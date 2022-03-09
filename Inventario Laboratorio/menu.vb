Public Class menu
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click

        If rolprivilegio = "Administrador" Then
            Estantes.Show()

        Else
            MsgBox("No posee suficientes Privilegios para Crear Nuevos Estantes")
        End If

    End Sub

    Private Sub IconButton10_Click(sender As Object, e As EventArgs) Handles IconButton10.Click


        If rolprivilegio = "Administrador" Then
            Fila.Show()

        Else
            MsgBox("No posee suficientes Privilegios para Crear Nuevas Filas")
        End If


    End Sub

    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles IconButton5.Click

        If rolprivilegio = "Administrador" Then

            Fabricante.Show()

        Else
            MsgBox("No posee suficientes Privilegios para Crear Nuevos Fabricantes")
        End If



    End Sub

    Private Sub IconButton6_Click(sender As Object, e As EventArgs) Handles IconButton6.Click

        If rolprivilegio = "Administrador" Then
            Pictograma.Show()

        Else
            MsgBox("No posee suficientes Privilegios para Crear Nuevos Pictogramas")
        End If

    End Sub

    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles IconButton2.Click

        If rolprivilegio = "Administrador" Then
            Sistema_Globalmente_Armonizado.Show()

        Else
            MsgBox("No posee suficientes Privilegios para Modificar los parametros  del Sistema Globalmente Armonizado validados en esta aplicación.")
        End If







    End Sub
End Class