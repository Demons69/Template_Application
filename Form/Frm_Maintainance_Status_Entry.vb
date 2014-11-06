Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_Maintainance_Status_Entry
    Dim conn As CSQL

    Public strID As String = ""
    Public strMODE As String = "ADD"
    Private Const strALL = "--------Select--------"

    Private Const strSingleProduct = "Single-Product"
    Private Const strProductChare = "Product Charge"

    Private Sub Frm_Maintainance_Status_Entry_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub Frm_Maintainance_Status_Entry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_Maintainance_Status_Entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            conn = New CSQL
            conn.Connect()
            Dim strSQL As String = ""
            ' strSQL = "select distinct ProductCode from dbo.PRD_Template order by ProductCode"
            strSQL = conn.GetSQL_LIST_PRODUCT_MST

            conn.Fill_ComboBox(strSQL, cbo_ProductCode, strALL)
            cbo_ProductCode.Text = strALL

            If strMODE.ToUpper <> "ADD" Then
                Call ShowData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = "SELECT * FROM [PRD_Template] WHERE [TemplateCode] ='" + strID + "'"
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()

            If IIf(res("TemplateType") Is System.DBNull.Value, "", res("TemplateType").ToString()) = "Product Charge" Then
                rad_TemplateType_2.Checked = True
            Else
                rad_TemplateType_3.Checked = True
            End If

            cbo_ProductCode.Text = cbo_ProductCode.Items(cbo_ProductCode.FindString(IIf(res("ProductCode") Is System.DBNull.Value, "", res("ProductCode").ToString()))).ToString

            txt_TemplateCode.Text = IIf(res("TemplateCode") Is System.DBNull.Value, "", res("TemplateCode").ToString())
            txt_TemplateFullName.Text = IIf(res("TemplateFullName") Is System.DBNull.Value, "", res("TemplateFullName").ToString())

            cbo_ProductCode.Enabled = False
            txt_TemplateCode.Enabled = False
            rad_TemplateType_2.Enabled = False
            rad_TemplateType_3.Enabled = False

            If IIf(res("StatusTemplate") Is System.DBNull.Value, "", res("StatusTemplate").ToString()) = "Y" Then
                rad_StatusTemplate_2.Checked = True
            Else
                rad_StatusTemplate_3.Checked = True
            End If

        End If
        res.Close()
        res = Nothing

    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
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
                strSQL = "SELECT * FROM [PRD_Template] WHERE [TemplateCode] ='" + txt_TemplateCode.Text.Replace("'", "''") + "'"
                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid Template Code is duplicate.")
                    Exit Sub
                End If

                Dim strValue As String = ""
                Dim strFiledname As String = ""

                strFiledname += vbCrLf & "[TemplateCode]"
                strValue += vbCrLf & "'" & txt_TemplateCode.Text.Replace("'", "''") & "'"

                strFiledname += ",[TemplateType]"
                If rad_TemplateType_2.Checked Then
                    strValue += vbCrLf & ",'" & strSingleProduct & "'"
                Else
                    strValue += vbCrLf & ",'" & strProductChare & "'"
                End If

                strFiledname += vbCrLf & ",[TemplateFullName]"
                strValue += vbCrLf & ",'" & txt_TemplateFullName.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[TemplateEffectiveFrom]"
                strValue += vbCrLf & ",''"

                strFiledname += ",[ProductCode]"
                strValue += vbCrLf & ",'" & cbo_ProductCode.Text.Substring(0, 3).Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[Remarks]"
                strValue += vbCrLf & ",''"

                strFiledname += ",[StatusTemplate]"
                If rad_StatusTemplate_2.Checked Then
                    strValue += vbCrLf & ",'Y'"
                Else
                    strValue += vbCrLf & ",'N'"
                End If

                strFiledname += ",[maintain_flag]"
                strValue += vbCrLf & ",'Y'"


                strSQL = ""
                strSQL += vbCrLf & "insert into [PRD_Template]"
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper = "ADD" Then
            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [PRD_Template] set "

                strSQL += vbCrLf & "[TemplateFullName]"
                strSQL += vbCrLf & " = '" & txt_TemplateFullName.Text.Replace("'", "''") & "'"

                strSQL += ",[StatusTemplate]"
                If rad_StatusTemplate_2.Checked Then
                    strSQL += vbCrLf & " = 'Y'"
                Else
                    strSQL += vbCrLf & " = 'N'"
                End If

                strSQL += vbCrLf & " WHERE [TemplateCode] ='" + txt_TemplateCode.Text.Replace("'", "''") + "'"
                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper <> "ADD" Then

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""

        If cbo_ProductCode.Text = "" Or cbo_ProductCode.Text = strALL Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Product]"
        End If

        If txt_TemplateCode.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Template Code]"
        End If

        If txt_TemplateFullName.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Template Full Name]"
        End If

        Return strErr
    End Function

    Private Sub cbo_ProductCode_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_ProductCode.SelectedValueChanged
        Call AutoLastNumber()
    End Sub

    Private Sub AutoLastNumber()
        Try
            Dim strTemplateType As String = ""
            Dim strSQL As String = ""

            If cbo_ProductCode.Text = "" Then Exit Sub

            If rad_TemplateType_2.Checked Then
                strTemplateType += strSingleProduct
            Else
                strTemplateType += strProductChare
            End If

            strSQL = "select max(TemplateCode) as TemplateCode from PRD_Template  "
            strSQL += " where ProductCode='" & cbo_ProductCode.Text.Substring(0, 3).Replace("'", "''") & "' "
            strSQL += " and TemplateType='" & strTemplateType.Replace("'", "''") & "' "

            Dim strValue As String = conn.GetDataFromSQL(strSQL)
            Dim intMax As Double

            If rad_TemplateType_2.Checked Then
                'product
                If strValue = "" Then
                    txt_TemplateCode.Text = cbo_ProductCode.Text.Substring(0, 3) & "P000001"
                    txt_TemplateFullName.Text = cbo_ProductCode.Text.Substring(0, 3) & " PRODUCT TEMPLATE 00001"
                Else
                    intMax = CDbl(strValue.Substring(strValue.Length - 6)) + 1
                    txt_TemplateCode.Text = cbo_ProductCode.Text.Substring(0, 3) & "P" & intMax.ToString("000000")
                    txt_TemplateFullName.Text = cbo_ProductCode.Text.Substring(0, 3) & " PRODUCT TEMPLATE " & intMax.ToString("00000")
                End If

            Else
                'charge
                If strValue = "" Then
                    txt_TemplateCode.Text = cbo_ProductCode.Text.Substring(0, 3) & "CG00001"
                    txt_TemplateFullName.Text = cbo_ProductCode.Text.Substring(0, 3) & " PRODUCT TEMPLATE 00001"
                Else
                    intMax = CDbl(strValue.Substring(strValue.Length - 5)) + 1
                    txt_TemplateCode.Text = cbo_ProductCode.Text.Substring(0, 3) & "CG" & intMax.ToString("00000")
                    txt_TemplateFullName.Text = cbo_ProductCode.Text.Substring(0, 3) & " CHARGE TEMPLATE " & intMax.ToString("00000")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub rad_TemplateType_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_TemplateType_2.CheckedChanged
        Call AutoLastNumber()
    End Sub

    Private Sub rad_TemplateType_3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad_TemplateType_3.CheckedChanged
        Call AutoLastNumber()
    End Sub

  
End Class