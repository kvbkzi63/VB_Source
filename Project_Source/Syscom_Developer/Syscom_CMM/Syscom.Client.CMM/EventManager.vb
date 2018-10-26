Imports System.Windows.Forms

Public Class EventManager

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property getInstance() As EventManager
        Get
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New EventManager()
    End Class

#End Region

#Region " CNC "

#Region " Cnc  Event "

    ''' <summary>
    ''' 多選控制項 回傳至 UC辨識資訊 和 Cell要顯示的值
    ''' </summary>
    ''' <param name="ucIdentify">UC 辨識資訊</param>
    ''' <param name="cellValue">Cell要顯示的值</param>
    ''' <remarks>by Sean.Lin on 2015-02-11</remarks>
    Public Event GetCncMutiChoiceSetCellValue(ByVal ucIdentify As String, ByVal cellValue As String)


    ''' <summary>
    ''' 部位檔回傳UI辨識資訊部位代碼、名稱、其他部位資訊
    ''' </summary>
    ''' <param name="UI_Identify"></param>
    ''' <param name="Body_Parts_No"></param>
    ''' <param name="Body_Parts_Name"></param>
    ''' <param name="Body_Parts_Others"></param>
    ''' <remarks></remarks>
    Public Event CncGetBodyPartsData(ByVal UI_Identify As String, ByVal Body_Parts_No As String, ByVal Body_Parts_Name As String, ByVal Body_Parts_Others As String)

    ''' <summary>
    ''' 護理紀錄 查詢UI的結果的Dataset 拋回 護理紀錄主畫面
    ''' </summary>
    ''' <param name="DS_QueryResualt"></param>
    ''' <param name="Input_String_Case_No"></param>
    ''' <param name="Input_query_Flag_Time_Condition"></param>
    ''' <param name="Input_query_Flag_Close_Condition"></param>
    ''' <param name="Input_Start_Time"></param>
    ''' <param name="Input_End_Time"></param>
    ''' <remarks></remarks>
    Public Event CncDARTRecordQueryDS(ByVal DS_QueryResualt As DataSet, ByVal Input_String_Case_No As String, ByVal Input_query_Flag_Time_Condition As String, ByVal Input_query_Flag_Close_Condition As String, ByVal Input_Start_Time As String, ByVal Input_End_Time As String)

    ''' <summary>
    ''' 護理紀錄 標點符號或從生命徵象元件帶入的資料 拋回 護理紀錄操作畫面
    ''' </summary>
    ''' <param name="Data_String"></param>
    ''' <param name="Input_Parent_Name"></param>
    ''' <remarks></remarks>
    Public Event CncDARTRecordOperationData(ByVal Data_String As String, ByVal Input_Parent_Name As String)

    ''' <summary>
    ''' 護理紀錄 護理指導評估完的資料 拋回 護理紀錄操作畫面
    ''' </summary>
    ''' <param name="Data_Array"></param>
    ''' <param name="Data_Type"></param>
    ''' <remarks></remarks>
    Public Event CncTeachingToDartRecord(ByVal Data_Array As Array, ByVal Data_Type As String)

    ''' <summary>
    ''' 護理紀錄 護理紀錄儲存預覽完的資料 拋回 護理紀錄操作畫面進行儲存
    ''' </summary>
    ''' <param name="DS_Save_Preview"></param>
    ''' <remarks></remarks>
    Public Event CncDartRecordDataPreview(ByVal DS_Save_Preview As DataSet)

    ''' <summary>
    ''' 護理紀錄 護理紀錄DARTGridUC 拋回 護理紀錄儲存預覽畫面變動畫面大小
    ''' </summary>
    ''' <param name="UI_Size"></param>
    ''' <param name="UI_Name"></param>
    ''' <remarks></remarks>
    Public Event CncDartGridToPreview(ByVal UI_Size As Integer, ByVal UI_Name As String)

    ''' <summary>
    ''' 從我的病人開啟持續護理評估畫面
    ''' </summary>
    ''' <param name="Form_No"></param>
    ''' <remarks></remarks>
    Public Event CncOpenNextEvaluationUI(ByVal Form_No As String, ByVal caseNo As String, ByVal chartNo As String)

    ''' <summary>
    ''' 將我的病人進行更新
    ''' </summary>
    ''' <remarks></remarks>
    Public Event CncMyPatientRefresh()

    ''' <summary>
    ''' 管理我的病人進行更新
    ''' </summary>
    ''' <remarks></remarks>
    Public Event CncMyPatientManageRefresh()

    ''' <summary>
    ''' 帶回自定義焦點範本資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Event GetCncFocusTemplateData(ByVal strTemplateD As String, ByVal strTemplateA As String, ByVal strTemplateR As String, ByVal strTemplateT As String)

    ''' <summary>
    ''' 重新查詢主檔評估資料
    ''' </summary>
    ''' <param name="UIName">UI名稱</param>
    ''' <param name="Form_No">表單編號</param>
    ''' <remarks></remarks>
    Public Event GetCncEvlMutilRefresh(ByVal UIName As String, ByVal Form_No As String)


    ''' <summary>
    ''' 取得三合一UC的部位名稱
    ''' </summary>
    ''' <param name="bodyPart">表單編號</param>
    ''' <remarks></remarks>
    Public Event GetBodyPart(ByVal bodyPart As String)

    ''' <summary>
    ''' CncNextEvilationHistory BtnSave Visible
    ''' </summary>
    ''' <param name="VisibleBl"></param>
    ''' <param name="FormNo"></param>
    ''' <param name="UIobj"></param>
    ''' <remarks></remarks>
    Public Event CncNextEvilationHistoryBtnSaveVisibleChange(ByVal VisibleBl As Boolean, ByVal FormNo As String, ByVal UIobj As Object)


    ''' <summary>
    ''' NextEvilationAddButtonFormNo
    ''' </summary>
    ''' <remarks></remarks>
    Public Event addButtonByFormNo(ByVal formNo As String)


#End Region

#Region " Cnc  Raise Event "
    ''' <summary>
    ''' CncNextEvilationHistory BtnSave Visible
    ''' </summary>
    ''' <param name="VisibleBl"></param>
    ''' <param name="FormNo"></param>
    ''' <param name="UIobj"></param>
    ''' <remarks></remarks>
    Public Sub RaiseCncNextEvilationHistoryBtnSaveVisible(ByVal VisibleBl As Boolean, ByVal FormNo As String, ByVal UIobj As Object)
        RaiseEvent CncNextEvilationHistoryBtnSaveVisibleChange(VisibleBl, FormNo, UIobj)
    End Sub
    ''' <summary>
    ''' NextEvilationAddButtonFormNo
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RaiseaddButtonByFormNo(ByVal formNo As String)
        RaiseEvent addButtonByFormNo(formNo)
    End Sub


    ''' <summary>
    ''' 取得三合一UC的部位名稱
    ''' </summary>
    ''' <param name="bodyPart">表單編號</param>
    ''' <remarks></remarks>
    Public Sub RaiseBodyPart(ByVal bodyPart As String)
        RaiseEvent GetBodyPart(bodyPart)
    End Sub


    ''' <summary>
    ''' 多選控制項 拋出 UC辨識資訊 和 Cell要顯示的值
    ''' </summary>
    ''' <param name="ucIdentify">UC 辨識資訊</param>
    ''' <param name="cellValue">Cell要顯示的值</param>
    ''' <remarks>by Sean.Lin on 2015-02-11</remarks>
    Public Sub RaiseCncMutiChoiceSetCellValue(ByVal ucIdentify As String, ByVal cellValue As String)
        RaiseEvent GetCncMutiChoiceSetCellValue(ucIdentify, cellValue)
    End Sub


    ''' <summary>
    ''' 部位檔回傳UI辨識資訊部位代碼、名稱、其他部位資訊
    ''' </summary>
    ''' <param name="UI_Identify"></param>
    ''' <param name="Body_Parts_No"></param>
    ''' <param name="Body_Parts_Name"></param>
    ''' <param name="Body_Parts_Others"></param>
    ''' <remarks></remarks>
    Public Sub RaiseCncGetBodyPartsData(ByVal UI_Identify As String, ByVal Body_Parts_No As String, ByVal Body_Parts_Name As String, ByVal Body_Parts_Others As String)
        RaiseEvent CncGetBodyPartsData(UI_Identify, Body_Parts_No, Body_Parts_Name, Body_Parts_Others)
    End Sub

    ''' <summary>
    ''' 護理紀錄 查詢UI的結果的Dataset 拋回 護理紀錄主畫面
    ''' </summary>
    ''' <param name="DS_QueryResualt"></param>
    ''' <param name="Input_String_Case_No"></param>
    ''' <param name="Input_query_Flag_Time_Condition"></param>
    ''' <param name="Input_query_Flag_Close_Condition"></param>
    ''' <param name="Input_Start_Time"></param>
    ''' <param name="Input_End_Time"></param>
    ''' <remarks></remarks>
    Public Sub RaiseCncDARTRecordQueryDS(ByVal DS_QueryResualt As DataSet, ByVal Input_String_Case_No As String, ByVal Input_query_Flag_Time_Condition As String, ByVal Input_query_Flag_Close_Condition As String, ByVal Input_Start_Time As String, ByVal Input_End_Time As String)
        RaiseEvent CncDARTRecordQueryDS(DS_QueryResualt, Input_String_Case_No, Input_query_Flag_Time_Condition, Input_query_Flag_Close_Condition, Input_Start_Time, Input_End_Time)
    End Sub

    ''' <summary>
    ''' 護理紀錄 標點符號或從生命徵象元件帶入的資料 拋回 護理紀錄操作畫面
    ''' </summary>
    ''' <param name="Data_String"></param>
    ''' <param name="Input_Parent_Name"></param>
    ''' <remarks></remarks>
    Public Sub RaiseCncDARTRecordOperationData(ByVal Data_String As String, ByVal Input_Parent_Name As String)
        RaiseEvent CncDARTRecordOperationData(Data_String, Input_Parent_Name)
    End Sub

    ''' <summary>
    ''' 護理紀錄 護理指導評估完的資料 拋回 護理紀錄操作畫面
    ''' </summary>
    ''' <param name="Data_Array"></param>
    ''' <param name="Data_Type"></param>
    ''' <remarks></remarks>
    Public Sub RaiseCncTeachingToDartRecord(ByVal Data_Array As Array, ByVal Data_Type As String)
        RaiseEvent CncTeachingToDartRecord(Data_Array, Data_Type)
    End Sub

    ''' <summary>
    ''' 護理紀錄 護理紀錄儲存預覽完的資料 拋回 護理紀錄操作畫面進行儲存
    ''' </summary>
    ''' <param name="DS_Save_Preview"></param>
    ''' <remarks></remarks>
    Public Sub RaiseCncDartRecordDataPreview(ByVal DS_Save_Preview As DataSet)
        RaiseEvent CncDartRecordDataPreview(DS_Save_Preview)
    End Sub

    ''' <summary>
    ''' 護理紀錄 護理紀錄DARTGridUC 拋回 護理紀錄儲存預覽畫面變動畫面大小
    ''' </summary>
    ''' <param name="UI_Size"></param>
    ''' <param name="UI_Name"></param>
    ''' <remarks></remarks>
    Public Sub RaiseCncDartGridToPreview(ByVal UI_Size As Integer, ByVal UI_Name As String)
        RaiseEvent CncDartGridToPreview(UI_Size, UI_Name)
    End Sub

    ''' <summary>
    ''' 從我的病人開啟持續護理評估表單
    ''' </summary>
    ''' <param name="Form_No"></param>
    ''' <remarks></remarks>
    Public Sub RaiseCncOpenNextEvaluationUI(ByVal Form_No As String, ByVal caseNo As String, ByVal chartNo As String)
        RaiseEvent CncOpenNextEvaluationUI(Form_No, caseNo, chartNo)
    End Sub

    ''' <summary>
    ''' 將我的病人更新
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RaiseCncMyPatientRefresh()
        RaiseEvent CncMyPatientRefresh()
    End Sub

    ''' <summary>
    ''' 管理我的病人更新
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RaiseCncMyPatientManageRefresh()
        RaiseEvent CncMyPatientManageRefresh()
    End Sub

    ''' <summary>
    ''' 帶回自定義焦點範本資料
    ''' </summary>
    ''' <param name="strTemplateD"></param>
    ''' <param name="strTemplateA"></param>
    ''' <param name="strTemplateR"></param>
    ''' <param name="strTemplateT"></param>
    ''' <remarks></remarks>
    Public Sub RaiseCncFocusTemplateData(ByVal strTemplateD As String, ByVal strTemplateA As String, ByVal strTemplateR As String, ByVal strTemplateT As String)
        RaiseEvent GetCncFocusTemplateData(strTemplateD, strTemplateA, strTemplateR, strTemplateT)
    End Sub

    ''' <summary>
    ''' 重新查詢主檔評估資料
    ''' </summary>
    ''' <param name="UIName">UI名稱</param>
    ''' <param name="Form_No">表單編號</param>
    ''' <remarks></remarks>
    Public Sub RaiseCncEvlMutilRefresh(ByVal UIName As String, ByVal Form_No As String)
        RaiseEvent GetCncEvlMutilRefresh(UIName, Form_No)
    End Sub

    ''' <summary>
    ''' 加護病房病患住院原因
    ''' </summary>
    ''' <param name="paramDS"></param>
    ''' <remarks></remarks>
    Public Sub RaiseGetInpInIcuRecordUIData(ByVal paramDS As DataSet)
        RaiseEvent GetInpInIcuRecordUIData(paramDS)
    End Sub

    ''' <summary>
    ''' ICD診斷篩選回傳
    ''' </summary>
    ''' <param name="paramDS"></param>
    ''' <remarks></remarks>
    Public Sub RaiseGetSICD10PCSCodeData(ByVal paramDS As DataSet)
        RaiseEvent GetSICD10PCSCodeData(paramDS)
    End Sub

