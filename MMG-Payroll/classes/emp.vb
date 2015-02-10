Imports MySql.Data.MySqlClient
Public Class emp

    Private _emp_no As Integer
    Private _name As String

    Public Property emp_no() As Integer
        Get
            Return _emp_no
        End Get
        Set(ByVal value As Integer)
            _emp_no = value
        End Set
    End Property
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Function save() As Boolean
        Dim cmd As New MySqlCommand
        SET_COMMAND_PROPERTIES(cmd, "EMPLOYEE_NEW")
        cmd.Parameters.AddWithValue("_emp_no", emp_no)
        cmd.Parameters.AddWithValue("_name", _name)

        If EXECUTE_COMMAND(cmd) Then
            save = True
        Else
            save = False
        End If
    End Function

End Class
