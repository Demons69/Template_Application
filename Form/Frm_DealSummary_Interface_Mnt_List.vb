Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_DealSummary_Interface_Mnt_List

    Dim conn As New CSQL
    Public txtCodeReturn As TextBox
    Public is_query As Boolean = False

    Public Sub New(ByVal param As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        '   strSQL = param
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Private Sub Frm_DealSummary_Interface_Mnt_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetGrid()
    End Sub

    Private Sub SetGrid()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""


            strCrit = ""

            If txt_mapping_code.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [mapping_code] LIKE '%" & txt_mapping_code.Text & "%'"
            End If
            If txt_mapping_description.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [mapping_description] LIKE '%" & txt_mapping_description.Text & "%'"
            End If
            If cbo_interface_type.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [interface_type] LIKE '%" & cbo_interface_type.Text & "%'"
            End If

            strSQL = ""

            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            strSQL += vbCrLf & "  mapping_code as [Mapping Code] "
            strSQL += vbCrLf & "   ,mapping_description as [Mapping Description] "
            strSQL += vbCrLf & "  ,interface_type as [Interface Type]"
            strSQL += vbCrLf & "  ,interface_code as [Interface Code]"
            strSQL += vbCrLf & "  ,process_code as [Process Code]"
            strSQL += vbCrLf & "  ,description_for_csd as [Description for CSD]"
            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & " TB_DEAL_INTERFACE_TEMPLATE a "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " ORDER BY   a.mapping_code "



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

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub grd_list_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_list.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            If is_query = False Then
                Call Editdata()
            Else
                Call SelectFind()
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Add.Click
        Dim mFrm_DealSummary_Interface_Mnt_Edit As New Frm_DealSummary_Interface_Mnt_Edit
        mFrm_DealSummary_Interface_Mnt_Edit.strID = ""
        mFrm_DealSummary_Interface_Mnt_Edit.strMODE = "ADD"
        mFrm_DealSummary_Interface_Mnt_Edit.ShowDialog()
        Call SetGrid()
    End Sub

    Private Sub btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Edit.Click
        Call Editdata()
    End Sub

    Private Sub Editdata()
        If grd_list.RowCount <= 0 Then Exit Sub

        If grd_list.CurrentRow.Cells(0).Value <> "" Then
            Dim mFrm_DealSummary_Interface_Mnt_Edit As New Frm_DealSummary_Interface_Mnt_Edit
            mFrm_DealSummary_Interface_Mnt_Edit.strID = grd_list.CurrentRow.Cells(0).Value
            mFrm_DealSummary_Interface_Mnt_Edit.strMODE = "EDIT"
            mFrm_DealSummary_Interface_Mnt_Edit.ShowDialog()
            Call SetGrid()
        End If
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        If grd_list.RowCount <= 0 Then Exit Sub

        If grd_list.CurrentRow.Cells(0).Value <> "" Then

            If MsgBox("Do you want to delete.", MsgBoxStyle.YesNo, "confirm") = MsgBoxResult.Yes Then
                Dim strSQL As String = "delete from [TB_DEAL_INTERFACE_TEMPLATE] where mapping_code='" & grd_list.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") & "'"
                conn.ExecuteNonQuery(strSQL)
                Call SetGrid()
            End If


        End If
    End Sub

    Private Sub btn_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Select.Click

        Call SelectFind()

    End Sub

    Private Sub SelectFind()
        If grd_list.RowCount <= 0 Then Exit Sub
        If grd_list.CurrentRow.Cells(0).Value = "" Then Exit Sub
        txtCodeReturn.Text = grd_list.CurrentRow.Cells(0).Value
        Me.Close()
    End Sub

    Private Sub grd_list_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_list.CellContentClick

    End Sub
End Class