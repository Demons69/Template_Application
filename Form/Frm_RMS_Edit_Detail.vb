Imports Template_Application.CSQL
Imports System.Data.SqlClient


Public Class Frm_RMS_Edit_Detail
    Dim conn As CSQL

    Public strID As String = ""
    Public strMODE As String = "ADD"

    Private Sub Frm_RMS_Edit_Detail_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        conn.Close()
    End Sub

    Private Sub Frm_RMS_Edit_Detail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FillComboALL()
        Dim strSQL As String = ""
        strSQL = ""
        strSQL += " SELECT    report_name as rpt " '+ ' (' + report_format + ')' 
        strSQL += " FROM TB_CATAGORY_REPORT_MST "
        strSQL += " WHERE     service_group = N'SQ' "
        strSQL += " order by report_name"
        conn.Fill_ComboBox(strSQL, cbo_report_name)

        cbo_report_format.Items.Clear()
        cbo_report_format.Items.Add("PDF")
        cbo_report_format.Items.Add("Text")
        cbo_report_format.Items.Add("")

        cbo_format_text.Items.Clear()
        cbo_format_text.Items.Add("SQ")
        cbo_format_text.Items.Add("")

        cbo_layout_flag.Items.Clear()
        cbo_layout_flag.Items.Add("As-is layout")
        cbo_layout_flag.Items.Add("To-be layout")

    End Sub

    Private Sub Frm_RMS_Edit_Detail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            conn = New CSQL
            conn.Connect()
            Dim strSQL As String = ""

            'Call FillComboALL()
            Call FillComboALL()

            If strMODE.ToUpper <> "ADD" Then
                Call ShowData()
                ' Call SetGrid_RMS()
            Else
                'Dim strSQL As String = ""
                'strSQL = "SELECT isnull(max(seq),0) + 1 as seq FROM [TB_RMS_H] WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
                'txt_seq.Text = conn.GetDataFromSQL(strSQL)
                ' Call SetGrid_RMS()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub ShowData()
        Dim res As SqlDataReader
        Dim strSQL As String = ""
        strSQL = ""
        strSQL += "SELECT * FROM [TB_RMS_D]"
        strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
        strSQL += " and seq= " & txt_seq.Text
        strSQL += " and report_name= '" & cbo_report_name.Text & "'"
        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            res.Read()

            cbo_report_name.Text = IIf(res("report_name") Is System.DBNull.Value, "", res("report_name").ToString())
            cbo_report_format.Text = IIf(res("report_format") Is System.DBNull.Value, "", res("report_format").ToString())
            ' Call SetForm()
            cbo_format_text.Text = IIf(res("format_text") Is System.DBNull.Value, "", res("format_text").ToString())
            cbo_layout_flag.Text = IIf(res("layout_flag") Is System.DBNull.Value, "", res("layout_flag").ToString())


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

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub SaveData(Optional ByVal IsShowMSG As Boolean = True)
        Try


            conn = New CSQL
            conn.Connect()
            Dim strSQL As String = ""
            '========================add mode====================
            If strMODE.ToUpper = "ADD" Then

                strSQL = ""
                strSQL += "SELECT * FROM [TB_RMS_D]"
                strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
                strSQL += " and seq= " & txt_seq.Text
                strSQL += " and report_name= '" & cbo_report_name.Text & "'"

                If conn.HasRows(strSQL) = True Then
                    MessageBox.Show("Invalid Report Name is duplicate.")
                    Exit Sub
                End If

                Dim strValue As String = ""
                Dim strFiledname As String = ""


                strFiledname += vbCrLf & "[company_id]"
                strValue += vbCrLf & "N'" & txt_company_id.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[seq]"
                strValue += vbCrLf & "," & txt_seq.Text.Replace("'", "''")


              

                strFiledname += vbCrLf & ",[report_name]"
                strValue += vbCrLf & ",N'" & cbo_report_name.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[report_format]"
                strValue += vbCrLf & ",N'" & cbo_report_format.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[format_text]"
                strValue += vbCrLf & ",N'" & cbo_format_text.Text.Replace("'", "''") & "'"

                strFiledname += vbCrLf & ",[layout_flag]"
                strValue += vbCrLf & ",N'" & cbo_layout_flag.Text.Replace("'", "''") & "'"

                strSQL = ""
                strSQL += vbCrLf & "insert into [TB_RMS_D]"
                strSQL += vbCrLf & "(" & strFiledname & ")"
                strSQL += vbCrLf & " VALUES (" & strValue & ")"

                conn.ExecuteNonQuery(strSQL)
                Me.Close()
                '    strMODE = "EDIT"
            End If ' If strMODE.ToUpper = "ADD" Then
            '========================edit mode====================
            If strMODE.ToUpper <> "ADD" Then
                strSQL = ""
                strSQL += vbCrLf & "update [TB_RMS_D] set "


                strSQL += vbCrLf & "[company_id]"
                strSQL += vbCrLf & "=N'" & txt_company_id.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[seq]"
                strSQL += vbCrLf & "=" & txt_seq.Text.Replace("'", "''")


                strSQL += vbCrLf & ",[report_name]"
                strSQL += vbCrLf & "=N'" & cbo_report_name.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[report_format]"
                strSQL += vbCrLf & "=N'" & cbo_report_format.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[format_text]"
                strSQL += vbCrLf & "=N'" & cbo_format_text.Text.Replace("'", "''") & "'"

                strSQL += vbCrLf & ",[layout_flag]"
                strSQL += vbCrLf & "=N'" & cbo_layout_flag.Text.Replace("'", "''") & "'"


                strSQL += " WHERE [company_id] ='" + txt_company_id.Text.Replace("'", "''") + "'"
                strSQL += " and seq= " & txt_seq.Text
                strSQL += " and report_name= '" & cbo_report_name.Text & "'"


                conn.ExecuteNonQuery(strSQL)
                Me.Close()

            End If ' If strMODE.ToUpper <> "ADD" Then

            'If IsShowMSG = True Then

            '    MsgBox("SaveData was Successful. ")
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Function ValidationData() As String
        Dim strErr As String = ""


        If txt_seq.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Seq]"
        End If

        If cbo_report_name.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Report Name]"
        End If

        If cbo_report_format.Text = "" Then
            strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Report Format]"
        End If

        If cbo_report_format.Text = "Text" Then
            If cbo_format_text.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Format Text]"
            End If

            If cbo_layout_flag.Text = "" Then
                strErr += IIf(strErr = "", "", vbCrLf) & "Invalid [Layout]"
            End If
        End If
       

        Return strErr
    End Function


    Private Sub SelecedReportName()
        If cbo_report_name.Text = "" Then Exit Sub

        Dim strSQL As String = ""
        strSQL = ""
        strSQL += " SELECT    report_format ,format_text,layout_flag " 'report_name + ' (' + report_format + ')'
        strSQL += " FROM TB_CATAGORY_REPORT_MST  "
        strSQL += " WHERE     service_group = N'SQ' "
        strSQL += " and report_name='" & cbo_report_name.Text.Replace("'", "''") & "'"
        strSQL += " order by report_name"

        cbo_report_format.Text = conn.GetDataFromSQL(strSQL, 0)
        cbo_format_text.Text = conn.GetDataFromSQL(strSQL, 1)
        cbo_layout_flag.Text = conn.GetDataFromSQL(strSQL, 2)

    End Sub


    Private Sub cbo_report_name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_report_name.SelectedIndexChanged
        Call SelecedReportName()
    End Sub

End Class