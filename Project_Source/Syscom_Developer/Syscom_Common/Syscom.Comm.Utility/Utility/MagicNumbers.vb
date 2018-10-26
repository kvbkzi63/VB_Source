Public Class MagicNumbers

#Region "共用(CMN_COD_FILE)"
    ''' <summary>
    ''' 定義所有的類別 譬如性別 教育程度 等等~
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum TYPE  '請記得修改下方 對應的 SYSMODLIST
        SEX = 0   '性別
        EDU       '教育程度(學歷)
        PAY       '繳費方式
        IDENTITY  '身份別
        TOF       '是或否
        DC        'DC 註記   有效無效
        VIP       'VIP註記   VIP
        OCCUPATION '目前職業
        CARING_MANNER '關懷方式
        TITLE         '稱謂
        DISCOUNT_IDENTITY   '優待身份
        APPOINTMENT_SOURCE  '預約來源
        BED_TYPE            '病床別
        APPOINTMENT_STATUS  '預約狀態
        PAY_STATUS          '繳費狀態
        MARITAL_STATUS      '婚姻狀態
        REPORT_RECEIVE      '報告領取方式
        APPOINTMENT_CANCEL_REASON   '預約刪除原因
        APPOINTMENT_DelOrRej        '預約延檢拒檢狀態
        APPOINTMENT_CATEGORY        '健檢類別
        STUS                        '健檢狀態
        PAYS
        MEDICAL_ORDER_CATEGORY  '醫令類別
        PPF_CATEGORY            '抽成類別
        CMYN        '公用是否註記
        REPT        '收據回收方式
        MPAY        '付款方式
        INPUT_TYPE  '輸入報告值型態
        RPDR        '顯示規則
        CNC_TITLE   '稱謂(護理)
        CHCA        '醫令類別
        DECISION_FLAG   '自行判斷碼
        HAVE_OR_NOT     '有或無
        ROOM_CATEGORY   '房間類別
        COST_OWNER      '費用歸屬
        LIMIT_CATEGORY  '限額類別
        PRINT_RPTTYPE   '報告列印類型
        PRINT_FORMAT    '表單列印格式
        FORM_APART      '表單拆單原則
        DEVIL_DEPT      '表單傳送單位
        VESSEL_NO       '容器代碼
        SAMPLE_NO       '檢體代碼
        HTML            'HTML表單物件
        HTDP            'HTML表單物件標籤文字顯示位置
        LAN            '語系
        MRAC            '病歷摘要類型
        OPSR            '意見來源
        OPCT            '意見類別
    End Enum

    '以下分別對應CMN_CODE_FILE 裡面的SYSTEM_NO, MODULE_NO欄位
    ''' <summary>
    ''' 定義類型中所需塞入的系統和模組代碼
    ''' </summary>
    ''' <remarks>...是要加註解 要多中文就多一column append在後</remarks>
    Private Shared SYSMODLIST(,) As String = { _
        {"CMN", "MSEX", "性別", "SEX"}, _
        {"CMN", "MEDU", "教育程度(學歷)", "EDU"}, _
        {"CMN", "MPAY", "繳費方式", "PAY"}, _
        {"CMN", "IDTY", "身份別", "IDENTITY"}, _
        {"CMN", "MTOF", "是或否", "TOF"}, _
        {"CMN", "DCYN", "DC 註記", "DC"}, _
        {"CMN", "MVIP", "VIP註記", "VIP"}, _
        {"CMN", "OCPA", "目前職業", "OCCUPATION"}, _
        {"CMN", "CARE", "關懷方式", "CARING_MANNER"}, _
        {"CMN", "TITL", "稱謂", "TITLE"}, _
        {"CMN", "DCID", "優待身份", "DISCOUNT_IDENTITY"}, _
        {"CMN", "APSR", "預約來源", "APPOINTMENT_SOURCE"}, _
        {"CMN", "BEDT", "病床別", "BED_TYPE"}, _
        {"CMN", "APST", "預約狀態", "APPOINTMENT_STATUS"}, _
        {"CMN", "PAYS", "繳費狀態", "PAY_STATUS"}, _
        {"CMN", "MARS", "婚姻狀態", "MARITAL_STATUS"}, _
        {"HEM", "RPRV", "報告領取方式", "REPORT_RECEIVE"}, _
        {"HEM", "CALR", "預約刪除原因", "APPOINTMENT_CANCEL_REASON"}, _
        {"HEM", "CHDX", "預約延檢拒檢狀態", "APPOINTMENT_DelOrRej"}, _
        {"HEM", "APCA", "健檢類別", "APPOINTMENT_CATEGORY"}, _
        {"HEM", "STUS", "健檢狀態", "STUS"}, _
        {"HEM", "PAYS", "繳費狀態", "PAYS"}, _
        {"HEM", "MOC", "醫令類別", "MEDICAL_ORDER_CATEGORY"}, _
        {"HEM", "PPFC", "抽成類別", "PPF_CATEGORY"}, _
        {"CMN", "CMYN", "公用是否註記", "CMYN"}, _
        {"HEM", "REPT", "收據回收方式", "REPT"}, _
        {"CMN", "MPAY", "付款方式", "MPAY"}, _
        {"HEM", "INTY", "輸入報告值型態", "INPUT_TYPE"}, _
        {"HEM", "RPDR", "顯示規則", "RPDR"}, _
        {"CNC", "TITL", "稱謂", "TITLE"}, _
        {"HEM", "CHCA", "醫令類別", "CHCA"}, _
        {"HEM", "DEFL", "自行判斷碼", "DECISION_FLAG"}, _
        {"CMN", "HONT", "有或無", "HAVE_OR_NOT"}, _
        {"HEM", "ROMC", "房間類別", "ROOM_CATEGORY"}, _
        {"HEM", "CTOR", "費用歸屬", "COST_OWNER"}, _
        {"HEM", "RSCT", "限額類別", "LIMIT_CATEGORY"}, _
        {"HEM", "PRRP", "報告列印類型", "PRINT_RPTTYPE"}, _
        {"HEM", "PRFO", "表單列印格式", "PRINT_FORMAT"}, _
        {"HEM", "FOAP", "表單拆單原則", "FORM_APART"}, _
        {"HEM", "DEDE", "表單傳送單位", "DEVIL_DEPT"}, _
        {"HEM", "VENO", "容器代碼", "VESSEL_NO"}, _
        {"HEM", "SANO", "檢體代碼", "SAMPLE_NO"}, _
        {"CNC", "HTML", "HTML表單物件", "HTML"}, _
        {"CNC", "HTDP", "HTML表單物件標籤文字顯示位置", "HTDP"}, _
        {"CMN", "LAN", "語系", "Language"}, _
        {"HEM", "MRAC", "病歷摘要分類", "MRAC"}, _
        {"HEM", "OPSR", "意見來源", "OPSR"}, _
        {"HEM", "OPCT", "意見類別", "OPCT"} _
        }

    Public Shared Function getSysNo(ByVal typ As Integer) As String
        Return SYSMODLIST(typ, 0)
    End Function
    Public Shared Function getModNo(ByVal typ As Integer) As String
        Return SYSMODLIST(typ, 1)
    End Function
    Public Shared Function getModName(ByVal typ As Integer) As String
        Return SYSMODLIST(typ, 2)
    End Function

    '以下就真的要對應CMN_CODE_FILE 裡面的CODE_NO欄位
    Public Shared CODE_NO_YES As String = "Y" 'YES!
    Public Shared CODE_NO_NO As String = "N" 'NO!
    Public Shared CODE_NO_MALE As String = "M" '性別男
    Public Shared CODE_NO_FEMALE As String = "F" '性別女
    Public Shared CODE_NO_ALL As String = "+" '性別不分
    Public Shared CODE_NO_UNIVERSITY As String = "01" '大學程度

    '是或否
    Public Shared CODE_NO_TRUE As String = "1"   '是
    Public Shared CODE_NO_FALSE As String = "0"  '否

    '身份別
    Public Shared CODE_NO_SINGLE As String = "1" '個人
    Public Shared CODE_NO_GROUP As String = "2" '團體
    Public Shared CODE_NO_GROUP_COMPANY_EMPLOYEE As String = "2" '團體-公司員工'949191
    Public Shared CODE_NO_GROUP_COMPANY_FAMILY As String = "3" '團體-公司眷屬'949191
    Public Shared CODE_NO_GROUP_COMPANY_FRIEND As String = "4" '團體-自組團體'949191
    Public Shared CODE_NO_GROUP_COMPANY_FRIEND_YES As String = "Y" '團體-自組團體flage'949191

    '套裝類型'949191
    Public Shared CODE_NO_EXCLUSIVE_NO As String = "N"         '一般套裝
    Public Shared CODE_NO_EXCLUSIVE_YES As String = "Y"        '專屬套裝
    Public Shared CODE_NO_ExclusivePackage_YES As String = "Y" '簽約專屬套裝
    Public Shared CODE_NO_ExclusivePackage_No As String = "N"  '簽約專屬套裝
    Public Shared CODE_NO_PackageIdentityId As String = "1"    '套裝身份代碼'20110314
    Public Shared CODE_NO_AttributePackageage As String = "1"    '套裝代碼'20110314
    Public Shared CODE_NO_AttributePackageageInclude As String = "2"    '套裝內含代碼'20110314
    Public Shared CODE_NO_AttributeOptional As String = "3"    '加作代碼'20110314

    '是否DC
    Public Shared CODE_NO_DC_YES As String = "Y" '無效(作廢)
    Public Shared CODE_NO_DC_NO As String = "N" '有效
    '關懷方式
    Public Shared CODE_NO_REJECT As String = "01" '拒絕
    Public Shared CODE_NO_EMAIL As String = "02" 'E-mail
    Public Shared CODE_NO_POST As String = "03" '郵件
    Public Shared CODE_NO_NEWS As String = "04" '簡訊
    Public Shared CODE_NO_TEL As String = "05" '電話
    '婚姻狀態
    Public Shared CODE_NO_MARRY_YES As String = "1" '已婚
    Public Shared CODE_NO_MARRY_NO As String = "2" '未婚
    '病床別
    Public Shared CODE_NO_BEDT_SINGLE As String = "1" '單人
    Public Shared CODE_NO_BEDT_DOUBLE As String = "2" '雙人
    '預約來源
    Public Shared CODE_NO_APSR_LOCALE As String = "1" '現場
    Public Shared CODE_NO_APSR_GROUP As String = "5" '團檢匯入
    Public Shared CODE_NO_APSR_NET As String = "4"   '網路預約
    '繳費狀態 
    Public Shared CODE_NO_PAYS_NO As String = "N" '未繳
    Public Shared CODE_NO_PAYS_YES As String = "Y" '已繳

    '報告領取方式
    Public Shared CODE_NO_RPRV_LOCALE As String = "0" '現場
    Public Shared CODE_NO_RPRV_POST As String = "1" '郵寄

    '預約狀態
    '0.初始化狀態,10.預約保留,20.預約確認,21.已寄發資料袋,22.已寄發瀉劑,25.已拉表(產生檢驗單、給床位),30.繳費,40.報到,45.報告異動,50.住院醫師報告,60.主治醫師報告,70.寄送報告,80.結案,99.作廢
    Public Shared CODE_NO_APP_INITIAL As Integer = 0
    Public Shared CODE_NO_APP_RESERVED As Integer = 10
    Public Shared CODE_NO_APP_CONFIRM As Integer = 20
    Public Shared CODE_NO_SENT_DATA As Integer = 21
    Public Shared CODE_NO_SNED_CATHARTIC As Integer = 22
    Public Shared CODE_NO_CREATE_LIST As Integer = 25
    Public Shared CODE_NO_ALREADY_PAY As Integer = 30
    Public Shared CODE_NO_CHECKIN As Integer = 40
    Public Shared CODE_NO_REPORT_CHANGE As Integer = 45
    Public Shared CODE_NO_RESIDENTS_REPORTED As Integer = 50
    Public Shared CODE_NO_ATTENDING_PHYSICIAN_REPORTED As Integer = 60
    Public Shared CODE_NO_REPORT_MAILED As Integer = 70
    Public Shared CODE_NO_APP_CLOSED As Integer = 80
    Public Shared CODE_NO_APP_CANCEL As Integer = 99
    '預約延檢拒檢狀態
    Public Shared CODE_NO_DERE_DELAY As String = "D" '延檢
    Public Shared CODE_NO_DERE_REJ As String = "X" '拒檢
    '物件狀態
    '1.TextBox , 2. RichTextBox , 3. CheckBox , 4. ComboBox(片語複選) , 5. ComboBox(診斷複選) , 6. ComboBox(片語單選) , 7. ComboBox(診斷單選) , 8. RadioButton , 9. 特殊處理
    '1 TextBox,2. RichTextBox,3. CheckBox,4. ComboBox.5
    Public Shared CODE_NO_TextBox As Integer = 1                    '一般TextBox輸入
    Public Shared CODE_NO_RichTextBox As Integer = 2                'RichTextBox輸入
    Public Shared CODE_NO_CheckBox As Integer = 3                   'c
    Public Shared CODE_NO_ComboBox_Phrase As Integer = 4            '複選片語檔Cbo
    Public Shared CODE_NO_ComboBox_dinagose As Integer = 5          '複選診斷檔Cbo
    Public Shared CODE_NO_ComboBox_Normal As Integer = 6            '單選診斷檔Cbo
    Public Shared CODE_NO_ComboBox_NormalD As Integer = 7           '單選片語檔Cbo
    Public Shared CODE_NO_RadioButton As Integer = 8                'RadioButton
    Public Shared CODE_NO_Special As Integer = 9                    '特殊處理
    Public Shared CODE_NO_TextBox_Phase As String = "Q"                    'TextBox 帶入片語


    '健檢類別
    Public Shared CODE_NO_HCK_HOSPITAL As String = "01"             '住院健檢
    Public Shared CODE_NO_HCK_OUTPATIENT_SERVICE As String = "02"   '門診健檢
    Public Shared CODE_NO_HCK_OCCUPATION As String = "03"           '職業健檢
    Public Shared CODE_NO_HCK_NEWBORN As String = "04"              '新生健檢
    '醫令類別
    Public Shared CODE_NO_NOT_CLASSIFIED As Integer = 0           '不分
    Public Shared CODE_NO_INCLUDE As Integer = 1                  '內含套裝
    Public Shared CODE_NO_ADD As Integer = 2                      '加作
    '抽成類別
    Public Shared CODE_NO_DR As Integer = 2                       '醫師抽成
    Public Shared CODE_NO_DE As Integer = 1                       '科室抽成
    '顯示規則
    Public Shared CODE_NO_UNCHANGELINE As Integer = 0            '不換行
    Public Shared CODE_NO_CHANGELINE As Integer = 1            '換行
    '判讀結果
    Public Shared CODE_NO_HIGH As String = "H"                      '高
    Public Shared CODE_NO_LOW As String = "L"

    '費用類型(1:套裝費用,2.套餐費用,3.加作項目費用)
    Public Shared CODE_FEE_PACKAGE As Integer = 1
    Public Shared CODE_FEE_SUITE As Integer = 2
    Public Shared CODE_FEE_PLUS As Integer = 3

    '繳費註記
    Public Shared CODE_PAYMENT_INVALID As String = "X"    '作廢

    '收據分單
    Public Shared CODE_RECEIPT_N As String = "N"    '不拆單
    Public Shared CODE_RECEIPT_A As String = "A"    'A單
    Public Shared CODE_RECEIPT_B As String = "B"    'B單
    Public Shared CODE_RECEIPT_O As String = "O"    '其他加作費用

    '收據狀態
    Public Shared Paid_YES As String = "1" '已結清
    Public Shared Paid_NO As String = "2" '未結清

    '收據類別
    Public Shared REPT_CATEGORY_FORMAL As String = "1" '正式收據
    Public Shared REPT_CATEGORY_TEMP As String = "2" '暫收據

    '付款方式
    Public Shared Code_Pay_ATM As String = "1"  'ATM
    Public Shared Code_Pay_creadit As String = "2"  '信用卡
    Public Shared Code_Pay_cash As String = "3"  '現金
    Public Shared Code_Pay_check As String = "4" '支票
    Public Shared Code_Pay_Post As String = "5" '郵政畫撥
    Public Shared Code_Pay_gift As String = "6" '禮券

    '確認狀態
    Public Shared CODE_CONFIRM_Y As String = "Y" '確認
    Public Shared CODE_CONFIRM_T As String = "T"  '暫存

    '醫令類別(可能會和ppf那邊的項目不同所以現在分開)
    Public Shared CODE_NO_INCLUDE_PACKAGE As Integer = 1           '內含套裝
    Public Shared CODE_NO_PLUS As Integer = 2                      '加作

    '自行判斷碼
    Public Shared CODE_NO_Integer As String = "I"       '數字
    Public Shared CODE_NO_String As String = "S"        '文字

    '員工類別
    Public Shared CODE_STAFF_AP As String = "1"         '主治醫師
    Public Shared CODE_STAFF_RN As String = "2"         '住院醫師


    ''房間類別(重複，請用CODE_NO_BEDT_SINGLE)
    'Public Shared CODE_ROOM_SINGLE As Integer = 1       '單人房
    'Public Shared CODE_ROOM_DOUBLE As Integer = 2       '雙人房

    '成本中心
    Public Shared CODE_COST_CENTER As String = "HEM005"

    '列印表類
    Public Shared CODE_PRINT_MASTER As String = "1"     '總表
    Public Shared CODE_PRINT_DETAIL As String = "2"     '明細表

    '報告列印類型
    Public Shared CODE_PRINT_RPTTYPE_A As String = "1"  '列印報告項目及內容(如個人疾病史)
    Public Shared CODE_PRINT_RPTTYPE_B As String = "2"  '列印報告項目+參考值+兩次前次資料(如理學檢查) 
    Public Shared CODE_PRINT_RPTTYPE_C As String = "3"  '列印報告項目+兩次前次資料(如超音波)

    '表單列印格式
    Public Shared CODE_PRINT_FORMAT_A As String = "1"  '檢驗單
    Public Shared CODE_PRINT_FORMAT_B As String = "2"  '檢查單

    '表單拆單原則
    Public Shared CODE_FORM_APART_A As String = "1"  'By檢體+容器拆單
    Public Shared CODE_FORM_APART_B As String = "2"  'By醫令拆單
    Public Shared CODE_FORM_APART_C As String = "3"  'By表單拆單
    Public Shared CODE_FORM_APART_D As String = "4"  'By分單註記拆單
    Public Shared CODE_FORM_APART_E As String = "5"  'By檢體+容器+分單註記拆單

    '表單傳送單位
    Public Shared CODE_DEVIL_DEPT_A As String = "1"  'LIS系統

    '容器代碼
    Public Shared CODE_VESSEL_NO_1 As Integer = 1  '紅頭
    Public Shared CODE_VESSEL_NO_2 As Integer = 2  '紫頭
    Public Shared CODE_VESSEL_NO_3 As Integer = 3  '薄層抹片保存液
    Public Shared CODE_VESSEL_NO_4 As Integer = 4  '微量紫頭管
    Public Shared CODE_VESSEL_NO_5 As Integer = 5  '天藍頭
    Public Shared CODE_VESSEL_NO_6 As Integer = 6  '灰頭
    Public Shared CODE_VESSEL_NO_7 As Integer = 7  '披衣菌收集小瓶
    Public Shared CODE_VESSEL_NO_8 As Integer = 8  '黑頭
    Public Shared CODE_VESSEL_NO_9 As Integer = 9  '淺綠頭(gel)
    Public Shared CODE_VESSEL_NO_10 As Integer = 10  '黃頭
    Public Shared CODE_VESSEL_NO_11 As Integer = 11  '黑頭無菌試管
    Public Shared CODE_VESSEL_NO_12 As Integer = 12  '有蓋定量離心管(尿液收集管)
    Public Shared CODE_VESSEL_NO_13 As Integer = 13  '糞便收集盒(含蓋附匙)
    Public Shared CODE_VESSEL_NO_14 As Integer = 14  '無菌盒
    Public Shared CODE_VESSEL_NO_15 As Integer = 15  '無菌針筒
    Public Shared CODE_VESSEL_NO_16 As Integer = 16  '橙黃頭SST管
    Public Shared CODE_VESSEL_NO_17 As Integer = 17  '藍頭綠標管
    Public Shared CODE_VESSEL_NO_18 As Integer = 18  '白頭尖底塑膠管
    Public Shared CODE_VESSEL_NO_19 As Integer = 19  '1.5 mL 微量離心管
    Public Shared CODE_VESSEL_NO_20 As Integer = 20  '藍頭紅標管
    Public Shared CODE_VESSEL_NO_21 As Integer = 21  '血液專用培養瓶_藍紫頭
    Public Shared CODE_VESSEL_NO_22 As Integer = 22  '有蓋紅色液體
    Public Shared CODE_VESSEL_NO_23 As Integer = 23  '藍頭傳送管(嗜氧)
    Public Shared CODE_VESSEL_NO_24 As Integer = 24  '紅頭傳送管(厭氧)
    Public Shared CODE_VESSEL_NO_25 As Integer = 25  '病毒培養收集瓶
    Public Shared CODE_VESSEL_NO_26 As Integer = 26  '夾鏈式塑膠袋
    Public Shared CODE_VESSEL_NO_27 As Integer = 27  '粘液收集套
    Public Shared CODE_VESSEL_NO_28 As Integer = 28  '塑膠/玻璃固定缸
    Public Shared CODE_VESSEL_NO_29 As Integer = 29  '電鏡固定瓶(含4%Glutaraldehyde固定液)
    Public Shared CODE_VESSEL_NO_30 As Integer = 30  'heparin抗凝劑及10cc無菌針筒
    Public Shared CODE_VESSEL_NO_31 As Integer = 31  '染色體檢查細胞培養液
    Public Shared CODE_VESSEL_NO_32 As Integer = 32  '真空吸引瓶
    Public Shared CODE_VESSEL_NO_33 As Integer = 33  '綠頭
    Public Shared CODE_VESSEL_NO_34 As Integer = 34  'heparin抗凝劑及20 mL無菌針筒
    Public Shared CODE_VESSEL_NO_35 As Integer = 35  '10 mL紫頭
    Public Shared CODE_VESSEL_NO_36 As Integer = 36  '糞便收集盒(含蓋附匙)
    Public Shared CODE_VESSEL_NO_37 As Integer = 37  '20mL無菌空針
    Public Shared CODE_VESSEL_NO_38 As Integer = 38  '血液氣體採樣針
    Public Shared CODE_VESSEL_NO_39 As Integer = 39  '抗生素治療後之血液培養瓶
    Public Shared CODE_VESSEL_NO_40 As Integer = 40  '小孩專用血液培養瓶
    Public Shared CODE_VESSEL_NO_41 As Integer = 41  '血液專用培養瓶_紅頭
    Public Shared CODE_VESSEL_NO_42 As Integer = 42  '不需容器

    '檢體代碼
    Public Shared CODE_SAMPLE_NO_0 As String = "0"  '不分
    Public Shared CODE_SAMPLE_NO_1 As String = "1"  '全血
    Public Shared CODE_SAMPLE_NO_2 As String = "2"  '血漿
    Public Shared CODE_SAMPLE_NO_3 As String = "3"  '血清
    Public Shared CODE_SAMPLE_NO_4 As String = "4"  '尿液
    Public Shared CODE_SAMPLE_NO_5 As String = "5"  '糞便
    Public Shared CODE_SAMPLE_NO_6 As String = "6"  '腦脊髓液
    Public Shared CODE_SAMPLE_NO_7 As String = "7"  '胸水
    Public Shared CODE_SAMPLE_NO_8 As String = "8"  '腹水
    Public Shared CODE_SAMPLE_NO_9 As String = "9"  '胃液
    Public Shared CODE_SAMPLE_NO_10 As String = "10"  '血液
    Public Shared CODE_SAMPLE_NO_11 As String = "11"  '十二指腸液
    Public Shared CODE_SAMPLE_NO_12 As String = "12"  '關節滑液
    Public Shared CODE_SAMPLE_NO_13 As String = "13"  '精液
    Public Shared CODE_SAMPLE_NO_14 As String = "14"  '痰
    Public Shared CODE_SAMPLE_NO_15 As String = "15"  '傷口
    Public Shared CODE_SAMPLE_NO_16 As String = "16"  '心胞膜積水
    Public Shared CODE_SAMPLE_NO_17 As String = "17"  '新鮮血抹片
    Public Shared CODE_SAMPLE_NO_18 As String = "18"  '抹片
    Public Shared CODE_SAMPLE_NO_19 As String = "19"  '羊水
    Public Shared CODE_SAMPLE_NO_20 As String = "20"  '膿
    Public Shared CODE_SAMPLE_NO_21 As String = "21"  '分泌物
    Public Shared CODE_SAMPLE_NO_22 As String = "22"  '生殖道檢體
    Public Shared CODE_SAMPLE_NO_23 As String = "23"  '臍帶血液
    Public Shared CODE_SAMPLE_NO_24 As String = "24"  '組織
    Public Shared CODE_SAMPLE_NO_25 As String = "25"  '喉嚨拭子
    Public Shared CODE_SAMPLE_NO_26 As String = "26"  '引流管
    Public Shared CODE_SAMPLE_NO_27 As String = "27"  '臍帶血清
    Public Shared CODE_SAMPLE_NO_28 As String = "28"  '骨髓
    Public Shared CODE_SAMPLE_NO_29 As String = "29"  '淋巴結
    Public Shared CODE_SAMPLE_NO_30 As String = "30"  '唾液
    Public Shared CODE_SAMPLE_NO_31 As String = "31"  '子宮頸抹片
    Public Shared CODE_SAMPLE_NO_32 As String = "32"  '脾臟
    Public Shared CODE_SAMPLE_NO_33 As String = "33"  '絨毛膜
    Public Shared CODE_SAMPLE_NO_34 As String = "34"  '臍帶
    Public Shared CODE_SAMPLE_NO_35 As String = "35"  '水?拭子
    Public Shared CODE_SAMPLE_NO_36 As String = "36"  '肛門拭子
    Public Shared CODE_SAMPLE_NO_37 As String = "37"  '肝
    Public Shared CODE_SAMPLE_NO_38 As String = "38"  '肺
    Public Shared CODE_SAMPLE_NO_39 As String = "39"  '膽汁
    Public Shared CODE_SAMPLE_NO_40 As String = "40"  '總膽管
    Public Shared CODE_SAMPLE_NO_41 As String = "41"  '眼睛角膜
    Public Shared CODE_SAMPLE_NO_42 As String = "42"  '大體解剖
    Public Shared CODE_SAMPLE_NO_43 As String = "43"  '屍體切片
    Public Shared CODE_SAMPLE_NO_44 As String = "44"  '胎盤
    Public Shared CODE_SAMPLE_NO_45 As String = "45"  '鼻
    Public Shared CODE_SAMPLE_NO_46 As String = "46"  '頸部
    Public Shared CODE_SAMPLE_NO_47 As String = "47"  '眼睛結膜
    Public Shared CODE_SAMPLE_NO_48 As String = "48"  '眼睛鞏膜
    Public Shared CODE_SAMPLE_NO_49 As String = "49"  '胰臟
    Public Shared CODE_SAMPLE_NO_50 As String = "50"  '甲狀腺
    Public Shared CODE_SAMPLE_NO_51 As String = "51"  '乳房抽取液
    Public Shared CODE_SAMPLE_NO_52 As String = "52"  '皮膚
    Public Shared CODE_SAMPLE_NO_53 As String = "53"  '皮膚組織
    Public Shared CODE_SAMPLE_NO_54 As String = "54"  '支氣管肺泡灌洗液
    Public Shared CODE_SAMPLE_NO_55 As String = "55"  '腫塊
    Public Shared CODE_SAMPLE_NO_56 As String = "56"  '支氣管刷出物
    Public Shared CODE_SAMPLE_NO_57 As String = "57"  '支氣管沖刷液
    Public Shared CODE_SAMPLE_NO_58 As String = "58"  '鼻咽分泌物
    Public Shared CODE_SAMPLE_NO_59 As String = "59"  '縱膈膜液
    Public Shared CODE_SAMPLE_NO_60 As String = "60"  '其他體液
    Public Shared CODE_SAMPLE_NO_61 As String = "61"  'PCN
    Public Shared CODE_SAMPLE_NO_62 As String = "62"  '中段尿
    Public Shared CODE_SAMPLE_NO_63 As String = "63"  '導尿
    Public Shared CODE_SAMPLE_NO_64 As String = "64"  '穿刺尿
    Public Shared CODE_SAMPLE_NO_65 As String = "65"  '透析液
    Public Shared CODE_SAMPLE_NO_66 As String = "66"  ' 器官
    Public Shared CODE_SAMPLE_NO_67 As String = "67"  '活體組織
    Public Shared CODE_SAMPLE_NO_68 As String = "68"  '子宮頸拭子
    Public Shared CODE_SAMPLE_NO_69 As String = "69"  '尿道拭子
    Public Shared CODE_SAMPLE_NO_70 As String = "70"  '眼睛結膜拭子
    Public Shared CODE_SAMPLE_NO_71 As String = "71"  '24小時尿
    Public Shared CODE_SAMPLE_NO_99 As String = "99"  '其他

    '語系
    Public Shared CODE_Language_NO_1 As String = "1"  '中文
    Public Shared CODE_Language_NO_2 As String = "2"  '英文
    Public Shared CODE_Language_NO_3 As String = "3"  '中英文

    '異常值檢合類型(1 : 報告值輸入警示 , 2 : 自動診斷判讀 )
    Public Shared CODE_Chk_Type_1 As String = "1"
    Public Shared CODE_Chk_Type_2 As String = "2"

