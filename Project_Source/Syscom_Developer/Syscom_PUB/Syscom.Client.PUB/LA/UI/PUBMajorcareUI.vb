'/*
'*****************************************************************************
'*
'*    Page/Class Name:  特定治療項目基本檔維護
'*              Title:	PUBMajorcareUI
'*        Description:	1.新增 2.修改 3.刪除 4.查詢 5.清除
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Hsiao,Kaiwen
'*        Create Date:	2016-12-21
'*      Last Modifier:	Hsiao,Kaiwen
'*   Last Modify Date:	2016-12-21
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


Public Class PUBMajorcareUI
    Inherits IUCLMaintainFormUI

#Region "     變數宣告 "

#End Region

#Region "     Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = {"Majorcare_Code", "Majorcare_Name", "Majorcare_Type_Id", "Case_Type_Id", "Is_Dr_Use", _
                                             "Add_Ratio", "Examine_Order_Code", "Order_Code_List", "Create_User", "Create_Time", "Modified_User", _
                                                "Modified_Time"}

    '存檔的Table Name
    Private gblTableName As String = PubMajorcareDataTableFactory.tableName

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = PubMajorcareDataTableFactory.getDataTable

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "特定治療項目代碼, 特定治療項目名稱, 特定治療項目類別, 預設案件分類, 是否前台使用,加成率, 醫令項目代碼,特定治療連帶醫令碼,建立者, 建立時間, 修改者, 修改時間"


    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "120,180,120,120,100,100,150,120,100,100,100,100"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1,2,3,4,6,7"

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

#Region "     *按鈕事件 "

