Imports MySql.Data.MySqlClient

Public Class MainWindow

    Dim builder As New MySqlConnectionStringBuilder

    Dim conn_for_injector_manager As MySqlConnection
    Dim conn_for_injector As MySqlConnection
    Dim injector_manager As DBInjectorManager

    Friend WithEvents InterfaceJVLink As JVDTLabLib.JVLink
    Dim ReturnCodeInterfaceJVLink As Long

    Dim order_types As String() = {
            "tansyou",
            "hukusyou",
            "waku_ren",
            "uma_ren",
            "wide",
            "uma_tan",
            "3renpuku"
        }

    Private Sub jravan_settings_button_Click(sender As Object, e As EventArgs) Handles jravan_settings_button.Click
        Try
            Dim IReturnCode As Long
            IReturnCode = AxJVLink1.JVSetUIProperties()
            If IReturnCode <> 0 Then
                MsgBox("Error has occured, code:" & IReturnCode, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub mysql_settings_button_Click(sender As Object, e As EventArgs) Handles mysql_settings_button.Click
        Dim mysql_settings_form As mysql_settings = New mysql_settings()

        If mysql_settings_form.ShowDialog = DialogResult.OK Then
            Dim mysql_conf As MySQLSettings = mysql_settings_form.get_mysql_settings()

            builder.Server = mysql_conf.server_name
            builder.Port = mysql_conf.port
            builder.UserID = mysql_conf.user_name
            builder.Password = mysql_conf.password
            builder.Database = mysql_conf.db_name
        End If
        mysql_settings_form.Dispose()
    End Sub

    Private Sub start_button_Click(sender As Object, e As EventArgs) Handles start_button.Click
        For Each i In {"1"}
            data_download_with_IOption(i)
        Next

        If permanent_update_chkbox.Checked Then
            InterfaceJVLink = New JVDTLabLib.JVLink
            ReturnCodeInterfaceJVLink = InterfaceJVLink.JVWatchEvent()
            updateTimeWatcher.Enabled = True
            Label4.Text = "AutoUpdate: ON"
        End If

    End Sub

    Private Sub fetch_setup_data_button_Click(sender As Object, e As EventArgs) Handles fetch_setup_data_button.Click
        data_download_with_IOption("4")
    End Sub

    Public WithEvents time_watch As MainWindow
    Public thursday_night_processed As Boolean = False
    Public sunday_night_processed As Boolean = False

    Private Sub updateTimeWatcher_Tick(sender As Object, e As EventArgs) Handles updateTimeWatcher.Tick
        If Weekday(Today) = vbThursday And thursday_night_processed = False Then
            thursday_night_update()
            thursday_night_processed = True
        ElseIf Weekday(Today) = vbThursday And thursday_night_processed = True Then
        Else
            thursday_night_processed = False
        End If

        If Weekday(Today) = vbSunday And sunday_night_processed = False Then
            sunday_night_update()
            sunday_night_processed = True
        ElseIf Weekday(Today) = vbSunday And sunday_night_processed = True Then
        Else
            sunday_night_processed = False
        End If

    End Sub

    Private Function thursday_night_update()

    End Function

    Private Function sunday_night_update()
        For Each i In {"1", "2"}
            data_download_with_IOption(i)
        Next
    End Function

    Private Sub InterfaceJVLink_JVEventPay(ByVal bstr As String) Handles InterfaceJVLink.JVEvtPay
        update_data_with_events("0B12", bstr, "JVEventPay")
    End Sub

    Private Sub InterfaceJVLink_JVEvtJockeyChange(ByVal bstr As String) Handles InterfaceJVLink.JVEvtJockeyChange
        update_data_with_events("0B16", bstr, "JVEvtJockeyChange")
    End Sub

    Private Sub InterfaceJVLink_JVEvtWeather(ByVal bstr As String) Handles InterfaceJVLink.JVEvtWeather
        update_data_with_events("0B16", bstr, "JVEvtWeather")
    End Sub

    Private Sub InterfaceJVLink_JVEvtCourseChange(ByVal bstr As String) Handles InterfaceJVLink.JVEvtCourseChange
        update_data_with_events("0B16", bstr, "JVEvtCourseChange")
    End Sub

    Private Sub InterfaceJVLink_JVEvtAvoid(ByVal bstr As String) Handles InterfaceJVLink.JVEvtAvoid
        update_data_with_events("0B16", bstr, "JVEvtAvoid")
    End Sub

    Private Sub InterfaceJVLink_JVEvtTimeChange(ByVal bstr As String) Handles InterfaceJVLink.JVEvtTimeChange
        update_data_with_events("0B16", bstr, "JVEvtTimeChange")
    End Sub

    Private Sub InterfaceJVLink_JVEvtWeight(ByVal bstr As String) Handles InterfaceJVLink.JVEvtWeather
        update_data_with_events("0B11", bstr, "JVEvtWeight")
    End Sub

    Private Function update_data_with_events(strDataSpec As String, bstr As String, eventTxt As String)
        ReturnCodeInterfaceJVLink = AxJVLink1.JVRTOpen(strDataSpec, bstr)
        Dim injector_manager As DBInjectorManager
        conn_for_injector = New MySqlConnection(builder.ToString())
        conn_for_injector.Open()
        conn_for_injector_manager = New MySqlConnection(builder.ToString())
        conn_for_injector_manager.Open()

        log_txtarea.AppendText(eventTxt & " has occured. building tables with:" & strDataSpec & vbCrLf)
        injector_manager = New DBInjectorManager(conn_for_injector, conn_for_injector_manager, strDataSpec, "0")
        download_data(injector_manager)

        For Each injector In injector_manager.injectors.Values
            injector.bulk_replace_data()
        Next

        AxJVLink1.JVClose()
        conn_for_injector_manager.Close()
        conn_for_injector.Close()
    End Function


    Private Function data_download_with_IOption(IOption As String)
        initialize_start_button_click()
        conn_for_injector = New MySqlConnection(builder.ToString())
        conn_for_injector.Open()
        conn_for_injector_manager = New MySqlConnection(builder.ToString())
        conn_for_injector_manager.Open()

        Dim target_dataspec_query As String = "SELECT DISTINCT str_data_spec FROM jvlink_table_master WHERE IOption='" & IOption & "' AND parent_table_name='';"
        Dim target_dataspec_list As List(Of String) = New List(Of String)

        If IOption = "3" Or IOption = "4" Then
            target_dataspec_query = "SELECT str_data_spec FROM jvlink_table_master WHERE IOption='1' AND parent_table_name='';"
        End If

        Using dr As MySqlDataReader = New MySqlCommand(target_dataspec_query, conn_for_injector).ExecuteReader()
            While (dr.Read())
                target_dataspec_list.Add(dr("str_data_spec"))
            End While
        End Using

        For Each target_dataspec In target_dataspec_list
            log_txtarea.AppendText("building tables with:" & target_dataspec & vbCrLf)
            injector_manager = New DBInjectorManager(conn_for_injector, conn_for_injector_manager, target_dataspec, IOption)

            download_data(injector_manager)
            AxJVLink1.JVClose()
            If IOption = "1" Or "3" Or "4" Then
                For Each injector In injector_manager.injectors.Values
                    injector.bulk_insert_data()
                Next
            ElseIf IOption = "2" Then
                For Each injector In injector_manager.injectors.Values
                    injector.bulk_replace_data()
                Next
            End If
        Next

        conn_for_injector_manager.Close()
        conn_for_injector.Close()
    End Function

    Private Function initialize_start_button_click()
        Try
            If initialize_jvlink() Then
                log_txtarea.AppendText("JVLink was successfully initialized." & Environment.NewLine)
            End If

            If initialize_mysql() Then
                log_txtarea.AppendText("Successfully connected to MySQL server." & Environment.NewLine)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function

    Private Function initialize_jvlink()
        Dim sid As String
        Dim IReturnCode As Long
        Dim test As Integer

        sid = "jravan_downloader"
        test = 100

        IReturnCode = AxJVLink1.JVInit(sid)

        If IReturnCode <> 0 Then
            Throw New Exception("JVInit error occured, code:" & IReturnCode)
        End If

        Return True
    End Function

    Private Function initialize_mysql()
        Using conn As New MySqlConnection(builder.ToString())
            conn.Open()
        End Using
        Return True
    End Function

    Private IDownloadCount As Long
    Private JVOpenFlag As Boolean
    Private Function download_data(injector_manager As DBInjectorManager)
        Dim IReturnCode As Long

        Dim strDataSpec As String = injector_manager.strDataSpec
        Dim strFromTime As String = injector_manager.strFromTime
        Dim IOption As String = injector_manager.IOption

        Dim IReadCount As String
        Dim strLastFileTimestamp As String

        Const IBuffSize As Long = 1100000
        Const INameSize As Integer = 256
        Dim strBuff As String
        Dim strFileName As String

        tmrDownload.Enabled = False
        prgDownload.Value = 0
        prgJVRead.Value = 0

        Try
            IReturnCode = AxJVLink1.JVOpen(strDataSpec, strFromTime, IOption,
                                    IReadCount, IDownloadCount,
                                    strLastFileTimestamp)

            If IReturnCode <> 0 Then
                Throw New Exception("Error on JVOpen(), code:" & IReturnCode)
            Else
                log_txtarea.AppendText("loading for dataspec:" & injector_manager.strDataSpec & vbCrLf)
                log_txtarea.AppendText("Return code:" & IReturnCode & Environment.NewLine &
                       "Read File Number:" & IReadCount & Environment.NewLine &
                       "Download File Number:" & IDownloadCount & Environment.NewLine &
                       "Timestamp:" & strLastFileTimestamp & Environment.NewLine)
                injector_manager.set_fromtime(strLastFileTimestamp)

                If IDownloadCount = 0 Then
                    prgDownload.Maximum = 100
                    prgDownload.Value = 100
                Else
                    prgDownload.Maximum = IDownloadCount
                    tmrDownload.Enabled = True
                End If
                prgJVRead.Maximum = IReadCount
            End If

        Catch ex As Exception
            log_txtarea.AppendText("Error code:" & ex.Message & vbCrLf & ". skipped reading:" & strDataSpec & vbCrLf)
        End Try

        Try
            If IReadCount > 0 Then
                Do
                    Application.DoEvents()

                    strBuff = New String(vbNullChar, IBuffSize)
                    strFileName = New String(vbNullChar, INameSize)

                    IReturnCode = AxJVLink1.JVRead(strBuff, IBuffSize,
                                                   strFileName)

                    Select Case IReturnCode
                        Case 0
                            prgJVRead.Value = prgJVRead.Maximum
                            Exit Do
                        Case -1
                            prgJVRead.Value = prgJVRead.Value + 1
                            log_txtarea.AppendText("JVRead() is reading file:" & prgJVRead.Value & vbCrLf)
                        Case -3
                        Case -201
                            Throw New Exception("JVInit() has not completed.")
                            Exit Do
                        Case -503
                            Throw New Exception("File not found.")
                            Exit Do
                        Case Is > 0
                            injector_manager.injectors(Mid(strBuff, 1, 2)).targetDataStructure.SetData(
                                strBuff, injector_manager.injectors(Mid(strBuff, 1, 2)))
                    End Select
                Loop While (1)
            End If

            If tmrDownload.Enabled = True Then
                tmrDownload.Enabled = False
                prgDownload.Value = prgDownload.Maximum
            End If

        Catch ex As Exception
            log_txtarea.AppendText("Error code:" & ex.Message & vbCrLf & ". skip reading:" & strDataSpec & vbCrLf)
        End Try

    End Function

    Private Sub initalize_db_button_Click(sender As Object, e As EventArgs) Handles initalize_db_button.Click
        Dim db_name_tmp As String = builder.Database
        builder.Database = ""

        Using conn As MySqlConnection = New MySqlConnection(builder.ToString())
            conn.Open()
            initialize_mysql_database(conn, db_name_tmp)
            conn.Close()
        End Using

        builder.Database = db_name_tmp

        Using conn As MySqlConnection = New MySqlConnection(builder.ToString())
            conn.Open()
            initialize_mysql_tables(conn)
        End Using
    End Sub

    Private Function initialize_mysql_database(conn As MySqlConnection, db_name As String)
        Dim db_builder As DataBaseBuilder = New DataBaseBuilder(conn)
        db_builder.build_database(db_name)
        log_txtarea.AppendText("Database was successfully created." & Environment.NewLine)
    End Function

    Private Function initialize_mysql_tables(conn As MySqlConnection)
        Dim db_builder As DataBaseBuilder = New DataBaseBuilder(conn)
        db_builder.build_tables()
        log_txtarea.AppendText("Creating tables..." & Environment.NewLine)
        log_txtarea.AppendText("All tables were successfully created." & Environment.NewLine)
    End Function

    Private Sub tmrDownload_Tick(sender As Object, e As EventArgs) Handles tmrDownload.Tick
        Dim IReturnCode As Long

        IReturnCode = AxJVLink1.JVStatus
        If IReturnCode < 0 Then
            MsgBox("JVStatus() Error!")
            tmrDownload.Enabled = False

            IReturnCode = Me.AxJVLink1.JVClose()
            If IReturnCode <> 0 Then
                MsgBox("JVClose Error!")
            End If
        ElseIf IReturnCode < IDownloadCount Then
            prgDownload.Value = IReturnCode
        ElseIf IReturnCode = IDownloadCount Then
            tmrDownload.Enabled = False
            prgDownload.Value = IReturnCode
        End If
    End Sub
End Class

Public Structure DownloadDataOptions
    Dim strDataSpec As String
    Dim dataSpecIdentifier As String
    Dim strFromTime As String
    Dim IOption As String

    Dim targetDataStructure
    Dim targetInjector

    Sub New(strDataSpec_val, dataSpecIdentifier_val, strFromTime_val, IOption_val, targetDataStructure_val, targetInjector_val)
        strDataSpec = strDataSpec_val
        dataSpecIdentifier = dataSpecIdentifier_val
        strFromTime = strFromTime_val
        IOption = IOption_val
        targetDataStructure = targetDataStructure_val
        targetInjector = targetInjector_val
    End Sub
End Structure
