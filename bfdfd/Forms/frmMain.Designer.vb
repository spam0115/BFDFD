<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits PersistentForm

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
        Me.MenuItemCheckAll = New System.Windows.Forms.MenuItem()
        Me.MenuItemSelCheck = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_LongestPath = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_ShortestPath = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_longestnonnumericname = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_shortestnonnumericname = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_longestname = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_shortestname = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_lm = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_mm = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_lc = New System.Windows.Forms.MenuItem()
        Me.MenuItemDS_mc = New System.Windows.Forms.MenuItem()
        Me.RMenuItemDupSel = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.MenuItemSelUncheck = New System.Windows.Forms.MenuItem()
        Me.MenuItemChRemove = New System.Windows.Forms.MenuItem()
        Me.MenuItemCheckNone = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItemOrphan = New System.Windows.Forms.MenuItem()
        Me.MenuItemRIPath = New System.Windows.Forms.MenuItem()
        Me.MenuItemFRFolder = New System.Windows.Forms.MenuItem()
        Me.RMenuItemRPath = New System.Windows.Forms.MenuItem()
        Me.MenuItemFRCustom = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItemFOVideos = New System.Windows.Forms.MenuItem()
        Me.MenuItemChMove = New System.Windows.Forms.MenuItem()
        Me.MenuItemFOMusic = New System.Windows.Forms.MenuItem()
        Me.MenuItemFOArchive = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItemFRVideos = New System.Windows.Forms.MenuItem()
        Me.MenuItemFRMusic = New System.Windows.Forms.MenuItem()
        Me.MenuItemFRImages = New System.Windows.Forms.MenuItem()
        Me.MenuItemFRArchives = New System.Windows.Forms.MenuItem()
        Me.RMenuItemFilter = New System.Windows.Forms.MenuItem()
        Me.MenuItemFOImages = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.MenuItemSelMove = New System.Windows.Forms.MenuItem()
        Me.MenuItemSelRemove = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItemOpenFile = New System.Windows.Forms.MenuItem()
        Me.mnuFile = New System.Windows.Forms.ContextMenu()
        Me.MenuItemOpenFileLocation = New System.Windows.Forms.MenuItem()
        Me.MenuItemFileProperties = New System.Windows.Forms.MenuItem()
        Me.MenuItemSelToTrash = New System.Windows.Forms.MenuItem()
        Me.MenuItemSelDelete = New System.Windows.Forms.MenuItem()
        Me.RMenuItemCopy = New System.Windows.Forms.MenuItem()
        Me.MenuItemCopyFilePath = New System.Windows.Forms.MenuItem()
        Me.MenuItemCopyFileHash = New System.Windows.Forms.MenuItem()
        Me.MenuItemCopyAll = New System.Windows.Forms.MenuItem()
        Me.MenuItemChToTrash = New System.Windows.Forms.MenuItem()
        Me.MenuItemChDelete = New System.Windows.Forms.MenuItem()
        Me.MenuItemRefresh = New System.Windows.Forms.MenuItem()
        Me.MenuItemSaveList = New System.Windows.Forms.MenuItem()
        Me.VistaMenu = New wyDay.Controls.VistaMenu(Me.components)
        Me.lblTop = New System.Windows.Forms.Label()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.vlvFiles = New BrightIdeasSoftware.VirtualObjectListView()
        Me.OlvColumn0 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.lblGroups = New System.Windows.Forms.Label()
        Me.lblWastedSpaceBytes = New System.Windows.Forms.Label()
        Me.lblWastedSpace = New System.Windows.Forms.Label()
        Me.lblDuplicateCount = New System.Windows.Forms.Label()
        Me.lblDuplicates = New System.Windows.Forms.Label()
        Me.lblGroupsCount = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblError = New System.Windows.Forms.Label()
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.lblFileCountValue = New System.Windows.Forms.Label()
        Me.lblFiles = New System.Windows.Forms.Label()
        CType(Me.VistaMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vlvFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuItemCheckAll
        '
        Me.MenuItemCheckAll.Index = 18
        Me.MenuItemCheckAll.Text = "Check &all"
        '
        'MenuItemSelCheck
        '
        Me.MenuItemSelCheck.Index = 16
        Me.MenuItemSelCheck.Text = "Check selected"
        '
        'MenuItemDS_LongestPath
        '
        Me.MenuItemDS_LongestPath.Index = 9
        Me.MenuItemDS_LongestPath.Text = "Original has the longest path"
        '
        'MenuItemDS_ShortestPath
        '
        Me.MenuItemDS_ShortestPath.Index = 8
        Me.MenuItemDS_ShortestPath.Text = "Original has the shortest path"
        '
        'MenuItemDS_longestnonnumericname
        '
        Me.MenuItemDS_longestnonnumericname.Index = 7
        Me.MenuItemDS_longestnonnumericname.Text = "Original has the longest non-numeric name"
        '
        'MenuItemDS_shortestnonnumericname
        '
        Me.MenuItemDS_shortestnonnumericname.Index = 6
        Me.MenuItemDS_shortestnonnumericname.Text = "Original has the shortest non-numeric name"
        '
        'MenuItemDS_longestname
        '
        Me.MenuItemDS_longestname.Index = 5
        Me.MenuItemDS_longestname.Text = "Original has the longest name"
        '
        'MenuItemDS_shortestname
        '
        Me.MenuItemDS_shortestname.Index = 4
        Me.MenuItemDS_shortestname.Text = "Original has the shortest name"
        '
        'MenuItemDS_lm
        '
        Me.MenuItemDS_lm.Index = 3
        Me.MenuItemDS_lm.Text = "Original has the less recent modification date"
        '
        'MenuItemDS_mm
        '
        Me.MenuItemDS_mm.Index = 2
        Me.MenuItemDS_mm.Text = "Original has the most recent modification date"
        '
        'MenuItemDS_lc
        '
        Me.MenuItemDS_lc.Index = 1
        Me.MenuItemDS_lc.Text = "Original has the less recent creation date"
        '
        'MenuItemDS_mc
        '
        Me.MenuItemDS_mc.Index = 0
        Me.MenuItemDS_mc.Text = "Original has the most recent creation date"
        '
        'RMenuItemDupSel
        '
        Me.RMenuItemDupSel.Index = 15
        Me.RMenuItemDupSel.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemDS_mc, Me.MenuItemDS_lc, Me.MenuItemDS_mm, Me.MenuItemDS_lm, Me.MenuItemDS_shortestname, Me.MenuItemDS_longestname, Me.MenuItemDS_shortestnonnumericname, Me.MenuItemDS_longestnonnumericname, Me.MenuItemDS_ShortestPath, Me.MenuItemDS_LongestPath})
        Me.RMenuItemDupSel.Text = "&Duplicate Selector"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 14
        Me.MenuItem11.Text = "-"
        '
        'MenuItemSelUncheck
        '
        Me.MenuItemSelUncheck.Index = 17
        Me.MenuItemSelUncheck.Text = "Uncheck selected"
        '
        'MenuItemChRemove
        '
        Me.MenuItemChRemove.Index = 12
        Me.MenuItemChRemove.Text = "Remove checked files from list"
        '
        'MenuItemCheckNone
        '
        Me.MenuItemCheckNone.Index = 19
        Me.MenuItemCheckNone.Text = "Check &none"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = -1
        Me.MenuItem4.Text = "Original has the longest non-numeric name"
        '
        'MenuItemOrphan
        '
        Me.MenuItemOrphan.Index = 23
        Me.MenuItemOrphan.Text = "Remove &orphan files from list"
        '
        'MenuItemRIPath
        '
        Me.MenuItemRIPath.Index = 1
        Me.MenuItemRIPath.Text = "Only include one path..."
        '
        'MenuItemFRFolder
        '
        Me.MenuItemFRFolder.Index = 0
        Me.MenuItemFRFolder.Text = "Exclude a path..."
        '
        'RMenuItemRPath
        '
        Me.RMenuItemRPath.Index = 11
        Me.RMenuItemRPath.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemFRFolder, Me.MenuItemRIPath})
        Me.RMenuItemRPath.Text = "Filter by path"
        '
        'MenuItemFRCustom
        '
        Me.MenuItemFRCustom.Index = 10
        Me.MenuItemFRCustom.Text = "Remove by custom extension..."
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 9
        Me.MenuItem2.Text = "-"
        '
        'MenuItemFOVideos
        '
        Me.MenuItemFOVideos.Index = 8
        Me.MenuItemFOVideos.Text = "Only display videos in list"
        '
        'MenuItemChMove
        '
        Me.MenuItemChMove.Index = 13
        Me.MenuItemChMove.Text = "Move checked files to..."
        '
        'MenuItemFOMusic
        '
        Me.MenuItemFOMusic.Index = 7
        Me.MenuItemFOMusic.Text = "Only display music in list"
        '
        'MenuItemFOArchive
        '
        Me.MenuItemFOArchive.Index = 5
        Me.MenuItemFOArchive.Text = "Only display archives in list"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 4
        Me.MenuItem8.Text = "-"
        '
        'MenuItemFRVideos
        '
        Me.MenuItemFRVideos.Checked = True
        Me.MenuItemFRVideos.Index = 3
        Me.MenuItemFRVideos.Text = "Display videos in list"
        '
        'MenuItemFRMusic
        '
        Me.MenuItemFRMusic.Checked = True
        Me.MenuItemFRMusic.Index = 2
        Me.MenuItemFRMusic.Text = "Display music in list"
        '
        'MenuItemFRImages
        '
        Me.MenuItemFRImages.Checked = True
        Me.MenuItemFRImages.Index = 1
        Me.MenuItemFRImages.Text = "Display images in list"
        '
        'MenuItemFRArchives
        '
        Me.MenuItemFRArchives.Checked = True
        Me.MenuItemFRArchives.Index = 0
        Me.MenuItemFRArchives.Text = "Display archives in list"
        '
        'RMenuItemFilter
        '
        Me.RMenuItemFilter.Index = 22
        Me.RMenuItemFilter.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemFRArchives, Me.MenuItemFRImages, Me.MenuItemFRMusic, Me.MenuItemFRVideos, Me.MenuItem8, Me.MenuItemFOArchive, Me.MenuItemFOImages, Me.MenuItemFOMusic, Me.MenuItemFOVideos, Me.MenuItem2, Me.MenuItemFRCustom, Me.RMenuItemRPath})
        Me.RMenuItemFilter.Text = "&Filter"
        '
        'MenuItemFOImages
        '
        Me.MenuItemFOImages.Index = 6
        Me.MenuItemFOImages.Text = "Only display images in list"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 20
        Me.MenuItem15.Text = "-"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 9
        Me.MenuItem7.Text = "-"
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.Filter = "CSV file (*.csv)|*.csv"
        Me.SaveFileDialog.SupportMultiDottedExtensions = True
        Me.SaveFileDialog.Title = "Save list"
        '
        'MenuItemSelMove
        '
        Me.MenuItemSelMove.Index = 7
        Me.MenuItemSelMove.Text = "Move selected files to..."
        '
        'MenuItemSelRemove
        '
        Me.MenuItemSelRemove.Index = 6
        Me.MenuItemSelRemove.Text = "Remove selected files from list"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.Text = "-"
        '
        'MenuItemOpenFile
        '
        Me.MenuItemOpenFile.Index = 0
        Me.MenuItemOpenFile.Text = "&Open file"
        '
        'mnuFile
        '
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemOpenFile, Me.MenuItem1, Me.MenuItemOpenFileLocation, Me.MenuItemFileProperties, Me.MenuItemSelToTrash, Me.MenuItemSelDelete, Me.MenuItemSelRemove, Me.MenuItemSelMove, Me.RMenuItemCopy, Me.MenuItem7, Me.MenuItemChToTrash, Me.MenuItemChDelete, Me.MenuItemChRemove, Me.MenuItemChMove, Me.MenuItem11, Me.RMenuItemDupSel, Me.MenuItemSelCheck, Me.MenuItemSelUncheck, Me.MenuItemCheckAll, Me.MenuItemCheckNone, Me.MenuItem15, Me.MenuItemRefresh, Me.RMenuItemFilter, Me.MenuItemOrphan, Me.MenuItemSaveList})
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
        'VistaMenu
        '
        Me.VistaMenu.ContainerControl = Me
        '
        'lblTop
        '
        Me.lblTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTop.AutoSize = True
        Me.lblTop.CausesValidation = False
        Me.lblTop.Location = New System.Drawing.Point(16, 10)
        Me.lblTop.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTop.Name = "lblTop"
        Me.lblTop.Size = New System.Drawing.Size(245, 16)
        Me.lblTop.TabIndex = 0
        Me.lblTop.Text = "Press ""Go!"" to start finding duplicate files"
        Me.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPause
        '
        Me.btnPause.Image = Global.My.Resources.Resources.Pause_16x16
        Me.btnPause.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPause.Location = New System.Drawing.Point(107, 37)
        Me.btnPause.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(85, 33)
        Me.btnPause.TabIndex = 4
        Me.btnPause.Text = "    Pause"
        Me.btnPause.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Image = Global.My.Resources.Resources.control
        Me.btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGo.Location = New System.Drawing.Point(13, 38)
        Me.btnGo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(84, 31)
        Me.btnGo.TabIndex = 3
        Me.btnGo.Text = "    Go !"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'vlvFiles
        '
        Me.vlvFiles.AllColumns.Add(Me.OlvColumn0)
        Me.vlvFiles.AllColumns.Add(Me.OlvColumn1)
        Me.vlvFiles.AllColumns.Add(Me.OlvColumn2)
        Me.vlvFiles.AllColumns.Add(Me.OlvColumn3)
        Me.vlvFiles.AllColumns.Add(Me.OlvColumn4)
        Me.vlvFiles.AllColumns.Add(Me.OlvColumn5)
        Me.vlvFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vlvFiles.CausesValidation = False
        Me.vlvFiles.CellEditUseWholeCell = False
        Me.vlvFiles.CheckBoxes = True
        Me.vlvFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn0, Me.OlvColumn1, Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5})
        Me.vlvFiles.Cursor = System.Windows.Forms.Cursors.Default
        Me.vlvFiles.FullRowSelect = True
        Me.vlvFiles.HideSelection = False
        Me.vlvFiles.LabelWrap = False
        Me.vlvFiles.Location = New System.Drawing.Point(13, 78)
        Me.vlvFiles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.vlvFiles.Name = "vlvFiles"
        Me.vlvFiles.ShowGroups = False
        Me.vlvFiles.ShowImagesOnSubItems = True
        Me.vlvFiles.ShowItemToolTips = True
        Me.vlvFiles.Size = New System.Drawing.Size(1193, 767)
        Me.vlvFiles.TabIndex = 3
        Me.vlvFiles.UseCompatibleStateImageBehavior = False
        Me.vlvFiles.View = System.Windows.Forms.View.Details
        Me.vlvFiles.VirtualMode = True
        '
        'OlvColumn0
        '
        Me.OlvColumn0.Text = "Group"
        '
        'OlvColumn1
        '
        Me.OlvColumn1.FillsFreeSpace = True
        Me.OlvColumn1.Text = "File"
        '
        'OlvColumn2
        '
        Me.OlvColumn2.Text = "Type"
        '
        'OlvColumn3
        '
        Me.OlvColumn3.Text = "Size"
        '
        'OlvColumn4
        '
        Me.OlvColumn4.Text = "Created Date"
        '
        'OlvColumn5
        '
        Me.OlvColumn5.Text = "Modified Date"
        '
        'lblGroups
        '
        Me.lblGroups.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGroups.AutoSize = True
        Me.lblGroups.Location = New System.Drawing.Point(9, 862)
        Me.lblGroups.Name = "lblGroups"
        Me.lblGroups.Size = New System.Drawing.Size(54, 16)
        Me.lblGroups.TabIndex = 11
        Me.lblGroups.Text = "Groups:"
        '
        'lblWastedSpaceBytes
        '
        Me.lblWastedSpaceBytes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblWastedSpaceBytes.AutoSize = True
        Me.lblWastedSpaceBytes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWastedSpaceBytes.Location = New System.Drawing.Point(697, 862)
        Me.lblWastedSpaceBytes.Name = "lblWastedSpaceBytes"
        Me.lblWastedSpaceBytes.Size = New System.Drawing.Size(57, 19)
        Me.lblWastedSpaceBytes.TabIndex = 10
        Me.lblWastedSpaceBytes.Text = "0 Bytes"
        '
        'lblWastedSpace
        '
        Me.lblWastedSpace.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblWastedSpace.AutoSize = True
        Me.lblWastedSpace.Location = New System.Drawing.Point(587, 862)
        Me.lblWastedSpace.Name = "lblWastedSpace"
        Me.lblWastedSpace.Size = New System.Drawing.Size(98, 16)
        Me.lblWastedSpace.TabIndex = 9
        Me.lblWastedSpace.Text = "Wasted space:"
        '
        'lblDuplicateCount
        '
        Me.lblDuplicateCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDuplicateCount.AutoSize = True
        Me.lblDuplicateCount.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuplicateCount.Location = New System.Drawing.Point(461, 862)
        Me.lblDuplicateCount.Name = "lblDuplicateCount"
        Me.lblDuplicateCount.Size = New System.Drawing.Size(17, 19)
        Me.lblDuplicateCount.TabIndex = 8
        Me.lblDuplicateCount.Text = "0"
        '
        'lblDuplicates
        '
        Me.lblDuplicates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDuplicates.AutoSize = True
        Me.lblDuplicates.Location = New System.Drawing.Point(355, 862)
        Me.lblDuplicates.Name = "lblDuplicates"
        Me.lblDuplicates.Size = New System.Drawing.Size(94, 16)
        Me.lblDuplicates.TabIndex = 7
        Me.lblDuplicates.Text = "Duplicate files:"
        '
        'lblGroupsCount
        '
        Me.lblGroupsCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGroupsCount.AutoSize = True
        Me.lblGroupsCount.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupsCount.Location = New System.Drawing.Point(73, 862)
        Me.lblGroupsCount.Name = "lblGroupsCount"
        Me.lblGroupsCount.Size = New System.Drawing.Size(17, 19)
        Me.lblGroupsCount.TabIndex = 12
        Me.lblGroupsCount.Text = "0"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lblError)
        Me.Panel1.Location = New System.Drawing.Point(199, 37)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1007, 32)
        Me.Panel1.TabIndex = 13
        '
        'lblError
        '
        Me.lblError.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblError.AutoSize = True
        Me.lblError.Location = New System.Drawing.Point(4, 7)
        Me.lblError.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(70, 16)
        Me.lblError.TabIndex = 1
        Me.lblError.Text = "                     "
        '
        'btnRestart
        '
        Me.btnRestart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestart.Location = New System.Drawing.Point(1133, 852)
        Me.btnRestart.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(75, 31)
        Me.btnRestart.TabIndex = 14
        Me.btnRestart.Text = "Restart"
        Me.btnRestart.UseVisualStyleBackColor = True
        '
        'lblFileCountValue
        '
        Me.lblFileCountValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFileCountValue.AutoSize = True
        Me.lblFileCountValue.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileCountValue.Location = New System.Drawing.Point(235, 862)
        Me.lblFileCountValue.Name = "lblFileCountValue"
        Me.lblFileCountValue.Size = New System.Drawing.Size(17, 19)
        Me.lblFileCountValue.TabIndex = 16
        Me.lblFileCountValue.Text = "0"
        '
        'lblFiles
        '
        Me.lblFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFiles.AutoSize = True
        Me.lblFiles.Location = New System.Drawing.Point(188, 862)
        Me.lblFiles.Name = "lblFiles"
        Me.lblFiles.Size = New System.Drawing.Size(39, 16)
        Me.lblFiles.TabIndex = 15
        Me.lblFiles.Text = "Files:"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1219, 889)
        Me.Controls.Add(Me.lblFileCountValue)
        Me.Controls.Add(Me.lblFiles)
        Me.Controls.Add(Me.btnRestart)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblGroups)
        Me.Controls.Add(Me.lblWastedSpaceBytes)
        Me.Controls.Add(Me.lblWastedSpace)
        Me.Controls.Add(Me.lblDuplicateCount)
        Me.Controls.Add(Me.lblDuplicates)
        Me.Controls.Add(Me.lblGroupsCount)
        Me.Controls.Add(Me.vlvFiles)
        Me.Controls.Add(Me.lblTop)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.btnPause)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmMain"
        Me.Text = "Big Fast Duplicate File Deleter!"
        CType(Me.VistaMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vlvFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuItemCheckAll As MenuItem
    Friend WithEvents MenuItemSelCheck As MenuItem
    Friend WithEvents MenuItemDS_LongestPath As MenuItem
    Friend WithEvents MenuItemDS_ShortestPath As MenuItem
    Friend WithEvents MenuItemDS_longestnonnumericname As MenuItem
    Friend WithEvents MenuItemDS_shortestnonnumericname As MenuItem
    Friend WithEvents MenuItemDS_longestname As MenuItem
    Friend WithEvents MenuItemDS_shortestname As MenuItem
    Friend WithEvents MenuItemDS_lm As MenuItem
    Friend WithEvents MenuItemDS_mm As MenuItem
    Friend WithEvents MenuItemDS_lc As MenuItem
    Friend WithEvents MenuItemDS_mc As MenuItem
    Friend WithEvents RMenuItemDupSel As MenuItem
    Friend WithEvents MenuItem11 As MenuItem
    Friend WithEvents MenuItemSelUncheck As MenuItem
    Friend WithEvents MenuItemChRemove As MenuItem
    Friend WithEvents MenuItemCheckNone As MenuItem
    Friend WithEvents MenuItem4 As MenuItem
    Friend WithEvents MenuItemOrphan As MenuItem
    Friend WithEvents MenuItemRIPath As MenuItem
    Friend WithEvents MenuItemFRFolder As MenuItem
    Friend WithEvents RMenuItemRPath As MenuItem
    Friend WithEvents MenuItemFRCustom As MenuItem
    Friend WithEvents MenuItem2 As MenuItem
    Friend WithEvents MenuItemFOVideos As MenuItem
    Friend WithEvents MenuItemChMove As MenuItem
    Friend WithEvents MenuItemFOMusic As MenuItem
    Friend WithEvents MenuItemFOArchive As MenuItem
    Friend WithEvents MenuItem8 As MenuItem
    Friend WithEvents MenuItemFRVideos As MenuItem
    Friend WithEvents MenuItemFRMusic As MenuItem
    Friend WithEvents MenuItemFRImages As MenuItem
    Friend WithEvents MenuItemFRArchives As MenuItem
    Friend WithEvents RMenuItemFilter As MenuItem
    Friend WithEvents MenuItemFOImages As MenuItem
    Friend WithEvents MenuItem15 As MenuItem
    Friend WithEvents MenuItem7 As MenuItem
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents MenuItemSelMove As MenuItem
    Friend WithEvents MenuItemSelRemove As MenuItem
    Friend WithEvents MenuItem1 As MenuItem
    Friend WithEvents MenuItemOpenFile As MenuItem
    Private WithEvents mnuFile As ContextMenu
    Friend WithEvents MenuItemOpenFileLocation As MenuItem
    Friend WithEvents VistaMenu As wyDay.Controls.VistaMenu
    Friend WithEvents MenuItemFileProperties As MenuItem
    Friend WithEvents MenuItemSelToTrash As MenuItem
    Friend WithEvents MenuItemSelDelete As MenuItem
    Friend WithEvents RMenuItemCopy As MenuItem
    Friend WithEvents MenuItemCopyFilePath As MenuItem
    Friend WithEvents MenuItemCopyFileHash As MenuItem
    Friend WithEvents MenuItemCopyAll As MenuItem
    Friend WithEvents MenuItemChToTrash As MenuItem
    Friend WithEvents MenuItemChDelete As MenuItem
    Friend WithEvents MenuItemRefresh As MenuItem
    Friend WithEvents MenuItemSaveList As MenuItem
    Friend WithEvents lblTop As Label
    Friend WithEvents vlvFiles As BrightIdeasSoftware.VirtualObjectListView
    Friend WithEvents OlvColumn0 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents lblGroups As Label
    Friend WithEvents lblWastedSpaceBytes As Label
    Friend WithEvents lblWastedSpace As Label
    Friend WithEvents lblDuplicateCount As Label
    Friend WithEvents lblDuplicates As Label
    Friend WithEvents lblGroupsCount As Label
    Friend WithEvents btnPause As Button
    Friend WithEvents btnGo As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblError As Label
    Friend WithEvents btnRestart As Button
    Friend WithEvents lblFiles As Label
    Friend WithEvents lblFileCountValue As Label
End Class
