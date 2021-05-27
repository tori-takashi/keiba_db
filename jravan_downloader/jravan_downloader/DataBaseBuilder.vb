Imports MySql.Data.MySqlClient

Public Class DataBaseBuilder
    Dim database As String = "MySQL"
    Dim conn As MySqlConnection

    Sub New(conn_val As MySqlConnection)
        conn = conn_val
    End Sub

    Public Function build_database(db_name As String)
        Dim query As String = "CREATE DATABASE " & db_name &
            ";SET GLOBAL max_allowed_packet=1073741824;"
        Dim cmd = New MySqlCommand(query, conn)
        Dim dr As MySqlDataReader = cmd.ExecuteReader()
        dr.Close()
    End Function

    Public Function build_tables()
        build_table_fromtime_management()
        build_table_table_master()

        build_table_tokubetsu_tourokuba()
        build_table_race_details()
        build_table_race_info_by_horse()

        build_table_haraimodosi()

        build_table_hyousuu1()
        build_table_hyousuu6()

        build_table_odds1()
        build_table_odds2()
        build_table_odds3()
        build_table_odds4()
        build_table_odds5()
        build_table_odds6()

        build_table_horses_master()
        build_table_riders_master()
        build_table_teachers_master()
        build_table_breeders_master()
        build_table_horse_owners_master()
        build_table_male_breeding_horses_master()
        build_table_female_breeding_horses_master()

        build_table_syussoubetu_chakudosuu()
        build_table_record_master()
        build_table_sakamiti_tyoukyou()
        build_table_horse_market_trade_price()
        build_table_name_meanings()
        build_table_race_schedule()

        build_table_keitou_information()
        build_table_course_information()

        build_table_mining_prediction_with_time()
        build_table_mining_prediction_with_race()

        build_table_zyuusyousiki()
        build_table_excluded_horses_information()
        build_table_bataizyuu()
        build_table_weather_field_conditions()
        build_table_syussou_torikesi_kyousou_jogai()

        build_table_kisyuhenkou()
        build_table_hassouzikoku_henkou()
        build_table_course_henkou()

    End Function

    Private Function build_table_fromtime_management()
        Dim query = "CREATE TABLE IF NOT EXISTS jvlink_fromtime_management (
str_data_spec CHAR(4) UNIQUE,
fromtime CHAR(14)
);"
        query = query.Replace(Chr(13), "").Replace(Chr(10), "")
        execute_query(query)
    End Function

    Private Function build_table_table_master()

        Dim query = "CREATE TABLE IF NOT EXISTS jvlink_table_master (
