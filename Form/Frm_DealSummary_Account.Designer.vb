<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_Account
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
        Me.txt_IsPaymentActive = New System.Windows.Forms.TextBox
        Me.txt_revision_desc = New System.Windows.Forms.TextBox
        Me.txt_revision_code = New System.Windows.Forms.TextBox
        Me.txt_company_id = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbHead = New System.Windows.Forms.Label
        Me.grp_tool = New System.Windows.Forms.GroupBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.BT_Update = New System.Windows.Forms.Button
        Me.txt_account_number = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbo_account_type = New System.Windows.Forms.ComboBox
        Me.chk_acc_stt = New System.Windows.Forms.CheckBox
        Me.chk_sq = New System.Windows.Forms.CheckBox
        Me.chk_bill_payment = New System.Windows.Forms.CheckBox
        Me.chk_payment = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.rad_yes = New System.Windows.Forms.RadioButton
        Me.rad_no = New System.Windows.Forms.RadioButton
        Me.txt_account_name = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_branch_code = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.chk_default_charge = New System.Windows.Forms.CheckBox
        Me.chk_default_debit = New System.Windows.Forms.CheckBox
        Me.chk_default_credit = New System.Windows.Forms.CheckBox
        Me.chk_set_as_charge_account = New System.Windows.Forms.CheckBox
        Me.chk_set_as_debit_and_charge_at = New System.Windows.Forms.CheckBox
        Me.cbo_charge_account_number = New System.Windows.Forms.ComboBox
        Me.chk_set_as_credit_account_for_debit = New System.Windows.Forms.CheckBox
        Me.cbo_txn_account_number = New System.Windows.Forms.ComboBox
        Me.Panel2.SuspendLayout()
        Me.grp_tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txt_IsPaymentActive)
        Me.Panel2.Controls.Add(Me.txt_revision_desc)
        Me.Panel2.Controls.Add(Me.txt_revision_code)
        Me.Panel2.Controls.Add(Me.txt_company_id)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lbHead)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(751, 35)
        Me.Panel2.TabIndex = 196
        '
        'txt_IsPaymentActive
        '
        Me.txt_IsPaymentActive.Location = New System.Drawing.Point(265, 10)
        Me.txt_IsPaymentActive.MaxLength = 8
        Me.txt_IsPaymentActive.Name = "txt_IsPaymentActive"
        Me.txt_IsPaymentActive.Size = New System.Drawing.Size(67, 20)
        Me.txt_IsPaymentActive.TabIndex = 1067
        Me.txt_IsPaymentActive.Visible = False
        '
        'txt_revision_desc
        '
        Me.txt_revision_desc.Location = New System.Drawing.Point(441, 7)
        Me.txt_revision_desc.MaxLength = 8
        Me.txt_revision_desc.Name = "txt_revision_desc"
        Me.txt_revision_desc.Size = New System.Drawing.Size(67, 20)
        Me.txt_revision_desc.TabIndex = 1066
        Me.txt_revision_desc.Visible = False
        '
        'txt_revision_code
        '
        Me.txt_revision_code.Location = New System.Drawing.Point(340, 7)
        Me.txt_revision_code.MaxLength = 8
        Me.txt_revision_code.Name = "txt_revision_code"
        Me.txt_revision_code.Size = New System.Drawing.Size(93, 20)
        Me.txt_revision_code.TabIndex = 1065
        Me.txt_revision_code.Visible = False
        '
        'txt_company_id
        '
        Me.txt_company_id.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_company_id.Enabled = False
        Me.txt_company_id.Location = New System.Drawing.Point(604, 6)
        Me.txt_company_id.MaxLength = 10
        Me.txt_company_id.Name = "txt_company_id"
        Me.txt_company_id.Size = New System.Drawing.Size(169, 20)
        Me.txt_company_id.TabIndex = 1055
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(525, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 1056
        Me.Label5.Text = "Company Id:"
        '
        'lbHead
        '
        Me.lbHead.AutoSize = True
        Me.lbHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbHead.ForeColor = System.Drawing.Color.Navy
        Me.lbHead.Location = New System.Drawing.Point(13, 5)
        Me.lbHead.Name = "lbHead"
        Me.lbHead.Size = New System.Drawing.Size(110, 24)
        Me.lbHead.TabIndex = 0
        Me.lbHead.Text = "ACCOUNT"
        '
        'grp_tool
        '
        Me.grp_tool.Controls.Add(Me.bt_close)
        Me.grp_tool.Controls.Add(Me.BT_Update)
        Me.grp_tool.Location = New System.Drawing.Point(4, 323)
        Me.grp_tool.Name = "grp_tool"
        Me.grp_tool.Size = New System.Drawing.Size(747, 51)
        Me.grp_tool.TabIndex = 1016
        Me.grp_tool.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(389, 16)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 7
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'BT_Update
        '
        Me.BT_Update.Location = New System.Drawing.Point(274, 16)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(99, 29)
        Me.BT_Update.TabIndex = 6
        Me.BT_Update.Text = "Save"
        Me.BT_Update.UseVisualStyleBackColor = True
        '
        'txt_account_number
        '
        Me.txt_account_number.Location = New System.Drawing.Point(208, 60)
        Me.txt_account_number.MaxLength = 20
        Me.txt_account_number.Name = "txt_account_number"
        Me.txt_account_number.Size = New System.Drawing.Size(249, 20)
        Me.txt_account_number.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(107, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 1019
        Me.Label1.Text = "Account Number *"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(121, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 1021
        Me.Label2.Text = "Account Type *"
        '
        'cbo_account_type
        '
        Me.cbo_account_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_account_type.FormattingEnabled = True
        Me.cbo_account_type.Location = New System.Drawing.Point(208, 108)
        Me.cbo_account_type.Name = "cbo_account_type"
        Me.cbo_account_type.Size = New System.Drawing.Size(300, 21)
        Me.cbo_account_type.TabIndex = 2
        '
        'chk_acc_stt
        '
        Me.chk_acc_stt.AutoSize = True
        Me.chk_acc_stt.Checked = True
        Me.chk_acc_stt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_acc_stt.Enabled = False
        Me.chk_acc_stt.Location = New System.Drawing.Point(208, 152)
        Me.chk_acc_stt.Name = "chk_acc_stt"
        Me.chk_acc_stt.Size = New System.Drawing.Size(64, 17)
        Me.chk_acc_stt.TabIndex = 3
        Me.chk_acc_stt.Text = "Acc Stt."
        Me.chk_acc_stt.UseVisualStyleBackColor = True
        '
        'chk_sq
        '
        Me.chk_sq.AutoSize = True
        Me.chk_sq.Location = New System.Drawing.Point(392, 152)
        Me.chk_sq.Name = "chk_sq"
        Me.chk_sq.Size = New System.Drawing.Size(41, 17)
        Me.chk_sq.TabIndex = 5
        Me.chk_sq.Text = "SQ"
        Me.chk_sq.UseVisualStyleBackColor = True
        '
        'chk_bill_payment
        '
        Me.chk_bill_payment.AutoSize = True
        Me.chk_bill_payment.Location = New System.Drawing.Point(291, 152)
        Me.chk_bill_payment.Name = "chk_bill_payment"
        Me.chk_bill_payment.Size = New System.Drawing.Size(83, 17)
        Me.chk_bill_payment.TabIndex = 4
        Me.chk_bill_payment.Text = "Bill Payment"
        Me.chk_bill_payment.UseVisualStyleBackColor = True
        '
        'chk_payment
        '
        Me.chk_payment.AutoSize = True
        Me.chk_payment.Location = New System.Drawing.Point(479, 152)
        Me.chk_payment.Name = "chk_payment"
        Me.chk_payment.Size = New System.Drawing.Size(67, 17)
        Me.chk_payment.TabIndex = 2
        Me.chk_payment.Text = "Payment"
        Me.chk_payment.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(129, 294)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 1035
        Me.Label6.Text = "Valid Flag"
        '
        'rad_yes
        '
        Me.rad_yes.AutoSize = True
        Me.rad_yes.Checked = True
        Me.rad_yes.Enabled = False
        Me.rad_yes.Location = New System.Drawing.Point(203, 290)
        Me.rad_yes.Name = "rad_yes"
        Me.rad_yes.Size = New System.Drawing.Size(43, 17)
        Me.rad_yes.TabIndex = 1036
        Me.rad_yes.TabStop = True
        Me.rad_yes.Text = "Yes"
        Me.rad_yes.UseVisualStyleBackColor = True
        '
        'rad_no
        '
        Me.rad_no.AutoSize = True
        Me.rad_no.Enabled = False
        Me.rad_no.Location = New System.Drawing.Point(265, 290)
        Me.rad_no.Name = "rad_no"
        Me.rad_no.Size = New System.Drawing.Size(39, 17)
        Me.rad_no.TabIndex = 1037
        Me.rad_no.Text = "No"
        Me.rad_no.UseVisualStyleBackColor = True
        '
        'txt_account_name
        '
        Me.txt_account_name.Location = New System.Drawing.Point(207, 83)
        Me.txt_account_name.MaxLength = 180
        Me.txt_account_name.Name = "txt_account_name"
        Me.txt_account_name.Size = New System.Drawing.Size(507, 20)
        Me.txt_account_name.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(116, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 1040
        Me.Label7.Text = "Account Name *"
        '
        'txt_branch_code
        '
        Me.txt_branch_code.Enabled = False
        Me.txt_branch_code.Location = New System.Drawing.Point(569, 60)
        Me.txt_branch_code.MaxLength = 20
        Me.txt_branch_code.Name = "txt_branch_code"
        Me.txt_branch_code.Size = New System.Drawing.Size(145, 20)
        Me.txt_branch_code.TabIndex = 1041
        Me.txt_branch_code.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(489, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 1042
        Me.Label8.Text = "Branch Code *"
        Me.Label8.Visible = False
        '
        'chk_default_charge
        '
        Me.chk_default_charge.AutoSize = True
        Me.chk_default_charge.Location = New System.Drawing.Point(207, 192)
        Me.chk_default_charge.Name = "chk_default_charge"
        Me.chk_default_charge.Size = New System.Drawing.Size(97, 17)
        Me.chk_default_charge.TabIndex = 1043
        Me.chk_default_charge.Text = "Default Charge"
        Me.chk_default_charge.UseVisualStyleBackColor = True
        '
        'chk_default_debit
        '
        Me.chk_default_debit.AutoSize = True
        Me.chk_default_debit.Location = New System.Drawing.Point(207, 222)
        Me.chk_default_debit.Name = "chk_default_debit"
        Me.chk_default_debit.Size = New System.Drawing.Size(88, 17)
        Me.chk_default_debit.TabIndex = 1044
        Me.chk_default_debit.Text = "Default Debit"
        Me.chk_default_debit.UseVisualStyleBackColor = True
        '
        'chk_default_credit
        '
        Me.chk_default_credit.AutoSize = True
        Me.chk_default_credit.Location = New System.Drawing.Point(207, 254)
        Me.chk_default_credit.Name = "chk_default_credit"
        Me.chk_default_credit.Size = New System.Drawing.Size(90, 17)
        Me.chk_default_credit.TabIndex = 1045
        Me.chk_default_credit.Text = "Default Credit"
        Me.chk_default_credit.UseVisualStyleBackColor = True
        '
        'chk_set_as_charge_account
        '
        Me.chk_set_as_charge_account.AutoSize = True
        Me.chk_set_as_charge_account.Location = New System.Drawing.Point(321, 192)
        Me.chk_set_as_charge_account.Name = "chk_set_as_charge_account"
        Me.chk_set_as_charge_account.Size = New System.Drawing.Size(136, 17)
        Me.chk_set_as_charge_account.TabIndex = 1046
        Me.chk_set_as_charge_account.Text = "Set as Charge Account"
        Me.chk_set_as_charge_account.UseVisualStyleBackColor = True
        '
        'chk_set_as_debit_and_charge_at
        '
        Me.chk_set_as_debit_and_charge_at.AutoSize = True
        Me.chk_set_as_debit_and_charge_at.Location = New System.Drawing.Point(321, 222)
        Me.chk_set_as_debit_and_charge_at.Name = "chk_set_as_debit_and_charge_at"
        Me.chk_set_as_debit_and_charge_at.Size = New System.Drawing.Size(199, 17)
        Me.chk_set_as_debit_and_charge_at.TabIndex = 1047
        Me.chk_set_as_debit_and_charge_at.Text = "Set as Debit Account And Charge At"
        Me.chk_set_as_debit_and_charge_at.UseVisualStyleBackColor = True
        '
        'cbo_charge_account_number
        '
        Me.cbo_charge_account_number.Enabled = False
        Me.cbo_charge_account_number.FormattingEnabled = True
        Me.cbo_charge_account_number.Location = New System.Drawing.Point(578, 220)
        Me.cbo_charge_account_number.Name = "cbo_charge_account_number"
        Me.cbo_charge_account_number.Size = New System.Drawing.Size(152, 21)
        Me.cbo_charge_account_number.TabIndex = 1048
        '
        'chk_set_as_credit_account_for_debit
        '
        Me.chk_set_as_credit_account_for_debit.AutoSize = True
        Me.chk_set_as_credit_account_for_debit.Enabled = False
        Me.chk_set_as_credit_account_for_debit.Location = New System.Drawing.Point(321, 254)
        Me.chk_set_as_credit_account_for_debit.Name = "chk_set_as_credit_account_for_debit"
        Me.chk_set_as_credit_account_for_debit.Size = New System.Drawing.Size(256, 17)
        Me.chk_set_as_credit_account_for_debit.TabIndex = 1049
        Me.chk_set_as_credit_account_for_debit.Text = "Set As Credit Account for Debit Account Number"
        Me.chk_set_as_credit_account_for_debit.UseVisualStyleBackColor = True
        '
        'cbo_txn_account_number
        '
        Me.cbo_txn_account_number.Enabled = False
        Me.cbo_txn_account_number.FormattingEnabled = True
        Me.cbo_txn_account_number.Location = New System.Drawing.Point(578, 254)
        Me.cbo_txn_account_number.Name = "cbo_txn_account_number"
        Me.cbo_txn_account_number.Size = New System.Drawing.Size(152, 21)
        Me.cbo_txn_account_number.TabIndex = 1050
        '
        'Frm_DealSummary_Account
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 411)
        Me.Controls.Add(Me.cbo_txn_account_number)
        Me.Controls.Add(Me.chk_set_as_credit_account_for_debit)
        Me.Controls.Add(Me.cbo_charge_account_number)
        Me.Controls.Add(Me.chk_set_as_debit_and_charge_at)
        Me.Controls.Add(Me.chk_set_as_charge_account)
        Me.Controls.Add(Me.chk_default_credit)
        Me.Controls.Add(Me.chk_default_debit)
        Me.Controls.Add(Me.chk_default_charge)
        Me.Controls.Add(Me.txt_branch_code)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_account_name)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.rad_no)
        Me.Controls.Add(Me.rad_yes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chk_payment)
        Me.Controls.Add(Me.chk_bill_payment)
        Me.Controls.Add(Me.chk_sq)
        Me.Controls.Add(Me.chk_acc_stt)
        Me.Controls.Add(Me.cbo_account_type)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_account_number)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grp_tool)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Frm_DealSummary_Account"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.grp_tool.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbHead As System.Windows.Forms.Label
    Friend WithEvents grp_tool As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents txt_account_number As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbo_account_type As System.Windows.Forms.ComboBox
    Friend WithEvents chk_acc_stt As System.Windows.Forms.CheckBox
    Friend WithEvents chk_sq As System.Windows.Forms.CheckBox
    Friend WithEvents chk_bill_payment As System.Windows.Forms.CheckBox
    Friend WithEvents txt_company_id As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chk_payment As System.Windows.Forms.CheckBox
    Friend WithEvents txt_revision_desc As System.Windows.Forms.TextBox
    Friend WithEvents txt_revision_code As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rad_yes As System.Windows.Forms.RadioButton
    Friend WithEvents rad_no As System.Windows.Forms.RadioButton
    Friend WithEvents txt_account_name As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_branch_code As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chk_default_charge As System.Windows.Forms.CheckBox
    Friend WithEvents chk_default_debit As System.Windows.Forms.CheckBox
    Friend WithEvents chk_default_credit As System.Windows.Forms.CheckBox
    Friend WithEvents chk_set_as_charge_account As System.Windows.Forms.CheckBox
    Friend WithEvents chk_set_as_debit_and_charge_at As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_charge_account_number As System.Windows.Forms.ComboBox
    Friend WithEvents chk_set_as_credit_account_for_debit As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_txn_account_number As System.Windows.Forms.ComboBox
    Friend WithEvents txt_IsPaymentActive As System.Windows.Forms.TextBox
End Class