#End Region

#Region " DDC "

#Region " DDC  Event "

    ''' <summary>
    ''' 待確認醫囑原因及說明
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-08</remarks>
    Public Event GetDDCDoubtOrderData(ByVal DoubtReason As String, ByVal DoubtCode As String, ByVal PositionY As Integer, ByVal OrderPlanNo As String)


    ''' <summary>
    ''' 醫囑執行重新查詢
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-08</remarks>
    Public Event GetDDCRefreshOrderExe(ByVal RefreshFlag As String)

    ''' <summary>
    ''' 離開醫囑修改畫面，Flag 為 0
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-07-09</remarks>
    Public Event GetDDCLeaveOrderModify(ByVal RefreshFlag As String)


    ''' <summary>
    ''' 取得計價結果的DS，包含兩個DT，1.OrderCode(Order_Code,count) 2.TreatmentNo(Treatment_No)。 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-02-07</remarks>
    Public Event GetDDCTreatmentSummary(ByVal ds As DataSet)


    ''' <summary>
    ''' 取得我的病人歷程起迄時間。 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-04-1</remarks>
    Public Event GetDDCPatientHistoryTime(ByVal timeArray As String())

    ''' <summary>
    ''' 取得計價結果的DS，包含兩個DT，1.OrderCode(Order_Code,count) 2.TreatmentNo(Treatment_No)。 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-06-27</remarks>
    Public Event GetDDCReturnDrugSTA(ByVal ds As DataSet)

    ''' <summary>
    ''' 取得加護病房病患住院原因的DS，包含 DT (InpInIcuRecordUI)。 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-06-27</remarks>
    Public Event GetInpInIcuRecordUIData(ByVal ds As DataSet)

    ''' <summary>
    ''' 取得ICD診斷篩選的DS，包含 DT (ICDIcd10CodeSelectorUI)。 
    ''' </summary>
    ''' <remarks>by Kudy.Sue on 2016-10-01</remarks>
    Public Event GetSICD10PCSCodeData(ByVal ds As DataSet)

#End Region

#Region " DDC  Raise Event "

    ''' <summary>
    ''' 待確認醫囑原因及說明
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-08</remarks>
    Public Sub RaiseDDCDoubtOrderData(ByVal DoubtReason As String, ByVal DoubtCode As String, ByVal PositionY As Integer, ByVal OrderPlanNo As String)
        RaiseEvent GetDDCDoubtOrderData(DoubtReason, DoubtCode, PositionY, OrderPlanNo)
    End Sub

    ''' <summary>
    ''' 醫囑執行重新查詢
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-08</remarks>
    Public Sub RaiseDDCRefreshOrderExe(ByVal RefreshFlag As String)
        RaiseEvent GetDDCRefreshOrderExe(RefreshFlag)
    End Sub


    ''' <summary>
    ''' 離開醫囑修改畫面，Flag 為 0
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-07-09</remarks>
    Public Sub RaiseDDCLeaveOrderModify(ByVal RefreshFlag As String)
        RaiseEvent GetDDCLeaveOrderModify(RefreshFlag)
    End Sub


    ''' <summary>
    ''' 取得計價結果的DS，包含兩個DT，1.OrderCode(Order_Code,count) 2.TreatmentNo(Treatment_No)。 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-02-07</remarks>
    Public Sub RaiseDDCTreatmentSummary(ByVal ds As DataSet)
        RaiseEvent GetDDCTreatmentSummary(ds)
    End Sub


    ''' <summary>
    ''' 取得我的病人歷程起迄時間。  
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-04-01</remarks>
    Public Sub RaiseDDCPatientHistoryTime(ByVal timeArray As String())
        RaiseEvent GetDDCPatientHistoryTime(timeArray)
    End Sub


    ''' <summary>
    ''' 取得計價結果的DS，包含兩個DT，1.OrderCode(Order_Code,count) 2.TreatmentNo(Treatment_No)。 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-06-27</remarks>
    Public Sub RaiseDDCReturnDrugSTA(ByVal ds As DataSet)
        RaiseEvent GetDDCReturnDrugSTA(ds)
    End Sub

#End Region

#End Region

#Region " Enc "

#Region " Enc  Event "

    ''' <summary>
    ''' 待確認醫囑原因及說明
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-08</remarks>
    Public Event GetEncDoubtOrderData(ByVal DoubtReason As String, ByVal DoubtCode As String, ByVal PositionY As Integer, ByVal OrderPlanNo As String)


    ''' <summary>
    ''' 醫囑執行重新查詢
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-08</remarks>
    Public Event GetEncRefreshOrderExe(ByVal RefreshFlag As String)

    ''' <summary>
    ''' 離開醫囑修改畫面，Flag 為 0
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-07-09</remarks>
    Public Event GetEncLeaveOrderModify(ByVal RefreshFlag As String)


    ''' <summary>
    ''' 取得計價結果的DS，包含兩個DT，1.OrderCode(Order_Code,count) 2.TreatmentNo(Treatment_No)。 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-02-07</remarks>
    Public Event GetEncTreatmentSummary(ByVal ds As DataSet)


    ''' <summary>
    ''' 取得我的病人歷程起迄時間。 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-04-1</remarks>
    Public Event GetEncPatientHistoryTime(ByVal timeArray As String())

    ''' <summary>
    ''' 取得計價結果的DS，包含兩個DT，1.OrderCode(Order_Code,count) 2.TreatmentNo(Treatment_No)。 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-06-27</remarks>
    Public Event GetEncReturnDrugSTA(ByVal ds As DataSet)

    ''' <summary>
    ''' 病人資訊 (EncPatientInfoUC) 接收從 我的病人   拋出的事件，取得病人的 資訊DS
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-02-15</remarks>
    Public Event GetEncPatientInfoDS(ByVal DS_Patient As DataSet)

    ''' <summary>
    ''' 病人資訊 (EncPatientInfoUC) 接收從 我的病人   拋出的事件，取得刷新畫面 flag
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-09</remarks>
    Public Event GetEncPatientInfoRefresh(ByVal RefreshFlag As Boolean)

    ''' <summary> 從外部元件取得資料帶回護理紀錄 </summary>
    ''' <remarks>by Kevin.Kai on 2015-08-07</remarks>
    Public Event GetEncFocusData(ByVal FocusData As String)

