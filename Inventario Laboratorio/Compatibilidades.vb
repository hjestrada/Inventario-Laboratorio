Imports System.Runtime.InteropServices
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.IO







Public Class Sistema_Globalmente_Armonizado


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



    Private Sub Sistema_Globalmente_Armonizado_Load(sender As Object, e As EventArgs) Handles Me.Load
        ComboBox1.SelectedIndex = 0
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox5.SelectedIndex = 0
        ComboBox5.DropDownStyle = ComboBoxStyle.DropDownList

        CargarPictogramas()
        CargarPictogramas2()

    End Sub



    Public Sub CargarPictogramas()

        Try

            SQLiteCon.Open()

            'Dim MySQLDA As New SQLiteDataAdapter("SELECT(`ID_PICTOGRAMA` || ' | ' || `DESCRIPCION`) AS ALGO FROM PICTOGRAMAS", SQLiteCon)

            Dim MySQLDA As New SQLiteDataAdapter("SELECT `ID_PICTOGRAMA`,`DESCRIPCION`,`IMAGEN` FROM PICTOGRAMAS", SQLiteCon)

            Dim table As New DataTable
            MySQLDA.Fill(table)
            ComboBox1.DataSource = table
            ComboBox1.ValueMember = "ID_PICTOGRAMA"
            ComboBox1.DisplayMember = "DESCRIPCION"

            ComboBox1.SelectedIndex = 0



            SQLiteCon.Close()

        Catch ex As Exception
            MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")

        Finally
            SQLiteCon.Close()
            SQLliteCMD = Nothing
        End Try
    End Sub




    Public Sub CargarPictogramas2()

        Try
            SQLiteCon.Open()

            'Dim MySQLDA As New SQLiteDataAdapter("SELECT(`ID_PICTOGRAMA` || ' | ' || `DESCRIPCION`) AS ALGO FROM PICTOGRAMAS", SQLiteCon)

            Dim MySQLDA As New SQLiteDataAdapter("SELECT `ID_PICTOGRAMA`,`DESCRIPCION` FROM PICTOGRAMAS", SQLiteCon)

            Dim table As New DataTable
            MySQLDA.Fill(table)
            ComboBox5.DataSource = table
            ComboBox5.ValueMember = "ID_PICTOGRAMA"
            ComboBox5.DisplayMember = "DESCRIPCION"

            ComboBox5.SelectedIndex = 0
            SQLiteCon.Close()

        Catch ex As Exception
            MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")

        Finally
            SQLiteCon.Close()
            SQLliteCMD = Nothing
        End Try
    End Sub

    Private Sub ComboBox5_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedValueChanged
        Try
            MsgBox(ComboBox5.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub
End Class