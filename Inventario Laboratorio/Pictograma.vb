

Imports System.Runtime.InteropServices
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.IO

Public Class Pictograma


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

    Private Sub Pictograma_Load(sender As Object, e As EventArgs) Handles Me.Load
        MAXID()
        CargarDatos()
    End Sub

    Private Sub CargarDatos()

        Dim sql As String = "SELECT `ID_PICTO`, `NOMBRE` FROM PICTOGRAMAS"

        Using con As New SQLiteConnection(DB_Path)
            Dim command As New SQLiteCommand(sql, con)
            Dim da As New SQLiteDataAdapter
            da.SelectCommand = command
            Dim dt As New DataTable
            da.Fill(dt)
            DataGridView1.DataSource = dt

        End Using
    End Sub


    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click

        If Trim(TextBox2.Text) = "" Then
            MsgBox("¡Error! no se permiten campos vacios")

        Else
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

    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles IconButton2.Click
        Try



            Dim Numero As String
            Do
                Numero = InputBox("Por favor digite el identificador de Pictograma:")
            Loop Until IsNumeric(Numero)


            consulta1 = "SELECT * FROM `PICTOGRAMAS` WHERE `ID_PICTO`=" & Numero & ""
            MySQLDA1 = New SQLiteDataAdapter(consulta1, SQLiteCon)
            datos1 = New DataSet
            MySQLDA1.Fill(datos1, "PICTOGRAMAS")
            lista1 = datos1.Tables("PICTOGRAMAS").Rows.Count

            If lista1 = 0 Then
                MsgBox("Registro no encontrado")


            End If


            Label3.Text = datos1.Tables("PICTOGRAMAS").Rows(0).Item("ID_PICTO")
            TextBox2.Text = datos1.Tables("PICTOGRAMAS").Rows(0).Item("NOMBRE")
            Dim ImgArray() As Byte = datos1.Tables("PICTOGRAMAS").Rows(0).Item("IMAGEN")
            Dim lmgStr As New System.IO.MemoryStream(ImgArray)
            PictureBox2.Image = Image.FromStream(lmgStr)
            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
            lmgStr.Close()

        Catch ex As Exception
            MsgBox("Error" & ex.Message)
        End Try


    End Sub

    Sub MAXID()

        MySQLDA1.SelectCommand = New SQLiteCommand
        MySQLDA1.SelectCommand.Connection = SQLiteCon
        MySQLDA1.SelectCommand.CommandText = "SELECT MAX(`ID_PICTO`)  AS id FROM PICTOGRAMAS"
        SQLiteCon.Open()
        Dim valorDefecto As Integer = 1
        Dim ValorRetornado As Object = MySQLDA1.SelectCommand.ExecuteScalar()

        If (ValorRetornado Is DBNull.Value) Then
            Label3.Text = CStr(valorDefecto)
        Else
            Label3.Text = CStr(ValorRetornado) + 1
        End If
        SQLiteCon.Close()
    End Sub

    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click
        SQLiteCon.Open()
        Dim Numero As String
        Do
            Numero = InputBox("Por favor digite el identificador de Pictograma:")
        Loop Until IsNumeric(Numero)

        If MessageBox.Show("¿Seguro que desea eliminar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            SQLliteCMD = New SQLite.SQLiteCommand("delete from PICTOGRAMAS where ID_PICTO='" & Numero & "'", SQLiteCon)
            SQLliteCMD.ExecuteNonQuery()
            CargarDatos()
            SQLiteCon.Close()
            MAXID()

        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class