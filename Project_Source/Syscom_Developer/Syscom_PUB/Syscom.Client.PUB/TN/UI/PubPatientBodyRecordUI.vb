'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病人身高體重登記作業
'*              Title:	PubPatientBodyRecordUI
'*        Description:	1.新增 2.修改 3.刪除 4.查詢 5.清除
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sharon.Du
'*        Create Date:	2015-07-14
'*      Last Modifier:	Sharon.Du
'*   Last Modify Date:	2015-07-14
'*
'*****************************************************************************
'*/

Imports System.Text

Imports Syscom.Client.CMM
Imports Syscom.Client.UCL.UCLScreenUtil
Imports Syscom.Client.UCL
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Comm.Utility.DataSetUtil
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.Servicefactory

'請修改成 TableFactory 所在的Utility
'Imports NIS.Comm.TableFactory

'請修改成使用到的Servicefactory
'Imports NIS.Client.ServiceFactory


Public Class PubPatientBodyRecordUI
    Inherits IUCLMaintainFormUI

#Region "     變數宣告 "

#Region "     *Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = PubPatientBodyRecordDataTableFactory.columnsName

    '存檔的Table Name
    Private gblTableName As String = PubPatientBodyRecordDataTableFactory.tableName

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = PubPatientBodyRecordDataTableFactory.getDataTable

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "病歷號,測量時間,身高,體重,脈搏,呼吸,體溫,收縮壓,舒張壓,建立者,建立時間,來源別,登錄單位"

    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "0,0,0,0,0,0,0,0,0,0,0,0"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1,2,3,4,5,6,7,8,9,10"

    Private Chart_No As String = ""
    '*******************************************************************************

#End Region

#Region "     *使用的service宣告 "

    '*******************************************************************************
    '依呼叫的 service 修改    ******************************************************
    '*******************************************************************************

    '定義使用的service介面
    Dim Pub As IPubServiceManager

    '*******************************************************************************

#End Region

#End Region

#Region "     主要功能 "

#Region "     *按鈕事件 "

#Region "     *新增 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Sharon.Du on 2015-7-14</remarks>
    Public Overrides Function InsertData() As Boolean

        Try
            Dim returnBoolean As Boolean = False

            Dim iButtonFlag As Integer = buttonAction.INSERT

            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If
           
            '新增，建立者與修改者為同一人
            Dim InsertDS As DataSet = GetSaveDS(CurrentUserID, CurrentUserID)


            If CheckHasValue(InsertDS) Then
                Dim count As Integer = Pub.PubPatientBodyRecordinsert(InsertDS)
                '*******************************************************************************
                '修改 insert 的 Method *********************************************************
                '*******************************************************************************

                '拿掉註解，修改 Insert 方法即可，修改完成後拿掉此行註解 
                '寫入資料庫



                '*******************************************************************************




                '有寫入資料要回傳True
                If count > 0 Then

                    returnBoolean = True




                    '******************************************************************************
                    '修改  ************************************************************************
                    '******************************************************************************


                    '拿掉註解，修改查詢ByPK 方法即可，修改完成後拿掉此行註解 
                    '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                    updateDataGridView(iButtonFlag, Pub.PubPatientBodyRecordqueryByPK(nvl(txt_Chart_No.uclCodeValue1), (dtp_Measure_Time.GetUsDateStr).Replace("/", "-") + " " + nvl(txt_Measure_Time.Text)))

                    '*******************************************************************************




                End If
            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
            Return False
        End Try

    End Function

#End Region

