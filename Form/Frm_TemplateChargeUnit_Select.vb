Imports Template_Application.CSQL
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class Frm_TemplateChargeUnit_Select

    Dim conn As CSQL
    Dim res As SqlDataReader
    Dim sql_cmd As String, add_cmd As String

    Private Const strALL = "--------Please Select--------"
    Private Const strBlankForm = "--------Blank Form--------"

    Private Const strSingleProduct = "Single-Product"
    Private Const strProductCharge = "Product Charge"

    Private Sub Frm_PD_Select_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            conn = New CSQL
            Dim strSQL As String
            'strSQL = "SELECT DISTINCT [Product] FROM [PRD_TemplateChargeEvents] ORDER BY [Product]"
            strSQL = conn.GetSQL_LIST_PRODUCT_MST
            conn.Fill_ComboBox(strSQL, cbo_product, strALL)
            If cbo_product.Items.Count > 0 Then cbo_product.SelectedIndex = 0
            cbo_Template.Text = ""
            cbo_Template.Enabled = False
            btn_Next.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub CB_PD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_product.SelectedIndexChanged
        Try
            Dim strSQL As String = ""
            strSQL = "SELECT DISTINCT [TemplateCode] FROM [PRD_TemplateChargeEvents] "
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

        Me.Close()

        'Dim mFrm_TemplateChargeUnit_list_pre_entry As New Frm_TemplateChargeUnit_list_pre_entry
        'mFrm_TemplateChargeUnit_list_pre_entry.strMODE = "ADD"
        'mFrm_TemplateChargeUnit_list_pre_entry.txt_new_template.Text = txt_new_template.Text
        'mFrm_TemplateChargeUnit_list_pre_entry.txt_CopyFromTemplate.Text = cbo_Template.Text
        'mFrm_TemplateChargeUnit_list_pre_entry.ShowDialog()

        Dim mFrm_TemplateChargeUnit_Wizard As New Frm_TemplateChargeUnit_Wizard
        ' mFrm_TemplateChargeUnit_Wizard.txt_new_template.Text = txt_new_template.Text
        mFrm_TemplateChargeUnit_Wizard.txt_CopyFromTemplate.Text = cbo_Template.Text
        mFrm_TemplateChargeUnit_Wizard.strProduct = cbo_product.Text
        Call mFrm_TemplateChargeUnit_Wizard.SetScreenByProduct()
        mFrm_TemplateChargeUnit_Wizard.ShowDialog()
    End Sub


    Private Sub AutoLastNumber()
        Try
            Dim strTemplateType As String = ""
            Dim strSQL As String = ""

            '  If cbo_product.Text.Length <> 3 Then Exit Sub


            strTemplateType += strProductCharge


            strSQL = "select max(TemplateCode) as TemplateCode from PRD_Template  "
            strSQL += " where ProductCode='" & cbo_product.Text.Substring(0, 3).Replace("'", "''") & "' "
            strSQL += " and TemplateType='" & strTemplateType.Replace("'", "''") & "' "

            Dim strValue As String = conn.GetDataFromSQL(strSQL)
            Dim intMax As Double

            'charge
            If strValue = "" Then
                txt_new_template.Text = cbo_product.Text.Substring(0, 3) & "CG00001"
            Else
                intMax = CDbl(strValue.Substring(strValue.Length - 5)) + 1
                txt_new_template.Text = cbo_product.Text.Substring(0, 3) & "CG" & intMax.ToString("00000")
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class