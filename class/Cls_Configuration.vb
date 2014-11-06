Imports System.Configuration
Public Class Cls_Configuration

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
        sData = Space$(1024) ' allocate some room 
        n = GetPrivateProfileString(SectionName, KeyName, DefaultValue, _
        sData, sData.Length, INIPath)
        If n > 0 Then ' return whatever it gave us
            INIRead = sData.Substring(0, n)
        Else
            INIRead = ""
        End If
    End Function

#Region "INIRead Overloads"
    Public Overloads Function INIRead(ByVal INIPath As String, _
    ByVal SectionName As String, ByVal KeyName As String) As String
        ' overload 1 assumes zero-length default
        Return INIRead(INIPath, SectionName, KeyName, "")
    End Function

    Public Overloads Function INIRead(ByVal INIPath As String, _
    ByVal SectionName As String) As String
        ' overload 2 returns all keys in a given section of the given file
        Return INIRead(INIPath, SectionName, Nothing, "")
    End Function

    Public Overloads Function INIRead(ByVal INIPath As String) As String
        ' overload 3 returns all section names given just path
        Return INIRead(INIPath, Nothing, Nothing, "")
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

    Dim strFile As String
    Dim strReportPath As String
    Dim strConnection As String

    Private Sub CheckingForm()
        'Dim strFile As String = Application.StartupPath & "\configuration.ini"
        If System.IO.File.Exists(strFile) = False Then
            Dim mFrmConfiguration As New FrmConfiguration
            ' Me.Hide()
            mFrmConfiguration.ShowDialog()
        End If
    End Sub

    Public Sub New()
        '-- comment by tum; 11-Apr-2014
        'Call CheckingForm()
        'If System.IO.File.Exists(strFile) = True Then
        '    strConnection = Decrypt_code(INIRead(strFile, "configuration", "connectionstring"))
        '    strReportPath = Decrypt_code(INIRead(strFile, "configuration", "report"))
        'End If

        strFile = Application.StartupPath & "\configuration.ini"
        strReportPath = Application.StartupPath & ConfigurationManager.AppSettings("ReportPath").ToString()
        strConnection = ConfigurationManager.ConnectionStrings("CnnPRD").ToString

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

    Public Property ConnectionString()
        Get
            Return strConnection
        End Get
        Set(ByVal value)
            strConnection = value
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

End Class
