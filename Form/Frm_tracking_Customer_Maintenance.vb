Public Class Frm_tracking_Customer_Maintenance

    Private Sub bt_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub btn_communication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_communication.Click
        Dim mFrm_tracking_Customer_communication As New Frm_tracking_Customer_communication
        mFrm_tracking_Customer_communication.ShowDialog()
    End Sub
End Class