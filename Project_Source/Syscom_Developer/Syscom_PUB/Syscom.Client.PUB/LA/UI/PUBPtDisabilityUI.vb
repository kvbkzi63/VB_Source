'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患殘障記錄檔
'*              Title:	PUBPtDisabilityUI
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-09
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-09
'*
'*****************************************************************************
'*/


Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports System.Text
Imports Syscom.Client.UCL

Public Class PUBPtDisabilityUI
    Inherits Syscom.Client.UCL.BaseFormUI

    Dim objPub As IPubServiceManager = Nothing

    Dim pDataRowView As DataRowView

    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.getInstance.getFileLogger(Me)

    '獲取維護表名
    Dim tableDB As String = PubPatientDisabilityDataTableFactory.tableName

    'Grid使用的標題
    '病歷號、姓名、序號、生效日、結束日、備註、殘障類別、殘障程度
    '2012/4/9 by ccr 加入建檔者,建檔時間,修改者,修改時間 
    Dim columnNameGrid() As String = {"病歷號", "姓名", "序號", "生效日", "結束日", "殘障類別", "殘障程度", "建立者", "建立時間", "修改者", "修改時間", "備註", "殘障類別DB", "殘障程度DB", "病患殘障記錄號"}
    'Dim columnNameGrid() As String = {"病歷號", "姓名", "序號", "生效日", "結束日", "殘障類別", "殘障程度", "備註", "殘障類別DB", "殘障程度DB"}
    '獲取維護表字段名
    Dim columnNameDB() As String = PubPatientDisabilityDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubPatientDisabilityDataTableFactory.columnsLength
    '設定隱藏的欄位
    'Dim visibleColumnNo As String = "0, 1, 2, 3, 4, 5, 6, 7"
    'Dim nonVisibleColumnNo As String = " 8, 9"
    Dim visibleColumnNo As String = "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11"
    Dim nonVisibleColumnNo As String = " 12, 13, 14"

    Const MAXDATE As String = "9998/12/31"

    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        DateTimePicker
        TextBox
    End Enum
    Enum buttonAction
        INSERT
        UPDATE
        DELETE
        QUERY
        CLEAR
    End Enum

