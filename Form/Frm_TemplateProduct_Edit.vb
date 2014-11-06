Imports Template_Application.CSQL
Imports System.Data.SqlClient
'Imports System.Drawing.Printing

Public Class Frm_TemplateProduct_Edit

    Public strID As String = ""
    Public strMODE As String = "ADD"
    Private Const strALL = "--------Select--------"
    Private Const strNoFloat = "---------NO FLOAT------------"

    Private Const strSingleProduct = "Single-Product"
    Private Const strProductChare = "Product Charge"

    Dim conn As CSQL
    Dim res As SqlDataReader
    Dim sql_cmd As String, add_cmd As String

    Public bNewFlag As Boolean = False
    Public txt_return As TextBox


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

    Private Sub SetScrenByProduct()

        pnl_CustomerFloat.Enabled = False
        cbo_CustomerFloatRate1.Enabled = False
        cbo_FloatSharingPercentage.Enabled = False
        pnl_RepostGL.Enabled = False
        pnl_GLReportType.Enabled = False

        Select Case cbo_Product.Text.Substring(0, 3)
            Case "PCT"
                pnl_RepostGL.Enabled = True
                pnl_GLReportType.Enabled = True
            Case "COC"
                pnl_CustomerFloat.Enabled = True
                cbo_CustomerFloatRate1.Enabled = True
                cbo_FloatSharingPercentage.Enabled = True
            Case Else

        End Select

    End Sub

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

    Private Sub MDI_Child_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.KeyPreview = True

            Call SetScrenByProduct()
          


            conn = New CSQL
            conn.Connect()
            Dim strSQL As String = ""
            ' strSQL = "select Product from dbo.PRD_TemplateProduct group by Product order by Product"
            strSQL = conn.GetSQL_LIST_PRODUCT_MST

            conn.Fill_ComboBox(strSQL, cbo_Product)
            strSQL = "select DafaultArrangement from dbo.PRD_TemplateProduct where Product='" & cbo_Product.Text.Substring(0, 3) & "' group by DafaultArrangement order by DafaultArrangement"

            conn.Fill_ComboBox(strSQL, cbo_DafaultArrangement)
            strSQL = "select FloatSharingPercentage from dbo.PRD_TemplateProduct group by FloatSharingPercentage order by FloatSharingPercentage"

            conn.Fill_ComboBox(strSQL, cbo_FloatSharingPercentage, strNoFloat)

            ' strSQL = "select CustomerFloatRate1 from dbo.PRD_TemplateProduct group by CustomerFloatRate1 order by CustomerFloatRate1"
            strSQL = " select  BASE_RATE_CODE  + ' (' +  cast(BASE_RATE as varchar) + ')' +  cast( [BASE_RATE_DESCRIPTION] as nvarchar(150))  as cc from dbo.BASE_RATES_MST  order by BASE_RATE_CODE"
            conn.Fill_ComboBox(strSQL, cbo_CustomerFloatRate1, strNoFloat)

            Call FillCombo_BeneAdviceOn()

            'NONE


            'If cbo_Product.Text.Substring(0, 3) <> "COC" Then
            '    cbo_BeneAdviceOn.Text = "Debit Confirm"
            'Else
            '    cbo_BeneAdviceOn.Text = "Print"
            'End If

            Call ShowData()
            ' If txt_new_template.Text = "" And strMODE = "ADD" Then Call AutoLastNumber()

            '=================default value=====================
            If txt_PerTxnMinAmnt.Text = "" Then txt_PerTxnMinAmnt.Text = "0.01"
            If cbo_Product.Text.Substring(0, 3) = "MCL" Or cbo_Product.Text.Substring(0, 3) = "MCS" Or cbo_Product.Text.Substring(0, 3) = "PCL" Then
                txt_PerTxnMaxAmnt.Text = "2000000"
            Else
                txt_PerTxnMaxAmnt.Text = "99999999999.99"
            End If
            'If txt_StalePeriodType.Text = "" Then txt_StalePeriodType.Text = "Monthly"
            'If txt_StalePeriod.Text = "" Then txt_StalePeriod.Text = "1" '"999"
            '======================================
            cbo_Product.Enabled = False
            txt_RefundAtStale.Text = "NO"

            cbo_BeneAdviceOn.Text = "NONE"

            'If cbo_Product.Text.Substring(0, 3) = "COC" Or cbo_Product.Text.Substring(0, 3) = "COE" Then
            '    cbo_BeneAdviceOn.Text = "Print"
            'Else
            '    cbo_BeneAdviceOn.Text = "Debit Confirm"
            'End If

            '======================txt_StalePeriod======================
            Select Case cbo_Product.Text.Substring(0, 3)
                Case "COC", "COE"
                    txt_StalePeriod.Text = "12"
                Case Else
                    txt_StalePeriod.Text = "1"
            End Select
            '================cbo_DafaultArrangement================
            Select Case cbo_Product.Text.Substring(0, 3)
                Case "COC"
                    cbo_DafaultArrangement.Text = "D-1"
                Case "MCL", "PCL"
                    cbo_DafaultArrangement.Text = "D-2"

                Case Else
                    cbo_DafaultArrangement.Text = "D+0"
            End Select

            Call LockControlsByProduct()

            opt_GLRepostType1.Enabled = False
            opt_GLRepostType2.Enabled = False
            opt_GLRepostType3.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""
        'txt_Deal_ID

        If txt_Deal_ID.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Deal ID]"
        End If

        If cbo_Product.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Product]"
        End If

        If cbo_DafaultArrangement.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Default Arrangment]"
        Else
            If cbo_DafaultArrangement.Text.Length > 10 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Default Arrangment]. Must be less then 11 digit. "
            End If
        End If



        If txt_StalePeriod.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [StalePeriod]"
        Else
            If IsNumeric(txt_StalePeriod.Text.Replace(",", "")) = False Then

                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [StalePeriod]"
            Else
                If CDbl(txt_StalePeriod.Text.Replace(",", "")) = 0 Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [StalePeriod] is not zero value."
                End If
            End If
        End If

        If opt_CustomerFloatComputation_Yes.Checked = True Then
            If cbo_CustomerFloatRate1.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Customer Float Computation]"
            Else
                'If cbo_CustomerFloatRate1.Text.Length > 40 Then
                '    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Customer Float Computation]. Must be less then 40 digit. "
                'End If
            End If

            If cbo_FloatSharingPercentage.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Float Sharing Percentage]"
            Else
                If IsNumeric(cbo_FloatSharingPercentage.Text.Replace(",", "")) = False Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Float Sharing Percentage]"
                End If
            End If

        End If

        If cbo_BeneAdviceOn.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Bene Advice ON]"
        Else
            If cbo_BeneAdviceOn.Text.Length > 25 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Bene Advice ON]. Must be less then 10 digit. "
            End If
        End If

        Return strErr
    End Function

    Private Function CompareTemplate() As String
        Try
            Dim qstr As String = ""
            qstr = "SELECT [TemplateCode] FROM [PRD_TemplateProduct] WHERE "
            qstr += "[Product] ='" + cbo_Product.Text.Substring(0, 3) + "' AND "
            If opt_TxnLimitLevel_No.Checked = True Then
                qstr += "[TxnLimitLevel] ='INSTRUMENTS' AND "
            Else
                qstr += "[TxnLimitLevel] ='PIR' AND "
            End If
            qstr += "[InstEnrichment] ='" + Get_Radiobox(opt_InstEnrichment_Yes, opt_InstEnrichment_No) + "' AND "
            qstr += "[DafaultArrangement] ='" + cbo_DafaultArrangement.Text + "' AND "
            qstr += "[GLRejectCharges] ='" + Get_Radiobox(opt_GLRejectCharges_Yes, opt_GLRejectCharges_No) + "' AND "
            qstr += "[AdviceFaxRequired] ='" + Get_Radiobox(opt_AdviceFaxRequired_Yes, opt_AdviceFaxRequired_No) + "' AND "
            qstr += "[AdviceEmailRequired] ='" + Get_Radiobox(opt_AdviceEmailRequired_Yes, opt_AdviceEmailRequired_No) + "' AND "
            qstr += "[FloatSharingPercentage] ='" + cbo_FloatSharingPercentage.Text + "' AND "

            If rad_StalePeriodType_M.Checked = True Then
                qstr += " upper([StalePeriodType]) ='" + "Monthly".ToUpper + "' AND "
            Else
                qstr += " upper([StalePeriodType])  ='" + "Daily".ToUpper + "' AND "
            End If

            qstr += " upper([StalePeriod])  ='" + txt_StalePeriod.Text.ToUpper + "' AND "

            If cbo_CustomerFloatRate1.Text.Length > 0 And cbo_CustomerFloatRate1.Text <> strNoFloat Then
                qstr += "[CustomerFloatComputation] ='YES' AND "
                qstr += "[CustomerFloatRate1] ='" + GetCustomerFloatRate1(cbo_CustomerFloatRate1.Text) + "' AND "
            Else
                qstr += "[CustomerFloatComputation] ='NO' AND "
            End If

            If Get_Radiobox(opt_RepostGL_Yes, opt_RepostGL_No) = "NO" Then
                qstr += "[RepostGL] ='NO' AND "
            Else
                qstr += "[RepostGL] ='YES' AND "
                qstr += "[GLRepostType] ='" + Get_Radiobox(opt_GLRepostType1, opt_GLRepostType2) + "' AND "
            End If

            qstr += "[ExportDownloadReq] ='" + Get_Radiobox(opt_ExportDownloadReq_Yes, opt_ExportDownloadReq_No) + "' AND "
            qstr += "[BeneAdviceOn] ='" + cbo_BeneAdviceOn.Text + "'"

            res = conn.GetDataReader(qstr)
            If res.HasRows Then
                res.Read()
                MsgBox("Data enter is same as template """ + res(0).ToString() + """ ")

                'Dim mFrmPrint_InputDescription As New FrmPrint_InputDescription
                'mFrmPrint_InputDescription.txt_template_code.Text = txt_TemplateCode.Text
                'mFrmPrint_InputDescription.strReportName = "product"
                'mFrmPrint_InputDescription.ShowDialog()

                Return res(0).ToString()
                Exit Function

            Else
                Return ""
            End If

            CompareTemplate = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return ""
        End Try
    End Function

    Public Sub AutoLastNumber()
        Try
            conn.Connect()
            Dim strTemplateType As String = ""
            Dim strSQL As String = ""

            If cbo_Product.Text = "" Then Exit Sub


            strTemplateType += strSingleProduct


            strSQL = "select max(TemplateCode) as TemplateCode from PRD_Template  "
            strSQL += " where ProductCode='" & cbo_Product.Text.Substring(0, 3).Replace("'", "''") & "' "
            strSQL += " and TemplateType='" & strTemplateType.Replace("'", "''") & "' "

            Dim strValue As String = conn.GetDataFromSQL(strSQL)
            Dim intMax As Double

            'product
            If strValue = "" Then
                txt_new_template.Text = cbo_Product.Text.Substring(0, 3) & "P000001"
            Else
                intMax = CDbl(strValue.Substring(strValue.Length - 6)) + 1
                txt_new_template.Text = cbo_Product.Text.Substring(0, 3) & "P" & intMax.ToString("000000")
            End If
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ShowData()
        Try
            res = conn.GetDataReader("SELECT * FROM [PRD_TemplateProduct] WHERE [TemplateCode] ='" + txt_TemplateCode.Text.Replace("'", "''") + "'")
            If res.HasRows = True Then
                res.Read()


                cbo_Product.Text = cbo_Product.Items.Item(cbo_Product.FindString(IIf(res("Product") Is System.DBNull.Value, "", res("Product").ToString()))).ToString
                txt_Line.Text = IIf(res("Line") Is System.DBNull.Value, "", res("Line").ToString())
                Set_Radiobox(opt_TxnLimitLevel_Yes, opt_TxnLimitLevel_No, res("TxnLimitLevel").ToString())
                txt_PerTxnMinAmnt.Text = IIf(res("PerTxnMinAmnt") Is System.DBNull.Value, "", res("PerTxnMinAmnt").ToString())
                txt_PerTxnMaxAmnt.Text = IIf(res("PerTxnMaxAmnt") Is System.DBNull.Value, "", res("PerTxnMaxAmnt").ToString())

                Set_Radiobox(opt_InstEnrichment_Yes, opt_InstEnrichment_No, res("InstEnrichment").ToString())
                cbo_DafaultArrangement.Text = IIf(res("DafaultArrangement") Is System.DBNull.Value, "", res("DafaultArrangement").ToString())
                Set_Radiobox(opt_GLRejectCharges_Yes, opt_GLRejectCharges_No, res("GLRejectCharges").ToString())
                Set_Radiobox(opt_AdviceFaxRequired_Yes, opt_AdviceFaxRequired_No, res("AdviceFaxRequired").ToString())
                Set_Radiobox(opt_AdviceEmailRequired_Yes, opt_AdviceEmailRequired_No, res("AdviceEmailRequired").ToString())

                cbo_FloatSharingPercentage.Text = res("FloatSharingPercentage").ToString() ' cbo_FloatSharingPercentage.Items.Item(cbo_FloatSharingPercentage.FindString(res("FloatSharingPercentage").ToString()))

                Set_Radiobox(opt_AdviceEmailRequired_Yes, opt_AdviceEmailRequired_No, res("AdviceEmailRequired").ToString())
                Set_Radiobox(opt_CustomerFloatComputation_Yes, opt_CustomerFloatComputation_No, res("CustomerFloatComputation").ToString())
                cbo_CustomerFloatRate1.Text = cbo_CustomerFloatRate1.Items(cbo_CustomerFloatRate1.FindString(IIf(res("CustomerFloatRate1") Is System.DBNull.Value, "", res("CustomerFloatRate1").ToString())))

                txt_ReviewOn.Text = IIf(res("ReviewOn") Is System.DBNull.Value, "", res("ReviewOn").ToString())
                txt_ChargesReviewOn.Text = IIf(res("ReviewOn") Is System.DBNull.Value, "", res("ReviewOn").ToString())
                txt_EffectiveFrom.Text = IIf(res("EffectiveFrom") Is System.DBNull.Value, "", res("EffectiveFrom").ToString())

                'If IIf(res("StalePeriodType") Is System.DBNull.Value, "", res("StalePeriodType").ToString()).ToString.ToUpper = "Monthly".ToUpper Then
                '    rad_StalePeriodType_M.Checked = True
                'Else
                '    rad_StalePeriodType_D.Checked = True
                'End If

                'txt_StalePeriod.Text = IIf(res("StalePeriod") Is System.DBNull.Value, "", res("StalePeriod").ToString())

                txt_InstNoGeneration.Text = IIf(res("InstNoGeneration") Is System.DBNull.Value, "", res("InstNoGeneration").ToString())
                txt_TAXSequence.Text = IIf(res("TAXSequence") Is System.DBNull.Value, "", res("TAXSequence").ToString())
                txt_VATApplicable.Text = IIf(res("VATApplicable") Is System.DBNull.Value, "", res("VATApplicable").ToString())
                txt_WHTRefundApplicable.Text = IIf(res("WHTRefundApplicable") Is System.DBNull.Value, "", res("WHTRefundApplicable").ToString())
                txt_WHTRedundRate1.Text = IIf(res("WHTRedundRate1") Is System.DBNull.Value, "", res("WHTRedundRate1").ToString())
                Set_Radiobox(opt_CustomerFloatComputation_Yes, opt_CustomerFloatComputation_No, res("CustomerFloatComputation").ToString())
                ' cbo_CustomerFloatRate1.Text = IIf(res("CustomerFloatRate1") Is System.DBNull.Value, "", res("CustomerFloatRate1").ToString())

                Set_Radiobox(opt_RepostGL_Yes, opt_RepostGL_No, res("RepostGL").ToString())

                Select Case IIf(res("GLRepostType") Is System.DBNull.Value, "", res("GLRepostType").ToString().ToUpper)
                    Case "MANUAL" : opt_GLRepostType2.Checked = True
                    Case "AUTOMATIC" : opt_GLRepostType1.Checked = True
                    Case "" : opt_GLRepostType3.Checked = True
                    Case "NONE" : opt_GLRepostType3.Checked = True
                    Case Else : opt_GLRepostType3.Checked = True
                End Select

                txt_NoofGLRepostAttempts.Text = IIf(res("NoofGLRepostAttempts") Is System.DBNull.Value, "", res("NoofGLRepostAttempts").ToString())
                txt_BeneValidationFlag.Text = IIf(res("BeneValidationFlag") Is System.DBNull.Value, "", res("BeneValidationFlag").ToString())

                Set_Radiobox(opt_ExportDownloadReq_Yes, opt_ExportDownloadReq_No, res("ExportDownloadReq").ToString())
                cbo_BeneAdviceOn.Text = IIf(res("BeneAdviceOn") Is System.DBNull.Value, "", res("BeneAdviceOn").ToString())


            End If

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub SaveData()
        Dim strSQL As String = ""
        If MsgBox("Do you want to create new a template?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add New Template") = MsgBoxResult.No Then Exit Sub

        If strMODE.ToUpper = "ADD" Then
            Call AutoLastNumber()
            Dim strValue As String = ""
            Dim strFiledname As String = ""

            strFiledname += vbCrLf & "[TemplateCode]"
            strValue += vbCrLf & "'" & txt_new_template.Text.Replace("'", "''") & "'"

            strFiledname += ",[Product]"
            strValue += vbCrLf & ",'" & cbo_Product.Text.Substring(0, 3).Replace("'", "''") & "'"

            strFiledname += ",[Line]"
            strValue += vbCrLf & ",'" & txt_Line.Text.Replace("'", "''") & "'"

            strFiledname += ",[TxnLimitLevel]"
            If opt_TxnLimitLevel_No.Checked = True Then
                strValue += vbCrLf & ",'INSTRUMENTS'"
            Else
                strValue += vbCrLf & ",'PIR'"
            End If

            strFiledname += ",[PerTxnMinAmnt]"
            strValue += vbCrLf & ", " & txt_PerTxnMinAmnt.Text.Replace(",", "") & " "

            strFiledname += ",[PerTxnMaxAmnt]"
            strValue += vbCrLf & ", " & txt_PerTxnMaxAmnt.Text.Replace(",", "") & " "

            strFiledname += ",[InstEnrichment]"
            If opt_InstEnrichment_Yes.Checked = True Then
                strValue += vbCrLf & ",'YES'"
            Else
                strValue += vbCrLf & ",'NO'"
            End If

            strFiledname += ",[DafaultArrangement]"
            strValue += vbCrLf & ",'" & cbo_DafaultArrangement.Text.Replace("'", "''") & "'"

            strFiledname += ",[GLRejectCharges]"
            If opt_GLRejectCharges_Yes.Checked = True Then
                strValue += vbCrLf & ",'YES'"
            Else
                strValue += vbCrLf & ",'NO'"
            End If

            strFiledname += ",[AdviceFaxRequired]"
            If opt_AdviceFaxRequired_Yes.Checked = True Then
                strValue += vbCrLf & ",'YES'"
            Else
                strValue += vbCrLf & ",'NO'"
            End If

            strFiledname += ",[AdviceEmailRequired]"
            If opt_AdviceEmailRequired_Yes.Checked = True Then
                strValue += vbCrLf & ",'YES'"
            Else
                strValue += vbCrLf & ",'NO'"
            End If

            strFiledname += ",[FloatSharingPercentage]"
            strValue += vbCrLf & ",'" & (cbo_FloatSharingPercentage.Text.Replace("'", "''")) & "'"

            strFiledname += ",[EffectiveFrom]"
            strValue += vbCrLf & ",'" & txt_EffectiveFrom.Text.Replace("'", "''") & "'"

            strFiledname += ",[ReviewOn]"
            strValue += vbCrLf & ",'" & txt_ReviewOn.Text.Replace("'", "''") & "'"

            strFiledname += ",[ChargesReviewOn]"
            strValue += vbCrLf & ",'" & txt_ChargesReviewOn.Text.Replace("'", "''") & "'"

            strFiledname += ",[StalePeriodType]"
            If rad_StalePeriodType_M.Checked = True Then
                strValue += vbCrLf & ",'" & "Monthly" & "'"
            Else
                strValue += vbCrLf & ",'" & "Daily" & "'"
            End If

            'strValue += vbCrLf & ",'" & txt_StalePeriodType.Text.Replace("'", "''") & "'"

            strFiledname += ",[StalePeriod]"
            strValue += vbCrLf & ",'" & txt_StalePeriod.Text.Replace("'", "''") & "'"

            strFiledname += ",[RefundAtStale]"
            strValue += vbCrLf & ",'" & txt_RefundAtStale.Text.Replace("'", "''") & "'"


            strFiledname += ",[InstNoGeneration]"
            strValue += vbCrLf & ",'" & txt_InstNoGeneration.Text.Replace("'", "''") & "'"

            strFiledname += ",[TAXSequence]"
            strValue += vbCrLf & ",'" & txt_TAXSequence.Text.Replace("'", "''") & "'"

            strFiledname += ",[VATApplicable]"
            strValue += vbCrLf & ",'" & txt_VATApplicable.Text.Replace("'", "''") & "'"

            strFiledname += ",[WHTRefundApplicable]"
            strValue += vbCrLf & ",'" & txt_WHTRefundApplicable.Text.Replace("'", "''") & "'"

            strFiledname += ",[WHTRedundRate1]"
            strValue += vbCrLf & ",'" & txt_WHTRedundRate1.Text.Replace("'", "''") & "'"


            strFiledname += ",[CustomerFloatComputation]"
            If opt_CustomerFloatComputation_Yes.Checked = True Then
                strValue += vbCrLf & ",'YES'"
            Else
                strValue += vbCrLf & ",'NO'"
            End If

            strFiledname += ",[CustomerFloatRate1]"
            strValue += vbCrLf & ",'" & GetCustomerFloatRate1(cbo_CustomerFloatRate1.Text.Replace(",", "")) & "'"

            strFiledname += ",[RepostGL]"
            If opt_RepostGL_Yes.Checked = True Then
                strValue += vbCrLf & ",'YES'"
            Else
                strValue += vbCrLf & ",'NO'"
            End If

            strFiledname += ",[GLRepostType]"
            If opt_GLRepostType1.Checked = True Then
                strValue += vbCrLf & ",'AUTOMATIC'"
            End If
            If opt_GLRepostType2.Checked = True Then
                strValue += vbCrLf & ",'MANUAL'"
            End If
            If opt_GLRepostType3.Checked = True Then
                strValue += vbCrLf & ",'NONE'"
            End If


            strFiledname += ",[NoofGLRepostAttempts]"
            strValue += vbCrLf & ",'" & txt_NoofGLRepostAttempts.Text.Replace("'", "''") & "'"

            strFiledname += ",[BeneValidationFlag]"
            strValue += vbCrLf & ",'" & txt_BeneValidationFlag.Text.Replace("'", "''") & "'"

            strFiledname += ",[ExportDownloadReq]"
            If opt_ExportDownloadReq_Yes.Checked = True Then
                strValue += vbCrLf & ",'YES'"
            Else
                strValue += vbCrLf & ",'NO'"
            End If

            strFiledname += ",[BeneAdviceOn]"
            strValue += vbCrLf & ",'" & cbo_BeneAdviceOn.Text.Replace("'", "''") & "'"


            strSQL = ""
            strSQL += vbCrLf & "insert into [PRD_TemplateProduct]"
            strSQL += vbCrLf & "(" & strFiledname & ")"
            strSQL += vbCrLf & " VALUES (" & strValue & ")"

            If conn.ExecuteNonQuery(strSQL) = "" Then

                strValue = ""
                strFiledname = ""

                strFiledname += vbCrLf & "[TemplateCode]"
                strValue += vbCrLf & "'" & txt_new_template.Text.Replace("'", "''") & "'"
                strFiledname += ",[TemplateType]"
                strValue += vbCrLf & ",'" & strSingleProduct & "'"
                strFiledname += vbCrLf & ",[TemplateFullName]"
                strValue += vbCrLf & ",'" & cbo_Product.Text.Substring(0, 3) & " PRODUCT TEMPLATE " & txt_new_template.Text.Substring(txt_new_template.Text.Length - 5) & "'"
                strFiledname += vbCrLf & ",[TemplateEffectiveFrom]"
                strValue += vbCrLf & ",''"
                strFiledname += ",[ProductCode]"
                strValue += vbCrLf & ",'" & cbo_Product.Text.Substring(0, 3).Replace("'", "''") & "'"
                strFiledname += vbCrLf & ",[Remarks]"
                strValue += vbCrLf & ",''"
                strFiledname += ",[StatusTemplate]"
                strValue += vbCrLf & ",'Y'"
                strFiledname += ",[maintain_flag]"
                strValue += vbCrLf & ",'Y'"


                strSQL = ""
                strSQL += vbCrLf & "insert into [PRD_Template]"
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                strSQL += vbCrLf & " exec dbo.sp_TemplateInstrumentEnrichments_PRD '" & txt_new_template.Text.Replace("'", "''") & "'"
                strSQL += vbCrLf & " exec dbo.sp_TemplateProductArrangements_PRD '" & txt_new_template.Text.Replace("'", "''") & "'"
                strSQL += vbCrLf & " exec dbo.sp_TemplateProductClearingLocation_PRD '" & txt_new_template.Text.Replace("'", "''") & "'"


                conn.ExecuteNonQuery(strSQL)

                If bNewFlag = False Then
                    Call PrintReport()
                End If


                If bNewFlag = True Then
                    txt_return.Text = txt_new_template.Text.Replace("'", "''")
                    Me.Close()
                End If

            End If



            ' Me.Close()
        End If '  If strMODE.ToUpper = "ADD" Then

        res.Close()
        conn.Close()
        'Me.Close()
    End Sub

    Private Sub UpdateData()
        If strMODE.ToUpper <> "ADD" Then

        End If
    End Sub

    Private Sub PrintReport()

        Try
            Dim FrmReport As New FrmReport
            FrmReport.ReportType = "TemplateProduct"

            'FrmReport.SQL = "select * from dbo.PRD_TemplateProduct where TemplateCode = '" & txt_new_template.Text & "' order by TemplateCode"

            FrmReport.SQL = ""
            FrmReport.SQL += "   SELECT a.*,CustomerFloatRate1  + '(' + cast(b.BASE_RATE as varchar) + ')'    +  '  ' +    cast( [BASE_RATE_DESCRIPTION] as nvarchar(150))  as CustomerFloatRate2"
            FrmReport.SQL += " FROM dbo.PRD_TemplateProduct a"
            FrmReport.SQL += " left outer join  dbo.BASE_RATES_MST b"
            FrmReport.SQL += " on a.CustomerFloatRate1=b.BASE_RATE_CODE"
            FrmReport.SQL += " where TemplateCode = '" & txt_new_template.Text & "' order by TemplateCode"

            FrmReport.strSQL_PRD_Template = "SELECT * FROM PRD_Template where TemplateCode = '" & txt_new_template.Text & "' order by TemplateCode"
            FrmReport.strSQL_PRD_TemplateProductArrangements = "SELECT * FROM PRD_TemplateProductArrangements where TemplateCode = '" & txt_new_template.Text & "' order by TemplateCode"
            FrmReport.strSQL_PRD_TemplateProductClearingLocation = "SELECT * FROM PRD_TemplateProductClearingLocation where TemplateCode = '" & txt_new_template.Text & "' order by TemplateCode"
            FrmReport.strSQL_PRD_TemplateInstrumentEnrichments = "SELECT * FROM PRD_TemplateInstrumentEnrichments where TemplateCode = '" & txt_new_template.Text & "' order by TemplateCode"
            FrmReport.strLine(0) = txt_Deal_ID.Text

            FrmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click

        If txt_Deal_ID.Text = "" Then
            MsgBox("Invalid [Deal ID]")
            Exit Sub
        End If

        If opt_CustomerFloatComputation_Yes.Checked = True Then
            Select Case cbo_Product.Text.Substring(0, 3)
                Case "PCT"
                    'opt_CustomerFloatComputation_Yes
                Case "COC"
                    ' If cbo_CustomerFloatRate1.Text <> "" Or cbo_CustomerFloatRate1.Text <> strNoFloat Then
                    If cbo_FloatSharingPercentage.Text = "" Or cbo_FloatSharingPercentage.Text = strNoFloat Then
                        MsgBox("Invalid [Float Sharing Percentage]")
                        Exit Sub
                    End If
                    ' End If

                    '  If cbo_FloatSharingPercentage.Text <> "" And cbo_FloatSharingPercentage.Text <> strNoFloat Then
                    If cbo_CustomerFloatRate1.Text = "" Or cbo_CustomerFloatRate1.Text = strNoFloat Then
                        MsgBox("Invalid [Customer Float Computation]")
                        Exit Sub
                    End If
                    '  End If
                Case Else


            End Select
        End If


        Dim strErr As String = ""

        strErr = ValidationData()
        If strErr <> "" Then
            MessageBox.Show(strErr)
            Exit Sub
        End If

        conn = New CSQL
        conn.Connect()

        Dim strCompareTemplate As String = ""
        strCompareTemplate = CompareTemplate()
        If strCompareTemplate <> "" Then
            Exit Sub
        End If

        If strMODE.ToUpper = "ADD" Then
            Call SaveData()
        Else
            Call UpdateData()
        End If

    End Sub


#Region "control event"

    Private Sub opt_CustomerFloatComputation_Yes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_CustomerFloatComputation_Yes.CheckedChanged
        Call SetScreenFloat()
    End Sub

    Private Sub opt_CustomerFloatComputation_No_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_CustomerFloatComputation_No.CheckedChanged
        Call SetScreenFloat()
    End Sub

    Private Sub SetScreenFloat()
        If opt_CustomerFloatComputation_Yes.Checked = True Then
            cbo_CustomerFloatRate1.Enabled = True
            cbo_FloatSharingPercentage.Enabled = True
        Else
            cbo_CustomerFloatRate1.Enabled = False
            cbo_FloatSharingPercentage.Enabled = False
        End If
    End Sub

    Private Function TrapKey(ByVal KCode As Integer) As Boolean
        If (KCode >= 48 And KCode <= 57) Or KCode = 8 Or KCode = 46 Then
            TrapKey = False
        Else
            TrapKey = True
        End If
    End Function

    Private Sub Set_Radiobox(ByRef r1 As RadioButton, ByRef r2 As RadioButton, ByVal val As String)
        Select Case (val.ToUpper())
            Case "YES"
                r1.Checked = True
            Case "PIR"
                r1.Checked = True
            Case "DAILY"
                r1.Checked = True
            Case "AUTOMATIC"
                r1.Checked = True

            Case "NO"
                r2.Checked = True
            Case "INSTRUMENTS"
                r2.Checked = True
            Case "MONTHLY"
                r2.Checked = True
            Case "MANUAL"
                r2.Checked = True
            Case Else
                r2.Checked = True
        End Select
    End Sub

    Private Function Get_Radiobox(ByRef r1 As RadioButton, ByRef r2 As RadioButton) As String
        If r1.Checked = True Then
            Get_Radiobox = r1.Text.ToUpper()
        Else
            Get_Radiobox = r2.Text.ToUpper()
        End If
    End Function

    Private Sub TxnPerMax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = TrapKey(Asc(e.KeyChar))
    End Sub

    Private Sub TxnPerMin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = TrapKey(Asc(e.KeyChar))
    End Sub

    Private Sub RGL1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_RepostGL_Yes.CheckedChanged
        opt_GLRepostType1.Enabled = False
        opt_GLRepostType2.Enabled = False
        opt_GLRepostType3.Enabled = False
        opt_GLRepostType2.Checked = True
    End Sub

    Private Sub RGL2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_RepostGL_No.CheckedChanged
        opt_GLRepostType1.Enabled = False
        opt_GLRepostType2.Enabled = False
        opt_GLRepostType3.Enabled = False
        opt_GLRepostType3.Checked = True
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub Frm_TemplateProduct_Edit_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub Frm_TemplateProduct_Edit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region


    Private Sub cbo_Product_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_Product.Validated
        Call LockControlsByProduct()
    End Sub


    Private Sub LockControlsByProduct()
        Try
            cbo_FloatSharingPercentage.Enabled = False
            pnl_CustomerFloat.Enabled = False
            cbo_CustomerFloatRate1.Enabled = False
            pnl_RepostGL.Enabled = False
            cbo_FloatSharingPercentage.Enabled = False
            pnl_GLReportType.Enabled = False
            pnl_StalePeriodType.Enabled = False
            txt_StalePeriod.Enabled = False
            txt_StalePeriod.BackColor = Color.Gray
            Select Case cbo_Product.Text.Substring(0, 3)
                Case "COC"
                    pnl_CustomerFloat.Enabled = True
                    If opt_CustomerFloatComputation_Yes.Checked = True Then
                        cbo_CustomerFloatRate1.Enabled = True
                    Else
                        cbo_CustomerFloatRate1.Enabled = False
                    End If
                    pnl_StalePeriodType.Enabled = True
                    txt_StalePeriod.Enabled = True
                    txt_StalePeriod.BackColor = Color.White
                Case "COE"
                    pnl_StalePeriodType.Enabled = True
                    txt_StalePeriod.Enabled = True
                    txt_StalePeriod.BackColor = Color.White
                Case "PCT"
                    pnl_RepostGL.Enabled = True
                    opt_RepostGL_No.Checked = True
                    pnl_GLReportType.Enabled = True
                    opt_GLRepostType2.Checked = True


                    '  opt_GLRepostType1.Enabled = True
                    ' opt_GLRepostType2.Enabled = True
                    'opt_GLRepostType3.Enabled = True

                Case Else

            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cbo_Product_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Product.SelectedIndexChanged

    End Sub
End Class