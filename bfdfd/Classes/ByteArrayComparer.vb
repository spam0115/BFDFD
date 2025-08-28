Imports System.Collections.Generic

Public NotInheritable Class ByteArrayComparer
    Implements IEqualityComparer(Of Byte())

    Public Overloads Function Equals(x As Byte(), y As Byte()) As Boolean _
        Implements IEqualityComparer(Of Byte()).Equals

        If ReferenceEquals(x, y) Then Return True
        If x Is Nothing OrElse y Is Nothing Then Return False
        If x.Length <> y.Length Then Return False
        For i = 0 To x.Length - 1
            If x(i) <> y(i) Then Return False
        Next
        Return True
    End Function

    Public Overloads Function GetHashCode(obj As Byte()) As Integer _
        Implements IEqualityComparer(Of Byte()).GetHashCode

        If obj Is Nothing Then Return 0
        Dim hash As Integer = 17
        For Each b In obj
            hash = (hash * 31) Xor b
        Next
        Return hash
    End Function
End Class