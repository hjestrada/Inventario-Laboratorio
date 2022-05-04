



Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Data

Imports System.Diagnostics

Imports System.Runtime.InteropServices
Imports System.Text





Public Class menu

    Dim Path As String
    Dim BackupPath As String
    Dim DatabaseName As String = "BK_InventarioLaboratorio" + Date.Now.ToString("dd-MM-yyyy HH-mm-ss")






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
    ' //--
    Private Sub IconButton2_Click(sender As Object, e As EventArgs)

        If rolprivilegio = "Administrador" Then
            Sistema_Globalmente_Armonizado.Show()

        Else
            MsgBox("No posee suficientes Privilegios para Modificar los parametros  del Sistema Globalmente Armonizado validados en esta aplicación.")
        End If


    End Sub

    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click
        '------------------------

        If rolprivilegio = "" Then

            MsgBox("Usuario Null")
            Usuarios.Show()
        Else
            If rolprivilegio = "Administrador" Then
                Usuarios.Show()

            Else
                MsgBox("No posee privilegios suficientes para gestionar Usuarios, consulte con el administrador del sistema")

            End If

        End If


    End Sub

    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click

        If rolprivilegio = "Administrador" Then
            Sistema_Globalmente_Armonizado.Show()


        Else
            MsgBox("No posee suficientes Privilegios para Modificar los parametros  del Sistema Globalmente Armonizado validados en esta aplicación.")
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub IconButton7_Click(sender As Object, e As EventArgs) Handles IconButton7.Click
        Pdf.Show()

    End Sub

End Class