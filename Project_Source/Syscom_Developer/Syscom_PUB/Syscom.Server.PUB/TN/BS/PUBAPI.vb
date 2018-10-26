Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.DateUtil
Imports System.Text
Imports Syscom.Server.SNC

Public Class PUBAPI

    Dim log As LOGDelegate = LOGDelegate.getInstance
    Private Shared instance As PUBAPI

#Region "2009.7.6 PUB API Add By  James"

    Public Function DoPubAction(ByVal ds As DataSet) As DataSet
        Try
            If ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "QueryByOrderCode" Then
                Dim PUBIcdRuleCheckBS As New PUBIcdRuleCheckBS
                Return PUBIcdRuleCheckBS.DoPubAction(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "QueryByRuleCode" Then
                Dim PUBIcdRuleCheckBS As New PUBIcdRuleCheckBS
                Return PUBIcdRuleCheckBS.DoPubAction(ds)

            ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "QueryIcdGridData" Then
                Dim PUBIcdRuleCheckBS As New PUBIcdRuleCheckBS
                Return PUBIcdRuleCheckBS.DoPubAction(ds)

            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function getInstance() As PUBAPI
        instance = New PUBAPI
        Return instance
    End Function

    '1.1初始函數
    Public Function Initialize() As Integer
        Try
            Return 0
        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function

    '1.2終止函數
    Public Function Terminate() As Integer
        Try
            Return 0
        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function

    ''1.3擷取錯誤訊息函數
    'Public Function GetErrorMsg(ByVal nErrorCode As Integer) As String
    '    Try

    '    Catch ex As Exception

    '        Return String.Empty
    '    End Try
    'End Function


    '1.4 取得科初診的訊息 return   1:院初診  2:大分科初診 3:小分科初診  4:複診
    Public Function GetFirstVisitRecordInfo(ByVal ds As DataSet) As Integer
        Try

            Dim returnDS As New DataSet
            Dim PubDS, PubDS1, PubDS2, BelongDepDS As DataSet
            PubDS = Nothing
            PubDS1 = Nothing
            PubDS2 = Nothing
            BelongDepDS = Nothing

            Dim FindBelongDep As Boolean = False
            Dim FindDep As Boolean = False

            Dim DepCode As String = ds.Tables(0).Rows(0).Item("DepCode")

            Dim IdNo As String = ds.Tables(0).Rows(0).Item("IdNo")
            Dim chartNo As String = ds.Tables(0).Rows(0).Item("chartNo")
            Dim BelongDep As String = ds.Tables(0).Rows(0).Item("BelongDep")

            '  Dim pub As PUBDelegate = PUBDelegate.getInstance

            Dim PUBDepartmentBO As PUBDepartmentBO_E1 = PUBDepartmentBO_E1.getInstance
            Dim PUBPatientBO As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance
            ' Dim PUBFirstVisitRecordBO As PUBFirstVisitRecordBO_E1 = PUBFirstVisitRecordBO_E1.getInstance

            Dim row As DataRow

            returnDS.Tables.Add()

            row = returnDS.Tables(0).Rows.Add()
            row("VisitType") = "1"

            BelongDepDS = PUBDepartmentBO.queryPUBDepartmentByKey(DepCode)
            If BelongDepDS IsNot Nothing AndAlso BelongDepDS.Tables(0).Rows.Count > 0 Then
                BelongDep = BelongDepDS.Tables(0).Rows(0).Item(0).ToString.Trim()
                ds.Tables(0).Rows(0).Item("BelongDep") = BelongDep
            End If

            PubDS2 = PUBPatientBO.queryPubChartNoByKey(chartNo, "ChartNo")

            If PubDS2 IsNot Nothing AndAlso PubDS2.Tables(0).Rows.Count > 0 Then
                IdNo = PubDS2.Tables(0).Rows(0).Item("Idno").ToString.Trim
            Else
                Return 1

            End If

            If IdNo.Trim <> "" AndAlso IdNo IsNot Nothing Then
                PubDS = PUBPatientBO.queryPubChartNoByKey(IdNo, "IdNo")

                If PubDS.Tables(0).Rows.Count = 0 Then '找不到chartNo ,此人為院初診
                    Return 1
                    row("VisitType") = "1"


                Else '找到chartNo ,

                    For i As Integer = 0 To PubDS.Tables(0).Rows.Count - 1
                        ds.Tables(0).Rows(0).Item("ChartNo") = PubDS.Tables(0).Rows(i).Item("Chart_No").ToString().Trim()
                        ' PubDS1 = PUBFirstVisitRecordBO.queryPUBFirstVisitRecord(ds)
                        If PubDS1.Tables(0).Rows.Count > 0 Then
                            FindBelongDep = True
                            Exit For
                        End If
                    Next

                    If FindBelongDep Then '在PUBFirstVisitRecord用ChartNo ,BelongDep找到資料=> 非大分科初診 =>小分科初診或複診
                        If PubDS1 IsNot Nothing Then
                            For j As Integer = 0 To PubDS1.Tables(0).Rows.Count - 1

                                If PubDS1.Tables(0).Rows(j).Item("Dept_Code").ToString.Trim() = DepCode Then
                                    Return 4 '複診

                                    FindDep = True
                                    Exit For
                                End If
                            Next
                        End If

                        If Not FindDep Then
                            Return 3 '小分科初診

                        End If
                    Else '大分科初診
                        Return 2

                    End If
                End If

            End If

            Return 0



            '院初診：在PUB_First_Visit_Record(科初診記錄) 用Chart_No=cartNo (病歷號)查不到。
            '複診：在PUB_First_Visit_Record(科初診記錄) 用Chart_No= cartNo (病歷號)和Dept_Code=deptCode (院內科別代碼)查得到>=一筆資料。
            '大分科初診：若SELECT Belong_Dept_Code From PUB_Department Where Dept_Code IN (SELECT Belong_Dept_Code From PUB_Department Where Dept_Code) 查出的大分科的資料沒有一個等於用deptCode 查出的大分科(SELECT Belong_Dept_Code From PUB_Department Where Dept_Code =deptCode)，則回傳大分科初診。
            '小分科初診：若SELECT Belong_Dept_Code From PUB_Department Where Dept_Code IN (SELECT Belong_Dept_Code From PUB_Department Where Dept_Code) 查出的大分科的資料至少有一個等於用deptCode 查出的大分科(SELECT Belong_Dept_Code From PUB_Department Where Dept_Code =deptCode)，則回傳小分科初診。

        Catch ex As Exception

            Return -1
            Throw ex
        End Try
    End Function


    '1.5 取初診病歷號
    Public Function GetNewPatientChartNo() As String
        Try

            Dim ChartNoStr As String = SNCDelegate.getInstance.getCmmSerialNo(AbstractFactory.SncType.typeD, "Chart_No", 1, -1)

            Dim total As Integer = 0

            Dim checkStr As String = ""


            For i As Integer = ChartNoStr.Trim.Count To 6
                ChartNoStr = "0" & ChartNoStr.Trim
            Next


            'A*1 + B*2 + C*3 + D*7 + E*2 + F*3 + G*7 = I
            total = 1 * CInt(ChartNoStr.Substring(0, 1)) + _
                    2 * CInt(ChartNoStr.Substring(1, 1)) + _
                    3 * CInt(ChartNoStr.Substring(2, 1)) + _
                    7 * CInt(ChartNoStr.Substring(3, 1)) + _
                    2 * CInt(ChartNoStr.Substring(4, 1)) + _
                    3 * CInt(ChartNoStr.Substring(5, 1)) + _
                    7 * CInt(ChartNoStr.Substring(6, 1))


            If total Mod 10 <> 0 Then
                checkStr = (10 - (total Mod 10)).ToString
            Else
                checkStr = "0"
            End If


            Return ChartNoStr & checkStr



        Catch ex As Exception

            Return ""
            Throw ex
        End Try

    End Function

    '1.6 新增病患基本資料
    Public Function InsertPatient(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Try
            Dim PUBPatientBO As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance
            If conn Is Nothing Then
                Return PUBPatientBO.insert(ds)
            Else
                Return PUBPatientBO.insert(ds, conn)
            End If
        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function

    '1.7更新病患基本資料
    Public Function UpdatePatient(ByVal ds As DataSet) As Integer

        Try
            Dim PUBPatientBO As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance
            Return PUBPatientBO.update(ds)

        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function

    '1.8新增病患重大傷病記錄檔
    Public Function InsertPatientSevereDisease(ByVal ds As DataSet) As Integer
        Try
            'Dim PUBPatientSevereDiseaseBO As PUBPatientSevereDiseaseBO_E1 = PUBPatientSevereDiseaseBO_E1.getInstance
            'Return PUBPatientSevereDiseaseBO.insert(ds)
        Catch ex As Exception

            Return -1
            Throw ex
        End Try
    End Function

    '1.9更新病患重大傷病記錄檔
    Public Function UpdatePatientSevereDisease(ByVal ds As DataSet) As Integer
        Try
            'Dim PUBPatientSevereDiseaseBO As PUBPatientSevereDiseaseBO_E1 = PUBPatientSevereDiseaseBO_E1.getInstance
            'Return PUBPatientSevereDiseaseBO.update(ds)
        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function


    '1.10新增病患殘障記錄檔
    Public Function InsertPatientDisability(ByVal ds As DataSet) As Integer
        Try
            Dim PUBPatientDisabilityBO As PUBPatientDisabilityBO_E1 = PUBPatientDisabilityBO_E1.getInstance
            Return PUBPatientDisabilityBO.insert(ds)
        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function


    '1.11更新病患殘障記錄檔
    Public Function UpdatePatientDisability(ByVal ds As DataSet) As Integer
        Try
            Dim PUBPatientDisabilityBO As PUBPatientDisabilityBO_E1 = PUBPatientDisabilityBO_E1.getInstance
            Return PUBPatientDisabilityBO.update(ds)
        Catch ex As Exception

            Throw ex
        End Try

    End Function


    '1.12清空病歷主檔爽約欄位資料
    Public Function ClearPatientMisRegister(ByVal chartNo As String) As Integer
        Try
            Dim PUBPatientBO As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance
            Return PUBPatientBO.ClearPatientMisRegister(chartNo)
        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function

    '1.13新增病患身體資訊記錄檔
    Public Function InsertPatientBodyRecord(ByVal ds As DataSet) As Integer
        Try
            Dim PUBPatientBodyRecordBO As PubPatientBodyrecordBO_E1 = PubPatientBodyrecordBO_E1.getInstance
            Return PUBPatientBodyRecordBO.insert(ds)
        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function

    '1.14更新病患身體資訊記錄檔
    Public Function UpdatePatientBodyRecord(ByVal ds As DataSet) As Integer
        Try
            Dim PUBPatientBodyRecordBO As PubPatientBodyrecordBO_E1 = PubPatientBodyrecordBO_E1.getInstance
            Return PUBPatientBodyRecordBO.update(ds)
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '1.15 是否填寫初診病歷單作業
    Public Function CheckWriteFirstVisitRecord(ByVal chartNo As String, ByVal depCode As String) As DataSet
        Try
            Dim PUBFirstVisitRecordBO As PUBFirstVisitRecordBO_E1 = PUBFirstVisitRecordBO_E1.getInstance
            Return PUBFirstVisitRecordBO.CheckWriteFirstVisitRecord(chartNo, depCode)
            Return Nothing
        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '1.16 新增科初診記錄
    Public Function InsertFirstVisitRecord(ByVal ds As DataSet) As Integer
        Try
            ' Dim PUBFirstVisitRecordBO As PUBFirstVisitRecordBO_E1 = PUBFirstVisitRecordBO_E1.getInstance
            ' Return PUBFirstVisitRecordBO.insert(ds)
        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function

    '1.17  更新科初診記錄
    Public Function UpdateFirstVisitRecord(ByVal ds As DataSet) As Integer
        Try
            'Dim PUBFirstVisitRecordBO As PUBFirstVisitRecordBO_E1 = PUBFirstVisitRecordBO_E1.getInstance
            'Return PUBFirstVisitRecordBO.update(ds)
        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function

#Region "1.18 身份2取得計價身份資訊"

    ''' <summary>
    ''' 谷官
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="pubOrderPriceHT"></param>
    ''' <param name="haveSubIdtSetFlag"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetChargeMainIdentityIdInfoByInputHashTable(ByVal ds As DataSet, ByVal pubOrderPriceHT As Hashtable, ByVal haveSubIdtSetFlag As Boolean, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try

            '  Dim PUBSubIdentitySetBO As PUBSubIdentitySetBO_E1 = PUBSubIdentitySetBO_E1.getInstance
            '  Dim PUBOrderPriceBO As PUBOrderPriceBO_E1 = PUBOrderPriceBO_E1.getInstance

            Dim SubIdSetDS, OrderPriceDS As DataSet
            Dim returnDS As New DataSet
            Dim row As DataRow

            Dim pubPriceColumn() As String = New String() {"Price", "Add_Price", "Material_Ratio", "Insu_Account_Id", "Insu_Code", _
                                                           "Material_Account_Id", "Is_Kid_Add", "Is_Emg_Add", "Is_Dental_Add", "Is_Holiday_Add", _
                                                           "Order_Ratio"}
            Dim queryStr As String = ""

            returnDS.Tables.Add()
            returnDS.Tables(0).Columns.Add("Main_Identity_Id")

            For cIndex As Integer = 0 To pubPriceColumn.Length - 1
                returnDS.Tables(0).Columns.Add(pubPriceColumn(cIndex))
            Next


            row = returnDS.Tables(0).NewRow

            With ds.Tables(0).Rows(0)
                '----------------------------------------------------------------------------
                '#Step1.確定Main_Identity_Id
                '----------------------------------------------------------------------------
                '先將傳入的Main_Identity_Id(1 or 2 or 3)作為預設的Main_Identity_Id
                row("Main_Identity_Id") = .Item("Main_Identity_Id").ToString.Trim
                '----------------------------------------------------------------------------
                '-Step1.1.如果Is_Force='Y'，表強制自費 -> Main_Identity_Id=1
                '----------------------------------------------------------------------------
                If .Item("Is_Force").ToString.Trim.Equals("Y") Then
                    row("Main_Identity_Id") = "1"
                End If
                '----------------------------------------------------------------------------

                '取得Where條件
                Dim orderCode As String = .Item("Order_Code").ToString.Trim
                Dim mainIdentityId As String = row("Main_Identity_Id")
                Dim opdChargeDate As String = Date.Parse(.Item("Opd_Charge_Date").ToString).ToShortDateString

                Dim subIdentityCode As String = .Item("Sub_Identity_Code").ToString.Trim
                Dim accountId As String = .Item("Account_Id").ToString.Trim
                Dim orderTypeId As String = .Item("Order_Type_Id").ToString.Trim

                '----------------------------------------------------------------------------
                '#Step2.如果Main_Identity_Id原來就等於1(非健保但因強制自費而改變為1的情況)，需要在PUB_Sub_Identity_Set裡找看有無符合的資料
                '       如果有表示有自費項目的Order可以以健保的金額來算錢
                '----------------------------------------------------------------------------
                'If haveSubIdtSetFlag And row("Main_Identity_Id").Equals("1") And .Item("Is_Force").ToString.Trim.Equals("N") Then
                If haveSubIdtSetFlag And row("Main_Identity_Id").Equals("1") Then

                    '取得PUB_Sub_Identity_Set資料
                    SubIdSetDS = queryPubSubIdentitySet(subIdentityCode, opdChargeDate, accountId, orderCode, orderTypeId, conn)

                    '找到自費項目的Order可以以健保的金額來算錢
                    If DataSetUtil.IsContainsData(SubIdSetDS) Then
                        '設定Main_Identity_Id的Where條件
                        mainIdentityId = SubIdSetDS.Tables(0).Rows(0).Item("Main_Identity_Id").ToString.Trim
                    End If
                End If
                '----------------------------------------------------------------------------
                '----------------------------------------------------------------------------
                '#Step3.從PUB_Order_Price找出此Order的Price資訊
                '----------------------------------------------------------------------------
                '----------------------------------------------------------------------------
                '-Step3.1.以目前得到的Main_Identity_Id，取得PUB_Order_Price資料
                '----------------------------------------------------------------------------
                '取得PUB_Order_Price資料
                Dim keyValue As String = orderCode & "," & mainIdentityId

                If pubOrderPriceHT.Contains(keyValue) Then
                    Using tempDT As New DataTable
                        tempDT.TableName = "OrderPriceDT"

                        For cIndex As Integer = 0 To pubPriceColumn.Length - 1
                            tempDT.Columns.Add(pubPriceColumn(cIndex))
                        Next

                        Dim popRow As DataRow = pubOrderPriceHT.Item(keyValue)

                        Dim newRow As DataRow = tempDT.NewRow
                        For cIndex As Integer = 0 To pubPriceColumn.Length - 1
                            newRow(pubPriceColumn(cIndex)) = popRow(pubPriceColumn(cIndex))
                        Next

                        tempDT.Rows.Add(newRow)

                        OrderPriceDS = New DataSet
                        OrderPriceDS.Tables.Add(tempDT)
                    End Using
                Else
                    OrderPriceDS = queryPubOrderPrice(orderCode, mainIdentityId, opdChargeDate, conn)
                End If

                '當非自費情況時找不到資料，則表示只有定義自費的計價身份，所以Main_Identity_Id更改值為1(自費)再找一次
                If Not mainIdentityId.Equals("1") And Not DataSetUtil.IsContainsData(OrderPriceDS) Then
                    '將Main_Identity_Id更改值為1
                    row("Main_Identity_Id") = "1"
                    '再找一次Price資訊

                    keyValue = orderCode & "," & "1"

                    If pubOrderPriceHT.Contains(keyValue) Then
                        Using tempDT As New DataTable
                            tempDT.TableName = "OrderPriceDT"

                            For cIndex As Integer = 0 To pubPriceColumn.Length - 1
                                tempDT.Columns.Add(pubPriceColumn(cIndex))
                            Next

                            Dim popRow As DataRow = pubOrderPriceHT.Item(keyValue)

                            Dim newRow As DataRow = tempDT.NewRow
                            For cIndex As Integer = 0 To pubPriceColumn.Length - 1
                                newRow(pubPriceColumn(cIndex)) = popRow(pubPriceColumn(cIndex))
                            Next

                            tempDT.Rows.Add(newRow)

                            OrderPriceDS = New DataSet
                            OrderPriceDS.Tables.Add(tempDT)
                        End Using
                    Else
                        OrderPriceDS = queryPubOrderPrice(orderCode, "1", opdChargeDate, conn)
                    End If
                End If
                '----------------------------------------------------------------------------
                '-Step3.2.設定回傳值，當最後以自費還是查無此Order的Price資訊時，回傳Nothing
                '----------------------------------------------------------------------------
                If DataSetUtil.IsContainsData(OrderPriceDS) Then

                    With OrderPriceDS.Tables(0).Rows(0)
                        If .Item("Price") IsNot DBNull.Value Then
                            row("Price") = .Item("Price").ToString.Trim
                        End If
                        If .Item("Add_Price") IsNot DBNull.Value Then
                            row("Add_Price") = .Item("Add_Price").ToString.Trim
                        End If
                        If .Item("Material_Ratio") IsNot DBNull.Value Then
                            row("Material_Ratio") = .Item("Material_Ratio").ToString.Trim
                        End If
                        If .Item("Is_Kid_Add") IsNot DBNull.Value Then
                            row("Is_Kid_Add") = .Item("Is_Kid_Add").ToString.Trim
                        End If
                        If .Item("Is_Emg_Add") IsNot DBNull.Value Then
                            row("Is_Emg_Add") = .Item("Is_Emg_Add").ToString.Trim
                        End If
                        If .Item("Is_Dental_Add") IsNot DBNull.Value Then
                            row("Is_Dental_Add") = .Item("Is_Dental_Add").ToString.Trim
                        End If
                        If .Item("Is_Holiday_Add") IsNot DBNull.Value Then
                            row("Is_Holiday_Add") = .Item("Is_Holiday_Add").ToString.Trim
                        End If

                        If .Item("Insu_Account_Id") IsNot DBNull.Value Then
                            row("Insu_Account_Id") = .Item("Insu_Account_Id").ToString.Trim
                        End If
                        If .Item("Insu_Code") IsNot DBNull.Value Then
                            row("Insu_Code") = .Item("Insu_Code").ToString.Trim
                        End If
                        If .Item("Material_Account_Id") IsNot DBNull.Value Then
                            row("Material_Account_Id") = .Item("Material_Account_Id").ToString.Trim
                        End If

                        If .Item("Order_Ratio") IsNot DBNull.Value Then
                            row("Order_Ratio") = .Item("Order_Ratio").ToString.Trim
                        End If
                    End With

                    returnDS.Tables(0).Rows.Add(row)
                    Return returnDS
                Else
                    '2015-06-01 加入回傳Nothing
                    Return Nothing
                End If
                '----------------------------------------------------------------------------
            End With
        Catch ex As Exception

            'Return Nothing
            Throw ex
        End Try

    End Function

    '1.18 身份2取得計價身份資訊
    Public Function GetChargeMainIdentityIdInfo(ByVal ds As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try

            ' Dim PUBSubIdentitySetBO As PUBSubIdentitySetBO_E1 = PUBSubIdentitySetBO_E1.getInstance
            '  Dim PUBOrderPriceBO As PUBOrderPriceBO_E1 = PUBOrderPriceBO_E1.getInstance

            Dim SubIdSetDS, OrderPriceDS As DataSet
            Dim returnDS As New DataSet
            Dim row As DataRow

            Dim queryStr As String = ""

            returnDS.Tables.Add()
            returnDS.Tables(0).Columns.Add("Main_Identity_Id")
            returnDS.Tables(0).Columns.Add("Price")
            returnDS.Tables(0).Columns.Add("Add_Price")
            returnDS.Tables(0).Columns.Add("Material_Ratio")
            returnDS.Tables(0).Columns.Add("Insu_Account_Id")
            returnDS.Tables(0).Columns.Add("Insu_Code")
            returnDS.Tables(0).Columns.Add("Material_Account_Id")
            returnDS.Tables(0).Columns.Add("Is_Kid_Add")
            returnDS.Tables(0).Columns.Add("Is_Emg_Add")
            returnDS.Tables(0).Columns.Add("Is_Dental_Add")
            returnDS.Tables(0).Columns.Add("Is_Holiday_Add")

            returnDS.Tables(0).Columns.Add("Order_Ratio")

            row = returnDS.Tables(0).Rows.Add()

            With ds.Tables(0).Rows(0)
                '----------------------------------------------------------------------------
                '#Step1.確定Main_Identity_Id
                '----------------------------------------------------------------------------
                '先將傳入的Main_Identity_Id(1 or 2 or 3)作為預設的Main_Identity_Id
                row("Main_Identity_Id") = .Item("Main_Identity_Id").ToString.Trim
                '----------------------------------------------------------------------------
                '-Step1.1.如果Is_Force='Y'，表強制自費 -> Main_Identity_Id=1
                '----------------------------------------------------------------------------
                If .Item("Is_Force").ToString.Trim.Equals("Y") Then
                    row("Main_Identity_Id") = "1"
                End If
                '----------------------------------------------------------------------------

                '取得Where條件
                Dim orderCode As String = .Item("Order_Code").ToString.Trim
                Dim mainIdentityId As String = row("Main_Identity_Id")
                Dim opdChargeDate As String = Date.Parse(.Item("Opd_Charge_Date").ToString).ToShortDateString

                Dim subIdentityCode As String = .Item("Sub_Identity_Code").ToString.Trim
                Dim accountId As String = .Item("Account_Id").ToString.Trim
                Dim orderTypeId As String = .Item("Order_Type_Id").ToString.Trim

                '----------------------------------------------------------------------------
                '#Step2.如果Main_Identity_Id原來就等於1(非健保但因強制自費而改變為1的情況)，需要在PUB_Sub_Identity_Set裡找看有無符合的資料
                '       如果有表示有自費項目的Order可以以健保的金額來算錢
                '----------------------------------------------------------------------------
                If row("Main_Identity_Id").Equals("1") And .Item("Is_Force").ToString.Trim.Equals("N") Then

                    '取得PUB_Sub_Identity_Set資料
                    SubIdSetDS = queryPubSubIdentitySet(subIdentityCode, opdChargeDate, accountId, orderCode, orderTypeId, conn)

                    '找到自費項目的Order可以以健保的金額來算錢
                    If DataSetUtil.IsContainsData(SubIdSetDS) Then
                        '設定Main_Identity_Id的Where條件
                        mainIdentityId = SubIdSetDS.Tables(0).Rows(0).Item("Main_Identity_Id").ToString.Trim
                    End If
                End If
                '----------------------------------------------------------------------------
                '----------------------------------------------------------------------------
                '#Step3.從PUB_Order_Price找出此Order的Price資訊
                '----------------------------------------------------------------------------
                '----------------------------------------------------------------------------
                '-Step3.1.以目前得到的Main_Identity_Id，取得PUB_Order_Price資料
                '----------------------------------------------------------------------------
                '取得PUB_Order_Price資料
                OrderPriceDS = queryPubOrderPrice(orderCode, mainIdentityId, opdChargeDate, conn)

                '當非自費情況時找不到資料，則表示只有定義自費的計價身份，所以Main_Identity_Id更改值為1(自費)再找一次
                If Not mainIdentityId.Equals("1") And Not DataSetUtil.IsContainsData(OrderPriceDS) Then
                    '將Main_Identity_Id更改值為1
                    row("Main_Identity_Id") = "1"
                    '再找一次Price資訊
                    OrderPriceDS = queryPubOrderPrice(orderCode, "1", opdChargeDate, conn)
                End If
                '----------------------------------------------------------------------------
                '-Step3.2.設定回傳值，當最後以自費還是查無此Order的Price資訊時，回傳Nothing
                '----------------------------------------------------------------------------
                If DataSetUtil.IsContainsData(OrderPriceDS) Then

                    With OrderPriceDS.Tables(0).Rows(0)
                        If .Item("Price") IsNot DBNull.Value Then
                            row("Price") = .Item("Price").ToString.Trim
                        End If
                        If .Item("Add_Price") IsNot DBNull.Value Then
                            row("Add_Price") = .Item("Add_Price").ToString.Trim
                        End If
                        If .Item("Material_Ratio") IsNot DBNull.Value Then
                            row("Material_Ratio") = .Item("Material_Ratio").ToString.Trim
                        End If
                        If .Item("Is_Kid_Add") IsNot DBNull.Value Then
                            row("Is_Kid_Add") = .Item("Is_Kid_Add").ToString.Trim
                        End If
                        If .Item("Is_Emg_Add") IsNot DBNull.Value Then
                            row("Is_Emg_Add") = .Item("Is_Emg_Add").ToString.Trim
                        End If
                        If .Item("Is_Dental_Add") IsNot DBNull.Value Then
                            row("Is_Dental_Add") = .Item("Is_Dental_Add").ToString.Trim
                        End If
                        If .Item("Is_Holiday_Add") IsNot DBNull.Value Then
                            row("Is_Holiday_Add") = .Item("Is_Holiday_Add").ToString.Trim
                        End If

                        If .Item("Insu_Account_Id") IsNot DBNull.Value Then
                            row("Insu_Account_Id") = .Item("Insu_Account_Id").ToString.Trim
                        End If
                        If .Item("Insu_Code") IsNot DBNull.Value Then
                            row("Insu_Code") = .Item("Insu_Code").ToString.Trim
                        End If
                        If .Item("Material_Account_Id") IsNot DBNull.Value Then
                            row("Material_Account_Id") = .Item("Material_Account_Id").ToString.Trim
                        End If

                        If .Item("Order_Ratio") IsNot DBNull.Value Then
                            row("Order_Ratio") = .Item("Order_Ratio").ToString.Trim
                        End If
                    End With

                    Return returnDS
                Else
                    '2015-06-01 加入回傳Nothing.
                    Return Nothing
                End If
                '----------------------------------------------------------------------------
            End With
        Catch ex As Exception

            'Return Nothing
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 取得PUB_Sub_Identity_Set資料
    ''' </summary>
    ''' <param name="subIdentityCode">Sub_Identity_Code</param>
    ''' <param name="opdChargeDate">Opd_Charge_Date</param>
    ''' <param name="accountId">Account_Id</param>
    ''' <param name="orderCode">Order_Code</param>
    ''' <param name="orderTypeId">Order_Type_Id</param>
    ''' <returns>PUB_Sub_Identity_Set資料</returns>
    Private Function queryPubSubIdentitySet(ByVal subIdentityCode As String, ByVal opdChargeDate As String, ByVal accountId As String, ByVal orderCode As String, ByVal orderTypeId As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim queryStr As String = ""

        Try
            queryStr = " SELECT top 1 Sub_Identity_Code, Account_Id, Order_Code, Main_Identity_Id " & _
                       " FROM PUB_Sub_Identity_Set  " & _
                       " WHERE Sub_Identity_Code ='" & subIdentityCode & "' And " & _
                       " Effect_Date<='" & opdChargeDate & "' And " & _
                       " End_Date >= '" & opdChargeDate & "' And " & _
                       " (Account_Id='" & accountId & "'  OR Account_Id='' OR Account_Id Is null ) And " & _
                       " (Order_Code='" & orderCode & "'  OR Order_Code='' OR  Order_Code Is null ) And " & _
                       " (Order_Type_Id='" & orderTypeId & "'  OR Order_Type_Id='' OR  Order_Type_Id Is null ) " & _
                       " ORDER BY Order_Code Desc, Account_Id Desc, Order_Type_Id DESC "

            Dim instance As PUBSubIdentitySetBO_E1 = PUBSubIdentitySetBO_E1.getInstance

            Return instance.dynamicQuery(queryStr, conn)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得PUB_Order_Price資料
    ''' </summary>
    ''' <param name="orderCode">Order_Code</param>
    ''' <param name="mainIdentityId">Main_Identity_Id</param>
    ''' <param name="opdChargeDate">Opd_Charge_Date</param>
    ''' <returns>Price資訊</returns>
    Private Function queryPubOrderPrice(ByVal orderCode As String, ByVal mainIdentityId As String, ByVal opdChargeDate As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim queryStr As String = ""

        Try
            queryStr = " SELECT OP.Price, OP.Add_Price, OP.Material_Ratio, OP.Is_Kid_Add, OP.Is_Emg_Add, OP.Is_Dental_Add, OP.Is_Holiday_Add , OP.Insu_Account_Id, OP.Insu_Code, OP.Material_Account_Id, OP.Order_Ratio " & _
                       " FROM PUB_Order_Price OP   " & _
                       " WHERE OP.Order_Code = '" & orderCode & "' And " & _
                       "       OP.Main_Identity_Id ='" & mainIdentityId & "' And " & _
                       "       OP.Effect_Date<='" & opdChargeDate & "' And " & _
                       "       OP.End_Date >='" & opdChargeDate & "'  "

            Dim instance As PUBOrderPriceBO_E1 = PUBOrderPriceBO_E1.getInstance

            Return instance.dynamicQuery(queryStr, conn)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    '1.19 取得兒童加成率
    Public Function GetKidAddRatio(ByVal ds As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try

            Dim PUBKidAddBO As PUBKidAddBO_E1 = PUBKidAddBO_E1.getInstance


            Dim queryStr As String = ""

            '  將醫令代碼、門診批價日、保險別(身份1)、年齡帶入兒童加成基本檔找出主身份：

            queryStr = " SELECT KA.Kid_Add_Ratio FROM PUB_Kid_Add KA  " & _
                       "  WHERE KA.Order_Code = '" & ds.Tables(0).Rows(0).Item("Order_Code").ToString.Trim & "' And " & _
                       "  KA.Effect_Date<='" & CDate(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "' And " & _
                       "  KA.End_Date >='" & CDate(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "' And " & _
                       "  KA.Main_Identity_Id='" & ds.Tables(0).Rows(0).Item("Main_Identity_Id").ToString.Trim & "' And " & _
                       "  (KA.Pt_From_Id='" & StringUtil.nvl(ds.Tables(0).Rows(0).Item("Pt_From_Id")) & "' or KA.Pt_From_Id = '' or KA.Pt_From_Id = null) And " & _
                       "  KA.Age_Start <= '" & ds.Tables(0).Rows(0).Item("Age").ToString.Trim & "' And " & _
                       "  KA.Age_End >= '" & ds.Tables(0).Rows(0).Item("Age").ToString.Trim & "' " & _
                       "  order by KA.Pt_From_Id desc"


            Return PUBKidAddBO.dynamicQuery(queryStr, conn)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    '1.20 取得牙科轉診加成率
    Public Function GetDentalAddRatio(ByVal ds As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try

            Dim PUBDentalAddBO As PUBDentalAddBO_E1 = PUBDentalAddBO_E1.getInstance

            Dim queryStr As String = ""


            queryStr = " SELECT DA.Dental_Add_Ratio FROM PUB_Dental_Add DA  " & _
                       "  WHERE DA.Order_Code = '" & ds.Tables(0).Rows(0).Item("Order_Code").ToString.Trim & "' And " & _
                       "  DA.Effect_Date<='" & CDate(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "' And " & _
                       "  DA.End_Date >='" & CDate(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "' And " & _
                       "  DA.Main_Identity_Id='" & ds.Tables(0).Rows(0).Item("Main_Identity_Id").ToString.Trim & "' And " & _
                       "  (DA.Pt_From_Id='" & StringUtil.nvl(ds.Tables(0).Rows(0).Item("Pt_From_Id")) & "' or DA.Pt_From_Id = '' or DA.Pt_From_Id = null)  " & _
                       "  order by DA.Pt_From_Id desc"

            Return PUBDentalAddBO.dynamicQuery(queryStr, conn)

        Catch ex As Exception

            'Return Nothing
            Throw ex
        End Try

    End Function

    Public Function GetDeptAddRatio(ByVal valueDT As DataTable, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim cmdStr As New StringBuilder

        Try
            Dim deptCode As String = StringUtil.nvl(valueDT.Rows(0).Item("Dept_Code"))
            Dim sectionId As String = StringUtil.nvl(valueDT.Rows(0).Item("Section_Id"))
            Dim chargeDate As Date = CDate(StringUtil.nvl(valueDT.Rows(0).Item("Opd_Charge_Date")))
            Dim orderCode As String = StringUtil.nvl(valueDT.Rows(0).Item("Order_Code"))
            Dim mainIdentityId As String = StringUtil.nvl(valueDT.Rows(0).Item("Main_Identity_Id"))

            'SQL
            cmdStr.AppendLine("Select")
            cmdStr.AppendLine("Dept_Add_Ratio")
            cmdStr.AppendLine("from PUB_Dept_Add")
            cmdStr.AppendLine("where 1 = 1")
            cmdStr.AppendLine("and '" & chargeDate.ToShortDateString & "' >= Effect_Date")
            cmdStr.AppendLine("and '" & chargeDate.ToShortDateString & "' <= End_Date")
            cmdStr.AppendLine("and Order_Code = '" & orderCode & "'")
            cmdStr.AppendLine("And Main_Identity_Id = '" & mainIdentityId & "'")
            cmdStr.AppendLine("And (Pt_From_Id = '" & StringUtil.nvl(valueDT.Rows(0).Item("Pt_From_Id")) & "' or Pt_From_Id = '' or Pt_From_Id = null)")
            cmdStr.AppendLine("And Dept_Code = (select top 1 rtrim(Health_Opd_Dept_Code) from Pub_Dept_Sect where isnull(Dc,'') <> 'Y' and Dept_Code='" & deptCode & "' and Section_Id='" & sectionId & "')")
            cmdStr.AppendLine("order by Pt_From_Id desc")

            Dim instance As PubDeptAddBO = PubDeptAddBO.GetInstance

            Return instance.dynamicQuery(cmdStr.ToString, conn)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetEmgAddRatio(ByVal valueDT As DataTable, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim cmdStr As New StringBuilder

        Try
            Dim chargeDate As Date = CDate(StringUtil.nvl(valueDT.Rows(0).Item("Opd_Charge_Date")))
            Dim orderCode As String = StringUtil.nvl(valueDT.Rows(0).Item("Order_Code"))
            Dim mainIdentityId As String = StringUtil.nvl(valueDT.Rows(0).Item("Main_Identity_Id"))

            'SQL
            cmdStr.AppendLine("Select")
            cmdStr.AppendLine("Emg_Add_Ratio")
            cmdStr.AppendLine("from PUB_Emg_Add")
            cmdStr.AppendLine("where 1 = 1")
            cmdStr.AppendLine("and '" & chargeDate.ToShortDateString & "' >= Effect_Date")
            cmdStr.AppendLine("and '" & chargeDate.ToShortDateString & "' <= End_Date")
            cmdStr.AppendLine("and Order_Code = '" & orderCode & "'")
            cmdStr.AppendLine("And Main_Identity_Id = '" & mainIdentityId & "'")
            cmdStr.AppendLine("And (Pt_From_Id = '" & StringUtil.nvl(valueDT.Rows(0).Item("Pt_From_Id")) & "' or Pt_From_Id = '' or Pt_From_Id = null)")
            cmdStr.AppendLine("order by Pt_From_Id desc")

            Dim instance As PubEmgAddBO = PubEmgAddBO.GetInstance

            Return instance.dynamicQuery(cmdStr.ToString, conn)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetMajorcareAddRatio(ByVal valueDT As DataTable, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim cmdStr As New StringBuilder

        Try
            Dim MajorcareCode As String = StringUtil.nvl(valueDT.Rows(0).Item("Majorcare_Code"))
            Dim chargeDate As Date = CDate(StringUtil.nvl(valueDT.Rows(0).Item("Opd_Charge_Date")))
            Dim orderCode As String = StringUtil.nvl(valueDT.Rows(0).Item("Order_Code"))
            Dim PtFromId As String = StringUtil.nvl(valueDT.Rows(0).Item("Pt_From_Id"))

            'SQL
            cmdStr.AppendLine("Select")
            cmdStr.AppendLine("Add_Ratio")
            cmdStr.AppendLine("from PUB_Majorcare_Add")
            cmdStr.AppendLine("where 1 = 1")
            cmdStr.AppendLine("and '" & chargeDate.ToShortDateString & "' >= Effect_Date")
            cmdStr.AppendLine("and '" & chargeDate.ToShortDateString & "' <= End_Date")
            cmdStr.AppendLine("and Order_Code = '" & orderCode & "'")
            cmdStr.AppendLine("And (Pt_From_Id = '" & StringUtil.nvl(valueDT.Rows(0).Item("Pt_From_Id")) & "' or Pt_From_Id = '' or Pt_From_Id = null)")
            cmdStr.AppendLine("And Majorcare_Code ='" & MajorcareCode & "'")
            cmdStr.AppendLine("order by Pt_From_Id desc")

            Dim instance As PubMajorcareAddBO = PubMajorcareAddBO.GetInstance

            Return instance.dynamicQuery(cmdStr.ToString, conn)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '1.21 取得合約身份折扣記帳設定資訊
    Public Function GetContractSetInfo(ByVal ds As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try

            Dim PUBContractSetBO As PubContractSetBO = PUBContractSetBO.GetInstance
            Dim queryStr As String = ""

            '將合約機關代碼、醫令代碼、門診批價日、醫令類型、院內費用項目帶入合約身份折扣記帳設定檔找出主身份：



            queryStr = " SELECT top 1 CS.Discount_Ratio, CS.Payself_Amt,   CS.Keep_Account_Ratio , CS.Keep_Account_Amt " & _
                       " FROM PUB_Contract_Set CS " & _
                       " WHERE CS.Contract_Code='" & ds.Tables(0).Rows(0).Item("Contract_Code").ToString.Trim & "' And " & _
                       " (CS.Sub_Identity_Code='" & ds.Tables(0).Rows(0).Item("Sub_Identity_Code").ToString.Trim & "' or CS.Sub_Identity_Code = '' or CS.Sub_Identity_Code is null) And " & _
                       " CS.Effect_Date<='" & Date.Parse(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "' And " & _
                       " CS.End_Date >= '" & Date.Parse(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "' And " & _
                       " (CS.Order_Type_Id ='" & ds.Tables(0).Rows(0).Item("Order_Type_Id").ToString.Trim & "' OR CS.Order_Type_Id ='' OR CS.Order_Type_Id is null ) And " & _
                       " (CS.Account_Id ='" & ds.Tables(0).Rows(0).Item("Account_Id").ToString.Trim & "' OR CS.Account_Id ='' OR CS.Account_Id is null ) And " & _
                       " (CS.Order_Code ='" & ds.Tables(0).Rows(0).Item("Order_Code").ToString.Trim & "' OR CS.Order_Code = '' OR CS.Order_Code is null) " & _
                       " ORDER BY CS.Sub_Identity_Code Desc, CS.Order_Code Desc, CS.Account_Id Desc, CS.Order_Type_Id DESC  "

            '找出結果中的第一筆才是所需要的資料()

            Return PUBContractSetBO.dynamicQuery(queryStr, conn)
        Catch ex As Exception

            'Return Nothing
            Throw ex
        End Try

    End Function

    Public Function GetContractPartSetInfo(ByVal ds As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim cmdStr As New StringBuilder

        Try
            'SQL
            cmdStr.AppendLine("select top 1")
            cmdStr.AppendLine("Contract_Code,")
            cmdStr.AppendLine("Sub_Identity_Code,")
            cmdStr.AppendLine("Keep_Account_Ratio,")
            cmdStr.AppendLine("Keep_Account_Amt")
            cmdStr.AppendLine("from Pub_Contract_Part_Set")
            cmdStr.AppendLine("where 1=1")
            cmdStr.AppendLine("and Contract_Code = '" & ds.Tables(0).Rows(0).Item("Contract_Code").ToString.Trim & "'")
            cmdStr.AppendLine("and (Sub_Identity_Code = '" & ds.Tables(0).Rows(0).Item("Sub_Identity_Code").ToString.Trim & "' or Sub_Identity_Code = '' or Sub_Identity_Code is null)")
            cmdStr.AppendLine("and Effect_Date <= '" & CDate(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "'")
            cmdStr.AppendLine("and End_Date >= '" & CDate(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "'")
            cmdStr.AppendLine("order by Sub_Identity_Code desc, Contract_Code")

            Dim instance As PUBContractPartSetBO_E1 = PUBContractPartSetBO_E1.getInstance

            Return instance.dynamicQuery(cmdStr.ToString, conn)

        Catch ex As Exception

            Throw ex
        End Try
    End Function

    '1.22 取得優待身份折扣設定資訊
    Public Function GetDisIdentitySetInfo(ByVal ds As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try
            Dim PUBDisIdentitySetBO As PUBDisIdentitySetBO_E1 = PUBDisIdentitySetBO_E1.getInstance
            Dim queryStr As String = ""


            queryStr = " SELECT top 1 Discount_Ratio FROM PUB_Dis_Identity_Set" & _
                       " WHERE Dis_Identity_Code = '" & ds.Tables(0).Rows(0).Item("Dis_Identity_Code").ToString.Trim & "' And " & _
                       " Effect_Date<='" & CType(ds.Tables(0).Rows(0).Item("Opd_Charge_Date"), Date).ToString("yyyy/MM/dd") & "' And " & _
                       " End_Date >='" & CType(ds.Tables(0).Rows(0).Item("Opd_Charge_Date"), Date).ToString("yyyy/MM/dd") & "' And " & _
                       " (Sub_Identity_Code = '" & ds.Tables(0).Rows(0).Item("Sub_Identity_Code").ToString.Trim & "' or Sub_Identity_Code = '' or Sub_Identity_Code is null) And " & _
                       " (Account_Id='" & ds.Tables(0).Rows(0).Item("Account_Id").ToString.Trim & "' OR Account_Id='' OR Account_Id Is null ) And " & _
                       " (Order_Code='" & ds.Tables(0).Rows(0).Item("Order_Code").ToString.Trim & "'  OR Order_Code='' OR  Order_Code Is null ) And " & _
                       " (Order_Type_Id='" & ds.Tables(0).Rows(0).Item("Order_Type_Id").ToString.Trim & "'  OR Order_Type_Id='' OR  Order_Type_Id Is null ) And" & _
                       " (Is_Payself_Flag='" & ds.Tables(0).Rows(0).Item("Is_Payself_Flag").ToString.Trim & "'  OR Is_Payself_Flag='' OR  Is_Payself_Flag Is null ) " & _
                       " ORDER BY Is_Payself_Flag Desc, Sub_Identity_Code Desc, Order_Code Desc, Account_Id Desc, Order_Type_Id DESC "

            Return PUBDisIdentitySetBO.dynamicQuery(queryStr, conn)

        Catch ex As Exception

            Throw ex
        End Try

    End Function

    '1.23 取得病患合約機構記帳累積資訊
    Public Function GetPatientQuotaInfo(ByVal ds As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try

            Dim PUBPatientQuotaBO As PUBPatientQuotaBO_E1 = PUBPatientQuotaBO_E1.getInstance
            Dim queryStr As String = ""


            queryStr = " SELECT PQ.* FROM PUB_Patient_Quota PQ " & _
                       " WHERE PQ.Chart_No ='" & ds.Tables(0).Rows(0).Item("Chart_No").ToString.Trim & "' And " & _
                       " PQ.Contract_Code ='" & ds.Tables(0).Rows(0).Item("Contract_Code").ToString.Trim & "' And " & _
                       " PQ.Effect_Date<='" & Date.Parse(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "' And " & _
                       " PQ.End_Date >='" & Date.Parse(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "' And " & _
                       " (PQ.Sub_Identity_Code ='" & ds.Tables(0).Rows(0).Item("Sub_Identity_Code").ToString.Trim & "' or PQ.Sub_Identity_Code ='' or PQ.Sub_Identity_Code is null) " & _
                       " ORDER BY PQ.Sub_Identity_Code Desc"


            'QUOTA_AMT(額度)= PQ.Quota_Amt
            'USED_QUOTA_AMT(已用額度)= PQ.Used_Quota_Amt
            'EFFECT_DATE(生效日)= PQ.Effect_Date

            Return PUBPatientQuotaBO.dynamicQuery(queryStr, conn)

        Catch ex As Exception

            'Return Nothing
            Throw ex
        End Try

    End Function


    '1.24 更新病患合約機構記帳累積資訊
    Public Function UpdatePatientQuota(ByVal ds As DataSet, Optional ByRef conn As IDbConnection = Nothing) As Integer
        Try

            Dim PUBPatientQuotaBO As PUBPatientQuotaBO_E1 = PUBPatientQuotaBO_E1.getInstance
            Return PUBPatientQuotaBO.update(ds, conn)

            '資料對應到PUB_Patient_Quota(病患合約機構記帳累積檔)
            'PUB_Patient_Quota.Modified_Time = 傳入修改時間或資料修改的系統時間

        Catch ex As Exception

            'Return -1
            Throw ex
        End Try

    End Function

    '1.25 取得合約機構記帳累積資訊
    Public Function GetContractQuotaInfo(ByVal ds As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try

            Dim PUBContractQuotaBO As PUBContractQuotaBO_E1 = PUBContractQuotaBO_E1.getInstance
            Dim queryStr As String = ""


            queryStr = " SELECT CQ.* FROM PUB_Contract_Quota CQ " & _
                       " WHERE CQ.Contract_Code ='" & ds.Tables(0).Rows(0).Item("Contract_Code").ToString.Trim & "' And " & _
                       "       CQ.Effect_Date<='" & CDate(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "' And " & _
                       "       CQ.End_Date >='" & CDate(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "' And " & _
                       "       (CQ.Sub_Identity_Code ='" & ds.Tables(0).Rows(0).Item("Sub_Identity_Code").ToString.Trim & "' or CQ.Sub_Identity_Code ='' or CQ.Sub_Identity_Code is null) " & _
                       " Order By CQ.Sub_Identity_Code Desc"


            Return PUBContractQuotaBO.dynamicQuery(queryStr, conn)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    '1.26 更新合約機構記帳累積資訊
    Public Function UpdateContractQuota(ByVal ds As DataSet, Optional ByRef conn As IDbConnection = Nothing) As Integer
        Try

            Dim PUBContractQuotaBO As PUBContractQuotaBO_E1 = PUBContractQuotaBO_E1.getInstance
            Return PUBContractQuotaBO.update(ds, conn)
            '資料對應到PUB_Contract_Quota(合約機構記帳累積檔)
            'PUB_Contract_Quota.Modified_Time = 傳入修改時間或資料修改的系統時間


        Catch ex As Exception
            Throw ex
        End Try

    End Function


    '1.27 取得部份負擔基本檔資訊
    Public Function GetPartInfo(ByVal ds As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try
            Dim PUBPartBO As PUBPartBO_E1 = PUBPartBO_E1.getInstance
            Dim queryStr As String = ""

            queryStr = " SELECT P.Part_Name, P.Part_Amt, P.Part_Ratio " & _
                       " FROM PUB_Part P " & _
                       " WHERE P.Part_Code='" & ds.Tables(0).Rows(0).Item("Part_Code").ToString.Trim & "' And " & _
                       " P.Effect_Date<='" & CDate(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "' And " & _
                       " P.End_Date >='" & CDate(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "'  "


            Return PUBPartBO.dynamicQuery(queryStr, conn)

        Catch ex As Exception

            'Return Nothing
            Throw ex
        End Try

    End Function

    '1.28 取得部份負擔優待基本檔資訊
    Public Function GetPartDiscountInfo(ByVal ds As DataSet, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Try

            Dim PUBPartDiscountBO As PUBPartDiscountBO_E1 = PUBPartDiscountBO_E1.getInstance
            Dim queryStr As String = ""

            queryStr = " SELECT PD.Discount_Ratio " & _
                       " FROM PUB_Part_Discount PD  " & _
                       " WHERE 1=1" & _
                       " And PD.Dis_Identity_Code='" & ds.Tables(0).Rows(0).Item("Dis_Identity_Code").ToString.Trim & "'" & _
                       " And (PD.Sub_Identity_Code='" & ds.Tables(0).Rows(0).Item("Sub_Identity_Code").ToString.Trim & "' Or PD.Sub_Identity_Code='' Or PD.Sub_Identity_Code is null)" & _
                       " And (PD.Part_Code='" & ds.Tables(0).Rows(0).Item("Part_Code").ToString.Trim & "' Or PD.Part_Code='' Or PD.Part_Code is null)" & _
                       " And PD.Effect_Date<='" & CDate(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "'" & _
                       " And PD.End_Date >='" & CDate(ds.Tables(0).Rows(0).Item("Opd_Charge_Date")).ToShortDateString & "'" & _
                       " Order By PD.Sub_Identity_Code Desc, PD.Part_Code Desc"

            Return PUBPartDiscountBO.dynamicQuery(queryStr, conn)

        Catch ex As Exception

            'Return Nothing
            Throw ex
        End Try

    End Function


    '1.29 新增病患預約記錄檔
    Public Function InsertPatientSchedule(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Try
            Dim PubPatientScheduleBO As PubPatientScheduleBO_E1 = PubPatientScheduleBO_E1.getInstance
            If conn Is Nothing Then
                Return PubPatientScheduleBO.insert(ds)
            Else
                Return PubPatientScheduleBO.insert(ds, conn)
            End If
        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function

    '1.30 更新病患預約記錄檔
    Public Function UpdatePatientSchedule(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Try
            Dim PubPatientScheduleBO As PubPatientScheduleBO_E1 = PubPatientScheduleBO_E1.getInstance
            Return PubPatientScheduleBO.update(ds, conn)

        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function

    '1.32 刪除病患預約記錄檔
    Public Function DeletePatientSchedule(ByVal Chart_No As String, ByVal Book_Date As Date, ByVal Book_Time As String, ByVal CheckIn_Dept_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Try
            Dim PubPatientScheduleBO As PubPatientScheduleBO_E1 = PubPatientScheduleBO_E1.getInstance
            Return PubPatientScheduleBO.DeleteByKeys(Chart_No, Book_Date, Book_Time, CheckIn_Dept_Code, conn)

        Catch ex As Exception

            Return -1
            Throw ex
        End Try

    End Function


    '檢查證號
    Public Function CheckIdNo(ByVal strIdNo As String, ByRef outputIdNo As String, Optional ByVal chkFlag As Integer = 0) As Integer

        Try

            If strIdNo.Length = 0 OrElse (strIdNo.Length = 11 AndAlso strIdNo.Substring(10, 1).ToUpper.Trim = "P") Then
                outputIdNo = strIdNo
                Return 0

            End If


            If strIdNo.Length = 10 AndAlso Asc(strIdNo.Substring(0, 1).ToUpper) >= 65 AndAlso Asc(strIdNo.Substring(0, 1).ToUpper) <= 90 AndAlso _
              (strIdNo.Substring(1, 1) = "1" OrElse strIdNo.Substring(1, 1) = "2") AndAlso IsNumeric(strIdNo.Substring(2, 8)) Then




                Dim PUBPatientBO As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance


                Dim ds As DataSet = Nothing

                If chkFlag <> 0 Then
                    'chkFlag：0不檢查(預設)； >0要檢查
                    ds = PUBPatientBO.queryPubPatientByIdno(strIdNo)
                End If

                If ds IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                    'outputIdNo = strIdNo + 第11碼填 'P’ (中間補空白)
                    'Return 88(統號與目前病歷號重複)

                    outputIdNo = strIdNo & "P"

                    Return 88


                Else


                    If checkId(strIdNo) Then

                        outputIdNo = strIdNo
                        Return 0 ' (統號OK)
                    Else
                        outputIdNo = strIdNo & "P"
                        Return 99 ' (統號不合邏輯)

                    End If



                End If


            Else

                If strIdNo.Trim.Length < 10 Then

                    For i As Integer = strIdNo.Trim.Length To 9
                        strIdNo = strIdNo & " "
                    Next

                End If

                outputIdNo = strIdNo & "P"

                Return 77 ' (不為統號)

            End If

        Catch ex As Exception

            Return -1
        End Try




    End Function


    ''' <summary>
    ''' 身分證號檢驗 
    ''' id:身分證號
    ''' </summary>
    ''' <returns>True:身分證合格  False:身分證號不合格</returns>
    ''' <remarks></remarks>''' 
    Private Function checkId(ByVal id As String) As Boolean
        Try




            Dim idvalue As Integer, checkvalue As Integer

            If id.Length <> 10 Then
                Return False
            End If


            idvalue = Int(getCountyCode(Microsoft.VisualBasic.Left(id, 1)) / 10)
            idvalue = idvalue + (getCountyCode(Microsoft.VisualBasic.Left(id, 1)) Mod 10) * 9


            For i = 2 To 9
                idvalue = idvalue + Mid(id, i, 1) * (10 - i)
            Next

            checkvalue = (10 - (idvalue Mod 10)) Mod 10

            If (checkvalue = Microsoft.VisualBasic.Right(id, 1)) Then
                Return True
            Else

                Return False
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

    ''' <summary>
    ''' 取得地區號 身分證驗證用
    ''' country:身分證號字母
    ''' </summary>
    ''' <returns>地區號</returns>
    ''' <remarks></remarks>''' 
    Private Function getCountyCode(ByVal county As String) As Integer
        Select Case UCase(county)
            Case "A" : getCountyCode = 10
            Case "B" : getCountyCode = 11
            Case "C" : getCountyCode = 12
            Case "D" : getCountyCode = 13
            Case "E" : getCountyCode = 14
            Case "F" : getCountyCode = 15
            Case "G" : getCountyCode = 16
            Case "H" : getCountyCode = 17
            Case "J" : getCountyCode = 18
            Case "K" : getCountyCode = 19
            Case "L" : getCountyCode = 20
            Case "M" : getCountyCode = 21
            Case "N" : getCountyCode = 22
            Case "P" : getCountyCode = 23
            Case "Q" : getCountyCode = 24
            Case "R" : getCountyCode = 25
            Case "S" : getCountyCode = 26
            Case "T" : getCountyCode = 27
            Case "U" : getCountyCode = 28
            Case "V" : getCountyCode = 29
            Case "W" : getCountyCode = 32
            Case "X" : getCountyCode = 30
            Case "Y" : getCountyCode = 31
            Case "Z" : getCountyCode = 33
            Case "I" : getCountyCode = 34
            Case "O" : getCountyCode = 35
        End Select
    End Function




    '判斷是否該病歷號存在
    Public Function CheckChartNoExist(ByVal ChartNo As String) As Integer
        Try

            Dim PUBPatientBO As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance
            Dim queryStr As String = ""
            Dim ds As DataSet

            queryStr = " SELECT Chart_No FROM PUB_Patient WHERE Chart_No='" & ChartNo.Trim & "' "


            ds = PUBPatientBO.dynamicQuery(queryStr)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Return 0
            Else
                Return -1
            End If

        Catch ex As Exception

            Return -1
            'Throw ex
        End Try

    End Function

#End Region

#Region "2009.12.10 PUB API Add By Alan"
    Public Function InsertPatientData(ByVal ChartNo As String, ByVal UserId As String, _
                                      ByVal CriticalIllness As DataSet, ByVal Allergic As DataSet) As Integer

        Dim result As Integer = 0

        Try

            Dim PUBPatientAllergyBO As PUBPatientAllergyBO_E1 = PUBPatientAllergyBO_E1.getInstance
            Dim PUBPatientSevereDiseaseBO As PUBPatientSevereDiseaseBO_E1 = PUBPatientSevereDiseaseBO_E1.getInstance


            result = PUBPatientSevereDiseaseBO.updatePubPatientSevereDiseaseByChartNo(UserId, ChartNo, CriticalIllness)
            result = PUBPatientAllergyBO.updatePUBPatientAllergyByChartNo(UserId, ChartNo, Allergic)

            Return result

        Catch ex As Exception

            Return result
            Throw ex
        End Try

    End Function


    Public Function InsertPatientData2(ByVal ChartNo As String, ByVal UserId As String, _
                                    ByVal CriticalIllness As DataSet, ByVal Allergic As DataSet, ByVal Prevent As DataSet) As Integer

        Dim result As Integer = 0
        Dim pvtGetPreventiveCareExe As New DataSet
        Dim pvtOMOPreventHC As New DataSet

        Try

            Dim PUBPatientAllergyBO As PUBPatientAllergyBO_E1 = PUBPatientAllergyBO_E1.getInstance
            Dim PUBPatientSevereDiseaseBO As PUBPatientSevereDiseaseBO_E1 = PUBPatientSevereDiseaseBO_E1.getInstance
            Dim PubPreventiveCareExeBO As PUBPreventiveCareExeBO_E1 = PUBPreventiveCareExeBO_E1.getInstance
            Dim PubPreventiveCareBO As PUBPreventiveCareBO_E1 = PUBPreventiveCareBO_E1.getInstance
            Dim OmoPreventationHealthCareBO As New OmoPreventationHealthCare

            Try
                If CriticalIllness IsNot Nothing Then
                    result = PUBPatientSevereDiseaseBO.updatePubPatientSevereDiseaseByChartNo(UserId, ChartNo, CriticalIllness)
                End If
            Catch ex As Exception
            End Try
          
            Try
                If Allergic IsNot Nothing Then
                    result = PUBPatientAllergyBO.updatePUBPatientAllergyByChartNo(UserId, ChartNo, Allergic)
                End If
            Catch ex As Exception
            End Try
        
            If Prevent IsNot Nothing Then

                '讀取PUB_Preventive_Care設定檔資料 04不會在預防保健區塊出現
                Dim pvtServiceItemId, pvtExamDate, pvtHospitalCode, pvtExamItemId As String
                'Dim pvtAgeControlId, pvtAgeStart, pvtAgeEnd As String
                'Dim pvtExecuteDate, pvtRecentDate, pvtCareEffectDate, pvtCareEndDate, pvtCareEffectDate2, pvtCareEndDate2 As String

                Dim Care_Item_Code, Care_Order_Code As String

                For i = 0 To Prevent.Tables(0).Rows.Count - 1

                    pvtServiceItemId = Prevent.Tables(0).Rows(i).Item("SERVICE_ITEM_ID").ToString.Trim
                    pvtExamDate = Prevent.Tables(0).Rows(i).Item("EXAM_DATE").ToString.Trim
                    pvtHospitalCode = Prevent.Tables(0).Rows(i).Item("HOSPITAL_CODE").ToString.Trim
                    pvtExamItemId = Prevent.Tables(0).Rows(i).Item("EXAM_ITEM_ID").ToString.Trim

                    If pvtServiceItemId <> "" AndAlso pvtExamDate <> "" Then


                        pvtExamDate = (CLng(pvtExamDate) + 19110000).ToString
                        pvtExamDate = pvtExamDate.Substring(0, 4) & "/" & _
                                      pvtExamDate.Substring(4, 2) & "/" & _
                                      pvtExamDate.Substring(6, 2)

                        Care_Order_Code = pvtExamItemId

                        Care_Item_Code = GetCareItemCode(Care_Order_Code)

                        If Care_Item_Code = "" Then
                            Continue For
                        End If

                        '判斷預防保健執行記錄檔(OMO_Preventation_Health_Care) 只查沒執行過的 Execute_Date = null
                        pvtOMOPreventHC = queryOMOPreventationHealthCare(ChartNo, Care_Item_Code, Care_Order_Code, pvtExamDate)


                        If pvtOMOPreventHC IsNot Nothing AndAlso pvtOMOPreventHC.Tables.Count > 0 AndAlso pvtOMOPreventHC.Tables(0).Rows.Count > 0 Then
                            '有找到 , 更新 Execute_Date_External , Exexute_External_Hospital , Execute_Date

                            For j = 0 To pvtOMOPreventHC.Tables(0).Rows.Count - 1

                                pvtOMOPreventHC.Tables(0).Rows(j).Item("Execute_Date_External") = CDate(pvtExamDate).ToShortDateString
                                'pvtOMOPreventHC.Tables(0).Rows(j).Item("Exexute_External_Hospital") = pvtHospitalCode
                                pvtOMOPreventHC.Tables(0).Rows(j).Item("Execute_Date") = CDate(pvtExamDate).ToShortDateString
                                pvtOMOPreventHC.Tables(0).Rows(j).Item("Modified_User") = "ICCard"
                                pvtOMOPreventHC.Tables(0).Rows(j).Item("Modified_Time") = Now.ToString("yyyy-MM-dd HH:mm:ss")


                            Next

                            OmoPreventationHealthCareBO.update(pvtOMOPreventHC)

                        Else
                            '沒找到,新增

                            Dim pvtDs As New DataSet
                            Dim pvtDs2 As New DataSet
                            Dim pvtPreventNo As String = "1"
                            Dim pvtCareSeq As String = ""

                            pvtDs = PubPreventiveCareBO.queryOMOPreventationHealthCareMaxNo(ChartNo)
                            If pvtDs IsNot Nothing AndAlso pvtDs.Tables IsNot Nothing AndAlso pvtDs.Tables(0).Rows.Count > 0 AndAlso _
                               pvtDs.Tables(0).Rows(0).Item("Prevent_No").ToString.Trim <> "" Then
                                pvtPreventNo = CStr(CInt(pvtDs.Tables(0).Rows(0).Item("Prevent_No").ToString.Trim) + 1)
                            End If

                            pvtDs2 = PubPreventiveCareBO.getPUBPreventiveCareSeq(Care_Item_Code, Care_Order_Code)
                            If pvtDs2 IsNot Nothing AndAlso pvtDs2.Tables IsNot Nothing AndAlso pvtDs2.Tables(0).Rows.Count > 0 Then
                                pvtCareSeq = pvtDs2.Tables(0).Rows(0).Item("Care_Cardseq").ToString.Trim
                            End If

                            Dim OmoPreventationHealthCareDataDT As DataTable = getDataTableForOMOPreventationHealthCare()

                            Dim row As DataRow = OmoPreventationHealthCareDataDT.NewRow

                            row("Chart_No") = ChartNo
                            row("Prevent_No") = pvtPreventNo
                            row("Care_Item_Code") = Care_Item_Code
                            row("Care_Order_Code") = Care_Order_Code
                            row("Care_Cardseq") = pvtCareSeq
                            row("Effect_Date") = CDate(pvtExamDate).ToShortDateString
                            row("End_Date") = CDate(pvtExamDate).ToShortDateString

                            row("Execute_Date") = CDate(pvtExamDate).ToShortDateString
                            row("Execute_Date_External") = CDate(pvtExamDate).ToShortDateString
                            'row("Exexute_External_Hospital") = pvtHospitalCode
                            row("Create_User") = "ICCard"
                            row("Create_Time") = Now.ToString("yyyy-MM-dd HH:mm:ss")

                            OmoPreventationHealthCareDataDT.Rows.Add(row)


                            Dim OmoPreventationHealthCareDataDS As New DataSet

                            OmoPreventationHealthCareDataDS.Tables.Add(OmoPreventationHealthCareDataDT)

                            OmoPreventationHealthCareBO.insert(OmoPreventationHealthCareDataDS)

                        End If

                    End If

                Next

            End If

            Return result

        Catch ex As Exception

            Return result
            Throw ex
        End Try

    End Function

    ''' <summary>
    '''取得資料庫表格的 DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTableForOMOPreventationHealthCare() As DataTable
        Try
            Dim dt As DataTable = New DataTable("OMO_Preventation_Health_Care")
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Prevent_No")
            dt.Columns.Add("Care_Item_Code")
            dt.Columns.Add("Care_Order_Code")
            dt.Columns.Add("Care_Cardseq")
            dt.Columns.Add("Outpatient_Sn")
            dt.Columns.Add("Is_Positive")
            dt.Columns.Add("Is_Will")
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Remind_Date")
            dt.Columns.Add("Remind_User")
            dt.Columns.Add("Remind_Dept")
            dt.Columns.Add("Execute_Date")
            dt.Columns.Add("Outpatient_Sn_Exe")
            dt.Columns.Add("Execute_User")
            dt.Columns.Add("Execute_Dept")
            dt.Columns.Add("Execute_Date_External")
            dt.Columns.Add("Execute_External_Hospital")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Remind_Cnt")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Prevent_No")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCareItemCode(ByVal Care_Order_Code As String) As String
        Try
            If IsNumeric(Care_Order_Code) Then

                If CInt(Care_Order_Code) >= 11 AndAlso CInt(Care_Order_Code) <= 19 Then
                    Return "01"

                ElseIf CInt(Care_Order_Code) >= 21 AndAlso CInt(Care_Order_Code) <= 24 Then
                    Return "02"

                ElseIf CInt(Care_Order_Code) >= 31 AndAlso CInt(Care_Order_Code) <= 33 Then

                    Return "03"
                ElseIf CInt(Care_Order_Code) >= 41 AndAlso CInt(Care_Order_Code) <= 50 Then

                    Return "04"
                ElseIf Care_Order_Code = "85" Then

                    Return "07"

                ElseIf Care_Order_Code = "95" Then

                    Return "08"

                ElseIf CInt(Care_Order_Code) >= 25 AndAlso CInt(Care_Order_Code) <= 26 Then

                    Return "25"

                ElseIf CInt(Care_Order_Code) >= 27 AndAlso CInt(Care_Order_Code) <= 28 Then

                    Return "27"

                ElseIf Care_Order_Code = "81" Then

                    Return "81"

                ElseIf CInt(Care_Order_Code) >= 91 AndAlso CInt(Care_Order_Code) <= 93 Then

                    Return "91"

                Else

                    Return ""

                End If


            Else
                Return ""
            End If

        Catch ex As Exception
            Return ""
        End Try
    End Function


    Public Function queryOMOPreventationHealthCare(ByVal ChartNo As String, ByVal ServiceItemId As String, _
                                                     ByVal ExamItemId As String, ByVal ExamDate As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getOPDConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select * From OMO_Preventation_Health_Care " & _
                                  "Where Chart_No='" & ChartNo & "' And Care_Item_Code='" & ServiceItemId & "' And " & _
                                  "      Care_Order_Code='" & ExamItemId & "' And Effect_Date<='" & ExamDate & "' And " & _
                                  "      End_Date>='" & ExamDate & "' " 'And (Execute_Date is null Or Execute_Date='' )
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("OMO_Preventation_Health_Care")
                adapter.Fill(ds, "OMO_Preventation_Health_Care")
                adapter.FillSchema(ds, SchemaType.Mapped, "OMO_Preventation_Health_Care")
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "2011.01.24 PUB API Add By Alan"
    ''' <summary>
    ''' 程式說明：依OrderCode取得AddOrder
    ''' 開發人員：Alan
    ''' 開發日期：2011.01.24
    ''' 傳入參數：型態為DataSet，各欄位說明如下
    '''           來    源 - Source_Type
    '''           護囑序號 - Order_Plan_No
    '''           醫令代碼 - Order_Code
    '''           主身分代號 - Main_Identity_Id
    '''           開單日期 - Order_Date (yyyy/mm/dd)
    ''' </summary>
    Public Function getPUBAddOrderbyOrderCode(ByVal inOrderData As DataSet) As DataSet

        Dim result As New DataSet
        Dim getAddOrderDS As DataSet

        Try
            If inOrderData IsNot Nothing AndAlso inOrderData.Tables(0) IsNot Nothing AndAlso inOrderData.Tables(0).Rows.Count > 0 Then

                Dim pvtSourceType, OrderPlanNo, OrderCode, MainIdentityId, OrderDate As String

                For i = 0 To inOrderData.Tables(0).Rows.Count - 1
                    pvtSourceType = inOrderData.Tables(0).Rows(i).Item("Source_Type").ToString.Trim
                    OrderPlanNo = inOrderData.Tables(0).Rows(i).Item("Order_Plan_No").ToString.Trim
                    OrderCode = inOrderData.Tables(0).Rows(i).Item("Order_Code").ToString.Trim
                    MainIdentityId = inOrderData.Tables(0).Rows(i).Item("Main_Identity_Id").ToString.Trim
                    OrderDate = inOrderData.Tables(0).Rows(i).Item("Order_Date").ToString.Trim
                    If i = 0 Then
                        getAddOrderDS = getPUBAddOrderbyOrderCodeSQL(pvtSourceType, OrderPlanNo, OrderCode, MainIdentityId, OrderDate)
                        result = getAddOrderDS.Copy
                    Else
                        getAddOrderDS = getPUBAddOrderbyOrderCodeSQL(pvtSourceType, OrderPlanNo, OrderCode, MainIdentityId, OrderDate)

                        If getAddOrderDS IsNot Nothing AndAlso getAddOrderDS.Tables(0) IsNot Nothing AndAlso getAddOrderDS.Tables(0).Rows.Count > 0 Then
                            Dim pvtColCount As Integer
                            pvtColCount = getAddOrderDS.Tables(0).Columns.Count - 1

                            For j = 0 To getAddOrderDS.Tables(0).Rows.Count - 1

                                Dim pvtDataRow As DataRow
                                pvtDataRow = result.Tables(0).NewRow

                                For k = 0 To pvtColCount
                                    pvtDataRow.Item(k) = getAddOrderDS.Tables(0).Rows(j).Item(k)
                                Next

                                result.Tables(0).Rows.Add(pvtDataRow)
                            Next
                        End If

                    End If
                Next

            End If

            Return result

        Catch ex As Exception

            Return result
        End Try

    End Function

    Public Function getPUBAddOrderbyOrderCodeSQL(ByVal SourceType As String, ByVal OrderPlanNo As String, _
                                                 ByVal OrderCode As String, ByVal MainIdentityId As String, _
                                                 ByVal OrderDate As String) As DataSet
        Dim resultDS As New DataSet

        Try
            '開單日未傳入，用系統日
            If OrderDate = "" Then
                OrderDate = Now.ToString("yyyy/MM/dd")
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(getOPDConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtOrderPlanNo As String = String.Empty
            Dim pvtSqlStr As String = String.Empty

            If OrderPlanNo = "" Then
                pvtOrderPlanNo = "''"
            Else
                pvtOrderPlanNo = "'" & OrderPlanNo & "'"
            End If

            Select Case SourceType
                Case "OMO"
                    pvtSqlStr = "      B.Add_Order_Code =A.Opd_Add_Order_Code And B.Dc<>'Y' And "
                Case "EMO"
                    pvtSqlStr = "      B.Add_Order_Code =A.Emg_Add_Order_Code And B.Dc<>'Y' And "
                Case "IMO"
                    pvtSqlStr = "      B.Add_Order_Code =A.Ipd_Add_Order_Code And B.Dc<>'Y' And "
                Case "ENC"
                    pvtSqlStr = "      B.Add_Order_Code =A.Emg_Nursing_Add_Order_Code And B.Dc<>'Y' And "
                Case "CNC"
                    pvtSqlStr = "      B.Add_Order_Code =A.Ipd_Nursing_Add_Order_Code And B.Dc<>'Y' And "
            End Select

            command.CommandText = "Select " & pvtOrderPlanNo & " AS Order_Plan_No,C.*,D.*,E.Price As Own_Price,F.Price  As Nhi_Price " & _
                                  "From PUB_Order_Price A,PUB_Add_Order B,PUB_Add_Order_Detail C,PUB_Order D " & _
                                  "     Left Join PUB_Order_Price  E ON  " & _
                                  "               E.Order_Code = D.Order_Code And " & _
                                  "               E.Main_Identity_Id <>'2' And " & _
                                  "     '" & OrderDate & "'>= E.Effect_Date  And '" & OrderDate & "'<= E.End_Date And E.Dc <>'Y' " & _
                                  "     Left Join PUB_Order_Price F ON " & _
                                  "               F.Order_Code = D.Order_Code And " & _
                                  "               F.Main_Identity_Id ='2' And " & _
                                  "     '" & OrderDate & "'>= F.Effect_Date  And '" & OrderDate & "'<= F.End_Date And F.Dc <>'Y' " & _
                                  "Where A.Order_Code ='" & OrderCode & "' And A.Main_Identity_Id ='" & MainIdentityId & "' And " & _
                                  "      '" & OrderDate & "'>= A.Effect_Date  And '" & OrderDate & "'<= A.End_Date And A.Dc<>'Y' And " & _
                                  pvtSqlStr & _
                                  "      C.Add_Order_Code =B.Add_Order_Code And C.Dc<>'Y' And " & _
                                  "      D.Order_Code = C.Order_Code And " & _
                                  "      '" & OrderDate & "'>= D.Effect_Date  And '" & OrderDate & "'<= D.End_Date And D.Dc<>'Y' "
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                resultDS = New DataSet("PUB_Add_Order_Detail")
                adapter.Fill(resultDS, "PUB_Add_Order_Detail")
            End Using

        Catch ex As Exception

        End Try

        Return resultDS

    End Function

    ''' <summary>
    ''' 程式說明：依OrderCode+OutpatientSn取得AddOrder(For急診)
    ''' 開發人員：Alan
    ''' 開發日期：2011.06.22
    ''' 傳入參數：型態為DataSet，各欄位說明如下
    '''           來    源 - Source_Type
    '''           護囑序號 - Order_Plan_No
    '''           醫令代碼 - Order_Code
    '''           主身分代號 - Main_Identity_Id
    '''           開單日期 - Order_Date (yyyy/mm/dd)
    '''           門急住號 - Outpatient_Sn  
    ''' </summary>
    Public Function getPUBAddOrderbyOutpatientSn(ByVal inOrderData As DataSet) As DataSet

        Dim result As New DataSet
        Dim getAddOrderDS As DataSet

        Try
            If inOrderData IsNot Nothing AndAlso inOrderData.Tables(0) IsNot Nothing AndAlso inOrderData.Tables(0).Rows.Count > 0 Then

                Dim pvtSourceType, OrderPlanNo, OrderCode, MainIdentityId, OrderDate, OutpatientSn, ReceiveNo As String

                For i = 0 To inOrderData.Tables(0).Rows.Count - 1
                    pvtSourceType = inOrderData.Tables(0).Rows(i).Item("Source_Type").ToString.Trim
                    OrderPlanNo = inOrderData.Tables(0).Rows(i).Item("Order_Plan_No").ToString.Trim
                    OrderCode = inOrderData.Tables(0).Rows(i).Item("Order_Code").ToString.Trim
                    MainIdentityId = inOrderData.Tables(0).Rows(i).Item("Main_Identity_Id").ToString.Trim
                    OrderDate = inOrderData.Tables(0).Rows(i).Item("Order_Date").ToString.Trim

                    '2011-06-22 Add By Alan
                    '若傳入的參數含有門急住號，回傳時需一併傳出
                    OutpatientSn = inOrderData.Tables(0).Rows(i).Item("Outpatient_Sn").ToString.Trim
                    ReceiveNo = inOrderData.Tables(0).Rows(i).Item("Receive_No").ToString.Trim
                    If i = 0 Then
                        getAddOrderDS = getPUBAddOrderbyOutpatientSnSQL(pvtSourceType, OrderPlanNo, OrderCode, MainIdentityId, OrderDate, OutpatientSn, ReceiveNo)
                        result = getAddOrderDS.Copy
                    Else
                        getAddOrderDS = getPUBAddOrderbyOutpatientSnSQL(pvtSourceType, OrderPlanNo, OrderCode, MainIdentityId, OrderDate, OutpatientSn, ReceiveNo)

                        If getAddOrderDS IsNot Nothing AndAlso getAddOrderDS.Tables(0) IsNot Nothing AndAlso getAddOrderDS.Tables(0).Rows.Count > 0 Then
                            Dim pvtColCount As Integer
                            pvtColCount = getAddOrderDS.Tables(0).Columns.Count - 1

                            For j = 0 To getAddOrderDS.Tables(0).Rows.Count - 1

                                Dim pvtDataRow As DataRow
                                pvtDataRow = result.Tables(0).NewRow

                                For k = 0 To pvtColCount
                                    pvtDataRow.Item(k) = getAddOrderDS.Tables(0).Rows(j).Item(k)
                                Next

                                result.Tables(0).Rows.Add(pvtDataRow)
                            Next
                        End If

                    End If
                Next

            End If

            Return result

        Catch ex As Exception

            Return result
        End Try

    End Function

    Public Function getPUBAddOrderbyOutpatientSnSQL(ByVal SourceType As String, ByVal OrderPlanNo As String, _
                                                    ByVal OrderCode As String, ByVal MainIdentityId As String, _
                                                    ByVal OrderDate As String, ByVal OutpatientSn As String, ByVal ReceiveNo As String) As DataSet
        Dim resultDS As New DataSet

        Try
            '開單日未傳入，用系統日
            If OrderDate = "" Then
                OrderDate = Now.ToString("yyyy/MM/dd")
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(getOPDConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtOrderPlanNo As String = String.Empty
            Dim pvtSqlStr As String = String.Empty

            If OrderPlanNo = "" Then
                pvtOrderPlanNo = "''"
            Else
                pvtOrderPlanNo = "'" & OrderPlanNo & "'"
            End If

            Select Case SourceType
                Case "OMO"
                    pvtSqlStr = "      B.Add_Order_Code =A.Opd_Add_Order_Code And B.Dc<>'Y' And "
                Case "EMO"
                    pvtSqlStr = "      B.Add_Order_Code =A.Emg_Add_Order_Code And B.Dc<>'Y' And "
                Case "IMO"
                    pvtSqlStr = "      B.Add_Order_Code =A.Ipd_Add_Order_Code And B.Dc<>'Y' And "
                Case "ENC"
                    pvtSqlStr = "      B.Add_Order_Code =A.Emg_Nursing_Add_Order_Code And B.Dc<>'Y' And "
                Case "CNC"
                    pvtSqlStr = "      B.Add_Order_Code =A.Ipd_Nursing_Add_Order_Code And B.Dc<>'Y' And "
            End Select

            command.CommandText = "Select " & pvtOrderPlanNo & " AS Order_Plan_No,C.*,D.*,E.Price As Own_Price,F.Price  As Nhi_Price,'" & OutpatientSn & "' as Outpatient_Sn,'" & ReceiveNo & "' as Receive_No " & _
                                  "From PUB_Order_Price A,PUB_Add_Order B,PUB_Add_Order_Detail C,PUB_Order D " & _
                                  "     Left Join PUB_Order_Price  E ON  " & _
                                  "               E.Order_Code = D.Order_Code And " & _
                                  "               E.Main_Identity_Id <>'2' And " & _
                                  "     '" & OrderDate & "'>= E.Effect_Date  And '" & OrderDate & "'<= E.End_Date And E.Dc <>'Y' " & _
                                  "     Left Join PUB_Order_Price F ON " & _
                                  "               F.Order_Code = D.Order_Code And " & _
                                  "               F.Main_Identity_Id ='2' And " & _
                                  "     '" & OrderDate & "'>= F.Effect_Date  And '" & OrderDate & "'<= F.End_Date And F.Dc <>'Y' " & _
                                  "Where A.Order_Code ='" & OrderCode & "' And A.Main_Identity_Id ='" & MainIdentityId & "' And " & _
                                  "      '" & OrderDate & "'>= A.Effect_Date  And '" & OrderDate & "'<= A.End_Date And A.Dc<>'Y' And " & _
                                  pvtSqlStr & _
                                  "      C.Add_Order_Code =B.Add_Order_Code And C.Dc<>'Y' And " & _
                                  "      D.Order_Code = C.Order_Code And " & _
                                  "      '" & OrderDate & "'>= D.Effect_Date  And '" & OrderDate & "'<= D.End_Date And D.Dc<>'Y' "
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                resultDS = New DataSet("PUB_Add_Order_Detail")
                adapter.Fill(resultDS, "PUB_Add_Order_Detail")
            End Using

        Catch ex As Exception

        End Try

        Return resultDS

    End Function

    ''' <summary>
    ''' 程式說明：依AddOrderCode取得AddOrder
    ''' 開發人員：Alan
    ''' 開發日期：2011.01.25
    ''' 傳入參數：AddOrderCode    
    ''' </summary>
    Public Function getPUBAddOrderByAddOrderCode(ByVal inAddOrderCode As String) As DataSet
        Dim result As New DataSet

        Try
            result = getPUBAddOrderByAddOrderCodeSQL(inAddOrderCode)

            Return result

        Catch ex As Exception

            Return result
        End Try

    End Function

    Public Function getPUBAddOrderByAddOrderCodeSQL(ByVal inAddOrderCode As String) As DataSet
        Dim resultDS As New DataSet

        Try
            Dim sqlConn As SqlClient.SqlConnection = CType(getOPDConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select B.*,C.* " & _
                                  "From PUB_Add_Order A,PUB_Add_Order_Detail B,PUB_Order C " & _
                                  "Where A.Add_Order_Code ='" & inAddOrderCode & "' And A.Dc<>'Y' And " & _
                                  "      B.Add_Order_Code =A.Add_Order_Code And B.Dc <>'Y' And " & _
                                  "      C.Effect_Date <= '" & Now.ToString("yyyy/MM/dd") & "' And C.End_Date >='" & Now.ToString("yyyy/MM/dd") & "' And " & _
                                  "      C.Order_Code =B.Order_Code And C.Dc<>'Y' "
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                resultDS = New DataSet("PUB_Add_Order_Detail")
                adapter.Fill(resultDS, "PUB_Add_Order_Detail")
            End Using

        Catch ex As Exception

        End Try

        Return resultDS

    End Function

    ''' <summary>
    ''' 程式說明：依AddOrderCode取得可替代Order
    ''' 開發人員：Alan
    ''' 開發日期：2011.01.25
    ''' 傳入參數：AddOrderCode   
    '''           AddOrderDetailNo 
    ''' </summary>
    Public Function getPUBAddOrderOptionByAddOrderCode(ByVal inAddOrderCode As String, ByVal inAddOrderDetailNo As String) As DataSet
        Dim result As New DataSet

        Try
            result = getPUBAddOrderOptionByAddOrderCodeSQL(inAddOrderCode, inAddOrderDetailNo)

            Return result

        Catch ex As Exception

            Return result
        End Try

    End Function

    Public Function getPUBAddOrderOptionByAddOrderCodeSQL(ByVal inAddOrderCode As String, ByVal inAddOrderDetailNo As String) As DataSet
        Dim resultDS As New DataSet

        Try
            Dim sqlConn As SqlClient.SqlConnection = CType(getOPDConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtSqlStr As String = ""

            If inAddOrderDetailNo <> "" Then
                pvtSqlStr = "And A.Add_Order_Detail_No ='" & inAddOrderDetailNo & "' "
            End If

            command.CommandText = "Select A.* " & _
                                  "From PUB_Add_Option_Order A " & _
                                  "Where A.Add_Order_Code ='" & inAddOrderCode & "' " & pvtSqlStr & _
                                  "      And A.Dc<>'Y' "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                resultDS = New DataSet("PUB_Add_Option_Order")
                adapter.Fill(resultDS, "PUB_Add_Option_Order")
            End Using

        Catch ex As Exception

        End Try

        Return resultDS

    End Function

    Public Function getPUBAddOrderOptionByAddOrderCodeForEIS(ByVal inAddOrderCode As String, ByVal inAddOrderDetailNo As String) As DataSet
        Dim resultDS As New DataSet

        Try
            Dim sqlConn As SqlClient.SqlConnection = CType(getOPDConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtSqlStr As String = ""

            If inAddOrderDetailNo <> "" Then
                pvtSqlStr = "And A.Add_Order_Detail_No ='" & inAddOrderDetailNo & "' "
            End If

            command.CommandText = "Select A.*,B.*,'0' As Own_Price,'0' As Nhi_Price  " & _
                                  "From PUB_Add_Option_Order A,PUB_Order B " & _
                                  "Where A.Add_Order_Code ='" & inAddOrderCode & "' " & pvtSqlStr & _
                                  "      And A.Dc<>'Y' And " & _
                                  "      B.Effect_Date<='" & Now.ToString("yyyy/MM/dd") & "' And " & _
                                  "      B.Order_Code=A.Option_Order_Code And " & _
                                  "      B.End_Date>='" & Now.ToString("yyyy/MM/dd") & "' "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                resultDS = New DataSet("PUB_Add_Option_Order")
                adapter.Fill(resultDS, "PUB_Add_Option_Order")
            End Using

            '讀取可替代藥的自費與健保價
            If resultDS IsNot Nothing AndAlso resultDS.Tables IsNot Nothing AndAlso resultDS.Tables(0).Rows.Count > 0 Then

                For i = 0 To resultDS.Tables(0).Rows.Count - 1
                    Dim pvtPriceDS As New DataSet
                    command.CommandText = "Select *  " & _
                                          "From PUB_Order_Price " & _
                                          "Where Effect_Date<='" & Now.ToString("yyyy/MM/dd") & "' And " & _
                                          "      Order_Code='" & resultDS.Tables(0).Rows(i).Item("Option_Order_Code").ToString.Trim & "' And " & _
                                          "      End_Date>='" & Now.ToString("yyyy/MM/dd") & "' "

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        pvtPriceDS = New DataSet("PUB_Order_Price")
                        adapter.Fill(pvtPriceDS, "PUB_Order_Price")
                    End Using

                    If pvtPriceDS IsNot Nothing AndAlso pvtPriceDS.Tables IsNot Nothing AndAlso pvtPriceDS.Tables(0).Rows.Count > 0 Then
                        For j = 0 To pvtPriceDS.Tables(0).Rows.Count - 1

                            If pvtPriceDS.Tables(0).Rows(j).Item("Main_Identity_Id").ToString.Trim = "1" Then
                                resultDS.Tables(0).Rows(i).Item("Own_Price") = pvtPriceDS.Tables(0).Rows(j).Item("Price").ToString.Trim
                            ElseIf pvtPriceDS.Tables(0).Rows(j).Item("Main_Identity_Id").ToString.Trim = "2" Then
                                resultDS.Tables(0).Rows(i).Item("Nhi_Price") = pvtPriceDS.Tables(0).Rows(j).Item("Price").ToString.Trim
                            End If

                        Next
                    End If

                Next

            End If

        Catch ex As Exception

        End Try

        Return resultDS

    End Function

    Public Function getOPDConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function

#End Region

    Public Function CheckIsFirstMust(ByVal Case_No As String, Optional ByVal Conn As IDbConnection = Nothing) As Boolean
        Dim connFlag As Boolean = Conn Is Nothing
        Dim openFlag As Boolean = False
        Try
            If connFlag Then
                Conn = getOPDConnection()
            End If
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
                openFlag = True
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(Conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "SELECT COUNT(*) FROM OMO_Nutritional_MUST WHERE Outpatient_Sn = @Case_No"
            command.Parameters.Add(New SqlParameter("@Case_No", SqlDbType.NChar, 15))
            command.Parameters("@Case_No").Value = Case_No
            Dim cnt As Integer = Convert.ToInt32(command.ExecuteScalar())
            If openFlag Then
                Conn.Close()
            End If
            If cnt = 0 Then
                Return True
            Else
                Return False
            End If
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                Conn.Close()
                Conn.Dispose()
            End If
        End Try
    End Function


    ''' <summary>
    ''' Get Pub SQL Connection.
    ''' </summary>
    ''' <returns>sql connection.</returns>
    ''' <remarks></remarks>
    Private Function getPubConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

    ''' <summary>
    ''' Get Pcs SQL Connection.
    ''' </summary>
    ''' <returns>sql connection.</returns>
    ''' <remarks></remarks>
    Private Function getPcsConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPcsDBSqlConn
    End Function

    ''' <summary>
    '''INP_Patient_Flag 新增
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function InpPatientFlagInsert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into INP_Patient_Flag (" & _
            " Case_No , Flag_Id , Chart_No , Create_User , Create_Time " & _
             "  ) " & _
             " values( @Case_No , @Flag_Id , @Chart_No , @Create_User , @Create_Time " & _
             "              )"
            If connFlag Then
                conn = getPcsConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Case_No", row.Item("Case_No"))
                    command.Parameters.AddWithValue("@Flag_Id", row.Item("Flag_Id"))
                    command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime)
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''INP_Patient_Flag 更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function InpPatientFlagUpdate(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update INP_Patient_Flag set " & _
            " Chart_No=@Chart_No " & _
            " where  Case_No=@Case_No and Flag_Id=@Flag_Id            "
            If connFlag Then
                conn = getPcsConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Case_No", row.Item("Case_No"))
                    command.Parameters.AddWithValue("@Flag_Id", row.Item("Flag_Id"))
                    command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''INP_Patient_Flag 以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function InpPatientFlagDelete(ByRef pk_Case_No As System.String, ByRef pk_Flag_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from INP_Patient_Flag where " & _
            " Case_No=@Case_No and Flag_Id=@Flag_Id "
            If connFlag Then
                conn = getPcsConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Case_No", pk_Case_No)
                command.Parameters.AddWithValue("@Flag_Id", pk_Flag_Id)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function



#Region "2013.03.27 OMOComputeBP Add By Rich"

    ''' <summary>
    ''' 計算身體質量指數
    ''' </summary>
    ''' <param name="Height">身高</param>
    ''' <param name="BW">體重</param>
    ''' <returns>BMI</returns>
    ''' <author>Ken</author>
    ''' <remarks></remarks>
    Public Function OMOBMI(ByVal Height As Decimal, ByVal BW As Decimal, Optional ByVal Age As Integer = 19, Optional ByVal Sex_Id As String = "1") As Decimal
        Try
            '20130424 add by Rich, 營養部於 20130418 提出修改的規則
            If Age > 18 Then
                '成人
                Return (BW * 10000) / (Height * Height)
            Else
                '小兒
                Dim value As Decimal = 0.0
                Select Case Age
                    Case 1
                        If Sex_Id = "1" Then
                            value = 0.128
                        Else
                            value = 0.127
                        End If
                    Case 2
                        If Sex_Id = "1" Then
                            value = 0.148
                        Else
                            value = 0.141
                        End If
                    Case 3
                        If Sex_Id = "1" Then
                            value = 0.156
                        Else
                            value = 0.157
                        End If
                    Case 4
                        If Sex_Id = "1" Then
                            value = 0.168
                        Else
                            value = 0.163
                        End If
                    Case 5
                        If Sex_Id = "1" Then
                            value = 0.177
                        Else
                            value = 0.174
                        End If
                    Case 6
                        If Sex_Id = "1" Then
                            value = 0.191
                        Else
                            value = 0.186
                        End If
                    Case 7
                        If Sex_Id = "1" Then
                            value = 0.205
                        Else
                            value = 0.198
                        End If
                    Case 8
                        If Sex_Id = "1" Then
                            value = 0.219
                        Else
                            value = 0.213
                        End If
                    Case 9
                        If Sex_Id = "1" Then
                            value = 0.241
                        Else
                            value = 0.227
                        End If
                    Case 10
                        If Sex_Id = "1" Then
                            value = 0.254
                        Else
                            value = 0.245
                        End If
                    Case 11
                        If Sex_Id = "1" Then
                            value = 0.278
                        Else
                            value = 0.367
                        End If
                    Case 12
                        If Sex_Id = "1" Then
                            value = 0.293
                        Else
                            value = 0.391
                        End If
                    Case 13
                        If Sex_Id = "1" Then
                            value = 0.316
                        Else
                            value = 0.31
                        End If
                    Case 14
                        If Sex_Id = "1" Then
                            value = 0.335
                        Else
                            value = 0.318
                        End If
                    Case 15
                        If Sex_Id = "1" Then
                            value = 0.351
                        Else
                            value = 0.329
                        End If
                    Case 16
                        If Sex_Id = "1" Then
                            value = 0.365
                        Else
                            value = 0.327
                        End If
                    Case 17
                        If Sex_Id = "1" Then
                            value = 0.368
                        Else
                            value = 0.327
                        End If
                    Case 18
                        If Sex_Id = "1" Then
                            value = 0.374
                        Else
                            value = 0.331
                        End If
                    Case Else
                        If Sex_Id = "1" Then
                            value = 0.128
                        Else
                            value = 0.127
                        End If
                End Select
                Return (BW / Height / value)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' BMI分數
    ''' </summary>
    ''' <param name="BMI">BMI</param>
    ''' <returns>BMI Score</returns>
    ''' <author>Ken</author>
    ''' <date>2009-10-14</date>
    ''' <remarks></remarks>
    Public Function OMOBMIScore(ByVal BMI As Decimal, Optional ByVal Age As Integer = 19) As Integer
        Try
            If Age > 18 Then
                If BMI >= 20 Then
                    Return 0
                ElseIf BMI < 18.5 Then
                    Return 2
                Else
                    Return 1
                End If
            Else
                If BMI < 0.8 Then
                    Return 2
                ElseIf BMI >= 0.8 AndAlso BMI <= 0.89 Then
                    Return 1
                ElseIf BMI >= 0.9 AndAlso BMI <= 1.09 Then
                    Return 0
                ElseIf BMI >= 1.1 AndAlso BMI <= 1.19 Then
                    Return 0
                ElseIf BMI >= 1.2 Then
                    Return 0
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    ''' <summary>
    ''' BW_Chagne
    ''' </summary>
    ''' <param name="BW">體重</param>
    ''' <param name="RegularWeight">經常體重</param>
    ''' <returns>BW Loss (百分比)</returns>
    ''' <remarks></remarks>
    Public Function OMOBWLoss(ByVal BW As Decimal, ByVal RegularWeight As Decimal) As Decimal
        Try
            Return ((BW - RegularWeight) / RegularWeight) * 100
        Catch ex As DivideByZeroException
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 計算 BW_Change 分數
    ''' </summary>
    ''' <param name="BW_Loss">BW_Loss</param>
    ''' <returns>BW_Loss Score</returns>
    ''' <author>Ken</author>
    ''' <date>2009-10-14</date>
    ''' <remarks></remarks>
    Public Function OMOBWLossScore(ByVal BW_Loss As Decimal) As Integer
        Try
            If BW_Loss > 0 Then
                Return 0
            ElseIf BW_Loss <= 0 AndAlso BW_Loss > -5 Then
                Return 0
            ElseIf BW_Loss <= -5 AndAlso BW_Loss > -10 Then
                Return 1
            ElseIf BW_Loss <= -10 Then
                Return 2
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' NPO分數
    ''' </summary>
    ''' <param name="NPO">NPO</param>
    ''' <returns>NPO Score</returns>
    ''' <remarks></remarks>
    Public Function OMONPOScore(ByVal NPO As Decimal) As Integer
        Try
            Return IIf(NPO > 5, 2, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 預設為本次住院的MUST最後一筆資料中的經常體重。若沒有則以六個月內的最重體重為經常體重
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <returns>查詢結果</returns>
    ''' <remarks></remarks>
    Public Function OMONutritionalMustGetRegularWeight(ByVal ChartNo As String, ByVal Query_Date As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getOPDConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT Isnull((SELECT TOP 1 Regular_Weight " & vbCrLf)
            sqlString.Append("               FROM   OMO_Nutritional_MUST " & vbCrLf)
            sqlString.Append("               WHERE  Chart_No = @Chart_No " & vbCrLf)
            sqlString.Append("               ORDER  BY Must_Date DESC), (SELECT Isnull(Max(Weight), 0) AS Regular_Weight " & vbCrLf)
            sqlString.Append("                                           FROM   PUB_Patient_BodyRecord " & vbCrLf)
            sqlString.Append("                                           WHERE  Chart_No = @Chart_No " & vbCrLf)
            sqlString.Append("                                                  AND CONVERT(VARCHAR(10), Measure_Time, 120) BETWEEN CONVERT(VARCHAR(10), Dateadd(mm, -6, @Query_Date), 120) AND CONVERT(VARCHAR(10), @Query_Date, 120))) AS Regular_Weight ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Chart_No", ChartNo)
            command.Parameters.AddWithValue("@Query_Date", CDate(Query_Date))
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("OMO_Nutritional_MUST")
                adapter.Fill(ds, "OMO_Nutritional_MUST")
            End Using

            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

#Region "20150928  PUB_Medical_Type_Id 取得COMBOBOX的看診目的 add by Will"
    Public Function getPUBMedicalTypeId() As DataSet
        Dim resultDS As New DataSet

        Try
            Dim sqlConn As SqlClient.SqlConnection = CType(getOPDConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "select Medical_Type_Id," & _
                                  "	   Medical_Type_Name" & _
                                  "  from PUB_Medical_Type " & _
                                  " where dc='N'"
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                resultDS = New DataSet("PUB_Medical_Type_Id")
                adapter.Fill(resultDS, "PUB_Medical_Type_Id")
            End Using

        Catch ex As Exception

        End Try

        Return resultDS

    End Function
#End Region

#Region "20160720  取得ChargeFlag add by James "

    Public Shared PubOrderExamNocheckinDeptDS As DataSet


    ' 身份	計價別	計價說明	科室執行註記	醫囑開立/補批價	可異動	科室執行	費用結算
    '健保   	S	    需科室執行	Y	            預帶S	    S,O,X	S->N	       暫不計價
    '           S	    需科室執行	N	            預帶N    	N,O,X	　       	計價
    '           N   	健保可修改	　           	預帶N   	N,O,X	      　	健保
    '           X	    不計價	　                 	預帶X	　	　          	不計價不申報
    ' 自費    	Y	    自費可修改	           　	預帶Y   	Y,O,X	      　	自費
    '           O	    自費不可修改	　      	預帶O   	O,X	　	            自費
    '      	    X	    不計價	　              	預帶X	　	　              	不計價

    ''' <summary>
    ''' 取得ChargeFlag
    ''' </summary>
    ''' <param name="Source_Id">O,E,I</param>
    ''' <param name="Main_Identity_Id">主身份</param>
    ''' <param name="Dept_Code">科別</param>
    ''' <param name="Section_id">診別</param>
    ''' <param name="dt">資料</param>
    ''' <remarks>取得ChargeFlag</remarks>
    Public Shared Function getChargeFlag(ByVal Source_Id As String, ByVal Main_Identity_Id As String, ByVal Dept_Code As String, ByVal Section_id As String, ByVal dt As DataTable) As DataSet
        Try
            Dim IsNeedUclQuery As Boolean = False
            If PubOrderExamNocheckinDeptDS Is Nothing Then
                PubOrderExamNocheckinDeptDS = DynamicSQL(True, "Select Order_Code , Kind_Id , Dept_Code ,Section_Id  From PUB_Order_Exam_Nocheckin_Dept")
            End If

            '==========================================================
            If Not dt.Columns.Contains("Self_Charge_Flag") Then
                dt.Columns.Add("Self_Charge_Flag")
            End If

            If Not dt.Columns.Contains("Nhi_Charge_Flag") Then
                dt.Columns.Add("Nhi_Charge_Flag")
            End If

            If Not dt.Columns.Contains("Is_No_Check_In") Then
                dt.Columns.Add("Is_No_Check_In")
            End If

            If Not dt.Columns.Contains("Include_Order_Mark") Then
                dt.Columns.Add("Include_Order_Mark")
            End If

            If Not dt.Columns.Contains("Is_Cure") Then
                dt.Columns.Add("Is_Cure")
            End If

            For i As Integer = 0 To dt.Rows.Count - 1

                If dt.Rows(i).Item("Self_Charge_Flag").ToString.Trim = "" OrElse dt.Rows(i).Item("Nhi_Charge_Flag").ToString.Trim = "" Then
                    IsNeedUclQuery = True
                Else
                    Exit For
                End If

                Dim DataDS As New DataSet
                DataDS.Tables.Add()

                DataDS.Tables(0).Columns.Add("Code")
                DataDS.Tables(0).Columns.Add("Name")
                DataDS.Tables(0).Columns.Add("Is_OPD")
                DataDS.Tables(0).Columns.Add("Is_IPD")
                DataDS.Tables(0).Columns.Add("Is_EPD")
                DataDS.Tables(0).Columns.Add("IsEqualMatch")
                DataDS.Tables(0).Columns.Add("OrderTypeId")
                DataDS.Tables(0).Columns.Add("Is_ShowPrice")
                DataDS.Tables(0).Rows.Add()


                DataDS.Tables(0).Rows(0).Item("Code") = dt.Rows(i).Item("Order_Code").ToString.Trim
                DataDS.Tables(0).Rows(0).Item("IsEqualMatch") = "Y"

                Dim OrderDS = queryChargeFlagData(DataDS)

                If OrderDS IsNot Nothing AndAlso OrderDS.Tables(0).Rows.Count > 0 Then
                    dt.Rows(i).Item("Self_Charge_Flag") = OrderDS.Tables(0).Rows(0).Item("Self_Charge_Flag").ToString.Trim
                    dt.Rows(i).Item("Nhi_Charge_Flag") = OrderDS.Tables(0).Rows(0).Item("Nhi_Charge_Flag").ToString.Trim
                    dt.Rows(i).Item("Is_No_Check_In") = OrderDS.Tables(0).Rows(0).Item("Is_No_Check_In").ToString.Trim
                    dt.Rows(i).Item("Include_Order_Mark") = OrderDS.Tables(0).Rows(0).Item("Include_Order_Mark").ToString.Trim
                    dt.Rows(i).Item("Is_Cure") = OrderDS.Tables(0).Rows(0).Item("Is_Cure").ToString.Trim
                End If

            Next

            '==========================================================

            Dim RetrunDS As New DataSet
            RetrunDS.Tables.Add(dt.Copy)

            If Main_Identity_Id = "1" Then
                For Each row As DataRow In RetrunDS.Tables(0).Rows

                    If row.Item("Self_Charge_Flag").ToString.Trim = "O" Then
                        row.Item("Charge_Flag") = "O"

                    ElseIf row.Item("Self_Charge_Flag").ToString.Trim = "Y" Then
                        row.Item("Charge_Flag") = "Y"

                    ElseIf row.Item("Self_Charge_Flag").ToString.Trim = "X" Then
                        row.Item("Charge_Flag") = "X"

                    End If

                Next
            Else

                For Each row As DataRow In RetrunDS.Tables(0).Rows

                    If row.Item("Include_Order_Mark").ToString.Trim = "A" Then
                        row.Item("Charge_Flag") = "X"

                    Else

                        'A.	計價別欄位預設帶入PUB_Order_Price.Charge_Flag
                        'B.	但PUB_Order_Price.Charge_Flag = 'N'時, 
                        'B1.當PUB_Order_Examine.Is_No_Check_In = 'N' 時, 計價別欄位改為'S'; 
                        'B2.PUB_Order_Examine.Is_No_Check_In = 'Y' 時, 且開單科診存在[科室不需報到設定檔](PUB_Order_Exam_Nocheckin_Dept)時, 計價別欄位改為'N'; 
                        'B3. PUB_Order_Examine.Is_No_Check_In = 'Y' 時, 且開單科診不存在[科室不需報到設定檔](PUB_Order_Exam_Nocheckin_Dept)時, 計價別欄位改為'S'

                        If row.Item("Nhi_Charge_Flag").ToString.Trim <> "" Then
                            row.Item("Charge_Flag") = row.Item("Nhi_Charge_Flag").ToString.Trim
                        Else
                            row.Item("Charge_Flag") = row.Item("Self_Charge_Flag").ToString.Trim
                        End If


                        If Source_Id = "O" Then

                            '門診
                            If row.Item("Nhi_Charge_Flag").ToString.Trim = "N" Then


                                If row.Item("Is_Cure").ToString.Trim = "Y" Then
                                    '療程項目
                                    row.Item("Charge_Flag") = "S"

                                Else

                                    If row.Item("Is_No_Check_In").ToString.Trim = "N" Then '科室需報到
                                        row.Item("Charge_Flag") = "S"

                                    ElseIf row.Item("Is_No_Check_In").ToString.Trim = "Y" Then
                                        '先用Order_Code找PubOrderExamNocheckinDept , 如果找不到 ,就代表科室不需執行 , Charge_Flag =N
                                        If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & row.Item("Order_Code").ToString.Trim & "'").Count = 0 Then
                                            '沒找不到
                                            row.Item("Charge_Flag") = "N"
                                        Else
                                            '有找到 ,再依據門急住科診 找,如果找到 , 代表科室不需執行 , Charge_Flag =N
                                            If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & row.Item("Order_Code").ToString.Trim & "' And Kind_Id='" & Source_Id & "' And Dept_Code='" & Dept_Code & "' And Section_Id='" & Section_id & "'").Count > 0 Then
                                                row.Item("Charge_Flag") = "N"
                                            Else
                                                '沒找到,需要報到(執行)
                                                row.Item("Charge_Flag") = "S"
                                            End If
                                        End If

                                    End If

                                End If

                            End If

                        Else

                            '急,住
                            If row.Item("Nhi_Charge_Flag").ToString.Trim = "N" Then
                                If row.Item("Is_No_Check_In").ToString.Trim = "N" Then '科室需報到
                                    row.Item("Charge_Flag") = "S"

                                ElseIf row.Item("Is_No_Check_In").ToString.Trim = "Y" Then
                                    '先用Order_Code找PubOrderExamNocheckinDept , 如果找不到 ,就代表科室不需執行 , Charge_Flag =N
                                    If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & row.Item("Order_Code").ToString.Trim & "'").Count = 0 Then
                                        '沒找不到
                                        row.Item("Charge_Flag") = "N"
                                    Else
                                        '有找到 ,再依據門急住科診 找,如果找到 , 代表科室不需執行 , Charge_Flag =N
                                        If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & row.Item("Order_Code").ToString.Trim & "' And Kind_Id='" & Source_Id & "' And Dept_Code='" & Dept_Code & "'").Count > 0 Then
                                            row.Item("Charge_Flag") = "N"
                                        Else
                                            '沒找到,需要報到(執行)
                                            row.Item("Charge_Flag") = "S"
                                        End If
                                    End If

                                End If
                            End If
                        End If

                    End If

                Next

            End If

            Return RetrunDS
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    ''' <summary>
    ''' 取得ChargeFlag
    ''' </summary>
    ''' <param name="Source_Id">O,E,I</param>
    ''' <param name="Main_Identity_Id">主身份</param>
    ''' <param name="Dept_Code">科別</param>
    ''' <param name="Section_id">診別</param>
    ''' <param name="Order_Code">Order_Code</param>
    ''' <param name="Self_Charge_Flag">PUB_Order_Price.Charge_Flag(Main_Identity_Id = '1')</param>
    ''' <param name="Nhi_Charge_Flag">PUB_Order_Price.Charge_Flag(Main_Identity_Id = '2')</param>
    ''' <param name="Is_No_Check_In">PUB_Order_Examination.Is_No_Check_In</param>
    ''' <param name="Include_Order_Mark">PUB_Order.Include_Order_Mark</param>
    ''' <param name="Is_Cure">PUB_Order.Is_Cure</param>
    ''' <remarks>取得ChargeFlag</remarks>
    Public Shared Function getChargeFlag(ByVal Source_Id As String, ByVal Main_Identity_Id As String, ByVal Dept_Code As String, ByVal Section_id As String, ByVal Order_Code As String, Optional ByVal Self_Charge_Flag As String = "", Optional ByVal Nhi_Charge_Flag As String = "", Optional ByVal Is_No_Check_In As String = "", Optional ByVal Include_Order_Mark As String = "", Optional ByVal Is_Cure As String = "", Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Dim connFlag As Boolean = conn Is Nothing

        Try
            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If
            If PubOrderExamNocheckinDeptDS Is Nothing Then
                PubOrderExamNocheckinDeptDS = DynamicSQL(True, "Select Order_Code , Kind_Id , Dept_Code ,Section_Id  From PUB_Order_Exam_Nocheckin_Dept", conn)
            End If

            '==========================================================

            Dim DataDS As New DataSet
            DataDS.Tables.Add()

            DataDS.Tables(0).Columns.Add("Code")
            DataDS.Tables(0).Columns.Add("Name")
            DataDS.Tables(0).Columns.Add("Is_OPD")
            DataDS.Tables(0).Columns.Add("Is_IPD")
            DataDS.Tables(0).Columns.Add("Is_EPD")
            DataDS.Tables(0).Columns.Add("IsEqualMatch")
            DataDS.Tables(0).Columns.Add("OrderTypeId")
            DataDS.Tables(0).Columns.Add("Is_ShowPrice")
            DataDS.Tables(0).Rows.Add()

            DataDS.Tables(0).Rows(0).Item("Code") = Order_Code.Trim
            DataDS.Tables(0).Rows(0).Item("IsEqualMatch") = "Y"

            Dim OrderDS = queryChargeFlagData(DataDS, conn)

            If OrderDS IsNot Nothing AndAlso OrderDS.Tables(0).Rows.Count > 0 Then
                Self_Charge_Flag = OrderDS.Tables(0).Rows(0).Item("Self_Charge_Flag").ToString.Trim
                Nhi_Charge_Flag = OrderDS.Tables(0).Rows(0).Item("Nhi_Charge_Flag").ToString.Trim
                Is_No_Check_In = OrderDS.Tables(0).Rows(0).Item("Is_No_Check_In").ToString.Trim
                Include_Order_Mark = OrderDS.Tables(0).Rows(0).Item("Include_Order_Mark").ToString.Trim
                Is_Cure = OrderDS.Tables(0).Rows(0).Item("Is_Cure").ToString.Trim
            End If

            '==========================================================

            Dim RetrunDS As New DataSet
            RetrunDS.Tables.Add("Charge_Flag_Value")

            RetrunDS.Tables("Charge_Flag_Value").Columns.Add("Charge_Flag")

            RetrunDS.Tables("Charge_Flag_Value").Rows.Add()

            If Main_Identity_Id = "1" Then

                If Self_Charge_Flag.Trim = "O" Then
                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "O"

                ElseIf Self_Charge_Flag.Trim = "Y" Then
                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "Y"

                ElseIf Self_Charge_Flag.Trim = "X" Then
                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "X"

                End If

            Else

                If Include_Order_Mark = "A" Then
                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "X"
                Else

                    If Nhi_Charge_Flag <> "" Then
                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = Nhi_Charge_Flag
                    Else
                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = Self_Charge_Flag
                    End If

                    If Source_Id = "O" Then
                        '門診
                        If Nhi_Charge_Flag = "N" Then
                            If Is_Cure = "Y" Then
                                '療程項目
                                RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "S"
                            Else

                                If Is_No_Check_In = "N" Then '科室需報到
                                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "S"

                                ElseIf Is_No_Check_In = "Y" Then
                                    '先用Order_Code找PubOrderExamNocheckinDept , 如果找不到 ,就代表科室不需執行 , Charge_Flag =N
                                    If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "'").Count = 0 Then
                                        '沒找不到
                                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "N"
                                    Else
                                        '有找到 ,再依據門急住科診 找,如果找到 , 代表科室不需執行 , Charge_Flag =N
                                        If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "' And Kind_Id='" & Source_Id & "' And Dept_Code='" & Dept_Code & "' And Section_Id='" & Section_id & "'").Count > 0 Then
                                            RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "N"
                                        Else
                                            '沒找到,需要報到(執行)
                                            RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "S"
                                        End If
                                    End If

                                End If
                            End If
                        End If

                    Else

                        '急,住
                        If Nhi_Charge_Flag = "N" Then
                            If Is_No_Check_In = "N" Then '科室需報到
                                RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "S"

                            ElseIf Is_No_Check_In = "Y" Then
                                '先用Order_Code找PubOrderExamNocheckinDept , 如果找不到 ,就代表科室不需執行 , Charge_Flag =N
                                If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "'").Count = 0 Then
                                    '沒找不到
                                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "N"
                                Else
                                    '有找到 ,再依據門急住科診 找,如果找到 , 代表科室不需執行 , Charge_Flag =N
                                    If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "' And Kind_Id='" & Source_Id & "' And Dept_Code='" & Dept_Code & "'").Count > 0 Then
                                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "N"
                                    Else
                                        '沒找到,需要報到(執行)
                                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "S"
                                    End If
                                End If

                            End If
                        End If
                    End If


                End If

            End If

            Return RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag").ToString.Trim
        Catch ex As Exception
            Return Nothing
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 取得Is_Need_Execute屬性(針對檢驗檢查醫令是否需科室執行 (True:需執行 ;False:不用執行))
    ''' </summary>
    ''' <param name="Source_Id">O,E,I</param>
    ''' <param name="Main_Identity_Id">主身份</param>
    ''' <param name="Dept_Code">科別</param>
    ''' <param name="Section_id">診別</param>
    ''' <param name="Order_Code">Order_Code</param>
    Public Function GetIsNeedExecute(ByVal Source_Id As String, ByVal Main_Identity_Id As String, ByVal Dept_Code As String, ByVal Section_id As String, ByVal Order_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing)

        Dim Is_Need_Execute = False

        Try
            Dim Treatment_Type_Id As String = ""
            Dim Is_Cure As String = ""
            Dim Is_No_Check_In As String = ""

            Dim DataDS As New DataSet
            DataDS.Tables.Add()

            DataDS.Tables(0).Columns.Add("Code")
            DataDS.Tables(0).Columns.Add("Name")
            DataDS.Tables(0).Columns.Add("Is_OPD")
            DataDS.Tables(0).Columns.Add("Is_IPD")
            DataDS.Tables(0).Columns.Add("Is_EPD")
            DataDS.Tables(0).Columns.Add("IsEqualMatch")
            DataDS.Tables(0).Columns.Add("OrderTypeId")
            DataDS.Tables(0).Columns.Add("Is_ShowPrice")
            DataDS.Tables(0).Rows.Add()

            DataDS.Tables(0).Rows(0).Item("Code") = Order_Code.Trim
            DataDS.Tables(0).Rows(0).Item("IsEqualMatch") = "Y"

            Dim OrderDS = queryChargeFlagData(DataDS, conn)

            If PubOrderExamNocheckinDeptDS Is Nothing Then
                PubOrderExamNocheckinDeptDS = DynamicSQL(True, "Select Order_Code , Kind_Id , Dept_Code ,Section_Id  From PUB_Order_Exam_Nocheckin_Dept", conn)
            End If

            If OrderDS IsNot Nothing AndAlso OrderDS.Tables(0).Rows.Count > 0 Then

                Treatment_Type_Id = OrderDS.Tables(0).Rows(0).Item("Treatment_Type_Id").ToString.Trim
                Is_Cure = OrderDS.Tables(0).Rows(0).Item("Is_Cure").ToString.Trim
                Is_No_Check_In = OrderDS.Tables(0).Rows(0).Item("Is_No_Check_In").ToString.Trim
                '療程
                If Is_Cure = "Y" Then
                    Is_Need_Execute = True
                    Return Is_Need_Execute
                End If

                '檢驗檢查
                If (Treatment_Type_Id = "3" OrElse Treatment_Type_Id = "4") Then
                    If Is_No_Check_In = "" OrElse Is_No_Check_In = "N" Then
                        Is_Need_Execute = True
                        Return Is_Need_Execute
                    Else
                        'Is_No_Check_In="Y"
                        If Source_Id = "O" Then
                            '門診
                            '先用Order_Code找PubOrderExamNocheckinDept , 如果找不到 ,就代表科室不需執行 , Charge_Flag =N
                            If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "'").Count = 0 Then
                                '沒找不到
                                Is_Need_Execute = False
                                Return Is_Need_Execute
                            Else
                                '有找到 ,再依據門急住科診 找,如果找到 , 代表科室不需執行 , Charge_Flag =N
                                If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "' And Kind_Id='" & Source_Id & "' And Dept_Code='" & Dept_Code & "' And Section_Id='" & Section_id & "'").Count > 0 Then
                                    Is_Need_Execute = False
                                    Return Is_Need_Execute
                                Else
                                    '沒找到,需要報到(執行)
                                    Is_Need_Execute = True
                                    Return Is_Need_Execute
                                End If
                            End If
                        Else
                            '急住
                            '先用Order_Code找PubOrderExamNocheckinDept , 如果找不到 ,就代表科室不需執行 , Charge_Flag =N
                            If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "'").Count = 0 Then
                                '沒找不到
                                Is_Need_Execute = False
                                Return Is_Need_Execute
                            Else
                                '有找到 ,再依據門急住科診 找,如果找到 , 代表科室不需執行 , Charge_Flag =N
                                If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "' And Kind_Id='" & Source_Id & "' And Dept_Code='" & Dept_Code & "'").Count > 0 Then
                                    Is_Need_Execute = False
                                    Return Is_Need_Execute
                                Else
                                    '沒找到,需要報到(執行)
                                    Is_Need_Execute = True
                                    Return Is_Need_Execute
                                End If
                            End If
                        End If
                    End If

                End If

            End If

            Return Is_Need_Execute
        Catch ex As Exception
            Return Is_Need_Execute
        End Try
    End Function


    ''' <summary>
    ''' 取得ChargeFlag for 轉身分用
    ''' </summary>
    ''' <param name="Source_Id">O,E,I</param>
    ''' <param name="Main_Identity_Id">主身份</param>
    ''' <param name="Dept_Code">科別</param>
    ''' <param name="Section_id">診別</param>
    ''' <param name="Order_Code">Order_Code</param>
    ''' <param name="OldChargeFlag">PUB_Order_Price.Charge_Flag</param>
    ''' <param name="Order_Stat_Id">Order_Stat_Id</param>
    ''' <remarks>取得ChargeFlag</remarks>
    Public Shared Function getChargeFlagForIdentity(Source_id, Main_Identity_Id, Dept_Code, Section_id, Order_Code, OldChargeFlag, Order_Stat_Id) As String
        Try
            '==========================================================
            If OldChargeFlag = "" Then
                '不要靠這個處理 有可能會很慢喔...
                Dim DataDS As New DataSet
                DataDS.Tables.Add()

                DataDS.Tables(0).Columns.Add("Code")
                DataDS.Tables(0).Columns.Add("Name")
                DataDS.Tables(0).Columns.Add("Is_OPD")
                DataDS.Tables(0).Columns.Add("Is_IPD")
                DataDS.Tables(0).Columns.Add("Is_EPD")
                DataDS.Tables(0).Columns.Add("IsEqualMatch")
                DataDS.Tables(0).Columns.Add("OrderTypeId")
                DataDS.Tables(0).Columns.Add("Is_ShowPrice")
                DataDS.Tables(0).Rows.Add()

                DataDS.Tables(0).Rows(0).Item("Code") = Order_Code.Trim
                DataDS.Tables(0).Rows(0).Item("IsEqualMatch") = "Y"

                Dim OrderDS = queryChargeFlagData(DataDS)

                If OrderDS IsNot Nothing AndAlso OrderDS.Tables(0).Rows.Count > 0 Then
                    If Main_Identity_Id = "1" Then
                        OldChargeFlag = OrderDS.Tables(0).Rows(0).Item("Self_Charge_Flag").ToString.Trim
                    Else
                        OldChargeFlag = OrderDS.Tables(0).Rows(0).Item("Nhi_Charge_Flag").ToString.Trim
                    End If

                End If

            End If

            '==========================================================

            Dim RetrunDS As New DataSet
            RetrunDS.Tables.Add("Charge_Flag_Value")

            RetrunDS.Tables("Charge_Flag_Value").Columns.Add("Charge_Flag")

            RetrunDS.Tables("Charge_Flag_Value").Rows.Add()

            If OldChargeFlag.Trim = "O" Then
                RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "O"


            ElseIf OldChargeFlag.Trim = "X" Then
                RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "X"
            ElseIf OldChargeFlag.Trim = "N" OrElse OldChargeFlag.Trim = "S" Then
                RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "Y"

            ElseIf OldChargeFlag.Trim = "Y" Then
                Dim NewChargeFlag = getChargeFlag(Source_id, Main_Identity_Id, Dept_Code, Section_id, Order_Code)

                If NewChargeFlag = "S" Then
                    If IsNumeric(Order_Stat_Id) AndAlso CInt(Order_Stat_Id) >= 40 Then
                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "N"
                    Else
                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "S"
                    End If
                Else
                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = NewChargeFlag
                End If

            End If

            Return RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag").ToString.Trim
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    ''' <summary>
    ''' 取得ChargeFlag範圍
    ''' </summary>
    ''' <param name="Source_Id">OEI</param>
    ''' <param name="Main_Identity_Id">主身份</param>
    ''' <param name="Dept_Code">科</param>
    ''' <param name="Section_id">診</param>
    ''' <param name="Order_Code">醫令代碼</param>
    ''' <param name="Self_Charge_Flag">PUB_Order_Price.Charge_Flag(Main_Identity_Id = '1')</param>
    ''' <param name="Nhi_Charge_Flag">PUB_Order_Price.Charge_Flag(Main_Identity_Id = '2')</param>
    ''' <param name="Is_No_Check_In">PUB_Order_Examination.Is_No_Check_In</param>
    ''' <param name="Include_Order_Mark">PUB_Order.Include_Order_Mark</param>
    ''' <param name="Is_Cure">PUB_Order.Is_Cure</param>
    ''' <remarks>取得ChargeFlag範圍</remarks>
    Public Shared Function getChargeFlagRange(ByVal Source_Id As String, ByVal Main_Identity_Id As String, ByVal Dept_Code As String, ByVal Section_id As String, ByVal Order_Code As String, Optional ByVal Self_Charge_Flag As String = "", Optional ByVal Nhi_Charge_Flag As String = "", Optional ByVal Is_No_Check_In As String = "", Optional ByVal Include_Order_Mark As String = "", Optional ByVal Is_Cure As String = "") As DataSet
        Try


            Dim RetrunDS As New DataSet

            RetrunDS.Tables.Add("Charge_Flag_Range")

            RetrunDS.Tables("Charge_Flag_Range").Columns.Add("Range")

            '==========================================================
            If Self_Charge_Flag = "" AndAlso Nhi_Charge_Flag = "" Then
                '不要靠這個處理 有可能會很慢喔...
                Dim DataDS As New DataSet
                DataDS.Tables.Add()
                DataDS.Tables(0).Columns.Add("Action")
                DataDS.Tables(0).Columns.Add("Code")
                DataDS.Tables(0).Columns.Add("Name")
                DataDS.Tables(0).Columns.Add("Is_OPD")
                DataDS.Tables(0).Columns.Add("Is_IPD")
                DataDS.Tables(0).Columns.Add("Is_EPD")
                DataDS.Tables(0).Columns.Add("IsEqualMatch")
                DataDS.Tables(0).Columns.Add("OrderTypeId")
                DataDS.Tables(0).Columns.Add("Is_ShowPrice")
                DataDS.Tables(0).Columns.Add("Choice_Dc_Order")
                DataDS.Tables(0).Rows.Add()

                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Mixed"
                DataDS.Tables(0).Rows(0).Item("Code") = Order_Code.Trim
                DataDS.Tables(0).Rows(0).Item("IsEqualMatch") = "Y"
                DataDS.Tables(0).Rows(0).Item("Choice_Dc_Order") = "N"

                Dim OrderDS = queryChargeFlagData(DataDS)

                If OrderDS IsNot Nothing AndAlso OrderDS.Tables(0).Rows.Count > 0 Then
                    Self_Charge_Flag = OrderDS.Tables(0).Rows(0).Item("Self_Charge_Flag").ToString.Trim
                    Nhi_Charge_Flag = OrderDS.Tables(0).Rows(0).Item("Nhi_Charge_Flag").ToString.Trim
                    Is_No_Check_In = OrderDS.Tables(0).Rows(0).Item("Is_No_Check_In").ToString.Trim
                    Include_Order_Mark = OrderDS.Tables(0).Rows(0).Item("Include_Order_Mark").ToString.Trim
                    Is_Cure = OrderDS.Tables(0).Rows(0).Item("Is_Cure").ToString.Trim
                End If

            End If

            '==========================================================

            If Main_Identity_Id = "1" Then
                'Order_Price的自費 單價的Charge_Flag
                If Self_Charge_Flag.Trim = "O" Then

                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()

                    RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "O"
                    RetrunDS.Tables("Charge_Flag_Range").Rows(1).Item("Range") = "X"

                ElseIf Self_Charge_Flag.Trim = "Y" Then

                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()

                    RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "Y"
                    RetrunDS.Tables("Charge_Flag_Range").Rows(1).Item("Range") = "O"
                    RetrunDS.Tables("Charge_Flag_Range").Rows(2).Item("Range") = "X"

                ElseIf Self_Charge_Flag.Trim = "X" Then

                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "X"
                End If

            Else
                'Order_Price的健保 單價的Charge_Flag

                Dim Default_Charge_Flag As String = getChargeFlag(Source_Id, Main_Identity_Id, Dept_Code, Section_id, Order_Code, Self_Charge_Flag, Nhi_Charge_Flag, Is_No_Check_In, Include_Order_Mark)


                If Nhi_Charge_Flag.Trim = "S" OrElse Nhi_Charge_Flag.Trim = "N" Then

                    If Default_Charge_Flag.Trim = "S" Then

                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()

                        RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "S"
                        RetrunDS.Tables("Charge_Flag_Range").Rows(1).Item("Range") = "O"
                        RetrunDS.Tables("Charge_Flag_Range").Rows(2).Item("Range") = "X"

                    Else

                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()

                        RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "N"
                        RetrunDS.Tables("Charge_Flag_Range").Rows(1).Item("Range") = "O"
                        RetrunDS.Tables("Charge_Flag_Range").Rows(2).Item("Range") = "X"

                    End If

                ElseIf Nhi_Charge_Flag.Trim = "X" Then

                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "X"

                ElseIf Nhi_Charge_Flag.Trim = "O" Then

                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "O"
                    RetrunDS.Tables("Charge_Flag_Range").Rows(1).Item("Range") = "X"
                Else
                    '健保不給付
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()

                    RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "Y"
                    RetrunDS.Tables("Charge_Flag_Range").Rows(1).Item("Range") = "O"
                    RetrunDS.Tables("Charge_Flag_Range").Rows(2).Item("Range") = "X"

                End If

            End If

            Return RetrunDS
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 取得Is_Force
    ''' </summary>
    ''' <param name="dt">資料</param>
    ''' <remarks>取得Is_Force</remarks>
    Public Shared Function getIsForce(ByVal dt As DataTable) As DataSet

        Try
            Dim RetrunDS As New DataSet
            RetrunDS.Tables.Add(dt.Copy)

            If Not RetrunDS.Tables(0).Columns.Contains("Is_Force") Then
                RetrunDS.Tables(0).Columns.Add("Is_Force")
            End If

            For Each row As DataRow In RetrunDS.Tables(0).Rows
                If row.Item("Charge_Flag").ToString.Trim = "Y" Then
                    row.Item("Is_Force") = "N"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "N" Then
                    row.Item("Is_Force") = "N"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "O" Then
                    row.Item("Is_Force") = "Y"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "S" Then
                    row.Item("Is_Force") = "N"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "X" Then
                    row.Item("Is_Force") = "N"

                End If

            Next

            Return RetrunDS

        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    ''' <summary>
    ''' 取得Is_Force
    ''' </summary>
    ''' <param name="Charge_Flag">Charge_Flag</param>
    ''' <remarks>取得Is_Force</remarks>
    Public Shared Function getIsForce(ByVal Charge_Flag As String) As String

        Try

            Dim Is_Force As String = "N"

            If Charge_Flag.Trim = "Y" Then
                Is_Force = "N"

            ElseIf Charge_Flag.Trim = "N" Then
                Is_Force = "N"

            ElseIf Charge_Flag.Trim = "O" Then
                Is_Force = "Y"

            ElseIf Charge_Flag.Trim = "S" Then
                Is_Force = "N"

            ElseIf Charge_Flag.Trim = "X" Then
                Is_Force = "N"

            End If

            Return Is_Force

        Catch ex As Exception
            Return "N"
        End Try

    End Function


    ''' <summary>
    ''' 取得Is_Charge
    ''' </summary>
    ''' <param name="dt">資料</param>
    ''' <remarks>取得Is_Charge</remarks>
    Public Shared Function getIsCharge(ByVal dt As DataTable) As DataSet

        Try
            Dim RetrunDS As New DataSet
            RetrunDS.Tables.Add(dt.Copy)

            If Not RetrunDS.Tables(0).Columns.Contains("Is_Charge") Then
                RetrunDS.Tables(0).Columns.Add("Is_Charge")
            End If

            For Each row As DataRow In RetrunDS.Tables(0).Rows
                If row.Item("Charge_Flag").ToString.Trim = "Y" Then
                    row.Item("Is_Charge") = "Y"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "N" Then
                    row.Item("Is_Charge") = "Y"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "O" Then
                    row.Item("Is_Charge") = "Y"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "S" Then
                    row.Item("Is_Charge") = "Y"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "X" Then
                    row.Item("Is_Charge") = "N"

                End If

            Next

            Return RetrunDS
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    ''' <summary>
    ''' 取得Is_Charge
    ''' </summary>
    ''' <param name="Charge_Flag">Charge_Flag</param>
    ''' <remarks>取得Is_Charge</remarks>
    Public Shared Function getIsCharge(ByVal Charge_Flag As String) As String

        Try

            Dim Is_Charge As String = "Y"

            If Charge_Flag.Trim = "Y" Then
                Is_Charge = "Y"

            ElseIf Charge_Flag.Trim = "N" Then
                Is_Charge = "Y"

            ElseIf Charge_Flag.Trim = "O" Then
                Is_Charge = "Y"

            ElseIf Charge_Flag.Trim = "S" Then
                Is_Charge = "Y"

            ElseIf Charge_Flag.Trim = "X" Then
                Is_Charge = "N"

            End If

            Return Is_Charge

        Catch ex As Exception
            Return "Y"
        End Try

    End Function


    '查詢 queryChargeFlagData
    Public Shared Function queryChargeFlagData(ByVal DataDS As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet

            If connFlag Then
                conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                conn.Open()
            End If
            Dim sqlConn As SqlClient.SqlConnection = conn
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim BasicDate As Date = Now

            Dim BasicDateStr As String = ""

            Dim OrderCode As String = DataDS.Tables(0).Rows(0).Item("Code").ToString.Trim
            Dim OrderEnName As String = DataDS.Tables(0).Rows(0).Item("Name").ToString.Trim
            Dim OrderTypeId As String = DataDS.Tables(0).Rows(0).Item("OrderTypeId").ToString.Trim
            Dim MultiOrderTypeId As String = ""

            Dim Is_OPD As String = DataDS.Tables(0).Rows(0).Item("Is_OPD").ToString.Trim
            Dim Is_IPD As String = DataDS.Tables(0).Rows(0).Item("Is_IPD").ToString.Trim
            Dim Is_EPD As String = DataDS.Tables(0).Rows(0).Item("Is_EPD").ToString.Trim
            Dim Is_ShowPrice As String = DataDS.Tables(0).Rows(0).Item("Is_ShowPrice").ToString.Trim
            Dim Is_ChemoDrug As String = "N"
            Dim Is_Prior_Review As String = ""
            Dim IsEqualMatch As String = "N"
            Dim IsCheckPubOrderDc As String = "Y"
            Dim IsChoiceDcOrder As String = "N"

            Dim SourceFlag As String = ""

            '====================
            If OrderCode <> "" Then
                'Order_Code
                command.CommandText = " Select Distinct RTRIM(A.Order_Code) as 'Order_Code' , RTRIM(A.Order_En_Name) as 'Order_En_Name', RTRIM(B.Scientific_Name) as 'Scientific_Name' , RTRIM(B.Trade_Name) as 'Trade_Name' , RTRIM(B.Specification) as 'Specification' , Rtrim(B.Supply_Status_Memo) as  'Supply_Status_Memo' ,B.Opd_Lack_Id , B.Emg_Lack_Id , B.Ipd_Lack_Id ,B.Pharmacy_12_Code , B.Usage_Code , B.Frequency_Code ,B.Order_Default_Dosage  ,B.Dosage_unit ,B.Base_Dosage , B.Base_Dosage_Unit,B.Order_Unit1 , B.Order_Unit2 ,B.Order_Unit3 ,B.Order_Unit4 ,B.Order_Unit5 ,B.Class_Code  , B.Is_Control_Rule ,B.Form_Kind_Id , B.Is_Non_Powder , B.Package_Qty , B.Pharmacy_Name , B.Alert_Content , B.ATC_Code , A.Is_Order_Check , A.Is_Icd_Check , A.Charge_Unit  , A.Is_IC_Card_Order ,   A.Is_Prior_Review,  A.Include_Order_Mark ,A.Is_Cure , A.Account_Id ,A.DC , A.Dc_Reason , A.Order_Name ,   X.Price as 'Self_Price' , Y.Price as 'Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio', X.Opd_Add_Order_Code as 'Self_Opd_Add_Order_Code' ,  X.Emg_Add_Order_Code as 'Self_Emg_Add_Order_Code' , X.Ipd_Add_Order_Code as 'Self_Ipd_Add_Order_Code' , X.Charge_Flag  as 'Self_Charge_Flag', Y.Order_Ratio , Y.Material_Ratio , Y.Add_Price , Y.Opd_Add_Order_Code as 'Opd_Add_Order_Code' ,  Y.Emg_Add_Order_Code as 'Emg_Add_Order_Code' , Y.Ipd_Add_Order_Code as 'Ipd_Add_Order_Code' , Y.Charge_Flag  as 'Nhi_Charge_Flag' , Y.Insu_Code , A.Order_Type_Id  ,A.Treatment_Type_Id   , POE.Is_Scheduled , POE.Is_Same_Specimen_Add ,   POE.Default_Body_Site_Code ,POE.Default_Main_Body_Site_Code ,POE.Default_Side_Id ,POE.Default_Specimen_Id,  E.Sheet_Code , E.Separate_Mark ,E.Is_InstantlyRpt ,F.Is_Emergency_Sheet , POE.Is_Main_Body_Site , POE.Is_Body_Site , POE.Is_Side_Id  , POE.Deliver_System  , POE.Is_With_Contrast, POE.Nhi_Body_Site_Code , POE.Is_No_Separate , POE.Is_No_Check_In ,   G.* , Case When (Select count(Pharmacy_12_Code) from OPH_Property Where Pharmacy_12_Code=A.Order_Code And Property_Id In('11C','11D','11E'))> 0 Then 'True' Else 'False' End  Is_Needed_Consultation , Case When  ('" & BasicDate.ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "'<= A.End_Date ) And A.Dc <>'Y' Then 'Y' else 'N' End As Is_Valid_Order "
                command.CommandText += " From   PUB_Order  A "
                If Is_ChemoDrug <> "Y" Then
                    command.CommandText += " Left Join OPH_Pharmacy_Base B On A.Order_Code=B.Order_Code And B.Dc <>'Y' Left Join OPH_Property C  ON B.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id not in ('09' , '10'  ) Left Join  OPH_Code D On D.Type_Id ='8' And B.Omo_Reminder_Id =D.Code_Id And D.DC<>'Y' "
                Else
                    command.CommandText += " Left Join OPH_Pharmacy_Base B On A.Order_Code=B.Order_Code And B.Dc <>'Y' Left Join OPH_Property C  ON B.Pharmacy_12_Code=C.Pharmacy_12_Code And C.Property_Id  in ('10') Left Join  OPH_Code D On D.Type_Id ='8' And B.Omo_Reminder_Id =D.Code_Id And D.DC<>'Y' "
                End If

                command.CommandText += " Left Join PUB_Order_Examination as POE on POE.Order_Code = A.Order_Code" & _
                              " Left Join PUB_Sheet_Detail E Left Join PUB_Sheet F On E.Sheet_Code = F.Sheet_Code And E.Dc <>'Y' And F.Dc <>'Y' On  A.Order_Code =E.Order_Code  And E.Dc <>'Y' " & _
                              " Left Join PUB_Cure_Control G On A.Cure_Type_Id=G.Cure_Type_Id " & _
                              " Left Join PUB_Order_Price X On X.DC='N' And A.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & BasicDate.ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "'<= X.End_Date " & _
                              " Left Join PUB_Order_Price Y On Y.DC='N' And A.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & BasicDate.ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & BasicDate.ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                              " Where   1=1 And "

                command.CommandText += " ( A.Order_Code = '" & OrderCode & "')  "

                command.CommandText += " And '" & BasicDate.ToString("yyyy/M/d") & "' >= A.Effect_Date And '" & _
                             BasicDate.ToString("yyyy/M/d") & "'<= A.End_Date  "

                command.CommandText += " And (A.DC<>'Y' or A.DC is null) "

            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Order")
                adapter.Fill(ds, "PUB_Order")
            End Using

            Return ds

        Catch sqlex As SqlException
            Return Nothing
        Catch cmex As CommonException
            Return Nothing
        Catch ex As Exception
            Return Nothing
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function



    '動態查詢---2012-10-23 高秀玲
    Public Shared Function DynamicSQL(ByVal blnQuery As Boolean, ByVal strSQL As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim dsReturn As DataSet = New DataSet

        Dim connFlag As Boolean = conn Is Nothing

        If connFlag Then
            conn = SQLConnFactory.getInstance.getOpdDBSqlConn
        End If

        Try

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = strSQL
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With

                If blnQuery Then
                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        adapter.Fill(dsReturn)
                    End Using
                Else
                    If conn.State <> ConnectionState.Open Then conn.Open()
                    Dim dtResult As DataTable = New DataTable
                    dtResult.Columns.Add()
                    Dim drResult As DataRow = dtResult.NewRow
                    drResult(0) = command.ExecuteNonQuery
                    dtResult.Rows.Add(drResult)
                    dsReturn.Tables.Add(dtResult)
                End If
            End Using

        Catch ex As SqlException
            Throw ex
        Finally
            If connFlag Then
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Dispose()
            End If

        End Try

        Return dsReturn

    End Function


#End Region

#Region "取得醫令費用"

    ''' <summary>
    ''' 取得醫令費用
    ''' </summary>
    ''' <param name="SourceId">O/E/I</param>
    ''' <param name="PatientData">病人資料</param>
    ''' <param name="OrderData">醫令</param>
    ''' <remarks>醫令費用</remarks>
    Public Function GetOrderAmt(ByVal SourceId As String, ByVal PatientData As DataSet, ByVal OrderData As DataSet, Optional ByRef Conn As System.Data.IDbConnection = Nothing) As DataSet


        Dim connFlag As Boolean = Conn Is Nothing

        Try
            Dim Source_Id As String = SourceId
            Dim Order_Code As String = ""
            Dim Tqty As Decimal = 0
            Dim Is_Force As String = ""
            Dim Is_Charge As String = ""
            Dim Main_Identity_Id As String = ""
            Dim Dept_Code As String = ""
            Dim Doctor_Code As String = ""
            Dim Birth_Date As String = "" '(沒生日 就不跑兒童加成)
            Dim Is_Emg As String = "N"
            Dim Op_Divisor As String = "1"
            Dim Majorcare_Code As String = ""

            Dim Ratio_1 As Decimal = 1
            Dim Ratio_2 As Decimal = 1
            Dim Self_Price As String = ""
            Dim Nhi_Price As String = "" '(健保單價)
            Dim Self_Add_Price As String = ""
            Dim Nhi_Add_Price As String = ""
            Dim PriceDS As DataSet

            Dim Kid_Add_Ratio_1 As Decimal = 0
            Dim Kid_Add_Ratio_2 As Decimal = 0

            Dim Dept_Add_Ratio_1 As Decimal = 0
            Dim Dept_Add_Ratio_2 As Decimal = 0

            Dim Dental_Add_Ratio_1 As Decimal = 0
            Dim Dental_Add_Ratio_2 As Decimal = 0

            Dim Holiday_Add_Ratio_1 As Decimal = 0
            Dim Holiday_Add_Ratio_2 As Decimal = 0

            Dim Material_Ratio As Decimal = 0

            Dim Emg_Add_Ratio_1 As Decimal = 0
            Dim Emg_Add_Ratio_2 As Decimal = 0

            Dim Dr_Add_Ratio1 As Decimal = 0
            Dim Dr_Add_Ratio2 As Decimal = 0

            Dim Order_Ratio As Decimal = 0
            Dim Self_Order_Ratio As Decimal = 0


            Dim Majorcare_Add_Ratio As Decimal = 0

            Dim Total_Amt As Decimal = 0
            Dim Total_Self_Amt As Decimal = 0

            Dim PUBKidAddRatioReturnDS As DataSet = Nothing
            Dim PUBKidAddRatioDS As New DataSet

            PUBKidAddRatioDS.Tables.Add()
            PUBKidAddRatioDS.Tables(0).Columns.Add("Order_Code")
            PUBKidAddRatioDS.Tables(0).Columns.Add("Opd_Charge_Date")
            PUBKidAddRatioDS.Tables(0).Columns.Add("Main_Identity_Id")
            PUBKidAddRatioDS.Tables(0).Columns.Add("Pt_From_Id")
            PUBKidAddRatioDS.Tables(0).Columns.Add("Age")

            Dim ageMonth As Integer = -1

            If connFlag Then
                Conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                Conn.Open()
            End If

            If Not OrderData.Tables(0).Columns.Contains("Ratio_1") Then
                OrderData.Tables(0).Columns.Add("Ratio_1")
            End If

            If Not OrderData.Tables(0).Columns.Contains("Ratio_2") Then
                OrderData.Tables(0).Columns.Add("Ratio_2")
            End If

            If Not OrderData.Tables(0).Columns.Contains("Self_Price") Then
                OrderData.Tables(0).Columns.Add("Self_Price")
            End If

            If Not OrderData.Tables(0).Columns.Contains("Price") Then
                OrderData.Tables(0).Columns.Add("Price")
            End If


            If Not OrderData.Tables(0).Columns.Contains("Self_Add_Price") Then
                OrderData.Tables(0).Columns.Add("Self_Add_Price")
            End If

            If Not OrderData.Tables(0).Columns.Contains("Add_Price") Then
                OrderData.Tables(0).Columns.Add("Add_Price")
            End If

            If Not OrderData.Tables(0).Columns.Contains("Total_Amt") Then
                OrderData.Tables(0).Columns.Add("Total_Amt")
            End If

            If Not OrderData.Tables(0).Columns.Contains("Total_Self_Amt") Then
                OrderData.Tables(0).Columns.Add("Total_Self_Amt")
            End If

            For i As Integer = 0 To OrderData.Tables(0).Rows.Count - 1

                Order_Code = OrderData.Tables(0).Rows(i).Item("Order_Code").ToString.Trim
                Tqty = OrderData.Tables(0).Rows(i).Item("Tqty").ToString.Trim
                Is_Force = OrderData.Tables(0).Rows(i).Item("Is_Force").ToString.Trim
                Is_Charge = OrderData.Tables(0).Rows(i).Item("Is_Charge").ToString.Trim
                Main_Identity_Id = OrderData.Tables(0).Rows(i).Item("Main_Identity_Id").ToString.Trim

                Dept_Code = ""
                Birth_Date = ""
                Is_Emg = "N"
                Op_Divisor = "1"
                Majorcare_Code = ""
                ageMonth = -1

                Ratio_1 = 1
                Ratio_2 = 1

                Kid_Add_Ratio_1 = 0
                Kid_Add_Ratio_2 = 0

                Dept_Add_Ratio_1 = 0
                Dept_Add_Ratio_2 = 0

                Dental_Add_Ratio_1 = 0
                Dental_Add_Ratio_2 = 0

                Holiday_Add_Ratio_1 = 0
                Holiday_Add_Ratio_2 = 0

                Material_Ratio = 0

                Emg_Add_Ratio_1 = 0
                Emg_Add_Ratio_2 = 0

                Majorcare_Add_Ratio = 0

                Order_Ratio = 0
                Self_Order_Ratio = 0

                If PatientData.Tables(0).Columns.Contains("Dept_Code") Then
                    Dept_Code = PatientData.Tables(0).Rows(0).Item("Dept_Code").ToString.Trim
                End If

                If OrderData.Tables(0).Columns.Contains("Doctor_Code") Then
                    Doctor_Code = OrderData.Tables(0).Rows(i).Item("Doctor_Code").ToString.Trim
                End If

                If PatientData.Tables(0).Columns.Contains("Birth_Date") AndAlso IsDate(PatientData.Tables(0).Rows(0).Item("Birth_Date")) Then
                    Birth_Date = CDate(PatientData.Tables(0).Rows(0).Item("Birth_Date")).ToShortDateString  '(沒生日 就不跑兒童加成)
                    ageMonth = CInt(DateDiff(DateInterval.Month, CDate(Birth_Date).Date, Now.Date))

                End If

                If OrderData.Tables(0).Columns.Contains("Is_Emg") Then
                    Is_Emg = OrderData.Tables(0).Rows(i).Item("Is_Emg").ToString.Trim
                End If

                If OrderData.Tables(0).Columns.Contains("Op_Divisor") AndAlso IsNumeric(OrderData.Tables(0).Rows(i).Item("Op_Divisor")) Then
                    Op_Divisor = OrderData.Tables(0).Rows(i).Item("Op_Divisor").ToString.Trim
                Else
                    Op_Divisor = 1
                End If

                If PatientData.Tables(0).Columns.Contains("Majorcare_Code") Then
                    Majorcare_Code = PatientData.Tables(0).Rows(0).Item("Majorcare_Code").ToString.Trim
                End If

                '===============================

                PriceDS = QueryRatioByOrderCode(Order_Code, Source_Id, Majorcare_Code, Doctor_Code, Now, Now, Dept_Code, Conn)

                If PriceDS Is Nothing OrElse PriceDS.Tables(0).Rows.Count = 0 Then
                    Continue For
                End If

                If PriceDS.Tables(1).Rows.Count > 0 Then
                    If IsNumeric(PriceDS.Tables(1).Rows(0).Item("Majorcare_Add_Ratio")) Then
                        Majorcare_Add_Ratio = PriceDS.Tables(1).Rows(0).Item("Majorcare_Add_Ratio")
                    Else
                        Majorcare_Add_Ratio = "0"
                    End If

                Else
                    Majorcare_Add_Ratio = "0"
                End If

                If IsNumeric(PriceDS.Tables(0).Rows(0).Item("Self_Dept_Add_Ratio")) Then
                    Dept_Add_Ratio_1 = PriceDS.Tables(0).Rows(0).Item("Self_Dept_Add_Ratio")
                Else
                    Dept_Add_Ratio_1 = "0"
                End If


                If IsNumeric(PriceDS.Tables(0).Rows(0).Item("Self_Dept_Add_Ratio")) Then
                    Dept_Add_Ratio_1 = PriceDS.Tables(0).Rows(0).Item("Self_Dept_Add_Ratio")
                Else
                    Dept_Add_Ratio_1 = "0"
                End If

                If IsNumeric(PriceDS.Tables(0).Rows(0).Item("Dept_Add_Ratio")) Then
                    Dept_Add_Ratio_2 = PriceDS.Tables(0).Rows(0).Item("Dept_Add_Ratio")
                Else
                    Dept_Add_Ratio_2 = "0"
                End If

                If IsNumeric(PriceDS.Tables(0).Rows(0).Item("Self_Dr_Add_Ratio")) Then
                    Dr_Add_Ratio1 = PriceDS.Tables(0).Rows(0).Item("Self_Dr_Add_Ratio")
                Else
                    Dr_Add_Ratio1 = "0"
                End If

                If IsNumeric(PriceDS.Tables(0).Rows(0).Item("Dr_Add_Ratio")) Then
                    Dr_Add_Ratio2 = PriceDS.Tables(0).Rows(0).Item("Dr_Add_Ratio")
                Else
                    Dr_Add_Ratio2 = "0"
                End If

                If IsNumeric(PriceDS.Tables(0).Rows(0).Item("Self_Emg_Add_Ratio")) AndAlso Is_Emg = "Y" Then
                    Emg_Add_Ratio_1 = PriceDS.Tables(0).Rows(0).Item("Self_Emg_Add_Ratio")
                Else
                    Emg_Add_Ratio_1 = "0"
                End If

                If IsNumeric(PriceDS.Tables(0).Rows(0).Item("Emg_Add_Ratio")) AndAlso Is_Emg = "Y" Then
                    Emg_Add_Ratio_2 = PriceDS.Tables(0).Rows(0).Item("Emg_Add_Ratio")
                Else
                    Emg_Add_Ratio_2 = "0"
                End If

                Dental_Add_Ratio_1 = "0"
                Dental_Add_Ratio_2 = "0"

                Holiday_Add_Ratio_1 = "0"
                Holiday_Add_Ratio_2 = "0"

                If IsNumeric(PriceDS.Tables(0).Rows(0).Item("Material_Ratio")) Then
                    Material_Ratio = PriceDS.Tables(0).Rows(0).Item("Material_Ratio")
                Else

                    If IsNumeric(PriceDS.Tables(0).Rows(0).Item("Self_Material_Ratio")) Then
                        Material_Ratio = PriceDS.Tables(0).Rows(0).Item("Self_Material_Ratio")
                    Else
                        Material_Ratio = "0"
                    End If

                End If

                If ageMonth >= 0 Then
                    '以月份來算
                    PUBKidAddRatioDS.Tables(0).Rows.Clear()
                    PUBKidAddRatioDS.Tables(0).Rows.Add()
                    PUBKidAddRatioDS.Tables(0).Rows(0).Item("Order_Code") = OrderData.Tables(0).Rows(i).Item("Order_Code").ToString.Trim
                    PUBKidAddRatioDS.Tables(0).Rows(0).Item("Opd_Charge_Date") = Now.ToShortDateString
                    PUBKidAddRatioDS.Tables(0).Rows(0).Item("Main_Identity_Id") = Main_Identity_Id
                    PUBKidAddRatioDS.Tables(0).Rows(0).Item("Pt_From_Id") = Source_Id
                    PUBKidAddRatioDS.Tables(0).Rows(0).Item("Age") = ageMonth

                    If PriceDS.Tables(0).Rows(0).Item("Self_Is_Kid_Add").ToString.Trim = "Y" Then
                        PUBKidAddRatioReturnDS = GetKidAddRatio(PUBKidAddRatioDS, Conn)
                    End If

                    If PriceDS.Tables(0).Rows(0).Item("Self_Is_Kid_Add").ToString.Trim = "Y" AndAlso PUBKidAddRatioReturnDS IsNot Nothing AndAlso PUBKidAddRatioReturnDS.Tables(0).Rows.Count > 0 Then
                        If IsNumeric(PUBKidAddRatioReturnDS.Tables(0).Rows(0).Item("Kid_Add_Ratio")) Then
                            Kid_Add_Ratio_1 = PUBKidAddRatioReturnDS.Tables(0).Rows(0).Item("Kid_Add_Ratio")
                        Else
                            Kid_Add_Ratio_1 = "0"
                        End If
                    Else
                        Kid_Add_Ratio_1 = "0"
                    End If

                    PUBKidAddRatioDS.Tables(0).Rows.Clear()
                    PUBKidAddRatioDS.Tables(0).Rows.Add()
                    PUBKidAddRatioDS.Tables(0).Rows(0).Item("Order_Code") = OrderData.Tables(0).Rows(i).Item("Order_Code").ToString.Trim
                    PUBKidAddRatioDS.Tables(0).Rows(0).Item("Opd_Charge_Date") = Now.ToShortDateString
                    PUBKidAddRatioDS.Tables(0).Rows(0).Item("Main_Identity_Id") = Main_Identity_Id
                    PUBKidAddRatioDS.Tables(0).Rows(0).Item("Pt_From_Id") = Source_Id
                    PUBKidAddRatioDS.Tables(0).Rows(0).Item("Age") = ageMonth

                    If PriceDS.Tables(0).Rows(0).Item("Is_Kid_Add").ToString.Trim = "Y" Then

                        PUBKidAddRatioReturnDS = GetKidAddRatio(PUBKidAddRatioDS, Conn)

                    End If

                    If PriceDS.Tables(0).Rows(0).Item("Is_Kid_Add").ToString.Trim = "Y" AndAlso PUBKidAddRatioReturnDS IsNot Nothing AndAlso PUBKidAddRatioReturnDS.Tables(0).Rows.Count > 0 Then
                        If IsNumeric(PUBKidAddRatioReturnDS.Tables(0).Rows(0).Item("Kid_Add_Ratio")) Then
                            Kid_Add_Ratio_2 = PUBKidAddRatioReturnDS.Tables(0).Rows(0).Item("Kid_Add_Ratio")
                        Else
                            Kid_Add_Ratio_2 = "0"
                        End If
                    Else
                        Kid_Add_Ratio_2 = "0"
                    End If

                Else
                    Kid_Add_Ratio_1 = "0"
                    Kid_Add_Ratio_2 = "0"
                End If

                If IsNumeric(PriceDS.Tables(0).Rows(0).Item("Self_Order_Ratio")) Then
                    Self_Order_Ratio = PriceDS.Tables(0).Rows(0).Item("Self_Order_Ratio")
                Else
                    Self_Order_Ratio = 0
                End If

                If IsNumeric(PriceDS.Tables(0).Rows(0).Item("Order_Ratio")) Then
                    Order_Ratio = PriceDS.Tables(0).Rows(0).Item("Order_Ratio")
                Else
                    Order_Ratio = 0
                End If


                '==========================================
                '傳回健保與自費的單價及成數,前端可自行運算
                Ratio_1 = (CDec(Majorcare_Add_Ratio) + CDec(Material_Ratio) + CDec(Dr_Add_Ratio1) + CDec(Kid_Add_Ratio_1) + CDec(Emg_Add_Ratio_1) + CDec(Dental_Add_Ratio_1) + CDec(Holiday_Add_Ratio_1) + CDec(Dept_Add_Ratio_1) + CDec(Self_Order_Ratio)) / CDec(Op_Divisor) '(Material_Ratio+Kid_Add_Ratio+Emg_Add_Ratio+Dental_Add_Ratio+Holiday_Add_Ratio+ Order_Ratio+ Dept_Add_Ratio)
                Ratio_2 = (CDec(Majorcare_Add_Ratio) + CDec(Material_Ratio) + CDec(Dr_Add_Ratio2) + CDec(Kid_Add_Ratio_2) + CDec(Emg_Add_Ratio_2) + CDec(Dental_Add_Ratio_2) + CDec(Holiday_Add_Ratio_2) + CDec(Dept_Add_Ratio_2) + CDec(Order_Ratio)) / CDec(Op_Divisor)

                Ratio_1 = Math.Round(Ratio_1, 2, MidpointRounding.AwayFromZero)
                Ratio_2 = Math.Round(Ratio_2, 2, MidpointRounding.AwayFromZero)

                '============================================
                '依據傳進來的身份 計算 健保金額 Total_Amt, 或自付金額 Total_Self_Amt

                'Total_Amt 
                'if mainid=2 and Price is not null  and   Is_Charge=Y and is_force =N 
                '   Total_Amt = Ratio_2 *  Price * Tqty

                If Main_Identity_Id = "2" AndAlso IsNumeric(PriceDS.Tables(0).Rows(0).Item("Price")) AndAlso Is_Charge = "Y" AndAlso Is_Force = "N" Then
                    Total_Amt = Ratio_2 * CDec(PriceDS.Tables(0).Rows(0).Item("Price")) * Tqty
                End If

                '============================================

                If Main_Identity_Id = "1" AndAlso Is_Charge = "Y" Then
                    Total_Self_Amt = Ratio_1 * CDec(PriceDS.Tables(0).Rows(0).Item("Self_Price")) * Tqty

                ElseIf Main_Identity_Id = "2" AndAlso Not IsNumeric(PriceDS.Tables(0).Rows(0).Item("Price")) AndAlso Is_Charge = "Y" Then

                    Total_Self_Amt = Ratio_1 * CDec(PriceDS.Tables(0).Rows(0).Item("Self_Price")) * Tqty

                ElseIf Main_Identity_Id = "2" AndAlso IsNumeric(PriceDS.Tables(0).Rows(0).Item("Price")) AndAlso Is_Charge = "Y" AndAlso Is_Force = "Y" Then

                    Total_Self_Amt = Ratio_1 * CDec(PriceDS.Tables(0).Rows(0).Item("Self_Price")) * Tqty
                ElseIf Main_Identity_Id = "2" AndAlso IsNumeric(PriceDS.Tables(0).Rows(0).Item("Price")) AndAlso Is_Charge = "Y" AndAlso Is_Force = "N" AndAlso IsNumeric(PriceDS.Tables(0).Rows(0).Item("Add_Price")) AndAlso Nhi_Add_Price > 0 Then

                    Total_Self_Amt = Nhi_Add_Price * Tqty
                End If

                OrderData.Tables(0).Rows(i).Item("Ratio_1") = Ratio_1
                OrderData.Tables(0).Rows(i).Item("Ratio_2") = Ratio_2
                OrderData.Tables(0).Rows(i).Item("Total_Amt") = Total_Amt
                OrderData.Tables(0).Rows(i).Item("Total_Self_Amt") = Total_Self_Amt

                OrderData.Tables(0).Rows(i).Item("Self_Price") = PriceDS.Tables(0).Rows(0).Item("Self_Price")
                OrderData.Tables(0).Rows(i).Item("Price") = PriceDS.Tables(0).Rows(0).Item("Price") '(健保單價)
                OrderData.Tables(0).Rows(i).Item("Self_Add_Price") = PriceDS.Tables(0).Rows(0).Item("Self_Add_Price")
                OrderData.Tables(0).Rows(i).Item("Add_Price") = PriceDS.Tables(0).Rows(0).Item("Add_Price")

                'Total_Self_Amt
                'if mainid =1 and Is_Charge=Y
                ' Total_Self_Amt=  Ratio_1 * Self_Price * Tqty

                'else maid =2 and Price is null (健保不給付)  and Is_Charge=Y
                ' Total_Self_Amt=  Ratio_1 * Self_Price * Tqty

                ' else mainid=2 and Price is not null and is_force =Y and Is_Charge=Y
                '  Total_Self_Amt=  Ratio_1 * Self_Price * Tqty
                'else mainid=2 and Price is not null and is_force =N and Is_Charge=Y and Add_Price is not null
                '  Total_Self_Amt=  Add_Price  * Tqty

            Next



            Return OrderData
        Catch ex As Exception
            Return Nothing

        Finally
            If connFlag AndAlso Conn IsNot Nothing Then
                Conn.Close()
                Conn.Dispose()
                Conn = Nothing
            End If

        End Try

    End Function


    ''' <summary>
    ''' 批價 查詢方法(使用Order_Code查詢) By James
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by James on 2012-2-8</remarks>
    Public Function QueryRatioByOrderCode(ByVal Order_Code As String, ByVal Pt_From_Id As String, ByVal Majorcare_Code As String, ByVal Employee_Code As String, ByVal Effect_Date As Date, ByVal End_Date As Date, ByVal Dept_Code As String, Optional ByRef Conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = Conn Is Nothing

        Try

            If connFlag Then
                Conn = getOPDConnection()
                Conn.Open()
            End If


            Dim sqlStr As String = ""
            Dim DeptCode As String = Dept_Code
            Dim QueryDepDS As New DataSet

            Try
                sqlStr = "  Select NHI_Ipd_Dept_Code From PUB_Department Where Dept_Code='" & Dept_Code & "' And Is_Ipd_Dept ='Y' And DC='N'   "
                Dim _DepCommand As New SqlCommand(sqlStr, Conn)

                Dim _dataAdapterDep1 As SqlDataAdapter = New SqlDataAdapter(_DepCommand)
                _dataAdapterDep1.Fill(QueryDepDS)

                If QueryDepDS IsNot Nothing AndAlso QueryDepDS.Tables(0).Rows.Count > 0 Then
                    DeptCode = QueryDepDS.Tables(0).Rows(0).Item(0).ToString.Trim
                End If
            Catch ex As Exception

            End Try

            sqlStr = "  Select    B.* ,   X.Price as 'Self_Price' , X.Add_Price  as 'Self_Add_Price' , X.Order_Ratio as 'Self_Order_Ratio' , X.Material_Ratio as 'Self_Material_Ratio' , X.Is_Kid_Add as 'Self_Is_Kid_Add' , X.Charge_Flag as 'Self_Charge_Flag' , M.Add_Ratio as 'Self_Dr_Add_Ratio' , Y.Price , Y.Add_Price, Y.Order_Ratio , Y.Insu_Order_Type_Id , Y.Insu_Account_Id , Y.Insu_Code , Y.Material_Account_Id , Y.Material_Ratio , Y.Is_Kid_Add as 'Is_Kid_Add' , Y.Charge_Flag as 'Charge_Flag' ,   N.Add_Ratio as 'Dr_Add_Ratio' , Z.Account_Id , Z.Receipt_Account_Id  , P.Emg_Add_Ratio  as 'Self_Emg_Add_Ratio'  , Q.Emg_Add_Ratio , J.Dept_Add_Ratio as 'Self_Dept_Add_Ratio' , K.Dept_Add_Ratio From  PUB_Order B " & _
                      "       Left Join PUB_Order_Price X On /* X.DC='N' And */ B.Order_Code=X.Order_Code And  X.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= X.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= X.End_Date " & _
                      "       Left Join PUB_Order_Price Y On /* Y.DC='N' And */ B.Order_Code=Y.Order_Code And  Y.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Y.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Y.End_Date " & _
                      "       Left Join PUB_Account Z On Z.DC='N' And B.Account_Id=Z.Account_Id   " & _
                      "       Left Join PUB_Emg_Add P On /* P.DC='N' And */ B.Order_Code=P.Order_Code And  P.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= P.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= P.End_Date And P.Pt_From_Id ='" & Pt_From_Id & "' " & _
                      "       Left Join PUB_Emg_Add Q On /* Q.DC='N' And */ B.Order_Code=Q.Order_Code And  Q.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= Q.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= Q.End_Date And Q.Pt_From_Id ='" & Pt_From_Id & "' " & _
                      "       Left Join PUB_Dept_Add J On /* J.DC='N' And */ B.Order_Code=J.Order_Code And  J.Main_Identity_Id='1' And  '" & Now().ToString("yyyy/M/d") & "' >= J.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= J.End_Date And J.Pt_From_Id='' And J.Dept_Code='" & DeptCode & "' " & _
                      "       Left Join PUB_Dept_Add K On /* K.DC='N' And */ B.Order_Code=K.Order_Code And  K.Main_Identity_Id='2' And  '" & Now().ToString("yyyy/M/d") & "' >= K.Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= K.End_Date And K.Pt_From_Id='' And K.Dept_Code='" & DeptCode & "' " & _
                      "       Left Join PUB_Dr_Add M On  B.Order_Code=M.Order_Code And M.Main_Identity_Id ='1' And M.Order_Code ='" & Order_Code & "' And M.Pt_From_Id ='' And M.Effect_Date <='" & Now().ToString("yyyy/M/d") & "' And '" & Now().ToString("yyyy/M/d") & "'<=M.End_Date   And 0 < (select count(*) from PUB_Dr_Add_Control where (Dept_Code ='' or Dept_Code='" & Dept_Code & "') and Order_Code ='" & Order_Code & "' and Employee_Code ='" & Employee_Code & "') " & _
                      "       Left Join PUB_Dr_Add N On  B.Order_Code=N.Order_Code And N.Main_Identity_Id ='2' And N.Order_Code ='" & Order_Code & "' And N.Pt_From_Id ='' And N.Effect_Date <='" & Now().ToString("yyyy/M/d") & "' And '" & Now().ToString("yyyy/M/d") & "'<=N.End_Date   And 0 < (select count(*) from PUB_Dr_Add_Control where (Dept_Code ='' or Dept_Code='" & Dept_Code & "') and Order_Code ='" & Order_Code & "' and Employee_Code ='" & Employee_Code & "') " & _
                      "  Where     B.Order_Code='" & Order_Code & "' And '" & Effect_Date.ToString("yyyy/M/d") & "' >= B.Effect_Date And '" & End_Date.ToString("yyyy/M/d") & "'<= B.End_Date And  B.dc<>'Y'    ;"

            sqlStr += " Select Add_Ratio as 'Majorcare_Add_Ratio' From PUB_Majorcare_Add Where Majorcare_Code ='" & Majorcare_Code & "' And Pt_From_Id ='' And Order_Code ='" & Order_Code & "'  And '" & Effect_Date.ToString("yyyy/M/d") & "' >=  Effect_Date And '" & End_Date.ToString("yyyy/M/d") & "'<=  End_Date "


            Dim QueryDS As New DataSet

            'Using _sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPcsDBSqlConn

            Dim _command As New SqlCommand(sqlStr, Conn)

            Dim _dataAdapter1 As SqlDataAdapter = New SqlDataAdapter(_command)


            _dataAdapter1.Fill(QueryDS)
            'End Using

            Return QueryDS

        Catch ex As Exception
            Return Nothing
        Finally
            If connFlag AndAlso Conn IsNot Nothing Then
                Conn.Close()
                Conn.Dispose()
                Conn = Nothing
            End If
        End Try
    End Function


    '取得年齡
    Public Function QueryPatAgeYear(ByVal Chart_No As String, ByVal Account_Date As String, Optional ByRef Conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = Conn Is Nothing

        Try
            If connFlag Then
                Conn = getOPDConnection()
                Conn.Open()
            End If

            Dim sqlStr As String = ""

            sqlStr += "  Select Birth_Date  From PUB_Patient Where Chart_No ='" & Chart_No & "' "


            Dim QueryDS As New DataSet

            'Using _sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPcsDBSqlConn
            Dim _command As New SqlCommand(sqlStr, Conn)
            Dim _dataAdapter1 As SqlDataAdapter = New SqlDataAdapter(_command)
            _dataAdapter1.Fill(QueryDS)
            'End Using

            If QueryDS IsNot Nothing AndAlso QueryDS.Tables(0).Rows.Count > 0 AndAlso IsDate(QueryDS.Tables(0).Rows(0).Item(0)) Then
                Dim Age As String() = GetAge(CDate(QueryDS.Tables(0).Rows(0).Item(0)).Date, CDate(Account_Date).Date)

                If Age IsNot Nothing AndAlso Age.Count > 2 AndAlso IsNumeric(Age(0)) AndAlso IsNumeric(Age(1)) Then
                    Return CInt(Age(0)) * 12 + CInt(Age(1))
                End If

            Else
                Return -1
            End If

        Catch ex As Exception
            Return -1
        Finally
            If connFlag AndAlso Conn IsNot Nothing Then
                Conn.Close()
                Conn.Dispose()
                Conn = Nothing
            End If

        End Try
        Return -1
    End Function

    '取得年齡
    Public Function QueryPatAgeMonth(ByVal Chart_No As String, ByVal Account_Date As String, Optional ByRef Conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = Conn Is Nothing

        Try
            If connFlag Then
                Conn = getOPDConnection()
                Conn.Open()
            End If

            Dim sqlStr As String = ""

            sqlStr += "  Select Birth_Date  From PUB_Patient Where Chart_No ='" & Chart_No & "' "


            Dim QueryDS As New DataSet

            'Using _sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPcsDBSqlConn
            Dim _command As New SqlCommand(sqlStr, Conn)
            Dim _dataAdapter1 As SqlDataAdapter = New SqlDataAdapter(_command)
            _dataAdapter1.Fill(QueryDS)
            'End Using

            If QueryDS IsNot Nothing AndAlso QueryDS.Tables(0).Rows.Count > 0 AndAlso IsDate(QueryDS.Tables(0).Rows(0).Item(0)) Then

                Return CInt(DateDiff(DateInterval.Month, CDate(QueryDS.Tables(0).Rows(0).Item("Birth_Date")).Date, CDate(Account_Date).Date))

                'Dim Age As String() = PCSDateUtil.PCSGetAge(CDate(QueryDS.Tables(0).Rows(0).Item(0)).Date, CDate(Account_Date).Date)

                'If Age IsNot Nothing AndAlso Age.Count > 2 AndAlso IsNumeric(Age(0)) AndAlso IsNumeric(Age(1)) Then
                '    Return CInt(Age(0)) * 12 + CInt(Age(1))
                'End If

            Else
                Return -1
            End If

        Catch ex As Exception
            Return -1
        Finally
            If connFlag AndAlso Conn IsNot Nothing Then
                Conn.Close()
                Conn.Dispose()
                Conn = Nothing
            End If

        End Try

    End Function


#End Region

End Class
