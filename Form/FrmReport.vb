
Imports Template_Application.CSQL
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms.ReportDataSource


Public Class FrmReport
    Dim conn As CSQL

    Private strReportType As String = ""
    Private strReportPath As String = ""
    Private strSQL As String = ""

    Public strSQL_PRD_Template As String = ""
    Public strSQL_PRD_TemplateProductArrangements As String
    Public strSQL_PRD_TemplateProductClearingLocation As String
    Public strSQL_PRD_TemplateInstrumentEnrichments As String


    Public strSQL1 As String = ""
    Public strSQL2 As String = ""

    Public Params(3) As Microsoft.Reporting.WinForms.ReportParameter
    Public strLine(3) As String

    Public Property ReportType()
        Get
            Return strReportType
        End Get
        Set(ByVal value)
            strReportType = value
        End Set
    End Property

    Public Property ReportPath()
        Get
            Return strReportPath
        End Get
        Set(ByVal value)
            strReportPath = value
        End Set
    End Property

    Public Property SQL()
        Get
            Return strSQL
        End Get
        Set(ByVal value)
            strSQL = value
        End Set
    End Property

    Private Sub FrmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            If strLine(0) Is Nothing Then strLine(0) = ""
            If strLine(1) Is Nothing Then strLine(1) = ""
            If strLine(2) Is Nothing Then strLine(2) = ""
            If strLine(3) Is Nothing Then strLine(3) = ""

            Params(0) = New Microsoft.Reporting.WinForms.ReportParameter
            Params(0) = New Microsoft.Reporting.WinForms.ReportParameter("line1", strLine(0), False)

            Params(1) = New Microsoft.Reporting.WinForms.ReportParameter
            Params(1) = New Microsoft.Reporting.WinForms.ReportParameter("line2", strLine(1), False)

            Params(2) = New Microsoft.Reporting.WinForms.ReportParameter
            Params(2) = New Microsoft.Reporting.WinForms.ReportParameter("line3", strLine(2), False)

            Params(3) = New Microsoft.Reporting.WinForms.ReportParameter
            Params(3) = New Microsoft.Reporting.WinForms.ReportParameter("type", strLine(3), False)


            Select Case strReportType
                Case "TemplateProduct"
                    Call Reporting_TemplateProduct()
                Case "TemplateChageUnit"
                    Call Reporting_template_charge_Unit()
                Case "TemplateExists"
                    Call Reporting_template_Exists()
                Case "BASE_RATES_MST"
                    Call Reporting_BASE_RATES_MST()
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try


    End Sub

    Private Sub Reporting_TemplateProduct()

        Dim strFile As String = strReportPath & "rpt_template_product.rdlc"
        Dim strFile_TMP As String = strReportPath & strLine(0) & ".rdlc"
        If strLine(0) = "" Then
            strFile_TMP = strReportPath & "rpt_template_product.rdlc"
        Else
            System.IO.File.Copy(strFile, strFile_TMP)
            System.Threading.Thread.Sleep(1000)
        End If


        conn = New CSQL
        ReportViewer1.Reset()
        Dim Params_deal(0) As Microsoft.Reporting.WinForms.ReportParameter
        If strLine(0) Is Nothing Then strLine(0) = ""
        Params_deal(0) = New Microsoft.Reporting.WinForms.ReportParameter
        Params_deal(0) = New Microsoft.Reporting.WinForms.ReportParameter("line1", strLine(0), False)


        ReportViewer1.LocalReport.ReportPath = strFile_TMP ' strReportPath & "rpt_template_product.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()
        Dim dt As DataSet
        Dim dt_PRD_Template As DataSet
        Dim dt_PRD_TemplateProductArrangements As DataSet
        Dim dt_PRD_TemplateProductClearingLocation As DataSet
        Dim dt_PRD_TemplateInstrumentEnrichments As DataSet
        'strSQL_PRD_Template
        dt = conn.GetDataSet(strSQL)
        dt_PRD_Template = conn.GetDataSet(strSQL_PRD_Template)
        dt_PRD_TemplateProductArrangements = conn.GetDataSet(strSQL_PRD_TemplateProductArrangements)
        dt_PRD_TemplateProductClearingLocation = conn.GetDataSet(strSQL_PRD_TemplateProductClearingLocation)
        dt_PRD_TemplateInstrumentEnrichments = conn.GetDataSet(strSQL_PRD_TemplateInstrumentEnrichments)

        ReportViewer1.Name = "XXXXX'"

        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ds_template_product_PRD_TemplateProduct", dt.Tables(0)))
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("Ds_PRD_Template_PRD_Template", dt_PRD_Template.Tables(0)))

        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("Ds_PRD_TemplateProductArrangements_PRD_TemplateProductArrangements", dt_PRD_TemplateProductArrangements.Tables(0)))
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("Ds_PRD_TemplateProductClearingLocation_PRD_TemplateProductClearingLocation", dt_PRD_TemplateProductClearingLocation.Tables(0)))
        'Ds_PRD_TemplateInstrumentEnrichments_PRD_TemplateInstrumentEnrichments
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("Ds_PRD_TemplateInstrumentEnrichments_PRD_TemplateInstrumentEnrichments", dt_PRD_TemplateInstrumentEnrichments.Tables(0)))

        'ReportViewer1.LocalReport.SetParameters(Params)
        ReportViewer1.LocalReport.SetParameters(Params_deal)
        ReportViewer1.DocumentMapCollapsed = True
        ReportViewer1.ResumeLayout()
        ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        ReportViewer1.RefreshReport()

        If strLine(0) <> "" Or strFile <> strFile_TMP Then
            System.Threading.Thread.Sleep(3000)
            System.IO.File.Delete(strFile_TMP)
        End If

    End Sub

    Private Sub Reporting_template_charge_event()
        conn = New CSQL
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportPath = strReportPath & "rpt_template_charge_event.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()
        Dim dt As DataSet
        dt = conn.GetDataSet(strSQL)
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ds_template_chage_event_PRD_TemplateChargeEvents", dt.Tables(0)))
        ReportViewer1.DocumentMapCollapsed = True
        ReportViewer1.ResumeLayout()
        ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        ReportViewer1.RefreshReport()
    End Sub

    Private Sub Reporting_template_charge_Unit()

        Dim strFile As String = strReportPath & "rpt_template_charge_unit.rdlc"

        Dim strFile_TMP As String = strReportPath & strLine(0) & ".rdlc"
        If strLine(0) = "" Then
            strFile_TMP = strReportPath & "rpt_template_charge_unit.rdlc"
        Else
            System.IO.File.Copy(strFile, strFile_TMP)
            System.Threading.Thread.Sleep(1000)
        End If


        conn = New CSQL
        ReportViewer1.Reset()

        ReportViewer1.LocalReport.ReportPath = strFile_TMP 'strReportPath & "rpt_template_charge_unit.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()


        Dim Params_deal(0) As Microsoft.Reporting.WinForms.ReportParameter
        If strLine(0) Is Nothing Then strLine(0) = ""
        Params_deal(0) = New Microsoft.Reporting.WinForms.ReportParameter
        Params_deal(0) = New Microsoft.Reporting.WinForms.ReportParameter("line1", strLine(0), False)


        'Ds_PRD_Template_PRD_Template
        Dim dt_PRD_Template As DataSet
        dt_PRD_Template = conn.GetDataSet(strSQL_PRD_Template)

        Dim dt_e As DataSet
        dt_e = conn.GetDataSet(strSQL1)

        Dim dt_u As DataSet
        dt_u = conn.GetDataSet(strSQL2)

        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ds_template_charge_event_PRD_TemplateChargeEvents", dt_e.Tables(0)))
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ds_template_charge_unit_PRD_TemplateChargeUnits", dt_u.Tables(0)))
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("Ds_PRD_Template_PRD_Template", dt_PRD_Template.Tables(0)))
        '
        ReportViewer1.LocalReport.SetParameters(Params_deal)

        ReportViewer1.DocumentMapCollapsed = True
        ReportViewer1.ResumeLayout()
        ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        ReportViewer1.RefreshReport()

        If strLine(0) <> "" Or strFile <> strFile_TMP Then
            System.Threading.Thread.Sleep(3000)
            System.IO.File.Delete(strFile_TMP)
        End If

    End Sub

    Private Sub FrmReport_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'On Error Resume Next
        'ReportViewer1.Left = 0
        'ReportViewer1.Top = 0
        'ReportViewer1.Height = Me.Height - 5
        'ReportViewer1.Width = Me.Width - 5
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim mCls_Configuration As New Cls_Configuration
        Dim str_p As String = mCls_Configuration.ReportPath 'System.Configuration.ConfigurationSettings.AppSettings("report_path")
        ' If System.IO.Pat
        strReportPath = Replace(str_p, ".\", Application.StartupPath & "\")
        If strReportPath.Substring(strReportPath.Length - 1) <> "\" Then strReportPath += "\"
        If System.IO.Directory.Exists(strReportPath) = False Then
            MessageBox.Show("Invalid report_paht in App.config.")
            ' Application.Exit()
        End If


    End Sub

    Private Sub Reporting_template_Exists()
        conn = New CSQL
        ReportViewer1.Reset()
        Dim strFile As String = strReportPath & "rpt_Template_Exists.rdlc"

        Dim strFile_TMP As String = strReportPath & strLine(0) & ".rdlc"
        If strLine(0) = "" Then
            strFile_TMP = strReportPath & "rpt_Template_Exists.rdlc"
        Else
            System.IO.File.Copy(strFile, strFile_TMP)
            System.Threading.Thread.Sleep(1000)
        End If



        ReportViewer1.LocalReport.ReportPath = strFile_TMP


        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        ReportViewer1.DocumentMapCollapsed = True
        ReportViewer1.ResumeLayout()
        ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        ReportViewer1.LocalReport.SetParameters(Params)
        'ReportViewer1
        'strLine(0)

        ReportViewer1.Refresh()
        ReportViewer1.RefreshReport()

        If strLine(0) <> "" Or strFile <> strFile_TMP Then
            System.Threading.Thread.Sleep(3000)
            System.IO.File.Delete(strFile_TMP)
        End If

    End Sub



    Private Sub Reporting_BASE_RATES_MST()

        Dim strFile As String = strReportPath & "rpt_base_rate.rdlc"

        Dim strFile_TMP As String = strReportPath & strLine(0) & ".rdlc"
        If strLine(0) = "" Then
            strFile_TMP = strReportPath & "rpt_base_rate.rdlc"
        Else
            System.IO.File.Copy(strFile, strFile_TMP)
            System.Threading.Thread.Sleep(1000)
        End If


        conn = New CSQL
        ReportViewer1.Reset()

        ReportViewer1.LocalReport.ReportPath = strFile_TMP 'strReportPath & "rpt_template_charge_unit.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()


        Dim Params_deal(0) As Microsoft.Reporting.WinForms.ReportParameter
        If strLine(0) Is Nothing Then strLine(0) = ""
        Params_deal(0) = New Microsoft.Reporting.WinForms.ReportParameter
        Params_deal(0) = New Microsoft.Reporting.WinForms.ReportParameter("line1", strLine(0), False)


        'Ds_PRD_Template_PRD_Template
        Dim dt_BASE_RATES_MST As DataSet
        dt_BASE_RATES_MST = conn.GetDataSet(strSQL)



        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("Ds_base_rate_BASE_RATES_MST", dt_BASE_RATES_MST.Tables(0)))
  
        ReportViewer1.LocalReport.SetParameters(Params_deal)

        ReportViewer1.DocumentMapCollapsed = True
        ReportViewer1.ResumeLayout()
        ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        ReportViewer1.RefreshReport()

        If strLine(0) <> "" Or strFile <> strFile_TMP Then
            System.Threading.Thread.Sleep(3000)
            System.IO.File.Delete(strFile_TMP)
        End If

    End Sub

End Class