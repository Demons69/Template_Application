<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Maintainance_Status_List
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.btn_Find = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbo_ProductCode = New System.Windows.Forms.ComboBox
        Me.txt_TemplateCode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.rad_StatusTemplate_1 = New System.Windows.Forms.RadioButton
        Me.rad_StatusTemplate_3 = New System.Windows.Forms.RadioButton
        Me.rad_StatusTemplate_2 = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.rad_TemplateType_1 = New System.Windows.Forms.RadioButton
        Me.rad_TemplateType_3 = New System.Windows.Forms.RadioButton
        Me.rad_TemplateType_2 = New System.Windows.Forms.RadioButton
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grd_Template = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_Delete = New System.Windows.Forms.Button
        Me.btn_Edit = New System.Windows.Forms.Button
        Me.btn_Add = New System.Windows.Forms.Button
        Me.bt_close = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_Template = New System.Windows.Forms.TextBox
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.grd_Template, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(755, 35)
        Me.Panel2.TabIndex = 167
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(12, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(183, 24)
        Me.Label17.TabIndex = 999
        Me.Label17.Text = "TEMPLATE CODE"
        '
        'btn_Find
        '
        Me.btn_Find.Location = New System.Drawing.Point(12, 206)
        Me.btn_Find.Name = "btn_Find"
        Me.btn_Find.Size = New System.Drawing.Size(120, 33)
        Me.btn_Find.TabIndex = 4
        Me.btn_Find.Text = "&Refresh..."
        Me.btn_Find.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo_ProductCode)
        Me.GroupBox1.Controls.Add(Me.txt_TemplateCode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Panel12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(733, 155)
        Me.GroupBox1.TabIndex = 168
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Criteria :"
        '
        'cbo_ProductCode
        '
        Me.cbo_ProductCode.FormattingEnabled = True
        Me.cbo_ProductCode.Location = New System.Drawing.Point(132, 52)
        Me.cbo_ProductCode.Name = "cbo_ProductCode"
        Me.cbo_ProductCode.Size = New System.Drawing.Size(447, 21)
        Me.cbo_ProductCode.TabIndex = 1
        '
        'txt_TemplateCode
        '
        Me.txt_TemplateCode.Location = New System.Drawing.Point(132, 79)
        Me.txt_TemplateCode.Name = "txt_TemplateCode"
        Me.txt_TemplateCode.Size = New System.Drawing.Size(137, 20)
        Me.txt_TemplateCode.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 179
        Me.Label4.Text = "Template Code"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rad_StatusTemplate_1)
        Me.Panel3.Controls.Add(Me.rad_StatusTemplate_3)
        Me.Panel3.Controls.Add(Me.rad_StatusTemplate_2)
        Me.Panel3.Location = New System.Drawing.Point(130, 110)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(289, 21)
        Me.Panel3.TabIndex = 3
        '
        'rad_StatusTemplate_1
        '
        Me.rad_StatusTemplate_1.AutoSize = True
        Me.rad_StatusTemplate_1.Checked = True
        Me.rad_StatusTemplate_1.Location = New System.Drawing.Point(8, 2)
        Me.rad_StatusTemplate_1.Name = "rad_StatusTemplate_1"
        Me.rad_StatusTemplate_1.Size = New System.Drawing.Size(44, 17)
        Me.rad_StatusTemplate_1.TabIndex = 0
        Me.rad_StatusTemplate_1.TabStop = True
        Me.rad_StatusTemplate_1.Text = "ALL"
        Me.rad_StatusTemplate_1.UseVisualStyleBackColor = True
        '
        'rad_StatusTemplate_3
        '
        Me.rad_StatusTemplate_3.AutoSize = True
        Me.rad_StatusTemplate_3.Location = New System.Drawing.Point(153, 3)
        Me.rad_StatusTemplate_3.Name = "rad_StatusTemplate_3"
        Me.rad_StatusTemplate_3.Size = New System.Drawing.Size(66, 17)
        Me.rad_StatusTemplate_3.TabIndex = 2
        Me.rad_StatusTemplate_3.Text = "Disabled"
        Me.rad_StatusTemplate_3.UseVisualStyleBackColor = True
        '
        'rad_StatusTemplate_2
        '
        Me.rad_StatusTemplate_2.AutoSize = True
        Me.rad_StatusTemplate_2.Location = New System.Drawing.Point(70, 3)
        Me.rad_StatusTemplate_2.Name = "rad_StatusTemplate_2"
        Me.rad_StatusTemplate_2.Size = New System.Drawing.Size(64, 17)
        Me.rad_StatusTemplate_2.TabIndex = 1
        Me.rad_StatusTemplate_2.Text = "Enabled"
        Me.rad_StatusTemplate_2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(89, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "Status"
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.rad_TemplateType_1)
        Me.Panel12.Controls.Add(Me.rad_TemplateType_3)
        Me.Panel12.Controls.Add(Me.rad_TemplateType_2)
        Me.Panel12.Location = New System.Drawing.Point(132, 21)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(343, 21)
        Me.Panel12.TabIndex = 0
        '
        'rad_TemplateType_1
        '
        Me.rad_TemplateType_1.AutoSize = True
        Me.rad_TemplateType_1.Checked = True
        Me.rad_TemplateType_1.Location = New System.Drawing.Point(7, 2)
        Me.rad_TemplateType_1.Name = "rad_TemplateType_1"
        Me.rad_TemplateType_1.Size = New System.Drawing.Size(44, 17)
        Me.rad_TemplateType_1.TabIndex = 0
        Me.rad_TemplateType_1.TabStop = True
        Me.rad_TemplateType_1.Text = "ALL"
        Me.rad_TemplateType_1.UseVisualStyleBackColor = True
        '
        'rad_TemplateType_3
        '
        Me.rad_TemplateType_3.AutoSize = True
        Me.rad_TemplateType_3.Location = New System.Drawing.Point(181, 3)
        Me.rad_TemplateType_3.Name = "rad_TemplateType_3"
        Me.rad_TemplateType_3.Size = New System.Drawing.Size(106, 17)
        Me.rad_TemplateType_3.TabIndex = 2
        Me.rad_TemplateType_3.Text = "Template Charge"
        Me.rad_TemplateType_3.UseVisualStyleBackColor = True
        '
        'rad_TemplateType_2
        '
        Me.rad_TemplateType_2.AutoSize = True
        Me.rad_TemplateType_2.Location = New System.Drawing.Point(66, 3)
        Me.rad_TemplateType_2.Name = "rad_TemplateType_2"
        Me.rad_TemplateType_2.Size = New System.Drawing.Size(109, 17)
        Me.rad_TemplateType_2.TabIndex = 1
        Me.rad_TemplateType_2.Text = "Template Product"
        Me.rad_TemplateType_2.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(51, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 177
        Me.Label13.Text = "TemplateType"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "Product Code"
        '
        'grd_Template
        '
        Me.grd_Template.AllowUserToAddRows = False
        Me.grd_Template.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_Template.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_Template.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.grd_Template.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_Template.Location = New System.Drawing.Point(10, 250)
        Me.grd_Template.MultiSelect = False
        Me.grd_Template.Name = "grd_Template"
        Me.grd_Template.ReadOnly = True
        Me.grd_Template.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_Template.Size = New System.Drawing.Size(733, 195)
        Me.grd_Template.TabIndex = 5
        Me.grd_Template.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_Delete)
        Me.Panel1.Controls.Add(Me.btn_Edit)
        Me.Panel1.Controls.Add(Me.btn_Add)
        Me.Panel1.Controls.Add(Me.bt_close)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_Template)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 460)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(755, 85)
        Me.Panel1.TabIndex = 173
        '
        'btn_Delete
        '
        Me.btn_Delete.Enabled = False
        Me.btn_Delete.Location = New System.Drawing.Point(293, 33)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(120, 33)
        Me.btn_Delete.TabIndex = 183
        Me.btn_Delete.Text = "Delete"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_Edit
        '
        Me.btn_Edit.Location = New System.Drawing.Point(150, 33)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(120, 33)
        Me.btn_Edit.TabIndex = 7
        Me.btn_Edit.Text = "Edit"
        Me.btn_Edit.UseVisualStyleBackColor = True
        '
        'btn_Add
        '
        Me.btn_Add.Location = New System.Drawing.Point(12, 33)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(120, 33)
        Me.btn_Add.TabIndex = 6
        Me.btn_Add.Text = "Add"
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(439, 33)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 33)
        Me.bt_close.TabIndex = 8
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 181
        Me.Label2.Text = "Selected"
        '
        'txt_Template
        '
        Me.txt_Template.Location = New System.Drawing.Point(64, 3)
        Me.txt_Template.Name = "txt_Template"
        Me.txt_Template.ReadOnly = True
        Me.txt_Template.Size = New System.Drawing.Size(109, 20)
        Me.txt_Template.TabIndex = 182
        Me.txt_Template.TabStop = False
        '
        'Frm_Maintainance_Status_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 545)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btn_Find)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grd_Template)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Frm_Maintainance_Status_List"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        CType(Me.grd_Template, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btn_Find As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grd_Template As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Template As System.Windows.Forms.TextBox
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents btn_Add As System.Windows.Forms.Button
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents rad_TemplateType_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rad_TemplateType_2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rad_StatusTemplate_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rad_StatusTemplate_2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_TemplateCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rad_TemplateType_1 As System.Windows.Forms.RadioButton
    Friend WithEvents rad_StatusTemplate_1 As System.Windows.Forms.RadioButton
    Friend WithEvents cbo_ProductCode As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
End Class
