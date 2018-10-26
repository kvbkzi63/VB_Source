'/*
'*****************************************************************************
'*
'*    Page/Class Name:  信件群組設定
'*              Title:	JobMailGroupDetailUI
'*        Description:	1.新增 2.修改 3.刪除 4.查詢 5.清除
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-06-16
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-06-16
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
Imports JOBClientServiceFactory
Imports Project.Comm.JOB
Imports System.Data
Imports System.Windows.Forms

'請修改成 TableFactory 所在的Utility
'Imports NIS.Comm.TableFactory

'請修改成使用到的Servicefactory
'Imports NIS.Client.ServiceFactory


Public Class JobMailGroupDetailUI
    Inherits IUCLMaintainFormUI

#Region "     變數宣告 "

#Region "     *Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = PrjMailGroupDetailDataTableFactory.columnsName

    '存檔的Table Name
    Private gblTableName As String = PrjMailGroupDetailDataTableFactory.tableName

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = PrjMailGroupDetailDataTableFactory.getDataTable

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "群組代號,所屬人,收件者,EMail,建立者,建立時間,修改者,修改時間"

    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "80,80,80,200,80,200,80,200"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1,2,3,4,5,6,7"

    '*******************************************************************************

    Dim m_GroupID As String = ""
    Public Property GroupID As String
        Get
            Return m_GroupID
        End Get
        Set(value As String)
            m_GroupID = value
        End Set
    End Property
    Dim m_GroupName As String = ""
    Public Property GroupName As String
        Get
            Return m_GroupName
        End Get
        Set(value As String)
            m_GroupName = value
        End Set
    End Property
#End Region

