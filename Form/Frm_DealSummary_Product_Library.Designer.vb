<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_Product_Library
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txt_MYPRODUCT_Selected = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.bt_close = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbo_bank_product = New System.Windows.Forms.ComboBox
        Me.txt_RULE_CODE = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_MYPRODUCT_DESCRIPTION = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_UDEPRODUCT = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_MYPRODUCT_REMARK = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_MYPRODUCT = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn_Find = New System.Windows.Forms.Button
        Me.grd_data = New System.Windows.Forms.DataGridView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.btn_Delete = New System.Windows.Forms.Button
        Me.btn_Edit = New System.Windows.Forms.Button
        Me.btn_Add = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.grd_data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_MYPRODUCT_Selected
        '
        Me.txt_MYPRODUCT_Selected.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_MYPRODUCT_Selected.Enabled = False
        Me.txt_MYPRODUCT_Selected.Location = New System.Drawing.Point(111, 567)
        Me.txt_MYPRODUCT_Selected.Name = "txt_MYPRODUCT_Selected"
        Me.txt_MYPRODUCT_Selected.Size = New System.Drawing.Size(179, 20)
        Me.txt_MYPRODUCT_Selected.TabIndex = 1012
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 570)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 1011
        Me.Label1.Text = "My Product Code"
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(732, 558)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 33)
        Me.bt_close.TabIndex = 1007
        Me.bt_close.Text = "&Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbo_bank_product)
        Me.GroupBox1.Controls.Add(Me.txt_RULE_CODE)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_MYPRODUCT_DESCRIPTION)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_UDEPRODUCT)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_MYPRODUCT_REMARK)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_MYPRODUCT)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btn_Find)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(819, 198)
        Me.GroupBox1.TabIndex = 1010
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Criteria :"
        '
        'cbo_bank_product
        '
        Me.cbo_bank_product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_bank_product.FormattingEnabled = True
        Me.cbo_bank_product.Location = New System.Drawing.Point(203, 106)
        Me.cbo_bank_product.Name = "cbo_bank_product"
        Me.cbo_bank_product.Size = New System.Drawing.Size(99, 21)
        Me.cbo_bank_product.TabIndex = 4
        '
        'txt_RULE_CODE
        '
        Me.txt_RULE_CODE.Location = New System.Drawing.Point(204, 130)
        Me.txt_RULE_CODE.MaxLength = 0
        Me.txt_RULE_CODE.Name = "txt_RULE_CODE"
        Me.txt_RULE_CODE.Size = New System.Drawing.Size(484, 20)
        Me.txt_RULE_CODE.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(138, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 1066
        Me.Label6.Text = "Rule Code"
        '
        'txt_MYPRODUCT_DESCRIPTION
        '
        Me.txt_MYPRODUCT_DESCRIPTION.Location = New System.Drawing.Point(203, 37)
        Me.txt_MYPRODUCT_DESCRIPTION.MaxLength = 0
        Me.txt_MYPRODUCT_DESCRIPTION.Name = "txt_MYPRODUCT_DESCRIPTION"
        Me.txt_MYPRODUCT_DESCRIPTION.Size = New System.Drawing.Size(484, 20)
        Me.txt_MYPRODUCT_DESCRIPTION.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(78, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 1064
        Me.Label4.Text = "My Product Description"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(123, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 1062
        Me.Label7.Text = "Bank Product"
        '
        'txt_UDEPRODUCT
        '
        Me.txt_UDEPRODUCT.Location = New System.Drawing.Point(203, 83)
        Me.txt_UDEPRODUCT.MaxLength = 0
        Me.txt_UDEPRODUCT.Name = "txt_UDEPRODUCT"
        Me.txt_UDEPRODUCT.Size = New System.Drawing.Size(484, 20)
        Me.txt_UDEPRODUCT.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(125, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 1060
        Me.Label3.Text = "UDE Product"
        '
        'txt_MYPRODUCT_REMARK
        '
        Me.txt_MYPRODUCT_REMARK.Location = New System.Drawing.Point(203, 60)
        Me.txt_MYPRODUCT_REMARK.MaxLength = 0
        Me.txt_MYPRODUCT_REMARK.Name = "txt_MYPRODUCT_REMARK"
        Me.txt_MYPRODUCT_REMARK.Size = New System.Drawing.Size(484, 20)
        Me.txt_MYPRODUCT_REMARK.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(94, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 1059
        Me.Label2.Text = "My Product Remark"
        '
        'txt_MYPRODUCT
        '
        Me.txt_MYPRODUCT.Location = New System.Drawing.Point(203, 14)
        Me.txt_MYPRODUCT.MaxLength = 0
        Me.txt_MYPRODUCT.Name = "txt_MYPRODUCT"
        Me.txt_MYPRODUCT.Size = New System.Drawing.Size(484, 20)
        Me.txt_MYPRODUCT.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(106, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 1056
        Me.Label5.Text = "My Product Code"
        '
        'btn_Find
        '
        Me.btn_Find.Location = New System.Drawing.Point(204, 159)
        Me.btn_Find.Name = "btn_Find"
        Me.btn_Find.Size = New System.Drawing.Size(120, 33)
        Me.btn_Find.TabIndex = 6
        Me.btn_Find.Text = "&Search"
        Me.btn_Find.UseVisualStyleBackColor = True
        '
        'grd_data
        '
        Me.grd_data.AllowUserToAddRows = False
        Me.grd_data.AllowUserToDeleteRows = False
        Me.grd_data.AllowUserToOrderColumns = True
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_data.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grd_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.grd_data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grd_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_data.Location = New System.Drawing.Point(12, 250)
        Me.grd_data.MultiSelect = False
        Me.grd_data.Name = "grd_data"
        Me.grd_data.ReadOnly = True
        Me.grd_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_data.Size = New System.Drawing.Size(819, 302)
        Me.grd_data.TabIndex = 1009
        Me.grd_data.TabStop = False
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
        Me.Label17.Size = New System.Drawing.Size(371, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "MY PRODUCT TABLE MAINTENANCE"
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(600, 559)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(120, 33)
        Me.btn_Delete.TabIndex = 1015
        Me.btn_Delete.Text = "Delete"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_Edit
        '
        Me.btn_Edit.Location = New System.Drawing.Point(465, 559)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(120, 33)
        Me.btn_Edit.TabIndex = 1014
        Me.btn_Edit.Text = "Edit"
        Me.btn_Edit.UseVisualStyleBackColor = True
        '
        'btn_Add
        '
        Me.btn_Add.Location = New System.Drawing.Point(327, 559)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(120, 33)
        Me.btn_Add.TabIndex = 1013
        Me.btn_Add.Text = "Add"
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'Frm_DealSummary_Product_Library
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 598)
        Me.Controls.Add(Me.btn_Delete)
        Me.Controls.Add(Me.btn_Edit)
        Me.Controls.Add(Me.btn_Add)
        Me.Controls.Add(Me.txt_MYPRODUCT_Selected)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bt_close)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grd_data)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Frm_DealSummary_Product_Library"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grd_data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_MYPRODUCT_Selected As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_RULE_CODE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_MYPRODUCT_DESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_UDEPRODUCT As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_MYPRODUCT_REMARK As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_MYPRODUCT As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_Find As System.Windows.Forms.Button
    Friend WithEvents grd_data As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbo_bank_product As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents btn_Add As System.Windows.Forms.Button
End Class
