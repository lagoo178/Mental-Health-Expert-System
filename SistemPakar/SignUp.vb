Imports MySql.Data.MySqlClient
Public Class SignUp
    Public lokasidata As String


    Private Sub jalankansql(ByVal sQl As String)
        Dim conn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim rd As MySqlDataReader
        Dim da As MySqlDataAdapter
        Dim ds As DataSet
        Call koneksi()

        Try

            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sQl
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conn.Close()
            MsgBox("Data Sudah Disimpan", vbInformation)
        Catch ex As Exception
            MsgBox("Tidak Bisa Menyimpan data ke Database" & ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Login.Show()
        Me.Hide()


    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim simpan As String

        Me.Cursor = Cursors.WaitCursor
        simpan = "INSERT INTO [login] VALUES('" & TextBox1.Text.ToString() & "','" & TextBox2.Text.ToString() & "','" & TextBox5.Text.ToString() & "','" & TextBox3.Text.ToString() & "','" & TextBox4.Text.ToString() & "') "
        jalankansql(simpan)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub SignUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class