#Region "     *修改 "

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Sharon.Du on 2015-7-14</remarks>
    Public Overrides Function updateData() As Boolean

        Dim returnBoolean As Boolean = False

        Dim iButtonFlag As Integer = buttonAction.UPDATE

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '修改，建立者與修改者為不同人
            Dim updateDS As DataSet = GetSaveDS(globalCreateUser, CurrentUserID)




            '*******************************************************************************
            '修改 update 的 Method *********************************************************
            '*******************************************************************************

            '拿掉註解，修改 Update 方法即可，修改完成後拿掉此行註解 
            '寫入資料庫
            Dim count As Integer = Pub.PubPatientBodyRecordupdate(updateDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True




                '*******************************************************************************
                '修改  *************************************************************************
                '*******************************************************************************

                '拿掉註解，修改查詢ByPK 方法即可，修改完成後拿掉此行註解 
                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                updateDataGridView(iButtonFlag, Pub.PubPatientBodyRecordqueryByPK(nvl(txt_Chart_No.uclCodeValue1), (dtp_Measure_Time.GetUsDateStr).Replace("/", "-") + " " + nvl(txt_Measure_Time.Text)))

                '*******************************************************************************




            Else

                '無資料被修改
                MessageHandling.ShowWarnMsg("CMMCMMB310", New String() {"修改"})
                returnBoolean = True

            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB913", ex)
        End Try

    End Function

#End Region

#Region "     *刪除 "

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Sharon.Du on 2015-7-14</remarks>
    Public Overrides Function deleteData() As Boolean

        Dim returnBoolean As Boolean

        Dim iButtonFlag As Integer = buttonAction.DELETE

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If




            '*******************************************************************************
            '修改  *************************************************************************
            '*******************************************************************************


            '拿掉註解，修改刪除ByPK 方法即可，修改完成後拿掉此行註解 
            '自資料庫刪除
            Dim count As Integer = Pub.PubPatientBodyRecorddelete(nvl(txt_Chart_No.uclCodeValue1), (dtp_Measure_Time.GetUsDateStr).Replace("/", "-") + " " + nvl(txt_Measure_Time.Text))
            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                '拿掉註解，修改 清除的控制項 即可，修改完成後拿掉此行註解 
                '刪除成功，清除控制項
                'CleanControls(tlp_Main)

            Else
                '無符合條件資料被刪除
                MessageHandling.ShowWarnMsg("CMMCMMB310", New String() {"刪除"})
                returnBoolean = True

            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB914", ex)
        End Try

    End Function

#End Region

#Region "     *查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Sharon.Du on 2015-7-14</remarks>
    Public Overrides Function queryData() As Boolean

        Dim returnBoolean As Boolean

        Dim iButtonFlag As Integer = buttonAction.QUERY

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '查詢成功後儲存的 DS
            Dim queryDS As DataSet



            '*******************************************************************************
            '修改  *************************************************************************
            '*******************************************************************************

            '拿掉註解，修改查詢 方法即可，查詢若不只一種，請自行增加 if 判斷式，修改完成後拿掉此行註解 
            '查詢 
            queryDS = Pub.PubPatientBodyRecordqueryPubPatientBodyrecordByCond("O", "CNC", nvl(txt_Chart_No.uclCodeValue1))


            '*******************************************************************************




            '有查到 Table 要回傳True
            If CheckHasTable(queryDS) Then

                '如果資料列為零要顯示查無符合條件資料
                If queryDS.Tables(0).Rows.Count = 0 Then

                    MessageHandling.ShowWarnMsg("CMMCMMB933", New String() {})

                End If

                '顯示資料在 Grid 上
                UCLScreenUtil.ShowDgv(dgvShowData, queryDS, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)

                returnBoolean = True

            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB915", ex)
        End Try

    End Function

#End Region

#Region "     *清除 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <remarks>by Sharon.Du on 2015-7-14</remarks>
    Public Overrides Sub clearData()

        Try
            dgvShowData.ClearDS()

            '*******************************************************************************
            '如果上方的TableLayputPanel 命名為 tlp_Main 則不用修改  ************************
            '*******************************************************************************

            '拿掉註解，修改 清除的控制項 即可，修改完成後拿掉此行註解 
            '清除傳入控制項的所有內含的控制項
            CleanControls(tlp_Main)

            '*******************************************************************************


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB916", ex)
        End Try

    End Sub

#End Region

#End Region

#End Region

#Region "     內部功能 "

#Region "     *初始化設定 "



#Region "     *初始化 - 畫面 - 繼承UCLMaintainUI "

    Sub New(Optional ByVal Chart_No As String = "")

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Me.Chart_No = Chart_No
    End Sub

    ''' <summary>
    ''' 初始化畫面 - 繼承UCLMaintainUI
    ''' </summary>
    ''' <remarks>by Sharon.Du on 2015-7-14</remarks>
    Public Overrides Sub initialData()

        Try

            '載入服務管理員
            LoadServiceManager()

            '初始化 - DataGridView
            ShowDgv()

            '*******************************************************************************
            '修改 初始化的Combox 沒有則不需要 **********************************************
            '*******************************************************************************

            '初始化 - ComboBox
            initialComboBox()

            '*******************************************************************************




        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region

#Region "     顯示空的Dataset 在　Grid 上 "

    ''' <summary>
    ''' 顯示空的Dataset 在　Grid 上
    ''' </summary>
    ''' <remarks>by Sharon.Du on 2015-7-14</remarks>
    Private Sub ShowDgv()

        Try

            '顯示空的Dataset 在　Grid 上
            UCLScreenUtil.ShowDgv(dgvShowData, gblEmptyDT, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - DataGridView"})
        End Try

    End Sub

#End Region

#Region "     *初始化 - ComboBox "

    ''' <summary>
    ''' 初始化 - ComboBox
    ''' </summary>
    ''' <remarks>by Sharon.Du on 2015-7-14</remarks>
    Private Sub initialComboBox()

        Try

            '***********************************************************************************************************
            '視需要進行修改，如果一次要取得多個 ComboBox，請取一個DS 回來，內包含各個DataTable，不可呼叫WCF多次 ********
            '***********************************************************************************************************

            '取得 Combobox的 資料
            'Dim cboDS As DataSet = IPH.IPHMedDeployListQueryCboData()

            '檢查資料來源
            'If CheckHasTable(cboDS, "PUB_Station") Then

            '設定資料來源
            'UclCbo_StationNo.Initial(cboDS.Tables("PUB_Station"), "ShowField", "ValueField")

            'End If

            '檢查資料來源
            'If CheckHasTable(cboDS, "PUB_Syscode") Then

            '設定資料來源
            'UclCbo_PrintTime.Initial(cboDS.Tables("PUB_Syscode"), "ShowField", "ValueField")

            'End If

            '檢查資料來源
            'If CheckHasTable(cboDS, "OPH_Printer_Setup") Then

            '設定資料來源
            'UclCbo_PrinterCode.Initial(cboDS.Tables("OPH_Printer_Setup"), "ShowField", "ValueField")

            'End If

            '**********************************************************************************************************

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - ComboBox"})
        End Try

    End Sub

#End Region

#Region "     *載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Sharon.Du on 2015-7-14</remarks>
    Private Sub LoadServiceManager()
        Try



            '*******************************************************************************
            '根據系統別進行修改  ***********************************************************
            '*******************************************************************************

            Pub = PubServiceManager.getInstance()

            '*******************************************************************************




        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"載入服務管理員"})
        End Try

    End Sub

