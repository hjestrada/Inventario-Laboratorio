


Option Strict Off
Option Explicit On

Imports System.Runtime.InteropServices
Imports System.Data.SQLite
Imports System.Data.SqlClient
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
    Dim GrupoGeneralaux, GrupoClasePeligroaux, CategoriaPeligroaux As String
    Dim table As New DataTable



    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBox1.SelectedIndex = 0
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList

        ComboBox2.SelectedIndex = 0
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList



        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList

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
        cargarPictograma()
        cargarPictograma2()
        cargarClasePeligro3()
        cargarPictograma3()

    End Sub

    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

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


        GrupoGeneralaux = ComboBox14.SelectedValue.ToString



        Try

            Dim MySQLDA As New SQLiteDataAdapter("SELECT CLASE_PELIGRO,ID_CLASIFICACION FROM clasificacion INNER JOIN sga WHERE SGA.ID_GRUPO_SGA=@Gg and clasificacion.ID_GRUPO_SGA  =@Gg", SQLiteCon)

            MySQLDA.SelectCommand.Parameters.AddWithValue("@Gg", GrupoGeneralaux)
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


        GrupoGeneralaux = ComboBox11.SelectedValue.ToString


        Try

            Dim MySQLDA As New SQLiteDataAdapter("SELECT CLASE_PELIGRO,ID_CLASIFICACION FROM clasificacion INNER JOIN sga WHERE SGA.ID_GRUPO_SGA=@Gg and clasificacion.ID_GRUPO_SGA  =@Gg", SQLiteCon)

            MySQLDA.SelectCommand.Parameters.AddWithValue("@Gg", GrupoGeneralaux)
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








    Public Sub cargarPictograma()
        Try


            Dim consulta1 As String
            Dim lista1 As Byte

            CategoriaPeligroaux = ComboBox4.SelectedValue.ToString

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
    End Sub

    Private Sub ComboBox13_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox13.SelectedIndexChanged
        cargarCategoriaPeligro2()
    End Sub

    Private Sub ComboBox12_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox12.SelectedIndexChanged
        cargarPictograma2()
    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox11.SelectedIndexChanged
        cargarClasePeligro3()
    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox10.SelectedIndexChanged
        cargarCategoriaPeligro3()
    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged
        cargarPictograma3()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        cargarCategoriaPeligro()
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.SelectedIndexChanged
        cargarClasePeligro()
    End Sub
End Class