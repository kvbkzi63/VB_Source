'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBOrderStandingUI.vb
'*              Title:	常備醫令檔
'*        Description:	常備醫令檔維護介面
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	william
'*        Create Date:	2009/08/21
'*      Last Modifier:	Yunfei
'*   Last Modify Date:	2009/12/09
'*
'*****************************************************************************
'*/
Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports System.Text
Imports Syscom.Client.UCL
Imports Syscom.Comm.EXP

Public Class PUBOrderStandingUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

    Dim objPub As IPubServiceManager = Nothing

    '目前使用者的ID
    'Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)
    '獲取維護表名
    Dim tableDB As String = PubOrderStandingDataTableFactory.tableName
    'Grid使用的標題
    'Dim columnNameGrid() As String = {"院內科別名稱", "科別/護理站", "醫令項目代碼", "醫令項目名稱", "服務開始時間", "服務結束時間", "星期", "消耗單位", "停用", "建立者", "建立時間", "修改者", "修改時間"}
    Dim columnNameGrid() As String = {"科別/護理站", "醫令項目代碼", "服務開始時間", "服務結束時間", "星期", "消耗單位", "停用", "建立者", "建立時間", "修改者", "修改時間"}
    '獲取維護表字段名
    Dim columnNameDB() As String = PubOrderStandingDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubOrderStandingDataTableFactory.columnsLength
    '設定隱藏的欄位
    'Dim visibleColumnNo() As Integer = {1, 2, 9, 10, 11, 12} '從0開始()
    Dim visibleColumnNo() As Integer = {7, 8, 9, 10} '從0開始()
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        UCLDateTimePicker
        DateTimePicker
        UCLTextCodeQuery
        UCLTextBox
        TextBox
        UCLComboBox
    End Enum




    ''' <summary>
    ''' 初始化畫面 構建空的Grid 設定欄位長度
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance

            '構建空的Grid
            'dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(tableDB)
            showResult(dgvShowData, genDataSet("dgvShowData"))
            '設定Grid滿屏
            'dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            '將DataGridView的欄位隱藏()
            For i As Integer = 0 To visibleColumnNo.Count - 1
                dgvShowData.Columns(visibleColumnNo(i)).Visible = False
            Next
            '設定欄位長度
            Me.txtConsumptionDept.MaxLength = columnsLength(5)

            ' 初始化科別/護理站
            Me.initialCboDept()
            '初始化星期
            Me.initialcmbWeekday()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化科別/護理站
    ''' </summary>
    ''' <remarks>by Michelle on 2016-11-16</remarks>
    Private Sub initialCboDept()

        Try

            '取得 Combobox的 資料
            Dim cboDS As DataSet = objPub.queryPUBOrderStandingByDept()

            cboDeptCode.DataSource = cboDS.Tables(0)
            cboDeptCode.uclValueIndex = "0"
            cboDeptCode.uclDisplayIndex = "0,1"

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化科別/護理站"})
        End Try

    End Sub

    ''' <summary>
    ''' 初始化星期
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialcmbWeekday()
        Try
            Me.cmbWeek.DataSource = GetWeekdayTable()
            Me.cmbWeek.uclValueIndex = "0"
            Me.cmbWeek.uclDisplayIndex = "1"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Function GetWeekdayTable() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("weekno", System.Type.GetType("System.String"))
        dt.Columns.Add("weekname", System.Type.GetType("System.String"))

        Dim dr As DataRow = dt.NewRow()
        dr("weekno") = "0"
        dr("weekname") = "不分"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("weekno") = "1"
        dr("weekname") = "星期一"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("weekno") = "2"
        dr("weekname") = "星期二"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("weekno") = "3"
        dr("weekname") = "星期三"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("weekno") = "4"
        dr("weekname") = "星期四"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("weekno") = "5"
        dr("weekname") = "星期五"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("weekno") = "6"
        dr("weekname") = "星期六"
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr("weekno") = "7"
        dr("weekname") = "星期日"
        dt.Rows.Add(dr)
        dt.AcceptChanges()
        Return dt
    End Function


    Private Function GetWeekdayNoOrName(ByVal strtem As String, ByVal strnoorname As String) As String
        Dim strTemp As String = ""
        Dim dt As DataTable = GetWeekdayTable()
        Dim drarr As DataRow()
        If strnoorname = "1" Then
            drarr = dt.Select("weekno='" + strtem + "'")
            For Each dr As DataRow In drarr
                strTemp = dr("weekname")
            Next
        End If
        If strnoorname = "2" Then
            drarr = dt.Select("weekname='" + strtem + "'")
            For Each dr As DataRow In drarr
                strTemp = dr("weekno")
            Next
        End If
        Return strTemp
    End Function



    ''' <summary>
    ''' 查詢事件
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 查詢成功</remarks>
    Public Overrides Function queryData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.QUERY
        Dim blnReturnFlag As Boolean = True
        Dim dsDB As DataSet
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        Dim strDeptCode As String = Me.cboDeptCode.SelectedValue.ToString.Replace("'", "''")
        Dim strOrderCode As String = Me.txtOrderCode.uclCodeValue1.ToString.Replace("'", "''")

        '執行查詢
        dsDB = objPub.queryPUBOrderStandingByCond(strDeptCode, strOrderCode)

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {})
                Else
                    Dim drGrid(dsDB.Tables(tableDB).Rows.Count - 1) As DataRow
                    '將查出的資料塞入Grid中
                    For i As Integer = 0 To dsDB.Tables(tableDB).Rows.Count - 1
                        drGrid(i) = dsGrid.Tables(tableDB).NewRow()
                        drGrid(i)("科別/護理站") = dsDB.Tables(tableDB).Rows(i)("Dept_Code").ToString.Trim()
                        'drGrid(i)("院內科別名稱") = dsDB.Tables(tableDB).Rows(i)("Dept_Code_Name").ToString.Trim()
                        drGrid(i)("醫令項目代碼") = dsDB.Tables(tableDB).Rows(i)("Order_Code").ToString.Trim()
                        'drGrid(i)("醫令項目名稱") = dsDB.Tables(tableDB).Rows(i)("Order_Code_Name").ToString.Trim()
                        drGrid(i)("服務開始時間") = dsDB.Tables(tableDB).Rows(i)("Service_Start_Time").ToString()
                        drGrid(i)("服務結束時間") = dsDB.Tables(tableDB).Rows(i)("Service_End_Time").ToString()
                        drGrid(i)("星期") = GetWeekdayNoOrName(dsDB.Tables(tableDB).Rows(i)("Week").ToString.Trim(), "1")
                        drGrid(i)("消耗單位") = dsDB.Tables(tableDB).Rows(i)("Consumption_Unit").ToString.Trim()
                        If dsDB.Tables(tableDB).Rows(i)("DC").ToString() = "N" Then
                            drGrid(i)("停用") = "否"
                        Else
                            drGrid(i)("停用") = "是"
                        End If
                        drGrid(i)("建立者") = dsDB.Tables(tableDB).Rows(i)("Create_User").ToString.Trim()
                        drGrid(i)("建立時間") = CDate(dsDB.Tables(tableDB).Rows(i)("Create_Time")).ToString("yyyy/MM/dd HH:mm:ss")
                        drGrid(i)("修改者") = dsDB.Tables(tableDB).Rows(i)("Modified_User").ToString.Trim()
                        If dsDB.Tables(tableDB).Rows(i)("Modified_Time").ToString <> "" Then
                            drGrid(i)("修改時間") = CDate(dsDB.Tables(tableDB).Rows(i)("Modified_Time")).ToString("yyyy/MM/dd HH:mm:ss")
                        End If
                        dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
                    Next
                    '資料邦定到Grid
                    'dgvShowData.DataSource = dsGrid.Tables(tableDB)
                    showResult(dgvShowData, dsGrid)
                End If
                Return blnReturnFlag
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 新增事件
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 新增成功</remarks>
    Public Overrides Function insertData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.INSERT
        Dim blnReturnFlag As Boolean = True

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

            '將輸入區資料塞入DB中
            drDB("Dept_Code") = Me.cboDeptCode.SelectedValue
            drDB("Order_Code") = Me.txtOrderCode.uclCodeValue1
            Dim strDeptName As String = Me.cboDeptCode.Text.ToString.Trim
            Dim strOrderName As String = Me.txtOrderCode.Text.ToString.Trim
            drDB("Service_Start_Time") = Me.txtServiceStartTime.Text
            drDB("Service_End_Time") = Me.txtServiceEndTime.Text
            drDB("Week") = Me.cmbWeek.SelectedValue
            drDB("Consumption_Unit") = Me.txtConsumptionDept.Text.Trim
            If Me.ckbDC.Checked = True Then
                drDB("DC") = "Y"
            Else
                drDB("DC") = "N"
            End If
            If CurrentUserID.Trim() = "" Then
                CurrentUserID = "pubuser"
            End If
            drDB("Create_User") = CurrentUserID
            drDB("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            drDB("Modified_User") = CurrentUserID
            drDB("Modified_Time") = drDB("Create_Time")
            dsDB.Tables(tableDB).Rows.Add(drDB)

            '執行新增
            iCount = objPub.insertPUBOrderStanding(dsDB)

            If iCount > 0 Then
                '將DB資料塞入Grid中
                drGrid("科別/護理站") = dsDB.Tables(tableDB).Rows(0)("Dept_Code").ToString.Trim()
                'drGrid("院內科別名稱") = strDeptName
                drGrid("醫令項目代碼") = dsDB.Tables(tableDB).Rows(0)("Order_Code").ToString.Trim()
                'drGrid("醫令項目名稱") = strOrderName
                drGrid("服務開始時間") = dsDB.Tables(tableDB).Rows(0)("Service_Start_Time").ToString()
                drGrid("服務結束時間") = dsDB.Tables(tableDB).Rows(0)("Service_End_Time").ToString()
                drGrid("星期") = GetWeekdayNoOrName(dsDB.Tables(tableDB).Rows(0)("Week").ToString.Trim(), "1")
                drGrid("消耗單位") = dsDB.Tables(tableDB).Rows(0)("Consumption_Unit").ToString.Trim()
                If dsDB.Tables(tableDB).Rows(0)("DC").ToString() = "N" Then
                    drGrid("停用") = "否"
                Else
                    drGrid("停用") = "是"
                End If
                drGrid("建立者") = dsDB.Tables(tableDB).Rows(0)("Create_User").ToString.Trim()
                drGrid("建立時間") = dsDB.Tables(tableDB).Rows(0)("Create_Time")
                drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                drGrid("修改時間") = dsDB.Tables(tableDB).Rows(0)("Modified_Time")
                dsGrid.Tables(tableDB).Rows.Add(drGrid)
                '同步更新
                updateDataGridView(iButtonFlag, dsGrid)
            Else
                blnReturnFlag = False
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 修改事件
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 修改成功</remarks>
    Public Overrides Function updateData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.UPDATE
        Dim blnReturnFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            Dim iCount As Integer = 0
            Dim dsDB As DataSet = genDS(DataSet_Type.DB)
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
            Dim drDB As DataRow = dsDB.Tables(tableDB).NewRow()
            Dim drGrid As DataRow = dsGrid.Tables(tableDB).NewRow()

            '將輸入區資料塞入DB中
            drDB("Dept_Code") = Me.cboDeptCode.SelectedValue
            drDB("Order_Code") = Me.txtOrderCode.uclCodeValue1
            Dim strDeptName As String = Me.cboDeptCode.Text.ToString.Trim
            Dim strOrderName As String = Me.txtOrderCode.Text.ToString.Trim
            drDB("Service_Start_Time") = Me.txtServiceStartTime.Text
            drDB("Service_End_Time") = Me.txtServiceEndTime.Text
            drDB("Week") = Me.cmbWeek.SelectedValue
            drDB("Consumption_Unit") = Me.txtConsumptionDept.Text.Trim
            If Me.ckbDC.Checked = True Then
                drDB("DC") = "Y"
            Else
                drDB("DC") = "N"
            End If
            If CurrentUserID.Trim() = "" Then
                CurrentUserID = "pubuser"
            End If
            drDB("Create_User") = Nothing
            drDB("Create_Time") = Nothing
            drDB("Modified_User") = CurrentUserID
            drDB("Modified_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            dsDB.Tables(tableDB).Rows.Add(drDB)

            '執行修改
            iCount = objPub.updatePUBOrderStanding(dsDB)

            If iCount > 0 Then
                '將DB資料塞入Grid中
                'Dim dtGrid As DataTable = dgvShowData.DataSource
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0)
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("科別/護理站"), dtGrid.Columns("醫令項目代碼"), dtGrid.Columns("服務開始時間"), dtGrid.Columns("服務結束時間"), dtGrid.Columns("星期"), dtGrid.Columns("消耗單位")}
                If dtGrid.Rows.Contains(New Object() {Me.cboDeptCode.SelectedValue, Me.txtOrderCode.uclCodeValue1, Me.txtServiceStartTime.Text, Me.txtServiceEndTime.Text, _
                                                      GetWeekdayNoOrName(Me.cmbWeek.SelectedValue, "1"), Me.txtConsumptionDept.Text.Trim}) Then
                    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.cboDeptCode.SelectedValue, Me.txtOrderCode.uclCodeValue1, Me.txtServiceStartTime.Text, Me.txtServiceEndTime.Text, _
                                                      GetWeekdayNoOrName(Me.cmbWeek.SelectedValue, "1"), Me.txtConsumptionDept.Text.Trim})
                    'dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    drGrid("科別/護理站") = dsDB.Tables(tableDB).Rows(0)("Dept_Code").ToString.Trim()
                    'drGrid("院內科別名稱") = strDeptName
                    drGrid("醫令項目代碼") = dsDB.Tables(tableDB).Rows(0)("Order_Code").ToString.Trim()
                    'drGrid("醫令項目名稱") = strOrderName
                    drGrid("服務開始時間") = dsDB.Tables(tableDB).Rows(0)("Service_Start_Time").ToString()
                    drGrid("服務結束時間") = dsDB.Tables(tableDB).Rows(0)("Service_End_Time").ToString()
                    drGrid("星期") = GetWeekdayNoOrName(dsDB.Tables(tableDB).Rows(0)("Week").ToString.Trim(), "1")
                    drGrid("消耗單位") = dsDB.Tables(tableDB).Rows(0)("Consumption_Unit").ToString.Trim()
                    If dsDB.Tables(tableDB).Rows(0)("DC").ToString() = "N" Then
                        drGrid("停用") = "否"
                    Else
                        drGrid("停用") = "是"
                    End If
                    drGrid("建立者") = drGrid2("建立者")
                    drGrid("建立時間") = drGrid2("建立時間")
                    drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                    drGrid("修改時間") = dsDB.Tables(tableDB).Rows(0)("Modified_Time")
                    dsGrid.Tables(tableDB).Rows.Add(drGrid)
                    '同步更新
                    updateDataGridView(iButtonFlag, dsGrid)
                End If
            Else
                'MessageHandling.showWarnByKey("CMMCMMB010")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowWarnMsg("CMMCMMB010", New String() {})
                blnReturnFlag = False
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    ''' <summary>
    ''' 刪除事件
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 刪除成功</remarks>
    Public Overrides Function deleteData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.DELETE
        Dim blnReturnFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            Dim iCount As Integer = 0
            Dim strDeptCode As String = Me.cboDeptCode.SelectedValue
            Dim strOrderCode As String = Me.txtOrderCode.uclCodeValue1
            Dim strService_Start_Time As String = Me.txtServiceStartTime.Text
            Dim strService_End_Time As String = Me.txtServiceEndTime.Text
            Dim strWeek As String = Me.cmbWeek.SelectedValue
            Dim strConsumption_Dept As String = Me.txtConsumptionDept.Text.Trim
            '執行刪除
            iCount = objPub.deletePUBOrderStandingByPK(strDeptCode, strOrderCode, strService_Start_Time, strService_End_Time, strWeek, strConsumption_Dept)

            If iCount > 0 Then
                'Dim dtGrid As DataTable = dgvShowData.DataSource
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0)
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("科別/護理站"), dtGrid.Columns("醫令項目代碼"), dtGrid.Columns("服務開始時間"), dtGrid.Columns("服務結束時間"), dtGrid.Columns("星期"), dtGrid.Columns("消耗單位")}
                If dtGrid.Rows.Contains(New Object() {Me.cboDeptCode.SelectedValue, Me.txtOrderCode.uclCodeValue1, Me.txtServiceStartTime.Text, Me.txtServiceEndTime.Text, _
                                                      GetWeekdayNoOrName(Me.cmbWeek.SelectedValue, "1"), Me.txtConsumptionDept.Text.Trim}) Then
                    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.cboDeptCode.SelectedValue, Me.txtOrderCode.uclCodeValue1, Me.txtServiceStartTime.Text, Me.txtServiceEndTime.Text, _
                                                      GetWeekdayNoOrName(Me.cmbWeek.SelectedValue, "1"), Me.txtConsumptionDept.Text.Trim})
                    'dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)

                End If
            Else
                'MessageHandling.showWarnByKey("CMMCMMB011")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowWarnMsg("CMMCMMB011", New String() {})
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
                '{"院內科別名稱", "科別/護理站", "醫令項目代碼", "醫令項目名稱", "服務開始時間", "服務結束時間", "星期", "消耗單位", "停用", "建立者", "建立時間", "修改者", "修改時間"}

                'Return New String(,) {{"科別/護理站", "科別/護理站", "Y", "N", ""}, _
                '                      {"院內科別名稱", "院內科別名稱", "Y", "N", ""}, _
                '                      {"醫令項目代碼", "醫令項目代碼", "Y", "N", ""}, _
                '                      {"醫令項目名稱", "醫令項目名稱", "Y", "N", ""}, _
                '                      {"服務開始時間", "服務開始時間", "Y", "N", ""}, _
                '                      {"服務結束時間", "服務結束時間", "Y", "N", ""}, _
                '                      {"星期", "星期", "Y", "N", ""}, _
                '                      {"消耗單位", "消耗單位", "Y", "N", ""}, _
                '                      {"停用", "停用", "Y", "N", ""}, _
                '                      {"建立者", "建立者", "Y", "N", ""}, _
                '                      {"建立時間", "建立時間", "Y", "N", ""}, _
                '                      {"修改者", "修改者", "Y", "N", ""}, _
                '                      {"修改時間", "修改時間", "Y", "N", ""}}

                Return New String(,) {{"科別/護理站", "科別/護理站", "Y", "N", ""}, _
                                      {"醫令項目代碼", "醫令項目代碼", "Y", "N", ""}, _
                                      {"服務開始時間", "服務開始時間", "Y", "N", ""}, _
                                      {"服務結束時間", "服務結束時間", "Y", "N", ""}, _
                                      {"星期", "星期", "Y", "N", ""}, _
                                      {"消耗單位", "消耗單位", "Y", "N", ""}, _
                                      {"停用", "停用", "Y", "N", ""}, _
                                      {"建立者", "建立者", "N", "N", ""}, _
                                      {"建立時間", "建立時間", "N", "N", ""}, _
                                      {"修改者", "修改者", "N", "N", ""}, _
                                      {"修改時間", "修改時間", "N", "N", ""}}

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
            dgv.uclHeaderText = headerTxtStr
            dgv.uclNonVisibleColIndex = Visible
            dgv.Initial(hashTable)
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
    Function genDataSet(ByVal dgvName As String) As DataSet
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
                'dsTemp.Tables(tableDB).Columns("星期").DataType = System.Type.GetType("System.Int32")
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
            '設定需要檢查的欄位
            Dim ctlTcpDeptCode As Control = Me.cboDeptCode
            Dim ctlTxtOrderCode As Control = Me.txtOrderCode
            Dim ctlDtpService_Start_Time As Control = Me.txtServiceStartTime
            Dim ctlDtpService_End_Time As Control = Me.txtServiceEndTime
            Dim ctlCmbWeek As Control = Me.cmbWeek
            Dim ctltxtConsumption_Dept As Control = Me.txtConsumptionDept
            Dim ctlObjFocus As Control = ctlTxtOrderCode
            '清除欄位背景色
            cleanFieldsColor()
            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not fieldCheckNull(cboDeptCode, Control_Type.UCLComboBox) Then
                        If Me.cboDeptCode.SelectedValue = "" Then
                            strErrMsg1.Append("科別/護理站")
                            ctlObjFocus = cboDeptCode
                            blnReturnFlag = True
                        End If
                    End If
                    If Not fieldCheckNull(ctlTxtOrderCode, Control_Type.UCLTextCodeQuery) Then
                        If Me.txtOrderCode.uclCodeValue1 = "" Then
                            If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                            strErrMsg1.Append("醫令項目代碼")
                            ctlObjFocus = ctlTxtOrderCode
                            blnReturnFlag = True
                        End If
                    End If
                    If Not fieldCheckNull(ctlDtpService_Start_Time, Control_Type.UCLTextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("服務開始時間")
                        If blnReturnFlag = False Then
                            ctlObjFocus = txtServiceStartTime
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlDtpService_End_Time, Control_Type.UCLTextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("服務結束時間")
                        If blnReturnFlag = False Then
                            ctlObjFocus = txtServiceEndTime
                        End If
                        blnReturnFlag = True
                    End If

                    If Not fieldCheckNull(ctlCmbWeek, Control_Type.UCLComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("星期")
                        If blnReturnFlag = False Then
                            ctlObjFocus = cmbWeek
                        End If
                        blnReturnFlag = True
                    End If

                    If txtServiceStartTime.Text <> "" And txtServiceEndTime.Text <> "" Then
                        Dim strStart As DateTime = CType(Now.ToString("yyyy/MM/dd") & " " & txtServiceStartTime.Text & ":00", DateTime)
                        Dim strEnd As DateTime = CType(Now.ToString("yyyy/MM/dd") & " " & txtServiceEndTime.Text & ":00", DateTime)
                        If strStart > strEnd Then
                            strErrMsg2.Append("服務開始時間")
                            If blnReturnFlag = False Then
                                ctlObjFocus = txtServiceStartTime
                            End If
                            blnReturnFlag = True
                        End If
                        If iButtonFlag = buttonAction.INSERT And fieldCheckNull(ctlCmbWeek, Control_Type.UCLComboBox) Then
                            If objPub.queryPUBOrderStandingTimeIsExist(Me.cboDeptCode.SelectedValue, Me.txtOrderCode.uclCodeValue1, txtServiceStartTime.Text, txtServiceEndTime.Text, Me.cmbWeek.SelectedValue) = False Then
                                strErrMsg3.Append("同一科別/護理站且同一個醫令項目代碼且同一個星期幾的時間起迄不可重疊")
                                If blnReturnFlag = False Then
                                    ctlObjFocus = txtServiceEndTime
                                End If
                                blnReturnFlag = True
                            End If
                        End If
                    End If

                    If Not fieldCheckNull(ctltxtConsumption_Dept, Control_Type.UCLTextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("消耗單位")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctltxtConsumption_Dept
                        End If
                        blnReturnFlag = True
                    End If

                Case buttonAction.DELETE
                    If Not fieldCheckNull(cboDeptCode, Control_Type.UCLComboBox) Then
                        If Me.cboDeptCode.SelectedValue = "" Then
                            strErrMsg1.Append("科別/護理站")
                            ctlObjFocus = cboDeptCode
                            blnReturnFlag = True
                        End If
                    End If
                    If Not fieldCheckNull(ctlTxtOrderCode, Control_Type.UCLTextCodeQuery) Then
                        If Me.txtOrderCode.uclCodeValue1 = "" Then
                            If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                            strErrMsg1.Append("醫令項目代碼")
                            ctlObjFocus = ctlTxtOrderCode
                            blnReturnFlag = True
                        End If
                    End If
                    If Not fieldCheckNull(ctlDtpService_Start_Time, Control_Type.UCLTextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("服務開始時間")
                        If blnReturnFlag = False Then
                            ctlObjFocus = txtServiceStartTime
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlDtpService_End_Time, Control_Type.UCLTextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("服務結束時間")
                        If blnReturnFlag = False Then
                            ctlObjFocus = txtServiceEndTime
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlCmbWeek, Control_Type.UCLComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("星期")
                        If blnReturnFlag = False Then
                            ctlObjFocus = cmbWeek
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctltxtConsumption_Dept, Control_Type.UCLTextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("消耗單位")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctltxtConsumption_Dept
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
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB102", New String() {"服務結束時間", "服務開始時間"})
                    i += 1
                End If
                If (strErrMsg3.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = strErrMsg3.ToString
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
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {pvtErrorMsg}, "")
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
            Case Control_Type.UCLTextBox
                If ctl.Text.Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.UCLTextCodeQuery
                If ctl.Text.Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.UCLComboBox
                Dim objCtl As Syscom.Client.UCL.UCLComboBoxUC = ctl
                If objCtl.SelectedValue.ToString.Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
        End Select
    End Function

    ''' <summary>
    ''' 清除事件
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub clearData()
        '清除欄位資料
        cleanFieldsValue()
        '清除欄位背景顏色
        cleanFieldsColor()
        'CType(dgvShowData.DataSource, DataTable).Clear()
        dgvShowData.ClearDS()
        dgvShowData.Refresh()
    End Sub

    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.cboDeptCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtOrderCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtServiceStartTime.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtServiceEndTime.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbWeek.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtConsumptionDept.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
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
            Me.cboDeptCode.Text = ""
            Me.cboDeptCode.SelectedValue = ""
            'Me.cboDeptCode.doFlag = True
            Me.txtOrderCode.Text = ""
            Me.txtOrderCode.uclCodeValue1 = ""
            Me.txtOrderCode.doFlag = True
            Me.txtServiceStartTime.Text = ""
            Me.txtServiceEndTime.Text = ""
            Me.txtConsumptionDept.Text = ""
            Me.cmbWeek.SelectedIndex = 0
            Me.ckbDC.Checked = False
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
    Private Overloads Sub updateDataGridView(ByVal mode As Integer, ByVal ds As DataSet)
        Select Case mode
            Case buttonAction.INSERT
                'CType(dgvShowData.DataSource, System.Data.DataTable).Rows.Add(ds.Tables(tableDB).Rows(0).ItemArray)
                dgvShowData.GetGridDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
                dgvShowData.GetDBDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
            Case buttonAction.UPDATE
                dgvShowData.CurrentRow.SetValues(ds.Tables(tableDB).Rows(0).ItemArray)
        End Select
        '將DataGridView的欄位隱藏()
        For i As Integer = 0 To visibleColumnNo.Count - 1
            dgvShowData.Columns(visibleColumnNo(i)).Visible = False
        Next
    End Sub

    ''' <summary>
    ''' 選中Grid行資料並顯示在輸入區
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub dgvCellClick()
        Try
            '清除欄位背景顏色
            cleanFieldsColor()
            If dgvShowData.CurrentCellAddress.Y >= 0 Then
                Me.txtOrderCode.uclCodeValue1 = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("醫令項目代碼").Value.ToString.Trim()
                If Me.txtOrderCode.uclCodeValue1 <> "" Then
                    Me.txtOrderCode.ProcessQuery(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("醫令項目代碼").Value.ToString.Trim())
                    Me.txtOrderCode.doFlag = False
                Else
                    Me.txtOrderCode.Text = ""
                End If
                Me.txtServiceStartTime.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("服務開始時間").Value.ToString.Trim()
                Me.txtServiceEndTime.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("服務結束時間").Value.ToString.Trim()
                Me.cmbWeek.SelectedValue = GetWeekdayNoOrName(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("星期").Value.ToString.Trim, 2)
                Me.txtConsumptionDept.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("消耗單位").Value.ToString.Trim()
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停用").Value.ToString.Trim = "是" Then
                    Me.ckbDC.Checked = True
                Else
                    Me.ckbDC.Checked = False
                End If
                Dim value As String = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("科別/護理站").Value.ToString.Trim())
                Me.cboDeptCode.SelectedValue = value

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub PUBOrderStandingUI_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If UCLFormUtil.isResizeable = True Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
            UCLFormUtil.ReDrawForm(Me)
        End If
    End Sub
End Class
