Option Explicit On

Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports Microsoft.Win32
Imports System.Text.RegularExpressions
Imports System.Collections

' Initial Code : Dean B White - Kiweed Software
'


Public Class frmMain
    Private Enum enumStatus As Integer
        status_noset = -1
        status_process = 0
        status_pause = 1
        status_resume = 2
        status_finished = 3
    End Enum

    Private m_status As enumStatus = enumStatus.status_process
    Private m_processors As Integer
    Private m_total As Integer
    Private m_processing As Integer
    Private m_waiting As Integer
    Private m_processed As Integer

    Private Const m_quote As String = ChrW(34)

    Private m_exe As String = "" ' name and path of openscad exe if found

    Private m_arr_status As String() = {"Process", "Pause Processing", "Resume Processing", "Finished"}

    Private Sub SetStatus(Optional st As enumStatus = enumStatus.status_noset)
        If (st > enumStatus.status_noset) Then
            m_status = st
        End If

        pbProcess.Text = m_arr_status(m_status)
    End Sub

    ' Holds info for each file
    Private Class strTag
        Public _fullname As String  ' path ... name ... ext

        Public _outdir As String

        Public _status As Integer
        Public _wrtime As Date
        Public _process As Process
        Public _ts As TimeSpan
        Public _dep As String
        Public _lines As Integer
        Public _size As Integer
        Public _invalid As Boolean
    End Class

    '  https://regex101.com/    tester

    Private m_arr_includes() As String = {"\s*(?i)use\s*<[a-z,A-Z]*.(?i)scad>\s*", "\s*(?i)use\s*<[a-z,A-Z]*.(?i)scad>\s*"}

    Private Function GetTreeDateTime(depth As Integer, fn As String, ByRef tag As strTag) As Date
        Dim arr_lines() As String

        Try
            Dim fi As New FileInfo(fn)

            Dim dt = fi.LastWriteTime

            arr_lines = File.ReadAllLines(fn)

            If depth = 0 Then
                tag._lines = arr_lines.Count
                tag._size = fi.Length
            End If

            For i As Integer = 0 To arr_lines.Count - 1
                Dim line = arr_lines(i)

                For u As Integer = 0 To m_arr_includes.Count - 1
                    Dim m As Match = Regex.Match(line, m_arr_includes(u))

                    If (m.Success) Then
                        Dim f() As String = Regex.Split(line, "[<>]", RegexOptions.IgnoreCase)

                        If f.Count >= 1 And f.Count >= 2 Then
                            Dim src As String = f(1) ' xxxxxx.scad

                            ' todo check existing to make sure not already in their (ie. circular reference)

                            Dim check As String = tag._dep.ToUpper()

                            If check.IndexOf(src.ToUpper) < 0 Then ' not found
                                tag._dep &= vbCrLf & line & "[" & depth.ToString & "]"

                                ' need full paths ... then check to see if it exists!!!!!

                                Dim fpath = Path.Combine(Path.GetDirectoryName(fn), Path.GetDirectoryName(src))

                                fpath &= "\" & Path.GetFileName(src)

                                If File.Exists(fpath) Then
                                    Dim dt_inc As Date = GetTreeDateTime(depth + 1, fpath, tag)

                                    If dt_inc > dt Then
                                        dt = dt_inc
                                    End If
                                Else
                                    tag._invalid = True
                                End If
                            End If
                        End If
                    End If
                Next
            Next

            Return dt
        Catch ex As Exception
        End Try

        Return Now()
    End Function

    Private Function FormatBytes(bytes As Integer) As String
        If bytes < 1024 Then Return bytes.ToString & " bytes"
        If bytes < 1024 * 1024 Then Return (CInt(bytes / 102.4F) / 10).ToString & "KB"
        Return (CInt(bytes / (1024 * 102.4F)) / 10).ToString & "MB"
    End Function

    Private Function FormatTimespan(span As TimeSpan) As String
        If span.Days > 1 Then
            Return String.Format("{0:#}+ days", span.Days)
        End If

        Return String.Format("{0:0#}:{1:0#}:{2:0#}", span.Hours, span.Minutes, span.Seconds)
    End Function

    ' open in stream so file is not locked

    Private Sub UpdateImage(Row As Integer)
        Dim bmp As Bitmap = Nothing
        Dim fs As FileStream = Nothing
        Dim tag As strTag = dgFiles.Rows(Row).Tag

        Dim fn As String = tag._outdir & "\" & Path.GetFileNameWithoutExtension(tag._fullname) & ".png"

        If File.Exists(fn) Then
            Try
                fs = New FileStream(fn, FileMode.Open)
                bmp = Bitmap.FromStream(fs)
            Catch e As Exception
                bmp = New Bitmap(32, 32, Imaging.PixelFormat.Format24bppRgb)
            End Try

            If fs IsNot Nothing Then
                fs.Close()
            End If
        Else
            bmp = New Bitmap(32, 32, Imaging.PixelFormat.Format24bppRgb)
        End If

        dgFiles.Rows(Row).Cells(4).Value = bmp
    End Sub


    Private Sub UpdateStatus()
        m_total = 0
        m_processing = 0
        m_waiting = 0
        m_processed = 0

        For i As Integer = 0 To dgFiles.Rows.Count - 1
            m_total += 1

            If dgFiles.Rows(i).Cells(2).Value = True Then
                Dim tag As strTag = dgFiles.Rows(i).Tag

                If tag._status = 0 Then
                    m_waiting += 1
                ElseIf tag._status = 1 Then
                    m_processing += 1
                End If
            End If
        Next
    End Sub


    Private Sub AdvanceStatus()
        If m_processing = 0 And m_waiting = 0 Then Return

        Dim limit As Single = Val(cmbCPULimit.SelectedItem.ToString) * 60.0F ' seconds

        For i As Integer = 0 To dgFiles.Rows.Count - 1
            Dim tag As strTag = dgFiles.Rows(i).Tag

            If dgFiles.Rows(i).Cells(2).Value = True Then
                If tag._status = 0 And m_status = enumStatus.status_pause Then ' is waiting and not paused
                    dgFiles.Rows(i).Cells(3).Value = "Waiting in Queue"

                    If m_processing < dfCores.Value Then
                        Dim fn As String = Path.GetFileNameWithoutExtension(tag._fullname)

                        Dim cmd1 As String = ""

                        If cbSTL.Checked Then
                            cmd1 &= " --o " & m_quote & tag._outdir & "\" & fn & ".stl" & m_quote
                        End If

                        If cbOBJ.Checked Then
                            cmd1 &= " --o " & m_quote & tag._outdir & "\" & fn & ".obj" & m_quote
                        End If

                        cmd1 &= " --o " & m_quote & tag._outdir & "\" & fn & ".png" & m_quote
                        cmd1 &= " --imgsize=1024,1024"
                        cmd1 &= " --render png"
                        cmd1 &= " " & m_quote & tag._fullname & m_quote

                        tag._process = Process.Start(m_exe, cmd1)

                        tag._status += 1

                        dgFiles.Rows(i).Cells(3).Value = "Submitted"
                        m_processing += 1
                        m_waiting -= 1
                    End If
                ElseIf tag._status = 1 Then ' is processing
                    If Not tag._process.HasExited Then
                        tag._ts = Now() - tag._process.StartTime()

                        dgFiles.Rows(i).Cells(3).Style.BackColor = Color.Orchid
                    End If

                    Dim el As String = FormatTimespan(tag._ts) ' = ts.Hours.ToString  & ":" & 

                    Dim pr As ProcessPriorityClass

                    Try
                        pr = tag._process.PriorityClass
                    Catch ex As Exception
                        pr = ProcessPriorityClass.Normal
                    End Try

                    Dim t As String

                    If pr = ProcessPriorityClass.Idle Then
                        t = "Slowed"
                    Else
                        If tag._process.HasExited Then
                            t = "Finished"
                            dgFiles.Rows(i).Cells(3).Style.BackColor = Color.Green
                        Else
                            ' Check for over CPU

                            If tag._process.UserProcessorTime.Seconds > limit Then
                                tag._process.Kill(True)
                                t = "Stopped/CPU Limit"
                                dgFiles.Rows(i).Cells(3).Style.BackColor = Color.Red
                            Else
                                t = "Processing"
                            End If
                        End If
                    End If

                    t &= vbCrLf & "PID=" & tag._process.Id.ToString & vbCrLf _                   '     & "Threads=" & tag._process.Threads.Count.ToString & vbCrLf _
                        & "CPU=" & FormatTimespan(tag._process.UserProcessorTime) & vbCrLf _
                        & "Elapsed=" & el ' & vbCrLf _

                    If tag._process.HasExited Then
                        t &= vbCrLf & "Exit Code=" & tag._process.ExitCode
                        tag._status += 1
                        UpdateImage(i)
                        m_processing -= 1
                        m_processed += 1
                    End If

                    dgFiles.Rows(i).Cells(3).Value = t
                End If
            Else ' not processed .. not counted for anything
                dgFiles.Rows(i).Cells(3).Value = "Omitted"
            End If
        Next
    End Sub

    Private Sub AddFiles(dir As String, ByRef files As List(Of String), depth As Integer)

        ' ignore if is backup

        If dir.ToUpper.Contains("\BACKUP") Then
            Return
        End If

        Dim _files = Directory.GetFiles(dir, dfFilter.Text & ".scad")

        If (_files.Count > 0) Then
            For u As Integer = 0 To _files.Count - 1
                Dim fi As New FileInfo(_files(u))

                If fi.Length >= 32 Then
                    files.Add(_files(u))
                End If
            Next
        End If

        If cbFolders.Checked Then
            Dim _dirs = Directory.GetDirectories(dir)

            For i As Integer = 0 To _dirs.Count - 1
                AddFiles(_dirs(i), files, depth + 1)
            Next
        End If
    End Sub

    Private Sub Populate()
        dgFiles.Rows.Clear()

        Dim m_files As New List(Of String)

        AddFiles(dfInDir.Text, m_files, 0)

        dgFiles.SuspendLayout()

        For i As Integer = 0 To m_files.Count - 1
            Dim tag As New strTag

            If cbOutputSameDir.Checked = True Then
                tag._outdir = Path.GetDirectoryName(m_files(i))
            Else
                tag._outdir = dfOutDir.Text
            End If

            Dim png As String = tag._outdir & Path.DirectorySeparatorChar & Path.GetFileNameWithoutExtension(m_files(i)) & ".png"

            Dim wrtime_png As Date

            Dim wrtime As Date = File.GetLastWriteTime(m_files(i))

            tag._process = Nothing
            tag._wrtime = wrtime
            Tag._fullname = m_files(i)
            Tag._status = 0
            tag._dep = ""
            tag._invalid = False

            Dim dt As Date = GetTreeDateTime(0, m_files(i), Tag)

            If tag._invalid = False Then ' invalid cause use or include a file that's not found
                If dt > tag._wrtime Then
                    tag._wrtime = dt
                End If

                If File.Exists(png) Then
                    wrtime_png = File.GetLastWriteTime(png)
                Else
                    wrtime_png = Date.MinValue
                End If

                Dim proc As Boolean = (wrtime_png < tag._wrtime)

                Dim diff As TimeSpan = Date.Now() - tag._wrtime
                Dim objrow() = {Path.GetFileName(m_files(i)) & " " & FormatBytes(tag._size) & tag._dep, FormatTimespan(diff), proc, "", Nothing}

                Dim idx As Integer = dgFiles.Rows.Add(objrow)

                dgFiles.Rows(idx).Tag = tag
                UpdateImage(idx)
            End If
        Next

        dgFiles.ResumeLayout()

        UpdateStatus()

    End Sub

    Private Shared Function PlaySound(fn As String) As Boolean
        Try
            Dim x As New Media.SoundPlayer()

            x.SoundLocation = fn
            x.Load()
            x.Play()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Shared Function RegGetVal(val As String, deft As Object) As Object
        Dim res As Object = Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Kiweed\ScadBuild", val, deft)

        If res Is Nothing Then
            res = deft
        End If

        Return res
    End Function

    Private Shared Function RegSetVal(val As String, deft As Object) As Boolean
        Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Kiweed\ScadBuild", val, deft)

        Return True
    End Function

    Private Sub SaveKeys()
        RegSetVal("Sound2", dfSound2.Text)
        RegSetVal("PlaySound2", CInt(cbPlay2.Checked))

        RegSetVal("InputDir", dfInDir.Text)
        RegSetVal("OutputDir", dfOutDir.Text)
        RegSetVal("OutputSame", CInt(cbOutputSameDir.Checked))
        RegSetVal("SubFolders", CInt(cbFolders.Checked))
        RegSetVal("Filter", dfFilter.Text)

        RegSetVal("MakeOBJ", CInt(cbOBJ.Checked))
        RegSetVal("MakeSTL", CInt(cbSTL.Checked))
    End Sub
    Private Sub LoadKeys()
        Dim deft As Object = Nothing
        dfSound2.Text = RegGetVal("Sound2", Path.GetDirectoryName(Application.ExecutablePath) & "\resources\tts_finish1.wav").ToString()
        cbPlay2.Checked = RegGetVal("PlaySound2", 1)

        dfInDir.Text = RegGetVal("InputDir", "c:\temp").ToString()
        dfOutDir.Text = RegGetVal("OutputDir", "c:\temp").ToString
        cbOutputSameDir.Checked = RegGetVal("OutputSame", 1)
        cbFolders.Checked = RegGetVal("SubFolders", 0)
        dfFilter.Text = RegGetVal("Filter", "lib_*").ToString

        cbOBJ.Checked = RegGetVal("MakeOBJ", 1)
        cbSTL.Checked = RegGetVal("MakeSTL", 1)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' NotifyIcon1.Visible = True

        SetStatus()

        Dim kv As Object = Registry.GetValue("HKEY_CLASSES_ROOT\OpenSCAD_File\shell\open\command", "", "")

        Try
            m_exe = kv.ToString()

            m_exe = m_exe.Replace(" " & m_quote & "%1" & m_quote, "")
        Catch ex As Exception
            m_exe = ""
        End Try

        m_processors = Environment.ProcessorCount

        dfCores.Minimum = 1
        dfCores.Maximum = m_processors
        dfCores.Value = m_processors

        cmbCPULimit.SelectedIndex = 0

        Dim cpu As String = Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", "")

        ToolTip1.SetToolTip(picCores, cpu.ToString)

        If m_exe.Length < 10 Then
            pbProcess.Enabled = False
            MsgBox("Unabled to find the executable for type .scad", "Error", MsgBoxResult.Ok)
        End If

        ' make registry keys to save stuff



        LoadKeys()

        Populate()
    End Sub

    Sub PauseAll()
        For i As Integer = 0 To dgFiles.Rows.Count - 1
            Dim tag As strTag = dgFiles.Rows(i).Tag

            If tag._status = 1 Then
                tag._process.PriorityClass = ProcessPriorityClass.Idle
            End If
        Next
    End Sub

    Sub ResumeAll()
        For i As Integer = 0 To dgFiles.Rows.Count - 1
            Dim tag As strTag = dgFiles.Rows(i).Tag

            If tag._status = 1 Then
                tag._process.PriorityClass = ProcessPriorityClass.Normal
            End If
        Next
    End Sub

    Private Sub pbProcess_Click(sender As Object, e As EventArgs) Handles pbProcess.Click
        If m_status = enumStatus.status_process Then
            For i As Integer = dgFiles.Rows.Count - 1 To 0 Step -1
                If dgFiles.Rows(i).Cells(2).Value = False Then
                    dgFiles.Rows.RemoveAt(i)
                End If
            Next
            setstatus(m_status + 1)
            Timer1.Start()

            pbRescan.Enabled = False
        ElseIf m_status = enumStatus.status_pause Then
            PauseAll()
            setstatus(m_status + 1)
            '    Timer1.Stop()
        ElseIf m_status = enumStatus.status_resume Then
            ResumeAll()
            setstatus(enumStatus.status_pause)
            '      Timer1.Start()
        ElseIf m_status = enumStatus.status_finished Then
            Populate()
            setstatus(enumStatus.status_process)
        End If

        updatestatus()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        updatestatus()
        advancestatus()
        Application.DoEvents()

        If m_waiting = 0 And m_processing = 0 Then
            Timer1.Stop()

            ' NotifyIcon1.BalloonTipTitle = "OpenScad Batch Builder"
            ' NotifyIcon1.BalloonTipText = "Finished: Processed " & m_processed & " files."
            ' NotifyIcon1.ShowBalloonTip(5000)

            SetStatus(enumStatus.status_finished)

            If cbPlay2.Checked And m_processed > 0 Then
                PlaySound(dfSound2.Text)
            End If

            pbProcess.Enabled = False
            pbRescan.Enabled = True
        End If
    End Sub

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        SaveKeys()
        Close()
    End Sub

    Private Sub pbRescan_Click(sender As Object, e As EventArgs) Handles pbRescan.Click
        Populate()
        SetStatus(enumStatus.status_process)
        pbProcess.Enabled = True
    End Sub

    Private Sub pbInputDir_Click(sender As Object, e As EventArgs) Handles pbInputDir.Click

        FolderBrowserDialog1.SelectedPath = dfInDir.Text

        Dim res = FolderBrowserDialog1.ShowDialog()

        If res = DialogResult.OK Then
            dfInDir.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub pbOutputDir_Click(sender As Object, e As EventArgs) Handles pbOutputDir.Click
        Dim res = FolderBrowserDialog1.ShowDialog()

        If res = DialogResult.OK Then
            dfOutDir.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub pbTest1_Click(sender As Object, e As EventArgs) Handles pbTest1.Click
        PlaySound(dfSound2.Text)
    End Sub

    Private Sub pbSound2_Click(sender As Object, e As EventArgs) Handles pbSound2.Click
        OpenFileDialog1.FileName = Path.GetFileName(dfSound2.Text)
        OpenFileDialog1.InitialDirectory = Path.GetDirectoryName(dfSound2.Text)

        Dim ret = OpenFileDialog1.ShowDialog()

        If ret = DialogResult.OK Then
            dfSound2.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim about = New frmAbout()

        about.ShowDialog()
    End Sub

    Dim lastPage As Integer = -1
    Private Sub tabChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If lastPage = 1 Then
            SaveKeys()
        End If

        lastPage = TabControl1.SelectedIndex

    End Sub
End Class
