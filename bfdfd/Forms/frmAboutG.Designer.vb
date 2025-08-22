<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAboutG
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lnklblSF = New System.Windows.Forms.LinkLabel
        Me.btnOK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblMe = New System.Windows.Forms.LinkLabel
        Me.cmdLicense = New System.Windows.Forms.Button
        Me.lnkWebsite = New System.Windows.Forms.LinkLabel
        Me.lnkTryYAPM = New System.Windows.Forms.LinkLabel
        Me.pctIcon = New System.Windows.Forms.PictureBox
        Me.cmdDonate = New System.Windows.Forms.Button
        CType(Me.pctIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lnklblSF
        '
        Me.lnklblSF.AutoSize = True
        Me.lnklblSF.Location = New System.Drawing.Point(13, 170)
        Me.lnklblSF.Name = "lnklblSF"
        Me.lnklblSF.Size = New System.Drawing.Size(290, 13)
        Me.lnklblSF.TabIndex = 2
        Me.lnklblSF.TabStop = True
        Me.lnklblSF.Text = "Big Fast Duplicate File Deleter! on Sourceforge.net"
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(346, 195)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(73, 25)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(104, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(307, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Big Fast Duplicate File Deleter!"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(113, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Version :"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(173, 46)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(23, 13)
        Me.lblVersion.TabIndex = 7
        Me.lblVersion.Text = "1.0"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(185, 63)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(115, 13)
        Me.lblDate.TabIndex = 9
        Me.lblDate.Text = "March 20, 2010 16h36"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(113, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Build date :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(337, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Big Fast Duplicate File Deleter! is under GNU GPL 3.0 license"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(113, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(189, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Copyright 2008-2009 (c) violent_ken"
        '
        'lblMe
        '
        Me.lblMe.AutoSize = True
        Me.lblMe.Location = New System.Drawing.Point(13, 186)
        Me.lblMe.Name = "lblMe"
        Me.lblMe.Size = New System.Drawing.Size(83, 13)
        Me.lblMe.TabIndex = 18
        Me.lblMe.TabStop = True
        Me.lblMe.Text = "Send feedback"
        '
        'cmdLicense
        '
        Me.cmdLicense.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.cmdLicense.Location = New System.Drawing.Point(259, 195)
        Me.cmdLicense.Name = "cmdLicense"
        Me.cmdLicense.Size = New System.Drawing.Size(73, 25)
        Me.cmdLicense.TabIndex = 19
        Me.cmdLicense.Text = "Licenses..."
        Me.cmdLicense.UseVisualStyleBackColor = True
        '
        'lnkWebsite
        '
        Me.lnkWebsite.AutoSize = True
        Me.lnkWebsite.Location = New System.Drawing.Point(102, 186)
        Me.lnkWebsite.Name = "lnkWebsite"
        Me.lnkWebsite.Size = New System.Drawing.Size(49, 13)
        Me.lnkWebsite.TabIndex = 22
        Me.lnkWebsite.TabStop = True
        Me.lnkWebsite.Text = "Website"
        '
        'lnkTryYAPM
        '
        Me.lnkTryYAPM.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lnkTryYAPM.AutoSize = True
        Me.lnkTryYAPM.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkTryYAPM.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lnkTryYAPM.Location = New System.Drawing.Point(13, 154)
        Me.lnkTryYAPM.Name = "lnkTryYAPM"
        Me.lnkTryYAPM.Size = New System.Drawing.Size(323, 13)
        Me.lnkTryYAPM.TabIndex = 23
        Me.lnkTryYAPM.TabStop = True
        Me.lnkTryYAPM.Text = "Try out YAPM, a free and powerful process monitoring tool !"
        '
        'pctIcon
        '
        Me.pctIcon.Image = Global.My.Resources.Resources.icon48
        Me.pctIcon.Location = New System.Drawing.Point(12, 12)
        Me.pctIcon.Name = "pctIcon"
        Me.pctIcon.Size = New System.Drawing.Size(84, 83)
        Me.pctIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctIcon.TabIndex = 4
        Me.pctIcon.TabStop = False
        '
        'cmdDonate
        '
        Me.cmdDonate.Image = Global.My.Resources.Resources.paypal
        Me.cmdDonate.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdDonate.Location = New System.Drawing.Point(342, 41)
        Me.cmdDonate.Name = "cmdDonate"
        Me.cmdDonate.Size = New System.Drawing.Size(75, 69)
        Me.cmdDonate.TabIndex = 24
        Me.cmdDonate.Text = "Support my software !"
        Me.cmdDonate.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdDonate.UseVisualStyleBackColor = True
        '
        'frmAboutG
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnOK
        Me.ClientSize = New System.Drawing.Size(428, 230)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdDonate)
        Me.Controls.Add(Me.lnkTryYAPM)
        Me.Controls.Add(Me.lnkWebsite)
        Me.Controls.Add(Me.cmdLicense)
        Me.Controls.Add(Me.lblMe)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pctIcon)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lnklblSF)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmAboutG"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About Big Fast Duplicate File Deleter!"
        CType(Me.pctIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lnklblSF As System.Windows.Forms.LinkLabel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents pctIcon As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblMe As System.Windows.Forms.LinkLabel
    Friend WithEvents cmdLicense As System.Windows.Forms.Button
    Friend WithEvents lnkWebsite As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkTryYAPM As System.Windows.Forms.LinkLabel
    Friend WithEvents cmdDonate As System.Windows.Forms.Button
End Class
