'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患DNR記錄檔
'*              Title:	PubPatientDNRUI
'*        Description:	1.新增 2.修改 3.刪除 4.查詢 5.清除
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Eddie,Lu
'*        Create Date:	2016-05-19
'*      Last Modifier:	Eddie,Lu
'*   Last Modify Date:	2016-05-19
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


Public Class PubPatientDNRUI
    Inherits IUCLMaintainFormUI

#Region "     變數宣告 "

#Region "     *Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = PUBPatientDNRDataTableFactory.columnsName

    '存檔的Table Name
    Private gblTableName As String = PUBPatientDNRDataTableFactory.tableName

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = PUBPatientDNRDataTableFactory.getDataTable

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "病歷號,身分證號,姓名,來源別(代碼),來源別,DNR流水號,DNR類別(代碼),DNR類別,停用(代碼),停用,停用者,停用時間(西元年),停用時間,建立者,建立時間(西元年),建立時間,修改者,修改時間(西元年),修改時間"

    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "80,100,80,0,80,0,0,100,0,50,0,0,0,100,0,120,100,0,120"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1,2,4,7,9,13,15,16,18"

    '*******************************************************************************

#End Region

#Region "     *使用的service宣告 "

    '定義使用的service介面
    Dim Pub As IPubServiceManager

#End Region

#Region "     屬性設定 "

    Dim gblDNRNo As String = ""

#End Region

#Region "     主要功能 "

#Region "     *按鈕事件 "

