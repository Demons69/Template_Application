<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BaseRate_Entry
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.BT_Update = New System.Windows.Forms.Button
        Me.txt_BASE_RATE = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.rad_StatusTemplate_N = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.rad_StatusTemplate_Y = New System.Windows.Forms.RadioButton
        Me.txt_BASE_RATE_DESCRIPTION = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txt_BASE_RATE_CODE = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(112, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 1019
        Me.Label3.Text = "Valid Flag"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_close)
        Me.GroupBox2.Controls.Add(Me.BT_Update)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 233)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(609, 51)
        Me.GroupBox2.TabIndex = 1015
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
        'txt_BASE_RATE
        '
        Me.txt_BASE_RATE.Location = New System.Drawing.Point(188, 133)
        Me.txt_BASE_RATE.MaxLength = 27
        Me.txt_BASE_RATE.Name = "txt_BASE_RATE"
        Me.txt_BASE_RATE.Size = New System.Drawing.Size(153, 20)
        Me.txt_BASE_RATE.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(109, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 1017
        Me.Label1.Text = "Base Rates"
        '
        'rad_StatusTemplate_N
        '
        Me.rad_StatusTemplate_N.AutoSize = True
        Me.rad_StatusTemplate_N.Location = New System.Drawing.Point(73, 3)
        Me.rad_StatusTemplate_N.Name = "rad_StatusTemplate_N"
        Me.rad_StatusTemplate_N.Size = New System.Drawing.Size(41, 17)
        Me.rad_StatusTemplate_N.TabIndex = 4
        Me.rad_StatusTemplate_N.Text = "NO"
        Me.rad_StatusTemplate_N.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(109, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1020
        Me.Label2.Text = "Base Rate"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(275, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "BASE RATE (ENTRY DATA)"
        '
        'rad_StatusTemplate_Y
        '
        Me.rad_StatusTemplate_Y.AutoSize = True
        Me.rad_StatusTemplate_Y.Checked = True
        Me.rad_StatusTemplate_Y.Location = New System.Drawing.Point(3, 4)
        Me.rad_StatusTemplate_Y.Name = "rad_StatusTemplate_Y"
        Me.rad_StatusTemplate_Y.Size = New System.Drawing.Size(46, 17)
        Me.rad_StatusTemplate_Y.TabIndex = 3
        Me.rad_StatusTemplate_Y.TabStop = True
        Me.rad_StatusTemplate_Y.Text = "YES"
        Me.rad_StatusTemplate_Y.UseVisualStyleBackColor = True
        '
        'txt_BASE_RATE_DESCRIPTION
        '
        Me.txt_BASE_RATE_DESCRIPTION.Location = New System.Drawing.Point(187, 107)
        Me.txt_BASE_RATE_DESCRIPTION.MaxLength = 120
        Me.txt_BASE_RATE_DESCRIPTION.Name = "txt_BASE_RATE_DESCRIPTION"
        Me.txt_BASE_RATE_DESCRIPTION.Size = New System.Drawing.Size(426, 20)
        Me.txt_BASE_RATE_DESCRIPTION.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(108, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 1018
        Me.Label4.Text = "Description"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rad_StatusTemplate_N)
        Me.Panel3.Controls.Add(Me.rad_StatusTemplate_Y)
        Me.Panel3.Location = New System.Drawing.Point(187, 159)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(154, 33)
        Me.Panel3.TabIndex = 1013
        Me.Panel3.TabStop = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(629, 35)
        Me.Panel2.TabIndex = 1014
        '
        'txt_BASE_RATE_CODE
        '
        Me.txt_BASE_RATE_CODE.Location = New System.Drawing.Point(187, 81)
        Me.txt_BASE_RATE_CODE.MaxLength = 30
        Me.txt_BASE_RATE_CODE.Name = "txt_BASE_RATE_CODE"
        Me.txt_BASE_RATE_CODE.Size = New System.Drawing.Size(249, 20)
        Me.txt_BASE_RATE_CODE.TabIndex = 0
        '
        'Frm_BaseRate_Entry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 294)
        Me.Controls.Add(Me.txt_BASE_RATE_CODE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txt_BASE_RATE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_BASE_RATE_DESCRIPTION)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_BaseRate_Entry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents txt_BASE_RATE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rad_StatusTemplate_N As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents rad_StatusTemplate_Y As System.Windows.Forms.RadioButton
    Friend WithEvents txt_BASE_RATE_DESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txt_BASE_RATE_CODE As System.Windows.Forms.TextBox
End Class
