Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_DealSummary_main

    Dim conn As CSQL
    Public strMODE_Main As String = "NEW"
    Public strMODE As String = "ADD"
    Dim int_tab_main As Long = 0
    Public strREVISION_CODE As String = ""
    Public strREVISION_DESC As String = ""
    Public bIsViewOnly As Boolean = False

    Private Sub Frm_DealSummary_main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            initData()

            Select Case strMODE.ToUpper
                Case "ADD"

                    txt_client_code.Enabled = True
                    txt_companyname_en.Enabled = True
                    cbo_customer_type.Text = "อื่นๆ"
                    txt_tax_id.Text = "-"
                    cbo_customer_service_category.Text = "NON"
                    txt_contact_name.Text = "-"
                    txt_contact_department.Text = "-"
                    txt_contact_phone.Text = "0"
                    txt_contact_mobile.Text = "0"
                    txt_contact_email.Text = "pwd_kcashconnectplus@kasikornbank.com"

                    'Registered Address:
                    txt_registered_no.Text = "-"
                    txt_registered_street.Text = "-"
                    cbo_registered_country.Text = "Thailand"

                    chk_login_flag.Checked = True
                    chk_login_non.Enabled = True
                    chk_login_hw.Enabled = True
                    chk_login_sms.Enabled = True

                    btn_new_product.Enabled = False
                    btn_edit_product.Enabled = False
                    btn_delete_product.Enabled = False

                    btn_new_auth.Enabled = False
                    btn_edit_auth.Enabled = False
                    btn_delete_auth.Enabled = False

                    Call RefreshDuplicationAddress()

                Case "EDIT"

                    Call SearchData()

                    txt_client_code.Enabled = False
                    txt_companyname_en.Enabled = True

                    Call ShowData_DEAL_UMM_COMPANY()
                    Call SetGrid_Account()
                    Call SetGrid_Fee()
                    Call SetGrid_RMS()

                Case "REVISION"

                    '-- COMMENT: Set back to default "EDIT" mode; 
                    '-- just in case for any other form doesn't support revision mode.

                    strMODE = "EDIT"

                    'REVISION mode must be fill revision type before modify
                    If rad_revision.Checked = True Then

                        Dim mFrm_DealSummary_Revision_Select As New Frm_DealSummary_Revision_Select
                        Frm_DealSummary_Revision_Select.txtCode = txt_revision_code
                        Frm_DealSummary_Revision_Select.txtDesc = txt_revision_desc
                        Frm_DealSummary_Revision_Select.ShowDialog()
                        lb_head.Text = "REVISION: " & txt_revision_desc.Text


                        If txt_revision_code.Text = "" Then
                            Me.Close()
                            Exit Sub
                        End If

                        '-- Set Search company, insert history revision, lock screens

                        Call SearchData()
                        Call SetScreenRevision()

                        btn_print.Enabled = True
                        btn_print_sum.Enabled = True

                    End If

            End Select

            chk_deal_cover_inquiry.Enabled = True
            chk_deal_cover_payment.Enabled = True
            chk_deal_cover_admin.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub


    Private Sub initData()

        cbo_status.Items.Clear()
        cbo_status.Items.Add("Generate File")
        cbo_status.Items.Add("Ensured File")
        cbo_status.Items.Add("Revision File")
        cbo_status.Items.Add("Program Error")
        cbo_status.Items.Add("N/A")
        cbo_status.Text = "N/A"

        Me.KeyPreview = True
        conn = New CSQL
        conn.Connect()

        'บริษัทจำกัด
        cbo_customer_type.Text = "อื่นๆ"

        'initize tabs
        'Drop Downlist for MBA, MBB, MBC, CBA, CBB, CBC, SMEB, SMEC,NON

        cbo_registered_region.Items.Clear()
        cbo_registered_region.Items.Add("")
        cbo_registered_region.Items.Add("North Region")
        cbo_registered_region.Items.Add("South Region")
        cbo_registered_region.Items.Add("West Region")
        cbo_registered_region.Items.Add("East Region")
        cbo_registered_region.Items.Add("Center Region")
        'cbo_mailing_region

        cbo_mailing_region.Items.Clear()
        cbo_mailing_region.Items.Add("")
        cbo_mailing_region.Items.Add("North Region")
        cbo_mailing_region.Items.Add("South Region")
        cbo_mailing_region.Items.Add("West Region")
        cbo_mailing_region.Items.Add("East Region")
        cbo_mailing_region.Items.Add("Center Region")


        cbo_customer_service_category.Items.Clear()
        cbo_customer_service_category.Items.Add("MBA")
        cbo_customer_service_category.Items.Add("MBB")
        cbo_customer_service_category.Items.Add("MBC")
        cbo_customer_service_category.Items.Add("CBA")
        cbo_customer_service_category.Items.Add("CBB")
        cbo_customer_service_category.Items.Add("CBC")
        cbo_customer_service_category.Items.Add("SMEB")
        cbo_customer_service_category.Items.Add("SMEC")
        cbo_customer_service_category.Items.Add("NON")
        cbo_customer_service_category.Text = "NON"
        'cbo_customer_type
        Dim strSQL As String = ""

        strSQL = ""
        strSQL += " select #all.[CUSTOMER_TYPE] from ( "
        strSQL += " select [CUSTOMER_TYPE]  from  [TB_CUSTOMER_TYPE] "
        strSQL += " union  "
        strSQL += "  select customer_type  as [CUSTOMER_TYPE] from dbo.TB_DEAL_UMM_COMPANY where isnull(customer_type,'')<>'' "
        strSQL += "  ) #all order by #all.[CUSTOMER_TYPE] "
        conn.Fill_ComboBox(strSQL, cbo_customer_type)
        'cbo_registered_province
        strSQL = ""
        strSQL += " select #all.[Province] from ( "
        strSQL += " select [Province]  from  [TB_PROVINCE] "
        strSQL += " union  "
        strSQL += "  select registered_province  as [Province] from dbo.TB_DEAL_UMM_COMPANY where isnull(registered_province,'')<>'' "
        strSQL += " union  "
        strSQL += "  select mailing_province  as [Province] from dbo.TB_DEAL_UMM_COMPANY where isnull(mailing_province,'')<>'' "
        strSQL += "  ) #all order by #all.[Province] "
        conn.Fill_ComboBox(strSQL, cbo_registered_province)
        conn.Fill_ComboBox(strSQL, cbo_mailing_province)
        '
        strSQL = ""
        strSQL += " select #all.[COUNTRY] from ( "
        strSQL += " select [COUNTRY]  from  [TB_COUNTRY] "
        strSQL += " union  "
        strSQL += "  select registered_country  as [COUNTRY] from dbo.TB_DEAL_UMM_COMPANY where isnull(registered_country,'')<>'' "
        strSQL += " union  "
        strSQL += "  select mailing_country  as [COUNTRY] from dbo.TB_DEAL_UMM_COMPANY where isnull(mailing_country,'')<>'' "
        strSQL += "  ) #all order by #all.[COUNTRY] "
        conn.Fill_ComboBox(strSQL, cbo_registered_country)
        conn.Fill_ComboBox(strSQL, cbo_mailing_country)

        If Now.ToString("yyyy") > 2500 Then
            txt_registration_date.Text = Now.ToString("dd") & "/" & Now.ToString("MM") & "/" & Now.ToString("yyyy") - 543

        Else
            txt_registration_date.Text = Now.ToString("dd") & "/" & Now.ToString("MM") & "/" & Now.ToString("yyyy")
        End If

    End Sub

    Public Sub SetFormViewOnly()
        btnSave.Enabled = False
        btn_print.Enabled = False
        btn_print_dm.Enabled = False
        btn_print_sum.Enabled = True
        'account
        btn_new_account.Enabled = False
        btn_edit_account.Enabled = True
        btn_delete_account.Enabled = False
        'product
        btn_new_product.Enabled = False
        btn_edit_product.Enabled = True
        btn_delete_product.Enabled = False
        btn_revision_add_charge_package.Enabled = False
        'User
        btn_Addnew_User.Enabled = False
        btn_edit_user.Enabled = True
        btn_delete_user.Enabled = False

        btn_GenerateGroup.Enabled = False
        btn_CopyCategory.Enabled = False

        'auth
        btn_new_auth.Enabled = False
        btn_edit_auth.Enabled = True
        btn_delete_auth.Enabled = False

        'interface
        btn_new_interface.Enabled = False
        btn_edit_interface.Enabled = True
        btn_delete_interface.Enabled = False

        'fee
        btn_new_fee.Enabled = False
        btn_edit_fee.Enabled = True
        btn_delete_fee.Enabled = False

        'fee
        btn_new_rms.Enabled = False
        btn_edit_rms.Enabled = True
        btn_delete_rms.Enabled = False

    End Sub



