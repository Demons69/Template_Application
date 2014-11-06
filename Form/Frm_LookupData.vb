Imports Template_Application.CSQL
Imports System.Data.SqlClient

Public Class Frm_LookupData

    Dim conn As CSQL
    Private strSQL As String = ""
    Public txtObject As TextBox

    Public Sub New(ByVal param As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        strSQL = param
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub



    Public Property SET_SQL()
        Get
            Return strSQL
        End Get
        Set(ByVal value)
            strSQL = value
        End Set
    End Property

    Private Sub Frm_LookupData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Frm_LookupData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        conn = New CSQL
        conn.Connect()
        Call SetGrid()
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Public Sub SetGrid()
        Try
            Call conn.SetGrid(strSQL, grd_data)
            If grd_data.RowCount > 0 Then
                grd_data.Rows.Item(0).Selected = True

                For i = 0 To grd_data.Columns.Count - 1
                    grd_data.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub grd_data_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd_data.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        Try
            'txtObject.Text = grd_data.CurrentRow.Cells(0).Value
            Call Selectdata()

        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub btn_select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_select.Click
        Call Selectdata()
    End Sub


    Private Sub Selectdata()
        Dim i As Integer
        Dim strData As String = ""

        If grd_data.Columns.Count <= 0 Then Exit Sub

        For i = 0 To grd_data.Columns.Count - 1
            'grd_data.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            strData += IIf(strData = "", "", "||") & grd_data.CurrentRow.Cells(i).Value
        Next
        txtObject.Text = strData
        Me.Close()
    End Sub
End Class