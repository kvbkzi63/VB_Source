'/*
'*****************************************************************************
'*
'*    Page/Class Name:  檢驗表單維護
'*              Title:	PUBLisSheetUI
'*        Description:	1.新增 2.修改 3.刪除 4.查詢 5.清除
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Kaiwen,Hsiao
'*        Create Date:	2016-04-25
'*      Last Modifier:	Kaiwen,Hsiao
'*   Last Modify Date:	2016-04-25
'*
'*****************************************************************************
'*/

Imports System.Text

Imports Syscom.Client.CMM
Imports Syscom.Client.UCL.UCLScreenUtil
Imports Syscom.Client.UCL

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


Public Class PUBLisSheetUI
    Inherits IUCLMaintainFormUI

#Region "     變數宣告 "

#Region "     Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = PubSheetDataTableFactory.columnsName
    'Private gblColumnNameDB As String() = {"Sheet_Code", "Sheet_Name", "Dept_Code", "Is_Emergency_Sheet", "Is_Indication", "Is_Print_Indication", "Sheet_Collect_Note", "Sheet_Note", "Sheet_Contect_Tel", "Sheet_Type_Id", "Lis_Sheet_Limit_Cnt", "Sheet_Sort_Value", "Dc", "Create_User", "Create_Time"}

    '存檔的Table Name
    Private gblTableName As String = PubSheetDataTableFactory.tableName

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = PubSheetDataTableFactory.getDataTable

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "表單代碼,表單名稱,執行科別,是否為急作單,是否有特殊屬性控制,是否列印Indication內容於申請單上,開單/採檢注意事項,表單注意事項,表單類別,檢驗申請單限制筆數,顯示排列順序,停用,建立者,建立時間,修改者,修改時間,是否印申請單,檢驗組別,報表抬頭,表單簡稱,應完成時數(開單-簽收),應完成時數(簽收-確認),IO類別,應完成時數(開單-確認)"  ' Elly Add 表單注意事項 on 2016/10/09

    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "60,150,60,80,150,300,150,110,80,120,120,120,50,60,60,70,100,60,60,110,130,130,100,130"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1,2,3,7,11,20,21,22,23" ' 7  Elly Add 表單注意事項 on 2016/10/09

    '*******************************************************************************

#End Region

#Region "     使用的service宣告 "

    '*******************************************************************************
    '依呼叫的 service 修改    ******************************************************
    '*******************************************************************************

    '定義使用的service介面
    Dim Pub As IPubServiceManager

    '*******************************************************************************

