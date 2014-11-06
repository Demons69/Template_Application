Imports Template_Application.CSQL
Imports System.Data.SqlClient


Public Class frm_user_entry
    Dim conn As CSQL

    Public strID As String = ""
    Public strMODE As String = "ADD"

    Private Sub frm_user_entry_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub frm_user_entry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frm_user_entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            conn = New CSQL
            conn.Connect()

            Dim strSQL As String = ""
            strSQL = " SELECT menu_id + '-' + menu_name from dbo.TB_USER_MENU_MST order by menu_group,menu_id "
            conn.Fill_ComboBox(strSQL, lst_permision)


            strSQL = " SELECT task_id  + '-' + task_name from dbo.TB_TRACKING_MST_TASK order by task_id,task_name "
            conn.Fill_ComboBox(strSQL, lst_permision_tracking)

            'cbo_default_charge_account
            'If strMODE.ToUpper = "ADD" Then

            '    For i = 0 To lst_permision.Items.Count - 1
            '        lst_permision.SetItemChecked(i, True)
            '    Next
            'End If

            If strMODE.ToUpper <> "ADD" Then
                Call ShowData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_USER] WHERE [userid] ='" + strID + "'"
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()

            txt_userid.Text = IIf(res("userid") Is System.DBNull.Value, "", res("userid").ToString())
            txt_userid.Enabled = True

            txt_username.Text = IIf(res("username") Is System.DBNull.Value, "", res("username").ToString())
            txt_pwd.Text = IIf(res("pwd") Is System.DBNull.Value, "", res("pwd").ToString())

            txt_userid.Enabled = False
            Call Show_Permission()
            Call Show_Permission_tracking()
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

        If txt_userid.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [User ID]"
        End If

        If txt_username.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [User Name]"
        End If

        If txt_pwd.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Password]"
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
                strSQL = "SELECT * FROM [TB_USER] WHERE [userid] ='" + txt_userid.Text.Replace("'", "''") + "'"
                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid User ID is duplicate.")
                    Exit Sub
                End If

                Dim strValue As String = ""
                Dim strFiledname As String = ""

                strFiledname += vbCrLf & "  [userid]"
                strValue += vbCrLf & "'" & txt_userid.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & "  ,[username]"
                strValue += vbCrLf & ",'" & txt_username.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & "  ,[pwd]"
                strValue += vbCrLf & ",'" & txt_pwd.Text.Replace("'", "''") & "'"


                strSQL = ""
                strSQL += vbCrLf & "insert into [TB_USER]"
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                conn.ExecuteNonQuery(strSQL)
                '  Me.Close()

            End If ' If strMODE.ToUpper = "ADD" Then
            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [TB_USER] set "
                strSQL += vbCrLf & "  [userid]"
                strSQL += vbCrLf & "='" & txt_userid.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & "  ,[username]"
                strSQL += vbCrLf & "= '" & txt_username.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & "  ,[pwd]"
                strSQL += vbCrLf & " = '" & txt_pwd.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & " WHERE [userid] ='" + txt_userid.Text.Replace("'", "''") + "'"
                conn.ExecuteNonQuery(strSQL)
                '  Me.Close()

            End If ' If strMODE.ToUpper <> "ADD" Then



            '==================account==============
            Dim i_permision As Integer = 0

            strSQL = ""
            strSQL += vbCrLf & " delete from TB_USER_PERMISSION WHERE [userid] ='" + txt_userid.Text.Replace("''", "'") + "'  "

            For Each Entry In lst_permision.CheckedItems
                ' MessageBox.Show(lst_account.ToString())

                Dim vnt As Object
                vnt = Split(Entry.ToString, "-")

                strSQL += vbCrLf & "insert into TB_USER_PERMISSION ( userid,[menu_id] ) values ( "
                strSQL += vbCrLf & "'" + txt_userid.Text.Replace("''", "'") + "' " 'company_id
                strSQL += vbCrLf & " , '" + RTrim(LTrim(vnt(0))) + "' " 'user_id
                strSQL += vbCrLf & " ) "

                i_permision += 1
            Next
            conn.ExecuteNonQuery(strSQL)

            '=============
            Dim i_permision_tracking As Integer = 0

            strSQL = ""
            strSQL += vbCrLf & " delete from TB_TRACKING_MST_TASK_USER_PERMISION WHERE [userid] ='" + txt_userid.Text.Replace("''", "'") + "'  "

            For Each Entry In lst_permision_tracking.CheckedItems
                ' MessageBox.Show(lst_account.ToString())

                Dim vnt As Object
                vnt = Split(Entry.ToString, "-")

                strSQL += vbCrLf & "insert into TB_TRACKING_MST_TASK_USER_PERMISION ( userid,[task_id] ) values ( "
                strSQL += vbCrLf & "'" + txt_userid.Text.Replace("''", "'") + "' " 'company_id
                strSQL += vbCrLf & " , '" + RTrim(LTrim(vnt(0))) + "' " 'user_id
                strSQL += vbCrLf & " ) "

                i_permision_tracking += 1
            Next
            conn.ExecuteNonQuery(strSQL)


            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Show_Permission()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_USER_PERMISSION] WHERE [userid] ='" + txt_userid.Text.Replace("'", "''") + "'   "
        res = conn.GetDataReader(strSQL)
        If res.HasRows = True Then
            While (res.Read())
                Dim i As Integer = 0
                For i = 0 To lst_permision.Items.Count - 1
                    'lst_account.Items(i).ToString 
                    If lst_permision.Items(i).ToString.Substring(0, res("menu_id").ToString.Length) = res("menu_id").ToString Then
                        lst_permision.SetItemChecked(i, True)
                    End If
                Next

            End While
        End If
    End Sub

    Private Sub Show_Permission_tracking()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_TRACKING_MST_TASK_USER_PERMISION] WHERE [userid] ='" + txt_userid.Text.Replace("'", "''") + "'   "
        res = conn.GetDataReader(strSQL)
        If res.HasRows = True Then
            While (res.Read())
                Dim i As Integer = 0
                For i = 0 To lst_permision_tracking.Items.Count - 1
                    'lst_account.Items(i).ToString 
                    If lst_permision_tracking.Items(i).ToString.Substring(0, res("task_id").ToString.Length) = res("task_id").ToString Then
                        lst_permision_tracking.SetItemChecked(i, True)
                    End If
                Next

            End While
        End If
    End Sub



    Private Sub btn_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_all.Click
        Dim i As Integer
        For i = 0 To lst_permision.Items.Count - 1
            lst_permision.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        Dim i As Integer
        For i = 0 To lst_permision.Items.Count - 1
            lst_permision.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub btn_all_tracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_all_tracking.Click
        Dim i As Integer
        For i = 0 To lst_permision_tracking.Items.Count - 1
            lst_permision_tracking.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub btn_clear_tracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear_tracking.Click
        Dim i As Integer
        For i = 0 To lst_permision_tracking.Items.Count - 1
            lst_permision_tracking.SetItemChecked(i, False)
        Next
    End Sub

End Class