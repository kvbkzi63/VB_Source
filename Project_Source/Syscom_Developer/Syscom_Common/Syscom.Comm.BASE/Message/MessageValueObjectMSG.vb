'/*
'*****************************************************************************
'*
'*    Page/Class Name:  訊息代碼物件 - 延伸類別(訊息)
'*              Title:	MessageValueObject
'*        Description:	訊息代碼與訊息內容清單
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-01-20
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-01-20
'*
'*****************************************************************************
'*/

Partial Public Class MessageValueObject

    ''' <summary>
    ''' 根據 AppConfigUtil 的 語言種類 取得訊息Table
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-7-30</remarks>
    Private Shared Function getMsgTable() As Hashtable
        Select Case AppConfigUtil.AppLanguage
            Case AppConfigUtil.Language.TraditionalChinese
                '繁體中文
                Return getMsgTableTradtional()
            Case AppConfigUtil.Language.SimplifiedChinese
                '簡體中文
                Return getMsgTableSimple()
            Case Else
                '其他
                Return getMsgTableTradtional()
        End Select
    End Function

    ''' <summary>
    ''' 取得繁體中文的訊息Table - 修改需同時修改各種語言
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-7-30</remarks>
    Private Shared Function getMsgTableTradtional() As Hashtable
        Dim msgTable As New Hashtable

        Try
            '==================================================================================================
            '  訊息編碼原則 = 系統代碼（3碼) + 模組代碼（3碼) + 分類碼（3碼) + 序號（3碼) 
            '==================================================================================================  
            ' 系統代碼 (3碼)：根據各系統定義之代碼，例如：掛號系統代碼為REG 
            ' 模組代碼 (3碼)：根據模組內需求之功能實際代碼為原則，例如：CMM表示為公用訊息
            ' 　分類碼 (1碼)：A-Z 共可區分後端26大類訊息，為避免有無法分類之情況，首碼 Z 固定為其它類
            '                 A：與資料庫連結產生之Log　　　　　　B：與使用者互動產生之Log　　
            '                 C：對外部系統互動產生的Log          D：系統內由程式所判定產生之Log
            '                 E：系統內產生的不可預期之Log 　　　 F：File I/O 產生的Log
            '                 Z：其它(無法分類項) 
            ' 　 序號 (3碼)： 001~ 999 ，各分類可容納999種訊息
            '==================================================================================================

            ''===========================================系統共用訊息區========================================
            msgTable.Add("CMMCMMB300", "{0}")
            msgTable.Add("CMMCMMB301", "{0}成功")                       '新增、修改、刪除、查詢、列印、預覽、匯入(XX)...成功
            msgTable.Add("CMMCMMB302", "{0}失敗")                       '新增、修改、刪除、查詢、列印、預覽、匯入(XX)...失敗
            msgTable.Add("CMMCMMB303", "是否確定{0}?")                  '是否確定刪除(離開)?
            msgTable.Add("CMMCMMB304", "尚未選取{0}資料，請選擇")       '尚未選取病患清單資料，請選擇
            msgTable.Add("CMMCMMB305", "{0}不得為空白")                 '診斷代碼不得為空白
            msgTable.Add("CMMCMMB306", "{0}不得小於{1}")                '看診日期迄日不得小於起日
            msgTable.Add("CMMCMMB307", "{0}不得大於{1}")                '看診日期起日不得大於迄日
            msgTable.Add("CMMCMMB308", "該筆記錄已存在{0}，請確認")     '該筆記錄已存在掛號週班表，請確認
            msgTable.Add("CMMCMMB309", "{0}欄位輸入錯誤，{1}")          '繳費金額欄位輸入錯誤，請輸入數字  掛號日期欄位輸入錯誤，請確認
            msgTable.Add("CMMCMMB310", "無符合條件資料被{0}")           '無符合條件資料被修改(刪除)
            msgTable.Add("CMMCMMB311", "尚有所屬{0}資料存在,無法刪除")  '尚有所屬表單醫令明細資料存在，無法刪除
            msgTable.Add("CMMCMMB312", "{0}按鈕啟動失敗，功能無法使用") '執行按鈕啟動失敗，功能無法使用

            msgTable.Add("CMMCMMB314", "{0}不得小於或等於{1}")
            msgTable.Add("CMMCMMB315", "{0}不得大於或等於{1}")
            msgTable.Add("CMMCMMB316", "{0}成功{1}")                    '新增、修改、刪除、查詢、列印、預覽、匯入(XX)...成功 
            msgTable.Add("CMMCMMB317", "{0}失敗{1}")                    '新增、修改、刪除、查詢、列印、預覽、匯入(XX)...成功
            msgTable.Add("CMMCMMB318", "{0}錯誤{1}")

            msgTable.Add("CMMCMMB901", "查詢成功")
            msgTable.Add("CMMCMMB902", "新增成功")
            msgTable.Add("CMMCMMB903", "修改成功")
            msgTable.Add("CMMCMMB904", "刪除成功")
            msgTable.Add("CMMCMMB905", "儲存成功")
            msgTable.Add("CMMCMMB906", "清除成功")
            msgTable.Add("CMMCMMB907", "暫存成功")
            msgTable.Add("CMMCMMB908", "預覽列印成功")
            msgTable.Add("CMMCMMB909", "列印成功")
            msgTable.Add("CMMCMMB940", "匯出成功")
            msgTable.Add("CMMCMMB941", "匯入成功")

            msgTable.Add("CMMCMMB911", "查詢失敗")
            msgTable.Add("CMMCMMB912", "新增失敗")
            msgTable.Add("CMMCMMB913", "修改失敗")
            msgTable.Add("CMMCMMB914", "刪除失敗")
            msgTable.Add("CMMCMMB915", "儲存失敗")
            msgTable.Add("CMMCMMB916", "清除失敗")
            msgTable.Add("CMMCMMB917", "暫存失敗")
            msgTable.Add("CMMCMMB918", "預覽列印失敗")
            msgTable.Add("CMMCMMB919", "列印失敗")
            msgTable.Add("CMMCMMB950", "匯出失敗")
            msgTable.Add("CMMCMMB951", "匯入失敗")


            msgTable.Add("CMMCMMB931", "載入資料失敗")
            msgTable.Add("CMMCMMB932", "是否確定刪除？")
            msgTable.Add("CMMCMMB933", "查無符合條件之資料")            '查無符合條件之資料
            msgTable.Add("CMMCMMB934", "非本人不可修改")

            msgTable.Add("CMMCMMB990", "初始化资料失敗")
            msgTable.Add("CMMCMMB991", "載入服務管理員失敗")
            msgTable.Add("CMMCMMB992", "載入事件管理員(EventManager)失敗")
            msgTable.Add("CMMCMMB993", "關閉事件管理員(EventManager)失敗")
            msgTable.Add("CMMCMMB994", "初始化Cbo失敗")

            msgTable.Add("CMMCMMD001", "系統執行異常")
            msgTable.Add("CMMCMMD002", "Delegate 執行異常")
            msgTable.Add("CMMCMMD003", "WCF Service 執行異常")
            msgTable.Add("CMMCMMD004", "Client Service 執行異常")

            '===========================================ARM系統訊息區=========================================
            msgTable.Add("ARMCMME001", "登入失敗：{0}")
            msgTable.Add("ARMCMME002", "帳號過期")
            msgTable.Add("ARMCMME003", "密碼過期{0}")
            msgTable.Add("ARMCMME004", "帳號鎖定")
            msgTable.Add("ARMCMME005", "帳號未啟用")

            'A：與資料庫連結產生之Log
            'C：對外部系統互動產生的Log          
            'F：File I/O 產生的Log
            'Z：其它(無法分類項) '

            '===========================================PUB系統訊息區=========================================
            msgTable.Add("PUBCMMB001", "此病歷號已經合併，合併後的病歷號是{0}，是否直接帶入？")
            msgTable.Add("PUBCMMB002", "無此病患資料")
            '=========================================系統共用機制訊息區=======================================
            msgTable.Add("FTMUNCA001", "無此 UNC Path 設定")
            msgTable.Add("FTMUNCA002", "錯誤的網路磁碟機代號")
            msgTable.Add("FTMUNCA003", "無法連線網路磁碟機")
            msgTable.Add("FTMUNCA004", "目標路徑創建及讀取無效")
            msgTable.Add("FTMUNCA005", "原始檔案不存在")
            msgTable.Add("FTMUNCA006", "寫入File Server失敗")
            msgTable.Add("FTMUNCA007", "原始檔案不存在：{0}")
            msgTable.Add("FTMUNCA008", "無法連線網路磁碟機：{0}")
            msgTable.Add("FTMUNCA009", "目標路徑創建及讀取無效：{0}")
            msgTable.Add("FTMUNCA010", "原始檔案不存在：{0}")
            msgTable.Add("FTMUNCA011", "寫入File Server失敗：{0}")

            msgTable.Add("RPTCMMA001", "報表資料查詢錯誤")
            msgTable.Add("RPTCMMA002", "報表產生錯誤")
            msgTable.Add("RPTCMMA003", "報表列印錯誤")
            msgTable.Add("RPTCMMA004", "報表預覽錯誤")
            msgTable.Add("RPTCMMA005", "報表發生未預期之錯誤")
            msgTable.Add("RPTCMMA006", "錯誤的報表物件")
            msgTable.Add("RPTCMMA007", "初始的印表機名稱，無法設定 Active 印表機")
            msgTable.Add("RPTCMMA008", "系統內無該印表機")
            msgTable.Add("RPTCMMA009", "無法設定 Active 印表機")
            msgTable.Add("RPTCMMA010", "系統未安裝任何印表機")

            msgTable.Add("SNCCMMA001", "序號取得失敗")
            msgTable.Add("SNCCMMA002", "序號取得失敗：{0}")

            msgTable.Add("SQLCMMA001", "資料庫處理錯誤")
            msgTable.Add("SQLCMMA002", "資料庫處理失敗(重複的索引鍵 index )")
            msgTable.Add("SQLCMMA003", "資料庫處理失敗(無法插入 NULL 值到 NOT NULL欄位)")
            msgTable.Add("SQLCMMA004", "資料庫處理失敗(無效的物件名稱)")
            msgTable.Add("SQLCMMA005", "資料庫處理失敗(錯誤的資料庫)")
            msgTable.Add("SQLCMMA006", "資料庫處理失敗(資料庫登入失敗)")
            msgTable.Add("SQLCMMA007", "資料庫處理失敗(外部索引鍵錯誤)")
            msgTable.Add("SQLCMMA008", "資料庫處理失敗(重複的索引鍵 constraint )")
            msgTable.Add("SQLCMMA009", "資料庫處理失敗(執行Replication失敗)")
            msgTable.Add("SQLCMMA010", "資料庫處理失敗(資料太長被截斷)")
            msgTable.Add("SQLCMMA011", "傳送要求至伺服器時發生傳輸層級的錯誤(遠端主機已強制關閉一個現存的連線)")

            msgTable.Add("SYSCMMA001", "無法判讀的系統錯誤")
            msgTable.Add("SYSMSQA001", "取得新的 Message Queue 失敗")
            msgTable.Add("SYSMSQA002", "傳送 MSMQ 訊息失敗")
            msgTable.Add("SYSWCFA001", "WCF 服務端發生未知例外")
            msgTable.Add("SYSWCFA002", "WCF 服務端連線例外")
            msgTable.Add("NIOCMMF001", "File I/O 處理錯誤")

            Return msgTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得简体中文的讯息Table - 修改需同時修改各種語言
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-7-30</remarks>
    Private Shared Function getMsgTableSimple() As Hashtable
        Dim msgTable As New Hashtable

        Try
            '==================================================================================================
            '  讯息编码原则 = 系统代码（3码) + 模组代码（3码) + 分类码（3码) + 序号（3码) 
            '==================================================================================================  
            ' 系统代码 (3码)：根据各系统定义之代码，例如：挂号系统代码为REG 
            ' 模组代码 (3码)：根据模组内需求之功能实际代码为原则，例如：CMM表示为公用讯息
            ' 　分类码 (1码)：A-Z 共可区分後端26大类讯息，为避免有无法分类之情况，首码 Z 固定为其它类
            '                 A：与数据库连结产生之Log　　　　　　B：与使用者互动产生之Log　　
            '                 C：对外部系统互动产生的Log          D：系统内由程式所判定产生之Log
            '                 E：系统内产生的不可预期之Log 　　　 F：File I/O 产生的Log
            '                 Z：其它(无法分类项) 
            ' 　 序号 (3码)： 001~ 999 ，各分类可容纳999种讯息
            '==================================================================================================

            ''===========================================系统共用讯息区========================================
            msgTable.Add("CMMCMMB300", "{0}")
            msgTable.Add("CMMCMMB301", "{0}成功")                       '新增、修改、删除、查询、列印、预览、汇入(XX)...成功
            msgTable.Add("CMMCMMB302", "{0}失败")                       '新增、修改、删除、查询、列印、预览、汇入(XX)...失败
            msgTable.Add("CMMCMMB303", "是否确定{0}?")                  '是否确定删除(离开)?
            msgTable.Add("CMMCMMB304", "尚未选取{0}资料，请选择")       '尚未选取病患清单资料，请选择
            msgTable.Add("CMMCMMB305", "{0}不得为空白")                 '诊断代码不得为空白
            msgTable.Add("CMMCMMB306", "{0}不得小於{1}")                '看诊日期迄日不得小於起日
            msgTable.Add("CMMCMMB307", "{0}不得大於{1}")                '看诊日期起日不得大於迄日
            msgTable.Add("CMMCMMB308", "该笔记录已存在{0}，请确认")     '该笔记录已存在挂号周班表，请确认
            msgTable.Add("CMMCMMB309", "{0}栏位输入错误，{1}")          '缴费金额栏位输入错误，请输入数字  挂号日期栏位输入错误，请确认
            msgTable.Add("CMMCMMB310", "无符合条件资料被{0}")           '无符合条件资料被修改(删除)
            msgTable.Add("CMMCMMB311", "尚有所属{0}资料存在,无法删除")  '尚有所属表单医令明细资料存在，无法删除
            msgTable.Add("CMMCMMB312", "{0}按钮启动失败，功能无法使用") '执行按钮启动失败，功能无法使用

            msgTable.Add("CMMCMMB314", "{0}不得小於或等於{1}")
            msgTable.Add("CMMCMMB315", "{0}不得大於或等於{1}")
            msgTable.Add("CMMCMMB316", "{0}成功{1}")                    '新增、修改、删除、查询、列印、预览、汇入(XX)...成功 
            msgTable.Add("CMMCMMB317", "{0}失败{1}")                    '新增、修改、删除、查询、列印、预览、汇入(XX)...成功
            msgTable.Add("CMMCMMB318", "{0}错误{1}")

            msgTable.Add("CMMCMMB901", "查询成功")
            msgTable.Add("CMMCMMB902", "新增成功")
            msgTable.Add("CMMCMMB903", "修改成功")
            msgTable.Add("CMMCMMB904", "删除成功")
            msgTable.Add("CMMCMMB905", "储存成功")
            msgTable.Add("CMMCMMB906", "清除成功")
            msgTable.Add("CMMCMMB907", "暂存成功")
            msgTable.Add("CMMCMMB908", "预览打印成功")
            msgTable.Add("CMMCMMB909", "打印成功")
 
            msgTable.Add("CMMCMMB911", "查询失败")
            msgTable.Add("CMMCMMB912", "新增失败")
            msgTable.Add("CMMCMMB913", "修改失败")
            msgTable.Add("CMMCMMB914", "删除失败")
            msgTable.Add("CMMCMMB915", "储存失败")
            msgTable.Add("CMMCMMB916", "清除失败")
            msgTable.Add("CMMCMMB917", "暂存失败")
            msgTable.Add("CMMCMMB918", "预览打印失败")
            msgTable.Add("CMMCMMB919", "打印失败")

            msgTable.Add("CMMCMMB931", "载入资料失败")
            msgTable.Add("CMMCMMB932", "是否确定删除？")
            msgTable.Add("CMMCMMB933", "查无符合条件之资料")            '查无符合条件之资料
            msgTable.Add("CMMCMMB934", "非本人不可修改")

            msgTable.Add("CMMCMMB990", "初始化资料失败")
            msgTable.Add("CMMCMMB991", "载入服务管理员失败")
            msgTable.Add("CMMCMMB992", "载入事件管理员(EventManager)失败")
            msgTable.Add("CMMCMMB993", "关闭事件管理员(EventManager)失败")
            msgTable.Add("CMMCMMB994", "初始化Cbo失败")

            msgTable.Add("CMMCMMD001", "系统执行异常")
            msgTable.Add("CMMCMMD002", "Delegate 执行异常")
            msgTable.Add("CMMCMMD003", "WCF Service 执行异常")
            msgTable.Add("CMMCMMD004", "Client Service 执行异常")

            '===========================================ARM系统讯息区=========================================
            msgTable.Add("ARMCMME001", "登入失败：{0}")
            msgTable.Add("ARMCMME002", "帐号过期")
            msgTable.Add("ARMCMME003", "密码过期{0}")
            msgTable.Add("ARMCMME004", "帐号锁定")
            msgTable.Add("ARMCMME005", "帐号未启用")

            'A：与数据库连结产生之Log
            'C：对外部系统互动产生的Log          
            'F：File I/O 产生的Log
            'Z：其它(无法分类项) 

            '===========================================PUB系统讯息区=========================================
            msgTable.Add("PUBCMMB001", "此病历号已经合并，合并後的病历号是{0}，是否直接带入？")
            msgTable.Add("PUBCMMB002", "无此病患资料")
            '=========================================系统共用机制讯息区=======================================
            msgTable.Add("FTMUNCA001", "无此 UNC Path 设定")
            msgTable.Add("FTMUNCA002", "错误的网盘代号")
            msgTable.Add("FTMUNCA003", "无法连线网盘")
            msgTable.Add("FTMUNCA004", "目标路径创建及读取无效")
            msgTable.Add("FTMUNCA005", "原始档案不存在")
            msgTable.Add("FTMUNCA006", "写入File Server失败")
            msgTable.Add("FTMUNCA007", "原始档案不存在：{0}")
            msgTable.Add("FTMUNCA008", "无法连线网盘：{0}")
            msgTable.Add("FTMUNCA009", "目标路径创建及读取无效：{0}")
            msgTable.Add("FTMUNCA010", "原始档案不存在：{0}")
            msgTable.Add("FTMUNCA011", "写入File Server失败：{0}")

            msgTable.Add("RPTCMMA001", "报表资料查询错误")
            msgTable.Add("RPTCMMA002", "报表产生错误")
            msgTable.Add("RPTCMMA003", "报表打印错误")
            msgTable.Add("RPTCMMA004", "报表预览错误")
            msgTable.Add("RPTCMMA005", "报表发生未预期之错误")
            msgTable.Add("RPTCMMA006", "错误的报表物件")
            msgTable.Add("RPTCMMA007", "初始的打印机名称，无法设定 Active 打印机")
            msgTable.Add("RPTCMMA008", "系统内无该打印机")
            msgTable.Add("RPTCMMA009", "无法设定 Active 打印机")
            msgTable.Add("RPTCMMA010", "系统未安装任何打印机")

            msgTable.Add("SNCCMMA001", "序号取得失败")
            msgTable.Add("SNCCMMA002", "序号取得失败：{0}")

            msgTable.Add("SQLCMMA001", "数据库处理错误")
            msgTable.Add("SQLCMMA002", "数据库处理失败(重复的索引键 index )")
            msgTable.Add("SQLCMMA003", "数据库处理失败(无法插入 NULL 值到 NOT NULL栏位)")
            msgTable.Add("SQLCMMA004", "数据库处理失败(无效的物件名称)")
            msgTable.Add("SQLCMMA005", "数据库处理失败(错误的数据库)")
            msgTable.Add("SQLCMMA006", "数据库处理失败(数据库登入失败)")
            msgTable.Add("SQLCMMA007", "数据库处理失败(外部索引键错误)")
            msgTable.Add("SQLCMMA008", "数据库处理失败(重复的索引键 constraint )")
            msgTable.Add("SQLCMMA009", "数据库处理失败(执行Replication失败)")
            msgTable.Add("SQLCMMA010", "数据库处理失败(资料太长被截断)")
            msgTable.Add("SQLCMMA011", "传送要求至伺服器时发生传输层级的错误(远端主机已强制关闭一个现存的连线)")

            msgTable.Add("SYSCMMA001", "无法判读的系统错误")
            msgTable.Add("SYSMSQA001", "取得新的 Message Queue 失败")
            msgTable.Add("SYSMSQA002", "传送 MSMQ 信息失败")
            msgTable.Add("SYSWCFA001", "WCF 服务端发生未知例外")
            msgTable.Add("SYSWCFA002", "WCF 服务端连线例外")
            msgTable.Add("NIOCMMF001", "File I/O 处理错误")

            Return msgTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
