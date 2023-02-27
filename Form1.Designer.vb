<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.dgFiles = New System.Windows.Forms.DataGridView()
        Me.pbProcess = New System.Windows.Forms.Button()
        Me.pbClose = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.picCores = New System.Windows.Forms.PictureBox()
        Me.dfCores = New System.Windows.Forms.NumericUpDown()
        Me.cbSTL = New System.Windows.Forms.CheckBox()
        Me.cbOBJ = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dfFilter = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pbRescan = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbCPULimit = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pbTest1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pbSound2 = New System.Windows.Forms.Button()
        Me.cbPlay2 = New System.Windows.Forms.CheckBox()
        Me.dfSound2 = New System.Windows.Forms.TextBox()
        Me.cbFolders = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbOutputDir = New System.Windows.Forms.Button()
        Me.dfInDir = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbInputDir = New System.Windows.Forms.Button()
        Me.cbOutputSameDir = New System.Windows.Forms.CheckBox()
        Me.dfOutDir = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colModified = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBuild = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPreview = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.dgFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dfCores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgFiles
        '
        Me.dgFiles.AllowUserToAddRows = False
        Me.dgFiles.AllowUserToDeleteRows = False
        Me.dgFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colName, Me.colModified, Me.colBuild, Me.colStatus, Me.colPreview})
        Me.dgFiles.Location = New System.Drawing.Point(6, 6)
        Me.dgFiles.Name = "dgFiles"
        Me.dgFiles.RowTemplate.Height = 128
        Me.dgFiles.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFiles.ShowEditingIcon = False
        Me.dgFiles.Size = New System.Drawing.Size(799, 455)
        Me.dgFiles.TabIndex = 0
        '
        'pbProcess
        '
        Me.pbProcess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbProcess.Location = New System.Drawing.Point(7, 467)
        Me.pbProcess.Name = "pbProcess"
        Me.pbProcess.Size = New System.Drawing.Size(162, 23)
        Me.pbProcess.TabIndex = 1
        Me.pbProcess.UseVisualStyleBackColor = True
        '
        'pbClose
        '
        Me.pbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbClose.Location = New System.Drawing.Point(724, 467)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(75, 23)
        Me.pbClose.TabIndex = 2
        Me.pbClose.Text = "Close"
        Me.pbClose.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'picCores
        '
        Me.picCores.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picCores.Image = Global.scadbuild.My.Resources.Resources.processor
        Me.picCores.Location = New System.Drawing.Point(388, 467)
        Me.picCores.Name = "picCores"
        Me.picCores.Size = New System.Drawing.Size(37, 39)
        Me.picCores.TabIndex = 3
        Me.picCores.TabStop = False
        '
        'dfCores
        '
        Me.dfCores.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dfCores.Location = New System.Drawing.Point(431, 467)
        Me.dfCores.Name = "dfCores"
        Me.dfCores.Size = New System.Drawing.Size(57, 23)
        Me.dfCores.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.dfCores, "Maximum number of CPU threads to use")
        '
        'cbSTL
        '
        Me.cbSTL.AutoSize = True
        Me.cbSTL.Checked = True
        Me.cbSTL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSTL.Location = New System.Drawing.Point(6, 38)
        Me.cbSTL.Name = "cbSTL"
        Me.cbSTL.Size = New System.Drawing.Size(44, 19)
        Me.cbSTL.TabIndex = 5
        Me.cbSTL.Text = "STL"
        Me.ToolTip1.SetToolTip(Me.cbSTL, "Build STL")
        Me.cbSTL.UseVisualStyleBackColor = True
        '
        'cbOBJ
        '
        Me.cbOBJ.AutoSize = True
        Me.cbOBJ.Checked = True
        Me.cbOBJ.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbOBJ.Location = New System.Drawing.Point(80, 38)
        Me.cbOBJ.Name = "cbOBJ"
        Me.cbOBJ.Size = New System.Drawing.Size(46, 19)
        Me.cbOBJ.TabIndex = 6
        Me.cbOBJ.Text = "OBJ"
        Me.ToolTip1.SetToolTip(Me.cbOBJ, "Build OBJ")
        Me.cbOBJ.UseVisualStyleBackColor = True
        '
        'dfFilter
        '
        Me.dfFilter.Location = New System.Drawing.Point(18, 34)
        Me.dfFilter.MaxLength = 20
        Me.dfFilter.Name = "dfFilter"
        Me.dfFilter.Size = New System.Drawing.Size(176, 23)
        Me.dfFilter.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.dfFilter, "Enter filter (eg. lib_*, module*)")
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(823, 548)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.pbRescan)
        Me.TabPage1.Controls.Add(Me.dgFiles)
        Me.TabPage1.Controls.Add(Me.pbClose)
        Me.TabPage1.Controls.Add(Me.dfCores)
        Me.TabPage1.Controls.Add(Me.pbProcess)
        Me.TabPage1.Controls.Add(Me.picCores)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(815, 520)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Build"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'pbRescan
        '
        Me.pbRescan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbRescan.Image = Global.scadbuild.My.Resources.Resources.magnifier
        Me.pbRescan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.pbRescan.Location = New System.Drawing.Point(182, 468)
        Me.pbRescan.Name = "pbRescan"
        Me.pbRescan.Size = New System.Drawing.Size(81, 43)
        Me.pbRescan.TabIndex = 7
        Me.pbRescan.Text = "Rescan"
        Me.pbRescan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.pbRescan.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.cmbCPULimit)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.pbTest1)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.pbSound2)
        Me.TabPage2.Controls.Add(Me.cbPlay2)
        Me.TabPage2.Controls.Add(Me.dfSound2)
        Me.TabPage2.Controls.Add(Me.cbFolders)
        Me.TabPage2.Controls.Add(Me.dfFilter)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.pbOutputDir)
        Me.TabPage2.Controls.Add(Me.dfInDir)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.pbInputDir)
        Me.TabPage2.Controls.Add(Me.cbOutputSameDir)
        Me.TabPage2.Controls.Add(Me.dfOutDir)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(805, 436)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Options"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(393, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 15)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Minutes"
        '
        'cmbCPULimit
        '
        Me.cmbCPULimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPULimit.FormattingEnabled = True
        Me.cmbCPULimit.Items.AddRange(New Object() {"5", "4", "3", "2", "1"})
        Me.cmbCPULimit.Location = New System.Drawing.Point(302, 34)
        Me.cmbCPULimit.Name = "cmbCPULimit"
        Me.cmbCPULimit.Size = New System.Drawing.Size(85, 23)
        Me.cmbCPULimit.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(302, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "CPU Limit"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbSTL)
        Me.GroupBox1.Controls.Add(Me.cbOBJ)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 346)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(775, 72)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Output Types"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(200, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 15)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = ".scad"
        '
        'pbTest1
        '
        Me.pbTest1.Location = New System.Drawing.Point(679, 299)
        Me.pbTest1.Name = "pbTest1"
        Me.pbTest1.Size = New System.Drawing.Size(75, 23)
        Me.pbTest1.TabIndex = 14
        Me.pbTest1.Text = "Test"
        Me.pbTest1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Sound"
        '
        'pbSound2
        '
        Me.pbSound2.Location = New System.Drawing.Point(760, 269)
        Me.pbSound2.Name = "pbSound2"
        Me.pbSound2.Size = New System.Drawing.Size(30, 23)
        Me.pbSound2.TabIndex = 12
        Me.pbSound2.Text = "..."
        Me.pbSound2.UseVisualStyleBackColor = True
        '
        'cbPlay2
        '
        Me.cbPlay2.AutoSize = True
        Me.cbPlay2.Location = New System.Drawing.Point(18, 299)
        Me.cbPlay2.Name = "cbPlay2"
        Me.cbPlay2.Size = New System.Drawing.Size(127, 19)
        Me.cbPlay2.TabIndex = 11
        Me.cbPlay2.Text = "Play when Finished"
        Me.cbPlay2.UseVisualStyleBackColor = True
        '
        'dfSound2
        '
        Me.dfSound2.Location = New System.Drawing.Point(18, 270)
        Me.dfSound2.Name = "dfSound2"
        Me.dfSound2.ReadOnly = True
        Me.dfSound2.Size = New System.Drawing.Size(736, 23)
        Me.dfSound2.TabIndex = 10
        '
        'cbFolders
        '
        Me.cbFolders.AutoSize = True
        Me.cbFolders.Location = New System.Drawing.Point(17, 126)
        Me.cbFolders.Name = "cbFolders"
        Me.cbFolders.Size = New System.Drawing.Size(157, 19)
        Me.cbFolders.TabIndex = 9
        Me.cbFolders.Text = "Also Include Sub-Folders"
        Me.cbFolders.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Input File Filter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Output Directory"
        '
        'pbOutputDir
        '
        Me.pbOutputDir.Location = New System.Drawing.Point(759, 182)
        Me.pbOutputDir.Name = "pbOutputDir"
        Me.pbOutputDir.Size = New System.Drawing.Size(30, 23)
        Me.pbOutputDir.TabIndex = 5
        Me.pbOutputDir.Text = "..."
        Me.pbOutputDir.UseVisualStyleBackColor = True
        '
        'dfInDir
        '
        Me.dfInDir.Location = New System.Drawing.Point(18, 91)
        Me.dfInDir.Name = "dfInDir"
        Me.dfInDir.ReadOnly = True
        Me.dfInDir.Size = New System.Drawing.Size(735, 23)
        Me.dfInDir.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Input Directory"
        '
        'pbInputDir
        '
        Me.pbInputDir.Location = New System.Drawing.Point(759, 90)
        Me.pbInputDir.Name = "pbInputDir"
        Me.pbInputDir.Size = New System.Drawing.Size(30, 23)
        Me.pbInputDir.TabIndex = 2
        Me.pbInputDir.Text = "..."
        Me.pbInputDir.UseVisualStyleBackColor = True
        '
        'cbOutputSameDir
        '
        Me.cbOutputSameDir.AutoSize = True
        Me.cbOutputSameDir.Location = New System.Drawing.Point(18, 212)
        Me.cbOutputSameDir.Name = "cbOutputSameDir"
        Me.cbOutputSameDir.Size = New System.Drawing.Size(100, 19)
        Me.cbOutputSameDir.TabIndex = 1
        Me.cbOutputSameDir.Text = "Same as Input"
        Me.cbOutputSameDir.UseVisualStyleBackColor = True
        '
        'dfOutDir
        '
        Me.dfOutDir.Location = New System.Drawing.Point(18, 183)
        Me.dfOutDir.Name = "dfOutDir"
        Me.dfOutDir.ReadOnly = True
        Me.dfOutDir.Size = New System.Drawing.Size(735, 23)
        Me.dfOutDir.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Sound Files|*.wav"
        Me.OpenFileDialog1.RestoreDirectory = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(832, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
        Me.ToolStripMenuItem1.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AboutToolStripMenuItem.Text = "About..."
        '
        'colName
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colName.DefaultCellStyle = DataGridViewCellStyle1
        Me.colName.HeaderText = "Source Name and Dependancies"
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        Me.colName.Width = 220
        '
        'colModified
        '
        Me.colModified.HeaderText = "Source Age"
        Me.colModified.Name = "colModified"
        '
        'colBuild
        '
        Me.colBuild.HeaderText = "Build"
        Me.colBuild.Name = "colBuild"
        Me.colBuild.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colBuild.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colBuild.Width = 50
        '
        'colStatus
        '
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colStatus.DefaultCellStyle = DataGridViewCellStyle2
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.Width = 150
        '
        'colPreview
        '
        Me.colPreview.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPreview.HeaderText = "Preview"
        Me.colPreview.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.colPreview.Name = "colPreview"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 593)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(848, 632)
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "OpenScad Batch Builder"
        CType(Me.dgFiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dfCores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgFiles As DataGridView
    Friend WithEvents pbProcess As Button
    Friend WithEvents pbClose As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents picCores As PictureBox
    Friend WithEvents dfCores As NumericUpDown
    Friend WithEvents cbSTL As CheckBox
    Friend WithEvents cbOBJ As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents pbOutputDir As Button
    Friend WithEvents dfInDir As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents pbInputDir As Button
    Friend WithEvents cbOutputSameDir As CheckBox
    Friend WithEvents dfOutDir As TextBox
    Friend WithEvents dfFilter As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pbRescan As Button
    Friend WithEvents cbFolders As CheckBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents pbSound2 As Button
    Friend WithEvents cbPlay2 As CheckBox
    Friend WithEvents dfSound2 As TextBox
    Friend WithEvents pbTest1 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmbCPULimit As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colModified As DataGridViewTextBoxColumn
    Friend WithEvents colBuild As DataGridViewCheckBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents colPreview As DataGridViewImageColumn
End Class
