' =======================================================
' Big Fast Duplicate File Deleter! (BFDFD)
' Copyright (c) 2025 Zhi Wong
' https://github.com/spam0115/BFDFD
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

Imports System.Runtime.InteropServices
Imports Native.Api.NativeEnums

Namespace Native.Api

    Public Class NativeStructs

#Region "Declarations used for files"

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure ShellExecuteInfo
            Public cbSize As Integer
            Public fMask As ShellExecuteInfoMask
            Public hwnd As IntPtr
            <MarshalAs(UnmanagedType.LPTStr)> Public lpVerb As String
            <MarshalAs(UnmanagedType.LPTStr)> Public lpFile As String
            <MarshalAs(UnmanagedType.LPTStr)> Public lpParameters As String
            <MarshalAs(UnmanagedType.LPTStr)> Public lpDirectory As String
            Dim nShow As ShowWindowType
            Dim hInstApp As IntPtr
            Dim lpIDList As IntPtr
            <MarshalAs(UnmanagedType.LPTStr)> Public lpClass As String
            Public hkeyClass As IntPtr
            Public dwHotKey As Integer
            Public hIcon As IntPtr
            Public hProcess As IntPtr
        End Structure

        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
        Public Structure SHFILEOPSTRUCT
            Public hwnd As IntPtr
            Public wFunc As FO_Func
            Public pFrom As IntPtr
            Public pTo As IntPtr
            Public fFlags As FILEOP_FLAGS_ENUM
            Public fAnyOperationsAborted As Int32
            Public hNameMappings As IntPtr
            <MarshalAs(UnmanagedType.LPWStr)> _
            Public lpszProgressTitle As [String]
        End Structure

#End Region

    End Class

End Namespace