#End Region

#Region "20091121 健檢系統 by yaya"
    '病歷摘要分類
    Public Shared CODE_MRAC_NO_1 As String = "1"        '主訴與過去病史
    Public Shared CODE_MRAC_NO_2 As String = "2"        '體檢發現
    Public Shared CODE_MRAC_NO_3 As String = "3"        '各科摘要
    Public Shared CODE_MRAC_NO_4 As String = "4"        '檢驗報告
    Public Shared CODE_MRAC_NO_5 As String = "5"        '比照各科照會

    '新生健檢個案狀態
    '00:健檢取消 10:已預約 20:已報到收費 30:理學檢查輸入完成 40:醫師總評完成 50:報告寄發
    Public Shared CODE_NO_OHM_Cancle As String = "00"
    Public Shared CODE_NO_OHM_Already_Reservation As String = "10"
    Public Shared CODE_NO_OHM_ALREADY_CONFIRM As String = "20"
    Public Shared CODE_NO_OHM_RptKeyIN As String = "30"
    Public Shared CODE_NO_OHM_DrDone As String = "40"
    Public Shared CODE_NO_OHM_SendRpt As String = "50"

    '限額類別
    Public Shared CODE_NO_LIMIT_TOTAL As String = "1"   '總人數
    Public Shared CODE_NO_LIMIT_SINGLE As String = "2"  '單人床
    Public Shared CODE_NO_LIMIT_DOUBLE As String = "3"  '雙人床
    Public Shared CODE_NO_LIMIT_NONBED As String = "4"  '不佔床
    '限額類別
    Public Shared Function CODE_NO_LIMIT_DICT() As Dictionary(Of String, String)
        Dim _limit_dict As New Dictionary(Of String, String)
        _limit_dict.Add(CODE_NO_LIMIT_TOTAL, "總人數")
        _limit_dict.Add(CODE_NO_LIMIT_SINGLE, "單人床")
        _limit_dict.Add(CODE_NO_LIMIT_DOUBLE, "雙人床")
        _limit_dict.Add(CODE_NO_LIMIT_NONBED, "不佔床")
        Return _limit_dict
    End Function
    '住院健檢套裝類別
    Public Shared CODE_PACKAGE_CATEGORY_DayNight As String = "1"        '一日一夜
    Public Shared CODE_PACKAGE_CATEGORY_Day As String = "2"             '一日
    Public Shared CODE_PACKAGE_CATEGORY_HalfDay As String = "3"         '半日
    Public Shared CODE_PACKAGE_CATEGORY_ProtectHeart As String = "4"    '護心
    ''' <summary>
    ''' 瀉劑
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared CODE_NO_CATHARTIC As String = "507525"
    Public Shared CODE_NO_FLEET As String = "707933"

    ''' <summary>
    ''' 調劑費
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared CODE_NO_MIX_FEE As String = "11C010"

    ''' <summary>
    ''' 未寄
    ''' </summary>
    ''' <remarks>個案資料查詢列印</remarks>
    Public Shared CODE_NO_UNSENT As String = "0"
    ''' <summary>
    ''' 已寄
    ''' </summary>
    ''' <remarks>個案資料查詢列印</remarks>
    Public Shared CODE_NO_SENT As String = "1"
    ''' <summary>
    ''' 全部
    ''' </summary>
    ''' <remarks>個案資料查詢列印</remarks>
    Public Shared CODE_NO_SENTAll As String = "2"
    ''' <summary>
    ''' 檢驗檢查單不用列印出來的批價項目
    ''' </summary>
    ''' <remarks></remarks>
    ''' 4210103 恢復要列印檢驗查單 (2011/5/20)
    ''' 1600101EKG改為要列印檢查單(fangchen)
    Public Shared NON_PRINT_CHARGE_NO As String = "'4210005','4210021','4210022','4210023','4210024','4210025','1600401','1700118','1700101','1700119','9400601'"

