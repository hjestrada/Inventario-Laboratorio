

Imports System.Runtime.InteropServices
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.IO


Public Class Usuarios


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

    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles IconButton5.Click
        PictureBox2.Image = Nothing
        Dim file As New OpenFileDialog()
        file.Filter = ("Image File (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg ;*.png")
        If file.ShowDialog() = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(file.FileName)
            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click


        If Trim(TextBox1.Text) = "" Or Trim(TextBox2.Text) = "" Or Trim(MaskedTextBox1.Text) = "" Or Trim(TextBox4.Text) = "" Or Trim(TextBox5.Text) = "" Or Trim(TextBox6.Text) = "" Then
            MsgBox("¡Error! no se permiten campos vacios")

        Else
            SQLiteCon.Close()
            Imag = Imagen_Bytes(Me.PictureBox2.Image)

            Try
                SQLiteCon.Open()
                SQLliteCMD = New SQLiteCommand


                With SQLliteCMD
                    .CommandText = " INSERT INTO USUARIOS (`ID_USUARIO`, `NOMBRES`, `ROL`,`TELEFONO`,`EMAIL`,`FOTO`,`USER`,`PWD`) VALUES (@ID_USUARIO, @NOMBRES, @ROL,@TELEFONO,@EMAIL,@FOTO,@USER,@PWD)"
                    .Connection = SQLiteCon
                    .Parameters.AddWithValue("@ID_USUARIO", Me.TextBox1.Text)
                    .Parameters.AddWithValue("@NOMBRES", Me.TextBox2.Text)
                    .Parameters.AddWithValue("@ROL", Me.ComboBox1.Text)
                    .Parameters.AddWithValue("@TELEFONO", Me.MaskedTextBox1.Text)
                    .Parameters.AddWithValue("@EMAIL", Me.TextBox4.Text)
                    .Parameters.AddWithValue("@FOTO", Imag)
                    .Parameters.AddWithValue("@USER", Me.TextBox5.Text)
                    .Parameters.AddWithValue("@PWD", Me.TextBox6.Text)

                    .ExecuteNonQuery()
                End With

                SQLiteCon.Close()
                MsgBox("Datos Registrados Exitosamente")
                limpiarform()


            Catch ex As Exception
                MsgBox("Error al momento de guardar, verifique que el numero de identificación no este repetido en el sistema" & vbCr & ex.Message, MsgBoxStyle.Critical, "Mensaje de Error")
                SQLiteCon.Close()
                Return
            End Try
            SQLiteCon.Close()
        End If

    End Sub

    Sub limpiarform()
        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.MaskedTextBox1.Clear()
        Me.TextBox4.Clear()
        '  PictureBox2.Load()
        Me.TextBox5.Clear()
        Me.TextBox6.Clear()

    End Sub



    'convertir imagen a binario
    Private Function Imagen_Bytes(ByVal Imagen As Image) As Byte()
        Try

            'si hay imagen
            If Not Imagen Is Nothing Then
                'variable de datos binarios en stream(flujo)
                Dim Bin As New MemoryStream
                'convertir a bytes
                Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
                'retorna binario
                Return Bin.GetBuffer
            Else
                Return Nothing
            End If

        Catch ex As Exception

        End Try
    End Function

    'convertir binario a imágen
    Private Function Bytes_Imagen(ByVal Imagen As Byte()) As Image
        Try
            'si hay imagen
            If Not Imagen Is Nothing Then
                'caturar array con memorystream hacia Bin
                Dim Bin As New MemoryStream(Imagen)
                'con el método FroStream de Image obtenemos imagen
                Dim Resultado As Image = Image.FromStream(Bin)
                'y la retornamos
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class