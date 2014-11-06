Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_Client_List
    Dim conn As New CSQL
    Private Const strALL = "--------ALL--------"
    ''Public txtRef As TextBox
    Public Is_parent As Boolean = True

    Private Sub Frm_DealSummary_List_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub Frm_DealSummary_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = New CSQL
        conn.Connect()
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub btn_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Find.Click
        Call SetGrid()
    End Sub

    Private Sub SetGrid()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""


            strCrit = ""



            If txt_company_id.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [company_id] LIKE '%" & txt_company_id.Text & "%'"
            End If

            If txt_client_code.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [client_code] LIKE '%" & txt_client_code.Text & "%'"
            End If

            If txt_companyname_en.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [companyname_en] LIKE '%" & txt_companyname_en.Text & "%'"
            End If
            If txt_companyname_th.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [companyname_th] LIKE '%" & txt_companyname_th.Text & "%'"
            End If
            If txt_tax_id.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [tax_id] LIKE '%" & txt_tax_id.Text & "%'"
            End If

            If txt_Account.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [company_id] in ( select company_id from TB_DEAL_ACCOUNT where account_number like '%" & txt_Account.Text & "%' OR account_number_charge LIKE '%" & txt_Account.Text & "%' OR account_number_credit LIKE '%" & txt_Account.Text & "%'  )"
            End If

            If strCrit = "" Then
                If MsgBox("No Criteria, Do you want to search data.", MsgBoxStyle.YesNo, "") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            If Is_parent = True Then
                ' strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [set_as_parent_company] = 'Y'   "
            End If


            strSQL = ""
            strSQL += vbCrLf & " SELECT "
            strSQL += vbCrLf & "   company_id as [Company Id]"
            strSQL += vbCrLf & " , client_code as [Client Code]"
            strSQL += vbCrLf & " , companyname_en as [Company Name(EN)]"
            strSQL += vbCrLf & " , companyname_th as [Company Name(TH)]"
            strSQL += vbCrLf & " , tax_id as [Corporate Registration ID / Tax Id]"

            strSQL += vbCrLf & " FROM "
            strSQL += vbCrLf & " dbo.TB_DEAL_UMM_COMPANY "
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & " ORDER BY  company_id "

            Call conn.SetGrid(strSQL, grd_data)
            Dim i As Integer
            For i = 0 To grd_data.ColumnCount - 1
                grd_data.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

            If grd_data.RowCount > 0 Then
                grd_data.Columns(2).Width = 350
                grd_data.Columns(3).Width = 350
                grd_data.Rows.Item(0).Selected = True
                txt_Company_ID_Selected.Text = grd_data.CurrentRow.Cells(0).Value
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub grd_data_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_data.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txt_Company_ID_Selected.Text = grd_data.CurrentRow.Cells(0).Value
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub


    Private Sub grd_data_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_data.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            txt_Company_ID_Selected.Text = grd_data.CurrentRow.Cells(0).Value
            If txt_Company_ID_Selected.Text = "" Then Exit Sub
            ''txtRef.Text = txt_Company_ID_Selected.Text
            Me.Close()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub btn_Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Submit.Click
        If txt_Company_ID_Selected.Text = "" Then Exit Sub
        ''txtRef.Text = txt_Company_ID_Selected.Text
        txt_Company_ID_Selected.Text = grd_data.CurrentRow.Cells(0).Value
        Me.Close()
    End Sub

    Private Sub btn_print_sum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print_sum.Click
        If txt_Company_ID_Selected.Text = "" Then
            MsgBox("Please selection client.")
            Exit Sub
        End If

        Dim str_cn As String = ""
        Dim str_cn_ole As String = ""
        Dim mCls_Configuration As New Cls_Configuration
        str_cn = mCls_Configuration.ConnectionString



        Dim strFile As String = Application.StartupPath & "\report\APPLICATION_FORM.doc"
        Dim strFile_param As String = Application.StartupPath & "\report\File_param.dat"
        ' Dim strFile_cfg As String = Application.StartupPath & "\report\Default.ini"
        Dim strPath As String = Application.StartupPath & "\report\"
        '\Report\output-files\THAILAND02'

        ' mCls_Configuration.INIWrite(strFile_cfg, "Options", "AutosaveDirectory", strPath & "output-files\" & txt_company_id.Text & "\")


        Dim strServer As String = ""
        Dim strDatabase As String = ""
        Dim strUser As String = ""
        Dim strPwd As String = ""


        Dim csb = New SqlConnectionStringBuilder(str_cn)



        strServer = csb.DataSource
        strDatabase = csb.InitialCatalog
        strUser = csb.UserID
        strPwd = csb.Password

        str_cn_ole = "Provider=SQLOLEDB.1;Password=" & strPwd & ";Persist Security Info=True;User ID=" & strUser & ";Initial Catalog=" & strDatabase & ";Data Source=" & strServer & ""

        'Call GenPDF(strFile, str_cn_ole, strPath)
        csb.Clear()
        Dim strParama As String = str_cn_ole & "||" & strPath & "||" & txt_Company_ID_Selected.Text & "||summary||generatefile"
        'Clipboard.Clear()
        'Clipboard.SetData(strParama, TextDataFormat.Text)

        Dim FILE_NAME As String = strFile_param 'Application.StartupPath & "\err" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".txt"

        ' If System.IO.File.Exists(FILE_NAME) = True Then

        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

        objWriter.Write(strParama)
        objWriter.Flush()
        objWriter.Close()

        Shell("cmd /k """ & strFile & """", AppWinStyle.NormalFocus)

        Exit Sub
    End Sub


    Public Property CompanyID() As String
        Get
            Return txt_Company_ID_Selected.Text
        End Get
        Set(ByVal Value As String)
            txt_Company_ID_Selected.Text = Value
        End Set
    End Property

End Class