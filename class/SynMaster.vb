Public Class SynMaster
    Private _companyID As String



    Public Function GetNewData(ByVal companyId As String) As Integer
        Dim rowsAffect As Integer
        Dim strSQL As String = "exec [USP_GCP_Deal_UpdateAll_ByCompany] '" & companyId & "'"
        Dim conn As New CSQL

        rowsAffect = conn.ExecuteScalar(strSQL, False)
        Return rowsAffect

    End Function



    Public Property CompanyID() As String
        Get
            Return _companyID
        End Get
        Set(ByVal Value As String)
            _companyID = Value
        End Set
    End Property


End Class
