Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_TemplateChargeEvent_Edit
    Dim conn As CSQL
    Public strMODE As String = "ADD"


    Private Sub Frm_TemplateChargeEvent_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New CSQL
        Me.KeyPreview = True
        Dim strSQL As String = ""
        strSQL = "select Product from dbo.PRD_TemplateChargeEvents group by Product order by Product"
        conn.Fill_ComboBox(strSQL, cbo_Product)

        'strSQL = "select [Code] from dbo.TB_ListOfValue WHERE TableName ='EVENT' AND ColumnName = 'EVENT'"
        strSQL = "select EVENT from dbo.PRD_TemplateChargeEvents group by EVENT order by EVENT"
        conn.Fill_ComboBox(strSQL, cbo_Event)

        strSQL = "select ApplyMinChgAmt from dbo.PRD_TemplateChargeEvents group by ApplyMinChgAmt order by ApplyMinChgAmt"
        conn.Fill_ComboBox(strSQL, cbo_ApplyMinChgAmt)

        strSQL = "select ApplyMaxChgAmt from dbo.PRD_TemplateChargeEvents group by ApplyMaxChgAmt order by ApplyMaxChgAmt "
        conn.Fill_ComboBox(strSQL, cbo_ApplyMaxChgAmt)

        'strSQL = "select [Code] from dbo.TB_ListOfValue WHERE TableName ='EVENT' AND upper(ColumnName) = upper('rounding type') "
        strSQL = "select RoundingType from"
        strSQL += " ( (select RoundingType from dbo.PRD_TemplateChargeEvents group by RoundingType) "
        strSQL += " union (select upper(Rounding) as  RoundingType from dbo.PRD_TemplateChargeUnits group by Rounding ) ) #all order by RoundingType "

        conn.Fill_ComboBox(strSQL, cbo_RoundingType)

        strSQL = "select RoundingAmnt from dbo.PRD_TemplateChargeEvents group by RoundingAmnt order by RoundingAmnt"
        conn.Fill_ComboBox(strSQL, cbo_RoundingAmnt)

        cbo_ApplyMinChgAmt.Enabled = False
        cbo_ApplyMaxChgAmt.Enabled = False

        If strMODE <> "ADD" Then
            ShowData()
            cbo_Product.Enabled = False
            cbo_Event.Enabled = False
        Else
            If txt_TemplateCode.Text <> "" Then
                cbo_Product.Text = txt_TemplateCode.Text.Substring(0, 3)
            End If
        End If

        cbo_Product.Enabled = False

        '   If cbo_ApplyMaxChgAmt.Text = "" Then cbo_ApplyMaxChgAmt.Text = 0
        ' If cbo_ApplyMaxChgAmt.Text = "" Then cbo_ApplyMaxChgAmt.Text = 0

    End Sub

    Private Sub PreLoad()

        If Len(txt_TemplateCode.Text) <= 0 Then




        End If

    End Sub

    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""

        Try

            strSQL = "SELECT * FROM [Inquiry_TemplateChargeEvents] where ID='" & txt_GUID.Text & "'  and Event='" & cbo_Event.Text & "'"
            res = conn.GetDataReader(strSQL)

            If res.HasRows = True Then
                res.Read()
                cbo_Product.Text = IIf(res("Product") Is System.DBNull.Value, "", res("Product").ToString())
                txt_ProductCCY.Text = IIf(res("ProductCCY") Is System.DBNull.Value, "", res("ProductCCY").ToString())
                If IIf(res("ApplyMinChg") Is System.DBNull.Value, "", res("ApplyMinChg").ToString()) = "YES" Then
                    rad_ApplyMinChg_Yes.Checked = True
                Else
                    rad_ApplyMinChg_No.Checked = True
                End If
                cbo_ApplyMinChgAmt.Text = IIf(res("ApplyMinChgAmt") Is System.DBNull.Value, "", res("ApplyMinChgAmt").ToString())

                If IIf(res("ApplyMaxChg") Is System.DBNull.Value, "", res("ApplyMaxChg").ToString()) = "YES" Then
                    rad_ApplyMaxChg_Yes.Checked = True
                Else
                    rad_ApplyMaxChg_No.Checked = True
                End If
                cbo_ApplyMaxChgAmt.Text = IIf(res("ApplyMaxChgAmt") Is System.DBNull.Value, "", res("ApplyMaxChgAmt").ToString())
                cbo_RoundingType.Text = IIf(res("RoundingType") Is System.DBNull.Value, "", res("RoundingType").ToString())
                cbo_RoundingAmnt.Text = IIf(res("RoundingAmnt") Is System.DBNull.Value, "", res("RoundingAmnt").ToString())
                txt_TemplateEffectiveFrom.Text = IIf(res("TemplateEffectiveFrom") Is System.DBNull.Value, "", res("TemplateEffectiveFrom").ToString())

                If IIf(res("ComputationFrequency") Is System.DBNull.Value, "", res("ComputationFrequency").ToString()) = "IMMEDIATE" Then
                    rad_ComputationFrequency_1.Checked = True
                Else
                    rad_ComputationFrequency_2.Checked = True
                End If
                If IIf(res("ComputationPeriodType") Is System.DBNull.Value, "", res("ComputationPeriodType").ToString()) = "DAILY" Then
                    rad_ComputationPeriodType_1.Checked = True
                Else
                    rad_ComputationPeriodType_2.Checked = True
                End If

                txt_ComputationPeriod.Text = IIf(res("ComputationPeriod") Is System.DBNull.Value, "", res("ComputationPeriod").ToString())
                txt_ComputationDay.Text = IIf(res("ComputationDay") Is System.DBNull.Value, "", res("ComputationDay").ToString())

                If IIf(res("PostingFrequency") Is System.DBNull.Value, "", res("PostingFrequency").ToString()) = "IMMEDIATE" Then
                    rad_PostingFrequency_1.Checked = True
                Else
                    rad_PostingFrequency_2.Checked = True
                End If
                If IIf(res("PostingPeriodType") Is System.DBNull.Value, "", res("PostingPeriodType").ToString()) = "DAILY" Then
                    rad_PostingPeriodType_1.Checked = True
                Else
                    rad_PostingPeriodType_2.Checked = True
                End If
                txt_PostingPeriod.Text = IIf(res("PostingPeriod") Is System.DBNull.Value, "", res("PostingPeriod").ToString())
                txt_PostingDay.Text = IIf(res("PostingDay") Is System.DBNull.Value, "", res("PostingDay").ToString())


            End If

            res.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rad_ApplyMinChg_Yes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_ApplyMinChg_Yes.CheckedChanged
        If rad_ApplyMinChg_Yes.Checked = True Then
            cbo_ApplyMinChgAmt.Enabled = True
        Else
            cbo_ApplyMinChgAmt.Text = ""
            cbo_ApplyMinChgAmt.Enabled = False
        End If

    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""

        If cbo_Product.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Product]"
        Else
            If cbo_Product.Text.Length > 10 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Product]. Must be less then 10 digit. "
            End If
        End If

        If cbo_Event.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Event]"
        Else
            If cbo_Event.Text.Length > 10 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Event]. Must be less then 10 digit. "
            End If
        End If

        'cbo_ApplyMinChgAmt:cbo_ApplyMinChgAmt
        If rad_ApplyMinChg_Yes.Checked = True Then
            If cbo_ApplyMinChgAmt.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Apply Min Chg]"
            Else
                If IsNumeric(cbo_ApplyMinChgAmt.Text.Replace(",", "")) = False Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Apply Min Chg]"
                End If
            End If
        End If

        If rad_ApplyMaxChg_Yes.Checked = True Then
            If cbo_ApplyMaxChgAmt.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Apply Max Chg]"
            Else
                If IsNumeric(cbo_ApplyMaxChgAmt.Text.Replace(",", "")) = False Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Apply Max Chg]"
                End If
            End If
        End If

        If rad_ApplyMinChg_Yes.Checked = True And rad_ApplyMaxChg_Yes.Checked = True Then
            If CDbl(cbo_ApplyMaxChgAmt.Text) < CDbl(cbo_ApplyMinChgAmt.Text) Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Apply Max Chg], Must be more than [Apply Min Chg]."
            End If
        End If

        If cbo_RoundingType.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rounding Type]"
        Else
            If cbo_RoundingType.Text.Length > 7 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rounding Type]. Must be less then 7 digit. "
            End If
        End If


            If cbo_RoundingAmnt.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rounding Amnt]"
            Else
                If IsNumeric(cbo_RoundingAmnt.Text.Replace(",", "")) = False Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rounding Amnt]"
                End If
            End If


        If txt_ComputationPeriod.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Period]"
            If IsNumeric(txt_ComputationPeriod.Text.Replace(",", "")) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Period]"
            End If
        End If


        If txt_ComputationDay.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Computation Day]"
        Else
            If IsNumeric(txt_ComputationDay.Text.Replace(",", "")) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Computation Day]"
            End If
        End If

        If txt_PostingPeriod.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Posting Period]"
        Else
            If IsNumeric(txt_PostingPeriod.Text.Replace(",", "")) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Posting Period]"
            End If
        End If
        'txt_PostingDay
        If txt_PostingDay.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Posting Day]"
        Else
            If IsNumeric(txt_PostingDay.Text.Replace(",", "")) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Posting Day]"
            End If
        End If


        Return strErr
    End Function

    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click
        Dim strErr As String = ""
        strErr = ValidationData()
        If strErr <> "" Then
            MessageBox.Show(strErr)
            Exit Sub
        End If
        Call SaveData()
    End Sub

    Private Function SaveData() As Boolean
        Try
            Dim strSQL As String = ""

            '========================add mode====================
            If strMODE.ToUpper = "ADD" Then


                strSQL = "SELECT * FROM [Inquiry_TemplateChargeEvents]  where ID='" & txt_GUID.Text & "'  and Event='" & cbo_Event.Text & "'"
                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid Event-Code is duplicate.")
                    Exit Function
                End If


                Dim strValue As String = ""
                Dim strFiledname As String = ""
                strSQL = ""

                strFiledname += vbCrLf & "[ID]"
                strValue += vbCrLf & "'" & txt_GUID.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[CreateDate]"
                strValue += vbCrLf & ",getdate() "


                strFiledname += vbCrLf & ",[Product]"
                strValue += vbCrLf & " , '" & cbo_Product.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[ProductCCY]"
                strValue += vbCrLf & " , '" & txt_ProductCCY.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[Event]"
                strValue += vbCrLf & " , '" & cbo_Event.Text.Replace("'", "''") & "'"



                strFiledname += ",[ApplyMinChg]"
                If rad_ApplyMinChg_Yes.Checked Then
                    strValue += vbCrLf & " , 'YES'"
                    strFiledname += vbCrLf & ",[ApplyMinChgAmt]"
                    strValue += vbCrLf & " , " & cbo_ApplyMinChgAmt.Text.Replace(",", "") & " "
                Else
                    strValue += vbCrLf & " , 'NO'"
                    strFiledname += vbCrLf & ",[ApplyMinChgAmt]"
                    strValue += vbCrLf & " , 0 "
                End If



                strFiledname += ",[ApplyMaxChg]"
                If rad_ApplyMaxChg_Yes.Checked Then
                    strValue += vbCrLf & " , 'YES'"
                    strFiledname += vbCrLf & ",[ApplyMaxChgAmt]"
                    strValue += vbCrLf & " , " & cbo_ApplyMaxChgAmt.Text.Replace(",", "") & " "
                Else
                    strValue += vbCrLf & " , 'NO'"
                    strFiledname += vbCrLf & ",[ApplyMaxChgAmt]"
                    strValue += vbCrLf & " , 0 "
                End If



                strFiledname += vbCrLf & ",[RoundingType]"
                strValue += vbCrLf & " , '" & cbo_RoundingType.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[RoundingAmnt]"
                strValue += vbCrLf & " , " & cbo_RoundingAmnt.Text.Replace(",", "") & ""

                strFiledname += ",[ComputationFrequency]"
                If rad_ComputationFrequency_1.Checked Then
                    strValue += vbCrLf & " , 'IMMEDIATE'"
                Else
                    strValue += vbCrLf & " , 'DEFERRED'"
                End If

                strFiledname += ",[ComputationPeriodType]"
                If rad_ComputationPeriodType_1.Checked Then
                    strValue += vbCrLf & " , 'DAILY'"
                Else
                    strValue += vbCrLf & " , 'MONTHLY'"
                End If

                strFiledname += vbCrLf & ",[ComputationPeriod]"
                strValue += vbCrLf & " , " & txt_ComputationPeriod.Text.Replace(",", "") & ""

                strFiledname += vbCrLf & ",[ComputationDay]"
                strValue += vbCrLf & " , " & txt_ComputationDay.Text.Replace(",", "") & ""

                strFiledname += vbCrLf & ",[NextComputationDate]"
                strValue += vbCrLf & " ,'' "

                strFiledname += ",[PostingFrequency]"
                If rad_PostingFrequency_1.Checked Then
                    strValue += vbCrLf & " , 'IMMEDIATE'"
                Else
                    strValue += vbCrLf & " , 'DEFERRED'"
                End If

                strFiledname += ",[PostingPeriodType]"
                If rad_PostingPeriodType_1.Checked Then
                    strValue += vbCrLf & " , 'DAILY'"
                Else
                    strValue += vbCrLf & " , 'MONTHLY'"
                End If

                strFiledname += vbCrLf & ",[PostingPeriod]"
                strValue += vbCrLf & " , " & txt_PostingPeriod.Text.Replace(",", "") & ""

                strFiledname += vbCrLf & ",[PostingDay]"
                strValue += vbCrLf & " , " & txt_PostingDay.Text.Replace(",", "") & ""

                strFiledname += vbCrLf & ",[NextPostingDate]"
                strValue += vbCrLf & " , '' "

                strSQL = ""
                strSQL += vbCrLf & "insert into [Inquiry_TemplateChargeEvents]"
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                If conn.ExecuteNonQuery(strSQL) = "" Then
                    Me.Close()
                End If

            End If ' If strMODE.ToUpper = "ADD" Then

            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [Inquiry_TemplateChargeEvents] set "

                strSQL += vbCrLf & "[Product]"
                strSQL += vbCrLf & " = '" & cbo_Product.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[ProductCCY]"
                strSQL += vbCrLf & " = '" & txt_ProductCCY.Text.Replace("'", "''") & "'"

                strSQL += ",[ApplyMinChg]"
                If rad_ApplyMinChg_Yes.Checked Then
                    strSQL += vbCrLf & " = 'YES'"
                Else
                    strSQL += vbCrLf & " = 'NO'"
                End If

                strSQL += vbCrLf & ",[ApplyMinChgAmt]"
                strSQL += vbCrLf & " = " & cbo_ApplyMinChgAmt.Text.Replace(",", "") & " "

                strSQL += ",[ApplyMaxChg]"
                If rad_ApplyMaxChg_Yes.Checked Then
                    strSQL += vbCrLf & " = 'YES'"
                Else
                    strSQL += vbCrLf & " = 'NO'"
                End If

                strSQL += vbCrLf & ",[ApplyMaxChgAmt]"
                strSQL += vbCrLf & " = " & cbo_ApplyMaxChgAmt.Text.Replace(",", "") & " "

                strSQL += vbCrLf & ",[RoundingType]"
                strSQL += vbCrLf & " = '" & cbo_RoundingType.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[RoundingAmnt]"
                strSQL += vbCrLf & " = " & cbo_RoundingAmnt.Text.Replace(",", "") & ""

                strSQL += ",[ComputationFrequency]"
                If rad_ComputationFrequency_1.Checked Then
                    strSQL += vbCrLf & " = 'IMMEDIATE'"
                Else
                    strSQL += vbCrLf & " = 'DEFERRED'"
                End If

                strSQL += ",[ComputationPeriodType]"
                If rad_ComputationPeriodType_1.Checked Then
                    strSQL += vbCrLf & " = 'DAILY'"
                Else
                    strSQL += vbCrLf & " = 'MONTHLY'"
                End If

                strSQL += vbCrLf & ",[ComputationPeriod]"
                strSQL += vbCrLf & " = " & txt_ComputationPeriod.Text.Replace(",", "") & ""

                strSQL += vbCrLf & ",[ComputationDay]"
                strSQL += vbCrLf & " = " & txt_ComputationDay.Text.Replace(",", "") & ""

                strSQL += vbCrLf & ",[NextComputationDate]"
                strSQL += vbCrLf & " ='' "

                strSQL += ",[PostingFrequency]"
                If rad_PostingFrequency_1.Checked Then
                    strSQL += vbCrLf & " = 'IMMEDIATE'"
                Else
                    strSQL += vbCrLf & " = 'DEFERRED'"
                End If

                strSQL += ",[PostingPeriodType]"
                If rad_PostingPeriodType_1.Checked Then
                    strSQL += vbCrLf & " = 'DAILY'"
                Else
                    strSQL += vbCrLf & " = 'MONTHLY'"
                End If

                strSQL += vbCrLf & ",[PostingPeriod]"
                strSQL += vbCrLf & " = " & txt_PostingPeriod.Text.Replace(",", "") & ""

                strSQL += vbCrLf & ",[PostingDay]"
                strSQL += vbCrLf & " = " & txt_PostingDay.Text.Replace(",", "") & ""

                strSQL += vbCrLf & ",[NextPostingDate]"
                strSQL += vbCrLf & " ='' "

                strSQL += vbCrLf & "  where ID='" & txt_GUID.Text & "'  and Event='" & cbo_Event.Text & "'"
                If conn.ExecuteNonQuery(strSQL) = "" Then
                    Me.Close()
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Function

    Private Sub rad_ComputationFrequency_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_ComputationFrequency_1.CheckedChanged
        Call RefreshComputationFrequency()
    End Sub

    Private Sub rad_ComputationPeriodType_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_ComputationPeriodType_2.CheckedChanged
        Call RefreshComputationPeriodType()
    End Sub

    Private Sub rad_ComputationFrequency_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_ComputationFrequency_2.CheckedChanged
        Call RefreshComputationFrequency()
    End Sub

    Private Sub RefreshComputationPeriodType()
        If rad_ComputationPeriodType_2.Checked = True Then
            txt_ComputationPeriod.Text = 1
            txt_ComputationDay.Text = 31
            txt_ComputationPeriod.Enabled = True
            txt_ComputationDay.Enabled = True
        Else
            txt_ComputationPeriod.Text = 1
            txt_ComputationDay.Text = 0
            txt_ComputationPeriod.Enabled = True
            txt_ComputationDay.Enabled = False
        End If
    End Sub

    Private Sub RefreshComputationFrequency()
        If rad_ComputationFrequency_1.Checked = True Then
            rad_ComputationPeriodType_1.Checked = True
            txt_ComputationPeriod.Text = 0
            txt_ComputationDay.Text = 0
            txt_ComputationPeriod.Enabled = False
            txt_ComputationDay.Enabled = False
        Else
            rad_ComputationPeriodType_2.Checked = True
        End If
    End Sub

    Private Sub rad_PostingFrequency_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_PostingFrequency_1.CheckedChanged
        Call RefreshPostingFrequency()
    End Sub

    Private Sub RefreshPostingFrequencyType()
        If rad_PostingPeriodType_2.Checked = True Then
            txt_PostingPeriod.Text = 1
            txt_PostingDay.Text = 31
            txt_PostingPeriod.Enabled = True
            txt_PostingDay.Enabled = True
        Else
            txt_PostingPeriod.Text = 1
            txt_PostingDay.Text = 0
            txt_PostingPeriod.Enabled = True
            txt_PostingDay.Enabled = False
        End If
    End Sub

    Private Sub RefreshPostingFrequency()
        If rad_PostingFrequency_1.Checked = True Then
            rad_PostingPeriodType_1.Checked = True
            txt_PostingPeriod.Text = 0
            txt_PostingDay.Text = 0
            txt_PostingPeriod.Enabled = False
            txt_PostingDay.Enabled = False
        Else
            rad_PostingPeriodType_2.Checked = True
        End If
    End Sub

    Private Sub rad_ApplyMinChg_No_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_ApplyMinChg_No.CheckedChanged
        If rad_ApplyMinChg_Yes.Checked = True Then
            cbo_ApplyMinChgAmt.Enabled = True
        Else
            cbo_ApplyMinChgAmt.Text = ""
            cbo_ApplyMinChgAmt.Enabled = False
        End If
    End Sub

    Private Sub rad_ApplyMaxChg_Yes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_ApplyMaxChg_Yes.CheckedChanged
        If rad_ApplyMaxChg_Yes.Checked Then
            cbo_ApplyMaxChgAmt.Enabled = True
        Else
            cbo_ApplyMaxChgAmt.Enabled = False
            cbo_ApplyMaxChgAmt.Text = ""
        End If
    End Sub

    Private Sub rad_PostingPeriodType_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_PostingPeriodType_2.CheckedChanged
        Call RefreshPostingFrequencyType()
    End Sub

    Private Sub rad_PostingPeriodType_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_PostingPeriodType_1.CheckedChanged
        Call RefreshPostingFrequencyType()
    End Sub

    Private Sub Frm_TemplateChargeEvent_Edit_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub Frm_TemplateChargeEvent_Edit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

