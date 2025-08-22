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


Public Class cError
        Inherits Exception


        ' ========================================
        ' Private constants
        ' ========================================


        ' ========================================
        ' Private attributes
        ' ========================================

        ' Custom message
        Private _customMessage As String


        ' ========================================
        ' Public properties
        ' ========================================

        ' Custom message
        Public ReadOnly Property CustomMessage() As String
            Get
                Return _customMessage
            End Get
        End Property


        ' ========================================
        ' Other public
        ' ========================================
        <Serializable()>
        Public Class SerializableException
            Public Sub New(ByVal ex As cError)

            End Sub
        End Class

        ' ========================================
        ' Public functions
        ' ========================================

        ' Constructor
        Public Sub New(ByVal message As String, ByVal exception As Exception)
            MyBase.New(exception.Message, exception)
            _customMessage = message
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(message)
            _customMessage = Nothing
        End Sub

        ' Show message
        Public Sub ShowMessage(Optional ByVal forceClassical As Boolean = False)
            ' The we have to display our error as a message box
            Misc.ShowMsg("An handled error occured",
                CustomMessage,
                "Detailed information : " & Message,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Sub


        ' ========================================
        ' Private functions
        ' ========================================


    End Class

