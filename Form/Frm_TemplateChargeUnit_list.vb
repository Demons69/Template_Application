Imports Template_Application.CSQL
Imports System.Data
Imports System.Data.SqlClient

Public Class Frm_TemplateChargeUnit_list
    Dim conn As CSQL
    Dim res As SqlDataReader
    Dim sql_cmd As String, add_cmd As String
    Private Const strALL = "--------Please Select--------"

    Public IS_RETURN As Boolean = False
    Public OBJ_COMBOBOX As ComboBox
    Public strProduct_sendto As String = ""
    Public txt_charge_template_new As TextBox

    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub Frm_TP_CU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'abControl_chargeamt.Enabled = False
        pnl_defer.Enabled = False

        conn = New CSQL
        Me.KeyPreview = True
        Dim strSQL As String = ""
        ' strSQL = " select distinct Product from dbo.PRD_TemplateChargeEvents order by Product "
        strSQL = conn.GetSQL_LIST_PRODUCT_MST
        conn.Fill_ComboBox(strSQL, cbo_Product, strALL)
        If cbo_Product.Items.Count > 0 Then cbo_Product.SelectedIndex = 0

        Call SetCombo()
        cbo_product_event.Enabled = False
        cbo_product_unit.Enabled = False
        Call SetCaptionComputationBasis()

        '  Call UpGrid_Template()
        TabControl1.Visible = False


        grp_Tab_slab.Location = grp_bne.Location
        grp_Tab_two.Location = grp_bne.Location
        grp_tab_one.Location = grp_bne.Location

        If strProduct_sendto <> "" Then
            cbo_Product.SelectedIndex = cbo_Product.FindString(strProduct_sendto)
        End If

    End Sub

    Private Sub SetCombo()
        Try

            Dim strCrit As String = ""
            Dim strCrit_unit As String = ""


            If cbo_Product.Text <> strALL Then
                strCrit = "where product='" & cbo_Product.Text.Substring(0, 3).Replace("'", "''") & "'"
                strCrit_unit = "where left(product,3) ='" & cbo_Product.Text.Substring(0, 3).Replace("'", "''") & "'"

            Else
                strCrit = ""
            End If

            Dim strSQL As String = ""

            '============basis point===========

    



            '=====================================event==================================

            'strSQL = "select Product from dbo.PRD_TemplateChargeEvents group by Product order by Product"
            'conn.Fill_ComboBox(strSQL, cbo_Product)

            strSQL = "select Event from dbo.PRD_TemplateChargeEvents " & strCrit & " group by Event order by Event"
            conn.Fill_ComboBox(strSQL, cbo_Event, strALL)
            If cbo_Event.Items.Count > 0 Then cbo_Event.SelectedIndex = 0

            strSQL = "select ApplyMinChgAmt from dbo.PRD_TemplateChargeEvents " & strCrit & " group by ApplyMinChgAmt order by ApplyMinChgAmt"
            conn.Fill_ComboBox(strSQL, cbo_ApplyMinChgAmt, strALL)
            If cbo_ApplyMinChgAmt.Items.Count > 0 Then cbo_ApplyMinChgAmt.SelectedIndex = 0


            strSQL = "select ApplyMaxChgAmt from dbo.PRD_TemplateChargeEvents " & strCrit & " group by ApplyMaxChgAmt order by ApplyMaxChgAmt "
            conn.Fill_ComboBox(strSQL, cbo_ApplyMaxChgAmt, strALL)
            If cbo_ApplyMaxChgAmt.Items.Count > 0 Then cbo_ApplyMaxChgAmt.SelectedIndex = 0

            strSQL = "select RoundingType from dbo.PRD_TemplateChargeEvents " & strCrit & "  group by RoundingType order by RoundingType"
            conn.Fill_ComboBox(strSQL, cbo_RoundingType, strALL)
            If cbo_RoundingType.Items.Count > 0 Then cbo_RoundingType.SelectedIndex = 0


            strSQL = "select RoundingAmnt from dbo.PRD_TemplateChargeEvents " & strCrit & " group by RoundingAmnt order by RoundingAmnt"
            conn.Fill_ComboBox(strSQL, cbo_RoundingAmnt, strALL)
            If cbo_RoundingAmnt.Items.Count > 0 Then cbo_RoundingAmnt.SelectedIndex = 0

            '==============================unit============================
            ' strSQL = "select Product from dbo.PRD_TemplateChargeUnits group by Product order by Product"
            '  conn.Fill_ComboBox(strSQL, cbo_Product)
            'cbo_Class
            strSQL = "select Class from dbo.PRD_TemplateChargeUnits " & strCrit_unit & " group by Class order by Class"
            conn.Fill_ComboBox(strSQL, cbo_Class, strALL)
            If cbo_Class.Items.Count > 0 Then cbo_Class.SelectedIndex = 0

            strSQL = "select ChargeCategory from dbo.PRD_TemplateChargeUnits " & strCrit_unit & "  group by ChargeCategory order by ChargeCategory"
            conn.Fill_ComboBox(strSQL, cbo_ChargeCategory, strALL)
            If cbo_ChargeCategory.Items.Count > 0 Then cbo_ChargeCategory.SelectedIndex = 0

            strSQL = "select ChargeUnitCode from dbo.PRD_TemplateChargeUnits " & strCrit_unit & " group by ChargeUnitCode order by ChargeUnitCode"
            conn.Fill_ComboBox(strSQL, cbo_ChargeUnitCode, strALL)
            If cbo_ChargeUnitCode.Items.Count > 0 Then cbo_ChargeUnitCode.SelectedIndex = 0

            strSQL = "select Description from dbo.PRD_TemplateChargeUnits  " & strCrit_unit & " group by Description order by Description "
            conn.Fill_ComboBox(strSQL, cbo_Description, strALL)
            If cbo_Description.Items.Count > 0 Then cbo_Description.SelectedIndex = 0

            strSQL = "select ApplyMinChgAmount from dbo.PRD_TemplateChargeUnits " & strCrit_unit & " group by ApplyMinChgAmount order by ApplyMinChgAmount"
            conn.Fill_ComboBox(strSQL, cbo_ApplyMinChgAmount, strALL)
            If cbo_ApplyMinChgAmount.Items.Count > 0 Then cbo_ApplyMinChgAmount.SelectedIndex = 0

            strSQL = "select ApplyMaxChgAmount from dbo.PRD_TemplateChargeUnits " & strCrit_unit & " group by ApplyMaxChgAmount order by ApplyMaxChgAmount"
            conn.Fill_ComboBox(strSQL, cbo_ApplyMaxChgAmount, strALL)
            If cbo_ApplyMaxChgAmount.Items.Count > 0 Then cbo_ApplyMaxChgAmount.SelectedIndex = 0


            strSQL = "select Rounding from dbo.PRD_TemplateChargeUnits " & strCrit_unit & " group by Rounding order by Rounding"
            conn.Fill_ComboBox(strSQL, cbo_Rounding, strALL)
            If cbo_Rounding.Items.Count > 0 Then cbo_Rounding.SelectedIndex = 0


            strSQL = "select RoundingAmount from dbo.PRD_TemplateChargeUnits " & strCrit_unit & " group by RoundingAmount order by RoundingAmount"
            conn.Fill_ComboBox(strSQL, cbo_RoundingAmount, strALL)
            If cbo_RoundingAmount.Items.Count > 0 Then cbo_RoundingAmount.SelectedIndex = 0

            strSQL = "select ComputationBasis from dbo.PRD_TemplateChargeUnits  " & strCrit_unit & " group by ComputationBasis order by ComputationBasis"
            conn.Fill_ComboBox(strSQL, cbo_ComputationBasis, strALL)
            If cbo_ComputationBasis.Items.Count > 0 Then cbo_ComputationBasis.SelectedIndex = 0

            strSQL = "select ChargeType from dbo.PRD_TemplateChargeUnits " & strCrit_unit & " group by ChargeType order by ChargeType"
            conn.Fill_ComboBox(strSQL, cbo_ChargeType, strALL)
            If cbo_ChargeType.Items.Count > 0 Then cbo_ChargeType.SelectedIndex = 0

            strSQL = "select InterestPeriod from dbo.PRD_TemplateChargeUnits " & strCrit_unit & " group by InterestPeriod order by InterestPeriod"
            conn.Fill_ComboBox(strSQL, cbo_InterestPeriod, strALL)
            If cbo_InterestPeriod.Items.Count > 0 Then cbo_InterestPeriod.SelectedIndex = 0

            strSQL = "select BaseRate from dbo.PRD_TemplateChargeUnits " & strCrit_unit & " group by BaseRate order by BaseRate"
            conn.Fill_ComboBox(strSQL, cbo_BaseRate, strALL)
            If cbo_BaseRate.Items.Count > 0 Then cbo_BaseRate.SelectedIndex = 0


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Function GetSQLByProduct_1_leg() As String
        Dim strSQL As String = ""
        strSQL = ""
        'strSQL += vbCrLf & " upper(u.ApplyMinchg)='NO' "
        'strSQL += vbCrLf & " and u.ApplyMinchgAmount=0 "
        'strSQL += vbCrLf & " and upper(u.ApplyMaxChg)='NO' "
        'strSQL += vbCrLf & " and u.ApplyMaxChgAmount=0 "
        strSQL += vbCrLf & "  upper(u.Rounding)='NONE' "
        strSQL += vbCrLf & " and u.RoundingAmount=0 "
        Select Case cbo_Product.Text.Substring(0, 3)
            Case "MCS", "MCL", "PCL"
                strSQL += vbCrLf & " and upper(u.ComputationBasis)= upper('Value-Based')  "
                strSQL += vbCrLf & " and upper(u.ChargeType)= upper('Direct Slab') "

            Case Else
                strSQL += vbCrLf & " and upper(u.ComputationBasis)= upper('Count-Based')  "
                strSQL += vbCrLf & " and upper(u.ChargeType)= upper('Single Rate') "
        End Select

        strSQL += vbCrLf & " and upper(u.ImmediatePosting)= 'NO' "
        strSQL += vbCrLf & "  and upper(u.ImmediateCompn)= 'NO'  "


        Return strSQL
    End Function

    Private Function GetSQLByProduct_2_leg(Optional ByVal strType As String = "SMZONE") As String
        Dim strSQL As String = ""
        strSQL = ""

        Select Case cbo_Product.Text.Substring(0, 3)
            Case "FTR", "FTL"
                strSQL += vbCrLf & " upper(a.ChargeCategory)='D-RUL-PAID' "
            Case Else
                strSQL += vbCrLf & " upper(a.ChargeCategory)='D-RUL-INST' "
        End Select


        'FTR-FTRDFZONE  / FTL-FTLDFZONE
        If cbo_Product.Text.Substring(0, 3) = "FTL" Or cbo_Product.Text.Substring(0, 3) = "FTR" Then
            If strType = "DFZONE" Then
                strSQL += vbCrLf & " and upper(a.Rounding)=upper('Lowest') "
                strSQL += vbCrLf & " and a.RoundingAmount=1 "
            Else
                strSQL += vbCrLf & " and upper(a.Rounding)='NONE' "
                strSQL += vbCrLf & " and a.RoundingAmount=0 "
            End If
        Else
            If cbo_Product.Text.Substring(0, 3) = "DCT" And chk_compute_basis_two_leg.Checked = True And strType = "DFZONE" Then
                strSQL += vbCrLf & " and upper(a.Rounding)=upper('Lowest') "
                strSQL += vbCrLf & " and a.RoundingAmount=1 "
            Else
                strSQL += vbCrLf & " and upper(a.Rounding)='NONE' "
                strSQL += vbCrLf & " and a.RoundingAmount=0 "
            End If

        End If

        Select Case cbo_Product.Text.Substring(0, 3)
            Case "FTL", "FTR"
                If strType = "DFZONE" Then
                    strSQL += vbCrLf & " and upper(a.ComputationBasis)= upper('Value-Based')  "
                Else
                    strSQL += vbCrLf & " and upper(a.ComputationBasis)= upper('Count-Based')  "
                End If
            Case Else
                If cbo_Product.Text.Substring(0, 3) = "DCT" And chk_compute_basis_two_leg.Checked = True And strType = "DFZONE" Then
                    strSQL += vbCrLf & " and upper(a.ComputationBasis)= upper('Value-Based')  "
                Else
                    strSQL += vbCrLf & " and upper(a.ComputationBasis)= upper('Count-Based')  "
                End If

        End Select

        strSQL += vbCrLf & " and upper(a.ChargeType)= upper('Single Rate') "
        strSQL += vbCrLf & " and upper(a.ImmediatePosting)= 'NO' "
        strSQL += vbCrLf & "  and upper(a.ImmediateCompn)= 'NO'  "


        Return strSQL
    End Function

    Private Function GetSQLByProduct() As String
        Dim strCrit_sub As String = ""


        Select Case cbo_Product.Text.Substring(0, 3)
            Case "BNE"

                strCrit_sub = ""
                strCrit_sub += vbCrLf & " ("
                '==========1 BNEBKKBKK
                strCrit_sub += vbCrLf & "( "
                strCrit_sub += vbCrLf & " select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode and (a.Product = 'BNEBKKBKK' and (  a.BasisPoints1= " & cbo_bne1.Text.Replace(",", "") & "  ) )  "

                If txt_ApplyMinchgAmount_bne1.Text <> "0" Then
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMinchg) ='YES' and  a.ApplyMinchgAmount = " & txt_ApplyMinchgAmount_bne1.Text.Replace(",", "") & ") "
                Else
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMinchg) ='NO') "
                End If

                If txt_ApplyMaxChgAmount_bne1.Text <> "0" Then
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMaxchg) ='YES' and a.ApplyMaxchgAmount = " & txt_ApplyMaxChgAmount_bne1.Text.Replace(",", "") & ") "
                Else
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMaxchg) ='NO') "
                End If

                strCrit_sub += vbCrLf & " and  upper(a.ComputationBasis) = upper('Count-Based') "
                strCrit_sub += vbCrLf & " and  upper(a.ChargeType) = upper('Single Rate') "
                strCrit_sub += vbCrLf & " and  upper(a.ImmediatePosting) =  'NO' "
                strCrit_sub += vbCrLf & " and  upper(a.ImmediateCompn) =  'NO' "

                strCrit_sub += vbCrLf & " )"

                '-----------2 BNEBKKUPC
                strCrit_sub += vbCrLf & "+( "
                strCrit_sub += vbCrLf & " select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode and  ( a.Product = 'BNEBKKUPC' and ( a.BasisPoints1= " & cbo_bne2.Text.Replace(",", "") & "  ) ) "
                If txt_ApplyMinchgAmount_bne2.Text <> "0" Then
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMinchg) ='YES' and  a.ApplyMinchgAmount = " & txt_ApplyMinchgAmount_bne2.Text.Replace(",", "") & ") "
                Else
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMinchg) ='NO') "
                End If
                If txt_ApplyMaxChgAmount_bne2.Text <> "0" Then
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMaxchg) ='YES' and a.ApplyMaxchgAmount = " & txt_ApplyMaxChgAmount_bne2.Text.Replace(",", "") & ") "
                Else
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMaxchg) ='NO') "
                End If
                strCrit_sub += vbCrLf & " and  upper(a.ComputationBasis) = upper('Count-Based') "
                strCrit_sub += vbCrLf & " and  upper(a.ChargeType) = upper('Single Rate') "
                strCrit_sub += vbCrLf & " and  upper(a.ImmediatePosting) =  'NO' "
                strCrit_sub += vbCrLf & " and  upper(a.ImmediateCompn) =  'NO' "

                strCrit_sub += vbCrLf & " )"
                '-----------3 BNEUPCBKK-1
                strCrit_sub += vbCrLf & "+( "
                strCrit_sub += vbCrLf & " select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode and  ( a.Product = 'BNEUPCBKK' and ( a.BasisPoints1= " & cbo_bne3_2.Text.Replace(",", "") & " / 10.00  ) )  " 'a.FixedAmount1 =" & cbo_bne3.Text.Replace(",", "") & " and 
                If txt_ApplyMinchgAmount_bne3.Text <> "0" Then
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMinchg) ='YES' and  a.ApplyMinchgAmount = " & txt_ApplyMinchgAmount_bne3.Text.Replace(",", "") & ") "
                Else
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMinchg) ='NO') "
                End If
                If txt_ApplyMaxChgAmount_bne3.Text <> "0" Then
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMaxchg) ='YES' and a.ApplyMaxchgAmount = " & txt_ApplyMaxChgAmount_bne3.Text.Replace(",", "") & ") "
                Else
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMaxchg) ='NO') "
                End If
                strCrit_sub += vbCrLf & " and  upper(a.ComputationBasis) = upper('Value-Based') "
                strCrit_sub += vbCrLf & " and  upper(a.ChargeType) = upper('Single Rate') "
                strCrit_sub += vbCrLf & " and  upper(a.ImmediatePosting) =  'NO' "
                strCrit_sub += vbCrLf & " and  upper(a.ImmediateCompn) =  'NO' "

                strCrit_sub += vbCrLf & " )"

                '-----------3 BNEUPCBKK-2
                strCrit_sub += vbCrLf & "+( "
                strCrit_sub += vbCrLf & " select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode and  ( a.Product = 'BNEUPCBKK' and ( a.BasisPoints1= " & cbo_bne3.Text.Replace(",", "") & " ) )  " 'a.FixedAmount1 =" & cbo_bne3.Text.Replace(",", "") & " and 
                '----use upcupc
                If txt_ApplyMinchgAmount_bne4.Text <> "0" Then
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMinchg) ='YES' and  a.ApplyMinchgAmount = " & txt_ApplyMinchgAmount_bne4.Text.Replace(",", "") & ") "
                Else
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMinchg) ='NO') "
                End If
                If txt_ApplyMaxChgAmount_bne4.Text <> "0" Then
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMaxchg) ='YES' and a.ApplyMaxchgAmount = " & txt_ApplyMaxChgAmount_bne4.Text.Replace(",", "") & ") "
                Else
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMaxchg) ='NO') "
                End If

                strCrit_sub += vbCrLf & " and  upper(a.ComputationBasis) = upper('Count-Based') "
                strCrit_sub += vbCrLf & " and  upper(a.ChargeType) = upper('Single Rate') "
                strCrit_sub += vbCrLf & " and  upper(a.ImmediatePosting) =  'NO' "
                strCrit_sub += vbCrLf & " and  upper(a.ImmediateCompn) =  'NO' "

                strCrit_sub += vbCrLf & " )"


                '-----------4 BNEUPCUPC
                strCrit_sub += vbCrLf & "+( "
                strCrit_sub += vbCrLf & " select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode and  ( a.Product = 'BNEUPCUPC' and (  a.BasisPoints1= " & cbo_bne4.Text.Replace(",", "") & "  ) )  "
                If txt_ApplyMinchgAmount_bne4.Text <> "0" Then
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMinchg) ='YES' and  a.ApplyMinchgAmount = " & txt_ApplyMinchgAmount_bne4.Text.Replace(",", "") & ") "
                Else
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMinchg) ='NO') "
                End If
                If txt_ApplyMaxChgAmount_bne4.Text <> "0" Then
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMaxchg) ='YES' and a.ApplyMaxchgAmount = " & txt_ApplyMaxChgAmount_bne4.Text.Replace(",", "") & ") "
                Else
                    strCrit_sub += vbCrLf & " and ( upper(a.ApplyMaxchg) ='NO') "
                End If
                strCrit_sub += vbCrLf & " and  upper(a.ComputationBasis) = upper('Count-Based') "
                strCrit_sub += vbCrLf & " and  upper(a.ChargeType) = upper('Single Rate') "
                strCrit_sub += vbCrLf & " and  upper(a.ImmediatePosting) =  'NO' "
                strCrit_sub += vbCrLf & " and  upper(a.ImmediateCompn) =  'NO' "

                strCrit_sub += vbCrLf & " )"

                strCrit_sub += vbCrLf & ")"

                If chk_compute_basis_bne.Checked = True Then
                    strCrit_sub += vbCrLf & " = 5 "
                Else
                    strCrit_sub += vbCrLf & " = 4 "
                End If

                'strCrit_sub += vbCrLf & " = 5 "
                'strCrit_sub += vbCrLf & " (select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode ) "

                strCrit_sub += vbCrLf & " and (select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode ) "

                If chk_compute_basis_bne.Checked = True Then
                    strCrit_sub += vbCrLf & " = 5 "
                Else
                    strCrit_sub += vbCrLf & " = 4 "
                End If

            Case "DCT", "FTR", "FTL", "PCT"
                strCrit_sub = ""


                If CDbl(cbo_same.Text) > 0 And cbo_same.Enabled = True Then


                    strCrit_sub += vbCrLf & "  e.TemplateCode in (select TemplateCode from PRD_TemplateChargeUnits a where (a.Product = '" & cbo_Product.Text.Substring(0, 3) & "SMZONE' and (  a.BasisPoints1= " & cbo_same.Text.Replace(",", "")

                    If CDbl(txt_ApplyMinchgAmount_same.Text) > 0 Then
                        strCrit_sub += vbCrLf & " and  upper(a.ApplyMinchg) ='YES' "
                        strCrit_sub += vbCrLf & " and a.ApplyMinchgAmount  = " & CDbl(txt_ApplyMinchgAmount_same.Text)
                    Else
                        strCrit_sub += vbCrLf & " and  upper(a.ApplyMinchg) ='NO' and a.ApplyMinchgAmount  = 0 "
                    End If
                    If CDbl(txt_ApplyMaxchgAmount_same.Text) > 0 Then
                        strCrit_sub += vbCrLf & " and  upper(a.ApplyMaxchg) ='YES' "
                        strCrit_sub += vbCrLf & " and a.ApplyMaxchgAmount  = " & CDbl(txt_ApplyMaxchgAmount_same.Text)
                    Else
                        strCrit_sub += vbCrLf & " and  upper(a.ApplyMaxchg) ='NO' and a.ApplyMaxchgAmount  = 0 "
                    End If

                    strCrit_sub += vbCrLf & " and " & GetSQLByProduct_2_leg("SMZONE")

                    strCrit_sub += vbCrLf & " ) ) ) "
                End If


                If (CDbl(cbo_same.Text) > 0 And cbo_same.Enabled = True) And (CDbl(cbo_diff.Text) > 0) Then ' Or CDbl(cbo_diff_2.Text) > 0
                    strCrit_sub += vbCrLf & " And "
                End If

                If (CDbl(cbo_diff.Text) > 0) Then 'Or CDbl(cbo_diff_2.Text) > 0
                    If cbo_Product.Text.Substring(0, 3) = "PCT" Or cbo_Product.Text.Substring(0, 3) = "DCT" Or cbo_Product.Text.Substring(0, 3) = "FTL" Or cbo_Product.Text.Substring(0, 3) = "FTR" Then
                        If chk_compute_basis_two_leg.Checked = True Then
                            strCrit_sub += vbCrLf & " e.TemplateCode in (select TemplateCode from PRD_TemplateChargeUnits a where  ( a.Product = '" & cbo_Product.Text.Substring(0, 3) & "DFZONE' and ( a.BasisPoints1=  " & CDbl(cbo_diff.Text.Replace(",", "")) / 10.0 '& "  and  a.FixedAmount1 = " & cbo_diff.Text.Replace(",", "")

                        Else
                            strCrit_sub += vbCrLf & " e.TemplateCode in (select TemplateCode from PRD_TemplateChargeUnits a where  ( a.Product = '" & cbo_Product.Text.Substring(0, 3) & "DFZONE' and ( a.BasisPoints1=  " & CDbl(cbo_diff.Text.Replace(",", "")) '/ 10.0 & "  and  a.FixedAmount1 = " & cbo_diff.Text.Replace(",", "")
                        End If
                    Else
                        strCrit_sub += vbCrLf & " e.TemplateCode in (select TemplateCode from PRD_TemplateChargeUnits a where  ( a.Product = '" & cbo_Product.Text.Substring(0, 3) & "DFZONE' and ( a.BasisPoints1=  " & CDbl(cbo_diff.Text.Replace(",", "")) / 10.0 '& "  and  a.FixedAmount1 = " & cbo_diff.Text.Replace(",", "")

                    End If

                    If CDbl(txt_ApplyMinchgAmount_diff.Text) > 0 Then
                        strCrit_sub += vbCrLf & " and  upper(a.ApplyMinchg) ='YES' "
                        strCrit_sub += vbCrLf & " and a.ApplyMinchgAmount  = " & CDbl(txt_ApplyMinchgAmount_diff.Text)
                    Else
                        strCrit_sub += vbCrLf & " and  upper(a.ApplyMinchg) ='NO' and a.ApplyMinchgAmount  = 0 "
                    End If
                    If CDbl(txt_ApplyMaxchgAmount_diff.Text) > 0 Then
                        strCrit_sub += vbCrLf & " and  upper(a.ApplyMaxchg) ='YES' "
                        strCrit_sub += vbCrLf & " and a.ApplyMaxchgAmount  = " & CDbl(txt_ApplyMaxchgAmount_diff.Text)
                    Else
                        strCrit_sub += vbCrLf & " and  upper(a.ApplyMaxchg) ='NO' and a.ApplyMaxchgAmount  = 0 "
                    End If

                    strCrit_sub += vbCrLf & " and " & GetSQLByProduct_2_leg("DFZONE")

                    strCrit_sub += vbCrLf & " ) ) )"
                End If



                ' strCrit_sub += vbCrLf & ")"

                ' strCrit_sub += vbCrLf & "="
                ' strCrit_sub += vbCrLf & " (select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode ) "

                '(select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode )

                If CDbl(cbo_same.Text) <> 0 And (CDbl(cbo_diff.Text) > 0) Then
                    strCrit_sub += vbCrLf & " and (select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode ) "
                    strCrit_sub += vbCrLf & " =2"
                End If

                If CDbl(cbo_same.Text) <> 0 And Not (CDbl(cbo_diff.Text) > 0) Then
                    strCrit_sub += vbCrLf & " and (select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode ) "
                    strCrit_sub += vbCrLf & " =1"
                End If

                If CDbl(cbo_same.Text) = 0 And (CDbl(cbo_diff.Text) > 0) Then
                    strCrit_sub += vbCrLf & " and (select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode ) "
                    strCrit_sub += vbCrLf & " =1"
                End If

            Case "MCL", "MCS", "PCL"
                strCrit_sub = ""
                strCrit_sub = GetSQLByProduct_1_leg()
                If cbo_tier1.Text <> "" Then
                    strCrit_sub += IIf(strCrit_sub = "", "", " AND ") & " ( u.FixedAmount1 =  " & cbo_tier1.Text.Replace(",", "") & " )"
                End If

                If cbo_tier2.Text <> "" Then
                    strCrit_sub += IIf(strCrit_sub = "", "", " AND ") & " ( u.FixedAmount2 =  " & cbo_tier2.Text.Replace(",", "") & " )"
                End If

                If cbo_tier3.Text <> "" Then
                    strCrit_sub += IIf(strCrit_sub = "", "", " AND ") & " ( u.FixedAmount3 =  " & cbo_tier3.Text.Replace(",", "") & " )"
                End If

            Case "COC", "COE"
                'cbo_ChargeAmount
                strCrit_sub = ""
                strCrit_sub = GetSQLByProduct_1_leg()
                If cbo_ChargeAmount.Text <> "" Then
                    strCrit_sub += " AND ( u.BasisPoints1 =  " & cbo_ChargeAmount.Text.Replace(",", "") & " )"
                End If

            Case Else
        End Select

        Return strCrit_sub

    End Function

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

    Private Sub UpGrid_Template()
        Try

            Dim strError As String = ""

            If cbo_Product.Text = "" Or cbo_Product.Text = strALL Then Exit Sub

            If rad_defer_y.Checked = True Then

                If GetErrorNumberic(txt_PostingDay_Monthly.Text) = True Then
                    strError += IIf(strError = "", "", vbCrLf) & "Invalid [Monthly Charge]"
                Else
                    If CDbl(txt_PostingDay_Monthly.Text) < 0 Or CDbl(txt_PostingDay_Monthly.Text) > 31 Then
                        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Monthly Charge]"
                    End If
                End If

            End If


            'Select Case cbo_Product.Text.Substring(0, 3)
            '    Case "BNE"

            '        '========Bangkok To Bangkok==========

            '        If GetErrorNumberic(cbo_bne1.Text) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Bangkok To Bangkok]"
            '        End If

            '        '=========Bangkok To Upcountry==========
            '        If GetErrorNumberic(cbo_bne2.Text) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Bangkok To Upcountry]"
            '        End If


            '        '=============Upcountry To Bangkok=============
            '        If GetErrorNumberic(cbo_bne3.Text) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Upcountry To Bangkok]"
            '        End If

            '        If GetErrorNumberic(cbo_bne3_2.Text) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Per 10,000]"
            '        End If

            '        '=============Upcountry To Upcountry=============
            '        If GetErrorNumberic(cbo_bne4.Text) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Upcountry To Upcountry]"
            '        End If

            '        '=================================
            '        If GetErrorNumberic(txt_ApplyMinchgAmount_bne1.Text, True) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMinchgAmount-1 (Bangkok To Bangkok) ]"
            '        End If
            '        If GetErrorNumberic(txt_ApplyMinchgAmount_bne2.Text, True) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMinchgAmount-2 (Bangkok To Upcountry) ]"
            '        End If
            '        If GetErrorNumberic(txt_ApplyMinchgAmount_bne3.Text, True) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMinchgAmount-3 (Upcountry To Bangkok) ]"
            '        End If
            '        If GetErrorNumberic(txt_ApplyMinchgAmount_bne4.Text, True) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMinchgAmount-4 (Upcountry To Upcountr) ]"
            '        End If
            '        '=================================
            '        If GetErrorNumberic(txt_ApplyMaxChgAmount_bne1.Text, True) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMaxchgAmount-1 (Bangkok To Bangkok) ]"
            '        End If
            '        If GetErrorNumberic(txt_ApplyMaxChgAmount_bne2.Text, True) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMaxchgAmount-2 (Bangkok To Upcountry) ]"
            '        End If
            '        If GetErrorNumberic(txt_ApplyMaxChgAmount_bne3.Text, True) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMaxchgAmount-3 (Upcountry To Bangkok) ]"
            '        End If
            '        If GetErrorNumberic(txt_ApplyMaxChgAmount_bne4.Text, True) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [ApplyMaxchgAmount-4 (Upcountry To Upcountr) ]"
            '        End If
            '        '=================================

            '    Case "DCT", "FTR", "FTL", "PCT"

            '        If cbo_same.Text <> "" Then
            '            If IsNumeric(cbo_same.Text) = False Then
            '                strError += IIf(strError = "", "", vbCrLf) & "Invalid [Same Zone]"
            '            End If
            '        Else
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Same Zone]"
            '        End If

            '        If cbo_diff.Text <> "" Then
            '            If IsNumeric(cbo_diff.Text) = False Then
            '                strError += IIf(strError = "", "", vbCrLf) & "Invalid [Diff Zone]"
            '            End If
            '        Else
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Diff Zone]"
            '        End If

            '        If GetErrorNumberic(txt_ApplyMinchgAmount_same.Text, False) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Min Amount (Same Zone) ]"
            '        End If

            '        If GetErrorNumberic(txt_ApplyMinchgAmount_diff.Text, False) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Min Amount (Diff Zone) ]"
            '        End If

            '        If GetErrorNumberic(txt_ApplyMaxchgAmount_same.Text, False) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Max Amount (Same Zone) ]"
            '        End If

            '        If GetErrorNumberic(txt_ApplyMaxchgAmount_diff.Text, False) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Max Amount (Diff Zone) ]"
            '        End If


            '    Case "MCL", "MCS", "PCL"
            '        'cbo_tier1
            '        If cbo_tier1.Text <> "" Then
            '            If IsNumeric(cbo_tier1.Text) = False Then
            '                strError += IIf(strError = "", "", vbCrLf) & "Invalid [Tier 1]"
            '            End If
            '        Else
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Tier 1]"
            '        End If

            '        If cbo_tier2.Text <> "" Then
            '            If IsNumeric(cbo_tier2.Text) = False Then
            '                strError += IIf(strError = "", "", vbCrLf) & "Invalid [Tier 2]"
            '            End If
            '        Else
            '            ' strError += IIf(strError = "", "", vbCrLf) & "Invalid [Tier 2]"
            '        End If

            '        If cbo_tier3.Text <> "" Then
            '            If IsNumeric(cbo_tier3.Text) = False Then
            '                strError += IIf(strError = "", "", vbCrLf) & "Invalid [Tier 3]"
            '            End If
            '        Else
            '            ' strError += IIf(strError = "", "", vbCrLf) & "Invalid [Tier 3]"
            '        End If

            '        If GetErrorNumberic(txt_ApplyMinchgAmount_t1.Text, False) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Min Amount (Tier 1) ]"
            '        End If
            '        'If GetErrorNumberic(txt_ApplyMinchgAmount_t2.Text, False) = True Then
            '        '    strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Min Amount (Tier 2) ]"
            '        'End If
            '        'If GetErrorNumberic(txt_ApplyMinchgAmount_t3.Text, False) = True Then
            '        '    strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Min Amount (Tier 3) ]"
            '        'End If

            '        If GetErrorNumberic(txt_ApplyMaxchgAmount_t1.Text, False) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Max Amount (Tier 1) ]"
            '        End If
            '        'If GetErrorNumberic(txt_ApplyMaxchgAmount_t2.Text, False) = True Then
            '        '    strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Max Amount (Tier 2) ]"
            '        'End If
            '        'If GetErrorNumberic(txt_ApplyMaxchgAmount_t3.Text, False) = True Then
            '        '    strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Max Amount (Tier 3) ]"
            '        'End If


            '    Case "COC", "COE"
            '        'Frm_TemplateChargeUnit_list
            '        If cbo_ChargeAmount.Text <> "" Then
            '            If IsNumeric(cbo_ChargeAmount.Text) = False Then
            '                strError += IIf(strError = "", "", vbCrLf) & "Invalid [Charge Amount]"
            '            End If
            '        Else
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Charge Amount]"
            '        End If

            '        If GetErrorNumberic(txt_ApplyMinchgAmount_one.Text, False) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Min Amount]"
            '        End If

            '        If GetErrorNumberic(txt_ApplyMaxchgAmount_one.Text, False) = True Then
            '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Apply Max Amount]"
            '        End If

            '    Case Else
            'End Select

            'If strError <> "" Then
            '    MsgBox(strError)
            '    Exit Sub
            'End If


            '=============validation===============
            Select Case cbo_Product.Text.Substring(0, 3)
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

                    If chk_compute_basis_bne.Checked = True Then
                        If GetErrorNumberic(cbo_bne3_2.Text) = True Then
                            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Per 10,000]"
                        End If
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

                    'chk_compute_basis_bne

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

                    'If cbo_diff_2.Text <> "" Then
                    '    If IsNumeric(cbo_diff_2.Text) = False Then
                    '        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Diff Zone(Per 10,000 *)]"
                    '    End If
                    'Else
                    '    strError += IIf(strError = "", "", vbCrLf) & "Invalid [Diff Zone-(Per 10,000 *)]"
                    'End If

                    'If chk_ValueBased.Checked = True Then
                    '    If cbo_diff_2.Text <> "" Then
                    '        If IsNumeric(cbo_diff_2.Text) = False Then
                    '            strError += IIf(strError = "", "", vbCrLf) & "Invalid [Diff Zone(Per 10,000 *)]"
                    '        End If
                    '    Else
                    '        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Diff Zone-(Per 10,000 *)]"
                    '    End If
                    'End If
                    'If IsNumeric(cbo_same.Text) = True And IsNumeric(cbo_diff.Text) = True And IsNumeric(cbo_diff_2.Text) = True Then
                    '    If CDbl(cbo_same.Text) = 0 And Not (CDbl(cbo_diff.Text) > 0 Or CDbl(cbo_diff_2.Text) > 0) Then
                    '        strError += IIf(strError = "", "", vbCrLf) & "Invalid [Zero charge is not require in GCP.]"
                    '    End If
                    'End If

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
            Dim strCrit As String = ""

            strCrit = ""

            If cbo_Product.Text <> "" And cbo_Product.Text <> strALL Then

                '==================event=============
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(left(e.TemplateCode,3))='" & cbo_Product.Text.Substring(0, 3).Replace("''", "''") & "' "

                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " e.[TemplateCode]  in (select TemplateCode from dbo.PRD_Template where StatusTemplate='Y')"

                'mandatory criteria
                If cbo_Product.Text.Substring(0, 3) = "FTR" Or cbo_Product.Text.Substring(0, 3) = "FTL" Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " e.[Event] = 'DPAIDLIQ' "
                Else
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " e.[Event] = 'DATAENTRY' "
                End If

                strCrit += IIf(strCrit = "", "WHERE", "AND") & " ( upper(e.ApplyMinChg)='NO' and ApplyMinChgAmt=0 ) "
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " ( upper(e.ApplyMaxChg)='NO' and ApplyMaxChgAmt=0 ) "

                strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.RoundingType) = 'NONE' and e.RoundingAmnt=0 "
                'ComputationFrequency
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.ComputationFrequency) = 'IMMEDIATE' "
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.ComputationPeriodType) = 'DAILY' "
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " e.ComputationPeriod=0 and e.ComputationDay=0 "



                If rad_defer_y.Checked = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.PostingFrequency) = 'DEFERRED' "
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.PostingPeriodType) = 'MONTHLY' "
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " e.PostingPeriod=1 and e.PostingDay= " & txt_PostingDay_Monthly.Text.Replace(",", "")

                Else

                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.PostingFrequency) = 'IMMEDIATE' "
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.PostingPeriodType) = 'DAILY' "
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " e.PostingPeriod=0 and e.PostingDay=0 "

                End If

                '==================unit=============************
                strCrit += IIf(strCrit = "", "WHERE", "AND") & "  not u.TemplateCode in (select TemplateCode from dbo.PRD_TemplateChargeUnits a where not a.Class in ('RULE','PRODUCT')  ) "
                strCrit += IIf(strCrit = "", "WHERE", "AND") & "  not u.TemplateCode in (select TemplateCode from dbo.PRD_TemplateChargeUnits a where not ( (upper(a.Rounding) = upper('None') and a.RoundingAmount=0 ) or ( upper(a.Rounding) = upper('Lowest') and  a.product in ('BNEUPCBKK','FTLDFZONE','FTRDFZONE','DCTDFZONE') and a.RoundingAmount=1)  ) )  "
                strCrit += IIf(strCrit = "", "WHERE", "AND") & "  not u.TemplateCode in (select TemplateCode from dbo.PRD_TemplateChargeUnits a where not ( a.ChargeCategory in ('D-RUL-INST')  or (a.ChargeCategory in ('D-RUL-PAID') and a.product like 'FT%' )) )  "
                'strCrit += IIf(strCrit = "", "WHERE", "AND") & "  not u.TemplateCode in (select TemplateCode from dbo.PRD_TemplateChargeUnits a where not ( upper(a.ComputationBasis) = upper('Count-Based') or ( upper(a.ComputationBasis) = upper('Value-Based')  and a.product in ('BNEUPCBKK','MCLRULE','MCSRULE','PCLRULE','FTRDFZONE' ,'FTLDFZONE','DCTDFZONE' ) ))   ) "
                strCrit += IIf(strCrit = "", "WHERE", "AND") & "  not u.TemplateCode in (select TemplateCode from dbo.PRD_TemplateChargeUnits a where not (upper(a.ChargeType) = upper('Single Rate') or (upper(a.ChargeType) = upper('Direct Slab') and a.product in ('MCLRULE','MCSRULE','PCLRULE') )  ) ) "
                strCrit += IIf(strCrit = "", "WHERE", "AND") & "  not u.TemplateCode in (select TemplateCode from dbo.PRD_TemplateChargeUnits a where  not a.ImmediatePosting='NO' ) "
                strCrit += IIf(strCrit = "", "WHERE", "AND") & "  not u.TemplateCode in (select TemplateCode from dbo.PRD_TemplateChargeUnits a where  not a.ImmediateCompn='NO' )"



            End If

            If rad_defer_y.Checked = True Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " e.PostingFrequency ='DEFERRED' and e.PostingPeriodType='MONTHLY'  "
            Else
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " e.PostingFrequency ='IMMEDIATE' and e.PostingPeriodType='DAILY'  "
            End If
            '=========advance amount
            'cbo_bne1
            Dim strCrit_sub As String = GetSQLByProduct()

            If strCrit_sub <> "" Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & strCrit_sub.ToString
            End If


            '===== NO ADVANCE ========
            'If cbo_bne1.TEX Then

            '========================events=====================
            If cbo_Event.Text <> "" And cbo_Event.Text <> strALL Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " e.[Event] like '%" & cbo_Event.Text.Replace("''", "''") & "%' "
            End If

            If rad_ApplyMinChg_ALL.Checked = False Then
                If rad_ApplyMinChg_Yes.Checked = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[ApplyMinChg]) ='YES' "
                Else
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[ApplyMinChg]) ='NO' "
                End If
            End If


            If cbo_ApplyMinChgAmt.Text <> "" And cbo_ApplyMinChgAmt.Text <> strALL Then
                If IsNumeric(cbo_ApplyMinChgAmt.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  e.ApplyMinChgAmt = " & cbo_ApplyMinChgAmt.Text.Replace(",", "") & " "
                End If
            End If

            If rad_ApplyMaxChg_ALL.Checked = False Then
                If rad_ApplyMaxChg_Yes.Checked = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[ApplyMaxChg]) ='YES' "
                Else
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[ApplyMaxChg]) ='NO' "
                End If
            End If

            If cbo_ApplyMaxChgAmt.Text <> "" And cbo_ApplyMaxChgAmt.Text <> strALL Then
                If IsNumeric(cbo_ApplyMaxChgAmt.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  e.ApplyMinChgAmt = " & cbo_ApplyMaxChgAmt.Text.Replace(",", "") & " "
                End If
            End If

            If cbo_RoundingType.Text <> "" And cbo_RoundingType.Text <> strALL Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " e.[RoundingType] ='" & cbo_RoundingType.Text.Replace("''", "''") & "' "
            End If

            If cbo_RoundingType.Text <> "" And cbo_RoundingType.Text <> strALL Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " e.[RoundingType] ='" & cbo_RoundingType.Text.Replace("''", "''") & "' "
            End If

            If cbo_ApplyMinChgAmt.Text <> "" And cbo_ApplyMinChgAmt.Text <> strALL Then
                If IsNumeric(cbo_ApplyMinChgAmt.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  e.ApplyMinChgAmt = " & cbo_ApplyMinChgAmt.Text.Replace(",", "") & " "
                End If
            End If

            If rad_ComputationFrequency_ALL.Checked = False Then
                If rad_ComputationFrequency_1.Checked = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[ApplyMaxChg]) ='YES' "
                Else
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[ApplyMaxChg]) ='NO' "
                End If
            End If

            If rad_ComputationPeriodType_ALL.Checked = False Then
                If rad_ComputationFrequency_1.Checked = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[ComputationPeriodType]) ='YES' "
                Else
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[ComputationPeriodType]) ='NO' "
                End If
            End If

            If txt_ComputationPeriod.Text <> "" And cbo_ApplyMinChgAmt.Text <> strALL Then
                If IsNumeric(txt_ComputationPeriod.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  e.ComputationPeriod = " & txt_ComputationPeriod.Text.Replace(",", "") & " "
                End If
            End If

            If txt_ComputationDay.Text <> "" And cbo_ApplyMinChgAmt.Text <> strALL Then
                If IsNumeric(txt_ComputationDay.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  e.ComputationDay = " & txt_ComputationDay.Text.Replace(",", "") & " "
                End If
            End If

            If rad_PostingFrequency_ALL.Checked = False Then
                If rad_PostingFrequency_1.Checked = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[PostingFrequency]) ='IMMEDIATE' "
                Else
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[PostingFrequency]) ='DEFERRED' "
                End If
            End If

            If rad_ComputationPeriodType_ALL.Checked = False Then
                If rad_ComputationPeriodType_1.Checked = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[PostingFrequency]) ='DAYS' "
                Else
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[PostingFrequency]) ='MONTHS' "
                End If
            End If

            If txt_ComputationPeriod.Text <> "" And cbo_ApplyMinChgAmt.Text <> strALL Then
                If IsNumeric(txt_ComputationPeriod.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  e.ComputationPeriod = " & txt_ComputationPeriod.Text.Replace(",", "") & " "
                End If
            End If


            If txt_ComputationDay.Text <> "" And cbo_ApplyMinChgAmt.Text <> strALL Then
                If IsNumeric(txt_ComputationDay.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  e.ComputationDay = " & txt_ComputationDay.Text.Replace(",", "") & " "
                End If
            End If

            If rad_PostingFrequency_ALL.Checked = False Then
                If rad_PostingFrequency_1.Checked = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[PostingFrequency]) ='DAYS' "
                Else
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(e.[PostingFrequency]) ='MONTHS' "
                End If
            End If

            If rad_PostingPeriodType_1.Text <> "" And cbo_ApplyMinChgAmt.Text <> strALL Then
                If IsNumeric(txt_ComputationPeriod.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  e.ComputationPeriod = " & txt_ComputationPeriod.Text.Replace(",", "") & " "
                End If
            End If

            If txt_PostingPeriod.Text <> "" And cbo_ApplyMinChgAmt.Text <> strALL Then
                If IsNumeric(txt_PostingPeriod.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  e.PostingPeriod = " & txt_PostingPeriod.Text.Replace(",", "") & " "
                End If
            End If

            If txt_PostingDay.Text <> "" And txt_PostingDay.Text <> strALL Then
                If IsNumeric(txt_PostingDay.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  e.PostingDay = " & txt_PostingDay.Text.Replace(",", "") & " "
                End If
            End If

            '========================unit=====================

            If cbo_Class.Text <> "" And cbo_Class.Text <> strALL Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " u.[Class] ='" & cbo_Class.Text.Replace("''", "''") & "' "
            End If

            If cbo_ChargeCategory.Text <> "" And cbo_ChargeCategory.Text <> strALL Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " u.[ChargeCategory]  like '%" & cbo_ChargeCategory.Text.Replace("''", "''") & "%' "
            End If

            If cbo_ChargeUnitCode.Text <> "" And cbo_ChargeUnitCode.Text <> strALL Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " u.[ChargeUnitCode]  like '%" & cbo_ChargeUnitCode.Text.Replace("''", "''") & "%' "
            End If

            If cbo_Description.Text <> "" And cbo_Description.Text <> strALL Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " u.[Description]  like '%" & cbo_Description.Text.Replace("''", "''") & "%' "
            End If

            If rad_ApplyMinchg_a.Checked = False Then
                If rad_ApplyMinchg_y.Checked = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(u.[ApplyMinchg]) ='YES' "
                Else
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(u.[ApplyMinchg]) ='NO' "
                End If
            End If

            If cbo_ApplyMinChgAmount.Text <> "" And cbo_ApplyMinChgAmount.Text <> strALL Then
                If IsNumeric(cbo_ApplyMinChgAmount.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  u.ApplyMinChgAmount = " & cbo_ApplyMinChgAmount.Text.Replace(",", "") & " "
                End If
            End If

            If rad_ApplyMaxChg_a.Checked = False Then
                If rad_ApplyMaxChg_y.Checked = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(u.[ApplyMaxChg]) ='YES' "
                Else
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(u.[ApplyMaxChg]) ='NO' "
                End If
            End If

            If cbo_ApplyMaxChgAmount.Text <> "" And cbo_ApplyMaxChgAmount.Text <> strALL Then
                If IsNumeric(cbo_ApplyMaxChgAmount.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  u.ApplyMaxChgAmount = " & cbo_ApplyMaxChgAmount.Text.Replace(",", "") & " "
                End If
            End If

            If cbo_Rounding.Text <> "" And cbo_Rounding.Text <> strALL Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " u.[Rounding] ='" & cbo_Rounding.Text.Replace("''", "''") & "' "
            End If

            If cbo_RoundingAmount.Text <> "" And cbo_ApplyMinChgAmt.Text <> strALL Then
                If IsNumeric(cbo_RoundingAmount.Text) = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & "  u.RoundingAmount = " & cbo_RoundingAmount.Text.Replace(",", "") & " "
                End If
            End If

            If cbo_ComputationBasis.Text <> "" And cbo_ComputationBasis.Text <> strALL Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " u.[ComputationBasis] ='" & cbo_ComputationBasis.Text.Replace("''", "''") & "' "
            End If

            If cbo_ChargeType.Text <> "" And cbo_ChargeType.Text <> strALL Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " u.[ChargeType] ='" & cbo_ChargeType.Text.Replace("''", "''") & "' "
            End If

            If cbo_InterestPeriod.Text <> "" And cbo_InterestPeriod.Text <> strALL Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " u.[InterestPeriod] ='" & cbo_InterestPeriod.Text.Replace("''", "''") & "' "
            End If

            If cbo_BaseRate.Text <> "" And cbo_BaseRate.Text <> strALL Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " u.[BaseRate] ='" & cbo_BaseRate.Text.Replace("''", "''") & "' "
            End If

            If rad_ImmediatePosting_all.Checked = False Then
                If rad_ImmediatePosting_y.Checked = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(u.[ImmediatePosting]) ='IMMEDIATE' "
                Else
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(u.[ImmediatePosting]) ='DEFERRED' "
                End If
            End If

            If rad_ImmediateCompn_all.Checked = False Then
                If rad_ImmediateCompn_y.Checked = True Then
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(u.[ImmediateCompn]) ='DAYS' "
                Else
                    strCrit += IIf(strCrit = "", "WHERE", "AND") & " upper(u.[ImmediateCompn]) ='MONTHS' "
                End If
            End If

            '==========unit - detail
            Dim i As Integer
            For i = 1 To 11
                If grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text <> "" Then

                End If

                If grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text <> "" And grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text <> strALL Then
                    If IsNumeric(grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text) = True Then
                        strCrit += IIf(strCrit = "", "WHERE", "AND") & "  u.LowerLimit" & i.ToString & " = " & grp_chg.Controls.Item("txt_LowerLimit_" & i.ToString).Text.Replace(",", "") & " "
                    End If
                End If

                If grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Text <> "" And grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Text <> strALL Then
                    If IsNumeric(grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Text) = True Then
                        strCrit += IIf(strCrit = "", "WHERE", "AND") & "  u.UpperLimit" & i.ToString & " = " & grp_chg.Controls.Item("txt_UpperLimit_" & i.ToString).Text.Replace(",", "") & " "
                    End If
                End If

                If grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Text <> "" And grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Text <> strALL Then
                    If IsNumeric(grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Text) = True Then
                        strCrit += IIf(strCrit = "", "WHERE", "AND") & "  u.FixedAmount" & i.ToString & " = " & grp_chg.Controls.Item("txt_FixedAmount_" & i.ToString).Text.Replace(",", "") & " "
                    End If
                End If

                If grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Text <> "" And grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Text <> strALL Then
                    If IsNumeric(grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Text) = True Then
                        strCrit += IIf(strCrit = "", "WHERE", "AND") & "  u.BasisPoints" & i.ToString & " = " & grp_chg.Controls.Item("txt_BasisPoints_" & i.ToString).Text.Replace(",", "") & " "
                    End If
                End If

            Next i

            '===================

            strSQL = ""
            strSQL += " select " & vbCrLf
            strSQL += " distinct top 1  e.TemplateCode  " & vbCrLf
            strSQL += " ,(select COUNT(*) from [PRD_TemplateChargeEvents] a where a.TemplateCode =e.TemplateCode ) AS [Total Of Event] " & vbCrLf
            strSQL += "  ,(select COUNT(*) from PRD_TemplateChargeUnits a where a.TemplateCode =e.TemplateCode ) as [Total Of Unit] " & vbCrLf
            strSQL += "  from " & vbCrLf
            strSQL += " 	dbo.PRD_TemplateChargeEvents e " & vbCrLf
            strSQL += "  left outer join dbo.PRD_TemplateChargeUnits u" & vbCrLf
            strSQL += "  on (e.TemplateCode=u.TemplateCode  ) " & vbCrLf 'and e.[Event] = u.[Event]
            strSQL += strCrit & vbCrLf
            strSQL += " group by e.TemplateCode  "
            strSQL += " order by e.TemplateCode  "

            Call conn.SetGrid(strSQL, grd_Template)
            ' Dim i As Integer
            For i = 0 To grd_Template.Columns.Count - 1
                grd_Template.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
            grd_Template.Columns("Total Of Event").DefaultCellStyle.Format = "###,###0"
            grd_Template.Columns("Total Of Event").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd_Template.Columns("Total Of Unit").DefaultCellStyle.Format = "###,###0"
            grd_Template.Columns("Total Of Unit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            grd_Template.Columns("Total Of Event").DefaultCellStyle.Format = "###,###0"
            grd_Template.Columns("Total Of Event").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd_Template.Columns("Total Of Unit").DefaultCellStyle.Format = "###,###0"
            grd_Template.Columns("Total Of Unit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            If grd_Template.RowCount > 0 Then
                grd_Template.Rows.Item(0).Selected = True
                Call SetGrid()
            Else
                grd_Event.DataSource = Nothing
                grd_unit.DataSource = Nothing

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub UpGrid_Template_EventsAndUnit(ByVal strTemplateCode As String)
        Try
            Dim strSQL As String = ""
            Dim strCrit As String = ""
            strCrit = ""
            If strTemplateCode <> "" Then
                strCrit += IIf(strCrit = "", "WHERE", "AND") & " TemplateCode ='" & strTemplateCode & "' "
            End If

            strSQL = ""
            strSQL += vbCrLf & "  Select [TemplateCode]"
            strSQL += vbCrLf & " ,[Product]"
            strSQL += vbCrLf & " ,[ProductCCY]"
            strSQL += vbCrLf & " ,[Event]"
            strSQL += vbCrLf & " ,[ApplyMinChg]"
            strSQL += vbCrLf & " ,[ApplyMinChgAmt]"
            strSQL += vbCrLf & " ,[ApplyMaxChg]"
            strSQL += vbCrLf & " ,[ApplyMaxChgAmt]"
            strSQL += vbCrLf & " ,[RoundingType]"
            strSQL += vbCrLf & " ,[RoundingAmnt]"
            strSQL += vbCrLf & " ,[TemplateEffectiveFrom]"
            strSQL += vbCrLf & " ,[ComputationFrequency]"
            strSQL += vbCrLf & " ,[ComputationPeriodType]"
            strSQL += vbCrLf & " ,[ComputationPeriod]"
            strSQL += vbCrLf & " ,[ComputationDay]"
            strSQL += vbCrLf & " ,[NextComputationDate]"
            strSQL += vbCrLf & " ,[PostingFrequency]"
            strSQL += vbCrLf & " ,[PostingPeriodType]"
            strSQL += vbCrLf & " ,[PostingPeriod]"
            strSQL += vbCrLf & " ,[PostingDay]"
            strSQL += vbCrLf & " ,[NextPostingDate]"
            strSQL += vbCrLf & " FROM [dbo].[PRD_TemplateChargeEvents] "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " order by [TemplateCode],Product ,ProductCCY,Event "
            Call conn.SetGrid(strSQL, grd_Event)


            Dim i As Integer
            For i = 0 To grd_Event.Columns.Count - 1
                grd_Event.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

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


            strSQL = ""
            strSQL += vbCrLf & " SELECT [TemplateCode]"
            strSQL += vbCrLf & "       ,[Class]"
            strSQL += vbCrLf & "       ,[Product]"

            strSQL += vbCrLf & "      ,[ApplyMinchg]"
            strSQL += vbCrLf & "      ,[ApplyMinchgAmount]"
            strSQL += vbCrLf & "      ,[ApplyMaxChg]"
            strSQL += vbCrLf & "      ,[ApplyMaxChgAmount]"

            strSQL += vbCrLf & "      ,[LowerLimit1]"
            strSQL += vbCrLf & "      ,[UpperLimit1]"
            strSQL += vbCrLf & "      ,[FixedAmount1]"
            strSQL += vbCrLf & "      ,[BasisPoints1]"
            strSQL += vbCrLf & "      ,[LowerLimit2]"
            strSQL += vbCrLf & "      ,[UpperLimit2]"
            strSQL += vbCrLf & "      ,[FixedAmount2]"
            strSQL += vbCrLf & "      ,[BasisPoints2]"
            strSQL += vbCrLf & "      ,[LowerLimit3]"
            strSQL += vbCrLf & "      ,[UpperLimit3]"
            strSQL += vbCrLf & "      ,[FixedAmount3]"
            strSQL += vbCrLf & "      ,[BasisPoints3]"
            strSQL += vbCrLf & "      ,[LowerLimit4]"
            strSQL += vbCrLf & "      ,[UpperLimit4]"
            strSQL += vbCrLf & "      ,[FixedAmount4]"
            strSQL += vbCrLf & "      ,[BasisPoints4]"
            strSQL += vbCrLf & "      ,[LowerLimit5]"
            strSQL += vbCrLf & "      ,[UpperLimit5]"
            strSQL += vbCrLf & "      ,[FixedAmount5]"
            strSQL += vbCrLf & "      ,[BasisPoints5]"
            strSQL += vbCrLf & "      ,[LowerLimit6]"
            strSQL += vbCrLf & "      ,[UpperLimit6]"
            strSQL += vbCrLf & "      ,[FixedAmount6]"
            strSQL += vbCrLf & "      ,[BasisPoints6]"

            strSQL += vbCrLf & "      ,[LowerLimit7]"
            strSQL += vbCrLf & "      ,[UpperLimit7]"
            strSQL += vbCrLf & "      ,[FixedAmount7]"
            strSQL += vbCrLf & "      ,[BasisPoints7]"

            strSQL += vbCrLf & "      ,[LowerLimit8]"
            strSQL += vbCrLf & "      ,[UpperLimit8]"
            strSQL += vbCrLf & "      ,[FixedAmount8]"
            strSQL += vbCrLf & "      ,[BasisPoints8]"

            strSQL += vbCrLf & "      ,[LowerLimit9]"
            strSQL += vbCrLf & "      ,[UpperLimit9]"
            strSQL += vbCrLf & "      ,[FixedAmount9]"
            strSQL += vbCrLf & "      ,[BasisPoints9]"

            strSQL += vbCrLf & "      ,[LowerLimit10]"
            strSQL += vbCrLf & "      ,[UpperLimit10]"
            strSQL += vbCrLf & "      ,[FixedAmount10]"
            strSQL += vbCrLf & "      ,[BasisPoints10]"

            strSQL += vbCrLf & "      ,[LowerLimit11]"
            strSQL += vbCrLf & "      ,[UpperLimit11]"
            strSQL += vbCrLf & "      ,[FixedAmount11]"
            strSQL += vbCrLf & "      ,[BasisPoints11]"

            strSQL += vbCrLf & "       ,[ProductCCY]"
            strSQL += vbCrLf & "       ,[ChargesDefinedFor]"
            strSQL += vbCrLf & "       ,[ChargeCategory]"
            strSQL += vbCrLf & "       ,[Event]"
            strSQL += vbCrLf & "       ,[ChargeUnitCode]"
            strSQL += vbCrLf & "       ,[Description]"

            strSQL += vbCrLf & "      ,[Rounding]"
            strSQL += vbCrLf & "      ,[RoundingAmount]"
            strSQL += vbCrLf & "      ,[TemplateEffectiveFrom]"
            strSQL += vbCrLf & "      ,[ComputationBasis]"
            strSQL += vbCrLf & "      ,[ChargeType]"
            strSQL += vbCrLf & "      ,[InterestPeriod]"
            strSQL += vbCrLf & "      ,[BaseRate]"
            strSQL += vbCrLf & "      ,[ImmediatePosting]"
            strSQL += vbCrLf & "      ,[ImmediateCompn]"
            strSQL += vbCrLf & "      ,[ChgUnitDet]"


            strSQL += vbCrLf & "  FROM [dbo].[PRD_TemplateChargeUnits]"
            strSQL += vbCrLf & " WHERE TemplateCode ='" + strTemplateCode + "'"
            strSQL += vbCrLf & " ORDER BY  [TemplateCode]"
            strSQL += vbCrLf & "       ,[Class]"
            strSQL += vbCrLf & "       ,[Product]"

            Select Case cbo_Product.Text.Substring(0, 3)
                Case "DCT", "FTR", "FTL", "PCT"
                    strSQL += vbCrLf & "     desc "
                Case Else
            End Select

            strSQL += vbCrLf & "       ,[ProductCCY]"
            strSQL += vbCrLf & "       ,[ChargesDefinedFor]"
            strSQL += vbCrLf & "       ,[ChargeCategory]"
            strSQL += vbCrLf & "       ,[Event]"

            conn.SetGrid(strSQL, grd_unit)

            For i = 0 To grd_unit.Columns.Count - 1
                grd_unit.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

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


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '   MDI_Frm.ChargeUnitToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub btn_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print.Click
        Try
            If txt_Template.Text = "" Then
                MessageBox.Show("Invalid Template Code. Please selection Template code.")
                Exit Sub
            End If

            Dim mFrmPrint_InputDescription As New FrmPrint_InputDescription
            mFrmPrint_InputDescription.txt_clientcode.Text = txt_Deal_ID.Text
            mFrmPrint_InputDescription.txt_template_code.Text = txt_Template.Text
            mFrmPrint_InputDescription.strReportName = "charge"

            ' If Not (opt_AdviceFaxRequired_Yes.Checked = True Or opt_AdviceEmailRequired_Yes.Checked = True) Then
            mFrmPrint_InputDescription.strWarnning = ""
            '  End If

            mFrmPrint_InputDescription.ShowDialog()

            'Dim FrmReport2 As New FrmReport
            'FrmReport2.ReportType = "TemplateChageUnit"
            'FrmReport2.strSQL_PRD_Template = "SELECT * FROM PRD_Template WHERE   TemplateCode = '" & txt_Template.Text & "'   order by TemplateCode"
            'FrmReport2.strSQL1 = "SELECT * FROM PRD_TemplateChargeEvents where TemplateCode = '" & txt_Template.Text & "'   order by TemplateCode,Product"
            'FrmReport2.strSQL2 = "SELECT * FROM PRD_TemplateChargeUnits where TemplateCode = '" & txt_Template.Text & "' order by  TemplateCode,Product,Event "
            'FrmReport2.ShowDialog()


            'Dim mFrmReport_Muti As New FrmReport_Muti
            'mFrmReport_Muti.strSQL1 = "select * from dbo.PRD_TemplateChargeEvents where TemplateCode = '" & txt_Template.Text & "'  order by [TemplateCode],[Product],[ProductCCY],[Event]"
            'mFrmReport_Muti.strSQL2 = "select * from dbo.PRD_TemplateChargeUnits where TemplateCode = '" & txt_Template.Text & "'   order by TemplateCode,Class,Product,Event,ChargeUnitCode "
            'mFrmReport_Muti.ShowDialog()
            If IS_RETURN = True Then
                OBJ_COMBOBOX.Text = txt_Template.Text
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_create.Click
        ''If txt_Template.Text = "" Then
        ''    MessageBox.Show("Invalid Template Code. Please selection Template code.")
        ''    Exit Sub
        ''End If
        ''Dim mFrm_TemplateChargeUnit_list_pre_entry As New Frm_TemplateChargeUnit_list_pre_entry
        ''mFrm_TemplateChargeUnit_list_pre_entry.strMODE = "ADD"
        ''mFrm_TemplateChargeUnit_list_pre_entry.txt_new_template.Text = ""
        ''mFrm_TemplateChargeUnit_list_pre_entry.txt_CopyFromTemplate.Text = txt_Template.Text
        ''mFrm_TemplateChargeUnit_list_pre_entry.ShowDialog()

    End Sub

    Private Sub Frm_TemplateChargeUnit_list_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        TabControl1.Visible = False
    End Sub

    Private Sub Frm_TemplateChargeUnit_list_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        On Error Resume Next
        'GroupBox1.Width = Me.Width - 30
        grd_Event.Width = Me.Width - 30
        grd_unit.Width = Me.Width - 30
        grd_unit.Height = (Panel1.Top - (grd_unit.Top)) - 20

    End Sub

    Private Sub btn_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Find.Click
        Call RefreshDataList()
    End Sub

    Private Sub RefreshDataList()
        txt_Template.Text = ""
        Call UpGrid_Template()
        TabControl1.Visible = False
    End Sub

    Private Sub grd_Template_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd_Template.CellMouseClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            Call SetGrid()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub SetGrid()
        Dim strTemplateCode As String
        strTemplateCode = grd_Template.CurrentRow.Cells(0).Value
        txt_Template.Text = strTemplateCode
        Call UpGrid_Template_EventsAndUnit(strTemplateCode)
    End Sub

    Private Sub txt_Template_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Template.TextChanged

    End Sub


    Private Sub btn_more_criteria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_more_criteria.Click
        '373, 102
        TabControl1.Location = New System.Drawing.Point(373, 102)

        TabControl1.Visible = Not TabControl1.Visible
        If TabControl1.Visible = False Then
            btn_more_criteria.Text = "More Criteria ..."
        Else
            btn_more_criteria.Text = "(Close) More Criteria ..."
        End If
    End Sub



    Private Sub cbo_Product_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_Product.Validated
        cbo_product_event.Text = cbo_Product.Text
        cbo_product_unit.Text = cbo_Product.Text
        Call SetCombo()
        'Call UpGrid_Template()
    End Sub

    Private Sub grd_Template_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd_Template.GotFocus
        TabControl1.Visible = False
    End Sub


    Private Sub grd_Event_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd_Event.GotFocus
        TabControl1.Visible = False
    End Sub


    Private Sub grd_unit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd_unit.GotFocus
        TabControl1.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TabControl1.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TabControl1.Visible = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TabControl1.Visible = False
    End Sub



    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click
        Try
            If txt_Template.Text = "" Then Exit Sub
            If MsgBox("Do you want to delete?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then Exit Sub
            Dim strSQL As String = ""

            strSQL = ""
            strSQL += " delete from dbo.PRD_TemplateChargeEvents where TemplateCode='" & txt_Template.Text.Replace("'", "''") & "' " & vbCrLf
            strSQL += " delete from dbo.PRD_TemplateChargeUnits where TemplateCode='" & txt_Template.Text.Replace("'", "''") & "' " & vbCrLf
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

    Private Sub cbo_ComputationBasis_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_ComputationBasis.Validated
        Call SetCaptionComputationBasis()
    End Sub

    Private Sub SetCaptionComputationBasis()
        lbComputeBasis.Text = "PerUnit Charge" & vbCrLf & " Or " & "Basis Point"
        lbComputeBasis.Location = New System.Drawing.Point(361, 0)
        If cbo_ComputationBasis.Text <> "" And cbo_ComputationBasis.Text <> strALL Then
            lbComputeBasis.Location = New System.Drawing.Point(361, 15)
            If cbo_ComputationBasis.Text.ToUpper = "Count-Based".ToUpper Then
                lbComputeBasis.Text = "PerUnit Charge"
            Else
                lbComputeBasis.Text = "Basis Point"
            End If
        End If
    End Sub

    Private Sub cbo_Product_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Product.SelectedIndexChanged
        Call SetScreenByProduct()
    End Sub

    Private Sub SetScreenByProduct()

        ' chk_compute_basis_two_leg.Visible = False
        'If cbo_Product.Text.Substring(0, 3) = "DCT" Then
        '    chk_compute_basis_two_leg.Visible = True
        '    chk_compute_basis_two_leg.Checked = False
        'End If

        grp_bne.Visible = False
        grp_Tab_slab.Visible = False
        grp_Tab_two.Visible = False
        grp_tab_one.Visible = False
        btn_Find.Enabled = False
        pnl_defer.Enabled = False
        btn_more_criteria.Enabled = False

        chk_compute_basis_bne.Enabled = True

        grp_Tab_slab.Location = grp_bne.Location
        grp_Tab_two.Location = grp_bne.Location
        grp_tab_one.Location = grp_bne.Location

        ' lb_cbo_diff_2.Visible = False
        ' cbo_diff_2.Visible = False
        ' cbo_diff_2.Text = "0"

        If cbo_Product.Text.Substring(0, 3) = "FTR" Or cbo_Product.Text.Substring(0, 3) = "FTL" Then
            '    lb_cbo_diff_2.Visible = True
            '   cbo_diff_2.Visible = True
        End If



        If cbo_Product.Text = "" Or cbo_Product.Text = strALL Then Exit Sub


        pnl_defer.Enabled = True
        btn_more_criteria.Enabled = True
        btn_Find.Enabled = True
        Dim strSQL As String = ""
        'rad_defer_y
        If cbo_Product.Text.Substring(0, 3) = "PCL" Then
            rad_defer_y.Checked = True
            Call Set_txt_PostingDay_crit()
        End If

        Select Case cbo_Product.Text.Substring(0, 3)
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

                '================same------------
                strSQL = "select BasisPoints1 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_Product.Text.Substring(0, 3) & "SMZONE'"
                cbo_same.Text = conn.GetDataFromSQL(strSQL, 0)
                If cbo_same.Text = "" Then cbo_same.Text = "0"

                strSQL = "select ApplyMinchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_Product.Text.Substring(0, 3) & "SMZONE'"
                txt_ApplyMinchgAmount_same.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMinchgAmount_same.Text = "" Then txt_ApplyMinchgAmount_same.Text = "0"

                strSQL = "select ApplyMaxchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_Product.Text.Substring(0, 3) & "SMZONE'"
                txt_ApplyMaxchgAmount_same.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMaxchgAmount_same.Text = "" Then txt_ApplyMaxchgAmount_same.Text = "0"

                '================diff------------
                If cbo_Product.Text.Substring(0, 3) = "FTR" Then
                    cbo_same.Text = "0" : cbo_same.Enabled = False
                    txt_ApplyMinchgAmount_same.Text = "0" : txt_ApplyMinchgAmount_same.Enabled = False
                    txt_ApplyMaxchgAmount_same.Text = "0" : txt_ApplyMaxchgAmount_same.Enabled = False
                Else
                    cbo_same.Enabled = True
                    txt_ApplyMinchgAmount_same.Enabled = True
                    txt_ApplyMaxchgAmount_same.Enabled = True
                End If


                If cbo_Product.Text.Substring(0, 3) = "FTR" Or cbo_Product.Text.Substring(0, 3) = "FTL" Then
                    'ftr,ftl
                    chk_compute_basis_two_leg.Checked = True
                    ''chk_compute_basis_two_leg.Enabled = False

                    'strSQL = "select FixedAmount1 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_Product.Text.Substring(0, 3) & "DFZONE'"
                    'cbo_diff.Text = conn.GetDataFromSQL(strSQL, 0)
                    'If cbo_diff.Text = "" Then cbo_diff.Text = "0"

                    strSQL = "select isnull(BasisPoints1,0) * 10.00 as BasisPoints1 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_Product.Text.Substring(0, 3) & "DFZONE'"
                    cbo_diff.Text = conn.GetDataFromSQL(strSQL, 0)
                    If cbo_diff.Text = "" Then cbo_diff.Text = "0"
                Else
                    'pcl
                    chk_compute_basis_two_leg.Checked = False
                    ''chk_compute_basis_two_leg.Enabled = True
                    strSQL = "select BasisPoints1 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_Product.Text.Substring(0, 3) & "DFZONE'"
                    cbo_diff.Text = conn.GetDataFromSQL(strSQL, 0)
                    If cbo_diff.Text = "" Then cbo_diff.Text = "0"
                    'cbo_diff_2.Text = "0"

                End If


                strSQL = "select ApplyMinchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_Product.Text.Substring(0, 3) & "DFZONE'"
                txt_ApplyMinchgAmount_diff.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMinchgAmount_diff.Text = "" Then txt_ApplyMinchgAmount_diff.Text = "0"

                strSQL = "select ApplyMaxchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_Product.Text.Substring(0, 3) & "DFZONE'"
                txt_ApplyMaxchgAmount_diff.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMaxchgAmount_diff.Text = "" Then txt_ApplyMaxchgAmount_diff.Text = "0"

            Case "MCL", "MCS", "PCL"
                grp_bne.Visible = False
                grp_Tab_slab.Visible = True
                grp_Tab_two.Visible = False
                grp_tab_one.Visible = False

                strSQL = "select FixedAmount1,FixedAmount2,FixedAmount3 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001'  "

                cbo_tier1.Text = conn.GetDataFromSQL(strSQL, 0)
                If cbo_tier1.Text = "" Then cbo_tier1.Text = "0"

                cbo_tier2.Text = conn.GetDataFromSQL(strSQL, 1)
                If cbo_tier2.Text = "" Then cbo_tier2.Text = "0"

                cbo_tier3.Text = conn.GetDataFromSQL(strSQL, 2)
                If cbo_tier3.Text = "" Then cbo_tier3.Text = "0"

                strSQL = "select ApplyMinchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_Product.Text.Substring(0, 3) & "DFZONE'"
                txt_ApplyMinchgAmount_t1.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMinchgAmount_t1.Text = "" Then txt_ApplyMinchgAmount_t1.Text = "0"

                strSQL = "select ApplyMaxchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001' and   product='" & cbo_Product.Text.Substring(0, 3) & "DFZONE'"
                txt_ApplyMaxchgAmount_t1.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMaxchgAmount_t1.Text = "" Then txt_ApplyMaxchgAmount_t1.Text = "0"


            Case "COC", "COE"
                grp_bne.Visible = False
                grp_Tab_slab.Visible = False
                grp_Tab_two.Visible = False
                grp_tab_one.Visible = True

                strSQL = "select BasisPoints1 from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001'  "
                cbo_ChargeAmount.Text = conn.GetDataFromSQL(strSQL, 0)
                If cbo_ChargeAmount.Text = "" Then cbo_ChargeAmount.Text = "0"

                strSQL = "select ApplyMinchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001' and   product like '" & cbo_Product.Text.Substring(0, 3) & "%'"
                txt_ApplyMinchgAmount_one.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMinchgAmount_one.Text = "" Then txt_ApplyMinchgAmount_one.Text = "0"

                strSQL = "select ApplyMaxchgAmount from dbo.PRD_TemplateChargeUnits u  where TemplateCode like '" & cbo_Product.Text.Substring(0, 3) & "CG00001' and   product like '" & cbo_Product.Text.Substring(0, 3) & "%'"
                txt_ApplyMaxchgAmount_one.Text = conn.GetDataFromSQL(strSQL, 0)
                If txt_ApplyMaxchgAmount_one.Text = "" Then txt_ApplyMaxchgAmount_one.Text = "0"


            Case Else
        End Select

    End Sub


    Private Sub rad_defer_y_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_defer_y.CheckedChanged
        Call Set_txt_PostingDay_crit()
    End Sub

    Private Sub rad_defer_n_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_defer_n.CheckedChanged
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


    Private Sub btnPrint_Detail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint_Detail.Click
        Try
            If txt_Template.Text = "" Then
                MessageBox.Show("Invalid Template Code. Please selection Template code.")
                Exit Sub
            End If

            Dim FrmReport2 As New FrmReport
            FrmReport2.ReportType = "TemplateChageUnit"
            FrmReport2.strSQL_PRD_Template = "SELECT * FROM PRD_Template WHERE   TemplateCode = '" & txt_Template.Text & "'   order by TemplateCode"
            FrmReport2.strSQL1 = "SELECT * FROM PRD_TemplateChargeEvents where TemplateCode = '" & txt_Template.Text & "'   order by TemplateCode,Product"
            FrmReport2.strSQL2 = "SELECT * FROM PRD_TemplateChargeUnits where TemplateCode = '" & txt_Template.Text & "' order by  TemplateCode,Product,Event "

            FrmReport2.strLine(0) = txt_Deal_ID.Text
            FrmReport2.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub



    Private Sub cbo_diff_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_diff.Validated
        'If IsNumeric(cbo_diff.Text) And IsNumeric(cbo_diff_2.Text) Then
        '    If CDbl(cbo_diff.Text) = 0 And CDbl(cbo_diff_2.Text) = 0 Then
        '        txt_ApplyMinchgAmount_diff.Text = "0"
        '        txt_ApplyMaxchgAmount_diff.Text = "0"
        '    End If
        'End If
    End Sub



    Private Sub cbo_same_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_same.Validated
        If cbo_same.Text = "" Or cbo_same.Text = "0" Then
            txt_ApplyMinchgAmount_same.Text = "0"
            txt_ApplyMaxchgAmount_same.Text = "0"
        End If
    End Sub



    Private Sub cbo_diff_2_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        'If IsNumeric(cbo_diff.Text) And IsNumeric(cbo_diff_2.Text) Then
        '    If CDbl(cbo_diff.Text) = 0 And CDbl(cbo_diff_2.Text) = 0 Then
        '        txt_ApplyMinchgAmount_diff.Text = "0"
        '        txt_ApplyMaxchgAmount_diff.Text = "0"
        '    End If
        'End If
    End Sub

    Private Sub btn_print_zero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print_zero.Click

        'If txt_Template.Text = "" Then
        '    MessageBox.Show("Invalid Template Code. Please selection Template code.")
        '    Exit Sub
        'End If

        Dim mFrmPrint_InputDescription As New FrmPrint_InputDescription
        mFrmPrint_InputDescription.txt_clientcode.Text = txt_Deal_ID.Text
        mFrmPrint_InputDescription.txt_template_code.Text = "" ' txt_Template.Text
        mFrmPrint_InputDescription.strReportName = "charge"

        ' If Not (opt_AdviceFaxRequired_Yes.Checked = True Or opt_AdviceEmailRequired_Yes.Checked = True) Then
        mFrmPrint_InputDescription.strWarnning = "Zero or fee monthly charging."
        '  End If

        mFrmPrint_InputDescription.ShowDialog()
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
        Dim strTemplate As String = ""
        Dim strSQL As String = ""
        strSQL = "SELECT top 1 [TemplateCode] FROM [PRD_TemplateChargeEvents] "
        strSQL += " where Product='" & cbo_Product.Text.Substring(0, 3).Replace("'", "''") & "' ORDER BY [TemplateCode] "

        strTemplate = conn.GetDataFromSQL(strSQL)

        Dim mFrm_TemplateChargeUnit_Wizard As New Frm_TemplateChargeUnit_Wizard
        ' mFrm_TemplateChargeUnit_Wizard.txt_new_template.Text = txt_new_template.Text
        mFrm_TemplateChargeUnit_Wizard.txt_CopyFromTemplate.Text = strTemplate 'cbo_Template.Text
        mFrm_TemplateChargeUnit_Wizard.strProduct = cbo_Product.Text

        ' mFrm_TemplateChargeUnit_Wizard.cbo_product.Enabled = False
        mFrm_TemplateChargeUnit_Wizard.txt_return = txt_Return
        mFrm_TemplateChargeUnit_Wizard.bNewFlag = True

        Call mFrm_TemplateChargeUnit_Wizard.SetScreenByProduct()
        mFrm_TemplateChargeUnit_Wizard.ShowDialog()

        If txt_Return.Text <> "" Then
            OBJ_COMBOBOX.Text = txt_Return.Text
            txt_charge_template_new.Text = txt_Return.Text
            Me.Close()
        End If

    End Sub

End Class