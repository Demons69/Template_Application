
Public Class Frm_RestoreData
    Dim conn As New CSQL

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub Frm_RestoreData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim strSQL As String = ""
            strSQL = ""
            strSQL += vbCrLf + " select"
            strSQL += vbCrLf + " #grp.VersionNumber"
            strSQL += vbCrLf + " ,#grp.VersionDate "
            strSQL += vbCrLf + " ,(select COUNT(*) from dbo.History_Template a where a.VersionNumber=#grp.VersionNumber) as [Count of Template]"
            strSQL += vbCrLf + " ,(select COUNT(*) from dbo.History_TemplateProduct a where a.VersionNumber=#grp.VersionNumber) as [Count of Product]"
            strSQL += vbCrLf + " ,(select COUNT(*) from dbo.History_TemplateChargeEvents a where a.VersionNumber=#grp.VersionNumber) as [Count of Event]"
            strSQL += vbCrLf + " ,(select COUNT(*) from dbo.History_TemplateChargeUnits a where a.VersionNumber=#grp.VersionNumber) as [Count of Unit]"

            strSQL += vbCrLf + " from "
            strSQL += vbCrLf + " ("
            strSQL += vbCrLf + " select "
            strSQL += vbCrLf + " VersionNumber,VersionDate"
            strSQL += vbCrLf + " from History_Template"
            strSQL += vbCrLf + " group by VersionNumber,VersionDate"
            strSQL += vbCrLf + " ) #grp"
            strSQL += vbCrLf + " order by #grp.VersionNumber,#grp.VersionDate "

            conn.SetGrid(strSQL, grd_Template)
            Dim i As Integer
            For i = 0 To grd_Template.Columns.Count - 1
                grd_Template.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

            grd_Template.Columns("Count of Template").DefaultCellStyle.Format = "###,###0"
            grd_Template.Columns("Count of Template").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grd_Template.Columns("Count of Product").DefaultCellStyle.Format = "###,###0"
            grd_Template.Columns("Count of Product").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            grd_Template.Columns("Count of Event").DefaultCellStyle.Format = "###,###0"
            grd_Template.Columns("Count of Event").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            grd_Template.Columns("Count of Unit").DefaultCellStyle.Format = "###,###0"
            grd_Template.Columns("Count of Unit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            'If grd_Template.CurrentRow.Cells(0).Value <> "" Then Exit Sub
            'Try
            '    txt_version.Text = grd_Template.CurrentRow.Cells(0).Value
            'Catch ex As Exception
            '    Exit Sub
            'End Try

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

  

    Private Sub grd_Template_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd_Template.CellMouseClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txt_version.Text = grd_Template.CurrentRow.Cells(0).Value
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

 
    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click
        If txt_version.Text = "" Then MessageBox.Show("Please select version.") : Exit Sub
        Dim strSQL As String = ""
        Try
            strSQL = "exec dbo.[SP_RestoreData]  " & CDbl(txt_version.Text)
            conn.ExecuteNonQuery(strSQL)
            MessageBox.Show("Restore data was successful.")

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
End Class