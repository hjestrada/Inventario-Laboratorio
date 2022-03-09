Imports System.Runtime.InteropServices
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.IO



Public Class PrincipalContenedor

    Dim DB_Path As String = "Data Source=" & Application.StartupPath & "\BD_Lab.s3db;"
    Dim SQLiteCon As New SQLiteConnection(DB_Path)
    Dim SQLliteCMD As New SQLiteCommand
    Dim Imag As Byte()
    Dim consulta1 As String
    Dim lista1 As Byte
    Dim datos1 As DataSet
    Dim MySQLDA1 As New SQLiteDataAdapter

    Dim bandera As Boolean = True
    Dim rolprivilegio As String

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


    Private Sub AbrirFormenPanel(ByVal FormHijo As Object)
        If Me.Panel_Central.Controls.Count > 0 Then
            Me.Panel_Central.Controls.RemoveAt(0)
        End If

        Dim fh As Form = TryCast(FormHijo, Form)
        fh.TopLevel = False

        fh.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        fh.Dock = DockStyle.None
        'fh.Dock = StartPosition.CenterScreen

        'fh.StartPosition = FormStartPosition.CenterParent
        Me.Panel_Central.Controls.Add(fh)
        Me.Panel_Central.Tag = fh
        fh.Show()
    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub

    Private Sub PrincipalContenedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarInfoLogin()
        TextBox1.Focus()
        Lb_Fecha.Text = Now
        'Necesario para redondear formulario
        Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width - 2, Height - 2, 20, 20))








    End Sub


    Sub CargarInfoLogin()
        Try


            consulta1 = "SELECT * FROM `USUARIO` WHERE `ID_USUARIO`=" & IDUSUARIO2 & ""
            MySQLDA1 = New SQLiteDataAdapter(consulta1, SQLiteCon)
            datos1 = New DataSet
            MySQLDA1.Fill(datos1, "USUARIO")
            lista1 = datos1.Tables("USUARIO").Rows.Count

            If lista1 = 0 Then
                MsgBox("Registro no encontrado")

            End If

            Label2.Text = datos1.Tables("USUARIO").Rows(0).Item("NOMBRE")
            Label5.Text = datos1.Tables("USUARIO").Rows(0).Item("ROL")
            rolprivilegio = Label5.Text


            Dim ImgArray() As Byte = datos1.Tables("USUARIO").Rows(0).Item("FOTO")
            Dim lmgStr As New System.IO.MemoryStream(ImgArray)
            PictureBox2.Image = Image.FromStream(lmgStr)
            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
            lmgStr.Close()

        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try


    End Sub







    Private Sub IconButton8_Click(sender As Object, e As EventArgs) Handles IconButton8.Click
        Dim Msg As MsgBoxResult
        Msg = MsgBox("¿Desea cerrar sesión?", vbYesNo, "Salir del Sistema")
        If Msg = MsgBoxResult.Yes Then
            Me.Close()

            Login.Show()

        Else
            Exit Sub
        End If


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Lb_Fecha.Text = Now

    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click

        AbrirFormenPanel(New Movimientos)

    End Sub

    Private Sub IconButton6_Click(sender As Object, e As EventArgs) Handles IconButton6.Click
        If rolprivilegio = "" Then

            MsgBox("Usuario NUll")
            AbrirFormenPanel(New Usuarios)
        Else
            If rolprivilegio = "Administrador" Then
                AbrirFormenPanel(New Usuarios)

            Else
                MsgBox("No posee privilegios suficientes para gestionar Usuarios, consulte con el administrador del sistema")

            End If

        End If



    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MsgBox("Desarrollado por: Hector J. Estrada Toledo, @hjestrada")
    End Sub

    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click
        AbrirFormenPanel(New menu)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Msg As MsgBoxResult
        Msg = MsgBox("¿Desea cerrar sesión?", vbYesNo, "Salir del Sistema")
        If Msg = MsgBoxResult.Yes Then
            Me.Close()

            Login.Show()

        Else
            Exit Sub
        End If



    End Sub

    Public Sub privilegios()



    End Sub


    Private Sub IconPictureBox2_Click(sender As Object, e As EventArgs) Handles IconPictureBox2.Click
        Panel1.Visible = False

    End Sub

    Private Sub IconPictureBox3_Click(sender As Object, e As EventArgs) Handles IconPictureBox3.Click
        Panel1.Visible = True
    End Sub

    Private Sub IconButton5_Click(sender As Object, e As EventArgs)
        AbrirFormenPanel(New Fabricante)
    End Sub

    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click
        AbrirFormenPanel(New GestionReactivos)
    End Sub
End Class
