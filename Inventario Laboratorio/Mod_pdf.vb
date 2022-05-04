Imports System.Data.SQLite

Module Mod_pdf
    'variables para conectar
    Dim cnn As SQLiteConnection
    Dim cmd As SQLiteCommand
    Public dr As SQLiteDataReader

    'variables de conexión
    Public str_conexion As String = "Data Source=" & Application.StartupPath & "\BD_Lab.s3db;"




    Public Function conectar() As Boolean
        Try
            conectar = False
            cnn = New SQLiteConnection
            cnn.ConnectionString = str_conexion
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
            End If
            conectar = True
        Catch ex As Exception
            conectar = False
        End Try
    End Function
    Public Function desconectar() As Boolean
        Try
            desconectar = False
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
                desconectar = True
            End If
        Catch ex As Exception
            desconectar = False
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function fun_ExecuteReader(ByVal cadenasql As String, Optional i As Integer = 0) As SQLiteDataReader
        Try
            cmd = New SQLiteCommand
            cmd.CommandText = cadenasql
            If i = 0 Then
                cmd.CommandType = CommandType.Text
            Else
                cmd.CommandType = CommandType.StoredProcedure
            End If
            cmd.Connection = cnn
            Return cmd.ExecuteReader()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Module
