'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBSubIdentitySetUI.vb
'*              Title:	身份二代碼計價設定檔維護
'*        Description:	主要對身份二代碼計價設定檔做確定儲存和查詢操作
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	mark
'*        Create Date:	2009/07/21
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

Public Class PUBSubIdentitySetUI
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent


    Dim objPub As IPubServiceManager = Nothing
    Dim pDataRowView As DataRowView
    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

    '獲取維護表名
    Dim strTableDB As String = PubSubIdentitySetDataTableFactory.tableName
    Dim pubSubIdentityTableName As String = PubSubIdentityDataTableFactory.tableName
    Dim pubSyscodeTableName As String = PubSyscodeDataTableFactory.tableName

    '醫令類型Syscode
    Dim iOrderTypeIdCode As Integer = 31
    '院內費用項目Syscode
    Dim iAccountIdCode As Integer = 41
    '計價原則(For自費項)Syscode
    Dim iMainIdentityIdCode As Integer = 18

    'Grid使用的標題
    Dim columnNameGrid() As String = {"生效日", "身份二代碼", "身份二名稱", "醫令類型", _
                                      "院內費用項目", "醫令項目代碼", _
                                      "計價原則(For自費項)", "結束日", _
                                      "停用", "建立者", "建立時間", "修改者", "修改時間", _
                                      "醫令類型ID", "院內費用項目ID", "醫令項目名稱", _
                                      "計價原則(For自費項)ID"}
    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {13, 14, 15, 16}

    '獲取維護表字段名
    Dim columnNameDB() As String = PubSubIdentitySetDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubSubIdentitySetDataTableFactory.columnsLength
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        ComboBox
        DateTimePicker
        'TextCodeQuery
    End Enum
    '單選按鈕選中狀態定義
    Enum Checked_Status
        RboOrderTypeIdChecked
        RboAccountIdChecked
        RboOrderCodeChecked
    End Enum
    Enum buttonAction
        OK
        QUERY
        CLEAR
    End Enum
    Const MAXDATE As String = "9998/12/31"

    ''' <summary>
    ''' 初始化對象 構建空的Grid 設定欄位長度
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance

            '構建空的Grid
            dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(strTableDB)
            '將DataGridView的欄位隱藏()
            For i As Integer = 0 To visibleColumnNo.Count - 1
                dgvShowData.Columns(visibleColumnNo(i)).Visible = False
            Next

            '設定Grid滿屏
            'dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            IUCLMaintainPanel.Dock = System.Windows.Forms.DockStyle.Fill

            '初始化RadioButton的狀態
            RadioButtonCheckedChanged(Checked_Status.RboOrderTypeIdChecked)

            '初始化身份二代碼Combox
            initialSubIdentityCode()
            '初始化醫令類型Combox
            initialComboBox(iOrderTypeIdCode)
            '初始化院內費用項目Combox
            initialComboBox(iAccountIdCode)
            '初始化計價原則(For自費項)Combox
            initialComboBox(iMainIdentityIdCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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
                dsTemp.Tables.Add(strTableDB)
                For i As Integer = 0 To columnNameGrid.Length - 1
                    dsTemp.Tables(strTableDB).Columns.Add(columnNameGrid(i))
                Next
            Case DataSet_Type.DB
                '給DB用Table
                dsTemp.Tables.Add(strTableDB)
                For i As Integer = 0 To columnNameDB.Length - 1
                    dsTemp.Tables(strTableDB).Columns.Add(columnNameDB(i))
                Next
        End Select
        Return dsTemp
    End Function


    ''' <summary>
    ''' 初始化身份二代碼Combox
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialSubIdentityCode()
        Dim dsDB As DataSet
        '執行查詢
        Dim objPub As IPubServiceManager = PubServiceManager.getInstance
        dsDB = objPub.queryPUBSubIdentityAll()

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(pubSubIdentityTableName).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    Me.cmbSubIdentityCode.DataSource = dsDB.Tables(pubSubIdentityTableName)
                    Me.cmbSubIdentityCode.uclDisplayIndex = "0,2"
                    Me.cmbSubIdentityCode.uclValueIndex = "0"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化ComboBox
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialComboBox(ByVal iTypeId As Integer)
        Dim dsDB As DataSet
        '執行查詢
        Dim objPub As IPubServiceManager = PubServiceManager.getInstance
        dsDB = objPub.queryPUBSysCode(iTypeId)

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(pubSyscodeTableName).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    If iTypeId = iOrderTypeIdCode Then
                        '初始化醫令類型
                        Me.cmbOrderTypeId.DataSource = dsDB.Tables(pubSyscodeTableName)
                        Me.cmbOrderTypeId.uclDisplayIndex = "1"
                        Me.cmbOrderTypeId.uclValueIndex = "0"
                    ElseIf iTypeId = iAccountIdCode Then
                        '初始化院內費用項目
                        Me.cmbAccountId.DataSource = dsDB.Tables(pubSyscodeTableName)
                        Me.cmbAccountId.uclDisplayIndex = "1"
                        Me.cmbAccountId.uclValueIndex = "0"
                    ElseIf iTypeId = iMainIdentityIdCode Then
                        '初始化計價原則(For自費項)
                        Me.cmbMainIdentityId.DataSource = dsDB.Tables(pubSyscodeTableName)
                        Me.cmbMainIdentityId.uclDisplayIndex = "1"
                        Me.cmbMainIdentityId.uclValueIndex = "0"
                    End If
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
    Public Function queryData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.QUERY
        Dim blnReturnFlag As Boolean = True
        Dim dsDB As DataSet
        Dim dateEffectDate As Date
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)

        '輸入區欄位顏色初始化
        cleanFieldsColor()

        If dtpEffectDate.IsEmpty Then
            dateEffectDate = System.DateTime.MinValue
        Else
            dateEffectDate = CDate(dtpEffectDate.GetUsDateStr)
        End If

        '執行查詢
        dsDB = objPub.queryPUBSubIdentitySetByCond(dateEffectDate, _
                                            Me.cmbSubIdentityCode.SelectedValue.Trim, _
                                            Me.cmbOrderTypeId.SelectedValue.Trim, _
                                            Me.cmbAccountId.SelectedValue.Trim, _
                                            Me.txtOrderCode.uclCodeValue1.Trim)
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
                        drGrid(i)("生效日") = CDate(dsDB.Tables(strTableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd")
                        drGrid(i)("身份二代碼") = dsDB.Tables(strTableDB).Rows(i)("Sub_Identity_Code").ToString.Trim()
                        drGrid(i)("身份二名稱") = dsDB.Tables(strTableDB).Rows(i)("Sub_Identity_Name").ToString.Trim()
                        drGrid(i)("醫令類型") = dsDB.Tables(strTableDB).Rows(i)("Order_Type_Name").ToString.Trim()
                        drGrid(i)("醫令類型ID") = dsDB.Tables(strTableDB).Rows(i)("Order_Type_Id").ToString.Trim()
                        drGrid(i)("院內費用項目") = dsDB.Tables(strTableDB).Rows(i)("Account_Name").ToString.Trim()
                        drGrid(i)("院內費用項目ID") = dsDB.Tables(strTableDB).Rows(i)("Account_Id").ToString.Trim()
                        drGrid(i)("醫令項目代碼") = dsDB.Tables(strTableDB).Rows(i)("Order_Code").ToString.Trim()
                        drGrid(i)("醫令項目名稱") = dsDB.Tables(strTableDB).Rows(i)("Order_Name").ToString.Trim()
                        drGrid(i)("計價原則(For自費項)") = dsDB.Tables(strTableDB).Rows(i)("Main_Identity_Name").ToString.Trim()
                        drGrid(i)("計價原則(For自費項)ID") = dsDB.Tables(strTableDB).Rows(i)("Main_Identity_Id").ToString.Trim()

                        Dim strTemp As String = dsDB.Tables(strTableDB).Rows(i)("End_Date").ToString.Trim
                        If Not strTemp.Equals("") Then
                            drGrid(i)("結束日") = CDate(strTemp).ToString("yyyy/MM/dd")
                        End If

                        If dsDB.Tables(strTableDB).Rows(i)("Dc").ToString() = "N" Then
                            drGrid(i)("停用") = "否"
                        Else
                            drGrid(i)("停用") = "是"
                        End If
                        drGrid(i)("建立者") = dsDB.Tables(strTableDB).Rows(i)("Create_User").ToString.Trim()
                        drGrid(i)("建立時間") = CDate(dsDB.Tables(strTableDB).Rows(i)("Create_Time")).ToString("yyyy/MM/dd HH:mm:ss")
                        drGrid(i)("修改者") = dsDB.Tables(strTableDB).Rows(i)("Modified_User").ToString.Trim()
                        strTemp = dsDB.Tables(strTableDB).Rows(i)("Modified_Time").ToString.Trim
                        If strTemp <> "" Then
                            drGrid(i)("修改時間") = CDate(strTemp).ToString("yyyy/MM/dd HH:mm:ss")
                        End If
                        dsGrid.Tables(strTableDB).Rows.Add(drGrid(i))
                    Next
                    '將查詢到的資料綁定到Grid上
                    dgvShowData.DataSource = dsGrid.Tables(strTableDB)
                End If
                Return blnReturnFlag
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 確定保存身份二代碼計價設定檔資料
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 成功</remarks>
    Public Function confirmPubSubIdentitySet() As Boolean
        Dim iButtonFlag As Integer = buttonAction.OK
        Dim blnReturnFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            Dim iCount As Integer = 0
            Dim dsDB As DataSet = genDS(DataSet_Type.DB)
            Dim dsReturn As DataSet
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
            Dim drDB As DataRow = dsDB.Tables(strTableDB).NewRow()
            Dim iIndex As Integer

            'DB檢查
            If dbCheck() Then
                Return False
            End If

            '將輸入區資料塞入DB1中
            drDB("Effect_Date") = Me.dtpEffectDate.GetUsDateStr
            drDB("Sub_Identity_Code") = Me.cmbSubIdentityCode.SelectedValue.Trim
            drDB("Order_Type_Id") = Me.cmbOrderTypeId.SelectedValue.Trim
            drDB("Account_Id") = Me.cmbAccountId.SelectedValue.Trim
            drDB("Order_Code") = Me.txtOrderCode.uclCodeValue1.Trim
            drDB("Main_Identity_Id") = Me.cmbMainIdentityId.SelectedValue.Trim
            If Me.dtpEndDate.IsEmpty Or Me.dtpEndDate.GetUsDateStr > MAXDATE Then
                drDB("End_Date") = MAXDATE
            Else
                drDB("End_Date") = Me.dtpEndDate.GetUsDateStr
            End If
            drDB("Dc") = "N"
            If currentUserID.Trim() = "" Then
                currentUserID = "pubuser"
            End If
            drDB("Create_User") = currentUserID
            drDB("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = drDB("Create_Time")

            dsDB.Tables(strTableDB).Rows.Add(drDB)

            '確定儲存健保部份負擔資料
            dsReturn = objPub.confirmPubSubIdentitySet(dsDB)

            If dsReturn.Tables.Count > 0 Then
                If dsReturn.Tables(strTableDB).Rows.Count = 0 Then
                    '查無符合條件之資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    Dim drGrid(dsReturn.Tables(strTableDB).Rows.Count - 1) As DataRow
                    '將查詢的數據插入到Grid表中並顯示在畫面上
                    For i As Integer = 0 To dsReturn.Tables(strTableDB).Rows.Count - 1
                        drGrid(i) = dsGrid.Tables(strTableDB).NewRow()
                        drGrid(i)("生效日") = CDate(dsReturn.Tables(strTableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd")
                        drGrid(i)("身份二代碼") = dsReturn.Tables(strTableDB).Rows(i)("Sub_Identity_Code").ToString.Trim()
                        drGrid(i)("身份二名稱") = dsReturn.Tables(strTableDB).Rows(i)("Sub_Identity_Name").ToString.Trim()
                        drGrid(i)("醫令類型") = dsReturn.Tables(strTableDB).Rows(i)("Order_Type_Name").ToString.Trim()
                        drGrid(i)("醫令類型ID") = dsReturn.Tables(strTableDB).Rows(i)("Order_Type_Id").ToString.Trim()
                        drGrid(i)("院內費用項目") = dsReturn.Tables(strTableDB).Rows(i)("Account_Name").ToString.Trim()
                        drGrid(i)("院內費用項目ID") = dsReturn.Tables(strTableDB).Rows(i)("Account_Id").ToString.Trim()
                        drGrid(i)("醫令項目代碼") = dsReturn.Tables(strTableDB).Rows(i)("Order_Code").ToString.Trim()
                        drGrid(i)("醫令項目名稱") = dsReturn.Tables(strTableDB).Rows(i)("Order_Name").ToString.Trim()
                        drGrid(i)("計價原則(For自費項)") = dsReturn.Tables(strTableDB).Rows(i)("Main_Identity_Name").ToString.Trim()
                        drGrid(i)("計價原則(For自費項)ID") = dsReturn.Tables(strTableDB).Rows(i)("Main_Identity_Id").ToString.Trim()

                        Dim strTemp As String = dsReturn.Tables(strTableDB).Rows(i)("End_Date").ToString.Trim
                        If Not strTemp.Equals("") Then
                            drGrid(i)("結束日") = CDate(strTemp).ToString("yyyy/MM/dd")
                        End If

                        If dsReturn.Tables(strTableDB).Rows(i)("Dc").ToString() = "N" Then
                            drGrid(i)("停用") = "否"
                            iIndex = i
                        Else
                            drGrid(i)("停用") = "是"
                        End If
                        drGrid(i)("建立者") = dsReturn.Tables(strTableDB).Rows(i)("Create_User").ToString.Trim()
                        drGrid(i)("建立時間") = CDate(dsReturn.Tables(strTableDB).Rows(i)("Create_Time")).ToString("yyyy/MM/dd HH:mm:ss")
                        drGrid(i)("修改者") = dsReturn.Tables(strTableDB).Rows(i)("Modified_User").ToString.Trim()
                        strTemp = dsReturn.Tables(strTableDB).Rows(i)("Modified_Time").ToString.Trim
                        If strTemp <> "" Then
                            drGrid(i)("修改時間") = CDate(strTemp).ToString("yyyy/MM/dd HH:mm:ss")
                        End If
                        dsGrid.Tables(strTableDB).Rows.Add(drGrid(i))
                    Next
                    '將查詢到的資料綁定到Grid上
                    dgvShowData.DataSource = dsGrid.Tables(strTableDB)
                    '選中沒有停用列
                    dgvShowData.CurrentCell = dgvShowData(0, iIndex)
                End If
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
            Dim strErrMsg2 As StringBuilder = New StringBuilder
            '設定需要檢查的欄位
            Dim ctlDtpEffectDate As Control = Me.dtpEffectDate
            Dim ctlCmbSubIdentityCode As Control = Me.cmbSubIdentityCode
            Dim ctlCmbMainIdentityId As Control = Me.cmbMainIdentityId
            Dim ctlObjFocus As Control = ctlDtpEffectDate
            '清除欄位背景色
            cleanFieldsColor()
            '針對確定按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.OK
                    If Not fieldCheckNull(ctlDtpEffectDate, Control_Type.DateTimePicker) Then
                        strErrMsg1.Append("生效日")
                        ctlObjFocus = ctlDtpEffectDate
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlCmbSubIdentityCode, Control_Type.ComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("身份二代碼")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlCmbSubIdentityCode
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlCmbMainIdentityId, Control_Type.ComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("計價原則(For自費項)")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlCmbMainIdentityId
                        End If
                        blnReturnFlag = True
                    End If
                    If Not Me.dtpEndDate.IsEmpty Then
                        If Me.dtpEffectDate.GetUsDateStr > Me.dtpEndDate.GetUsDateStr Then
                            strErrMsg2.Append("結束日" & "," & "生效日")
                            Me.dtpEndDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            If blnReturnFlag = False Then
                                ctlObjFocus = Me.dtpEndDate
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
                MessageHandling.showErrorMsg("CMMCMMB300", New String() {pvtErrorMsg}, "")
                ctlObjFocus.Focus()
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' DB檢查
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 失敗;False 成功</remarks>
    Private Function dbCheck() As Boolean
        Dim dsDB As DataSet
        Dim strEffectDate As String = String.Empty
        Dim i As Integer
        Dim iIndex As Integer
        Dim strMsg As String

        Try
            '先以身份二代碼,醫令類型,院內費用項目,醫令項目代碼作為條件查詢出所有記錄
            '執行查詢
            dsDB = objPub.queryPUBSubIdentitySetByCond(System.DateTime.MinValue, _
                                                Me.cmbSubIdentityCode.SelectedValue.Trim, _
                                                Me.cmbOrderTypeId.SelectedValue.Trim, _
                                                Me.cmbAccountId.SelectedValue.Trim, _
                                                Me.txtOrderCode.uclCodeValue1.Trim)

            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(strTableDB).Rows.Count = 0 Then
                    Return False
                End If
                For i = 0 To dsDB.Tables(strTableDB).Rows.Count - 1
                    If dsDB.Tables(strTableDB).Rows(i)("Dc").ToString() = "N" Then
                        Exit For
                    End If
                Next
                If i = dsDB.Tables(strTableDB).Rows.Count Then
                    iIndex = dsDB.Tables(strTableDB).Rows.Count - 1
                Else
                    iIndex = i - 1
                End If
                If iIndex < 0 Then
                    strEffectDate = System.DateTime.MinValue.ToString("yyyy/MM/dd")
                Else
                    strEffectDate = CDate(dsDB.Tables(strTableDB).Rows(iIndex)("Effect_Date")).ToString("yyyy/MM/dd")
                End If
                '生效日必需大於表中已停用的生效日
                If Me.dtpEffectDate.GetUsDateStr <= strEffectDate Then
                    strMsg = ResourceUtil.getString("CMMCMMB102", New String() {"生效日", "已停用的生效日"})
                    'MessageHandling.showError(strMsg)
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showErrorMsg("CMMCMMB300", New String() {strMsg}, "")
                    Me.dtpEffectDate.Focus()
                    Return True
                End If
                '詢問User需Delete已存在的record
                If i < dsDB.Tables(strTableDB).Rows.Count Then
                    strEffectDate = CDate(dsDB.Tables(strTableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd")
                    If Not strEffectDate.Equals(Me.dtpEffectDate.GetUsDateStr) Then
                        If (Me.dtpEffectDate.GetUsDateStr <= Now.ToString("yyyy/MM/dd") And Me.dtpEffectDate.GetUsDateStr < strEffectDate) Or _
                           (Me.dtpEffectDate.GetUsDateStr > Now.ToString("yyyy/MM/dd") And i < dsDB.Tables(strTableDB).Rows.Count - 1) Then
                            'If (MessageHandling.showQuestionByKey("HEMCMMB007") <> Windows.Forms.DialogResult.Yes) Then
                            '********************2010/2/9 Modify By Alan**********************
                            If (MessageHandling.showQuestionMsg("HEMCMMB007", New String() {}) <> Windows.Forms.DialogResult.Yes) Then
                                Return True
                            End If
                        End If
                    End If
                End If
            End If
            Return False
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
    Public Sub clearData()
        '清除欄位資料
        cleanFieldsValue()
        '清除欄位背景顏色
        cleanFieldsColor()
        '確定變可用
        Me.btnOK.Enabled = True
        CType(dgvShowData.DataSource, DataTable).Clear()
        dgvShowData.Refresh()
    End Sub

    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.dtpEffectDate.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbSubIdentityCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'Me.cmbOrderTypeId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'Me.cmbAccountId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'Me.txtOrderCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbMainIdentityId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.dtpEndDate.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
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
            Me.dtpEffectDate.Clear()
            Me.cmbSubIdentityCode.SelectedValue = ""
            RadioButtonCheckedChanged(Checked_Status.RboOrderTypeIdChecked)
            Me.cmbMainIdentityId.SelectedValue = ""
            Me.dtpEndDate.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 點選行資料,塞入輸入區
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub dgvCellClick()
        Try
            '清除欄位資料
            cleanFieldsValue()
            '清除欄位背景顏色
            cleanFieldsColor()
            If dgvShowData.CurrentCellAddress.Y >= 0 Then
                Me.cmbSubIdentityCode.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("身份二代碼").Value.ToString.Trim

                Dim strOrderTypeId As String = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("醫令類型ID").Value.ToString.Trim
                Dim strAccountId As String = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內費用項目ID").Value.ToString.Trim
                Dim strOrderCode As String = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("醫令項目代碼").Value.ToString.Trim
                Dim strOrderName As String = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("醫令項目名稱").Value.ToString.Trim

                RadioButtonValueChanged(strOrderTypeId, strAccountId, strOrderCode, strOrderName)

                Me.cmbMainIdentityId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("計價原則(For自費項)ID").Value.ToString.Trim
                Dim strDC As String = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停用").Value.ToString.Trim
                Me.dtpEndDate.SetValue(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("結束日").Value.ToString)
                If strDC = "否" Then
                    Me.dtpEffectDate.SetValue(Now.ToString("yyyy/MM/dd"))
                    Me.btnOK.Enabled = True
                Else
                    Me.dtpEffectDate.SetValue(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("生效日").Value.ToString)
                    Me.btnOK.Enabled = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    ''' 
    Private Sub PubSubIdentitySetUI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                '清除
                btnClear_Click(sender, e)
            Case Keys.F1
                '查詢
                btnQuery_Click(sender, e)
            Case Keys.F12
                '確定
                If Me.btnOK.Enabled = True Then btnOK_Click(sender, e)
            Case Keys.Enter
                Me.ProcessTabKey(True)
        End Select
    End Sub

    Private Sub PubSubIdentitySetUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            initialData()
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("HEMCMMB006")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("HEMCMMB006", New String() {}, "")
        End Try
    End Sub

    ''' <summary>
    ''' 確定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.clearInfoMsg()
            If (confirmPubSubIdentitySet()) Then
                'MessageHandling.showInfoByKey("HEMCMMB005")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showInfoMsg("HEMCMMB005", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("HEMCMMD015")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("HEMCMMD015", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.clearInfoMsg()
            If (queryData()) Then
                'ming 20091013 del
                'If (dgvShowData.CurrentRow IsNot Nothing AndAlso dgvShowData.CurrentRow.Index >= 0) Then dgvShowData.CurrentRow.Selected = False


                If (dgvShowData.CurrentRow IsNot Nothing AndAlso dgvShowData.CurrentRow.Index >= 0) Then
                    '清除選中資料行 ming 20091013 add
                    dgvShowData.CurrentRow.Selected = False
                    '清除選中資料項 ming 20091013 add
                    dgvShowData.CurrentCell = Nothing
                End If
                '清除全局變量 ming 20091013 add
                pDataRowView = Nothing
                'MessageHandling.showInfoByKey("CMMCMMB001")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showInfoMsg("CMMCMMB001", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD001")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMD001", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            clearData()

            '清除全局變量 ming 20091013 add
            pDataRowView = Nothing

            MessageHandling.clearInfoMsg()
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD006")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMD006", New String() {}, "")
        End Try
        MessageHandling.clearInfoMsg()
    End Sub

    ''' <summary>
    ''' 按下DatagridView的cell時,需處理的事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvShowData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShowData.CellClick
        Try
            If (e.RowIndex >= 0) Then
                'GRID點擊后，將選中行給全局變量 ming 20091013 add
                If dgvShowData.ContainsFocus AndAlso dgvShowData.CurrentCellAddress.Y >= 0 Then
                    pDataRowView = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).DataBoundItem
                End If

                dgvCellClick()
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showError(ResourceUtil.getString("HEMCMMB203", New String(0) {"資料"}))
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("HEMCMMB203", New String() {}, "")
        End Try
    End Sub

    ''' <summary>
    ''' 由醫令類型、院內費用項目、醫令項目代碼的值確定RadioButton的狀態，並賦值到相應控件
    ''' </summary>
    ''' <param name="strOrderTypeId">醫令類型</param>
    ''' <param name="strAccountId">院內費用項目</param>
    ''' <param name="strOrderCode">醫令項目代碼</param>
    ''' <param name="strOrderName">醫令項目名稱</param>
    ''' <remarks></remarks>
    Private Sub RadioButtonValueChanged(ByVal strOrderTypeId As String, ByVal strAccountId As String, _
                                        ByVal strOrderCode As String, ByVal strOrderName As String)
        If Not strOrderTypeId.Equals("") Then
            RadioButtonCheckedChanged(Checked_Status.RboOrderTypeIdChecked)
            Me.cmbOrderTypeId.SelectedValue = strOrderTypeId
            Return
        End If

        If Not strAccountId.Equals("") Then
            RadioButtonCheckedChanged(Checked_Status.RboAccountIdChecked)
            Me.cmbAccountId.SelectedValue = strAccountId
            Return
        End If

        If Not strOrderCode.Equals("") Then
            RadioButtonCheckedChanged(Checked_Status.RboOrderCodeChecked)
            Me.txtOrderCode.Text = strOrderName
            Me.txtOrderCode.uclCodeValue1 = strOrderCode
            Me.txtOrderCode.doFlag = False
            Return
        End If
        RadioButtonCheckedChanged(Checked_Status.RboOrderTypeIdChecked)
    End Sub
    ''' <summary>
    ''' 單選按鈕選中狀態改變時的動作
    ''' </summary>
    ''' <param name="iCheckedStatus">單選按鈕選中狀態</param>
    ''' <remarks></remarks>
    Private Sub RadioButtonCheckedChanged(ByVal iCheckedStatus As Integer)
        If iCheckedStatus = Checked_Status.RboOrderTypeIdChecked Then
            '醫令類型
            Me.rboOrderTypeId.Checked = True
            Me.cmbOrderTypeId.Enabled = True
            '院內費用項目
            Me.rboAccountId.Checked = False
            Me.cmbAccountId.Enabled = False
            '醫令項目代碼
            Me.rboOrderCode.Checked = False
            Me.txtOrderCode.Enabled = False
        End If
        If iCheckedStatus = Checked_Status.RboAccountIdChecked Then
            '醫令類型
            Me.rboOrderTypeId.Checked = False
            Me.cmbOrderTypeId.Enabled = False
            '院內費用項目
            Me.rboAccountId.Checked = True
            Me.cmbAccountId.Enabled = True
            '醫令項目代碼
            Me.rboOrderCode.Checked = False
            Me.txtOrderCode.Enabled = False
        End If
        If iCheckedStatus = Checked_Status.RboOrderCodeChecked Then
            '醫令類型
            Me.rboOrderTypeId.Checked = False
            Me.cmbOrderTypeId.Enabled = False
            '院內費用項目
            Me.rboAccountId.Checked = False
            Me.cmbAccountId.Enabled = False
            '醫令項目代碼
            Me.rboOrderCode.Checked = True
            Me.txtOrderCode.Enabled = True
        End If
        '醫令類型
        Me.cmbOrderTypeId.SelectedValue = ""
        '院內費用項目
        Me.cmbAccountId.SelectedValue = ""
        '醫令項目代碼
        Me.txtOrderCode.Text = ""
        Me.txtOrderCode.uclCodeValue1 = ""
        Me.txtOrderCode.doFlag = True
    End Sub
    ''' <summary>
    ''' 單選醫令類型，禁用院內費用項目，醫令項目代碼
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rboOrderTypeId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rboOrderTypeId.CheckedChanged
        If rboOrderTypeId.Checked = True Then
            RadioButtonCheckedChanged(Checked_Status.RboOrderTypeIdChecked)
        End If
    End Sub

    ''' <summary>
    ''' 單選院內費用項目，禁用醫令類型，醫令項目代碼
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rboAccountId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rboAccountId.CheckedChanged
        If rboAccountId.Checked = True Then
            RadioButtonCheckedChanged(Checked_Status.RboAccountIdChecked)
        End If
    End Sub

    ''' <summary>
    ''' 單選醫令項目代碼，禁用醫令類型,院內費用項目
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rboOrderCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rboOrderCode.CheckedChanged
        If rboOrderCode.Checked = True Then
            RadioButtonCheckedChanged(Checked_Status.RboOrderCodeChecked)
        End If
    End Sub
    ''' <summary>
    ''' 身份二代碼選擇非空時，清除欄位背景顏色
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbSubIdentityCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubIdentityCode.SelectedIndexChanged
        If cmbSubIdentityCode.SelectedValue.Trim <> "" Then
            Me.cmbSubIdentityCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        End If
    End Sub

    ''' <summary>
    ''' 計價原則(For自費項) 選擇非空時，清除欄位背景顏色
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbMainIdentityId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMainIdentityId.SelectedIndexChanged
        If cmbMainIdentityId.SelectedValue.Trim <> "" Then
            Me.cmbMainIdentityId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        End If
    End Sub

    ''' <summary>
    ''' 按下DatagridView的Sorted時,需處理的事件  ming 20091013 add
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvShowData__Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvShowData.Sorted
        Try
            '排序后更新選中行
            ScreenUtil.setRowFocusByDataRowView(dgvShowData, pDataRowView)
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showError(ResourceUtil.getString("HEMCMMB203", New String(0) {"資料"}))
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("HEMCMMB203", New String() {}, "")
        End Try
    End Sub

    ''' <summary>
    ''' 焦點在grid上時候，上，下，回車鍵改變選中行資料 ming 20091013 add
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvShowData_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvShowData.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter, Keys.Down, Keys.Up
                'dgvCellClick()
                'pDataRowView = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).DataBoundItem
                '20091223 yunfei add
                If dgvShowData.CurrentCellAddress.Y <> -1 Then
                    dgvCellClick()
                    pDataRowView = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).DataBoundItem
                End If
        End Select
    End Sub

    ''' <summary>
    ''' 焦點在grid上時候,回車鍵改變選中行資料,避開IUCLMaintainFormUI_KeyDown衝突 ming 20091013 add
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvShowData_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvShowData.KeyDown
        Dim nextIndex As Integer = -1
        Select Case e.KeyCode
            Case Keys.Enter
                nextIndex = dgvShowData.CurrentRow.Index + 1
                If (nextIndex >= 0 And nextIndex < dgvShowData.Rows.Count) Then
                    Me.dgvShowData.Focus()
                    Me.dgvShowData.Rows(nextIndex).Cells(0).Selected = True
                End If
        End Select
    End Sub

End Class
