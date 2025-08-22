Public Class ListViewItemData
    Public Property Id As Integer
    Public Property FileName As String
    Public Property FileType As String
    Public Property FileSizeBytes As Long
    Public Property CreatedDate As DateTime
    Public Property ModifiedDate As DateTime
    Public Property Group As Integer
    Public Property Checked As Boolean

    Public Sub New(id As Integer, fileName As String, fileType As String, fileSizeBytes As Long, createdDate As DateTime, modifiedDate As DateTime, group As Integer, checked As Boolean)
        Me.Id = id
        Me.FileName = fileName
        Me.FileType = fileType
        Me.FileSizeBytes = fileSizeBytes
        Me.CreatedDate = createdDate
        Me.ModifiedDate = modifiedDate
        Me.Group = group
        Me.Checked = checked
    End Sub

    Public Function GetFormattedSize() As String
        If FileSizeBytes < 1024 Then
            Return $"{FileSizeBytes} B"
        ElseIf FileSizeBytes < 1048576 Then
            Return $"{FileSizeBytes / 1024:F2} KB"
        ElseIf FileSizeBytes < (1048576 * 1024) Then
            Return $"{FileSizeBytes / (1048576):F2} MB"
        Else
            Return $"{FileSizeBytes / (1048576 * 1024):F2} GB"
        End If
    End Function

    Public Function GetFormattedDate() As String
        Return CreatedDate.ToString("MM/dd/yyyy HH:mm")
    End Function

End Class