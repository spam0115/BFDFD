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

' From http://tom-shelton.net/index.php/2010/01/02/using-extension-methods-and-the-win32-api-to-efficiently-enumerate-the-file-system/

Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Win32.SafeHandles

Public Class NativeWin32

    Public Const MAX_PATH As Integer = 260

    ''' <summary>
    ''' Win32 FILETIME structure.  The win32 documentation says this:
    ''' "Contains a 64-bit value representing the number of 100-nanosecond intervals since January 1, 1601 (UTC)."
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure FILETIME
        Public dwLowDateTime As UInteger
        Public dwHighDateTime As UInteger
    End Structure

    ''' <summary>
    ''' The Win32 find data structure.  The documentation says:
    ''' "Contains information about the file that is found by the FindFirstFile, FindFirstFileEx, or FindNextFile function."
    ''' </summary>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Public Structure WIN32_FIND_DATA
        Public dwFileAttributes As FileAttributes
        Public ftCreationTime As FILETIME
        Public ftLastAccessTime As FILETIME
        Public ftLastWriteTime As FILETIME
        Public nFileSizeHigh As UInteger
        Public nFileSizeLow As UInteger
        Public dwReserved0 As UInteger
        Public dwReserved1 As UInteger

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> _
        Public cFileName As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=14)> _
        Public cAlternateFileName As String

        Public ReadOnly Property Size() As Long
            Get
                Dim ret As Long
                ret = nFileSizeLow
                If nFileSizeLow < 0 Then
                    ret += 4294967296
                End If
                If nFileSizeHigh > 0 Then
                    ret += nFileSizeHigh * 4294967296
                End If
                Return ret
            End Get
        End Property
        Public ReadOnly Property DateC() As Long
            Get
                Dim ret As Long
                ret = ftCreationTime.dwLowDateTime
                If ftCreationTime.dwLowDateTime < 0 Then
                    ret += 4294967296
                End If
                If ftCreationTime.dwHighDateTime > 0 Then
                    ret += ftCreationTime.dwHighDateTime * 4294967296
                End If
                Return ret
            End Get
        End Property
        Public ReadOnly Property DateA() As Long
            Get
                Dim ret As Long
                ret = ftLastAccessTime.dwLowDateTime
                If ftLastAccessTime.dwLowDateTime < 0 Then
                    ret += 4294967296
                End If
                If ftLastAccessTime.dwHighDateTime > 0 Then
                    ret += ftLastAccessTime.dwHighDateTime * 4294967296
                End If
                Return ret
            End Get
        End Property
        Public ReadOnly Property DateW() As Long
            Get
                Dim ret As Long
                ret = ftLastWriteTime.dwLowDateTime
                If ftLastWriteTime.dwLowDateTime < 0 Then
                    ret += 4294967296
                End If
                If ftLastWriteTime.dwHighDateTime > 0 Then
                    ret += ftLastWriteTime.dwHighDateTime * 4294967296
                End If
                Return ret
            End Get
        End Property
    End Structure

    ''' <summary>
    ''' Searches a directory for a file or subdirectory with a name that matches a specific name (or partial name if wildcards are used).
    ''' </summary>
    ''' <param name="lpFileName">The directory or path, and the file name, which can include wildcard characters, for example, an asterisk (*) or a question mark (?). </param>
    ''' <param name="lpFindData">A pointer to the WIN32_FIND_DATA structure that receives information about a found file or directory.</param>
    ''' <returns>
    ''' If the function succeeds, the return value is a search handle used in a subsequent call to FindNextFile or FindClose, and the lpFindFileData parameter contains information about the first file or directory found.
    ''' If the function fails or fails to locate files from the search string in the lpFileName parameter, the return value is INVALID_HANDLE_VALUE and the contents of lpFindFileData are indeterminate.
    '''</returns>
    <DllImport("kernel32", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function FindFirstFile(ByVal lpFileName As String, ByRef lpFindData As WIN32_FIND_DATA) As SafeSearchHandle
    End Function

    ''' <summary>
    ''' Continues a file search from a previous call to the FindFirstFile or FindFirstFileEx function.
    ''' </summary>
    ''' <param name="hFindFile">The search handle returned by a previous call to the FindFirstFile or FindFirstFileEx function.</param>
    ''' <param name="lpFindData">A pointer to the WIN32_FIND_DATA structure that receives information about the found file or subdirectory.
    ''' The structure can be used in subsequent calls to FindNextFile to indicate from which file to continue the search.
    ''' </param>
    ''' <returns>
    ''' If the function succeeds, the return value is nonzero and the lpFindFileData parameter contains information about the next file or directory found.
    ''' If the function fails, the return value is zero and the contents of lpFindFileData are indeterminate.
    ''' </returns>
    <DllImport("kernel32", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Shared Function FindNextFile(ByVal hFindFile As SafeSearchHandle, ByRef lpFindData As WIN32_FIND_DATA) As Boolean
    End Function

    ''' <summary>
    ''' Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, or FindFirstStreamW function.
    ''' </summary>
    ''' <param name="hFindFile">The file search handle.</param>
    ''' <returns>
    ''' If the function succeeds, the return value is nonzero.
    ''' If the function fails, the return value is zero. 
    ''' </returns>
    <DllImport("kernel32", SetLastError:=True)> _
    Public Shared Function FindClose(ByVal hFindFile As IntPtr) As Boolean
    End Function

    ''' <summary>
    ''' Class to encapsulate a seach handle returned from FindFirstFile.  Using a wrapper
    ''' like this ensures that the handle is properly cleaned up with FindClose.
    ''' </summary>
    Public Class SafeSearchHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid
        Public Sub New()
            MyBase.New(True)
        End Sub

        Protected Overloads Overrides Function ReleaseHandle() As Boolean
            Return NativeWin32.FindClose(MyBase.handle)
        End Function
    End Class

End Class