#End Region

#Region " Enc  Raise Event "

    ''' <summary>
    ''' 待確認醫囑原因及說明
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-08</remarks>
    Public Sub RaiseEncDoubtOrderData(ByVal DoubtReason As String, ByVal DoubtCode As String, ByVal PositionY As Integer, ByVal OrderPlanNo As String)
        RaiseEvent GetEncDoubtOrderData(DoubtReason, DoubtCode, PositionY, OrderPlanNo)
    End Sub

    ''' <summary>
    ''' 醫囑執行重新查詢
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-08</remarks>
    Public Sub RaiseEncRefreshOrderExe(ByVal RefreshFlag As String)
        RaiseEvent GetEncRefreshOrderExe(RefreshFlag)
    End Sub


    ''' <summary>
    ''' 離開醫囑修改畫面，Flag 為 0
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-07-09</remarks>
    Public Sub RaiseEncLeaveOrderModify(ByVal RefreshFlag As String)
        RaiseEvent GetEncLeaveOrderModify(RefreshFlag)
    End Sub


    ''' <summary>
    ''' 取得計價結果的DS，包含兩個DT，1.OrderCode(Order_Code,count) 2.TreatmentNo(Treatment_No)。 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-02-07</remarks>
    Public Sub RaiseEncTreatmentSummary(ByVal ds As DataSet)
        RaiseEvent GetEncTreatmentSummary(ds)
    End Sub


    ''' <summary>
    ''' 取得我的病人歷程起迄時間。  
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-04-01</remarks>
    Public Sub RaiseEncPatientHistoryTime(ByVal timeArray As String())
        RaiseEvent GetEncPatientHistoryTime(timeArray)
    End Sub


    ''' <summary>
    ''' 取得計價結果的DS，包含兩個DT，1.OrderCode(Order_Code,count) 2.TreatmentNo(Treatment_No)。 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-06-27</remarks>
    Public Sub RaiseEncReturnDrugSTA(ByVal ds As DataSet)
        RaiseEvent GetEncReturnDrugSTA(ds)
    End Sub

    ''' <summary>
    ''' 從 我的病人  拋出的事件，傳出一個病人的 資訊DS
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-02-15</remarks>
    Public Sub RaiseEncPatientInfoDS(ByVal DS_Patient As DataSet)
        RaiseEvent GetEncPatientInfoDS(DS_Patient)
    End Sub

    ''' <summary>
    ''' 從 我的病人  拋出的事件，傳出 True 表示刷新畫面了
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-09</remarks>
    Public Sub RaiseEncPatientInfoRefresh(ByVal RefreshFlag As Boolean)
        RaiseEvent GetEncPatientInfoRefresh(RefreshFlag)
    End Sub

    ''' <summary> 從外部元件帶資料回護理紀錄 </summary>
    ''' <remarks>by Kevin.Kai on 2015-08-07</remarks>
    Public Sub RaisENCFocusData(ByVal FocusData As String)
        RaiseEvent GetEncFocusData(FocusData)
    End Sub

#End Region

#End Region

#Region " API "

#Region " API  Event "

    ''' <summary>
    ''' 病人資訊 (PCSUCLPatientInfoUC) 接收從 我的病人(PCSUCLMyPatientUI)  拋出的事件，取得病人的 Chart_No
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-11-29</remarks>
    Public Event GetAPIPatientInfoChartNo(ByVal Chart_No As String)

    ''' <summary>
    ''' 病人資訊 (PCSUCLPatientInfoUC) 接收從 我的病人(PCSUCLMyPatientUI)  拋出的事件，取得病人的 資訊DS
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-02-15</remarks>
    Public Event GetAPIPatientInfoDS(ByVal DS_Patient As DataSet)

    ''' <summary>
    ''' 病人資訊 (PCSUCLPatientInfoUC) 接收從 我的病人(PCSUCLMyPatientUI)  拋出的事件，取得刷新畫面 flag
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-09</remarks>
    Public Event GetAPIPatientInfoRefresh(ByVal RefreshFlag As Boolean)

#End Region

#Region " API  Raise Event "

    ''' <summary>
    ''' 從 我的病人(PCSUCLMyPatientUI) 拋出的事件，傳出一個病人的 Chart_No
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-11-29</remarks>
    Public Sub RaiseAPIPatientInfoChartNo(ByVal Chart_No As String)
        RaiseEvent GetAPIPatientInfoChartNo(Chart_No)
    End Sub

    ''' <summary>
    ''' 從 我的病人(PCSUCLMyPatientUI) 拋出的事件，傳出一個病人的 資訊DS
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-02-15</remarks>
    Public Sub RaiseAPIPatientInfoDS(ByVal DS_Patient As DataSet)
        RaiseEvent GetAPIPatientInfoDS(DS_Patient)
    End Sub

    ''' <summary>
    ''' 從 我的病人(PCSUCLMyPatientUI) 拋出的事件，傳出 True 表示刷新畫面了
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-09</remarks>
    Public Sub RaiseAPIPatientInfoRefresh(ByVal RefreshFlag As Boolean)
        RaiseEvent GetAPIPatientInfoRefresh(RefreshFlag)
    End Sub

#End Region

#End Region

#Region "診間掛號"

#Region "診間掛號 Event"

    ''' <summary>
    ''' 診間掛號
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Event OMOREG(ByVal ctlName As String, ByVal ds As DataSet)

#End Region

#Region "診間掛號 Raise Event"
    ''' <summary>
    ''' 診間掛號
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Sub RaiseOMOREG(ByVal ctlName As String, ByVal ds As DataSet)
        RaiseEvent OMOREG(ctlName, ds)
    End Sub
#End Region

#End Region

#Region " System "

