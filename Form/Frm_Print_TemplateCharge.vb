Imports Template_Application.CSQL
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Frm_Print_TemplateCharge
    Dim conn As CSQL
    Dim res As SqlDataReader
    Dim sql_cmd As String, add_cmd As String

    Private Sub Frm_Print_CU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New CSQL
        Dim strSQL As String
        ' strSQL = "SELECT DISTINCT [Product] FROM dbo.PRD_TemplateChargeEvents ORDER BY [Product]"
        strSQL = conn.GetSQL_LIST_PRODUCT_MST

        conn.Fill_ComboBox(strSQL, CB_PD)
        btnPrint.Enabled = False

    End Sub

    Private Sub CB_PD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_PD.SelectedIndexChanged
        conn.Connect()
        res = conn.GetDataReader("SELECT Distinct TemplateCode FROM PRD_TemplateChargeEvents WHERE Product ='" + CB_PD.Text.Substring(0, 3) + "'")

        st_s.Items.Clear()
        While (res.Read())
            st_s.Items.Add(res(0).ToString())
        End While

        If st_s.Items.Count > 0 Then
            st_s.SelectedIndex = 0
            btnPrint.Enabled = True
            st_s.Enabled = True
            end_s.Enabled = True
        End If

        conn.Close()
    End Sub

    Private Sub st_s_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles st_s.SelectedIndexChanged
        conn.Connect()
        res = conn.GetDataReader("SELECT Distinct TemplateCode FROM PRD_TemplateChargeEvents WHERE Product ='" + CB_PD.Text.Substring(0, 3) + "' AND TemplateCode >='" + st_s.Text + "'")

        end_s.Items.Clear()
        While (res.Read())
            end_s.Items.Add(res(0).ToString())
        End While
        If end_s.Items.Count > 0 Then end_s.SelectedIndex = 0
        conn.Close()
    End Sub

    Private Sub Frm_Print_CU_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            'Dim FrmReport As New FrmReport
            'FrmReport.ReportType = "TemplateChageEvent"
            'FrmReport.SQL = "SELECT * FROM PRD_TemplateChargeEvents WHERE TemplateCode BETWEEN '" + st_s.Text + "' and '" + end_s.Text + "'"
            ''FrmReport.Show()

            Dim FrmReport2 As New FrmReport
            FrmReport2.ReportType = "TemplateChageUnit"
            FrmReport2.strLine(0) = ""
            FrmReport2.strSQL_PRD_Template = "SELECT * FROM PRD_Template WHERE TemplateCode BETWEEN'" + st_s.Text + "' and '" + end_s.Text + "'"
            FrmReport2.strSQL1 = "SELECT * FROM PRD_TemplateChargeEvents WHERE TemplateCode BETWEEN '" + st_s.Text + "' and '" + end_s.Text + "' order by TemplateCode,Product"
            FrmReport2.strSQL2 = "SELECT * FROM PRD_TemplateChargeUnits WHERE TemplateCode BETWEEN '" + st_s.Text + "' and '" + end_s.Text + "' order by  TemplateCode,Product,Event "
            FrmReport2.ShowDialog()

            'Dim mFrmReport_Muti As New FrmReport_Muti
            'mFrmReport_Muti.strSQL1 = "SELECT * FROM PRD_TemplateChargeEvents WHERE TemplateCode BETWEEN '" + st_s.Text + "' and '" + end_s.Text + "'"
            'mFrmReport_Muti.strSQL2 = "SELECT * FROM PRD_TemplateChargeUnits WHERE TemplateCode  BETWEEN '" + st_s.Text + "' and '" + end_s.Text + "'"
            'mFrmReport_Muti.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class