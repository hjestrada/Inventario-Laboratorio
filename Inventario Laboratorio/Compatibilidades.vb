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
            busqueda()
            busqueda2()
            SQLiteCon.Close()


            '-----------------




        Catch ex As Exception
            MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")

        Finally
            SQLiteCon.Close()
        SQLliteCMD = Nothing
        End Try
    End Sub





    Sub busqueda()

        Try
            Dim consulta1 As String
            Dim lista1 As Byte


            Dim id_picto1 As String
            id_picto1 = ComboBox5.SelectedValue

            If id_picto1 <> "" Then
                consulta1 = "SELECT * FROM `pictogramas` WHERE `ID_PICTOGRAMA`=" & id_picto1 & ""
                MySQLDA1 = New SQLiteDataAdapter(consulta1, SQLiteCon)
                datos1 = New DataSet
                MySQLDA1.Fill(datos1, "pictogramas")
                lista1 = datos1.Tables("pictogramas").Rows.Count

                If lista1 = 0 Then
                    MsgBox("No existen datos")

                End If

                Dim ImgArray() As Byte = datos1.Tables("pictogramas").Rows(0).Item("IMAGEN")
                Dim lmgStr As New System.IO.MemoryStream(ImgArray)
                PictureBox2.Image = Image.FromStream(lmgStr)
                PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
                lmgStr.Close()

            End If


        Catch ex As Exception
            'MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")
        End Try

    End Sub






    Sub busqueda2()

        Try
            Dim consulta1 As String
            Dim lista1 As Byte


            Dim id_picto2 As String
            id_picto2 = ComboBox1.SelectedValue

            If id_picto2 <> "" Then
                consulta1 = "SELECT * FROM `pictogramas` WHERE `ID_PICTOGRAMA`=" & id_picto2 & ""
                MySQLDA1 = New SQLiteDataAdapter(consulta1, SQLiteCon)
                datos1 = New DataSet
                MySQLDA1.Fill(datos1, "pictogramas")
                lista1 = datos1.Tables("pictogramas").Rows.Count

                If lista1 = 0 Then
                    MsgBox("No existen datos")

                End If

                Dim ImgArray() As Byte = datos1.Tables("pictogramas").Rows(0).Item("IMAGEN")
                Dim lmgStr As New System.IO.MemoryStream(ImgArray)
                PictureBox1.Image = Image.FromStream(lmgStr)
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                lmgStr.Close()

            End If


        Catch ex As Exception
            'MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")
        End Try

    End Sub











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

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        busqueda()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        busqueda2()
    End Sub
End Class