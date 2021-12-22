


Public Class PrincipalContenedor

    Private Sub AbrirFormenPanel(ByVal FormHijo As Object)
        If Me.Panel_Central.Controls.Count > 0 Then
            Me.Panel_Central.Controls.RemoveAt(0)
        End If

        Dim fh As Form = TryCast(FormHijo, Form)
        fh.TopLevel = False

        fh.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        fh.Dock = DockStyle.None
        'fh.Dock = StartPosition.CenterScreen

        'fh.StartPosition = FormStartPosition.CenterScreen
        Me.Panel_Central.Controls.Add(fh)
        Me.Panel_Central.Tag = fh
        fh.Show()
    End Sub








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

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click

        AbrirFormenPanel(New Elementos)
    End Sub
End Class
