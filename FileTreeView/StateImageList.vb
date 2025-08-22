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

Public Class StateImageList

    ' The imagelist
    Private _imgList As New ImageList

    Public Property ImageList() As ImageList
        Get
            Return _imgList
        End Get
        Set(ByVal value As ImageList)
            _imgList = value
        End Set
    End Property

    ' Constructor
    Public Sub New()

        Dim vsr As System.Windows.Forms.VisualStyles.VisualStyleRenderer = Nothing

        If System.Windows.Forms.VisualStyles.VisualStyleRenderer.IsSupported = True Then
            vsr = New System.Windows.Forms.VisualStyles.VisualStyleRenderer(System.Windows.Forms.VisualStyles.VisualStyleElement.Button.CheckBox.UncheckedNormal)
        End If

        Dim smallIconSize As New System.Drawing.Rectangle(0, 0, _imgList.ImageSize.Width, _imgList.ImageSize.Height)

        Dim BitmapUnchecked = New System.Drawing.Bitmap(_imgList.ImageSize.Width, _imgList.ImageSize.Height)
        Dim BitmapChecked = New System.Drawing.Bitmap(_imgList.ImageSize.Width, _imgList.ImageSize.Height)
        Dim BitmapIndeterminate = New System.Drawing.Bitmap(_imgList.ImageSize.Width, _imgList.ImageSize.Height)

        Dim GraphicsUnchecked As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(BitmapUnchecked)
        Dim GraphicsChecked As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(BitmapChecked)
        Dim GraphicsIndeterminate As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(BitmapIndeterminate)

        Using (GraphicsUnchecked)
            If (vsr Is Nothing) Then
                System.Windows.Forms.ControlPaint.DrawMixedCheckBox(GraphicsUnchecked, smallIconSize, System.Windows.Forms.ButtonState.Normal)
            Else
                vsr.SetParameters(System.Windows.Forms.VisualStyles.VisualStyleElement.Button.CheckBox.UncheckedNormal)
                vsr.DrawBackground(GraphicsUnchecked, smallIconSize)
            End If
            _imgList.Images.Add(BitmapUnchecked, System.Drawing.Color.Transparent)
            _imgList.Images.Add(BitmapUnchecked, System.Drawing.Color.Transparent)
        End Using

        Using (GraphicsChecked)
            If (vsr Is Nothing) Then
                System.Windows.Forms.ControlPaint.DrawMixedCheckBox(GraphicsChecked, smallIconSize, System.Windows.Forms.ButtonState.Checked)
            Else
                vsr.SetParameters(System.Windows.Forms.VisualStyles.VisualStyleElement.Button.CheckBox.CheckedNormal)
                vsr.DrawBackground(GraphicsChecked, smallIconSize)
            End If
            _imgList.Images.Add(BitmapChecked, System.Drawing.Color.Transparent)
        End Using

        Using (GraphicsIndeterminate)
            If (vsr Is Nothing) Then
                System.Windows.Forms.ControlPaint.DrawMixedCheckBox(GraphicsIndeterminate, smallIconSize, System.Windows.Forms.ButtonState.Pushed)
            Else
                vsr.SetParameters(System.Windows.Forms.VisualStyles.VisualStyleElement.Button.CheckBox.MixedNormal)
                vsr.DrawBackground(GraphicsIndeterminate, smallIconSize)
            End If
            _imgList.Images.Add(BitmapIndeterminate, System.Drawing.Color.Transparent)
        End Using

    End Sub

End Class
