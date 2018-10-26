'/*
'*****************************************************************************
'*
'*    Page/Class Name:  表單開單顯示醫令檔維護
'*              Title:	PUBSheetDisplayOrderUI
'*        Description:	1.新增 2.修改 3.刪除 4.查詢 5.清除
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Roger.Sun
'*        Create Date:	2016-05-24
'*      Last Modifier:	Roger.Sun
'*   Last Modify Date:	2016-05-24
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


Public Class PUBSheetDisplayOrderUI
    Inherits IUCLMaintainFormUI

#Region "     變數宣告 "

#Region "     *Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = PubSheetDisplayOrderDataTableFactory.columnsName

    '存檔的Table Name
    Private gblTableName As String = PubSheetDisplayOrderDataTableFactory.tableName

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = PubSheetDisplayOrderDataTableFactory.getDataTable

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "表單顯示次分類,醫令顯示代碼,醫令顯示名稱,醫令代碼,預設大部位,預設部位,預設側位,Sheet_Sub_Display,Default_Main_Body_Site_Code,Default_Body_Site_Code,Default_Side_Id,排序"

    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "150,100,150,100,120,160,80,0,0,0,0,50"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1,2,3,4,5,6,11"



    '*******************************************************************************

    Private Sheet_Sub_Display_First As String

#End Region

#Region "     *使用的service宣告 "

    '*******************************************************************************
    '依呼叫的 service 修改    ******************************************************
    '*******************************************************************************

    '定義使用的service介面
    Dim PUB As IPubServiceManager

    '*******************************************************************************

#End Region

#Region "     主要功能 "

#Region "     *按鈕事件 "

