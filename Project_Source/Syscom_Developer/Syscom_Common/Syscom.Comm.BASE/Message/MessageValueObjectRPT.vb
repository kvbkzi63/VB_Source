'/*
'*****************************************************************************
'*
'*    Page/Class Name:  訊息代碼物件 - 延伸類別(報表)
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
    ''' 根據 AppConfigUtil 的 語言種類 取得報表抬頭Table
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-7-30</remarks>
    Private Shared Function getRptTable() As Hashtable
        Select Case AppConfigUtil.AppLanguage
            Case AppConfigUtil.Language.TraditionalChinese
                '繁體中文
                Return getRptTableTradtional()
            Case AppConfigUtil.Language.SimplifiedChinese
                '簡體中文
                Return getRptTableSimple()
            Case Else
                '其他
                Return getRptTableTradtional()
        End Select
    End Function

    ''' <summary>
    ''' 取得繁體中文的取得報表抬頭Table - 修改需同時修改各種語言
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-7-30</remarks>
    Private Shared Function getRptTableTradtional() As Hashtable
        Dim rptTable As New Hashtable

        Try
            rptTable.Add("HEMRPT0010102", "網路預約名單")
            rptTable.Add("HEMRPT0010103", "網路預約單")

            '---LA----262
            rptTable.Add("CNCRPT0070101", "入院護理評估表")
            rptTable.Add("CNCRPT0070102", "兒科入院護理評估表")
            rptTable.Add("CNCRPT0070103", "新生兒科入院護理評估表")
            rptTable.Add("CNCRPT0070104", "產科入院護理評估表")
            rptTable.Add("CNCRPT0070105", "精神科入院護理評估表")
            rptTable.Add("CNCRPT0290701", "團體護理指導教案表")
            rptTable.Add("ICDRPT0050101", "未完成病歷清單")
            rptTable.Add("ICDRPT0060102", "醫師量審未完成病歷報表")
            rptTable.Add("ICDRPT0060202", "科部未完成病歷報表")
            rptTable.Add("ICDRPT0060302", "完成病歷超過N天報表")
            rptTable.Add("ICDRPT010101", "癌登病歷再閱")
            rptTable.Add("ICDRPT0010201", "出院病歷逾期清單")
            rptTable.Add("ICDRPT1020101", "疾病分類住院資料查詢")
            rptTable.Add("ICDRPT1030102", "疾病分類住院資料申請單")
            rptTable.Add("ICDRPT2010101", "癌登個案收錄(短表)")
            rptTable.Add("ICDRPT2010201", "癌登個案收錄(長表)")
            rptTable.Add("ICDRPT2020101", "無需配置")
            rptTable.Add("ICDRPT2020102", "無需配置")
            rptTable.Add("ICDRPT2020201", "個案登錄資料查詢 - 長表")
            rptTable.Add("ICDRPT2040101", "癌登個案申報(長表)")
            rptTable.Add("ICDRPT2040201", "癌登個案申報(短表)")
            rptTable.Add("ICDRPT2050101", "癌登個案追蹤")
            rptTable.Add("ICDRPT4010301", "住院病患地區分布統計表")
            rptTable.Add("ICDRPT4010401", "入院來源統計表")
            rptTable.Add("ICDRPT4010501", "損傷及中毒之外因分類統計表")
            rptTable.Add("ICDRPT4010601", "出院病患年齡層分佈之順位及佔總出院人數之比率")
            'rptTable.Add("ICDRPT4010701", "十大住院疾病原因統計表")
            rptTable.Add("ICDRPT4010701", "十大住院疾病統計")
            rptTable.Add("ICDRPT4010801", "住院疾病原因統計總表")
            rptTable.Add("ICDRPT4010901", "住院妊娠、生產及產褥期之併發症統計表")
            rptTable.Add("ICDRPT4011001", "院內新生兒主次診斷統計總表")
            rptTable.Add("ICDRPT4011101", "院內新生兒之出生型態統計表")
            rptTable.Add("ICDRPT4011201", "外科手術和相關處置統計總表")
            rptTable.Add("ICDRPT4011301", "十大住院手術疾病統計")
            rptTable.Add("ICDRPT4011401", "住院死亡原因統計總表")
            rptTable.Add("ICDRPT4011501", "十大住院死亡原因統計表(採衛生署死因統計之歸類方式)")
            rptTable.Add("ICDRPT4011601", "各月份住院死亡統計表")
            rptTable.Add("ICDRPT4011701", "診斷統計表")
            rptTable.Add("ICDRPT4011801", "疾病分類死亡及平均住院日、醫療費用統計表")
            rptTable.Add("ICDRPT4011901", "診斷評鑑總表")
            rptTable.Add("ICDRPT4012001", "手術處置評鑑總表")
            rptTable.Add("ICDRPT4012201", "癌症登記個案登記個案性別年齡分布")
            rptTable.Add("ICDRPT4012401", "癌登內容資料 - 短表95")
            rptTable.Add("ICDRPT4012402", "癌登內容資料 - 短表96")
            rptTable.Add("ICDRPT4012403", "癌登內容資料 - 長表")

            Return rptTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得简体中文的取得報表抬頭Table - 修改需同時修改各種語言
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-7-30</remarks>
    Private Shared Function getRptTableSimple() As Hashtable
        Dim rptTable As New Hashtable

        Try
            rptTable.Add("HEMRPT0010102", "网路预约名单")
            rptTable.Add("HEMRPT0010103", "网路预约单")

            '---LA----262
            rptTable.Add("CNCRPT0070101", "入院护理评估表")
            rptTable.Add("CNCRPT0070102", "儿科入院护理评估表")
            rptTable.Add("CNCRPT0070103", "新生儿科入院护理评估表")
            rptTable.Add("CNCRPT0070104", "产科入院护理评估表")
            rptTable.Add("CNCRPT0070105", "精神科入院护理评估表")
            rptTable.Add("CNCRPT0290401", "国立成功大学医学院附设医院护理部")
            rptTable.Add("CNCRPT0290402", "国立成功大学医学院附设医院护理部")
            rptTable.Add("CNCRPT0290701", "团体护理指导教案表")

            Return rptTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
