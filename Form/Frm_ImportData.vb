
Public Class Frm_ImportData

    Private Const str_TEMPLATE_CLIENT_PRODUCT_MST = "TEMPLATE_CLIENT_PRODUCT_MST" 'template product
    Private Const str_TEMPLATE_MST = "TEMPLATE_MST" 'template code
    Private Const str_TEMPLATE_ENTITY_CHG_EVENTS_MST = "TEMPLATE_ENTITY_CHG_EVENTS_MST" 'event 
    Private Const str_CHARGE_CATEGORY_MST = "CHARGE_CATEGORY_MST" 'charge category
    Private Const str_TEMPLATE_ENTITY_CHG_UNIT_MST = "TEMPLATE_ENTITY_CHG_UNIT_MST" ' unit
    Private Const str_TEMPLATE_ENTITY_CHG_UNIT_DTL = "TEMPLATE_ENTITY_CHG_UNIT_DTL" ' unit-details


    Dim bProcess As Boolean = False

    Dim conn As New CSQL

    Public Sub ShowMessage(ByVal strData As String)
        txt_desc.Text = txt_desc.Text & vbCrLf & Format(Now, "dd/MM/yyyy HH:mm:ss") & " >> " & strData

        Dim mvnt As Object, i As Long, NewData As String = ""

        If UBound(Split(txt_desc.Text, vbCrLf)) >= 10 Then

            mvnt = Split(txt_desc.Text, vbCrLf)

            For i = 1 To UBound(mvnt)
                If Trim(mvnt(i)) <> "" Then NewData = NewData & mvnt(i) & vbCrLf
            Next i

            txt_desc.Text = NewData
        End If
    End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click

        If bProcess = True Then
            BT_Update.Text = "Import"
            btn_close.Enabled = True
            bProcess = False
            Exit Sub
        End If

        If txt_FileName.Text.Substring(txt_FileName.Text.Length - 4).ToUpper <> ".xls".ToUpper Or txt_FileName.Text = "" Then
            MessageBox.Show("Invalid File.")
        End If

        bProcess = True
        btn_close.Enabled = False
        BT_Update.Text = "Cancel process..."

        Dim strFiled As String = ""
        '========================================================
        strFiled = ""
        strFiled += "CHARGE_CATEGORY_CODE"
        strFiled += ",ENTITY_TYPE"
        strFiled += ",PRODUCT_TYPE_CODE"
        strFiled += ",EVENT_CODE"
        strFiled += ",CHARGE_CLASS_CODE"
        strFiled += ",CHARGE_CATEGORY_DESCRIPTION"
        strFiled += ",CHARGE_COST_CODE"
        strFiled += ",INST_DEPOSIT_FLAG"
        strFiled += ",INTEREST_BASED_CHG_FLAG"
        strFiled += ",VALID_BASIS_TYPES"

        Call Import_data(str_CHARGE_CATEGORY_MST, "CHARGE_CATEGORY_MST", strFiled)
        '========================================================
        strFiled = ""
        strFiled += "TEMPLATE_CODE"
        strFiled += ",DESCRIPTION"
        strFiled += ",RECORD_KEY_NMBR"
        strFiled += ",AUDIT_NMBR"
        strFiled += ",VALID_FLAG"
        strFiled += ",OPERATION_FLAG"
        strFiled += ",CHECKER_ACTION"
        strFiled += ",PREV_AUDIT_NMBR"
        strFiled += ",VERSION"
        strFiled += ",SELLER_CODE"
        strFiled += ",TEMPLATE_EFFECTIVE_FROM"
        strFiled += ",PAYOUT_CLIENT_FLAG"
        strFiled += ",COLLECTION_ENABLE_FLAG"
        strFiled += ",PAYMENT_ENABLE_FLAG"
        strFiled += ",LMS_ENABLE_FLAG"
        strFiled += ",DWIW_ENABLE_FLAG"
        strFiled += ",RMS_ENABLE_FLAG"
        strFiled += ",TEMPLATE_TYPE"
        strFiled += ",PRODUCT_CODE"

        Call Import_data(str_TEMPLATE_MST, "TEMPLATE_MST", strFiled)

        '========================================================
        strFiled = ""
        strFiled += "TEMPLATE_CODE"
        strFiled += ",PRODUCT_CODE"
        strFiled += ",LINE_CODE"
        strFiled += ",CORPORATION_CODE"
        strFiled += ",INST_DETAILS_FLAG"
        strFiled += ",TXN_LIMITS_LEVEL_FLAG"
        strFiled += ",PER_TXN_MIN_AMNT"
        strFiled += ",PER_TXN_MAX_AMNT"
        strFiled += ",ACCOUNTING_LEVEL_FLAG"
        strFiled += ",ENRICHMENT_FLAG"
        strFiled += ",PAYER_ANALYSIS_FLAG"
        strFiled += ",DEDUCT_CHARGES_FLAG"
        strFiled += ",DEFAULT_ARRANGEMENT_CODE"
        strFiled += ",START_DATE"
        strFiled += ",END_DATE"
        strFiled += ",CHARGES_REVIEW_DATE"
        strFiled += ",RECORD_KEY_NMBR"
        strFiled += ",AUDIT_NMBR"
        strFiled += ",VALID_FLAG"
        strFiled += ",OPERATION_FLAG"
        strFiled += ",CHECKER_ACTION"
        strFiled += ",PREV_AUDIT_NMBR"
        strFiled += ",ADHOC_DISP_CHARGE"
        strFiled += ",STALE_PERIOD"
        strFiled += ",STALE_PERIOD_TYPE"
        strFiled += ",REFUND_AT_STALE_FLAG"
        strFiled += ",INCOME_POSTING_DATE"
        strFiled += ",INCOME_DAY_NUMBER"
        strFiled += ",PROFIT_SHARING_PERCENTAGE"
        strFiled += ",INCOME_POSTING_FREQUENCY"
        strFiled += ",NO_OF_UNITS"
        strFiled += ",OUTSOURCED_PRINT_TYPE"
        strFiled += ",CHECK_SEQ_FLAG"
        strFiled += ",DEP_ENRICHMENT_FLAG"
        strFiled += ",DRAWER_DESC_MANDATORY"
        strFiled += ",LINE_REV_INST_LEVEL"
        strFiled += ",MANDATE_VERIFICATION_REQD_FLAG"
        strFiled += ",AUTH_CONFIRMATION_REQD_FLAG"
        strFiled += ",TEMPLATE_EFFECTIVE_FROM"
        strFiled += ",CHARGE_CCY_LEVEL"
        strFiled += ",VERSION"
        strFiled += ",SELLER_CODE"
        strFiled += ",FORCE_CHARGE_FLAG"
        strFiled += ",RETURN_LIQ_ACCT"
        strFiled += ",DAYS_AFTER_LIQ"
        strFiled += ",HOLIDAY_TEMPLATE_CODE"
        strFiled += ",DENOM_DERIVATION_FLAG"
        strFiled += ",HIGHEST_DENOM_CODE"
        strFiled += ",WHT_DOCUMENT_NO_FLAG"
        strFiled += ",TAX_SEQUENCE_NO_FLAG"
        strFiled += ",EXEMPTED_FROM_TAX_FLAG"
        strFiled += ",WHT_REFUND_FLAG"
        strFiled += ",WHT_RATE_CODE"
        strFiled += ",RETURN_FLOAT_FLAG"
        strFiled += ",UPLOAD_ADVICE"
        strFiled += ",NO_OF_LINES"
        strFiled += ",BANK_FLOAT_RATE"
        strFiled += ",AUTO_LIQUIDATION_TYPE"
        strFiled += ",GL_VERIFY_ATTEMPTS"
        strFiled += ",STATIONARY_CODE"
        strFiled += ",CLIENT_PRINTING_FLAG"
        strFiled += ",LIMIT_PROCESSING_FLAG"
        strFiled += ",CONSOLIDATION_REQUIRED"
        strFiled += ",CLEARING_LOCATION"
        strFiled += ",BACK_INST_DATE"
        strFiled += ",BACK_INST_DAYS"
        strFiled += ",CENTRALIZED_CHARGE_FLAG"
        strFiled += ",AUTO_INVOCATION_FLAG"
        strFiled += ",DIRECT_DEBIT_RETRY_DAYS"
        strFiled += ",CUSTOMER_ID"
        strFiled += ",SERVICE_TYPE_CODE"
        strFiled += ",DEFAULT_CHG_ACCT"
        strFiled += ",BENE_VALIDATION_REQ_FLAG"
        strFiled += ",EXPORT_REQ_FLAG"
        strFiled += ",NO_CHAR_PER_LN"
        strFiled += ",REPORT_FONT"
        strFiled += ",FONT_SIZE"
        strFiled += ",REPOST_GL_FLAG"
        strFiled += ",GL_REPOST_TYPE"
        strFiled += ",AUTO_LIQUIDATION_BASIS"
        strFiled += ",CLIENT_CHG_PERCENT"
        strFiled += ",BENE_CHG_PERCENT"
        strFiled += ",ADVICE_PRINTING_ON"
        strFiled += ",CHARGE_ON_GLREJECT"
        strFiled += ",FLOAT_TENURE"
        strFiled += ",FLOAT_SHARING"
        strFiled += ",MARGIN_OR_SPREAD"
        strFiled += ",ADVICE_EMAIL_REQUIRED"
        strFiled += ",ADVICE_FAX_REQUIRED"

        Call Import_data(str_TEMPLATE_CLIENT_PRODUCT_MST, "TEMPLATE_CLIENT_PRODUCT_MST", strFiled)

        '========================================================
        strFiled = ""
        strFiled += "INTERNAL_CHARGE_ID"
        strFiled += ",CHARGE_UNIT_CODE"
        strFiled += ",EVENT_CODE"
        strFiled += ",ENTITY_TYPE"
        strFiled += ",CHARGE_CATEGORY_CODE"
        strFiled += ",REF_KEY_CODE"
        strFiled += ",UNIQUE_KEY_NMBR"
        strFiled += ",CHARGE_UNIT_DESCRIPTION"
        strFiled += ",MIN_CHARGE_APPLICABLE_FLAG"
        strFiled += ",MIN_CHARGE_LIMIT_AMNT"
        strFiled += ",MAX_CHARGE_APPLICABLE_FLAG"
        strFiled += ",MAX_CHARGE_LIMIT_AMNT"
        strFiled += ",ROUNDING_TYPE_FLAG"
        strFiled += ",ROUNDING_VALUE_AMNT"
        strFiled += ",COMPUTATION_BASIS_FLAG"
        strFiled += ",FLAT_OR_SLAB_FLAG"
        strFiled += ",BASE_RATE_CODE"
        strFiled += ",INTEREST_CODE"
        strFiled += ",START_DAY_CODE"
        strFiled += ",END_DAY_CODE"
        strFiled += ",POSTING_OVERRIDE_FLAG"
        strFiled += ",COMPUTE_OVERRIDE_FLAG"
        strFiled += ",RECORD_KEY_NMBR"
        strFiled += ",AUDIT_NMBR"
        strFiled += ",VALID_FLAG"
        strFiled += ",OPERATION_FLAG"
        strFiled += ",CHECKER_ACTION"
        strFiled += ",PREV_AUDIT_NMBR"
        strFiled += ",TEMPLATE_EFFECTIVE_FROM"
        strFiled += ",VERSION"
        strFiled += ",SELLER_CODE"
        strFiled += ",MIN_CHARGE_DAY_NMBR"
        strFiled += ",MAX_CHARGE_DAY_NMBR"
        strFiled += ",INTEREST_RATE_BASIS"
        strFiled += ",PERIOD_BASED_SLABS"
        strFiled += ",OVERDUE_INTEREST_RATE"
        strFiled += ",BK_INTEREST_TYPE"
        strFiled += ",BK_INTEREST_FIXING_EVENT"
        strFiled += ",BK_ACCRUAL_REQD"
        strFiled += ",BK_PERIOD_BASED"
        strFiled += ",BK_ACCR_FREQUENCY"
        strFiled += ",BK_ACCR_PERIOD_TYPE"
        strFiled += ",BK_ACCR_PERIOD"
        strFiled += ",BK_DAY_NMBR"
        strFiled += ",BK_NEXT_ACCR_DATE"
        strFiled += ",CLT_ACCR_FREQUENCY"
        strFiled += ",CLT_ACCR_PERIOD_TYPE"
        strFiled += ",CLT_ACCR_PERIOD"
        strFiled += ",CLT_DAY_NMBR"
        strFiled += ",CLT_NEXT_ACCR_DATE"
        strFiled += ",INTEREST_TYPE"
        strFiled += ",DEDUCT_FROM_PROCEED"
        strFiled += ",INTEREST_FIXING_EVENT"
        strFiled += ",INCOME_ACCRUAL_REQD"
        strFiled += ",INCOME_SHARING"
        strFiled += ",INCOME_SHARING_PER"
        strFiled += ",INTEREST_REFUND_ON_PRE_PAY"
        strFiled += ",INTEREST_REFUND_ON_RE_PAY"
        strFiled += ",BANK_CHARGE_COMPUTATION_REQD"
        strFiled += ",COMPUTATION_FLAG"
        strFiled += ",POSTING_FLAG"
        strFiled += ",CHARGE_TO"
        strFiled += ",COMM_OR_SERVICE_FLAG"
        strFiled += ",CLIENT_LEVEL_CHARGE"
        strFiled += ",DENOM_CODE"
        strFiled += ",START_EFFECTIVE_DATE"
        strFiled += ",END_EFFECTIVE_DATE"

        Call Import_data(str_TEMPLATE_ENTITY_CHG_UNIT_MST, "TEMPLATE_ENTITY_CHG_UNIT_MST", strFiled)
        '========================================================
        strFiled = ""
        strFiled += "[INTERNAL_CHARGE_ID]"
        strFiled += ",[LOWER_LIMIT_AMNT]"
        strFiled += ",[UPPER_LIMIT_AMNT]"
        strFiled += ",[FIXED_AMNT]"
        strFiled += ",[PERCENTAGE_CHARGE]"
        strFiled += ",[RECORD_KEY_NMBR]"
        strFiled += ",[VERSION]"
        strFiled += ",[MIN_DAYS]"
        strFiled += ",[MAX_DAYS]"

        Call Import_data(str_TEMPLATE_ENTITY_CHG_UNIT_DTL, "TEMPLATE_ENTITY_CHG_UNIT_DTL", strFiled)
        '========================================================
        strFiled = ""
        strFiled += "EVENT_CODE"
        strFiled += ",ENTITY_TYPE"
        strFiled += ",TEMPLATE_CODE"
        strFiled += ",PRODUCT_CODE"
        strFiled += ",MIN_CHARGE_APPLICABLE_FLAG"
        strFiled += ",MIN_CHARGE_LIMIT_AMNT"
        strFiled += ",MAX_CHARGE_APPLICABLE_FLAG"
        strFiled += ",MAX_CHARGE_LIMIT_AMNT"
        strFiled += ",ROUNDING_TYPE_FLAG"
        strFiled += ",ROUNDING_VALUE_AMNT"
        strFiled += ",COMPUTATION_FREQUENCY"
        strFiled += ",COMPUTATION_PERIOD_TYPE"
        strFiled += ",COMPUTATION_PERIOD"
        strFiled += ",COMPUTATION_DAY_NMBR"
        strFiled += ",NEXT_COMPUTATION_DATE"
        strFiled += ",POSTING_FREQUENCY"
        strFiled += ",POSTING_PERIOD_TYPE"
        strFiled += ",POSTING_PERIOD"
        strFiled += ",POSTING_DAY_NMBR"
        strFiled += ",NEXT_POSTING_DATE"
        strFiled += ",RECORD_KEY_NMBR"
        strFiled += ",AUDIT_NMBR"
        strFiled += ",VALID_FLAG"
        strFiled += ",OPERATION_FLAG"
        strFiled += ",CHECKER_ACTION"
        strFiled += ",PREV_AUDIT_NMBR"
        strFiled += ",TEMPLATE_EFFECTIVE_FROM"
        strFiled += ",VERSION"
        strFiled += ",SELLER_CODE"


        Call Import_data(str_TEMPLATE_ENTITY_CHG_EVENTS_MST, "TEMPLATE_ENTITY_CHG_EVENTS_MST", strFiled)


        ShowMessage("start transform data")
        conn.ExecuteNonQuery("exec dbo.SP_TRANSFORM")
        ShowMessage("start summit data")
        conn.ExecuteNonQuery("exec dbo.SP_ImportData")
        ShowMessage("process was successful.")

        BT_Update.Text = "Import"
        btn_close.Enabled = True
        bProcess = False

    End Sub

    Private Sub KillExcel()
        Dim proc As System.Diagnostics.Process
        For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
            proc.Kill()
        Next
    End Sub

    Private Function GetExcelToDataSource(ByVal strFile As String, ByVal strSheetName As String) As System.Data.OleDb.OleDbDataReader
        Try
            Dim xConnStr As String = "Provider=Microsoft.JET.oledb.4.0;Data Source=" & strFile & ";Extended Properties=" & """Excel 8.0;IMEX=1""" & ";Persist Security Info=False "
            Dim objXConn As New System.Data.OleDb.OleDbConnection(xConnStr)
            objXConn.Open()
            Dim objCommand As New System.Data.OleDb.OleDbCommand("SELECT * FROM [" & strSheetName & "$]", objXConn)
            GetExcelToDataSource = objCommand.ExecuteReader()

        Catch ex As Exception
            GetExcelToDataSource = Nothing
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Sub MapStatement(ByVal excel_data As String, ByVal SqlElement As String, ByVal IsNum As Boolean, ByRef strFiledname As String, ByRef strValue As String, ByRef strErr As String)

        If IsNum = True Then
            excel_data = GetSQLNumber(excel_data)
        Else
            excel_data = GetSQLText(excel_data)
        End If

        strFiledname += vbCrLf & IIf(strFiledname = "", "", ",") & SqlElement
        If excel_data = "" Then
            strErr += IIf(strErr = "", "", ",") & SqlElement
            strValue += vbCrLf & IIf(strValue = "", "", ",") & excel_data
        Else
            strValue += vbCrLf & IIf(strValue = "", "", ",") & excel_data
        End If
    End Sub

    Private Function GetSQLText(ByVal strvalue) As String
        GetSQLText = "'" & Replace(strvalue, "'", "''") & "'"
    End Function

    Private Function GetSQLNumber(ByVal strvalue As Object, Optional ByVal fmt As String = "") As String
        GetSQLNumber = ""

        If strvalue = "" Then
            GetSQLNumber = "NULL"
        Else
            If IsNumeric(strvalue.ToString.Replace(",", "")) = True Then
                If fmt <> "" Then
                    GetSQLNumber = CDbl(strvalue).ToString(fmt)
                Else
                    GetSQLNumber = CDbl(strvalue).ToString
                End If

            End If
        End If

    End Function

    Private Sub brn_Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brn_Browse.Click
        Try
            OpenFileDialog1.Filter = "Excel File|*.XLS"
            OpenFileDialog1.FileName = Application.StartupPath

            Dim mDialogResult As New System.Windows.Forms.DialogResult
            mDialogResult = OpenFileDialog1.ShowDialog
            If mDialogResult = Windows.Forms.DialogResult.OK Then
                txt_FileName.Text = OpenFileDialog1.FileName
                If txt_FileName.Text.Substring(txt_FileName.Text.Length - 4).ToUpper <> ".xls".ToUpper Then
                    MessageBox.Show("Invalid File.")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Frm_ImportData_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        bProcess = False
    End Sub

    Private Sub Frm_ImportData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bProcess = False
    End Sub

