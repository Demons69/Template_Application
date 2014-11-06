Public Class Frm_DealSummary_List

    Dim conn As New CSQL
    Private Const strALL = "--------ALL--------"
    Public txtRef As TextBox
    Public Is_parent As Boolean = True

    Private Sub Frm_DealSummary_List_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub Frm_DealSummary_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New CSQL
        conn.Connect()
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub btn_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Find.Click
        Dim strCrit As String = ""

        Try

            If txt_company_id.Text <> "" And Len(txt_company_id.Text) >= 3 Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " ([company_id] LIKE '%" & _
                        txt_company_id.Text & "%' or company_id_parent LIKE '%" & txt_company_id.Text & "%' ) "
            End If

            If txt_client_code.Text <> "" And Len(txt_client_code.Text) >= 3 Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [client_code] LIKE '%" & txt_client_code.Text & "%'"
            End If

            If txt_companyname_en.Text <> "" And Len(txt_companyname_en.Text) >= 3 Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [companyname_en] LIKE '%" & txt_companyname_en.Text & "%'"
            End If
            If txt_companyname_th.Text <> "" And Len(txt_companyname_th.Text) >= 3 Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [companyname_th] LIKE '%" & txt_companyname_th.Text & "%'"
            End If
            If txt_tax_id.Text <> "" And Len(txt_tax_id.Text) >= 3 Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [tax_id] LIKE '%" & txt_tax_id.Text & "%'"
            End If

            If txt_Account.Text <> "" And Len(txt_Account.Text) >= 3 Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [company_id] in ( select company_id from TB_DEAL_ACCOUNT where account_number like '%" & txt_Account.Text & "%' OR account_number_charge LIKE '%" & txt_Account.Text & "%' OR account_number_credit LIKE '%" & txt_Account.Text & "%'  )"
            End If


            ''-- validate condition 
            If strCrit = "" Then
                'If MsgBox("No Criteria, Do you want to search data.", MsgBoxStyle.YesNo, "") = MsgBoxResult.No Then
                '    Exit Sub
                'End If
                MessageBox.Show("Please input criteria again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else

                Call SetGrid(strCrit)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub SetGrid(ByVal strCrit As String)
        Dim strSQL As String = ""
        Dim i As Integer

        strSQL += vbCrLf & " SELECT company_id as [Company Id] "
        strSQL += vbCrLf & " , client_code as [Client Code]"
        strSQL += vbCrLf & " , companyname_en as [Company Name(EN)]"
        strSQL += vbCrLf & " , companyname_th as [Company Name(TH)]"
        strSQL += vbCrLf & " , tax_id as [Corporate Registration ID / Tax Id]"
        strSQL += vbCrLf & " , company_id_parent as [Company Id Parernt]"

        strSQL += vbCrLf & " FROM "
        strSQL += vbCrLf & " dbo.TB_DEAL_UMM_COMPANY "
        strSQL += vbCrLf & strCrit
        strSQL += vbCrLf & " ORDER BY  company_id "

        Call conn.SetGrid(strSQL, grd_data)

        For i = 0 To grd_data.ColumnCount - 1
            grd_data.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        If grd_data.RowCount > 0 Then
            grd_data.Columns(2).Width = 350
            grd_data.Columns(3).Width = 350
            grd_data.Rows.Item(0).Selected = True
            txt_Company_ID_Selected.Text = grd_data.CurrentRow.Cells(0).Value
        End If

    End Sub

    Private Sub grd_data_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_data.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txt_Company_ID_Selected.Text = grd_data.CurrentRow.Cells(0).Value
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

   
    Private Sub grd_data_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_data.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txt_Company_ID_Selected.Text = grd_data.CurrentRow.Cells(0).Value
            If txt_Company_ID_Selected.Text = "" Then Exit Sub
            txtRef.Text = txt_Company_ID_Selected.Text
            Me.Close()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub btn_Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Submit.Click
        If txt_Company_ID_Selected.Text = "" Then Exit Sub
        txtRef.Text = txt_Company_ID_Selected.Text
        Me.Close()
        Me.Dispose()
    End Sub

  
    Private Sub grd_data_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_data.CellContentClick

    End Sub

End Class