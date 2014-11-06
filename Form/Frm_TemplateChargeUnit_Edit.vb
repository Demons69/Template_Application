Imports Template_Application.CSQL
Imports System.Data.SqlClient


Public Class Frm_TemplateChargeUnit_Edit
    Dim conn As CSQL
    Public strMODE As String = "ADD"
    Dim intRow As Integer


    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub Frm_TemplateChargeUnit_Edit_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub Frm_TemplateChargeEvent_Edit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ChekingNumberControls(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If grp_chg.Controls.Item(sender.name).text <> "" Then
            If IsNumeric(grp_chg.Controls.Item(sender.name).text) = False Then
                grp_chg.Controls.Item(sender.name).text = "0"
            End If
        End If
    End Sub

    Private Sub Frm_TemplateChargeUnit_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     

        Try
            Dim i As Integer
            For i = 1 To 11

                AddHandler grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Validated, AddressOf ChekingNumberControls
                AddHandler grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Validated, AddressOf ChekingNumberControls
                AddHandler grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Validated, AddressOf ChekingNumberControls
             

            Next i

            Me.KeyPreview = True
            conn = New CSQL
            Dim strSQL As String = ""
            'strSQL = "select [Code] from dbo.TB_ListOfValue WHERE TableName ='UNIT' AND ColumnName = 'Product'"
            strSQL = "select Product from dbo.PRD_TemplateChargeUnits group by Product order by Product"
            conn.Fill_ComboBox(strSQL, cbo_Product)
            'cbo_Class
            'strSQL = "select [Code] from dbo.TB_ListOfValue WHERE TableName ='UNIT' AND ColumnName = 'CLASS'"
            strSQL = "select CLASS from dbo.PRD_TemplateChargeUnits group by CLASS order by CLASS"
            conn.Fill_ComboBox(strSQL, cbo_Class)

            'strSQL = "select [Code] from dbo.TB_ListOfValue WHERE TableName ='UNIT' AND ColumnName = 'ChargeCategory'"
            strSQL = "select ChargeCategory from dbo.PRD_TemplateChargeUnits group by ChargeCategory order by ChargeCategory"
            conn.Fill_ComboBox(strSQL, cbo_ChargeCategory)

            strSQL = "select ChargeUnitCode from dbo.PRD_TemplateChargeUnits group by ChargeUnitCode order by ChargeUnitCode"
            conn.Fill_ComboBox(strSQL, cbo_ChargeUnitCode)

            strSQL = "select Description from dbo.PRD_TemplateChargeUnits group by Description order by Description "
            conn.Fill_ComboBox(strSQL, cbo_Description)

            strSQL = "select ApplyMinChgAmount from dbo.PRD_TemplateChargeUnits group by ApplyMinChgAmount order by ApplyMinChgAmount"
            conn.Fill_ComboBox(strSQL, cbo_ApplyMinChgAmount)

            strSQL = "select ApplyMaxChgAmount from dbo.PRD_TemplateChargeUnits group by ApplyMaxChgAmount order by ApplyMaxChgAmount"
            conn.Fill_ComboBox(strSQL, cbo_ApplyMaxChgAmount)

            strSQL = "select Rounding from dbo.PRD_TemplateChargeUnits group by Rounding order by Rounding"
            conn.Fill_ComboBox(strSQL, cbo_Rounding)

            strSQL = "select RoundingAmount from dbo.PRD_TemplateChargeUnits group by RoundingAmount order by RoundingAmount"
            conn.Fill_ComboBox(strSQL, cbo_RoundingAmount)

            'strSQL = "select [Code] from dbo.TB_ListOfValue WHERE TableName ='UNIT' AND ColumnName = 'ComputationBasis'"
            strSQL = "select ComputationBasis from dbo.PRD_TemplateChargeUnits group by ComputationBasis order by ComputationBasis"
            conn.Fill_ComboBox(strSQL, cbo_ComputationBasis)

            'strSQL = "select [Code] from dbo.TB_ListOfValue WHERE TableName ='UNIT' AND ColumnName = 'ChargeType'"
            strSQL = "select ChargeType from dbo.PRD_TemplateChargeUnits group by ChargeType order by ChargeType"
            conn.Fill_ComboBox(strSQL, cbo_ChargeType)

            'strSQL = "select [Code] from dbo.TB_ListOfValue WHERE TableName ='UNIT' AND ColumnName = 'InterestPeriod'"
            strSQL = "select InterestPeriod from dbo.PRD_TemplateChargeUnits group by InterestPeriod order by InterestPeriod"
            conn.Fill_ComboBox(strSQL, cbo_InterestPeriod)

            'strSQL = "select [Code] from dbo.TB_ListOfValue WHERE TableName ='UNIT' AND ColumnName = 'BaseRate'"
            strSQL = "select BaseRate from dbo.PRD_TemplateChargeUnits group by BaseRate order by BaseRate"
            conn.Fill_ComboBox(strSQL, cbo_BaseRate)

            cbo_ApplyMinChgAmount.Enabled = False
            cbo_ApplyMaxChgAmount.Enabled = False
            intRow = 1
            Call SetControlGroup_Charge(intRow)
            If strMODE <> "ADD" Then
                Call ShowData()
                cbo_Product.Enabled = False
                ' cbo_Event.Enabled = False
            Else
                If txt_TemplateCode.Text <> "" Then
                    cbo_Product.Text = txt_TemplateCode.Text.Substring(0, 3)
                End If
                txt_LowerLimit_1.Text = "0"
                txt_UpperLimit_1.Text = "0"
                txt_FixedAmount_1.Text = "0"
                txt_BasisPoints_1.Text = "0"
                'D-RUL-INST
                cbo_ChargeCategory.Text = "D-RUL-INST"
                cbo_ChargeUnitCode.Text = cbo_Product.Text & "CHG"
                cbo_Description.Text = "CHARGE FOR " & cbo_Product.Text
                cbo_Rounding.Text = "None"
                cbo_RoundingAmount.Text = "0"
                cbo_ChargeType.Text = "Single Rate"
                cbo_ComputationBasis.Text = "Count-Based"

            End If

            '   If cbo_ApplyMaxChgAmt.Text = "" Then cbo_ApplyMaxChgAmt.Text = 0
            ' If cbo_ApplyMaxChgAmt.Text = "" Then cbo_ApplyMaxChgAmt.Text = 0
            cbo_Product.Enabled = False
            Call RefreshChargeType()
            Call SetCaptionComputationBasis()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ShowData()
        Try
            Dim res As SqlDataReader
            Dim strSQL As String = ""
            strSQL = "SELECT * FROM [Inquiry_TemplateChargeUnits] where ID='" & txt_GUID.Text & "'  and row_id='" & txt_row_id.Text & "'"
            res = conn.GetDataReader(strSQL)

            If res.HasRows = True Then
                res.Read()
                cbo_Class.Text = IIf(res("Class") Is System.DBNull.Value, "", res("Class").ToString())
                cbo_Product.Text = IIf(res("Product") Is System.DBNull.Value, "", res("Product").ToString())
                cbo_ChargeCategory.Text = IIf(res("ChargeCategory") Is System.DBNull.Value, "", res("ChargeCategory").ToString())
                cbo_ChargeUnitCode.Text = IIf(res("ChargeUnitCode") Is System.DBNull.Value, "", res("ChargeUnitCode").ToString())
                cbo_Description.Text = IIf(res("Description") Is System.DBNull.Value, "", res("Description").ToString())

                If IIf(res("ApplyMinchg") Is System.DBNull.Value, "", res("ApplyMinchg").ToString()) = "YES" Then
                    rad_ApplyMinchg_y.Checked = True
                Else
                    rad_ApplyMinchg_n.Checked = True
                End If
                cbo_ApplyMinChgAmount.Text = IIf(res("ApplyMinChgAmount") Is System.DBNull.Value, "", res("ApplyMinChgAmount").ToString())

                If IIf(res("ApplyMaxChg") Is System.DBNull.Value, "", res("ApplyMaxChg").ToString()) = "YES" Then
                    rad_ApplyMaxChg_y.Checked = True
                Else
                    rad_ApplyMaxChg_n.Checked = True
                End If
                cbo_ApplyMaxChgAmount.Text = IIf(res("ApplyMaxChgAmount") Is System.DBNull.Value, "", res("ApplyMaxChgAmount").ToString())
                cbo_Rounding.Text = IIf(res("Rounding") Is System.DBNull.Value, "", res("Rounding").ToString())
                cbo_RoundingAmount.Text = IIf(res("RoundingAmount") Is System.DBNull.Value, "", res("RoundingAmount").ToString())

                cbo_ComputationBasis.Text = IIf(res("ComputationBasis") Is System.DBNull.Value, "", res("ComputationBasis").ToString())
                cbo_ChargeType.Text = IIf(res("ChargeType") Is System.DBNull.Value, "", res("ChargeType").ToString())
                cbo_InterestPeriod.Text = IIf(res("InterestPeriod") Is System.DBNull.Value, "", res("InterestPeriod").ToString())
                cbo_BaseRate.Text = IIf(res("BaseRate") Is System.DBNull.Value, "", res("BaseRate").ToString())

                If IIf(res("ImmediatePosting") Is System.DBNull.Value, "", res("ImmediatePosting").ToString()) = "YES" Then
                    rad_ImmediatePosting_y.Checked = True
                Else
                    rad_ImmediatePosting_n.Checked = True
                End If

                If IIf(res("ImmediateCompn") Is System.DBNull.Value, "", res("ImmediateCompn").ToString()) = "YES" Then
                    rad_ImmediateCompn_y.Checked = True
                Else
                    rad_ImmediateCompn_n.Checked = True
                End If
                '=============1==========

                txt_LowerLimit_1.Text = IIf(res("LowerLimit1") Is System.DBNull.Value, "", res("LowerLimit1").ToString())
                txt_UpperLimit_1.Text = IIf(res("UpperLimit1") Is System.DBNull.Value, "", res("UpperLimit1").ToString())
                txt_FixedAmount_1.Text = IIf(res("FixedAmount1") Is System.DBNull.Value, "", res("FixedAmount1").ToString())
                txt_BasisPoints_1.Text = IIf(res("BasisPoints1") Is System.DBNull.Value, "", res("BasisPoints1").ToString())
                If txt_LowerLimit_1.Text <> "" And txt_LowerLimit_1.Text > "0" Then intRow = 1
                '=============2==========
                txt_LowerLimit_2.Text = IIf(res("LowerLimit2") Is System.DBNull.Value, "", res("LowerLimit2").ToString())
                txt_UpperLimit_2.Text = IIf(res("UpperLimit2") Is System.DBNull.Value, "", res("UpperLimit2").ToString())
                txt_FixedAmount_2.Text = IIf(res("FixedAmount2") Is System.DBNull.Value, "", res("FixedAmount2").ToString())
                txt_BasisPoints_2.Text = IIf(res("BasisPoints2") Is System.DBNull.Value, "", res("BasisPoints2").ToString())
                If txt_LowerLimit_2.Text <> "" And txt_LowerLimit_2.Text > "0" Then intRow = 2
                '=============3==========
                txt_LowerLimit_3.Text = IIf(res("LowerLimit3") Is System.DBNull.Value, "", res("LowerLimit3").ToString())
                txt_UpperLimit_3.Text = IIf(res("UpperLimit3") Is System.DBNull.Value, "", res("UpperLimit3").ToString())
                txt_FixedAmount_3.Text = IIf(res("FixedAmount3") Is System.DBNull.Value, "", res("FixedAmount3").ToString())
                txt_BasisPoints_3.Text = IIf(res("BasisPoints3") Is System.DBNull.Value, "", res("BasisPoints3").ToString())
                If txt_LowerLimit_3.Text <> "" And txt_LowerLimit_3.Text > "0" Then intRow = 3
                '=============4==========
                txt_LowerLimit_4.Text = IIf(res("LowerLimit4") Is System.DBNull.Value, "", res("LowerLimit4").ToString())
                txt_UpperLimit_4.Text = IIf(res("UpperLimit4") Is System.DBNull.Value, "", res("UpperLimit4").ToString())
                txt_FixedAmount_4.Text = IIf(res("FixedAmount4") Is System.DBNull.Value, "", res("FixedAmount4").ToString())
                txt_BasisPoints_4.Text = IIf(res("BasisPoints4") Is System.DBNull.Value, "", res("BasisPoints4").ToString())
                If txt_LowerLimit_4.Text <> "" And txt_LowerLimit_4.Text > "0" Then intRow = 4
                '=============5==========
                txt_LowerLimit_5.Text = IIf(res("LowerLimit5") Is System.DBNull.Value, "", res("LowerLimit5").ToString())
                txt_UpperLimit_5.Text = IIf(res("UpperLimit5") Is System.DBNull.Value, "", res("UpperLimit5").ToString())
                txt_FixedAmount_5.Text = IIf(res("FixedAmount5") Is System.DBNull.Value, "", res("FixedAmount5").ToString())
                txt_BasisPoints_5.Text = IIf(res("BasisPoints5") Is System.DBNull.Value, "", res("BasisPoints5").ToString())
                If txt_LowerLimit_5.Text <> "" And txt_LowerLimit_5.Text > "0" Then intRow = 5
                '=============6==========
                txt_LowerLimit_6.Text = IIf(res("LowerLimit6") Is System.DBNull.Value, "", res("LowerLimit6").ToString())
                txt_UpperLimit_6.Text = IIf(res("UpperLimit6") Is System.DBNull.Value, "", res("UpperLimit6").ToString())
                txt_FixedAmount_6.Text = IIf(res("FixedAmount6") Is System.DBNull.Value, "", res("FixedAmount6").ToString())
                txt_BasisPoints_6.Text = IIf(res("BasisPoints6") Is System.DBNull.Value, "", res("BasisPoints6").ToString())
                If txt_LowerLimit_6.Text <> "" And txt_LowerLimit_6.Text > "0" Then intRow = 6
                '=============7==========
                txt_LowerLimit_7.Text = IIf(res("LowerLimit7") Is System.DBNull.Value, "", res("LowerLimit7").ToString())
                txt_UpperLimit_7.Text = IIf(res("UpperLimit7") Is System.DBNull.Value, "", res("UpperLimit7").ToString())
                txt_FixedAmount_7.Text = IIf(res("FixedAmount7") Is System.DBNull.Value, "", res("FixedAmount7").ToString())
                txt_BasisPoints_7.Text = IIf(res("BasisPoints7") Is System.DBNull.Value, "", res("BasisPoints7").ToString())
                If txt_LowerLimit_7.Text <> "" And txt_LowerLimit_7.Text > "0" Then intRow = 7
                '=============8==========
                txt_LowerLimit_8.Text = IIf(res("LowerLimit8") Is System.DBNull.Value, "", res("LowerLimit8").ToString())
                txt_UpperLimit_8.Text = IIf(res("UpperLimit8") Is System.DBNull.Value, "", res("UpperLimit8").ToString())
                txt_FixedAmount_8.Text = IIf(res("FixedAmount8") Is System.DBNull.Value, "", res("FixedAmount8").ToString())
                txt_BasisPoints_8.Text = IIf(res("BasisPoints8") Is System.DBNull.Value, "", res("BasisPoints8").ToString())
                If txt_LowerLimit_8.Text <> "" And txt_LowerLimit_8.Text > "0" Then intRow = 8
                '=============9==========
                txt_LowerLimit_9.Text = IIf(res("LowerLimit9") Is System.DBNull.Value, "", res("LowerLimit9").ToString())
                txt_UpperLimit_9.Text = IIf(res("UpperLimit9") Is System.DBNull.Value, "", res("UpperLimit9").ToString())
                txt_FixedAmount_9.Text = IIf(res("FixedAmount9") Is System.DBNull.Value, "", res("FixedAmount9").ToString())
                txt_BasisPoints_9.Text = IIf(res("BasisPoints9") Is System.DBNull.Value, "", res("BasisPoints9").ToString())
                If txt_LowerLimit_9.Text <> "" And txt_LowerLimit_9.Text > "0" Then intRow = 9
                '=============10==========
                txt_LowerLimit_10.Text = IIf(res("LowerLimit10") Is System.DBNull.Value, "", res("LowerLimit10").ToString())
                txt_UpperLimit_10.Text = IIf(res("UpperLimit10") Is System.DBNull.Value, "", res("UpperLimit10").ToString())
                txt_FixedAmount_10.Text = IIf(res("FixedAmount10") Is System.DBNull.Value, "", res("FixedAmount10").ToString())
                txt_BasisPoints_10.Text = IIf(res("BasisPoints10") Is System.DBNull.Value, "", res("BasisPoints10").ToString())
                If txt_LowerLimit_10.Text <> "" And txt_LowerLimit_10.Text > "0" Then intRow = 10
                '=============11==========
                txt_LowerLimit_11.Text = IIf(res("LowerLimit11") Is System.DBNull.Value, "", res("LowerLimit11").ToString())
                txt_UpperLimit_11.Text = IIf(res("UpperLimit11") Is System.DBNull.Value, "", res("UpperLimit11").ToString())
                txt_FixedAmount_11.Text = IIf(res("FixedAmount11") Is System.DBNull.Value, "", res("FixedAmount11").ToString())
                txt_BasisPoints_11.Text = IIf(res("BasisPoints11") Is System.DBNull.Value, "", res("BasisPoints11").ToString())
                If txt_LowerLimit_11.Text <> "" And txt_LowerLimit_11.Text > "0" Then intRow = 11

                Call SetControlGroup_Charge(intRow)
            End If

            res.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click
        Dim strErr As String = ""
        strErr = ValidationData()
        If strErr <> "" Then
            MessageBox.Show(strErr)
            Exit Sub
        End If
        If strMODE.ToUpper = "ADD" Then
            Call NewData()
        Else
            Call EditData()
        End If
    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""

        If txt_TemplateCode.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Template Code]"
        Else
            If txt_TemplateCode.Text.Length > 10 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Template Code]. Must be less then 10 digit. "
            End If
        End If

        If cbo_Product.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Product]"
        Else
            If cbo_Product.Text.Length > 10 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Product]. Must be less then 10 digit. "
            End If
        End If

        If cbo_Class.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Class]"
        Else
            If cbo_Class.Text.Length > 10 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Class]. Must be less then 10 digit. "
            End If
        End If

        If cbo_ChargeCategory.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Charge Category]"
        Else
            If cbo_ChargeCategory.Text.Length > 40 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Charge Category]. Must be less then 40 digit. "
            End If
        End If

        If cbo_ChargeUnitCode.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Charge Unit Code]"
        Else
            If cbo_ChargeCategory.Text.Length > 256 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Charge Unit Code]. Must be less then 256 digit. "
            End If
        End If

        If cbo_Description.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Description]"
        Else
            If cbo_ChargeCategory.Text.Length > 256 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Description]. Must be less then 256 digit. "
            End If
        End If

        If rad_ApplyMinchg_y.Checked = True Then
            If cbo_ApplyMinChgAmount.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Apply Min Chg]"
            Else
                If IsNumeric(cbo_ApplyMinChgAmount.Text.Replace(",", "")) = False Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Apply Min Chg]"
                End If
            End If
        End If

        If rad_ApplyMaxChg_y.Checked = True Then
            If cbo_ApplyMaxChgAmount.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Apply Min Chg]"
            Else
                If IsNumeric(cbo_ApplyMaxChgAmount.Text.Replace(",", "")) = False Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Apply Max Chg]"
                End If
            End If
        End If

        If rad_ApplyMinchg_y.Checked = True And rad_ApplyMaxChg_y.Checked = True Then
            If CDbl(cbo_ApplyMaxChgAmount.Text) < CDbl(cbo_ApplyMinChgAmount.Text) Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Apply Max Chg], Must be more than [Apply Min Chg]."
            End If
        End If

        If cbo_Rounding.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rounding]"
        Else
            If cbo_Rounding.Text.Length > 7 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rounding]. Must be less then 7 digit. "
            End If
        End If

        If cbo_RoundingAmount.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rounding Amount]"
        Else
            If IsNumeric(cbo_RoundingAmount.Text.Replace(",", "")) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rounding Amount]"
            End If
        End If
        If cbo_ComputationBasis.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Computation Basis]"
        Else
            If cbo_ChargeCategory.Text.Length > 14 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Computation Basis]. Must be less then 14 digit. "
            End If
        End If
        If cbo_ChargeType.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Charge Type]"
        Else
            If cbo_ChargeType.Text.Length > 14 Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Charge Type]. Must be less then 14 digit. "
            End If
        End If


        Dim i As Integer
        For i = 1 To 11
            If grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text <> "" Then
                If grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Text = "" Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Upper Limit (" & i.ToString & ")]"
                Else
                    If IsNumeric(grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Text.Replace(",", "")) = False Then
                        strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Upper Limit (" & i.ToString & ")]"
                    End If
                End If

                If grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Text = "" Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Fixed Amount (" & i.ToString & ")]"
                Else
                    If IsNumeric(grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Text.Replace(",", "")) = False Then
                        strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Fixed Amount (" & i.ToString & ")]"
                    End If
                End If

                If grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Text = "" Then
                    strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Percentage Value (" & i.ToString & ")]"
                Else
                    If IsNumeric(grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Text.Replace(",", "")) = False Then
                        strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Percentage Value (" & i.ToString & ")]"
                    End If
                End If

            End If 'If grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text <> "" And grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text <> "0" Then
        Next i

       


        Return strErr
    End Function

    Private Function NewData() As Boolean
        Try
            Dim strSQL As String = ""

            Dim strValue As String = ""
            Dim strFiledname As String = ""
            '===========row_id auto generate======
            strFiledname += vbCrLf & "[ID]"
            strValue += vbCrLf & "'" & txt_GUID.Text.Replace("'", "''") & "'"

            strFiledname += vbCrLf & ",[CreateDate]"
            strValue += vbCrLf & ",getdate() "

            strFiledname += vbCrLf & ",[Class]"
            strValue += vbCrLf & " , '" & cbo_Class.Text.Replace("'", "''") & "'"

            strFiledname += vbCrLf & ",[Product]"
            strValue += vbCrLf & " , '" & cbo_Product.Text.Replace("'", "''") & "'"
            'cbo_ChargeCategory
            strFiledname += vbCrLf & ",[ChargeCategory]"
            strValue += vbCrLf & " , '" & cbo_ChargeCategory.Text.Replace("'", "''") & "'"

            strFiledname += vbCrLf & ",[ProductCCY]"
            strValue += vbCrLf & " , '" & txt_ProductCCY.Text.Replace("'", "''") & "'"

            strFiledname += vbCrLf & ",[ChargesDefinedFor]"
            strValue += vbCrLf & " , '' "

            strFiledname += vbCrLf & ",[Event]"
            strValue += vbCrLf & " , ''"

            strFiledname += vbCrLf & ",[ChargeUnitCode]"
            strValue += vbCrLf & " , '" & cbo_ChargeUnitCode.Text.Replace("'", "''") & "'"

            strFiledname += vbCrLf & ",[Description]"
            strValue += vbCrLf & " , '" & cbo_Description.Text.Replace("'", "''") & "'"

            strFiledname += ",[ApplyMinchg]"
            If rad_ApplyMinchg_y.Checked Then
                strValue += vbCrLf & " , 'YES'"

                strFiledname += vbCrLf & ",[ApplyMinChgAmount]"
                strValue += vbCrLf & " , " & cbo_ApplyMinChgAmount.Text.Replace(",", "") & " "

            Else
                strValue += vbCrLf & " , 'NO'"
                strFiledname += vbCrLf & ",[ApplyMinChgAmount]"
                strValue += vbCrLf & " ,0 "
            End If



            strFiledname += ",[ApplyMaxChg]"
            If rad_ApplyMaxChg_y.Checked Then
                strValue += vbCrLf & " , 'YES'"
                strFiledname += vbCrLf & ",[ApplyMaxChgAmount]"
                strValue += vbCrLf & " , " & cbo_ApplyMaxChgAmount.Text.Replace(",", "") & " "

            Else
                strValue += vbCrLf & " , 'NO'"
                strFiledname += vbCrLf & ",[ApplyMaxChgAmount]"
                strValue += vbCrLf & " , 0  "
            End If



            strFiledname += vbCrLf & ",[Rounding]"
            strValue += vbCrLf & " , '" & cbo_Rounding.Text.Replace("'", "''") & "'"

            strFiledname += vbCrLf & ",[RoundingAmount]"
            strValue += vbCrLf & " , " & cbo_RoundingAmount.Text.Replace(",", "") & ""

            strFiledname += vbCrLf & ",[TemplateEffectiveFrom]"
            strValue += vbCrLf & " , '' "

            strFiledname += vbCrLf & ",[ComputationBasis]"
            strValue += vbCrLf & " , '" & cbo_ComputationBasis.Text.Replace("'", "''") & "'"

            strFiledname += vbCrLf & ",[ChargeType]"
            strValue += vbCrLf & " , '" & cbo_ChargeType.Text.Replace("'", "''") & "'"

            strFiledname += vbCrLf & ",[InterestPeriod]"
            strValue += vbCrLf & " , '" & cbo_InterestPeriod.Text.Replace("'", "''") & "'"

            strFiledname += vbCrLf & ",[BaseRate]"
            strValue += vbCrLf & " , '" & cbo_BaseRate.Text.Replace("'", "''") & "'"

            strFiledname += ",[ImmediatePosting]"
            If rad_ImmediatePosting_y.Checked Then
                strValue += vbCrLf & " , 'YES'"
            Else
                strValue += vbCrLf & " , 'NO'"
            End If

            strFiledname += ",[ImmediateCompn]"
            If rad_ImmediateCompn_y.Checked Then
                strValue += vbCrLf & " , 'YES'"
            Else
                strValue += vbCrLf & " , 'NO'"
            End If
            '===============charg amount ====================
            '==1=====
            Dim i As Integer
            For i = 1 To 11
                If grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text <> "" Then
                    strFiledname += vbCrLf & ",[LowerLimit" & i.ToString & "]"
                    strValue += vbCrLf & " , " & grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text.Replace(",", "") & ""
                    strFiledname += vbCrLf & ",[UpperLimit" & i.ToString & "]"
                    strValue += vbCrLf & " , " & grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Text.Replace(",", "") & ""
                    strFiledname += vbCrLf & ",[FixedAmount" & i.ToString & "]"
                    strValue += vbCrLf & " , " & grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Text.Replace(",", "") & ""
                    strFiledname += vbCrLf & ",[BasisPoints" & i.ToString & "]"
                    strValue += vbCrLf & " , " & grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Text.Replace(",", "") & ""
                End If 'If grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text <> "" And grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text <> "0" Then
            Next i


            strSQL = ""
            strSQL += vbCrLf & "insert into [Inquiry_TemplateChargeUnits]"
            strSQL += vbCrLf & "(" & strFiledname & ")"
            strSQL += vbCrLf & " VALUES (" & strValue & ")"

            If conn.ExecuteNonQuery(strSQL) = "" Then
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Function EditData() As Boolean
        Try
            Dim strSQL As String = ""

            strSQL = ""
            strSQL += vbCrLf & "update [Inquiry_TemplateChargeUnits] set "

            strSQL += vbCrLf & "[Product]"
            strSQL += vbCrLf & " = '" & cbo_Product.Text.Replace("'", "''") & "'"
            'cbo_ChargeCategory
            strSQL += vbCrLf & ",[ChargeCategory]"
            strSQL += vbCrLf & " = '" & cbo_ChargeCategory.Text.Replace("'", "''") & "'"

            strSQL += vbCrLf & ",[Class]"
            strSQL += vbCrLf & " = '" & cbo_Class.Text.Replace("'", "''") & "'"

            strSQL += vbCrLf & ",[ProductCCY]"
            strSQL += vbCrLf & " = '" & txt_ProductCCY.Text.Replace("'", "''") & "'"

            strSQL += vbCrLf & ",[ChargesDefinedFor]"
            strSQL += vbCrLf & " = '' "

            strSQL += vbCrLf & ",[Event]"
            strSQL += vbCrLf & " = ''"



            strSQL += vbCrLf & ",[ChargeUnitCode]"
            strSQL += vbCrLf & " = '" & cbo_ChargeUnitCode.Text.Replace("'", "''") & "'"

            strSQL += vbCrLf & ",[Description]"
            strSQL += vbCrLf & " = '" & cbo_Description.Text.Replace("'", "''") & "'"

            strSQL += ",[ApplyMinchg]"
            If rad_ApplyMinchg_y.Checked Then
                strSQL += vbCrLf & " = 'YES'"
                strSQL += vbCrLf & ",[ApplyMinChgAmount]"
                strSQL += vbCrLf & " = " & cbo_ApplyMinChgAmount.Text.Replace(",", "") & " "
            Else
                strSQL += vbCrLf & " = 'NO'"
                strSQL += vbCrLf & ",[ApplyMinChgAmount]"
                strSQL += vbCrLf & " = 0  "
            End If



            strSQL += ",[ApplyMaxChg]"
            If rad_ApplyMaxChg_y.Checked Then
                strSQL += vbCrLf & " = 'YES'"
                strSQL += vbCrLf & ",[ApplyMaxChgAmount]"
                strSQL += vbCrLf & " = " & cbo_ApplyMaxChgAmount.Text.Replace(",", "") & " "
            Else
                strSQL += vbCrLf & " = 'NO'"
                strSQL += vbCrLf & ",[ApplyMaxChgAmount]"
                strSQL += vbCrLf & " = 0 "
            End If



            strSQL += vbCrLf & ",[Rounding]"
            strSQL += vbCrLf & " = '" & cbo_Rounding.Text.Replace("'", "''") & "'"

            strSQL += vbCrLf & ",[RoundingAmount]"
            strSQL += vbCrLf & " = " & cbo_RoundingAmount.Text.Replace(",", "") & ""

            strSQL += vbCrLf & ",[TemplateEffectiveFrom]"
            strSQL += vbCrLf & " = '' "

            strSQL += vbCrLf & ",[ComputationBasis]"
            strSQL += vbCrLf & " = '" & cbo_ComputationBasis.Text.Replace("'", "''") & "'"

            strSQL += vbCrLf & ",[ChargeType]"
            strSQL += vbCrLf & " = '" & cbo_ChargeType.Text.Replace("'", "''") & "'"

            strSQL += vbCrLf & ",[InterestPeriod]"
            strSQL += vbCrLf & " = '" & cbo_InterestPeriod.Text.Replace("'", "''") & "'"

            strSQL += vbCrLf & ",[BaseRate]"
            strSQL += vbCrLf & " = '" & cbo_BaseRate.Text.Replace("'", "''") & "'"

            strSQL += ",[ImmediatePosting]"
            If rad_ImmediatePosting_y.Checked Then
                strSQL += vbCrLf & " = 'YES'"
            Else
                strSQL += vbCrLf & " = 'NO'"
            End If

            strSQL += ",[ImmediateCompn]"
            If rad_ImmediateCompn_y.Checked Then
                strSQL += vbCrLf & " = 'YES'"
            Else
                strSQL += vbCrLf & " = 'NO'"
            End If
            '===============charg amount ====================
            '==1=====
            Dim i As Integer
            For i = 1 To 11
                If grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text <> "" Then
                    strSQL += vbCrLf & ",[LowerLimit" & i.ToString & "]"
                    strSQL += vbCrLf & " = " & grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text.Replace(",", "") & ""
                    strSQL += vbCrLf & ",[UpperLimit" & i.ToString & "]"
                    strSQL += vbCrLf & " = " & grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Text.Replace(",", "") & ""
                    strSQL += vbCrLf & ",[FixedAmount" & i.ToString & "]"
                    strSQL += vbCrLf & " = " & grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Text.Replace(",", "") & ""
                    strSQL += vbCrLf & ",[BasisPoints" & i.ToString & "]"
                    strSQL += vbCrLf & " = " & grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Text.Replace(",", "") & ""
                End If 'If grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text <> "" And grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text <> "0" Then
            Next i


            strSQL += vbCrLf & " where ID='" & txt_GUID.Text & "'  and row_id=" & txt_row_id.Text & ""

            If conn.ExecuteNonQuery(strSQL) = "" Then
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function


    Private Sub SetControlGroup_Charge(ByVal intRow As Integer)

        Dim i As Integer
        For i = 2 To 11
            If i <= intRow Then

 

                grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Enabled = True
                grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Enabled = True
                grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Enabled = True
                If grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Text = "" Then
                    grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Text = "0"
                End If
                If grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Text = "" Then
                    grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Text = "0"
                End If
                If grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Text = "" Then
                    grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Text = "0"
                End If

            Else
                grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Enabled = False
                grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Enabled = False
                grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Enabled = False
                grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text = ""
                grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Text = ""
                grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Text = ""
                grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Text = ""
            End If

          
        Next
  

    End Sub



    Private Sub txt_UpperLimit_Charge(ByVal strIndex As Integer)
        If strIndex <> 11 And strIndex <> 0 Then
            If grp_chg.Controls.Item("txt_UpperLimit_" & (strIndex + 1).ToString).Enabled = True Then
                If grp_chg.Controls.Item("txt_UpperLimit_" & (strIndex).ToString).Text <> grp_chg.Controls.Item("txt_LowerLimit_" & (strIndex + 1).ToString).Text Then
                    grp_chg.Controls.Item("txt_LowerLimit_" & (strIndex + 1).ToString).Text = grp_chg.Controls.Item("txt_UpperLimit_" & (strIndex).ToString).Text
                End If
            End If

        End If

        If grp_chg.Controls.Item("txt_UpperLimit_" & (strIndex).ToString).Text = "" Then Exit Sub
        If IsNumeric(grp_chg.Controls.Item("txt_UpperLimit_" & (strIndex).ToString).Text) = False Then
            grp_chg.Controls.Item("txt_UpperLimit_" & (strIndex).ToString).Text = "0"
        End If

        If strIndex > 1 Then
            If grp_chg.Controls.Item("txt_UpperLimit_" & (strIndex).ToString).Text <> "0" Then
                If CDbl(grp_chg.Controls.Item("txt_UpperLimit_" & (strIndex).ToString).Text) <= CDbl(grp_chg.Controls.Item("txt_UpperLimit_" & (strIndex - 1).ToString).Text) Then
                    MessageBox.Show("invalid [Upper Limit]. Must be more than Upper Limit Low Level. or Equal Zero.")
                    grp_chg.Controls.Item("txt_UpperLimit_" & (strIndex).ToString).Text = "0"
                End If
            End If
        End If

    End Sub


    Private Sub txt_UpperLimit_1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UpperLimit_1.Validated
        Call txt_UpperLimit_Charge(1)
    End Sub
    Private Sub txt_UpperLimit_2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UpperLimit_2.Validated
        Call txt_UpperLimit_Charge(2)
    End Sub
    Private Sub txt_UpperLimit_3_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UpperLimit_3.Validated
        Call txt_UpperLimit_Charge(3)
    End Sub
    Private Sub txt_UpperLimit_4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UpperLimit_4.Validated
        Call txt_UpperLimit_Charge(4)
    End Sub
    Private Sub txt_UpperLimit_5_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UpperLimit_5.Validated
        Call txt_UpperLimit_Charge(5)
    End Sub
    Private Sub txt_UpperLimit_6_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UpperLimit_6.Validated
        Call txt_UpperLimit_Charge(6)
    End Sub
    Private Sub txt_UpperLimit_7_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UpperLimit_7.Validated
        Call txt_UpperLimit_Charge(7)
    End Sub
    Private Sub txt_UpperLimit_8_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UpperLimit_8.Validated
        Call txt_UpperLimit_Charge(8)
    End Sub
    Private Sub txt_UpperLimit_9_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UpperLimit_9.Validated
        Call txt_UpperLimit_Charge(9)
    End Sub
    Private Sub txt_UpperLimit_10_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UpperLimit_10.Validated
        Call txt_UpperLimit_Charge(10)
    End Sub
    Private Sub txt_UpperLimit_11_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UpperLimit_11.Validated
        Call txt_UpperLimit_Charge(11)
    End Sub

    Private Sub btn_DeleteRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DeleteRow.Click
        If cbo_ChargeType.Text.ToUpper = "Single Rate".ToUpper Then
            Exit Sub
        End If

        If intRow <= 1 Then intRow = 1 : Exit Sub

        grp_chg.Controls.Item("txt_LowerLimit_" & intRow.ToString).Text = ""
        grp_chg.Controls.Item("txt_UpperLimit_" & intRow.ToString).Text = ""
        grp_chg.Controls.Item("txt_FixedAmount_" & intRow.ToString).Text = ""
        grp_chg.Controls.Item("txt_BasisPoints_" & intRow.ToString).Text = ""

        intRow = intRow - 1
        Call SetControlGroup_Charge(intRow)
    End Sub


  
    Private Sub btnAddRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRow.Click
        If cbo_ChargeType.Text.ToUpper = "Single Rate".ToUpper Then
            Exit Sub
        End If

        intRow = intRow + 1
        If intRow > 11 Then intRow = 11
        If grp_chg.Controls.Item("txt_LowerLimit_" & intRow.ToString).Text = "" Then
            grp_chg.Controls.Item("txt_LowerLimit_" & intRow.ToString).Text = grp_chg.Controls.Item("txt_UpperLimit_" & (intRow - 1).ToString).Text
        End If

        Call SetControlGroup_Charge(intRow)
    End Sub

  
    Private Sub rad_ApplyMinchg_y_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_ApplyMinchg_y.CheckedChanged
        If rad_ApplyMinchg_y.Checked = True Then
            cbo_ApplyMinChgAmount.Enabled = True
        Else
            cbo_ApplyMinChgAmount.Enabled = False
            cbo_ApplyMinChgAmount.Text = ""
        End If
    End Sub

    Private Sub rad_ApplyMaxChg_y_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_ApplyMaxChg_y.CheckedChanged
        If rad_ApplyMaxChg_y.Checked = True Then
            cbo_ApplyMaxChgAmount.Enabled = True
        Else
            cbo_ApplyMaxChgAmount.Enabled = False
            cbo_ApplyMaxChgAmount.Text = ""
        End If
    End Sub

  
    Private Sub rad_ApplyMinchg_n_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_ApplyMinchg_n.CheckedChanged
        If rad_ApplyMinchg_y.Checked = True Then
            cbo_ApplyMinChgAmount.Enabled = True
        Else
            cbo_ApplyMinChgAmount.Enabled = False
            cbo_ApplyMinChgAmount.Text = "0"
        End If
    End Sub

    Private Sub rad_ApplyMaxChg_n_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_ApplyMaxChg_n.CheckedChanged
        If rad_ApplyMaxChg_y.Checked = True Then
            cbo_ApplyMaxChgAmount.Enabled = True
        Else
            cbo_ApplyMaxChgAmount.Enabled = False
            cbo_ApplyMaxChgAmount.Text = "0"
        End If
    End Sub


    Private Sub cbo_ChargeType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_ChargeType.Validated
        Call RefreshChargeType()
    End Sub


    Private Sub RefreshChargeType()
        If cbo_ChargeType.Text.ToUpper = "Single Rate".ToUpper Then
            txt_UpperLimit_1.Text = "0"
            txt_UpperLimit_1.Enabled = False
            intRow = 1
            Call SetControlGroup_Charge(intRow)
            btnAddRow.Enabled = False
            btn_DeleteRow.Enabled = False
        Else
            btnAddRow.Enabled = True
            btn_DeleteRow.Enabled = True
            txt_UpperLimit_1.Enabled = True
        End If
    End Sub
  

    Private Sub cbo_ComputationBasis_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_ComputationBasis.Validated
        If cbo_ComputationBasis.Text <> "" Then
            If cbo_ComputationBasis.Text.ToUpper = "Count-Based".ToUpper Then

            Else

            End If
        End If
    End Sub

    Private Sub SetCaptionComputationBasis()
        If cbo_ComputationBasis.Text <> "" Then
            If cbo_ComputationBasis.Text.ToUpper = "Count-Based".ToUpper Then
                lbComputeBasis.Text = "PerUnit Charge"
            Else
                lbComputeBasis.Text = "Basis Point"
            End If
        End If
    End Sub

    Private Sub cbo_ComputationBasis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_ComputationBasis.SelectedIndexChanged
        Call SetComputationBasis()
    End Sub

    Private Sub SetComputationBasis()
        If cbo_ComputationBasis.Text.ToUpper = "Count-Based".ToUpper Then
            lbComputeBasis.Text = "PerUnit Charge"
        Else
            lbComputeBasis.Text = "Basis Point"
        End If
    End Sub
End Class