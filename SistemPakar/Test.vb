Imports MySql.Data.MySqlClient

Public Class Test
    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Dim idkonsultasi, idt, idp, npenyakit, hasil As String
    Dim tanggal As Date
    Dim jgejala, jyes As Integer

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
    Sub kodeOtomatis()

        comtest = New MySqlCommand("select*from konsultasi order by idkonsultasi desc", conn)
        drtest = comtest.ExecuteReader
        If drtest.HasRows Then
            idkonsultasi = Microsoft.VisualBasic.Right("0000" & Trim(str(Val(Microsoft.VisualBasic.Right(drtest.Item(0), 5)) + 1)), 5)
        Else
            idkonsultasi = "00001"
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Laki - Laki" Then

        ElseIf ComboBox1.SelectedItem = "Perempuan" Then

        End If
    End Sub

    Private Sub Test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()

        tampilgrid()

        kodeOtomatis()

        tanggal = Now.Date
    End Sub

    Sub tampilgrid()

        Dim ch As New DataGridViewCheckBoxColumn

        'menampilkan data di gridview
        da = New MySqlDataAdapter("SELECT idt, ntanda FROM tanda", conn)
        ds = New DataSet
        datanda = New MySqlDataAdapter("SELECT idt, ntanda FROM tanda order by tanda asc", conn)
        dttanda = New DataTable
        da.Fill(ds, "tanda")
        DataGridView1.DataSource = ds.Tables("tanda")

        'menaruh checkbox di grid
        DataGridView1.Columns.Add(ch)

        'mengatur judul
        DataGridView1.Columns(0).HeaderText = "ID Tanda Gejala"
        DataGridView1.Columns(1).HeaderText = "Nama Tanda Gejala"
        DataGridView1.Columns(2).HeaderText = ""

        'mengatur lebar kolom
        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 80

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim i As Integer
        For i = 0 To DataGridView1.Rows.Count() - 1


            Dim chk As Boolean
            chk = CBool(DataGridView1.Rows(i).Cells(0).Value)

            If chk = True Then

                idt = DataGridView1.Rows(i).Cells(1).Value

                'MsgBox(dgkonsultasi.Rows(i).Cells(1).Value)

                'proses simpan detail konsultasi
                comtest = New MySqlCommand("insert into konsultasi1 values('" & idkonsultasi & "','" & idt & "')", conn)
                comtest.ExecuteNonQuery()

            End If
        Next

        'mencari jumlah gejala pada konsultasi
        conn.Open()

        comtest = New MySqlCommand("select count(idt) from konsultasi1 where idkonsultasi='" & idkonsultasi & "'", conn)
        drtest = comtest.ExecuteReader
        If drtest.HasRows Then
            jgejala = drtest.Item(0)
        Else
            MsgBox("Penyakit tidak ditemukan", , "Perhatian")
            Return
        End If

        'mencari jumlah gejala yg sama di aturan dengan pada saat konsultasi
        comaturan = New MySqlCommand("select idp,npenyakit from view_aturan group by npenyakit having count(idt)='" & jgejala & "'", conn)
        draturan = comaturan.ExecuteReader
        If draturan.HasRows Then

            Do While draturan.Read
                idp = draturan.Item(0)
                npenyakit = draturan.Item(1)
                hasil = draturan.Item(2)

                jyes = 0

                'mencari gejala per penyakit
                comaturan2 = New MySqlCommand("select idt from view_aturan where idp='" & idp & "'", conn)
                draturan2 = comaturan2.ExecuteReader
                If draturan2.HasRows Then

                    Do While draturan2.Read

                        idt = draturan2.Item(0)

                        comtest = New MySqlCommand("select*from konsultasi1 where idkonsultasi='" & idkonsultasi & "' and idt='" & idt & "'", conn)
                        drtest = comtest.ExecuteReader
                        If drtest.HasRows Then
                            jyes = jyes + 1
                        End If

                        'proses membandingkan jumlah konsultasi dan aturan
                        If jyes = jgejala Then
                            'proses simpan ke konsultasi, penyakit ditemukan
                            comtest = New MySqlCommand("insert into konsultasi values('" & idkonsultasi & "','" & Format(tanggal, "yyyy-MM-dd") & "','" & TextBox1.Text & "','" & TextBox1.Text & "','" & ComboBox1.SelectedItem.ToString() & "','" & DateTimePicker1.Value().ToString() & "','" & npenyakit & "')", conn)
                            comtest.ExecuteNonQuery()
                            GoTo SELESAI
                        End If
                    Loop
                    draturan2.NextResult()
                End If
            Loop
            draturan.NextResult()

            'proses simpan ke konsultasi , tidak ditemukan
            comtest = New MySqlCommand("insert into konsultasi values('" & idkonsultasi & "','" & Format(tanggal, "yyyy-MM-dd") & "','" & TextBox1.Text & "','" & TextBox1.Text & "','" & ComboBox1.SelectedItem.ToString() & "','" & DateTimePicker1.Value().ToString() & "','tidak ditemukan','-')", conn)
            comtest.ExecuteNonQuery()

        Else
            MsgBox("Penyakit tidak ditemukan", , "Perhatian")

            Close()
        End If


SELESAI:
        comtest = New MySqlCommand("select hasil, from konsultasi where idkonsultasi='" & idkonsultasi & "'", conn)
        drtest = comtest.ExecuteReader
        If drtest.HasRows Then
            MsgBox("Penyakit : " & drtest.Item(0) & vbCrLf)
        End If

        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        MenuUtama.ShowDialog()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class