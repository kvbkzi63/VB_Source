Imports Syscom.Comm.Utility

Public Class ChargeUtil
    Implements IDisposable

#Region "########## Dispose ##########"
    Private Shared instance As ChargeUtil
    Private disposedValue As Boolean = False ' 偵測多餘的呼叫
    Public Shared Function getInstance() As ChargeUtil
        'If instance Is Nothing Then
        '    instance = New ChargeUtil
        'End If
        'Return instance
        Return New ChargeUtil
    End Function
    Private Sub New()
    End Sub
    ''' <summary>
    ''' Dispose
    ''' </summary>
    ''' <param name="disposing"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            ' TODO: 釋放其他狀態 (Managed 物件)。
            instance = Nothing
        End If
        ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
        ' TODO: 將大型欄位設定為 null。

        Me.disposedValue = True
    End Sub
    ''' <summary>
    ''' Dispose
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Public Function getChronicInfoHashTable(ByVal chronicInfoDT As DataTable) As Hashtable
        Dim rtnHT As New Hashtable

        Try
            If DataSetUtil.IsContainsData(chronicInfoDT) Then
                For iIndex As Integer = 0 To chronicInfoDT.Rows.Count - 1
                    Dim keyValue As String = StringUtil.nvl(chronicInfoDT.Rows(iIndex).Item("Chronic_Card_Sn")) & "," & _
                                             CDate(StringUtil.nvl(chronicInfoDT.Rows(iIndex).Item("Drug_Date"))).ToShortDateString

                    Dim isDrugsAbroad As String = StringUtil.nvl(chronicInfoDT.Rows(iIndex).Item("Is_Drugs_Abroad"))
                    Dim drugsSn As Integer = CInt(chronicInfoDT.Rows(iIndex).Item("Drugs_Sn"))

                    If Not rtnHT.Contains(keyValue) Then
                        Dim tempAL As New ArrayList
                        tempAL.Add(isDrugsAbroad)
                        tempAL.Add(drugsSn)

                        rtnHT.Add(keyValue, tempAL)
                    End If
                Next
            End If

            Return rtnHT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getOrderPriceHashTable(ByVal orderPriceDT As DataTable) As Hashtable
        Dim rtnHT As New Hashtable

        Try
            If DataSetUtil.IsContainsData(orderPriceDT) Then
                For iIndex As Integer = 0 To orderPriceDT.Rows.Count - 1
                    Dim keyValue As String = StringUtil.nvl(orderPriceDT.Rows(iIndex).Item("Order_Code"))

                    If Not rtnHT.Contains(keyValue) Then
                        Dim tempAL As New ArrayList
                        tempAL.Add(CDec(StringUtil.nvl(orderPriceDT.Rows(iIndex).Item("Price"))))
                        tempAL.Add(StringUtil.nvl(orderPriceDT.Rows(iIndex).Item("Account_Id")))

                        rtnHT.Add(keyValue, tempAL)
                    End If
                Next
            End If

            Return rtnHT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "全域變數"

    Dim gblSysFlag As String = "OPD"

