'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBBodySiteUI.vb
'*              Title:	部位檔維護
'*        Description:	部位檔維護介面-查詢，增加，修改，刪除，清除操作
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	tianxie
'*        Create Date:	2009/08/14
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

Public Class PUBBodySiteUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI


    Dim objOph As IPubServiceManager = Nothing

    '目前使用者的ID
    'Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)
    '獲取維護表名--PharmacistDuty表
    Dim bodySiteDB As String = PubBodySiteDataTableFactory.tableName
    'Grid使用的標題--組別代碼為隱藏字段
    Dim columnNameGrid() As String = {"部位代碼", "部位名稱", "部位大分類", "停用", "建立者", "建立時間", "修改者", "修改時間"}
    '獲取維護表字段名
    Dim bodySiteColumnNameDB() As String = PubBodySiteDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim bodySiteColumnsLength() As Integer = PubBodySiteDataTableFactory.columnsLength
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
    ''' 產生一個DataSet並包含一個空的Table 給Grid用 或 DB用
    ''' </summary>
    ''' <param name="type">資料集類型</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function genDS(ByVal type As Integer, ByVal table As String) As DataSet
        Dim dsTemp As New DataSet

        Select Case type
            Case DataSet_Type.Grid
                '給Grid用Table
                dsTemp.Tables.Add(table)
                For i As Integer = 0 To columnNameGrid.Length - 1
                    dsTemp.Tables(table).Columns.Add(columnNameGrid(i))
                Next
            Case DataSet_Type.DB
                '給DB用Table
                dsTemp.Tables.Add(table)
                For i As Integer = 0 To bodySiteColumnNameDB.Length - 1
                    dsTemp.Tables(table).Columns.Add(bodySiteColumnNameDB(i))
                Next
        End Select
        Return dsTemp
    End Function

    Public Sub initialCmbMainBodySiteCode()
        Dim dsDB As DataSet
        dsDB = objOph.queryMainBodySiteCodeByCond("")
        Try
            If dsDB.Tables.Count > 0 Then
                'If dsDB.Tables(0).Rows.Count > 0 Then
                Me.cmbMainBodySiteCode.DataSource = dsDB.Tables(0)
                Me.cmbMainBodySiteCode.uclValueIndex = "0"
                Me.cmbMainBodySiteCode.uclDisplayIndex = "0,1"
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 初始化健保申報部位
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbNhiBodySiteCode()
        Dim dsDB As DataSet

        '執行查詢
        dsDB = objOph.queryNhiBodySiteCodeByColumnValue((New String() {"Type_Id", "DC"}), New Object() {115, "N"})

        Try
            If dsDB.Tables.Count > 0 Then
                'If dsDB.Tables(0).Rows.Count > 0 Then
                Me.cmbNhiBodySiteCode.DataSource = dsDB.Tables(0)
                Me.cmbNhiBodySiteCode.uclValueIndex = "0"
                Me.cmbNhiBodySiteCode.uclDisplayIndex = "0,1"
                'End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' 初始化畫面 構建空的Grid 設定欄位長度
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub initialData()
        Try
            '初始化對象
            objOph = PubServiceManager.getInstance
            '構建空的Grid
            showResult(dgvShowData, genDataSet("dgvShowData"))
            '設定Grid滿屏
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            '設定欄位長度
            Me.txtBodySiteCode.MaxLength = bodySiteColumnsLength(0)
            Me.txtBodySiteName.MaxLength = bodySiteColumnsLength(1)
            'Me.cmbMainBodySiteCode.MaxLength = bodySiteColumnsLength(2)
            '初始化健保申報部位代碼
            Me.initialCmbNhiBodySiteCode()

            Me.initialCmbMainBodySiteCode()
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
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid, bodySiteDB)
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        Dim strDc As String
        If chkDc.Checked = True Then
            strDc = "Y"
        Else
            strDc = "N"
        End If
        '執行查詢
        'dsDB = objOph.queryPUBBodySiteByCond(txtBodySiteCode.Text.Trim.Replace("'", "''"), txtBodySiteName.Text.Trim.Replace("'", "''"), cmbMainBodySiteCode.Text.Trim.Replace("'", "''"), cmbNhiBodySiteCode.SelectedValue.Trim.ToString(), strDc)
        dsDB = objOph.queryPUBBodySiteByCond(txtBodySiteCode.Text.Trim.Replace("'", "''"))

        'Select Main_Body_Site_Code 
        Dim mainBodySiteCode As String = StringUtil.nvl(cmbMainBodySiteCode.SelectedValue.Trim)
        If mainBodySiteCode.Length > 0 Then
            Dim dt As DataTable
            dt = dsDB.Tables(0).Select("main_body_site_code = '" & mainBodySiteCode & "'").CopyToDataTable()
            dt.TableName = PubBodySiteDataTableFactory.tableName

            Dim ds As New DataSet
            ds.Tables.Add(dt)
            dsDB = ds
        End If

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(bodySiteDB).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {})
                Else
                    Dim drGrid(dsDB.Tables(bodySiteDB).Rows.Count) As DataRow
                    '將查出的資料塞入Grid中
                    For i As Integer = 0 To dsDB.Tables(bodySiteDB).Rows.Count - 1
                        drGrid(i) = dsGrid.Tables(bodySiteDB).NewRow()
                        drGrid(i)("部位代碼") = dsDB.Tables(bodySiteDB).Rows(i)("Body_Site_Code").ToString.Trim()
                        drGrid(i)("部位名稱") = dsDB.Tables(bodySiteDB).Rows(i)("Body_Site_Name").ToString.Trim()
                        drGrid(i)("部位大分類") = dsDB.Tables(bodySiteDB).Rows(i)("Main_Body_Site_Code").ToString.Trim()
                        'drGrid(i)("健保申報部位代碼") = dsDB.Tables(bodySiteDB).Rows(i)("Nhi_Body_Site_Code").ToString.Trim()
                        'drGrid(i)("健保申報部位名稱") = dsDB.Tables(bodySiteDB).Rows(i)("Code_Name").ToString.Trim()
                        If dsDB.Tables(bodySiteDB).Rows(i)("Dc").ToString() = "N" Then
                            drGrid(i)("停用") = "否"
                        Else
                            drGrid(i)("停用") = "是"
                        End If
                        drGrid(i)("建立者") = dsDB.Tables(bodySiteDB).Rows(i)("Create_User").ToString.Trim()
                        drGrid(i)("建立時間") = CDate(dsDB.Tables(bodySiteDB).Rows(i)("Create_Time")).ToString("yyyy/MM/dd HH:mm:ss")
                        drGrid(i)("修改者") = dsDB.Tables(bodySiteDB).Rows(i)("Modified_User").ToString.Trim()
                        If dsDB.Tables(bodySiteDB).Rows(i)("Modified_Time").ToString <> "" Then
                            drGrid(i)("修改時間") = CDate(dsDB.Tables(bodySiteDB).Rows(i)("Modified_Time")).ToString("yyyy/MM/dd HH:mm:ss")
                        End If
                        dsGrid.Tables(bodySiteDB).Rows.Add(drGrid(i))
                    Next
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

            Dim dsbodySiteDB As DataSet = genDS(DataSet_Type.DB, bodySiteDB)
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid, bodySiteDB)
            Dim drGrid As DataRow = dsGrid.Tables(bodySiteDB).NewRow()
            Dim drDB As DataRow = dsbodySiteDB.Tables(bodySiteDB).NewRow()

            '將輸入區資料塞入DB中
            drDB("Body_Site_Code") = Me.txtBodySiteCode.Text.Trim
            drDB("Body_Site_Name") = Me.txtBodySiteName.Text.Trim
            'drDB("Nhi_Body_Site_Code") = Me.cmbNhiBodySiteCode.SelectedValue.Trim
            If Me.cmbMainBodySiteCode.SelectedValue.Trim = "" Then
                drDB("Main_Body_Site_Code") = Me.txtBodySiteCode.Text.Trim
            Else
                drDB("Main_Body_Site_Code") = Me.cmbMainBodySiteCode.SelectedValue.Trim
            End If


            If chkDc.Checked = True Then
                drDB("Dc") = "Y"
            Else
                drDB("Dc") = "N"
            End If
            If currentUserID.Trim() = "" Then
                currentUserID = "pubuser"
            End If
            drDB("Create_User") = currentUserID
            drDB("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = drDB("Create_Time")

            dsbodySiteDB.Tables(bodySiteDB).Rows.Add(drDB)

            '執行新增
            iCount = objOph.insertPUBBodySite(dsbodySiteDB)
            initialCmbMainBodySiteCode()
            Me.cmbMainBodySiteCode.SelectedValue = drDB("Main_Body_Site_Code")
            If iCount > 0 Then
                '將DB資料塞入Grid中
                drGrid("部位代碼") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Body_Site_Code").ToString.Trim()
                drGrid("部位名稱") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Body_Site_Name").ToString.Trim()
                'drGrid("部位大分類") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Main_Body_Site_Code").ToString.Trim()
                If Me.cmbMainBodySiteCode.SelectedValue.ToString.Trim() = "" Then
                    drGrid("部位大分類") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Body_Site_Code").ToString.Trim()
                Else
                    drGrid("部位大分類") = Me.cmbMainBodySiteCode.SelectedValue.ToString.Trim()
                End If

                'drGrid("健保申報部位代碼") = Me.cmbNhiBodySiteCode.SelectedValue.ToString.Trim()
                'drGrid("健保申報部位名稱") = Me.cmbNhiBodySiteCode.SelectedItem(1).ToString().Trim()
                If dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Dc").ToString() = "N" Then
                    drGrid("停用") = "否"
                Else
                    drGrid("停用") = "是"
                End If
                drGrid("建立者") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Create_User").ToString.Trim()
                drGrid("建立時間") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Create_Time")
                drGrid("修改者") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Modified_User").ToString.Trim()
                drGrid("修改時間") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Modified_Time")

                dsGrid.Tables(bodySiteDB).Rows.Add(drGrid)
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

            Dim dsbodySiteDB As DataSet = genDS(DataSet_Type.DB, bodySiteDB)
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid, bodySiteDB)
            Dim drGrid As DataRow = dsGrid.Tables(bodySiteDB).NewRow()
            Dim drDB As DataRow = dsbodySiteDB.Tables(bodySiteDB).NewRow()

            '將輸入區資料塞入DB中
            drDB("Body_Site_Code") = Me.txtBodySiteCode.Text.Trim
            drDB("Body_Site_Name") = Me.txtBodySiteName.Text.Trim
            If Me.cmbMainBodySiteCode.SelectedValue.Trim = "" Then
                drDB("Main_Body_Site_Code") = Me.txtBodySiteCode.Text.Trim
            Else
                drDB("Main_Body_Site_Code") = Me.cmbMainBodySiteCode.SelectedValue.Trim
            End If

            'drDB("Nhi_Body_Site_Code") = Me.cmbNhiBodySiteCode.SelectedValue.Trim
            If chkDc.Checked = True Then
                drDB("Dc") = "Y"
            Else
                drDB("Dc") = "N"
            End If
            If currentUserID.Trim() = "" Then
                currentUserID = "pubuser"
            End If
            drDB("Create_User") = Nothing
            drDB("Create_Time") = Nothing
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")

            dsbodySiteDB.Tables(bodySiteDB).Rows.Add(drDB)

            '執行修改
            iCount = objOph.updatePUBBodySite(dsbodySiteDB)
            initialCmbMainBodySiteCode()
            Me.cmbMainBodySiteCode.SelectedValue = drDB("Main_Body_Site_Code")
            If iCount > 0 Then

                '將DB資料塞入Grid中
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0)
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("部位代碼")}
                If dtGrid.Rows.Contains(Me.txtBodySiteCode.Text.Trim) Then
                    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(Me.txtBodySiteCode.Text.Trim)
                    'dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    drGrid("部位代碼") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Body_Site_Code").ToString.Trim()
                    drGrid("部位名稱") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Body_Site_Name").ToString.Trim()
                    'drGrid("部位大分類") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Main_Body_Site_Code").ToString.Trim()
                    If Me.cmbMainBodySiteCode.SelectedValue.ToString.Trim() = "" Then
                        drGrid("部位大分類") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Body_Site_Code").ToString.Trim()
                    Else
                        drGrid("部位大分類") = Me.cmbMainBodySiteCode.SelectedValue.ToString.Trim()
                    End If

                    'drGrid("健保申報部位代碼") = Me.cmbNhiBodySiteCode.SelectedValue.ToString.Trim()
                    'drGrid("健保申報部位名稱") = Me.cmbNhiBodySiteCode.SelectedItem(1).ToString().Trim()
                    If dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Dc").ToString() = "N" Then
                        drGrid("停用") = "否"
                    Else
                        drGrid("停用") = "是"
                    End If
                    drGrid("建立者") = drGrid2("建立者")
                    drGrid("建立時間") = drGrid2("建立時間")
                    drGrid("修改者") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Modified_User").ToString.Trim()
                    drGrid("修改時間") = dsbodySiteDB.Tables(bodySiteDB).Rows(0)("Modified_Time")
                    dsGrid.Tables(bodySiteDB).Rows.Add(drGrid)
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
            iCount = objOph.deletePUBBodySiteByPK(Me.txtBodySiteCode.Text.ToString.Trim)
            initialCmbMainBodySiteCode()
            If iCount > 0 Then
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0)
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("部位代碼")}
                If dtGrid.Rows.Contains(Me.txtBodySiteCode.Text.Trim) Then
                    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(Me.txtBodySiteCode.Text.Trim)
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
    ''' <remarks>True 失敗;False 成功</remarks>
    Private Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean
        Try
            Dim blnReturnFlag As Boolean = False
            Dim strErrMsg1 As StringBuilder = New StringBuilder
            '設定需要檢查的欄位
            Dim ctlTxtBodySiteCode As Control = Me.txtBodySiteCode
            Dim ctlTxtBodySiteName As Control = Me.txtBodySiteName
            Dim ctlTxtMainBodySiteCode As Control = Me.cmbMainBodySiteCode
            Dim ctlObjFocus As Control = ctlTxtBodySiteCode
            '清除欄位背景色
            cleanFieldsColor()
            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not fieldCheckNull(ctlTxtBodySiteCode, Control_Type.TextBox) Then
                        strErrMsg1.Append("部位代碼")
                        ctlObjFocus = ctlTxtBodySiteCode
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtBodySiteName, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("部位名稱")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtBodySiteName
                        End If
                        blnReturnFlag = True
                    End If
                    'If Not fieldCheckNull(ctlTxtMainBodySiteCode, Control_Type.ComboBox) Then
                    '    If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                    '    strErrMsg1.Append("部位大分類")
                    '    If blnReturnFlag = False Then
                    '        ctlObjFocus = ctlTxtMainBodySiteCode
                    '    End If
                    '    blnReturnFlag = True
                    'End If
                Case buttonAction.DELETE
                    If Not fieldCheckNull(ctlTxtBodySiteCode, Control_Type.TextBox) Then
                        strErrMsg1.Append("部位代碼")
                        ctlObjFocus = ctlTxtBodySiteCode
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
            Case Control_Type.TextBox
                If ctl.Text.Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.ComboBox
                Dim objCtl As Syscom.Client.UCL.UCLComboBoxUC = ctl
                If objCtl.SelectedValue.Trim.Equals("") Then
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
        ' CType(dgvShowData.DataSource, DataTable).Clear()
        dgvShowData.ClearDS()
        dgvShowData.Refresh()
    End Sub

    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.txtBodySiteCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtBodySiteName.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'Me.cmbMainBodySiteCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
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
            Me.txtBodySiteCode.Text = ""
            Me.txtBodySiteName.Text = ""
            Me.cmbNhiBodySiteCode.SelectedValue = ""
            Me.cmbMainBodySiteCode.Text = ""
            Me.chkDc.Checked = False
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
                Me.txtBodySiteCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("部位代碼").Value.ToString.Trim
                Me.txtBodySiteName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("部位名稱").Value.ToString.Trim
                'Me.cmbNhiBodySiteCode.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("健保申報部位代碼").Value.ToString.Trim()
                Me.cmbMainBodySiteCode.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("部位大分類").Value.ToString.Trim
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停用").Value.ToString.Trim = "是" Then
                    Me.chkDc.Checked = True
                Else
                    Me.chkDc.Checked = False
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
                dgvShowData.GetGridDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
                dgvShowData.GetDBDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
            Case buttonAction.UPDATE
                dgvShowData.CurrentRow.SetValues(ds.Tables(bodySiteDB).Rows(0).ItemArray)
        End Select

    End Sub

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
                '{"部位代碼", "部位名稱", "部位大分類", "健保申報部位代碼", "健保申報部位名稱", "停用", "建立者", "建立時間", "修改者", "修改時間"}

                Return New String(,) {{"部位代碼", "部位代碼", "Y", "N", ""}, _
                                      {"部位名稱", "部位名稱", "Y", "N", ""}, _
                                      {"部位大分類", "部位大分類", "Y", "N", ""}, _
                                      {"停用", "停用", "Y", "N", ""}, _
                                      {"建立者", "建立者", "N", "N", ""}, _
                                      {"建立時間", "建立時間", "Y", "N", ""}, _
                                      {"修改者", "修改者", "Y", "N", ""}, _
                                      {"修改時間", "修改時間", "Y", "N", ""}}

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
End Class
