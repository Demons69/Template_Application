Public Class Frm_BaseRate_List

    Dim conn As New CSQL
    Private Const strALL = "--------ALL--------"

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub Frm_BaseRate_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetGrid()
    End Sub

    Private Sub SetGrid()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""


            strCrit = ""

            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            strSQL += vbCrLf & "  BASE_RATE_CODE            as [Base Rates] "
            strSQL += vbCrLf & "  ,BASE_RATE_DESCRIPTION    as [Description] "
            strSQL += vbCrLf & "  ,BASE_RATE                as [Base Rate] "
            strSQL += vbCrLf & "  ,VALID_FLAG               as [Valid Flag] "

            strSQL += vbCrLf & "  from dbo.BASE_RATES_MST "
            ' strSQL += vbCrLf & " where VALID_FLAG='Y'  "
            strSQL += vbCrLf & " order by BASE_RATE_CODE "

            Call conn.SetGrid(strSQL, grd_Template)

            For i = 0 To grd_Template.Columns.Count - 1
                grd_Template.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

            If grd_Template.RowCount > 0 Then
                grd_Template.Rows.Item(0).Selected = True
                txt_Template.Text = grd_Template.CurrentRow.Cells(0).Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub grd_Template_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_Template.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txt_Template.Text = grd_Template.CurrentRow.Cells(0).Value

            If txt_Template.Text <> "" Then
                btn_Edit.Enabled = True
                btn_Print.Enabled = True
            End If

        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        Call AddData()
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Call EditData()
    End Sub

    Private Sub AddData()
        Dim mFrm_Frm_BaseRate_Entry As New Frm_BaseRate_Entry
        mFrm_Frm_BaseRate_Entry.strID = ""
        mFrm_Frm_BaseRate_Entry.strMODE = "ADD"
        mFrm_Frm_BaseRate_Entry.ShowDialog()
        Call SetGrid()
    End Sub

    Private Sub EditData()
        If txt_Template.Text = "" Then Exit Sub
        Dim mFrm_Frm_BaseRate_Entry As New Frm_BaseRate_Entry
        mFrm_Frm_BaseRate_Entry.strID = txt_Template.Text
        mFrm_Frm_BaseRate_Entry.strMODE = "EDIT"
        mFrm_Frm_BaseRate_Entry.ShowDialog()
        Call SetGrid()
    End Sub


    Private Sub btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Print.Click

        If txt_Template.Text = "" Then
            MsgBox("Invalid Base rate code")
            Exit Sub
        End If

        Dim FrmReport As New FrmReport
        FrmReport.ReportType = "BASE_RATES_MST"
        FrmReport.SQL = ""
        FrmReport.SQL += "   SELECT  * FROM dbo.BASE_RATES_MST where  BASE_RATE_CODE='" & txt_Template.Text.Replace("'", "''") & "'"
        FrmReport.strLine(0) = txt_Deal_ID.Text
        FrmReport.ShowDialog()

    End Sub

 


    Private Sub grd_Template_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_Template.CellContentClick

    End Sub
End Class