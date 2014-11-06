Public Class TemplateMaster


    Public Function GetTemplateEvent() As DataTable
        Dim strSQL As String = "exec [SP_tp_TemplateChargeEvents] "
        Dim conn As New CSQL
        Return conn.BindingDT(strSQL, "TemplateChgEvent")

    End Function


    Public Function GetTemplateEventByTemplateCode(ByVal TemplateCode As String) As DataTable
        Dim strSQL As String = "exec [SP_tp_TemplateChargeEvents] '', '" & TemplateCode & "'"
        Dim conn As New CSQL
        Return conn.BindingDT(strSQL, "TemplateChgEvent")

    End Function

    Public Function GetTemplateEventByProductCode(ByVal ProductCode As String) As DataTable
        Dim strSQL As String = "exec [SP_tp_TemplateChargeEvents] '" & ProductCode & "', ''"
        Dim conn As New CSQL
        Return conn.BindingDT(strSQL, "TemplateChgEvent")

    End Function


    Public Function GetTemplateUnit(ByVal TemplateCode As String) As DataTable
        Dim strSQL As String = "exec [SP_tp_TemplateChargeUnit] '" & TemplateCode & "'"
        Dim conn As New CSQL
        Return conn.BindingDT(strSQL, "TemplateChgUnit")

    End Function


    Public Function DeleteTemplateUnit(ByVal TemplateCode As String) As String

        Dim strSQL As String = " delete from [PRD_TemplateChargeUnits] where [TemplateCode] = '" & TemplateCode & "'"
        Dim conn As New CSQL
        Return conn.ExecuteNonQuery(strSQL)

    End Function


    Public Function DeleteTemplateEvent(ByVal TemplateCode As String) As String

        Dim strSQL As String = " delete from [PRD_TemplateChargeUnits] where [TemplateCode] = '" & TemplateCode & "'"
        Dim conn As New CSQL
        Return conn.ExecuteNonQuery(strSQL)

    End Function




End Class
