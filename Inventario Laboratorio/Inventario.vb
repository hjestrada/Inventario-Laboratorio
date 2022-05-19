


Option Strict Off
Option Explicit On
Imports System.Data.SQLite
Imports System.IO





Public Class Inventario

    Dim DB_Path As String = "Data Source=" & Application.StartupPath & "\BD_Lab.s3db;"
    Dim SQLiteCon As New SQLiteConnection(DB_Path)
    Dim SQLliteCMD As New SQLiteCommand
    Dim Imag As Byte()
    Dim consulta1 As String
    Dim lista1 As Byte
    Dim datos1 As DataSet
    Dim MySQLDA1 As New SQLiteDataAdapter
    Dim GrupoGeneralaux, GrupoGeneralaux2, GrupoGeneralaux3, GrupoGeneralaux4, GrupoClasePeligroaux, CategoriaPeligroaux As String
    Dim table As New DataTable

    Dim Id_picto1, Id_picto2, Id_picto3, Id_picto4 As String



    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try
            ComboBox1.SelectedIndex = 0
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList

            ComboBox2.SelectedIndex = 0
            ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList

            ComboBox6.DropDownStyle = ComboBoxStyle.DropDownList

            ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBox7.DropDownStyle = ComboBoxStyle.DropDownList

            ComboBox8.DropDownStyle = ComboBoxStyle.DropDownList

            ComboBox5.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBox4.DropDownStyle = ComboBoxStyle.DropDownList

            ComboBox14.DropDownStyle = ComboBoxStyle.DropDownList

            ComboBox13.DropDownStyle = ComboBoxStyle.DropDownList

            ComboBox12.DropDownStyle = ComboBoxStyle.DropDownList

            ComboBox9.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBox10.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBox11.DropDownStyle = ComboBoxStyle.DropDownList

            ComboBox15.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBox16.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBox17.DropDownStyle = ComboBoxStyle.DropDownList


            MAXID()
            cargarfabricante2()
            GrupoGeneral()
            GrupoGeneral2()
            GrupoGeneral3()
            GrupoGeneral4()



            cargarClasePeligro3()
            cargarClasePeligro4()


            EstantesCombo()
            cargarfilaestantecombo()

            cargarPictograma()
            cargarPictograma2()
            cargarPictograma3()
            cargarPictograma4()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub



    Public Sub EstantesCombo()
        Try

            Dim cmd As String = "SELECT `ID_ESTANTE`,`DESCRIPCION`FROM estante"
            Dim da As New SQLiteDataAdapter(cmd, SQLiteCon)
            Dim dt As DataTable = New DataTable("estante")
            da.Fill(dt)
            With ComboBox6
                .DataSource = dt
                .DisplayMember = "ID_ESTANTE"
                .ValueMember = "ID_ESTANTE"
            End With

        Catch ex As Exception
            '   MessageBox.Show(ex.Message)
        End Try
    End Sub




    Public Sub cargarfilaestantecombo()

        Dim estantecombo As String
        estantecombo = ComboBox6.SelectedValue.ToString


        Try


            Dim MySQLDA As New SQLiteDataAdapter("Select ID_FILA,FILA.DESCRIPCION FROM FILA INNER JOIN ESTANTE WHERE ESTANTE.ID_ESTANTE=@Gg And FILA.ID_ESTANTE=@Gg", SQLiteCon)

            MySQLDA.SelectCommand.Parameters.AddWithValue("@Gg", estantecombo)
            Dim ds As New DataSet
            Dim table As New DataTable

            MySQLDA.Fill(ds)

            ComboBox7.DataSource = ds.Tables(0)
            ComboBox7.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
            ComboBox7.ValueMember = "ID_FILA"


        Catch ex As Exception
            '  MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")


        Finally
            SQLiteCon.Close()

        End Try

    End Sub




    Public Sub GrupoGeneral()
        Try

            Dim cmd As String = "SELECT `ID_GRUPO_SGA`,`GRUPO_GENERAL`FROM sga"
            Dim da As New SQLiteDataAdapter(cmd, SQLiteCon)
            Dim dt As DataTable = New DataTable("sga")
            da.Fill(dt)
            With ComboBox8
                .DataSource = dt
                .DisplayMember = "GRUPO_GENERAL"
                .ValueMember = "ID_GRUPO_SGA"
            End With
            cargarClasePeligro()
        Catch ex As Exception
            '   MessageBox.Show(ex.Message)
        End Try
    End Sub



    Public Sub GrupoGeneral2()
        Try

            Dim cmd As String = "SELECT `ID_GRUPO_SGA`,`GRUPO_GENERAL`FROM sga"
            Dim da As New SQLiteDataAdapter(cmd, SQLiteCon)
            Dim dt As DataTable = New DataTable("sga")
            da.Fill(dt)
            With ComboBox14
                .DataSource = dt
                .DisplayMember = "GRUPO_GENERAL"
                .ValueMember = "ID_GRUPO_SGA"
            End With
            cargarClasePeligro2()
        Catch ex As Exception
            '   MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GrupoGeneral3()
        Try

            Dim cmd As String = "SELECT `ID_GRUPO_SGA`,`GRUPO_GENERAL`FROM sga"
            Dim da As New SQLiteDataAdapter(cmd, SQLiteCon)
            Dim dt As DataTable = New DataTable("sga")
            da.Fill(dt)
            With ComboBox17
                .DataSource = dt
                .DisplayMember = "GRUPO_GENERAL"
                .ValueMember = "ID_GRUPO_SGA"
            End With
            cargarClasePeligro()
        Catch ex As Exception
            '   MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub GrupoGeneral4()
        Try

            Dim cmd As String = "SELECT `ID_GRUPO_SGA`,`GRUPO_GENERAL`FROM sga"
            Dim da As New SQLiteDataAdapter(cmd, SQLiteCon)
            Dim dt As DataTable = New DataTable("sga")
            da.Fill(dt)
            With ComboBox11
                .DataSource = dt
                .DisplayMember = "GRUPO_GENERAL"
                .ValueMember = "ID_GRUPO_SGA"
            End With
            cargarClasePeligro2()
        Catch ex As Exception
            '   MessageBox.Show(ex.Message)
        End Try
    End Sub




    Public Sub cargarClasePeligro()
        GrupoGeneralaux = ComboBox8.SelectedValue.ToString

        Try

            Dim MySQLDA As New SQLiteDataAdapter("SELECT CLASE_PELIGRO,ID_CLASIFICACION FROM clasificacion INNER JOIN sga WHERE SGA.ID_GRUPO_SGA=@Gg and clasificacion.ID_GRUPO_SGA  =@Gg", SQLiteCon)

            MySQLDA.SelectCommand.Parameters.AddWithValue("@Gg", GrupoGeneralaux)
            Dim ds As New DataSet
            Dim table As New DataTable

            MySQLDA.Fill(ds)

            ComboBox5.DataSource = ds.Tables(0)
            ComboBox5.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
            ComboBox5.ValueMember = "ID_CLASIFICACION"


        Catch ex As Exception
            '  MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")


        Finally
            SQLiteCon.Close()

        End Try

    End Sub



    Public Sub cargarClasePeligro2()


        GrupoGeneralaux2 = ComboBox14.SelectedValue.ToString



        Try

            Dim MySQLDA As New SQLiteDataAdapter("SELECT CLASE_PELIGRO,ID_CLASIFICACION FROM clasificacion INNER JOIN sga WHERE SGA.ID_GRUPO_SGA=@Gg and clasificacion.ID_GRUPO_SGA  =@Gg", SQLiteCon)

            MySQLDA.SelectCommand.Parameters.AddWithValue("@Gg", GrupoGeneralaux2)
            Dim ds As New DataSet
            Dim table As New DataTable

            MySQLDA.Fill(ds)

            ComboBox13.DataSource = ds.Tables(0)
            ComboBox13.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
            ComboBox13.ValueMember = "ID_CLASIFICACION"


        Catch ex As Exception
            '  MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")


        Finally
            SQLiteCon.Close()

        End Try

    End Sub

    Public Sub cargarClasePeligro3()


        GrupoGeneralaux3 = ComboBox11.SelectedValue.ToString


        Try

            Dim MySQLDA As New SQLiteDataAdapter("SELECT CLASE_PELIGRO,ID_CLASIFICACION FROM clasificacion INNER JOIN sga WHERE SGA.ID_GRUPO_SGA=@Gg and clasificacion.ID_GRUPO_SGA  =@Gg", SQLiteCon)

            MySQLDA.SelectCommand.Parameters.AddWithValue("@Gg", GrupoGeneralaux3)
            Dim ds As New DataSet
            Dim table As New DataTable

            MySQLDA.Fill(ds)

            ComboBox10.DataSource = ds.Tables(0)
            ComboBox10.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
            ComboBox10.ValueMember = "ID_CLASIFICACION"


        Catch ex As Exception
            '  MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")


        Finally
            SQLiteCon.Close()

        End Try

    End Sub

    Public Sub cargarClasePeligro4()


        GrupoGeneralaux4 = ComboBox17.SelectedValue.ToString


        Try

            Dim MySQLDA As New SQLiteDataAdapter("SELECT CLASE_PELIGRO,ID_CLASIFICACION FROM clasificacion INNER JOIN sga WHERE SGA.ID_GRUPO_SGA=@Gg and clasificacion.ID_GRUPO_SGA  =@Gg", SQLiteCon)

            MySQLDA.SelectCommand.Parameters.AddWithValue("@Gg", GrupoGeneralaux4)
            Dim ds As New DataSet
            Dim table As New DataTable

            MySQLDA.Fill(ds)

            ComboBox16.DataSource = ds.Tables(0)
            ComboBox16.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
            ComboBox16.ValueMember = "ID_CLASIFICACION"


        Catch ex As Exception
            '  MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")


        Finally
            SQLiteCon.Close()

        End Try

    End Sub


    Public Sub cargarCategoriaPeligro()

        GrupoClasePeligroaux = ComboBox5.SelectedValue.ToString
        ' MsgBox(GrupoClasePeligroaux)

        Try

            Dim MySQLDA As New SQLiteDataAdapter("SELECT CAT_PELIGRO,ID_CAT_PELIGRO FROM cat_peligro INNER JOIN clasificacion WHERE clasificacion.ID_CLASIFICACION=@Gg and cat_peligro.ID_CLASIFICACION=@Gg", SQLiteCon)

            MySQLDA.SelectCommand.Parameters.AddWithValue("@Gg", GrupoClasePeligroaux)
            Dim ds As New DataSet
            Dim table As New DataTable

            MySQLDA.Fill(ds)

            ComboBox4.DataSource = ds.Tables(0)
            ComboBox4.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
            ComboBox4.ValueMember = "ID_CAT_PELIGRO"

        Catch ex As Exception
            '  MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")


        Finally
            SQLiteCon.Close()

        End Try

    End Sub


    Public Sub cargarCategoriaPeligro2()

        GrupoClasePeligroaux = ComboBox13.SelectedValue.ToString
        ' MsgBox(GrupoClasePeligroaux)

        Try

            Dim MySQLDA As New SQLiteDataAdapter("SELECT CAT_PELIGRO,ID_CAT_PELIGRO FROM cat_peligro INNER JOIN clasificacion WHERE clasificacion.ID_CLASIFICACION=@Gg and cat_peligro.ID_CLASIFICACION=@Gg", SQLiteCon)

            MySQLDA.SelectCommand.Parameters.AddWithValue("@Gg", GrupoClasePeligroaux)
            Dim ds As New DataSet
            Dim table As New DataTable

            MySQLDA.Fill(ds)

            ComboBox12.DataSource = ds.Tables(0)
            ComboBox12.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
            ComboBox12.ValueMember = "ID_CAT_PELIGRO"

        Catch ex As Exception
            '  MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")


        Finally
            SQLiteCon.Close()

        End Try

    End Sub



    Public Sub cargarCategoriaPeligro3()

        GrupoClasePeligroaux = ComboBox10.SelectedValue.ToString
        ' MsgBox(GrupoClasePeligroaux)

        Try

            Dim MySQLDA As New SQLiteDataAdapter("SELECT CAT_PELIGRO,ID_CAT_PELIGRO FROM cat_peligro INNER JOIN clasificacion WHERE clasificacion.ID_CLASIFICACION=@Gg and cat_peligro.ID_CLASIFICACION=@Gg", SQLiteCon)

            MySQLDA.SelectCommand.Parameters.AddWithValue("@Gg", GrupoClasePeligroaux)
            Dim ds As New DataSet
            Dim table As New DataTable

            MySQLDA.Fill(ds)

            ComboBox9.DataSource = ds.Tables(0)
            ComboBox9.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
            ComboBox9.ValueMember = "ID_CAT_PELIGRO"

        Catch ex As Exception
            '  MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")


        Finally
            SQLiteCon.Close()

        End Try

    End Sub


    Public Sub cargarCategoriaPeligro4()

        GrupoClasePeligroaux = ComboBox16.SelectedValue.ToString
        ' MsgBox(GrupoClasePeligroaux)

        Try

            Dim MySQLDA As New SQLiteDataAdapter("SELECT CAT_PELIGRO,ID_CAT_PELIGRO FROM cat_peligro INNER JOIN clasificacion WHERE clasificacion.ID_CLASIFICACION=@Gg and cat_peligro.ID_CLASIFICACION=@Gg", SQLiteCon)

            MySQLDA.SelectCommand.Parameters.AddWithValue("@Gg", GrupoClasePeligroaux)
            Dim ds As New DataSet
            Dim table As New DataTable

            MySQLDA.Fill(ds)

            ComboBox15.DataSource = ds.Tables(0)
            ComboBox15.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
            ComboBox15.ValueMember = "ID_CAT_PELIGRO"

        Catch ex As Exception
            '  MsgBox("Error" & vbCr & ex.Message, MsgBoxStyle.Critical, "Error Message")


        Finally
            SQLiteCon.Close()

        End Try

    End Sub


    Public Sub cargarPictograma()
        Try




            Dim consulta1 As String
            Dim lista1 As Byte

            CategoriaPeligroaux = ComboBox4.SelectedValue.ToString

            Id_picto1 = CategoriaPeligroaux

            consulta1 = "SELECT pictogramas.IMAGEN, cat_peligro.ID_CAT_PELIGRO,cat_peligro.PALABRA_ADVERTENCIA,cat_peligro.INDICACION_PELIGRO FROM   cat_peligro INNER JOIN pictogramas ON pictogramas.ID_PICTOGRAMA = cat_peligro.ID_PICTOGRAMA  AND  cat_peligro.ID_CAT_PELIGRO= " & CategoriaPeligroaux & ""

            MySQLDA1 = New SQLiteDataAdapter(consulta1, SQLiteCon)


            datos1 = New DataSet
            MySQLDA1.Fill(datos1, "pictogramas")
            lista1 = datos1.Tables("pictogramas").Rows.Count


            If lista1 = 0 Then

                'MsgBox("Error al cargar datos")

            End If

            Dim ImgArray() As Byte = datos1.Tables("PICTOGRAMAS").Rows(0).Item("IMAGEN")

            Dim lmgStr As New System.IO.MemoryStream(ImgArray)
            PictureBox1.Image = Image.FromStream(lmgStr)
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            Dim aux1, aux2

            aux1 = datos1.Tables("pictogramas").Rows(0).Item("PALABRA_ADVERTENCIA")
            TextBox1.Text = aux1
            aux2 = datos1.Tables("pictogramas").Rows(0).Item("INDICACION_PELIGRO")
            TextBox4.Text = aux2
            lmgStr.Close()


        Catch ex As Exception

        End Try

    End Sub


    Public Sub cargarPictograma2()
        Try


            Dim consulta1 As String
            Dim lista1 As Byte

            CategoriaPeligroaux = ComboBox12.SelectedValue.ToString
            Id_picto2 = CategoriaPeligroaux
            consulta1 = "SELECT pictogramas.IMAGEN, cat_peligro.ID_CAT_PELIGRO,cat_peligro.PALABRA_ADVERTENCIA,cat_peligro.INDICACION_PELIGRO FROM   cat_peligro INNER JOIN pictogramas ON pictogramas.ID_PICTOGRAMA = cat_peligro.ID_PICTOGRAMA  AND  cat_peligro.ID_CAT_PELIGRO= " & CategoriaPeligroaux & ""

            MySQLDA1 = New SQLiteDataAdapter(consulta1, SQLiteCon)


            datos1 = New DataSet
            MySQLDA1.Fill(datos1, "pictogramas")
            lista1 = datos1.Tables("pictogramas").Rows.Count


            If lista1 = 0 Then

                'MsgBox("Error al cargar datos")

            End If

            Dim ImgArray() As Byte = datos1.Tables("PICTOGRAMAS").Rows(0).Item("IMAGEN")

            Dim lmgStr As New System.IO.MemoryStream(ImgArray)
            PictureBox4.Image = Image.FromStream(lmgStr)
            PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
            Dim aux1, aux2

            aux1 = datos1.Tables("pictogramas").Rows(0).Item("PALABRA_ADVERTENCIA")
            '   TextBox5.Text = aux1
            aux2 = datos1.Tables("pictogramas").Rows(0).Item("INDICACION_PELIGRO")
            TextBox5.Text = aux2
            lmgStr.Close()





        Catch ex As Exception

        End Try

    End Sub


    Public Sub cargarPictograma3()
        Try


            Dim consulta1 As String
            Dim lista1 As Byte

            CategoriaPeligroaux = ComboBox9.SelectedValue.ToString
            Id_picto3 = CategoriaPeligroaux
            consulta1 = "SELECT pictogramas.IMAGEN, cat_peligro.ID_CAT_PELIGRO,cat_peligro.PALABRA_ADVERTENCIA,cat_peligro.INDICACION_PELIGRO FROM   cat_peligro INNER JOIN pictogramas ON pictogramas.ID_PICTOGRAMA = cat_peligro.ID_PICTOGRAMA  AND  cat_peligro.ID_CAT_PELIGRO= " & CategoriaPeligroaux & ""

            MySQLDA1 = New SQLiteDataAdapter(consulta1, SQLiteCon)


            datos1 = New DataSet
            MySQLDA1.Fill(datos1, "pictogramas")
            lista1 = datos1.Tables("pictogramas").Rows.Count


            If lista1 = 0 Then

                'MsgBox("Error al cargar datos")

            End If

            Dim ImgArray() As Byte = datos1.Tables("PICTOGRAMAS").Rows(0).Item("IMAGEN")

            Dim lmgStr As New System.IO.MemoryStream(ImgArray)
            PictureBox2.Image = Image.FromStream(lmgStr)
            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
            Dim aux1, aux2

            aux1 = datos1.Tables("pictogramas").Rows(0).Item("PALABRA_ADVERTENCIA")
            '   TextBox5.Text = aux1
            aux2 = datos1.Tables("pictogramas").Rows(0).Item("INDICACION_PELIGRO")
            TextBox7.Text = aux2
            lmgStr.Close()


        Catch ex As Exception

        End Try

    End Sub


    Public Sub cargarPictograma4()
        Try


            Dim consulta1 As String
            Dim lista1 As Byte

            CategoriaPeligroaux = ComboBox15.SelectedValue.ToString
            Id_picto4 = CategoriaPeligroaux
            consulta1 = "SELECT pictogramas.IMAGEN, cat_peligro.ID_CAT_PELIGRO,cat_peligro.PALABRA_ADVERTENCIA,cat_peligro.INDICACION_PELIGRO FROM   cat_peligro INNER JOIN pictogramas ON pictogramas.ID_PICTOGRAMA = cat_peligro.ID_PICTOGRAMA  AND  cat_peligro.ID_CAT_PELIGRO= " & CategoriaPeligroaux & ""

            MySQLDA1 = New SQLiteDataAdapter(consulta1, SQLiteCon)


            datos1 = New DataSet
            MySQLDA1.Fill(datos1, "pictogramas")
            lista1 = datos1.Tables("pictogramas").Rows.Count


            If lista1 = 0 Then

                'MsgBox("Error al cargar datos")

            End If

            Dim ImgArray() As Byte = datos1.Tables("PICTOGRAMAS").Rows(0).Item("IMAGEN")

            Dim lmgStr As New System.IO.MemoryStream(ImgArray)
            PictureBox5.Image = Image.FromStream(lmgStr)
            PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
            Dim aux1, aux2

            aux1 = datos1.Tables("pictogramas").Rows(0).Item("PALABRA_ADVERTENCIA")
            '   TextBox5.Text = aux1
            aux2 = datos1.Tables("pictogramas").Rows(0).Item("INDICACION_PELIGRO")
            TextBox8.Text = aux2
            lmgStr.Close()


        Catch ex As Exception

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




    Public Sub cargarfabricante2()
        Try
            'Dim cmd As String = "Select`ID_FABRICANTE` || ' | ' || `NOMBRE_FAB` AS ALGO FROM FABRICANTE"
            Dim cmd As String = "SELECT `ID_FABRICANTE`,`NOMBRE_FAB`FROM FABRICANTE"
            Dim da As New SQLiteDataAdapter(cmd, SQLiteCon)
            Dim dt As DataTable = New DataTable("FABRICANTE")
            da.Fill(dt)
            With ComboBox3
                .DataSource = dt
                .DisplayMember = "NOMBRE_FAB"
                .ValueMember = "ID_FABRICANTE"
            End With

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub



    Sub MAXID()

        MySQLDA1.SelectCommand = New SQLiteCommand
        MySQLDA1.SelectCommand.Connection = SQLiteCon
        MySQLDA1.SelectCommand.CommandText = "SELECT MAX(`id_reactivo`)  AS id FROM reactivo"
        SQLiteCon.Open()
        Dim valorDefecto As Integer = 1
        Dim ValorRetornado As Object = MySQLDA1.SelectCommand.ExecuteScalar()

        If ValorRetornado Is DBNull.Value Then
            TextBox6.Text = CStr(valorDefecto)
        Else
            TextBox6.Text = CStr(ValorRetornado) + 1
        End If
        SQLiteCon.Close()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

        cargarPictograma()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        cargarPictograma()
    End Sub

    Private Sub ComboBox14_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox14.SelectedIndexChanged
        cargarClasePeligro2()
        validarsegundovacio()
    End Sub

    Private Sub ComboBox13_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox13.SelectedIndexChanged
        cargarCategoriaPeligro2()
    End Sub

    Private Sub ComboBox12_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox12.SelectedIndexChanged


        cargarPictograma2()

    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox11.SelectedIndexChanged
        cargarClasePeligro3()
        validartercervacio()
    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox10.SelectedIndexChanged
        cargarCategoriaPeligro3()
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged


        cargarPictograma3()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub ComboBox17_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox17.SelectedIndexChanged
        cargarClasePeligro4()
    End Sub

    Private Sub ComboBox16_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox16.SelectedIndexChanged
        cargarCategoriaPeligro4()
    End Sub

    Private Sub ComboBox15_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox15.SelectedIndexChanged

        cargarPictograma4()
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        cargarfilaestantecombo()
    End Sub

    Private Sub IconButton3_Click(sender As Object, e As EventArgs) Handles IconButton3.Click

        Pdf.Show()

    End Sub

    Private Sub IconButton5_Click(sender As Object, e As EventArgs) Handles IconButton5.Click

        Dim file As New OpenFileDialog()
        file.Filter = ("PDF File (*.pdf)|*.pdf")
        If file.ShowDialog() = DialogResult.OK Then
            TextBox9.Text = file.FileName
            My.Computer.FileSystem.CopyFile(file.FileName, Application.StartupPath & "\FichasTecnicas\" & "FT" & TextBox6.Text & ".pdf", Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            archivovisualizar = Application.StartupPath & "\FichasTecnicas\" & "FT" & TextBox6.Text & ".pdf"
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        ' verificar consulta

        Try
            ' bloque1
            ' verifica campos vacios

            If Trim(TextBox2.Text) = "" Or Trim(TextBox3.Text) = "" Or Trim(RichTextBox2.Text) = "" Or Trim(TextBox9.Text) = "" Then
                mensaje_error = "No se permiten campos vacios, verifique la información suministrada,verifique si cargó la ficha técnica o diligenció la información de primeros auxilios."
                FormError.mensaje(mensaje_error)
                FormError.Show()
            Else

                If (Id_picto1 = 89 And Id_picto2 = 89 And Id_picto3 = 89 And Id_picto4 = 89) Then
                    insertarReactivo()
                    MsgBox("entro bloque 89")
                Else
                    If (Id_picto1 <> Id_picto2 And (Id_picto1 <> Id_picto3) And (Id_picto1 <> Id_picto4)) Then
                        insertarReactivo()
                        ' MsgBox("condiciones")
                    Else
                        If ((Id_picto2 = 89 And Id_picto3 = 89 And Id_picto4 = 89) And Id_picto1 <> 89) Then
                            insertarReactivo()
                            'MsgBox("entro funcion solo la primera el resto vacios")

                        Else
                            If ((Id_picto3 = 89 And Id_picto4 = 89) And ((Id_picto1 <> Id_picto2) And (Id_picto1 <> 89 And Id_picto2 <> 89))) Then
                                insertarReactivo()
                                'MsgBox("entro funcion primera y seguda diferentes 3y 4 vacio")
                            Else

                                If (Id_picto1 = Id_picto2 = Id_picto3 = Id_picto4) And (Id_picto1 <> 89 And Id_picto2 <> 89 And Id_picto3 <> 89 And Id_picto4 <> 89) Then
                                    mensaje_error = "Todas son iguales diferentes a vacío"
                                    FormError.mensaje(mensaje_error)
                                    FormError.Show()
                                End If
                                If (Id_picto1 = Id_picto3 = Id_picto4) And (Id_picto2 <> Id_picto1 And Id_picto2 <> Id_picto3 And Id_picto2 <> Id_picto4) Then
                                    mensaje_error = "No pueden existir categorias de peligro iguales, verifique la informacion suministrada e intente nuevamente"
                                    FormError.mensaje(mensaje_error)
                                    FormError.Show()
                                End If
                                'MsgBox("por fuera")

                                If (Id_picto1 = Id_picto2) And (Id_picto3 = 89 And Id_picto4 = 89) Then
                                    mensaje_error = "Las primeras 2 categorias no pueden ser iguales"
                                    FormError.mensaje(mensaje_error)
                                    FormError.Show()
                                End If

                                MsgBox("aqui")




                            End If

                        End If
                    End If

                End If
            End If


        Catch ex As Exception
            mensaje_error = ex.Message
            FormError.mensaje(mensaje_error)
            FormError.Show()

        End Try
    End Sub

    Sub validarprimerovacio()
        Dim auxcombo
        auxcombo = ComboBox8.SelectedValue.ToString
        If (auxcombo = "4") Then

            Dim cmd As String = "SELECT `ID_GRUPO_SGA`,`GRUPO_GENERAL`FROM sga where ID_GRUPO_SGA=" & auxcombo & ""
            Dim da As New SQLiteDataAdapter(cmd, SQLiteCon)
            Dim dt As DataTable = New DataTable("sga")
            da.Fill(dt)
            With ComboBox14
                .DataSource = dt
                .DisplayMember = "GRUPO_GENERAL"
                .ValueMember = "ID_GRUPO_SGA"
            End With


            With ComboBox11
                .DataSource = dt
                .DisplayMember = "GRUPO_GENERAL"
                .ValueMember = "ID_GRUPO_SGA"
            End With
            With ComboBox17
                .DataSource = dt
                .DisplayMember = "GRUPO_GENERAL"
                .ValueMember = "ID_GRUPO_SGA"
            End With

            cargarClasePeligro2()
            cargarClasePeligro()


        Else
            GrupoGeneral2()
            GrupoGeneral3()
            GrupoGeneral4()
        End If





    End Sub

    Sub validarsegundovacio()
        Dim auxcombo
        auxcombo = ComboBox14.SelectedValue.ToString
        If (auxcombo = "4") Then

            Dim cmd As String = "SELECT `ID_GRUPO_SGA`,`GRUPO_GENERAL`FROM sga where ID_GRUPO_SGA=" & auxcombo & ""
            Dim da As New SQLiteDataAdapter(cmd, SQLiteCon)
            Dim dt As DataTable = New DataTable("sga")
            da.Fill(dt)


            With ComboBox11
                .DataSource = dt
                .DisplayMember = "GRUPO_GENERAL"
                .ValueMember = "ID_GRUPO_SGA"
            End With
            With ComboBox17
                .DataSource = dt
                .DisplayMember = "GRUPO_GENERAL"
                .ValueMember = "ID_GRUPO_SGA"
            End With

            cargarClasePeligro2()
            cargarClasePeligro()


        Else
            '  GrupoGeneral2()
            GrupoGeneral3()
            GrupoGeneral4()
        End If

    End Sub
    Sub validartercervacio()
        Dim auxcombo
        auxcombo = ComboBox11.SelectedValue.ToString
        If (auxcombo = "4") Then

            Dim cmd As String = "SELECT `ID_GRUPO_SGA`,`GRUPO_GENERAL`FROM sga where ID_GRUPO_SGA=" & auxcombo & ""
            Dim da As New SQLiteDataAdapter(cmd, SQLiteCon)
            Dim dt As DataTable = New DataTable("sga")
            da.Fill(dt)

            With ComboBox17
                .DataSource = dt
                .DisplayMember = "GRUPO_GENERAL"
                .ValueMember = "ID_GRUPO_SGA"
            End With
            cargarClasePeligro3()
            cargarClasePeligro2()
            cargarClasePeligro()


        Else
            '  GrupoGeneral2()
            GrupoGeneral3()
            GrupoGeneral4()
        End If
    End Sub




    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        cargarCategoriaPeligro()
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.SelectedIndexChanged
        cargarClasePeligro()
        'validarprimerovacio()
    End Sub

    Sub insertarReactivo()
        Try
            Dim x As Integer


            SQLiteCon.Close()


                SQLiteCon.Open()
                SQLliteCMD = New SQLiteCommand

                With SQLliteCMD
                    .CommandText = " INSERT INTO REACTIVO (`ID_REACTIVO`, `NOMBRE_REAC`,`COD_CUS`,`ADVERTENCIA`,
                                                            `PRI_AUXILIO`,`ESTADO`,`UNIDAD_MEDIDA`,
                                                            `FECHA_VENC`, `FICHA_TEC`,`ID_FABRICANTE` ) VALUES (NULL, @NOMBRE_REAC,
                                                            @COD_CUS,@ADVERTENCIA,@PRI_AUXILIO,@ESTADO,
                                                            @UNIDAD_MEDIDA,@FECHA_VENC,@FICHA_TEC,@ID_FABRICANTE)"

                .Connection = SQLiteCon

                .Parameters.AddWithValue("@NOMBRE_REAC", Me.TextBox3.Text)
                .Parameters.AddWithValue("@COD_CUS", Me.TextBox2.Text)
                .Parameters.AddWithValue("@ADVERTENCIA", Me.TextBox1.Text)
                .Parameters.AddWithValue("@PRI_AUXILIO", Me.RichTextBox2.Text)
                .Parameters.AddWithValue("@ESTADO", Me.ComboBox1.Text)
                .Parameters.AddWithValue("@UNIDAD_MEDIDA", Me.ComboBox2.Text)
                .Parameters.AddWithValue("@FECHA_VENC", Me.DateTimePicker1.Value)
                .Parameters.AddWithValue("@FICHA_TEC", Application.StartupPath & "\FichasTecnicas\" & "FT" & TextBox6.Text & ".pdf")
                .Parameters.AddWithValue("@ID_FABRICANTE", Me.ComboBox3.SelectedValue.ToString)
                .ExecuteNonQuery()
                End With

                SQLiteCon.Close()
                FormGuardarExitoso.Show()
                limpiarformReac()
                MAXID()



        Catch ex As Exception
            mensaje_error = ex.Message
            FormError.mensaje(mensaje_error)
            FormError.Show()
            SQLiteCon.Close()
            Return
            End Try
            SQLiteCon.Close()

    End Sub


    Sub limpiarformReac()
        TextBox2.Clear()
        TextBox3.Clear()
        RichTextBox2.Clear()
        TextBox9.Clear()

    End Sub



End Class