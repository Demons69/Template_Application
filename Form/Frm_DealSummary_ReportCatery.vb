Imports Template_Application.CSQL
Imports System.Data.SqlClient


Public Class Frm_DealSummary_ReportCatery

    Public strID As String = ""
    Public strMODE As String = "ADD"
    Private Const strALL = "--------Select--------"
    Dim conn As CSQL

    Private Sub Frm_DealSummary_ReportCatery_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_DealSummary_ReportCatery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        conn = New CSQL
        conn.Connect()
        Call SetGrid_Category()
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub SetGrid_Category()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""
            strCrit = ""

            strSQL = ""
            strSQL += vbCrLf & " SELECT "

            strSQL += vbCrLf & " a.[seq] as [No.]   "
            strSQL += vbCrLf & "  ,a.[report_id]	as [Report ID]  "
            strSQL += vbCrLf & "  ,a.[report_name_cw]  as [Report Name] "
            strSQL += vbCrLf & "  , (CASE when isnull(#r.[view],'N')='Y' THEN 1 ELSE 0 end )  as [View] "

            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & "  [dbo].[TB_CATAGORY_REPORT_MST] a  "

            strSQL += vbCrLf & " LEFT OUTER JOIN ( "
            strSQL += vbCrLf & "  SELECT * from TB_CATEGORY_REPORT where company_id='" & txt_company_id.Text.Replace("'", "''") & "' and Report_Category_ID='" & txt_Report_Category_ID.Text.Replace("'", "''") & "'  "
            strSQL += vbCrLf & " ) #r ON #r.[report_id]=a.[report_id] "

            strSQL += vbCrLf & " ORDER BY   a.report_id  " 'cast(a.[seq] AS FLOAT)

            Call conn.SetGrid(strSQL, grd_category_user)
            If grd_category_user.RowCount > 0 Then

                'grd_category_user.Columns(i) = DataGridViewCheckBoxColumn
                grd_category_user.Rows.Item(0).Selected = True

                For i = 0 To grd_category_user.Columns.Count - 1
                    grd_category_user.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Next
            End If

            grd_category_user.Columns(0).ReadOnly = True
            grd_category_user.Columns(1).ReadOnly = True
            grd_category_user.Columns(2).ReadOnly = True
            grd_category_user.Columns(3).ReadOnly = True

            grd_category_user.Columns(3).Visible = False


            Dim colCheckbox As New DataGridViewCheckBoxColumn()
            colCheckbox.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            colCheckbox.ThreeState = False
            colCheckbox.TrueValue = 1
            colCheckbox.FalseValue = 0
            colCheckbox.IndeterminateValue = System.DBNull.Value
            colCheckbox.DataPropertyName = "view-edit"
            colCheckbox.HeaderText = "view-edit"
            colCheckbox.Name = "view-edit"
            colCheckbox.ReadOnly = False
            colCheckbox.HeaderText = "view-edit"
            grd_category_user.Columns.Add(colCheckbox)

            '            Dim i As Long = 0
            For i = 0 To grd_category_user.RowCount - 1
                grd_category_user.Rows(i).Cells(0).Value = i + 1
                If grd_category_user.Rows(i).Cells(3).Value = "1" Then
                    DirectCast(grd_category_user.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = True
                Else
                    DirectCast(grd_category_user.Rows(i).Cells(4), DataGridViewCheckBoxCell).Value = False
                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click

        Try
            Dim strView As String = ""

            Dim strSQL As String = ""
            strSQL = ""
            strSQL += " delete from TB_CATEGORY_REPORT where company_id='" & txt_company_id.Text.Replace("'", "''") & "' and Report_Category_ID='" & txt_Report_Category_ID.Text.Replace("'", "''") & "' "

            Dim i As Long = 0
            For i = 0 To grd_category_user.RowCount - 1

                'If grd_category_user.Rows(i).Cells("view").Value = True Then



                strSQL += vbCrLf & "  insert into TB_CATEGORY_REPORT( [company_id],[Report_Category_ID],[seq],[report_id],[report_name],[view]) "
                strSQL += "   values ( "
                strSQL += "  '" & txt_company_id.Text.Replace("'", "''") & "' "
                strSQL += "  ,'" & txt_Report_Category_ID.Text.Replace("'", "''") & "' "
                strSQL += "  ," & grd_category_user.Rows(i).Cells(0).Value & " "
                strSQL += "  ,'" & grd_category_user.Rows(i).Cells(1).Value.Replace("'", "''") & "' "
                strSQL += "  ,'" & grd_category_user.Rows(i).Cells(2).Value.Replace("'", "''") & "' "
                If grd_category_user.Rows(i).Cells(4).FormattedValue = True Then
                    strSQL += "  ,'Y' "
                    strView += "1"
                Else
                    strSQL += "  ,'N' "
                    strView += "0"
                End If

                strSQL += "   ) "

            Next

            Dim strErr As String = ""
            strErr += conn.ExecuteNonQuery(strSQL)

            'TB_CATEGORY
            strSQL = ""
            strSQL += vbCrLf & " update TB_CATEGORY set "
            strSQL += vbCrLf & " report_view='" & strView & "'"
            strSQL += vbCrLf & " where company_id='" & txt_company_id.Text.Replace("'", "''") & "' and Report_Category_ID='" & txt_Report_Category_ID.Text.Replace("'", "''") & "' "
            strErr += conn.ExecuteNonQuery(strSQL)


            If strErr <> "" Then
                MsgBox(strErr)
            Else
                MsgBox("Save data was successful.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


End Class