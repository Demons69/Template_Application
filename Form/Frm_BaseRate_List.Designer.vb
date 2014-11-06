<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_BaseRate_List
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txt_Deal_ID = New System.Windows.Forms.TextBox
        Me.Label61 = New System.Windows.Forms.Label
        Me.btn_Print = New System.Windows.Forms.Button
        Me.btn_Edit = New System.Windows.Forms.Button
        Me.btn_Add = New System.Windows.Forms.Button
        Me.bt_close = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_Template = New System.Windows.Forms.TextBox
        Me.grd_Template = New System.Windows.Forms.DataGridView
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grd_Template, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(743, 35)
        Me.Panel2.TabIndex = 197
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(125, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "BASE RATE"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_Deal_ID)
        Me.Panel1.Controls.Add(Me.Label61)
        Me.Panel1.Controls.Add(Me.btn_Print)
        Me.Panel1.Controls.Add(Me.btn_Edit)
        Me.Panel1.Controls.Add(Me.btn_Add)
        Me.Panel1.Controls.Add(Me.bt_close)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_Template)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 471)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(743, 85)
        Me.Panel1.TabIndex = 201
        '
        'txt_Deal_ID
        '
        Me.txt_Deal_ID.Location = New System.Drawing.Point(379, 40)
        Me.txt_Deal_ID.Name = "txt_Deal_ID"
        Me.txt_Deal_ID.Size = New System.Drawing.Size(101, 20)
        Me.txt_Deal_ID.TabIndex = 1020
        Me.txt_Deal_ID.Text = "0000-000000-00"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(330, 44)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(43, 13)
        Me.Label61.TabIndex = 1019
        Me.Label61.Text = "Deal ID"
        '
        'btn_Print
        '
        Me.btn_Print.Enabled = False
        Me.btn_Print.Location = New System.Drawing.Point(486, 33)
        Me.btn_Print.Name = "btn_Print"
        Me.btn_Print.Size = New System.Drawing.Size(120, 33)
        Me.btn_Print.TabIndex = 183
        Me.btn_Print.Text = "Print"
        Me.btn_Print.UseVisualStyleBackColor = True
        '
        'btn_Edit
        '
        Me.btn_Edit.Enabled = False
        Me.btn_Edit.Location = New System.Drawing.Point(150, 33)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(120, 33)
        Me.btn_Edit.TabIndex = 7
        Me.btn_Edit.Text = "Edit"
        Me.btn_Edit.UseVisualStyleBackColor = True
        '
        'btn_Add
        '
        Me.btn_Add.Location = New System.Drawing.Point(12, 33)
        Me.btn_Add.Name = "btn_Add"
        Me.btn_Add.Size = New System.Drawing.Size(120, 33)
        Me.btn_Add.TabIndex = 6
        Me.btn_Add.Text = "Add"
        Me.btn_Add.UseVisualStyleBackColor = True
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(632, 33)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 33)
        Me.bt_close.TabIndex = 8
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 181
        Me.Label2.Text = "Selected"
        '
        'txt_Template
        '
        Me.txt_Template.Location = New System.Drawing.Point(65, 7)
        Me.txt_Template.Name = "txt_Template"
        Me.txt_Template.ReadOnly = True
        Me.txt_Template.Size = New System.Drawing.Size(109, 20)
        Me.txt_Template.TabIndex = 182
        Me.txt_Template.TabStop = False
        '
        'grd_Template
        '
        Me.grd_Template.AllowUserToAddRows = False
        Me.grd_Template.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_Template.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_Template.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.grd_Template.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_Template.Location = New System.Drawing.Point(10, 41)
        Me.grd_Template.MultiSelect = False
        Me.grd_Template.Name = "grd_Template"
        Me.grd_Template.ReadOnly = True
        Me.grd_Template.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grd_Template.Size = New System.Drawing.Size(721, 410)
        Me.grd_Template.TabIndex = 199
        Me.grd_Template.TabStop = False
        '
        'Frm_BaseRate_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 556)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grd_Template)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_BaseRate_List"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_BaseRate_List"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grd_Template, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_Print As System.Windows.Forms.Button
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents btn_Add As System.Windows.Forms.Button
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Template As System.Windows.Forms.TextBox
    Friend WithEvents grd_Template As System.Windows.Forms.DataGridView
    Friend WithEvents txt_Deal_ID As System.Windows.Forms.TextBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
End Class
