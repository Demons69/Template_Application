Imports Template_Application.CSQL
Imports System.Data.SqlClient


Public Class Frm_DealSummary_FeeCharging_List

    Dim conn As New CSQL

    Private Sub Frm_DealSummary_FeeCharging_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetGrid()
    End Sub

    Private Sub SetGrid()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""


            strCrit = ""

            If txt_product_id.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [Product ID] LIKE '%" & txt_product_id.Text & "%'"
            End If
            If txt_product_description.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [Product Description] LIKE '%" & txt_product_description.Text & "%'"
            End If
            If txt_account_no.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [GL Account] LIKE '%" & txt_account_no.Text & "%'"
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
            strSQL += vbCrLf & "        ,working_day_condition_date as [Working Day]"
            ' strSQL += vbCrLf & "        ,[Working Day Condition]"
            strSQL += vbCrLf & "    FROM [dbo].[TB_FEE_CHARGING]"
            strSQL += vbCrLf & strCrit

            strSQL += vbCrLf & "  order by [Product ID]"


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

    Private Sub btn_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Find.Click
        Call SetGrid()
    End Sub


    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        Dim mFrm_DealSummary_FeeCharging_Edit As New Frm_DealSummary_FeeCharging_Edit
        mFrm_DealSummary_FeeCharging_Edit.strID = ""
        mFrm_DealSummary_FeeCharging_Edit.strMODE = "ADD"
        mFrm_DealSummary_FeeCharging_Edit.ShowDialog()
        Call SetGrid()
    End Sub


    Private Sub grd_Template_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_list.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            Call Editdata()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Call Editdata()
    End Sub

    Private Sub Editdata()
        If grd_list.RowCount <= 0 Then Exit Sub

        If grd_list.CurrentRow.Cells(0).Value <> "" Then
            Dim mFrm_DealSummary_FeeCharging_Edit As New Frm_DealSummary_FeeCharging_Edit
            mFrm_DealSummary_FeeCharging_Edit.strID = grd_list.CurrentRow.Cells(0).Value
            mFrm_DealSummary_FeeCharging_Edit.strMODE = "EDIT"
            mFrm_DealSummary_FeeCharging_Edit.ShowDialog()
            Call SetGrid()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If grd_list.RowCount <= 0 Then Exit Sub

        If grd_list.CurrentRow.Cells(0).Value <> "" Then

            If MsgBox("Do you want to delete.", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
                Dim strSQL As String = "delete from [TB_FEE_CHARGING] where product_id='" & grd_list.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") & "'"
                conn.ExecuteNonQuery(strSQL)
                Call SetGrid()
            End If


        End If
    End Sub

    Private Sub btn_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print.Click
        ' Try
        Dim str_cn As String = ""
        Dim str_cn_ole As String = ""
        Dim mCls_Configuration As New Cls_Configuration
        str_cn = mCls_Configuration.ConnectionString



        Dim strFile As String = Application.StartupPath & "\report\APPLICATION_FORM.doc"
        Dim strFile_param As String = Application.StartupPath & "\report\File_param.dat"
        ' Dim strFile_cfg As String = Application.StartupPath & "\report\Default.ini"
        Dim strPath As String = Application.StartupPath & "\report\"
        '\Report\output-files\THAILAND02'

        ' mCls_Configuration.INIWrite(strFile_cfg, "Options", "AutosaveDirectory", strPath & "output-files\" & txt_company_id.Text & "\")


        Dim strServer As String = ""
        Dim strDatabase As String = ""
        Dim strUser As String = ""
        Dim strPwd As String = ""


        Dim csb = New SqlConnectionStringBuilder(str_cn)



        strServer = csb.DataSource
        strDatabase = csb.InitialCatalog
        strUser = csb.UserID
        strPwd = csb.Password

        str_cn_ole = "Provider=SQLOLEDB.1;Password=" & strPwd & ";Persist Security Info=True;User ID=" & strUser & ";Initial Catalog=" & strDatabase & ";Data Source=" & strServer & ""

        'Call GenPDF(strFile, str_cn_ole, strPath)
        csb.Clear()
        Dim strParama As String = str_cn_ole & "||" & strPath & "||" & grd_list.CurrentRow.Cells(0).Value & "||" & "FEE-CHARGING"
        'Clipboard.Clear()
        'Clipboard.SetData(strParama, TextDataFormat.Text)

        Dim FILE_NAME As String = strFile_param 'Application.StartupPath & "\err" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".txt"

        ' If System.IO.File.Exists(FILE_NAME) = True Then

        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

        objWriter.Write(strParama)
        objWriter.Flush()
        objWriter.Close()

        Shell("cmd /k """ & strFile & """", AppWinStyle.NormalFocus)
    End Sub
End Class