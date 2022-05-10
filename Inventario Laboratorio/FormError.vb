Public Class FormError
    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        Me.Close()

    End Sub

    Private Sub FormError_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mensaje(mensaje_error)


    End Sub



    Sub mensaje(errores As String)
        TextBox1.Text = errores
    End Sub


End Class