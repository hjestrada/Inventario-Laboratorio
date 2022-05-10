
Option Strict Off
Option Explicit On

Imports System.Runtime.InteropServices
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.IO

Public Class Estantes



    Dim DB_Path As String = "Data Source=" & Application.StartupPath & "\BD_Lab.s3db;"
    Dim SQLiteCon As New SQLiteConnection(DB_Path)
    Dim SQLliteCMD As New SQLiteCommand
    Dim Imag As Byte()
    Dim consulta1 As String
    Dim lista1 As Byte
    Dim datos1 As DataSet
    Dim MySQLDA1 As New SQLiteDataAdapter




    'Necesarios para redondear formulario
    Public SD As Integer
    Public Declare Function GetClassLong Lib "user32" Alias "GetClassLongA" (Dt As IntPtr, UI As Integer) As Integer
    Public Declare Function GetDesktopWindow Lib "user32" () As Integer
    Public Declare Function SetClassLong Lib "user32" Alias "SetClassLongA" (Dt As IntPtr, IDF As Integer, IGT As Integer) As Integer
    Public Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (Wo As IntPtr, Ni As Integer, NK As Integer) As Integer


    Public Sub New()
        InitializeComponent()
        SuspendLayout()
        FormBorderStyle = FormBorderStyle.None
        Const CS_DROPSHADOW As Integer = 500000
        '----&H20000
        '----131072
        SD = SetWindowLong(Handle, -8, GetDesktopWindow())
        SetClassLong(Handle, -26, GetClassLong(Handle, -26) Or CS_DROPSHADOW)
        ResumeLayout(False)

    End Sub
    '----------------------------------------------------


    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(LR As Integer, TR As Integer, RR As Integer, BR As Integer, WE As Integer, HE As Integer) As IntPtr

    End Function






    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub Estantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Necesario para redondear formulario
        Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width - 2, Height - 2, 20, 20))
        MAXID()
        CargarDatos()

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
                    .CommandText = " INSERT INTO ESTANTE (`ID_ESTANTE`, `DESCRIPCION`) VALUES (NULL, @DESCRIPCION)"
                    .Connection = SQLiteCon
                    .Parameters.AddWithValue("@DESCRIPCION", Me.TextBox2.Text)
                    .ExecuteNonQuery()
                End With

                SQLiteCon.Close()
                MsgBox("Datos Registrados Exitosamente")
                Me.TextBox2.Clear()
                CargarDatos()
                MAXID()


            Catch ex As Exception
                mensaje_error = ex.Message
                FormError.mensaje(mensaje_error)
                FormError.Show()
                SQLiteCon.Close()
                Return
            End Try
            SQLiteCon.Close()


        End If


    End Sub


    Private Sub CargarDatos()

        Dim sql As String = "SELECT `ID_ESTANTE`,`DESCRIPCION` FROM ESTANTE"

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
        MySQLDA1.SelectCommand.CommandText = "SELECT MAX(`ID_ESTANTE`)  AS id FROM ESTANTE"
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

    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click

        Try


            SQLiteCon.Open()
            Dim Numero As String
            Numero = InputBox("Por favor digite el identificador del Estante:")

            If MessageBox.Show("¿Seguro que desea eliminar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                SQLliteCMD = New SQLite.SQLiteCommand("delete from ESTANTE where ID_ESTANTE='" & Numero & "'", SQLiteCon)
                SQLliteCMD.ExecuteNonQuery()
                CargarDatos()
                SQLiteCon.Close()
                MAXID()

            End If

        Catch ex As Exception
            mensaje_error = "Operación eliminar cancelada por el usuario"
            FormError.mensaje(mensaje_error)
            FormError.Show()

        End Try
    End Sub
End Class