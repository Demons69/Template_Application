
Imports Template_Application.CSQL
Imports System.Data.SqlClient


Public Class XXXX_Frm_DealSummary_User_Category

    Public strID As String = ""
    Public strMODE As String = "ADD"
    Private Const strALL = "--------Select--------"
    Dim conn As CSQL

    Private Sub Frm_DealSummary_User_Category_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub Frm_DealSummary_User_Category_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        conn = New CSQL
        conn.Connect()
        Dim strSQL As String = ""
        If strMODE.ToUpper <> "ADD" Then
            Call ShowData()
        End If

    End Sub

    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_DEAL_UMM_USER] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and user_id='" + txt_user_id.Text.Replace("'", "''") + "' "
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()
            ' txt_account_number.Enabled = False
            txt_Template_User_Group_ID.Text = IIf(res("Template_User_Group_ID") Is System.DBNull.Value, "", res("Template_User_Group_ID").ToString())
            txt_User_Category_ID.Text = IIf(res("User_Category_ID") Is System.DBNull.Value, "", res("User_Category_ID").ToString())
            txt_firstname.Text = IIf(res("firstname") Is System.DBNull.Value, "", res("firstname").ToString())
            txt_lastname.Text = IIf(res("lastname") Is System.DBNull.Value, "", res("lastname").ToString())
            txt_Report_Category_ID.Text = IIf(res("Report_Category_ID") Is System.DBNull.Value, "", res("Report_Category_ID").ToString())
            txt_User_Category_Name.Text = IIf(res("User_Category_Name") Is System.DBNull.Value, "", res("User_Category_Name").ToString())
            txt_Report_Category_Name.Text = IIf(res("Report_Category_Name") Is System.DBNull.Value, "", res("Report_Category_Name").ToString())

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

        If txt_User_Category_ID.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [User Category ID]"
        End If
        If txt_Report_Category_ID.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Report Category ID]"
        End If
        If txt_User_Category_Name.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [User Category Name]"
        End If
        If txt_Report_Category_Name.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Report Category Name]"
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
                'strSQL = "SELECT * FROM [TB_DEAL_ACCOUNT] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and account_number='" + txt_account_number.Text.Replace("'", "''") + "' "
                'If conn.HasRows(strSQL) = True Then
                '    MessageBox.Show("Invalid [Account] is duplicate.")
                '    Exit Sub
                'End If

                'Dim strValue As String = ""
                'Dim strFiledname As String = ""

                'strFiledname += vbCrLf & "[account_number]"
                'strValue += vbCrLf & "N'" & txt_account_number.Text.Replace("'", "''") & "'"



                'strSQL = ""
                'strSQL += vbCrLf & "insert into [TB_DEAL_UMM_USER]  "
                'strSQL += vbCrLf & "(" & strFiledname & ")"
                'strSQL += vbCrLf & " VALUES (" & strValue & ")"

                'conn.ExecuteNonQuery(strSQL)
                'Me.Close()

            End If ' If strMODE.ToUpper = "ADD" Then
            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [TB_DEAL_UMM_USER] set "

                strSQL += vbCrLf & "[User_Category_ID]"
                strSQL += vbCrLf & "=N'" & txt_User_Category_ID.Text.Replace("'", "''") & "'"

                strSQL += ",[Report_Category_ID]"
                strSQL += vbCrLf & "=N'" & (txt_Report_Category_ID.Text.Replace("''", "'")) & "'"

                strSQL += ",[User_Category_Name]"
                strSQL += vbCrLf & "=N'" & (txt_User_Category_Name.Text.Replace("''", "'")) & "'"

                strSQL += ",[Report_Category_Name]"
                strSQL += vbCrLf & "=N'" & (txt_Report_Category_Name.Text.Replace("''", "'")) & "'"



                strSQL += vbCrLf & " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'  and user_id='" + txt_user_id.Text.Replace("'", "''") + "' "
                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper <> "ADD" Then

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class