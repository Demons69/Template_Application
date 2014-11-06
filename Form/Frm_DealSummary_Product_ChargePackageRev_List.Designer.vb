<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_Product_ChargePackageRev_List
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
        Me.txt_revision_desc = New System.Windows.Forms.TextBox
        Me.txt_revision_code = New System.Windows.Forms.TextBox
        Me.txt_company_id = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.lbHead = New System.Windows.Forms.Label
        Me.grd_list = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_exit = New System.Windows.Forms.Button
        Me.btn_Delete = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btn_Edit = New System.Windows.Forms.Button
        Me.btn_Add = New System.Windows.Forms.Button
        Me.txt_my_product = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        CType(Me.grd_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txt_revision_desc)
        Me.Panel2.Controls.Add(Me.txt_revision_code)
        Me.Panel2.Controls.Add(Me.txt_company_id)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.lbHead)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(755, 35)
        Me.Panel2.TabIndex = 199
        '
        'txt_revision_desc
        '
        Me.txt_revision_desc.Location = New System.Drawing.Point(429, 8)
        Me.txt_revision_desc.MaxLength = 8
        Me.txt_revision_desc.Name = "txt_revision_desc"
        Me.txt_revision_desc.Size = New System.Drawing.Size(52, 20)
        Me.txt_revision_desc.TabIndex = 1061
        Me.txt_revision_desc.Visible = False
        '
        'txt_revision_code
        '
        Me.txt_revision_code.Location = New System.Drawing.Point(330, 8)
        Me.txt_revision_code.MaxLength = 8
        Me.txt_revision_code.Name = "txt_revision_code"
        Me.txt_revision_code.Size = New System.Drawing.Size(93, 20)
        Me.txt_revision_code.TabIndex = 1060
        Me.txt_revision_code.Visible = False
        '
        'txt_company_id
        '
        Me.txt_company_id.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_company_id.Enabled = False
        Me.txt_company_id.Location = New System.Drawing.Point(572, 5)
        Me.txt_company_id.MaxLength = 10
        Me.txt_company_id.Name = "txt_company_id"
        Me.txt_company_id.Size = New System.Drawing.Size(169, 20)
        Me.txt_company_id.TabIndex = 1057
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label24.Location = New System.Drawing.Point(493, 8)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 13)
        Me.Label24.TabIndex = 1058
        Me.Label24.Text = "Company Id:"
        '
        'lbHead
        '
        Me.lbHead.AutoSize = True
        Me.lbHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbHead.ForeColor = System.Drawing.Color.Navy
        Me.lbHead.Location = New System.Drawing.Point(13, 5)
        Me.lbHead.Name = "lbHead"
        Me.lbHead.Size = New System.Drawing.Size(307, 24)
        Me.lbHead.TabIndex = 0
        Me.lbHead.Text = "Revision - Add Charge Package"
        '
        'grd_list
        '
        Me.grd_list.AllowUserToAddRows = False
        Me.grd_list.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_list.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.grd_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_list.Location = New System.Drawing.Point(12, 79)
        Me.grd_list.MultiSelect = False
        Me.grd_list.Name = "grd_list"
        Me.grd_list.ReadOnly = True
        Me.grd_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_list.Size = New System.Drawing.Size(729, 239)
        Me.grd_list.TabIndex = 1033
        Me.grd_list.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_exit)
        Me.Panel1.Controls.Add(Me.btn_Delete)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btn_Edit)
        Me.Panel1.Controls.Add(Me.btn_Add)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 349)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(755, 66)
        Me.Panel1.TabIndex = 1034
        '
        'btn_exit
        '
        Me.btn_exit.Location = New System.Drawing.Point(621, 13)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(120, 33)
        Me.btn_exit.TabIndex = 10
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.UseVisualStyleBackColor = True
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(285, 13)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(120, 33)
        Me.btn_Delete.TabIndex = 9
        Me.btn_Delete.Text = "Delete"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(817, 13)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(120, 33)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btn_Edit
        '
        Me.btn_Edit.Location = New System.Drawing.Point(150, 13)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(120, 33)
        Me.btn_Edit.TabIndex = 7
        Me.btn_Edit.Text = "Edit"
        Me.btn_Edit.UseVisualStyleBackColor = True
        '
        'btn_Add
        '
        Me.btn_Add.Location = New System.Drawing.Point(12, 13)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(120, 33)
        Me.btn_Add.TabIndex = 6
        Me.btn_Add.Text = "Add"
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'txt_my_product
        '
        Me.txt_my_product.Enabled = False
        Me.txt_my_product.Location = New System.Drawing.Point(124, 44)
        Me.txt_my_product.MaxLength = 0
        Me.txt_my_product.Name = "txt_my_product"
        Me.txt_my_product.Size = New System.Drawing.Size(146, 20)
        Me.txt_my_product.TabIndex = 1040
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 1041
        Me.Label1.Text = "My Product Code"
        '
        'Frm_DealSummary_Product_ChargePackageRev_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 415)
        Me.Controls.Add(Me.txt_my_product)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grd_list)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Frm_DealSummary_Product_ChargePackageRev_List"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grd_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txt_revision_desc As System.Windows.Forms.TextBox
    Friend WithEvents txt_revision_code As System.Windows.Forms.TextBox
    Friend WithEvents txt_company_id As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lbHead As System.Windows.Forms.Label
    Friend WithEvents grd_list As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents btn_Add As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents txt_my_product As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
