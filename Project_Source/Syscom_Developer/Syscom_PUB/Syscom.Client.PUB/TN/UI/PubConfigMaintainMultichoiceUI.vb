﻿'/*
'*****************************************************************************
'*
'*    Page/Class Name:  參數設定檔
'*              Title:	PubConfigMaintainUI
'*        Description:	1.新增 2.修改 3.刪除 4.查詢
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2014-10-13
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2014-10-13
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

'請修改成 TableFactory 所在的Utility
Imports Syscom.Comm.TableFactory

'請修改成使用到的Servicefactory
Imports Syscom.Client.Servicefactory


Public Class PubConfigMaintainMultichoiceUI
    Inherits IMaintainMultichoiceFormUI

#Region "     變數宣告 "

#Region "     *Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = PubConfigDataTableFactory.columnsName

    '存檔的Table Name
    Private gblTableName As String = PubConfigDataTableFactory.tableName

    '空的DS，清空資料使用
    Private gblEmptyDS As DataSet = PubConfigDataTableFactory.getDataSet

 
    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "系統參數名稱,系統參數說明,設定值,建立者,建立時間,修改者,修改時間"

    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "80,400,200,80,80,80,80"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1,2,3,4,5,6"
     
    '要顯示在畫面上的Grid 欄位Index
    Private gblGridAttribute As GridAttribute() = _
        New GridAttribute() {New GridAttribute(0, GridColumn.TextBoxCell), _
                             New GridAttribute(1, GridColumn.TextBoxCell), _
                             New GridAttribute(2, GridColumn.TextBoxCell), _
                             New GridAttribute(3, GridColumn.TextBoxCell), _
                             New GridAttribute(4, GridColumn.DateTimePickerCell), _
                             New GridAttribute(5, GridColumn.TextBoxCell), _
                             New GridAttribute(6, GridColumn.DateTimePickerCell)
                             }

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

#Region "     *確認"

    ''' <summary>
    ''' 確認
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Sean.Lin on 2014-11-03</remarks>
    Public Overrides Function SaveData() As Boolean

        Try
            Dim returnBoolean As Boolean = False

            Dim iButtonFlag As Integer = buttonAction.SAVE

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
            Dim count As Integer '= Pub.PubConfigInsert(InsertDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True




                '******************************************************************************
                '修改  ************************************************************************
                '******************************************************************************


                '拿掉註解，修改查詢ByPK 方法即可，修改完成後拿掉此行註解 
                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                'updateDataGridView(iButtonFlag, Pub.PubConfigQueryByPK(PK))

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
     

#Region "     *刪除 "

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Sean.Lin on 2014-11-03</remarks>
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
            Dim count As Integer '= Pub.PubConfigdelete(PK)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                '拿掉註解，修改 清除的控制項 即可，修改完成後拿掉此行註解 
                '刪除成功，清除控制項
                'CleanControls(tlp_Main)

            Else
                '無符合條件資料被刪除
                MessageHandling.showWarnMsg("CMMCMMB310", New String() {"刪除"})
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
    ''' <remarks>by Sean.Lin on 2014-11-03</remarks>
    Public Overrides Function queryData() As Boolean

        Dim returnBoolean As Boolean

        Dim iButtonFlag As Integer = buttonAction.QUERY

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '查詢成功後儲存的 DS
            Dim queryDS As New DataSet



            '*******************************************************************************
            '修改  *************************************************************************
            '*******************************************************************************

            '拿掉註解，修改查詢 方法即可，查詢若不只一種，請自行增加 if 判斷式，修改完成後拿掉此行註解 
            '查詢 
            queryDS = Pub.PubConfigQueryByConfigName(nvl(txt_ConfigName.Text))


            '*******************************************************************************




            '有查到 Table 要回傳True
            If CheckHasTable(queryDS) Then

                '如果資料列為零要顯示查無符合條件資料
                If queryDS.Tables(0).Rows.Count = 0 Then

                    MessageHandling.showWarnMsg("CMMCMMB933", New String() {})

                End If

                '顯示資料在 Grid 上
                ShowDgvEdit(queryDS)

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
    ''' <remarks>by Sean.Lin on 2014-11-03</remarks>
    Public Overrides Sub clearData()

        Try


            '*******************************************************************************
            '如果上方的TableLayputPanel 命名為 tlp_Main 則不用修改  ************************
            '*******************************************************************************

            '拿掉註解，修改 清除的控制項 即可，修改完成後拿掉此行註解 
            '清除傳入控制項的所有內含的控制項
            'CleanControls(tlp_Main)

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

    ''' <summary>
    ''' 初始化畫面 - 繼承UCLMaintainUI
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2014-11-03</remarks>
    Public Overrides Sub initialData()

        Try

            '載入服務管理員
            LoadServiceManager()

            '初始化 - DataGridView
            Dim dr As DataRow = gblEmptyDS.Tables(0).NewRow
            gblEmptyDS.Tables(0).Rows.Add(dr)
            ShowDgvEdit(gblEmptyDS)

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

