Public Class Form2
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox4.Checked And CheckBox1.Checked OrElse CheckBox2.Checked OrElse CheckBox9.Checked OrElse CheckBox10.Checked OrElse CheckBox17.Checked OrElse CheckBox4.Checked OrElse CheckBox16.Checked OrElse CheckBox19.Checked Then
            Me.Hide()
            Galau.ShowDialog()

        ElseIf CheckBox15.Checked And CheckBox8.Checked And CheckBox9.Checked And CheckBox4.Checked OrElse CheckBox5.Checked OrElse CheckBox3.Checked And CheckBox2.Checked OrElse CheckBox13.Checked OrElse CheckBox16.Checked OrElse CheckBox21.Checked Then
            Me.Hide()
            Depresi1.ShowDialog()

        ElseIf checkbox20.checked And CheckBox9.Checked And CheckBox15.Checked And CheckBox22.Checked And CheckBox21.Checked OrElse CheckBox11.Checked And CheckBox5.Checked OrElse CheckBox13.Checked Then
            Me.Hide()
            Depresi2.ShowDialog()

        ElseIf CheckBox24.Checked And CheckBox23.Checked And CheckBox13.Checked And CheckBox17.Checked And CheckBox11.Checked OrElse CheckBox18.Checked OrElse CheckBox6.Checked OrElse CheckBox9.Checked Then
            Me.Hide()
            Depresi3.ShowDialog()

        Else




        End If


    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Panel1.AutoScroll = True
        Panel1.VerticalScroll.Visible = False Or Panel1.HorizontalScroll.Visible = False
    End Sub
End Class