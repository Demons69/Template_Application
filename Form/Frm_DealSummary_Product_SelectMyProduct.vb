Imports Template_Application.CSQL
Imports System.Data.SqlClient


Public Class Frm_DealSummary_Product_SelectMyProduct

    Dim conn As New CSQL
    Public strID As String = ""
    ' Public cbo_ude_product As ComboBox
    ' Public cbo_bank_product As ComboBox
    ' Public txt_my_product As TextBox
    ' Public xFrm_DealSummary_Product As Frm_DealSummary_Product
    Public strMODE As String
    Dim is_first_time As Boolean = True
    Public bIsViewOnly As Boolean = False

    'Dim strSQL As String

    'Public Sub New(ByVal param As Frm_DealSummary_Product)

    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()
    '    xFrm_DealSummary_Product = param
    '    ' Add any initialization after the InitializeComponent() call.

    'End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub


    ''-- comment by tum; 7-aug-2014
    'Private Sub Frm_DealSummary_Product_SelectMyProduct_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    If is_first_time = False And strMODE = "ADD" Then
    '        If grd_data.RowCount > 0 Then
    '            MsgBox("All bank product muse be edited and saved.")
    '            e.Cancel = True
    '            Exit Sub
    '        End If
    '    End If
    'End Sub

    Private Sub Frm_DealSummary_Product_SelectMyProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New CSQL
        conn.Connect()

        Dim mFrm_LookupData As Frm_LookupData

        ' Dim strSQL As String = ""
        'mFrm_DealSummary_Product_SelectMyProduct = New Frm_DealSummary_Product_SelectMyProduct()
        Dim strSQL As String = ""

        If strMODE = "ADD" Then
            strSQL = ""
            strSQL += " select  distinct "
            strSQL += " [MYPRODUCT] AS [My Product Code]  "
            strSQL += " ,[MYPRODUCT_DESCRIPTION] AS [My Product Description] "
            strSQL += "  ,[MYPRODUCT_REMARK] AS [My Product Remark] "
            strSQL += "  ,[UDEPRODUCT] AS [UDE Product] "
            strSQL += "  from "
            strSQL += " [TB_BANK_PRODUCT_LIBRARY]  a "
            strSQL += "  order by MYPRODUCT ,UDEPRODUCT "
            'strSQL += "  a.company_id='" & txt_company_id.Text.Replace("'", "''") & "' "

            ' Frm_LookupData.Show()
            txt_temp.Text = ""
            mFrm_LookupData = New Frm_LookupData()
            mFrm_LookupData.SET_SQL = strSQL
            mFrm_LookupData.txtObject = txt_temp

            mFrm_LookupData.ShowDialog()


            If txt_temp.Text <> "" Then
                If UBound(Split(txt_temp.Text, "||")) = 3 Then

                    txt_MYPRODUCT.Text = Split(txt_temp.Text, "||")(0)
                    txt_MYPRODUCT_DESCRIPTION.Text = Split(txt_temp.Text, "||")(1)
                    txt_MYPRODUCT_REMARK.Text = Split(txt_temp.Text, "||")(2)
                    txt_UDEPRODUCT.Text = Split(txt_temp.Text, "||")(3)
                    Call ShowDataGrid()
                End If
            Else
                Me.Close()
            End If
        End If ' If strMODE = "ADD" Then


        If strMODE <> "ADD" Then
            Dim res As SqlDataReader
            strSQL = ""
            strSQL += " select  distinct "
            strSQL += " [MYPRODUCT]   "
            strSQL += " ,[MYPRODUCT_DESCRIPTION]  "
            strSQL += "  ,[MYPRODUCT_REMARK] "
            strSQL += "  ,[UDEPRODUCT]  "
            strSQL += "  from "
            strSQL += " [TB_BANK_PRODUCT_LIBRARY]  a "
            strSQL += " where MYPRODUCT ='" & txt_MYPRODUCT.Text.Replace("'", "''") & "'"
            strSQL += "  order by MYPRODUCT ,UDEPRODUCT "

            res = conn.GetDataReader(strSQL)

            If res.HasRows = True Then
                res.Read()
                txt_MYPRODUCT_DESCRIPTION.Text = IIf(res("MYPRODUCT_DESCRIPTION") Is System.DBNull.Value, "", res("MYPRODUCT_DESCRIPTION").ToString())
                txt_MYPRODUCT_REMARK.Text = IIf(res("MYPRODUCT_REMARK") Is System.DBNull.Value, "", res("MYPRODUCT_REMARK").ToString())
                txt_UDEPRODUCT.Text = IIf(res("UDEPRODUCT") Is System.DBNull.Value, "", res("UDEPRODUCT").ToString())

            End If
            res.Close()
            res = Nothing

            Call ShowDataGrid()
        End If '  If strMODE <> "ADD" Then


    End Sub

    Private Sub ShowDataGrid()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""

            strCrit = ""

            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            strSQL += vbCrLf & "  DISTINCT  [PRODUCT_CODE] AS [Bank Product Code] "
            strSQL += vbCrLf & "  ,[PRODUCT_DESCRIPTION] AS [Bank Product Description] "
            strSQL += vbCrLf & "   ,[ARRANGEMENT_CODE] AS [Arrangement] "
            strSQL += vbCrLf & "   ,[PER_TXN_MAX_AMNT] AS [Per Txn Max Amt] "
            strSQL += vbCrLf & "   ,[RULE_PRIORITY] AS [Rule Priority] "
            strSQL += vbCrLf & "    ,[RULE_CODE] AS [Rule Code] "
            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & " [TB_BANK_PRODUCT_LIBRARY] "
            strSQL += vbCrLf & " where MYPRODUCT='" & txt_MYPRODUCT.Text.Replace("'", "''") & "'"
            strSQL += vbCrLf & " and MYPRODUCT + PRODUCT_CODE "
            If strMODE = "ADD" Then
                strSQL += vbCrLf & " not in "
            Else
                strSQL += vbCrLf & "  in "
            End If
            strSQL += vbCrLf & " (select  my_product + bank_product   from    TB_DEAL_PRODUCT where company_id='" & txt_company_id.Text.Replace("'", "''") & "')"
            strSQL += vbCrLf & " ORDER BY  [PRODUCT_CODE],[PRODUCT_DESCRIPTION] "

            Call conn.SetGrid(strSQL, grd_data)
            Dim i As Integer
            For i = 0 To grd_data.ColumnCount - 1
                grd_data.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

            If grd_data.RowCount > 0 Then
                ' grd_data.Columns(1).Width = 350
                'grd_data.Columns(2).Width = 100
                grd_data.Rows.Item(0).Selected = True
                ' txt_Company_ID_Selected.Text = grd_data.CurrentRow.Cells(0).Value
            End If

            If is_first_time = True Then
                If grd_data.RowCount = 0 Then
                    MsgBox("My Product exist.")
                    Me.Close()
                End If
                is_first_time = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub grd_data_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_data.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            'cbo_bank_product.Text = grd_data.CurrentRow.Cells(0).Value
            'txtDesc.Text = grd_data.CurrentRow.Cells(1).Value
            'Me.Close()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub


    Private Sub grd_data_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_data.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            Call SelectNow()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub



    Private Sub btn_Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Submit.Click

        If txt_revision_code.Text.ToUpper = "Rev0022".ToUpper Then
            Dim mFrm_DealSummary_Product_ChargePackageRev As New Frm_DealSummary_Product_ChargePackageRev_Edit
            mFrm_DealSummary_Product_ChargePackageRev.strMODE = "ADD"

    

            mFrm_DealSummary_Product_ChargePackageRev.ShowDialog()
        Else
            Call SelectNow()
        End If


    End Sub

    Private Sub SelectNow()
        If grd_data.RowCount <= 0 Then Exit Sub
        If grd_data.CurrentRow.Cells(0).Value = "" Then Exit Sub

        'xFrm_DealSummary_Product.cbo_ude_product.Text = txt_UDEPRODUCT.Text
        'xFrm_DealSummary_Product.txt_my_product.Text = txt_MYPRODUCT.Text
        'xFrm_DealSummary_Product.cbo_bank_product.Text = grd_data.CurrentRow.Cells(0).Value


        Dim mFrm_DealSummary_Product As Frm_DealSummary_Product
        mFrm_DealSummary_Product = New Frm_DealSummary_Product(Me)


        mFrm_DealSummary_Product.strMODE = strMODE
        Dim strSQL As String = ""
        Dim intCount As String = ""

        strSQL = " select count(*) as c FROM dbo.TB_DEAL_PRODUCT a "
        strSQL += " WHERE a.company_id='" + txt_company_id.Text.Replace("'", "''") + "' "
        strSQL += " and my_product='" + txt_MYPRODUCT.Text.ToString.Replace("'", "''") + "' "
        strSQL += " and bank_product='" + grd_data.CurrentRow.Cells(0).Value + "' "

        intCount = conn.GetDataFromSQL(strSQL)


        If strMODE = "ADD" Then

            If CDbl(intCount) > 0 Then
                MsgBox("This product was used by some user.")
                Exit Sub
            End If


        End If

        If strMODE <> "ADD" Then

            If CDbl(intCount) = 0 Then
                MsgBox("Not found data.")
                Exit Sub
            End If


        End If

        mFrm_DealSummary_Product.txt_company_id.Text = txt_company_id.Text
        mFrm_DealSummary_Product.cbo_ude_product.Text = txt_UDEPRODUCT.Text
        mFrm_DealSummary_Product.cbo_bank_product.Text = grd_data.CurrentRow.Cells(0).Value

        ' mFrm_DealSummary_Product.txt_my_product.Text = ""

        If txt_revision_code.Text <> "" Then
            mFrm_DealSummary_Product.txt_revision_code.Text = txt_revision_code.Text
            mFrm_DealSummary_Product.txt_revision_desc.Text = txt_revision_desc.Text
            mFrm_DealSummary_Product.lbHead.Text += " - " & txt_revision_desc.Text
        End If


        If bIsViewOnly = True Then
            ' Frm_DealSummary_Product_SelectMyProduct.bIsViewOnly = bIsViewOnly
            mFrm_DealSummary_Product.BT_Update.Enabled = False
            mFrm_DealSummary_Product.btn_find_product.Enabled = False
            mFrm_DealSummary_Product.btn_find_charge.Enabled = False

        End If

        mFrm_DealSummary_Product.ShowDialog()
        Call ShowDataGrid()

        'Me.Close()
    End Sub
End Class