End Class



'Public tp As String = "", ev As String = ""
'Dim conn As CSQL
'Dim res As SqlDataReader
'Dim sql_cmd As String, add_cmd As String

'Private Sub Frm_Add_Event_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'    conn = New CSQL
'    'conn.TP_PRD_SetList("Product", CB_PD)
'    'conn.TP_CE_SetList("Event", CP_EV)
'    'conn.TP_CE_SetList("ApplyMinChg", minC3)
'    'conn.TP_CE_SetList("ApplyMaxChg", maxC3)
'    'conn.TP_CE_SetList("RoundingType", cb_rounding)
'    'conn.TP_CE_SetList("RoundingAmnt", RAT)

'    conn.Connect()
'    conn.Query("SELECT * FROM [Inquiry_TemplateChargeEvents] WHERE [tID] ='" + tp + "' AND [Event] ='" + ev + "'", res)
'    res.Read()

'    'CB_PD.Text = res(1).ToString()
'    CP_EV.Text = res(3).ToString()
'    Set_Radiobox(minC1, minC2, res(4).ToString())
'    minC3.Text = res(5).ToString()
'    Set_Radiobox(maxC1, maxC2, res(6).ToString())
'    maxC3.Text = res(7).ToString()
'    cb_rounding.Text = res(8).ToString()
'    RAT.Text = res(9).ToString()
'    Set_Radiobox(CF1, CF2, res(11).ToString())
'    Set_Radiobox(CPT1, CPT2, res(12).ToString())
'    CPD.Text = res(13).ToString()
'    CDAY.Text = res(14).ToString()
'    Set_Radiobox(PF1, PF2, res(16).ToString())
'    Set_Radiobox(FPT1, FPT2, res(17).ToString())
'    PPD.Text = res(18).ToString()
'    PDAY.Text = res(19).ToString()
'End Sub

