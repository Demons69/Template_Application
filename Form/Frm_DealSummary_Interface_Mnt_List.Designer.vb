<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_Interface_Mnt_List
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
        Me.Label17 = New System.Windows.Forms.Label
        Me.btn_Find = New System.Windows.Forms.Button
        Me.btn_Delete = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btn_Add = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_Select = New System.Windows.Forms.Button
        Me.btn_Edit = New System.Windows.Forms.Button
        Me.grd_list = New System.Windows.Forms.DataGridView
        Me.cbo_interface_type = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt_mapping_description = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_mapping_code = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grd_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(947, 35)
        Me.Panel2.TabIndex = 1031
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(272, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "INTERFACE MAPPING LIST"
        '
        'btn_Find
        '
        Me.btn_Find.Location = New System.Drawing.Point(208, 121)
        Me.btn_Find.Name = "btn_Find"
        Me.btn_Find.Size = New System.Drawing.Size(120, 33)
        Me.btn_Find.TabIndex = 1038
        Me.btn_Find.Text = "&Search..."
        Me.btn_Find.UseVisualStyleBackColor = True
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
        'btn_Add
        '
        Me.btn_Add.Location = New System.Drawing.Point(12, 13)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(120, 33)
        Me.btn_Add.TabIndex = 6
        Me.btn_Add.Text = "Add"
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btn_Select)
        Me.Panel1.Controls.Add(Me.btn_Delete)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btn_Edit)
        Me.Panel1.Controls.Add(Me.btn_Add)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 545)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(947, 66)
        Me.Panel1.TabIndex = 1033
        '
        'btn_Select
        '
        Me.btn_Select.Location = New System.Drawing.Point(677, 13)
        Me.btn_Select.Name = "btn_Select"
        Me.btn_Select.Size = New System.Drawing.Size(120, 33)
        Me.btn_Select.TabIndex = 10
        Me.btn_Select.Text = "Select"
        Me.btn_Select.UseVisualStyleBackColor = True
        Me.btn_Select.Visible = False
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
        Me.grd_list.Size = New System.Drawing.Size(925, 363)
        Me.grd_list.TabIndex = 1032
        Me.grd_list.TabStop = False
        '
        'cbo_interface_type
        '
        Me.cbo_interface_type.FormattingEnabled = True
        Me.cbo_interface_type.Location = New System.Drawing.Point(207, 90)
        Me.cbo_interface_type.Name = "cbo_interface_type"
        Me.cbo_interface_type.Size = New System.Drawing.Size(205, 21)
        Me.cbo_interface_type.TabIndex = 1102
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(99, 96)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 13)
        Me.Label21.TabIndex = 1101
        Me.Label21.Text = "Interface Type *"
        '
        'txt_mapping_description
        '
        Me.txt_mapping_description.Location = New System.Drawing.Point(208, 67)
        Me.txt_mapping_description.MaxLength = 10
        Me.txt_mapping_description.Name = "txt_mapping_description"
        Me.txt_mapping_description.Size = New System.Drawing.Size(249, 20)
        Me.txt_mapping_description.TabIndex = 1098
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 1100
        Me.Label2.Text = "Mapping Description *"
        '
        'txt_mapping_code
        '
        Me.txt_mapping_code.Location = New System.Drawing.Point(208, 41)
        Me.txt_mapping_code.MaxLength = 10
        Me.txt_mapping_code.Name = "txt_mapping_code"
        Me.txt_mapping_code.Size = New System.Drawing.Size(249, 20)
        Me.txt_mapping_code.TabIndex = 1097
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 1099
        Me.Label1.Text = "Mapping Code *"
        '
        'Frm_DealSummary_Interface_Mnt_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 611)
        Me.Controls.Add(Me.cbo_interface_type)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txt_mapping_description)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_mapping_code)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btn_Find)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grd_list)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_DealSummary_Interface_Mnt_List"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grd_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btn_Find As System.Windows.Forms.Button
    Friend WithEvents btn_Delete As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btn_Add As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents grd_list As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_interface_type As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_mapping_description As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_mapping_code As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Select As System.Windows.Forms.Button
End Class
