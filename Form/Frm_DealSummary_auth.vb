Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_DealSummary_auth

    Public strID As String = ""
    Public strMODE As String = "ADD"
    Public strAuthorizationType As String = ""
    Public strAuthorizationParameter As String = ""
    Public strProduct As String = ""
    Public strAccount As String = ""
    Public strLimitFrom As String = ""
    Public strLimitTo As String = ""
    Public strLevelNumber As String = ""
    Public strNoOfUser As String = ""

    'Private Is_changeFlag As Boolean = True
    'Private Const str_start_group = "start-group"
    'Private Const str_end_group = "end-group"
    'Private strGroupData As String = ""
    'Private str_group_type As String = ""

    Private Const strALL = "--------Select--------"
    Dim conn As CSQL
    Dim strMaxLimmit = "99999999999.99"

#Region "init"

    Private Sub Frm_DealSummary_auth_svm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub SetForm_by_AuthorizationType()

        cbo_Account.Text = ""

        If cbo_AuthorizationType.Text = "Product" Then
            cbo_Account.Enabled = False
            cbo_Account.BackColor = Color.Gray
            cbo_Account.Text = ""
        Else
            Dim strSQL As String = ""

            strSQL = ""
            strSQL += " SELECT distinct acc.account_number "
            strSQL += " from dbo.TB_DEAL_ACCOUNT acc"
            strSQL += "  where acc.company_id ='" & txt_company_id.Text.Replace("'", "''") & "' "
            strSQL += " and acc.account_number  in ("
            strSQL += " select p.account_number "
            strSQL += " from dbo.TB_DEAL_PRODUCT_ACCOUNT p where p.company_id=acc.company_id  "
            strSQL += " and my_product='" & cbo_Product.Text.Replace("'", "''") & "' ) "
            strSQL += " order by acc.account_number "

            conn.Fill_ComboBox(strSQL, cbo_Account, "")

            cbo_Account.Enabled = True
            cbo_Account.BackColor = Color.White
        End If

    End Sub

    Public Sub FillComboALL()
        Dim strSQL As String = ""
        Dim strCrit As String = ""
        Dim strParent As String = ""


        ''-- Set Parent company
        If txt_company_id.Text <> "" Then
            strParent = conn.GetDataFromSQL("SELECT top 1 company_id_parent from dbo.TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "'")
            If strParent = "" Then
                strParent = txt_company_id.Text
            End If
        Else
            strParent = txt_company_id.Text
        End If


        cbo_AuthorizationType.Items.Clear()
        cbo_AuthorizationType.Items.Add("Product")
        cbo_AuthorizationType.Items.Add("Account")
        cbo_AuthorizationType.Items.Add("")
        cbo_AuthorizationType.Text = "Product"

        'cbo_AuthorizationType
        cbo_AuthorizationParameter.Items.Clear()
        cbo_AuthorizationParameter.Items.Add("Authorization Matrix")
        cbo_AuthorizationParameter.Items.Add("Signatory Matrix")
        cbo_AuthorizationParameter.Items.Add("")
        cbo_AuthorizationParameter.Text = strAuthorizationParameter
        cbo_AuthorizationParameter.Enabled = False


        strSQL = " SELECT distinct my_product from dbo.TB_DEAL_PRODUCT where company_id ='" & txt_company_id.Text.Replace("'", "''") & "' order by my_product "
        conn.Fill_ComboBox(strSQL, cbo_Product)

        strSQL = " SELECT distinct account_number from dbo.TB_DEAL_ACCOUNT where company_id ='" & txt_company_id.Text.Replace("'", "''") & "' order by account_number "
        conn.Fill_ComboBox(strSQL, cbo_Account, "")

        '    '============FILL CATEGORY===========

        strCrit = ""
        strCrit += "("
        strCrit += " select a1.company_id "
        strCrit += " from "
        strCrit += " dbo.TB_DEAL_UMM_COMPANY a1"
        strCrit += " where a1.company_id ='" & strParent.Replace("'", "''") & "' AND a1.set_as_parent_company='Y'"
        strCrit += " UNION"
        strCrit += " select a1.company_id"
        strCrit += " from"
        strCrit += " dbo.TB_DEAL_UMM_COMPANY a1"
        strCrit += " where a1.company_id_parent='" & strParent.Replace("'", "''") & "' AND a1.set_as_parent_company='N'"
        strCrit += " )"

        strSQL = " SELECT a.User_Category_ID  from dbo.TB_CATEGORY a where a.company_id  in ( " & strCrit & " ) and a.payment_authoriser_flag='Y'  order by a.User_Category_ID  "
        conn.Fill_ComboBox(strSQL, cbo_category)

    End Sub

    Private Sub FillComboUser()
        Dim strSQL As String = ""
        cbo_user.Text = ""
        cbo_user.Enabled = False
        '  If cbo_Product.Text <> "" And cbo_AuthorizationType.Text <> "" Then

        If cbo_AuthorizationType.Text = "Account" Then
            If cbo_Account.Text <> "" Then
                strSQL = "exec dbo.[sp_deal_get_avm_user] '" & txt_company_id.Text.Replace("'", "''") & "','" & cbo_Product.Text.Replace("'", "''") & "','" & cbo_Account.Text.Replace("'", "''") & "'  "
                cbo_user.Enabled = True
            Else
                Exit Sub
            End If

        Else
            cbo_user.Enabled = True
            strSQL = "exec dbo.[sp_deal_get_avm_user] '" & txt_company_id.Text.Replace("'", "''") & "','" & cbo_Product.Text.Replace("'", "''") & "',null  "
        End If

        conn.Fill_ComboBox(strSQL, cbo_user)
        conn.Fill_ComboBox(strSQL, lst_user)

        ' End If 'If cbo_Product.Text <> "" Then

        'If strAuthorizationParameter <> "Signatory Matrix" Then
        '    'avm
        '    strSQL = " SELECT isnull(user_id,'') + '@' + isnull(company_id,'')  as  user_id from dbo.TB_DEAL_UMM_USER where company_id in ( " & strCrit & " ) AND admin_authoriser_flag='Y' order by user_id "
        '    conn.Fill_ComboBox(strSQL, lst_user)

        'Else
        '    'svm

        'End If

    End Sub

#End Region

    Private Sub Frm_DealSummary_auth_svm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String = ""

        Try

            Me.KeyPreview = True
            conn = New CSQL
            conn.Connect()

            Call FillComboALL()

            'set form  by auth type
            Call SetForm_by_AuthorizationType()

            cbo_AuthorizationType.Text = strAuthorizationType
            cbo_AuthorizationParameter.Text = strAuthorizationParameter
            cbo_Product.Text = strProduct
            cbo_Account.Text = strAccount
            txt_LimitFrom.Text = strLimitFrom
            txt_LimitTo.Text = strLimitTo
            txt_LevelNumber.Text = strLevelNumber
            txt_NoOfUser.Text = strNoOfUser

            If txt_LimitFrom.Text = "" Then txt_LimitFrom.Text = "0.00"
            If txt_LimitTo.Text = "" Then txt_LimitTo.Text = strMaxLimmit

            Call FillComboUser()


            If strMODE.ToUpper <> "ADD" Then
                Call ShowData()

                ''-- Set revision screen
                If txt_revision_code.Text = "Rev0083" Then



                End If

            Else

                Dim iRowMax As Double = 0

                strSQL = ""
                strSQL += " SELECT isn/ull(max(LevelNumber),0) as  LevelNumber FROM [TB_DEAL_AUTH] "
                strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
                strSQL += "  and LimitFrom= " + txt_LimitFrom.Text.Replace(",", "") + " "
                strSQL += "  and LimitTo= " + txt_LimitTo.Text.Replace(",", "") + " "
                strSQL += "  and AuthorizationType= '" + cbo_AuthorizationType.Text.Replace(",", "") + "' "
                strSQL += "  and AuthorizationParameter= '" + cbo_AuthorizationParameter.Text.Replace(",", "") + "' "
                strSQL += "  and Product= '" + cbo_Product.Text.Replace("'", "''") + "' "
                strSQL += "  and Account= '" + cbo_Account.Text.Replace("'", "''") + "' "
                iRowMax = conn.GetDataFromSQL(strSQL)

                txt_LevelNumber.Text = iRowMax + 1
                txt_NoOfUser.Text = strNoOfUser

            End If

            ''-------------

            If strAuthorizationParameter = "Signatory Matrix" Then

                txt_LevelNumber.Visible = False
                lb_LevelNumber.Visible = False

                txt_NoOfUser.Visible = False
                lb_NoOfUser.Visible = False

                ' txt_SignatoryMatrix.Visible = False
                txt_LevelNumber.Text = "0"
                txt_NoOfUser.Text = "0"

                lst_user.Visible = False
                Panel_SVM.Visible = True
                'TabUserList.TabPages(0).Enabled = False
                'TabUserList.TabPages(1).Enabled = True

            Else

                '=============FILL USER============
                'cbo_user

                txt_LevelNumber.Visible = True
                lb_LevelNumber.Visible = True

                txt_NoOfUser.Visible = True
                lb_NoOfUser.Visible = True

                lst_user.Visible = True
                Panel_SVM.Visible = False

                'lst_user.Enabled = True
                'TabUserList.TabPages(0).Enabled = True
                'TabUserList.TabPages(1).Enabled = False
                TabUserList.SelectTab(1)


            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        Dim iRowMax As Double = 0

        strSQL = ""
        strSQL += " SELECT isnull(max(LevelNumber),0) as  LevelNumber FROM [TB_DEAL_AUTH] "
        strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
        strSQL += "  and LimitFrom= " + txt_LimitFrom.Text.Replace(",", "") + " "
        strSQL += "  and LimitTo= " + txt_LimitTo.Text.Replace(",", "") + " "
        strSQL += "  and AuthorizationType= '" + cbo_AuthorizationType.Text.Replace(",", "") + "' "
        strSQL += "  and AuthorizationParameter= '" + cbo_AuthorizationParameter.Text.Replace(",", "") + "' "
        strSQL += "  and Product= '" + cbo_Product.Text.Replace("'", "''") + "' "
        strSQL += "  and Account= '" + cbo_Account.Text.Replace("'", "''") + "' "
        iRowMax = conn.GetDataFromSQL(strSQL)

        strSQL = ""
        strSQL += " SELECT * FROM [TB_DEAL_AUTH] "
        strSQL += " WHERE [id] ='" + txt_ID.Text.Replace("'", "''") + "'  "
      

        If iRowMax <> CDbl(txt_LevelNumber.Text) And strAuthorizationParameter = "Authorization Matrix" Then
            MsgBox("Allow edit for Max Level only.")
            Me.Close()
        End If

        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()
            cbo_AuthorizationParameter.Enabled = False
            cbo_Product.Enabled = False
            cbo_AuthorizationType.Enabled = False
            cbo_Account.Enabled = False
            txt_LimitFrom.Enabled = False
            txt_LimitTo.Enabled = False
            txt_LevelNumber.Enabled = False
            txt_NoOfUser.Enabled = False
            cbo_Product.Text = IIf(res("Product") Is System.DBNull.Value, "", res("Product").ToString())
            cbo_AuthorizationType.Text = IIf(res("AuthorizationType") Is System.DBNull.Value, "", res("AuthorizationType").ToString())
            cbo_Account.Text = IIf(res("Account") Is System.DBNull.Value, "", res("Account").ToString())
            txt_LevelNumber.Text = IIf(res("LevelNumber") Is System.DBNull.Value, "", res("LevelNumber").ToString())
            txt_NoOfUser.Text = IIf(res("NoOfUser") Is System.DBNull.Value, "", res("NoOfUser").ToString())

            If txt_LimitFrom.Text <> "" And IsNumeric(txt_LimitFrom.Text) Then
                txt_LimitFrom.Text = CDbl(txt_LimitFrom.Text).ToString("###,##0.00")
            End If
            If txt_LimitTo.Text <> "" And IsNumeric(txt_LimitTo.Text) Then
                txt_LimitTo.Text = CDbl(txt_LimitTo.Text).ToString("###,##0.00")
            End If

            If strAuthorizationParameter <> "Signatory Matrix" Then
                '==avm================user lists================
                Dim strUserList As String = ""
                Dim vntUserList As Object
                Dim i As Integer = 0
                Dim j As Integer = 0

                If strUserList = "" Then
                    strUserList = IIf(res("SignatoryMatrix") Is System.DBNull.Value, "", res("SignatoryMatrix").ToString())
                    vntUserList = Split(strUserList, " OR ")
                    For i = 0 To UBound(vntUserList)
                        For j = 0 To lst_user.Items.Count - 1
                            If vntUserList(i).ToString = lst_user.Items(j).ToString Then
                                lst_user.SetItemChecked(j, True)
                                ' Exit For
                            End If
                        Next
                    Next
                End If


            Else
                ' Panel_SVM.Visible = True
                txt_SignatoryMatrix.Text = IIf(res("SignatoryMatrix") Is System.DBNull.Value, "", res("SignatoryMatrix").ToString())

                If txt_SignatoryMatrix.Text <> "" Then
                    Dim strvnt As Object = Split(txt_SignatoryMatrix.Text, " OR ")
                    Dim strTmp As String = ""
                    Dim i As Integer
                    For i = 0 To UBound(strvnt)
                        strTmp = strvnt(i)
                        strTmp = Replace(strTmp, "( ", "")
                        strTmp = Replace(strTmp, " )", "")
                        lstdata.Items.Add(strTmp)
                    Next
                End If
               
            End If

            If lstdata.SelectedIndex = -1 Then lstdata.SelectedIndex = lstdata.Items.Count - 1


            'If IIf(res("valid_flag") Is System.DBNull.Value, "", res("valid_flag").ToString()) = "Y" Then
            '    rad_yes.Checked = True
            'Else
            '    rad_no.Checked = True
            'End If

        End If
        res.Close()
        res = Nothing

    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub txt_LimitFrom_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_LimitFrom.Validated
        If IsNumeric(txt_LimitFrom.Text.Replace(",", "")) = False Then
            txt_LimitFrom.Text = ""
        End If

        If txt_LimitFrom.Text = "0" Then
            txt_LimitFrom.Text = "0.01"
        End If

    End Sub

    Private Sub txt_LimitTo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_LimitTo.Validated
        If IsNumeric(txt_LimitTo.Text.Replace(",", "")) = False Then
            txt_LimitTo.Text = ""
        End If
    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""
        If strMODE = "EDIT" Then
            Return strErr
            Exit Function
        End If

        If cbo_AuthorizationType.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Authorization Parameter]"
        Else
            If cbo_AuthorizationType.Text = "Product" Then
                If cbo_Product.Text = "" Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Product]"
                End If
            Else
                If cbo_Account.Text = "" Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Account]"
                End If
            End If
        End If

        If cbo_AuthorizationType.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Authorization Type]"

        End If

        If txt_LimitFrom.Text = "" Or IsNumeric(txt_LimitFrom.Text) = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Limit From]"
        End If

        If txt_LimitFrom.Text = "" Or IsNumeric(txt_LimitFrom.Text) = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Limit To]"
        End If

        If txt_LevelNumber.Text = "" Or IsNumeric(txt_LevelNumber.Text) = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Auth Level]"
        End If

        If txt_NoOfUser.Text = "" Or IsNumeric(txt_NoOfUser.Text) = False Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [No. of User]"
        End If



        If strAuthorizationParameter <> "Signatory Matrix" Then
            'avm
            Dim strUserList As String = ""
            Dim iCount As Integer = 0
            For Each Entry In lst_user.CheckedItems
                iCount += 1
            Next

            If iCount = 0 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [User]"
            End If
        Else
            'svm
            If txt_SignatoryMatrix.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Signatory Matrix]"
            End If

        End If




        If strErr = "" Then

            Dim strSQL As String = ""
            Dim vnt As String = ""

            If cbo_AuthorizationParameter.Text = "Authorization Matrix" Then



                strSQL = ""
                strSQL += " SELECT count(*) as c FROM [TB_DEAL_AUTH] "
                strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
                strSQL += "  and LimitFrom= " + txt_LimitFrom.Text.Replace(",", "") + " "
                strSQL += "  and LimitTo= " + txt_LimitTo.Text.Replace(",", "") + " "
                strSQL += "  and AuthorizationType= '" + cbo_AuthorizationType.Text.Replace(",", "") + "' "
                strSQL += "  and AuthorizationParameter= '" + cbo_AuthorizationParameter.Text.Replace(",", "") + "' "
                strSQL += "  and Product= '" + cbo_Product.Text.Replace("'", "''") + "' "
                strSQL += "  and Account= '" + cbo_Account.Text.Replace("'", "''") + "' "
                strSQL += "  and LevelNumber= " + txt_LevelNumber.Text.Replace(",", "") + " "
                '  strSQL += "  and SignatoryMatrix like '%" & Entry.ToString.Replace("''", "'") & "%'"

                vnt = conn.GetDataFromSQL(strSQL)
                If CDbl(vnt) > 0 Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [duplication level]-" & txt_LevelNumber.Text

                End If

                'Dim strUserList As String = ""
                For Each Entry In lst_user.CheckedItems
                    '  strUserList += IIf(strUserList = "", "", " OR ") & Entry.ToString.Replace("''", "'")

                    strSQL = ""
                    strSQL += " SELECT count(*) as c FROM [TB_DEAL_AUTH] "
                    strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
                    strSQL += "  and LimitFrom= " + txt_LimitFrom.Text.Replace(",", "") + " "
                    strSQL += "  and LimitTo= " + txt_LimitTo.Text.Replace(",", "") + " "
                    strSQL += "  and AuthorizationType= '" + cbo_AuthorizationType.Text.Replace(",", "") + "' "
                    strSQL += "  and AuthorizationParameter= '" + cbo_AuthorizationParameter.Text.Replace(",", "") + "' "
                    strSQL += "  and Product= '" + cbo_Product.Text.Replace("'", "''") + "' "
                    strSQL += "  and Account= '" + cbo_Account.Text.Replace("'", "''") + "' "
                    ' strSQL += "  and LevelNumber= " + txt_LevelNumber.Text.Replace(",", "") + " "
                    strSQL += "  and SignatoryMatrix like '%" & Entry.ToString.Replace("''", "'") & "%'"

                    vnt = conn.GetDataFromSQL(strSQL)
                    If CDbl(vnt) > 0 Then
                        strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [duplication user]-" & Entry.ToString
                        Exit For
                    End If
                Next

            End If ' If cbo_AuthorizationParameter.Text = "Authorization Matrix" Then

            strSQL = ""
            strSQL += " exec [dbo].[sp_deal_AuthValidate] "
            If strMODE = "ADD" Then
                strSQL += " @ID=null"
            Else
                strSQL += "@ID='" & txt_ID.Text & "' "
            End If
            strSQL += ", @company_id='" & txt_company_id.Text & "' "
            strSQL += ", @AuthorizationParameter='" & cbo_AuthorizationParameter.Text & "' "
            strSQL += ", @AuthorizationType='" & cbo_AuthorizationType.Text & "' "
            strSQL += ", @Product='" & cbo_Product.Text & "' "
            strSQL += ", @Account='" & cbo_Account.Text & "' "
            strSQL += ", @LimitFrom	= " & CDbl(txt_LimitFrom.Text) & " "
            strSQL += ", @LimitTo	= " & CDbl(txt_LimitTo.Text) & " "
            strSQL += ", @LevelNumber	= " & CDbl(txt_LevelNumber.Text) & " "
            strSQL += ", @NoOfUser	= " & CDbl(txt_NoOfUser.Text) & " "
            vnt = conn.GetDataFromSQL(strSQL)
            If vnt <> "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & Replace(vnt, ",", vbCrLf)
            End If

        End If ' If strErr = "" Then

        Return strErr
    End Function

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
        Dim strRevDate As String = Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat)

        Try
            conn = New CSQL
            conn.Connect()
            Dim strSQL As String = ""
            '========================add mode====================
            If strMODE.ToUpper = "ADD" Then
                'strSQL = "SELECT * FROM [TB_DEAL_AUTH] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "

                strSQL = ""
                strSQL += " SELECT * FROM [TB_DEAL_AUTH] "
                strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
                strSQL += "  and LimitFrom= " + txt_LimitFrom.Text.Replace(",", "") + " "
                strSQL += "  and LimitTo= " + txt_LimitTo.Text.Replace(",", "") + " "
                strSQL += "  and AuthorizationType= '" + cbo_AuthorizationType.Text.Replace(",", "") + "' "
                strSQL += "  and AuthorizationParameter= '" + cbo_AuthorizationParameter.Text.Replace(",", "") + "' "
                strSQL += "  and Product= '" + cbo_Product.Text.Replace("'", "''") + "' "
                strSQL += "  and Account= '" + cbo_Account.Text.Replace("'", "''") + "' "
                strSQL += "  and LevelNumber= " + txt_LevelNumber.Text.Replace(",", "") + " "

                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid [Authorization] is duplicate.")
                    Exit Sub
                End If

                Dim strValue As String = ""
                Dim strFiledname As String = ""

                strFiledname += vbCrLf & "[company_id]"
                strValue += vbCrLf & "N'" & txt_company_id.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[AuthorizationParameter]"
                strValue += vbCrLf & ",N'" & cbo_AuthorizationParameter.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[Product]"
                strValue += vbCrLf & ",N'" & cbo_Product.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[AuthorizationType]"
                strValue += vbCrLf & ",N'" & cbo_AuthorizationType.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[Account]"
                strValue += vbCrLf & ",N'" & cbo_Account.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[LimitFrom]"
                strValue += vbCrLf & ", " & txt_LimitFrom.Text.Replace(",", "") & " "

                strFiledname += vbCrLf & ",[LimitTo]"
                strValue += vbCrLf & ", " & txt_LimitTo.Text.Replace(",", "") & " "

                strFiledname += vbCrLf & ",[LevelNumber]"
                strValue += vbCrLf & ", " & txt_LevelNumber.Text.Replace(",", "") & " "

                strFiledname += vbCrLf & ",[NoOfUser]"
                strValue += vbCrLf & ", " & txt_NoOfUser.Text.Replace(",", "") & " "

                strFiledname += vbCrLf & ",[Valid_Flag]"

                Select Case rdoTrue.Checked
                    Case True

                        strValue += vbCrLf & ", 'Y' "
                    Case Else

                        strValue += vbCrLf & ", 'N' "
                End Select


                If strAuthorizationParameter <> "Signatory Matrix" Then
                    'avm
                    Dim strUserList As String = ""
                    For Each Entry In lst_user.CheckedItems
                        strUserList += IIf(strUserList = "", "", " OR ") & Entry.ToString.Replace("''", "'")
                    Next

                    strFiledname += vbCrLf & ",[SignatoryMatrix]"
                    strValue += vbCrLf & ",N'" & strUserList.ToString & "'"

                Else
                    'svm
                    strFiledname += vbCrLf & ",[SignatoryMatrix]"
                    strValue += vbCrLf & ",N'" & txt_SignatoryMatrix.Text.Replace("'", "''") & "'"

                End If

                strSQL = ""
                strSQL += vbCrLf & "insert into [TB_DEAL_AUTH]  "
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper = "ADD" Then


            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [TB_DEAL_AUTH] set "

                strSQL += vbCrLf & "[company_id]"
                strSQL += vbCrLf & "=N'" & txt_company_id.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[AuthorizationParameter]"
                strSQL += vbCrLf & "=N'" & cbo_AuthorizationParameter.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[Product]"
                strSQL += vbCrLf & "=N'" & cbo_Product.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[AuthorizationType]"
                strSQL += vbCrLf & "=N'" & cbo_AuthorizationType.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[Account]"
                strSQL += vbCrLf & "=N'" & cbo_Account.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[LimitFrom]"
                strSQL += vbCrLf & "= " & txt_LimitFrom.Text.Replace(",", "") & " "

                strSQL += vbCrLf & ",[LimitTo]"
                strSQL += vbCrLf & "= " & txt_LimitTo.Text.Replace(",", "") & " "

                strSQL += vbCrLf & ",[LevelNumber]"
                strSQL += vbCrLf & "= " & txt_LevelNumber.Text.Replace(",", "") & " "

                strSQL += vbCrLf & ",[NoOfUser]"
                strSQL += vbCrLf & "= " & txt_NoOfUser.Text.Replace(",", "") & " "

                strSQL += vbCrLf & ",[Valid_Flag]"

                Select Case rdoTrue.Checked
                    Case True

                        strSQL += vbCrLf & "= 'Y' "
                    Case Else

                        strSQL += vbCrLf & "= 'N' "
                End Select


                If strAuthorizationParameter <> "Signatory Matrix" Then
                    'avm
                    Dim strUserList As String = ""
                    For Each Entry In lst_user.CheckedItems
                        strUserList += IIf(strUserList = "", "", " OR ") & Entry.ToString.Replace("''", "'")
                    Next

                    strSQL += vbCrLf & ",[SignatoryMatrix]"
                    strSQL += vbCrLf & "=N'" & strUserList.ToString & "'"

                Else
                    'svm
                    strSQL += vbCrLf & ",[SignatoryMatrix]"
                    strSQL += vbCrLf & "=N'" & txt_SignatoryMatrix.Text.Replace("'", "''") & "'"

                End If

                strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
                strSQL += "  and LimitFrom= " + txt_LimitFrom.Text.Replace(",", "") + " "
                strSQL += "  and LimitTo= " + txt_LimitTo.Text.Replace(",", "") + " "
                strSQL += "  and AuthorizationType= '" + cbo_AuthorizationType.Text.Replace(",", "") + "' "
                strSQL += "  and Product= '" + cbo_Product.Text.Replace("'", "''") + "' "
                strSQL += "  and Account= '" + cbo_Account.Text.Replace("'", "''") + "' "
                strSQL += "  and LevelNumber= " + txt_LevelNumber.Text.Replace(",", "") + " "

                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper <> "ADD" Then


            If txt_revision_code.Text <> "" Then
                strSQL = ""
                strSQL += vbCrLf & "update [TB_DEAL_AUTH] set "

                '  strSQL += vbCrLf & "[gcp_service_end_date]"
                ' strSQL += vbCrLf & "=" & get_date_sql(txt_gcp_service_end_date.Text) & ""
                'strSQL += vbCrLf & "[valid_flag]"
                'If rad_yes.Checked = True Then
                '    strSQL += vbCrLf & "='Y'"
                'Else
                '    strSQL += vbCrLf & "='N'"
                'End If

                strSQL += vbCrLf & " [revision_code]"
                strSQL += vbCrLf & "=N'" & txt_revision_code.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[revision_desc]"
                strSQL += vbCrLf & "=N'" & txt_revision_desc.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[revision_date]"
                strSQL += vbCrLf & "= '" & strRevDate & "'"

                strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  "
                strSQL += "  and LimitFrom= " + txt_LimitFrom.Text.Replace(",", "") + " "
                strSQL += "  and LimitTo= " + txt_LimitTo.Text.Replace(",", "") + " "
                strSQL += "  and AuthorizationType= '" + cbo_AuthorizationType.Text.Replace(",", "") + "' "
                strSQL += "  and Product= '" + cbo_Product.Text.Replace("'", "''") + "' "
                strSQL += "  and Account= '" + cbo_Account.Text.Replace("'", "''") + "' "
                strSQL += "  and LevelNumber= " + txt_LevelNumber.Text.Replace(",", "") + " "


                'strSQL += vbCrLf & " DELETE FROM dbo.TB_REVISION_HISTORY WHERE company_id='" + txt_company_id.Text.Replace("'", "''") + "'"
                ''strSQL += vbCrLf & "   and revision_code='" + txt_revision_code.Text.Replace("'", "''") + "' "
                'strSQL += vbCrLf & "   and revision_code in ('Rev0020','Rev0021') "

                'strSQL += vbCrLf & " insert into  TB_REVISION_HISTORY (company_id,revision_code,revision_desc,revision_date) "
                ''company_id,revision_code,revision_desc,revision_date,revision_reason
                'strSQL += vbCrLf & " select distinct company_id,revision_code,revision_desc,revision_date from  TB_DEAL_AUTH"
                'strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  " 'and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "
                'strSQL += vbCrLf & "   and revision_code in ('Rev0020','Rev0021') "


                conn.ExecuteNonQuery(strSQL)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub txt_LevelNumber_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_LevelNumber.Validated
        If IsNumeric(txt_LevelNumber.Text.Replace(",", "")) = False Then
            txt_LevelNumber.Text = ""
        End If
    End Sub

    Private Sub txt_NoOfUser_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_NoOfUser.Validated
        If IsNumeric(txt_NoOfUser.Text.Replace(",", "")) = False Then
            txt_NoOfUser.Text = ""
        End If
    End Sub


    Private Sub cbo_AuthorizationType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_AuthorizationType.Validated
        'Call SetForm_by_AuthorizationType()
        'Call FillComboUser()
    End Sub

    Private Sub cbo_Account_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_Account.Validated
        Call FillComboUser()
    End Sub

    Private Sub btn_add_category_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_category.Click
        If cbo_category.Text = "" Then Exit Sub
        'lstdata.SelectedIndex = lstdata.Items.Count
        If lstdata.SelectedIndex = -1 Then lstdata.SelectedIndex = lstdata.Items.Count - 1

        Dim strtemp As String = ""

        If rad_start_group.Checked = True Then
            If lstdata.Items.Count = 0 Then lstdata.Items.Add("")
            If lstdata.SelectedIndex = -1 Then lstdata.SelectedIndex = lstdata.Items.Count - 1
            strtemp = lstdata.Items(lstdata.SelectedIndex)
            strtemp += IIf(strtemp = "", "", " AND ") & cbo_category.Text
            lstdata.Items(lstdata.SelectedIndex) = strtemp
        Else
            strtemp = cbo_category.Text
            lstdata.Items.Add("")
            lstdata.Items(lstdata.Items.Count - 1) = strtemp

        End If 'If strGroupData = str_start_group Then
        Call GenCode()
    End Sub

    Private Sub btn_add_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_user.Click
        If cbo_user.Text = "" Then Exit Sub
        If lstdata.SelectedIndex = -1 Then lstdata.SelectedIndex = lstdata.Items.Count - 1

        ' lstdata.SelectedIndex = lstdata.Items.Count
        Dim strtemp As String = ""

        If rad_start_group.Checked = True Then
            If lstdata.Items.Count = 0 Then lstdata.Items.Add("")
            If lstdata.SelectedIndex = -1 Then lstdata.SelectedIndex = lstdata.Items.Count - 1
            strtemp = lstdata.Items(lstdata.SelectedIndex)
            strtemp += IIf(strtemp = "", "", " AND ") & cbo_user.Text
            lstdata.Items(lstdata.SelectedIndex) = strtemp
        Else
            strtemp = cbo_user.Text
            lstdata.Items.Add("")
            lstdata.Items(lstdata.Items.Count - 1) = strtemp

        End If 'If strGroupData = str_start_group Then
        Call GenCode()
    End Sub


    Private Sub btn_remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_remove.Click
        If lstdata.SelectedIndex < 0 Then Exit Sub
        lstdata.Items.RemoveAt(lstdata.SelectedIndex)
        Call GenCode()
    End Sub


    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        If lstdata.SelectedIndex < 0 Then Exit Sub
        Dim intTmp As Integer = lstdata.SelectedIndex
        Dim intTmp_sw As Integer = 0

        Dim strTemp As String = ""
        intTmp_sw = intTmp - 1
        If intTmp_sw < 0 Then Exit Sub
        'lstdata.Items.Count 
        strTemp = lstdata.Items(intTmp_sw)
        lstdata.Items(intTmp_sw) = lstdata.Items(intTmp).ToString
        lstdata.Items(intTmp) = strTemp
        lstdata.SelectedIndex = intTmp_sw
        Call GenCode()
    End Sub

    Private Sub btn_Down_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Down.Click
        If lstdata.SelectedIndex < 0 Then Exit Sub
        Dim intTmp As Integer = lstdata.SelectedIndex
        Dim intTmp_sw As Integer = 0

        Dim strTemp As String = ""
        intTmp_sw = intTmp + 1
        If intTmp_sw > lstdata.Items.Count - 1 Then Exit Sub
        'lstdata.Items.Count 
        strTemp = lstdata.Items(intTmp_sw)
        lstdata.Items(intTmp_sw) = lstdata.Items(intTmp)
        lstdata.Items(intTmp) = strTemp
        lstdata.SelectedIndex = intTmp_sw
        Call GenCode()
    End Sub

    Private Sub GenCode()
        Dim strData As String = ""
        Dim i As Integer = 0
        For i = 0 To lstdata.Items.Count - 1
            If lstdata.Items(i).ToString <> "" Then
                If InStr(lstdata.Items(i).ToString, " AND ", CompareMethod.Text) > 0 Then
                    strData += IIf(strData = "", "", " OR ") & "( " & lstdata.Items(i).ToString & " )"
                Else
                    strData += IIf(strData = "", "", " OR ") & lstdata.Items(i).ToString
                End If
            End If
        Next

        txt_SignatoryMatrix.Text = strData
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        lstdata.Items.Clear()
        txt_SignatoryMatrix.Text = ""
    End Sub


    Private Sub cbo_Product_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Product.SelectedIndexChanged
        Call FillComboUser()
        Call GetDefaultValue()
        Call SetForm_by_AuthorizationType()
    End Sub

    Private Sub GetDefaultValue()
        Try
            If cbo_Product.Text = "" Then Exit Sub
            Dim strsql As String = ""
            Dim vnt As String = ""

            strsql = " select auth_type from dbo.TB_DEAL_PRODUCT where company_id='" & txt_company_id.Text.Replace("'", "''") & "' and my_product='" & cbo_Product.Text.Replace("'", "''") & "' "
            vnt = conn.GetDataFromSQL(strsql)


            If vnt = "Account" Then
                cbo_AuthorizationType.Text = "Account"
            Else
                cbo_AuthorizationType.Text = "Product"
            End If

            'default limit from /to
            If cbo_AuthorizationParameter.Text = "Authorization Matrix" And strMODE = "ADD" Then

                '-- Tum: set default limit from = 0.00; 25-Apr-2014
                'strsql = " select isnull(max(LimitTo),0)  as LimitTo from  dbo.TB_DEAL_AUTH a "
                'strsql += " where a.company_id='" & txt_company_id.Text.Replace("'", "''") & "' "
                'strsql += "   and AuthorizationParameter='Signatory Matrix' "
                'strsql += " and Product='" & cbo_Product.Text.Replace("'", "''") & "' "

                ''where company_id='" & txt_company_id.Text.Replace("'", "''") & "' and my_product='" & cbo_Product.Text.Replace("'", "''") & "' "
                'vnt = conn.GetDataFromSQL(strsql)

                'If CDbl(vnt) < CDbl(strMaxLimmit) Then
                '    'MsgBox("Maximum value")
                '    txt_LimitFrom.Text = CDbl(vnt) + 0.01
                'Else
                '    txt_LimitFrom.Text = strMaxLimmit
                'End If

                txt_LimitTo.Text = "0.00"
                txt_LimitTo.Text = strMaxLimmit

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub


End Class