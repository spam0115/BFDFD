<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlStep2
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.splitMain = New System.Windows.Forms.SplitContainer
        Me.lblStepDescription = New System.Windows.Forms.Label
        Me.split2 = New System.Windows.Forms.SplitContainer
        Me.splitInclude = New System.Windows.Forms.SplitContainer
        Me.Label1 = New System.Windows.Forms.Label
        Me.splitExclude1 = New System.Windows.Forms.SplitContainer
        Me.Label2 = New System.Windows.Forms.Label
        Me.splitExclude2 = New System.Windows.Forms.SplitContainer
        Me.lvExclude = New System.Windows.Forms.ListView
        Me.header1 = New System.Windows.Forms.ColumnHeader
        Me.splitExclude3 = New System.Windows.Forms.SplitContainer
        Me.txtExclude = New System.Windows.Forms.TextBox
        Me.cmdAddExclude = New System.Windows.Forms.Button
        Me.cmdBrowseExclude = New System.Windows.Forms.Button
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.split2.Panel1.SuspendLayout()
        Me.split2.Panel2.SuspendLayout()
        Me.split2.SuspendLayout()
        Me.splitInclude.Panel1.SuspendLayout()
        Me.splitInclude.SuspendLayout()
        Me.splitExclude1.Panel1.SuspendLayout()
        Me.splitExclude1.Panel2.SuspendLayout()
        Me.splitExclude1.SuspendLayout()
        Me.splitExclude2.Panel1.SuspendLayout()
        Me.splitExclude2.Panel2.SuspendLayout()
        Me.splitExclude2.SuspendLayout()
        Me.splitExclude3.Panel1.SuspendLayout()
        Me.splitExclude3.Panel2.SuspendLayout()
        Me.splitExclude3.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitMain
        '
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitMain.IsSplitterFixed = True
        Me.splitMain.Location = New System.Drawing.Point(0, 0)
        Me.splitMain.Name = "splitMain"
        Me.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.splitMain.Panel1.Controls.Add(Me.lblStepDescription)
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.Controls.Add(Me.split2)
        Me.splitMain.Size = New System.Drawing.Size(563, 308)
        Me.splitMain.SplitterDistance = 25
        Me.splitMain.TabIndex = 1
        Me.splitMain.TabStop = False
        '
        'lblStepDescription
        '
        Me.lblStepDescription.AutoSize = True
        Me.lblStepDescription.Location = New System.Drawing.Point(6, 6)
        Me.lblStepDescription.Name = "lblStepDescription"
        Me.lblStepDescription.Size = New System.Drawing.Size(299, 13)
        Me.lblStepDescription.TabIndex = 1
        Me.lblStepDescription.Text = "Step 2 : select directories  to include/exclude for research" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'split2
        '
        Me.split2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.split2.IsSplitterFixed = True
        Me.split2.Location = New System.Drawing.Point(0, 0)
        Me.split2.Name = "split2"
        '
        'split2.Panel1
        '
        Me.split2.Panel1.Controls.Add(Me.splitInclude)
        '
        'split2.Panel2
        '
        Me.split2.Panel2.Controls.Add(Me.splitExclude1)
        Me.split2.Size = New System.Drawing.Size(563, 279)
        Me.split2.SplitterDistance = 281
        Me.split2.TabIndex = 0
        '
        'splitInclude
        '
        Me.splitInclude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitInclude.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitInclude.IsSplitterFixed = True
        Me.splitInclude.Location = New System.Drawing.Point(0, 0)
        Me.splitInclude.Name = "splitInclude"
        Me.splitInclude.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitInclude.Panel1
        '
        Me.splitInclude.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.splitInclude.Panel1.Controls.Add(Me.Label1)
        Me.splitInclude.Size = New System.Drawing.Size(281, 279)
        Me.splitInclude.SplitterDistance = 25
        Me.splitInclude.TabIndex = 1
        Me.splitInclude.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Directories to include"
        '
        'splitExclude1
        '
        Me.splitExclude1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitExclude1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitExclude1.IsSplitterFixed = True
        Me.splitExclude1.Location = New System.Drawing.Point(0, 0)
        Me.splitExclude1.Name = "splitExclude1"
        Me.splitExclude1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitExclude1.Panel1
        '
        Me.splitExclude1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.splitExclude1.Panel1.Controls.Add(Me.Label2)
        '
        'splitExclude1.Panel2
        '
        Me.splitExclude1.Panel2.Controls.Add(Me.splitExclude2)
        Me.splitExclude1.Size = New System.Drawing.Size(278, 279)
        Me.splitExclude1.SplitterDistance = 25
        Me.splitExclude1.TabIndex = 2
        Me.splitExclude1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Directories to exclude"
        '
        'splitExclude2
        '
        Me.splitExclude2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitExclude2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitExclude2.IsSplitterFixed = True
        Me.splitExclude2.Location = New System.Drawing.Point(0, 0)
        Me.splitExclude2.Name = "splitExclude2"
        Me.splitExclude2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitExclude2.Panel1
        '
        Me.splitExclude2.Panel1.Controls.Add(Me.lvExclude)
        '
        'splitExclude2.Panel2
        '
        Me.splitExclude2.Panel2.Controls.Add(Me.splitExclude3)
        Me.splitExclude2.Size = New System.Drawing.Size(278, 250)
        Me.splitExclude2.SplitterDistance = 221
        Me.splitExclude2.TabIndex = 1
        Me.splitExclude2.TabStop = False
        '
        'lvExclude
        '
        Me.lvExclude.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.header1})
        Me.lvExclude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvExclude.FullRowSelect = True
        Me.lvExclude.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvExclude.Location = New System.Drawing.Point(0, 0)
        Me.lvExclude.Name = "lvExclude"
        Me.lvExclude.Size = New System.Drawing.Size(278, 221)
        Me.lvExclude.TabIndex = 1
        Me.lvExclude.UseCompatibleStateImageBehavior = False
        Me.lvExclude.View = System.Windows.Forms.View.Details
        '
        'header1
        '
        Me.header1.Width = 144
        '
        'splitExclude3
        '
        Me.splitExclude3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitExclude3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitExclude3.IsSplitterFixed = True
        Me.splitExclude3.Location = New System.Drawing.Point(0, 0)
        Me.splitExclude3.Name = "splitExclude3"
        '
        'splitExclude3.Panel1
        '
        Me.splitExclude3.Panel1.Controls.Add(Me.txtExclude)
        '
        'splitExclude3.Panel2
        '
        Me.splitExclude3.Panel2.Controls.Add(Me.cmdAddExclude)
        Me.splitExclude3.Panel2.Controls.Add(Me.cmdBrowseExclude)
        Me.splitExclude3.Size = New System.Drawing.Size(278, 25)
        Me.splitExclude3.SplitterDistance = 157
        Me.splitExclude3.TabIndex = 4
        Me.splitExclude3.TabStop = False
        '
        'txtExclude
        '
        Me.txtExclude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtExclude.Location = New System.Drawing.Point(0, 0)
        Me.txtExclude.Name = "txtExclude"
        Me.txtExclude.Size = New System.Drawing.Size(157, 22)
        Me.txtExclude.TabIndex = 2
        '
        'cmdAddExclude
        '
        Me.cmdAddExclude.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddExclude.Location = New System.Drawing.Point(39, 1)
        Me.cmdAddExclude.Name = "cmdAddExclude"
        Me.cmdAddExclude.Size = New System.Drawing.Size(72, 23)
        Me.cmdAddExclude.TabIndex = 5
        Me.cmdAddExclude.Text = "Add to list"
        Me.cmdAddExclude.UseVisualStyleBackColor = True
        '
        'cmdBrowseExclude
        '
        Me.cmdBrowseExclude.Location = New System.Drawing.Point(3, 1)
        Me.cmdBrowseExclude.Name = "cmdBrowseExclude"
        Me.cmdBrowseExclude.Size = New System.Drawing.Size(33, 23)
        Me.cmdBrowseExclude.TabIndex = 4
        Me.cmdBrowseExclude.Text = "..."
        Me.cmdBrowseExclude.UseVisualStyleBackColor = True
        '
        'ctlStep2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.splitMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctlStep2"
        Me.Size = New System.Drawing.Size(563, 308)
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel1.PerformLayout()
        Me.splitMain.Panel2.ResumeLayout(False)
        Me.splitMain.ResumeLayout(False)
        Me.split2.Panel1.ResumeLayout(False)
        Me.split2.Panel2.ResumeLayout(False)
        Me.split2.ResumeLayout(False)
        Me.splitInclude.Panel1.ResumeLayout(False)
        Me.splitInclude.Panel1.PerformLayout()
        Me.splitInclude.ResumeLayout(False)
        Me.splitExclude1.Panel1.ResumeLayout(False)
        Me.splitExclude1.Panel1.PerformLayout()
        Me.splitExclude1.Panel2.ResumeLayout(False)
        Me.splitExclude1.ResumeLayout(False)
        Me.splitExclude2.Panel1.ResumeLayout(False)
        Me.splitExclude2.Panel2.ResumeLayout(False)
        Me.splitExclude2.ResumeLayout(False)
        Me.splitExclude3.Panel1.ResumeLayout(False)
        Me.splitExclude3.Panel1.PerformLayout()
        Me.splitExclude3.Panel2.ResumeLayout(False)
        Me.splitExclude3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents splitMain As System.Windows.Forms.SplitContainer
    Friend WithEvents lblStepDescription As System.Windows.Forms.Label
    Friend WithEvents split2 As System.Windows.Forms.SplitContainer
    Friend WithEvents splitInclude As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents splitExclude1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents splitExclude2 As System.Windows.Forms.SplitContainer
    Friend WithEvents lvExclude As System.Windows.Forms.ListView
    Friend WithEvents splitExclude3 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtExclude As System.Windows.Forms.TextBox
    Friend WithEvents cmdAddExclude As System.Windows.Forms.Button
    Friend WithEvents cmdBrowseExclude As System.Windows.Forms.Button
    Friend WithEvents header1 As System.Windows.Forms.ColumnHeader

End Class
