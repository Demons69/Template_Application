<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_LookupData
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grd_data = New System.Windows.Forms.DataGridView
        Me.btn_select = New System.Windows.Forms.Button
        Me.bt_close = New System.Windows.Forms.Button
        CType(Me.grd_data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grd_data
        '
        Me.grd_data.AllowUserToAddRows = False
        Me.grd_data.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grd_data.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grd_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grd_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_data.Location = New System.Drawing.Point(12, 12)
        Me.grd_data.MultiSelect = False
        Me.grd_data.Name = "grd_data"
        Me.grd_data.ReadOnly = True
        Me.grd_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grd_data.Size = New System.Drawing.Size(758, 352)
        Me.grd_data.TabIndex = 6
        '
        'btn_select
        '
        Me.btn_select.Location = New System.Drawing.Point(551, 369)
        Me.btn_select.Name = "btn_select"
        Me.btn_select.Size = New System.Drawing.Size(99, 29)
        Me.btn_select.TabIndex = 9
        Me.btn_select.Text = "Select"
        Me.btn_select.UseVisualStyleBackColor = True
        '
        'bt_close
        '
        Me.bt_close.Location = New System.Drawing.Point(676, 370)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(99, 29)
        Me.bt_close.TabIndex = 10
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'Frm_LookupData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 412)
        Me.Controls.Add(Me.btn_select)
        Me.Controls.Add(Me.bt_close)
        Me.Controls.Add(Me.grd_data)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Frm_LookupData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.grd_data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grd_data As System.Windows.Forms.DataGridView
    Friend WithEvents btn_select As System.Windows.Forms.Button
    Friend WithEvents bt_close As System.Windows.Forms.Button
End Class
