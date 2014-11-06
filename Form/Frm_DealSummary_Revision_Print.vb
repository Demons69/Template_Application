
Imports System.Data.SqlClient

Public Class Frm_DealSummary_Revision_Print
    Dim conn As New CSQL

    Private Sub Frm_DealSummary_Revision_Print_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        conn = New CSQL
        conn.Connect()
        Call FindCustomer()

    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub FindCustomer()
        Dim mFrm_DealSummary_List As New Frm_DealSummary_List
        mFrm_DealSummary_List.txtRef = txt_company_id
        mFrm_DealSummary_List.Is_parent = True
        mFrm_DealSummary_List.ShowDialog()

        If txt_company_id.Text <> "" Then
            ' Call ShowCompanyName()
            'Call SetGrid_Category()
            txt_company_name.Text = conn.GetDataFromSQL("select companyname_en from dbo.TB_DEAL_UMM_COMPANY where company_id='" & txt_company_id.Text.Replace("'", "''") & "' ")
            txt_from.Enabled = True
            txt_to.Enabled = True

            txt_to.Text = Format(Now, "dd/MM/") & Now.Year
            txt_from.Text = Format(DateAdd(DateInterval.Day, -7, Now), "dd/MM/") & Now.Year

            txt_from.Text = Replace(txt_from.Text, "-", "/")
            txt_to.Text = Replace(txt_to.Text, "-", "/")

            btn_Find.Enabled = True

            If get_date_sql(txt_from.Text) = "NULL" Then Exit Sub
            If get_date_sql(txt_to.Text) = "NULL" Then Exit Sub
            Call SetGrid()

        Else
            Me.Close()
        End If

    End Sub


    Private Sub btn_Find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Find.Click
        'BT_Print
        If get_date_sql(txt_from.Text) = "NULL" Then Exit Sub
        If get_date_sql(txt_to.Text) = "NULL" Then Exit Sub
        Call SetGrid()
    End Sub

    Private Sub SetGrid()
        Try

            Dim strSQL As String = ""
            Dim strCrit As String = ""


            strCrit = ""

            If txt_company_id.Text <> "" Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " [company_id] = '" & txt_company_id.Text & "'"
            End If

            If (get_date_sql(txt_to.Text)) < (get_date_sql(txt_from.Text)) Then
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " cast([revision_date] as date)  between  " & get_date_sql(txt_to.Text) & " and " & get_date_sql(txt_from.Text) & ""

            Else
                strCrit += vbCrLf & IIf(strCrit = "", "WHERE", "AND") & " cast([revision_date] as date)  between  " & get_date_sql(txt_from.Text) & " and " & get_date_sql(txt_to.Text) & ""

            End If

            strSQL = ""
            strSQL += vbCrLf & " select  [Revision Date],Code,[Description] from ( "
            strSQL += vbCrLf & "  SELECT   distinct "
            strSQL += vbCrLf & "     right(day(revision_date) + 10000,2) + '/' + right(month(revision_date) + 10000,2) + '/' + right(year(revision_date) + 10000,4)  as [Revision Date] "
            strSQL += vbCrLf & "       ,revision_code as [Code] "
            strSQL += vbCrLf & "     ,revision_desc as [Description] "
            ' strSQL += vbCrLf & "     ,right(year(revision_date) + 10000,4)   + '/' + right(month(revision_date) + 10000,2) + '/' +  right(day(revision_date) + 10000,2) as [Revision Date2] "
            strSQL += vbCrLf & "    FROM [dbo].[TB_REVISION_HISTORY]"
            strSQL += vbCrLf & strCrit
            strSQL += vbCrLf & "group by revision_date,revision_code,revision_desc "
            ' strSQL += vbCrLf & "  order by revision_date desc " 'year([Revision Date]) desc, month([Revision Date]) desc,day([Revision Date]) desc "
            strSQL += vbCrLf & " ) #all  "
            strSQL += vbCrLf & "  order by right([Revision Date],4) desc ,substring([Revision Date],3,2) desc   ,left([Revision Date],2) desc  "
            grd_list.Columns.Clear()


            Call conn.SetGrid(strSQL, grd_list)

            ' grd_list.Columns("Revision Date2").Visible = False

            For i = 0 To grd_list.Columns.Count - 1
                grd_list.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                grd_list.Columns(i).ReadOnly = True
            Next

            Dim colCheckbox As New DataGridViewCheckBoxColumn()
            colCheckbox.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            colCheckbox.ThreeState = False
            colCheckbox.TrueValue = 1
            colCheckbox.FalseValue = 0
            colCheckbox.IndeterminateValue = System.DBNull.Value
            colCheckbox.DataPropertyName = "Print"
            colCheckbox.HeaderText = "Print"
            colCheckbox.Name = "Print"
            colCheckbox.ReadOnly = False
            colCheckbox.HeaderText = "Print"
            grd_list.Columns.Add(colCheckbox)

            If grd_list.RowCount > 0 Then
                grd_list.Rows.Item(0).Selected = True
                ' txt_Template.Text = grd_Template.CurrentRow.Cells(0).Value
                BT_Print.Enabled = True
                btn_print_offline.Enabled = True

            End If


            '   Dim i As Long = 0
            For i = 0 To grd_list.RowCount - 1
                ' grd_list.Rows(i).Cells(3).FormattedValue = True
                grd_list.Rows(i).Cells(3).Value = True

            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Function get_date_to_control(ByVal strData As Object) As String
        Try

            '  If strData = "" Then Return "NULL" : Exit Function

            Dim strtmp As String = ""
            If IsDate(strData) Then
                strtmp = CDate(strData).ToString("dd/MM/") & CDate(strData).Year
                strtmp = Replace(strtmp, "-", "/")
            Else
                strtmp = ""
            End If


            Return strtmp
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function get_date_sql(ByVal strData As String) As String
        Try



            If strData = "" Then Return "NULL" : Exit Function

            Dim strtmp As String = ""
            If UBound(strData.Split("/")) = 2 Then
                strtmp = strData.Split("/")(2) & "/" & strData.Split("/")(1) & "/" & strData.Split("/")(0)
                strtmp = "'" & strtmp & "'"
            Else
                strtmp = "NULL"
            End If


            Return strtmp
        Catch ex As Exception
            Return "NULL"
        End Try
    End Function

    Private Sub btn_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_all.Click
        Dim i As Long = 0
        For i = 0 To grd_list.RowCount - 1
            ' grd_list.Rows(i).Cells(3).FormattedValue = True
            grd_list.Rows(i).Cells(3).Value = True

        Next
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        Dim i As Long = 0
        For i = 0 To grd_list.RowCount - 1
            grd_list.Rows(i).Cells(3).Value = False
        Next
    End Sub

    Private Sub btn_print_offline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print_offline.Click
        Dim i As Long = 0
        Dim strValue As String = ""

        For i = 0 To grd_list.RowCount - 1

            'strSQL += vbCrLf & "     revision_date as [Revision Date] "
            'strSQL += vbCrLf & "       ,revision_code as [Code] "
            'strSQL += vbCrLf & "     ,revision_desc as [Description] "

            If grd_list.Rows(i).Cells(3).FormattedValue = True Then
                'MsgBox(grd_list.Rows(i).Cells(1).Value & " - " & grd_list.Rows(i).Cells(2).Value)
                'Dim strTmp As String = ""
                'strTmp += grd_list.Rows(i).Cells(0).Value & ";"
                'strTmp += grd_list.Rows(i).Cells(1).Value & ";"
                'strTmp += grd_list.Rows(i).Cells(2).Value
                'strValue += IIf(strValue = "", "", "|") & strTmp

                '[Revision Date],Code,[Description]
                Dim strSQL As String = ""
                strSQL = ""
                strSQL += vbCrLf & " update TB_REVISION_HISTORY set "
                strSQL += vbCrLf & " print_flag ='Y' "
                strSQL += vbCrLf & " where "
                strSQL += vbCrLf & " company_id='" & txt_company_id.Text.Replace("'", "''") & "' "

                strSQL += vbCrLf & " and year(revision_date)=" & CDbl(Split(grd_list.Rows(i).Cells(0).Value, "/")(2))
                strSQL += vbCrLf & " and month(revision_date)=" & CDbl(Split(grd_list.Rows(i).Cells(0).Value, "/")(1))
                strSQL += vbCrLf & " and day(revision_date)=" & CDbl(Split(grd_list.Rows(i).Cells(0).Value, "/")(0))

                strSQL += vbCrLf & " and revision_code='" & grd_list.Rows(i).Cells(1).Value & "' "

                conn.ExecuteNonQuery(strSQL)

            End If
        Next
        MsgBox("Print Offline was success.")

    End Sub

    Private Sub BT_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Print.Click
        Dim i As Long = 0
        Dim strValue As String = String.Empty
        Dim expMsg As String = String.Empty
        Dim isPrinted As Boolean = False

        For i = 0 To grd_list.RowCount - 1

            'strSQL += vbCrLf & "     revision_date as [Revision Date] "
            'strSQL += vbCrLf & "       ,revision_code as [Code] "
            'strSQL += vbCrLf & "     ,revision_desc as [Description] "

            If grd_list.Rows(i).Cells(3).FormattedValue = True Then
                'MsgBox(grd_list.Rows(i).Cells(1).Value & " - " & grd_list.Rows(i).Cells(2).Value)

                expMsg += ValidateRevision(grd_list.Rows(i).Cells(1).Value)

                Dim strTmp As String = ""
                strTmp += grd_list.Rows(i).Cells(0).Value & ";"
                strTmp += grd_list.Rows(i).Cells(1).Value & ";"
                strTmp += grd_list.Rows(i).Cells(2).Value

                strValue += IIf(strValue = "", "", "|") & strTmp

                isPrinted = True

            End If
        Next

        '-- validate before print
        If Len(expMsg) > 0 Then

            MessageBox.Show(expMsg, "Revision", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf isPrinted = False Then

            MessageBox.Show("Require at least one revision.", "Revision", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            PrintOnline(strValue)

        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValidateRevision(ByVal revisionCode As String) As String
        Dim msg As String = String.Empty
        Dim outData As String = String.Empty

        Select revisionCode
            Case "Rev0003"

                outData = conn.GetDataFromSQL("exec [SP_ta_Rev003_UserProfile_Validation] '" & txt_company_id.Text & "' ")
                If Len(outData) > 0 Then msg = "Please complete require fileds in customer profile for " & outData

            Case "Rev0002"

                outData = conn.GetDataFromSQL("exec [SP_ta_Rev002_DisableCompanyProfile_Validation] '" & txt_company_id.Text & "' ")
                If outData = String.Empty Then msg = "Require GCP Service end date in company profile."

        End Select

        Return msg

    End Function


    Private Sub PrintOnline(ByVal strValue As String)
        Dim strFile As String = Application.StartupPath & "\report\APPLICATION_FORM.doc"
        Dim strFile_param As String = Application.StartupPath & "\report\File_param.dat"
        ' Dim strFile_cfg As String = Application.StartupPath & "\report\Default.ini"
        Dim strPath As String = Application.StartupPath & "\report\"
        '\Report\output-files\THAILAND02'
        ' mCls_Configuration.INIWrite(strFile_cfg, "Options", "AutosaveDirectory", strPath & "output-files\" & txt_company_id.Text & "\")

        Dim str_cn As String
        Dim str_cn_ole As String
        Dim mCls_Configuration As New Cls_Configuration


        Dim strServer As String
        Dim strDatabase As String
        Dim strUser As String
        Dim strPwd As String

        str_cn = mCls_Configuration.ConnectionString
        Dim csb = New SqlConnectionStringBuilder(str_cn)


        strServer = csb.DataSource
        strDatabase = csb.InitialCatalog
        strUser = csb.UserID
        strPwd = csb.Password

        str_cn_ole = "Provider=SQLOLEDB.1;Password=" & strPwd & ";Persist Security Info=True;User ID=" & strUser & ";Initial Catalog=" & strDatabase & ";Data Source=" & strServer & ""

        'Call GenPDF(strFile, str_cn_ole, strPath)
        csb.Clear()
        Dim strParama As String = str_cn_ole & "||" & strPath & "||" & txt_company_id.Text & "||" & strValue
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


        ' Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        ' End Try

    End Sub

End Class