#Region "     *新增 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Roger.Sun on 2016-5-24</remarks>
    Public Overrides Function InsertData() As Boolean

        Try
            Dim returnBoolean As Boolean = False

            Dim iButtonFlag As Integer = buttonAction.INSERT

            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '重複檢查
            Dim CheckDS As DataSet = PUB.QuerySheetDisplayOrderCheckDS(UclCbo_Order_Code.SelectedValue, UclCbo_Main_Body_Site.SelectedValue, UclCbo_Body_Site.SelectedValue, UclCbo_Side_Id.SelectedValue)
            If (Not IsNothing(CheckDS) AndAlso CheckDS.Tables("CheckSheetDisplayOrderDS").Rows.Count > 0) Then
                Dim strSub As String = CheckDS.Tables("CheckSheetDisplayOrderDS").Rows(0).Item("sub_displsy_name").ToString.Trim
                Dim strOrder As String = CheckDS.Tables("CheckSheetDisplayOrderDS").Rows(0).Item("order_display_name").ToString.Trim

                MessageHandling.ShowWarnMsg("CMMCMMB300", "該醫令之預設大部位,預設部位及預設側位已存在於表單顯示次分類為 " & strSub & "、醫令顯示代碼為 " & strOrder & ", 請確認內容再執行新增功能。")

                Exit Function
            End If

            '新增，建立者與修改者為同一人
            Dim InsertDS As DataSet = GetSaveDS(CurrentUserID, CurrentUserID)



            '*******************************************************************************
            '修改 insert 的 Method *********************************************************
            '*******************************************************************************

            '拿掉註解，修改 Insert 方法即可，修改完成後拿掉此行註解 
            '寫入資料庫
            Dim count As Integer = PUB.PUBSheetDisplayOrderInsert(InsertDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True




                '******************************************************************************
                '修改  ************************************************************************
                '******************************************************************************


                '拿掉註解，修改查詢ByPK 方法即可，修改完成後拿掉此行註解 
                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                'UCLScreenUtil.ShowDgv(dgvShowData, InsertDS, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)

                updateDataGridView(iButtonFlag, InsertDS)

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
    ''' <remarks>by Roger.Sun on 2016-5-24</remarks>
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
            Dim count As Integer = PUB.PUBSheetDisplayOrderUpdate(updateDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True


                updateDS = PUB.QueryPubSheetDisplayOrderByCond(UclCbo_Sheet_Sub_Display.SelectedValue, "", "", "")

                '顯示資料在 Grid 上
                UCLScreenUtil.ShowDgv(dgvShowData, updateDS, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)
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
    ''' <remarks>by Roger.Sun on 2016-5-24</remarks>
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
            Dim count As Integer = PUB.PUBSheetDisplayOrderDelete(UclCbo_Sheet_Sub_Display.SelectedValue, txt_Order_Display_Code.Text.Trim)

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

#Region "     *查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Roger.Sun on 2016-5-24</remarks>
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
          
            queryDS = PUB.QueryPubSheetDisplayOrderByCond(nvl(UclCbo_Sheet_Sub_Display.SelectedValue), nvl(UclCbo_Order_Code.SelectedValue), nvl(txt_Order_Display_Code.Text), nvl(txt_Order_Display_Name.Text))

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
    ''' <remarks>by Roger.Sun on 2016-5-24</remarks>
    Public Overrides Sub clearData()

        Try


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
    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Sub New(ByVal Sheet_Sub_Display As String)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

        Sheet_Sub_Display_First = Sheet_Sub_Display
        UclCbo_Sheet_Sub_Display.Enabled = True
    End Sub
    ''' <summary>
    ''' 初始化畫面 - 繼承UCLMaintainUI
    ''' </summary>
    ''' <remarks>by Roger.Sun on 2016-5-24</remarks>
    Public Overrides Sub initialData()

        Try
            Dim emptyDS As New DataSet

            '載入服務管理員
            LoadServiceManager()

            '初始化 - ComboBox
            initialComboBox()

            UclCbo_Sheet_Sub_Display.SelectedValue = Sheet_Sub_Display_First


            '初始化 - 先查詢帶進來的條件對應資料
            queryData()
            'ShowDgv(emptyDS)



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
    ''' <remarks>by Roger.Sun on 2016-5-24</remarks>
    Private Sub ShowDgv(ByVal ds As DataSet)

        Try
            Dim emptyDS As New DataSet
            If ds IsNot Nothing AndAlso ds.Tables IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
                emptyDS.Merge(ds.Tables(0).Copy)
            Else
                emptyDS = Nothing
            End If

            'Dim columnName As String = gblColumnTextDgv

            'Dim emptyDT As DataTable = GenDataTable(columnName.Split(","))

            '顯示空的Dataset 在　Grid 上
            UCLScreenUtil.ShowDgv(dgvShowData, emptyDS, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)

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
    ''' <remarks>by Roger.Sun on 2016-5-24</remarks>
    Private Sub initialComboBox()

        Try

            '***********************************************************************************************************
            '視需要進行修改，如果一次要取得多個 ComboBox，請取一個DS 回來，內包含各個DataTable，不可呼叫WCF多次 ********
            '***********************************************************************************************************

            '取得 Combobox的 資料
            'Dim cboDS As DataSet = IPH.IPHMedDeployListQueryCboData()

            Dim ds As New DataSet
            Dim MainBodySite As String = ""
            ds = PUB.QueryPubSheetDisplayOrderCombodata(nvl(MainBodySite))

            '檢查資料來源
            'If CheckHasTable(cboDS, "PUB_Station") Then
            '設定資料來源
            'UclCbo_Sheet_Type_Id.Initial(ds.Tables("PUB_Syscode"), "Code_ID" & "Code_Name", "Code_ID")
            'UclCbo_Sheet_Type_Id
            'UclCbo_Sheet_Type_Id.uclDisplayIndex("0,1")
            'End If

            If CheckHasTable(ds, "UclCbo_PUB_Sheet_Sub_Display") Then

                UclCbo_Sheet_Sub_Display.DataSource = ds.Tables("UclCbo_PUB_Sheet_Sub_Display")
                UclCbo_Sheet_Sub_Display.uclValueIndex = "0"
                UclCbo_Sheet_Sub_Display.uclDisplayIndex = "0,1"

            End If

            If CheckHasTable(ds, "UclCbo_Order_Code") Then

                UclCbo_Order_Code.DataSource = ds.Tables("UclCbo_Order_Code").Copy
                UclCbo_Order_Code.uclValueIndex = "0"
                UclCbo_Order_Code.uclDisplayIndex = "0,1"
                ' UclCbo_Order_Code.Tag = ds.Tables("UclCbo_Order_Code").Copy
            End If

            If CheckHasTable(ds, "UclCbo_Main_Body_Site_Code") Then

                UclCbo_Main_Body_Site.DataSource = ds.Tables("UclCbo_Main_Body_Site_Code")
                UclCbo_Main_Body_Site.uclValueIndex = "0"
                UclCbo_Main_Body_Site.uclDisplayIndex = "0,1"

            End If

            If CheckHasTable(ds, "UclCbo_Body_Site_Code") Then

                UclCbo_Body_Site.DataSource = ds.Tables("UclCbo_Body_Site_Code")
                UclCbo_Body_Site.uclValueIndex = "0"
                UclCbo_Body_Site.uclDisplayIndex = "0,1"

            End If

            If CheckHasTable(ds, "UclCbo_Sch_Code_Id") Then

                UclCbo_Side_Id.DataSource = ds.Tables("UclCbo_Sch_Code_Id")
                UclCbo_Side_Id.uclValueIndex = "0"
                UclCbo_Side_Id.uclDisplayIndex = "0,1"

            End If
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
    ''' <remarks>by Roger.Sun on 2016-5-24</remarks>
    Private Sub LoadServiceManager()
        Try



            '*******************************************************************************
            '根據系統別進行修改  ***********************************************************
            '*******************************************************************************

            PUB = PubServiceManager.getInstance()

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
    ''' <remarks>by Roger.Sun on 2016-5-24</remarks>
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
            Dim objCheck1 As UCLComboBoxUC = UclCbo_Sheet_Sub_Display
            Dim errorStr1 As String = "表單顯示次分類、"

            Dim objCheck2 As UCLComboBoxUC = UclCbo_Order_Code
            Dim errorStr2 As String = "醫令代碼、"

            Dim objCheck3 As TextBox = txt_Order_Display_Code
            Dim errorStr3 As String = "醫令顯示代碼、"

            Dim objCheck4 As TextBox = txt_Order_Display_Name
            Dim errorStr4 As String = "醫令顯示名稱、"
           

            '*******************************************************************************************************************




            Select Case iButtonFlag

                '新增/修改時的檢查
                Case buttonAction.INSERT, buttonAction.UPDATE




                    '*********************************************************************************************************************
                    '設定新增/修改要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ***************************
                    '*********************************************************************************************************************

                    '表單顯示次分類 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)

                    '醫令代碼 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck2, errorStr2, stbErrorCollection, returnBoolean)

                    '醫令顯示代碼 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck3, errorStr3, stbErrorCollection, returnBoolean)
                    '醫令顯示名稱 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck4, errorStr4, stbErrorCollection, returnBoolean)
                    '*********************************************************************************************************************





                    '刪除時的檢查
                Case buttonAction.DELETE



                    '*********************************************************************************************************************
                    '設定刪除要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ********************************
                    '*********************************************************************************************************************

                    '欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)
                    SetCheckResult(objCheck2, errorStr2, stbErrorCollection, returnBoolean)
                    SetCheckResult(objCheck3, errorStr3, stbErrorCollection, returnBoolean)
                    '*********************************************************************************************************************




                    '查詢時的檢查
                Case buttonAction.QUERY

                    '*********************************************************************************************************************
                    '設定查詢要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ********************************
                    '*********************************************************************************************************************

                    '欄位檢查並設定檢查結果
                    'SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)
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
    ''' <remarks>by Roger.Sun on 2016-5-24</remarks>
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

               

                '設定表單顯示次分類的控制項
                UclCbo_Sheet_Sub_Display.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Sheet_Sub_Display").Value)
                '設定醫令代碼的控制項
                UclCbo_Order_Code.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Order_Code").Value)
                ' UclCbo_Order_Code.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Order_Code").Value)
                '設定醫令顯示代碼的控制項
                txt_Order_Display_Code.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Order_Display_Code").Value)
                '設定醫令顯示名稱的控制項
                txt_Order_Display_Name.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Order_Display_Name").Value)
                '設定預設大部位的控制項
                UclCbo_Main_Body_Site.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Default_Main_Body_Site_Code").Value)

                txt_Display_Sort_Value.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Display_Sort_Value").Value)

                Dim ds As New DataSet

                ds = PUB.QueryPubSheetDisplayOrderCombodata(nvl(UclCbo_Main_Body_Site.SelectedValue))
                If CheckHasTable(ds, "UclCbo_Body_Site_Code") Then

                    UclCbo_Body_Site.DataSource = ds.Tables("UclCbo_Body_Site_Code")
                    UclCbo_Body_Site.uclValueIndex = "0"
                    UclCbo_Body_Site.uclDisplayIndex = "0,1"

                End If

                '設定預設部位的控制項
                UclCbo_Body_Site.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Default_Body_Site_Code").Value)

                '設定預設側位的控制項
                UclCbo_Side_Id.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Default_Side_Id").Value)
                '設定建立者的資料 - 必須要填寫!
                'globalCreateUser = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Create_User").Value)

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
    ''' <remarks>by Roger.Sun on 2016-5-24</remarks>
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

            'drSave("Create_User") = inputCreateUser

            'drSave("Modified_User") = inputModifiedUser

            drSave("Sheet_Sub_Display") = nvl(UclCbo_Sheet_Sub_Display.SelectedValue.ToString)
            drSave("Order_Code") = nvl(UclCbo_Order_Code.SelectedValue.ToString)
            drSave("Order_Display_Code") = nvl(txt_Order_Display_Code.Text)
            drSave("Order_Display_Name") = nvl(txt_Order_Display_Name.Text)
            drSave("Default_Main_Body_Site_Code") = nvl(UclCbo_Main_Body_Site.SelectedValue.ToString)
            drSave("Default_Body_Site_Code") = nvl(UclCbo_Body_Site.SelectedValue.ToString)
            drSave("Default_Side_Id") = nvl(UclCbo_Side_Id.SelectedValue.ToString)
            drSave("Display_Sort_Value") = nvl(txt_Display_Sort_Value.Text)

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

#Region "MainBodySite的觸發"
    Private Sub MainBodySite_Changed(sender As Object, e As EventArgs) Handles UclCbo_Main_Body_Site.TextChanged
       
    End Sub
#End Region

#Region "OrderCode的觸發"
    Private Sub OrderCode_Changed() Handles UclCbo_Order_Code.SelectedIndexChanged
        Dim ds As New DataSet
        Dim MainBodySiteCode As String
        MainBodySiteCode = ""
        ds = PUB.QueryPubSheetDisplayOrderCombodata(nvl(MainBodySiteCode))
        If CheckHasTable(ds, "UclCbo_Body_Site_Code") Then

            UclCbo_Body_Site.DataSource = ds.Tables("UclCbo_Body_Site_Code")
            UclCbo_Body_Site.uclValueIndex = "0"
            UclCbo_Body_Site.uclDisplayIndex = "1,2"

        End If
        UclCbo_Main_Body_Site.SelectedValue = nvl(ds.Tables("UclCbo_Order_Code").Rows.Item("Default_Main_Body_Site_Code"))
        UclCbo_Body_Site.SelectedValue = nvl(ds.Tables("UclCbo_Order_Code").Rows.Item("Default_Body_Site_Code"))
        UclCbo_Side_Id.SelectedValue = nvl(ds.Tables("UclCbo_Order_Code").Rows.Item("Default_Side_Id"))
    End Sub
#End Region

#End Region

#End Region


End Class