#Region "     顯示 Dataset 在　Grid 上 "

    ''' <summary>
    ''' 顯示 Dataset 在　Grid 上
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2014-11-03</remarks>
    Private Sub ShowDgvEdit(ByVal ds As DataSet)

        Try
 

            Dim htShow As Hashtable = TransforDatatableToHashTable(ds, gblGridAttribute)


                dgvShowData.Initial(htShow, gblColumnTextDgv, gblColumnVisibleDgv, gblColumnWidthDgv)

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
    ''' <remarks>by Sean.Lin on 2014-11-03</remarks>
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
    ''' <remarks>by Sean.Lin on 2014-11-03</remarks>
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
    ''' <remarks>by Sean.Lin on 2014-11-03</remarks>
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
            'CleanControlsBackcolor(tlp_Main)

            '*******************************************************************************



            '*******************************************************************************************************************
            '修改成要設定檢查的控制項、檢查未通過的顯示名稱 EX: 護理站未輸入 只要設定成 [護理站] 即可  *************************
            '本檢查只會檢查有沒有值，如果是其他的檢查需求，須另行增加!  ********************************************************
            '*******************************************************************************************************************

            '設定檢查的控制項、檢查未通過的顯示名稱
            Dim objCheck1 As TextBox = txt_ConfigName

            Dim errorStr1 As String = "系統參數名稱、"
 

            '*******************************************************************************************************************




            Select Case iButtonFlag

                '新增/修改時的檢查
                Case buttonAction.SAVE




                    '*********************************************************************************************************************
                    '設定新增/修改要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ***************************
                    '*********************************************************************************************************************

                    '護理站 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)
 
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

#Region "     *資料被點選時的相應動作 "

    ''' <summary>
    ''' 資料被點選時的相應動作
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2014-11-03</remarks>
    Public Overrides Sub dgvCellClick()

        Try



            '********************************************************************************
            '如果上方的TableLayputPanel 命名為 tlp_Main 則不用修改  *************************
            '********************************************************************************

            '拿掉註解，修改 清除欄位底色的控制項 即可，修改完成後拿掉此行註解 
            '清除傳入控制項的所有內含的控制項的欄位底色
            '清除欄位背景顏色
            'CleanControlsBackcolor(tlp_Main)
            '********************************************************************************




            '被點選的資料列大於零，才執行動作
            If dgvShowData.CurrentCellAddress.Y >= 0 Then



                '*************************************************************************************************************************
                '設定點選後，畫面上方要跟著異動的控制項，譬如說 TextBox 的文字，Combobox 的 select Value *********************************
                '*************************************************************************************************************************

                '{ Station_No,Print_Time,Printer_Code,Create_User,Create_Time,Modified_User ,Modified_Time   }
                '設定護理站的控制項
                'EX: UclCbo_StationNo.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Station_No").Value)

                '設定列印時機的控制項
                'EX: UclCbo_PrintTime.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Print_Time").Value)

                '設定印表機的控制項
                'EX: UclCbo_PrinterCode.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Printer_Code").Value)

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
    ''' <remarks>by Sean.Lin on 2014-11-03</remarks>
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