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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.dgFiles = New System.Windows.Forms.DataGridView()
        Me.pbProcess = New System.Windows.Forms.Button()
        Me.pbClose = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.picCores = New System.Windows.Forms.PictureBox()
        Me.dfCores = New System.Windows.Forms.NumericUpDown()
        Me.cbSTL = New System.Windows.Forms.CheckBox()
        Me.cbOBJ = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colModified = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBuild = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPreview = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.dgFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dfCores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgFiles
        '
        Me.dgFiles.AllowUserToAddRows = False
        Me.dgFiles.AllowUserToDeleteRows = False
        Me.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colName, Me.colModified, Me.colBuild, Me.colStatus, Me.colPreview})
        Me.dgFiles.Location = New System.Drawing.Point(2, 1)
        Me.dgFiles.Name = "dgFiles"
        Me.dgFiles.RowTemplate.Height = 128
        Me.dgFiles.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgFiles.ShowEditingIcon = False
        Me.dgFiles.Size = New System.Drawing.Size(785, 380)
        Me.dgFiles.TabIndex = 0
        '
        'pbProcess
        '
        Me.pbProcess.Location = New System.Drawing.Point(2, 387)
        Me.pbProcess.Name = "pbProcess"
        Me.pbProcess.Size = New System.Drawing.Size(162, 23)
        Me.pbProcess.TabIndex = 1
        Me.pbProcess.UseVisualStyleBackColor = True
        '
        'pbClose
        '
        Me.pbClose.Location = New System.Drawing.Point(712, 387)
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
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'picCores
        '
        Me.picCores.Image = Global.scadbuild.My.Resources.Resources.processor
        Me.picCores.Location = New System.Drawing.Point(263, 387)
        Me.picCores.Name = "picCores"
        Me.picCores.Size = New System.Drawing.Size(37, 39)
        Me.picCores.TabIndex = 3
        Me.picCores.TabStop = False
        '
        'dfCores
        '
        Me.dfCores.Location = New System.Drawing.Point(306, 387)
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
        Me.cbSTL.Location = New System.Drawing.Point(382, 387)
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
        Me.cbOBJ.Location = New System.Drawing.Point(464, 387)
        Me.cbOBJ.Name = "cbOBJ"
        Me.cbOBJ.Size = New System.Drawing.Size(46, 19)
        Me.cbOBJ.TabIndex = 6
        Me.cbOBJ.Text = "OBJ"
        Me.ToolTip1.SetToolTip(Me.cbOBJ, "Build OBJ")
        Me.cbOBJ.UseVisualStyleBackColor = True
        '
        'colName
        '
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colName.HeaderText = "Source Name and Dependancies"
        Me.colName.Name = "colName"
        Me.colName.ReadOnly = True
        Me.colName.Width = 220
        '
        'colModified
        '
        Me.colModified.HeaderText = "Age"
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
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colStatus.DefaultCellStyle = DataGridViewCellStyle4
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.Width = 150
        '
        'colPreview
        '
        Me.colPreview.HeaderText = "Preview"
        Me.colPreview.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.colPreview.Name = "colPreview"
        Me.colPreview.Width = 196
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 434)
        Me.Controls.Add(Me.cbOBJ)
        Me.Controls.Add(Me.cbSTL)
        Me.Controls.Add(Me.dfCores)
        Me.Controls.Add(Me.picCores)
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.pbProcess)
        Me.Controls.Add(Me.dgFiles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "OpenScad Batch Builder"
        CType(Me.dgFiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dfCores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgFiles As DataGridView
    Friend WithEvents pbProcess As Button
    Friend WithEvents pbClose As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents picCores As PictureBox
    Friend WithEvents dfCores As NumericUpDown
    Friend WithEvents cbSTL As CheckBox
    Friend WithEvents cbOBJ As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colModified As DataGridViewTextBoxColumn
    Friend WithEvents colBuild As DataGridViewCheckBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents colPreview As DataGridViewImageColumn
End Class
