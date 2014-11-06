<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_DealSummary_Revision_Select
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
        Me.btn_Submit = New System.Windows.Forms.Button
        Me.bt_close = New System.Windows.Forms.Button
        Me.grd_data = New System.Windows.Forms.DataGridView
        Me.Panel2.SuspendLayout()
        CType(Me.grd_data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(737, 35)
        Me.Panel2.TabIndex = 199
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(13, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(165, 24)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "REVISION TYPE"
        '
        'btn_Submit
        '
        Me.btn_Submit.Location = New System.Drawing.Point(491, 362)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Size = New System.Drawing.Size(129, 33)
        Me.btn_Submit.TabIndex = 1008
        Me.btn_Submit.Text = "Select"
        Me.btn_Submit.UseVisualStyleBackColor = True
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(626, 362)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 33)
        Me.bt_close.TabIndex = 1007
        Me.bt_close.Text = "&Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'grd_data
        '
        Me.grd_data.AllowUserToAddRows = False
        Me.grd_data.AllowUserToDeleteRows = False
        Me.grd_data.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_data.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grd_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.grd_data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grd_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_data.Location = New System.Drawing.Point(12, 41)
        Me.grd_data.MultiSelect = False
        Me.grd_data.Name = "grd_data"
        Me.grd_data.ReadOnly = True
        Me.grd_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_data.Size = New System.Drawing.Size(713, 306)
        Me.grd_data.TabIndex = 1009
        Me.grd_data.TabStop = False
        '
        'Frm_DealSummary_Revision_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 407)
        Me.Controls.Add(Me.grd_data)
        Me.Controls.Add(Me.btn_Submit)
        Me.Controls.Add(Me.bt_close)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_DealSummary_Revision_Select"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grd_data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btn_Submit As System.Windows.Forms.Button
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents grd_data As System.Windows.Forms.DataGridView
End Class
