
Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_DealSummary_FeeCharging_Select

    Dim conn As New CSQL

    Public txtRef As TextBox

    Private Sub Frm_DealSummary_FeeCharging_Select_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetGrid()
    End Sub

    Private Sub SetGrid()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""


            strCrit = ""

            If txt_product_id.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [product_id] LIKE '%" & txt_product_id.Text & "%'"
            End If
            If txt_product_description.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [product_description] LIKE '%" & txt_product_description.Text & "%'"
            End If
            If txt_account_no.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [gl_account] LIKE '%" & txt_account_no.Text & "%'"
            End If

            strSQL = ""

            strSQL += vbCrLf & "  SELECT "
            strSQL += vbCrLf & "        product_id as [Product ID]"
            strSQL += vbCrLf & "        ,product_description as [Product Description]"
            ' strSQL += vbCrLf & "        ,[GL Branch]"
            strSQL += vbCrLf & "        ,gl_account as [GL Account]"
            ' strSQL += vbCrLf & "        ,[KBank Product Code]"
            strSQL += vbCrLf & "        ,charge_amt as [Charge Amt]"
            strSQL += vbCrLf & "        ,charge_frequency as [Charge Frequency]"
            strSQL += vbCrLf & "        ,charge_type as [Charge Type]"
            strSQL += vbCrLf & "        ,deduct_condition as [Deduct Condition]"
            ' strSQL += vbCrLf & "        ,working_day_condition_date as [Working Day]"
            ' strSQL += vbCrLf & "        ,[Working Day Condition]"
            strSQL += vbCrLf & "    FROM [dbo].[TB_FEE_MST]"
            strSQL += vbCrLf & strCrit

            strSQL += vbCrLf & "  order by  product_id "


            Call conn.SetGrid(strSQL, grd_list)

            For i = 0 To grd_list.Columns.Count - 1
                grd_list.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

            If grd_list.RowCount > 0 Then
                grd_list.Rows.Item(0).Selected = True
                txt_ID_Selected.Text = grd_list.CurrentRow.Cells(0).Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Find.Click
        Call SetGrid()
    End Sub

    Private Sub btn_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub

    Private Sub grd_list_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_list.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txt_ID_Selected.Text = grd_list.CurrentRow.Cells(0).Value
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    
    Private Sub grd_list_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_list.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txt_ID_Selected.Text = grd_list.CurrentRow.Cells(0).Value
            If txt_ID_Selected.Text = "" Then Exit Sub
            txtRef.Text = txt_ID_Selected.Text
            Me.Close()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub btn_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Select.Click
        If txt_ID_Selected.Text = "" Then Exit Sub
        txt_ID_Selected.Text = grd_list.CurrentRow.Cells(0).Value
        If txt_ID_Selected.Text = "" Then Exit Sub
        txtRef.Text = txt_ID_Selected.Text
        Me.Close()
    End Sub


End Class