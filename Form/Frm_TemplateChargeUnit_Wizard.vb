Imports Template_Application.CSQL
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class Frm_TemplateChargeUnit_Wizard

    Dim conn As CSQL
    Dim res As SqlDataReader
    Dim sql_cmd As String, add_cmd As String

    Private Const strALL = "--------Please Select--------"
    Private Const strBlankForm = "--------Blank Form--------"

    Private Const strSingleProduct = "Single-Product"
    Private Const strProductCharge = "Product Charge"

    Public strProduct As String = ""
    Public strGUID As String = ""

    Public bNewFlag As Boolean = False
    Public txt_return As TextBox



    Private Sub Frm_TemplateChargeUnit_Wizard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New CSQL

        strGUID = conn.GetDataFromSQL("select newid()")
        strGUID = strGUID.ToUpper
        txt_GUID.Text = strGUID



        Dim strSQL As String
        'strSQL = "SELECT DISTINCT [Product] FROM [PRD_TemplateChargeEvents] ORDER BY [Product]"
        strSQL = conn.GetSQL_LIST_PRODUCT_MST
        conn.Fill_ComboBox(strSQL, cbo_product, strALL)
        If cbo_product.Items.Count > 0 Then cbo_product.SelectedIndex = 0

        cbo_product.Text = strProduct
        txt_Product.Text = cbo_product.Text.Substring(0, 3)
        Call SetScreenByProduct()

    End Sub


    Public Sub SetScreenByProduct()
        Dim strSQL As String = ""
        chk_ValueBased.Visible = False
        If cbo_product.Text = "" Then Exit Sub

        If cbo_product.Text.Substring(0, 3) = "DCT" Then
            chk_ValueBased.Visible = True
            chk_ValueBased.Checked = False
        End If

        grp_bne.Visible = False
        grp_Tab_slab.Visible = False
        grp_Tab_two.Visible = False
        grp_tab_one.Visible = False
        '  btn_Find.Enabled = False
        pnl_defer.Enabled = False
        ' btn_more_criteria.Enabled = False

        grp_Tab_slab.Location = grp_bne.Location
        grp_Tab_two.Location = grp_bne.Location
        grp_tab_one.Location = grp_bne.Location

        lb_cbo_diff_2.Visible = False
        cbo_diff_2.Visible = False
        cbo_diff_2.Text = "0"



        If cbo_product.Text = "" Or cbo_product.Text = strALL Then Exit Sub

        If cbo_product.Text.Substring(0, 3) = "FTR" Or cbo_product.Text.Substring(0, 3) = "FTL" Then
            lb_cbo_diff_2.Visible = True
            cbo_diff_2.Visible = True
        End If

        pnl_defer.Enabled = True
        ' btn_more_criteria.Enabled = True
        'btn_Find.Enabled = True

        If cbo_product.Text.Substring(0, 3) = "PCL" Then
            rad_defer_y.Checked = True
            Call Set_txt_PostingDay_crit()
        End If

        Select Case cbo_product.Text.Substring(0, 3)
            Case "BNE"
                grp_bne.Visible = True
                grp_Tab_slab.Visible = False
                grp_Tab_two.Visible = False
                grp_tab_one.Visible = False

            Case "DCT", "FTR", "FTL", "PCT"
                grp_bne.Visible = False
                grp_Tab_slab.Visible = False
                grp_Tab_two.Visible = True
                grp_tab_one.Visible = False


                If cbo_product.Text.Substring(0, 3) = "FTR" Then
                    cbo_same.Text = "0" : cbo_same.Enabled = False
                    txt_ApplyMinchgAmount_same.Text = "0" : txt_ApplyMinchgAmount_same.Enabled = False
                    txt_ApplyMaxchgAmount_same.Text = "0" : txt_ApplyMaxchgAmount_same.Enabled = False
                Else
                    cbo_same.Enabled = True
                    txt_ApplyMinchgAmount_same.Enabled = True
                    txt_ApplyMaxchgAmount_same.Enabled = True
                End If

                '================same------------
                strSQL = "select BasisPoints1 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_product.Text.Substring(0, 3) & "SMZONE'"
                cbo_same.Text = conn.GetDataFromSQL(strSQL, 0)
                If cbo_same.Text = "" Then cbo_same.Text = "0"

                strSQL = "select ApplyMinchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_product.Text.Substring(0, 3) & "SMZONE'"
                txt_ApplyMinchgAmount_same.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMinchgAmount_same.Text = "" Then txt_ApplyMinchgAmount_same.Text = "0"

                strSQL = "select ApplyMaxchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_product.Text.Substring(0, 3) & "SMZONE'"
                txt_ApplyMaxchgAmount_same.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMaxchgAmount_same.Text = "" Then txt_ApplyMaxchgAmount_same.Text = "0"

                '================diff------------
                'strSQL = "select BasisPoints1 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_product.Text.Substring(0, 3) & "DFZONE'"
                'cbo_diff.Text = conn.GetDataFromSQL(strSQL, 0)
                'If cbo_diff.Text = "" Then cbo_diff.Text = "0"

                If cbo_product.Text.Substring(0, 3) = "FTR" Or cbo_product.Text.Substring(0, 3) = "FTL" Then
                    'ftr,ftl
                    strSQL = "select FixedAmount1 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_product.Text.Substring(0, 3) & "DFZONE'"
                    cbo_diff.Text = conn.GetDataFromSQL(strSQL, 0)
                    If cbo_diff.Text = "" Then cbo_diff.Text = "0"

                    strSQL = "select isnull(BasisPoints1,0) * 10.00 as BasisPoints1 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_product.Text.Substring(0, 3) & "DFZONE'"
                    cbo_diff_2.Text = conn.GetDataFromSQL(strSQL, 0)
                    If cbo_diff_2.Text = "" Then cbo_diff_2.Text = "0"
                Else
                    'pcl
                    strSQL = "select BasisPoints1 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_product.Text.Substring(0, 3) & "DFZONE'"
                    cbo_diff.Text = conn.GetDataFromSQL(strSQL, 0)
                    If cbo_diff.Text = "" Then cbo_diff.Text = "0"
                    cbo_diff_2.Text = "0"

                End If


                strSQL = "select ApplyMinchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_product.Text.Substring(0, 3) & "DFZONE'"
                txt_ApplyMinchgAmount_diff.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMinchgAmount_diff.Text = "" Then txt_ApplyMinchgAmount_diff.Text = "0"

                strSQL = "select ApplyMaxchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_product.Text.Substring(0, 3) & "DFZONE'"
                txt_ApplyMaxchgAmount_diff.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMaxchgAmount_diff.Text = "" Then txt_ApplyMaxchgAmount_diff.Text = "0"


            Case "MCL", "MCS", "PCL"
                grp_bne.Visible = False
                grp_Tab_slab.Visible = True
                grp_Tab_two.Visible = False
                grp_tab_one.Visible = False

                strSQL = "select FixedAmount1,FixedAmount2,FixedAmount3 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001'  "

                cbo_tier1.Text = conn.GetDataFromSQL(strSQL, 0)
                If cbo_tier1.Text = "" Then cbo_tier1.Text = "0"

                cbo_tier2.Text = conn.GetDataFromSQL(strSQL, 1)
                If cbo_tier2.Text = "" Then cbo_tier2.Text = "0"

                cbo_tier3.Text = conn.GetDataFromSQL(strSQL, 2)
                If cbo_tier3.Text = "" Then cbo_tier3.Text = "0"


                strSQL = "select ApplyMinchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_product.Text.Substring(0, 3) & "DFZONE'"
                txt_ApplyMinchgAmount_t1.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMinchgAmount_t1.Text = "" Then txt_ApplyMinchgAmount_t1.Text = "0"

                strSQL = "select ApplyMaxchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_product.Text.Substring(0, 3) & "DFZONE'"
                txt_ApplyMaxchgAmount_t1.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMaxchgAmount_t1.Text = "" Then txt_ApplyMaxchgAmount_t1.Text = "0"




            Case "COC", "COE"
                grp_bne.Visible = False
                grp_Tab_slab.Visible = False
                grp_Tab_two.Visible = False
                grp_tab_one.Visible = True

                strSQL = "select BasisPoints1 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001'  "
                cbo_ChargeAmount.Text = conn.GetDataFromSQL(strSQL, 0)
                If cbo_ChargeAmount.Text = "" Then cbo_ChargeAmount.Text = "0"

                strSQL = "select ApplyMinchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product like '" & cbo_product.Text.Substring(0, 3) & "%'"
                txt_ApplyMinchgAmount_one.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMinchgAmount_one.Text = "" Then txt_ApplyMinchgAmount_one.Text = "0"

                strSQL = "select ApplyMaxchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_product.Text.Substring(0, 3) & "CG00001' and   product like '" & cbo_product.Text.Substring(0, 3) & "%'"
                txt_ApplyMaxchgAmount_one.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMaxchgAmount_one.Text = "" Then txt_ApplyMaxchgAmount_one.Text = "0"


            Case Else
        End Select

    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click
        If txt_Deal_ID.Text = "" Then
            MsgBox("Invalid [Deal ID]")
            Exit Sub
        End If

        Call SaveData()
    End Sub

    Private Function GetErrorNumberic(ByVal strData As String, Optional ByVal MaindatoryFlag As Boolean = True) As Boolean
        Dim strError As Boolean = False

        If strData <> "" Then
            If IsNumeric(strData) = False Then
                strError = True
            End If
        Else
            If MaindatoryFlag = True Then
                strError = True
            End If
        End If

        Return strError

    End Function

    Private Sub SaveData()
        Try
            Dim strError As String = ""

            If rad_defer_y.Checked = True Then

                If GetErrorNumberic(txt_PostingDay_Monthly.Text) = True Then
                    strError += IIf(strError = "", "", vbCrLf) & "Invalid [Monthly Charge]"
                Else
                    If CDbl(txt_PostingDay_Monthly.Text) < 0 Or CDbl(txt_PostingDay_Monthly.Text) > 31 Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Monthly Charge]"
                    End If
                End If

            End If


            '=============validation===============
            Select Case cbo_product.Text.Substring(0, 3)
                Case "BNE"

                    '========Bangkok To Bangkok==========

                    If GetErrorNumberic(cbo_bne1.Text) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Bangkok To Bangkok]"
                    End If

                    '=========Bangkok To Upcountry==========
                    If GetErrorNumberic(cbo_bne2.Text) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Bangkok To Upcountry]"
                    End If


                    '=============Upcountry To Bangkok=============
                    If GetErrorNumberic(cbo_bne3.Text) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Upcountry To Bangkok]"
                    End If

                    If GetErrorNumberic(cbo_bne3_2.Text) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Per 10,000]"
                    End If

                    '=============Upcountry To Upcountry=============
                    If GetErrorNumberic(cbo_bne4.Text) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Upcountry To Upcountry]"
                    End If

                    '=================================
                    If GetErrorNumberic(txt_ApplyMinchgAmount_bne1.Text, True) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMinchgAmount-1 (Bangkok To Bangkok) ]"
                    End If
                    If GetErrorNumberic(txt_ApplyMinchgAmount_bne2.Text, True) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMinchgAmount-2 (Bangkok To Upcountry) ]"
                    End If
                    If GetErrorNumberic(txt_ApplyMinchgAmount_bne3.Text, True) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMinchgAmount-3 (Upcountry To Bangkok) ]"
                    End If
                    If GetErrorNumberic(txt_ApplyMinchgAmount_bne4.Text, True) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMinchgAmount-4 (Upcountry To Upcountr) ]"
                    End If
                    '=================================
                    If GetErrorNumberic(txt_ApplyMaxChgAmount_bne1.Text, True) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMaxchgAmount-1 (Bangkok To Bangkok) ]"
                    End If
                    If GetErrorNumberic(txt_ApplyMaxChgAmount_bne2.Text, True) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMaxchgAmount-2 (Bangkok To Upcountry) ]"
                    End If
                    If GetErrorNumberic(txt_ApplyMaxChgAmount_bne3.Text, True) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMaxchgAmount-3 (Upcountry To Bangkok) ]"
                    End If
                    If GetErrorNumberic(txt_ApplyMaxChgAmount_bne4.Text, True) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMaxchgAmount-4 (Upcountry To Upcountr) ]"
                    End If
                    '=================================
                    If CDbl(cbo_bne1.Text) = 0 And CDbl(cbo_bne2.Text) = 0 And CDbl(cbo_bne3.Text) = 0 And CDbl(cbo_bne4.Text) = 0 Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Zero charge is not require in GCP.]"
                    End If

                Case "DCT", "FTR", "FTL", "PCT"

                    If cbo_same.Text <> "" Then
                        If IsNumeric(cbo_same.Text) = False Then
                            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Same Zone]"
                        End If
                    Else
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Same Zone]"
                    End If

                    If cbo_diff.Text <> "" Then
                        If IsNumeric(cbo_diff.Text) = False Then
                            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Diff Zone]"
                        End If
                    Else
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Diff Zone]"
                    End If

                    If cbo_diff_2.Text <> "" Then
                        If IsNumeric(cbo_diff_2.Text) = False Then
                            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Diff Zone(Per 10,000 *)]"
                        End If
                    Else
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Diff Zone-(Per 10,000 *)]"
                    End If

                    If IsNumeric(cbo_same.Text) = True And IsNumeric(cbo_diff.Text) = True And IsNumeric(cbo_diff_2.Text) = True Then
                        If CDbl(cbo_same.Text) = 0 And Not (CDbl(cbo_diff.Text) > 0 Or CDbl(cbo_diff_2.Text) > 0) Then
                            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Zero charge is not require in GCP.]"
                        End If
                    End If


                    If GetErrorNumberic(txt_ApplyMinchgAmount_same.Text, False) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Min Amount (Same Zone) ]"
                    End If

                    If GetErrorNumberic(txt_ApplyMinchgAmount_diff.Text, False) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Min Amount (Diff Zone) ]"
                    End If

                    If GetErrorNumberic(txt_ApplyMaxchgAmount_same.Text, False) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Max Amount (Same Zone) ]"
                    End If

                    If GetErrorNumberic(txt_ApplyMaxchgAmount_diff.Text, False) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Max Amount (Diff Zone) ]"
                    End If


                Case "MCL", "MCS", "PCL"
                    'cbo_tier1
                    If cbo_tier1.Text <> "" Then
                        If IsNumeric(cbo_tier1.Text) = False Then
                            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Tier 1]"


                        Else
                            If CDbl(cbo_tier1.Text) = 0 Then
                                strError += IIf(strError = "", "", vbCrLf) & "Invalid tier1 [Zero charge is not require in GCP.]"
                            End If

                        End If
                    Else
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Tier 1]"
                    End If



                    If cbo_tier2.Text <> "" Then
                        If IsNumeric(cbo_tier2.Text) = False Then
                            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Tier 2]"
                        Else
                            If CDbl(cbo_tier2.Text) = 0 Then
                                strError += IIf(strError = "", "", vbCrLf) & "Invalid tier2 [Zero charge is not require in GCP.]"
                            End If

                        End If
                    Else
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Tier 2]"
                    End If

                    If cbo_tier3.Text <> "" Then
                        If IsNumeric(cbo_tier3.Text) = False Then
                            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Tier 3]"
                        Else
                            If CDbl(cbo_tier3.Text) = 0 Then
                                strError += IIf(strError = "", "", vbCrLf) & "Invalid tier3 [Zero charge is not require in GCP.]"
                            End If
                        End If
                    Else
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Tier 3]"
                    End If


                    If GetErrorNumberic(txt_ApplyMinchgAmount_t1.Text, True) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Min Amount (Tier 1) ]"
                    End If
                    'If GetErrorNumberic(txt_ApplyMinchgAmount_t2.Text, True) = True Then
                    '    strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Min Amount (Tier 2) ]"
                    'End If
                    'If GetErrorNumberic(txt_ApplyMinchgAmount_t3.Text, True) = True Then
                    '    strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Min Amount (Tier 3) ]"
                    'End If

                    If GetErrorNumberic(txt_ApplyMaxchgAmount_t1.Text, True) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Max Amount (Tier 1) ]"
                    End If
                    'If GetErrorNumberic(txt_ApplyMaxchgAmount_t2.Text, True) = True Then
                    '    strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Max Amount (Tier 2) ]"
                    'End If
                    'If GetErrorNumberic(txt_ApplyMaxchgAmount_t3.Text, True) = True Then
                    '    strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Max Amount (Tier 3) ]"
                    'End If


                Case "COC", "COE"
                    'Frm_TemplateChargeUnit_list
                    If cbo_ChargeAmount.Text <> "" Then
                        If IsNumeric(cbo_ChargeAmount.Text) = False Then
                            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Charge Amount]"
                        End If
                    Else
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Charge Amount]"
                    End If

                    If CDbl(cbo_ChargeAmount.Text) = 0 Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Zero charge is not require in GCP.]"
                    End If

                    If GetErrorNumberic(txt_ApplyMinchgAmount_one.Text, True) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Min Amount]"
                    End If

                    If GetErrorNumberic(txt_ApplyMaxchgAmount_one.Text, True) = True Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Max Amount]"
                    End If

                Case Else
            End Select

            If strError <> "" Then
                MsgBox(strError)
                Exit Sub
            End If

            Dim strSQL As String = ""
            If txt_CopyFromTemplate.Text <> "" Then
                strSQL = "exec  [dbo].[sp_TemplateCharge_Insert_Inquiry]  '" & txt_GUID.Text & "','" & txt_CopyFromTemplate.Text & "' "
                conn.ExecuteNonQuery(strSQL)
            End If

            'events
            strSQL = ""
            If rad_defer_y.Checked = True Then

                strSQL = ""
                strSQL += vbCrLf & " update   dbo.Inquiry_TemplateChargeEvents set "
                strSQL += vbCrLf & " PostingFrequency = 'DEFERRED'  "
                strSQL += vbCrLf & " , PostingPeriodType = 'MONTHLY'"
                strSQL += vbCrLf & " , PostingPeriod=1 "
                strSQL += vbCrLf & " , PostingDay=  " & txt_PostingDay_Monthly.Text.Replace(",", "")
                strSQL += vbCrLf & " where ID='" & txt_GUID.Text & "' "
                conn.ExecuteNonQuery(strSQL)

            Else

                strSQL = ""
                strSQL += vbCrLf & " update   dbo.Inquiry_TemplateChargeEvents set "
                strSQL += vbCrLf & " PostingFrequency = 'IMMEDIATE'  "
                strSQL += vbCrLf & " , PostingPeriodType = 'DAILY'"
                strSQL += vbCrLf & " , PostingPeriod=0 "
                strSQL += vbCrLf & " , PostingDay=0  "
                strSQL += vbCrLf & " where ID='" & txt_GUID.Text & "' "
                conn.ExecuteNonQuery(strSQL)

            End If

             Select cbo_product.Text.Substring(0, 3)
                Case "BNE"
                    ' ==========='BNEBKKBKK=============
                    strSQL = ""
                    strSQL += vbCrLf & " update   dbo.Inquiry_TemplateChargeUnits set "
                    strSQL += vbCrLf & " BasisPoints1=" & CDbl(cbo_bne1.Text.Replace(",", ""))
                    If CDbl(txt_ApplyMinchgAmount_bne1.Text) > 0 Then
                        strSQL += vbCrLf & " , ApplyMinchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMinchgAmount  = " & CDbl(txt_ApplyMinchgAmount_bne1.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & ", ApplyMinchg ='NO' ,ApplyMinchgAmount=0 "
                    End If
                    If CDbl(txt_ApplyMaxChgAmount_bne1.Text) > 0 Then
                        strSQL += vbCrLf & " , ApplyMaxchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMaxchgAmount  = " & CDbl(txt_ApplyMaxChgAmount_bne1.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMaxchg ='NO' ,ApplyMaxchgAmount=0 "
                    End If

                    strSQL += vbCrLf & " where ID='" & txt_GUID.Text & "' and  Product= 'BNEBKKBKK' "
                    conn.ExecuteNonQuery(strSQL)
                    ' ==========='BNEBKKUPC=============
                    strSQL = ""
                    strSQL += vbCrLf & " update   dbo.Inquiry_TemplateChargeUnits set "
                    strSQL += vbCrLf & " BasisPoints1=" & CDbl(cbo_bne2.Text.Replace(",", ""))
                    If CDbl(txt_ApplyMinchgAmount_bne2.Text) > 0 Then
                        strSQL += vbCrLf & " , ApplyMinchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMinchgAmount  = " & CDbl(txt_ApplyMinchgAmount_bne2.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & ", ApplyMinchg ='NO' ,ApplyMinchgAmount=0 "
                    End If
                    If CDbl(txt_ApplyMaxChgAmount_bne2.Text) > 0 Then
                        strSQL += vbCrLf & " , ApplyMaxchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMaxchgAmount  = " & CDbl(txt_ApplyMaxChgAmount_bne2.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMaxchg ='NO' ,ApplyMaxchgAmount=0 "
                    End If

                    strSQL += vbCrLf & " where ID='" & txt_GUID.Text & "' and  Product= 'BNEBKKUPC' "
                    conn.ExecuteNonQuery(strSQL)

                    ' ==========='BNEUPCBKK=============
                    strSQL = ""
                    strSQL += vbCrLf & " update   dbo.Inquiry_TemplateChargeUnits set "
                    ' strSQL += vbCrLf & " FixedAmount1=" & CDbl(cbo_bne3.Text.Replace(",", ""))
                    strSQL += vbCrLf & " BasisPoints1= ( " & cbo_bne3_2.Text.Replace(",", "") & " / 10.00   )  "
                    If CDbl(txt_ApplyMinchgAmount_bne2.Text) > 0 Then
                        strSQL += vbCrLf & " ,ApplyMinchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMinchgAmount  = " & CDbl(txt_ApplyMinchgAmount_bne3.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMinchg ='NO' ,ApplyMinchgAmount=0 "
                    End If
                    If CDbl(txt_ApplyMaxChgAmount_bne3.Text) > 0 Then
                        strSQL += vbCrLf & " , ApplyMaxchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMaxchgAmount  = " & CDbl(txt_ApplyMaxChgAmount_bne3.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & ", ApplyMaxchg ='NO' ,ApplyMaxchgAmount=0 "
                    End If

                    strSQL += vbCrLf & " where ID='" & txt_GUID.Text & "' and  Product= 'BNEUPCBKK'  and  upper(ComputationBasis) = upper('Value-Based')  "


                    conn.ExecuteNonQuery(strSQL)



                    strSQL = ""
                    strSQL += vbCrLf & " update   dbo.Inquiry_TemplateChargeUnits set "
                    strSQL += vbCrLf & " BasisPoints1=" & CDbl(cbo_bne3.Text.Replace(",", ""))
                    ' strSQL += vbCrLf & " BasisPoints1= ( " & cbo_bne3_2.Text.Replace(",", "") & " / 10.00   )  "
                    If CDbl(txt_ApplyMinchgAmount_bne4.Text) > 0 Then
                        strSQL += vbCrLf & " ,ApplyMinchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMinchgAmount  = " & CDbl(txt_ApplyMinchgAmount_bne4.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMinchg ='NO' ,ApplyMinchgAmount=0 "
                    End If
                    If CDbl(txt_ApplyMaxChgAmount_bne4.Text) > 0 Then
                        strSQL += vbCrLf & " , ApplyMaxchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMaxchgAmount  = " & CDbl(txt_ApplyMaxChgAmount_bne4.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & ", ApplyMaxchg ='NO' ,ApplyMaxchgAmount=0 "
                    End If

                    strSQL += vbCrLf & " where ID='" & txt_GUID.Text & "' and  Product= 'BNEUPCBKK'  and  upper(ComputationBasis) = upper('Count-Based')  "


                    conn.ExecuteNonQuery(strSQL)


                    ' ==========='BNEUPCUPC=============
                    strSQL = ""
                    strSQL += vbCrLf & " update   dbo.Inquiry_TemplateChargeUnits set "
                    strSQL += vbCrLf & " BasisPoints1=" & CDbl(cbo_bne4.Text.Replace(",", ""))
                    If CDbl(txt_ApplyMinchgAmount_bne4.Text) > 0 Then
                        strSQL += vbCrLf & " ,ApplyMinchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMinchgAmount  = " & CDbl(txt_ApplyMinchgAmount_bne4.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMinchg ='NO' ,ApplyMinchgAmount=0 "
                    End If
                    If CDbl(txt_ApplyMaxChgAmount_bne4.Text) > 0 Then
                        strSQL += vbCrLf & " , ApplyMaxchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMaxchgAmount  = " & CDbl(txt_ApplyMaxChgAmount_bne4.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMaxchg ='NO' ,ApplyMaxchgAmount=0 "
                    End If

                    strSQL += vbCrLf & " where ID='" & txt_GUID.Text & "' and  Product= 'BNEUPCUPC' "
                    conn.ExecuteNonQuery(strSQL)

                Case "DCT", "FTR", "FTL", "PCT"
                    'DIFF ZONE
                    strSQL = ""
                    strSQL += vbCrLf & " update   dbo.Inquiry_TemplateChargeUnits set "

                    If cbo_product.Text.Substring(0, 3) = "PCT" Or cbo_product.Text.Substring(0, 3) = "DCT" Then

                        If cbo_product.Text.Substring(0, 3) = "DCT" And chk_ValueBased.Checked = True Then
                            strSQL += vbCrLf & " ComputationBasis='Value-Based' "
                            strSQL += vbCrLf & ", Rounding='Lowest'"
                            strSQL += vbCrLf & ", RoundingAmount=1 "
                            strSQL += vbCrLf & " , BasisPoints1= ( " & CDbl(cbo_diff_2.Text.Replace(",", "")) / 10.0 & "  )  "
                            strSQL += vbCrLf & " , FixedAmount1= ( " & CDbl(cbo_diff.Text.Replace(",", "")) & "  )  "
                        Else
                            strSQL += vbCrLf & " BasisPoints1= ( " & cbo_diff.Text.Replace(",", "") & "  )  "

                        End If
                      
                    Else
                        strSQL += vbCrLf & " BasisPoints1= ( " & CDbl(cbo_diff_2.Text.Replace(",", "")) / 10.0 & "  )  "
                        strSQL += vbCrLf & " , FixedAmount1= ( " & CDbl(cbo_diff.Text.Replace(",", "")) & "  )  "

                    End If
                  
                    If CDbl(txt_ApplyMinchgAmount_diff.Text) > 0 Then
                        strSQL += vbCrLf & " ,ApplyMinchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMinchgAmount  = " & CDbl(txt_ApplyMinchgAmount_diff.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMinchg ='NO' ,ApplyMinchgAmount=0 "
                    End If
                    If CDbl(txt_ApplyMaxchgAmount_diff.Text) > 0 Then
                        strSQL += vbCrLf & " ,ApplyMaxchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMaxchgAmount  = " & CDbl(txt_ApplyMaxchgAmount_diff.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMaxchg ='NO' ,ApplyMaxchgAmount=0 "
                    End If
                    strSQL += vbCrLf & " where ID='" & txt_GUID.Text & "' and  Product= '" & txt_Product.Text & "DFZONE' "
                    conn.ExecuteNonQuery(strSQL)

                    'SAME ZONE
                    strSQL = ""
                    strSQL += vbCrLf & " update   dbo.Inquiry_TemplateChargeUnits set "
                    strSQL += vbCrLf & " BasisPoints1= ( " & cbo_same.Text.Replace(",", "") & "  )  "
                    If CDbl(txt_ApplyMinchgAmount_same.Text) > 0 Then
                        strSQL += vbCrLf & " ,ApplyMinchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMinchgAmount  = " & CDbl(txt_ApplyMinchgAmount_same.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMinchg ='NO' ,ApplyMinchgAmount=0 "
                    End If
                    If CDbl(txt_ApplyMaxchgAmount_same.Text) > 0 Then
                        strSQL += vbCrLf & " ,ApplyMaxchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMaxchgAmount  = " & CDbl(txt_ApplyMaxchgAmount_same.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMaxchg ='NO' ,ApplyMaxchgAmount=0 "
                    End If
                    strSQL += vbCrLf & " where ID='" & txt_GUID.Text & "' and  Product= '" & txt_Product.Text & "SMZONE' "
                    conn.ExecuteNonQuery(strSQL)


                Case "MCL", "MCS", "PCL"
                    'TIER-1

                    strSQL = ""
                    strSQL += vbCrLf & " update   dbo.Inquiry_TemplateChargeUnits set "
                    'TIER-1
                    strSQL += vbCrLf & " FixedAmount1= ( " & cbo_tier1.Text.Replace(",", "") & "  )  "

                    'TIER-2
                    strSQL += vbCrLf & " ,FixedAmount2= ( " & cbo_tier2.Text.Replace(",", "") & "  )  "

                    'TIER-3
                    strSQL += vbCrLf & " ,FixedAmount3= ( " & cbo_tier3.Text.Replace(",", "") & "  )  "

                    If CDbl(txt_ApplyMinchgAmount_t1.Text) > 0 Then
                        strSQL += vbCrLf & " ,ApplyMinchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMinchgAmount  = " & CDbl(txt_ApplyMinchgAmount_t1.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMinchg ='NO' ,ApplyMinchgAmount=0 "
                    End If
                    If CDbl(txt_ApplyMaxchgAmount_t1.Text) > 0 Then
                        strSQL += vbCrLf & " ,ApplyMaxchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMaxchgAmount  = " & CDbl(txt_ApplyMaxchgAmount_t1.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMaxchg ='NO' ,ApplyMaxchgAmount=0 "
                    End If
                    strSQL += vbCrLf & " where ID='" & txt_GUID.Text & "' and  Product like '" & txt_Product.Text & "%' "
                    conn.ExecuteNonQuery(strSQL)


                Case "COC", "COE"
                    'CHARGE AMOUNT
                    strSQL = ""
                    strSQL += vbCrLf & " update   dbo.Inquiry_TemplateChargeUnits set "
                    strSQL += vbCrLf & " BasisPoints1= ( " & cbo_ChargeAmount.Text.Replace(",", "") & "  )  "
                    If CDbl(txt_ApplyMinchgAmount_one.Text) > 0 Then
                        strSQL += vbCrLf & " ,ApplyMinchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMinchgAmount  = " & CDbl(txt_ApplyMinchgAmount_one.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMinchg ='NO' ,ApplyMinchgAmount=0 "
                    End If
                    If CDbl(txt_ApplyMaxchgAmount_one.Text) > 0 Then
                        strSQL += vbCrLf & " ,ApplyMaxchg ='YES'"
                        strSQL += vbCrLf & " ,ApplyMaxchgAmount  = " & CDbl(txt_ApplyMaxchgAmount_one.Text.Replace(",", ""))
                    Else
                        strSQL += vbCrLf & " ,ApplyMaxchg ='NO' ,ApplyMaxchgAmount=0 "
                    End If
                    strSQL += vbCrLf & " where ID='" & txt_GUID.Text & "' and  Product like '" & txt_Product.Text & "%' "
                    conn.ExecuteNonQuery(strSQL)

            End Select

            'compare template


            If txt_GUID.Text = "" Then Exit Sub

            'GetDataReader
            '  Dim strSQL As String = ""
            strSQL = "  exec dbo.sp_Inquiry_Template_code '" & txt_GUID.Text & "' "
            Dim rst As SqlDataReader

            rst = conn.GetDataReader(strSQL)
            If rst.HasRows Then
                rst.Read()
                Dim strTemplateCode As String = ""
                strTemplateCode = IIf(rst(0) Is System.DBNull.Value, "", rst(0).ToString())
                If strTemplateCode <> "" Then
                    MsgBox("Data enter is  same as template """ + strTemplateCode + """ ")
                    'Dim mFrmPrint_InputDescription As New FrmPrint_InputDescription
                    'mFrmPrint_InputDescription.txt_template_code.Text = txt_CopyFromTemplate.Text
                    'mFrmPrint_InputDescription.strReportName = "charge"
                    'mFrmPrint_InputDescription.ShowDialog()

                End If
            Else
                If MsgBox("Do you want to create new a template?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add New Template") = MsgBoxResult.No Then Exit Sub
                Call AutoLastNumber()
                strSQL = "exec [sp_TemplateCharge_Insert_Production] '" & txt_GUID.Text & "' , '" & txt_new_template.Text & "' "
                If conn.ExecuteNonQuery(strSQL) = "" Then

                    Me.Close()
                    Dim strValue As String = ""
                    Dim strFiledname As String = ""

                    strValue = ""
                    strFiledname = ""

                    strFiledname += vbCrLf & "[TemplateCode]"
                    strValue += vbCrLf & "'" & txt_new_template.Text.Replace("'", "''") & "'"
                    strFiledname += ",[TemplateType]"
                    strValue += vbCrLf & ",'" & strProductCharge & "'"
                    strFiledname += vbCrLf & ",[TemplateFullName]"
                    strValue += vbCrLf & ",'" & txt_Product.Text.Substring(0, 3) & " CHARGE TEMPLATE " & txt_new_template.Text.Substring(txt_new_template.Text.Length - 5) & "'"
                    strFiledname += vbCrLf & ",[TemplateEffectiveFrom]"
                    strValue += vbCrLf & ",''"
                    strFiledname += ",[ProductCode]"
                    strValue += vbCrLf & ",'" & txt_Product.Text.Substring(0, 3).Replace("'", "''") & "'"
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

                    conn.ExecuteNonQuery(strSQL)

                    'Dim mFrmReport_Muti As New FrmReport_Muti
                    'mFrmReport_Muti.strSQL_PRD_Template = "SELECT * FROM PRD_Template WHERE   TemplateCode = '" & txt_new_template.Text & "'   order by TemplateCode"

                    'mFrmReport_Muti.strSQL1 = "select * from dbo.PRD_TemplateChargeEvents where TemplateCode = '" & txt_new_template.Text & "'  order by [TemplateCode],[Product],[ProductCCY],[Event]"
                    'mFrmReport_Muti.strSQL2 = "select * from dbo.PRD_TemplateChargeUnits where TemplateCode = '" & txt_new_template.Text & "'   order by TemplateCode,Class,Product,Event,ChargeUnitCode "
                    'mFrmReport_Muti.ShowDialog()
                    If bNewFlag = False Then
                        Dim FrmReport2 As New FrmReport
                        FrmReport2.ReportType = "TemplateChageUnit"
                        FrmReport2.strSQL_PRD_Template = "SELECT * FROM PRD_Template WHERE   TemplateCode = '" & txt_new_template.Text & "'   order by TemplateCode"
                        FrmReport2.strSQL1 = "SELECT * FROM PRD_TemplateChargeEvents where TemplateCode = '" & txt_new_template.Text & "'   order by TemplateCode,Product"
                        FrmReport2.strSQL2 = "SELECT * FROM PRD_TemplateChargeUnits where TemplateCode = '" & txt_new_template.Text & "' order by  TemplateCode,Product,Event "
                        FrmReport2.strLine(0) = txt_Deal_ID.Text
                        FrmReport2.ShowDialog()
                    End If
                   

                    If bNewFlag = True Then
                        txt_return.Text = txt_new_template.Text.Replace("'", "''")
                        Me.Close()
                    End If


                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.ToString)
        End Try
    End Sub

    Private Sub AutoLastNumber()
        Try
            Dim strTemplateType As String = ""
            Dim strSQL As String = ""

            If txt_Product.Text.Length <> 3 Then Exit Sub


            strTemplateType += strProductCharge


            strSQL = "select max(TemplateCode) as TemplateCode from PRD_Template  "
            strSQL += " where ProductCode='" & txt_Product.Text.Replace("'", "''") & "' "
            strSQL += " and TemplateType='" & strTemplateType.Replace("'", "''") & "' "

            Dim strValue As String = conn.GetDataFromSQL(strSQL)
            Dim intMax As Double

            'product
            If strValue = "" Then
                txt_new_template.Text = txt_Product.Text & "CG00001"
            Else
                intMax = CDbl(strValue.Substring(strValue.Length - 5)) + 1
                txt_new_template.Text = txt_Product.Text & "CG" & intMax.ToString("00000")
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub rad_defer_y_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_defer_y.CheckedChanged
        Call Set_txt_PostingDay_crit()
    End Sub

    Private Sub Set_txt_PostingDay_crit()

        If rad_defer_y.Checked = True Then
            txt_PostingDay_Monthly.Text = "31"
            txt_PostingDay_Monthly.Enabled = True
        Else
            txt_PostingDay_Monthly.Enabled = False
            txt_PostingDay_Monthly.Text = "0"
        End If

    End Sub

    Private Sub rad_defer_n_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_defer_n.CheckedChanged
        Call Set_txt_PostingDay_crit()
    End Sub

  
    Private Sub chk_ValueBased_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_ValueBased.CheckedChanged
        lb_cbo_diff_2.Visible = chk_ValueBased.Checked
        cbo_diff_2.Visible = chk_ValueBased.Checked
    End Sub

End Class