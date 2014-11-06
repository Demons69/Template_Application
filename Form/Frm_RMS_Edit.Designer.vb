<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RMS_Edit
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.BT_Update = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.rad_enable_n = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cbo_product_name = New System.Windows.Forms.ComboBox
        Me.rad_enable_y = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txt_company_id = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_organizer_name = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rad_encryption_n = New System.Windows.Forms.RadioButton
        Me.rad_encryption_y = New System.Windows.Forms.RadioButton
        Me.cbo_delivery_channel = New System.Windows.Forms.ComboBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.rad_delivery_method_manual = New System.Windows.Forms.RadioButton
        Me.rad_delivery_method_auto = New System.Windows.Forms.RadioButton
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.rad_every_hour_n = New System.Windows.Forms.RadioButton
        Me.rad_every_hour_y = New System.Windows.Forms.RadioButton
        Me.grd_rms = New System.Windows.Forms.DataGridView
        Me.btn_new = New System.Windows.Forms.Button
        Me.brn_edit = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.txt_seq = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbo_account_no = New System.Windows.Forms.ComboBox
        Me.btn_new_all = New System.Windows.Forms.Button
        Me.txt_revision_desc = New System.Windows.Forms.TextBox
        Me.txt_revision_code = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grd_rms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(177, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 1019
        Me.Label3.Text = "Encryption"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_close)
        Me.GroupBox2.Controls.Add(Me.BT_Update)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 455)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(698, 51)
        Me.GroupBox2.TabIndex = 1015
        Me.GroupBox2.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(333, 16)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 6
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'BT_Update
        '
        Me.BT_Update.Location = New System.Drawing.Point(218, 16)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(99, 29)
        Me.BT_Update.TabIndex = 5
        Me.BT_Update.Text = "Save"
        Me.BT_Update.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(159, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 1017
        Me.Label1.Text = "Product Name"
        '
        'rad_enable_n
        '
        Me.rad_enable_n.AutoSize = True
        Me.rad_enable_n.Location = New System.Drawing.Point(83, 4)
        Me.rad_enable_n.Name = "rad_enable_n"
        Me.rad_enable_n.Size = New System.Drawing.Size(39, 17)
        Me.rad_enable_n.TabIndex = 2
        Me.rad_enable_n.Text = "No"
        Me.rad_enable_n.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(194, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 1020
        Me.Label2.Text = "Enable"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "RMS"
        '
        'cbo_product_name
        '
        Me.cbo_product_name.FormattingEnabled = True
        Me.cbo_product_name.Location = New System.Drawing.Point(250, 80)
        Me.cbo_product_name.Name = "cbo_product_name"
        Me.cbo_product_name.Size = New System.Drawing.Size(335, 21)
        Me.cbo_product_name.TabIndex = 0
        '
        'rad_enable_y
        '
        Me.rad_enable_y.AutoSize = True
        Me.rad_enable_y.Checked = True
        Me.rad_enable_y.Location = New System.Drawing.Point(3, 4)
        Me.rad_enable_y.Name = "rad_enable_y"
        Me.rad_enable_y.Size = New System.Drawing.Size(43, 17)
        Me.rad_enable_y.TabIndex = 1
        Me.rad_enable_y.TabStop = True
        Me.rad_enable_y.Text = "Yes"
        Me.rad_enable_y.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(170, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 1018
        Me.Label4.Text = "Account No"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rad_enable_n)
        Me.Panel3.Controls.Add(Me.rad_enable_y)
        Me.Panel3.Location = New System.Drawing.Point(250, 133)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(154, 24)
        Me.Panel3.TabIndex = 2
        Me.Panel3.TabStop = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txt_revision_desc)
        Me.Panel2.Controls.Add(Me.txt_revision_code)
        Me.Panel2.Controls.Add(Me.txt_company_id)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(727, 35)
        Me.Panel2.TabIndex = 1014
        '
        'txt_company_id
        '
        Me.txt_company_id.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_company_id.Enabled = False
        Me.txt_company_id.Location = New System.Drawing.Point(555, 5)
        Me.txt_company_id.MaxLength = 10
        Me.txt_company_id.Name = "txt_company_id"
        Me.txt_company_id.Size = New System.Drawing.Size(169, 20)
        Me.txt_company_id.TabIndex = 1061
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label24.Location = New System.Drawing.Point(476, 8)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 13)
        Me.Label24.TabIndex = 1062
        Me.Label24.Text = "Company Id:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(147, 195)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 1022
        Me.Label5.Text = "Delivery Channel"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(150, 221)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 1024
        Me.Label6.Text = "Delivery Method"
        '
        'txt_organizer_name
        '
        Me.txt_organizer_name.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_organizer_name.Enabled = False
        Me.txt_organizer_name.Location = New System.Drawing.Point(250, 244)
        Me.txt_organizer_name.MaxLength = 27
        Me.txt_organizer_name.Name = "txt_organizer_name"
        Me.txt_organizer_name.Size = New System.Drawing.Size(468, 20)
        Me.txt_organizer_name.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(151, 247)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 1026
        Me.Label7.Text = "Organizer Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(174, 273)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 1028
        Me.Label8.Text = "Every Hour"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rad_encryption_n)
        Me.Panel1.Controls.Add(Me.rad_encryption_y)
        Me.Panel1.Location = New System.Drawing.Point(250, 162)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(154, 24)
        Me.Panel1.TabIndex = 3
        Me.Panel1.TabStop = True
        '
        'rad_encryption_n
        '
        Me.rad_encryption_n.AutoSize = True
        Me.rad_encryption_n.Checked = True
        Me.rad_encryption_n.Location = New System.Drawing.Point(83, 4)
        Me.rad_encryption_n.Name = "rad_encryption_n"
        Me.rad_encryption_n.Size = New System.Drawing.Size(39, 17)
        Me.rad_encryption_n.TabIndex = 2
        Me.rad_encryption_n.TabStop = True
        Me.rad_encryption_n.Text = "No"
        Me.rad_encryption_n.UseVisualStyleBackColor = True
        '
        'rad_encryption_y
        '
        Me.rad_encryption_y.AutoSize = True
        Me.rad_encryption_y.Location = New System.Drawing.Point(3, 4)
        Me.rad_encryption_y.Name = "rad_encryption_y"
        Me.rad_encryption_y.Size = New System.Drawing.Size(43, 17)
        Me.rad_encryption_y.TabIndex = 1
        Me.rad_encryption_y.Text = "Yes"
        Me.rad_encryption_y.UseVisualStyleBackColor = True
        '
        'cbo_delivery_channel
        '
        Me.cbo_delivery_channel.FormattingEnabled = True
        Me.cbo_delivery_channel.Location = New System.Drawing.Point(250, 189)
        Me.cbo_delivery_channel.Name = "cbo_delivery_channel"
        Me.cbo_delivery_channel.Size = New System.Drawing.Size(335, 21)
        Me.cbo_delivery_channel.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rad_delivery_method_manual)
        Me.Panel4.Controls.Add(Me.rad_delivery_method_auto)
        Me.Panel4.Location = New System.Drawing.Point(250, 216)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(310, 24)
        Me.Panel4.TabIndex = 5
        Me.Panel4.TabStop = True
        '
        'rad_delivery_method_manual
        '
        Me.rad_delivery_method_manual.AutoSize = True
        Me.rad_delivery_method_manual.Location = New System.Drawing.Point(119, 4)
        Me.rad_delivery_method_manual.Name = "rad_delivery_method_manual"
        Me.rad_delivery_method_manual.Size = New System.Drawing.Size(60, 17)
        Me.rad_delivery_method_manual.TabIndex = 2
        Me.rad_delivery_method_manual.Text = "Manual"
        Me.rad_delivery_method_manual.UseVisualStyleBackColor = True
        '
        'rad_delivery_method_auto
        '
        Me.rad_delivery_method_auto.AutoSize = True
        Me.rad_delivery_method_auto.Checked = True
        Me.rad_delivery_method_auto.Location = New System.Drawing.Point(3, 4)
        Me.rad_delivery_method_auto.Name = "rad_delivery_method_auto"
        Me.rad_delivery_method_auto.Size = New System.Drawing.Size(76, 17)
        Me.rad_delivery_method_auto.TabIndex = 1
        Me.rad_delivery_method_auto.TabStop = True
        Me.rad_delivery_method_auto.Text = "Automated"
        Me.rad_delivery_method_auto.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.rad_every_hour_n)
        Me.Panel5.Controls.Add(Me.rad_every_hour_y)
        Me.Panel5.Location = New System.Drawing.Point(250, 270)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(154, 24)
        Me.Panel5.TabIndex = 7
        Me.Panel5.TabStop = True
        '
        'rad_every_hour_n
        '
        Me.rad_every_hour_n.AutoSize = True
        Me.rad_every_hour_n.Checked = True
        Me.rad_every_hour_n.Location = New System.Drawing.Point(83, 4)
        Me.rad_every_hour_n.Name = "rad_every_hour_n"
        Me.rad_every_hour_n.Size = New System.Drawing.Size(39, 17)
        Me.rad_every_hour_n.TabIndex = 2
        Me.rad_every_hour_n.TabStop = True
        Me.rad_every_hour_n.Text = "No"
        Me.rad_every_hour_n.UseVisualStyleBackColor = True
        '
        'rad_every_hour_y
        '
        Me.rad_every_hour_y.AutoSize = True
        Me.rad_every_hour_y.Location = New System.Drawing.Point(3, 4)
        Me.rad_every_hour_y.Name = "rad_every_hour_y"
        Me.rad_every_hour_y.Size = New System.Drawing.Size(43, 17)
        Me.rad_every_hour_y.TabIndex = 1
        Me.rad_every_hour_y.Text = "Yes"
        Me.rad_every_hour_y.UseVisualStyleBackColor = True
        '
        'grd_rms
        '
        Me.grd_rms.AllowUserToAddRows = False
        Me.grd_rms.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_rms.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_rms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.grd_rms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_rms.Location = New System.Drawing.Point(12, 306)
        Me.grd_rms.MultiSelect = False
        Me.grd_rms.Name = "grd_rms"
        Me.grd_rms.ReadOnly = True
        Me.grd_rms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_rms.Size = New System.Drawing.Size(601, 143)
        Me.grd_rms.TabIndex = 1034
        Me.grd_rms.TabStop = False
        '
        'btn_new
        '
        Me.btn_new.Location = New System.Drawing.Point(619, 342)
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Size = New System.Drawing.Size(99, 29)
        Me.btn_new.TabIndex = 1035
        Me.btn_new.Text = "New Individual"
        Me.btn_new.UseVisualStyleBackColor = True
        '
        'brn_edit
        '
        Me.brn_edit.Location = New System.Drawing.Point(619, 380)
        Me.brn_edit.Name = "brn_edit"
        Me.brn_edit.Size = New System.Drawing.Size(99, 29)
        Me.brn_edit.TabIndex = 1036
        Me.brn_edit.Text = "Edit"
        Me.brn_edit.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(619, 416)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(99, 29)
        Me.btn_delete.TabIndex = 1037
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'txt_seq
        '
        Me.txt_seq.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_seq.Enabled = False
        Me.txt_seq.Location = New System.Drawing.Point(250, 54)
        Me.txt_seq.MaxLength = 10
        Me.txt_seq.Name = "txt_seq"
        Me.txt_seq.Size = New System.Drawing.Size(137, 20)
        Me.txt_seq.TabIndex = 1038
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(205, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 1039
        Me.Label9.Text = "Seq"
        '
        'cbo_account_no
        '
        Me.cbo_account_no.FormattingEnabled = True
        Me.cbo_account_no.Location = New System.Drawing.Point(250, 106)
        Me.cbo_account_no.Name = "cbo_account_no"
        Me.cbo_account_no.Size = New System.Drawing.Size(199, 21)
        Me.cbo_account_no.TabIndex = 1
        '
        'btn_new_all
        '
        Me.btn_new_all.Location = New System.Drawing.Point(619, 306)
        Me.btn_new_all.Name = "btn_new_all"
        Me.btn_new_all.Size = New System.Drawing.Size(99, 29)
        Me.btn_new_all.TabIndex = 1040
        Me.btn_new_all.Text = "New All"
        Me.btn_new_all.UseVisualStyleBackColor = True
        '
        'txt_revision_desc
        '
        Me.txt_revision_desc.Location = New System.Drawing.Point(189, 5)
        Me.txt_revision_desc.MaxLength = 8
        Me.txt_revision_desc.Name = "txt_revision_desc"
        Me.txt_revision_desc.Size = New System.Drawing.Size(215, 20)
        Me.txt_revision_desc.TabIndex = 1068
        Me.txt_revision_desc.Visible = False
        '
        'txt_revision_code
        '
        Me.txt_revision_code.Location = New System.Drawing.Point(90, 5)
        Me.txt_revision_code.MaxLength = 8
        Me.txt_revision_code.Name = "txt_revision_code"
        Me.txt_revision_code.Size = New System.Drawing.Size(93, 20)
        Me.txt_revision_code.TabIndex = 1067
        Me.txt_revision_code.Visible = False
        '
        'Frm_RMS_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(727, 518)
        Me.Controls.Add(Me.btn_new_all)
        Me.Controls.Add(Me.cbo_account_no)
        Me.Controls.Add(Me.txt_seq)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.brn_edit)
        Me.Controls.Add(Me.btn_new)
        Me.Controls.Add(Me.grd_rms)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.cbo_delivery_channel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_organizer_name)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbo_product_name)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_RMS_Edit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.grd_rms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rad_enable_n As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbo_product_name As System.Windows.Forms.ComboBox
    Friend WithEvents rad_enable_y As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_organizer_name As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rad_encryption_n As System.Windows.Forms.RadioButton
    Friend WithEvents rad_encryption_y As System.Windows.Forms.RadioButton
    Friend WithEvents cbo_delivery_channel As System.Windows.Forms.ComboBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rad_delivery_method_manual As System.Windows.Forms.RadioButton
    Friend WithEvents rad_delivery_method_auto As System.Windows.Forms.RadioButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents rad_every_hour_n As System.Windows.Forms.RadioButton
    Friend WithEvents rad_every_hour_y As System.Windows.Forms.RadioButton
    Friend WithEvents grd_rms As System.Windows.Forms.DataGridView
    Friend WithEvents btn_new As System.Windows.Forms.Button
    Friend WithEvents brn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents txt_seq As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_company_id As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbo_account_no As System.Windows.Forms.ComboBox
    Friend WithEvents btn_new_all As System.Windows.Forms.Button
    Friend WithEvents txt_revision_desc As System.Windows.Forms.TextBox
    Friend WithEvents txt_revision_code As System.Windows.Forms.TextBox
End Class
