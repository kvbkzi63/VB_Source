'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBPhaServicesUI.vb
'*              Title:	藥事服務費基本檔維護
'*        Description:	藥事服務費基本檔維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Max
'*        Create Date:	2009/07/16
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
Public Class PUBPhaServicesUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

    
    Dim objPub As IPubServiceManager = Nothing
    '目前使用者的ID
    'Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

    '宣告EventManager
    Private mgr As EventManager = EventManager.getInstance   '宣告EventManager
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance

    '獲取維護表名
    Dim tableDB As String = PubPhaServicesDataTableFactory.tableName
    'Grid使用的標題
    Dim columnNameGrid() As String = {"主身份", "院內科別", "藥事服務費類別", "批價碼", "停用", "建立者", "建立時間", "修改者", "修改時間", "主身份ID", "院內科ID", "藥事服務費類別ID", "批價碼ID"}
    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {9, 10, 11, 12} '從0開始()
    '獲取維護表字段名
    Dim columnNameDB() As String = PubPhaServicesDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubPhaServicesDataTableFactory.columnsLength
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        ComboBox
        TextBox
        TextCodeQuery
    End Enum

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
    ''' 初始化畫面 構建空的Grid 設定欄位長度
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance
            '構建空的Grid
            'Mark By Will dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(tableDB)
            showResult(dgvShowData, genDataSet("dgvShowData"))
            '將DataGridView的欄位隱藏
            For i As Integer = 0 To visibleColumnNo.Count - 1
                dgvShowData.Columns(visibleColumnNo(i)).Visible = False
            Next
            '設定Grid滿屏
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            initialCmbPhraseTypeId()

        Catch ex As Exception
            Throw ex
        End Try
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
                '{"主身份", "院內科別", "藥事服務費類別", "批價碼", "停用", "建立者", "建立時間", "修改者", "修改時間", "主身份ID", "院內科ID", "藥事服務費類別ID", "批價碼ID"}
                Return New String(,) {{"主身份", "主身份", "Y", "N", ""}, _
                                      {"院內科別", "院內科別", "Y", "N", ""}, _
                                      {"藥事服務費類別", "藥事服務費類別", "Y", "N", ""}, _
                                      {"批價碼", "批價碼", "Y", "N", ""}, _
                                      {"停用", "停用", "Y", "N", ""}, _
                                      {"建立者", "建立者", "Y", "N", ""}, _
                                      {"建立時間", "建立時間", "Y", "N", ""}, _
                                      {"修改者", "修改者", "Y", "N", ""}, _
                                      {"修改時間", "修改時間", "Y", "N", ""}, _
                                      {"主身份ID", "主身份ID", "N", "N", ""}, _
                                      {"院內科ID", "院內科ID", "N", "N", ""}, _
                                      {"藥事服務費類別ID", "藥事服務費類別ID", "N", "N", ""}, _
                                      {"批價碼ID", "批價碼ID", "N", "N", ""}}

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
        Dim strMainIdentityId As String = Me.cmbMainIdentityId.SelectedValue
        Dim strDeptCode As String = Me.txtDeptCode.uclCodeValue1
        Dim strPhaServicesTypeId As String = Me.cmbPhaServicesTypeId.SelectedValue
        Dim strOrderCode As String = Me.txtOrderCode.uclCodeValue1
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        '執行查詢
        dsDB = objPub.queryPUBPhaServicesByCond(strMainIdentityId, strDeptCode, strPhaServicesTypeId, strOrderCode)

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    Dim drGrid(dsDB.Tables(tableDB).Rows.Count - 1) As DataRow
                    '將查出的資料塞入Grid中
                    For i As Integer = 0 To dsDB.Tables(tableDB).Rows.Count - 1
                        '"主身份", "院內科別", "藥事服務費類別", "批價碼", "停用", "建立者", "建立時間", "修改者", "修改時間", "主身份ID", "院內科ID", "藥事服務費類別ID", "批價碼ID"
                        drGrid(i) = dsGrid.Tables(tableDB).NewRow()
                        drGrid(i)("主身份") = dsDB.Tables(tableDB).Rows(i)("Main_Identity_Id_Value").ToString.Trim()
                        If dsDB.Tables(tableDB).Rows(i)("Dept_Code_Value").ToString.Trim() <> "" Then
                            drGrid(i)("院內科別") = dsDB.Tables(tableDB).Rows(i)("Dept_Code").ToString.Trim() & " - " & _
                            dsDB.Tables(tableDB).Rows(i)("Dept_Code_Value").ToString.Trim()
                        Else
                            drGrid(i)("院內科別") = dsDB.Tables(tableDB).Rows(i)("Dept_Code").ToString.Trim()
                        End If
                        drGrid(i)("藥事服務費類別") = dsDB.Tables(tableDB).Rows(i)("Pha_Services_Type_Id_Value").ToString.Trim()
                        If dsDB.Tables(tableDB).Rows(i)("Order_Code_Value").ToString.Trim() <> "" Then
                            drGrid(i)("批價碼") = dsDB.Tables(tableDB).Rows(i)("Order_Code").ToString.Trim() & " - " & _
                            dsDB.Tables(tableDB).Rows(i)("Order_Code_Value").ToString.Trim()
                        Else
                            drGrid(i)("批價碼") = dsDB.Tables(tableDB).Rows(i)("Order_Code").ToString.Trim()
                        End If
                        If dsDB.Tables(tableDB).Rows(i)("DC").ToString() = "N" Then
                            drGrid(i)("停用") = "否"
                        Else
                            drGrid(i)("停用") = "是"
                        End If
                        drGrid(i)("建立者") = dsDB.Tables(tableDB).Rows(i)("Create_User").ToString.Trim()
                        drGrid(i)("建立時間") = dsDB.Tables(tableDB).Rows(i)("Create_Time")
                        drGrid(i)("修改者") = dsDB.Tables(tableDB).Rows(i)("Modified_User").ToString.Trim()
                        If dsDB.Tables(tableDB).Rows(i)("Modified_Time").ToString <> "" Then
                            drGrid(i)("修改時間") = dsDB.Tables(tableDB).Rows(i)("Modified_Time")
                        End If
                        drGrid(i)("主身份ID") = dsDB.Tables(tableDB).Rows(i)("Main_Identity_Id").ToString.Trim()
                        drGrid(i)("院內科ID") = dsDB.Tables(tableDB).Rows(i)("Dept_Code").ToString.Trim()
                        drGrid(i)("藥事服務費類別ID") = dsDB.Tables(tableDB).Rows(i)("Pha_Services_Type_Id").ToString.Trim()
                        drGrid(i)("批價碼ID") = dsDB.Tables(tableDB).Rows(i)("Order_Code").ToString.Trim()
                        dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
                    Next
                    '資料邦定到Grid
                    'Mark By Will dgvShowData.DataSource = dsGrid.Tables(tableDB)
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
            drDB("Main_Identity_Id") = Me.cmbMainIdentityId.SelectedValue
            drDB("Dept_Code") = Me.txtDeptCode.uclCodeValue1
            drDB("Pha_Services_Type_Id") = Me.cmbPhaServicesTypeId.SelectedValue
            drDB("Order_Code") = Me.txtOrderCode.uclCodeValue1
            If chkDc.Checked = True Then
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

            '執行新增
            iCount = objPub.insertPUBPhaServices(dsDB)

            If iCount > 0 Then
                '將DB資料塞入Grid中
                '"主身份", "院內科別", "藥事服務費類別", "批價碼", "停用", "建立者", "建立時間", "修改者", "修改時間", "主身份ID", "院內科ID", "藥事服務費類別ID", "批價碼ID"
                drGrid("主身份") = Me.cmbMainIdentityId.SelectedItem(1).ToString.Trim
                drGrid("院內科別") = Me.txtDeptCode.Text.ToString.Trim
                drGrid("藥事服務費類別") = Me.cmbPhaServicesTypeId.SelectedItem(1).ToString.Trim
                drGrid("批價碼") = Me.txtOrderCode.Text.ToString.Trim
                If dsDB.Tables(tableDB).Rows(0)("DC").ToString() = "N" Then
                    drGrid("停用") = "否"
                Else
                    drGrid("停用") = "是"
                End If
                drGrid("主身份ID") = dsDB.Tables(tableDB).Rows(0)("Main_Identity_Id").ToString.Trim()
                drGrid("院內科ID") = dsDB.Tables(tableDB).Rows(0)("Dept_Code").ToString.Trim()
                drGrid("藥事服務費類別ID") = dsDB.Tables(tableDB).Rows(0)("Pha_Services_Type_Id").ToString.Trim()
                drGrid("批價碼ID") = dsDB.Tables(tableDB).Rows(0)("Order_Code").ToString.Trim()
                drGrid("建立者") = dsDB.Tables(tableDB).Rows(0)("Create_User").ToString.Trim()
                drGrid("建立時間") = DateUtil.TransDateToROC(dsDB.Tables(tableDB).Rows(0)("Create_Time")) & " " & Now.ToString("HH:mm:ss")
                drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                drGrid("修改時間") = DateUtil.TransDateToROC(dsDB.Tables(tableDB).Rows(0)("Modified_Time")) & " " & Now.ToString("HH:mm:ss")
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
            drDB("Main_Identity_Id") = Me.cmbMainIdentityId.SelectedValue
            drDB("Dept_Code") = Me.txtDeptCode.uclCodeValue1
            drDB("Pha_Services_Type_Id") = Me.cmbPhaServicesTypeId.SelectedValue
            drDB("Order_Code") = Me.txtOrderCode.uclCodeValue1
            If chkDc.Checked = True Then
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
            iCount = objPub.updatePUBPhaServices(dsDB)

            Dim strMainIdentityId As String = Me.cmbMainIdentityId.SelectedValue
            Dim strDeptCode As String = Me.txtDeptCode.uclCodeValue1
            Dim strPhaServicesTypeId As String = Me.cmbPhaServicesTypeId.SelectedValue

            If iCount > 0 Then
                '將DB資料塞入Grid中

                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0).Copy

                '"主身份", "院內科別", "藥事服務費類別", "批價碼", "停用", "建立者", "建立時間", "修改者", "修改時間", "主身份ID", "院內科ID", "藥事服務費類別ID", "批價碼ID"
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("主身份ID"), dtGrid.Columns("院內科ID"), dtGrid.Columns("藥事服務費類別ID")}
                If dtGrid.Rows.Contains(New Object() {strMainIdentityId, strDeptCode, strPhaServicesTypeId}) Then
                    'Mark By Will CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {strMainIdentityId, strDeptCode, strPhaServicesTypeId})
                    'Mark By Will dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    'Mark By Will ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)

                    drGrid("主身份") = Me.cmbMainIdentityId.SelectedItem(1).ToString.Trim
                    drGrid("院內科別") = Me.txtDeptCode.Text.ToString.Trim
                    drGrid("藥事服務費類別") = Me.cmbPhaServicesTypeId.SelectedItem(1).ToString.Trim
                    drGrid("批價碼") = Me.txtOrderCode.Text.ToString.Trim
                    If dsDB.Tables(tableDB).Rows(0)("DC").ToString() = "N" Then
                        drGrid("停用") = "否"
                    Else
                        drGrid("停用") = "是"
                    End If
                    drGrid("主身份ID") = dsDB.Tables(tableDB).Rows(0)("Main_Identity_Id").ToString.Trim()
                    drGrid("院內科ID") = dsDB.Tables(tableDB).Rows(0)("Dept_Code").ToString.Trim()
                    drGrid("藥事服務費類別ID") = dsDB.Tables(tableDB).Rows(0)("Pha_Services_Type_Id").ToString.Trim()
                    drGrid("批價碼ID") = dsDB.Tables(tableDB).Rows(0)("Order_Code").ToString.Trim()

                    drGrid("建立者") = drGrid2("建立者")
                    drGrid("建立時間") = drGrid2("建立時間")
                    drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                    drGrid("修改時間") = DateUtil.TransDateToROC(dsDB.Tables(tableDB).Rows(0)("Modified_Time")) & " " & Now.ToString("HH:mm:ss")
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
        Dim strMainIdentityId As String = Me.cmbMainIdentityId.SelectedValue
        Dim strDeptCode As String = Me.txtDeptCode.uclCodeValue1
        Dim strPhaServicesTypeId As String = Me.cmbPhaServicesTypeId.SelectedValue
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        Try
            Dim iCount As Integer = 0

            '執行刪除
            iCount = objPub.deletePUBPhaServicesByPK(strMainIdentityId, strDeptCode, strPhaServicesTypeId)

            If iCount > 0 Then

                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0).Copy

                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("主身份ID"), dtGrid.Columns("院內科ID"), dtGrid.Columns("藥事服務費類別ID")}
                If dtGrid.Rows.Contains(New Object() {strMainIdentityId, strDeptCode, strPhaServicesTypeId}) Then
                    'Mark By Will CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {strMainIdentityId, strDeptCode, strPhaServicesTypeId})
                    'Mark By Will dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    'Mark By Will ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)

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
            Dim strErrMsg2 As StringBuilder = New StringBuilder
            ''設定需要檢查的欄位
            Dim ctlCmbSexId As Control = Me.cmbMainIdentityId
            Dim ctlPhaServicesTypeId As Control = Me.cmbPhaServicesTypeId
            Dim ctltxtOrderCode As Control = Me.txtOrderCode
            Dim ctlObjFocus As Control = ctlCmbSexId
            '清除欄位背景色
            cleanFieldsColor()
            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not fieldCheckNull(ctlCmbSexId, Control_Type.ComboBox) Then
                        strErrMsg1.Append("主身份")
                        ctlObjFocus = ctlCmbSexId
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlPhaServicesTypeId, Control_Type.ComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("藥事服務費類別")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlPhaServicesTypeId
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctltxtOrderCode, Control_Type.TextCodeQuery) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("批價碼")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctltxtOrderCode
                        End If
                        blnReturnFlag = True
                    End If
                Case buttonAction.DELETE
                    If Not fieldCheckNull(ctlCmbSexId, Control_Type.ComboBox) Then
                        strErrMsg1.Append("主身份")
                        ctlObjFocus = ctlCmbSexId
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlPhaServicesTypeId, Control_Type.ComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("藥事服務費類別")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlPhaServicesTypeId
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
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB102", New String() {"迄日", "生效起日"})
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
                If objCtl.SelectedValue.ToString.Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.TextCodeQuery
                If CType(ctl, UCLTextCodeQueryUI).uclCodeValue1.Trim.Equals("") Then
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
        dgvShowData.ClearDS()
        dgvShowData.Refresh()
    End Sub

    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.cmbPhaServicesTypeId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbMainIdentityId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtDeptCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtOrderCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
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
            Me.txtDeptCode.Text = ""
            Me.txtOrderCode.Text = ""
            Me.txtDeptCode.uclCodeValue1 = ""
            Me.txtOrderCode.uclCodeValue1 = ""
            Me.cmbMainIdentityId.SelectedValue = ""
            Me.cmbPhaServicesTypeId.SelectedValue = ""
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
                '"主身份", "院內科別", "藥事服務費類別", "批價碼", "停用", "建立者", "建立時間", "修改者", "修改時間", "主身份ID", "院內科ID", "藥事服務費類別ID", "批價碼ID"
                Me.txtDeptCode.uclCodeValue1 = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內科ID").Value.ToString.Trim
                If Split(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內科別").Value.ToString.Trim(), " - ").Length > 1 Then
                    Me.txtDeptCode.uclCodeName = Split(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內科別").Value.ToString.Trim(), " - ")(1).Trim
                End If
                Me.txtDeptCode.doFlag = False
                Me.txtDeptCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內科別").Value.ToString.Trim
                Me.txtOrderCode.uclCodeValue1 = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("批價碼ID").Value.ToString.Trim
                If Split(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("批價碼").Value.ToString.Trim(), " - ").Length > 1 Then
                    Me.txtOrderCode.uclCodeName = Split(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("批價碼").Value.ToString.Trim(), " - ")(1).Trim
                End If
                Me.txtOrderCode.doFlag = False
                Me.txtOrderCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("批價碼").Value.ToString.Trim
                Me.cmbMainIdentityId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("主身份ID").Value.ToString.Trim
                Me.cmbPhaServicesTypeId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("藥事服務費類別ID").Value.ToString.Trim
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
                'CType(dgvShowData.DataSource, System.Data.DataTable).Rows.Add(ds.Tables(strTableDB).Rows(0).ItemArray)

                dgvShowData.GetGridDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
                dgvShowData.GetDBDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
            Case buttonAction.UPDATE
                dgvShowData.CurrentRow.SetValues(ds.Tables(tableDB).Rows(0).ItemArray)
        End Select
    End Sub

    ''' <summary>
    ''' 初始化片語種類
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbPhraseTypeId()
        Dim dsDB1 As DataSet
        Dim dsDB2 As DataSet
        Try
            '執行查詢
            dsDB1 = objPub.queryPUBSysCode("18")
            dsDB2 = objPub.queryPUBSysCode("507")
            If dsDB1.Tables.Count > 0 Then
                If dsDB1.Tables(0).Rows.Count > 0 Then
                    Me.cmbMainIdentityId.DataSource = dsDB1.Tables(0)
                    Me.cmbMainIdentityId.uclValueIndex = "0"
                    Me.cmbMainIdentityId.uclDisplayIndex = "0,1"
                End If
            End If
            If dsDB2.Tables.Count > 0 Then
                If dsDB2.Tables(0).Rows.Count > 0 Then
                    Me.cmbPhaServicesTypeId.DataSource = dsDB2.Tables(0)
                    Me.cmbPhaServicesTypeId.uclValueIndex = "0"
                    Me.cmbPhaServicesTypeId.uclDisplayIndex = "0,1"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbMainIdentityId_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMainIdentityId.Leave
        If Me.cmbMainIdentityId.SelectedValue.Trim <> "" Then
            Me.cmbMainIdentityId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        End If
    End Sub

    Private Sub cmbPhaServicesTypeId_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPhaServicesTypeId.Leave
        If Me.cmbPhaServicesTypeId.SelectedValue.Trim <> "" Then
            Me.cmbPhaServicesTypeId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        End If
    End Sub


End Class
