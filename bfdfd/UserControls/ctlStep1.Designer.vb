<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlStep1
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlStep1))
        Me.lblStepDescription = New System.Windows.Forms.Label()
        Me.cmdAbout = New System.Windows.Forms.Button()
        Me.cmdPreferences = New System.Windows.Forms.Button()
        Me.cmdStartWizard = New System.Windows.Forms.Button()
        Me.txtWelcome = New System.Windows.Forms.TextBox()
        Me.cmdDonate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblStepDescription
        '
        Me.lblStepDescription.AutoSize = True
        Me.lblStepDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStepDescription.Location = New System.Drawing.Point(18, 15)
        Me.lblStepDescription.Name = "lblStepDescription"
        Me.lblStepDescription.Size = New System.Drawing.Size(359, 23)
        Me.lblStepDescription.TabIndex = 1
        Me.lblStepDescription.Text = "Welcome to Big Fast Duplicate File Deleter!"
        '
        'cmdAbout
        '
        Me.cmdAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAbout.Location = New System.Drawing.Point(122, 435)
        Me.cmdAbout.Name = "cmdAbout"
        Me.cmdAbout.Size = New System.Drawing.Size(119, 30)
        Me.cmdAbout.TabIndex = 2
        Me.cmdAbout.Text = "About BFDFD!"
        Me.cmdAbout.UseVisualStyleBackColor = True
        '
        'cmdPreferences
        '
        Me.cmdPreferences.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPreferences.Location = New System.Drawing.Point(13, 435)
        Me.cmdPreferences.Name = "cmdPreferences"
        Me.cmdPreferences.Size = New System.Drawing.Size(103, 30)
        Me.cmdPreferences.TabIndex = 1
        Me.cmdPreferences.Text = "Preferences..."
        Me.cmdPreferences.UseVisualStyleBackColor = True
        '
        'cmdStartWizard
        '
        Me.cmdStartWizard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdStartWizard.FlatAppearance.BorderSize = 3
        Me.cmdStartWizard.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStartWizard.Image = Global.My.Resources.Resources.icon48
        Me.cmdStartWizard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdStartWizard.Location = New System.Drawing.Point(399, 384)
        Me.cmdStartWizard.Name = "cmdStartWizard"
        Me.cmdStartWizard.Size = New System.Drawing.Size(214, 81)
        Me.cmdStartWizard.TabIndex = 0
        Me.cmdStartWizard.Text = "       Next"
        Me.cmdStartWizard.UseVisualStyleBackColor = True
        '
        'txtWelcome
        '
        Me.txtWelcome.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWelcome.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtWelcome.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWelcome.Location = New System.Drawing.Point(13, 41)
        Me.txtWelcome.Multiline = True
        Me.txtWelcome.Name = "txtWelcome"
        Me.txtWelcome.ReadOnly = True
        Me.txtWelcome.Size = New System.Drawing.Size(611, 337)
        Me.txtWelcome.TabIndex = 0
        Me.txtWelcome.TabStop = False
        Me.txtWelcome.Text = resources.GetString("txtWelcome.Text")
        '
        'cmdDonate
        '
        Me.cmdDonate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdDonate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDonate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDonate.Image = Global.My.Resources.Resources.paypal
        Me.cmdDonate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDonate.Location = New System.Drawing.Point(13, 384)
        Me.cmdDonate.Name = "cmdDonate"
        Me.cmdDonate.Size = New System.Drawing.Size(228, 45)
        Me.cmdDonate.TabIndex = 1
        Me.cmdDonate.Text = "Support my software !"
        Me.cmdDonate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDonate.UseVisualStyleBackColor = True
        '
        'ctlStep1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblStepDescription)
        Me.Controls.Add(Me.cmdAbout)
        Me.Controls.Add(Me.cmdPreferences)
        Me.Controls.Add(Me.cmdStartWizard)
        Me.Controls.Add(Me.txtWelcome)
        Me.Controls.Add(Me.cmdDonate)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctlStep1"
        Me.Size = New System.Drawing.Size(640, 480)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblStepDescription As System.Windows.Forms.Label
    Friend WithEvents cmdStartWizard As System.Windows.Forms.Button
    Friend WithEvents txtWelcome As System.Windows.Forms.TextBox
    Friend WithEvents cmdDonate As System.Windows.Forms.Button
    Friend WithEvents cmdPreferences As System.Windows.Forms.Button
    Friend WithEvents cmdAbout As System.Windows.Forms.Button

End Class
