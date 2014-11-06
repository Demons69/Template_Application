Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_DealSummary_Product

    Public strID As String = ""
    Public strMODE As String = "ADD"
    Private Const strALL = "--------Select--------"
    Dim conn As CSQL
    Private x As String
    Dim xFrm_DealSummary_Product_SelectMyProduct As Frm_DealSummary_Product_SelectMyProduct

    Public Sub New(ByVal param As Frm_DealSummary_Product_SelectMyProduct)
        InitializeComponent()
        xFrm_DealSummary_Product_SelectMyProduct = param

    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Private Sub ShowDataModeAdd()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = " SELECT * FROM [TB_BANK_PRODUCT_LIBRARY] "
        strSQL += " WHERE [MYPRODUCT] ='" + txt_my_product.Text.Replace("'", "''") + "'  "
        strSQL += " and PRODUCT_CODE ='" + cbo_bank_product.Text.Replace("'", "''") + "' "
        strSQL += " and UDEPRODUCT ='" + cbo_ude_product.Text.Replace("'", "''") + "' "
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()


            txt_product_name.Text = IIf(res("MYPRODUCT_DESCRIPTION") Is System.DBNull.Value, "", res("MYPRODUCT_DESCRIPTION").ToString())
            txt_rule_priority.Text = IIf(res("RULE_PRIORITY") Is System.DBNull.Value, "", res("RULE_PRIORITY").ToString())
            txt_rule_code.Text = IIf(res("RULE_CODE") Is System.DBNull.Value, "", res("RULE_CODE").ToString())
            txt_per_txm_max_amt.Text = IIf(res("PER_TXN_MAX_AMNT") Is System.DBNull.Value, "", res("PER_TXN_MAX_AMNT").ToString())


            txt_per_txm_max_amt.Text = CDbl(txt_per_txm_max_amt.Text).ToString("###,##0.0")


            cbo_arrangement.Text = IIf(res("ARRANGEMENT_CODE") Is System.DBNull.Value, "", res("ARRANGEMENT_CODE").ToString())
            txt_days_period.Text = IIf(res("DAYS_PERIOD") Is System.DBNull.Value, "", res("DAYS_PERIOD").ToString())

            txt_product_name.Enabled = False
            txt_rule_priority.Enabled = False
            txt_rule_code.Enabled = False
            txt_per_txm_max_amt.Enabled = True
            cbo_arrangement.Enabled = True

            If txt_my_product.Text = "FTR" Then
                cbo_beneficiary_type.Text = "Others"
                cbo_adhoc_allow.Text = "Allowed"
            End If '  If txt_my_product.Text = "FTR" Then

        End If
        res.Close()
        res = Nothing
    End Sub

    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = " SELECT * FROM [TB_DEAL_PRODUCT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
        strSQL += " and my_product ='" + txt_my_product.Text.Replace("'", "''") + "' "
        strSQL += " and bank_product ='" + cbo_bank_product.Text.Replace("'", "''") + "' "

        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then

            txt_product_name.Enabled = False
            txt_rule_priority.Enabled = False
            txt_rule_code.Enabled = False
            txt_per_txm_max_amt.Enabled = True
            cbo_arrangement.Enabled = True

            res.Read()
            txt_my_product.Enabled = False

            txt_product_name.Text = IIf(res("product_name") Is System.DBNull.Value, "", res("product_name").ToString())
            cbo_ude_product.Text = IIf(res("ude_product") Is System.DBNull.Value, "", res("ude_product").ToString())
            Call FillComboByProduct()
            cbo_bank_product.Text = IIf(res("bank_product") Is System.DBNull.Value, "", res("bank_product").ToString())

            If InStr("COC,COE", cbo_bank_product.Text.Substring(cbo_bank_product.Text.Length - 3, 3)) > 0 Then
                lst_pickup_location.Enabled = True

                If cbo_bank_product.Text = "COE" Or cbo_bank_product.Text = "COC" Then
                    strSQL = ""
                    strSQL += vbCrLf & " SELECT isnull(PICKUP_LOCATION_DESCRIPTION,'') + ' || ' + isnull(PICKUP_LOCATION,'') + '' as pickup  "
                    strSQL += vbCrLf & " FROM dbo.PICKUP_LOCATION_MST "
                    strSQL += vbCrLf & " where not ( PICKUP_LOCATION like 'FSI%' or PICKUP_LOCATION like 'UL%' )"
                    strSQL += vbCrLf & " and PICKUP_LOCATION like '%" & cbo_bank_product.Text & "'"
                    strSQL += vbCrLf & " order by PICKUP_LOCATION_DESCRIPTION"
                    conn.Fill_ComboBox(strSQL, lst_pickup_location)
                End If

            Else
                lst_pickup_location.Enabled = False
            End If

            txt_rule_priority.Text = IIf(res("rule_priority") Is System.DBNull.Value, "", res("rule_priority").ToString())
            txt_rule_code.Text = IIf(res("rule_code") Is System.DBNull.Value, "", res("rule_code").ToString())

            cbo_arrangement.Text = IIf(res("arrangement") Is System.DBNull.Value, "", res("arrangement").ToString())
            txt_days_period.Text = IIf(res("days_period") Is System.DBNull.Value, "", res("days_period").ToString())
            txt_per_txm_max_amt.Text = IIf(res("per_txm_max_amt") Is System.DBNull.Value, "", res("per_txm_max_amt").ToString())
            txt_per_txm_max_amt.Text = CDbl(txt_per_txm_max_amt.Text).ToString("###,##0.0")
            'txt_account_number.Text = IIf(res("account_number") Is System.DBNull.Value, "", res("account_number").ToString())

            'cbo_pickup_location.Text = IIf(res("pickup_location_desc") Is System.DBNull.Value, "", res("pickup_location_desc").ToString()) & " || " & IIf(res("pickup_location") Is System.DBNull.Value, "", res("pickup_location").ToString()) 'cbo_pickup_location.FindString(IIf(res("pickup_location_desc") Is System.DBNull.Value, "", res("pickup_location_desc").ToString()))

            cbo_product_template.Text = IIf(res("product_template") Is System.DBNull.Value, "", res("product_template").ToString())
            cbo_charge_template.Text = IIf(res("charge_template") Is System.DBNull.Value, "", res("charge_template").ToString())
            cbo_beneficiary_type.Text = IIf(res("beneficiary_type") Is System.DBNull.Value, "", res("beneficiary_type").ToString())
            cbo_my_product_usage.Text = IIf(res("my_product_usage") Is System.DBNull.Value, "", res("my_product_usage").ToString())
            cbo_auth_type.Text = IIf(res("auth_type") Is System.DBNull.Value, "", res("auth_type").ToString())
            cbo_auth_level.Text = IIf(res("auth_level") Is System.DBNull.Value, "", res("auth_level").ToString())
            cbo_adhoc_allow.Text = IIf(res("adhoc_allow") Is System.DBNull.Value, "", res("adhoc_allow").ToString())
            ' txt_beneficiary_advice_detail.Text = IIf(res("beneficiary_advice_detail") Is System.DBNull.Value, "", res("beneficiary_advice_detail").ToString())
            '==============Manual Entry=================
            If IIf(res("manual_entry_approve_required") Is System.DBNull.Value, "", res("manual_entry_approve_required").ToString()) = "Y" Then
                chk_manual_entry_approve_required.Checked = True
            Else
                chk_manual_entry_approve_required.Checked = False
            End If

            If IIf(res("manual_entry_verify_required") Is System.DBNull.Value, "", res("manual_entry_verify_required").ToString()) = "Y" Then
                chk_manual_entry_verify_required.Checked = True
            Else
                chk_manual_entry_verify_required.Checked = False
            End If

            If IIf(res("manual_entry_send_required") Is System.DBNull.Value, "", res("manual_entry_send_required").ToString()) = "Y" Then
                chk_manual_entry_send_required.Checked = True
            Else
                chk_manual_entry_send_required.Checked = False
            End If


            '===========File Upload========
            If IIf(res("file_upload_auto_submit") Is System.DBNull.Value, "", res("file_upload_auto_submit").ToString()) = "Y" Then
                chk_file_upload_auto_submit.Checked = True
            Else
                chk_file_upload_auto_submit.Checked = False
            End If

            If IIf(res("file_upload_allow_transaction_edit") Is System.DBNull.Value, "", res("file_upload_allow_transaction_edit").ToString()) = "Y" Then
                chk_file_upload_allow_transaction_edit.Checked = True
            Else
                chk_file_upload_allow_transaction_edit.Checked = False
            End If

            If IIf(res("file_upload_approve_required") Is System.DBNull.Value, "", res("file_upload_approve_required").ToString()) = "Y" Then
                chk_file_upload_approve_required.Checked = True
            Else
                chk_file_upload_approve_required.Checked = False
            End If

            If IIf(res("file_upload_verify_required") Is System.DBNull.Value, "", res("file_upload_verify_required").ToString()) = "Y" Then
                chk_file_upload_verify_required.Checked = True
            Else
                chk_file_upload_verify_required.Checked = False
            End If

            If IIf(res("file_upload_send_required") Is System.DBNull.Value, "", res("file_upload_send_required").ToString()) = "Y" Then
                chk_file_upload_send_required.Checked = True
            Else
                chk_file_upload_send_required.Checked = False
            End If

            'If IIf(res("file_upload_action") Is System.DBNull.Value, "", res("file_upload_action").ToString()) = "Y" Then
            '    chk_file_upload_action.Checked = True
            'Else
            '    chk_file_upload_action.Checked = False
            'End If
            'file_upload_action
            cbo_file_upload_action.Text = IIf(res("file_upload_action") Is System.DBNull.Value, "", res("file_upload_action").ToString())

            '==========Standing Instruction-Execute==========
            If IIf(res("si_submit_required") Is System.DBNull.Value, "", res("si_submit_required").ToString()) = "Y" Then
                chk_si_submit_required.Checked = True
            Else
                chk_si_submit_required.Checked = False
            End If

            If IIf(res("si_approve_required") Is System.DBNull.Value, "", res("si_approve_required").ToString()) = "Y" Then
                chk_si_approve_required.Checked = True
            Else
                chk_si_approve_required.Checked = False
            End If

            If IIf(res("si_verify_required") Is System.DBNull.Value, "", res("si_verify_required").ToString()) = "Y" Then
                chk_si_verify_required.Checked = True
            Else
                chk_si_verify_required.Checked = False
            End If

            If IIf(res("si_send_required") Is System.DBNull.Value, "", res("si_send_required").ToString()) = "Y" Then
                chk_si_send_required.Checked = True
            Else
                chk_si_send_required.Checked = False
            End If

            'If IIf(res("si_auto_approve") Is System.DBNull.Value, "", res("si_auto_approve").ToString()) = "Y" Then
            '    chk_si_auto_approve.Checked = True
            'Else
            '    chk_si_auto_approve.Checked = False
            'End If

            '============Validation===============

            If IIf(res("validation_user_product") Is System.DBNull.Value, "", res("validation_user_product").ToString()) = "Y" Then
                chk_validation_user_product.Checked = True
            Else
                chk_validation_user_product.Checked = False
            End If

            If IIf(res("validation_product_account") Is System.DBNull.Value, "", res("validation_product_account").ToString()) = "Y" Then
                chk_validation_product_account.Checked = True
            Else
                chk_validation_product_account.Checked = False
            End If

            If IIf(res("validation_user_account") Is System.DBNull.Value, "", res("validation_user_account").ToString()) = "Y" Then
                chk_validation_user_account.Checked = True
            Else
                chk_validation_user_account.Checked = False
            End If

            If IIf(res("validation_product_beneficiary") Is System.DBNull.Value, "", res("validation_product_beneficiary").ToString()) = "Y" Then
                chk_validation_product_beneficiary.Checked = True
            Else
                chk_validation_product_beneficiary.Checked = False
            End If

            If IIf(res("validation_zero_proofing") Is System.DBNull.Value, "", res("validation_zero_proofing").ToString()) = "Y" Then
                chk_validation_zero_proofing.Checked = True
            Else
                chk_validation_zero_proofing.Checked = False
            End If

            'If IIf(res("validation_scrap_if_not_auth_or_send") Is System.DBNull.Value, "", res("validation_scrap_if_not_auth_or_send").ToString()) = "Y" Then
            '    chk_validation_scrap_if_not_auth_or_send.Checked = True
            'Else
            '    chk_validation_scrap_if_not_auth_or_send.Checked = False
            'End If
            txt_validation_scrap_if_not_auth_or_send.Text = IIf(res("validation_scrap_if_not_auth_or_send") Is System.DBNull.Value, "", res("validation_scrap_if_not_auth_or_send").ToString())
            txt_validation_notify_user_of_scrap_before_day.Text = IIf(res("validation_notify_user_of_scrap_before_day") Is System.DBNull.Value, "", res("validation_notify_user_of_scrap_before_day").ToString())
            cbo_default_charge_account.Text = IIf(res("default_charge_account") Is System.DBNull.Value, "", res("default_charge_account").ToString())
            '==============Payee Notofication================
            If IIf(res("payee_notofication_fax") Is System.DBNull.Value, "", res("payee_notofication_fax").ToString()) = "Y" Then
                chk_payee_notofication_fax.Checked = True
            Else
                chk_payee_notofication_fax.Checked = False
            End If

            If IIf(res("payee_notofication_email") Is System.DBNull.Value, "", res("payee_notofication_email").ToString()) = "Y" Then
                chk_payee_notofication_email.Checked = True
            Else
                chk_payee_notofication_email.Checked = False
            End If

            txt_product_template_new.Text = IIf(res("product_template_new") Is System.DBNull.Value, "", res("product_template_new").ToString())
            txt_charge_template_new.Text = IIf(res("charge_template_new") Is System.DBNull.Value, "", res("charge_template_new").ToString())

            Call Show_Account()
            Call Show_pickup_location()

            'rad_yes
            If IIf(res("valid_flag") Is System.DBNull.Value, "", res("valid_flag").ToString()) = "Y" Then
                rad_yes.Checked = True
            Else
                rad_no.Checked = True
            End If

            'chk_confidenfial_flag
            If IIf(res("confidenfial_flag") Is System.DBNull.Value, "", res("confidenfial_flag").ToString()) = "Y" Then
                chk_confidenfial_flag.Checked = True
            Else
                chk_confidenfial_flag.Checked = False
            End If

            'Debit account
            If IIf(res("Debit_Account") Is System.DBNull.Value, "", res("Debit_Account").ToString()) = "Instrument Level" Then
                rdInstrument.Checked = True
            Else
                rdBatch.Checked = True
            End If

        End If
        res.Close()
        res = Nothing

    End Sub


    Private Sub ShowDuplicationBankProduct_UDE()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = " SELECT * FROM [TB_DEAL_PRODUCT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
        strSQL += " and ude_product ='" + cbo_ude_product.Text.Replace("'", "''") + "' "
        strSQL += " and bank_product ='" + cbo_bank_product.Text.Replace("'", "''") + "' "

        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then

           

            res.Read()
            txt_my_product.Enabled = False

           

            txt_rule_priority.Text = IIf(res("rule_priority") Is System.DBNull.Value, "", res("rule_priority").ToString())
            txt_rule_code.Text = IIf(res("rule_code") Is System.DBNull.Value, "", res("rule_code").ToString())
            cbo_arrangement.Text = IIf(res("arrangement") Is System.DBNull.Value, "", res("arrangement").ToString())
            txt_per_txm_max_amt.Text = IIf(res("per_txm_max_amt") Is System.DBNull.Value, "", res("per_txm_max_amt").ToString())
            txt_per_txm_max_amt.Text = CDbl(txt_per_txm_max_amt.Text).ToString("###,##0.0")

            'txt_account_number.Text = IIf(res("account_number") Is System.DBNull.Value, "", res("account_number").ToString())

            'cbo_pickup_location.Text = IIf(res("pickup_location_desc") Is System.DBNull.Value, "", res("pickup_location_desc").ToString()) & " || " & IIf(res("pickup_location") Is System.DBNull.Value, "", res("pickup_location").ToString()) 'cbo_pickup_location.FindString(IIf(res("pickup_location_desc") Is System.DBNull.Value, "", res("pickup_location_desc").ToString()))

            cbo_product_template.Text = IIf(res("product_template") Is System.DBNull.Value, "", res("product_template").ToString())
            cbo_charge_template.Text = IIf(res("charge_template") Is System.DBNull.Value, "", res("charge_template").ToString())
            cbo_default_charge_account.Text = IIf(res("default_charge_account") Is System.DBNull.Value, "", res("default_charge_account").ToString())


            txt_product_name.Enabled = False
            txt_rule_priority.Enabled = False
            txt_rule_code.Enabled = False
            cbo_arrangement.Enabled = False
            txt_per_txm_max_amt.Enabled = False
            cbo_product_template.Enabled = False
            cbo_charge_template.Enabled = False
            cbo_default_charge_account.Enabled = False

        End If
        res.Close()
        res = Nothing

    End Sub

    Private Sub Show_Account()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_DEAL_PRODUCT_ACCOUNT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and my_product='" + txt_my_product.Text.Replace("'", "''") + "' "
        strSQL += vbCrLf & " AND bank_product= '" + cbo_bank_product.Text.Replace("''", "'") + "'  "

        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            While (res.Read())

                Dim i As Integer = 0
                For i = 0 To lst_account.Items.Count - 1
                    'lst_account.Items(i).ToString 
                    If lst_account.Items(i).ToString = res("account_number").ToString Then
                        lst_account.SetItemChecked(i, False)
                    End If
                Next

            End While
        End If

    End Sub

    Private Sub Show_pickup_location()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_DEAL_PRODUCT_PICKUP_LOCATION] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "' " ' and my_product='" + txt_my_product.Text.Replace("'", "''") + "' "
        strSQL += vbCrLf & " AND my_product= '" + txt_my_product.Text.Replace("''", "'") + "'  "
        'my_product='" + txt_my_product.Text.Replace("''", "'") + "'

        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            While (res.Read())

                Dim i As Integer = 0
                For i = 0 To lst_pickup_location.Items.Count - 1
                    If LTrim(RTrim(Split(lst_pickup_location.Items(i).ToString, "||")(0))) = res("pickup_location_desc").ToString Then
                        lst_pickup_location.SetItemChecked(i, True)
                    End If
                Next

            End While
        End If

    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click
        Dim strErr As String = ""
        strErr = ValidationData()

        If strErr <> "" Then
            MessageBox.Show(strErr)
            Exit Sub
        End If

        If txt_revision_code.Text = "Rev0009" Then
            Call ChangeClearingLocation()
            'Me.Close()
            'Exit Sub
        Else
            Call SaveData()
        End If

    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""


        If txt_product_name.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [My Product Name]"
        End If
        If cbo_ude_product.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [UDE Product]"
        End If
        If cbo_bank_product.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Bank Product]"
        End If
        If cbo_arrangement.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Arrangement]"
        End If

        If txt_per_txm_max_amt.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Per Txn Max Amt]"
        End If

        If txt_rule_priority.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rule Priority]"
        End If

        If txt_rule_code.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rule Code]"
        End If


        'If txt_account_number.Text = "" Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Account Number]"
        'End If
        'If cbo_pickup_location.Text = "" Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Pickup Location]"
        'End If
        If cbo_product_template.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Product Template]"
        End If
        'If cbo_charge_template.Text = "" Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Charge Template]"
        'End If
        If cbo_beneficiary_type.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Beneficiary Type]"
        End If
        If cbo_my_product_usage.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [My Product Usage]"
        End If
        If cbo_auth_type.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Auth Type]"
        End If
        If cbo_auth_level.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Auth Level]"
        End If
        If cbo_adhoc_allow.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Adhoc Allow]"
        End If
        'If txt_beneficiary_advice_detail.Text = "" Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Beneficiary Advice Detail]"
        'End If
        '===txt_validation_notify_user_of_scrap_before_day=

        If txt_validation_scrap_if_not_auth_or_send.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Scrap if not Auth or Send*]"
        End If

        If txt_validation_notify_user_of_scrap_before_day.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Notify user of scrap before (day)]"
        End If

        '==================account==============
        Dim i_lst_account As Integer = 0

        For Each Entry In lst_account.CheckedItems
            ' MessageBox.Show(lst_account.ToString())
            i_lst_account += 1
        Next

        Dim i_lst_pickup_location As Integer = 0

        For Each Entry In lst_pickup_location.CheckedItems
            ' MessageBox.Show(lst_account.ToString())
            i_lst_pickup_location += 1
        Next


        Return strErr
    End Function

    Private Sub ChangeClearingLocation()
        Dim strSQL As String = ""
        Dim strRevDate As String = Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)

        If txt_revision_code.Text = "Rev0009" Then

            strSQL = "select my_product from TB_DEAL_PRODUCT where company_id = '" & txt_company_id.Text _
                                    & "' and bank_product = '" & txt_my_product.Text & "'"

            If conn.HasRows(strSQL) Then

                strSQL = vbCrLf & " delete from TB_DEAL_PRODUCT_PICKUP_LOCATION WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "' and my_product='" + txt_my_product.Text.Replace("''", "'") + "'"

                For Each Entry In lst_pickup_location.CheckedItems
                    ' MessageBox.Show(lst_account.ToString())
                    strSQL += vbCrLf & "insert into TB_DEAL_PRODUCT_PICKUP_LOCATION ( company_id,my_product,pickup_location,pickup_location_desc,revision_code,revision_desc,revision_date ) values ( "
                    strSQL += vbCrLf & "'" + txt_company_id.Text.Replace("''", "'") + "' " 'company_id
                    strSQL += vbCrLf & " ,'" + txt_my_product.Text.Replace("''", "'") + "' " 'my_product
                    strSQL += vbCrLf & " ,'" + RTrim(LTrim(Split(Entry.ToString, "||")(1))).Replace("''", "'") + "' " 'pickup_location
                    strSQL += vbCrLf & " ,'" + RTrim(LTrim(Split(Entry.ToString, "||")(0))).Replace("''", "'") + "' " 'pickup_location_desc
                    'revision_code,revision_desc,revision_date
                    strSQL += vbCrLf & ",'" + txt_revision_code.Text.Replace("''", "'") + "' "
                    strSQL += vbCrLf & ",'" + txt_revision_desc.Text.Replace("''", "'") + "' "
                    strSQL += vbCrLf & ", '" & strRevDate & "'"

                    strSQL += vbCrLf & " ) "

                    ' strProduct += IIf(strProduct = "", "", ",") & RTrim(LTrim(Split(Entry.ToString, "||")(1))).Replace("''", "'")

                    '    i_lst_account += 1
                Next

                strSQL += vbCrLf & "update [TB_DEAL_PRODUCT] set "
                strSQL += vbCrLf & "[valid_flag]"
                If rad_yes.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If

                strSQL += vbCrLf & " ,[revision_code]"
                strSQL += vbCrLf & "=N'" & txt_revision_code.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[revision_desc]"
                strSQL += vbCrLf & "=N'" & txt_revision_desc.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[revision_date]"
                strSQL += vbCrLf & "= '" & strRevDate & "'"
                strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and my_product='" + txt_my_product.Text.Replace("'", "''") + "' "

                strSQL += vbCrLf & " DELETE FROM dbo.TB_REVISION_HISTORY WHERE company_id='" + txt_company_id.Text.Replace("'", "''") + "'"
                ' strSQL += vbCrLf & "   and revision_code='" + txt_revision_code.Text.Replace("'", "''") + "' "
                strSQL += vbCrLf & "   and revision_code in ('Rev0009') "

                strSQL += vbCrLf & " insert into  TB_REVISION_HISTORY (company_id,revision_code,revision_desc,revision_date)"
                'company_id,revision_code,revision_desc,revision_date,revision_reason
                strSQL += vbCrLf & " select distinct company_id,revision_code,revision_desc,revision_date from  TB_DEAL_PRODUCT"
                strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  " 'and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "
                strSQL += vbCrLf & "   and revision_code in ('Rev0009') "

                conn.ExecuteNonQuery(strSQL)

                MsgBox("Save pickup location was successful.")
            Else

                MessageBox.Show("Product is not available !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        End If

    End Sub


    Private Sub SaveData()
        Dim strSQL As String = String.Empty
        Dim strErr As String = String.Empty
        Dim strRevDate As String = Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)

        Try

            conn = New CSQL
            conn.Connect()

            '========================add mode====================
            If strMODE.ToUpper = "ADD" Then

                'strSQL = ""
                'strSQL += " SELECT * FROM [TB_DEAL_PRODUCT] "
                'strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
                'strSQL += "  and my_product ='" + txt_my_product.Text.Replace("'", "''") + "' "
                ''  strSQL += "  and ude_product ='" + cbo_ude_product.Text.Replace("'", "''") + "' "

                'If conn.HasRows(strSQL) = True Then
                '    MessageBox.Show("Invalid [My Product Code] is duplicate.")
                '    Exit Sub
                'End If


                strSQL = ""
                strSQL += " SELECT * FROM [TB_DEAL_PRODUCT] "
                strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
                strSQL += "  and my_product ='" + txt_my_product.Text.Replace("'", "''") + "' "
                strSQL += "  and ude_product ='" + cbo_ude_product.Text.Replace("'", "''") + "' "
                strSQL += "  and bank_product ='" + cbo_bank_product.Text.Replace("'", "''") + "' "

                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid [My Product Code]/[UDE Product]/[Bank Product] is duplicate.")
                    Exit Sub
                End If

                Dim strValue As String = ""
                Dim strFiledname As String = ""

                '---------------key----------------
                strFiledname += vbCrLf & "[my_product]"
                strValue += vbCrLf & "N'" & txt_my_product.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[company_id]"
                strValue += vbCrLf & ",N'" & txt_company_id.Text.Replace("'", "''") & "'"

                '--------------data-------------
                strFiledname += vbCrLf & ",[product_name]"
                strValue += vbCrLf & ",N'" & txt_product_name.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[ude_product]"
                strValue += vbCrLf & ",N'" & cbo_ude_product.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[bank_product]"
                strValue += vbCrLf & ",N'" & cbo_bank_product.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[rule_priority]"
                strValue += vbCrLf & ",N'" & txt_rule_priority.Text.Replace("'", "''") & "'"


                strFiledname += vbCrLf & ",[rule_code]"
                strValue += vbCrLf & ",N'" & txt_rule_code.Text.Replace("'", "''") & "'"


                strFiledname += vbCrLf & ",[arrangement]"
                strValue += vbCrLf & ",N'" & cbo_arrangement.Text.Replace("'", "''") & "'"
                'txt_days_period
                strFiledname += vbCrLf & ",[days_period]"
                strValue += vbCrLf & ",N'" & txt_days_period.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[per_txm_max_amt]"
                strValue += vbCrLf & ",N'" & txt_per_txm_max_amt.Text.Replace(",", "") & "'"

                'strFiledname += vbCrLf & ",[account_number]"
                'strValue += vbCrLf & ",N'" & txt_account_number.Text.Replace("'", "''") & "'"

                'strFiledname += vbCrLf & ",[pickup_location]"
                'strValue += vbCrLf & ",N'" & LTrim(RTrim(Split(cbo_pickup_location.Text, "||")(1).Replace("'", "''"))) & "'"

                'strFiledname += vbCrLf & ",[pickup_location_desc]"
                'strValue += vbCrLf & ",N'" & LTrim(RTrim(Split(cbo_pickup_location.Text, "||")(0).Replace("'", "''"))) & "'"


                strFiledname += vbCrLf & ",[product_template]"
                strValue += vbCrLf & ",N'" & cbo_product_template.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[charge_template]"
                strValue += vbCrLf & ",N'" & cbo_charge_template.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[beneficiary_type]"
                strValue += vbCrLf & ",N'" & cbo_beneficiary_type.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[my_product_usage]"
                strValue += vbCrLf & ",N'" & cbo_my_product_usage.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[auth_type]"
                strValue += vbCrLf & ",N'" & cbo_auth_type.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[auth_level]"
                strValue += vbCrLf & ",N'" & cbo_auth_level.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[adhoc_allow]"
                strValue += vbCrLf & ",N'" & cbo_adhoc_allow.Text.Replace("'", "''") & "'"

                ' strFiledname += vbCrLf & ",[beneficiary_advice_detail]"
                'strValue += vbCrLf & ",N'" & txt_beneficiary_advice_detail.Text.Replace("'", "''") & "'"

                '==============Manual Entry================

                strFiledname += vbCrLf & ",[manual_entry_approve_required]"
                If chk_manual_entry_approve_required.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[manual_entry_verify_required]"
                If chk_manual_entry_verify_required.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[manual_entry_send_required]"
                If chk_manual_entry_send_required.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                '=============File Upload==============
                strFiledname += vbCrLf & ",[file_upload_auto_submit]"
                If chk_file_upload_auto_submit.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[file_upload_allow_transaction_edit]"
                If chk_file_upload_allow_transaction_edit.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[file_upload_approve_required]"
                If chk_file_upload_approve_required.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[file_upload_verify_required]"
                If chk_file_upload_verify_required.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[file_upload_send_required]"
                If chk_file_upload_send_required.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[file_upload_action]"
                strValue += vbCrLf & ",N'" & cbo_file_upload_action.Text.Replace("'", "''") & "'"
                'If chk_file_upload_action.Checked = True Then
                '    strValue += vbCrLf & ",'Y'"
                'Else
                '    strValue += vbCrLf & ",'N'"
                'End If
                '===========Standing Instruction-Execute==============
                strFiledname += vbCrLf & ",[si_submit_required]"
                If chk_si_submit_required.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[si_approve_required]"
                If chk_si_approve_required.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[si_verify_required]"
                If chk_si_verify_required.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[si_send_required]"
                If chk_si_send_required.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                ' strFiledname += vbCrLf & ",[si_auto_approve]"
                'If chk_si_auto_approve.Checked = True Then
                '    strValue += vbCrLf & ",'Y'"
                'Else
                '    strValue += vbCrLf & ",'N'"
                'End If
                '=======Validation=========
                strFiledname += vbCrLf & ",[validation_user_product]"
                If chk_validation_user_product.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[validation_product_account]"
                If chk_validation_product_account.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[validation_user_account]"
                If chk_validation_user_account.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[validation_product_beneficiary]"
                If chk_validation_product_beneficiary.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[validation_zero_proofing]"
                If chk_validation_zero_proofing.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If

                'strFiledname += vbCrLf & ",[validation_scrap_if_not_auth_or_send]"
                'If chk_validation_scrap_if_not_auth_or_send.Checked = True Then
                '    strValue += vbCrLf & ",'Y'"
                'Else
                '    strValue += vbCrLf & ",'N'"
                'End If
                'txt_validation_scrap_if_not_auth_or_send
                strFiledname += vbCrLf & ",[validation_scrap_if_not_auth_or_send]"
                strValue += vbCrLf & ",N'" & txt_validation_scrap_if_not_auth_or_send.Text.Replace("'", "''") & "'"


                strFiledname += vbCrLf & ",[validation_notify_user_of_scrap_before_day]"
                strValue += vbCrLf & ",N'" & txt_validation_notify_user_of_scrap_before_day.Text.Replace("'", "''") & "'"
                'cbo_default_charge_account
                strFiledname += vbCrLf & ",[default_charge_account]"
                strValue += vbCrLf & ",N'" & cbo_default_charge_account.Text.Replace("'", "''") & "'"

                '========Payee Notofication==========
                strFiledname += vbCrLf & ",[payee_notofication_fax]"
                If chk_payee_notofication_fax.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If
                strFiledname += vbCrLf & ",[payee_notofication_email]"
                If chk_payee_notofication_email.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If

                'chk_confidenfial_flag
                strFiledname += vbCrLf & ",[confidenfial_flag]"
                If chk_confidenfial_flag.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If


                'txt_product_template_new
                strFiledname += vbCrLf & ",[product_template_new]"
                strValue += vbCrLf & ",N'" & txt_product_template_new.Text.Replace("'", "''") & "'"
                'txt_charge_template_new
                strFiledname += vbCrLf & ",[charge_template_new]"
                strValue += vbCrLf & ",N'" & txt_charge_template_new.Text.Replace("'", "''") & "'"


                strFiledname += vbCrLf & ",[revision_code]"
                strValue += vbCrLf & ",N'" & txt_revision_code.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[revision_desc]"
                strValue += vbCrLf & ",N'" & txt_revision_desc.Text.Replace("'", "''") & "'"


                strFiledname += vbCrLf & ",[revision_date]"
                strValue += vbCrLf & ", '" & strRevDate & "'"

                If rdInstrument.Checked Then

                    strFiledname += vbCrLf & ",[Debit_Account]"
                    strValue += vbCrLf & ", 'Instrument Level'"
                Else
                    strFiledname += vbCrLf & ",[Debit_Account]"
                    strValue += vbCrLf & ", 'Batch Level'"
                End If

                strSQL = ""
                strSQL += vbCrLf & "insert into [TB_DEAL_PRODUCT]  "
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                strErr = conn.ExecuteNonQuery(strSQL)

            End If ' If strMODE.ToUpper = "ADD" Then



            '========================edit mode====================


            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [TB_DEAL_PRODUCT] set "


                '--------------data-------------
                strSQL += vbCrLf & "[product_name]"
                strSQL += vbCrLf & "=N'" & txt_product_name.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[ude_product]"
                strSQL += vbCrLf & "=N'" & cbo_ude_product.Text.Replace("'", "''") & "'"

                'strSQL += vbCrLf & ",[bank_product]"
                'strSQL += vbCrLf & "=N'" & cbo_bank_product.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[rule_priority]"
                strSQL += vbCrLf & "=N'" & txt_rule_priority.Text.Replace("'", "''") & "'"


                strSQL += vbCrLf & ",[rule_code]"
                strSQL += vbCrLf & "=N'" & txt_rule_code.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[arrangement]"
                strSQL += vbCrLf & "=N'" & cbo_arrangement.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[days_period]"
                strSQL += vbCrLf & "=N'" & txt_days_period.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[per_txm_max_amt]"
                strSQL += vbCrLf & "=N'" & txt_per_txm_max_amt.Text.Replace(",", "") & "'"

                'strSQL += vbCrLf & ",[account_number]"
                'strSQL += vbCrLf & "=N'" & txt_account_number.Text.Replace("'", "''") & "'"

                ' strSQL += vbCrLf & ",[pickup_location]"
                ' strSQL += vbCrLf & "=N'" & cbo_pickup_location.Text.Replace("'", "''") & "'"

                'strSQL += vbCrLf & ",[pickup_location]"
                'strSQL += vbCrLf & "=N'" & LTrim(RTrim(Split(cbo_pickup_location.Text, "||")(1).Replace("'", "''"))) & "'"

                'strSQL += vbCrLf & ",[pickup_location_desc]"
                'strSQL += vbCrLf & "=N'" & LTrim(RTrim(Split(cbo_pickup_location.Text, "||")(0).Replace("'", "''"))) & "'"


                strSQL += vbCrLf & ",[product_template]"
                strSQL += vbCrLf & "=N'" & cbo_product_template.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[charge_template]"
                strSQL += vbCrLf & "=N'" & cbo_charge_template.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[beneficiary_type]"
                strSQL += vbCrLf & "=N'" & cbo_beneficiary_type.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[my_product_usage]"
                strSQL += vbCrLf & "=N'" & cbo_my_product_usage.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[auth_type]"
                strSQL += vbCrLf & "=N'" & cbo_auth_type.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[auth_level]"
                strSQL += vbCrLf & "=N'" & cbo_auth_level.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[adhoc_allow]"
                strSQL += vbCrLf & "=N'" & cbo_adhoc_allow.Text.Replace("'", "''") & "'"

                'strSQL += vbCrLf & ",[beneficiary_advice_detail]"
                'strSQL += vbCrLf & "=N'" & txt_beneficiary_advice_detail.Text.Replace("'", "''") & "'"

                '==============Manual Entry================

                strSQL += vbCrLf & ",[manual_entry_approve_required]"
                If chk_manual_entry_approve_required.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[manual_entry_verify_required]"
                If chk_manual_entry_verify_required.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[manual_entry_send_required]"
                If chk_manual_entry_send_required.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If


                '=============File Upload==============
                strSQL += vbCrLf & ",[file_upload_auto_submit]"
                If chk_file_upload_auto_submit.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[file_upload_allow_transaction_edit]"
                If chk_file_upload_allow_transaction_edit.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[file_upload_approve_required]"
                If chk_file_upload_approve_required.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[file_upload_verify_required]"
                If chk_file_upload_verify_required.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[file_upload_send_required]"
                If chk_file_upload_send_required.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[file_upload_action]"
                strSQL += vbCrLf & "=N'" & cbo_file_upload_action.Text.Replace("'", "''") & "'"
                'If chk_file_upload_action.Checked = True Then
                '    strSQL += vbCrLf & "='Y'"
                'Else
                '    strSQL += vbCrLf & "='N'"
                'End If
                '===========Standing Instruction-Execute==============
                strSQL += vbCrLf & ",[si_submit_required]"
                If chk_si_submit_required.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[si_approve_required]"
                If chk_si_approve_required.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[si_verify_required]"
                If chk_si_verify_required.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[si_send_required]"
                If chk_si_send_required.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If

                'strSQL += vbCrLf & ",[si_auto_approve]"
                'If chk_si_auto_approve.Checked = True Then
                '    strSQL += vbCrLf & "='Y'"
                'Else
                '    strSQL += vbCrLf & "='N'"
                'End If
                '=======Validation=========
                strSQL += vbCrLf & ",[validation_user_product]"
                If chk_validation_user_product.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[validation_product_account]"
                If chk_validation_product_account.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[validation_user_account]"
                If chk_validation_user_account.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[validation_product_beneficiary]"
                If chk_validation_product_beneficiary.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[validation_zero_proofing]"
                If chk_validation_zero_proofing.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                ' strSQL += vbCrLf & ",[validation_scrap_if_not_auth_or_send]"
                'If chk_validation_scrap_if_not_auth_or_send.Checked = True Then
                '    strSQL += vbCrLf & "='Y'"
                'Else
                '    strSQL += vbCrLf & "='N'"
                'End If

                strSQL += vbCrLf & ",[validation_scrap_if_not_auth_or_send]"
                strSQL += vbCrLf & "=N'" & txt_validation_scrap_if_not_auth_or_send.Text.Replace("'", "''") & "'"


                strSQL += vbCrLf & ",[validation_notify_user_of_scrap_before_day]"
                strSQL += vbCrLf & "=N'" & txt_validation_notify_user_of_scrap_before_day.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[default_charge_account]"
                strSQL += vbCrLf & "=N'" & cbo_default_charge_account.Text.Replace("'", "''") & "'"


                '========Payee Notofication==========
                strSQL += vbCrLf & ",[payee_notofication_fax]"
                If chk_payee_notofication_fax.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If
                strSQL += vbCrLf & ",[payee_notofication_email]"
                If chk_payee_notofication_email.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If

                'chk_confidenfial_flag
                strSQL += vbCrLf & ",[confidenfial_flag]"
                If chk_confidenfial_flag.Checked = True Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If


                'txt_product_template_new
                strSQL += vbCrLf & ",[product_template_new]"
                strSQL += vbCrLf & "=N'" & txt_product_template_new.Text.Replace("'", "''") & "'"
                'txt_charge_template_new
                strSQL += vbCrLf & ",[charge_template_new]"
                strSQL += vbCrLf & "=N'" & txt_charge_template_new.Text.Replace("'", "''") & "'"


                strSQL += vbCrLf & ",[revision_code]"
                strSQL += vbCrLf & "=N'" & txt_revision_code.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[revision_desc]"
                strSQL += vbCrLf & "=N'" & txt_revision_desc.Text.Replace("'", "''") & "'"


                strSQL += vbCrLf & ",[revision_date]"
                strSQL += vbCrLf & "= '" & strRevDate & "'"


                If rdInstrument.Checked Then

                    strSQL += vbCrLf & ",[Debit_Account]"
                    strSQL += vbCrLf & "= 'Instrument Level'"
                Else

                    strSQL += vbCrLf & ",[Debit_Account]"
                    strSQL += vbCrLf & "= 'Batch Level'"
                End If

                '---- ==============================

                strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "' "
                strSQL += vbCrLf & "  and my_product='" + txt_my_product.Text.Replace("'", "''") + "' "
                strSQL += vbCrLf & " AND bank_product ='" + cbo_bank_product.Text.Replace("'", "''") + "'"

                'strSQL += vbCrLf & ",[bank_product]"
                'strSQL += vbCrLf & "=N'" & cbo_bank_product.Text.Replace("'", "''") & "'"

                strErr = conn.ExecuteNonQuery(strSQL)

            End If ' If strMODE.ToUpper <> "ADD" Then

            ''***************************
            ''--- Checkpoint of Err
            ''***************************
            If Len(strErr) > 0 Then
                MessageBox.Show(strErr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Close()
                Exit Sub
            End If


            '==================account==============
            Dim i_lst_account As Integer = 0

            strSQL = ""
            strSQL += vbCrLf & " delete from TB_DEAL_PRODUCT_ACCOUNT "
            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'"
            strSQL += vbCrLf & " AND my_product= '" + txt_my_product.Text.Replace("''", "'") + "'  "
            strSQL += vbCrLf & " AND bank_product= '" + cbo_bank_product.Text.Replace("''", "'") + "'  "
            'bank_product

            Dim strAccount As String = ""

            For Each Entry In lst_account.CheckedItems
                ' MessageBox.Show(lst_account.ToString())
                strSQL += vbCrLf & "insert into TB_DEAL_PRODUCT_ACCOUNT ( company_id,my_product,account_number,bank_product ) values ( "
                strSQL += vbCrLf & "'" + txt_company_id.Text.Replace("''", "'") + "' " 'company_id
                strSQL += vbCrLf & " ,'" + txt_my_product.Text.Replace("''", "'") + "' " 'my_product
                strSQL += vbCrLf & " ,'" + Entry.ToString.Replace("''", "'") + "' " 'account_number
                strSQL += vbCrLf & " ,'" + cbo_bank_product.Text.Replace("''", "'") + "' "
                strSQL += vbCrLf & " ) "

                strAccount += IIf(strAccount = "", "", ",") & Entry.ToString
                '  i_lst_account += 1
            Next

            strSQL += vbCrLf & " update TB_DEAL_PRODUCT set "
            strSQL += vbCrLf & " account_number='" & strAccount.Replace("'", "''") & "'"
            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
            strSQL += vbCrLf & "   and my_product='" + txt_my_product.Text.Replace("'", "''") + "' "
            strSQL += vbCrLf & " AND bank_product= '" + cbo_bank_product.Text.Replace("''", "'") + "'  "


            conn.ExecuteNonQuery(strSQL)





            strSQL = ""
            strSQL += vbCrLf & " delete from TB_DEAL_PRODUCT_PICKUP_LOCATION "
            strSQL += vbCrLf & "  WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "' "
            strSQL += vbCrLf & "   and my_product='" + txt_my_product.Text.Replace("''", "'") + "'"
            strSQL += vbCrLf & "   and bank_product='" + cbo_bank_product.Text.Replace("''", "'") + "'"

            Dim strProduct As String = ""

            For Each Entry In lst_pickup_location.CheckedItems
                ' MessageBox.Show(lst_account.ToString())
                strSQL += vbCrLf & "insert into TB_DEAL_PRODUCT_PICKUP_LOCATION ( company_id,my_product,pickup_location,pickup_location_desc,bank_product ) values ( "
                strSQL += vbCrLf & "'" + txt_company_id.Text.Replace("''", "'") + "' " 'company_id
                strSQL += vbCrLf & " ,'" + txt_my_product.Text.Replace("''", "'") + "' " 'my_product
                strSQL += vbCrLf & " ,'" + RTrim(LTrim(Split(Entry.ToString, "||")(1))).Replace("''", "'") + "' " 'pickup_location
                strSQL += vbCrLf & " ,'" + RTrim(LTrim(Split(Entry.ToString, "||")(0))).Replace("''", "'") + "' " 'pickup_location_desc
                strSQL += vbCrLf & " ,'" + cbo_bank_product.Text.Replace("''", "'") + "' "
                strSQL += vbCrLf & " ) "

                strProduct += IIf(strProduct = "", "", ",") & RTrim(LTrim(Split(Entry.ToString, "||")(1))).Replace("''", "'")

                '    i_lst_account += 1
            Next

            strSQL += vbCrLf & " update TB_DEAL_PRODUCT set "
            strSQL += vbCrLf & " pickup_location='" & strProduct.Replace("'", "''") & "'"
            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and my_product='" + txt_my_product.Text.Replace("'", "''") + "' "


            conn.ExecuteNonQuery(strSQL)


            ''-- Tum; 07-Aug-2014: 
            '','Rev0023','Rev0024'
            'If txt_revision_code.Text <> "Rev0023" And txt_revision_code.Text <> "Rev0024" Then
            '    strSQL = ""

            '    strSQL += vbCrLf & "update [TB_DEAL_PRODUCT] set "
            '    strSQL += vbCrLf & "[valid_flag]"
            '    If rad_yes.Checked = True Then
            '        strSQL += vbCrLf & "='Y'"
            '    Else
            '        strSQL += vbCrLf & "='N'"
            '    End If

            '    strSQL += vbCrLf & " ,[revision_code]"
            '    strSQL += vbCrLf & "=N'" & txt_revision_code.Text.Replace("'", "''") & "'"

            '    strSQL += vbCrLf & ",[revision_desc]"
            '    strSQL += vbCrLf & "=N'" & txt_revision_desc.Text.Replace("'", "''") & "'"

            '    strSQL += vbCrLf & ",[revision_date]"
            '    strSQL += vbCrLf & "=getdate()"

            '    strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and my_product='" + txt_my_product.Text.Replace("'", "''") + "' "

            '    strSQL += vbCrLf & " DELETE FROM dbo.TB_REVISION_HISTORY WHERE company_id='" + txt_company_id.Text.Replace("'", "''") + "'"
            '    ' strSQL += vbCrLf & "   and revision_code='" + txt_revision_code.Text.Replace("'", "''") + "' "
            '    strSQL += vbCrLf & "   and revision_code in ('Rev0010','Rev0011','Rev0012','Rev0013','Rev0014') "

            '    strSQL += vbCrLf & " insert into  TB_REVISION_HISTORY (company_id,revision_code,revision_desc,revision_date)"
            '    'company_id,revision_code,revision_desc,revision_date,revision_reason
            '    strSQL += vbCrLf & " select distinct company_id,revision_code,revision_desc,revision_date from  TB_DEAL_PRODUCT"
            '    strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  " 'and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "
            '    strSQL += vbCrLf & "   and revision_code in ('Rev0010','Rev0011','Rev0012','Rev0013','Rev0014') "

            '    conn.ExecuteNonQuery(strSQL)

            'End If

            'If txt_revision_code.Text = "Rev0023" Or txt_revision_code.Text = "Rev0024" Then
            '    Dim strCode As String = txt_revision_code.Text
            '    strSQL = ""

            '    strSQL += vbCrLf & "update [TB_DEAL_PRODUCT] set "
            '    strSQL += vbCrLf & "[valid_flag]"
            '    If rad_yes.Checked = True Then
            '        strSQL += vbCrLf & "='Y'"
            '    Else
            '        strSQL += vbCrLf & "='N'"
            '    End If

            '    strSQL += vbCrLf & " ,[revision_code_" & strCode & "]"
            '    strSQL += vbCrLf & "=N'" & txt_revision_code.Text.Replace("'", "''") & "'"

            '    strSQL += vbCrLf & ",[revision_desc_" & strCode & "]"
            '    strSQL += vbCrLf & "=N'" & txt_revision_desc.Text.Replace("'", "''") & "'"

            '    strSQL += vbCrLf & ",[revision_date_" & strCode & "]"
            '    strSQL += vbCrLf & "=getdate()"

            '    strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and my_product='" + txt_my_product.Text.Replace("'", "''") + "' "

            '    strSQL += vbCrLf & " DELETE FROM dbo.TB_REVISION_HISTORY WHERE company_id='" + txt_company_id.Text.Replace("'", "''") + "'"
            '    ' strSQL += vbCrLf & "   and revision_code='" + txt_revision_code.Text.Replace("'", "''") + "' "
            '    strSQL += vbCrLf & "   and revision_code in ('" & strCode & "') "

            '    strSQL += vbCrLf & " insert into  TB_REVISION_HISTORY (company_id,revision_code,revision_desc,revision_date)"
            '    'company_id,revision_code,revision_desc,revision_date,revision_reason
            '    strSQL += vbCrLf & " select distinct company_id,revision_code_" & strCode & ",revision_desc_" & strCode & ",revision_date_" & strCode & " from  TB_DEAL_PRODUCT"
            '    strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  " 'and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "
            '    strSQL += vbCrLf & "   and revision_code_" & strCode & " in ('" & strCode & "') "

            '    conn.ExecuteNonQuery(strSQL)
            'End If

            MsgBox("SaveData was successful.")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Frm_DealSummary_Product_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FillComboALL()
        Dim i As Integer
        '===================
        cbo_ude_product.Items.Clear()
        cbo_ude_product.Items.Add("UDEBNE")
        cbo_ude_product.Items.Add("UDECOC")
        cbo_ude_product.Items.Add("UDECOE")
        cbo_ude_product.Items.Add("UDEDCT")
        cbo_ude_product.Items.Add("UDEFTL")
        cbo_ude_product.Items.Add("UDEFTR")
        cbo_ude_product.Items.Add("UDEMCS")
        cbo_ude_product.Items.Add("UDEMCL")
        cbo_ude_product.Items.Add("UDEPCT")
        cbo_ude_product.Items.Add("UDEPCL")
        cbo_ude_product.Items.Add("")

        cbo_bank_product.Items.Clear()
        cbo_bank_product.Items.Add("BNE")
        cbo_bank_product.Items.Add("COC")
        cbo_bank_product.Items.Add("COE")
        cbo_bank_product.Items.Add("DCT")
        cbo_bank_product.Items.Add("FTL")
        cbo_bank_product.Items.Add("FTR")
        cbo_bank_product.Items.Add("MCS")
        cbo_bank_product.Items.Add("MCL")
        cbo_bank_product.Items.Add("PCT")
        cbo_bank_product.Items.Add("PCL")
        cbo_bank_product.Items.Add("")
        'cbo_arrangement
        cbo_arrangement.Items.Clear()
        cbo_arrangement.Items.Add("D+0")
        cbo_arrangement.Items.Add("D-1")
        cbo_arrangement.Items.Add("D-2")

        Dim strSQL As String = ""

        'strSQL = ""
        'strSQL += vbCrLf & " SELECT isnull(PICKUP_LOCATION_DESCRIPTION,'') + ' || ' + isnull(PICKUP_LOCATION,'') + '' as pickup  "
        'strSQL += vbCrLf & " FROM dbo.PICKUP_LOCATION_MST "
        'strSQL += vbCrLf & " order by PICKUP_LOCATION_DESCRIPTION"
        'conn.Fill_ComboBox(strSQL, lst_pickup_location)

        strSQL = " SELECT account_number from dbo.TB_DEAL_ACCOUNT where company_id ='" & txt_company_id.Text.Replace("'", "''") & "' and payment='Y' and set_as_debit_and_charge_at='Y' order by account_number "
        conn.Fill_ComboBox(strSQL, lst_account)
        'cbo_default_charge_account
        If strMODE.ToUpper = "ADD" Then

            For i = 0 To lst_account.Items.Count - 1
                lst_account.SetItemChecked(i, True)
            Next
        End If

        strSQL = "SELECT account_number from  dbo.TB_DEAL_ACCOUNT   where company_id ='" & txt_company_id.Text.Replace("'", "''") & "'  and set_as_charge_account='Y' group by account_number ORDER BY account_number "
        conn.Fill_ComboBox(strSQL, cbo_default_charge_account)


        ' cbo_beneficiary_type.Items.Clear()
        ' If cbo_ude_product.Text = "" Or cbo_ude_product.Text = "UDEDCT" Or cbo_ude_product.Text = "UDEFTL" _
        'Or cbo_ude_product.Text = "UDEFTR" Or cbo_ude_product.Text = "UDEPCT" Then
        '     cbo_beneficiary_type.Items.Add("Own Account")
        '     cbo_beneficiary_type.Items.Add("Group Account")

        ' End If
        ' cbo_beneficiary_type.Items.Add("Others")
        ' cbo_beneficiary_type.Items.Add("")
        ' cbo_beneficiary_type.Text = "Others"

        Call FillComboByProduct()


        cbo_my_product_usage.Items.Clear()
        cbo_my_product_usage.Items.Add("QuickPay")
        cbo_my_product_usage.Items.Add("Batch Payment")
        cbo_my_product_usage.Text = "Batch Payment"

        'cbo_auth_type
        '- My Product
        '- Account
        '- Maker Checker
        cbo_auth_type.Items.Clear()
        cbo_auth_type.Items.Add("My Product")
        cbo_auth_type.Items.Add("Account")
        cbo_auth_type.Items.Add("Maker Checker")
        cbo_auth_type.Text = "My Product"

        'cbo_auth_level
        '- Instrument Level
        '- Batch Level
        cbo_auth_level.Items.Clear()
        cbo_auth_level.Items.Add("Instrument Level")
        cbo_auth_level.Items.Add("Batch Level")
        cbo_auth_level.Text = "Batch Level"

        'cbo_adhoc_allow
        cbo_adhoc_allow.Items.Clear()
        cbo_adhoc_allow.Items.Add("Allowed")
        cbo_adhoc_allow.Items.Add("Not Allowed")
        cbo_adhoc_allow.Text = "Allowed"


        '        # แสดง Dropdown List
        '- Process all records in reject repair (default)
        '- Process OK records
        '- Reject entire file on error
        '- Process OK records with balance record in reject repair

        cbo_file_upload_action.Items.Clear()
        cbo_file_upload_action.Items.Add("Process all records in reject repair")
        cbo_file_upload_action.Items.Add("Process OK records")
        cbo_file_upload_action.Items.Add("Reject entire file on error")
        cbo_file_upload_action.Items.Add("Process OK records with balance record in reject repair")

        cbo_file_upload_action.Text = "Process all records in reject repair"

    End Sub


    Private Sub FillComboByProduct()
        Dim strSQL As String = ""
        Dim mCrit As String = ""

        If strMODE.ToUpper = "ADD" Then
            If cbo_bank_product.Text <> "" Then
                If InStr("BNE,DCT,MCS,MCL,PCL,PCT,COC,COE,FTL,FTR", cbo_bank_product.Text.Substring(cbo_bank_product.Text.Length - 3, 3)) > 0 Then
                    mCrit = " and TemplateCode like '" & cbo_bank_product.Text.Substring(cbo_bank_product.Text.Length - 3, 3) & "%' "
                End If
            End If
        End If

        If cbo_bank_product.Text = "COE" Or cbo_bank_product.Text = "COC" Then
            strSQL = ""
            strSQL += vbCrLf & " SELECT isnull(PICKUP_LOCATION_DESCRIPTION,'') + ' || ' + isnull(PICKUP_LOCATION,'') + '' as pickup  "
            strSQL += vbCrLf & " FROM dbo.PICKUP_LOCATION_MST "
            strSQL += vbCrLf & " where not ( PICKUP_LOCATION like 'FSI%' or PICKUP_LOCATION like 'UL%' )"
            strSQL += vbCrLf & " and PICKUP_LOCATION like '%" & cbo_bank_product.Text & "'"
            strSQL += vbCrLf & " order by PICKUP_LOCATION_DESCRIPTION"
            conn.Fill_ComboBox(strSQL, lst_pickup_location)
        End If


        strSQL = " select TemplateCode from dbo.PRD_Template where TemplateType='Single-Product' and StatusTemplate='Y' " & mCrit & " order BY TemplateCode"
        conn.Fill_ComboBox(strSQL, cbo_product_template)
        cbo_product_template.Items.Add("")

        strSQL = " select TemplateCode from dbo.PRD_Template where TemplateType='Product Charge' and StatusTemplate='Y'  " & mCrit & "  order BY TemplateCode"
        conn.Fill_ComboBox(strSQL, cbo_charge_template)
        cbo_charge_template.Items.Add("")

        cbo_beneficiary_type.Items.Clear()
        If cbo_ude_product.Text = "" Or cbo_ude_product.Text = "UDEDCT" Or cbo_ude_product.Text = "UDEFTL" _
       Or cbo_ude_product.Text = "UDEFTR" Or cbo_ude_product.Text = "UDEPCT" Then
            cbo_beneficiary_type.Items.Add("Own Account")
            cbo_beneficiary_type.Items.Add("Group Account")

        End If
        cbo_beneficiary_type.Items.Add("Others")
        cbo_beneficiary_type.Items.Add("")
        cbo_beneficiary_type.Text = "Others"

    End Sub


    Private Sub DisableALL()
        Dim ctrl As Control
        For Each ctrl In Me.Controls
            'If Not TypeOf ctrl Is CommandButton Then
            ctrl.Enabled = False
            ' End If
        Next

    End Sub

    Private Sub Frm_DealSummary_Product_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lst_pickup_location.Enabled = False

        Me.KeyPreview = True
        conn = New CSQL
        conn.Connect()
        Dim strSQL As String = ""

        Call FillComboALL()
        Call FillComboByProduct()

        txt_validation_scrap_if_not_auth_or_send.Text = "90"
        txt_validation_notify_user_of_scrap_before_day.Text = "1"

        'If strMODE.ToUpper = "ADD" Then


        txt_my_product.Text = xFrm_DealSummary_Product_SelectMyProduct.txt_MYPRODUCT.Text
        txt_product_name.Text = xFrm_DealSummary_Product_SelectMyProduct.txt_MYPRODUCT_DESCRIPTION.Text
        cbo_ude_product.Text = xFrm_DealSummary_Product_SelectMyProduct.txt_UDEPRODUCT.Text
        cbo_bank_product.Text = xFrm_DealSummary_Product_SelectMyProduct.grd_data.CurrentRow.Cells(0).Value

        If cbo_bank_product.Text <> "" Then
            txt_my_product.Enabled = False
            cbo_ude_product.Enabled = False
            txt_product_name.Enabled = False
            cbo_bank_product.Enabled = False
            Call ShowDataModeAdd()


        End If 'If cbo_bank_product.Text <> "" Then

        If strMODE.ToUpper = "ADD" Then
            If cbo_ude_product.Text <> "" And cbo_bank_product.Text <> "" Then
                Call ShowDuplicationBankProduct_UDE()
            End If

            'If txt_my_product.Text = "PCT" Or txt_my_product.Text = "PCL" Or txt_my_product.Text = "PMX" Or txt_my_product.Text = "PCX" Then
            ' chk_confidenfial_flag.Checked = True
            'End If
        End If ' If strMODE.ToUpper = "ADD" Then

        ' End If '========= If strMODE.ToUpper = "ADD" Then

        If strMODE.ToUpper <> "ADD" Then
            Call ShowData()

            strSQL = ""
            strSQL += "select "
            strSQL += " charge_template "
            strSQL += " from TB_DEAL_PRODUCT_CHARGE_PACKAGE "
            strSQL += " where "
            strSQL += " company_id ='" & txt_company_id.Text.Replace("'", "''") & "' "
            strSQL += " and my_product ='" & txt_my_product.Text.Replace("'", "''") & "' "

            strSQL += " group by charge_template "
            strSQL += " order by charge_template "


            conn.Fill_ComboBox(strSQL, lst_charge_package)

            Select Case cbo_bank_product.Text.ToUpper()
                'Case "PCL", "MCL"
                '   cbo_arrangement.Text = "D-2"
                Case "COC", "COE"
                    '  cbo_arrangement.Text = "D-1"
                    lst_pickup_location.Enabled = True
                Case Else
                    ' cbo_arrangement.Text = "D+0"
            End Select

            txt_my_product.Enabled = False
            cbo_ude_product.Enabled = False
            cbo_bank_product.Enabled = False

            btn_select_my_product_code.Enabled = False
            btn_select_ude_product.Enabled = False
            btn_select_bank_product.Enabled = False


            ' Dim strSQL As String = ""
            Dim vnt As String = ""
            strSQL = " SELECT isnull(count(*),0) as c FROM [TB_DEAL_PRODUCT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
            strSQL += " and ude_product ='" + cbo_ude_product.Text.Replace("'", "''") + "' "
            strSQL += " and bank_product ='" + cbo_bank_product.Text.Replace("'", "''") + "' "
            vnt = conn.GetDataFromSQL(strSQL)
            If CDbl(vnt) > 1 Then
                txt_product_name.Enabled = False
                txt_rule_priority.Enabled = False
                txt_rule_code.Enabled = False
                cbo_arrangement.Enabled = False
                txt_per_txm_max_amt.Enabled = False
                cbo_product_template.Enabled = False
                cbo_charge_template.Enabled = False
                cbo_default_charge_account.Enabled = False
                txt_days_period.Enabled = False

            End If

            If txt_revision_code.Text.ToUpper = "Rev0009".ToUpper Then 'Client Pickup Location Changing
                Call DisableALL()
                lst_pickup_location.Enabled = True
                grp_tool.Enabled = True
                BT_Update.Enabled = True
                bt_close.Enabled = True

            End If


        End If '=============If strMODE.ToUpper <> "ADD" Then


        If txt_revision_code.Text.ToUpper = "Rev0014".ToUpper Then 'Rev0014	Disable My Product
            Call DisableALL()
            rad_no.Checked = True
            grp_tool.Enabled = True
            BT_Update.Enabled = True
            bt_close.Enabled = True

        End If
        ' "Rev0023".ToUpper 
        If txt_revision_code.Text.ToUpper = "Rev0023".ToUpper Then 'Rev0014	Disable My Product
            Call DisableALL()
            ' rad_no.Checked = True
            grp_tool.Enabled = True
            BT_Update.Enabled = True
            bt_close.Enabled = True
            cbo_product_template.Enabled = True
        End If
        ' "Rev0024".ToUpper 
        If txt_revision_code.Text.ToUpper = "Rev0024".ToUpper Then 'Rev0014	Disable My Product
            Call DisableALL()
            ' rad_no.Checked = True
            grp_tool.Enabled = True
            BT_Update.Enabled = True
            bt_close.Enabled = True
            cbo_charge_template.Enabled = True
        End If

    End Sub

    Private Sub txt_validation_notify_user_of_scrap_before_day_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_validation_notify_user_of_scrap_before_day.Validated
        If IsNumeric(txt_validation_notify_user_of_scrap_before_day.Text.Replace(",", "")) = False Then
            txt_validation_notify_user_of_scrap_before_day.Text = "1"
        End If
    End Sub

    Private Sub txt_per_txm_max_amt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_per_txm_max_amt.Validated
        If IsNumeric(txt_per_txm_max_amt.Text.Replace(",", "")) = False Then
            txt_per_txm_max_amt.Text = ""
        Else
            txt_per_txm_max_amt.Text = CDbl(txt_per_txm_max_amt.Text).ToString("###,##0.0")
        End If
    End Sub

    Private Sub cbo_ude_product_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_ude_product.Validated
       
        'If cbo_ude_product.Text <> "" Then
        '    Call AutoSelectProduct()
        '    Call FillComboByProduct()
        'End If

    End Sub

    Private Sub AutoSelectProduct()
        'BNE(D + 0)
        'COC(D - 1)
        'COE(D + 0)
        'DCT(D + 0)
        'FTL(D + 0)
        'FTR(D + 0)
        'MCL(D - 2)
        'MCS(D + 0)
        'PCL(D - 2)
        'PCT(D + 0)
        cbo_bank_product.Text = cbo_ude_product.Text.Substring(cbo_ude_product.Text.Length - 3, 3)

        'cbo_arrangement
        Select Case cbo_ude_product.Text.Substring(cbo_ude_product.Text.Length - 3, 3)
            Case "PCL", "MCL"
                cbo_arrangement.Text = "D-2"
            Case "COC"
                cbo_arrangement.Text = "D-1"
                lst_pickup_location.Enabled = True
            Case "COE"
                lst_pickup_location.Enabled = True
            Case Else
                cbo_arrangement.Text = "D+0"
                lst_pickup_location.Enabled = False
        End Select

    End Sub

    Private Sub cbo_ude_product_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_ude_product.SelectedIndexChanged
        If cbo_ude_product.Text <> "" Then
            '    Call AutoSelectProduct()
            ' Call FillComboByProduct()
        End If
    End Sub

    Private Sub btn_find_product_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_find_product.Click
        Try
            Dim mFrm_TemplateProduct_list As New Frm_TemplateProduct_list
            mFrm_TemplateProduct_list.IS_RETURN = True
            mFrm_TemplateProduct_list.OBJ_COMBOBOX = cbo_product_template
            If cbo_bank_product.Text <> "" Then
                mFrm_TemplateProduct_list.strProduct_sendto = cbo_bank_product.Text
            End If
            mFrm_TemplateProduct_list.btnSendTo.Visible = True
            mFrm_TemplateProduct_list.btn_new_template.Visible = True
            mFrm_TemplateProduct_list.txt_product_template_new = txt_product_template_new
            mFrm_TemplateProduct_list.ShowDialog()

        


        Catch ex As Exception
            MsgBox(Err.Description & "::" & Err.Number)
        End Try
    End Sub



    Private Sub btn_find_charge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_find_charge.Click
        Try
          
            Dim mFrm_TemplateChargeUnit As New Frm_TemplateChargeUnit_list
            mFrm_TemplateChargeUnit.IS_RETURN = True
            mFrm_TemplateChargeUnit.OBJ_COMBOBOX = cbo_charge_template
            mFrm_TemplateChargeUnit.strProduct_sendto = cbo_bank_product.Text
            mFrm_TemplateChargeUnit.btnSendTo.Visible = True
            mFrm_TemplateChargeUnit.btn_new_template.Visible = True
            mFrm_TemplateChargeUnit.txt_charge_template_new = txt_charge_template_new
            mFrm_TemplateChargeUnit.ShowDialog()

        Catch ex As Exception
            MsgBox(Err.Description & "::" & Err.Number)
        End Try
    End Sub

    Private Sub btn_select_my_product_code_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_select_my_product_code.Click

        Dim mFrm_LookupData As Frm_LookupData
        Dim strSQL As String = ""

        strSQL = ""
        strSQL += " select  distinct "
        strSQL += "  a.my_product as [My Product Code] "
        strSQL += "  ,a.product_name as [My Product Name] "
        strSQL += "  from "
        strSQL += " dbo.TB_DEAL_PRODUCT a "
        strSQL += "  where "
        strSQL += "  a.company_id='" & txt_company_id.Text.Replace("'", "''") & "' "

        ' Frm_LookupData.Show()
        txt_temp.Text = ""
        mFrm_LookupData = New Frm_LookupData()
        mFrm_LookupData.SET_SQL = strSQL
        mFrm_LookupData.txtObject = txt_temp

        mFrm_LookupData.ShowDialog()

        If txt_temp.Text <> "" Then

            If UBound(Split(txt_temp.Text, "||")) Then

                txt_my_product.Text = Split(txt_temp.Text, "||")(0)
                txt_product_name.Text = Split(txt_temp.Text, "||")(1)

            End If

            'strSQL = ""
            'strSQL += " select  "
            'strSQL += "  a.product_name as [My Product Name] "
            'strSQL += "  from "
            'strSQL += " dbo.TB_DEAL_PRODUCT a "
            'strSQL += "  where "
            'strSQL += "  a.company_id='" & txt_company_id.Text.Replace("'", "''") & "' and a.my_product='" & txt_my_product.Text.Replace("'", "''") & "' "

            'txt_product_name.Text = conn.GetDataFromSQL(strSQL)

        End If

    End Sub


    Private Sub btn_select_ude_product_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_select_ude_product.Click
        Dim mFrm_LookupData As Frm_LookupData
        Dim strSQL As String = ""

        strSQL = ""
        strSQL += " select distinct "
        strSQL += "  a.ude_product as [UDE Product] "

        strSQL += "  from "
        strSQL += " dbo.TB_DEAL_PRODUCT a "
        strSQL += "  where "
        strSQL += "  a.company_id='" & txt_company_id.Text.Replace("'", "''") & "' "

        If txt_my_product.Text <> "" Then
            '  strSQL += "  AND a.ude_product not in (select  ude_product from TB_DEAL_PRODUCT  where company_id='" & txt_company_id.Text.Replace("'", "''") & "' and my_product='" & txt_my_product.Text.Replace("'", "''") & "'   ) "
        End If
        
        txt_temp.Text = ""
        mFrm_LookupData = New Frm_LookupData()
        mFrm_LookupData.SET_SQL = strSQL
        mFrm_LookupData.txtObject = txt_temp

        mFrm_LookupData.ShowDialog()
        If txt_temp.Text <> "" Then
            cbo_ude_product.Text = txt_temp.Text
        End If

    End Sub

    Private Sub cbo_bank_product_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_bank_product.SelectedIndexChanged
        Call FillComboByProduct()

        If InStr("COC,COE", cbo_bank_product.Text.Substring(cbo_bank_product.Text.Length - 3, 3)) > 0 Then
            lst_pickup_location.Enabled = True
        Else
            lst_pickup_location.Enabled = False
        End If

    End Sub

    Private Sub btn_select_bank_product_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_select_bank_product.Click
        Dim mFrm_LookupData As Frm_LookupData
        Dim strSQL As String = ""

        strSQL = ""

        strSQL += " SELECT distinct #all.* from"
        strSQL += " ("
        strSQL += " SELECT  [PRODUCT_CODE] as [Bank Product Code]"
        strSQL += "       ,[PRODUCT_DESCRIPTION] as [Description]"
        strSQL += "       ,[ARRANGEMENT_CODE] as [Arrangement]"
        strSQL += "       ,[PER_TXN_MAX_AMNT] as [Per Txn Max Amt]"
        strSQL += "       ,[RULE_PRIORITY] as [Rule Priority]"
        strSQL += "       ,[RULE_CODE] as [Rule Code]"
        strSQL += "  FROM "
        strSQL += "   [dbo].[TB_BANK_PRODUCT]"
        strSQL += "  union"
        strSQL += "   SELECT  DISTINCT "
        strSQL += " 	a.bank_product as [Bank Product Code]"
        strSQL += "       ,p.PRODUCT_DESCRIPTION  as [Description]"
        strSQL += "       ,a.arrangement as [Arrangement]"
        strSQL += "       ,a.per_txm_max_amt as [Per Txn Max Amt]"
        strSQL += "       ,a.rule_priority as [Rule Priority]"
        strSQL += "       ,a.rule_code as [Rule Code]"
        strSQL += "  FROM "
        strSQL += " 	dbo.TB_DEAL_PRODUCT a"
        strSQL += " 	LEFT OUTER JOIN dbo.PRODUCT_MST p ON  p.PRODUCT_CODE=a.bank_product"
        strSQL += "   where a.company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
        strSQL += "  ) #all"

        If txt_my_product.Text <> "" And cbo_ude_product.Text <> "" Then
            ' strSQL += "  where #all.[Bank Product Code] not in (select  bank_product from TB_DEAL_PRODUCT  where company_id='" & txt_company_id.Text.Replace("'", "''") & "' and my_product='" & txt_my_product.Text.Replace("'", "''") & "'    and ude_product='" & cbo_ude_product.Text.Replace("'", "''") & "') "
        End If

        strSQL += "  order by #all.[Bank Product Code],#all.[Description],#all.Arrangement  "


        ' Frm_LookupData.Show()
        txt_temp.Text = ""
        mFrm_LookupData = New Frm_LookupData()
        mFrm_LookupData.SET_SQL = strSQL
        mFrm_LookupData.txtObject = txt_temp

        mFrm_LookupData.ShowDialog()
        If txt_temp.Text <> "" Then
            '    cbo_ude_product.Text = txt_temp.Text
            'strSQL += " 	a.bank_product as [Bank Product Code]" 0
            'strSQL += "       ,p.PRODUCT_DESCRIPTION  as [Description]" 1
            'strSQL += "       ,a.arrangement as [Arrangement]" 2 
            'strSQL += "       ,a.per_txm_max_amt as [Per Txn Max Amt]" 3
            'strSQL += "       ,a.rule_priority as [Rule Priority]" 4
            'strSQL += "       ,a.rule_code as [Rule Code]" 5

            If UBound(Split(txt_temp.Text, "||")) Then

                cbo_bank_product.Text = Split(txt_temp.Text, "||")(0)
                txt_rule_priority.Text = Split(txt_temp.Text, "||")(4)
                txt_per_txm_max_amt.Text = Split(txt_temp.Text, "||")(3)
                cbo_arrangement.Text = Split(txt_temp.Text, "||")(2)
                txt_rule_code.Text = Split(txt_temp.Text, "||")(5)
            End If


        End If
    End Sub

    Private Sub txt_validation_scrap_if_not_auth_or_send_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_validation_scrap_if_not_auth_or_send.Validated
        If IsNumeric(txt_validation_scrap_if_not_auth_or_send.Text.Replace(",", "")) = False Then
            txt_validation_scrap_if_not_auth_or_send.Text = "90"
        End If
    End Sub

    Private Sub cbo_auth_type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_auth_type.SelectedIndexChanged
        If cbo_auth_type.Text = "Account" Then
            cbo_auth_level.Text = "Instrument Level"
            cbo_auth_level.Enabled = False
        Else
            cbo_auth_level.Enabled = True
        End If

    End Sub


    Private Sub cbo_arrangement_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_arrangement.SelectedIndexChanged

        txt_days_period.Text = Replace(cbo_arrangement.SelectedItem, "D", "")
        txt_days_period.Text = Replace(txt_days_period.Text, "+", "")


    End Sub

End Class