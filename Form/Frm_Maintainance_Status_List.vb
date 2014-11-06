Public Class Frm_Maintainance_Status_List

    Dim conn As New CSQL
    Private Const strALL = "--------ALL--------"

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

            If rad_TemplateType_1.Checked = False Then
                If rad_TemplateType_2.Checked = True Then
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [TemplateType] = 'Single-Product' "
                Else
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [TemplateType] = 'Product Charge' "
                End If
            End If
            If cbo_ProductCode.Text.Length > 0 And cbo_ProductCode.Text <> strALL Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [ProductCode] LIKE '%" & cbo_ProductCode.Text.Substring(0, 3) & "%'"
            End If

            If txt_TemplateCode.Text.Length > 0 Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [TemplateCode] LIKE '%" & txt_TemplateCode.Text & "%'"
            End If

            If rad_StatusTemplate_1.Checked = False Then
                If rad_StatusTemplate_2.Checked = True Then
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [StatusTemplate] = 'Y' "
                Else
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [StatusTemplate] = 'N' "
                End If
            End If

            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            strSQL += vbCrLf & "   TemplateCode"
            strSQL += vbCrLf & " , TemplateFullName"
            'strSQL += vbCrLf & " , TemplateEffectiveFrom"
            strSQL += vbCrLf & " , TemplateType"
            strSQL += vbCrLf & " , ProductCode"
            strSQL += vbCrLf & " , Remarks"
            strSQL += vbCrLf & " ,(case when StatusTemplate='Y' then 'Enabled' else 'Disabled' end) as StatusTemplate"
            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & " dbo.PRD_Template "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " ORDER BY ProductCode,TemplateType,TemplateCode "

            Call conn.SetGrid(strSQL, grd_Template)
            If grd_Template.RowCount > 0 Then
                grd_Template.Rows.Item(0).Selected = True
                txt_Template.Text = grd_Template.CurrentRow.Cells(0).Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Frm_Maintainance_Status_List_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub Frm_Maintainance_Status_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String = ""
        ' strSQL = "select distinct ProductCode from dbo.PRD_Template order by ProductCode"
        strSQL = conn.GetSQL_LIST_PRODUCT_MST

        conn = New CSQL
        conn.Connect()
        conn.Fill_ComboBox(strSQL, cbo_ProductCode, strALL)
        Call SetGrid()
    End Sub

    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        Call AddData()
    End Sub


    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Call EditData()
    End Sub

    Private Sub AddData()
        Dim mFrm_Maintainance_Status_Entry As New Frm_Maintainance_Status_Entry
        mFrm_Maintainance_Status_Entry.strID = ""
        mFrm_Maintainance_Status_Entry.strMODE = "ADD"
        mFrm_Maintainance_Status_Entry.ShowDialog()
        Call SetGrid()
    End Sub

    Private Sub EditData()
        If txt_Template.Text = "" Then Exit Sub
        Dim mFrm_Maintainance_Status_Entry As New Frm_Maintainance_Status_Entry
        mFrm_Maintainance_Status_Entry.strID = txt_Template.Text
        mFrm_Maintainance_Status_Entry.strMODE = "EDIT"
        mFrm_Maintainance_Status_Entry.ShowDialog()
        Call SetGrid()
    End Sub

    Private Sub grd_Template_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_Template.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txt_Template.Text = grd_Template.CurrentRow.Cells(0).Value
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub grd_Template_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_Template.CellDoubleClick
        Call EditData()
    End Sub


    Private Sub grd_Template_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_Template.CellContentClick

    End Sub
End Class