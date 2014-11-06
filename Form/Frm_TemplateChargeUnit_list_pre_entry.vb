Imports Template_Application.CSQL
Imports System.Data
Imports System.Data.SqlClient

Public Class Frm_TemplateChargeUnit_list_pre_entry

    'Public strTemplateCode As String
    'Public strMODE As String = "ADD"
    'Public strGUID As String = ""
    'Private Const COL_GRD_EVENT_EVENT_CODE = 3
    'Private Const strSingleProduct = "Single-Product"
    'Private Const strProductChare = "Product Charge"

    Private objTemplate As New TemplateMaster

    Private Sub Frm_TemplateChargeUnit_list_pre_entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Call Preload()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Preload()

        If cboProduct.Items.Count <= 0 Then
            Dim strsql As String
            Dim conn As New CSQL

            strsql = "Select distinct Product FROM [PRD_TemplateChargeEvents] order by Product"
            conn.Fill_ComboBox(strsql, cboProduct)
        End If

        If grd_Event.RowCount > 0 Then

            grd_Event.Columns("ApplyMinChgAmt").DefaultCellStyle.Format = "###,###0.00"
            grd_Event.Columns("ApplyMinChgAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd_Event.Columns("ApplyMaxChgAmt").DefaultCellStyle.Format = "###,###0.00"
            grd_Event.Columns("ApplyMaxChgAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd_Event.Columns("RoundingAmnt").DefaultCellStyle.Format = "###,###0.00"
            grd_Event.Columns("RoundingAmnt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd_Event.Columns("ComputationPeriod").DefaultCellStyle.Format = "###,###0"
            grd_Event.Columns("ComputationPeriod").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd_Event.Columns("ComputationDay").DefaultCellStyle.Format = "###,###0"
            grd_Event.Columns("ComputationDay").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd_Event.Columns("PostingPeriod").DefaultCellStyle.Format = "###,###0"
            grd_Event.Columns("PostingPeriod").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd_Event.Columns("PostingDay").DefaultCellStyle.Format = "###,###0"
            grd_Event.Columns("PostingDay").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

        ''--#############################

        If grd_unit.RowCount > 0 Then
            grd_unit.Columns("ApplyMinchgAmount").DefaultCellStyle.Format = "###,###0.00"
            grd_unit.Columns("ApplyMinchgAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grd_unit.Columns("ApplyMaxChgAmount").DefaultCellStyle.Format = "###,###0.00"
            grd_unit.Columns("ApplyMaxChgAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            grd_unit.Columns("RoundingAmount").DefaultCellStyle.Format = "###,###0.00"
            grd_unit.Columns("RoundingAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            For i = 1 To 4
                grd_unit.Columns("LowerLimit" & i.ToString).DefaultCellStyle.Format = "###,###0.00"
                grd_unit.Columns("LowerLimit" & i.ToString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                grd_unit.Columns("UpperLimit" & i.ToString).DefaultCellStyle.Format = "###,###0.00"
                grd_unit.Columns("UpperLimit" & i.ToString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                grd_unit.Columns("FixedAmount" & i.ToString).DefaultCellStyle.Format = "###,###0.00"
                grd_unit.Columns("FixedAmount" & i.ToString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                grd_unit.Columns("BasisPoints" & i.ToString).DefaultCellStyle.Format = "###,###0.00"
                grd_unit.Columns("BasisPoints" & i.ToString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Next

        End If



    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click

        If Len(cboProduct.SelectedItem) = 0 And Len(txtTemplateCode.Text) = 0 Then
            MessageBox.Show("Pls. input Template code or Product code.", "Warning", MessageBoxButtons.OK)

        Else

            Select Case Len(txtTemplateCode.Text)
                Case 0

                    grd_Event.DataSource = objTemplate.GetTemplateEventByProductCode(cboProduct.SelectedItem)

                Case Else
                    grd_Event.DataSource = objTemplate.GetTemplateEventByTemplateCode(txtTemplateCode.Text)
                    grd_unit.DataSource = objTemplate.GetTemplateUnit(txtTemplateCode.Text)
            End Select

        End If

    End Sub

    Private Sub cboProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduct.SelectedIndexChanged

        txtTemplateCode.Text = ""
        grd_Event.DataSource = objTemplate.GetTemplateEventByProductCode(cboProduct.SelectedItem)

        If grd_Event.RowCount > 0 Then

            grd_unit.DataSource = objTemplate.GetTemplateUnit(grd_Event.Rows(0).Cells(0).Value)
        End If

    End Sub


    Private Sub grd_Event_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_Event.CellContentDoubleClick

        grd_unit.DataSource = objTemplate.GetTemplateUnit(grd_Event.Rows(e.RowIndex).Cells(0).Value)
        txtTemplateCode.Text = grd_Event.Rows(e.RowIndex).Cells(0).Value

    End Sub

    Private Sub btnEditEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditEvent.Click

        Try

            Dim mFrm_TemplateChargeEvent_Edit As New Frm_TemplateChargeEvent_Edit
            mFrm_TemplateChargeEvent_Edit.strMODE = "EDIT"
            mFrm_TemplateChargeEvent_Edit.txt_TemplateCode.Text = txtTemplateCode.Text
            mFrm_TemplateChargeEvent_Edit.ShowDialog()

            ''Call UpGrid_Template_EventsAndUnit(True, False)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnEditUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditUnit.Click

        Try

            If grd_unit.CurrentRow Is Nothing Then

                MessageBox.Show("Please select template code of Charge Unit.")
            Else

                Dim mFrm_Frm_TemplateChargeUnit_Edit As New Frm_TemplateChargeUnit_Edit
                mFrm_Frm_TemplateChargeUnit_Edit.strMODE = "EDIT"
                mFrm_Frm_TemplateChargeUnit_Edit.txt_TemplateCode.Text = grd_unit.CurrentRow.Cells(0).Value
                mFrm_Frm_TemplateChargeUnit_Edit.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    'Private Sub UpGrid_Template_EventsAndUnit(Optional ByVal bRefreshEvent As Boolean = True, Optional ByVal bRefreshChargeUnit As Boolean = True)
    '    Dim strSQL As String = String.Empty
    '    Dim strCrit As String = String.Empty
    '    Dim dtChgEvent As DataTable
    '    Dim dtChgUnit As DataTable

    '    Try

    '        If txt_GUID.Text <> "" Then
    '            strCrit += IIf(strCrit = "", "WHERE", "AND") & " ID ='" & txt_GUID.Text & "' "
    '        End If

    '        strSQL = "  Select '" & txt_new_template.Text & "' as [TemplateCode]"
    '        strSQL += vbCrLf & " ,[Product]"
    '        strSQL += vbCrLf & " ,[ProductCCY]"
    '        strSQL += vbCrLf & " ,[Event]"
    '        strSQL += vbCrLf & " ,[ApplyMinChg]"
    '        strSQL += vbCrLf & " ,[ApplyMinChgAmt]"
    '        strSQL += vbCrLf & " ,[ApplyMaxChg]"
    '        strSQL += vbCrLf & " ,[ApplyMaxChgAmt]"
    '        strSQL += vbCrLf & " ,[RoundingType]"
    '        strSQL += vbCrLf & " ,[RoundingAmnt]"
    '        strSQL += vbCrLf & " ,[TemplateEffectiveFrom]"
    '        strSQL += vbCrLf & " ,[ComputationFrequency]"
    '        strSQL += vbCrLf & " ,[ComputationPeriodType]"
    '        strSQL += vbCrLf & " ,[ComputationPeriod]"
    '        strSQL += vbCrLf & " ,[ComputationDay]"
    '        strSQL += vbCrLf & " ,[NextComputationDate]"
    '        strSQL += vbCrLf & " ,[PostingFrequency]"
    '        strSQL += vbCrLf & " ,[PostingPeriodType]"
    '        strSQL += vbCrLf & " ,[PostingPeriod]"
    '        strSQL += vbCrLf & " ,[PostingDay]"
    '        strSQL += vbCrLf & " ,[NextPostingDate]"
    '        strSQL += vbCrLf & " FROM [PRD_TemplateChargeEvents]  "
    '        strSQL += vbCrLf & strCrit
    '        strSQL += vbCrLf & " order by Product ,ProductCCY,Event "

    '        If bRefreshEvent = True Then

    '            ''Call conn.SetGrid(strSQL, grd_Event)
    '            dtChgEvent = conn.BindingDT(strSQL, "Tb_ChgEvent")

    '            If dtChgEvent.Rows.Count > 0 Then

    '                grd_Event.DataSource = dtChgEvent

    '                Dim i As Integer
    '                For i = 0 To grd_Event.Columns.Count - 1
    '                    grd_Event.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    '                Next

    '                grd_Event.Columns("ApplyMinChgAmt").DefaultCellStyle.Format = "###,###0.00"
    '                grd_Event.Columns("ApplyMinChgAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                grd_Event.Columns("ApplyMaxChgAmt").DefaultCellStyle.Format = "###,###0.00"
    '                grd_Event.Columns("ApplyMaxChgAmt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                grd_Event.Columns("RoundingAmnt").DefaultCellStyle.Format = "###,###0.00"
    '                grd_Event.Columns("RoundingAmnt").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                grd_Event.Columns("ComputationPeriod").DefaultCellStyle.Format = "###,###0"
    '                grd_Event.Columns("ComputationPeriod").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                grd_Event.Columns("ComputationDay").DefaultCellStyle.Format = "###,###0"
    '                grd_Event.Columns("ComputationDay").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                grd_Event.Columns("PostingPeriod").DefaultCellStyle.Format = "###,###0"
    '                grd_Event.Columns("PostingPeriod").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                grd_Event.Columns("PostingDay").DefaultCellStyle.Format = "###,###0"
    '                grd_Event.Columns("PostingDay").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '            End If

    '        End If


    '        strSQL = ""
    '        strSQL += vbCrLf & " SELECT   '" & txt_new_template.Text & "' as [TemplateCode]"
    '        strSQL += vbCrLf & "       ,[Class]"
    '        strSQL += vbCrLf & "       ,[Product]"
    '        strSQL += vbCrLf & "       ,[ProductCCY]"
    '        strSQL += vbCrLf & "       ,[ChargesDefinedFor]"
    '        strSQL += vbCrLf & "       ,[ChargeCategory]"
    '        strSQL += vbCrLf & "       ,[Event]"
    '        strSQL += vbCrLf & "       ,[ChargeUnitCode]"
    '        strSQL += vbCrLf & "       ,[Description]"
    '        strSQL += vbCrLf & "       ,[ApplyMinchg]"
    '        strSQL += vbCrLf & "       ,[ApplyMinchgAmount]"
    '        strSQL += vbCrLf & "       ,[ApplyMaxChg]"
    '        strSQL += vbCrLf & "       ,[ApplyMaxChgAmount]"
    '        strSQL += vbCrLf & "       ,[Rounding]"
    '        strSQL += vbCrLf & "       ,[RoundingAmount]"
    '        strSQL += vbCrLf & "       ,[TemplateEffectiveFrom]"
    '        strSQL += vbCrLf & "       ,[ComputationBasis]"
    '        strSQL += vbCrLf & "       ,[ChargeType]"
    '        strSQL += vbCrLf & "       ,[InterestPeriod]"
    '        strSQL += vbCrLf & "       ,[BaseRate]"
    '        strSQL += vbCrLf & "       ,[ImmediatePosting]"
    '        strSQL += vbCrLf & "       ,[ImmediateCompn]"
    '        strSQL += vbCrLf & "      ,[ChgUnitDet]"
    '        strSQL += vbCrLf & "      ,[LowerLimit1]"
    '        strSQL += vbCrLf & "      ,[UpperLimit1]"
    '        strSQL += vbCrLf & "      ,[FixedAmount1]"
    '        strSQL += vbCrLf & "      ,[BasisPoints1]"
    '        strSQL += vbCrLf & "      ,[LowerLimit2]"
    '        strSQL += vbCrLf & "      ,[UpperLimit2]"
    '        strSQL += vbCrLf & "      ,[FixedAmount2]"
    '        strSQL += vbCrLf & "      ,[BasisPoints2]"
    '        strSQL += vbCrLf & "      ,[LowerLimit3]"
    '        strSQL += vbCrLf & "      ,[UpperLimit3]"
    '        strSQL += vbCrLf & "      ,[FixedAmount3]"
    '        strSQL += vbCrLf & "      ,[BasisPoints3]"
    '        strSQL += vbCrLf & "      ,[LowerLimit4]"
    '        strSQL += vbCrLf & "      ,[UpperLimit4]"
    '        strSQL += vbCrLf & "      ,[FixedAmount4]"
    '        strSQL += vbCrLf & "      ,[BasisPoints4]"

    '        strSQL += vbCrLf & "      ,[LowerLimit5]"
    '        strSQL += vbCrLf & "      ,[UpperLimit5]"
    '        strSQL += vbCrLf & "      ,[FixedAmount5]"
    '        strSQL += vbCrLf & "      ,[BasisPoints5]"

    '        strSQL += vbCrLf & "      ,[LowerLimit6]"
    '        strSQL += vbCrLf & "      ,[UpperLimit6]"
    '        strSQL += vbCrLf & "      ,[FixedAmount6]"
    '        strSQL += vbCrLf & "      ,[BasisPoints6]"

    '        strSQL += vbCrLf & "      ,[LowerLimit7]"
    '        strSQL += vbCrLf & "      ,[UpperLimit7]"
    '        strSQL += vbCrLf & "      ,[FixedAmount7]"
    '        strSQL += vbCrLf & "      ,[BasisPoints7]"

    '        strSQL += vbCrLf & "      ,[LowerLimit8]"
    '        strSQL += vbCrLf & "      ,[UpperLimit8]"
    '        strSQL += vbCrLf & "      ,[FixedAmount8]"
    '        strSQL += vbCrLf & "      ,[BasisPoints8]"

    '        strSQL += vbCrLf & "      ,[LowerLimit9]"
    '        strSQL += vbCrLf & "      ,[UpperLimit9]"
    '        strSQL += vbCrLf & "      ,[FixedAmount9]"
    '        strSQL += vbCrLf & "      ,[BasisPoints9]"


    '        strSQL += vbCrLf & "      ,[LowerLimit10]"
    '        strSQL += vbCrLf & "      ,[UpperLimit10]"
    '        strSQL += vbCrLf & "      ,[FixedAmount10]"
    '        strSQL += vbCrLf & "      ,[BasisPoints10]"


    '        strSQL += vbCrLf & "      ,[LowerLimit11]"
    '        strSQL += vbCrLf & "      ,[UpperLimit11]"
    '        strSQL += vbCrLf & "      ,[FixedAmount11]"
    '        strSQL += vbCrLf & "      ,[BasisPoints11],row_id"

    '        strSQL += vbCrLf & "  FROM [dbo].[PRD_TemplateChargeUnits]"
    '        strSQL += vbCrLf & strCrit
    '        strSQL += vbCrLf & " ORDER BY  [TemplateCode]"
    '        strSQL += vbCrLf & "       ,[Class]"
    '        strSQL += vbCrLf & "       ,[Product]"
    '        strSQL += vbCrLf & "      ,[ProductCCY]"
    '        strSQL += vbCrLf & "       ,[ChargesDefinedFor]"
    '        strSQL += vbCrLf & "       ,[ChargeCategory]"
    '        strSQL += vbCrLf & "       ,[Event]"

    '        If bRefreshChargeUnit = True Then
    '            ''conn.SetGrid(strSQL, grd_unit)
    '            dtChgUnit = conn.BindingDT(strSQL, "Tb_ChgUnit")

    '            If dtChgUnit.Rows.Count > 0 Then
    '                grd_unit.DataSource = dtChgUnit

    '                For i = 0 To grd_unit.Columns.Count - 1
    '                    grd_unit.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    '                Next

    '                grd_unit.Columns("ApplyMinchgAmount").DefaultCellStyle.Format = "###,###0.00"
    '                grd_unit.Columns("ApplyMinchgAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '                grd_unit.Columns("ApplyMaxChgAmount").DefaultCellStyle.Format = "###,###0.00"
    '                grd_unit.Columns("ApplyMaxChgAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '                grd_unit.Columns("RoundingAmount").DefaultCellStyle.Format = "###,###0.00"
    '                grd_unit.Columns("RoundingAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '                For i = 1 To 4
    '                    grd_unit.Columns("LowerLimit" & i.ToString).DefaultCellStyle.Format = "###,###0.00"
    '                    grd_unit.Columns("LowerLimit" & i.ToString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '                    grd_unit.Columns("UpperLimit" & i.ToString).DefaultCellStyle.Format = "###,###0.00"
    '                    grd_unit.Columns("UpperLimit" & i.ToString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '                    grd_unit.Columns("FixedAmount" & i.ToString).DefaultCellStyle.Format = "###,###0.00"
    '                    grd_unit.Columns("FixedAmount" & i.ToString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    '                    grd_unit.Columns("BasisPoints" & i.ToString).DefaultCellStyle.Format = "###,###0.00"
    '                    grd_unit.Columns("BasisPoints" & i.ToString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                Next
    '            End If

    '        End If

    '        ': grd_unit.Columns.Item(0).Visible = False
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try
    'End Sub



    'Private Sub btnDeleteEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteEvent.Click

    '    Try
    '        If MsgBox("Do you want to delete.", vbYesNo, "confirm") = Windows.Forms.DialogResult.Yes Then
    '            Dim strEvent As String = ""
    '            strEvent = grd_Event.CurrentRow.Cells(COL_GRD_EVENT_EVENT_CODE).Value
    '            If strEvent = "" Then Exit Sub
    '            Dim strSQL As String = ""
    '            strSQL = ""
    '            strSQL += " delete from Inquiry_TemplateChargeEvents"
    '            strSQL += " where ID='" & txt_GUID.Text & "' "
    '            strSQL += " and [Event]='" & strEvent & "' "
    '            conn.ExecuteNonQuery(strSQL)
    '            Call UpGrid_Template_EventsAndUnit(True, False)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try
    'End Sub

    'Private Sub btnNewEvent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewEvent.Click

    '    Try
    '        Dim mFrm_TemplateChargeEvent_Edit As New Frm_TemplateChargeEvent_Edit
    '        mFrm_TemplateChargeEvent_Edit.strMODE = "ADD"
    '        mFrm_TemplateChargeEvent_Edit.txt_GUID.Text = txt_GUID.Text
    '        mFrm_TemplateChargeEvent_Edit.txt_TemplateCode.Text = txt_new_template.Text
    '        mFrm_TemplateChargeEvent_Edit.cbo_Event.Text = ""
    '        mFrm_TemplateChargeEvent_Edit.ShowDialog()
    '        Call UpGrid_Template_EventsAndUnit(True, False)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try

    'End Sub

    

    'Private Sub btnNewUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewUnit.Click
    '    Try
    '        Dim str_row_id As String = ""


    '        '   str_row_id = grd_unit.CurrentRow.Cells(0).Value
    '        ' If str_row_id = "" Then Exit Sub

    '        Dim mFrm_Frm_TemplateChargeUnit_Edit As New Frm_TemplateChargeUnit_Edit
    '        mFrm_Frm_TemplateChargeUnit_Edit.strMODE = "ADD"
    '        mFrm_Frm_TemplateChargeUnit_Edit.txt_GUID.Text = txt_GUID.Text
    '        mFrm_Frm_TemplateChargeUnit_Edit.txt_TemplateCode.Text = txt_new_template.Text
    '        mFrm_Frm_TemplateChargeUnit_Edit.txt_row_id.Text = "" ' str_row_id
    '        ' mFrm_Frm_TemplateChargeUnit_Edit.cbo_Event.Text = strEvent
    '        mFrm_Frm_TemplateChargeUnit_Edit.ShowDialog()
    '        Call UpGrid_Template_EventsAndUnit(False, True)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try
    'End Sub

    Private Sub btnDeleteUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteUnit.Click
        Dim str_row_id As String
        Dim strSQL As String = ""

        Try
            If grd_unit.RowCount <= 0 Then Exit Sub

            If MsgBox("Do you want to delete.", vbYesNo, "confirm") = Windows.Forms.DialogResult.Yes Then

                str_row_id = grd_unit.CurrentRow.Cells(0).Value

                If str_row_id = "" Then Exit Sub

                'Call UpGrid_Template_EventsAndUnit(True, False)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub


End Class