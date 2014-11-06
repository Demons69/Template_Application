<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Maintainance_Status_Entry
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
        Me.cbo_ProductCode = New System.Windows.Forms.ComboBox
        Me.txt_TemplateCode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.rad_StatusTemplate_3 = New System.Windows.Forms.RadioButton
        Me.rad_StatusTemplate_2 = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.rad_TemplateType_3 = New System.Windows.Forms.RadioButton
        Me.rad_TemplateType_2 = New System.Windows.Forms.RadioButton
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_TemplateFullName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_close)
        Me.GroupBox2.Controls.Add(Me.BT_Update)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 210)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(609, 51)
        Me.GroupBox2.TabIndex = 195
        Me.GroupBox2.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(333, 16)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 6
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'BT_Update
        '
        Me.BT_Update.Location = New System.Drawing.Point(218, 16)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(99, 29)
        Me.BT_Update.TabIndex = 5
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
        Me.Panel2.Size = New System.Drawing.Size(625, 35)
        Me.Panel2.TabIndex = 194
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(333, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "TEMPLATE CODE (ENTRY DATA)"
        '
        'cbo_ProductCode
        '
        Me.cbo_ProductCode.FormattingEnabled = True
        Me.cbo_ProductCode.Location = New System.Drawing.Point(187, 92)
        Me.cbo_ProductCode.Name = "cbo_ProductCode"
        Me.cbo_ProductCode.Size = New System.Drawing.Size(335, 21)
        Me.cbo_ProductCode.TabIndex = 1
        '
        'txt_TemplateCode
        '
        Me.txt_TemplateCode.Location = New System.Drawing.Point(187, 119)
        Me.txt_TemplateCode.MaxLength = 10
        Me.txt_TemplateCode.Name = "txt_TemplateCode"
        Me.txt_TemplateCode.Size = New System.Drawing.Size(137, 20)
        Me.txt_TemplateCode.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(102, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 1005
        Me.Label4.Text = "Template Code"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rad_StatusTemplate_3)
        Me.Panel3.Controls.Add(Me.rad_StatusTemplate_2)
        Me.Panel3.Location = New System.Drawing.Point(185, 171)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(154, 33)
        Me.Panel3.TabIndex = 4
        Me.Panel3.TabStop = True
        '
        'rad_StatusTemplate_3
        '
        Me.rad_StatusTemplate_3.AutoSize = True
        Me.rad_StatusTemplate_3.Location = New System.Drawing.Point(73, 3)
        Me.rad_StatusTemplate_3.Name = "rad_StatusTemplate_3"
        Me.rad_StatusTemplate_3.Size = New System.Drawing.Size(66, 17)
        Me.rad_StatusTemplate_3.TabIndex = 7
        Me.rad_StatusTemplate_3.Text = "Disabled"
        Me.rad_StatusTemplate_3.UseVisualStyleBackColor = True
        '
        'rad_StatusTemplate_2
        '
        Me.rad_StatusTemplate_2.AutoSize = True
        Me.rad_StatusTemplate_2.Checked = True
        Me.rad_StatusTemplate_2.Location = New System.Drawing.Point(3, 4)
        Me.rad_StatusTemplate_2.Name = "rad_StatusTemplate_2"
        Me.rad_StatusTemplate_2.Size = New System.Drawing.Size(64, 17)
        Me.rad_StatusTemplate_2.TabIndex = 6
        Me.rad_StatusTemplate_2.TabStop = True
        Me.rad_StatusTemplate_2.Text = "Enabled"
        Me.rad_StatusTemplate_2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(144, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 1006
        Me.Label3.Text = "Status"
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.rad_TemplateType_3)
        Me.Panel12.Controls.Add(Me.rad_TemplateType_2)
        Me.Panel12.Location = New System.Drawing.Point(187, 61)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(249, 21)
        Me.Panel12.TabIndex = 0
        '
        'rad_TemplateType_3
        '
        Me.rad_TemplateType_3.AutoSize = True
        Me.rad_TemplateType_3.Location = New System.Drawing.Point(115, 4)
        Me.rad_TemplateType_3.Name = "rad_TemplateType_3"
        Me.rad_TemplateType_3.Size = New System.Drawing.Size(106, 17)
        Me.rad_TemplateType_3.TabIndex = 1
        Me.rad_TemplateType_3.TabStop = True
        Me.rad_TemplateType_3.Text = "Template Charge"
        Me.rad_TemplateType_3.UseVisualStyleBackColor = True
        '
        'rad_TemplateType_2
        '
        Me.rad_TemplateType_2.AutoSize = True
        Me.rad_TemplateType_2.Checked = True
        Me.rad_TemplateType_2.Location = New System.Drawing.Point(7, 4)
        Me.rad_TemplateType_2.Name = "rad_TemplateType_2"
        Me.rad_TemplateType_2.Size = New System.Drawing.Size(109, 17)
        Me.rad_TemplateType_2.TabIndex = 0
        Me.rad_TemplateType_2.TabStop = True
        Me.rad_TemplateType_2.Text = "Template Product"
        Me.rad_TemplateType_2.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(106, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 1003
        Me.Label13.Text = "TemplateType"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(109, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 1004
        Me.Label1.Text = "Product Code"
        '
        'txt_TemplateFullName
        '
        Me.txt_TemplateFullName.Location = New System.Drawing.Point(188, 145)
        Me.txt_TemplateFullName.MaxLength = 27
        Me.txt_TemplateFullName.Name = "txt_TemplateFullName"
        Me.txt_TemplateFullName.Size = New System.Drawing.Size(338, 20)
        Me.txt_TemplateFullName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(80, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 1008
        Me.Label2.Text = "Template Full Name"
        '
        'Frm_Maintainance_Status_Entry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 264)
        Me.Controls.Add(Me.txt_TemplateFullName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbo_ProductCode)
        Me.Controls.Add(Me.txt_TemplateCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_Maintainance_Status_Entry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbo_ProductCode As System.Windows.Forms.ComboBox
    Friend WithEvents txt_TemplateCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rad_StatusTemplate_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rad_StatusTemplate_2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rad_TemplateType_3 As System.Windows.Forms.RadioButton
    Friend WithEvents rad_TemplateType_2 As System.Windows.Forms.RadioButton
    Friend WithEvents txt_TemplateFullName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