#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     新增 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2016-4-25</remarks>
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



            '*******************************************************************************
            '修改 insert 的 Method *********************************************************
            '*******************************************************************************

            '拿掉註解，修改 Insert 方法即可，修改完成後拿掉此行註解 
            '寫入資料庫
            Dim count As Integer = Pub.PubLisSheetInsert(InsertDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True


                '******************************************************************************
                '修改  ************************************************************************
                '******************************************************************************


                '拿掉註解，修改查詢ByPK 方法即可，修改完成後拿掉此行註解 
                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                updateDataGridView(iButtonFlag, Pub.PubSheetQueryByPK(txt_SheetCode.Text.ToString.Trim, txt_SheetName.Text.ToString.Trim, cbo_DeptCode.SelectedValue))

                '*******************************************************************************

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
    ''' <remarks>by Kaiwen,Hsiao on 2016-4-25</remarks>
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
            Dim count As Integer = Pub.PubLisSheetUpdate(updateDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True




                '*******************************************************************************
                '修改  *************************************************************************
                '*******************************************************************************

                '拿掉註解，修改查詢ByPK 方法即可，修改完成後拿掉此行註解 
                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                updateDataGridView(iButtonFlag, Pub.PubSheetQueryByPK(txt_SheetCode.Text.ToString.Trim, txt_SheetName.Text.ToString.Trim, cbo_DeptCode.SelectedValue))

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

#Region "     刪除 "

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2016-4-25</remarks>
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
            Dim count As Integer = Pub.PubLisSheetDelete(txt_SheetCode.Text.ToString.Trim)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                '拿掉註解，修改 清除的控制項 即可，修改完成後拿掉此行註解 
                '刪除成功，清除控制項
                CleanControls(tlp_Main)

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

#Region "     查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2016-4-25</remarks>
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
            queryDS = Pub.PubSheetQueryByLikePK(txt_SheetCode.Text.ToString.Trim)


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

#Region "     清除 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <remarks>by Kaiwen,Hsiao on 2016-4-25</remarks>
    Public Overrides Sub clearData()

        Try


            '*******************************************************************************
            '如果上方的TableLayputPanel 命名為 tlp_Main 則不用修改  ************************
            '*******************************************************************************

            '拿掉註解，修改 清除的控制項 即可，修改完成後拿掉此行註解 
            '清除傳入控制項的所有內含的控制項
            CleanControls(tlp_Main)
            dgvShowData.ClearDS()
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

#Region "     初始化設定 "

#Region "     初始化 - 畫面 - 繼承UCLMaintainUI "

    ''' <summary>
    ''' 初始化畫面 - 繼承UCLMaintainUI
    ''' </summary>
    ''' <remarks>by Kaiwen,Hsiao on 2016-4-25</remarks>
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
            initalSpicemenType()

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
    ''' <remarks>by Kaiwen,Hsiao on 2016-4-25</remarks>
    Private Sub ShowDgv()

        Try

            UCLScreenUtil.ShowDgv(dgvShowData, gblEmptyDT, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - DataGridView"})
        End Try

    End Sub

#End Region

#Region "     初始化 - ComboBox "

    ''' <summary>
    ''' 初始化 - ComboBox
    ''' </summary>
    ''' <remarks>by Kaiwen,Hsiao on 2016-4-25</remarks>
    Private Sub initialComboBox()

        Try

            '***********************************************************************************************************
            '視需要進行修改，如果一次要取得多個 ComboBox，請取一個DS 回來，內包含各個DataTable，不可呼叫WCF多次 ********
            '***********************************************************************************************************
            '取得 Combobox的 資料
            Dim cboDS As DataSet = Pub.queryPUBDepartmentAllDept()

            cbo_DeptCode.DataSource = cboDS.Tables(0)
            cbo_DeptCode.uclDisplayIndex = "0,1"
            cbo_DeptCode.uclValueIndex = "0"

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
#Region "[開單-確認應完成時數] =[開單-簽收應完成時數]+[簽收-確認應完成時數]     "
    Private Sub txt_SignHour_Leave(sender As Object, e As EventArgs) Handles txt_SignHour.Leave, txt_RptHour.Leave
        If txt_SignHour.Text <> "" And txt_RptHour.Text <> "" Then
            Dim SignHour As Single = txt_SignHour.Text
            Dim RptHour As Single = txt_RptHour.Text
            Dim FinishTotalHours As Single = SignHour + RptHour
            txt_FinishTotalHours.Text = nvl(FinishTotalHours)
        End If

    End Sub
#End Region

#Region "  初始化檢驗組別    "
    ''' <summary>
    ''' 初始檢驗組別
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initalSpicemenType()
        Try
            ''初始化對象
            Dim objPub = PubServiceManager.getInstance

            Dim pvtInitDs As DataSet = objPub.querySpicemenType()

            If pvtInitDs IsNot Nothing And pvtInitDs.Tables.Count > 0 Then

                '檢驗組別
                cbo_SpicemenType.DataSource = pvtInitDs.Tables(0).Copy
                cbo_SpicemenType.uclDisplayIndex = "0,1"
                cbo_SpicemenType.uclValueIndex = "0"

                'IO類別()
                cbo_IOType.DataSource = pvtInitDs.Tables(1).Copy
                cbo_IOType.uclDisplayIndex = "0,1"
                cbo_IOType.uclValueIndex = "0"
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Kaiwen,Hsiao on 2016-4-25</remarks>
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

#Region "     欄位檢查 "

#Region "     欄位檢查 - True 檢查不通過;False 檢查通過 "

    ''' <summary>
    ''' 欄位檢查 - True 檢查不通過;False 檢查通過
    ''' </summary>
    ''' <remarks>by Kaiwen,Hsiao on 2016-4-25</remarks>
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
            Dim objCheck1 As TextBox = txt_SheetCode
            Dim errorStr1 As String = "表單代碼、"

            Dim objCheck2 As TextBox = txt_SheetName
            Dim errorStr2 As String = "表單名稱、"

            Dim objCheck3 As UCLComboBoxUC = cbo_DeptCode
            Dim errorStr3 As String = "執行科別、"

            '*******************************************************************************************************************




            Select Case iButtonFlag

                '新增/修改時的檢查
                Case buttonAction.INSERT, buttonAction.UPDATE

                    '*********************************************************************************************************************
                    '設定新增/修改要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ***************************
                    '*********************************************************************************************************************

                    '護理站 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)

                    '時間點 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck2, errorStr2, stbErrorCollection, returnBoolean)

                    '印表機代碼 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck3, errorStr3, stbErrorCollection, returnBoolean)
                    '*********************************************************************************************************************

                    '刪除時的檢查
                Case buttonAction.DELETE

                    '*********************************************************************************************************************
                    '設定刪除要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ********************************
                    '*********************************************************************************************************************

                    '護理站 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)
                    '*********************************************************************************************************************

                    '查詢時的檢查
                Case buttonAction.QUERY

                    ''*********************************************************************************************************************
                    ''設定查詢要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ********************************
                    ''*********************************************************************************************************************

                    ''護理站 欄位檢查並設定檢查結果
                    'SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)
                    ''*********************************************************************************************************************


            End Select

            '欄位check錯誤
            If returnBoolean Then

                Dim finalErrorString As String = stbErrorCollection.ToString

                '有值
                If finalErrorString.Length > 0 Then

                    '去掉最後一個逗號
                    finalErrorString = finalErrorString.Substring(0, finalErrorString.Length - 2)

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

#Region "     資料被點選時的相應動作 "

    ''' <summary>
    ''' 資料被點選時的相應動作
    ''' </summary>
    ''' <remarks>by Kaiwen,Hsiao on 2016-4-25</remarks>
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

                txt_SheetCode.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Sheet_Code").Value)

                txt_SheetName.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Sheet_Name").Value)
                txt_SheetShortName.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Sheet_Short_Name").Value)

                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_Emergency_Sheet").Value) = "Y" Then
                    chk_IsEmergencySheet.Checked = True
                End If
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Dc").Value) = "Y" Then
                    chk_Dc.Checked = True
                End If

                cbo_DeptCode.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Dept_Code").Value)
                txt_ReportTitle.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Report_Title").Value)
                txt_SignHour.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Finish_Sign_Hours").Value)
                cbo_SpicemenType.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Lab_Group_Id").Value)
                cbo_IOType.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("In_Out_Id").Value)
                txt_RptHour.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Finish_Rpt_Hours").Value)
                txt_FinishTotalHours.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Finish_Total_Hours").Value)

                'Add By Elly 2016/10/09 --start
                rtxt_ListWarning.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Sheet_Note").Value)
                '--end
                '*************************************************************************************************************************


            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"資料被點選時的相應動作"})
        End Try

    End Sub

