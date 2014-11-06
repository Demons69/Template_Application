<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_Interface
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
        Me.txt_company_id = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.BT_Update = New System.Windows.Forms.Button
        Me.txt_mapping_code = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_mapping_description = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_description_for_csd = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rad_checksum_flag_n = New System.Windows.Forms.RadioButton
        Me.rad_checksum_flag_y = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbo_checksum_algorithm = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rad_encryption_flag_n = New System.Windows.Forms.RadioButton
        Me.rad_encryption_flag_y = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbo_cryptography_type = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbo_encryption_algorithm = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cbo_key_length = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_encryption_key = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.rad_signing_flag_n = New System.Windows.Forms.RadioButton
        Me.rad_signing_flag_y = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.cbo_signing_type = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cbo_signing_algorithm = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_expiry_date = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.rad_auto_auth_flag_n = New System.Windows.Forms.RadioButton
        Me.rad_auto_auth_flag_y = New System.Windows.Forms.RadioButton
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.cbo_interface_type = New System.Windows.Forms.ComboBox
        Me.btnFind = New System.Windows.Forms.Button
        Me.cbo_interface_code = New System.Windows.Forms.ComboBox
        Me.cbo_process_code = New System.Windows.Forms.ComboBox
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txt_company_id)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(759, 35)
        Me.Panel2.TabIndex = 201
        '
        'txt_company_id
        '
        Me.txt_company_id.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_company_id.Enabled = False
        Me.txt_company_id.Location = New System.Drawing.Point(578, 5)
        Me.txt_company_id.MaxLength = 10
        Me.txt_company_id.Name = "txt_company_id"
        Me.txt_company_id.Size = New System.Drawing.Size(169, 20)
        Me.txt_company_id.TabIndex = 1057
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(499, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 1058
        Me.Label6.Text = "Company Id:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(126, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "INTERFACE"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_close)
        Me.GroupBox2.Controls.Add(Me.BT_Update)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 599)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(747, 51)
        Me.GroupBox2.TabIndex = 1017
        Me.GroupBox2.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(389, 16)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 6
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'BT_Update
        '
        Me.BT_Update.Location = New System.Drawing.Point(274, 16)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(99, 29)
        Me.BT_Update.TabIndex = 5
        Me.BT_Update.Text = "Save"
        Me.BT_Update.UseVisualStyleBackColor = True
        '
        'txt_mapping_code
        '
        Me.txt_mapping_code.Location = New System.Drawing.Point(299, 45)
        Me.txt_mapping_code.MaxLength = 20
        Me.txt_mapping_code.Name = "txt_mapping_code"
        Me.txt_mapping_code.Size = New System.Drawing.Size(249, 20)
        Me.txt_mapping_code.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(191, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 1021
        Me.Label1.Text = "Mapping Code *"
        '
        'txt_mapping_description
        '
        Me.txt_mapping_description.Location = New System.Drawing.Point(299, 71)
        Me.txt_mapping_description.MaxLength = 160
        Me.txt_mapping_description.Name = "txt_mapping_description"
        Me.txt_mapping_description.Size = New System.Drawing.Size(249, 20)
        Me.txt_mapping_description.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(163, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 1023
        Me.Label2.Text = "Mapping Description *"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(190, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 1025
        Me.Label3.Text = "Interface Code *"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(194, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 1027
        Me.Label4.Text = "Process Code *"
        '
        'txt_description_for_csd
        '
        Me.txt_description_for_csd.Location = New System.Drawing.Point(299, 551)
        Me.txt_description_for_csd.MaxLength = 255
        Me.txt_description_for_csd.Name = "txt_description_for_csd"
        Me.txt_description_for_csd.Size = New System.Drawing.Size(249, 20)
        Me.txt_description_for_csd.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(191, 554)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 13)
        Me.Label5.TabIndex = 1029
        Me.Label5.Text = "Description for CSD *"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(187, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 1030
        Me.Label7.Text = "Checksum Flag *"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rad_checksum_flag_n)
        Me.GroupBox1.Controls.Add(Me.rad_checksum_flag_y)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(299, 170)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(179, 36)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'rad_checksum_flag_n
        '
        Me.rad_checksum_flag_n.AutoSize = True
        Me.rad_checksum_flag_n.Checked = True
        Me.rad_checksum_flag_n.Location = New System.Drawing.Point(101, 10)
        Me.rad_checksum_flag_n.Name = "rad_checksum_flag_n"
        Me.rad_checksum_flag_n.Size = New System.Drawing.Size(39, 17)
        Me.rad_checksum_flag_n.TabIndex = 1
        Me.rad_checksum_flag_n.TabStop = True
        Me.rad_checksum_flag_n.Text = "No"
        Me.rad_checksum_flag_n.UseVisualStyleBackColor = True
        '
        'rad_checksum_flag_y
        '
        Me.rad_checksum_flag_y.AutoSize = True
        Me.rad_checksum_flag_y.Location = New System.Drawing.Point(20, 11)
        Me.rad_checksum_flag_y.Name = "rad_checksum_flag_y"
        Me.rad_checksum_flag_y.Size = New System.Drawing.Size(43, 17)
        Me.rad_checksum_flag_y.TabIndex = 0
        Me.rad_checksum_flag_y.Text = "Yes"
        Me.rad_checksum_flag_y.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(168, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 13)
        Me.Label8.TabIndex = 1032
        Me.Label8.Text = "Checksum  Algorithm"
        '
        'cbo_checksum_algorithm
        '
        Me.cbo_checksum_algorithm.Enabled = False
        Me.cbo_checksum_algorithm.FormattingEnabled = True
        Me.cbo_checksum_algorithm.Location = New System.Drawing.Point(299, 213)
        Me.cbo_checksum_algorithm.Name = "cbo_checksum_algorithm"
        Me.cbo_checksum_algorithm.Size = New System.Drawing.Size(205, 21)
        Me.cbo_checksum_algorithm.TabIndex = 5
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rad_encryption_flag_n)
        Me.GroupBox3.Controls.Add(Me.rad_encryption_flag_y)
        Me.GroupBox3.Location = New System.Drawing.Point(299, 238)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(179, 36)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'rad_encryption_flag_n
        '
        Me.rad_encryption_flag_n.AutoSize = True
        Me.rad_encryption_flag_n.Checked = True
        Me.rad_encryption_flag_n.Location = New System.Drawing.Point(101, 10)
        Me.rad_encryption_flag_n.Name = "rad_encryption_flag_n"
        Me.rad_encryption_flag_n.Size = New System.Drawing.Size(39, 17)
        Me.rad_encryption_flag_n.TabIndex = 1
        Me.rad_encryption_flag_n.TabStop = True
        Me.rad_encryption_flag_n.Text = "No"
        Me.rad_encryption_flag_n.UseVisualStyleBackColor = True
        '
        'rad_encryption_flag_y
        '
        Me.rad_encryption_flag_y.AutoSize = True
        Me.rad_encryption_flag_y.Location = New System.Drawing.Point(20, 11)
        Me.rad_encryption_flag_y.Name = "rad_encryption_flag_y"
        Me.rad_encryption_flag_y.Size = New System.Drawing.Size(43, 17)
        Me.rad_encryption_flag_y.TabIndex = 0
        Me.rad_encryption_flag_y.Text = "Yes"
        Me.rad_encryption_flag_y.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(194, 250)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 1034
        Me.Label9.Text = "Encryption Flag"
        '
        'cbo_cryptography_type
        '
        Me.cbo_cryptography_type.Enabled = False
        Me.cbo_cryptography_type.FormattingEnabled = True
        Me.cbo_cryptography_type.Location = New System.Drawing.Point(299, 280)
        Me.cbo_cryptography_type.Name = "cbo_cryptography_type"
        Me.cbo_cryptography_type.Size = New System.Drawing.Size(205, 21)
        Me.cbo_cryptography_type.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(178, 283)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 13)
        Me.Label10.TabIndex = 1036
        Me.Label10.Text = "Cryptography Type"
        '
        'cbo_encryption_algorithm
        '
        Me.cbo_encryption_algorithm.Enabled = False
        Me.cbo_encryption_algorithm.FormattingEnabled = True
        Me.cbo_encryption_algorithm.Location = New System.Drawing.Point(299, 307)
        Me.cbo_encryption_algorithm.Name = "cbo_encryption_algorithm"
        Me.cbo_encryption_algorithm.Size = New System.Drawing.Size(205, 21)
        Me.cbo_encryption_algorithm.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(171, 310)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 13)
        Me.Label11.TabIndex = 1038
        Me.Label11.Text = "Encryption Algorithm"
        '
        'cbo_key_length
        '
        Me.cbo_key_length.Enabled = False
        Me.cbo_key_length.FormattingEnabled = True
        Me.cbo_key_length.Location = New System.Drawing.Point(299, 334)
        Me.cbo_key_length.Name = "cbo_key_length"
        Me.cbo_key_length.Size = New System.Drawing.Size(205, 21)
        Me.cbo_key_length.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(217, 337)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 1040
        Me.Label12.Text = "Key length"
        '
        'txt_encryption_key
        '
        Me.txt_encryption_key.Enabled = False
        Me.txt_encryption_key.Location = New System.Drawing.Point(298, 361)
        Me.txt_encryption_key.MaxLength = 255
        Me.txt_encryption_key.Name = "txt_encryption_key"
        Me.txt_encryption_key.Size = New System.Drawing.Size(249, 20)
        Me.txt_encryption_key.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(196, 364)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 1043
        Me.Label13.Text = "Encryption Key"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rad_signing_flag_n)
        Me.GroupBox4.Controls.Add(Me.rad_signing_flag_y)
        Me.GroupBox4.Location = New System.Drawing.Point(299, 387)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(179, 36)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        '
        'rad_signing_flag_n
        '
        Me.rad_signing_flag_n.AutoSize = True
        Me.rad_signing_flag_n.Checked = True
        Me.rad_signing_flag_n.Location = New System.Drawing.Point(101, 10)
        Me.rad_signing_flag_n.Name = "rad_signing_flag_n"
        Me.rad_signing_flag_n.Size = New System.Drawing.Size(39, 17)
        Me.rad_signing_flag_n.TabIndex = 1
        Me.rad_signing_flag_n.TabStop = True
        Me.rad_signing_flag_n.Text = "No"
        Me.rad_signing_flag_n.UseVisualStyleBackColor = True
        '
        'rad_signing_flag_y
        '
        Me.rad_signing_flag_y.AutoSize = True
        Me.rad_signing_flag_y.Location = New System.Drawing.Point(20, 11)
        Me.rad_signing_flag_y.Name = "rad_signing_flag_y"
        Me.rad_signing_flag_y.Size = New System.Drawing.Size(43, 17)
        Me.rad_signing_flag_y.TabIndex = 0
        Me.rad_signing_flag_y.Text = "Yes"
        Me.rad_signing_flag_y.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(209, 399)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 1044
        Me.Label14.Text = "Signing Flag"
        '
        'cbo_signing_type
        '
        Me.cbo_signing_type.Enabled = False
        Me.cbo_signing_type.FormattingEnabled = True
        Me.cbo_signing_type.Location = New System.Drawing.Point(299, 429)
        Me.cbo_signing_type.Name = "cbo_signing_type"
        Me.cbo_signing_type.Size = New System.Drawing.Size(205, 21)
        Me.cbo_signing_type.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(205, 432)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 13)
        Me.Label15.TabIndex = 1046
        Me.Label15.Text = "Signing Type"
        '
        'cbo_signing_algorithm
        '
        Me.cbo_signing_algorithm.Enabled = False
        Me.cbo_signing_algorithm.FormattingEnabled = True
        Me.cbo_signing_algorithm.Location = New System.Drawing.Point(299, 456)
        Me.cbo_signing_algorithm.Name = "cbo_signing_algorithm"
        Me.cbo_signing_algorithm.Size = New System.Drawing.Size(205, 21)
        Me.cbo_signing_algorithm.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(186, 459)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 13)
        Me.Label16.TabIndex = 1048
        Me.Label16.Text = "Signing Algorithm"
        '
        'txt_expiry_date
        '
        Me.txt_expiry_date.Enabled = False
        Me.txt_expiry_date.Location = New System.Drawing.Point(299, 483)
        Me.txt_expiry_date.MaxLength = 10
        Me.txt_expiry_date.Name = "txt_expiry_date"
        Me.txt_expiry_date.Size = New System.Drawing.Size(140, 20)
        Me.txt_expiry_date.TabIndex = 14
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(215, 486)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 13)
        Me.Label18.TabIndex = 1051
        Me.Label18.Text = "Expiry date"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(445, 486)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 13)
        Me.Label19.TabIndex = 1052
        Me.Label19.Text = "(DD/MM/YYYY)"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rad_auto_auth_flag_n)
        Me.GroupBox5.Controls.Add(Me.rad_auto_auth_flag_y)
        Me.GroupBox5.Location = New System.Drawing.Point(299, 509)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(179, 36)
        Me.GroupBox5.TabIndex = 15
        Me.GroupBox5.TabStop = False
        '
        'rad_auto_auth_flag_n
        '
        Me.rad_auto_auth_flag_n.AutoSize = True
        Me.rad_auto_auth_flag_n.Checked = True
        Me.rad_auto_auth_flag_n.Location = New System.Drawing.Point(101, 10)
        Me.rad_auto_auth_flag_n.Name = "rad_auto_auth_flag_n"
        Me.rad_auto_auth_flag_n.Size = New System.Drawing.Size(39, 17)
        Me.rad_auto_auth_flag_n.TabIndex = 1
        Me.rad_auto_auth_flag_n.TabStop = True
        Me.rad_auto_auth_flag_n.Text = "No"
        Me.rad_auto_auth_flag_n.UseVisualStyleBackColor = True
        '
        'rad_auto_auth_flag_y
        '
        Me.rad_auto_auth_flag_y.AutoSize = True
        Me.rad_auto_auth_flag_y.Location = New System.Drawing.Point(20, 11)
        Me.rad_auto_auth_flag_y.Name = "rad_auto_auth_flag_y"
        Me.rad_auto_auth_flag_y.Size = New System.Drawing.Size(43, 17)
        Me.rad_auto_auth_flag_y.TabIndex = 0
        Me.rad_auto_auth_flag_y.Text = "Yes"
        Me.rad_auto_auth_flag_y.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(209, 521)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 13)
        Me.Label20.TabIndex = 1053
        Me.Label20.Text = "Auto Auth Flag"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(190, 100)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 13)
        Me.Label21.TabIndex = 1055
        Me.Label21.Text = "Interface Type *"
        '
        'cbo_interface_type
        '
        Me.cbo_interface_type.FormattingEnabled = True
        Me.cbo_interface_type.Location = New System.Drawing.Point(298, 94)
        Me.cbo_interface_type.Name = "cbo_interface_type"
        Me.cbo_interface_type.Size = New System.Drawing.Size(205, 21)
        Me.cbo_interface_type.TabIndex = 2
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(554, 45)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(132, 22)
        Me.btnFind.TabIndex = 1057
        Me.btnFind.Text = "Copy From Template"
        Me.btnFind.UseVisualStyleBackColor = True
        Me.btnFind.Visible = False
        '
        'cbo_interface_code
        '
        Me.cbo_interface_code.FormattingEnabled = True
        Me.cbo_interface_code.Location = New System.Drawing.Point(298, 121)
        Me.cbo_interface_code.Name = "cbo_interface_code"
        Me.cbo_interface_code.Size = New System.Drawing.Size(205, 21)
        Me.cbo_interface_code.TabIndex = 3
        '
        'cbo_process_code
        '
        Me.cbo_process_code.FormattingEnabled = True
        Me.cbo_process_code.Location = New System.Drawing.Point(298, 150)
        Me.cbo_process_code.Name = "cbo_process_code"
        Me.cbo_process_code.Size = New System.Drawing.Size(205, 21)
        Me.cbo_process_code.TabIndex = 4
        '
        'Frm_DealSummary_Interface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 663)
        Me.Controls.Add(Me.cbo_process_code)
        Me.Controls.Add(Me.cbo_interface_code)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.cbo_interface_type)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txt_expiry_date)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cbo_signing_algorithm)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cbo_signing_type)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txt_encryption_key)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cbo_key_length)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cbo_encryption_algorithm)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cbo_cryptography_type)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbo_checksum_algorithm)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_description_for_csd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_mapping_description)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_mapping_code)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Frm_DealSummary_Interface"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents txt_mapping_code As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_mapping_description As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_description_for_csd As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_company_id As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rad_checksum_flag_n As System.Windows.Forms.RadioButton
    Friend WithEvents rad_checksum_flag_y As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbo_checksum_algorithm As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rad_encryption_flag_n As System.Windows.Forms.RadioButton
    Friend WithEvents rad_encryption_flag_y As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbo_cryptography_type As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbo_encryption_algorithm As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbo_key_length As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_encryption_key As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rad_signing_flag_n As System.Windows.Forms.RadioButton
    Friend WithEvents rad_signing_flag_y As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbo_signing_type As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbo_signing_algorithm As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_expiry_date As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rad_auto_auth_flag_n As System.Windows.Forms.RadioButton
    Friend WithEvents rad_auto_auth_flag_y As System.Windows.Forms.RadioButton
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbo_interface_type As System.Windows.Forms.ComboBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents cbo_interface_code As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_process_code As System.Windows.Forms.ComboBox
End Class