#End Region

#Region "20091121 新生健檢XRay by yaya"
    Public Shared FHM_XRay_Charge_Code As String = "9110101"
    Public Shared FHM_XRay_Exam_Item_Code As String = "Xray"
    Public Shared FHM_Result_Normal As String = "9110101Xray03"   '正常
    Public Shared FHM_Result_Abnormal As String = "9110101Xray04"   '異常
#End Region

#Region "20091215 住院健檢收據院歸屬"
    Public Shared HEM_Med_Price_Code As String = "5" '藥劑費
    Public Shared HEM_Anes_Price_Code As String = "24" '麻醉費
    Public Shared HEM_Exam_Price_Code As String = "99"    '檢查費
#End Region

#Region "20100201 一般檢查輸入(眼科/牙科/耳鼻喉科/婦科會診)"
    ''' <summary>
    ''' 眼科會診批價碼
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared HEM_EYE_CONSULT_CHARGE_CODE As String = "4210031"
    ''' <summary>
    ''' 耳鼻喉科會診批價碼
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared HEM_ENT_CONSULT_CHARGE_CODE As String = "4210034"
    ''' <summary>
    ''' 牙科會診批價碼
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared HEM_DENTAL_CONSULT_CHARGE_CODE As String = "4210032"
    ''' <summary>
    ''' 婦產科會診批價碼
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared HEM_GYN_CONSULT_CHARGE_CODE As String = "4210033"
    ''' <summary>
    ''' 眼科會診流程站
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared HEM_EYE_STATION_NO As String = "2"
    ''' <summary>
    ''' 耳鼻喉科會診流程站
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared HEM_ENT_STATION_NO As String = "22"
    ''' <summary>
    ''' 牙科會診流程站
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared HEM_DENTAL_STATION_NO As String = "23"
    ''' <summary>
    ''' 婦產科會診流程站
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared HEM_GYN_STATION_NO As String = "24"