#Region "         初始化"

    Private Sub PUBPatientDisabilityUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            initialData()
        Catch ex As Exception
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 初始化對象 構建空的Grid 設定欄位長度
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance

            '構建空的Grid
            Dim ht As New Hashtable
            ht.Add(-1, genDS(DataSet_Type.Grid))
            Me.dgvShowData.Initial(ht)

            'DataGridView的欄位隱藏/顯示
            dgvShowData.uclVisibleColIndex = visibleColumnNo
            dgvShowData.uclNonVisibleColIndex = nonVisibleColumnNo

            '設定Grid滿屏
            'dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            '設定Grid 欄位寬度
            setDgvColWidth()

            '設定欄位長度
            Me.txtPatientDisabilityMemo.MaxLength = columnsLength(4)

            '初始化殘障類別
            intialCmbDisabilityTypeId()

            '初始化殘障程度
            intialCmbDisabilityDegreeId()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化殘障類別
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub intialCmbDisabilityTypeId()
        '執行查詢
        Dim dsTemp As DataSet
        Try
            dsTemp = objPub.queryPUBSysCodeByTypeIdForDisability_L("212")
            If dsTemp.Tables.Count > 0 Then
                If dsTemp.Tables(0).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    '初始化殘障類別
                    Me.cmbDisabilityTypeId.DataSource = dsTemp.Tables(0).Copy
                    Me.cmbDisabilityTypeId.uclValueIndex = "0"
                    Me.cmbDisabilityTypeId.uclDisplayIndex = "0,1"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化殘障程度
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub intialCmbDisabilityDegreeId()
        '執行查詢
        Dim dsTemp As DataSet
        Try
            dsTemp = objPub.queryPUBSysCodeByTypeIdForDisability_L("214")
            If dsTemp.Tables.Count > 0 Then
                If dsTemp.Tables(0).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    '初始化殘障程度
                    Me.cmbDisabilityDegreeId.DataSource = dsTemp.Tables(0).Copy
                    Me.cmbDisabilityDegreeId.uclValueIndex = "0"
                    Me.cmbDisabilityDegreeId.uclDisplayIndex = "0,1"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "         button 事件"

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.clearInfoMsg()
            If (insertData()) Then
                If (dgvShowData.CurrentRow IsNot Nothing AndAlso dgvShowData.CurrentRow.Index >= 0) Then
                    '清除選中資料行 
                    dgvShowData.CurrentRow.Selected = False
                    '清除選中資料項 
                    dgvShowData.CurrentCell = Nothing
                End If
                '清除全局變量 ming 20091013 add
                pDataRowView = Nothing
                'MessageHandling.showInfoByKey("HEMCMMB005")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showInfoMsg("CMMCMMB002", New String() {})
            End If
        Catch ex As Exception
            '.Error(ex.ToString)
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.clearInfoMsg()
            If (updateData()) Then
                'MessageHandling.showInfoByKey("HEMCMMB005")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showInfoMsg("CMMCMMB003", New String() {})
            End If
        Catch ex As Exception
            '.Error(ex.ToString)
            'MessageHandling.showErrorByKey("HEMCMMD015")
            '********************2010/2/9 Modify By Alan**********************
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.clearInfoMsg()
            If (deleteData()) Then
                'MessageHandling.showInfoByKey("HEMCMMB005")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showInfoMsg("HEMCMMB004", New String() {})
            End If
        Catch ex As Exception
            '.Error(ex.ToString)
            'MessageHandling.showErrorByKey("HEMCMMD015")
            '********************2010/2/9 Modify By Alan**********************
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.clearInfoMsg()
            If (queryData()) Then
                If (dgvShowData.CurrentRow IsNot Nothing AndAlso dgvShowData.CurrentRow.Index >= 0) Then
                    '清除選中資料行 
                    dgvShowData.CurrentRow.Selected = False
                    '清除選中資料項 
                    dgvShowData.CurrentCell = Nothing
                End If
                '清除全局變量 ming 20091013 add
                pDataRowView = Nothing
                'MessageHandling.showInfoByKey("CMMCMMB001")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showInfoMsg("CMMCMMB001", New String() {})
            End If

        Catch ex As Exception
            '.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD001")
            '********************2010/2/9 Modify By Alan**********************
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            clearData()

            MessageHandling.clearInfoMsg()
        Catch ex As Exception
            '.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD006")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMD006", New String() {}, "")
        End Try
        MessageHandling.clearInfoMsg()
    End Sub

    Private Sub txtChartNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChartNo.Leave
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.clearInfoMsg()
            '設定姓名
            If Me.txtChartNo.Text.Trim <> "" Then
                Me.txtPatientName.Text = Me.txtChartNo.GetPatientObj().Patient_Name
            Else
                Me.txtPatientName.Text = ""
            End If

        Catch ex As Exception
            '.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD001")
            MessageHandling.showErrorMsg("CMMCMMD001", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

#End Region

#Region "         Grid 事件"

    ''' <summary>
    ''' 點選行資料,塞入輸入區
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub dgvShowData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShowData.CellClick
        Try
            If (e.RowIndex >= 0) Then
                'GRID點擊后，將選中行給全局變量 ming 20091013 add
                If dgvShowData.ContainsFocus AndAlso dgvShowData.CurrentCellAddress.Y >= 0 Then
                    pDataRowView = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).DataBoundItem
                End If

                dgvCellClick()

                changedButton()

            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showError(ResourceUtil.getString("HEMCMMB203", New String(0) {"資料"}))
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("HEMCMMB203", New String() {}, "")
        End Try
    End Sub

    ''' <summary>
    ''' 點選行資料,塞入輸入區
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub dgvCellClick()
        Try
            '清除欄位資料
            cleanFieldsValue()
            '清除欄位背景顏色
            cleanFieldsColor()
            If dgvShowData.CurrentCellAddress.Y >= 0 Then
                '病歷號、姓名、生效日、結束日、備註、殘障類別、殘障程度
                Me.txtChartNo.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("病歷號").Value.ToString.Trim
                Me.txtPatientName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("姓名").Value.ToString.Trim
                Me.txtPatientDisabilityMemo.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("備註").Value.ToString.Trim
                Me.cmbDisabilityTypeId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("殘障類別DB").Value.ToString.Trim
                Me.cmbDisabilityDegreeId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("殘障程度DB").Value.ToString.Trim
                Me.dtpEndDate.SetValue(DateUtil.TransDateToWE(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("結束日").Value.ToString))
                Me.dtpEffectDate.SetValue(DateUtil.TransDateToWE(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("生效日").Value.ToString))
                Me.txtPatientDisabilityNo.Text = CInt(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("序號").Value.ToString.Trim)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    ''' <summary>
    ''' 焦點在grid上時候，上，下，回車鍵改變選中行資料 ming 20091013 add
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvShowData_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvShowData.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter, Keys.Down, Keys.Up
                If dgvShowData.CurrentCellAddress.Y <> -1 Then
                    dgvCellClick()
                    pDataRowView = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).DataBoundItem
                End If
        End Select

    End Sub
    ''' <summary>
    ''' 焦點在grid上時候,回車鍵改變選中行資料,避開IUCLMaintainFormUI_KeyDown衝突 ming 20091013 add
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvShowData_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvShowData.KeyDown
        Dim nextIndex As Integer = -1
        Select Case e.KeyCode
            Case Keys.Enter
                nextIndex = dgvShowData.CurrentRow.Index + 1
                If (nextIndex >= 0 And nextIndex < dgvShowData.Rows.Count) Then
                    Me.dgvShowData.Focus()
                    Me.dgvShowData.Rows(nextIndex).Cells(0).Selected = True
                End If
        End Select
    End Sub

