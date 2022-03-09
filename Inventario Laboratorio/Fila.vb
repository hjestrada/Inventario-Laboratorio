


Option Strict Off
Option Explicit On

Imports System.Runtime.InteropServices
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.IO




Public Class Fila

    Dim DB_Path As String = "Data Source=" & Application.StartupPath & "\BD_Lab.s3db;"
    Dim SQLiteCon As New SQLiteConnection(DB_Path)
    Dim SQLliteCMD As New SQLiteCommand
    Dim Imag As Byte()
    Dim consulta1 As String
    Dim lista1 As Byte
    Dim datos1 As DataSet
    Dim MySQLDA1 As New SQLiteDataAdapter





    Private Sub Fila_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList

        CargarDatos()
        CargarEstante()
        MAXID()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
                    .CommandText = " INSERT INTO FILA (`ID_FILA`, `DESCRIPCION`,`ID_ESTANTE`) VALUES (NULL, @DESCRIPCION,@ID_ESTANTE)"
                    .Connection = SQLiteCon
                    .Parameters.AddWithValue("@DESCRIPCION", Me.TextBox2.Text)
                    .Parameters.AddWithValue("@ID_ESTANTE", Me.ComboBox3.Text)


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

        Dim sql As String = "SELECT * FROM FILA"

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
        MySQLDA1.SelectCommand.CommandText = "SELECT MAX(`ID_FILA`)  AS id FROM FILA"
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






    Public Sub CargarEstante()
        Try
            SQLiteCon.Open()

            'Dim MySQLDA As New SQLiteDataAdapter("SELECT(`ID_ESTANTE` || ' | ' || `DESCRIPCION`) AS ALGO FROM ESTANTE", SQLiteCon)
            Dim MySQLDA As New SQLiteDataAdapter("SELECT `ID_ESTANTE` FROM ESTANTE", SQLiteCon)

            Dim table As New DataTable
            MySQLDA.Fill(table)
            ComboBox3.DataSource = table
            ComboBox3.ValueMember = "ID_ESTANTE"
            ComboBox3.DisplayMember = "DESCRIPCION"
            ComboBox3.SelectedIndex = 0
            SQLiteCon.Close()

        Catch ex As Exception
            MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")

        Finally
            SQLiteCon.Close()
            SQLliteCMD = Nothing
        End Try
    End Sub

    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click
        Try


            SQLiteCon.Open()
            Dim Numero As String
            Numero = InputBox("Por favor digite el Codigo de la Fila:")

            If MessageBox.Show("¿Seguro que desea eliminar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                SQLliteCMD = New SQLite.SQLiteCommand("delete from fila where ID_FILA='" & Numero & "'", SQLiteCon)
                SQLliteCMD.ExecuteNonQuery()
                CargarDatos()
                SQLiteCon.Close()
                MAXID()

            End If

        Catch ex As Exception
            MsgBox("Operación eliminar cancelada por el usuario")
        End Try
    End Sub
End Class