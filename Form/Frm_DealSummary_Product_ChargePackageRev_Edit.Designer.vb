<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_Product_ChargePackageRev_Edit
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
        Me.txt_revision_desc = New System.Windows.Forms.TextBox
        Me.txt_revision_code = New System.Windows.Forms.TextBox
        Me.txt_company_id = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.lbHead = New System.Windows.Forms.Label
        Me.grp_tool = New System.Windows.Forms.GroupBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.BT_Update = New System.Windows.Forms.Button
        Me.cbo_charge_template = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txt_start_date = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_end_date = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_seq = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_my_product = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.grp_tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txt_revision_desc)
        Me.Panel2.Controls.Add(Me.txt_revision_code)
        Me.Panel2.Controls.Add(Me.txt_company_id)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.lbHead)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(752, 35)
        Me.Panel2.TabIndex = 198
        '
        'txt_revision_desc
        '
        Me.txt_revision_desc.Location = New System.Drawing.Point(429, 8)
        Me.txt_revision_desc.MaxLength = 8
        Me.txt_revision_desc.Name = "txt_revision_desc"
        Me.txt_revision_desc.Size = New System.Drawing.Size(52, 20)
        Me.txt_revision_desc.TabIndex = 1061
        Me.txt_revision_desc.Visible = False
        '
        'txt_revision_code
        '
        Me.txt_revision_code.Location = New System.Drawing.Point(330, 8)
        Me.txt_revision_code.MaxLength = 8
        Me.txt_revision_code.Name = "txt_revision_code"
        Me.txt_revision_code.Size = New System.Drawing.Size(93, 20)
        Me.txt_revision_code.TabIndex = 1060
        Me.txt_revision_code.Visible = False
        '
        'txt_company_id
        '
        Me.txt_company_id.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_company_id.Enabled = False
        Me.txt_company_id.Location = New System.Drawing.Point(572, 5)
        Me.txt_company_id.MaxLength = 10
        Me.txt_company_id.Name = "txt_company_id"
        Me.txt_company_id.Size = New System.Drawing.Size(169, 20)
        Me.txt_company_id.TabIndex = 1057
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label24.Location = New System.Drawing.Point(493, 8)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 13)
        Me.Label24.TabIndex = 1058
        Me.Label24.Text = "Company Id:"
        '
        'lbHead
        '
        Me.lbHead.AutoSize = True
        Me.lbHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbHead.ForeColor = System.Drawing.Color.Navy
        Me.lbHead.Location = New System.Drawing.Point(13, 5)
        Me.lbHead.Name = "lbHead"
        Me.lbHead.Size = New System.Drawing.Size(307, 24)
        Me.lbHead.TabIndex = 0
        Me.lbHead.Text = "Revision - Add Charge Package"
        '
        'grp_tool
        '
        Me.grp_tool.Controls.Add(Me.bt_close)
        Me.grp_tool.Controls.Add(Me.BT_Update)
        Me.grp_tool.Location = New System.Drawing.Point(6, 309)
        Me.grp_tool.Name = "grp_tool"
        Me.grp_tool.Size = New System.Drawing.Size(735, 49)
        Me.grp_tool.TabIndex = 4
        Me.grp_tool.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(376, 14)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 2
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'BT_Update
        '
        Me.BT_Update.Location = New System.Drawing.Point(253, 14)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(99, 29)
        Me.BT_Update.TabIndex = 1
        Me.BT_Update.Text = "Save"
        Me.BT_Update.UseVisualStyleBackColor = True
        '
        'cbo_charge_template
        '
        Me.cbo_charge_template.FormattingEnabled = True
        Me.cbo_charge_template.Location = New System.Drawing.Point(318, 161)
        Me.cbo_charge_template.Name = "cbo_charge_template"
        Me.cbo_charge_template.Size = New System.Drawing.Size(146, 21)
        Me.cbo_charge_template.TabIndex = 1
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(207, 164)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 13)
        Me.Label19.TabIndex = 1059
        Me.Label19.Text = "Charge Template"
        '
        'txt_start_date
        '
        Me.txt_start_date.Location = New System.Drawing.Point(318, 199)
        Me.txt_start_date.MaxLength = 0
        Me.txt_start_date.Name = "txt_start_date"
        Me.txt_start_date.Size = New System.Drawing.Size(146, 20)
        Me.txt_start_date.TabIndex = 2
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(240, 201)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 13)
        Me.Label30.TabIndex = 1126
        Me.Label30.Text = "Start Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(470, 202)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 1128
        Me.Label1.Text = "(DD/MM/YYYY)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(470, 240)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1131
        Me.Label2.Text = "(DD/MM/YYYY)"
        '
        'txt_end_date
        '
        Me.txt_end_date.Location = New System.Drawing.Point(318, 237)
        Me.txt_end_date.MaxLength = 0
        Me.txt_end_date.Name = "txt_end_date"
        Me.txt_end_date.Size = New System.Drawing.Size(146, 20)
        Me.txt_end_date.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(243, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 1129
        Me.Label3.Text = "End Date"
        '
        'txt_seq
        '
        Me.txt_seq.Enabled = False
        Me.txt_seq.Location = New System.Drawing.Point(318, 123)
        Me.txt_seq.MaxLength = 0
        Me.txt_seq.Name = "txt_seq"
        Me.txt_seq.Size = New System.Drawing.Size(78, 20)
        Me.txt_seq.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(269, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 1132
        Me.Label4.Text = "Seq"
        '
        'txt_my_product
        '
        Me.txt_my_product.Enabled = False
        Me.txt_my_product.Location = New System.Drawing.Point(318, 82)
        Me.txt_my_product.MaxLength = 0
        Me.txt_my_product.Name = "txt_my_product"
        Me.txt_my_product.Size = New System.Drawing.Size(146, 20)
        Me.txt_my_product.TabIndex = 1133
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(206, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 1134
        Me.Label5.Text = "My Product Code"
        '
        'Frm_DealSummary_Product_ChargePackageRev_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 378)
        Me.Controls.Add(Me.txt_my_product)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_seq)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_end_date)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_start_date)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.cbo_charge_template)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.grp_tool)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Frm_DealSummary_Product_ChargePackageRev_Edit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.grp_tool.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txt_revision_desc As System.Windows.Forms.TextBox
    Friend WithEvents txt_revision_code As System.Windows.Forms.TextBox
    Friend WithEvents txt_company_id As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lbHead As System.Windows.Forms.Label
    Friend WithEvents grp_tool As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents cbo_charge_template As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_start_date As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_end_date As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_seq As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_my_product As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
