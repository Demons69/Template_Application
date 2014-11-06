<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Print_TemplateProduct
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.CB_PD = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.end_s = New System.Windows.Forms.ComboBox
        Me.st_s = New System.Windows.Forms.ComboBox
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(413, 35)
        Me.Panel2.TabIndex = 174
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(223, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Print Template Product"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(189, 13)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(98, 27)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 139)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(413, 46)
        Me.GroupBox1.TabIndex = 175
        Me.GroupBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(305, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 27)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CB_PD
        '
        Me.CB_PD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.CB_PD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CB_PD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_PD.FormattingEnabled = True
        Me.CB_PD.Location = New System.Drawing.Point(102, 56)
        Me.CB_PD.Name = "CB_PD"
        Me.CB_PD.Size = New System.Drawing.Size(280, 21)
        Me.CB_PD.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 173
        Me.Label3.Text = "Product"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Template Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(236, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "-"
        '
        'end_s
        '
        Me.end_s.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.end_s.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.end_s.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.end_s.Enabled = False
        Me.end_s.FormattingEnabled = True
        Me.end_s.Location = New System.Drawing.Point(251, 83)
        Me.end_s.Name = "end_s"
        Me.end_s.Size = New System.Drawing.Size(131, 21)
        Me.end_s.TabIndex = 2
        '
        'st_s
        '
        Me.st_s.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.st_s.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.st_s.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.st_s.Enabled = False
        Me.st_s.FormattingEnabled = True
        Me.st_s.Location = New System.Drawing.Point(102, 83)
        Me.st_s.Name = "st_s"
        Me.st_s.Size = New System.Drawing.Size(131, 21)
        Me.st_s.TabIndex = 1
        '
        'Frm_Print_TemplateProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 185)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CB_PD)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.end_s)
        Me.Controls.Add(Me.st_s)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Frm_Print_TemplateProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CB_PD As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents end_s As System.Windows.Forms.ComboBox
    Friend WithEvents st_s As System.Windows.Forms.ComboBox
End Class
