'/*
'*****************************************************************************
'*
'*    Page/Class Name:  科室維護
'*              Title:	PUBDepartmentUI
'*        Description:	1.新增 2.修改 3.刪除 4.查詢 5.清除
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-17
'*      Last Modifier:	承毅
'*   Last Modify Date:	2016-09-20
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


Public Class PUBDepartmentUI
    Inherits IUCLMaintainFormUI

#Region "     變數宣告 "

#Region "     *Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = PubDepartmentDataTableFactory.columnsName

    '存檔的Table Name
    Private gblTableName As String = PubDepartmentDataTableFactory.tableName

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = PubDepartmentDataTableFactory.getDataTable

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "24,25"

    '共用的下拉選單資料-科室層級
    Private gblDeptLevelDS As New DataSet
    Private gblAccDeptDS As New DataSet

    '*******************************************************************************

#End Region

#End Region

#Region "     *使用的service宣告 "

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
    ''' <remarks>by Will,Lin on 2015-9-17</remarks>
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
            Dim count As Integer = Pub.insertPUBDepartment(InsertDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True




                '******************************************************************************
                '修改  ************************************************************************
                '******************************************************************************


                '拿掉註解，修改查詢ByPK 方法即可，修改完成後拿掉此行註解 
                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                updateDataGridView(iButtonFlag, Pub.queryPUBDepartmentByCond(Me.txtDeptCode.Text, Me.txtDeptName.Text, Me.txtDeptEnName.Text))

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
    ''' <remarks>by Will,Lin on 2015-9-17</remarks>
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

            '寫入資料庫
            Dim count As Integer = Pub.updatePUBDepartment(updateDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                updateDataGridView(iButtonFlag, Pub.queryPUBDepartmentByCond(Me.txtDeptCode.Text, Me.txtDeptName.Text, Me.txtDeptEnName.Text))

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
    ''' <remarks>by Will,Lin on 2015-9-17</remarks>
    Public Overrides Function deleteData() As Boolean

        Dim returnBoolean As Boolean

        Dim iButtonFlag As Integer = buttonAction.DELETE

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '自資料庫刪除
            Dim count As Integer = Pub.deletePUBDepartment(Me.txtDeptCode.Text)

            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                '刪除成功，清除控制項
                CleanControls(tlp_nonButton)
                dgvShowData.ClearDS()
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
    ''' <remarks>by Will,Lin on 2015-9-17</remarks>
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
            queryDS = Pub.queryPUBDepartmentByCond(Me.txtDeptCode.Text, Me.txtDeptName.Text, Me.txtDeptEnName.Text)

            '有查到 Table 要回傳True
            If CheckHasTable(queryDS) Then

                '如果資料列為零要顯示查無符合條件資料
                If queryDS.Tables(0).Rows.Count = 0 Then

                    MessageHandling.ShowWarnMsg("CMMCMMB933", New String() {})

                End If

                '顯示資料在 Grid 上
                showResult(dgvShowData, queryDS)
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
    ''' <remarks>by Will,Lin on 2015-9-17</remarks>
    Public Overrides Sub clearData()

        Try
            CleanControls(tlp_nonButton)
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
    ''' <remarks>by Will,Lin on 2015-9-17</remarks>
    Public Overrides Sub initialData()

        Try

            '載入服務管理員
            LoadServiceManager()

            '初始化 - DataGridView
            showResult(dgvShowData, genDS("dgvShowData"))

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



#End Region

#Region "     *初始化 - ComboBox "

    ''' <summary>
    ''' 初始化 - ComboBox
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-9-17</remarks>
    Private Sub initialComboBox()

        Try


            gblDeptLevelDS = Pub.queryPUBSysCode("86")


            If CheckHasTable(gblDeptLevelDS, "Pub_Syscode") Then
                cbo_Dept_Level_Id.DataSource = gblDeptLevelDS.Tables(0).Copy
                cbo_Dept_Level_Id.uclDisplayIndex = "0,1"
                cbo_Dept_Level_Id.uclValueIndex = "0"
                cbo_Dept_Level_Id.SelectedValue = ""
            End If

            '承毅
            gblAccDeptDS = Pub.QueryPubAccDeptName()
            cbo_Acc_Dept.DataSource = gblAccDeptDS.Tables(0).Copy
            cbo_Acc_Dept.uclDisplayIndex = "0,1"
            cbo_Acc_Dept.uclValueIndex = "0"
            cbo_Acc_Dept.SelectedValue = ""

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
    ''' <remarks>by Will,Lin on 2015-9-17</remarks>
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
    ''' <remarks>by Will,Lin on 2015-9-17</remarks>
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
            Dim objCheck1 As UCLTextBoxUC = txtDeptCode
            Dim errorStr1 As String = "科室代碼、"

            Dim objCheck2 As UCLTextBoxUC = txtDeptName
            Dim errorStr2 As String = "科室名稱、"



            '*******************************************************************************************************************




            Select Case iButtonFlag

                '新增/修改時的檢查
                Case buttonAction.INSERT, buttonAction.UPDATE
                    '科室代碼 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)

                    '科室名稱 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck2, errorStr2, stbErrorCollection, returnBoolean)


                    '*********************************************************************************************************************
                    '刪除時的檢查
                Case buttonAction.DELETE

                    '科室代碼 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)

                    '科室名稱 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck2, errorStr2, stbErrorCollection, returnBoolean)

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
    ''' <remarks>by Will,Lin on 2015-9-17</remarks>
    Public Overrides Sub dgvCellClick()

        Try

            '清除欄位背景顏色
            CleanControlsBackcolor(tlp_nonButton)




            '被點選的資料列大於零，才執行動作
            If dgvShowData.CurrentCellAddress.Y >= 0 Then


                txtDeptCode.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Dept_Code").Value)
                txtShortName.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Short_Name").Value)
                txtDeptName.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Dept_Name").Value)
                txtDeptEnName.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Dept_En_Name").Value)

                txt_Belong_Dept_Code.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Belong_Dept_Code").Value)
                txt_Ipd_Sort_Value.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Ipd_Sort_Value").Value)
                txt_Emg_Sort_Value.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Emg_Sort_Value").Value)
                txt_Sort_Value.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Sort_Value").Value)

                txt_Emg_Dept_En_Name.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Emg_Dept_En_Name").Value)
                txt_Emg_Dept_Name.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Emg_Dept_Name").Value)

                txt_Ipd_Dept_Name.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Ipd_Dept_Name").Value)
                txt_Ipd_Dept_En_Name.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Ipd_Dept_En_Name").Value)

                txt_NHI_Ipd_Dept_Code.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("NHI_Ipd_Dept_Code").Value)
                txt_NHI_Opd_Dept_Code.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("NHI_Opd_Dept_Code").Value)

                txt_Upper_Dept_Code.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Upper_Dept_Code").Value)
                cbo_Dept_Level_Id.SelectedValue = StringUtil.nvl(dgvShowData.GetDBDS.Tables(0).Rows(dgvShowData.CurrentCellAddress.Y).Item("Dept_Level_Id").ToString)
                '承毅
                cbo_Acc_Dept.SelectedValue = StringUtil.nvl(dgvShowData.GetDBDS.Tables(0).Rows(dgvShowData.CurrentCellAddress.Y).Item("Acc_Dept").ToString)

                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_Emg_Dept").Value) = "Y" Then
                    chk_Is_Emg_Dept.Checked = True
                Else
                    chk_Is_Emg_Dept.Checked = False
                End If
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_Ipd_Dept").Value) = "Y" Then
                    chk_Is_Ipd_Dept.Checked = True
                Else
                    chk_Is_Ipd_Dept.Checked = False
                End If
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_Nrs_Station").Value) = "Y" Then
                    chk_Is_Nrs_Station.Checked = True
                Else
                    chk_Is_Nrs_Station.Checked = False
                End If
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_Reg_Dept").Value) = "Y" Then
                    chk_Is_Reg_Dept.Checked = True
                Else
                    chk_Is_Reg_Dept.Checked = False
                End If
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("DC").Value) = "Y" Then
                    chkDC.Checked = True
                Else
                    chkDC.Checked = False
                End If




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
    ''' <remarks>by Will,Lin on 2015-9-17</remarks>
    Private Function GetSaveDS(ByVal inputCreateUser As String, ByVal inputModifiedUser As String) As DataSet

        Dim returnDataSet As DataSet

        Try

            '產生要存檔的Dataset
            returnDataSet = GenDataSet(gblTableName, gblColumnNameDB)

            Dim drSave As DataRow = returnDataSet.Tables(gblTableName).NewRow()


            drSave("Dept_Code") = txtDeptCode.Text
            drSave("Dept_Name") = txtDeptName.Text
            drSave("Dept_En_Name") = txtDeptEnName.Text
            drSave("Short_Name") = txtShortName.Text
            drSave("NHI_Opd_Dept_Code") = txt_NHI_Opd_Dept_Code.uclCodeValue
            drSave("NHI_Ipd_Dept_Code") = txt_NHI_Ipd_Dept_Code.uclCodeValue

            drSave("Belong_Dept_Code") = txt_Belong_Dept_Code.Text
            drSave("Dept_Level_Id") = cbo_Dept_Level_Id.SelectedValue

            '承毅
            drSave("Acc_Dept") = cbo_Acc_Dept.SelectedValue
            'Dim str As String = cbo_Acc_Dept.SelectedValue

            drSave("Upper_Dept_Code") = txt_Upper_Dept_Code.Text
            drSave("Ipd_Sort_Value") = txt_Ipd_Sort_Value.Text
            drSave("Emg_Sort_Value") = txt_Emg_Sort_Value.Text
            drSave("Sort_Value") = txt_Sort_Value.Text

            drSave("Ipd_Dept_Name") = txt_Ipd_Dept_Name.Text
            drSave("Ipd_Dept_En_Name") = txt_Ipd_Dept_En_Name.Text
            drSave("Emg_Dept_Name") = txt_Emg_Dept_Name.Text
            drSave("Emg_Dept_En_Name") = txt_Emg_Dept_En_Name.Text

            drSave("Create_User") = inputCreateUser
            drSave("Modified_User") = inputModifiedUser




            drSave("Create_User") = inputCreateUser

            drSave("Modified_User") = inputModifiedUser

            drSave("Effect_Date") = "1911/01/01"
            If chkDC.Checked Then
                drSave("Dc") = "Y"
                drSave("End_Date") = Now.ToString("yyyyMMdd")
            Else
                drSave("Dc") = "N"
                drSave("End_Date") = "2999/12/31"
            End If

            If chk_Is_Emg_Dept.Checked Then
                drSave("Is_Emg_Dept") = "Y"
            Else
                drSave("Is_Emg_Dept") = "N"
            End If
            If chk_Is_Ipd_Dept.Checked Then
                drSave("Is_Ipd_Dept") = "Y"
            Else
                drSave("Is_Ipd_Dept") = "N"
            End If
            If chk_Is_Nrs_Station.Checked Then
                drSave("Is_Nrs_Station") = "Y"
            Else
                drSave("Is_Nrs_Station") = "N"
            End If
            If chk_Is_Reg_Dept.Checked Then
                drSave("Is_Reg_Dept") = "Y"
            Else
                drSave("Is_Reg_Dept") = "N"
            End If
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


#Region "### 顯示資料(DataGridView) ###"

    ''' <summary>
    ''' 取得欄位顯示的欄位資料
    ''' </summary>
    ''' <param name="dgvName">DataGridView的Name</param>
    ''' <remarks></remarks>
    Private Function getColumnData(ByVal dgvName As String) As String(,)
        'Array元素Index的對照：Grid欄位顯示名稱、資料庫欄位名稱、顯示與否、(日期欄位D,DT、金額M、數值NO)與否、顯示欄位的長度
        Select Case dgvName
            Case "dgvShowData"
                '{"科別代碼", "科別名稱", "科別英文", "上層科室", "生效起日", "迄日", "簡稱",  "班表使用科別", "停用", "建立者", "建立時間", "修改者", "修改時間"}

                Return New String(,) {{"科室代碼", "Dept_Code", "Y", "N", ""}, _
                                      {"簡稱", "Short_Name", "Y", "N", ""}, _
                                      {"科室名稱", "Dept_Name", "Y", "N", ""}, _
                                      {"英文名稱", "Dept_En_Name", "Y", "N", ""}, _
                                      {"班表使用科別", "Is_Reg_Dept", "Y", "N", ""}, _
                                      {"排序", "Sort_Value", "Y", "N", ""}, _
                                      {"科室名稱(急)", "Emg_Dept_Name", "Y", "N", ""}, _
                                      {"英文名稱(急)", "Emg_Dept_En_Name", "Y", "N", ""}, _
                                      {"急診科別", "Is_Emg_Dept", "Y", "N", ""}, _
                                      {"排序(急)", "Emg_Sort_Value", "Y", "N", ""}, _
                                      {"科室名稱(住)", "Ipd_Dept_Name", "Y", "N", ""}, _
                                      {"英文名稱(住)", "Ipd_Dept_En_Name", "Y", "N", ""}, _
                                      {"住院科別", "Is_Ipd_Dept", "Y", "N", ""}, _
                                      {"排序(住)", "Ipd_Sort_Value", "Y", "N", ""}, _
                                      {"健保門診科別", "NHI_Opd_Dept_Code", "Y", "N", ""}, _
                                      {"健保住院科別", "NHI_Ipd_Dept_Code", "Y", "N", ""}, _
                                      {"歸屬科別", "Belong_Dept_Code", "Y", "N", ""}, _
                                      {"上層科室", "Upper_Dept_Code", "Y", "N", ""}, _
                                      {"科室層級", "Dept_Level_Id", "Y", "N", ""}, _
                                      {"成本中心", "Acc_Dept", "Y", "N", ""}, _
                                      {"是否為護理站", "Is_Nrs_Station", "Y", "N", ""}, _
                                      {"停用", "Dc", "Y", "N", ""}, _
                                      {"建立者", "Create_User", "Y", "N", ""}, _
                                      {"建立時間", "Create_Time", "Y", "N", ""}, _
                                      {"修改者", "Modified_User", "Y", "N", ""}, _
                                      {"修改時間", "Modified_Time", "Y", "N", ""}, _
                                      {"有效起日", "Effect_Date", "N", "N", ""}, _
                                      {"有效迄日", "End_Date", "N", "N", ""}}

        End Select
        Return Nothing
    End Function

    ''' <summary>
    ''' 顯示最新的資料在DataGridView
    ''' </summary>
    ''' <param name="ds">欲顯示的資料</param>
    ''' <remarks></remarks>
    Private Sub showResult(ByRef dgv As UCLDataGridViewUC, ByVal ds As DataSet)
        Try
            Dim headerTxtStr As String = ""
            Dim Visible As String = ""
            Dim hashTable As New Hashtable()

            Dim clnObj(,) As String = getColumnData(dgv.Name)
            For num As Integer = 0 To clnObj.GetUpperBound(0)
                If headerTxtStr.Length > 0 Then
                    headerTxtStr += ","
                End If
                headerTxtStr += clnObj(num, 0)
            Next
            '設定不被顯示的欄位
            For num As Integer = 0 To clnObj.GetUpperBound(0)
                If clnObj(num, 2) = "N" Then
                    Visible += num & ","
                End If
            Next
            If Visible.Length > 0 Then
                Visible = Visible.Substring(0, Visible.Length - 1)
            End If
            hashTable.Add(-1, ds)
            dgv.uclNonVisibleColIndex = Visible

            '手動處理Grid欄位的加入
            Select Case dgv.Name
                Case "dgvShowData"
                    '插入科室層級的選單欄位
                    Dim DeptLevelIdCell As New ComboBoxCell
                    '填入【科室層級】
                    DeptLevelIdCell.Ds = gblDeptLevelDS.Copy
                    DeptLevelIdCell.DisplayIndex = "0,1"
                    DeptLevelIdCell.ValueIndex = "0"
                    hashTable.Add(18, DeptLevelIdCell)
                    '承毅
                    DeptLevelIdCell.Ds = gblAccDeptDS.Copy
                    DeptLevelIdCell.DisplayIndex = "0,1"
                    DeptLevelIdCell.ValueIndex = "0"
                    hashTable.Add(19, DeptLevelIdCell)

            End Select
            dgv.uclHeaderText = headerTxtStr
            dgv.uclNonVisibleColIndex = Visible
            dgv.Initial(hashTable)
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.SetColReadOnly(19, True)
            '----------------------------------------------------------------------------
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB013", New String() {}, "")
        End Try
    End Sub


    ''' <summary>
    ''' 利用ColumnData的資料產生一個Data Set且包含一個空的Table
    ''' </summary>
    ''' <param name="dgvName">欲顯示資料的DataGridView名稱</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function genDS(ByVal dgvName As String) As DataSet
        '----------------------------------------------------------------------------
        '#Step1.取得欄位顯示的欄位資料
        '----------------------------------------------------------------------------
        Dim columnNameMap As String(,) = getColumnData(dgvName)
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        '#Step2.回傳Data Set
        '----------------------------------------------------------------------------
        Using dt As New DataTable("dataDT")

            For iIndex As Integer = 0 To columnNameMap.GetUpperBound(0)
                dt.Columns.Add(columnNameMap(iIndex, 1))
            Next

            Using ds As New DataSet
                ds.Tables.Add(dt.Copy)

                Return ds
            End Using
        End Using
        '----------------------------------------------------------------------------
    End Function


    ''' <summary>
    ''' 設定DataGridView的顯示欄位
    ''' </summary>
    ''' <param name="uclDgv"></param>
    ''' <remarks></remarks>
    Private Sub setDataGridViewVisibleColumnAndColumnWidth(ByVal uclDgv As UCLDataGridViewUC)

        Dim clnWidthStr As String = ""

        Dim clnObj(,) As String = getColumnData(uclDgv.Name)
        For num As Integer = 0 To clnObj.GetUpperBound(0)
            If clnWidthStr.Length > 0 Then
                clnWidthStr += ","
            End If

            If clnObj(num, 4).Length.Equals(0) Then
                clnWidthStr += "1"
            Else
                clnWidthStr += clnObj(num, 4)
            End If
        Next
        uclDgv.uclColumnWidth = clnWidthStr

    End Sub

#End Region

#End Region





End Class