'Private Sub Set_Radiobox(ByRef r1 As RadioButton, ByRef r2 As RadioButton, ByVal val As String)
'    Select Case (val.ToUpper())
'        Case "YES"
'            r1.Checked = True
'        Case "PIR"
'            r1.Checked = True
'        Case "DAILY"
'            r1.Checked = True
'        Case "AUTOMATIC"
'            r1.Checked = True

'        Case "NO"
'            r2.Checked = True
'        Case "INSTRUMENTS"
'            r2.Checked = True
'        Case "MONTHLY"
'            r2.Checked = True
'        Case "MANUAL"
'            r2.Checked = True
'        Case Else
'            r2.Checked = True
'    End Select
'End Sub

'Private Function Get_Radiobox(ByRef r1 As RadioButton, ByRef r2 As RadioButton) As String
'    If r1.Checked = True Then
'        Get_Radiobox = r1.Text.ToUpper()
'    Else
'        Get_Radiobox = r2.Text.ToUpper()
'    End If
'End Function

'Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
'    Me.Close()
'End Sub

'Private Sub Frm_Add_Event_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
'    If e.KeyChar = Chr(27) Then Me.Close()
'End Sub

'Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click
'    conn.Connect()
'    sql_cmd = "UPDATE [Inquiry_TemplateChargeEvents] SET "
'    sql_cmd += "[Event] ='" + CP_EV.Text + "'"
'    sql_cmd += ",[ApplyMinChg]='" + Get_Radiobox(minC1, minC2) + "'"
'    sql_cmd += ",[ApplyMinChgAmt]='" + minC3.Text + "'"
'    sql_cmd += ",[ApplyMaxChg]='" + Get_Radiobox(maxC1, maxC2) + "'"
'    sql_cmd += ",[ApplyMaxChgAmt]='" + maxC3.Text + "'"
'    sql_cmd += ",[RoundingType]='" + cb_rounding.Text + "'"
'    sql_cmd += ",[RoundingAmnt]='" + RAT.Text + "'"
'    sql_cmd += ",[ComputationFrequency]='" + Get_Radiobox(CF1, CF2) + "'"
'    If Get_Radiobox(CPT1, CPT2) = "MONTHLY" Then
'        sql_cmd += ",[ComputationPeriodType]='MONTHS'"
'    Else
'        sql_cmd += ",[ComputationPeriodType]='" + Get_Radiobox(CPT1, CPT2) + "'"
'    End If