#End Region

#End Region

#Region "     *欄位檢查 "

#Region "     *欄位檢查 - True 檢查不通過;False 檢查通過 "

    ''' <summary>
    ''' 欄位檢查 - True 檢查不通過;False 檢查通過
    ''' </summary>
    ''' <remarks>by Sharon.Du on 2015-7-14</remarks>
    Public Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean

        Dim returnBoolean As Boolean = False

        '儲存要顯示 Error 字串
        Dim stbErrorCollection As StringBuilder = New StringBuilder

        Try



            '*******************************************************************************
            '如果上方的TableLayputPanel 命名為 tlp_Main 則不用修改  ************************
            '*******************************************************************************

            '拿掉註解，修改 清除欄位底色的控制項 即可，修改完成後拿掉此行註解 
            '清除傳入控制項的所有內含的控制項的欄位底色
            '清除欄位底色
            CleanControlsBackcolor(tlp_Main)

            '*******************************************************************************



            '*******************************************************************************************************************
            '修改成要設定檢查的控制項、檢查未通過的顯示名稱 EX: 護理站未輸入 只要設定成 [護理站] 即可  *************************
            '本檢查只會檢查有沒有值，如果是其他的檢查需求，須另行增加!  ********************************************************
            '*******************************************************************************************************************

            '設定檢查的控制項、檢查未通過的顯示名稱
            Dim objCheck1 As UCLTextCodeQueryUI = txt_Chart_No
            Dim errorStr1 As String = "病歷號、"
             
            Dim objCheck2 As UCLDateTimePickerUC = dtp_Measure_Time
            Dim errorStr2 As String = "測量日期、"

            Dim objCheck3 As TextBox = txt_Measure_Time
            Dim errorStr3 As String = "測量時間、"

            Dim objCheck4 As TextBox = txt_Height
            Dim errorStr4 As String = "身高、"
             
            Dim objCheck5 As TextBox = txt_Weight
            Dim errorStr5 As String = "體重、"


            '*******************************************************************************************************************




            Select Case iButtonFlag

                '新增/修改時的檢查
                Case buttonAction.INSERT, buttonAction.UPDATE
                     

                    '*********************************************************************************************************************
                    '設定新增/修改要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ***************************
                    '*********************************************************************************************************************

                    '病歷號 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)

                    '測量日期 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck2, errorStr2, stbErrorCollection, returnBoolean)
                     
                    '測量時間 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck3, errorStr3, stbErrorCollection, returnBoolean)

                    '身高 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck4, errorStr4, stbErrorCollection, returnBoolean)

                    '體重 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck5, errorStr5, stbErrorCollection, returnBoolean)

 
                    '*********************************************************************************************************************
                     

                    '刪除時的檢查
                Case buttonAction.DELETE



                    '*********************************************************************************************************************
                    '設定刪除要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ********************************
                    '*********************************************************************************************************************

                    '護理站 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)

                    '測量日期 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck2, errorStr2, stbErrorCollection, returnBoolean)

                    '測量時間 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck3, errorStr3, stbErrorCollection, returnBoolean)

                    '*********************************************************************************************************************




                    '查詢時的檢查
                Case buttonAction.QUERY

                    '*********************************************************************************************************************
                    '設定查詢要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ********************************
                    '*********************************************************************************************************************

                    '護理站 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)
                    '*********************************************************************************************************************


            End Select

            '欄位check錯誤
            If returnBoolean Then

                Dim finalErrorString As String = stbErrorCollection.ToString

                '有值
                If finalErrorString.Length > 0 Then

                    '去掉最後一個逗號
                    finalErrorString = finalErrorString.Substring(0, finalErrorString.Length - 1)

                    finalErrorString = finalErrorString & "不得為空"

                    MessageHandling.ShowErrorMsg("CMMCMMB300", finalErrorString)

                End If

            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"欄位檢查 - True 檢查不通過;False 檢查通過"})
        End Try

    End Function