#Region "GeneralCode"
    

    Private Sub btn_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub

    Private Sub rad_revision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_revision.CheckedChanged
        'Dim mFrm_DealSummary_List As New Frm_DealSummary_List
        'mFrm_DealSummary_List.ShowDialog()
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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Call SaveMain(True)
    End Sub

    Private Function ReplaceSpChar(ByVal text As String) As String
        Dim strTmp As String

        strTmp = Replace(text, "*", "")
        strTmp = Replace(strTmp, "%", "")
        strTmp = Replace(strTmp, """", "")

        strTmp = Replace(strTmp, "&", "")
        strTmp = Replace(strTmp, "@", "")
        strTmp = Replace(strTmp, "$", "")
        strTmp = Replace(strTmp, "!", "")
        strTmp = Replace(strTmp, "=", "")
        strTmp = Replace(strTmp, ">", "")
        strTmp = Replace(strTmp, "<", "")
        strTmp = Replace(strTmp, ";", "")
        strTmp = Replace(strTmp, "#", "")
        strTmp = Replace(strTmp, "{", "")
        strTmp = Replace(strTmp, "}", "")
        strTmp = Replace(strTmp, "[", "")
        strTmp = Replace(strTmp, "]", "")

        Return strTmp
    End Function

    Private Sub SaveMain(Optional ByVal IsShowMsg As Boolean = False)
        Dim strErr As String = ""

        ''-- VALIDATION PART
        txt_companyname_en.Text = ReplaceSpChar(txt_companyname_en.Text)

        If chk_deal_cover_inquiry.Checked = False And chk_deal_cover_payment.Checked = False And chk_deal_cover_admin.Checked = False Then
            strErr += "Invalid [Service Cover]"
        End If

        If (txt_revision_code.Text.ToUpper = "Rev0001".ToUpper And rad_revision.Checked = True) Then
            strErr += ValidationData_CreateCompanyProfile()
            strErr += ValidationData_Address()
        End If

        If txt_revision_code.Text.ToUpper = "Rev0002".ToUpper Then
            If txt_gcp_service_end_date.Text = "" Or Is_date(txt_gcp_service_end_date.Text) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Contact Point & Relationship->GCP Service End Date:]"
            End If
        End If

        If chk_login_flag.Checked = False And chk_login_sms_flag.Checked = False And chk_login_token_flag.Checked = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Login Method:]"
        Else

            If chk_login_flag.Checked = True Then
                If chk_login_non.Checked = False And chk_login_hw.Checked = False And chk_login_sms.Checked = False Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Login With Static Password Only]"
                End If
            End If

            If chk_login_sms_flag.Checked = True Then
                If chk_login_sms_non.Checked = False And chk_login_sms_sms.Checked = False Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Login With Static Password and SMS OTP(2Factor)]"
                End If
            End If

            If chk_login_token_flag.Checked = True Then
                If chk_login_token_non.Checked = False And chk_login_token_hw.Checked = False Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Login With Static Password and Token OTP(2Factor)]"
                End If
            End If

            If Len(txt_corporation_name.Text) > 40 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Corporation name is over than 40 characters."
            End If



        End If

        'chekcing client code
        Dim strSQL As String = ""

        strSQL = ""
        strSQL += " select isnull(count(*),0) as c from TB_DEAL_UMM_COMPANY"
        strSQL += "  where client_code='" & txt_client_code.Text.Replace("'", "''") & "' "
        strSQL += "  and company_id <> '" & txt_company_id.Text.Replace("'", "''") & "' "
        Dim vnt As String = conn.GetDataFromSQL(strSQL)
        If vnt <> "0" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Client Code] is Duplication"
        End If

        If rad_set_as_parent_company_y.Checked = True Then
            strSQL = ""
            strSQL += " select isnull(count(*),0) as c from TB_DEAL_UMM_COMPANY"
            strSQL += "  where set_as_parent_company='Y' and corporation_code='" & txt_corporation_code.Text.Replace("'", "''") & "' "
            strSQL += "  and company_id <> '" & txt_company_id.Text.Replace("'", "''") & "' "
            vnt = conn.GetDataFromSQL(strSQL)
            If vnt <> "0" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Corporation Code] is Duplication"
            End If
        End If


        Select Case strErr
            Case ""

                '----------------------------------------------
                '--- Save company profile

                If SaveData_CreateCompanyProfile() = False Then
                    Exit Sub
                Else

                    If rad_revision.Checked = False Then
                        btn_print.Enabled = True
                    End If

                    If IsShowMsg = True Then
                        MessageBox.Show("Save data was successful.")
                    End If


                    '-- Disable key data to protect data lost
                    txt_company_id.Enabled = False
                    txt_client_code.Enabled = False
                    txt_corporation_code.Enabled = False
                    txt_corporation_name.Enabled = False

                End If

            Case Else
                '-- validation error
                MessageBox.Show(strErr)
        End Select

    End Sub


    Private Sub Frm_DealSummary_main_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub Frm_DealSummary_main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If strMODE.ToUpper = "ADD" Then
            If MsgBox("Company Profile has not been saved?" & vbCrLf & "Do you want to save.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Frm_DealSummary_main_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub setDisableAllTab()

        For i = 0 To tab_main.TabPages.Count - 1

            tab_main.TabPages(i).Enabled = False

        Next

        ''====acccount===
        'btn_new_account.Enabled = False
        'btn_edit_account.Enabled = False
        'btn_delete_account.Enabled = False
        'grd_account.Enabled = False

        ''=====Tab_Products
        'btn_new_product.Enabled = False
        'btn_edit_product.Enabled = False
        'btn_delete_product.Enabled = False
        'grd_product.Enabled = False

        ''=====Tab_UMM_User
        'btn_Addnew_User.Enabled = False
        'btn_edit_user.Enabled = False
        'btn_delete_user.Enabled = False
        'grd_user.Enabled = False

        ''=====Tab_Category
        'btn_GenerateGroup.Enabled = False
        'btn_ViewGroup.Enabled = False
        'btn_CopyCategory.Enabled = False
        'grd_category.Enabled = False

        ''=====Tab_AuthorizationMatrix
        'btn_new_auth.Enabled = False
        'btn_edit_auth.Enabled = False
        'btn_delete_auth.Enabled = False
        'grd_auth.Enabled = False

        ''=====Tab_Inteface
        'btn_new_interface.Enabled = False
        'btn_new_interface_product.Enabled = False
        'btn_edit_interface.Enabled = False
        'btn_delete_interface.Enabled = False
        'grd_interface.Enabled = False

        ''====tab fee
        'btn_new_fee.Enabled = False
        'btn_edit_fee.Enabled = False
        'btn_delete_fee.Enabled = False
        'grd_fee.Enabled = False

        ''====tab rms
        'btn_new_rms.Enabled = False
        'btn_edit_rms.Enabled = False
        'btn_delete_rms.Enabled = False
        'grd_rms.Enabled = False

    End Sub

    Sub ClearAllControls(ByRef container As Object, Optional ByVal Recurse As Boolean = True _
       , Optional ByVal IsEnable As Boolean = False)

        'Clear all of the controls within the container object
        'If "Recurse" is true, then also clear controls within any sub-containers
        Dim ctrl As Control
        For Each ctrl In container.Controls
            If (ctrl.GetType() Is GetType(TextBox)) Then
                Dim txt As TextBox = CType(ctrl, TextBox)
                'txt.Text = ""
                txt.Enabled = IsEnable
            End If
            If (ctrl.GetType() Is GetType(CheckBox)) Then
                Dim chkbx As CheckBox = CType(ctrl, CheckBox)
                chkbx.Enabled = IsEnable
            End If
            If (ctrl.GetType() Is GetType(ComboBox)) Then
                Dim cbobx As ComboBox = CType(ctrl, ComboBox)
                cbobx.Enabled = IsEnable
            End If
            If (ctrl.GetType() Is GetType(RadioButton)) Then
                Dim cbobx As RadioButton = CType(ctrl, RadioButton)
                cbobx.Enabled = IsEnable
            End If
            If (ctrl.GetType() Is GetType(DateTimePicker)) Then
                Dim dtp As DateTimePicker = CType(ctrl, DateTimePicker)
                dtp.Enabled = IsEnable
            End If

            If Recurse Then
                If (ctrl.GetType() Is GetType(Panel)) Then
                    Dim pnl As Panel = CType(ctrl, Panel)
                    ClearAllControls(pnl, Recurse, IsEnable)
                End If
                If ctrl.GetType() Is GetType(GroupBox) Then
                    Dim grbx As GroupBox = CType(ctrl, GroupBox)
                    ClearAllControls(grbx, Recurse, IsEnable)
                End If

                If ctrl.GetType() Is GetType(TabPage) Then
                    '  Dim grbx As GroupBox = CType(ctrl, TabPage)
                    ClearAllControls(ctrl, Recurse, IsEnable)
                End If

            End If
        Next
    End Sub

    Private Sub SetScreenRevision()

        Dim strRevDate As String = Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)

        btn_print_dm.Enabled = False
        btn_print_sum.Enabled = False
        btn_Correction.Enabled = False
        btn_parent.Enabled = False

        btnSave.Enabled = True
        rad_set_as_parent_company_y.Enabled = False
        rad_set_as_parent_company_n.Enabled = False
        Call setDisableAllTab()

        Call ClearAllControls(tab_main, True, False)

        Select Case txt_revision_code.Text.ToUpper
            'Update Company Profile

            Case "Rev0002".ToUpper 'Disable GCP Service at Company Profile
                tab_main.TabPages(0).Enabled = True
                Call ClearAllControls(Tab_CreateCompany, True, True)

                txt_gcp_service_end_date.Enabled = True
                btnSave.Enabled = True

            Case "Rev0003".ToUpper, "Rev0077".ToUpper
                tab_main.TabPages(5).Enabled = True
                Call ClearAllControls(Tab_UMM_User, True, True)
                tab_main.TabPages(6).Enabled = True
                Call ClearAllControls(Tab_Category, True, True)

                '=====Tab_UMM_User
                grd_user.Enabled = True
                btn_Addnew_User.Enabled = True
                btn_edit_user.Enabled = True
                btn_delete_user.Enabled = True


                '=====Tab_Category
                grd_category.Enabled = True
                btn_GenerateGroup.Enabled = True
                btn_ViewGroup.Enabled = True
                btn_CopyCategory.Enabled = True

                'Disable User Profile
            Case "Rev0005".ToUpper
                tab_main.TabPages(5).Enabled = True
                Call ClearAllControls(Tab_UMM_User, True, True)

                btn_Addnew_User.Enabled = False
                btn_edit_user.Enabled = True
                btn_delete_user.Enabled = False
                grd_user.Enabled = True

            Case "Rev0006".ToUpper  '-Add BTR Account
                tab_main.TabPages(3).Enabled = True
                Call ClearAllControls(Tab_Accounts, True, True)

                btn_new_account.Enabled = True
                btn_edit_account.Enabled = True
                btn_delete_account.Enabled = True
                grd_account.Enabled = True

            Case "Rev0007".ToUpper 'Update Account
                tab_main.TabPages(3).Enabled = True
                Call ClearAllControls(Tab_Accounts, True, True)

                btn_new_account.Enabled = False
                btn_edit_account.Enabled = True
                btn_delete_account.Enabled = False
                grd_account.Enabled = True

            Case "Rev0009".ToUpper '  'Rev0009	Client Pickup Location Changing
                '=====Tab_Products
                tab_main.TabPages(4).Enabled = True
                Call ClearAllControls(Tab_Products, True, True)
                btn_new_product.Enabled = False
                btn_edit_product.Enabled = True
                btn_delete_product.Enabled = False
                grd_product.Enabled = True

            Case "Rev0012".ToUpper, "Rev0050".ToUpper
                tab_main.TabPages(4).Enabled = True
                Call ClearAllControls(Tab_Products, True, True)
                btn_new_product.Enabled = True
                btn_edit_product.Enabled = True
                grd_product.Enabled = True

                tab_main.TabPages(8).Enabled = True
                Call ClearAllControls(Tab_Inteface, True, True)

                btn_new_interface.Enabled = True
                btn_new_interface_product.Enabled = True
                btn_edit_interface.Enabled = True
                btn_delete_interface.Enabled = True


            Case "Rev0026".ToUpper 'Add User Client Relation
                '=====Tab_UMM_User
                tab_main.TabPages(5).Enabled = True
                Call ClearAllControls(Tab_UMM_User, True, True)

                btn_Addnew_User.Enabled = False
                btn_edit_user.Enabled = True
                grd_user.Enabled = True

                '=====Tab_Category
                btn_GenerateGroup.Enabled = True
                btn_ViewGroup.Enabled = True
                btn_CopyCategory.Enabled = True
                grd_category.Enabled = True


                'Case "Rev0030".ToUpper 'RMS - Add/Update RMS
                '    btn_new_rms.Enabled = True
                '    btn_edit_rms.Enabled = True
                '    btn_delete_rms.Enabled = True
                '    grd_rms.Enabled = True

            Case "Rev0051".ToUpper
                ''-- Update company profile
                tab_main.TabPages(0).Enabled = True
                btn_parent.Enabled = False

                cbo_customer_type.Enabled = True
                txt_companyname_en.Enabled = True
                txt_companyname_th.Enabled = True
                txt_tax_id.Enabled = True
                txt_registration_date.Enabled = True
                cbo_customer_service_category.Enabled = True

            Case "Rev0052".ToUpper
                ''-- Update company address
                tab_main.TabPages(1).Enabled = True

                ''-- To enable all controls on tab
                Call ClearAllControls(Tab_Address, True, True)

            Case "Rev0053".ToUpper
                ''-- Update company contact person
                tab_main.TabPages(0).Enabled = True
                btn_parent.Enabled = False

                txt_contact_name.Enabled = True
                txt_contact_fax.Enabled = True
                txt_contact_department.Enabled = True
                txt_contact_mobile.Enabled = True
                txt_contact_phone.Enabled = True
                txt_contact_email.Enabled = True


            Case "Rev0054".ToUpper
                ''-- Update company relationship: parent company
                tab_main.TabPages(0).Enabled = True
                btn_parent.Enabled = True

            Case "Rev0055".ToUpper
                ''-- Update company loing method
                tab_main.TabPages(2).Enabled = True
                Call ClearAllControls(Tab_Config, True, True)

            Case "Rev0056".ToUpper, "Rev0057".ToUpper, "Rev0058".ToUpper, "Rev0059".ToUpper _
                , "Rev0060".ToUpper, "Rev0064".ToUpper, "Rev0065".ToUpper _
                , "Rev0066".ToUpper, "Rev0067".ToUpper, "Rev0068".ToUpper, "Rev0069".ToUpper _
                , "Rev0070".ToUpper, "Rev0071".ToUpper

                tab_main.TabPages(5).Enabled = True
                Call ClearAllControls(Tab_UMM_User, True, True)
                btn_Addnew_User.Enabled = False
                btn_delete_user.Enabled = False

            Case "Rev0061".ToUpper
                '-- user category/ print flag
                tab_main.TabPages(5).Enabled = True
                tab_main.TabPages(6).Enabled = True
                Call ClearAllControls(Tab_UMM_User, True, True)
                Call ClearAllControls(Tab_Category, True, True)

                btn_Addnew_User.Enabled = False
                btn_delete_user.Enabled = False
                btn_GenerateGroup.Enabled = True
                btn_CopyCategory.Enabled = True

            Case "Rev0072".ToUpper
                tab_main.TabPages(3).Enabled = True
                tab_main.TabPages(4).Enabled = True
                Call ClearAllControls(Tab_Accounts, True, True)
                Call ClearAllControls(Tab_Products, True, True)

                btn_Addnew_User.Enabled = False
                btn_edit_user.Enabled = True
                btn_delete_user.Enabled = False

                btn_new_product.Enabled = False
                btn_edit_product.Enabled = True
                btn_delete_product.Enabled = False
                btn_revision_add_charge_package.Enabled = True


            Case "Rev0073".ToUpper
                tab_main.TabPages(3).Enabled = True
                Call ClearAllControls(Tab_Accounts, True, True)

                btn_new_account.Enabled = True
                btn_edit_account.Enabled = False
                btn_delete_account.Enabled = False

                btn_revision_add_charge_package.Enabled = True

            Case "Rev0074".ToUpper, "Rev0075".ToUpper
                tab_main.TabPages(3).Enabled = True
                Call ClearAllControls(Tab_Accounts, True, True)

                btn_new_account.Enabled = False
                btn_edit_account.Enabled = True
                btn_delete_account.Enabled = False

                btn_revision_add_charge_package.Enabled = True
                'Case Else
                'MsgBox("Application does support this function.")
            Case "Rev0076".ToUpper
                tab_main.TabPages(8).Enabled = True
                Call ClearAllControls(Tab_Inteface, True, True)

                'btn_new_interface.Enabled = True
                'btn_new_interface_product.Enabled = True
                btn_edit_interface.Enabled = True
                btn_delete_interface.Enabled = True

            Case "Rev0078".ToUpper, "Rev0079".ToUpper, "Rev0080".ToUpper _
                , "Rev0081".ToUpper, "Rev0082".ToUpper

                tab_main.TabPages(5).Enabled = True
                Call ClearAllControls(Tab_UMM_User, True, True)

                '=====Tab_UMM_User
                grd_user.Enabled = True
                btn_Addnew_User.Enabled = True
                btn_edit_user.Enabled = True
                btn_delete_user.Enabled = True

            Case "Rev0083".ToUpper, "Rev0084".ToUpper, "Rev0085".ToUpper

                tab_main.TabPages(7).Enabled = True
                Call ClearAllControls(Tab_UMM_User, True, True)

                '=====Tab_UMM_User
                grd_auth.Enabled = True
                btn_new_auth.Enabled = True
                btn_edit_auth.Enabled = True
                btn_delete_auth.Enabled = True
                rad_avm.Enabled = True
                rad_svm.Enabled = True


        End Select

        '-- Insert revision log 

        If Len(txt_revision_code.Text) > 0 Then
            Dim strSQL As String = "exec [SP_tp_History_Insert] '" & txt_company_id.Text _
                                        & "', '" & txt_revision_code.Text _
                                        & "', '" & txt_revision_desc.Text _
                                        & "', '" & strRevDate & "'"


            conn.ExecuteNonQuery(strSQL)

        End If


    End Sub

    Private Sub tab_main_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab_main.SelectedIndexChanged

        If int_tab_main <> tab_main.SelectedIndex Then
            Call CheckErrorTab()
            int_tab_main = tab_main.SelectedIndex
        End If

        If tab_main.SelectedTab.Text = "Category" Then
            Call SetGrid_Category()
        End If
    End Sub

    Private Sub txt_company_id_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_company_id.Validated
        txt_company_id.Text = txt_company_id.Text.ToUpper

        If rad_set_as_parent_company_y.Checked = True Then
            If strMODE.ToUpper = "ADD" Then
                txt_corporation_code.Text = txt_company_id.Text
            End If

        End If

        Call CheckingDuplicationCompanyID()
    End Sub

    Private Sub CheckingDuplicationCompanyID()
        Try
            Dim strSQL As String = ""
            strSQL = "SELECT * FROM [TB_DEAL_UMM_COMPANY] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
            If conn.HasRows(strSQL) = True Then
                MessageBox.Show("Invalid Company id is duplicate.")
                Exit Sub
            Else
                '   If txt_client_code.Text = "" Then txt_client_code.Text = txt_company_id.Text
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txt_companyname_en_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_companyname_en.Validated
        txt_companyname_en.Text = txt_companyname_en.Text.ToUpper

        If strMODE.ToUpper = "ADD" Then
            Call AutoGenerate_CommpanyID()
        End If
    End Sub

    Private Sub AutoGenerate_CommpanyID()
        Dim vnt As Object
        Dim strNaming As String = ""
        Dim strDate As String = ""

        Try

            If txt_companyname_en.Text = "" Then Exit Sub

            strDate = Now.Year.ToString.Substring(2, 2) & Format(Now, "MMdd")
            vnt = Split(txt_companyname_en.Text, " ")

            If UBound(vnt) >= 1 Then
                strNaming = vnt(0).ToString.ToUpper.Substring(0, 1) & vnt(1).ToString.ToUpper.Substring(0, 1) & strDate
            Else
                If vnt(0).ToString.Length > 2 Then
                    strNaming = vnt(0).ToString.ToUpper.Substring(0, 2) & strDate
                End If
            End If

            Dim strSQL As String = ""
            strSQL = "SELECT  ISNULL( (CASE WHEN ISNUMERIC(RIGHT(MAX(company_id),2))=0 THEN CAST(RIGHT(max(company_id),2) AS FLOAT)   ELSE 0  END  ) ,0) as company_id  FROM [TB_DEAL_UMM_COMPANY] WHERE [company_id] like '" + strNaming.Replace("'", "''") + "%'" ' group by company_id
            If conn.HasRows(strSQL) = True Then
                'MessageBox.Show("Invalid Company id is duplicate.")

                Dim strRunning As String = ""
                strRunning = conn.GetDataFromSQL(strSQL, 0)


                If IsNumeric(strRunning) = True Then
                    Dim intRunning As Long = CDbl(strRunning.ToString) + 1
                    txt_company_id.Text = strNaming & intRunning.ToString("00")

                    'txt_corporation_code.Text = txt_client_code.Text

                End If

                ' Exit Sub
            Else
                txt_company_id.Text = strNaming & "01"
            End If

            txt_client_code.Text = txt_company_id.Text

            If rad_set_as_parent_company_y.Checked = True Then
                txt_corporation_code.Text = txt_company_id.Text
                txt_corporation_name.Text = txt_companyname_en.Text
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            If MsgBox("Connection fail. Do you want to resume connection.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                Call AutoGenerate_CommpanyID()
            End If
        End Try
    End Sub

    Private Sub rad_set_as_parent_company_y_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_set_as_parent_company_y.CheckedChanged
        Call Enable_txt_company_id_parent()
    End Sub

    Private Sub rad_set_as_parent_company_n_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_set_as_parent_company_n.CheckedChanged
        Call Enable_txt_company_id_parent()
    End Sub

    Private Sub Enable_txt_company_id_parent()
        '  If rad_revision.Checked = True Then Exit Sub

        If rad_set_as_parent_company_y.Checked = True Then
            txt_company_id_parent.Text = ""
            txt_company_id_parent.Enabled = False
            txt_company_id_parent.BackColor = Color.Gray

            'txt_corporation_code.Enabled = True
            'txt_corporation_code.BackColor = Color.White

            'txt_corporation_name.Enabled = True
            'txt_corporation_name.BackColor = Color.White
           

            btn_parent.Enabled = False
        Else
            'txt_company_id_parent.Text = ""
            txt_company_id_parent.Enabled = True
            txt_company_id_parent.BackColor = Color.White

            If strMODE.ToUpper <> "ADD" Then
                Dim strSQL As String = ""
                Dim vnt As String
                strSQL = "select count(*) as c from TB_DEAL_UMM_COMPANY where company_id_parent='" & txt_company_id.Text.Replace("'", "''") & "'"
                vnt = conn.GetDataFromSQL(strSQL, 0)
                If CDbl(vnt) > 0 Then
                    MsgBox("There is child company binding with this parent company")
                    rad_set_as_parent_company_y.Checked = True
                    Exit Sub
                End If
            End If

            'txt_corporation_code.Enabled = False
            'txt_corporation_code.BackColor = Color.Gray

            'txt_corporation_name.Enabled = False
            'txt_corporation_name.BackColor = Color.Gray


            btn_parent.Enabled = True
        End If
    End Sub

    Private Sub btn_parent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_parent.Click
        Dim mFrm_DealSummary_List As New Frm_DealSummary_List
        mFrm_DealSummary_List.txtRef = txt_company_id_parent
        mFrm_DealSummary_List.Is_parent = True
        mFrm_DealSummary_List.ShowDialog()

        If txt_company_id_parent.Text <> "" Then
            Call ShowCompanyName()
            Call SetGrid_Category()
        End If

    End Sub

    ''' <summary>
    ''' Fixed bug: realease note 0.35
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowCompanyName()
        Dim dtCorp As DataTable

        Try

            If Len(txt_company_id_parent.Text) = 0 Then Exit Sub

            dtCorp = conn.BindingDT("[SP_ap_GCP002_Company_Select] '" & txt_company_id_parent.Text & "', 'Y'", "CorpName")

            If dtCorp.Rows.Count > 0 Then

                txt_parent_name.Text = dtCorp.Rows(0)("companyname_en").ToString
                txt_corporation_code.Text = dtCorp.Rows(0)("corporation_code").ToString
                txt_corporation_name.Text = dtCorp.Rows(0)("corporation_name").ToString

                txt_corporation_code.Enabled = False
                txt_corporation_name.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txt_company_id_parent_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_company_id_parent.Validated
        Call ShowCompanyName()
    End Sub

#End Region

#Region "event-auto-address"

    Private Sub txt_registered_no_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_registered_no.Validated
        If chk_use_registered_address.Checked = True Then
            txt_mailing_no.Text = txt_registered_no.Text
        End If
    End Sub

    Private Sub txt_registered_moo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_registered_moo.Validated
        If chk_use_registered_address.Checked = True Then
            txt_mailing_moo.Text = txt_registered_moo.Text
        End If
    End Sub

    Private Sub txt_registered_building_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_registered_building.Validated
        If chk_use_registered_address.Checked = True Then
            txt_mailing_building.Text = txt_registered_building.Text
        End If
    End Sub

    Private Sub txt_registered_floor_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_registered_floor.Validated
        If chk_use_registered_address.Checked = True Then
            txt_mailing_floor.Text = txt_registered_floor.Text
        End If
    End Sub

    Private Sub txt_registered_soi_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_registered_soi.Validated
        If chk_use_registered_address.Checked = True Then
            txt_mailing_soi.Text = txt_registered_soi.Text
        End If
    End Sub

    Private Sub txt_registered_street_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_registered_street.Validated
        If chk_use_registered_address.Checked = True Then
            txt_mailing_street.Text = txt_registered_street.Text
        End If
    End Sub

    Private Sub txt_registered_sub_district_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_registered_sub_district.Validated
        If chk_use_registered_address.Checked = True Then
            txt_mailing_sub_district.Text = txt_registered_sub_district.Text
        End If
    End Sub

    Private Sub txt_registered_district_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_registered_district.Validated
        If chk_use_registered_address.Checked = True Then
            txt_mailing_district.Text = txt_registered_district.Text
        End If
    End Sub

    Private Sub txt_registered_province_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        If chk_use_registered_address.Checked = True Then
            cbo_mailing_province.Text = cbo_registered_province.Text
        End If
    End Sub

    Private Sub txt_registered_region_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        If chk_use_registered_address.Checked = True Then
            cbo_mailing_region.Text = cbo_registered_region.Text
        End If
    End Sub

    Private Sub txt_registered_postal_code_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_registered_postal_code.Validated
        If chk_use_registered_address.Checked = True Then
            txt_mailing_postal_code.Text = txt_registered_postal_code.Text
        End If
    End Sub

    Private Sub txt_registered_country_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        If chk_use_registered_address.Checked = True Then
            cbo_mailing_country.Text = cbo_registered_country.Text
        End If
    End Sub

    Private Sub chk_use_registered_address_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_use_registered_address.CheckedChanged

        Call RefreshDuplicationAddress()

    End Sub

    Private Sub RefreshDuplicationAddress()
        If chk_use_registered_address.Checked = True Then
            txt_mailing_no.Text = txt_registered_no.Text
            txt_mailing_moo.Text = txt_registered_moo.Text
            txt_mailing_building.Text = txt_registered_building.Text
            txt_mailing_floor.Text = txt_registered_floor.Text
            txt_mailing_soi.Text = txt_registered_soi.Text
            txt_mailing_street.Text = txt_registered_street.Text
            txt_mailing_sub_district.Text = txt_registered_sub_district.Text
            txt_mailing_district.Text = txt_registered_district.Text
            cbo_mailing_province.Text = cbo_registered_province.Text
            cbo_mailing_region.Text = cbo_registered_region.Text
            txt_mailing_postal_code.Text = txt_registered_postal_code.Text
            cbo_mailing_country.Text = cbo_registered_country.Text

            txt_mailing_no.Enabled = False
            txt_mailing_moo.Enabled = False
            txt_mailing_building.Enabled = False
            txt_mailing_floor.Enabled = False
            txt_mailing_soi.Enabled = False
            txt_mailing_street.Enabled = False
            txt_mailing_sub_district.Enabled = False
            txt_mailing_district.Enabled = False
            cbo_mailing_province.Enabled = False
            cbo_mailing_region.Enabled = False
            txt_mailing_postal_code.Enabled = False
            cbo_mailing_country.Enabled = False
        Else
            txt_mailing_no.Enabled = True
            txt_mailing_moo.Enabled = True
            txt_mailing_building.Enabled = True
            txt_mailing_floor.Enabled = True
            txt_mailing_soi.Enabled = True
            txt_mailing_street.Enabled = True
            txt_mailing_sub_district.Enabled = True
            txt_mailing_district.Enabled = True
            cbo_mailing_province.Enabled = True
            cbo_mailing_region.Enabled = True
            txt_mailing_postal_code.Enabled = True
            cbo_mailing_country.Enabled = True
        End If
    End Sub
#End Region

#Region "data-interface"

    Private Function ValidationData_CreateCompanyProfile() As String
        Dim strErr As String = ""

       

      

        'If txt_contact_fax.Text = "" Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Contact Point & Relationship->Contact Point & Relationship / Fax :]"
        'End If

        If txt_contact_mobile.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Contact Point & Relationship / Mobile :]"
        End If

        If rad_set_as_parent_company_n.Checked = True Then
            If txt_company_id_parent.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Contact Point & Relationship / Set Parent Code:]"
            End If
        End If

        '===============for tab Company Profile==================
        If txt_companyname_en.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Company Name(TH):]"
        End If

        If txt_companyname_th.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Company Name(TH):]"
        End If

        If txt_company_id.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Company Id:]"
        End If

        'txt_client_code
        If txt_client_code.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Client Code:]"
        End If

        If txt_corporation_code.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Corporation Code:]"
        End If

        If txt_corporation_name.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Corporation Name:]"
        End If


        If cbo_customer_type.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Customer Type:]"
        End If

        If txt_tax_id.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Corporate Registration ID / Tax Id:]"
        End If

        If txt_registration_date.Text = "" Or Is_date(txt_registration_date.Text) = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Corpotrate Registration Date:]"
        End If

        '=======contact person
        If chk_deal_cover_inquiry.Checked = False And chk_deal_cover_payment.Checked = False And chk_deal_cover_admin.Checked = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Please mark at least in 'Service Cover :' ]"
        End If


        If txt_contact_name.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Contact Point & Relationship / Name:]"
        End If

        If txt_contact_department.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Contact Point & Relationship / Department:]"
        End If

        If txt_contact_phone.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Contact Point & Relationship / Phone:]"
        End If

        If txt_contact_email.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Contact Point & Relationship / Email Address:]"
        End If


        'get_date_sql


        Return strErr
    End Function

    Private Function ValidationData_Address() As String
        Dim strErr As String = ""
        '===============:===============
        If txt_registered_no.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Address->Registered Address:/ No.:]"
        End If

        If txt_registered_street.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Address->Registered Address:/ Street:]"
        End If

        If cbo_registered_province.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Address->Registered Address:/ Province/City:]"
        End If

        'If cbo_registered_region.Text = "" Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Mailing Address: / Region:]"
        'End If

        If txt_registered_postal_code.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Address->Mailing Address: / Postal Code:]"
        End If

        If cbo_registered_country.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Address->Mailing Address: / Country:]"
        End If

        '===============Mailing Address:===============
        If txt_mailing_no.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Address->Mailing Address: / No.:]"
        End If

        If txt_mailing_street.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Address->Mailing Address: / Street:]"
        End If

        If cbo_mailing_province.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Address->Mailing Address: / Province/City:]"
        End If

        'If cbo_mailing_region.Text = "" Then
        '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Profile->Mailing Address: / Region:]"
        'End If

        If txt_mailing_postal_code.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Address->Mailing Address: / Postal Code:]"
        End If

        If cbo_mailing_country.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Company Address->Mailing Address: / Country:]"
        End If
        Return strErr
    End Function

    'Private Function ValidationData_ContactPointRelationship() As String
    '    Dim strErr As String = ""
    '    '============Contact Point && Relationship===============

    '    Return strErr

    'End Function

    Private Sub ShowData_DEAL_UMM_COMPANY()
        If txt_company_id.Text = "" Then Exit Sub
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_DEAL_UMM_COMPANY] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()

            txt_client_code.Text = IIf(res("client_code") Is System.DBNull.Value, "", res("client_code").ToString())

            If IIf(res("deal_type") Is System.DBNull.Value, "", res("deal_type").ToString()) = "" Then
                rad_new.Checked = True
                rad_revision.Checked = False
            Else
                rad_new.Checked = False
                rad_revision.Checked = True
            End If

            'chk_Generate
            If IIf(res("validation_flag") Is System.DBNull.Value, "", res("validation_flag").ToString()) = "Y" Then
                chk_Generate.Checked = True
            Else
                chk_Generate.Checked = False
            End If
            'cbo_status
            cbo_status.Text = IIf(res("status") Is System.DBNull.Value, "", res("status").ToString())


            If IIf(res("deal_cover_inquiry") Is System.DBNull.Value, "", res("deal_cover_inquiry").ToString()) = "Y" Then
                chk_deal_cover_inquiry.Checked = True
            Else
                chk_deal_cover_inquiry.Checked = False
            End If

            If IIf(res("deal_cover_payment") Is System.DBNull.Value, "", res("deal_cover_payment").ToString()) = "Y" Then
                chk_deal_cover_payment.Checked = True
                Call EnableButtonPayment()
            Else
                chk_deal_cover_payment.Checked = False
            End If

            If IIf(res("deal_cover_admin") Is System.DBNull.Value, "", res("deal_cover_admin").ToString()) = "Y" Then
                chk_deal_cover_admin.Checked = True
            Else
                chk_deal_cover_admin.Checked = False
            End If


            txt_companyname_en.Text = IIf(res("companyname_en") Is System.DBNull.Value, "", res("companyname_en").ToString())
            txt_companyname_th.Text = IIf(res("companyname_th") Is System.DBNull.Value, "", res("companyname_th").ToString())
            txt_corporation_code.Text = IIf(res("corporation_code") Is System.DBNull.Value, "", res("corporation_code").ToString())
            txt_corporation_name.Text = IIf(res("corporation_name") Is System.DBNull.Value, "", res("corporation_name").ToString())


            cbo_customer_type.Text = IIf(res("customer_type") Is System.DBNull.Value, "", res("customer_type").ToString())
            txt_tax_id.Text = IIf(res("tax_id") Is System.DBNull.Value, "", res("tax_id").ToString())
            txt_registration_date.Text = get_date_to_control(res("registration_date"))
            txt_gcp_service_end_date.Text = get_date_to_control(res("gcp_service_end_date"))
            cbo_customer_service_category.Text = IIf(res("customer_service_category") Is System.DBNull.Value, "", res("customer_service_category").ToString())
            '===========Registered Address:==============
            txt_registered_no.Text = IIf(res("registered_no") Is System.DBNull.Value, "", res("registered_no").ToString())
            txt_registered_moo.Text = IIf(res("registered_moo") Is System.DBNull.Value, "", res("registered_moo").ToString())
            txt_registered_building.Text = IIf(res("registered_building") Is System.DBNull.Value, "", res("registered_building").ToString())
            txt_registered_floor.Text = IIf(res("registered_floor") Is System.DBNull.Value, "", res("registered_floor").ToString())
            txt_registered_soi.Text = IIf(res("registered_soi") Is System.DBNull.Value, "", res("registered_soi").ToString())
            txt_registered_street.Text = IIf(res("registered_street") Is System.DBNull.Value, "", res("registered_street").ToString())
            txt_registered_sub_district.Text = IIf(res("registered_sub_district") Is System.DBNull.Value, "", res("registered_sub_district").ToString())
            txt_registered_district.Text = IIf(res("registered_district") Is System.DBNull.Value, "", res("registered_district").ToString())
            cbo_registered_province.Text = IIf(res("registered_province") Is System.DBNull.Value, "", res("registered_province").ToString())
            cbo_registered_region.Text = IIf(res("registered_region") Is System.DBNull.Value, "", res("registered_region").ToString())
            txt_registered_postal_code.Text = IIf(res("registered_postal_code") Is System.DBNull.Value, "", res("registered_postal_code").ToString())
            cbo_registered_country.Text = IIf(res("registered_country") Is System.DBNull.Value, "", res("registered_country").ToString())
            '==========Mailing Address:================
            'chk_use_registered_address
            If IIf(res("use_registered_address") Is System.DBNull.Value, "", res("use_registered_address").ToString()) = "Y" Then
                chk_use_registered_address.Checked = True
            Else
                chk_use_registered_address.Checked = False
            End If

            txt_mailing_no.Text = IIf(res("mailing_no") Is System.DBNull.Value, "", res("mailing_no").ToString())
            txt_mailing_moo.Text = IIf(res("mailing_moo") Is System.DBNull.Value, "", res("mailing_moo").ToString())
            txt_mailing_building.Text = IIf(res("mailing_building") Is System.DBNull.Value, "", res("mailing_building").ToString())
            txt_mailing_floor.Text = IIf(res("mailing_floor") Is System.DBNull.Value, "", res("mailing_floor").ToString())
            txt_mailing_soi.Text = IIf(res("mailing_soi") Is System.DBNull.Value, "", res("mailing_soi").ToString())
            txt_mailing_street.Text = IIf(res("mailing_street") Is System.DBNull.Value, "", res("mailing_street").ToString())
            txt_mailing_sub_district.Text = IIf(res("mailing_sub_district") Is System.DBNull.Value, "", res("mailing_sub_district").ToString())
            txt_mailing_district.Text = IIf(res("mailing_district") Is System.DBNull.Value, "", res("mailing_district").ToString())
            cbo_mailing_province.Text = IIf(res("mailing_province") Is System.DBNull.Value, "", res("mailing_province").ToString())
            cbo_mailing_region.Text = IIf(res("mailing_region") Is System.DBNull.Value, "", res("mailing_region").ToString())
            txt_mailing_postal_code.Text = IIf(res("mailing_postal_code") Is System.DBNull.Value, "", res("mailing_postal_code").ToString())
            cbo_mailing_country.Text = IIf(res("mailing_country") Is System.DBNull.Value, "", res("mailing_country").ToString())

            '=============Contact Point && Relationship==============
            txt_contact_name.Text = IIf(res("contact_name") Is System.DBNull.Value, "", res("contact_name").ToString())
            txt_contact_department.Text = IIf(res("contact_department") Is System.DBNull.Value, "", res("contact_department").ToString())
            txt_contact_phone.Text = IIf(res("contact_phone") Is System.DBNull.Value, "", res("contact_phone").ToString())
            txt_contact_email.Text = IIf(res("contact_email") Is System.DBNull.Value, "", res("contact_email").ToString())
            txt_contact_fax.Text = IIf(res("contact_fax") Is System.DBNull.Value, "", res("contact_fax").ToString())
            txt_contact_mobile.Text = IIf(res("contact_mobile") Is System.DBNull.Value, "", res("contact_mobile").ToString())

            If IIf(res("set_as_parent_company") Is System.DBNull.Value, "", res("set_as_parent_company").ToString()) = "Y" Then
                rad_set_as_parent_company_y.Checked = True
                ' txt_company_id_parent.Text = ""
            Else
                rad_set_as_parent_company_n.Checked = True

            End If

            Call Enable_txt_company_id_parent()


            txt_company_id_parent.Text = IIf(res("company_id_parent") Is System.DBNull.Value, "", res("company_id_parent").ToString())
            Call ShowCompanyName()

            txt_corporation_code.Enabled = False
            txt_corporation_name.Enabled = False


            'txt_beneficiary_advice_detail
            txt_beneficiary_advice_detail.Text = IIf(res("beneficiary_advice_detail") Is System.DBNull.Value, "", res("beneficiary_advice_detail").ToString())


            'txt_company_id_parent

            'strFiledname += vbCrLf & ",[AuthorizationParameter]"
            'If rad_avm.Checked = True Then
            '    strValue += vbCrLf & ",N'Authorization Matrix'"
            'Else
            '    strValue += vbCrLf & ",N'Signatory Matrix'"
            'End If

            If IIf(res("AuthorizationParameter") Is System.DBNull.Value, "", res("AuthorizationParameter").ToString()) = "Signatory Matrix" Then
                rad_svm.Checked = True
            Else
                rad_avm.Checked = True
            End If

            If IIf(res("login_flag") Is System.DBNull.Value, "", res("login_flag").ToString()) = "Y" Then
                chk_login_flag.Checked = True
            Else
                chk_login_flag.Checked = False
            End If
            If IIf(res("login_non") Is System.DBNull.Value, "", res("login_non").ToString()) = "Y" Then
                chk_login_non.Checked = True
            Else
                chk_login_non.Checked = False
            End If
            If IIf(res("login_hw") Is System.DBNull.Value, "", res("login_hw").ToString()) = "Y" Then
                chk_login_hw.Checked = True
            Else
                chk_login_hw.Checked = False
            End If
            If IIf(res("login_sms") Is System.DBNull.Value, "", res("login_sms").ToString()) = "Y" Then
                chk_login_sms.Checked = True
            Else
                chk_login_sms.Checked = False
            End If
            If IIf(res("login_sms_flag") Is System.DBNull.Value, "", res("login_sms_flag").ToString()) = "Y" Then
                chk_login_sms_flag.Checked = True
            Else
                chk_login_sms_flag.Checked = False
            End If
            If IIf(res("login_sms_non") Is System.DBNull.Value, "", res("login_sms_non").ToString()) = "Y" Then
                chk_login_sms_non.Checked = True
            Else
                chk_login_sms_non.Checked = False
            End If
            If IIf(res("login_sms_sms") Is System.DBNull.Value, "", res("login_sms_sms").ToString()) = "Y" Then
                chk_login_sms_sms.Checked = True
            Else
                chk_login_sms_sms.Checked = False
            End If
            If IIf(res("login_token_flag") Is System.DBNull.Value, "", res("login_token_flag").ToString()) = "Y" Then
                chk_login_token_flag.Checked = True
            Else
                chk_login_token_flag.Checked = False
            End If
            If IIf(res("login_token_non") Is System.DBNull.Value, "", res("login_token_non").ToString()) = "Y" Then
                chk_login_token_non.Checked = True
            Else
                chk_login_token_non.Checked = False
            End If
            If IIf(res("login_token_hw") Is System.DBNull.Value, "", res("login_token_hw").ToString()) = "Y" Then
                chk_login_token_hw.Checked = True
            Else
                chk_login_token_hw.Checked = False

            End If
            '=================
            If IIf(res("h2h_workflow") Is System.DBNull.Value, "", res("h2h_workflow").ToString()) = rad_h2h_workflow_client.Text Then
                rad_h2h_workflow_client.Checked = True
            Else
                rad_h2h_workflow_bank.Checked = True
            End If

            If IIf(res("customer_float_computation") Is System.DBNull.Value, "", res("customer_float_computation").ToString()) = rad_customer_float_computation_stale.Text Then
                rad_customer_float_computation_stale.Checked = True
            Else
                rad_customer_float_computation_liquidatation.Checked = True
            End If

            If IIf(res("wht_language") Is System.DBNull.Value, "", res("wht_language").ToString()) = rad_wht_language_thai.Text Then
                rad_wht_language_thai.Checked = True
            Else
                rad_wht_language_english.Checked = True
            End If

            'rad_ivr_fax_y
            If IIf(res("ivr_fax") Is System.DBNull.Value, "", res("ivr_fax").ToString()) = "Y" Then
                rad_ivr_fax_y.Checked = True
            Else
                rad_ivr_fax_n.Checked = True
            End If

            If IIf(res("ivr_email") Is System.DBNull.Value, "", res("ivr_email").ToString()) = "Y" Then
                rad_ivr_email_y.Checked = True
            Else
                rad_ivr_email_n.Checked = True
            End If

            ' cbo_ProductCode.Text = cbo_ProductCode.Items(cbo_ProductCode.FindString(IIf(res("ProductCode") Is System.DBNull.Value, "", res("ProductCode").ToString()))).ToString
        End If
        res.Close()
        res = Nothing

    End Sub

    Private Function SaveData_Service() As Boolean
        Dim strSQL As String = ""
        Dim strErr As String = ""
        If txt_company_id.Text = "" Then Exit Function
        If strMODE = "ADD" Then Exit Function
        strSQL = ""
        strSQL += vbCrLf & "update [TB_DEAL_UMM_COMPANY] set "
        'deal_cover_inquiry
        strSQL += vbCrLf & " [deal_cover_inquiry]"
        If chk_deal_cover_inquiry.Checked = True Then
            strSQL += vbCrLf & "=N'Y'"
        Else
            strSQL += vbCrLf & "=N'N'"
        End If

        strSQL += vbCrLf & ",[deal_cover_payment]"
        If chk_deal_cover_payment.Checked = True Then
            strSQL += vbCrLf & "=N'Y'"
        Else
            strSQL += vbCrLf & "=N'N'"
        End If

        strSQL += vbCrLf & ",[deal_cover_admin]"
        If chk_deal_cover_admin.Checked = True Then
            strSQL += vbCrLf & "=N'Y'"
        Else
            strSQL += vbCrLf & "=N'N'"
        End If
        strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
        strErr = conn.ExecuteNonQuery(strSQL)

    End Function

    Private Function SaveData_CreateCompanyProfile() As Boolean
        Dim strSQL As String = ""
        Dim strErr As String = ""
        Dim strRevDate As String = Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)

        Try
            ' conn = New CSQL
            'conn.Connect()


            '========================add mode====================
            If strMODE.ToUpper = "ADD" Then

                'strSQL = "SELECT * FROM [TB_DEAL_UMM_COMPANY] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"

                If conn.IsExistingCompanyID(txt_company_id.Text) = True Then
                    MessageBox.Show("Invalid Company id is duplicate.")
                    Exit Function
                End If



                Dim strValue As String = ""
                Dim strFiledname As String = ""

                strFiledname += vbCrLf & "[company_id]"
                strValue += vbCrLf & "N'" & txt_company_id.Text.Replace("'", "''") & "'"


                strFiledname += vbCrLf & ",[validation_flag]"
                If chk_Generate.Checked = True Then
                    strValue += vbCrLf & ",N'Y'"
                Else
                    strValue += vbCrLf & ",N'N'"
                End If
                'cbo_status
                strFiledname += vbCrLf & ",[status]"
                strValue += vbCrLf & ",N'" & cbo_status.Text.Replace("'", "''") & "'"


                '===============
                'deal_type
                strFiledname += vbCrLf & ",[deal_type]"
                If rad_new.Checked = True Then
                    strValue += vbCrLf & ",N'NEW'"
                Else
                    strValue += vbCrLf & ",N'REVISION'"
                End If

                'deal_cover_inquiry
                strFiledname += vbCrLf & ",[deal_cover_inquiry]"
                If chk_deal_cover_inquiry.Checked = True Then
                    strValue += vbCrLf & ",N'Y'"
                Else
                    strValue += vbCrLf & ",N'N'"
                End If

                strFiledname += vbCrLf & ",[deal_cover_payment]"
                If chk_deal_cover_payment.Checked = True Then
                    strValue += vbCrLf & ",N'Y'"
                Else
                    strValue += vbCrLf & ",N'N'"
                End If

                strFiledname += vbCrLf & ",[deal_cover_admin]"
                If chk_deal_cover_admin.Checked = True Then
                    strValue += vbCrLf & ",N'Y'"
                Else
                    strValue += vbCrLf & ",N'N'"
                End If

                '============
                strFiledname += vbCrLf & ",[companyname_en]"
                strValue += vbCrLf & ",N'" & txt_companyname_en.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[companyname_th]"
                strValue += vbCrLf & ",N'" & txt_companyname_th.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[client_code]"
                strValue += vbCrLf & ",N'" & txt_client_code.Text.Replace("'", "''") & "'"

                'txt_corporation_code
                strFiledname += vbCrLf & ",[corporation_code]"
                strValue += vbCrLf & ",N'" & txt_corporation_code.Text.Replace("'", "''") & "'"
                'txt_corporation_name
                strFiledname += vbCrLf & ",[corporation_name]"
                strValue += vbCrLf & ",N'" & txt_corporation_name.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[customer_type]"
                strValue += vbCrLf & ",N'" & cbo_customer_type.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[tax_id]"
                strValue += vbCrLf & ",N'" & txt_tax_id.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[registration_date]"
                strValue += vbCrLf & "," & get_date_sql(txt_registration_date.Text) & ""

                strFiledname += vbCrLf & ",[customer_service_category]"
                strValue += vbCrLf & ",N'" & cbo_customer_service_category.Text.Replace("'", "''") & "'"

                '===========Registered Address:===============

                strFiledname += vbCrLf & ",[registered_no]"
                strValue += vbCrLf & ",N'" & txt_registered_no.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[registered_moo]"
                strValue += vbCrLf & ",N'" & txt_registered_moo.Text.Replace("'", "''") & "'"

                'txt_registered_building
                strFiledname += vbCrLf & ",[registered_building]"
                strValue += vbCrLf & ",N'" & txt_registered_building.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[registered_floor]"
                strValue += vbCrLf & ",N'" & txt_registered_floor.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[registered_soi]"
                strValue += vbCrLf & ",N'" & txt_registered_soi.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[registered_street]"
                strValue += vbCrLf & ",N'" & txt_registered_street.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[registered_sub_district]"
                strValue += vbCrLf & ",N'" & txt_registered_sub_district.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[registered_district]"
                strValue += vbCrLf & ",N'" & txt_registered_district.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[registered_province]"
                strValue += vbCrLf & ",N'" & cbo_registered_province.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[registered_region]"
                strValue += vbCrLf & ",N'" & cbo_registered_region.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[registered_postal_code]"
                strValue += vbCrLf & ",N'" & txt_registered_postal_code.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[registered_country]"
                strValue += vbCrLf & ",N'" & cbo_registered_country.Text.Replace("'", "''") & "'"

                '===========Mailing Address:===================
                strFiledname += vbCrLf & ",[use_registered_address]"
                If chk_use_registered_address.Checked = True Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If

                strFiledname += vbCrLf & ",[mailing_no]"
                strValue += vbCrLf & ",N'" & txt_mailing_no.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[mailing_moo]"
                strValue += vbCrLf & ",N'" & txt_mailing_moo.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[mailing_building]"
                strValue += vbCrLf & ",N'" & txt_mailing_building.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[mailing_floor]"
                strValue += vbCrLf & ",N'" & txt_mailing_floor.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[mailing_soi]"
                strValue += vbCrLf & ",N'" & txt_mailing_soi.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[mailing_street]"
                strValue += vbCrLf & ",N'" & txt_mailing_street.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[mailing_sub_district]"
                strValue += vbCrLf & ",N'" & txt_mailing_sub_district.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[mailing_district]"
                strValue += vbCrLf & ",N'" & txt_mailing_district.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[mailing_province]"
                strValue += vbCrLf & ",N'" & cbo_mailing_province.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[mailing_region]"
                strValue += vbCrLf & ",N'" & cbo_mailing_region.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[mailing_postal_code]"
                strValue += vbCrLf & ",N'" & txt_mailing_postal_code.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[mailing_country]"
                strValue += vbCrLf & ",N'" & cbo_mailing_country.Text.Replace("'", "''") & "'"

                '==============Contact Point && Relationship==========================
                strFiledname += vbCrLf & ",[contact_name]"
                strValue += vbCrLf & ",N'" & txt_contact_name.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[contact_department]"
                strValue += vbCrLf & ",N'" & txt_contact_department.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[contact_phone]"
                strValue += vbCrLf & ",N'" & txt_contact_phone.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[contact_email]"
                strValue += vbCrLf & ",N'" & txt_contact_email.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[contact_fax]"
                strValue += vbCrLf & ",N'" & txt_contact_fax.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[contact_mobile]"
                strValue += vbCrLf & ",N'" & txt_contact_mobile.Text.Replace("'", "''") & "'"

                '==========parent========
                strFiledname += vbCrLf & ",[set_as_parent_company]"
                If rad_set_as_parent_company_y.Checked = True Then
                    strValue += vbCrLf & ",N'Y'"

                    strFiledname += vbCrLf & ",[company_id_parent]"
                    strValue += vbCrLf & ",N''"

                Else
                    strValue += vbCrLf & ",N'N'"

                    strFiledname += vbCrLf & ",[company_id_parent]"
                    strValue += vbCrLf & ",N'" & txt_company_id_parent.Text.Replace("'", "''") & "'"

                End If
                'beneficiary_advice_detail
                strFiledname += vbCrLf & ",[beneficiary_advice_detail]"
                strValue += vbCrLf & ",N'" & txt_beneficiary_advice_detail.Text.Replace("'", "''") & "'"


                strFiledname += vbCrLf & ",[AuthorizationParameter]"

                If rad_avm.Checked = True Then
                    strValue += vbCrLf & ",N'Authorization Matrix'"
                Else
                    strValue += vbCrLf & ",N'Signatory Matrix'"
                End If

                'chk_login_flag
                strFiledname += vbCrLf & ",[login_flag]"
                strValue += vbCrLf & ",N'" & IIf(chk_login_flag.Checked = True, "Y", "N") & "'"
                strFiledname += vbCrLf & ",[login_non]"
                strValue += vbCrLf & ",N'" & IIf(chk_login_non.Checked = True, "Y", "N") & "'"
                strFiledname += vbCrLf & ",[login_hw]"
                strValue += vbCrLf & ",N'" & IIf(chk_login_hw.Checked = True, "Y", "N") & "'"
                strFiledname += vbCrLf & ",[login_sms]"
                strValue += vbCrLf & ",N'" & IIf(chk_login_sms.Checked = True, "Y", "N") & "'"

                'chk_login_sms_flag
                strFiledname += vbCrLf & ",[login_sms_flag]"
                strValue += vbCrLf & ",N'" & IIf(chk_login_sms_flag.Checked = True, "Y", "N") & "'"
                strFiledname += vbCrLf & ",[login_sms_non]"
                strValue += vbCrLf & ",N'" & IIf(chk_login_sms_non.Checked = True, "Y", "N") & "'"
                strFiledname += vbCrLf & ",[login_sms_sms]"
                strValue += vbCrLf & ",N'" & IIf(chk_login_sms_sms.Checked = True, "Y", "N") & "'"

                'chk_login_token_flag
                strFiledname += vbCrLf & ",[login_token_flag]"
                strValue += vbCrLf & ",N'" & IIf(chk_login_token_flag.Checked = True, "Y", "N") & "'"
                strFiledname += vbCrLf & ",[login_token_non]"
                strValue += vbCrLf & ",N'" & IIf(chk_login_token_non.Checked = True, "Y", "N") & "'"
                strFiledname += vbCrLf & ",[login_token_hw]"
                strValue += vbCrLf & ",N'" & IIf(chk_login_token_hw.Checked = True, "Y", "N") & "'"

                strFiledname += vbCrLf & ",[h2h_workflow]"
                strValue += vbCrLf & ",N'" & IIf(rad_h2h_workflow_client.Checked = True, rad_h2h_workflow_client.Text, rad_h2h_workflow_bank.Text) & "'"

                strFiledname += vbCrLf & ",[customer_float_computation]"
                strValue += vbCrLf & ",N'" & IIf(rad_customer_float_computation_stale.Checked = True, rad_customer_float_computation_stale.Text, rad_customer_float_computation_liquidatation.Text) & "'"

                strFiledname += vbCrLf & ",[wht_language]"
                strValue += vbCrLf & ",N'" & IIf(rad_wht_language_thai.Checked = True, rad_wht_language_thai.Text, rad_wht_language_english.Text) & "'"

                strFiledname += vbCrLf & ",[ivr_fax]"
                If rad_ivr_fax_y.Checked = True Then
                    strValue += vbCrLf & ",N'Y'"
                Else
                    strValue += vbCrLf & ",N'N'"
                End If

                strFiledname += vbCrLf & ",[ivr_email]"
                If rad_ivr_email_y.Checked = True Then
                    strValue += vbCrLf & ",N'Y'"
                Else
                    strValue += vbCrLf & ",N'N'"
                End If


                '==========insert command=========
                strSQL = ""
                strSQL += vbCrLf & "insert into [TB_DEAL_UMM_COMPANY]"
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                strErr = conn.ExecuteNonQuery(strSQL)

                ''-- Is completed transaction to DB
                If conn.IsExistingCompanyID(txt_company_id.Text) = True Then
                    strMODE = "EDIT"
                End If

            End If

            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [TB_DEAL_UMM_COMPANY] set "


                strSQL += vbCrLf & "[company_id]"
                strSQL += vbCrLf & "=N'" & txt_company_id.Text.Replace("'", "''") & "'"

                If (txt_revision_code.Text.ToUpper = "Rev0001".ToUpper And rad_revision.Checked = True) Or rad_revision.Checked = False Or rad_revision.Checked = True Then



                    '===============


                    strSQL += vbCrLf & ",[validation_flag]"
                    If chk_Generate.Checked = True Then
                        strSQL += vbCrLf & "=N'Y'"
                    Else
                        strSQL += vbCrLf & "=N'N'"
                    End If

                    strSQL += vbCrLf & ",[status]"
                    strSQL += vbCrLf & "=N'" & cbo_status.Text.Replace("'", "''") & "'"


                    'deal_type
                    strSQL += vbCrLf & ",[deal_type]"
                    If rad_new.Checked = True Then
                        strSQL += vbCrLf & "=N'NEW'"
                    Else
                        strSQL += vbCrLf & "=N'REVISION'"
                    End If

                    'deal_cover_inquiry
                    strSQL += vbCrLf & ",[deal_cover_inquiry]"
                    If chk_deal_cover_inquiry.Checked = True Then
                        strSQL += vbCrLf & "=N'Y'"
                    Else
                        strSQL += vbCrLf & "=N'N'"
                    End If

                    strSQL += vbCrLf & ",[deal_cover_payment] "
                    If chk_deal_cover_payment.Checked = True Then
                        strSQL += vbCrLf & "=N'Y'"
                    Else
                        strSQL += vbCrLf & "=N'N'"
                    End If

                    strSQL += vbCrLf & ",[deal_cover_admin]"
                    If chk_deal_cover_admin.Checked = True Then
                        strSQL += vbCrLf & "=N'Y'"
                    Else
                        strSQL += vbCrLf & "=N'N'"
                    End If

                    '============
                    strSQL += vbCrLf & ",[companyname_en]"
                    strSQL += vbCrLf & "=N'" & txt_companyname_en.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[companyname_th]"
                    strSQL += vbCrLf & "=N'" & txt_companyname_th.Text.Replace("'", "''") & "'"


                    strSQL += vbCrLf & ",[client_code]"
                    strSQL += vbCrLf & "=N'" & txt_client_code.Text.Replace("'", "''") & "'"


                    'txt_corporation_code
                    strSQL += vbCrLf & ",[corporation_code]"
                    strSQL += vbCrLf & "=N'" & txt_corporation_code.Text.Replace("'", "''") & "'"
                    'txt_corporation_name
                    strSQL += vbCrLf & ",[corporation_name]"
                    strSQL += vbCrLf & "=N'" & txt_corporation_name.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[customer_type]"
                    strSQL += vbCrLf & "=N'" & cbo_customer_type.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[tax_id]"
                    strSQL += vbCrLf & "=N'" & txt_tax_id.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[registration_date]"
                    strSQL += vbCrLf & "=" & get_date_sql(txt_registration_date.Text) & ""

                    strSQL += vbCrLf & ",[customer_service_category]"
                    strSQL += vbCrLf & "=N'" & cbo_customer_service_category.Text.Replace("'", "''") & "'"

                    '===========Registered Address:===============

                    strSQL += vbCrLf & ",[registered_no]"
                    strSQL += vbCrLf & "=N'" & txt_registered_no.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[registered_moo]"
                    strSQL += vbCrLf & "=N'" & txt_registered_moo.Text.Replace("'", "''") & "'"

                    'txt_registered_building
                    strSQL += vbCrLf & ",[registered_building]"
                    strSQL += vbCrLf & "=N'" & txt_registered_building.Text.Replace("'", "''") & "'"


                    strSQL += vbCrLf & ",[registered_floor]"
                    strSQL += vbCrLf & "=N'" & txt_registered_floor.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[registered_soi]"
                    strSQL += vbCrLf & "=N'" & txt_registered_soi.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[registered_street]"
                    strSQL += vbCrLf & "=N'" & txt_registered_street.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[registered_sub_district]"
                    strSQL += vbCrLf & "=N'" & txt_registered_sub_district.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[registered_district]"
                    strSQL += vbCrLf & "=N'" & txt_registered_district.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[registered_province]"
                    strSQL += vbCrLf & "=N'" & cbo_registered_province.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[registered_region]"
                    strSQL += vbCrLf & "=N'" & cbo_registered_region.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[registered_postal_code]"
                    strSQL += vbCrLf & "=N'" & txt_registered_postal_code.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[registered_country]"
                    strSQL += vbCrLf & "=N'" & cbo_registered_country.Text.Replace("'", "''") & "'"

                    '===========Mailing Address:===================
                    strSQL += vbCrLf & ",[use_registered_address]"
                    If chk_use_registered_address.Checked = True Then
                        strSQL += vbCrLf & "='Y'"
                    Else
                        strSQL += vbCrLf & "='N'"
                    End If

                    strSQL += vbCrLf & ",[mailing_no]"
                    strSQL += vbCrLf & " = N'" & txt_mailing_no.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[mailing_moo]"
                    strSQL += vbCrLf & "=N'" & txt_mailing_moo.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[mailing_building]"
                    strSQL += vbCrLf & "=N'" & txt_mailing_building.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[mailing_floor]"
                    strSQL += vbCrLf & "=N'" & txt_mailing_floor.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[mailing_soi]"
                    strSQL += vbCrLf & "=N'" & txt_mailing_soi.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[mailing_street]"
                    strSQL += vbCrLf & "=N'" & txt_mailing_street.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[mailing_sub_district]"
                    strSQL += vbCrLf & "=N'" & txt_mailing_sub_district.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[mailing_district]"
                    strSQL += vbCrLf & "=N'" & txt_mailing_district.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[mailing_province]"
                    strSQL += vbCrLf & "=N'" & cbo_mailing_province.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[mailing_region]"
                    strSQL += vbCrLf & "=N'" & cbo_mailing_region.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[mailing_postal_code]"
                    strSQL += vbCrLf & "=N'" & txt_mailing_postal_code.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[mailing_country]"
                    strSQL += vbCrLf & "=N'" & cbo_mailing_country.Text.Replace("'", "''") & "'"

                    '==============Contact Point && Relationship==========================
                    strSQL += vbCrLf & ",[contact_name]"
                    strSQL += vbCrLf & "=N'" & txt_contact_name.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[contact_department]"
                    strSQL += vbCrLf & "=N'" & txt_contact_department.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[contact_phone]"
                    strSQL += vbCrLf & "=N'" & txt_contact_phone.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[contact_email]"
                    strSQL += vbCrLf & "=N'" & txt_contact_email.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[contact_fax]"
                    strSQL += vbCrLf & "=N'" & txt_contact_fax.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[contact_mobile]"
                    strSQL += vbCrLf & "=N'" & txt_contact_mobile.Text.Replace("'", "''") & "'"

                    '==========parent========
                    strSQL += vbCrLf & ",[set_as_parent_company]"
                    If rad_set_as_parent_company_y.Checked = True Then
                        strSQL += vbCrLf & "=N'Y'"

                        strSQL += vbCrLf & ",[company_id_parent]"
                        strSQL += vbCrLf & "=N''"

                    Else
                        strSQL += vbCrLf & "=N'N'"

                        strSQL += vbCrLf & ",[company_id_parent]"
                        strSQL += vbCrLf & "=N'" & txt_company_id_parent.Text.Replace("'", "''") & "'"

                    End If

                    strSQL += vbCrLf & ",[beneficiary_advice_detail]"
                    strSQL += vbCrLf & "=N'" & txt_beneficiary_advice_detail.Text.Replace("'", "''") & "'"


                    strSQL += vbCrLf & ",[AuthorizationParameter]"
                    If rad_avm.Checked = True Then
                        strSQL += vbCrLf & "=N'Authorization Matrix'"
                    Else
                        strSQL += vbCrLf & "=N'Signatory Matrix'"
                    End If


                    'chk_login_flag
                    strSQL += vbCrLf & ",[login_flag]"
                    strSQL += vbCrLf & "=N'" & IIf(chk_login_flag.Checked = True, "Y", "N") & "'"
                    strSQL += vbCrLf & ",[login_non]"
                    strSQL += vbCrLf & "=N'" & IIf(chk_login_non.Checked = True, "Y", "N") & "'"
                    strSQL += vbCrLf & ",[login_hw]"
                    strSQL += vbCrLf & "=N'" & IIf(chk_login_hw.Checked = True, "Y", "N") & "'"
                    strSQL += vbCrLf & ",[login_sms]"
                    strSQL += vbCrLf & "=N'" & IIf(chk_login_sms.Checked = True, "Y", "N") & "'"

                    'chk_login_sms_flag
                    strSQL += vbCrLf & ",[login_sms_flag]"
                    strSQL += vbCrLf & "=N'" & IIf(chk_login_sms_flag.Checked = True, "Y", "N") & "'"
                    strSQL += vbCrLf & ",[login_sms_non]"
                    strSQL += vbCrLf & "=N'" & IIf(chk_login_sms_non.Checked = True, "Y", "N") & "'"
                    strSQL += vbCrLf & ",[login_sms_sms]"
                    strSQL += vbCrLf & "=N'" & IIf(chk_login_sms_sms.Checked = True, "Y", "N") & "'"

                    'chk_login_token_flag
                    strSQL += vbCrLf & ",[login_token_flag]"
                    strSQL += vbCrLf & "=N'" & IIf(chk_login_token_flag.Checked = True, "Y", "N") & "'"
                    strSQL += vbCrLf & ",[login_token_non]"
                    strSQL += vbCrLf & "=N'" & IIf(chk_login_token_non.Checked = True, "Y", "N") & "'"
                    strSQL += vbCrLf & ",[login_token_hw]"
                    strSQL += vbCrLf & "=N'" & IIf(chk_login_token_hw.Checked = True, "Y", "N") & "'"

                    strSQL += vbCrLf & ",[h2h_workflow]"
                    strSQL += vbCrLf & "=N'" & IIf(rad_h2h_workflow_client.Checked = True, rad_h2h_workflow_client.Text, rad_h2h_workflow_bank.Text) & "'"

                    strSQL += vbCrLf & ",[customer_float_computation]"
                    strSQL += vbCrLf & "=N'" & IIf(rad_customer_float_computation_stale.Checked = True, rad_customer_float_computation_stale.Text, rad_customer_float_computation_liquidatation.Text) & "'"

                    strSQL += vbCrLf & ",[wht_language]"
                    strSQL += vbCrLf & "=N'" & IIf(rad_wht_language_thai.Checked = True, rad_wht_language_thai.Text, rad_wht_language_english.Text) & "'"


                    strSQL += vbCrLf & ",[ivr_fax]"
                    If rad_ivr_fax_y.Checked = True Then
                        strSQL += vbCrLf & "=N'Y'"
                    Else
                        strSQL += vbCrLf & "=N'N'"
                    End If

                    strSQL += vbCrLf & ",[ivr_email]"
                    If rad_ivr_email_y.Checked = True Then
                        strSQL += vbCrLf & "=N'Y'"
                    Else
                        strSQL += vbCrLf & "=N'N'"
                    End If


                End If ' If txt_revision_code.Text.ToUpper = "Rev0001".ToUpper Or rad_new.Checked = True Then

                If rad_revision.Checked = True Then
                    strSQL += vbCrLf & ",[revision_code]"
                    strSQL += vbCrLf & "=N'" & txt_revision_code.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[revision_desc]"
                    strSQL += vbCrLf & "=N'" & txt_revision_desc.Text.Replace("'", "''") & "'"

                    strSQL += vbCrLf & ",[revision_date]"
                    strSQL += vbCrLf & "= '" & strRevDate & "'"

                    If txt_revision_code.Text.ToUpper = "Rev0002".ToUpper Then
                        strSQL += vbCrLf & ",[gcp_service_end_date]"
                        strSQL += vbCrLf & "=" & get_date_sql(txt_gcp_service_end_date.Text) & ""
                    End If

                End If


                strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
                '[TB_DEAL_UMM_COMPANY] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''")+ "'"


                '===========add tag of history----------------
                If txt_revision_code.Text <> "" Then 'rad_revision.Checked = True and
                    strSQL += vbCrLf & " DELETE FROM dbo.TB_REVISION_HISTORY WHERE company_id='" + txt_company_id.Text.Replace("'", "''") + "'"
                    strSQL += vbCrLf & "   and revision_code='" + txt_revision_code.Text.Replace("'", "''") + "' "

                    strSQL += vbCrLf & " insert into  TB_REVISION_HISTORY (company_id,revision_code,revision_desc,revision_date) values ("
                    'company_id,revision_code,revision_desc,revision_date,revision_reason
                    strSQL += vbCrLf & " '" + txt_company_id.Text.Replace("'", "''") + "'"
                    strSQL += vbCrLf & " ,N'" & txt_revision_code.Text.Replace("'", "''") & "' "
                    strSQL += vbCrLf & " ,N'" & txt_revision_desc.Text.Replace("'", "''") & "'"
                    strSQL += vbCrLf & " , '" & strRevDate & "'"


                    strSQL += vbCrLf & " "

                    strSQL += vbCrLf & ")"
                End If

                strErr = conn.ExecuteNonQuery(strSQL)

            End If

            'update to tracking system

            'cbo_status.Items.Add("Generate File")
            ' cbo_status.Items.Add("Ensured File")
            'cbo_status.Items.Add("Revision File")
            'cbo_status.Items.Add("Program Error")
            'cbo_status.Items.Add("N/A")
            '  If cbo_status.Text <> "Ensured File" Then


            strSQL = ""
            strSQL += vbCrLf & "  update dbo.TB_TRACKING_SUMMARY set "

            Select Case cbo_status.Text
                Case "Generate File"
                    strSQL += vbCrLf & " status='Completed' "
                    strSQL += vbCrLf & " ,result='Generated File' "

                Case "Ensured File"
                    strSQL += vbCrLf & " status='Completed' "
                    strSQL += vbCrLf & " ,result='Ensured File' "

                Case "Revision File"
                    strSQL += vbCrLf & " status='In Progress' "
                    strSQL += vbCrLf & " ,result='Revision' "
                Case "Program Error"
                    strSQL += vbCrLf & " status='In Progress' "
                    strSQL += vbCrLf & " ,result='Program Error' "
                Case Else
                    strSQL += vbCrLf & " status='' "
                    strSQL += vbCrLf & " ,result='' "
            End Select

            strSQL += vbCrLf & " where task_name like '%Ensure Data%' "
            strSQL += vbCrLf & " and company_id='" & txt_company_id.Text.Replace("'", "''") & "' "

            strErr = conn.ExecuteNonQuery(strSQL)


            If Len(strErr) > 0 Then
                MessageBox.Show(strErr)
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try

    End Function

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


    Private Sub CheckErrorTab()
        Dim strErr As String = ""
        If int_tab_main = 0 Then strErr = ValidationData_CreateCompanyProfile()
        If int_tab_main = 1 Then strErr = ValidationData_Address()
        If strErr <> "" Then

            'tab_main.SelectedIndex = int_tab_main
            ' txt_company_th.Focus()
            ' e.Cancel = True
            MessageBox.Show(strErr)

            Exit Sub
        End If
    End Sub

#End Region

#Region "Account"

    Private Sub SetGrid_Account()
        Dim strSQL As String = ""

        Try

            strSQL = "exec [SP_ta_Account_Select] '" & txt_company_id.Text & "'"
            grd_account.DataSource = conn.BindingDT(strSQL, "Deal_Account")

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_edit_account_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_account.Click
        Call EditAccount()
    End Sub

    Private Sub EditAccount()
        If btn_edit_account.Enabled = False Then Exit Sub


        If strMODE = "ADD" Then
            Call SaveMain()
        End If

        If grd_account.RowCount = 0 Then Exit Sub
        If grd_account.CurrentRow.Cells(0).Value = "" Then Exit Sub
        Dim mFrm_DealSummary_Account As New Frm_DealSummary_Account
        mFrm_DealSummary_Account.strMODE = "EDIT"
        mFrm_DealSummary_Account.txt_company_id.Text = txt_company_id.Text
        mFrm_DealSummary_Account.txt_account_number.Text = grd_account.CurrentRow.Cells(0).Value
        If txt_revision_code.Text <> "" Then
            mFrm_DealSummary_Account.txt_revision_code.Text = txt_revision_code.Text
            mFrm_DealSummary_Account.txt_revision_desc.Text = txt_revision_desc.Text
            mFrm_DealSummary_Account.lbHead.Text += " - " & txt_revision_desc.Text
        End If
        If chk_deal_cover_inquiry.Checked = False Then
            mFrm_DealSummary_Account.chk_acc_stt.Enabled = False
            mFrm_DealSummary_Account.chk_bill_payment.Enabled = False
            mFrm_DealSummary_Account.chk_sq.Enabled = False
        End If
        If chk_deal_cover_payment.Checked = False Then
            mFrm_DealSummary_Account.chk_payment.Enabled = False
            ' mFrm_DealSummary_Account.chk_default_account.Enabled = False
        End If

        mFrm_DealSummary_Account.bPayment = chk_deal_cover_payment.Checked
        If bIsViewOnly = True Then
            mFrm_DealSummary_Account.BT_Update.Enabled = False
        End If

        mFrm_DealSummary_Account.ShowDialog()
        Call SetGrid_Account()
    End Sub

    Private Sub btn_new_account_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_account.Click
        If strMODE = "ADD" Then
            Call SaveMain()
        End If

        Dim mFrm_DealSummary_Account As New Frm_DealSummary_Account
        mFrm_DealSummary_Account.strMODE = "ADD"
        mFrm_DealSummary_Account.txt_company_id.Text = txt_company_id.Text
        mFrm_DealSummary_Account.txt_account_name.Text = txt_companyname_th.Text

        If txt_revision_code.Text <> "" Then
            mFrm_DealSummary_Account.txt_revision_code.Text = txt_revision_code.Text
            mFrm_DealSummary_Account.txt_revision_desc.Text = txt_revision_desc.Text
            mFrm_DealSummary_Account.lbHead.Text += " - " & txt_revision_desc.Text
        End If

        '  If grd_account.RowCount = 0 Then
        'mFrm_DealSummary_Account.chk_default_account.Checked = True
        'End If

        If chk_deal_cover_inquiry.Checked = False Then
            mFrm_DealSummary_Account.chk_acc_stt.Enabled = False
            mFrm_DealSummary_Account.chk_bill_payment.Enabled = False
            mFrm_DealSummary_Account.chk_sq.Enabled = False
        End If

        If chk_deal_cover_payment.Checked = False Then
            mFrm_DealSummary_Account.chk_payment.Enabled = False
        Else
            mFrm_DealSummary_Account.chk_payment.Checked = True
        End If

        mFrm_DealSummary_Account.bPayment = chk_deal_cover_payment.Checked

        mFrm_DealSummary_Account.ShowDialog()

        Call SetGrid_Account()
    End Sub

    Private Sub grd_account_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_account.CellDoubleClick
        Call EditAccount()
    End Sub

    Private Sub btn_delete_account_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete_account.Click
        Try
            If grd_account.RowCount = 0 Then Exit Sub
            If grd_account.CurrentRow.Cells(0).Value = "" Then Exit Sub
            Dim strSQL As String = ""
            Dim intCount As String = ""

            strSQL = " select count(*) as c FROM dbo.TB_DEAL_PRODUCT_ACCOUNT a WHERE a.company_id='" + txt_company_id.Text.Replace("'", "''") + "' and account_number='" + grd_account.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") + "' "
            intCount = conn.GetDataFromSQL(strSQL)
            If CDbl(intCount) > 0 Then
                MsgBox("This product was used by some Product.")
                Exit Sub
            End If


            If MsgBox("Do you want to delete?", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
                '  Dim strSQL As String = ""
                strSQL = "delete from [TB_DEAL_ACCOUNT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + grd_account.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") + "' "
                conn.ExecuteNonQuery(strSQL)
                Call SetGrid_Account()
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

#End Region

#Region "Products"

    Private Sub SetGrid_Product()
        Dim strSQL As String
        Dim strCrit As String = ""

        Try

            If txt_company_id.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " a.[company_id] = '" & txt_company_id.Text & "'"
            Else
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " 1=0"
            End If

            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            strSQL += vbCrLf & " a.[my_product] as [My Product Code] "
            strSQL += vbCrLf & "  ,a.[product_name] as [My Product Name] "
            strSQL += vbCrLf & "  ,a.[ude_product] as [UDE Product] "
            strSQL += vbCrLf & "  , a.[bank_product] as [Bank Product] "



            strSQL += vbCrLf & "  ,  a.[per_txm_max_amt] as [Per Txn Max Amt] "
            strSQL += vbCrLf & "  ,  a.[arrangement] as [Arrangement] "

            'strSQL += vbCrLf & " a.[my_product] as [My Product Code] "
            'strSQL += vbCrLf & "  ,a.[product_name] as [My Product Name] "
            'strSQL += vbCrLf & "  ,a.[ude_product] as [UDE Product] "



            'strSQL += vbCrLf & "  ,a.[account_number] as [Account Number] "
            'strSQL += vbCrLf & "  ,a.[pickup_location] as [Pickup Location] "
            'strSQL += vbCrLf & "  ,a.[product_template] as [Product Template]"
            'strSQL += vbCrLf & "  ,a.[charge_template] as [Charge Template] "
            'strSQL += vbCrLf & "  ,a.[beneficiary_type] as [Beneficiary Type]"
            'strSQL += vbCrLf & "  ,a.[my_product_usage] as [My Product Usage]"
            'strSQL += vbCrLf & "  ,a.[auth_type] as [Auth Type] "
            'strSQL += vbCrLf & "  ,a.[auth_level] as [Auth Level]"
            'strSQL += vbCrLf & "  ,a.[adhoc_allow] as [Adhoc Allow] "
            ''--Beneficiary Advice
            'strSQL += vbCrLf & "  ,a.[beneficiary_advice_detail] as [Beneficiary Advice Detail] "
            'strSQL += vbCrLf & "  ,a.[manual_entry_approve_required] as [Manual Entry-Approve Required] "
            'strSQL += vbCrLf & "  ,a.[manual_entry_verify_required] as [Manual Entry-Verify Required] "
            'strSQL += vbCrLf & "   ,a.[manual_entry_send_required] as [Manual Entry-Send Required] "
            '' --[File Upload]
            'strSQL += vbCrLf & "  ,a.[file_upload_auto_submit] as [File Upload-Auto Submit] "
            'strSQL += vbCrLf & "  ,a.[file_upload_allow_transaction_edit] as [File Upload-Allow Transaction Edit] "
            'strSQL += vbCrLf & "  ,a.[file_upload_approve_required] as [File Upload-Approve Required] "
            'strSQL += vbCrLf & "   ,a.[file_upload_verify_required] as [File Upload-Verify Required] "
            'strSQL += vbCrLf & "  ,a.[file_upload_send_required] as [File Upload-Send Required] "
            'strSQL += vbCrLf & "  ,a.[file_upload_action] as [File Upload-File Uplaod Action] "
            ''--SI
            'strSQL += vbCrLf & "  ,a.[si_submit_required] as [SI-Submit Required]"
            'strSQL += vbCrLf & "  ,a.[si_approve_required] as [SI-Approve Required]"
            'strSQL += vbCrLf & "  ,a.[si_verify_required] as [SI-Verify Required]"
            'strSQL += vbCrLf & "  ,a.[si_send_required] as [SI-Send Required]"
            'strSQL += vbCrLf & "  ,a.[si_auto_approve] as [SI-Auto Approve]"
            ''---validation
            'strSQL += vbCrLf & "  ,a.[validation_user_product] as [validation-User-Product] "
            'strSQL += vbCrLf & "  ,a.[validation_product_account] as [validation-Product - Account]"
            'strSQL += vbCrLf & "  ,a.[validation_user_account] as [validation-User - Account]"
            'strSQL += vbCrLf & "  ,a.[validation_product_beneficiary] as [validation-Product - Beneficiary]"
            'strSQL += vbCrLf & "  ,a.[validation_zero_proofing] as [validation-Zero Proofing] "
            'strSQL += vbCrLf & "  ,a.[validation_scrap_if_not_auth_or_send] as [validation-Scrap if not Auth or Send] "
            'strSQL += vbCrLf & "  ,a.[validation_notify_user_of_scrap_before_day] as [validation-Notify user of scrap before (day)]"
            ''-----notofication
            'strSQL += vbCrLf & "  ,a.[payee_notofication_fax] as [Fax] "
            'strSQL += vbCrLf & "  ,a.[payee_notofication_email] as [Email] "

            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & "  [TB_DEAL_PRODUCT] a "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " ORDER BY    "

            strSQL += vbCrLf & " a.[my_product]  "
            strSQL += vbCrLf & "  , a.[bank_product]  "
            strSQL += vbCrLf & "  ,  a.[per_txm_max_amt]  "
            strSQL += vbCrLf & "  ,  a.[arrangement]  "



            Call conn.SetGrid(strSQL, grd_product)

            If grd_product.RowCount > 0 Then
                grd_product.Rows.Item(0).Selected = True
                grd_product.Columns("My Product Name").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                'Per Txn Max Amt
                grd_product.Columns("Per Txn Max Amt").DefaultCellStyle.Format = "###,##0.00"
                grd_product.Columns("Per Txn Max Amt").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


                ' txt_Company_ID_Selected.Text = grd_account.CurrentRow.Cells(0).Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_new_product_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_product.Click
        If strMODE = "ADD" Then
            Call SaveMain()
        End If

        Dim Frm_DealSummary_Product_SelectMyProduct As New Frm_DealSummary_Product_SelectMyProduct
        Frm_DealSummary_Product_SelectMyProduct.strMODE = "ADD"

        Frm_DealSummary_Product_SelectMyProduct.txt_company_id.Text = txt_company_id.Text
        Frm_DealSummary_Product_SelectMyProduct.txt_MYPRODUCT.Text = ""

        If txt_revision_code.Text <> "" Then
            Frm_DealSummary_Product_SelectMyProduct.txt_revision_code.Text = txt_revision_code.Text
            Frm_DealSummary_Product_SelectMyProduct.txt_revision_desc.Text = txt_revision_desc.Text
            Frm_DealSummary_Product_SelectMyProduct.lbHead.Text += " - " & txt_revision_desc.Text
        End If


        Frm_DealSummary_Product_SelectMyProduct.ShowDialog()


        Call SetGrid_Product()
    End Sub

    Private Sub btn_edit_product_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_product.Click
        Call EditProduct()
    End Sub

    Private Sub EditProduct()

        If btn_edit_product.Enabled = False Then Exit Sub

        If strMODE = "ADD" Then
            Call SaveMain()
        End If

        If grd_product.RowCount = 0 Then Exit Sub
        If grd_product.CurrentRow.Cells(0).Value = "" Then Exit Sub


        Dim Frm_DealSummary_Product_SelectMyProduct As New Frm_DealSummary_Product_SelectMyProduct
        Frm_DealSummary_Product_SelectMyProduct.strMODE = "EDIT"

        Frm_DealSummary_Product_SelectMyProduct.txt_company_id.Text = txt_company_id.Text
        Frm_DealSummary_Product_SelectMyProduct.txt_MYPRODUCT.Text = grd_product.CurrentRow.Cells(0).Value

        If txt_revision_code.Text <> "" Then
            If txt_revision_code.Text.ToUpper = "Rev0009".ToUpper Then
                If Not (grd_product.CurrentRow.Cells(3).Value = "COC" Or grd_product.CurrentRow.Cells(3).Value = "COE") Then
                    MsgBox("Product is not equal COC or COE only")
                    Exit Sub
                End If

            End If

            Frm_DealSummary_Product_SelectMyProduct.txt_revision_code.Text = txt_revision_code.Text
            Frm_DealSummary_Product_SelectMyProduct.txt_revision_desc.Text = txt_revision_desc.Text
            Frm_DealSummary_Product_SelectMyProduct.lbHead.Text += " - " & txt_revision_desc.Text
        End If


        If bIsViewOnly = True Then
            Frm_DealSummary_Product_SelectMyProduct.bIsViewOnly = bIsViewOnly

        End If

        Frm_DealSummary_Product_SelectMyProduct.ShowDialog()


        'Dim mFrm_DealSummary_Product As New Frm_DealSummary_Product
        'mFrm_DealSummary_Product.strMODE = "EDIT"
        'mFrm_DealSummary_Product.txt_company_id.Text = txt_company_id.Text
        'mFrm_DealSummary_Product.txt_my_product.Text = grd_product.CurrentRow.Cells(0).Value

        'If txt_revision_code.Text <> "" Then
        '    If txt_revision_code.Text.ToUpper = "Rev0009".ToUpper Then
        '        If Not (grd_product.CurrentRow.Cells(2).Value = "COC" Or grd_product.CurrentRow.Cells(2).Value = "COE") Then
        '            MsgBox("Product is not equal COC or COE only")
        '            Exit Sub
        '        End If

        '    End If

        '    mFrm_DealSummary_Product.txt_revision_code.Text = txt_revision_code.Text
        '    mFrm_DealSummary_Product.txt_revision_desc.Text = txt_revision_desc.Text
        '    mFrm_DealSummary_Product.lbHead.Text += " - " & txt_revision_desc.Text
        'End If

        'mFrm_DealSummary_Product.ShowDialog()

        Call SetGrid_Product()

    End Sub

    Private Sub btn_revision_add_charge_package_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_revision_add_charge_package.Click

        If grd_product.RowCount = 0 Then Exit Sub
        If grd_product.CurrentRow.Cells(0).Value = "" Then Exit Sub
        Frm_DealSummary_Product_ChargePackageRev_List.txt_revision_code.Text = txt_revision_code.Text
        Frm_DealSummary_Product_ChargePackageRev_List.txt_revision_desc.Text = txt_revision_desc.Text
        Frm_DealSummary_Product_ChargePackageRev_List.txt_company_id.Text = txt_company_id.Text
        Frm_DealSummary_Product_ChargePackageRev_List.txt_my_product.Text = grd_product.CurrentRow.Cells(0).Value
        Frm_DealSummary_Product_ChargePackageRev_List.ShowDialog()
       
    End Sub

    Private Sub grd_product_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_product.CellDoubleClick
        Call EditProduct()
    End Sub

    Private Sub btn_delete_product_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete_product.Click
        Try
            Dim strSQL As String = ""
            Dim intCount As String = ""

            strSQL = " select count(*) as c FROM dbo.TB_DEAL_UMM_USER_PRODUCT a "
            strSQL += " WHERE a.company_id='" + txt_company_id.Text.Replace("'", "''") + "' "
            strSQL += "  and product_code='" + grd_product.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") + "' "
            'strSQL += "  and bank_product='" + grd_product.CurrentRow.Cells(2).Value.ToString.Replace("'", "''") + "' "

            ' strSQL += vbCrLf & " AND bank_product ='" + cbo_bank_product.Text.Replace("'", "''") + "'"

            intCount = conn.GetDataFromSQL(strSQL)
            If CDbl(intCount) > 0 Then
                MsgBox("This product was used by some user.")
                Exit Sub
            End If

            'strSQL = " select count(*) as c FROM dbo.TB_DEAL_PRODUCT_ACCOUNT a WHERE a.company_id='" + txt_company_id.Text.Replace("'", "''") + "' and my_product='" + grd_product.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") + "' "
            'intCount = conn.GetDataFromSQL(strSQL)
            'If CDbl(intCount) > 0 Then
            '    MsgBox("This product was used by some Account.")
            '    Exit Sub
            'End If


            If grd_product.RowCount = 0 Then Exit Sub
            If grd_product.CurrentRow.Cells(0).Value = "" Then Exit Sub

            If MsgBox("Do you want to delete?", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
                ' strSQL += "  and bank_product='" + grd_product.CurrentRow.Cells(2).Value.ToString.Replace("'", "''") + "' "

                strSQL = ""
                strSQL += " delete from [TB_DEAL_PRODUCT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and my_product='" + grd_product.CurrentRow.Cells(0).Value.ToString + "' "
                strSQL += vbCrLf & " delete from [TB_DEAL_PRODUCT_ACCOUNT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and my_product='" + grd_product.CurrentRow.Cells(0).Value.ToString + "' "
                strSQL += vbCrLf & " delete from [TB_DEAL_PRODUCT_PICKUP_LOCATION] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and my_product='" + grd_product.CurrentRow.Cells(0).Value.ToString + "' "

                conn.ExecuteNonQuery(strSQL)
                Call SetGrid_Product()
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

#End Region

#Region "Users"

    Private Sub SetGrid_Users()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""
            strCrit = ""


            If txt_company_id.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " a.[company_id] = '" & txt_company_id.Text & "'"
            Else
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " 1=0 "
            End If

            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            strSQL += vbCrLf & "  a.[user_id] as [User ID] "
            strSQL += vbCrLf & "  ,a.User_Category_ID as [Category] "

            strSQL += vbCrLf & "  ,a.gender as [Gender] "
            strSQL += vbCrLf & "  ,a.title as [Title] "
            strSQL += vbCrLf & "  ,a.firstname as [First Name] "
            strSQL += vbCrLf & "  ,a.lastname as [Last Name] "

            strSQL += vbCrLf & "  ,a.date_of_birth as [Date of Birth] "
            strSQL += vbCrLf & "  ,a.reference_type as [Reference Type]"
            strSQL += vbCrLf & "  ,a.reference_no as [Reference No.]"
            strSQL += vbCrLf & "  ,a.phone as [Phone]"
            strSQL += vbCrLf & "  ,a.mobile_phone as [Mobile Phone]"
            '--authrize
            strSQL += vbCrLf & "  ,a.view_acc_stt_flag as [View Acc.Stt.] "
            strSQL += vbCrLf & "  ,a.view_sq_flag as [View SQ]"
            strSQL += vbCrLf & "  ,a.view_bill_payment_flag as [View Bill Payment]"
            strSQL += vbCrLf & "  ,a.payment_maker_flag as [Payment Maker]"
            strSQL += vbCrLf & "  ,a.payment_verifier_flag as [Payment Verifier]"
            strSQL += vbCrLf & "  ,a.payment_authoriser_flag as [Payment Authoriser]"
            strSQL += vbCrLf & "  ,a.payment_sender_flag as [Payment Sender]"
            strSQL += vbCrLf & "  ,a.admin_maker_flag as [Admin Maker]"
            strSQL += vbCrLf & "  ,a.admin_authoriser_flag as [Admin Authoriser] "
            strSQL += vbCrLf & "  ,a.view_confidential_flag as [View Confidential]"
            strSQL += vbCrLf & "  ,a.super_user_flag as [Super User]"
            strSQL += vbCrLf & "  ,a.across_client_flag as [Across Client]"
            '==============
            strSQL += vbCrLf & "  ,a.log_in_method as [Log in method]"
            strSQL += vbCrLf & "  ,a.auth_method as [Auth Method]"
            strSQL += vbCrLf & "  ,a.email as [Email]"
            strSQL += vbCrLf & "  ,a.token_no as [Token No.] "
            strSQL += vbCrLf & "  ,a.fax as [Fax] "

            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & "  [TB_DEAL_UMM_USER] a "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " ORDER BY  a.User_Category_ID , a.[user_id] "

            Call conn.SetGrid(strSQL, grd_user)
            If grd_user.RowCount > 0 Then
                grd_user.Rows.Item(0).Selected = True

                For i = 0 To grd_user.Columns.Count - 1
                    grd_user.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next
                grd_user.Columns("Date of Birth").DefaultCellStyle.Format = "dd/MMM/yyyy"
                grd_user.Columns("Date of Birth").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                ' txt_Company_ID_Selected.Text = grd_account.CurrentRow.Cells(0).Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub SetGrid_Category()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""
            strCrit = ""


            If txt_company_id.Text <> "" Then
                If rad_set_as_parent_company_y.Checked = True Then
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " a.[company_id] = '" & txt_company_id.Text & "'"
                Else
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " a.[company_id] = '" & txt_company_id_parent.Text & "'"
                End If

            Else
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " 1=0 "
            End If

            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            strSQL += vbCrLf & " a.[company_id]  as [Company ID] "
            strSQL += vbCrLf & " ,a.User_Category_ID  as [User Category ID]"
            strSQL += vbCrLf & " ,a.Report_Category_ID  as [Report Category ID]"
            strSQL += vbCrLf & " ,a.User_Category_Name as [User Category Name]"
            strSQL += vbCrLf & " ,a.Report_Category_Name as [Report Category Name]"
            strSQL += vbCrLf & " ,a.seq as [seq]"
            strSQL += vbCrLf & " ,a.print_flag as [Print Flag]"

            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & "  [TB_CATEGORY] a "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " ORDER BY   a.seq "

            Call conn.SetGrid(strSQL, grd_category)
            If grd_category.RowCount > 0 Then
                grd_category.Rows.Item(0).Selected = True

                For i = 0 To grd_category.Columns.Count - 1
                    grd_category.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub btn_Addnew_User_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Addnew_User.Click
        If strMODE = "ADD" Then
            Call SaveMain()
        End If
        Dim mFrm_DealSummary_User As New Frm_DealSummary_User
        mFrm_DealSummary_User.strMODE = "ADD"
        mFrm_DealSummary_User.strID = txt_company_id.Text
        mFrm_DealSummary_User.txt_company_id.Text = txt_company_id.Text
        mFrm_DealSummary_User.lb_company_id.Text = "@" & txt_company_id.Text
        mFrm_DealSummary_User.txt_user_id.Text = ""

        If txt_revision_code.Text <> "" Then
            mFrm_DealSummary_User.txt_revision_code.Text = txt_revision_code.Text
            mFrm_DealSummary_User.txt_revision_desc.Text = txt_revision_desc.Text
            mFrm_DealSummary_User.lbHead.Text += " - " & txt_revision_desc.Text
        End If

        ' mFrm_DealSummary_User.FillComboALL()
        ' mFrm_DealSummary_User.ShowData 

        If chk_deal_cover_inquiry.Checked = False Then
            mFrm_DealSummary_User.chk_view_acc_stt_flag.Enabled = False
            mFrm_DealSummary_User.chk_view_sq_flag.Enabled = False
            mFrm_DealSummary_User.chk_view_bill_payment_flag.Enabled = False
        End If

        If chk_deal_cover_payment.Checked = False Then
            mFrm_DealSummary_User.chk_payment_maker_flag.Enabled = False
            mFrm_DealSummary_User.chk_payment_verifier_flag.Enabled = False
            mFrm_DealSummary_User.chk_payment_authoriser_flag.Enabled = False
            mFrm_DealSummary_User.chk_payment_sender_flag.Enabled = False
        End If

        If chk_deal_cover_admin.Checked = False Then
            mFrm_DealSummary_User.chk_admin_maker_flag.Enabled = False
            mFrm_DealSummary_User.chk_admin_authoriser_flag.Enabled = False
        End If


        mFrm_DealSummary_User.ShowDialog()
        Call SetGrid_Users()
        Call SetGrid_Category()
    End Sub

    Private Sub EditUsers()
        If btn_edit_user.Enabled = False Then Exit Sub

        If strMODE = "ADD" Then
            Call SaveMain()
        End If


        If grd_user.RowCount = 0 Then Exit Sub
        If grd_user.CurrentRow.Cells(0).Value = "" Then Exit Sub

        Dim mFrm_DealSummary_User As New Frm_DealSummary_User
        mFrm_DealSummary_User.strMODE = "EDIT"
        mFrm_DealSummary_User.chkInquiry = chk_deal_cover_inquiry.Checked
        mFrm_DealSummary_User.strID = txt_company_id.Text
        mFrm_DealSummary_User.txt_company_id.Text = txt_company_id.Text
        mFrm_DealSummary_User.lb_company_id.Text = "@" & txt_company_id.Text
        mFrm_DealSummary_User.txt_user_id.Text = grd_user.CurrentRow.Cells(0).Value

        If txt_revision_code.Text <> "" Then
            mFrm_DealSummary_User.txt_revision_code.Text = txt_revision_code.Text
            mFrm_DealSummary_User.txt_revision_desc.Text = txt_revision_desc.Text
            mFrm_DealSummary_User.lbHead.Text += " - " & txt_revision_desc.Text
        End If

        ' mFrm_DealSummary_User.FillComboALL()
        'mFrm_DealSummary_User.ShowData()

        If rad_set_as_parent_company_y.Checked = True Then
            mFrm_DealSummary_User.txt_company_id_parent.Text = txt_company_id.Text
        Else
            mFrm_DealSummary_User.txt_company_id_parent.Text = txt_company_id_parent.Text
        End If

        If chk_deal_cover_inquiry.Checked = False Then
            mFrm_DealSummary_User.chk_view_acc_stt_flag.Enabled = False
            mFrm_DealSummary_User.chk_view_sq_flag.Enabled = False
            mFrm_DealSummary_User.chk_view_bill_payment_flag.Enabled = False
        End If

        If chk_deal_cover_payment.Checked = False Then
            mFrm_DealSummary_User.chk_payment_maker_flag.Enabled = False
            mFrm_DealSummary_User.chk_payment_verifier_flag.Enabled = False
            mFrm_DealSummary_User.chk_payment_authoriser_flag.Enabled = False
            mFrm_DealSummary_User.chk_payment_sender_flag.Enabled = False
        End If

        If chk_deal_cover_admin.Checked = False Then
            mFrm_DealSummary_User.chk_admin_maker_flag.Enabled = False
            mFrm_DealSummary_User.chk_admin_authoriser_flag.Enabled = False
        End If


        If bIsViewOnly = True Then
            mFrm_DealSummary_User.BT_Update.Enabled = False
            mFrm_DealSummary_User.btn_clear_category.Enabled = False
            mFrm_DealSummary_User.btn_ChangeCategory.Enabled = False
        End If

        mFrm_DealSummary_User.ShowDialog()
        Call SetGrid_Users()
        Call SetGrid_Category()

    End Sub

    Private Sub btn_edit_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_user.Click
        Call EditUsers()
    End Sub

    Private Sub grd_user_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_user.CellDoubleClick
        Call EditUsers()
    End Sub

    Private Sub brn_delete_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete_user.Click
        Try
            If grd_user.RowCount = 0 Then Exit Sub
            If grd_user.CurrentRow.Cells(0).Value = "" Then Exit Sub

            If MsgBox("Do you want to delete?", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
                Dim strSQL As String = ""
                strSQL = ""
                strSQL += "  delete from [TB_DEAL_UMM_USER] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and user_id ='" + grd_user.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") + "' "
                strSQL += vbCrLf & "  delete from [TB_DEAL_UMM_USER_ACCOUNT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and user_id ='" + grd_user.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") + "' "
                strSQL += vbCrLf & "  delete from [TB_DEAL_UMM_USER_PRODUCT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and user_id ='" + grd_user.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") + "' "
                strSQL += vbCrLf & "  delete from [TB_DEAL_UMM_USER_ACROSS] WHERE [company_id_across] ='" + txt_company_id.Text.Replace("'", "''") + "'  and user_id ='" + grd_user.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") + "' "

                'TB_DEAL_UMM_USER_ACROSS

                conn.ExecuteNonQuery(strSQL)
                Call SetGrid_Users()
                Call SetGrid_Category()
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


#End Region

#Region "Interface"

    Private Sub SetGrid_Interface()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""
            strCrit = ""


            If txt_company_id.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [company_id] = '" & txt_company_id.Text.Replace("'", "''") & "'"
            Else
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " 1=0"
            End If

            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            strSQL += vbCrLf & "  mapping_code as [Mapping Code] "
            strSQL += vbCrLf & "   ,mapping_description as [Mapping Description] "
            strSQL += vbCrLf & "  ,interface_code as [Interface Code]"
            strSQL += vbCrLf & "  ,process_code as [Process Code]"
            strSQL += vbCrLf & "  ,description_for_csd as [Description for CSD]"
            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & " TB_DEAL_INTERFACE a "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " ORDER BY   a.mapping_code "

            Call conn.SetGrid(strSQL, grd_interface)
            If grd_interface.RowCount > 0 Then
                grd_interface.Rows.Item(0).Selected = True
                ' txt_Company_ID_Selected.Text = grd_account.CurrentRow.Cells(0).Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_new_interface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_interface.Click
        If strMODE = "ADD" Then
            Call SaveMain()
        End If

        Dim mFrm_DealSummary_Interface As New Frm_DealSummary_Interface
        mFrm_DealSummary_Interface.strMODE = "ADD"


        mFrm_DealSummary_Interface.btnFind.Visible = True
        mFrm_DealSummary_Interface.txt_company_id.Text = txt_company_id.Text
        mFrm_DealSummary_Interface.txt_mapping_code.Text = ""
        mFrm_DealSummary_Interface.ShowDialog()
        Call SetGrid_Interface()

    End Sub

    Private Sub btn_new_interface_product_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_interface_product.Click

        Try
            If grd_interface.RowCount > 0 Then
                If MsgBox("Do you want to replace data.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            Dim strSQL As String = "EXEC [SP_NewInterfaceProduct] '" & txt_company_id.Text.Replace("'", "''") & "' "

            'strSQL = ""
            'strSQL += vbCrLf & "  delete from TB_DEAL_INTERFACE where company_id='" & txt_company_id.Text.Replace("'", "''") & "'"
            'strSQL += vbCrLf & "  insert into [TB_DEAL_INTERFACE]"
            'strSQL += vbCrLf & "  ("
            'strSQL += vbCrLf & "   [company_id]"
            'strSQL += vbCrLf & "       ,[interface_type]"
            'strSQL += vbCrLf & "      ,[mapping_code]"
            'strSQL += vbCrLf & "      ,[mapping_description]"
            'strSQL += vbCrLf & "      ,[interface_code]"
            'strSQL += vbCrLf & "      ,[process_code]"
            'strSQL += vbCrLf & "        ,[checksum_flag]"
            'strSQL += vbCrLf & "        ,[checksum_algorithm]"
            'strSQL += vbCrLf & "        ,[encryption_flag]"
            'strSQL += vbCrLf & "       ,[cryptography_type]"
            'strSQL += vbCrLf & "       ,[encryption_algorithm]"
            'strSQL += vbCrLf & "       ,[key_length]"
            'strSQL += vbCrLf & "       ,[encryption_key]"
            'strSQL += vbCrLf & "        ,[signing_flag]"
            'strSQL += vbCrLf & "       ,[signing_type]"
            'strSQL += vbCrLf & "       ,[signing_algorithm]"
            'strSQL += vbCrLf & "       ,[expiry_date]"
            'strSQL += vbCrLf & "       ,[auto_auth_flag]"
            'strSQL += vbCrLf & "       ,[description_for_csd]"
            'strSQL += vbCrLf & "  )"

            'strSQL += vbCrLf & "  SELECT  distinct '" & txt_company_id.Text.Replace("'", "''") & "' as [company_id]"
            'strSQL += vbCrLf & "       ,a.[interface_type]"
            'strSQL += vbCrLf & "       ,a.[mapping_code]"
            'strSQL += vbCrLf & "      ,a.[mapping_description]"
            'strSQL += vbCrLf & "      ,a.[interface_code]"
            'strSQL += vbCrLf & "       ,a.[process_code]"
            'strSQL += vbCrLf & "       ,a.[checksum_flag]"
            'strSQL += vbCrLf & "        ,a.[checksum_algorithm]"
            'strSQL += vbCrLf & "       ,a.[encryption_flag]"
            'strSQL += vbCrLf & "      ,a.[cryptography_type]"
            'strSQL += vbCrLf & "      ,a.[encryption_algorithm]"
            'strSQL += vbCrLf & "      ,a.[key_length]"
            'strSQL += vbCrLf & "      ,a.[encryption_key]"
            'strSQL += vbCrLf & "       ,a.[signing_flag]"
            'strSQL += vbCrLf & "      ,a.[signing_type]"
            'strSQL += vbCrLf & "       ,a.[signing_algorithm]"
            'strSQL += vbCrLf & "      ,a.[expiry_date]"
            'strSQL += vbCrLf & "      ,a.[auto_auth_flag]"
            'strSQL += vbCrLf & "       ,a.[description_for_csd]"
            'strSQL += vbCrLf & "  FROM  dbo.TB_DEAL_INTERFACE_TEMPLATE a"
            'strSQL += vbCrLf & "  inner join dbo.TB_DEAL_PRODUCT p"
            'strSQL += vbCrLf & "  on p.my_product = (case when a.mapping_code ='PCTDRVA' then  'PCT' else a.mapping_code end ) "
            'strSQL += vbCrLf & " where p.company_id= '" & txt_company_id.Text.Replace("'", "''") & "' "
            ''[company_id]

            conn.ExecuteNonQuery(strSQL)

            Call SetGrid_Interface()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub btn_edit_interface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_interface.Click
        Call EditInterface()
    End Sub

    Private Sub EditInterface()
        If btn_edit_interface.Enabled = False Then Exit Sub

        If strMODE = "ADD" Then
            Call SaveMain()
        End If

        If grd_interface.RowCount = 0 Then Exit Sub
        If grd_interface.CurrentRow.Cells(0).Value = "" Then Exit Sub
        Dim mFrm_DealSummary_Interface As New Frm_DealSummary_Interface
        mFrm_DealSummary_Interface.strMODE = "EDIT"
        mFrm_DealSummary_Interface.txt_company_id.Text = txt_company_id.Text
        mFrm_DealSummary_Interface.txt_mapping_code.Text = grd_interface.CurrentRow.Cells(0).Value

        If bIsViewOnly = True Then
            mFrm_DealSummary_Interface.BT_Update.Enabled = False
        End If
        mFrm_DealSummary_Interface.ShowDialog()
        Call SetGrid_Interface()
    End Sub

    Private Sub btn_delete_interface_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete_interface.Click

        Try
            If grd_interface.RowCount = 0 Then Exit Sub
            If grd_interface.CurrentRow.Cells(0).Value = "" Then Exit Sub

            If MsgBox("Do you want to delete?", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
                Dim strSQL As String = ""
                strSQL = "delete from [TB_DEAL_INTERFACE] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and mapping_code ='" + grd_interface.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") + "' "
                conn.ExecuteNonQuery(strSQL)
                Call SetGrid_Interface()
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

#End Region

#Region "Auth"

    Private Sub SetGrid_Auth()
        Dim strSQL As String = ""
        Dim strCrit As String = ""

        Try

            strCrit = ""

            If txt_company_id.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [company_id] = '" & txt_company_id.Text & "'"
            Else
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " 1=0"
            End If

            If txt_company_id.Text <> "" Then
                If rad_avm.Checked = True Then
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " AuthorizationParameter='Authorization Matrix' "
                Else
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " AuthorizationParameter='Signatory Matrix' "
                End If
            End If


            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            'AuthorizationParameter
            strSQL += vbCrLf & "  AuthorizationParameter as [Authorization Parameter] " '--0
            strSQL += vbCrLf & "  ,Product as [Product] " '--1
            strSQL += vbCrLf & "  , AuthorizationType as [Authorization Type] " '2
            strSQL += vbCrLf & "  , Account as [Account] " '3
            strSQL += vbCrLf & "  , LimitFrom as [Limit From] " '4
            strSQL += vbCrLf & "  , LimitTo as [Limit To] " '5
            ' If rad_avm.Checked = True Then
            strSQL += vbCrLf & "  , LevelNumber as [Level] " '6
            strSQL += vbCrLf & "  , NoOfUser as [No. of User] " '7
            'End If
            strSQL += vbCrLf & "  , SignatoryMatrix as [User] " '8
            strSQL += vbCrLf & "  , ID " '9
            strSQL += vbCrLf & "  , Valid_flag" '10
            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & " TB_DEAL_AUTH a "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " ORDER BY   a.Product,a.AuthorizationType,a.Account,a.LimitFrom ,a.LimitTo,a.LevelNumber"

            Call conn.SetGrid(strSQL, grd_auth)
            If grd_auth.RowCount > 0 Then
                grd_auth.Columns("User").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                grd_auth.Rows.Item(0).Selected = True

                '    strSQL += vbCrLf & "  , LimitFrom as [Limit From] " '4
                ' strSQL += vbCrLf & "  , ng as [Limit To] " '5

                grd_auth.Columns("Limit From").DefaultCellStyle.Format = "###,##0.00"
                grd_auth.Columns("Limit To").DefaultCellStyle.Format = "###,##0.00"
                grd_auth.Columns("Limit From").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                grd_auth.Columns("Limit To").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                ' rad_avm.Enabled = False
                ' rad_svm.Enabled = False
                If rad_svm.Checked = True Then
                    grd_auth.Columns("Level").Visible = False
                    grd_auth.Columns("No. of User").Visible = False
                Else
                    grd_auth.Columns("Level").Visible = True
                    grd_auth.Columns("No. of User").Visible = True
                End If



            Else
                'rad_avm.Enabled = True
                'rad_svm.Enabled = True
                ' txt_Company_ID_Selected.Text = grd_account.CurrentRow.Cells(0).Value
            End If


        Catch ex As Exception
            '  MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_new_auth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_auth.Click
        If strMODE = "ADD" Then
            Call SaveMain()
        End If
        Dim mFrm_DealSummary_auth As New Frm_DealSummary_auth
        mFrm_DealSummary_auth.strMODE = "ADD"
        '  mFrm_DealSummary_auth.FillComboALL()
        mFrm_DealSummary_auth.txt_company_id.Text = txt_company_id.Text

        If rad_avm.Checked = True Then
            mFrm_DealSummary_auth.strAuthorizationParameter = "Authorization Matrix"
        Else
            mFrm_DealSummary_auth.strAuthorizationParameter = "Signatory Matrix"
        End If

        If rad_svm.Checked = True Then
            mFrm_DealSummary_auth.strLevelNumber = "0"
            mFrm_DealSummary_auth.strNoOfUser = "0"
        End If

        If grd_auth.RowCount > 0 And rad_avm.Checked = True Then

            'mFrm_DealSummary_auth.strProduct = grd_auth.CurrentRow.Cells(1).Value
            'mFrm_DealSummary_auth.strAuthorizationType = grd_auth.CurrentRow.Cells(2).Value
            'mFrm_DealSummary_auth.strAccount = grd_auth.CurrentRow.Cells(3).Value
            'mFrm_DealSummary_auth.strLimitFrom = grd_auth.CurrentRow.Cells(4).Value
            'mFrm_DealSummary_auth.strLimitTo = grd_auth.CurrentRow.Cells(5).Value

        End If

        If rad_avm.Checked = True Then ' grd_auth.CurrentRow.Cells(0).Value <> "Signatory Matrix" Then 'rad_avm.Checked = True Then
            '  mFrm_DealSummary_auth.strLevelNumber = grd_auth.CurrentRow.Cells(6).Value
            '   mFrm_DealSummary_auth.strNoOfUser = grd_auth.CurrentRow.Cells(7).Value
        Else
            mFrm_DealSummary_auth.strLevelNumber = "0"
            mFrm_DealSummary_auth.strNoOfUser = "0"
        End If

        'txt_ID
        '  mFrm_DealSummary_auth.txt_ID.Text = grd_auth.CurrentRow.Cells("ID").Value

        If txt_revision_code.Text <> "" Then
            mFrm_DealSummary_auth.txt_revision_code.Text = txt_revision_code.Text
            mFrm_DealSummary_auth.txt_revision_desc.Text = txt_revision_desc.Text
            mFrm_DealSummary_auth.lbHead.Text += " - " & txt_revision_desc.Text
        End If

        mFrm_DealSummary_auth.ShowDialog()
        Call SetGrid_Auth()
    End Sub

    Private Sub btn_edit_auth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_auth.Click
        Call Edit_Auth()
    End Sub

    Private Sub Edit_Auth()
        If grd_auth.RowCount <= 0 Then Exit Sub
        If btn_edit_auth.Enabled = False Then Exit Sub

        If strMODE = "ADD" Then
            Call SaveMain()
        End If
        Dim mFrm_DealSummary_auth As New Frm_DealSummary_auth
        mFrm_DealSummary_auth.strMODE = "EDIT"
        mFrm_DealSummary_auth.txt_company_id.Text = txt_company_id.Text

        If rad_avm.Checked = True Then
            mFrm_DealSummary_auth.strAuthorizationParameter = grd_auth.CurrentRow.Cells(0).Value '"Authorization Matrix"
        Else
            mFrm_DealSummary_auth.strAuthorizationParameter = grd_auth.CurrentRow.Cells(0).Value '"Signatory Matrix"
        End If

        If grd_auth.RowCount <= 0 Then Exit Sub


        mFrm_DealSummary_auth.strProduct = grd_auth.CurrentRow.Cells(1).Value
        mFrm_DealSummary_auth.strAuthorizationType = grd_auth.CurrentRow.Cells(2).Value
        mFrm_DealSummary_auth.strAccount = grd_auth.CurrentRow.Cells(3).Value
        mFrm_DealSummary_auth.strLimitFrom = grd_auth.CurrentRow.Cells(4).Value
        mFrm_DealSummary_auth.strLimitTo = grd_auth.CurrentRow.Cells(5).Value

        If grd_auth.CurrentRow.Cells(0).Value <> "Signatory Matrix" Then 'rad_avm.Checked = True Then
            mFrm_DealSummary_auth.strLevelNumber = grd_auth.CurrentRow.Cells(6).Value
            mFrm_DealSummary_auth.strNoOfUser = grd_auth.CurrentRow.Cells(7).Value
        Else
            mFrm_DealSummary_auth.strLevelNumber = "0"
            mFrm_DealSummary_auth.strNoOfUser = "0"
        End If

        'txt_ID
        mFrm_DealSummary_auth.txt_ID.Text = grd_auth.CurrentRow.Cells("ID").Value

        'strSQL += vbCrLf & "  Product as [Product] " '--0
        'strSQL += vbCrLf & "  , AuthorizationType as [Authorization Type] " '1
        'strSQL += vbCrLf & "  , Account as [Account] " '2
        'strSQL += vbCrLf & "  , LimitFrom as [Limit From] " '3
        'strSQL += vbCrLf & "  , LimitTo as [Limit To] " '4
        'If rad_avm.Checked = True Then
        '    strSQL += vbCrLf & "  , LevelNumber as [Level] " '5
        '    strSQL += vbCrLf & "  , NoOfUser as [No. of User] " '6
        'End If
        'strSQL += vbCrLf & "  , SignatoryMatrix as [User] " '7


        If txt_revision_code.Text <> "" Then
            mFrm_DealSummary_auth.txt_revision_code.Text = txt_revision_code.Text
            mFrm_DealSummary_auth.txt_revision_desc.Text = txt_revision_desc.Text
            mFrm_DealSummary_auth.lbHead.Text += " - " & txt_revision_desc.Text
        End If

        If bIsViewOnly = True Then
            mFrm_DealSummary_auth.BT_Update.Enabled = False
        End If

        mFrm_DealSummary_auth.ShowDialog()
        Call SetGrid_Auth()
    End Sub

    Private Sub btn_delete_auth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete_auth.Click
        Try
            If grd_auth.RowCount = 0 Then Exit Sub
            If grd_auth.CurrentRow.Cells(0).Value = "" Then Exit Sub

            If MsgBox("Do you want to delete?", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
                Dim strSQL As String = ""
                ' strSQL = "delete from [TB_DEAL_UMM_USER] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and user_id ='" + grd_user.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") + "' "

                strSQL = ""
                strSQL += " delete FROM [TB_DEAL_AUTH] "
                strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
                strSQL += "  and ID= " + grd_auth.CurrentRow.Cells("ID").Value.ToString.Replace(",", "") + " "

                'strSQL += "  and LimitFrom= " + grd_auth.CurrentRow.Cells(3).Value.ToString.Replace(",", "") + " "
                'strSQL += "  and LimitTo= " + grd_auth.CurrentRow.Cells(4).Value.ToString.Replace(",", "") + " "

                'If rad_avm.Checked = True Then
                '    strSQL += "  and AuthorizationParameter= '" + "Authorization Matrix" + "' "
                'Else
                '    strSQL += "  and AuthorizationParameter= '" + "Signatory Matrix" + "' "
                'End If
                'strSQL += "  and AuthorizationType= '" + grd_auth.CurrentRow.Cells(1).Value.ToString.Replace("'", "''") + "' "
                'strSQL += "  and Product= '" + grd_auth.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") + "' "
                'strSQL += "  and Account= '" + grd_auth.CurrentRow.Cells(2).Value.ToString.Replace("'", "''") + "' "
                '' strSQL += "  and LevelNumber= " + grd_auth.CurrentRow.Cells(5).Value.ToString.Replace(",", "") + " "

                'If rad_avm.Checked = True Then
                '    strSQL += "  and LevelNumber= " + grd_auth.CurrentRow.Cells(5).Value.ToString.Replace(",", "") + " "
                'Else
                '    strSQL += "  and LevelNumber= 0 "
                'End If

                'strSQL += vbCrLf & "  Product as [Product] " '--0
                'strSQL += vbCrLf & "  , AuthorizationType as [Authorization Type] " '1
                'strSQL += vbCrLf & "  , Account as [Account] " '2
                'strSQL += vbCrLf & "  , LimitFrom as [Limit From] " '3
                'strSQL += vbCrLf & "  , LimitTo as [Limit To] " '4
                'If rad_avm.Checked = True Then
                '    strSQL += vbCrLf & "  , LevelNumber as [Level] " '5
                '    strSQL += vbCrLf & "  , NoOfUser as [No. of User] " '6
                'End If
                'strSQL += vbCrLf & "  , SignatoryMatrix as [User] " '7


                conn.ExecuteNonQuery(strSQL)
                Call SetGrid_Auth()
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

#End Region

#Region "Fee Charging"

    Private Sub SetGrid_Fee()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""
            strCrit = ""


            If txt_company_id.Text <> "" Then
                'strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " gl_account in ( select account_number from dbo.TB_DEAL_ACCOUNT where company_id=  '" & txt_company_id.Text & "'  )"
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & "  company_id=  '" & txt_company_id.Text & "'  "
            Else
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " 1=0"
            End If

         
            strSQL = ""
            strSQL += vbCrLf & "  SELECT "
            strSQL += vbCrLf & "        product_id as [Product ID]"
            strSQL += vbCrLf & "        ,seq as [Seq]"
            strSQL += vbCrLf & "        ,product_description as [Product Description]"
            ' strSQL += vbCrLf & "        ,[GL Branch]"
            strSQL += vbCrLf & "        ,gl_account as [GL Account]"
            ' strSQL += vbCrLf & "        ,[KBank Product Code]"
            strSQL += vbCrLf & "        ,charge_amt as [Charge Amt]"
            strSQL += vbCrLf & "        ,charge_frequency as [Charge Frequency]"
            strSQL += vbCrLf & "        ,charge_type as [Charge Type]"
            strSQL += vbCrLf & "        ,deduct_condition as [Deduct Condition]"
            strSQL += vbCrLf & "        ,working_day_condition_date as [Working Day]"
            ' strSQL += vbCrLf & "        ,[Working Day Condition]"
            strSQL += vbCrLf & "    FROM [dbo].[TB_FEE_CHARGING]"
            strSQL += vbCrLf & strCrit

            strSQL += vbCrLf & "  order by [Product ID]"

            Call conn.SetGrid(strSQL, grd_fee)
            If grd_fee.RowCount > 0 Then
                grd_fee.Columns("User").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                grd_fee.Rows.Item(0).Selected = True
         
            End If


        Catch ex As Exception
            '  MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_new_fee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_fee.Click
        Dim mFrm_DealSummary_FeeCharging_Edit As New Frm_DealSummary_FeeCharging_Edit
        mFrm_DealSummary_FeeCharging_Edit.strID = ""
        mFrm_DealSummary_FeeCharging_Edit.strMODE = "ADD"
        mFrm_DealSummary_FeeCharging_Edit.btnFindCust.Visible = False
        mFrm_DealSummary_FeeCharging_Edit.txt_company_id.Text = txt_company_id.Text
        mFrm_DealSummary_FeeCharging_Edit.ShowDialog()
        Call SetGrid_Fee()
    End Sub

    Private Sub btn_edit_fee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_fee.Click
        Dim mFrm_DealSummary_FeeCharging_Edit As New Frm_DealSummary_FeeCharging_Edit
        mFrm_DealSummary_FeeCharging_Edit.strID = grd_fee.CurrentRow.Cells(0).Value
        mFrm_DealSummary_FeeCharging_Edit.txt_Product_ID.Text = grd_fee.CurrentRow.Cells(0).Value
        mFrm_DealSummary_FeeCharging_Edit.txt_seq.Text = grd_fee.CurrentRow.Cells(1).Value
        mFrm_DealSummary_FeeCharging_Edit.strMODE = "EDIT"
        mFrm_DealSummary_FeeCharging_Edit.btnFindCust.Visible = False
        mFrm_DealSummary_FeeCharging_Edit.txt_company_id.Text = txt_company_id.Text
        If bIsViewOnly = True Then
            mFrm_DealSummary_FeeCharging_Edit.BT_Update.Enabled = False
        End If

        mFrm_DealSummary_FeeCharging_Edit.ShowDialog()
        Call SetGrid_Fee()
    End Sub


    Private Sub btn_delete_fee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete_fee.Click
        If grd_fee.RowCount <= 0 Then Exit Sub

        If grd_fee.CurrentRow.Cells(0).Value <> "" Then

            If MsgBox("Do you want to delete.", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
                Dim strSQL As String = "delete from [TB_FEE_CHARGING] where product_id='" & grd_fee.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") & "' and seq=" & grd_fee.CurrentRow.Cells(1).Value.ToString.Replace("'", "''")
                conn.ExecuteNonQuery(strSQL)
                Call SetGrid_Fee()
            End If


        End If
    End Sub

#End Region

#Region "RMS"

    Private Sub SetGrid_RMS()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""
            strCrit = ""


            If txt_company_id.Text <> "" Then
                'strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " gl_account in ( select account_number from dbo.TB_DEAL_ACCOUNT where company_id=  '" & txt_company_id.Text & "'  )"
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & "  company_id=  '" & txt_company_id.Text & "'  "
            Else
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " 1=0"
            End If


            strSQL = ""
            strSQL += vbCrLf & "  SELECT "
            strSQL += vbCrLf & "        seq as [Seq]"
            strSQL += vbCrLf & "        ,product_name as [Product Name]"
            strSQL += vbCrLf & "        ,account_no as [Account Number]"
            strSQL += vbCrLf & "        ,enable as [Enable]"
            strSQL += vbCrLf & "        ,encryption as [Encryption]"
            strSQL += vbCrLf & "        ,delivery_channel as [Delivery Channel]"
            strSQL += vbCrLf & "        ,delivery_method as [Delivery Method]"
            strSQL += vbCrLf & "        ,organizer_name as [Organizer Name]"
            strSQL += vbCrLf & "        ,every_hour as [Every Hour]"

            strSQL += vbCrLf & "    FROM [dbo].[TB_RMS_H]"
            strSQL += vbCrLf & strCrit

            strSQL += vbCrLf & "  order by [seq]"

            Call conn.SetGrid(strSQL, grd_rms)
            If grd_rms.RowCount > 0 Then
                'grd_rms.Columns("User").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                grd_rms.Rows.Item(0).Selected = True

            End If


        Catch ex As Exception
            '  MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_new_rms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_rms.Click
        Dim mFrm_RMS_Edit As New Frm_RMS_Edit
        mFrm_RMS_Edit.strID = ""
        mFrm_RMS_Edit.strMODE = "ADD"
        mFrm_RMS_Edit.txt_organizer_name.Text = txt_client_code.Text
        ' mFrm_RMS_Edit.btnFindCust.Visible = False
        mFrm_RMS_Edit.txt_revision_code.Text = txt_revision_code.Text
        mFrm_RMS_Edit.txt_revision_desc.Text = txt_revision_desc.Text

        mFrm_RMS_Edit.txt_company_id.Text = txt_company_id.Text
        mFrm_RMS_Edit.ShowDialog()
        Call SetGrid_RMS()
    End Sub


    Private Sub btn_edit_rms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit_rms.Click

        If grd_rms.RowCount = 0 Then Exit Sub

        Dim mFrm_RMS_Edit As New Frm_RMS_Edit
        mFrm_RMS_Edit.strID = grd_rms.CurrentRow.Cells(0).Value
        'mFrm_RMS_Edit.txt_Product_ID.Text = grd_fee.CurrentRow.Cells(0).Value
        mFrm_RMS_Edit.txt_seq.Text = grd_rms.CurrentRow.Cells(0).Value
        'PERSONAL AND HOUSEHOLD SERVICES
        ' mFrm_RMS_Edit.txt_organizer_name.Text = txt_client_code.Text
        mFrm_RMS_Edit.strMODE = "EDIT"
        'mFrm_RMS_Edit.btnFindCust.Visible = False
        mFrm_RMS_Edit.txt_company_id.Text = txt_company_id.Text
        mFrm_RMS_Edit.txt_seq.Text = grd_rms.CurrentRow.Cells(0).Value

        mFrm_RMS_Edit.txt_revision_code.Text = txt_revision_code.Text
        mFrm_RMS_Edit.txt_revision_desc.Text = txt_revision_desc.Text

        If bIsViewOnly = True Then
            mFrm_RMS_Edit.BT_Update.Enabled = False
        End If


        mFrm_RMS_Edit.ShowDialog()
        Call SetGrid_RMS()
    End Sub

    Private Sub btn_delete_rms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete_rms.Click
        If grd_rms.RowCount <= 0 Then Exit Sub

        '  If grd_rms.CurrentRow.Cells(0).Value <> "" Then

        If MsgBox("Do you want to delete.", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
            Dim strSQL As String = ""

            strSQL += vbCrLf & "delete from [TB_RMS_D] where company_id='" & txt_company_id.Text & "' and seq=" & grd_rms.CurrentRow.Cells(0).Value
            strSQL += vbCrLf & "delete from [TB_RMS_H] where company_id='" & txt_company_id.Text & "'  and seq=" & grd_rms.CurrentRow.Cells(0).Value

            conn.ExecuteNonQuery(strSQL)
            Call SetGrid_RMS()
        End If


        ' End If
    End Sub


#End Region

    Private Sub btn_search_company_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search_company.Click
        Call SearchData()

    End Sub

    Private Sub SearchData()
        Dim mFrm_DealSummary_List As New Frm_DealSummary_List
        mFrm_DealSummary_List.txtRef = txt_company_id
        mFrm_DealSummary_List.Is_parent = False
        mFrm_DealSummary_List.ShowDialog()

        If txt_company_id.Text <> "" Then
            strMODE = "EDIT"

            Call ShowData_DEAL_UMM_COMPANY()
            Call SetGrid_Account()
            Call SetGrid_Product()
            Call SetGrid_Users()
            Call SetGrid_Category()
            Call SetGrid_Auth()
            Call SetGrid_Interface()
            '-- 
            Call SetGrid_Fee()
            Call SetGrid_RMS()

            If rad_revision.Checked = False Then
                btn_print.Enabled = True
            End If

            'disabled controls mode=edit
            rad_new.Enabled = False
            rad_revision.Enabled = False
            txt_company_id.Enabled = False
            ' txt_client_code.Enabled = False
        Else

            'MessageBox.Show("Company is not found !!", "Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If
    End Sub


    Private Sub btn_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print.Click
        ' Try
        Dim str_cn As String = ""
        Dim str_cn_ole As String = ""
        Dim mCls_Configuration As New Cls_Configuration
        str_cn = mCls_Configuration.ConnectionString



        Dim strFile As String = Application.StartupPath & "\report\APPLICATION_FORM.doc"
        Dim strFile_param As String = Application.StartupPath & "\report\File_param.dat"
        ' Dim strFile_cfg As String = Application.StartupPath & "\report\Default.ini"
        Dim strPath As String = Application.StartupPath & "\report\"
        '\Report\output-files\THAILAND02'

        ' mCls_Configuration.INIWrite(strFile_cfg, "Options", "AutosaveDirectory", strPath & "output-files\" & txt_company_id.Text & "\")


        Dim strServer As String = ""
        Dim strDatabase As String = ""
        Dim strUser As String = ""
        Dim strPwd As String = ""


        Dim csb = New SqlConnectionStringBuilder(str_cn)



        strServer = csb.DataSource
        strDatabase = csb.InitialCatalog
        strUser = csb.UserID
        strPwd = csb.Password

        str_cn_ole = "Provider=SQLOLEDB.1;Password=" & strPwd & ";Persist Security Info=True;User ID=" & strUser & ";Initial Catalog=" & strDatabase & ";Data Source=" & strServer & ""

        'Call GenPDF(strFile, str_cn_ole, strPath)
        csb.Clear()
        Dim strParama As String = str_cn_ole & "||" & strPath & "||" & txt_company_id.Text
        'Clipboard.Clear()
        'Clipboard.SetData(strParama, TextDataFormat.Text)

        Dim FILE_NAME As String = strFile_param 'Application.StartupPath & "\err" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".txt"

        ' If System.IO.File.Exists(FILE_NAME) = True Then

        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

        objWriter.Write(strParama)
        objWriter.Flush()
        objWriter.Close()

        Shell("cmd /k """ & strFile & """", AppWinStyle.NormalFocus)

        Exit Sub


        ' Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        ' End Try
    End Sub

    Private Sub GenPDF(ByVal strFile As String, ByVal str_cn As String, ByVal strPath As String)
        ' Try
        Dim oWord As New Microsoft.Office.Interop.Word.Application  'Word.ApplicationClass
        'Start Word and open the document.
        ' oWord = CreateObject("Word.Application")
        oWord.Application.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone
        'oWord.Application.
        oWord.Visible = True
        oWord.Documents.Open(strFile)

        'Run the macros.
        'oWord.Run("DoKbTest")
        oWord.Activate()
        oWord.Run("OpenForm", str_cn, strPath, txt_company_id.Text, True)

        'Quit Word.
        'oWord.Quit()
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord)
        oWord = Nothing
        '  Catch ex As Exception
        'MessageBox.Show(ex.ToString)
        ' End Try
    End Sub

    Private Sub btn_GenerateGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GenerateGroup.Click
        'txt_company_id.Text 
        Try

            Dim strSQL As String = ""
            If rad_set_as_parent_company_y.Checked = True Then
                strSQL = " EXEC [sp_deal_category_generate] '" & txt_company_id.Text.Replace("'", "''") & "' "
            Else
                strSQL = " EXEC [sp_deal_category_generate] '" & txt_company_id_parent.Text.Replace("'", "''") & "' "
            End If

            conn.ExecuteNonQuery(strSQL)

            MsgBox("Update was sucessful.")

            Call SetGrid_Category()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_ViewGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ViewGroup.Click
        If grd_category.RowCount = 0 Then Exit Sub
        If grd_category.CurrentRow.Cells(0).Value = "" Then Exit Sub

        Dim mFrm_DealSummary_Category As New Frm_DealSummary_Category
        mFrm_DealSummary_Category.strMODE = "EDIT"
        'txt_company_id
        If rad_set_as_parent_company_y.Checked = True Then
            mFrm_DealSummary_Category.txt_company_id.Text = txt_company_id.Text
        Else
            mFrm_DealSummary_Category.txt_company_id.Text = txt_company_id_parent.Text
        End If

        mFrm_DealSummary_Category.txt_client_code.Text = txt_client_code.Text
        mFrm_DealSummary_Category.txt_User_Category_ID.Text = grd_category.CurrentRow.Cells(1).Value
        mFrm_DealSummary_Category.txt_User_Category_Name.Text = grd_category.CurrentRow.Cells(3).Value

        mFrm_DealSummary_Category.txt_Report_Category_ID.Text = grd_category.CurrentRow.Cells(2).Value
        mFrm_DealSummary_Category.txt_Report_Category_Name.Text = grd_category.CurrentRow.Cells(4).Value

        mFrm_DealSummary_Category.txt_seq.Text = grd_category.CurrentRow.Cells("seq").Value

        'strSQL += vbCrLf & " a.[company_id]  as [Company ID] " 1
        'strSQL += vbCrLf & " ,a.User_Category_ID  as [User Category ID]" 2
        'strSQL += vbCrLf & " ,a.Report_Category_ID  as [Report Category ID]" 3
        'strSQL += vbCrLf & " ,a.User_Category_Name as [User Category Name]" 4
        'strSQL += vbCrLf & " ,a.Report_Category_Name as [Report Category Name]" 5
        'strSQL += vbCrLf & " ,a.seq as [seq]" 6

        mFrm_DealSummary_Category.chk_deal_cover_admin.Checked = chk_deal_cover_admin.Checked
        mFrm_DealSummary_Category.chk_deal_cover_inquiry.Checked = chk_deal_cover_inquiry.Checked
        mFrm_DealSummary_Category.chk_deal_cover_payment.Checked = chk_deal_cover_payment.Checked

        If bIsViewOnly = True Then
            mFrm_DealSummary_Category.btn_ClearPrintFlag.Enabled = False
            mFrm_DealSummary_Category.bIsViewOnly = True
        End If

        mFrm_DealSummary_Category.ShowDialog()
        ' Call SetGrid_Users()
        Call SetGrid_Category()
    End Sub

    Private Sub Tab_Category_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab_Category.Click
        Call SetGrid_Category()
    End Sub

    Private Sub txt_client_code_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_client_code.Validated
        txt_client_code.Text = txt_client_code.Text.ToUpper
    End Sub

    Private Sub btn_CopyCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CopyCategory.Click
        Try
            If grd_category.RowCount = 0 Then Exit Sub
            If grd_category.CurrentRow.Cells(0).Value = "" Then Exit Sub

            Dim strSeq As Double = 0
            strSeq = grd_category.CurrentRow.Cells(5).Value
            If MsgBox("Do you want to copy data [" & grd_category.CurrentRow.Cells(2).Value & "]", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim strSQL As String = ""
            If rad_set_as_parent_company_y.Checked = True Then
                strSQL = " EXEC [sp_deal_category_copy] '" & txt_company_id.Text.Replace("'", "''") & "', " & strSeq.ToString
            Else
                strSQL = " EXEC [sp_deal_category_copy] '" & txt_company_id_parent.Text.Replace("'", "''") & "', " & strSeq.ToString
            End If

            conn.ExecuteNonQuery(strSQL)

            MsgBox("Update was successful.")

            Call SetGrid_Category()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub cbo_registered_region_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_registered_region.Validated
        If chk_use_registered_address.Checked = True Then
            cbo_mailing_region.Text = cbo_registered_region.Text
        End If
    End Sub

    Private Sub chk_deal_cover_admin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_deal_cover_admin.CheckedChanged
        'If txt_revision_code.Text <> "" Then Exit Sub
        Call SaveData_Service()
    End Sub

    Private Sub chk_deal_cover_payment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_deal_cover_payment.CheckedChanged
        'If txt_revision_code.Text <> "" Then Exit Sub
        ''If chk_deal_cover_payment.Checked = True Then
        ''    chk_deal_cover_admin.Enabled = True
        ''Else
        ''    chk_deal_cover_admin.Enabled = False
        ''    chk_deal_cover_admin.Checked = False
        ''End If

        Call SaveData_Service()

    End Sub


    Private Sub rad_svm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_svm.CheckedChanged
        Call SetGrid_Auth()
    End Sub

    Private Sub rad_avm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_avm.CheckedChanged
        Call SetGrid_Auth()
    End Sub


    Private Sub btn_print_sum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print_sum.Click
        Dim str_cn As String = ""
        Dim str_cn_ole As String = ""
        Dim mCls_Configuration As New Cls_Configuration
        str_cn = mCls_Configuration.ConnectionString



        Dim strFile As String = Application.StartupPath & "\report\APPLICATION_FORM.doc"
        Dim strFile_param As String = Application.StartupPath & "\report\File_param.dat"
        ' Dim strFile_cfg As String = Application.StartupPath & "\report\Default.ini"
        Dim strPath As String = Application.StartupPath & "\report\"
        '\Report\output-files\THAILAND02'

        ' mCls_Configuration.INIWrite(strFile_cfg, "Options", "AutosaveDirectory", strPath & "output-files\" & txt_company_id.Text & "\")


        Dim strServer As String = ""
        Dim strDatabase As String = ""
        Dim strUser As String = ""
        Dim strPwd As String = ""


        Dim csb = New SqlConnectionStringBuilder(str_cn)



        strServer = csb.DataSource
        strDatabase = csb.InitialCatalog
        strUser = csb.UserID
        strPwd = csb.Password

        str_cn_ole = "Provider=SQLOLEDB.1;Password=" & strPwd & ";Persist Security Info=True;User ID=" & strUser & ";Initial Catalog=" & strDatabase & ";Data Source=" & strServer & ""

        'Call GenPDF(strFile, str_cn_ole, strPath)
        csb.Clear()
        Dim strParama As String = str_cn_ole & "||" & strPath & "||" & txt_company_id.Text & "||summary||" & txt_userid.Text
        'Clipboard.Clear()
        'Clipboard.SetData(strParama, TextDataFormat.Text)

        Dim FILE_NAME As String = strFile_param 'Application.StartupPath & "\err" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".txt"

        ' If System.IO.File.Exists(FILE_NAME) = True Then

        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

        objWriter.Write(strParama)
        objWriter.Flush()
        objWriter.Close()

        Shell("cmd /k """ & strFile & """", AppWinStyle.NormalFocus)

        Exit Sub
    End Sub

    Private Sub cbo_registered_province_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_registered_province.Validated
        If chk_use_registered_address.Checked = True Then
            cbo_mailing_province.Text = cbo_registered_province.Text
        End If
    End Sub


    Private Sub cbo_registered_country_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_registered_country.Validated
        If chk_use_registered_address.Checked = True Then
            cbo_mailing_country.Text = cbo_registered_country.Text
        End If
    End Sub

    Private Sub chk_login_flag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_login_flag.CheckedChanged
        If chk_login_flag.Checked = True Then

            chk_login_non.Enabled = True
            chk_login_hw.Enabled = True
            chk_login_sms.Enabled = True

            chk_login_hw.Checked = True
            ' chk_login_sms.Checked = True

        Else
            chk_login_non.Enabled = False
            chk_login_hw.Enabled = False
            chk_login_sms.Enabled = False

            chk_login_non.Checked = False
            chk_login_hw.Checked = False
            chk_login_sms.Checked = False
        End If

    End Sub

    Private Sub chk_login_sms_flag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_login_sms_flag.CheckedChanged
        If chk_login_sms_flag.Checked = True Then
            chk_login_sms_non.Enabled = True
            chk_login_sms_sms.Enabled = True
            chk_login_sms_sms.Checked = True
        Else
            chk_login_sms_non.Enabled = False
            chk_login_sms_sms.Enabled = False

            chk_login_sms_non.Checked = False
            chk_login_sms_sms.Checked = False

        End If
    End Sub


    Private Sub chk_login_token_flag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_login_token_flag.CheckedChanged
        If chk_login_token_flag.Checked = True Then
            chk_login_token_non.Enabled = True
            chk_login_token_hw.Enabled = True
            chk_login_token_hw.Checked = True

        Else
            chk_login_token_non.Enabled = False
            chk_login_token_hw.Enabled = False

            chk_login_token_non.Checked = False
            chk_login_token_hw.Checked = False

        End If

    End Sub

    Private Sub chk_deal_cover_payment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_deal_cover_payment.Click

        Call EnableButtonPayment()

    End Sub


    Private Sub EnableButtonPayment()

        If chk_deal_cover_payment.Checked = True Then
            btn_new_product.Enabled = True
            btn_edit_product.Enabled = True
            btn_delete_product.Enabled = True

            btn_new_auth.Enabled = True
            btn_edit_auth.Enabled = True
            btn_delete_auth.Enabled = True
        Else
            btn_new_product.Enabled = False
            btn_edit_product.Enabled = False
            btn_delete_product.Enabled = False

            btn_new_auth.Enabled = False
            btn_edit_auth.Enabled = False
            btn_delete_auth.Enabled = False

        End If

    End Sub


    Private Sub btn_print_dm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print_dm.Click
        ' Try
        Dim str_cn As String = ""
        Dim str_cn_ole As String = ""
        Dim mCls_Configuration As New Cls_Configuration
        str_cn = mCls_Configuration.ConnectionString



        Dim strFile As String = Application.StartupPath & "\report\APPLICATION_FORM.doc"
        Dim strFile_param As String = Application.StartupPath & "\report\File_param.dat"
        ' Dim strFile_cfg As String = Application.StartupPath & "\report\Default.ini"
        Dim strPath As String = Application.StartupPath & "\report\"
        '\Report\output-files\THAILAND02'

        ' mCls_Configuration.INIWrite(strFile_cfg, "Options", "AutosaveDirectory", strPath & "output-files\" & txt_company_id.Text & "\")


        Dim strServer As String = ""
        Dim strDatabase As String = ""
        Dim strUser As String = ""
        Dim strPwd As String = ""


        Dim csb = New SqlConnectionStringBuilder(str_cn)



        strServer = csb.DataSource
        strDatabase = csb.InitialCatalog
        strUser = csb.UserID
        strPwd = csb.Password

        str_cn_ole = "Provider=SQLOLEDB.1;Password=" & strPwd & ";Persist Security Info=True;User ID=" & strUser & ";Initial Catalog=" & strDatabase & ";Data Source=" & strServer & ""

        'Call GenPDF(strFile, str_cn_ole, strPath)
        csb.Clear()
        Dim strParama As String = str_cn_ole & "||" & strPath & "||" & txt_company_id.Text & "||dm||generatefile"
        'Clipboard.Clear()
        'Clipboard.SetData(strParama, TextDataFormat.Text)

        Dim FILE_NAME As String = strFile_param 'Application.StartupPath & "\err" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".txt"

        ' If System.IO.File.Exists(FILE_NAME) = True Then

        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

        objWriter.Write(strParama)
        objWriter.Flush()
        objWriter.Close()

        Shell("cmd /k """ & strFile & """", AppWinStyle.NormalFocus)

        Exit Sub

    End Sub


    Private Sub btnUploadAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadAddress.Click
        LbError.Text = ""

        Dim strCode As String = ""
        Dim strCodeSub As String = ""
        Dim dblPos As Double = 0

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Title = "Open File Dialog"
        OpenFileDialog1.InitialDirectory = Application.StartupPath


        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName <> "" Then

            txt_registered_no.Text = ""
            txt_registered_building.Text = ""
            txt_registered_soi.Text = ""
            txt_registered_sub_district.Text = ""
            cbo_registered_province.Text = ""
            txt_registered_postal_code.Text = ""
            cbo_registered_country.Text = ""
            txt_registered_moo.Text = ""
            txt_registered_floor.Text = ""
            txt_registered_street.Text = ""
            txt_registered_district.Text = ""
            cbo_registered_region.Text = ""


            Dim FILE_NAME As String = OpenFileDialog1.FileName

            If System.IO.File.Exists(FILE_NAME) = True Then

                Dim objReader As New System.IO.StreamReader(FILE_NAME, System.Text.Encoding.Default)
                strCode = objReader.ReadToEnd
                txt_code.Text = strCode

                objReader.Close()

                '===============================
                '>เลขที่ <
                dblPos = InStr(strCode, ">เลขที่ <", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'เลขที่ ' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)
                'skip </TD> 2 times
                dblPos = InStr(strCode, "</TD>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "</TD>".Length)
                dblPos = InStr(strCode, "</TD>", CompareMethod.Text)
                strCodeSub = strCode.Substring(0, dblPos)
                strCode = strCode.Substring(dblPos + "</TD>".Length)

                'cut no
                dblPos = InStr(strCodeSub, ">", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(dblPos)
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))
                txt_registered_no.Text = strCodeSub
                '===============================
                '>อาคาร 
                dblPos = InStr(strCode, ">อาคาร", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'อาคาร ' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)
                'find colSpan=2>
                dblPos = InStr(strCode, "colSpan=2>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "colSpan=2>".Length - 1)
                'cut no
                strCodeSub = strCode
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))
                txt_registered_building.Text = strCodeSub
                '===============================
                '>ชั้น
                dblPos = InStr(strCode, ">ชั้น", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'ชั้น' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)

                'find colSpan=2>
                dblPos = InStr(strCode, "class=text8>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "class=text8>".Length - 1)
                'cut no
                strCodeSub = strCode
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))

                txt_registered_floor.Text = strCodeSub

                '===============================
                '>ชั้น
                dblPos = InStr(strCode, ">ห้อง", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'ห้อง' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)

                'find colSpan=2>
                dblPos = InStr(strCode, "colSpan=2>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "colSpan=2>".Length - 1)
                'cut no
                strCodeSub = strCode
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))
                If strCodeSub <> "" Then
                    txt_registered_building.Text = txt_registered_building.Text & IIf(txt_registered_building.Text = "", "", " ห้อง ") & strCodeSub
                End If

                '======================
                '>หมู่ที่ 

                dblPos = InStr(strCode, ">หมู่ที่", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'หมู่ที่' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)

                'find colSpan=2>
                dblPos = InStr(strCode, "class=text8>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "class=text8>".Length - 1)
                'cut no
                strCodeSub = strCode
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))

                txt_registered_moo.Text = strCodeSub

                '===============================
                '>หมู่บ้าน 
                dblPos = InStr(strCode, ">หมู่บ้าน", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'หมู่บ้าน' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)

                'find colSpan=2>
                dblPos = InStr(strCode, "colSpan=2>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "colSpan=2>".Length - 1)
                'cut no
                strCodeSub = strCode
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))
                If strCodeSub <> "" Then
                    txt_registered_building.Text = txt_registered_building.Text & IIf(txt_registered_building.Text = "", "", " - ") & strCodeSub
                End If

                '===============================
                '>หมู่บ้าน 
                dblPos = InStr(strCode, ">ซอย", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'ซอย' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)

                'find colSpan=2>
                dblPos = InStr(strCode, "colSpan=2>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "colSpan=2>".Length - 1)
                'cut no
                strCodeSub = strCode
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))

                txt_registered_soi.Text = strCodeSub
                '===============================
                '>หมู่บ้าน 
                dblPos = InStr(strCode, ">ถนน", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'ถนน' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)

                'find colSpan=2>
                dblPos = InStr(strCode, "colSpan=2>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "colSpan=2>".Length - 1)
                'cut no
                strCodeSub = strCode
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))

                txt_registered_street.Text = strCodeSub
                '===============================
                '>หมู่บ้าน 
                dblPos = InStr(strCode, ">ตำบล/แขวง", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'ตำบล/แขวง' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)

                'find colSpan=2>
                dblPos = InStr(strCode, "colSpan=2>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "colSpan=2>".Length - 1)
                'cut no
                strCodeSub = strCode
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))

                txt_registered_sub_district.Text = strCodeSub
                '===============================
                '>อำเภอ/เขต
                dblPos = InStr(strCode, ">อำเภอ/เขต", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'อำเภอ/เขต' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)

                'find colSpan=2>
                dblPos = InStr(strCode, "colSpan=2>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "colSpan=2>".Length - 1)
                'cut no
                strCodeSub = strCode
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))

                txt_registered_district.Text = strCodeSub

                '===============================
                '>อำเภอ/เขต
                dblPos = InStr(strCode, ">จังหวัด", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'จังหวัด' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)

                'find colSpan=2>
                dblPos = InStr(strCode, "colSpan=2>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "colSpan=2>".Length - 1)
                'cut no
                strCodeSub = strCode
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))


                If cbo_registered_country.FindString(strCodeSub) > 0 Then
                    cbo_registered_country.Text = cbo_registered_country.Items(cbo_registered_country.FindString(strCodeSub)).ToString
                Else
                    If InStr(strCodeSub, "กทม", CompareMethod.Text) > 0 Or InStr(strCodeSub, "กรุงเทพ", CompareMethod.Text) > 0 Then
                        cbo_registered_province.Text = "กรุงเทพมหานคร"

                    Else
                        If strCodeSub <> "" Then
                            LbError.Text += IIf(LbError.Text = "", "", vbCrLf) & "จังหวัด : " & strCodeSub & " ไม่พบ"
                        End If

                    End If
                End If

                '===============================
                '>รหัสไปรษณีย์ 
                dblPos = InStr(strCode, ">รหัสไปรษณีย์", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'รหัสไปรษณีย์' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)

                'find colSpan=2>
                dblPos = InStr(strCode, "colSpan=2>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "colSpan=2>".Length - 1)
                'cut no
                strCodeSub = strCode
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))

                txt_registered_postal_code.Text = strCodeSub

                '===============================
                '>รหัสไปรษณีย์ 
                dblPos = InStr(strCode, ">ประเทศ", CompareMethod.Text)
                If dblPos <= 0 Then
                    LbError.Text = "ไม่พบคำ 'ประเทศ' ใน File นี้"
                    Exit Sub
                End If
                strCode = strCode.Substring(dblPos)

                'find colSpan=2>
                dblPos = InStr(strCode, "colSpan=2>", CompareMethod.Text)
                strCode = strCode.Substring(dblPos + "colSpan=2>".Length - 1)
                'cut no
                strCodeSub = strCode
                dblPos = InStr(strCodeSub, "<", CompareMethod.Text)
                strCodeSub = strCodeSub.Substring(0, dblPos - 1)
                strCodeSub = LTrim(RTrim(strCodeSub))




                If cbo_registered_country.FindString(strCodeSub) > 0 Then
                    cbo_registered_country.Text = cbo_registered_country.Items(cbo_registered_country.FindString(strCodeSub)).ToString
                Else
                    If InStr(strCodeSub, "Thai", CompareMethod.Text) > 0 _
                    Or InStr(strCodeSub, "thai", CompareMethod.Text) > 0 _
                     Or InStr(strCodeSub, "TH", CompareMethod.Text) > 0 _
                     Or InStr(strCodeSub, "th", CompareMethod.Text) > 0 _
                     Or InStr(strCodeSub, "Th", CompareMethod.Text) > 0 _
                     Or InStr(strCodeSub, "ไทย", CompareMethod.Text) > 0 Then
                        cbo_registered_country.Text = "Thailand"
                    Else
                        If strCodeSub <> "" Then
                            LbError.Text += IIf(LbError.Text = "", "", vbCrLf) & "ประเทศ : " & strCodeSub & " ไม่พบ"
                        End If


                    End If
                End If

                LbError.Text += IIf(LbError.Text = "", "", vbCrLf) & " ดึงข้อมูลที่อยู่สำเร็จ"
                Call RefreshDuplicationAddress()
                'cbo_registered_region.Text = "Thailand"

            Else

                LbError.Text = ("File Does Not Exist")

            End If

        End If

        If LbError.Text <> "" Then
            LbError.Visible = True
        End If
    End Sub


    Private Sub btn_Correction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Correction.Click
        Dim str_cn As String = ""
        Dim str_cn_ole As String = ""
        Dim mCls_Configuration As New Cls_Configuration
        str_cn = mCls_Configuration.ConnectionString



        Dim strFile As String = Application.StartupPath & "\report\APPLICATION_FORM.doc"
        Dim strFile_param As String = Application.StartupPath & "\report\File_param.dat"
        ' Dim strFile_cfg As String = Application.StartupPath & "\report\Default.ini"
        Dim strPath As String = Application.StartupPath & "\report\"
        '\Report\output-files\THAILAND02'

        ' mCls_Configuration.INIWrite(strFile_cfg, "Options", "AutosaveDirectory", strPath & "output-files\" & txt_company_id.Text & "\")


        Dim strServer As String = ""
        Dim strDatabase As String = ""
        Dim strUser As String = ""
        Dim strPwd As String = ""


        Dim csb = New SqlConnectionStringBuilder(str_cn)



        strServer = csb.DataSource
        strDatabase = csb.InitialCatalog
        strUser = csb.UserID
        strPwd = csb.Password

        str_cn_ole = "Provider=SQLOLEDB.1;Password=" & strPwd & ";Persist Security Info=True;User ID=" & strUser & ";Initial Catalog=" & strDatabase & ";Data Source=" & strServer & ""

        'Call GenPDF(strFile, str_cn_ole, strPath)
        csb.Clear()
        Dim strParama As String = str_cn_ole & "||" & strPath & "||" & txt_company_id.Text & "||correction||generatefile"
        'Clipboard.Clear()
        'Clipboard.SetData(strParama, TextDataFormat.Text)

        Dim FILE_NAME As String = strFile_param 'Application.StartupPath & "\err" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".txt"

        ' If System.IO.File.Exists(FILE_NAME) = True Then

        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

        objWriter.Write(strParama)
        objWriter.Flush()
        objWriter.Close()

        Shell("cmd /k """ & strFile & """", AppWinStyle.NormalFocus)

        Exit Sub
    End Sub



    Private Sub cbo_status_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_status.SelectedIndexChanged
        If cbo_status.Text = "Generate File" Or cbo_status.Text = "Ensured File" Then
            chk_Generate.Checked = True
        Else
            chk_Generate.Checked = False
        End If
    End Sub

    Private Sub Frm_DealSummary_main_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If strMODE.ToUpper = "EDIT" Then

            Dim strAuth As String = ""
            Dim strSQL As String = ""

            strSQL = " select  distinct a.AuthorizationParameter   from TB_DEAL_AUTH  a where a.company_id='" & txt_company_id.Text & "' "
            strAuth = conn.GetDataFromSQL(strSQL)
            If strAuth = "Signatory Matrix" Then
                rad_svm.Checked = True
            Else
                rad_avm.Checked = True
            End If

            Call SetGrid_Auth()
        End If
    End Sub

    Private Sub btnCorpname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AutoGenerate_CommpanyID()
    End Sub

    Private Sub btnRev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRev.Click
        Dim strFile As String = Application.StartupPath & "\report\APPLICATION_FORM.doc"
        Dim strFile_param As String = Application.StartupPath & "\report\File_param.dat"
        Dim strPath As String = Application.StartupPath & "\report\"
        Dim str_cn As String
        Dim str_cn_ole As String
        Dim mCls_Configuration As New Cls_Configuration

        Dim strServer As String
        Dim strDatabase As String
        Dim strUser As String
        Dim strPwd As String
        Dim strValue As String

        Dim strRevDate As String = Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)

        Try

            strValue = strRevDate & ";" & txt_revision_code.Text & ";" & txt_revision_desc.Text

            str_cn = mCls_Configuration.ConnectionString
            Dim csb = New SqlConnectionStringBuilder(str_cn)

            strServer = csb.DataSource
            strDatabase = csb.InitialCatalog
            strUser = csb.UserID
            strPwd = csb.Password

            str_cn_ole = "Provider=SQLOLEDB.1;Password=" & strPwd & ";Persist Security Info=True;User ID=" & strUser & ";Initial Catalog=" & strDatabase & ";Data Source=" & strServer & ""

            'Call GenPDF(strFile, str_cn_ole, strPath)
            csb.Clear()
            Dim strParama As String = str_cn_ole & "||" & strPath & "||" & txt_company_id.Text & "||" & strValue
            'Clipboard.Clear()
            'Clipboard.SetData(strParama, TextDataFormat.Text)

            Dim FILE_NAME As String = strFile_param 'Application.StartupPath & "\err" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".txt"

            ' If System.IO.File.Exists(FILE_NAME) = True Then

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

            objWriter.Write(strParama)
            objWriter.Flush()
            objWriter.Close()

            Shell("cmd /k """ & strFile & """", AppWinStyle.NormalFocus)

            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Cannot generate form !!")
        End Try

    End Sub

End Class

''-- comment by tum; 16-May-2014
'Private Sub chk_deal_cover_inquiry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_deal_cover_inquiry.CheckedChanged
'    If txt_revision_code.Text <> "" Then Exit Sub
'    Call SaveData_Service()

'    If chk_deal_cover_inquiry.Checked = True Then
'        chk_deal_cover_payment.Enabled = True

'    Else
'        chk_deal_cover_payment.Enabled = False
'        chk_deal_cover_admin.Enabled = False

'        chk_deal_cover_payment.Checked = False
'        chk_deal_cover_admin.Checked = False
'    End If

'End Sub

'Private Sub DisableALL()
'    Dim ctrl As Control
'    For Each ctrl In Me.Controls
'        'If TypeOf ctrl Is CommandButton Then
'        ctrl.Enabled = False
'        ' End If
'    Next

'End Sub

'Sub ClearAllControls(ByRef container As Object, Optional ByVal Recurse As Boolean = True _
'       , Optional ByVal IsEnable As Boolean = False)
'    'Clear all of the controls within the container object
'    'If "Recurse" is true, then also clear controls within any sub-containers
'    Dim ctrl As Control
'    For Each ctrl In container.Controls
'        If (ctrl.GetType() Is GetType(TextBox)) Then
'            Dim txt As TextBox = CType(ctrl, TextBox)
'            'txt.Text = ""
'            txt.Enabled = IsEnable
'        End If
'        If (ctrl.GetType() Is GetType(CheckBox)) Then
'            Dim chkbx As CheckBox = CType(ctrl, CheckBox)
'            chkbx.Enabled = IsEnable
'        End If
'        If (ctrl.GetType() Is GetType(ComboBox)) Then
'            Dim cbobx As ComboBox = CType(ctrl, ComboBox)
'            cbobx.Enabled = IsEnable
'        End If
'        If (ctrl.GetType() Is GetType(RadioButton)) Then
'            Dim cbobx As RadioButton = CType(ctrl, RadioButton)
'            cbobx.Enabled = IsEnable
'        End If
'        If (ctrl.GetType() Is GetType(DateTimePicker)) Then
'            Dim dtp As DateTimePicker = CType(ctrl, DateTimePicker)
'            dtp.Enabled = IsEnable
'        End If

'        If Recurse Then
'            If (ctrl.GetType() Is GetType(Panel)) Then
'                Dim pnl As Panel = CType(ctrl, Panel)
'                ClearAllControls(pnl, Recurse, IsEnable)
'            End If
'            If ctrl.GetType() Is GetType(GroupBox) Then
'                Dim grbx As GroupBox = CType(ctrl, GroupBox)
'                ClearAllControls(grbx, Recurse, IsEnable)
'            End If

'            If ctrl.GetType() Is GetType(TabPage) Then
'                '  Dim grbx As GroupBox = CType(ctrl, TabPage)
'                ClearAllControls(ctrl, Recurse, IsEnable)
'            End If

'        End If
'    Next
'End Sub

'Private Sub SetScreenRevision()
'    btn_print_dm.Enabled = False
'    btn_print_sum.Enabled = False
'    btn_Correction.Enabled = False
'    btnSave.Enabled = False
'    btn_parent.Enabled = False

'    rad_set_as_parent_company_y.Enabled = False
'    rad_set_as_parent_company_n.Enabled = False


'    Call setDisableAllTab()

'    Select Case txt_revision_code.Text.ToUpper
'        'Update Company Profile

'        Case "Rev0001".ToUpper, "Rev0051".ToUpper

'            tab_main.TabPages(0).Enabled = True

'            '=====by spec 
'            btnSave.Enabled = True
'            txt_client_code.Enabled = False

'        Case "Rev0002".ToUpper 'Disable GCP Service at Company Profile
'            txt_gcp_service_end_date.Enabled = True
'            btnSave.Enabled = True

'        Case "Rev0003".ToUpper 'Add User Profile
'            '=====Tab_UMM_User
'            btn_Addnew_User.Enabled = True
'            btn_edit_user.Enabled = True
'            ' btn_delete_user.Enabled = False
'            grd_user.Enabled = True

'            '=====Tab_Category
'            btn_GenerateGroup.Enabled = True
'            btn_ViewGroup.Enabled = True
'            btn_CopyCategory.Enabled = True
'            grd_category.Enabled = True

'            '---------table btn_new_product
'            btn_new_product.Enabled = False
'            btn_edit_product.Enabled = False
'            btn_delete_product.Enabled = False
'            grd_product.Enabled = False


'        Case "Rev0004".ToUpper 'Update User Profile
'            '=====Tab_UMM_User
'            'btn_Addnew_User.Enabled = True
'            btn_edit_user.Enabled = True
'            ' btn_delete_user.Enabled = False
'            grd_user.Enabled = True

'            '=====Tab_Category
'            btn_GenerateGroup.Enabled = True
'            btn_ViewGroup.Enabled = True
'            btn_CopyCategory.Enabled = True
'            grd_category.Enabled = True

'        Case "Rev0025".ToUpper, "Rev0026".ToUpper, "Rev0029".ToUpper
'            '=====Tab_UMM_User
'            'btn_Addnew_User.Enabled = True
'            btn_edit_user.Enabled = True
'            ' btn_delete_user.Enabled = False
'            grd_user.Enabled = True

'            '=====Tab_Category
'            'btn_GenerateGroup.Enabled = True
'            'btn_ViewGroup.Enabled = True
'            'btn_CopyCategory.Enabled = True
'            'grd_category.Enabled = True
'        Case "Rev0027".ToUpper
'            '=====Tab_UMM_User
'            'btn_Addnew_User.Enabled = True
'            btn_edit_user.Enabled = True
'            ' btn_delete_user.Enabled = False
'            grd_user.Enabled = True

'            '=====Tab_Category
'            btn_GenerateGroup.Enabled = True
'            'btn_ViewGroup.Enabled = True
'            'btn_CopyCategory.Enabled = True
'            'grd_category.Enabled = True
'        Case "Rev0028".ToUpper
'            '=====Tab_UMM_User
'            'btn_Addnew_User.Enabled = True
'            btn_edit_user.Enabled = True
'            ' btn_delete_user.Enabled = False
'            grd_user.Enabled = True

'            '=====Tab_Category
'            btn_GenerateGroup.Enabled = True
'            btn_ViewGroup.Enabled = True
'            btn_CopyCategory.Enabled = True
'            grd_category.Enabled = True
'        Case "Rev0005".ToUpper 'Delete User Profile
'            '=====Tab_UMM_User
'            'btn_Addnew_User.Enabled = True
'            btn_edit_user.Enabled = True
'            ' btn_delete_user.Enabled = False
'            grd_user.Enabled = True

'            '=====Tab_Category
'            'btn_GenerateGroup.Enabled = True
'            'btn_ViewGroup.Enabled = True
'            'btn_CopyCategory.Enabled = True
'            'grd_category.Enabled = True

'        Case "Rev0006".ToUpper 'Add New Account
'            '====acccount===
'            btn_new_account.Enabled = True
'            btn_edit_account.Enabled = True
'            '  btn_delete_account.Enabled = False
'            grd_account.Enabled = True

'        Case "Rev0007".ToUpper 'Update Account
'            '====acccount===
'            'btn_new_account.Enabled = True
'            btn_edit_account.Enabled = True
'            '  btn_delete_account.Enabled = False
'            grd_account.Enabled = True
'        Case "Rev0008".ToUpper 'Disable Account
'            '====acccount===
'            'btn_new_account.Enabled = True
'            btn_edit_account.Enabled = True
'            '  btn_delete_account.Enabled = False
'            grd_account.Enabled = True

'        Case "Rev0009".ToUpper '  'Rev0009	Client Pickup Location Changing
'            '=====Tab_Products
'            ' btn_new_product.Enabled = False
'            btn_edit_product.Enabled = True
'            ' btn_delete_product.Enabled = False
'            grd_product.Enabled = True


'        Case "Rev0012".ToUpper, "Rev0050".ToUpper
'            'Rev0012	Add My Product	12
'            'MsgBox("Application does support this function.")

'            btn_new_product.Enabled = True
'            btn_edit_product.Enabled = True
'            'btn_delete_product.Enabled = True
'            grd_product.Enabled = True

'        Case "Rev0013".ToUpper
'            'Rev0013	Update My Product	13
'            ' MsgBox("Application does support this function.")

'            '=====Tab_Products
'            ' btn_new_product.Enabled = False
'            btn_edit_product.Enabled = True
'            ' btn_delete_product.Enabled = False
'            grd_product.Enabled = True

'        Case "Rev0014".ToUpper
'            'Rev0014	Disable My Product	14
'            '=====Tab_Products
'            ' btn_new_product.Enabled = False
'            btn_edit_product.Enabled = True
'            ' btn_delete_product.Enabled = False
'            grd_product.Enabled = True


'        Case "Rev0020".ToUpper
'            'Rev0020	Add Authorization Matrix	20
'            'MsgBox("Application does support this function.")

'            '=====Tab_AuthorizationMatrix
'            btn_new_auth.Enabled = True
'            btn_edit_auth.Enabled = True
'            '  btn_delete_auth.Enabled = True
'            grd_auth.Enabled = True

'        Case "Rev0021".ToUpper
'            'Rev0021	Update Authorization Matrix	21
'            ' MsgBox("Application does support this function.")
'            btn_new_auth.Enabled = False
'            btn_edit_auth.Enabled = True
'            '  btn_delete_auth.Enabled = True
'            grd_auth.Enabled = True


'        Case "Rev0022".ToUpper 'charge package
'            btn_revision_add_charge_package.Enabled = True
'            grd_product.Enabled = True

'        Case "Rev0023".ToUpper 'change product template
'            btn_edit_product.Enabled = True
'            grd_product.Enabled = True
'        Case "Rev0024".ToUpper 'change default charge template
'            btn_edit_product.Enabled = True
'            grd_product.Enabled = True

'        Case "Rev0026".ToUpper 'Add User Client Relation
'            '=====Tab_UMM_User
'            btn_Addnew_User.Enabled = False
'            btn_edit_user.Enabled = True
'            grd_user.Enabled = True

'            '=====Tab_Category
'            btn_GenerateGroup.Enabled = True
'            btn_ViewGroup.Enabled = True
'            btn_CopyCategory.Enabled = True
'            grd_category.Enabled = True


'        Case "Rev0030".ToUpper 'RMS - Add/Update RMS
'            btn_new_rms.Enabled = True
'            btn_edit_rms.Enabled = True
'            btn_delete_rms.Enabled = True
'            grd_rms.Enabled = True

'            'Case Else
'            'MsgBox("Application does support this function.")

'    End Select

'    btn_print.Enabled = False

'End Sub