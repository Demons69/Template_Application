Imports Template_Application.CSQL
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Frm_DealSummary_User

    Public strID As String = ""
    Public strMODE As String = "ADD"
    Public chkInquiry As Boolean
    Private Const strALL = "--------Select--------"
    Private dsAccount As DataTable
    Private dsProduct As DataTable
    Dim conn As CSQL


    Private Sub Frm_DealSummary_User_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String
        cbo_User_Category_ID.Enabled = False
        cbo_Report_Category_ID.Enabled = False
        Me.KeyPreview = True

        Try

            grd_account.AutoGenerateColumns = False
            grd_product.AutoGenerateColumns = False

            conn = New CSQL
            conn.Connect()

            '-- Get parent company id
            If txt_company_id_parent.Text = "" Then
                txt_company_id_parent.Text = conn.GetDataFromSQL("SELECT top 1 company_id_parent from dbo.TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "'")

                If txt_company_id_parent.Text = "" Then txt_company_id_parent.Text = txt_company_id.Text

            End If

            Call FillComboALL()

            Select Case strMODE.ToUpper
                Case "ADD"

                    cbo_title.Text = "Mr."

                    'If Now.ToString("yyyy") > 2500 Then
                    '    txt_date_of_birth.Text = Now.ToString("dd") & "/" & Now.ToString("MM") & "/" & Now.ToString("yyyy") - 543
                    '    txt_reference_no.Text = Now.ToString("yyyy") - 543 & Now.ToString("MMddHHmmss")
                    'Else
                    '    txt_date_of_birth.Text = Now.ToString("dd") & "/" & Now.ToString("MM") & "/" & Now.ToString("yyyy")
                    '    txt_reference_no.Text = Now.ToString("yyyy") & Now.ToString("MMddHHmmss")
                    'End If

                    txt_date_of_birth.Text = Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)
                    txt_reference_no.Text = Now.ToString("yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat) & Now.ToString("MMddHHmmss")

                    txt_mobile_phone.Text = "0"
                    cbo_log_in_method.Text = "Login With Static Password Only"
                    cbo_auth_method.Text = "Authorize by token hardware"
                    txt_email.Text = "pwd_kcashconnectplus@kasikornbank.com"
                    txt_fax.Text = "0"
                    cbo_reference_type.Text = "Other"
                    cbo_event_template.Text = ""

                    'chk_across_client_flag.Checked = True

                Case Else
                    '--Get data from UMM User table
                    Call ShowData()

            End Select


            '------------------------------------
            '-- Load account by current companyid

            strSQL = "exec [SP_tp_UserAccount_Select] '" _
                & txt_company_id_parent.Text & "', '" & txt_user_id.Text & "'"
            dsAccount = conn.BindingDT(strSQL, "tblUserAccount")

            dsAccount.DefaultView.RowFilter = "company_id = '" & txt_company_id.Text & "'"
            grd_account.DataSource = dsAccount.DefaultView


            '------------------------------------
            '-- Load product by current companyid
            strSQL = "exec [SP_tp_UserProduct_Select] '" _
                & txt_company_id_parent.Text & "', '" & txt_user_id.Text & "'"
            dsProduct = conn.BindingDT(strSQL, "tblUserProduct")

            dsProduct.DefaultView.RowFilter = "company_id = '" & txt_company_id.Text & "'"
            grd_product.DataSource = dsProduct.DefaultView

            '-- Enable/Disable Grid account
            '--Call FillGridAccount()

            '-- Get across company 
            Call GetUserAcross()

            If Len(txt_revision_code.Text) > 0 Then
                Call SetScreenRevision()
            End If

        Catch ex As Exception
            MessageBox.Show("Unable to load data !!")
        End Try

    End Sub


    ''' <summary>
    ''' Fixed bug: Release note 0.35
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillGridAccount()

        For i = 0 To grd_account.RowCount - 1

            Select Case strMODE.ToUpper
                Case "EDIT"

                    If grd_account.Rows(i).Cells(0).Value = 0 Then

                        DirectCast(grd_account.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value = False

                        '-- View Acc Stt
                        'grd_account.Rows(i).Cells(2).Style.BackColor = Color.Gray
                        'grd_account.Rows(i).Cells(2).ReadOnly = True
                        DirectCast(grd_account.Rows(i).Cells(2), DataGridViewCheckBoxCell).Value = False

                        '--"SQ"
                        'grd_account.Rows(i).Cells(3).Style.BackColor = Color.Gray
                        'grd_account.Rows(i).Cells(3).ReadOnly = True
                        DirectCast(grd_account.Rows(i).Cells(3), DataGridViewCheckBoxCell).Value = False

                        '-- "Payment"
                        'grd_account.Rows(i).Cells(4).Style.BackColor = Color.Gray
                        'grd_account.Rows(i).Cells(4).ReadOnly = True
                        DirectCast(grd_account.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = False

                    Else

                        DirectCast(grd_account.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value = True

                        '--"View Acc Stt"
                        'grd_account.Rows(i).Cells(2).Style.BackColor = Color.White
                        'grd_account.Rows(i).Cells(2).ReadOnly = False

                        If grd_account.Rows(i).Cells(2).Value = 0 Then
                            DirectCast(grd_account.Rows(i).Cells(2), DataGridViewCheckBoxCell).Value = False
                        Else
                            DirectCast(grd_account.Rows(i).Cells(2), DataGridViewCheckBoxCell).Value = True
                        End If


                        '--"View SQ"
                        'grd_account.Rows(i).Cells(3).Style.BackColor = Color.White
                        'grd_account.Rows(i).Cells(3).ReadOnly = False

                        If grd_account.Rows(i).Cells(3).Value = 0 Then
                            DirectCast(grd_account.Rows(i).Cells(3), DataGridViewCheckBoxCell).Value = False
                        Else
                            DirectCast(grd_account.Rows(i).Cells(3), DataGridViewCheckBoxCell).Value = True
                        End If

                        '-- Payment
                        'grd_account.Rows(i).Cells(4).Style.BackColor = Color.White
                        'grd_account.Rows(i).Cells(4).ReadOnly = False

                        If grd_account.Rows(i).Cells(4).Value = 0 Then
                            DirectCast(grd_account.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = False
                        Else
                            DirectCast(grd_account.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = True
                        End If

                    End If

                Case "ADD"
                    DirectCast(grd_account.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value = True

                    'If chk_view_acc_stt_flag.Checked = True Then
                    '    grd_account.Rows(i).Cells("View Acc Stt").Style.BackColor = Color.White
                    '    grd_account.Rows(i).Cells("View Acc Stt").ReadOnly = False
                    '    DirectCast(grd_account.Rows(i).Cells("View Acc Stt"), DataGridViewCheckBoxCell).Value = True
                    'Else
                    '    grd_account.Rows(i).Cells("View Acc Stt").Style.BackColor = Color.Gray
                    '    grd_account.Rows(i).Cells("View Acc Stt").ReadOnly = True
                    '    DirectCast(grd_account.Rows(i).Cells("View Acc Stt"), DataGridViewCheckBoxCell).Value = False
                    'End If



                    'If chk_view_sq_flag.Checked = True Then
                    '    grd_account.Rows(i).Cells("SQ").Style.BackColor = Color.White
                    '    grd_account.Rows(i).Cells("SQ").ReadOnly = False
                    '    DirectCast(grd_account.Rows(i).Cells("SQ"), DataGridViewCheckBoxCell).Value = True
                    'Else
                    '    grd_account.Rows(i).Cells("SQ").Style.BackColor = Color.Gray
                    '    grd_account.Rows(i).Cells("SQ").ReadOnly = True
                    '    DirectCast(grd_account.Rows(i).Cells("SQ"), DataGridViewCheckBoxCell).Value = False
                    'End If


                    If chk_payment_maker_flag.Checked = True Or chk_payment_verifier_flag.Checked = True _
                        Or chk_payment_authoriser_flag.Checked = True Or chk_payment_sender_flag.Checked = True Then

                        'grd_account.Rows(i).Cells(4).Style.BackColor = Color.White
                        'grd_account.Rows(i).Cells(4).ReadOnly = False
                        DirectCast(grd_account.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = True
                    Else
                        'grd_account.Rows(i).Cells(4).Style.BackColor = Color.Gray
                        'grd_account.Rows(i).Cells(4).ReadOnly = True
                        DirectCast(grd_account.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = False
                    End If

            End Select


            ''-- status of checkboxs in grid account = inquiry checkbox on main form

            If chkInquiry Then

                '--"View Acc Stt"
                chk_view_acc_stt_flag.Checked = True
                'grd_account.Rows(i).Cells(2).Style.BackColor = Color.White
                'grd_account.Rows(i).Cells(2).ReadOnly = False

                '--"SQ"
                chk_view_sq_flag.Checked = True
                'grd_account.Rows(i).Cells(3).Style.BackColor = Color.White
                'grd_account.Rows(i).Cells(3).ReadOnly = False

            Else

                chk_view_acc_stt_flag.Checked = False
                'grd_account.Rows(i).Cells(2).Style.BackColor = Color.Gray
                'grd_account.Rows(i).Cells(2).ReadOnly = True


                chk_view_sq_flag.Checked = False
                'grd_account.Rows(i).Cells(3).Style.BackColor = Color.Gray
                'grd_account.Rows(i).Cells(3).ReadOnly = True
            End If

        Next

    End Sub


    Public Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_DEAL_UMM_USER] WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and user_id ='" + txt_user_id.Text.Replace("''", "'") + "' "
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()
            txt_user_id.Enabled = False

            cbo_gender.Text = IIf(res("gender") Is System.DBNull.Value, "", res("gender").ToString())
            cbo_title.Text = IIf(res("title") Is System.DBNull.Value, "", res("title").ToString())
            txt_firstname.Text = IIf(res("firstname") Is System.DBNull.Value, "", res("firstname").ToString())
            txt_lastname.Text = IIf(res("lastname") Is System.DBNull.Value, "", res("lastname").ToString())
            txt_user_id.Text = IIf(res("user_id") Is System.DBNull.Value, "", res("user_id").ToString())
            txt_date_of_birth.Text = get_date_to_control(res("date_of_birth"))
            txt_gcp_service_end_date.Text = get_date_to_control(res("gcp_service_end_date"))

            cbo_reference_type.Text = IIf(res("reference_type") Is System.DBNull.Value, "", res("reference_type").ToString())
            txt_reference_no.Text = IIf(res("reference_no") Is System.DBNull.Value, "", res("reference_no").ToString())
            txt_phone.Text = IIf(res("phone") Is System.DBNull.Value, "", res("phone").ToString())
            txt_mobile_phone.Text = IIf(res("mobile_phone") Is System.DBNull.Value, "", res("mobile_phone").ToString())
            cbo_log_in_method.Text = IIf(res("log_in_method") Is System.DBNull.Value, "", res("log_in_method").ToString())
            cbo_auth_method.Text = IIf(res("auth_method") Is System.DBNull.Value, "", res("auth_method").ToString())
            txt_email.Text = IIf(res("email") Is System.DBNull.Value, "", res("email").ToString())
            txt_token_no.Text = IIf(res("token_no") Is System.DBNull.Value, "", res("token_no").ToString())
            txt_fax.Text = IIf(res("fax") Is System.DBNull.Value, "", res("fax").ToString())

            cbo_User_Category_ID.Text = IIf(res("User_Category_ID") Is System.DBNull.Value, "", res("User_Category_ID").ToString())
            cbo_Report_Category_ID.Text = IIf(res("Report_Category_ID") Is System.DBNull.Value, "", res("Report_Category_ID").ToString())
            cbo_event_template.Text = IIf(res("event_template") Is System.DBNull.Value, "", res("event_template").ToString())


            '===================menu===============
            If IIf(res("view_acc_stt_flag") Is System.DBNull.Value, "", res("view_acc_stt_flag").ToString()) = "Y" Then
                chk_view_acc_stt_flag.Checked = True
            Else
                chk_view_acc_stt_flag.Checked = False
            End If
            If IIf(res("view_sq_flag") Is System.DBNull.Value, "", res("view_sq_flag").ToString()) = "Y" Then
                chk_view_sq_flag.Checked = True
            Else
                chk_view_sq_flag.Checked = False
            End If
            If IIf(res("view_bill_payment_flag") Is System.DBNull.Value, "", res("view_bill_payment_flag").ToString()) = "Y" Then
                chk_view_bill_payment_flag.Checked = True
            Else
                chk_view_bill_payment_flag.Checked = False
            End If
            If IIf(res("payment_maker_flag") Is System.DBNull.Value, "", res("payment_maker_flag").ToString()) = "Y" Then
                chk_payment_maker_flag.Checked = True
            Else
                chk_payment_maker_flag.Checked = False
            End If
            If IIf(res("payment_verifier_flag") Is System.DBNull.Value, "", res("payment_verifier_flag").ToString()) = "Y" Then
                chk_payment_verifier_flag.Checked = True
            Else
                chk_payment_verifier_flag.Checked = False
            End If
            If IIf(res("payment_authoriser_flag") Is System.DBNull.Value, "", res("payment_authoriser_flag").ToString()) = "Y" Then
                chk_payment_authoriser_flag.Checked = True
            Else
                chk_payment_authoriser_flag.Checked = False
            End If
            If IIf(res("payment_sender_flag") Is System.DBNull.Value, "", res("payment_sender_flag").ToString()) = "Y" Then
                chk_payment_sender_flag.Checked = True
            Else
                chk_payment_sender_flag.Checked = False
            End If
            If IIf(res("admin_maker_flag") Is System.DBNull.Value, "", res("admin_maker_flag").ToString()) = "Y" Then
                chk_admin_maker_flag.Checked = True
            Else
                chk_admin_maker_flag.Checked = False
            End If
            If IIf(res("admin_authoriser_flag") Is System.DBNull.Value, "", res("admin_authoriser_flag").ToString()) = "Y" Then
                chk_admin_authoriser_flag.Checked = True
            Else
                chk_admin_authoriser_flag.Checked = False
            End If
            If IIf(res("view_confidential_flag") Is System.DBNull.Value, "", res("view_confidential_flag").ToString()) = "Y" Then
                chk_view_confidential_flag.Checked = True
            Else
                chk_view_confidential_flag.Checked = False
            End If
            If IIf(res("super_user_flag") Is System.DBNull.Value, "", res("super_user_flag").ToString()) = "Y" Then
                chk_super_user_flag.Checked = True
            Else
                chk_super_user_flag.Checked = False
            End If


            'non_cms_stop_pay
            If IIf(res("non_cms_stop_pay") Is System.DBNull.Value, "", res("non_cms_stop_pay").ToString()) = "Y" Then
                chk_non_cms_stop_pay.Checked = True
            Else
                chk_non_cms_stop_pay.Checked = False
            End If
            'non_cms_stop_pay_auth
            If IIf(res("non_cms_stop_pay_auth") Is System.DBNull.Value, "", res("non_cms_stop_pay_auth").ToString()) = "Y" Then
                chk_non_cms_stop_pay_auth.Checked = True
            Else
                chk_non_cms_stop_pay_auth.Checked = False
            End If

            'chk_si_maker_flag
            If IIf(res("si_maker_flag") Is System.DBNull.Value, "", res("si_maker_flag").ToString()) = "Y" Then
                chk_si_maker_flag.Checked = True
            Else
                chk_si_maker_flag.Checked = False
            End If

            If IIf(res("si_authoriser_flag") Is System.DBNull.Value, "", res("si_authoriser_flag").ToString()) = "Y" Then
                chk_si_authoriser_flag.Checked = True
            Else
                chk_si_authoriser_flag.Checked = False
            End If


            If IIf(res("across_client_flag") Is System.DBNull.Value, "", res("across_client_flag").ToString()) = "Y" Then
                chk_across_client_flag.Checked = True
            Else
                chk_across_client_flag.Checked = False
            End If
        End If

        res.Close()
        res = Nothing

    End Sub


    Private Sub Show_Across()

        If Len(txt_company_id.Text) <= 0 Then Exit Sub

        Dim strSQL As String = ""
        Dim dt As DataTable
        conn = New CSQL
        conn.Connect()

        strSQL = "SP_tp_UserAcross_Select '" _
            & txt_company_id.Text & "', '" _
            & txt_company_id_parent.Text & "', '" _
            & txt_user_id.Text & "'"

        'conn.Fill_ComboBox(strSQL, lst_across_client_code)
        dt = conn.BindingDT(strSQL, "tblUserAcross")

        For i = 0 To dt.Rows.Count - 1

            If dt.Rows(i)(2) = 1 Then
                lst_across_client_code.Items.Add(dt.Rows(i)(1), True)
            Else
                lst_across_client_code.Items.Add(dt.Rows(i)(1))
            End If

        Next

        'Select IDX
        '	,citem
        '	, Selected
        '	,company_id
        'from @TblUserAcross

        ''-- Old P'yot code
        ''strSQL = "SELECT * FROM TB_DEAL_UMM_USER_ACROSS  WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and user_id ='" + txt_user_id.Text.Replace("''", "'") + "' "
        'res = conn.GetDataReader(strSQL)
        'If res.HasRows = True Then
        '    While (res.Read())

        '        Dim i As Integer = 0
        '        For i = 0 To lst_across_client_code.Items.Count - 1
        '            Dim vnt As Object
        '            vnt = Split(lst_across_client_code.Items(i).ToString, "-")

        '            If RTrim(LTrim(vnt(0))) = res("client_code").ToString And RTrim(LTrim(vnt(1))) = res("company_id_across").ToString Then
        '                lst_across_client_code.SetItemChecked(i, True)
        '            End If
        '        Next

        '    End While
        'End If

    End Sub


    Private Sub lst_across_client_code_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_across_client_code.SelectedIndexChanged

        Call GetUserAcross()

    End Sub

    Private Sub GetUserAcross()
        Dim itemChecked As Object
        Dim objStr As Object
        Dim strCompGrp As String = String.Empty

        For Each itemChecked In lst_across_client_code.CheckedItems

            ' Use the IndexOf method to get the index of an item.
            'MessageBox.Show("Item with title: " + itemChecked.ToString() + " | " + _
            '                ", is checked. Checked state is: " + _
            '                lst_across_client_code.GetItemCheckState(lst_across_client_code.Items.IndexOf(itemChecked)).ToString() + ".")

            itemChecked.ToString()

            objStr = Split(itemChecked.ToString(), "-")

            strCompGrp += "'" & Trim(objStr(1).ToString()) & "', "

        Next


        If strCompGrp.Length > 0 Then
            strCompGrp = strCompGrp.Substring(0, strCompGrp.Length - 2)

            strCompGrp = strCompGrp & ", '" & txt_company_id.Text & "'"

            '-- Binding company to boxes of account/product
            'If grd_account.RowCount > 0 Then
            dsAccount.DefaultView.RowFilter = "company_id in (" + strCompGrp + ")"
            grd_account.DataSource = dsAccount.DefaultView
            'End If

            'If grd_product.RowCount > 0 Then
            dsProduct.DefaultView.RowFilter = "company_id in (" + strCompGrp + ")"
            grd_product.DataSource = dsProduct.DefaultView
            'End If


        Else

            'If grd_account.RowCount > 0 Then
            dsAccount.DefaultView.RowFilter = "company_id = '" + txt_company_id.Text + "'"
            grd_account.DataSource = dsAccount.DefaultView
            'End If

            'If grd_product.RowCount > 0 Then
            dsProduct.DefaultView.RowFilter = "company_id = '" + txt_company_id.Text + "'"
            grd_product.DataSource = dsProduct.DefaultView
            'End If

        End If

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


    Private Sub SaveData()
        Dim strMsg As String
        Dim strSQL As String
        Dim strEndDate As String
        Dim strRevDate As String = Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)

        Try

            conn = New CSQL
            conn.Connect()

            If txt_gcp_service_end_date.Text = "" Then
                strEndDate = "null"
            Else
                strEndDate = "'" & CDate(txt_gcp_service_end_date.Text).ToString("yyyy-MM-dd") & "'"
            End If



            Select Case strMODE.ToUpper
                Case "ADD"

                    strSQL = "exec [SP_tp_User_Insert] '" _
                      & txt_company_id.Text & "', '" _
                      & cbo_gender.Text & "', '" _
                      & cbo_title.Text & "', '" _
                      & txt_firstname.Text & "', '" _
                      & txt_lastname.Text & "', '" _
                      & txt_user_id.Text & "', '" _
                      & CDate(txt_date_of_birth.Text).ToString("yyyy-MM-dd") & "', '" _
                      & cbo_reference_type.Text & "', '" _
                      & txt_reference_no.Text & "', '" _
                      & txt_phone.Text & "', '" _
                      & txt_mobile_phone.Text & "', '" _
                      & IIf(chk_view_acc_stt_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_view_sq_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_view_bill_payment_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_payment_maker_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_payment_verifier_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_payment_authoriser_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_payment_sender_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_admin_maker_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_admin_authoriser_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_view_confidential_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_super_user_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_across_client_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_non_cms_stop_pay.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_non_cms_stop_pay_auth.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_si_maker_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_si_authoriser_flag.Checked, "Y", "N").ToString() & "', '" _
                      & cbo_log_in_method.Text & "', '" _
                      & cbo_auth_method.Text & "', '" _
                      & txt_email.Text & "', '" _
                      & txt_token_no.Text & "', '" _
                      & txt_fax.Text & "', '" _
                      & cbo_event_template.Text & "', " _
                      & IIf(Len(txt_revision_code.Text) = 0, "null", "'" & txt_revision_code.Text & "'") & ", " _
                      & IIf(Len(txt_revision_code.Text) = 0, "null", "'" & txt_revision_desc.Text & "'") & ", " _
                      & IIf(Len(txt_revision_code.Text) = 0, "null", "'" & strRevDate & "'")



                    If conn.GetDataFromSQL(strSQL) = 0 Then
                        MessageBox.Show("Invalid [Account] is duplicate.")
                    Else
                        MessageBox.Show("Save data was successful.")
                        Me.Close()
                    End If

                Case Else

                    strSQL = "exec [SP_tp_User_Update] '" _
                      & txt_company_id.Text & "', '" _
                      & cbo_gender.Text & "', '" _
                      & cbo_title.Text & "', '" _
                      & txt_firstname.Text & "', '" _
                      & txt_lastname.Text & "', '" _
                      & txt_user_id.Text & "', '" _
                      & CDate(txt_date_of_birth.Text).ToString("yyyy-MM-dd") & "', '" _
                      & cbo_reference_type.Text & "', '" _
                      & txt_reference_no.Text & "', '" _
                      & txt_phone.Text & "', '" _
                      & txt_mobile_phone.Text & "', '" _
                      & IIf(chk_view_acc_stt_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_view_sq_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_view_bill_payment_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_payment_maker_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_payment_verifier_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_payment_authoriser_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_payment_sender_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_admin_maker_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_admin_authoriser_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_view_confidential_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_super_user_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_across_client_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_non_cms_stop_pay.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_non_cms_stop_pay_auth.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_si_maker_flag.Checked, "Y", "N").ToString() & "', '" _
                      & IIf(chk_si_authoriser_flag.Checked, "Y", "N").ToString() & "', '" _
                      & cbo_log_in_method.Text & "', '" _
                      & cbo_auth_method.Text & "', '" _
                      & txt_email.Text & "', '" _
                      & txt_token_no.Text & "', '" _
                      & txt_fax.Text & "', " _
                      & strEndDate & ", '" _
                      & cbo_Report_Category_ID.Text & "', '" _
                      & cbo_User_Category_ID.Text & "', '" _
                      & cbo_event_template.Text & "', '" _
                      & txt_company_id_parent.Text & "', " _
                      & IIf(Len(txt_revision_code.Text) = 0, "null", "'" & txt_revision_code.Text & "'") & ", " _
                      & IIf(Len(txt_revision_code.Text) = 0, "null", "'" & txt_revision_desc.Text & "'") & ", " _
                      & IIf(Len(txt_revision_code.Text) = 0, "null", "'" & strRevDate & "'")

                    strMsg = conn.ExecuteNonQuery(strSQL)

                    If Len(strMsg) > 0 Then
                        MessageBox.Show(strMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

            End Select


            '==================account==============
            Dim i_lst_account As Integer = 0

            strSQL = " delete from TB_DEAL_UMM_USER_ACCOUNT WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and [user_id] ='" + txt_user_id.Text.Replace("''", "'") + "' "

            For i_lst_account = 0 To grd_account.RowCount - 1
                If grd_account.Rows(i_lst_account).Cells(0).FormattedValue = True Then

                    Dim vnt As Object
                    vnt = Split(grd_account.Rows(i_lst_account).Cells(1).Value, "||")

                    strSQL += vbCrLf & "insert into TB_DEAL_UMM_USER_ACCOUNT ( "
                    strSQL += vbCrLf & "company_id"
                    strSQL += vbCrLf & ",[user_id]"
                    strSQL += vbCrLf & ",account_number"
                    strSQL += vbCrLf & ",company_id_account,view_acc_stt_flag,view_sq_flag,payment_flag, revision_code, revision_date, revision_desc ) values ( "
                    strSQL += vbCrLf & "'" + txt_company_id.Text.Replace("''", "'") + "' " 'company_id
                    strSQL += vbCrLf & " , '" + txt_user_id.Text.Replace("''", "'") + "' " 'user_id
                    strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt(0))) + "' " 'account_number
                    strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt(1))) + "' "

                    '-- View acct stt
                    If grd_account.Rows(i_lst_account).Cells(2).FormattedValue = True Then
                        strSQL += vbCrLf & " ,'Y' "
                    Else
                        strSQL += vbCrLf & " ,'N' "
                    End If

                    '-- View SQ
                    If grd_account.Rows(i_lst_account).Cells(3).FormattedValue = True Then
                        strSQL += vbCrLf & " ,'Y' "
                    Else
                        strSQL += vbCrLf & " ,'N' "
                    End If

                    '-- Payment
                    If grd_account.Rows(i_lst_account).Cells(4).FormattedValue = True Then
                        strSQL += vbCrLf & " ,'Y' "
                    Else
                        strSQL += vbCrLf & " ,'N' "
                    End If

                    strSQL += vbCrLf & " ," + IIf(Len(txt_revision_code.Text) = 0, "null", "'" & txt_revision_code.Text & "'")
                    strSQL += vbCrLf & " ," + IIf(Len(txt_revision_code.Text) = 0, "null", "'" & strRevDate & "'")
                    strSQL += vbCrLf & " ," + IIf(Len(txt_revision_code.Text) = 0, "null", "'" & txt_revision_desc.Text & "'")

                    strSQL += vbCrLf & " ) "
                End If
            Next

            conn.ExecuteNonQuery(strSQL)

            strSQL = ""
            strSQL += vbCrLf & " delete from TB_DEAL_UMM_USER_PRODUCT WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and [user_id] ='" + txt_user_id.Text.Replace("''", "'") + "' "

            '================product=============

            For i = 0 To grd_product.RowCount - 1

                If grd_product.Rows(i).Cells(0).FormattedValue = True Then

                    Dim vnt_prd As Object
                    vnt_prd = Split(grd_product.Rows(i).Cells(1).Value, "-")

                    strSQL += vbCrLf & "insert into TB_DEAL_UMM_USER_PRODUCT ( company_id,[user_id],product_code,company_id_product, revision_code, revision_date, revision_desc ) values ( "
                    strSQL += vbCrLf & "'" + txt_company_id_parent.Text.Replace("''", "'") + "' " 'company_id
                    strSQL += vbCrLf & " , '" + txt_user_id.Text.Replace("''", "'") + "' " 'user_id
                    strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt_prd(0))) + "' "
                    strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt_prd(1))) + "' "
                    strSQL += vbCrLf & " ," + IIf(Len(txt_revision_code.Text) = 0, "null", "'" & txt_revision_code.Text & "'")
                    strSQL += vbCrLf & " ," + IIf(Len(txt_revision_code.Text) = 0, "null", "'" & strRevDate & "'")
                    strSQL += vbCrLf & " ," + IIf(Len(txt_revision_code.Text) = 0, "null", "'" & txt_revision_desc.Text & "'")


                    strSQL += vbCrLf & " ) "
                End If
            Next

            conn.ExecuteNonQuery(strSQL)


            'Dim i_lst_product As Integer = 0
            'For Each Entry In lst_product.CheckedItems
            '    'MessageBox.Show(lst_account.ToString())

            '    Dim vnt_prd As Object
            '    vnt_prd = Split(Entry.ToString, "-")

            '    strSQL += vbCrLf & "insert into TB_DEAL_UMM_USER_PRODUCT ( company_id,[user_id],product_code,company_id_product ) values ( "
            '    strSQL += vbCrLf & "'" + txt_company_id.Text.Replace("''", "'") + "' " 'company_id
            '    strSQL += vbCrLf & " , '" + txt_user_id.Text.Replace("''", "'") + "' " 'user_id
            '    strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt_prd(0))) + "' " 'account_number
            '    strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt_prd(1))) + "' "
            '    strSQL += vbCrLf & " ) "

            '    i_lst_product += 1
            'Next

            'conn.ExecuteNonQuery(strSQL)

            '===============lst_across_client_code================

            strSQL = ""
            strSQL += vbCrLf & " delete from TB_DEAL_UMM_USER_ACROSS WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and [user_id] ='" + txt_user_id.Text.Replace("''", "'") + "' "

            Dim strlist_client As String = ""
            Dim i_across_client_codet As Integer = 0
            For Each Entry In lst_across_client_code.CheckedItems
                'MessageBox.Show(lst_account.ToString())

                Dim vnt_client As Object
                vnt_client = Split(Entry.ToString, "-")

                strSQL += vbCrLf & "insert into TB_DEAL_UMM_USER_ACROSS ( company_id,[user_id],client_code,company_id_across, revision_code, revision_date, revision_desc ) values ( "
                strSQL += vbCrLf & "'" + txt_company_id.Text.Replace("''", "'") + "' " 'company_id
                strSQL += vbCrLf & " , '" + txt_user_id.Text.Replace("''", "'") + "' " 'user_id
                strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt_client(0))) + "' " 'account_number
                strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt_client(1))) + "' "
                strSQL += vbCrLf & " ," + IIf(Len(txt_revision_code.Text) = 0, "null", "'" & txt_revision_code.Text & "'")
                strSQL += vbCrLf & " ," + IIf(Len(txt_revision_code.Text) = 0, "null", "'" & strRevDate & "'")
                strSQL += vbCrLf & " ," + IIf(Len(txt_revision_code.Text) = 0, "null", "'" & txt_revision_desc.Text & "'")
                strSQL += vbCrLf & " ) "
                strlist_client += IIf(strlist_client = "", "", ",") & RTrim(LTrim(vnt_client(0)))
                i_across_client_codet += 1
            Next

            'across_client_code
            strSQL += vbCrLf & " update TB_DEAL_UMM_USER set "
            strSQL += vbCrLf & " across_client_code='" & strlist_client.Replace("'", "''") & "'"
            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "

            conn.ExecuteNonQuery(strSQL)

            MessageBox.Show("Save data was successful.")

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub chk_across_client_flag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_across_client_flag.CheckedChanged

        If chk_across_client_flag.Checked Then

            Call Show_Across()
        Else
            lst_across_client_code.Items.Clear()
        End If

    End Sub


    Private Sub SetScreenRevision()

        lbHead.Text = "Revision User"
        Call DisableALL()

        Select Case txt_revision_code.Text.ToUpper

            Case "Rev0003".ToUpper, "Rev0077".ToUpper
                DisableALL(True)

            Case "Rev0005".ToUpper
                '--User - Disable User Account
                txt_gcp_service_end_date.Enabled = True
                'grp_tool.Enabled = True

            Case "Rev0026".ToUpper, "Rev0071".ToUpper
                '-- Add User Client Relation
                chk_across_client_flag.Enabled = True
                lst_across_client_code.Enabled = True
                btn_client_all.Enabled = True
                btn_client_clear.Enabled = True

                grd_account.Enabled = True
                btn_account_all.Enabled = True
                btn_account_clear.Enabled = True

                grd_product.Enabled = True
                btn_product_all.Enabled = True
                btn_product_clear.Enabled = True

            Case "Rev0056".ToUpper, "Rev0068".ToUpper, "Rev0069".ToUpper _
                , "Rev0078".ToUpper, "Rev0079".ToUpper, "Rev0080".ToUpper _
                , "Rev0081".ToUpper, "Rev0082".ToUpper

                txt_token_no.Enabled = True

            Case "Rev0057".ToUpper
                txt_email.Enabled = True

            Case "Rev0058".ToUpper
                txt_mobile_phone.Enabled = True
                txt_phone.Enabled = True
                txt_fax.Enabled = True

            Case "Rev0059".ToUpper
                '-- General profile
                cbo_title.Enabled = True
                cbo_gender.Enabled = True
                txt_firstname.Enabled = True
                txt_lastname.Enabled = True
                txt_date_of_birth.Enabled = True
                cbo_reference_type.Enabled = True
                txt_reference_no.Enabled = True
                txt_phone.Enabled = True
                txt_mobile_phone.Enabled = True
                txt_email.Enabled = True
                txt_fax.Enabled = True


            Case "Rev0060".ToUpper
                cbo_log_in_method.Enabled = True
                cbo_auth_method.Enabled = True

            Case "Rev0061".ToUpper, "Rev0062".ToUpper
                cbo_User_Category_ID.Enabled = True
                cbo_Report_Category_ID.Enabled = True
                btn_clear_category.Enabled = True
                btn_ChangeCategory.Enabled = True

                btn_PaymentMaker.Enabled = True
                btn_PaymentAuth.Enabled = True
                btn_Admin.Enabled = True
                chk_view_acc_stt_flag.Enabled = True
                chk_view_sq_flag.Enabled = True
                chk_view_bill_payment_flag.Enabled = True
                chk_payment_maker_flag.Enabled = True
                chk_payment_verifier_flag.Enabled = True
                chk_payment_authoriser_flag.Enabled = True
                chk_payment_sender_flag.Enabled = True
                chk_admin_maker_flag.Enabled = True
                chk_admin_authoriser_flag.Enabled = True

                chk_non_cms_stop_pay.Enabled = True
                chk_non_cms_stop_pay_auth.Enabled = True
                chk_si_maker_flag.Enabled = True
                chk_si_authoriser_flag.Enabled = True
                txt_token_no.Enabled = True

            Case "Rev0064".ToUpper, "Rev0065".ToUpper
                grd_account.Enabled = True
                btn_account_all.Enabled = True
                btn_account_clear.Enabled = True

            Case "Rev0066".ToUpper, "Rev0067".ToUpper
                grd_product.Enabled = True
                btn_product_all.Enabled = True
                btn_product_clear.Enabled = True

            Case "Rev0070".ToUpper
                DisableALL(True)
        End Select

    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""

        'chk_view_acc_stt_flag
        'chk_view_sq_flag
        'chk_view_bill_payment_flag
        'chk_payment_maker_flag
        'chk_payment_verifier_flag
        'chk_payment_authoriser_flag
        'chk_payment_sender_flag
        'chk_admin_maker_flag
        'chk_admin_authoriser_flag
        'chk_view_confidential_flag

        'chk_super_user_flag
        'chk_across_client_flag

        If chk_view_acc_stt_flag.Checked = False _
        And chk_view_sq_flag.Checked = False _
        And chk_view_bill_payment_flag.Checked = False _
        And chk_payment_maker_flag.Checked = False _
        And chk_payment_verifier_flag.Checked = False _
        And chk_payment_authoriser_flag.Checked = False _
        And chk_payment_sender_flag.Checked = False _
        And chk_admin_maker_flag.Checked = False _
        And chk_admin_authoriser_flag.Checked = False _
        And chk_view_confidential_flag.Checked = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Menu list]"
        End If


        If cbo_gender.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [gender]"
        End If
        If cbo_title.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Title]"
        End If
        If txt_firstname.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [User First Name]"
        End If
        If txt_lastname.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [User Last Name]"
        End If
        If txt_user_id.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [User ID]"
        End If

        If txt_date_of_birth.Text = "" Or Is_date(txt_date_of_birth.Text) = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid  [Date of Birth]"
        End If

        If txt_gcp_service_end_date.Text <> "" Then
            If txt_gcp_service_end_date.Text = "" Or Is_date(txt_gcp_service_end_date.Text) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [GCP Service End Date]"
            End If
        End If

        If cbo_reference_type.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Reference Type]"
        End If

        If txt_reference_no.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Reference No.]"
        End If

        'If txt_phone.Text = "" Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Phone]"
        'End If

        If txt_mobile_phone.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Mobile Phone]"
        End If

        If cbo_log_in_method.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Log in method]"
        End If

        If cbo_auth_method.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Auth Method]"
        End If

        If txt_email.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Email]"
        End If

        'If txt_token_no.Text = "" Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Token No.]"
        'End If

        If txt_fax.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Fax]"
        End If

        '==================account==============
        'Dim i_lst_account As Integer = 0

        'For Each Entry In lst_account.CheckedItems
        '    ' MessageBox.Show(lst_account.ToString())
        '    i_lst_account += 1
        'Next



        '================product=============
        'Dim i_lst_product As Integer = 0
        'For Each Entry In lst_account.CheckedItems
        '    ' MessageBox.Show(lst_account.ToString())
        '    i_lst_product += 1
        'Next


        Return strErr
    End Function


    Public Sub FillComboCategory()

        Dim strSQL As String = ""
        Dim strCrit As String = ""
        Dim mParentCode As String = ""

        strSQL = ""
        strSQL += vbCrLf & "   select "
        strSQL += vbCrLf & "   #all.company_id "
        strSQL += vbCrLf & "   from "
        strSQL += vbCrLf & "   ( "
        strSQL += vbCrLf & "   SELECT company_id "
        strSQL += vbCrLf & "   FROM "
        strSQL += vbCrLf & "   TB_DEAL_UMM_COMPANY a "
        strSQL += vbCrLf & "   where a.company_id='" & txt_company_id.Text.Replace("'", "''") & "' AND a.set_as_parent_company='Y' "
        strSQL += vbCrLf & "   UNION "
        strSQL += vbCrLf & "   SELECT company_id_parent "
        strSQL += vbCrLf & "   FROM "
        strSQL += vbCrLf & "   TB_DEAL_UMM_COMPANY a "
        strSQL += vbCrLf & "   where a.company_id='" & txt_company_id.Text.Replace("'", "''") & "' AND a.set_as_parent_company='N' "
        strSQL += vbCrLf & "   ) #all "

        mParentCode = conn.GetDataFromSQL(strSQL)


        strCrit = ""
        strSQL = ""
        strSQL += vbCrLf & " SELECT "

        strSQL += vbCrLf & " ,a.User_Category_ID  as [User Category ID]"


        strSQL += vbCrLf & " FROM "
        strSQL += vbCrLf & "  [TB_CATEGORY] a "
        strSQL += vbCrLf & " where a.[company_id] "
        strSQL += vbCrLf & " ORDER BY   a.seq "

    End Sub

    Private Sub btn_ChangeCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ChangeCategory.Click
        Dim mFrm_LookupData As Frm_LookupData
        Dim strSQL As String = ""
        Dim strCrit As String = ""

        strSQL = ""

    
        strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " a.[company_id] = '" & txt_company_id_parent.Text & "'"



        strSQL = ""
        strSQL += vbCrLf & " SELECT "
        strSQL += vbCrLf & " a.[company_id]  as [Company ID] " '1
        strSQL += vbCrLf & " ,a.User_Category_ID  as [User Category ID]" ''2
        strSQL += vbCrLf & " ,a.Report_Category_ID  as [Report Category ID]" '3
        strSQL += vbCrLf & " ,a.User_Category_Name as [User Category Name]" '4
        strSQL += vbCrLf & " ,a.Report_Category_Name as [Report Category Name]" '5
        strSQL += vbCrLf & " ,a.seq as [seq]" '6

        strSQL += vbCrLf & " FROM "
        strSQL += vbCrLf & "  [TB_CATEGORY] a "
        strSQL += vbCrLf & strCrit
        strSQL += vbCrLf & " ORDER BY   a.seq "


        ' Frm_LookupData.Show()
        txt_temp.Text = ""
        mFrm_LookupData = New Frm_LookupData()
        mFrm_LookupData.SET_SQL = strSQL
        mFrm_LookupData.txtObject = txt_temp

        mFrm_LookupData.ShowDialog()
        If txt_temp.Text <> "" Then


            If UBound(Split(txt_temp.Text, "||")) Then

                cbo_User_Category_ID.Text = Split(txt_temp.Text, "||")(1)
                cbo_Report_Category_ID.Text = Split(txt_temp.Text, "||")(2)
               
            End If


        End If
    End Sub


