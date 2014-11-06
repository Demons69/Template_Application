Imports Template_Application.CSQL
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Frm_Print_TemplateProduct
    Dim conn As CSQL
    Dim res As SqlDataReader
    Dim sql_cmd As String, add_cmd As String
    Private Const strALL = "--------ALL--------"

    Private Sub Frm_Print_PD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then Me.Close()
    End Sub

    Private Sub Frm_Print_PD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New CSQL
        Dim strSQL As String
        'strSQL = "SELECT DISTINCT [Product] FROM [PRD_TemplateProduct] ORDER BY [Product]"
        strSQL = conn.GetSQL_LIST_PRODUCT_MST

        conn.Fill_ComboBox(strSQL, CB_PD)
        btnPrint.Enabled = False

    End Sub

    Private Sub CB_PD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_PD.SelectedIndexChanged

        res = conn.GetDataReader("SELECT Distinct TemplateCode FROM PRD_TemplateProduct WHERE Product ='" + CB_PD.Text.Substring(0, 3) + "'")

        st_s.Items.Clear()
        While (res.Read())
            st_s.Items.Add(res(0).ToString())
        End While

        If st_s.Items.Count > 0 Then
            st_s.SelectedIndex = 0 : btnPrint.Enabled = True
            st_s.Enabled = True
            end_s.Enabled = True
        End If

        conn.Close()


    End Sub

    Private Sub st_s_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles st_s.SelectedIndexChanged
        conn.Connect()
        res = conn.GetDataReader("SELECT Distinct TemplateCode FROM PRD_TemplateProduct WHERE Product ='" + CB_PD.Text.Substring(0, 3) + "' AND TemplateCode >='" + st_s.Text + "'")

        end_s.Items.Clear()
        While (res.Read())
            end_s.Items.Add(res(0).ToString())
        End While
        If end_s.Items.Count > 0 Then end_s.SelectedIndex = 0
        conn.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Dim FrmReport As New FrmReport
            FrmReport.ReportType = "TemplateProduct"
            '   FrmReport.SQL = "SELECT * FROM PRD_TemplateProduct WHERE TemplateCode BETWEEN '" + st_s.Text + "' and '" + end_s.Text + "' order by TemplateCode "
            FrmReport.SQL = ""
            FrmReport.SQL += "   SELECT a.*,CustomerFloatRate1  + '(' + cast(b.BASE_RATE as varchar) + ')'    +  '  ' +    cast( [BASE_RATE_DESCRIPTION] as nvarchar(150))  as CustomerFloatRate2"
            FrmReport.SQL += " FROM dbo.PRD_TemplateProduct a"
            FrmReport.SQL += " left outer join  dbo.BASE_RATES_MST b"
            FrmReport.SQL += " on a.CustomerFloatRate1=b.BASE_RATE_CODE"
            FrmReport.SQL += " where TemplateCode BETWEEN '" + st_s.Text + "' and '" + end_s.Text + "' order by TemplateCode "

            FrmReport.strLine(0) = ""

            FrmReport.strSQL_PRD_Template = "SELECT * FROM PRD_Template WHERE TemplateCode BETWEEN '" + st_s.Text + "' and '" + end_s.Text + "'   order by TemplateCode"
            FrmReport.strSQL_PRD_TemplateProductArrangements = "SELECT * FROM PRD_TemplateProductArrangements WHERE TemplateCode BETWEEN '" + st_s.Text + "' and '" + end_s.Text + "'   order by TemplateCode"
            FrmReport.strSQL_PRD_TemplateProductClearingLocation = "SELECT * FROM PRD_TemplateProductClearingLocation WHERE TemplateCode BETWEEN '" + st_s.Text + "' and '" + end_s.Text + "'   order by TemplateCode"
            FrmReport.strSQL_PRD_TemplateInstrumentEnrichments = "SELECT * FROM PRD_TemplateInstrumentEnrichments  WHERE TemplateCode BETWEEN '" + st_s.Text + "' and '" + end_s.Text + "'   order by TemplateCode"

            FrmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class