Imports Template_Application.CSQL
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Frm_TemplateProduct_list
    Dim conn As CSQL
    Dim res As SqlDataReader
    Dim sql_cmd As String, add_cmd As String
    Private Const strALL = "--------Please select--------"
    Private Const strNoFloat = "---------NO FLOAT------------"

    Public IS_RETURN As Boolean = False
    Public OBJ_COMBOBOX As ComboBox
    Public txt_product_template_new As TextBox
    Public strProduct_sendto As String = ""



    Private Sub FillCombo_BeneAdviceOn()

        cbo_BeneAdviceOn.Items.Clear()
        cbo_BeneAdviceOn.Items.Add(strALL)
        cbo_BeneAdviceOn.Items.Add("NONE")
        cbo_BeneAdviceOn.Items.Add("Data Entry")
        cbo_BeneAdviceOn.Items.Add("Debit Confirm")

        If cbo_Product.Text.Substring(0, 3) = "COC" Or cbo_Product.Text.Substring(0, 3) = "COE" Then
            cbo_BeneAdviceOn.Items.Add("Print")
        End If

        cbo_BeneAdviceOn.Items.Add("(All)")

    End Sub

    Private Sub Frm_TemplateProduct_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim strSQL As String = ""

            conn = New CSQL
            conn.Connect()

            ' For Fill cbo_Product
            'strSQL = "select distinct Product from dbo.PRD_TemplateProduct order by Product"
            strSQL = conn.GetSQL_LIST_PRODUCT_MST
            conn.Fill_ComboBox(strSQL, cbo_Product, strALL)
            If cbo_Product.Items.Count > 0 Then cbo_Product.SelectedIndex = 0


            ' For Fill cbo_DafaultArrangement
            strSQL = "select distinct DafaultArrangement from dbo.PRD_TemplateProduct order by DafaultArrangement"
            conn.Fill_ComboBox(strSQL, cbo_DafaultArrangement, strALL)
            If cbo_DafaultArrangement.Items.Count > 0 Then cbo_DafaultArrangement.SelectedIndex = 0


            ' For Fill cbo_FloatSharingPercentage
            strSQL = "select distinct FloatSharingPercentage from dbo.PRD_TemplateProduct order by FloatSharingPercentage"
            conn.Fill_ComboBox(strSQL, cbo_FloatSharingPercentage, strNoFloat)
            If cbo_FloatSharingPercentage.Items.Count > 0 Then cbo_FloatSharingPercentage.SelectedIndex = 0


            ' For Fill cbo_CustomerFloatRate1
            strSQL = "select  BASE_RATE_CODE  + ' (' +  cast(BASE_RATE as varchar) + ') ' +  cast( [BASE_RATE_DESCRIPTION] as nvarchar(150)) as cc from dbo.BASE_RATES_MST  where BASE_RATE_CODE in (select  CustomerFloatRate1 from dbo.PRD_TemplateProduct ) order by BASE_RATE_CODE  "
            conn.Fill_ComboBox(strSQL, cbo_CustomerFloatRate1, strNoFloat)
            If cbo_CustomerFloatRate1.Items.Count > 0 Then cbo_CustomerFloatRate1.SelectedIndex = 0
            'cbo_CustomerFloatRate1

            ' For Fill cbo_BeneAdviceOn
            'strSQL = "select distinct BeneAdviceOn from dbo.PRD_TemplateProduct order by BeneAdviceOn"
            'conn.Fill_ComboBox(strSQL, cbo_BeneAdviceOn, strALL)
            'If cbo_BeneAdviceOn.Items.Count > 0 Then cbo_BeneAdviceOn.SelectedIndex = 0
            'cbo_BeneAdviceOn

            Call FillCombo_BeneAdviceOn()

            'cbo_BeneAdviceOn.Text = strALL '"Debit Confirm"
            cbo_BeneAdviceOn.Text = "NONE"


            If strProduct_sendto <> "" Then
                cbo_Product.SelectedIndex = cbo_Product.FindString(strProduct_sendto)
            End If

            ' Call SetGrid()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txt_Template.Text = DataGridView1.CurrentRow.Cells(0).Value
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Template_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Template.TextChanged


    End Sub

    Private Sub Frm_TemplateProduct_list_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        On Error Resume Next
        DataGridView1.Width = Me.Width - 30
        DataGridView1.Height = (Panel1.Top - DataGridView1.Top) - 20
        grp_search.Width = Me.Width - 30
    End Sub

    Private Sub BT_Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If cbo_Product.Text = "" Or cbo_Product.Text = strALL Then
            MsgBox("Please select product code.")
            Exit Sub
        End If

        If DataGridView1.RowCount > 0 Then
            Call AddData()
        Else
            Call AddData_from_Criteria()
        End If

    End Sub

    Private Sub AddData_from_Criteria()
        Dim f As New Frm_TemplateProduct_Edit
        f.strMODE = "ADD"

        If cbo_Product.Text <> strALL And cbo_Product.Text <> "" Then
            f.cbo_Product.Text = cbo_Product.Text
        End If

        'Call f.AutoLastNumber()
        f.txt_TemplateCode.Text = "" 'cbo_Template.Text.Replace(strBlankForm, "")
        'fill data from criteria
        If opt_GLRejectCharges_Yes.Checked = True Then f.opt_GLRejectCharges_Yes.Checked = True
        If opt_GLRejectCharges_No.Checked = True Then f.opt_GLRejectCharges_No.Checked = True

        If opt_AdviceFaxRequired_Yes.Checked = True Then f.opt_AdviceFaxRequired_Yes.Checked = True
        If opt_AdviceFaxRequired_No.Checked = True Then f.opt_AdviceFaxRequired_No.Checked = True

        If opt_AdviceEmailRequired_Yes.Checked = True Then f.opt_AdviceEmailRequired_Yes.Checked = True
        If opt_AdviceEmailRequired_No.Checked = True Then f.opt_AdviceEmailRequired_No.Checked = True

        If opt_RepostGL_Yes.Checked = True Then f.opt_RepostGL_Yes.Checked = True
        If opt_RepostGL_No.Checked = True Then f.opt_RepostGL_No.Checked = True

        'If opt_GLRepostType1.Checked = True Then f.opt_GLRepostType1.Checked = True
        'If opt_GLRepostType2.Checked = True Then f.opt_GLRepostType2.Checked = True
        'If opt_GLRepostType3.Checked = True Then f.opt_GLRepostType3.Checked = True

        If opt_ExportDownloadReq_Yes.Checked = True Then f.opt_ExportDownloadReq_Yes.Checked = True
        If opt_ExportDownloadReq_No.Checked = True Then f.opt_ExportDownloadReq_No.Checked = True

        If cbo_BeneAdviceOn.Text <> "" And cbo_BeneAdviceOn.Text <> strALL Then f.cbo_BeneAdviceOn.Text = cbo_BeneAdviceOn.Text

        If cbo_CustomerFloatRate1.Text <> strALL And cbo_CustomerFloatRate1.Text <> "" Then
            f.opt_CustomerFloatComputation_Yes.Checked = True
            f.cbo_CustomerFloatRate1.Text = cbo_CustomerFloatRate1.Text
        End If


        f.ShowDialog()
    End Sub

    Private Sub AddData()
        If txt_Template.Text = "" Then
            MessageBox.Show("Invalid Template Code. Please selection Template code.")
            Exit Sub
        End If

        Dim f As New Frm_TemplateProduct_Edit
        f.strMODE = "ADD"
        f.strID = ""
        f.txt_TemplateCode.Text = txt_Template.Text
        f.cbo_Product.Text = cbo_Product.Text
        f.cbo_Product.Enabled = False

        f.ShowDialog()
        Call SetGrid()
    End Sub

    Private Sub EditData()
        If txt_Template.Text = "" Then
            MessageBox.Show("Invalid Template Code. Please selection Template code.")
            Exit Sub
        End If

        Dim f As New Frm_TemplateProduct_Edit
        f.strMODE = "EDIT"
        f.strID = ""
        f.txt_TemplateCode.Text = txt_Template.Text
        f.txt_new_template.Text = "Edit Mode"
        f.ShowDialog()
        Call SetGrid()

        Dim mFrm_Maintainance_Status_Entry As New Frm_Maintainance_Status_Entry
        mFrm_Maintainance_Status_Entry.strID = txt_Template.Text
        mFrm_Maintainance_Status_Entry.strMODE = "EDIT"
        mFrm_Maintainance_Status_Entry.ShowDialog()
        Call SetGrid()
    End Sub


    Private Sub btn_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print.Click
        Try
            If txt_Template.Text = "" Then
                MessageBox.Show("Invalid Template Code. Please selection Template code.")
                Exit Sub
            End If

            If txt_Deal_ID.Text = "" Then
                MessageBox.Show("Invalid Template Code. Please selection  [Deal ID].")
                Exit Sub
            End If

            Dim mFrmPrint_InputDescription As New FrmPrint_InputDescription
            mFrmPrint_InputDescription.txt_clientcode.Text = txt_Deal_ID.Text
            mFrmPrint_InputDescription.txt_template_code.Text = txt_Template.Text
            mFrmPrint_InputDescription.strReportName = "product"

            If Not (opt_AdviceFaxRequired_Yes.Checked = True Or opt_AdviceEmailRequired_Yes.Checked = True) Then
                mFrmPrint_InputDescription.strWarnning = ""
            End If

            mFrmPrint_InputDescription.ShowDialog()


            'Dim FrmReport As New FrmReport
            'FrmReport.ReportType = "TemplateProduct"

            ''FrmReport.SQL = "select * from dbo.PRD_TemplateProduct where TemplateCode = '" & txt_Template.Text & "' order by TemplateCode"
            'FrmReport.SQL = ""
            'FrmReport.SQL += "   SELECT a.*,CustomerFloatRate1  + '(' + cast(b.BASE_RATE as varchar) + ')'as CustomerFloatRate2"
            'FrmReport.SQL += " FROM dbo.PRD_TemplateProduct a"
            'FrmReport.SQL += " left outer join  dbo.BASE_RATES_MST b"
            'FrmReport.SQL += " on a.CustomerFloatRate1=b.BASE_RATE_CODE"
            'FrmReport.SQL += " where TemplateCode = '" & txt_Template.Text & "' order by TemplateCode"

            'FrmReport.strSQL_PRD_Template = "SELECT * FROM PRD_Template where TemplateCode = '" & txt_Template.Text & "' order by TemplateCode"
            'FrmReport.strSQL_PRD_TemplateProductArrangements = "SELECT * FROM PRD_TemplateProductArrangements where TemplateCode = '" & txt_Template.Text & "' order by TemplateCode"
            'FrmReport.strSQL_PRD_TemplateProductClearingLocation = "SELECT * FROM PRD_TemplateProductClearingLocation where TemplateCode = '" & txt_Template.Text & "' order by TemplateCode"
            ''strSQL_PRD_TemplateInstrumentEnrichments
            'FrmReport.strSQL_PRD_TemplateInstrumentEnrichments = "SELECT * FROM PRD_TemplateInstrumentEnrichments where TemplateCode = '" & txt_Template.Text & "' order by TemplateCode"

            'FrmReport.ShowDialog()
            If IS_RETURN = True Then
                OBJ_COMBOBOX.Text = txt_Template.Text
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub



    Private Sub RefreshDataList()
        txt_Template.Text = ""
        Call SetGrid()

        If cbo_Product.Text <> strALL And cbo_Product.Text <> "" Then
            btn_create.Enabled = True
        Else
            btn_create.Enabled = False
        End If
    End Sub

    Private Function GetCustomerFloatRate1(ByVal strData As String) As String
        Dim vnt
        Dim strDataTmp As String = ""
        vnt = strData.ToString.Split("(")
        If UBound(vnt) = 1 Then
            strDataTmp = vnt(0)
            strDataTmp = Trim(strDataTmp)

        End If
        Return strDataTmp

    End Function

    Private Sub SetGrid()
        Try
            Dim strSQL As String = ""
            Dim strCrit As String = ""

            strSQL = "SELECT "

            strSQL += " a.[TemplateCode]"

            strSQL += " , a.AdviceFaxRequired as [Advice Fax Request]"
            strSQL += " , a.AdviceEmailRequired as [Advice Email Request]"
            strSQL += " , a.BeneAdviceOn as [Bene Advice ON] "
            strSQL += " , a.ExportDownloadReq as [JP MORGAN GROUP]"


            strSQL += " , a.CustomerFloatRate1 + '(' +  CAST(BASE_RATE AS VARCHAR)  + ')' AS  [Customer Float Computation] "
            strSQL += " , a.CustomerFloatComputation as [Float Sharing Percentage] "

            strSQL += " , a.StalePeriodType"
            strSQL += " , a.StalePeriod"

            strSQL += " , a.RepostGL"
            strSQL += " , a.GLRepostType"

            strSQL += " , a.Product"
            strSQL += " , a.Line"
            strSQL += " , a.TxnLimitLevel"
            strSQL += " , a.PerTxnMinAmnt"
            strSQL += " , a.PerTxnMaxAmnt"
            strSQL += " , a.InstEnrichment"
            strSQL += " , a.DafaultArrangement"
            strSQL += " , a.GLRejectCharges"
            'strSQL += " , a.AdviceFaxRequired"
            'strSQL += " , a.AdviceEmailRequired"
            strSQL += " , a.FloatSharingPercentage"
            strSQL += " , a.EffectiveFrom"
            strSQL += " , a.ReviewOn"
            strSQL += " , a.ChargesReviewOn"

            strSQL += " , a.RefundAtStale"
            strSQL += " , a.InstNoGeneration"
            strSQL += " , a.TAXSequence"
            strSQL += " , a.VATApplicable"
            strSQL += " , a.WHTRefundApplicable"
            strSQL += " , a.WHTRedundRate1"
            'strSQL += " , a.CustomerFloatComputation"
            'strSQL += " , a.CustomerFloatRate1 + '(' +  CAST(BASE_RATE AS VARCHAR)  + ')' AS  CustomerFloatRate1"
            'strSQL += " , a.RepostGL"
            'strSQL += " , a.GLRepostType"
            ' strSQL += " , a.ExportDownloadReq"
            'strSQL += " , a.BeneAdviceOn "

            strSQL += " FROM [PRD_TemplateProduct] a "
            strSQL += " left outer join  dbo.BASE_RATES_MST b "
            strSQL += " on a.CustomerFloatRate1=b.BASE_RATE_CODE"

            strCrit = ""

            If cbo_Product.Text.Length > 0 And cbo_Product.Text <> strALL Then

                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [TemplateCode]  in (select TemplateCode from dbo.PRD_Template where StatusTemplate='Y')"

                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [Product] = '" + cbo_Product.Text.Substring(0, 3) + "' "
                'add maindatory criteria

                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " TxnLimitLevel='INSTRUMENTS' "
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " PerTxnMinAmnt=0.01 "
                If cbo_Product.Text.Substring(0, 3) = "MCL" Or cbo_Product.Text.Substring(0, 3) = "MCS" Or cbo_Product.Text.Substring(0, 3) = "PCL" Then
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " PerTxnMaxAmnt=2000000 "
                Else
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " PerTxnMaxAmnt=99999999999.99 "
                End If

                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " InstEnrichment='YES' "
                'DafaultArrangement
                Dim strDafaultArrangement As String = ""
                Select Case cbo_Product.Text.Substring(0, 3)
                    Case "COC"
                        strDafaultArrangement = "D-1"
                    Case "MCL", "PCL"
                        strDafaultArrangement = "D-2"
                    Case Else
                        strDafaultArrangement = "D+0"
                End Select

                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " DafaultArrangement='" & strDafaultArrangement & "' "
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " GLRejectCharges='NO' "

                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper(StalePeriodType)=upper('Monthly') "

                'If cbo_Product.Text.Substring(0, 3) = "COC" Or cbo_Product.Text.Substring(0, 3) = "COE" Then
                '    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " StalePeriod='12' "
                'Else
                '    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " StalePeriod='1' "
                'End If

                If cbo_Product.Text.Substring(0, 3) = "COC" Or cbo_Product.Text.Substring(0, 3) = "COE" Then

                    If rad_StalePeriodType_M.Checked = True Then
                        strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([StalePeriodType]) = 'MONTHLY' "
                    Else
                        strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([StalePeriodType]) = 'DAILY' "
                    End If


                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [StalePeriod] = '" + CDbl(txt_StalePeriod.Text).ToString & "'"
                Else
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([StalePeriodType]) = 'MONTHLY' "
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " StalePeriod='1' "
                End If

                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper(RefundAtStale)='NO' "
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper(InstNoGeneration)=upper('Generated by System') "
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper(TAXSequence)='NONE' "
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper(VATApplicable)='NO' "
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper(WHTRefundApplicable)='NO' "


            End If


            If opt_AdviceFaxRequired_Yes.Checked = True Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([AdviceFaxRequired]) = 'YES' "
            Else
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([AdviceFaxRequired]) = 'NO' "
            End If

            If opt_AdviceEmailRequired_Yes.Checked = True Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([AdviceEmailRequired]) = 'YES' "
            Else
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([AdviceEmailRequired]) = 'NO' "
            End If


            If cbo_BeneAdviceOn.Text.Length > 0 And cbo_BeneAdviceOn.Text <> strALL Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [BeneAdviceOn] = '" + cbo_BeneAdviceOn.Text + "' "
            End If

            If opt_ExportDownloadReq_Yes.Checked = True Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([ExportDownloadReq]) = 'YES' "
            Else
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([ExportDownloadReq]) = 'NO' "
            End If


            If cbo_Product.Text.Substring(0, 3) = "COC" Then
                'strNoFloat
                If cbo_FloatSharingPercentage.Text = strNoFloat Then
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [CustomerFloatRate1] = '' "
                Else
                    If cbo_FloatSharingPercentage.Text.Length > 0 Then
                        strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [FloatSharingPercentage] = '" + cbo_FloatSharingPercentage.Text + "' "
                    End If

                    If cbo_CustomerFloatRate1.Text.Length > 0 Then
                        strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [CustomerFloatRate1] = '" + GetCustomerFloatRate1(cbo_CustomerFloatRate1.Text) + "' "
                    End If
                End If


            End If



            If cbo_Product.Text.Substring(0, 3) = "PCT" Then

                'If opt_GLRepostType1.Checked = False Then
                '    If opt_GLRepostType2.Checked = False Then
                '        strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([GLRepostType]) = 'NONE' "
                '    Else
                '        strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([GLRepostType]) = 'MANUAL' "
                '    End If
                'Else
                '    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([GLRepostType]) = 'AUTOMATIC' "
                'End If

                If opt_RepostGL_Yes.Checked = True Then
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([RepostGL]) = 'YES'  and upper([GLRepostType]) = 'MANUAL' "
                Else
                    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([RepostGL]) = 'NO' and upper([GLRepostType]) = 'NONE' "
                End If

            End If


            'If cbo_DafaultArrangement.Text.Length > 0 And cbo_DafaultArrangement.Text <> strALL Then
            '    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [DafaultArrangement] = '" + cbo_DafaultArrangement.Text + "' "
            'End If


            'If opt_GLRejectCharges_Yes.Checked = True Then
            '    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([GLRejectCharges]) = 'YES'"
            'Else
            '    strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " upper([GLRejectCharges]) = 'NO'"
            'End If

            If strCrit.Length > 0 Then
                strSQL += vbCrLf & strCrit
            End If

            strSQL += vbCrLf & " ORDER BY [TemplateCode]"


            conn.SetGrid(strSQL, DataGridView1)

            If DataGridView1.RowCount > 0 Then
                DataGridView1.Rows.Item(0).Selected = True


                Try
                    txt_Template.Text = DataGridView1.CurrentRow.Cells(0).Value
                Catch ex As Exception
                    Exit Sub
                End Try

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub SetAllComboBox()
        Dim strSQL As String = ""
        Dim strCrit As String = ""


        If cbo_Product.Text <> strALL Then
            strCrit = "where product='" & cbo_Product.Text.Substring(0, 3).Replace("'", "''") & "'"
        Else
            strCrit = ""
        End If

        ' For Fill cbo_DafaultArrangement
        strSQL = "select distinct DafaultArrangement from dbo.PRD_TemplateProduct " & strCrit & " order by DafaultArrangement"
        conn.Fill_ComboBox(strSQL, cbo_DafaultArrangement, strALL)
        ' If cbo_DafaultArrangement.Items.Count > 0 Then cbo_DafaultArrangement.SelectedIndex = 0


        ' For Fill cbo_FloatSharingPercentage
        strSQL = "select distinct FloatSharingPercentage from dbo.PRD_TemplateProduct " & strCrit & " order by FloatSharingPercentage"
        conn.Fill_ComboBox(strSQL, cbo_FloatSharingPercentage, strALL)
        ' If cbo_FloatSharingPercentage.Items.Count > 0 Then cbo_FloatSharingPercentage.SelectedIndex = 0


        ' For Fill cbo_CustomerFloatRate1
        ' strSQL = "select distinct CustomerFloatRate1 from dbo.PRD_TemplateProduct " & strCrit & " order by CustomerFloatRate1"
        strSQL = "select  BASE_RATE_CODE  + ' (' +  cast(BASE_RATE as varchar) + ')' as cc from dbo.BASE_RATES_MST  where BASE_RATE_CODE in (select  CustomerFloatRate1 from dbo.PRD_TemplateProduct  " & strCrit & " )  order by BASE_RATE_CODE"
        conn.Fill_ComboBox(strSQL, cbo_CustomerFloatRate1, strALL)
        ' If cbo_CustomerFloatRate1.Items.Count > 0 Then cbo_CustomerFloatRate1.SelectedIndex = 0

        ' For Fill cbo_BeneAdviceOn
        strSQL = "select distinct BeneAdviceOn from dbo.PRD_TemplateProduct " & strCrit & " order by BeneAdviceOn"
        conn.Fill_ComboBox(strSQL, cbo_BeneAdviceOn, strALL)
        ' If cbo_BeneAdviceOn.Items.Count > 0 Then cbo_BeneAdviceOn.SelectedIndex = 0
    End Sub

    Private Sub cbo_Product_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Product.SelectedIndexChanged
        pnl_RepostGL.Enabled = False
        'pnl_GLRepostType.Enabled = False
        cbo_CustomerFloatRate1.Enabled = False
        cbo_FloatSharingPercentage.Enabled = False

        pnl_StalePeriodType_D.Enabled = False
        txt_StalePeriod.Enabled = False
        txt_StalePeriod.Text = ""
        txt_StalePeriod.BackColor = Color.Gray

        If cbo_Product.Text <> "" And cbo_Product.Text <> strALL Then
            btn_Find.Enabled = True
        End If

        Call FillCombo_BeneAdviceOn()

        Select Case cbo_Product.Text.Substring(0, 3)
            Case "PCT"
                pnl_RepostGL.Enabled = True
                ' pnl_GLRepostType.Enabled = True
            Case "COC"
                cbo_CustomerFloatRate1.Enabled = True
                cbo_FloatSharingPercentage.Enabled = True

                pnl_StalePeriodType_D.Enabled = True
                txt_StalePeriod.Enabled = True
                txt_StalePeriod.BackColor = Color.White
                txt_StalePeriod.Text = "12"
                ' cbo_BeneAdviceOn.Text = "Print"
            Case "COE"

                pnl_StalePeriodType_D.Enabled = True
                txt_StalePeriod.Enabled = True
                txt_StalePeriod.BackColor = Color.White
                txt_StalePeriod.Text = "12"
                'cbo_BeneAdviceOn.Text = "Print"
            Case Else
                'cbo_BeneAdviceOn.Text = "Debit Confirm"

        End Select
    End Sub



    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If txt_Template.Text = "" Then Exit Sub
            If MsgBox("Do you want to delete?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then Exit Sub
            Dim strSQL As String = ""

            strSQL = ""
            strSQL += " delete from dbo.PRD_TemplateProduct where TemplateCode='" & txt_Template.Text.Replace("'", "''") & "' " & vbCrLf
            strSQL += " delete from dbo.PRD_Template where TemplateCode='" & txt_Template.Text.Replace("'", "''") & "' " & vbCrLf
            Dim strErr As String = conn.ExecuteNonQuery(strSQL)
            If strErr = "" Then
                Call RefreshDataList()
            Else
                MsgBox(strErr)
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub RefreshData()
        If cbo_Product.Text = "" Or cbo_Product.Text = strALL Then
            MsgBox("Invalid Product")
            Exit Sub
        End If

        Select Case cbo_Product.Text.Substring(0, 3)


            Case "COC"
                If cbo_CustomerFloatRate1.Text <> "" And cbo_CustomerFloatRate1.Text <> strNoFloat Then
                    If cbo_FloatSharingPercentage.Text = "" Or cbo_FloatSharingPercentage.Text = strNoFloat Then
                        MsgBox("Invalid [Float Sharing Percentage]")
                        Exit Sub
                    End If
                End If

                If cbo_FloatSharingPercentage.Text <> "" And cbo_FloatSharingPercentage.Text <> strNoFloat Then
                    If cbo_CustomerFloatRate1.Text = "" Or cbo_CustomerFloatRate1.Text = strNoFloat Then
                        MsgBox("Invalid [Customer Float Computation]")
                        Exit Sub
                    End If

                End If
                'txt_StalePeriod
                If txt_StalePeriod.Text <> "" Then
                    If IsNumeric(txt_StalePeriod.Text) = False Then
                        MsgBox("Invalid [StalePeriod]")
                        Exit Sub
                    End If
                Else
                    MsgBox("Invalid [StalePeriod]")
                    Exit Sub
                End If

            Case "COE"
                If txt_StalePeriod.Text <> "" Then
                    If IsNumeric(txt_StalePeriod.Text) = False Then
                        MsgBox("Invalid [StalePeriod]")
                        Exit Sub
                    End If
                Else
                    MsgBox("Invalid [StalePeriod]")
                    Exit Sub
                End If
            Case Else


        End Select




        Call RefreshDataList()
    End Sub

    Private Sub btn_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Find.Click

        Call RefreshData()
    End Sub

    Private Sub bt_close_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub



    Private Sub btnPrint_Detail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint_Detail.Click
        Try
            If txt_Template.Text = "" Then
                MessageBox.Show("Invalid Template Code. Please selection Template code.")
                Exit Sub
            End If

            Dim FrmReport As New FrmReport
            FrmReport.ReportType = "TemplateProduct"
            FrmReport.SQL = ""
            FrmReport.SQL += "   SELECT a.*,CustomerFloatRate1  + '(' + cast(b.BASE_RATE as varchar) + ')'   +  '  ' +    cast( [BASE_RATE_DESCRIPTION] as nvarchar(150))  as CustomerFloatRate2"
            FrmReport.SQL += " FROM dbo.PRD_TemplateProduct a"
            FrmReport.SQL += " left outer join  dbo.BASE_RATES_MST b"
            FrmReport.SQL += " on a.CustomerFloatRate1=b.BASE_RATE_CODE"
            FrmReport.SQL += " where TemplateCode = '" & txt_Template.Text & "' order by TemplateCode"

            FrmReport.strSQL_PRD_Template = "SELECT * FROM PRD_Template where TemplateCode = '" & txt_Template.Text & "' order by TemplateCode"
            FrmReport.strSQL_PRD_TemplateProductArrangements = "SELECT * FROM PRD_TemplateProductArrangements where TemplateCode = '" & txt_Template.Text & "' order by TemplateCode"
            FrmReport.strSQL_PRD_TemplateProductClearingLocation = "SELECT * FROM PRD_TemplateProductClearingLocation where TemplateCode = '" & txt_Template.Text & "' order by TemplateCode"
            FrmReport.strSQL_PRD_TemplateInstrumentEnrichments = "SELECT * FROM PRD_TemplateInstrumentEnrichments where TemplateCode = '" & txt_Template.Text & "' order by TemplateCode"
            FrmReport.strLine(0) = txt_Deal_ID.Text

            FrmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub txt_Template_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Template.Validated
        btn_create.Enabled = False

        If txt_Template.Text.Length > 0 Then
            btn_create.Enabled = True

            Dim strSQL As String = "select StatusTemplate from dbo.PRD_Template where TemplateCode='" & txt_Template.Text.Replace("'", "''") & "'"
            Dim strValue As String = conn.GetDataFromSQL(strSQL, 0)
            If strValue = "" Then
                MsgBox("Invalid, This ref is not found.")
                txt_Template.Text = ""
                Exit Sub
            End If
            If strValue = "Y" Then
                btn_Delete.Enabled = True
            Else
                btn_Delete.Enabled = False
            End If


        End If
    End Sub

    Private Sub btnSendTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendTo.Click
        If IS_RETURN = True Then
            OBJ_COMBOBOX.Text = txt_Template.Text
            Me.Close()
        End If
    End Sub

    Private Sub btn_new_template_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_template.Click
        If cbo_Product.Text = "" Then
            MsgBox("Please Product Code.")
            Exit Sub
        End If

        Dim f As New Frm_TemplateProduct_Edit
        f.strMODE = "ADD"
        ' f.txt_new_template.Text = txt_new_template.Text
        f.cbo_Product.Text = cbo_Product.Text
        f.cbo_Product.Enabled = False
        f.txt_return = txt_Return
        f.bNewFlag = True

        Dim strSQL As String = ""
        strSQL = "SELECT top 1 [TemplateCode] FROM [PRD_TemplateProduct] "
        strSQL += " where Product='" & cbo_Product.Text.Substring(0, 3).Replace("'", "''") & "' ORDER BY [TemplateCode] "


        f.txt_TemplateCode.Text = conn.GetDataFromSQL(strSQL) 'cbo_Template.Text.Replace(strBlankForm, "")
        ' Me.Close()
        f.ShowDialog()
        Call RefreshData()
        If txt_Return.Text <> "" Then
            OBJ_COMBOBOX.Text = txt_Return.Text
            txt_product_template_new.Text = txt_Return.Text
            Me.Close()
        End If
    End Sub
End Class