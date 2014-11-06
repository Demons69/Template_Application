<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_user_entry
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_username = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_userid = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_pwd = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.BT_Update = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.lst_permision = New System.Windows.Forms.CheckedListBox
        Me.btn_clear = New System.Windows.Forms.Button
        Me.btn_all = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbo_BeneAdviceOn = New System.Windows.Forms.ComboBox
        Me.btn_clear_tracking = New System.Windows.Forms.Button
        Me.btn_all_tracking = New System.Windows.Forms.Button
        Me.lst_permision_tracking = New System.Windows.Forms.CheckedListBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(768, 35)
        Me.Panel2.TabIndex = 1076
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "USER"
        '
        'txt_username
        '
        Me.txt_username.Location = New System.Drawing.Point(239, 76)
        Me.txt_username.MaxLength = 50
        Me.txt_username.Name = "txt_username"
        Me.txt_username.Size = New System.Drawing.Size(249, 20)
        Me.txt_username.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(167, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 1110
        Me.Label2.Text = "User Name"
        '
        'txt_userid
        '
        Me.txt_userid.Location = New System.Drawing.Point(239, 50)
        Me.txt_userid.MaxLength = 50
        Me.txt_userid.Name = "txt_userid"
        Me.txt_userid.Size = New System.Drawing.Size(249, 20)
        Me.txt_userid.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(184, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1108
        Me.Label1.Text = "User ID"
        '
        'txt_pwd
        '
        Me.txt_pwd.Location = New System.Drawing.Point(239, 102)
        Me.txt_pwd.MaxLength = 50
        Me.txt_pwd.Name = "txt_pwd"
        Me.txt_pwd.Size = New System.Drawing.Size(249, 20)
        Me.txt_pwd.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(174, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 1112
        Me.Label3.Text = "Password"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_close)
        Me.GroupBox2.Controls.Add(Me.BT_Update)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 477)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(747, 51)
        Me.GroupBox2.TabIndex = 1113
        Me.GroupBox2.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(389, 16)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 19
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'BT_Update
        '
        Me.BT_Update.Location = New System.Drawing.Point(274, 16)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(99, 29)
        Me.BT_Update.TabIndex = 18
        Me.BT_Update.Text = "Save"
        Me.BT_Update.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(233, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 1131
        Me.Label4.Text = "Permision List :"
        '
        'lst_permision
        '
        Me.lst_permision.FormattingEnabled = True
        Me.lst_permision.Location = New System.Drawing.Point(234, 210)
        Me.lst_permision.Name = "lst_permision"
        Me.lst_permision.Size = New System.Drawing.Size(417, 109)
        Me.lst_permision.TabIndex = 3
        Me.lst_permision.ThreeDCheckBoxes = True
        '
        'btn_clear
        '
        Me.btn_clear.Location = New System.Drawing.Point(578, 179)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(70, 25)
        Me.btn_clear.TabIndex = 1133
        Me.btn_clear.Text = "Clear All"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'btn_all
        '
        Me.btn_all.Location = New System.Drawing.Point(502, 179)
        Me.btn_all.Name = "btn_all"
        Me.btn_all.Size = New System.Drawing.Size(70, 25)
        Me.btn_all.TabIndex = 1132
        Me.btn_all.Text = "Select All"
        Me.btn_all.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(166, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 1134
        Me.Label5.Text = "User Group"
        Me.Label5.Visible = False
        '
        'cbo_BeneAdviceOn
        '
        Me.cbo_BeneAdviceOn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbo_BeneAdviceOn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_BeneAdviceOn.FormattingEnabled = True
        Me.cbo_BeneAdviceOn.Items.AddRange(New Object() {"NONE", "Data Entry", "Debit", "Print", "(All)"})
        Me.cbo_BeneAdviceOn.Location = New System.Drawing.Point(239, 127)
        Me.cbo_BeneAdviceOn.Name = "cbo_BeneAdviceOn"
        Me.cbo_BeneAdviceOn.Size = New System.Drawing.Size(175, 21)
        Me.cbo_BeneAdviceOn.TabIndex = 1135
        Me.cbo_BeneAdviceOn.Visible = False
        '
        'btn_clear_tracking
        '
        Me.btn_clear_tracking.Location = New System.Drawing.Point(578, 325)
        Me.btn_clear_tracking.Name = "btn_clear_tracking"
        Me.btn_clear_tracking.Size = New System.Drawing.Size(70, 25)
        Me.btn_clear_tracking.TabIndex = 1139
        Me.btn_clear_tracking.Text = "Clear All"
        Me.btn_clear_tracking.UseVisualStyleBackColor = True
        '
        'btn_all_tracking
        '
        Me.btn_all_tracking.Location = New System.Drawing.Point(502, 325)
        Me.btn_all_tracking.Name = "btn_all_tracking"
        Me.btn_all_tracking.Size = New System.Drawing.Size(70, 25)
        Me.btn_all_tracking.TabIndex = 1138
        Me.btn_all_tracking.Text = "Select All"
        Me.btn_all_tracking.UseVisualStyleBackColor = True
        '
        'lst_permision_tracking
        '
        Me.lst_permision_tracking.FormattingEnabled = True
        Me.lst_permision_tracking.Location = New System.Drawing.Point(234, 356)
        Me.lst_permision_tracking.Name = "lst_permision_tracking"
        Me.lst_permision_tracking.Size = New System.Drawing.Size(417, 109)
        Me.lst_permision_tracking.TabIndex = 1136
        Me.lst_permision_tracking.ThreeDCheckBoxes = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(233, 337)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 13)
        Me.Label6.TabIndex = 1137
        Me.Label6.Text = "Menu Tracking List :"
        '
        'frm_user_entry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 540)
        Me.Controls.Add(Me.btn_clear_tracking)
        Me.Controls.Add(Me.btn_all_tracking)
        Me.Controls.Add(Me.lst_permision_tracking)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbo_BeneAdviceOn)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.btn_all)
        Me.Controls.Add(Me.lst_permision)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txt_pwd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_username)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_userid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frm_user_entry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_username As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_userid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_pwd As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lst_permision As System.Windows.Forms.CheckedListBox
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents btn_all As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_BeneAdviceOn As System.Windows.Forms.ComboBox
    Friend WithEvents btn_clear_tracking As System.Windows.Forms.Button
    Friend WithEvents btn_all_tracking As System.Windows.Forms.Button
    Friend WithEvents lst_permision_tracking As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
