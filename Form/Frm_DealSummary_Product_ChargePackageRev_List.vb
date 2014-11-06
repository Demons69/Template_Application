Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_DealSummary_Product_ChargePackageRev_List

    Dim conn As New CSQL

    Private Sub Frm_DealSummary_Product_ChargePackageRev_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Call SetGrid()
    End Sub

    Private Sub SetGrid()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""


            strCrit = ""

            If txt_company_id.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [company_id] = '" & txt_company_id.Text & "'"
            End If
            'txt_my_product
            If txt_company_id.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [my_product] = '" & txt_my_product.Text & "'"
            End If

            strSQL = ""

            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            strSQL += vbCrLf & "  charge_template as [Charge Template] "
            strSQL += vbCrLf & "   , right(day(start_date) + 10000,2) + '/' + right(month(start_date) + 10000,2) + '/' + right(year(start_date) + 10000,4)   as [Start Date] "
            strSQL += vbCrLf & "  , right(day(end_date) + 10000,2) + '/' + right(month(end_date) + 10000,2) + '/' + right(year(end_date) + 10000,4)   as [End Date]"
            strSQL += vbCrLf & "  ,seq as [Seq]"
            'seq
            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & " TB_DEAL_PRODUCT_CHARGE_PACKAGE a "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " ORDER BY  charge_template "



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

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub

    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click

        Dim mFrm_DealSummary_Product_ChargePackageRev_Edit As New Frm_DealSummary_Product_ChargePackageRev_Edit
        mFrm_DealSummary_Product_ChargePackageRev_Edit.strMODE = "ADD"
        mFrm_DealSummary_Product_ChargePackageRev_Edit.txt_my_product.Text = txt_my_product.Text
        mFrm_DealSummary_Product_ChargePackageRev_Edit.txt_revision_code.Text = txt_revision_code.Text
        mFrm_DealSummary_Product_ChargePackageRev_Edit.txt_revision_desc.Text = txt_revision_desc.Text
        mFrm_DealSummary_Product_ChargePackageRev_Edit.txt_company_id.Text = txt_company_id.Text

        mFrm_DealSummary_Product_ChargePackageRev_Edit.ShowDialog()
        Call SetGrid()

    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
    
        Call EditData()

    End Sub

    Private Sub EditData()
        If grd_list.RowCount <= 0 Then Exit Sub

        If grd_list.CurrentRow.Cells(0).Value <> "" Then
            Dim mFrm_DealSummary_Product_ChargePackageRev_Edit As New Frm_DealSummary_Product_ChargePackageRev_Edit
            mFrm_DealSummary_Product_ChargePackageRev_Edit.txt_seq.Text = grd_list.CurrentRow.Cells(3).Value
            mFrm_DealSummary_Product_ChargePackageRev_Edit.strMODE = "EDIT"

            mFrm_DealSummary_Product_ChargePackageRev_Edit.txt_my_product.Text = txt_my_product.Text
            mFrm_DealSummary_Product_ChargePackageRev_Edit.txt_revision_code.Text = txt_revision_code.Text
            mFrm_DealSummary_Product_ChargePackageRev_Edit.txt_revision_desc.Text = txt_revision_desc.Text
            mFrm_DealSummary_Product_ChargePackageRev_Edit.txt_company_id.Text = txt_company_id.Text

            mFrm_DealSummary_Product_ChargePackageRev_Edit.ShowDialog()
            Call SetGrid()
        End If
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If grd_list.RowCount <= 0 Then Exit Sub

        If grd_list.CurrentRow.Cells(0).Value <> "" Then

            If MsgBox("Do you want to delete.", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
                Dim strSQL As String = "delete from [TB_DEAL_PRODUCT_CHARGE_PACKAGE] where seq=" & grd_list.CurrentRow.Cells(3).Value.ToString.Replace("'", "''") & " and my_product='" & txt_my_product.Text.Replace("'", "''") & "'"
                conn.ExecuteNonQuery(strSQL)
                Call SetGrid()
            End If
        End If

    End Sub


    Private Sub grd_list_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_list.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            Call EditData()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

End Class