IOption CHAR(1),
parent_table_name VARCHAR(100),
table_name VARCHAR(100) NOT NULL,
str_data_spec CHAR(4),
record_syubetsu_id CHAR(2)
);
INSERT INTO jvlink_table_master VALUES 
('1', '', 'jvlink_tokubetsu_tourokuba', 'TOKU', 'TK'),
('1', 'jvlink_tokubetsu_tourokuba', 'jvlink_tourokuba_goto_zyouhou','',''),
('1', '', 'jvlink_race_syousai', 'RACE', 'RA'),
('1', 'jvlink_race_syousai', 'jvlink_corner_tsuuka_zyunni','',''),
('1', '', 'jvlink_uma_goto_race_zyouhou', 'RACE', 'SE'),
('1', '', 'jvlink_haraimodoshi', 'RACE', 'HR'),
('1', '', 'jvlink_hyousuu_1', 'RACE', 'H1'),
('', 'jvlink_hyousuu_1','jvlink_hyousuu_1_tansyou','',''),
('', 'jvlink_hyousuu_1','jvlink_hyousuu_1_hukusyou','',''),
('', 'jvlink_hyousuu_1','jvlink_hyousuu_1_waku_ren','',''),
('', 'jvlink_hyousuu_1','jvlink_hyousuu_1_uma_ren','',''),
('', 'jvlink_hyousuu_1','jvlink_hyousuu_1_wide','',''),
('', 'jvlink_hyousuu_1','jvlink_hyousuu_1_uma_tan','',''),
('', 'jvlink_hyousuu_1','jvlink_hyousuu_1_3renpuku','',''),
('1', '', 'jvlink_hyousuu_6', 'RACE', 'H6'),
('', 'jvlink_hyousuu_6','jvlink_hyousuu_6_3rentan','',''),
('1', '', 'jvlink_odds_1', 'RACE', 'O1'),
('', 'jvlink_odds_1','jvlink_odds_1_tansyou_odds','',''),
('', 'jvlink_odds_1','jvlink_odds_1_hukusyou_odds','',''),
('', 'jvlink_odds_1','jvlink_odds_1_waku_ren_odds','',''),
('1', '', 'jvlink_odds_2_uma_ren', 'RACE', 'O2'),
('', 'jvlink_odds_2_uma_ren','jvlink_odds_2_uma_ren_odds','',''),
('1', '', 'jvlink_odds_3_wide', 'RACE', 'O3'),
('', 'jvlink_odds_3_wide','jvlink_odds_3_wide_odds','',''),
('1', '', 'jvlink_odds_4_uma_tan', 'RACE', 'O4'),
('', 'jvlink_odds_4_uma_tan','jvlink_odds_4_uma_tan_odds','',''),
('1', '', 'jvlink_odds_5_3renpuku', 'RACE', 'O5'),
('', 'jvlink_odds_5_3renpuku','jvlink_odds_5_3renpuku_odds','',''),
('1', '', 'jvlink_odds_6_3rentan', 'RACE', 'O6'),
('', 'jvlink_odds_6_3rentan','jvlink_odds_6_3rentan_odds','',''),
('1', '', 'jvlink_zyuusyoushiki_win5','RACE','WF'),
('', 'jvlink_zyuusyoushiki_win5', 'jvlink_zyuusyoushiki_win5_haraimodoshi','',''),
('1', '', 'jvlink_kyousouba_zyogai_zyouhou','RACE','JG'),
('1', '', 'jvlink_kyousouba_master','DIFF','UM'),
('1', '', 'jvlink_kisyu_master','DIFF','KS'),
('1', '', 'jvlink_tyoukyoushi_master','DIFF','CH'),
('1', '', 'jvlink_seisansya_master','DIFF','BR'),
('1', '', 'jvlink_banushi_master','DIFF','BN'),
('1', '', 'jvlink_record_master','DIFF','RC'),
('1', '', 'jvlink_race_syousai','DIFF','RA'),
('1', '', 'jvlink_uma_goto_race_zyouhou','DIFF','SE'),
('1', '', 'jvlink_hansyokuba_master','BLOD','HN'),
('1', '', 'jvlink_sanku_master','BLOD','SK'),
('1', '', 'jvlink_keitou_zyouhou','BLOD','BT'),
('1', '', 'jvlink_data_mining_yosou_with_time','MING','DM'),
('1', '', 'jvlink_data_mining_yosou_with_race','MING','TM'),
('1', '', 'jvlink_chakudosuu','SNAP','CK'),
('', 'jvlink_chakudosuu', 'jvlink_baba_betsu_chakukaisuu','',''),
('', 'jvlink_chakudosuu', 'jvlink_baba_zyoutai_betsu_chakukaisuu','',''),
('', 'jvlink_chakudosuu', 'jvlink_kyori_betsu_chakukaisuu','',''),
('', 'jvlink_chakudosuu', 'jvlink_keibazyou_betsu_chakukaisuu','',''),
('', 'jvlink_chakudosuu', 'jvlink_kisyu_betsu_chakukaisuu','',''),
('', 'jvlink_chakudosuu', 'jvlink_tyoukyoushi_betsu_chakukaisuu','',''),
('', 'jvlink_chakudosuu', 'jvlink_banushi_betsu_chakukaisuu','',''),
('', 'jvlink_chakudosuu', 'jvlink_seisansya_betsu_chakukaisuu','',''),
('1', '', 'jvlink_sakamichi_tyoukyou','SLOP','HC'),
('1', '', 'jvlink_kaisai_schedule','YSCH','YS'),
('1', '', 'jvlink_kyousouba_shizyou_torihiki_kakaku','HOSE','HS'),
('1', '', 'jvlink_uma_mei_imi_yurai','HOYU','HY'),
('1', '', 'jvlink_course_zyouhou','COMM','CS'),
('2', '', 'jvlink_kyousouba_master','TCOV','UM'),
('2', '', 'jvlink_kisyu_master','TCOV','KS'),
('2', '', 'jvlink_tyoukyoushi_master','TCOV','CH'),
('2', '', 'jvlink_seisansya_master','TCOV','BR'),
('2', '', 'jvlink_banushi_master','TCOV','BN'),
('2', '', 'jvlink_record_master','TCOV','RC'),
('2', '', 'jvlink_race_syousai','TCOV','RA'),
('2', '', 'jvlink_uma_goto_race_zyouhou','TCOV','SE'),
('2', '', 'jvlink_kyousouba_master','RCOV','UM'),
('2', '', 'jvlink_kisyu_master','RCOV','KS'),
('2', '', 'jvlink_tyoukyoushi_master','RCOV','CH'),
('2', '', 'jvlink_seisansya_master','RCOV','BR'),
('2', '', 'jvlink_banushi_master','RCOV','BN'),
('2', '', 'jvlink_record_master','RCOV','RC'),
('2', '', 'jvlink_race_syousai','RCOV','RA'),
('2', '', 'jvlink_uma_goto_race_zyouhou','RCOV','SE'),
('0', '', 'jvlink_race_syousai','0B12', 'RA'),
('0', '', 'jvlink_uma_goto_race_zyouhou','0B12', 'SE'),
('0', '', 'jvlink_haraimodoshi','0B12', 'HR'),
('0', '', 'jvlink_race_syousai','0B15', 'RA'),
('0', '', 'jvlink_uma_goto_race_zyouhou','0B15', 'SE'),
('0', '', 'jvlink_haraimodoshi','0B15', 'HR'),
('0', '', 'jvlink_odds_1','0B30', 'O1'),
('0', '', 'jvlink_odds_2','0B30', 'O2'),
('0', '', 'jvlink_odds_3','0B30', 'O3'),
('0', '', 'jvlink_odds_4','0B30', 'O4'),
('0', '', 'jvlink_odds_5','0B30', 'O5'),
('0', '', 'jvlink_odds_6','0B30', 'O6'),
('0', '', 'jvlink_odds_1','0B31', 'O1'),
('0', '', 'jvlink_odds_2','0B32', 'O2'),
('0', '', 'jvlink_odds_3','0B33', 'O3'),
('0', '', 'jvlink_odds_4','0B34', 'O4'),
('0', '', 'jvlink_odds_5','0B35', 'O5'),
('0', '', 'jvlink_odds_6','0B36', 'O6'),
('0', '', 'jvlink_hyousuu_1','0B20', 'H1'),
('0', '', 'jvlink_hyousuu_6','0B20', 'H6'),
('0', '', 'jvlink_bataizyuu','0B11', 'WH'),
('0', '', 'jvlink_tenkou_baba_zyoutai','0B14', 'WE'),
('0', '', 'jvlink_syussou_torikeshi_kyousou_zyogai','0B14', 'AV'),
('0', '', 'jvlink_kisyu_henkou','0B14', 'JC'),
('0', '', 'jvlink_hassou_zikoku_henkou','0B14', 'TC'),
('0', '', 'jvlink_course_henkou','0B14', 'CC'),
('0', '', 'jvlink_tenkou_baba_zyoutai','0B16', 'WE'),
('0', '', 'jvlink_syussou_torikeshi_kyousou_zyogai','0B16', 'AV'),
('0', '', 'jvlink_kisyu_henkou','0B16', 'JC'),
('0', '', 'jvlink_hassou_zikoku_henkou','0B16', 'TC'),
('0', '', 'jvlink_course_henkou','0B16', 'CC'),
('0', '', 'jvlink_data_mining_yosou_time','0B13', 'DM'),
('0', '', 'jvlink_data_mining_yosou_race','0B17', 'TM'),
('0', '', 'jvlink_odds_1','0B41', 'O1'),
('0', '', 'jvlink_odds_2','0B42', 'O2'),
('0', '', 'jvlink_zyuusyoushiki_win5','0B51', 'WF');
"
        query = query.Replace(Chr(13), "").Replace(Chr(10), "")
        execute_query(query)
    End Function

    Private Function build_table_initial_query(table_name As String)
        Return "SET SESSION innodb_strict_mode=OFF;CREATE TABLE IF NOT EXISTS jvlink_" & table_name & " " &
            "(id INTEGER NOT NULL PRIMARY KEY, "
    End Function

    Private Function append_query_bt(column_name As String,
                                     length As Integer,
                                     Optional type As String = "CHAR",
                                     Optional opt As String = "")

        If type = "CHAR" Then
            Return column_name & " CHAR(" & length & "), "
        Else
            Return column_name & " " & type & " " & opt & ", "
        End If

    End Function

    Private Function append_unique_constraint(target As String)
        Return target & ", "
    End Function

    Private Function build_table_finalize_query(existing_query As String, Optional unique_constraints As String = "")
        If unique_constraints.Length <> 0 Then
            Return existing_query & "UNIQUE(" & unique_constraints.Substring(0, unique_constraints.Length - 2) & " ));"
        Else
            Return existing_query.Substring(0, existing_query.Length - 2) & ");"
        End If
    End Function

    Private Function execute_query(query As String)
        Dim cmd = New MySqlCommand(query, conn)
        Dim dr = cmd.ExecuteReader()
        dr.Close()
    End Function

    Private Function build_table_tokubetsu_tourokuba()
        Dim q As String = build_table_initial_query("tokubetsu_tourokuba")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("youbi_code", 1)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        q += append_query_bt("tokubetsu_kyousou_bangou", 4)
        q += append_query_bt("kyousoumei_hondai", 60)
        q += append_query_bt("kyousoumei_hukudai", 60)
        q += append_query_bt("kyousoumei_kakkonai", 60)
        q += append_query_bt("kyousoumei_hondai_ouzi", 120)
        q += append_query_bt("kyousoumei_hukudai_ouzi", 120)
        q += append_query_bt("kyousoumei_kakkonai_ouzi", 120)
        q += append_query_bt("kyousoumei_ryakusyou_10", 20)
        q += append_query_bt("kyousoumei_ryakusyou_6", 12)
        q += append_query_bt("kyousoumei_ryakusyou_3", 6)
        q += append_query_bt("kyousoumei_kubun", 1)
        q += append_query_bt("zyuusyou_kaizi", 3)
        q += append_query_bt("grade_code", 1)
        q += append_query_bt("kyousou_syubetsu_code", 2)
        q += append_query_bt("kyousou_kigou_code", 3)
        q += append_query_bt("zyuuryou_syubetsu_code", 1)
        q += append_query_bt("kyousou_zyouken_code_2sai", 3)
        q += append_query_bt("kyousou_zyouken_code_3sai", 3)
        q += append_query_bt("kyousou_zyouken_code_4sai", 3)
        q += append_query_bt("kyousou_zyouken_code_5sai_izyou", 3)
        q += append_query_bt("kyousou_zyouken_code_saizyakunen", 3)
        q += append_query_bt("kyori", 2)
        q += append_query_bt("track_code", 2)
        q += append_query_bt("course_kubun", 2)
        q += append_query_bt("handicap_happyoubi", 8)
        q += append_query_bt("touroku_tousuu", 3)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

        build_table_tourokuba_goto_zyouhou()

    End Function

    Private Function build_table_tourokuba_goto_zyouhou()
        Dim q As String = build_table_initial_query("tourokuba_goto_zyouhou")

        q += append_query_bt("tokubetsu_tourokuba_id", 0, "INTEGER")

        q += append_query_bt("renban", 3)
        q += append_query_bt("kettou_touroku_bangou", 10)
        q += append_query_bt("uma_mei", 36)
        q += append_query_bt("uma_kigou_code", 2)
        q += append_query_bt("seibetsu_code", 1)
        q += append_query_bt("tyoukyoushi_touzai_syozoku_code", 1)
        q += append_query_bt("tyoukyoushi_code", 5)
        q += append_query_bt("tyoukyoushi_mei_ryakusyou", 8)
        q += append_query_bt("hutan_zyuuryou", 3)
        q += append_query_bt("kouryuu_kubun", 1)

        q = build_table_finalize_query(q)
        execute_query(q)

    End Function

    Private Function build_table_race_details()
        Dim q As String = build_table_initial_query("race_syousai")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)

        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("youbi_code", 1)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        q += append_query_bt("tokubetsu_kyousou_bangou", 4)
        q += append_query_bt("kyousoumei_hondai", 60)
        q += append_query_bt("kyousoumei_hukudai", 60)
        q += append_query_bt("kyousoumei_kakkonai", 60)
        q += append_query_bt("kyousoumei_hondai_ouzi", 120)
        q += append_query_bt("kyousoumei_hukudai_ouzi", 120)
        q += append_query_bt("kyousoumei_kakkonai_ouzi", 120)
        q += append_query_bt("kyousoumei_ryakusyou_10", 20)
        q += append_query_bt("kyousoumei_ryakusyou_6", 12)
        q += append_query_bt("kyousoumei_ryakusyou_3", 6)
        q += append_query_bt("kyousoumei_kubun", 1)
        q += append_query_bt("zyuusyou_kaizi", 3)
        q += append_query_bt("grade_code", 1)
        q += append_query_bt("henkoumae_grade_code", 1)
        q += append_query_bt("kyousou_syubetsu_code", 2)
        q += append_query_bt("kyousou_kigou_code", 3)
        q += append_query_bt("zyuuryou_syubetsu_code", 1)
        q += append_query_bt("kyousou_zyouken_code_2sai", 3)
        q += append_query_bt("kyousou_zyouken_code_3sai", 3)
        q += append_query_bt("kyousou_zyouken_code_4sai", 3)
        q += append_query_bt("kyousou_zyouken_code_5sai_izyou", 3)
        q += append_query_bt("kyousou_zyouken_code_saizyakunen", 3)
        q += append_query_bt("kyousou_zyouken_meisyou", 60)

        Dim henkoumae_ato_types As String() = {"henkoumae_", ""}

        For Each henkoumae_ato In henkoumae_ato_types
            q += append_query_bt(henkoumae_ato & "kyori", 4)
            q += append_query_bt(henkoumae_ato & "track_code", 2)
            q += append_query_bt(henkoumae_ato & "course_kubun", 2)

            For i = 1 To 7
                q += append_query_bt(henkoumae_ato & "honsyoukin_" & i, 8)
                If henkoumae_ato = "henkoumae_" And i = 5 Then
                    Exit For
                End If
            Next

            For i = 1 To 5
                q += append_query_bt(henkoumae_ato & "huka_syoukin_" & i, 8)
                If henkoumae_ato = "henkoumae_" And i = 3 Then
                    Exit For
                End If
            Next

            q += append_query_bt(henkoumae_ato & "hassou_zikoku", 4)
        Next

        q += append_query_bt("touroku_tousuu", 2)
        q += append_query_bt("syussou_tousuu", 2)
        q += append_query_bt("nyuusen_tousuu", 2)
        q += append_query_bt("tenkou_code", 1)
        q += append_query_bt("shiba_baba_zyoutai_code", 1)
        q += append_query_bt("dirt_baba_zyoutai_code", 1)
        For i = 1 To 25
            q += append_query_bt("lap_time_" & i, 3)
        Next
        q += append_query_bt("syougai_mile_time", 4)
        q += append_query_bt("mae_3_furlong", 3)
        q += append_query_bt("mae_4_furlong", 3)
        q += append_query_bt("ato_3_furlong", 3)
        q += append_query_bt("ato_4_furlong", 3)
        q += append_query_bt("record_koushin_kubun", 1)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

        build_table_corner_tuuka_zyunni()

    End Function

    Private Function build_table_corner_tuuka_zyunni()
        Dim q As String = build_table_initial_query("corner_tsuuka_zyunni")

        q += append_query_bt("race_syousai_id", 0, "INTEGER")

        q += append_query_bt("corner", 1)
        q += append_query_bt("syuukaisuu", 1)
        q += append_query_bt("kaku_tsuuka_zyunni", 70)

        q = build_table_finalize_query(q)
        execute_query(q)

    End Function

    Private Function build_table_race_info_by_horse()
        Dim q As String = build_table_initial_query("uma_goto_race_zyouhou")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        q += append_query_bt("waku_ban", 1)
        q += append_query_bt("uma_ban", 2)
        q += append_query_bt("kettou_touroku_bangou", 10)
        q += append_query_bt("uma_mei", 36)
        q += append_query_bt("uma_kigou_code", 2)
        q += append_query_bt("seibetsu_code", 1)
        q += append_query_bt("hinsyu_code", 1)
        q += append_query_bt("keiro_code", 2)
        q += append_query_bt("barei", 2)
        q += append_query_bt("touzai_syozoku_code", 1)
        q += append_query_bt("tyoukyoushi_code", 5)
        q += append_query_bt("tyoukyoushi_mei_ryakusyou", 8)
        q += append_query_bt("banushi_code", 6)
        q += append_query_bt("banushi_mei_not_houzin", 64)
        q += append_query_bt("hukuiro_hyouzi", 60)
        q += append_query_bt("yobi_1", 60)
        q += append_query_bt("hutan_zyuuryou", 3)
        q += append_query_bt("henkoumae_hutan_zyuuryou", 3)
        q += append_query_bt("blinker_shiyou_kubun", 1)
        q += append_query_bt("yobi_2", 1)
        q += append_query_bt("kisyu_code", 5)
        q += append_query_bt("henkoumae_kisyu_code", 5)
        q += append_query_bt("kisyu_mei_ryakusyou", 8)
        q += append_query_bt("henkoumae_kisyu_mei_ryakusyou", 8)
        q += append_query_bt("kisyu_minarai_code", 1)
        q += append_query_bt("henkoumae_kisyu_minarai_code", 1)
        q += append_query_bt("bataizyuu", 3)
        q += append_query_bt("zougen_hugou", 1)
        q += append_query_bt("zougen_sa", 3)
        q += append_query_bt("izyoukubun_code", 1)
        q += append_query_bt("nyuusen_zyunni", 2)
        q += append_query_bt("kakutei_chakuzyun", 2)
        q += append_query_bt("douchaku_kubun", 1)
        q += append_query_bt("douchaku_tousuu", 1)
        q += append_query_bt("souha_time", 4)
        q += append_query_bt("chakusa_code", 3)
        q += append_query_bt("plus_chakusa_code", 3)
        q += append_query_bt("plus_plus_chakusa_code", 3)
        q += append_query_bt("zyunni_corner_1", 2)
        q += append_query_bt("zyunni_corner_2", 2)
        q += append_query_bt("zyunni_corner_3", 2)
        q += append_query_bt("zyunni_corner_4", 2)
        q += append_query_bt("tansyou_odds", 4)
        q += append_query_bt("tansyou_ninkizyun", 2)
        q += append_query_bt("kakutoku_honsyoukin", 8)
        q += append_query_bt("kakutoku_huka_syoukin", 8)
        q += append_query_bt("yobi_3", 3)
        q += append_query_bt("yobi_4", 3)
        q += append_query_bt("ato_4_furlong_time", 3)
        q += append_query_bt("ato_3_furlong_time", 3)

        uniq += append_unique_constraint("uma_ban")
        uniq += append_unique_constraint("kettou_touroku_bangou")

        For i = 1 To 3
            q += append_query_bt("aiteuma_kettou_touroku_bangou_for_" & i, 10)
            q += append_query_bt("aiteuma_uma_mei_for_" & i, 36)
        Next

        q += append_query_bt("time_sa", 4)
        q += append_query_bt("record_koushin_kubun", 1)
        q += append_query_bt("mining_kubun", 1)
        q += append_query_bt("mining_yosou_souha_time", 5)
        q += append_query_bt("mining_yosougosa_plus", 4)
        q += append_query_bt("mining_yosougosa_minus", 4)
        q += append_query_bt("mining_yosou_zyunni", 2)
        q += append_query_bt("kyakushitsu_hantei", 1)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_haraimodosi()
        Dim q As String = build_table_initial_query("haraimodoshi")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("touroku_tousuu", 2)
        q += append_query_bt("syussou_tousuu", 2)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")


        q += append_query_bt("huseiritsu_flag_tansyou", 1)
        q += append_query_bt("huseiritsu_flag_hukusyou", 1)
        q += append_query_bt("huseiritsu_flag_waku_ren", 1)
        q += append_query_bt("huseiritsu_flag_uma_ren", 1)
        q += append_query_bt("huseiritsu_flag_wide", 1)
        q += append_query_bt("yobi_1", 1)
        q += append_query_bt("huseiritsu_flag_uma_tan", 1)
        q += append_query_bt("huseiritsu_flag_3renpuku", 1)
        q += append_query_bt("huseiritsu_flag_3rentan", 1)
        q += append_query_bt("tokubarai_flag_tansyou", 1)
        q += append_query_bt("tokubarai_flag_hukusyou", 1)
        q += append_query_bt("tokubarai_flag_waku_ren", 1)
        q += append_query_bt("tokubarai_flag_uma_ren", 1)
        q += append_query_bt("tokubarai_flag_wide", 1)
        q += append_query_bt("yobi_2", 1)
        q += append_query_bt("tokubarai_flag_uma_tan", 1)
        q += append_query_bt("tokubarai_flag_3renpuku", 1)
        q += append_query_bt("tokubarai_flag_3rentan", 1)
        q += append_query_bt("henkan_flag_tansyou", 1)
        q += append_query_bt("henkan_flag_hukusyou", 1)
        q += append_query_bt("henkan_flag_waku_ren", 1)
        q += append_query_bt("henkan_flag_uma_ren", 1)
        q += append_query_bt("henkan_flag_wide", 1)
        q += append_query_bt("yobi_3", 1)
        q += append_query_bt("henkan_flag_uma_tan", 1)
        q += append_query_bt("henkan_flag_3renpuku", 1)
        q += append_query_bt("henkan_flag_3rentan", 1)

        For i = 1 To 28
            q += append_query_bt("henkan_uma_ban_zyouhou_" & i, 1)
        Next

        For i = 1 To 8
            q += append_query_bt("henkan_waku_ban_zyouhou_" & i, 1)
        Next

        For i = 1 To 8
            q += append_query_bt("henkan_douwaku_zyouhou_" & i, 1)
        Next

        Dim haraimodoshi_types As Hashtable = New Hashtable From {
            {"tansyou", 3},
            {"hukusyou", 5},
            {"waku_ren", 3},
            {"uma_ren", 3},
            {"wide", 7},
            {"yobi", 3},
            {"uma_tan", 6},
            {"3renpuku", 3},
            {"3rentan", 6}
        }

        For Each haraimodoshi_type As DictionaryEntry In haraimodoshi_types
            For i = 1 To haraimodoshi_type.Value
                Dim uma_kumi As String = "kumi_"

                If haraimodoshi_type.Key = "tansyou" Or haraimodoshi_type.Key = "hukusyou" Then
                    uma_kumi = "uma_"
                ElseIf haraimodoshi_type.Key = "yobi" Then
                    uma_kumi = ""
                End If

                q += append_query_bt(uma_kumi & "ban_" & haraimodoshi_type.Key & "_" & i, 6)
                q += append_query_bt("haraimodoshikin_" & haraimodoshi_type.Key & "_" & i, 9)
                q += append_query_bt("ninkizyun_" & haraimodoshi_type.Key & "_" & i, 6)

            Next
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_hyousuu1()
        Dim q As String = build_table_initial_query("hyousuu_1")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("touroku_tousuu", 2)
        q += append_query_bt("syussou_tousuu", 2)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")


        Dim order_types As String() = {
            "tansyou",
            "hukusyou",
            "waku_ren",
            "uma_ren",
            "wide",
            "uma_tan",
            "3renpuku"
        }

        For Each order_type As String In order_types
            q += append_query_bt("hatsubai_flag_" & order_type, 1)
            q += append_query_bt("hyousuu_goukei_" & order_type, 11)
            q += append_query_bt("henkan_hyousuu_goukei_" & order_type, 11)
        Next

        q += append_query_bt("hukusyou_chakubarai_key", 1)

        For i = 1 To 28
            q += append_query_bt("henkan_zyouhou_uma_ban_" & i, 1)
        Next

        For i = 1 To 8
            q += append_query_bt("henkan_zyouhou_waku_ban_" & i, 1)
        Next

        For i = 1 To 8
            q += append_query_bt("henkan_zyouhou_douwaku_" & i, 1)
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

        build_table_hyousuu1_by_order_type(order_types)

    End Function

    Private Function build_table_hyousuu1_by_order_type(order_types As String())
        For Each order_type In order_types
            Dim q As String = build_table_initial_query("hyousuu_1_" & order_type)
            Dim uma_kumi As String = "kumi_"

            If order_type = "tansyou" Or order_type = "hukusyou" Then
                uma_kumi = "uma_"
            End If

            q += append_query_bt("hyousuu_1_id", 0, "INTEGER")

            q += append_query_bt(uma_kumi & "ban", 6)
            q += append_query_bt("hyousuu", 11)
            q += append_query_bt("ninkizyun", 3)

            q = build_table_finalize_query(q)
            execute_query(q)
        Next
    End Function

    Private Function build_table_hyousuu6()
        Dim q As String = build_table_initial_query("hyousuu_6")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("touroku_tousuu", 2)
        q += append_query_bt("syussou_tousuu", 2)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        q += append_query_bt("hatsubai_flag_3rentan", 1)

        For i = 1 To 18
            q += append_query_bt("henkan_uma_ban_zyouhou_" & i, 1)
        Next

        q += append_query_bt("hyousuu_goukei_3rentan", 11)
        q += append_query_bt("henkan_hyousuu_goukei_3rentan", 11)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

        build_table_hyousuu6_by_order_type()

    End Function

    Private Function build_table_hyousuu6_by_order_type()
        Dim q As String = build_table_initial_query("hyousuu_6_3rentan")

        q += append_query_bt("hyousuu_6_id", 0, "INTEGER")

        q += append_query_bt("kumi_ban", 6)
        q += append_query_bt("hyousuu", 11)
        q += append_query_bt("ninkizyun", 4)

        q = build_table_finalize_query(q)
        execute_query(q)
    End Function

    Private Function build_table_odds1()
        Dim q As String = build_table_initial_query("odds_1")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("happyoubi_gappi_zihun", 8)
        q += append_query_bt("touroku_tousuu", 2)
        q += append_query_bt("syussou_tousuu", 2)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        q += append_query_bt("hatsubai_flag_tansyou", 1)
        q += append_query_bt("hatsubai_flag_hukusyou", 1)
        q += append_query_bt("hatsubai_flag_waku_ren", 1)

        q += append_query_bt("hyousuu_goukei_tansuu", 11)
        q += append_query_bt("hyousuu_goukei_hukusyou", 11)
        q += append_query_bt("hyousuu_goukei_waku_ren", 11)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

        build_table_odds_1_tansyou_odds()
        build_table_odds_1_hukusyou_odds()
        build_table_odds_1_waku_ren_odds()

    End Function

    Private Function build_table_odds_1_tansyou_odds()
        Dim q As String = build_table_initial_query("odds_1_tansyou_odds")

        q += append_query_bt("odds_1_id", 0, "INTEGER")

        q += append_query_bt("uma_ban", 2)
        q += append_query_bt("odds", 4)
        q += append_query_bt("ninkizyun", 2)

        q = build_table_finalize_query(q)
        execute_query(q)
    End Function

    Private Function build_table_odds_1_hukusyou_odds()
        Dim q As String = build_table_initial_query("odds_1_hukusyou_odds")

        q += append_query_bt("odds_1_id", 0, "INTEGER")

        q += append_query_bt("uma_ban", 2)
        q += append_query_bt("saitei_odds", 4)
        q += append_query_bt("saikou_odds", 4)
        q += append_query_bt("ninkizyun", 2)

        q = build_table_finalize_query(q)
        execute_query(q)
    End Function

    Private Function build_table_odds_1_waku_ren_odds()
        Dim q As String = build_table_initial_query("odds_1_waku_ren_odds")

        q += append_query_bt("odds_1_id", 0, "INTEGER")

        q += append_query_bt("uma_ban", 2)
        q += append_query_bt("odds", 5)
        q += append_query_bt("ninkizyun", 2)

        q = build_table_finalize_query(q)
        execute_query(q)
    End Function

    Private Function build_table_odds2()
        Dim q As String = build_table_initial_query("odds_2_uma_ren")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("happyoubi_gappi_zihun", 8)
        q += append_query_bt("touroku_tousuu", 2)
        q += append_query_bt("syussou_tousuu", 2)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        q += append_query_bt("hatsubai_flag_uma_ren", 1)

        q += append_query_bt("hyousuu_goukei_uma_ren", 11)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

        build_table_odds_2_uma_ren_odds()
    End Function

    Private Function build_table_odds_2_uma_ren_odds()
        Dim q As String = build_table_initial_query("odds_2_uma_ren_odds")

        q += append_query_bt("odds_2_uma_ren_id", 0, "INTEGER")

        q += append_query_bt("kumi_ban", 4)
        q += append_query_bt("odds", 6)
        q += append_query_bt("ninkizyun", 3)

        q = build_table_finalize_query(q)
        execute_query(q)
    End Function

    Private Function build_table_odds3()
        Dim q As String = build_table_initial_query("odds_3_wide")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("happyoubi_gappi_zihun", 8)
        q += append_query_bt("touroku_tousuu", 2)
        q += append_query_bt("syussou_tousuu", 2)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        q += append_query_bt("hatsubai_flag_wide", 1)

        q += append_query_bt("hyousuu_goukei_wide", 11)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

        build_table_odds_3_wide_odds()

    End Function

    Private Function build_table_odds_3_wide_odds()
        Dim q As String = build_table_initial_query("odds_3_wide_odds")

        q += append_query_bt("odds_3_wide_id", 0, "INTEGER")

        q += append_query_bt("kumi_ban", 4)
        q += append_query_bt("saitei_odds", 5)
        q += append_query_bt("saikou_odds", 5)
        q += append_query_bt("ninkizyun", 3)

        q = build_table_finalize_query(q)
        execute_query(q)
    End Function

    Private Function build_table_odds4()
        Dim q As String = build_table_initial_query("odds_4_uma_tan")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("happyoubi_gappi_zihun", 8)
        q += append_query_bt("touroku_tousuu", 2)
        q += append_query_bt("syussou_tousuu", 2)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        q += append_query_bt("hatsubai_flag_uma_tan", 1)

        q += append_query_bt("hyousuu_goukei_uma_tan", 11)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

        build_table_odds_4_uma_tan_odds()

    End Function

    Private Function build_table_odds_4_uma_tan_odds()
        Dim q As String = build_table_initial_query("odds_4_uma_tan_odds")

        q += append_query_bt("odds_4_uma_tan_id", 0, "INTEGER")

        q += append_query_bt("kumi_ban", 4)
        q += append_query_bt("odds", 6)
        q += append_query_bt("ninkizyun", 3)

        q = build_table_finalize_query(q)
        execute_query(q)
    End Function

    Private Function build_table_odds5()
        Dim q As String = build_table_initial_query("odds_5_3renpuku")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("happyoubi_gappi_zihun", 8)
        q += append_query_bt("touroku_tousuu", 2)
        q += append_query_bt("syussou_tousuu", 2)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        q += append_query_bt("hatsubai_flag_3renpuku", 1)

        q += append_query_bt("hyousuu_goukei_3renpuku", 11)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

        build_table_odds_5_3renpuku_odds()

    End Function

    Private Function build_table_odds_5_3renpuku_odds()
        Dim q As String = build_table_initial_query("odds_5_3renpuku_odds")

        q += append_query_bt("odds_5_3renpuku_id", 0, "INTEGER")

        q += append_query_bt("kumi_ban", 6)
        q += append_query_bt("odds", 6)
        q += append_query_bt("ninkizyun", 3)

        q = build_table_finalize_query(q)
        execute_query(q)
    End Function

    Private Function build_table_odds6()
        Dim q As String = build_table_initial_query("odds_6_3rentan")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("happyoubi_gappi_zihun", 8)
        q += append_query_bt("touroku_tousuu", 2)
        q += append_query_bt("syussou_tousuu", 2)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        q += append_query_bt("hatsubai_flag_3rentan", 1)

        q += append_query_bt("hyousuu_goukei_3rentan", 11)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

        build_table_odds_6_3rentan_odds()

    End Function

    Private Function build_table_odds_6_3rentan_odds()
        Dim q As String = build_table_initial_query("odds_6_3rentan_odds")

        q += append_query_bt("odds_6_3rentan_id", 0, "INTEGER")

        q += append_query_bt("kumi_ban", 6)
        q += append_query_bt("odds", 6)
        q += append_query_bt("ninkizyun", 3)

        q = build_table_finalize_query(q)
        execute_query(q)
    End Function

    Private Function build_table_horses_master()
        Dim q As String = build_table_initial_query("kyousouba_master")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kettou_touroku_bangou", 10)
        q += append_query_bt("kyousouba_massyou_kubun", 1)
        q += append_query_bt("kyousouba_touroku_nen_gappi", 8)
        q += append_query_bt("kyousouba_massyou_nen_gappi", 8)
        q += append_query_bt("sei_nen_gappi", 8)
        q += append_query_bt("uma_mei", 36)
        q += append_query_bt("uma_mei_hankaku_kana", 36)
        q += append_query_bt("uma_mei_ouzi", 60)
        q += append_query_bt("JRA_shisetsu_zaikyu_flag", 1)
        q += append_query_bt("yobi_1", 19)
        q += append_query_bt("uma_kigou_code", 2)
        q += append_query_bt("seibetsu_code", 1)
        q += append_query_bt("hinsyu_code", 1)
        q += append_query_bt("keiro_code", 2)

        uniq += append_unique_constraint("kettou_touroku_bangou")

        Dim hubo_types As String() = {
            "hu", "bo",
            "huhu", "hubo", "bohu", "bobo",
            "huhuhu", "huhubo", "hubohu", "hubobo",
            "bohuhu", "bohubo", "bobohu", "bobobo"}

        For Each hubo_type In hubo_types
            q += append_query_bt("hansyokuba_tourokubangou_" & hubo_type, 8)
            q += append_query_bt("uma_mei_" & hubo_type, 36)
        Next

        q += append_query_bt("touzai_syozoku_code", 1)
        q += append_query_bt("tyoukyoushi_code", 5)
        q += append_query_bt("tyoukyoushi_mei_ryakusyou", 8)
        q += append_query_bt("syoutai_chiiki_mei", 20)
        q += append_query_bt("seisansya_code", 6)
        q += append_query_bt("seisansya_mei", 70)
        q += append_query_bt("sanchi_mei", 20)
        q += append_query_bt("banushi_code", 6)
        q += append_query_bt("banushi_mei", 64)
        q += append_query_bt("heichi_honsyoukin_ruikei", 9)
        q += append_query_bt("syougai_honsyoukin_ruikei", 9)
        q += append_query_bt("heichi_huka_syoukin_ruikei", 9)
        q += append_query_bt("syougai_huka_syoukin_ruikei", 9)
        q += append_query_bt("heichi_syuutokusyoukin_ruikei", 9)
        q += append_query_bt("syougai_syuutokusyoukin_ruikei", 9)

        For i = 1 To 6
            Dim ika As String = ""
            If i = 6 Then
                ika = "_ika"
            End If
            q += append_query_bt("sougou_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("tyuuou_goukei_chakukaisuu_" & i & "_chaku" & ika, 3)

            q += append_query_bt("shiba_tyoku_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("shiba_migi_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("shiba_hidari_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("da_tyoku_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("da_migi_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("da_hidari_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("syougai_chakukaisuu_" & i & "_chaku" & ika, 3)

            q += append_query_bt("shiba_ryou_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("shiba_saya_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("shiba_omo_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("shiba_hu_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("da_ryou_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("da_saya_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("da_omo_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("da_hu_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("syougai_ryou_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("syougai_saya_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("syougai_omo_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("syougai_hu_chakukaisuu_" & i & "_chaku" & ika, 3)

            q += append_query_bt("shiba_16_shita_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("shiba_22_shita_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("shiba_22_goe_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("da_16_shita_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("da_22_shita_chakukaisuu_" & i & "_chaku" & ika, 3)
            q += append_query_bt("da_22_goe_chakukaisuu_" & i & "_chaku" & ika, 0)
        Next

        q += append_query_bt("kyakushitsu_keikou_nige", 3)
        q += append_query_bt("kyakushitsu_keikou_senkou", 3)
        q += append_query_bt("kyakushitsu_keikou_sashi", 3)
        q += append_query_bt("kyakushitsu_keikou_oikomi", 3)

        q += append_query_bt("touroku_race_suu", 3)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)
    End Function

    Private Function build_table_riders_master()
        Dim q As String = build_table_initial_query("kisyu_master")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kisyu_code", 5)
        q += append_query_bt("kisyu_massyou_kubun", 1)
        q += append_query_bt("kisyu_menkyo_kouhu_nen_gappi", 8)
        q += append_query_bt("kisyu_menkyo_massyou_nen_gappi", 8)
        q += append_query_bt("sei_nen_gappi", 8)
        q += append_query_bt("kisyu_mei", 34)
        q += append_query_bt("yobi_1", 34)
        q += append_query_bt("kisyu_mei_hankaku_kana", 30)
        q += append_query_bt("kisyu_mei_ryakusyou", 8)
        q += append_query_bt("kisyu_mei_ouzi", 80)
        q += append_query_bt("seibetsu_kubun", 1)
        q += append_query_bt("kizyou_shikaku_code", 1)
        q += append_query_bt("kisyu_minarai_code", 1)
        q += append_query_bt("kisyu_touzai_syozoku_code", 1)
        q += append_query_bt("syoutai_chiiki_mei", 20)
        q += append_query_bt("syozoku_tyoukyoushi_code", 5)
        q += append_query_bt("syozoku_tyoukyoushi_meisyou", 8)

        uniq += append_unique_constraint("kisyu_code")

        Dim heichi_syougai As String() = {"hatsu_heichi_", "hatsu_syougai_"}

        For Each heichi_syougai_prefix In heichi_syougai
            q += append_query_bt(heichi_syougai_prefix & "kizyou_nen_gappi_zyou_kai_hi_R", 16)
            q += append_query_bt(heichi_syougai_prefix & "kizyou_syussou_tousuu", 2)
            q += append_query_bt(heichi_syougai_prefix & "kizyou_kettou_touroku_bangou", 10)
            q += append_query_bt(heichi_syougai_prefix & "kizyou_uma_mei", 36)
            q += append_query_bt(heichi_syougai_prefix & "kizyou_kakutei_chakuzyun", 2)
            q += append_query_bt(heichi_syougai_prefix & "izyou_kubun_code", 1)

            q += append_query_bt(heichi_syougai_prefix & "syouri_nen_gappi_zyou_kai_hi_R", 16)
            q += append_query_bt(heichi_syougai_prefix & "syouri_syussou_tousuu", 2)
            q += append_query_bt(heichi_syougai_prefix & "syouri_kettou_touroku_bangou", 10)
            q += append_query_bt(heichi_syougai_prefix & "syouri_uma_mei", 36)
        Next

        q = append_seiseki_information(q)

        q = build_table_finalize_query(q, uniq)

        execute_query(q)

    End Function

    Private Function append_seiseki_information(q As String)
        For i = 1 To 3
            Dim prefix As String = "recent_zyuusyou_race_" & i & "_"
            q += append_query_bt(prefix & "nenn_gappi_zyou_kai_R", 16)
            q += append_query_bt(prefix & "kyousoumei_hondai", 60)
            q += append_query_bt(prefix & "kyousoumei_ryakusyou_10", 20)
            q += append_query_bt(prefix & "kyousoumei_ryakusyou_6", 12)
            q += append_query_bt(prefix & "kyousoumei_ryakusyou_3", 6)
            q += append_query_bt(prefix & "grade_code", 1)
            q += append_query_bt(prefix & "syussou_tousuu", 2)
            q += append_query_bt(prefix & "kettou_touroku_bangou", 10)
            q += append_query_bt(prefix & "uma_mei", 36)
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

        For Each year_prefix In years
            q += append_query_bt("settei_nen" & year_prefix, 4)
            q += append_query_bt("heichi_honsyoukin_goukei" & year_prefix, 10)
            q += append_query_bt("syougai_honsyoukin_goukei" & year_prefix, 10)
            q += append_query_bt("heichi_huka_syoukin_goukei" & year_prefix, 10)
            q += append_query_bt("syougai_huka_syoukin_goukei" & year_prefix, 10)

            For i = 1 To 6
                Dim ika As String = ""
                If i = 6 Then
                    ika = "_ika"
                End If

                q += append_query_bt("heichi_" & i & "_chaku" & ika & "_kaisuu" & year_prefix, 6)
                q += append_query_bt("syougai_" & i & "_chaku" & ika & "_kaisuu" & year_prefix, 6)

                For Each field_location In field_locations
                    For Each field_type In field_types
                        q += append_query_bt(field_location & "_" & field_type & "_" &
                                             i & ika & "_chakukaisuu" & year_prefix, 6)
                    Next
                Next

                For Each shiba_da_type In shiba_da_types
                    q += append_query_bt(shiba_da_type & "16_shita_" &
                                         i & ika & "_chakukaisuu" & year_prefix, 6)
                    q += append_query_bt(shiba_da_type & "22_shita_" &
                         i & ika & "_chakukaisuu" & year_prefix, 6)
                    q += append_query_bt(shiba_da_type & "22_goe_" &
                         i & ika & "_chakukaisuu" & year_prefix, 6)
                Next
            Next
        Next


        Return q
    End Function

    Private Function build_table_teachers_master()
        Dim q As String = build_table_initial_query("tyoukyoushi_master")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("tyoukyoushi_code", 5)
        q += append_query_bt("tyoukyoushi_massyou_kubun", 1)
        q += append_query_bt("tyoukyoushi_menkyo_kouhu_nen_gappi", 8)
        q += append_query_bt("tyoukyoushi_menkyo_massyou_nen_gappi", 8)
        q += append_query_bt("sei_nen_gappi", 8)
        q += append_query_bt("tyoukyoushi_mei", 34)
        q += append_query_bt("tyoukyoushi_mei_hankaku_kana", 30)
        q += append_query_bt("tyoukyoushi_mei_ryakusyou", 8)
        q += append_query_bt("tyoukyoushi_mei_ouzi", 80)
        q += append_query_bt("seibetsu_kubun", 1)
        q += append_query_bt("tyoukyoushi_touzai_syozoku_code", 1)
        q += append_query_bt("syoutai_chiiki_mei", 20)

        uniq += append_unique_constraint("tyoukyoushi_code")

        q = append_seiseki_information(q)

        q = build_table_finalize_query(q, uniq)

        execute_query(q)

    End Function

    Private Function build_table_breeders_master()
        Dim q As String = build_table_initial_query("seisansya_master")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("seisansya_code", 6)
        q += append_query_bt("seisansya_mei_houzin", 70)
        q += append_query_bt("seisansya_mei_not_houzin", 70)
        q += append_query_bt("seisansya_mei_hankaku_kana", 70)
        q += append_query_bt("seisansya_mei_ouzi", 168)
        q += append_query_bt("sesansya_zyuusyo_zichitai_mei", 20)

        uniq += append_unique_constraint("seisansya_code")

        Dim honnnen_ruikei_type As String() = {"_honnnen", "_ruikei"}

        For Each honnnen_ruikei In honnnen_ruikei_type
            q += append_query_bt("settei_nen" & honnnen_ruikei, 4)
            q += append_query_bt("honsyoukin_goukei" & honnnen_ruikei, 10)
            q += append_query_bt("huka_syoukin_goukei" & honnnen_ruikei, 10)
            For i = 1 To 6
                q += append_query_bt("chakukaisuu_" & i & honnnen_ruikei, 6)
            Next
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_horse_owners_master()
        Dim q As String = build_table_initial_query("banushi_master")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("banushi_code", 6)
        q += append_query_bt("banushi_mei_houzin", 64)
        q += append_query_bt("banushi_mei_not_houzin", 64)
        q += append_query_bt("banushi_mei_hankaku_kana", 50)
        q += append_query_bt("banushi_mei_ouzi", 100)
        q += append_query_bt("hukusyoku_hyouzi", 60)

        uniq += append_unique_constraint("banushi_code")

        Dim honnnen_ruikei_type As String() = {"_honnnen", "_ruikei"}

        For Each honnnen_ruikei In honnnen_ruikei_type
            q += append_query_bt("settei_nen" & honnnen_ruikei, 4)
            q += append_query_bt("honsyoukin_goukei" & honnnen_ruikei, 10)
            q += append_query_bt("huka_syoukin_goukei" & honnnen_ruikei, 10)
            For i = 1 To 6
                q += append_query_bt("chakukaisuu_" & i & honnnen_ruikei, 6)
            Next
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_male_breeding_horses_master()
        Dim q As String = build_table_initial_query("hansyokuba_master")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("hansyokuba_touroku_bangou", 8)
        q += append_query_bt("yobi_1", 8)
        q += append_query_bt("kettou_touroku_bangou", 8)
        q += append_query_bt("delkubun", 1)
        q += append_query_bt("uma_mei", 36)
        q += append_query_bt("uma_mei_hankaku_kana", 40)
        q += append_query_bt("uma_mei_ouzi", 80)

        uniq += append_unique_constraint("hansyokuba_touroku_bangou")

        q += append_query_bt("seinen", 4)
        q += append_query_bt("seibetsu_code", 1)
        q += append_query_bt("hinsyu_code", 1)
        q += append_query_bt("keiro_code", 2)
        q += append_query_bt("hansyokuba_mochikomi_kubun", 1)
        q += append_query_bt("yunyuu_nen", 4)
        q += append_query_bt("sanchi_mei", 20)
        q += append_query_bt("huba_hansyoku_touroku_bangou", 8)
        q += append_query_bt("boba_hansyoku_touroku_bangou", 8)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)
    End Function

    Private Function build_table_female_breeding_horses_master()
        Dim q As String = build_table_initial_query("sanku_master")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kettou_touroku_bangou", 10)

        uniq += append_unique_constraint("kettou_touroku_bangou")

        q += append_query_bt("seinenn_gappi", 8)
        q += append_query_bt("seibetsu_code", 1)
        q += append_query_bt("hinsyu_code", 1)
        q += append_query_bt("keiro_code", 2)
        q += append_query_bt("sanku_mochikomi_kubun", 1)
        q += append_query_bt("yunyuu_nen", 4)
        q += append_query_bt("seisansya_code", 6)
        q += append_query_bt("sanchi_mei", 20)

        Dim hubo_types As String() = {
            "hu", "bo",
            "huhu", "hubo", "bohu", "bobo",
            "huhuhu", "huhubo", "hubohu", "hubobo",
            "bohuhu", "bohubo", "bobohu", "bobobo"}

        For Each hubo_type In hubo_types
            q += append_query_bt(hubo_type & "_hansyoku_touroku_bangou", 8)
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_syussoubetu_chakudosuu()
        Dim q As String = build_table_initial_query("chakudosuu")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("kettou_touroku_bangou", 10)
        q += append_query_bt("uma_mei", 36)
        q += append_query_bt("heichi_honsyoukin_ruikei", 9)
        q += append_query_bt("syougai_honsyoukin_ruikei", 9)
        q += append_query_bt("heichi_huka_syoukin_ruikei", 9)
        q += append_query_bt("syougai_huka_syoukin_ruikei", 9)
        q += append_query_bt("heichi_syuutoku_syoukin_ruikei", 9)
        q += append_query_bt("syougai_syuutoku_syoukin_ruikei", 9)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")
        uniq += append_unique_constraint("kettou_touroku_bangou")

        For i = 1 To 6
            Dim ika As String = ""
            If i = 6 Then
                ika = "_ika"
            End If
            q += append_query_bt("sougou_chakukaisuu_" & i & ika, 3)
            q += append_query_bt("tyuuou_goukei_chakukaisuu_" & i & ika, 3)
        Next

        Dim kyakushitsu_types As String() = {
            "nige",
            "senkou",
            "sashi",
            "oikomi"
        }

        For Each kyakushitsu_type In kyakushitsu_types
            q += append_query_bt("kyakushitsu_keikou_" & kyakushitsu_type, 3)
        Next

        q += append_query_bt("touroku_race_suu", 3)
        q += append_query_bt("kisyu_code", 5)
        q += append_query_bt("kisyu_mei", 34)

        q += append_query_bt("seisansya_code", 6)
        q += append_query_bt("seisansya_mei", 70)
        q += append_query_bt("seisansya_mei_not_houzin", 6)

        Dim honnnen_ruikei As String() = {"honnnen_", "ruikei_"}
        For Each honnnen_ruikei_type In honnnen_ruikei
            q += append_query_bt(honnnen_ruikei_type & "settei_nen", 0)
            q += append_query_bt(honnnen_ruikei_type & "honsyoukin_goukei", 0)
            q += append_query_bt(honnnen_ruikei_type & "huka_syoukin_goukei", 0)
            For i = 1 To 6
                Dim ika = ""
                If i = 6 Then
                    ika = "_ika"
                End If
                q += append_query_bt(honnnen_ruikei_type & i & "_chaku" & ika, 0)
            Next

        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

        build_table_baba_betsu_chakukaisuu()
        build_table_baba_zyoutai_betsu_chakukaisuu()
        build_table_kyori_betsu_chakukaisuu()
        build_table_keibazyou_betsu_chakukaisuu()
        build_table_kisyu_and_tyoukyoushi_betsu_chakukaisuu()
        build_table_banushi_and_seisansya_zyouhou_chakukaisuu()

    End Function

    Private Function build_table_baba_betsu_chakukaisuu()
        Dim q As String = build_table_initial_query("baba_betsu_chakukaisuu")

        q += append_query_bt("chakudosuu_id", 0, "INTEGER")

        Dim shiba_da As String() = {"shiba_", "da_"}
        Dim tyoku_migi_hidari As String() = {"tyoku_", "migi_", "hidari_"}

        For i = 1 To 6
            Dim ika As String = ""
            If i = 6 Then
                ika = "_ika"
            End If

            For Each shiba_da_type In shiba_da
                For Each tyoku_migi_hidari_type In tyoku_migi_hidari
                    q += append_query_bt(shiba_da_type & tyoku_migi_hidari_type & i & "_chaku" & ika, 3)
                Next
            Next

            q += append_query_bt("syougai_" & i & "_chaku" & ika, 3)
        Next

        q = build_table_finalize_query(q)
        execute_query(q)

    End Function

    Private Function build_table_baba_zyoutai_betsu_chakukaisuu()
        Dim q As String = build_table_initial_query("baba_zyoutai_betsu_chakukaisuu")

        Dim shiba_da_syougai As String() = {"shiba_", "da_", "syougai_"}
        Dim conditions As String() = {"ryou_", "saya_", "omo_", "hu_"}

        q += append_query_bt("chakudosuu_id", 0, "INTEGER")

        For i = 1 To 6
            Dim ika As String = ""
            If i = 6 Then
                ika = "_ika"
            End If

            For Each shiba_da_type In shiba_da_syougai
                For Each condition In conditions
                    q += append_query_bt(shiba_da_type & condition & i & "_chaku" & ika, 3)
                Next
            Next
        Next

        q = build_table_finalize_query(q)
        execute_query(q)

    End Function

    Private Function build_table_kyori_betsu_chakukaisuu()
        Dim q As String = build_table_initial_query("kyori_betsu_chakukaisuu")

        Dim shiba_da As String() = {"shiba_", "da_"}
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

        q += append_query_bt("chakudosuu_id", 0, "INTEGER")

        For i = 1 To 6
            Dim ika As String = ""
            If i = 6 Then
                ika = "_ika"
            End If

            For Each shiba_da_type In shiba_da
                For Each kyori In kyori_types
                    q += append_query_bt(shiba_da_type & kyori & i & "_chaku" & ika, 3)
                Next
            Next
        Next

        q = build_table_finalize_query(q)
        execute_query(q)

    End Function

    Private Function build_table_keibazyou_betsu_chakukaisuu()
        Dim q As String = build_table_initial_query("keibazyou_betsu_chakukaisuu")

        Dim shiba_da_syougai As String() = {"shiba_", "da_", "syougai_"}
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

        q += append_query_bt("chakudosuu_id", 0, "INTEGER")

        For i = 1 To 6
            Dim ika As String = ""
            If i = 6 Then
                ika = "_ika"
            End If

            For Each shiba_da_type In shiba_da_syougai
                For Each field_location In field_locations
                    q += append_query_bt(field_location & shiba_da_type & i & "_chaku" & ika, 3)
                Next
            Next
        Next

        q = build_table_finalize_query(q)
        execute_query(q)

    End Function

    Private Function build_table_kisyu_and_tyoukyoushi_betsu_chakukaisuu()
        Dim q As String = ""
        Dim q1 As String = build_table_initial_query("kisyu_betsu_chakukaisuu")
        Dim q2 As String = build_table_initial_query("tyoukyoushi_betsu_chakukaisuu")

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
        Dim honnnen_ruikei As String() = {"honnnen_", "ruikei_"}

        q += append_query_bt("chakudosuu_id", 0, "INTEGER")

        For Each honnnen_ruikei_type In honnnen_ruikei
            q += append_query_bt(honnnen_ruikei_type & "settei_nen", 4)
            q += append_query_bt(honnnen_ruikei_type & "heichi_honsyoukin_goukei", 10)
            q += append_query_bt(honnnen_ruikei_type & "syougai_honsyoukin_goukei", 10)
            q += append_query_bt(honnnen_ruikei_type & "heichi_huka_syoukin_goukei", 10)
            q += append_query_bt(honnnen_ruikei_type & "syougai_huka_syoukin_goukei", 10)

            For i = 1 To 6
                Dim ika As String = ""
                If i = 6 Then
                    ika = "_ika"
                End If

                For Each shiba_da_syougai_type In shiba_da_syougai
                    q += append_query_bt(honnnen_ruikei_type & shiba_da_syougai_type & i & "_chaku" & ika, 0)
                Next

                For Each shiba_da_type In shiba_da
                    For Each kyori In kyori_types
                        q += append_query_bt(honnnen_ruikei_type & shiba_da_type & kyori & i & "_chaku" & ika, 3)
                    Next
                Next

                For Each shiba_da_syougai_type In shiba_da_syougai
                    For Each field_location In field_locations
                        q += append_query_bt(honnnen_ruikei_type & field_location & shiba_da_syougai_type & i & "_chaku" & ika, 3)
                    Next
                Next
            Next
        Next

        q1 += q
        q2 += q

        q1 += append_query_bt("kisyu_code", 5)
        q1 += append_query_bt("kisyu_mei", 34)
        q2 += append_query_bt("tyoukyoushi_code", 5)
        q2 += append_query_bt("tyoukyoushi_mei", 34)

        q1 = build_table_finalize_query(q1)
        q2 = build_table_finalize_query(q2)

        execute_query(q1)
        execute_query(q2)
    End Function

    Private Function build_table_banushi_and_seisansya_zyouhou_chakukaisuu()
        Dim q As String = ""
        Dim q1 As String = build_table_initial_query("banushi_betsu_chakukaisuu")
        Dim q2 As String = build_table_initial_query("seisansya_betsu_chakukaisuu")
        Dim honnnen_ruikei As String() = {"honnnen_", "ruikei_"}

        q += append_query_bt("chakudosuu_id", 0, "INTEGER")

        For Each honnnen_ruikei_type In honnnen_ruikei
            q += append_query_bt(honnnen_ruikei_type & "settei_nen", 0)
            q += append_query_bt(honnnen_ruikei_type & "honsyoukin_goukei", 0)
            q += append_query_bt(honnnen_ruikei_type & "huka_syoukin_goukei", 0)
            For i = 1 To 6
                Dim ika = ""
                If i = 6 Then
                    ika = "_ika"
                End If
                q += append_query_bt(honnnen_ruikei_type & i & "_chaku" & ika, 0)
            Next
        Next

        q1 += q
        q2 += q

        q1 += append_query_bt("banushi_code", 6)
        q1 += append_query_bt("banushi_mei", 64)
        q1 += append_query_bt("banushi_mei_not_houzin", 64)

        q2 += append_query_bt("seisansya_code", 6)
        q2 += append_query_bt("seisansya_mei", 64)
        q2 += append_query_bt("seisansya_mei_not_houzin", 64)

        q1 = build_table_finalize_query(q1)
        q2 = build_table_finalize_query(q2)

        execute_query(q1)
        execute_query(q2)

    End Function

    Private Function build_table_record_master()
        Dim q As String = build_table_initial_query("record_master")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("record_shikibetsu_kubun", 1)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("tokubetsu_kyousou_bangou", 4)
        q += append_query_bt("kyousoumei_hondai", 60)
        q += append_query_bt("grade_code", 1)
        q += append_query_bt("kyousou_syubetsu_code", 2)
        q += append_query_bt("kyori", 4)
        q += append_query_bt("track_code", 2)
        q += append_query_bt("record_kubun", 1)
        q += append_query_bt("record_time", 4)
        q += append_query_bt("tenkou_code", 1)
        q += append_query_bt("shiba_baba_zyoutai_code", 1)
        q += append_query_bt("dirt_baba_zyoutai_code", 1)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        uniq += append_unique_constraint("kyousou_syubetsu_code")
        uniq += append_unique_constraint("kyori")
        uniq += append_unique_constraint("track_code")

        For i = 1 To 3
            q += append_query_bt("kettou_touroku_bangou_" & i, 10)
            q += append_query_bt("uma_mei_" & i, 36)
            q += append_query_bt("uma_kigou_code_" & i, 2)
            q += append_query_bt("seibetsu_code_" & i, 1)
            q += append_query_bt("tyoukyoushi_code_" & i, 5)
            q += append_query_bt("tyoukyoushi_mei_" & i, 34)
            q += append_query_bt("hutan_zyuuryou_" & i, 3)
            q += append_query_bt("kisyu_code_" & i, 5)
            q += append_query_bt("kisyu_mei_" & i, 34)
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_sakamiti_tyoukyou()
        Dim q As String = build_table_initial_query("sakamichi_tyoukyou")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("traning_center_kubun", 1)
        q += append_query_bt("tyoukyou_nen_gappi", 8)
        q += append_query_bt("tyoukyou_zikoku", 4)
        q += append_query_bt("kettou_touroku_bangou", 10)
        q += append_query_bt("furlong_time_goukei_4_800_0", 4)
        q += append_query_bt("lap_time_800_600", 3)
        q += append_query_bt("furlong_time_goukei_3_600_0", 4)
        q += append_query_bt("lap_time_600_400", 3)
        q += append_query_bt("furlong_time_goukei_2_400_0", 4)
        q += append_query_bt("lap_time_400_200", 3)
        q += append_query_bt("lap_time_200_0", 3)

        uniq += append_unique_constraint("traning_center_kubun")
        uniq += append_unique_constraint("tyoukyou_nen_gappi")
        uniq += append_unique_constraint("tyoukyou_zikoku")
        uniq += append_unique_constraint("kettou_touroku_bangou")

        q = build_table_finalize_query(q, uniq)
        execute_query(q)
    End Function

    Private Function build_table_horse_market_trade_price()
        Dim q As String = build_table_initial_query("kyousouba_shizyou_torihiki_kakaku")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kettou_touroku_bangou", 10)
        q += append_query_bt("huba_hansyoku_touroku_bangou", 8)
        q += append_query_bt("boba_hansyoku_touroku_bangou", 8)
        q += append_query_bt("seinen", 4)
        q += append_query_bt("syusaisya_shizyou_code", 6)
        q += append_query_bt("syusaisya_meisyou", 40)
        q += append_query_bt("shizyou_meisyou", 80)
        q += append_query_bt("shizyou_kaisai_kaishibi", 8)
        q += append_query_bt("shizyou_kaisei_syuuryoubi", 8)
        q += append_query_bt("torihikizi_kyousouba_nennrei", 1)
        q += append_query_bt("torihiki_kakaku", 10)

        uniq += append_unique_constraint("kettou_touroku_bangou")
        uniq += append_unique_constraint("syusaisya_shizyou_code")
        uniq += append_unique_constraint("shizyou_kaisai_kaishibi")

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_name_meanings()
        Dim q As String = build_table_initial_query("uma_mei_imi_yurai")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kettou_touroku_bangou", 10)
        q += append_query_bt("uma_mei", 36)
        q += append_query_bt("uma_mei_imi_yurai_text", 64)

        uniq += append_unique_constraint("kettou_touroku_bangou")

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_race_schedule()
        Dim q As String = build_table_initial_query("kaisai_schedule")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("youbi_code", 1)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")

        For i = 1 To 3
            q += append_query_bt("tokubetsu_kyousou_bangou_annai_" & i, 4)
            q += append_query_bt("kyousoumei_hondai_annai_" & i, 60)
            q += append_query_bt("kyousoumei_ryakusyou_10_annai_" & i, 20)
            q += append_query_bt("kyousoumei_ryakusyou_6_annai_" & i, 12)
            q += append_query_bt("kyousoumei_ryakusyou_3_annai_" & i, 6)
            q += append_query_bt("zyuusyou_kaizi_annai_" & i, 3)
            q += append_query_bt("grade_code_annai_" & i, 1)
            q += append_query_bt("kyousou_syubetsu_code_annai_" & i, 2)
            q += append_query_bt("kyousou_kigou_code__annai_" & i, 3)
            q += append_query_bt("zyuuryou_syubetsu_annai_" & i, 1)
            q += append_query_bt("kyori_annai_" & i, 4)
            q += append_query_bt("track_code_annai_" & i, 2)
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_keitou_information()
        Dim q As String = build_table_initial_query("keitou_zyouhou")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("hansyoku_touroku_bangou", 8)
        q += append_query_bt("keitou_ID", 30)
        q += append_query_bt("keitou_mei", 36)
        q += append_query_bt("keitou_setsumei", 0, "TEXT")

        uniq += append_unique_constraint("hansyoku_touroku_bangou")

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_course_information()
        Dim q As String = build_table_initial_query("course_zyouhou")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kyori", 4)
        q += append_query_bt("track_code", 2)
        q += append_query_bt("course_kaisyuu_nen_gappi", 8)
        q += append_query_bt("course_setsumei", 0, "TEXT")

        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kyori")
        uniq += append_unique_constraint("track_code")
        uniq += append_unique_constraint("course_kaisyuu_nen_gappi")

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_mining_prediction_with_time()
        Dim q As String = build_table_initial_query("data_mining_yosou_with_time")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("data_sakusei_zihun", 4)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        For i = 1 To 18
            q += append_query_bt("uma_ban_" & i, 2)
            q += append_query_bt("yosou_souha_time_" & i, 5)
            q += append_query_bt("yosou_gosa_plus_" & i, 4)
            q += append_query_bt("yosou_gosa_minus_" & i, 4)
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)
    End Function

    Private Function build_table_mining_prediction_with_race()
        Dim q As String = build_table_initial_query("data_mining_yosou_with_race")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("data_sakusei_zihun", 4)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        For i = 1 To 18
            q += append_query_bt("uma_ban_" & i, 2)
            q += append_query_bt("yosou_score_" & i, 4)
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_zyuusyousiki()
        Dim q As String = build_table_initial_query("zyuusyoushiki_win5")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("yobi_1", 2)

        q += append_query_bt("yobi_2", 6)
        q += append_query_bt("zyuusyoushiki_hatsubai_hyousuu", 11)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")

        For i = 1 To 5
            q += append_query_bt("race_" & i & "_keibazyou_code", 2)
            q += append_query_bt("race_" & i & "_kaisai_kai", 2)
            q += append_query_bt("race_" & i & "_kaisai_nichime", 2)
            q += append_query_bt("race_" & i & "_race_bangou", 2)
            q += append_query_bt("race_" & i & "_yuukou_hyousuu", 2)
        Next

        q += append_query_bt("henkan_flag", 1)
        q += append_query_bt("huseritsu_flag", 1)
        q += append_query_bt("tekityuu_nashi_flag", 1)

        q += append_query_bt("carry_over_kingaku_syoki", 15)
        q += append_query_bt("carry_over_kingaku_zandaka", 15)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

        build_table_zyuusyoushiki_haraimodoshi()

    End Function

    Private Function build_table_zyuusyoushiki_haraimodoshi()
        Dim q As String = build_table_initial_query("zyuusyoushiki_win5_haraimodoshi")

        q += append_query_bt("zyuusyoushiki_win5_id", 0, "INTEGER")

        q += append_query_bt("kumi_ban", 10)
        q += append_query_bt("zyuusyoushiki_haraimodoshikin", 9)
        q += append_query_bt("tekityuu_hyousuu", 10)

        q = build_table_finalize_query(q)
        execute_query(q)

    End Function

    Private Function build_table_excluded_horses_information()
        Dim q As String = build_table_initial_query("kyousouba_zyogai_zyouhou")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("kettou_touroku_bangou", 10)
        q += append_query_bt("uma_mei", 36)
        q += append_query_bt("syutsuba_touhyou_uketsuke_zyunban", 3)
        q += append_query_bt("syussou_kubun", 1)
        q += append_query_bt("zyogai_zyoutai_kubun", 1)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        uniq += append_unique_constraint("kettou_touroku_bangou")
        uniq += append_unique_constraint("syutsuba_touhyou_uketsuke_zyunban")

        q = build_table_finalize_query(q, uniq)
        execute_query(q)

    End Function

    Private Function build_table_bataizyuu()
        Dim q As String = build_table_initial_query("bataizyuu")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("happyou_gappi_zihun", 8)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        For i = 1 To 18
            q += append_query_bt("uma_ban_" & i, 2)
            q += append_query_bt("uma_mei_" & i, 36)
            q += append_query_bt("bataizyuu_" & i, 3)
            q += append_query_bt("zougen_hugou_" & i, 1)
            q += append_query_bt("zougen_sa_" & i, 3)
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)
    End Function

    Private Function build_table_weather_field_conditions()
        Dim q As String = build_table_initial_query("tenkou_baba_zyoutai")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("happyou_gappi_zihun", 8)
        q += append_query_bt("henkou_syubetsu", 1)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")

        uniq += append_unique_constraint("happyou_gappi_zihun")
        uniq += append_unique_constraint("henkou_syubetsu")

        Dim genzai_henkoumae_types As String() = {"genzai_", "henkoumae_"}

        For Each genzai_henkoumae In genzai_henkoumae_types
            q += append_query_bt(genzai_henkoumae & "tenkou_zyoutai", 1)
            q += append_query_bt(genzai_henkoumae & "baba_zyoutai_shiba", 1)
            q += append_query_bt(genzai_henkoumae & "baba_zyoutai_dirt", 1)
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)
    End Function

    Private Function build_table_syussou_torikesi_kyousou_jogai()
        Dim q As String = build_table_initial_query("syussou_torikeshi_kyousou_zyogai")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("happyou_gappi_zihun", 8)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        q += append_query_bt("uma_ban", 2)
        q += append_query_bt("uma_mei", 36)
        q += append_query_bt("ziyuu_kubun", 3)

        uniq += append_unique_constraint("uma_ban")

        q = build_table_finalize_query(q, uniq)
        execute_query(q)
    End Function

    Private Function build_table_kisyuhenkou()
        Dim q As String = build_table_initial_query("kisyu_henkou")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("happyou_gappi_zihun", 8)
        q += append_query_bt("uma_ban", 2)
        q += append_query_bt("uma_mei", 36)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        uniq += append_unique_constraint("happyou_gappi_zihun")
        uniq += append_unique_constraint("uma_ban")

        Dim henkoumae_henkougo_types As String() = {"henkoumae_", "henkougo_"}

        For Each henkoumae_henkougo In henkoumae_henkougo_types
            q += append_query_bt(henkoumae_henkougo & "hutan_zyuuryou", 3)
            q += append_query_bt(henkoumae_henkougo & "kisyu_code", 5)
            q += append_query_bt(henkoumae_henkougo & "kisyu_mei", 34)
            q += append_query_bt(henkoumae_henkougo & "kisyu_minarai_code", 1)
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)
    End Function

    Private Function build_table_hassouzikoku_henkou()
        Dim q As String = build_table_initial_query("hassou_zikoku_henkou")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("happyou_gappi_zihun", 8)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        Dim henkoumae_henkougo_types As String() = {"henkoumae_", "henkougo_"}

        For Each henkoumae_henkougo In henkoumae_henkougo_types
            q += append_query_bt(henkoumae_henkougo & "hassou_zikoku", 3)
        Next

        q = build_table_finalize_query(q, uniq)
        execute_query(q)
    End Function

    Private Function build_table_course_henkou()
        Dim q As String = build_table_initial_query("course_henkou")
        Dim uniq As String = ""

        q += append_query_bt("record_syubetsu_id", 2)
        q += append_query_bt("data_kubun", 1)
        q += append_query_bt("data_sakusei_nen_gappi", 8)
        q += append_query_bt("kaisai_nen", 4)
        q += append_query_bt("kaisai_gappi", 4)
        q += append_query_bt("keibazyou_code", 2)
        q += append_query_bt("kaisai_kai", 2)
        q += append_query_bt("kaisai_nichime", 2)
        q += append_query_bt("race_bangou", 2)
        q += append_query_bt("happyou_gappi_zihun", 8)

        uniq += append_unique_constraint("kaisai_nen")
        uniq += append_unique_constraint("kaisai_gappi")
        uniq += append_unique_constraint("keibazyou_code")
        uniq += append_unique_constraint("kaisai_kai")
        uniq += append_unique_constraint("kaisai_nichime")
        uniq += append_unique_constraint("race_bangou")

        Dim henkoumae_henkougo_types As String() = {"henkoumae_", "henkougo_"}

        For Each henkoumae_henkougo In henkoumae_henkougo_types
            q += append_query_bt(henkoumae_henkougo & "kyori", 4)
            q += append_query_bt(henkoumae_henkougo & "track_code", 2)
        Next

        q += append_query_bt("ziyuu_kubun", 1)

        q = build_table_finalize_query(q, uniq)
        execute_query(q)
    End Function

End Class
