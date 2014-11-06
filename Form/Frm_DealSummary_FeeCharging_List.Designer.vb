<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_FeeCharging_List
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.grd_list = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_Delete = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btn_Edit = New System.Windows.Forms.Button
        Me.btn_Add = New System.Windows.Forms.Button
        Me.txt_product_id = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_account_no = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_Find = New System.Windows.Forms.Button
        Me.txt_product_description = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_print = New System.Windows.Forms.Button
        Me.Panel2.SuspendLayout()
        CType(Me.grd_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(949, 35)
        Me.Panel2.TabIndex = 198
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(164, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "FEE CHARGING"
        '
        'grd_list
        '
        Me.grd_list.AllowUserToAddRows = False
        Me.grd_list.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_list.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grd_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.grd_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_list.Location = New System.Drawing.Point(12, 160)
        Me.grd_list.MultiSelect = False
        Me.grd_list.Name = "grd_list"
        Me.grd_list.ReadOnly = True
        Me.grd_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_list.Size = New System.Drawing.Size(925, 338)
        Me.grd_list.TabIndex = 200
        Me.grd_list.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_print)
        Me.Panel1.Controls.Add(Me.btn_Delete)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btn_Edit)
        Me.Panel1.Controls.Add(Me.btn_Add)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 523)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(949, 66)
        Me.Panel1.TabIndex = 202
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
        'txt_product_id
        '
        Me.txt_product_id.Location = New System.Drawing.Point(256, 41)
        Me.txt_product_id.MaxLength = 255
        Me.txt_product_id.Name = "txt_product_id"
        Me.txt_product_id.Size = New System.Drawing.Size(320, 20)
        Me.txt_product_id.TabIndex = 1024
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(182, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 1025
        Me.Label1.Text = "Product ID"
        '
        'txt_account_no
        '
        Me.txt_account_no.Location = New System.Drawing.Point(256, 95)
        Me.txt_account_no.MaxLength = 255
        Me.txt_account_no.Name = "txt_account_no"
        Me.txt_account_no.Size = New System.Drawing.Size(320, 20)
        Me.txt_account_no.TabIndex = 1026
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(176, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 1027
        Me.Label2.Text = "Account No"
        '
        'btn_Find
        '
        Me.btn_Find.Location = New System.Drawing.Point(256, 121)
        Me.btn_Find.Name = "btn_Find"
        Me.btn_Find.Size = New System.Drawing.Size(120, 33)
        Me.btn_Find.TabIndex = 1028
        Me.btn_Find.Text = "&Search..."
        Me.btn_Find.UseVisualStyleBackColor = True
        '
        'txt_product_description
        '
        Me.txt_product_description.Location = New System.Drawing.Point(256, 69)
        Me.txt_product_description.MaxLength = 255
        Me.txt_product_description.Name = "txt_product_description"
        Me.txt_product_description.Size = New System.Drawing.Size(320, 20)
        Me.txt_product_description.TabIndex = 1029
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(140, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 1030
        Me.Label3.Text = "Product Description"
        '
        'btn_print
        '
        Me.btn_print.Location = New System.Drawing.Point(432, 13)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(120, 33)
        Me.btn_print.TabIndex = 10
        Me.btn_print.Text = "Print / Preview"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'Frm_DealSummary_FeeCharging_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 589)
        Me.Controls.Add(Me.txt_product_description)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_Find)
        Me.Controls.Add(Me.txt_account_no)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_product_id)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grd_list)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Frm_DealSummary_FeeCharging_List"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grd_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents grd_list As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents btn_Add As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents txt_product_id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_account_no As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_Find As System.Windows.Forms.Button
    Friend WithEvents txt_product_description As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_print As System.Windows.Forms.Button
End Class
