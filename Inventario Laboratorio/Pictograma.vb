

Imports System.Runtime.InteropServices
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.IO

Public Class Pictograma


    Dim DB_Path As String = "Data Source=" & Application.StartupPath & "\BD_Lab.s3db;"
    Dim SQLiteCon As New SQLiteConnection(DB_Path)
    Dim SQLliteCMD As New SQLiteCommand
    Dim Imag As Byte()

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub Pictograma_Load(sender As Object, e As EventArgs) Handles Me.Load


    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click

        SQLiteCon.Close()
        Imag = Imagen_Bytes(Me.PictureBox2.Image)

        Try
            SQLiteCon.Open()

            SQLliteCMD = New SQLiteCommand

            With SQLliteCMD
                .CommandText = " INSERT INTO PICTOGRAMAS (`ID_PICTO`, `NOMBRE`, `IMAGEN`) VALUES (NULL, @NOMBRE,@IMAGEN)"
                .Connection = SQLiteCon

                .Parameters.AddWithValue("@NOMBRE", Me.TextBox2.Text)
                .Parameters.AddWithValue("@IMAGEN", Imag)

                .ExecuteNonQuery()

            End With

            SQLiteCon.Close()
            MsgBox("Datos Registrados Exitosamente")


        Catch ex As Exception
            MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")
            SQLiteCon.Close()
            Return
        End Try
        SQLiteCon.Close()




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




    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles IconButton5.Click
        PictureBox2.Image = Nothing
        Dim file As New OpenFileDialog()
        file.Filter = ("Image File (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg ;*.png")
        If file.ShowDialog() = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(file.FileName)
            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub
End Class