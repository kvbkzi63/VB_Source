
'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBAccountUI.vb
'*              Title:	費用項目對應檔維護
'*        Description:	費用項目對應檔維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	tony
'*        Create Date:	2009/07/27
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
Public Class PUBAccountUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI


    Dim objPub As IPubServiceManager = Nothing
    '目前使用者的ID
    'Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

    '獲取維護表名
    Dim tableDB As String = PubAccountDataTableFactory.tableName
    Dim pubSyscodeTableName As String = PubSyscodeDataTableFactory.tableName
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
    Dim columnNameGrid() As String = {"院內費用項目代碼", "收據費用項目代碼", "健保費用項目代碼", "會計費用項目代碼1", "會計費用項目代碼2", "停用", "建立者", "建立時間", "修改者", "修改時間", "院內費用項目代碼DB", "收據費用項目代碼DB", "健保費用項目代碼DB", "會計費用項目代碼1DB", "會計費用項目代碼2DB"}
    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {10, 11, 12, 13, 14}
    '獲取維護表字段名
    Dim columnNameDB() As String = PubAccountDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubAccountDataTableFactory.columnsLength
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        ComboBox
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
                '{"院內費用項目代碼", "收據費用項目代碼", "健保費用項目代碼", "會計費用項目代碼1", "會計費用項目代碼2", "停用", "建立者", "建立時間", "修改者", "修改時間", 
                ' "院內費用項目代碼DB", "收據費用項目代碼DB", "健保費用項目代碼DB", "會計費用項目代碼1DB", "會計費用項目代碼2DB"}

                Return New String(,) {{"院內費用項目代碼", "院內費用項目代碼", "Y", "N", ""}, _
                                      {"收據費用項目代碼", "收據費用項目代碼", "Y", "N", ""}, _
                                      {"健保費用項目代碼", "健保費用項目代碼", "Y", "N", ""}, _
                                      {"會計費用項目代碼1", "會計費用項目代碼1", "Y", "N", ""}, _
                                      {"會計費用項目代碼2", "會計費用項目代碼2", "Y", "N", ""}, _
                                      {"停用", "停用", "Y", "N", ""}, _
                                      {"建立者", "建立者", "N", "N", ""}, _
                                      {"建立時間", "建立時間", "Y", "N", ""}, _
                                      {"修改者", "修改者", "Y", "N", ""}, _
                                      {"修改時間", "修改時間", "Y", "N", ""}, _
                                      {"院內費用項目代碼DB", "院內費用項目代碼DB", "N", "N", ""}, _
                                      {"收據費用項目代碼DB", "收據費用項目代碼DB", "N", "N", ""}, _
                                      {"健保費用項目代碼DB", "健保費用項目代碼DB", "N", "N", ""}, _
                                      {"會計費用項目代碼1DB", "會計費用項目代碼1DB", "N", "N", ""}, _
                                      {"會計費用項目代碼2DB", "會計費用項目代碼2DB", "N", "N", ""}}

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
            '設定grid的隱藏欄位
            For i As Integer = 0 To visibleColumnNo.Count - 1
                dgvShowData.Columns(visibleColumnNo(i)).Visible = False
            Next

            '初始化院內費用項目代碼combo
            initialComboBox(iAccountId)
            '初始化收據費用項目代碼combo
            initialComboBox(iReceiptAccountId)
            '初始化健保費用項目代碼combo
            initialComboBox(iInsuAccountId)
            '初始化會計費用項目代碼1
            initialComboBox(iAcc1AccountId)
            '初始化會計費用項目代碼2
            initialComboBox(iAcc2AccountId)
            Me.ckbDc.Checked = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub initialComboBox(ByRef itypeId As Integer)

        Dim dsDB As DataSet
        '執行查詢
        Dim objPub As IPubServiceManager = PubServiceManager.getInstance
        Select Case itypeId
            Case iAccountId
                dsDB = objPub.queryPUBSysCode_L(iAccountId)

                Try
                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(pubSyscodeTableName).Rows.Count = 0 Then
                            '查無資料
                            'MessageHandling.showWarnByKey("CMMCMMB000")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                        Else
                            '院內費用項目代碼combo塞值
                            Me.cmbAccountId.DataSource = dsDB.Tables(pubSyscodeTableName)
                            Me.cmbAccountId.uclDisplayIndex = "0,1"
                            Me.cmbAccountId.uclValueIndex = "0"
                        End If
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            Case iReceiptAccountId
                dsDB = objPub.queryPUBSysCode_L(iReceiptAccountId)

                Try
                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(pubSyscodeTableName).Rows.Count = 0 Then
                            '查無資料
                            'MessageHandling.showWarnByKey("CMMCMMB000")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                        Else
                            '收據費用項目代碼combo塞值
                            Me.cmbReceiptAccountId.DataSource = dsDB.Tables(pubSyscodeTableName)
                            Me.cmbReceiptAccountId.uclDisplayIndex = "0,1"
                            Me.cmbReceiptAccountId.uclValueIndex = "0"
                        End If
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            Case iInsuAccountId
                dsDB = objPub.queryPUBSysCode_L(iInsuAccountId)

                Try
                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(pubSyscodeTableName).Rows.Count = 0 Then
                            '查無資料
                            'MessageHandling.showWarnByKey("CMMCMMB000")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                        Else
                            '健保費用項目代碼combo塞值
                            Me.cmbInsuAccountId.DataSource = dsDB.Tables(pubSyscodeTableName)
                            Me.cmbInsuAccountId.uclDisplayIndex = "0,1"
                            Me.cmbInsuAccountId.uclValueIndex = "0"
                        End If
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            Case iAcc1AccountId
                dsDB = objPub.queryPUBSysCode_L(iAcc1AccountId)
                Try
                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(pubSyscodeTableName).Rows.Count = 0 Then
                            '查無資料
                            'MessageHandling.showWarnByKey("CMMCMMB000")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                        Else
                            '會計費用項目代碼1combo塞值
                            Me.cmbAcc1AccountId.DataSource = dsDB.Tables(pubSyscodeTableName)
                            Me.cmbAcc1AccountId.uclDisplayIndex = "0,1"
                            Me.cmbAcc1AccountId.uclValueIndex = "0"
                        End If
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            Case iAcc2AccountId
                dsDB = objPub.queryPUBSysCode_L(iAcc2AccountId)

                Try
                    If dsDB.Tables.Count > 0 Then
                        If dsDB.Tables(pubSyscodeTableName).Rows.Count = 0 Then
                            '查無資料
                            'MessageHandling.showWarnByKey("CMMCMMB000")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                        Else
                            '會計費用項目代碼2combo塞值
                            Me.cmbAcc2AccountId.DataSource = dsDB.Tables(pubSyscodeTableName)
                            Me.cmbAcc2AccountId.uclDisplayIndex = "0,1"
                            Me.cmbAcc2AccountId.uclValueIndex = "0"
                        End If
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
        End Select
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
        Dim strAccountId As String = Me.cmbAccountId.SelectedValue.Trim

        '欄位檢查
        cleanFieldsColor()
        '執行查詢
        dsDB = objPub.queryPUBAccountByCond(strAccountId)
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
                        drGrid(i)("院內費用項目代碼DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Account_Id"))
                        drGrid(i)("院內費用項目代碼") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Account_Name"))
                        drGrid(i)("收據費用項目代碼DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Receipt_Account_Id"))
                        drGrid(i)("收據費用項目代碼") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Receipt_Account_Name"))
                        drGrid(i)("健保費用項目代碼DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Insu_Account_Id"))
                        drGrid(i)("健保費用項目代碼") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Insu_Account_Name"))
                        drGrid(i)("會計費用項目代碼1DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Acc1_Account_Id"))
                        drGrid(i)("會計費用項目代碼1") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Acc1_Account_Name"))
                        drGrid(i)("會計費用項目代碼2DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Acc2_Account_Id"))
                        drGrid(i)("會計費用項目代碼2") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Acc2_Account_Name"))
                        strTemp = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Dc"))
                        If strTemp = "N" Then
                            drGrid(i)("停用") = "否"
                        Else
                            drGrid(i)("停用") = "是"
                        End If
                        drGrid(i)("建立者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_User"))
                        'Modify By Elly 2016/07/13 --start
                        'drGrid(i)("建立時間") = CDate(StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_Time"))).ToString("yyyy/MM/dd HH:mm:ss")
                        drGrid(i)("建立時間") = DateUtil.TransDateToROC(dsDB.Tables(tableDB).Rows(i)("Create_Time")).ToString.Trim
                        '--end
                        drGrid(i)("修改者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Modified_User"))
                        strTemp = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Modified_Time"))
                        If strTemp <> "" Then
                            'Modify By Elly 2016/07/13 --start
                            'drGrid(i)("修改時間") = CDate(strTemp).ToString("yyyy/MM/dd HH:mm:ss")
                            drGrid(i)("修改時間") = DateUtil.TransDateToROC(dsDB.Tables(tableDB).Rows(i)("Modified_Time")).ToString.Trim
                            '--end
                        End If
                        dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
                    Next
                    '資料邦定到Grid
                    'Mark By Will dgvShowData.DataSource = dsGrid.Tables(tableDB)
                    'Modify By Elly 2016/07/13 --start
                    '     showResult(dgvShowData, genDataSet("dgvShowData"))
                    dgvShowData.DataSource = dsGrid
                    '--end
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
        'If fieldCheckResult(iButtonFlag) Then
        '    Return False
        'End If
        Try
            Dim iCount As Integer = 0
            Dim dsDB As DataSet = genDS(DataSet_Type.DB)
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
            Dim drGrid As DataRow = dsGrid.Tables(tableDB).NewRow()
            Dim drDB As DataRow = dsDB.Tables(tableDB).NewRow()
            '將輸入區資料塞入DB中
            drDB("Account_Id") = Me.cmbAccountId.SelectedValue.ToString.Trim
            drDB("Receipt_Account_Id") = Me.cmbReceiptAccountId.SelectedValue.ToString.Trim
            drDB("Insu_Account_Id") = Me.cmbInsuAccountId.SelectedValue.ToString.Trim
            drDB("Acc1_Account_Id") = Me.cmbAcc1AccountId.SelectedValue.ToString.Trim
            drDB("Acc2_Account_Id") = Me.cmbAcc2AccountId.SelectedValue.ToString.Trim
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
            drDB("BIL_Seqno") = Nothing
            dsDB.Tables(tableDB).Rows.Add(drDB)
            '執行新增 將查出的資料塞入Grid中 
            iCount = objPub.insertPUBAccount(dsDB)
            If iCount > 0 Then
                drGrid("院內費用項目代碼DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Account_Id"))
                If Me.cmbAccountId.Text.ToString.Trim <> "" Then
                    drGrid("院內費用項目代碼") = Me.cmbAccountId.SelectedItem(1).ToString.Trim
                Else
                    drGrid("院內費用項目代碼") = ""
                End If
                drGrid("收據費用項目代碼DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Receipt_Account_Id"))
                If Me.cmbReceiptAccountId.Text.ToString.Trim <> "" Then
                    drGrid("收據費用項目代碼") = Me.cmbReceiptAccountId.SelectedItem(1).ToString.Trim
                Else
                    drGrid("收據費用項目代碼") = ""
                End If
                drGrid("健保費用項目代碼DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Insu_Account_Id"))
                If Me.cmbInsuAccountId.Text.ToString.Trim <> "" Then
                    drGrid("健保費用項目代碼") = Me.cmbInsuAccountId.SelectedItem(1).ToString.Trim
                Else
                    drGrid("健保費用項目代碼") = ""
                End If
                drGrid("會計費用項目代碼1DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Acc1_Account_Id"))
                If Me.cmbAcc1AccountId.Text.ToString.Trim <> "" Then
                    drGrid("會計費用項目代碼1") = Me.cmbAcc1AccountId.SelectedItem(1).ToString.Trim
                Else
                    drGrid("會計費用項目代碼1") = ""
                End If
                drGrid("會計費用項目代碼2DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Acc2_Account_Id"))
                If Me.cmbAcc2AccountId.Text.ToString.Trim <> "" Then
                    drGrid("會計費用項目代碼2") = Me.cmbAcc2AccountId.SelectedItem(1).ToString.Trim
                Else
                    drGrid("會計費用項目代碼2") = ""
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
        'If fieldCheckResult(iButtonFlag) Then
        '    Return False
        'End If
        Try
            Dim iCount As Integer = 0
            Dim dsDB As DataSet = genDS(DataSet_Type.DB)
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
            Dim drGrid As DataRow = dsGrid.Tables(tableDB).NewRow()
            Dim drDB As DataRow = dsDB.Tables(tableDB).NewRow()
            '將輸入區資料塞入DB中
            drDB("Account_Id") = Me.cmbAccountId.SelectedValue.Trim
            drDB("Receipt_Account_Id") = Me.cmbReceiptAccountId.SelectedValue.Trim
            drDB("Insu_Account_Id") = Me.cmbInsuAccountId.SelectedValue.Trim
            drDB("Acc1_Account_Id") = Me.cmbAcc1AccountId.SelectedValue.Trim
            drDB("Acc2_Account_Id") = Me.cmbAcc2AccountId.SelectedValue.Trim
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
            drDB("BIL_Seqno") = Nothing 'DBNull.Value

            dsDB.Tables(tableDB).Rows.Add(drDB)
            '執行修改
            iCount = objPub.updatePUBAccount(dsDB)
            If iCount > 0 Then
                '將DB資料塞入Grid中 "院內費用項目代碼", "收據費用項目代碼", "健保費用項目代碼", "會計費用項目代碼1", "會計費用項目代碼2", "停用", "建立者", "建立時間", "修改者", "修改時間", "院內費用項目代碼DB", "收據費用項目代碼DB", "健保費用項目代碼DB", "會計費用項目代碼1DB", "會計費用項目代碼2DB"
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0).Copy
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("院內費用項目代碼DB")}
                If dtGrid.Rows.Contains(New Object() {Me.cmbAccountId.SelectedValue.ToString.Trim}) Then
                    'Mark By Will CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.cmbAccountId.SelectedValue.Trim})
                    'Mark By Will dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    'Mark By Will  ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    'Mark By Will ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    drGrid("院內費用項目代碼DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Account_Id"))
                    If Me.cmbAccountId.Text.ToString.Trim <> "" Then
                        drGrid("院內費用項目代碼") = Me.cmbAccountId.SelectedItem(1).ToString.Trim
                    Else
                        drGrid("院內費用項目代碼") = ""
                    End If
                    drGrid("收據費用項目代碼DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Receipt_Account_Id"))
                    If Me.cmbReceiptAccountId.Text.ToString.Trim <> "" Then
                        drGrid("收據費用項目代碼") = Me.cmbReceiptAccountId.SelectedItem(1).ToString.Trim
                    Else
                        drGrid("收據費用項目代碼") = ""
                    End If
                    drGrid("健保費用項目代碼DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Insu_Account_Id"))
                    If Me.cmbInsuAccountId.Text.ToString.Trim <> "" Then
                        drGrid("健保費用項目代碼") = Me.cmbInsuAccountId.SelectedItem(1).ToString.Trim
                    Else
                        drGrid("健保費用項目代碼") = ""
                    End If
                    drGrid("會計費用項目代碼1DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Acc1_Account_Id"))
                    If Me.cmbAcc1AccountId.Text.ToString.Trim <> "" Then
                        drGrid("會計費用項目代碼1") = Me.cmbAcc1AccountId.SelectedItem(1).ToString.Trim
                    Else
                        drGrid("會計費用項目代碼1") = ""
                    End If
                    drGrid("會計費用項目代碼2DB") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(0)("Acc2_Account_Id"))
                    If Me.cmbAcc2AccountId.Text.ToString.Trim <> "" Then
                        drGrid("會計費用項目代碼2") = Me.cmbAcc2AccountId.SelectedItem(1).ToString.Trim
                    Else
                        drGrid("會計費用項目代碼2") = ""
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
        'If fieldCheckResult(iButtonFlag) Then
        '    Return False
        'End If
        Try
            Dim iCount As Integer = 0
            '執行刪除
            iCount = objPub.deletePUBAccountByPK(Me.cmbAccountId.SelectedValue.Trim)
            If iCount > 0 Then
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0).Copy
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("院內費用項目代碼DB")}
                If dtGrid.Rows.Contains(New Object() {Me.cmbAccountId.SelectedValue.ToString.Trim}) Then
                    'Mark By Will CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.cmbAccountId.SelectedValue.ToString.Trim})
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
            Dim ctlCmbAccountId As Control = Me.cmbAccountId
            Dim ctlCmbReceiptAccountId As Control = Me.cmbReceiptAccountId
            Dim ctlCmbAcc1AccountId As Control = Me.cmbAcc1AccountId
            Dim ctlCmbAcc2AccountId As Control = Me.cmbAcc2AccountId
            Dim ctlObjFocus As Control = ctlCmbAccountId
            '清除欄位背景色
            cleanFieldsColor()
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not fieldCheckNull(ctlCmbAccountId, Control_Type.ComboBox) Then
                        strErrMsg1.Append("院內費用項目代碼")
                        ctlObjFocus = ctlCmbAccountId
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlCmbReceiptAccountId, Control_Type.ComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("收據費用項目代碼")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlCmbReceiptAccountId
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlCmbAcc1AccountId, Control_Type.ComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("會計費用項目代碼1")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlCmbAcc1AccountId
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlCmbAcc2AccountId, Control_Type.ComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("會計費用項目代碼2")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlCmbAcc2AccountId
                        End If
                        blnReturnFlag = True
                    End If

                Case buttonAction.DELETE
                    If Not fieldCheckNull(ctlCmbAccountId, Control_Type.ComboBox) Then
                        strErrMsg1.Append("院內費用項目代碼")
                        ctlObjFocus = ctlCmbAccountId
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
        'Mark By WillCType(dgvShowData.DataSource, DataTable).Clear()
        dgvShowData.ClearDS()
        dgvShowData.Refresh()
    End Sub
    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.cmbAccountId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbReceiptAccountId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbAcc1AccountId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbAcc2AccountId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
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
            Me.cmbAccountId.SelectedValue = ""
            Me.cmbReceiptAccountId.SelectedValue = ""
            Me.cmbInsuAccountId.SelectedValue = ""
            Me.cmbAcc1AccountId.SelectedValue = ""
            Me.cmbAcc2AccountId.SelectedValue = ""
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
                Me.cmbAccountId.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內費用項目代碼DB").Value)
                Me.cmbReceiptAccountId.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("收據費用項目代碼DB").Value)
                Me.cmbInsuAccountId.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("健保費用項目代碼DB").Value)
                Me.cmbAcc1AccountId.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("會計費用項目代碼1DB").Value)
                Me.cmbAcc2AccountId.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("會計費用項目代碼2DB").Value)
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
                'Mark By Will CType(dgvShowData.DataSource, System.Data.DataTable).Rows.Add(ds.Tables(tableDB).Rows(0).ItemArray)
                dgvShowData.GetGridDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
                dgvShowData.GetDBDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
            Case buttonAction.UPDATE
                dgvShowData.CurrentRow.SetValues(ds.Tables(tableDB).Rows(0).ItemArray)
        End Select
    End Sub
End Class
