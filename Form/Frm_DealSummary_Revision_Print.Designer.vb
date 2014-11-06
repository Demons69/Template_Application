<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_Revision_Print
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
        Me.txt_from = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_company_id = New System.Windows.Forms.TextBox
        Me.grd_list = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.BT_Print = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.bt_close = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_to = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btn_Find = New System.Windows.Forms.Button
        Me.txt_company_name = New System.Windows.Forms.TextBox
        Me.btn_all = New System.Windows.Forms.Button
        Me.btn_clear = New System.Windows.Forms.Button
        Me.txt_userid = New System.Windows.Forms.TextBox
        Me.btn_print_offline = New System.Windows.Forms.Button
        CType(Me.grd_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_from
        '
        Me.txt_from.Enabled = False
        Me.txt_from.Location = New System.Drawing.Point(112, 95)
        Me.txt_from.MaxLength = 255
        Me.txt_from.Name = "txt_from"
        Me.txt_from.Size = New System.Drawing.Size(98, 20)
        Me.txt_from.TabIndex = 1032
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 1034
        Me.Label2.Text = "Date"
        '
        'txt_company_id
        '
        Me.txt_company_id.Enabled = False
        Me.txt_company_id.Location = New System.Drawing.Point(112, 56)
        Me.txt_company_id.MaxLength = 255
        Me.txt_company_id.Name = "txt_company_id"
        Me.txt_company_id.Size = New System.Drawing.Size(124, 20)
        Me.txt_company_id.TabIndex = 1031
        '
        'grd_list
        '
        Me.grd_list.AllowUserToAddRows = False
        Me.grd_list.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_list.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grd_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grd_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_list.Location = New System.Drawing.Point(15, 175)
        Me.grd_list.MultiSelect = False
        Me.grd_list.Name = "grd_list"
        Me.grd_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_list.Size = New System.Drawing.Size(657, 338)
        Me.grd_list.TabIndex = 1030
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1033
        Me.Label1.Text = "Company Id:"
        '
        'BT_Print
        '
        Me.BT_Print.Enabled = False
        Me.BT_Print.Location = New System.Drawing.Point(293, 16)
        Me.BT_Print.Name = "BT_Print"
        Me.BT_Print.Size = New System.Drawing.Size(99, 29)
        Me.BT_Print.TabIndex = 6
        Me.BT_Print.Text = "Print Online"
        Me.BT_Print.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(790, 35)
        Me.Panel2.TabIndex = 1028
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(588, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "DEAL SUMMARY DOCUMENT - REVISION (PRINT/PREVIEW)"
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(408, 16)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 7
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_print_offline)
        Me.GroupBox2.Controls.Add(Me.bt_close)
        Me.GroupBox2.Controls.Add(Me.BT_Print)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 519)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(747, 51)
        Me.GroupBox2.TabIndex = 1029
        Me.GroupBox2.TabStop = False
        '
        'txt_to
        '
        Me.txt_to.Enabled = False
        Me.txt_to.Location = New System.Drawing.Point(246, 95)
        Me.txt_to.MaxLength = 255
        Me.txt_to.Name = "txt_to"
        Me.txt_to.Size = New System.Drawing.Size(98, 20)
        Me.txt_to.TabIndex = 1035
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(216, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 1036
        Me.Label3.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(352, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 1037
        Me.Label4.Text = "(DD/MM/YYYY)"
        '
        'btn_Find
        '
        Me.btn_Find.Enabled = False
        Me.btn_Find.Location = New System.Drawing.Point(112, 136)
        Me.btn_Find.Name = "btn_Find"
        Me.btn_Find.Size = New System.Drawing.Size(120, 33)
        Me.btn_Find.TabIndex = 1038
        Me.btn_Find.Text = "&Search"
        Me.btn_Find.UseVisualStyleBackColor = True
        '
        'txt_company_name
        '
        Me.txt_company_name.Enabled = False
        Me.txt_company_name.Location = New System.Drawing.Point(246, 56)
        Me.txt_company_name.MaxLength = 255
        Me.txt_company_name.Name = "txt_company_name"
        Me.txt_company_name.Size = New System.Drawing.Size(492, 20)
        Me.txt_company_name.TabIndex = 1039
        '
        'btn_all
        '
        Me.btn_all.Location = New System.Drawing.Point(678, 175)
        Me.btn_all.Name = "btn_all"
        Me.btn_all.Size = New System.Drawing.Size(100, 33)
        Me.btn_all.TabIndex = 1040
        Me.btn_all.Text = "Select ALL"
        Me.btn_all.UseVisualStyleBackColor = True
        '
        'btn_clear
        '
        Me.btn_clear.Location = New System.Drawing.Point(678, 214)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(100, 33)
        Me.btn_clear.TabIndex = 1041
        Me.btn_clear.Text = "Clear ALL"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'txt_userid
        '
        Me.txt_userid.Location = New System.Drawing.Point(617, 115)
        Me.txt_userid.Name = "txt_userid"
        Me.txt_userid.Size = New System.Drawing.Size(37, 20)
        Me.txt_userid.TabIndex = 1042
        Me.txt_userid.Visible = False
        '
        'btn_print_offline
        '
        Me.btn_print_offline.Enabled = False
        Me.btn_print_offline.Location = New System.Drawing.Point(171, 16)
        Me.btn_print_offline.Name = "btn_print_offline"
        Me.btn_print_offline.Size = New System.Drawing.Size(99, 29)
        Me.btn_print_offline.TabIndex = 8
        Me.btn_print_offline.Text = "Print Offline"
        Me.btn_print_offline.UseVisualStyleBackColor = True
        '
        'Frm_DealSummary_Revision_Print
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 592)
        Me.Controls.Add(Me.txt_userid)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.btn_all)
        Me.Controls.Add(Me.txt_company_name)
        Me.Controls.Add(Me.btn_Find)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_to)
        Me.Controls.Add(Me.txt_from)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_company_id)
        Me.Controls.Add(Me.grd_list)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_DealSummary_Revision_Print"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.grd_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_from As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_company_id As System.Windows.Forms.TextBox
    Friend WithEvents grd_list As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BT_Print As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_to As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_Find As System.Windows.Forms.Button
    Friend WithEvents txt_company_name As System.Windows.Forms.TextBox
    Friend WithEvents btn_all As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents txt_userid As System.Windows.Forms.TextBox
    Friend WithEvents btn_print_offline As System.Windows.Forms.Button
End Class
