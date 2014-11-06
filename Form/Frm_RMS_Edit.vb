Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_RMS_Edit
    Dim conn As CSQL

    Public strID As String = ""
    Public strMODE As String = "ADD"

    Private Sub Frm_RMS_Edit_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub Frm_RMS_Edit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FillComboALL()

        cbo_product_name.Items.Clear()
        cbo_product_name.Items.Add("Special Collection")
        cbo_product_name.Items.Add("")
        cbo_product_name.Text = "Special Collection"

        'cbo_delivery_channel
        cbo_delivery_channel.Items.Clear()
        cbo_delivery_channel.Items.Add("FTP Channel")
        cbo_delivery_channel.Items.Add("")
        cbo_delivery_channel.Text = "FTP Channel"

        Dim strSQL As String = ""

        'cbo_account_no
        strSQL = " SELECT account_number from dbo.TB_DEAL_ACCOUNT where company_id ='" & txt_company_id.Text.Replace("'", "''") & "' and sq='Y' order by account_number "
        conn.Fill_ComboBox(strSQL, cbo_account_no)

    End Sub

    Private Sub Frm_RMS_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            conn = New CSQL
            conn.Connect()
            Dim strSQL As String = ""
          
            Call FillComboALL()

            If strMODE.ToUpper <> "ADD" Then
                Call ShowData()
                Call SetGrid_RMS()
            Else
                'Dim strSQL As String = ""
                strSQL = "SELECT isnull(max(seq),0) + 1 as seq FROM [TB_RMS_H] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
                txt_seq.Text = conn.GetDataFromSQL(strSQL)
                Call SetGrid_RMS()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_RMS_H] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "' and seq= " & txt_seq.Text
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()

            cbo_product_name.Text = IIf(res("product_name") Is System.DBNull.Value, "", res("product_name").ToString())
            cbo_account_no.Text = IIf(res("account_no") Is System.DBNull.Value, "", res("account_no").ToString())

            If IIf(res("enable") Is System.DBNull.Value, "", res("enable").ToString()) = "Y" Then
                rad_enable_y.Checked = True
            Else
                rad_enable_n.Checked = True
            End If

            If IIf(res("encryption") Is System.DBNull.Value, "", res("encryption").ToString()) = "Y" Then
                rad_encryption_y.Checked = True
            Else
                rad_encryption_n.Checked = True
            End If

            cbo_delivery_channel.Text = IIf(res("delivery_channel") Is System.DBNull.Value, "", res("delivery_channel").ToString())

            If IIf(res("delivery_method") Is System.DBNull.Value, "", res("delivery_method").ToString()) = rad_delivery_method_auto.Text Then
                rad_delivery_method_auto.Checked = True
            Else
                rad_delivery_method_manual.Checked = True
            End If

            txt_organizer_name.Text = IIf(res("organizer_name") Is System.DBNull.Value, "", res("organizer_name").ToString())

            If IIf(res("every_hour") Is System.DBNull.Value, "", res("every_hour").ToString()) = "Y" Then
                rad_every_hour_y.Checked = True
            Else
                rad_every_hour_n.Checked = True
            End If

        End If
        res.Close()
        res = Nothing

    End Sub

    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click
        Call SaveALL()
    End Sub

    Private Sub SaveALL(Optional ByVal IsShowMsg As Boolean = True)
        Dim strErr As String = ""
        strErr = ValidationData()
        If strErr <> "" Then
            MessageBox.Show(strErr)
            Exit Sub
        End If
        Call SaveData(IsShowMsg)
    End Sub

    Private Sub SaveData(Optional ByVal IsShowMSG As Boolean = True)
        Try


            conn = New CSQL
            conn.Connect()
            Dim strSQL As String = ""
            '========================add mode====================
            If strMODE.ToUpper = "ADD" Then
                strSQL = "SELECT * FROM [TB_RMS_H] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "' and seq= " & txt_seq.Text
                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid Seq is duplicate.")
                    Exit Sub
                End If

                Dim strValue As String = ""
                Dim strFiledname As String = ""


                strFiledname += vbCrLf & "[company_id]"
                strValue += vbCrLf & "N'" & txt_company_id.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[seq]"
                strValue += vbCrLf & "," & txt_seq.Text.Replace("'", "''")

                'cbo_product_name
                strFiledname += vbCrLf & ",[product_name]"
                strValue += vbCrLf & ",'" & cbo_product_name.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[account_no]"
                strValue += vbCrLf & ",N'" & cbo_account_no.Text.Replace("'", "''") & "'"


                strFiledname += ",[enable]"
                If rad_enable_y.Checked Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If

                strFiledname += ",[encryption]"
                If rad_encryption_y.Checked Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If

                strFiledname += vbCrLf & ",[delivery_channel]"
                strValue += vbCrLf & ",N'" & cbo_delivery_channel.Text.Replace("'", "''") & "'"

                strFiledname += ",[delivery_method]"
                If rad_delivery_method_auto.Checked Then
                    strValue += vbCrLf & ",'" & rad_delivery_method_auto.Text & "'"
                Else
                    strValue += vbCrLf & ",'" & rad_delivery_method_manual.Text & "'"
                End If

                strFiledname += vbCrLf & ",[organizer_name]"
                strValue += vbCrLf & ",N'" & txt_organizer_name.Text.Replace("'", "''") & "'"

                strFiledname += ",[every_hour]"
                If rad_every_hour_y.Checked Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If


                strSQL = ""
                strSQL += vbCrLf & "insert into [TB_RMS_H]"
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                conn.ExecuteNonQuery(strSQL)
                ' Me.Close()
                strMODE = "EDIT"
            End If ' If strMODE.ToUpper = "ADD" Then
            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [TB_RMS_H] set "


                strSQL += vbCrLf & "[product_name]"
                strSQL += vbCrLf & "='" & cbo_product_name.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[account_no]"
                strSQL += vbCrLf & "=N'" & cbo_account_no.Text.Replace("'", "''") & "'"


                strSQL += " ,[enable]"
                If rad_enable_y.Checked Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If

                strSQL += ",[encryption]"
                If rad_encryption_y.Checked Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If

                strSQL += vbCrLf & ",[delivery_channel]"
                strSQL += vbCrLf & "=N'" & cbo_delivery_channel.Text.Replace("'", "''") & "'"

                strSQL += ",[delivery_method]"
                If rad_delivery_method_auto.Checked Then
                    strSQL += vbCrLf & "='" & rad_delivery_method_auto.Text & "'"
                Else
                    strSQL += vbCrLf & "='" & rad_delivery_method_manual.Text & "'"
                End If

                strSQL += vbCrLf & ",[organizer_name]"
                strSQL += vbCrLf & "=N'" & txt_organizer_name.Text.Replace("'", "''") & "'"

                strSQL += ",[every_hour]"
                If rad_every_hour_y.Checked Then
                    strSQL += vbCrLf & "= 'Y'"
                Else
                    strSQL += vbCrLf & "= 'N'"
                End If


                strSQL += vbCrLf & " WHERE  [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
                strSQL += vbCrLf & " and seq= " & txt_seq.Text

                conn.ExecuteNonQuery(strSQL)
                ' Me.Close()

            End If ' If strMODE.ToUpper <> "ADD" Then


            '========revision

            If txt_revision_code.Text <> "" Then
                strSQL = ""
                strSQL += vbCrLf & "update [TB_RMS_H] set "
                ' strSQL += vbCrLf & "[gcp_service_end_date]"
                'strSQL += vbCrLf & "=" & get_date_sql(txt_gcp_service_end_date.Text) & ""
                strSQL += vbCrLf & "[revision_code]"
                strSQL += vbCrLf & "=N'" & txt_revision_code.Text.Replace("'", "''") & "'"
                strSQL += vbCrLf & ",[revision_desc]"
                strSQL += vbCrLf & "=N'" & txt_revision_desc.Text.Replace("'", "''") & "'"
                strSQL += vbCrLf & ",[revision_date]"
                strSQL += vbCrLf & "=getdate()"
                strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "' " ' and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "

                strSQL += vbCrLf & " DELETE FROM dbo.TB_REVISION_HISTORY WHERE company_id='" + txt_company_id.Text.Replace("'", "''") + "'"
                strSQL += vbCrLf & "   and revision_code in ('Rev0030') "

                strSQL += vbCrLf & " insert into  TB_REVISION_HISTORY (company_id,revision_code,revision_desc,revision_date)" ' values (
                'company_id,revision_code,revision_desc,revision_date,revision_reason
                strSQL += vbCrLf & " select distinct company_id,revision_code,revision_desc,revision_date from  TB_RMS_H "
                strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("''", "'") + "'  " 'and user_id='" + txt_user_id.Text.Replace("''", "'") + "' "
                strSQL += vbCrLf & "   and revision_code in ('Rev0030')"


           
                conn.ExecuteNonQuery(strSQL)

            End If

            If IsShowMSG = True Then

                MsgBox("SaveData was Successful. ")
                Me.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""


        If txt_seq.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Seq]"
        End If

        If cbo_product_name.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Product Name]"
        End If

        If cbo_account_no.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Account No]"
        End If

        If cbo_delivery_channel.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Delivery Channel]"
        End If

        If txt_organizer_name.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Organizer Name]"
        End If

        Return strErr
    End Function

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        If strMODE.ToUpper = "ADD" Then
            Call SaveALL(False)
        End If

        Dim mFrm_RMS_Edit_Detail As New Frm_RMS_Edit_Detail
        Frm_RMS_Edit_Detail.txt_company_id.Text = txt_company_id.Text
        Frm_RMS_Edit_Detail.txt_seq.Text = txt_seq.Text
        Frm_RMS_Edit_Detail.strMODE = "ADD"
        Frm_RMS_Edit_Detail.ShowDialog()
        Call SetGrid_RMS()
    End Sub



    Private Sub SetGrid_RMS()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""
            strCrit = ""

            '[company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
            If txt_company_id.Text <> "" And txt_seq.Text <> "" Then
                'strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " gl_account in ( select account_number from dbo.TB_DEAL_ACCOUNT where company_id=  '" & txt_company_id.Text & "'  )"
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & "  company_id=  '" & txt_company_id.Text & "'  and seq= " & txt_seq.Text
            Else
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " 1=0"
            End If


            strSQL = ""
            strSQL += vbCrLf & "  SELECT "
            strSQL += vbCrLf & "        report_name as [Report Name]"
            strSQL += vbCrLf & "        ,report_format as [Report Format]"
            strSQL += vbCrLf & "        ,format_text as [Format Text]"
            strSQL += vbCrLf & "        ,layout_flag as [Layout]"
            strSQL += vbCrLf & "    FROM [dbo].[TB_RMS_D]"
            strSQL += vbCrLf & strCrit

            strSQL += vbCrLf & "  order by [report_name]"

            Call conn.SetGrid(strSQL, grd_rms)
            If grd_rms.RowCount > 0 Then
                grd_rms.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                grd_rms.Rows.Item(0).Selected = True

            End If


        Catch ex As Exception
            '  MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub brn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brn_edit.Click
        If grd_rms.RowCount = 0 Then Exit Sub
        If strMODE.ToUpper = "ADD" Then
            Call SaveALL(False)
        End If

        Dim mFrm_RMS_Edit_Detail As New Frm_RMS_Edit_Detail
        Frm_RMS_Edit_Detail.txt_company_id.Text = txt_company_id.Text
        Frm_RMS_Edit_Detail.txt_seq.Text = txt_seq.Text
        Frm_RMS_Edit_Detail.cbo_report_name.Text = grd_rms.CurrentRow.Cells(0).Value
        Frm_RMS_Edit_Detail.strMODE = "EDIT"
        Frm_RMS_Edit_Detail.ShowDialog()
        Call SetGrid_RMS()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        If grd_rms.RowCount <= 0 Then Exit Sub

        If grd_rms.CurrentRow.Cells(0).Value <> "" Then

            If MsgBox("Do you want to delete.", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
                Dim strSQL As String = ""

                strSQL += vbCrLf & "delete from [TB_RMS_D] where company_id='" & txt_company_id.Text & "' and report_name='" & grd_rms.CurrentRow.Cells(0).Value & "'"
                '  strSQL += vbCrLf & "delete from [TB_RMS_H] where company_id='" & txt_company_id.Text & "'"

                conn.ExecuteNonQuery(strSQL)
                Call SetGrid_RMS()
            End If


        End If
    End Sub

    Private Sub btn_new_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_all.Click

        Try
            Dim strSQL As String = ""
            strSQL = ""
            strSQL += vbCrLf & "  delete from [TB_RMS_D] where"
            strSQL += vbCrLf & "  company_id='" & txt_company_id.Text.Replace("'", "''") & "' and seq=" & txt_seq.Text.Replace(",", "")

            strSQL += vbCrLf & " insert into [TB_RMS_D]"
            strSQL += vbCrLf & " ("
            strSQL += vbCrLf & " company_id"
            strSQL += vbCrLf & " ,seq"
            strSQL += vbCrLf & " ,seq_sub"
            strSQL += vbCrLf & " ,report_name"

            strSQL += vbCrLf & " ,report_format"
            strSQL += vbCrLf & " ,format_text"
            strSQL += vbCrLf & " ,layout_flag"


            strSQL += vbCrLf & " )"
            strSQL += vbCrLf & " SELECT    "
            strSQL += vbCrLf & " '" & txt_company_id.Text.Replace("'", "''") & "' as company_id"
            strSQL += vbCrLf & " ," & txt_seq.Text.Replace(",", "") & " as seq"
            strSQL += vbCrLf & " ,ROW_NUMBER() OVER(ORDER BY a.report_name ASC) AS seq_sub"
            strSQL += vbCrLf & " ,isnull(a.report_name,'')  as report_name"
            strSQL += vbCrLf & " ,isnull(a.report_format,'') as report_format"
            strSQL += vbCrLf & " ,isnull(a.format_text,'') as format_text"
            strSQL += vbCrLf & " ,isnull(a.layout_flag,'') as layout_flag"
            strSQL += vbCrLf & " FROM TB_CATAGORY_REPORT_MST  a"
            strSQL += vbCrLf & " WHERE     a.service_group = N'SQ' "
            strSQL += vbCrLf & " order by a.report_name"


            conn.ExecuteNonQuery(strSQL)

            Call SetGrid_RMS()

        Catch ex As Exception
            MsgBox(e.ToString)
        End Try
    End Sub

End Class