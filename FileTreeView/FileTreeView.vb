' =======================================================
' Big Fast Duplicate File Deleter! (BFDFD)
' Copyright (c) 2008-2009 Alain Descotes (violent_ken)
' https://sourceforge.net/projects/yadfr/
' =======================================================


' Big Fast Duplicate File Deleter! is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 3 of the License, or
' (at your option) any later version.
'
' Big Fast Duplicate File Deleter! is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with Big Fast Duplicate File Deleter!; if not, see http://www.gnu.org/licenses/.

' Derivated from here : http://www.codeproject.com/KB/cpp/vbnettristatechkbox.aspx
' A work by Carlos J. Quintero

Option Strict On

Imports System.Runtime.InteropServices

Public Class FileTreeView
    Inherits System.Windows.Forms.TreeView

    ' Constants
    Private Const IMG_INDEX_DRIVE As Integer = 0
    Private Const IMG_INDEX_FOLDER As Integer = 1

    ' Contains list of icons
    Private _img As New ImageList

    Public Event NodeClicked()


    <StructLayout(LayoutKind.Sequential)> _
    Private Structure TVITEM
        Public mask As UInteger
        Public hItem As IntPtr
        Public state As UInteger
        Public stateMask As UInteger
        Public pszText As IntPtr
        Public cchTextMax As Integer
        Public iImage As Integer
        Public iSelectedImage As Integer
        Public cChildren As Integer
        Public lParam As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure POINTAPI
        Public x As Integer
        Public y As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure TVHITTESTINFO
        Public pt As POINTAPI
        Public flags As Integer
        Public hItem As IntPtr
    End Structure

    ' Messages
    Private Const TV_FIRST As Integer = &H1100
    Private Const TVM_SETIMAGELIST As Integer = TV_FIRST + 9
    Private Const TVM_GETITEM As Integer = TV_FIRST + 12
    Private Const TVM_SETITEM As Integer = TV_FIRST + 13
    Private Const TVM_HITTEST As Integer = TV_FIRST + 17

    ' TVM_SETIMAGELIST image list kind
    Private Const TVSIL_STATE As Integer = 2

    'TVITEM.mask flags
    Private Const TVIF_STATE As Integer = &H8
    Private Const TVIF_HANDLE As Integer = &H10

    'TVITEM.state flags
    Public Const TVIS_STATEIMAGEMASK As Integer = &HF000

    'TVHITTESTINFO.flags flags
    Public Const TVHT_ONITEMSTATEICON As Integer = &H40

    ' ImageList Images Indexes
    Private Const m_IMG_CHECKBOX_UNCHECKED As Integer = 1
    Private Const m_IMG_CHECKBOX_CHECKED As Integer = 2
    Private Const m_IMG_CHECKBOX_INDETERMINATE As Integer = 3

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInt32, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInt32, ByVal wParam As IntPtr, ByRef lParam As TVITEM) As IntPtr
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInt32, ByVal wParam As IntPtr, ByRef lParam As TVHITTESTINFO) As IntPtr
    End Function

    Public Sub New(ByVal ctlStateImageList As ImageList)
        SendMessage(Me.Handle, TVM_SETIMAGELIST, New IntPtr(TVSIL_STATE), ctlStateImageList.Handle)
        ' Initializes ImageList
        _img = New ImageList
        _img.ImageSize = New Size(16, 16)
        _img.ColorDepth = ColorDepth.Depth32Bit
        _img.Images.Add("drive", My.Resources.drive)
        _img.Images.Add("folder", My.Resources.folder)
        Me.ImageList = _img
        ' Retrieve list of drives
        Me.RefreshDriveList()
    End Sub

    Private Sub SetTreeNodeAndChildrenStateRecursively(ByVal objTreeNode As DirNode, ByVal eCheckBoxState As CheckState)
        Dim objChildTreeNode As DirNode
        If Not (objTreeNode Is Nothing) Then
            SetTreeNodeState(objTreeNode, eCheckBoxState)
            For Each objChildTreeNode In objTreeNode.Nodes
                SetTreeNodeAndChildrenStateRecursively(objChildTreeNode, eCheckBoxState)
            Next
        End If
    End Sub

    Private Sub SetParentTreeNodeStateRecursively(ByVal objParentTreeNode As DirNode)
        Dim objTreeNode As TreeNode
        Dim eCheckBoxState As CheckState
        Dim bAllChildrenChecked As Boolean = True
        Dim bAllChildrenUnchecked As Boolean = True

        If Not (objParentTreeNode Is Nothing) Then

            For Each objTreeNode In objParentTreeNode.Nodes

                eCheckBoxState = GetTreeNodeState(objTreeNode)

                Select Case eCheckBoxState
                    Case CheckState.Checked
                        bAllChildrenUnchecked = False
                    Case CheckState.Indeterminate
                        bAllChildrenUnchecked = False
                        bAllChildrenChecked = False
                    Case CheckState.Unchecked
                        bAllChildrenChecked = False
                End Select

                If bAllChildrenChecked = False And bAllChildrenUnchecked = False Then
                    ' This is an optimization
                    Exit For
                End If

            Next

            If bAllChildrenChecked Then
                SetTreeNodeState(objParentTreeNode, CheckState.Checked)
            ElseIf bAllChildrenUnchecked Then
                SetTreeNodeState(objParentTreeNode, CheckState.Unchecked)
            Else
                SetTreeNodeState(objParentTreeNode, CheckState.Indeterminate)
            End If

            ' Enter in recursion
            If Not (objParentTreeNode.Parent Is Nothing) Then
                SetParentTreeNodeStateRecursively(CType(objParentTreeNode.Parent, DirNode))
            End If

        End If

    End Sub

    Friend Function GetTreeNodeState(ByVal objTreeNode As TreeNode) As CheckState
        Dim eCheckBoxState As CheckState
        Dim tTVITEM As TVITEM
        Dim iState As Integer
        Dim iResult As IntPtr

        tTVITEM.mask = TVIF_HANDLE Or TVIF_STATE
        tTVITEM.hItem = objTreeNode.Handle
        tTVITEM.stateMask = TVIS_STATEIMAGEMASK
        tTVITEM.state = 0

        iResult = SendMessage(Me.Handle, TVM_GETITEM, IntPtr.Zero, tTVITEM)

        If iResult <> IntPtr.Zero Then
            iState = CInt(tTVITEM.state)

            ' State image index in bits 12..15
            iState = iState \ &HFFF

            Select Case iState
                Case m_IMG_CHECKBOX_UNCHECKED
                    eCheckBoxState = CheckState.Unchecked
                Case m_IMG_CHECKBOX_CHECKED
                    eCheckBoxState = CheckState.Checked
                Case m_IMG_CHECKBOX_INDETERMINATE
                    eCheckBoxState = CheckState.Indeterminate
            End Select
        End If

        Return eCheckBoxState
    End Function

    Friend Sub SetTreeNodeState(ByVal objTreeNode As DirNode, ByVal eCheckBoxState As CheckState)
        Dim iImageIndex As Integer
        Dim tTVITEM As TVITEM
        Dim iResult As IntPtr

        If Not (objTreeNode Is Nothing) Then

            objTreeNode.CheckState = eCheckBoxState
            Select Case eCheckBoxState
                Case CheckState.Unchecked
                    iImageIndex = m_IMG_CHECKBOX_UNCHECKED
                Case CheckState.Checked
                    iImageIndex = m_IMG_CHECKBOX_CHECKED
                Case CheckState.Indeterminate
                    iImageIndex = m_IMG_CHECKBOX_INDETERMINATE
            End Select

            tTVITEM.mask = TVIF_HANDLE Or TVIF_STATE
            tTVITEM.hItem = objTreeNode.Handle
            tTVITEM.stateMask = TVIS_STATEIMAGEMASK
            ' State image index in bits 12..15
            tTVITEM.state = CUInt(iImageIndex * &H1000)
            iResult = SendMessage(Me.Handle, TVM_SETITEM, IntPtr.Zero, tTVITEM)
        End If
    End Sub

    Private Sub ToggleTreeNodeState(ByVal objTreeNode As DirNode)
        Dim eCheckBoxState As CheckState
        eCheckBoxState = GetTreeNodeState(objTreeNode)
        Me.BeginUpdate()
        Select Case eCheckBoxState
            Case CheckState.Unchecked
                SetTreeNodeAndChildrenStateRecursively(objTreeNode, CheckState.Checked)
                SetParentTreeNodeStateRecursively(CType(objTreeNode.Parent, DirNode))
            Case CheckState.Checked, CheckState.Indeterminate
                SetTreeNodeAndChildrenStateRecursively(objTreeNode, CheckState.Unchecked)
                SetParentTreeNodeStateRecursively(CType(objTreeNode.Parent, DirNode))
        End Select
        Me.EndUpdate()
    End Sub

    Private Function GetTreeNodeHitAtCheckBoxByScreenPosition(ByVal iXScreenPos As Integer, ByVal iYScreenPos As Integer) As TreeNode
        Dim objClientPoint As Point
        Dim objTreeNode As TreeNode
        objClientPoint = Me.PointToClient(New Point(iXScreenPos, iYScreenPos))
        objTreeNode = GetTreeNodeHitAtCheckBoxByClientPosition(objClientPoint.X, objClientPoint.Y)
        Return objTreeNode
    End Function

    Private Function GetTreeNodeHitAtCheckBoxByClientPosition(ByVal iXClientPos As Integer, ByVal iYClientPos As Integer) As TreeNode
        Dim objTreeNode As TreeNode = Nothing
        Dim iTreeNodeHandle As IntPtr
        Dim tTVHITTESTINFO As TVHITTESTINFO

        ' Get the hit info
        tTVHITTESTINFO.pt.x = iXClientPos
        tTVHITTESTINFO.pt.y = iYClientPos
        iTreeNodeHandle = SendMessage(Me.Handle, TVM_HITTEST, IntPtr.Zero, tTVHITTESTINFO)

        ' Check if it has clicked on an item
        If iTreeNodeHandle <> IntPtr.Zero Then
            ' Check if it has clicked on the state image of the item
            If (tTVHITTESTINFO.flags And TVHT_ONITEMSTATEICON) <> 0 Then
                objTreeNode = TreeNode.FromHandle(Me, iTreeNodeHandle)
            End If
        End If

        Return objTreeNode
    End Function

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim objTreeNode As DirNode
        MyBase.OnMouseUp(e)
        objTreeNode = CType(GetTreeNodeHitAtCheckBoxByClientPosition(e.X, e.Y), DirNode)
        If Not (objTreeNode Is Nothing) Then
            ToggleTreeNodeState(objTreeNode)
        End If
        RaiseEvent NodeClicked()
    End Sub

    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyUp(e)
        If e.KeyCode = Keys.Space Then
            If Not (Me.SelectedNode Is Nothing) Then
                ToggleTreeNodeState(CType(Me.SelectedNode, DirNode))
            End If
        End If
    End Sub

    Protected Overrides Sub OnBeforeExpand(ByVal e As System.Windows.Forms.TreeViewCancelEventArgs)
        ' PATCH: if the node is being expanded by a double click at the state image, cancel it
        If Not (GetTreeNodeHitAtCheckBoxByScreenPosition(Control.MousePosition.X, Control.MousePosition.Y) Is Nothing) Then
            e.Cancel = True
        End If

        Dim dirN As DirNode = CType(e.Node, DirNode)
        Me.BeginUpdate()

        ' Enumerate list of sub dirs if necessary
        If dirN.AlreadyExpanded = False Then
            dirN.AlreadyExpanded = True
            Try
                ' Remove the fake subdir of the dir
                dirN.Nodes.Clear()

                ' Add real subdirs
                For Each d As String In IO.Directory.GetDirectories(dirN.FullPath)
                    Dim pDir As String = GetParentDir(d)
                    Dim n As New DirNode(pDir, _
                                         IMG_INDEX_FOLDER, _
                                         IMG_INDEX_FOLDER)

                    Try
                        ' Add a a fake subdir if there actually ARE real subdirs
                        If IO.Directory.GetDirectories(dirN.FullPath & "\" & pDir).Length > 0 Then
                            n.Nodes.Add(New DirNode(".."))
                        End If
                    Catch ex As Exception
                        '
                    End Try
                    n.AlreadyExpanded = False
                    dirN.Nodes.Add(n)
                    Me.SetTreeNodeState(n, dirN.CheckState)
                Next
            Catch ex As Exception
                ' Drive could not be accessed...
                ' Only remove the fake subdir
                dirN.Nodes.Clear()
            End Try
        End If

        Me.EndUpdate()
    End Sub

    Protected Overrides Sub OnBeforeCollapse(ByVal e As System.Windows.Forms.TreeViewCancelEventArgs)
        ' PATCH: if the node is being collapsed by a double click at the state image, cancel it
        If Not (GetTreeNodeHitAtCheckBoxByScreenPosition(Control.MousePosition.X, Control.MousePosition.Y) Is Nothing) Then
            e.Cancel = True
        End If
    End Sub

    'Friend Function AddTreeNode(ByVal colNodes As TreeNodeCollection, ByVal sNodeText As String, ByVal iImageIndex As Integer, ByVal eCheckBoxState As System.Windows.Forms.CheckState) As TreeNode
    '    Dim objTreeNode As TreeNode
    '    objTreeNode = New TreeNode(sNodeText)
    '    objTreeNode.ImageIndex = iImageIndex
    '    objTreeNode.SelectedImageIndex = iImageIndex
    '    colNodes.Add(objTreeNode)
    '    Me.SetTreeNodeState(objTreeNode, eCheckBoxState)
    '    Return objTreeNode
    'End Function


    ' Refresh the list of drives
    Public Sub RefreshDriveList()
        Me.BeginUpdate()
        For Each dr As IO.DriveInfo In IO.DriveInfo.GetDrives
            If Me.Nodes.ContainsKey(dr.RootDirectory.FullName) = False Then
                Dim n As New DirNode(dr.RootDirectory.FullName, _
                                     IMG_INDEX_DRIVE, _
                                     IMG_INDEX_DRIVE)
                Try
                    ' Add a a fake subdir if there actually ARE real subdirs
                    If IO.Directory.GetDirectories(dr.RootDirectory.FullName).Length > 0 Then
                        n.Nodes.Add(New DirNode(".."))
                    End If
                Catch ex As Exception
                    ' D'oh !
                End Try
                Me.Nodes.Add(n)
            End If
        Next
        Me.EndUpdate()
    End Sub

    ' Recupere la liste de tous les dossiers selectionnes
    Public Function GetDirectories() As List(Of DirNode)
        Dim tmp As New List(Of DirNode)
        For Each n As DirNode In Me.Nodes
            If n.CheckState = CheckState.Indeterminate Then
                ' At least one sub dir is selected
                recAddSelectedNodes(n, tmp)
            ElseIf n.CheckState = CheckState.Checked Then
                ' All sub dir are selected, so we add the dir to the list
                tmp.Add(n)
            End If
        Next
        Return tmp
    End Function
    Private Sub recAddSelectedNodes(ByVal n As TreeNode, ByRef list As List(Of DirNode))
        For Each n2 As DirNode In n.Nodes
            If n2.CheckState = CheckState.Indeterminate Then
                ' At least one sub dir is selected
                recAddSelectedNodes(n2, list)
            ElseIf n2.CheckState = CheckState.Checked Then
                ' All sub dir are selected, so we add the dir to the list
                list.Add(n2)
            End If
        Next
    End Sub

    ' Return the parent dir
    ' Get parent dir
    Private Shared Function GetParentDir(ByVal path As String) As String
        Dim i As Integer = InStrRev(path, "\", , CompareMethod.Binary)
        If i > 0 Then
            Return path.Substring(i, path.Length - i)
        Else
            Return path
        End If
    End Function

End Class
