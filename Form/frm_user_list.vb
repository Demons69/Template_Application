Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class frm_user_list

    Dim conn As New CSQL


    Private Sub frm_user_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetGrid()
    End Sub

    Private Sub btn_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Find.Click
        Call SetGrid()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub SetGrid()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""


            strCrit = ""

            If txt_userid.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [userid] LIKE '%" & txt_userid.Text & "%'"
            End If
            If txt_username.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [username] LIKE '%" & txt_username.Text & "%'"
            End If
       
            strSQL = ""

            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            strSQL += vbCrLf & "  a.userid as [User ID] "
            strSQL += vbCrLf & "   ,a.username as [User Name] "
            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & " TB_USER a "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " ORDER BY   a.userid "



            Call conn.SetGrid(strSQL, grd_list)

            For i = 0 To grd_list.Columns.Count - 1
                grd_list.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

            If grd_list.RowCount > 0 Then
                grd_list.Rows.Item(0).Selected = True
                ' txt_Template.Text = grd_Template.CurrentRow.Cells(0).Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        Dim mfrm_user_entry As New frm_user_entry
        mfrm_user_entry.strID = ""
        mfrm_user_entry.strMODE = "ADD"
        mfrm_user_entry.ShowDialog()
        Call SetGrid()
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Call Editdata()
    End Sub

    Private Sub Editdata()
        If grd_list.RowCount <= 0 Then Exit Sub

        If grd_list.CurrentRow.Cells(0).Value <> "" Then
            Dim mfrm_user_entry As New frm_user_entry
            mfrm_user_entry.strID = grd_list.CurrentRow.Cells(0).Value
            mfrm_user_entry.strMODE = "EDIT"
            mfrm_user_entry.ShowDialog()
            Call SetGrid()
        End If
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If grd_list.RowCount <= 0 Then Exit Sub

        If grd_list.CurrentRow.Cells(0).Value <> "" Then

            If MsgBox("Do you want to delete.", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
                Dim strSQL As String = "delete from [TB_USER] where userid='" & grd_list.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") & "'"

                strSQL += vbCrLf & " delete from TB_USER_PERMISSION WHERE [userid] ='" + txt_userid.Text.Replace("''", "'") + "'  "

                conn.ExecuteNonQuery(strSQL)
                Call SetGrid()
            End If


        End If
    End Sub



    Private Sub grd_list_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_list.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            Call Editdata()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

End Class