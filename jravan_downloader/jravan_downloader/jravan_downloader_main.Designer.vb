<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.AxJVLink1 = New AxJVDTLabLib.AxJVLink()
        Me.jravan_settings_button = New System.Windows.Forms.Button()
        Me.mysql_settings_button = New System.Windows.Forms.Button()
        Me.start_button = New System.Windows.Forms.Button()
        Me.permanent_update_chkbox = New System.Windows.Forms.CheckBox()
        Me.log_txtarea = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.initalize_db_button = New System.Windows.Forms.Button()
        Me.AxJVLink2 = New AxJVDTLabLib.AxJVLink()
        Me.AxJVLink3 = New AxJVDTLabLib.AxJVLink()
        Me.fetch_setup_data_button = New System.Windows.Forms.Button()
        Me.prgJVRead = New System.Windows.Forms.ProgressBar()
        Me.prgDownload = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tmrDownload = New System.Windows.Forms.Timer(Me.components)
        Me.AxJVLink4 = New AxJVDTLabLib.AxJVLink()
        Me.AxJVLink5 = New AxJVDTLabLib.AxJVLink()
        Me.updateTimeWatcher = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.AxJVLink1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxJVLink2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxJVLink3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxJVLink4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxJVLink5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxJVLink1
        '
        Me.AxJVLink1.Enabled = True
        Me.AxJVLink1.Location = New System.Drawing.Point(437, 8)
        Me.AxJVLink1.Name = "AxJVLink1"
        Me.AxJVLink1.OcxState = CType(resources.GetObject("AxJVLink1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxJVLink1.Size = New System.Drawing.Size(192, 192)
        Me.AxJVLink1.TabIndex = 0
        '
        'jravan_settings_button
        '
        Me.jravan_settings_button.Location = New System.Drawing.Point(25, 26)
        Me.jravan_settings_button.Name = "jravan_settings_button"
        Me.jravan_settings_button.Size = New System.Drawing.Size(127, 23)
        Me.jravan_settings_button.TabIndex = 1
        Me.jravan_settings_button.Text = "JRAVAN settings"
        Me.jravan_settings_button.UseVisualStyleBackColor = True
        '
        'mysql_settings_button
        '
        Me.mysql_settings_button.Location = New System.Drawing.Point(25, 55)
        Me.mysql_settings_button.Name = "mysql_settings_button"
        Me.mysql_settings_button.Size = New System.Drawing.Size(127, 23)
        Me.mysql_settings_button.TabIndex = 2
        Me.mysql_settings_button.Text = "MySQL settings"
        Me.mysql_settings_button.UseVisualStyleBackColor = True
        '
        'start_button
        '
        Me.start_button.Location = New System.Drawing.Point(25, 224)
        Me.start_button.Name = "start_button"
        Me.start_button.Size = New System.Drawing.Size(127, 63)
        Me.start_button.TabIndex = 60
        Me.start_button.Text = "Start"
        Me.start_button.UseVisualStyleBackColor = True
        '
        'permanent_update_chkbox
        '
        Me.permanent_update_chkbox.AutoSize = True
        Me.permanent_update_chkbox.Location = New System.Drawing.Point(25, 193)
        Me.permanent_update_chkbox.Name = "permanent_update_chkbox"
        Me.permanent_update_chkbox.Size = New System.Drawing.Size(146, 16)
        Me.permanent_update_chkbox.TabIndex = 8
        Me.permanent_update_chkbox.Text = "Permanent Data Update"
        Me.permanent_update_chkbox.UseVisualStyleBackColor = True
        '
        'log_txtarea
        '
        Me.log_txtarea.EnableAutoDragDrop = True
        Me.log_txtarea.Location = New System.Drawing.Point(177, 39)
        Me.log_txtarea.Name = "log_txtarea"
        Me.log_txtarea.ReadOnly = True
        Me.log_txtarea.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.log_txtarea.Size = New System.Drawing.Size(452, 190)
        Me.log_txtarea.TabIndex = 5
        Me.log_txtarea.TabStop = False
        Me.log_txtarea.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(179, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Logs"
        '
        'initalize_db_button
        '
        Me.initalize_db_button.Location = New System.Drawing.Point(25, 84)
        Me.initalize_db_button.Name = "initalize_db_button"
        Me.initalize_db_button.Size = New System.Drawing.Size(127, 23)
        Me.initalize_db_button.TabIndex = 7
        Me.initalize_db_button.Text = "Initialize database"
        Me.initalize_db_button.UseVisualStyleBackColor = True
        '
        'fetch_setup_data_button
        '
        Me.fetch_setup_data_button.Location = New System.Drawing.Point(25, 145)
        Me.fetch_setup_data_button.Name = "fetch_setup_data_button"
        Me.fetch_setup_data_button.Size = New System.Drawing.Size(127, 23)
        Me.fetch_setup_data_button.TabIndex = 63
        Me.fetch_setup_data_button.Text = "Get setup data"
        Me.fetch_setup_data_button.UseVisualStyleBackColor = True
        '
        'prgJVRead
        '
        Me.prgJVRead.Location = New System.Drawing.Point(422, 258)
        Me.prgJVRead.Name = "prgJVRead"
        Me.prgJVRead.Size = New System.Drawing.Size(207, 23)
        Me.prgJVRead.TabIndex = 64
        '
        'prgDownload
        '
        Me.prgDownload.Location = New System.Drawing.Point(181, 258)
        Me.prgDownload.Name = "prgDownload"
        Me.prgDownload.Size = New System.Drawing.Size(210, 25)
        Me.prgDownload.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(420, 243)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 12)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "JVRead progress"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(179, 243)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 12)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Download progress"
        '
        'tmrDownload
        '
        Me.tmrDownload.Interval = 500
        '
        'AxJVLink4
        '
        Me.AxJVLink4.Enabled = True
        Me.AxJVLink4.Location = New System.Drawing.Point(409, 230)
        Me.AxJVLink4.Name = "AxJVLink4"
        Me.AxJVLink4.OcxState = CType(resources.GetObject("AxJVLink4.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxJVLink4.Size = New System.Drawing.Size(192, 192)
        Me.AxJVLink4.TabIndex = 68
        '
        'AxJVLink5
        '
        Me.AxJVLink5.Enabled = True
        Me.AxJVLink5.Location = New System.Drawing.Point(73, 205)
        Me.AxJVLink5.Name = "AxJVLink5"
        Me.AxJVLink5.OcxState = CType(resources.GetObject("AxJVLink5.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxJVLink5.Size = New System.Drawing.Size(192, 192)
        Me.AxJVLink5.TabIndex = 69
        '
        'updateTimeWatcher
        '
        Me.updateTimeWatcher.Interval = 1000
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(536, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 12)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "AutoUpdate: OFF"
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 295)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.AxJVLink5)
        Me.Controls.Add(Me.AxJVLink4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.prgDownload)
        Me.Controls.Add(Me.prgJVRead)
        Me.Controls.Add(Me.fetch_setup_data_button)
        Me.Controls.Add(Me.AxJVLink3)
        Me.Controls.Add(Me.AxJVLink2)
        Me.Controls.Add(Me.initalize_db_button)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.log_txtarea)
        Me.Controls.Add(Me.permanent_update_chkbox)
        Me.Controls.Add(Me.start_button)
        Me.Controls.Add(Me.mysql_settings_button)
        Me.Controls.Add(Me.jravan_settings_button)
        Me.Controls.Add(Me.AxJVLink1)
        Me.Name = "MainWindow"
        Me.Text = "JRAVAN downloader"
        CType(Me.AxJVLink1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxJVLink2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxJVLink3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxJVLink4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxJVLink5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AxJVLink1 As AxJVDTLabLib.AxJVLink
    Friend WithEvents jravan_settings_button As Button
    Friend WithEvents mysql_settings_button As Button
    Friend WithEvents start_button As Button
    Friend WithEvents permanent_update_chkbox As CheckBox
    Friend WithEvents log_txtarea As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents initalize_db_button As Button
    Friend WithEvents AxJVLink2 As AxJVDTLabLib.AxJVLink
    Friend WithEvents AxJVLink3 As AxJVDTLabLib.AxJVLink
    Friend WithEvents fetch_setup_data_button As Button
    Friend WithEvents prgJVRead As ProgressBar
    Friend WithEvents prgDownload As ProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tmrDownload As Timer
    Friend WithEvents AxJVLink4 As AxJVDTLabLib.AxJVLink
    Friend WithEvents AxJVLink5 As AxJVDTLabLib.AxJVLink
    Friend WithEvents updateTimeWatcher As Timer
    Friend WithEvents Label4 As Label
End Class
