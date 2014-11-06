<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Client_List
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
        Me.txt_Account = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_client_code = New System.Windows.Forms.TextBox
        Me.txt_tax_id = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_Company_ID_Selected = New System.Windows.Forms.TextBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.txt_companyname_th = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_companyname_en = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_company_id = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_Find = New System.Windows.Forms.Button
        Me.grd_data = New System.Windows.Forms.DataGridView
        Me.btn_Submit = New System.Windows.Forms.Button
        Me.btn_print_sum = New System.Windows.Forms.Button
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grd_data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_Account
        '
        Me.txt_Account.Location = New System.Drawing.Point(204, 130)
        Me.txt_Account.MaxLength = 0
        Me.txt_Account.Name = "txt_Account"
        Me.txt_Account.Size = New System.Drawing.Size(484, 20)
        Me.txt_Account.TabIndex = 1065
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(149, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 1066
        Me.Label6.Text = "Account"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(131, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 1064
        Me.Label4.Text = "Client Code:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(843, 35)
        Me.Panel2.TabIndex = 1008
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(170, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "CLIENT INQUIRY"
        '
        'txt_client_code
        '
        Me.txt_client_code.Location = New System.Drawing.Point(203, 37)
        Me.txt_client_code.MaxLength = 0
        Me.txt_client_code.Name = "txt_client_code"
        Me.txt_client_code.Size = New System.Drawing.Size(484, 20)
        Me.txt_client_code.TabIndex = 1
        '
        'txt_tax_id
        '
        Me.txt_tax_id.Location = New System.Drawing.Point(204, 106)
        Me.txt_tax_id.MaxLength = 0
        Me.txt_tax_id.Name = "txt_tax_id"
        Me.txt_tax_id.Size = New System.Drawing.Size(484, 20)
        Me.txt_tax_id.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 572)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1011
        Me.Label1.Text = "Company Id:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(170, 13)
        Me.Label7.TabIndex = 1062
        Me.Label7.Text = "Corporate Registration ID / Tax Id:"
        '
        'txt_Company_ID_Selected
        '
        Me.txt_Company_ID_Selected.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_Company_ID_Selected.Enabled = False
        Me.txt_Company_ID_Selected.Location = New System.Drawing.Point(92, 569)
        Me.txt_Company_ID_Selected.Name = "txt_Company_ID_Selected"
        Me.txt_Company_ID_Selected.Size = New System.Drawing.Size(198, 20)
        Me.txt_Company_ID_Selected.TabIndex = 1012
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(732, 560)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 33)
        Me.bt_close.TabIndex = 1007
        Me.bt_close.Text = "&Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'txt_companyname_th
        '
        Me.txt_companyname_th.Location = New System.Drawing.Point(203, 83)
        Me.txt_companyname_th.MaxLength = 0
        Me.txt_companyname_th.Name = "txt_companyname_th"
        Me.txt_companyname_th.Size = New System.Drawing.Size(484, 20)
        Me.txt_companyname_th.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_Account)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_client_code)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_tax_id)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_companyname_th)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_companyname_en)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_company_id)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btn_Find)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(819, 198)
        Me.GroupBox1.TabIndex = 1010
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Criteria :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(91, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 1060
        Me.Label3.Text = "Company Name(TH):"
        '
        'txt_companyname_en
        '
        Me.txt_companyname_en.Location = New System.Drawing.Point(203, 60)
        Me.txt_companyname_en.MaxLength = 0
        Me.txt_companyname_en.Name = "txt_companyname_en"
        Me.txt_companyname_en.Size = New System.Drawing.Size(484, 20)
        Me.txt_companyname_en.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(91, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 1059
        Me.Label2.Text = "Company Name(EN):"
        '
        'txt_company_id
        '
        Me.txt_company_id.Location = New System.Drawing.Point(203, 14)
        Me.txt_company_id.MaxLength = 0
        Me.txt_company_id.Name = "txt_company_id"
        Me.txt_company_id.Size = New System.Drawing.Size(484, 20)
        Me.txt_company_id.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(131, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 1056
        Me.Label5.Text = "Company Id:"
        '
        'btn_Find
        '
        Me.btn_Find.Location = New System.Drawing.Point(204, 159)
        Me.btn_Find.Name = "btn_Find"
        Me.btn_Find.Size = New System.Drawing.Size(120, 33)
        Me.btn_Find.TabIndex = 5
        Me.btn_Find.Text = "&Search"
        Me.btn_Find.UseVisualStyleBackColor = True
        '
        'grd_data
        '
        Me.grd_data.AllowUserToAddRows = False
        Me.grd_data.AllowUserToDeleteRows = False
        Me.grd_data.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_data.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.grd_data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grd_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_data.Location = New System.Drawing.Point(12, 252)
        Me.grd_data.MultiSelect = False
        Me.grd_data.Name = "grd_data"
        Me.grd_data.ReadOnly = True
        Me.grd_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_data.Size = New System.Drawing.Size(819, 302)
        Me.grd_data.TabIndex = 1009
        Me.grd_data.TabStop = False
        '
        'btn_Submit
        '
        Me.btn_Submit.Location = New System.Drawing.Point(597, 560)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Size = New System.Drawing.Size(129, 33)
        Me.btn_Submit.TabIndex = 1013
        Me.btn_Submit.Text = "Select"
        Me.btn_Submit.UseVisualStyleBackColor = True
        '
        'btn_print_sum
        '
        Me.btn_print_sum.Location = New System.Drawing.Point(449, 557)
        Me.btn_print_sum.Name = "btn_print_sum"
        Me.btn_print_sum.Size = New System.Drawing.Size(122, 32)
        Me.btn_print_sum.TabIndex = 1018
        Me.btn_print_sum.Text = "Print Summary"
        Me.btn_print_sum.UseVisualStyleBackColor = True
        Me.btn_print_sum.Visible = False
        '
        'Frm_Client_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 602)
        Me.Controls.Add(Me.btn_print_sum)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_Company_ID_Selected)
        Me.Controls.Add(Me.bt_close)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grd_data)
        Me.Controls.Add(Me.btn_Submit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_Client_List"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grd_data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_Account As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_client_code As System.Windows.Forms.TextBox
    Friend WithEvents txt_tax_id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_Company_ID_Selected As System.Windows.Forms.TextBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents txt_companyname_th As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_companyname_en As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_company_id As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_Find As System.Windows.Forms.Button
    Friend WithEvents grd_data As System.Windows.Forms.DataGridView
    Friend WithEvents btn_Submit As System.Windows.Forms.Button
    Friend WithEvents btn_print_sum As System.Windows.Forms.Button
End Class
