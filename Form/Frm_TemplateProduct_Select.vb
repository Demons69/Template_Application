Imports Template_Application.CSQL
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class Frm_TemplateProduct_Select
    Dim conn As CSQL
    Dim res As SqlDataReader
    Dim sql_cmd As String, add_cmd As String

    Private Const strALL = "--------Please Select--------"
    Private Const strBlankForm = "--------Blank Form--------"

    Private Const strSingleProduct = "Single-Product"
    Private Const strProductChare = "Product Charge"

    Private Sub Frm_PD_Select_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            conn = New CSQL
            Dim strSQL As String = ""
            'LIST OF PRODUCT
            strSQL = conn.GetSQL_LIST_PRODUCT_MST

            'strSQL = "SELECT DISTINCT [Product] FROM [PRD_TemplateProduct] ORDER BY [Product]"
            conn.Fill_ComboBox(strSQL, cbo_product, strALL)
            If cbo_product.Items.Count > 0 Then cbo_product.SelectedIndex = 0
            cbo_Template.Text =""
            cbo_Template.Enabled = False
            btn_Next.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub CB_PD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_product.SelectedIndexChanged
        Try
            Dim strSQL As String = ""
            strSQL = "SELECT DISTINCT [TemplateCode] FROM [PRD_TemplateProduct] "
            strSQL += " where Product='" & cbo_product.Text.Substring(0, 3).Replace("'", "''") & "' ORDER BY [TemplateCode] "

            conn.Fill_ComboBox(strSQL, cbo_Template, strBlankForm)
            If cbo_Template.Items.Count > 1 Then cbo_Template.SelectedIndex = 1
            cbo_Template.Enabled = True
            btn_Next.Enabled = True
            cbo_Template.Focus()

            Call AutoLastNumber()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub btn_Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Next.Click

        'If cbo_Template.Text = strBlankForm Then
        '    MessageBox.Show("On going.")
        '    Exit Sub
        'End If

        If cbo_Template.Text = "" Then
            MessageBox.Show("Invalid Template Code. Please selection Template code.")
            Exit Sub
        End If

        Dim f As New Frm_TemplateProduct_Edit
        f.strMODE = "ADD"
        ' f.txt_new_template.Text = txt_new_template.Text
        f.cbo_Product.Text = cbo_product.Text
        f.cbo_Product.Enabled = False

        f.txt_TemplateCode.Text = cbo_Template.Text.Replace(strBlankForm, "")
        Me.Close()
        f.ShowDialog()

    End Sub


    Private Sub AutoLastNumber()
        Try
            Dim strTemplateType As String = ""
            Dim strSQL As String = ""

            'If cbo_product.Text.Length <> 3 Then Exit Sub


            strTemplateType += strSingleProduct


            strSQL = "select max(TemplateCode) as TemplateCode from PRD_Template  "
            strSQL += " where ProductCode='" & cbo_product.Text.Substring(0, 3).Replace("'", "''") & "' "
            strSQL += " and TemplateType='" & strTemplateType.Replace("'", "''") & "' "

            Dim strValue As String = conn.GetDataFromSQL(strSQL)
            Dim intMax As Double

            'product
            If strValue = "" Then
                txt_new_template.Text = cbo_product.Text.Substring(0, 3) & "P000001"
            Else
                intMax = CDbl(strValue.Substring(strValue.Length - 6)) + 1
                txt_new_template.Text = cbo_product.Text.Substring(0, 3) & "P" & intMax.ToString("000000")
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class
