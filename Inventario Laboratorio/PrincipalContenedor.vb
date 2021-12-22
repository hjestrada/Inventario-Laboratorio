


Public Class PrincipalContenedor



    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub

    Private Sub PrincipalContenedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        Lb_Fecha.Text = Now
    End Sub



    Private Sub IconButton8_Click(sender As Object, e As EventArgs) Handles IconButton8.Click
        Me.Close()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Lb_Fecha.Text = Now

    End Sub
End Class
