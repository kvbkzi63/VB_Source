'/*
'*****************************************************************************
'*
'*    Page/Class Name:  自費衛材核定記錄維護
'*              Title:	PUBMaterialSelfpayApplyUI
'*        Description:	1.新增 2.修改 3.刪除 4.查詢 5.清除
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Kaiwen
'*        Create Date:	2016-12-14
'*      Last Modifier:	Kaiwen
'*   Last Modify Date:	2016-12-14
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

Public Class PUBMaterialSelfpayApplyUI
    Inherits IUCLMaintainFormUI

#Region "     變數宣告 "

    '案件資料
    Private dsFromOutSide As New DataSet

    Property SeleDsPUBMaterialSelfpayApplyShow() As DataSet
        Get
            Return dsFromOutSide
        End Get
        Set(ByVal Value As DataSet)
            dsFromOutSide = Value
        End Set
    End Property

#End Region

#Region "     Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = PubMaterialSelfpayApplyDataTableFactory.columnsName

    '存檔的Table Name
    Private gblTableName As String = PubMaterialSelfpayApplyDataTableFactory.tableName

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = PubMaterialSelfpayApplyDataTableFactory.getDataTable

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    '---------------------------------------0      1        2          3         4          5             6          7         8         9     10      11          12        13         14                  15                       16                   17                  18                  19                    20                  21                     22                  23                  24                  25      26     27      28      29      
    Private gblColumnTextDgv As String = "醫令碼,生效日期,結束日期,虛擬健保碼,申請狀況,器材許可證字第,器材許可證號,產品特性,使用原因,注意事項,副作用,療效比較,申報醫令類別,替代註記,可替代之給付健保碼 1,可替代之給付健保碼 2,可替代之給付健保碼 3,可替代之給付健保碼 4,可替代之給付健保碼 5,可替代之給付健保碼 6,可替代之給付健保碼 7,可替代之給付健保碼 8,可替代之給付健保碼 9,可替代之給付健保碼 10,列印同意書註記,列印說明書註記,建立者,建立時間,修改者,修改時間"

    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "100,100,100,100,100,150,150,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100,100"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29"

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
    ''' <remarks>by Kaiwen on 2016-12-14</remarks>
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
            Dim count As Integer = Pub.PUBMaterialSelfpayApplyinsert(InsertDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                '******************************************************************************
                '修改  ************************************************************************
                '******************************************************************************

                '拿掉註解，修改查詢ByPK 方法即可，修改完成後拿掉此行註解 
                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                updateDataGridView(iButtonFlag, Pub.queryPubMaterialSelfpayApplyByPK(txt_OrderCode.Text.ToString.Trim, txt_EffectDate.GetUsDateStr))

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
    ''' <remarks>by Kaiwen on 2016-12-14</remarks>
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
            Dim count As Integer = Pub.PUBMaterialSelfpayApplyupdate(updateDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True




                '*******************************************************************************
                '修改  *************************************************************************
                '*******************************************************************************

                '拿掉註解，修改查詢ByPK 方法即可，修改完成後拿掉此行註解 
                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                updateDataGridView(iButtonFlag, Pub.queryPubMaterialSelfpayApplyByPK(txt_OrderCode.Text.ToString.Trim, txt_EffectDate.GetUsDateStr))

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
    ''' <remarks>by Kaiwen on 2016-12-14</remarks>
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
            Dim count As Integer = Pub.PUBMaterialSelfpayApplyDelete(txt_OrderCode.Text.ToString.Trim, txt_EffectDate.GetUsDateStr)

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
    ''' <remarks>by Kaiwen on 2016-12-14</remarks>
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
            queryDS = Pub.queryPubMaterialSelfpayApplyByPKLike(txt_OrderCode.Text.ToString.Trim, txt_EffectDate.GetUsDateStr)


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
    ''' <remarks>by Kaiwen on 2016-12-14</remarks>
    Public Overrides Sub clearData()

        Try

            Dim strTemp As String = txt_OrderCode.Text.ToString.Trim

            CleanControls(tlp_Main)

            txt_OrderCode.Text = strTemp

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB916", ex)
        End Try

    End Sub

#End Region

#Region "     產品特性 "

    Private Sub btn_RichText1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RichText1.Click
        Dim pvtOpen As PUBRichTextContentUI
        pvtOpen = New PUBRichTextContentUI("產品特性", txt_ProductFeatures.Text.Trim)
        pvtOpen.ShowDialog()
        Me.txt_ProductFeatures.Text = pvtOpen.pvtContent
    End Sub

#End Region
  
#Region "     使用原因 "
    Private Sub btn_RichText2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RichText2.Click
        Dim pvtOpen As PUBRichTextContentUI
        pvtOpen = New PUBRichTextContentUI("使用原因", txt_UseReason.Text.Trim)
        pvtOpen.ShowDialog()
        Me.txt_UseReason.Text = pvtOpen.pvtContent
    End Sub
#End Region

#Region "     注意事項 "
    Private Sub btn_RichText3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RichText3.Click
        Dim pvtOpen As PUBRichTextContentUI
        pvtOpen = New PUBRichTextContentUI("注意事項", txt_Precautions.Text.Trim)
        pvtOpen.ShowDialog()
        Me.txt_Precautions.Text = pvtOpen.pvtContent
    End Sub
#End Region

#Region "     副作用 "
    Private Sub btn_RichText4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RichText4.Click
        Dim pvtOpen As PUBRichTextContentUI
        pvtOpen = New PUBRichTextContentUI("副作用", txt_SideEffect.Text.Trim)
        pvtOpen.ShowDialog()
        Me.txt_SideEffect.Text = pvtOpen.pvtContent
    End Sub
#End Region

#Region "     療效比較 "
    Private Sub btn_RichText5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RichText5.Click
        Dim pvtOpen As PUBRichTextContentUI
        pvtOpen = New PUBRichTextContentUI("療效比較", txt_EfficacyComparison.Text.Trim)
        pvtOpen.ShowDialog()
        Me.txt_EfficacyComparison.Text = pvtOpen.pvtContent
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
    ''' <remarks>by Kaiwen on 2016-12-14</remarks>
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

            '初始化畫面控制項**************************************************************************************************************************
            Dim queryDS As New DataSet

            If dsFromOutSide IsNot Nothing AndAlso dsFromOutSide.Tables(0).Rows.Count > 0 Then
                txt_OrderCode.Text = dsFromOutSide.Tables(0).Rows(0).Item("Order_Code").ToString.Trim
                'txt_EffectDate.SetValue(dsFromOutSide.Tables(0).Rows(0).Item("Effect_Date").ToString.Trim)

                queryDS = Pub.queryPubMaterialSelfpayApplyByPKLike(txt_OrderCode.Text.ToString.Trim, "")

            End If

            If CheckHasTable(queryDS) Then
                '顯示資料在 Grid 上
                UCLScreenUtil.ShowDgv(dgvShowData, queryDS, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)
            End If

            '******************************************************************************************************************************************

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
    ''' <remarks>by Kaiwen on 2016-12-14</remarks>
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
    ''' <remarks>by Kaiwen on 2016-12-14</remarks>
    Private Sub initialComboBox()

        Try

            '***********************************************************************************************************
            '視需要進行修改，如果一次要取得多個 ComboBox，請取一個DS 回來，內包含各個DataTable，不可呼叫WCF多次 ********
            '***********************************************************************************************************
            Dim dsDB As New DataSet
            dsDB = Pub.queryPUBSysCode("500")
            Me.cbo_ApplyStatusId.DataSource = dsDB.Tables(0)
            Me.cbo_ApplyStatusId.uclValueIndex = "0"
            Me.cbo_ApplyStatusId.uclDisplayIndex = "0,1"


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
    ''' <remarks>by Kaiwen on 2016-12-14</remarks>
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
    ''' <remarks>by Kaiwen on 2016-12-14</remarks>
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
            Dim objCheck1 As UCLTextBoxUC = txt_OrderCode
            Dim errorStr1 As String = "醫令碼、"

            Dim objCheck2 As UCLDateTimePickerUC = txt_EffectDate
            Dim errorStr2 As String = "生效日、"

            '*******************************************************************************************************************




            Select Case iButtonFlag

                '新增/修改時的檢查
                Case buttonAction.INSERT, buttonAction.UPDATE




                    '*********************************************************************************************************************
                    '設定新增/修改要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ***************************
                    '*********************************************************************************************************************

                    '醫令碼 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)

                    '生效日 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck2, errorStr2, stbErrorCollection, returnBoolean)

                 
                    '*********************************************************************************************************************





                    '刪除時的檢查
                Case buttonAction.DELETE



                    '*********************************************************************************************************************
                    '設定刪除要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ********************************
                    '*********************************************************************************************************************

                    '醫令碼 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)

                    '生效日 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck2, errorStr2, stbErrorCollection, returnBoolean)

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
    ''' <remarks>by Kaiwen on 2016-12-14</remarks>
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
                Me.txt_OrderCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Order_Code").Value.ToString.Trim
                Me.txt_EffectDate.SetValue(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Effect_Date").Value.ToString.Trim)
                Me.txt_EndDate.SetValue(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("End_Date").Value.ToString.Trim)
                Me.txt_SelfInsuCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Self_Insu_Code").Value.ToString.Trim
                Me.cbo_ApplyStatusId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Apply_Status_Id").Value.ToString.Trim
                Me.txt_License.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Equipment_License").Value.ToString.Trim
                Me.txt_LicenseNo.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Equipment_License_No").Value.ToString.Trim
                Me.txt_ProductFeatures.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Product_Features").Value.ToString.Trim
                Me.txt_UseReason.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Use_Reason").Value.ToString.Trim
                Me.txt_Precautions.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Precautions").Value.ToString.Trim
                Me.txt_SideEffect.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Side_Effect").Value.ToString.Trim
                Me.txt_EfficacyComparison.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Efficacy_Comparison").Value.ToString.Trim
                Me.txt_InsuOrderType.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Insu_Order_Type_Id").Value.ToString.Trim
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_Alter").Value.ToString.Trim = "Y" Then
                    chk_IsAlter.Checked = True
                Else
                    chk_IsAlter.Checked = False
                End If

                Me.txt_InsuCode1.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Alternative_Insu_Code_1").Value.ToString.Trim
                Me.txt_InsuCode2.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Alternative_Insu_Code_2").Value.ToString.Trim
                Me.txt_InsuCode3.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Alternative_Insu_Code_3").Value.ToString.Trim
                Me.txt_InsuCode4.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Alternative_Insu_Code_4").Value.ToString.Trim
                Me.txt_InsuCode5.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Alternative_Insu_Code_5").Value.ToString.Trim
                Me.txt_InsuCode6.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Alternative_Insu_Code_6").Value.ToString.Trim
                Me.txt_InsuCode7.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Alternative_Insu_Code_7").Value.ToString.Trim
                Me.txt_InsuCode8.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Alternative_Insu_Code_8").Value.ToString.Trim
                Me.txt_InsuCode9.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Alternative_Insu_Code_9").Value.ToString.Trim
                Me.txt_InsuCode10.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Alternative_Insu_Code_10").Value.ToString.Trim

                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_Agreement_Print").Value.ToString.Trim = "Y" Then
                    chk_Agreement.Checked = True
                Else
                    chk_Agreement.Checked = False
                End If

                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_Instruction_Print").Value.ToString.Trim = "Y" Then
                    chk_Instruction.Checked = True
                Else
                    chk_Instruction.Checked = False
                End If


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
    ''' <remarks>by Kaiwen on 2016-12-14</remarks>
    Private Function GetSaveDS(ByVal inputCreateUser As String, ByVal inputModifiedUser As String) As DataSet

        Dim returnDataSet As DataSet

        Try

            '產生要存檔的Dataset
            returnDataSet = GenDataSet(gblTableName, gblColumnNameDB)

            Dim drSave As DataRow = returnDataSet.Tables(gblTableName).NewRow()


            '*************************************************************************************************************************
            '設定 要儲存的資料 *******************************************************************************************************
            '*************************************************************************************************************************

            '將輸入區資料塞入DB中
            drSave("Order_Code") = Me.txt_OrderCode.Text.Trim
            drSave("Effect_Date") = Me.txt_EffectDate.GetUsDateStr()
            drSave("End_Date") = txt_EndDate.GetUsDateStr()
            drSave("Self_Insu_Code") = Me.txt_SelfInsuCode.Text.Trim
            drSave("Apply_Status_Id") = Me.cbo_ApplyStatusId.SelectedValue
            drSave("Equipment_License") = Me.txt_License.Text.Trim
            drSave("Equipment_License_No") = Me.txt_LicenseNo.Text.Trim
            drSave("Product_Features") = Me.txt_ProductFeatures.Text.Trim
            drSave("Use_Reason") = Me.txt_UseReason.Text.Trim
            drSave("Precautions") = Me.txt_Precautions.Text.Trim
            drSave("Side_Effect") = Me.txt_SideEffect.Text.Trim
            drSave("Efficacy_Comparison") = Me.txt_EfficacyComparison.Text.Trim
            drSave("Insu_Order_Type_Id") = Me.txt_InsuOrderType.Text.Trim

            If chk_IsAlter.Checked Then
                drSave("Is_Alter") = "Y"
            Else
                drSave("Is_Alter") = "N"
            End If

            drSave("Alternative_Insu_Code_1") = Me.txt_InsuCode1.Text.Trim
            drSave("Alternative_Insu_Code_2") = Me.txt_InsuCode2.Text.Trim
            drSave("Alternative_Insu_Code_3") = Me.txt_InsuCode3.Text.Trim
            drSave("Alternative_Insu_Code_4") = Me.txt_InsuCode4.Text.Trim
            drSave("Alternative_Insu_Code_5") = Me.txt_InsuCode5.Text.Trim
            drSave("Alternative_Insu_Code_6") = Me.txt_InsuCode6.Text.Trim
            drSave("Alternative_Insu_Code_7") = Me.txt_InsuCode7.Text.Trim
            drSave("Alternative_Insu_Code_8") = Me.txt_InsuCode8.Text.Trim
            drSave("Alternative_Insu_Code_9") = Me.txt_InsuCode9.Text.Trim
            drSave("Alternative_Insu_Code_10") = Me.txt_InsuCode10.Text.Trim

            If chk_Agreement.Checked Then
                drSave("Is_Agreement_Print") = "Y"
            Else
                drSave("Is_Agreement_Print") = "N"
            End If

            If chk_Instruction.Checked Then
                drSave("Is_Instruction_Print") = "Y"
            Else
                drSave("Is_Instruction_Print") = "N"
            End If

            If CurrentUserID.Trim() = "" Then
                CurrentUserID = "pubuser"
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




End Class

