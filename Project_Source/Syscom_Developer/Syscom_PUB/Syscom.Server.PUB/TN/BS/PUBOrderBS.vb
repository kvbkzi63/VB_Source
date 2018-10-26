Imports System.Data.SqlClient
Imports System.Transactions
Imports log4net
Imports Syscom.Comm.Utility
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports System.Reflection
Imports System.Text


Public Class PUBOrderBS
    Implements IDisposable


#Region "########## getInstance() ##########"

    'Private Shared instance As PUBOrderBS

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As PUBOrderBS
        Try
            Return New PUBOrderBS

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region


#Region "特殊處理狀態"
    'update
    Private SpecialProcessStatus0 As String = "102400"
    'insert
    Private SpecialProcessStatus1 As String = "102401"
    Private SpecialProcessStatus2 As String = "102402"
    Private SpecialProcessStatus3 As String = "102403"
    Private SpecialProcessStatus4 As String = "102404"
#End Region


    ''' <summary>
    ''' 初始醫令畫面資料-處置/其他; 藥品; 檢驗查
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Add By Jen</remarks>
    Public Function initPUBOrderInfo(ByVal initType As String) As DataSet
        Dim SyscodeDT As DataTable = Nothing
        Dim SystemDate As Date = DateUtil.getSystemDate
        Dim OrderInitDS As New DataSet

        If initType IsNot Nothing AndAlso (initType.Equals("Order") Or initType.Equals("Examine")) Then
            Dim MajorcareDT As DataTable = PUBMajorcareBO_E1.getInstance.queryMajorcareForCombo("")
            If DataSetUtil.IsContainsData(MajorcareDT) Then
                MajorcareDT.TableName = "majorcare"
                OrderInitDS.Tables.Add(MajorcareDT)
            End If
            'modify by 唐子晴 2014.02.06 ---------------------------------------------------------
            Dim TypeIds() As Integer = {18, 19, 36, 39, 40, 41, 43, 69, 501, 510, 511, 902, 1262}
            'Dim TypeIds() As Integer = {18, 19, 36, 39, 40, 41, 43, 69, 501, 510, 511, 902}
            '-------------------------------------------------------------------------------------
            SyscodeDT = PUBSysCodeBO_E1.getInstance.querySyscodeByTypeIds(TypeIds)
        ElseIf initType IsNot Nothing AndAlso initType.Equals("Medicine") Then
            'modify by 唐子晴 2014.02.06 -----------------------------------
            Dim TypeIds() As Integer = {18, 19, 39, 41, 43, 501, 902, 1262}
            'Dim TypeIds() As Integer = {18, 19, 39, 41, 43, 501, 902}
            '---------------------------------------------------------------
            SyscodeDT = PUBSysCodeBO_E1.getInstance.querySyscodeByTypeIds(TypeIds)
        End If


        Dim UnitDT As DataTable = PUBUnitBO_E1.getInstance.queryUnitForCombo
        If DataSetUtil.IsContainsData(UnitDT) Then
            UnitDT.TableName = "unit"
            OrderInitDS.Tables.Add(UnitDT)
        End If

        'syscode: 18(身分), 19(計算到...), 39(群組醫令), 36, 41, 43, 69, 501, 902
        'Dim TypeIds() As Integer = {18, 19, 36, 39, 40, 41, 43, 69, 501, 511, 902}
        'Dim SyscodeDT As DataTable = PUBSysCodeBO_E1.getInstance.querySyscodeByTypeIds(TypeIds)
        If DataSetUtil.IsContainsData(SyscodeDT) Then
            SyscodeDT.TableName = "pubsyscode"
            OrderInitDS.Tables.Add(SyscodeDT)
        End If

        '系統日期
        Dim SystemDateColumn() As String = {"System_Date"}
        Dim SystemDateColumnType() As Integer = {DataSetUtil.TypeDate}
        Dim SystemDateDT As DataTable = DataSetUtil.createDataTable("systemdate", Nothing, SystemDateColumn, SystemDateColumnType)
        Dim dateDR As DataRow = SystemDateDT.NewRow
        dateDR(SystemDateColumn(0)) = SystemDate

        SystemDateDT.Rows.Add(dateDR)

        OrderInitDS.Tables.Add(SystemDateDT)

        Return OrderInitDS
    End Function

    ''' <summary>
    ''' 醫令資料查詢(含醫令，醫令價格)
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <param name="EffectDate"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order, PUB_Order_Price</remarks>
    Public Function queryOrderData(ByVal OrderCode As String, ByVal EffectDate As Date) As DataSet
        Dim orderRelatedDS As New DataSet
        Dim orderDT As DataTable = PUBOrderBO_E1.getInstance.queryOrderData2(OrderCode, EffectDate)

        If DataSetUtil.IsContainsData(orderDT) Then
            orderRelatedDS.Tables.Add(orderDT)

            Dim OrderTypeId As String = CType(orderDT.Rows(0).Item("Order_Type_Id"), String).Trim

            If OrderTypeId.Equals("E") Or OrderTypeId.Equals("F") Then
                Dim PharmacyBaseDT As DataTable = PUBDelegate.getInstance.queryPharmacyBaseByOrderCode(OrderCode)
                If DataSetUtil.IsContainsData(PharmacyBaseDT) Then
                    orderRelatedDS.Tables.Add(PharmacyBaseDT)
                End If

                Dim ExcludeDrugSetDT As DataTable = PUBDelegate.getInstance.queryExclusiveDrugSetData(OrderCode)
                If ExcludeDrugSetDT IsNot Nothing Then
                    orderRelatedDS.Tables.Add(ExcludeDrugSetDT)
                End If

            Else

                Dim CureTypeId As String = ""
                If Not IsDBNull(orderDT.Rows(0).Item("Is_Cure")) AndAlso CType(orderDT.Rows(0).Item("Is_Cure"), String).Trim.Equals("Y") Then
                    If Not IsDBNull(orderDT.Rows(0).Item("Cure_Type_Id")) Then
                        CureTypeId = CType(orderDT.Rows(0).Item("Cure_Type_Id"), String).Trim
                    End If
                End If

                If (CureTypeId IsNot Nothing) AndAlso (Not CureTypeId.Equals("")) Then
                    Dim CureContrilDS As DataSet = PUBCureControlBO_E1.getInstance.queryByPK(CureTypeId)
                    If DataSetUtil.IsContainsData(CureContrilDS.Tables(PubCureControlDataTableFactory.tableName)) Then
                        orderRelatedDS.Tables.Add(CureContrilDS.Tables(PubCureControlDataTableFactory.tableName).Copy)
                    End If
                End If

                'Dim OrderMajorcareDT As DataTable = PUBOrderMajorcareBO_E1.getInstance.queryMajorcareData(OrderCode)
                'If DataSetUtil.IsContainsData(OrderMajorcareDT) Then
                '    orderRelatedDS.Tables.Add(OrderMajorcareDT)
                'End If

                If OrderTypeId.Equals("J") Then
                    Dim OrderOrTreatDT As DataTable = PUBOrderOrTreatBO_E1.getInstance.queryByOrderCode(OrderCode)
                    If DataSetUtil.IsContainsData(OrderOrTreatDT) Then
                        orderRelatedDS.Tables.Add(OrderOrTreatDT)
                    End If
                End If

                'H Type多查
                If OrderTypeId.Equals("H") Then
                    Dim OrderExaminationDT As DataTable = PUBOrderExaminationBO_E1.getInstance.queryActiveOrderCode(OrderCode)
                    If DataSetUtil.IsContainsData(OrderExaminationDT) Then
                        orderRelatedDS.Tables.Add(OrderExaminationDT)
                    End If
                End If

                'G Type多查
                If OrderTypeId.Equals("G") Then
                    Dim OrderMaterialDS As DataSet = PUBMaterialSelfpayApplyBO_E1.GetInstance.queryLastData(OrderCode)
                    If OrderMaterialDS IsNot Nothing AndAlso OrderMaterialDS.Tables IsNot Nothing AndAlso OrderMaterialDS.Tables(0).Rows.Count > 0 Then
                        orderRelatedDS.Tables.Add(OrderMaterialDS.Tables(0).Copy)
                    End If
                End If

            End If

            Dim OrderPriceDT As DataTable = PUBOrderPriceBO_E1.getInstance.queryOrderPriceData(OrderCode)

            If DataSetUtil.IsContainsData(OrderPriceDT) Then
                orderRelatedDS.Tables.Add(OrderPriceDT)
            End If

            Dim OrderPriceHistoryDT As DataTable = PUBOrderPriceBO_E1.getInstance.queryOrderPriceHistoryData(OrderCode)

            If DataSetUtil.IsContainsData(OrderPriceHistoryDT) Then
                OrderPriceHistoryDT.TableName = PubOrderPriceDataTableFactory.tableName & "-" & "History"
                orderRelatedDS.Tables.Add(OrderPriceHistoryDT)
            End If

        Else


            Dim PharmacyBaseDT As DataTable = PUBDelegate.getInstance.queryPharmacyBaseByOrderCode(OrderCode)
            If DataSetUtil.IsContainsData(PharmacyBaseDT) Then
                orderRelatedDS.Tables.Add(PharmacyBaseDT)
            End If

            Dim ExcludeDrugSetDT As DataTable = PUBDelegate.getInstance.queryExclusiveDrugSetData(OrderCode)
            If ExcludeDrugSetDT IsNot Nothing Then
                orderRelatedDS.Tables.Add(ExcludeDrugSetDT)
            End If


        End If


        Return orderRelatedDS

    End Function

    ''' <summary>
    ''' 檢查醫令的特殊處理狀態
    ''' </summary>
    ''' <param name="OldOrderDT"></param>
    ''' <param name="NewOrderDT"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function checkProcessStatus(ByVal OldOrderDT As DataTable, ByVal NewOrderDT As DataTable) As DataSet
        '0 更新
        '1....新增...新舊不相關

        Dim SystemDate As Date = DateUtil.getSystemDate
        Dim returnOpeDS As New DataSet

        If DataSetUtil.IsContainsData(OldOrderDT) Then
            If DataSetUtil.IsContainsData(NewOrderDT) Then
                '有舊有新
                '開始檢查
                Dim oldOrderCode As String = CType(OldOrderDT.Rows(0).Item("Order_Code"), String).Trim
                Dim oldEffectDate As Date = CType(OldOrderDT.Rows(0).Item("Effect_Date"), Date)

                Dim newOrderCode As String = CType(NewOrderDT.Rows(0).Item("Order_Code"), String).Trim
                Dim newEffectDate As Date = CType(NewOrderDT.Rows(0).Item("Effect_Date"), Date)

                'add by 唐子晴 2014.02.19------------------------------------------------
                Dim oldDc As String = CType(OldOrderDT.Rows(0).Item("Dc"), String).Trim
                Dim newDc As String = CType(NewOrderDT.Rows(0).Item("Dc"), String).Trim
                '------------------------------------------------------------------------

                If oldOrderCode.Equals(newOrderCode) Then
                    'modify by 唐子晴 2014.03.12 --
                    NewOrderDT.TableName = "Update"
                    '-------------------------------
                    returnOpeDS.Tables.Add(NewOrderDT)
                    returnOpeDS.DataSetName = SpecialProcessStatus0
                    Return returnOpeDS
                    'If oldEffectDate.ToString("yyyy/MM/dd").Equals(newEffectDate.ToString("yyyy/MM/dd")) Then
                    '    'old new 一樣 update內容
                    '    'SpecialProcessStatus0
                    '    NewOrderDT.TableName = "Update"
                    '    returnOpeDS.Tables.Add(NewOrderDT)
                    '    returnOpeDS.DataSetName = SpecialProcessStatus0
                    '    Return returnOpeDS

                    'Else
                    '    Dim OrderDT As DataTable = PUBOrderBO_E1.getInstance.queryCompleteOrderData(oldOrderCode)
                    '    Dim workOrderDT As DataTable = PubOrderDataTableFactory.getDataTableWithSchema

                    '    If DataSetUtil.IsContainsData(OrderDT) Then
                    '        For i As Integer = 0 To (OrderDT.Rows.Count - 1)
                    '            workOrderDT.Rows.Add(OrderDT.Rows(i).ItemArray)
                    '            If oldEffectDate.ToString("yyyy/MM/dd").Equals(CType(OrderDT.Rows(i).Item("Effect_Date"), Date).ToString("yyyy/MM/dd")) Then
                    '                Exit For
                    '            End If
                    '        Next

                    '        'workOrderDT
                    '        '2.同代碼修改date..EffectDate < systemdate且2 date間沒存在record>> 原代碼DC=Y,enddte = 新effectdate-1, insert 1 update old
                    '        '3.同代碼修改date..EffectDate < systemdate且2 date間有存在record>>是否刪除已存資料? Y>delete, 原代碼DC=Y,enddte = 新effectdate-1, insert 1 update old
                    '        '4.同代碼修改date..EffectDate > systemdate且2 ,new enddte = old effectdate;dc=Y, old enddate = new effectdate-1, insert new, update old

                    '        If newEffectDate.ToString("yyyy/MM/dd").CompareTo(SystemDate.ToString("yyyy/MM/dd")) <= 0 Then
                    '            If DataSetUtil.IsContainsData(workOrderDT) Then
                    '                workOrderDT.Rows(0).Item("Dc") = "Y"
                    '                workOrderDT.Rows(0).Item("End_Date") = newEffectDate.AddDays(-1)

                    '                'TODO
                    '                'workOrderDT update
                    '                'newOrder insert
                    '                'SpecialProcessStatus2
                    '                workOrderDT.TableName = "Update"
                    '                NewOrderDT.TableName = "Insert"
                    '                returnOpeDS.Tables.Add(workOrderDT)
                    '                returnOpeDS.Tables.Add(NewOrderDT)
                    '                returnOpeDS.DataSetName = SpecialProcessStatus2
                    '                Return returnOpeDS
                    '                'If workOrderDT.Rows.Count = 1 Then
                    '                '    '=1 , 2
                    '                '    workOrderDT.Rows(0).Item("Dc") = "Y"
                    '                '    workOrderDT.Rows(0).Item("End_Date") = newEffectDate.AddDays(-1)

                    '                '    'TODO
                    '                '    'workOrderDT update
                    '                '    'newOrder insert
                    '                '    'SpecialProcessStatus2
                    '                '    workOrderDT.TableName = "Update"
                    '                '    NewOrderDT.TableName = "Insert"
                    '                '    returnOpeDS.Tables.Add(workOrderDT)
                    '                '    returnOpeDS.Tables.Add(NewOrderDT)
                    '                '    returnOpeDS.DataSetName = SpecialProcessStatus2
                    '                '    Return returnOpeDS
                    '                'Else
                    '                '    Dim deleteOrderDT As DataTable = PubOrderDataTableFactory.getDataTableWithSchema
                    '                '    Dim updateOrderDT As DataTable = PubOrderDataTableFactory.getDataTableWithSchema
                    '                '    '>1 , 3
                    '                '    'SpecialProcessStatus3
                    '                '    ''3.同代碼修改date..EffectDate < systemdate且2 date間有存在record>>是否刪除已存資料? Y>delete, 
                    '                '    '原代碼DC=Y,enddte = 新effectdate-1, insert 1 update old
                    '                '    'ex: new(i); work:1(d),2(d),3(u)
                    '                '    For i As Integer = 0 To (workOrderDT.Rows.Count - 1)
                    '                '        If i = (workOrderDT.Rows.Count - 1) Then
                    '                '            'update
                    '                '            updateOrderDT.Rows.Add(workOrderDT.Rows(i).ItemArray)
                    '                '        Else
                    '                '            'delete
                    '                '            deleteOrderDT.Rows.Add(workOrderDT.Rows(i).ItemArray)
                    '                '        End If
                    '                '    Next

                    '                '    For i As Integer = 0 To (updateOrderDT.Rows.Count - 1)
                    '                '        updateOrderDT.Rows(i).Item("Dc") = "Y"
                    '                '        updateOrderDT.Rows(0).Item("End_Date") = newEffectDate.AddDays(-1)
                    '                '    Next

                    '                '    updateOrderDT.TableName = "Update"
                    '                '    deleteOrderDT.TableName = "Delete"
                    '                '    NewOrderDT.TableName = "Insert"
                    '                '    returnOpeDS.Tables.Add(updateOrderDT)
                    '                '    returnOpeDS.Tables.Add(deleteOrderDT)
                    '                '    returnOpeDS.Tables.Add(NewOrderDT)
                    '                '    returnOpeDS.DataSetName = SpecialProcessStatus3
                    '                '    Return returnOpeDS

                    '                'End If
                    '            Else
                    '                '無舊
                    '                NewOrderDT.TableName = "Insert"
                    '                returnOpeDS.Tables.Add(NewOrderDT)
                    '                returnOpeDS.DataSetName = SpecialProcessStatus1
                    '                Return returnOpeDS
                    '            End If


                    '        ElseIf newEffectDate.ToString("yyyy/MM/dd").CompareTo(SystemDate.ToString("yyyy/MM/dd")) > 0 Then
                    '            '4 SpecialProcessStatus4
                    '            ''4.同代碼修改date..EffectDate > systemdate且2 ,new enddte = old effectdate;dc=Y, 
                    '            'old enddate = new effectdate-1, insert new, update old
                    '            OldOrderDT.Rows(0).Item("End_Date") = newEffectDate.AddDays(-1)
                    '            NewOrderDT.Rows(0).Item("Dc") = "Y"
                    '            NewOrderDT.Rows(0).Item("End_Date") = "9999/12/31"

                    '            Dim deleteOrderDT As DataTable = PubOrderDataTableFactory.getDataTableWithSchema
                    '            For i As Integer = 0 To (OrderDT.Rows.Count - 1)
                    '                If CType(OrderDT.Rows(i).Item("Effect_Date"), Date).ToString("yyyy/MM/dd").CompareTo(SystemDate.ToString("yyyy/MM/dd")) >= 0 Then
                    '                    deleteOrderDT.Rows.Add(OrderDT.Rows(i).ItemArray)
                    '                End If
                    '            Next

                    '            OldOrderDT.TableName = "Update"
                    '            NewOrderDT.TableName = "Unsert"

                    '            returnOpeDS.Tables.Add(OldOrderDT)
                    '            returnOpeDS.Tables.Add(NewOrderDT)
                    '            If DataSetUtil.IsContainsData(deleteOrderDT) Then
                    '                deleteOrderDT.TableName = "Delete"
                    '                returnOpeDS.Tables.Add(deleteOrderDT)
                    '            End If

                    '            returnOpeDS.DataSetName = SpecialProcessStatus4
                    '            Return returnOpeDS
                    '        End If


                    '    Else
                    '        '查無資料..新增
                    '        NewOrderDT.TableName = "Insert"
                    '        returnOpeDS.Tables.Add(NewOrderDT)
                    '        returnOpeDS.DataSetName = SpecialProcessStatus1
                    '        Return returnOpeDS
                    '    End If


                    'End If
                Else
                    'pk不相同(被改過)....newㄧ個 SpecialProcessStatus1

                    Dim OrderDS As DataSet = PUBOrderBO_E1.getInstance.queryByPK(newEffectDate, newOrderCode)

                    If DataSetUtil.IsContainsData(OrderDS) Then
                        Return checkProcessStatus(OrderDS.Tables(0).Copy, NewOrderDT)
                    Else
                        NewOrderDT.TableName = "Insert"
                        returnOpeDS.Tables.Add(NewOrderDT)
                        returnOpeDS.DataSetName = SpecialProcessStatus1
                        Return returnOpeDS
                    End If

                End If

            Else
                '有舊無新
                Return Nothing
            End If
        Else
            If DataSetUtil.IsContainsData(NewOrderDT) Then
                NewOrderDT.TableName = "Insert"
                returnOpeDS.Tables.Add(NewOrderDT)
                returnOpeDS.DataSetName = SpecialProcessStatus1
                Return returnOpeDS
            Else
                Return Nothing
            End If
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' 確認醫令相關資料
    ''' </summary>
    ''' <param name="OrderRelatedData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function commitOrderRelatedData(ByVal OrderRelatedData As DataSet) As Integer
        'Order Order_Price nhi majorcare Add
        '醫令
        '......

        '綁交易

        '總結(order, curecontrol, majorcare, orderprice, addorderprice)
        'emgupdate,insert; kidupdate,insert; dentalupdate,insert; holidayupdate,insert

        Dim orderCode As String = ""
        Dim pvtReturnValue As Integer

        Dim OrderBO As PUBOrderBO_E1 = PUBOrderBO_E1.getInstance
        Dim OrderPriceBO As PUBOrderPriceBO_E1 = PUBOrderPriceBO_E1.getInstance
        Dim OrderMajorcareBO As PUBOrderMajorcareBO_E1 = PUBOrderMajorcareBO_E1.getInstance
        Dim CureControlBO As PUBCureControlBO_E1 = PUBCureControlBO_E1.getInstance
        Dim OrderExaminationBO As PUBOrderExaminationBO_E1 = PUBOrderExaminationBO_E1.getInstance

        Dim ExcludeBO As PUBExcludeDrugSetBO_E1 = PUBExcludeDrugSetBO_E1.getInstance
        Dim NhiIndexBO As PUBNhiIndexSetBO_E1 = PUBNhiIndexSetBO_E1.getInstance

        Dim EmgAddBO As PUBEmgAddBO_E1 = PUBEmgAddBO_E1.getInstance
        Dim KidAddBO As PUBKidAddBO_E1 = PUBKidAddBO_E1.getInstance

        Dim DentalAddBO As PUBDentalAddBO_E1 = PUBDentalAddBO_E1.getInstance
        Dim DeptAddBO As PUBDeptAddBO_E1 = PUBDeptAddBO_E1.getInstance
        'Dim HolidayAddBO As PUBHolidayAddBO_E1 = PUBHolidayAddBO_E1.getInstance

        Dim AddOrderBO As PUBAddOrderBO_E1 = PUBAddOrderBO_E1.getInstance
        Dim AddOrderDtlBO As PUBAddOrderDetailBO_E1 = PUBAddOrderDetailBO_E1.getInstance
        Dim AddOptionOrderBO As PUBAddOptionOrderBO_E1 = PUBAddOptionOrderBO_E1.getInstance
        Dim CallPRIReviewOrderBO As PUBDelegate = PUBDelegate.getInstance

        Dim OrderMajorcareDT As DataTable = PubOrderMajorcareDataTableFactory.getDataTableWithSchema
        Dim CureControlDT As DataTable = PubCureControlDataTableFactory.getDataTableWithSchema

        Dim OrderExaminationDT As DataTable = PubOrderExaminationDataTableFactory.getDataTableWithNoPK

        Dim OrderOrTreatDT As DataTable = PubOrderOrTreatDataTableFactory.getDataTableWithSchema


        Dim exeresult As Integer = -1
        Dim nextFlag As Boolean = True

        '-----------------------------------------------------------------------------------------------------------
        '補充與判斷資料:
        '-----------------------------------------------------------------------------------------------------------

        '-----------------------------------------------------------------------------------------------------------
        '先處理'curecontrol, majorcare,
        '-----------------------------------------------------------------------------------------------------------
        If OrderRelatedData.Tables.Contains("majorcare") Then

            Dim majorcaredr As DataRow = OrderMajorcareDT.NewRow
            majorcaredr.Item("Order_Code") = OrderRelatedData.Tables("majorcare").Rows(0).Item("Order_Code")
            majorcaredr.Item("Majorcare_Code") = OrderRelatedData.Tables("majorcare").Rows(0).Item("Majorcare_Code")

            OrderMajorcareDT.Rows.Add(majorcaredr)

            If CType(OrderRelatedData.Tables("majorcare").Rows(0).Item("Mode"), String).Trim.Equals("Insert") Then
                OrderMajorcareDT.TableName = "Insert"
            ElseIf CType(OrderRelatedData.Tables("majorcare").Rows(0).Item("Mode"), String).Trim.Equals("Delete") Then
                OrderMajorcareDT.TableName = "Delete"
            End If

        End If

        If OrderRelatedData.Tables.Contains("curecontrol") Then
            Dim curecontroldr As DataRow = CureControlDT.NewRow

            curecontroldr.Item("Cure_Type_Id") = OrderRelatedData.Tables("curecontrol").Rows(0).Item("Cure_Type_Id")
            curecontroldr.Item("Time_Control_Id") = OrderRelatedData.Tables("curecontrol").Rows(0).Item("Time_Control_Id")
            curecontroldr.Item("Control_Value") = OrderRelatedData.Tables("curecontrol").Rows(0).Item("Control_Value")
            curecontroldr.Item("Max_Cnt") = OrderRelatedData.Tables("curecontrol").Rows(0).Item("Max_Cnt")
            curecontroldr.Item("Is_Reg_Fee") = OrderRelatedData.Tables("curecontrol").Rows(0).Item("Is_Reg_Fee")
            curecontroldr.Item("Is_Fee_Check") = OrderRelatedData.Tables("curecontrol").Rows(0).Item("Is_Fee_Check")

            CureControlDT.Rows.Add(curecontroldr)

            If DataSetUtil.IsContainsData(CureControlBO.queryByPK(CType(OrderRelatedData.Tables("curecontrol").Rows(0).Item("Cure_Type_Id"), String).Trim)) Then
                CureControlDT.TableName = "Update"
            Else
                CureControlDT.TableName = "Insert"
            End If
        End If

        '-----------------------------------------------------------------------------------------------------------
        '檢驗查
        '-----------------------------------------------------------------------------------------------------------

        If OrderRelatedData.Tables.Contains("updateorderexamination") Then
            OrderExaminationDT.Rows.Add(OrderRelatedData.Tables("updateorderexamination").Rows(0).ItemArray)
            OrderExaminationDT.TableName = "Update"
        ElseIf OrderRelatedData.Tables.Contains("insertorderexamination") Then
            OrderExaminationDT.Rows.Add(OrderRelatedData.Tables("insertorderexamination").Rows(0).ItemArray)
            OrderExaminationDT.TableName = "Insert"
        End If

        '-----------------------------------------------------------------------------------------------------------
        '手術處置;將沒在畫面上的欄位補入
        '-----------------------------------------------------------------------------------------------------------
        Dim insertOrderOrTreatFlag As Boolean = True
        If OrderRelatedData.Tables.Contains(PubOrderOrTreatDataTableFactory.tableName) Then
            OrderOrTreatDT.Rows.Add(OrderRelatedData.Tables(PubOrderOrTreatDataTableFactory.tableName).Rows(0).ItemArray)

            Dim dbOrderOrTreatDT As DataTable = PUBOrderOrTreatBO_E1.getInstance.queryByOrderCode(CType(OrderOrTreatDT.Rows(0).Item("Order_Code"), String).Trim)

            If DataSetUtil.IsContainsData(dbOrderOrTreatDT) Then
                insertOrderOrTreatFlag = False
                OrderOrTreatDT.Rows(0).Item("Default_Body_Site_Code") = dbOrderOrTreatDT.Rows(0).Item("Default_Body_Site_Code")
                OrderOrTreatDT.Rows(0).Item("Default_Side_Id") = dbOrderOrTreatDT.Rows(0).Item("Default_Side_Id")
            End If

        End If


        '開始交易
        Dim scope As TransactionScope = Nothing
        '  scope = SQLConnFactory.getInstance.getRequiredTransactionScope()

        Try

            If OrderRelatedData.Tables.Contains("deleteorder") Then
                Dim OrderDT As DataTable = OrderRelatedData.Tables("deleteorder")
                If DataSetUtil.IsContainsData(OrderDT) Then
                    Try
                        For i As Integer = 0 To (OrderDT.Rows.Count - 1)
                            exeresult = OrderBO.delete(CType(OrderDT.Rows(i).Item("Effect_Date"), Date), CType(OrderDT.Rows(i).Item("Order_Code"), String).Trim)
                            If Not (exeresult = 1) Then
                                nextFlag = False
                            End If
                        Next
                    Catch ex As Exception
                        nextFlag = False
                    End Try
                End If
            End If

            If nextFlag AndAlso OrderRelatedData.Tables.Contains("updateorder") Then
                Dim OrderDT As DataTable = OrderRelatedData.Tables("updateorder").Copy
                OrderDT.TableName = PubOrderDataTableFactory.tableName
                orderCode = CType(OrderDT.Rows(0).Item("Order_Code"), String).Trim

                Dim pvtOrderData As New DataTable
                Dim pvtEffectDate As Date
                Dim pvtIsPriorReview As String
                'Dim pvtBrand As String
                Dim pvtOrderTypeID As String
                Dim pvtOldEffectDate As Date
                Dim pvtOldEndDate As Date
                Dim pvtOldIsPriorReview As String
                'Dim pvtUpdateEndDate As String
                Dim pvtDcFlag As String = "Y"
                Dim pvtInsertFlag As Boolean = False
                Dim pvtEffectDS As New DataSet
                Dim OrderDS As New DataSet



                OrderDS.Tables.Add(OrderDT)

                Try
                    pvtEffectDate = CType(OrderDT.Rows(0).Item("Effect_Date"), Date)
                    pvtIsPriorReview = OrderDT.Rows(0).Item("Is_Prior_Review").ToString.Trim

                    pvtOrderTypeID = OrderDT.Rows(0).Item("Order_Type_Id").ToString.Trim

                    '抓Pub_Order裡的舊資料(pvtEffectDate的查詢條件已移除)
                    pvtOrderData = OrderBO.queryOrderData(orderCode, pvtEffectDate)

                    pvtOldEffectDate = CType(pvtOrderData.Rows(0).Item("Effect_Date"), Date)
                    pvtOldEndDate = CType(pvtOrderData.Rows(0).Item("End_Date"), Date)
                    pvtOldIsPriorReview = pvtOrderData.Rows(0).Item("Is_Prior_Review").ToString.Trim

                    '*******************************************************************************************************************************
                    'Pub_Order儲存處理
                    '*******************************************************************************************************************************

                    Dim NewOrderDS As New DataSet
                    NewOrderDS.Tables.Add(OrderRelatedData.Tables("updateorder").Copy)

                    '先刪除資料庫中的所有資料
                    If pvtOrderData IsNot Nothing AndAlso pvtOrderData IsNot Nothing AndAlso pvtOrderData.Rows.Count > 0 Then
                        exeresult = OrderBO.delete(pvtOldEffectDate, orderCode)
                    End If

                    '取得PUB_Order_Price所有資料
                    Dim ds_AllPubOrderPrice As DataSet = OrderPriceBO.queryEffectdayAndEndday(orderCode, "")
                    '最小生效日
                    Dim str_OldEffectday As Date = CType(ds_AllPubOrderPrice.Tables(0).Rows(0).Item("Effect_Date"), Date)
                    '最大到期日
                    Dim str_OldEndday As Date = CType(ds_AllPubOrderPrice.Tables(1).Rows(0).Item("End_Date"), Date)

                    If pvtEffectDate < str_OldEffectday Then   '若新增的生效日小於舊有的最小生效日
                        NewOrderDS.Tables(0).Rows(0).Item("Effect_Date") = pvtEffectDate.ToShortDateString

                    Else   '若新增的生效日大於等於舊有的最小生效日
                        NewOrderDS.Tables(0).Rows(0).Item("Effect_Date") = str_OldEffectday.ToShortDateString
                    End If

                    '若新增的到期日處理
                    NewOrderDS.Tables(0).Rows(0).Item("End_Date") = OrderRelatedData.Tables("updateorder").Rows(0).Item("End_Date")

                    '判斷DC
                    If CType(NewOrderDS.Tables(0).Rows(0).Item("Effect_Date"), Date) <= CDate(Now.ToString("yyyy/MM/dd")) And CDate(Now.ToString("yyyy/MM/dd")) < CType(NewOrderDS.Tables(0).Rows(0).Item("End_Date"), Date) Then
                        NewOrderDS.Tables(0).Rows(0).Item("Dc") = "N"
                    Else
                        NewOrderDS.Tables(0).Rows(0).Item("Dc") = "Y"
                    End If

                    '重新新增資料
                    If nextFlag Then
                        exeresult = OrderBO.insert(NewOrderDS)
                    End If

                    '*******************************************************************************************************************************



                    '2010-05-14 Add By Alan
                    '事前審查註記若有異動，則呼叫PRI API--->1.20-UpdateReviewOrder (更新前審查項目基本資料)
                    If pvtIsPriorReview <> pvtOldIsPriorReview Then
                        Dim pvtAPIData As New DataSet
                        Dim columnName() As String = {"Order_Code", "Order_Type_Id", "Brand", "Dc", "Modified_User", "Modified_Time"}

                        pvtAPIData.Tables.Add("PRIAPIDs")
                        For i As Integer = 0 To columnName.Length - 1
                            pvtAPIData.Tables(0).Columns.Add(columnName(i))
                        Next

                        Dim row1 As DataRow = pvtAPIData.Tables(0).Rows.Add()
                        row1("Order_Code") = OrderDT.Rows(0).Item("Order_Code").ToString.Trim
                        row1("Order_Type_Id") = OrderDT.Rows(0).Item("Order_Type_Id").ToString.Trim
                        'row1("Brand") = OrderDT.Rows(0).Item("Brand").ToString.Trim

                        '若醫令類別為藥品，則需另外取得廠牌
                        If OrderDT.Rows(0).Item("Order_Type_Id").ToString.Trim = "E" Then
                            Dim pvtDrugBrand As New DataSet
                            pvtDrugBrand = OrderBO.queryOrderBrand(OrderDT.Rows(0).Item("Order_Code").ToString.Trim)

                        End If

                        If pvtIsPriorReview = "Y" Then
                            row1("Dc") = "N"
                        Else
                            row1("Dc") = "Y"
                        End If

                        row1("Modified_User") = OrderDT.Rows(0).Item("Create_User").ToString.Trim
                        row1("Modified_Time") = DateTime.Now.ToString("yyyy/MM/dd") & " " & DateTime.Now.ToString("HH:mm:ss")

                        If CallPRIReviewOrderBO.UpdateReviewOrder(pvtAPIData) <> 0 Then
                            '  nextFlag = False
                        End If

                    End If

                    If Not (exeresult = OrderDT.Rows.Count) Then
                        nextFlag = False
                    End If
                Catch ex As Exception
                    nextFlag = False
                End Try
            End If

            If nextFlag AndAlso OrderRelatedData.Tables.Contains("insertorder") Then
                '無更新醫令 看新增
                Dim OrderDT As DataTable = OrderRelatedData.Tables("insertorder").Copy
                OrderDT.TableName = PubOrderDataTableFactory.tableName

                orderCode = CType(OrderDT.Rows(0).Item("Order_Code"), String).Trim

                Dim pvtOrderData As New DataTable
                Dim pvtEffectDate As Date
                Dim OrderDS As New DataSet

                OrderDS.Tables.Add(OrderDT)

                Try
                    pvtEffectDate = CType(OrderDT.Rows(0).Item("Effect_Date"), Date)


                    If nextFlag Then
                        If DateDiff(DateInterval.Day, CDate(Now.ToString("yyyy/MM/dd")), pvtEffectDate) > 0 Then
                            OrderDS.Tables(0).Rows(0).Item("Dc") = "Y"
                        End If
                        '若新增的起始日期已存在資料庫且DC='Y'，則先刪除後再新增
                        exeresult = OrderBO.DeletePUBOrderByEffectDateAndDc(pvtEffectDate, orderCode, "Y")
                        exeresult = OrderBO.insert(OrderDS)


                        If Not (exeresult = OrderDT.Rows.Count) Then
                            nextFlag = False
                        End If
                    End If

                    '2010-05-14 Add By Alan
                    '事前審查註記若有異動，則呼叫PRI API--->1.20-UpdateReviewOrder (更新前審查項目基本資料)
                    If nextFlag AndAlso OrderDT.Rows(0).Item("Is_Prior_Review").ToString.Trim = "Y" Then
                        Dim pvtAPIData As New DataSet
                        Dim columnName() As String = {"Order_Code", "Order_Type_Id", "Brand", "Dc", "Modified_User", "Modified_Time"}

                        pvtAPIData.Tables.Add("PRIAPIDs")
                        For i As Integer = 0 To columnName.Length - 1
                            pvtAPIData.Tables(0).Columns.Add(columnName(i))
                        Next

                        Dim row1 As DataRow = pvtAPIData.Tables(0).Rows.Add()
                        row1("Order_Code") = OrderDT.Rows(0).Item("Order_Code").ToString.Trim
                        row1("Order_Type_Id") = OrderDT.Rows(0).Item("Order_Type_Id").ToString.Trim
                        row1("Brand") = OrderDT.Rows(0).Item("Brand").ToString.Trim
                        '若醫令類別為藥品，則需另外取得廠牌
                        If OrderDT.Rows(0).Item("Order_Type_Id").ToString.Trim = "E" Then
                            Dim pvtDrugBrand As New DataSet
                            pvtDrugBrand = OrderBO.queryOrderBrand(OrderDT.Rows(0).Item("Order_Code").ToString.Trim)
                            If pvtDrugBrand IsNot Nothing AndAlso pvtDrugBrand.Tables IsNot Nothing AndAlso pvtDrugBrand.Tables(0).Rows.Count > 0 Then
                                row1("Brand") = pvtDrugBrand.Tables(0).Rows(0).Item("Code_Name")
                            Else
                                row1("Brand") = ""
                            End If

                        End If
                        row1("Dc") = "N"
                        row1("Modified_User") = OrderDT.Rows(0).Item("Create_User").ToString.Trim
                        row1("Modified_Time") = DateTime.Now.ToString("yyyy/MM/dd") & " " & DateTime.Now.ToString("HH:mm:ss")
                        'modify by 唐子晴2014.02.25--------------------------------------
                        ''If CallPRIReviewOrderBO.UpdateReviewOrder(pvtAPIData) = 0 Then
                        If CallPRIReviewOrderBO.UpdateReviewOrder(pvtAPIData) <> 0 Then
                            nextFlag = False
                        End If
                    End If

                Catch ex As Exception
                    nextFlag = False
                End Try
                '
            End If



            If nextFlag AndAlso DataSetUtil.IsContainsData(CureControlDT) Then
                Dim CureControlDS As New DataSet
                If CureControlDT.TableName.Equals("Insert") Then
                    CureControlDT.TableName = PubCureControlDataTableFactory.tableName
                    CureControlDS.Tables.Add(CureControlDT)

                    Try
                        exeresult = CureControlBO.insert(CureControlDS)
                        If Not (exeresult = CureControlDT.Rows.Count) Then
                            nextFlag = False
                        End If
                    Catch ex As Exception
                        nextFlag = False
                    End Try
                ElseIf CureControlDT.TableName.Equals("Update") Then
                    CureControlDT.TableName = PubCureControlDataTableFactory.tableName
                    CureControlDS.Tables.Add(CureControlDT)

                    Try
                        exeresult = CureControlBO.update(CureControlDS)
                        If Not (exeresult = CureControlDT.Rows.Count) Then
                            nextFlag = False
                        End If
                    Catch ex As Exception
                        nextFlag = False
                    End Try
                End If
            End If

            'OrderExamination
            If nextFlag AndAlso DataSetUtil.IsContainsData(OrderExaminationDT) Then

                '判斷是要Insert還是update
                Dim TempOrderCode As String = OrderRelatedData.Tables(0).Rows(0).Item("Order_Code").ToString.Trim
                Dim ds_TempOrderExamination As DataSet = OrderExaminationBO.queryByPK(TempOrderCode)

                Dim strOrderExaminationIorU As String = "I"
                If ds_TempOrderExamination IsNot Nothing AndAlso ds_TempOrderExamination.Tables.Count > 0 AndAlso ds_TempOrderExamination.Tables(0).Rows.Count > 0 Then
                    strOrderExaminationIorU = "U"
                End If

                '宣告Treatment_Type_Id變數
                Dim strTreatmentTypeId As String = ""
                For ti = 0 To OrderRelatedData.Tables.Count - 1

                    If OrderRelatedData.Tables(ti).TableName = "insertorder" Then
                        strTreatmentTypeId = OrderRelatedData.Tables("insertorder").Rows(0).Item("Treatment_Type_Id").ToString.Trim

                    ElseIf OrderRelatedData.Tables(ti).TableName = "updateorder" Then
                        strTreatmentTypeId = OrderRelatedData.Tables("updateorder").Rows(0).Item("Treatment_Type_Id").ToString.Trim
                    End If

                Next
               
                Dim OrderExaminationDS As New DataSet
                If strOrderExaminationIorU = "I" Then
                    OrderExaminationDT.TableName = PubOrderExaminationDataTableFactory.tableName
                    OrderExaminationDS.Tables.Add(OrderExaminationDT)

                    Try

                        If strTreatmentTypeId = "3" OrElse strTreatmentTypeId = "4" Then
                            '先執行刪除
                            exeresult = OrderExaminationBO.delete(OrderExaminationDS.Tables(0).Rows(0).Item("Order_Code").ToString.Trim)
                            exeresult = OrderExaminationBO.insert(OrderExaminationDS)
                        End If

                    Catch ex As Exception
                        Throw ex
                    End Try
                ElseIf strOrderExaminationIorU = "U" Then
                    OrderExaminationDT.TableName = PubOrderExaminationDataTableFactory.tableName
                    OrderExaminationDS.Tables.Add(OrderExaminationDT)

                    Try
                       If strTreatmentTypeId = "3" OrElse strTreatmentTypeId = "4" Then
                            exeresult = OrderExaminationBO.update(OrderExaminationDS)
                        Else
                            exeresult = OrderExaminationBO.delete(OrderExaminationDS.Tables(0).Rows(0).Item("Order_Code").ToString.Trim)
                        End If


                        If Not (exeresult = OrderExaminationDT.Rows.Count) Then
                            nextFlag = False
                        End If
                    Catch ex As Exception
                        nextFlag = False
                    End Try
                End If
            End If

            'insertOrderOrTreatFlag
            If nextFlag AndAlso DataSetUtil.IsContainsData(OrderOrTreatDT) Then
                Dim orderOrTrDS As New DataSet
                orderOrTrDS.Tables.Add(OrderOrTreatDT.Copy)

                Try

                    If insertOrderOrTreatFlag Then
                        'insert
                        exeresult = PUBOrderOrTreatBO_E1.getInstance.insert(orderOrTrDS)
                    Else
                        'update
                        exeresult = PUBOrderOrTreatBO_E1.getInstance.update(orderOrTrDS)

                    End If

                    If Not (exeresult = OrderOrTreatDT.Rows.Count) Then
                        nextFlag = False
                    End If
                Catch ex As Exception
                    nextFlag = False
                End Try
            End If

            If nextFlag Then '新增的...檢查資料庫
                If OrderRelatedData.Tables.Contains("insertorderprice") Then

                    Dim OrderPriceDS As New DataSet
                    Dim OrderPriceDT As DataTable = OrderRelatedData.Tables("insertorderprice").Copy
                    OrderPriceDT.TableName = PubOrderPriceDataTableFactory.tableName
                    OrderPriceDS.Tables.Add(OrderPriceDT)

                    Dim pvtOrderPriceData As New DataTable
                    Dim pvtEffectDate As Date
                    Dim pvtMainIdentityId As String
                    Dim pvtOldEffectDate As Date
                    Dim pvtOldEndDate As Date
                    Dim pvtUpdateEndDate As String
                    Dim pvtDcFlag As String = "Y"
                    Dim pvtInsertFlag As Boolean = False

                    '逐筆處理OrderPrice資料
                    For Each pricedr As DataRow In OrderPriceDT.Rows

                        pvtEffectDate = CType(pricedr.Item("Effect_Date"), Date)
                        pvtMainIdentityId = pricedr.Item("Main_Identity_Id").ToString.Trim

                        '取得作用中資料
                        pvtOrderPriceData = OrderPriceBO.queryOrderPriceData("", "", orderCode, pvtMainIdentityId, "N")

                        '以下為存在作用中資料的處理
                        If pvtOrderPriceData IsNot Nothing AndAlso pvtOrderPriceData.Rows.Count > 0 Then
                            pvtOldEffectDate = CType(pvtOrderPriceData.Rows(0).Item("Effect_Date"), Date)
                            pvtOldEndDate = CType(pvtOrderPriceData.Rows(0).Item("End_Date"), Date)

                            '若Effect_Date不變，則執行Update
                            If pvtEffectDate.ToString("yyyy/MM/dd") = pvtOldEffectDate.ToString("yyyy/MM/dd") Then
                                Dim updateOrderPriceDT As DataTable = PubOrderPriceDataTableFactory.getDataTableWithSchema
                                Dim updateOPDS As New DataSet
                                updateOrderPriceDT.Clear()
                                updateOrderPriceDT.Rows.Add(pricedr.ItemArray)
                                updateOPDS.Tables.Add(updateOrderPriceDT)
                                exeresult = OrderPriceBO.update(updateOPDS)

                                '若Effect_Date大於Old_Effect_Date，則queryOrderData更新Old_End_Date=Effect_Date-1

                                'ElseIf DateDiff(DateInterval.Day, pvtOldEffectDate, pvtEffectDate) > 0 Then
                            Else
                                '先刪除大於Effect_Date資料
                                exeresult = OrderPriceBO.DeletePUBOrderPriceByEffectDateAndDc(pvtEffectDate.ToString("yyyy/MM/dd"), orderCode, pvtMainIdentityId)

                                '更新Old_End_Date=Effect_Date-1
                                pvtUpdateEndDate = pvtEffectDate.AddDays(-1).ToString("yyyy/MM/dd")

                                'Old_End_Date大於系統日期，則DC='N'(生效);否則為'Y'(未生效)
                                If DateDiff(DateInterval.Day, DateUtil.getSystemDate, CType(pvtUpdateEndDate, Date)) >= 0 Then
                                    pvtDcFlag = "N"
                                End If

                                '若生效日期小於系統日期，則需重設OldEffectDate
                                If DateDiff(DateInterval.Day, pvtEffectDate, DateUtil.getSystemDate) > 0 Then
                                    Dim pvtMaxOldEffectDate As New DataTable
                                    pvtMaxOldEffectDate = OrderPriceBO.queryOrderPriceData(pvtEffectDate.ToString("yyyy/MM/dd"), "<", orderCode, pvtMainIdentityId, "")
                                    If pvtMaxOldEffectDate IsNot Nothing AndAlso pvtMaxOldEffectDate.Rows.Count > 0 Then
                                        pvtOldEffectDate = pvtMaxOldEffectDate.Rows(0).Item("Effect_Date")
                                    End If
                                End If


                                exeresult = OrderPriceBO.updatePUBOrderPriceEndDateAndDc(pvtOldEffectDate.ToString("yyyy/MM/dd"), _
                                                                                         orderCode, pvtMainIdentityId, pvtUpdateEndDate, _
                                                                                         pvtDcFlag, pricedr.Item("Modified_User").ToString.Trim)

                                '新增Effect_Date資料
                                Dim insertOrderPriceDT As DataTable = PubOrderPriceDataTableFactory.getDataTableWithSchema
                                Dim insertOPDS As New DataSet
                                insertOrderPriceDT.Clear()
                                insertOrderPriceDT.Rows.Add(pricedr.ItemArray)
                                insertOPDS.Tables.Add(insertOrderPriceDT)
                                '若Effect_Date大於系統日期，則設為非生效
                                If pvtDcFlag = "N" Then
                                    insertOPDS.Tables(0).Rows(0).Item("DC") = "Y"
                                End If
                                exeresult = OrderPriceBO.insert(insertOPDS)

                                'Else  '若Effect_Date小於Old_Effect_Date,在此不予考慮此狀況發生

                            End If

                        Else '以下為無作用中資料的處理

                            '取得起始日期大於或等於系統日期的停用資料
                            pvtOrderPriceData = OrderPriceBO.queryOrderPriceData(DateUtil.getSystemDate.ToString("yyyy/MM/dd"), ">=", orderCode, pvtMainIdentityId, "Y")

                            If pvtOrderPriceData IsNot Nothing AndAlso pvtOrderPriceData.Rows.Count > 0 Then

                                pvtOldEffectDate = CType(pvtOrderPriceData.Rows(0).Item("Effect_Date"), Date)
                                pvtOldEndDate = CType(pvtOrderPriceData.Rows(0).Item("End_Date"), Date)

                                '若Effect_Date不變，則執行Update
                                If pvtEffectDate.ToString("yyyy/MM/dd") = pvtOldEffectDate.ToString("yyyy/MM/dd") Then
                                    Dim updateOrderPriceDT As DataTable = PubOrderPriceDataTableFactory.getDataTableWithSchema
                                    Dim updateOPDS As New DataSet
                                    updateOrderPriceDT.Clear()
                                    updateOrderPriceDT.Rows.Add(pricedr.ItemArray)
                                    updateOPDS.Tables.Add(updateOrderPriceDT)
                                    exeresult = OrderPriceBO.update(updateOPDS)

                                    '若Effect_Date大於Old_Effect_Date，則更新Old_End_Date=Effect_Date-1
                                ElseIf DateDiff(DateInterval.Day, pvtOldEffectDate, pvtEffectDate) > 0 Then
                                    '刪除所有起始日期大於系統日期的停用資料
                                    exeresult = OrderPriceBO.DeletePUBOrderPriceByEffectDateAndDc(DateUtil.getSystemDate.ToString("yyyy/MM/dd"), _
                                                                                                  orderCode, pvtMainIdentityId)
                                    '更新Old_End_Date=Effect_Date-1
                                    pvtUpdateEndDate = pvtEffectDate.AddDays(-1).ToString("yyyy/MM/dd")

                                    'Old_End_Date大於系統日期，則DC='N'(生效);否則為'Y'(未生效)
                                    If DateDiff(DateInterval.Day, DateUtil.getSystemDate, CType(pvtUpdateEndDate, Date)) >= 0 Then
                                        pvtDcFlag = "N"
                                    End If

                                    exeresult = OrderPriceBO.updatePUBOrderPriceEndDateAndDc(pvtOldEffectDate.ToString("yyyy/MM/dd"), _
                                                                                             orderCode, pvtMainIdentityId, pvtUpdateEndDate, _
                                                                                             pvtDcFlag, pricedr.Item("Modified_User").ToString.Trim)

                                    '新增Effect_Date資料
                                    Dim insertOrderPriceDT As DataTable = PubOrderPriceDataTableFactory.getDataTableWithSchema
                                    Dim insertOPDS As New DataSet
                                    insertOrderPriceDT.Clear()
                                    insertOrderPriceDT.Rows.Add(pricedr.ItemArray)
                                    insertOPDS.Tables.Add(insertOrderPriceDT)
                                    '若Effect_Date大於系統日期，則設為非生效
                                    'modify by 唐子晴 2014.03.28----------------------
                                    ''If pvtDcFlag = "N" Then
                                    ''    insertOPDS.Tables(0).Rows(0).Item("DC") = "Y"
                                    ''End If
                                    '--------------------------------------------------
                                    exeresult = OrderPriceBO.insert(insertOPDS)

                                Else '若Effect_Date小於Old_Effect_Date,在此不予考慮此狀況發生

                                End If

                            Else    '若查無資料，則直接新增
                                Dim insertOrderPriceDT As DataTable = PubOrderPriceDataTableFactory.getDataTableWithSchema
                                Dim insertOPDS As New DataSet
                                insertOrderPriceDT.Clear()
                                insertOrderPriceDT.Rows.Add(pricedr.ItemArray)
                                insertOPDS.Tables.Add(insertOrderPriceDT)
                                exeresult = OrderPriceBO.insert(insertOPDS)
                            End If

                        End If

                    Next


                End If
                'add by 唐子晴 2014.03.12 -------------------------------------------------------------------
                If OrderRelatedData.Tables.Contains("updateorderprice") Then

                    Dim updateOrderPriceDt As DataTable = PubOrderPriceDataTableFactory.getDataTableWithSchema
                    Dim updateOPDs As New DataSet
                    updateOrderPriceDt.Clear()
                    updateOrderPriceDt = OrderRelatedData.Tables("updateorderprice").Copy
                    updateOPDs.Tables.Add(updateOrderPriceDt)
                    Dim ret As Integer = OrderPriceBO.update(updateOPDs)
                End If
                '----------------------------------------------------------------------------------------------
            Else
                'error
                'nextFlag = False
            End If

            '若為衛材時，則需更新PUB_Material_Selfpay_Apply結束日期
            If nextFlag Then

                Try
                    '取得需Update的資料
                    Dim pvtDs As New DataSet
                    pvtDs = OrderBO.queryDateByOrderCode(orderCode)

                    If pvtDs IsNot Nothing AndAlso pvtDs.Tables IsNot Nothing AndAlso pvtDs.Tables(0).Rows.Count > 0 Then
                        '逐筆更新結束日期
                        For i = 0 To pvtDs.Tables(0).Rows.Count - 1
                            OrderBO.updateEndDateByOrderCode(pvtDs.Tables(0).Rows(i).Item("Order_Code").ToString.Trim, _
                                                             CDate(pvtDs.Tables(0).Rows(i).Item("Effect_Date")).ToString("yyyy/MM/dd"), _
                                                              CDate(pvtDs.Tables(0).Rows(i).Item("End_Date")).ToString("yyyy/MM/dd"))

                        Next
                    End If
                Catch ex As Exception
                    nextFlag = False
                End Try
            Else
                'error
                'nextFlag = False
            End If

            'exclusive
            If nextFlag Then
                If OrderRelatedData.Tables.Contains("exclusive") Then
                    Dim ExclusiveDT As DataTable = OrderRelatedData.Tables("exclusive").Copy
                    ExclusiveDT.TableName = PubExcludeDrugSetDataTableFactory.tableName
                    Dim ExclusiveDS As New DataSet
                    ExclusiveDS.Tables.Add(ExclusiveDT)
                    Try
                        'Dim excluOrderCode As String = CType(ExclusiveDT.Rows(0).Item("Order_Code"), String).Trim
                        exeresult = ExcludeBO.deleteExclusiveDrugSetByOrderCode(orderCode) 'EmgAddBO.update(ExclusiveDS)
                        If exeresult = -1 Then
                            nextFlag = False
                        End If
                    Catch ex As Exception
                        nextFlag = False
                    End Try

                    If nextFlag AndAlso ExclusiveDT IsNot Nothing AndAlso ExclusiveDT.Rows.Count > 0 Then
                        Try
                            exeresult = ExcludeBO.insert(ExclusiveDS)
                            If Not (exeresult = ExclusiveDT.Rows.Count) Then
                                nextFlag = False
                            End If
                        Catch ex As Exception
                            nextFlag = False
                        End Try
                    End If

                End If
            Else
                'error
                'nextFlag = False
            End If


            'exclusive
            If nextFlag Then
                If OrderRelatedData.Tables.Contains("nhiindex") Then
                    Dim NhiIndexDT As DataTable = OrderRelatedData.Tables("nhiindex").Copy
                    NhiIndexDT.TableName = PubNhiIndexSetDataTableFactory.tableName
                    Dim NhiIndexDS As New DataSet
                    NhiIndexDS.Tables.Add(NhiIndexDT)
                    Try
                        Dim nhiOrderCode As String = CType(NhiIndexDT.Rows(0).Item("Order_Code"), String).Trim
                        exeresult = NhiIndexBO.deleteNhiIndexSetByOrderCode(nhiOrderCode)
                        If exeresult = -1 Then
                            nextFlag = False
                        End If
                    Catch ex As Exception
                        nextFlag = False
                    End Try

                    If nextFlag Then
                        Try
                            exeresult = NhiIndexBO.insert(NhiIndexDS)
                            If Not (exeresult = NhiIndexDT.Rows.Count) Then
                                nextFlag = False
                            End If
                        Catch ex As Exception
                            nextFlag = False
                        End Try
                    End If

                End If
            Else
                'error
                'nextFlag = False
            End If

            'EmgAddBO
            If nextFlag Then
                If OrderRelatedData.Tables.Contains("emgupdate") Then
                    Dim EmgAddDT As DataTable = OrderRelatedData.Tables("emgupdate").Copy
                    EmgAddDT.TableName = PubEmgAddDataTableFactory.tableName
                    Dim EmgAddDS As New DataSet
                    EmgAddDS.Tables.Add(EmgAddDT)
                    Try
                        exeresult = EmgAddBO.update(EmgAddDS)
                        If Not (exeresult = EmgAddDT.Rows.Count) Then
                            nextFlag = False
                        End If
                    Catch ex As Exception
                        nextFlag = False
                    End Try
                End If
            Else
                'error
                'nextFlag = False
            End If


            If nextFlag Then

                Dim pvtEmgAddData As New DataTable
                Dim pvtEffectDate As Date
                Dim pvtMainIdentityId As String
                Dim pvtPtFromId As String
                Dim pvtOldEffectDate As Date
                Dim pvtOldEndDate As Date
                Dim pvtUpdateEndDate As String
                Dim pvtDcFlag As String = "Y"

                If OrderRelatedData.Tables.Contains("emginsert") Then

                    Dim EmgAddDT As DataTable = OrderRelatedData.Tables("emginsert").Copy

                    '逐筆處理EmgAdd資料
                    For Each EmgAddrow As DataRow In EmgAddDT.Rows
                        pvtEffectDate = CType(EmgAddrow.Item("Effect_Date"), Date)
                        pvtMainIdentityId = EmgAddrow.Item("Main_Identity_Id").ToString.Trim()
                        pvtPtFromId = EmgAddrow.Item("Pt_From_Id").ToString.Trim()

                        '取得作用中資料
                        pvtEmgAddData = EmgAddBO.queryEmgAddData("", "", orderCode, pvtMainIdentityId, pvtPtFromId, "N")

                        '以下為存在作用中資料的處理
                        If pvtEmgAddData IsNot Nothing AndAlso pvtEmgAddData.Rows.Count > 0 Then
                            pvtOldEffectDate = CType(pvtEmgAddData.Rows(0).Item("Effect_Date"), Date)
                            pvtOldEndDate = CType(pvtEmgAddData.Rows(0).Item("End_Date"), Date)

                            '若Effect_Date不變，則執行Update
                            If pvtEffectDate.ToString("yyyy/MM/dd") = pvtOldEffectDate.ToString("yyyy/MM/dd") Then
                                Dim updateEmgAddDT As DataTable = PubEmgAddDataTableFactory.getDataTableWithSchema
                                Dim updateEmgAddDS As New DataSet
                                updateEmgAddDT.Clear()
                                updateEmgAddDT.Rows.Add(EmgAddrow.ItemArray)
                                updateEmgAddDS.Tables.Add(updateEmgAddDT)
                                exeresult = EmgAddBO.update(updateEmgAddDS)

                                '若Effect_Date大於Old_Effect_Date，則更新Old_End_Date=Effect_Date-1

                                'ElseIf DateDiff(DateInterval.Day, pvtOldEffectDate, pvtEffectDate) > 0 Then
                            Else
                                '先刪除大於Effect_Date資料
                                exeresult = EmgAddBO.DeletePUBEmgAddByEffectDateAndDc(pvtEffectDate.ToString("yyyy/MM/dd"), orderCode, pvtMainIdentityId, pvtPtFromId)

                                '更新Old_End_Date=Effect_Date-1
                                pvtUpdateEndDate = pvtEffectDate.AddDays(-1).ToString("yyyy/MM/dd")

                                'Old_End_Date大於系統日期，則DC='N'(生效);否則為'Y'(未生效)
                                If DateDiff(DateInterval.Day, DateUtil.getSystemDate, CType(pvtUpdateEndDate, Date)) >= 0 Then
                                    pvtDcFlag = "N"
                                End If

                                '若生效日期小於系統日期，則需重設OldEffectDate
                                If DateDiff(DateInterval.Day, pvtEffectDate, DateUtil.getSystemDate) > 0 Then
                                    Dim pvtMaxOldEffectDate As New DataTable
                                    pvtMaxOldEffectDate = EmgAddBO.queryEmgAddData(pvtEffectDate.ToString("yyyy/MM/dd"), "<", orderCode, pvtMainIdentityId, pvtPtFromId, "")
                                    If pvtMaxOldEffectDate IsNot Nothing AndAlso pvtMaxOldEffectDate.Rows.Count > 0 Then
                                        pvtOldEffectDate = pvtMaxOldEffectDate.Rows(0).Item("Effect_Date")
                                    End If
                                End If


                                exeresult = EmgAddBO.updatePUBEmgAddEndDateAndDc(pvtOldEffectDate.ToString("yyyy/MM/dd"), _
                                                                                         orderCode, pvtMainIdentityId, pvtPtFromId, pvtUpdateEndDate, _
                                                                                         pvtDcFlag, EmgAddrow.Item("Create_User").ToString.Trim)

                                '新增Effect_Date資料
                                Dim insertEmgAddDT As DataTable = PubEmgAddDataTableFactory.getDataTableWithSchema
                                Dim insertEmgAddDS As New DataSet
                                insertEmgAddDT.Clear()
                                insertEmgAddDT.Rows.Add(EmgAddrow.ItemArray)
                                insertEmgAddDS.Tables.Add(insertEmgAddDT)
                                '若Effect_Date大於系統日期，則設為非生效
                                If pvtDcFlag = "N" Then
                                    insertEmgAddDS.Tables(0).Rows(0).Item("DC") = "Y"
                                End If
                                exeresult = EmgAddBO.insert(insertEmgAddDS)

                                'Else  '若Effect_Date小於Old_Effect_Date,在此不予考慮此狀況發生

                            End If

                        Else '以下為無作用中資料的處理

                            '取得起始日期大於或等於系統日期的停用資料
                            pvtEmgAddData = EmgAddBO.queryEmgAddData(DateUtil.getSystemDate.ToString("yyyy/MM/dd"), ">=", orderCode, pvtMainIdentityId, pvtPtFromId, "Y")

                            If pvtEmgAddData IsNot Nothing AndAlso pvtEmgAddData.Rows.Count > 0 Then

                                pvtOldEffectDate = CType(pvtEmgAddData.Rows(0).Item("Effect_Date"), Date)
                                pvtOldEndDate = CType(pvtEmgAddData.Rows(0).Item("End_Date"), Date)

                                '若Effect_Date不變，則執行Update
                                If pvtEffectDate.ToString("yyyy/MM/dd") = pvtOldEffectDate.ToString("yyyy/MM/dd") Then
                                    Dim updateEmgAddDT As DataTable = PubEmgAddDataTableFactory.getDataTableWithSchema
                                    Dim updateEmgAddDS As New DataSet
                                    updateEmgAddDT.Clear()
                                    updateEmgAddDT.Rows.Add(EmgAddrow.ItemArray)
                                    updateEmgAddDS.Tables.Add(updateEmgAddDT)
                                    exeresult = EmgAddBO.update(updateEmgAddDS)

                                    '若Effect_Date大於Old_Effect_Date，則更新Old_End_Date=Effect_Date-1
                                ElseIf DateDiff(DateInterval.Day, pvtOldEffectDate, pvtEffectDate) > 0 Then
                                    '刪除所有起始日期大於系統日期的停用資料
                                    exeresult = EmgAddBO.DeletePUBEmgAddByEffectDateAndDc(DateUtil.getSystemDate.ToString("yyyy/MM/dd"), _
                                                                                                  orderCode, pvtMainIdentityId, pvtPtFromId)
                                    '更新Old_End_Date=Effect_Date-1
                                    pvtUpdateEndDate = pvtEffectDate.AddDays(-1).ToString("yyyy/MM/dd")

                                    'Old_End_Date大於系統日期，則DC='N'(生效);否則為'Y'(未生效)
                                    If DateDiff(DateInterval.Day, DateUtil.getSystemDate, CType(pvtUpdateEndDate, Date)) >= 0 Then
                                        pvtDcFlag = "N"
                                    End If

                                    exeresult = EmgAddBO.updatePUBEmgAddEndDateAndDc(pvtOldEffectDate.ToString("yyyy/MM/dd"), _
                                                                                             orderCode, pvtMainIdentityId, pvtPtFromId, pvtUpdateEndDate, _
                                                                                             pvtDcFlag, EmgAddrow.Item("Create_User").ToString.Trim)

                                    '新增Effect_Date資料
                                    Dim insertEmgAddDT As DataTable = PubEmgAddDataTableFactory.getDataTableWithSchema
                                    Dim insertEmgAddDS As New DataSet
                                    insertEmgAddDT.Clear()
                                    insertEmgAddDT.Rows.Add(EmgAddrow.ItemArray)
                                    insertEmgAddDS.Tables.Add(insertEmgAddDT)
                                    '若Effect_Date大於系統日期，則設為非生效
                                    If pvtDcFlag = "N" Then
                                        insertEmgAddDS.Tables(0).Rows(0).Item("DC") = "Y"
                                    End If
                                    exeresult = EmgAddBO.insert(insertEmgAddDS)

                                Else '若Effect_Date小於Old_Effect_Date,在此不予考慮此狀況發生

                                End If

                            Else    '若查無資料，則直接新增
                                Dim insertEmgAddDT As DataTable = PubEmgAddDataTableFactory.getDataTableWithSchema
                                Dim insertEmgAddDS As New DataSet
                                insertEmgAddDT.Clear()
                                insertEmgAddDT.Rows.Add(EmgAddrow.ItemArray)
                                insertEmgAddDS.Tables.Add(insertEmgAddDT)
                                exeresult = EmgAddBO.insert(insertEmgAddDS)
                            End If


                        End If

                    Next

                End If


            Else
                'error
                'nextFlag = False
            End If

            'KidAddBO
            If nextFlag Then
                If OrderRelatedData.Tables.Contains("kidupdate") Then
                    Dim KidAddDT As DataTable = OrderRelatedData.Tables("kidupdate").Copy
                    KidAddDT.TableName = PubKidAddDataTableFactory.tableName
                    Dim KidAddDS As New DataSet
                    KidAddDS.Tables.Add(KidAddDT)
                    Try
                        exeresult = KidAddBO.update(KidAddDS)
                        If Not (exeresult = KidAddDT.Rows.Count) Then
                            nextFlag = False
                        End If
                    Catch ex As Exception
                        nextFlag = False
                    End Try
                End If
            Else
                'error
                'nextFlag = False
            End If

            If nextFlag Then

                Dim pvtKidAddData As New DataTable
                Dim pvtEffectDate As Date
                Dim pvtMainIdentityId As String
                Dim pvtPtFromId As String
                Dim pvtAgeTypeId As String
                Dim pvtAgeStart As String
                Dim pvtOldEffectDate As Date
                Dim pvtOldEndDate As Date
                Dim pvtUpdateEndDate As String
                Dim pvtDcFlag As String = "Y"

                If OrderRelatedData.Tables.Contains("kidinsert") Then

                    Dim KidAddDT As DataTable = OrderRelatedData.Tables("kidinsert").Copy

                    '逐筆處理KidAdd資料
                    For Each KidAddrow As DataRow In KidAddDT.Rows
                        pvtEffectDate = CType(KidAddrow.Item("Effect_Date"), Date)
                        pvtMainIdentityId = KidAddrow.Item("Main_Identity_Id").ToString.Trim()
                        pvtPtFromId = KidAddrow.Item("Pt_From_Id").ToString
                        pvtAgeTypeId = KidAddrow.Item("Age_Type_Id").ToString.Trim()
                        pvtAgeStart = KidAddrow.Item("Age_Start").ToString.Trim()


                        '取得作用中資料
                        pvtKidAddData = KidAddBO.queryKidAddData("", "", orderCode, pvtMainIdentityId, pvtPtFromId, pvtAgeTypeId, pvtAgeStart, "N")

                        '以下為存在作用中資料的處理
                        If pvtKidAddData IsNot Nothing AndAlso pvtKidAddData.Rows.Count > 0 Then
                            pvtOldEffectDate = CType(pvtKidAddData.Rows(0).Item("Effect_Date"), Date)
                            pvtOldEndDate = CType(pvtKidAddData.Rows(0).Item("End_Date"), Date)

                            '若Effect_Date不變，則執行Update
                            If pvtEffectDate.ToString("yyyy/MM/dd") = pvtOldEffectDate.ToString("yyyy/MM/dd") Then
                                Dim updateKidAddDT As DataTable = PubKidAddDataTableFactory.getDataTableWithSchema
                                Dim updateKidAddDS As New DataSet
                                updateKidAddDT.Clear()
                                updateKidAddDT.Rows.Add(KidAddrow.ItemArray)
                                updateKidAddDS.Tables.Add(updateKidAddDT)
                                exeresult = KidAddBO.update(updateKidAddDS)

                                '若Effect_Date大於Old_Effect_Date，則更新Old_End_Date=Effect_Date-1

                                'ElseIf DateDiff(DateInterval.Day, pvtOldEffectDate, pvtEffectDate) > 0 Then
                            Else
                                '先刪除大於Effect_Date資料
                                exeresult = KidAddBO.DeletePUBKidAddByEffectDateAndDc(pvtEffectDate.ToString("yyyy/MM/dd"), orderCode, pvtMainIdentityId, pvtPtFromId, pvtAgeTypeId, pvtAgeStart)

                                '更新Old_End_Date=Effect_Date-1
                                pvtUpdateEndDate = pvtEffectDate.AddDays(-1).ToString("yyyy/MM/dd")

                                'Old_End_Date大於系統日期，則DC='N'(生效);否則為'Y'(未生效)
                                If DateDiff(DateInterval.Day, DateUtil.getSystemDate, CType(pvtUpdateEndDate, Date)) >= 0 Then
                                    pvtDcFlag = "N"
                                End If

                                '若生效日期小於系統日期，則需重設OldEffectDate
                                If DateDiff(DateInterval.Day, pvtEffectDate, DateUtil.getSystemDate) > 0 Then
                                    Dim pvtMaxOldEffectDate As New DataTable
                                    pvtMaxOldEffectDate = KidAddBO.queryKidAddData(pvtEffectDate.ToString("yyyy/MM/dd"), "<", orderCode, pvtMainIdentityId, pvtPtFromId, pvtAgeTypeId, pvtAgeStart, "")
                                    If pvtMaxOldEffectDate IsNot Nothing AndAlso pvtMaxOldEffectDate.Rows.Count > 0 Then
                                        pvtOldEffectDate = pvtMaxOldEffectDate.Rows(0).Item("Effect_Date")
                                    End If
                                End If


                                exeresult = KidAddBO.updatePUBKidAddEndDateAndDc(pvtOldEffectDate.ToString("yyyy/MM/dd"), _
                                                                                         orderCode, pvtMainIdentityId, pvtPtFromId, pvtAgeTypeId, pvtAgeStart, pvtUpdateEndDate, _
                                                                                         pvtDcFlag, KidAddrow.Item("Create_User").ToString.Trim)

                                '新增Effect_Date資料
                                Dim insertKidAddDT As DataTable = PubKidAddDataTableFactory.getDataTableWithSchema
                                Dim insertKidAddDS As New DataSet
                                insertKidAddDT.Clear()
                                insertKidAddDT.Rows.Add(KidAddrow.ItemArray)
                                insertKidAddDS.Tables.Add(insertKidAddDT)
                                '若Effect_Date大於系統日期，則設為非生效
                                If pvtDcFlag = "N" Then
                                    insertKidAddDS.Tables(0).Rows(0).Item("DC") = "Y"
                                End If
                                exeresult = KidAddBO.insert(insertKidAddDS)

                                'Else  '若Effect_Date小於Old_Effect_Date,在此不予考慮此狀況發生

                            End If

                        Else '以下為無作用中資料的處理

                            '取得起始日期大於或等於系統日期的停用資料
                            pvtKidAddData = KidAddBO.queryKidAddData(DateUtil.getSystemDate.ToString("yyyy/MM/dd"), ">=", orderCode, pvtMainIdentityId, pvtPtFromId, pvtAgeTypeId, pvtAgeStart, "Y")

                            If pvtKidAddData IsNot Nothing AndAlso pvtKidAddData.Rows.Count > 0 Then

                                pvtOldEffectDate = CType(pvtKidAddData.Rows(0).Item("Effect_Date"), Date)
                                pvtOldEndDate = CType(pvtKidAddData.Rows(0).Item("End_Date"), Date)

                                '若Effect_Date不變，則執行Update
                                If pvtEffectDate.ToString("yyyy/MM/dd") = pvtOldEffectDate.ToString("yyyy/MM/dd") Then
                                    Dim updateKidAddDT As DataTable = PubKidAddDataTableFactory.getDataTableWithSchema
                                    Dim updateKidAddDS As New DataSet
                                    updateKidAddDT.Clear()
                                    updateKidAddDT.Rows.Add(KidAddrow.ItemArray)
                                    updateKidAddDS.Tables.Add(updateKidAddDT)
                                    exeresult = KidAddBO.update(updateKidAddDS)

                                    '若Effect_Date大於Old_Effect_Date，則更新Old_End_Date=Effect_Date-1
                                ElseIf DateDiff(DateInterval.Day, pvtOldEffectDate, pvtEffectDate) > 0 Then
                                    '刪除所有起始日期大於系統日期的停用資料
                                    exeresult = KidAddBO.DeletePUBKidAddByEffectDateAndDc(DateUtil.getSystemDate.ToString("yyyy/MM/dd"), _
                                                                                                  orderCode, pvtMainIdentityId, pvtPtFromId, pvtAgeTypeId, pvtAgeStart)
                                    '更新Old_End_Date=Effect_Date-1
                                    pvtUpdateEndDate = pvtEffectDate.AddDays(-1).ToString("yyyy/MM/dd")

                                    'Old_End_Date大於系統日期，則DC='N'(生效);否則為'Y'(未生效)
                                    If DateDiff(DateInterval.Day, DateUtil.getSystemDate, CType(pvtUpdateEndDate, Date)) >= 0 Then
                                        pvtDcFlag = "N"
                                    End If

                                    exeresult = KidAddBO.updatePUBKidAddEndDateAndDc(pvtOldEffectDate.ToString("yyyy/MM/dd"), _
                                                                                             orderCode, pvtMainIdentityId, pvtPtFromId, pvtAgeTypeId, pvtAgeStart, pvtUpdateEndDate, _
                                                                                             pvtDcFlag, KidAddrow.Item("Create_User").ToString.Trim)

                                    '新增Effect_Date資料
                                    Dim insertKidAddDT As DataTable = PubKidAddDataTableFactory.getDataTableWithSchema
                                    Dim insertKidAddDS As New DataSet
                                    insertKidAddDT.Clear()
                                    insertKidAddDT.Rows.Add(KidAddrow.ItemArray)
                                    insertKidAddDS.Tables.Add(insertKidAddDT)
                                    '若Effect_Date大於系統日期，則設為非生效
                                    If pvtDcFlag = "N" Then
                                        insertKidAddDS.Tables(0).Rows(0).Item("DC") = "Y"
                                    End If
                                    exeresult = KidAddBO.insert(insertKidAddDS)

                                Else '若Effect_Date小於Old_Effect_Date,在此不予考慮此狀況發生

                                End If

                            Else    '若查無資料，則直接新增
                                Dim insertKidAddDT As DataTable = PubKidAddDataTableFactory.getDataTableWithSchema
                                Dim insertKidAddDS As New DataSet
                                insertKidAddDT.Clear()
                                insertKidAddDT.Rows.Add(KidAddrow.ItemArray)
                                insertKidAddDS.Tables.Add(insertKidAddDT)
                                exeresult = KidAddBO.insert(insertKidAddDS)
                            End If


                        End If

                    Next

                End If

                ''2011-08-25 先刪除後新增
                'exeresult = KidAddBO.delete(orderCode)

                'If OrderRelatedData.Tables.Contains("kidinsert") Then
                '    Dim KidAddDT As DataTable = OrderRelatedData.Tables("kidinsert").Copy
                '    KidAddDT.TableName = PubKidAddDataTableFactory.tableName
                '    Dim KidAddDS As New DataSet
                '    KidAddDS.Tables.Add(KidAddDT)
                '    Try
                '        exeresult = KidAddBO.insert(KidAddDS)
                '        If Not (exeresult = KidAddDT.Rows.Count) Then
                '            nextFlag = False
                '        End If
                '    Catch ex As Exception
                '        nextFlag = False
                '    End Try
                'End If
            Else
                'error
                'nextFlag = False
            End If

            'DentalAddBO
            If nextFlag Then
                If OrderRelatedData.Tables.Contains("dentalupdate") Then
                    Dim DentalAddDT As DataTable = OrderRelatedData.Tables("dentalupdate").Copy
                    DentalAddDT.TableName = PubDentalAddDataTableFactory.tableName
                    Dim DentalAddDS As New DataSet
                    DentalAddDS.Tables.Add(DentalAddDT)
                    Try
                        exeresult = DentalAddBO.update(DentalAddDS)
                        If Not (exeresult = DentalAddDT.Rows.Count) Then
                            nextFlag = False
                        End If
                    Catch ex As Exception
                        nextFlag = False
                    End Try
                End If
            Else
                'error
                'nextFlag = False
            End If

            If nextFlag Then

                Dim pvtDentalAddData As New DataTable
                Dim pvtEffectDate As Date
                Dim pvtMainIdentityId As String
                Dim pvtPtFromId As String
                Dim pvtOldEffectDate As Date
                Dim pvtOldEndDate As Date
                Dim pvtUpdateEndDate As String
                Dim pvtDcFlag As String = "Y"

                If OrderRelatedData.Tables.Contains("dentalinsert") Then

                    Dim DentalAddDT As DataTable = OrderRelatedData.Tables("dentalinsert").Copy

                    '逐筆處理EmgAdd資料
                    For Each DentalAddrow As DataRow In DentalAddDT.Rows
                        pvtEffectDate = CType(DentalAddrow.Item("Effect_Date"), Date)
                        pvtMainIdentityId = DentalAddrow.Item("Main_Identity_Id").ToString.Trim()
                        pvtPtFromId = DentalAddrow.Item("Pt_From_Id").ToString.Trim()

                        '取得作用中資料
                        pvtDentalAddData = DentalAddBO.queryDentalAddData("", "", orderCode, pvtMainIdentityId, pvtPtFromId, "N")

                        '以下為存在作用中資料的處理
                        If pvtDentalAddData IsNot Nothing AndAlso pvtDentalAddData.Rows.Count > 0 Then
                            pvtOldEffectDate = CType(pvtDentalAddData.Rows(0).Item("Effect_Date"), Date)
                            pvtOldEndDate = CType(pvtDentalAddData.Rows(0).Item("End_Date"), Date)

                            '若Effect_Date不變，則執行Update
                            If pvtEffectDate.ToString("yyyy/MM/dd") = pvtOldEffectDate.ToString("yyyy/MM/dd") Then
                                Dim updateDentalAddDT As DataTable = PubDentalAddDataTableFactory.getDataTableWithSchema
                                Dim updateDentalAddDS As New DataSet
                                updateDentalAddDT.Clear()
                                updateDentalAddDT.Rows.Add(DentalAddrow.ItemArray)
                                updateDentalAddDS.Tables.Add(updateDentalAddDT)
                                exeresult = EmgAddBO.update(updateDentalAddDS)

                                '若Effect_Date大於Old_Effect_Date，則更新Old_End_Date=Effect_Date-1

                                'ElseIf DateDiff(DateInterval.Day, pvtOldEffectDate, pvtEffectDate) > 0 Then
                            Else
                                '先刪除大於Effect_Date資料
                                exeresult = DentalAddBO.DeletePUBDentalAddByEffectDateAndDc(pvtEffectDate.ToString("yyyy/MM/dd"), orderCode, pvtMainIdentityId, pvtPtFromId)

                                '更新Old_End_Date=Effect_Date-1
                                pvtUpdateEndDate = pvtEffectDate.AddDays(-1).ToString("yyyy/MM/dd")

                                'Old_End_Date大於系統日期，則DC='N'(生效);否則為'Y'(未生效)
                                If DateDiff(DateInterval.Day, DateUtil.getSystemDate, CType(pvtUpdateEndDate, Date)) >= 0 Then
                                    pvtDcFlag = "N"
                                End If

                                '若生效日期小於系統日期，則需重設OldEffectDate
                                If DateDiff(DateInterval.Day, pvtEffectDate, DateUtil.getSystemDate) > 0 Then
                                    Dim pvtMaxOldEffectDate As New DataTable
                                    pvtMaxOldEffectDate = DentalAddBO.queryDentalAddData(pvtEffectDate.ToString("yyyy/MM/dd"), "<", orderCode, pvtMainIdentityId, pvtPtFromId, "")
                                    If pvtMaxOldEffectDate IsNot Nothing AndAlso pvtMaxOldEffectDate.Rows.Count > 0 Then
                                        pvtOldEffectDate = pvtMaxOldEffectDate.Rows(0).Item("Effect_Date")
                                    End If
                                End If


                                exeresult = DentalAddBO.updatePUBDentalAddEndDateAndDc(pvtOldEffectDate.ToString("yyyy/MM/dd"), _
                                                                                         orderCode, pvtMainIdentityId, pvtPtFromId, pvtUpdateEndDate, _
                                                                                         pvtDcFlag, DentalAddrow.Item("Create_User").ToString.Trim)

                                '新增Effect_Date資料
                                Dim insertDentalAddDT As DataTable = PubDentalAddDataTableFactory.getDataTableWithSchema
                                Dim insertDentalAddDS As New DataSet
                                insertDentalAddDT.Clear()
                                insertDentalAddDT.Rows.Add(DentalAddrow.ItemArray)
                                insertDentalAddDS.Tables.Add(insertDentalAddDT)
                                '若Effect_Date大於系統日期，則設為非生效
                                If pvtDcFlag = "N" Then
                                    insertDentalAddDS.Tables(0).Rows(0).Item("DC") = "Y"
                                End If
                                exeresult = EmgAddBO.insert(insertDentalAddDS)

                                'Else  '若Effect_Date小於Old_Effect_Date,在此不予考慮此狀況發生

                            End If

                        Else '以下為無作用中資料的處理

                            '取得起始日期大於或等於系統日期的停用資料
                            pvtDentalAddData = DentalAddBO.queryDentalAddData(DateUtil.getSystemDate.ToString("yyyy/MM/dd"), ">=", orderCode, pvtMainIdentityId, pvtPtFromId, "Y")

                            If pvtDentalAddData IsNot Nothing AndAlso pvtDentalAddData.Rows.Count > 0 Then

                                pvtOldEffectDate = CType(pvtDentalAddData.Rows(0).Item("Effect_Date"), Date)
                                pvtOldEndDate = CType(pvtDentalAddData.Rows(0).Item("End_Date"), Date)

                                '若Effect_Date不變，則執行Update
                                If pvtEffectDate.ToString("yyyy/MM/dd") = pvtOldEffectDate.ToString("yyyy/MM/dd") Then
                                    Dim updateDentalAddDT As DataTable = PubDentalAddDataTableFactory.getDataTableWithSchema
                                    Dim updateDentalAddDS As New DataSet
                                    updateDentalAddDT.Clear()
                                    updateDentalAddDT.Rows.Add(DentalAddrow.ItemArray)
                                    updateDentalAddDS.Tables.Add(updateDentalAddDT)
                                    exeresult = DentalAddBO.update(updateDentalAddDS)

                                    '若Effect_Date大於Old_Effect_Date，則更新Old_End_Date=Effect_Date-1
                                ElseIf DateDiff(DateInterval.Day, pvtOldEffectDate, pvtEffectDate) > 0 Then
                                    '刪除所有起始日期大於系統日期的停用資料
                                    exeresult = DentalAddBO.DeletePUBDentalAddByEffectDateAndDc(DateUtil.getSystemDate.ToString("yyyy/MM/dd"), _
                                                                                                  orderCode, pvtMainIdentityId, pvtPtFromId)
                                    '更新Old_End_Date=Effect_Date-1
                                    pvtUpdateEndDate = pvtEffectDate.AddDays(-1).ToString("yyyy/MM/dd")

                                    'Old_End_Date大於系統日期，則DC='N'(生效);否則為'Y'(未生效)
                                    If DateDiff(DateInterval.Day, DateUtil.getSystemDate, CType(pvtUpdateEndDate, Date)) >= 0 Then
                                        pvtDcFlag = "N"
                                    End If

                                    exeresult = DentalAddBO.updatePUBDentalAddEndDateAndDc(pvtOldEffectDate.ToString("yyyy/MM/dd"), _
                                                                                             orderCode, pvtMainIdentityId, pvtPtFromId, pvtUpdateEndDate, _
                                                                                             pvtDcFlag, DentalAddrow.Item("Create_User").ToString.Trim)

                                    '新增Effect_Date資料
                                    Dim insertDentalAddDT As DataTable = PubDentalAddDataTableFactory.getDataTableWithSchema
                                    Dim insertDentalAddDS As New DataSet
                                    insertDentalAddDT.Clear()
                                    insertDentalAddDT.Rows.Add(DentalAddrow.ItemArray)
                                    insertDentalAddDS.Tables.Add(insertDentalAddDT)
                                    '若Effect_Date大於系統日期，則設為非生效
                                    If pvtDcFlag = "N" Then
                                        insertDentalAddDS.Tables(0).Rows(0).Item("DC") = "Y"
                                    End If
                                    exeresult = EmgAddBO.insert(insertDentalAddDS)

                                Else '若Effect_Date小於Old_Effect_Date,在此不予考慮此狀況發生

                                End If

                            Else    '若查無資料，則直接新增
                                Dim insertDentalAddDT As DataTable = PubDentalAddDataTableFactory.getDataTableWithSchema
                                Dim insertDentalAddDS As New DataSet
                                insertDentalAddDT.Clear()
                                insertDentalAddDT.Rows.Add(DentalAddrow.ItemArray)
                                insertDentalAddDS.Tables.Add(insertDentalAddDT)
                                exeresult = DentalAddBO.insert(insertDentalAddDS)
                            End If


                        End If

                    Next

                End If

                ''2011-08-25 先刪除後新增
                'exeresult = DentalAddBO.delete(orderCode)

                'If OrderRelatedData.Tables.Contains("dentalinsert") Then
                '    Dim DentalAddDT As DataTable = OrderRelatedData.Tables("dentalinsert").Copy
                '    DentalAddDT.TableName = PubDentalAddDataTableFactory.tableName
                '    Dim DentalAddDS As New DataSet
                '    DentalAddDS.Tables.Add(DentalAddDT)
                '    Try
                '        exeresult = DentalAddBO.insert(DentalAddDS)
                '        If Not (exeresult = DentalAddDT.Rows.Count) Then
                '            nextFlag = False
                '        End If
                '    Catch ex As Exception
                '        nextFlag = False
                '    End Try
                'End If
            Else
                'error
                'nextFlag = False
            End If

            If nextFlag Then
                If OrderRelatedData.Tables.Contains("deptupdate") Then
                    Dim DeptAddDT As DataTable = OrderRelatedData.Tables("deptupdate").Copy
                    DeptAddDT.TableName = PubDeptAddDataTableFactory.tableName
                    Dim DeptAddDS As New DataSet
                    DeptAddDS.Tables.Add(DeptAddDT)
                    Try
                        exeresult = DeptAddBO.update(DeptAddDS)
                        If Not (exeresult = DeptAddDT.Rows.Count) Then
                            nextFlag = False
                        End If
                    Catch ex As Exception
                        nextFlag = False
                    End Try
                End If
            Else
                'error
                'nextFlag = False
            End If

            If nextFlag Then

                Dim pvtDeptAddData As New DataTable
                Dim pvtEffectDate As Date
                Dim pvtMainIdentityId As String
                Dim pvtPtFromId As String
                Dim pvtDeptCode As String
                Dim pvtOldEffectDate As Date
                Dim pvtOldEndDate As Date
                Dim pvtUpdateEndDate As String
                Dim pvtDcFlag As String = "Y"

                If OrderRelatedData.Tables.Contains("deptinsert") Then

                    Dim DeptAddDT As DataTable = OrderRelatedData.Tables("deptinsert").Copy

                    '逐筆處理EmgAdd資料
                    For Each DeptAddrow As DataRow In DeptAddDT.Rows
                        pvtEffectDate = CType(DeptAddrow.Item("Effect_Date"), Date)
                        pvtMainIdentityId = DeptAddrow.Item("Main_Identity_Id").ToString.Trim()
                        pvtPtFromId = DeptAddrow.Item("Pt_From_Id").ToString.Trim()
                        pvtDeptCode = DeptAddrow.Item("Dept_Code").ToString.Trim()

                        '取得作用中資料
                        pvtDeptAddData = DeptAddBO.queryDeptAddData("", "", orderCode, pvtMainIdentityId, pvtPtFromId, pvtDeptCode, "N")

                        '以下為存在作用中資料的處理
                        If pvtDeptAddData IsNot Nothing AndAlso pvtDeptAddData.Rows.Count > 0 Then
                            pvtOldEffectDate = CType(pvtDeptAddData.Rows(0).Item("Effect_Date"), Date)
                            pvtOldEndDate = CType(pvtDeptAddData.Rows(0).Item("End_Date"), Date)

                            '若Effect_Date不變，則執行Update
                            If pvtEffectDate.ToString("yyyy/MM/dd") = pvtOldEffectDate.ToString("yyyy/MM/dd") Then
                                Dim updateDeptAddDT As DataTable = PubDeptAddDataTableFactory.getDataTableWithSchema
                                Dim updateDeptAddDS As New DataSet
                                updateDeptAddDT.Clear()
                                updateDeptAddDT.Rows.Add(DeptAddrow.ItemArray)
                                updateDeptAddDS.Tables.Add(updateDeptAddDT)
                                exeresult = DeptAddBO.update(updateDeptAddDS)

                                '若Effect_Date大於Old_Effect_Date，則更新Old_End_Date=Effect_Date-1

                                'ElseIf DateDiff(DateInterval.Day, pvtOldEffectDate, pvtEffectDate) > 0 Then
                            Else
                                '先刪除大於Effect_Date資料
                                exeresult = DeptAddBO.DeletePUBDeptAddByEffectDateAndDc(pvtEffectDate.ToString("yyyy/MM/dd"), orderCode, pvtMainIdentityId, pvtPtFromId, pvtDeptCode)

                                '更新Old_End_Date=Effect_Date-1
                                pvtUpdateEndDate = pvtEffectDate.AddDays(-1).ToString("yyyy/MM/dd")

                                'Old_End_Date大於系統日期，則DC='N'(生效);否則為'Y'(未生效)
                                If DateDiff(DateInterval.Day, DateUtil.getSystemDate, CType(pvtUpdateEndDate, Date)) >= 0 Then
                                    pvtDcFlag = "N"
                                End If

                                '若生效日期小於系統日期，則需重設OldEffectDate
                                If DateDiff(DateInterval.Day, pvtEffectDate, DateUtil.getSystemDate) > 0 Then
                                    Dim pvtMaxOldEffectDate As New DataTable
                                    pvtMaxOldEffectDate = DeptAddBO.queryDeptAddData(pvtEffectDate.ToString("yyyy/MM/dd"), "<", orderCode, pvtMainIdentityId, pvtPtFromId, pvtDeptCode, "")
                                    If pvtMaxOldEffectDate IsNot Nothing AndAlso pvtMaxOldEffectDate.Rows.Count > 0 Then
                                        pvtOldEffectDate = pvtMaxOldEffectDate.Rows(0).Item("Effect_Date")
                                    End If
                                End If


                                exeresult = DeptAddBO.updatePUBDeptAddEndDateAndDc(pvtOldEffectDate.ToString("yyyy/MM/dd"), _
                                                                                         orderCode, pvtMainIdentityId, pvtPtFromId, pvtDeptCode, pvtUpdateEndDate, _
                                                                                         pvtDcFlag, DeptAddrow.Item("Create_User").ToString.Trim)

                                '新增Effect_Date資料
                                Dim insertDeptAddDT As DataTable = PubDeptAddDataTableFactory.getDataTableWithSchema
                                Dim insertDeptAddDS As New DataSet
                                insertDeptAddDT.Clear()
                                insertDeptAddDT.Rows.Add(DeptAddrow.ItemArray)
                                insertDeptAddDS.Tables.Add(insertDeptAddDT)
                                '若Effect_Date大於系統日期，insertDeptAddDT
                                If pvtDcFlag = "N" Then
                                    insertDeptAddDS.Tables(0).Rows(0).Item("DC") = "Y"
                                End If
                                exeresult = DeptAddBO.insert(insertDeptAddDS)

                                'Else  '若Effect_Date小於Old_Effect_Date,在此不予考慮此狀況發生

                            End If

                        Else '以下為無作用中資料的處理

                            '取得起始日期大於或等於系統日期的停用資料
                            pvtDeptAddData = DeptAddBO.queryDeptAddData(DateUtil.getSystemDate.ToString("yyyy/MM/dd"), ">=", orderCode, pvtMainIdentityId, pvtPtFromId, pvtDeptCode, "Y")

                            If pvtDeptAddData IsNot Nothing AndAlso pvtDeptAddData.Rows.Count > 0 Then

                                pvtOldEffectDate = CType(pvtDeptAddData.Rows(0).Item("Effect_Date"), Date)
                                pvtOldEndDate = CType(pvtDeptAddData.Rows(0).Item("End_Date"), Date)

                                '若Effect_Date不變，則執行Update
                                If pvtEffectDate.ToString("yyyy/MM/dd") = pvtOldEffectDate.ToString("yyyy/MM/dd") Then
                                    Dim updateDeptAddDT As DataTable = PubDeptAddDataTableFactory.getDataTableWithSchema
                                    Dim updateDeptAddDS As New DataSet
                                    updateDeptAddDT.Clear()
                                    updateDeptAddDT.Rows.Add(DeptAddrow.ItemArray)
                                    updateDeptAddDS.Tables.Add(updateDeptAddDT)
                                    exeresult = DeptAddBO.update(updateDeptAddDS)

                                    '若Effect_Date大於Old_Effect_Date，則更新Old_End_Date=Effect_Date-1
                                ElseIf DateDiff(DateInterval.Day, pvtOldEffectDate, pvtEffectDate) > 0 Then
                                    '刪除所有起始日期大於系統日期的停用資料
                                    exeresult = DeptAddBO.DeletePUBDeptAddByEffectDateAndDc(DateUtil.getSystemDate.ToString("yyyy/MM/dd"), _
                                                                                                  orderCode, pvtMainIdentityId, pvtPtFromId, pvtDeptCode)
                                    '更新Old_End_Date=Effect_Date-1
                                    pvtUpdateEndDate = pvtEffectDate.AddDays(-1).ToString("yyyy/MM/dd")

                                    'Old_End_Date大於系統日期，則DC='N'(生效);否則為'Y'(未生效)
                                    If DateDiff(DateInterval.Day, DateUtil.getSystemDate, CType(pvtUpdateEndDate, Date)) >= 0 Then
                                        pvtDcFlag = "N"
                                    End If

                                    exeresult = DeptAddBO.updatePUBDeptAddEndDateAndDc(pvtOldEffectDate.ToString("yyyy/MM/dd"), _
                                                                                             orderCode, pvtMainIdentityId, pvtPtFromId, pvtDeptCode, pvtUpdateEndDate, _
                                                                                             pvtDcFlag, DeptAddrow.Item("Create_User").ToString.Trim)

                                    '新增Effect_Date資料
                                    Dim insertDeptAddDT As DataTable = PubDeptAddDataTableFactory.getDataTableWithSchema
                                    Dim insertDeptAddDS As New DataSet
                                    insertDeptAddDT.Clear()
                                    insertDeptAddDT.Rows.Add(DeptAddrow.ItemArray)
                                    insertDeptAddDS.Tables.Add(insertDeptAddDT)
                                    '若Effect_Date大於系統日期，則設為非生效
                                    If pvtDcFlag = "N" Then
                                        insertDeptAddDS.Tables(0).Rows(0).Item("DC") = "Y"
                                    End If
                                    exeresult = DeptAddBO.insert(insertDeptAddDS)

                                Else '若Effect_Date小於Old_Effect_Date,在此不予考慮此狀況發生

                                End If

                            Else    '若查無資料，則直接新增
                                Dim insertDeptAddDT As DataTable = PubDeptAddDataTableFactory.getDataTableWithSchema
                                Dim insertDeptAddDS As New DataSet
                                insertDeptAddDT.Clear()
                                insertDeptAddDT.Rows.Add(DeptAddrow.ItemArray)
                                insertDeptAddDS.Tables.Add(insertDeptAddDT)
                                exeresult = DeptAddBO.insert(insertDeptAddDS)
                            End If


                        End If

                    Next

                End If

            Else
                'error
                'nextFlag = False
            End If

            '------------------------------------------
            '群組醫令

            If nextFlag Then

                '群組醫令, 查詢db是否有已存在...(刪掉??)
                'PubAddOrder
                '    Add_Order_Code
                'PubAddOrderDetail
                '    Add_Order_Code, Add_Order_Detail_No
                'PubAddOptionOrder
                '    Add_Order_Code, Add_Order_Detail_No, Option_Order_Code
                If OrderRelatedData.Tables.Contains(PubAddOrderDataTableFactory.tableName) Then
                    Dim AddOrderCode As String = CType(OrderRelatedData.Tables(PubAddOrderDataTableFactory.tableName).Rows(0).Item("Add_Order_Code"), String).Trim
                    AddOrderBO.deleteByAddOrderCode(AddOrderCode)
                    If OrderRelatedData.Tables.Contains(PubAddOrderDetailDataTableFactory.tableName) Then
                        AddOrderDtlBO.deleteByAddOrderCode(AddOrderCode)
                    End If
                    If OrderRelatedData.Tables.Contains(PubAddOptionOrderDataTableFactory.tableName) Then
                        AddOptionOrderBO.deleteByAddOrderCode(AddOrderCode)
                    End If
                End If

                If OrderRelatedData.Tables.Contains(PubAddOrderDataTableFactory.tableName) Then
                    Dim AddOrderDT As DataTable = OrderRelatedData.Tables(PubAddOrderDataTableFactory.tableName).Copy
                    Dim AddOrderDS As New DataSet
                    AddOrderDS.Tables.Add(AddOrderDT)
                    Try
                        exeresult = AddOrderBO.insert(AddOrderDS)
                        If Not (exeresult = AddOrderDT.Rows.Count) Then
                            nextFlag = False
                        End If

                        'detail層
                        If nextFlag Then
                            If OrderRelatedData.Tables.Contains(PubAddOrderDetailDataTableFactory.tableName) Then
                                Dim AddOrderDtlDT As DataTable = OrderRelatedData.Tables(PubAddOrderDetailDataTableFactory.tableName).Copy
                                Dim AddOrderDtlDS As New DataSet
                                AddOrderDtlDS.Tables.Add(AddOrderDtlDT)
                                Try
                                    exeresult = AddOrderDtlBO.insert(AddOrderDtlDS)
                                    If Not (exeresult = AddOrderDtlDT.Rows.Count) Then
                                        nextFlag = False
                                    End If
                                Catch ex As Exception
                                    nextFlag = False
                                End Try
                            End If
                        Else
                            'error
                            'nextFlag = False
                        End If

                        If nextFlag Then
                            If OrderRelatedData.Tables.Contains(PubAddOptionOrderDataTableFactory.tableName) Then
                                Dim AddOptionOrderDT As DataTable = OrderRelatedData.Tables(PubAddOptionOrderDataTableFactory.tableName).Copy
                                Dim AddOptionOrderDS As New DataSet
                                AddOptionOrderDS.Tables.Add(AddOptionOrderDT)
                                Try
                                    exeresult = AddOptionOrderBO.insert(AddOptionOrderDS)
                                    If Not (exeresult = AddOptionOrderDT.Rows.Count) Then
                                        nextFlag = False
                                    End If
                                Catch ex As Exception
                                    nextFlag = False
                                End Try
                            End If
                        Else
                            'error
                            'nextFlag = False
                        End If

                    Catch ex As Exception
                        nextFlag = False
                    End Try
                End If
            Else
                'error
                'nextFlag = False
            End If



            '------------------------------------------

            If nextFlag Then

                '   scope.Complete()
            Else
                ' scope.Dispose()
            End If


        Catch cmex As CommonException
            Throw cmex

        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        Finally
            Try
                ' If scope IsNot Nothing Then scope.Dispose()
            Catch ex As Exception
                Throw ex
            End Try
        End Try

        If pvtReturnValue <> 0 Then
            Return pvtReturnValue
        End If

        If nextFlag Then
            exeresult = OrderBO.UpdatePUBOrderEffectDateByOrderCode(orderCode)
            Return 1
        Else
            Return -1
        End If


    End Function



    ''' <summary>
    ''' 檢查開始值(區間)與比較值(區間)是否重疊
    ''' </summary>
    ''' <param name="startPeriod"></param>
    ''' <param name="endPeriod"></param>
    ''' <param name="compareStartPeriod"></param>
    ''' <param name="compareEndPeriod"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function isPeriodLapped(ByRef startPeriod As Date, ByRef endPeriod As Date, ByRef compareStartPeriod As Date, ByRef compareEndPeriod As Date) As Boolean
        If startPeriod.CompareTo(compareStartPeriod) > 0 AndAlso startPeriod.CompareTo(compareEndPeriod) < 0 Then
            Return True
        End If

        If endPeriod.CompareTo(compareStartPeriod) > 0 AndAlso endPeriod.CompareTo(compareEndPeriod) < 0 Then
            Return True
        End If

        If startPeriod.CompareTo(compareStartPeriod) < 0 AndAlso endPeriod.CompareTo(compareEndPeriod) > 0 Then
            Return True
        End If

        If startPeriod.CompareTo(compareStartPeriod) = 0 AndAlso startPeriod.CompareTo(endPeriod) <> 0 Then
            Return True
        End If

        If endPeriod.CompareTo(compareEndPeriod) = 0 And startPeriod.CompareTo(endPeriod) <> 0 Then
            Return True
        End If

        Return False

    End Function

    ''' <summary>
    ''' 程式說明：查詢醫令上一筆(下一筆)資料
    ''' 開發人員：Jen
    ''' 開發日期：2010.03.01
    ''' </summary>
    ''' <param name="partialOrderCode">部分醫令碼</param>
    ''' <param name="orderTypeId">醫令分類碼</param>
    ''' <param name="isPre">找上一筆?</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Order
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2010/03/10, XXX
    ''' </修改註記>
    Public Function queryPreOrNextRecordOrder(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal isPre As Boolean) As DataSet
        Dim nextDT As DataTable = Nothing

        If (partialOrderCode IsNot Nothing AndAlso partialOrderCode.Length > 0) AndAlso (orderTypeId IsNot Nothing AndAlso orderTypeId.Length > 0) Then
            nextDT = PUBOrderBO_E1.getInstance.queryPreOrNextRecordOrder(partialOrderCode, orderTypeId, isPre)
        End If

        If DataSetUtil.IsContainsData(nextDT) Then
            Return queryOrderData(CType(nextDT.Rows(0).Item("Order_Code"), String).Trim, DateUtil.getSystemDate)
        Else
            Return Nothing
        End If

    End Function

    Public Function queryPreOrNextRecordOrder2(ByVal partialOrderCode As String, ByVal orderTypeId As String, ByVal EffectDate As String, ByVal isPre As Boolean) As DataSet
        Dim nextDT As DataTable = Nothing
        Dim pvtIsChageOrder As Boolean

        If EffectDate <> "" AndAlso (partialOrderCode IsNot Nothing AndAlso _
           partialOrderCode.Length > 0) AndAlso (orderTypeId IsNot Nothing AndAlso _
           orderTypeId.Length > 0) Then

            nextDT = PUBOrderBO_E1.getInstance.queryPreOrNextRecordOrder2(partialOrderCode, orderTypeId, EffectDate, isPre)

            If nextDT.Rows.Count > 1 AndAlso _
                   nextDT.Rows(0).Item("Order_Code").ToString.Trim <> nextDT.Rows(1).Item("Order_Code").ToString.Trim Then
                pvtIsChageOrder = True
                EffectDate = ""
                nextDT = PUBOrderBO_E1.getInstance.queryPreOrNextRecordOrder2(partialOrderCode, orderTypeId, EffectDate, isPre)
            ElseIf nextDT.Rows.Count = 1 Then
                pvtIsChageOrder = True
                EffectDate = ""
                nextDT = PUBOrderBO_E1.getInstance.queryPreOrNextRecordOrder2(partialOrderCode, orderTypeId, EffectDate, isPre)

            End If

            If nextDT.Rows.Count > 1 Then
                If pvtIsChageOrder Then
                    nextDT.Rows.RemoveAt(1)
                Else
                    nextDT.Rows.RemoveAt(0)
                End If
            Else
                nextDT.Rows.Clear()
            End If

        Else
            nextDT = PUBOrderBO_E1.getInstance.queryPreOrNextRecordOrder3(partialOrderCode, orderTypeId, EffectDate, isPre)

        End If

        If DataSetUtil.IsContainsData(nextDT) Then
            Return queryOrderData(CType(nextDT.Rows(0).Item("Order_Code"), String).Trim, CType(nextDT.Rows(0).Item("Effect_Date"), String).Trim)
        Else
            Return Nothing
        End If

    End Function


    ''' <summary>
    ''' 刪除醫令相關資料
    ''' </summary>
    ''' <param name="inOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deletePUBOrderByOrderCode(ByVal inOrderCode As String) As Integer

        Dim PUBOrder As PUBOrderBO_E1 = PUBOrderBO_E1.getInstance
        Dim PUBOrderPrice As PUBOrderPriceBO_E1 = PUBOrderPriceBO_E1.getInstance
        Dim PUBOrderExam As PUBOrderExaminationBO_E1 = PUBOrderExaminationBO_E1.getInstance
        Dim PUBOrderOrTreat As PUBOrderOrTreatBO_E1 = PUBOrderOrTreatBO_E1.getInstance
        Dim PUBOrderMajorCare As PUBOrderMajorcareBO_E1 = PUBOrderMajorcareBO_E1.getInstance
        Dim PUBNhiIndexSet As PUBNhiIndexSetBO_E1 = PUBNhiIndexSetBO_E1.getInstance
        Dim PUBExcludeDrugSet As PUBExcludeDrugSetBO_E1 = PUBExcludeDrugSetBO_E1.getInstance
        Dim pvtResult As Integer = 0
        Dim pvtError As Integer = 0

        Dim scope As TransactionScope = Nothing
        scope = SQLConnFactory.getInstance.getRequiredTransactionScope()

        Try

            Using conn As System.Data.IDbConnection = CType(getConnection(), SqlConnection)
                conn.Open()

                Try
                    '查詢PubOrder當中的資料
                    Dim dsQuery As DataSet = PUBOrder.queryPubOrderByOrderCode(inOrderCode, conn)

                    Dim strEffectDay As String = ""
                    If dsQuery IsNot Nothing AndAlso dsQuery.Tables.Count > 0 AndAlso dsQuery.Tables(0).Rows.Count > 0 Then
                        strEffectDay = dsQuery.Tables(0).Rows(0).Item("Effect_Date")
                    End If

                    pvtResult += PUBOrder.delete(strEffectDay, inOrderCode, conn)
                    pvtResult += PUBOrderPrice.DeletePUBOrderPriceByOrderCode(inOrderCode, conn)
                    pvtResult += PUBOrderExam.delete(inOrderCode, conn)
                    pvtResult += PUBOrderOrTreat.delete(inOrderCode, conn)

                Catch ex As Exception
                    pvtError = 0
                    pvtResult = 0
                End Try

                scope.Complete()

            End Using

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally

            Try
                If scope IsNot Nothing Then scope.Dispose()
            Catch ex As Exception
                Throw ex
            End Try

        End Try

        Return pvtResult

    End Function

    'add by 唐子晴 2014.02.06 ------------------------------------------------------------------
    ''' <summary>
    ''' 刪除醫令相關資料 Log
    ''' </summary>
    ''' <param name="inOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deletePUBOrderLog(ByVal inOrderCode As String, ByVal inOrderName As String, ByVal inOrderTypeId As String, ByVal inOrderMode As String, ByVal inExecutionUser As String) As Integer
        Dim PUBOrder As PUBOrderBO_E1 = PUBOrderBO_E1.getInstance
        Dim pvtResult As Integer = 0

        Try
            pvtResult = PUBOrder.deletePUBOrderLog(inOrderCode, inOrderName, inOrderTypeId, inOrderMode, inExecutionUser)

            Return 1
        Catch ex As Exception
            Return 0
        End Try

    End Function
    '--------------------------------------------------------------------------------------------

#Region "群組醫令維護檔"
    ''' <summary>
    ''' InsertTo AddOrderDT/AddOrderDetailDT 
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateAddOrder(ByVal ds As DataSet) As Integer

        Dim AddOrderBO As PUBAddOrderBO_E1 = PUBAddOrderBO_E1.getInstance
        Dim AddorderDetailBO As PUBAddOrderDetailBO_E1 = PUBAddOrderDetailBO_E1.getInstance
        Dim InsertToAddOrderDS As New DataSet
        Dim InsertToAddorderDetailDS As New DataSet
        Try

            InsertToAddOrderDS.Tables.Add(ds.Tables("PUB_Add_Order").Copy)
            InsertToAddorderDetailDS.Tables.Add(ds.Tables("PUB_Add_Order_Detail").Copy)
            Dim count As Integer = 0
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

                '先刪除再寫入
                For Each dr As DataRow In InsertToAddOrderDS.Tables(0).Rows
                    count += AddOrderBO.delete(dr("Add_Order_Code"))
                    count += AddorderDetailBO.deleteByAddOrderCode(dr("Add_Order_Code"))
                Next
                'For Each dr As DataRow In InsertToAddorderDetailDS.Tables(0).Rows
                '    count += AddorderDetailBO.deleteByAddOrderCode(dr("Add_Order_Code"))
                'Next
                count += AddOrderBO.insert(InsertToAddOrderDS)
                count += AddorderDetailBO.insert(InsertToAddorderDetailDS)
                scope.Complete()
            End Using
            Return count

        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Delete AddOrderDT/AddOrderDetailDT 
    ''' </summary>
    ''' <param name="addOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deleteAddOrder(ByVal addOrderCode As String) As Integer

        Dim AddOrderBO As PUBAddOrderBO_E1 = PUBAddOrderBO_E1.getInstance
        Dim AddorderDetailBO As PUBAddOrderDetailBO_E1 = PUBAddOrderDetailBO_E1.getInstance

        Try


            Dim count As Integer = 0
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

                '先刪除再寫入
                count += AddorderDetailBO.deleteByAddOrderCode(addOrderCode)
                count += AddOrderBO.delete(addOrderCode)


                scope.Complete()
            End Using
            Return count

        Catch ex As Exception
            Return 0
        End Try
    End Function


#End Region

#Region "處理醫令停用替代項目"
    ''' <summary>
    ''' 找醫令替代項目
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryOrderAlternativeForOEIOtherLack(ByVal OrderCode As String) As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim Content As New StringBuilder
            Content.AppendLine("DECLARE @orderCdoe AS VARCHAR(20)= '" & OrderCode & "'")
            Content.AppendLine(";")
            Content.AppendLine("WITH base ")
            Content.AppendLine("     AS (SELECT A.Alternative_Code  AS myorder, ")
            Content.AppendLine("                0                     AS mysn, ")
            Content.AppendLine("				B.Order_En_Name, ")
            Content.AppendLine("				(Select Dc From PUB_Order C Where C.Order_Code=A.Alternative_Code) Dc")
            Content.AppendLine("         FROM   PUB_Order_Alternative A ")
            Content.AppendLine("                INNER JOIN PUB_Order B ")
            Content.AppendLine("                        ON A.Order_Code = B.Order_Code ")
            Content.AppendLine("         WHERE  A.Order_Code = @orderCdoe")
            Content.AppendLine("         UNION ALL ")
            Content.AppendLine("         SELECT A1.Alternative_Code AS myorder, ")
            Content.AppendLine("                B1.mysn + 1            AS mysn, ")
            Content.AppendLine(" 				B1.Order_En_Name, ")
            Content.AppendLine("				(Select Dc From PUB_Order C1 Where C1.Order_Code=A1.Alternative_Code) Dc")
            Content.AppendLine("         FROM   PUB_Order_Alternative A1 ")
            Content.AppendLine("                INNER JOIN base B1 ")
            Content.AppendLine("                        ON A1.Order_Code = B1.myorder ")
            Content.AppendLine("                INNER JOIN PUB_Order B2 ")
            Content.AppendLine("                        ON A1.Alternative_Code = B2.Order_Code")
            Content.AppendLine("		 Where A1.Alternative_Code <> @orderCdoe) ")
            Content.AppendLine(" SELECT TOP 1 myorder AS Order_Code, y.Order_En_Name ")
            Content.AppendLine(" FROM   base x , PUB_Order y ")
            Content.AppendLine(" WHERE  x.Dc = 'N' and x.myorder =y.Order_Code and y.Dc ='N' ")
            Content.AppendLine(" ORDER  BY mysn;")
            command.CommandText = Content.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Order")
                adapter.Fill(ds, "PUB_Order")
            End Using

            Return ds

        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbErrorMsg("{" & Me.GetType.Name & "}-{" & MethodBase.GetCurrentMethod.Name & "} " & ex.Message, ex)
            Return Nothing
        End Try
    End Function
#End Region

#Region "     取得 DB 在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>by Hsiao.Kaiwen on 2015-09-21</remarks>
    Public Function getConnection() As IDbConnection

        '自行設定正確的Connection 字串
        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class
