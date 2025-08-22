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

Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Drawing
Imports System.Net
Imports Native.Api.NativeStructs
Imports Native.Api.NativeEnums

Namespace Native.Api

    Public Class NativeFunctions

#Region "Declarations used for processes"

        <DllImport("kernel32.dll", SetLastError:=True)> _
        Public Shared Function GetExitCodeProcess(<[In]()> ByVal ProcessHandle As IntPtr, _
            <Out()> ByRef ExitCode As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("kernel32.dll", SetLastError:=True)> _
        Public Shared Function GetCurrentProcessId() As Integer
        End Function

        <DllImport("advapi32.dll", SetLastError:=True)> _
        Public Shared Function OpenProcessToken(<[In]()> ByVal ProcessHandle As IntPtr, _
                     <[In]()> ByVal DesiredAccess As UInteger, _
                     <Out()> ByRef TokenHandle As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("kernel32.dll", SetLastError:=True)> _
        Public Shared Function OpenProcess(ByVal DesiredAccess As UInteger, _
                                           ByVal InheritHandle As Boolean, _
                                           ByVal ProcessId As Integer) As IntPtr
        End Function

        <DllImport("kernel32.dll", SetLastError:=True)> _
        Public Shared Sub ExitProcess(ByVal ExitCode As Integer)
        End Sub

#End Region

#Region "Declarations used for tokens & privileges"

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
        Public Shared Function GetTokenInformation(ByVal TokenHandle As IntPtr, _
                                                    ByVal TokenInformationClass As UInteger, _
                                                    ByVal TokenInformation As IntPtr, _
                                                    ByVal TokenInformationLength As Integer, _
                                                    ByRef ReturnLength As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

#End Region

#Region "Declarations used for files"

        <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
        Public Shared Function GetShortPathName(ByVal longPath As String, _
              <MarshalAs(UnmanagedType.LPTStr)> ByVal ShortPath As System.Text.StringBuilder, _
              <MarshalAs(Runtime.InteropServices.UnmanagedType.U4)> ByVal bufferSize As Integer) As Integer
        End Function

        <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
        Public Shared Function CreateFile(ByVal lpFileName As String, _
                                ByVal dwDesiredAccess As EFileAccess, _
                                ByVal dwShareMode As EFileShare, _
                                ByVal lpSecurityAttributes As IntPtr, _
                                ByVal dwCreationDisposition As ECreationDisposition, _
                                ByVal dwFlagsAndAttributes As EFileAttributes, _
                                ByVal hTemplateFile As IntPtr) As IntPtr
        End Function

        <DllImport("kernel32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function GetFileSizeEx(<[In]()> ByVal hFile As IntPtr, _
                                    <[In](), Out()> ByRef lpFileSize As Long) As Boolean
        End Function

        <DllImport("Shell32", CharSet:=CharSet.Auto, SetLastError:=True)> _
        Public Shared Function ShellExecuteEx(ByRef lpExecInfo As ShellExecuteInfo) As Boolean
        End Function

        <DllImport("shell32.dll")> _
        Public Shared Function FindExecutable(ByVal lpFile As String, _
                                              ByVal lpDirectory As String, _
                                              ByVal lpResult As StringBuilder) As IntPtr
        End Function

        <DllImport("kernel32.dll")> _
        Public Shared Function GetCompressedFileSize(ByVal lpFileName As String, _
                                                     ByRef lpFileSizeHigh As UInteger) As UInteger
        End Function

        <DllImport("kernel32.dll")> _
        Public Shared Function SetFilePointerEx(ByVal hFile As IntPtr, _
                                                ByVal liDistanceToMove As Long, _
                                                ByRef lpNewFilePointer As Long, _
                                                ByVal dwMoveMethod As EMoveMethod) As Boolean
        End Function

        <DllImport("kernel32.dll")> _
        Public Shared Function ReadFile(ByVal hFile As IntPtr, _
                                        ByVal lpBuffer As Byte(), _
                                        ByVal nNumberOfBytesToRead As UInteger, _
                                        ByRef lpNumberOfBytesRead As UInteger, _
                                        ByVal lpOverlapped As IntPtr) As Boolean

        End Function

        <DllImport("shell32.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function SHFileOperation(ByRef lpFileOp As SHFILEOPSTRUCT) As Integer
        End Function

        <DllImport("shell32.dll")> _
       Public Shared Sub SHChangeNotify( _
                    ByVal wEventID As HChangeNotifyEventID, _
                    ByVal uFlags As HChangeNotifyFlags, _
                    ByVal dwItem1 As IntPtr, _
                    ByVal dwItem2 As IntPtr)
        End Sub

#End Region

#Region "Declarations used for windows"

        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
        Public Shared Function SendMessage(ByVal hWnd As IntPtr, _
                ByVal Msg As Integer, _
                ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        End Function

#End Region

#Region "General declarations"

        <DllImport("msvcrt.dll")> _
        Public Shared Function memcmp(ByVal b1 As Byte(), _
                                      ByVal b2 As Byte(), _
                                      ByVal count As Long) As Integer
        End Function

        <DllImport("kernel32.dll")> _
        Public Shared Function GetTickCount() As Integer
        End Function

        <DllImport("kernel32.dll", SetLastError:=True)> _
        Public Shared Function CloseHandle(<[In]()> ByVal Handle As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

#End Region

#Region "Declarations used for graphical functions"

        <DllImport("uxtheme.dll", CharSet:=CharSet.Unicode, ExactSpelling:=True)> _
        Public Shared Function SetWindowTheme(ByVal hWnd As IntPtr, ByVal appName As String, _
                                              ByVal partList As String) As Integer
        End Function

#End Region

    End Class

End Namespace
