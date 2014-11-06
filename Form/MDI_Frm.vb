Option Explicit On
Imports System.Data.SqlClient
Imports System.Configuration

Public Class MDI_Frm
    Private DLG_F_TP As Boolean = False
    Private DLG_CU As Frm_TemplateChargeUnit_list
    Private DLG_F_CU As Boolean = False

    Dim _imgHitArea As Point = New Point(13, 2)
    Dim _imageLocation As Point = New Point(15, 5)

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub MDI_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim appVersion As String = ConfigurationManager.AppSettings("AppVersion").ToString()
        Dim releaseDate As String = ConfigurationManager.AppSettings("ReleaseDate").ToString()
        Dim conn As New CSQL
        Dim strSQL As String = "select [version] from TB_VERSION where IsActive = 'Y'"
        Dim strVersion As String

        Try

            '-- get version from DB Srv
            strVersion = conn.GetDataFromSQL(strSQL)

            If strVersion <> appVersion Then
                MsgBox("Your template version is not current version. Please contact template help admin.")
                Exit Sub
            End If

            Me.Text = "Template Application " & " Version : " & appVersion & " - " & releaseDate
            Call GetServerName()

            Dim sLoginForm As New LoginForm
            sLoginForm.txt_userid = txt_userid
            sLoginForm.ShowDialog()
            If txt_userid.Text = "" Then
                Me.Close()
            Else
                Call SetMenuByUserName()
            End If

            Me.Text += "   Login as  : " & txt_userid.Text

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn = Nothing
        End Try

    End Sub

    Private Sub MDI_Frm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'If MsgBox("Do you want to Exit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Exit Program") = MsgBoxResult.No Then
        '    e.Cancel = True
        'Else
        '    End
        'End If
    End Sub

    Private Sub GetServerName()
        Dim str_cn_ole As String = ""
        Dim str_cn As String = ""
        Dim mCls_Configuration As New Cls_Configuration
        str_cn = mCls_Configuration.ConnectionString
        Dim csb = New SqlConnectionStringBuilder(str_cn)
        Dim strServer As String = ""
        Dim strDatabase As String = ""
        Dim strUser As String = ""
        Dim strPwd As String = ""

        strServer = csb.DataSource
        strDatabase = csb.InitialCatalog
        strUser = csb.UserID
        strPwd = csb.Password
        Me.Text += "  Server Name : " & strServer
    End Sub

    Private Sub MDI_Frm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        'If e.KeyChar = Chr(27) Then Me.Close()
    End Sub


    Private Sub SetMenuByUserName()
        mnu_b_client_1.Visible = False
        mnu_b_client_2.Visible = False
        mnu_b_template_1.Visible = False
        mnu_b_template_2.Visible = False
        '==========
        mnu_New_Client_Profile.Visible = False
        mnu_ModifyClientProfile_sub.Visible = False
        mnu_Revision_Client_Profile.Visible = False
        mnu_print_revision.Visible = False
        mnu_ClientInquiry.Visible = False

        mnu_ViewTemplateProduc.Visible = False
        mnu_ViewTemplateCharge.Visible = False
        mnu_NewTemplateProduct.Visible = False
        mnu_NewTemplateCharge.Visible = False
        mnu_PrintTemplateProduct_sub.Visible = False
        mnu_PrintTemplateCharge.Visible = False

        mnu_MyProductLibrary.Visible = False
        mnu_InterfaceMapping.Visible = False
        mnu_MaintenanceTemplateCode.Visible = False
        mnu_BaseRateLibrary.Visible = False
        mnu_user.Visible = False

        Dim strSQL As String = ""
        Dim b_client As Boolean = False
        Dim b_template As Boolean = False
        Dim b_library As Boolean = False
        Dim b_user As Boolean = False

        Dim i_permision As Integer = 0

        strSQL = ""
        strSQL += vbCrLf & " select a.*,b.menu_group "
        strSQL += vbCrLf & " from dbo.TB_USER_PERMISSION a "
        strSQL += vbCrLf & " left outer join dbo.TB_USER_MENU_MST b on b.menu_id=a.menu_id  "
        strSQL += vbCrLf & " WHERE a.[userid] ='" + txt_userid.Text.Replace("''", "'") + "'  "
        strSQL += vbCrLf & "order by b.menu_group,a.menu_id "
        Dim conn As CSQL
        conn = New CSQL
        conn.Connect()


        Dim res As SqlDataReader

        res = conn.GetDataReader(strSQL)

        If res.HasRows = True Then
            While (res.Read())

                Select Case res("menu_group").ToString
                    Case "client"
                        b_client = True
                    Case "library"
                        b_library = True
                    Case "template"
                        b_template = True
                    Case "user"
                        b_user = True
                    Case Else
                End Select

                Select Case res("menu_id").ToString
                    '========client===========
                    Case "CLN001" 'New Client Profile
                        mnu_New_Client_Profile.Visible = True

                    Case "CLN002" 'Modify Client Profile
                        mnu_ModifyClientProfile_sub.Visible = True

                    Case "CLN003" 'Revision Client Profile
                        mnu_Revision_Client_Profile.Visible = True

                    Case "CLN004" 'Print Revision Client Profile
                        mnu_print_revision.Visible = True
                        mnu_b_client_1.Visible = True
                    Case "CLN005" 'Client Inquiry
                        mnu_ClientInquiry.Visible = True
                        mnu_b_client_2.Visible = True
                        '=====template================
                    Case "TMP001" 'View Template Product
                        mnu_ViewTemplateProduc.Visible = True

                    Case "TMP002" 'View Template Charge
                        mnu_ViewTemplateCharge.Visible = True

                    Case "TMP003" 'New Template Product
                        mnu_NewTemplateProduct.Visible = True
                        mnu_b_template_1.Visible = True

                    Case "TMP004" 'New Template Charge
                        mnu_NewTemplateCharge.Visible = True
                        mnu_b_template_1.Visible = True

                    Case "TMP005" 'Print Template Charge
                        mnu_PrintTemplateProduct_sub.Visible = True
                        mnu_b_template_2.Visible = True

                    Case "TMP006" 'Print Template Charge
                        mnu_PrintTemplateCharge.Visible = True
                        mnu_b_template_2.Visible = True

                        '======library============
                    Case "LIB001" 'My Product Library
                        mnu_MyProductLibrary.Visible = True
                    Case "LIB002" 'Interface Mapping Library
                        mnu_InterfaceMapping.Visible = True
                    Case "LIB003" 'Maintenance Template Code
                        mnu_MaintenanceTemplateCode.Visible = True
                    Case "LIB004" 'Base Rate Library
                        mnu_BaseRateLibrary.Visible = True
                        '===============user=======
                    Case "USR001" 'User Maintenance
                        mnu_user.Visible = True


                    Case Else

                End Select

            End While

            '============set visibled main menu

            If b_client = False Then
                mnu_Modify_Client_Profile.Visible = False
                mnu_l_client.Visible = False
            Else
                mnu_Modify_Client_Profile.Visible = True
                mnu_l_client.Visible = True
            End If

            If b_library = False Then
                mnu_library_main.Visible = False
                mnu_l_library.Visible = False
            Else
                mnu_library_main.Visible = True
                mnu_l_library.Visible = True
            End If

            If b_template = False Then
                mnu_template_main.Visible = False
                mnu_l_template.Visible = False
            Else
                mnu_template_main.Visible = True
                mnu_l_template.Visible = True
            End If

            If b_user = False Then
                mnu_user_main.Visible = False
                mnu_l_user.Visible = False
            Else
                mnu_user_main.Visible = True
                mnu_l_user.Visible = True
            End If

        End If

        conn.Close()

    End Sub

    Private Sub ImportDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mFrm_ImportData As New Frm_ImportData
        Frm_ImportData.ShowDialog()
    End Sub

    Private Sub RestoreDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mFrm_RestoreData As New Frm_RestoreData
        mFrm_RestoreData.ShowDialog()

    End Sub

    Private Sub mnu_New_Client_Profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_New_Client_Profile.Click
        Dim mFrm_DealSummary_main As New Frm_DealSummary_main
        mFrm_DealSummary_main.lb_head.Text = "DEAL SUMMARY (NEW)"
        mFrm_DealSummary_main.rad_new.Checked = True
        mFrm_DealSummary_main.txt_userid.Text = txt_userid.Text
        mFrm_DealSummary_main.strMODE = "ADD"
        mFrm_DealSummary_main.ShowDialog()
    End Sub

    Private Sub ModifyClientProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ModifyClientProfile_sub.Click
        Dim mFrm_DealSummary_main As New Frm_DealSummary_main
        mFrm_DealSummary_main.lb_head.Text = "DEAL SUMMARY (MODIFY DRAFT)"
        mFrm_DealSummary_main.rad_new.Checked = True
        mFrm_DealSummary_main.txt_userid.Text = txt_userid.Text
        mFrm_DealSummary_main.strMODE = "EDIT"
        mFrm_DealSummary_main.ShowDialog()
    End Sub

    Private Sub ToolStripDropDownButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDropDownButton7.Click
        Me.Close()
    End Sub

    Private Sub mnu_Revision_Client_Profile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_Revision_Client_Profile.Click
        Dim mFrm_DealSummary_main As New Frm_DealSummary_main
        mFrm_DealSummary_main.lb_head.Text = "DEAL SUMMARY (REVISION)"
        mFrm_DealSummary_main.rad_revision.Checked = True
        mFrm_DealSummary_main.txt_userid.Text = txt_userid.Text
        mFrm_DealSummary_main.strMODE = "REVISION"
        mFrm_DealSummary_main.ShowDialog()
    End Sub

    Private Sub mnu_print_revision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_print_revision.Click
        Dim mFrm_DealSummary_Revision_Print As New Frm_DealSummary_Revision_Print
        mFrm_DealSummary_Revision_Print.txt_userid.Text = txt_userid.Text
        mFrm_DealSummary_Revision_Print.ShowDialog()
    End Sub

    Private Sub mnu_ViewTemplateProduc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ViewTemplateProduc.Click
        Dim mFrm_TemplateProduct_list As New Frm_TemplateProduct_list
        mFrm_TemplateProduct_list.ShowDialog()

    End Sub

    Private Sub mnu_ViewTemplateCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ViewTemplateCharge.Click

        Dim mFrm_TemplateChargeUnit As New Frm_TemplateChargeUnit_list
        mFrm_TemplateChargeUnit.ShowDialog()

    End Sub


    Private Sub PrintTemplateProductToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_PrintTemplateProduct_sub.Click
        Dim mFrm_Print_TemplateProduct As New Frm_Print_TemplateProduct
        mFrm_Print_TemplateProduct.ShowDialog()
    End Sub

    Private Sub mnu_PrintTemplateCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_PrintTemplateCharge.Click
        Dim mFrm_Print_TemplateCharge As New Frm_Print_TemplateCharge
        mFrm_Print_TemplateCharge.ShowDialog()
    End Sub

    Private Sub mnu_MyProductLibrary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_MyProductLibrary.Click
        Dim mFrm_DealSummary_Product_Library As New Frm_DealSummary_Product_Library
        mFrm_DealSummary_Product_Library.ShowDialog()
    End Sub

    Private Sub mnu_InterfaceMapping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_InterfaceMapping.Click
        Dim mFrm_DealSummary_Interface_Mnt_List As New Frm_DealSummary_Interface_Mnt_List
        mFrm_DealSummary_Interface_Mnt_List.ShowDialog()
    End Sub

    Private Sub mnu_MaintenanceTemplateCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_MaintenanceTemplateCode.Click
        Dim mFrm_Maintainance_Status As New Frm_Maintainance_Status_List
        mFrm_Maintainance_Status.ShowDialog()
    End Sub

    Private Sub mnu_BaseRateLibrary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_BaseRateLibrary.Click
        Dim mFrm_BaseRate_List As New Frm_BaseRate_List
        mFrm_BaseRate_List.ShowDialog()
    End Sub

    Private Sub mnu_NewTemplateProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_NewTemplateProduct.Click

        Dim mFrm_TemplateProduct_Select As New Frm_TemplateProduct_Edit
        Frm_TemplateProduct_Select.ShowDialog()
    End Sub

    Private Sub mnu_NewTemplateCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_NewTemplateCharge.Click
        Dim mFrm_TemplateChargeUnit_Select As New Frm_TemplateChargeUnit_Select
        mFrm_TemplateChargeUnit_Select.ShowDialog()
    End Sub


    Private Sub mnu_user_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_user.Click
        Dim mfrm_user_list As New frm_user_list
        mfrm_user_list.ShowDialog()
        Call SetMenuByUserName()
    End Sub

    Private Sub mnu_ClientInquiry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ClientInquiry.Click
        'Dim mFrm_Client_List As New Frm_Client_List
        'Frm_Client_List.ShowDialog()

        'Dim mFrm_DealSummary_main As New Frm_DealSummary_main
        'mFrm_DealSummary_main.lb_head.Text = "DEAL SUMMARY (MODIFY DRAFT)"
        'mFrm_DealSummary_main.rad_new.Checked = True
        'mFrm_DealSummary_main.strMODE = "EDIT"
        'mFrm_DealSummary_main.ShowDialog()

        Dim mFrm_DealSummary_main As New Frm_DealSummary_main
        mFrm_DealSummary_main.lb_head.Text = "CLIENT INQUERY"
        mFrm_DealSummary_main.rad_new.Checked = True
        mFrm_DealSummary_main.bIsViewOnly = True
        mFrm_DealSummary_main.SetFormViewOnly()
        mFrm_DealSummary_main.strMODE = "EDIT"
        mFrm_DealSummary_main.ShowDialog()

    End Sub

    Private Sub mnu_task_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_task.Click
        Dim mFrm_tracking_task As New Frm_tracking_task
        Frm_tracking_task.ShowDialog()

    End Sub

    Private Sub mnu_customer_tracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_customer_tracking.Click
        Dim mFrm_tracking_Customer_Maintenance As New Frm_tracking_Customer_Maintenance
        mFrm_tracking_Customer_Maintenance.ShowDialog()

    End Sub

    Private Sub LoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadToolStripMenuItem.Click
        Dim _companyID As String
        Dim objClient As New Frm_Client_List
        Dim objSynMaster As SynMaster
        Dim rows As Integer
        Dim cur As Cursor
        Try

            ''-- search company id
            objClient.ShowDialog()
            _companyID = objClient.CompanyID

            If MessageBox.Show("Do you want to get the " & _companyID & " data from GCP. Current data will be overwritten." _
                , "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                cur = Cursors.WaitCursor
                Me.Cursor = cur

                ''=========================
                objSynMaster = New SynMaster
                rows = objSynMaster.GetNewData(_companyID)

                If rows > 0 Then
                    MessageBox.Show(_companyID & " : " & rows & " row(s) has been updated.", "Information", MessageBoxButtons.OK)
                Else
                    MessageBox.Show("The package data is not available!!", "Contact Admin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If

        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub XxxxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XxxxToolStripMenuItem.Click

        Dim objTemplateChg As New Frm_TemplateChargeUnit_list_pre_entry
        objTemplateChg.Show()

    End Sub


End Class

'Private Sub MDI_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'    'My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
'    'My.Application.Info.Title
'    Dim appVersion As String = ConfigurationManager.AppSettings("AppVersion").ToString()
'    Dim releaseDate As String = ConfigurationManager.AppSettings("ReleaseDate").ToString()
'    Dim strFile As String = Application.StartupPath & "\configuration.ini"

'    Me.Text = "Template Application " & " Version : " & appVersion & " - " & releaseDate

'    If System.IO.File.Exists(strFile) = False Then
'        Dim mFrmConfiguration As New FrmConfiguration
'        ' Me.Hide()
'        mFrmConfiguration.ShowDialog()
'        End

'    Else
'        'TB_VERSION
'        Dim conn As New CSQL
'        Dim strSQL As String = "select a.[version] as [version] from dbo.TB_VERSION a"
'        Dim strVersion As String = ""
'        strVersion = conn.GetDataFromSQL(strSQL)
'        If strVersion <> "0.27" Then
'            MsgBox("Your template version is not current version. Please contact template help admin.")
'        End If
'        conn = Nothing
'    End If

'    Call GetServerName()

'    Dim sLoginForm As New LoginForm
'    sLoginForm.txt_userid = txt_userid
'    sLoginForm.ShowDialog()
'    If txt_userid.Text = "" Then
'        Me.Close()
'    Else
'        Call SetMenuByUserName()
'    End If

'    Me.Text += "   Login as  : " & txt_userid.Text
'End Sub