#End Region


#Region "     取得要存檔的Dataset "

    ''' <summary>
    ''' 取得要存檔的Dataset
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Kaiwen,Hsiao on 2016-4-25</remarks>
    Private Function GetSaveDS(ByVal inputCreateUser As String, ByVal inputModifiedUser As String) As DataSet

        Dim returnDataSet As DataSet

        Try

            '產生要存檔的Dataset
            returnDataSet = GenDataSet(gblTableName, gblColumnNameDB)

            Dim drSave As DataRow = returnDataSet.Tables(gblTableName).NewRow()


            '*************************************************************************************************************************
            '設定 要儲存的資料 *******************************************************************************************************
            '*************************************************************************************************************************

            For i = 0 To returnDataSet.Tables(0).Columns.Count - 1
                drSave(i) = DBNull.Value
            Next

            drSave("Sheet_Code") = nvl(txt_SheetCode.Text.ToString)
            drSave("Sheet_Name") = nvl(txt_SheetName.Text.ToString)
            drSave("Sheet_Short_Name") = nvl(txt_SheetShortName.Text.ToString)

            If chk_IsEmergencySheet.Checked = True Then
                drSave("Is_Emergency_Sheet") = "Y"
            Else
                drSave("Is_Emergency_Sheet") = "N"
            End If
            If chk_Dc.Checked = True Then
                drSave("Dc") = "Y"
            Else
                drSave("Dc") = "N"
            End If
            drSave("Is_Print") = "N"
            drSave("Is_Indication") = "N"
            drSave("Is_Print_Indication") = "N"
            drSave("Sheet_Type_Id") = "1"
            drSave("Sheet_Sort_Value") = 1
            drSave("Lis_Sheet_Limit_Cnt") = 9999
            drSave("Dept_Code") = nvl(cbo_DeptCode.SelectedValue)
            drSave("Report_Title") = nvl(txt_ReportTitle.Text.ToString)
            drSave("Lab_Group_Id") = nvl(cbo_SpicemenType.SelectedValue)

            'Add By Elly on2016/10/09 --start
            drSave("Sheet_Note") = nvl(rtxt_ListWarning.Text.ToString)
            '--end


            If txt_SignHour.Text.ToString = "" Then
                drSave("Finish_Sign_Hours") = 0
            Else
                drSave("Finish_Sign_Hours") = CDec(nvl(txt_SignHour.Text.ToString))
            End If

            drSave("In_Out_Id") = nvl(cbo_IOType.SelectedValue)

            If txt_RptHour.Text.ToString = "" Then
                drSave("Finish_Rpt_Hours") = 0
            Else
                drSave("Finish_Rpt_Hours") = CDec(nvl(txt_RptHour.Text.ToString))
            End If

            If txt_FinishTotalHours.Text.ToString = "" Then
                drSave("Finish_Total_Hours") = 0
            Else
                drSave("Finish_Total_Hours") = CDec(nvl(txt_FinishTotalHours.Text.ToString))
            End If
          
            drSave("Create_User") = inputCreateUser

            drSave("Modified_User") = inputModifiedUser

            '*************************************************************************************************************************

            'Create_Time 後端會自動產生

            'Modified_Time 後端會自動產生

            returnDataSet.Tables(gblTableName).Rows.Add(drSave)

            Return returnDataSet

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得要存檔的Dataset"})
        End Try

    End Function

#End Region

#End Region

#End Region


End Class

