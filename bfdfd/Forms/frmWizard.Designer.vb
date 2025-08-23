<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWizard
    Inherits PersistentForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWizard))
        Me.Tray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.mnuMain = New System.Windows.Forms.ContextMenu()
        Me.MenuItemHide = New System.Windows.Forms.MenuItem()
        Me.MenuItemMainElevate = New System.Windows.Forms.MenuItem()
        Me.MenuItemSeparator0 = New System.Windows.Forms.MenuItem()
        Me.MenuItemMainWindow = New System.Windows.Forms.MenuItem()
        Me.MenuItemSeparator2 = New System.Windows.Forms.MenuItem()
        Me.MenuItemMainCheckUpdate = New System.Windows.Forms.MenuItem()
        Me.MenuItemMainAbout = New System.Windows.Forms.MenuItem()
        Me.MenuItemMainExit = New System.Windows.Forms.MenuItem()
        Me.VistaMenu = New wyDay.Controls.VistaMenu(Me.components)
        Me.splitMain = New System.Windows.Forms.SplitContainer()
        Me.cmdNextStep = New System.Windows.Forms.Button()
        Me.cmdPreviousStep = New System.Windows.Forms.Button()
        Me.lblStepNoutOfN = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.VistaMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tray
        '
        Me.Tray.Text = "Big Fast Duplicate File Deleter! 1.0"
        Me.Tray.Visible = True
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItemHide, Me.MenuItemMainElevate, Me.MenuItemSeparator0, Me.MenuItemMainWindow, Me.MenuItemSeparator2, Me.MenuItemMainCheckUpdate, Me.MenuItemMainAbout, Me.MenuItemMainExit})
        '
        'MenuItemHide
        '
        Me.MenuItemHide.DefaultItem = True
        Me.MenuItemHide.Index = 0
        Me.MenuItemHide.Text = "&Hide"
        '
        'MenuItemMainElevate
        '
        Me.MenuItemMainElevate.Index = 1
        Me.MenuItemMainElevate.Text = "&Restart YADFR as admin"
        '
        'MenuItemSeparator0
        '
        Me.MenuItemSeparator0.Index = 2
        Me.MenuItemSeparator0.Text = "-"
        '
        'MenuItemMainWindow
        '
        Me.MenuItemMainWindow.Index = 3
        Me.MenuItemMainWindow.Text = "&Window"
        '
        'MenuItemSeparator2
        '
        Me.MenuItemSeparator2.Index = 4
        Me.MenuItemSeparator2.Text = "-"
        '
        'MenuItemMainCheckUpdate
        '
        Me.MenuItemMainCheckUpdate.Index = 5
        Me.MenuItemMainCheckUpdate.Text = "&Check update..."
        '
        'MenuItemMainAbout
        '
        Me.MenuItemMainAbout.Index = 6
        Me.MenuItemMainAbout.Text = "&About YADFR"
        '
        'MenuItemMainExit
        '
        Me.MenuItemMainExit.Index = 7
        Me.MenuItemMainExit.Text = "&Exit"
        '
        'VistaMenu
        '
        Me.VistaMenu.ContainerControl = Me
        '
        'splitMain
        '
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitMain.IsSplitterFixed = True
        Me.splitMain.Location = New System.Drawing.Point(0, 0)
        Me.splitMain.Name = "splitMain"
        Me.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.BackColor = System.Drawing.Color.White
        Me.splitMain.Panel1.Controls.Add(Me.Label1)
        Me.splitMain.Panel1.Controls.Add(Me.cmdNextStep)
        Me.splitMain.Panel1.Controls.Add(Me.cmdPreviousStep)
        Me.splitMain.Panel1.Controls.Add(Me.lblStepNoutOfN)
        Me.splitMain.Size = New System.Drawing.Size(942, 673)
        Me.splitMain.SplitterDistance = 39
        Me.splitMain.TabIndex = 0
        Me.splitMain.TabStop = False
        '
        'cmdNextStep
        '
        Me.cmdNextStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNextStep.Enabled = False
        Me.cmdNextStep.Image = Global.My.Resources.Resources.right16
        Me.cmdNextStep.Location = New System.Drawing.Point(905, 8)
        Me.cmdNextStep.Name = "cmdNextStep"
        Me.cmdNextStep.Size = New System.Drawing.Size(29, 23)
        Me.cmdNextStep.TabIndex = 1
        Me.cmdNextStep.UseVisualStyleBackColor = True
        '
        'cmdPreviousStep
        '
        Me.cmdPreviousStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPreviousStep.Enabled = False
        Me.cmdPreviousStep.Image = Global.My.Resources.Resources.left16
        Me.cmdPreviousStep.Location = New System.Drawing.Point(870, 8)
        Me.cmdPreviousStep.Name = "cmdPreviousStep"
        Me.cmdPreviousStep.Size = New System.Drawing.Size(29, 23)
        Me.cmdPreviousStep.TabIndex = 0
        Me.cmdPreviousStep.UseVisualStyleBackColor = True
        '
        'lblStepNoutOfN
        '
        Me.lblStepNoutOfN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStepNoutOfN.AutoSize = True
        Me.lblStepNoutOfN.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStepNoutOfN.Location = New System.Drawing.Point(769, 6)
        Me.lblStepNoutOfN.Name = "lblStepNoutOfN"
        Me.lblStepNoutOfN.Size = New System.Drawing.Size(95, 25)
        Me.lblStepNoutOfN.TabIndex = 5
        Me.lblStepNoutOfN.Text = "Step N/N"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 28)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Options Wizard"
        '
        'frmWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 673)
        Me.Controls.Add(Me.splitMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(720, 540)
        Me.Name = "frmWizard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Big Fast Duplicate File Deleter!"
        CType(Me.VistaMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel1.PerformLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tray As System.Windows.Forms.NotifyIcon
    Private WithEvents mnuMain As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemMainElevate As System.Windows.Forms.MenuItem
    Friend WithEvents VistaMenu As wyDay.Controls.VistaMenu
    Friend WithEvents MenuItemMainAbout As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemMainCheckUpdate As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSeparator0 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemMainExit As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemMainWindow As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents splitMain As System.Windows.Forms.SplitContainer
    Friend WithEvents lblStepNoutOfN As System.Windows.Forms.Label
    Friend WithEvents cmdPreviousStep As System.Windows.Forms.Button
    Friend WithEvents cmdNextStep As System.Windows.Forms.Button
    Friend WithEvents MenuItemHide As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As Label
End Class
