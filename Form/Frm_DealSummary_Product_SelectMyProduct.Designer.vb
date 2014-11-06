<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_Product_SelectMyProduct
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
        Me.grd_data = New System.Windows.Forms.DataGridView
        Me.btn_Submit = New System.Windows.Forms.Button
        Me.lbHead = New System.Windows.Forms.Label
        Me.bt_close = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txt_company_id = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txt_revision_desc = New System.Windows.Forms.TextBox
        Me.txt_revision_code = New System.Windows.Forms.TextBox
        Me.txt_temp = New System.Windows.Forms.TextBox
        Me.txt_MYPRODUCT_DESCRIPTION = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_UDEPRODUCT = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_MYPRODUCT_REMARK = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_MYPRODUCT = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.grd_data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.grd_data.Location = New System.Drawing.Point(17, 151)
        Me.grd_data.MultiSelect = False
        Me.grd_data.Name = "grd_data"
        Me.grd_data.ReadOnly = True
        Me.grd_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_data.Size = New System.Drawing.Size(777, 320)
        Me.grd_data.TabIndex = 1013
        Me.grd_data.TabStop = False
        '
        'btn_Submit
        '
        Me.btn_Submit.Location = New System.Drawing.Point(560, 477)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Size = New System.Drawing.Size(129, 33)
        Me.btn_Submit.TabIndex = 1012
        Me.btn_Submit.Text = "Edit"
        Me.btn_Submit.UseVisualStyleBackColor = True
        '
        'lbHead
        '
        Me.lbHead.AutoSize = True
        Me.lbHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbHead.ForeColor = System.Drawing.Color.Navy
        Me.lbHead.Location = New System.Drawing.Point(13, 5)
        Me.lbHead.Name = "lbHead"
        Me.lbHead.Size = New System.Drawing.Size(223, 24)
        Me.lbHead.TabIndex = 0
        Me.lbHead.Text = "SELECT MYPRODUCT"
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(695, 477)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 33)
        Me.bt_close.TabIndex = 1011
        Me.bt_close.Text = "&Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txt_company_id)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.txt_revision_desc)
        Me.Panel2.Controls.Add(Me.txt_revision_code)
        Me.Panel2.Controls.Add(Me.txt_temp)
        Me.Panel2.Controls.Add(Me.lbHead)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(805, 35)
        Me.Panel2.TabIndex = 1010
        '
        'txt_company_id
        '
        Me.txt_company_id.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_company_id.Enabled = False
        Me.txt_company_id.Location = New System.Drawing.Point(633, 5)
        Me.txt_company_id.MaxLength = 10
        Me.txt_company_id.Name = "txt_company_id"
        Me.txt_company_id.Size = New System.Drawing.Size(169, 20)
        Me.txt_company_id.TabIndex = 1064
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label24.Location = New System.Drawing.Point(554, 8)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 13)
        Me.Label24.TabIndex = 1065
        Me.Label24.Text = "Company Id:"
        '
        'txt_revision_desc
        '
        Me.txt_revision_desc.Location = New System.Drawing.Point(293, 5)
        Me.txt_revision_desc.MaxLength = 8
        Me.txt_revision_desc.Name = "txt_revision_desc"
        Me.txt_revision_desc.Size = New System.Drawing.Size(24, 20)
        Me.txt_revision_desc.TabIndex = 1063
        Me.txt_revision_desc.Visible = False
        '
        'txt_revision_code
        '
        Me.txt_revision_code.Location = New System.Drawing.Point(267, 5)
        Me.txt_revision_code.MaxLength = 8
        Me.txt_revision_code.Name = "txt_revision_code"
        Me.txt_revision_code.Size = New System.Drawing.Size(20, 20)
        Me.txt_revision_code.TabIndex = 1062
        Me.txt_revision_code.Visible = False
        '
        'txt_temp
        '
        Me.txt_temp.Location = New System.Drawing.Point(242, 5)
        Me.txt_temp.MaxLength = 0
        Me.txt_temp.Name = "txt_temp"
        Me.txt_temp.Size = New System.Drawing.Size(17, 20)
        Me.txt_temp.TabIndex = 1060
        Me.txt_temp.Visible = False
        '
        'txt_MYPRODUCT_DESCRIPTION
        '
        Me.txt_MYPRODUCT_DESCRIPTION.Location = New System.Drawing.Point(267, 64)
        Me.txt_MYPRODUCT_DESCRIPTION.MaxLength = 0
        Me.txt_MYPRODUCT_DESCRIPTION.Name = "txt_MYPRODUCT_DESCRIPTION"
        Me.txt_MYPRODUCT_DESCRIPTION.ReadOnly = True
        Me.txt_MYPRODUCT_DESCRIPTION.Size = New System.Drawing.Size(484, 20)
        Me.txt_MYPRODUCT_DESCRIPTION.TabIndex = 1066
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(142, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 1072
        Me.Label4.Text = "My Product Description"
        '
        'txt_UDEPRODUCT
        '
        Me.txt_UDEPRODUCT.Location = New System.Drawing.Point(267, 110)
        Me.txt_UDEPRODUCT.MaxLength = 0
        Me.txt_UDEPRODUCT.Name = "txt_UDEPRODUCT"
        Me.txt_UDEPRODUCT.ReadOnly = True
        Me.txt_UDEPRODUCT.Size = New System.Drawing.Size(484, 20)
        Me.txt_UDEPRODUCT.TabIndex = 1068
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(189, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 1071
        Me.Label3.Text = "UDE Product"
        '
        'txt_MYPRODUCT_REMARK
        '
        Me.txt_MYPRODUCT_REMARK.Location = New System.Drawing.Point(267, 87)
        Me.txt_MYPRODUCT_REMARK.MaxLength = 0
        Me.txt_MYPRODUCT_REMARK.Name = "txt_MYPRODUCT_REMARK"
        Me.txt_MYPRODUCT_REMARK.ReadOnly = True
        Me.txt_MYPRODUCT_REMARK.Size = New System.Drawing.Size(484, 20)
        Me.txt_MYPRODUCT_REMARK.TabIndex = 1067
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(158, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 1070
        Me.Label2.Text = "My Product Remark"
        '
        'txt_MYPRODUCT
        '
        Me.txt_MYPRODUCT.Location = New System.Drawing.Point(267, 41)
        Me.txt_MYPRODUCT.MaxLength = 0
        Me.txt_MYPRODUCT.Name = "txt_MYPRODUCT"
        Me.txt_MYPRODUCT.ReadOnly = True
        Me.txt_MYPRODUCT.Size = New System.Drawing.Size(484, 20)
        Me.txt_MYPRODUCT.TabIndex = 1065
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(170, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 1069
        Me.Label5.Text = "My Product Code"
        '
        'Frm_DealSummary_Product_SelectMyProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 522)
        Me.Controls.Add(Me.txt_MYPRODUCT_DESCRIPTION)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_UDEPRODUCT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_MYPRODUCT_REMARK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_MYPRODUCT)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.grd_data)
        Me.Controls.Add(Me.btn_Submit)
        Me.Controls.Add(Me.bt_close)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_DealSummary_Product_SelectMyProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.grd_data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grd_data As System.Windows.Forms.DataGridView
    Friend WithEvents btn_Submit As System.Windows.Forms.Button
    Friend WithEvents lbHead As System.Windows.Forms.Label
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txt_MYPRODUCT_DESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_UDEPRODUCT As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_MYPRODUCT_REMARK As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_MYPRODUCT As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_temp As System.Windows.Forms.TextBox
    Friend WithEvents txt_revision_desc As System.Windows.Forms.TextBox
    Friend WithEvents txt_revision_code As System.Windows.Forms.TextBox
    Friend WithEvents txt_company_id As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
End Class
