'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBAddPartUI.vb
'*              Title:	加收部份負擔基本檔維護
'*        Description:	加收部份負擔基本檔維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Johsn
'*        Create Date:	2009/06/24
'*      Last Modifier:	tony
'*   Last Modify Date:	2009/12/17
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
Imports System.Globalization
Imports Syscom.Client.UCL
Imports Syscom.Comm.EXP

Public Class PUBAddPartUI
    Inherits Syscom.Client.UCL.BaseFormUI


    Dim objPub As IPubServiceManager = Nothing
    Dim pDataRowView As DataRowView
    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)
    '獲取維護表名
    Dim tableDB As String = PubAddPartDataTableFactory.tableName
    '取得表名
    Dim tableNameSyscode = PubSyscodeDataTableFactory.tableName
    'Grid使用的標題
    Dim columnNameGrid() As String = {"生效日", "加收類別", "起", "迄", "批價碼", "批價碼名稱", "加收金額", "停用", "結束日", "建立者", "建立時間", "修改者", "修改時間", "加收類別DB"}
    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {9, 10, 11, 12, 13} '從0開始() 
    '獲取維護表字段名
    Dim columnNameDB() As String = PubAddPartDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubAddPartDataTableFactory.columnsLength
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        DateTimePicker
        TextBox
        ComboBox
        TextCodeQuery
    End Enum
    Enum buttonAction
        OK
        QUERY
        CLEAR
    End Enum
    Const MAXDATE As String = "9998/12/31"

    '''' <summary>
    '''' 產生一個DataSet並包含一個空的Table 給Grid用 或 DB用
    '''' </summary>
    '''' <param name="type">資料集類型</param>
    '''' <returns>DataSet</returns>
    '''' <remarks></remarks>
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

    '''' <summary>
    '''' 初始化對象 構建空的Grid 設定欄位長度
    '''' </summary>
    '''' <remarks></remarks>
    Public Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance
            '初始化加收類別
            initialCmbPartTypeId("509")
            '構建空的Grid
            dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(tableDB)
            '將DataGridView的欄位隱藏()
            For i As Integer = 0 To visibleColumnNo.Count - 1
                dgvShowData.Columns(visibleColumnNo(i)).Visible = False
            Next
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            '設定disable欄位
            txtOrderCode.Text = ""
            txtOrderCode.uclCodeValue1 = ""
            txtOrderCode.doFlag = True
            txtOrderCode.Enabled = False
            txtStartValue.Text = ""
            txtStartValue.Enabled = False
            txtEndValue.Text = ""
            txtEndValue.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化加收類別
    ''' </summary>
    ''' <param name="typeId"></param>
    ''' <remarks></remarks>
    Public Sub initialCmbPartTypeId(ByVal typeId As String)
        Dim dsDB As DataSet
        If typeId = "509" Then
            '執行查詢
            dsDB = objPub.queryPUBSysCode(typeId)
            Try
                If dsDB.Tables.Count > 0 Then
                    If dsDB.Tables(tableNameSyscode).Rows.Count = 0 Then
                        '查無資料
                        'MessageHandling.showWarnByKey("CMMCMMB000")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {})
                    Else
                        '初始化加收類別
                        cmbPartTypeId.DataSource = dsDB.Tables(tableNameSyscode).Copy
                        cmbPartTypeId.uclDisplayIndex = "1"
                        cmbPartTypeId.uclValueIndex = "0"
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    '''' <summary>
    '''' 查詢事件
    '''' </summary>
    '''' <returns>Boolean</returns>
    '''' <remarks>True 查詢成功</remarks>
    Public Function queryData() As Boolean
        Dim blnReturnFlag As Boolean = True
        Dim dsDB As DataSet
        Dim dateEffectDate As Date

        Try
            If dtpEffectDate.IsEmpty Then
                dateEffectDate = Date.MinValue
            Else
                dateEffectDate = CDate(dtpEffectDate.GetUsDateStr)
            End If
            '執行查詢
            dsDB = objPub.queryPUBAddPartByCond(dateEffectDate, cmbPartTypeId.SelectedValue.Trim)

            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {})
                    blnReturnFlag = False
                Else
                    bindDataGridView(dsDB, buttonAction.QUERY)
                End If
                Return blnReturnFlag
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '''' <summary>
    '''' 確定儲存健保部份負擔資料
    '''' </summary>
    '''' <returns>Boolean</returns>
    '''' <remarks>True 成功</remarks>
    Public Function confirmPUBAddPart() As Boolean
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
            Dim drGrid As DataRow = dsGrid.Tables(tableDB).NewRow()
            Dim drDB As DataRow = dsDB.Tables(tableDB).NewRow()

            'DB檢查
            If dbCheck() Then
                Return False
            End If

            '將輸入區資料塞入DB中
            drDB("Effect_Date") = Me.dtpEffectDate.GetUsDateStr
            drDB("Part_Type_Id") = Me.cmbPartTypeId.SelectedValue
            drDB("Start_Value") = Me.txtStartValue.Text.Trim
            drDB("End_Value") = Me.txtEndValue.Text.Trim
            drDB("Add_Part_Amt") = Me.txtAddPartAmt.Text.Trim
            drDB("Order_Code") = Me.txtOrderCode.uclCodeValue1.Trim

            If Me.dtpEndDate.IsEmpty Or Me.dtpEndDate.GetUsDateStr > MAXDATE Then
                drDB("End_Date") = MAXDATE
            Else
                drDB("End_Date") = Me.dtpEndDate.GetUsDateStr
            End If
            If (dtpEffectDate.GetUsDateStr > Today.ToString("yyyy/MM/dd")) Then
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
            '確定儲存健保部份負擔資料
            dsReturn = objPub.confirmPUBAddPart(dsDB)
            If dsReturn.Tables.Count > 0 Then
                '邦定Grid
                bindDataGridView(dsReturn, buttonAction.OK)
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '''' <summary>
    '''' 欄位檢查
    '''' </summary>
    '''' <param name="iButtonFlag">BUTTON標記</param>
    '''' <returns>Boolean</returns>
    '''' <remarks>True 失敗;False 成功</remarks>
    Private Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean
        Try
            Dim blnReturnFlag As Boolean = False
            Dim strErrMsg1 As StringBuilder = New StringBuilder
            Dim strErrMsg2 As StringBuilder = New StringBuilder
            Dim strErrMsg3 As StringBuilder = New StringBuilder
            Dim strErrMsg4 As StringBuilder = New StringBuilder
            Dim strErrMsg5 As StringBuilder = New StringBuilder
            '設定需要檢查的欄位
            Dim ctlDtpEffectDate As Control = Me.dtpEffectDate
            Dim ctlTxtStartValue As Control = Me.txtStartValue
            Dim ctlTxtEndValue As Control = Me.txtEndValue
            Dim ctlTxtOrderCode As Control = Me.txtOrderCode
            Dim ctlTxtAddPartAmt As Control = Me.txtAddPartAmt
            Dim ctlCmbPartTypeId As Control = Me.cmbPartTypeId
            Dim ctlDtpEndDate As Control = Me.dtpEndDate
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
                        ctlDtpEffectDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    End If
                    If Not fieldCheckNull(ctlCmbPartTypeId, Control_Type.ComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("加收類別")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlCmbPartTypeId
                        End If
                        blnReturnFlag = True
                        ctlCmbPartTypeId.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    End If
                    If (ctlTxtStartValue.Enabled = True And ctlTxtEndValue.Enabled = True) Then
                        If Not fieldCheckNull(ctlTxtStartValue, Control_Type.TextBox) Then
                            If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                            strErrMsg1.Append("起")
                            If blnReturnFlag = False Then
                                ctlObjFocus = ctlTxtStartValue
                            End If
                            ctlTxtStartValue.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            blnReturnFlag = True
                        Else
                            If Me.txtStartValue.Text.Trim > 2147483647 Then
                                strErrMsg4.Append("起")
                                If blnReturnFlag = False Then
                                    ctlObjFocus = ctlTxtStartValue
                                End If
                                blnReturnFlag = True
                                ctlTxtStartValue.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            End If
                        End If
                        If Not fieldCheckNull(ctlTxtEndValue, Control_Type.TextBox) Then
                            If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                            strErrMsg1.Append("迄")
                            If blnReturnFlag = False Then
                                ctlObjFocus = ctlTxtEndValue
                            End If
                            ctlTxtEndValue.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            blnReturnFlag = True
                        Else
                            If Me.txtEndValue.Text.Trim > 2147483647 Then
                                strErrMsg5.Append("迄")
                                If blnReturnFlag = False Then
                                    ctlObjFocus = ctlTxtEndValue
                                End If
                                blnReturnFlag = True
                                ctlTxtEndValue.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            End If
                        End If
                        If fieldCheckNull(ctlTxtEndValue, Control_Type.TextBox) And fieldCheckNull(ctlTxtStartValue, Control_Type.TextBox) Then
                            If Me.txtStartValue.Text.Trim <= 2147483647 And Me.txtEndValue.Text.Trim <= 2147483647 Then
                                If CInt(txtEndValue.Text.Trim) < CInt(txtStartValue.Text.Trim) Then
                                    strErrMsg3.Append("迄" & "," & "起")
                                    If blnReturnFlag = False Then
                                        ctlObjFocus = ctlTxtEndValue
                                    End If
                                    blnReturnFlag = True
                                    ctlTxtStartValue.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                                    ctlTxtEndValue.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                                End If
                            End If
                        End If
                    End If
                    If (ctlTxtOrderCode.Enabled = True) Then
                        If Not fieldCheckNull(ctlTxtOrderCode, Control_Type.TextCodeQuery) Then
                            If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                            strErrMsg1.Append("批價碼")
                            If blnReturnFlag = False Then
                                ctlObjFocus = ctlTxtOrderCode
                            End If
                            blnReturnFlag = True
                            ctlTxtOrderCode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                        End If
                    End If
                    If Not fieldCheckNull(ctlTxtAddPartAmt, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("加收金額")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtAddPartAmt
                        End If
                        blnReturnFlag = True
                        ctlTxtAddPartAmt.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    End If
                    If dtpEndDate.GetUsDateStr.Trim <> "" Then
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
                If (strErrMsg3.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB102", New String() {"迄", "起"})
                    i += 1
                End If
                If (strErrMsg2.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB102", New String() {"結束日", "生效日"})
                    i += 1
                End If
                If (strErrMsg4.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB103", New String() {"起", "2147483647"})
                    i += 1
                End If
                If (strErrMsg5.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB103", New String() {"迄", "2147483647"})
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
            '先以部分負擔類別作為條件查詢出所有記錄
            dsDB = objPub.queryPUBAddPartByCond(System.DateTime.MinValue, cmbPartTypeId.SelectedValue.Trim)
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count = 0 Then
                    Return False
                End If
                For i = 0 To dsDB.Tables(tableDB).Rows.Count - 1
                    If dsDB.Tables(tableDB).Rows(i)("Dc").ToString() = "N" Then
                        Exit For
                    End If
                Next
                If i = dsDB.Tables(tableDB).Rows.Count Then
                    iIndex = dsDB.Tables(tableDB).Rows.Count - 1
                Else
                    iIndex = i - 1
                End If
                If iIndex < 0 Then
                    strEffectDate = System.DateTime.MinValue.ToString("yyyy/MM/dd")
                Else
                    strEffectDate = CDate(dsDB.Tables(tableDB).Rows(iIndex)("Effect_Date")).ToString("yyyy/MM/dd")
                End If
                '生效日必需大於表中已停用的生效日
                If Me.dtpEffectDate.GetUsDateStr <= strEffectDate Then
                    strMsg = ResourceUtil.getString("CMMCMMB102", New String() {"生效日", "已停用的生效日"})
                    'MessageHandling.showError(strMsg)
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {strMsg}, "")
                    Me.dtpEffectDate.Focus()
                    Return True
                End If
                '詢問User需Delete已存在的record
                If i < dsDB.Tables(tableDB).Rows.Count Then
                    strEffectDate = CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd")
                    If Not strEffectDate.Equals(Me.dtpEffectDate.GetUsDateStr) Then
                        If (Me.dtpEffectDate.GetUsDateStr <= Now.ToString("yyyy/MM/dd") And Me.dtpEffectDate.GetUsDateStr < strEffectDate) Or _
                           (Me.dtpEffectDate.GetUsDateStr > Now.ToString("yyyy/MM/dd") And i < dsDB.Tables(tableDB).Rows.Count - 1) Then
                            'If (MessageHandling.showQuestionByKey("HEMCMMB007") <> Windows.Forms.DialogResult.Yes) Then
                            '********************2010/2/9 Modify By Alan**********************
                            If (MessageHandling.ShowQuestionMsg("HEMCMMB007", New String() {}) <> Windows.Forms.DialogResult.Yes) Then
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
            Case Control_Type.DateTimePicker
                Dim objCtl As Syscom.Client.UCL.UCLDateTimePickerUC = ctl
                If objCtl.GetUsDateStr.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.TextCodeQuery
                If CType(ctl, Syscom.Client.UCL.UCLTextCodeQueryUI).uclCodeValue1.Trim.Equals("") Then
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
            Me.txtStartValue.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtEndValue.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtAddPartAmt.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbPartTypeId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.dtpEndDate.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtOrderCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            changeBackColor()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '''' <summary>
    '''' 清除欄位資料
    '''' </summary>
    '''' <remarks></remarks>
    Private Sub cleanFieldsValue()
        Try
            Me.dtpEffectDate.Text = ""
            Me.txtAddPartAmt.Text = ""
            Me.txtStartValue.Text = ""
            Me.txtEndValue.Text = ""
            Me.cmbPartTypeId.SelectedValue = ""
            Me.dtpEndDate.Text = ""
            Me.txtOrderCode.uclCodeName = ""
            Me.txtOrderCode.uclCodeValue1 = ""
            Me.txtOrderCode.doFlag = True
            'add by tony 2009/12/17
            Me.txtOrderCode.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '''' <summary>
    '''' 點選行資料,塞入輸入區
    '''' </summary>
    '''' <remarks></remarks>
    Public Sub dgvCellClick()
        Try
            '清除欄位資料
            cleanFieldsValue()
            '清除欄位背景顏色
            cleanFieldsColor()
            If dgvShowData.CurrentCellAddress.Y >= 0 Then

                Me.txtStartValue.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("起").Value.ToString.Trim
                Me.txtEndValue.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("迄").Value
                Me.txtAddPartAmt.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("加收金額").Value.ToString.Trim
                Me.cmbPartTypeId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("加收類別DB").Value.ToString.Trim
                Me.dtpEndDate.SetValue(DateUtil.TransDateToWE(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("結束日").Value.ToString))
                Me.txtOrderCode.uclCodeValue1 = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("批價碼").Value.ToString.Trim()
                Me.txtOrderCode.uclCodeName = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("批價碼名稱").Value.ToString.Trim()
                If Me.txtOrderCode.uclCodeValue1 <> "" Then
                    Me.txtOrderCode.Text = Me.txtOrderCode.uclCodeValue1 + "-" + Me.txtOrderCode.uclCodeName
                Else
                    Me.txtOrderCode.Text = ""
                End If
                Me.txtOrderCode.doFlag = False
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停用").Value.ToString.Trim = "否" Then
                    Me.dtpEffectDate.SetValue(Now.ToString("yyyy/MM/dd"))
                    Me.btnOK.Enabled = True
                Else
                    Me.dtpEffectDate.SetValue(DateUtil.TransDateToWE(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("生效日").Value.ToString))
                    Me.btnOK.Enabled = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '''' <summary>
    '''' 邦定DataGridView
    '''' </summary>
    '''' <param name="ds">更新數據集</param>
    '''' <param name="iButtonFlag">Button標記</param>
    '''' <remarks></remarks>
    Private Sub bindDataGridView(ByVal ds As DataSet, ByVal iButtonFlag As Integer)
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        Dim drGrid(ds.Tables(tableDB).Rows.Count - 1) As DataRow
        Dim iIndex As Integer
        '將查出的資料塞入Grid中
        For i As Integer = 0 To ds.Tables(tableDB).Rows.Count - 1
            drGrid(i) = dsGrid.Tables(tableDB).NewRow()
            drGrid(i)("生效日") = DateUtil.TransDateToROC(CDate(ds.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd"))
            drGrid(i)("加收類別") = ds.Tables(tableDB).Rows(i)("Code_Name").ToString.Trim()
            drGrid(i)("起") = ds.Tables(tableDB).Rows(i)("Start_Value").ToString.Trim()
            drGrid(i)("迄") = ds.Tables(tableDB).Rows(i)("End_Value").ToString.Trim()
            drGrid(i)("批價碼名稱") = ds.Tables(tableDB).Rows(i)("Order_Name").ToString.Trim()
            drGrid(i)("批價碼") = ds.Tables(tableDB).Rows(i)("Order_Code").ToString.Trim()
            If (ds.Tables(tableDB).Rows(i)("Add_Part_Amt").ToString.Trim <> "") Then
                drGrid(i)("加收金額") = CDec(ds.Tables(tableDB).Rows(i)("Add_Part_Amt")).ToString("0.0", CultureInfo.InvariantCulture)
            End If
            If (ds.Tables(tableDB).Rows(i)("Dc").ToString.Trim = "Y") Then
                drGrid(i)("停用") = "是"
            Else
                drGrid(i)("停用") = "否"
                iIndex = i
            End If
            If (ds.Tables(tableDB).Rows(i)("End_Date").ToString.Trim <> "") Then
                drGrid(i)("結束日") = DateUtil.TransDateToROC(CDate(ds.Tables(tableDB).Rows(i)("End_Date")).ToString("yyyy/MM/dd"))
            End If
            drGrid(i)("建立者") = ds.Tables(tableDB).Rows(i)("Create_User").ToString.Trim()
            drGrid(i)("建立時間") = DateUtil.TransDateToROC(CDate(ds.Tables(tableDB).Rows(i)("Create_Time")).ToString("yyyy/MM/dd")) & " " & CDate(ds.Tables(tableDB).Rows(i)("Create_Time")).ToString("HH:mm:ss")
            drGrid(i)("修改者") = ds.Tables(tableDB).Rows(i)("Modified_User").ToString.Trim()
            If (ds.Tables(tableDB).Rows(i)("Modified_Time").ToString.Trim <> "") Then
                drGrid(i)("修改時間") = DateUtil.TransDateToROC(CDate(ds.Tables(tableDB).Rows(i)("Modified_Time")).ToString("yyyy/MM/dd")) & " " & CDate(ds.Tables(tableDB).Rows(i)("Modified_Time")).ToString("HH:mm:ss")
            End If
            drGrid(i)("加收類別DB") = ds.Tables(tableDB).Rows(i)("Part_Type_Id").ToString.Trim()
            dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
        Next
        '資料邦定到Grid
        dgvShowData.DataSource = dsGrid.Tables(tableDB)
        If iButtonFlag = buttonAction.OK Then
            '選中沒有停用列
            'dgvShowData.CurrentCell = dgvShowData(0, iIndex)
        End If
    End Sub

    '''' <summary>
    '''' HotKey設定
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    Private Sub PUBAddPartUI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub PUBAddPartUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            initialData()
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("HEMCMMB006")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("HEMCMMB006", New String() {}, "")
        End Try
    End Sub

    '''' <summary>
    '''' 確定
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()
            If (confirmPUBAddPart()) Then
                'MessageHandling.showInfoByKey("HEMCMMB005")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("HEMCMMB005", New String() {})
            End If
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("HEMCMMD015")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("HEMCMMD015", New String() {}, "")
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
            MessageHandling.ClearInfoMsg()
            '清除欄位背景顏色
            cleanFieldsColor()
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
                MessageHandling.ShowInfoMsg("CMMCMMB001", New String() {})
            End If
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD001")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMD001", New String() {}, "")
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

            MessageHandling.ClearInfoMsg()
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD006")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMD006", New String() {}, "")
        End Try
        MessageHandling.ClearInfoMsg()
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
            Throw New CommonException("CMMCMMB990", ex)
            'log.Error(ex.ToString)
            'MessageHandling.showError(ResourceUtil.getString("HEMCMMB203", New String(0) {"資料"}))
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("HEMCMMB203", New String() {}, "")
        End Try
    End Sub

    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub
    Private Sub cmbPartTypeId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPartTypeId.SelectedIndexChanged
        changeState()
    End Sub

    Private Sub changeState()
        Select Case cmbPartTypeId.SelectedValue.Trim
            Case "2"
                txtOrderCode.uclCodeName = ""
                txtOrderCode.uclCodeValue1 = ""
                'add by tony 2009/12/17
                txtOrderCode.Text = ""

                txtOrderCode.doFlag = True
                txtOrderCode.Enabled = False
                txtOrderCode.BackColor = Me.BackColor
                txtStartValue.Enabled = True
                txtStartValue.BackColor = Colors.BACK_COLOR_DEFAULT
                txtEndValue.Enabled = True
                txtEndValue.BackColor = Colors.BACK_COLOR_DEFAULT
            Case "3"
                txtStartValue.Text = ""
                txtStartValue.Enabled = False
                txtOrderCode.BackColor = Me.BackColor
                txtEndValue.Text = ""
                txtEndValue.Enabled = False
                txtOrderCode.BackColor = Me.BackColor
                txtOrderCode.Enabled = True
                txtOrderCode.BackColor = Colors.BACK_COLOR_DEFAULT
            Case Else
                txtOrderCode.uclCodeName = ""
                txtOrderCode.uclCodeValue1 = ""
                txtOrderCode.doFlag = True
                txtOrderCode.Enabled = False
                txtOrderCode.BackColor = Me.BackColor
                txtStartValue.Text = ""
                txtStartValue.Enabled = False
                txtStartValue.BackColor = Me.BackColor
                txtEndValue.Text = ""
                txtEndValue.Enabled = False
                txtEndValue.BackColor = Me.BackColor
        End Select
        changeBackColor()
    End Sub
    Private Sub changeBackColor()
        If (txtStartValue.Enabled = True) Then
            txtStartValue.BackColor = Colors.BACK_COLOR_DEFAULT
            txtEndValue.BackColor = Colors.BACK_COLOR_DEFAULT
        Else
            txtStartValue.BackColor = Me.BackColor
            txtEndValue.BackColor = Me.BackColor
        End If
        If (txtOrderCode.Enabled = True) Then
            txtOrderCode.BackColor = Colors.BACK_COLOR_DEFAULT
        Else
            txtOrderCode.BackColor = Me.BackColor
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
            Throw New CommonException("CMMCMMB990", ex)
            'MessageHandling.showError(ResourceUtil.getString("HEMCMMB203", New String(0) {"資料"}))
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
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
