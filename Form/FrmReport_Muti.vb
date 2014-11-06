Public Class FrmReport_Muti

    Dim conn As CSQL
    Dim conn2 As CSQL

    Private strReportPath As String = ""
    Public strSQL1 As String = ""
    Public strSQL2 As String = ""

    Public Property ReportPath()
        Get
            Return strReportPath
        End Get
        Set(ByVal value)
            strReportPath = value
        End Set
    End Property

    Private Sub FrmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            SplitContainer1.SplitterDistance = SplitContainer1.Size.Width / 2

            Call Reporting_template_charge_event()

            Call Reporting_template_charge_Unit()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try


    End Sub



    Private Sub Reporting_template_charge_event()
        conn = New CSQL
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportPath = strReportPath & "rpt_template_charge_event.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()
        Dim dt As DataSet
        dt = conn.GetDataSet(strSQL1)
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ds_template_charge_event_PRD_TemplateChargeEvents", dt.Tables(0)))
        ReportViewer1.DocumentMapCollapsed = True
        ReportViewer1.ResumeLayout()
        ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        ReportViewer1.RefreshReport()
    End Sub

    Private Sub Reporting_template_charge_Unit()
        conn2 = New CSQL
        ReportViewer2.Reset()
        ReportViewer2.LocalReport.ReportPath = strReportPath & "rpt_template_charge_unit.rdlc"
        ReportViewer2.LocalReport.DataSources.Clear()
        Dim dt2 As DataSet
        dt2 = conn.GetDataSet(strSQL2)
        ReportViewer2.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        ReportViewer2.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ds_template_charge_unit_PRD_TemplateChargeUnits", dt2.Tables(0)))
        ReportViewer2.DocumentMapCollapsed = True
        ReportViewer2.ResumeLayout()
        ReportViewer2.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        ReportViewer2.RefreshReport()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim mCls_Configuration As New Cls_Configuration

        Dim str_p As String = mCls_Configuration.ReportPath  'System.Configuration.ConfigurationSettings.AppSettings("report_path")
        ' If System.IO.Pat
        strReportPath = Replace(str_p, ".\", Application.StartupPath & "\")
        If strReportPath.Substring(strReportPath.Length - 1) <> "\" Then strReportPath += "\"
        If System.IO.Directory.Exists(strReportPath) = False Then
            MessageBox.Show("Invalid report_paht in App.config.")
            ' Application.Exit()
        End If


    End Sub

    Private Sub FrmReport_Muti_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        On Error Resume Next
        SplitContainer1.SplitterDistance = SplitContainer1.Size.Width / 2

    End Sub
End Class