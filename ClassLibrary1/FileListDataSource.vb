' Data source class that implements IVirtualListDataSource
Imports BrightIdeasSoftware
Imports System.Windows.Forms

Public Class FileListDataSource
    Implements IVirtualListDataSource

    Private _dataList As List(Of cSimpleFile)

    Public Sub New(data As List(Of cSimpleFile))
        _dataList = data
    End Sub

    Public Function GetNthObject(n As Integer) As Object Implements BrightIdeasSoftware.IVirtualListDataSource.GetNthObject
        If _dataList IsNot Nothing AndAlso n >= 0 AndAlso n < _dataList.Count Then
            Return _dataList(n)
        End If
        Return Nothing
    End Function

    Public Function GetObjectCount() As Integer Implements BrightIdeasSoftware.IVirtualListDataSource.GetObjectCount
        If _dataList IsNot Nothing Then
            Return _dataList.Count
        End If
        Return 0
    End Function

    Public Function GetObjectIndex(model As Object) As Integer Implements BrightIdeasSoftware.IVirtualListDataSource.GetObjectIndex
        If _dataList IsNot Nothing AndAlso TypeOf model Is cSimpleFile Then
            Return _dataList.IndexOf(DirectCast(model, cSimpleFile))
        End If
        Return -1
    End Function

    Public Sub PrepareCache(first As Integer, last As Integer) Implements BrightIdeasSoftware.IVirtualListDataSource.PrepareCache
        ' No caching needed for this simple example
    End Sub

    Public Function SearchText(value As String, first As Integer, last As Integer, column As BrightIdeasSoftware.OLVColumn) As Integer Implements BrightIdeasSoftware.IVirtualListDataSource.SearchText
        ' Simple search implementation
        If _dataList IsNot Nothing Then
            For i As Integer = first To Math.Min(last, _dataList.Count - 1)
                Dim item = _dataList(i)
                If item.Path.ToLower().Contains(value.ToLower()) Then
                    Return i
                End If
            Next
        End If
        Return -1
    End Function

    Public Sub Sort(column As BrightIdeasSoftware.OLVColumn, order As SortOrder) Implements IVirtualListDataSource.Sort
        If _dataList IsNot Nothing Then
            Select Case column.AspectName
                Case "_Path"
                    If order = SortOrder.Ascending Then
                        _dataList.Sort(Function(x, y) String.Compare(x._Path, y._Path))
                    Else
                        _dataList.Sort(Function(x, y) String.Compare(y._Path, x._Path))
                    End If
                Case "_FileType"
                    If order = SortOrder.Ascending Then
                        _dataList.Sort(Function(x, y) String.Compare(x._FileType, y._FileType))
                    Else
                        _dataList.Sort(Function(x, y) String.Compare(y._FileType, x._FileType))
                    End If
                Case "_Size"
                    If order = SortOrder.Ascending Then
                        _dataList.Sort(Function(x, y) x._Size.CompareTo(y._Size))
                    Else
                        _dataList.Sort(Function(x, y) y._Size.CompareTo(x._Size))
                    End If
                Case "_CreatedDate"
                    If order = SortOrder.Ascending Then
                        _dataList.Sort(Function(x, y) x._CreatedDate.CompareTo(y._CreatedDate))
                    Else
                        _dataList.Sort(Function(x, y) y._CreatedDate.CompareTo(x._CreatedDate))
                    End If
                Case "_ModifiedDate"
                    If order = SortOrder.Ascending Then
                        _dataList.Sort(Function(x, y) x._ModifiedDate.CompareTo(y._ModifiedDate))
                    Else
                        _dataList.Sort(Function(x, y) y._ModifiedDate.CompareTo(x._ModifiedDate))
                    End If
                Case "_GroupId"
                    If order = SortOrder.Ascending Then
                        _dataList.Sort(Function(x, y) x._GroupId.CompareTo(y._GroupId))
                    Else
                        _dataList.Sort(Function(x, y) y._GroupId.CompareTo(x._GroupId))
                    End If
            End Select
        End If
    End Sub


    Public Sub AddObjects(modelObjects As ICollection) Implements IVirtualListDataSource.AddObjects
        If _dataList Is Nothing Then
            _dataList = New List(Of cSimpleFile)()
        End If

        If modelObjects IsNot Nothing Then
            For Each obj As Object In modelObjects
                If TypeOf obj Is cSimpleFile Then
                    _dataList.Add(DirectCast(obj, cSimpleFile))
                End If
            Next
        End If
    End Sub

    Public Sub InsertObjects(index As Integer, modelObjects As ICollection) Implements IVirtualListDataSource.InsertObjects
        If _dataList Is Nothing Then
            _dataList = New List(Of cSimpleFile)()
        End If

        If modelObjects IsNot Nothing AndAlso index >= 0 AndAlso index <= _dataList.Count Then
            Dim insertIndex As Integer = index
            For Each obj As Object In modelObjects
                If TypeOf obj Is cSimpleFile Then
                    _dataList.Insert(insertIndex, DirectCast(obj, cSimpleFile))
                    insertIndex += 1
                End If
            Next
        End If
    End Sub

    Public Sub RemoveObjects(modelObjects As ICollection) Implements IVirtualListDataSource.RemoveObjects
        If _dataList IsNot Nothing AndAlso modelObjects IsNot Nothing Then
            For Each obj As Object In modelObjects
                If TypeOf obj Is cSimpleFile Then
                    _dataList.Remove(DirectCast(obj, cSimpleFile))
                End If
            Next
        End If
    End Sub

    Public Sub SetObjects(collection As IEnumerable) Implements IVirtualListDataSource.SetObjects
        If _dataList Is Nothing Then
            _dataList = New List(Of cSimpleFile)()
        Else
            _dataList.Clear()
        End If

        If collection IsNot Nothing Then
            For Each obj As Object In collection
                If TypeOf obj Is cSimpleFile Then
                    _dataList.Add(DirectCast(obj, cSimpleFile))
                End If
            Next
        End If
    End Sub

    Public Sub UpdateObject(index As Integer, modelObject As Object) Implements IVirtualListDataSource.UpdateObject
        If _dataList IsNot Nothing AndAlso index >= 0 AndAlso index < _dataList.Count AndAlso TypeOf modelObject Is cSimpleFile Then
            _dataList(index) = DirectCast(modelObject, cSimpleFile)
        End If
    End Sub
End Class
