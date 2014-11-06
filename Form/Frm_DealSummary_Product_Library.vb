Public Class Frm_DealSummary_Product_Library

    Dim conn As New CSQL
    Private Const strALL = "--------ALL--------"
    Public txtRef As TextBox
    Public Is_parent As Boolean = True

    Private Sub Frm_DealSummary_Product_Library_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub Frm_DealSummary_Product_Library_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New CSQL
        conn.Connect()

        cbo_bank_product.Items.Clear()
        cbo_bank_product.Items.Add("BNE")
        cbo_bank_product.Items.Add("COC")
        cbo_bank_product.Items.Add("COE")
        cbo_bank_product.Items.Add("DCT")
        cbo_bank_product.Items.Add("FTL")
        cbo_bank_product.Items.Add("FTR")
        cbo_bank_product.Items.Add("MCS")
        cbo_bank_product.Items.Add("MCL")
        cbo_bank_product.Items.Add("PCT")
        cbo_bank_product.Items.Add("PCL")
        cbo_bank_product.Items.Add("")

        Call SetGrid()
    End Sub


    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub btn_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Find.Click
        Call SetGrid()
    End Sub

    Private Sub SetGrid()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""


            strCrit = ""



            If txt_MYPRODUCT.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [MYPRODUCT] LIKE '%" & txt_MYPRODUCT.Text & "%'"
            End If
            If txt_MYPRODUCT_DESCRIPTION.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [MYPRODUCT_DESCRIPTION] LIKE '%" & txt_MYPRODUCT_DESCRIPTION.Text & "%'"
            End If
            If txt_MYPRODUCT_REMARK.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [MYPRODUCT_REMARK] LIKE '%" & txt_MYPRODUCT_REMARK.Text & "%'"
            End If
            If txt_UDEPRODUCT.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [UDEPRODUCT] LIKE '%" & txt_UDEPRODUCT.Text & "%'"
            End If
            If cbo_bank_product.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [PRODUCT_CODE] LIKE '%" & cbo_bank_product.Text & "%'"
            End If
            If txt_RULE_CODE.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [RULE_CODE] LIKE '%" & txt_RULE_CODE.Text & "%'"
            End If

            'If strCrit = "" Then
            '    If MsgBox("No Criteria, Do you want to search data.", MsgBoxStyle.YesNo, "") = MsgBoxResult.No Then
            '        Exit Sub
            '    End If
            'End If

  
            strSQL = ""
            strSQL += vbCrLf & " SELECT [MYPRODUCT] AS [My Product Code] "
            strSQL += vbCrLf & "  ,[MYPRODUCT_DESCRIPTION] AS [My Product Description] "
            strSQL += vbCrLf & "  ,[MYPRODUCT_REMARK] AS [My Product Remark]"
            strSQL += vbCrLf & "  ,[UDEPRODUCT] AS [UDE Product]"
            strSQL += vbCrLf & "  ,[PRODUCT_CODE] AS [Bank Product Code]"
            strSQL += vbCrLf & "  ,[PRODUCT_DESCRIPTION] AS [Bank Product Description]"
            strSQL += vbCrLf & "   ,[ARRANGEMENT_CODE] AS [Arrangement]"
            strSQL += vbCrLf & "  ,[PER_TXN_MAX_AMNT] AS [Per Txn Max Amt]"
            strSQL += vbCrLf & "  ,[RULE_PRIORITY] AS [Rule Priority]"
            strSQL += vbCrLf & "  ,[RULE_CODE] AS [Rule Code]"

            strSQL += vbCrLf & " FROM [dbo].[TB_BANK_PRODUCT_LIBRARY] "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " ORDER BY [MYPRODUCT],[UDEPRODUCT],[PRODUCT_CODE] "


            Call conn.SetGrid(strSQL, grd_data)
            Dim i As Integer
            For i = 0 To grd_data.ColumnCount - 1
                grd_data.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

            If grd_data.RowCount > 0 Then
                ' grd_data.Columns(2).Width = 350
                '  grd_data.Columns(3).Width = 350
                grd_data.Rows.Item(0).Selected = True
                txt_MYPRODUCT_Selected.Text = grd_data.CurrentRow.Cells(0).Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub grd_data_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_data.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txt_MYPRODUCT_Selected.Text = grd_data.CurrentRow.Cells(0).Value
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub grd_data_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_data.CellDoubleClick
        Call EditData()
    End Sub

    Private Sub EditData()
        If txt_MYPRODUCT_Selected.Text = "" Then Exit Sub
        Dim mFrm_DealSummary_Product_Library_Edit As New Frm_DealSummary_Product_Library_Edit
        mFrm_DealSummary_Product_Library_Edit.strID = grd_data.CurrentRow.Cells(0).Value
        mFrm_DealSummary_Product_Library_Edit.strMODE = "EDIT"
        mFrm_DealSummary_Product_Library_Edit.ShowDialog()
        Call SetGrid()
    End Sub

    Private Sub AddData()
        Dim mFrm_DealSummary_Product_Library_Edit As New Frm_DealSummary_Product_Library_Edit
        mFrm_DealSummary_Product_Library_Edit.strID = ""
        mFrm_DealSummary_Product_Library_Edit.strMODE = "ADD"
        mFrm_DealSummary_Product_Library_Edit.ShowDialog()
        Call SetGrid()
    End Sub

    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        Call AddData()
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Call EditData()
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If grd_data.RowCount <= 0 Then Exit Sub

      

        If grd_data.CurrentRow.Cells(0).Value <> "" Then

            If MsgBox("Do you want to delete.", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
                Dim strSQL As String = ""
                strSQL = "delete from [TB_BANK_PRODUCT_LIBRARY]"
                strSQL += " where [MYPRODUCT] ='" & grd_data.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") & "'"
                strSQL += " AND [UDEPRODUCT] ='" & grd_data.CurrentRow.Cells(3).Value.ToString.Replace("'", "''") & "'"
                strSQL += " AND [PRODUCT_CODE] ='" & grd_data.CurrentRow.Cells(4).Value.ToString.Replace("'", "''") & "'"

                conn.ExecuteNonQuery(strSQL)
                Call SetGrid()
            End If


        End If
    End Sub
End Class