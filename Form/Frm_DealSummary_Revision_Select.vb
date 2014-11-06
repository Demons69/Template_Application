Public Class Frm_DealSummary_Revision_Select

    Dim conn As New CSQL
    Public txtCode As TextBox
    Public txtDesc As TextBox

    Private Sub Frm_DealSummary_Revision_Select_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub
   
    Private Sub Frm_DealSummary_Revision_Select_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New CSQL
        conn.Connect()
        Call SetGrid()
    End Sub

    Private Sub SetGrid()
        Dim strSQL As String = ""

        Try

            strSQL = "EXEC [SP_ap_GetRevisionCode]"

            Call conn.SetGrid(strSQL, grd_data)
            Dim i As Integer
            For i = 0 To grd_data.ColumnCount - 1
                grd_data.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

            If grd_data.RowCount > 0 Then
                ' grd_data.Columns(1).Width = 350
                'grd_data.Columns(2).Width = 100
                grd_data.Rows.Item(0).Selected = True
                ' txt_Company_ID_Selected.Text = grd_data.CurrentRow.Cells(0).Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub grd_data_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_data.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txtCode.Text = grd_data.CurrentRow.Cells(1).Value
            txtDesc.Text = grd_data.CurrentRow.Cells(0).Value

        Catch ex As Exception
            Exit Sub
        End Try
    End Sub


    Private Sub grd_data_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_data.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txtCode.Text = grd_data.CurrentRow.Cells(1).Value
            txtDesc.Text = grd_data.CurrentRow.Cells(0).Value
            
            Me.Close()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    
    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        txtCode.Text = ""
        txtDesc.Text = ""
        Me.Close()
    End Sub

    Private Sub btn_Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Submit.Click

        If txtCode.Text <> "" Then Me.Close()
    End Sub

    
End Class