Imports MySql.Data.MySqlClient

Module JVLink_Stluct
    '�e�Z�b�^�[���\�b�h�����R�[�h��}������悤�ɕύX 20200322


    '========================================================================
    '  JRA-VAN Data Lab. JV-Data�\����
    '
    '
    '	�쐬: JRA-VAN �\�t�g�E�F�A�H�[
    '	�X�V:                           2009�N 9�� 8��
    '
    '========================================================================
    '	(C) Copyright JRA SYSTEM SERVICE CO.,LTD. 2007 All rights reserved
    '========================================================================


    '''''''''''''''''''' �Z�b�g�f�[�^�̃v���O���~���O�p�[�c '''''''''''''''''''''''''''''''''''''

    '------------------------------------------------------------------------
    '�@�@��������o�C�g���Ő؏o��
    '------------------------------------------------------------------------
    '�@ [����]
    '		myByte			= ������
    '		strStart		= �J�n�ʒu
    '		strLength		= �o�C�g��
    '	[�߂�l]
    '		String			= ������
    '------------------------------------------------------------------------
    Public Function MidB2S(ByRef myByte As Byte(),
          ByVal bSt As Long,
          ByVal bLen As Long) As String
        '������C�ӂɐ؏o��
        MidB2S = System.Text.Encoding.GetEncoding(932).GetString(myByte, bSt - 1, bLen)
    End Function

    '------------------------------------------------------------------------
    '�@�@�o�C�g�z����o�C�g���Ő؏o��
    '------------------------------------------------------------------------
    '�@ [����]
    '		myByte			= ������
    '		strStart		= �J�n�ʒu
    '		strLength		= �o�C�g��
    '	[�߂�l]
    '		String			= ������
    '------------------------------------------------------------------------
    Public Function MidB2B(ByRef myByte As Byte(),
           ByVal bSt As Long,
           ByVal bLen As Long) As Byte()
        Dim cBt As Byte()
        ReDim cBt(bLen - 1)
        ReDim MidB2B(bLen - 1)

        '������o�C�g�C�Ӑ؂�o��
        Dim i, j As Integer
        j = 0
        i = 0
        For i = bSt - 1 To bSt - 1 + bLen - 1
            cBt(j) = myByte(i)
            j = j + 1
        Next
        MidB2B = cBt
    End Function

    '------------------------------------------------------------------------
    '�@�@��������o�C�g�z��ɕϊ�
    '------------------------------------------------------------------------
    '�@ [����]
    '		myString		= ������
    '	[�߂�l]
    '		Byte()			= �o�C�g�z��
    '------------------------------------------------------------------------
    Public Function Str2Byte(ByRef myString As String) As Byte()
        'Shift JIS�ɕϊ�����
        Str2Byte = System.Text.Encoding.GetEncoding(932).GetBytes(myString)
    End Function


    '''''''''''''''''''' ���ʍ\���� ''''''''''''''''''''''''''''''''''''''''

    '<�N����>
    Public Structure YMD
        Public Year As String     ''�N
        Public Month As String     ''��
        Public Day As String     ''��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Year = MidB2S(bBuff, 1, 4)
            Month = MidB2S(bBuff, 5, 2)
            Day = MidB2S(bBuff, 7, 2)
        End Sub
    End Structure

    '<�����b>
    Public Structure HMS
        Public Hour As String     ''��
        Public Minute As String     ''��
        Public Second As String     ''�b
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Hour = MidB2S(bBuff, 1, 2)
            Minute = MidB2S(bBuff, 3, 2)
            Second = MidB2S(bBuff, 5, 2)
        End Sub
    End Structure

    '<����>
    Public Structure HM
        Public Hour As String     ''��
        Public Minute As String     ''��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Hour = MidB2S(bBuff, 1, 2)
            Minute = MidB2S(bBuff, 3, 2)
        End Sub
    End Structure

    '<��������>
    Public Structure MDHM
        Public Month As String     ''��
        Public Day As String     ''��
        Public Hour As String     ''��
        Public Minute As String     ''��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Month = MidB2S(bBuff, 1, 2)
            Day = MidB2S(bBuff, 3, 2)
            Hour = MidB2S(bBuff, 5, 2)
            Minute = MidB2S(bBuff, 7, 2)
        End Sub
    End Structure

    '<���R�[�h�w�b�_>
    Public Structure RECORD_ID
        Public RecordSpec As String    ''���R�[�h���
        Public DataKubun As String    ''�f�[�^�敪
        Public MakeDate As YMD     ''�f�[�^�쐬�N����
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            RecordSpec = MidB2S(bBuff, 1, 2)
            DataKubun = MidB2S(bBuff, 3, 1)
            MakeDate.SetDataB(MidB2B(bBuff, 4, 8))
        End Sub
    End Structure

    '<�������ʏ��>
    Public Structure RACE_ID
        Public Year As String     ''�J�ÔN
        Public MonthDay As String    ''�J�Ì���
        Public JyoCD As String     ''���n��R�[�h
        Public Kaiji As String     ''�J�É�[��N��]
        Public Nichiji As String    ''�J�Ó���[N����]
        Public RaceNum As String    ''���[�X�ԍ�
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Year = MidB2S(bBuff, 1, 4)
            MonthDay = MidB2S(bBuff, 5, 4)
            JyoCD = MidB2S(bBuff, 9, 2)
            Kaiji = MidB2S(bBuff, 11, 2)
            Nichiji = MidB2S(bBuff, 13, 2)
            RaceNum = MidB2S(bBuff, 15, 2)
        End Sub
    End Structure

    '<�������ʏ��Q>
    Public Structure RACE_ID2
        Public Year As String     ''�J�ÔN
        Public MonthDay As String    ''�J�Ì���
        Public JyoCD As String     ''���n��R�[�h
        Public Kaiji As String     ''�J�É�[��N��]
        Public Nichiji As String    ''�J�Ó���[N����]
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Year = MidB2S(bBuff, 1, 4)
            MonthDay = MidB2S(bBuff, 5, 4)
            JyoCD = MidB2S(bBuff, 9, 2)
            Kaiji = MidB2S(bBuff, 11, 2)
            Nichiji = MidB2S(bBuff, 13, 2)
        End Sub
    End Structure

    '<�{�N�E�݌v���я��>
    Public Structure SEI_RUIKEI_INFO
        Public SetYear As String    ''�ݒ�N
        Public HonSyokinTotal As String   ''�{�܋����v
        Public FukaSyokin As String    ''�t���܋����v
        Public ChakuKaisu() As String   ''����
        '�z��̏�����
        Public Sub Initialize()
            ReDim ChakuKaisu(5)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Initialize()      ''�z��̏�����
            SetYear = MidB2S(bBuff, 1, 4)
            HonSyokinTotal = MidB2S(bBuff, 5, 10)
            FukaSyokin = MidB2S(bBuff, 15, 10)
            Dim i As Integer = 0
            For i = 0 To 5
                ChakuKaisu(i) = MidB2S(bBuff, 25 + 6 * i, 6)
            Next i
        End Sub
    End Structure

    '<�ŋߏd�܏������>
    Public Structure SAIKIN_JYUSYO_INFO
        Public SaikinJyusyoid As RACE_ID  ''<�N��������R>
        Public Hondai As String     ''�������{��
        Public Ryakusyo10 As String    ''����������10��
        Public Ryakusyo6 As String    ''����������6��
        Public Ryakusyo3 As String    ''����������3��
        Public GradeCD As String    ''�O���[�h�R�[�h
        Public SyussoTosu As String    ''�o������
        Public KettoNum As String    ''�����o�^�ԍ�
        Public Bamei As String     ''�n��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            SaikinJyusyoid.SetDataB(MidB2B(bBuff, 1, 16))
            Hondai = MidB2S(bBuff, 17, 60)
            Ryakusyo10 = MidB2S(bBuff, 77, 20)
            Ryakusyo6 = MidB2S(bBuff, 97, 12)
            Ryakusyo3 = MidB2S(bBuff, 109, 6)
            GradeCD = MidB2S(bBuff, 115, 1)
            SyussoTosu = MidB2S(bBuff, 116, 2)
            KettoNum = MidB2S(bBuff, 118, 10)
            Bamei = MidB2S(bBuff, 128, 36)
        End Sub
    End Structure

    '<�{�N�E�O�N�E�݌v���я��>
    Public Structure HON_ZEN_RUIKEISEI_INFO
        Public SetYear As String    ''�ݒ�N
        Public HonSyokinHeichi As String  ''���n�{�܋����v
        Public HonSyokinSyogai As String  ''��Q�{�܋����v
        Public FukaSyokinHeichi As String  ''���n�t���܋����v
        Public FukaSyokinSyogai As String  ''��Q�t���܋����v
        Public ChakuKaisuHeichi As CHAKUKAISU6_INFO  ''���n����
        Public ChakuKaisuSyogai As CHAKUKAISU6_INFO  ''��Q����
        Public ChakuKaisuJyo() As CHAKUKAISU6_INFO  ''���n��ʒ���
        Public ChakuKaisuKyori() As CHAKUKAISU6_INFO ''�����ʒ���
        '�z��̏�����
        Public Sub Initialize()
            ReDim ChakuKaisuJyo(19)
            ReDim ChakuKaisuKyori(5)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Initialize()      ''�z��̏�����
            SetYear = MidB2S(bBuff, 1, 4)
            HonSyokinHeichi = MidB2S(bBuff, 5, 10)
            HonSyokinSyogai = MidB2S(bBuff, 15, 10)
            FukaSyokinHeichi = MidB2S(bBuff, 25, 10)
            FukaSyokinSyogai = MidB2S(bBuff, 35, 10)
            ChakuKaisuHeichi.SetDataB(MidB2B(bBuff, 45, 36))
            ChakuKaisuSyogai.SetDataB(MidB2B(bBuff, 81, 36))
            Dim i As Integer = 0
            For i = 0 To 19
                ChakuKaisuJyo(i).SetDataB(MidB2B(bBuff, 117 + 36 * i, 36))
            Next i
            For i = 0 To 5
                ChakuKaisuKyori(i).SetDataB(MidB2B(bBuff, 837 + 36 * i, 36))
            Next i
        End Sub
    End Structure

    '<���[�X���>
    Public Structure RACE_INFO
        Public YoubiCD As String    ''�j���R�[�h
        Public TokuNum As String    ''���ʋ����ԍ�
        Public Hondai As String     ''�������{��
        Public Fukudai As String    ''����������
        Public Kakko As String     ''�������J�b�R��
        Public HondaiEng As String    ''�������{�艢��
        Public FukudaiEng As String    ''���������艢��
        Public KakkoEng As String    ''�������J�b�R������
        Public Ryakusyo10 As String    ''���������̂P�O��
        Public Ryakusyo6 As String    ''���������̂U��
        Public Ryakusyo3 As String    ''���������̂R��
        Public Kubun As String     ''�������敪
        Public Nkai As String     ''�d�܉�[��N��]
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            YoubiCD = MidB2S(bBuff, 1, 1)
            TokuNum = MidB2S(bBuff, 2, 4)
            Hondai = MidB2S(bBuff, 6, 60)
            Fukudai = MidB2S(bBuff, 66, 60)
            Kakko = MidB2S(bBuff, 126, 60)
            HondaiEng = MidB2S(bBuff, 186, 120)
            FukudaiEng = MidB2S(bBuff, 306, 120)
            KakkoEng = MidB2S(bBuff, 426, 120)
            Ryakusyo10 = MidB2S(bBuff, 546, 20)
            Ryakusyo6 = MidB2S(bBuff, 566, 12)
            Ryakusyo3 = MidB2S(bBuff, 578, 6)
            Kubun = MidB2S(bBuff, 584, 1)
            Nkai = MidB2S(bBuff, 585, 3)
        End Sub
    End Structure

    '<�V��E�n����>
    Public Structure TENKO_BABA_INFO
        Public TenkoCD As String    ''�V��R�[�h
        Public SibaBabaCD As String    ''�Ŕn���ԃR�[�h
        Public DirtBabaCD As String    ''�_�[�g�n���ԃR�[�h
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            TenkoCD = MidB2S(bBuff, 1, 1)
            SibaBabaCD = MidB2S(bBuff, 2, 1)
            DirtBabaCD = MidB2S(bBuff, 3, 1)
        End Sub
    End Structure

    '<���񐔁i�T�C�Y3byte�j>
    Public Structure CHAKUKAISU3_INFO
        Public Chakukaisu() As String
        '�z��̏�����
        Public Sub Initialize()
            ReDim Chakukaisu(5)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Initialize()      ''�z��̏�����
            Dim i As Integer = 0
            For i = 0 To 5
                Chakukaisu(i) = MidB2S(bBuff, 1 + 3 * i, 3)
            Next i
        End Sub
    End Structure

    '<���񐔁i�T�C�Y4byte�j>
    Public Structure CHAKUKAISU4_INFO
        Public Chakukaisu() As String
        '�z��̏�����
        Public Sub Initialize()
            ReDim Chakukaisu(5)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Initialize()      ''�z��̏�����
            Dim i As Integer = 0
            For i = 0 To 5
                Chakukaisu(i) = MidB2S(bBuff, 1 + 4 * i, 4)
            Next i
        End Sub
    End Structure

    '<���񐔁i�T�C�Y5byte�j>
    Public Structure CHAKUKAISU5_INFO
        Public Chakukaisu() As String
        '�z��̏�����
        Public Sub Initialize()
            ReDim Chakukaisu(5)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Initialize()      ''�z��̏�����
            Dim i As Integer = 0
            For i = 0 To 5
                Chakukaisu(i) = MidB2S(bBuff, 1 + 5 * i, 5)
            Next i
        End Sub
    End Structure

    '<���񐔁i�T�C�Y6byte�j>
    Public Structure CHAKUKAISU6_INFO
        Public Chakukaisu() As String
        '�z��̏�����
        Public Sub Initialize()
            ReDim Chakukaisu(5)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Initialize()      ''�z��̏�����
            Dim i As Integer = 0
            For i = 0 To 5
                Chakukaisu(i) = MidB2S(bBuff, 1 + (6 * i), 6)
            Next i
        End Sub
    End Structure

    '<���������R�[�h>
    Public Structure RACE_JYOKEN
        Public SyubetuCD As String      ''������ʃR�[�h
        Public KigoCD As String       ''�����L���R�[�h
        Public JyuryoCD As String      ''�d�ʎ�ʃR�[�h
        Public JyokenCD() As String      ''���������R�[�h
        '�z��̏�����
        Public Sub Initialize()
            ReDim JyokenCD(4)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Initialize()      ''�z��̏�����
            SyubetuCD = MidB2S(bBuff, 1, 2)
            KigoCD = MidB2S(bBuff, 3, 3)
            JyuryoCD = MidB2S(bBuff, 6, 1)
            Dim i As Integer = 0
            For i = 0 To 4
                JyokenCD(i) = MidB2S(bBuff, 7 + 3 * i, 3)
            Next i
        End Sub
    End Structure

    '''''''''''''''''''' �f�[�^�\���� ''''''''''''''''''''''''''''''

    '****** �P�D���ʓo�^�n ****************************************
    '<�o�^�n�����>
    Public Structure TOKUUMA_INFO
        Public Num As String     ''�A��
        Public KettoNum As String    ''�����o�^�ԍ�
        Public Bamei As String     ''�n��
        Public UmaKigoCD As String    ''�n�L���R�[�h
        Public SexCD As String     ''���ʃR�[�h
        Public TozaiCD As String    ''�����t���������R�[�h
        Public ChokyosiCode As String   ''�����t�R�[�h
        Public ChokyosiRyakusyo As String  ''�����t������
        Public Futan As String     ''���S�d��
        Public Koryu As String     ''�𗬋敪
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Num = MidB2S(bBuff, 1, 3)
            KettoNum = MidB2S(bBuff, 4, 10)
            Bamei = MidB2S(bBuff, 14, 36)
            UmaKigoCD = MidB2S(bBuff, 50, 2)
            SexCD = MidB2S(bBuff, 52, 1)
            TozaiCD = MidB2S(bBuff, 53, 1)
            ChokyosiCode = MidB2S(bBuff, 54, 5)
            ChokyosiRyakusyo = MidB2S(bBuff, 59, 8)
            Futan = MidB2S(bBuff, 67, 3)
            Koryu = MidB2S(bBuff, 70, 1)
        End Sub
    End Structure
    Public Structure JV_TK_TOKUUMA
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID     ''<�������ʏ��>
        Public RaceInfo As RACE_INFO   ''<���[�X���>
        Public GradeCD As String    ''�O���[�h�R�[�h
        Public JyokenInfo As RACE_JYOKEN  ''<���������R�[�h>
        Public Kyori As String     ''����
        Public TrackCD As String    ''�g���b�N�R�[�h
        Public CourseKubunCD As String   ''�R�[�X�敪
        Public HandiDate As YMD     ''�n���f���\��
        Public TorokuTosu As String    ''�o�^����
        Public TokuUmaInfo() As TOKUUMA_INFO ''<�o�^�n�����>
        Public crlf As String     ''���R�[�h���
        '�z��̏�����
        Public Sub Initialize()
            ReDim TokuUmaInfo(299)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim current_record_id As Integer = injector.issue_id()

            Initialize()      ''�z��̏�����
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 21657
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            RaceInfo.SetDataB(MidB2B(bBuff, 28, 587))
            GradeCD = MidB2S(bBuff, 615, 1)
            JyokenInfo.SetDataB(MidB2B(bBuff, 616, 21))
            Kyori = MidB2S(bBuff, 637, 4)
            TrackCD = MidB2S(bBuff, 641, 2)
            CourseKubunCD = MidB2S(bBuff, 643, 2)
            HandiDate.SetDataB(MidB2B(bBuff, 645, 8))
            TorokuTosu = MidB2S(bBuff, 653, 3)

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            injector.append_to_col_init("youbi_code")
            injector.append_to_data(RaceInfo.YoubiCD)
            injector.append_to_col_init("tokubetsu_kyousou_bangou")
            injector.append_to_data(RaceInfo.TokuNum)
            Dim kyousoumei = "kyousoumei_"
            injector.append_to_col_init(kyousoumei & "hondai")
            injector.append_to_data(RaceInfo.Hondai)
            injector.append_to_col_init(kyousoumei & "hukudai")
            injector.append_to_data(RaceInfo.Fukudai)
            injector.append_to_col_init(kyousoumei & "kakkonai")
            injector.append_to_data(RaceInfo.Kakko)
            injector.append_to_col_init(kyousoumei & "hondai_ouzi")
            injector.append_to_data(RaceInfo.HondaiEng)
            injector.append_to_col_init(kyousoumei & "hukudai_ouzi")
            injector.append_to_data(RaceInfo.FukudaiEng)
            injector.append_to_col_init(kyousoumei & "kakkonai_ouzi")
            injector.append_to_data(RaceInfo.KakkoEng)
            injector.append_to_col_init(kyousoumei & "ryakusyou_10")
            injector.append_to_data(RaceInfo.Ryakusyo10)
            injector.append_to_col_init(kyousoumei & "ryakusyou_6")
            injector.append_to_data(RaceInfo.Ryakusyo6)
            injector.append_to_col_init(kyousoumei & "ryakusyou_3")
            injector.append_to_data(RaceInfo.Ryakusyo3)
            injector.append_to_col_init(kyousoumei & "kubun")
            injector.append_to_data(RaceInfo.Kubun)
            injector.append_to_col_init("zyuusyou_kaizi")
            injector.append_to_data(RaceInfo.Nkai)

            injector.append_to_col_init("grade_code")
            injector.append_to_data(GradeCD)

            injector.append_to_col_init("kyousou_syubetsu_code")
            injector.append_to_data(JyokenInfo.SyubetuCD)
            injector.append_to_col_init("kyousou_kigou_code")
            injector.append_to_data(JyokenInfo.KigoCD)
            injector.append_to_col_init("zyuuryou_syubetsu_code")
            injector.append_to_data(JyokenInfo.JyuryoCD)

            Dim kyousou_zyouken As String = "kyousou_zyouken_code_"
            injector.append_to_col_init(kyousou_zyouken & "2sai")
            injector.append_to_data(JyokenInfo.JyokenCD(0))
            injector.append_to_col_init(kyousou_zyouken & "3sai")
            injector.append_to_data(JyokenInfo.JyokenCD(1))
            injector.append_to_col_init(kyousou_zyouken & "4sai")
            injector.append_to_data(JyokenInfo.JyokenCD(2))
            injector.append_to_col_init(kyousou_zyouken & "5sai_izyou")
            injector.append_to_data(JyokenInfo.JyokenCD(3))
            injector.append_to_col_init(kyousou_zyouken & "saizyakunen")
            injector.append_to_data(JyokenInfo.JyokenCD(4))

            injector.append_to_col_init("kyori")
            injector.append_to_data(Kyori)
            injector.append_to_col_init("track_code")
            injector.append_to_data(TrackCD)
            injector.append_to_col_init("course_kubun")
            injector.append_to_data(CourseKubunCD)
            injector.append_to_col_init("handicap_happyoubi")
            injector.append_to_data(HandiDate.Year & HandiDate.Month & HandiDate.Day)
            injector.append_to_col_init("touroku_tousuu")
            injector.append_to_data(TorokuTosu)

            injector.data_end()

            Dim tourokuba_goto_zyouhou_injector = injector.dependent_injectors("jvlink_tourokuba_goto_zyouhou")

            Dim i As Integer
            For i = 0 To 299
                TokuUmaInfo(i).SetDataB(MidB2B(bBuff, 656 + 70 * i, 70))

                tourokuba_goto_zyouhou_injector.append_to_col_init("tokubetsu_tourokuba_id")
                tourokuba_goto_zyouhou_injector.append_to_data(current_record_id, True)

                tourokuba_goto_zyouhou_injector.append_to_col_init("renban")
                tourokuba_goto_zyouhou_injector.append_to_data(TokuUmaInfo(i).Num)
                tourokuba_goto_zyouhou_injector.append_to_col_init("kettou_touroku_bangou")
                tourokuba_goto_zyouhou_injector.append_to_data(TokuUmaInfo(i).KettoNum)
                tourokuba_goto_zyouhou_injector.append_to_col_init("uma_mei")
                tourokuba_goto_zyouhou_injector.append_to_data(TokuUmaInfo(i).Bamei)
                tourokuba_goto_zyouhou_injector.append_to_col_init("uma_kigou_code")
                tourokuba_goto_zyouhou_injector.append_to_data(TokuUmaInfo(i).UmaKigoCD)
                tourokuba_goto_zyouhou_injector.append_to_col_init("seibetsu_code")
                tourokuba_goto_zyouhou_injector.append_to_data(TokuUmaInfo(i).SexCD)
                tourokuba_goto_zyouhou_injector.append_to_col_init("tyoukyoushi_touzai_syozoku_code")
                tourokuba_goto_zyouhou_injector.append_to_data(TokuUmaInfo(i).TozaiCD)
                tourokuba_goto_zyouhou_injector.append_to_col_init("tyoukyoushi_code")
                tourokuba_goto_zyouhou_injector.append_to_data(TokuUmaInfo(i).ChokyosiCode)
                tourokuba_goto_zyouhou_injector.append_to_col_init("tyoukyoushi_mei_ryakusyou")
                tourokuba_goto_zyouhou_injector.append_to_data(TokuUmaInfo(i).ChokyosiRyakusyo)
                tourokuba_goto_zyouhou_injector.append_to_col_init("hutan_zyuuryou")
                tourokuba_goto_zyouhou_injector.append_to_data(TokuUmaInfo(i).Futan)
                tourokuba_goto_zyouhou_injector.append_to_col_init("kouryuu_kubun")
                tourokuba_goto_zyouhou_injector.append_to_data(TokuUmaInfo(i).Koryu)

                tourokuba_goto_zyouhou_injector.data_end()
            Next i

            crlf = MidB2S(bBuff, 21656, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �Q�D���[�X�ڍ� ****************************************
    '<�R�[�i�[�ʉߏ���>
    Public Structure CORNER_INFO
        Public Corner As String     ''�R�[�i�[
        Public Syukaisu As String    ''����
        Public Jyuni As String     ''�e�ʉߏ���
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Corner = MidB2S(bBuff, 1, 1)
            Syukaisu = MidB2S(bBuff, 2, 1)
            Jyuni = MidB2S(bBuff, 3, 70)
        End Sub
    End Structure
    Public Structure JV_RA_RACE
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID     ''<�������ʏ��>
        Public RaceInfo As RACE_INFO   ''<���[�X���>
        Public GradeCD As String    ''�O���[�h�R�[�h
        Public GradeCDBefore As String   ''�ύX�O�O���[�h�R�[�h
        Public JyokenInfo As RACE_JYOKEN  ''<���������R�[�h>
        Public JyokenName As String    ''������������
        Public Kyori As String     ''����
        Public KyoriBefore As String   ''�ύX�O����
        Public TrackCD As String    ''�g���b�N�R�[�h
        Public TrackCDBefore As String   ''�ύX�O�g���b�N�R�[�h
        Public CourseKubunCD As String   ''�R�[�X�敪
        Public CourseKubunCDBefore As String ''�ύX�O�R�[�X�敪
        Public Honsyokin() As String   ''�{�܋�
        Public HonsyokinBefore() As String  ''�ύX�O�{�܋�
        Public Fukasyokin() As String   ''�t���܋�
        Public FukasyokinBefore() As String  ''�ύX�O�t���܋�
        Public HassoTime As String    ''��������
        Public HassoTimeBefore As String  ''�ύX�O��������
        Public TorokuTosu As String    ''�o�^����
        Public SyussoTosu As String    ''�o������
        Public NyusenTosu As String    ''��������
        Public TenkoBaba As TENKO_BABA_INFO  ''�V��E�n���ԃR�[�h
        Public LapTime() As String    ''���b�v�^�C��
        Public SyogaiMileTime As String   ''��Q�}�C���^�C��
        Public HaronTimeS3 As String   ''�O�R�n�����^�C��
        Public HaronTimeS4 As String   ''�O�S�n�����^�C��
        Public HaronTimeL3 As String   ''��R�n�����^�C��
        Public HaronTimeL4 As String   ''��S�n�����^�C��
        Public CornerInfo() As CORNER_INFO  ''<�R�[�i�[�ʉߏ���>
        Public RecordUpKubun As String   ''���R�[�h�X�V�敪
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim Honsyokin(6)
            ReDim HonsyokinBefore(4)
            ReDim Fukasyokin(4)
            ReDim FukasyokinBefore(2)
            ReDim LapTime(24)
            ReDim CornerInfo(3)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim current_record_id As Integer = injector.issue_id()

            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 1272
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            RaceInfo.SetDataB(MidB2B(bBuff, 28, 587))
            GradeCD = MidB2S(bBuff, 615, 1)
            GradeCDBefore = MidB2S(bBuff, 616, 1)
            JyokenInfo.SetDataB(MidB2B(bBuff, 617, 21))
            JyokenName = MidB2S(bBuff, 638, 60)
            Kyori = MidB2S(bBuff, 698, 4)
            KyoriBefore = MidB2S(bBuff, 702, 4)
            TrackCD = MidB2S(bBuff, 706, 2)
            TrackCDBefore = MidB2S(bBuff, 708, 2)
            CourseKubunCD = MidB2S(bBuff, 710, 2)
            CourseKubunCDBefore = MidB2S(bBuff, 712, 2)

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            injector.append_to_col_init("youbi_code")
            injector.append_to_data(RaceInfo.YoubiCD)
            injector.append_to_col_init("tokubetsu_kyousou_bangou")
            injector.append_to_data(RaceInfo.TokuNum)
            Dim kyousoumei = "kyousoumei_"
            injector.append_to_col_init(kyousoumei & "hondai")
            injector.append_to_data(RaceInfo.Hondai)
            injector.append_to_col_init(kyousoumei & "hukudai")
            injector.append_to_data(RaceInfo.Fukudai)
            injector.append_to_col_init(kyousoumei & "kakkonai")
            injector.append_to_data(RaceInfo.Kakko)
            injector.append_to_col_init(kyousoumei & "hondai_ouzi")
            injector.append_to_data(RaceInfo.HondaiEng)
            injector.append_to_col_init(kyousoumei & "hukudai_ouzi")
            injector.append_to_data(RaceInfo.FukudaiEng)
            injector.append_to_col_init(kyousoumei & "kakkonai_ouzi")
            injector.append_to_data(RaceInfo.KakkoEng)
            injector.append_to_col_init(kyousoumei & "ryakusyou_10")
            injector.append_to_data(RaceInfo.Ryakusyo10)
            injector.append_to_col_init(kyousoumei & "ryakusyou_6")
            injector.append_to_data(RaceInfo.Ryakusyo6)
            injector.append_to_col_init(kyousoumei & "ryakusyou_3")
            injector.append_to_data(RaceInfo.Ryakusyo3)
            injector.append_to_col_init(kyousoumei & "kubun")
            injector.append_to_data(RaceInfo.Kubun)
            injector.append_to_col_init("zyuusyou_kaizi")
            injector.append_to_data(RaceInfo.Nkai)

            injector.append_to_col_init("grade_code")
            injector.append_to_data(GradeCD)
            injector.append_to_col_init("henkoumae_grade_code")
            injector.append_to_data(GradeCDBefore)

            injector.append_to_col_init("kyousou_syubetsu_code")
            injector.append_to_data(JyokenInfo.SyubetuCD)
            injector.append_to_col_init("kyousou_kigou_code")
            injector.append_to_data(JyokenInfo.KigoCD)
            injector.append_to_col_init("zyuuryou_syubetsu_code")
            injector.append_to_data(JyokenInfo.JyuryoCD)

            Dim kyousou_zyouken As String = "kyousou_zyouken_code_"
            injector.append_to_col_init(kyousou_zyouken & "2sai")
            injector.append_to_data(JyokenInfo.JyokenCD(0))
            injector.append_to_col_init(kyousou_zyouken & "3sai")
            injector.append_to_data(JyokenInfo.JyokenCD(1))
            injector.append_to_col_init(kyousou_zyouken & "4sai")
            injector.append_to_data(JyokenInfo.JyokenCD(2))
            injector.append_to_col_init(kyousou_zyouken & "5sai_izyou")
            injector.append_to_data(JyokenInfo.JyokenCD(3))
            injector.append_to_col_init(kyousou_zyouken & "saizyakunen")
            injector.append_to_data(JyokenInfo.JyokenCD(4))

            injector.append_to_col_init("kyousou_zyouken_meisyou")
            injector.append_to_data(JyokenName)
            injector.append_to_col_init("kyori")
            injector.append_to_data(Kyori)
            injector.append_to_col_init("henkoumae_kyori")
            injector.append_to_data(KyoriBefore)
            injector.append_to_col_init("track_code")
            injector.append_to_data(TrackCD)
            injector.append_to_col_init("henkoumae_track_code")
            injector.append_to_data(TrackCDBefore)
            injector.append_to_col_init("course_kubun")
            injector.append_to_data(CourseKubunCD)
            injector.append_to_col_init("henkoumae_course_kubun")
            injector.append_to_data(CourseKubunCDBefore)

            For i = 0 To 6
                Honsyokin(i) = MidB2S(bBuff, 714 + 8 * i, 8)
                injector.append_to_col_init("honsyoukin_" & i + 1)
                injector.append_to_data(Honsyokin(i))
            Next i
            For i = 0 To 4
                HonsyokinBefore(i) = MidB2S(bBuff, 770 + 8 * i, 8)
                injector.append_to_col_init("henkoumae_honsyoukin_" & i + 1)
                injector.append_to_data(HonsyokinBefore(i))
            Next i
            For i = 0 To 4
                Fukasyokin(i) = MidB2S(bBuff, 810 + 8 * i, 8)
                injector.append_to_col_init("huka_syoukin_" & i + 1)
                injector.append_to_data(Fukasyokin(i))
            Next i
            For i = 0 To 2
                FukasyokinBefore(i) = MidB2S(bBuff, 850 + 8 * i, 8)
                injector.append_to_col_init("henkoumae_huka_syoukin_" & i + 1)
                injector.append_to_data(FukasyokinBefore(i))
            Next i

            HassoTime = MidB2S(bBuff, 874, 4)
            HassoTimeBefore = MidB2S(bBuff, 878, 4)
            TorokuTosu = MidB2S(bBuff, 882, 2)
            SyussoTosu = MidB2S(bBuff, 884, 2)
            NyusenTosu = MidB2S(bBuff, 886, 2)
            TenkoBaba.SetDataB(MidB2B(bBuff, 888, 3))
            For i = 0 To 24
                LapTime(i) = MidB2S(bBuff, 891 + 3 * i, 3)
                injector.append_to_col_init("lap_time_" & i + 1)
                injector.append_to_data(LapTime(i))
            Next i
            SyogaiMileTime = MidB2S(bBuff, 966, 4)
            HaronTimeS3 = MidB2S(bBuff, 970, 3)
            HaronTimeS4 = MidB2S(bBuff, 973, 3)
            HaronTimeL3 = MidB2S(bBuff, 976, 3)
            HaronTimeL4 = MidB2S(bBuff, 979, 3)
            RecordUpKubun = MidB2S(bBuff, 1270, 1)

            injector.append_to_col_init("hassou_zikoku")
            injector.append_to_data(HassoTime)
            injector.append_to_col_init("henkoumae_hassou_zikoku")
            injector.append_to_data(HassoTimeBefore)
            injector.append_to_col_init("touroku_tousuu")
            injector.append_to_data(TorokuTosu)
            injector.append_to_col_init("syussou_tousuu")
            injector.append_to_data(SyussoTosu)
            injector.append_to_col_init("nyuusen_tousuu")
            injector.append_to_data(NyusenTosu)
            injector.append_to_col_init("tenkou_code")
            injector.append_to_data(TenkoBaba.TenkoCD)
            injector.append_to_col_init("shiba_baba_zyoutai_code")
            injector.append_to_data(TenkoBaba.SibaBabaCD)
            injector.append_to_col_init("dirt_baba_zyoutai_code")
            injector.append_to_data(TenkoBaba.DirtBabaCD)
            injector.append_to_col_init("syougai_mile_time")
            injector.append_to_data(SyogaiMileTime)
            injector.append_to_col_init("mae_3_furlong")
            injector.append_to_data(HaronTimeS3)
            injector.append_to_col_init("mae_4_furlong")
            injector.append_to_data(HaronTimeS4)
            injector.append_to_col_init("ato_3_furlong")
            injector.append_to_data(HaronTimeL3)
            injector.append_to_col_init("ato_4_furlong")
            injector.append_to_data(HaronTimeL4)
            injector.append_to_col_init("record_koushin_kubun")
            injector.append_to_data(RecordUpKubun)

            injector.data_end()

            Dim corner_tsuuka_zyunni_injector As DBInjector = injector.dependent_injectors("jvlink_corner_tsuuka_zyunni")

            For i = 0 To 3
                CornerInfo(i).SetDataB(MidB2B(bBuff, 982 + 72 * i, 72))
                corner_tsuuka_zyunni_injector.issue_id()

                corner_tsuuka_zyunni_injector.append_to_col_init("race_syousai_id")
                corner_tsuuka_zyunni_injector.append_to_data(current_record_id, True)

                corner_tsuuka_zyunni_injector.append_to_col_init("corner")
                corner_tsuuka_zyunni_injector.append_to_data(CornerInfo(i).Corner)
                corner_tsuuka_zyunni_injector.append_to_col_init("syuukaisuu")
                corner_tsuuka_zyunni_injector.append_to_data(CornerInfo(i).Syukaisu)
                corner_tsuuka_zyunni_injector.append_to_col_init("kaku_tsuuka_zyunni")
                corner_tsuuka_zyunni_injector.append_to_data(CornerInfo(i).Jyuni)

                corner_tsuuka_zyunni_injector.data_end()
            Next i

            crlf = MidB2S(bBuff, 1271, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �R�D�n�����[�X��� ****************************************
    '<1���n(����n)���>
    Public Structure CHAKUUMA_INFO
        Public KettoNum As String    ''�����o�^�ԍ�
        Public Bamei As String     ''�n��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            KettoNum = MidB2S(bBuff, 1, 10)
            Bamei = MidB2S(bBuff, 11, 36)
        End Sub
    End Structure
    Public Structure JV_SE_RACE_UMA
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID     ''<�������ʏ��>
        Public Wakuban As String       ''�g��
        Public Umaban As String     ''�n��
        Public KettoNum As String    ''�����o�^�ԍ�
        Public Bamei As String     ''�n��
        Public UmaKigoCD As String    ''�n�L���R�[�h
        Public SexCD As String     ''���ʃR�[�h
        Public HinsyuCD As String    ''�i��R�[�h
        Public KeiroCD As String    ''�ѐF�R�[�h
        Public Barei As String     ''�n��
        Public TozaiCD As String    ''���������R�[�h
        Public ChokyosiCode As String   ''�����t�R�[�h
        Public ChokyosiRyakusyo As String  ''�����t������
        Public BanusiCode As String    ''�n��R�[�h
        Public BanusiName As String    ''�n�喼
        Public Fukusyoku As String    ''���F�W��
        Public reserved1 As String    ''�\��
        Public Futan As String     ''���S�d��
        Public FutanBefore As String   ''�ύX�O���S�d��
        Public Blinker As String    ''�u�����J�[�g�p�敪
        Public reserved2 As String    ''�\��
        Public KisyuCode As String    ''�R��R�[�h
        Public KisyuCodeBefore As String  ''�ύX�O�R��R�[�h
        Public KisyuRyakusyo As String   ''�R�薼����
        Public KisyuRyakusyoBefore As String ''�ύX�O�R�薼����
        Public MinaraiCD As String    ''�R�茩�K�R�[�h
        Public MinaraiCDBefore As String  ''�ύX�O�R�茩�K�R�[�h
        Public BaTaijyu As String    ''�n�̏d
        Public ZogenFugo As String    ''��������
        Public ZogenSa As String    ''������
        Public IJyoCD As String     ''�ُ�敪�R�[�h
        Public NyusenJyuni As String   ''��������
        Public KakuteiJyuni As String   ''�m�蒅��
        Public DochakuKubun As String   ''�����敪
        Public DochakuTosu As String   ''��������
        Public Time As String     ''���j�^�C��
        Public ChakusaCD As String    ''�����R�[�h
        Public ChakusaCDP As String    ''+�����R�[�h
        Public ChakusaCDPP As String   ''++�����R�[�h
        Public Jyuni1c As String    ''1�R�[�i�[�ł̏���
        Public Jyuni2c As String    ''2�R�[�i�[�ł̏���
        Public Jyuni3c As String    ''3�R�[�i�[�ł̏���
        Public Jyuni4c As String    ''4�R�[�i�[�ł̏���
        Public Odds As String     ''�P���I�b�Y
        Public Ninki As String     ''�P���l�C��
        Public Honsyokin As String    ''�l���{�܋�
        Public Fukasyokin As String    ''�l���t���܋�
        Public reserved3 As String    ''�\��
        Public reserved4 As String    ''�\��
        Public HaronTimeL4 As String   ''��S�n�����^�C��
        Public HaronTimeL3 As String   ''��R�n�����^�C��
        Public ChakuUmaInfo() As CHAKUUMA_INFO ''<1���n(����n)���>
        Public TimeDiff As String    ''�^�C����
        Public RecordUpKubun As String   ''���R�[�h�X�V�敪
        Public DMKubun As String    ''�}�C�j���O�敪
        Public DMTime As String     ''�}�C�j���O�\�z���j�^�C��
        Public DMGosaP As String    ''�\���덷(�M���x)�{
        Public DMGosaM As String    ''�\���덷(�M���x)�|
        Public DMJyuni As String    ''�}�C�j���O�\�z����
        Public KyakusituKubun As String   ''���񃌁[�X�r������
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim ChakuUmaInfo(2)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 555
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            Wakuban = MidB2S(bBuff, 28, 1)
            Umaban = MidB2S(bBuff, 29, 2)
            KettoNum = MidB2S(bBuff, 31, 10)
            Bamei = MidB2S(bBuff, 41, 36)
            UmaKigoCD = MidB2S(bBuff, 77, 2)
            SexCD = MidB2S(bBuff, 79, 1)
            HinsyuCD = MidB2S(bBuff, 80, 1)
            KeiroCD = MidB2S(bBuff, 81, 2)
            Barei = MidB2S(bBuff, 83, 2)
            TozaiCD = MidB2S(bBuff, 85, 1)
            ChokyosiCode = MidB2S(bBuff, 86, 5)
            ChokyosiRyakusyo = MidB2S(bBuff, 91, 8)
            BanusiCode = MidB2S(bBuff, 99, 6)
            BanusiName = MidB2S(bBuff, 105, 64)
            Fukusyoku = MidB2S(bBuff, 169, 60)
            reserved1 = MidB2S(bBuff, 229, 60)
            Futan = MidB2S(bBuff, 289, 3)
            FutanBefore = MidB2S(bBuff, 292, 3)
            Blinker = MidB2S(bBuff, 295, 1)
            reserved2 = MidB2S(bBuff, 296, 1)
            KisyuCode = MidB2S(bBuff, 297, 5)
            KisyuCodeBefore = MidB2S(bBuff, 302, 5)
            KisyuRyakusyo = MidB2S(bBuff, 307, 8)
            KisyuRyakusyoBefore = MidB2S(bBuff, 315, 8)
            MinaraiCD = MidB2S(bBuff, 323, 1)
            MinaraiCDBefore = MidB2S(bBuff, 324, 1)
            BaTaijyu = MidB2S(bBuff, 325, 3)
            ZogenFugo = MidB2S(bBuff, 328, 1)
            ZogenSa = MidB2S(bBuff, 329, 3)
            IJyoCD = MidB2S(bBuff, 332, 1)
            NyusenJyuni = MidB2S(bBuff, 333, 2)
            KakuteiJyuni = MidB2S(bBuff, 335, 2)
            DochakuKubun = MidB2S(bBuff, 337, 1)
            DochakuTosu = MidB2S(bBuff, 338, 1)
            Time = MidB2S(bBuff, 339, 4)
            ChakusaCD = MidB2S(bBuff, 343, 3)
            ChakusaCDP = MidB2S(bBuff, 346, 3)
            ChakusaCDPP = MidB2S(bBuff, 349, 3)
            Jyuni1c = MidB2S(bBuff, 352, 2)
            Jyuni2c = MidB2S(bBuff, 354, 2)
            Jyuni3c = MidB2S(bBuff, 356, 2)
            Jyuni4c = MidB2S(bBuff, 358, 2)
            Odds = MidB2S(bBuff, 360, 4)
            Ninki = MidB2S(bBuff, 364, 2)
            Honsyokin = MidB2S(bBuff, 366, 8)
            Fukasyokin = MidB2S(bBuff, 374, 8)
            reserved3 = MidB2S(bBuff, 382, 3)
            reserved4 = MidB2S(bBuff, 385, 3)
            HaronTimeL4 = MidB2S(bBuff, 388, 3)
            HaronTimeL3 = MidB2S(bBuff, 391, 3)
            For i = 0 To 2
                ChakuUmaInfo(i).SetDataB(MidB2B(bBuff, 394 + 46 * i, 46))
            Next i
            TimeDiff = MidB2S(bBuff, 532, 4)
            RecordUpKubun = MidB2S(bBuff, 536, 1)
            DMKubun = MidB2S(bBuff, 537, 1)
            DMTime = MidB2S(bBuff, 538, 5)
            DMGosaP = MidB2S(bBuff, 543, 4)
            DMGosaM = MidB2S(bBuff, 547, 4)
            DMJyuni = MidB2S(bBuff, 551, 2)
            KyakusituKubun = MidB2S(bBuff, 553, 1)
            crlf = MidB2S(bBuff, 554, 2)
            bBuff = Nothing

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            injector.append_to_col_init("waku_ban")
            injector.append_to_data(Wakuban)
            injector.append_to_col_init("uma_ban")
            injector.append_to_data(Umaban)
            injector.append_to_col_init("kettou_touroku_bangou")
            injector.append_to_data(KettoNum)
            injector.append_to_col_init("uma_mei")
            injector.append_to_data(Bamei)
            injector.append_to_col_init("uma_kigou_code")
            injector.append_to_data(UmaKigoCD)
            injector.append_to_col_init("seibetsu_code")
            injector.append_to_data(SexCD)
            injector.append_to_col_init("hinsyu_code")
            injector.append_to_data(HinsyuCD)
            injector.append_to_col_init("keiro_code")
            injector.append_to_data(KeiroCD)
            injector.append_to_col_init("barei")
            injector.append_to_data(Barei)
            injector.append_to_col_init("touzai_syozoku_code")
            injector.append_to_data(TozaiCD)
            injector.append_to_col_init("tyoukyoushi_code")
            injector.append_to_data(ChokyosiCode)
            injector.append_to_col_init("tyoukyoushi_mei_ryakusyou")
            injector.append_to_data(ChokyosiRyakusyo)
            injector.append_to_col_init("banushi_code")
            injector.append_to_data(BanusiCode)
            injector.append_to_col_init("banushi_mei_not_houzin")
            injector.append_to_data(BanusiName)
            injector.append_to_col_init("hukuiro_hyouzi")
            injector.append_to_data(Fukusyoku)
            injector.append_to_col_init("yobi_1")
            injector.append_to_data(reserved1)
            injector.append_to_col_init("hutan_zyuuryou")
            injector.append_to_data(Futan)
            injector.append_to_col_init("henkoumae_hutan_zyuuryou")
            injector.append_to_data(FutanBefore)
            injector.append_to_col_init("blinker_shiyou_kubun")
            injector.append_to_data(Blinker)
            injector.append_to_col_init("yobi_2")
            injector.append_to_data(reserved2)
            injector.append_to_col_init("kisyu_code")
            injector.append_to_data(KisyuCode)
            injector.append_to_col_init("henkoumae_kisyu_code")
            injector.append_to_data(KisyuCodeBefore)
            injector.append_to_col_init("bataizyuu")
            injector.append_to_data(BaTaijyu)
            injector.append_to_col_init("zougen_hugou")
            injector.append_to_data(ZogenFugo)
            injector.append_to_col_init("zougen_sa")
            injector.append_to_data(ZogenSa)
            injector.append_to_col_init("izyoukubun_code")
            injector.append_to_data(IJyoCD)
            injector.append_to_col_init("nyuusen_zyunni")
            injector.append_to_data(NyusenJyuni)
            injector.append_to_col_init("kakutei_chakuzyun")
            injector.append_to_data(KakuteiJyuni)
            injector.append_to_col_init("douchaku_kubun")
            injector.append_to_data(DochakuKubun)
            injector.append_to_col_init("douchaku_tousuu")
            injector.append_to_data(DochakuTosu)
            injector.append_to_col_init("souha_time")
            injector.append_to_data(Time)
            injector.append_to_col_init("chakusa_code")
            injector.append_to_data(ChakusaCD)
            injector.append_to_col_init("plus_chakusa_code")
            injector.append_to_data(ChakusaCDP)
            injector.append_to_col_init("plus_plus_chakusa_code")
            injector.append_to_data(ChakusaCDPP)
            injector.append_to_col_init("zyunni_corner_1")
            injector.append_to_data(Jyuni1c)
            injector.append_to_col_init("zyunni_corner_2")
            injector.append_to_data(Jyuni2c)
            injector.append_to_col_init("zyunni_corner_3")
            injector.append_to_data(Jyuni3c)
            injector.append_to_col_init("zyunni_corner_4")
            injector.append_to_data(Jyuni4c)
            injector.append_to_col_init("tansyou_odds")
            injector.append_to_data(Odds)
            injector.append_to_col_init("tansyou_ninkizyun")
            injector.append_to_data(Ninki)
            injector.append_to_col_init("kakutoku_honsyoukin")
            injector.append_to_data(Honsyokin)
            injector.append_to_col_init("kakutoku_huka_syoukin")
            injector.append_to_data(Fukasyokin)
            injector.append_to_col_init("yobi_3")
            injector.append_to_data(reserved3)
            injector.append_to_col_init("yobi_4")
            injector.append_to_data(reserved4)
            injector.append_to_col_init("ato_4_furlong_time")
            injector.append_to_data(HaronTimeL4)
            injector.append_to_col_init("ato_3_furlong_time")
            injector.append_to_data(HaronTimeL3)

            For i = 0 To 2
                injector.append_to_col_init("aiteuma_kettou_touroku_bangou_for_" & i + 1)
                injector.append_to_data(ChakuUmaInfo(i).KettoNum)
                injector.append_to_col_init("aiteuma_uma_mei_for_" & i + 1)
                injector.append_to_data(ChakuUmaInfo(i).Bamei)
            Next

            injector.append_to_col_init("time_sa")
            injector.append_to_data(TimeDiff)
            injector.append_to_col_init("record_koushin_kubun")
            injector.append_to_data(RecordUpKubun)
            injector.append_to_col_init("mining_kubun")
            injector.append_to_data(DMKubun)
            injector.append_to_col_init("mining_yosou_souha_time")
            injector.append_to_data(DMTime)
            injector.append_to_col_init("mining_yosougosa_plus")
            injector.append_to_data(DMGosaP)
            injector.append_to_col_init("mining_yosougosa_minus")
            injector.append_to_data(DMGosaM)
            injector.append_to_col_init("mining_yosou_zyunni")
            injector.append_to_data(DMJyuni)
            injector.append_to_col_init("kyakushitsu_hantei")
            injector.append_to_data(KyakusituKubun)

            injector.data_end()
        End Sub
    End Structure

    '****** �S�D���� ****************************************

    ''<���ߏ��P �P�E���E�g>
    Public Structure PAY_INFO1
        Public Umaban As String     ''�n��
        Public Pay As String     ''���ߋ�
        Public Ninki As String     ''�l�C��	
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Umaban = MidB2S(bBuff, 1, 2)
            Pay = MidB2S(bBuff, 3, 9)
            Ninki = MidB2S(bBuff, 12, 2)
        End Sub
    End Structure

    ''<���ߏ��Q �n�A�E���C�h�E�\���E�n�P>
    Public Structure PAY_INFO2
        Public Kumi As String     ''�g��
        Public Pay As String     ''���ߋ�
        Public Ninki As String     ''�l�C��	
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumi = MidB2S(bBuff, 1, 4)
            Pay = MidB2S(bBuff, 5, 9)
            Ninki = MidB2S(bBuff, 14, 3)
        End Sub
    End Structure

    ''<���ߏ��R �R�A��>
    Public Structure PAY_INFO3
        Public Kumi As String     ''�g��
        Public Pay As String     ''���ߋ�
        Public Ninki As String     ''�l�C��	
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumi = MidB2S(bBuff, 1, 6)
            Pay = MidB2S(bBuff, 7, 9)
            Ninki = MidB2S(bBuff, 16, 3)
        End Sub
    End Structure

    ''<���ߏ��S �R�A�P>
    Public Structure PAY_INFO4
        Public Kumi As String     ''�g��
        Public Pay As String     ''���ߋ�
        Public Ninki As String     ''�l�C��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumi = MidB2S(bBuff, 1, 6)
            Pay = MidB2S(bBuff, 7, 9)
            Ninki = MidB2S(bBuff, 16, 4)
        End Sub
    End Structure

    Public Structure JV_HR_PAY
        Public head As RECORD_ID            ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID                ''<�������ʏ��>
        Public TorokuTosu As String         ''�o�^����
        Public SyussoTosu As String         ''�o������
        Public FuseirituFlag() As String    ''�s�����t���O
        Public TokubaraiFlag() As String    ''�����t���O
        Public HenkanFlag() As String       ''�Ԋ҃t���O
        Public HenkanUma() As String        ''�ԊҔn�ԏ��(�n��01�`28)
        Public HenkanWaku() As String       ''�ԊҘg�ԏ��(�g��1�`8)
        Public HenkanDoWaku() As String     ''�Ԋғ��g���(�g��1�`8)
        Public PayTansyo() As PAY_INFO1     ''<�P������>
        Public PayFukusyo() As PAY_INFO1    ''<��������>
        Public PayWakuren() As PAY_INFO1    ''<�g�A����>
        Public PayUmaren() As PAY_INFO2     ''<�n�A����>
        Public PayWide() As PAY_INFO2       ''<���C�h����>
        Public PayReserved1() As PAY_INFO2  ''<�\��>
        Public PayUmatan() As PAY_INFO2     ''<�n�P����>
        Public PaySanrenpuku() As PAY_INFO3 ''<3�A������>
        Public PaySanrentan() As PAY_INFO4  ''<3�A�P����>
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim FuseirituFlag(8)
            ReDim TokubaraiFlag(8)
            ReDim HenkanFlag(8)
            ReDim HenkanUma(27)
            ReDim HenkanWaku(7)
            ReDim HenkanDoWaku(7)
            ReDim PayTansyo(2)
            ReDim PayFukusyo(4)
            ReDim PayWakuren(2)
            ReDim PayUmaren(2)
            ReDim PayWide(6)
            ReDim PayReserved1(2)
            ReDim PayUmatan(5)
            ReDim PaySanrenpuku(2)
            ReDim PaySanrentan(5)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 719
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            TorokuTosu = MidB2S(bBuff, 28, 2)
            SyussoTosu = MidB2S(bBuff, 30, 2)

            For i = 0 To 8
                FuseirituFlag(i) = MidB2S(bBuff, 32 + (1 * i), 1)
            Next i
            For i = 0 To 8
                TokubaraiFlag(i) = MidB2S(bBuff, 41 + (1 * i), 1)
            Next i
            For i = 0 To 8
                HenkanFlag(i) = MidB2S(bBuff, 50 + (1 * i), 1)
            Next i

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            injector.append_to_col_init("touroku_tousuu")
            injector.append_to_data(TorokuTosu)
            injector.append_to_col_init("syussou_tousuu")
            injector.append_to_data(SyussoTosu)

            Dim huseiritsu As String = "huseiritsu_flag_"
            Dim tokubarai As String = "tokubarai_flag_"
            Dim henkan As String = "henkan_flag_"

            injector.append_to_col_init(huseiritsu & "tansyou")
            injector.append_to_data(FuseirituFlag(0))
            injector.append_to_col_init(huseiritsu & "hukusyou")
            injector.append_to_data(FuseirituFlag(1))
            injector.append_to_col_init(huseiritsu & "waku_ren")
            injector.append_to_data(FuseirituFlag(2))
            injector.append_to_col_init(huseiritsu & "uma_ren")
            injector.append_to_data(FuseirituFlag(3))
            injector.append_to_col_init(huseiritsu & "wide")
            injector.append_to_data(FuseirituFlag(4))
            injector.append_to_col_init("yobi_1")
            injector.append_to_data(FuseirituFlag(5))
            injector.append_to_col_init(huseiritsu & "uma_tan")
            injector.append_to_data(FuseirituFlag(6))
            injector.append_to_col_init(huseiritsu & "3renpuku")
            injector.append_to_data(FuseirituFlag(7))
            injector.append_to_col_init(huseiritsu & "3rentan")
            injector.append_to_data(FuseirituFlag(8))

            injector.append_to_col_init(tokubarai & "tansyou")
            injector.append_to_data(TokubaraiFlag(0))
            injector.append_to_col_init(tokubarai & "hukusyou")
            injector.append_to_data(TokubaraiFlag(1))
            injector.append_to_col_init(tokubarai & "waku_ren")
            injector.append_to_data(TokubaraiFlag(2))
            injector.append_to_col_init(tokubarai & "uma_ren")
            injector.append_to_data(TokubaraiFlag(3))
            injector.append_to_col_init(tokubarai & "wide")
            injector.append_to_data(TokubaraiFlag(4))
            injector.append_to_col_init("yobi_2")
            injector.append_to_data(TokubaraiFlag(5))
            injector.append_to_col_init(tokubarai & "uma_tan")
            injector.append_to_data(TokubaraiFlag(6))
            injector.append_to_col_init(tokubarai & "3renpuku")
            injector.append_to_data(TokubaraiFlag(7))
            injector.append_to_col_init(tokubarai & "3rentan")
            injector.append_to_data(TokubaraiFlag(8))

            injector.append_to_col_init(henkan & "tansyou")
            injector.append_to_data(HenkanFlag(0))
            injector.append_to_col_init(henkan & "hukusyou")
            injector.append_to_data(HenkanFlag(1))
            injector.append_to_col_init(henkan & "waku_ren")
            injector.append_to_data(HenkanFlag(2))
            injector.append_to_col_init(henkan & "uma_ren")
            injector.append_to_data(HenkanFlag(3))
            injector.append_to_col_init(henkan & "wide")
            injector.append_to_data(HenkanFlag(4))
            injector.append_to_col_init("yobi_3")
            injector.append_to_data(HenkanFlag(5))
            injector.append_to_col_init(henkan & "uma_tan")
            injector.append_to_data(HenkanFlag(6))
            injector.append_to_col_init(henkan & "3renpuku")
            injector.append_to_data(HenkanFlag(7))
            injector.append_to_col_init(henkan & "3rentan")
            injector.append_to_data(HenkanFlag(8))

            For i = 0 To 27
                HenkanUma(i) = MidB2S(bBuff, 59 + (1 * i), 1)
                injector.append_to_col_init("henkan_uma_ban_zyouhou_" & i + 1)
                injector.append_to_data(HenkanUma(i))
            Next i
            For i = 0 To 7
                HenkanWaku(i) = MidB2S(bBuff, 87 + (1 * i), 1)
                injector.append_to_col_init("henkan_waku_ban_zyouhou_" & i + 1)
                injector.append_to_data(HenkanWaku(i))
            Next i
            For i = 0 To 7
                HenkanDoWaku(i) = MidB2S(bBuff, 95 + (1 * i), 1)
                injector.append_to_col_init("henkan_douwaku_zyouhou_" & i + 1)
                injector.append_to_data(HenkanDoWaku(i))
            Next i
            For i = 0 To 2
                PayTansyo(i).SetDataB(MidB2B(bBuff, 103 + (13 * i), 13))
                injector.append_to_col_init("uma_ban_tansyou_" & i + 1)
                injector.append_to_data(PayTansyo(i).Umaban)
                injector.append_to_col_init("haraimodoshikin_tansyou_" & i + 1)
                injector.append_to_data(PayTansyo(i).Pay)
                injector.append_to_col_init("ninkizyun_tansyou_" & i + 1)
                injector.append_to_data(PayTansyo(i).Ninki)
            Next i
            For i = 0 To 4
                PayFukusyo(i).SetDataB(MidB2B(bBuff, 142 + (13 * i), 13))
                injector.append_to_col_init("uma_ban_hukusyou_" & i + 1)
                injector.append_to_data(PayFukusyo(i).Umaban)
                injector.append_to_col_init("haraimodoshikin_hukusyou_" & i + 1)
                injector.append_to_data(PayFukusyo(i).Pay)
                injector.append_to_col_init("ninkizyun_hukusyou_" & i + 1)
                injector.append_to_data(PayFukusyo(i).Ninki)
            Next i
            For i = 0 To 2
                PayWakuren(i).SetDataB(MidB2B(bBuff, 207 + (13 * i), 13))
                injector.append_to_col_init("kumi_ban_waku_ren_" & i + 1)
                injector.append_to_data(PayWakuren(i).Umaban)
                injector.append_to_col_init("haraimodoshikin_waku_ren_" & i + 1)
                injector.append_to_data(PayWakuren(i).Pay)
                injector.append_to_col_init("ninkizyun_waku_ren_" & i + 1)
                injector.append_to_data(PayWakuren(i).Ninki)
            Next i
            For i = 0 To 2
                PayUmaren(i).SetDataB(MidB2B(bBuff, 246 + (16 * i), 16))
                injector.append_to_col_init("kumi_ban_uma_ren_" & i + 1)
                injector.append_to_data(PayUmaren(i).Kumi)
                injector.append_to_col_init("haraimodoshikin_uma_ren_" & i + 1)
                injector.append_to_data(PayUmaren(i).Pay)
                injector.append_to_col_init("ninkizyun_uma_ren_" & i + 1)
                injector.append_to_data(PayUmaren(i).Ninki)
            Next i
            For i = 0 To 6
                PayWide(i).SetDataB(MidB2B(bBuff, 294 + (16 * i), 16))
                injector.append_to_col_init("kumi_ban_wide_" & i + 1)
                injector.append_to_data(PayWide(i).Kumi)
                injector.append_to_col_init("haraimodoshikin_wide_" & i + 1)
                injector.append_to_data(PayWide(i).Pay)
                injector.append_to_col_init("ninkizyun_wide_" & i + 1)
                injector.append_to_data(PayWide(i).Ninki)
            Next i
            For i = 0 To 2
                PayReserved1(i).SetDataB(MidB2B(bBuff, 406 + (16 * i), 16))
                injector.append_to_col_init("ban_yobi_" & i + 1)
                injector.append_to_data(PayReserved1(i).Kumi)
                injector.append_to_col_init("haraimodoshikin_yobi_" & i + 1)
                injector.append_to_data(PayReserved1(i).Pay)
                injector.append_to_col_init("ninkizyun_yobi_" & i + 1)
                injector.append_to_data(PayReserved1(i).Ninki)
            Next i
            For i = 0 To 5
                PayUmatan(i).SetDataB(MidB2B(bBuff, 454 + (16 * i), 16))
                injector.append_to_col_init("kumi_ban_uma_tan_" & i + 1)
                injector.append_to_data(PayUmatan(i).Kumi)
                injector.append_to_col_init("haraimodoshikin_uma_tan_" & i + 1)
                injector.append_to_data(PayUmatan(i).Pay)
                injector.append_to_col_init("ninkizyun_uma_tan_" & i + 1)
                injector.append_to_data(PayUmatan(i).Ninki)
            Next i
            For i = 0 To 2
                PaySanrenpuku(i).SetDataB(MidB2B(bBuff, 550 + (18 * i), 18))
                injector.append_to_col_init("kumi_ban_3renpuku_" & i + 1)
                injector.append_to_data(PaySanrenpuku(i).Kumi)
                injector.append_to_col_init("haraimodoshikin_3renpuku_" & i + 1)
                injector.append_to_data(PaySanrenpuku(i).Pay)
                injector.append_to_col_init("ninkizyun_3renpuku_" & i + 1)
                injector.append_to_data(PaySanrenpuku(i).Ninki)
            Next i
            For i = 0 To 5
                PaySanrentan(i).SetDataB(MidB2B(bBuff, 604 + (19 * i), 19))
                injector.append_to_col_init("kumi_ban_3rentan_" & i + 1)
                injector.append_to_data(PaySanrentan(i).Kumi)
                injector.append_to_col_init("haraimodoshikin_3rentan_" & i + 1)
                injector.append_to_data(PaySanrentan(i).Pay)
                injector.append_to_col_init("ninkizyun_3rentan_" & i + 1)
                injector.append_to_data(PaySanrentan(i).Ninki)
            Next i
            crlf = MidB2S(bBuff, 718, 2)
            bBuff = Nothing

            injector.data_end()

        End Sub
    End Structure

    '****** �T�D�[���i�S�|���j****************************************
    '<�[�����P �P�E���E�g>
    Public Structure HYO_INFO1
        Public Umaban As String     ''�n��		
        Public Hyo As String     ''�[��
        Public Ninki As String     ''�l�C
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Umaban = MidB2S(bBuff, 1, 2)
            Hyo = MidB2S(bBuff, 3, 11)
            Ninki = MidB2S(bBuff, 14, 2)
        End Sub
    End Structure
    '<�[�����Q �n�A�E���C�h�E�n�P>
    Public Structure HYO_INFO2
        Public Kumi As String     ''�g��		
        Public Hyo As String     ''�[��
        Public Ninki As String     ''�l�C
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumi = MidB2S(bBuff, 1, 4)
            Hyo = MidB2S(bBuff, 5, 11)
            Ninki = MidB2S(bBuff, 16, 3)
        End Sub
    End Structure
    '<�[�����R �R�A���[��>
    Public Structure HYO_INFO3
        Public Kumi As String     ''�g��		
        Public Hyo As String     ''�[��
        Public Ninki As String     ''�l�C
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumi = MidB2S(bBuff, 1, 6)
            Hyo = MidB2S(bBuff, 7, 11)
            Ninki = MidB2S(bBuff, 18, 3)
        End Sub
    End Structure
    '<�[�����S �R�A�P�[��>
    Public Structure HYO_INFO4
        Public Kumi As String     ''�g��		
        Public Hyo As String     ''�[��
        Public Ninki As String     ''�l�C
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumi = MidB2S(bBuff, 1, 6)
            Hyo = MidB2S(bBuff, 7, 11)
            Ninki = MidB2S(bBuff, 18, 4)
        End Sub
    End Structure

    Public Structure JV_H1_HYOSU_ZENKAKE
        Public head As RECORD_ID            ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID                ''<�������ʏ��>
        Public TorokuTosu As String         ''�o�^����
        Public SyussoTosu As String         ''�o������
        Public HatubaiFlag() As String      ''�����t���O�@
        Public FukuChakuBaraiKey As String  ''���������L�[
        Public HenkanUma() As String        ''�ԊҔn�ԏ��(�n��01�`28)
        Public HenkanWaku() As String       ''�ԊҘg�ԏ��(�g��1�`8)
        Public HenkanDoWaku() As String     ''�Ԋғ��g���(�g��1�`8)
        Public HyoTansyo() As HYO_INFO1     ''<�P���[��>
        Public HyoFukusyo() As HYO_INFO1    ''<�����[��>
        Public HyoWakuren() As HYO_INFO1    ''<�g�A�[��>
        Public HyoUmaren() As HYO_INFO2     ''<�n�A�[��>
        Public HyoWide() As HYO_INFO2       ''<���C�h�[��>
        Public HyoUmatan() As HYO_INFO2     ''<�n�P�[��>
        Public HyoSanrenpuku() As HYO_INFO3 ''<3�A���[��>
        Public HyoTotal() As String         ''�[�����v
        Public crlf As String               ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim HatubaiFlag(6)
            ReDim HenkanUma(27)
            ReDim HenkanWaku(7)
            ReDim HenkanDoWaku(7)
            ReDim HyoTansyo(27)
            ReDim HyoFukusyo(27)
            ReDim HyoWakuren(35)
            ReDim HyoUmaren(152)
            ReDim HyoWide(152)
            ReDim HyoUmatan(305)
            ReDim HyoSanrenpuku(815)
            ReDim HyoTotal(13)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 28955
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            TorokuTosu = MidB2S(bBuff, 28, 2)
            SyussoTosu = MidB2S(bBuff, 30, 2)

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            injector.append_to_col_init("touroku_tousuu")
            injector.append_to_data(TorokuTosu)
            injector.append_to_col_init("syussou_tousuu")
            injector.append_to_data(SyussoTosu)

            For i = 0 To 6
                HatubaiFlag(i) = MidB2S(bBuff, 32 + (1 * i), 1)
            Next i

            Dim collection_order_types As IEnumerable(Of String) = New List(Of String) _
                From {
                "tansyou",
                "hukusyou",
                "waku_ren",
                "uma_ren",
                "wide",
                "uma_tan",
                "3renpuku"
            }

            For i = 0 To 13
                HyoTotal(i) = MidB2S(bBuff, 28800 + (11 * i), 11)
            Next i

            For Each item In collection_order_types.Select(Function(order, index) New With {order, index})
                injector.append_to_col_init("hyousuu_goukei_" & item.order)
                injector.append_to_data(HyoTotal(item.index))
            Next

            For Each item In collection_order_types.Select(Function(order, index) New With {order, index})
                injector.append_to_col_init("henkan_hyousuu_goukei_" & item.order)
                injector.append_to_data(HyoTotal(item.index + 7))
            Next

            For Each item In collection_order_types.Select(Function(order, index) New With {order, index})
                injector.append_to_col_init("hatsubai_flag_" & item.order)
                injector.append_to_data(HatubaiFlag(item.index))
            Next

            FukuChakuBaraiKey = MidB2S(bBuff, 39, 1)
            injector.append_to_col_init("hukusyou_chakubarai_key")
            injector.append_to_data(FukuChakuBaraiKey)

            For i = 0 To 27
                HenkanUma(i) = MidB2S(bBuff, 40 + (1 * i), 1)
                injector.append_to_col_init("henkan_zyouhou_uma_ban_" & i + 1)
                injector.append_to_data(HenkanUma(i))
            Next i
            For i = 0 To 7
                HenkanWaku(i) = MidB2S(bBuff, 68 + (1 * i), 1)
                injector.append_to_col_init("henkan_zyouhou_waku_ban_" & i + 1)
                injector.append_to_data(HenkanWaku(i))
            Next i
            For i = 0 To 7
                HenkanDoWaku(i) = MidB2S(bBuff, 76 + (1 * i), 1)
                injector.append_to_col_init("henkan_zyouhou_douwaku_" & i + 1)
                injector.append_to_data(HenkanDoWaku(i))
            Next i

            injector.data_end()

            Dim tansyou As DBInjector = injector.dependent_injectors("jvlink_hyousuu_1_tansyou")
            Dim hukusyou As DBInjector = injector.dependent_injectors("jvlink_hyousuu_1_hukusyou")
            Dim waku_ren As DBInjector = injector.dependent_injectors("jvlink_hyousuu_1_waku_ren")
            Dim uma_ren As DBInjector = injector.dependent_injectors("jvlink_hyousuu_1_uma_ren")
            Dim wide As DBInjector = injector.dependent_injectors("jvlink_hyousuu_1_wide")
            Dim uma_tan As DBInjector = injector.dependent_injectors("jvlink_hyousuu_1_uma_tan")
            Dim sanrenpuku As DBInjector = injector.dependent_injectors("jvlink_hyousuu_1_3renpuku")

            For i = 0 To 27
                HyoTansyo(i).SetDataB(MidB2B(bBuff, 84 + (15 * i), 15))
                tansyou.issue_id()

                tansyou.append_to_col_init("hyousuu_1_id")
                tansyou.append_to_data(current_record_id, True)

                tansyou.append_to_col_init("uma_ban")
                tansyou.append_to_data(HyoTansyo(i).Umaban)
                tansyou.append_to_col_init("hyousuu")
                tansyou.append_to_data(HyoTansyo(i).Hyo)
                tansyou.append_to_col_init("ninkizyun")
                tansyou.append_to_data(HyoTansyo(i).Ninki)

                tansyou.data_end()
            Next i

            For i = 0 To 27
                HyoFukusyo(i).SetDataB(MidB2B(bBuff, 504 + (15 * i), 15))
                hukusyou.issue_id()

                hukusyou.append_to_col_init("hyousuu_1_id")
                hukusyou.append_to_data(current_record_id, True)

                hukusyou.append_to_col_init("uma_ban")
                hukusyou.append_to_data(HyoFukusyo(i).Umaban)
                hukusyou.append_to_col_init("hyousuu")
                hukusyou.append_to_data(HyoFukusyo(i).Hyo)
                hukusyou.append_to_col_init("ninkizyun")
                hukusyou.append_to_data(HyoFukusyo(i).Ninki)

                hukusyou.data_end()
            Next i
            For i = 0 To 35
                HyoWakuren(i).SetDataB(MidB2B(bBuff, 924 + (15 * i), 15))
                waku_ren.issue_id()

                waku_ren.append_to_col_init("hyousuu_1_id")
                waku_ren.append_to_data(current_record_id, True)

                waku_ren.append_to_col_init("kumi_ban")
                waku_ren.append_to_data(HyoWakuren(i).Umaban)
                waku_ren.append_to_col_init("hyousuu")
                waku_ren.append_to_data(HyoWakuren(i).Hyo)
                waku_ren.append_to_col_init("ninkizyun")
                waku_ren.append_to_data(HyoWakuren(i).Ninki)

                waku_ren.data_end()
            Next i
            For i = 0 To 152
                HyoUmaren(i).SetDataB(MidB2B(bBuff, 1464 + (18 * i), 18))
                uma_ren.issue_id()

                uma_ren.append_to_col_init("hyousuu_1_id")
                uma_ren.append_to_data(current_record_id, True)

                uma_ren.append_to_col_init("kumi_ban")
                uma_ren.append_to_data(HyoUmaren(i).Kumi)
                uma_ren.append_to_col_init("hyousuu")
                uma_ren.append_to_data(HyoUmaren(i).Hyo)
                uma_ren.append_to_col_init("ninkizyun")
                uma_ren.append_to_data(HyoUmaren(i).Ninki)

                uma_ren.data_end()

            Next i
            For i = 0 To 152
                HyoWide(i).SetDataB(MidB2B(bBuff, 4218 + (18 * i), 18))
                wide.issue_id()

                wide.append_to_col_init("hyousuu_1_id")
                wide.append_to_data(current_record_id, True)

                wide.append_to_col_init("kumi_ban")
                wide.append_to_data(HyoWide(i).Kumi)
                wide.append_to_col_init("hyousuu")
                wide.append_to_data(HyoWide(i).Hyo)
                wide.append_to_col_init("ninkizyun")
                wide.append_to_data(HyoWide(i).Ninki)

                wide.data_end()
            Next i
            For i = 0 To 305
                HyoUmatan(i).SetDataB(MidB2B(bBuff, 6972 + (18 * i), 18))
                uma_tan.issue_id()

                uma_tan.append_to_col_init("hyousuu_1_id")
                uma_tan.append_to_data(current_record_id, True)

                uma_tan.append_to_col_init("kumi_ban")
                uma_tan.append_to_data(HyoUmatan(i).Kumi)
                uma_tan.append_to_col_init("hyousuu")
                uma_tan.append_to_data(HyoUmatan(i).Hyo)
                uma_tan.append_to_col_init("ninkizyun")
                uma_tan.append_to_data(HyoUmatan(i).Ninki)

                uma_tan.data_end()
            Next i
            For i = 0 To 815
                HyoSanrenpuku(i).SetDataB(MidB2B(bBuff, 12480 + (20 * i), 20))
                sanrenpuku.issue_id()

                sanrenpuku.append_to_col_init("hyousuu_1_id")
                sanrenpuku.append_to_data(current_record_id, True)

                sanrenpuku.append_to_col_init("kumi_ban")
                sanrenpuku.append_to_data(HyoSanrenpuku(i).Kumi)
                sanrenpuku.append_to_col_init("hyousuu")
                sanrenpuku.append_to_data(HyoSanrenpuku(i).Hyo)
                sanrenpuku.append_to_col_init("ninkizyun")
                sanrenpuku.append_to_data(HyoSanrenpuku(i).Ninki)

                sanrenpuku.data_end()
            Next i

            crlf = MidB2S(bBuff, 28954, 2)
            bBuff = Nothing
        End Sub
    End Structure

    Public Structure JV_H6_HYOSU_SANRENTAN
        Public head As RECORD_ID            ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID                ''<�������ʏ��>
        Public TorokuTosu As String         ''�o�^����
        Public SyussoTosu As String         ''�o������
        Public HatubaiFlag As String        ''�����t���O�@
        Public HenkanUma() As String        ''�ԊҔn�ԏ��(�n��01�`18)
        Public HyoSanrentan() As HYO_INFO4 ''<3�A�P�[��>
        Public HyoTotal() As String         ''�[�����v
        Public crlf As String               ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim HenkanUma(17)
            ReDim HyoSanrentan(4895)
            ReDim HyoTotal(1)
        End Sub

        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 102900
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            TorokuTosu = MidB2S(bBuff, 28, 2)
            SyussoTosu = MidB2S(bBuff, 30, 2)
            HatubaiFlag = MidB2S(bBuff, 32, 1)

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            injector.append_to_col_init("touroku_tousuu")
            injector.append_to_data(TorokuTosu)
            injector.append_to_col_init("syussou_tousuu")
            injector.append_to_data(SyussoTosu)

            injector.append_to_col_init("hatsubai_flag_3rentan")
            injector.append_to_data(HatubaiFlag)

            For i = 0 To 17
                HenkanUma(i) = MidB2S(bBuff, 33 + (1 * i), 1)
                injector.append_to_col_init("henkan_uma_ban_zyouhou_" & i + 1)
                injector.append_to_data(HenkanUma(i))
            Next i
            For i = 0 To 1
                HyoTotal(i) = MidB2S(bBuff, 102867 + (11 * i), 11)
            Next i

            injector.append_to_col_init("hyousuu_goukei_3rentan")
            injector.append_to_data(HyoTotal(0))
            injector.append_to_col_init("henkan_hyousuu_goukei_3rentan")
            injector.append_to_data(HyoTotal(1))

            injector.data_end()

            Dim sanrentan As DBInjector = injector.dependent_injectors("jvlink_hyousuu_6_3rentan")

            For i = 0 To 4895
                HyoSanrentan(i).SetDataB(MidB2B(bBuff, 51 + (21 * i), 21))
                sanrentan.issue_id()

                sanrentan.append_to_col_init("hyousuu_6_id")
                sanrentan.append_to_data(current_record_id, True)

                sanrentan.append_to_col_init("kumi_ban")
                sanrentan.append_to_data(HyoSanrentan(i).Kumi)
                sanrentan.append_to_col_init("hyousuu")
                sanrentan.append_to_data(HyoSanrentan(i).Hyo)
                sanrentan.append_to_col_init("ninkizyun")
                sanrentan.append_to_data(HyoSanrentan(i).Ninki)

                sanrentan.data_end()
            Next i

            crlf = MidB2S(bBuff, 102889, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �U�D�I�b�Y�i�P���g�j****************************************
    '<�P���I�b�Y>
    Public Structure ODDS_TANSYO_INFO
        Public Umaban As String     ''�n��
        Public Odds As String     ''�I�b�Y
        Public Ninki As String     ''�l�C��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Umaban = MidB2S(bBuff, 1, 2)
            Odds = MidB2S(bBuff, 3, 4)
            Ninki = MidB2S(bBuff, 7, 2)
        End Sub
    End Structure
    '<�����I�b�Y>
    Public Structure ODDS_FUKUSYO_INFO
        Public Umaban As String     ''�n��
        Public OddsLow As String    ''�Œ�I�b�Y
        Public OddsHigh As String    ''�ō��I�b�Y
        Public Ninki As String     ''�l�C��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Umaban = MidB2S(bBuff, 1, 2)
            OddsLow = MidB2S(bBuff, 3, 4)
            OddsHigh = MidB2S(bBuff, 7, 4)
            Ninki = MidB2S(bBuff, 11, 2)
        End Sub
    End Structure
    '<�g�A�I�b�Y>
    Public Structure ODDS_WAKUREN_INFO
        Public Kumi As String     ''�g
        Public Odds As String     ''�I�b�Y
        Public Ninki As String     ''�l�C��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumi = MidB2S(bBuff, 1, 2)
            Odds = MidB2S(bBuff, 3, 5)
            Ninki = MidB2S(bBuff, 8, 2)
        End Sub
    End Structure
    Public Structure JV_O1_ODDS_TANFUKUWAKU
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID     ''<�������ʏ��>
        Public HappyoTime As MDHM    ''���\��������
        Public TorokuTosu As String    ''�o�^����
        Public SyussoTosu As String    ''�o������
        Public TansyoFlag As String    ''�����t���O�@�P��
        Public FukusyoFlag As String   ''�����t���O�@����
        Public WakurenFlag As String   ''�����t���O�@�g�A
        Public FukuChakuBaraiKey As String  ''���������L�[
        Public OddsTansyoInfo() As ODDS_TANSYO_INFO  ''<�P���I�b�Y>
        Public OddsFukusyoInfo() As ODDS_FUKUSYO_INFO ''<�����[���I�b�Y>
        Public OddsWakurenInfo() As ODDS_WAKUREN_INFO ''<�g�A�[���I�b�Y>
        Public TotalHyosuTansyo As String  ''�P���[�����v
        Public TotalHyosuFukusyo As String  ''�����[�����v
        Public TotalHyosuWakuren As String  ''�g�A�[�����v
        Public crlf As String   ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim OddsTansyoInfo(27)
            ReDim OddsFukusyoInfo(27)
            ReDim OddsWakurenInfo(35)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 962
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            HappyoTime.SetDataB(MidB2B(bBuff, 28, 8))
            TorokuTosu = MidB2S(bBuff, 36, 2)
            SyussoTosu = MidB2S(bBuff, 38, 2)
            TansyoFlag = MidB2S(bBuff, 40, 1)
            FukusyoFlag = MidB2S(bBuff, 41, 1)
            WakurenFlag = MidB2S(bBuff, 42, 1)
            FukuChakuBaraiKey = MidB2S(bBuff, 43, 1)

            TotalHyosuTansyo = MidB2S(bBuff, 928, 11)
            TotalHyosuFukusyo = MidB2S(bBuff, 939, 11)
            TotalHyosuWakuren = MidB2S(bBuff, 950, 11)

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            injector.append_to_col_init("happyoubi_gappi_zihun")
            injector.append_to_data(HappyoTime.Month & HappyoTime.Day &
                          HappyoTime.Hour & HappyoTime.Minute)
            injector.append_to_col_init("touroku_tousuu")
            injector.append_to_data(TorokuTosu)
            injector.append_to_col_init("syussou_tousuu")
            injector.append_to_data(SyussoTosu)
            injector.append_to_col_init("hatsubai_flag_tansyou")
            injector.append_to_data(TansyoFlag)
            injector.append_to_col_init("hatsubai_flag_hukusyou")
            injector.append_to_data(FukusyoFlag)
            injector.append_to_col_init("hatsubai_flag_waku_ren")
            injector.append_to_data(WakurenFlag)
            injector.append_to_col_init("hyousuu_goukei_tansuu")
            injector.append_to_data(TotalHyosuTansyo)
            injector.append_to_col_init("hyousuu_goukei_hukusyou")
            injector.append_to_data(TotalHyosuFukusyo)
            injector.append_to_col_init("hyousuu_goukei_waku_ren")
            injector.append_to_data(TotalHyosuWakuren)

            injector.data_end()

            Dim tansyou As DBInjector = injector.dependent_injectors("jvlink_odds_1_tansyou_odds")
            Dim hukusyou As DBInjector = injector.dependent_injectors("jvlink_odds_1_hukusyou_odds")
            Dim waku_ren As DBInjector = injector.dependent_injectors("jvlink_odds_1_waku_ren_odds")

            For i = 0 To 27
                OddsTansyoInfo(i).SetDataB(MidB2B(bBuff, 44 + (8 * i), 8))
                tansyou.issue_id()

                tansyou.append_to_col_init("odds_1_id")
                tansyou.append_to_data(current_record_id, True)

                tansyou.append_to_col_init("uma_ban")
                tansyou.append_to_data(OddsTansyoInfo(i).Umaban)
                tansyou.append_to_col_init("odds")
                tansyou.append_to_data(OddsTansyoInfo(i).Odds)
                tansyou.append_to_col_init("ninkizyun")
                tansyou.append_to_data(OddsTansyoInfo(i).Ninki)

                tansyou.data_end()
            Next i
            For i = 0 To 27
                OddsFukusyoInfo(i).SetDataB(MidB2B(bBuff, 268 + (12 * i), 12))
                hukusyou.issue_id()

                hukusyou.append_to_col_init("odds_1_id")
                hukusyou.append_to_data(current_record_id, True)

                hukusyou.append_to_col_init("uma_ban")
                hukusyou.append_to_data(OddsFukusyoInfo(i).Umaban)
                hukusyou.append_to_col_init("saitei_odds")
                hukusyou.append_to_data(OddsFukusyoInfo(i).OddsLow)
                hukusyou.append_to_col_init("saikou_odds")
                hukusyou.append_to_data(OddsFukusyoInfo(i).OddsHigh)
                hukusyou.append_to_col_init("ninkizyun")
                hukusyou.append_to_data(OddsFukusyoInfo(i).Ninki)

                hukusyou.data_end()
            Next i
            For i = 0 To 35
                OddsWakurenInfo(i).SetDataB(MidB2B(bBuff, 604 + (9 * i), 9))
                waku_ren.issue_id()

                waku_ren.append_to_col_init("odds_1_id")
                waku_ren.append_to_data(current_record_id, True)

                waku_ren.append_to_col_init("uma_ban")
                waku_ren.append_to_data(OddsWakurenInfo(i).Kumi)
                waku_ren.append_to_col_init("odds")
                waku_ren.append_to_data(OddsWakurenInfo(i).Odds)
                waku_ren.append_to_col_init("ninkizyun")
                waku_ren.append_to_data(OddsWakurenInfo(i).Ninki)

                waku_ren.data_end()
            Next i

            crlf = MidB2S(bBuff, 961, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �V�D�I�b�Y�i�n�A�j****************************************
    '<�n�A�I�b�Y>
    Public Structure ODDS_UMAREN_INFO
        Public Kumi As String     ''�g��
        Public Odds As String     ''�I�b�Y
        Public Ninki As String     ''�l�C��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumi = MidB2S(bBuff, 1, 4)
            Odds = MidB2S(bBuff, 5, 6)
            Ninki = MidB2S(bBuff, 11, 3)
        End Sub
    End Structure
    Public Structure JV_O2_ODDS_UMAREN
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID     ''<�������ʏ��>
        Public HappyoTime As MDHM    ''���\��������
        Public TorokuTosu As String    ''�o�^����
        Public SyussoTosu As String    ''�o������
        Public UmarenFlag As String    ''�����t���O�@�n�A
        Public OddsUmarenInfo() As ODDS_UMAREN_INFO  ''<�n�A�I�b�Y>
        Public TotalHyosuUmaren As String  ''�n�A�[�����v
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim OddsUmarenInfo(152)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 2042
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            HappyoTime.SetDataB(MidB2B(bBuff, 28, 8))
            TorokuTosu = MidB2S(bBuff, 36, 2)
            SyussoTosu = MidB2S(bBuff, 38, 2)
            UmarenFlag = MidB2S(bBuff, 40, 1)
            TotalHyosuUmaren = MidB2S(bBuff, 2030, 11)

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            injector.append_to_col_init("happyoubi_gappi_zihun")
            injector.append_to_data(HappyoTime.Month & HappyoTime.Day &
                          HappyoTime.Hour & HappyoTime.Minute)
            injector.append_to_col_init("touroku_tousuu")
            injector.append_to_data(TorokuTosu)
            injector.append_to_col_init("syussou_tousuu")
            injector.append_to_data(SyussoTosu)
            injector.append_to_col_init("hyousuu_goukei_uma_ren")
            injector.append_to_data(TotalHyosuUmaren)

            injector.data_end()

            Dim uma_ren As DBInjector = injector.dependent_injectors("jvlink_odds_2_uma_ren_odds")

            For i = 0 To 152
                OddsUmarenInfo(i).SetDataB(MidB2B(bBuff, 41 + (13 * i), 13))
                uma_ren.issue_id()

                uma_ren.append_to_col_init("odds_2_uma_ren_id")
                uma_ren.append_to_data(current_record_id, True)

                uma_ren.append_to_col_init("kumi_ban")
                uma_ren.append_to_data(OddsUmarenInfo(i).Kumi)
                uma_ren.append_to_col_init("odds")
                uma_ren.append_to_data(OddsUmarenInfo(i).Odds)
                uma_ren.append_to_col_init("ninkizyun")
                uma_ren.append_to_data(OddsUmarenInfo(i).Ninki)

                uma_ren.data_end()
            Next i

            crlf = MidB2S(bBuff, 2041, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �W�D�I�b�Y�i���C�h�j****************************************
    '<���C�h�I�b�Y>
    Public Structure ODDS_WIDE_INFO
        Public Kumi As String     ''�g��
        Public OddsLow As String    ''�Œ�I�b�Y
        Public OddsHigh As String    ''�ō��I�b�Y
        Public Ninki As String     ''�l�C��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumi = MidB2S(bBuff, 1, 4)
            OddsLow = MidB2S(bBuff, 5, 5)
            OddsHigh = MidB2S(bBuff, 10, 5)
            Ninki = MidB2S(bBuff, 15, 3)
        End Sub
    End Structure
    Public Structure JV_O3_ODDS_WIDE
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID     ''<�������ʏ��>
        Public HappyoTime As MDHM    ''���\��������
        Public TorokuTosu As String    ''�o�^����
        Public SyussoTosu As String    ''�o������
        Public WideFlag As String    ''�����t���O�@���C�h
        Public OddsWideInfo() As ODDS_WIDE_INFO ''<���C�h�I�b�Y>
        Public TotalHyosuWide As String   ''���C�h�[�����v
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim OddsWideInfo(152)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 2654
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            HappyoTime.SetDataB(MidB2B(bBuff, 28, 8))
            TorokuTosu = MidB2S(bBuff, 36, 2)
            SyussoTosu = MidB2S(bBuff, 38, 2)
            WideFlag = MidB2S(bBuff, 40, 1)
            TotalHyosuWide = MidB2S(bBuff, 2642, 11)

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            injector.append_to_col_init("happyoubi_gappi_zihun")
            injector.append_to_data(HappyoTime.Month & HappyoTime.Day &
                          HappyoTime.Hour & HappyoTime.Minute)
            injector.append_to_col_init("touroku_tousuu")
            injector.append_to_data(TorokuTosu)
            injector.append_to_col_init("syussou_tousuu")
            injector.append_to_data(SyussoTosu)
            injector.append_to_col_init("hyousuu_goukei_wide")
            injector.append_to_data(TotalHyosuWide)

            injector.data_end()

            Dim wide As DBInjector = injector.dependent_injectors("jvlink_odds_3_wide_odds")

            For i = 0 To 152
                OddsWideInfo(i).SetDataB(MidB2B(bBuff, 41 + (17 * i), 17))
                wide.issue_id()

                wide.append_to_col_init("odds_3_wide_id")
                wide.append_to_data(current_record_id, True)

                wide.append_to_col_init("kumi_ban")
                wide.append_to_data(OddsWideInfo(i).Kumi)
                wide.append_to_col_init("saitei_odds")
                wide.append_to_data(OddsWideInfo(i).OddsLow)
                wide.append_to_col_init("saikou_odds")
                wide.append_to_data(OddsWideInfo(i).OddsHigh)
                wide.append_to_col_init("ninkizyun")
                wide.append_to_data(OddsWideInfo(i).Ninki)

                wide.data_end()
            Next i

            crlf = MidB2S(bBuff, 2653, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �X�D�I�b�Y�i�n�P�j ****************************************
    '<�n�P�I�b�Y>
    Public Structure ODDS_UMATAN_INFO
        Public Kumi As String     ''�g��
        Public Odds As String     ''�I�b�Y
        Public Ninki As String     ''�l�C��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumi = MidB2S(bBuff, 1, 4)
            Odds = MidB2S(bBuff, 5, 6)
            Ninki = MidB2S(bBuff, 11, 3)
        End Sub
    End Structure
    Public Structure JV_O4_ODDS_UMATAN
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID     ''<�������ʏ��>
        Public HappyoTime As MDHM    ''���\��������
        Public TorokuTosu As String    ''�o�^����
        Public SyussoTosu As String    ''�o������
        Public UmatanFlag As String    ''�����t���O�@�n�P
        Public OddsUmatanInfo() As ODDS_UMATAN_INFO ''<�n�P�I�b�Y>
        Public TotalHyosuUmatan As String  ''�n�P�[�����v
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim OddsUmatanInfo(305)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 4031
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            HappyoTime.SetDataB(MidB2B(bBuff, 28, 8))
            TorokuTosu = MidB2S(bBuff, 36, 2)
            SyussoTosu = MidB2S(bBuff, 38, 2)
            UmatanFlag = MidB2S(bBuff, 40, 1)
            TotalHyosuUmatan = MidB2S(bBuff, 4019, 11)

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            injector.append_to_col_init("happyoubi_gappi_zihun")
            injector.append_to_data(HappyoTime.Month & HappyoTime.Day &
                          HappyoTime.Hour & HappyoTime.Minute)
            injector.append_to_col_init("touroku_tousuu")
            injector.append_to_data(TorokuTosu)
            injector.append_to_col_init("syussou_tousuu")
            injector.append_to_data(SyussoTosu)
            injector.append_to_col_init("hyousuu_goukei_uma_tan")
            injector.append_to_data(TotalHyosuUmatan)

            injector.data_end()

            Dim uma_tan As DBInjector = injector.dependent_injectors("jvlink_odds_4_uma_tan_odds")

            For i = 0 To 305
                OddsUmatanInfo(i).SetDataB(MidB2B(bBuff, 41 + (13 * i), 13))
                uma_tan.issue_id()

                uma_tan.append_to_col_init("odds_4_uma_tan_id")
                uma_tan.append_to_data(current_record_id, True)

                uma_tan.append_to_col_init("kumi_ban")
                uma_tan.append_to_data(OddsUmatanInfo(i).Kumi)
                uma_tan.append_to_col_init("odds")
                uma_tan.append_to_data(OddsUmatanInfo(i).Odds)
                uma_tan.append_to_col_init("ninkizyun")
                uma_tan.append_to_data(OddsUmatanInfo(i).Ninki)

                uma_tan.data_end()
            Next i

            crlf = MidB2S(bBuff, 4030, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �P�O�D�I�b�Y�i�R�A���j****************************************
    '<3�A���I�b�Y>
    Public Structure ODDS_SANREN_INFO
        Public Kumi As String     ''�g��
        Public Odds As String     ''�I�b�Y
        Public Ninki As String     ''�l�C��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumi = MidB2S(bBuff, 1, 6)
            Odds = MidB2S(bBuff, 7, 6)
            Ninki = MidB2S(bBuff, 13, 3)
        End Sub
    End Structure
    Public Structure JV_O5_ODDS_SANREN
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID     ''<�������ʏ��>
        Public HappyoTime As MDHM    ''���\��������
        Public TorokuTosu As String    ''�o�^����
        Public SyussoTosu As String    ''�o������
        Public SanrenpukuFlag As String   ''�����t���O�@3�A��
        Public OddsSanrenInfo() As ODDS_SANREN_INFO ''<3�A���I�b�Y>
        Public TotalHyosuSanrenpuku As String ''3�A���[�����v
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim OddsSanrenInfo(815)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 12293
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            HappyoTime.SetDataB(MidB2B(bBuff, 28, 8))
            TorokuTosu = MidB2S(bBuff, 36, 2)
            SyussoTosu = MidB2S(bBuff, 38, 2)
            SanrenpukuFlag = MidB2S(bBuff, 40, 1)
            TotalHyosuSanrenpuku = MidB2S(bBuff, 12281, 11)

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            injector.append_to_col_init("happyoubi_gappi_zihun")
            injector.append_to_data(HappyoTime.Month & HappyoTime.Day &
                          HappyoTime.Hour & HappyoTime.Minute)
            injector.append_to_col_init("touroku_tousuu")
            injector.append_to_data(TorokuTosu)
            injector.append_to_col_init("syussou_tousuu")
            injector.append_to_data(SyussoTosu)
            injector.append_to_col_init("hyousuu_goukei_3renpuku")
            injector.append_to_data(TotalHyosuSanrenpuku)

            injector.data_end()

            Dim sanrenpuku As DBInjector = injector.dependent_injectors("jvlink_odds_5_3renpuku_odds")

            For i = 0 To 815
                OddsSanrenInfo(i).SetDataB(MidB2B(bBuff, 41 + (15 * i), 15))
                sanrenpuku.issue_id()

                sanrenpuku.append_to_col_init("odds_5_3renpuku_id")
                sanrenpuku.append_to_data(current_record_id, True)

                sanrenpuku.append_to_col_init("kumi_ban")
                sanrenpuku.append_to_data(OddsSanrenInfo(i).Kumi)
                sanrenpuku.append_to_col_init("odds")
                sanrenpuku.append_to_data(OddsSanrenInfo(i).Odds)
                sanrenpuku.append_to_col_init("ninkizyun")
                sanrenpuku.append_to_data(OddsSanrenInfo(i).Ninki)

                sanrenpuku.data_end()
            Next i
            crlf = MidB2S(bBuff, 12292, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �P�O�|�P�D�I�b�Y�i�R�A�P�j****************************************
    '<3�A�P�I�b�Y>
    Public Structure ODDS_SANRENTAN_INFO
        Public Kumi As String       ''�g��
        Public Odds As String       ''�I�b�Y
        Public Ninki As String      ''�l�C��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumi = MidB2S(bBuff, 1, 6)
            Odds = MidB2S(bBuff, 7, 7)
            Ninki = MidB2S(bBuff, 14, 4)
        End Sub
    End Structure

    Public Structure JV_O6_ODDS_SANRENTAN
        Public head As RECORD_ID                            ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID                                ''<�������ʏ��>
        Public HappyoTime As MDHM                           ''���\��������
        Public TorokuTosu As String                         ''�o�^����
        Public SyussoTosu As String                         ''�o������
        Public SanrentanFlag As String                      ''�����t���O�@3�A�P
        Public OddsSanrentanInfo() As ODDS_SANRENTAN_INFO   ''<3�A�P�I�b�Y>
        Public TotalHyosuSanrentan As String                ''3�A�P�[�����v
        Public crlf As String                               ''���R�[�h��؂�

        '�z��̏�����
        Public Sub Initialize()
            ReDim OddsSanrentanInfo(4895)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 83285
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            HappyoTime.SetDataB(MidB2B(bBuff, 28, 8))
            TorokuTosu = MidB2S(bBuff, 36, 2)
            SyussoTosu = MidB2S(bBuff, 38, 2)
            SanrentanFlag = MidB2S(bBuff, 40, 1)
            TotalHyosuSanrentan = MidB2S(bBuff, 83273, 11)

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            injector.append_to_col_init("touroku_tousuu")
            injector.append_to_data(TorokuTosu)
            injector.append_to_col_init("syussou_tousuu")
            injector.append_to_data(SyussoTosu)

            injector.append_to_col_init("hyousuu_goukei_3rentan")
            injector.append_to_data(TotalHyosuSanrentan)

            injector.data_end()

            Dim sanrentan As DBInjector = injector.dependent_injectors("jvlink_odds_6_3rentan_odds")

            For i = 0 To 4895
                OddsSanrentanInfo(i).SetDataB(MidB2B(bBuff, 41 + (17 * i), 17))
                sanrentan.issue_id()

                sanrentan.append_to_col_init("odds_6_3rentan_id")
                sanrentan.append_to_data(current_record_id, True)

                sanrentan.append_to_col_init("kumi_ban")
                sanrentan.append_to_data(OddsSanrentanInfo(i).Kumi)
                sanrentan.append_to_col_init("odds")
                sanrentan.append_to_data(OddsSanrentanInfo(i).Odds)
                sanrentan.append_to_col_init("ninkizyun")
                sanrentan.append_to_data(OddsSanrentanInfo(i).Ninki)

                sanrentan.data_end()
            Next i
            crlf = MidB2S(bBuff, 83284, 2)
            bBuff = Nothing
        End Sub
    End Structure


    '****** �P�P�D�����n�}�X�^ ****************************************
    '<�R�㌌�����>
    Public Structure KETTO3_INFO
        Public HansyokuNum As String   ''�ɐB�o�^�ԍ�
        Public Bamei As String     ''�n��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            HansyokuNum = MidB2S(bBuff, 1, 8)
            Bamei = MidB2S(bBuff, 9, 36)
        End Sub
    End Structure
    Public Structure JV_UM_UMA
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public KettoNum As String    ''�����o�^�ԍ�
        Public DelKubun As String    ''�����n�����敪
        Public RegDate As YMD     ''�����n�o�^�N����
        Public DelDate As YMD     ''�����n�����N����
        Public BirthDate As YMD     ''���N����
        Public Bamei As String     ''�n��
        Public BameiKana As String    ''�n�����p�J�i
        Public BameiEng As String    ''�n������
        Public ZaikyuFlag As String    ''JRA�{�ݍ݂��イ�t���O
        Public Reserved As String    ''�\��
        Public UmaKigoCD As String    ''�n�L���R�[�h
        Public SexCD As String     ''���ʃR�[�h
        Public HinsyuCD As String    ''�i��R�[�h
        Public KeiroCD As String    ''�ѐF�R�[�h
        Public Ketto3Info() As KETTO3_INFO  ''<3�㌌�����>
        Public TozaiCD As String    ''���������R�[�h
        Public ChokyosiCode As String   ''�����t�R�[�h
        Public ChokyosiRyakusyo As String  ''�����t������
        Public Syotai As String     ''���Ғn�於
        Public BreederCode As String   ''���Y�҃R�[�h
        Public BreederName As String   ''���Y�Җ�
        Public SanchiName As String    ''�Y�n��
        Public BanusiCode As String    ''�n��R�[�h
        Public BanusiName As String    ''�n�喼
        Public RuikeiHonsyoHeiti As String  ''���n�{�܋��݌v
        Public RuikeiHonsyoSyogai As String  ''��Q�{�܋��݌v
        Public RuikeiFukaHeichi As String  ''���n�t���܋��݌v
        Public RuikeiFukaSyogai As String  ''��Q�t���܋��݌v
        Public RuikeiSyutokuHeichi As String ''���n�����܋��݌v
        Public RuikeiSyutokuSyogai As String ''��Q�����܋��݌v
        Public ChakuSogo As CHAKUKAISU3_INFO     ''��������
        Public ChakuChuo As CHAKUKAISU3_INFO     ''�������v����
        Public ChakuKaisuBa() As CHAKUKAISU3_INFO   ''�n��ʒ���
        Public ChakuKaisuJyotai() As CHAKUKAISU3_INFO  ''�n���ԕʒ���
        Public ChakuKaisuKyori() As CHAKUKAISU3_INFO  ''�����ʒ���
        Public Kyakusitu() As String   ''�r���X��
        Public RaceCount As String    ''�o�^���[�X��
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim Ketto3Info(13)
            ReDim ChakuKaisuBa(6)
            ReDim ChakuKaisuJyotai(11)
            ReDim Kyakusitu(3)
            ReDim ChakuKaisuKyori(5)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 1577
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            KettoNum = MidB2S(bBuff, 12, 10)
            DelKubun = MidB2S(bBuff, 22, 1)
            RegDate.SetDataB(MidB2B(bBuff, 23, 8))
            DelDate.SetDataB(MidB2B(bBuff, 31, 8))
            BirthDate.SetDataB(MidB2B(bBuff, 39, 8))
            Bamei = MidB2S(bBuff, 47, 36)
            BameiKana = MidB2S(bBuff, 83, 36)
            BameiEng = MidB2S(bBuff, 119, 60)
            ZaikyuFlag = MidB2S(bBuff, 179, 1)
            Reserved = MidB2S(bBuff, 180, 19)
            UmaKigoCD = MidB2S(bBuff, 199, 2)
            SexCD = MidB2S(bBuff, 201, 1)
            HinsyuCD = MidB2S(bBuff, 202, 1)
            KeiroCD = MidB2S(bBuff, 203, 2)
            For i = 0 To 13
                Ketto3Info(i).SetDataB(MidB2B(bBuff, 205 + (44 * i), 44))
            Next i
            TozaiCD = MidB2S(bBuff, 821, 1)
            ChokyosiCode = MidB2S(bBuff, 822, 5)
            ChokyosiRyakusyo = MidB2S(bBuff, 827, 8)
            Syotai = MidB2S(bBuff, 835, 20)
            BreederCode = MidB2S(bBuff, 855, 6)
            BreederName = MidB2S(bBuff, 861, 70)
            SanchiName = MidB2S(bBuff, 931, 20)
            BanusiCode = MidB2S(bBuff, 951, 6)
            BanusiName = MidB2S(bBuff, 957, 64)
            RuikeiHonsyoHeiti = MidB2S(bBuff, 1021, 9)
            RuikeiHonsyoSyogai = MidB2S(bBuff, 1030, 9)
            RuikeiFukaHeichi = MidB2S(bBuff, 1039, 9)
            RuikeiFukaSyogai = MidB2S(bBuff, 1048, 9)
            RuikeiSyutokuHeichi = MidB2S(bBuff, 1057, 9)
            RuikeiSyutokuSyogai = MidB2S(bBuff, 1066, 9)
            ChakuSogo.SetDataB(MidB2B(bBuff, 1075, 18))
            ChakuChuo.SetDataB(MidB2B(bBuff, 1093, 18))
            For i = 0 To 6
                ChakuKaisuBa(i).SetDataB(MidB2B(bBuff, 1111 + (18 * i), 18))
            Next i
            For i = 0 To 11
                ChakuKaisuJyotai(i).SetDataB(MidB2B(bBuff, 1237 + (18 * i), 18))
            Next i
            For i = 0 To 5
                ChakuKaisuKyori(i).SetDataB(MidB2B(bBuff, 1453 + (18 * i), 18))
            Next i
            For i = 0 To 3
                Kyakusitu(i) = MidB2S(bBuff, 1561 + (3 * i), 3)
            Next i
            RaceCount = MidB2S(bBuff, 1573, 3)
            crlf = MidB2S(bBuff, 1576, 2)

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kettou_touroku_bangou")
            injector.append_to_data(KettoNum)
            injector.append_to_col_init("kyousouba_massyou_kubun")
            injector.append_to_data(DelKubun)
            injector.append_to_col_init("kyousouba_touroku_nen_gappi")
            injector.append_to_data(RegDate.Year & RegDate.Month & RegDate.Day)
            injector.append_to_col_init("kyousouba_massyou_nen_gappi")
            injector.append_to_data(DelDate.Year & DelDate.Month & DelDate.Day)
            injector.append_to_col_init("sei_nen_gappi")
            injector.append_to_data(BirthDate.Year & BirthDate.Month & BirthDate.Day)
            injector.append_to_col_init("uma_mei")
            injector.append_to_data(Bamei)
            injector.append_to_col_init("uma_mei_hankaku_kana")
            injector.append_to_data(BameiKana)
            injector.append_to_col_init("uma_mei_ouzi")
            injector.append_to_data(BameiEng)
            injector.append_to_col_init("JRA_shisetsu_zaikyu_flag")
            injector.append_to_data(ZaikyuFlag)
            injector.append_to_col_init("yobi_1")
            injector.append_to_data(Reserved)
            injector.append_to_col_init("uma_kigou_code")
            injector.append_to_data(UmaKigoCD)
            injector.append_to_col_init("seibetsu_code")
            injector.append_to_data(SexCD)
            injector.append_to_col_init("hinsyu_code")
            injector.append_to_data(HinsyuCD)
            injector.append_to_col_init("keiro_code")
            injector.append_to_data(KeiroCD)

            Dim collection_hubo_type As IEnumerable(Of String) = New List(Of String) _
                From {
                    "hu", "bo",
                    "huhu", "hubo", "bohu", "bobo",
                    "huhuhu", "huhubo", "hubohu", "hubobo",
                    "bohuhu", "bohubo", "bobohu", "bobobo"
            }

            For Each item In collection_hubo_type.Select(Function(hubo_type, index) New With {hubo_type, index})
                injector.append_to_col_init("hansyokuba_tourokubangou_" & item.hubo_type)
                injector.append_to_data(Ketto3Info(item.index).HansyokuNum)
                injector.append_to_col_init("uma_mei_" & item.hubo_type)
                injector.append_to_data(Ketto3Info(item.index).Bamei)
            Next

            injector.append_to_col_init("touzai_syozoku_code")
            injector.append_to_data(TozaiCD)
            injector.append_to_col_init("tyoukyoushi_code")
            injector.append_to_data(ChokyosiCode)
            injector.append_to_col_init("tyoukyoushi_mei_ryakusyou")
            injector.append_to_data(ChokyosiRyakusyo)
            injector.append_to_col_init("syoutai_chiiki_mei")
            injector.append_to_data(Syotai)
            injector.append_to_col_init("seisansya_code")
            injector.append_to_data(BreederCode)
            injector.append_to_col_init("seisansya_mei")
            injector.append_to_data(BreederName)
            injector.append_to_col_init("sanchi_mei")
            injector.append_to_data(SanchiName)
            injector.append_to_col_init("banushi_code")
            injector.append_to_data(BanusiCode)
            injector.append_to_col_init("banushi_mei")
            injector.append_to_data(BanusiName)
            Dim ruikei = "_ruikei"
            injector.append_to_col_init("heichi_honsyoukin" & ruikei)
            injector.append_to_data(RuikeiHonsyoHeiti)
            injector.append_to_col_init("syougai_honsyoukin" & ruikei)
            injector.append_to_data(RuikeiHonsyoSyogai)
            injector.append_to_col_init("heichi_huka_syoukin" & ruikei)
            injector.append_to_data(RuikeiFukaHeichi)
            injector.append_to_col_init("syougai_huka_syoukin" & ruikei)
            injector.append_to_data(RuikeiFukaSyogai)
            injector.append_to_col_init("heichi_syuutokusyoukin" & ruikei)
            injector.append_to_data(RuikeiSyutokuHeichi)
            injector.append_to_col_init("syougai_syuutokusyoukin" & ruikei)
            injector.append_to_data(RuikeiSyutokuSyogai)

            Dim shiba_da_types As String() = {"shiba_", "da_"}
            Dim shiba_da_syougai_types As String() = {"shiba_", "da_", "syougai_"}
            Dim houhou_types As String() = {"tyoku_", "migi_", "hidari_"}
            Dim condition_types As String() = {"ryou_", "saya_", "omo_", "hu_"}
            Dim shita_goe_with_1622_types As String() = {"16_shita_", "22_shita_", "22_goe_"}

            For i = 0 To 5
                Dim ika As String = ""
                If i = 5 Then
                    ika = "_ika"
                End If

                Dim chakuiika As String = "chakukaisuu_" & i + 1 & "_chaku" & ika

                injector.append_to_col_init("sougou_" & chakuiika)
                injector.append_to_data(ChakuSogo.Chakukaisu(i))
                injector.append_to_col_init("tyuuou_goukei_" & chakuiika)
                injector.append_to_data(ChakuChuo.Chakukaisu(i))

                Dim k As Integer = 0

                For Each shiba_da In shiba_da_types
                    For Each houkou In houhou_types
                        injector.append_to_col_init(shiba_da & houkou & chakuiika)
                        injector.append_to_data(ChakuKaisuBa(k).Chakukaisu(i))
                        k += 1
                    Next
                Next

                injector.append_to_col_init("syougai_" & chakuiika)
                injector.append_to_data(ChakuKaisuBa(6).Chakukaisu(i))

                Dim l As Integer = 0

                For Each shiba_da_syougai In shiba_da_syougai_types
                    For Each condition In condition_types
                        injector.append_to_col_init(shiba_da_syougai & condition & chakuiika)
                        injector.append_to_data(ChakuKaisuJyotai(l).Chakukaisu(i))
                        l += 1
                    Next
                Next

                Dim m As Integer = 0

                For Each shiba_da In shiba_da_types
                    For Each shita_goe In shita_goe_with_1622_types
                        injector.append_to_col_init(shiba_da & shita_goe & chakuiika)
                        injector.append_to_data(ChakuKaisuKyori(m).Chakukaisu(i))
                        m += 1
                    Next
                Next

            Next

            Dim kyakushitsu_types As String() = {"nige", "senkou", "sashi", "oikomi"}
            Dim kyakushitsu_keikou = "kyakushitsu_keikou_"

            Dim n As Integer = 0
            For Each kyakushitsu In kyakushitsu_types
                injector.append_to_col_init(kyakushitsu_keikou & kyakushitsu)
                injector.append_to_data(Kyakusitu(n))
                n += 1
            Next

            injector.data_end()

            bBuff = Nothing
        End Sub
    End Structure

    '****** �P�Q�D�R��}�X�^ ****************************************
    '<���R����>
    Public Structure HATUKIJYO_INFO
        Public Hatukijyoid As RACE_ID   ''�N��������R
        Public SyussoTosu As String    ''�o������
        Public KettoNum As String    ''�����o�^�ԍ�
        Public Bamei As String     ''�n��
        Public KakuteiJyuni As String   ''�m�蒅��
        Public IJyoCD As String     ''�ُ�敪�R�[�h
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Hatukijyoid.SetDataB(MidB2B(bBuff, 1, 16))
            SyussoTosu = MidB2S(bBuff, 17, 2)
            KettoNum = MidB2S(bBuff, 19, 10)
            Bamei = MidB2S(bBuff, 29, 36)
            KakuteiJyuni = MidB2S(bBuff, 65, 2)
            IJyoCD = MidB2S(bBuff, 67, 1)
        End Sub
    End Structure
    '<���������>
    Public Structure HATUSYORI_INFO
        Public Hatusyoriid As RACE_ID   ''�N��������R
        Public SyussoTosu As String    ''�o������
        Public KettoNum As String    ''�����o�^�ԍ�
        Public Bamei As String     ''�n��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Hatusyoriid.SetDataB(MidB2B(bBuff, 1, 16))
            SyussoTosu = MidB2S(bBuff, 17, 2)
            KettoNum = MidB2S(bBuff, 19, 10)
            Bamei = MidB2S(bBuff, 29, 36)
        End Sub
    End Structure
    Public Structure JV_KS_KISYU
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public KisyuCode As String    ''�R��R�[�h
        Public DelKubun As String    ''�R�薕���敪
        Public IssueDate As YMD     ''�R��Ƌ���t�N����
        Public DelDate As YMD     ''�R��Ƌ������N����
        Public BirthDate As YMD     ''���N����
        Public KisyuName As String    ''�R�薼����
        Public reserved As String    ''�\��
        Public KisyuNameKana As String   ''�R�薼���p�J�i
        Public KisyuRyakusyo As String   ''�R�薼����
        Public KisyuNameEng As String   ''�R�薼����
        Public SexCD As String     ''���ʋ敪
        Public SikakuCD As String    ''�R�掑�i�R�[�h
        Public MinaraiCD As String    ''�R�茩�K�R�[�h
        Public TozaiCD As String    ''�R�蓌�������R�[�h
        Public Syotai As String     ''���Ғn�於
        Public ChokyosiCode As String   ''���������t�R�[�h
        Public ChokyosiRyakusyo As String  ''���������t������
        Public HatuKiJyo() As HATUKIJYO_INFO   ''<���R����>
        Public HatuSyori() As HATUSYORI_INFO   ''<���������>
        Public SaikinJyusyo() As SAIKIN_JYUSYO_INFO  ''<�ŋߏd�܏������>
        Public HonZenRuikei() As HON_ZEN_RUIKEISEI_INFO ''<�{�N�E�O�N�E�݌v���я��>
        Public crlf As String   ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim HatuKiJyo(1)
            ReDim HatuSyori(1)
            ReDim SaikinJyusyo(2)
            ReDim HonZenRuikei(2)
        End Sub
        '�f�[�^�Z�b�g	
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 4173
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            KisyuCode = MidB2S(bBuff, 12, 5)
            DelKubun = MidB2S(bBuff, 17, 1)
            IssueDate.SetDataB(MidB2B(bBuff, 18, 8))
            DelDate.SetDataB(MidB2B(bBuff, 26, 8))
            BirthDate.SetDataB(MidB2B(bBuff, 34, 8))
            KisyuName = MidB2S(bBuff, 42, 34)
            reserved = MidB2S(bBuff, 76, 34)
            KisyuNameKana = MidB2S(bBuff, 110, 30)
            KisyuRyakusyo = MidB2S(bBuff, 140, 8)
            KisyuNameEng = MidB2S(bBuff, 148, 80)
            SexCD = MidB2S(bBuff, 228, 1)
            SikakuCD = MidB2S(bBuff, 229, 1)
            MinaraiCD = MidB2S(bBuff, 230, 1)
            TozaiCD = MidB2S(bBuff, 231, 1)
            Syotai = MidB2S(bBuff, 232, 20)
            ChokyosiCode = MidB2S(bBuff, 252, 5)
            ChokyosiRyakusyo = MidB2S(bBuff, 257, 8)

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kisyu_code")
            injector.append_to_data(KisyuCode)
            injector.append_to_col_init("kisyu_massyou_kubun")
            injector.append_to_data(DelKubun)
            injector.append_to_col_init("kisyu_menkyo_kouhu_nen_gappi")
            injector.append_to_data(IssueDate.Year & IssueDate.Month & IssueDate.Day)
            injector.append_to_col_init("kisyu_menkyo_massyou_nen_gappi")
            injector.append_to_data(DelDate.Year & DelDate.Month & DelDate.Day)
            injector.append_to_col_init("sei_nen_gappi")
            injector.append_to_data(BirthDate.Year & BirthDate.Month & BirthDate.Day)
            injector.append_to_col_init("kisyu_mei")
            injector.append_to_data(KisyuName)
            injector.append_to_col_init("yobi_1")
            injector.append_to_data(reserved)
            injector.append_to_col_init("kisyu_mei_hankaku_kana")
            injector.append_to_data(KisyuNameKana)
            injector.append_to_col_init("kisyu_mei_ouzi")
            injector.append_to_data(KisyuNameEng)
            injector.append_to_col_init("seibetsu_kubun")
            injector.append_to_data(SexCD)
            injector.append_to_col_init("kizyou_shikaku_code")
            injector.append_to_data(SikakuCD)
            injector.append_to_col_init("kisyu_minarai_code")
            injector.append_to_data(MinaraiCD)
            injector.append_to_col_init("kisyu_touzai_syozoku_code")
            injector.append_to_data(TozaiCD)
            injector.append_to_col_init("syoutai_chiiki_mei")
            injector.append_to_data(Syotai)
            injector.append_to_col_init("syozoku_tyoukyoushi_code")
            injector.append_to_data(ChokyosiCode)
            injector.append_to_col_init("syozoku_tyoukyoushi_meisyou")
            injector.append_to_data(ChokyosiRyakusyo)

            Dim heichi_syougai As String() = {"hatsu_heichi_", "hatsu_syougai_"}

            For i = 0 To 1
                HatuKiJyo(i).SetDataB(MidB2B(bBuff, 265 + (67 * i), 67))
            Next i
            For i = 0 To 1
                HatuSyori(i).SetDataB(MidB2B(bBuff, 399 + (64 * i), 64))
            Next i
            For i = 0 To 2
                SaikinJyusyo(i).SetDataB(MidB2B(bBuff, 527 + (163 * i), 163))
            Next i
            For i = 0 To 2
                HonZenRuikei(i).SetDataB(MidB2B(bBuff, 1016 + (1052 * i), 1052))
            Next i

            Dim j As Integer = 0

            For Each heichi_syougai_prefix In heichi_syougai
                injector.append_to_col_init(heichi_syougai_prefix & "kizyou_nen_gappi_zyou_kai_hi_R")
                injector.append_to_data(HatuKiJyo(j).Hatukijyoid.ToString())
                injector.append_to_col_init(heichi_syougai_prefix & "kizyou_syussou_tousuu")
                injector.append_to_data(HatuKiJyo(j).SyussoTosu)
                injector.append_to_col_init(heichi_syougai_prefix & "kizyou_kettou_touroku_bangou")
                injector.append_to_data(HatuKiJyo(j).KettoNum)
                injector.append_to_col_init(heichi_syougai_prefix & "kizyou_uma_mei")
                injector.append_to_data(HatuKiJyo(j).Bamei)
                injector.append_to_col_init(heichi_syougai_prefix & "kizyou_kakutei_chakuzyun")
                injector.append_to_data(HatuKiJyo(j).KakuteiJyuni)
                injector.append_to_col_init(heichi_syougai_prefix & "izyou_kubun_code")
                injector.append_to_data(HatuKiJyo(j).IJyoCD)

                injector.append_to_col_init(heichi_syougai_prefix & "syouri_nen_gappi_zyou_kai_hi_R")
                injector.append_to_data(HatuSyori(j).Hatusyoriid.ToString())
                injector.append_to_col_init(heichi_syougai_prefix & "syouri_syussou_tousuu")
                injector.append_to_data(HatuSyori(j).SyussoTosu)
                injector.append_to_col_init(heichi_syougai_prefix & "syouri_kettou_touroku_bangou")
                injector.append_to_data(HatuSyori(j).KettoNum)
                injector.append_to_col_init(heichi_syougai_prefix & "syouri_uma_mei")
                injector.append_to_data(HatuSyori(j).Bamei)
                j += 1
            Next

            injector = append_seiseki_information(injector, SaikinJyusyo, HonZenRuikei)

            injector.data_end()

            crlf = MidB2S(bBuff, 4172, 2)
            bBuff = Nothing
        End Sub
    End Structure


    Private Function append_seiseki_information(injector As DBInjector,
            SaikinJyusyo() As SAIKIN_JYUSYO_INFO,
            HonZenRuikei() As HON_ZEN_RUIKEISEI_INFO)

        For i = 1 To 3
            Dim prefix As String = "recent_zyuusyou_race_" & i & "_"
            injector.append_to_col_init(prefix & "nenn_gappi_zyou_kai_R")
            injector.append_to_data(SaikinJyusyo(i - 1).SaikinJyusyoid.ToString())
            injector.append_to_col_init(prefix & "kyousoumei_hondai")
            injector.append_to_data(SaikinJyusyo(i - 1).Hondai)
            injector.append_to_col_init(prefix & "kyousoumei_ryakusyou_10")
            injector.append_to_data(SaikinJyusyo(i - 1).Ryakusyo10)
            injector.append_to_col_init(prefix & "kyousoumei_ryakusyou_6")
            injector.append_to_data(SaikinJyusyo(i - 1).Ryakusyo6)
            injector.append_to_col_init(prefix & "kyousoumei_ryakusyou_3")
            injector.append_to_data(SaikinJyusyo(i - 1).Ryakusyo3)
            injector.append_to_col_init(prefix & "grade_code")
            injector.append_to_data(SaikinJyusyo(i - 1).GradeCD)
            injector.append_to_col_init(prefix & "syussou_tousuu")
            injector.append_to_data(SaikinJyusyo(i - 1).SyussoTosu)
            injector.append_to_col_init(prefix & "kettou_touroku_bangou")
            injector.append_to_data(SaikinJyusyo(i - 1).KettoNum)
            injector.append_to_col_init(prefix & "uma_mei")
            injector.append_to_data(SaikinJyusyo(i - 1).Bamei)
        Next

        Dim years As String() = {"_honnnen", "_zennen", "_ruikei"}
        Dim field_types As String() = {"heichi", "syougai"}
        Dim shiba_da_types As String() = {"shiba", "da"}
        Dim field_locations As String() = {
            "sapporo",
            "hakodate",
            "hukushima",
            "niigata",
            "toukyou",
            "nakayama",
            "tyuukyou",
            "kyouto",
            "hanshin",
            "ogura"
        }

        Dim j As Integer = 0

        For Each year_prefix In years
            injector.append_to_col_init("settei_nen" & year_prefix)
            injector.append_to_data(HonZenRuikei(j).SetYear)
            injector.append_to_col_init("heichi_honsyoukin_goukei" & year_prefix)
            injector.append_to_data(HonZenRuikei(j).HonSyokinHeichi)
            injector.append_to_col_init("syougai_honsyoukin_goukei" & year_prefix)
            injector.append_to_data(HonZenRuikei(j).HonSyokinSyogai)
            injector.append_to_col_init("heichi_huka_syoukin_goukei" & year_prefix)
            injector.append_to_data(HonZenRuikei(j).FukaSyokinHeichi)
            injector.append_to_col_init("syougai_huka_syoukin_goukei" & year_prefix)
            injector.append_to_data(HonZenRuikei(j).FukaSyokinSyogai)

            For i = 1 To 6
                Dim ika As String = ""
                If i = 6 Then
                    ika = "_ika"
                End If

                injector.append_to_col_init("heichi_" & i & "_chaku" & ika & "_kaisuu" & year_prefix)
                injector.append_to_data(HonZenRuikei(j).ChakuKaisuHeichi.Chakukaisu(i - 1))
                injector.append_to_col_init("syougai_" & i & "_chaku" & ika & "_kaisuu" & year_prefix)
                injector.append_to_data(HonZenRuikei(j).ChakuKaisuSyogai.Chakukaisu(i - 1))

                Dim k As Integer = 0
                For Each field_location In field_locations
                    For Each field_type In field_types
                        injector.append_to_col_init(field_location & "_" & field_type & "_" &
                                             i & ika & "_chakukaisuu" & year_prefix)
                        injector.append_to_data(HonZenRuikei(j).ChakuKaisuJyo(k).Chakukaisu(i - 1))
                        k += 1
                    Next
                Next

                Dim l As Integer = 0
                For Each shiba_da_type In shiba_da_types
                    injector.append_to_col_init(shiba_da_type & "16_shita_" &
                                         i & ika & "_chakukaisuu" & year_prefix)
                    injector.append_to_data(HonZenRuikei(j).ChakuKaisuKyori(l).Chakukaisu(i - 1))
                    injector.append_to_col_init(shiba_da_type & "22_shita_" &
                         i & ika & "_chakukaisuu" & year_prefix)
                    injector.append_to_data(HonZenRuikei(j).ChakuKaisuKyori(l).Chakukaisu(i - 1))
                    injector.append_to_col_init(shiba_da_type & "22_goe_" &
                         i & ika & "_chakukaisuu" & year_prefix)
                    injector.append_to_data(HonZenRuikei(j).ChakuKaisuKyori(l).Chakukaisu(i - 1))
                    l += 1
                Next
            Next
        Next
        Return injector
    End Function

    '****** �P�R�D�����t�}�X�^ ****************************************
    Public Structure JV_CH_CHOKYOSI
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public ChokyosiCode As String   ''�����t�R�[�h
        Public DelKubun As String    ''�����t�����敪
        Public IssueDate As YMD      ''�����t�Ƌ���t�N����
        Public DelDate As YMD     ''�����t�Ƌ������N����
        Public BirthDate As YMD     ''���N����
        Public ChokyosiName As String   ''�����t������
        Public ChokyosiNameKana As String  ''�����t�����p�J�i
        Public ChokyosiRyakusyo As String  ''�����t������
        Public ChokyosiNameEng As String  ''�����t������
        Public SexCD As String     ''���ʋ敪
        Public TozaiCD As String    ''�����t���������R�[�h
        Public Syotai As String     ''���Ғn�於
        Public SaikinJyusyo() As SAIKIN_JYUSYO_INFO  ''<�ŋߏd�܏������>
        Public HonZenRuikei() As HON_ZEN_RUIKEISEI_INFO ''<�{�N�E�O�N�E�݌v���я��>
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim SaikinJyusyo(2)
            ReDim HonZenRuikei(2)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 3862
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            ChokyosiCode = MidB2S(bBuff, 12, 5)
            DelKubun = MidB2S(bBuff, 17, 1)
            IssueDate.SetDataB(MidB2B(bBuff, 18, 8))
            DelDate.SetDataB(MidB2B(bBuff, 26, 8))
            BirthDate.SetDataB(MidB2B(bBuff, 34, 8))
            ChokyosiName = MidB2S(bBuff, 42, 34)
            ChokyosiNameKana = MidB2S(bBuff, 76, 30)
            ChokyosiRyakusyo = MidB2S(bBuff, 106, 8)
            ChokyosiNameEng = MidB2S(bBuff, 114, 80)
            SexCD = MidB2S(bBuff, 194, 1)
            TozaiCD = MidB2S(bBuff, 195, 1)
            Syotai = MidB2S(bBuff, 196, 20)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("tyoukyoushi_code")
            injector.append_to_data(ChokyosiCode)
            injector.append_to_col_init("tyoukyoushi_massyou_kubun")
            injector.append_to_data(DelKubun)
            injector.append_to_col_init("tyoukyoushi_menkyo_kouhu_nen_gappi")
            injector.append_to_data(IssueDate.Year & IssueDate.Month & IssueDate.Day)
            injector.append_to_col_init("tyoukyoushi_menkyo_massyou_nen_gappi")
            injector.append_to_data(DelDate.Year & DelDate.Month & DelDate.Day)
            injector.append_to_col_init("sei_nen_gappi")
            injector.append_to_data(BirthDate.Year & BirthDate.Month & BirthDate.Day)
            injector.append_to_col_init("tyoukyoushi_mei")
            injector.append_to_data(ChokyosiName)
            injector.append_to_col_init("tyoukyoushi_mei_hankaku_kana")
            injector.append_to_data(ChokyosiNameKana)
            injector.append_to_col_init("tyoukyoushi_mei_ryakusyou")
            injector.append_to_data(ChokyosiRyakusyo)
            injector.append_to_col_init("tyoukyoushi_mei_ouzi")
            injector.append_to_data(ChokyosiNameEng)
            injector.append_to_col_init("seibetsu_kubun")
            injector.append_to_data(SexCD)
            injector.append_to_col_init("tyoukyoushi_touzai_syozoku_code")
            injector.append_to_data(TozaiCD)
            injector.append_to_col_init("syoutai_chiiki_mei")
            injector.append_to_data(Syotai)

            For i = 0 To 2
                SaikinJyusyo(i).SetDataB(MidB2B(bBuff, 216 + (163 * i), 163))
            Next i
            For i = 0 To 2
                HonZenRuikei(i).SetDataB(MidB2B(bBuff, 705 + (1052 * i), 1052))
            Next i

            injector = append_seiseki_information(injector, SaikinJyusyo, HonZenRuikei)

            injector.data_end()

            crlf = MidB2S(bBuff, 3861, 2)
            bBuff = Nothing
        End Sub
    End Structure

    ''******�P�S�D���Y�҃}�X�^ ****************************************
    Public Structure JV_BR_BREEDER
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public BreederCode As String   ''���Y�҃R�[�h
        Public BreederName_Co As String   ''���Y�Җ�(�@�l�i�L)
        Public BreederName As String   ''���Y�Җ�(�@�l�i��)
        Public BreederNameKana As String  ''���Y�Җ����p�J�i
        Public BreederNameEng As String   ''���Y�Җ�����
        Public Address As String    ''���Y�ҏZ�������Ȗ�
        Public HonRuikei() As SEI_RUIKEI_INFO ''<�{�N�E�݌v���я��>
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim HonRuikei(1)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 537
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            BreederCode = MidB2S(bBuff, 12, 6)
            BreederName_Co = MidB2S(bBuff, 18, 70)
            BreederName = MidB2S(bBuff, 88, 70)
            BreederNameKana = MidB2S(bBuff, 158, 70)
            BreederNameEng = MidB2S(bBuff, 228, 168)
            Address = MidB2S(bBuff, 396, 20)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("seisansya_code")
            injector.append_to_data(BreederCode)
            injector.append_to_col_init("seisansya_mei_houzin")
            injector.append_to_data(BreederName_Co)
            injector.append_to_col_init("seisansya_mei_not_houzin")
            injector.append_to_data(BreederName)
            injector.append_to_col_init("seisansya_mei_hankaku_kana")
            injector.append_to_data(BreederNameKana)
            injector.append_to_col_init("seisansya_mei_ouzi")
            injector.append_to_data(BreederNameEng)
            injector.append_to_col_init("sesansya_zyuusyo_zichitai_mei")
            injector.append_to_data(Address)

            For i = 0 To 1
                HonRuikei(i).SetDataB(MidB2B(bBuff, 416 + (60 * i), 60))
            Next i

            Dim honnnen_ruikei_type As String() = {"_honnnen", "_ruikei"}
            Dim j As Integer = 0

            For Each honnnen_ruikei In honnnen_ruikei_type
                injector.append_to_col_init("settei_nen" & honnnen_ruikei)
                injector.append_to_data(HonRuikei(j).SetYear)
                injector.append_to_col_init("honsyoukin_goukei" & honnnen_ruikei)
                injector.append_to_data(HonRuikei(j).HonSyokinTotal)
                injector.append_to_col_init("huka_syoukin_goukei" & honnnen_ruikei)
                injector.append_to_data(HonRuikei(j).FukaSyokin)
                For i = 0 To 5
                    injector.append_to_col_init("chakukaisuu_" & i + 1 & honnnen_ruikei)
                    injector.append_to_data(HonRuikei(j).ChakuKaisu(i))
                Next
                j += 1
            Next

            injector.data_end()

            crlf = MidB2S(bBuff, 536, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �P�T�D�n��}�X�^ ****************************************
    Public Structure JV_BN_BANUSI
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public BanusiCode As String    ''�n��R�[�h
        Public BanusiName_Co As String    ''�n�喼(�@�l�i�L)
        Public BanusiName As String    ''�n�喼(�@�l�i��)
        Public BanusiNameKana As String   ''�n�喼���p�J�i
        Public BanusiNameEng As String   ''�n�喼����
        Public Fukusyoku As String    ''���F�W��
        Public HonRuikei() As SEI_RUIKEI_INFO ''<�{�N�E�݌v���я��>
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim HonRuikei(1)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 477
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            BanusiCode = MidB2S(bBuff, 12, 6)
            BanusiName_Co = MidB2S(bBuff, 18, 64)
            BanusiName = MidB2S(bBuff, 82, 64)
            BanusiNameKana = MidB2S(bBuff, 146, 50)
            BanusiNameEng = MidB2S(bBuff, 196, 100)
            Fukusyoku = MidB2S(bBuff, 296, 60)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("banushi_code")
            injector.append_to_data(BanusiCode)
            injector.append_to_col_init("banushi_mei_houzin")
            injector.append_to_data(BanusiName_Co)
            injector.append_to_col_init("banushi_mei_not_houzin")
            injector.append_to_data(BanusiName)
            injector.append_to_col_init("banushi_mei_hankaku_kana")
            injector.append_to_data(BanusiNameKana)
            injector.append_to_col_init("banushi_mei_ouzi")
            injector.append_to_data(BanusiNameEng)
            injector.append_to_col_init("hukusyoku_hyouzi")
            injector.append_to_data(Fukusyoku)

            Dim honnnen_ruikei_type As String() = {"_honnnen", "_ruikei"}

            For i = 0 To 1
                HonRuikei(i).SetDataB(MidB2B(bBuff, 356 + (60 * i), 60))
            Next i

            Dim j As Integer = 0

            For Each honnnen_ruikei In honnnen_ruikei_type
                injector.append_to_col_init("settei_nen" & honnnen_ruikei)
                injector.append_to_data(HonRuikei(j).SetYear)
                injector.append_to_col_init("honsyoukin_goukei" & honnnen_ruikei)
                injector.append_to_data(HonRuikei(j).HonSyokinTotal)
                injector.append_to_col_init("huka_syoukin_goukei" & honnnen_ruikei)
                injector.append_to_data(HonRuikei(j).FukaSyokin)
                For i = 0 To 5
                    injector.append_to_col_init("chakukaisuu_" & i + 1 & honnnen_ruikei)
                    injector.append_to_data(HonRuikei(j).ChakuKaisu(i))
                Next
                j += 1
            Next

            injector.data_end()

            crlf = MidB2S(bBuff, 476, 2)
            bBuff = Nothing
        End Sub
    End Structure

    ''****** �P�U�D�ɐB�n�}�X�^ ****************************************
    Public Structure JV_HN_HANSYOKU
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public HansyokuNum As String   ''�ɐB�o�^�ԍ�
        Public reserved As String    ''�\��
        Public KettoNum As String    ''�����o�^�ԍ�
        Public DelKubun As String    ''�ɐB�n�����敪(���݂͗\���Ƃ��Ďg�p)
        Public Bamei As String     ''�n��
        Public BameiKana As String    ''�n�����p�J�i
        Public BameiEng As String    ''�n������
        Public BirthYear As String    ''���N
        Public SexCD As String     ''���ʃR�[�h
        Public HinsyuCD As String    ''�i��R�[�h
        Public KeiroCD As String    ''�ѐF�R�[�h
        Public HansyokuMochiKubun As String  ''�ɐB�n�����敪
        Public ImportYear As String    ''�A���N
        Public SanchiName As String    ''�Y�n��
        Public HansyokuFNum As String   ''���n�ɐB�o�^�ԍ�
        Public HansyokuMNum As String   ''��n�ɐB�o�^�ԍ�
        Public crlf As String     ''���R�[�h��؂�
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 245
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            HansyokuNum = MidB2S(bBuff, 12, 8)
            reserved = MidB2S(bBuff, 20, 8)
            KettoNum = MidB2S(bBuff, 28, 10)
            DelKubun = MidB2S(bBuff, 38, 1)
            Bamei = MidB2S(bBuff, 39, 36)
            BameiKana = MidB2S(bBuff, 75, 40)
            BameiEng = MidB2S(bBuff, 115, 80)
            BirthYear = MidB2S(bBuff, 195, 4)
            SexCD = MidB2S(bBuff, 199, 1)
            HinsyuCD = MidB2S(bBuff, 200, 1)
            KeiroCD = MidB2S(bBuff, 201, 2)
            HansyokuMochiKubun = MidB2S(bBuff, 203, 1)
            ImportYear = MidB2S(bBuff, 204, 4)
            SanchiName = MidB2S(bBuff, 208, 20)
            HansyokuFNum = MidB2S(bBuff, 228, 8)
            HansyokuMNum = MidB2S(bBuff, 236, 8)
            crlf = MidB2S(bBuff, 244, 2)
            bBuff = Nothing

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("hansyokuba_touroku_bangou")
            injector.append_to_data(HansyokuNum)
            injector.append_to_col_init("yobi_1")
            injector.append_to_data(reserved)
            injector.append_to_col_init("kettou_touroku_bangou")
            injector.append_to_data(KettoNum)
            injector.append_to_col_init("delkubun")
            injector.append_to_data(DelKubun)
            injector.append_to_col_init("uma_mei")
            injector.append_to_data(Bamei)
            injector.append_to_col_init("uma_mei_hankaku_kana")
            injector.append_to_data(BameiKana)
            injector.append_to_col_init("uma_mei_ouzi")
            injector.append_to_data(BameiEng)

            injector.append_to_col_init("seinen")
            injector.append_to_data(BirthYear)
            injector.append_to_col_init("seibetsu_code")
            injector.append_to_data(SexCD)
            injector.append_to_col_init("hinsyu_code")
            injector.append_to_data(HinsyuCD)
            injector.append_to_col_init("keiro_code")
            injector.append_to_data(KeiroCD)
            injector.append_to_col_init("hansyokuba_mochikomi_kubun")
            injector.append_to_data(HansyokuMochiKubun)
            injector.append_to_col_init("yunyuu_nen")
            injector.append_to_data(ImportYear)
            injector.append_to_col_init("sanchi_mei")
            injector.append_to_data(SanchiName)
            injector.append_to_col_init("huba_hansyoku_touroku_bangou")
            injector.append_to_data(HansyokuFNum)
            injector.append_to_col_init("boba_hansyoku_touroku_bangou")
            injector.append_to_data(HansyokuMNum)

            injector.data_end()

        End Sub
    End Structure

    '****** �P�V�D�Y��}�X�^ ****************************************
    Public Structure JV_SK_SANKU
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public KettoNum As String    ''�����o�^�ԍ�
        Public BirthDate As YMD     ''���N����
        Public SexCD As String     ''���ʃR�[�h
        Public HinsyuCD As String    ''�i��R�[�h
        Public KeiroCD As String    ''�ѐF�R�[�h
        Public SankuMochiKubun As String  ''�Y����敪
        Public ImportYear As String    ''�A���N
        Public BreederCode As String   ''���Y�҃R�[�h
        Public SanchiName As String    ''�Y�n��
        Public HansyokuNum() As String   ''3�㌌�� �ɐB�o�^�ԍ�
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim HansyokuNum(13)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 178
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            KettoNum = MidB2S(bBuff, 12, 10)
            BirthDate.SetDataB(MidB2B(bBuff, 22, 8))
            SexCD = MidB2S(bBuff, 30, 1)
            HinsyuCD = MidB2S(bBuff, 31, 1)
            KeiroCD = MidB2S(bBuff, 32, 2)
            SankuMochiKubun = MidB2S(bBuff, 34, 1)
            ImportYear = MidB2S(bBuff, 35, 4)
            BreederCode = MidB2S(bBuff, 39, 6)
            SanchiName = MidB2S(bBuff, 45, 20)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)


            injector.append_to_col_init("kettou_touroku_bangou")
            injector.append_to_data(KettoNum)
            injector.append_to_col_init("seinenn_gappi")
            injector.append_to_data(BirthDate.Year & BirthDate.Month & BirthDate.Day)
            injector.append_to_col_init("seibetsu_code")
            injector.append_to_data(SexCD)
            injector.append_to_col_init("hinsyu_code")
            injector.append_to_data(HinsyuCD)
            injector.append_to_col_init("keiro_code")
            injector.append_to_data(KeiroCD)
            injector.append_to_col_init("sanku_mochikomi_kubun")
            injector.append_to_data(SankuMochiKubun)
            injector.append_to_col_init("yunyuu_nen")
            injector.append_to_data(ImportYear)
            injector.append_to_col_init("seisansya_code")
            injector.append_to_data(BreederCode)
            injector.append_to_col_init("sanchi_mei")
            injector.append_to_data(SanchiName)

            For i = 0 To 13
                HansyokuNum(i) = MidB2S(bBuff, 65 + (8 * i), 8)
            Next i

            Dim hubo_types As String() = {
            "hu", "bo",
            "huhu", "hubo", "bohu", "bobo",
            "huhuhu", "huhubo", "hubohu", "hubobo",
            "bohuhu", "bohubo", "bobohu", "bobobo"}

            Dim j As Integer = 0

            For Each hubo_type In hubo_types
                injector.append_to_col_init(hubo_type & "_hansyoku_touroku_bangou")
                injector.append_to_data(HansyokuNum(j))
                j += 1
            Next

            injector.data_end()

            crlf = MidB2S(bBuff, 177, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �P�W�D���R�[�h�}�X�^ ****************************************
    '<���R�[�h�ێ��n���>
    Public Structure RECUMA_INFO
        Public KettoNum As String    ''�����o�^�ԍ�
        Public Bamei As String     ''�n��
        Public UmaKigoCD As String    ''�n�L���R�[�h
        Public SexCD As String     ''���ʃR�[�h
        Public ChokyosiCode As String   ''�����t�R�[�h
        Public ChokyosiName As String   ''�����t��
        Public Futan As String     ''���S�d��
        Public KisyuCode As String    ''�R��R�[�h
        Public KisyuName As String    ''�R�薼
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            KettoNum = MidB2S(bBuff, 1, 10)
            Bamei = MidB2S(bBuff, 11, 36)
            UmaKigoCD = MidB2S(bBuff, 47, 2)
            SexCD = MidB2S(bBuff, 49, 1)
            ChokyosiCode = MidB2S(bBuff, 50, 5)
            ChokyosiName = MidB2S(bBuff, 55, 34)
            Futan = MidB2S(bBuff, 89, 3)
            KisyuCode = MidB2S(bBuff, 92, 5)
            KisyuName = MidB2S(bBuff, 97, 34)
        End Sub
    End Structure
    Public Structure JV_RC_RECORD
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public RecInfoKubun As String   ''���R�[�h���ʋ敪
        Public id As RACE_ID     ''<�������ʏ��>
        Public TokuNum As String    ''���ʋ����ԍ�
        Public Hondai As String     ''�������{��
        Public GradeCD As String    ''�O���[�h�R�[�h
        Public SyubetuCD As String    ''������ʃR�[�h
        Public Kyori As String     ''����
        Public TrackCD As String    ''�g���b�N�R�[�h
        Public RecKubun As String    ''���R�[�h�敪
        Public RecTime As String    ''���R�[�h�^�C��
        Public TenkoBaba As TENKO_BABA_INFO  ''�V��E�n����
        Public RecUmaInfo() As RECUMA_INFO  ''<���R�[�h�ێ��n���>
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim RecUmaInfo(2)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 501
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            RecInfoKubun = MidB2S(bBuff, 12, 1)
            id.SetDataB(MidB2B(bBuff, 13, 16))
            TokuNum = MidB2S(bBuff, 29, 4)
            Hondai = MidB2S(bBuff, 33, 60)
            GradeCD = MidB2S(bBuff, 93, 1)
            SyubetuCD = MidB2S(bBuff, 94, 2)
            Kyori = MidB2S(bBuff, 96, 4)
            TrackCD = MidB2S(bBuff, 100, 2)
            RecKubun = MidB2S(bBuff, 102, 1)
            RecTime = MidB2S(bBuff, 103, 4)
            TenkoBaba.SetDataB(MidB2B(bBuff, 107, 3))

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)


            injector.append_to_col_init("record_shikibetsu_kubun")
            injector.append_to_data(RecInfoKubun)
            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)
            injector.append_to_col_init("tokubetsu_kyousou_bangou")
            injector.append_to_data(TokuNum)
            injector.append_to_col_init("kyousoumei_hondai")
            injector.append_to_data(Hondai)
            injector.append_to_col_init("grade_code")
            injector.append_to_data(GradeCD)
            injector.append_to_col_init("kyousou_syubetsu_code")
            injector.append_to_data(SyubetuCD)
            injector.append_to_col_init("kyori")
            injector.append_to_data(Kyori)
            injector.append_to_col_init("track_code")
            injector.append_to_data(TrackCD)
            injector.append_to_col_init("record_kubun")
            injector.append_to_data(RecKubun)
            injector.append_to_col_init("record_time")
            injector.append_to_data(RecTime)
            injector.append_to_col_init("tenkou_code")
            injector.append_to_data(TenkoBaba.TenkoCD)
            injector.append_to_col_init("shiba_baba_zyoutai_code")
            injector.append_to_data(TenkoBaba.SibaBabaCD)
            injector.append_to_col_init("dirt_baba_zyoutai_code")
            injector.append_to_data(TenkoBaba.DirtBabaCD)

            For i = 0 To 2
                RecUmaInfo(i).SetDataB(MidB2B(bBuff, 110 + (130 * i), 130))
                injector.append_to_col_init("kettou_touroku_bangou_" & i + 1)
                injector.append_to_data(RecUmaInfo(i).KettoNum)
                injector.append_to_col_init("uma_mei_" & i + 1)
                injector.append_to_data(RecUmaInfo(i).Bamei)
                injector.append_to_col_init("uma_kigou_code_" & i + 1)
                injector.append_to_data(RecUmaInfo(i).UmaKigoCD)
                injector.append_to_col_init("seibetsu_code_" & i + 1)
                injector.append_to_data(RecUmaInfo(i).SexCD)
                injector.append_to_col_init("tyoukyoushi_code_" & i + 1)
                injector.append_to_data(RecUmaInfo(i).ChokyosiCode)
                injector.append_to_col_init("tyoukyoushi_mei_" & i + 1)
                injector.append_to_data(RecUmaInfo(i).ChokyosiName)
                injector.append_to_col_init("hutan_zyuuryou_" & i + 1)
                injector.append_to_data(RecUmaInfo(i).Futan)
                injector.append_to_col_init("kisyu_code_" & i + 1)
                injector.append_to_data(RecUmaInfo(i).KisyuCode)
                injector.append_to_col_init("kisyu_mei_" & i + 1)
                injector.append_to_data(RecUmaInfo(i).KisyuName)
            Next i

            injector.data_end()

            crlf = MidB2S(bBuff, 500, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �P�X�D��H���� ****************************************
    Public Structure JV_HC_HANRO
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public TresenKubun As String   ''�g���Z���敪
        Public ChokyoDate As YMD    ''�����N����
        Public ChokyoTime As String    ''��������
        Public KettoNum As String    ''�����o�^�ԍ�
        Public HaronTime4 As String    ''4�n�����^�C�����v(800M-0M)
        Public LapTime4 As String    ''���b�v�^�C��(800M-600M)
        Public HaronTime3 As String    ''3�n�����^�C�����v(600M-0M)
        Public LapTime3 As String    ''���b�v�^�C��(600M-400M)
        Public HaronTime2 As String    ''2�n�����^�C�����v(400M-0M)
        Public LapTime2 As String    ''���b�v�^�C��(400M-200M)
        Public LapTime1 As String    ''���b�v�^�C��(200M-0M)
        Public crlf As String     ''���R�[�h��؂�
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 60
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            TresenKubun = MidB2S(bBuff, 12, 1)
            ChokyoDate.SetDataB(MidB2B(bBuff, 13, 8))
            ChokyoTime = MidB2S(bBuff, 21, 4)
            KettoNum = MidB2S(bBuff, 25, 10)
            HaronTime4 = MidB2S(bBuff, 35, 4)
            LapTime4 = MidB2S(bBuff, 39, 3)
            HaronTime3 = MidB2S(bBuff, 42, 4)
            LapTime3 = MidB2S(bBuff, 46, 3)
            HaronTime2 = MidB2S(bBuff, 49, 4)
            LapTime2 = MidB2S(bBuff, 53, 3)
            LapTime1 = MidB2S(bBuff, 56, 3)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("traning_center_kubun")
            injector.append_to_data(TresenKubun)
            injector.append_to_col_init("tyoukyou_nen_gappi")
            injector.append_to_data(ChokyoDate.Year & ChokyoDate.Month & ChokyoDate.Day)
            injector.append_to_col_init("tyoukyou_zikoku")
            injector.append_to_data(ChokyoTime)
            injector.append_to_col_init("kettou_touroku_bangou")
            injector.append_to_data(KettoNum)
            injector.append_to_col_init("furlong_time_goukei_4_800_0")
            injector.append_to_data(HaronTime4)
            injector.append_to_col_init("lap_time_800_600")
            injector.append_to_data(LapTime4)
            injector.append_to_col_init("furlong_time_goukei_3_600_0")
            injector.append_to_data(HaronTime3)
            injector.append_to_col_init("lap_time_600_400")
            injector.append_to_data(LapTime3)
            injector.append_to_col_init("furlong_time_goukei_2_400_0")
            injector.append_to_data(HaronTime2)
            injector.append_to_col_init("lap_time_400_200")
            injector.append_to_data(LapTime2)
            injector.append_to_col_init("lap_time_200_0")
            injector.append_to_data(LapTime1)

            injector.data_end()

            crlf = MidB2S(bBuff, 59, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �Q�O�D�n�̏d ****************************************
    '<�n�̏d���>
    Public Structure BATAIJYU_INFO
        Public Umaban As String     ''�n��
        Public Bamei As String     ''�n��
        Public BaTaijyu As String    ''�n�̏d
        Public ZogenFugo As String    ''��������
        Public ZogenSa As String    ''������
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Umaban = MidB2S(bBuff, 1, 2)
            Bamei = MidB2S(bBuff, 3, 36)
            BaTaijyu = MidB2S(bBuff, 39, 3)
            ZogenFugo = MidB2S(bBuff, 42, 1)
            ZogenSa = MidB2S(bBuff, 43, 3)
        End Sub
    End Structure
    Public Structure JV_WH_BATAIJYU
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID     ''<�������ʏ��>
        Public HappyoTime As MDHM    ''���\��������
        Public BataijyuInfo() As BATAIJYU_INFO ''<�n�̏d���>
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim BataijyuInfo(17)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 847
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            HappyoTime.SetDataB(MidB2B(bBuff, 28, 8))

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)
            injector.append_to_col_init("happyou_gappi_zihun")
            injector.append_to_data(HappyoTime.Month & HappyoTime.Day & HappyoTime.Hour & HappyoTime.Minute)

            For i = 0 To 17
                BataijyuInfo(i).SetDataB(MidB2B(bBuff, 36 + (45 * i), 45))
                injector.append_to_col_init("uma_ban_" & i + 1)
                injector.append_to_data(BataijyuInfo(i).Umaban)
                injector.append_to_col_init("uma_mei_" & i + 1)
                injector.append_to_data(BataijyuInfo(i).Bamei)
                injector.append_to_col_init("bataizyuu_" & i + 1)
                injector.append_to_data(BataijyuInfo(i).BaTaijyu)
                injector.append_to_col_init("zougen_hugou_" & i + 1)
                injector.append_to_data(BataijyuInfo(i).ZogenFugo)
                injector.append_to_col_init("zougen_sa_" & i + 1)
                injector.append_to_data(BataijyuInfo(i).ZogenSa)
            Next i

            injector.data_end()

            crlf = MidB2S(bBuff, 846, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �Q�P�D�V��n���� ******************************************
    Public Structure JV_WE_WEATHER
        Public head As RECORD_ID     ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID2      ''<�������ʏ��Q>
        Public HappyoTime As MDHM     ''���\��������
        Public HenkoID As String     ''�ύX����
        Public TenkoBaba As TENKO_BABA_INFO   ''���ݏ�ԏ��
        Public TenkoBabaBefore As TENKO_BABA_INFO   ''�ύX�O��ԏ��
        Public crlf As String     ''���R�[�h��؂�
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 42
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 14))
            HappyoTime.SetDataB(MidB2B(bBuff, 26, 8))
            HenkoID = MidB2S(bBuff, 34, 1)
            TenkoBaba.SetDataB(MidB2B(bBuff, 35, 3))
            TenkoBabaBefore.SetDataB(MidB2B(bBuff, 38, 3))

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("happyou_gappi_zihun")
            injector.append_to_data(HappyoTime.Month & HappyoTime.Day & HappyoTime.Hour & HappyoTime.Minute)

            injector.append_to_col_init("henkou_syubetsu")
            injector.append_to_data(HenkoID)

            injector.append_to_col_init("genzai_tenkou_zyoutai")
            injector.append_to_data(TenkoBaba.TenkoCD)
            injector.append_to_col_init("genzai_baba_zyoutai_shiba")
            injector.append_to_data(TenkoBaba.SibaBabaCD)
            injector.append_to_col_init("genzai_baba_zyoutai_dirt")
            injector.append_to_data(TenkoBaba.DirtBabaCD)

            injector.append_to_col_init("henkoumae_tenkou_zyoutai")
            injector.append_to_data(TenkoBabaBefore.TenkoCD)
            injector.append_to_col_init("henkoumae_baba_zyoutai_shiba")
            injector.append_to_data(TenkoBabaBefore.SibaBabaCD)
            injector.append_to_col_init("henkoumae_baba_zyoutai_dirt")
            injector.append_to_data(TenkoBabaBefore.DirtBabaCD)

            injector.data_end()

            crlf = MidB2S(bBuff, 41, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �Q�Q�D�o������E�������O ****************************************
    Public Structure JV_AV_INFO
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID     ''<�������ʏ��>
        Public HappyoTime As MDHM    ''���\��������
        Public Umaban As String     ''�n��
        Public Bamei As String     ''�n��
        Public JiyuKubun As String    ''���R�敪
        Public crlf As String     ''���R�[�h��؂�
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 78
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            HappyoTime.SetDataB(MidB2B(bBuff, 28, 8))
            Umaban = MidB2S(bBuff, 36, 2)
            Bamei = MidB2S(bBuff, 38, 36)
            JiyuKubun = MidB2S(bBuff, 74, 3)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)
            injector.append_to_col_init("happyou_gappi_zihun")
            injector.append_to_data(HappyoTime.Month & HappyoTime.Day & HappyoTime.Hour & HappyoTime.Minute)

            injector.append_to_col_init("uma_ban")
            injector.append_to_data(Umaban)
            injector.append_to_col_init("uma_mei")
            injector.append_to_data(Bamei)
            injector.append_to_col_init("ziyuu_kubun")
            injector.append_to_data(JiyuKubun)

            injector.data_end()

            crlf = MidB2S(bBuff, 77, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '************ �Q�R�D�R��ύX **************************************** 
    '<�ύX���>
    Public Structure JC_INFO
        Public Futan As String     ''���S�d��
        Public KisyuCode As String    ''�R��R�[�h
        Public KisyuName As String    ''�R�薼
        Public MinaraiCD As String    ''�R�茩�K�R�[�h
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Futan = MidB2S(bBuff, 1, 3)
            KisyuCode = MidB2S(bBuff, 4, 5)
            KisyuName = MidB2S(bBuff, 9, 34)
            MinaraiCD = MidB2S(bBuff, 43, 1)
        End Sub
    End Structure
    Public Structure JV_JC_INFO
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID     ''<�������ʏ��>
        Public HappyoTime As MDHM    ''���\��������
        Public Umaban As String     ''�n��
        Public Bamei As String     ''�n��
        Public JCInfoAfter As JC_INFO   ''<�ύX����>
        Public JCInfoBefore As JC_INFO   ''<�ύX�O���>
        Public crlf As String     ''���R�[�h��؂�
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 161
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            HappyoTime.SetDataB(MidB2B(bBuff, 28, 8))
            Umaban = MidB2S(bBuff, 36, 2)
            Bamei = MidB2S(bBuff, 38, 36)
            JCInfoAfter.SetDataB(MidB2B(bBuff, 74, 43))
            JCInfoBefore.SetDataB(MidB2B(bBuff, 117, 43))

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)
            injector.append_to_col_init("happyou_gappi_zihun")
            injector.append_to_data(HappyoTime.Month & HappyoTime.Day & HappyoTime.Hour & HappyoTime.Minute)

            injector.append_to_col_init("henkoumae_hutan_zyuuryou")
            injector.append_to_data(JCInfoBefore.Futan)
            injector.append_to_col_init("henkoumae_kisyu_code")
            injector.append_to_data(JCInfoBefore.KisyuCode)
            injector.append_to_col_init("henkoumae_kisyu_mei")
            injector.append_to_data(JCInfoBefore.KisyuName)
            injector.append_to_col_init("henkoumae_kisyu_minarai_code")
            injector.append_to_data(JCInfoBefore.MinaraiCD)

            injector.append_to_col_init("henkougo_hutan_zyuuryou")
            injector.append_to_data(JCInfoAfter.Futan)
            injector.append_to_col_init("henkougo_kisyu_code")
            injector.append_to_data(JCInfoAfter.KisyuCode)
            injector.append_to_col_init("henkougo_kisyu_mei")
            injector.append_to_data(JCInfoAfter.KisyuName)
            injector.append_to_col_init("henkougo_kisyu_minarai_code")
            injector.append_to_data(JCInfoAfter.MinaraiCD)

            injector.data_end()

            crlf = MidB2S(bBuff, 160, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '************ �Q�R�|�P�D���������ύX **************************************** 
    '<�ύX���>
    Public Structure TC_INFO
        Public Ji As String  ''��
        Public Fun As String  ''��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Ji = MidB2S(bBuff, 1, 2)
            Fun = MidB2S(bBuff, 3, 2)
        End Sub
    End Structure
    Public Structure JV_TC_INFO
        Public head As RECORD_ID  ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID   ''<�������ʏ��>
        Public HappyoTime As MDHM  ''���\��������
        Public TCInfoAfter As TC_INFO ''<�ύX����>
        Public TCInfoBefore As TC_INFO ''<�ύX�O���>
        Public crlf As String   ''���R�[�h��؂�
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 45
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)
            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            HappyoTime.SetDataB(MidB2B(bBuff, 28, 8))
            TCInfoAfter.SetDataB(MidB2B(bBuff, 36, 4))
            TCInfoBefore.SetDataB(MidB2B(bBuff, 40, 4))

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)
            injector.append_to_col_init("happyou_gappi_zihun")
            injector.append_to_data(HappyoTime.Month & HappyoTime.Day & HappyoTime.Hour & HappyoTime.Minute)

            injector.append_to_col_init("henkoumae_hassou_zikoku")
            injector.append_to_data(TCInfoBefore.Ji & TCInfoBefore.Fun)
            injector.append_to_col_init("henkougo_hassou_zikoku")
            injector.append_to_data(TCInfoAfter.Ji & TCInfoAfter.Fun)

            injector.data_end()

            crlf = MidB2S(bBuff, 44, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '************ �Q�R�|�Q�D�R�[�X�ύX **************************************** 
    '<�ύX���>
    Public Structure CC_INFO
        Public Kyori As String   ''����
        Public TruckCd As String  ''�g���b�N�R�[�h
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kyori = MidB2S(bBuff, 1, 4)
            TruckCd = MidB2S(bBuff, 5, 2)
        End Sub
    End Structure
    Public Structure JV_CC_INFO
        Public head As RECORD_ID  ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID   ''<�������ʏ��>
        Public HappyoTime As MDHM  ''���\��������
        Public CCInfoAfter As CC_INFO ''<�ύX����>
        Public CCInfoBefore As CC_INFO ''<�ύX�O���>
        Public JiyuCd As String   ''���R�R�[�h
        Public crlf As String   ''���R�[�h��؂�
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 50
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)
            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            HappyoTime.SetDataB(MidB2B(bBuff, 28, 8))
            CCInfoAfter.SetDataB(MidB2B(bBuff, 36, 6))
            CCInfoBefore.SetDataB(MidB2B(bBuff, 42, 6))
            JiyuCd = MidB2S(bBuff, 48, 1)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)
            injector.append_to_col_init("happyou_gappi_zihun")
            injector.append_to_data(HappyoTime.Month & HappyoTime.Day & HappyoTime.Hour & HappyoTime.Minute)

            injector.append_to_col_init("henkoumae_kyori")
            injector.append_to_data(CCInfoBefore.Kyori)
            injector.append_to_col_init("henkoumae_track_code")
            injector.append_to_data(CCInfoBefore.TruckCd)

            injector.append_to_col_init("henkougo_kyori")
            injector.append_to_data(CCInfoAfter.Kyori)
            injector.append_to_col_init("henkougo_track_code")
            injector.append_to_data(CCInfoAfter.TruckCd)

            injector.append_to_col_init("ziyuu_kubun")
            injector.append_to_data(JiyuCd)

            injector.data_end()

            crlf = MidB2S(bBuff, 49, 2)
            bBuff = Nothing
        End Sub
    End Structure


    '****** �Q�S�D�f�[�^�}�C�j���O�\�z************************************
    '<�}�C�j���O�\�z>
    Public Structure DM_INFO
        Public Umaban As String     ''�n��
        Public DMTime As String     ''�\�z���j�^�C��
        Public DMGosaP As String    ''�\�z�덷(�M���x)�{
        Public DMGosaM As String    ''�\�z�덷(�M���x)�|
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Umaban = MidB2S(bBuff, 1, 2)
            DMTime = MidB2S(bBuff, 3, 5)
            DMGosaP = MidB2S(bBuff, 8, 4)
            DMGosaM = MidB2S(bBuff, 12, 4)
        End Sub
    End Structure
    Public Structure JV_DM_INFO
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID     ''<�������ʏ��>
        Public MakeHM As HM      ''�f�[�^�쐬����
        Public DMInfo() As DM_INFO    ''<�}�C�j���O�\�z>
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim DMInfo(17)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����							
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 303
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            MakeHM.SetDataB(MidB2B(bBuff, 28, 4))

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)

            For i = 0 To 17
                DMInfo(i).SetDataB(MidB2B(bBuff, 32 + (15 * i), 15))
                injector.append_to_col_init("uma_ban_" & i + 1)
                injector.append_to_data(DMInfo(i).Umaban)
                injector.append_to_col_init("yosou_souha_time_" & i + 1)
                injector.append_to_data(DMInfo(i).DMTime)
                injector.append_to_col_init("yosou_gosa_plus_" & i + 1)
                injector.append_to_data(DMInfo(i).DMGosaP)
                injector.append_to_col_init("yosou_gosa_minus_" & i + 1)
                injector.append_to_data(DMInfo(i).DMGosaM)
            Next i

            injector.data_end()

            crlf = MidB2S(bBuff, 302, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �Q�T�D�J�ÃX�P�W���[��************************************
    '<�d�܈ē�>
    Public Structure JYUSYO_INFO
        Public TokuNum As String    ''���ʋ����ԍ�
        Public Hondai As String     ''�������{��
        Public Ryakusyo10 As String    ''����������10��
        Public Ryakusyo6 As String    ''����������6��
        Public Ryakusyo3 As String    ''����������3��
        Public Nkai As String     ''�d�܉�[��N��]
        Public GradeCD As String    ''�O���[�h�R�[�h
        Public SyubetuCD As String    ''������ʃR�[�h
        Public KigoCD As String     ''�����L���R�[�h
        Public JyuryoCD As String    ''�d�ʎ�ʃR�[�h
        Public Kyori As String     ''����
        Public TrackCD As String    ''�g���b�N�R�[�h
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            TokuNum = MidB2S(bBuff, 1, 4)
            Hondai = MidB2S(bBuff, 5, 60)
            Ryakusyo10 = MidB2S(bBuff, 65, 20)
            Ryakusyo6 = MidB2S(bBuff, 85, 12)
            Ryakusyo3 = MidB2S(bBuff, 97, 6)
            Nkai = MidB2S(bBuff, 103, 3)
            GradeCD = MidB2S(bBuff, 106, 1)
            SyubetuCD = MidB2S(bBuff, 107, 2)
            KigoCD = MidB2S(bBuff, 109, 3)
            JyuryoCD = MidB2S(bBuff, 112, 1)
            Kyori = MidB2S(bBuff, 113, 4)
            TrackCD = MidB2S(bBuff, 117, 2)
        End Sub
    End Structure
    Public Structure JV_YS_SCHEDULE
        Public head As RECORD_ID    ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID2     ''<�������ʏ��Q>
        Public YoubiCD As String    ''�j���R�[�h
        Public JyusyoInfo() As JYUSYO_INFO  ''<�d�܈ē�>
        Public crlf As String     ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim JyusyoInfo(2)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����	
            Dim bBuff As Byte()
            Dim i As Integer
            Dim bSize As Long
            bSize = 382
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 14))
            YoubiCD = MidB2S(bBuff, 26, 1)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("youbi_code")
            injector.append_to_data(YoubiCD)

            For i = 0 To 2
                JyusyoInfo(i).SetDataB(MidB2B(bBuff, 27 + (118 * i), 118))
                injector.append_to_col_init("tokubetsu_kyousou_bangou_annai_" & i + 1)
                injector.append_to_data(JyusyoInfo(i).TokuNum)
                injector.append_to_col_init("kyousoumei_hondai_annai_" & i + 1)
                injector.append_to_data(JyusyoInfo(i).Hondai)
                injector.append_to_col_init("kyousoumei_ryakusyou_10_annai_" & i + 1)
                injector.append_to_data(JyusyoInfo(i).Ryakusyo10)
                injector.append_to_col_init("kyousoumei_ryakusyou_6_annai_" & i + 1)
                injector.append_to_data(JyusyoInfo(i).Ryakusyo6)
                injector.append_to_col_init("kyousoumei_ryakusyou_3_annai_" & i + 1)
                injector.append_to_data(JyusyoInfo(i).Ryakusyo3)
                injector.append_to_col_init("zyuusyou_kaizi_annai_" & i + 1)
                injector.append_to_data(JyusyoInfo(i).Nkai)
                injector.append_to_col_init("grade_code_annai_" & i + 1)
                injector.append_to_data(JyusyoInfo(i).GradeCD)
                injector.append_to_col_init("kyousou_syubetsu_code_annai_" & i + 1)
                injector.append_to_data(JyusyoInfo(i).SyubetuCD)
                injector.append_to_col_init("kyousou_kigou_code__annai_" & i + 1)
                injector.append_to_data(JyusyoInfo(i).KigoCD)
                injector.append_to_col_init("zyuuryou_syubetsu_annai_" & i + 1)
                injector.append_to_data(JyusyoInfo(i).JyuryoCD)
                injector.append_to_col_init("kyori_annai_" & i + 1)
                injector.append_to_data(JyusyoInfo(i).Kyori)
                injector.append_to_col_init("track_code_annai_" & i + 1)
                injector.append_to_data(JyusyoInfo(i).TrackCD)
            Next i

            injector.data_end()

            crlf = MidB2S(bBuff, 381, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �Q�U�D�����n�s�������i ****************************************
    Public Structure JV_HS_SALE
        Public head As RECORD_ID         ''<���R�[�h�w�b�_�[>
        Public KettoNum As String        ''�����o�^�ԍ�
        Public HansyokuFNum As String    ''���n�ɐB�o�^�ԍ�
        Public HansyokuMNum As String    ''��n�ɐB�o�^�ԍ�
        Public BirthYear As String       ''���N
        Public SaleCode As String        ''��ÎҁE�s��R�[�h
        Public SaleHostName As String    ''��ÎҖ���
        Public SaleName As String        ''�s��̖���
        Public FromDate As YMD           ''�s��̊J�Ê���(�J�n��)
        Public ToDate As YMD             ''�s��̊J�Ê���(�I����)
        Public Barei As String          ''������̋����n�̔N��
        Public Price As String          ''������i
        Public crlf As String            ''���R�[�h��؂�
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 196
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            KettoNum = MidB2S(bBuff, 12, 10)
            HansyokuFNum = MidB2S(bBuff, 22, 8)
            HansyokuMNum = MidB2S(bBuff, 30, 8)
            BirthYear = MidB2S(bBuff, 38, 4)
            SaleCode = MidB2S(bBuff, 42, 6)
            SaleHostName = MidB2S(bBuff, 48, 40)
            SaleName = MidB2S(bBuff, 88, 80)
            FromDate.SetDataB(MidB2B(bBuff, 168, 8))
            ToDate.SetDataB(MidB2B(bBuff, 176, 8))
            Barei = MidB2S(bBuff, 184, 1)
            Price = MidB2S(bBuff, 185, 10)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kettou_touroku_bangou")
            injector.append_to_data(KettoNum)
            injector.append_to_col_init("huba_hansyoku_touroku_bangou")
            injector.append_to_data(HansyokuFNum)
            injector.append_to_col_init("boba_hansyoku_touroku_bangou")
            injector.append_to_data(HansyokuMNum)
            injector.append_to_col_init("seinen")
            injector.append_to_data(BirthYear)
            injector.append_to_col_init("syusaisya_shizyou_code")
            injector.append_to_data(SaleCode)
            injector.append_to_col_init("syusaisya_meisyou")
            injector.append_to_data(SaleHostName)
            injector.append_to_col_init("shizyou_meisyou")
            injector.append_to_data(SaleName)
            injector.append_to_col_init("shizyou_kaisai_kaishibi")
            injector.append_to_data(FromDate.Year & FromDate.Month & FromDate.Day)
            injector.append_to_col_init("shizyou_kaisei_syuuryoubi")
            injector.append_to_data(ToDate.Year & ToDate.Month & ToDate.Day)
            injector.append_to_col_init("torihikizi_kyousouba_nennrei")
            injector.append_to_data(Barei)
            injector.append_to_col_init("torihiki_kakaku")
            injector.append_to_data(Price)

            injector.data_end()

            crlf = MidB2S(bBuff, 195, 2)
            bBuff = Nothing
        End Sub
    End Structure

    ''****** �Q�V�D�n���̈Ӗ��R�� ****************************************
    Public Structure JV_HY_BAMEIORIGIN
        Public head As RECORD_ID       ''<���R�[�h�w�b�_�[>
        Public KettoNum As String      ''�����o�^�ԍ�
        Public Bamei As String         ''�n��
        Public Origin As String        ''�n���̈Ӗ��R��
        Public crlf As String          ''���R�[�h��؂�
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 123
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            KettoNum = MidB2S(bBuff, 12, 10)
            Bamei = MidB2S(bBuff, 22, 36)
            Origin = MidB2S(bBuff, 58, 64)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kettou_touroku_bangou")
            injector.append_to_data(KettoNum)
            injector.append_to_col_init("uma_mei")
            injector.append_to_data(Bamei)
            injector.append_to_col_init("uma_mei_imi_yurai_text")
            injector.append_to_data(Origin)

            injector.data_end()

            crlf = MidB2S(bBuff, 122, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �Q�W�D�o���ʒ��x�� ****************************************

    '<�o���ʒ��x�� �����n���>
    Public Structure JV_CK_UMA
        Public KettoNum As String                         ''�����o�^�ԍ�
        Public Bamei As String                            ''�n��
        Public RuikeiHonsyoHeiti As String                ''���n�{�܋��݌v
        Public RuikeiHonsyoSyogai As String               ''��Q�{�܋��݌v
        Public RuikeiFukaHeichi As String                 ''���n�t���܋��݌v
        Public RuikeiFukaSyogai As String                 ''��Q�t���܋��݌v
        Public RuikeiSyutokuHeichi As String              ''���n�����܋��݌v
        Public RuikeiSyutokuSyogai As String              ''��Q�����܋��݌v
        Public ChakuSogo As CHAKUKAISU3_INFO              ''��������
        Public ChakuChuo As CHAKUKAISU3_INFO              ''�������v����
        Public ChakuKaisuBa() As CHAKUKAISU3_INFO         ''�n��ʒ���
        Public ChakuKaisuJyotai() As CHAKUKAISU3_INFO     ''�n���ԕʒ���
        Public ChakuKaisuSibaKyori() As CHAKUKAISU3_INFO  ''�ŋ����ʒ���
        Public ChakuKaisuDirtKyori() As CHAKUKAISU3_INFO  ''�_�[�g�����ʒ���
        Public ChakuKaisuJyoSiba() As CHAKUKAISU3_INFO    ''���n��ʎŒ���
        Public ChakuKaisuJyoDirt() As CHAKUKAISU3_INFO    ''���n��ʃ_�[�g����
        Public ChakuKaisuJyoSyogai() As CHAKUKAISU3_INFO  ''���n��ʏ�Q����
        Public Kyakusitu() As String                      ''�r���X��
        Public RaceCount As String                        ''�o�^���[�X��
        '�z��̏�����
        Public Sub Initialize()
            ReDim ChakuKaisuBa(6)
            ReDim ChakuKaisuJyotai(11)
            ReDim ChakuKaisuSibaKyori(8)
            ReDim ChakuKaisuDirtKyori(8)
            ReDim ChakuKaisuJyoSiba(9)
            ReDim ChakuKaisuJyoDirt(9)
            ReDim ChakuKaisuJyoSyogai(9)
            ReDim Kyakusitu(3)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte(), injector As DBInjector)
            Initialize()      ''�z��̏�����
            KettoNum = MidB2S(bBuff, 1, 10)
            Bamei = MidB2S(bBuff, 11, 36)
            RuikeiHonsyoHeiti = MidB2S(bBuff, 47, 9)
            RuikeiHonsyoSyogai = MidB2S(bBuff, 56, 9)
            RuikeiFukaHeichi = MidB2S(bBuff, 65, 9)
            RuikeiFukaSyogai = MidB2S(bBuff, 74, 9)
            RuikeiSyutokuHeichi = MidB2S(bBuff, 83, 9)
            RuikeiSyutokuSyogai = MidB2S(bBuff, 92, 9)
            ChakuSogo.SetDataB(MidB2B(bBuff, 101, 18))
            ChakuChuo.SetDataB(MidB2B(bBuff, 119, 18))

            Dim shiba_da As String() = {"shiba_", "da_"}
            Dim shiba_da_course_type As DBInjector = injector.dependent_injectors("jvlink_baba_betsu_chakukaisuu")
            shiba_da_course_type.issue_id()
            shiba_da_course_type.append_to_col_init("chakudosuu_id")
            shiba_da_course_type.append_to_data(injector.get_id())
            For i = 0 To 5
                Dim ika As String = ""
                If i = 5 Then
                    ika = "_ika"
                End If
                injector.append_to_col_init("sougou_chakukaisuu_" & i + 1 & ika)
                injector.append_to_data(ChakuSogo.Chakukaisu(i))
                injector.append_to_col_init("tyuuou_goukei_chakukaisuu_" & i + 1 & ika)
                injector.append_to_data(ChakuChuo.Chakukaisu(i))
            Next

            Dim tyoku_migi_hidari As String() = {"tyoku_", "migi_", "hidari_"}
            Dim baba_idx As Integer = 0
            For Each shiba_da_type In shiba_da
                For Each tyoku_migi_hidari_type In tyoku_migi_hidari
                    For i = 0 To 5
                        Dim ika As String = ""
                        If i = 5 Then
                            ika = "_ika"
                        End If
                        ChakuKaisuBa(baba_idx).SetDataB(MidB2B(bBuff, 137 + 18 * i, 18))
                        shiba_da_course_type.append_to_col_init(shiba_da_type & tyoku_migi_hidari_type & i + 1 & "_chaku" & ika)
                        shiba_da_course_type.append_to_data(ChakuKaisuBa(baba_idx).Chakukaisu(i))
                    Next
                    baba_idx += 1
                Next
            Next

            ChakuKaisuBa(6).SetDataB(MidB2B(bBuff, 137 + 18 * 6, 18))

            For i = 0 To 5
                Dim ika As String = ""
                If i = 5 Then
                    ika = "_ika"
                End If
                shiba_da_course_type.append_to_col_init("syougai_" & i + 1 & "_chaku" & ika)
                shiba_da_course_type.append_to_data(ChakuKaisuBa(6).Chakukaisu(i))
            Next

            Dim shiba_da_syougai As String() = {"shiba_", "da_", "syougai_"}
            Dim conditions As String() = {"ryou_", "saya_", "omo_", "hu_"}
            Dim zyoutai_betsu As DBInjector = injector.dependent_injectors("jvlink_baba_zyoutai_betsu_chakukaisuu")
            zyoutai_betsu.issue_id()
            zyoutai_betsu.append_to_col_init("chakudosuu_id")
            zyoutai_betsu.append_to_data(injector.get_id())
            Dim zyoutai_idx As Integer = 0
            For Each shiba_da_type In shiba_da_syougai
                For Each condition In conditions
                    For i = 0 To 5
                        Dim ika As String = ""
                        If i = 5 Then
                            ika = "_ika"
                        End If
                        ChakuKaisuJyotai(zyoutai_idx).SetDataB(MidB2B(bBuff, 263 + 18 * i, 18))
                        zyoutai_betsu.append_to_col_init(shiba_da_type & condition & i + 1 & "_chaku" & ika)
                        zyoutai_betsu.append_to_data(ChakuKaisuJyotai(zyoutai_idx).Chakukaisu(i))
                    Next
                    zyoutai_idx += 1
                Next
            Next

            Dim kyori_types As String() = {
                "1200_ika_",
                "1201_1400_",
                "1401_1600_",
                "1601_1800_",
                "1801_2000_",
                "2001_2200_",
                "2201_2400_",
                "2401_2800_",
                "2801_izyou_"
            }
            Dim kyori_betsu As DBInjector = injector.dependent_injectors("jvlink_kyori_betsu_chakukaisuu")
            kyori_betsu.issue_id()
            kyori_betsu.append_to_col_init("chakudosuu_id")
            kyori_betsu.append_to_data(injector.get_id())
            Dim kyori_shiba_idx As Integer = 0
            Dim kyori_da_idx As Integer = 0
            For Each shiba_da_type In shiba_da
                For Each kyori In kyori_types
                    For i = 0 To 5
                        Dim ika As String = ""
                        If i = 5 Then
                            ika = "_ika"
                        End If
                        kyori_betsu.append_to_col_init(shiba_da_type & kyori & i + 1 & "_chaku" & ika)
                        If shiba_da_type = "shiba_" Then
                            ChakuKaisuSibaKyori(kyori_shiba_idx).SetDataB(MidB2B(bBuff, 479 + 18 * i, 18))
                            kyori_betsu.append_to_data(ChakuKaisuSibaKyori(kyori_shiba_idx).Chakukaisu(i))
                        ElseIf shiba_da_type = "da_" Then
                            ChakuKaisuDirtKyori(kyori_da_idx).SetDataB(MidB2B(bBuff, 641 + 18 * i, 18))
                            kyori_betsu.append_to_data(ChakuKaisuDirtKyori(kyori_da_idx).Chakukaisu(i))
                        End If
                    Next
                    If shiba_da_type = "shiba_" Then
                        kyori_shiba_idx += 1
                    ElseIf shiba_da_type = "da_" Then
                        kyori_da_idx += 1
                    End If
                Next
            Next

            Dim field_locations As String() = {
                "sapporo_",
                "hakodate_",
                "hukushima_",
                "niigata_",
                "toukyou_",
                "nakayama_",
                "tyuukyou_",
                "kyouto_",
                "hanshin_",
                "ogura_"
            }
            Dim jyoshiba_idx As Integer = 0
            Dim jyodirt_idx As Integer = 0
            Dim jyosyogai_idx As Integer = 0
            Dim keibazyou_betsu As DBInjector = injector.dependent_injectors("jvlink_keibazyou_betsu_chakukaisuu")
            keibazyou_betsu.issue_id()
            keibazyou_betsu.append_to_col_init("chakudosuu_id")
            keibazyou_betsu.append_to_data(injector.get_id())
            For Each shiba_da_syougai_type In shiba_da_syougai
                For Each jyo In field_locations
                    For i = 0 To 5
                        Dim ika As String = ""
                        If i = 5 Then
                            ika = "_ika"
                        End If
                        keibazyou_betsu.append_to_col_init(jyo & shiba_da_syougai_type & i + 1 & "_chaku" & ika)

                        If shiba_da_syougai_type = "shiba_" Then
                            ChakuKaisuJyoSiba(jyoshiba_idx).SetDataB(MidB2B(bBuff, 803 + 18 * i, 18))
                            keibazyou_betsu.append_to_data(ChakuKaisuJyoSiba(jyoshiba_idx).Chakukaisu(i))
                        ElseIf shiba_da_syougai_type = "da_" Then
                            ChakuKaisuJyoDirt(jyodirt_idx).SetDataB(MidB2B(bBuff, 983 + 18 * i, 18))
                            keibazyou_betsu.append_to_data(ChakuKaisuJyoDirt(jyodirt_idx).Chakukaisu(i))
                        ElseIf shiba_da_syougai_type = "syougai_" Then
                            ChakuKaisuJyoSyogai(jyosyogai_idx).SetDataB(MidB2B(bBuff, 1163 + 18 * i, 18))
                            keibazyou_betsu.append_to_data(ChakuKaisuJyoSyogai(jyosyogai_idx).Chakukaisu(i))
                        End If
                    Next
                    If shiba_da_syougai_type = "shiba_" Then
                        jyoshiba_idx += 1
                    ElseIf shiba_da_syougai_type = "dirt_" Then
                        jyodirt_idx += 1
                    ElseIf shiba_da_syougai_type = "syougai_" Then
                        jyosyogai_idx += 1
                    End If
                Next
            Next

            Dim kyakushitsu_types As String() = {
                "nige",
                "senkou",
                "sashi",
                "oikomi"
            }
            Dim kyakushitsu_idx As Integer = 0
            For Each kyakushitsu_type In kyakushitsu_types
                Kyakusitu(kyakushitsu_idx) = MidB2S(bBuff, 1343 + (3 * kyakushitsu_idx), 3)
                injector.append_to_col_init("kyakushitsu_keikou_" & kyakushitsu_type)
                injector.append_to_data(kyakushitsu_idx)
                kyakushitsu_idx += 1
            Next

            shiba_da_course_type.data_end()
            zyoutai_betsu.data_end()
            kyori_betsu.data_end()
            zyoutai_betsu.data_end()
            keibazyou_betsu.data_end()

            RaceCount = MidB2S(bBuff, 1355, 3)
            injector.append_to_col_init("touroku_race_suu")
            injector.append_to_data(RaceCount)
        End Sub
    End Structure

    '<�o���ʒ��x�� �{�N�E�݌v���я��>
    Public Structure JV_CK_HON_RUIKEISEI_INFO
        Public SetYear As String                          ''�ݒ�N
        Public HonSyokinHeichi As String                  ''���n�{�܋����v
        Public HonSyokinSyogai As String                  ''��Q�{�܋����v
        Public FukaSyokinHeichi As String                 ''���n�t���܋����v
        Public FukaSyokinSyogai As String                 ''��Q�t���܋����v
        Public ChakuKaisuSiba As CHAKUKAISU5_INFO         ''�Œ���
        Public ChakuKaisuDirt As CHAKUKAISU5_INFO         ''�_�[�g����
        Public ChakuKaisuSyogai As CHAKUKAISU4_INFO       ''��Q����
        Public ChakuKaisuSibaKyori() As CHAKUKAISU4_INFO ''�ŋ����ʒ���
        Public ChakuKaisuDirtKyori() As CHAKUKAISU4_INFO ''�_�[�g�����ʒ���
        Public ChakuKaisuJyoSiba() As CHAKUKAISU4_INFO   ''���n��ʎŒ���
        Public ChakuKaisuJyoDirt() As CHAKUKAISU4_INFO   ''���n��ʃ_�[�g����
        Public ChakuKaisuJyoSyogai() As CHAKUKAISU3_INFO ''���n��ʏ�Q����
        '�z��̏�����
        Public Sub Initialize()
            ReDim ChakuKaisuSibaKyori(8)
            ReDim ChakuKaisuDirtKyori(8)
            ReDim ChakuKaisuJyoSiba(9)
            ReDim ChakuKaisuJyoDirt(9)
            ReDim ChakuKaisuJyoSyogai(9)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte(), injector As DBInjector, prefix As String)
            Initialize()      ''�z��̏�����
            SetYear = MidB2S(bBuff, 1, 4)
            HonSyokinHeichi = MidB2S(bBuff, 5, 10)
            HonSyokinSyogai = MidB2S(bBuff, 15, 10)
            FukaSyokinHeichi = MidB2S(bBuff, 25, 10)
            FukaSyokinSyogai = MidB2S(bBuff, 35, 10)
            ChakuKaisuSiba.SetDataB(MidB2B(bBuff, 45, 30))
            ChakuKaisuDirt.SetDataB(MidB2B(bBuff, 75, 30))
            ChakuKaisuSyogai.SetDataB(MidB2B(bBuff, 105, 24))

            injector.append_to_col_init(prefix & "_" & "settei_nen")
            injector.append_to_data(SetYear)
            injector.append_to_col_init(prefix & "_" & "heichi_honsyoukin_goukei")
            injector.append_to_data(HonSyokinHeichi)
            injector.append_to_col_init(prefix & "_" & "syougai_honsyoukin_goukei")
            injector.append_to_data(HonSyokinSyogai)
            injector.append_to_col_init(prefix & "_" & "heichi_huka_syoukin_goukei")
            injector.append_to_data(FukaSyokinHeichi)
            injector.append_to_col_init(prefix & "_" & "syougai_huka_syoukin_goukei")
            injector.append_to_data(FukaSyokinSyogai)

            For i = 0 To 8
                ChakuKaisuSibaKyori(i).SetDataB(MidB2B(bBuff, 129 + 24 * i, 24))
            Next i
            For i = 0 To 8
                ChakuKaisuDirtKyori(i).SetDataB(MidB2B(bBuff, 345 + 24 * i, 24))
            Next i
            For i = 0 To 9
                ChakuKaisuJyoSiba(i).SetDataB(MidB2B(bBuff, 561 + 24 * i, 24))
            Next i
            For i = 0 To 9
                ChakuKaisuJyoDirt(i).SetDataB(MidB2B(bBuff, 801 + 24 * i, 24))
            Next i
            For i = 0 To 9
                ChakuKaisuJyoSyogai(i).SetDataB(MidB2B(bBuff, 1041 + 18 * i, 18))
            Next i

            Dim shiba_da_syougai As String() = {"shiba_", "da_", "syougai_"}
            Dim shiba_da As String() = {"shiba_", "da_"}
            Dim field_locations As String() = {
                "sapporo_",
                "hakodate_",
                "hukushima_",
                "niigata_",
                "toukyou_",
                "nakayama_",
                "tyuukyou_",
                "kyouto_",
                "hanshin_",
                "ogura_"
            }
            Dim kyori_types As String() = {
                "1200_ika_",
                "1201_1400_",
                "1401_1600_",
                "1601_1800_",
                "1801_2000_",
                "2001_2200_",
                "2201_2400_",
                "2401_2800_",
                "2801_izyou_"
            }

            For Each shiba_da_syougai_type In shiba_da_syougai
                For i = 0 To 5
                    Dim ika As String = ""
                    If i = 5 Then
                        ika = "_ika"
                    End If
                    injector.append_to_col_init(prefix & "_" & shiba_da_syougai_type & i + 1 & "_chaku" & ika)
                    If shiba_da_syougai_type = "shiba_" Then
                        injector.append_to_data(ChakuKaisuSiba.Chakukaisu(i))
                    ElseIf shiba_da_syougai_type = "da_" Then
                        injector.append_to_data(ChakuKaisuDirt.Chakukaisu(i))
                    ElseIf shiba_da_syougai_type = "syougai_" Then
                        injector.append_to_data(ChakuKaisuSyogai.Chakukaisu(i))
                    End If
                Next
            Next

            Dim kyori_idx As Integer = 0
            For Each shiba_da_type In shiba_da
                For Each kyori In kyori_types
                    For i = 0 To 5
                        Dim ika As String = ""
                        If i = 5 Then
                            ika = "_ika"
                        End If
                        injector.append_to_col_init(prefix & "_" & shiba_da_type & kyori & i + 1 & "_chaku" & ika)

                        If shiba_da_type = "shiba_" Then
                            injector.append_to_data(ChakuKaisuSibaKyori(kyori_idx).Chakukaisu(i))
                        ElseIf shiba_da_type = "da_" Then
                            injector.append_to_data(ChakuKaisuDirtKyori(kyori_idx).Chakukaisu(i))
                        End If
                    Next
                    kyori_idx += 1
                Next
                kyori_idx = 0
            Next

            Dim field_idx As Integer = 0
            For Each shiba_da_syougai_type In shiba_da_syougai
                For Each field_location In field_locations
                    For i = 0 To 5
                        Dim ika As String = ""
                        If i = 5 Then
                            ika = "_ika"
                        End If
                        injector.append_to_col_init(prefix & "_" & field_location & shiba_da_syougai_type & i + 1 & "_chaku" & ika)

                        If shiba_da_syougai_type = "shiba_" Then
                            injector.append_to_data(ChakuKaisuJyoSiba(field_idx).Chakukaisu(i))
                        ElseIf shiba_da_syougai_type = "da_" Then
                            injector.append_to_data(ChakuKaisuJyoDirt(field_idx).Chakukaisu(i))
                        ElseIf shiba_da_syougai_type = "syougai_" Then
                            injector.append_to_data(ChakuKaisuJyoSyogai(field_idx).Chakukaisu(i))
                        End If
                    Next
                    field_idx += 1
                Next
                field_idx = 0
            Next
        End Sub
    End Structure

    '<�o���ʒ��x�� �R����>
    Public Structure JV_CK_KISYU
        Public KisyuCode As String                 ''�R��R�[�h
        Public KisyuName As String                 ''�R�薼����
        Public HonRuikei() As JV_CK_HON_RUIKEISEI_INFO ''<�{�N�E�݌v���я��>
        '�z��̏�����
        Public Sub Initialize()
            ReDim HonRuikei(1)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte(), injector As DBInjector)
            Initialize()      ''�z��̏�����
            KisyuCode = MidB2S(bBuff, 1, 5)
            KisyuName = MidB2S(bBuff, 6, 34)

            Dim kisyu_betsu As DBInjector = injector.dependent_injectors("jvlink_kisyu_betsu_chakukaisuu")
            kisyu_betsu.issue_id()
            kisyu_betsu.append_to_col_init("chakudosuu_id")
            kisyu_betsu.append_to_data(injector.get_id())

            kisyu_betsu.append_to_col_init("kisyu_code")
            kisyu_betsu.append_to_data(KisyuCode)
            kisyu_betsu.append_to_col_init("kisyu_mei")
            kisyu_betsu.append_to_data(KisyuName)

            HonRuikei(0).SetDataB(MidB2B(bBuff, 40 + 1220 * 0, 1220), kisyu_betsu, "honnnen")
            HonRuikei(1).SetDataB(MidB2B(bBuff, 40 + 1220 * 1, 1220), kisyu_betsu, "ruikei")

            kisyu_betsu.data_end()
        End Sub
    End Structure

    '<�o���ʒ��x�� �����t���>
    Public Structure JV_CK_CHOKYOSI
        Public ChokyosiCode As String              ''�����t�R�[�h
        Public ChokyosiName As String              ''�����t������
        Public HonRuikei() As JV_CK_HON_RUIKEISEI_INFO ''<�{�N�E�݌v���я��>
        '�z��̏�����
        Public Sub Initialize()
            ReDim HonRuikei(1)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte(), injector As DBInjector)
            Initialize()      ''�z��̏�����
            ChokyosiCode = MidB2S(bBuff, 1, 5)
            ChokyosiName = MidB2S(bBuff, 6, 34)

            Dim tyoukyoushi_betsu As DBInjector = injector.dependent_injectors("jvlink_tyoukyoushi_betsu_chakukaisuu")
            tyoukyoushi_betsu.issue_id()
            tyoukyoushi_betsu.append_to_col_init("chakudosuu_id")
            tyoukyoushi_betsu.append_to_data(injector.get_id())

            tyoukyoushi_betsu.append_to_col_init("tyoukyoushi_code")
            tyoukyoushi_betsu.append_to_data(ChokyosiCode)
            tyoukyoushi_betsu.append_to_col_init("tyoukyoushi_mei")
            tyoukyoushi_betsu.append_to_data(ChokyosiName)

            HonRuikei(0).SetDataB(MidB2B(bBuff, 40 + 1220 * 0, 1220), tyoukyoushi_betsu, "honnnen")
            HonRuikei(1).SetDataB(MidB2B(bBuff, 40 + 1220 * 1, 1220), tyoukyoushi_betsu, "ruikei")

            tyoukyoushi_betsu.data_end()
        End Sub
    End Structure

    '<�o���ʒ��x�� �n����>
    Public Structure JV_CK_BANUSI
        Public BanusiCode As String                ''�n��R�[�h
        Public BanusiName_Co As String             ''�n�喼�i�@�l�i�L�j
        Public BanusiName As String                ''�n�喼�i�@�l�i���j
        Public HonRuikei() As SEI_RUIKEI_INFO     ''<�{�N�E�݌v���я��>
        '�z��̏�����
        Public Sub Initialize()
            ReDim HonRuikei(1)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte(), injector As DBInjector)
            Initialize()      ''�z��̏�����
            BanusiCode = MidB2S(bBuff, 1, 6)
            BanusiName_Co = MidB2S(bBuff, 7, 64)
            BanusiName = MidB2S(bBuff, 71, 64)

            Dim banushi_zyouhou As DBInjector = injector.dependent_injectors("jvlink_banushi_betsu_chakukaisuu")
            banushi_zyouhou.issue_id()

            banushi_zyouhou.append_to_col_init("chakudosuu_id")
            banushi_zyouhou.append_to_data(injector.get_id())
            banushi_zyouhou.append_to_col_init("banushi_code")
            banushi_zyouhou.append_to_data(BanusiCode)
            banushi_zyouhou.append_to_col_init("banushi_mei")
            banushi_zyouhou.append_to_data(BanusiName_Co)
            banushi_zyouhou.append_to_col_init("banushi_mei_not_houzin")
            banushi_zyouhou.append_to_data(BanusiName)

            For i = 0 To 1
                Dim prefix As String = "honnnen_"
                If i = 1 Then
                    prefix = "ruikei_"
                End If

                HonRuikei(i).SetDataB(MidB2B(bBuff, 135 + 60 * i, 60))
                banushi_zyouhou.append_to_col_init(prefix & "settei_nen")
                banushi_zyouhou.append_to_data(HonRuikei(i).SetYear)
                banushi_zyouhou.append_to_col_init(prefix & "honsyoukin_goukei")
                banushi_zyouhou.append_to_data(HonRuikei(i).HonSyokinTotal)
                banushi_zyouhou.append_to_col_init(prefix & "huka_syoukin_goukei")
                banushi_zyouhou.append_to_data(HonRuikei(i).FukaSyokin)
                For j = 0 To 5
                    Dim ika As String = ""
                    If j = 5 Then
                        ika = "_ika"
                    End If
                    banushi_zyouhou.append_to_col_init(prefix & j + 1 & "_chaku" & ika)
                    banushi_zyouhou.append_to_data(HonRuikei(i).ChakuKaisu(j))
                Next

            Next

            banushi_zyouhou.data_end()

        End Sub
    End Structure

    '<�o���ʒ��x�� ���Y�ҏ��>
    Public Structure JV_CK_BREEDER
        Public BreederCode As String               ''���Y�҃R�[�h
        Public BreederName_Co As String            ''���Y�Җ��i�@�l�i�L�j
        Public BreederName As String               ''���Y�Җ��i�@�l�i���j
        Public HonRuikei() As SEI_RUIKEI_INFO     ''<�{�N�E�݌v���я��>
        '�z��̏�����
        Public Sub Initialize()
            ReDim HonRuikei(1)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte(), injector As DBInjector)
            Initialize()      ''�z��̏�����
            BreederCode = MidB2S(bBuff, 1, 6)
            BreederName_Co = MidB2S(bBuff, 7, 70)
            BreederName = MidB2S(bBuff, 77, 70)

            Dim seisansya_zyouhou As DBInjector = injector.dependent_injectors("jvlink_seisansya_betsu_chakukaisuu")
            seisansya_zyouhou.issue_id()

            seisansya_zyouhou.append_to_col_init("chakudosuu_id")
            seisansya_zyouhou.append_to_data(injector.get_id())
            seisansya_zyouhou.append_to_col_init("seisansya_code")
            seisansya_zyouhou.append_to_data(BreederCode)
            seisansya_zyouhou.append_to_col_init("seisansya_mei")
            seisansya_zyouhou.append_to_data(BreederName_Co)
            seisansya_zyouhou.append_to_col_init("seisansya_mei_not_houzin")
            seisansya_zyouhou.append_to_data(BreederName)

            For i = 0 To 1
                Dim prefix As String = "honnnen_"
                If i = 1 Then
                    prefix = "ruikei_"
                End If

                HonRuikei(i).SetDataB(MidB2B(bBuff, 135 + 60 * i, 60))
                seisansya_zyouhou.append_to_col_init(prefix & "settei_nen")
                seisansya_zyouhou.append_to_data(HonRuikei(i).SetYear)
                seisansya_zyouhou.append_to_col_init(prefix & "honsyoukin_goukei")
                seisansya_zyouhou.append_to_data(HonRuikei(i).HonSyokinTotal)
                seisansya_zyouhou.append_to_col_init(prefix & "huka_syoukin_goukei")
                seisansya_zyouhou.append_to_data(HonRuikei(i).FukaSyokin)
                For j = 0 To 5
                    Dim ika As String = ""
                    If j = 5 Then
                        ika = "_ika"
                    End If
                    seisansya_zyouhou.append_to_col_init(prefix & j + 1 & "_chaku" & ika)
                    seisansya_zyouhou.append_to_data(HonRuikei(i).ChakuKaisu(j))
                Next

            Next

            seisansya_zyouhou.data_end()

        End Sub
    End Structure

    Public Structure JV_CK_CHAKU
        Public head As RECORD_ID                   ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID                       ''<�������ʏ��P>
        Public UmaChaku As JV_CK_UMA               ''<�o���ʒ��x�� �����n���>
        Public KisyuChaku As JV_CK_KISYU           ''<�o���ʒ��x�� �R����>
        Public ChokyoChaku As JV_CK_CHOKYOSI       ''<�o���ʒ��x�� �����t���>
        Public BanusiChaku As JV_CK_BANUSI         ''<�o���ʒ��x�� �n����>
        Public BreederChaku As JV_CK_BREEDER       ''<�o���ʒ��x�� ���Y�ҏ��>
        Public crlf As String                      ''���R�[�h��؂�
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 6864
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            UmaChaku.SetDataB(MidB2B(bBuff, 28, 1357), injector)

            injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)
            injector.append_to_col_init("kettou_touroku_bangou")
            injector.append_to_data(UmaChaku.KettoNum)
            injector.append_to_col_init("uma_mei")
            injector.append_to_data(UmaChaku.Bamei)
            injector.append_to_col_init("heichi_honsyoukin_ruikei")
            injector.append_to_data(UmaChaku.RuikeiHonsyoHeiti)
            injector.append_to_col_init("syougai_honsyoukin_ruikei")
            injector.append_to_data(UmaChaku.RuikeiHonsyoSyogai)
            injector.append_to_col_init("heichi_huka_syoukin_ruikei")
            injector.append_to_data(UmaChaku.RuikeiFukaHeichi)
            injector.append_to_col_init("syougai_huka_syoukin_ruikei")
            injector.append_to_data(UmaChaku.RuikeiFukaSyogai)
            injector.append_to_col_init("heichi_syuutoku_syoukin_ruikei")
            injector.append_to_data(UmaChaku.RuikeiSyutokuHeichi)
            injector.append_to_col_init("syougai_syuutoku_syoukin_ruikei")
            injector.append_to_data(UmaChaku.RuikeiSyutokuSyogai)

            KisyuChaku.SetDataB(MidB2B(bBuff, 1385, 2479), injector)
            ChokyoChaku.SetDataB(MidB2B(bBuff, 3864, 2479), injector)
            BanusiChaku.SetDataB(MidB2B(bBuff, 6343, 254), injector)
            BreederChaku.SetDataB(MidB2B(bBuff, 6597, 266), injector)

            injector.data_end()

            crlf = MidB2S(bBuff, 6863, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �Q�X�D�n����� ****************************************
    Public Structure JV_BT_KEITO
        Public head As RECORD_ID       ''<���R�[�h�w�b�_�[>
        Public HansyokuNum As String   ''�ɐB�o�^�ԍ�
        Public KeitoId As String       ''�n��ID
        Public KeitoName As String     ''�n����
        Public KeitoEx As String       ''�n������
        Public crlf As String          ''���R�[�h��؂�
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 6887
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            HansyokuNum = MidB2S(bBuff, 12, 8)
            KeitoId = MidB2S(bBuff, 20, 30)
            KeitoName = MidB2S(bBuff, 50, 36)
            KeitoEx = MidB2S(bBuff, 86, 6800)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("hansyoku_touroku_bangou")
            injector.append_to_data(HansyokuNum)
            injector.append_to_col_init("keitou_ID")
            injector.append_to_data(KeitoId)
            injector.append_to_col_init("keitou_mei")
            injector.append_to_data(KeitoName)
            injector.append_to_col_init("keitou_setsumei")
            injector.append_to_data(KeitoEx)

            injector.data_end()

            crlf = MidB2S(bBuff, 6886, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �R�O�D�R�[�X��� ****************************************
    Public Structure JV_CS_COURSE
        Public head As RECORD_ID       ''<���R�[�h�w�b�_�[>
        Public JyoCD As String         ''���n��R�[�h
        Public Kyori As String         ''����
        Public TrackCD As String       ''�g���b�N�R�[�h
        Public KaishuDate As YMD       ''�R�[�X���C�N����
        Public CourseEx As String      ''�R�[�X����
        Public crlf As String          ''���R�[�h��؂�
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 6829
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            JyoCD = MidB2S(bBuff, 12, 2)
            Kyori = MidB2S(bBuff, 14, 4)
            TrackCD = MidB2S(bBuff, 18, 2)
            KaishuDate.SetDataB(MidB2B(bBuff, 20, 8))
            CourseEx = MidB2S(bBuff, 28, 6800)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(JyoCD)
            injector.append_to_col_init("kyori")
            injector.append_to_data(Kyori)
            injector.append_to_col_init("track_code")
            injector.append_to_data(TrackCD)
            injector.append_to_col_init("course_kaisyuu_nen_gappi")
            injector.append_to_data(KaishuDate.Year & KaishuDate.Month & KaishuDate.Day)
            injector.append_to_col_init("course_setsumei")
            injector.append_to_data(CourseEx)

            injector.data_end()

            crlf = MidB2S(bBuff, 6828, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �R�P�D�ΐ�^�f�[�^�}�C�j���O�\�z************************************
    '<�}�C�j���O�\�z>
    Public Structure TM_INFO
        Public Umaban As String    ''�n��
        Public TMScore As String    ''�\���X�R�A
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Umaban = MidB2S(bBuff, 1, 2)
            TMScore = MidB2S(bBuff, 3, 4)
        End Sub
    End Structure
    Public Structure JV_TM_INFO
        Public head As RECORD_ID      ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID          ''<�������ʏ��>
        Public MakeHM As HM           ''�f�[�^�쐬����
        Public TMInfo() As TM_INFO    ''<�}�C�j���O�\�z>
        Public crlf As String         ''���R�[�h��؂�
        '�z��̏�����
        Public Sub Initialize()
            ReDim TMInfo(17)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����							
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 141
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            MakeHM.SetDataB(MidB2B(bBuff, 28, 4))

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)
            injector.append_to_col_init("data_sakusei_zihun")
            injector.append_to_data(MakeHM.Hour & MakeHM.Minute)

            For i = 0 To 17
                TMInfo(i).SetDataB(MidB2B(bBuff, 32 + (6 * i), 6))
                injector.append_to_col_init("uma_ban_" & i + 1)
                injector.append_to_data(TMInfo(i).Umaban)
                injector.append_to_col_init("yosou_score_" & i + 1)
                injector.append_to_data(TMInfo(i).TMScore)
            Next i

            injector.data_end()

            crlf = MidB2S(bBuff, 140, 2)
            bBuff = Nothing
        End Sub
    End Structure

    '****** �R�Q�D�d����(WIN5)************************************
    '<�d�����Ώۃ��[�X���>
    Public Structure WF_RACE_INFO
        Public JyoCD As String     ''���n��R�[�h
        Public Kaiji As String     ''�J�É�[��N��]
        Public Nichiji As String   ''�J�Ó���[N����]
        Public RaceNum As String   ''���[�X�ԍ�
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            JyoCD = MidB2S(bBuff, 1, 2)
            Kaiji = MidB2S(bBuff, 3, 2)
            Nichiji = MidB2S(bBuff, 5, 2)
            RaceNum = MidB2S(bBuff, 7, 2)
        End Sub
    End Structure

    '<�L���[�����>
    Public Structure WF_YUKO_HYO_INFO
        Public Yuko_Hyo As String     ''�L���[��
        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Yuko_Hyo = MidB2S(bBuff, 1, 11)
        End Sub
    End Structure

    '<�d�������ߏ��>
    Public Structure WF_PAY_INFO
        Public Kumiban As String     ''�g��
        Public Pay As String         ''�d�������ߋ�
        Public Tekichu_Hyo As String ''�I���[��

        '�f�[�^�Z�b�g
        Public Sub SetDataB(ByVal bBuff As Byte())
            Kumiban = MidB2S(bBuff, 1, 10)
            Pay = MidB2S(bBuff, 11, 9)
            Tekichu_Hyo = MidB2S(bBuff, 20, 10)

        End Sub
    End Structure

    Public Structure JV_WF_INFO
        Public head As RECORD_ID                   ''<���R�[�h�w�b�_�[>
        Public KaisaiDate As YMD                   ''�J�ÔN����
        Public reserved1 As String                 ''�\��
        Public WFRaceInfo() As WF_RACE_INFO        ''<�d�����Ώۃ��[�X���>
        Public reserved2 As String                 ''�\��
        Public Hatsubai_Hyo As String              ''�d���������[��
        Public WFYukoHyoInfo() As WF_YUKO_HYO_INFO ''<�L���[�����>
        Public HenkanFlag As String                ''�Ԋ҃t���O
        Public FuseiritsuFlag As String            ''�s�����t���O
        Public TekichunashiFlag As String          ''�I�����t���O
        Public COShoki As String                   ''�L�����[�I�[�o�[���z����
        Public COZanDaka As String                 ''�L�����[�I�[�o�[���z�c��
        Public WFPayInfo() As WF_PAY_INFO          ''<�d�������ߏ��>
        Public crlf As String                      ''���R�[�h��؂�

        '�z��̏�����
        Public Sub Initialize()
            ReDim WFRaceInfo(4)
            ReDim WFYukoHyoInfo(4)
            ReDim WFPayInfo(242)
        End Sub
        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Initialize()      ''�z��̏�����
            Dim i As Integer
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 7215
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            KaisaiDate.SetDataB(MidB2B(bBuff, 12, 8))
            reserved1 = MidB2S(bBuff, 20, 2)

            Dim current_record_id As Integer = injector.issue_id()


            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(KaisaiDate.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(KaisaiDate.Month & KaisaiDate.Day)
            injector.append_to_col_init("yobi_1")
            injector.append_to_data(reserved1)

            For i = 0 To 4
                WFRaceInfo(i).SetDataB(MidB2B(bBuff, 22 + (8 * i), 8))
                injector.append_to_col_init("race_" & i + 1 & "_keibazyou_code")
                injector.append_to_data(WFRaceInfo(i).JyoCD)
                injector.append_to_col_init("race_" & i + 1 & "_kaisai_kai")
                injector.append_to_data(WFRaceInfo(i).Kaiji)
                injector.append_to_col_init("race_" & i + 1 & "_kaisai_nichime")
                injector.append_to_data(WFRaceInfo(i).Nichiji)
                injector.append_to_col_init("race_" & i + 1 & "_race_bangou")
                injector.append_to_data(WFRaceInfo(i).RaceNum)
            Next i

            reserved2 = MidB2S(bBuff, 62, 6)
            Hatsubai_Hyo = MidB2S(bBuff, 68, 11)

            injector.append_to_col_init("yobi_2")
            injector.append_to_data(reserved2)
            injector.append_to_col_init("zyuusyoushiki_hatsubai_hyousuu")
            injector.append_to_data(Hatsubai_Hyo)

            For i = 0 To 4
                WFYukoHyoInfo(i).SetDataB(MidB2B(bBuff, 79 + (11 * i), 11))
                injector.append_to_col_init("race_" & i + 1 & "_yuukou_hyousuu")
                injector.append_to_data(WFYukoHyoInfo(i).Yuko_Hyo)
            Next i

            HenkanFlag = MidB2S(bBuff, 134, 1)
            FuseiritsuFlag = MidB2S(bBuff, 135, 1)
            TekichunashiFlag = MidB2S(bBuff, 136, 1)
            COShoki = MidB2S(bBuff, 137, 15)
            COZanDaka = MidB2S(bBuff, 152, 15)

            injector.append_to_col_init("henkan_flag")
            injector.append_to_data(HenkanFlag)
            injector.append_to_col_init("huseritsu_flag")
            injector.append_to_data(FuseiritsuFlag)
            injector.append_to_col_init("tekityuu_nashi_flag")
            injector.append_to_data(TekichunashiFlag)
            injector.append_to_col_init("carry_over_kingaku_syoki")
            injector.append_to_data(COShoki)
            injector.append_to_col_init("carry_over_kingaku_zandaka")
            injector.append_to_data(COZanDaka)

            injector.data_end()

            Dim haraimodoshi As DBInjector = injector.dependent_injectors("jvlink_zyuusyoushiki_win5_haraimodoshi")

            For i = 0 To 242
                WFPayInfo(i).SetDataB(MidB2B(bBuff, 167 + (29 * i), 29))
                haraimodoshi.issue_id()

                haraimodoshi.append_to_col_init("zyuusyoushiki_win5_id")
                haraimodoshi.append_to_data(current_record_id, True)

                haraimodoshi.append_to_col_init("kumi_ban")
                haraimodoshi.append_to_data(WFPayInfo(i).Kumiban)
                haraimodoshi.append_to_col_init("zyuusyoushiki_haraimodoshikin")
                haraimodoshi.append_to_data(WFPayInfo(i).Pay)
                haraimodoshi.append_to_col_init("tekityuu_hyousuu")
                haraimodoshi.append_to_data(WFPayInfo(i).Tekichu_Hyo)

                haraimodoshi.data_end()
            Next i

            crlf = MidB2S(bBuff, 7214, 2)
            bBuff = Nothing

        End Sub
    End Structure

    '****** �R�R�D�����n���O���************************************
    Public Structure JV_JG_JOGAIBA
        Public head As RECORD_ID            ''<���R�[�h�w�b�_�[>
        Public id As RACE_ID                ''<�������ʏ��>
        Public KettoNum As String           ''�����o�^�ԍ�
        Public Bamei As String              ''�n��
        Public ShutsubaTohyoJun As String   ''�o�n���[��t����
        Public ShussoKubun As String        ''�o���敪
        Public JogaiJotaiKubun As String    ''���O��ԋ敪
        Public crlf As String               ''���R�[�h��؂�

        '�f�[�^�Z�b�g
        Public Sub SetData(ByRef strBuff As String, injector As DBInjector)
            Dim bBuff As Byte()
            Dim bSize As Long
            bSize = 80
            bBuff = New Byte(bSize) {}
            bBuff = Str2Byte(strBuff)

            head.SetDataB(MidB2B(bBuff, 1, 11))
            id.SetDataB(MidB2B(bBuff, 12, 16))
            KettoNum = MidB2S(bBuff, 28, 10)
            Bamei = MidB2S(bBuff, 38, 36)
            ShutsubaTohyoJun = MidB2S(bBuff, 74, 3)
            ShussoKubun = MidB2S(bBuff, 77, 1)
            JogaiJotaiKubun = MidB2S(bBuff, 78, 1)

            Dim current_record_id As Integer = injector.issue_id()

            injector.append_to_col_init("record_syubetsu_id")
            injector.append_to_data(head.RecordSpec)
            injector.append_to_col_init("data_kubun")
            injector.append_to_data(head.DataKubun)
            injector.append_to_col_init("data_sakusei_nen_gappi")
            injector.append_to_data(head.MakeDate.Year & head.MakeDate.Month & head.MakeDate.Day)

            injector.append_to_col_init("kaisai_nen")
            injector.append_to_data(id.Year)
            injector.append_to_col_init("kaisai_gappi")
            injector.append_to_data(id.MonthDay)
            injector.append_to_col_init("keibazyou_code")
            injector.append_to_data(id.JyoCD)
            injector.append_to_col_init("kaisai_kai")
            injector.append_to_data(id.Kaiji)
            injector.append_to_col_init("kaisai_nichime")
            injector.append_to_data(id.Nichiji)
            injector.append_to_col_init("race_bangou")
            injector.append_to_data(id.RaceNum)
            injector.append_to_col_init("kettou_touroku_bangou")
            injector.append_to_data(KettoNum)
            injector.append_to_col_init("uma_mei")
            injector.append_to_data(Bamei)
            injector.append_to_col_init("syutsuba_touhyou_uketsuke_zyunban")
            injector.append_to_data(ShutsubaTohyoJun)
            injector.append_to_col_init("syussou_kubun")
            injector.append_to_data(ShussoKubun)
            injector.append_to_col_init("zyogai_zyoutai_kubun")
            injector.append_to_data(JogaiJotaiKubun)

            injector.data_end()

            crlf = MidB2S(bBuff, 79, 2)
            bBuff = Nothing
        End Sub
    End Structure

    Class DBInjectorManager
        Public strDataSpec As String
        Public strFromTime As String = ""
        Private conn As MySqlConnection
        Private conn_for_injector As MySqlConnection
        Public injectors As Hashtable = New Hashtable From {}
        Public IOption

        Sub New(conn_val As MySqlConnection, conn_for_injector_val As MySqlConnection, strDataSpec_val As String, IOption_val As String)
            strDataSpec = strDataSpec_val
            conn = conn_val
            conn_for_injector = conn_for_injector_val
            IOption = IOption_val
            init_fromtime()
        End Sub

        Private Function init_fromtime()
            Dim q As String = "SELECT fromtime FROM jvlink_fromtime_management WHERE str_data_spec='" & strDataSpec & "';"

            Using dr As MySqlDataReader = New MySqlCommand(q, conn).ExecuteReader()
                While (dr.Read())
                    strFromTime = dr("fromtime")
                End While
            End Using

            If strFromTime = "" Then
                strFromTime = "19860101000000"
            End If

        End Function

        Public Function set_fromtime(fromtime_val As String)
            Dim q_settime = "INSERT INTO jvlink_fromtime_management VALUES ('" & strDataSpec & "', '" & fromtime_val &
                "') ON DUPLICATE KEY UPDATE fromtime='" & fromtime_val & "';"
            Dim settime_cmd = New MySqlCommand(q_settime, conn)
            settime_cmd.ExecuteNonQuery()
            set_injectors()
        End Function

        Private Function set_injectors()
            Dim q As String = "SELECT * FROM jvlink_table_master WHERE str_data_spec='" & strDataSpec & "' AND IOption='" & IOption & "';"
            If IOption = "3" Or IOption = "4" Then
                q = "SELECT * FROM jvlink_table_master WHERE str_data_spec='" & strDataSpec & "' AND IOption='1';"
            End If

            Using dr As MySqlDataReader = New MySqlCommand(q, conn).ExecuteReader()
                While (dr.Read())
                    injectors(dr("record_syubetsu_id")) = New DBInjector(conn_for_injector, dr("table_name"), IOption)
                End While
            End Using
        End Function

    End Class

    Class DBInjector
        Private conn As MySqlConnection
        Private insert_volume As Integer = 1

        Public parent_injector As DBInjector
        Public is_insert_successed As Boolean = True
        Private is_dependent_table As Boolean = False

        Public dependent_injectors As Hashtable = New Hashtable From {}

        Public table_name As String = ""

        Public strDataSpec As String
        Public recordSyubetsuId As String
        Public IOption As String
        Public targetDataStructure

        Private current_id As Integer = 0

        Private col_init As String = ""
        Private columns As String = ""

        Private data As String = ""
        Private data_count As Integer = 0
        Private data_set As String = ""

        Sub New(conn_val As MySqlConnection, table_name_val As String, IOption_val As String, Optional dep_flag As Boolean = False, Optional parent_injector_val As DBInjector = Nothing)
            conn = conn_val
            is_dependent_table = dep_flag

            table_name = table_name_val
            current_id = get_latest_id_from_db()

            If Not is_dependent_table Then
                IOption = IOption_val

                Dim dataspec_query As String = "SELECT * FROM jvlink_table_master WHERE IOption='" & IOption & "' AND table_name='" & table_name & "';"
                If IOption = "3" Or IOption = "4" Then
                    dataspec_query = "SELECT * FROM jvlink_table_master WHERE IOption='1' AND table_name='" & table_name & "';"
                End If

                Using dr As MySqlDataReader = New MySqlCommand(dataspec_query, conn).ExecuteReader()
                    While (dr.Read())
                        strDataSpec = CStr(dr("str_data_spec"))
                        recordSyubetsuId = CStr(dr("record_syubetsu_id"))
                    End While
                End Using

                Dim dep_query As String = "SELECT table_name FROM jvlink_table_master WHERE parent_table_name='" & table_name & "';"
                Using dr As MySqlDataReader = New MySqlCommand(dep_query, conn).ExecuteReader()
                    While (dr.Read())
                        dependent_injectors(dr("table_name")) = New DBInjector(conn, dr("table_name"), Nothing, True, Me)
                    End While
                End Using

                targetDataStructure = set_target_datastructure()
            Else
                parent_injector = parent_injector_val
            End If
        End Sub

        Private Function has_columns()
            Return columns.Length > 0
        End Function

        Public Function append_to_col_init(column As String)
            If Not has_columns() Then
                col_init += column & ", "
            End If
        End Function

        Public Function issue_id()
            current_id += 1
            Return current_id
        End Function

        Public Function get_id()
            Return current_id
        End Function

        Public Function append_to_data(append_data As String, Optional is_int As Boolean = False)
            If is_int Then
                data += append_data & ", "
            Else
                data += "'" & append_data.Replace("'", """") & "', "
            End If
        End Function

        Public Function data_end()
            '�e�e�[�u���̏ꍇ�͖������Ŏ��s
            If Not is_dependent_table Then
                '�O��insert��False�������ꍇ�̂���True���Z�b�g
                is_insert_successed = True
                build_insert_data_for_query()
                insert_data()
            End If

            '�e�e�[�u����insert���������Ă����ꍇ�̂ݎq�e�[�u����insert�����s
            If is_dependent_table Then
                If parent_injector.is_insert_successed Then
                    build_insert_data_for_query()
                    insert_data()
                Else
                    '���s���Ă����ꍇ�̓f�[�^���N���A
                    data = ""
                End If
            End If

        End Function

        Private Function build_insert_data_for_query()
            If Not has_columns() Then
                columns = "(id, " & col_init.Substring(0, col_init.Length - 2) & ")"
            End If

            If data <> "" Then
                data = data.Substring(0, data.Length - 2)
                data_set += "(" & current_id & ", " & data & "),"
                data_count += 1
                data = ""
            End If
        End Function

        Public Function insert_data()
            Dim q As String = "SET SESSION innodb_strict_mode=OFF;INSERT INTO " & table_name & " " & columns & " VALUES " & data_set
            mod_suffix_and_execute_query(q)
        End Function

        Public Function bulk_insert_data()
            Dim q As String = "SET SESSION innodb_strict_mode=OFF;INSERT IGNORE INTO " & table_name & " " & columns & " VALUES " & data_set
            mod_suffix_and_execute_query(q)
        End Function

        Public Function bulk_replace_data()
            Dim q As String = "SET SESSION innodb_strict_mode=OFF;REPLACE " & table_name & " " & columns & " VALUES " & data_set
            mod_suffix_and_execute_query(q)
        End Function

        Private Function mod_suffix_and_execute_query(q)
            q = q.Substring(0, q.Length - 2) & ");"

            If data_set.Length <> 0 Then
                Dim cmd = New MySqlCommand(q, conn)
                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                dr.Close()
            End If

            data_set = ""
            data_count = 0

        End Function

        Private Function get_latest_id_from_db()
            Dim q As String = "SELECT COUNT(id) FROM " & table_name & ";"
            Dim cmd As MySqlCommand = New MySqlCommand(q, conn)

            Try
                Return cmd.ExecuteScalar()
            Catch ex As Exception
                Return 0
            End Try

        End Function

        Private Function set_target_datastructure()
            Select Case recordSyubetsuId
                Case "TK"
                    Return New JV_TK_TOKUUMA
                Case "RA"
                    Return New JV_RA_RACE
                Case "SE"
                    Return New JV_SE_RACE_UMA
                Case "HR"
                    Return New JV_HR_PAY
                Case "H1"
                    Return New JV_H1_HYOSU_ZENKAKE
                Case "H6"
                    Return New JV_H6_HYOSU_SANRENTAN
                Case "O1"
                    Return New JV_O1_ODDS_TANFUKUWAKU
                Case "O2"
                    Return New JV_O2_ODDS_UMAREN
                Case "O3"
                    Return New JV_O3_ODDS_WIDE
                Case "O4"
                    Return New JV_O4_ODDS_UMATAN
                Case "O5"
                    Return New JV_O5_ODDS_SANREN
                Case "O6"
                    Return New JV_O6_ODDS_SANRENTAN
                Case "WF"
                    Return New JV_WF_INFO
                Case "JG"
                    Return New JV_JG_JOGAIBA
                Case "UM"
                    Return New JV_UM_UMA
                Case "KS"
                    Return New JV_KS_KISYU
                Case "CH"
                    Return New JV_CH_CHOKYOSI
                Case "BR"
                    Return New JV_BR_BREEDER
                Case "BN"
                    Return New JV_BN_BANUSI
                Case "RC"
                    Return New JV_RC_RECORD
                Case "HN"
                    Return New JV_HN_HANSYOKU
                Case "SK"
                    Return New JV_SK_SANKU
                Case "BT"
                    Return New JV_BT_KEITO
                Case "DM"
                    Return New JV_DM_INFO
                Case "TM"
                    Return New JV_TM_INFO
                Case "CK"
                    Return New JV_CK_CHAKU
                Case "HC"
                    Return New JV_HC_HANRO
                Case "YS"
                    Return New JV_YS_SCHEDULE
                Case "HS"
                    Return New JV_HS_SALE
                Case "HY"
                    Return New JV_HY_BAMEIORIGIN
                Case "CS"
                    Return New JV_CS_COURSE

                Case "WE"
                    Return New JV_WE_WEATHER
                Case "AV"
                    Return New JV_AV_INFO
                Case "JC"
                    Return New JV_JC_INFO
                Case "TC"
                    Return New JV_TC_INFO
                Case "CC"
                    Return New JV_CC_INFO
            End Select
        End Function

    End Class

End Module
