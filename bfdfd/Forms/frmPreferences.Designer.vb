<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreferences
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
        Me.TabControl = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.cbPriority = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkStart = New System.Windows.Forms.CheckBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.cmdUpdateCheckNow = New System.Windows.Forms.Button
        Me.txtUpdateServer = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.chkUpdateAuto = New System.Windows.Forms.CheckBox
        Me.chkUpdateAlpha = New System.Windows.Forms.CheckBox
        Me.chkUpdateBeta = New System.Windows.Forms.CheckBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.cmdDefVideos = New System.Windows.Forms.Button
        Me.txtVideos = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdDefMusic = New System.Windows.Forms.Button
        Me.txtMusic = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdDefImages = New System.Windows.Forms.Button
        Me.txtImages = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdDefArchives = New System.Windows.Forms.Button
        Me.txtArchives = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdQuit = New System.Windows.Forms.Button
        Me.cmdDefaut = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbHash = New System.Windows.Forms.ComboBox
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Controls.Add(Me.TabPage3)
        Me.TabControl.Location = New System.Drawing.Point(9, 9)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(286, 209)
        Me.TabControl.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cbHash)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.cbPriority)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.ImageKey = "(aucun)"
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(278, 183)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cbPriority
        '
        Me.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPriority.FormattingEnabled = True
        Me.cbPriority.Items.AddRange(New Object() {"Idle", "Below Normal", "Normal", "Above Normal", "High", "Real Time"})
        Me.cbPriority.Location = New System.Drawing.Point(71, 77)
        Me.cbPriority.Name = "cbPriority"
        Me.cbPriority.Size = New System.Drawing.Size(159, 21)
        Me.cbPriority.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Priority"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkStart)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(252, 47)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Startup"
        '
        'chkStart
        '
        Me.chkStart.AutoSize = True
        Me.chkStart.Location = New System.Drawing.Point(9, 22)
        Me.chkStart.Name = "chkStart"
        Me.chkStart.Size = New System.Drawing.Size(195, 17)
        Me.chkStart.TabIndex = 0
        Me.chkStart.Text = "Start YADFR on Windows startup"
        Me.chkStart.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cmdUpdateCheckNow)
        Me.TabPage2.Controls.Add(Me.txtUpdateServer)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.chkUpdateAuto)
        Me.TabPage2.Controls.Add(Me.chkUpdateAlpha)
        Me.TabPage2.Controls.Add(Me.chkUpdateBeta)
        Me.TabPage2.ImageKey = "(aucun)"
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(278, 183)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Update"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmdUpdateCheckNow
        '
        Me.cmdUpdateCheckNow.Location = New System.Drawing.Point(11, 131)
        Me.cmdUpdateCheckNow.Name = "cmdUpdateCheckNow"
        Me.cmdUpdateCheckNow.Size = New System.Drawing.Size(108, 23)
        Me.cmdUpdateCheckNow.TabIndex = 18
        Me.cmdUpdateCheckNow.Text = "Check now"
        Me.cmdUpdateCheckNow.UseVisualStyleBackColor = True
        '
        'txtUpdateServer
        '
        Me.txtUpdateServer.Location = New System.Drawing.Point(56, 90)
        Me.txtUpdateServer.Name = "txtUpdateServer"
        Me.txtUpdateServer.Size = New System.Drawing.Size(216, 22)
        Me.txtUpdateServer.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Server"
        '
        'chkUpdateAuto
        '
        Me.chkUpdateAuto.AutoSize = True
        Me.chkUpdateAuto.Location = New System.Drawing.Point(11, 67)
        Me.chkUpdateAuto.Name = "chkUpdateAuto"
        Me.chkUpdateAuto.Size = New System.Drawing.Size(224, 17)
        Me.chkUpdateAuto.TabIndex = 15
        Me.chkUpdateAuto.Text = "Check if YADFR is up to date at startup"
        Me.chkUpdateAuto.UseVisualStyleBackColor = True
        '
        'chkUpdateAlpha
        '
        Me.chkUpdateAlpha.AutoSize = True
        Me.chkUpdateAlpha.Location = New System.Drawing.Point(11, 44)
        Me.chkUpdateAlpha.Name = "chkUpdateAlpha"
        Me.chkUpdateAlpha.Size = New System.Drawing.Size(151, 17)
        Me.chkUpdateAlpha.TabIndex = 14
        Me.chkUpdateAlpha.Text = "Check for alpha releases"
        Me.chkUpdateAlpha.UseVisualStyleBackColor = True
        '
        'chkUpdateBeta
        '
        Me.chkUpdateBeta.AutoSize = True
        Me.chkUpdateBeta.Location = New System.Drawing.Point(11, 21)
        Me.chkUpdateBeta.Name = "chkUpdateBeta"
        Me.chkUpdateBeta.Size = New System.Drawing.Size(145, 17)
        Me.chkUpdateBeta.TabIndex = 13
        Me.chkUpdateBeta.Text = "Check for beta releases"
        Me.chkUpdateBeta.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cmdDefVideos)
        Me.TabPage3.Controls.Add(Me.txtVideos)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.cmdDefMusic)
        Me.TabPage3.Controls.Add(Me.txtMusic)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.cmdDefImages)
        Me.TabPage3.Controls.Add(Me.txtImages)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.cmdDefArchives)
        Me.TabPage3.Controls.Add(Me.txtArchives)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(278, 183)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Extensions"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cmdDefVideos
        '
        Me.cmdDefVideos.Location = New System.Drawing.Point(214, 123)
        Me.cmdDefVideos.Name = "cmdDefVideos"
        Me.cmdDefVideos.Size = New System.Drawing.Size(58, 23)
        Me.cmdDefVideos.TabIndex = 12
        Me.cmdDefVideos.Text = "Default"
        Me.cmdDefVideos.UseVisualStyleBackColor = True
        '
        'txtVideos
        '
        Me.txtVideos.Location = New System.Drawing.Point(55, 124)
        Me.txtVideos.Name = "txtVideos"
        Me.txtVideos.Size = New System.Drawing.Size(153, 22)
        Me.txtVideos.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Videos"
        '
        'cmdDefMusic
        '
        Me.cmdDefMusic.Location = New System.Drawing.Point(214, 95)
        Me.cmdDefMusic.Name = "cmdDefMusic"
        Me.cmdDefMusic.Size = New System.Drawing.Size(58, 23)
        Me.cmdDefMusic.TabIndex = 9
        Me.cmdDefMusic.Text = "Default"
        Me.cmdDefMusic.UseVisualStyleBackColor = True
        '
        'txtMusic
        '
        Me.txtMusic.Location = New System.Drawing.Point(55, 96)
        Me.txtMusic.Name = "txtMusic"
        Me.txtMusic.Size = New System.Drawing.Size(153, 22)
        Me.txtMusic.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Music"
        '
        'cmdDefImages
        '
        Me.cmdDefImages.Location = New System.Drawing.Point(214, 67)
        Me.cmdDefImages.Name = "cmdDefImages"
        Me.cmdDefImages.Size = New System.Drawing.Size(58, 23)
        Me.cmdDefImages.TabIndex = 6
        Me.cmdDefImages.Text = "Default"
        Me.cmdDefImages.UseVisualStyleBackColor = True
        '
        'txtImages
        '
        Me.txtImages.Location = New System.Drawing.Point(55, 68)
        Me.txtImages.Name = "txtImages"
        Me.txtImages.Size = New System.Drawing.Size(153, 22)
        Me.txtImages.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Images"
        '
        'cmdDefArchives
        '
        Me.cmdDefArchives.Location = New System.Drawing.Point(214, 39)
        Me.cmdDefArchives.Name = "cmdDefArchives"
        Me.cmdDefArchives.Size = New System.Drawing.Size(58, 23)
        Me.cmdDefArchives.TabIndex = 3
        Me.cmdDefArchives.Text = "Default"
        Me.cmdDefArchives.UseVisualStyleBackColor = True
        '
        'txtArchives
        '
        Me.txtArchives.Location = New System.Drawing.Point(55, 40)
        Me.txtArchives.Name = "txtArchives"
        Me.txtArchives.Size = New System.Drawing.Size(153, 22)
        Me.txtArchives.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Archives"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Example : *.jpg;*.jpeg;*.bmp;*.png"
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(12, 224)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(66, 26)
        Me.cmdSave.TabIndex = 7
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdQuit
        '
        Me.cmdQuit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdQuit.Location = New System.Drawing.Point(216, 224)
        Me.cmdQuit.Name = "cmdQuit"
        Me.cmdQuit.Size = New System.Drawing.Size(75, 26)
        Me.cmdQuit.TabIndex = 9
        Me.cmdQuit.Text = "Close"
        Me.cmdQuit.UseVisualStyleBackColor = True
        '
        'cmdDefaut
        '
        Me.cmdDefaut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdDefaut.Location = New System.Drawing.Point(109, 224)
        Me.cmdDefaut.Name = "cmdDefaut"
        Me.cmdDefaut.Size = New System.Drawing.Size(75, 26)
        Me.cmdDefaut.TabIndex = 8
        Me.cmdDefaut.Text = "Default"
        Me.cmdDefaut.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Hash algorithm"
        '
        'cbHash
        '
        Me.cbHash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbHash.FormattingEnabled = True
        Me.cbHash.Items.AddRange(New Object() {"MD5", "SHA1"})
        Me.cbHash.Location = New System.Drawing.Point(114, 116)
        Me.cbHash.Name = "cbHash"
        Me.cbHash.Size = New System.Drawing.Size(116, 21)
        Me.cbHash.TabIndex = 12
        '
        'frmPreferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 258)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdDefaut)
        Me.Controls.Add(Me.cmdQuit)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.TabControl)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPreferences"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preferences"
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdQuit As System.Windows.Forms.Button
    Friend WithEvents cmdDefaut As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkStart As System.Windows.Forms.CheckBox
    Friend WithEvents chkUpdateAuto As System.Windows.Forms.CheckBox
    Friend WithEvents chkUpdateAlpha As System.Windows.Forms.CheckBox
    Friend WithEvents chkUpdateBeta As System.Windows.Forms.CheckBox
    Friend WithEvents cmdUpdateCheckNow As System.Windows.Forms.Button
    Friend WithEvents txtUpdateServer As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbPriority As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents cmdDefVideos As System.Windows.Forms.Button
    Friend WithEvents txtVideos As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdDefMusic As System.Windows.Forms.Button
    Friend WithEvents txtMusic As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdDefImages As System.Windows.Forms.Button
    Friend WithEvents txtImages As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdDefArchives As System.Windows.Forms.Button
    Friend WithEvents txtArchives As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbHash As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
