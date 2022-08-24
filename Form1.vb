Option Explicit On

Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports Microsoft.Win32
Imports System.Text.RegularExpressions



Public Class frmMain


    Enum enumStatus As Integer
        status_noset = -1
        status_process = 0
        status_pause = 1
        status_resume = 2
        status_finished = 3
    End Enum


    Dim m_status As enumStatus = enumStatus.status_process

    Dim m_arr_status As String() = {"Process", "Pause Processing", "Resume Processing", "Reload"}

    Private Sub setstatus(Optional st As enumStatus = enumStatus.status_noset)
        If (st > enumStatus.status_noset) Then
            m_status = st
        End If

        pbProcess.Text = m_arr_status(m_status)
    End Sub

    Dim m_processors As Integer
    Dim m_total As Integer
    Dim m_processing As Integer
    Dim m_waiting As Integer
    Dim m_processed As Integer

    Const quote As String = ChrW(34)

    Dim m_exe As String = ""


    Class strTag

        Public _fullname As String
        Public _status As Integer
        Public _wrtime As Date
        Public _process As Process
        Public _ts As TimeSpan
        Public _dep As String
    End Class

    '  https://regex101.com/    tester

    Private m_arr_includes() As String = {"\s*(?i)use\s*<[a-z,A-Z]*.(?i)scad>\s*", "\s*(?i)use\s*<[a-z,A-Z]*.(?i)scad>\s*"}

    Private Function GetTreeDateTime(depth As Integer, fn As String, ByRef tag As strTag) As Date

        Dim sr = File.OpenText(fn)

        Dim i As Integer = 0

        Dim dt As Date = File.GetLastWriteTime(fn)

        While i < 10 And sr.EndOfStream = False
            Dim line = sr.ReadLine()

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

                            Dim dt_inc As Date = GetTreeDateTime(depth + 1, "source\" & src, tag)

                            If dt_inc > dt Then
                                dt = dt_inc
                            End If
                        End If
                    End If
                End If
            Next

            i += 1
        End While

        sr.Close()

        Return dt
    End Function

    Private Function ts(span As TimeSpan) As String
        If span.Days > 1 Then
            Return String.Format("{0:#}+ days", span.Days)
        End If

        Return String.Format("{0:0#}:{1:0#}:{2:0#}", span.Hours, span.Minutes, span.Seconds)
    End Function

    ' open in stream so file is not locked

    Private Sub updateimage(Row As Integer)
        Dim bmp As Bitmap = Nothing

        Dim fs As FileStream = Nothing

        Dim tag As strTag = dgFiles.Rows(Row).Tag

        Try
            fs = New FileStream("output\" & Path.GetFileNameWithoutExtension(tag._fullname) & ".png", FileMode.Open)
            bmp = Bitmap.FromStream(fs)
        Catch e As Exception
            bmp = New Bitmap(32, 32, Imaging.PixelFormat.Format24bppRgb)
        End Try

        If fs IsNot Nothing Then
            fs.Close()
        End If

        dgFiles.Rows(Row).Cells(4).Value = bmp
    End Sub


    Private Sub updatestatus()
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



    Private Sub advancestatus()

        If m_processing = 0 And m_waiting = 0 Then Return

        For i As Integer = 0 To dgFiles.Rows.Count - 1
            Dim tag As strTag = dgFiles.Rows(i).Tag

            If dgFiles.Rows(i).Cells(2).Value = True Then
                If tag._status = 0 And m_status = enumStatus.status_pause Then ' is waiting and not paused
                    If m_processing < dfCores.Value Then
                        Dim fn As String = Path.GetFileNameWithoutExtension(tag._fullname)

                        Dim cmd1 As String = ""

                        If cbSTL.Checked Then
                            cmd1 &= " --o " & quote & "output\" & fn & ".stl" & quote
                        End If

                        If cbOBJ.Checked Then
                            cmd1 &= " --o " & quote & "output\" & fn & ".obj" & quote
                        End If

                        cmd1 &= " --o " & quote & "output\" & fn & ".png" & quote
                        cmd1 &= " --imgsize=1024,1024"
                        cmd1 &= " --render png"
                        cmd1 &= " " & quote & tag._fullname & quote

                        Dim exe = m_exe.Substring(0, m_exe.Length - 5)

                        tag._process = Process.Start(exe, cmd1)

                        tag._status += 1

                        dgFiles.Rows(i).Cells(3).Value = "Submitted"
                        m_processing += 1
                        m_waiting -= 1
                    End If
                ElseIf tag._status = 1 Then ' is processing

                    If Not Tag._process.HasExited Then
                        Tag._ts = Now() - Tag._process.StartTime()
                    End If

                    Dim el As String = ts(Tag._ts) ' = ts.Hours.ToString  & ":" & 


                    Dim t As String

                    If Tag._process.PriorityClass = ProcessPriorityClass.Idle Then
                        t = "Slowed"
                    Else
                        If tag._process.HasExited Then
                            t = "Finished"
                        Else
                            t = "Processing"
                        End If
                    End If

                    t &= vbCrLf & "PID=" & tag._process.Id.ToString & vbCrLf _
                        & "Threads=" & tag._process.Threads.Count.ToString & vbCrLf _
                        & "CPU=" & ts(tag._process.UserProcessorTime) & vbCrLf _
                        & "Elapsed=" & el ' & vbCrLf _


                    If tag._process.HasExited Then
                        t &= vbCrLf & "Exit Code=" & tag._process.ExitCode
                        tag._status += 1
                        updateimage(i)
                        m_processing -= 1
                        m_processed += 1
                    End If

                    dgFiles.Rows(i).Cells(3).Value = t
                Else ' not processed
                    If Tag._status = 0 Then
                        dgFiles.Rows(i).Cells(3).Value = "Omitted"
                        Tag._status += 1

                    End If
                End If
            End If
        Next
    End Sub


    Private Sub Populate()
        dgFiles.Rows.Clear()

        Dim m_files() As String = Nothing

        m_files = Directory.GetFiles("source", "lib_*.scad")

        For i As Integer = 0 To m_files.Count - 1

            Dim png As String = "output" & Path.DirectorySeparatorChar & Path.GetFileNameWithoutExtension(m_files(i)) & ".png"

            Dim wrtime_png As Date

            Dim wrtime As Date = File.GetLastWriteTime(m_files(i))



            Dim tag As New strTag

            tag._process = Nothing
            tag._wrtime = wrtime
            tag._fullname = m_files(i)
            tag._status = 0
            tag._dep = ""

            Dim dt As Date = GetTreeDateTime(0, m_files(i), tag)

            If dt > tag._wrtime Then
                tag._wrtime = dt
            End If

            If File.Exists(png) Then
                wrtime_png = File.GetLastWriteTime(png)
            Else
                wrtime_png = Date.MinValue
            End If

            Dim proc As Boolean = (wrtime_png < tag._wrtime)

            Dim diff = Date.Now() - tag._wrtime
            Dim objrow() = {Path.GetFileName(m_files(i) & tag._dep), ts(diff), proc, "", Nothing}

            Dim idx As Integer = dgFiles.Rows.Add(objrow)



            dgFiles.Rows(i).Tag = tag

            updateimage(i)

        Next

        updatestatus()

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NotifyIcon1.Visible = True

        setstatus()

        Dim kv = Registry.GetValue("HKEY_CLASSES_ROOT\OpenSCAD_File\shell\open\command", "", "")
        Try
            m_exe = kv
        Catch ex As Exception
            m_exe = ""
        End Try

        m_processors = Environment.ProcessorCount

        dfCores.Minimum = 1
        dfCores.Maximum = m_processors
        dfCores.Value = m_processors

        Dim cpu As String = Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", "")

        ToolTip1.SetToolTip(picCores, cpu.ToString)

        Populate()

        If m_exe.Length < 10 Then
            pbProcess.Enabled = False
            MsgBox("Unabled to find the executable for type .scad", "Error", MsgBoxResult.Ok)
        End If
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


            NotifyIcon1.BalloonTipTitle = "OpenScad Batch Builder"
            NotifyIcon1.BalloonTipText = "Finished: Processed " & m_processed & " files."
            NotifyIcon1.ShowBalloonTip(5000)

            setstatus(enumStatus.status_finished)
            'Populate()
        End If
    End Sub

    Private Sub pbClose_Click(sender As Object, e As EventArgs) Handles pbClose.Click
        Close()
    End Sub
End Class
