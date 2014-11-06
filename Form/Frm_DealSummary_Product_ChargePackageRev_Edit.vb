Imports Template_Application.CSQL
Imports System.Data.SqlClient


Public Class Frm_DealSummary_Product_ChargePackageRev_Edit
    Public strID As String = ""
    Public strMODE As String = "ADD"
    Private Const strALL = "--------Select--------"
    Dim conn As CSQL

    Private Sub Frm_DealSummary_Product_ChargePackageRev_Edit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_DealSummary_Product_ChargePackageRev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        conn = New CSQL
        conn.Connect()
        Dim strSQL As String = ""
        Dim vnt As String = ""

        strSQL = " select TemplateCode from dbo.PRD_Template where TemplateType='Product Charge' and StatusTemplate='Y'  and ProductCode like '" & txt_my_product.Text.Substring(0, 3).Replace("'", "''") & "%'  order BY TemplateCode"
        conn.Fill_ComboBox(strSQL, cbo_charge_template)
        cbo_charge_template.Items.Add("")

        If strMODE.ToUpper <> "ADD" Then
            Call ShowData()
        Else

            strSQL = "select isnull(max(seq),0) + 1 as count_item from TB_DEAL_PRODUCT_CHARGE_PACKAGE  where my_product='" & txt_my_product.Text.Replace("'", "''") & "'"
            vnt = conn.GetDataFromSQL(strSQL)
            txt_seq.Text = vnt

        End If

    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Function get_date_sql(ByVal strData As String) As String
        Try



            If strData = "" Then Return "NULL" : Exit Function

            Dim strtmp As String = ""
            If UBound(strData.Split("/")) = 2 Then
                strtmp = strData.Split("/")(2) & "/" & strData.Split("/")(1) & "/" & strData.Split("/")(0)
                strtmp = "'" & strtmp & "'"
            Else
                strtmp = "NULL"
            End If


            Return strtmp
        Catch ex As Exception
            Return "NULL"
        End Try
    End Function

    Private Function get_date_to_control(ByVal strData As Object) As String
        Try



            '  If strData = "" Then Return "NULL" : Exit Function

            Dim strtmp As String = ""
            If IsDate(strData) Then
                strtmp = CDate(strData).ToString("dd/MM/") & CDate(strData).Year
                strtmp = Replace(strtmp, "-", "/")
            Else
                strtmp = ""
            End If


            Return strtmp
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function Is_date(ByVal strData As String) As Boolean
        Try
            Is_date = True


            If strData = "" Then Exit Function

            Dim strtmp As String = ""
            If UBound(strData.Split("/")) = 2 Then
                strtmp = strData.Split("/")(2) & "/" & strData.Split("/")(1) & "/" & strData.Split("/")(0)
            Else
                Is_date = False : Exit Function
            End If

            If IsDate(strtmp) = False Then
                Is_date = False : Exit Function
            End If

        Catch ex As Exception

        End Try
    End Function

    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_DEAL_PRODUCT_CHARGE_PACKAGE] WHERE  my_product='" + txt_my_product.Text.Replace("'", "''") + "' and seq= " & txt_seq.Text
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()
            'txt_mapping_code.Enabled = False
            cbo_charge_template.Text = IIf(res("charge_template") Is System.DBNull.Value, "", res("charge_template").ToString())
            txt_start_date.Text = get_date_to_control(res("start_date"))
            txt_end_date.Text = get_date_to_control(res("end_date"))

        End If

        res.Close()
        res = Nothing

    End Sub

    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click
        Dim strErr As String = ""
        strErr = ValidationData()
        If strErr <> "" Then
            MessageBox.Show(strErr)
            Exit Sub
        End If

        Call SaveData()
    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""

        If cbo_charge_template.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Charge Template]"
        End If

        If txt_start_date.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Start Date]"
        Else
            If get_date_sql(txt_start_date.Text) = "NULL" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Start Date]"
            End If
        End If

        If txt_end_date.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [End Date]"
        Else
            If get_date_sql(txt_end_date.Text) = "NULL" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [End Date]"
            End If
        End If

        Return strErr
    End Function

    Private Sub SaveData()
        Dim strRevDate As String = Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)
        Dim strSQL As String = ""

        Try
            conn = New CSQL
            conn.Connect()

            '========================add mode====================
            If strMODE.ToUpper = "ADD" Then
                strSQL = "SELECT * FROM [TB_DEAL_PRODUCT_CHARGE_PACKAGE] WHERE  my_product='" + txt_my_product.Text.Replace("'", "''") + "'  and seq =" & txt_seq.Text
                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid [seq] is duplicate.")
                    Exit Sub
                End If

                Dim strValue As String = ""
                Dim strFiledname As String = ""

                strFiledname += vbCrLf & "[company_id]"
                strValue += vbCrLf & "  N'" & txt_company_id.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & " , [my_product]"
                strValue += vbCrLf & " , N'" & txt_my_product.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & " , [seq]"
                strValue += vbCrLf & " , " & txt_seq.Text.Replace(",", "") & ""

                strFiledname += vbCrLf & ",[charge_template]"
                strValue += vbCrLf & ", N'" & cbo_charge_template.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[start_date]"
                strValue += vbCrLf & ", " & get_date_sql(txt_start_date.Text.Replace("'", "''"))

                strFiledname += vbCrLf & ",[end_date]"
                strValue += vbCrLf & ", " & get_date_sql(txt_end_date.Text.Replace("'", "''"))

                strFiledname += vbCrLf & " ,[revision_code]"
                strValue += vbCrLf & ",N'" & txt_revision_code.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[revision_desc]"
                strValue += vbCrLf & ",N'" & txt_revision_desc.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[revision_date]"
                strValue += vbCrLf & ", '" & strRevDate & "'"


                strSQL = ""
                strSQL += vbCrLf & "insert into [TB_DEAL_PRODUCT_CHARGE_PACKAGE]  "
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                conn.ExecuteNonQuery(strSQL)
                '  Me.Close()

            End If ' If strMODE.ToUpper = "ADD" Then
            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [TB_DEAL_PRODUCT_CHARGE_PACKAGE] set "




                strSQL += vbCrLf & "  [charge_template]"
                strSQL += vbCrLf & "=N'" & cbo_charge_template.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & " , [start_date]"
                strSQL += vbCrLf & "= " & get_date_sql(txt_start_date.Text.Replace("'", "''"))

                strSQL += vbCrLf & ",[end_date]"
                strSQL += vbCrLf & "= " & get_date_sql(txt_end_date.Text.Replace("'", "''"))


                strSQL += vbCrLf & " ,[revision_code]"
                strSQL += vbCrLf & "=N'" & txt_revision_code.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[revision_desc]"
                strSQL += vbCrLf & "=N'" & txt_revision_desc.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[revision_date]"
                strSQL += vbCrLf & "=getdate()"


                strSQL += vbCrLf & "  WHERE  my_product='" + txt_my_product.Text.Replace("'", "''") + "'  and seq =" & txt_seq.Text
                conn.ExecuteNonQuery(strSQL)
                '  Me.Close()

            End If ' If strMODE.ToUpper <> "ADD" Then

            strSQL = ""
            strSQL += vbCrLf & " DELETE FROM dbo.TB_REVISION_HISTORY WHERE company_id='" + txt_company_id.Text.Replace("'", "''") + "'"
            ' strSQL += vbCrLf & "   and revision_code='" + txt_revision_code.Text.Replace("'", "''") + "' "
            strSQL += vbCrLf & "   and revision_code in ('Rev0022') "

            strSQL += vbCrLf & " insert into  TB_REVISION_HISTORY (company_id,revision_code,revision_desc,revision_date)"
            'company_id,revision_code,revision_desc,revision_date,revision_reason
            strSQL += vbCrLf & " select distinct company_id,revision_code,revision_desc,revision_date from  [TB_DEAL_PRODUCT_CHARGE_PACKAGE] "
            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  " 'and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "
            strSQL += vbCrLf & "   and revision_code in ('Rev0022') "

            conn.ExecuteNonQuery(strSQL)
            Me.Close()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class