#End Region

#End Region

#Region "     *資料被點選時的相應動作 "

    ''' <summary>
    ''' 資料被點選時的相應動作
    ''' </summary>
    ''' <remarks>by Sharon.Du on 2015-7-14</remarks>
    Public Overrides Sub dgvCellClick()

        Try



            '********************************************************************************
            '如果上方的TableLayputPanel 命名為 tlp_Main 則不用修改  *************************
            '********************************************************************************

            '拿掉註解，修改 清除欄位底色的控制項 即可，修改完成後拿掉此行註解 
            '清除傳入控制項的所有內含的控制項的欄位底色
            '清除欄位背景顏色
            CleanControlsBackcolor(tlp_Main)
            '********************************************************************************




            '被點選的資料列大於零，才執行動作
            If dgvShowData.CurrentCellAddress.Y >= 0 Then



                '*************************************************************************************************************************
                '設定點選後，畫面上方要跟著異動的控制項，譬如說 TextBox 的文字，Combobox 的 select Value *********************************
                '*************************************************************************************************************************


                '{ Station_No,Print_Time,Printer_Code,Create_User,Create_Time,Modified_User ,Modified_Time   }
                '設定病歷號的控制項
                txt_Chart_No.uclCodeValue1 = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Chart_No").Value)
                txt_Chart_No.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Chart_No").Value)

                '設定測量時間的控制項
                dtp_Measure_Time.Text = CDate(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Measure_Time").Value).ToString("yyy/MM/dd")
                'nvl(dtp_Measure_Time.GetUsDateStr) + " " + nvl(txt_Measure_Time.Text)

                txt_Measure_Time.Text = CDate(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Measure_Time").Value).ToString("HH:mm:ss")

                '設定身高的控制項
                txt_Height.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Height").Value)

                '設定體重的控制項
                txt_Weight.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Weight").Value)

                '設定脈搏的控制項
                txt_Pulse.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Pulse").Value)

                '設定呼吸的控制項
                txt_Breath.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Breath").Value)

                '設定體溫的控制項
                txt_Temperature.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Temperature").Value)

                '設定收縮壓的控制項
                txt_Blood_Pressure.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Blood_Pressure").Value)

                '設定舒張壓的控制項
                txt_Blood_Diastolic.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Blood_Diastolic").Value)

                '設定建立者的資料 - 必須要填寫!
                globalCreateUser = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Create_User").Value)

                '*************************************************************************************************************************




            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"資料被點選時的相應動作"})
        End Try

    End Sub

