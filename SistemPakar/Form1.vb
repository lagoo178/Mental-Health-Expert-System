Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MessageBox.Show("Apakah Anda Yakin Ingin Keluar? ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If MsgBoxResult.Yes Then
            End
        Else
            Me.ShowDialog()

        End If
    End Sub
End Class
