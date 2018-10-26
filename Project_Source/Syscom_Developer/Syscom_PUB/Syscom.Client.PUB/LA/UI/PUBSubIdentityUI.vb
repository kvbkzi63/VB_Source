'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBSubIdentityUI.vb
'*              Title:	身份二代碼基本檔維護
'*        Description:	身份二代碼基本檔維護 新增,修改,刪除和查詢
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Merry_Jing
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
Public Class PUBSubIdentityUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

    Dim objPub As IPubServiceManager = Nothing

    '目前使用者的ID
    'Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

    '宣告EventManager
    Private mgr As EventManager = EventManager.getInstance   '宣告EventManager
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance

    '獲取維護表名
    '身份二代碼基本檔-PUB_Sub_Identity
    Dim strTableDB As String = PubSubIdentityDataTableFactory.tableName

    '獲取維護表字段名
    Dim strColumnNameDB() As String = PubSubIdentityDataTableFactory.columnsName

    '獲取維護表字段長度
    Dim iColumnsLength() As Integer = PubSubIdentityDataTableFactory.columnsLength

    'Grid使用的標題
    Dim columnNameGrid() As String = {"身份二代碼", "身份二名稱", "隸屬主身份", "隸屬主身份代碼", "是否可收據分單", "門診使用", "急診使用", "住診使用", "是否直接自動結清", "停用", "建立者", "建立時間", "修改者", "修改時間", "健檢使用"} ' Elly Add 健檢使用  2016/05/12

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
    ''' 初始化畫面 構建空的Grid 設定欄位長度
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance

            '顯示DataGridView的初始Table
            'dgvShowData.DataSource = genDS(DataSet_Type.Grid)
            showResult(dgvShowData, genDataSet("dgvShowData"))

            '設定Grid滿屏
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            '設定欄位長度
            Me.txtSubIdentityCode.MaxLength = iColumnsLength(0)
            Me.txtSubIdentityName.MaxLength = iColumnsLength(2)


            '初始化隸屬主身份
            Me.initialCmbMainIdentityId()


            '隱藏隸屬主身份代碼列
            dgvShowData.Columns(3).Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 產生一個DataSet並包含空的Table用於Grid更新或者DB操作
    ''' </summary>
    ''' <param name="type">資料集類型</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function genDS(ByVal type As Integer) As DataSet
        Dim dsTemp As New DataSet
        Select Case type
            Case DataSet_Type.Grid
                '給Grid用Table
                dsTemp.Tables.Add(strTableDB)
                For i As Integer = 0 To columnNameGrid.Length - 1
                    dsTemp.Tables(strTableDB).Columns.Add(columnNameGrid(i))
                Next
            Case DataSet_Type.DB
                '給DB用Table
                '身份二代碼基本檔-PUB_Sub_Identity
                dsTemp.Tables.Add(strTableDB)
                For i As Integer = 0 To strColumnNameDB.Length - 1
                    dsTemp.Tables(strTableDB).Columns.Add(strColumnNameDB(i))
                Next
        End Select
        Return dsTemp
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

        '輸入區欄位顏色初始化
        cleanFieldsColor()

        '執行查詢
        dsDB = objPub.queryPUBSubIdentityByCond(Me.txtSubIdentityCode.Text.Trim.Replace("'", "''"), Me.cmbMainIdentityId.SelectedValue.ToString.Trim)
        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(strTableDB).Rows.Count = 0 Then
                    '查無符合條件之資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    Dim drGrid(dsDB.Tables(strTableDB).Rows.Count - 1) As DataRow
                    '將查詢的數據插入到Grid表中並顯示在畫面上
                    For i As Integer = 0 To dsDB.Tables(strTableDB).Rows.Count - 1
                        drGrid(i) = dsGrid.Tables(strTableDB).NewRow()
                        drGrid(i)("身份二代碼") = dsDB.Tables(strTableDB).Rows(i)("Sub_Identity_Code").ToString.Trim()
                        drGrid(i)("身份二名稱") = dsDB.Tables(strTableDB).Rows(i)("Sub_Identity_Name").ToString.Trim()
                        drGrid(i)("隸屬主身份") = dsDB.Tables(strTableDB).Rows(i)("Main_Name").ToString.Trim()
                        drGrid(i)("隸屬主身份代碼") = dsDB.Tables(strTableDB).Rows(i)("Main_Identity_Id").ToString.Trim()
                        ''是否可收據分單
                        'If dsDB.Tables(strTableDB).Rows(i)("Is_Allow_Divide_Receipt").ToString() = "Y" Then
                        '    drGrid(i)("是否可收據分單") = "是"
                        'Else
                        '    drGrid(i)("是否可收據分單") = "否"
                        'End If

                        '"門診使用", "急診使用", "住診使用", "是否直接自動結清"
                        If dsDB.Tables(strTableDB).Rows(i)("Is_Opd").ToString() = "Y" Then
                            drGrid(i)("門診使用") = "是"
                        Else
                            drGrid(i)("門診使用") = "否"
                        End If
                        '
                        If dsDB.Tables(strTableDB).Rows(i)("Is_Emg").ToString() = "Y" Then
                            drGrid(i)("急診使用") = "是"
                        Else
                            drGrid(i)("急診使用") = "否"
                        End If
                        '
                        If dsDB.Tables(strTableDB).Rows(i)("Is_Ipd").ToString() = "Y" Then
                            drGrid(i)("住診使用") = "是"
                        Else
                            drGrid(i)("住診使用") = "否"
                        End If
                        '
                        If dsDB.Tables(strTableDB).Rows(i)("Is_Bill_Close").ToString() = "Y" Then
                            drGrid(i)("是否直接自動結清") = "是"
                        Else
                            drGrid(i)("是否直接自動結清") = "否"
                        End If

                        '停用
                        If dsDB.Tables(strTableDB).Rows(i)("Dc").ToString() = "Y" Then
                            drGrid(i)("停用") = "是"
                        Else
                            drGrid(i)("停用") = "否"
                        End If

                        '健檢使用 Elly Add 2016/05/12
                        If dsDB.Tables(strTableDB).Rows(i)("Is_Ohm").ToString() = "Y" Then
                            drGrid(i)("健檢使用") = "是"
                        Else
                            drGrid(i)("健檢使用") = "否"
                        End If


                        drGrid(i)("建立者") = dsDB.Tables(strTableDB).Rows(i)("Create_User").ToString.Trim()
                        If dsDB.Tables(strTableDB).Rows(i)("Create_Time").ToString <> "" Then
                            drGrid(i)("建立時間") = CDate(dsDB.Tables(strTableDB).Rows(i)("Create_Time")).Year - 1911 & CDate(dsDB.Tables(strTableDB).Rows(i)("Create_Time")).ToString("/MM/dd HH:mm:ss")
                        End If
                        drGrid(i)("修改者") = dsDB.Tables(strTableDB).Rows(i)("Modified_User").ToString.Trim()
                        If dsDB.Tables(strTableDB).Rows(i)("Modified_Time").ToString <> "" Then
                            drGrid(i)("修改時間") = CDate(dsDB.Tables(strTableDB).Rows(i)("Modified_Time")).Year - 1911 & CDate(dsDB.Tables(strTableDB).Rows(i)("Modified_Time")).ToString("/MM/dd HH:mm:ss")
                        End If
                        dsGrid.Tables(strTableDB).Rows.Add(drGrid(i))
                    Next
                    '將查詢到的資料綁定到Grid上

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

        '創建Grid更新用DataSet和DataRow
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        Dim drGrid As DataRow = dsGrid.Tables(strTableDB).NewRow()
        Dim iCount As Integer = 0

        '創建DB新增用DataSet和DataRow
        Dim dsDB As DataSet = genDS(DataSet_Type.DB)
        Dim drDB As DataRow = dsDB.Tables(strTableDB).NewRow()

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            '將輸入區資料添加到DB中
            drDB("Sub_Identity_Code") = Me.txtSubIdentityCode.Text.ToString.Trim
            drDB("Sub_Identity_Name") = Me.txtSubIdentityName.Text.ToString.Trim
            drDB("Main_Identity_Id") = Me.cmbMainIdentityId.SelectedValue.ToString.Trim
            ''是否可收據分單
            'If ckbIsAllowDivideReceipt.Checked = True Then
            '    drDB("Is_Allow_Divide_Receipt") = "Y"
            'Else
            '    drDB("Is_Allow_Divide_Receipt") = "N"
            'End If
            '"門診使用", "急診使用", "住診使用", "是否直接自動結清"
            If ckbIsOpd.Checked = True Then
                drDB("Is_Opd") = "Y"
            Else
                drDB("Is_Opd") = "N"
            End If
            If Me.ckbIsEmg.Checked = True Then
                drDB("Is_Emg") = "Y"
            Else
                drDB("Is_Emg") = "N"
            End If
            If ckbIsIpd.Checked = True Then
                drDB("Is_Ipd") = "Y"
            Else
                drDB("Is_Ipd") = "N"
            End If
            If ckbIsBillClose.Checked = True Then
                drDB("Is_Bill_Close") = "Y"
            Else
                drDB("Is_Bill_Close") = "N"
            End If
            '停用
            If ckbDC.Checked = True Then
                drDB("Dc") = "Y"
            Else
                drDB("Dc") = "N"
            End If

            '健檢使用  Elly Add 2016/05/12
            If Me.ckbIsOhm.Checked = True Then
                drDB("Is_Ohm") = "Y"
            Else
                drDB("Is_Ohm") = "N"
            End If

            '創建者/修改者設定
            If currentUserID.Trim() = "" Then
                currentUserID = "pubuser"
            End If
            drDB("Create_User") = currentUserID
            drDB("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = drDB("Create_Time")

            dsDB.Tables(strTableDB).Rows.Add(drDB)

            '執行新增
            iCount = objPub.insertPUBSubIdentity(dsDB)

            If iCount > 0 Then
                '將畫面輸入資料塞入Grid中
                drGrid("身份二代碼") = Me.txtSubIdentityCode.Text.Trim
                drGrid("身份二名稱") = Me.txtSubIdentityName.Text.Trim
                drGrid("隸屬主身份") = Me.cmbMainIdentityId.Text.ToString.Trim
                drGrid("隸屬主身份代碼") = Me.cmbMainIdentityId.SelectedValue.ToString.Trim

                ''是否可收據分單
                'If ckbIsAllowDivideReceipt.Checked = True Then
                '    drGrid("是否可收據分單") = "是"
                'Else
                '    drGrid("是否可收據分單") = "否"
                'End If
                '"門診使用", "急診使用", "住診使用", "是否直接自動結清"
                If ckbIsOpd.Checked = True Then
                    drGrid("門診使用") = "是"
                Else
                    drGrid("門診使用") = "否"
                End If
                If ckbIsEmg.Checked = True Then
                    drGrid("急診使用") = "是"
                Else
                    drGrid("急診使用") = "否"
                End If
                If ckbIsIpd.Checked = True Then
                    drGrid("住診使用") = "是"
                Else
                    drGrid("住診使用") = "否"
                End If
                If ckbIsBillClose.Checked = True Then
                    drGrid("是否直接自動結清") = "是"
                Else
                    drGrid("是否直接自動結清") = "否"
                End If
                '停用
                If ckbDC.Checked = True Then
                    drGrid("停用") = "是"
                Else
                    drGrid("停用") = "否"
                End If

                '健檢使用  Elly Add 2016/05/12
                If Me.ckbIsOhm.Checked = True Then
                    drGrid("健檢使用") = "是"
                Else
                    drGrid("健檢使用") = "否"
                End If
                drGrid("建立者") = dsDB.Tables(strTableDB).Rows(0)("Create_User").ToString.Trim()
                If dsDB.Tables(strTableDB).Rows(0)("Create_Time").ToString <> "" Then
                    drGrid("建立時間") = dsDB.Tables(strTableDB).Rows(0)("Create_Time")
                End If
                drGrid("修改者") = dsDB.Tables(strTableDB).Rows(0)("Modified_User").ToString.Trim()
                If dsDB.Tables(strTableDB).Rows(0)("Modified_Time").ToString <> "" Then
                    drGrid("修改時間") = dsDB.Tables(strTableDB).Rows(0)("Modified_Time")
                End If
                dsGrid.Tables(strTableDB).Rows.Add(drGrid)
                '同步更新Grid內容
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
        '創建DB修改用DataSet和DataRow
        Dim dsDB As DataSet = genDS(DataSet_Type.DB)
        Dim drDB As DataRow = dsDB.Tables(strTableDB).NewRow()
        Dim iCount As Integer = 0
        '創建Grid更新用DataSet和DataRow
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        Dim drGrid As DataRow = dsGrid.Tables(strTableDB).NewRow()

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            '將輸入區資料添加到DB中
            drDB("Sub_Identity_Code") = Me.txtSubIdentityCode.Text.ToString.Trim
            drDB("Sub_Identity_Name") = Me.txtSubIdentityName.Text.ToString.Trim
            drDB("Main_Identity_Id") = Me.cmbMainIdentityId.SelectedValue.ToString.Trim
            ''是否可收據分單
            'If ckbIsAllowDivideReceipt.Checked = True Then
            '    drDB("Is_Allow_Divide_Receipt") = "Y"
            'Else
            '    drDB("Is_Allow_Divide_Receipt") = "N"
            'End If
            '"門診使用", "急診使用", "住診使用", "是否直接自動結清"
            If ckbIsOpd.Checked = True Then
                drDB("Is_Opd") = "Y"
            Else
                drDB("Is_Opd") = "N"
            End If
            If Me.ckbIsEmg.Checked = True Then
                drDB("Is_Emg") = "Y"
            Else
                drDB("Is_Emg") = "N"
            End If
            If ckbIsIpd.Checked = True Then
                drDB("Is_Ipd") = "Y"
            Else
                drDB("Is_Ipd") = "N"
            End If
            If ckbIsBillClose.Checked = True Then
                drDB("Is_Bill_Close") = "Y"
            Else
                drDB("Is_Bill_Close") = "N"
            End If

            '停用
            If ckbDC.Checked = True Then
                drDB("Dc") = "Y"
            Else
                drDB("Dc") = "N"
            End If

            '健檢使用
            If Me.ckbIsOhm.Checked = True Then
                drDB("Is_Ohm") = "Y"
            Else
                drDB("Is_Ohm") = "N"
            End If

            '創建者/修改者設定
            If currentUserID.Trim() = "" Then
                currentUserID = "pubuser"
            End If
            drDB("Create_User") = Nothing
            drDB("Create_Time") = Nothing
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")

            dsDB.Tables(strTableDB).Rows.Add(drDB)

            '執行修改
            iCount = objPub.updatePUBSubIdentity(dsDB)

            If iCount > 0 Then
                '將畫面輸入資料塞入Grid中
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0).Copy
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("身份二代碼"), dtGrid.Columns("隸屬主身份代碼")}
                If dtGrid.Rows.Contains(New Object() {Me.txtSubIdentityCode.Text.ToString.Trim, Me.cmbMainIdentityId.SelectedValue.ToString.Trim}) Then
                    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.txtSubIdentityCode.Text.ToString.Trim, Me.cmbMainIdentityId.SelectedValue.ToString.Trim})
                    'dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    ''定位行
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    drGrid("身份二代碼") = Me.txtSubIdentityCode.Text.Trim
                    drGrid("身份二名稱") = Me.txtSubIdentityName.Text.Trim
                    Dim str As String = Me.cmbMainIdentityId.Text.ToString.Trim
                    drGrid("隸屬主身份") = Me.cmbMainIdentityId.Text.ToString.Trim
                    drGrid("隸屬主身份代碼") = Me.cmbMainIdentityId.SelectedValue.ToString.Trim

                    ''是否可收據分單
                    'If ckbIsAllowDivideReceipt.Checked = True Then
                    '    drGrid("是否可收據分單") = "是"
                    'Else
                    '    drGrid("是否可收據分單") = "否"
                    'End If
                    '"門診使用", "急診使用", "住診使用", "是否直接自動結清"
                    If ckbIsOpd.Checked = True Then
                        drGrid("門診使用") = "是"
                    Else
                        drGrid("門診使用") = "否"
                    End If
                    If ckbIsEmg.Checked = True Then
                        drGrid("急診使用") = "是"
                    Else
                        drGrid("急診使用") = "否"
                    End If
                    If ckbIsIpd.Checked = True Then
                        drGrid("住診使用") = "是"
                    Else
                        drGrid("住診使用") = "否"
                    End If
                    If ckbIsBillClose.Checked = True Then
                        drGrid("是否直接自動結清") = "是"
                    Else
                        drGrid("是否直接自動結清") = "否"
                    End If
                    '停用
                    If ckbDC.Checked = True Then
                        drGrid("停用") = "是"
                    Else
                        drGrid("停用") = "否"
                    End If
                    '健檢使用  Elly Add 2016/05/12
                    If Me.ckbIsOhm.Checked = True Then
                        drGrid("健檢使用") = "是"
                    Else
                        drGrid("健檢使用") = "否"
                    End If
                    drGrid("建立者") = drGrid2("建立者")
                    drGrid("建立時間") = drGrid2("建立時間")
                    drGrid("修改者") = dsDB.Tables(strTableDB).Rows(0)("Modified_User").ToString.Trim()

                    If dsDB.Tables(strTableDB).Rows(0)("Modified_Time").ToString <> "" Then
                        drGrid("修改時間") = dsDB.Tables(strTableDB).Rows(0)("Modified_Time")
                    End If

                    dsGrid.Tables(strTableDB).Rows.Add(drGrid)
                    '同步更新Grid內容
                    updateDataGridView(iButtonFlag, dsGrid)
                End If
            Else
                '無符合條件資料被修改
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
        Dim iCount As Integer = 0

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            '執行刪除
            iCount = objPub.deletePUBSubIdentityByPK(Me.txtSubIdentityCode.Text.Trim, Me.cmbMainIdentityId.SelectedValue.ToString.Trim)

            If iCount > 0 Then
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0).Copy
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("身份二代碼"), dtGrid.Columns("隸屬主身份代碼")}
                If dtGrid.Rows.Contains(New Object() {Me.txtSubIdentityCode.Text.ToString.Trim, Me.cmbMainIdentityId.SelectedValue.ToString.Trim}) Then
                    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.txtSubIdentityCode.Text.ToString.Trim, Me.cmbMainIdentityId.SelectedValue.ToString.Trim})
                    'dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                End If
            Else
                '無符合條件資料被刪除
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
            Dim ctlTxtSubIdentityCode As Control = Me.txtSubIdentityCode
            Dim ctlcmbMainIdentityId As Control = Me.cmbMainIdentityId
            Dim ctlTxtSubIdentityName As Control = Me.txtSubIdentityName
            Dim ctlObjFocus As Control = ctlTxtSubIdentityCode
            '清除欄位背景色
            cleanFieldsColor()
            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not fieldCheckNull(ctlTxtSubIdentityCode, Control_Type.TextBox) Then
                        strErrMsg1.Append("身份二代碼")
                        ctlObjFocus = ctlTxtSubIdentityCode
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlcmbMainIdentityId, Control_Type.ComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then
                            strErrMsg1.Append(",")
                        End If
                        strErrMsg1.Append("隸屬主身份")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlcmbMainIdentityId
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtSubIdentityName, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then
                            strErrMsg1.Append(",")
                        End If
                        strErrMsg1.Append("身份二名稱")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtSubIdentityName
                        End If
                        blnReturnFlag = True
                    End If
                Case buttonAction.DELETE
                    If Not fieldCheckNull(ctlTxtSubIdentityCode, Control_Type.TextBox) Then
                        strErrMsg1.Append("身份二代碼")
                        ctlObjFocus = ctlTxtSubIdentityCode
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlcmbMainIdentityId, Control_Type.ComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then
                            strErrMsg1.Append(",")
                        End If
                        strErrMsg1.Append("隸屬主身份")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlcmbMainIdentityId
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
        dgvShowData.ClearDS()
        'CType(dgvShowData.DataSource, DataTable).Clear()
        dgvShowData.Refresh()
    End Sub

    ''' <summary>
    ''' 清除欄位資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsValue()
        Try
            Me.txtSubIdentityCode.Text = ""
            Me.cmbMainIdentityId.SelectedValue = ""
            Me.txtSubIdentityName.Text = ""
            'Me.ckbIsAllowDivideReceipt.Checked = False
            Me.ckbDC.Checked = False
            Me.ckbIsOpd.Checked = False
            Me.ckbIsIpd.Checked = False
            Me.ckbIsEmg.Checked = False
            Me.ckbIsBillClose.Checked = False
            Me.ckbIsOhm.Checked = False   'Elly add for 健檢使用 2016/05/12
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.txtSubIdentityCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbMainIdentityId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtSubIdentityName.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        Catch ex As Exception
            Throw ex
        End Try
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
                Me.txtSubIdentityCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("身份二代碼").Value.ToString.Trim
                Me.txtSubIdentityName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("身份二名稱").Value.ToString.Trim
                Me.cmbMainIdentityId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("隸屬主身份代碼").Value.ToString.Trim
                ''是否可收據分單
                'If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("是否可收據分單").Value.ToString.Trim = "是" Then
                '    Me.ckbIsAllowDivideReceipt.Checked = True
                'Else
                '    Me.ckbIsAllowDivideReceipt.Checked = False
                'End If
                '"門診使用", "急診使用", "住診使用", "是否直接自動結清"
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("門診使用").Value.ToString.Trim = "是" Then
                    Me.ckbIsOpd.Checked = True
                Else
                    Me.ckbIsOpd.Checked = False
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("急診使用").Value.ToString.Trim = "是" Then
                    Me.ckbIsEmg.Checked = True
                Else
                    Me.ckbIsEmg.Checked = False
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("住診使用").Value.ToString.Trim = "是" Then
                    Me.ckbIsIpd.Checked = True
                Else
                    Me.ckbIsIpd.Checked = False
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("是否直接自動結清").Value.ToString.Trim = "是" Then
                    Me.ckbIsBillClose.Checked = True
                Else
                    Me.ckbIsBillClose.Checked = False
                End If
                '停用
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停用").Value.ToString.Trim = "是" Then
                    Me.ckbDC.Checked = True
                Else
                    Me.ckbDC.Checked = False
                End If

                '健檢使用  Elly Add 2016/05/12
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("健檢使用").Value.ToString.Trim = "是" Then
                    Me.ckbIsOhm.Checked = True
                Else
                    Me.ckbIsOhm.Checked = False
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化隸屬主身份
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbMainIdentityId()
        Dim dsDB As DataSet
        '執行查詢
        dsDB = objPub.queryPUBSysCode("18")

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count > 0 Then
                    Me.cmbMainIdentityId.DataSource = dsDB.Tables(0)
                    Me.cmbMainIdentityId.uclValueIndex = "0"
                    Me.cmbMainIdentityId.uclDisplayIndex = "0,1"
                End If
            End If
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
                '{"身份二代碼", "身份二名稱", "隸屬主身份", "隸屬主身份代碼", "是否可收據分單", "門診使用", "急診使用", "住診使用", "是否直接自動結清", "停用", "建立者", "建立時間", "修改者", "修改時間"}
                Return New String(,) {{"身份二代碼", "身份二代碼", "Y", "N", ""}, _
                                      {"身份二名稱", "身份二名稱", "Y", "N", ""}, _
                                      {"隸屬主身份", "隸屬主身份", "Y", "N", ""}, _
                                      {"隸屬主身份代碼", "隸屬主身份代碼", "Y", "N", ""}, _
                                      {"是否可收據分單", "是否可收據分單", "N", "N", ""}, _
                                      {"門診使用", "門診使用", "Y", "N", ""}, _
                                      {"急診使用", "急診使用", "Y", "N", ""}, _
                                      {"住診使用", "住診使用", "Y", "N", ""}, _
                                      {"是否直接自動結清", "是否直接自動結清", "Y", "N", ""}, _
                                      {"停用", "停用", "Y", "N", ""}, _
                                      {"建立者", "建立者", "Y", "N", ""}, _
                                      {"建立時間", "建立時間", "Y", "N", ""}, _
                                      {"修改者", "修改者", "Y", "N", ""}, _
                                      {"修改時間", "修改時間", "Y", "N", ""}, _
                                      {"健檢使用", "健檢使用", "Y", "N", ""}}   ' Elly Add 健檢使用 2016/05/12

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
