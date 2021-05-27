Module mysql_settings_Structure
    Public Structure MySQLSettings
        Public server_name As String
        Public port As Integer
        Public user_name As String
        Public password As String
        Public db_name As String

        Public Sub set_mysql_settings(ByVal server_name_val As String, ByVal port_val As Integer,
                                      ByVal user_name_val As String, ByVal password_val As String, ByVal db_name_val As String)
            server_name = server_name_val
            port = port_val
            user_name = user_name_val
            password = password_val
            db_name = db_name_val
        End Sub
    End Structure
End Module
