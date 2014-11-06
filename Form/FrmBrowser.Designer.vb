<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBrowser
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
        Me.btnUploadAddress = New System.Windows.Forms.Button
        Me.txt_code = New System.Windows.Forms.TextBox
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'btnUploadAddress
        '
        Me.btnUploadAddress.Location = New System.Drawing.Point(12, 3)
        Me.btnUploadAddress.Name = "btnUploadAddress"
        Me.btnUploadAddress.Size = New System.Drawing.Size(93, 29)
        Me.btnUploadAddress.TabIndex = 1166
        Me.btnUploadAddress.Text = "Upload.."
        Me.btnUploadAddress.UseVisualStyleBackColor = True
        '
        'txt_code
        '
        Me.txt_code.Location = New System.Drawing.Point(12, 341)
        Me.txt_code.Multiline = True
        Me.txt_code.Name = "txt_code"
        Me.txt_code.Size = New System.Drawing.Size(568, 101)
        Me.txt_code.TabIndex = 1168
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(13, 39)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(566, 293)
        Me.WebBrowser1.TabIndex = 1169
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 454)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.txt_code)
        Me.Controls.Add(Me.btnUploadAddress)
        Me.Name = "FrmBrowser"
        Me.Text = "FrmBrowser"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnUploadAddress As System.Windows.Forms.Button
    Friend WithEvents txt_code As System.Windows.Forms.TextBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