'    sql_cmd += ",[ComputationPeriod]='" + CPD.Text + "'"
'    sql_cmd += ",[ComputationDay]='" + CDAY.Text + "'"
'    sql_cmd += ",[PostingFrequency]='" + Get_Radiobox(PF1, PF2) + "'"
'    If Get_Radiobox(FPT1, FPT2) = "MONTHLY" Then
'        sql_cmd += ",[PostingPeriodType]='MONTHS'"
'    Else
'        sql_cmd += ",[PostingPeriodType]='" + Get_Radiobox(FPT1, FPT2) + "'"
'    End If

'    sql_cmd += ",[PostingPeriod]='" + PPD.Text + "'"
'    sql_cmd += ",[PostingDay]='" + PDAY.Text + "'"
'    sql_cmd += " WHERE [tID]='" + tp + "' AND [Event] ='" + ev + "'"
'    conn.Query(sql_cmd, res)
'    Me.Close()
'End Sub

'Private Sub minC1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles minC1.CheckedChanged
'    minC3.Enabled = True
'End Sub

'Private Sub minC2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles minC2.CheckedChanged
'    minC2.Enabled = False
'End Sub

'Private Sub maxC1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles maxC1.CheckedChanged
'    maxC3.Enabled = True
'End Sub

'Private Sub maxC2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles maxC2.CheckedChanged
'    maxC3.Enabled = False
'End Sub