#Region "     *新增 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Eddie,Lu on 2016-5-19</remarks>
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

            '寫入資料庫
            Dim count As Integer = Pub.PUBPatientDNRinsertWithDNRNo(InsertDS)

            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                btnQuery.PerformClick()

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
    ''' <remarks>by Eddie,Lu on 2016-5-19</remarks>
    Public Overrides Function updateData() As Boolean

        Dim returnBoolean As Boolean = False

        Dim iButtonFlag As Integer = buttonAction.UPDATE

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            If gblDNRNo = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "請選取一筆資料")
                Return False
            End If

            '修改，建立者與修改者為不同人
            Dim updateDS As DataSet = GetSaveDS(globalCreateUser, CurrentUserID)

            '寫入資料庫
            Dim count As Integer = Pub.PUBPatientDNRupdate(updateDS)

            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                btnQuery.PerformClick()

            Else

                '無資料被修改
                MessageHandling.showWarnMsg("CMMCMMB310", New String() {"修改"})
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
    ''' <remarks>by Eddie,Lu on 2016-5-19</remarks>
    Public Overrides Function deleteData() As Boolean

        Dim returnBoolean As Boolean

        Dim iButtonFlag As Integer = buttonAction.DELETE

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            If gblDNRNo = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "請選取一筆資料")
                Return False
            End If

            '帶入來源
            Dim strSourceKind As String = ""
            If rbtSourceKind1.Checked = True Then
                strSourceKind = "1"
            Else
                strSourceKind = "2"
            End If

            '自資料庫刪除
            Dim count As Integer = Pub.PUBPatientDNRdelete(txtChartNo.Text, strSourceKind, gblDNRNo)

            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                '刪除成功，清除控制項及重設變數
                CleanControls(tlp_Main)
                txtIdno.BackColor = Control.DefaultBackColor
                txtPatientName.BackColor = Control.DefaultBackColor
                '[來源]預設選取”健保局”
                rbtSourceKind1.Checked = True
                '清空DNR序號
                gblDNRNo = ""

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
    ''' <remarks>by Eddie,Lu on 2016-5-19</remarks>
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
            queryDS = Pub.PUBPatientDNRqueryByPKROC(txtChartNo.Text, cboDNRKindId.SelectedValue)

            '有查到 Table 要回傳True
            If CheckHasTable(queryDS) Then

                '如果資料列為零要顯示查無符合條件資料
                If queryDS.Tables(0).Rows.Count = 0 Then

                    MessageHandling.showWarnMsg("CMMCMMB933", New String() {})

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
    ''' <remarks>by Eddie,Lu on 2016-5-19</remarks>
    Public Overrides Sub clearData()

        Try

            '清除傳入控制項的所有內含的控制項
            CleanControls(tlp_Main)
            txtIdno.BackColor = Control.DefaultBackColor
            txtPatientName.BackColor = Control.DefaultBackColor
            dgvShowData.ClearDS()
            '[來源]預設選取”健保局”
            rbtSourceKind1.Checked = True
            '清空DNR序號
            gblDNRNo = ""

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
    ''' <remarks>by Eddie,Lu on 2016-5-19</remarks>
    Public Overrides Sub initialData()

        Try

            '載入服務管理員
            LoadServiceManager()

            '初始化 - DataGridView
            ShowDgv()

            '初始化 - ComboBox
            initialComboBox()

            '[來源]預設選取”健保局”
            rbtSourceKind1.Checked = True

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
    ''' <remarks>by Eddie,Lu on 2016-5-19</remarks>
    Private Sub ShowDgv()

        Try

            Dim emptyDt As DataTable = GenDataTable(gblColumnTextDgv.Split(","))

            '顯示空的Dataset 在　Grid 上
            UCLScreenUtil.ShowDgv(dgvShowData, emptyDt, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)

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
    ''' <remarks>by Eddie,Lu on 2016-5-19</remarks>
    Private Sub initialComboBox()

        Try

            '取得 Combobox的 資料
            Dim cboDS As DataSet = Pub.PUBPatientDNRqueryCboDs()

            '檢查資料來源
            If CheckHasTable(cboDS, "PUB_Patient_DNR") Then

                '設定資料來源
                cboDNRKindId.Initial(cboDS.Tables("PUB_Patient_DNR"), "Id_Name", "Code_Id")

            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - ComboBox"})
        End Try

    End Sub

#End Region

#Region "     輸入病歷號元件事件 "

    ''' <summary>
    ''' 輸入病歷號元件事件
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub txtChartNo_Enter() Handles txtChartNo.Leave

        Try

            '設定身分證號的控制項
            txtIdno.Text = txtChartNo.GetPatientObj.Idno
            '設定姓名的控制項
            txtPatientName.Text = txtChartNo.GetPatientObj.Patient_Name

            txtIdno.BackColor = Control.DefaultBackColor
            txtPatientName.BackColor = Control.DefaultBackColor

        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

#End Region

#Region "     *載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Eddie,Lu on 2016-5-19</remarks>
    Private Sub LoadServiceManager()
        Try

            Pub = PubServiceManager.getInstance()

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
    ''' <remarks>by Eddie,Lu on 2016-5-19</remarks>
    Public Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean

        Dim returnBoolean As Boolean = False

        '儲存要顯示 Error 字串
        Dim stbErrorCollection As StringBuilder = New StringBuilder

        Try

            '清除傳入控制項的所有內含的控制項的欄位底色
            '清除欄位底色
            CleanControlsBackcolor(tlp_Main)
            txtIdno.BackColor = Control.DefaultBackColor
            txtPatientName.BackColor = Control.DefaultBackColor

            '*******************************************************************************************************************
            '修改成要設定檢查的控制項、檢查未通過的顯示名稱 EX: 護理站未輸入 只要設定成 [護理站] 即可  *************************
            '本檢查只會檢查有沒有值，如果是其他的檢查需求，須另行增加!  ********************************************************
            '*******************************************************************************************************************

            '設定檢查的控制項、檢查未通過的顯示名稱
            Dim objCheck1 As UCLChartNoUC = txtChartNo
            Dim errorStr1 As String = "病歷號、"

            '*******************************************************************************************************************




            Select Case iButtonFlag

                '新增/修改時的檢查
                Case buttonAction.INSERT, buttonAction.UPDATE




                    '*********************************************************************************************************************
                    '設定新增/修改要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ***************************
                    '*********************************************************************************************************************

                    '病歷號 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)
                    '*********************************************************************************************************************





                    '刪除時的檢查
                Case buttonAction.DELETE



                    '*********************************************************************************************************************
                    '設定刪除要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ********************************
                    '*********************************************************************************************************************

                    '病歷號 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)
                    '*********************************************************************************************************************




                    '查詢時的檢查
                Case buttonAction.QUERY

                    '*********************************************************************************************************************
                    '設定查詢要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ********************************
                    '*********************************************************************************************************************

                    '病歷號 欄位檢查並設定檢查結果
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
    ''' <remarks>by Eddie,Lu on 2016-5-19</remarks>
    Public Overrides Sub dgvCellClick()

        Try

            '清除傳入控制項的所有內含的控制項的欄位底色
            '清除欄位背景顏色
            CleanControlsBackcolor(tlp_Main)
            txtIdno.BackColor = Control.DefaultBackColor
            txtPatientName.BackColor = Control.DefaultBackColor

            '被點選的資料列大於零，才執行動作
            If dgvShowData.CurrentCellAddress.Y >= 0 Then



                '*************************************************************************************************************************
                '設定點選後，畫面上方要跟著異動的控制項，譬如說 TextBox 的文字，Combobox 的 select Value *********************************
                '*************************************************************************************************************************

                '{ Chart_No,Source_Kind,DNR_No,DNR_Kind_Id,Cancel,Cancel_User,Cancel_Time,Create_User,Create_Time,Modified_User ,Modified_Time   }
                '設定病歷號的控制項
                txtChartNo.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Chart_No").Value)
                '設定身分證號的控制項
                txtIdno.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Idno").Value)
                '設定姓名的控制項
                txtPatientName.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Patient_Name").Value)

                '設定來源別的控制項
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Source_Kind").Value) = "2" Then
                    rbtSourceKind2.Checked = True
                Else
                    rbtSourceKind1.Checked = True
                End If

                '設定DNR類別的控制項
                cboDNRKindId.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("DNR_Kind_Id").Value)

                '設定建立者的資料 - 必須要填寫!
                globalCreateUser = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Create_User").Value)

                gblDNRNo = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("DNR_No").Value)

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
    ''' <remarks>by Eddie,Lu on 2016-5-19</remarks>
    Private Function GetSaveDS(ByVal inputCreateUser As String, ByVal inputModifiedUser As String) As DataSet

        Dim returnDataSet As DataSet

        Try

            '產生要存檔的Dataset
            returnDataSet = GenDataSet(gblTableName, gblColumnNameDB)

            Dim drSave As DataRow = returnDataSet.Tables(gblTableName).NewRow()


            '*************************************************************************************************************************
            '設定 要儲存的資料 *******************************************************************************************************
            '*************************************************************************************************************************

            '{ Chart_No,Source_Kind,DNR_No,DNR_Kind_Id,Cancel,Cancel_User,Cancel_Time,Create_User,Create_Time,Modified_User ,Modified_Time   }
            drSave("Chart_No") = nvl(txtChartNo.Text)

            If rbtSourceKind1.Checked = True Then
                drSave("Source_Kind") = "1"
            Else
                drSave("Source_Kind") = "2"
            End If

            '修改才會用到
            drSave("DNR_No") = gblDNRNo

            drSave("DNR_Kind_Id") = nvl(cboDNRKindId.SelectedValue.ToString)

            '修改才會用到
            drSave("Cancel") = "N"

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



    Private Sub txtChartNo_Enter(sender As Object, e As EventArgs) Handles txtChartNo.Leave

    End Sub
End Class