#End Region
    ''' <summary>
    ''' 計算健保全部藥費 及 加收藥費
    ''' </summary>
    ''' <param name="orderDT"></param>
    ''' <param name="chronicInfoDT"></param>
    ''' <param name="orderPriceDT"></param>
    ''' <param name="PriceForIntFlag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getDrugsAmtAndMaxDayAndHaveSurOrderOrNotInfo(ByVal orderDT As DataTable, ByVal chronicInfoDT As DataTable, ByVal orderPriceDT As DataTable, Optional ByVal PriceForIntFlag As Boolean = False) As DataTable
        Dim rtnDT As New DataTable
        rtnDT.TableName = "orderInfoDT"
        rtnDT.Columns.Add("drugsAmt") '這是計算加收的藥費
        rtnDT.Columns.Add("maxDays")
        rtnDT.Columns.Add("haveSurOrderFlag")
        rtnDT.Columns.Add("isChrAbroadFlag")
        rtnDT.Columns.Add("drugsAmt_all") '新增計算全部的藥費

        Dim AdddrugsAmt As Integer = 0 '加收藥費總額
        Dim drugsAmt As Integer = 0 '全部藥費總額
        Dim maxDays As Decimal = 0
        Dim haveSurOrderFlag As String = "N"
        Dim isChrAbroadFlag As String = "N"
        '用傳進來的table欄位做系統判別
        If orderDT.Columns.Contains("Duration") Then
            gblSysFlag = "EMG"
        ElseIf orderDT.Columns.Contains("Days") Then
            gblSysFlag = "OPD"
        End If
        Try
            '1.取得慢箋資料的HashTable
            Dim chronicInfoHT As New Hashtable
            chronicInfoHT = getChronicInfoHashTable(chronicInfoDT)

            '2.取得Order Price的HashTable
            Dim orderPriceHT As New Hashtable
            orderPriceHT = getOrderPriceHashTable(orderPriceDT)

            Dim selectStr As String = ""
            If orderDT.Columns.Contains("Cancel") Then
                selectStr = "Cancel <> 'Y'"
            Else
                selectStr = "1=1"
            End If
            Dim nonCancelDataRows() As DataRow = orderDT.Select(selectStr)

            If nonCancelDataRows.Length > 0 Then

                Dim mainIdentityId As String = "2"

                Dim accIdHT As New Hashtable '計算加收藥費
                Dim accIdHTAll As New Hashtable '計算全部藥費
                Dim needAddPartAmtFlag As Boolean = True

                For Each row As DataRow In nonCancelDataRows

                    If orderDT.Columns.Contains("Main_Identity_Id") Then
                        mainIdentityId = StringUtil.nvl(row.Item("Main_Identity_Id"))
                    End If

                    Dim chargeDate As Date = Now
                    If orderDT.Columns.Contains("Charge_Date") Then
                        'OMO_Order_Record_Impl
                        If StringUtil.nvl(row("Charge_Date")).Length > 0 Then
                            chargeDate = CDate(row("Charge_Date"))
                        End If
                    ElseIf orderDT.Columns.Contains("Opd_Charge_Date") Then
                        'OHD_Order_Record、OPC_Charge_Detail
                        If StringUtil.nvl(row("Opd_Charge_Date")).Length > 0 Then
                            chargeDate = CDate(row("Opd_Charge_Date"))
                        End If
                    End If

                    '====================
                    '取得天數、數量、成數
                    '====================
                    Dim days As Decimal = CDec(0)
                    If gblSysFlag = "OPD" AndAlso StringUtil.nvl(row("Days")).Length > 0 Then
                        days = CDec(row("Days"))
                    ElseIf gblSysFlag = "EMG" AndAlso StringUtil.nvl(row("Duration")).Length > 0 Then
                        days = CDec(row("Duration"))
                    End If
                    Dim tqty As Decimal = 0
                    If StringUtil.nvl(row("Tqty")).Length > 0 Then
                        tqty = CDec(row("Tqty"))
                    End If
                    Dim ratio As Decimal = 1

                    '====================
                    '計算全部藥費
                    '====================
                    If mainIdentityId.Equals("2") _
                          AndAlso StringUtil.nvl(row("Order_Type_Id")).Equals("E") _
                          AndAlso StringUtil.nvl(row("Is_Charge")).Equals("Y") _
                          AndAlso ((orderDT.Columns.Contains("Is_Force") AndAlso StringUtil.nvl(row("Is_Force")).Equals("N")) _
                                   Or Not orderDT.Columns.Contains("Is_Force")) Then

                        '取得Order_Price資料
                        Dim price As Decimal = 0
                        Dim accountId As String = "X"

                        Dim orderCode As String = StringUtil.nvl(row("Order_Code"))
                        If orderPriceHT.Contains(orderCode) Then
                            Dim tempAL As ArrayList = orderPriceHT.Item(orderCode)
                            price = tempAL.Item(0)
                            accountId = tempAL.Item(1)
                        End If

                        '只將有Order_Price的Order納入計算
                        If Not accountId.Equals("X") Then

                            Dim amt As Decimal = price * tqty * ratio

                            If PriceForIntFlag Then
                                amt = MathUtil.Round(amt)
                            End If

                            'By Account_Id計算金額
                            If accIdHTAll.Contains(accountId) Then
                                accIdHTAll(accountId) = CDec(accIdHTAll(accountId)) + amt
                            Else
                                accIdHTAll.Add(accountId, amt)
                            End If
                        End If

                    End If

                    '====================
                    '慢箋出國帶藥(只有門診會做)
                    '====================
                    Dim isChronicCard As String = "N"
                    If gblSysFlag = "OPD" Then

                        isChronicCard = StringUtil.nvl(row("Is_Chronic_Card"))

                        If isChronicCard.Equals("Y") Then
                            Dim preSn As String = ""
                            If orderDT.Columns.Contains("Prescription_Sn") Then
                                preSn = StringUtil.nvl(row("Prescription_Sn"))
                            ElseIf orderDT.Columns.Contains("Prescirption_Sn") Then
                                preSn = StringUtil.nvl(row("Prescirption_Sn"))
                            End If

                            Dim keyValue As String = preSn & "," & chargeDate.ToShortDateString
                            Dim isDrugsAbroad As String = "N"
                            Dim drugsSn As Integer = 1
                            If chronicInfoHT.Contains(keyValue) Then
                                isDrugsAbroad = CType(chronicInfoHT.Item(keyValue), ArrayList).Item(0)
                                drugsSn = CType(chronicInfoHT.Item(keyValue), ArrayList).Item(1)
                            End If

                            If isDrugsAbroad.Equals("Y") And drugsSn > 1 Then

                                If isChrAbroadFlag.Equals("N") Then
                                    isChrAbroadFlag = "Y"
                                End If

                                days = days / 2
                            End If

                            If days >= 28 Then
                                needAddPartAmtFlag = False
                            End If
                        End If
                    End If
                    '====================

                    '====================
                    '取得最大的用藥天數
                    '====================
                    If maxDays < days Then
                        maxDays = days
                    End If
                    '====================

                    '====================
                    '判斷是否為手術醫令
                    '====================
                    If haveSurOrderFlag.Equals("N") And row("Order_Type_Id").ToString.Trim.Equals("J") Then
                        haveSurOrderFlag = "Y"
                    End If
                    '====================
                    '急診不會往下跑，只有門診需要計算
                    If gblSysFlag = "OPD" AndAlso needAddPartAmtFlag Then
                        'Order_Type_Id = 'E' and Main_Identity_Id ='2' and Is_Charge = 'Y' and (Is_Chronic_Card = 'N' or (Is_Chronic_Card = 'Y' and Days < 28))
                        If mainIdentityId.Equals("2") _
                           AndAlso StringUtil.nvl(row("Order_Type_Id")).Equals("E") _
                           AndAlso StringUtil.nvl(row("Is_Charge")).Equals("Y") _
                           AndAlso Not (isChronicCard.Equals("Y") And days >= 28) _
                           AndAlso ((orderDT.Columns.Contains("Is_Force") AndAlso StringUtil.nvl(row("Is_Force")).Equals("N")) _
                                    Or Not orderDT.Columns.Contains("Is_Force")) Then


                            If isChronicCard.Equals("Y") And isChrAbroadFlag.Equals("Y") Then
                                tqty = tqty / 2
                            End If

                            '取得Order_Price資料
                            Dim price As Decimal = 0
                            Dim accountId As String = "X"

                            Dim orderCode As String = StringUtil.nvl(row("Order_Code"))
                            If orderPriceHT.Contains(orderCode) Then
                                Dim tempAL As ArrayList = orderPriceHT.Item(orderCode)
                                price = tempAL.Item(0)
                                accountId = tempAL.Item(1)
                            End If

                            '只將有Order_Price的Order納入計算
                            If Not accountId.Equals("X") Then

                                Dim amt As Decimal = price * tqty * ratio

                                If PriceForIntFlag Then
                                    amt = MathUtil.Round(amt)
                                End If

                                'By Account_Id計算金額
                                If accIdHT.Contains(accountId) Then
                                    accIdHT(accountId) = CDec(accIdHT(accountId)) + amt
                                Else
                                    accIdHT.Add(accountId, amt)
                                End If
                            End If

                        End If
                    Else
                        accIdHT.Clear()
                    End If
                Next

                '加總所有的Account_Id四捨五入的金額(加收藥費)
                For iIndex As Integer = 0 To accIdHT.Count - 1
                    AdddrugsAmt += MathUtil.Round(CDec(accIdHT.Values(iIndex)))
                Next
                '加總所有的Account_Id四捨五入的金額(全部藥費)
                For iIndex As Integer = 0 To accIdHTAll.Count - 1
                    drugsAmt += MathUtil.Round(CDec(accIdHTAll.Values(iIndex)))
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try

        rtnDT.Rows.Add(New Object() {AdddrugsAmt, maxDays, haveSurOrderFlag, isChrAbroadFlag, drugsAmt})

        Return rtnDT
    End Function

    ''' <summary>
    ''' 程式說明：取得健保資料設定後的資料
    ''' 開發人員：谷官
    ''' 開發日期：2009.10.06
    ''' </summary>
    ''' <param name="opMsg">
    ''' { 0, "取得健保資料設定後的資料完成!!"}
    ''' {-1, "尚未初始化健保資料設定的資料", ""}
    ''' {-2, "取得健保資料設定後的資料失敗", ""}
    ''' </param>
    ''' <returns>
    ''' dataDT
    ''' 
    ''' column0：案件Case_Type_Id
    ''' column1：部份負擔Part_Code
    ''' column2：給付類別Insu_Paykind_Id
    ''' column3：卡序Card_Sn，for 特殊卡序，若回傳為’’，則原呼叫的UI或程式不update本身的卡序
    ''' column4：就醫類別IC_Medical_Type_Id
    ''' column5：Contract_Code1
    ''' column6：Contract_Code2
    ''' </returns>
    ''' <remarks></remarks>
    Public Function getSetHealthInsuData(ByVal paramDS As DataSet, ByVal Health_Opd_Dept_Code As String, ByVal Hospital_Level As String, ByVal orderInfo As DataTable, ByVal addPartAmtDT As DataTable, ByVal pipPrjDrugHT As Hashtable, ByVal pubMedicalTypeDT As DataTable, ByRef opMsg As DataTable, Optional ByVal dbConn As IDbConnection = Nothing, Optional ByVal cmnConn As IDbConnection = Nothing) As DataTable

        '產生儲存操作過程的Message之Table
        Dim columnNa As String() = {"resultNum", "errMsg", "exString"}
        Dim columnType As Integer() = {DataSetUtil.TypeInteger, DataSetUtil.TypeString, DataSetUtil.TypeString}
        opMsg = DataSetUtil.GenDataTable("opMsg", Nothing, columnNa, columnType)

        Try
            Dim Case_Type_Id As String = ""
            Dim Part_Code As String = ""
            Dim Insu_Paykind_Id As String = ""
            Dim Card_Sn As String = ""
            Dim IC_Medical_Type_Id As String = ""

            Dim Contract_Code1 As String = ""
            Dim Contract_Code2 As String = ""

            Dim orgContractCode1 As String = ""
            Dim orgContractCode2 As String = ""

            '增加優免判斷
            Dim Dis_Identity_Code As String = ""

            '-----------------------------------------------------
            '設定常數（盡量不要寫死碼，不得已請寫常數設定）
            '-----------------------------------------------------
            Dim m_SubCodeVeteran As String = "22" '榮民
            Dim m_SubCodeLow As String = "23" '福保


            If DataSetUtil.IsContainsData(paramDS) Then

                Dim deptCode As String = StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("Dept_Code"))
                Dim subIdentityCode As String = StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("Sub_Identity_Code"))
                Dim disIdentityCode As String = StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("Dis_Identity_Code"))
                Dim MedicalTypeDr As DataRow() = Nothing
                Dim medicalTypeId As String = StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("Medical_Type_Id"))
                Dim medicalCtrlIdStr As String = ""

                '依據傳入的看診目的去設定看診目的的基本檔資料
                If pubMedicalTypeDT IsNot Nothing AndAlso pubMedicalTypeDT.Rows.Count > 0 Then
                    MedicalTypeDr = pubMedicalTypeDT.Select("Medical_Type_Id = '" & medicalTypeId & "'")
                    If MedicalTypeDr.Length > 0 Then
                        medicalCtrlIdStr = MedicalTypeDr(0).Item("Medical_Type_Ctrl_Id").ToString
                        medicalCtrlIdStr = Trim(medicalCtrlIdStr)
                    End If
                End If

                Dim patientAge As Integer = Val(StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("PatientAge")))

                Dim birthDateStr As String = ""
                Try
                    birthDateStr = CDate(paramDS.Tables("valueDT").Rows(0).Item("Birth_Date")).ToShortDateString
                Catch ex As Exception
                End Try

                Dim opdVisitDateStr As String = ""
                Try
                    opdVisitDateStr = CDate(paramDS.Tables("valueDT").Rows(0).Item("Opd_Visit_Date")).ToShortDateString
                Catch ex As Exception
                End Try
                '20121126 by ccr 902 條件控管改為滿三歲,例900101 出生截止為 930101
                Dim end902date As Date
                Try
                    end902date = DateAdd(DateInterval.Year, 3, CDate(paramDS.Tables("valueDT").Rows(0).Item("Birth_Date")))
                Catch ex As Exception
                End Try


                '計算歲(年)
                Dim ageYears As Integer = -1

                '計算歲(天)
                Dim ageDays As Integer = -1

                If patientAge >= 0 Then
                    ageYears = patientAge
                End If

                If birthDateStr.Length > 0 And opdVisitDateStr.Length > 0 Then
                    ageYears = DateUtil.GetAge(CDate(birthDateStr), CDate(opdVisitDateStr)).GetValue(0)
                    ageDays = DateDiff(DateInterval.Day, CDate(birthDateStr), CDate(opdVisitDateStr))
                End If


                Dim babyMark As String = StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("BabyMark"))
                Dim isSevereDisease As String = StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("Is_Severe_Disease"))
                Dim isDisabled As String = StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("Is_Disabled"))
                Dim isEmg As String = StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("Is_Emg"))

                Dim sectionId As String = StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("Section_Id"))

                If paramDS.Tables("valueDT").Columns.Contains("Contract_Code1") Then
                    orgContractCode1 = StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("Contract_Code1"))
                End If

                If paramDS.Tables("valueDT").Columns.Contains("Contract_Code2") Then
                    orgContractCode2 = StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("Contract_Code2"))
                End If
                '20150722 加入傳入卡序，若有變更，依變更，若無變更，傳回原本
                If paramDS.Tables("valueDT").Columns.Contains("Card_Sn") Then
                    Card_Sn = StringUtil.nvl(paramDS.Tables("valueDT").Rows(0).Item("Card_Sn"))
                End If
                '加入優免
                Dis_Identity_Code = disIdentityCode
                '----------------------------------------------------------------------------
                '#Step1.預設Case_Type_Id=09，Insu_Paykind_Id=4，IC_Medical_Type_ID=01(急診04)(牙科02)
                '----------------------------------------------------------------------------
                Case_Type_Id = "09"
                Insu_Paykind_Id = "4"

                If isEmg.Equals("Y") Then
                    Case_Type_Id = "02"
                End If

                '20110803 add by bella for 急診就醫類型04 
                If isEmg.Equals("Y") Then
                    IC_Medical_Type_Id = "04"
                Else
                    If Health_Opd_Dept_Code.Equals("40") Or Health_Opd_Dept_Code.Equals("GA") Then
                        IC_Medical_Type_Id = "02"
                    Else
                        IC_Medical_Type_Id = "01"
                    End If
                End If
                '----------------------------------------------------------------------------
                '----------------------------------------------------------------------------
                '#Step2.設定Part_Code
                '----------------------------------------------------------------------------
                '部份負擔1,2,3碼
                Dim partCode1 As String = ""
                Dim partCode2 As String = ""
                Dim partCode3 As String = ""
                '----------------------------------------------------------------------------
                '-Step2.3.設定Part_Code第1碼
                '         區分西醫、牙醫、中醫的，PUB_Hospital.Hospital_Level=A(醫學中心) B(區域醫院) C(地區醫院)D(基層院所)
                '         如下表對應，設定部分負擔第一碼。
                '         預設為Hospital_Level
                '         當健保科別=40，使用牙醫Dental_Hospital_Level，當部分負擔第一碼
                '         當健保科別=60，使用中醫CM_Hospital_Level，當部分負擔第一碼
                '----------------------------------------------------------------------------
                Dim hospitalLevelData As String(,) = {{"E", "N"}, _
                                                      {"F", "Q"}, _
                                                      {"G", "R"}, _
                                                      {"H", "S"}}

                partCode1 = Hospital_Level

                If Health_Opd_Dept_Code.Equals("40") Or Health_Opd_Dept_Code.Equals("GA") Then
                    partCode1 = hospitalLevelData(Asc(Hospital_Level) - 65, 0)
                    Hospital_Level = hospitalLevelData(Asc(Hospital_Level) - 65, 0)
                ElseIf Health_Opd_Dept_Code.Equals("60") Then
                    partCode1 = hospitalLevelData(Asc(Hospital_Level) - 65, 1)
                    Hospital_Level = hospitalLevelData(Asc(Hospital_Level) - 65, 1)
                End If
                '----------------------------------------------------------------------------
                '-Step2.4.設定Part_Code第2碼
                '         預設為1
                '         if Is_Emg=Y急診，部分負擔第二碼=0
                '         if  (Is_Emg=N非急診)  and  (Medical_Type_Id=07住院出院回診  or  08門診手術7日內之回診)，部分負擔第二碼=4 <==改為用Medical_Type_Ctrl_Id判斷 T07=住院出院回診
                '                                                                                                                                                    T08=門診手術7日內之回診
                '         加收部分負擔
                '----------------------------------------------------------------------------
                partCode2 = "1"

                If isEmg.Equals("Y") Then
                    partCode2 = "0"
                Else
                    If medicalCtrlIdStr.Equals("T07") Or medicalCtrlIdStr.Equals("T08") Then '待確認BELLA
                        partCode2 = "4"
                    End If
                    If medicalCtrlIdStr.Equals("T06") Then
                        partCode2 = "3"
                    End If
                End If
                '----------------------------------------------------------------------------
                '-Step2.5.設定Part_Code第3碼
                '         預設為0
                '         If Is_Emg=N非急診and 西醫Hospital_Level= A(醫學中心)，default =2
                '         If Is_Emg=N非急診and 殘障註記Is_Disabled=Y，部分負擔第三碼=3
                '         診斷設定，當診斷明細任一筆為慢性病註記(Is_Chronic_Disease=Y) and醫令明細最大開藥日數>=7 and Hospital_Level in (A、B、C、D)，then Case_Type_Id=04
                '         醫令明細設定，當醫令明細任一筆為手術if Order_Type_Id=’J’，then Case_Type_Id=03
                '----------------------------------------------------------------------------
                partCode3 = "0"

                If isEmg.Equals("N") And Not (medicalCtrlIdStr.Equals("T07") Or medicalCtrlIdStr.Equals("T08") Or medicalCtrlIdStr.Equals("T06")) Then '待確認BELLA
                    If Hospital_Level.Equals("A") Then
                        partCode3 = "2"
                    End If
                    If isDisabled.Equals("Y") And (Asc(Hospital_Level) >= 65 And Asc(Hospital_Level) <= 70) Then
                        '殘障且西醫
                        partCode3 = "3"
                    End If
                    'If medicalTypeId = "13" Then
                    '    '收容對象醫療服務計畫之矯正機關內門診 '待確認BELLA
                    '    partCode3 = "3"
                    'End If
                End If

                '====================
                '加收部分負擔
                '**2011/01/13 非急診且不是牙科
                '====================
                If isEmg.Equals("N") And Not (Health_Opd_Dept_Code.Equals("40") Or Health_Opd_Dept_Code.Equals("GA")) Then

                    Dim drugsAmt As Integer = 0
                    Dim addPartAmt As Integer = 0

                    If DataSetUtil.IsContainsData(orderInfo) Then
                        drugsAmt = Val(orderInfo.Rows(0).Item("drugsAmt"))
                    End If

                    If DataSetUtil.IsContainsData(addPartAmtDT) Then
                        addPartAmt = Val(addPartAmtDT.Rows(0).Item("Add_Part_Amt"))

                        Dim isChrAbroadFlag As String = "N"
                        If DataSetUtil.IsContainsData(orderInfo) Then
                            isChrAbroadFlag = orderInfo.Rows(0).Item("isChrAbroadFlag")
                        End If
                        If isChrAbroadFlag.Equals("Y") Then
                            addPartAmt = addPartAmt * 2
                        End If
                    End If

                    '當PUB_Add_Part查到筆數，則符合加收規則，if部分負擔第三碼=2,0，則第二、三碼需改成20。if第三=3碼，則第二碼改成2

                    If addPartAmt > 0 Then
                        If partCode3.Equals("2") Or partCode3.Equals("0") Then
                            partCode2 = "2"
                            partCode3 = "0"
                        End If
                        If partCode3.Equals("3") Then
                            partCode2 = "2"
                        End If
                    End If

                End If
                '----------------------------------------------------------------------------
                Part_Code = partCode1 & partCode2 & partCode3
                '----------------------------------------------------------------------------
                '====================
                '診斷設定
                '**2011/01/13 非急診
                '====================
                Dim isChronicDiseaseFlag As Boolean = False

                If isEmg.Equals("N") Then

                    If paramDS.Tables("diagnosisDT").Columns.Contains("Is_Chronic_Disease") And paramDS.Tables("diagnosisDT").Columns.Contains("Diagnosis_Type_Id") Then
                        For Each row As DataRow In paramDS.Tables("diagnosisDT").Rows
                            If StringUtil.nvl(row("Is_Chronic_Disease")).Equals("Y") And StringUtil.nvl(row("Diagnosis_Type_Id")).Equals("1") Then
                                isChronicDiseaseFlag = True
                                Exit For
                            End If
                        Next
                    End If

                    If DataSetUtil.IsContainsData(orderInfo) Then
                        If isChronicDiseaseFlag And Val(orderInfo.Rows(0).Item("maxDays")) >= 7 And (Asc(Hospital_Level) >= 65 And Asc(Hospital_Level) <= 68) Then
                            Case_Type_Id = "04"
                        End If
                    End If

                End If
                '----------------------------------------------------------------------------
                '-Step2.8.依健保科別設定
                '         洗腎if Health_Opd_Dept_Code= 2B  then Case_Type_Id=05
                '         **2010/08/18 牙科if Health_Opd_Dept_Code= 40  then Case_Type_Id=19
                '         **2011/01/13 牙科、急診，Case_Type_Id=12
                '----------------------------------------------------------------------------
                If Health_Opd_Dept_Code.Equals("2B") Then
                    Case_Type_Id = "05"
                ElseIf Health_Opd_Dept_Code.Equals("40") Or Health_Opd_Dept_Code.Equals("GA") Then
                    Case_Type_Id = "19"

                    If isEmg.Equals("Y") Then
                        Case_Type_Id = "12"
                    End If
                End If
                '----------------------------------------------------------------------------
                '**2010/12/10，居家依科別診別設定(高聯醫待確認，先mark掉 by Bella)
                '1.參數院內科別=98參數診別=90  then Case_Type_Id=A1，Part_Code=K00
                '2.參數院內科別=36參數診別=90  then Case_Type_Id=A2，Part_Code=K00
                '3.參數院內科別=38參數診別=90  then Case_Type_Id=A2，Part_Code=L00
                '4.參數院內科別=89參數診別=01  then Case_Type_Id=A5，Part_Code=K00
                '5.參數院內科別=98參數診別=01  then Case_Type_Id=A7，Part_Code=K00
                '20130227 by ccr 增加居家偏遠9802
                '5.參數院內科別=98參數診別=02  then Case_Type_Id=A1，Part_Code=K01
                '----------------------------------------------------------------------------
                'If deptCode.Equals("98") And sectionId.Equals("90") Then
                '    Case_Type_Id = "A1"
                '    Part_Code = "K00"
                '    'medicalTypeId = "AH"
                'End If
                ''If (deptCode.Equals("36") Or deptCode.Equals("38")) And sectionId.Equals("90") Then
                'If deptCode.Equals("36") And sectionId.Equals("90") Then
                '    Case_Type_Id = "A2"
                '    Part_Code = "K00"
                'End If
                ''20131101 by ccr 配合健保局精神疾病社區復健(3890)部份負擔碼改為 L00
                'If deptCode.Equals("38") And sectionId.Equals("90") Then
                '    Case_Type_Id = "A2"
                '    Part_Code = "L00"
                'End If

                'If deptCode.Equals("89") And sectionId.Equals("01") Then
                '    Case_Type_Id = "A5"
                '    Part_Code = "K00"
                '    'medicalTypeId = "AH"
                'End If
                'If deptCode.Equals("98") And sectionId.Equals("01") Then
                '    Case_Type_Id = "A7"
                '    Part_Code = "K00"
                '    'medicalTypeId = "AH"
                'End If
                ''20130227 by ccr 增加居家偏遠9802
                'If deptCode.Equals("98") And sectionId.Equals("02") Then
                '    Case_Type_Id = "A1"
                '    Part_Code = "K01"
                '    'medicalTypeId = "AH"
                'End If
                '----------------------------------------------------------------------------
                '====================
                '醫令明細設定(在成醫就被攔掉了)
                '====================
                'If DataSetUtil.IsContainsData(orderInfo) AndAlso orderInfo.Rows(0).Item("haveSurOrderFlag").Equals("Y") Then
                '    Select Case Asc(Hospital_Level)
                '        Case 65 To 68
                '            'A,B,C,D
                '            Case_Type_Id = "03"
                '        Case 69 To 72
                '            'E,F,G,H
                '            Case_Type_Id = "13"
                '    End Select
                'End If

                '待確認ORDERCODEbyBella
                '**2010/12/29 當醫令明細任一筆落在select Drug_Order_code from PIP_Prj_Drug(TB用藥) where Pip_Type=’TB’， then Case_Type_Id=06
                '**2010/12/29 當醫令明細任一筆Order_Code =7100031,7100041,7100042,7100043,7100044,7100045,7100046， then Case_Type_Id=16
                '**2010/12/29 當醫令明細任一筆Order_Code =7300071,7300072,7300073， then Case_Type_Id=15
                '**2011/01/13 非急診

                If isEmg.Equals("N") Then

                    If DataSetUtil.IsContainsData(paramDS.Tables("orderRecordImplDT")) Then

                        Dim nonCancelDataRows() As DataRow = paramDS.Tables("orderRecordImplDT").Select("Cancel <> 'Y'")

                        For Each row As DataRow In nonCancelDataRows
                            Dim orderCode As String = StringUtil.nvl(row("Order_Code"))

                            If pipPrjDrugHT IsNot Nothing AndAlso pipPrjDrugHT.Contains(orderCode) Then
                                Case_Type_Id = "06"
                                Exit For
                            Else
                                Select Case orderCode
                                    Case "7100031", "7100041", "7100042", "7100043", "7100044", "7100045", "7100046"
                                        Case_Type_Id = "16"
                                        Exit For
                                    Case "7300071", "7300072", "7300073"
                                        Case_Type_Id = "15"
                                        Exit For
                                    Case Else
                                End Select
                            End If
                        Next

                    End If

                End If
                '----------------------------------------------------------------------------
                '----------------------------------------------------------------------------
                '-Step2.7.年齡設定
                '         三歲以下，免部分負擔，if  PatientAge<3 and Part_Code第一碼<>0 then Part_Code=902
                '  20121123 by ccr   902 修正到足三歲
                '         百歲人瑞，免部分負擔，if  PatientAge>=100 and Part_Code第一碼<>0 then Part_Code=009
                '----------------------------------------------------------------------------
                If birthDateStr.Trim.Length > 0 Then
                    If ageYears >= 0 Then
                        If ageYears < 3 Then
                            Part_Code = "902"
                        ElseIf ageYears >= 100 Then
                            Part_Code = "009"
                        End If
                    End If


                    If CDate(paramDS.Tables("valueDT").Rows(0).Item("Opd_Visit_Date")) <= end902date Then
                        Part_Code = "902"
                    End If
                End If
                '----------------------------------------------------------------------------
                '-Step2.6.IC新生兒就醫註記，if BabyMark=Y then Part_Code=903
                '----------------------------------------------------------------------------
                If babyMark.Equals("Y") Then
                    Part_Code = "903"
                End If
                '----------------------------------------------------------------------------
                '高聯醫待確認 BY BELLA
                'Select Case medicalTypeId

                'Case "T06", "T07", "T08", "BC"
                '    If Asc(Part_Code.Substring(0, 1).ToUpper) >= 65 And Asc(Part_Code.Substring(0, 1).ToUpper) <= 68 Then
                '        Part_Code = Part_Code.Substring(0, 1).ToUpper & "40"

                '        If medicalTypeId.Equals("T06") Then
                '            Part_Code = Part_Code.Substring(0, 1).ToUpper & "30"
                '        End If
                '    End If
                'Case "AH"
                '    Part_Code = "K00"
                '    If deptCode.Equals("38") And sectionId.Equals("90") Then
                '        Part_Code = "L00"
                '    End If
                ''2010129 by ccr 增加居家護理醫療缺乏地區就醫類型AHK01, 部份負擔設定為K01
                'Case "AHK01"
                '    Part_Code = "K01"
                'Case "JA", "JB"
                '    Part_Code = Part_Code.Substring(0, 1).ToUpper & "30"
                'End Select
                '----------------------------------------------------------------------------
                '-Step2.9.依身份二
                '         If Sub_Identity_Code = 榮民(m_SubCodeServiceMan) then Part_Code=004
                '         If Sub_Identity_Code = 福保(m_SubCodeLow) then Part_Code=003
                '----------------------------------------------------------------------------
                If subIdentityCode.Equals(m_SubCodeVeteran) Then
                    Part_Code = "004"
                ElseIf subIdentityCode.Equals(m_SubCodeLow) Then
                    Part_Code = "003"
                End If
                '----------------------------------------------------------------------------
                '-Step2.10.依就醫類型設定Medical_Type_Id (先MARK,待確認)
                '          **2010/06/02 **2010/06/11 **2010/07/29預防保健，If Medical_Type_Id in (01,02,25,27,03,04,07,08,81,91)  then Case_Type_Id=A3，Part_Code=009，Insu_Paykind_Id=’’
                '          **2010/07/29弱勢新生兒聽力篩檢，If Medical_Type_Id= IC20  then Case_Type_Id=D1，Part_Code=009，Card_Sn=IC20
                '          老人感冒疫苗，If Medical_Type_Id= IC01  then Case_Type_Id=D2，Part_Code=009，Card_Sn=IC01
                '          門診戒菸，If Medical_Type_Id= IC07  then Case_Type_Id=B7，Part_Code=009，Card_Sn=IC07 **2010/12/10 Contract_Code1=ZZ01 **2012/02/14 Contract_Code1='' Part_Code=Z00 or 003
                '          慢性病連續處方，If Medical_Type_Id= AE08  then Case_Type_Id=08，Part_Code=009
                '          ...
                '   	   **2010/05/17 **2010/07/22 AIDS健保或健保HIV子宮頸抹片檢查，If Medical_Type_Id= AIDS、HIV  then Case_Type_Id=D1，Part_Code=904
                '          **2010/05/17 **2010/07/22 AIDS非健保或非健保HIV子宮頸抹片檢查，If Medical_Type_Id= AIDS1、HIV1  then Case_Type_Id=D1，Part_Code=904，Card_Sn=IC09
                '          **2010/08/17 職災病患就診，If Medical_Type_Id in ( IC06A, IC06B, IC06C, IC06D, IC06F)  then Case_Type_Id=B6，Part_Code=006，Card_Sn=IC06，Insu_Paykind_Id=2
                '          **2010/08/17 職災傷害就診，If Medical_Type_Id in ( IC06E,IC06G)  then Case_Type_Id=B6，Part_Code=006，Card_Sn=IC06，Insu_Paykind_Id=1
                '          **2010/12/21藥癮AIDS無健保病患就醫or藥癮無健保病患就醫，If Medical_Type_Id= IC09A or IC09D  then Case_Type_Id=BA，Part_Code=904，Card_Sn=IC09 
                '          **2010/12/21 TB無健保病患就醫，If Medical_Type_Id= IC09T  then Case_Type_Id=C4，Part_Code=009，Card_Sn=IC09
                '          **2011/01/19門診手術後之回診，If Medical_Type_Id= T07、BC and Part_Code部分負擔第一碼in (A、B、C、D)   then Part_Code第二、三碼= 40，Ex.A40
                '          **2011/01/19 TB就醫回診，If Medical_Type_Id= TB  then Case_Type_Id=06，Part_Code=005
                '          **2011/02/10弱勢新生兒聽力篩檢，If (Medical_Type_Id= IC20 and Sub_Identity_Code = 33福保 and Age<93天)  then Case_Type_Id=A3，Part_Code=009，Insu_Paykind_Id=’’，Card_Sn=IC20
                '          **2012/01/09 增加82, 83 同81處理
                '          **2011/03/15改為全部新生兒聽力篩檢，If (Medical_Type_Id= IC20 and Age<93天)  then Case_Type_Id=A3，Part_Code=009 依附維持為 903，Insu_Paykind_Id=’’，Card_Sn=IC20
                '          **2013/06/06 新增加就醫類型 09.口腔黏膜檢查(18歲以上原住民) 計價方式比照 08.口腔黏膜檢查
                '          **2013/06/17 新增加就醫類型 87.兒童牙齒塗氟(未滿12歲低收入,身心障礙,原住民偏遠離島區) 計價方式比照 81.兒童牙齒塗氟
                '          **2013/06/19 新增加就醫類型 84.弱勢兒童臼齒窩溝封劑服務(身心障礙學童) 計價方式比照 83.弱勢兒童臼齒窩溝封劑服務(山地原住民族地區、離島地區)
                '          **2014/03/06 新增加就醫類型 13.收容對象醫療服務計畫之矯正機關內門診, 案件類別為 D4, 部份負擔為 A13
                '----------------------------------------------------------------------------

                '2015.07.09 改成規則從PUB_Medical_Type預設 by Bella
                If pubMedicalTypeDT IsNot Nothing AndAlso pubMedicalTypeDT.Rows.Count > 0 Then
                    '移到程式進入點
                    'Dim dr As DataRow() = pubMedicalTypeDT.Select("Medical_Type_Id = '" & medicalTypeId & "'")
                    If MedicalTypeDr.Length > 0 Then
                        If StringUtil.nvl(MedicalTypeDr(0).Item("Dis_Identity_Code")).Length > 0 Then
                            Dis_Identity_Code = StringUtil.nvl(MedicalTypeDr(0).Item("Dis_Identity_Code"))
                        End If
                        If StringUtil.nvl(MedicalTypeDr(0).Item("Contract_Code1")).Length > 0 Then
                            Contract_Code1 = StringUtil.nvl(MedicalTypeDr(0).Item("Contract_Code1"))
                        End If
                        If StringUtil.nvl(MedicalTypeDr(0).Item("Contract_Code2")).Length > 0 Then
                            Contract_Code2 = StringUtil.nvl(MedicalTypeDr(0).Item("Contract_Code2"))
                        End If
                        If StringUtil.nvl(MedicalTypeDr(0).Item("Medical_Type_Ctrl_Id")).Equals("S") Then
                            '若為自費的看診目的，要把Part_Code, Card_Sn, IC_Medical_Typd_Id, Case_Type_Id,Insu_Paykind_Id 清掉
                            Part_Code = ""
                            Card_Sn = ""
                            IC_Medical_Type_Id = ""
                            Case_Type_Id = ""
                            Insu_Paykind_Id = ""
                        Else
                            '如果遇到A3案件，903 > 009 
                            If Case_Type_Id.Equals("A3") Then
                                If Not Part_Code.Equals("903") Then
                                    If StringUtil.nvl(MedicalTypeDr(0).Item("Part_Code")).Length > 0 Then
                                        Part_Code = StringUtil.nvl(MedicalTypeDr(0).Item("Part_Code"))
                                    End If
                                End If
                            Else
                                If StringUtil.nvl(MedicalTypeDr(0).Item("Part_Code")).Length > 0 Then
                                    Part_Code = StringUtil.nvl(MedicalTypeDr(0).Item("Part_Code"))
                                End If
                            End If
                            '如果卡序本身沒有預設，然後舊卡序也不是數值(數值的話表示從卡片取得的)，那就依預設的為主
                            If StringUtil.nvl(MedicalTypeDr(0).Item("Card_Sn")).Length > 0 OrElse Not IsNumeric(Card_Sn) Then
                                Card_Sn = StringUtil.nvl(MedicalTypeDr(0).Item("Card_Sn"))
                            End If
                            If StringUtil.nvl(MedicalTypeDr(0).Item("IC_Medical_Type_Id")).Length > 0 Then
                                IC_Medical_Type_Id = StringUtil.nvl(MedicalTypeDr(0).Item("IC_Medical_Type_Id"))
                            End If
                            If StringUtil.nvl(MedicalTypeDr(0).Item("Case_Type_Id")).Length > 0 Then
                                Case_Type_Id = StringUtil.nvl(MedicalTypeDr(0).Item("Case_Type_Id"))
                            End If
                        End If
                    End If
                End If


                'Select Case medicalTypeId
                '    Case "01", "02", "25", "27", "03", "04", "07", "08", "09", "81", "82", "83", "84", "87"
                '        Case_Type_Id = "A3"
                '        If Part_Code <> "903" Then
                '            Part_Code = "009"
                '        End If
                '        Insu_Paykind_Id = ""

                '    Case "13"
                '        Case_Type_Id = "D4"
                '    Case "IC20"
                '        If ageDays >= 0 And ageDays < 93 Then
                '            Case_Type_Id = "A3"
                '            If Part_Code <> "903" Then
                '                Part_Code = "009"
                '            End If
                '            Insu_Paykind_Id = ""
                '        End If
                '    Case "IC01"
                '        Case_Type_Id = "D2"
                '        Part_Code = "009"
                '        Card_Sn = "IC01"
                '    Case "IC07"
                '        '2012-02-14 配合二代戒菸2012-03-01生效修改計價規則　　成醫曾祥益
                '        Dim dateVisitDate As DateTime = Nothing
                '        Try
                '            dateVisitDate = CDate(opdVisitDateStr)
                '        Catch ex As Exception
                '            dateVisitDate = Now
                '        End Try
                '        If dateVisitDate.CompareTo(CDate("2012-03-01")) >= 0 Then
                '            'IC07 新規則
                '            Case_Type_Id = "B7"
                '            Part_Code = "009"
                '            Card_Sn = "IC07"
                '            If subIdentityCode.Equals(m_SubCodeLow) Then
                '                Part_Code = "003"
                '            Else
                '                Part_Code = "Z00"
                '            End If
                '        Else
                '            'IC07 舊規則
                '            Case_Type_Id = "B7"
                '            Part_Code = "009"
                '            Card_Sn = "IC07"
                '            Contract_Code1 = "ZZ01"
                '        End If
                '    Case "IC08"
                '        Case_Type_Id = "B8"
                '        Part_Code = "009"
                '        Card_Sn = "IC08"
                '    Case "IC09"
                '        Case_Type_Id = "C4"
                '        Part_Code = "009"
                '        Card_Sn = "IC09"
                '    Case "IC10"
                '        Case_Type_Id = "B1"
                '        Part_Code = "009"
                '        Card_Sn = "IC10"
                '    Case "IC89"
                '        Card_Sn = "IC89"
                '    Case "IC98"
                '        Card_Sn = "IC98"
                '    Case "IC99"
                '        'Part_Code = "801"
                '        Part_Code = "009"
                '        Card_Sn = "IC99"
                '    Case "IC06A", "IC06B", "IC06C", "IC06D", "IC06F", "IC06E", "IC06G"
                '        Case_Type_Id = "B6"
                '        Part_Code = "006"
                '        Card_Sn = "IC06"
                '        Insu_Paykind_Id = "2"
                '        If medicalTypeId.Equals("IC06E") Or medicalTypeId.Equals("IC06G") Then
                '            Insu_Paykind_Id = "1"
                '        End If
                '    Case "AE08"
                '        If StringUtil.IsLetter(Part_Code.Substring(0, 1)) And Not Part_Code.Substring(1, 1).Equals("2") Then
                '            Case_Type_Id = "08"
                '            Part_Code = "009"
                '        End If
                '    Case "TB", "TB1", "TB2"
                '        Case_Type_Id = "06"
                '        Part_Code = "005"
                '    Case "AA", "AB", "AG", "AI", "CA", "KID"
                '        Part_Code = "009"
                '    Case "AIDS", "HIV"
                '        Case_Type_Id = "D1"
                '        Part_Code = "904"
                '    Case "AIDS1", "HIV1"
                '        Case_Type_Id = "D1"
                '        Part_Code = "904"
                '        Card_Sn = "IC09"
                '    Case "IC09A", "IC09D"
                '        Case_Type_Id = "BA"
                '        Part_Code = "904"
                '        Card_Sn = "IC09"
                '    Case "IC09T"
                '        Case_Type_Id = "C4"
                '        Part_Code = "009"
                '        Card_Sn = "IC09"
                '        '20140305 by ccr 增加山地離島地區之就醫
                '    Case "007"  '山地離島地區之就醫
                '        Part_Code = "007"
                '    Case "008"  '經離島醫院診所轉診
                '        Part_Code = "008"
                '        '20121123 by ccr 加入91, 93, 901 
                '    Case "91"
                '        Case_Type_Id = "A3"
                '        If Part_Code <> "903" Then
                '            Part_Code = "009"
                '        End If
                '        Insu_Paykind_Id = ""
                '        Card_Sn = "IC91"
                '    Case "93"
                '        Case_Type_Id = "A3"
                '        If Part_Code <> "903" Then
                '            Part_Code = "009"
                '        End If
                '        Insu_Paykind_Id = ""
                '        Card_Sn = "IC93"
                '    Case "901"
                '        Part_Code = "901"
                '        '20121205 by ccr 加入906
                '    Case "906"
                '        Part_Code = "906"
                'End Select
                '----------------------------------------------------------------------------
                '-Step2.11.If Is_Severe_Disease=Y then Part_Code=001
                '----------------------------------------------------------------------------
                If isSevereDisease.Equals("Y") Then
                    Dim changeFlag As Boolean = True

                    Select Case Case_Type_Id
                        Case "B6"
                            If Part_Code.Equals("006") Then
                                changeFlag = False
                            End If
                        Case "06"
                            If Part_Code.Equals("005") Then
                                changeFlag = False
                            End If
                        Case "D1", "BA"
                            If Part_Code.Equals("904") Then
                                changeFlag = False
                            End If
                        Case "A3", "B1", "B9"
                            If Part_Code.Equals("009") Then
                                changeFlag = False
                            End If
                        Case Else
                    End Select

                    If changeFlag Then
                        Part_Code = "001"
                    End If
                End If
                '----------------------------------------------------------------------------
                '----------------------------------------------------------------------------
                '-Step2.12.依就醫類型(Medical_Type_Id)設定IC就醫類別 (IC_Medical_Type_Id)(先MARK,待確認)
                '          **2010/06/02 **2010/06/11 **2010/07/22 **2010/07/29
                '          當就醫類型(Medical_Type_Id)= 01、02、25、27、03、04、07、08、81、91、IC01，回傳IC就醫類別=AC預防保健。
                '          **2010/08/17當就醫類型(Medical_Type_Id)= IC06A、IC06B、IC06C、IC06D、IC06E、IC06F、IC06G，則IC就醫類別= AD職業傷害或職業病。
                '          **2011/02/10弱勢新生兒聽力篩檢，If (Medical_Type_Id= IC20 and Sub_Identity_Code = 33福保 and Age<93天) ，回傳IC就醫類別=AC預防保健
                '          **2011/08/03急診就醫類型04
                '          **2012/01/09增加82,83同81處理
                '          **2011/03/15改為全部新生兒聽力篩檢，If (Medical_Type_Id= IC20 and Age<93天)  then Case_Type_Id=A3，Part_Code=009 依附維持為 903，Insu_Paykind_Id=’’，Card_Sn=IC20
                '          **2013/06/06 新增加就醫類型 09.口腔黏膜檢查(18歲以上原住民) 計價方式比照 08.口腔黏膜檢查
                '          **2013/06/17 新增加就醫類型 87.兒童牙齒塗氟(未滿12歲低收入,身心障礙,原住民偏遠離島區) 計價方式比照 81.兒童牙齒塗氟
                '          **2013/06/19 新增加就醫類型 84.弱勢兒童臼齒窩溝封劑服務(身心障礙學童) 計價方式比照 83.弱勢兒童臼齒窩溝封劑服務(山地原住民族地區、離島地區)
                '----------------------------------------------------------------------------
                'Select Case medicalTypeId
                '    Case "01", "02", "25", "27", "03", "04", "07", "08", "09", "81", "82", "83", "84", "87", "91", "93", "IC01"
                '        IC_Medical_Type_Id = "AC"
                '    Case "IC20"
                '        If ageDays >= 0 And ageDays < 93 Then
                '            IC_Medical_Type_Id = "AC"
                '        End If
                '    Case "AE08"
                '        IC_Medical_Type_Id = "AE"
                '    Case "IC06A", "IC06B", "IC06C", "IC06D", "IC06E", "IC06F", "IC06G"
                '        IC_Medical_Type_Id = "AD"
                '    Case "IC07", "IC08", "IC09", "IC10", "IC89", "IC98", "IC99"
                '        IC_Medical_Type_Id = "CA"
                '    Case "CA", "IC07", "IC08", "IC09", "IC10", "IC89", "IC98", "IC99"
                '        IC_Medical_Type_Id = "CA"
                '    Case "T06", "T07", "T08"
                '        IC_Medical_Type_Id = medicalTypeId.Replace("T", "")
                '        '20130503 by ccr 加入指定就醫 IC_Medical_Type_Id 為 00
                '    Case "AH", "AI", "AA", "AB", "KID", "AG", "00"
                '        If medicalTypeId.Equals("KID") Then
                '            IC_Medical_Type_Id = "AI"
                '        Else
                '            IC_Medical_Type_Id = medicalTypeId
                '        End If
                '    Case "AHK01"
                '        IC_Medical_Type_Id = "AH"
                '    Case Else
                '        '20110803 add by bella for 急診就醫類型04 
                '        If isEmg.Equals("Y") Then
                '            IC_Medical_Type_Id = "04"
                '        Else
                '            If Health_Opd_Dept_Code.Equals("40") Or Health_Opd_Dept_Code.Equals("GA") Then
                '                IC_Medical_Type_Id = "02"
                '            Else
                '                IC_Medical_Type_Id = "01"
                '            End If
                '        End If
                'End Select
                '----------------------------------------------------------------------------
            Else
                opMsg.Rows.Clear()
                opMsg.Rows.Add(New Object() {-1, "尚未初始化健保資料設定的資料", ""})
                Return Nothing
            End If
            '----------------------------------------------------------------------------
            '#Step3.回傳值
            '----------------------------------------------------------------------------
            '照預設的顯示，如果沒有值還是要蓋掉 by Bella 2015-07-09
            If orgContractCode1.Length <> 0 Then
                Contract_Code1 = orgContractCode1
            End If

            If orgContractCode2.Length <> 0 Then
                Contract_Code2 = orgContractCode2
            End If


            Using returnDT As DataTable = DataSetUtil.GenDataTable("returnDT", _
                                                                      Nothing, _
                                                                      New String() {"Case_Type_Id", "Part_Code", "Insu_Paykind_Id", "Card_Sn", "IC_Medical_Type_Id", "Contract_Code1", "Contract_Code2", "Dis_Identity_Code"}, _
                                                                      New Integer() {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString})

                opMsg.Rows.Clear()
                opMsg.Rows.Add(New Object() {0, "取得健保資料設定後的資料完成!!", ""})

                returnDT.Rows.Add(New Object() {Case_Type_Id, Part_Code, Insu_Paykind_Id, Card_Sn, IC_Medical_Type_Id, Contract_Code1, Contract_Code2, Dis_Identity_Code})

                Return returnDT
            End Using
            '----------------------------------------------------------------------------
        Catch ex As Exception
            opMsg.Rows.Clear()
            opMsg.Rows.Add(New Object() {-2, "取得健保資料設定後的資料失敗", ex.ToString})
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Array和Datatable之間的轉換 for DataGridView用
    ''' </summary>
    ''' <param name="columnDataObj"></param>
    ''' <param name="transToDataTableOrNotFlag"></param>
    ''' <param name="dtName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function transColumnDataArrayToDatatableOrReverse(ByVal columnDataObj As Object, ByVal transToDataTableOrNotFlag As Boolean, Optional ByVal dtName As String = "columnDT") As Object
        Try
            If transToDataTableOrNotFlag Then
                'Array to Datatable
                With CType(columnDataObj, String(,))
                    Using dt As New DataTable
                        dt.TableName = dtName

                        For iIndex As Integer = 0 To .GetUpperBound(1)
                            dt.Columns.Add("c" & (iIndex + 1).ToString.Trim)
                        Next

                        For iRow As Integer = 0 To .GetUpperBound(0)

                            Dim row As DataRow = dt.NewRow

                            For iColumn As Integer = 0 To .GetUpperBound(1)
                                row(iColumn) = .GetValue(iRow, iColumn)
                            Next

                            dt.Rows.Add(row)
                        Next

                        Return dt
                    End Using
                End With
            Else
                'Datatable to Array
                If DataSetUtil.IsContainsData(CType(columnDataObj, DataTable)) Then
                    With CType(columnDataObj, DataTable)

                        Dim rtnColumnArray(.Rows.Count - 1, .Columns.Count - 1) As String

                        For iRow As Integer = 0 To .Rows.Count - 1
                            For iColumn As Integer = 0 To .Columns.Count - 1
                                rtnColumnArray(iRow, iColumn) = .Rows(iRow).Item(iColumn)
                            Next
                        Next

                        Return rtnColumnArray
                    End With
                Else
                    Return Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得Flag Datatable
    ''' </summary>
    ''' <param name="flagName"></param>
    ''' <param name="dValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getFlagDataTable(ByVal flagName As String, Optional ByVal dValue As String = "N") As DataTable
        Try
            Using rtnDT As New DataTable
                rtnDT.TableName = flagName & "DT"
                rtnDT.Columns.Add(flagName)
                rtnDT.Rows.Add(New Object() {dValue})

                Return rtnDT
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
