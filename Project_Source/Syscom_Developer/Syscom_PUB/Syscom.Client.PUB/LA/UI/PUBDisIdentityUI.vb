'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBDisIdentityUI.vb
'*              Title:	優待身份基本檔維護
'*        Description:	優待身份基本檔維護介面
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	liuye
'*        Create Date:	2009/07/23
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
Public Class PUBDisIdentityUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI


    Dim objPub As IPubServiceManager = Nothing

    '目前使用者的ID
    'Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)
    '獲取維護表名
    Dim tableDB As String = PubDisIdentityDataTableFactory.tableName
    'Grid使用的標題
    Dim columnNameGrid() As String = {"優待身份", "優待身份名稱", "優待類別", "優待類別DB", "是否開放線上選擇優免類別", "停用", "建立者", "建立時間", "修改者", "修改時間"}
    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {2, 3, 4} '從0開始()

    '獲取維護表字段名
    Dim columnNameDB() As String = PubDisIdentityDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubDisIdentityDataTableFactory.columnsLength
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
            '設定Grid滿屏
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            '將DataGridView的欄位隱藏()
            For i As Integer = 0 To visibleColumnNo.Count - 1
                dgvShowData.Columns(visibleColumnNo(i)).Visible = False
            Next
            '設定欄位長度
            Me.txtDisIdentityCode.MaxLength = columnsLength(0)
            Me.txtDisIdentityName.MaxLength = columnsLength(1)

            '初始化優待類別
            'initialcmbDisIdentityTypeId() //rubbed out by xiaozhi modify SDSPEC-206-10-43 2016-05-18
            '初始化是否開放線上選擇優免
            'chkIsOnlineChoice.Checked = False //rubbed out by xiaozhi modify SDSPEC-206-10-43 2016-05-18
            '初始化停用 
            chkDc.Checked = False
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
                '{"優待身份", "優待身份名稱", "優待類別", "優待類別DB", "是否開放線上選擇優免類別", "停用", "建立者", "建立時間", "修改者", "修改時間"}
                Return New String(,) {{"優待身份", "優待身份", "Y", "N", ""}, _
                                      {"優待身份名稱", "優待身份名稱", "Y", "N", ""}, _
                                      {"優待類別", "優待類別", "Y", "N", ""}, _
                                      {"優待類別DB", "優待類別DB", "N", "N", ""}, _
                                      {"是否開放線上選擇優免類別", "是否開放線上選擇優免類別", "Y", "N", ""}, _
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

    ''' <summary>
    ''' 初始化優待類別
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialcmbDisIdentityTypeId()
        Dim dsDB As DataSet

        '執行查詢
        dsDB = objPub.queryPUBSysCodeByCV((New String() {"Type_ID", "Dc"}), New Object() {"49", "N"})
        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else

                    cmbDisIdentityTypeId.DataSource = dsDB.Tables(0).Copy
                    cmbDisIdentityTypeId.uclDisplayIndex = "0,1"
                    cmbDisIdentityTypeId.uclValueIndex = "0"
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

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        '依條件查詢
        dsDB = objPub.queryPUBDisIdentityByCond(txtDisIdentityCode.Text.Trim.Replace("'", "''"))

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
                        drGrid(i) = dsGrid.Tables(tableDB).NewRow()
                        drGrid(i)("優待身份") = dsDB.Tables(tableDB).Rows(i)("Dis_Identity_Code").ToString.Trim()
                        drGrid(i)("優待身份名稱") = dsDB.Tables(tableDB).Rows(i)("Dis_Identity_Name").ToString.Trim()
                        drGrid(i)("優待類別") = dsDB.Tables(tableDB).Rows(i)("Dis_Identity_Type_Name").ToString.Trim()
                        drGrid(i)("優待類別DB") = dsDB.Tables(tableDB).Rows(i)("Dis_Identity_Type_Id").ToString.Trim()

                        If dsDB.Tables(tableDB).Rows(i)("Is_Online_Choice").ToString() = "N" Then
                            drGrid(i)("是否開放線上選擇優免類別") = "否"
                        Else
                            drGrid(i)("是否開放線上選擇優免類別") = "是"
                        End If
                        If dsDB.Tables(tableDB).Rows(i)("Dc").ToString() = "N" Then
                            drGrid(i)("停用") = "否"
                        Else
                            drGrid(i)("停用") = "是"
                        End If

                        drGrid(i)("建立者") = dsDB.Tables(tableDB).Rows(i)("Create_User").ToString.Trim()
                        drGrid(i)("建立時間") = DateUtil.TransDateToROC(CDate(dsDB.Tables(tableDB).Rows(i)("Create_Time")).ToString("yyyy/MM/dd")) & " " & CDate(dsDB.Tables(tableDB).Rows(i)("Create_Time")).ToString("HH:mm:ss")
                        drGrid(i)("修改者") = dsDB.Tables(tableDB).Rows(i)("Modified_User").ToString.Trim()
                        If dsDB.Tables(tableDB).Rows(i)("Modified_Time").ToString <> "" Then
                            drGrid(i)("修改時間") = DateUtil.TransDateToROC(CDate(dsDB.Tables(tableDB).Rows(i)("Modified_Time")).ToString("yyyy/MM/dd")) & " " & CDate(dsDB.Tables(tableDB).Rows(i)("Modified_Time")).ToString("HH:mm:ss")
                        End If
                        dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
                    Next
                    '資料邦定到Grid
                    'Mark By Will dgvShowData.DataSource = dsGrid.Tables(tableDB)
                    showResult(dgvShowData, dsGrid)
                    For i As Integer = 0 To visibleColumnNo.Count - 1
                        dgvShowData.Columns(visibleColumnNo(i)).Visible = False
                    Next
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
            drDB("Dis_Identity_Code") = Me.txtDisIdentityCode.Text.Trim
            drDB("Dis_Identity_Name") = Me.txtDisIdentityName.Text.Trim
            drDB("Dis_Identity_Type_Id") = "" 'modify by xiaozhi  SDSPEC-206-10-43 2016-05-18

            'rubbed out by xiaozhi modify SDSPEC-206-10-43 2016-05-18
            'If chkIsOnlineChoice.Checked = True Then
            '    drDB("Is_Online_Choice") = "Y"
            'Else
            '    drDB("Is_Online_Choice") = "N"
            'End If
            drDB("Is_Online_Choice") = "" 'modify by xiaozhi  SDSPEC-206-10-43 2016-05-18
            If chkDC.Checked = True Then
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
            dsDB.Tables(tableDB).Rows.Add(drDB)

            '執行新增
            iCount = objPub.insertPUBDisIdentity(dsDB)

            If iCount > 0 Then
                '將DB資料塞入Grid中
                drGrid("優待身份") = dsDB.Tables(tableDB).Rows(0)("Dis_Identity_Code").ToString.Trim()
                drGrid("優待身份名稱") = dsDB.Tables(tableDB).Rows(0)("Dis_Identity_Name").ToString.Trim()
                If Me.cmbDisIdentityTypeId.Text.ToString.Trim <> "" Then
                    drGrid("優待類別") = Me.cmbDisIdentityTypeId.SelectedItem(1).ToString.Trim
                End If
                drGrid("優待類別DB") = dsDB.Tables(tableDB).Rows(0)("Dis_Identity_Type_Id").ToString.Trim()
                If dsDB.Tables(tableDB).Rows(0)("Is_Online_Choice").ToString() = "N" Then
                    drGrid("是否開放線上選擇優免類別") = "否"
                Else
                    drGrid("是否開放線上選擇優免類別") = "是"
                End If
                If dsDB.Tables(tableDB).Rows(0)("Dc").ToString() = "N" Then
                    drGrid("停用") = "否"
                Else
                    drGrid("停用") = "是"
                End If
                drGrid("建立者") = dsDB.Tables(tableDB).Rows(0)("Create_User").ToString.Trim()
                drGrid("建立時間") = DateUtil.TransDateToROC(dsDB.Tables(tableDB).Rows(0)("Create_Time"))
                drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                drGrid("修改時間") = DateUtil.TransDateToROC(dsDB.Tables(tableDB).Rows(0)("Modified_Time"))
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
            iCount = objPub.deletePUBDisIdentityByPK(Me.txtDisIdentityCode.Text.Trim)

            If iCount > 0 Then
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0).Copy
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("優待身份")}
                'If dtGrid.Rows.Contains(Me.txtDisIdentityCode.Text.Trim) Then
                '    CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                '    Dim drGrid2 As DataRow = dtGrid.Rows.Find(Me.txtDisIdentityCode.Text.Trim)
                '    dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                '    '定位行
                '    ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                'End If
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
            drDB("Dis_Identity_Code") = Me.txtDisIdentityCode.Text.Trim
            drDB("Dis_Identity_Name") = Me.txtDisIdentityName.Text.Trim
            drDB("Dis_Identity_Type_Id") = "" 'modify by xiaozhi  SDSPEC-206-10-43 2016-05-18

            'rubbed out by xiaozhi modify SDSPEC-206-10-43 2016-05-18
            'If chkIsOnlineChoice.Checked = True Then
            '    drDB("Is_Online_Choice") = "Y"
            'Else
            '    drDB("Is_Online_Choice") = "N"
            'End If
            drDB("Is_Online_Choice") = "" 'modify by xiaozhi  SDSPEC-206-10-43 2016-05-18
            If chkDC.Checked = True Then
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
            dsDB.Tables(tableDB).Rows.Add(drDB)

            '執行修改
            iCount = objPub.updatePUBDisIdentity(dsDB)

            If iCount > 0 Then
                '將DB資料塞入Grid中
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0).Copy
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("優待身份")}
                If dtGrid.Rows.Contains(Me.txtDisIdentityCode.Text.Trim) Then
                    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(Me.txtDisIdentityCode.Text.Trim)
                    'dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    ''定位行
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    drGrid("優待身份") = dsDB.Tables(tableDB).Rows(0)("Dis_Identity_Code").ToString.Trim()
                    drGrid("優待身份名稱") = dsDB.Tables(tableDB).Rows(0)("Dis_Identity_Name").ToString.Trim()
                    If Me.cmbDisIdentityTypeId.Text.ToString.Trim <> "" Then
                        drGrid("優待類別") = Me.cmbDisIdentityTypeId.SelectedItem(1).ToString.Trim
                    End If
                    drGrid("優待類別DB") = dsDB.Tables(tableDB).Rows(0)("Dis_Identity_Type_Id").ToString.Trim()
                    If dsDB.Tables(tableDB).Rows(0)("Is_Online_Choice").ToString() = "N" Then
                        drGrid("是否開放線上選擇優免類別") = "否"
                    Else
                        drGrid("是否開放線上選擇優免類別") = "是"
                    End If
                    If dsDB.Tables(tableDB).Rows(0)("Dc").ToString() = "N" Then
                        drGrid("停用") = "否"
                    Else
                        drGrid("停用") = "是"
                    End If
                    drGrid("建立者") = drGrid2("建立者")
                    drGrid("建立時間") = drGrid2("建立時間")
                    drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                    drGrid("修改時間") = DateUtil.TransDateToROC(dsDB.Tables(tableDB).Rows(0)("Modified_Time"))
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
    ''' 欄位檢查
    ''' </summary>
    ''' <param name="iButtonFlag">BUTTON標記</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 失敗;False 成功</remarks>
    Private Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean
        Try
            Dim blnReturnFlag As Boolean = False
            Dim strErrMsg1 As StringBuilder = New StringBuilder
            'Dim strErrMsg2 As StringBuilder = New StringBuilder

            '設定需要檢查的欄位
            Dim ctltxtDisIdentityCode As Control = Me.txtDisIdentityCode
            Dim ctltxtDisIdentityName As Control = Me.txtDisIdentityName
            'Dim ctlcmbDisIdentityTypeId As Control = Me.cmbDisIdentityTypeId //rubbed out by xiaozhi modify SDSPEC-206-10-43 2016-05-18
            Dim ctlObjFocus As Control = ctltxtDisIdentityCode
            '清除欄位背景色
            cleanFieldsColor()
            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not fieldCheckNull(ctltxtDisIdentityCode, Control_Type.TextBox) Then
                        strErrMsg1.Append("優待身份")
                        ctlObjFocus = ctltxtDisIdentityCode
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctltxtDisIdentityName, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("優待身份名稱")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctltxtDisIdentityName
                        End If
                        blnReturnFlag = True
                    End If
                    'rubbed out by xiaozhi modify SDSPEC-206-10-43 2016-05-18
                    'If Not fieldCheckNull(ctlcmbDisIdentityTypeId, Control_Type.ComboBox) Then
                    '    If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                    '    strErrMsg1.Append("優待類別")
                    '    If blnReturnFlag = False Then
                    '        ctlObjFocus = ctlcmbDisIdentityTypeId
                    '    End If
                    '    blnReturnFlag = True
                    'End If

                Case buttonAction.DELETE
                    If Not fieldCheckNull(ctltxtDisIdentityCode, Control_Type.TextBox) Then
                        strErrMsg1.Append("優待身份")
                        ctlObjFocus = ctltxtDisIdentityCode
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
                'If (strErrMsg2.Length > 0) Then
                '    ReDim Preserve strMsgs(i)
                '    strMsgs(i) = ResourceUtil.getString("CMMCMMB102", New String() {strErrMsg2.ToString})
                '    i += 1
                'End If
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
                If objCtl.SelectedValue.Trim = "" Then
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
        '  CType(dgvShowData.DataSource, DataTable).Clear()
        dgvShowData.ClearDS()
        dgvShowData.Refresh()
    End Sub
    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.txtDisIdentityCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtDisIdentityName.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'Me.cmbDisIdentityTypeId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT //rubbed out by xiaozhi modify SDSPEC-206-10-43 2016-05-18
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
            Me.txtDisIdentityCode.Text = ""
            Me.txtDisIdentityName.Text = ""
            'Me.cmbDisIdentityTypeId.SelectedValue = "" //rubbed out by xiaozhi modify SDSPEC-206-10-43 2016-05-18
            'Me.chkIsOnlineChoice.Checked = False //rubbed out by xiaozhi modify SDSPEC-206-10-43 2016-05-18
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
                Me.txtDisIdentityCode.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("優待身份").Value)
                Me.txtDisIdentityName.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("優待身份名稱").Value)

                'Me.cmbDisIdentityTypeId.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("優待類別DB").Value) //rubbed out by xiaozhi modify SDSPEC-206-10-43 2016-05-18

                'rubbed out by xiaozhi modify SDSPEC-206-10-43 2016-05-18
                'If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("是否開放線上選擇優免類別").Value) = "是" Then
                '    Me.chkIsOnlineChoice.Checked = True
                'Else
                '    Me.chkIsOnlineChoice.Checked = False
                'End If
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停用").Value) = "是" Then
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
End Class

