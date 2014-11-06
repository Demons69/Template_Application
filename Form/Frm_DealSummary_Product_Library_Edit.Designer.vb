<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_Product_Library_Edit
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.BT_Update = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_MYPRODUCT = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_MYPRODUCT_DESCRIPTION = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_MYPRODUCT_REMARK = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbo_UDEPRODUCT = New System.Windows.Forms.ComboBox
        Me.cbo_PRODUCT_CODE = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_PRODUCT_DESCRIPTION = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbo_ARRANGEMENT_CODE = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_PER_TXN_MAX_AMNT = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_RULE_CODE = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txt_RULE_PRIORITY = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txt_DAYS_PERIOD = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_close)
        Me.GroupBox2.Controls.Add(Me.BT_Update)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 336)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(756, 51)
        Me.GroupBox2.TabIndex = 197
        Me.GroupBox2.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(391, 16)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 11
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'BT_Update
        '
        Me.BT_Update.Location = New System.Drawing.Point(276, 16)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(99, 29)
        Me.BT_Update.TabIndex = 10
        Me.BT_Update.Text = "Save"
        Me.BT_Update.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(779, 35)
        Me.Panel2.TabIndex = 196
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(521, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "MY PRODUCT TABLE MAINTENANCE (ENTRY DATA)"
        '
        'txt_MYPRODUCT
        '
        Me.txt_MYPRODUCT.Location = New System.Drawing.Point(266, 41)
        Me.txt_MYPRODUCT.MaxLength = 0
        Me.txt_MYPRODUCT.Name = "txt_MYPRODUCT"
        Me.txt_MYPRODUCT.Size = New System.Drawing.Size(146, 20)
        Me.txt_MYPRODUCT.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(146, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 1041
        Me.Label1.Text = "My Product Code *"
        '
        'txt_MYPRODUCT_DESCRIPTION
        '
        Me.txt_MYPRODUCT_DESCRIPTION.Location = New System.Drawing.Point(266, 66)
        Me.txt_MYPRODUCT_DESCRIPTION.MaxLength = 0
        Me.txt_MYPRODUCT_DESCRIPTION.Name = "txt_MYPRODUCT_DESCRIPTION"
        Me.txt_MYPRODUCT_DESCRIPTION.Size = New System.Drawing.Size(342, 20)
        Me.txt_MYPRODUCT_DESCRIPTION.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(160, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 1043
        Me.Label2.Text = "My Product Name *"
        '
        'txt_MYPRODUCT_REMARK
        '
        Me.txt_MYPRODUCT_REMARK.Location = New System.Drawing.Point(266, 91)
        Me.txt_MYPRODUCT_REMARK.MaxLength = 0
        Me.txt_MYPRODUCT_REMARK.Name = "txt_MYPRODUCT_REMARK"
        Me.txt_MYPRODUCT_REMARK.Size = New System.Drawing.Size(484, 20)
        Me.txt_MYPRODUCT_REMARK.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(154, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 1061
        Me.Label3.Text = "My Product Remark*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(173, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 1063
        Me.Label4.Text = "UDE Product*"
        '
        'cbo_UDEPRODUCT
        '
        Me.cbo_UDEPRODUCT.FormattingEnabled = True
        Me.cbo_UDEPRODUCT.Location = New System.Drawing.Point(266, 116)
        Me.cbo_UDEPRODUCT.Name = "cbo_UDEPRODUCT"
        Me.cbo_UDEPRODUCT.Size = New System.Drawing.Size(122, 21)
        Me.cbo_UDEPRODUCT.TabIndex = 3
        '
        'cbo_PRODUCT_CODE
        '
        Me.cbo_PRODUCT_CODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_PRODUCT_CODE.FormattingEnabled = True
        Me.cbo_PRODUCT_CODE.Location = New System.Drawing.Point(266, 142)
        Me.cbo_PRODUCT_CODE.Name = "cbo_PRODUCT_CODE"
        Me.cbo_PRODUCT_CODE.Size = New System.Drawing.Size(99, 21)
        Me.cbo_PRODUCT_CODE.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(170, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 1066
        Me.Label7.Text = "Bank Product*"
        '
        'txt_PRODUCT_DESCRIPTION
        '
        Me.txt_PRODUCT_DESCRIPTION.Location = New System.Drawing.Point(266, 168)
        Me.txt_PRODUCT_DESCRIPTION.MaxLength = 0
        Me.txt_PRODUCT_DESCRIPTION.Name = "txt_PRODUCT_DESCRIPTION"
        Me.txt_PRODUCT_DESCRIPTION.Size = New System.Drawing.Size(484, 20)
        Me.txt_PRODUCT_DESCRIPTION.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(127, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 13)
        Me.Label5.TabIndex = 1068
        Me.Label5.Text = "Bank Product Description*"
        '
        'cbo_ARRANGEMENT_CODE
        '
        Me.cbo_ARRANGEMENT_CODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_ARRANGEMENT_CODE.FormattingEnabled = True
        Me.cbo_ARRANGEMENT_CODE.Location = New System.Drawing.Point(266, 193)
        Me.cbo_ARRANGEMENT_CODE.Name = "cbo_ARRANGEMENT_CODE"
        Me.cbo_ARRANGEMENT_CODE.Size = New System.Drawing.Size(77, 21)
        Me.cbo_ARRANGEMENT_CODE.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(185, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 1070
        Me.Label6.Text = "Arrangement *"
        '
        'txt_PER_TXN_MAX_AMNT
        '
        Me.txt_PER_TXN_MAX_AMNT.Location = New System.Drawing.Point(266, 246)
        Me.txt_PER_TXN_MAX_AMNT.MaxLength = 0
        Me.txt_PER_TXN_MAX_AMNT.Name = "txt_PER_TXN_MAX_AMNT"
        Me.txt_PER_TXN_MAX_AMNT.Size = New System.Drawing.Size(146, 20)
        Me.txt_PER_TXN_MAX_AMNT.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(164, 249)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 13)
        Me.Label8.TabIndex = 1072
        Me.Label8.Text = "Per Txn Max Amt *"
        '
        'txt_RULE_CODE
        '
        Me.txt_RULE_CODE.Location = New System.Drawing.Point(266, 296)
        Me.txt_RULE_CODE.MaxLength = 0
        Me.txt_RULE_CODE.Name = "txt_RULE_CODE"
        Me.txt_RULE_CODE.Size = New System.Drawing.Size(146, 20)
        Me.txt_RULE_CODE.TabIndex = 10
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(195, 299)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(64, 13)
        Me.Label26.TabIndex = 1114
        Me.Label26.Text = "Rule Code *"
        '
        'txt_RULE_PRIORITY
        '
        Me.txt_RULE_PRIORITY.Location = New System.Drawing.Point(266, 271)
        Me.txt_RULE_PRIORITY.MaxLength = 0
        Me.txt_RULE_PRIORITY.Name = "txt_RULE_PRIORITY"
        Me.txt_RULE_PRIORITY.Size = New System.Drawing.Size(146, 20)
        Me.txt_RULE_PRIORITY.TabIndex = 9
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(189, 274)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 13)
        Me.Label25.TabIndex = 1113
        Me.Label25.Text = "Rule Priority *"
        '
        'txt_DAYS_PERIOD
        '
        Me.txt_DAYS_PERIOD.Location = New System.Drawing.Point(266, 220)
        Me.txt_DAYS_PERIOD.MaxLength = 0
        Me.txt_DAYS_PERIOD.Name = "txt_DAYS_PERIOD"
        Me.txt_DAYS_PERIOD.Size = New System.Drawing.Size(146, 20)
        Me.txt_DAYS_PERIOD.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(188, 223)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 1116
        Me.Label9.Text = "Days Period *"
        '
        'Frm_DealSummary_Product_Library_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 422)
        Me.Controls.Add(Me.txt_DAYS_PERIOD)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_RULE_CODE)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txt_RULE_PRIORITY)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txt_PER_TXN_MAX_AMNT)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbo_ARRANGEMENT_CODE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_PRODUCT_DESCRIPTION)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbo_PRODUCT_CODE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbo_UDEPRODUCT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_MYPRODUCT_REMARK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_MYPRODUCT_DESCRIPTION)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_MYPRODUCT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Frm_DealSummary_Product_Library_Edit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_MYPRODUCT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_MYPRODUCT_DESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_MYPRODUCT_REMARK As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbo_UDEPRODUCT As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_PRODUCT_CODE As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_PRODUCT_DESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_ARRANGEMENT_CODE As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_PER_TXN_MAX_AMNT As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_RULE_CODE As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txt_RULE_PRIORITY As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt_DAYS_PERIOD As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
