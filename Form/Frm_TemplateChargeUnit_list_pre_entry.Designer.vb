<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_TemplateChargeUnit_list_pre_entry
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txt_GUID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.grd_Event = New System.Windows.Forms.DataGridView
        Me.Label28 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.bt_close = New System.Windows.Forms.Button
        Me.btnNewEvent = New System.Windows.Forms.Button
        Me.btnEditEvent = New System.Windows.Forms.Button
        Me.btnDeleteEvent = New System.Windows.Forms.Button
        Me.btnDeleteUnit = New System.Windows.Forms.Button
        Me.btnEditUnit = New System.Windows.Forms.Button
        Me.btnNewUnit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.grd_unit = New System.Windows.Forms.DataGridView
        Me.txtTemplateCode = New System.Windows.Forms.TextBox
        Me.cboProduct = New System.Windows.Forms.ComboBox
        Me.btnGo = New System.Windows.Forms.Button
        Me.Panel2.SuspendLayout()
        CType(Me.grd_Event, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grd_unit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.txt_GUID)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(835, 35)
        Me.Panel2.TabIndex = 166
        '
        'txt_GUID
        '
        Me.txt_GUID.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_GUID.ForeColor = System.Drawing.Color.Black
        Me.txt_GUID.Location = New System.Drawing.Point(538, 9)
        Me.txt_GUID.Name = "txt_GUID"
        Me.txt_GUID.Size = New System.Drawing.Size(287, 20)
        Me.txt_GUID.TabIndex = 217
        Me.txt_GUID.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(498, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 216
        Me.Label2.Text = "GUID"
        Me.Label2.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(239, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Template Charge (Entry)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 170
        Me.Label4.Text = "Charge Events :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 261)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 169
        Me.Label3.Text = "Charge Units :"
        '
        'grd_Event
        '
        Me.grd_Event.AllowUserToAddRows = False
        Me.grd_Event.AllowUserToDeleteRows = False
        Me.grd_Event.AllowUserToResizeColumns = False
        Me.grd_Event.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_Event.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_Event.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.grd_Event.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_Event.Location = New System.Drawing.Point(11, 99)
        Me.grd_Event.MultiSelect = False
        Me.grd_Event.Name = "grd_Event"
        Me.grd_Event.ReadOnly = True
        Me.grd_Event.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_Event.Size = New System.Drawing.Size(812, 97)
        Me.grd_Event.TabIndex = 175
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(14, 52)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(79, 13)
        Me.Label28.TabIndex = 174
        Me.Label28.Text = "Template Code"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bt_close)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 485)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(808, 65)
        Me.GroupBox2.TabIndex = 183
        Me.GroupBox2.TabStop = False
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(672, 10)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 102
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'btnNewEvent
        '
        Me.btnNewEvent.Location = New System.Drawing.Point(11, 202)
        Me.btnNewEvent.Name = "btnNewEvent"
        Me.btnNewEvent.Size = New System.Drawing.Size(81, 29)
        Me.btnNewEvent.TabIndex = 176
        Me.btnNewEvent.Text = "New Event"
        Me.btnNewEvent.UseVisualStyleBackColor = True
        '
        'btnEditEvent
        '
        Me.btnEditEvent.Location = New System.Drawing.Point(111, 202)
        Me.btnEditEvent.Name = "btnEditEvent"
        Me.btnEditEvent.Size = New System.Drawing.Size(81, 29)
        Me.btnEditEvent.TabIndex = 177
        Me.btnEditEvent.Text = "Edit Event"
        Me.btnEditEvent.UseVisualStyleBackColor = True
        '
        'btnDeleteEvent
        '
        Me.btnDeleteEvent.Location = New System.Drawing.Point(208, 202)
        Me.btnDeleteEvent.Name = "btnDeleteEvent"
        Me.btnDeleteEvent.Size = New System.Drawing.Size(81, 29)
        Me.btnDeleteEvent.TabIndex = 178
        Me.btnDeleteEvent.Text = "Delete Event"
        Me.btnDeleteEvent.UseVisualStyleBackColor = True
        '
        'btnDeleteUnit
        '
        Me.btnDeleteUnit.Location = New System.Drawing.Point(208, 450)
        Me.btnDeleteUnit.Name = "btnDeleteUnit"
        Me.btnDeleteUnit.Size = New System.Drawing.Size(81, 29)
        Me.btnDeleteUnit.TabIndex = 182
        Me.btnDeleteUnit.Text = "Delete Unit"
        Me.btnDeleteUnit.UseVisualStyleBackColor = True
        '
        'btnEditUnit
        '
        Me.btnEditUnit.Location = New System.Drawing.Point(111, 450)
        Me.btnEditUnit.Name = "btnEditUnit"
        Me.btnEditUnit.Size = New System.Drawing.Size(81, 29)
        Me.btnEditUnit.TabIndex = 181
        Me.btnEditUnit.Text = "Edit Unit"
        Me.btnEditUnit.UseVisualStyleBackColor = True
        '
        'btnNewUnit
        '
        Me.btnNewUnit.Location = New System.Drawing.Point(11, 450)
        Me.btnNewUnit.Name = "btnNewUnit"
        Me.btnNewUnit.Size = New System.Drawing.Size(81, 29)
        Me.btnNewUnit.TabIndex = 180
        Me.btnNewUnit.Text = "New Unit"
        Me.btnNewUnit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(267, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 214
        Me.Label1.Text = "Product"
        '
        'grd_unit
        '
        Me.grd_unit.AllowUserToAddRows = False
        Me.grd_unit.AllowUserToDeleteRows = False
        Me.grd_unit.AllowUserToResizeColumns = False
        Me.grd_unit.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_unit.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grd_unit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.grd_unit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_unit.Location = New System.Drawing.Point(9, 277)
        Me.grd_unit.MultiSelect = False
        Me.grd_unit.Name = "grd_unit"
        Me.grd_unit.ReadOnly = True
        Me.grd_unit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_unit.Size = New System.Drawing.Size(812, 167)
        Me.grd_unit.TabIndex = 179
        '
        'txtTemplateCode
        '
        Me.txtTemplateCode.Location = New System.Drawing.Point(99, 47)
        Me.txtTemplateCode.Name = "txtTemplateCode"
        Me.txtTemplateCode.Size = New System.Drawing.Size(151, 20)
        Me.txtTemplateCode.TabIndex = 215
        '
        'cboProduct
        '
        Me.cboProduct.FormattingEnabled = True
        Me.cboProduct.Location = New System.Drawing.Point(317, 44)
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.Size = New System.Drawing.Size(121, 21)
        Me.cboProduct.TabIndex = 216
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(457, 44)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 217
        Me.btnGo.Text = "Search"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'Frm_TemplateChargeUnit_list_pre_entry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 559)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.cboProduct)
        Me.Controls.Add(Me.txtTemplateCode)
        Me.Controls.Add(Me.grd_unit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDeleteUnit)
        Me.Controls.Add(Me.btnEditUnit)
        Me.Controls.Add(Me.btnNewUnit)
        Me.Controls.Add(Me.btnDeleteEvent)
        Me.Controls.Add(Me.btnEditEvent)
        Me.Controls.Add(Me.btnNewEvent)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grd_Event)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_TemplateChargeUnit_list_pre_entry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grd_Event, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grd_unit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grd_Event As System.Windows.Forms.DataGridView
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents btnNewEvent As System.Windows.Forms.Button
    Friend WithEvents btnEditEvent As System.Windows.Forms.Button
    Friend WithEvents btnDeleteEvent As System.Windows.Forms.Button
    Friend WithEvents btnDeleteUnit As System.Windows.Forms.Button
    Friend WithEvents btnEditUnit As System.Windows.Forms.Button
    Friend WithEvents btnNewUnit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_GUID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grd_unit As System.Windows.Forms.DataGridView
    Friend WithEvents txtTemplateCode As System.Windows.Forms.TextBox
    Friend WithEvents cboProduct As System.Windows.Forms.ComboBox
    Friend WithEvents btnGo As System.Windows.Forms.Button
End Class
