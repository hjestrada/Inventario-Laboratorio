Public Class Pdf
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Pdf_Load(sender As Object, e As EventArgs) Handles Me.Load
        AxAcroPDF1.LoadFile(archivovisualizar)
    End Sub
End Class