Public Class FrmPrint_InputDescription
    Public strReportName As String = "" 'product,charge

    Public strWarnning As String = "This Product Template has been setup IVR Fax/Email, please consider in" & vbCrLf & "Client Master master for IVR Fax/Email flag."


    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub FrmPrint_InputDescription_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.KeyPreview = True
        If strWarnning <> "" Then
            txtRemark.Text = strWarnning '"Template Code นี้มีการ Setup [IVR Fax/Email]. กรุณา Setup Client Master ให้สอดคล้องกัน"
        End If

    End Sub

    Private Sub PrintReport()

        Try
            Dim FrmReport As New FrmReport
            FrmReport.ReportType = "TemplateExists"
            If txt_clientcode.Text <> "" Then
                FrmReport.strLine(0) = txt_clientcode.Text
            End If

            If txt_template_code.Text <> "" Then
                FrmReport.strLine(1) = txt_template_code.Text
            End If
            If txtRemark.Text <> "" Then
                FrmReport.strLine(2) = txtRemark.Text
            End If

            If strReportName = "product" Then
                FrmReport.strLine(3) = "TEMPLATE PRODUCT"
            Else
                FrmReport.strLine(3) = "TEMPLATE CHARGE"
            End If


            FrmReport.ShowDialog()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub BT_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Print.Click
        Dim strErr As String = ""
        'If txt_clientcode.Text = "" Then
        '    strErr += "Invalid, [Client Code]"
        'End If
        'If txtRemark.Text = "" Then
        '    strErr += vbCrLf & "Invalid, [Remark]"
        'End If
        'If strErr <> "" Then
        '    If MsgBox(strErr & vbCrLf & "Do you want to print? [Y/N]", MsgBoxStyle.YesNo, "Confirm...") = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        'End If
        Call PrintReport()
    End Sub


End Class