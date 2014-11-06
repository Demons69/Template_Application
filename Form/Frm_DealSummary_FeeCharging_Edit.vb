Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_DealSummary_FeeCharging_Edit

    Public strID As String = ""
    Public strMODE As String = "ADD"
    Private Const strALL = "--------Select--------"
    Dim conn As CSQL

    Private Sub SetControlFreq()
        txt_charge_frequency_due_date.Text = ""
        cbo_charge_frequency_date_of_month.Text = ""
        cbo_charge_frequency_date.Text = ""
        cbo_charge_frequency_month.Text = ""

        ''txt_charge_frequency_due_date.Enabled = False
        ''cbo_charge_frequency_date_of_month.Enabled = False
        ''cbo_charge_frequency_date.Enabled = False
        ''cbo_charge_frequency_month.Enabled = False

        'day
        lb_d.Visible = False
        txt_charge_frequency_due_date.Visible = False
        lb_d_format.Visible = False
        'monthly
        lb_m.Visible = False
        cbo_charge_frequency_date_of_month.Visible = False
        'yearly
        lb_y.Visible = False
        cbo_charge_frequency_date.Visible = False
        cbo_charge_frequency_month.Visible = False

        '=============working day condition ==============
        gcp_workingDayCondition.Enabled = False

        chk_mon.Checked = False
        chk_tue.Checked = False
        chk_wed.Checked = False
        chk_thu.Checked = False
        chk_fri.Checked = False

        rad_working_day_condition_type_next_round.Checked = False
        rad_working_day_condition_type_next_working_day.Checked = False


        If rad_charge_frequency_daily.Checked = True Then

            lb_d.Visible = True
            txt_charge_frequency_due_date.Visible = True
            lb_d_format.Visible = True
            gcp_workingDayCondition.Enabled = True

        End If

        If rad_charge_frequency_monthly.Checked = True Then
            lb_m.Visible = True
            cbo_charge_frequency_date_of_month.Visible = True
        End If

        If rad_charge_frequency_yearly.Checked = True Then
            lb_y.Visible = True
            cbo_charge_frequency_date.Visible = True
            cbo_charge_frequency_month.Visible = True

        End If

    End Sub

    Private Sub FillCombo()
        'cbo_gl_account
        Dim strSQL_Combo As String = ""

       

        If txt_company_id.Text <> "" Then
            ' Dim strSQL_Combo As String = ""
            strSQL_Combo = ""
            'strSQL_Combo += " SELECT  account_number from ( "
            'strSQL_Combo += "  select a.account_number as account_number from dbo.TB_DEAL_ACCOUNT a WHERE a.company_id='" & txt_company_id.Text.Replace("'", "''") & "' "
            'strSQL_Combo += "  union select a.account_number_charge as account_number  from dbo.TB_DEAL_ACCOUNT a WHERE a.company_id='" & txt_company_id.Text.Replace("'", "''") & "' "
            'strSQL_Combo += "  union select a.account_number_credit as account_number from dbo.TB_DEAL_ACCOUNT a WHERE a.company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
            'strSQL_Combo += " ) #all order BY account_number "
            strSQL_Combo += "select distinct account_number from dbo.TB_DEAL_ACCOUNT where account_type in('Current','Saving') and company_id='" & txt_company_id.Text.Replace("'", "''") & "' order by account_number"
            Call conn.Fill_ComboBox(strSQL_Combo, cbo_gl_account)
        Else
            strSQL_Combo = "SELECT  gl_account from [TB_FEE_CHARGING] group by gl_account ORDER by gl_account"
            Call conn.Fill_ComboBox(strSQL_Combo, cbo_gl_account)
        End If

        ' strSQL_Combo = "SELECT  request_wht from [TB_FEE_CHARGING] group by request_wht ORDER by request_wht"
        ' Call conn.Fill_ComboBox(strSQL_Combo, cbo_request_wht)
        cbo_request_wht.Items.Clear()
        cbo_request_wht.Items.Add("")
        cbo_request_wht.Items.Add("Yes")
        cbo_request_wht.Items.Add("No")

        cbo_charge_type.Items.Clear()
        cbo_charge_type.Items.Add("Fix Price")
        cbo_charge_type.Items.Add("Fix By Working Day")

        cbo_holiday_condition.Items.Clear()
        cbo_holiday_condition.Items.Add("Before Holiday")
        cbo_holiday_condition.Items.Add("Next Working Day")


        Dim i As Long
        cbo_charge_frequency_date_of_month.Items.Clear()
        cbo_charge_frequency_date.Items.Clear()
        For i = 1 To 31
            cbo_charge_frequency_date_of_month.Items.Add(i.ToString)
            cbo_charge_frequency_date.Items.Add(i.ToString)
        Next

        cbo_charge_frequency_month.Items.Clear()
        For i = 1 To 12
            cbo_charge_frequency_month.Items.Add(i.ToString)
        Next

    End Sub

    Private Sub Frm_DealSummary_FeeCharging_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        conn = New CSQL
        conn.Connect()
        Dim strSQL As String = ""
        Call FillCombo()

        If strMODE.ToUpper <> "ADD" Then
            Call ShowData()
        Else
            'Dim strSQL_data As String = ""
            'Dim strData As String = ""
            'strSQL_data = "select max(product_id) from dbo.TB_FEE_CHARGING where "
            'strData = conn.GetDataFromSQL(strSQL_data)
            'If IsNumeric(strData) = True Then
            '    txt_seq.Text = CDbl(strData) ' Format(CDbl(strData) + 1, "00000")
            'End If
        End If
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Function get_date_to_control(ByVal strData As Object) As String
        Try



            '  If strData = "" Then Return "NULL" : Exit Function

            Dim strtmp As String = ""
            If IsDate(strData) Then

                If Now.ToString("yyyy") > 2500 Then
                    strtmp = CDate(strData).ToString("dd/MM/") & CDate(strData).Year.ToString
                Else
                    strtmp = CDate(strData).ToString("dd/MM/yyyy")
                End If

                strtmp = Replace(strtmp, "-", "/")
            Else
                strtmp = ""
            End If


            Return strtmp
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM  [TB_FEE_CHARGING] WHERE [product_id] ='" + txt_Product_ID.Text + "' and seq=" & txt_seq.Text
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()
            txt_Product_ID.Text = IIf(res("product_id") Is System.DBNull.Value, "", res("product_id").ToString())
            txt_product_description.Text = IIf(res("product_description") Is System.DBNull.Value, "", res("product_description").ToString())
            txt_start_date.Text = get_date_to_control(res("start_date"))
            cbo_gl_account.Text = IIf(res("gl_account") Is System.DBNull.Value, "", res("gl_account").ToString())
            cbo_request_wht.Text = IIf(res("request_wht") Is System.DBNull.Value, "", res("request_wht").ToString())
            cbo_charge_type.Text = IIf(res("charge_type") Is System.DBNull.Value, "", res("charge_type").ToString())

            txt_expiration_date.Text = get_date_to_control(res("expiration_date"))
            txt_charge_amt.Text = IIf(res("charge_amt") Is System.DBNull.Value, "", CDbl(res("charge_amt")).ToString("###,##0.00"))
            cbo_holiday_condition.Text = IIf(res("holiday_condition") Is System.DBNull.Value, "", res("holiday_condition").ToString())
            'deduct_condition
            If IIf(res("deduct_condition") Is System.DBNull.Value, "", res("deduct_condition").ToString()) = "Billing" Then
                rad_deduct_condition_billing.Checked = True
            Else
                rad_deduct_condition_no_billing.Checked = True
            End If

            Select Case IIf(res("charge_frequency") Is System.DBNull.Value, "", res("charge_frequency").ToString())

                Case rad_charge_frequency_one_time.Text
                    rad_charge_frequency_one_time.Checked = True
                Case rad_charge_frequency_daily.Text
                    rad_charge_frequency_daily.Checked = True
                Case rad_charge_frequency_monthly.Text
                    rad_charge_frequency_monthly.Checked = True
                Case rad_charge_frequency_yearly.Text
                    rad_charge_frequency_yearly.Checked = True
                Case Else

            End Select

            txt_charge_frequency_due_date.Text = get_date_to_control(res("charge_frequency_due_date"))
            cbo_charge_frequency_date_of_month.Text = IIf(res("charge_frequency_date_of_month") Is System.DBNull.Value, "", res("charge_frequency_date_of_month").ToString())
            cbo_charge_frequency_date.Text = IIf(res("charge_frequency_date") Is System.DBNull.Value, "", res("charge_frequency_date").ToString())
            cbo_charge_frequency_month.Text = IIf(res("charge_frequency_month") Is System.DBNull.Value, "", res("charge_frequency_month").ToString())

            Dim strworking_day_condition_date As String = ""
            strworking_day_condition_date = IIf(res("working_day_condition_date") Is System.DBNull.Value, "", res("working_day_condition_date").ToString())

            If rad_charge_frequency_daily.Checked = True Then

                If InStr(strworking_day_condition_date, chk_mon.Text, CompareMethod.Text) > 0 Then
                    chk_mon.Checked = True
                End If
                If InStr(strworking_day_condition_date, chk_tue.Text, CompareMethod.Text) > 0 Then
                    chk_tue.Checked = True
                End If
                If InStr(strworking_day_condition_date, chk_wed.Text, CompareMethod.Text) > 0 Then
                    chk_wed.Checked = True
                End If
                If InStr(strworking_day_condition_date, chk_thu.Text, CompareMethod.Text) > 0 Then
                    chk_thu.Checked = True
                End If
                If InStr(strworking_day_condition_date, chk_fri.Text, CompareMethod.Text) > 0 Then
                    chk_fri.Checked = True
                End If

                If IIf(res("working_day_condition_type") Is System.DBNull.Value, "", res("working_day_condition_type").ToString()) <> "" Then
                    If IIf(res("working_day_condition_type") Is System.DBNull.Value, "", res("working_day_condition_type").ToString()) = "Next Round" Then
                        rad_working_day_condition_type_next_round.Checked = True
                    Else
                        rad_working_day_condition_type_next_working_day.Checked = True
                    End If
                End If

            End If

           



            txt_Product_ID.Enabled = False

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

    Private Function ValidationData() As String
        Dim strErr As String = ""

        'txt_company_id
        If txt_company_id.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Id]"
        End If

        If txt_Product_ID.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Product ID]"
        End If

        If txt_product_description.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Product Description]"
        End If


        If txt_start_date.Text = "" Or Is_date(txt_start_date.Text) = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Start Date]"
        End If

        If cbo_gl_account.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Account No]"
        End If

        If cbo_request_wht.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Request WHT]"
        End If

        If cbo_charge_type.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Charge Type]"
        End If

        'If txt_expiration_date.Text = "" Or Is_date(txt_expiration_date.Text) = False Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Expiration Date]"
        'End If

        If txt_charge_amt.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Charge Amount]"
        Else
            If IsNumeric(txt_charge_amt.Text) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Charge Amount]"
            End If
        End If

        If cbo_holiday_condition.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Holiday Condition]"
        End If

        If txt_charge_frequency_due_date.Visible = True Then
            If txt_charge_frequency_due_date.Text = "" Or Is_date(txt_charge_frequency_due_date.Text) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Due Date]"
            End If
        End If

        If cbo_charge_frequency_date_of_month.Visible = True Then
            If cbo_charge_frequency_date_of_month.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Date Of Month]"
            End If
        End If

        If cbo_charge_frequency_date.Visible = True Then
            If cbo_charge_frequency_date.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Date/Month]"
            End If
        End If

        If cbo_charge_frequency_month.Visible = True Then
            If cbo_charge_frequency_month.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Date/Month]"
            End If
        End If

        If rad_charge_frequency_monthly.Checked = True Then
            If rad_deduct_condition_no_billing.Checked = True Then
                If cbo_charge_frequency_date_of_month.Text <> "31" Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Date Of Month] must be value=31."
                End If
            Else
                If cbo_charge_frequency_date_of_month.Text = "31" Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Date Of Month] must be value<>31."
                End If
            End If
        End If

        Return strErr
    End Function

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

    Private Sub SaveData()
        Try
            Dim str_working_day_condition_date As String = ""
            If chk_mon.Checked = True Then
                str_working_day_condition_date += IIf(str_working_day_condition_date = "", "", ",") & chk_mon.Text
            End If
            If chk_tue.Checked = True Then
                str_working_day_condition_date += IIf(str_working_day_condition_date = "", "", ",") & chk_tue.Text
            End If
            If chk_wed.Checked = True Then
                str_working_day_condition_date += IIf(str_working_day_condition_date = "", "", ",") & chk_wed.Text
            End If
            If chk_thu.Checked = True Then
                str_working_day_condition_date += IIf(str_working_day_condition_date = "", "", ",") & chk_thu.Text
            End If
            If chk_fri.Checked = True Then
                str_working_day_condition_date += IIf(str_working_day_condition_date = "", "", ",") & chk_fri.Text
            End If
           


            conn = New CSQL
            conn.Connect()
            Dim strSQL As String = ""
            '========================add mode====================
            If strMODE.ToUpper = "ADD" Then
                strSQL = "SELECT * FROM [TB_FEE_CHARGING] WHERE [product_id] ='" + txt_Product_ID.Text.Replace("'", "''") + "' and seq=" & txt_seq.Text
                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid [Product ID]/[Seq] is duplicate.")
                    Exit Sub
                End If

                Dim strValue As String = ""
                Dim strFiledname As String = ""

                strFiledname += vbCrLf & "[Product_ID]"
                strValue += vbCrLf & "N'" & txt_Product_ID.Text.Replace("'", "''") & "'"
                'txt_seq
                strFiledname += vbCrLf & ",[seq]"
                strValue += vbCrLf & ",N'" & txt_seq.Text.Replace("'", "''") & "'"

                'txt_company_id
                strFiledname += vbCrLf & ",[company_id]"
                strValue += vbCrLf & ",N'" & txt_company_id.Text.Replace("'", "''") & "'"


                strFiledname += vbCrLf & ",[product_description]"
                strValue += vbCrLf & ",N'" & txt_product_description.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[start_date]"
                strValue += vbCrLf & "," & get_date_sql(txt_start_date.Text)

                strFiledname += vbCrLf & ",[gl_account]"
                strValue += vbCrLf & ",N'" & cbo_gl_account.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[request_wht]"
                strValue += vbCrLf & ",N'" & cbo_request_wht.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[charge_type]"
                strValue += vbCrLf & ",N'" & cbo_charge_type.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[expiration_date]"
                strValue += vbCrLf & "," & get_date_sql(txt_expiration_date.Text)

                strFiledname += vbCrLf & ",[charge_amt]"
                strValue += vbCrLf & "," & CDbl(txt_charge_amt.Text) & ""

                strFiledname += vbCrLf & ",[holiday_condition]"
                strValue += vbCrLf & ",N'" & cbo_holiday_condition.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[deduct_condition]"
                If rad_deduct_condition_no_billing.Checked = True Then
                    strValue += vbCrLf & ",N'" & rad_deduct_condition_no_billing.Text.Replace("'", "''") & "'"
                Else
                    strValue += vbCrLf & ",N'" & rad_deduct_condition_billing.Text.Replace("'", "''") & "'"
                End If

                strFiledname += vbCrLf & ",[charge_frequency]"
                If rad_charge_frequency_one_time.Checked = True Then
                    strValue += vbCrLf & ",N'" & rad_charge_frequency_one_time.Text.Replace("'", "''") & "'"
                End If
                If rad_charge_frequency_daily.Checked = True Then
                    strValue += vbCrLf & ",N'" & rad_charge_frequency_daily.Text.Replace("'", "''") & "'"
                End If
                If rad_charge_frequency_monthly.Checked = True Then
                    strValue += vbCrLf & ",N'" & rad_charge_frequency_monthly.Text.Replace("'", "''") & "'"
                End If
                If rad_charge_frequency_yearly.Checked = True Then
                    strValue += vbCrLf & ",N'" & rad_charge_frequency_yearly.Text.Replace("'", "''") & "'"
                End If

                strFiledname += vbCrLf & ",[charge_frequency_due_date]"
                strValue += vbCrLf & "," & get_date_sql(txt_charge_frequency_due_date.Text)

                strFiledname += vbCrLf & ",[charge_frequency_date_of_month]"
                strValue += vbCrLf & ",N'" & cbo_charge_frequency_date_of_month.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[charge_frequency_date]"
                strValue += vbCrLf & ",N'" & cbo_charge_frequency_date.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[charge_frequency_month]"
                strValue += vbCrLf & ",N'" & cbo_charge_frequency_month.Text.Replace("'", "''") & "'"

     

                If rad_charge_frequency_daily.Checked = True Then
                    strFiledname += vbCrLf & ",[working_day_condition_date]"
                    strValue += vbCrLf & ",N'" & str_working_day_condition_date.Replace("'", "''") & "'"

                    strFiledname += vbCrLf & ",[working_day_condition_type]"
                    If rad_working_day_condition_type_next_round.Checked = True Then
                        strValue += vbCrLf & ",N'" & rad_working_day_condition_type_next_round.Text.Replace("'", "''") & "'"
                    Else
                        strValue += vbCrLf & ",N'" & rad_working_day_condition_type_next_working_day.Text.Replace("'", "''") & "'"
                    End If
                Else
                    strFiledname += vbCrLf & ",[working_day_condition_date]"
                    strValue += vbCrLf & ",N''"

                    strFiledname += vbCrLf & ",[working_day_condition_type]"
                   strValue += vbCrLf & ",N''"
                End If

                strSQL = ""
                strSQL += vbCrLf & "insert into [TB_FEE_CHARGING]"
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper = "ADD" Then
            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [TB_FEE_CHARGING] set "

             
                'strSQL += vbCrLf & "[Product_ID]"
                ' strSQL += vbCrLf & "N'" & txt_Product_ID.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & "[seq]"
                strSQL += vbCrLf & "=N'" & txt_seq.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[product_description]"
                strSQL += vbCrLf & "=N'" & txt_product_description.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[company_id]"
                strSQL += vbCrLf & "=N'" & txt_company_id.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[start_date]"
                strSQL += vbCrLf & "=" & get_date_sql(txt_start_date.Text)

                strSQL += vbCrLf & ",[gl_account]"
                strSQL += vbCrLf & "=N'" & cbo_gl_account.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[request_wht]"
                strSQL += vbCrLf & "=N'" & cbo_request_wht.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[charge_type]"
                strSQL += vbCrLf & "=N'" & cbo_charge_type.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[expiration_date]"
                strSQL += vbCrLf & "=" & get_date_sql(txt_expiration_date.Text)

                strSQL += vbCrLf & ",[charge_amt]"
                strSQL += vbCrLf & "=" & CDbl(txt_charge_amt.Text) & ""

                strSQL += vbCrLf & ",[holiday_condition]"
                strSQL += vbCrLf & "=N'" & cbo_holiday_condition.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[deduct_condition]"
                If rad_deduct_condition_no_billing.Checked = True Then
                    strSQL += vbCrLf & "=N'" & rad_deduct_condition_no_billing.Text.Replace("'", "''") & "'"
                Else
                    strSQL += vbCrLf & "=N'" & rad_deduct_condition_billing.Text.Replace("'", "''") & "'"
                End If

                strSQL += vbCrLf & ",[charge_frequency]"
                If rad_charge_frequency_one_time.Checked = True Then
                    strSQL += vbCrLf & "=N'" & rad_charge_frequency_one_time.Text.Replace("'", "''") & "'"
                End If
                If rad_charge_frequency_daily.Checked = True Then
                    strSQL += vbCrLf & "=N'" & rad_charge_frequency_daily.Text.Replace("'", "''") & "'"
                End If
                If rad_charge_frequency_monthly.Checked = True Then
                    strSQL += vbCrLf & "=N'" & rad_charge_frequency_monthly.Text.Replace("'", "''") & "'"
                End If
                If rad_charge_frequency_yearly.Checked = True Then
                    strSQL += vbCrLf & "=N'" & rad_charge_frequency_yearly.Text.Replace("'", "''") & "'"
                End If

                strSQL += vbCrLf & ",[charge_frequency_due_date]"
                strSQL += vbCrLf & "=" & get_date_sql(txt_charge_frequency_due_date.Text)

                strSQL += vbCrLf & ",[charge_frequency_date_of_month]"
                strSQL += vbCrLf & "=N'" & cbo_charge_frequency_date_of_month.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[charge_frequency_date]"
                strSQL += vbCrLf & "=N'" & cbo_charge_frequency_date.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[charge_frequency_month]"
                strSQL += vbCrLf & "=N'" & cbo_charge_frequency_month.Text.Replace("'", "''") & "'"

                'strSQL += vbCrLf & ",[working_day_condition_date]"
                'strSQL += vbCrLf & "=N'" & str_working_day_condition_date.Replace("'", "''") & "'"

                'strSQL += vbCrLf & ",[working_day_condition_type]"
                'If rad_working_day_condition_type_next_round.Checked = True Then
                '    strSQL += vbCrLf & "=N'" & rad_working_day_condition_type_next_round.Text.Replace("'", "''") & "'"
                'Else
                '    strSQL += vbCrLf & "=N'" & rad_working_day_condition_type_next_working_day.Text.Replace("'", "''") & "'"
                'End If

                If rad_charge_frequency_daily.Checked = True Then
                    strSQL += vbCrLf & ",[working_day_condition_date]"
                    strSQL += vbCrLf & "=N'" & str_working_day_condition_date.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[working_day_condition_type]"
                    If rad_working_day_condition_type_next_round.Checked = True Then
                        strSQL += vbCrLf & "=N'" & rad_working_day_condition_type_next_round.Text.Replace("'", "''") & "'"
                    Else
                        strSQL += vbCrLf & "=N'" & rad_working_day_condition_type_next_working_day.Text.Replace("'", "''") & "'"
                    End If
                Else
                    strSQL += vbCrLf & ",[working_day_condition_date]"
                    strSQL += vbCrLf & "=N''"

                    strSQL += vbCrLf & ",[working_day_condition_type]"
                    strSQL += vbCrLf & "=N''"
                End If

                strSQL += vbCrLf & " WHERE [Product_ID] ='" + txt_Product_ID.Text.Replace("'", "''") + "'"

                strSQL += vbCrLf & " and seq=" & txt_seq.Text

                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper <> "ADD" Then

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    
    Private Sub rad_charge_frequency_one_time_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_charge_frequency_one_time.CheckedChanged
        Call SetControlFreq()
    End Sub

    Private Sub rad_charge_frequency_daily_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_charge_frequency_daily.CheckedChanged
        Call SetControlFreq()
    End Sub

    Private Sub rad_charge_frequency_monthly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_charge_frequency_monthly.CheckedChanged
        Call SetControlFreq()
    End Sub

    Private Sub rad_charge_frequency_yearly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_charge_frequency_yearly.CheckedChanged
        Call SetControlFreq()
    End Sub

    Private Sub btnFindCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCust.Click
        Call SearchData()
    End Sub

    Private Sub SearchData()
        Dim mFrm_DealSummary_List As New Frm_DealSummary_List
        mFrm_DealSummary_List.txtRef = txt_company_id
        mFrm_DealSummary_List.Is_parent = False
        mFrm_DealSummary_List.ShowDialog()

     
    End Sub

    Public Sub FillcomboAccount()
        If txt_company_id.Text <> "" Then
            Dim strSQL_Combo As String = ""
            strSQL_Combo = ""
            strSQL_Combo += " SELECT  account_number from ( "
            strSQL_Combo += "  select a.account_number as account_number from dbo.TB_DEAL_ACCOUNT a WHERE a.company_id='" & txt_company_id.Text.Replace("'", "''") & "' "
            strSQL_Combo += "  union select a.account_number_charge as account_number  from dbo.TB_DEAL_ACCOUNT a WHERE a.company_id='" & txt_company_id.Text.Replace("'", "''") & "' "
            strSQL_Combo += "  union select a.account_number_credit as account_number from dbo.TB_DEAL_ACCOUNT a WHERE a.company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
            strSQL_Combo += " ) #all order BY account_number "

            Call conn.Fill_ComboBox(strSQL_Combo, cbo_gl_account)
        End If
    End Sub

    
    Private Sub btn_find_product_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_find_product.Click
        Dim mFrm_DealSummary_FeeCharging_Select As New Frm_DealSummary_FeeCharging_Select
        mFrm_DealSummary_FeeCharging_Select.txtRef = txt_Product_ID
        'mFrm_DealSummary_FeeCharging_Select.Is_parent = True
        mFrm_DealSummary_FeeCharging_Select.ShowDialog()

        If txt_Product_ID.Text <> "" Then
            Call ShowDataByProduct()
            Call RunningSeq()
        End If
    End Sub

    Private Sub RunningSeq()
        If txt_Product_ID.Text = "" Then Exit Sub
        If strMODE.ToUpper <> "ADD" Then Exit Sub

        Dim strSQL_data As String = ""
        Dim strData As String = ""
        strSQL_data = "select isnull(max(seq),0) +1  from dbo.TB_FEE_CHARGING where product_id='" & txt_Product_ID.Text & "'"
        strData = conn.GetDataFromSQL(strSQL_data)
        If IsNumeric(strData) = True Then
            txt_seq.Text = CDbl(strData) ' Format(CDbl(strData) + 1, "00000")
        Else
            txt_seq.Text = "1"
        End If

    End Sub

    Private Sub ShowDataByProduct()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM  [TB_FEE_MST] WHERE [product_id] ='" + txt_Product_ID.Text + "'" ' and [seq]=" & txt_seq.Text
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()
            txt_product_description.Text = IIf(res("product_description") Is System.DBNull.Value, "", res("product_description").ToString())
            cbo_charge_type.Text = IIf(res("charge_type") Is System.DBNull.Value, "", res("charge_type").ToString())
            txt_charge_amt.Text = IIf(res("charge_amt") Is System.DBNull.Value, "", CDbl(res("charge_amt")).ToString("###,##0.00"))
            'cbo_holiday_condition.Text = IIf(res("holiday_condition") Is System.DBNull.Value, "", res("holiday_condition").ToString())
            'deduct_condition
            If IIf(res("deduct_condition") Is System.DBNull.Value, "", res("deduct_condition").ToString()) = "Billing" Then
                rad_deduct_condition_billing.Checked = True
            Else
                rad_deduct_condition_no_billing.Checked = True
            End If

            Select Case IIf(res("charge_frequency") Is System.DBNull.Value, "", res("charge_frequency").ToString())

                Case rad_charge_frequency_one_time.Text
                    rad_charge_frequency_one_time.Checked = True
                Case rad_charge_frequency_daily.Text
                    rad_charge_frequency_daily.Checked = True
                Case rad_charge_frequency_monthly.Text
                    rad_charge_frequency_monthly.Checked = True
                Case rad_charge_frequency_yearly.Text
                    rad_charge_frequency_yearly.Checked = True
                Case Else

            End Select


        End If
        res.Close()
        res = Nothing

    End Sub

    

    Private Sub txt_Product_ID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Product_ID.Validated
        If txt_Product_ID.Text <> "" Then
            Call ShowDataByProduct()
            Call RunningSeq()
        End If
    End Sub

    
    Private Sub rad_deduct_condition_no_billing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_deduct_condition_no_billing.CheckedChanged
        If rad_deduct_condition_no_billing.Checked = True Then
            If rad_charge_frequency_monthly.Checked = True Then
                cbo_charge_frequency_date_of_month.Text = "31"
            End If
        End If

    End Sub
End Class