Imports System.ComponentModel
Imports System.Windows.Forms

Public Class PersistentForm
    Inherits Form

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        If IsInDesigner(Me) Then Return
        ' Safe at runtime only
        FormPlacement.Restore(Me)
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If Not IsInDesigner(Me) Then
            FormPlacement.Save(Me)
        End If
        MyBase.OnFormClosing(e)
    End Sub

    Private Shared Function IsInDesigner(c As Component) As Boolean
        ' More reliable than Me.DesignMode alone in base classes/constructors
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return True
        Return c.Site IsNot Nothing AndAlso c.Site.DesignMode
    End Function
End Class