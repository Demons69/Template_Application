<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_FeeCharging_Edit
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
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_Product_ID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_start_date = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbo_gl_account = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbo_request_wht = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbo_charge_type = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbo_charge_frequency_month = New System.Windows.Forms.ComboBox
        Me.cbo_charge_frequency_date = New System.Windows.Forms.ComboBox
        Me.lb_y = New System.Windows.Forms.Label
        Me.lb_m = New System.Windows.Forms.Label
        Me.cbo_charge_frequency_date_of_month = New System.Windows.Forms.ComboBox
        Me.lb_d_format = New System.Windows.Forms.Label
        Me.txt_charge_frequency_due_date = New System.Windows.Forms.TextBox
        Me.lb_d = New System.Windows.Forms.Label
        Me.rad_charge_frequency_yearly = New System.Windows.Forms.RadioButton
        Me.rad_charge_frequency_monthly = New System.Windows.Forms.RadioButton
        Me.rad_charge_frequency_daily = New System.Windows.Forms.RadioButton
        Me.rad_charge_frequency_one_time = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.gcp_workingDayCondition = New System.Windows.Forms.GroupBox
        Me.rad_working_day_condition_type_next_working_day = New System.Windows.Forms.RadioButton
        Me.rad_working_day_condition_type_next_round = New System.Windows.Forms.RadioButton
        Me.chk_fri = New System.Windows.Forms.CheckBox
        Me.chk_thu = New System.Windows.Forms.CheckBox
        Me.chk_wed = New System.Windows.Forms.CheckBox
        Me.chk_tue = New System.Windows.Forms.CheckBox
        Me.chk_mon = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_expiration_date = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_charge_amt = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cbo_holiday_condition = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rad_deduct_condition_billing = New System.Windows.Forms.RadioButton
        Me.rad_deduct_condition_no_billing = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.BT_Update = New System.Windows.Forms.Button
        Me.txt_product_description = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnFindCust = New System.Windows.Forms.Button
        Me.btn_find_product = New System.Windows.Forms.Button
        Me.txt_seq = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gcp_workingDayCondition.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txt_company_id)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(798, 35)
        Me.Panel2.TabIndex = 199
        '
        'txt_company_id
        '
        Me.txt_company_id.Enabled = False
        Me.txt_company_id.Location = New System.Drawing.Point(595, 9)
        Me.txt_company_id.MaxLength = 10
        Me.txt_company_id.Name = "txt_company_id"
        Me.txt_company_id.Size = New System.Drawing.Size(200, 20)
        Me.txt_company_id.TabIndex = 1055
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label20.Location = New System.Drawing.Point(511, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(86, 13)
        Me.Label20.TabIndex = 1056
        Me.Label20.Text = "Company Id: *"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(312, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "FEE REGISTRATION PRODUCT"
        '
        'txt_Product_ID
        '
        Me.txt_Product_ID.Location = New System.Drawing.Point(161, 45)
        Me.txt_Product_ID.MaxLength = 255
        Me.txt_Product_ID.Name = "txt_Product_ID"
        Me.txt_Product_ID.Size = New System.Drawing.Size(99, 20)
        Me.txt_Product_ID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(87, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 1023
        Me.Label1.Text = "Product ID*"
        '
        'txt_start_date
        '
        Me.txt_start_date.Location = New System.Drawing.Point(161, 97)
        Me.txt_start_date.MaxLength = 255
        Me.txt_start_date.Name = "txt_start_date"
        Me.txt_start_date.Size = New System.Drawing.Size(99, 20)
        Me.txt_start_date.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(90, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 1026
        Me.Label2.Text = "Start Date*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(266, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 1027
        Me.Label3.Text = "(DD/MM/YYYY)"
        '
        'cbo_gl_account
        '
        Me.cbo_gl_account.FormattingEnabled = True
        Me.cbo_gl_account.Location = New System.Drawing.Point(161, 123)
        Me.cbo_gl_account.Name = "cbo_gl_account"
        Me.cbo_gl_account.Size = New System.Drawing.Size(139, 21)
        Me.cbo_gl_account.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(78, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 1029
        Me.Label4.Text = "Account No *"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(69, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 1031
        Me.Label6.Text = "Request WHT*"
        '
        'cbo_request_wht
        '
        Me.cbo_request_wht.FormattingEnabled = True
        Me.cbo_request_wht.Location = New System.Drawing.Point(161, 150)
        Me.cbo_request_wht.Name = "cbo_request_wht"
        Me.cbo_request_wht.Size = New System.Drawing.Size(139, 21)
        Me.cbo_request_wht.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(77, 181)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 1033
        Me.Label7.Text = "Charge Type*"
        '
        'cbo_charge_type
        '
        Me.cbo_charge_type.FormattingEnabled = True
        Me.cbo_charge_type.Location = New System.Drawing.Point(161, 177)
        Me.cbo_charge_type.Name = "cbo_charge_type"
        Me.cbo_charge_type.Size = New System.Drawing.Size(139, 21)
        Me.cbo_charge_type.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(51, 219)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 1034
        Me.Label8.Text = "Charge Frequency*"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo_charge_frequency_month)
        Me.GroupBox1.Controls.Add(Me.cbo_charge_frequency_date)
        Me.GroupBox1.Controls.Add(Me.lb_y)
        Me.GroupBox1.Controls.Add(Me.lb_m)
        Me.GroupBox1.Controls.Add(Me.cbo_charge_frequency_date_of_month)
        Me.GroupBox1.Controls.Add(Me.lb_d_format)
        Me.GroupBox1.Controls.Add(Me.txt_charge_frequency_due_date)
        Me.GroupBox1.Controls.Add(Me.lb_d)
        Me.GroupBox1.Controls.Add(Me.rad_charge_frequency_yearly)
        Me.GroupBox1.Controls.Add(Me.rad_charge_frequency_monthly)
        Me.GroupBox1.Controls.Add(Me.rad_charge_frequency_daily)
        Me.GroupBox1.Controls.Add(Me.rad_charge_frequency_one_time)
        Me.GroupBox1.Location = New System.Drawing.Point(161, 207)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(441, 121)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'cbo_charge_frequency_month
        '
        Me.cbo_charge_frequency_month.FormattingEnabled = True
        Me.cbo_charge_frequency_month.Location = New System.Drawing.Point(311, 89)
        Me.cbo_charge_frequency_month.Name = "cbo_charge_frequency_month"
        Me.cbo_charge_frequency_month.Size = New System.Drawing.Size(62, 21)
        Me.cbo_charge_frequency_month.TabIndex = 7
        Me.cbo_charge_frequency_month.Visible = False
        '
        'cbo_charge_frequency_date
        '
        Me.cbo_charge_frequency_date.FormattingEnabled = True
        Me.cbo_charge_frequency_date.Location = New System.Drawing.Point(243, 89)
        Me.cbo_charge_frequency_date.Name = "cbo_charge_frequency_date"
        Me.cbo_charge_frequency_date.Size = New System.Drawing.Size(62, 21)
        Me.cbo_charge_frequency_date.TabIndex = 6
        Me.cbo_charge_frequency_date.Visible = False
        '
        'lb_y
        '
        Me.lb_y.AutoSize = True
        Me.lb_y.Location = New System.Drawing.Point(159, 93)
        Me.lb_y.Name = "lb_y"
        Me.lb_y.Size = New System.Drawing.Size(65, 13)
        Me.lb_y.TabIndex = 1059
        Me.lb_y.Text = "Date/Month"
        Me.lb_y.Visible = False
        '
        'lb_m
        '
        Me.lb_m.AutoSize = True
        Me.lb_m.Location = New System.Drawing.Point(147, 67)
        Me.lb_m.Name = "lb_m"
        Me.lb_m.Size = New System.Drawing.Size(77, 13)
        Me.lb_m.TabIndex = 1058
        Me.lb_m.Text = "Date Of Month"
        Me.lb_m.Visible = False
        '
        'cbo_charge_frequency_date_of_month
        '
        Me.cbo_charge_frequency_date_of_month.FormattingEnabled = True
        Me.cbo_charge_frequency_date_of_month.Location = New System.Drawing.Point(243, 64)
        Me.cbo_charge_frequency_date_of_month.Name = "cbo_charge_frequency_date_of_month"
        Me.cbo_charge_frequency_date_of_month.Size = New System.Drawing.Size(62, 21)
        Me.cbo_charge_frequency_date_of_month.TabIndex = 5
        Me.cbo_charge_frequency_date_of_month.Visible = False
        '
        'lb_d_format
        '
        Me.lb_d_format.AutoSize = True
        Me.lb_d_format.Location = New System.Drawing.Point(348, 44)
        Me.lb_d_format.Name = "lb_d_format"
        Me.lb_d_format.Size = New System.Drawing.Size(85, 13)
        Me.lb_d_format.TabIndex = 1056
        Me.lb_d_format.Text = "(DD/MM/YYYY)"
        Me.lb_d_format.Visible = False
        '
        'txt_charge_frequency_due_date
        '
        Me.txt_charge_frequency_due_date.Location = New System.Drawing.Point(243, 40)
        Me.txt_charge_frequency_due_date.MaxLength = 255
        Me.txt_charge_frequency_due_date.Name = "txt_charge_frequency_due_date"
        Me.txt_charge_frequency_due_date.Size = New System.Drawing.Size(99, 20)
        Me.txt_charge_frequency_due_date.TabIndex = 4
        Me.txt_charge_frequency_due_date.Visible = False
        '
        'lb_d
        '
        Me.lb_d.AutoSize = True
        Me.lb_d.Location = New System.Drawing.Point(167, 44)
        Me.lb_d.Name = "lb_d"
        Me.lb_d.Size = New System.Drawing.Size(57, 13)
        Me.lb_d.TabIndex = 1055
        Me.lb_d.Text = "Due Date*"
        Me.lb_d.Visible = False
        '
        'rad_charge_frequency_yearly
        '
        Me.rad_charge_frequency_yearly.AutoSize = True
        Me.rad_charge_frequency_yearly.Location = New System.Drawing.Point(17, 88)
        Me.rad_charge_frequency_yearly.Name = "rad_charge_frequency_yearly"
        Me.rad_charge_frequency_yearly.Size = New System.Drawing.Size(54, 17)
        Me.rad_charge_frequency_yearly.TabIndex = 3
        Me.rad_charge_frequency_yearly.Text = "Yearly"
        Me.rad_charge_frequency_yearly.UseVisualStyleBackColor = True
        '
        'rad_charge_frequency_monthly
        '
        Me.rad_charge_frequency_monthly.AutoSize = True
        Me.rad_charge_frequency_monthly.Location = New System.Drawing.Point(17, 65)
        Me.rad_charge_frequency_monthly.Name = "rad_charge_frequency_monthly"
        Me.rad_charge_frequency_monthly.Size = New System.Drawing.Size(62, 17)
        Me.rad_charge_frequency_monthly.TabIndex = 2
        Me.rad_charge_frequency_monthly.Text = "Monthly"
        Me.rad_charge_frequency_monthly.UseVisualStyleBackColor = True
        '
        'rad_charge_frequency_daily
        '
        Me.rad_charge_frequency_daily.AutoSize = True
        Me.rad_charge_frequency_daily.Location = New System.Drawing.Point(17, 42)
        Me.rad_charge_frequency_daily.Name = "rad_charge_frequency_daily"
        Me.rad_charge_frequency_daily.Size = New System.Drawing.Size(48, 17)
        Me.rad_charge_frequency_daily.TabIndex = 1
        Me.rad_charge_frequency_daily.Text = "Daily"
        Me.rad_charge_frequency_daily.UseVisualStyleBackColor = True
        '
        'rad_charge_frequency_one_time
        '
        Me.rad_charge_frequency_one_time.AutoSize = True
        Me.rad_charge_frequency_one_time.Checked = True
        Me.rad_charge_frequency_one_time.Location = New System.Drawing.Point(17, 19)
        Me.rad_charge_frequency_one_time.Name = "rad_charge_frequency_one_time"
        Me.rad_charge_frequency_one_time.Size = New System.Drawing.Size(71, 17)
        Me.rad_charge_frequency_one_time.TabIndex = 0
        Me.rad_charge_frequency_one_time.TabStop = True
        Me.rad_charge_frequency_one_time.Text = "One Time"
        Me.rad_charge_frequency_one_time.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(35, 329)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 13)
        Me.Label9.TabIndex = 1036
        Me.Label9.Text = "Working Day Condition"
        '
        'gcp_workingDayCondition
        '
        Me.gcp_workingDayCondition.Controls.Add(Me.rad_working_day_condition_type_next_working_day)
        Me.gcp_workingDayCondition.Controls.Add(Me.rad_working_day_condition_type_next_round)
        Me.gcp_workingDayCondition.Controls.Add(Me.chk_fri)
        Me.gcp_workingDayCondition.Controls.Add(Me.chk_thu)
        Me.gcp_workingDayCondition.Controls.Add(Me.chk_wed)
        Me.gcp_workingDayCondition.Controls.Add(Me.chk_tue)
        Me.gcp_workingDayCondition.Controls.Add(Me.chk_mon)
        Me.gcp_workingDayCondition.Location = New System.Drawing.Point(161, 345)
        Me.gcp_workingDayCondition.Name = "gcp_workingDayCondition"
        Me.gcp_workingDayCondition.Size = New System.Drawing.Size(294, 85)
        Me.gcp_workingDayCondition.TabIndex = 11
        Me.gcp_workingDayCondition.TabStop = False
        '
        'rad_working_day_condition_type_next_working_day
        '
        Me.rad_working_day_condition_type_next_working_day.AutoSize = True
        Me.rad_working_day_condition_type_next_working_day.Location = New System.Drawing.Point(114, 50)
        Me.rad_working_day_condition_type_next_working_day.Name = "rad_working_day_condition_type_next_working_day"
        Me.rad_working_day_condition_type_next_working_day.Size = New System.Drawing.Size(112, 17)
        Me.rad_working_day_condition_type_next_working_day.TabIndex = 6
        Me.rad_working_day_condition_type_next_working_day.Text = "Next Working Day"
        Me.rad_working_day_condition_type_next_working_day.UseVisualStyleBackColor = True
        '
        'rad_working_day_condition_type_next_round
        '
        Me.rad_working_day_condition_type_next_round.AutoSize = True
        Me.rad_working_day_condition_type_next_round.Location = New System.Drawing.Point(17, 50)
        Me.rad_working_day_condition_type_next_round.Name = "rad_working_day_condition_type_next_round"
        Me.rad_working_day_condition_type_next_round.Size = New System.Drawing.Size(82, 17)
        Me.rad_working_day_condition_type_next_round.TabIndex = 5
        Me.rad_working_day_condition_type_next_round.Text = "Next Round"
        Me.rad_working_day_condition_type_next_round.UseVisualStyleBackColor = True
        '
        'chk_fri
        '
        Me.chk_fri.AutoSize = True
        Me.chk_fri.Location = New System.Drawing.Point(230, 19)
        Me.chk_fri.Name = "chk_fri"
        Me.chk_fri.Size = New System.Drawing.Size(37, 17)
        Me.chk_fri.TabIndex = 4
        Me.chk_fri.Text = "Fri"
        Me.chk_fri.UseVisualStyleBackColor = True
        '
        'chk_thu
        '
        Me.chk_thu.AutoSize = True
        Me.chk_thu.Location = New System.Drawing.Point(175, 18)
        Me.chk_thu.Name = "chk_thu"
        Me.chk_thu.Size = New System.Drawing.Size(45, 17)
        Me.chk_thu.TabIndex = 3
        Me.chk_thu.Text = "Thu"
        Me.chk_thu.UseVisualStyleBackColor = True
        '
        'chk_wed
        '
        Me.chk_wed.AutoSize = True
        Me.chk_wed.Location = New System.Drawing.Point(119, 19)
        Me.chk_wed.Name = "chk_wed"
        Me.chk_wed.Size = New System.Drawing.Size(49, 17)
        Me.chk_wed.TabIndex = 2
        Me.chk_wed.Text = "Wed"
        Me.chk_wed.UseVisualStyleBackColor = True
        '
        'chk_tue
        '
        Me.chk_tue.AutoSize = True
        Me.chk_tue.Location = New System.Drawing.Point(68, 18)
        Me.chk_tue.Name = "chk_tue"
        Me.chk_tue.Size = New System.Drawing.Size(45, 17)
        Me.chk_tue.TabIndex = 1
        Me.chk_tue.Text = "Tue"
        Me.chk_tue.UseVisualStyleBackColor = True
        '
        'chk_mon
        '
        Me.chk_mon.AutoSize = True
        Me.chk_mon.Location = New System.Drawing.Point(12, 18)
        Me.chk_mon.Name = "chk_mon"
        Me.chk_mon.Size = New System.Drawing.Size(47, 17)
        Me.chk_mon.TabIndex = 0
        Me.chk_mon.Text = "Mon"
        Me.chk_mon.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(705, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 1040
        Me.Label10.Text = "(DD/MM/YYYY)"
        '
        'txt_expiration_date
        '
        Me.txt_expiration_date.Enabled = False
        Me.txt_expiration_date.Location = New System.Drawing.Point(600, 68)
        Me.txt_expiration_date.MaxLength = 255
        Me.txt_expiration_date.Name = "txt_expiration_date"
        Me.txt_expiration_date.Size = New System.Drawing.Size(99, 20)
        Me.txt_expiration_date.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(498, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 1039
        Me.Label11.Text = "Expiration Date*"
        '
        'txt_charge_amt
        '
        Me.txt_charge_amt.Location = New System.Drawing.Point(600, 94)
        Me.txt_charge_amt.MaxLength = 255
        Me.txt_charge_amt.Name = "txt_charge_amt"
        Me.txt_charge_amt.Size = New System.Drawing.Size(99, 20)
        Me.txt_charge_amt.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(497, 98)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 13)
        Me.Label12.TabIndex = 1042
        Me.Label12.Text = "Charge Amount*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(488, 125)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 13)
        Me.Label13.TabIndex = 1044
        Me.Label13.Text = "Holiday Condition*"
        '
        'cbo_holiday_condition
        '
        Me.cbo_holiday_condition.FormattingEnabled = True
        Me.cbo_holiday_condition.Location = New System.Drawing.Point(600, 121)
        Me.cbo_holiday_condition.Name = "cbo_holiday_condition"
        Me.cbo_holiday_condition.Size = New System.Drawing.Size(139, 21)
        Me.cbo_holiday_condition.TabIndex = 8
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rad_deduct_condition_billing)
        Me.GroupBox3.Controls.Add(Me.rad_deduct_condition_no_billing)
        Me.GroupBox3.Location = New System.Drawing.Point(600, 148)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(190, 43)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        '
        'rad_deduct_condition_billing
        '
        Me.rad_deduct_condition_billing.AutoSize = True
        Me.rad_deduct_condition_billing.Location = New System.Drawing.Point(108, 19)
        Me.rad_deduct_condition_billing.Name = "rad_deduct_condition_billing"
        Me.rad_deduct_condition_billing.Size = New System.Drawing.Size(52, 17)
        Me.rad_deduct_condition_billing.TabIndex = 1
        Me.rad_deduct_condition_billing.Text = "Billing"
        Me.rad_deduct_condition_billing.UseVisualStyleBackColor = True
        '
        'rad_deduct_condition_no_billing
        '
        Me.rad_deduct_condition_no_billing.AutoSize = True
        Me.rad_deduct_condition_no_billing.Checked = True
        Me.rad_deduct_condition_no_billing.Location = New System.Drawing.Point(17, 19)
        Me.rad_deduct_condition_no_billing.Name = "rad_deduct_condition_no_billing"
        Me.rad_deduct_condition_no_billing.Size = New System.Drawing.Size(69, 17)
        Me.rad_deduct_condition_no_billing.TabIndex = 0
        Me.rad_deduct_condition_no_billing.TabStop = True
        Me.rad_deduct_condition_no_billing.Text = "No Billing"
        Me.rad_deduct_condition_no_billing.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(488, 160)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 13)
        Me.Label14.TabIndex = 1045
        Me.Label14.Text = "Deduct Condition*"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.bt_close)
        Me.GroupBox4.Controls.Add(Me.BT_Update)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 458)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(775, 51)
        Me.GroupBox4.TabIndex = 1047
        Me.GroupBox4.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(385, 16)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 6
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'BT_Update
        '
        Me.BT_Update.Location = New System.Drawing.Point(270, 16)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(99, 29)
        Me.BT_Update.TabIndex = 5
        Me.BT_Update.Text = "Save"
        Me.BT_Update.UseVisualStyleBackColor = True
        '
        'txt_product_description
        '
        Me.txt_product_description.Location = New System.Drawing.Point(161, 70)
        Me.txt_product_description.MaxLength = 255
        Me.txt_product_description.Name = "txt_product_description"
        Me.txt_product_description.Size = New System.Drawing.Size(331, 20)
        Me.txt_product_description.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 13)
        Me.Label5.TabIndex = 1049
        Me.Label5.Text = "Product Description*"
        '
        'btnFindCust
        '
        Me.btnFindCust.Location = New System.Drawing.Point(306, 120)
        Me.btnFindCust.Name = "btnFindCust"
        Me.btnFindCust.Size = New System.Drawing.Size(108, 23)
        Me.btnFindCust.TabIndex = 1050
        Me.btnFindCust.Text = "Find Customer"
        Me.btnFindCust.UseVisualStyleBackColor = True
        Me.btnFindCust.Visible = False
        '
        'btn_find_product
        '
        Me.btn_find_product.Location = New System.Drawing.Point(268, 41)
        Me.btn_find_product.Name = "btn_find_product"
        Me.btn_find_product.Size = New System.Drawing.Size(112, 27)
        Me.btn_find_product.TabIndex = 1051
        Me.btn_find_product.Text = "Browse..."
        Me.btn_find_product.UseVisualStyleBackColor = True
        '
        'txt_seq
        '
        Me.txt_seq.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_seq.Enabled = False
        Me.txt_seq.Location = New System.Drawing.Point(434, 44)
        Me.txt_seq.MaxLength = 255
        Me.txt_seq.Name = "txt_seq"
        Me.txt_seq.Size = New System.Drawing.Size(58, 20)
        Me.txt_seq.TabIndex = 1052
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(398, 48)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(30, 13)
        Me.Label21.TabIndex = 1053
        Me.Label21.Text = "Seq*"
        '
        'Frm_DealSummary_FeeCharging_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 513)
        Me.Controls.Add(Me.txt_seq)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.btn_find_product)
        Me.Controls.Add(Me.btnFindCust)
        Me.Controls.Add(Me.txt_product_description)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cbo_holiday_condition)
        Me.Controls.Add(Me.txt_charge_amt)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_expiration_date)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.gcp_workingDayCondition)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbo_charge_type)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbo_request_wht)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbo_gl_account)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_start_date)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_Product_ID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_DealSummary_FeeCharging_Edit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gcp_workingDayCondition.ResumeLayout(False)
        Me.gcp_workingDayCondition.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_Product_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_start_date As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_gl_account As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbo_request_wht As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_charge_type As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rad_charge_frequency_daily As System.Windows.Forms.RadioButton
    Friend WithEvents rad_charge_frequency_one_time As System.Windows.Forms.RadioButton
    Friend WithEvents rad_charge_frequency_yearly As System.Windows.Forms.RadioButton
    Friend WithEvents rad_charge_frequency_monthly As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gcp_workingDayCondition As System.Windows.Forms.GroupBox
    Friend WithEvents chk_mon As System.Windows.Forms.CheckBox
    Friend WithEvents chk_wed As System.Windows.Forms.CheckBox
    Friend WithEvents chk_tue As System.Windows.Forms.CheckBox
    Friend WithEvents chk_thu As System.Windows.Forms.CheckBox
    Friend WithEvents chk_fri As System.Windows.Forms.CheckBox
    Friend WithEvents rad_working_day_condition_type_next_working_day As System.Windows.Forms.RadioButton
    Friend WithEvents rad_working_day_condition_type_next_round As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_expiration_date As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_charge_amt As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbo_holiday_condition As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rad_deduct_condition_billing As System.Windows.Forms.RadioButton
    Friend WithEvents rad_deduct_condition_no_billing As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbo_charge_frequency_date As System.Windows.Forms.ComboBox
    Friend WithEvents lb_y As System.Windows.Forms.Label
    Friend WithEvents lb_m As System.Windows.Forms.Label
    Friend WithEvents cbo_charge_frequency_date_of_month As System.Windows.Forms.ComboBox
    Friend WithEvents lb_d_format As System.Windows.Forms.Label
    Friend WithEvents txt_charge_frequency_due_date As System.Windows.Forms.TextBox
    Friend WithEvents lb_d As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents txt_product_description As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_charge_frequency_month As System.Windows.Forms.ComboBox
    Friend WithEvents btnFindCust As System.Windows.Forms.Button
    Friend WithEvents txt_company_id As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btn_find_product As System.Windows.Forms.Button
    Friend WithEvents txt_seq As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
End Class
