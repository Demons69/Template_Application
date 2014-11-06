<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiguration
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
        Me.btn_browse_report = New System.Windows.Forms.Button
        Me.txt_ReportPath = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_browse_connect = New System.Windows.Forms.Button
        Me.txt_connection = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_close)
        Me.GroupBox2.Controls.Add(Me.BT_Update)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 256)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(827, 57)
        Me.GroupBox2.TabIndex = 197
        Me.GroupBox2.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(416, 16)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 9
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'BT_Update
        '
        Me.BT_Update.Location = New System.Drawing.Point(301, 16)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(99, 29)
        Me.BT_Update.TabIndex = 8
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
        Me.Panel2.Size = New System.Drawing.Size(831, 35)
        Me.Panel2.TabIndex = 196
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(134, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Configuration"
        '
        'btn_browse_report
        '
        Me.btn_browse_report.Location = New System.Drawing.Point(673, 162)
        Me.btn_browse_report.Name = "btn_browse_report"
        Me.btn_browse_report.Size = New System.Drawing.Size(99, 29)
        Me.btn_browse_report.TabIndex = 1017
        Me.btn_browse_report.Text = "Browse..."
        Me.btn_browse_report.UseVisualStyleBackColor = True
        '
        'txt_ReportPath
        '
        Me.txt_ReportPath.Location = New System.Drawing.Point(155, 167)
        Me.txt_ReportPath.MaxLength = 0
        Me.txt_ReportPath.Name = "txt_ReportPath"
        Me.txt_ReportPath.Size = New System.Drawing.Size(512, 20)
        Me.txt_ReportPath.TabIndex = 1015
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 170)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 1016
        Me.Label1.Text = "Report Path"
        '
        'btn_browse_connect
        '
        Me.btn_browse_connect.Location = New System.Drawing.Point(673, 95)
        Me.btn_browse_connect.Name = "btn_browse_connect"
        Me.btn_browse_connect.Size = New System.Drawing.Size(99, 29)
        Me.btn_browse_connect.TabIndex = 1020
        Me.btn_browse_connect.Text = "Browse..."
        Me.btn_browse_connect.UseVisualStyleBackColor = True
        '
        'txt_connection
        '
        Me.txt_connection.Location = New System.Drawing.Point(155, 100)
        Me.txt_connection.MaxLength = 0
        Me.txt_connection.Name = "txt_connection"
        Me.txt_connection.Size = New System.Drawing.Size(512, 20)
        Me.txt_connection.TabIndex = 1018
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(66, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1019
        Me.Label2.Text = "Connectin String"
        '
        'FrmConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 314)
        Me.Controls.Add(Me.btn_browse_connect)
        Me.Controls.Add(Me.txt_connection)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_browse_report)
        Me.Controls.Add(Me.txt_ReportPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmConfiguration"
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
    Friend WithEvents btn_browse_report As System.Windows.Forms.Button
    Friend WithEvents txt_ReportPath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_browse_connect As System.Windows.Forms.Button
    Friend WithEvents txt_connection As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