#End Region

#Region "         KeyDown 事件"

    Private Sub PUBPatientDisabilityUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                '清除
                'MessageHandling.clearInfoMsg()
                btnClear_Click(sender, e)
            Case Keys.F1
                '查詢
                'MessageHandling.clearInfoMsg()
                btnQuery_Click(sender, e)
            Case Keys.F12

                '刪除 SF12
                If e.Shift Then
                    If (btnDelete.Enabled) Then btnDelete_Click(sender, e)
                Else
                    '新增F12
                    'MessageHandling.clearInfoMsg()
                    If (btnOK.Enabled) Then btnOK_Click(sender, e)
                End If
            Case Keys.F10
                '修改
                'MessageHandling.clearInfoMsg()
                If (btnUpdate.Enabled) Then btnUpdate_Click(sender, e)
            Case Keys.Enter
                Me.ProcessTabKey(True)

            Case Keys.Enter
                Me.ProcessTabKey(True)
        End Select
    End Sub

#End Region

#Region "         公用"

    ''' <summary>
    ''' 產生一個DataSet並包含一個空的Table 給Grid用 或 DB用
    ''' </summary>
    ''' <param name="type">資料集類型</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function genDS(ByVal type As Integer) As DataSet
        Dim dsTemp As New DataSet
        Select Case type
            Case DataSet_Type.Grid
                '給Grid用Table
                dsTemp.Tables.Add(tableDB)
                For i As Integer = 0 To columnNameGrid.Length - 1
                    dsTemp.Tables(tableDB).Columns.Add(columnNameGrid(i))
                Next
            Case DataSet_Type.DB
                '給DB用Table
                dsTemp.Tables.Add(tableDB)
                For i As Integer = 0 To columnNameDB.Length - 1
                    dsTemp.Tables(tableDB).Columns.Add(columnNameDB(i))
                Next
        End Select
        Return dsTemp
    End Function

    ''' <summary>
    ''' 設定Grid 欄位寬度
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setDgvColWidth()
        dgvShowData.Columns(0).Width = 80
        dgvShowData.Columns(1).Width = 70
        dgvShowData.Columns(2).Width = 70
        dgvShowData.Columns(3).Width = 70
        dgvShowData.Columns(4).Width = 95
        dgvShowData.Columns(5).Width = 95
        dgvShowData.Columns(6).Width = 60
        dgvShowData.Columns(7).Width = 100
        dgvShowData.Columns(8).Width = 60
        dgvShowData.Columns(9).Width = 100
        dgvShowData.Columns(10).Width = 310
    End Sub

    ''' <summary>
    ''' 清除事件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub clearData()
        '清除欄位資料
        cleanFieldsValue()
        '清除欄位背景顏色
        cleanFieldsColor()
        '確定變可用
        Me.btnOK.Enabled = True
        '清除GRID資料
        dgvShowData.DataSource = Nothing
        dgvShowData.Refresh()
        '構建空的Grid
        dgvShowData.DataSource = (genDS(DataSet_Type.Grid))
    End Sub

    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.dtpEffectDate.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtChartNo.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtPatientDisabilityNo.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtPatientDisabilityMemo.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 清除欄位資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsValue()
        Try
            Me.dtpEffectDate.Clear()
            Me.txtPatientDisabilityMemo.Text = ""
            Me.txtPatientName.Text = ""
            Me.txtChartNo.Text = ""
            Me.txtPatientDisabilityNo.Text = ""
            Me.cmbDisabilityDegreeId.SelectedValue = ""
            Me.cmbDisabilityTypeId.SelectedValue = ""
            Me.dtpEndDate.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 同步更新DataGridView中的值
    ''' </summary>
    ''' <param name="mode">BUTTON類型</param>
    ''' <param name="ds">更新數據集</param>
    ''' <remarks></remarks>
    Private Sub updateDataGridView(ByVal mode As Integer, ByVal ds As DataSet)
        Select Case mode
            Case buttonAction.INSERT
                'CType(dgvShowData.DataSource, System.Data.DataTable).Rows.Add(ds.Tables(tableDB).Rows(0).ItemArray)
                CType(dgvShowData.GetGridDS, System.Data.DataSet).Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
            Case buttonAction.UPDATE
                dgvShowData.CurrentRow.SetValues(ds.Tables(tableDB).Rows(0).ItemArray)
        End Select
    End Sub

    ''' <summary>
    ''' 改變按鈕的狀態
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub changedButton()
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    ''' <summary>
    ''' 新增病患殘障記錄資料
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 成功</remarks>
    Public Function insertData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.INSERT
        Dim blnReturnFlag As Boolean = False
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            Dim iCount As Integer = 0
            Dim dsDB As DataSet = genDS(DataSet_Type.DB)
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
            Dim drGrid As DataRow = dsGrid.Tables(tableDB).NewRow()
            Dim drDB As DataRow = dsDB.Tables(tableDB).NewRow()


            '將輸入區資料塞入DB1中
            drDB("Chart_No") = Me.txtChartNo.Text.ToString.Trim
            drDB("Patient_Disability_No") = CInt(Me.txtPatientDisabilityNo.Text.Trim)
            drDB("Effect_Date") = Me.dtpEffectDate.GetUsDateStr
            If Me.dtpEndDate.IsEmpty Or Me.dtpEndDate.GetUsDateStr > MAXDATE Then
                drDB("End_Date") = MAXDATE
            Else
                drDB("End_Date") = Me.dtpEndDate.GetUsDateStr
            End If
            drDB("Patient_Disability_Memo") = Me.txtPatientDisabilityMemo.Text.ToString.Trim
            drDB("Disability_Type_Id") = Me.cmbDisabilityTypeId.SelectedValue.ToString.Trim
            drDB("Disability_Degree_Id") = Me.cmbDisabilityDegreeId.SelectedValue.ToString.Trim
            drDB("Create_User") = currentUserID
            drDB("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = drDB("Create_Time")


            dsDB.Tables(tableDB).Rows.Add(drDB)

            '確定儲存病患殘障記錄資料
            iCount = objPub.insertPUBPtDisability_L(dsDB)

            If iCount > 0 Then
                blnReturnFlag = True

                drGrid("病歷號") = dsDB.Tables(tableDB).Rows(0)("Chart_No").ToString.Trim()
                drGrid("姓名") = Me.txtPatientName.Text.ToString.Trim()
                drGrid("生效日") = dsDB.Tables(tableDB).Rows(0)("Effect_Date").ToString.Trim()
                drGrid("結束日") = dsDB.Tables(tableDB).Rows(0)("End_Date").ToString.Trim()
                drGrid("備註") = dsDB.Tables(tableDB).Rows(0)("Patient_Disability_Memo").ToString.Trim()
                drGrid("殘障類別") = dsDB.Tables(tableDB).Rows(0)("Disability_Type_Id").ToString.Trim() + "-" + Me.cmbDisabilityTypeId.SelectedItem(1).ToString.Trim()
                drGrid("殘障程度") = dsDB.Tables(tableDB).Rows(0)("Disability_Degree_Id").ToString.Trim() + "-" + Me.cmbDisabilityDegreeId.SelectedItem(1).ToString.Trim()
                drGrid("殘障類別DB") = dsDB.Tables(tableDB).Rows(0)("Disability_Type_Id").ToString.Trim()
                drGrid("殘障程度DB") = dsDB.Tables(tableDB).Rows(0)("Disability_Degree_Id").ToString.Trim()
                drGrid("序號") = dsDB.Tables(tableDB).Rows(0)("Patient_Disability_No").ToString.Trim()
                drGrid("建立者") = dsDB.Tables(tableDB).Rows(0)("Create_User").ToString.Trim()
                drGrid("建立時間") = DateUtil.TransDateToROC(dsDB.Tables(tableDB).Rows(0)("Create_Time"))
                drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                drGrid("修改時間") = DateUtil.TransDateToROC(dsDB.Tables(tableDB).Rows(0)("Modified_Time"))


                dsGrid.Tables(0).Rows.Add(drGrid)

                '新增后選中新增的行
                Dim dtGrid As DataTable = dgvShowData.GetGridDS.Tables(0).Copy
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("病歷號"), dtGrid.Columns("序號")}
                If dtGrid.Rows.Contains(New Object() {Me.txtChartNo.Text.Trim, Me.txtPatientDisabilityNo.Text.Trim}) Then
                    dtGrid.AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.txtChartNo.Text.Trim, Me.txtPatientDisabilityNo.Text.Trim})
                    dgvShowData.Rows.RemoveAt(dtGrid.Rows.IndexOf(drGrid2))
                End If
                '同步更新
                updateDataGridView(iButtonFlag, dsGrid)
                '給全局變量賦值
                pDataRowView = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).DataBoundItem
            Else
                blnReturnFlag = False
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 修改病患殘障記錄資料
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 成功</remarks>
    Public Function updateData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.UPDATE
        Dim blnReturnFlag As Boolean = False
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            Dim iCount As Integer = 0
            Dim dsDB As DataSet = genDS(DataSet_Type.DB)
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
            Dim drGrid As DataRow = dsGrid.Tables(tableDB).NewRow()
            Dim drDB As DataRow = dsDB.Tables(tableDB).NewRow()


            '將輸入區資料塞入DB1中
            drDB("Chart_No") = Me.txtChartNo.Text.ToString.Trim
            drDB("Patient_Disability_No") = CInt(Me.txtPatientDisabilityNo.Text.Trim)
            drDB("Effect_Date") = Me.dtpEffectDate.GetUsDateStr
            If Me.dtpEndDate.IsEmpty Or Me.dtpEndDate.GetUsDateStr > MAXDATE Then
                drDB("End_Date") = MAXDATE
            Else
                drDB("End_Date") = Me.dtpEndDate.GetUsDateStr
            End If
            drDB("Patient_Disability_Memo") = Me.txtPatientDisabilityMemo.Text.ToString.Trim
            drDB("Disability_Type_Id") = Me.cmbDisabilityTypeId.SelectedValue.ToString.Trim
            drDB("Disability_Degree_Id") = Me.cmbDisabilityDegreeId.SelectedValue.ToString.Trim
            drDB("Create_User") = Nothing
            drDB("Create_Time") = Nothing
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")


            dsDB.Tables(tableDB).Rows.Add(drDB)

            '確定儲存病患殘障記錄資料
            iCount = objPub.updatePUBPtDisabilityByPK_L(dsDB)

            If iCount > 0 Then
                blnReturnFlag = True

                Dim dtGrid As DataTable = dgvShowData.GetGridDS.Tables(0).Copy
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("病歷號"), dtGrid.Columns("序號")}
                If dtGrid.Rows.Contains(New Object() {Me.txtChartNo.Text.Trim, CInt(Me.txtPatientDisabilityNo.Text.Trim)}) Then
                    dtGrid.AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.txtChartNo.Text.Trim, CInt(Me.txtPatientDisabilityNo.Text.Trim)})
                    dgvShowData.CurrentCell = dgvShowData.Rows(dtGrid.Rows.IndexOf(drGrid2)).Cells(0)

                    drGrid("病歷號") = dsDB.Tables(tableDB).Rows(0)("Chart_No").ToString.Trim()
                    drGrid("姓名") = Me.txtPatientName.Text.ToString.Trim()
                    drGrid("生效日") = DateUtil.TransDateToROC(dsDB.Tables(tableDB).Rows(0)("Effect_Date").ToString.Trim())
                    drGrid("結束日") = DateUtil.TransDateToROC(dsDB.Tables(tableDB).Rows(0)("End_Date").ToString.Trim())
                    drGrid("備註") = dsDB.Tables(tableDB).Rows(0)("Patient_Disability_Memo").ToString.Trim()
                    drGrid("殘障類別") = dsDB.Tables(tableDB).Rows(0)("Disability_Type_Id").ToString.Trim() + "-" + Me.cmbDisabilityTypeId.SelectedItem(1).ToString.Trim()
                    drGrid("殘障程度") = dsDB.Tables(tableDB).Rows(0)("Disability_Degree_Id").ToString.Trim() + "-" + Me.cmbDisabilityDegreeId.SelectedItem(1).ToString.Trim()
                    drGrid("殘障類別DB") = dsDB.Tables(tableDB).Rows(0)("Disability_Type_Id").ToString.Trim()
                    drGrid("殘障程度DB") = dsDB.Tables(tableDB).Rows(0)("Disability_Degree_Id").ToString.Trim()
                    drGrid("序號") = dsDB.Tables(tableDB).Rows(0)("Patient_Disability_No").ToString.Trim()
                    drGrid("建立者") = drGrid2("建立者")
                    drGrid("建立時間") = drGrid2("建立時間")
                    drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                    drGrid("修改時間") = DateUtil.TransDateToROC(Now.ToString("yyyy/MM/dd")) & " " & Now.ToString("HH:mm:ss")

                    dsGrid.Tables(tableDB).Rows.Add(drGrid)
                    '同步更新
                    updateDataGridView(iButtonFlag, dsGrid)
                End If

                '同步更新
                updateDataGridView(iButtonFlag, dsGrid)

                '給全局變量賦值
                pDataRowView = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).DataBoundItem
            Else
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showWarnMsg("CMMCMMB010", New String() {})
                blnReturnFlag = False
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 刪除病患殘障記錄資料
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 成功</remarks>
    Public Function deleteData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.DELETE
        Dim blnReturnFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            Dim iCount As Integer = 0

            '執行刪除
            iCount = objPub.deletePUBPtDisabilityByPK_L(Me.txtChartNo.Text.ToString.Trim, CInt(Me.txtPatientDisabilityNo.Text.Trim))

            If iCount > 0 Then
                Dim dtGrid As DataTable = dgvShowData.GetGridDS.Tables(0).Copy
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("病歷號"), dtGrid.Columns("序號")}
                Dim objPrimaryKey = New Object() {dtGrid.Rows(0)("病歷號").ToString.Trim, _
                                                 dtGrid.Rows(0)("序號").ToString.Trim}
                If dtGrid.Rows.Contains(objPrimaryKey) Then
                    dtGrid.AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(objPrimaryKey)
                    dgvShowData.CurrentCell = dgvShowData.Rows(dtGrid.Rows.IndexOf(drGrid2)).Cells(0)
                End If

                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("病歷號"), dtGrid.Columns("序號")}
                If dtGrid.Rows.Contains(New Object() {Me.txtChartNo.Text.Trim, CInt(Me.txtPatientDisabilityNo.Text.Trim)}) Then
                    dtGrid.AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.txtChartNo.Text.Trim, CInt(Me.txtPatientDisabilityNo.Text.Trim)})
                    dgvShowData.Rows.RemoveAt(dtGrid.Rows.IndexOf(drGrid2))
                End If

                '給全局變量賦值
                If dgvShowData.Rows.Count > 0 Then
                    pDataRowView = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).DataBoundItem
                End If
            Else
                'MessageHandling.showWarnByKey("CMMCMMB011")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showWarnMsg("CMMCMMB011", New String() {})
                blnReturnFlag = False
            End If

            '清除欄位背景色
            cleanFieldsColor()
            '清除欄位資料
            cleanFieldsValue()
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢病患殘障記錄資料
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 查詢成功</remarks>
    Public Function queryData() As Boolean
        Dim blnReturnFlag As Boolean = True
        Dim dsDB As DataSet
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)

        Try

            '執行查詢
            dsDB = objPub.queryPUBPtDisabilityByCond_L(Me.txtChartNo.Text.ToString.Trim, Me.txtPatientDisabilityNo.Text.Trim)
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                    '清除GRID資料
                    dgvShowData.ClearDS()
                    dgvShowData.Refresh()

                    blnReturnFlag = False
                Else
                    Dim drGrid(dsDB.Tables(tableDB).Rows.Count - 1) As DataRow
                    For i As Integer = 0 To dsDB.Tables(tableDB).Rows.Count - 1
                        ' 病歷號、姓名、生效日、結束日、備註、殘障類別、殘障程度
                        drGrid(i) = dsGrid.Tables(tableDB).NewRow()
                        drGrid(i)("病歷號") = dsDB.Tables(tableDB).Rows(i)("Chart_No").ToString.Trim()
                        drGrid(i)("姓名") = dsDB.Tables(tableDB).Rows(i)("Patient_Name").ToString.Trim()
                        drGrid(i)("生效日") = dsDB.Tables(tableDB).Rows(i)("Effect_Date").ToString.Trim()
                        drGrid(i)("結束日") = dsDB.Tables(tableDB).Rows(i)("End_Date").ToString.Trim()
                        drGrid(i)("備註") = dsDB.Tables(tableDB).Rows(i)("Patient_Disability_Memo").ToString.Trim()
                        drGrid(i)("殘障類別") = dsDB.Tables(tableDB).Rows(i)("Disability_Type_Id").ToString.Trim() + "-" + dsDB.Tables(tableDB).Rows(i)("Disability_Type_Name").ToString.Trim()
                        drGrid(i)("殘障程度") = dsDB.Tables(tableDB).Rows(i)("Disability_Degree_Id").ToString.Trim() + "-" + dsDB.Tables(tableDB).Rows(i)("Disability_Degree_Name").ToString.Trim()
                        drGrid(i)("殘障類別DB") = dsDB.Tables(tableDB).Rows(i)("Disability_Type_Id").ToString.Trim()
                        drGrid(i)("殘障程度DB") = dsDB.Tables(tableDB).Rows(i)("Disability_Degree_Id").ToString.Trim()
                        drGrid(i)("序號") = dsDB.Tables(tableDB).Rows(i)("Patient_Disability_No").ToString.Trim()
                        drGrid(i)("建立者") = dsDB.Tables(tableDB).Rows(i)("Create_User").ToString.Trim()
                        If dsDB.Tables(tableDB).Rows(i)("Create_Time").ToString <> "" Then
                            drGrid(i)("建立時間") = dsDB.Tables(tableDB).Rows(i)("Create_Time")
                        End If
                        drGrid(i)("修改者") = dsDB.Tables(tableDB).Rows(i)("Modified_User").ToString.Trim()
                        If dsDB.Tables(tableDB).Rows(i)("Modified_Time").ToString <> "" Then
                            drGrid(i)("修改時間") = dsDB.Tables(tableDB).Rows(i)("Modified_Time")
                        End If

                        dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
                    Next
                    '資料邦定到Grid()
                    dgvShowData.SetDS(dsGrid.Copy)

                    setDgvColWidth()
                End If
                Return blnReturnFlag
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "         檢核"

    ''' <summary>
    ''' 欄位檢查
    ''' </summary>
    ''' <param name="iButtonFlag">BUTTON標記</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 失敗;False 成功</remarks>
    Private Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean
        Try
            Dim blnReturnFlag As Boolean = False
            Dim strErrMsg1 As StringBuilder = New StringBuilder
            Dim strErrMsg2 As StringBuilder = New StringBuilder
            Dim strErrMsg3 As StringBuilder = New StringBuilder
            Dim strErrMsg4 As StringBuilder = New StringBuilder
            '設定需要檢查的欄位
            Dim ctlDtpEffectDate As Control = Me.dtpEffectDate
            Dim ctlTxtChartNo As Control = Me.txtChartNo
            Dim ctlTxtPatientDisabilityNo As Control = Me.txtPatientDisabilityNo
            Dim ctlDtpEndDate As Control = Me.dtpEndDate
            Dim ctlObjFocus As Control = ctlDtpEffectDate
            '清除欄位背景色
            cleanFieldsColor()
            '針對確定按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not fieldCheckNull(ctlDtpEffectDate, Control_Type.DateTimePicker) Then
                        strErrMsg1.Append("生效日")
                        ctlObjFocus = ctlDtpEffectDate
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtChartNo, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("病歷號")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtChartNo
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtPatientDisabilityNo, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("序號")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtChartNo
                        End If
                        blnReturnFlag = True
                    End If
                    If Not Me.dtpEndDate.IsEmpty Then
                        If Me.dtpEffectDate.GetUsDateStr > Me.dtpEndDate.GetUsDateStr Then
                            strErrMsg2.Append("結束日" & "," & "生效日")
                            Me.dtpEndDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            If blnReturnFlag = False Then
                                ctlObjFocus = Me.dtpEndDate
                            End If
                            blnReturnFlag = True
                        End If
                    End If
                Case buttonAction.DELETE
                    If Not fieldCheckNull(ctlTxtChartNo, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("病歷號")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtChartNo
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtPatientDisabilityNo, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("序號")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtChartNo
                        End If
                        blnReturnFlag = True
                    End If
            End Select

            '欄位check錯誤
            If blnReturnFlag Then
                Dim strMsgs(0) As String
                Dim i As Integer = 0
                If strErrMsg1.Length > 0 Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB101", New String() {strErrMsg1.ToString})
                    i += 1
                End If
                If (strErrMsg2.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB102", New String() {"結束日", "生效日"})
                    i += 1
                End If
                'MessageHandling.showErrors(strMsgs)
                '********************2010/2/9 Modify By Alan**********************
                Dim pvtErrorMsg As String = ""
                For i = 0 To strMsgs.Length - 1
                    If i <> 0 Then
                        pvtErrorMsg = pvtErrorMsg & vbCrLf & strMsgs(i)
                    Else
                        pvtErrorMsg = strMsgs(i)
                    End If
                Next
                MessageHandling.showErrorMsg("CMMCMMB300", New String() {pvtErrorMsg}, "")
                ctlObjFocus.Focus()
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 檢查是否為空白
    ''' </summary>
    ''' <param name="ctl">控件</param>
    ''' <param name="ctType">控件類型</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 合法;False 非法</remarks>
    Private Function fieldCheckNull(ByVal ctl As Control, ByVal ctType As Integer) As Boolean
        Select Case ctType
            Case Control_Type.TextBox
                If ctl.Text.Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.DateTimePicker
                Dim objCtl As Syscom.Client.UCL.UCLDateTimePickerUC = ctl
                If objCtl.GetUsDateStr.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
        End Select
    End Function

#End Region


End Class

