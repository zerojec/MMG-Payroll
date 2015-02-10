Imports MySql.Data.MySqlClient

Module connection

    Public con As New MySqlConnection
    Public err_global As New Exception    
    Public this_date_time As New DateTime

    Public Function OPEN_CONNECTION() As Boolean
        Dim constr As String
        constr = My.Settings.constr
        con = New MySqlConnection(constr)

        Try
            con.Open()
            OPEN_CONNECTION = True
        Catch ex As Exception
            clear_exception()
            err_global = ex
            OPEN_CONNECTION = False
        End Try

    End Function

    Public Function LOAD_DATATABLE_FROM_STOREDPRO(ByRef cmd As MySqlCommand) As DataTable
        Dim dt As New DataTable
        Dim da As MySqlDataAdapter

        Try
            da = New MySqlDataAdapter(cmd)
            da.Fill(dt)
            LOAD_DATATABLE_FROM_STOREDPRO = dt
        Catch ex As Exception
            clear_exception()
            err_global = ex
            LOAD_DATATABLE_FROM_STOREDPRO = Nothing
        End Try
    End Function

    Public Function LOAD_DATATABLE(ByVal sql As String) As DataTable
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(sql, con)
        Try
            da.Fill(dt)
            If dt IsNot Nothing Then
                LOAD_DATATABLE = dt
            Else
                LOAD_DATATABLE = Nothing
            End If
        Catch ex As Exception
            clear_exception()
            err_global = ex
            LOAD_DATATABLE = Nothing
        End Try
    End Function

    Public Function EXECUTE_COMMAND(ByRef cmd As MySqlCommand) As Boolean
        Try
            cmd.ExecuteNonQuery()
            EXECUTE_COMMAND = True
        Catch ex As Exception
            clear_exception()
            err_global = ex
            EXECUTE_COMMAND = False
        End Try
    End Function

    Public Sub SET_COMMAND_PROPERTIES(ByRef cmd As MySqlCommand, ByVal sql As String)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = sql
        cmd.Connection = con
    End Sub

    Public Sub CLEAR_EXCEPTION()
        err_global = Nothing
    End Sub

    Public Function GetLastDayOfMonth(ByVal intMonth As Integer, ByVal intYear As Integer) As Date
        GetLastDayOfMonth = DateSerial(intYear, intMonth + 1, 0)
    End Function

   
End Module
