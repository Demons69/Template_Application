
Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_DealSummary_Account

    Public strID As String = ""
    Public strMODE As String = "ADD"
    Private Const strALL = "--------Select--------"
    Dim conn As CSQL
    Public bPayment As Boolean =False 

    Private Sub init()

        Dim strSQL As String = String.Empty
        conn = New CSQL
        conn.Connect()

        cbo_account_type.Items.Clear()
        cbo_account_type.Items.Add("Current") '1
        cbo_account_type.Items.Add("Saving") '2
        cbo_account_type.Items.Add("Fix Deposit") '3
        cbo_account_type.Items.Add("Special Fix Deposit")
        cbo_account_type.SelectedIndex = 0

        strSQL = "select account_number from tb_deal_account where payment = 'Y' and company_id = '" & txt_company_id.Text & "'"

        '-- set default for first account only
        If conn.HasRows(strSQL) Then
            chk_default_charge.Checked = False
            chk_default_debit.Checked = False
            chk_default_credit.Checked = False

            '-- Already have payment acct
            txt_IsPaymentActive.Text = "Y"

        Else
            If chk_payment.Checked Then

                chk_default_charge.Checked = True
                chk_default_debit.Checked = True
                chk_default_credit.Checked = True
            Else

                chk_default_charge.Checked = False
                chk_default_debit.Checked = False
                chk_default_credit.Checked = False

            End If

            '-- No payment acct
            txt_IsPaymentActive.Text = "N"
        End If

    End Sub

    Private Sub Frm_DealSummary_Account_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Try

            Me.KeyPreview = True
            Call init()

            Select Case strMODE.ToUpper

                Case "ADD"


                Case Else

                    Call ShowData()
                    If bPayment = False Then chk_payment.Enabled = False
                    ''Call SetOptionEnabled()
                    ''Call SetEnableDefault()
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub


    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_DEAL_ACCOUNT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()
            txt_account_number.Enabled = False

            txt_branch_code.Text = IIf(res("branch_code") Is System.DBNull.Value, "", res("branch_code").ToString())
            txt_account_name.Text = IIf(res("account_name") Is System.DBNull.Value, "", res("account_name").ToString())
            'txt_account_number_charge.Text = IIf(res("account_number_charge") Is System.DBNull.Value, "", res("account_number_charge").ToString())
            'txt_account_number_credit.Text = IIf(res("account_number_credit") Is System.DBNull.Value, "", res("account_number_credit").ToString())

            cbo_account_type.Text = IIf(res("account_type") Is System.DBNull.Value, "", res("account_type").ToString())

            'chk_default_account
            'If IIf(res("default_account") Is System.DBNull.Value, "", res("default_account").ToString()) = "Y" Then
            '    chk_default_account.Checked = True
            'Else
            '    chk_default_account.Checked = False
            'End If

            If IIf(res("payment") Is System.DBNull.Value, "", res("payment").ToString()) = "Y" Then
                chk_payment.Checked = True
            Else
                chk_payment.Checked = False
            End If

            ''Call setcontrol_payment()

            If IIf(res("acc_stt") Is System.DBNull.Value, "", res("acc_stt").ToString()) = "Y" Then
                chk_acc_stt.Checked = True
            Else
                chk_acc_stt.Checked = False
                chk_acc_stt.Enabled = True
            End If

            If IIf(res("sq") Is System.DBNull.Value, "", res("sq").ToString()) = "Y" Then
                chk_sq.Checked = True
            Else
                chk_sq.Checked = False
            End If

            If IIf(res("bill_payment") Is System.DBNull.Value, "", res("bill_payment").ToString()) = "Y" Then
                chk_bill_payment.Checked = True
            Else
                chk_bill_payment.Checked = False
            End If

            'rad_yes
            If IIf(res("valid_flag") Is System.DBNull.Value, "", res("valid_flag").ToString()) = "Y" Then
                rad_yes.Checked = True
            Else
                rad_no.Checked = True
            End If

            'chk_default_charge
            If IIf(res("default_charge") Is System.DBNull.Value, "", res("default_charge").ToString()) = "Y" Then
                chk_default_charge.Checked = True
            Else
                chk_default_charge.Checked = False
            End If

            If IIf(res("default_debit") Is System.DBNull.Value, "", res("default_debit").ToString()) = "Y" Then
                chk_default_debit.Checked = True
            Else
                chk_default_debit.Checked = False
            End If

            If IIf(res("default_credit") Is System.DBNull.Value, "", res("default_credit").ToString()) = "Y" Then
                chk_default_credit.Checked = True
            Else
                chk_default_credit.Checked = False
            End If

            'chk_set_as_charge_account
            If IIf(res("set_as_charge_account") Is System.DBNull.Value, "", res("set_as_charge_account").ToString()) = "Y" Then
                chk_set_as_charge_account.Checked = True
            Else
                chk_set_as_charge_account.Checked = False
            End If
            'chk_set_as_debit_and_charge_at
            If IIf(res("set_as_debit_and_charge_at") Is System.DBNull.Value, "", res("set_as_debit_and_charge_at").ToString()) = "Y" Then
                chk_set_as_debit_and_charge_at.Checked = True
            Else
                chk_set_as_debit_and_charge_at.Checked = False
            End If
            'cbo_charge_account_number
            cbo_charge_account_number.Text = IIf(res("charge_account_number") Is System.DBNull.Value, "", res("charge_account_number").ToString())

            If IIf(res("set_as_credit_account_for_debit") Is System.DBNull.Value, "", res("set_as_credit_account_for_debit").ToString()) = "Y" Then
                chk_set_as_credit_account_for_debit.Checked = True
            Else
                chk_set_as_credit_account_for_debit.Checked = False
            End If
            cbo_txn_account_number.Text = IIf(res("txn_account_number") Is System.DBNull.Value, "", res("txn_account_number").ToString())


            ''Call setcontrol_payment()
            'txt_set_fee_charge.Text = IIf(res("set_fee_charge") Is System.DBNull.Value, "", res("set_fee_charge").ToString())

        End If
        res.Close()
        res = Nothing

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

        Call SaveData()
    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""
        Dim strSQL As String = ""

        'If chk_default_account.Checked = True Then
        '    strSQL = "SELECT * FROM [TB_DEAL_ACCOUNT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number <> '" + txt_account_number.Text.Replace("'", "''") + "' and default_account='Y' "
        '    If conn.HasRows(strSQL) = True Then
        '        'MessageBox.Show("Invalid [Account] is duplicate.")
        '        'Exit Function
        '        strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Main Account]"
        '    End If
        'End If '  If chk_default_account.Checked = True Then


        If chk_payment.Checked = False And chk_acc_stt.Checked = False And chk_bill_payment.Checked = False And chk_sq.Checked = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Account Option]"
        End If

        If txt_account_number.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Account Number]"
        End If
        If chk_default_charge.Checked = True And chk_set_as_charge_account.Checked = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Set as Charge Account] must be selected."
        End If

        If chk_default_debit.Checked = True And chk_set_as_debit_and_charge_at.Checked = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Set as Debit Account And Charge At] must be selected."
        End If

        If chk_default_credit.Checked = True And chk_set_as_credit_account_for_debit.Checked = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Set As Credit Account for Debit Account Number] must be selected."
        End If

        'If txt_account_number_charge.Text = "" Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Charge Account Number]"
        'End If
        'If txt_account_number_credit.Text = "" Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Credit Account Number]"
        'End If

        If cbo_account_type.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Account Type]"
        End If

        'If txt_set_fee_charge.Text = "" Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Set Fee Charge]"
        'End If

        Return strErr
    End Function

    Private Sub SaveData()
        Dim strSQL As String = String.Empty
        Dim strMsg As String = String.Empty
        Dim strRevDate As String = Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)

        Try

            conn = New CSQL
            conn.Connect()

            Select Case strMODE.ToUpper
                Case "ADD"

                    strSQL = "exec [SP_tp_Account_Insert] '" _
                        & txt_company_id.Text & "', '" _
                        & txt_branch_code.Text & "', '" _
                        & cbo_account_type.Text & "', '" _
                        & txt_account_number.Text & "', '" _
                        & txt_account_name.Text & "', '" _
                        & IIf(chk_acc_stt.Checked, "Y", "N").ToString() & "', '" _
                        & IIf(chk_bill_payment.Checked, "Y", "N").ToString() & "', '" _
                        & IIf(chk_sq.Checked, "Y", "N").ToString() & "', '" _
                        & IIf(chk_payment.Checked, "Y", "N").ToString() & "', 'Y', 'N', '" _
                        & IIf(chk_default_charge.Checked, "Y", "N").ToString() & "', '" _
                        & IIf(chk_set_as_charge_account.Checked, "Y", "N").ToString() & "', '" _
                        & IIf(chk_default_debit.Checked, "Y", "N").ToString() & "', '" _
                        & IIf(chk_set_as_debit_and_charge_at.Checked, "Y", "N").ToString() & "', '" _
                        & IIf(chk_default_credit.Checked, "Y", "N").ToString() & "', '" _
                        & IIf(chk_set_as_credit_account_for_debit.Checked, "Y", "N").ToString() & "', '" _
                        & cbo_charge_account_number.Text & "', '" _
                        & cbo_txn_account_number.Text & "', '" _
                        & txt_revision_code.Text & "', '" _
                        & IIf(Len(txt_revision_code.Text) > 0, strRevDate, String.Empty) & "', '" _
                        & txt_revision_desc.Text & "'"


                    If conn.GetDataFromSQL(strSQL) = 0 Then
                        MessageBox.Show("Invalid [Account] is duplicate.")
                    Else
                        MessageBox.Show("Save data was successful.")
                        Me.Close()
                    End If

                Case Else

                    strSQL = "exec [SP_tp_Account_Update] '" _
                            & txt_company_id.Text & "', '" _
                            & txt_account_number.Text & "', '" _
                            & txt_account_name.Text & "', '" _
                            & cbo_account_type.Text & "', '" _
                            & IIf(chk_acc_stt.Checked, "Y", "N").ToString() & "', '" _
                            & IIf(chk_bill_payment.Checked, "Y", "N").ToString() & "', '" _
                            & IIf(chk_sq.Checked, "Y", "N").ToString() & "', '" _
                            & IIf(chk_payment.Checked, "Y", "N").ToString() & "', '" _
                            & IIf(rad_yes.Checked, "Y", "N").ToString() & "', 'N', '" _
                            & IIf(chk_default_charge.Checked, "Y", "N").ToString() & "', '" _
                            & IIf(chk_set_as_charge_account.Checked, "Y", "N").ToString() & "', '" _
                            & IIf(chk_default_debit.Checked, "Y", "N").ToString() & "', '" _
                            & IIf(chk_set_as_debit_and_charge_at.Checked, "Y", "N").ToString() & "', '" _
                            & IIf(chk_default_credit.Checked, "Y", "N").ToString() & "', '" _
                            & IIf(chk_set_as_credit_account_for_debit.Checked, "Y", "N").ToString() & "', '" _
                            & cbo_charge_account_number.Text & "', '" _
                            & cbo_txn_account_number.Text & "', " _
                            & IIf(Len(txt_revision_code.Text) = 0, "null", "'" & txt_revision_code.Text & "'") & ", " _
                            & IIf(Len(txt_revision_code.Text) = 0, "null", "'" & txt_revision_desc.Text & "'") & ", " _
                            & IIf(Len(txt_revision_code.Text) = 0, "null", "' " & strRevDate & "'")

                    strMsg = conn.ExecuteNonQuery(strSQL)

                    If Len(strMsg) > 0 Then
                        MessageBox.Show(strMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Save data was successful.")
                        Me.Close()
                    End If

            End Select


            ''---- Comment by Tum: 17-Jun-2014
            ''---- Release note: 0.35; req frm P'Pum+
            'If chk_payment.Checked = True Then
            '    Dim strSQLCheck As String = ""
            '    Dim vnt As String = ""
            '    strSQLCheck = ""
            '    strSQLCheck += " select isnull(count(*),0) as c from TB_DEAL_ACCOUNT"
            '    strSQLCheck += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
            '    strSQLCheck += " and default_charge='Y' "
            '    vnt = conn.GetDataFromSQL(strSQLCheck)
            '    If CDbl(vnt) = 0 Then 'if no payment accoun

            '        chk_default_charge.Checked = True
            '        ' Else
            '        ' chk_default_account.Checked = False
            '    End If
            'End If      

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub txt_account_number_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_account_number.Validated

        txt_account_number.Text = txt_account_number.Text.Replace("-", "")

        'If txt_account_number.Text.Length > 4 Then
        '    Select Case txt_account_number.Text.Substring(4, 1)

        '        Case "1" : cbo_account_type.Text = "Current"
        '        Case "2" : cbo_account_type.Text = "Saving"
        '        Case "3" : cbo_account_type.Text = "Fix Deposit"
        '        Case Else : cbo_account_type.Text = "Current"

        '    End Select
        'End If
       

        If txt_account_number.Text.Length >= 3 Then
            txt_branch_code.Text = "0040" & txt_account_number.Text.Substring(0, 3)
        End If

        If txt_account_number.Text.Length <> 10 Or IsNumeric(txt_account_number.Text) = False Then
            MsgBox("Please enter numberic 10 digit only.")
        End If

        'If chk_set_as_credit_account_for_debit.Checked = True Then
        '    cbo_txn_account_number.Text = txt_account_number.Text
        'End If

    End Sub

    Private Sub chk_payment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_payment.CheckedChanged

        'chk_default_charge.Checked = False
        'chk_default_debit.Checked = False
        'chk_default_credit.Checked = False
        'Call setcontrol_payment()
        'Call SetEnableDefault()

        cbo_charge_account_number.Text = ""
        cbo_charge_account_number.Enabled = False
        cbo_txn_account_number.Text = txt_account_number.Text

        If chk_payment.Checked Then
            chk_set_as_credit_account_for_debit.Checked = True
            chk_set_as_credit_account_for_debit.Enabled = True

            chk_set_as_charge_account.Checked = True
            chk_set_as_debit_and_charge_at.Checked = True

        Else
            chk_set_as_credit_account_for_debit.Checked = False
            chk_set_as_credit_account_for_debit.Enabled = False

            chk_set_as_charge_account.Checked = False
            chk_set_as_debit_and_charge_at.Checked = False

        End If

    End Sub


    Private Sub cbo_account_type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_account_type.SelectedIndexChanged

        If cbo_account_type.Text = "Fix Deposit" Or cbo_account_type.Text = "Special Fix Deposit" Then
            chk_bill_payment.Enabled = False
            chk_sq.Enabled = False
            chk_payment.Enabled = False

            chk_bill_payment.Checked = False
            chk_sq.Checked = False
            chk_payment.Checked = False

            chk_default_charge.Enabled = False : chk_default_charge.Checked = False
            chk_set_as_charge_account.Enabled = False : chk_set_as_charge_account.Checked = False

            chk_default_debit.Enabled = False : chk_default_debit.Checked = False
            chk_set_as_debit_and_charge_at.Enabled = False : chk_set_as_debit_and_charge_at.Checked = False
            cbo_charge_account_number.Enabled = False : cbo_charge_account_number.Text = ""

            chk_default_credit.Enabled = False : chk_default_credit.Checked = False
            chk_set_as_credit_account_for_debit.Enabled = False : chk_set_as_credit_account_for_debit.Checked = False
            cbo_txn_account_number.Enabled = False : cbo_txn_account_number.Text = ""

        Else

            If txt_IsPaymentActive.Text = "Y" Then
                chk_default_charge.Checked = False
                chk_default_debit.Checked = False
                chk_default_credit.Checked = False
            End If

            chk_bill_payment.Enabled = True
            chk_sq.Enabled = True
            chk_payment.Enabled = True

            End If

    End Sub


    Private Sub chk_default_charge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_default_charge.CheckedChanged
        Call Autocharge_account_number()
    End Sub


    Private Sub Autocharge_account_number()
        If chk_set_as_charge_account.Checked = True And chk_set_as_debit_and_charge_at.Checked = True Then
            cbo_charge_account_number.Text = txt_account_number.Text
        End If
    End Sub

    Private Sub chk_set_as_charge_account_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_set_as_charge_account.CheckedChanged
        Call FillChargeAccount()


    End Sub

    Private Sub chk_set_as_debit_and_charge_at_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_set_as_debit_and_charge_at.CheckedChanged
        'cbo_charge_account_number
        If chk_set_as_debit_and_charge_at.Checked = True Then
            cbo_charge_account_number.Enabled = True

            Call FillChargeAccount()
            ' Call Autocharge_account_number()
        Else
            cbo_charge_account_number.Text = ""
            cbo_charge_account_number.Enabled = False
        End If

        Call Autocharge_account_number()
    End Sub

    Private Sub FillChargeAccount()
        Dim strSQL As String = ""

        If Len(txt_account_number.Text) > 0 Then


            strSQL = " select "
            strSQL += vbCrLf & "  account_number "
            strSQL += vbCrLf & " from TB_DEAL_ACCOUNT "
            strSQL += vbCrLf & " where company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
            strSQL += vbCrLf & " and isnull(set_as_charge_account,'N')='Y' "
            strSQL += vbCrLf & " order by account_number "
            conn.Fill_ComboBox(strSQL, cbo_charge_account_number)

            If strMODE.ToString = "ADD" And chk_set_as_charge_account.Checked = True And chk_set_as_debit_and_charge_at.Checked = True Then

                cbo_charge_account_number.Items.Add(txt_account_number.Text)

            End If

            cbo_charge_account_number.Items.Add("Default Charge Account")
        End If
    End Sub

    Private Sub Frm_DealSummary_Account_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DisableALL()
        Dim ctrl As Control
        For Each ctrl In Me.Controls
            'If Not TypeOf ctrl Is CommandButton Then
            ctrl.Enabled = False
            ' End If
        Next

    End Sub
End Class


'Private Sub SaveData()
'    Try
'        conn = New CSQL
'        conn.Connect()
'        Dim strSQL As String = ""

'        '========================add mode====================
'        If strMODE.ToUpper = "ADD" Then
'            strSQL = "SELECT * FROM [TB_DEAL_ACCOUNT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "
'            If conn.HasRows(strSQL) = True Then
'                MessageBox.Show("Invalid [Account] is duplicate.")
'                Exit Sub
'            End If

'            Dim strValue As String = ""
'            Dim strFiledname As String = ""

'            'txt_account_name

'            strFiledname += vbCrLf & "[account_number]"
'            strValue += vbCrLf & "N'" & txt_account_number.Text.Replace("'", "''") & "'"
'            'branch_code
'            strFiledname += vbCrLf & ",[branch_code]"
'            strValue += vbCrLf & ",N'" & txt_branch_code.Text.Replace("'", "''") & "'"

'            strFiledname += vbCrLf & ",[account_name]"
'            strValue += vbCrLf & ",N'" & txt_account_name.Text.Replace("'", "''") & "'"


'            'strFiledname += vbCrLf & ",[account_number_charge]"
'            'strValue += vbCrLf & ",N'" & txt_account_number_charge.Text.Replace("'", "''") & "'"

'            'strFiledname += vbCrLf & ",[account_number_credit]"
'            'strValue += vbCrLf & ",N'" & txt_account_number_credit.Text.Replace("'", "''") & "'"

'            strFiledname += vbCrLf & ",[company_id]"
'            strValue += vbCrLf & ",N'" & txt_company_id.Text.Replace("'", "''") & "'"

'            strFiledname += vbCrLf & ",[account_type]"
'            strValue += vbCrLf & ",N'" & cbo_account_type.Text.Replace("'", "''") & "'"

'            strFiledname += vbCrLf & ",[payment]"
'            If chk_payment.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If

'            strFiledname += vbCrLf & ",[acc_stt]"
'            If chk_acc_stt.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If

'            strFiledname += vbCrLf & ",[sq]"
'            If chk_sq.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If

'            strFiledname += vbCrLf & ",[bill_payment]"

'            If chk_bill_payment.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If

'            '=========================================
'            strFiledname += vbCrLf & ",[default_charge]"

'            If chk_default_charge.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If

'            strFiledname += vbCrLf & ",[default_debit]"
'            If chk_default_debit.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            strFiledname += vbCrLf & ",[default_credit]"
'            If chk_default_credit.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            '============
'            strFiledname += vbCrLf & ",[set_as_charge_account]"
'            If chk_set_as_charge_account.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If

'            strFiledname += vbCrLf & ",[set_as_debit_and_charge_at]"
'            If chk_set_as_debit_and_charge_at.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If

'            strFiledname += vbCrLf & ",[charge_account_number]"
'            strValue += vbCrLf & ",N'" & cbo_charge_account_number.Text.Replace("'", "''") & "'"

'            strFiledname += vbCrLf & ",[set_as_credit_account_for_debit]"
'            If chk_set_as_credit_account_for_debit.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If

'            strFiledname += vbCrLf & ",[txn_account_number]"
'            strValue += vbCrLf & ",N'" & cbo_txn_account_number.Text.Replace("'", "''") & "'"

'            'strFiledname += ",[set_fee_charge]"
'            'strValue += vbCrLf & ",N'" & (txt_set_fee_charge.Text.Replace("'", "''")) & "'"


'            strSQL = ""
'            strSQL += vbCrLf & "insert into [TB_DEAL_ACCOUNT]  "
'            strSQL += vbCrLf & "(" & strFiledname & ")"
'            strSQL += vbCrLf & " VALUES (" & strValue & ")"

'            conn.ExecuteNonQuery(strSQL)
'            Me.Close()

'        End If ' If strMODE.ToUpper = "ADD" Then

'        '========================edit mode====================
'        If strMODE.ToUpper <> "ADD" Then
'            strSQL = ""
'            strSQL += vbCrLf & "update [TB_DEAL_ACCOUNT] set "

'            strSQL += vbCrLf & "[account_type]"
'            strSQL += vbCrLf & "=N'" & cbo_account_type.Text.Replace("'", "''") & "'"

'            strSQL += vbCrLf & ",[branch_code]"
'            strSQL += vbCrLf & "=N'" & txt_branch_code.Text.Replace("'", "''") & "'"

'            strSQL += vbCrLf & ",[account_name]"
'            strSQL += vbCrLf & "=N'" & txt_account_name.Text.Replace("'", "''") & "'"


'            strSQL += vbCrLf & ",[payment]"
'            If chk_payment.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            strSQL += vbCrLf & ",[acc_stt]"
'            If chk_acc_stt.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            strSQL += vbCrLf & ",[sq]"
'            If chk_sq.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            strSQL += vbCrLf & ",[bill_payment]"
'            If chk_bill_payment.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            'strSQL += vbCrLf & ",[account_number_charge]"
'            'strSQL += vbCrLf & "=N'" & txt_account_number_charge.Text.Replace("'", "''") & "'"

'            'strSQL += vbCrLf & ",[account_number_credit]"
'            'strSQL += vbCrLf & "=N'" & txt_account_number_credit.Text.Replace("'", "''") & "'"

'            'strSQL += ",[set_fee_charge]"
'            'strSQL += vbCrLf & "=N'" & (txt_set_fee_charge.Text.Replace("''", "'")) & "'"


'            '=========================================
'            strSQL += vbCrLf & ",[default_charge]"
'            If chk_default_charge.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            strSQL += vbCrLf & ",[default_debit]"
'            If chk_default_debit.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            strSQL += vbCrLf & ",[default_credit]"
'            If chk_default_credit.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            '============
'            strSQL += vbCrLf & ",[set_as_charge_account]"
'            If chk_set_as_charge_account.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            strSQL += vbCrLf & ",[set_as_debit_and_charge_at]"
'            If chk_set_as_debit_and_charge_at.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            strSQL += vbCrLf & ",[charge_account_number]"
'            strSQL += vbCrLf & "= N'" & cbo_charge_account_number.Text.Replace("'", "''") & "'"

'            strSQL += vbCrLf & ",[set_as_credit_account_for_debit]"
'            If chk_set_as_credit_account_for_debit.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            strSQL += vbCrLf & ",[txn_account_number]"
'            strSQL += vbCrLf & "= N'" & cbo_txn_account_number.Text.Replace("'", "''") & "'"


'            ''----xxxxx
'            If txt_revision_code.Text <> "" Then
'                strSQL += vbCrLf & "[valid_flag]"
'                If rad_yes.Checked = True Then
'                    strSQL += vbCrLf & "='Y'"
'                Else
'                    strSQL += vbCrLf & "='N'"
'                End If

'                strSQL += vbCrLf & " ,[revision_code]"
'                strSQL += vbCrLf & "=N'" & txt_revision_code.Text.Replace("'", "''") & "'"

'                strSQL += vbCrLf & ",[revision_desc]"
'                strSQL += vbCrLf & "=N'" & txt_revision_desc.Text.Replace("'", "''") & "'"

'                strSQL += vbCrLf & ",[revision_date]"
'                strSQL += vbCrLf & "=getdate()"

'            End If

'            ''-------------


'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "
'            conn.ExecuteNonQuery(strSQL)
'            Me.Close()

'        End If

'        If txt_revision_code.Text <> "" Then

'            strSQL = ""
'            strSQL += vbCrLf & "update [TB_DEAL_ACCOUNT] set "

'            '  strSQL += vbCrLf & "[gcp_service_end_date]"
'            ' strSQL += vbCrLf & "=" & get_date_sql(txt_gcp_service_end_date.Text) & ""

'            strSQL += vbCrLf & "[valid_flag]"
'            If rad_yes.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            strSQL += vbCrLf & " ,[revision_code]"
'            strSQL += vbCrLf & "=N'" & txt_revision_code.Text.Replace("'", "''") & "'"

'            strSQL += vbCrLf & ",[revision_desc]"
'            strSQL += vbCrLf & "=N'" & txt_revision_desc.Text.Replace("'", "''") & "'"

'            strSQL += vbCrLf & ",[revision_date]"
'            strSQL += vbCrLf & "=getdate()"

'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "


'            strSQL += vbCrLf & " DELETE FROM dbo.TB_REVISION_HISTORY WHERE company_id='" + txt_company_id.Text.Replace("'", "''") + "'"
'            'strSQL += vbCrLf & "   and revision_code='" + txt_revision_code.Text.Replace("'", "''") + "' "
'            strSQL += vbCrLf & "   and revision_code in ('Rev0006','Rev0007','Rev0008') "

'            'strSQL += vbCrLf & " insert into  TB_REVISION_HISTORY (company_id,revision_code,revision_desc,revision_date) values ("
'            ''company_id,revision_code,revision_desc,revision_date,revision_reason
'            'strSQL += vbCrLf & " '" + txt_company_id.Text.Replace("'", "''") + "'"
'            'strSQL += vbCrLf & " ,N'" & txt_revision_code.Text.Replace("'", "''") & "' "
'            'strSQL += vbCrLf & " ,N'" & txt_revision_desc.Text.Replace("'", "''") & "'"
'            'strSQL += vbCrLf & " ,getdate()"
'            'strSQL += vbCrLf & " "
'            'strSQL += vbCrLf & ")"

'            strSQL += vbCrLf & " insert into  TB_REVISION_HISTORY (company_id,revision_code,revision_desc,revision_date)" ' values (
'            'company_id,revision_code,revision_desc,revision_date,revision_reason
'            strSQL += vbCrLf & " select distinct company_id,revision_code,revision_desc,revision_date from  TB_DEAL_ACCOUNT"
'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  " 'and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "
'            strSQL += vbCrLf & "   and revision_code in ('Rev0006','Rev0007','Rev0008')"

'            conn.ExecuteNonQuery(strSQL)

'        End If

'        ''---- Comment by Tum: 17-Jun-2014
'        ''---- Release note: 0.35; req frm P'Pum+
'        'If chk_payment.Checked = True Then
'        '    Dim strSQLCheck As String = ""
'        '    Dim vnt As String = ""
'        '    strSQLCheck = ""
'        '    strSQLCheck += " select isnull(count(*),0) as c from TB_DEAL_ACCOUNT"
'        '    strSQLCheck += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
'        '    strSQLCheck += " and default_charge='Y' "
'        '    vnt = conn.GetDataFromSQL(strSQLCheck)
'        '    If CDbl(vnt) = 0 Then 'if no payment accoun

'        '        chk_default_charge.Checked = True
'        '        ' Else
'        '        ' chk_default_account.Checked = False
'        '    End If
'        'End If

'        'update default
'        If chk_default_charge.Checked = True Then
'            'strSQL = ""
'            'strSQL += vbCrLf & "update [TB_DEAL_ACCOUNT] set "
'            'strSQL += vbCrLf & "[default_charge]"
'            'strSQL += vbCrLf & "='N'"
'            'strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
'            'strSQL += vbCrLf & "update [TB_DEAL_ACCOUNT] set "
'            'strSQL += vbCrLf & "[default_charge]"
'            'strSQL += vbCrLf & "='Y'"
'            'strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "
'            strSQL = ""
'            strSQL += vbCrLf & "update [TB_DEAL_ACCOUNT] set "
'            strSQL += vbCrLf & "[default_charge]"
'            strSQL += vbCrLf & "='Y'"
'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "

'            conn.ExecuteNonQuery(strSQL)
'        Else
'            strSQL = ""
'            strSQL += vbCrLf & "update [TB_DEAL_ACCOUNT] set "
'            strSQL += vbCrLf & "[default_charge]"
'            strSQL += vbCrLf & "='N'"
'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "
'            conn.ExecuteNonQuery(strSQL)
'        End If

'        If chk_default_debit.Checked = True Then
'            strSQL = ""
'            strSQL += vbCrLf & "update [TB_DEAL_ACCOUNT] set "
'            strSQL += vbCrLf & "[default_debit]"
'            strSQL += vbCrLf & "='Y'"
'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "
'            conn.ExecuteNonQuery(strSQL)
'        Else
'            strSQL = ""
'            strSQL += vbCrLf & "update [TB_DEAL_ACCOUNT] set "
'            strSQL += vbCrLf & "[default_debit]"
'            strSQL += vbCrLf & "='N'"
'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "
'            conn.ExecuteNonQuery(strSQL)
'        End If

'        If chk_default_credit.Checked = True Then

'            strSQL = ""
'            strSQL += vbCrLf & "update [TB_DEAL_ACCOUNT] set "
'            strSQL += vbCrLf & "[default_credit]"
'            strSQL += vbCrLf & "='Y'"
'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "
'            conn.ExecuteNonQuery(strSQL)

'        Else
'            strSQL = ""
'            strSQL += vbCrLf & "update [TB_DEAL_ACCOUNT] set "
'            strSQL += vbCrLf & "[default_credit]"
'            strSQL += vbCrLf & "='N'"
'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "
'            conn.ExecuteNonQuery(strSQL)
'        End If

'    Catch ex As Exception
'        MessageBox.Show(ex.ToString)
'    End Try
'End Sub


'Private Sub setcontrol_payment()

'    If chk_payment.Checked = True Then
'        chk_default_charge.Enabled = True
'        chk_default_debit.Enabled = True
'        chk_default_credit.Enabled = True

'        chk_set_as_charge_account.Enabled = True
'        chk_set_as_debit_and_charge_at.Enabled = True

'    Else
'        chk_default_charge.Enabled = False
'        chk_default_debit.Enabled = False
'        chk_default_credit.Enabled = False

'        chk_set_as_charge_account.Enabled = False
'        chk_set_as_debit_and_charge_at.Enabled = False

'    End If

'End Sub


'Private Sub SetEnableDefault()
'    Dim vnt As String = ""
'    Dim strSQLCheck As String = ""

'    If chk_payment.Checked = False Then Exit Sub

'    chk_set_as_charge_account.Checked = True

'    If chk_default_charge.Checked = False Then
'        strSQLCheck = ""
'        strSQLCheck += " select isnull(count(*),0) as c from TB_DEAL_ACCOUNT "
'        strSQLCheck += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
'        strSQLCheck += " and default_charge='Y' " 'and account_number='" & txt_account_number.Text.Replace("'", "''") & "'"
'        If strMODE.ToUpper = "EDIT" Then
'            strSQLCheck += " and account_number<>'" & txt_account_number.Text.Replace("'", "''") & "'"
'        End If

'        vnt = conn.GetDataFromSQL(strSQLCheck)
'        If CDbl(vnt) = 0 Then 'if no payment account
'            chk_default_charge.Enabled = True
'            chk_default_charge.Checked = True
'        Else
'            chk_default_charge.Enabled = False
'        End If
'    Else
'        chk_default_charge.Enabled = True
'    End If


'    If chk_default_debit.Checked = False Then
'        strSQLCheck = ""
'        strSQLCheck += " select isnull(count(*),0) as c from TB_DEAL_ACCOUNT "
'        strSQLCheck += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
'        strSQLCheck += " and default_debit='Y' " 'and account_number='" & txt_account_number.Text.Replace("'", "''") & "'"
'        If strMODE.ToUpper = "EDIT" Then
'            strSQLCheck += " and account_number<>'" & txt_account_number.Text.Replace("'", "''") & "'"
'        End If

'        vnt = conn.GetDataFromSQL(strSQLCheck)
'        If CDbl(vnt) = 0 Then 'if no payment accoun
'            chk_default_debit.Enabled = True
'            chk_default_debit.Checked = True
'        Else
'            chk_default_debit.Enabled = False
'        End If
'    Else
'        chk_default_debit.Enabled = True
'    End If

'    If chk_default_credit.Checked = False Then
'        strSQLCheck = ""
'        strSQLCheck += " select isnull(count(*),0) as c from TB_DEAL_ACCOUNT "
'        strSQLCheck += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
'        strSQLCheck += " and default_credit='Y' " 'and account_number='" & txt_account_number.Text.Replace("'", "''") & "'"
'        If strMODE.ToUpper = "EDIT" Then
'            strSQLCheck += " and account_number<>'" & txt_account_number.Text.Replace("'", "''") & "'"
'        End If

'        vnt = conn.GetDataFromSQL(strSQLCheck)
'        If CDbl(vnt) = 0 Then 'if no payment accoun
'            chk_default_credit.Enabled = True
'            chk_default_credit.Checked = True
'        Else
'            chk_default_credit.Enabled = False
'        End If
'    Else
'        chk_default_credit.Enabled = True
'    End If

'End Sub