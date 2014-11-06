<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_User
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txt_revision_desc = New System.Windows.Forms.TextBox
        Me.txt_revision_code = New System.Windows.Forms.TextBox
        Me.txt_company_id_parent = New System.Windows.Forms.TextBox
        Me.txt_temp = New System.Windows.Forms.TextBox
        Me.txt_company_id = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.lbHead = New System.Windows.Forms.Label
        Me.grp_tool = New System.Windows.Forms.GroupBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.BT_Update = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_firstname = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_lastname = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_user_id = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_date_of_birth = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_reference_no = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_phone = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_mobile_phone = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.chk_view_bill_payment_flag = New System.Windows.Forms.CheckBox
        Me.chk_view_sq_flag = New System.Windows.Forms.CheckBox
        Me.chk_view_acc_stt_flag = New System.Windows.Forms.CheckBox
        Me.chk_payment_verifier_flag = New System.Windows.Forms.CheckBox
        Me.chk_payment_maker_flag = New System.Windows.Forms.CheckBox
        Me.chk_admin_maker_flag = New System.Windows.Forms.CheckBox
        Me.chk_payment_sender_flag = New System.Windows.Forms.CheckBox
        Me.chk_payment_authoriser_flag = New System.Windows.Forms.CheckBox
        Me.chk_across_client_flag = New System.Windows.Forms.CheckBox
        Me.chk_super_user_flag = New System.Windows.Forms.CheckBox
        Me.chk_view_confidential_flag = New System.Windows.Forms.CheckBox
        Me.chk_admin_authoriser_flag = New System.Windows.Forms.CheckBox
        Me.cbo_gender = New System.Windows.Forms.ComboBox
        Me.cbo_title = New System.Windows.Forms.ComboBox
        Me.cbo_log_in_method = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cbo_auth_method = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_token_no = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_email = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txt_fax = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cbo_reference_type = New System.Windows.Forms.ComboBox
        Me.cbo_User_Category_ID = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cbo_Report_Category_ID = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.btn_ChangeCategory = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.txt_gcp_service_end_date = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.btn_account_all = New System.Windows.Forms.Button
        Me.btn_account_clear = New System.Windows.Forms.Button
        Me.btn_product_clear = New System.Windows.Forms.Button
        Me.btn_product_all = New System.Windows.Forms.Button
        Me.lst_across_client_code = New System.Windows.Forms.CheckedListBox
        Me.btn_client_clear = New System.Windows.Forms.Button
        Me.btn_client_all = New System.Windows.Forms.Button
        Me.lb_company_id = New System.Windows.Forms.Label
        Me.chk_non_cms_stop_pay = New System.Windows.Forms.CheckBox
        Me.chk_non_cms_stop_pay_auth = New System.Windows.Forms.CheckBox
        Me.cbo_event_template = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.btn_clear_category = New System.Windows.Forms.Button
        Me.chk_si_maker_flag = New System.Windows.Forms.CheckBox
        Me.chk_si_authoriser_flag = New System.Windows.Forms.CheckBox
        Me.btn_PaymentMaker = New System.Windows.Forms.Button
        Me.btn_PaymentAuth = New System.Windows.Forms.Button
        Me.btn_Admin = New System.Windows.Forms.Button
        Me.grd_account = New System.Windows.Forms.DataGridView
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Account = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.view_acc_stt_flag = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.view_sq_flag = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.payment_flag = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.IDX = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.company_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grd_product = New System.Windows.Forms.DataGridView
        Me.pSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Product = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pCompany_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pIdx = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2.SuspendLayout()
        Me.grp_tool.SuspendLayout()
        CType(Me.grd_account, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_product, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txt_revision_desc)
        Me.Panel2.Controls.Add(Me.txt_revision_code)
        Me.Panel2.Controls.Add(Me.txt_company_id_parent)
        Me.Panel2.Controls.Add(Me.txt_temp)
        Me.Panel2.Controls.Add(Me.txt_company_id)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.lbHead)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1026, 35)
        Me.Panel2.TabIndex = 198
        '
        'txt_revision_desc
        '
        Me.txt_revision_desc.Location = New System.Drawing.Point(408, 7)
        Me.txt_revision_desc.MaxLength = 8
        Me.txt_revision_desc.Name = "txt_revision_desc"
        Me.txt_revision_desc.Size = New System.Drawing.Size(215, 20)
        Me.txt_revision_desc.TabIndex = 1064
        Me.txt_revision_desc.Visible = False
        '
        'txt_revision_code
        '
        Me.txt_revision_code.Location = New System.Drawing.Point(309, 7)
        Me.txt_revision_code.MaxLength = 8
        Me.txt_revision_code.Name = "txt_revision_code"
        Me.txt_revision_code.Size = New System.Drawing.Size(93, 20)
        Me.txt_revision_code.TabIndex = 1063
        Me.txt_revision_code.Visible = False
        '
        'txt_company_id_parent
        '
        Me.txt_company_id_parent.Location = New System.Drawing.Point(206, 7)
        Me.txt_company_id_parent.MaxLength = 0
        Me.txt_company_id_parent.Name = "txt_company_id_parent"
        Me.txt_company_id_parent.Size = New System.Drawing.Size(32, 20)
        Me.txt_company_id_parent.TabIndex = 1062
        Me.txt_company_id_parent.Visible = False
        '
        'txt_temp
        '
        Me.txt_temp.Location = New System.Drawing.Point(244, 9)
        Me.txt_temp.MaxLength = 0
        Me.txt_temp.Name = "txt_temp"
        Me.txt_temp.Size = New System.Drawing.Size(31, 20)
        Me.txt_temp.TabIndex = 1061
        Me.txt_temp.Visible = False
        '
        'txt_company_id
        '
        Me.txt_company_id.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_company_id.Enabled = False
        Me.txt_company_id.Location = New System.Drawing.Point(805, 7)
        Me.txt_company_id.MaxLength = 10
        Me.txt_company_id.Name = "txt_company_id"
        Me.txt_company_id.Size = New System.Drawing.Size(169, 20)
        Me.txt_company_id.TabIndex = 1059
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label24.Location = New System.Drawing.Point(726, 10)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 13)
        Me.Label24.TabIndex = 1060
        Me.Label24.Text = "Company Id:"
        '
        'lbHead
        '
        Me.lbHead.AutoSize = True
        Me.lbHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbHead.ForeColor = System.Drawing.Color.Navy
        Me.lbHead.Location = New System.Drawing.Point(13, 5)
        Me.lbHead.Name = "lbHead"
        Me.lbHead.Size = New System.Drawing.Size(65, 24)
        Me.lbHead.TabIndex = 0
        Me.lbHead.Text = "USER"
        '
        'grp_tool
        '
        Me.grp_tool.Controls.Add(Me.bt_close)
        Me.grp_tool.Controls.Add(Me.BT_Update)
        Me.grp_tool.Location = New System.Drawing.Point(12, 500)
        Me.grp_tool.Name = "grp_tool"
        Me.grp_tool.Size = New System.Drawing.Size(1007, 51)
        Me.grp_tool.TabIndex = 1017
        Me.grp_tool.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(465, 16)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 31
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'BT_Update
        '
        Me.BT_Update.Location = New System.Drawing.Point(350, 16)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(99, 29)
        Me.BT_Update.TabIndex = 30
        Me.BT_Update.Text = "Save"
        Me.BT_Update.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 1021
        Me.Label1.Text = "Gender*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(86, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 1023
        Me.Label2.Text = "Title*"
        '
        'txt_firstname
        '
        Me.txt_firstname.Location = New System.Drawing.Point(122, 91)
        Me.txt_firstname.MaxLength = 64
        Me.txt_firstname.Name = "txt_firstname"
        Me.txt_firstname.Size = New System.Drawing.Size(249, 20)
        Me.txt_firstname.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 1025
        Me.Label3.Text = "User First Name (En)*"
        '
        'txt_lastname
        '
        Me.txt_lastname.Location = New System.Drawing.Point(122, 117)
        Me.txt_lastname.MaxLength = 64
        Me.txt_lastname.Name = "txt_lastname"
        Me.txt_lastname.Size = New System.Drawing.Size(249, 20)
        Me.txt_lastname.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 13)
        Me.Label4.TabIndex = 1027
        Me.Label4.Text = "User Last Name (En)*"
        '
        'txt_user_id
        '
        Me.txt_user_id.Location = New System.Drawing.Point(122, 143)
        Me.txt_user_id.MaxLength = 100
        Me.txt_user_id.Name = "txt_user_id"
        Me.txt_user_id.Size = New System.Drawing.Size(128, 20)
        Me.txt_user_id.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(70, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 1029
        Me.Label5.Text = "User ID*"
        '
        'txt_date_of_birth
        '
        Me.txt_date_of_birth.Location = New System.Drawing.Point(122, 169)
        Me.txt_date_of_birth.MaxLength = 0
        Me.txt_date_of_birth.Name = "txt_date_of_birth"
        Me.txt_date_of_birth.Size = New System.Drawing.Size(128, 20)
        Me.txt_date_of_birth.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(47, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 1031
        Me.Label6.Text = "Date of Birth*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 198)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 1033
        Me.Label7.Text = "Reference Type*"
        '
        'txt_reference_no
        '
        Me.txt_reference_no.Location = New System.Drawing.Point(122, 221)
        Me.txt_reference_no.MaxLength = 32
        Me.txt_reference_no.Name = "txt_reference_no"
        Me.txt_reference_no.Size = New System.Drawing.Size(249, 20)
        Me.txt_reference_no.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(36, 224)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 1035
        Me.Label8.Text = "Reference No.*"
        '
        'txt_phone
        '
        Me.txt_phone.Location = New System.Drawing.Point(122, 247)
        Me.txt_phone.MaxLength = 50
        Me.txt_phone.Name = "txt_phone"
        Me.txt_phone.Size = New System.Drawing.Size(249, 20)
        Me.txt_phone.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(75, 250)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 1037
        Me.Label9.Text = "Phone"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(256, 172)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 1038
        Me.Label10.Text = "(DD/MM/YYYY)"
        '
        'txt_mobile_phone
        '
        Me.txt_mobile_phone.Location = New System.Drawing.Point(122, 273)
        Me.txt_mobile_phone.MaxLength = 12
        Me.txt_mobile_phone.Name = "txt_mobile_phone"
        Me.txt_mobile_phone.Size = New System.Drawing.Size(249, 20)
        Me.txt_mobile_phone.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(41, 276)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 1040
        Me.Label11.Text = "Mobile Phone*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(386, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 1071
        Me.Label12.Text = "Menu :"
        '
        'chk_view_bill_payment_flag
        '
        Me.chk_view_bill_payment_flag.AutoSize = True
        Me.chk_view_bill_payment_flag.Location = New System.Drawing.Point(388, 112)
        Me.chk_view_bill_payment_flag.Name = "chk_view_bill_payment_flag"
        Me.chk_view_bill_payment_flag.Size = New System.Drawing.Size(109, 17)
        Me.chk_view_bill_payment_flag.TabIndex = 17
        Me.chk_view_bill_payment_flag.Text = "View Bill Payment"
        Me.chk_view_bill_payment_flag.UseVisualStyleBackColor = True
        '
        'chk_view_sq_flag
        '
        Me.chk_view_sq_flag.AutoSize = True
        Me.chk_view_sq_flag.Location = New System.Drawing.Point(388, 89)
        Me.chk_view_sq_flag.Name = "chk_view_sq_flag"
        Me.chk_view_sq_flag.Size = New System.Drawing.Size(67, 17)
        Me.chk_view_sq_flag.TabIndex = 16
        Me.chk_view_sq_flag.Text = "View SQ"
        Me.chk_view_sq_flag.UseVisualStyleBackColor = True
        '
        'chk_view_acc_stt_flag
        '
        Me.chk_view_acc_stt_flag.AutoSize = True
        Me.chk_view_acc_stt_flag.Location = New System.Drawing.Point(388, 66)
        Me.chk_view_acc_stt_flag.Name = "chk_view_acc_stt_flag"
        Me.chk_view_acc_stt_flag.Size = New System.Drawing.Size(90, 17)
        Me.chk_view_acc_stt_flag.TabIndex = 15
        Me.chk_view_acc_stt_flag.Text = "View Acc.Stt."
        Me.chk_view_acc_stt_flag.UseVisualStyleBackColor = True
        '
        'chk_payment_verifier_flag
        '
        Me.chk_payment_verifier_flag.AutoSize = True
        Me.chk_payment_verifier_flag.Location = New System.Drawing.Point(388, 160)
        Me.chk_payment_verifier_flag.Name = "chk_payment_verifier_flag"
        Me.chk_payment_verifier_flag.Size = New System.Drawing.Size(102, 17)
        Me.chk_payment_verifier_flag.TabIndex = 19
        Me.chk_payment_verifier_flag.Text = "Payment Verifier"
        Me.chk_payment_verifier_flag.UseVisualStyleBackColor = True
        '
        'chk_payment_maker_flag
        '
        Me.chk_payment_maker_flag.AutoSize = True
        Me.chk_payment_maker_flag.Location = New System.Drawing.Point(388, 135)
        Me.chk_payment_maker_flag.Name = "chk_payment_maker_flag"
        Me.chk_payment_maker_flag.Size = New System.Drawing.Size(100, 17)
        Me.chk_payment_maker_flag.TabIndex = 18
        Me.chk_payment_maker_flag.Text = "Payment Maker"
        Me.chk_payment_maker_flag.UseVisualStyleBackColor = True
        '
        'chk_admin_maker_flag
        '
        Me.chk_admin_maker_flag.AutoSize = True
        Me.chk_admin_maker_flag.Location = New System.Drawing.Point(388, 229)
        Me.chk_admin_maker_flag.Name = "chk_admin_maker_flag"
        Me.chk_admin_maker_flag.Size = New System.Drawing.Size(88, 17)
        Me.chk_admin_maker_flag.TabIndex = 22
        Me.chk_admin_maker_flag.Text = "Admin Maker"
        Me.chk_admin_maker_flag.UseVisualStyleBackColor = True
        '
        'chk_payment_sender_flag
        '
        Me.chk_payment_sender_flag.AutoSize = True
        Me.chk_payment_sender_flag.Location = New System.Drawing.Point(388, 206)
        Me.chk_payment_sender_flag.Name = "chk_payment_sender_flag"
        Me.chk_payment_sender_flag.Size = New System.Drawing.Size(104, 17)
        Me.chk_payment_sender_flag.TabIndex = 21
        Me.chk_payment_sender_flag.Text = "Payment Sender"
        Me.chk_payment_sender_flag.UseVisualStyleBackColor = True
        '
        'chk_payment_authoriser_flag
        '
        Me.chk_payment_authoriser_flag.AutoSize = True
        Me.chk_payment_authoriser_flag.Location = New System.Drawing.Point(388, 183)
        Me.chk_payment_authoriser_flag.Name = "chk_payment_authoriser_flag"
        Me.chk_payment_authoriser_flag.Size = New System.Drawing.Size(117, 17)
        Me.chk_payment_authoriser_flag.TabIndex = 20
        Me.chk_payment_authoriser_flag.Text = "Payment Authoriser"
        Me.chk_payment_authoriser_flag.UseVisualStyleBackColor = True
        '
        'chk_across_client_flag
        '
        Me.chk_across_client_flag.AutoSize = True
        Me.chk_across_client_flag.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chk_across_client_flag.Location = New System.Drawing.Point(387, 331)
        Me.chk_across_client_flag.Name = "chk_across_client_flag"
        Me.chk_across_client_flag.Size = New System.Drawing.Size(87, 17)
        Me.chk_across_client_flag.TabIndex = 27
        Me.chk_across_client_flag.Text = "Across Client"
        Me.chk_across_client_flag.UseVisualStyleBackColor = True
        '
        'chk_super_user_flag
        '
        Me.chk_super_user_flag.AutoSize = True
        Me.chk_super_user_flag.Location = New System.Drawing.Point(387, 298)
        Me.chk_super_user_flag.Name = "chk_super_user_flag"
        Me.chk_super_user_flag.Size = New System.Drawing.Size(79, 17)
        Me.chk_super_user_flag.TabIndex = 26
        Me.chk_super_user_flag.Text = "Super User"
        Me.chk_super_user_flag.UseVisualStyleBackColor = True
        '
        'chk_view_confidential_flag
        '
        Me.chk_view_confidential_flag.AutoSize = True
        Me.chk_view_confidential_flag.Location = New System.Drawing.Point(507, 301)
        Me.chk_view_confidential_flag.Name = "chk_view_confidential_flag"
        Me.chk_view_confidential_flag.Size = New System.Drawing.Size(107, 17)
        Me.chk_view_confidential_flag.TabIndex = 24
        Me.chk_view_confidential_flag.Text = "View Confidential"
        Me.chk_view_confidential_flag.UseVisualStyleBackColor = True
        '
        'chk_admin_authoriser_flag
        '
        Me.chk_admin_authoriser_flag.AutoSize = True
        Me.chk_admin_authoriser_flag.Location = New System.Drawing.Point(387, 252)
        Me.chk_admin_authoriser_flag.Name = "chk_admin_authoriser_flag"
        Me.chk_admin_authoriser_flag.Size = New System.Drawing.Size(105, 17)
        Me.chk_admin_authoriser_flag.TabIndex = 23
        Me.chk_admin_authoriser_flag.Text = "Admin Authoriser"
        Me.chk_admin_authoriser_flag.UseVisualStyleBackColor = True
        '
        'cbo_gender
        '
        Me.cbo_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_gender.FormattingEnabled = True
        Me.cbo_gender.Location = New System.Drawing.Point(122, 39)
        Me.cbo_gender.Name = "cbo_gender"
        Me.cbo_gender.Size = New System.Drawing.Size(249, 21)
        Me.cbo_gender.TabIndex = 0
        '
        'cbo_title
        '
        Me.cbo_title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_title.FormattingEnabled = True
        Me.cbo_title.Location = New System.Drawing.Point(122, 66)
        Me.cbo_title.Name = "cbo_title"
        Me.cbo_title.Size = New System.Drawing.Size(249, 21)
        Me.cbo_title.TabIndex = 1
        '
        'cbo_log_in_method
        '
        Me.cbo_log_in_method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_log_in_method.DropDownWidth = 380
        Me.cbo_log_in_method.FormattingEnabled = True
        Me.cbo_log_in_method.Location = New System.Drawing.Point(122, 301)
        Me.cbo_log_in_method.Name = "cbo_log_in_method"
        Me.cbo_log_in_method.Size = New System.Drawing.Size(249, 21)
        Me.cbo_log_in_method.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(39, 304)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 1090
        Me.Label13.Text = "Log in method*"
        '
        'cbo_auth_method
        '
        Me.cbo_auth_method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_auth_method.Enabled = False
        Me.cbo_auth_method.FormattingEnabled = True
        Me.cbo_auth_method.Location = New System.Drawing.Point(122, 327)
        Me.cbo_auth_method.Name = "cbo_auth_method"
        Me.cbo_auth_method.Size = New System.Drawing.Size(249, 21)
        Me.cbo_auth_method.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(45, 330)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 13)
        Me.Label14.TabIndex = 1092
        Me.Label14.Text = "Auth Method*"
        '
        'txt_token_no
        '
        Me.txt_token_no.Location = New System.Drawing.Point(122, 380)
        Me.txt_token_no.MaxLength = 20
        Me.txt_token_no.Name = "txt_token_no"
        Me.txt_token_no.Size = New System.Drawing.Size(249, 20)
        Me.txt_token_no.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(55, 383)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 1097
        Me.Label15.Text = "Token No."
        '
        'txt_email
        '
        Me.txt_email.Location = New System.Drawing.Point(122, 354)
        Me.txt_email.MaxLength = 100
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(249, 20)
        Me.txt_email.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(81, 357)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 1095
        Me.Label16.Text = "Email*"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(676, 69)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 13)
        Me.Label18.TabIndex = 1099
        Me.Label18.Text = "Account"
        '
        'txt_fax
        '
        Me.txt_fax.Location = New System.Drawing.Point(122, 406)
        Me.txt_fax.MaxLength = 20
        Me.txt_fax.Name = "txt_fax"
        Me.txt_fax.Size = New System.Drawing.Size(249, 20)
        Me.txt_fax.TabIndex = 14
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(89, 409)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 13)
        Me.Label19.TabIndex = 1103
        Me.Label19.Text = "Fax*"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(679, 247)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 1104
        Me.Label20.Text = "Product"
        '
        'cbo_reference_type
        '
        Me.cbo_reference_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_reference_type.FormattingEnabled = True
        Me.cbo_reference_type.Location = New System.Drawing.Point(122, 194)
        Me.cbo_reference_type.Name = "cbo_reference_type"
        Me.cbo_reference_type.Size = New System.Drawing.Size(249, 21)
        Me.cbo_reference_type.TabIndex = 6
        '
        'cbo_User_Category_ID
        '
        Me.cbo_User_Category_ID.FormattingEnabled = True
        Me.cbo_User_Category_ID.Location = New System.Drawing.Point(814, 414)
        Me.cbo_User_Category_ID.Name = "cbo_User_Category_ID"
        Me.cbo_User_Category_ID.Size = New System.Drawing.Size(201, 21)
        Me.cbo_User_Category_ID.TabIndex = 30
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(736, 417)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(74, 13)
        Me.Label21.TabIndex = 1106
        Me.Label21.Text = "User Category"
        '
        'cbo_Report_Category_ID
        '
        Me.cbo_Report_Category_ID.FormattingEnabled = True
        Me.cbo_Report_Category_ID.Location = New System.Drawing.Point(814, 441)
        Me.cbo_Report_Category_ID.Name = "cbo_Report_Category_ID"
        Me.cbo_Report_Category_ID.Size = New System.Drawing.Size(201, 21)
        Me.cbo_Report_Category_ID.TabIndex = 31
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(723, 444)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 13)
        Me.Label22.TabIndex = 1108
        Me.Label22.Text = "Report Category"
        '
        'btn_ChangeCategory
        '
        Me.btn_ChangeCategory.Location = New System.Drawing.Point(917, 473)
        Me.btn_ChangeCategory.Name = "btn_ChangeCategory"
        Me.btn_ChangeCategory.Size = New System.Drawing.Size(99, 29)
        Me.btn_ChangeCategory.TabIndex = 1109
        Me.btn_ChangeCategory.Text = "Change Category"
        Me.btn_ChangeCategory.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(256, 462)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(85, 13)
        Me.Label23.TabIndex = 1112
        Me.Label23.Text = "(DD/MM/YYYY)"
        '
        'txt_gcp_service_end_date
        '
        Me.txt_gcp_service_end_date.Enabled = False
        Me.txt_gcp_service_end_date.Location = New System.Drawing.Point(122, 459)
        Me.txt_gcp_service_end_date.MaxLength = 0
        Me.txt_gcp_service_end_date.Name = "txt_gcp_service_end_date"
        Me.txt_gcp_service_end_date.Size = New System.Drawing.Size(128, 20)
        Me.txt_gcp_service_end_date.TabIndex = 16
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(0, 462)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(116, 13)
        Me.Label25.TabIndex = 1111
        Me.Label25.Text = "GCP Service End Date"
        '
        'btn_account_all
        '
        Me.btn_account_all.Location = New System.Drawing.Point(873, 54)
        Me.btn_account_all.Name = "btn_account_all"
        Me.btn_account_all.Size = New System.Drawing.Size(70, 25)
        Me.btn_account_all.TabIndex = 1113
        Me.btn_account_all.Text = "Select All"
        Me.btn_account_all.UseVisualStyleBackColor = True
        '
        'btn_account_clear
        '
        Me.btn_account_clear.Location = New System.Drawing.Point(949, 54)
        Me.btn_account_clear.Name = "btn_account_clear"
        Me.btn_account_clear.Size = New System.Drawing.Size(70, 25)
        Me.btn_account_clear.TabIndex = 1114
        Me.btn_account_clear.Text = "Clear All"
        Me.btn_account_clear.UseVisualStyleBackColor = True
        '
        'btn_product_clear
        '
        Me.btn_product_clear.Location = New System.Drawing.Point(945, 234)
        Me.btn_product_clear.Name = "btn_product_clear"
        Me.btn_product_clear.Size = New System.Drawing.Size(70, 25)
        Me.btn_product_clear.TabIndex = 1116
        Me.btn_product_clear.Text = "Clear All"
        Me.btn_product_clear.UseVisualStyleBackColor = True
        '
        'btn_product_all
        '
        Me.btn_product_all.Location = New System.Drawing.Point(869, 234)
        Me.btn_product_all.Name = "btn_product_all"
        Me.btn_product_all.Size = New System.Drawing.Size(70, 25)
        Me.btn_product_all.TabIndex = 1115
        Me.btn_product_all.Text = "Select All"
        Me.btn_product_all.UseVisualStyleBackColor = True
        '
        'lst_across_client_code
        '
        Me.lst_across_client_code.CheckOnClick = True
        Me.lst_across_client_code.FormattingEnabled = True
        Me.lst_across_client_code.Location = New System.Drawing.Point(387, 371)
        Me.lst_across_client_code.Name = "lst_across_client_code"
        Me.lst_across_client_code.Size = New System.Drawing.Size(274, 124)
        Me.lst_across_client_code.TabIndex = 28
        '
        'btn_client_clear
        '
        Me.btn_client_clear.Location = New System.Drawing.Point(591, 343)
        Me.btn_client_clear.Name = "btn_client_clear"
        Me.btn_client_clear.Size = New System.Drawing.Size(70, 25)
        Me.btn_client_clear.TabIndex = 1118
        Me.btn_client_clear.Text = "Clear All"
        Me.btn_client_clear.UseVisualStyleBackColor = True
        '
        'btn_client_all
        '
        Me.btn_client_all.Location = New System.Drawing.Point(515, 343)
        Me.btn_client_all.Name = "btn_client_all"
        Me.btn_client_all.Size = New System.Drawing.Size(70, 25)
        Me.btn_client_all.TabIndex = 1117
        Me.btn_client_all.Text = "Select All"
        Me.btn_client_all.UseVisualStyleBackColor = True
        '
        'lb_company_id
        '
        Me.lb_company_id.AutoSize = True
        Me.lb_company_id.Location = New System.Drawing.Point(256, 147)
        Me.lb_company_id.Name = "lb_company_id"
        Me.lb_company_id.Size = New System.Drawing.Size(98, 13)
        Me.lb_company_id.TabIndex = 1119
        Me.lb_company_id.Text = "XXXXXXXXXXXXX"
        '
        'chk_non_cms_stop_pay
        '
        Me.chk_non_cms_stop_pay.AutoSize = True
        Me.chk_non_cms_stop_pay.Location = New System.Drawing.Point(512, 65)
        Me.chk_non_cms_stop_pay.Name = "chk_non_cms_stop_pay"
        Me.chk_non_cms_stop_pay.Size = New System.Drawing.Size(137, 17)
        Me.chk_non_cms_stop_pay.TabIndex = 28
        Me.chk_non_cms_stop_pay.Text = "Stop Corporate Cheque"
        Me.chk_non_cms_stop_pay.UseVisualStyleBackColor = True
        '
        'chk_non_cms_stop_pay_auth
        '
        Me.chk_non_cms_stop_pay_auth.AutoSize = True
        Me.chk_non_cms_stop_pay_auth.Location = New System.Drawing.Point(512, 88)
        Me.chk_non_cms_stop_pay_auth.Name = "chk_non_cms_stop_pay_auth"
        Me.chk_non_cms_stop_pay_auth.Size = New System.Drawing.Size(162, 17)
        Me.chk_non_cms_stop_pay_auth.TabIndex = 29
        Me.chk_non_cms_stop_pay_auth.Text = "Stop Corporate Cheque Auth"
        Me.chk_non_cms_stop_pay_auth.UseVisualStyleBackColor = True
        '
        'cbo_event_template
        '
        Me.cbo_event_template.FormattingEnabled = True
        Me.cbo_event_template.Location = New System.Drawing.Point(122, 432)
        Me.cbo_event_template.Name = "cbo_event_template"
        Me.cbo_event_template.Size = New System.Drawing.Size(249, 21)
        Me.cbo_event_template.TabIndex = 15
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(27, 435)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 13)
        Me.Label17.TabIndex = 1123
        Me.Label17.Text = "Event Template"
        '
        'btn_clear_category
        '
        Me.btn_clear_category.Location = New System.Drawing.Point(812, 473)
        Me.btn_clear_category.Name = "btn_clear_category"
        Me.btn_clear_category.Size = New System.Drawing.Size(99, 29)
        Me.btn_clear_category.TabIndex = 1124
        Me.btn_clear_category.Text = "Clear Category"
        Me.btn_clear_category.UseVisualStyleBackColor = True
        '
        'chk_si_maker_flag
        '
        Me.chk_si_maker_flag.AutoSize = True
        Me.chk_si_maker_flag.Location = New System.Drawing.Point(512, 110)
        Me.chk_si_maker_flag.Name = "chk_si_maker_flag"
        Me.chk_si_maker_flag.Size = New System.Drawing.Size(69, 17)
        Me.chk_si_maker_flag.TabIndex = 30
        Me.chk_si_maker_flag.Text = "SI Maker"
        Me.chk_si_maker_flag.UseVisualStyleBackColor = True
        '
        'chk_si_authoriser_flag
        '
        Me.chk_si_authoriser_flag.AutoSize = True
        Me.chk_si_authoriser_flag.Location = New System.Drawing.Point(512, 133)
        Me.chk_si_authoriser_flag.Name = "chk_si_authoriser_flag"
        Me.chk_si_authoriser_flag.Size = New System.Drawing.Size(86, 17)
        Me.chk_si_authoriser_flag.TabIndex = 31
        Me.chk_si_authoriser_flag.Text = "SI Authoriser"
        Me.chk_si_authoriser_flag.UseVisualStyleBackColor = True
        '
        'btn_PaymentMaker
        '
        Me.btn_PaymentMaker.Location = New System.Drawing.Point(512, 186)
        Me.btn_PaymentMaker.Name = "btn_PaymentMaker"
        Me.btn_PaymentMaker.Size = New System.Drawing.Size(150, 25)
        Me.btn_PaymentMaker.TabIndex = 1125
        Me.btn_PaymentMaker.Text = "Payment Maker"
        Me.btn_PaymentMaker.UseVisualStyleBackColor = True
        '
        'btn_PaymentAuth
        '
        Me.btn_PaymentAuth.Location = New System.Drawing.Point(512, 216)
        Me.btn_PaymentAuth.Name = "btn_PaymentAuth"
        Me.btn_PaymentAuth.Size = New System.Drawing.Size(150, 25)
        Me.btn_PaymentAuth.TabIndex = 1126
        Me.btn_PaymentAuth.Text = "Payment Authoriser"
        Me.btn_PaymentAuth.UseVisualStyleBackColor = True
        '
        'btn_Admin
        '
        Me.btn_Admin.Location = New System.Drawing.Point(512, 247)
        Me.btn_Admin.Name = "btn_Admin"
        Me.btn_Admin.Size = New System.Drawing.Size(150, 25)
        Me.btn_Admin.TabIndex = 1127
        Me.btn_Admin.Text = "Admin"
        Me.btn_Admin.UseVisualStyleBackColor = True
        '
        'grd_account
        '
        Me.grd_account.AllowUserToAddRows = False
        Me.grd_account.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_account.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_account.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grd_account.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_account.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected, Me.Account, Me.view_acc_stt_flag, Me.view_sq_flag, Me.payment_flag, Me.IDX, Me.company_id})
        Me.grd_account.Location = New System.Drawing.Point(679, 84)
        Me.grd_account.MultiSelect = False
        Me.grd_account.Name = "grd_account"
        Me.grd_account.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_account.Size = New System.Drawing.Size(336, 145)
        Me.grd_account.TabIndex = 1128
        '
        'Selected
        '
        Me.Selected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Selected.DataPropertyName = "Selected"
        Me.Selected.FalseValue = "0"
        Me.Selected.HeaderText = "Select"
        Me.Selected.IndeterminateValue = "System.DBNull.Value"
        Me.Selected.Name = "Selected"
        Me.Selected.TrueValue = "1"
        Me.Selected.Width = 43
        '
        'Account
        '
        Me.Account.DataPropertyName = "account"
        Me.Account.HeaderText = "Account"
        Me.Account.Name = "Account"
        Me.Account.ReadOnly = True
        Me.Account.Width = 72
        '
        'view_acc_stt_flag
        '
        Me.view_acc_stt_flag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.view_acc_stt_flag.DataPropertyName = "view_acc_stt_flag"
        Me.view_acc_stt_flag.FalseValue = "0"
        Me.view_acc_stt_flag.HeaderText = "View Acc Stt"
        Me.view_acc_stt_flag.IndeterminateValue = "System.DBNull.Value"
        Me.view_acc_stt_flag.Name = "view_acc_stt_flag"
        Me.view_acc_stt_flag.TrueValue = "1"
        Me.view_acc_stt_flag.Width = 74
        '
        'view_sq_flag
        '
        Me.view_sq_flag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.view_sq_flag.DataPropertyName = "view_sq_flag"
        Me.view_sq_flag.FalseValue = "0"
        Me.view_sq_flag.HeaderText = "View SQ"
        Me.view_sq_flag.IndeterminateValue = "System.DBNull.Value"
        Me.view_sq_flag.Name = "view_sq_flag"
        Me.view_sq_flag.TrueValue = "1"
        Me.view_sq_flag.Width = 54
        '
        'payment_flag
        '
        Me.payment_flag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.payment_flag.DataPropertyName = "payment_flag"
        Me.payment_flag.FalseValue = "0"
        Me.payment_flag.HeaderText = "Payment"
        Me.payment_flag.IndeterminateValue = "System.DBNull.Value"
        Me.payment_flag.Name = "payment_flag"
        Me.payment_flag.TrueValue = "1"
        Me.payment_flag.Width = 54
        '
        'IDX
        '
        Me.IDX.DataPropertyName = "idx"
        Me.IDX.HeaderText = "Idx"
        Me.IDX.Name = "IDX"
        Me.IDX.Visible = False
        Me.IDX.Width = 46
        '
        'company_id
        '
        Me.company_id.DataPropertyName = "company_id"
        Me.company_id.HeaderText = "CompanyID"
        Me.company_id.Name = "company_id"
        Me.company_id.Visible = False
        Me.company_id.Width = 87
        '
        'grd_product
        '
        Me.grd_product.AllowUserToAddRows = False
        Me.grd_product.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_product.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grd_product.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grd_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_product.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pSelected, Me.Product, Me.pCompany_id, Me.pIdx})
        Me.grd_product.Location = New System.Drawing.Point(679, 264)
        Me.grd_product.MultiSelect = False
        Me.grd_product.Name = "grd_product"
        Me.grd_product.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_product.Size = New System.Drawing.Size(336, 145)
        Me.grd_product.TabIndex = 1129
        '
        'pSelected
        '
        Me.pSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.pSelected.DataPropertyName = "Selected"
        Me.pSelected.FalseValue = "0"
        Me.pSelected.HeaderText = "Select"
        Me.pSelected.IndeterminateValue = "System.DBNull.Value"
        Me.pSelected.Name = "pSelected"
        Me.pSelected.TrueValue = "1"
        Me.pSelected.Width = 43
        '
        'Product
        '
        Me.Product.DataPropertyName = "citem"
        Me.Product.HeaderText = "Product"
        Me.Product.Name = "Product"
        Me.Product.ReadOnly = True
        Me.Product.Width = 69
        '
        'pCompany_id
        '
        Me.pCompany_id.DataPropertyName = "company_id"
        Me.pCompany_id.HeaderText = "company_id"
        Me.pCompany_id.Name = "pCompany_id"
        Me.pCompany_id.Visible = False
        Me.pCompany_id.Width = 89
        '
        'pIdx
        '
        Me.pIdx.DataPropertyName = "Idx"
        Me.pIdx.HeaderText = "Idx"
        Me.pIdx.Name = "pIdx"
        Me.pIdx.Visible = False
        Me.pIdx.Width = 46
        '
        'Frm_DealSummary_User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 563)
        Me.Controls.Add(Me.grd_product)
        Me.Controls.Add(Me.grd_account)
        Me.Controls.Add(Me.btn_Admin)
        Me.Controls.Add(Me.btn_PaymentAuth)
        Me.Controls.Add(Me.btn_PaymentMaker)
        Me.Controls.Add(Me.chk_si_authoriser_flag)
        Me.Controls.Add(Me.chk_si_maker_flag)
        Me.Controls.Add(Me.btn_clear_category)
        Me.Controls.Add(Me.cbo_event_template)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.chk_non_cms_stop_pay_auth)
        Me.Controls.Add(Me.chk_non_cms_stop_pay)
        Me.Controls.Add(Me.lb_company_id)
        Me.Controls.Add(Me.btn_client_clear)
        Me.Controls.Add(Me.btn_client_all)
        Me.Controls.Add(Me.lst_across_client_code)
        Me.Controls.Add(Me.btn_product_clear)
        Me.Controls.Add(Me.btn_product_all)
        Me.Controls.Add(Me.btn_account_clear)
        Me.Controls.Add(Me.btn_account_all)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txt_gcp_service_end_date)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.btn_ChangeCategory)
        Me.Controls.Add(Me.cbo_Report_Category_ID)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cbo_User_Category_ID)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cbo_reference_type)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txt_fax)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txt_token_no)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cbo_auth_method)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cbo_log_in_method)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cbo_title)
        Me.Controls.Add(Me.cbo_gender)
        Me.Controls.Add(Me.chk_across_client_flag)
        Me.Controls.Add(Me.chk_super_user_flag)
        Me.Controls.Add(Me.chk_view_confidential_flag)
        Me.Controls.Add(Me.chk_admin_authoriser_flag)
        Me.Controls.Add(Me.chk_admin_maker_flag)
        Me.Controls.Add(Me.chk_payment_sender_flag)
        Me.Controls.Add(Me.chk_payment_authoriser_flag)
        Me.Controls.Add(Me.chk_payment_verifier_flag)
        Me.Controls.Add(Me.chk_payment_maker_flag)
        Me.Controls.Add(Me.chk_view_bill_payment_flag)
        Me.Controls.Add(Me.chk_view_sq_flag)
        Me.Controls.Add(Me.chk_view_acc_stt_flag)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txt_mobile_phone)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_phone)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_reference_no)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_date_of_birth)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_user_id)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_lastname)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_firstname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grp_tool)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Frm_DealSummary_User"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.grp_tool.ResumeLayout(False)
        CType(Me.grd_account, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_product, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbHead As System.Windows.Forms.Label
    Friend WithEvents grp_tool As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_firstname As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_lastname As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_user_id As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_date_of_birth As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_reference_no As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_phone As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_mobile_phone As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chk_view_bill_payment_flag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_view_sq_flag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_view_acc_stt_flag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_payment_verifier_flag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_payment_maker_flag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_admin_maker_flag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_payment_sender_flag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_payment_authoriser_flag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_across_client_flag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_super_user_flag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_view_confidential_flag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_admin_authoriser_flag As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_gender As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_title As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_log_in_method As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbo_auth_method As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_token_no As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_fax As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cbo_reference_type As System.Windows.Forms.ComboBox
    Friend WithEvents txt_company_id As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbo_User_Category_ID As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbo_Report_Category_ID As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btn_ChangeCategory As System.Windows.Forms.Button
    Friend WithEvents txt_temp As System.Windows.Forms.TextBox
    Friend WithEvents txt_company_id_parent As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_gcp_service_end_date As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt_revision_desc As System.Windows.Forms.TextBox
    Friend WithEvents txt_revision_code As System.Windows.Forms.TextBox
    Friend WithEvents btn_account_all As System.Windows.Forms.Button
    Friend WithEvents btn_account_clear As System.Windows.Forms.Button
    Friend WithEvents btn_product_clear As System.Windows.Forms.Button
    Friend WithEvents btn_product_all As System.Windows.Forms.Button
    Friend WithEvents lst_across_client_code As System.Windows.Forms.CheckedListBox
    Friend WithEvents btn_client_clear As System.Windows.Forms.Button
    Friend WithEvents btn_client_all As System.Windows.Forms.Button
    Friend WithEvents lb_company_id As System.Windows.Forms.Label
    Friend WithEvents chk_non_cms_stop_pay As System.Windows.Forms.CheckBox
    Friend WithEvents chk_non_cms_stop_pay_auth As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_event_template As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btn_clear_category As System.Windows.Forms.Button
    Friend WithEvents chk_si_maker_flag As System.Windows.Forms.CheckBox
    Friend WithEvents chk_si_authoriser_flag As System.Windows.Forms.CheckBox
    Friend WithEvents btn_PaymentMaker As System.Windows.Forms.Button
    Friend WithEvents btn_PaymentAuth As System.Windows.Forms.Button
    Friend WithEvents btn_Admin As System.Windows.Forms.Button
    Friend WithEvents grd_product As System.Windows.Forms.DataGridView
    Friend WithEvents grd_account As System.Windows.Forms.DataGridView
    Friend WithEvents pSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Product As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pCompany_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pIdx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Account As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents view_acc_stt_flag As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents view_sq_flag As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents payment_flag As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IDX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents company_id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