#Region "First/Last name"

    Private Sub AutoNameLogin()
        On Error Resume Next
        If txt_firstname.Text = "" Then Exit Sub
        If txt_user_id.Text <> "" Then Exit Sub
        '     If txt_lastname.Text = "" Then Exit Sub
        Dim strNaming As String = ""
        Dim iMaxChar As Double = 0

        strNaming = txt_firstname.Text

        strNaming = Replace(strNaming, " ", "")
        strNaming = Replace(strNaming, "-", "")
        strNaming = Replace(strNaming, "_", "")
        strNaming = Replace(strNaming, ".", "")
        strNaming = Replace(strNaming, "'", "")


        If strNaming.Length >= 8 Then
            strNaming = strNaming.Substring(0, 8)
            iMaxChar = 8
        Else 'If txt_firstname.Text.Length >= 8 Then
            'strNaming = strNaming
            iMaxChar = strNaming.Length
        End If 'If txt_firstname.Text.Length >= 8 Then

        Dim strSQL As String = ""
        Dim vnt As String = ""
        strSQL = ""
        strSQL += " select isnull(count(*),0) as c from TB_DEAL_UMM_USER "
        strSQL += "  where company_id='" & txt_company_id.Text.Replace("'", "''") & "' "
        strSQL += "  and firstname like '" & txt_firstname.Text.Substring(0, iMaxChar).Replace("'", "''") & "%' "
        vnt = conn.GetDataFromSQL(strSQL)

        If CDbl(vnt) > 0 Then
            If iMaxChar >= 6 Then
                strNaming = strNaming.Substring(0, 6) & Format(CDbl(vnt), "00")
            Else
                strNaming = strNaming.Substring(0, iMaxChar) & Format(CDbl(vnt), "00")
            End If

        End If
        txt_user_id.Text = strNaming


        'Dim fname As String = txt_firstname.Text
        'Dim lname As String = txt_lastname.Text

        'fname = Replace(fname, " ", "")
        'fname = Replace(fname, "-", "")
        'fname = Replace(fname, "_", "")
        'fname = Replace(fname, ".", "")

        'lname = Replace(lname, " ", "")
        'lname = Replace(lname, "-", "")
        'lname = Replace(lname, "_", "")
        'lname = Replace(lname, ".", "")

        'Dim iCutLast As Integer = 0
        'Dim iCutFirst As Integer = 0

        'If lname.Length >= 3 Then
        '    iCutLast = 3
        'Else
        '    iCutLast = lname.Length
        'End If

        'If fname.Length >= 5 Then
        '    iCutFirst = 5
        'Else
        '    iCutFirst = fname.Length
        'End If

        ''  If lname.Length >= 3 And fname.Length >= 5 Then
        'txt_user_id.Text = lname.Substring(0, iCutLast) & fname.Substring(0, iCutFirst)
        'txt_user_id.Text = txt_user_id.Text.ToUpper()
        'End If


    End Sub

    Private Sub txt_firstname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_firstname.Validated
        txt_firstname.Text = txt_firstname.Text.ToUpper
        Call AutoNameLogin()
    End Sub

    Private Sub txt_lastname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_lastname.Validated
        txt_lastname.Text = txt_lastname.Text.ToUpper
        'Call AutoNameLogin()
    End Sub

    Private Sub txt_user_id_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_user_id.Validated
        txt_user_id.Text = txt_user_id.Text.ToUpper
    End Sub

