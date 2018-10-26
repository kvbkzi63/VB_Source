'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBRegisterFeeUI.vb
'*              Title:	掛號費基本檔維護
'*        Description:	掛號費基本檔維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	chen yang 
'*        Create Date:	2009/08/20
'*      Last Modifier:	2010/02/03
'*   Last Modify Date:	Merry
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
Public Class PUBRegisterFeeUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

    

    Dim objPub As IPubServiceManager = Nothing
    '目前使用者的ID
    'Dim currentUserID As String = AppContext.userProfile.userId
    ' Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

    '宣告EventManager
    Private mgr As EventManager = EventManager.getInstance   '宣告EventManager
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance

    '獲取維護表名
    Dim tableDB As String = PubRegisterFeeDataTableFactory.tableName
    'Grid使用的標題
    Dim columnNameGrid() As String = {"門/急診", "身份二代碼", "初診", "院內科別", "診別", "看診目的", "醫令項目代碼", _
                                      "停用", "建立者", "建立時間", "修改者", "修改時間", _
                                      "身份二代碼ID", "院內科別代碼ID", "看診目的代碼ID", "醫令項目代碼ID", "診別ID", "初診ID", _
                                      "院內科別Name", "醫令項目Name"}
    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {11, 12, 13, 14, 15, 16} '從0開始()
    '獲取維護表字段名
    Dim columnNameDB() As String = PubRegisterFeeDataTableFactory.columnsName

    '定義門急診別
    Dim glbSourceId As New DataSet
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
            'dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(tableDB)
            showResult(dgvShowData, genDataSet("dgvShowData"))

            '將DataGridView的欄位隱藏
            For i As Integer = 0 To visibleColumnNo.Count - 1
                dgvShowData.Columns(visibleColumnNo(i)).Visible = False
            Next
            '設定Grid滿屏
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            Me.initialCmbSubIdentityCode()

            Me.initialCmbMedicalTypeId()

            Me.initialCboSourceId()
            '初始化診別
            initialCmbSectionId()
            'Me.cmbSectionId.Enabled = False
            'Me.cmbSectionId.Text = ""
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

        Dim dsDB As New DataSet
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)

        Dim strSubIdentityCode As String = Me.cmbSubIdentityCode.SelectedValue
        Dim strDeptCode As String = Me.txtDeptCode.uclCodeValue1
        Dim strMedicalTypeId As String = Me.cmbMedicalTypeId.SelectedValue
        Dim strSectionId As String = Me.cmbSectionId.SelectedValue
        Dim strOrderCode As String = Me.txtOrderCode.uclCodeValue1
        Dim strFirstReg As String = ""
        If ckbFirstReg.Checked = True Then
            strFirstReg = "Y"
        End If
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        '執行查詢
        dsDB = objPub.queryPUBRegisterFeeByCond(cbo_SourceId.SelectedValue, strSubIdentityCode, strDeptCode, strMedicalTypeId, strOrderCode, strSectionId, strFirstReg)

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    bindDataGridView(dsDB, buttonAction.QUERY)
                End If
                Return blnReturnFlag
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 邦定DataGridView
    ''' </summary>
    ''' <param name="ds">更新數據集</param>
    ''' <param name="iButtonFlag">Button標記</param>
    ''' <remarks></remarks>
    Private Sub bindDataGridView(ByVal ds As DataSet, ByVal iButtonFlag As Integer)
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        Dim drGrid(ds.Tables(tableDB).Rows.Count - 1) As DataRow

        '將查出的資料塞入Grid中
        For i As Integer = 0 To ds.Tables(tableDB).Rows.Count - 1

            '"身份二代碼", "院內科別", "診別","看診目的", "醫令項目代碼", "停用", "建立者", "建立時間", "修改者", "修改時間", "身份二代碼ID", "院內科別代碼ID", "看診目的代碼ID", "醫令項目代碼ID", "診別ID"
            drGrid(i) = dsGrid.Tables(tableDB).NewRow()
            If ds.Tables(tableDB).Rows(i)("Sub_Identity_Name").ToString.Trim() <> "" Then
                drGrid(i)("身份二代碼") = ds.Tables(tableDB).Rows(i)("Sub_Identity_Code").ToString.Trim() & " - " _
                & ds.Tables(tableDB).Rows(i)("Sub_Identity_Name").ToString.Trim()
            Else
                drGrid(i)("身份二代碼") = ds.Tables(tableDB).Rows(i)("Sub_Identity_Code").ToString.Trim()
            End If

            If ds.Tables(tableDB).Rows(i)("First_Reg").ToString.Trim() = "Y" Then
                drGrid(i)("初診") = "是"
            Else
                drGrid(i)("初診") = ""
            End If

            If ds.Tables(tableDB).Rows(i)("Dept_Code_Name").ToString.Trim() <> "" Then
                drGrid(i)("院內科別") = ds.Tables(tableDB).Rows(i)("Dept_Code").ToString.Trim() & " - " _
                & ds.Tables(tableDB).Rows(i)("Dept_Code_Name").ToString.Trim()
            Else
                drGrid(i)("院內科別") = ds.Tables(tableDB).Rows(i)("Dept_Code").ToString.Trim()
            End If

            If ds.Tables(tableDB).Rows(i)("Section_Id_Name").ToString.Trim() <> "" Then
                drGrid(i)("診別") = ds.Tables(tableDB).Rows(i)("Section_Id").ToString.Trim() & " - " _
                & ds.Tables(tableDB).Rows(i)("Section_Id_Name").ToString.Trim()
            Else
                drGrid(i)("診別") = ds.Tables(tableDB).Rows(i)("Section_Id").ToString.Trim()
            End If

            If ds.Tables(tableDB).Rows(i)("Medical_Type_Id_Name").ToString.Trim() <> "" Then
                drGrid(i)("看診目的") = ds.Tables(tableDB).Rows(i)("Medical_Type_Id").ToString.Trim() & " - " _
                & ds.Tables(tableDB).Rows(i)("Medical_Type_Id_Name").ToString.Trim()
            Else
                drGrid(i)("看診目的") = ds.Tables(tableDB).Rows(i)("Medical_Type_Id").ToString.Trim()
            End If

            If ds.Tables(tableDB).Rows(i)("Order_Code_Name").ToString.Trim() <> "" Then
                drGrid(i)("醫令項目代碼") = ds.Tables(tableDB).Rows(i)("Order_Code").ToString.Trim() & " - " _
                & ds.Tables(tableDB).Rows(i)("Order_Code_Name").ToString.Trim()
            Else
                drGrid(i)("醫令項目代碼") = ds.Tables(tableDB).Rows(i)("Order_Code").ToString.Trim()
            End If

            If ds.Tables(tableDB).Rows(i)("DC").ToString() = "N" Then
                drGrid(i)("停用") = "否"
            Else
                drGrid(i)("停用") = "是"
            End If
            drGrid(i)("建立者") = ds.Tables(tableDB).Rows(i)("Create_User").ToString.Trim()
            drGrid(i)("建立時間") = CDate(ds.Tables(tableDB).Rows(i)("Create_Time")).Year - 1911 & CDate(ds.Tables(tableDB).Rows(i)("Create_Time")).ToString("/MM/dd HH:mm:ss")
            drGrid(i)("修改者") = ds.Tables(tableDB).Rows(i)("Modified_User").ToString.Trim()
            If ds.Tables(tableDB).Rows(i)("Modified_Time").ToString <> "" Then
                drGrid(i)("修改時間") = CDate(ds.Tables(tableDB).Rows(i)("Modified_Time")).Year - 1911 & CDate(ds.Tables(tableDB).Rows(i)("Modified_Time")).ToString("/MM/dd HH:mm:ss")
            End If

            drGrid(i)("身份二代碼ID") = ds.Tables(tableDB).Rows(i)("Sub_Identity_Code").ToString.Trim()
            drGrid(i)("院內科別代碼ID") = ds.Tables(tableDB).Rows(i)("Dept_Code").ToString.Trim()
            drGrid(i)("看診目的代碼ID") = ds.Tables(tableDB).Rows(i)("Medical_Type_Id").ToString.Trim()
            drGrid(i)("醫令項目代碼ID") = ds.Tables(tableDB).Rows(i)("Order_Code").ToString.Trim()
            drGrid(i)("診別ID") = ds.Tables(tableDB).Rows(i)("Section_Id").ToString.Trim()

            drGrid(i)("院內科別Name") = ds.Tables(tableDB).Rows(i)("Dept_Code_Name").ToString.Trim()
            drGrid(i)("醫令項目Name") = ds.Tables(tableDB).Rows(i)("Order_Code_Name").ToString.Trim()


            drGrid(i)("初診ID") = ds.Tables(tableDB).Rows(i)("First_Reg").ToString.Trim()
            drGrid(i)("門/急診") = ds.Tables(tableDB).Rows(i)("Source_Id").ToString.Trim()

            dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
        Next
        '資料邦定到Grid
        'dgvShowData.DataSource = dsGrid.Tables(tableDB)
        showResult(dgvShowData, dsGrid)
    End Sub

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
            drDB("Source_Id") = Me.cbo_SourceId.SelectedValue
            drDB("Sub_Identity_Code") = Me.cmbSubIdentityCode.SelectedValue
            drDB("Dept_Code") = Me.txtDeptCode.uclCodeValue1
            drDB("Section_Id") = Me.cmbSectionId.SelectedValue
            drDB("Medical_Type_Id") = Me.cmbMedicalTypeId.SelectedValue
            drDB("Order_Code") = Me.txtOrderCode.uclCodeValue1
            If chkDc.Checked = True Then
                drDB("DC") = "Y"
            Else
                drDB("DC") = "N"
            End If
            If ckbFirstReg.Checked = True Then
                drDB("First_Reg") = "Y"
            Else
                drDB("First_Reg") = ""
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
            iCount = objPub.insertPUBRegisterFee(dsDB)

            If iCount > 0 Then
                '將DB資料塞入Grid中
                '"身份二代碼", "院內科別", "診別","看診目的", "醫令項目代碼", "停用", "建立者", "建立時間", "修改者", "修改時間", "身份二代碼ID", "院內科別代碼ID", "看診目的代碼ID", "醫令項目代碼ID", "診別ID"
                drGrid("身份二代碼") = Me.cmbSubIdentityCode.SelectedItem(0).ToString.Trim & "- " & Me.cmbSubIdentityCode.SelectedItem(1).ToString.Trim
                If dsDB.Tables(tableDB).Rows(0)("First_Reg").ToString.Trim() = "Y" Then
                    drGrid("初診") = "是"
                Else
                    drGrid("初診") = ""
                End If
                drGrid("院內科別") = Me.txtDeptCode.uclCodeName.ToString.Trim
                drGrid("院內科別Name") = Me.txtDeptCode.uclCodeValue1.ToString.Trim
                If Me.cmbSectionId.Text.ToString.Trim <> "" Then
                    drGrid("診別") = Me.cmbSectionId.SelectedItem(0).ToString.Trim & "- " & Me.cmbSectionId.SelectedItem(1).ToString.Trim
                End If
                If Me.cmbMedicalTypeId.Text.ToString.Trim <> "" Then
                    drGrid("看診目的") = Me.cmbMedicalTypeId.SelectedItem(0).ToString.Trim & "- " & Me.cmbMedicalTypeId.SelectedItem(1).ToString.Trim
                End If
                drGrid("醫令項目代碼") = Me.txtOrderCode.uclCodeName.ToString.Trim
                drGrid("醫令項目Name") = Me.txtOrderCode.uclCodeValue1.ToString.Trim
                If dsDB.Tables(tableDB).Rows(0)("DC").ToString() = "N" Then
                    drGrid("停用") = "否"
                Else
                    drGrid("停用") = "是"
                End If
                drGrid("建立者") = dsDB.Tables(tableDB).Rows(0)("Create_User").ToString.Trim()
                drGrid("建立時間") = dsDB.Tables(tableDB).Rows(0)("Create_Time")
                drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                drGrid("修改時間") = dsDB.Tables(tableDB).Rows(0)("Modified_Time")

                drGrid("身份二代碼ID") = dsDB.Tables(tableDB).Rows(0)("Sub_Identity_Code").ToString.Trim()
                drGrid("院內科別代碼ID") = dsDB.Tables(tableDB).Rows(0)("Dept_Code").ToString.Trim()
                drGrid("看診目的代碼ID") = dsDB.Tables(tableDB).Rows(0)("Medical_Type_Id").ToString.Trim()
                drGrid("醫令項目代碼ID") = dsDB.Tables(tableDB).Rows(0)("Order_Code").ToString.Trim()
                drGrid("診別ID") = dsDB.Tables(tableDB).Rows(0)("Section_Id").ToString.Trim()
                drGrid("初診ID") = dsDB.Tables(tableDB).Rows(0)("First_Reg").ToString.Trim()
                drGrid("門/急診") = dsDB.Tables(tableDB).Rows(0)("Source_Id").ToString.Trim()

                dsGrid.Tables(tableDB).Rows.Add(drGrid)

                '同步更新
                showResult(dgvShowData, dsGrid)
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
            drDB("Source_Id") = Me.cbo_SourceId.SelectedValue
            drDB("Sub_Identity_Code") = Me.cmbSubIdentityCode.SelectedValue
            drDB("Dept_Code") = Me.txtDeptCode.uclCodeValue1
            drDB("Section_Id") = Me.cmbSectionId.SelectedValue
            drDB("Medical_Type_Id") = Me.cmbMedicalTypeId.SelectedValue
            drDB("Order_Code") = Me.txtOrderCode.uclCodeValue1
            If chkDc.Checked = True Then
                drDB("DC") = "Y"
            Else
                drDB("DC") = "N"
            End If
            If ckbFirstReg.Checked = True Then
                drDB("First_Reg") = "Y"
            Else
                drDB("First_Reg") = ""
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
            iCount = objPub.updatePUBRegisterFee(dsDB)

            Dim strSubIdentityCode As String = Me.cmbSubIdentityCode.SelectedValue
            Dim strDeptCode As String = Me.txtDeptCode.uclCodeValue1
            Dim strMedicalTypeId As String = Me.cmbMedicalTypeId.SelectedValue
            Dim strSectionId As String = Me.cmbSectionId.SelectedValue
            Dim strFirstReg As String = ""
            If ckbFirstReg.Checked = True Then
                strFirstReg = "Y"
            End If
            If iCount > 0 Then
                '將DB資料塞入Grid中

                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0).Copy

                '"身份二代碼", "院內科別", "診別","看診目的", "醫令項目代碼", "停用", "建立者", "建立時間", "修改者", "修改時間", "身份二代碼ID", "院內科別代碼ID", "看診目的代碼ID", "醫令項目代碼ID", "診別ID"
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("身份二代碼ID"), dtGrid.Columns("院內科別代碼ID"), dtGrid.Columns("診別ID"), dtGrid.Columns("看診目的代碼ID"), dtGrid.Columns("初診ID")}
                If dtGrid.Rows.Contains(New Object() {strSubIdentityCode, strDeptCode, strSectionId, strMedicalTypeId, strFirstReg}) Then
                    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {strSubIdentityCode, strDeptCode, strSectionId, strMedicalTypeId, strFirstReg})
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    'dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    ' ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    drGrid("身份二代碼") = Me.cmbSubIdentityCode.SelectedItem(0).ToString.Trim & " - " & Me.cmbSubIdentityCode.SelectedItem(1).ToString.Trim
                    If dsDB.Tables(tableDB).Rows(0)("First_Reg").ToString.Trim() = "Y" Then
                        drGrid("初診") = "是"
                    Else
                        drGrid("初診") = ""
                    End If
                    drGrid("院內科別") = Me.txtDeptCode.uclCodeName.ToString.Trim
                    drGrid("院內科別Name") = Me.txtDeptCode.uclCodeValue1.ToString.Trim
                    If Me.cmbMedicalTypeId.Text.ToString.Trim <> "" Then
                        drGrid("看診目的") = Me.cmbMedicalTypeId.SelectedItem(0).ToString.Trim & " - " & Me.cmbMedicalTypeId.SelectedItem(1).ToString.Trim
                    End If
                    If Me.cmbSectionId.Text.ToString.Trim <> "" Then
                        drGrid("診別") = Me.cmbSectionId.SelectedItem(0).ToString.Trim & " - " & Me.cmbSectionId.SelectedItem(1).ToString.Trim
                    End If
                    drGrid("醫令項目代碼") = Me.txtOrderCode.uclCodeName.ToString.Trim
                    drGrid("醫令項目Name") = Me.txtOrderCode.uclCodeValue1.ToString.Trim
                    If dsDB.Tables(tableDB).Rows(0)("DC").ToString() = "N" Then
                        drGrid("停用") = "否"
                    Else
                        drGrid("停用") = "是"
                    End If
                    drGrid("建立者") = drGrid2("建立者")
                    drGrid("建立時間") = drGrid2("建立時間")
                    drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                    drGrid("修改時間") = dsDB.Tables(tableDB).Rows(0)("Modified_Time")

                    drGrid("身份二代碼ID") = dsDB.Tables(tableDB).Rows(0)("Sub_Identity_Code").ToString.Trim()
                    drGrid("院內科別代碼ID") = dsDB.Tables(tableDB).Rows(0)("Dept_Code").ToString.Trim()
                    drGrid("看診目的代碼ID") = dsDB.Tables(tableDB).Rows(0)("Medical_Type_Id").ToString.Trim()
                    drGrid("醫令項目代碼ID") = dsDB.Tables(tableDB).Rows(0)("Order_Code").ToString.Trim()
                    drGrid("診別ID") = dsDB.Tables(tableDB).Rows(0)("Section_Id").ToString.Trim()
                    drGrid("初診ID") = dsDB.Tables(tableDB).Rows(0)("First_Reg").ToString.Trim()
                    drGrid("門/急診") = dsDB.Tables(tableDB).Rows(0)("Source_Id").ToString.Trim()

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

        Dim strSubIdentityCode As String = Me.cmbSubIdentityCode.SelectedValue
        Dim strDeptCode As String = Me.txtDeptCode.uclCodeValue1
        Dim strMedicalTypeId As String = Me.cmbMedicalTypeId.SelectedValue
        Dim strSectionId As String = Me.cmbSectionId.SelectedValue
        Dim strFirstReg As String = ""
        If ckbFirstReg.Checked = True Then
            strFirstReg = "Y"
        End If
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            Dim iCount As Integer = 0

            '執行刪除
            iCount = objPub.deletePUBRegisterFeeByPK(cbo_SourceId.SelectedValue, strSubIdentityCode, strFirstReg, strDeptCode, strSectionId, strMedicalTypeId)

            If iCount > 0 Then

                'Dim dtGrid As DataTable = dgvShowData.DataSource
                'dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("身份二代碼ID"), dtGrid.Columns("院內科別代碼ID"), dtGrid.Columns("看診目的代碼ID"), dtGrid.Columns("診別ID"), dtGrid.Columns("初診ID")}
                'If dtGrid.Rows.Contains(New Object() {strSubIdentityCode, strDeptCode, strMedicalTypeId, strSectionId, strFirstReg}) Then
                '    CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                '    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {strSubIdentityCode, strDeptCode, strMedicalTypeId, strSectionId, strFirstReg})
                '    ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                '    ' dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                '    '定位行
                '    ' ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)

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

            '設定需要檢查的欄位
            Dim ctlTxtDeptCode As Control = txtDeptCode
            Dim ctlTxtOrderCode As Control = txtOrderCode
            Dim ctlCmbSubIdentityCode As Control = cmbSubIdentityCode
            Dim ctlCmbMedicalTypeId As Control = cmbMedicalTypeId
            Dim ctlCmbSectionId As Control = cmbMedicalTypeId
            Dim ctlObjFocus As Control = ctlCmbSubIdentityCode

            '清除欄位背景色
            cleanFieldsColor()

            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not fieldCheckNull(ctlCmbSubIdentityCode, Control_Type.ComboBox) Then
                        strErrMsg1.Append("身份二代碼")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlCmbSubIdentityCode
                        End If
                        blnReturnFlag = True
                    End If

                    If Me.txtDeptCode.Text.Trim.Equals("") Then
                        If Not Me.cmbSectionId.SelectedValue.Trim.Equals("") Then
                            ctlTxtDeptCode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            strErrMsg2.Append("若要輸入診別，需先輸入院內科別代碼！")
                            If blnReturnFlag = False Then
                                ctlObjFocus = ctlTxtDeptCode
                            End If
                            blnReturnFlag = True
                        End If
                    End If

                    If Not fieldCheckNull(ctlTxtOrderCode, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("醫令項目代碼")
                        ctlObjFocus = ctlTxtOrderCode
                        blnReturnFlag = True
                    End If
                Case buttonAction.DELETE
                    If Not fieldCheckNull(ctlCmbSubIdentityCode, Control_Type.ComboBox) Then
                        strErrMsg1.Append("身份二代碼")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlCmbSubIdentityCode
                        End If
                        blnReturnFlag = True
                    End If

                    If Me.txtDeptCode.Text.Trim.Equals("") Then
                        If Not Me.cmbSectionId.SelectedValue.Trim.Equals("") Then
                            ctlTxtDeptCode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            strErrMsg2.Append("若要輸入診別，需先輸入院內科別代碼！")
                            If blnReturnFlag = False Then
                                ctlObjFocus = ctlTxtDeptCode
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
                If strErrMsg2.Length > 0 Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = strErrMsg2.ToString
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
            Me.txtDeptCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtOrderCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbSubIdentityCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbMedicalTypeId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbSectionId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
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
            Me.cmbSubIdentityCode.SelectedValue = ""
            Me.cmbMedicalTypeId.SelectedValue = ""
            Me.cmbSectionId.SelectedValue = ""
            Me.chkDc.Checked = False
            Me.ckbFirstReg.Checked = False
            Me.cbo_SourceId.SelectedValue = ""
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

                Me.cmbSubIdentityCode.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("身份二代碼ID").Value.ToString.Trim
                Me.cmbMedicalTypeId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("看診目的代碼ID").Value.ToString.Trim
                Me.cmbSectionId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("診別ID").Value.ToString.Trim
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內科別").Value.ToString.Trim <> "" Then
                    Me.txtDeptCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內科別代碼ID").Value.ToString.Trim & " - " & dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內科別").Value.ToString.Trim
                    'Me.cmbSectionId.Enabled = True
                Else
                    Me.txtDeptCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內科別代碼ID").Value.ToString.Trim
                    'Me.cmbSectionId.Enabled = False
                    Me.cmbSectionId.Text = ""
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("醫令項目代碼").Value.ToString.Trim <> "" Then
                    Me.txtOrderCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("醫令項目代碼ID").Value.ToString.Trim & " - " & dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("醫令項目代碼").Value.ToString.Trim
                Else
                    Me.txtOrderCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("醫令項目代碼ID").Value.ToString.Trim
                End If
                Me.txtDeptCode.uclCodeValue1 = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內科別代碼ID").Value.ToString.Trim
                Me.txtOrderCode.uclCodeValue1 = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("醫令項目代碼ID").Value.ToString.Trim
                Me.txtDeptCode.uclCodeName = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內科別Name").Value.ToString.Trim
                Me.txtOrderCode.uclCodeName = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("醫令項目Name").Value.ToString.Trim
                Me.txtDeptCode.Text = Me.txtDeptCode.uclCodeValue1 & " - " & Me.txtDeptCode.uclCodeName
                Me.txtOrderCode.Text = Me.txtOrderCode.uclCodeValue1 & " - " & Me.txtOrderCode.uclCodeName
                Me.cbo_SourceId.SelectedValue = dgvShowData.GetDBDS.Tables(0).Rows(dgvShowData.CurrentCellAddress.Y).Item("門/急診").ToString.Trim
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停用").Value.ToString.Trim = "是" Then
                    Me.chkDc.Checked = True
                Else
                    Me.chkDc.Checked = False
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("初診ID").Value.ToString.Trim = "Y" Then
                    Me.ckbFirstReg.Checked = True
                Else
                    Me.ckbFirstReg.Checked = False
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
            Case buttonAction.UPDATE
                dgvShowData.CurrentRow.SetValues(ds.Tables(tableDB).Rows(0).ItemArray)
        End Select
    End Sub

    ''' <summary>
    ''' 初始化身份二代碼
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbSubIdentityCode()
        Dim dsDB As DataSet
        '執行查詢()
        dsDB = objPub.queryPUBSubIdentityByCV((New String() {"DC"}), New Object() {"N"})

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count = 0 Then
                    ''查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                Else
                    Me.cmbSubIdentityCode.DataSource = dsDB.Tables(0)
                    Me.cmbSubIdentityCode.uclValueIndex = "0"
                    Me.cmbSubIdentityCode.uclDisplayIndex = "0,1"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化看診目的
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbMedicalTypeId()
        Dim dsDB As DataSet

        '執行查詢()
        'dsDB = objPub.queryPUBSysCode("20") rubbed by Xiaozhi 2016-05-19
        dsDB = objPub.queryPUBSubMedicalType
        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count = 0 Then
                    ''查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                Else
                    Me.cmbMedicalTypeId.DataSource = dsDB.Tables(0)
                    Me.cmbMedicalTypeId.uclValueIndex = "0"
                    Me.cmbMedicalTypeId.uclDisplayIndex = "0,1"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化診別
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbSectionId()
        Dim dsDB As DataSet

        '執行查詢
        dsDB = objPub.queryPUBSysCode("11")

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count = 0 Then
                    ''查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                Else
                    Me.cmbSectionId.DataSource = dsDB.Tables(0)
                    Me.cmbSectionId.uclValueIndex = "0"
                    Me.cmbSectionId.uclDisplayIndex = "0,1"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化SourceId選項
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCboSourceId()
        Dim SourceDS As New DataSet
        Dim SourceDT As New DataTable
        SourceDT.Columns.Add("SourceId", GetType(String))
        SourceDT.Columns.Add("SourceName", GetType(String))
        SourceDT.Rows.Add(New Object() {"O", "門診"})
        SourceDT.Rows.Add(New Object() {"E", "急診"})

        SourceDS.Tables.Add(SourceDT.Copy)
        glbSourceId.Tables.Add(SourceDT.Copy)
        Try
            Me.cbo_SourceId.DataSource = SourceDS.Tables(0).Copy
            Me.cbo_SourceId.uclValueIndex = "0"
            Me.cbo_SourceId.uclDisplayIndex = "0,1"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 院內科別代碼的離開事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtDeptCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeptCode.Leave
        If Me.txtDeptCode.Text.Trim.Equals("") Then
            Me.cmbSectionId.SelectedValue = ""
        End If
    End Sub

    Private Sub txtDeptCode_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeptCode.Enter
        If Me.txtDeptCode.Text.Trim.Equals("") Then
            Me.cmbSectionId.SelectedValue = ""
        End If
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
                '{"身份二代碼", "初診", "院內科別", "診別", "看診目的", "醫令項目代碼", _
                ' "停用", "建立者", "建立時間", "修改者", "修改時間", _
                ' "身份二代碼ID", "院內科別代碼ID", "看診目的代碼ID", "醫令項目代碼ID", "診別ID", "初診ID", _
                ' "院內科別Name", "醫令項目Name"}
                Return New String(,) {{"門/急診", "門/急診", "Y", "N", ""}, _
                                      {"身份二代碼", "身份二代碼", "Y", "N", ""}, _
                                      {"初診", "初診", "Y", "N", ""}, _
                                      {"院內科別", "院內科別", "Y", "N", ""}, _
                                      {"診別", "DB診別", "Y", "N", ""}, _
                                      {"看診目的", "看診目的", "Y", "N", ""}, _
                                      {"醫令項目代碼", "醫令項目代碼", "Y", "N", ""}, _
                                      {"停用", "停用", "Y", "N", ""}, _
                                      {"建立者", "建立者", "Y", "N", ""}, _
                                      {"建立時間", "建立時間", "Y", "N", ""}, _
                                      {"修改者", "修改者", "Y", "N", ""}, _
                                      {"修改時間", "修改時間", "Y", "N", ""}, _
                                      {"身份二代碼ID", "身份二代碼ID", "Y", "N", ""}, _
                                      {"院內科別代碼ID", "院內科別代碼ID", "Y", "N", ""}, _
                                      {"看診目的代碼ID", "看診目的代碼ID", "Y", "N", ""}, _
                                      {"醫令項目代碼ID", "醫令項目代碼ID", "Y", "N", ""}, _
                                      {"診別ID", "診別ID", "Y", "N", ""}, _
                                      {"初診ID", "初診ID", "Y", "N", ""}, _
                                      {"院內科別Name", "院內科別Name", "Y", "N", ""}, _
                                      {"醫令項目Name", "醫令項目Name", "Y", "N", ""}}

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

            '手動處理Grid欄位的加入
            Select Case dgv.Name
                Case "dgvShowData"
                    '插入執行者欄位已供User點選
                    Dim SourceIdCell As New ComboBoxCell
                    '填入【治療類別】
                    SourceIdCell.Ds = glbSourceId.Copy
                    SourceIdCell.DisplayIndex = "0,1"
                    SourceIdCell.ValueIndex = "0"
                    hashTable.Add(0, SourceIdCell)
            End Select
            hashTable.Add(-1, ds)
            dgv.uclNonVisibleColIndex = Visible
            dgv.uclHeaderText = headerTxtStr
            dgv.uclNonVisibleColIndex = Visible
            dgv.Initial(hashTable)
            dgv.SetColReadOnly(0, True)

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
