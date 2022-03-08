


Option Strict Off
Option Explicit On

Imports System.Runtime.InteropServices
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.IO



Public Class Login

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










    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub
    Sub login()
        USER = UsernameTextBox.Text
        PWD = PasswordTextBox.Text


        If USER = "" Or PWD = "" Then
            MsgBox("Todos los campos son obligatorios")
        Else

            Dim CONSULTA As String
            Dim LISTA As Byte
            CONSULTA = "Select *  From USUARIO WHERE USER ='" & USER & "' "
            MySQLDA1 = New SQLiteDataAdapter(CONSULTA, SQLiteCon)
            datos1 = New DataSet
            MySQLDA1.Fill(datos1, "USUARIO")
            LISTA = datos1.Tables("USUARIO").Rows.Count

            If LISTA <> 0 Then

                USERBD = datos1.Tables("USUARIO").Rows(0).Item("USER")
                PWDBD = datos1.Tables("USUARIO").Rows(0).Item("PWD")
                NOMBREUSUARIO = datos1.Tables("USUARIO").Rows(0).Item("NOMBRES")
                ROL = datos1.Tables("USUARIO").Rows(0).Item("ROL")
                IDUSUARIO = datos1.Tables("USUARIO").Rows(0).Item("ID_USUARIO")

                SQLiteCon.Close()

                If (USER = USERBD) And (PWD = PWDBD) Then
                    Me.Hide()
                    MsgBox("Bienvenido al Sistema, " & ROL & " " & NOMBREUSUARIO & "")
                    IDUSUARIO2 = IDUSUARIO
                    UsernameTextBox.Clear()
                    PasswordTextBox.Clear()

                    PrincipalContenedor.Show()
                Else
                    MsgBox("Error al Validar Usuario y/o Contraseña")
                    UsernameTextBox.Clear()
                    PasswordTextBox.Clear()
                End If
            Else
                MsgBox("No se encontraron datos")
            End If
        End If

    End Sub
    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        login()

    End Sub

    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles IconButton2.Click
        Me.Close()

    End Sub

    Private Sub IconButton1_Enter(sender As Object, e As EventArgs) Handles IconButton1.Enter
        login()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Necesario para redondear formulario
        Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width - 2, Height - 2, 20, 20))



    End Sub
End Class
