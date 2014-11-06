<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_TemplateProduct_Select
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_product = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_Template = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.btn_Next = New System.Windows.Forms.Button
        Me.txt_new_template = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(123, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Product"
        '
        'cbo_product
        '
        Me.cbo_product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbo_product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_product.FormattingEnabled = True
        Me.cbo_product.Location = New System.Drawing.Point(180, 118)
        Me.cbo_product.Name = "cbo_product"
        Me.cbo_product.Size = New System.Drawing.Size(288, 21)
        Me.cbo_product.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(305, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 13)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Create Data From Template"
        Me.Label2.Visible = False
        '
        'cbo_Template
        '
        Me.cbo_Template.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbo_Template.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_Template.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Template.FormattingEnabled = True
        Me.cbo_Template.Location = New System.Drawing.Point(455, 168)
        Me.cbo_Template.Name = "cbo_Template"
        Me.cbo_Template.Size = New System.Drawing.Size(216, 21)
        Me.cbo_Template.TabIndex = 1
        Me.cbo_Template.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(596, 35)
        Me.Panel2.TabIndex = 165
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(431, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "TEMPLATE PRODUCT(SELECT TEMPLATE)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_close)
        Me.GroupBox2.Controls.Add(Me.btn_Next)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 217)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(567, 57)
        Me.GroupBox2.TabIndex = 166
        Me.GroupBox2.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(305, 16)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 3
        Me.bt_close.Text = "&Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'btn_Next
        '
        Me.btn_Next.Location = New System.Drawing.Point(172, 16)
        Me.btn_Next.Name = "btn_Next"
        Me.btn_Next.Size = New System.Drawing.Size(99, 29)
        Me.btn_Next.TabIndex = 2
        Me.btn_Next.Text = "&Next"
        Me.btn_Next.UseVisualStyleBackColor = True
        '
        'txt_new_template
        '
        Me.txt_new_template.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_new_template.Enabled = False
        Me.txt_new_template.ForeColor = System.Drawing.Color.Black
        Me.txt_new_template.Location = New System.Drawing.Point(455, 195)
        Me.txt_new_template.Name = "txt_new_template"
        Me.txt_new_template.Size = New System.Drawing.Size(169, 20)
        Me.txt_new_template.TabIndex = 180
        Me.txt_new_template.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(366, 198)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(76, 13)
        Me.Label28.TabIndex = 179
        Me.Label28.Text = "New Template"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label28.Visible = False
        '
        'Frm_TemplateProduct_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 286)
        Me.Controls.Add(Me.txt_new_template)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cbo_Template)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbo_product)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_TemplateProduct_Select"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_product As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_Template As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents btn_Next As System.Windows.Forms.Button
    Friend WithEvents txt_new_template As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
End Class
