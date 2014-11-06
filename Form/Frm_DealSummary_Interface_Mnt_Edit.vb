Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_DealSummary_Interface_Mnt_Edit

    Public strID As String = ""
    Public strMODE As String = "ADD"
    Private Const strALL = "--------Select--------"
    Dim conn As CSQL

    Private Sub Frm_DealSummary_Interface_Mnt_Edit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
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

    Private Sub Frm_DealSummary_Interface_Mnt_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        conn = New CSQL
        conn.Connect()
        Dim strSQL As String = ""

        If strMODE.ToUpper <> "ADD" Then
            Call ShowData()
        End If
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_DEAL_INTERFACE_TEMPLATE] WHERE  mapping_code='" + strID.Replace("'", "''") + "' "
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()
            txt_mapping_code.Enabled = False

            txt_mapping_code.Text = IIf(res("mapping_code") Is System.DBNull.Value, "", res("mapping_code").ToString())
            txt_mapping_description.Text = IIf(res("mapping_description") Is System.DBNull.Value, "", res("mapping_description").ToString())
            cbo_interface_type.Text = IIf(res("interface_type") Is System.DBNull.Value, "", res("interface_type").ToString())
            cbo_interface_code.Text = IIf(res("interface_code") Is System.DBNull.Value, "", res("interface_code").ToString())
            cbo_process_code.Text = IIf(res("process_code") Is System.DBNull.Value, "", res("process_code").ToString())

            If IIf(res("checksum_flag") Is System.DBNull.Value, "", res("checksum_flag").ToString()) = "Y" Then
                rad_checksum_flag_y.Checked = True
            Else
                rad_checksum_flag_n.Checked = True
            End If

            cbo_checksum_algorithm.Text = IIf(res("checksum_algorithm") Is System.DBNull.Value, "", res("checksum_algorithm").ToString())
            If IIf(res("encryption_flag") Is System.DBNull.Value, "", res("encryption_flag").ToString()) = "Y" Then
                rad_encryption_flag_y.Checked = True
            Else
                rad_encryption_flag_n.Checked = True
            End If

            cbo_cryptography_type.Text = IIf(res("cryptography_type") Is System.DBNull.Value, "", res("cryptography_type").ToString())
            cbo_encryption_algorithm.Text = IIf(res("encryption_algorithm") Is System.DBNull.Value, "", res("encryption_algorithm").ToString())
            cbo_key_length.Text = IIf(res("key_length") Is System.DBNull.Value, "", res("key_length").ToString())
            txt_encryption_key.Text = IIf(res("encryption_key") Is System.DBNull.Value, "", res("encryption_key").ToString())

            cbo_checksum_algorithm.Text = IIf(res("checksum_algorithm") Is System.DBNull.Value, "", res("checksum_algorithm").ToString())
            If IIf(res("signing_flag") Is System.DBNull.Value, "", res("signing_flag").ToString()) = "Y" Then
                rad_signing_flag_y.Checked = True
            Else
                rad_signing_flag_n.Checked = True
            End If

            cbo_signing_type.Text = IIf(res("signing_type") Is System.DBNull.Value, "", res("signing_type").ToString())
            cbo_signing_algorithm.Text = IIf(res("signing_algorithm") Is System.DBNull.Value, "", res("signing_algorithm").ToString())

            txt_expiry_date.Text = get_date_to_control(res("expiry_date"))

            If IIf(res("auto_auth_flag") Is System.DBNull.Value, "", res("auto_auth_flag").ToString()) = "Y" Then
                rad_auto_auth_flag_y.Checked = True
            Else
                rad_auto_auth_flag_n.Checked = True
            End If

            txt_description_for_csd.Text = IIf(res("description_for_csd") Is System.DBNull.Value, "", res("description_for_csd").ToString())


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

        If txt_mapping_code.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Mapping Code]"
        End If

        If txt_mapping_description.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Mapping Description]"
        End If

        If cbo_interface_type.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Interface Type]"
        End If

        If cbo_interface_code.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Interface Code]"
        End If


        If cbo_process_code.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Process Code]"
        End If

        If txt_description_for_csd.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Description for CSD]"
        End If

        If rad_checksum_flag_y.Checked = True Then
            If cbo_checksum_algorithm.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Checksum  Algorithm]"
            End If
        End If

        If rad_encryption_flag_y.Checked = True Then

            If cbo_cryptography_type.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Cryptography Type]"
            End If

            If cbo_encryption_algorithm.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Encryption Algorithm]"
            End If

            If cbo_key_length.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Key length]"
            End If

            If txt_encryption_key.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Encryption Key]"
            End If

        End If


        If rad_signing_flag_y.Checked = True Then

            If cbo_signing_type.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Signing Type]"
            End If

            If cbo_signing_algorithm.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Signing Algorithm]"
            End If

            If txt_expiry_date.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Expiry date]"
            Else
                If get_date_sql(txt_expiry_date.Text) = "NULL" Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Expiry date]"
                End If
            End If
        End If

        Return strErr
    End Function

    Private Sub SaveData()
        Try


            conn = New CSQL
            conn.Connect()
            Dim strSQL As String = ""
            '========================add mode====================
            If strMODE.ToUpper = "ADD" Then
                strSQL = "SELECT * FROM [TB_DEAL_INTERFACE_TEMPLATE] WHERE  mapping_code='" + txt_mapping_code.Text.Replace("'", "''") + "' "
                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid [Interface] is duplicate.")
                    Exit Sub
                End If

                Dim strValue As String = ""
                Dim strFiledname As String = ""

                strFiledname += vbCrLf & "[mapping_code]"
                strValue += vbCrLf & "N'" & txt_mapping_code.Text.Replace("'", "''") & "'"



                strFiledname += vbCrLf & ",[mapping_description]"
                strValue += vbCrLf & ",N'" & txt_mapping_description.Text.Replace("'", "''") & "'"

                'cbo_interface_type
                strFiledname += vbCrLf & ",[interface_type]"
                strValue += vbCrLf & ",N'" & cbo_interface_type.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[interface_code]"
                strValue += vbCrLf & ",N'" & cbo_interface_code.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[process_code]"
                strValue += vbCrLf & ",N'" & cbo_process_code.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[checksum_flag]"
                strValue += vbCrLf & ",N'" & IIf(rad_checksum_flag_y.Checked = True, "Y", "N") & "'"

                strFiledname += vbCrLf & ",[checksum_algorithm]"
                strValue += vbCrLf & ",N'" & cbo_checksum_algorithm.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[encryption_flag]"
                strValue += vbCrLf & ",N'" & IIf(rad_encryption_flag_y.Checked = True, "Y", "N") & "'"

                strFiledname += vbCrLf & ",[cryptography_type]"
                strValue += vbCrLf & ",N'" & cbo_cryptography_type.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[encryption_algorithm]"
                strValue += vbCrLf & ",N'" & cbo_encryption_algorithm.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[key_length]"
                strValue += vbCrLf & ",N'" & cbo_key_length.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[encryption_key]"
                strValue += vbCrLf & ",N'" & txt_encryption_key.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[signing_flag]"
                strValue += vbCrLf & ",N'" & IIf(rad_signing_flag_y.Checked = True, "Y", "N") & "'"

                strFiledname += vbCrLf & ",[signing_type]"
                strValue += vbCrLf & ",N'" & cbo_signing_type.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[signing_algorithm]"
                strValue += vbCrLf & ",N'" & cbo_signing_algorithm.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[expiry_date]"
                strValue += vbCrLf & ", " & get_date_sql(txt_expiry_date.Text.Replace("'", "''"))

                strFiledname += vbCrLf & ",[auto_auth_flag]"
                strValue += vbCrLf & ",N'" & IIf(rad_auto_auth_flag_y.Checked = True, "Y", "N") & "'"

                strFiledname += vbCrLf & ",[description_for_csd]"
                strValue += vbCrLf & ",N'" & txt_description_for_csd.Text.Replace("'", "''") & "'"


                strSQL = ""
                strSQL += vbCrLf & "insert into [TB_DEAL_INTERFACE_TEMPLATE]  "
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper = "ADD" Then
            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [TB_DEAL_INTERFACE_TEMPLATE] set "


                strSQL += vbCrLf & "[mapping_code]"
                strSQL += vbCrLf & "=N'" & txt_mapping_code.Text.Replace("'", "''") & "'"



                strSQL += vbCrLf & ",[mapping_description]"
                strSQL += vbCrLf & "=N'" & txt_mapping_description.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[interface_type]"
                strSQL += vbCrLf & "=N'" & cbo_interface_type.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[interface_code]"
                strSQL += vbCrLf & "=N'" & cbo_interface_code.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[process_code]"
                strSQL += vbCrLf & "=N'" & cbo_process_code.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[checksum_flag]"
                strSQL += vbCrLf & "=N'" & IIf(rad_checksum_flag_y.Checked = True, "Y", "N") & "'"

                strSQL += vbCrLf & ",[checksum_algorithm]"
                strSQL += vbCrLf & "=N'" & cbo_checksum_algorithm.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[encryption_flag]"
                strSQL += vbCrLf & "=N'" & IIf(rad_encryption_flag_y.Checked = True, "Y", "N") & "'"

                strSQL += vbCrLf & ",[cryptography_type]"
                strSQL += vbCrLf & "=N'" & cbo_cryptography_type.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[encryption_algorithm]"
                strSQL += vbCrLf & "=N'" & cbo_encryption_algorithm.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[key_length]"
                strSQL += vbCrLf & "=N'" & cbo_key_length.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[encryption_key]"
                strSQL += vbCrLf & "=N'" & txt_encryption_key.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[signing_flag]"
                strSQL += vbCrLf & "=N'" & IIf(rad_signing_flag_y.Checked = True, "Y", "N") & "'"

                strSQL += vbCrLf & ",[signing_type]"
                strSQL += vbCrLf & "=N'" & cbo_signing_type.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[signing_algorithm]"
                strSQL += vbCrLf & "=N'" & cbo_signing_algorithm.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[expiry_date]"
                strSQL += vbCrLf & "= " & get_date_sql(txt_expiry_date.Text.Replace("'", "''"))

                strSQL += vbCrLf & ",[auto_auth_flag]"
                strSQL += vbCrLf & "=N'" & IIf(rad_auto_auth_flag_y.Checked = True, "Y", "N") & "'"


                strSQL += vbCrLf & ",[description_for_csd]"
                strSQL += vbCrLf & "=N'" & txt_description_for_csd.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & " WHERE  mapping_code='" + txt_mapping_code.Text.Replace("'", "''") + "' "
                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper <> "ADD" Then

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub FillCombo(Optional ByVal strControl As String = "")
        Dim mcrit As String = ""
        If cbo_interface_type.Text <> "" Then
            mcrit += IIf(mcrit = "", " where ", " and ") & " interface_type ='" & cbo_interface_type.Text.Replace("'", "''") & "'"
        End If
        Dim strSQL As String = ""

        strSQL = ""
        strSQL += "  select  #all.* "
        strSQL += "     from "
        strSQL += " ("
        strSQL += " select  interface_type from dbo.TB_DEAL_INTERFACE"
        strSQL += " union "
        strSQL += " select  interface_type from dbo.TB_DEAL_INTERFACE_TEMPLATE"
        strSQL += " ) #all order by interface_type "

        If strControl <> "cbo_interface_type" Then
            Call conn.Fill_ComboBox(strSQL, cbo_interface_type)
        End If

        strSQL = ""
        strSQL += "  select  #all.* "
        strSQL += "     from "
        strSQL += " ("
        strSQL += " select  interface_code from dbo.TB_DEAL_INTERFACE" & mcrit
        strSQL += " union "
        strSQL += " select  interface_code from dbo.TB_DEAL_INTERFACE_TEMPLATE" & mcrit
        strSQL += " ) #all order by interface_code "
        Call conn.Fill_ComboBox(strSQL, cbo_interface_code)

        strSQL = ""
        strSQL += "  select  #all.* "
        strSQL += "     from "
        strSQL += " ("
        strSQL += " select  process_code from dbo.TB_DEAL_INTERFACE" & mcrit
        strSQL += " union "
        strSQL += " select  process_code from dbo.TB_DEAL_INTERFACE_TEMPLATE" & mcrit
        strSQL += " ) #all order by process_code "
        Call conn.Fill_ComboBox(strSQL, cbo_process_code)
        'cbo_checksum_algorithm
        strSQL = ""
        strSQL += "  select  #all.* "
        strSQL += "     from "
        strSQL += " ("
        strSQL += " select  checksum_algorithm from dbo.TB_DEAL_INTERFACE" & mcrit
        strSQL += " union "
        strSQL += " select  checksum_algorithm from dbo.TB_DEAL_INTERFACE_TEMPLATE" & mcrit
        strSQL += " ) #all order by checksum_algorithm "
        Call conn.Fill_ComboBox(strSQL, cbo_checksum_algorithm)

        'cbo_cryptography_type
        strSQL = ""
        strSQL += "  select  #all.* "
        strSQL += "     from "
        strSQL += " ("
        strSQL += " select  cryptography_type from dbo.TB_DEAL_INTERFACE" & mcrit
        strSQL += " union "
        strSQL += " select  cryptography_type from dbo.TB_DEAL_INTERFACE_TEMPLATE" & mcrit
        strSQL += " ) #all order by cryptography_type "
        Call conn.Fill_ComboBox(strSQL, cbo_cryptography_type)

        'cbo_encryption_algorithm
        strSQL = ""
        strSQL += "  select  #all.* "
        strSQL += "     from "
        strSQL += " ("
        strSQL += " select  encryption_algorithm from dbo.TB_DEAL_INTERFACE" & mcrit
        strSQL += " union "
        strSQL += " select  encryption_algorithm from dbo.TB_DEAL_INTERFACE_TEMPLATE" & mcrit
        strSQL += " ) #all order by encryption_algorithm "
        Call conn.Fill_ComboBox(strSQL, cbo_encryption_algorithm)

        'cbo_key_length
        strSQL = ""
        strSQL += "  select  #all.* "
        strSQL += "     from "
        strSQL += " ("
        strSQL += " select  key_length from dbo.TB_DEAL_INTERFACE" & mcrit
        strSQL += " union "
        strSQL += " select  key_length from dbo.TB_DEAL_INTERFACE_TEMPLATE" & mcrit
        strSQL += " ) #all order by key_length "
        Call conn.Fill_ComboBox(strSQL, cbo_key_length)

        'cbo_signing_type
        strSQL = ""
        strSQL += "  select  #all.* "
        strSQL += "     from "
        strSQL += " ("
        strSQL += " select  signing_type from dbo.TB_DEAL_INTERFACE" & mcrit
        strSQL += " union "
        strSQL += " select  signing_type from dbo.TB_DEAL_INTERFACE_TEMPLATE" & mcrit
        strSQL += " ) #all order by signing_type "
        Call conn.Fill_ComboBox(strSQL, cbo_signing_type)


        'cbo_signing_algorithm
        strSQL = ""
        strSQL += "  select  #all.* "
        strSQL += "     from "
        strSQL += " ("
        strSQL += " select  signing_algorithm from dbo.TB_DEAL_INTERFACE" & mcrit
        strSQL += " union "
        strSQL += " select  signing_algorithm from dbo.TB_DEAL_INTERFACE_TEMPLATE" & mcrit
        strSQL += " ) #all order by signing_algorithm "
        Call conn.Fill_ComboBox(strSQL, cbo_signing_algorithm)

    End Sub

    Private Sub cbo_interface_type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_interface_type.SelectedIndexChanged
        Call FillCombo("cbo_interface_type")
    End Sub


    Private Sub rad_checksum_flag_n_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_checksum_flag_n.CheckedChanged
        Call SetCheckSum()
    End Sub


    Private Sub rad_checksum_flag_y_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_checksum_flag_y.CheckedChanged
        Call SetCheckSum()
    End Sub


    Private Sub rad_signing_flag_y_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_signing_flag_y.CheckedChanged
        Call set_encryption()
    End Sub


    Private Sub rad_signing_flag_n_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_signing_flag_n.CheckedChanged
        Call set_signing()
    End Sub

    Private Sub rad_encryption_flag_n_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_encryption_flag_n.CheckedChanged
        Call set_encryption()
    End Sub


    Private Sub rad_encryption_flag_y_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_encryption_flag_y.CheckedChanged
        Call set_encryption()
    End Sub


    Private Sub set_signing()
        If rad_signing_flag_y.Checked = True Then
            cbo_signing_type.Enabled = True
            cbo_signing_algorithm.Enabled = True
            txt_expiry_date.Enabled = True
        Else
            cbo_signing_type.Enabled = False
            cbo_signing_algorithm.Enabled = False
            txt_expiry_date.Enabled = False

            cbo_signing_type.Text = ""
            cbo_signing_algorithm.Text = ""
            txt_expiry_date.Text = ""
        End If
    End Sub

    Private Sub set_encryption()
        If rad_encryption_flag_y.Checked = True Then
            cbo_cryptography_type.Enabled = True
            cbo_encryption_algorithm.Enabled = True
            cbo_key_length.Enabled = True
            txt_encryption_key.Enabled = True

        Else
            cbo_cryptography_type.Enabled = False
            cbo_encryption_algorithm.Enabled = False
            cbo_key_length.Enabled = False
            txt_encryption_key.Enabled = False

            cbo_cryptography_type.Text = ""
            cbo_encryption_algorithm.Text = ""
            cbo_key_length.Text = ""
            txt_encryption_key.Text = ""

        End If
    End Sub

    Private Sub SetCheckSum()
        'cbo_checksum_algorithm
        If rad_checksum_flag_y.Checked = True Then
            cbo_checksum_algorithm.Enabled = True
        Else
            cbo_checksum_algorithm.Enabled = False
            cbo_checksum_algorithm.Text = ""

        End If
    End Sub
End Class