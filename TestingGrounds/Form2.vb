Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Linq
Imports BrightIdeasSoftware
Imports ClassLibrary1

Public Class Form2
    Private _FileList As List(Of cSimpleFile)
    Private _size As Integer = 1000000

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure the columns to bind to your data properties
        ConfigureColumns()


        ' Add event handlers for checkbox changes
        AddHandler vlvFiles.ItemChecked, AddressOf VirtualObjectListView1_ItemChecked
    End Sub

    Private Sub ConfigureColumns()
        ' Configure each column to display the appropriate data
        OlvColumn0.AspectName = "_GroupId"
        OlvColumn0.Text = "Group"
        OlvColumn0.Width = 70

        OlvColumn1.AspectName = "_Path"
        OlvColumn1.Text = "File"
        OlvColumn1.Width = 200

        OlvColumn2.AspectName = "_FileType"
        OlvColumn2.Text = "Type"
        OlvColumn2.Width = 100

        ' Use the formatted size method for better display
        OlvColumn3.AspectName = "_Size"
        OlvColumn3.Text = "Size"
        OlvColumn3.Width = 100

        ' Use the formatted date method for better display
        OlvColumn4.AspectGetter = Function(x As Object) If(x Is Nothing, "MM/dd/yyyy HH:mm", DirectCast(x, cSimpleFile).CreatedDate())
        OlvColumn4.Text = "Created Date"
        OlvColumn4.Width = 150

        ' Use the formatted date method for better display
        OlvColumn5.AspectGetter = Function(x As Object) If(x Is Nothing, "MM/dd/yyyy HH:mm", DirectCast(x, cSimpleFile).ModifiedDate())
        OLVColumn5.Text = "Modified Date"
        OlvColumn5.Width = 150


        ' Configure checkbox handling
        vlvFiles.CheckedAspectName = "_Checked"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        _size = Integer.Parse(ItemQuantity.Text)
        PopulateFileList(_size)
        ' Refresh the virtual list after populating data
        vlvFiles.VirtualListSize = _FileList.Count
        vlvFiles.Invalidate()
        Label1.Text = $"Loaded {_FileList.Count} items"
    End Sub

    Private Sub VirtualObjectListView1_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles vlvFiles.ItemChecked
        ' Update the underlying data when checkbox state changes
        Dim item As ListViewItem = e.Item
        If item.Tag IsNot Nothing AndAlso TypeOf item.Tag Is cSimpleFile Then
            Dim data As cSimpleFile = DirectCast(item.Tag, cSimpleFile)
            data._Checked = item.Checked
        End If
    End Sub

    Private Sub PopulateFileList(count As Integer)

        ' Generate persistent data collection
        _FileList = New List(Of cSimpleFile)(count)

        Dim rnd As New Random()
        Dim fileTypes() As String = {"Text", "Image", "Video", "Audio", "Document", "Spreadsheet", "Presentation"}

        For i As Integer = 0 To count - 1
            Dim id = i
            Dim fileName As String = $"file_{rnd.Next(0, 99999999)}.txt"
            Dim fileType As String = fileTypes(rnd.Next(fileTypes.Length))
            Dim fileSizeBytes As Long = CLng(rnd.NextDouble() * 10 * 1024 * 1024 * 1024) + 1
            Dim createdDate As DateTime = DateTime.Now.AddDays(-rnd.Next(0, 3650)).AddSeconds(-rnd.Next(0, 86400))
            Dim modifiedDate As DateTime = createdDate.AddDays(-rnd.Next(0, 3650))
            Dim group As Integer = rnd.Next(1, count / 10)
            Dim checked As Boolean = rnd.Next(0, 1) = 1

            _FileList.Add(New cSimpleFile(i, fileName, fileType, fileSizeBytes, createdDate, modifiedDate, group, checked))
        Next

        ' Set up the VirtualObjectListView data source
        vlvFiles.VirtualListDataSource = New FileListDataSource(_FileList)

    End Sub

    ' Property to expose the file list to the data source
    Public ReadOnly Property FileList As List(Of cSimpleFile)
        Get
            Return _FileList
        End Get
    End Property

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        vlvFiles.Refresh()
    End Sub
End Class
