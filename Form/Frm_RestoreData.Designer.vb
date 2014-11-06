<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RestoreData
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btn_close = New System.Windows.Forms.Button
        Me.BT_Update = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grd_Template = New System.Windows.Forms.DataGridView
        Me.Label28 = New System.Windows.Forms.Label
        Me.txt_version = New System.Windows.Forms.TextBox
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grd_Template, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 1017
        Me.Label1.Text = "Information :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(169, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "RESTORE DATA"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(728, 35)
        Me.Panel2.TabIndex = 1011
        '
        'btn_close
        '
        Me.btn_close.Location = New System.Drawing.Point(363, 16)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(99, 29)
        Me.btn_close.TabIndex = 9
        Me.btn_close.Text = "Close"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'BT_Update
        '
        Me.BT_Update.Location = New System.Drawing.Point(248, 16)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(99, 29)
        Me.BT_Update.TabIndex = 8
        Me.BT_Update.Text = "Import"
        Me.BT_Update.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_close)
        Me.GroupBox2.Controls.Add(Me.BT_Update)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 355)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(704, 54)
        Me.GroupBox2.TabIndex = 1012
        Me.GroupBox2.TabStop = False
        '
        'grd_Template
        '
        Me.grd_Template.AllowUserToAddRows = False
        Me.grd_Template.AllowUserToDeleteRows = False
        Me.grd_Template.AllowUserToResizeColumns = False
        Me.grd_Template.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_Template.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_Template.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.grd_Template.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_Template.Location = New System.Drawing.Point(12, 54)
        Me.grd_Template.MultiSelect = False
        Me.grd_Template.Name = "grd_Template"
        Me.grd_Template.ReadOnly = True
        Me.grd_Template.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_Template.Size = New System.Drawing.Size(704, 271)
        Me.grd_Template.TabIndex = 1018
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(13, 334)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(42, 13)
        Me.Label28.TabIndex = 1020
        Me.Label28.Text = "Version"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_version
        '
        Me.txt_version.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_version.Enabled = False
        Me.txt_version.ForeColor = System.Drawing.Color.Black
        Me.txt_version.Location = New System.Drawing.Point(82, 331)
        Me.txt_version.Name = "txt_version"
        Me.txt_version.Size = New System.Drawing.Size(145, 20)
        Me.txt_version.TabIndex = 1019
        '
        'Frm_RestoreData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 424)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txt_version)
        Me.Controls.Add(Me.grd_Template)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_RestoreData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grd_Template, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grd_Template As System.Windows.Forms.DataGridView
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txt_version As System.Windows.Forms.TextBox
End Class