#End Region

#Region "20100209 門診健檢報告區塊(Charles)"
    ''' <summary>
    ''' 中文報告
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly OHM_Rpt_Language_CH As String = "C"
    ''' <summary>
    ''' 英文報告
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly OHM_Rpt_Language_EN As String = "E"
#End Region

#Region "20101020 門診健檢報告狀態(Charles)"
    '0-理學報告未完成,1-理學報告已完成,2-已發檢驗報告,待住院醫師總評,3-更改檢驗報告,待住院醫師總評,4-住院醫師已完成總評,5-主治醫師已完成確認,99暫存
    ''' <summary>
    ''' 0-理學報告未完成
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly OHM_Rpt_Status_PH_UnDone As String = "0"
    ''' <summary>
    ''' 1-理學報告已完成
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly OHM_Rpt_Status_PH_Done As String = "1"
    ''' <summary>
    ''' 2-已發檢驗報告,待住院醫師總評
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly OHM_Rpt_Status_LIS_Done As String = "2"
    ''' <summary>
    ''' 3-更改檢驗報告,待住院醫師總評
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly OHM_Rpt_Status_LIS_Change As String = "3"
    ''' <summary>
    ''' 4-住院醫師已完成總評
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly OHM_Rpt_Status_DR_Done As String = "4"
    ''' <summary>
    ''' 5-主治醫師已完成確認
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly OHM_Rpt_Status_VS_Done As String = "5"
    ''' <summary>
    ''' 99--暫存
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly OHM_Rpt_Status_Temporary As String = "99"

