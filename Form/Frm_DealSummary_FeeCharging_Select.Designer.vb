<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_FeeCharging_Select
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
        Me.txt_account_no = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn_Find = New System.Windows.Forms.Button
        Me.txt_product_description = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.txt_product_id = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn_Select = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_Exit = New System.Windows.Forms.Button
        Me.grd_list = New System.Windows.Forms.DataGridView
        Me.txt_ID_Selected = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grd_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_account_no
        '
        Me.txt_account_no.Location = New System.Drawing.Point(184, 100)
        Me.txt_account_no.MaxLength = 255
        Me.txt_account_no.Name = "txt_account_no"
        Me.txt_account_no.Size = New System.Drawing.Size(320, 20)
        Me.txt_account_no.TabIndex = 1036
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(793, 35)
        Me.Panel2.TabIndex = 1031
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(263, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "FEE CHARGING (SELECT)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(104, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 1037
        Me.Label2.Text = "Account No"
        '
        'btn_Find
        '
        Me.btn_Find.Location = New System.Drawing.Point(184, 126)
        Me.btn_Find.Name = "btn_Find"
        Me.btn_Find.Size = New System.Drawing.Size(120, 33)
        Me.btn_Find.TabIndex = 1038
        Me.btn_Find.Text = "&Search..."
        Me.btn_Find.UseVisualStyleBackColor = True
        '
        'txt_product_description
        '
        Me.txt_product_description.Location = New System.Drawing.Point(184, 74)
        Me.txt_product_description.MaxLength = 255
        Me.txt_product_description.Name = "txt_product_description"
        Me.txt_product_description.Size = New System.Drawing.Size(320, 20)
        Me.txt_product_description.TabIndex = 1039
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(110, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 1035
        Me.Label1.Text = "Product ID"
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
        'txt_product_id
        '
        Me.txt_product_id.Location = New System.Drawing.Point(184, 46)
        Me.txt_product_id.MaxLength = 255
        Me.txt_product_id.Name = "txt_product_id"
        Me.txt_product_id.Size = New System.Drawing.Size(320, 20)
        Me.txt_product_id.TabIndex = 1034
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(68, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 1040
        Me.Label3.Text = "Product Description"
        '
        'btn_Select
        '
        Me.btn_Select.Location = New System.Drawing.Point(255, 13)
        Me.btn_Select.Name = "btn_Select"
        Me.btn_Select.Size = New System.Drawing.Size(120, 33)
        Me.btn_Select.TabIndex = 6
        Me.btn_Select.Text = "Select"
        Me.btn_Select.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btn_Exit)
        Me.Panel1.Controls.Add(Me.btn_Select)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 463)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(793, 66)
        Me.Panel1.TabIndex = 1033
        '
        'btn_Exit
        '
        Me.btn_Exit.Location = New System.Drawing.Point(395, 13)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(120, 33)
        Me.btn_Exit.TabIndex = 7
        Me.btn_Exit.Text = "Close"
        Me.btn_Exit.UseVisualStyleBackColor = True
        '
        'grd_list
        '
        Me.grd_list.AllowUserToAddRows = False
        Me.grd_list.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_list.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.grd_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_list.Location = New System.Drawing.Point(12, 165)
        Me.grd_list.MultiSelect = False
        Me.grd_list.Name = "grd_list"
        Me.grd_list.ReadOnly = True
        Me.grd_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_list.Size = New System.Drawing.Size(769, 258)
        Me.grd_list.TabIndex = 1032
        Me.grd_list.TabStop = False
        '
        'txt_ID_Selected
        '
        Me.txt_ID_Selected.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_ID_Selected.Enabled = False
        Me.txt_ID_Selected.Location = New System.Drawing.Point(87, 429)
        Me.txt_ID_Selected.Name = "txt_ID_Selected"
        Me.txt_ID_Selected.Size = New System.Drawing.Size(198, 20)
        Me.txt_ID_Selected.TabIndex = 1042
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 432)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 1041
        Me.Label4.Text = "Product ID"
        '
        'Frm_DealSummary_FeeCharging_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 529)
        Me.Controls.Add(Me.txt_ID_Selected)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_account_no)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_Find)
        Me.Controls.Add(Me.txt_product_description)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_product_id)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grd_list)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_DealSummary_FeeCharging_Select"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grd_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_account_no As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_Find As System.Windows.Forms.Button
    Friend WithEvents txt_product_description As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents txt_product_id As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Select As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_Exit As System.Windows.Forms.Button
    Friend WithEvents grd_list As System.Windows.Forms.DataGridView
    Friend WithEvents txt_ID_Selected As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
