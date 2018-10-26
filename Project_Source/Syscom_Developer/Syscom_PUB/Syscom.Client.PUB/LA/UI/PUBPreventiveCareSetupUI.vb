'/*
'*****************************************************************************
'*
'*    Page/Class Name:  預防保健基本檔設定維護
'*              Title:	PUBPreventiveCareSetupUI
'*        Description:	1.新增 2.修改 3.刪除 4.查詢 5.清除
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	lingan Computer Co,.Ltd
'*            @author:	Remote_Liu
'*        Create Date:	2016-05-17
'*      Last Modifier:	Remote_Liu
'*   Last Modify Date:	2016-05-17
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

Public Class PUBPreventiveCareSetupUI

#Region "     變數宣告 "

#Region "     *Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = PubPreventiveCareDataTableFactory.columnsName

    '存檔的Table Name
    Private gblTableName As String = PubPreventiveCareDataTableFactory.tableName

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = PubPreventiveCareDataTableFactory.getDataTable

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "服務項目,服務時程代碼,就醫序號,服務時程名稱,年齡控制類型,年齡起,年齡迄,說明,套餐代碼,性別限制,篩檢條件說明,諮詢單位,診間提示說明,備註"

    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "150,100,80,200,100,120,120,300,0,0,0,0,0,0"

    '要顯示在畫面上的Grid 欄位Index
    '有Check Box 不用加0 Bycharles
    Private gblColumnVisibleDgv As String = "0,1,2,3,4,5,6,7"

    '*******************************************************************************

#End Region

#Region "     *使用的service宣告 "

    '*******************************************************************************
    '依呼叫的 service 修改    ******************************************************
    '*******************************************************************************

    '定義使用的service介面
    Dim pub As IPubServiceManager_L

    '*******************************************************************************

#End Region

#Region "     主要功能 "

#Region "     *按鈕事件 "

#Region "     *新增 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Remote_Liu on 2016-5-17</remarks>
    Public Overrides Function InsertData() As Boolean

        Try
            Dim returnBoolean As Boolean = False

            Dim iButtonFlag As Integer = buttonAction.INSERT

            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '新增，建立者與修改者為同一人
            Dim InsertDS As DataSet = GetSaveDS(CurrentUserID, CurrentUserID, iButtonFlag)

            '寫入資料庫
            Dim count As Integer = pub.PUBPreventiveCareInsert(InsertDS)
            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid

                '承毅
                'updateDataGridView(iButtonFlag, pub.PUBPreventiveCareQueryByPK(cmb_CareItem.SelectedValue, Cmb_OrderCode.SelectedValue, txt_Serialnumber.Text.ToString.Trim))
                updateDataGridView(iButtonFlag, pub.PUBPreventiveCareQueryByPK(cmb_CareItem.SelectedValue, txt_OrderCode.Text.Trim, txt_Serialnumber.Text.ToString.Trim))

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
    ''' <remarks>by Remote_Liu on 2016-5-17</remarks>
    Public Overrides Function updateData() As Boolean

        Dim returnBoolean As Boolean = False

        Dim iButtonFlag As Integer = buttonAction.UPDATE

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '修改，建立者與修改者為同一人
            Dim updateDS As DataSet = GetSaveDS(CurrentUserID, CurrentUserID, iButtonFlag)

            '*******************************************************************************
            '修改 update 的 Method *********************************************************
            '*******************************************************************************
            '寫入資料庫
            Dim count As Integer = pub.PUBPreventiveCareUpdate(updateDS)

            '*******************************************************************************
            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True


                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid

                '承毅
                'updateDataGridView(iButtonFlag, pub.PUBPreventiveCareQueryByPK(cmb_CareItem.SelectedValue, Cmb_OrderCode.SelectedValue, txt_Serialnumber.Text.ToString.Trim))
                updateDataGridView(iButtonFlag, pub.PUBPreventiveCareQueryByPK(cmb_CareItem.SelectedValue, txt_OrderCode.Text.Trim, txt_Serialnumber.Text.ToString.Trim))

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
    ''' <remarks>by Remote_Liu on 2016-5-17</remarks>
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
            '自資料庫刪除

            '承毅
            'Dim count As Integer = pub.PubPreventiveCareDeleteByPK(cmb_CareItem.SelectedValue, Cmb_OrderCode.SelectedValue, txt_Serialnumber.Text.ToString.Trim)
            Dim count As Integer = pub.PubPreventiveCareDeleteByPK(cmb_CareItem.SelectedValue, txt_OrderCode.Text.Trim, txt_Serialnumber.Text.ToString.Trim)
            '*******************************************************************************

            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True
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


