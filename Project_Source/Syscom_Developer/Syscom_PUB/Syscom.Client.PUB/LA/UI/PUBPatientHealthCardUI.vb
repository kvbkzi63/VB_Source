'/*
'*****************************************************************************
'*
'*    Page/Class Name:  全國醫療卡維護
'*              Title:	PUBPatientHealthCardUI
'*        Description:	全國醫療服務卡維護檔-增刪改查查
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-14
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-14
'*
'*****************************************************************************
'*/

Imports System.ServiceModel

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports Syscom.Comm.TableFactory
Imports System.Text

Public Class PUBPatientHealthCardUI
    Inherits Syscom.Client.UCL.IMaintainFormUI
    Dim objPub As IPubServiceManager = Nothing
    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId
    ' Dim log As ILog = LOGDelegate.getInstance.getFileLogger(Me)
    '獲取維護表名
    Dim tableDB As String = PubPatientHealthCardDataTableFactory.tableName
    '獲取維護表名PUB_Patient_Flag
    Dim tableDBFlag As String = PubPatientFlagDataTableFactory.tableName
    'Grid使用的標題
    Dim columnNameGrid() As String = {"病歷號", "身份證號", "姓名", "生效日", "結束日", "電腦編號", "類別", "建立者", "建立時間"}
    '獲取維護表字段名
    Dim columnNameDB() As String = PubPatientHealthCardDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubPatientHealthCardDataTableFactory.columnsLength
    '獲取維護表PUB_Patient_Flag字段名
    Dim columnNameDBFlag() As String = PubPatientFlagDataTableFactory.columnsName
    Const MAXDATE As String = "9998/12/31"
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
        DB1 = 2
    End Enum

    '控件類型定義
    Enum Control_Type
        TextBox
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
            Case DataSet_Type.DB1
                '給DB用Table
                dsTemp.Tables.Add(tableDBFlag)
                For i As Integer = 0 To columnNameDBFlag.Length - 1
                    dsTemp.Tables(tableDBFlag).Columns.Add(columnNameDBFlag(i))
                Next
        End Select
        Return dsTemp
    End Function

    ''' <summary>
    ''' 初始化畫面 構建空的Grid 設定欄位長度
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance

            '構建空的Grid
            dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(tableDB)
            '設定Grid滿屏
            'dgvShowData.MultiSelect = True
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            '設定欄位長度
            'Me.txtChartNo.MaxLength = columnsLength(0)
            Me.txtHealthCardSn.MaxLength = columnsLength(3)
            Me.txtHealthCardClass.MaxLength = columnsLength(4)
            '類別欄位預設值
            Me.txtHealthCardClass.Text = "A"
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
        Dim dsDB As DataSet = genDS(DataSet_Type.DB)
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        Dim dateEffectDate As Date

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        If dtpEffectDate.IsEmpty Then
            dateEffectDate = System.DateTime.MinValue
        Else
            dateEffectDate = CDate(dtpEffectDate.GetUsDateStr)
        End If
        '執行查詢
        dsDB = objPub.queryPUBPatientHealthCardByCond_L(Me.txtChartNo.Text.ToString.Trim, dateEffectDate)
        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count = 0 Then
                    '查無資料
                    MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {})
                    CType(dgvShowData.DataSource, DataTable).Clear()
                    dgvShowData.Refresh()
                Else
                    Dim drGrid(dsDB.Tables(tableDB).Rows.Count - 1) As DataRow
                    '將查出的資料塞入Grid中
                    For i As Integer = 0 To dsDB.Tables(tableDB).Rows.Count - 1
                        drGrid(i) = dsGrid.Tables(tableDB).NewRow()
                        drGrid(i)("病歷號") = dsDB.Tables(tableDB).Rows(i)("Chart_No").ToString().Trim
                        drGrid(i)("身份證號") = dsDB.Tables(tableDB).Rows(i)("Idno").ToString().Trim
                        drGrid(i)("姓名") = dsDB.Tables(tableDB).Rows(i)("Patient_Name").ToString().Trim
                        drGrid(i)("生效日") = CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd")
                        drGrid(i)("結束日") = CDate(dsDB.Tables(tableDB).Rows(i)("End_Date")).ToString("yyyy/MM/dd")
                        drGrid(i)("電腦編號") = dsDB.Tables(tableDB).Rows(i)("Health_Card_Sn").ToString().Trim
                        drGrid(i)("類別") = dsDB.Tables(tableDB).Rows(i)("Health_Card_Class").ToString().Trim
                        drGrid(i)("建立者") = dsDB.Tables(tableDB).Rows(i)("Create_User").ToString().Trim
                        If dsDB.Tables(tableDB).Rows(i)("Create_Time").ToString <> "" Then
                            drGrid(i)("建立時間") = CDate(dsDB.Tables(tableDB).Rows(i)("Create_Time")).ToString("yyyy/MM/dd HH:mm:ss").Trim
                        End If
                        dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
                    Next
                    '資料邦定到Grid
                    dgvShowData.DataSource = dsGrid.Tables(tableDB)
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
        Dim dsDBQuery As DataSet = genDS(DataSet_Type.DB)
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
            Dim dsDBFlag As DataSet = genDS(DataSet_Type.DB1)
            Dim drDBFlag As DataRow = dsDBFlag.Tables(tableDBFlag).NewRow()
            '將輸入區資料塞入DB中
            drDB("Chart_No") = Me.txtChartNo.Text.ToString.Trim
            drDB("Effect_Date") = Me.dtpEffectDate.GetUsDateStr
            'drDB("End_Date") = Me.dtpEndDate.Text.ToString.Trim
            If Me.dtpEndDate.IsEmpty Or Me.dtpEndDate.GetUsDateStr > MAXDATE Then
                drDB("End_Date") = MAXDATE
            Else
                drDB("End_Date") = Me.dtpEndDate.GetUsDateStr
            End If
            drDB("Health_Card_Sn") = Me.txtHealthCardSn.Text.ToString.Trim
            drDB("Health_Card_Class") = Me.txtHealthCardClass.Text.ToString.Trim

            If currentUserID.Trim() = "" Then
                currentUserID = "pubuser"
            End If
            drDB("Create_User") = currentUserID
            drDB("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss").Trim

            dsDB.Tables(tableDB).Rows.Add(drDB)

            drDBFlag("Chart_No") = Me.txtChartNo.Text.ToString.Trim
            drDBFlag("Flag_Id") = "124"
            drDBFlag("Flag_Memo") = "HIV"
            drDBFlag("Flag_Id") = "124"
            drDBFlag("Record_Date") = Now.ToString("yyyy/MM/dd").Trim
            drDBFlag("Create_User") = currentUserID
            drDBFlag("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss").Trim
            dsDBFlag.Tables(tableDBFlag).Rows.Add(drDBFlag)
            Dim dsFlag As DataSet = objPub.queryPubPatientFlagByChartNo_L(Me.txtChartNo.Text.ToString.Trim)
            If dsFlag.Tables.Count > 0 AndAlso dsFlag.Tables(0).Rows.Count > 0 Then
                '執行新增
                iCount = objPub.insertPUBPatientHealthCard_L(dsDB)
            Else
                iCount = objPub.insertPUBHealthAndFlag_L(dsDB, dsDBFlag, True)
            End If

            If iCount > 0 Then
                drGrid("病歷號") = dsDB.Tables(tableDB).Rows(0)("Chart_No").ToString().Trim
                drGrid("身份證號") = Me.txtIdNo.Text.ToString().Trim
                drGrid("姓名") = Me.txtPatientName.Text.ToString.Trim
                drGrid("生效日") = dsDB.Tables(tableDB).Rows(0)("Effect_Date").ToString().Trim
                drGrid("結束日") = dsDB.Tables(tableDB).Rows(0)("End_Date").ToString().Trim
                drGrid("電腦編號") = dsDB.Tables(tableDB).Rows(0)("Health_Card_Sn").ToString().Trim
                drGrid("類別") = dsDB.Tables(tableDB).Rows(0)("Health_Card_Class").ToString().Trim
                drGrid("建立者") = dsDB.Tables(tableDB).Rows(0)("Create_User").ToString().Trim
                drGrid("建立時間") = dsDB.Tables(tableDB).Rows(0)("Create_Time").ToString().Trim
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
            Dim drGrid As DataRow = dsGrid.Tables(tableDB).NewRow()
            Dim drDB As DataRow = dsDB.Tables(tableDB).NewRow()
            Dim dsDBQuery As DataSet = genDS(DataSet_Type.DB)
            Dim dsDBFlag As DataSet = genDS(DataSet_Type.DB1)
            Dim drDBFlag As DataRow = dsDBFlag.Tables(tableDBFlag).NewRow()
            '將輸入區資料塞入DB中
            drDB("Chart_No") = Me.txtChartNo.Text.ToString.Trim
            drDB("Effect_Date") = Me.dtpEffectDate.GetUsDateStr
            'drDB("End_Date") = Me.dtpEndDate.Text.ToString.Trim
            If Me.dtpEndDate.IsEmpty Or Me.dtpEndDate.GetUsDateStr > MAXDATE Then
                drDB("End_Date") = MAXDATE
            Else
                drDB("End_Date") = Me.dtpEndDate.GetUsDateStr
            End If
            drDB("Health_Card_Sn") = Me.txtHealthCardSn.Text.ToString.Trim
            drDB("Health_Card_Class") = Me.txtHealthCardClass.Text.ToString.Trim

            drDB("Create_User") = Nothing
            drDB("Create_Time") = Nothing
            dsDB.Tables(tableDB).Rows.Add(drDB)

            drDBFlag("Chart_No") = Me.txtChartNo.Text.ToString.Trim
            drDBFlag("Flag_Id") = "124"
            drDBFlag("Flag_Memo") = "HIV"
            drDBFlag("Flag_Id") = "124"
            drDBFlag("Record_Date") = Now.ToString("yyyy/MM/dd").Trim
            drDBFlag("Create_User") = currentUserID
            drDBFlag("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss").Trim
            dsDBFlag.Tables(tableDBFlag).Rows.Add(drDBFlag)
            Dim dsFlag As DataSet = objPub.queryPubPatientFlagByChartNo_L(Me.txtChartNo.Text.ToString.Trim)
            If dsFlag.Tables.Count > 0 AndAlso dsFlag.Tables(0).Rows.Count > 0 Then
                '執行修改
                iCount = objPub.updatePUBPatientHealthCard_L(dsDB)
            Else
                iCount = objPub.insertPUBHealthAndFlag_L(dsDB, dsDBFlag, False)
            End If

            ''執行修改
            'iCount = objPub.updatePUBPatientHealthCard_L(dsDB)
            If iCount > 0 Then
                '將DB資料塞入Grid中
                Dim dtGrid As DataTable = dgvShowData.DataSource
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("病歷號"), dtGrid.Columns("生效日")}
                If dtGrid.Rows.Contains(New Object() {Me.txtChartNo.Text.Trim, Me.dtpEffectDate.GetUsDateStr}) Then
                    CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.txtChartNo.Text.Trim, Me.dtpEffectDate.GetUsDateStr})
                    ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    drGrid("病歷號") = dsDB.Tables(tableDB).Rows(0)("Chart_No").ToString().Trim
                    drGrid("身份證號") = Me.txtIdNo.Text.ToString().Trim
                    drGrid("姓名") = Me.txtPatientName.Text.ToString.Trim
                    drGrid("生效日") = dsDB.Tables(tableDB).Rows(0)("Effect_Date").ToString().Trim
                    drGrid("結束日") = dsDB.Tables(tableDB).Rows(0)("End_Date").ToString().Trim
                    drGrid("電腦編號") = dsDB.Tables(tableDB).Rows(0)("Health_Card_Sn").ToString().Trim
                    drGrid("類別") = dsDB.Tables(tableDB).Rows(0)("Health_Card_Class").ToString().Trim
                    drGrid("建立者") = drGrid2("建立者").ToString().Trim
                    drGrid("建立時間") = drGrid2("建立時間").ToString().Trim
                    dsGrid.Tables(tableDB).Rows.Add(drGrid)
                    '同步更新
                    updateDataGridView(iButtonFlag, dsGrid)
                End If
            Else
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
        Dim dsDB As DataSet = genDS(DataSet_Type.DB)
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        Try
            Dim iCount As Integer = 0
            '執行刪除
            iCount = objPub.deletePUBPatientHealthCard_L(Me.txtChartNo.Text.ToString.Trim, Me.dtpEffectDate.Text.Trim)
            If iCount > 0 Then
                Dim dtGrid As DataTable = dgvShowData.DataSource
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("病歷號"), dtGrid.Columns("生效日")}
                If dtGrid.Rows.Contains(New Object() {Me.txtChartNo.Text.ToString.Trim, Me.dtpEffectDate.Text.Trim}) Then
                    CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.txtChartNo.Text.ToString.Trim, Me.dtpEffectDate.Text.Trim})
                    ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                End If
            Else
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
    ''' 欄位檢查
    ''' </summary>
    ''' <param name="iButtonFlag">BUTTON標記</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 檢查不通過;False 檢查通過</remarks>
    Private Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean
        Try
            Dim blnReturnFlag As Boolean = False
            Dim strErrMsg1 As StringBuilder = New StringBuilder
            Dim strErrMsg2 As StringBuilder = New StringBuilder
            '設定需要檢查的欄位
            Dim ctltxtChartNo As Control = Me.txtChartNo
            Dim cltdtpEffectDate As Control = Me.dtpEffectDate
            Dim clttxtHealthCardClass As Control = Me.txtHealthCardClass
            Dim ctlObjFocus As Control = ctltxtChartNo
            '清除欄位背景色
            cleanFieldsColor()
            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not fieldCheckNull(ctltxtChartNo, Control_Type.TextBox) Then
                        strErrMsg1.Append("病歷號")
                        ctlObjFocus = ctltxtChartNo
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(cltdtpEffectDate, Control_Type.DateTimePicker) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("生效日")
                        ctlObjFocus = cltdtpEffectDate
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(clttxtHealthCardClass, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("類別")
                        ctlObjFocus = clttxtHealthCardClass
                        blnReturnFlag = True
                    End If
                    If Not dtpEndDate.GetUsDateStr.Equals("") Then
                        If Me.dtpEffectDate.GetUsDateStr() > Me.dtpEndDate.GetUsDateStr() Then
                            strErrMsg2.Append("結束日" & "," & "生效日")
                            Me.dtpEndDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            If blnReturnFlag = False Then
                                ctlObjFocus = dtpEndDate
                            End If
                            blnReturnFlag = True
                        End If
                    End If
                Case buttonAction.DELETE
                    If Not fieldCheckNull(ctltxtChartNo, Control_Type.TextBox) Then
                        strErrMsg1.Append("病歷號")
                        ctlObjFocus = ctltxtChartNo
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(cltdtpEffectDate, Control_Type.DateTimePicker) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("生效日")
                        ctlObjFocus = cltdtpEffectDate
                        blnReturnFlag = True
                    End If
                    If Not dtpEndDate.GetUsDateStr.Equals("") Then
                        If Me.dtpEffectDate.GetUsDateStr() > Me.dtpEndDate.GetUsDateStr() Then
                            strErrMsg2.Append("結束日" & "," & "生效日")
                            Me.dtpEndDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            If blnReturnFlag = False Then
                                ctlObjFocus = dtpEndDate
                            End If
                            blnReturnFlag = True
                        End If
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
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {pvtErrorMsg}, "")
                ctlObjFocus.Focus()
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '''' <summary>
    '''' 檢查是否為空白
    '''' </summary>
    '''' <param name="ctl">控件</param>
    '''' <param name="ctType">控件類型</param>
    '''' <returns>Boolean</returns>
    '''' <remarks>True 合法;False 非法</remarks>
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

    ''' <summary>
    ''' 清除事件
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub clearData()
        '清除欄位資料
        cleanFieldsValue()
        '清除欄位背景顏色
        cleanFieldsColor()
        CType(dgvShowData.DataSource, DataTable).Clear()
        dgvShowData.Refresh()
    End Sub

    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.txtChartNo.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.dtpEffectDate.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtHealthCardClass.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
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
            Me.txtChartNo.Text = ""
            Me.dtpEffectDate.Clear()
            Me.dtpEndDate.Clear()
            Me.txtIdNo.Text = ""
            Me.txtHealthCardClass.Text = "A"
            Me.txtHealthCardSn.Text = ""
            Me.txtPatientName.Text = ""
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
                Me.txtChartNo.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("病歷號").Value
                Me.txtIdNo.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("身份證號").Value
                Me.txtPatientName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("姓名").Value
                Me.txtHealthCardSn.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("電腦編號").Value
                Me.txtHealthCardClass.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("類別").Value
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("生效日").Value.ToString.Trim <> "" Then
                    Me.dtpEffectDate.SetValue(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("生效日").Value.ToString.Trim)
                Else
                    Me.dtpEffectDate.Clear()
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("結束日").Value.ToString.Trim <> "" Then
                    Me.dtpEndDate.SetValue(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("結束日").Value.ToString.Trim)
                Else
                    Me.dtpEndDate.Clear()
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
    Private Sub updateDataGridView(ByVal mode As Integer, ByVal ds As DataSet)
        Select Case mode
            Case buttonAction.INSERT
                CType(dgvShowData.DataSource, System.Data.DataTable).Rows.Add(ds.Tables(tableDB).Rows(0).ItemArray)
            Case buttonAction.UPDATE
                dgvShowData.CurrentRow.SetValues(ds.Tables(tableDB).Rows(0).ItemArray)
        End Select
    End Sub

    ''' <summary>
    ''' 病歷號光標離開事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtChartNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChartNo.Leave
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()

            '設定身份證號
            PatientMessageSet()

        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD001")
            MessageHandling.ShowErrorMsg("CMMCMMD001", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 病患信息設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PatientMessageSet()
        If Me.txtChartNo.Text.Trim <> "" Then
            Me.txtIdNo.Text = Me.txtChartNo.GetPatientObj().Idno
            Me.txtPatientName.Text = Me.txtChartNo.GetPatientObj().Patient_Name
        Else
            Me.txtIdNo.Text = ""
            Me.txtPatientName.Text = ""
        End If

    End Sub


End Class

