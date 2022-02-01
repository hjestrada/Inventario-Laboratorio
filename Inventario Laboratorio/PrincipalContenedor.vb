Imports System.Runtime.InteropServices


Public Class PrincipalContenedor


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

        'fh.StartPosition = FormStartPosition.CenterScreen
        Me.Panel_Central.Controls.Add(fh)
        Me.Panel_Central.Tag = fh
        fh.Show()
    End Sub








    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub

    Private Sub PrincipalContenedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        Lb_Fecha.Text = Now
        'Necesario para redondear formulario
        Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width - 2, Height - 2, 20, 20))
    End Sub



    Private Sub IconButton8_Click(sender As Object, e As EventArgs) Handles IconButton8.Click
        Me.Close()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Lb_Fecha.Text = Now

    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click

        AbrirFormenPanel(New Movimientos)

    End Sub

    Private Sub IconButton6_Click(sender As Object, e As EventArgs) Handles IconButton6.Click
        AbrirFormenPanel(New Usuarios)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MsgBox("Desarrollado por: Hector J. Estrada Toledo")
    End Sub

    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click
        AbrirFormenPanel(New Pictograma)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Panel_Central_Paint(sender As Object, e As PaintEventArgs) Handles Panel_Central.Paint

    End Sub
End Class
