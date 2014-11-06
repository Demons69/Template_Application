Imports System.Data.SqlClient
Imports Template_Application.CSQL


Public Class LoginForm
    Public txt_userid As TextBox
    Dim conn As New CSQL
    Dim iCount As Integer = 0


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text = "" Then
            MsgBox("Invalid User")
            Exit Sub
        End If
        If PasswordTextBox.Text = "" Then
            MsgBox("Invalid Password")
            Exit Sub
        End If

        Dim strSQL As String = ""
        strSQL += " select * from TB_USER"
        strSQL += vbCrLf & " where "
        strSQL += vbCrLf & " userid='" & UsernameTextBox.Text.Replace("'", "''") & "' "
        strSQL += vbCrLf & " and pwd='" & PasswordTextBox.Text.Replace("'", "''") & "' "

        Dim vnt As String = conn.GetDataFromSQL(strSQL)
        If vnt <> "" Then
            UsernameTextBox.Text = vnt
            txt_userid.Text = UsernameTextBox.Text
            Me.Close()
        Else
            MsgBox("Invalid user/pwd")
            iCount += 1
            If iCount = 3 Then
                MsgBox("You are login more than three times.")
                Me.Close()
            Else
                MsgBox("Invalid user/pwd")
            End If
        End If



    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        txt_userid.Text = ""
        Me.Close()
    End Sub

    Private Sub LoginForm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

    End Sub
End Class