#Region "     *新增 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-21</remarks>
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
            Dim count As Integer = Pub.insertPUBMajorcare(InsertDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True




                '******************************************************************************
                '修改  ************************************************************************
                '******************************************************************************


                '拿掉註解，修改查詢ByPK 方法即可，修改完成後拿掉此行註解 
                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                updateDataGridView(iButtonFlag, Pub.queryPUBMajorcareByCond(txtMajorcareCode.Text.Replace("'", "''")))

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

#Region "     修改 "

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-21</remarks>
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
            Dim count As Integer = Pub.updatePUBMajorcare(updateDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True


                '*******************************************************************************
                '修改  *************************************************************************
                '*******************************************************************************

                '拿掉註解，修改查詢ByPK 方法即可，修改完成後拿掉此行註解 
                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                updateDataGridView(iButtonFlag, Pub.queryPUBMajorcareByCond(txtMajorcareCode.Text.Replace("'", "''")))

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
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-21</remarks>
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
            Dim count As Integer = Pub.deletePUBMajorcareByPK(txtMajorcareCode.Text.ToString.Trim)

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
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-21</remarks>
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


            '查詢 
            queryDS = Pub.queryPUBMajorcareByCond(txtMajorcareCode.Text.Replace("'", "''"))


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
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-21</remarks>
    Public Overrides Sub clearData()

        Try


            '拿掉註解，修改 清除的控制項 即可，修改完成後拿掉此行註解 
            '清除傳入控制項的所有內含的控制項
            CleanControls(tlp_Main)


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
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-21</remarks>
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
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-21</remarks>
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

#Region "     初始化 - ComboBox "

    ''' <summary>
    ''' 初始化 - ComboBox
    ''' </summary>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-21</remarks>
    Private Sub initialComboBox()

        Try

            '***********************************************************************************************************
            '視需要進行修改，如果一次要取得多個 ComboBox，請取一個DS 回來，內包含各個DataTable，不可呼叫WCF多次 ********
            '***********************************************************************************************************

            '取得 Combobox的 資料
            Dim dsDB As DataSet = Pub.queryPUBSysCode("501")

            '初始化職稱
            cmbMajorcareTypeId.DataSource = dsDB.Tables(PubSyscodeDataTableFactory.tableName).Copy
            cmbMajorcareTypeId.uclDisplayIndex = "0,1"
            cmbMajorcareTypeId.uclValueIndex = "0"

            '取得 Combobox的 資料
            Dim dsCaseType As DataSet = Pub.queryPUBSysCode("504")

            '初始化職稱
            cmb_CaseType.DataSource = dsCaseType.Tables(0).Copy
            cmb_CaseType.uclDisplayIndex = "0,1"
            cmb_CaseType.uclValueIndex = "0"

            '**********************************************************************************************************

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - ComboBox"})
        End Try

    End Sub

#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-21</remarks>
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
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-21</remarks>
    Public Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean

        Dim returnBoolean As Boolean = False

        '儲存要顯示 Error 字串
        Dim stbErrorCollection As StringBuilder = New StringBuilder

        Try



          
            '拿掉註解，修改 清除欄位底色的控制項 即可，修改完成後拿掉此行註解 
            '清除傳入控制項的所有內含的控制項的欄位底色
            '清除欄位底色
            CleanControlsBackcolor(tlp_Main)

            '*******************************************************************************************************************
            '修改成要設定檢查的控制項、檢查未通過的顯示名稱 EX: 護理站未輸入 只要設定成 [護理站] 即可  *************************
            '本檢查只會檢查有沒有值，如果是其他的檢查需求，須另行增加!  ********************************************************
            '*******************************************************************************************************************

            '設定檢查的控制項、檢查未通過的顯示名稱
            Dim objCheck1 As UCLTextBoxUC = txtMajorcareCode
            Dim errorStr1 As String = "特定治療項目代碼、"

            '*******************************************************************************************************************




            Select Case iButtonFlag

                '新增/修改時的檢查
                Case buttonAction.INSERT, buttonAction.UPDATE


                    '*********************************************************************************************************************
                    '設定新增/修改要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ***************************
                    '*********************************************************************************************************************

                    '特定治療項目代碼 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)

                    '*********************************************************************************************************************



                    '刪除時的檢查
                Case buttonAction.DELETE



                    '*********************************************************************************************************************
                    '設定刪除要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ********************************
                    '*********************************************************************************************************************

                    '特定治療項目代碼 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)
                    '*********************************************************************************************************************

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
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-21</remarks>
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

                '特定治療項目類別
                cmbMajorcareTypeId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Majorcare_Type_Id").Value.ToString.Trim

                '特定治療項目代碼
                txtMajorcareCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Majorcare_Code").Value.ToString.Trim

                '特定治療項目名稱
                txtMajorcareName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Majorcare_Name").Value.ToString.Trim

                '預設案件分類
                cmb_CaseType.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Case_Type_Id").Value.ToString.Trim

                '診察費醫令碼
                tcq_ExamineOrderCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Examine_Order_Code").Value.ToString.Trim

                '是否前台使用
                Dim strchecked As String = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_Dr_Use").Value.ToString.Trim
                If strchecked = "Y" Then
                    chk_IsUsed.Checked = True
                Else
                    chk_IsUsed.Checked = False
                End If

                '特定治療連帶醫令碼
                txt_OrderCodeList.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Order_Code_List").Value.ToString.Trim

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

#Region "     取得要存檔的Dataset "

    ''' <summary>
    ''' 取得要存檔的Dataset
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-12-21</remarks>
    Private Function GetSaveDS(ByVal inputCreateUser As String, ByVal inputModifiedUser As String) As DataSet

        Dim returnDataSet As DataSet

        Try

            '產生要存檔的Dataset
            returnDataSet = GenDataSet(gblTableName, gblColumnNameDB)

            Dim drSave As DataRow = returnDataSet.Tables(gblTableName).NewRow()


            '*************************************************************************************************************************
            '設定 要儲存的資料 *******************************************************************************************************
            '*************************************************************************************************************************

            '特定治療項目類別
            drSave("Majorcare_Type_Id") = cmbMajorcareTypeId.SelectedValue
            drSave("Majorcare_Code") = txtMajorcareCode.Text.ToString.Trim
            drSave("Majorcare_Name") = txtMajorcareName.Text.ToString.Trim
            drSave("Case_Type_Id") = cmb_CaseType.SelectedValue
            drSave("Examine_Order_Code") = tcq_ExamineOrderCode.Text.ToString.Trim

            If chk_IsUsed.Checked = True Then
                drSave("Is_Dr_Use") = "Y"
            Else
                drSave("Is_Dr_Use") = "N"
            End If

            drSave("Order_Code_List") = txt_OrderCodeList.Text.ToString.Trim

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



End Class

