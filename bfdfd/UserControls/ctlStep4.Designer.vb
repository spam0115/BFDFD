<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlStep4
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
        Me.chkIDate = New System.Windows.Forms.CheckBox
        Me.chkISize = New System.Windows.Forms.CheckBox
        Me.chkIAll = New System.Windows.Forms.CheckBox
        Me.splitI = New System.Windows.Forms.SplitContainer
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbISizeUnitLT = New System.Windows.Forms.ComboBox
        Me.txtISizeLT = New ctlNumericTextBox
        Me.chkISizeLT = New System.Windows.Forms.CheckBox
        Me.cbISizeUnitGT = New System.Windows.Forms.ComboBox
        Me.txtISizeGT = New ctlNumericTextBox
        Me.chkISizeGT = New System.Windows.Forms.CheckBox
        Me.cbIDateType = New System.Windows.Forms.ComboBox
        Me.dtILT = New System.Windows.Forms.DateTimePicker
        Me.dtIGT = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkIDateLT = New System.Windows.Forms.CheckBox
        Me.chkIDateGT = New System.Windows.Forms.CheckBox
        Me.splitExclude1 = New System.Windows.Forms.SplitContainer
        Me.Label2 = New System.Windows.Forms.Label
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.chkEDate = New System.Windows.Forms.CheckBox
        Me.chkESize = New System.Windows.Forms.CheckBox
        Me.chkENone = New System.Windows.Forms.CheckBox
        Me.splitE = New System.Windows.Forms.SplitContainer
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbESizeUnitLT = New System.Windows.Forms.ComboBox
        Me.txtESizeLT = New ctlNumericTextBox
        Me.chkESizeLT = New System.Windows.Forms.CheckBox
        Me.cbESizeUnitGT = New System.Windows.Forms.ComboBox
        Me.txtESizeGT = New ctlNumericTextBox
        Me.chkESizeGT = New System.Windows.Forms.CheckBox
        Me.cbEDateType = New System.Windows.Forms.ComboBox
        Me.dtELT = New System.Windows.Forms.DateTimePicker
        Me.dtEGT = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkEDateLT = New System.Windows.Forms.CheckBox
        Me.chkEDateGT = New System.Windows.Forms.CheckBox
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
        Me.splitI.Panel1.SuspendLayout()
        Me.splitI.Panel2.SuspendLayout()
        Me.splitI.SuspendLayout()
        Me.splitExclude1.Panel1.SuspendLayout()
        Me.splitExclude1.Panel2.SuspendLayout()
        Me.splitExclude1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.splitE.Panel1.SuspendLayout()
        Me.splitE.Panel2.SuspendLayout()
        Me.splitE.SuspendLayout()
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
        Me.lblStepDescription.Size = New System.Drawing.Size(209, 13)
        Me.lblStepDescription.TabIndex = 1
        Me.lblStepDescription.Text = "Step 4 : specify options for file research"
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
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Include"
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
        Me.splitIncludeMain.Panel1.Controls.Add(Me.chkIDate)
        Me.splitIncludeMain.Panel1.Controls.Add(Me.chkISize)
        Me.splitIncludeMain.Panel1.Controls.Add(Me.chkIAll)
        '
        'splitIncludeMain.Panel2
        '
        Me.splitIncludeMain.Panel2.Controls.Add(Me.splitI)
        Me.splitIncludeMain.Size = New System.Drawing.Size(281, 250)
        Me.splitIncludeMain.SplitterDistance = 73
        Me.splitIncludeMain.TabIndex = 6
        Me.splitIncludeMain.TabStop = False
        '
        'chkIDate
        '
        Me.chkIDate.AutoSize = True
        Me.chkIDate.Enabled = False
        Me.chkIDate.Location = New System.Drawing.Point(4, 49)
        Me.chkIDate.Name = "chkIDate"
        Me.chkIDate.Size = New System.Drawing.Size(68, 17)
        Me.chkIDate.TabIndex = 2
        Me.chkIDate.Text = "If date..."
        Me.chkIDate.UseVisualStyleBackColor = True
        '
        'chkISize
        '
        Me.chkISize.AutoSize = True
        Me.chkISize.Enabled = False
        Me.chkISize.Location = New System.Drawing.Point(3, 26)
        Me.chkISize.Name = "chkISize"
        Me.chkISize.Size = New System.Drawing.Size(64, 17)
        Me.chkISize.TabIndex = 1
        Me.chkISize.Text = "If size..."
        Me.chkISize.UseVisualStyleBackColor = True
        '
        'chkIAll
        '
        Me.chkIAll.AutoSize = True
        Me.chkIAll.Checked = True
        Me.chkIAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIAll.Location = New System.Drawing.Point(3, 3)
        Me.chkIAll.Name = "chkIAll"
        Me.chkIAll.Size = New System.Drawing.Size(39, 17)
        Me.chkIAll.TabIndex = 0
        Me.chkIAll.Text = "All"
        Me.chkIAll.UseVisualStyleBackColor = True
        '
        'splitI
        '
        Me.splitI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitI.IsSplitterFixed = True
        Me.splitI.Location = New System.Drawing.Point(0, 0)
        Me.splitI.Name = "splitI"
        Me.splitI.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitI.Panel1
        '
        Me.splitI.Panel1.Controls.Add(Me.Label3)
        Me.splitI.Panel1.Controls.Add(Me.cbISizeUnitLT)
        Me.splitI.Panel1.Controls.Add(Me.txtISizeLT)
        Me.splitI.Panel1.Controls.Add(Me.chkISizeLT)
        Me.splitI.Panel1.Controls.Add(Me.cbISizeUnitGT)
        Me.splitI.Panel1.Controls.Add(Me.txtISizeGT)
        Me.splitI.Panel1.Controls.Add(Me.chkISizeGT)
        Me.splitI.Panel1.Enabled = False
        '
        'splitI.Panel2
        '
        Me.splitI.Panel2.Controls.Add(Me.cbIDateType)
        Me.splitI.Panel2.Controls.Add(Me.dtILT)
        Me.splitI.Panel2.Controls.Add(Me.dtIGT)
        Me.splitI.Panel2.Controls.Add(Me.Label5)
        Me.splitI.Panel2.Controls.Add(Me.chkIDateLT)
        Me.splitI.Panel2.Controls.Add(Me.chkIDateGT)
        Me.splitI.Panel2.Enabled = False
        Me.splitI.Size = New System.Drawing.Size(204, 250)
        Me.splitI.SplitterDistance = 125
        Me.splitI.TabIndex = 0
        Me.splitI.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "File size options"
        '
        'cbISizeUnitLT
        '
        Me.cbISizeUnitLT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbISizeUnitLT.FormattingEnabled = True
        Me.cbISizeUnitLT.Items.AddRange(New Object() {"Bytes", "KB", "MB", "TB"})
        Me.cbISizeUnitLT.Location = New System.Drawing.Point(126, 60)
        Me.cbISizeUnitLT.Name = "cbISizeUnitLT"
        Me.cbISizeUnitLT.Size = New System.Drawing.Size(51, 21)
        Me.cbISizeUnitLT.TabIndex = 11
        '
        'txtISizeLT
        '
        Me.txtISizeLT.AllowSpace = False
        Me.txtISizeLT.Location = New System.Drawing.Point(55, 60)
        Me.txtISizeLT.Name = "txtISizeLT"
        Me.txtISizeLT.Size = New System.Drawing.Size(65, 22)
        Me.txtISizeLT.TabIndex = 10
        '
        'chkISizeLT
        '
        Me.chkISizeLT.AutoSize = True
        Me.chkISizeLT.Location = New System.Drawing.Point(15, 62)
        Me.chkISizeLT.Name = "chkISizeLT"
        Me.chkISizeLT.Size = New System.Drawing.Size(34, 17)
        Me.chkISizeLT.TabIndex = 9
        Me.chkISizeLT.Text = "<"
        Me.chkISizeLT.UseVisualStyleBackColor = True
        '
        'cbISizeUnitGT
        '
        Me.cbISizeUnitGT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbISizeUnitGT.FormattingEnabled = True
        Me.cbISizeUnitGT.Items.AddRange(New Object() {"Bytes", "KB", "MB", "TB"})
        Me.cbISizeUnitGT.Location = New System.Drawing.Point(126, 32)
        Me.cbISizeUnitGT.Name = "cbISizeUnitGT"
        Me.cbISizeUnitGT.Size = New System.Drawing.Size(51, 21)
        Me.cbISizeUnitGT.TabIndex = 8
        '
        'txtISizeGT
        '
        Me.txtISizeGT.AllowSpace = False
        Me.txtISizeGT.Location = New System.Drawing.Point(55, 32)
        Me.txtISizeGT.Name = "txtISizeGT"
        Me.txtISizeGT.Size = New System.Drawing.Size(65, 22)
        Me.txtISizeGT.TabIndex = 7
        '
        'chkISizeGT
        '
        Me.chkISizeGT.AutoSize = True
        Me.chkISizeGT.Location = New System.Drawing.Point(15, 34)
        Me.chkISizeGT.Name = "chkISizeGT"
        Me.chkISizeGT.Size = New System.Drawing.Size(34, 17)
        Me.chkISizeGT.TabIndex = 6
        Me.chkISizeGT.Text = ">"
        Me.chkISizeGT.UseVisualStyleBackColor = True
        '
        'cbIDateType
        '
        Me.cbIDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbIDateType.FormattingEnabled = True
        Me.cbIDateType.Items.AddRange(New Object() {"Creation date", "Last access date", "Last write date"})
        Me.cbIDateType.Location = New System.Drawing.Point(15, 85)
        Me.cbIDateType.Name = "cbIDateType"
        Me.cbIDateType.Size = New System.Drawing.Size(175, 21)
        Me.cbIDateType.TabIndex = 18
        '
        'dtILT
        '
        Me.dtILT.CustomFormat = "HH:mm:ss - dd/MM/yy"
        Me.dtILT.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtILT.Location = New System.Drawing.Point(55, 57)
        Me.dtILT.Name = "dtILT"
        Me.dtILT.Size = New System.Drawing.Size(135, 22)
        Me.dtILT.TabIndex = 16
        '
        'dtIGT
        '
        Me.dtIGT.CustomFormat = "HH:mm:ss - dd/MM/yy"
        Me.dtIGT.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtIGT.Location = New System.Drawing.Point(55, 29)
        Me.dtIGT.Name = "dtIGT"
        Me.dtIGT.Size = New System.Drawing.Size(135, 22)
        Me.dtIGT.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "File date options"
        '
        'chkIDateLT
        '
        Me.chkIDateLT.AutoSize = True
        Me.chkIDateLT.Location = New System.Drawing.Point(15, 62)
        Me.chkIDateLT.Name = "chkIDateLT"
        Me.chkIDateLT.Size = New System.Drawing.Size(34, 17)
        Me.chkIDateLT.TabIndex = 15
        Me.chkIDateLT.Text = "<"
        Me.chkIDateLT.UseVisualStyleBackColor = True
        '
        'chkIDateGT
        '
        Me.chkIDateGT.AutoSize = True
        Me.chkIDateGT.Location = New System.Drawing.Point(15, 34)
        Me.chkIDateGT.Name = "chkIDateGT"
        Me.chkIDateGT.Size = New System.Drawing.Size(34, 17)
        Me.chkIDateGT.TabIndex = 13
        Me.chkIDateGT.Text = ">"
        Me.chkIDateGT.UseVisualStyleBackColor = True
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
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Exclude"
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkEDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkESize)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkENone)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.splitE)
        Me.SplitContainer2.Size = New System.Drawing.Size(278, 250)
        Me.SplitContainer2.SplitterDistance = 70
        Me.SplitContainer2.TabIndex = 7
        Me.SplitContainer2.TabStop = False
        '
        'chkEDate
        '
        Me.chkEDate.AutoSize = True
        Me.chkEDate.Enabled = False
        Me.chkEDate.Location = New System.Drawing.Point(1, 49)
        Me.chkEDate.Name = "chkEDate"
        Me.chkEDate.Size = New System.Drawing.Size(68, 17)
        Me.chkEDate.TabIndex = 10
        Me.chkEDate.Text = "If date..."
        Me.chkEDate.UseVisualStyleBackColor = True
        '
        'chkESize
        '
        Me.chkESize.AutoSize = True
        Me.chkESize.Enabled = False
        Me.chkESize.Location = New System.Drawing.Point(0, 26)
        Me.chkESize.Name = "chkESize"
        Me.chkESize.Size = New System.Drawing.Size(64, 17)
        Me.chkESize.TabIndex = 9
        Me.chkESize.Text = "If size..."
        Me.chkESize.UseVisualStyleBackColor = True
        '
        'chkENone
        '
        Me.chkENone.AutoSize = True
        Me.chkENone.Checked = True
        Me.chkENone.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkENone.Location = New System.Drawing.Point(0, 3)
        Me.chkENone.Name = "chkENone"
        Me.chkENone.Size = New System.Drawing.Size(54, 17)
        Me.chkENone.TabIndex = 8
        Me.chkENone.Text = "None"
        Me.chkENone.UseVisualStyleBackColor = True
        '
        'splitE
        '
        Me.splitE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitE.Location = New System.Drawing.Point(0, 0)
        Me.splitE.Name = "splitE"
        Me.splitE.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitE.Panel1
        '
        Me.splitE.Panel1.Controls.Add(Me.Label4)
        Me.splitE.Panel1.Controls.Add(Me.cbESizeUnitLT)
        Me.splitE.Panel1.Controls.Add(Me.txtESizeLT)
        Me.splitE.Panel1.Controls.Add(Me.chkESizeLT)
        Me.splitE.Panel1.Controls.Add(Me.cbESizeUnitGT)
        Me.splitE.Panel1.Controls.Add(Me.txtESizeGT)
        Me.splitE.Panel1.Controls.Add(Me.chkESizeGT)
        Me.splitE.Panel1.Enabled = False
        '
        'splitE.Panel2
        '
        Me.splitE.Panel2.Controls.Add(Me.cbEDateType)
        Me.splitE.Panel2.Controls.Add(Me.dtELT)
        Me.splitE.Panel2.Controls.Add(Me.dtEGT)
        Me.splitE.Panel2.Controls.Add(Me.Label6)
        Me.splitE.Panel2.Controls.Add(Me.chkEDateLT)
        Me.splitE.Panel2.Controls.Add(Me.chkEDateGT)
        Me.splitE.Panel2.Enabled = False
        Me.splitE.Size = New System.Drawing.Size(204, 250)
        Me.splitE.SplitterDistance = 125
        Me.splitE.TabIndex = 0
        Me.splitE.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "File size options"
        '
        'cbESizeUnitLT
        '
        Me.cbESizeUnitLT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbESizeUnitLT.FormattingEnabled = True
        Me.cbESizeUnitLT.Items.AddRange(New Object() {"Bytes", "KB", "MB", "TB"})
        Me.cbESizeUnitLT.Location = New System.Drawing.Point(126, 60)
        Me.cbESizeUnitLT.Name = "cbESizeUnitLT"
        Me.cbESizeUnitLT.Size = New System.Drawing.Size(51, 21)
        Me.cbESizeUnitLT.TabIndex = 11
        '
        'txtESizeLT
        '
        Me.txtESizeLT.AllowSpace = False
        Me.txtESizeLT.Location = New System.Drawing.Point(55, 60)
        Me.txtESizeLT.Name = "txtESizeLT"
        Me.txtESizeLT.Size = New System.Drawing.Size(65, 22)
        Me.txtESizeLT.TabIndex = 10
        '
        'chkESizeLT
        '
        Me.chkESizeLT.AutoSize = True
        Me.chkESizeLT.Location = New System.Drawing.Point(15, 62)
        Me.chkESizeLT.Name = "chkESizeLT"
        Me.chkESizeLT.Size = New System.Drawing.Size(34, 17)
        Me.chkESizeLT.TabIndex = 9
        Me.chkESizeLT.Text = "<"
        Me.chkESizeLT.UseVisualStyleBackColor = True
        '
        'cbESizeUnitGT
        '
        Me.cbESizeUnitGT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbESizeUnitGT.FormattingEnabled = True
        Me.cbESizeUnitGT.Items.AddRange(New Object() {"Bytes", "KB", "MB", "TB"})
        Me.cbESizeUnitGT.Location = New System.Drawing.Point(126, 32)
        Me.cbESizeUnitGT.Name = "cbESizeUnitGT"
        Me.cbESizeUnitGT.Size = New System.Drawing.Size(51, 21)
        Me.cbESizeUnitGT.TabIndex = 8
        '
        'txtESizeGT
        '
        Me.txtESizeGT.AllowSpace = False
        Me.txtESizeGT.Location = New System.Drawing.Point(55, 32)
        Me.txtESizeGT.Name = "txtESizeGT"
        Me.txtESizeGT.Size = New System.Drawing.Size(65, 22)
        Me.txtESizeGT.TabIndex = 7
        '
        'chkESizeGT
        '
        Me.chkESizeGT.AutoSize = True
        Me.chkESizeGT.Location = New System.Drawing.Point(15, 34)
        Me.chkESizeGT.Name = "chkESizeGT"
        Me.chkESizeGT.Size = New System.Drawing.Size(34, 17)
        Me.chkESizeGT.TabIndex = 6
        Me.chkESizeGT.Text = ">"
        Me.chkESizeGT.UseVisualStyleBackColor = True
        '
        'cbEDateType
        '
        Me.cbEDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEDateType.FormattingEnabled = True
        Me.cbEDateType.Items.AddRange(New Object() {"Creation date", "Last access date", "Last write date"})
        Me.cbEDateType.Location = New System.Drawing.Point(15, 85)
        Me.cbEDateType.Name = "cbEDateType"
        Me.cbEDateType.Size = New System.Drawing.Size(175, 21)
        Me.cbEDateType.TabIndex = 4
        '
        'dtELT
        '
        Me.dtELT.CustomFormat = "HH:mm:ss - dd/MM/yy"
        Me.dtELT.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtELT.Location = New System.Drawing.Point(55, 57)
        Me.dtELT.Name = "dtELT"
        Me.dtELT.Size = New System.Drawing.Size(135, 22)
        Me.dtELT.TabIndex = 3
        '
        'dtEGT
        '
        Me.dtEGT.CustomFormat = "HH:mm:ss - dd/MM/yy"
        Me.dtEGT.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEGT.Location = New System.Drawing.Point(55, 29)
        Me.dtEGT.Name = "dtEGT"
        Me.dtEGT.Size = New System.Drawing.Size(135, 22)
        Me.dtEGT.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "File date options"
        '
        'chkEDateLT
        '
        Me.chkEDateLT.AutoSize = True
        Me.chkEDateLT.Location = New System.Drawing.Point(15, 62)
        Me.chkEDateLT.Name = "chkEDateLT"
        Me.chkEDateLT.Size = New System.Drawing.Size(34, 17)
        Me.chkEDateLT.TabIndex = 2
        Me.chkEDateLT.Text = "<"
        Me.chkEDateLT.UseVisualStyleBackColor = True
        '
        'chkEDateGT
        '
        Me.chkEDateGT.AutoSize = True
        Me.chkEDateGT.Location = New System.Drawing.Point(15, 34)
        Me.chkEDateGT.Name = "chkEDateGT"
        Me.chkEDateGT.Size = New System.Drawing.Size(34, 17)
        Me.chkEDateGT.TabIndex = 0
        Me.chkEDateGT.Text = ">"
        Me.chkEDateGT.UseVisualStyleBackColor = True
        '
        'ctlStep4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.splitMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctlStep4"
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
        Me.splitI.Panel1.ResumeLayout(False)
        Me.splitI.Panel1.PerformLayout()
        Me.splitI.Panel2.ResumeLayout(False)
        Me.splitI.Panel2.PerformLayout()
        Me.splitI.ResumeLayout(False)
        Me.splitExclude1.Panel1.ResumeLayout(False)
        Me.splitExclude1.Panel1.PerformLayout()
        Me.splitExclude1.Panel2.ResumeLayout(False)
        Me.splitExclude1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.splitE.Panel1.ResumeLayout(False)
        Me.splitE.Panel1.PerformLayout()
        Me.splitE.Panel2.ResumeLayout(False)
        Me.splitE.Panel2.PerformLayout()
        Me.splitE.ResumeLayout(False)
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
    Friend WithEvents chkIDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkISize As System.Windows.Forms.CheckBox
    Friend WithEvents chkIAll As System.Windows.Forms.CheckBox
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents chkEDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkESize As System.Windows.Forms.CheckBox
    Friend WithEvents chkENone As System.Windows.Forms.CheckBox
    Friend WithEvents splitI As System.Windows.Forms.SplitContainer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbISizeUnitLT As System.Windows.Forms.ComboBox
    Friend WithEvents txtISizeLT As ctlNumericTextBox
    Friend WithEvents chkISizeLT As System.Windows.Forms.CheckBox
    Friend WithEvents cbISizeUnitGT As System.Windows.Forms.ComboBox
    Friend WithEvents txtISizeGT As ctlNumericTextBox
    Friend WithEvents chkISizeGT As System.Windows.Forms.CheckBox
    Friend WithEvents splitE As System.Windows.Forms.SplitContainer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbESizeUnitLT As System.Windows.Forms.ComboBox
    Friend WithEvents txtESizeLT As ctlNumericTextBox
    Friend WithEvents chkESizeLT As System.Windows.Forms.CheckBox
    Friend WithEvents cbESizeUnitGT As System.Windows.Forms.ComboBox
    Friend WithEvents txtESizeGT As ctlNumericTextBox
    Friend WithEvents chkESizeGT As System.Windows.Forms.CheckBox
    Friend WithEvents dtILT As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtIGT As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkIDateLT As System.Windows.Forms.CheckBox
    Friend WithEvents chkIDateGT As System.Windows.Forms.CheckBox
    Friend WithEvents dtELT As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtEGT As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkEDateLT As System.Windows.Forms.CheckBox
    Friend WithEvents chkEDateGT As System.Windows.Forms.CheckBox
    Friend WithEvents cbIDateType As System.Windows.Forms.ComboBox
    Friend WithEvents cbEDateType As System.Windows.Forms.ComboBox

End Class