#End Region

#Region "20100210 PUB_Syscode/Pub_Order_Price"
    ''' <summary>
    ''' 醫令類型
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared PUB_ORDER_CODE As String = "31"
    ''' <summary>
    ''' 費用項目
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared PUB_FEE_ITEMS As String = "41"
    ''' <summary>
    ''' 自費身分
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Main_Identity_Id_Self As String = "1"
    ''' <summary>
    ''' 健保身分
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Main_Identity_Id_NHI As String = "2"
#End Region

#Region "20100319 by yaya 檢驗檢查單位分機"
    Public Shared GetExUnitTelList As Hashtable = GetExUnitCallData()
    Private Shared Function GetExUnitCallData() As Hashtable
        Dim TelTable As New Hashtable
        TelTable.Add("11C", "4041")
        TelTable.Add("8121", "2652")
        TelTable.Add("8122", "2654")
        TelTable.Add("8130", "2618")
        TelTable.Add("8211", "2612")
        TelTable.Add("8212", "2614")
        TelTable.Add("8213", "2612")
        TelTable.Add("8216", "2614")
        TelTable.Add("8261", "2614")
        TelTable.Add("8263", "2603")
        TelTable.Add("8264", "2640")
        TelTable.Add("8266", "2640")
        TelTable.Add("8267", "2640")
        TelTable.Add("8271", "2614")
        TelTable.Add("8221", "2610")
        TelTable.Add("8222", "2610")
        TelTable.Add("8223", "2610")
        TelTable.Add("8224", "2610")
        TelTable.Add("8262", "2611")
        TelTable.Add("8265", "2611")
        TelTable.Add("8231", "2651")
        TelTable.Add("8236", "2653")
        TelTable.Add("8240", "2656")
        TelTable.Add("8257", "2606、2607")
        TelTable.Add("8259", "2606、2607")
        TelTable.Add("8250", "2606、2607")
        TelTable.Add("8234", "2604")
        TelTable.Add("8290", "2604")
        Return TelTable
    End Function

