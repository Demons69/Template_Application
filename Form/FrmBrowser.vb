Public Class FrmBrowser

    Private Sub btnUploadAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadAddress.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Title = "Open File Dialog"
        OpenFileDialog1.InitialDirectory = Application.StartupPath


        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName <> "" Then
            'WebBrowser1.Site = OpenFileDialog1.FileName
        End If

    End Sub
End Class