#Region "     *使用的service宣告 "

    '*******************************************************************************
    '依呼叫的 service 修改    ******************************************************
    '*******************************************************************************

    '定義使用的service介面
    Dim Job As IJOBServiceManager

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
    ''' <remarks>by Will.Lin on 2017-6-16</remarks>
    Public Overrides Function InsertData() As Boolean

        Try
            Dim returnBoolean As Boolean = False

            Dim iButtonFlag As Integer = buttonAction.INSERT

            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '新增，建立者與修改者為同一人
            Dim InsertDS As DataSet = GetSaveDS(CurrentUserID, CurrentUserID, "InsertMailGroupDetail")

            Dim ResultDS As DataSet = Job.PRJDoAction(InsertDS)



            '有寫入資料要回傳True
            If CheckMethodUtil.CheckHasValue(ResultDS) AndAlso ResultDS.Tables(0).Rows(0).Item(0) > 0 Then
                returnBoolean = True
                Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryMailGroupDetail)
                SendDS.Tables(0).Rows.Add("QueryMailGroupDetail", GroupID, CurrentUserID, cbo_Receiver.SelectedValue)
                updateDataGridView(iButtonFlag, Job.PRJDoAction(SendDS))
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
    ''' <remarks>by Will.Lin on 2017-6-16</remarks>
    Public Overrides Function updateData() As Boolean

        Dim returnBoolean As Boolean = False

        Dim iButtonFlag As Integer = buttonAction.UPDATE

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '修改，建立者與修改者為不同人
            Dim updateDS As DataSet = GetSaveDS(globalCreateUser, CurrentUserID, "UpdateMailGroupDetail")
            Dim ResultDS As DataSet = Job.PRJDoAction(updateDS)


            '有寫入資料要回傳True
            If CheckMethodUtil.CheckHasValue(ResultDS) AndAlso ResultDS.Tables(0).Rows(0).Item(0) > 0 Then
                returnBoolean = True
                Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryMailGroupDetail)
                SendDS.Tables(0).Rows.Add("QueryMailGroupDetail", GroupID, CurrentUserID, cbo_Receiver.SelectedValue)
                updateDataGridView(iButtonFlag, Job.PRJDoAction(SendDS))

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
    ''' <remarks>by Will.Lin on 2017-6-16</remarks>
    Public Overrides Function deleteData() As Boolean

        Dim returnBoolean As Boolean

        Dim iButtonFlag As Integer = buttonAction.DELETE

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.DeleteMailGroupDetail)
            SendDS.Tables(0).Rows.Add("DeleteMailGroupDetail", GroupID, CurrentUserID, cbo_Receiver.SelectedValue)
            '自資料庫刪除
            Dim ResultDS As DataSet = Job.PRJDoAction(SendDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If CheckMethodUtil.CheckHasValue(ResultDS) AndAlso ResultDS.Tables(0).Rows(0).Item(0) > 0 Then

                returnBoolean = True

                '刪除成功，清除控制項
                CleanControls(tlp_Main1)

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
    ''' <remarks>by Will.Lin on 2017-6-16</remarks>
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

            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryMailGroupDetail)
            SendDS.Tables(0).Rows.Add("QueryMailGroupDetail", GroupID, CurrentUserID, cbo_Receiver.SelectedValue)
            '查詢 
            queryDS = Job.PRJDoAction(SendDS)


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
    ''' <remarks>by Will.Lin on 2017-6-16</remarks>
    Public Overrides Sub clearData()

        Try

            CleanControls(tlp_Main1)


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
    ''' <remarks>by Will.Lin on 2017-6-16</remarks>
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

            txt_GroupId.Text = GroupID
            txt_GroupName.Text = GroupName


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
    ''' <remarks>by Will.Lin on 2017-6-16</remarks>
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
    ''' <remarks>by Will.Lin on 2017-6-16</remarks>
    Private Sub initialComboBox()

        Try

            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryEmployeeListByLevel)
            SendDS.Tables(0).Rows.Add("QueryEmployeeListByLevel", "1")
            '取得 Combobox的 資料
            Dim cboDS As DataSet = Job.PRJDoAction(SendDS)

            '檢查資料來源
            If CheckHasTable(cboDS, "PUB_Employee") Then

                cbo_Receiver.Initial(cboDS.Tables("PUB_Employee"), "Employee_En_Name", "Employee_Code")

            End If


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
    ''' <remarks>by Will.Lin on 2017-6-16</remarks>
    Private Sub LoadServiceManager()
        Try



            Job = JOBServiceManager.getInstance()

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
    ''' <remarks>by Will.Lin on 2017-6-16</remarks>
    Public Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean

        Dim returnBoolean As Boolean = False

        '儲存要顯示 Error 字串
        Dim stbErrorCollection As StringBuilder = New StringBuilder

        Try

            CleanControlsBackcolor(tlp_Main1)

            '*******************************************************************************



            '設定檢查的控制項、檢查未通過的顯示名稱
            Dim objCheck1 As UCLComboBoxUC = cbo_Receiver
            Dim errorStr1 As String = "收件者、"

            Dim objCheck2 As TextBox = txt_EMail
            Dim errorStr2 As String = "電子郵件、"


            Select Case iButtonFlag

                '新增/修改時的檢查
                Case buttonAction.INSERT, buttonAction.UPDATE, buttonAction.DELETE

                    '收件者 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)

                    '電子郵件 欄位檢查並設定檢查結果
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
    ''' <remarks>by Will.Lin on 2017-6-16</remarks>
    Public Overrides Sub dgvCellClick()

        Try



            CleanControlsBackcolor(tlp_Main1)

            '被點選的資料列大於零，才執行動作
            If dgvShowData.CurrentCellAddress.Y >= 0 Then



                cbo_Receiver.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Employee_Name").Value.ToString.Split("-")(0))

                txt_EMail.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("EMail").Value)

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
    ''' <remarks>by Will.Lin on 2017-6-16</remarks>
    Private Function GetSaveDS(ByVal inputCreateUser As String, ByVal inputModifiedUser As String, ByVal Action As String) As DataSet

        Dim returnDataSet As DataSet

        Try

            '產生要存檔的Dataset
            returnDataSet = GenDataSet(gblTableName, gblColumnNameDB)
            returnDataSet.Tables(0).Columns.Add("Action")
            Dim drSave As DataRow = returnDataSet.Tables(gblTableName).NewRow()
            drSave("Action") = Action
            drSave("Group_ID") = GroupID
            drSave("Employee_Code") = cbo_Receiver.SelectedValue
            drSave("EMail") = txt_EMail.Text
            drSave("Belong_Employee_Code") = CurrentUserID
            drSave("Create_User") = CurrentUserID
            drSave("Modified_User") = CurrentUserID

            returnDataSet.Tables(gblTableName).Rows.Add(drSave)

            Return returnDataSet

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得要存檔的Dataset"})
        End Try

    End Function



#End Region

#Region ""
    ''' <summary>
    ''' 收件者被選擇的動作
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbo_Receiver_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Receiver.SelectedIndexChanged

        Try
            If cbo_Receiver.SelectedValue <> "" Then
                Dim ds As DataSet = Syscom.Client.Servicefactory.PubServiceManager.getInstance.PUBEmployeequeryEmployeeByEmpCode(cbo_Receiver.SelectedValue)
                If CheckHasValue(ds) Then
                    txt_EMail.Text = ds.Tables(0).Rows(0).Item("Email")
                End If
            Else
                txt_EMail.Text = ""
            End If


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"收件者被選擇的動作"})
        End Try
    End Sub


#End Region
#End Region




End Class

