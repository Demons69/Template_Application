Imports System.Data.SqlClient
Imports System.Configuration


Public Class CSQL
    Dim cn As SqlConnection
    'Dim str_cn As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Template_DB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
    Dim str_cn As String = ""
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter

    Public Sub New()

        Dim mCls_Configuration As New Cls_Configuration
        str_cn = mCls_Configuration.ConnectionString

    End Sub

    Public Sub Connect()
        Try

            cn = New SqlConnection
            cn.ConnectionString = str_cn

            cn.Open()

        Catch ex As Exception

            MsgBox(ex.ToString)
            'If cn.State = ConnectionState.Closed Then
            '    cn.Open()
            '    Do While Not cn.State = ConnectionState.Open
            '        If cn.State <> ConnectionState.Open Then
            '            If MsgBox("Conntion fail. Do you want to resume connection.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            '                cn.Open()
            '            Else
            '                Exit Do
            '            End If
            '        End If
            '    Loop
            'End If

            If MsgBox("Conntion fail. Do you want to resume connection.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                Call Connect()
            End If


        End Try

    End Sub

    Public Sub Close()
        cn.Close()
    End Sub

    Public Function ExecuteScalar(ByVal SqlCmd As String, Optional ByVal bShowErr As Boolean = True) As Integer
        Dim rst As Integer

        Try
            Connect()
            cmd = New SqlCommand(SqlCmd, cn)
            rst = Convert.ToInt32(cmd.ExecuteScalar())

            Return rst
        Catch ex As Exception

            If bShowErr = True Then
                MessageBox.Show(ex.ToString)
            End If

            Dim FILE_NAME As String = Application.StartupPath & "\err" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".txt"
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

            objWriter.Write("Date:" & DateTime.Now.ToString("yyyyMMddhhmmss") & vbCrLf & ex.ToString & vbCrLf & "sql:" & vbCrLf & SqlCmd)
            objWriter.Flush()
            objWriter.Close()

            Return -1
        Finally
            Close()
            cmd = Nothing
        End Try
    End Function


    Public Function ExecuteNonQuery(ByVal SqlCmd As String, Optional ByVal bShowErr As Boolean = True) As String
        Try
            Connect()

            cmd = New SqlCommand(SqlCmd, cn)
            da = New SqlDataAdapter(cmd)
            cmd.CommandTimeout = 180
            cmd.ExecuteNonQuery()
            Close()
            Return ""
        Catch ex As Exception

            If bShowErr = True Then
                MessageBox.Show(ex.ToString)
            End If

            Dim FILE_NAME As String = Application.StartupPath & "\err" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".txt"

            ' If System.IO.File.Exists(FILE_NAME) = True Then

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

            objWriter.Write("Date:" & DateTime.Now.ToString("yyyyMMddhhmmss") & vbCrLf & ex.ToString & vbCrLf & "sql:" & vbCrLf & SqlCmd)
            objWriter.Flush()
            objWriter.Close()
            ' MsgBox("Text written to file")
            ' End If
            Return ex.ToString
        Finally
            cmd = Nothing
            da = Nothing
        End Try
    End Function

    Public Function HasRows(ByVal SqlCmd As String) As Boolean
        Connect()
        Dim res As SqlDataReader
        cmd = New SqlCommand(SqlCmd, cn)
        da = New SqlDataAdapter(cmd)
        res = cmd.ExecuteReader()
        Return res.HasRows
        res.Close()
        Close()
    End Function

    Public Function GetDataFromSQL(ByVal SqlCmd As String, Optional ByVal sIndex As Integer = 0) As String
        Connect()
        GetDataFromSQL = ""
        Dim res As SqlDataReader
        cmd = New SqlCommand(SqlCmd, cn)
        da = New SqlDataAdapter(cmd)
        res = cmd.ExecuteReader()
        If res.HasRows = True Then
            res.Read()
            Return IIf(res(sIndex) Is System.DBNull.Value, "", res(sIndex).ToString())
        End If
        res.Close()
        Close()
    End Function

    'overloading type1
    Public Function GetDataReader(ByVal SqlCmd As String) As SqlDataReader
        Try
            Connect()
            cmd = New SqlCommand(SqlCmd, cn)
            da = New SqlDataAdapter(cmd)
            cmd.CommandTimeout = 180
            Return cmd.ExecuteReader()
            Exit Function

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return Nothing
    End Function

    'Public Sub Query(ByVal SqlCmd As String, ByRef res As SqlDataReader)
    '    Connect()
    '    cmd = New SqlCommand(SqlCmd, cn)
    '    da = New SqlDataAdapter(cmd)

    '    res = cmd.ExecuteReader()
    'End Sub

    'overloading type2
    'Public Sub Query(ByVal SqlCmd As String)
    '    Connect()
    '    cmd = New SqlCommand(SqlCmd, cn)
    '    da = New SqlDataAdapter(cmd)

    '    cmd.ExecuteNonQuery()
    '    Close()
    'End Sub

    Public Function BindingDT(ByVal SqlCmd As String, ByVal tblName As String) As DataTable
        Dim ds As New DataSet
        Dim da As SqlDataAdapter

        Try

            Connect()
            cmd = New SqlCommand(SqlCmd, cn)
            da = New SqlDataAdapter(cmd)
            da.Fill(ds, tblName)
            Return ds.Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            Close()
        End Try
    End Function

    Public Sub SetGrid(ByVal SqlCmd As String, ByRef DG As DataGridView)
        Dim ds As New DataSet
        Connect()
        cmd = New SqlCommand(SqlCmd, cn)
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "PRD_TemplateProduct")


        DG.DataSource = ds.Tables("PRD_TemplateProduct")
        If DG.RowCount > 0 Then
            DG.Rows.Item(0).Selected = True
        End If

        Close()
    End Sub

    Public Function GetDataSet(ByVal SqlCmd As String) As DataSet
        Dim ds As New DataSet
        Connect()
        cmd = New SqlCommand(SqlCmd, cn)
        da = New SqlDataAdapter(cmd)
        da.Fill(ds, "DataTable1")
        Return ds
        Close()
    End Function


    Public Sub Fill_ComboBox(ByVal strSQL As String, ByRef Obj As Object, Optional ByVal strAddional As String = "-----")
        Connect()
        cmd = New SqlCommand(strSQL, cn)
        da = New SqlDataAdapter(cmd)
        Dim Tmp = cmd.ExecuteReader()

        Obj.Items.Clear()
        If strAddional <> "-----" Then
            Obj.Items.Add(strAddional)
        End If
        While (Tmp.Read())
            Obj.Items.Add(Tmp(0).ToString)
        End While
        Close()
    End Sub

    Public Function GetSQL_LIST_PRODUCT_MST() As String
        Dim strSQL As String = ""

        strSQL = ""
        strSQL += "  SELECT  t.[Product] +  '-' + ISNULL(p.PRODUCT_DESCRIPTION,'') "
        strSQL += "  FROM [PRD_TemplateProduct] t "
        strSQL += "  left outer join dbo.PRODUCT_MST p "
        strSQL += "  on  (p.PRODUCT_CODE = t.[Product])"
        strSQL += "  GROUP BY  t.[Product] , p.PRODUCT_DESCRIPTION "
        strSQL += "  ORDER BY t.[Product],p.PRODUCT_DESCRIPTION "

        Return strSQL
    End Function

    Public Function IsExistingCompanyID(ByVal companyID As String) As Boolean

        Return HasRows("SELECT * FROM [TB_DEAL_UMM_COMPANY] WHERE [company_id] ='" _
                    + companyID.Replace("'", "''") + "'")

    End Function

    'Public Sub Fill_ComboBox_with_Value(ByVal strSQL As String, ByRef Obj As Object, Optional ByVal strAddional As String = "")
    '    Connect()
    '    cmd = New SqlCommand(strSQL, cn)
    '    da = New SqlDataAdapter(cmd)
    '    Dim Tmp = cmd.ExecuteReader()

    '    Obj.Items.Clear()
    '    If strAddional <> "" Then
    '        Obj.Items.Add(strAddional)
    '    End If
    '    While (Tmp.Read())
    '        Dim xx As New System

    '        Obj.Items.Add(Tmp(0).ToString)
    '    End While
    '    Close()
    'End Sub

    'Public Sub TP_PRD_SetList(ByVal Elemiment As String, ByRef Obj As Object, Optional ByVal strAddional As String = "")
    '    Connect()
    '    cmd = New SqlCommand("SELECT DISTINCT [" + Elemiment + "] FROM [PRD_TemplateProduct] ORDER BY [" + Elemiment + "]", cn)
    '    da = New SqlDataAdapter(cmd)
    '    Dim Tmp = cmd.ExecuteReader()

    '    Obj.Items.Clear()
    '    If strAddional <> "" Then
    '        Obj.Items.Add(strAddional)
    '    End If
    '    While (Tmp.Read())
    '        Obj.Items.Add(Tmp(0).ToString)
    '    End While
    '    Close()
    'End Sub

    'Public Sub TP_CHG_SetList(ByVal Elemiment As String, ByRef Obj As Object)
    '    Connect()
    '    cmd = New SqlCommand("SELECT DISTINCT [" + Elemiment + "] FROM [PRD_TemplateChargeUnits] ORDER BY [" + Elemiment + "]", cn)
    '    da = New SqlDataAdapter(cmd)
    '    Dim Tmp = cmd.ExecuteReader()

    '    Obj.Items.Clear()
    '    While (Tmp.Read())
    '        Obj.Items.Add(Tmp(0).ToString)
    '    End While
    '    Close()
    'End Sub

    'Public Sub TP_CHG_SetList(ByVal Elemiment As String, ByVal pd As String, ByRef Obj As Object)
    '    Connect()
    '    cmd = New SqlCommand("SELECT DISTINCT [" + Elemiment + "] FROM [PRD_TemplateChargeUnits] WHERE Template like '" + pd + "%'", cn)
    '    da = New SqlDataAdapter(cmd)
    '    Dim Tmp = cmd.ExecuteReader()

    '    Obj.Items.Clear()
    '    While (Tmp.Read())
    '        Obj.Items.Add(Tmp(0).ToString)
    '    End While
    '    Close()
    'End Sub

    'Public Sub TP_CE_SetList(ByVal Elemiment As String, ByRef Obj As Object)
    '    Connect()
    '    cmd = New SqlCommand("SELECT DISTINCT [" + Elemiment + "] FROM [PRD_TemplateChargeEvents] ORDER BY [" + Elemiment + "]", cn)
    '    da = New SqlDataAdapter(cmd)
    '    Dim Tmp = cmd.ExecuteReader()

    '    Obj.Items.Clear()
    '    While (Tmp.Read())
    '        Obj.Items.Add(Tmp(0).ToString)
    '    End While
    '    Close()
    'End Sub

    'Public Sub TP_CU_SetList(ByVal Elemiment As String, ByRef Obj As Object)
    '    Connect()
    '    cmd = New SqlCommand("SELECT DISTINCT [" + Elemiment + "] FROM [PRD_TemplateChargeUnits] ORDER BY [" + Elemiment + "]", cn)
    '    da = New SqlDataAdapter(cmd)
    '    Dim Tmp = cmd.ExecuteReader()

    '    Obj.Items.Clear()
    '    While (Tmp.Read())
    '        Obj.Items.Add(Tmp(0).ToString)
    '    End While
    '    Close()
    'End Sub

End Class