#End Region

#Region "Button Select/UnSelect all"


    Private Sub btn_account_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_account_all.Click
        Dim i As Integer

        For i = 0 To grd_account.RowCount - 1
            DirectCast(grd_account.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value = True

            ''==============
            ''-- "View Acc Stt"

            'If chk_view_acc_stt_flag.Checked = True Then
            '    grd_account.Rows(i).Cells(2).Style.BackColor = Color.White
            '    grd_account.Rows(i).Cells(2).ReadOnly = False
            '    DirectCast(grd_account.Rows(i).Cells(2), DataGridViewCheckBoxCell).Value = True
            'Else
            '    grd_account.Rows(i).Cells(2).Style.BackColor = Color.Gray
            '    grd_account.Rows(i).Cells(2).ReadOnly = True
            '    DirectCast(grd_account.Rows(i).Cells(2), DataGridViewCheckBoxCell).Value = False
            'End If


            'If chk_view_sq_flag.Checked = True Then
            '    grd_account.Rows(i).Cells(3).Style.BackColor = Color.White
            '    grd_account.Rows(i).Cells(3).ReadOnly = False
            '    DirectCast(grd_account.Rows(i).Cells(3), DataGridViewCheckBoxCell).Value = True
            'Else
            '    grd_account.Rows(i).Cells(3).Style.BackColor = Color.Gray
            '    grd_account.Rows(i).Cells(3).ReadOnly = True
            '    DirectCast(grd_account.Rows(i).Cells(3), DataGridViewCheckBoxCell).Value = False
            'End If

            'If chk_payment_maker_flag.Checked = True _
            '        Or chk_payment_verifier_flag.Checked = True _
            '        Or chk_payment_authoriser_flag.Checked = True _
            '        Or chk_payment_sender_flag.Checked = True Then

            '    grd_account.Rows(i).Cells(4).Style.BackColor = Color.White
            '    grd_account.Rows(i).Cells(4).ReadOnly = False
            '    DirectCast(grd_account.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = True
            'Else
            '    grd_account.Rows(i).Cells(4).Style.BackColor = Color.Gray
            '    grd_account.Rows(i).Cells(4).ReadOnly = True
            '    DirectCast(grd_account.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = False
            'End If

        Next

    End Sub

    Private Sub btn_account_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_account_clear.Click

        Dim i As Int16
        For i = 0 To grd_account.RowCount - 1

            DirectCast(grd_account.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value = False

            ''==============
            'If chk_view_acc_stt_flag.Checked = True Then
            '    grd_account.Rows(i).Cells(2).Style.BackColor = Color.White
            '    grd_account.Rows(i).Cells(2).ReadOnly = False
            '    ' DirectCast(grd_account.Rows(e.RowIndex).Cells("View Acc Stt"), DataGridViewCheckBoxCell).Value = True
            'Else
            '    grd_account.Rows(i).Cells(2).Style.BackColor = Color.Gray
            '    grd_account.Rows(i).Cells(2).ReadOnly = True
            '    DirectCast(grd_account.Rows(i).Cells(2), DataGridViewCheckBoxCell).Value = False
            'End If


            'If chk_view_sq_flag.Checked = True Then
            '    grd_account.Rows(i).Cells(3).Style.BackColor = Color.White
            '    grd_account.Rows(i).Cells(3).ReadOnly = False
            '    '  DirectCast(grd_account.Rows(i).Cells("SQ"), DataGridViewCheckBoxCell).Value = True
            'Else
            '    grd_account.Rows(i).Cells(3).Style.BackColor = Color.Gray
            '    grd_account.Rows(i).Cells(3).ReadOnly = True
            '    DirectCast(grd_account.Rows(i).Cells(3), DataGridViewCheckBoxCell).Value = False
            'End If



            'If chk_payment_maker_flag.Checked = True _
            '    Or chk_payment_verifier_flag.Checked = True _
            '    Or chk_payment_authoriser_flag.Checked = True _
            '    Or chk_payment_sender_flag.Checked = True Then

            '    grd_account.Rows(i).Cells(4).Style.BackColor = Color.White
            '    grd_account.Rows(i).Cells(4).ReadOnly = False
            '    '  DirectCast(grd_account.Rows(i).Cells("Payment"), DataGridViewCheckBoxCell).Value = True
            'Else
            '    grd_account.Rows(i).Cells(4).Style.BackColor = Color.Gray
            '    grd_account.Rows(i).Cells(4).ReadOnly = True
            '    DirectCast(grd_account.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = False
            'End If

            'DirectCast(grd_account.Rows(i).Cells(2), DataGridViewCheckBoxCell).Value = False
            'DirectCast(grd_account.Rows(i).Cells(3), DataGridViewCheckBoxCell).Value = False
            'DirectCast(grd_account.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = False

        Next

    End Sub

    Private Sub btn_product_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_product_all.Click

        Dim i As Integer
        For i = 0 To grd_product.RowCount - 1
            DirectCast(grd_product.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value = True
        Next

    End Sub

    Private Sub btn_product_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_product_clear.Click

        Dim i As Integer
        For i = 0 To grd_product.RowCount - 1
            DirectCast(grd_product.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value = False
        Next

    End Sub

    Private Sub btn_client_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_client_all.Click
        Dim i As Integer
        For i = 0 To lst_across_client_code.Items.Count - 1
            lst_across_client_code.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub btn_client_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_client_clear.Click
        Dim i As Integer
        For i = 0 To lst_across_client_code.Items.Count - 1
            lst_across_client_code.SetItemChecked(i, False)
        Next
    End Sub

#End Region
 

    Private Sub cbo_log_in_method_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_log_in_method.SelectedIndexChanged
        ' If vnt1 = "Y" Then cbo_log_in_method.Items.Add("Login With Static Password Only")
        ' If vnt2 = "Y" Then cbo_log_in_method.Items.Add("Login With Static Password and SMS OTP(2Factor)")
        ' If vnt3 = "Y" Then cbo_log_in_method.Items.Add("Login With Static Password and  Token OTP(2Factor)")
        Dim strSQL As String = ""
        Dim vnt1 As String = ""

        cbo_auth_method.Items.Clear()

        Select Case cbo_log_in_method.Text
            Case "Login With Static Password Only"

                strSQL = ""
                strSQL += "select login_non from TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
                vnt1 = conn.GetDataFromSQL(strSQL)
                If vnt1 = "Y" Then
                    cbo_auth_method.Items.Add("Non authorize require")
                End If

                strSQL = ""
                strSQL += "select login_hw from TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
                vnt1 = conn.GetDataFromSQL(strSQL)
                If vnt1 = "Y" Then
                    cbo_auth_method.Items.Add("Authorize by token hardware")
                End If

                strSQL = ""
                strSQL += "select login_sms from TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
                vnt1 = conn.GetDataFromSQL(strSQL)
                If vnt1 = "Y" Then
                    cbo_auth_method.Items.Add("Authorize by token SMS")
                End If

            Case "Login With Static Password and SMS OTP(2Factor)"

                strSQL = ""
                strSQL += "select login_sms_non from TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
                vnt1 = conn.GetDataFromSQL(strSQL)
                If vnt1 = "Y" Then
                    cbo_auth_method.Items.Add("Non authorize require")
                End If

                strSQL = ""
                strSQL += "select login_sms_sms from TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
                vnt1 = conn.GetDataFromSQL(strSQL)
                If vnt1 = "Y" Then
                    cbo_auth_method.Items.Add("Authorize by token SMS")
                End If

            Case "Login With Static Password and  Token OTP(2Factor)"
                strSQL = ""
                strSQL += "select login_token_non from TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
                vnt1 = conn.GetDataFromSQL(strSQL)
                If vnt1 = "Y" Then
                    cbo_auth_method.Items.Add("Non authorize require")
                End If

                strSQL = ""
                strSQL += "select login_token_hw from TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
                vnt1 = conn.GetDataFromSQL(strSQL)
                If vnt1 = "Y" Then
                    cbo_auth_method.Items.Add("Authorize by token hardware")
                End If

            Case Else
                cbo_auth_method.Text = ""
                cbo_auth_method.Enabled = False
        End Select

        cbo_auth_method.Text = ""
        cbo_auth_method.Enabled = True
    End Sub


    Private Sub btn_clear_category_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear_category.Click
        Try

            Dim strSQL As String = ""
            strSQL = ""
            strSQL += " " & vbCrLf

            strSQL += vbCrLf & " update TB_DEAL_UMM_USER set "
            strSQL += vbCrLf & " seq = null "
            strSQL += vbCrLf & ", User_Category_ID = null "
            strSQL += vbCrLf & ", Report_Category_ID = null "
            strSQL += vbCrLf & ", User_Category_Name = null "
            strSQL += vbCrLf & " , Report_Category_Name = null "

            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "

            conn.ExecuteNonQuery(strSQL)

            MsgBox("Update was sucessful.")

            cbo_User_Category_ID.Text = ""
            cbo_Report_Category_ID.Text = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub btn_Admin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Admin.Click
        Call ClearMenuListALL()

        If chk_admin_maker_flag.Enabled = True Then
            chk_admin_maker_flag.Checked = True
        End If
        If chk_admin_authoriser_flag.Enabled = True Then
            chk_admin_authoriser_flag.Checked = True
        End If
        cbo_event_template.Text = ""

    End Sub


    Private Sub grd_account_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_account.CellValueChanged
        '-- todo: verify code here

        'If grd_account.Rows(e.RowIndex).Cells("Select").FormattedValue = True Then


        '    grd_account.Rows(e.RowIndex).Cells("View Acc Stt").Style.BackColor = Color.White
        '    grd_account.Rows(e.RowIndex).Cells("View Acc Stt").ReadOnly = False

        '    grd_account.Rows(e.RowIndex).Cells("SQ").Style.BackColor = Color.White
        '    grd_account.Rows(e.RowIndex).Cells("SQ").ReadOnly = False

        '    grd_account.Rows(e.RowIndex).Cells("Payment").Style.BackColor = Color.White
        '    grd_account.Rows(e.RowIndex).Cells("Payment").ReadOnly = False
        '    If strMODE = "ADD" Then

        '        If chk_view_acc_stt_flag.Checked = True Then
        '            grd_account.Rows(e.RowIndex).Cells("View Acc Stt").Style.BackColor = Color.White
        '            grd_account.Rows(e.RowIndex).Cells("View Acc Stt").ReadOnly = False
        '            ' DirectCast(grd_account.Rows(e.RowIndex).Cells("View Acc Stt"), DataGridViewCheckBoxCell).Value = True
        '        Else
        '            grd_account.Rows(e.RowIndex).Cells("View Acc Stt").Style.BackColor = Color.Gray
        '            grd_account.Rows(e.RowIndex).Cells("View Acc Stt").ReadOnly = True
        '            DirectCast(grd_account.Rows(e.RowIndex).Cells("View Acc Stt"), DataGridViewCheckBoxCell).Value = False
        '        End If



        '        If chk_view_sq_flag.Checked = True Then
        '            grd_account.Rows(e.RowIndex).Cells("SQ").Style.BackColor = Color.White
        '            grd_account.Rows(e.RowIndex).Cells("SQ").ReadOnly = False
        '            '  DirectCast(grd_account.Rows(e.RowIndex).Cells("SQ"), DataGridViewCheckBoxCell).Value = True
        '        Else
        '            grd_account.Rows(e.RowIndex).Cells("SQ").Style.BackColor = Color.Gray
        '            grd_account.Rows(e.RowIndex).Cells("SQ").ReadOnly = True
        '            DirectCast(grd_account.Rows(e.RowIndex).Cells("SQ"), DataGridViewCheckBoxCell).Value = False
        '        End If



        '        If chk_payment_maker_flag.Checked = True _
        '    Or chk_payment_verifier_flag.Checked = True _
        '    Or chk_payment_authoriser_flag.Checked = True _
        '    Or chk_payment_sender_flag.Checked = True Then
        '            grd_account.Rows(e.RowIndex).Cells("Payment").Style.BackColor = Color.White
        '            grd_account.Rows(e.RowIndex).Cells("Payment").ReadOnly = False
        '            '  DirectCast(grd_account.Rows(e.RowIndex).Cells("Payment"), DataGridViewCheckBoxCell).Value = True
        '        Else
        '            grd_account.Rows(e.RowIndex).Cells("Payment").Style.BackColor = Color.Gray
        '            grd_account.Rows(e.RowIndex).Cells("Payment").ReadOnly = True
        '            DirectCast(grd_account.Rows(e.RowIndex).Cells("Payment"), DataGridViewCheckBoxCell).Value = False
        '        End If
        '    End If ' If strMODE = "ADD" Then

        'Else
        '    grd_account.Rows(e.RowIndex).Cells("View Acc Stt").Style.BackColor = Color.Gray
        '    grd_account.Rows(e.RowIndex).Cells("View Acc Stt").ReadOnly = True

        '    grd_account.Rows(e.RowIndex).Cells("SQ").Style.BackColor = Color.Gray
        '    grd_account.Rows(e.RowIndex).Cells("SQ").ReadOnly = True

        '    grd_account.Rows(e.RowIndex).Cells("Payment").Style.BackColor = Color.Gray
        '    grd_account.Rows(e.RowIndex).Cells("Payment").ReadOnly = True

        '    DirectCast(grd_account.Rows(e.RowIndex).Cells("View Acc Stt"), DataGridViewCheckBoxCell).Value = False
        '    DirectCast(grd_account.Rows(e.RowIndex).Cells("SQ"), DataGridViewCheckBoxCell).Value = False
        '    DirectCast(grd_account.Rows(e.RowIndex).Cells("Payment"), DataGridViewCheckBoxCell).Value = False

        'End If
    End Sub

    Private Sub chk_view_acc_stt_flag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_view_acc_stt_flag.CheckedChanged
        Dim i As Double
        If strMODE = "ADD" Then

            For i = 0 To grd_account.RowCount - 1
                If chk_view_acc_stt_flag.Checked = True Then
                    DirectCast(grd_account.Rows(i).Cells(2), DataGridViewCheckBoxCell).Value = True
                Else
                    DirectCast(grd_account.Rows(i).Cells(2), DataGridViewCheckBoxCell).Value = False
                End If
            Next

        End If

    End Sub

    Private Sub chk_view_sq_flag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_view_sq_flag.CheckedChanged
        Dim i As Double
        If strMODE = "ADD" Then

            For i = 0 To grd_account.RowCount - 1
                If chk_view_sq_flag.Checked = True Then
                    DirectCast(grd_account.Rows(i).Cells(3), DataGridViewCheckBoxCell).Value = True
                Else
                    DirectCast(grd_account.Rows(i).Cells(3), DataGridViewCheckBoxCell).Value = False
                End If
            Next

        End If
    End Sub


#Region "Payment"

    Private Sub btn_PaymentMaker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PaymentMaker.Click
        Call ClearMenuListALL()
        If chk_view_acc_stt_flag.Enabled = True Then
            chk_view_acc_stt_flag.Checked = True
        End If
        If chk_payment_maker_flag.Enabled = True Then
            chk_payment_maker_flag.Checked = True
        End If
        If chk_non_cms_stop_pay.Enabled = True Then
            chk_non_cms_stop_pay.Checked = True
        End If
        If chk_si_maker_flag.Enabled = True Then
            chk_si_maker_flag.Checked = True
        End If
        cbo_event_template.Text = "STDMAKER"

    End Sub

    Private Sub btn_PaymentAuth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PaymentAuth.Click
        Call ClearMenuListALL()

        If chk_view_acc_stt_flag.Enabled = True Then
            chk_view_acc_stt_flag.Checked = True
        End If

        If chk_payment_authoriser_flag.Enabled = True Then
            chk_payment_authoriser_flag.Checked = True
        End If

        If chk_non_cms_stop_pay_auth.Enabled = True Then
            chk_non_cms_stop_pay_auth.Checked = True
        End If

        If chk_si_authoriser_flag.Enabled = True Then
            chk_si_authoriser_flag.Checked = True
        End If

        cbo_event_template.Text = "STDAUTH"

    End Sub

    Private Sub chk_payment_maker_flag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_payment_maker_flag.CheckedChanged
        Call PaymentSetGrid()
    End Sub


    Private Sub chk_payment_verifier_flag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_payment_verifier_flag.CheckedChanged
        Call PaymentSetGrid()
    End Sub

    Private Sub chk_payment_authoriser_flag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_payment_authoriser_flag.CheckedChanged
        Call PaymentSetGrid()
    End Sub

    Private Sub chk_payment_sender_flag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_payment_sender_flag.CheckedChanged
        Call PaymentSetGrid()
    End Sub

    Private Sub PaymentSetGrid()
        Dim i As Double
        If strMODE = "ADD" Then

            For i = 0 To grd_account.RowCount - 1
                If chk_payment_maker_flag.Checked = True _
                Or chk_payment_verifier_flag.Checked = True _
                Or chk_payment_authoriser_flag.Checked = True _
                Or chk_payment_sender_flag.Checked = True Then
                    DirectCast(grd_account.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = True
                Else
                    DirectCast(grd_account.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = False
                End If
            Next

        End If
    End Sub


#End Region

    Private Sub Frm_DealSummary_User_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DisableALL(Optional ByVal enableFlag As Boolean = False)
        Dim ctrl As Control
        For Each ctrl In Me.Controls

            If (ctrl.Name = "BT_Update") Or (ctrl.Name = "bt_close") Or (ctrl.Name = "grp_tool") Then
                ctrl.Enabled = True
            Else

                If Not TypeOf ctrl Is Label Then
                    ctrl.Enabled = enableFlag
                End If

            End If
        Next

    End Sub

    Private Sub DisableALLNoButton()
        Dim ctrl As Control
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is Button Then
                ctrl.Enabled = False
            Else
                ctrl.Enabled = True
            End If
        Next

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

    Public Sub FillComboALL()

        'Gender()
        '"# Dropdown List
        '- Female
        '- Male
        '- Other (default)"
        cbo_gender.Items.Clear()
        cbo_gender.Items.Add("Female")
        cbo_gender.Items.Add("Male")
        cbo_gender.Items.Add("Other")
        cbo_gender.Items.Add("")
        cbo_gender.Text = "Other" 'Other


        '# Dropdown List
        '- Mr.
        '- Miss
        '- Mistress
        '- Doctor
        cbo_title.Items.Clear()
        cbo_title.Items.Add("Mr.")
        cbo_title.Items.Add("Miss")
        cbo_title.Items.Add("Mistress")
        cbo_title.Items.Add("Doctor")
        cbo_title.Items.Add("KHUN")
        cbo_title.Items.Add("")


        'Reference(Type)
        '"# Dropdown List
        '- Personal ID
        '- Passport
        '- Other"
        cbo_reference_type.Items.Clear()
        cbo_reference_type.Items.Add("Personal ID")
        cbo_reference_type.Items.Add("Passport")
        cbo_reference_type.Items.Add("Other")
        cbo_reference_type.Items.Add("")


        'Log in method
        '"# แสดง Dropdown List
        '- Login With Static Password Only (default)
        '- Login With Static Password and SMS OTP(2Factor)
        '- Login With Static Password and  Token OTP(2Factor)"
        Dim strSQL As String = ""
        Dim vnt1 As String = ""
        Dim vnt2 As String = ""
        Dim vnt3 As String = ""

        strSQL = ""
        strSQL += "select login_flag from TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
        vnt1 = conn.GetDataFromSQL(strSQL)

        strSQL = ""
        strSQL += "select login_sms_flag from TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
        vnt2 = conn.GetDataFromSQL(strSQL)

        strSQL = ""
        strSQL += "select login_token_flag from TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
        vnt3 = conn.GetDataFromSQL(strSQL)

        'cbo_event_template

        'strSQL = " select distinct event_template as event_template   from   dbo.TB_DEAL_UMM_USER  a where event_template is not null order by a.event_template "
        strSQL = " SELECT code from dbo.TB_EVENT_TEMPLATE_MST order by code"
        conn.Fill_ComboBox(strSQL, cbo_event_template)

        cbo_log_in_method.Items.Clear()
        If vnt1 = "Y" Then cbo_log_in_method.Items.Add("Login With Static Password Only")
        If vnt2 = "Y" Then cbo_log_in_method.Items.Add("Login With Static Password and SMS OTP(2Factor)")
        If vnt3 = "Y" Then cbo_log_in_method.Items.Add("Login With Static Password and  Token OTP(2Factor)")

        'cbo_log_in_method.Items.Add("")
        'cbo_log_in_method.Text = "Login With Static Password Only" 'Login With Static Password Only
        'cbo_log_in_method

        'Auth(Method)
        '"# แสดง Dropdown List
        '- Non authorize require
        '- Authorize by token hardware (default)
        '- Authorize by token SMS"
        cbo_auth_method.Items.Clear()
        cbo_auth_method.Items.Add("Non authorize require")
        cbo_auth_method.Items.Add("Authorize by token hardware")
        cbo_auth_method.Items.Add("Authorize by token SMS")
        cbo_auth_method.Items.Add("")
        cbo_auth_method.Text = "Authorize by token hardware" 'Authorize by token hardware

    End Sub


    Private Sub ClearMenuListALL()
        chk_view_acc_stt_flag.Checked = False
        chk_view_sq_flag.Checked = False
        chk_view_bill_payment_flag.Checked = False
        chk_payment_maker_flag.Checked = False
        chk_payment_verifier_flag.Checked = False
        chk_payment_authoriser_flag.Checked = False
        chk_payment_sender_flag.Checked = False
        chk_admin_maker_flag.Checked = False
        chk_admin_authoriser_flag.Checked = False
        chk_non_cms_stop_pay.Checked = False
        chk_non_cms_stop_pay_auth.Checked = False
        chk_si_maker_flag.Checked = False
        chk_si_authoriser_flag.Checked = False

    End Sub


End Class


''--- comment out: casue of text firstname/lastname are access with ctl+v

'Private Sub AcceptKey(ByRef e As System.Windows.Forms.KeyPressEventArgs)
'    If (Microsoft.VisualBasic.Asc(e.KeyChar) <= Microsoft.VisualBasic.Asc("z") And (Microsoft.VisualBasic.Asc(e.KeyChar) >= Microsoft.VisualBasic.Asc("a"))) _
'         Or (Microsoft.VisualBasic.Asc(e.KeyChar) <= Microsoft.VisualBasic.Asc("Z") And (Microsoft.VisualBasic.Asc(e.KeyChar) >= Microsoft.VisualBasic.Asc("A"))) _
'        Or (Microsoft.VisualBasic.Asc(e.KeyChar) <= Microsoft.VisualBasic.Asc("9") And (Microsoft.VisualBasic.Asc(e.KeyChar) >= Microsoft.VisualBasic.Asc("0"))) _
'        Or Microsoft.VisualBasic.Asc(e.KeyChar) = Microsoft.VisualBasic.Asc("-") _
'         Or Microsoft.VisualBasic.Asc(e.KeyChar) = Microsoft.VisualBasic.Asc("_") _
'         Or Microsoft.VisualBasic.Asc(e.KeyChar) = Microsoft.VisualBasic.Asc(".") _
'         Or Microsoft.VisualBasic.Asc(e.KeyChar) = Microsoft.VisualBasic.Asc(" ") Then
'        'Allowed space
'        e.Handled = False
'        Exit Sub
'    Else
'        e.Handled = True
'    End If
'    ' Allowed backspace
'    If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
'        e.Handled = False
'    End If
'End Sub


'Private Sub txt_firstname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_firstname.KeyPress

'    AcceptKey(e)

'End Sub

'Private Sub txt_lastname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_lastname.KeyPress
'    AcceptKey(e)
'End Sub



'Private Sub SaveData()
'    Dim strValue As String = ""
'    Dim strFiledname As String = ""
'    Dim strSQL As String = ""

'    Try


'        conn = New CSQL
'        conn.Connect()

'        '========================add mode====================
'        If strMODE.ToUpper = "ADD" Then
'            strSQL = "SELECT * FROM [TB_DEAL_UMM_USER] WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "
'            If conn.HasRows(strSQL) = True Then
'                MessageBox.Show("Invalid [User] is duplicate.")
'                Exit Sub
'            End If

'            strFiledname += vbCrLf & "[company_id]"
'            strValue += vbCrLf & "N'" & txt_company_id.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[gender]"
'            strValue += vbCrLf & ",N'" & cbo_gender.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[title]"
'            strValue += vbCrLf & ",N'" & cbo_title.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[firstname]"
'            strValue += vbCrLf & ",N'" & txt_firstname.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[lastname]"
'            strValue += vbCrLf & ",N'" & txt_lastname.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[user_id]"
'            strValue += vbCrLf & ",N'" & txt_user_id.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[date_of_birth]"
'            strValue += vbCrLf & "," & get_date_sql(txt_date_of_birth.Text) & ""

'            strFiledname += vbCrLf & ",[gcp_service_end_date]"
'            strValue += vbCrLf & "," & get_date_sql(txt_gcp_service_end_date.Text) & ""

'            strFiledname += vbCrLf & ",[reference_type]"
'            strValue += vbCrLf & ",N'" & cbo_reference_type.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[reference_no]"
'            strValue += vbCrLf & ",N'" & txt_reference_no.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[phone]"
'            strValue += vbCrLf & ",N'" & txt_phone.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[mobile_phone]"
'            strValue += vbCrLf & ",N'" & txt_mobile_phone.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[log_in_method]"
'            strValue += vbCrLf & ",N'" & cbo_log_in_method.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[auth_method]"
'            strValue += vbCrLf & ",N'" & cbo_auth_method.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[email]"
'            strValue += vbCrLf & ",N'" & txt_email.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[token_no]"
'            strValue += vbCrLf & ",N'" & txt_token_no.Text.Replace("''", "'") & "'"

'            strFiledname += vbCrLf & ",[fax]"
'            strValue += vbCrLf & ",N'" & txt_fax.Text.Replace("''", "'") & "'"

'            'cbo_event_template
'            strFiledname += vbCrLf & ",[event_template]"
'            strValue += vbCrLf & ",N'" & cbo_event_template.Text.Replace("''", "'") & "'"

'            '---------menu---------
'            strFiledname += vbCrLf & ",[view_acc_stt_flag]"
'            If chk_view_acc_stt_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            strFiledname += vbCrLf & ",[view_sq_flag]"
'            If chk_view_sq_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            strFiledname += vbCrLf & ",[view_bill_payment_flag]"
'            If chk_view_bill_payment_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            strFiledname += vbCrLf & ",[payment_maker_flag]"
'            If chk_payment_maker_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            strFiledname += vbCrLf & ",[payment_verifier_flag]"
'            If chk_payment_verifier_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            strFiledname += vbCrLf & ",[payment_authoriser_flag]"
'            If chk_payment_authoriser_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            strFiledname += vbCrLf & ",[payment_sender_flag]"
'            If chk_payment_sender_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            strFiledname += vbCrLf & ",[admin_maker_flag]"
'            If chk_admin_maker_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            strFiledname += vbCrLf & ",[admin_authoriser_flag]"
'            If chk_admin_authoriser_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            strFiledname += vbCrLf & ",[view_confidential_flag]"
'            If chk_view_confidential_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            strFiledname += vbCrLf & ",[super_user_flag]"
'            If chk_super_user_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            strFiledname += vbCrLf & ",[across_client_flag]"
'            If chk_across_client_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            'non_cms_stop_pay
'            strFiledname += vbCrLf & ",[non_cms_stop_pay]"
'            If chk_non_cms_stop_pay.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If
'            'non_cms_stop_pay_auth
'            strFiledname += vbCrLf & ",[non_cms_stop_pay_auth]"
'            If chk_non_cms_stop_pay_auth.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If

'            strFiledname += vbCrLf & ",[si_maker_flag]"
'            If chk_si_maker_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If

'            strFiledname += vbCrLf & ",[si_authoriser_flag]"
'            If chk_si_authoriser_flag.Checked = True Then
'                strValue += vbCrLf & ",'Y'"
'            Else
'                strValue += vbCrLf & ",'N'"
'            End If



'            'use_across_client_flag
'            'strFiledname += vbCrLf & ",[use_across_client_flag]"
'            'If chk_use_across_client_flag.Checked = True Then
'            '    strValue += vbCrLf & ",'Y'"
'            'Else
'            '    strValue += vbCrLf & ",'N'"
'            'End If

'            strSQL = ""
'            strSQL += vbCrLf & "insert into [TB_DEAL_UMM_USER]  "
'            strSQL += vbCrLf & "(" & strFiledname & ")"
'            strSQL += vbCrLf & " VALUES (" & strValue & ")"

'            conn.ExecuteNonQuery(strSQL)

'            strSQL = " EXEC [sp_deal_category_generate] '" & txt_company_id_parent.Text.Replace("'", "''") & "' "

'            conn.ExecuteNonQuery(strSQL)

'            ' Me.Close()

'        End If ' If strMODE.ToUpper = "ADD" Then

'        '========================edit mode====================
'        If strMODE.ToUpper <> "ADD" Then
'            strSQL = ""
'            strSQL += vbCrLf & "update [TB_DEAL_UMM_USER] set "

'            '  strFiledname += vbCrLf & "[company_id]"
'            ' strValue += vbCrLf & "N'" & txt_company_id.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & "[gender]"
'            strSQL += vbCrLf & "=N'" & cbo_gender.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[title]"
'            strSQL += vbCrLf & "=N'" & cbo_title.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[firstname]"
'            strSQL += vbCrLf & "=N'" & txt_firstname.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[lastname]"
'            strSQL += vbCrLf & "=N'" & txt_lastname.Text.Replace("''", "'") & "'"

'            '  strFiledname += vbCrLf & ",[user_id]"
'            ' strValue += vbCrLf & ",N'" & txt_user_id.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[date_of_birth]"
'            strSQL += vbCrLf & "=" & get_date_sql(txt_date_of_birth.Text) & ""

'            strSQL += vbCrLf & ",[gcp_service_end_date]"
'            strSQL += vbCrLf & "=" & get_date_sql(txt_gcp_service_end_date.Text) & ""

'            strSQL += vbCrLf & ",[reference_type]"
'            strSQL += vbCrLf & "=N'" & cbo_reference_type.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[reference_no]"
'            strSQL += vbCrLf & "=N'" & txt_reference_no.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[phone]"
'            strSQL += vbCrLf & "=N'" & txt_phone.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[mobile_phone]"
'            strSQL += vbCrLf & "=N'" & txt_mobile_phone.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[log_in_method]"
'            strSQL += vbCrLf & "=N'" & cbo_log_in_method.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[auth_method]"
'            strSQL += vbCrLf & "=N'" & cbo_auth_method.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[email]"
'            strSQL += vbCrLf & "=N'" & txt_email.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[token_no]"
'            strSQL += vbCrLf & "=N'" & txt_token_no.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[fax]"
'            strSQL += vbCrLf & "=N'" & txt_fax.Text.Replace("''", "'") & "'"

'            strSQL += vbCrLf & ",[event_template]"
'            strSQL += vbCrLf & "=N'" & cbo_event_template.Text.Replace("''", "'") & "'"

'            '---------menu---------
'            strSQL += vbCrLf & ",[view_acc_stt_flag]"
'            If chk_view_acc_stt_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If
'            strSQL += vbCrLf & ",[view_sq_flag]"
'            If chk_view_sq_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If
'            strSQL += vbCrLf & ",[view_bill_payment_flag]"
'            If chk_view_bill_payment_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If
'            strSQL += vbCrLf & ",[payment_maker_flag]"
'            If chk_payment_maker_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If
'            strSQL += vbCrLf & ",[payment_verifier_flag]"
'            If chk_payment_verifier_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If
'            strSQL += vbCrLf & ",[payment_authoriser_flag]"
'            If chk_payment_authoriser_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If
'            strSQL += vbCrLf & ",[payment_sender_flag]"
'            If chk_payment_sender_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If
'            strSQL += vbCrLf & ",[admin_maker_flag]"
'            If chk_admin_maker_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If
'            strSQL += vbCrLf & ",[admin_authoriser_flag]"
'            If chk_admin_authoriser_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If
'            strSQL += vbCrLf & ",[view_confidential_flag]"
'            If chk_view_confidential_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If
'            strSQL += vbCrLf & ",[super_user_flag]"
'            If chk_super_user_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If
'            strSQL += vbCrLf & ",[across_client_flag]"
'            If chk_across_client_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            'non_cms_stop_pay
'            strSQL += vbCrLf & ",[non_cms_stop_pay]"
'            If chk_non_cms_stop_pay.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If
'            'non_cms_stop_pay_auth
'            strSQL += vbCrLf & ",[non_cms_stop_pay_auth]"
'            If chk_non_cms_stop_pay_auth.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            strSQL += vbCrLf & ",[si_maker_flag]"
'            If chk_si_maker_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If

'            strSQL += vbCrLf & ",[si_authoriser_flag]"
'            If chk_si_authoriser_flag.Checked = True Then
'                strSQL += vbCrLf & "='Y'"
'            Else
'                strSQL += vbCrLf & "='N'"
'            End If


'            'use_across_client_flag
'            'strSQL += vbCrLf & ",[use_across_client_flag]"
'            'If chk_use_across_client_flag.Checked = True Then
'            '    strSQL += vbCrLf & "='Y'"
'            'Else
'            '    strSQL += vbCrLf & "='N'"
'            'End If

'            strSQL += vbCrLf & ", seq= (SELECT TOP 1  a.seq from TB_CATEGORY a where a.company_id='" & txt_company_id_parent.Text.Replace("'", "''") & "' AND a.User_Category_ID ='" & cbo_User_Category_ID.Text.Replace("'", "''") & "' ) "
'            strSQL += vbCrLf & ", User_Category_ID='" & cbo_User_Category_ID.Text.Replace("'", "''") & "'"
'            strSQL += vbCrLf & ", User_Category_Name= (SELECT TOP 1  a.User_Category_Name from TB_CATEGORY a where a.company_id='" & txt_company_id_parent.Text.Replace("'", "''") & "' AND a.User_Category_ID ='" & cbo_User_Category_ID.Text.Replace("'", "''") & "' ) "
'            strSQL += vbCrLf & ", Report_Category_ID='" & cbo_Report_Category_ID.Text.Replace("'", "''") & "'"
'            strSQL += vbCrLf & ", Report_Category_Name= (SELECT TOP 1  a.Report_Category_Name from TB_CATEGORY a where a.company_id='" & txt_company_id_parent.Text.Replace("'", "''") & "' AND a.User_Category_ID ='" & cbo_User_Category_ID.Text.Replace("'", "''") & "' ) "

'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "
'            conn.ExecuteNonQuery(strSQL)
'            ' Me.Close()

'        End If ' If strMODE.ToUpper <> "ADD" Then
'        '-------
'        '================revision=============

'        If txt_revision_code.Text <> "" Then
'            strSQL = ""
'            strSQL += vbCrLf & "update [TB_DEAL_UMM_USER] set "
'            strSQL += vbCrLf & "[gcp_service_end_date]"
'            strSQL += vbCrLf & "=" & get_date_sql(txt_gcp_service_end_date.Text) & ""
'            strSQL += vbCrLf & ",[revision_code]"
'            strSQL += vbCrLf & "=N'" & txt_revision_code.Text.Replace("'", "''") & "'"
'            strSQL += vbCrLf & ",[revision_desc]"
'            strSQL += vbCrLf & "=N'" & txt_revision_desc.Text.Replace("'", "''") & "'"
'            strSQL += vbCrLf & ",[revision_date]"
'            strSQL += vbCrLf & "=getdate()"
'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "

'            strSQL += vbCrLf & " DELETE FROM dbo.TB_REVISION_HISTORY WHERE company_id='" + txt_company_id.Text.Replace("'", "''") + "'"
'            strSQL += vbCrLf & "   and revision_code in ('Rev0003','Rev0004','Rev0005') "

'            strSQL += vbCrLf & " insert into  TB_REVISION_HISTORY (company_id,revision_code,revision_desc,revision_date)" ' values (
'            'company_id,revision_code,revision_desc,revision_date,revision_reason
'            strSQL += vbCrLf & " select distinct company_id,revision_code,revision_desc,revision_date from  TB_DEAL_UMM_USER"
'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  " 'and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "
'            strSQL += vbCrLf & "   and revision_code in ('Rev0003','Rev0004','Rev0005')"


'            'strSQL += vbCrLf & " update  dbo.TB_CATEGORY_REPORT set print_flag='N'    "
'            'strSQL += vbCrLf & " WHERE [company_id]='" + txt_company_id.Text.Replace("''", "'") + "' "
'            'strSQL += vbCrLf & " and Report_Category_ID  in ( "
'            'strSQL += vbCrLf & " SELECT  b.Report_Category_ID FROM dbo.TB_DEAL_UMM_USER b  "
'            'strSQL += vbCrLf & " where b.[company_id]='" + txt_company_id.Text.Replace("''", "'") + "' and b.user_id='" + txt_user_id.Text.Replace("''", "'") + "'  )"


'            conn.ExecuteNonQuery(strSQL)

'        End If

'        ','Rev0025','Rev0026','Rev0027','Rev0028'

'        If txt_revision_code.Text = "Rev0025" _
'        Or txt_revision_code.Text = "Rev0026" _
'        Or txt_revision_code.Text = "Rev0027" _
'        Or txt_revision_code.Text = "Rev0028" _
'         Or txt_revision_code.Text = "Rev0029" Then

'            Dim strCode As String = txt_revision_code.Text
'            strSQL = ""

'            strSQL += vbCrLf & "update [TB_DEAL_UMM_USER] set "


'            strSQL += vbCrLf & " [revision_code_" & strCode & "]"
'            strSQL += vbCrLf & "=N'" & txt_revision_code.Text.Replace("'", "''") & "'"

'            strSQL += vbCrLf & ",[revision_desc_" & strCode & "]"
'            strSQL += vbCrLf & "=N'" & txt_revision_desc.Text.Replace("'", "''") & "'"

'            strSQL += vbCrLf & ",[revision_date_" & strCode & "]"
'            strSQL += vbCrLf & "=getdate()"

'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "


'            strSQL += vbCrLf & " DELETE FROM dbo.TB_REVISION_HISTORY WHERE company_id='" + txt_company_id.Text.Replace("'", "''") + "'"
'            ' strSQL += vbCrLf & "   and revision_code='" + txt_revision_code.Text.Replace("'", "''") + "' "
'            strSQL += vbCrLf & "   and revision_code in ('" & strCode & "') "

'            strSQL += vbCrLf & " insert into  TB_REVISION_HISTORY (company_id,revision_code,revision_desc,revision_date)"
'            'company_id,revision_code,revision_desc,revision_date,revision_reason
'            strSQL += vbCrLf & " select distinct company_id,revision_code_" & strCode & ",revision_desc_" & strCode & ",revision_date_" & strCode & " from  TB_DEAL_UMM_USER "
'            strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  " 'and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "
'            strSQL += vbCrLf & "   and revision_code_" & strCode & " in ('" & strCode & "') "



'            'strSQL += vbCrLf & " update  dbo.TB_CATEGORY_REPORT set print_flag='N'    "
'            'strSQL += vbCrLf & " WHERE [company_id]='" + txt_company_id.Text.Replace("''", "'") + "' "
'            'strSQL += vbCrLf & " and Report_Category_ID  in ( "
'            'strSQL += vbCrLf & " SELECT  b.Report_Category_ID FROM dbo.TB_DEAL_UMM_USER b  "
'            'strSQL += vbCrLf & " where b.[company_id]='" + txt_company_id.Text.Replace("''", "'") + "' and b.user_id='" + txt_user_id.Text.Replace("''", "'") + "'  )"


'            conn.ExecuteNonQuery(strSQL)
'        End If


'        '==================account==============
'        Dim i_lst_account As Integer = 0

'        strSQL = ""
'        strSQL += vbCrLf & " delete from TB_DEAL_UMM_USER_ACCOUNT WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and [user_id] ='" + txt_user_id.Text.Replace("''", "'") + "' "


'        For i_lst_account = 0 To grd_account.RowCount - 1
'            If grd_account.Rows(i_lst_account).Cells("select").FormattedValue = True Then

'                Dim vnt As Object
'                vnt = Split(grd_account.Rows(i_lst_account).Cells("Account").Value, "||")


'                strSQL += vbCrLf & "insert into TB_DEAL_UMM_USER_ACCOUNT ( "
'                strSQL += vbCrLf & "company_id"
'                strSQL += vbCrLf & ",[user_id]"
'                strSQL += vbCrLf & ",account_number"
'                strSQL += vbCrLf & ",company_id_account,view_acc_stt_flag,view_sq_flag,payment_flag  ) values ( "
'                strSQL += vbCrLf & "'" + txt_company_id.Text.Replace("''", "'") + "' " 'company_id
'                strSQL += vbCrLf & " , '" + txt_user_id.Text.Replace("''", "'") + "' " 'user_id
'                strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt(0))) + "' " 'account_number
'                strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt(1))) + "' "

'                If grd_account.Rows(i_lst_account).Cells("View Acc Stt").FormattedValue = True Then
'                    strSQL += vbCrLf & " ,'Y' "
'                Else
'                    strSQL += vbCrLf & " ,'N' "
'                End If

'                If grd_account.Rows(i_lst_account).Cells("SQ").FormattedValue = True Then
'                    strSQL += vbCrLf & " ,'Y' "
'                Else
'                    strSQL += vbCrLf & " ,'N' "
'                End If

'                If grd_account.Rows(i_lst_account).Cells("Payment").FormattedValue = True Then
'                    strSQL += vbCrLf & " ,'Y' "
'                Else
'                    strSQL += vbCrLf & " ,'N' "
'                End If


'                strSQL += vbCrLf & " ) "
'            End If
'        Next

'        conn.ExecuteNonQuery(strSQL)

'        'For Each Entry In lst_account.CheckedItems
'        '    ' MessageBox.Show(lst_account.ToString())

'        '    Dim vnt As Object
'        '    vnt = Split(Entry.ToString, "-")

'        '    strSQL += vbCrLf & "insert into TB_DEAL_UMM_USER_ACCOUNT ( company_id,[user_id],account_number,company_id_account ) values ( "
'        '    strSQL += vbCrLf & "'" + txt_company_id.Text.Replace("''", "'") + "' " 'company_id
'        '    strSQL += vbCrLf & " , '" + txt_user_id.Text.Replace("''", "'") + "' " 'user_id
'        '    strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt(0))) + "' " 'account_number
'        '    strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt(1))) + "' "
'        '    strSQL += vbCrLf & " ) "

'        '    i_lst_account += 1
'        'Next



'        strSQL = ""
'        strSQL += vbCrLf & " delete from TB_DEAL_UMM_USER_PRODUCT WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and [user_id] ='" + txt_user_id.Text.Replace("''", "'") + "' "

'        '================product=============
'        Dim i_lst_product As Integer = 0
'        For Each Entry In lst_product.CheckedItems
'            'MessageBox.Show(lst_account.ToString())

'            Dim vnt_prd As Object
'            vnt_prd = Split(Entry.ToString, "-")

'            strSQL += vbCrLf & "insert into TB_DEAL_UMM_USER_PRODUCT ( company_id,[user_id],product_code,company_id_product ) values ( "
'            strSQL += vbCrLf & "'" + txt_company_id.Text.Replace("''", "'") + "' " 'company_id
'            strSQL += vbCrLf & " , '" + txt_user_id.Text.Replace("''", "'") + "' " 'user_id
'            strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt_prd(0))) + "' " 'account_number
'            strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt_prd(1))) + "' "
'            strSQL += vbCrLf & " ) "

'            i_lst_product += 1
'        Next

'        conn.ExecuteNonQuery(strSQL)
'        '===============lst_across_client_code================

'        strSQL = ""
'        strSQL += vbCrLf & " delete from TB_DEAL_UMM_USER_ACROSS WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and [user_id] ='" + txt_user_id.Text.Replace("''", "'") + "' "

'        Dim strlist_client As String = ""
'        Dim i_across_client_codet As Integer = 0
'        For Each Entry In lst_across_client_code.CheckedItems
'            'MessageBox.Show(lst_account.ToString())

'            Dim vnt_client As Object
'            vnt_client = Split(Entry.ToString, "-")

'            strSQL += vbCrLf & "insert into TB_DEAL_UMM_USER_ACROSS ( company_id,[user_id],client_code,company_id_across ) values ( "
'            strSQL += vbCrLf & "'" + txt_company_id.Text.Replace("''", "'") + "' " 'company_id
'            strSQL += vbCrLf & " , '" + txt_user_id.Text.Replace("''", "'") + "' " 'user_id
'            strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt_client(0))) + "' " 'account_number
'            strSQL += vbCrLf & " ,'" + RTrim(LTrim(vnt_client(1))) + "' "
'            strSQL += vbCrLf & " ) "
'            strlist_client += IIf(strlist_client = "", "", ",") & RTrim(LTrim(vnt_client(0)))
'            i_across_client_codet += 1
'        Next

'        'across_client_code
'        strSQL += vbCrLf & " update TB_DEAL_UMM_USER set "
'        strSQL += vbCrLf & " across_client_code='" & strlist_client.Replace("'", "''") & "'"
'        strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "

'        conn.ExecuteNonQuery(strSQL)

'        Me.Close()
'    Catch ex As Exception
'        MessageBox.Show(ex.ToString)
'    End Try
'End Sub


''--- below code are in SetScreenRevision Sub

'        If txt_revision_code.Text.ToUpper = "Rev0025".ToUpper Then
'            Call DisableALL()

'            cbo_gender.Enabled = True
'            cbo_title.Enabled = True
'            txt_firstname.Enabled = True
'            txt_lastname.Enabled = True
'            txt_user_id.Enabled = True
'            txt_date_of_birth.Enabled = True
'            cbo_reference_type.Enabled = True
'            txt_reference_no.Enabled = True
'            txt_phone.Enabled = True
'            txt_mobile_phone.Enabled = True
'            cbo_log_in_method.Enabled = True
'            cbo_auth_method.Enabled = True
'            txt_email.Enabled = True
'            txt_token_no.Enabled = True
'            txt_fax.Enabled = True
'            cbo_event_template.Enabled = True

'            chk_super_user_flag.Enabled = True
'            chk_view_confidential_flag.Enabled = True
'            chk_across_client_flag.Enabled = True


'            grp_tool.Enabled = True
'            BT_Update.Enabled = True
'            bt_close.Enabled = True

'        End If

'        If txt_revision_code.Text.ToUpper = "Rev0026".ToUpper Then
'' Call DisableALL()

'            cbo_gender.Enabled = False
'            cbo_title.Enabled = False
'            txt_firstname.Enabled = False
'            txt_lastname.Enabled = False
'            txt_user_id.Enabled = False
'            txt_date_of_birth.Enabled = False
'            cbo_reference_type.Enabled = False
'            txt_reference_no.Enabled = False
'            txt_phone.Enabled = False
'            txt_mobile_phone.Enabled = False
'            cbo_log_in_method.Enabled = False
'            cbo_auth_method.Enabled = False
'            txt_email.Enabled = False
'            txt_token_no.Enabled = False

'            btn_clear_category.Enabled = False
'            btn_ChangeCategory.Enabled = False

'            grp_tool.Enabled = True
'            BT_Update.Enabled = True
'            bt_close.Enabled = True

'        End If

''If txt_revision_code.Text.ToUpper = "Rev0027".ToUpper Then
''    Call DisableALL()
''    btn_clear_category.Enabled = True
''    grp_tool.Enabled = True
''    BT_Update.Enabled = True
''    bt_close.Enabled = True
''End If

'        If txt_revision_code.Text.ToUpper = "Rev0028".ToUpper Then
'            Call DisableALL()
'            btn_clear_category.Enabled = True
'            btn_ChangeCategory.Enabled = True

'            chk_view_acc_stt_flag.Enabled = True
'            chk_view_sq_flag.Enabled = True
'            chk_view_bill_payment_flag.Enabled = True
'            chk_payment_maker_flag.Enabled = True
'            chk_payment_verifier_flag.Enabled = True
'            chk_payment_authoriser_flag.Enabled = True
'            chk_payment_sender_flag.Enabled = True
'            chk_admin_maker_flag.Enabled = True
'            chk_admin_authoriser_flag.Enabled = True

'            chk_non_cms_stop_pay.Enabled = True
'            chk_non_cms_stop_pay_auth.Enabled = True
'            chk_si_maker_flag.Enabled = True
'            chk_si_authoriser_flag.Enabled = True

'            grp_tool.Enabled = True
'            BT_Update.Enabled = True
'            bt_close.Enabled = True
'        End If

'        If txt_revision_code.Text.ToUpper = "Rev0029".ToUpper Then
'            Call DisableALL()

'            chk_across_client_flag.Enabled = True
'            lst_across_client_code.Enabled = True
'' lst_account.Enabled = True
'            grd_account.Enabled = True
'            grd_product.Enabled = True

'            grp_tool.Enabled = True
'            BT_Update.Enabled = True
'            bt_close.Enabled = True

'        End If