#End Region

#Region "健檢網頁"
    ''' <summary>
    ''' 意見來源--電話
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared OPSR_TEL As String = "1"
    ''' <summary>
    ''' 意見來源--EMAIL
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared OPSR_EMAIL As String = "2"
    ''' <summary>
    ''' 意見來源--網路
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared OPSR_NET As String = "3"
    ''' <summary>
    ''' 意見來源--傳真
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared OPSR_FAX As String = "4"
    ''' <summary>
    ''' 意見來源--現場
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared OPSR_LOC As String = "5"
    ''' <summary>
    ''' 意見來源--其他
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared OPSR_OTHER As String = "6"
    ''' <summary>
    ''' 意見類別--抱怨
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared OPCT_COMPLAIN As String = "1"
    ''' <summary>
    ''' 意見類別--建議
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared OPCT_ADVICE As String = "2"
    ''' <summary>
    ''' 意見類別--鼓勵
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared OPCT_CHEER As String = "3"
    ''' <summary>
    ''' 意見類別--其他
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared OPCT_OTHER As String = "4"
    ''' <summary>
    ''' 回覆狀態--已回覆
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared CODE_REPAID As String = "1"
    ''' <summary>
    ''' 回覆狀態--未回覆
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared CODE_REPLY_YET As String = "2"
    ''' <summary>
    ''' 回覆狀態--不需回覆
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared CODE_REPlY_NO As String = "3"

    ''' <summary>
    ''' QA資料匯入方式
    ''' </summary>
    ''' <remarks>刪除資料後匯入</remarks>
    Public Shared DELETE_IMPORT As Integer = 0
    ''' <summary>
    ''' QA資料匯入方式
    ''' </summary>
    ''' <remarks>附加原先的資料</remarks>
    Public Shared APPEND_IMPORT As Integer = 1
