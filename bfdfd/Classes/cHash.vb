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

Option Strict On

Imports System.IO
Imports System.Security.Cryptography

Public Class cHash
    'the CryptoServiceProviders are supposed to be thread safe in .net classic but they cause "Safe handle has been closed" exceptions when actually used in a multithreading situation.
    Private Shared md5Pool As New ObjectPool(Of MD5CryptoServiceProvider)(Function() New MD5CryptoServiceProvider())
    Private Shared sha1Pool As New ObjectPool(Of SHA1CryptoServiceProvider)(Function() New SHA1CryptoServiceProvider())
    Private Const bufferSize As Integer = 81920

    ' Return hash from file path
    Public Shared Function GetMD5Hash4File(ByVal path As String) As Byte()
        Try
            Using f As New IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read, bufferSize)
                Dim _md5 = md5Pool.Get()
                Dim hash = _md5.ComputeHash(f)
                md5Pool.Return(_md5)
                Return hash
            End Using
        Catch ex As DirectoryNotFoundException
            If (ex.Message.Contains("Could not find a part of the path")) Then
                Dim index As Integer = ex.Message.IndexOf("'") + 1
                Dim filePath = ex.Message.Substring(index, ex.Message.Length - index)
                If (filePath.Length - 2 > 255) Then
                    Throw New DirectoryNotFoundException("file path is too long.  It is greater than 255 characters.  Either shorten path or enable 'LongPathsEnabled'.")
                End If
            End If

            Throw ex
        End Try
    End Function

    Public Shared Function GetSHA1Hash4File(ByVal path As String) As Byte()
        Try

            Using f As New IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read, bufferSize)
                Dim _sha1 = sha1Pool.Get()
                Dim hash = _sha1.ComputeHash(f)
                sha1Pool.Return(_sha1)
                Return hash
            End Using
        Catch ex As DirectoryNotFoundException
            If (ex.Message.Contains("Could not find a part of the path")) Then
                Dim index As Integer = ex.Message.IndexOf("'") + 1
                Dim filePath = ex.Message.Substring(index, ex.Message.Length - index)
                If (filePath.Length - 2 > 255) Then
                    Throw New DirectoryNotFoundException("file path is too long.  It is greater than 255 characters.  Either shorten path or enable 'LongPathsEnabled'.")
                End If
            End If

            Throw ex
        End Try
    End Function

End Class
