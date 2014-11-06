Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_BaseRate_Entry
    Public strID As String = ""
    Public strMODE As String = "ADD"
    Private Const strALL = "--------Select--------"
    Dim conn As CSQL

    Private Sub Frm_BaseRate_Entry_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Me.Close()
    End Sub

    Private Sub Frm_BaseRate_Entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        strSQL = "SELECT * FROM [BASE_RATES_MST] WHERE [BASE_RATE_CODE] ='" + strID + "'"
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()
            txt_BASE_RATE_CODE.Enabled = False
            txt_BASE_RATE_CODE.Text = IIf(res("BASE_RATE_CODE") Is System.DBNull.Value, "", res("BASE_RATE_CODE").ToString())
            txt_BASE_RATE_DESCRIPTION.Text = IIf(res("BASE_RATE_DESCRIPTION") Is System.DBNull.Value, "", res("BASE_RATE_DESCRIPTION").ToString())
            txt_BASE_RATE.Text = IIf(res("BASE_RATE") Is System.DBNull.Value, "", res("BASE_RATE").ToString())


            If IIf(res("VALID_FLAG") Is System.DBNull.Value, "", res("VALID_FLAG").ToString()) = "Y" Then
                rad_StatusTemplate_Y.Checked = True
            Else
                rad_StatusTemplate_N.Checked = True
            End If


        End If
        res.Close()
        res = Nothing

    End Sub


    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""

        If txt_BASE_RATE_CODE.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Base Rates]"
        End If

        If txt_BASE_RATE_DESCRIPTION.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Description]"
        End If

        If txt_BASE_RATE.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Base Rate]"
        Else
            If IsNumeric(txt_BASE_RATE.Text) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Base Rate]"
            End If
        End If

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
        Try


            conn = New CSQL
            conn.Connect()
            Dim strSQL As String = ""
            '========================add mode====================
            If strMODE.ToUpper = "ADD" Then
                strSQL = "SELECT * FROM [BASE_RATES_MST] WHERE [BASE_RATE_CODE] ='" + txt_BASE_RATE_CODE.Text.Replace("'", "''") + "'"
                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid [Base Rates] is duplicate.")
                    Exit Sub
                End If

                Dim strValue As String = ""
                Dim strFiledname As String = ""

                strFiledname += vbCrLf & "[BASE_RATE_CODE]"
                strValue += vbCrLf & "'" & txt_BASE_RATE_CODE.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[BASE_RATE_DESCRIPTION]"
                strValue += vbCrLf & ",'" & txt_BASE_RATE_DESCRIPTION.Text.Replace("'", "''") & "'"


                strFiledname += ",[BASE_RATE]"
                strValue += vbCrLf & ",'" & CDbl(txt_BASE_RATE.Text.Replace("''", "'")) & "'"

                strFiledname += vbCrLf & ",[VALID_FLAG]"

                If rad_StatusTemplate_Y.Checked Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If

                strSQL = ""
                strSQL += vbCrLf & "insert into [BASE_RATES_MST]"
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper = "ADD" Then
            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [BASE_RATES_MST] set "

                'strSQL += vbCrLf & "[BASE_RATE_CODE]"
                'strSQL += vbCrLf & "'" & txt_BASE_RATE_CODE.Text.Replace("'", "''")& "'"

                strSQL += vbCrLf & "[BASE_RATE_DESCRIPTION]"
                strSQL += vbCrLf & "='" & txt_BASE_RATE_DESCRIPTION.Text.Replace("'", "''") & "'"

                strSQL += ",[BASE_RATE]"
                strSQL += vbCrLf & " = '" & CDbl(txt_BASE_RATE.Text.Replace("''", "'")) & "'"

                strSQL += vbCrLf & ",[VALID_FLAG]"
                If rad_StatusTemplate_Y.Checked Then
                    strSQL += vbCrLf & "='Y'"
                Else
                    strSQL += vbCrLf & "='N'"
                End If

                strSQL += vbCrLf & " WHERE [BASE_RATE_CODE] ='" + txt_BASE_RATE_CODE.Text.Replace("'", "''") + "'"
                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper <> "ADD" Then

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class