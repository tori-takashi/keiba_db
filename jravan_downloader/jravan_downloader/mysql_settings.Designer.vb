<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mysql_settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mysql_settings))
        Me.server_name_txtbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.user_name_txtbox = New System.Windows.Forms.TextBox()
        Me.password_txtbox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.db_name_txtbox = New System.Windows.Forms.TextBox()
        Me.mysql_settings_ok_button = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.port_txtbox = New System.Windows.Forms.TextBox()
        Me.AxJVLink1 = New AxJVDTLabLib.AxJVLink()
        CType(Me.AxJVLink1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'server_name_txtbox
        '
        Me.server_name_txtbox.Location = New System.Drawing.Point(89, 50)
        Me.server_name_txtbox.Name = "server_name_txtbox"
        Me.server_name_txtbox.Size = New System.Drawing.Size(254, 19)
        Me.server_name_txtbox.TabIndex = 0
        Me.server_name_txtbox.Text = "localhost"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "MySQL Settings"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Server Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "User Name"
        '
        'user_name_txtbox
        '
        Me.user_name_txtbox.Location = New System.Drawing.Point(89, 101)
        Me.user_name_txtbox.Name = "user_name_txtbox"
        Me.user_name_txtbox.Size = New System.Drawing.Size(254, 19)
        Me.user_name_txtbox.TabIndex = 2
        Me.user_name_txtbox.Text = "root"
        '
        'password_txtbox
        '
        Me.password_txtbox.Location = New System.Drawing.Point(89, 126)
        Me.password_txtbox.Name = "password_txtbox"
        Me.password_txtbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.password_txtbox.Size = New System.Drawing.Size(254, 19)
        Me.password_txtbox.TabIndex = 3
        Me.password_txtbox.Text = ""
        Me.password_txtbox.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "DB Name"
        '
        'db_name_txtbox
        '
        Me.db_name_txtbox.Location = New System.Drawing.Point(88, 151)
        Me.db_name_txtbox.Name = "db_name_txtbox"
        Me.db_name_txtbox.Size = New System.Drawing.Size(254, 19)
        Me.db_name_txtbox.TabIndex = 4
        Me.db_name_txtbox.Text = "test"
        '
        'mysql_settings_ok_button
        '
        Me.mysql_settings_ok_button.Location = New System.Drawing.Point(15, 190)
        Me.mysql_settings_ok_button.Name = "mysql_settings_ok_button"
        Me.mysql_settings_ok_button.Size = New System.Drawing.Size(328, 23)
        Me.mysql_settings_ok_button.TabIndex = 99
        Me.mysql_settings_ok_button.Text = "OK"
        Me.mysql_settings_ok_button.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 12)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Port"
        '
        'port_txtbox
        '
        Me.port_txtbox.Location = New System.Drawing.Point(89, 76)
        Me.port_txtbox.Name = "port_txtbox"
        Me.port_txtbox.Size = New System.Drawing.Size(253, 19)
        Me.port_txtbox.TabIndex = 1
        Me.port_txtbox.Text = "3306"
        '
        'AxJVLink1
        '
        Me.AxJVLink1.Enabled = True
        Me.AxJVLink1.Location = New System.Drawing.Point(280, 48)
        Me.AxJVLink1.Name = "AxJVLink1"
        Me.AxJVLink1.OcxState = CType(resources.GetObject("AxJVLink1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxJVLink1.Size = New System.Drawing.Size(192, 192)
        Me.AxJVLink1.TabIndex = 100
        '
        'mysql_settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 225)
        Me.Controls.Add(Me.AxJVLink1)
        Me.Controls.Add(Me.port_txtbox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.mysql_settings_ok_button)
        Me.Controls.Add(Me.db_name_txtbox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.password_txtbox)
        Me.Controls.Add(Me.user_name_txtbox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.server_name_txtbox)
        Me.Name = "mysql_settings"
        Me.Text = "MySQL Settings"
        CType(Me.AxJVLink1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents server_name_txtbox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents user_name_txtbox As TextBox
    Friend WithEvents password_txtbox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents db_name_txtbox As TextBox
    Friend WithEvents mysql_settings_ok_button As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents port_txtbox As TextBox
    Friend WithEvents AxJVLink1 As AxJVDTLabLib.AxJVLink
End Class