#Region " Event "

    ''' <summary>
    ''' NFC Event (不管什麼狀況，需要讓 『通知訊息 UI 』 立刻更新，便是這一個。)
    ''' </summary>
    ''' <remarks>20100624 add by Roger</remarks>
    Public Event NFCForceRefresh()

    ''' <summary>
    ''' 訊息列需要被更新的事件
    ''' </summary>
    ''' <param name="msg">訊息</param>
    ''' <remarks></remarks>
    Public Event DisplayStatusBar(ByVal msg As String)

    ''' <summary>
    ''' 自動顯示被 Dock 的 Form
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <remarks></remarks>
    Public Event showDockEven(ByVal msg As String)

    ''' <summary>
    ''' 訊息事件-Error(WCF專用)
    ''' </summary>
    ''' <param name="inErrorCode"></param>
    ''' <param name="inMessage"></param>
    ''' <param name="inDetail"></param>
    ''' <remarks></remarks>
    Public Event showErrorMsgForWCF(ByVal inErrorCode As String, ByVal inMessage As String, ByVal inDetail As String)

    ''' <summary>
    ''' 訊息事件-Error
    ''' </summary>
    ''' <param name="inErrorCode"></param>
    ''' <param name="inMessage"></param>
    ''' <param name="inDetail"></param>
    ''' <remarks></remarks>
    Public Event showErrorMsg(ByVal inErrorCode As String, ByVal inMessage As String(), ByVal inDetail As String)

    ''' <summary>
    ''' 訊息事件-Warn
    ''' </summary>
    ''' <param name="inErrorCode"></param>
    ''' <param name="inMessage"></param>
    ''' <remarks></remarks>
    Public Event showWarnMsg(ByVal inErrorCode As String, ByVal inMessage As String())

    ''' <summary>
    ''' 訊息事件-Question
    ''' </summary>
    ''' <param name="inErrorCode"></param>
    ''' <param name="inMessage"></param>
    ''' <remarks></remarks>
    Public Event showQuestionMsg(ByVal inErrorCode As String, ByVal inMessage As String())

    ''' <summary>
    ''' 訊息事件-Infomation
    ''' </summary>
    ''' <param name="inErrorCode"></param>
    ''' <param name="inMessage"></param>
    ''' <remarks></remarks>
    Public Event showInfoMsg(ByVal inErrorCode As String, ByVal inMessage As String())

    ''' <summary>
    ''' 開啟 OpenWindow 視窗，傳入查詢表格與條件值
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="uclTableName"></param>
    ''' <param name="uclQueryValue"></param>
    ''' <remarks></remarks>
    Public Event UclOpenWindow(ByVal ctlName As String, ByVal uclTableName As String, ByVal uclQueryValue As String)

    ''' <summary>
    ''' 開啟 OpenWindow 視窗，傳入查詢表格與條件值
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="uclTableName"></param>
    ''' <param name="uclQueryField"></param>
    ''' <param name="uclQueryValue"></param>
    ''' <remarks></remarks>
    Public Event UclOpenWindow2(ByVal ctlName As String, ByVal uclTableName As String, ByVal uclQueryField As String, ByVal uclQueryValue As String)

    ''' <summary>
    ''' OpenWindow 視窗選取值回傳
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="uclCodeValue1"></param>
    ''' <param name="uclCodeValue2"></param>
    ''' <param name="uclCodeName"></param>
    ''' <remarks></remarks>
    Public Event UclOpenWindowValue(ByVal ctlName As String, ByVal uclCodeValue1 As String, ByVal uclCodeValue2 As String, ByVal uclCodeName As String)

    ''' <summary>
    ''' OpenWindow 視窗選取值回傳(多選)
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Event UclOpenWindowValue2(ByVal ctlName As String, ByVal ds As DataSet)

    ''' <summary>
    ''' OpenWindow 視窗選取值回傳(多選)
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Event OmoToEmrFunctionList(ByVal ctlName As String, ByVal ds As DataSet)

    ''' <summary>
    ''' OpenWindow 視窗選取值回傳(多選)
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Event EmrDittoOmo(ByVal ctlName As String, ByVal ds As DataSet)

    ''' <summary>
    ''' OpenWindow 視窗選取值回傳(多選)
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Event UclOpenWindowMultiSelectValue(ByVal ctlName As String, ByVal ds As DataSet)

    ''' <summary>
    ''' OpenWindow 視窗選取值回傳(隨輸隨選)
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="rowIndex"></param>
    ''' <param name="colIndex"></param>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Public Event UclOpenWindowComboBoxGridValue(ByVal ctlName As String, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal row As System.Windows.Forms.DataGridViewRow)

    ''' <summary>
    ''' 開啟 OpenAreaWindow 視窗
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="uclCodeValue"></param>
    ''' <remarks></remarks>
    Public Event UclOpenAreaWindow(ByVal ctlName As String, ByVal uclCodeValue As String)

    ''' <summary>
    ''' 開啟 OpenChartNoWindow 視窗
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="uclCodeValue"></param>
    ''' <remarks></remarks>
    Public Event UclOpenChartNoWindow(ByVal ctlName As String, ByVal uclCodeValue As String)
    ''' <summary>
    ''' 開啟 OpenChartNoWindow 視窗
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="uclCodeValue"></param>
    ''' <remarks></remarks>
    Public Event UclOpenChartNoWindowNew(ByVal UIName As String, ByVal ctlName As String, ByVal uclCodeValue As String)

    ''' <summary>
    ''' 開啟 OpenGridWindow 視窗
    ''' </summary>
    ''' <param name="CboName"></param>
    ''' <param name="SelectedValue"></param>
    ''' <param name="SelectedName"></param>
    ''' <remarks></remarks>
    Public Event UclOpenComboBoxGridWindow(ByVal CboName As String, ByVal SelectedValue As String, ByVal SelectedName As String)

    ''' <summary>
    ''' 回傳目前作用中的 TreeGridView
    ''' </summary>
    ''' <param name="GridViewName"></param>
    ''' <remarks></remarks>
    Public Event UclGetActiveTreeGridView(ByVal GridViewName As String)

    ''' <summary>
    ''' 啟動 UclFinishDoAction
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <remarks></remarks>
    Public Event UclFinishDoAction(ByVal ctlName As String)

    ''' <summary>
    ''' 回傳目前關閉 DEPOrderUI
    ''' </summary>
    ''' <param name="Flag"></param>
    ''' <remarks></remarks>
    Public Event DEPOrderUIClosed(ByVal Flag As String)

    ''' <summary>
    ''' 啟動 UclWaitingFormUI
    ''' </summary>
    ''' <param name="Action"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Public Event UclWaitingForm(ByVal Action As String, ByVal Msg As String)

    ''' <summary>
    ''' 啟動 UclWaitingFormUI2
    ''' </summary>
    ''' <param name="Action"></param>
    ''' <param name="Msg"></param>
    ''' <param name="LocationX"></param>
    ''' <param name="LocationY"></param>
    ''' <remarks></remarks>
    Public Event UclWaitingForm2(ByVal Action As String, ByVal Msg As String, ByVal LocationX As Integer, ByVal LocationY As Integer)

    ''' <summary>
    ''' 鎖定登入視窗，True: 鎖定；False:解鎖
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-11-13</remarks>
    Public Event GetAPPLockWindow(ByVal LockFalg As Boolean)

    ''' <summary>
    ''' 切換使用者
    ''' </summary> 
    ''' <remarks>Copy by Sean.Lin on 2014-01-28</remarks>
    Public Event SwitchUserEvent()

    ''' <summary>
    ''' 授權代理
    ''' </summary> 
    ''' <remarks></remarks>
    Public Event OpenAgentInstance(ByVal LoginUserId As String, ByVal LoginUserName As String, ByVal AgentUserId As String, ByVal AgentUserName As String, ByVal userRoleList() As String)

    ''' <summary>
    ''' 完成開啟動作
    ''' </summary>
    ''' <remarks></remarks>
    Public Event OpenUIFinished()

    ''' <summary>
    ''' 匯入Excel Ds
    ''' </summary>
    ''' <param name="ImportDs"></param>
    ''' <remarks></remarks>
    Public Event ImportExcel(ByVal ImportDs As DataSet)

#End Region

#Region " Raise Event "

    ''' <summary>
    ''' fire NFC Event (不管什麼狀況，需要讓 『通知訊息 UI 』 立刻更新，便是這一個。)
    ''' </summary>
    ''' <remarks>20100624 add by Roger </remarks>
    Public Sub RaiseNFCForceRefresh()
        RaiseEvent NFCForceRefresh()
    End Sub

    ''' <summary>
    ''' 自動顯示被 Dock 的 Form
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <remarks></remarks>
    Public Sub RaisShowDockEvent(ByVal msg As String)
        RaiseEvent showDockEven(msg)
    End Sub

    ''' <summary>
    ''' 啟動訊息列需要被更新的事件，傳入訊息
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <remarks></remarks>
    Public Sub RaisDisplayStatusBar(ByVal msg As String)
        RaiseEvent DisplayStatusBar(msg)
    End Sub

    ''' <summary>
    ''' 啟動錯誤訊息需要被更新的事件，傳入訊息(WCF專用)
    ''' </summary>
    ''' <param name="inErrorCode"></param>
    ''' <param name="inMessage"></param>
    ''' <param name="inDetail"></param>
    ''' <remarks></remarks>
    Public Sub RaiseShowErrorMsgForWCF(ByVal inErrorCode As String, ByVal inMessage As String, ByVal inDetail As String)
        RaiseEvent showErrorMsgForWCF(inErrorCode, inMessage, inDetail)
    End Sub

    ''' <summary>
    ''' 啟動錯誤訊息需要被更新的事件，傳入訊息
    ''' </summary>
    ''' <param name="inErrorCode"></param>
    ''' <param name="inMessage"></param>
    ''' <param name="inDetail"></param>
    ''' <remarks></remarks>
    Public Sub RaiseShowErrorMsg(ByVal inErrorCode As String, ByVal inMessage As String(), ByVal inDetail As String)
        RaiseEvent showErrorMsg(inErrorCode, inMessage, inDetail)
    End Sub

    ''' <summary>
    ''' 啟動警告訊息需要被更新的事件，傳入訊息
    ''' </summary>
    ''' <param name="inErrorCode"></param>
    ''' <param name="inMessage"></param>
    ''' <remarks></remarks>
    Public Sub RaiseShowWarnMsg(ByVal inErrorCode As String, ByVal inMessage As String())
        RaiseEvent showWarnMsg(inErrorCode, inMessage)
    End Sub

    ''' <summary>
    ''' 啟動問題訊息需要被更新的事件，傳入訊息
    ''' </summary>
    ''' <param name="inErrorCode"></param>
    ''' <param name="inMessage"></param>
    ''' <remarks></remarks>
    Public Sub RaiseShowQuestionMsg(ByVal inErrorCode As String, ByVal inMessage As String())
        RaiseEvent showQuestionMsg(inErrorCode, inMessage)
    End Sub

    ''' <summary>
    ''' 啟動資訊訊息需要被更新的事件，傳入訊息
    ''' </summary>
    ''' <param name="inErrorCode"></param>
    ''' <param name="inMessage"></param>
    ''' <remarks></remarks>
    Public Sub RaiseShowInfoMsg(ByVal inErrorCode As String, ByVal inMessage As String())
        RaiseEvent showInfoMsg(inErrorCode, inMessage)
    End Sub

    ''' <summary>
    ''' 開啟 OpenWindow 視窗，傳入查詢表格與條件值
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="uclTableName"></param>
    ''' <param name="uclQueryValue"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclOpenWindow(ByVal ctlName As String, ByVal uclTableName As String, ByVal uclQueryValue As String)
        RaiseEvent UclOpenWindow(ctlName, uclTableName, uclQueryValue)
    End Sub

    ''' <summary>
    ''' 開啟 OpenWindow 視窗，傳入查詢表格與條件值
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="uclTableName"></param>
    ''' <param name="uclQueryField"></param>
    ''' <param name="uclQueryValue"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclOpenWindow2(ByVal ctlName As String, ByVal uclTableName As String, ByVal uclQueryField As String, ByVal uclQueryValue As String)
        RaiseEvent UclOpenWindow2(ctlName, uclTableName, uclQueryField, uclQueryValue)
    End Sub

    ''' <summary>
    ''' OpenWindow 視窗選取值回傳
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="uclCodeValue1"></param>
    ''' <param name="uclCodeValue2"></param>
    ''' <param name="uclCodeName"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclOpenWindowValue(ByVal ctlName As String, ByVal uclCodeValue1 As String, ByVal uclCodeValue2 As String, ByVal uclCodeName As String)
        RaiseEvent UclOpenWindowValue(ctlName, uclCodeValue1, uclCodeValue2, uclCodeName)
    End Sub

    ''' <summary>
    ''' OpenWindow 視窗選取值回傳 
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclOpenWindowValue2(ByVal ctlName As String, ByVal ds As DataSet)
        RaiseEvent UclOpenWindowValue2(ctlName, ds)
    End Sub

    ''' <summary>
    ''' OpenWindow 視窗選取值回傳 
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Sub RaiseOmoToEmrFunctionList(ByVal ctlName As String, ByVal ds As DataSet)
        RaiseEvent OmoToEmrFunctionList(ctlName, ds)
    End Sub

    ''' <summary>
    ''' OpenWindow 視窗選取值回傳 
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEmrDittoOmo(ByVal ctlName As String, ByVal ds As DataSet)
        RaiseEvent EmrDittoOmo(ctlName, ds)
    End Sub

    ''' <summary>
    ''' OpenWindow 視窗選取值回傳(隨輸隨選)
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="rowIndex"></param>
    ''' <param name="colIndex"></param>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclOpenWindowComboBoxGridValue(ByVal ctlName As String, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal row As System.Windows.Forms.DataGridViewRow)
        RaiseEvent UclOpenWindowComboBoxGridValue(ctlName, rowIndex, colIndex, row)
    End Sub

    ''' <summary>
    ''' OpenWindow 視窗選取值回傳(多選)
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclOpenWindowMultiSelectValue(ByVal ctlName As String, ByVal ds As DataSet)
        RaiseEvent UclOpenWindowMultiSelectValue(ctlName, ds)
    End Sub

    ''' <summary>
    ''' 開啟 OpenWindow 視窗
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="uclCodeValue"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclOpenAreaWindow(ByVal ctlName As String, ByVal uclCodeValue As String)
        RaiseEvent UclOpenAreaWindow(ctlName, uclCodeValue)
    End Sub

    ''' <summary>
    ''' 開啟 OpenWindow 視窗
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="uclCodeValue"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclOpenChartNoWindow(ByVal ctlName As String, ByVal uclCodeValue As String)
        RaiseEvent UclOpenChartNoWindow(ctlName, uclCodeValue)
    End Sub

    ''' <summary>
    ''' 開啟 OpenWindow 視窗
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="uclCodeValue"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclOpenChartNoWindowNew(ByVal UIName As String, ByVal ctlName As String, ByVal uclCodeValue As String)
        RaiseEvent UclOpenChartNoWindowNew(UIName, ctlName, uclCodeValue)
    End Sub
    ''' <summary>
    ''' 開啟 OpenWindow 視窗
    ''' </summary>
    ''' <param name="CboName"></param>
    ''' <param name="SelectedValue"></param>
    ''' <param name="SelectedName"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclOpenComboBoxGridWindow(ByVal CboName As String, ByVal SelectedValue As String, ByVal SelectedName As String)
        RaiseEvent UclOpenComboBoxGridWindow(CboName, SelectedValue, SelectedName)
    End Sub

    ''' <summary>
    ''' 啟動 UclFinishDoAction
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclFinishDoAction(ByVal ctlName As String)
        RaiseEvent UclFinishDoAction(ctlName)
    End Sub

    ''' <summary>
    ''' 回傳目前作用中的 TreeGridView
    ''' </summary>
    ''' <param name="Flag"></param>
    ''' <remarks></remarks>
    Public Sub RaiseDEPOrderUIClosed(ByVal Flag As String)
        RaiseEvent DEPOrderUIClosed(Flag)
    End Sub

    ''' <summary>
    ''' 回傳目前作用中的 TreeGridView
    ''' </summary>
    ''' <param name="GridViewName"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclGetActiveTreeGridView(ByVal GridViewName As String)
        RaiseEvent UclGetActiveTreeGridView(GridViewName)
    End Sub

    ''' <summary>
    ''' 啟動 UclWaitingFormUI
    ''' </summary>
    ''' <param name="Action"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclWaitingForm(ByVal Action As String, ByVal Msg As String)
        RaiseEvent UclWaitingForm(Action, Msg)
    End Sub

    ''' <summary>
    ''' 啟動 UclWaitingFormUI 
    ''' </summary>
    ''' <param name="Action"></param>
    ''' <param name="Msg"></param>
    ''' <param name="LocationX"></param>
    ''' <param name="LocationY"></param>
    ''' <remarks></remarks>
    Public Sub RaiseUclWaitingForm2(ByVal Action As String, ByVal Msg As String, ByVal LocationX As Integer, ByVal LocationY As Integer)
        RaiseEvent UclWaitingForm2(Action, Msg, LocationX, LocationY)
    End Sub

    ''' <summary>
    ''' 鎖定登入視窗，True: 鎖定；False:解鎖
    ''' </summary>
    ''' <param name="LockFalg"></param>
    ''' <remarks>by Sean.Lin on 2012-11-13</remarks>
    Public Sub RaiseAPPLockWindow(ByVal LockFalg As String)
        RaiseEvent GetAPPLockWindow(LockFalg)
    End Sub

    ''' <summary>
    ''' 拋出切換使用者
    ''' </summary> 
    ''' <remarks>Copy by Sean.Lin on 2014-01-28</remarks>
    Public Sub RaiseSwitchUserEvent()
        RaiseEvent SwitchUserEvent()
    End Sub

    ''' <summary>
    ''' 授權代理
    ''' </summary> 
    ''' <remarks></remarks>
    Public Sub RaiseOpenAgentInstance(ByVal LoginUserId As String, ByVal LoginUserName As String, ByVal AgentUserId As String, ByVal AgentUserName As String, ByVal userRoleList() As String)
        RaiseEvent OpenAgentInstance(LoginUserId, LoginUserName, AgentUserId, AgentUserName, userRoleList)
    End Sub

    Public Sub RaiseOpenUIFinished()
        RaiseEvent OpenUIFinished()
    End Sub

    Public Sub RaiseImportExcel(ByVal ImportDs As DataSet)
        RaiseEvent ImportExcel(ImportDs)
    End Sub

#End Region

#End Region

#Region "   電子表單"
#Region "20130509 圖片管理共用元件PIC"

#Region "Event"

    '圖片匯入完成回傳
    Public Event PICUclFinishLoadValue(ByVal sourTypeId As String, ByVal rt As ArrayList)
    '圖片被切換
    Public Event PICUclClickImage(ByVal ctlName As String)
    '觸發按確定
    Public Event PICUclSaveButtonClick(ByVal ctlName As String)
    '觸發按取消
    Public Event PICUclCancelButtonClick(ByVal ctlName As String)
    '觸發按我的最愛
    Public Event PICUclAddFavoriteButtonClick(ByVal ctlName As String)
    '修改DataGirdViewCell值的時候
    Public Event PICUclDataGirdViewCellValueChange(ByVal ctlName As String, ByVal columnName As String, ByVal changeValue As String)
    '刪除圖片
    Public Event PICUclDeleteClick(ByVal ctlName As String)
    '呼叫視窗快取時
    Public Event PICOpenScreenShotUI(ByVal ctlName As String)
    '關閉視窗快取時
    Public Event PICCloseScreenShotUI(ByVal ctlName As String)
    '按下摺疊/展開鈕(PICViewWindowUCL)
    Public Event PICClickCollapsedButton(ByVal ctlName As String, ByVal openFlag As Boolean)
    '貼上鈕(PICViewWindowUCL)
    Public Event PICClickPasteButton(ByVal ctlName As String, ByRef okFlag As Boolean)
#End Region

#Region "Raise Event"

    '圖片匯入完成回傳
    Public Sub RaisePICUclFinishLoadValue(ByVal sourTypeId As String, ByVal rt As ArrayList)
        RaiseEvent PICUclFinishLoadValue(sourTypeId, rt)
    End Sub
    '圖片被切換
    Public Sub RaisePICUclClickImage(ByVal ctlName As String)
        RaiseEvent PICUclClickImage(ctlName)
    End Sub
    '觸發按確定
    Public Sub RaisePICUclSaveButtonClick(ByVal ctlName As String)
        RaiseEvent PICUclSaveButtonClick(ctlName)
    End Sub
    '觸發按取消
    Public Sub RaisePICUclCancelButtonClick(ByVal ctlName As String)
        RaiseEvent PICUclCancelButtonClick(ctlName)
    End Sub
    '觸發按我的最愛
    Public Sub RaisePICAddFavoriteButtonClick(ByVal ctlName As String)
        RaiseEvent PICUclAddFavoriteButtonClick(ctlName)
    End Sub
    '修改DataGirdViewCell值的時候
    Public Sub RaisePICUclDataGirdViewCellValueChange(ByVal ctlName As String, ByVal columnName As String, ByVal changeValue As String)
        RaiseEvent PICUclDataGirdViewCellValueChange(ctlName, columnName, changeValue)
    End Sub
    '修改DataGirdViewCell值的時候
    Public Sub RaisePICUclDeleteClick(ByVal ctlName As String)
        RaiseEvent PICUclDeleteClick(ctlName)
    End Sub
    '呼叫視窗快取時
    Public Sub RaisePICOpenScreenShotUI(ByVal ctlName As String)
        RaiseEvent PICOpenScreenShotUI(ctlName)
    End Sub
    '關閉視窗快取時
    Public Sub RaisePICCloseScreenShotUI(ByVal ctlName As String)
        RaiseEvent PICCloseScreenShotUI(ctlName)
    End Sub
    '按下摺疊/展開鈕(PICViewWindowUCL)
    Public Sub RaisePICClickCollapsedButton(ByVal ctlName As String, ByVal openFlag As Boolean)
        RaiseEvent PICClickCollapsedButton(ctlName, openFlag)
    End Sub
    '貼上鈕(PICViewWindowUCL)
    Public Sub RaisePICClickPasteButton(ByVal ctlName As String, Optional ByRef okFlag As Boolean = True)
        RaiseEvent PICClickPasteButton(ctlName, okFlag)
    End Sub

#End Region

#End Region

#Region "   樣板設計"

#Region "Event"

    ''' <summary>
    ''' 更新 Dgv_Property 事件
    ''' </summary>
    ''' <param name="_ctrl"></param>
    ''' <remarks></remarks>
    Public Event RefreshDgvProperty(ByRef sender As Object, ByRef _ctrl As Control)

    ''' <summary>
    ''' 選擇 Control 事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="parentForm"></param>
    ''' <param name="arySelectedCtrl"></param>
    ''' <remarks></remarks>
    Public Event SelectdToolCtrl(ByRef sender As Object, ByVal parentForm As System.Object, ByRef arySelectedCtrl As ArrayList)

    ''' <summary>
    ''' 點選控制項
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="ctrl"></param>
    ''' <remarks></remarks>
    Public Event EventSetSelectedCtrl(ByRef sender As Object, ByRef ctrl As Control)

    ''' <summary>
    ''' 完成加入控制項
    ''' </summary>
    ''' <remarks></remarks>
    Public Event AfterFinsihAddCtrl(ByRef sender As Object, ByRef ctrl As Control)

    ''' <summary>
    ''' 點選自定義控制項
    ''' </summary>
    ''' <remarks></remarks>
    Public Event SelectedUCR(ByRef sender As Object, ByRef _ctrl As Control, ByRef _ctrlName As String)

    ''' <summary>
    ''' 設定病患資料完成
    ''' </summary>
    ''' <param name="_ctrlName"></param>
    ''' <remarks></remarks>
    Public Event PatientInfoSetFinished(ByRef sender As Object, ByVal _ctrlName As String)

    ''' <summary>
    ''' 選取工具箱
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="listSelectedCtrl"></param>
    ''' <param name="IsSelected"></param>
    ''' <remarks></remarks>
    Public Event EvtSelectingToolBox(ByVal timeStamp As String, ByRef sender As Object, ByVal IsSelected As Boolean,
                                     ByRef listSelectedCtrl As ArrayList)

    ''' <summary>
    ''' 加入控制項
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="ctrl"></param>
    ''' <param name="IsAdd"></param>
    ''' <remarks></remarks>
    Public Event EvtAddCtrl2Panel(ByVal timeStamp As String, ByRef sender As Object, ByRef ctrl As Object, ByVal IsAdd As Boolean)

    ''' <summary>
    ''' 點選 / 取消點選控制項
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="IsSelected"></param>
    ''' <remarks></remarks>
    Public Event EvtSelectingCtrl(ByVal timeStamp As String, ByRef sender As Object, ByVal IsSelected As Boolean)

    ''' <summary>
    ''' 設定BaseCtrl
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name=" baseCtrl "></param>
    ''' <remarks></remarks>
    Public Event EvtSetBaseCtrl(ByVal timeStamp As String, ByRef sender As Object, ByRef baseCtrl As Object)

    ''' <summary>
    ''' 外部控制項點選控制項
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="ctrl"></param>
    ''' <param name="IsSelected"></param>
    ''' <remarks></remarks>
    Public Event EvtRaiseSelectingFromOtherCtrl(ByVal timeStamp As String, ByRef sender As Object, ByRef ctrl As Control, ByVal IsSelected As Boolean)

