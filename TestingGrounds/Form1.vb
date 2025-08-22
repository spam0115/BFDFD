Imports System.Data.Linq

Public Class Form1

    Private _FileList As List(Of ListViewItemData)
    Private _listViewItemsCache As New Dictionary(Of Integer, ListViewItem)
    Private lastCacheStart As Integer = -1
    Private lastCacheEnd As Integer = -1
    Private sortedIndices As Integer()
    Private sortColumn As Integer = -1
    Private sortOrder As SortOrder = SortOrder.None

    Public Sub New()
        InitializeComponent()
        ' Enable virtual mode
        ListView2.VirtualMode = True
        ListView2.VirtualListSize = 0
        ListView2.StateImageList = Nothing
        ListView2.OwnerDraw = False

        ItemQuantity.SelectedIndex = 4
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim numItems As Integer
        If Integer.TryParse(ItemQuantity.Text, numItems) AndAlso numItems > 0 Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim sw = Stopwatch.StartNew()
                PopulateListView1(numItems)
                sw.Stop()
                Label2.Text = $"Form1 - Time: {sw.ElapsedMilliseconds} ms"
            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            MessageBox.Show("Please enter a valid positive number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub PopulateListView1(count As Integer)
        ListView1.BeginUpdate()
        ListView1.Items.Clear()
        ListView1.Sorting = SortOrder.None
        Dim sorter = ListView1.ListViewItemSorter
        ListView1.ListViewItemSorter = Nothing

        Dim rnd As New Random()
        Dim fileTypes() As String = {"Text", "Image", "Video", "Audio", "Document", "Spreadsheet", "Presentation"}
        Dim groups() As String = {"Group A", "Group B", "Group C", "Group D", "Group E"}

        For i As Integer = 1 To count
            Dim fileName As String = $"file_{rnd.Next(10000, 99999)}.txt"
            Dim fileType As String = fileTypes(rnd.Next(fileTypes.Length))

            ' Generate file size between 1KB and 100MB
            Dim fileSizeKB As Long = CLng(rnd.NextDouble() * 102400) + 1
            Dim sizeText As String = If(fileSizeKB < 1024,
                $"{fileSizeKB} KB",
                $"{fileSizeKB / 1024:F2} MB")

            ' Generate random date within last 10 years
            Dim createdDate As DateTime = DateTime.Now.AddDays(-rnd.Next(0, 3650))
            Dim dateText As String = createdDate.ToString("MM/dd/yyyy HH:mm")

            Dim groupText As String = groups(rnd.Next(groups.Length))

            Dim lvi As New ListViewItem()
            'lvi.SubItems.Add(False)
            lvi.SubItems.Add(fileName)
            lvi.SubItems.Add(fileType)
            lvi.SubItems.Add(sizeText)
            lvi.SubItems.Add(dateText)
            lvi.SubItems.Add(groupText)
            lvi.Checked = False

            ListView1.Items.Add(lvi)
        Next

        ListView1.ListViewItemSorter = sorter
        ListView1.EndUpdate()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ItemQuantity.SelectedIndex = -1 Then
            MessageBox.Show("Please select a quantity first", "Selection Required",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim numItems As Integer
        If Integer.TryParse(ItemQuantity.Text, numItems) AndAlso numItems > 0 Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim sw = Stopwatch.StartNew()
                PopulateListView2(numItems)
                sw.Stop()
                Me.Label2.Text = $"Form1 - Time: {sw.ElapsedMilliseconds} ms"
            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            MessageBox.Show("Please enter a valid positive number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub PopulateListView2(count As Integer)
        ' Generate persistent data collection
        _FileList = New List(Of ListViewItemData)(count)

        Dim rnd As New Random()
        Dim fileTypes() As String = {"Text", "Image", "Video", "Audio", "Document", "Spreadsheet", "Presentation"}
        Dim groups() As String = {"Group A", "Group B", "Group C", "Group D", "Group E"}

        For i As Integer = 0 To count - 1
            Dim fileName As String = $"file_{rnd.Next(0, 99999999)}.txt"
            Dim fileType As String = fileTypes(rnd.Next(fileTypes.Length))
            Dim fileSizeBytes As Long = CLng(rnd.NextDouble() * 100 * 1024 * 1024) + 1 ' 1 byte to 100 MB
            Dim createdDate As DateTime = DateTime.Now.AddDays(-rnd.Next(0, 3650))
            Dim modifiedDate As DateTime = createdDate.AddDays(-rnd.Next(0, 3650))
            Dim group As Integer = groups(rnd.Next(1, count / 10))

            _FileList.Add(New ListViewItemData(i, fileName, fileType, fileSizeBytes, createdDate, modifiedDate, group, False))
        Next

        ' Initialize sorted indices
        sortedIndices = Enumerable.Range(0, count).ToArray()

        ' Reset cache
        _listViewItemsCache.Clear()
        lastCacheStart = -1
        lastCacheEnd = -1

        ' Configure virtual list
        ListView2.BeginUpdate()
        ListView2.VirtualListSize = count
        ListView2.EndUpdate()
    End Sub

    Private Sub ListView2_RetrieveVirtualItem(sender As Object, e As RetrieveVirtualItemEventArgs) Handles ListView2.RetrieveVirtualItem
        Dim dataIndex = sortedIndices(e.ItemIndex)

        If _listViewItemsCache.ContainsKey(dataIndex) Then
            e.Item = _listViewItemsCache(dataIndex)
        Else
            e.Item = CreateListViewItemFromData(_FileList(dataIndex))
        End If
    End Sub

    Private Sub ListView2_CacheVirtualItems(sender As Object, e As CacheVirtualItemsEventArgs) Handles ListView2.CacheVirtualItems
        If lastCacheStart >= e.StartIndex AndAlso lastCacheEnd <= e.EndIndex Then
            Return
        End If

        lastCacheStart = e.StartIndex
        lastCacheEnd = e.EndIndex
        'randomCache.Clear() 'why do this?  A cache with little data is of little use

        For i As Integer = e.StartIndex To e.EndIndex
            Dim dataIndex = sortedIndices(i)
            _listViewItemsCache(dataIndex) = CreateListViewItemFromData(_FileList(dataIndex))
        Next
    End Sub

    Private Function CreateListViewItemFromData(data As ListViewItemData) As ListViewItem
        Dim lvi As New ListViewItem(data.FileName)
        'lvi.SubItems.Add(False)
        'lvi.SubItems.Add(data.FileName)
        lvi.SubItems.Add(data.FileType)
        lvi.SubItems.Add(data.GetFormattedSize())
        lvi.SubItems.Add(data.GetFormattedDate())
        lvi.SubItems.Add(data.Group)
        lvi.Checked = data.Checked
        Return lvi
    End Function

    Private Sub ListView2_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles ListView2.ItemCheck
        Dim dataIndex = sortedIndices(e.Index)
        _FileList(dataIndex).Checked = (e.NewValue = CheckState.Checked)

        If _listViewItemsCache.ContainsKey(dataIndex) Then
            _listViewItemsCache(dataIndex).Checked = _FileList(dataIndex).Checked
        End If
    End Sub

    Private Sub ListView2_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView2.ColumnClick
        Dim lv = CType(sender, ListView)

        If e.Column = sortColumn Then
            sortOrder = If(sortOrder = SortOrder.Ascending, SortOrder.Descending, SortOrder.Ascending)
        Else
            sortColumn = e.Column
            sortOrder = SortOrder.Ascending
        End If

        ' Sort the indices array
        Array.Sort(sortedIndices, Function(i1, i2) CompareItems(i1, i2))

        ' Refresh the list
        lv.BeginUpdate()
        _listViewItemsCache.Clear()
        lastCacheStart = -1
        lastCacheEnd = -1
        lv.Invalidate()
        lv.EndUpdate()
    End Sub



    Private Function CompareItems(index1 As Integer, index2 As Integer) As Integer
        Dim orderMultiplier = If(sortOrder = SortOrder.Ascending, 1, -1)
        Dim item1 = _FileList(index1)
        Dim item2 = _FileList(index2)

        Select Case sortColumn
            Case 0 ' File
                Return orderMultiplier * String.Compare(item1.FileName, item2.FileName, StringComparison.OrdinalIgnoreCase)
            Case 1 ' Type
                Return orderMultiplier * String.Compare(item1.FileType, item2.FileType, StringComparison.OrdinalIgnoreCase)
            Case 2 ' Size
                Return orderMultiplier * item1.FileSizeBytes.CompareTo(item2.FileSizeBytes)
            Case 3 ' Created Date
                Return orderMultiplier * item1.CreatedDate.CompareTo(item2.CreatedDate)
            Case 4 ' Group
                Return orderMultiplier * item1.Group.CompareTo(item2.Group)
            Case Else
                Return 0
        End Select
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form2.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ItemQuantity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemQuantity.SelectedIndexChanged

    End Sub
End Class
