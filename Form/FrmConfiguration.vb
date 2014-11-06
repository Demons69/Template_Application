Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Microsoft.Data.ConnectionUI
Imports System.Data.SqlClient

Public Class FrmConfiguration

#Region "API Calls"
    ' standard API declarations for INI access
    ' changing only "As Long" to "As Int32" (As Integer would work also)
    Private Declare Unicode Function WritePrivateProfileString Lib "kernel32" _
    Alias "WritePrivateProfileStringW" (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpString As String, _
    ByVal lpFileName As String) As Int32

    Private Declare Unicode Function GetPrivateProfileString Lib "kernel32" _
    Alias "GetPrivateProfileStringW" (ByVal lpApplicationName As String, _
    ByVal lpKeyName As String, ByVal lpDefault As String, _
    ByVal lpReturnedString As String, ByVal nSize As Int32, _
    ByVal lpFileName As String) As Int32
#End Region

    Public Overloads Function INIRead(ByVal INIPath As String, _
    ByVal SectionName As String, ByVal KeyName As String, _
    ByVal DefaultValue As String) As String
        ' primary version of call gets single value given all parameters
        Dim n As Int32
        Dim sData As String
        sData = space$(1024) ' allocate some room 
        n = GetPrivateProfileString(SectionName, KeyName, DefaultValue, _
        sData, sData.Length, INIPath)
        If n > 0 Then ' return whatever it gave us
            INIRead = sdata.Substring(0, n)
        Else
            iniread = ""
        End If
    End Function

#Region "INIRead Overloads"
    Public Overloads Function INIRead(ByVal INIPath As String, _
    ByVal SectionName As String, ByVal KeyName As String) As String
        ' overload 1 assumes zero-length default
        Return INIRead(inipath, sectionname, KeyName, "")
    End Function

    Public Overloads Function INIRead(ByVal INIPath As String, _
    ByVal SectionName As String) As String
        ' overload 2 returns all keys in a given section of the given file
        Return INIRead(inipath, sectionname, Nothing, "")
    End Function

    Public Overloads Function INIRead(ByVal INIPath As String) As String
        ' overload 3 returns all section names given just path
        Return INIRead(inipath, Nothing, Nothing, "")
    End Function
#End Region

    Public Sub INIWrite(ByVal INIPath As String, ByVal SectionName As String, _
    ByVal KeyName As String, ByVal TheValue As String)
        Call WritePrivateProfileString(SectionName, KeyName, TheValue, INIPath)
    End Sub

    Public Overloads Sub INIDelete(ByVal INIPath As String, ByVal SectionName As String, _
    ByVal KeyName As String) ' delete single line from section
        Call WritePrivateProfileString(SectionName, KeyName, Nothing, INIPath)
    End Sub

    Public Overloads Sub INIDelete(ByVal INIPath As String, ByVal SectionName As String)
        ' delete section from INI file
        Call WritePrivateProfileString(SectionName, Nothing, Nothing, INIPath)
    End Sub

    Private Sub CheckingForm()
        Dim strFile As String = Application.StartupPath & "\configuration.ini"
        If System.IO.File.Exists(strFile) = False Then
            Dim mFrmConfiguration As New FrmConfiguration
            ' Me.Hide()
            mFrmConfiguration.ShowDialog()
        End If
    End Sub

    Private Sub FrmConfiguration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim strFile As String = Application.StartupPath & "\configuration.ini"
            If System.IO.File.Exists(strFile) = True Then
                txt_connection.Text = Decrypt_code(INIRead(strFile, "configuration", "connectionstring"))
                txt_ReportPath.Text = Decrypt_code(INIRead(strFile, "configuration", "report"))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub btn_browse_connect_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse_connect.Click
        Try
            '' tum
            ''Dim dcd As New Microsoft.Data.ConnectionUI.DataConnectionDialog
            ''Microsoft.Data.ConnectionUI.DataSource.AddStandardDataSources(dcd)
            ''If Microsoft.Data.ConnectionUI.DataConnectionDialog.Show(dcd) = Windows.Forms.DialogResult.OK Then
            ''    txt_connection.Text = dcd.ConnectionString
            ''End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btn_browse_report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse_report.Click
        Try
            If txt_ReportPath.Text <> "" Then
                FolderBrowserDialog1.SelectedPath = txt_ReportPath.Text
            Else
                FolderBrowserDialog1.SelectedPath = Application.StartupPath
            End If
            FolderBrowserDialog1.ShowDialog()

            If FolderBrowserDialog1.SelectedPath <> "" Then
                txt_ReportPath.Text = Replace(FolderBrowserDialog1.SelectedPath, Application.StartupPath, ".")
            End If
            If txt_ReportPath.Text.Substring(txt_ReportPath.Text.Length - 1) <> "\" Then txt_ReportPath.Text += "\"

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click
        Try
            Dim strFile As String = Application.StartupPath & "\configuration.ini"
            INIWrite(strFile, "configuration", "connectionstring", Encrypt_code(txt_connection.Text))
            INIWrite(strFile, "configuration", "report", Encrypt_code(txt_ReportPath.Text))
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Public Function Encrypt_code(ByVal input As String) As String
        ' Return Transform(input, m_des.CreateEncryptor(m_key, m_iv))
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(input)

        ' convert the byte array to a Base64 string

        Encrypt_code = Convert.ToBase64String(byt)
        Decrypt_code(Convert.ToBase64String(byt))
    End Function

    Public Function Decrypt_code(ByVal input As String) As String
        Decrypt_code = New System.Text.ASCIIEncoding().GetString(Convert.FromBase64String(input))
    End Function




End Class