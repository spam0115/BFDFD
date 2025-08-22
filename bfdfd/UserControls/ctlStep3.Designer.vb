<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlStep3
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
        Me.splitIncludeMain = New System.Windows.Forms.SplitContainer
        Me.chkICustom = New System.Windows.Forms.CheckBox
        Me.chkIArchives = New System.Windows.Forms.CheckBox
        Me.chkIVideos = New System.Windows.Forms.CheckBox
        Me.chkIMusic = New System.Windows.Forms.CheckBox
        Me.chkIImages = New System.Windows.Forms.CheckBox
        Me.chkIAll = New System.Windows.Forms.CheckBox
        Me.splitIncludeCustom = New System.Windows.Forms.SplitContainer
        Me.lvI = New System.Windows.Forms.ListView
        Me.header1 = New System.Windows.Forms.ColumnHeader
        Me.splitCustomInclude3 = New System.Windows.Forms.SplitContainer
        Me.txtInclude = New System.Windows.Forms.TextBox
        Me.cmdAddIncludeFilter = New System.Windows.Forms.Button
        Me.splitExclude1 = New System.Windows.Forms.SplitContainer
        Me.Label2 = New System.Windows.Forms.Label
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.chkECustom = New System.Windows.Forms.CheckBox
        Me.chkEArchives = New System.Windows.Forms.CheckBox
        Me.chkEVideos = New System.Windows.Forms.CheckBox
        Me.chkEMusic = New System.Windows.Forms.CheckBox
        Me.chkEImages = New System.Windows.Forms.CheckBox
        Me.splitExcludeCustom = New System.Windows.Forms.SplitContainer
        Me.lvE = New System.Windows.Forms.ListView
        Me.header2 = New System.Windows.Forms.ColumnHeader
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer
        Me.txtExclude = New System.Windows.Forms.TextBox
        Me.cmdAddExcludeFilter = New System.Windows.Forms.Button
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.split2.Panel1.SuspendLayout()
        Me.split2.Panel2.SuspendLayout()
        Me.split2.SuspendLayout()
        Me.splitInclude.Panel1.SuspendLayout()
        Me.splitInclude.Panel2.SuspendLayout()
        Me.splitInclude.SuspendLayout()
        Me.splitIncludeMain.Panel1.SuspendLayout()
        Me.splitIncludeMain.Panel2.SuspendLayout()
        Me.splitIncludeMain.SuspendLayout()
        Me.splitIncludeCustom.Panel1.SuspendLayout()
        Me.splitIncludeCustom.Panel2.SuspendLayout()
        Me.splitIncludeCustom.SuspendLayout()
        Me.splitCustomInclude3.Panel1.SuspendLayout()
        Me.splitCustomInclude3.Panel2.SuspendLayout()
        Me.splitCustomInclude3.SuspendLayout()
        Me.splitExclude1.Panel1.SuspendLayout()
        Me.splitExclude1.Panel2.SuspendLayout()
        Me.splitExclude1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.splitExcludeCustom.Panel1.SuspendLayout()
        Me.splitExcludeCustom.Panel2.SuspendLayout()
        Me.splitExcludeCustom.SuspendLayout()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
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
        Me.lblStepDescription.Size = New System.Drawing.Size(288, 13)
        Me.lblStepDescription.TabIndex = 1
        Me.lblStepDescription.Text = "Step 3 : select file types to include/exclude for research"
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
        '
        'splitInclude.Panel2
        '
        Me.splitInclude.Panel2.Controls.Add(Me.splitIncludeMain)
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
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Types to include"
        '
        'splitIncludeMain
        '
        Me.splitIncludeMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitIncludeMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitIncludeMain.IsSplitterFixed = True
        Me.splitIncludeMain.Location = New System.Drawing.Point(0, 0)
        Me.splitIncludeMain.Name = "splitIncludeMain"
        '
        'splitIncludeMain.Panel1
        '
        Me.splitIncludeMain.Panel1.Controls.Add(Me.chkICustom)
        Me.splitIncludeMain.Panel1.Controls.Add(Me.chkIArchives)
        Me.splitIncludeMain.Panel1.Controls.Add(Me.chkIVideos)
        Me.splitIncludeMain.Panel1.Controls.Add(Me.chkIMusic)
        Me.splitIncludeMain.Panel1.Controls.Add(Me.chkIImages)
        Me.splitIncludeMain.Panel1.Controls.Add(Me.chkIAll)
        '
        'splitIncludeMain.Panel2
        '
        Me.splitIncludeMain.Panel2.Controls.Add(Me.splitIncludeCustom)
        Me.splitIncludeMain.Size = New System.Drawing.Size(281, 250)
        Me.splitIncludeMain.SplitterDistance = 73
        Me.splitIncludeMain.TabIndex = 6
        Me.splitIncludeMain.TabStop = False
        '
        'chkICustom
        '
        Me.chkICustom.AutoSize = True
        Me.chkICustom.Enabled = False
        Me.chkICustom.Location = New System.Drawing.Point(4, 117)
        Me.chkICustom.Name = "chkICustom"
        Me.chkICustom.Size = New System.Drawing.Size(65, 17)
        Me.chkICustom.TabIndex = 5
        Me.chkICustom.Text = "Custom"
        Me.chkICustom.UseVisualStyleBackColor = True
        '
        'chkIArchives
        '
        Me.chkIArchives.AutoSize = True
        Me.chkIArchives.Enabled = False
        Me.chkIArchives.Location = New System.Drawing.Point(4, 95)
        Me.chkIArchives.Name = "chkIArchives"
        Me.chkIArchives.Size = New System.Drawing.Size(68, 17)
        Me.chkIArchives.TabIndex = 4
        Me.chkIArchives.Text = "Archives"
        Me.chkIArchives.UseVisualStyleBackColor = True
        '
        'chkIVideos
        '
        Me.chkIVideos.AutoSize = True
        Me.chkIVideos.Enabled = False
        Me.chkIVideos.Location = New System.Drawing.Point(4, 72)
        Me.chkIVideos.Name = "chkIVideos"
        Me.chkIVideos.Size = New System.Drawing.Size(61, 17)
        Me.chkIVideos.TabIndex = 3
        Me.chkIVideos.Text = "Videos"
        Me.chkIVideos.UseVisualStyleBackColor = True
        '
        'chkIMusic
        '
        Me.chkIMusic.AutoSize = True
        Me.chkIMusic.Enabled = False
        Me.chkIMusic.Location = New System.Drawing.Point(4, 49)
        Me.chkIMusic.Name = "chkIMusic"
        Me.chkIMusic.Size = New System.Drawing.Size(56, 17)
        Me.chkIMusic.TabIndex = 2
        Me.chkIMusic.Text = "Music"
        Me.chkIMusic.UseVisualStyleBackColor = True
        '
        'chkIImages
        '
        Me.chkIImages.AutoSize = True
        Me.chkIImages.Enabled = False
        Me.chkIImages.Location = New System.Drawing.Point(3, 26)
        Me.chkIImages.Name = "chkIImages"
        Me.chkIImages.Size = New System.Drawing.Size(62, 17)
        Me.chkIImages.TabIndex = 1
        Me.chkIImages.Text = "Images"
        Me.chkIImages.UseVisualStyleBackColor = True
        '
        'chkIAll
        '
        Me.chkIAll.AutoSize = True
        Me.chkIAll.Checked = True
        Me.chkIAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIAll.Location = New System.Drawing.Point(3, 3)
        Me.chkIAll.Name = "chkIAll"
        Me.chkIAll.Size = New System.Drawing.Size(69, 17)
        Me.chkIAll.TabIndex = 0
        Me.chkIAll.Text = "All types"
        Me.chkIAll.UseVisualStyleBackColor = True
        '
        'splitIncludeCustom
        '
        Me.splitIncludeCustom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitIncludeCustom.Enabled = False
        Me.splitIncludeCustom.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitIncludeCustom.IsSplitterFixed = True
        Me.splitIncludeCustom.Location = New System.Drawing.Point(0, 0)
        Me.splitIncludeCustom.Name = "splitIncludeCustom"
        Me.splitIncludeCustom.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitIncludeCustom.Panel1
        '
        Me.splitIncludeCustom.Panel1.Controls.Add(Me.lvI)
        '
        'splitIncludeCustom.Panel2
        '
        Me.splitIncludeCustom.Panel2.Controls.Add(Me.splitCustomInclude3)
        Me.splitIncludeCustom.Size = New System.Drawing.Size(204, 250)
        Me.splitIncludeCustom.SplitterDistance = 221
        Me.splitIncludeCustom.TabIndex = 0
        '
        'lvI
        '
        Me.lvI.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.header1})
        Me.lvI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvI.FullRowSelect = True
        Me.lvI.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvI.Location = New System.Drawing.Point(0, 0)
        Me.lvI.Name = "lvI"
        Me.lvI.Size = New System.Drawing.Size(204, 221)
        Me.lvI.TabIndex = 6
        Me.lvI.UseCompatibleStateImageBehavior = False
        Me.lvI.View = System.Windows.Forms.View.Details
        '
        'header1
        '
        Me.header1.Width = 144
        '
        'splitCustomInclude3
        '
        Me.splitCustomInclude3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitCustomInclude3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitCustomInclude3.IsSplitterFixed = True
        Me.splitCustomInclude3.Location = New System.Drawing.Point(0, 0)
        Me.splitCustomInclude3.Name = "splitCustomInclude3"
        '
        'splitCustomInclude3.Panel1
        '
        Me.splitCustomInclude3.Panel1.Controls.Add(Me.txtInclude)
        '
        'splitCustomInclude3.Panel2
        '
        Me.splitCustomInclude3.Panel2.Controls.Add(Me.cmdAddIncludeFilter)
        Me.splitCustomInclude3.Size = New System.Drawing.Size(204, 25)
        Me.splitCustomInclude3.SplitterDistance = 119
        Me.splitCustomInclude3.TabIndex = 5
        Me.splitCustomInclude3.TabStop = False
        '
        'txtInclude
        '
        Me.txtInclude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtInclude.Location = New System.Drawing.Point(0, 0)
        Me.txtInclude.Name = "txtInclude"
        Me.txtInclude.Size = New System.Drawing.Size(119, 22)
        Me.txtInclude.TabIndex = 7
        '
        'cmdAddIncludeFilter
        '
        Me.cmdAddIncludeFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddIncludeFilter.Location = New System.Drawing.Point(4, 1)
        Me.cmdAddIncludeFilter.Name = "cmdAddIncludeFilter"
        Me.cmdAddIncludeFilter.Size = New System.Drawing.Size(72, 23)
        Me.cmdAddIncludeFilter.TabIndex = 8
        Me.cmdAddIncludeFilter.Text = "Add to list"
        Me.cmdAddIncludeFilter.UseVisualStyleBackColor = True
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
        Me.splitExclude1.Panel2.Controls.Add(Me.SplitContainer2)
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
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Types to exclude"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkECustom)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkEArchives)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkEVideos)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkEMusic)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkEImages)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.splitExcludeCustom)
        Me.SplitContainer2.Size = New System.Drawing.Size(278, 250)
        Me.SplitContainer2.SplitterDistance = 73
        Me.SplitContainer2.TabIndex = 7
        Me.SplitContainer2.TabStop = False
        '
        'chkECustom
        '
        Me.chkECustom.AutoSize = True
        Me.chkECustom.Location = New System.Drawing.Point(3, 95)
        Me.chkECustom.Name = "chkECustom"
        Me.chkECustom.Size = New System.Drawing.Size(65, 17)
        Me.chkECustom.TabIndex = 13
        Me.chkECustom.Text = "Custom"
        Me.chkECustom.UseVisualStyleBackColor = True
        '
        'chkEArchives
        '
        Me.chkEArchives.AutoSize = True
        Me.chkEArchives.Location = New System.Drawing.Point(3, 72)
        Me.chkEArchives.Name = "chkEArchives"
        Me.chkEArchives.Size = New System.Drawing.Size(68, 17)
        Me.chkEArchives.TabIndex = 12
        Me.chkEArchives.Text = "Archives"
        Me.chkEArchives.UseVisualStyleBackColor = True
        '
        'chkEVideos
        '
        Me.chkEVideos.AutoSize = True
        Me.chkEVideos.Location = New System.Drawing.Point(4, 49)
        Me.chkEVideos.Name = "chkEVideos"
        Me.chkEVideos.Size = New System.Drawing.Size(61, 17)
        Me.chkEVideos.TabIndex = 11
        Me.chkEVideos.Text = "Videos"
        Me.chkEVideos.UseVisualStyleBackColor = True
        '
        'chkEMusic
        '
        Me.chkEMusic.AutoSize = True
        Me.chkEMusic.Location = New System.Drawing.Point(4, 26)
        Me.chkEMusic.Name = "chkEMusic"
        Me.chkEMusic.Size = New System.Drawing.Size(56, 17)
        Me.chkEMusic.TabIndex = 10
        Me.chkEMusic.Text = "Music"
        Me.chkEMusic.UseVisualStyleBackColor = True
        '
        'chkEImages
        '
        Me.chkEImages.AutoSize = True
        Me.chkEImages.Location = New System.Drawing.Point(3, 3)
        Me.chkEImages.Name = "chkEImages"
        Me.chkEImages.Size = New System.Drawing.Size(62, 17)
        Me.chkEImages.TabIndex = 9
        Me.chkEImages.Text = "Images"
        Me.chkEImages.UseVisualStyleBackColor = True
        '
        'splitExcludeCustom
        '
        Me.splitExcludeCustom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitExcludeCustom.Enabled = False
        Me.splitExcludeCustom.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitExcludeCustom.IsSplitterFixed = True
        Me.splitExcludeCustom.Location = New System.Drawing.Point(0, 0)
        Me.splitExcludeCustom.Name = "splitExcludeCustom"
        Me.splitExcludeCustom.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitExcludeCustom.Panel1
        '
        Me.splitExcludeCustom.Panel1.Controls.Add(Me.lvE)
        '
        'splitExcludeCustom.Panel2
        '
        Me.splitExcludeCustom.Panel2.Controls.Add(Me.SplitContainer4)
        Me.splitExcludeCustom.Size = New System.Drawing.Size(201, 250)
        Me.splitExcludeCustom.SplitterDistance = 221
        Me.splitExcludeCustom.TabIndex = 0
        '
        'lvE
        '
        Me.lvE.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.header2})
        Me.lvE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvE.FullRowSelect = True
        Me.lvE.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvE.Location = New System.Drawing.Point(0, 0)
        Me.lvE.Name = "lvE"
        Me.lvE.Size = New System.Drawing.Size(201, 221)
        Me.lvE.TabIndex = 14
        Me.lvE.UseCompatibleStateImageBehavior = False
        Me.lvE.View = System.Windows.Forms.View.Details
        '
        'header2
        '
        Me.header2.Width = 144
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer4.IsSplitterFixed = True
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.txtExclude)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.cmdAddExcludeFilter)
        Me.SplitContainer4.Size = New System.Drawing.Size(201, 25)
        Me.SplitContainer4.SplitterDistance = 116
        Me.SplitContainer4.TabIndex = 5
        Me.SplitContainer4.TabStop = False
        '
        'txtExclude
        '
        Me.txtExclude.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtExclude.Location = New System.Drawing.Point(0, 0)
        Me.txtExclude.Name = "txtExclude"
        Me.txtExclude.Size = New System.Drawing.Size(116, 22)
        Me.txtExclude.TabIndex = 15
        '
        'cmdAddExcludeFilter
        '
        Me.cmdAddExcludeFilter.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddExcludeFilter.Location = New System.Drawing.Point(4, 1)
        Me.cmdAddExcludeFilter.Name = "cmdAddExcludeFilter"
        Me.cmdAddExcludeFilter.Size = New System.Drawing.Size(72, 23)
        Me.cmdAddExcludeFilter.TabIndex = 16
        Me.cmdAddExcludeFilter.Text = "Add to list"
        Me.cmdAddExcludeFilter.UseVisualStyleBackColor = True
        '
        'ctlStep3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.splitMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctlStep3"
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
        Me.splitInclude.Panel2.ResumeLayout(False)
        Me.splitInclude.ResumeLayout(False)
        Me.splitIncludeMain.Panel1.ResumeLayout(False)
        Me.splitIncludeMain.Panel1.PerformLayout()
        Me.splitIncludeMain.Panel2.ResumeLayout(False)
        Me.splitIncludeMain.ResumeLayout(False)
        Me.splitIncludeCustom.Panel1.ResumeLayout(False)
        Me.splitIncludeCustom.Panel2.ResumeLayout(False)
        Me.splitIncludeCustom.ResumeLayout(False)
        Me.splitCustomInclude3.Panel1.ResumeLayout(False)
        Me.splitCustomInclude3.Panel1.PerformLayout()
        Me.splitCustomInclude3.Panel2.ResumeLayout(False)
        Me.splitCustomInclude3.ResumeLayout(False)
        Me.splitExclude1.Panel1.ResumeLayout(False)
        Me.splitExclude1.Panel1.PerformLayout()
        Me.splitExclude1.Panel2.ResumeLayout(False)
        Me.splitExclude1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.splitExcludeCustom.Panel1.ResumeLayout(False)
        Me.splitExcludeCustom.Panel2.ResumeLayout(False)
        Me.splitExcludeCustom.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        Me.SplitContainer4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents splitMain As System.Windows.Forms.SplitContainer
    Friend WithEvents lblStepDescription As System.Windows.Forms.Label
    Friend WithEvents split2 As System.Windows.Forms.SplitContainer
    Friend WithEvents splitInclude As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents splitExclude1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents splitIncludeMain As System.Windows.Forms.SplitContainer
    Friend WithEvents chkIArchives As System.Windows.Forms.CheckBox
    Friend WithEvents chkIVideos As System.Windows.Forms.CheckBox
    Friend WithEvents chkIMusic As System.Windows.Forms.CheckBox
    Friend WithEvents chkIImages As System.Windows.Forms.CheckBox
    Friend WithEvents chkIAll As System.Windows.Forms.CheckBox
    Friend WithEvents splitIncludeCustom As System.Windows.Forms.SplitContainer
    Friend WithEvents lvI As System.Windows.Forms.ListView
    Friend WithEvents header1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents splitCustomInclude3 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtInclude As System.Windows.Forms.TextBox
    Friend WithEvents cmdAddIncludeFilter As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents chkEArchives As System.Windows.Forms.CheckBox
    Friend WithEvents chkEVideos As System.Windows.Forms.CheckBox
    Friend WithEvents chkEMusic As System.Windows.Forms.CheckBox
    Friend WithEvents chkEImages As System.Windows.Forms.CheckBox
    Friend WithEvents splitExcludeCustom As System.Windows.Forms.SplitContainer
    Friend WithEvents lvE As System.Windows.Forms.ListView
    Friend WithEvents header2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtExclude As System.Windows.Forms.TextBox
    Friend WithEvents cmdAddExcludeFilter As System.Windows.Forms.Button
    Friend WithEvents chkICustom As System.Windows.Forms.CheckBox
    Friend WithEvents chkECustom As System.Windows.Forms.CheckBox

End Class
