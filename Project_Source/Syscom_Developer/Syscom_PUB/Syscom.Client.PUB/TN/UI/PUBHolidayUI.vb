'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBHolidayUI.vb
'*              Title:	假日檔維護
'*        Description:	假日檔維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Coco
'*        Create Date:	2009/07/31
'*      Last Modifier:	
'*   Last Modify Date:	
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
Imports log4net
Imports System.Text
Imports System.Globalization.TaiwanCalendar

Public Class PUBHolidayUI
    Inherits client.ucl.IUCLMaintainFormUI

    Dim objPub As IPubServiceManager = Nothing
    Dim cmm As ICmmServiceManager
    Dim conSubSystemCode As String = "全院"
    '目前使用者的ID
    'Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)
    '獲取維護表名
    Dim tableDB As String = PubHolidayDataTableFactory.tableName
    'Grid使用的標題
    Dim columnNameGrid() As String = {"年度", "日期", "說明", "使用單位", "假日/非假日", "午別", "建立者", "建立時間", "修改者", "修改時間", "使用單位DB"}
    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {10} '從0開始()
    '獲取維護表字段名
    Dim columnNameDB() As String = PubHolidayDataTableFactory.columnsName

    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubHolidayDataTableFactory.columnsLength
    '取得使用者權限
    Dim gblSubSystemCode As String = ""
    '目前登入的使用者權限
    Dim userPower() As String = AppContext.userProfile.userMemberOf.Replace("'", "").TrimEnd(",").Split(",")
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        TextBox
        Combobox
        DateTimePicker
    End Enum

    ''' <summary>
    ''' 產生一個空的DataSet
    ''' </summary>
    ''' <param name="type"></param>
    ''' <returns></returns>
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
    Public Overrides Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance
            cmm = CmmServiceManager.getInstance
            '構建空的Grid
            Dim a As DataTable = genDS(DataSet_Type.Grid).Tables(tableDB)

            'dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(tableDB)
            dgvShowData.Initial(genDS(DataSet_Type.Grid).Tables(tableDB).Copy)


            '將DataGridView的欄位隱藏()
            For i As Integer = 0 To visibleColumnNo.Count - 1
                dgvShowData.Columns(visibleColumnNo(i)).Visible = False
            Next

            '設定Grid滿屏
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            '設定欄位長度
            Me.txtDescription.MaxLength = columnsLength(2)

            If CheckAuthority() Then
                '初始化使用單位
                initialComboBox(74)

                '畫面初始化
                Me.rdbIsNonHoliday1.Checked = True
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {"config查無資料"})
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化職稱
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialComboBox(ByVal iTypeId As Integer)
        Dim dsDB As DataSet
        Dim tempDT As DataTable
        '執行查詢
        Dim objPub As IPubServiceManager = PubServiceManager.getInstance
        dsDB = objPub.queryPUBSysCode(iTypeId)
        tempDT = dsDB.Tables(0).Clone

        For Each row As DataRow In dsDB.Tables(0).Rows
            If gblSubSystemCode.Contains(row.Item("Code_Id")) Then
                tempDT.ImportRow(row)
            End If
        Next

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(PubSyscodeDataTableFactory.tableName).Rows.Count = 0 Then
                    '查無資料
                    MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"查無資料"})
                Else
                    '初始化使用單位
                    Me.cmbSubSystemCode.DataSource = tempDT
                    Me.cmbSubSystemCode.uclDisplayIndex = "1"
                    Me.cmbSubSystemCode.uclValueIndex = "0"
                End If
            End If


            Dim temp As New DataTable
           
            temp.Columns.Add("Noon_Code_Id")
            temp.Columns.Add("Noon_Code_Name")

            temp.Rows.Add("1", "上午")
            temp.Rows.Add("2", "下午")
         

            Me.cmbNoonCode.DataSource = temp
            Me.cmbNoonCode.uclDisplayIndex = "0,1"
            Me.cmbNoonCode.uclValueIndex = "0"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
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
        Dim strTemp As String
        Dim dateholidayDate As Date
        Dim strSubSystemCode As String
        If Me.dtpHolidayDate.GetUsDateStr().Trim <> "" Then
            dateholidayDate = CDate(Me.dtpHolidayDate.GetUsDateStr().Trim)
        Else
            dateholidayDate = System.DateTime.MinValue
        End If
        'If Me.cmbSubSystemCode.SelectedValue.Trim = "" Then
        '    strSubSystemCode = conSubSystemCode
        'Else
        strSubSystemCode = Me.cmbSubSystemCode.SelectedValue.Trim
        'End If
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        Dim tempStr As String = Me.txtHolidayYear.Text
        If tempStr <> "" Then tempStr = (CType(tempStr, Int32) + 1911).ToString
        '年度和日期不符時以年度為主
        If Not dateholidayDate.ToString.Contains(tempStr) Then
            dateholidayDate = System.DateTime.MinValue
            Me.dtpHolidayDate.Clear()
        End If
        '執行查詢
        dsDB = objPub.queryPUBHolidayByCond(tempStr.Trim.Replace("'", "''"), dateholidayDate, strSubSystemCode)
        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    clearData()
                    MessageHandling.ShowWarnMsg("CMMCMMB302", New String() {"此年度無資料，查詢"})
                Else
                    Dim drGrid(dsDB.Tables(tableDB).Rows.Count - 1) As DataRow
                    '將查出的資料塞入Grid中
                    For i As Integer = 0 To dsDB.Tables(tableDB).Rows.Count - 1
                        drGrid(i) = dsGrid.Tables(tableDB).NewRow()
                        Dim strHolidayYear As String = StringUtil.nvl(CDate(dsDB.Tables(tableDB).Rows(i)("Holiday_Date")).AddYears(-1911).ToString)
                        drGrid(i)("年度") = strHolidayYear.Substring(1, 3)
                        drGrid(i)("日期") = UsDateToTwDate(dsDB.Tables(tableDB).Rows(i)("Holiday_Date"))
                        drGrid(i)("說明") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Description"))
                        drGrid(i)("使用單位") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("SubSystem_Name"))
                        strTemp = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Is_Holiday"))
                        If strTemp = "N" Then
                            drGrid(i)("假日/非假日") = "非假日"
                        Else
                            drGrid(i)("假日/非假日") = "假日"
                        End If
                        If StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Noon_Code")).Contains("1") Then
                            drGrid(i)("午別") = "上午"
                        ElseIf StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Noon_Code")).Contains("2") Then
                            drGrid(i)("午別") = "下午"
                        End If
                        drGrid(i)("建立者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_User"))
                        If StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_Time")) <> "" Then
                            drGrid(i)("建立時間") = StringUtil.nvl(CDate(dsDB.Tables(tableDB).Rows(i)("Create_Time")).AddYears(-1911).ToString("yyy/MM/dd HH:mm:ss"))
                        End If
                        drGrid(i)("修改者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Modified_User"))
                        If Not IsDBNull(dsDB.Tables(tableDB).Rows(i)("Modified_Time")) Then
                            strTemp = StringUtil.nvl(CDate(dsDB.Tables(tableDB).Rows(i)("Modified_Time")).AddYears(-1911).ToString("yyy/MM/dd HH:mm:ss"))
                            drGrid(i)("修改時間") = strTemp
                        End If
                        dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
                        drGrid(i)("使用單位DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("SubSystem_Code"))
                    Next
                    '資料邦定到Grid
                    'dgvShowData.DataSource = dsGrid.Tables(tableDB)
                    dgvShowData.Initial(dsGrid.Copy)
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
        'Dim strtemp As String
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
            drDB("Holiday_Date") = Me.dtpHolidayDate.GetUsDateStr().Trim
            drDB("Description") = Me.txtDescription.Text.Trim
            'If Me.cmbSubSystemCode.SelectedValue.Trim <> "" Then
            drDB("SubSystem_Code") = Me.cmbSubSystemCode.SelectedValue.Trim
            'Else
            'drDB("SubSystem_Code") = conSubSystemCode.Substring(0, 1)
            'End If
            If Me.rdbIsNonHoliday2.Checked = True Then
                drDB("Is_Holiday") = "N"
                drDB("Noon_Code") = ""
            Else
                drDB("Is_Holiday") = "Y"
                drDB("Noon_Code") = cmbNoonCode.SelectedValue.ToString
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
            iCount = objPub.insertPubHoliday(dsDB)
            If iCount > 0 Then
                '將DB資料塞入Grid中
                Dim strHolidayYear As String = (CDate(dsDB.Tables(tableDB).Rows(0)("Holiday_Date")).AddYears(-1911)).ToString.Trim
                Me.txtHolidayYear.Text = strHolidayYear.Substring(1, 3)
                drGrid("年度") = strHolidayYear.Substring(1, 3)
                drGrid("日期") = UsDateToTwDate(dsDB.Tables(tableDB).Rows(0)("Holiday_Date"))
                drGrid("說明") = dsDB.Tables(tableDB).Rows(0)("Description").ToString.Trim()
                drGrid("使用單位") = Me.cmbSubSystemCode.SelectedItem(1).ToString.Trim
                If dsDB.Tables(tableDB).Rows(0)("Is_Holiday").ToString.Trim() = "Y" Then
                    drGrid("假日/非假日") = "假日"
                Else
                    drGrid("假日/非假日") = "非假日"
                End If
                If dsDB.Tables(tableDB).Rows(0)("Noon_Code").ToString.Trim().Contains("1") Then
                    drGrid("午別") = "上午"
                ElseIf dsDB.Tables(tableDB).Rows(0)("Noon_Code").ToString.Trim().Contains("2") Then
                    drGrid("午別") = "下午"
                End If
                drGrid("建立者") = dsDB.Tables(tableDB).Rows(0)("Create_User").ToString.Trim()
                drGrid("建立時間") = (CDate(dsDB.Tables(tableDB).Rows(0)("Create_Time")).AddYears(-1911)).ToString("yyy/MM/dd HH:mm:ss").Trim
                drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                drGrid("修改時間") = (CDate(dsDB.Tables(tableDB).Rows(0)("Modified_Time")).AddYears(-1911)).ToString("yyy/MM/dd HH:mm:ss").Trim
                drGrid("使用單位DB") = Me.cmbSubSystemCode.SelectedValue.Trim

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
            drDB("Holiday_Date") = Me.dtpHolidayDate.GetUsDateStr().Trim
            drDB("Description") = Me.txtDescription.Text.Trim
            'If Me.cmbSubSystemCode.SelectedValue.Trim <> "" Then
            drDB("SubSystem_Code") = Me.cmbSubSystemCode.SelectedValue.Trim
            'Else
            'drDB("SubSystem_Code") = conSubSystemCode.Substring(0, 1)
            'End If
            If Me.rdbIsNonHoliday2.Checked = True Then
                drDB("Is_Holiday") = "N"
                drDB("Noon_Code") = ""
            Else
                drDB("Is_Holiday") = "Y"
                drDB("Noon_Code") = cmbNoonCode.SelectedValue.ToString
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
            iCount = objPub.updatePubHoliday(dsDB)

            If iCount > 0 Then
                '將DB資料塞入Grid中
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0) 'dgvShowData.DataSource
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("日期"), dtGrid.Columns("使用單位DB")}
                If dtGrid.Rows.Contains(New Object() {Me.dtpHolidayDate.GetTwDateStr().Trim, Me.cmbSubSystemCode.SelectedValue.Trim}) Then
                    CType(dgvShowData.GetDBDS.Tables(0), DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.dtpHolidayDate.GetTwDateStr().Trim, Me.cmbSubSystemCode.SelectedValue.Trim})
                    'dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    ' ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    Dim strHolidayYear As String = CDate(dsDB.Tables(tableDB).Rows(0)("Holiday_Date")).AddYears(-1911).ToString.Trim
                    Me.txtHolidayYear.Text = strHolidayYear.Substring(1, 3)
                    drGrid("年度") = strHolidayYear.Substring(1, 3)
                    drGrid("日期") = UsDateToTwDate(dsDB.Tables(tableDB).Rows(0)("Holiday_Date"))
                    drGrid("說明") = dsDB.Tables(tableDB).Rows(0)("Description").ToString.Trim()
                    drGrid("使用單位") = Me.cmbSubSystemCode.SelectedItem(1).ToString.Trim
                    If dsDB.Tables(tableDB).Rows(0)("Is_Holiday").ToString.Trim() = "Y" Then
                        drGrid("假日/非假日") = "假日"
                    Else
                        drGrid("假日/非假日") = "非假日"
                    End If
                    If dsDB.Tables(tableDB).Rows(0)("Noon_Code").ToString.Trim().Contains("1") Then
                        drGrid("午別") = "上午"
                    ElseIf dsDB.Tables(tableDB).Rows(0)("Noon_Code").ToString.Trim().Contains("2") Then
                        drGrid("午別") = "下午"
                    End If
                    drGrid("建立者") = drGrid2("建立者")
                    drGrid("建立時間") = drGrid2("建立時間").ToString.Trim
                    drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                    drGrid("修改時間") = (CDate(dsDB.Tables(tableDB).Rows(0)("Modified_Time")).AddYears(-1911)).ToString("yyy/MM/dd HH:mm:ss").Trim
                    drGrid("使用單位DB") = Me.cmbSubSystemCode.SelectedValue.Trim
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

            '執行刪除
            iCount = objPub.deletePubHoliday(Me.dtpHolidayDate.GetUsDateStr().Trim, Me.cmbSubSystemCode.SelectedValue.Trim)

            If iCount > 0 Then
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0) 'dgvShowData.DataSource
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("日期"), dtGrid.Columns("使用單位DB")}
                If dtGrid.Rows.Contains(New Object() {Me.dtpHolidayDate.GetTwDateStr().Trim, Me.cmbSubSystemCode.SelectedValue.Trim}) Then
                    CType(dgvShowData.GetDBDS.Tables(0), DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.dtpHolidayDate.GetTwDateStr().Trim, Me.cmbSubSystemCode.SelectedValue.Trim})
                    'dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    ' ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
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
    ''' <summary>
    ''' 檢查是否為空白
    ''' </summary>
    ''' <param name="ctl"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function fieldCheckNull(ByVal ctl As Control, ByVal ctType As Integer) As Boolean
        Select Case ctType
            Case Control_Type.TextBox
                If ctl.Text.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else

                    Return True
                End If
            Case Control_Type.Combobox
                Dim objCtl As Syscom.Client.UCL.UCLComboBoxUC = ctl
                If objCtl.SelectedValue.Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.DateTimePicker
                Dim objCtl As Syscom.Client.UCL.UCLDateTimePickerUC = ctl
                If objCtl.GetUsDateStr().Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
        End Select

    End Function

    ''' <summary>
    ''' 假日日期欄位檢查
    ''' </summary>
    ''' <param name="msgTitle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function fieldCheckResult(ByVal msgTitle As Integer) As Boolean
        Try
            Dim isError As Boolean = False
            Dim errorMsg1 As StringBuilder = New StringBuilder

            '設定需要檢查的欄位
            Dim ctlDtpHolidayDate As Control = dtpHolidayDate
            Dim ctlCmbSubSystemCode As Control = cmbSubSystemCode

            '清除欄位背景顏色
            cleanFieldsColor()

            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case msgTitle
                Case buttonAction.INSERT, buttonAction.UPDATE, buttonAction.DELETE
                    If Not fieldCheckNull(ctlDtpHolidayDate, Control_Type.DateTimePicker) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        errorMsg1.Append("日期")
                        isError = True
                    End If
                    If Not fieldCheckNull(ctlCmbSubSystemCode, Control_Type.Combobox) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        errorMsg1.Append("使用單位")
                        isError = True
                    End If
            End Select

            If (isError) Then
                '欄位check錯誤
                Dim opt(0) As String
                Dim cnt = 0
                If (errorMsg1.Length > 0) Then
                    ReDim opt(cnt)
                    opt(cnt) = ResourceUtil.getString("CMMCMMB302", New String() {errorMsg1.ToString})
                    cnt += 1
                End If

                'MessageHandling.showErrors(opt)
                '********************2010/2/9 Modify By Alan**********************
                Dim pvtErrorMsg As String = ""
                For i = 0 To opt.Length - 1
                    If i <> 0 Then
                        pvtErrorMsg = pvtErrorMsg & vbCrLf & opt(i)
                    Else
                        pvtErrorMsg = opt(i)
                    End If
                Next
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {pvtErrorMsg}, "")
            End If
            Return isError
        Catch ex As Exception
            Throw ex
        End Try
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
            Me.dtpHolidayDate.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbSubSystemCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT

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
            Me.dtpHolidayDate.Clear()
            'Me.cmbSubSystemCode.SelectedValue = ""  使用者初始化後不得再更改
            Me.txtDescription.Text = ""
            Me.txtHolidayYear.Text = ""
            Me.rdbIsNonHoliday1.Checked = True
            Me.rdbIsNonHoliday2.Checked = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 點選行資料,塞入輸入區
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub dgvCellClick()
        Try
            '清除欄位背景顏色
            cleanFieldsColor()

            If dgvShowData.CurrentCellAddress.Y >= 0 Then
                Me.txtHolidayYear.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("年度").Value)
                Me.dtpHolidayDate.SetValue(CDate(TwDateToUsdate(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("日期").Value)))
                Me.txtDescription.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("說明").Value)
                'Me.cmbSubSystemCode.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("使用單位DB").Value)  使用者初始化後不得再更改
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("假日/非假日").Value) = "假日" Then
                    Me.rdbIsNonHoliday1.Checked = True
                ElseIf StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("假日/非假日").Value) = "非假日" Then
                    Me.rdbIsNonHoliday2.Checked = True
                End If
            End If
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
                Dim pvtInsertIndex As Integer = 0
                pvtInsertIndex = dgvShowData.GetDBDS.Tables(0).Rows.Count

                dgvShowData.InsertRowDbDsAt(ds.Tables(tableDB).Rows(0), pvtInsertIndex)
                dgvShowData.InsertRowGridDsAt(ds.Tables(tableDB).Rows(0), pvtInsertIndex)

            Case buttonAction.UPDATE
                dgvShowData.CurrentRow.SetValues(ds.Tables(tableDB).Rows(0).ItemArray)
        End Select
    End Sub

    Private Sub dtpHolidayDate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpHolidayDate.Leave
        If Me.dtpHolidayDate.GetUsDateStr().Trim.Replace("/", "") <> "" Then
            Me.txtHolidayYear.Text = Me.dtpHolidayDate.GetYear(UCL.UCLDateTimePickerUC.Locale.TW)
        End If
    End Sub
    ''' <summary>
    ''' 無權限鎖定所有按鈕跳出警告視窗
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ButtonAuthority()

        If gblSubSystemCode = "" Then
            btnInsert.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
            btnQuery.Enabled = False
            btnClear.Enabled = False
        End If
    End Sub
    ''' <summary>
    ''' 取得登入使用者的權限
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckAuthority() As Boolean
        Try
            Dim ds As DataSet = cmm.CMMSysCodeQueryPubConfigMuti({"PUB_HolidayRole_OPH", "PUB_HolidayRole_All", "PUB_HolidayRole_REG"})
            If CheckHasValue(ds) Then
                For Each str As String In userPower
                    If ds.Tables("PUB_HolidayRole_OPH").Rows(0).Item("Config_Value").Contains(str) Then gblSubSystemCode = gblSubSystemCode & "IPH"
                Next
                For Each str As String In userPower
                    If ds.Tables("PUB_HolidayRole_All").Rows(0).Item("Config_Value").Contains(str) Then gblSubSystemCode = gblSubSystemCode & "++"
                Next
                For Each str As String In userPower
                    If ds.Tables("PUB_HolidayRole_REG").Rows(0).Item("Config_Value").Contains(str) Then gblSubSystemCode = gblSubSystemCode & "REG"
                Next
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    ''' <summary>
    ''' 初始化視窗，因為鎖定按鍵的需求所以覆蓋掉底層的初始化。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Shadows Sub IUCLMaintainFormUI_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            If gblSubSystemCode = "" Then
                MessageBox.Show("非合法的使用者", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ButtonAuthority()
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub
    ''' <summary>
    ''' combox改變選項時清除GRIDVIEW欄位避免錯誤的系統權限編輯
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboboxChanged(sender As Object, e As EventArgs) Handles cmbSubSystemCode.SelectedIndexChanged
        Try
            clearData()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub
    ''' <summary>
    ''' 西元轉民國
    ''' </summary>
    ''' <param name="usDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UsDateToTwDate(ByVal usDate As Date) As String
        Try
            Dim twDate As String
            '取得民國年分
            Dim twC = New System.Globalization.TaiwanCalendar()

            twDate = twC.GetYear(usDate).ToString + usDate.ToString("/MM/dd")

            Return twDate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function TwDateToUsdate(ByVal twDate As String) As String
        Try
            Dim usDate As String
            '如果是潤年
            If twDate.Contains("02/29") Then
                twDate = twDate.Replace("/29", "/28")
                usDate = CDate(twDate).AddYears(1911).AddDays(1).ToString("yyyy/MM/dd")
            Else
                usDate = CDate(twDate).AddYears(1911).ToString("yyyy/MM/dd")
            End If

            Return usDate
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