#End Region

#Region "Raise Event"

    ''' <summary>
    ''' 觸發更新 Dgv_Property 事件
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <remarks></remarks>
    Public Sub RaiseRefreshDgvProperty(ByRef sender As Object, ByRef ctrl As Control)
        RaiseEvent RefreshDgvProperty(sender, ctrl)
    End Sub

    ''' <summary>
    ''' 觸發選擇 Control 事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="parentForm"></param>
    ''' <param name="arySelectedCtrl"></param>
    ''' <remarks></remarks>
    Public Sub RaiseSelectdToolCtrl(ByRef sender As Object, ByVal parentForm As System.Object, ByRef arySelectedCtrl As ArrayList)
        RaiseEvent SelectdToolCtrl(sender, parentForm, arySelectedCtrl)
    End Sub

    ''' <summary>
    ''' 觸發點選控制項
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="ctrl"></param>
    ''' <remarks></remarks>
    Public Sub RaiseSetSelectedCtrl(ByRef sender As Object, ByRef ctrl As Control)
        RaiseEvent EventSetSelectedCtrl(sender, ctrl)
    End Sub

    ''' <summary>
    ''' 觸發完成加入控制項
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RaiseAfterFinsihAddCtrl(ByRef sender As Object, ByRef ctrl As Control)
        RaiseEvent AfterFinsihAddCtrl(sender, ctrl)
    End Sub

    ''' <summary>
    ''' 點選自定義控制項
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RaiseSelectedUCR(ByRef sender As Object, ByRef ctrl As Control, ByRef ctrlName As String)
        RaiseEvent SelectedUCR(sender, ctrl, ctrlName)
    End Sub

    ''' <summary>
    ''' 設定病患資料完成
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RaisePatientInfoSetFinished(ByRef sender As Object, ByVal ctrlName As String)
        RaiseEvent PatientInfoSetFinished(sender, ctrlName)
    End Sub


    ''' <summary>
    ''' 觸發-選取工具箱
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="IsSelected"></param>
    ''' <param name="listSelectedCtrl"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEvtSelectingToolBox(ByVal timeStamp As String, ByRef sender As Object, ByVal IsSelected As Boolean,
                                        ByRef listSelectedCtrl As ArrayList)
        RaiseEvent EvtSelectingToolBox(timeStamp, sender, IsSelected, listSelectedCtrl)
    End Sub

    ''' <summary>
    ''' 觸發-加入控制項
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="ctrl"></param>
    ''' <param name="IsAdd"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEvtAddCtrl2Panel(ByVal timeStamp As String, ByRef sender As Object, ByRef ctrl As Object, ByRef IsAdd As Boolean)
        RaiseEvent EvtAddCtrl2Panel(timeStamp, sender, ctrl, IsAdd)
    End Sub

    ''' <summary>
    ''' 觸發-點選 / 取消點選控制項
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="IsSelected"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEvtSelectingCtrl(ByVal timeStamp As String, ByRef sender As Object, ByVal IsSelected As Boolean)
        RaiseEvent EvtSelectingCtrl(timeStamp, sender, IsSelected)
    End Sub

    ''' <summary>
    ''' 設定 BaseCtrl
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="baseCtrl"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEvtSetBaseCtrl(ByVal timeStamp As String, ByRef sender As Object, ByVal baseCtrl As Object)
        RaiseEvent EvtSetBaseCtrl(timeStamp, sender, baseCtrl)
    End Sub

    ''' <summary>
    ''' 外部控制項點選控制項
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="ctrl"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEvtSelectingFromOtherCtrl(ByVal timeStamp As String, ByRef sender As Object,
           ByRef ctrl As Control, ByVal IsSelected As Boolean)
        RaiseEvent EvtRaiseSelectingFromOtherCtrl(timeStamp, sender, ctrl, IsSelected)
    End Sub

#End Region


#End Region

#Region "       表單填寫"

#Region "Event"

    ''' <summary>
    ''' 設定病患資料事件
    ''' </summary>
    ''' <param name="_ChartNo"></param>
    ''' <param name="_MedicalSn"></param>
    ''' <remarks></remarks>
    Public Event SetPatientData(ByRef sender As Object, ByVal _ChartNo As String, ByVal _MedicalSn As String)

    '''' <summary>
    '''' 點選檢驗項目
    '''' </summary>
    '''' <remarks></remarks>
    'Public Event SelectExamineItem()

    '''' <summary>
    '''' 預覽點選檢驗項目
    '''' </summary>
    '''' <remarks></remarks>
    'Public Event PreviewExamineItemValue()

    ''' <summary>
    ''' 設定BaseCtrl事件
    ''' </summary>
    ''' <param name="baseCtrl"></param>
    ''' <remarks></remarks>
    Public Event EventSetBaseCtrl(ByRef baseCtrl As Control)

    ''' <summary>
    ''' BtnClick
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <param name="baseCtrl">參考控制項</param>
    ''' <remarks></remarks>
    Public Event EventBtnClick(ByRef sender As System.Object, ByVal e As System.EventArgs, ByRef baseCtrl As Control)

    ''' <summary>
    ''' 設定表單記錄
    ''' </summary>
    ''' <param name="TMPId"></param>
    ''' <param name="TMPSeqNo"></param>
    ''' <param name="SeqNo"></param>
    ''' <param name="ChartNo"></param>
    ''' <remarks></remarks>
    Public Event EventSetFormRecord(ByRef sender As Object, ByVal TMPId As String, ByVal TMPSeqNo As String, ByVal SeqNo As String, ByVal ChartNo As String, ByVal MedicalSn As String)

    ''' <summary>
    ''' 選擇表單清單其中一筆紀錄
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="IsAdd">True: Add or Select ; False: Remove</param>
    ''' <param name="listObj"></param>
    ''' <remarks></remarks>
    Public Event EventSelectingFormList(ByRef sender As Object, ByVal IsAdd As Boolean, ByRef listObj As Object)

    ''' <summary>
    ''' 設定按鍵狀態
    ''' </summary>
    ''' <param name="Area"></param>
    ''' <param name="Status"></param>
    ''' <remarks></remarks>
    Public Event EventSetButtonStatus(ByRef sender As Object, ByVal Area As String, ByVal Status As Object)

    ''' <summary>
    ''' 存檔後更新清單狀態
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="TmpId"></param>
    ''' <param name="TmpSeqNo"></param>
    ''' <param name="SeqNo"></param>
    ''' <param name="ChartNo"></param>
    ''' <remarks></remarks>
    Public Event EventRefreshListStatus(ByRef sender As Object, ByVal TmpId As String, ByVal TmpSeqNo As Object,
                                        ByVal SeqNo As String, ByVal ChartNo As String)

    ''' <summary>
    ''' 設定選擇歷史紀錄
    ''' </summary>
    ''' <param name="TMPId"></param>
    ''' <param name="TMPSeqNo"></param>
    ''' <param name="SeqNo"></param>
    ''' <param name="ChartNo"></param>
    ''' <remarks></remarks>
    Public Event EventSetHistoryRecord(ByRef sender As Object, ByVal TMPId As String, ByVal TMPSeqNo As String,
                                       ByVal SeqNo As String, ByVal ChartNo As String)

    ''' <summary>
    ''' 初始化表單病人與使用者資料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="dtPatient"></param>
    ''' <param name="dtUser"></param>
    ''' <remarks></remarks>
    Public Event EventInitFormPatientAndUserData(ByRef sender As Object, ByVal dtPatient As DataTable, ByVal dtUser As DataTable)

#End Region

#Region "Raise Event"

    ''' <summary>
    ''' 觸發設定病患資料事件
    ''' </summary>
    ''' <param name="_ChartNo"></param>
    ''' <param name="_MedicalSn"></param>
    ''' <remarks></remarks>
    Public Sub RaiseSetPatientData(ByRef sender As Object, ByVal _ChartNo As String, ByVal _MedicalSn As String)
        RaiseEvent SetPatientData(sender, _ChartNo, _MedicalSn)
    End Sub


    '''' <summary>
    '''' 觸發點選檢驗項目
    '''' </summary>
    '''' <remarks></remarks>
    'Public Sub RaiseSelectExamineItem()
    '    RaiseEvent SelectExamineItem()
    'End Sub

    '''' <summary>
    '''' 觸發預覽點選檢驗項目
    '''' </summary>
    '''' <remarks></remarks>
    'Public Sub RaisePreviewExamineItemValue()
    '    RaiseEvent PreviewExamineItemValue()
    'End Sub

    ''' <summary>
    ''' 觸發設定BaseCtrl事件
    ''' </summary>
    ''' <param name="baseCtrl"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEventSetBaseCtrl(ByRef baseCtrl As Control)
        RaiseEvent EventSetBaseCtrl(baseCtrl)
    End Sub



    ''' <summary>
    ''' 觸發BtnClick
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <param name="baseCtrl">參考控制項</param>
    ''' <remarks></remarks>
    Public Sub RaiseEventBtnClick(ByRef sender As System.Object, ByVal e As System.EventArgs, ByRef baseCtrl As Control)
        RaiseEvent EventBtnClick(sender, e, baseCtrl)
    End Sub

    ''' <summary>
    ''' 設定表單記錄
    ''' </summary>
    ''' <param name="TMPId"></param>
    ''' <param name="TMPSeqNo"></param>
    ''' <param name="SeqNo"></param>
    ''' <param name="ChartNo"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEventSetFormRecord(ByRef sender As Object, ByVal TMPId As String, ByVal TMPSeqNo As String, ByVal SeqNo As String, ByVal ChartNo As String, ByVal MedicalSn As String)
        RaiseEvent EventSetFormRecord(sender, TMPId, TMPSeqNo, SeqNo, ChartNo, MedicalSn)
    End Sub


    ''' <summary>
    ''' 觸發事件- 選擇表單清單其中一筆紀錄
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="IsAdd">True: Add or Select ; False: Remove</param>
    ''' <param name="listObj"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEventSelectingFormList(ByRef sender As Object, ByVal IsAdd As Boolean, ByRef listObj As Object)
        RaiseEvent EventSelectingFormList(sender, IsAdd, listObj)
    End Sub



    ''' <summary>
    ''' 觸發事件-設定按鍵狀態
    ''' </summary>
    ''' <param name="Area"></param>
    ''' <param name="Status"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEventSetButtonStatus(ByRef sender As Object, ByVal Area As String, ByVal Status As Object)
        RaiseEvent EventSetButtonStatus(sender, Area, Status)
    End Sub

    ''' <summary>
    ''' 觸發事件-存檔後更新清單狀態
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="TmpId"></param>
    ''' <param name="TmpSeqNo"></param>
    ''' <param name="SeqNo"></param>
    ''' <param name="ChartNo"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEventRefreshListStatus(ByRef sender As Object, ByVal TmpId As String, ByVal TmpSeqNo As Object,
                                        ByVal SeqNo As String, ByVal ChartNo As String)
        RaiseEvent EventRefreshListStatus(sender, TmpId, TmpSeqNo, SeqNo, ChartNo)
    End Sub


    ''' <summary>
    ''' 設定選擇歷史紀錄
    ''' </summary>
    ''' <param name="TMPId"></param>
    ''' <param name="TMPSeqNo"></param>
    ''' <param name="SeqNo"></param>
    ''' <param name="ChartNo"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEventSetHistoryRecord(ByRef sender As Object, ByVal TMPId As String, ByVal TMPSeqNo As String,
                                       ByVal SeqNo As String, ByVal ChartNo As String)
        RaiseEvent EventSetHistoryRecord(sender, TMPId, TMPSeqNo, SeqNo, ChartNo)
    End Sub


    ''' <summary>
    ''' 初始化表單病人與使用者資料
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="dtPatient"></param>
    ''' <param name="dtUser"></param>
    ''' <remarks></remarks>
    Public Sub RaiseEventInitFormPatientAndUserData(ByRef sender As Object, ByVal dtPatient As DataTable,
                                                      ByVal dtUser As DataTable)
        RaiseEvent EventInitFormPatientAndUserData(sender, dtPatient, dtUser)
    End Sub

#End Region



#End Region
#End Region

#Region " 化療執行"

#Region " Event"

    ''' <summary>
    ''' 門診化療執行
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <param name="OutpatientSn">門診號</param>
    ''' <param name="ChemoCardSn">化療卡號</param>
    ''' <param name="ReturnDs"></param>
    ''' <remarks></remarks>
    Public Event OmoChemoExecuted(ChartNo As String, OutpatientSn As String, ChemoCardSn As String, ReturnDs As DataSet)

    ''' <summary>
    ''' 化療身高體重改變
    ''' </summary>
    '''<param name="height" ></param>
    ''' <param name="weight"></param>
    ''' <remarks></remarks>
    Public Event PatientHeightWeightChanged(ByVal height As String, ByVal weight As String)

