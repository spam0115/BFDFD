<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.vlvFiles = New BrightIdeasSoftware.VirtualObjectListView()
        Me.OlvColumn0 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ItemQuantity = New System.Windows.Forms.ComboBox()
        CType(Me.vlvFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'vlvFiles
        '
        Me.vlvFiles.AllColumns.Add(Me.OlvColumn0)
        Me.vlvFiles.AllColumns.Add(Me.OlvColumn1)
        Me.vlvFiles.AllColumns.Add(Me.OlvColumn2)
        Me.vlvFiles.AllColumns.Add(Me.OlvColumn3)
        Me.vlvFiles.AllColumns.Add(Me.OlvColumn4)
        Me.vlvFiles.AllColumns.Add(Me.OlvColumn5)
        Me.vlvFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vlvFiles.CellEditUseWholeCell = False
        Me.vlvFiles.CheckBoxes = True
        Me.vlvFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn0, Me.OlvColumn1, Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5})
        Me.vlvFiles.Cursor = System.Windows.Forms.Cursors.Default
        Me.vlvFiles.HideSelection = False
        Me.vlvFiles.Location = New System.Drawing.Point(12, 12)
        Me.vlvFiles.Name = "vlvFiles"
        Me.vlvFiles.ShowGroups = False
        Me.vlvFiles.ShowImagesOnSubItems = True
        Me.vlvFiles.Size = New System.Drawing.Size(776, 334)
        Me.vlvFiles.TabIndex = 0
        Me.vlvFiles.UseCompatibleStateImageBehavior = False
        Me.vlvFiles.View = System.Windows.Forms.View.Details
        Me.vlvFiles.VirtualMode = True
        '
        'OlvColumn0
        '
        Me.OlvColumn0.Text = "Group"
        '
        'OlvColumn1
        '
        Me.OlvColumn1.FillsFreeSpace = True
        Me.OlvColumn1.Text = "File"
        '
        'OlvColumn2
        '
        Me.OlvColumn2.Text = "Type"
        '
        'OlvColumn3
        '
        Me.OlvColumn3.Text = "Size"
        '
        'OlvColumn4
        '
        Me.OlvColumn4.Text = "Created Date"
        '
        'OlvColumn5
        '
        Me.OlvColumn5.Text = "Modified Date"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(213, 352)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Populate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 381)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(322, 352)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Refresh"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 355)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "# of Items"
        '
        'ItemQuantity
        '
        Me.ItemQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ItemQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ItemQuantity.FormattingEnabled = True
        Me.ItemQuantity.Items.AddRange(New Object() {"10", "100", "1000", "10000", "100000", "1000000", "10000000"})
        Me.ItemQuantity.Location = New System.Drawing.Point(74, 352)
        Me.ItemQuantity.Name = "ItemQuantity"
        Me.ItemQuantity.Size = New System.Drawing.Size(121, 21)
        Me.ItemQuantity.TabIndex = 7
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ItemQuantity)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.vlvFiles)
        Me.Name = "Form2"
        Me.Text = "Virtual Object ListView"
        CType(Me.vlvFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents vlvFiles As BrightIdeasSoftware.VirtualObjectListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn0 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ItemQuantity As ComboBox
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
End Class