#Region "Import data"

    Private Function Import_data(ByVal mWorkBook As String, ByVal strTABLE As String, ByVal strFildName As String) As String ' Microsoft.Office.Interop.Excel.Workbook)
        Import_data = ""
        ShowMessage("--------------Start " & strTABLE & " File ----------------")
        Dim strSQL As String = ""
        Dim iRow As Double, EOF As Boolean
        iRow = 1
        EOF = False

        conn.ExecuteNonQuery("truncate table " & strTABLE)

        Dim rst As System.Data.OleDb.OleDbDataReader
        rst = GetExcelToDataSource(txt_FileName.Text, mWorkBook)

        If rst.HasRows = False Then Exit Function

        Do While rst.Read
            Application.DoEvents()
            If bProcess = False Then Exit Do

            If rst.Item(0).ToString = "" Then
                Exit Do
            End If
            ShowMessage("ID:" & rst.Item(0).ToString & " Row Number=" & iRow)
            strSQL = ""
            Dim strValue As String = ""
            Dim strFiledname As String = ""
            Dim strErr As String = ""

            Dim vnt As Object, i As Integer
            vnt = Split(strFildName, ",")

            For i = 0 To UBound(vnt)

                MapStatement(rst.Item(i).ToString, vnt(i), False, strFiledname, strValue, strErr)
            Next


            strSQL = ""
            strSQL += vbCrLf & "insert into " & strTABLE
            strSQL += vbCrLf & "(" & strFiledname & ")"
            strSQL += vbCrLf & " VALUES (" & strValue & ")"

            Try
                Dim strErr_Execute As String = ""
                strErr_Execute = conn.ExecuteNonQuery(strSQL, False)
                If strErr_Execute = "" Then
                    'rst.Item(8).ToString = ""
                Else
                    Import_data = strErr_Execute
                    'rst.Item(8).value = strErr_Execute
                    Call ShowMessage(strErr_Execute)
                    Exit Do
                End If
            Catch ex As Exception
                Import_data = ex.ToString
                ' rst.Item(8).value = ex.ToString
                Exit Do
            End Try


            iRow += 1
        Loop

        ShowMessage("--------------Start  " & strTABLE & " File ----------------")
    End Function

#End Region


    Private Sub txt_FileName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_FileName.TextChanged

    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
End Class