#End Region

#Region " Raise Event"

    ''' <summary>
    ''' 化療執行完畢丟出Event
    ''' </summary>
    ''' <param name="ChartNo"></param>
    ''' <param name="OutpatientSn"></param>
    ''' <param name="ChemoCardSn"></param>
    ''' <param name="ReturnDs"></param>
    ''' <remarks></remarks>
    Public Sub RaiseOmoChemoExecuted(ChartNo As String, OutpatientSn As String, ChemoCardSn As String, ReturnDs As DataSet)

        RaiseEvent OmoChemoExecuted(ChartNo, OutpatientSn, ChemoCardSn, ReturnDs)
    End Sub


    ''' <summary>
    ''' 化療身高體重改變
    ''' </summary>
    '''<param name="height" ></param>
    ''' <param name="weight"></param>
    ''' <remarks></remarks>
    Public Sub RaisePatientHeightWeightChanged(ByVal height As String, ByVal weight As String)

        RaiseEvent PatientHeightWeightChanged(height, weight)
    End Sub

#End Region

#End Region

    ''' <summary>
    ''' 為 Compile 通過加入，日後會移除
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2014-01-24</remarks>
    Public Event CncPatientSelected(ByVal temp As DataTable)

    ''' <summary>
    ''' 啟動病患資料點選時的事件，傳入病患的DataTable
    ''' </summary>
    ''' <param name="patiDataTable"></param>
    ''' <remarks></remarks>
    Public Sub RaisCncPatientSelected(ByVal patiDataTable As DataTable)
        RaiseEvent CncPatientSelected(patiDataTable)
    End Sub
#End Region


#Region " PCSUCL"

    ''' <summary>
    ''' 病人資訊 (PCSUCLPatientInfoUC) 接收從 我的病人(PCSUCLMyPatientUI)  拋出的事件，取得病人的 Chart_No
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-11-29</remarks>
    Public Event GetPCSUCLPatientInfoChartNo(ByVal Chart_No As String)

    ''' <summary>
    ''' 病人資訊 (PCSUCLPatientInfoUC) 接收從 我的病人(PCSUCLMyPatientUI)  拋出的事件，取得病人的 資訊DS
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-02-15</remarks>
    Public Event GetPCSUCLPatientInfoDS(ByVal DS_Patient As DataSet)


    ''' <summary>
    ''' 病人資訊 (PCSUCLPatientInfoUC) 接收從 我的病人(PCSUCLMyPatientUI)  拋出的事件，取得刷新畫面 flag
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-09</remarks>
    Public Event GetPCSUCLPatientInfoRefresh(ByVal RefreshFlag As Boolean)

    ''' <summary>
    ''' 從 我的病人(PCSUCLMyPatientUI) 拋出的事件，傳出一個病人的 Chart_No
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-11-29</remarks>
    Public Sub RaisePCSUCLPatientInfoChartNo(ByVal Chart_No As String)
        RaiseEvent GetPCSUCLPatientInfoChartNo(Chart_No)
    End Sub

    ''' <summary>
    ''' 從 我的病人(PCSUCLMyPatientUI) 拋出的事件，傳出一個病人的 資訊DS
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-02-15</remarks>
    Public Sub RaisePCSUCLPatientInfoDS(ByVal DS_Patient As DataSet)
        RaiseEvent GetPCSUCLPatientInfoDS(DS_Patient)
    End Sub


    ''' <summary>
    ''' 從 我的病人(PCSUCLMyPatientUI) 拋出的事件，傳出 True 表示刷新畫面了
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-03-09</remarks>
    Public Sub RaisePCSUCLPatientInfoRefresh(ByVal RefreshFlag As Boolean)
        RaiseEvent GetPCSUCLPatientInfoRefresh(RefreshFlag)
    End Sub

#End Region

#Region "     住院"

#Region "    住院申報(IHD)"

    ''' <summary>
    '''IHD設定檢核條件作業關聯改變
    ''' </summary>
    ''' <remarks>by Charles on 2015-12-10</remarks>
    Public Sub RaiseTIhdCboRelationSelectedIndexChanged(ByVal returnBoolean As Boolean)
        RaiseEvent GetTIhdCboRelationSelectedIndexChanged(returnBoolean)
    End Sub

    ''' <summary>
    ''' 各自UI 接收從 IHD設定檢核條件作業關聯改變
    ''' </summary>
    ''' <remarks>by Charles on 2015-12-10</remarks>
    Public Event GetTIhdCboRelationSelectedIndexChanged(ByVal returnBoolean As Boolean)

#End Region

#Region "    營養供膳(NUT)"
    ''' <summary>
    ''' 灌食機管理畫面與檢核表互相傳遞資料集
    ''' </summary>
    ''' <remarks>by Rich on 2012-03-15</remarks>
    Public Event GetNUTPumpCheckListData(ByVal CheckList As DataSet)

    ''' <summary>
    ''' 營養配方查詢畫面回傳配方代號
    ''' </summary>
    ''' <remarks>by Rich on 2012-03-30</remarks>
    Public Event GetNUTFormulaIdData(ByVal Formula As DataRow)

    ''' <summary>
    ''' 營養評估儲存完成後傳遞資料表
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks>by Rich on 2012-08-27</remarks>
    Public Event UpdateSGAForAssessment(ByVal dt As DataTable)

    ''' <summary>
    ''' 灌食機管理畫面與檢核表互相傳遞資料集
    ''' </summary>
    ''' <remarks>by Rich on 2012-03-15</remarks>
    Public Sub RaiseNUTPumpCheckListData(ByVal CheckList As DataSet)
        RaiseEvent GetNUTPumpCheckListData(CheckList)
    End Sub

    ''' <summary>
    ''' 營養配方查詢畫面回傳配方代號
    ''' </summary>
    ''' <remarks>by Rich on 2012-03-30</remarks>
    Public Sub RaiseNUTFormulaIdData(ByVal Formula As DataRow)
        RaiseEvent GetNUTFormulaIdData(Formula)
    End Sub

    ''' <summary>
    ''' 營養評估儲存完成後傳遞資料表
    ''' </summary>
    ''' <remarks>by Rich on 2012-08-27</remarks>
    Public Sub RaiseUpdateSGAForAssessment(ByVal dt As DataTable)
        RaiseEvent UpdateSGAForAssessment(dt)
    End Sub
#End Region

#Region "   住院醫囑(IMO)"

    ''' <summary>
    ''' 更新使用中醫囑清單及醫囑清單
    ''' </summary>
    ''' <remarks>by Charles 2016-01-28</remarks>
    Public Event GetIMOOrderUsingOrderListRefresh()

    ''' <summary>
    ''' 更新使用中醫囑及醫囑清單
    ''' </summary>
    ''' <remarks>by Charles 2016-01-28</remarks>
    Public Sub RaiseIMOOrderUsingOrderListRefresh()
        RaiseEvent GetIMOOrderUsingOrderListRefresh()
    End Sub

    ''' <summary>
    ''' 呼叫化療處方確認執行功能
    ''' </summary>
    ''' <remarks>by Will 2016-06-22</remarks>
    Public Event GetOmoChemoOrderListForExecutionDialog()

    ''' <summary>
    ''' 呼叫化療處方確認執行功能
    ''' </summary>
    ''' <remarks>by Will 2016-06-22</remarks>
    Public Sub RaiseOmoChemoOrderListForExecutionDialog()
        RaiseEvent GetOmoChemoOrderListForExecutionDialog()
    End Sub

#End Region

#End Region

#Region " AMR  By Rudolf"

    ''' <summary>
    ''' 複製入院病摘樣版到病摘
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Event GetAMRAdmissionTemplateToNote(ByVal itemObj As Object, ByVal obj As Object)
    ''' <summary>
    ''' 複製病程病摘樣版到病摘
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Event GetAMRProgressTemplateToNote(ByVal obj As Object)
    ''' <summary>
    ''' 複製出院病摘樣版到病摘
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Event GetAMRDischargeTemplateToNote(ByVal itemObj As Object, ByVal obj As Object)
    ''' <summary>
    ''' 複製其他病摘樣版到病摘
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Event GetAMROtherTemplateToNote(ByVal obj As Object)
    ''' <summary>
    ''' 複製病程病摘紀錄到病摘
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Event GetAMRProgressRecordToNote(ByVal obj As Object)
    ''' <summary>
    ''' 複製其他病摘紀錄到病摘
    ''' </summary>
    ''' <param name="_digestTypeId">病摘種類</param>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Event GetAMROtherRecordToNote(ByVal _digestTypeId As String, ByVal obj As Object)
    ''' <summary>
    ''' 複製病程病摘紀錄到病摘範本
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Event GetAMRSaveProgressRecordToTemplate(ByVal obj As Object)
    ''' <summary>
    ''' 複製其他病摘紀錄到病摘範本
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Event GetAMRSaveOtherRecordToTemplate(ByVal obj As Object)
    ''' <summary>
    ''' 複製手術紀錄紀錄到病摘
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks>by Rudolf on 2012-04-02</remarks>
    Public Event GetAMROperationRecordToNote(ByVal obj As Object)
    ''' <summary>
    '''  複製評論和其他病摘紀錄到病摘範本
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Event GetAMRSaveCommentsToTemplate(ByVal obj As Object)
#End Region

#Region " AMR  By Yaya"
    ''' <summary>
    ''' 載入問題表列資料
    ''' </summary>
    ''' <param name="owner">判斷是否要接收Event</param>
    ''' <param name="dt_Problem">問題表列物件</param>
    ''' <remarks>By Yaya on 2012-07-22</remarks>
    Public Event LoadProblemListData(ByVal owner As String, ByVal dt_Problem As DataTable)
#End Region

#Region " AMR By Rudolf"

    ''' <summary>
    ''' 複製入院病摘樣版到病摘
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub RaiseGetAMRAdmissionTemplateToNote(ByVal itemObj As Object, ByVal obj As Object)
        RaiseEvent GetAMRAdmissionTemplateToNote(itemObj, obj)
    End Sub
    ''' <summary>
    ''' 複製病程病摘樣版到病摘
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub RaiseGetAMRProgressTemplateToNote(ByVal obj As Object)
        RaiseEvent GetAMRProgressTemplateToNote(obj)
    End Sub
    ''' <summary>
    ''' 複製出院病摘樣版到病摘
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub RaiseGetAMRDischargeTemplateToNote(ByVal itemObj As Object, ByVal obj As Object)
        RaiseEvent GetAMRDischargeTemplateToNote(itemObj, obj)
    End Sub
    ''' <summary>
    ''' 複製其他病摘樣版到病摘
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub RaiseGetAMROtherTemplateToNote(ByVal obj As Object)
        RaiseEvent GetAMROtherTemplateToNote(obj)
    End Sub
    ''' <summary>
    ''' 複製病程紀錄到病摘
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub RaiseGetAMRProgressRecordToNote(ByVal obj As Object)
        RaiseEvent GetAMRProgressRecordToNote(obj)
    End Sub
    ''' <summary>
    ''' 複製其他病摘紀錄到病摘
    ''' </summary>
    ''' <param name="_digestTypeId">病摘種類</param>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub RaiseGetAMROtherRecordToNote(ByVal _digestTypeId As String, ByVal obj As Object)
        RaiseEvent GetAMROtherRecordToNote(_digestTypeId, obj)
    End Sub
    ''' <summary>
    ''' 複製病程病摘紀錄到病摘範本
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub RaiseGetAMRSaveProgressRecordToTemplate(ByVal obj As Object)
        RaiseEvent GetAMRSaveProgressRecordToTemplate(obj)
    End Sub
    ''' <summary>
    ''' 複製其他病摘紀錄到病摘範本
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub RaiseGetAMRSaveOtherRecordToTemplate(ByVal obj As Object)
        RaiseEvent GetAMRSaveOtherRecordToTemplate(obj)
    End Sub
    ''' <summary>
    ''' 複製手術紀錄紀錄到病摘
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks>by Rudolf on 2012-04-02</remarks>
    Public Sub RaiseGetAMROperationRecordToNote(ByVal obj As Object)
        RaiseEvent GetAMROperationRecordToNote(obj)
    End Sub
    ''' <summary>
    ''' 複製評論和其他病摘紀錄到病摘範本
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub RaiseGetAMRSaveCommentsToTemplate(ByVal obj As Object)
        RaiseEvent GetAMRSaveCommentsToTemplate(obj)
    End Sub
#End Region

#Region "AMR Yaya"
    ''' <summary>
    ''' 載入問題表列資料
    ''' </summary>
    ''' <param name="owner">判斷是否要接收Event</param>
    ''' <param name="dt_Problem">問題表列物件</param>
    ''' <remarks>By Yaya on 2012-07-22</remarks>
    Public Sub RaiseLoadProblemListData(ByVal owner As String, ByVal dt_Problem As DataTable)
        RaiseEvent LoadProblemListData(owner, dt_Problem)
    End Sub
#End Region

#Region "OMO Jun"
    ''' <summary>
    ''' 更新身高
    ''' </summary>
    ''' <param name="value">身高數值</param>
    ''' <remarks>By Jun on 2016-09-30</remarks>
    Public Event HeightChanged(ByVal value As String)
    ''' <summary>
    ''' 更新身高
    ''' </summary>
    ''' <param name="value">身高數值</param>
    ''' <remarks>By Jun on 2016-09-30</remarks>
    Public Sub RaiseHeightChanged(ByVal value As String)
        RaiseEvent HeightChanged(value)
    End Sub
    ''' <summary>
    ''' 更新體重
    ''' </summary>
    ''' <param name="value">體重數值</param>
    ''' <remarks>By Jun on 2016-09-30</remarks>
    Public Event WeightChanged(ByVal value As String)
    ''' <summary>
    ''' 更新體重
    ''' </summary>
    ''' <param name="value">體重數值</param>
    ''' <remarks>By Jun on 2016-09-30</remarks>
    Public Sub RaiseWeightChanged(ByVal value As String)
        RaiseEvent WeightChanged(value)
    End Sub
#End Region


#Region "     JOBAPP"

    Public Event ProjectModified()
    Public Sub RaiseProjectModified()
        RaiseEvent ProjectModified()
    End Sub

    Public Event ReceiveReportName(ByVal tag As String, ByVal Report_Id As String)

    Public Sub RaiseReportIdEvent(ByVal tag As String, ByVal Report_Name As String)
        RaiseEvent ReceiveReportName(tag, Report_Name)
    End Sub

#Region "     QA專案改變"

    Public Event ReceiveProjectChanged(ByVal ProjectId As String)

    Public Sub RaiseProjectChangedEvent(ByVal ProjectId As String)
        RaiseEvent ReceiveProjectChanged(ProjectId)
    End Sub

#End Region

#Region "     JobQACreateNewJobUC GridCellClick"

    Public Event JobQACreateNewJobUC_GridCellClick(ByVal dr As DataRow)

    Public Sub RaiseJobQACreateNewJobUC_GridCellClick(ByVal dr As DataRow)
        RaiseEvent JobQACreateNewJobUC_GridCellClick(dr)
    End Sub

#End Region

#Region "     CreateNewBug"

    Public Event JobQACreateNewBugUC_CreateNewBug(sender As Object, e As EventArgs)

    Public Sub RaiseJobQACreateNewJobUC_CreateNewBug(sender As Object, e As EventArgs)
        RaiseEvent JobQACreateNewBugUC_CreateNewBug(sender, e)
    End Sub

#End Region

#Region "     BugStatusModifiy"
    Public Event JobQACheckBugHistoryUI_StatusModified()

    Public Sub RaiseJobQACheckBugHistoryUI_StatusModified()
        RaiseEvent JobQACheckBugHistoryUI_StatusModified()
    End Sub

#End Region

#End Region
End Class
