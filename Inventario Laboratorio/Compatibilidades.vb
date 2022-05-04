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

    Dim compatibilidad As String
    Dim id_picto2 As String
    Dim id_picto1 As String


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
        cargaDataview()
        'hacemos que las columnas se ajusten a al tamaño del contenido
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.ScrollBars = ScrollBars.Both
        DataGridView1.ForeColor = Color.Black
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

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
                Label5.Text = id_picto1

            End If


        Catch ex As Exception
            'MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")
        End Try

    End Sub


    Sub busqueda2()

        Try
            Dim consulta1 As String
            Dim lista1 As Byte

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
                Label6.Text = id_picto2
            End If


        Catch ex As Exception
            'MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")
        End Try

    End Sub


    Sub validarGUardar()
        Dim consulta1 As String
        Dim lista1 As Byte


        consulta1 = "SELECT * FROM   compatibilidades WHERE   compatibilidades.ID_PICTOGRAMA = " & id_picto1 & " AND    compatibilidades.ID_PICTOGRAMA2 =" & id_picto2 & ""
        MySQLDA1 = New SQLiteDataAdapter(consulta1, SQLiteCon)
        datos1 = New DataSet
        MySQLDA1.Fill(datos1, "pictogramas")
        lista1 = datos1.Tables("pictogramas").Rows.Count

        If lista1 = 0 Then
            guardarcompatibilidad()
        Else
            MsgBox("Error, ya existe registrada esta compatibilidad")
        End If

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



    Sub cargaDataview()
        Try
            Dim datos As DataSet
            Dim Consulta As String
            Dim MySQLCMD As New SQLiteCommand
            Dim MySQLDA As New SQLiteDataAdapter

            'ClaseConexion.CadenaConex.Open()
            Consulta = "SELECT * FROM Compatibilidades"
            MySQLDA = New SQLiteDataAdapter(Consulta, SQLiteCon)
            datos = New DataSet
            MySQLDA.Fill(datos, "Compatibilidades")
            DataGridView1.DataSource = datos
            DataGridView1.DataMember = "Compatibilidades"
            'DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGreen
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White
            SQLiteCon.Close()

        Catch ex As Exception
            MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")
            SQLiteCon.Close()
        End Try

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        busqueda()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        busqueda2()
    End Sub

    Private Sub IconButton4_Click(sender As Object, e As EventArgs) Handles IconButton4.Click
        Try


            SQLiteCon.Open()
            Dim Numero As String
            Numero = InputBox("Por favor digite el identificador de la Compatibilidad")

            If MessageBox.Show("¿Seguro que desea eliminar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                SQLliteCMD = New SQLite.SQLiteCommand("delete from Compatibilidades where ID_COMPATIBILIDAD='" & Numero & "'", SQLiteCon)
                SQLliteCMD.ExecuteNonQuery()
                cargaDataview()
                SQLiteCon.Close()

            End If

        Catch ex As Exception
            MsgBox("Operación eliminar cancelada por el usuario")
        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        If RadioButton1.Checked Then
            compatibilidad = "Compatible"

        End If



    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

        If RadioButton2.Checked Then
            compatibilidad = "No Compatible"

        End If



    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

        If RadioButton3.Checked Then
            compatibilidad = "Solamente podrán almacenarse juntos,adoptando ciertas medidas."

        End If

    End Sub

    Private Sub IconButton7_Click(sender As Object, e As EventArgs) Handles IconButton7.Click
        validarGUardar()

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Sub guardarcompatibilidad()




        If MsgBox("Advertencia, ¿esta seguro de que la información suministrada es correcta y desea guardar esta compatibilidad?", MsgBoxStyle.Information + vbYesNo) = vbYes Then


            SQLiteCon.Close()
            Try
                SQLiteCon.Open()
                SQLliteCMD = New SQLiteCommand


                With SQLliteCMD
                    .CommandText = " INSERT INTO compatibilidades (`ID_COMPATIBILIDAD`, `ID_PICTOGRAMA`, `ID_PICTOGRAMA2`,`DEF_COMP`) VALUES (NULL, @ID_PICTOGRAMA, @ID_PICTOGRAMA2,@DEF_COMP)"
                    .Connection = SQLiteCon
                    .Parameters.AddWithValue("@ID_PICTOGRAMA", Me.Label5.Text)
                    .Parameters.AddWithValue("@ID_PICTOGRAMA2", Me.Label6.Text)
                    .Parameters.AddWithValue("@DEF_COMP", compatibilidad)

                    .ExecuteNonQuery()
                End With

                SQLiteCon.Close()
                MsgBox("Datos Registrados Exitosamente")
                cargaDataview()


            Catch ex As Exception
                MsgBox("Error al momento de guardar Compatibilidad.")
                SQLiteCon.Close()
                Return
            End Try
            SQLiteCon.Close()

        Else

            MsgBox("Operacion de Guardado Cancelado")

        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class