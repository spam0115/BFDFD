Imports System
Imports System.Collections.Concurrent
Imports System.Threading

''' <summary>
''' A thread-safe object pool implementation for .NET Framework 4.8
''' </summary>
''' <typeparam name="T">The type of objects to pool</typeparam>
Public Class ObjectPool(Of T As Class)
    Private ReadOnly _objects As ConcurrentQueue(Of T)
    Private ReadOnly _objectFactory As Func(Of T)
    Private ReadOnly _resetAction As Action(Of T)
    Private ReadOnly _maxSize As Integer
    Private _currentCount As Integer

    ''' <summary>
    ''' Initializes a new instance of the ObjectPool class
    ''' </summary>
    ''' <param name="objectFactory">Factory function to create new objects</param>
    ''' <param name="resetAction">Optional action to reset objects before returning to pool</param>
    ''' <param name="maxSize">Maximum number of objects to keep in the pool (default: 100)</param>
    Public Sub New(objectFactory As Func(Of T), Optional resetAction As Action(Of T) = Nothing, Optional maxSize As Integer = 100)
        If objectFactory Is Nothing Then
            Throw New ArgumentNullException(NameOf(objectFactory))
        End If

        _objectFactory = objectFactory
        _resetAction = resetAction
        _maxSize = maxSize
        _objects = New ConcurrentQueue(Of T)()
        _currentCount = 0
    End Sub

    ''' <summary>
    ''' Gets an object from the pool or creates a new one if the pool is empty
    ''' </summary>
    ''' <returns>An object of type T</returns>
    Public Function [Get]() As T
        Dim obj As T = Nothing

        If _objects.TryDequeue(obj) Then
            Interlocked.Decrement(_currentCount)
            Return obj
        End If

        ' Pool is empty, create a new object
        Return _objectFactory()
    End Function

    ''' <summary>
    ''' Returns an object to the pool
    ''' </summary>
    ''' <param name="obj">The object to return to the pool</param>
    Public Sub [Return](obj As T)
        If obj Is Nothing Then
            Return
        End If

        ' Reset the object if a reset action is provided
        If _resetAction IsNot Nothing Then
            Try
                _resetAction(obj)
            Catch
                ' If reset fails, don't return the object to the pool
                Return
            End Try
        End If

        ' Only add to pool if we haven't exceeded the maximum size
        If _currentCount < _maxSize Then
            _objects.Enqueue(obj)
            Interlocked.Increment(_currentCount)
        End If
        ' If pool is full, let the object be garbage collected
    End Sub

    ''' <summary>
    ''' Gets the current number of objects in the pool
    ''' </summary>
    Public ReadOnly Property Count As Integer
        Get
            Return _currentCount
        End Get
    End Property

    ''' <summary>
    ''' Gets the maximum size of the pool
    ''' </summary>
    Public ReadOnly Property MaxSize As Integer
        Get
            Return _maxSize
        End Get
    End Property

    ''' <summary>
    ''' Clears all objects from the pool
    ''' </summary>
    Public Sub Clear()
        Dim obj As T = Nothing
        While _objects.TryDequeue(obj)
            ' Objects will be garbage collected
        End While
        _currentCount = 0
    End Sub
End Class

''' <summary>
''' Example usage and helper class for StringBuilder pooling
''' </summary>
Public Class StringBuilderPool
    Private Shared ReadOnly _pool As New ObjectPool(Of System.Text.StringBuilder)(
        Function() New System.Text.StringBuilder(),
        Sub(sb) sb.Clear(),
        50
    )

    Public Shared Function [Get]() As System.Text.StringBuilder
        Return _pool.Get()
    End Function

    Public Shared Sub [Return](sb As System.Text.StringBuilder)
        _pool.Return(sb)
    End Sub
End Class