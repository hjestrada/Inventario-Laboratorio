Public Class Usuarios
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()


    End Sub

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles Me.Load
        ComboBox1.SelectedIndex = 0
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList


        tooltipMensaje()



    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub


    Sub tooltipMensaje()

        Dim toolTip1 As New ToolTip()
        toolTip1.ShowAlways = True
        toolTip1.SetToolTip(TextBox1, "Ingrese Numero de Indentificación (Cédula,NIT,Céduala de Extranjería).")

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        tooltipMensaje()
    End Sub

    Private Sub TextBox1_DragOver(sender As Object, e As DragEventArgs) Handles TextBox1.DragOver

    End Sub
End Class