<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_auth
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
        Me.txt_ID = New System.Windows.Forms.TextBox
        Me.txt_revision_desc = New System.Windows.Forms.TextBox
        Me.txt_revision_code = New System.Windows.Forms.TextBox
        Me.txt_company_id = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.lbHead = New System.Windows.Forms.Label
        Me.cbo_AuthorizationParameter = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grp_tool = New System.Windows.Forms.GroupBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.BT_Update = New System.Windows.Forms.Button
        Me.cbo_Product = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_LimitFrom = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_LimitTo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lb_user = New System.Windows.Forms.Label
        Me.cbo_Account = New System.Windows.Forms.ComboBox
        Me.lb_account_or_product = New System.Windows.Forms.Label
        Me.cbo_AuthorizationType = New System.Windows.Forms.ComboBox
        Me.txt_LevelNumber = New System.Windows.Forms.TextBox
        Me.lb_LevelNumber = New System.Windows.Forms.Label
        Me.txt_NoOfUser = New System.Windows.Forms.TextBox
        Me.lb_NoOfUser = New System.Windows.Forms.Label
        Me.lst_user = New System.Windows.Forms.CheckedListBox
        Me.Panel_SVM = New System.Windows.Forms.Panel
        Me.btnClear = New System.Windows.Forms.Button
        Me.btn_Down = New System.Windows.Forms.Button
        Me.btnUp = New System.Windows.Forms.Button
        Me.btn_remove = New System.Windows.Forms.Button
        Me.lstdata = New System.Windows.Forms.ListBox
        Me.btn_add_user = New System.Windows.Forms.Button
        Me.btn_add_category = New System.Windows.Forms.Button
        Me.cbo_user = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbo_category = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.rad_end_group = New System.Windows.Forms.RadioButton
        Me.rad_start_group = New System.Windows.Forms.RadioButton
        Me.txt_SignatoryMatrix = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdoFalse = New System.Windows.Forms.RadioButton
        Me.rdoTrue = New System.Windows.Forms.RadioButton
        Me.TabUserList = New System.Windows.Forms.TabControl
        Me.tabSVM = New System.Windows.Forms.TabPage
        Me.tabAVM = New System.Windows.Forms.TabPage
        Me.Panel2.SuspendLayout()
        Me.grp_tool.SuspendLayout()
        Me.Panel_SVM.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabUserList.SuspendLayout()
        Me.tabSVM.SuspendLayout()
        Me.tabAVM.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txt_ID)
        Me.Panel2.Controls.Add(Me.txt_revision_desc)
        Me.Panel2.Controls.Add(Me.txt_revision_code)
        Me.Panel2.Controls.Add(Me.txt_company_id)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.lbHead)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(968, 35)
        Me.Panel2.TabIndex = 201
        '
        'txt_ID
        '
        Me.txt_ID.Location = New System.Drawing.Point(213, 7)
        Me.txt_ID.MaxLength = 8
        Me.txt_ID.Name = "txt_ID"
        Me.txt_ID.Size = New System.Drawing.Size(75, 20)
        Me.txt_ID.TabIndex = 1069
        Me.txt_ID.Visible = False
        '
        'txt_revision_desc
        '
        Me.txt_revision_desc.Location = New System.Drawing.Point(427, 7)
        Me.txt_revision_desc.MaxLength = 8
        Me.txt_revision_desc.Name = "txt_revision_desc"
        Me.txt_revision_desc.Size = New System.Drawing.Size(215, 20)
        Me.txt_revision_desc.TabIndex = 1068
        Me.txt_revision_desc.Visible = False
        '
        'txt_revision_code
        '
        Me.txt_revision_code.Location = New System.Drawing.Point(328, 7)
        Me.txt_revision_code.MaxLength = 8
        Me.txt_revision_code.Name = "txt_revision_code"
        Me.txt_revision_code.Size = New System.Drawing.Size(93, 20)
        Me.txt_revision_code.TabIndex = 1067
        Me.txt_revision_code.Visible = False
        '
        'txt_company_id
        '
        Me.txt_company_id.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_company_id.Enabled = False
        Me.txt_company_id.Location = New System.Drawing.Point(782, 6)
        Me.txt_company_id.MaxLength = 10
        Me.txt_company_id.Name = "txt_company_id"
        Me.txt_company_id.Size = New System.Drawing.Size(169, 20)
        Me.txt_company_id.TabIndex = 1057
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.Location = New System.Drawing.Point(703, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 1058
        Me.Label12.Text = "Company Id:"
        '
        'lbHead
        '
        Me.lbHead.AutoSize = True
        Me.lbHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbHead.ForeColor = System.Drawing.Color.Navy
        Me.lbHead.Location = New System.Drawing.Point(13, 5)
        Me.lbHead.Name = "lbHead"
        Me.lbHead.Size = New System.Drawing.Size(200, 24)
        Me.lbHead.TabIndex = 0
        Me.lbHead.Text = "Authorization Matrix "
        '
        'cbo_AuthorizationParameter
        '
        Me.cbo_AuthorizationParameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_AuthorizationParameter.FormattingEnabled = True
        Me.cbo_AuthorizationParameter.Location = New System.Drawing.Point(183, 49)
        Me.cbo_AuthorizationParameter.Name = "cbo_AuthorizationParameter"
        Me.cbo_AuthorizationParameter.Size = New System.Drawing.Size(300, 21)
        Me.cbo_AuthorizationParameter.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 1031
        Me.Label2.Text = "Authorization Parameter *"
        '
        'grp_tool
        '
        Me.grp_tool.Controls.Add(Me.bt_close)
        Me.grp_tool.Controls.Add(Me.BT_Update)
        Me.grp_tool.Location = New System.Drawing.Point(38, 641)
        Me.grp_tool.Name = "grp_tool"
        Me.grp_tool.Size = New System.Drawing.Size(903, 51)
        Me.grp_tool.TabIndex = 1033
        Me.grp_tool.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(487, 14)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 16
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'BT_Update
        '
        Me.BT_Update.Location = New System.Drawing.Point(372, 14)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(99, 29)
        Me.BT_Update.TabIndex = 15
        Me.BT_Update.Text = "Save"
        Me.BT_Update.UseVisualStyleBackColor = True
        '
        'cbo_Product
        '
        Me.cbo_Product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Product.FormattingEnabled = True
        Me.cbo_Product.Location = New System.Drawing.Point(183, 76)
        Me.cbo_Product.Name = "cbo_Product"
        Me.cbo_Product.Size = New System.Drawing.Size(134, 21)
        Me.cbo_Product.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(127, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1034
        Me.Label1.Text = "Product *"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(76, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 1037
        Me.Label3.Text = "Authorization Type *"
        '
        'txt_LimitFrom
        '
        Me.txt_LimitFrom.Location = New System.Drawing.Point(592, 49)
        Me.txt_LimitFrom.MaxLength = 0
        Me.txt_LimitFrom.Name = "txt_LimitFrom"
        Me.txt_LimitFrom.Size = New System.Drawing.Size(249, 20)
        Me.txt_LimitFrom.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(526, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 1041
        Me.Label5.Text = "Limit From *"
        '
        'txt_LimitTo
        '
        Me.txt_LimitTo.Location = New System.Drawing.Point(592, 75)
        Me.txt_LimitTo.MaxLength = 0
        Me.txt_LimitTo.Name = "txt_LimitTo"
        Me.txt_LimitTo.Size = New System.Drawing.Size(249, 20)
        Me.txt_LimitTo.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(536, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 1043
        Me.Label6.Text = "Limit To *"
        '
        'lb_user
        '
        Me.lb_user.AutoSize = True
        Me.lb_user.Location = New System.Drawing.Point(123, 220)
        Me.lb_user.Name = "lb_user"
        Me.lb_user.Size = New System.Drawing.Size(54, 13)
        Me.lb_user.TabIndex = 1053
        Me.lb_user.Text = "User List :"
        '
        'cbo_Account
        '
        Me.cbo_Account.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Account.FormattingEnabled = True
        Me.cbo_Account.Location = New System.Drawing.Point(183, 130)
        Me.cbo_Account.Name = "cbo_Account"
        Me.cbo_Account.Size = New System.Drawing.Size(300, 21)
        Me.cbo_Account.TabIndex = 3
        '
        'lb_account_or_product
        '
        Me.lb_account_or_product.AutoSize = True
        Me.lb_account_or_product.Location = New System.Drawing.Point(127, 133)
        Me.lb_account_or_product.Name = "lb_account_or_product"
        Me.lb_account_or_product.Size = New System.Drawing.Size(54, 13)
        Me.lb_account_or_product.TabIndex = 1056
        Me.lb_account_or_product.Text = "Account *"
        '
        'cbo_AuthorizationType
        '
        Me.cbo_AuthorizationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_AuthorizationType.Enabled = False
        Me.cbo_AuthorizationType.FormattingEnabled = True
        Me.cbo_AuthorizationType.Location = New System.Drawing.Point(183, 103)
        Me.cbo_AuthorizationType.Name = "cbo_AuthorizationType"
        Me.cbo_AuthorizationType.Size = New System.Drawing.Size(300, 21)
        Me.cbo_AuthorizationType.TabIndex = 2
        '
        'txt_LevelNumber
        '
        Me.txt_LevelNumber.Location = New System.Drawing.Point(592, 102)
        Me.txt_LevelNumber.MaxLength = 0
        Me.txt_LevelNumber.Name = "txt_LevelNumber"
        Me.txt_LevelNumber.Size = New System.Drawing.Size(99, 20)
        Me.txt_LevelNumber.TabIndex = 6
        '
        'lb_LevelNumber
        '
        Me.lb_LevelNumber.AutoSize = True
        Me.lb_LevelNumber.Location = New System.Drawing.Point(520, 105)
        Me.lb_LevelNumber.Name = "lb_LevelNumber"
        Me.lb_LevelNumber.Size = New System.Drawing.Size(65, 13)
        Me.lb_LevelNumber.TabIndex = 1058
        Me.lb_LevelNumber.Text = "Auth Level *"
        '
        'txt_NoOfUser
        '
        Me.txt_NoOfUser.Location = New System.Drawing.Point(592, 128)
        Me.txt_NoOfUser.MaxLength = 0
        Me.txt_NoOfUser.Name = "txt_NoOfUser"
        Me.txt_NoOfUser.Size = New System.Drawing.Size(99, 20)
        Me.txt_NoOfUser.TabIndex = 7
        '
        'lb_NoOfUser
        '
        Me.lb_NoOfUser.AutoSize = True
        Me.lb_NoOfUser.Location = New System.Drawing.Point(520, 131)
        Me.lb_NoOfUser.Name = "lb_NoOfUser"
        Me.lb_NoOfUser.Size = New System.Drawing.Size(68, 13)
        Me.lb_NoOfUser.TabIndex = 1060
        Me.lb_NoOfUser.Text = "No. of User *"
        '
        'lst_user
        '
        Me.lst_user.FormattingEnabled = True
        Me.lst_user.Location = New System.Drawing.Point(6, 16)
        Me.lst_user.Name = "lst_user"
        Me.lst_user.Size = New System.Drawing.Size(348, 169)
        Me.lst_user.TabIndex = 8
        Me.lst_user.ThreeDCheckBoxes = True
        '
        'Panel_SVM
        '
        Me.Panel_SVM.AutoScroll = True
        Me.Panel_SVM.BackColor = System.Drawing.SystemColors.Control
        Me.Panel_SVM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_SVM.Controls.Add(Me.btnClear)
        Me.Panel_SVM.Controls.Add(Me.btn_Down)
        Me.Panel_SVM.Controls.Add(Me.btnUp)
        Me.Panel_SVM.Controls.Add(Me.btn_remove)
        Me.Panel_SVM.Controls.Add(Me.lstdata)
        Me.Panel_SVM.Controls.Add(Me.btn_add_user)
        Me.Panel_SVM.Controls.Add(Me.btn_add_category)
        Me.Panel_SVM.Controls.Add(Me.cbo_user)
        Me.Panel_SVM.Controls.Add(Me.Label7)
        Me.Panel_SVM.Controls.Add(Me.cbo_category)
        Me.Panel_SVM.Controls.Add(Me.Label4)
        Me.Panel_SVM.Controls.Add(Me.rad_end_group)
        Me.Panel_SVM.Controls.Add(Me.rad_start_group)
        Me.Panel_SVM.Controls.Add(Me.txt_SignatoryMatrix)
        Me.Panel_SVM.Location = New System.Drawing.Point(4, 4)
        Me.Panel_SVM.Name = "Panel_SVM"
        Me.Panel_SVM.Size = New System.Drawing.Size(680, 374)
        Me.Panel_SVM.TabIndex = 1061
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(557, 219)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(99, 29)
        Me.btnClear.TabIndex = 1048
        Me.btnClear.Text = "Clear All"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btn_Down
        '
        Me.btn_Down.Location = New System.Drawing.Point(557, 184)
        Me.btn_Down.Name = "btn_Down"
        Me.btn_Down.Size = New System.Drawing.Size(99, 29)
        Me.btn_Down.TabIndex = 1047
        Me.btn_Down.Text = "Down"
        Me.btn_Down.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Location = New System.Drawing.Point(557, 149)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(99, 29)
        Me.btnUp.TabIndex = 1046
        Me.btnUp.Text = "Up"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btn_remove
        '
        Me.btn_remove.Location = New System.Drawing.Point(557, 114)
        Me.btn_remove.Name = "btn_remove"
        Me.btn_remove.Size = New System.Drawing.Size(99, 29)
        Me.btn_remove.TabIndex = 1045
        Me.btn_remove.Text = "Remove Item"
        Me.btn_remove.UseVisualStyleBackColor = True
        '
        'lstdata
        '
        Me.lstdata.FormattingEnabled = True
        Me.lstdata.Location = New System.Drawing.Point(27, 114)
        Me.lstdata.Name = "lstdata"
        Me.lstdata.Size = New System.Drawing.Size(524, 134)
        Me.lstdata.TabIndex = 1044
        '
        'btn_add_user
        '
        Me.btn_add_user.Location = New System.Drawing.Point(434, 70)
        Me.btn_add_user.Name = "btn_add_user"
        Me.btn_add_user.Size = New System.Drawing.Size(99, 29)
        Me.btn_add_user.TabIndex = 1043
        Me.btn_add_user.Text = "Add User"
        Me.btn_add_user.UseVisualStyleBackColor = True
        '
        'btn_add_category
        '
        Me.btn_add_category.Location = New System.Drawing.Point(434, 32)
        Me.btn_add_category.Name = "btn_add_category"
        Me.btn_add_category.Size = New System.Drawing.Size(99, 29)
        Me.btn_add_category.TabIndex = 1042
        Me.btn_add_category.Text = "Add Category"
        Me.btn_add_category.UseVisualStyleBackColor = True
        '
        'cbo_user
        '
        Me.cbo_user.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_user.Enabled = False
        Me.cbo_user.FormattingEnabled = True
        Me.cbo_user.Location = New System.Drawing.Point(128, 75)
        Me.cbo_user.Name = "cbo_user"
        Me.cbo_user.Size = New System.Drawing.Size(300, 21)
        Me.cbo_user.TabIndex = 1040
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(89, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 1041
        Me.Label7.Text = "User"
        '
        'cbo_category
        '
        Me.cbo_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_category.FormattingEnabled = True
        Me.cbo_category.Location = New System.Drawing.Point(128, 36)
        Me.cbo_category.Name = "cbo_category"
        Me.cbo_category.Size = New System.Drawing.Size(300, 21)
        Me.cbo_category.TabIndex = 1038
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(74, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 1039
        Me.Label4.Text = "Category"
        '
        'rad_end_group
        '
        Me.rad_end_group.AutoSize = True
        Me.rad_end_group.Location = New System.Drawing.Point(114, 6)
        Me.rad_end_group.Name = "rad_end_group"
        Me.rad_end_group.Size = New System.Drawing.Size(79, 17)
        Me.rad_end_group.TabIndex = 12
        Me.rad_end_group.Text = "New Group"
        Me.rad_end_group.UseVisualStyleBackColor = True
        '
        'rad_start_group
        '
        Me.rad_start_group.AutoSize = True
        Me.rad_start_group.Checked = True
        Me.rad_start_group.Location = New System.Drawing.Point(12, 7)
        Me.rad_start_group.Name = "rad_start_group"
        Me.rad_start_group.Size = New System.Drawing.Size(94, 17)
        Me.rad_start_group.TabIndex = 11
        Me.rad_start_group.TabStop = True
        Me.rad_start_group.Text = "Append Group"
        Me.rad_start_group.UseVisualStyleBackColor = True
        '
        'txt_SignatoryMatrix
        '
        Me.txt_SignatoryMatrix.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txt_SignatoryMatrix.Location = New System.Drawing.Point(27, 261)
        Me.txt_SignatoryMatrix.MaxLength = 0
        Me.txt_SignatoryMatrix.Multiline = True
        Me.txt_SignatoryMatrix.Name = "txt_SignatoryMatrix"
        Me.txt_SignatoryMatrix.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_SignatoryMatrix.Size = New System.Drawing.Size(609, 94)
        Me.txt_SignatoryMatrix.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoFalse)
        Me.GroupBox1.Controls.Add(Me.rdoTrue)
        Me.GroupBox1.Location = New System.Drawing.Point(183, 157)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 41)
        Me.GroupBox1.TabIndex = 1062
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Valid Flag"
        '
        'rdoFalse
        '
        Me.rdoFalse.AutoSize = True
        Me.rdoFalse.Location = New System.Drawing.Point(139, 18)
        Me.rdoFalse.Name = "rdoFalse"
        Me.rdoFalse.Size = New System.Drawing.Size(50, 17)
        Me.rdoFalse.TabIndex = 1
        Me.rdoFalse.Text = "False"
        Me.rdoFalse.UseVisualStyleBackColor = True
        '
        'rdoTrue
        '
        Me.rdoTrue.AutoSize = True
        Me.rdoTrue.Checked = True
        Me.rdoTrue.Location = New System.Drawing.Point(61, 18)
        Me.rdoTrue.Name = "rdoTrue"
        Me.rdoTrue.Size = New System.Drawing.Size(47, 17)
        Me.rdoTrue.TabIndex = 0
        Me.rdoTrue.TabStop = True
        Me.rdoTrue.Text = "True"
        Me.rdoTrue.UseVisualStyleBackColor = True
        '
        'TabUserList
        '
        Me.TabUserList.Controls.Add(Me.tabSVM)
        Me.TabUserList.Controls.Add(Me.tabAVM)
        Me.TabUserList.Location = New System.Drawing.Point(183, 214)
        Me.TabUserList.Name = "TabUserList"
        Me.TabUserList.SelectedIndex = 0
        Me.TabUserList.Size = New System.Drawing.Size(747, 410)
        Me.TabUserList.TabIndex = 1063
        '
        'tabSVM
        '
        Me.tabSVM.Controls.Add(Me.Panel_SVM)
        Me.tabSVM.Location = New System.Drawing.Point(4, 22)
        Me.tabSVM.Name = "tabSVM"
        Me.tabSVM.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSVM.Size = New System.Drawing.Size(739, 384)
        Me.tabSVM.TabIndex = 0
        Me.tabSVM.Text = "SVM"
        Me.tabSVM.UseVisualStyleBackColor = True
        '
        'tabAVM
        '
        Me.tabAVM.Controls.Add(Me.lst_user)
        Me.tabAVM.Location = New System.Drawing.Point(4, 22)
        Me.tabAVM.Name = "tabAVM"
        Me.tabAVM.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAVM.Size = New System.Drawing.Size(739, 384)
        Me.tabAVM.TabIndex = 1
        Me.tabAVM.Text = "AVM"
        Me.tabAVM.UseVisualStyleBackColor = True
        '
        'Frm_DealSummary_auth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 697)
        Me.Controls.Add(Me.TabUserList)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_NoOfUser)
        Me.Controls.Add(Me.lb_NoOfUser)
        Me.Controls.Add(Me.txt_LevelNumber)
        Me.Controls.Add(Me.lb_LevelNumber)
        Me.Controls.Add(Me.cbo_AuthorizationType)
        Me.Controls.Add(Me.cbo_Account)
        Me.Controls.Add(Me.lb_account_or_product)
        Me.Controls.Add(Me.lb_user)
        Me.Controls.Add(Me.txt_LimitTo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_LimitFrom)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbo_Product)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grp_tool)
        Me.Controls.Add(Me.cbo_AuthorizationParameter)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Frm_DealSummary_auth"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.grp_tool.ResumeLayout(False)
        Me.Panel_SVM.ResumeLayout(False)
        Me.Panel_SVM.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabUserList.ResumeLayout(False)
        Me.tabSVM.ResumeLayout(False)
        Me.tabAVM.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbHead As System.Windows.Forms.Label
    Friend WithEvents cbo_AuthorizationParameter As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grp_tool As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents cbo_Product As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_LimitFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_LimitTo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lb_user As System.Windows.Forms.Label
    Friend WithEvents cbo_Account As System.Windows.Forms.ComboBox
    Friend WithEvents lb_account_or_product As System.Windows.Forms.Label
    Friend WithEvents cbo_AuthorizationType As System.Windows.Forms.ComboBox
    Friend WithEvents txt_company_id As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_LevelNumber As System.Windows.Forms.TextBox
    Friend WithEvents lb_LevelNumber As System.Windows.Forms.Label
    Friend WithEvents txt_NoOfUser As System.Windows.Forms.TextBox
    Friend WithEvents lb_NoOfUser As System.Windows.Forms.Label
    Friend WithEvents lst_user As System.Windows.Forms.CheckedListBox
    Friend WithEvents Panel_SVM As System.Windows.Forms.Panel
    Friend WithEvents txt_SignatoryMatrix As System.Windows.Forms.TextBox
    Friend WithEvents rad_start_group As System.Windows.Forms.RadioButton
    Friend WithEvents rad_end_group As System.Windows.Forms.RadioButton
    Friend WithEvents cbo_user As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_category As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_add_user As System.Windows.Forms.Button
    Friend WithEvents btn_add_category As System.Windows.Forms.Button
    Friend WithEvents btn_remove As System.Windows.Forms.Button
    Friend WithEvents lstdata As System.Windows.Forms.ListBox
    Friend WithEvents btn_Down As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents txt_revision_desc As System.Windows.Forms.TextBox
    Friend WithEvents txt_revision_code As System.Windows.Forms.TextBox
    Friend WithEvents txt_ID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoFalse As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTrue As System.Windows.Forms.RadioButton
    Friend WithEvents TabUserList As System.Windows.Forms.TabControl
    Friend WithEvents tabSVM As System.Windows.Forms.TabPage
    Friend WithEvents tabAVM As System.Windows.Forms.TabPage
End Class
