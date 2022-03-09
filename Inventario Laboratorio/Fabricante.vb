

Imports System.Runtime.InteropServices
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.IO


Public Class Fabricante

    Dim DB_Path As String = "Data Source=" & Application.StartupPath & "\BD_Lab.s3db;"
    Dim SQLiteCon As New SQLiteConnection(DB_Path)
    Dim SQLliteCMD As New SQLiteCommand
    Dim Imag As Byte()
    Dim consulta1 As String
    Dim lista1 As Byte
    Dim datos1 As DataSet
    Dim MySQLDA1 As New SQLiteDataAdapter


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click

        If Trim(TextBox2.Text) = "" Then
            MsgBox("¡Error! no se permiten campos vacios")

        Else
            SQLiteCon.Close()

            Try
                SQLiteCon.Open()
                SQLliteCMD = New SQLiteCommand

                With SQLliteCMD
                    .CommandText = " INSERT INTO FABRICANTE (`ID_FABRICANTE`, `NOMBRE_FAB`) VALUES (NULL, @NOMBRE_FAB)"
                    .Connection = SQLiteCon
                    .Parameters.AddWithValue("@NOMBRE_FAB", Me.TextBox2.Text)
                    .ExecuteNonQuery()
                End With

                SQLiteCon.Close()
                MsgBox("Datos Registrados Exitosamente")
                Me.TextBox2.Clear()
                CargarDatos()
                MAXID()


            Catch ex As Exception
                MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")
                SQLiteCon.Close()
                Return
            End Try
            SQLiteCon.Close()

        End If

    End Sub

    Private Sub CargarDatos()

        Dim sql As String = "SELECT `ID_FABRICANTE`, `NOMBRE_FAB` FROM FABRICANTE"

        Using con As New SQLiteConnection(DB_Path)
            Dim command As New SQLiteCommand(sql, con)
            Dim da As New SQLiteDataAdapter
            da.SelectCommand = command
            Dim dt As New DataTable
            da.Fill(dt)
            DataGridView1.DataSource = dt

        End Using
    End Sub

    Sub MAXID()

        MySQLDA1.SelectCommand = New SQLiteCommand
        MySQLDA1.SelectCommand.Connection = SQLiteCon
        MySQLDA1.SelectCommand.CommandText = "SELECT MAX(`ID_FABRICANTE`)  AS id FROM FABRICANTE"
        SQLiteCon.Open()
        Dim valorDefecto As Integer = 1
        Dim ValorRetornado As Object = MySQLDA1.SelectCommand.ExecuteScalar()

        If ValorRetornado Is DBNull.Value Then
            Label3.Text = CStr(valorDefecto)
        Else
            Label3.Text = CStr(ValorRetornado) + 1
        End If
        SQLiteCon.Close()
    End Sub

    Private Sub Fabricante_Load(sender As Object, e As EventArgs) Handles Me.Load
        MAXID()
        CargarDatos()
    End Sub

    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click
        SQLiteCon.Open()
        Dim Numero As String
        Numero = InputBox("Por favor digite el identificador del Fabricante")

        If MessageBox.Show("¿Seguro que desea eliminar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            SQLliteCMD = New SQLite.SQLiteCommand("delete from FABRICANTE where ID_FABRICANTE='" & Numero & "'", SQLiteCon)
            SQLliteCMD.ExecuteNonQuery()
            CargarDatos()
            SQLiteCon.Close()
            MAXID()

        End If
    End Sub
End Class