Public Class mysql_settings
    Dim mysql_conf As MySQLSettings

    Private Sub mysql_settings_ok_button_Click(sender As Object, e As EventArgs) Handles mysql_settings_ok_button.Click
        mysql_conf.set_mysql_settings(
            server_name_txtbox.Text,
            Val(port_txtbox.Text),
            user_name_txtbox.Text,
            password_txtbox.Text,
            db_name_txtbox.Text
        )
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Public Function get_mysql_settings()
        Return mysql_conf
    End Function
End Class