<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDI_Frm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.mnu_Modify_Client_Profile = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnu_New_Client_Profile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_ModifyClientProfile_sub = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_Revision_Client_Profile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_b_client_1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnu_print_revision = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_b_client_2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnu_ClientInquiry = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_l_client = New System.Windows.Forms.ToolStripSeparator
        Me.mnu_template_main = New System.Windows.Forms.ToolStripSplitButton
        Me.mnu_ViewTemplateProduc = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_ViewTemplateCharge = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_b_template_1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnu_NewTemplateProduct = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_NewTemplateCharge = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_b_template_2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnu_PrintTemplateProduct_sub = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_PrintTemplateCharge = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_l_template = New System.Windows.Forms.ToolStripSeparator
        Me.mnu_library_main = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnu_MyProductLibrary = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_InterfaceMapping = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_MaintenanceTemplateCode = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_BaseRateLibrary = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_l_library = New System.Windows.Forms.ToolStripSeparator
        Me.mnu_user_main = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnu_user = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_l_user = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnu_task = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_task_status = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_task_result = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_reason = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_error_message = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnu_customer_tracking = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripDropDownButton7 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.txt_userid = New System.Windows.Forms.TextBox
        Me.NewClientProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_ModifyClientProfile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_RevisionClientProfile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_PrintRevisionClientProfile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_NewClientProfile = New System.Windows.Forms.ToolStripDropDownButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.XxxxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(89, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(60, 60)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_Modify_Client_Profile, Me.mnu_l_client, Me.mnu_template_main, Me.mnu_l_template, Me.mnu_library_main, Me.mnu_l_library, Me.mnu_user_main, Me.mnu_l_user, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripDropDownButton7, Me.ToolStripSeparator11})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(870, 82)
        Me.ToolStrip2.TabIndex = 8
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'mnu_Modify_Client_Profile
        '
        Me.mnu_Modify_Client_Profile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.mnu_Modify_Client_Profile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_New_Client_Profile, Me.mnu_ModifyClientProfile_sub, Me.mnu_Revision_Client_Profile, Me.mnu_b_client_1, Me.mnu_print_revision, Me.mnu_b_client_2, Me.mnu_ClientInquiry, Me.LoadToolStripMenuItem})
        Me.mnu_Modify_Client_Profile.Image = Global.Template_Application.My.Resources.Resources.import
        Me.mnu_Modify_Client_Profile.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.mnu_Modify_Client_Profile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnu_Modify_Client_Profile.Name = "mnu_Modify_Client_Profile"
        Me.mnu_Modify_Client_Profile.Size = New System.Drawing.Size(73, 79)
        Me.mnu_Modify_Client_Profile.Text = "Client  "
        Me.mnu_Modify_Client_Profile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnu_New_Client_Profile
        '
        Me.mnu_New_Client_Profile.Name = "mnu_New_Client_Profile"
        Me.mnu_New_Client_Profile.Size = New System.Drawing.Size(217, 22)
        Me.mnu_New_Client_Profile.Text = "New Client Profile"
        '
        'mnu_ModifyClientProfile_sub
        '
        Me.mnu_ModifyClientProfile_sub.Name = "mnu_ModifyClientProfile_sub"
        Me.mnu_ModifyClientProfile_sub.Size = New System.Drawing.Size(217, 22)
        Me.mnu_ModifyClientProfile_sub.Text = "Modify Client Profile"
        '
        'mnu_Revision_Client_Profile
        '
        Me.mnu_Revision_Client_Profile.Name = "mnu_Revision_Client_Profile"
        Me.mnu_Revision_Client_Profile.Size = New System.Drawing.Size(217, 22)
        Me.mnu_Revision_Client_Profile.Text = "Revision Client Profile"
        '
        'mnu_b_client_1
        '
        Me.mnu_b_client_1.Name = "mnu_b_client_1"
        Me.mnu_b_client_1.Size = New System.Drawing.Size(214, 6)
        '
        'mnu_print_revision
        '
        Me.mnu_print_revision.Name = "mnu_print_revision"
        Me.mnu_print_revision.Size = New System.Drawing.Size(217, 22)
        Me.mnu_print_revision.Text = "Print Revision Client Profile"
        '
        'mnu_b_client_2
        '
        Me.mnu_b_client_2.Name = "mnu_b_client_2"
        Me.mnu_b_client_2.Size = New System.Drawing.Size(214, 6)
        '
        'mnu_ClientInquiry
        '
        Me.mnu_ClientInquiry.Name = "mnu_ClientInquiry"
        Me.mnu_ClientInquiry.Size = New System.Drawing.Size(217, 22)
        Me.mnu_ClientInquiry.Text = "Client Inquiry"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.LoadToolStripMenuItem.Text = "Update data via GCP"
        '
        'mnu_l_client
        '
        Me.mnu_l_client.Name = "mnu_l_client"
        Me.mnu_l_client.Size = New System.Drawing.Size(6, 82)
        '
        'mnu_template_main
        '
        Me.mnu_template_main.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_ViewTemplateProduc, Me.mnu_ViewTemplateCharge, Me.mnu_b_template_1, Me.mnu_NewTemplateProduct, Me.mnu_NewTemplateCharge, Me.mnu_b_template_2, Me.mnu_PrintTemplateProduct_sub, Me.mnu_PrintTemplateCharge, Me.ToolStripSeparator2, Me.XxxxToolStripMenuItem})
        Me.mnu_template_main.Image = Global.Template_Application.My.Resources.Resources.create
        Me.mnu_template_main.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnu_template_main.Name = "mnu_template_main"
        Me.mnu_template_main.Size = New System.Drawing.Size(76, 79)
        Me.mnu_template_main.Text = "Template"
        Me.mnu_template_main.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnu_ViewTemplateProduc
        '
        Me.mnu_ViewTemplateProduc.Name = "mnu_ViewTemplateProduc"
        Me.mnu_ViewTemplateProduc.Size = New System.Drawing.Size(197, 22)
        Me.mnu_ViewTemplateProduc.Text = "View Template Product"
        '
        'mnu_ViewTemplateCharge
        '
        Me.mnu_ViewTemplateCharge.Name = "mnu_ViewTemplateCharge"
        Me.mnu_ViewTemplateCharge.Size = New System.Drawing.Size(197, 22)
        Me.mnu_ViewTemplateCharge.Text = "View Template Charge"
        '
        'mnu_b_template_1
        '
        Me.mnu_b_template_1.Name = "mnu_b_template_1"
        Me.mnu_b_template_1.Size = New System.Drawing.Size(194, 6)
        '
        'mnu_NewTemplateProduct
        '
        Me.mnu_NewTemplateProduct.Name = "mnu_NewTemplateProduct"
        Me.mnu_NewTemplateProduct.Size = New System.Drawing.Size(197, 22)
        Me.mnu_NewTemplateProduct.Text = "New Template Product"
        '
        'mnu_NewTemplateCharge
        '
        Me.mnu_NewTemplateCharge.Name = "mnu_NewTemplateCharge"
        Me.mnu_NewTemplateCharge.Size = New System.Drawing.Size(197, 22)
        Me.mnu_NewTemplateCharge.Text = "New Template Charge"
        '
        'mnu_b_template_2
        '
        Me.mnu_b_template_2.Name = "mnu_b_template_2"
        Me.mnu_b_template_2.Size = New System.Drawing.Size(194, 6)
        '
        'mnu_PrintTemplateProduct_sub
        '
        Me.mnu_PrintTemplateProduct_sub.Name = "mnu_PrintTemplateProduct_sub"
        Me.mnu_PrintTemplateProduct_sub.Size = New System.Drawing.Size(197, 22)
        Me.mnu_PrintTemplateProduct_sub.Text = "Print Template Product"
        '
        'mnu_PrintTemplateCharge
        '
        Me.mnu_PrintTemplateCharge.Name = "mnu_PrintTemplateCharge"
        Me.mnu_PrintTemplateCharge.Size = New System.Drawing.Size(197, 22)
        Me.mnu_PrintTemplateCharge.Text = "Print Template Charge"
        '
        'mnu_l_template
        '
        Me.mnu_l_template.Name = "mnu_l_template"
        Me.mnu_l_template.Size = New System.Drawing.Size(6, 82)
        '
        'mnu_library_main
        '
        Me.mnu_library_main.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_MyProductLibrary, Me.mnu_InterfaceMapping, Me.mnu_MaintenanceTemplateCode, Me.mnu_BaseRateLibrary})
        Me.mnu_library_main.Image = Global.Template_Application.My.Resources.Resources.Download_icon
        Me.mnu_library_main.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnu_library_main.Name = "mnu_library_main"
        Me.mnu_library_main.Size = New System.Drawing.Size(73, 79)
        Me.mnu_library_main.Text = "Library"
        Me.mnu_library_main.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnu_MyProductLibrary
        '
        Me.mnu_MyProductLibrary.Name = "mnu_MyProductLibrary"
        Me.mnu_MyProductLibrary.Size = New System.Drawing.Size(227, 22)
        Me.mnu_MyProductLibrary.Text = "My Product Library"
        '
        'mnu_InterfaceMapping
        '
        Me.mnu_InterfaceMapping.Name = "mnu_InterfaceMapping"
        Me.mnu_InterfaceMapping.Size = New System.Drawing.Size(227, 22)
        Me.mnu_InterfaceMapping.Text = "Interface Mapping Library"
        '
        'mnu_MaintenanceTemplateCode
        '
        Me.mnu_MaintenanceTemplateCode.Name = "mnu_MaintenanceTemplateCode"
        Me.mnu_MaintenanceTemplateCode.Size = New System.Drawing.Size(227, 22)
        Me.mnu_MaintenanceTemplateCode.Text = "Maintenance Template Code"
        '
        'mnu_BaseRateLibrary
        '
        Me.mnu_BaseRateLibrary.Name = "mnu_BaseRateLibrary"
        Me.mnu_BaseRateLibrary.Size = New System.Drawing.Size(227, 22)
        Me.mnu_BaseRateLibrary.Text = "Base Rate Library"
        '
        'mnu_l_library
        '
        Me.mnu_l_library.Name = "mnu_l_library"
        Me.mnu_l_library.Size = New System.Drawing.Size(6, 82)
        '
        'mnu_user_main
        '
        Me.mnu_user_main.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_user})
        Me.mnu_user_main.Image = Global.Template_Application.My.Resources.Resources.import
        Me.mnu_user_main.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnu_user_main.Name = "mnu_user_main"
        Me.mnu_user_main.Size = New System.Drawing.Size(73, 79)
        Me.mnu_user_main.Text = "User"
        Me.mnu_user_main.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnu_user
        '
        Me.mnu_user.Name = "mnu_user"
        Me.mnu_user.Size = New System.Drawing.Size(169, 22)
        Me.mnu_user.Text = "User Maintenance"
        '
        'mnu_l_user
        '
        Me.mnu_l_user.Name = "mnu_l_user"
        Me.mnu_l_user.Size = New System.Drawing.Size(6, 82)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_task, Me.mnu_task_status, Me.mnu_task_result, Me.mnu_reason, Me.mnu_error_message, Me.ToolStripMenuItem2, Me.mnu_customer_tracking})
        Me.ToolStripButton1.Image = Global.Template_Application.My.Resources.Resources.Preview
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(73, 79)
        Me.ToolStripButton1.Text = "Tracking"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton1.Visible = False
        '
        'mnu_task
        '
        Me.mnu_task.Name = "mnu_task"
        Me.mnu_task.Size = New System.Drawing.Size(175, 22)
        Me.mnu_task.Text = "Task"
        Me.mnu_task.Visible = False
        '
        'mnu_task_status
        '
        Me.mnu_task_status.Name = "mnu_task_status"
        Me.mnu_task_status.Size = New System.Drawing.Size(175, 22)
        Me.mnu_task_status.Text = "Task Status"
        Me.mnu_task_status.Visible = False
        '
        'mnu_task_result
        '
        Me.mnu_task_result.Name = "mnu_task_result"
        Me.mnu_task_result.Size = New System.Drawing.Size(175, 22)
        Me.mnu_task_result.Text = "Task Result"
        Me.mnu_task_result.Visible = False
        '
        'mnu_reason
        '
        Me.mnu_reason.Name = "mnu_reason"
        Me.mnu_reason.Size = New System.Drawing.Size(175, 22)
        Me.mnu_reason.Text = "Reason"
        Me.mnu_reason.Visible = False
        '
        'mnu_error_message
        '
        Me.mnu_error_message.Name = "mnu_error_message"
        Me.mnu_error_message.Size = New System.Drawing.Size(175, 22)
        Me.mnu_error_message.Text = "Error Message"
        Me.mnu_error_message.Visible = False
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(172, 6)
        Me.ToolStripMenuItem2.Visible = False
        '
        'mnu_customer_tracking
        '
        Me.mnu_customer_tracking.Name = "mnu_customer_tracking"
        Me.mnu_customer_tracking.Size = New System.Drawing.Size(175, 22)
        Me.mnu_customer_tracking.Text = "Customer Tracking"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 82)
        Me.ToolStripSeparator1.Visible = False
        '
        'ToolStripDropDownButton7
        '
        Me.ToolStripDropDownButton7.Image = Global.Template_Application.My.Resources.Resources.close1
        Me.ToolStripDropDownButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton7.Name = "ToolStripDropDownButton7"
        Me.ToolStripDropDownButton7.Size = New System.Drawing.Size(73, 79)
        Me.ToolStripDropDownButton7.Text = "Exit"
        Me.ToolStripDropDownButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 82)
        '
        'txt_userid
        '
        Me.txt_userid.Location = New System.Drawing.Point(525, 12)
        Me.txt_userid.Name = "txt_userid"
        Me.txt_userid.Size = New System.Drawing.Size(100, 20)
        Me.txt_userid.TabIndex = 10
        Me.txt_userid.Visible = False
        '
        'NewClientProfileToolStripMenuItem
        '
        Me.NewClientProfileToolStripMenuItem.Name = "NewClientProfileToolStripMenuItem"
        Me.NewClientProfileToolStripMenuItem.Size = New System.Drawing.Size(67, 22)
        '
        'mnu_ModifyClientProfile
        '
        Me.mnu_ModifyClientProfile.Name = "mnu_ModifyClientProfile"
        Me.mnu_ModifyClientProfile.Size = New System.Drawing.Size(67, 22)
        '
        'mnu_RevisionClientProfile
        '
        Me.mnu_RevisionClientProfile.Name = "mnu_RevisionClientProfile"
        Me.mnu_RevisionClientProfile.Size = New System.Drawing.Size(67, 22)
        '
        'mnu_PrintRevisionClientProfile
        '
        Me.mnu_PrintRevisionClientProfile.Name = "mnu_PrintRevisionClientProfile"
        Me.mnu_PrintRevisionClientProfile.Size = New System.Drawing.Size(67, 22)
        '
        'mnu_NewClientProfile
        '
        Me.mnu_NewClientProfile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewClientProfileToolStripMenuItem, Me.mnu_ModifyClientProfile, Me.mnu_RevisionClientProfile, Me.mnu_PrintRevisionClientProfile})
        Me.mnu_NewClientProfile.Image = Global.Template_Application.My.Resources.Resources.import
        Me.mnu_NewClientProfile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnu_NewClientProfile.Name = "mnu_NewClientProfile"
        Me.mnu_NewClientProfile.Size = New System.Drawing.Size(63, 22)
        Me.mnu_NewClientProfile.Text = "Client"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(194, 6)
        '
        'XxxxToolStripMenuItem
        '
        Me.XxxxToolStripMenuItem.Name = "XxxxToolStripMenuItem"
        Me.XxxxToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.XxxxToolStripMenuItem.Text = "xxxx"
        '
        'MDI_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 311)
        Me.Controls.Add(Me.txt_userid)
        Me.Controls.Add(Me.ToolStrip2)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "MDI_Frm"
        Me.Text = "Template-GCP"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents mnu_template_main As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents mnu_ViewTemplateProduc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_ViewTemplateCharge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_NewTemplateProduct As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_NewTemplateCharge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_PrintTemplateProduct_sub As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewClientProfileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_ModifyClientProfile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_RevisionClientProfile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_PrintRevisionClientProfile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_NewClientProfile As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnu_Modify_Client_Profile As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnu_library_main As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownButton7 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnu_l_client As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_l_template As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_l_library As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_b_template_1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_b_template_2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_PrintTemplateCharge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_New_Client_Profile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_ModifyClientProfile_sub As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_Revision_Client_Profile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_b_client_1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_print_revision As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_MyProductLibrary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_InterfaceMapping As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_MaintenanceTemplateCode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_BaseRateLibrary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_user_main As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnu_user As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_l_user As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txt_userid As System.Windows.Forms.TextBox
    Friend WithEvents mnu_b_client_2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_ClientInquiry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnu_task As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_task_status As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_task_result As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_reason As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_error_message As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_customer_tracking As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents XxxxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