#End Region




    ''' <summary>
    ''' 更新版本及時通知(ExternalFunction)
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Notify_Deploy As String = "deploy"

    Private Sub New()
    End Sub

#Region "CMN_Code_File Mapping PUB_Syscode"

#Region "性別對應 CMN_Code_File---> PUB_Syscode"
    Public Shared PubSyscodeSex As Hashtable = PubSexMappingData()
    Private Shared Function PubSexMappingData() As Hashtable
        Dim SexTable As New Hashtable
        SexTable.Add("M", "1")  '男
        SexTable.Add("F", "2")  '女
        SexTable.Add("U", "3")  '其他
        Return SexTable
    End Function
#End Region

#Region "性別對應 PUB_Syscode --->CMN_Code_File"
    Public Shared CmncodeSex As Hashtable = CmnSexMappingData()
    Private Shared Function CmnSexMappingData() As Hashtable
        Dim SexTable As New Hashtable
        SexTable.Add("1", "M")  '男
        SexTable.Add("2", "F")  '女
        SexTable.Add("3", "U")  '其他
        Return SexTable
    End Function
#End Region

#Region "婚姻狀況 CMN_Code_File---> PUB_Syscode"
    Public Shared PubSyscodeMarriage As Hashtable = PubMarriageMappingData()
    Private Shared Function PubMarriageMappingData() As Hashtable
        Dim MarriageTable As New Hashtable
        MarriageTable.Add("1", "2")  '已婚
        MarriageTable.Add("2", "1")  '未婚
        MarriageTable.Add("3", "3")  '未知
        Return MarriageTable
    End Function
#End Region
#Region "婚姻狀況 PUB_Syscode --->CMN_Code_File"
    Public Shared CmncodeMarriage As Hashtable = CmnMarriageMappingData()
    Private Shared Function CmnMarriageMappingData() As Hashtable
        Dim MarriageTable As New Hashtable
        MarriageTable.Add("2", "1")  '已婚
        MarriageTable.Add("1", "2")  '未婚
        MarriageTable.Add("3", "3")  '未知
        Return MarriageTable
    End Function
#End Region

#End Region
End Class
