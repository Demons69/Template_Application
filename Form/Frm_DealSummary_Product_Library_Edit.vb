Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_DealSummary_Product_Library_Edit

    Dim conn As CSQL

    Public strID As String = ""
    Public strMODE As String = "ADD"

    Private Sub Frm_DealSummary_Product_Library_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        conn = New CSQL
        conn.Connect()
        Dim strSQL As String = ""
        Call FillCombo()

        If strMODE.ToUpper <> "ADD" Then
            Call ShowData()
        Else
            'Dim strSQL_data As String = ""
            'Dim strData As String = ""
            'strSQL_data = "select max(product_id) from dbo.TB_FEE_CHARGING"
            'strData = conn.GetDataFromSQL(strSQL_data)
            'If IsNumeric(strData) = True Then
            '    txt_Product_ID.Text = Format(CDbl(strData) + 1, "00000")

            'End If
        End If
    End Sub

    Private Sub FillCombo()

        '===================
        cbo_UDEPRODUCT.Items.Clear()
        cbo_UDEPRODUCT.Items.Add("UDEBNE")
        cbo_UDEPRODUCT.Items.Add("UDECOC")
        cbo_UDEPRODUCT.Items.Add("UDECOE")
        cbo_UDEPRODUCT.Items.Add("UDEDCT")
        cbo_UDEPRODUCT.Items.Add("UDEFTL")
        cbo_UDEPRODUCT.Items.Add("UDEFTR")
        cbo_UDEPRODUCT.Items.Add("UDEMCS")
        cbo_UDEPRODUCT.Items.Add("UDEMCL")
        cbo_UDEPRODUCT.Items.Add("UDEPCT")
        cbo_UDEPRODUCT.Items.Add("UDEPCL")
        cbo_UDEPRODUCT.Items.Add("")

        cbo_PRODUCT_CODE.Items.Clear()
        cbo_PRODUCT_CODE.Items.Add("BNE")
        cbo_PRODUCT_CODE.Items.Add("COC")
        cbo_PRODUCT_CODE.Items.Add("COE")
        cbo_PRODUCT_CODE.Items.Add("DCT")
        cbo_PRODUCT_CODE.Items.Add("FTL")
        cbo_PRODUCT_CODE.Items.Add("FTR")
        cbo_PRODUCT_CODE.Items.Add("MCS")
        cbo_PRODUCT_CODE.Items.Add("MCL")
        cbo_PRODUCT_CODE.Items.Add("PCT")
        cbo_PRODUCT_CODE.Items.Add("PCL")
        cbo_PRODUCT_CODE.Items.Add("")
        'cbo_arrangement
        cbo_ARRANGEMENT_CODE.Items.Clear()
        cbo_ARRANGEMENT_CODE.Items.Add("D+0")
        cbo_ARRANGEMENT_CODE.Items.Add("D-1")
        cbo_ARRANGEMENT_CODE.Items.Add("D-2")
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [TB_BANK_PRODUCT_LIBRARY] WHERE [MYPRODUCT] ='" + strID + "'"
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()
            txt_MYPRODUCT.Text = IIf(res("MYPRODUCT") Is System.DBNull.Value, "", res("MYPRODUCT").ToString())
            txt_MYPRODUCT_DESCRIPTION.Text = IIf(res("MYPRODUCT_DESCRIPTION") Is System.DBNull.Value, "", res("MYPRODUCT_DESCRIPTION").ToString())
            txt_MYPRODUCT_REMARK.Text = IIf(res("MYPRODUCT_REMARK") Is System.DBNull.Value, "", res("MYPRODUCT_REMARK").ToString())
            cbo_UDEPRODUCT.Text = IIf(res("UDEPRODUCT") Is System.DBNull.Value, "", res("UDEPRODUCT").ToString())
            cbo_PRODUCT_CODE.Text = IIf(res("PRODUCT_CODE") Is System.DBNull.Value, "", res("PRODUCT_CODE").ToString())
            txt_PRODUCT_DESCRIPTION.Text = IIf(res("PRODUCT_DESCRIPTION") Is System.DBNull.Value, "", res("PRODUCT_DESCRIPTION").ToString())
            cbo_ARRANGEMENT_CODE.Text = IIf(res("ARRANGEMENT_CODE") Is System.DBNull.Value, "", res("ARRANGEMENT_CODE").ToString())
            txt_DAYS_PERIOD.Text = IIf(res("DAYS_PERIOD") Is System.DBNull.Value, "", res("DAYS_PERIOD").ToString())
            txt_PER_TXN_MAX_AMNT.Text = IIf(res("PER_TXN_MAX_AMNT") Is System.DBNull.Value, "", res("PER_TXN_MAX_AMNT").ToString())
            txt_PER_TXN_MAX_AMNT.Text = CDbl(txt_PER_TXN_MAX_AMNT.Text).ToString("###,##0.00")

            txt_RULE_PRIORITY.Text = IIf(res("RULE_PRIORITY") Is System.DBNull.Value, "", res("RULE_PRIORITY").ToString())
            txt_RULE_CODE.Text = IIf(res("RULE_CODE") Is System.DBNull.Value, "", res("RULE_CODE").ToString())


            txt_MYPRODUCT.Enabled = False
            cbo_UDEPRODUCT.Enabled = False
            cbo_PRODUCT_CODE.Enabled = False

        End If
        res.Close()
        res = Nothing

    End Sub

    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click
        Dim strErr As String = ""
        strErr = ValidationData()
        If strErr <> "" Then
            MessageBox.Show(strErr)
            Exit Sub
        End If

        Call SaveData()
    End Sub

    Private Sub SaveData()
        Try
        


            conn = New CSQL
            conn.Connect()
            Dim strSQL As String = ""
            '========================add mode====================
            If strMODE.ToUpper = "ADD" Then

                strSQL = "SELECT * FROM [TB_BANK_PRODUCT_LIBRARY] "
                strSQL += vbCrLf & " WHERE  "
                strSQL += vbCrLf & "  [MYPRODUCT] ='" + txt_MYPRODUCT.Text.Replace("'", "''") + "'"
                strSQL += vbCrLf & " and  [UDEPRODUCT] ='" + cbo_UDEPRODUCT.Text.Replace("'", "''") + "'"
                strSQL += vbCrLf & " AND [PRODUCT_CODE] ='" + cbo_PRODUCT_CODE.Text.Replace("'", "''") + "'"

                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid [myproduct+ude+bank product] is duplicate.")
                    Exit Sub
                End If

                strSQL = "SELECT * FROM [TB_BANK_PRODUCT_LIBRARY] "
                strSQL += vbCrLf & " WHERE [MYPRODUCT] ='" + txt_MYPRODUCT.Text.Replace("'", "''") + "'"
                strSQL += vbCrLf & " AND [UDEPRODUCT] ='" + cbo_UDEPRODUCT.Text.Replace("'", "''") + "'"
                strSQL += vbCrLf & " AND [PRODUCT_CODE] ='" + cbo_PRODUCT_CODE.Text.Replace("'", "''") + "'"

                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid [My Product+ude+bank product] is duplicate.")
                    Exit Sub
                End If

                Dim strValue As String = ""
                Dim strFiledname As String = ""

                strFiledname += vbCrLf & "[MYPRODUCT]"
                strValue += vbCrLf & "N'" & txt_MYPRODUCT.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[MYPRODUCT_DESCRIPTION]"
                strValue += vbCrLf & ",N'" & txt_MYPRODUCT_DESCRIPTION.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[MYPRODUCT_REMARK]"
                strValue += vbCrLf & ",N'" & txt_MYPRODUCT_REMARK.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[UDEPRODUCT]"
                strValue += vbCrLf & ",N'" & cbo_UDEPRODUCT.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[PRODUCT_CODE]"
                strValue += vbCrLf & ",N'" & cbo_PRODUCT_CODE.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[PRODUCT_DESCRIPTION]"
                strValue += vbCrLf & ",N'" & txt_PRODUCT_DESCRIPTION.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[ARRANGEMENT_CODE]"
                strValue += vbCrLf & ",N'" & cbo_ARRANGEMENT_CODE.Text.Replace("'", "''") & "'"

                'txt_DAYS_PERIOD
                strFiledname += vbCrLf & ",[DAYS_PERIOD]"
                strValue += vbCrLf & ",N'" & txt_DAYS_PERIOD.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[PER_TXN_MAX_AMNT]"
                strValue += vbCrLf & "," & CDbl(txt_PER_TXN_MAX_AMNT.Text.Replace(",", "")) & " "

                strFiledname += vbCrLf & ",[RULE_PRIORITY]"
                strValue += vbCrLf & ", " & CDbl(txt_RULE_PRIORITY.Text.Replace("'", "''")) & " "

                strFiledname += vbCrLf & ",[RULE_CODE]"
                strValue += vbCrLf & ",N'" & txt_RULE_CODE.Text.Replace("'", "''") & "'"


                strSQL = ""
                strSQL += vbCrLf & "insert into [TB_BANK_PRODUCT_LIBRARY]"
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper <> "ADD" Then


            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then

                'strSQL = "SELECT * FROM [TB_BANK_PRODUCT_LIBRARY] "
                'strSQL += vbCrLf & " WHERE [MYPRODUCT] ='" + txt_MYPRODUCT.Text.Replace("'", "''") + "'"
                'strSQL += vbCrLf & " AND [UDEPRODUCT] ='" + cbo_UDEPRODUCT.Text.Replace("'", "''") + "'"
                'strSQL += vbCrLf & " AND [PRODUCT_CODE] ='" + cbo_PRODUCT_CODE.Text.Replace("'", "''") + "'"

                'If conn.HasRows(strSQL) = True Then
                '    MessageBox.Show("Invalid [Bank Product] is duplicate.")
                '    Exit Sub
                'End If

                strSQL = ""
                strSQL += vbCrLf & "update [TB_BANK_PRODUCT_LIBRARY]  set "


                strSQL += vbCrLf & "[MYPRODUCT_DESCRIPTION]"
                strSQL += vbCrLf & "=N'" & txt_MYPRODUCT_DESCRIPTION.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[MYPRODUCT_REMARK]"
                strSQL += vbCrLf & "=N'" & txt_MYPRODUCT_REMARK.Text.Replace("'", "''") & "'"



                strSQL += vbCrLf & ",[PRODUCT_DESCRIPTION]"
                strSQL += vbCrLf & "=N'" & txt_PRODUCT_DESCRIPTION.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[ARRANGEMENT_CODE]"
                strSQL += vbCrLf & "=N'" & cbo_ARRANGEMENT_CODE.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[DAYS_PERIOD]"
                strSQL += vbCrLf & "=N'" & txt_DAYS_PERIOD.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[PER_TXN_MAX_AMNT]"
                strSQL += vbCrLf & "=" & CDbl(txt_PER_TXN_MAX_AMNT.Text.Replace(",", "")) & " "

                strSQL += vbCrLf & ",[RULE_PRIORITY]"
                strSQL += vbCrLf & " = " & CDbl(txt_RULE_PRIORITY.Text.Replace("'", "''")) & " "

                strSQL += vbCrLf & ",[RULE_CODE]"
                strSQL += vbCrLf & " = N'" & txt_RULE_CODE.Text.Replace("'", "''") & "'"




                strSQL += vbCrLf & " WHERE [MYPRODUCT] ='" + txt_MYPRODUCT.Text.Replace("'", "''") + "'"
                strSQL += vbCrLf & " AND [UDEPRODUCT] ='" + cbo_UDEPRODUCT.Text.Replace("'", "''") + "'"
                strSQL += vbCrLf & " AND [PRODUCT_CODE] ='" + cbo_PRODUCT_CODE.Text.Replace("'", "''") + "'"




                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper <> "ADD" Then

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""

        If txt_MYPRODUCT.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [My Product Code]"
        End If
        If txt_MYPRODUCT_DESCRIPTION.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [My Product Name]"
        End If
        If txt_MYPRODUCT_REMARK.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [My Product Remark]"
        End If
        If cbo_UDEPRODUCT.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [UDE Product]"
        End If
        If cbo_PRODUCT_CODE.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Bank Product]"
        End If
        If txt_PRODUCT_DESCRIPTION.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Bank Product Description]"
        End If

        If cbo_ARRANGEMENT_CODE.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Arrangement]"
        End If

        If txt_DAYS_PERIOD.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Days Period]"
        Else
            If IsNumeric(txt_DAYS_PERIOD.Text) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Days Period]"
            End If
        End If

        If txt_PER_TXN_MAX_AMNT.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Per Txn Max Amt]"
        Else
            If IsNumeric(txt_PER_TXN_MAX_AMNT.Text) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Per Txn Max Amt]"
            End If
        End If

        If txt_RULE_PRIORITY.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rule Priority]"
        Else
            If IsNumeric(txt_RULE_PRIORITY.Text) = False Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rule Priority]"
            End If
        End If

        If txt_RULE_CODE.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Rule Code]"
        End If

        Return strErr
    End Function

    Private Function Is_date(ByVal strData As String) As Boolean
        Try
            Is_date = True


            If strData = "" Then Exit Function

            Dim strtmp As String = ""
            If UBound(strData.Split("/")) = 2 Then
                strtmp = strData.Split("/")(2) & "/" & strData.Split("/")(1) & "/" & strData.Split("/")(0)
            Else
                Is_date = False : Exit Function
            End If

            If IsDate(strtmp) = False Then
                Is_date = False : Exit Function
            End If

        Catch ex As Exception

        End Try
    End Function

    Private Sub txt_MYPRODUCT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MYPRODUCT.Validated
        txt_MYPRODUCT.Text = txt_MYPRODUCT.Text.ToUpper

        If txt_MYPRODUCT.Text <> "" Then
            Dim strSQL As String = ""
            strSQL = "SELECT * FROM [TB_BANK_PRODUCT_LIBRARY] "
            strSQL += vbCrLf & " WHERE [MYPRODUCT] ='" + txt_MYPRODUCT.Text.Replace("'", "''") + "'"

            Dim res As SqlDataReader
            ' Dim strSQL As String = ""
            ' strSQL = "SELECT * FROM [TB_BANK_PRODUCT_LIBRARY] WHERE [MYPRODUCT] ='" + strID + "'"
            res = conn.GetDataReader(strSQL)

            If res.HasRows = True Then
                res.Read()
                txt_MYPRODUCT_DESCRIPTION.Text = IIf(res("MYPRODUCT_DESCRIPTION") Is System.DBNull.Value, "", res("MYPRODUCT_DESCRIPTION").ToString())
                cbo_UDEPRODUCT.Text = IIf(res("UDEPRODUCT") Is System.DBNull.Value, "", res("UDEPRODUCT").ToString())
                txt_MYPRODUCT_REMARK.Text = IIf(res("MYPRODUCT_REMARK") Is System.DBNull.Value, "", res("MYPRODUCT_REMARK").ToString())
                txt_MYPRODUCT_DESCRIPTION.Enabled = False
                cbo_UDEPRODUCT.Enabled = False
                txt_MYPRODUCT_REMARK.Enabled = False
                ' cbo_PRODUCT_CODE.Enabled = False
            Else
                txt_MYPRODUCT_REMARK.Enabled = True
                txt_MYPRODUCT_DESCRIPTION.Enabled = True
                cbo_UDEPRODUCT.Enabled = True
            End If
            res.Close()
            res = Nothing

        End If
       

    End Sub


    
    Private Sub txt_PER_TXN_MAX_AMNT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_PER_TXN_MAX_AMNT.TextChanged

    End Sub

    Private Sub txt_PER_TXN_MAX_AMNT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_PER_TXN_MAX_AMNT.Validated
        '  grd_product.Columns("Per Txn Max Amt").DefaultCellStyle.Format = "###,##0.00"
        ' grd_product.Columns("Per Txn Max Amt").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        If IsNumeric(txt_PER_TXN_MAX_AMNT.Text) = True Then
            txt_PER_TXN_MAX_AMNT.Text = CDbl(txt_PER_TXN_MAX_AMNT.Text).ToString("###,##0.00")
        End If

    End Sub
End Class