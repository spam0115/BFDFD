<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlStep5
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
        Me.components = New System.ComponentModel.Container()
        Me.splitMain = New System.Windows.Forms.SplitContainer()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblStepDescription = New System.Windows.Forms.Label()
        Me.splitA = New System.Windows.Forms.SplitContainer()
        Me.SplitContainerCmdGo = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdGo = New System.Windows.Forms.Button()
        Me.splitRes = New System.Windows.Forms.SplitContainer()
        Me.headerPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.headerType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.headerSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.headerDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.headerGroup = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblGroups = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblWastedSpace = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDuplicateCount = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.VistaMenu = New wyDay.Controls.VistaMenu(Me.components)
        Me.RMenuItemCopy = New System.Windows.Forms.MenuItem()
        Me.MenuItemCopyFilePath = New System.Windows.Forms.MenuItem()
        Me.MenuItemCopyFileHash = New System.Windows.Forms.MenuItem()
        Me.MenuItemCopyAll = New System.Windows.Forms.MenuItem()
        Me.MenuItemSelToTrash = New System.Windows.Forms.MenuItem()
        Me.MenuItemSelDelete = New System.Windows.Forms.MenuItem()
        Me.MenuItemChToTrash = New System.Windows.Forms.MenuItem()
        Me.MenuItemChDelete = New System.Windows.Forms.MenuItem()
        Me.MenuItemOpenFileLocation = New System.Windows.Forms.MenuItem()
        Me.MenuItemFileProperties = New System.Windows.Forms.MenuItem()
        Me.MenuItemRefresh = New System.Windows.Forms.MenuItem()
        Me.MenuItemSaveList = New System.Windows.Forms.MenuItem()
        Me.mnuFile = New System.Windows.Forms.ContextMenu()
        Me.MenuItemOpenFile = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItemSelRemove = New System.Windows.Forms.MenuItem()
        Me.MenuItemSelMove = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItemChRemove = New System.Windows.Forms.MenuItem()
        Me.MenuItemChMove = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.RMenuItemDupSel = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_mc = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_lc = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_mm = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_lm = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_ma = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_ra = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_shortestname = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_longestname = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_shortestnonnumericname = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_longestnonnumericname = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_ShortestPath = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_LongestPath = New System.Windows.Forms.MenuItem()
        Me.MenuItemSelCheck = New System.Windows.Forms.MenuItem()
        Me.MenuItemSelUncheck = New System.Windows.Forms.MenuItem()
        Me.MenuItemCheckAll = New System.Windows.Forms.MenuItem()
        Me.MenuItemCheckNone = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.RMenuItemFilter = New System.Windows.Forms.MenuItem()
        Me.MenuItemFRArchives = New System.Windows.Forms.MenuItem()
        Me.MenuItemFRImages = New System.Windows.Forms.MenuItem()
        Me.MenuItemFRMusic = New System.Windows.Forms.MenuItem()
        Me.MenuItemFRVideos = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItemFOArchive = New System.Windows.Forms.MenuItem()
        Me.MenuItemFOImages = New System.Windows.Forms.MenuItem()
        Me.MenuItemFOMusic = New System.Windows.Forms.MenuItem()
        Me.MenuItemFOVideos = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItemFRCustom = New System.Windows.Forms.MenuItem()
        Me.RMenuItemRPath = New System.Windows.Forms.MenuItem()
        Me.MenuItemFRFolder = New System.Windows.Forms.MenuItem()
        Me.MenuItemRIPath = New System.Windows.Forms.MenuItem()
        Me.MenuItemOrphan = New System.Windows.Forms.MenuItem()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        CType(Me.splitA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitA.Panel1.SuspendLayout()
        Me.splitA.Panel2.SuspendLayout()
        Me.splitA.SuspendLayout()
        CType(Me.SplitContainerCmdGo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerCmdGo.Panel1.SuspendLayout()
        Me.SplitContainerCmdGo.Panel2.SuspendLayout()
        Me.SplitContainerCmdGo.SuspendLayout()
        CType(Me.splitRes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitRes.Panel1.SuspendLayout()
        Me.splitRes.Panel2.SuspendLayout()
        Me.splitRes.SuspendLayout()
        CType(Me.VistaMenu, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.splitMain.Panel1.Controls.Add(Me.lblProgress)
        Me.splitMain.Panel1.Controls.Add(Me.lblStepDescription)
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.Controls.Add(Me.splitA)
        Me.splitMain.Size = New System.Drawing.Size(563, 266)
        Me.splitMain.SplitterDistance = 25
        Me.splitMain.TabIndex = 1
        Me.splitMain.TabStop = False
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProgress.AutoSize = True
        Me.lblProgress.CausesValidation = False
        Me.lblProgress.Location = New System.Drawing.Point(244, 6)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(64, 13)
        Me.lblProgress.TabIndex = 2
        Me.lblProgress.Text = "lblProgress"
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStepDescription
        '
        Me.lblStepDescription.AutoSize = True
        Me.lblStepDescription.Location = New System.Drawing.Point(6, 6)
        Me.lblStepDescription.Name = "lblStepDescription"
        Me.lblStepDescription.Size = New System.Drawing.Size(136, 13)
        Me.lblStepDescription.TabIndex = 1
        Me.lblStepDescription.Text = "Step 5 : start file research"
        '
        'splitA
        '
        Me.splitA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitA.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitA.IsSplitterFixed = True
        Me.splitA.Location = New System.Drawing.Point(0, 0)
        Me.splitA.Name = "splitA"
        Me.splitA.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitA.Panel1
        '
        Me.splitA.Panel1.Controls.Add(Me.SplitContainerCmdGo)
        '
        'splitA.Panel2
        '
        Me.splitA.Panel2.Controls.Add(Me.splitRes)
        Me.splitA.Size = New System.Drawing.Size(563, 237)
        Me.splitA.SplitterDistance = 25
        Me.splitA.TabIndex = 0
        '
        'SplitContainerCmdGo
        '
        Me.SplitContainerCmdGo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerCmdGo.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerCmdGo.IsSplitterFixed = True
        Me.SplitContainerCmdGo.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerCmdGo.Name = "SplitContainerCmdGo"
        '
        'SplitContainerCmdGo.Panel1
        '
        Me.SplitContainerCmdGo.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainerCmdGo.Panel2
        '
        Me.SplitContainerCmdGo.Panel2.Controls.Add(Me.cmdGo)
        Me.SplitContainerCmdGo.Size = New System.Drawing.Size(563, 25)
        Me.SplitContainerCmdGo.SplitterDistance = 486
        Me.SplitContainerCmdGo.TabIndex = 2
        Me.SplitContainerCmdGo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(469, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Start research NOW ! This only displays results, nothing will be deleted until yo" &
    "u decide it."
        '
        'cmdGo
        '
        Me.cmdGo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGo.Image = Global.My.Resources.Resources.control
        Me.cmdGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGo.Location = New System.Drawing.Point(5, 1)
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.Size = New System.Drawing.Size(62, 23)
        Me.cmdGo.TabIndex = 2
        Me.cmdGo.Text = "    Go !"
        Me.cmdGo.UseVisualStyleBackColor = True
        '
        'splitRes
        '
        Me.splitRes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitRes.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitRes.IsSplitterFixed = True
        Me.splitRes.Location = New System.Drawing.Point(0, 0)
        Me.splitRes.Name = "splitRes"
        Me.splitRes.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitRes.Panel1
        '
        '
        'splitRes.Panel2
        '
        Me.splitRes.Panel2.Controls.Add(Me.lblGroups)
        Me.splitRes.Panel2.Controls.Add(Me.Label5)
        Me.splitRes.Panel2.Controls.Add(Me.lblWastedSpace)
        Me.splitRes.Panel2.Controls.Add(Me.Label4)
        Me.splitRes.Panel2.Controls.Add(Me.lblDuplicateCount)
        Me.splitRes.Panel2.Controls.Add(Me.Label2)
        Me.splitRes.Panel2.Enabled = False
        Me.splitRes.Size = New System.Drawing.Size(563, 208)
        Me.splitRes.SplitterDistance = 179
        Me.splitRes.TabIndex = 0
        Me.splitRes.TabStop = False
        '
        'headerPath
        '
        Me.headerPath.Text = "File"
        Me.headerPath.Width = 291
        '
        'headerType
        '
        Me.headerType.Text = "Type"
        Me.headerType.Width = 50
        '
        'headerSize
        '
        Me.headerSize.Text = "Size"
        Me.headerSize.Width = 76
        '
        'headerDate
        '
        Me.headerDate.Text = "Created Date"
        '
        'headerGroup
        '
        Me.headerGroup.Text = "Group"
        '
        'lblGroups
        '
        Me.lblGroups.AutoSize = True
        Me.lblGroups.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroups.Location = New System.Drawing.Point(353, 6)
        Me.lblGroups.Name = "lblGroups"
        Me.lblGroups.Size = New System.Drawing.Size(13, 13)
        Me.lblGroups.TabIndex = 6
        Me.lblGroups.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(305, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Groups"
        '
        'lblWastedSpace
        '
        Me.lblWastedSpace.AutoSize = True
        Me.lblWastedSpace.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWastedSpace.Location = New System.Drawing.Point(228, 6)
        Me.lblWastedSpace.Name = "lblWastedSpace"
        Me.lblWastedSpace.Size = New System.Drawing.Size(44, 13)
        Me.lblWastedSpace.TabIndex = 3
        Me.lblWastedSpace.Text = "0 Bytes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(147, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Wasted space"
        '
        'lblDuplicateCount
        '
        Me.lblDuplicateCount.AutoSize = True
        Me.lblDuplicateCount.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuplicateCount.Location = New System.Drawing.Point(89, 6)
        Me.lblDuplicateCount.Name = "lblDuplicateCount"
        Me.lblDuplicateCount.Size = New System.Drawing.Size(13, 13)
        Me.lblDuplicateCount.TabIndex = 1
        Me.lblDuplicateCount.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Duplicate files"
        '
        'VistaMenu
        '
        Me.VistaMenu.ContainerControl = Me
        '
        'RMenuItemCopy
        '
        Me.VistaMenu.SetImage(Me.RMenuItemCopy, Global.My.Resources.Resources.copy16)
        Me.RMenuItemCopy.Index = 8
        Me.RMenuItemCopy.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemCopyFilePath, Me.MenuItemCopyFileHash, Me.MenuItemCopyAll})
        Me.RMenuItemCopy.Text = "&Copy"
        '
        'MenuItemCopyFilePath
        '
        Me.MenuItemCopyFilePath.Index = 0
        Me.MenuItemCopyFilePath.Text = "File &path"
        '
        'MenuItemCopyFileHash
        '
        Me.MenuItemCopyFileHash.Index = 1
        Me.MenuItemCopyFileHash.Text = "File &hash"
        '
        'MenuItemCopyAll
        '
        Me.MenuItemCopyAll.Index = 2
        Me.MenuItemCopyAll.Text = "All informations"
        '
        'MenuItemSelToTrash
        '
        Me.VistaMenu.SetImage(Me.MenuItemSelToTrash, Global.My.Resources.Resources.trash16)
        Me.MenuItemSelToTrash.Index = 4
        Me.MenuItemSelToTrash.Text = "Move selected files to trash"
        '
        'MenuItemSelDelete
        '
        Me.VistaMenu.SetImage(Me.MenuItemSelDelete, Global.My.Resources.Resources.cross16)
        Me.MenuItemSelDelete.Index = 5
        Me.MenuItemSelDelete.Text = "Delete selected files"
        '
        'MenuItemChToTrash
        '
        Me.VistaMenu.SetImage(Me.MenuItemChToTrash, Global.My.Resources.Resources.trash16)
        Me.MenuItemChToTrash.Index = 10
        Me.MenuItemChToTrash.Text = "Move checked files to trash"
        '
        'MenuItemChDelete
        '
        Me.VistaMenu.SetImage(Me.MenuItemChDelete, Global.My.Resources.Resources.cross16)
        Me.MenuItemChDelete.Index = 11
        Me.MenuItemChDelete.Text = "Delete checked files"
        '
        'MenuItemOpenFileLocation
        '
        Me.VistaMenu.SetImage(Me.MenuItemOpenFileLocation, Global.My.Resources.Resources.folder_open)
        Me.MenuItemOpenFileLocation.Index = 2
        Me.MenuItemOpenFileLocation.Text = "&Open file location"
        '
        'MenuItemFileProperties
        '
        Me.VistaMenu.SetImage(Me.MenuItemFileProperties, Global.My.Resources.Resources.document_text)
        Me.MenuItemFileProperties.Index = 3
        Me.MenuItemFileProperties.Text = "File &properties"
        '
        'MenuItemRefresh
        '
        Me.VistaMenu.SetImage(Me.MenuItemRefresh, Global.My.Resources.Resources.refresh16)
        Me.MenuItemRefresh.Index = 21
        Me.MenuItemRefresh.Text = "&Refresh list"
        '
        'MenuItemSaveList
        '
        Me.VistaMenu.SetImage(Me.MenuItemSaveList, Global.My.Resources.Resources.save16)
        Me.MenuItemSaveList.Index = 24
        Me.MenuItemSaveList.Text = "&Save list..."
        '
        'mnuFile
        '
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemOpenFile, Me.MenuItem1, Me.MenuItemOpenFileLocation, Me.MenuItemFileProperties, Me.MenuItemSelToTrash, Me.MenuItemSelDelete, Me.MenuItemSelRemove, Me.MenuItemSelMove, Me.RMenuItemCopy, Me.MenuItem7, Me.MenuItemChToTrash, Me.MenuItemChDelete, Me.MenuItemChRemove, Me.MenuItemChMove, Me.MenuItem11, Me.RMenuItemDupSel, Me.MenuItemSelCheck, Me.MenuItemSelUncheck, Me.MenuItemCheckAll, Me.MenuItemCheckNone, Me.MenuItem15, Me.MenuItemRefresh, Me.RMenuItemFilter, Me.MenuItemOrphan, Me.MenuItemSaveList})
        '
        'MenuItemOpenFile
        '
        Me.MenuItemOpenFile.Index = 0
        Me.MenuItemOpenFile.Text = "&Open file"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.Text = "-"
        '
        'MenuItemSelRemove
        '
        Me.MenuItemSelRemove.Index = 6
        Me.MenuItemSelRemove.Text = "Remove selected files from list"
        '
        'MenuItemSelMove
        '
        Me.MenuItemSelMove.Index = 7
        Me.MenuItemSelMove.Text = "Move selected files to..."
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 9
        Me.MenuItem7.Text = "-"
        '
        'MenuItemChRemove
        '
        Me.MenuItemChRemove.Index = 12
        Me.MenuItemChRemove.Text = "Remove checked files from list"
        '
        'MenuItemChMove
        '
        Me.MenuItemChMove.Index = 13
        Me.MenuItemChMove.Text = "Move checked files to..."
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 14
        Me.MenuItem11.Text = "-"
        '
        'RMenuItemDupSel
        '
        Me.RMenuItemDupSel.Index = 15
        Me.RMenuItemDupSel.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemDS_mc, Me.MenuItemDS_lc, Me.MenuItemDS_mm, Me.MenuItemDS_lm, Me.MenuItemDS_ma, Me.MenuItemDS_ra, Me.MenuItemDS_shortestname, Me.MenuItemDS_longestname, Me.MenuItemDS_shortestnonnumericname, Me.MenuItemDS_longestnonnumericname, Me.MenuItemDS_ShortestPath, Me.MenuItemDS_LongestPath})
        Me.RMenuItemDupSel.Text = "&Duplicate Selector"
        '
        'MenuItemDS_mc
        '
        Me.MenuItemDS_mc.Index = 0
        Me.MenuItemDS_mc.Text = "Original has the most recent creation date"
        '
        'MenuItemDS_lc
        '
        Me.MenuItemDS_lc.Index = 1
        Me.MenuItemDS_lc.Text = "Original has the less recent creation date"
        '
        'MenuItemDS_mm
        '
        Me.MenuItemDS_mm.Index = 2
        Me.MenuItemDS_mm.Text = "Original has the most recent modification date"
        '
        'MenuItemDS_lm
        '
        Me.MenuItemDS_lm.Index = 3
        Me.MenuItemDS_lm.Text = "Original has the less recent modification date"
        '
        'MenuItemDS_ma
        '
        Me.MenuItemDS_ma.Index = 4
        Me.MenuItemDS_ma.Text = "Original has the most recent last access date"
        '
        'MenuItemDS_ra
        '
        Me.MenuItemDS_ra.Index = 5
        Me.MenuItemDS_ra.Text = "Original has the less recent last access date"
        '
        'MenuItemDS_shortestname
        '
        Me.MenuItemDS_shortestname.Index = 6
        Me.MenuItemDS_shortestname.Text = "Original has the shortest name"
        '
        'MenuItemDS_longestname
        '
        Me.MenuItemDS_longestname.Index = 7
        Me.MenuItemDS_longestname.Text = "Original has the longest name"
        '
        'MenuItemDS_shortestnonnumericname
        '
        Me.MenuItemDS_shortestnonnumericname.Index = 8
        Me.MenuItemDS_shortestnonnumericname.Text = "Original has the shortest non-numeric name"
        '
        'MenuItemDS_longestnonnumericname
        '
        Me.MenuItemDS_longestnonnumericname.Index = 9
        Me.MenuItemDS_longestnonnumericname.Text = "Original has the longest non-numeric name"
        '
        'MenuItemDS_ShortestPath
        '
        Me.MenuItemDS_ShortestPath.Index = 10
        Me.MenuItemDS_ShortestPath.Text = "Original has the shortest path"
        '
        'MenuItemDS_LongestPath
        '
        Me.MenuItemDS_LongestPath.Index = 11
        Me.MenuItemDS_LongestPath.Text = "Original has the longest path"
        '
        'MenuItemSelCheck
        '
        Me.MenuItemSelCheck.Index = 16
        Me.MenuItemSelCheck.Text = "Check selected"
        '
        'MenuItemSelUncheck
        '
        Me.MenuItemSelUncheck.Index = 17
        Me.MenuItemSelUncheck.Text = "Uncheck selected"
        '
        'MenuItemCheckAll
        '
        Me.MenuItemCheckAll.Index = 18
        Me.MenuItemCheckAll.Text = "Check &all"
        '
        'MenuItemCheckNone
        '
        Me.MenuItemCheckNone.Index = 19
        Me.MenuItemCheckNone.Text = "Check &none"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 20
        Me.MenuItem15.Text = "-"
        '
        'RMenuItemFilter
        '
        Me.RMenuItemFilter.Index = 22
        Me.RMenuItemFilter.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemFRArchives, Me.MenuItemFRImages, Me.MenuItemFRMusic, Me.MenuItemFRVideos, Me.MenuItem8, Me.MenuItemFOArchive, Me.MenuItemFOImages, Me.MenuItemFOMusic, Me.MenuItemFOVideos, Me.MenuItem2, Me.MenuItemFRCustom, Me.RMenuItemRPath})
        Me.RMenuItemFilter.Text = "&Filter"
        '
        'MenuItemFRArchives
        '
        Me.MenuItemFRArchives.Checked = True
        Me.MenuItemFRArchives.Index = 0
        Me.MenuItemFRArchives.Text = "Display archives in list"
        '
        'MenuItemFRImages
        '
        Me.MenuItemFRImages.Checked = True
        Me.MenuItemFRImages.Index = 1
        Me.MenuItemFRImages.Text = "Display images in list"
        '
        'MenuItemFRMusic
        '
        Me.MenuItemFRMusic.Checked = True
        Me.MenuItemFRMusic.Index = 2
        Me.MenuItemFRMusic.Text = "Display music in list"
        '
        'MenuItemFRVideos
        '
        Me.MenuItemFRVideos.Checked = True
        Me.MenuItemFRVideos.Index = 3
        Me.MenuItemFRVideos.Text = "Display videos in list"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 4
        Me.MenuItem8.Text = "-"
        '
        'MenuItemFOArchive
        '
        Me.MenuItemFOArchive.Index = 5
        Me.MenuItemFOArchive.Text = "Only display archives in list"
        '
        'MenuItemFOImages
        '
        Me.MenuItemFOImages.Index = 6
        Me.MenuItemFOImages.Text = "Only display images in list"
        '
        'MenuItemFOMusic
        '
        Me.MenuItemFOMusic.Index = 7
        Me.MenuItemFOMusic.Text = "Only display music in list"
        '
        'MenuItemFOVideos
        '
        Me.MenuItemFOVideos.Index = 8
        Me.MenuItemFOVideos.Text = "Only display videos in list"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 9
        Me.MenuItem2.Text = "-"
        '
        'MenuItemFRCustom
        '
        Me.MenuItemFRCustom.Index = 10
        Me.MenuItemFRCustom.Text = "Remove by custom extension..."
        '
        'RMenuItemRPath
        '
        Me.RMenuItemRPath.Index = 11
        Me.RMenuItemRPath.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemFRFolder, Me.MenuItemRIPath})
        Me.RMenuItemRPath.Text = "Filter by path"
        '
        'MenuItemFRFolder
        '
        Me.MenuItemFRFolder.Index = 0
        Me.MenuItemFRFolder.Text = "Exclude a path..."
        '
        'MenuItemRIPath
        '
        Me.MenuItemRIPath.Index = 1
        Me.MenuItemRIPath.Text = "Only include one path..."
        '
        'MenuItemOrphan
        '
        Me.MenuItemOrphan.Index = 23
        Me.MenuItemOrphan.Text = "Remove &orphan files from list"
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.Filter = "CSV file (*.csv)|*.csv"
        Me.SaveFileDialog.SupportMultiDottedExtensions = True
        Me.SaveFileDialog.Title = "Save list"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = -1
        Me.MenuItem4.Text = "Original has the longest non-numeric name"
        '
        'ctlStep5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.splitMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctlStep5"
        Me.Size = New System.Drawing.Size(563, 266)
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel1.PerformLayout()
        Me.splitMain.Panel2.ResumeLayout(False)
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        Me.splitA.Panel1.ResumeLayout(False)
        Me.splitA.Panel2.ResumeLayout(False)
        CType(Me.splitA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitA.ResumeLayout(False)
        Me.SplitContainerCmdGo.Panel1.ResumeLayout(False)
        Me.SplitContainerCmdGo.Panel1.PerformLayout()
        Me.SplitContainerCmdGo.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerCmdGo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerCmdGo.ResumeLayout(False)
        Me.splitRes.Panel1.ResumeLayout(False)
        Me.splitRes.Panel2.ResumeLayout(False)
        Me.splitRes.Panel2.PerformLayout()
        CType(Me.splitRes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitRes.ResumeLayout(False)
        CType(Me.VistaMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents splitMain As System.Windows.Forms.SplitContainer
    Friend WithEvents lblStepDescription As System.Windows.Forms.Label
    Friend WithEvents splitA As System.Windows.Forms.SplitContainer
    Friend WithEvents splitRes As System.Windows.Forms.SplitContainer
    Friend WithEvents headerPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents headerType As System.Windows.Forms.ColumnHeader
    Friend WithEvents headerSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblWastedSpace As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDuplicateCount As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents headerDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblGroups As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents headerGroup As System.Windows.Forms.ColumnHeader
    Friend WithEvents SplitContainerCmdGo As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdGo As System.Windows.Forms.Button
    Friend WithEvents VistaMenu As wyDay.Controls.VistaMenu
    Private WithEvents mnuFile As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemOpenFile As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemOpenFileLocation As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSelToTrash As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSelDelete As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSelRemove As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemChToTrash As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemChDelete As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemChRemove As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCheckAll As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCheckNone As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFileProperties As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents RMenuItemCopy As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCopyFilePath As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCopyFileHash As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemRefresh As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSelCheck As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSelUncheck As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCopyAll As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSaveList As System.Windows.Forms.MenuItem
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents RMenuItemDupSel As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDS_mc As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDS_lc As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDS_mm As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDS_lm As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDS_ma As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDS_ra As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSelMove As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemChMove As System.Windows.Forms.MenuItem
    Friend WithEvents RMenuItemFilter As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFRVideos As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemOrphan As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFRImages As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFRArchives As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFRMusic As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFRCustom As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFOVideos As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFOImages As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFOArchive As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFOMusic As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemFRFolder As System.Windows.Forms.MenuItem
    Friend WithEvents RMenuItemRPath As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemRIPath As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDS_shortestname As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDS_longestname As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDS_shortestnonnumericname As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDS_longestnonnumericname As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDS_ShortestPath As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDS_LongestPath As System.Windows.Forms.MenuItem

End Class
