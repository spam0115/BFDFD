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

Namespace Native.Api

    Public Class NativeConstants

        ' Invalid handle
        Public Shared ReadOnly InvalidHandleValue As New IntPtr(-1)

        ' For OpenProcess()
        Public Const Process_QueryInformation As UInteger = &H400

        ' For OpenProcessToken() & GetTokenInformation
        Public Const Token_Query As UInteger = &H8
        Public Const Token_TokenElevationType As UInteger = &H12

    End Class

End Namespace
