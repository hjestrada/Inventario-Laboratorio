Public Class Inventario



    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label20.Text = Now
        ComboBox1.SelectedIndex = 0
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList

        ComboBox2.SelectedIndex = 0
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList



    End Sub

    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label20.Text = Now
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub
End Class