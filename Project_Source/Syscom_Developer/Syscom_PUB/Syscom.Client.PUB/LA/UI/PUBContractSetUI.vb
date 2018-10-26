'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBContractSetUI.vb
'*              Title:	合約身份折扣記帳設定檔維護
'*        Description:	主要對合約身份折扣記帳設定檔做確定儲存和查詢操作
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Yunfei
'*        Create Date:	2009/07/22
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
Public Class PUBContractSetUI


    Dim pDataRowView As DataRowView
    Dim objPub As IPubServiceManager = Nothing
    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)
    '宣告EventManager
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance
    '獲取維護表名
    Dim tableDB As String = PubContractSetDataTableFactory.tableName
    'Grid使用的標題
    Dim columnNameGrid() As String = {"生效日", "合約機關ID", "合約機關代碼", "身份二ID", "身份二代碼", _
                                      "醫令類型", "院內費用項目代碼", "院內費用項目", "醫令代碼", _
                                       "批價碼", "折扣率", "自付金額", "請款比率", "請款定額", _
                                      "停止日", "停用", "建立者", "建立時間", _
                                      "修改者", "修改時間", "生效日1", "停止日1"}
    '獲取維護表字段名
    Dim columnNameDB() As String = PubContractSetDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubContractSetDataTableFactory.columnsLength

    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {1, 3, 6, 8, 20, 21} '從0開始
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        DateTimePicker
        TextBox
        ComBoBox
    End Enum
    Enum buttonAction
        OK
        QUERY
        CLEAR
    End Enum

    Const MAXDATE As String = "9998/12/31"

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
    ''' 初始化對象 構建空的Grid 設定欄位長度
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance

            '構建空的Grid
            dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(tableDB)

            '將DataGridView的欄位隱藏()
            For i As Integer = 0 To visibleColumnNo.Count - 1
                dgvShowData.Columns(visibleColumnNo(i)).Visible = False
            Next
            '初始化醫令類型
            Me.initialCmbOrderTypeId()
            '初始化身份二代碼
            Me.initialCmbSubIdentityCode()
            '初始化合約機關代碼
            Me.initialCmbContractCode("")
            ' 初始化院內費用項目
            Me.initialCmbAccountId()
            '院內費用項目有值，自付金額和請款定額才可輸入
            isEnabled()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' 初始化合約機關代碼
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbContractCode(ByVal strSubIdentityCode As String)
        Dim dsDB As DataSet
        '執行查詢()
        dsDB = objPub.queryPUBContractByColumnValue((New String() {"DC", "Sub_Identity_Code"}), New Object() {"N", strSubIdentityCode.ToString.Trim})

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                Else
                    Me.cmbContractCode.DataSource = dsDB.Tables(0)
                    Me.cmbContractCode.uclValueIndex = "0"
                    Me.cmbContractCode.uclDisplayIndex = "0,1"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
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
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
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
    ''' 初始化醫令類型
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbOrderTypeId()
        Dim dsDB As DataSet
        '執行查詢()
        dsDB = objPub.queryPUBSysCodeByCV((New String() {"Type_Id", "DC"}), New Object() {"31", "N"})

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    Me.cmbOrderTypeId.DataSource = dsDB.Tables(0)
                    Me.cmbOrderTypeId.uclValueIndex = "0"
                    Me.cmbOrderTypeId.uclDisplayIndex = "1"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化院內費用項目
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbAccountId()
        Dim dsDB As DataSet
        '執行查詢()
        dsDB = objPub.queryPUBSysCodeByCV((New String() {"Type_Id", "DC"}), New Object() {"41", "N"})

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    Me.cmbAccountId.DataSource = dsDB.Tables(0)
                    Me.cmbAccountId.uclValueIndex = "0"
                    Me.cmbAccountId.uclDisplayIndex = "1"
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
        Dim blnReturnFlag As Boolean = True
        Dim dsDB As DataSet
        Dim dateEffectDate As Date

        Try
            If dtpEffectDate.IsEmpty Then
                dateEffectDate = System.DateTime.MinValue
            Else
                dateEffectDate = CDate(dtpEffectDate.GetUsDateStr)
            End If
            '執行查詢
            dsDB = objPub.queryPUBContractSetByCond(dateEffectDate, cmbContractCode.SelectedValue.Trim.Replace("'", "''"), cmbSubIdentityCode.SelectedValue.Trim.Replace("'", "''"), cmbOrderTypeId.SelectedValue.Trim.Replace("'", "''"), cmbAccountId.SelectedValue.Trim.Replace("'", "''"), tcqOrderCode.uclCodeValue1.Trim.Replace("'", "''"), False)
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
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

    ''' <summary>
    ''' 邦定DataGridView
    ''' </summary>
    ''' <param name="ds">更新數據集</param>
    ''' <param name="iButtonFlag">Button標記</param>
    ''' <remarks></remarks>
    Private Sub bindDataGridView(ByVal ds As DataSet, ByVal iButtonFlag As Integer)
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        Dim drGrid(ds.Tables(tableDB).Rows.Count - 1) As DataRow
        Dim iIndex As Integer
        '將查出的資料塞入Grid中
        For i As Integer = 0 To ds.Tables(tableDB).Rows.Count - 1
            drGrid(i) = dsGrid.Tables(tableDB).NewRow()
            If ds.Tables(tableDB).Rows(i)("Effect_Date").ToString.Trim <> "" Then
                drGrid(i)("生效日1") = CDate(ds.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd")
            Else
                drGrid(i)("生效日1") = ""
            End If

            If ds.Tables(tableDB).Rows(i)("Effect_Date").ToString.Trim <> "" Then
                drGrid(i)("生效日") = CDate(ds.Tables(tableDB).Rows(i)("Effect_Date")).Year - 1911 & CDate(ds.Tables(tableDB).Rows(i)("Effect_Date")).ToString("/MM/dd")
            Else
                drGrid(i)("生效日") = ""
            End If

            drGrid(i)("合約機關ID") = ds.Tables(tableDB).Rows(i)("Contract_Code").ToString.Trim()
            drGrid(i)("合約機關代碼") = ds.Tables(tableDB).Rows(i)("Contract_Code").ToString.Trim() & " - " & ds.Tables(tableDB).Rows(i)("Contract_Name").ToString.Trim()
            drGrid(i)("身份二ID") = ds.Tables(tableDB).Rows(i)("Sub_Identity_Code").ToString.Trim()
            If ds.Tables(tableDB).Rows(i)("Sub_Identity_Code").ToString.Trim() <> "" Then
                drGrid(i)("身份二代碼") = ds.Tables(tableDB).Rows(i)("Sub_Identity_Code").ToString.Trim() & " - " & ds.Tables(tableDB).Rows(i)("Sub_Identity_Name").ToString.Trim()
            Else
                drGrid(i)("身份二代碼") = ""
            End If
            drGrid(i)("醫令代碼") = ds.Tables(tableDB).Rows(i)("Order_Type_Id").ToString.Trim()
            drGrid(i)("醫令類型") = ds.Tables(tableDB).Rows(i)("Order_Code_Name").ToString.Trim()
            drGrid(i)("院內費用項目代碼") = ds.Tables(tableDB).Rows(i)("Account_Id").ToString.Trim()
            drGrid(i)("院內費用項目") = ds.Tables(tableDB).Rows(i)("Account_Code_Name").ToString.Trim()
            drGrid(i)("批價碼") = ds.Tables(tableDB).Rows(i)("Order_Code").ToString.Trim()
            drGrid(i)("折扣率") = ds.Tables(tableDB).Rows(i)("Discount_Ratio").ToString.Trim()
            drGrid(i)("自付金額") = ds.Tables(tableDB).Rows(i)("Payself_Amt").ToString.Trim()
            drGrid(i)("請款比率") = ds.Tables(tableDB).Rows(i)("Keep_Account_Ratio").ToString.Trim()
            drGrid(i)("請款定額") = ds.Tables(tableDB).Rows(i)("Keep_Account_Amt").ToString.Trim()
            If ds.Tables(tableDB).Rows(i)("End_Date").ToString.Trim <> "" Then
                drGrid(i)("停止日1") = CDate(ds.Tables(tableDB).Rows(i)("End_Date")).ToString("yyyy/MM/dd")
            Else
                drGrid(i)("停止日1") = ""
            End If

            If ds.Tables(tableDB).Rows(i)("End_Date").ToString.Trim <> "" Then
                drGrid(i)("停止日") = CDate(ds.Tables(tableDB).Rows(i)("End_Date")).Year - 1911 & CDate(ds.Tables(tableDB).Rows(i)("End_Date")).ToString("/MM/dd")
            Else
                drGrid(i)("停止日") = ""
            End If

            If ds.Tables(tableDB).Rows(i)("Dc").ToString() = "N" Then
                drGrid(i)("停用") = "否"
                iIndex = i
            Else
                drGrid(i)("停用") = "是"
            End If
            drGrid(i)("建立者") = ds.Tables(tableDB).Rows(i)("Create_User").ToString.Trim()
            If ds.Tables(tableDB).Rows(i)("Create_Time").ToString.Trim <> "" Then
                drGrid(i)("建立時間") = CDate(ds.Tables(tableDB).Rows(i)("Create_Time")).Year - 1911 & CDate(ds.Tables(tableDB).Rows(i)("Create_Time")).ToString("/MM/dd HH:mm:ss")
            Else
                drGrid(i)("建立時間") = ""
            End If
            drGrid(i)("修改者") = ds.Tables(tableDB).Rows(i)("Modified_User").ToString.Trim()
            If ds.Tables(tableDB).Rows(i)("Modified_Time").ToString.Trim <> "" Then
                drGrid(i)("修改時間") = CDate(ds.Tables(tableDB).Rows(i)("Modified_Time")).Year - 1911 & CDate(ds.Tables(tableDB).Rows(i)("Modified_Time")).ToString("/MM/dd HH:mm:ss")
            Else
                drGrid(i)("修改時間") = ""
            End If
            dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
        Next
        '資料邦定到Grid
        dgvShowData.DataSource = dsGrid.Tables(tableDB)
        If iButtonFlag = buttonAction.OK Then
            '選中沒有停用列
            dgvShowData.CurrentCell = dgvShowData(0, iIndex)
        End If
        '將DataGridView的欄位隱藏()
        For i As Integer = 0 To visibleColumnNo.Count - 1
            dgvShowData.Columns(visibleColumnNo(i)).Visible = False
        Next
    End Sub

    ''' <summary>
    ''' 確定儲存合約機構記帳累計資料
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 成功</remarks>
    Public Function confirmPUBContractSet() As Boolean
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

            '將輸入區資料塞入DB1中
            drDB("Effect_Date") = Me.dtpEffectDate.GetUsDateStr
            drDB("Contract_Code") = Me.cmbContractCode.SelectedValue.Trim.Replace("'", "''")
            drDB("Sub_Identity_Code") = Me.cmbSubIdentityCode.SelectedValue.Trim.Replace("'", "''")
            If Me.cmbOrderTypeId.SelectedValue.Trim <> "" Then
                drDB("Order_Type_Id") = Me.cmbOrderTypeId.SelectedValue.Trim.Replace("'", "''")
            Else
                drDB("Order_Type_Id") = " "
            End If

            If Me.cmbAccountId.SelectedValue.Trim <> "" Then
                drDB("Account_Id") = Me.cmbAccountId.SelectedValue.Trim.Replace("'", "''")
            Else
                drDB("Account_Id") = " "
            End If

            If Me.tcqOrderCode.uclCodeValue1.Trim <> "" Then
                drDB("Order_Code") = Me.tcqOrderCode.uclCodeValue1.Trim.Replace("'", "''")
            Else
                drDB("Order_Code") = " "
            End If


            drDB("Discount_Ratio") = Me.txtDiscountRatio.Text.Trim
            drDB("Payself_Amt") = Me.txtPayselfAmt.Text.Trim
            drDB("Keep_Account_Ratio") = Me.txtKeepAccountRatio.Text.Trim
            drDB("Keep_Account_Amt") = Me.txtKeepAccountAmt.Text.Trim

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

            dsDB.Tables(tableDB).Rows.Add(drDB)

            '確定儲存合約機構記帳累計資料
            dsReturn = objPub.confirmContractSet(dsDB)

            If dsReturn.Tables.Count > 0 Then
                '邦定Grid
                bindDataGridView(dsReturn, buttonAction.OK)
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
            '先以合約機關ID作為條件查詢出所有記錄
            dsDB = objPub.queryPUBContractSetByCond(System.DateTime.MinValue, cmbContractCode.SelectedValue.Trim.Replace("'", "''"), cmbSubIdentityCode.SelectedValue.Trim.Replace("'", "''"), cmbOrderTypeId.SelectedValue.Trim.Replace("'", "''"), cmbAccountId.SelectedValue.Trim.Replace("'", "''"), tcqOrderCode.uclCodeValue1.Trim.Replace("'", "''"), True)

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
                    MessageHandling.showErrorMsg("CMMCMMB300", New String() {strMsg}, "")
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
            Dim strErrMsg3 As StringBuilder = New StringBuilder
            Dim strErrMsg4 As StringBuilder = New StringBuilder
            Dim strErrMsg6 As StringBuilder = New StringBuilder
            Dim strErrMsg7 As StringBuilder = New StringBuilder
            Dim strErrMsg8 As StringBuilder = New StringBuilder
            '設定需要檢查的欄位
            Dim ctlDtpEffectDate As Control = Me.dtpEffectDate
            Dim ctlCmbContractCode As Control = Me.cmbContractCode
            Dim ctlCmbSubIdentityCode As Control = Me.cmbSubIdentityCode
            Dim ctlCmbOrderTypeId As Control = Me.cmbOrderTypeId

            Dim ctlTxtDiscountRatio As Control = Me.txtDiscountRatio
            Dim ctlTxtKeepAccountRatio As Control = Me.txtKeepAccountRatio

            Dim ctlDtpEndDate As Control = Me.dtpEndDate
            Dim ctlObjFocus As Control = ctlDtpEffectDate

            Dim blnDiscountRatio As Boolean = False
            Dim blnKeepAccountRatio As Boolean = False
            Dim blnPayselfAmt As Boolean = False
            Dim blnKeepAccountAmt As Boolean = False
            If Me.txtDiscountRatio.Text.Trim.Equals("") Then
                Me.txtDiscountRatio.Text = "1"
                blnDiscountRatio = True
            End If
            If Me.txtKeepAccountRatio.Text.Trim.Equals("") Then
                Me.txtKeepAccountRatio.Text = "0"
                blnKeepAccountRatio = True
            End If
            If Me.txtPayselfAmt.Text.Trim.Equals("") Then
                Me.txtPayselfAmt.Text = "0"
                blnPayselfAmt = True
            End If
            If Me.txtKeepAccountAmt.Text.Trim.Equals("") Then
                Me.txtKeepAccountAmt.Text = "0"
                blnKeepAccountAmt = True
            End If


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

                    If Not fieldCheckNull(ctlCmbContractCode, Control_Type.ComBoBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("合約機關代碼")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlCmbContractCode
                        End If
                        blnReturnFlag = True
                    End If

                    'If Not fieldCheckNull(ctlCmbSubIdentityCode, Control_Type.ComBoBox) Then
                    '    If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                    '    strErrMsg1.Append("身份二代碼")
                    '    If blnReturnFlag = False Then
                    '        ctlObjFocus = ctlCmbSubIdentityCode
                    '    End If
                    '    blnReturnFlag = True
                    'End If

                    If (Me.cmbOrderTypeId.SelectedValue.Trim <> "" And Me.cmbAccountId.SelectedValue.Trim <> "" And Me.tcqOrderCode.uclCodeValue1.Trim.Equals("")) Or _
                    (Me.cmbOrderTypeId.SelectedValue.Trim.Equals("") And Me.cmbAccountId.SelectedValue.Trim <> "" And Me.tcqOrderCode.uclCodeValue1.Trim <> "") Or _
                    (Me.cmbOrderTypeId.SelectedValue.Trim <> "" And Me.cmbAccountId.SelectedValue.Trim.Equals("") And Me.tcqOrderCode.uclCodeValue1.Trim <> "") Or _
                    (Me.cmbOrderTypeId.SelectedValue.Trim <> "" And Me.cmbAccountId.SelectedValue.Trim <> "" And Me.tcqOrderCode.uclCodeValue1.Trim <> "") Then
                        strErrMsg4.Append("醫令類型" & "," & "院內費用項目" & "," & "批價碼")
                        Me.cmbOrderTypeId.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlCmbOrderTypeId
                        End If
                        blnReturnFlag = True
                    End If

                    If Me.txtDiscountRatio.Text.Trim <> "" Then
                        If CDbl(Me.txtDiscountRatio.Text.Trim) > 1 Then
                            strErrMsg6.Append("折扣率")
                            If blnReturnFlag = False Then
                                ctlObjFocus = ctlTxtDiscountRatio
                            End If
                            blnReturnFlag = True
                        End If
                    End If
                    If Me.txtKeepAccountRatio.Text.Trim <> "" Then
                        If CDbl(Me.txtKeepAccountRatio.Text.Trim) > 1 Then
                            If (strErrMsg6.ToString.Trim.Length > 0) Then strErrMsg6.Append(",")
                            strErrMsg6.Append("請款比率")
                            If blnReturnFlag = False Then
                                ctlObjFocus = ctlTxtKeepAccountRatio
                            End If
                            blnReturnFlag = True
                        End If
                    End If

                    If (CDbl(Me.txtDiscountRatio.Text.Trim) < 1 And CDbl(Me.txtDiscountRatio.Text.Trim) >= 0 And CDbl(Me.txtPayselfAmt.Text.Trim) > 0) Then
                        strErrMsg3.Append("折扣率" & "," & "自付金額")
                        Me.txtDiscountRatio.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtDiscountRatio
                        End If
                        blnReturnFlag = True
                    End If
                    If (CDbl(Me.txtKeepAccountRatio.Text.Trim) <= 1 And CDbl(Me.txtKeepAccountRatio.Text.Trim) > 0 And CDbl(Me.txtKeepAccountAmt.Text.Trim) > 0) Then
                        strErrMsg8.Append("請款比率" & "," & "請款定額")
                        Me.txtDiscountRatio.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                        If blnReturnFlag = False Then
                            ctlObjFocus = txtKeepAccountRatio
                        End If
                        blnReturnFlag = True
                    End If

                    'If (CDbl(Me.txtDiscountRatio.Text.Trim) = 1 And CDbl(Me.txtPayselfAmt.Text.Trim) = 0 And CDbl(Me.txtKeepAccountRatio.Text.Trim) = 0 And CDbl(Me.txtKeepAccountAmt.Text.Trim) = 0) Then
                    '    strErrMsg7.Append("（折扣率" & "或" & "自付金額）" & "與" & "（請款比率" & "或" & "請款定額")
                    '    Me.txtDiscountRatio.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    '    If blnReturnFlag = False Then
                    '        ctlObjFocus = ctlTxtDiscountRatio
                    '    End If
                    '    blnReturnFlag = True
                    'End If

                    If Not Me.dtpEndDate.IsEmpty Then
                        If Me.dtpEffectDate.GetUsDateStr > Me.dtpEndDate.GetUsDateStr Then
                            strErrMsg2.Append("停止日" & "," & "生效日")
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
                If (strErrMsg4.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("HEMCMMD5001", New String() {"醫令類型" & "," & "院內費用項目" & "," & "批價碼"})
                    i += 1
                End If
                If strErrMsg6.Length > 0 Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB103", New String() {strErrMsg6.ToString, "1"})
                    i += 1
                End If
                If (strErrMsg3.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("HEMCMMD5001", New String() {"折扣率" & "," & "自付金額"})
                    i += 1
                End If
                If (strErrMsg8.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("HEMCMMD5001", New String() {"請款比率" & "," & "請款定額"})
                    i += 1
                End If
                'If (strErrMsg7.Length > 0) Then
                '    ReDim Preserve strMsgs(i)
                '    strMsgs(i) = ResourceUtil.getString("CMMCMMD101", New String() {"(折扣率" & "和" & "自付金額)" & "與" & "(請款比率" & "和" & "請款定額)默認值、空值和(默認值和空值)不能同時存在,輸入"})
                '    i += 1
                'End If
                If (strErrMsg2.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB102", New String() {"停止日", "生效日"})
                    i += 1
                End If
                If blnDiscountRatio = True Then
                    Me.txtDiscountRatio.Text = ""
                    If strErrMsg3.Length > 0 Or strErrMsg7.Length > 0 Then
                        Me.txtDiscountRatio.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    End If
                End If
                If blnKeepAccountAmt = True Then
                    Me.txtKeepAccountAmt.Text = ""
                End If
                If blnKeepAccountRatio = True Then
                    Me.txtKeepAccountRatio.Text = ""
                    If strErrMsg8.Length > 0 Then
                        Me.txtKeepAccountRatio.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    End If
                End If
                If blnPayselfAmt = True Then
                    Me.txtPayselfAmt.Text = ""
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
            Case Control_Type.DateTimePicker
                Dim objCtl As Syscom.Client.UCL.UCLDateTimePickerUC = ctl
                If objCtl.GetUsDateStr.Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.ComBoBox
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
            Me.cmbContractCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbSubIdentityCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbOrderTypeId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbAccountId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.tcqOrderCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtDiscountRatio.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtPayselfAmt.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtKeepAccountRatio.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.dtpEndDate.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtKeepAccountAmt.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
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
            Me.dtpEffectDate.GetUsDateStr.Equals("")
            Me.dtpEffectDate.Text = ""
            Me.cmbContractCode.SelectedValue = ""
            Me.cmbSubIdentityCode.SelectedValue = ""
            Me.cmbOrderTypeId.SelectedValue = ""
            Me.cmbAccountId.SelectedValue = ""

            Me.tcqOrderCode.Text = ""
            Me.tcqOrderCode.uclCodeValue1 = ""
            Me.tcqOrderCode.doFlag = True

            Me.txtDiscountRatio.Text = ""
            Me.txtPayselfAmt.Enabled = False
            Me.txtPayselfAmt.Text = ""
            Me.txtKeepAccountRatio.Text = ""
            Me.dtpEndDate.GetUsDateStr.Equals("")
            Me.dtpEndDate.Text = ""
            Me.txtKeepAccountAmt.Text = ""
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

                Me.cmbOrderTypeId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("醫令代碼").Value.ToString.Trim
                Me.cmbAccountId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("院內費用項目代碼").Value.ToString.Trim

                Me.tcqOrderCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("批價碼").Value.ToString.Trim
                Me.tcqOrderCode.uclCodeValue1 = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("批價碼").Value.ToString.Trim
                Me.tcqOrderCode.doFlag = False

                Me.txtDiscountRatio.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("折扣率").Value.ToString.Trim

                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("批價碼").Value.ToString.Trim.Equals("") Then
                    Me.txtPayselfAmt.Text = ""
                    Me.txtPayselfAmt.Enabled = False
                    Me.txtKeepAccountAmt.Text = ""
                    Me.txtKeepAccountAmt.Enabled = False
                Else
                    Me.txtPayselfAmt.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("自付金額").Value.ToString.Trim
                    Me.txtKeepAccountAmt.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("請款定額").Value.ToString.Trim
                End If
                Me.txtKeepAccountRatio.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("請款比率").Value.ToString.Trim

                '日期判斷
                Me.dtpEndDate.SetValue(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停止日1").Value.ToString)
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停用").Value.ToString.Trim = "否" Then
                    Me.dtpEffectDate.SetValue(Now.ToString("yyyy/MM/dd"))
                    Me.btnOK.Enabled = True
                Else
                    Me.dtpEffectDate.SetValue(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("生效日1").Value.ToString)
                    Me.btnOK.Enabled = False
                End If
                Dim strSub_Identity_Code As String = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("身份二ID").Value.ToString.Trim

                'If strSub_Identity_Code.ToString.Trim <> "" Then
                '    '初始化合約機關ID
                Me.initialCmbContractCode(strSub_Identity_Code.ToString.Trim)
                'Else
                '    Me.cmbContractCode.DataSource = Nothing
                'End If
                Me.cmbSubIdentityCode.SelectedValue = strSub_Identity_Code.ToString.Trim
                Me.cmbContractCode.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("合約機關ID").Value.ToString.Trim

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PUBContractSetUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            initialData()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
            '.Error(ex.ToString)
            'MessageHandling.showErrorByKey("HEMCMMB006")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("HEMCMMB006", New String() {}, "")
        End Try
    End Sub

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PUBContractSetUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            If (confirmPUBContractSet()) Then
                'MessageHandling.showInfoByKey("HEMCMMB005")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showInfoMsg("HEMCMMB005", New String() {})
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
            '.Error(ex.ToString)
            'MessageHandling.showErrorByKey("HEMCMMD015")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("HEMCMMD015", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
        Me.isEnabled()
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
            ClientExceptionHandler.ProccessException(ex)
            '.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD001")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMD001", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
        Me.isEnabled()
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
            ClientExceptionHandler.ProccessException(ex)
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD006")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMD006", New String() {}, "")
        End Try
        MessageHandling.clearInfoMsg()
        Me.isEnabled()
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
            ClientExceptionHandler.ProccessException(ex)
            'log.Error(ex.ToString)
            'MessageHandling.showError(ResourceUtil.getString("HEMCMMB203", New String(0) {"資料"}))
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("HEMCMMB203", New String() {}, "")
        End Try
        Me.isEnabled()
    End Sub

    ''' <summary>
    ''' 根據醫令類型判斷是否禁用文本框
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub isEnabled()
        If tcqOrderCode.Text.Trim <> "" Then
            Me.txtPayselfAmt.Enabled = True
            Me.txtKeepAccountAmt.Enabled = True
        Else
            Me.txtPayselfAmt.Enabled = False
            Me.txtKeepAccountAmt.Enabled = False
            Me.txtPayselfAmt.Text = ""
            Me.txtKeepAccountAmt.Text = ""
        End If
        'If tcqOrderCode.uclCodeValue1.Trim <> "" Then
        '    Me.txtPayselfAmt.Enabled = True
        '    Me.txtKeepAccountAmt.Enabled = True
        'Else
        '    Me.txtPayselfAmt.Enabled = False
        '    Me.txtKeepAccountAmt.Enabled = False
        'End If

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
            ClientExceptionHandler.ProccessException(ex)
            'log.Error(ex.ToString)
            'MessageHandling.showError(ResourceUtil.getString("HEMCMMB203", New String(0) {"資料"}))
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("HEMCMMB203", New String() {}, "")
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

    Private Sub cmbSubIdentityCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubIdentityCode.SelectedIndexChanged
        Try
            'If Me.cmbSubIdentityCode.SelectedValue.ToString.Trim <> "" Then
            '    '初始化合約機關ID
            Me.initialCmbContractCode(Me.cmbSubIdentityCode.SelectedValue.ToString.Trim)
            'Else
            '    Me.cmbContractCode.DataSource = Nothing
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tcqOrderCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcqOrderCode.Leave
        Me.isEnabled()
    End Sub

    Private Sub tcqOrderCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tcqOrderCode.KeyDown
        Me.isEnabled()
    End Sub

#Region "開啟病歷號視窗關閉事件"
    Private Sub doUcrOpenWindowValue(ByVal uclName As String, ByVal uclCodeValue1 As String, ByVal uclCodeValue2 As String, ByVal uclCodeName As String) Handles pvtReceiveMgr.UclOpenWindowValue
        Try
            tcqOrderCode.Text = uclCodeValue1.Trim
            Me.isEnabled()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
            '.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD001")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMD001", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub
#End Region
End Class
