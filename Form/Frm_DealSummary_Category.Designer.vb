<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_Category
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
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.chk_deal_cover_admin = New System.Windows.Forms.CheckBox
        Me.chk_deal_cover_payment = New System.Windows.Forms.CheckBox
        Me.chk_deal_cover_inquiry = New System.Windows.Forms.CheckBox
        Me.txt_company_id = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_ClearPrintFlag = New System.Windows.Forms.Button
        Me.btn_ReportCategory = New System.Windows.Forms.Button
        Me.bt_close = New System.Windows.Forms.Button
        Me.btn_UserCategory = New System.Windows.Forms.Button
        Me.txt_User_Category_ID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_User_Category_Name = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_Report_Category_ID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_Report_Category_Name = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.grd_category_user = New System.Windows.Forms.DataGridView
        Me.txt_client_code = New System.Windows.Forms.TextBox
        Me.txt_seq = New System.Windows.Forms.TextBox
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grd_category_user, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.txt_company_id)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(782, 35)
        Me.Panel2.TabIndex = 197
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chk_deal_cover_admin)
        Me.Panel3.Controls.Add(Me.chk_deal_cover_payment)
        Me.Panel3.Controls.Add(Me.chk_deal_cover_inquiry)
        Me.Panel3.Location = New System.Drawing.Point(268, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(247, 31)
        Me.Panel3.TabIndex = 1057
        Me.Panel3.Visible = False
        '
        'chk_deal_cover_admin
        '
        Me.chk_deal_cover_admin.AutoSize = True
        Me.chk_deal_cover_admin.Location = New System.Drawing.Point(166, 5)
        Me.chk_deal_cover_admin.Name = "chk_deal_cover_admin"
        Me.chk_deal_cover_admin.Size = New System.Drawing.Size(55, 17)
        Me.chk_deal_cover_admin.TabIndex = 2
        Me.chk_deal_cover_admin.Text = "Admin"
        Me.chk_deal_cover_admin.UseVisualStyleBackColor = True
        '
        'chk_deal_cover_payment
        '
        Me.chk_deal_cover_payment.AutoSize = True
        Me.chk_deal_cover_payment.Location = New System.Drawing.Point(86, 5)
        Me.chk_deal_cover_payment.Name = "chk_deal_cover_payment"
        Me.chk_deal_cover_payment.Size = New System.Drawing.Size(67, 17)
        Me.chk_deal_cover_payment.TabIndex = 1
        Me.chk_deal_cover_payment.Text = "Payment"
        Me.chk_deal_cover_payment.UseVisualStyleBackColor = True
        '
        'chk_deal_cover_inquiry
        '
        Me.chk_deal_cover_inquiry.AutoSize = True
        Me.chk_deal_cover_inquiry.Location = New System.Drawing.Point(14, 5)
        Me.chk_deal_cover_inquiry.Name = "chk_deal_cover_inquiry"
        Me.chk_deal_cover_inquiry.Size = New System.Drawing.Size(57, 17)
        Me.chk_deal_cover_inquiry.TabIndex = 0
        Me.chk_deal_cover_inquiry.Text = "Inquiry"
        Me.chk_deal_cover_inquiry.UseVisualStyleBackColor = True
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
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(123, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "CATEGORY"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_ClearPrintFlag)
        Me.GroupBox2.Controls.Add(Me.btn_ReportCategory)
        Me.GroupBox2.Controls.Add(Me.bt_close)
        Me.GroupBox2.Controls.Add(Me.btn_UserCategory)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 455)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(747, 51)
        Me.GroupBox2.TabIndex = 1017
        Me.GroupBox2.TabStop = False
        '
        'btn_ClearPrintFlag
        '
        Me.btn_ClearPrintFlag.Location = New System.Drawing.Point(18, 15)
        Me.btn_ClearPrintFlag.Name = "btn_ClearPrintFlag"
        Me.btn_ClearPrintFlag.Size = New System.Drawing.Size(99, 29)
        Me.btn_ClearPrintFlag.TabIndex = 9
        Me.btn_ClearPrintFlag.Text = "Clear Print Flag"
        Me.btn_ClearPrintFlag.UseVisualStyleBackColor = True
        '
        'btn_ReportCategory
        '
        Me.btn_ReportCategory.Location = New System.Drawing.Point(319, 15)
        Me.btn_ReportCategory.Name = "btn_ReportCategory"
        Me.btn_ReportCategory.Size = New System.Drawing.Size(99, 29)
        Me.btn_ReportCategory.TabIndex = 7
        Me.btn_ReportCategory.Text = "Report Category"
        Me.btn_ReportCategory.UseVisualStyleBackColor = True
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(444, 16)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 8
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'btn_UserCategory
        '
        Me.btn_UserCategory.Location = New System.Drawing.Point(189, 16)
        Me.btn_UserCategory.Name = "btn_UserCategory"
        Me.btn_UserCategory.Size = New System.Drawing.Size(99, 29)
        Me.btn_UserCategory.TabIndex = 6
        Me.btn_UserCategory.Text = "User Category"
        Me.btn_UserCategory.UseVisualStyleBackColor = True
        '
        'txt_User_Category_ID
        '
        Me.txt_User_Category_ID.Location = New System.Drawing.Point(286, 63)
        Me.txt_User_Category_ID.MaxLength = 255
        Me.txt_User_Category_ID.Name = "txt_User_Category_ID"
        Me.txt_User_Category_ID.Size = New System.Drawing.Size(249, 20)
        Me.txt_User_Category_ID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(186, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 1021
        Me.Label1.Text = "User Category ID*"
        '
        'txt_User_Category_Name
        '
        Me.txt_User_Category_Name.Location = New System.Drawing.Point(286, 89)
        Me.txt_User_Category_Name.MaxLength = 255
        Me.txt_User_Category_Name.Name = "txt_User_Category_Name"
        Me.txt_User_Category_Name.Size = New System.Drawing.Size(249, 20)
        Me.txt_User_Category_Name.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(166, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 1023
        Me.Label2.Text = "User Category Name *"
        '
        'txt_Report_Category_ID
        '
        Me.txt_Report_Category_ID.Location = New System.Drawing.Point(286, 115)
        Me.txt_Report_Category_ID.MaxLength = 255
        Me.txt_Report_Category_ID.Name = "txt_Report_Category_ID"
        Me.txt_Report_Category_ID.Size = New System.Drawing.Size(249, 20)
        Me.txt_Report_Category_ID.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(173, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 1025
        Me.Label3.Text = "Report Category ID *"
        '
        'txt_Report_Category_Name
        '
        Me.txt_Report_Category_Name.Location = New System.Drawing.Point(286, 141)
        Me.txt_Report_Category_Name.MaxLength = 255
        Me.txt_Report_Category_Name.Name = "txt_Report_Category_Name"
        Me.txt_Report_Category_Name.Size = New System.Drawing.Size(249, 20)
        Me.txt_Report_Category_Name.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(156, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 13)
        Me.Label4.TabIndex = 1027
        Me.Label4.Text = "Report Category Name *"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 1028
        Me.Label6.Text = "User Category ID*"
        '
        'grd_category_user
        '
        Me.grd_category_user.AllowUserToAddRows = False
        Me.grd_category_user.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_category_user.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_category_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grd_category_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_category_user.Location = New System.Drawing.Point(12, 193)
        Me.grd_category_user.MultiSelect = False
        Me.grd_category_user.Name = "grd_category_user"
        Me.grd_category_user.ReadOnly = True
        Me.grd_category_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_category_user.Size = New System.Drawing.Size(758, 249)
        Me.grd_category_user.TabIndex = 4
        '
        'txt_client_code
        '
        Me.txt_client_code.Location = New System.Drawing.Point(601, 41)
        Me.txt_client_code.MaxLength = 10
        Me.txt_client_code.Name = "txt_client_code"
        Me.txt_client_code.Size = New System.Drawing.Size(172, 20)
        Me.txt_client_code.TabIndex = 1029
        Me.txt_client_code.Visible = False
        '
        'txt_seq
        '
        Me.txt_seq.Location = New System.Drawing.Point(598, 67)
        Me.txt_seq.MaxLength = 10
        Me.txt_seq.Name = "txt_seq"
        Me.txt_seq.Size = New System.Drawing.Size(172, 20)
        Me.txt_seq.TabIndex = 1030
        Me.txt_seq.Visible = False
        '
        'Frm_DealSummary_Category
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 529)
        Me.Controls.Add(Me.txt_seq)
        Me.Controls.Add(Me.txt_client_code)
        Me.Controls.Add(Me.grd_category_user)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_Report_Category_Name)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_Report_Category_ID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_User_Category_Name)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_User_Category_ID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_DealSummary_Category"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grd_category_user, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txt_company_id As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents btn_UserCategory As System.Windows.Forms.Button
    Friend WithEvents txt_User_Category_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_User_Category_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Report_Category_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_Report_Category_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_ReportCategory As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grd_category_user As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chk_deal_cover_admin As System.Windows.Forms.CheckBox
    Friend WithEvents chk_deal_cover_payment As System.Windows.Forms.CheckBox
    Friend WithEvents chk_deal_cover_inquiry As System.Windows.Forms.CheckBox
    Friend WithEvents txt_client_code As System.Windows.Forms.TextBox
    Friend WithEvents btn_ClearPrintFlag As System.Windows.Forms.Button
    Friend WithEvents txt_seq As System.Windows.Forms.TextBox
End Class