#Region "     *查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Remote_Liu on 2016-5-17</remarks>
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
            queryDS = pub.PUBPreventiveCareQueryByLikePK(cmb_CareItem.SelectedValue)
           
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
    ''' <remarks>by Remote_Liu on 2016-5-17</remarks>
    Public Overrides Sub clearData()

        Try

            '清除傳入控制項的所有內含的控制
            CleanControls(tlp_Main)
            dgvShowData.ClearDS()


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

    ''' <summary>
    ''' 初始化畫面 - 繼承UCLMaintainUI
    ''' </summary>
    ''' <remarks>by Remote_Liu on 2016-5-17</remarks>
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
    ''' <remarks>by Remote_Liu on 2016-5-17</remarks>
    Private Sub ShowDgv()

        Try

            Dim columnName As String = " Care_Item_Code, Care_Order_Code, Care_Cardseq, Care_Cardseq_Name, Age_Control_Id, Age_Start, Age_End, Preventive_Care_Memo"
            Dim emptyDT As DataTable = GenDataTable(columnName.Split(","))
            'Dim pkColArray(0) As DataColumn
            'pkColArray(0) = emptyDT.Columns("Icd_Code")
            'emptyDT.PrimaryKey = pkColArray

            '顯示空的Dataset 在　Grid 上
            UCLScreenUtil.ShowDgv(dgvShowData, gblEmptyDT, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)
            ' UCLScreenUtil.ShowDgv(dgvShowData, emptyDT, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)
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
    ''' <remarks>by Remote_Liu on 2016-5-17</remarks>
    Private Sub initialComboBox()

        Try

            '***********************************************************************************************************
            '視需要進行修改，如果一次要取得多個 ComboBox，請取一個DS 回來，內包含各個DataTable，不可呼叫WCF多次 ********
            '***********************************************************************************************************
           

            '取得 Combobox的 資料
            Dim cboDS As DataSet = pub.queryPUBCareItemAgeSex()


            ' 服務項目
            cmb_CareItem.DataSource = cboDS.Tables(0)
            cmb_CareItem.uclDisplayIndex = "0,1"
            cmb_CareItem.uclValueIndex = "0"

            ' 服務時程代碼
            Cmb_OrderCode.DataSource = cboDS.Tables(1)
            Cmb_OrderCode.uclDisplayIndex = "0,1"
            Cmb_OrderCode.uclValueIndex = "0"

            ' 年齡控制類型
            cmb_Agecontrol.DataSource = cboDS.Tables(2)
            cmb_Agecontrol.uclDisplayIndex = "0,1"
            cmb_Agecontrol.uclValueIndex = "0"

            ' 性別限制
            cmb_sex.DataSource = cboDS.Tables(3)
            cmb_sex.uclDisplayIndex = "0,1"
            cmb_sex.uclValueIndex = "0"

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
    ''' <remarks>by Remote_Liu on 2016-5-9</remarks>
    Private Sub LoadServiceManager()
        Try

            pub = PubServiceManager.getInstance()

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
    ''' <remarks>by Remote_Liu on 2016-5-17</remarks>
    Public Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean

        Dim returnBoolean As Boolean = False

        '儲存要顯示 Error 字串
        Dim stbErrorCollection As StringBuilder = New StringBuilder

        Try

            '清除傳入控制項的所有內含的控制項的欄位底色
            '清除欄位底色
            CleanControlsBackcolor(tlp_Main)

            '*******************************************************************************

            '*******************************************************************************************************************
            '本檢查只會檢查有沒有值，如果是其他的檢查需求，須另行增加!  ********************************************************
            '*******************************************************************************************************************
            ' 服務項目,服務時程代碼,就醫序號
            '設定檢查的控制項、檢查未通過的顯示名稱
            Dim objCheck1 As UCLComboBoxUC = cmb_CareItem
            Dim errorStr1 As String = "服務項目、"

            Dim objCheck2 As UCLComboBoxUC = Cmb_OrderCode
            Dim errorStr2 As String = "服務時程代碼、"

            Dim objCheck3 As UCLTextBoxUC = txt_Serialnumber
            Dim errorStr3 As String = "就醫序號、"

            Dim objCheck4 As UCLTextBoxUC = txt_OrderName
            Dim errorStr4 As String = "服務時程名稱、"
            '*******************************************************************************************************************
            Select Case iButtonFlag

                '新增/修改時的檢查
                Case buttonAction.INSERT, buttonAction.UPDATE

                    '*********************************************************************************************************************
                    '設定新增/修改要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ***************************
                    '*********************************************************************************************************************

                    '服務項目 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)

                    '服務時程代碼 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck2, errorStr2, stbErrorCollection, returnBoolean)

                    '就醫序號 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck3, errorStr3, stbErrorCollection, returnBoolean)

                    '服務時程名稱 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck4, errorStr4, stbErrorCollection, returnBoolean)
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

                    '*********************************************************************************************************************
                    '設定查詢要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ********************************
                    '*********************************************************************************************************************

                    '服務項目 欄位檢查並設定檢查結果
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

#Region "     *資料被點選時的相應動作 "

    ''' <summary>
    ''' 資料被點選時的相應動作
    ''' </summary>
    ''' <remarks>by Remote_Liu on 2016-5-17</remarks>
    Public Overrides Sub dgvCellClick()

        Try
            '清除傳入控制項的所有內含的控制項的欄位底色
            '清除欄位背景顏色
            CleanControlsBackcolor(tlp_Main)
            '被點選的資料列大於零，才執行動作
            If dgvShowData.CurrentCellAddress.Y >= 0 Then
                '*************************************************************************************************************************
                '設定點選後，畫面上方要跟著異動的控制項，譬如說 TextBox 的文字，Combobox 的 select Value *********************************
                '*************************************************************************************************************************
                cmb_CareItem.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Item_Code").Value)

                '承毅
                Cmb_OrderCode.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Order_Code").Value)
                txt_OrderCode.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Order_Code").Value)

                txt_Serialnumber.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Cardseq").Value)
                txt_OrderName.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Cardseq_Name").Value)
                cmb_Agecontrol.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Age_Control_Id").Value)
                txt_AgeMin.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Age_Start").Value)
                txt_AgeMax.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Age_End").Value)

                'txt_instruction.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Preventive_Care_Memo").Value)
                '承毅
                Dim richText As String = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Preventive_Care_Memo").Value)
                If richText.Contains("rtf") Then
                    rich_instruction.Rtf = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Preventive_Care_Memo").Value)
                Else
                    rich_instruction.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Preventive_Care_Memo").Value)
                End If


                txt_Packagecode.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Package_Code").Value)
                cmb_sex.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Limit_Sex_Id").Value)
                txt_Sconditions.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Filter_Desc").Value)
                txt_Advisoryunit.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Advisory_Unit").Value)
                txt_Indiagnosis.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Opd_Memo").Value)
                txt_note.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Preventive_Care_Note").Value)
                '*************************************************************************************************************************
            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"資料被點選時的相應動作"})
        End Try

    End Sub

#End Region

#Region "     * 取得要存檔的Dataset "

    ''' <summary>
    ''' 取得要存檔的Dataset
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-5-17</remarks>
    Private Function GetSaveDS(ByVal inputCreateUser As String, ByVal inputModifiedUser As String, ByVal iButtonFlag As Integer) As DataSet

        Dim returnDataSet As DataSet

        Try

            '產生要存檔的Dataset

            returnDataSet = GenDataSet(gblTableName, gblColumnNameDB)

            Dim drSave As DataRow = returnDataSet.Tables(gblTableName).NewRow()

            If iButtonFlag = buttonAction.UPDATE Then
                '承毅
                'If nvl(cmb_CareItem.SelectedValue.ToString) <> StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Item_Code").Value) Or _
                '               Cmb_OrderCode.SelectedValue.ToString <> StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Order_Code").Value) Or _
                '                nvl(txt_Serialnumber.Text.ToString) <> StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Cardseq").Value) Then
                '    MessageHandling.ShowWarnMsg("CMMCMMB300", "服務項目,服務時程代碼,就醫序號不可修改")
                '    cmb_CareItem.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Item_Code").Value)
                '    Cmb_OrderCode.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Order_Code").Value)
                '    txt_Serialnumber.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Cardseq").Value)

                '    cmb_CareItem.Enabled = False
                '    Cmb_OrderCode.Enabled = False
                '    txt_Serialnumber.Enabled = False
                'End If
                If nvl(cmb_CareItem.SelectedValue.ToString) <> StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Item_Code").Value) Or _
                               txt_OrderCode.Text <> StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Order_Code").Value) Or _
                                nvl(txt_Serialnumber.Text.ToString) <> StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Cardseq").Value) Then
                    MessageHandling.ShowWarnMsg("CMMCMMB300", "服務項目,服務時程代碼,就醫序號不可修改")
                    cmb_CareItem.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Item_Code").Value)
                    txt_OrderCode.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Order_Code").Value)
                    txt_Serialnumber.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Care_Cardseq").Value)

                    cmb_CareItem.Enabled = False
                    txt_OrderCode.Enabled = False
                    txt_Serialnumber.Enabled = False
                End If

            End If
            '*************************************************************************************************************************
            '設定 要儲存的資料 *******************************************************************************************************
            '*************************************************************************************************************************

            drSave("Care_Item_Code") = nvl(cmb_CareItem.SelectedValue.ToString)

            '承毅
            'drSave("Care_Order_Code") = nvl(Cmb_OrderCode.SelectedValue.ToString)
            drSave("Care_Order_Code") = nvl(txt_OrderCode.Text)

            drSave("Care_Cardseq") = nvl(txt_Serialnumber.Text.ToString)
            drSave("Care_Cardseq_Name") = nvl(txt_OrderName.Text.ToString)
            drSave("Age_Control_Id") = nvl(cmb_Agecontrol.SelectedValue.ToString)
            drSave("Age_Start") = nvl(txt_AgeMin.Text.ToString)
            drSave("Age_End") = nvl(txt_AgeMax.Text.ToString)


            'drSave("Preventive_Care_Memo") = nvl(txt_instruction.Text.ToString)
            drSave("Preventive_Care_Memo") = nvl(rich_instruction.Text.ToString)
            '承毅

            drSave("Package_Code") = nvl(txt_Packagecode.Text.ToString)
            drSave("Limit_Sex_Id") = nvl(cmb_sex.SelectedValue.ToString)
            drSave("Filter_Desc") = nvl(txt_Sconditions.Text.ToString)
            drSave("Advisory_Unit") = nvl(txt_Advisoryunit.Text.ToString)
            drSave("Opd_Memo") = nvl(txt_Indiagnosis.Text.ToString)
            drSave("Preventive_Care_Note") = nvl(txt_note.Text.ToString)


            '*************************************************************************************************************************

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


    Private Sub rich_instruction_Click(sender As Object, e As EventArgs) Handles rich_instruction.Click
        Try
            'MsgBox(rich_instruction.Text, 0, "說明")
            'rich_instruction.Text = InputBox("", "說明", rich_instruction.Text, 0, 0)
            Dim richForm As New PUBinput()
            richForm.Owner = Me
            richForm.rich_instruction.Text = rich_instruction.Text
            richForm.Show()

            'If (richForm.ShowDialog() = DialogResult.OK) Then
            '    rich_instruction.Text = richForm.getRich
            'End If       
        Catch ex As Exception
            MessageHandling.ShowErrorMsg("CMMCMMB9160")
        End Try
    End Sub

    Private Sub rich_instruction_TextChanged(sender As Object, e As EventArgs) Handles rich_instruction.TextChanged

    End Sub
End Class