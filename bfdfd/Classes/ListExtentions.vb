Imports System.Linq
Imports System.Runtime.CompilerServices

Module ListExtensions

    <Extension()>
    Public Function ChunkBy(Of T)(source As IEnumerable(Of T), chunkSize As Integer) As IEnumerable(Of IEnumerable(Of T))
        Return source _
            .Select(Function(x, i) New With {.Index = i, .Value = x}) _
            .GroupBy(Function(x) x.Index \ chunkSize) _
            .Select(Function(x) x.Select(Function(v) v.Value))
    End Function


End Module