#End Region

#Region "     *取得要存檔的Dataset "

    ''' <summary>
    ''' 取得要存檔的Dataset
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Sharon.Du on 2015-7-14</remarks>
    Private Function GetSaveDS(ByVal inputCreateUser As String, ByVal inputModifiedUser As String) As DataSet

        Dim returnDataSet As DataSet

        Try

            '產生要存檔的Dataset
            returnDataSet = GenDataSet(gblTableName, gblColumnNameDB)

            Dim drSave As DataRow = returnDataSet.Tables(gblTableName).NewRow()


            '*************************************************************************************************************************
            '設定 要儲存的資料 *******************************************************************************************************
            '*************************************************************************************************************************

            '{ Station_No,Print_Time,Printer_Code,Create_User,Create_Time,Modified_User ,Modified_Time   }
            'EX: drSave("Station_No") = nvl(UclCbo_StationNo.SelectedValue)

            'EX: drSave("Print_Time") = nvl(UclCbo_PrintTime.SelectedValue.ToString)

            'EX: drSave("Printer_Code") = nvl(UclCbo_PrinterCode.SelectedValue.ToString)
            If dtp_Measure_Time.GetUsDateStr = "" Then
                ShowWarnMsg("CMMCMMB300", "請輸入日期!")
            ElseIf txt_Measure_Time.Text = "" Then
                ShowWarnMsg("CMMCMMB300", "請輸入時間!")
            ElseIf nvl(txt_Height.Text) = "" Then
                ShowWarnMsg("CMMCMMB300", "請輸入身高!")
            ElseIf nvl(txt_Weight.Text) = "" Then
                ShowWarnMsg("CMMCMMB300", "請輸入體重!")
            Else
                drSave("Chart_No") = txt_Chart_No.uclCodeValue1
                Dim Measure_time As String = (dtp_Measure_Time.GetUsDateStr).Replace("/", "-") + " " + nvl(txt_Measure_Time.Text)
                drSave("Measure_Time") = Measure_time
                drSave("Height") = nvl(txt_Height.Text)
                drSave("Weight") = nvl(txt_Weight.Text)
                If nvl(txt_Pulse.Text) = "" Then
                    drSave("Pulse") = Nothing
                Else
                    drSave("Pulse") = nvl(txt_Pulse.Text)
                End If
                If nvl(txt_Breath.Text) = "" Then
                    drSave("Breath") = Nothing
                Else
                    drSave("Breath") = nvl(txt_Breath.Text)
                End If
                If nvl(txt_Temperature.Text) = "" Then
                    drSave("Temperature") = Nothing
                Else
                    drSave("Temperature") = nvl(txt_Temperature.Text)
                End If
                If nvl(txt_Blood_Pressure.Text) = "" Then
                    drSave("Blood_Pressure") = Nothing
                Else
                    drSave("Blood_Pressure") = nvl(txt_Blood_Pressure.Text)
                End If
                If nvl(txt_Blood_Diastolic.Text) = "" Then
                    drSave("Blood_Diastolic") = Nothing
                Else
                    drSave("Blood_Diastolic") = nvl(txt_Blood_Diastolic.Text)
                End If
                drSave("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                drSave("Source_Type_Id") = "O"
                drSave("Keyin_Unit") = "CNC"
                drSave("Create_User") = inputCreateUser
                'drSave("Modified_User") = inputModifiedUser

                '*************************************************************************************************************************

                'Create_Time 後端會自動產生

                'Modified_Time 後端會自動產生


                returnDataSet.Tables(gblTableName).Rows.Add(drSave)


            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得要存檔的Dataset"})
        End Try

        Return returnDataSet
    End Function

#End Region

#End Region





    Private Sub txt_Measure_Time_TextChanged(sender As Object, e As EventArgs) Handles txt_Measure_Time.TextChanged
        If txt_Measure_Time.Text.Length = 4 Then
            txt_Measure_Time.Text = String.Format("{0}:{1}", txt_Measure_Time.Text.Substring(0, 2), txt_Measure_Time.Text.Substring(2, 2))
        End If
    End Sub

    Private Sub PubPatientBodyRecordUI_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Chart_No <> "" Then
            txt_Chart_No.ProcessQuery(Chart_No)
            queryData()
        End If
    End Sub
 

End Class

