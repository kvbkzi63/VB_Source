'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBZoneRoomUI.vb
'*              Title:	診區診間維護檔
'*        Description:	診區診間維護檔
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	pearl
'*        Create Date:	2010/04/21
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
Imports System.Text
Imports Syscom.Client.UCL
Public Class PUBZoneRoomUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

    Dim objPub As IPubServiceManager = Nothing
    '目前使用者的ID
    'Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

    '獲取維護表名
    Dim tableDB As String = PubZoneRoomDataTableFactory.tableName
    Dim pubSyscodeTableName As String = PubZoneRoomDataTableFactory.tableName
    '
    Dim iAccountId As Integer = 41
    '
    Dim iReceiptAccountId As Integer = 42
    '
    Dim iInsuAccountId As Integer = 43
    '
    Dim iAcc1AccountId As Integer = 44
    '
    Dim iAcc2AccountId As Integer = 45
    Dim itypeId As Integer
    'Grid使用的標題
    Dim columnNameGrid() As String = {"診區代碼", "診間號", "分機號碼", "診間名稱", "診間英文名稱", "停用", "建立者", "建立時間", "修改者", "修改時間", "診區代碼ID", "樓層"}
    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {10}
    '獲取維護表字段名
    Dim columnNameDB() As String = PubZoneRoomDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubZoneRoomDataTableFactory.columnsLength
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        ComboBox
        TextBox
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
   
    ''' <summary>
    ''' 初始化畫面 構建空的Grid 設定欄位長度
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub initialData()

        Try
            '初始化對象
            objPub = PubServiceManager.getInstance
            '構建空的Grid
            dgvShowData.DataSource = genDS(DataSet_Type.Grid)
            '設定Grid滿屏
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            '設定grid的隱藏欄位
            For i As Integer = 0 To visibleColumnNo.Count - 1
                dgvShowData.Columns(visibleColumnNo(i)).Visible = False
            Next

            '診區代碼
            initialComboBox()
           
            Me.ckbDc.Checked = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub initialComboBox()
        Dim dsDB As DataSet
        '執行查詢
        Dim objPub As IPubServiceManager = PubServiceManager.getInstance
        dsDB = objPub.queryPUBSysCodeByCV((New String() {"Type_Id", "DC"}), New Object() {79, "N"})
        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    '院內費用項目代碼combo塞值
                    Me.cmbZoneId.DataSource = dsDB.Tables(0)
                    Me.cmbZoneId.uclDisplayIndex = "0,1"
                    Me.cmbZoneId.uclValueIndex = "0"
                End If
            End If
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
        Dim strZoneId As String = Me.cmbZoneId.SelectedValue.Trim
        Dim strRoomCode As String = Me.txtRoomCode.Text.Trim
        '欄位檢查
        cleanFieldsColor()
        '執行查詢
        dsDB = objPub.queryPUBZoneRoomByCond(strZoneId, strRoomCode)
        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                    'CType(dgvShowData.DataSource.Tables(tableDB), DataTable).Clear()
                    'dgvShowData.Refresh()
                Else
                    Dim drGrid(dsDB.Tables(tableDB).Rows.Count - 1) As DataRow
                    '將查出的資料塞入Grid中
                    For i As Integer = 0 To dsDB.Tables(tableDB).Rows.Count - 1
                        drGrid(i) = dsGrid.Tables(tableDB).NewRow()
                        drGrid(i)("診區代碼") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Zone_Id")) & " - " & StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Code_Name"))
                        drGrid(i)("診間號") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Room_Code"))
                        drGrid(i)("分機號碼") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Tel_Ext_No"))
                        drGrid(i)("診間名稱") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Room_Name"))
                        drGrid(i)("診間英文名稱") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Room_En_Name"))
                        strTemp = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Dc"))
                        If strTemp = "N" Then
                            drGrid(i)("停用") = "否"
                        Else
                            drGrid(i)("停用") = "是"
                        End If
                        drGrid(i)("建立者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_User"))
                        drGrid(i)("建立時間") = CDate(StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_Time"))).ToString("yyyy/MM/dd HH:mm:ss")
                        drGrid(i)("修改者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Modified_User"))
                        strTemp = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Modified_Time"))
                        If strTemp <> "" Then
                            drGrid(i)("修改時間") = CDate(strTemp).ToString("yyyy/MM/dd HH:mm:ss")
                        End If
                        drGrid(i)("診區代碼ID") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Zone_Id"))
                        drGrid(i)("樓層") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Floor"))

                        dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
                    Next
                    '資料邦定到Grid
                    'dgvShowData.DataSource = dsGrid
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
        Dim strTemp As String
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
            drDB("Zone_Id") = Me.cmbZoneId.SelectedValue.ToString.Trim
            drDB("Room_Code") = Me.txtRoomCode.Text.ToString.Trim
            drDB("Tel_Ext_No") = Me.txtTelExtNo.Text.ToString.Trim
            drDB("Room_Name") = Me.txtRoomName.Text.ToString.Trim
            drDB("Room_En_Name") = Me.txtRoomEnName.Text.ToString.Trim
            drDB("Floor") = Me.txtFloor.Text.ToString.Trim
            If ckbDc.Checked = True Then
                drDB("DC") = "Y"
            Else
                drDB("DC") = "N"
            End If
            If currentUserID.Trim() = "" Then
                currentUserID = "pubuser"
            End If
            drDB("Create_User") = currentUserID
            drDB("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = drDB("Create_Time")
            dsDB.Tables(tableDB).Rows.Add(drDB)
            '執行新增 將查出的資料塞入Grid中 
            iCount = objPub.insertPUBZoneRoom(dsDB)
            If iCount > 0 Then

                If Me.cmbZoneId.Text.ToString.Trim <> "" Then
                    drGrid("診區代碼ID") = Me.cmbZoneId.SelectedValue.ToString.Trim
                    drGrid("診區代碼") = Me.cmbZoneId.Text.Trim
                Else
                    drGrid("診區代碼ID") = ""
                    drGrid("診區代碼") = ""
                End If
                If Me.txtRoomCode.Text.ToString.Trim <> "" Then
                    drGrid("診間號") = Me.txtRoomCode.Text.ToString.Trim
                Else
                    drGrid("診間號") = ""
                End If
                If Me.txtTelExtNo.Text.ToString.Trim <> "" Then
                    drGrid("分機號碼") = Me.txtTelExtNo.Text.ToString.Trim
                Else
                    drGrid("分機號碼") = ""
                End If
                If Me.txtRoomName.Text.ToString.Trim <> "" Then
                    drGrid("診間名稱") = Me.txtRoomName.Text.ToString.Trim
                Else
                    drGrid("診間名稱") = ""
                End If
                If Me.txtRoomEnName.Text.ToString.Trim <> "" Then
                    drGrid("診間英文名稱") = Me.txtRoomEnName.Text.ToString.Trim
                Else
                    drGrid("診間英文名稱") = ""
                End If
                If Me.txtFloor.Text.ToString.Trim <> "" Then
                    drGrid("樓層") = Me.txtFloor.Text.ToString.Trim
                Else
                    drGrid("樓層") = ""
                End If
                strTemp = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Dc"))
                If strTemp = "N" Then
                    drGrid("停用") = "否"
                Else
                    drGrid("停用") = "是"
                End If
                drGrid("建立者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Create_User"))
                drGrid("建立時間") = CDate(StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Create_Time"))).ToString("yyyy/MM/dd HH:mm:ss")
                drGrid("修改者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Modified_User"))
                strTemp = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Modified_Time"))
                If strTemp <> "" Then
                    drGrid("修改時間") = CDate(strTemp).ToString("yyyy/MM/dd HH:mm:ss")
                End If
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
            '將輸入區資料塞入DB中
            drDB("Zone_Id") = Me.cmbZoneId.SelectedValue.Trim
            drDB("Room_Code") = Me.txtRoomCode.Text.Trim
            drDB("Tel_Ext_No") = Me.txtTelExtNo.Text.Trim
            drDB("Room_Name") = Me.txtRoomName.Text.Trim
            drDB("Room_En_Name") = Me.txtRoomEnName.Text.Trim
            drDB("Floor") = Me.txtFloor.Text.Trim
            If ckbDc.Checked = True Then
                drDB("DC") = "Y"
            Else
                drDB("DC") = "N"
            End If
            If currentUserID.Trim() = "" Then
                currentUserID = "pubuser"
            End If
            drDB("Create_User") = Nothing
            drDB("Create_Time") = Nothing
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            dsDB.Tables(tableDB).Rows.Add(drDB)
            '執行修改
            iCount = objPub.updatePUBZoneRoom(dsDB)
            If iCount > 0 Then
                '將DB資料塞入Grid中 "院內費用項目代碼", "收據費用項目代碼", "健保費用項目代碼", "會計費用項目代碼1", "會計費用項目代碼2", "停用", "建立者", "建立時間", "修改者", "修改時間", "院內費用項目代碼DB", "收據費用項目代碼DB", "健保費用項目代碼DB", "會計費用項目代碼1DB", "會計費用項目代碼2DB"
                'Dim dtGrid As DataTable = dgvShowData.DataSource.Tables(tableDB)
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0)
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("診區代碼ID"), dtGrid.Columns("診間號")}
                If dtGrid.Rows.Contains(New Object() {Me.cmbZoneId.SelectedValue.ToString.Trim, Me.txtRoomCode.Text.ToString.Trim}) Then
                    'CType(dgvShowData.DataSource.Tables(tableDB), DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.cmbZoneId.SelectedValue.Trim, Me.txtRoomCode.Text.ToString.Trim})
                    'dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    If Me.cmbZoneId.Text.ToString.Trim <> "" Then
                        drGrid("診區代碼ID") = Me.cmbZoneId.SelectedValue.ToString.Trim
                        drGrid("診區代碼") = Me.cmbZoneId.Text.Trim
                    Else
                        drGrid("診區代碼ID") = ""
                        drGrid("診區代碼") = ""
                    End If
                    If Me.txtRoomCode.Text.ToString.Trim <> "" Then
                        drGrid("診間號") = Me.txtRoomCode.Text.ToString.Trim
                    Else
                        drGrid("診間號") = ""
                    End If
                    If Me.txtTelExtNo.Text.ToString.Trim <> "" Then
                        drGrid("分機號碼") = Me.txtTelExtNo.Text.ToString.Trim
                    Else
                        drGrid("分機號碼") = ""
                    End If
                    If Me.txtRoomName.Text.ToString.Trim <> "" Then
                        drGrid("診間名稱") = Me.txtRoomName.Text.ToString.Trim
                    Else
                        drGrid("診間名稱") = ""
                    End If
                    If Me.txtRoomEnName.Text.ToString.Trim <> "" Then
                        drGrid("診間英文名稱") = Me.txtRoomEnName.Text.ToString.Trim
                    Else
                        drGrid("診間英文名稱") = ""
                    End If
                    If Me.txtFloor.Text.ToString.Trim <> "" Then
                        drGrid("樓層") = Me.txtFloor.Text.ToString.Trim
                    Else
                        drGrid("樓層") = ""
                    End If
                    If StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("DC")) = "N" Then
                        drGrid("停用") = "否"
                    Else
                        drGrid("停用") = "是"
                    End If
                    drGrid("建立者") = StringUtil.nvl(drGrid2("建立者"))
                    drGrid("建立時間") = StringUtil.nvl(drGrid2("建立時間"))
                    drGrid("修改者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Modified_User"))
                    drGrid("修改時間") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Modified_Time"))
                    dsGrid.Tables(tableDB).Rows.Add(drGrid)
                    '同步更新
                    updateDataGridView(iButtonFlag, dsGrid)
                End If
            Else
                'MessageHandling.showWarnByKey("CMMCMMB010")
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
            iCount = objPub.deletePUBZoneRoomByPK(Me.cmbZoneId.SelectedValue.Trim, Me.txtRoomCode.Text.Trim)
            If iCount > 0 Then
                'Dim dtGrid As DataTable = dgvShowData.DataSource.Tables(tableDB)
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0)
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("診區代碼ID"), dtGrid.Columns("診間號")}
                If dtGrid.Rows.Contains(New Object() {Me.cmbZoneId.SelectedValue.Trim, Me.txtRoomCode.Text.Trim}) Then
                    'CType(dgvShowData.DataSource.Tables(tableDB), DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.cmbZoneId.SelectedValue.Trim, Me.txtRoomCode.Text.Trim})
                    'dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                End If
            Else
                'MessageHandling.showWarnByKey("CMMCMMB011")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showWarnMsg("CMMCMMB011", New String() {})
                blnReturnFlag = False
            End If
            ''清除欄位背景色
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
            '設定需要檢查的欄位
            Dim ctlCmbZoneId As Control = Me.cmbZoneId
            Dim ctlTxtRoomCode As Control = Me.txtRoomCode

            Dim ctlObjFocus As Control = ctlCmbZoneId
            '清除欄位背景色
            cleanFieldsColor()
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE, buttonAction.DELETE
                    If Not fieldCheckNull(ctlCmbZoneId, Control_Type.ComboBox) Then
                        strErrMsg1.Append("診區代碼")
                        ctlObjFocus = ctlCmbZoneId
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtRoomCode, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("診間號")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtRoomCode
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
            Case Control_Type.ComboBox
                Dim objCtl As Syscom.Client.UCL.UCLComboBoxUC = ctl

                If objCtl.SelectedValue.Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.TextBox
                Dim objCtl As Syscom.Client.UCL.UCLTextBoxUC = ctl
                If objCtl.Text.Trim.Equals("") Then
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
        'CType(dgvShowData.DataSource.Tables(tableDB), DataTable).Clear()
        dgvShowData.ClearDS()
        dgvShowData.Refresh()
    End Sub

    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.cmbZoneId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtRoomCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT

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
            Me.cmbZoneId.SelectedValue = ""
            Me.txtRoomCode.Text = ""
            Me.txtRoomEnName.Text = ""
            Me.txtRoomName.Text = ""
            Me.txtTelExtNo.Text = ""
            Me.txtFloor.Text = ""
            Me.ckbDc.Checked = False
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
            If dgvShowData.CurrentCellAddress.Y >= 0 Then   '"院內費用項目代碼DB", "收據費用項目代碼DB", "健保費用項目代碼DB", "會計費用項目代碼1DB", "會計費用項目代碼2DB"
                Me.cmbZoneId.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("診區代碼ID").Value)
                Me.txtRoomCode.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("診間號").Value)
                Me.txtTelExtNo.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("分機號碼").Value)
                Me.txtRoomName.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("診間名稱").Value)
                Me.txtRoomEnName.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("診間英文名稱").Value)
                Me.txtFloor.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("樓層").Value)
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停用").Value) = "是" Then
                    Me.ckbDc.Checked = True
                Else
                    Me.ckbDc.Checked = False
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
                'CType(dgvShowData.DataSource.Tables(tableDB), System.Data.DataTable).Rows.Add(ds.Tables(tableDB).Rows(0).ItemArray)
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
    ''' 取得欄位顯示的欄位資料
    ''' </summary>
    ''' <param name="dgvName">DataGridView的Name</param>
    ''' <remarks></remarks>
    Private Function getColumnData(ByVal dgvName As String) As String(,)
        'Array元素Index的對照：Grid欄位顯示名稱、資料庫欄位名稱、顯示與否、(日期欄位D,DT、金額M、數值NO)與否、顯示欄位的長度
        Select Case dgvName
            Case "dgvShowData"
                Return New String(,) {{"診區代碼", "診區代碼", "Y", "N", ""}, _
                                      {"診間號", "診間號", "Y", "N", ""}, _
                                      {"分機號碼", "分機號碼", "Y", "N", ""}, _
                                      {"診間名稱", "診間名稱", "Y", "N", ""}, _
                                      {"診間英文名稱", "診間英文名稱", "Y", "N", ""}, _
                                      {"停用", "停用", "Y", "N", ""}, _
                                      {"建立者", "建立者", "Y", "N", ""}, _
                                      {"建立時間", "建立時間", "Y", "N", ""}, _
                                      {"修改者", "修改者", "Y", "N", ""}, _
                                      {"修改時間", "修改時間", "Y", "N", ""}, _
                                      {"診區代碼ID", "診區代碼ID", "N", "N", ""}, _
                                      {"樓層", "樓層", "Y", "N", ""}}
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
End Class