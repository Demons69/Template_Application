Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_DealSummary_UserCategory
    Public strID As String = ""
    Public strMODE As String = "ADD"
    Private Const strALL = "--------Select--------"
    Dim conn As CSQL

    Private Sub Frm_DealSummary_UserCategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_DealSummary_UserCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            strCrit = " where a.service_group='ALL' "

            If chk_deal_cover_inquiry.Checked Then
                strCrit += " or a.service_group='Inquiry' "
            End If
            If chk_deal_cover_payment.Checked Then
                strCrit += " or a.service_group='Payment' "
            End If
            If chk_deal_cover_admin.Checked Then
                strCrit += " or a.service_group='Admin' "
            End If

            strSQL = ""
            strSQL += vbCrLf & " SELECT "

            strSQL += vbCrLf & "  a.[seq] as [seq]   " '--------1
            strSQL += vbCrLf & " ,a.[menu_parent] as [menu_parent]   " '---------2
            strSQL += vbCrLf & " ,a.[menu] as [menu]  " '------------3

            strSQL += vbCrLf & "  ,a.[view] as [view-use] " '-----------4
            strSQL += vbCrLf & "  ,a.[edit] as [edit-use] " '----------5
            strSQL += vbCrLf & "  ,a.[auth] as [auth-use] " '----------6

            strSQL += vbCrLf & "  ,(CASE when isnull(#r.[view], a.[view])='Y' THEN 1 ELSE 0 end )  as [view-value] " '---------------7
            strSQL += vbCrLf & "  ,(CASE when isnull(#r.[edit], a.[edit])='Y' THEN 1 ELSE 0 end )  as [edit-value] " '--------------8
            strSQL += vbCrLf & "  ,(CASE when isnull(#r.[auth], a.[auth])='Y' THEN 1 ELSE 0 end )  as [auth-value] " '--------------9

            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & "  [dbo].[TB_CATEGORY_FORM_MST] a  "

            strSQL += vbCrLf & " LEFT OUTER JOIN ( "
            strSQL += vbCrLf & "  SELECT * from TB_CATAGORY_FORM where company_id='" & txt_company_id.Text.Replace("'", "''") & "' and User_Category_ID='" & txt_User_Category_ID.Text.Replace("'", "''") & "'  "
            strSQL += vbCrLf & " ) #r ON #r.[seq]=a.[seq] "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " ORDER BY   cast(a.[seq] AS FLOAT) "

            Call conn.SetGrid(strSQL, grd_category_user)

            If grd_category_user.RowCount > 0 Then

                'grd_category_user.Columns(i) = DataGridViewCheckBoxColumn
                grd_category_user.Rows.Item(0).Selected = True

                For i = 0 To grd_category_user.Columns.Count - 1
                    grd_category_user.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Next
            End If


            Dim colCheckbox1 As New DataGridViewCheckBoxColumn()
            Dim colCheckbox2 As New DataGridViewCheckBoxColumn()
            Dim colCheckbox3 As New DataGridViewCheckBoxColumn()
            '-------------10-7
            colCheckbox1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            colCheckbox1.ThreeState = False
            colCheckbox1.TrueValue = 1
            colCheckbox1.FalseValue = 0
            colCheckbox1.IndeterminateValue = System.DBNull.Value
            colCheckbox1.DataPropertyName = "view"
            colCheckbox1.HeaderText = "view"
            colCheckbox1.Name = "view"
            colCheckbox1.ReadOnly = False
            colCheckbox1.HeaderText = "view"
            '-------------11-8
            colCheckbox2.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            colCheckbox2.ThreeState = False
            colCheckbox2.TrueValue = 1
            colCheckbox2.FalseValue = 0
            colCheckbox2.IndeterminateValue = System.DBNull.Value
            colCheckbox2.DataPropertyName = "edit"
            colCheckbox2.HeaderText = "edit"
            colCheckbox2.Name = "edit"
            colCheckbox2.ReadOnly = False
            colCheckbox2.HeaderText = "edit"
            '-------------12-9
            colCheckbox3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            colCheckbox3.ThreeState = False
            colCheckbox3.TrueValue = 1
            colCheckbox3.FalseValue = 0
            colCheckbox3.IndeterminateValue = System.DBNull.Value
            colCheckbox3.DataPropertyName = "Auth"
            colCheckbox3.HeaderText = "Auth"
            colCheckbox3.Name = "Auth"
            colCheckbox3.ReadOnly = False
            colCheckbox3.HeaderText = "Auth"

            grd_category_user.Columns.Add(colCheckbox1)
            grd_category_user.Columns.Add(colCheckbox2)
            grd_category_user.Columns.Add(colCheckbox3)
            '--------------------------------------
            grd_category_user.Columns(0).ReadOnly = True
            grd_category_user.Columns(1).ReadOnly = True
            grd_category_user.Columns(2).ReadOnly = True
            grd_category_user.Columns(3).ReadOnly = True
            grd_category_user.Columns(4).ReadOnly = True
            grd_category_user.Columns(5).ReadOnly = True
            grd_category_user.Columns(6).ReadOnly = True
            grd_category_user.Columns(7).ReadOnly = True
            grd_category_user.Columns(8).ReadOnly = True
            ' grd_category_user.Columns(9).ReadOnly = True

            '--------------------------------------
            grd_category_user.Columns(3).Visible = False
            grd_category_user.Columns(4).Visible = False
            grd_category_user.Columns(5).Visible = False
            grd_category_user.Columns(6).Visible = False
            grd_category_user.Columns(7).Visible = False
            grd_category_user.Columns(8).Visible = False
            'grd_category_user.Columns(9).Visible = False

            '  Dim i As Long = 0
            For i = 0 To grd_category_user.RowCount - 1
                '-------------10-3
                If grd_category_user.Rows(i).Cells(3).Value = "Y" Then

                    grd_category_user.Rows(i).Cells(9).Style.BackColor = Color.White
                    grd_category_user.Rows(i).Cells(9).ReadOnly = False
                Else

                    grd_category_user.Rows(i).Cells(9).Style.BackColor = Color.Gray
                    grd_category_user.Rows(i).Cells(9).ReadOnly = True
                End If

                If grd_category_user.Rows(i).Cells(6).Value = "1" Then
                    DirectCast(grd_category_user.Rows(i).Cells(9), DataGridViewCheckBoxCell).Value = True
                Else
                    DirectCast(grd_category_user.Rows(i).Cells(9), DataGridViewCheckBoxCell).Value = False
                End If

                '-------------11-4
                If grd_category_user.Rows(i).Cells(4).Value = "Y" Then
                    ' DirectCast(grd_category_user.Rows(i).Cells(10), DataGridViewCheckBoxCell).Value = True
                    grd_category_user.Rows(i).Cells(10).Style.BackColor = Color.White
                    grd_category_user.Rows(i).Cells(10).ReadOnly = False
                Else
                    'DirectCast(grd_category_user.Rows(i).Cells(10), DataGridViewCheckBoxCell).Value = False
                    grd_category_user.Rows(i).Cells(10).Style.BackColor = Color.Gray
                    grd_category_user.Rows(i).Cells(10).ReadOnly = True
                End If

                If grd_category_user.Rows(i).Cells(7).Value = "1" Then
                    DirectCast(grd_category_user.Rows(i).Cells(10), DataGridViewCheckBoxCell).Value = True
                Else
                    DirectCast(grd_category_user.Rows(i).Cells(10), DataGridViewCheckBoxCell).Value = False
                End If

                '-------------12-5
                If grd_category_user.Rows(i).Cells(5).Value = "Y" Then
                    ' DirectCast(grd_category_user.Rows(i).Cells(11), DataGridViewCheckBoxCell).Value = True
                    grd_category_user.Rows(i).Cells(11).Style.BackColor = Color.White
                    grd_category_user.Rows(i).Cells(11).ReadOnly = False
                Else
                    'DirectCast(grd_category_user.Rows(i).Cells(11), DataGridViewCheckBoxCell).Value = False
                    grd_category_user.Rows(i).Cells(11).Style.BackColor = Color.Gray
                    grd_category_user.Rows(i).Cells(11).ReadOnly = True
                End If

                If grd_category_user.Rows(i).Cells(8).Value = "1" Then
                    DirectCast(grd_category_user.Rows(i).Cells(11), DataGridViewCheckBoxCell).Value = True
                Else
                    DirectCast(grd_category_user.Rows(i).Cells(11), DataGridViewCheckBoxCell).Value = False
                End If

            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click
        Try
            Dim strView As String = ""
            Dim strEdit As String = ""
            Dim strAuth As String = ""

            Dim strSQL As String = ""
            strSQL = ""
            strSQL += " delete from TB_CATAGORY_FORM where company_id='" & txt_company_id.Text.Replace("'", "''") & "' and User_Category_ID='" & txt_User_Category_ID.Text.Replace("'", "''") & "' "

            Dim i As Long = 0
            For i = 0 To grd_category_user.RowCount - 1

                'If grd_category_user.Rows(i).Cells("view").Value = True Then



                strSQL += vbCrLf & "  insert into TB_CATAGORY_FORM( [company_id],[User_Category_ID],[seq],[menu_parent],[menu],[view],[edit],[auth] ) "
                strSQL += "   values ( "
                strSQL += "  '" & txt_company_id.Text.Replace("'", "''") & "' "
                strSQL += "  ,'" & txt_User_Category_ID.Text.Replace("'", "''") & "' "

                strSQL += "  ," & grd_category_user.Rows(i).Cells(0).Value & " "
                strSQL += "  ,'" & grd_category_user.Rows(i).Cells(1).Value.Replace("'", "''") & "' "
                strSQL += "  ,'" & grd_category_user.Rows(i).Cells(2).Value.Replace("'", "''") & "' "

                If grd_category_user.Rows(i).Cells(9).FormattedValue = True Then
                    strSQL += "  ,'Y' "
                    strView += "1"
                Else
                    strSQL += "  ,'N' "
                    strView += "0"
                End If

                If grd_category_user.Rows(i).Cells(10).FormattedValue = True Then
                    strSQL += "  ,'Y' "
                    strEdit += "1"
                Else
                    strSQL += "  ,'N' "
                    strEdit += "0"
                End If

                If grd_category_user.Rows(i).Cells(11).FormattedValue = True Then
                    strSQL += "  ,'Y' "
                    strAuth += "1"
                Else
                    strSQL += "  ,'N' "
                    strAuth += "0"
                End If

                strSQL += "   ) "

            Next

            Dim strErr As String = ""
            strErr += conn.ExecuteNonQuery(strSQL)

            'TB_CATEGORY
            strSQL = ""
            strSQL += vbCrLf & " update TB_CATEGORY set "

            strSQL += vbCrLf & " form_view='" & strView & "'"
            strSQL += vbCrLf & ", form_edit='" & strEdit & "'"
            strSQL += vbCrLf & " , form_auth='" & strAuth & "'"

            strSQL += vbCrLf & " where company_id='" & txt_company_id.Text.Replace("'", "''") & "' and User_Category_ID='" & txt_User_Category_ID.Text.Replace("'", "''") & "' "
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