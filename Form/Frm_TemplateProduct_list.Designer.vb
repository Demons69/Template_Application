<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_TemplateProduct_list
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_Product = New System.Windows.Forms.ComboBox
        Me.cbo_FloatSharingPercentage = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.grp_search = New System.Windows.Forms.GroupBox
        Me.pnl_StalePeriodType_D = New System.Windows.Forms.Panel
        Me.rad_StalePeriodType_M = New System.Windows.Forms.RadioButton
        Me.rad_StalePeriodType_D = New System.Windows.Forms.RadioButton
        Me.txt_StalePeriod = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtdsfsdf = New System.Windows.Forms.Label
        Me.btn_Find = New System.Windows.Forms.Button
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.opt_ExportDownloadReq_No = New System.Windows.Forms.RadioButton
        Me.opt_ExportDownloadReq_Yes = New System.Windows.Forms.RadioButton
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.pnl_RepostGL = New System.Windows.Forms.Panel
        Me.opt_RepostGL_No = New System.Windows.Forms.RadioButton
        Me.opt_RepostGL_Yes = New System.Windows.Forms.RadioButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.cbo_BeneAdviceOn = New System.Windows.Forms.ComboBox
        Me.cbo_CustomerFloatRate1 = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.opt_AdviceEmailRequired_No = New System.Windows.Forms.RadioButton
        Me.opt_AdviceEmailRequired_Yes = New System.Windows.Forms.RadioButton
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.opt_AdviceFaxRequired_No = New System.Windows.Forms.RadioButton
        Me.opt_AdviceFaxRequired_Yes = New System.Windows.Forms.RadioButton
        Me.Label20 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.bt_close = New System.Windows.Forms.Button
        Me.btn_print = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_Template = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_Delete = New System.Windows.Forms.Button
        Me.btn_create = New System.Windows.Forms.Button
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.opt_GLRejectCharges_No = New System.Windows.Forms.RadioButton
        Me.opt_GLRejectCharges_Yes = New System.Windows.Forms.RadioButton
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbo_DafaultArrangement = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_Deal_ID = New System.Windows.Forms.TextBox
        Me.btnPrint_Detail = New System.Windows.Forms.Button
        Me.btnSendTo = New System.Windows.Forms.Button
        Me.btn_new_template = New System.Windows.Forms.Button
        Me.txt_Return = New System.Windows.Forms.TextBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_search.SuspendLayout()
        Me.pnl_StalePeriodType_D.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.pnl_RepostGL.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.Location = New System.Drawing.Point(12, 292)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(752, 50)
        Me.DataGridView1.TabIndex = 999
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(103, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Product"
        '
        'cbo_Product
        '
        Me.cbo_Product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbo_Product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_Product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Product.DropDownWidth = 331
        Me.cbo_Product.FormattingEnabled = True
        Me.cbo_Product.Location = New System.Drawing.Point(167, 21)
        Me.cbo_Product.Name = "cbo_Product"
        Me.cbo_Product.Size = New System.Drawing.Size(202, 21)
        Me.cbo_Product.TabIndex = 0
        '
        'cbo_FloatSharingPercentage
        '
        Me.cbo_FloatSharingPercentage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbo_FloatSharingPercentage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_FloatSharingPercentage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_FloatSharingPercentage.Enabled = False
        Me.cbo_FloatSharingPercentage.FormattingEnabled = True
        Me.cbo_FloatSharingPercentage.Location = New System.Drawing.Point(528, 48)
        Me.cbo_FloatSharingPercentage.Name = "cbo_FloatSharingPercentage"
        Me.cbo_FloatSharingPercentage.Size = New System.Drawing.Size(131, 21)
        Me.cbo_FloatSharingPercentage.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(393, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 13)
        Me.Label11.TabIndex = 122
        Me.Label11.Text = "Float Sharing Percentage"
        '
        'grp_search
        '
        Me.grp_search.Controls.Add(Me.txt_Return)
        Me.grp_search.Controls.Add(Me.pnl_StalePeriodType_D)
        Me.grp_search.Controls.Add(Me.txt_StalePeriod)
        Me.grp_search.Controls.Add(Me.Label13)
        Me.grp_search.Controls.Add(Me.txtdsfsdf)
        Me.grp_search.Controls.Add(Me.btn_Find)
        Me.grp_search.Controls.Add(Me.Panel11)
        Me.grp_search.Controls.Add(Me.Label24)
        Me.grp_search.Controls.Add(Me.Label18)
        Me.grp_search.Controls.Add(Me.pnl_RepostGL)
        Me.grp_search.Controls.Add(Me.Label15)
        Me.grp_search.Controls.Add(Me.cbo_BeneAdviceOn)
        Me.grp_search.Controls.Add(Me.cbo_CustomerFloatRate1)
        Me.grp_search.Controls.Add(Me.Label10)
        Me.grp_search.Controls.Add(Me.Label21)
        Me.grp_search.Controls.Add(Me.Panel7)
        Me.grp_search.Controls.Add(Me.Panel6)
        Me.grp_search.Controls.Add(Me.Label20)
        Me.grp_search.Controls.Add(Me.cbo_Product)
        Me.grp_search.Controls.Add(Me.Label1)
        Me.grp_search.Controls.Add(Me.cbo_FloatSharingPercentage)
        Me.grp_search.Controls.Add(Me.Label11)
        Me.grp_search.Location = New System.Drawing.Point(12, 41)
        Me.grp_search.Name = "grp_search"
        Me.grp_search.Size = New System.Drawing.Size(848, 206)
        Me.grp_search.TabIndex = 0
        Me.grp_search.TabStop = False
        Me.grp_search.Text = "Criteria :"
        '
        'pnl_StalePeriodType_D
        '
        Me.pnl_StalePeriodType_D.Controls.Add(Me.rad_StalePeriodType_M)
        Me.pnl_StalePeriodType_D.Controls.Add(Me.rad_StalePeriodType_D)
        Me.pnl_StalePeriodType_D.Location = New System.Drawing.Point(528, 75)
        Me.pnl_StalePeriodType_D.Name = "pnl_StalePeriodType_D"
        Me.pnl_StalePeriodType_D.Size = New System.Drawing.Size(129, 21)
        Me.pnl_StalePeriodType_D.TabIndex = 1003
        '
        'rad_StalePeriodType_M
        '
        Me.rad_StalePeriodType_M.AutoSize = True
        Me.rad_StalePeriodType_M.Checked = True
        Me.rad_StalePeriodType_M.Location = New System.Drawing.Point(63, 3)
        Me.rad_StalePeriodType_M.Name = "rad_StalePeriodType_M"
        Me.rad_StalePeriodType_M.Size = New System.Drawing.Size(62, 17)
        Me.rad_StalePeriodType_M.TabIndex = 1
        Me.rad_StalePeriodType_M.TabStop = True
        Me.rad_StalePeriodType_M.Text = "Monthly"
        Me.rad_StalePeriodType_M.UseVisualStyleBackColor = True
        '
        'rad_StalePeriodType_D
        '
        Me.rad_StalePeriodType_D.AutoSize = True
        Me.rad_StalePeriodType_D.Location = New System.Drawing.Point(3, 3)
        Me.rad_StalePeriodType_D.Name = "rad_StalePeriodType_D"
        Me.rad_StalePeriodType_D.Size = New System.Drawing.Size(48, 17)
        Me.rad_StalePeriodType_D.TabIndex = 0
        Me.rad_StalePeriodType_D.TabStop = True
        Me.rad_StalePeriodType_D.Text = "Daily"
        Me.rad_StalePeriodType_D.UseVisualStyleBackColor = True
        '
        'txt_StalePeriod
        '
        Me.txt_StalePeriod.BackColor = System.Drawing.Color.White
        Me.txt_StalePeriod.ForeColor = System.Drawing.Color.Black
        Me.txt_StalePeriod.Location = New System.Drawing.Point(527, 102)
        Me.txt_StalePeriod.Name = "txt_StalePeriod"
        Me.txt_StalePeriod.Size = New System.Drawing.Size(169, 20)
        Me.txt_StalePeriod.TabIndex = 1004
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(454, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 1006
        Me.Label13.Text = "StalePeriod"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtdsfsdf
        '
        Me.txtdsfsdf.AutoSize = True
        Me.txtdsfsdf.Location = New System.Drawing.Point(424, 78)
        Me.txtdsfsdf.Name = "txtdsfsdf"
        Me.txtdsfsdf.Size = New System.Drawing.Size(91, 13)
        Me.txtdsfsdf.TabIndex = 1005
        Me.txtdsfsdf.Text = "Stale Period Type"
        Me.txtdsfsdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_Find
        '
        Me.btn_Find.Enabled = False
        Me.btn_Find.Location = New System.Drawing.Point(20, 157)
        Me.btn_Find.Name = "btn_Find"
        Me.btn_Find.Size = New System.Drawing.Size(120, 33)
        Me.btn_Find.TabIndex = 1002
        Me.btn_Find.Text = "&Search"
        Me.btn_Find.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.opt_ExportDownloadReq_No)
        Me.Panel11.Controls.Add(Me.opt_ExportDownloadReq_Yes)
        Me.Panel11.Location = New System.Drawing.Point(238, 128)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(125, 21)
        Me.Panel11.TabIndex = 22
        '
        'opt_ExportDownloadReq_No
        '
        Me.opt_ExportDownloadReq_No.AutoSize = True
        Me.opt_ExportDownloadReq_No.Checked = True
        Me.opt_ExportDownloadReq_No.Location = New System.Drawing.Point(72, 3)
        Me.opt_ExportDownloadReq_No.Name = "opt_ExportDownloadReq_No"
        Me.opt_ExportDownloadReq_No.Size = New System.Drawing.Size(39, 17)
        Me.opt_ExportDownloadReq_No.TabIndex = 2
        Me.opt_ExportDownloadReq_No.TabStop = True
        Me.opt_ExportDownloadReq_No.Text = "No"
        Me.opt_ExportDownloadReq_No.UseVisualStyleBackColor = True
        '
        'opt_ExportDownloadReq_Yes
        '
        Me.opt_ExportDownloadReq_Yes.AutoSize = True
        Me.opt_ExportDownloadReq_Yes.Location = New System.Drawing.Point(12, 3)
        Me.opt_ExportDownloadReq_Yes.Name = "opt_ExportDownloadReq_Yes"
        Me.opt_ExportDownloadReq_Yes.Size = New System.Drawing.Size(43, 17)
        Me.opt_ExportDownloadReq_Yes.TabIndex = 1
        Me.opt_ExportDownloadReq_Yes.Text = "Yes"
        Me.opt_ExportDownloadReq_Yes.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(9, 132)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(228, 13)
        Me.Label24.TabIndex = 185
        Me.Label24.Text = "JP MORGAN GROUP (Export Download Req.)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(464, 134)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 13)
        Me.Label18.TabIndex = 184
        Me.Label18.Text = "Repost GL"
        '
        'pnl_RepostGL
        '
        Me.pnl_RepostGL.Controls.Add(Me.opt_RepostGL_No)
        Me.pnl_RepostGL.Controls.Add(Me.opt_RepostGL_Yes)
        Me.pnl_RepostGL.Enabled = False
        Me.pnl_RepostGL.Location = New System.Drawing.Point(526, 129)
        Me.pnl_RepostGL.Name = "pnl_RepostGL"
        Me.pnl_RepostGL.Size = New System.Drawing.Size(199, 21)
        Me.pnl_RepostGL.TabIndex = 15
        '
        'opt_RepostGL_No
        '
        Me.opt_RepostGL_No.AutoSize = True
        Me.opt_RepostGL_No.Checked = True
        Me.opt_RepostGL_No.Location = New System.Drawing.Point(69, 3)
        Me.opt_RepostGL_No.Name = "opt_RepostGL_No"
        Me.opt_RepostGL_No.Size = New System.Drawing.Size(39, 17)
        Me.opt_RepostGL_No.TabIndex = 2
        Me.opt_RepostGL_No.TabStop = True
        Me.opt_RepostGL_No.Text = "No"
        Me.opt_RepostGL_No.UseVisualStyleBackColor = True
        '
        'opt_RepostGL_Yes
        '
        Me.opt_RepostGL_Yes.AutoSize = True
        Me.opt_RepostGL_Yes.Location = New System.Drawing.Point(5, 3)
        Me.opt_RepostGL_Yes.Name = "opt_RepostGL_Yes"
        Me.opt_RepostGL_Yes.Size = New System.Drawing.Size(43, 17)
        Me.opt_RepostGL_Yes.TabIndex = 1
        Me.opt_RepostGL_Yes.Text = "Yes"
        Me.opt_RepostGL_Yes.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(75, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 13)
        Me.Label15.TabIndex = 183
        Me.Label15.Text = "Bene Advice ON"
        '
        'cbo_BeneAdviceOn
        '
        Me.cbo_BeneAdviceOn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbo_BeneAdviceOn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_BeneAdviceOn.FormattingEnabled = True
        Me.cbo_BeneAdviceOn.Items.AddRange(New Object() {"NONE", "Data Entry", "Debit", "Print", "(All)"})
        Me.cbo_BeneAdviceOn.Location = New System.Drawing.Point(167, 101)
        Me.cbo_BeneAdviceOn.Name = "cbo_BeneAdviceOn"
        Me.cbo_BeneAdviceOn.Size = New System.Drawing.Size(175, 21)
        Me.cbo_BeneAdviceOn.TabIndex = 25
        '
        'cbo_CustomerFloatRate1
        '
        Me.cbo_CustomerFloatRate1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbo_CustomerFloatRate1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_CustomerFloatRate1.DropDownWidth = 500
        Me.cbo_CustomerFloatRate1.Enabled = False
        Me.cbo_CustomerFloatRate1.FormattingEnabled = True
        Me.cbo_CustomerFloatRate1.Location = New System.Drawing.Point(529, 21)
        Me.cbo_CustomerFloatRate1.Name = "cbo_CustomerFloatRate1"
        Me.cbo_CustomerFloatRate1.Size = New System.Drawing.Size(310, 21)
        Me.cbo_CustomerFloatRate1.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(382, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 13)
        Me.Label10.TabIndex = 177
        Me.Label10.Text = "Customer Float Computation"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(42, 77)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(111, 13)
        Me.Label21.TabIndex = 176
        Me.Label21.Text = "Advice Email Request"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.opt_AdviceEmailRequired_No)
        Me.Panel7.Controls.Add(Me.opt_AdviceEmailRequired_Yes)
        Me.Panel7.Location = New System.Drawing.Point(167, 73)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(199, 21)
        Me.Panel7.TabIndex = 10
        '
        'opt_AdviceEmailRequired_No
        '
        Me.opt_AdviceEmailRequired_No.AutoSize = True
        Me.opt_AdviceEmailRequired_No.Checked = True
        Me.opt_AdviceEmailRequired_No.Location = New System.Drawing.Point(72, 3)
        Me.opt_AdviceEmailRequired_No.Name = "opt_AdviceEmailRequired_No"
        Me.opt_AdviceEmailRequired_No.Size = New System.Drawing.Size(39, 17)
        Me.opt_AdviceEmailRequired_No.TabIndex = 2
        Me.opt_AdviceEmailRequired_No.TabStop = True
        Me.opt_AdviceEmailRequired_No.Text = "No"
        Me.opt_AdviceEmailRequired_No.UseVisualStyleBackColor = True
        '
        'opt_AdviceEmailRequired_Yes
        '
        Me.opt_AdviceEmailRequired_Yes.AutoSize = True
        Me.opt_AdviceEmailRequired_Yes.Location = New System.Drawing.Point(12, 3)
        Me.opt_AdviceEmailRequired_Yes.Name = "opt_AdviceEmailRequired_Yes"
        Me.opt_AdviceEmailRequired_Yes.Size = New System.Drawing.Size(43, 17)
        Me.opt_AdviceEmailRequired_Yes.TabIndex = 1
        Me.opt_AdviceEmailRequired_Yes.Text = "Yes"
        Me.opt_AdviceEmailRequired_Yes.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.opt_AdviceFaxRequired_No)
        Me.Panel6.Controls.Add(Me.opt_AdviceFaxRequired_Yes)
        Me.Panel6.Location = New System.Drawing.Point(167, 46)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(199, 21)
        Me.Panel6.TabIndex = 6
        '
        'opt_AdviceFaxRequired_No
        '
        Me.opt_AdviceFaxRequired_No.AutoSize = True
        Me.opt_AdviceFaxRequired_No.Checked = True
        Me.opt_AdviceFaxRequired_No.Location = New System.Drawing.Point(71, 3)
        Me.opt_AdviceFaxRequired_No.Name = "opt_AdviceFaxRequired_No"
        Me.opt_AdviceFaxRequired_No.Size = New System.Drawing.Size(39, 17)
        Me.opt_AdviceFaxRequired_No.TabIndex = 2
        Me.opt_AdviceFaxRequired_No.TabStop = True
        Me.opt_AdviceFaxRequired_No.Text = "No"
        Me.opt_AdviceFaxRequired_No.UseVisualStyleBackColor = True
        '
        'opt_AdviceFaxRequired_Yes
        '
        Me.opt_AdviceFaxRequired_Yes.AutoSize = True
        Me.opt_AdviceFaxRequired_Yes.Location = New System.Drawing.Point(11, 3)
        Me.opt_AdviceFaxRequired_Yes.Name = "opt_AdviceFaxRequired_Yes"
        Me.opt_AdviceFaxRequired_Yes.Size = New System.Drawing.Size(43, 17)
        Me.opt_AdviceFaxRequired_Yes.TabIndex = 1
        Me.opt_AdviceFaxRequired_Yes.Text = "Yes"
        Me.opt_AdviceFaxRequired_Yes.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(50, 51)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 13)
        Me.Label20.TabIndex = 174
        Me.Label20.Text = "Advice Fax Request"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.bt_close)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 394)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(872, 46)
        Me.Panel1.TabIndex = 27
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(17, 3)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 33)
        Me.bt_close.TabIndex = 32
        Me.bt_close.Text = "&Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'btn_print
        '
        Me.btn_print.Location = New System.Drawing.Point(364, 253)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(82, 33)
        Me.btn_print.TabIndex = 30
        Me.btn_print.Text = "&Print To CA"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(191, 263)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Selected"
        '
        'txt_Template
        '
        Me.txt_Template.BackColor = System.Drawing.Color.White
        Me.txt_Template.Location = New System.Drawing.Point(245, 260)
        Me.txt_Template.Name = "txt_Template"
        Me.txt_Template.Size = New System.Drawing.Size(109, 20)
        Me.txt_Template.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(872, 35)
        Me.Panel2.TabIndex = 164
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
        Me.Label17.Text = "TEMPLATE PRODUCT"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.btn_Delete)
        Me.GroupBox1.Controls.Add(Me.btn_create)
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbo_DafaultArrangement)
        Me.GroupBox1.Location = New System.Drawing.Point(316, 288)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 113)
        Me.GroupBox1.TabIndex = 1000
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "UNUSED"
        Me.GroupBox1.Visible = False
        '
        'btn_Delete
        '
        Me.btn_Delete.Enabled = False
        Me.btn_Delete.Location = New System.Drawing.Point(48, 67)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(120, 33)
        Me.btn_Delete.TabIndex = 191
        Me.btn_Delete.Text = "Delete"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_create
        '
        Me.btn_create.Enabled = False
        Me.btn_create.Location = New System.Drawing.Point(181, 70)
        Me.btn_create.Name = "btn_create"
        Me.btn_create.Size = New System.Drawing.Size(120, 33)
        Me.btn_create.TabIndex = 190
        Me.btn_create.Text = "Create New Template"
        Me.btn_create.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.opt_GLRejectCharges_No)
        Me.Panel5.Controls.Add(Me.opt_GLRejectCharges_Yes)
        Me.Panel5.Location = New System.Drawing.Point(185, 38)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(199, 21)
        Me.Panel5.TabIndex = 188
        '
        'opt_GLRejectCharges_No
        '
        Me.opt_GLRejectCharges_No.AutoSize = True
        Me.opt_GLRejectCharges_No.Checked = True
        Me.opt_GLRejectCharges_No.Location = New System.Drawing.Point(133, 3)
        Me.opt_GLRejectCharges_No.Name = "opt_GLRejectCharges_No"
        Me.opt_GLRejectCharges_No.Size = New System.Drawing.Size(39, 17)
        Me.opt_GLRejectCharges_No.TabIndex = 2
        Me.opt_GLRejectCharges_No.TabStop = True
        Me.opt_GLRejectCharges_No.Text = "No"
        Me.opt_GLRejectCharges_No.UseVisualStyleBackColor = True
        '
        'opt_GLRejectCharges_Yes
        '
        Me.opt_GLRejectCharges_Yes.AutoSize = True
        Me.opt_GLRejectCharges_Yes.Location = New System.Drawing.Point(73, 3)
        Me.opt_GLRejectCharges_Yes.Name = "opt_GLRejectCharges_Yes"
        Me.opt_GLRejectCharges_Yes.Size = New System.Drawing.Size(43, 17)
        Me.opt_GLRejectCharges_Yes.TabIndex = 1
        Me.opt_GLRejectCharges_Yes.Text = "Yes"
        Me.opt_GLRejectCharges_Yes.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(79, 41)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(92, 13)
        Me.Label19.TabIndex = 189
        Me.Label19.Text = "GL Reject Charge"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(70, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "Default Arrangment"
        Me.Label7.Visible = False
        '
        'cbo_DafaultArrangement
        '
        Me.cbo_DafaultArrangement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbo_DafaultArrangement.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_DafaultArrangement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_DafaultArrangement.FormattingEnabled = True
        Me.cbo_DafaultArrangement.Location = New System.Drawing.Point(182, 13)
        Me.cbo_DafaultArrangement.Name = "cbo_DafaultArrangement"
        Me.cbo_DafaultArrangement.Size = New System.Drawing.Size(131, 21)
        Me.cbo_DafaultArrangement.TabIndex = 121
        Me.cbo_DafaultArrangement.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 263)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 1002
        Me.Label3.Text = "Deal ID"
        '
        'txt_Deal_ID
        '
        Me.txt_Deal_ID.Location = New System.Drawing.Point(69, 260)
        Me.txt_Deal_ID.Name = "txt_Deal_ID"
        Me.txt_Deal_ID.Size = New System.Drawing.Size(116, 20)
        Me.txt_Deal_ID.TabIndex = 1003
        Me.txt_Deal_ID.Text = "0000-000000-00"
        '
        'btnPrint_Detail
        '
        Me.btnPrint_Detail.Location = New System.Drawing.Point(452, 253)
        Me.btnPrint_Detail.Name = "btnPrint_Detail"
        Me.btnPrint_Detail.Size = New System.Drawing.Size(80, 33)
        Me.btnPrint_Detail.TabIndex = 1008
        Me.btnPrint_Detail.Text = "&Print Detail"
        Me.btnPrint_Detail.UseVisualStyleBackColor = True
        '
        'btnSendTo
        '
        Me.btnSendTo.Location = New System.Drawing.Point(540, 253)
        Me.btnSendTo.Name = "btnSendTo"
        Me.btnSendTo.Size = New System.Drawing.Size(117, 33)
        Me.btnSendTo.TabIndex = 1009
        Me.btnSendTo.Text = "&Send To Deal Form"
        Me.btnSendTo.UseVisualStyleBackColor = True
        Me.btnSendTo.Visible = False
        '
        'btn_new_template
        '
        Me.btn_new_template.Location = New System.Drawing.Point(663, 253)
        Me.btn_new_template.Name = "btn_new_template"
        Me.btn_new_template.Size = New System.Drawing.Size(146, 33)
        Me.btn_new_template.TabIndex = 1010
        Me.btn_new_template.Text = "Create New Template"
        Me.btn_new_template.UseVisualStyleBackColor = True
        Me.btn_new_template.Visible = False
        '
        'txt_Return
        '
        Me.txt_Return.BackColor = System.Drawing.Color.White
        Me.txt_Return.ForeColor = System.Drawing.Color.Black
        Me.txt_Return.Location = New System.Drawing.Point(622, 170)
        Me.txt_Return.Name = "txt_Return"
        Me.txt_Return.Size = New System.Drawing.Size(169, 20)
        Me.txt_Return.TabIndex = 1007
        Me.txt_Return.Visible = False
        '
        'Frm_TemplateProduct_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 440)
        Me.Controls.Add(Me.btn_new_template)
        Me.Controls.Add(Me.btnSendTo)
        Me.Controls.Add(Me.btnPrint_Detail)
        Me.Controls.Add(Me.txt_Deal_ID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grp_search)
        Me.Controls.Add(Me.txt_Template)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_TemplateProduct_list"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_search.ResumeLayout(False)
        Me.grp_search.PerformLayout()
        Me.pnl_StalePeriodType_D.ResumeLayout(False)
        Me.pnl_StalePeriodType_D.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.pnl_RepostGL.ResumeLayout(False)
        Me.pnl_RepostGL.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_Product As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_FloatSharingPercentage As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grp_search As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_print As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Template As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents opt_AdviceEmailRequired_No As System.Windows.Forms.RadioButton
    Friend WithEvents opt_AdviceEmailRequired_Yes As System.Windows.Forms.RadioButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents opt_AdviceFaxRequired_No As System.Windows.Forms.RadioButton
    Friend WithEvents opt_AdviceFaxRequired_Yes As System.Windows.Forms.RadioButton
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cbo_CustomerFloatRate1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents opt_ExportDownloadReq_No As System.Windows.Forms.RadioButton
    Friend WithEvents opt_ExportDownloadReq_Yes As System.Windows.Forms.RadioButton
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents pnl_RepostGL As System.Windows.Forms.Panel
    Friend WithEvents opt_RepostGL_No As System.Windows.Forms.RadioButton
    Friend WithEvents opt_RepostGL_Yes As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbo_BeneAdviceOn As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbo_DafaultArrangement As System.Windows.Forms.ComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents opt_GLRejectCharges_No As System.Windows.Forms.RadioButton
    Friend WithEvents opt_GLRejectCharges_Yes As System.Windows.Forms.RadioButton
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btn_create As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_Find As System.Windows.Forms.Button
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Deal_ID As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint_Detail As System.Windows.Forms.Button
    Friend WithEvents pnl_StalePeriodType_D As System.Windows.Forms.Panel
    Friend WithEvents rad_StalePeriodType_M As System.Windows.Forms.RadioButton
    Friend WithEvents rad_StalePeriodType_D As System.Windows.Forms.RadioButton
    Friend WithEvents txt_StalePeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtdsfsdf As System.Windows.Forms.Label
    Friend WithEvents btnSendTo As System.Windows.Forms.Button
    Friend WithEvents btn_new_template As System.Windows.Forms.Button
    Friend WithEvents txt_Return As System.Windows.Forms.TextBox
End Class
