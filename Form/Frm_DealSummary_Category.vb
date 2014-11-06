Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_DealSummary_Category

    Public strID As String = ""
    Public strMODE As String = "ADD"
    Private Const strALL = "--------Select--------"
    Dim conn As CSQL
    Public bIsViewOnly As Boolean = False

    Private Sub Frm_DealSummary_Category_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_DealSummary_Category_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        conn = New CSQL
        conn.Connect()
        Dim strSQL As String = ""

        txt_User_Category_ID.Enabled = False
        txt_User_Category_Name.Enabled = False
        txt_Report_Category_ID.Enabled = False
        txt_Report_Category_Name.Enabled = False

        ' If strMODE.ToUpper <> "ADD" Then
        'Call ShowData()
        'End If


        Call SetGrid_Category()

    End Sub

    Private Sub SetGrid_Category()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""
            strCrit = ""

            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            strSQL += vbCrLf & " u.[user_id] as [User ID]   "
            strSQL += vbCrLf & "  ,u.firstname + '  ' + u.lastname as [Fullname] "
            strSQL += vbCrLf & "  , u.company_id as [Company ID]"
            strSQL += vbCrLf & " , c.client_code as [Client Code] "
            strSQL += vbCrLf & "  , c.companyname_en as [Client Name]"
            ' strSQL += vbCrLf & " ,a.seq as [seq]"

            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & "  dbo.TB_DEAL_UMM_USER u"
            strSQL += vbCrLf & " left OUTER JOIN dbo.TB_DEAL_UMM_COMPANY c "
            strSQL += vbCrLf & " on c.company_id=u.company_id  "

            strSQL += vbCrLf & "  WHERE"
            strSQL += vbCrLf & " u.company_id IN"
            strSQL += vbCrLf & " ("
            strSQL += vbCrLf & " Select company_id"
            strSQL += vbCrLf & " FROM"
            strSQL += vbCrLf & "  TB_DEAL_UMM_COMPANY a"
            strSQL += vbCrLf & " where a.company_id='" & txt_company_id.Text.Replace("'", "''") & "' AND a.set_as_parent_company='Y'"
            strSQL += vbCrLf & "  UNION "
            strSQL += vbCrLf & " Select company_id"
            strSQL += vbCrLf & "  FROM "
            strSQL += vbCrLf & "  TB_DEAL_UMM_COMPANY a"
            strSQL += vbCrLf & " where a.company_id_parent='" & txt_company_id.Text.Replace("'", "''") & "' AND a.set_as_parent_company='N'"
            strSQL += vbCrLf & " )"

            strSQL += vbCrLf & " and  u.User_Category_ID='" & txt_User_Category_ID.Text.Replace("'", "''") & "'"

            strSQL += vbCrLf & "  and  c.client_code = '" & txt_client_code.Text.Replace("'", "''") & "'  "

            strSQL += vbCrLf & " ORDER BY   u.[user_id]  "

            Call conn.SetGrid(strSQL, grd_category_user)
            If grd_category_user.RowCount > 0 Then
                grd_category_user.Rows.Item(0).Selected = True

                For i = 0 To grd_category_user.Columns.Count - 1
                    grd_category_user.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub btn_ReportCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ReportCategory.Click
        Dim mFrm_DealSummary_ReportCatery As New Frm_DealSummary_ReportCatery
        mFrm_DealSummary_ReportCatery.txt_company_id.Text = txt_company_id.Text
        mFrm_DealSummary_ReportCatery.txt_Report_Category_ID.Text = txt_Report_Category_ID.Text
        mFrm_DealSummary_ReportCatery.txt_Report_Category_Name.Text = txt_Report_Category_Name.Text
        If bIsViewOnly = True Then
            mFrm_DealSummary_ReportCatery.BT_Update.Enabled = False
        End If
        mFrm_DealSummary_ReportCatery.ShowDialog()
    End Sub


    Private Sub btn_UserCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_UserCategory.Click
        Dim mFrm_DealSummary_UserCategory As New Frm_DealSummary_UserCategory
        mFrm_DealSummary_UserCategory.txt_company_id.Text = txt_company_id.Text
        mFrm_DealSummary_UserCategory.txt_User_Category_ID.Text = txt_User_Category_ID.Text
        mFrm_DealSummary_UserCategory.txt_User_Category_Name.Text = txt_User_Category_Name.Text

        mFrm_DealSummary_UserCategory.chk_deal_cover_admin.Checked = chk_deal_cover_admin.Checked
        mFrm_DealSummary_UserCategory.chk_deal_cover_inquiry.Checked = chk_deal_cover_inquiry.Checked
        mFrm_DealSummary_UserCategory.chk_deal_cover_payment.Checked = chk_deal_cover_payment.Checked
        If bIsViewOnly = True Then
            mFrm_DealSummary_UserCategory.BT_Update.Enabled = False
        End If
        mFrm_DealSummary_UserCategory.ShowDialog()
    End Sub

    Private Sub btn_ClearPrintFlag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ClearPrintFlag.Click
        Try
            If txt_seq.Text = "" Then Exit Sub

            Dim strSQL As String = ""
           
            strSQL += vbCrLf & " update TB_CATEGORY set print_flag='' where company_id='" & txt_company_id.Text & "' and seq=" & txt_seq.Text
            strSQL += vbCrLf & " update TB_CATAGORY_FORM set print_flag='' where company_id='" & txt_company_id.Text & "' and User_Category_ID='" & txt_User_Category_ID.Text & "'"
            strSQL += vbCrLf & " update TB_CATEGORY_REPORT set print_flag='' where company_id='" & txt_company_id.Text & "' and Report_Category_ID='" & txt_Report_Category_ID.Text & "'"

            conn.ExecuteNonQuery(strSQL)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    
End Class