Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.DataSetUtil
Imports Syscom.Comm.LOG
Imports Syscom.Comm.BASE
Imports Syscom.Comm.EXP
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.Windows.Forms

Public Class TskSystemMtnUI
    Inherits IMaintainFormUI

    Dim tableName As String = "arm_tsk_system"

    '繁體中文的顯示名稱
    Dim columnNameTraditional() As String = {"系統代碼", "系統名稱", "子系統代碼", "子系統名稱", "作業代碼", "作業名稱", "排列順序", "是否有效代码", "是否有效", _
                                  "建立者", "建立時間", "修改者", "修改時間"}

    '簡體體中文的顯示名稱
    Dim columnNameSimple() As String = {"系统代码", "系统名称", "子系统代码", "子系统名称", "作业代码", "作业名称", "排列顺序", "是否有效代码", "是否有效", _
                                  "建立者", "建立时间", "修改者", "修改时间"}

    '要顯示的名稱 - 在 initial 時 會根據 AppConfigUtil.AppLanguage 的值去設定，預設繁體中文
    Dim columnName() As String = {}


    Dim columnNameDB() As String = {"app_system_no", "app_system_name", "tsk_sub_system_no", "sub_system_name", "tsk_task_no", "tsk_task_name", "tsk_display_order", "tsk_task_flag_no", "tsk_task_flag_name", _
                                    "tsk_creator_no", "tsk_create_datetime", "tsk_operator_no", "tsk_update_datetime"}

    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {0, 2, 7}

    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId

    '是否的 Code Type 代號
    Dim CodeTypeDC As String = "9000"

    Private CodeDs As DataSet = Nothing
    Private DCTable As DataTable = Nothing
    Dim ds1 As New DataSet
    Dim ds2 As New DataSet

    Public Overrides Sub initialData()
        Try
            '載入ArmServiceManager的Instance
            loadArmServiceManager()

            '設定Column 要使用哪一個，必須在 顯示DataGridView(showResult) 之前
            '設定UI的名稱字樣
            Select Case AppConfigUtil.AppLanguage
                Case AppConfigUtil.Language.TraditionalChinese

                    '繁體中文
                    columnName = columnNameTraditional
                    lbl_app_system_no.Text = "*系統代碼"
                    lbl_tsk_sub_system_no.Text = "*子系統代碼"
                    lbl_tsk_task_no.Text = "*作業代碼"
                    lbl_tsk_task_name.Text = "*作業名稱"
                    lbl_tsk_display_order.Text = "*排列順序"
                    lbl_DCYN.Text = "*是否有效"
                Case AppConfigUtil.Language.SimplifiedChinese

                    '簡體中文
                    columnName = columnNameSimple
                    lbl_app_system_no.Text = "*系统代码"
                    lbl_tsk_sub_system_no.Text = "*子系统代码"
                    lbl_tsk_task_no.Text = "*作业代码"
                    lbl_tsk_task_name.Text = "*作业名称"
                    lbl_tsk_display_order.Text = "*排列顺序"
                    lbl_DCYN.Text = "*是否有效"
            End Select

            '顯示DataGridView的初始Table
            showResult(GenDataSet(tableName, columnNameDB))

            If dgvShowData.Columns.Count >= 6 And dgvShowData.Columns.Count < 11 Then
                For i As Integer = 0 To dgvShowData.Columns.Count - 1
                    dgvShowData.Columns(i).Width = 1024 / dgvShowData.Columns.Count
                Next
            ElseIf dgvShowData.Columns.Count < 6 Then
                For i As Integer = 0 To dgvShowData.Columns.Count - 1
                    dgvShowData.Columns(i).Width = 200
                Next
            End If

            ds1 = ARM.AppGetAppSystemCombobox
            If ds1.Tables.Count > 0 Then
                ds1.Tables(0).PrimaryKey = New DataColumn() {ds1.Tables(0).Columns(0)}
            End If

            '加入空白列
            Dim _row As DataRow = ds1.Tables(0).NewRow
            _row.Item("app_system_no") = ""
            _row.Item("app_system_name") = ""
            _row.Item("cbo_app_system") = ""
            ds1.Tables(0).Rows.InsertAt(_row, 0)

            'Combobox 初始化
            app_system_no.DataSource = ds1.Tables("arm_app_system")
            app_system_no.DisplayMember = "cbo_app_system"
            app_system_no.ValueMember = "app_system_no"

            '加入空白列
            Dim dt As New DataTable
            dt.Columns.Add("sub_system_no")
            dt.Columns.Add("sub_system_name")
            dt.Columns.Add("cbo_sub_system")
            Dim empty As DataRow = dt.Rows.Add()
            empty.Item("sub_system_no") = ""
            empty.Item("sub_system_name") = ""
            empty.Item("cbo_sub_system") = ""

            'Combobox 初始化
            tsk_sub_system_no.DataSource = dt
            tsk_sub_system_no.DisplayMember = "cbo_sub_system"
            tsk_sub_system_no.ValueMember = "sub_system_no"

            '*****************************************************************************
            '取得 顯示在畫面上的 RadioButton 的文字【是否】
            '*****************************************************************************
            '取得代碼的 Dataset  與 Datatable
            CodeDs = CmmServiceManager.getInstance.CMMSysCodeBSSysCodeQuery(CodeTypeDC)
            DCTable = CodeDs.Tables(CodeTypeDC)

            '設定至畫面上
            RdoBtnY.Text = DCTable.Rows(0).Item("code_name").ToString.Trim
            RdoBtnY.Tag = DCTable.Rows(0).Item("code_ID").ToString.Trim
            RdoBtnN.Text = DCTable.Rows(1).Item("code_name").ToString.Trim
            RdoBtnN.Tag = DCTable.Rows(1).Item("code_ID").ToString.Trim
            '*****************************************************************************

            '設定長度
            tsk_task_no.MaxLength = 10
            tsk_task_name.MaxLength = 40
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Public Overrides Function insertData() As Boolean
        Dim resultFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(buttonAction.INSERT) Then
            Return False
        End If

        Try
            Dim dsParam As New DataSet
            Dim count As Integer = 0
            dsParam = GenDataSet(tableName, columnNameDB)
            Dim row As DataRow = dsParam.Tables(0).Rows.Add()

            row("tsk_task_no") = Me.tsk_task_no.Text
            row("tsk_task_name") = Me.tsk_task_name.Text
            row("tsk_sub_system_no") = Me.tsk_sub_system_no.SelectedValue
            row("tsk_display_order") = Me.tsk_display_order.Text
            If RdoBtnN.Checked Then
                row("tsk_task_flag_no") = RdoBtnN.Tag
            ElseIf RdoBtnY.Checked Then
                row("tsk_task_flag_no") = RdoBtnY.Tag
            End If
            row("tsk_creator_no") = Me.currentUserID
            row("tsk_operator_no") = row("tsk_creator_no")

            count = ARM.TskInsert(dsParam)

            If Not count.Equals(0) Then
                '同步更新DataGridView中的值
                updateDataGridView(buttonAction.INSERT, ARM.TskQueryByPK(dsParam.Tables(0).Rows(0).Item("tsk_task_no")))
            Else
                resultFlag = False
            End If
            Return resultFlag
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Overrides Function updateData() As Boolean
        Dim resultFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(buttonAction.UPDATE) Then
            Return False
        End If

        Try
            Dim dsParam As New DataSet
            Dim count As Integer = 0
            dsParam = GenDataSet(tableName, columnNameDB)
            Dim row As DataRow = dsParam.Tables(0).Rows.Add()

            row("tsk_task_no") = Me.tsk_task_no.Text
            row("tsk_task_name") = Me.tsk_task_name.Text
            row("tsk_sub_system_no") = Me.tsk_sub_system_no.SelectedValue
            row("tsk_display_order") = Me.tsk_display_order.Text
            If RdoBtnN.Checked Then
                row("tsk_task_flag_no") = RdoBtnN.Tag
            ElseIf RdoBtnY.Checked Then
                row("tsk_task_flag_no") = RdoBtnY.Tag
            End If
            row("tsk_operator_no") = Me.currentUserID

            count = ARM.TskUpdate(dsParam)

            If Not count.Equals(0) Then
                Dim dt As DataTable = dgvShowData.DataSource
                If dt.Rows.Contains(tsk_task_no.Text) Then
                    CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim _row As DataRow = dt.Rows.Find(tsk_task_no.Text)
                    dgvShowData.CurrentCell = dgvShowData(4, dt.Rows.IndexOf(_row))
                    '同步更新DataGridView中的值
                    updateDataGridView(buttonAction.UPDATE, ARM.TskQueryByPK(dsParam.Tables(0).Rows(0).Item("tsk_task_no")))
                Else
                    updateDataGridView(buttonAction.INSERT, ARM.TskQueryByPK(dsParam.Tables(0).Rows(0).Item("tsk_task_no")))
                    dgvShowData.CurrentCell = dgvShowData(1, dgvShowData.Rows.Count - 1)
                End If
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB010", New String() {})
            End If
            Return resultFlag
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Overrides Function deleteData() As Boolean
        Dim resultFlag As Boolean = True
        '欄位檢查
        If fieldCheckResult(buttonAction.DELETE) Then
            Return False
        End If

        Try
            Dim dsParam As New DataSet
            Dim count As Integer = 0
            dsParam = GenDataSet(tableName, columnNameDB)
            Dim row As DataRow = dsParam.Tables(0).Rows.Add()

            '加入Pkey
            row("tsk_task_no") = Me.tsk_task_no.Text

            count = ARM.TskDelete(dsParam.Tables(0).Rows(0).Item("tsk_task_no"))

            '同步更新DataGridView中的值
            If Not count.Equals(0) Then
                Dim dt As DataTable = dgvShowData.DataSource
                If dt.Rows.Contains(tsk_task_no.Text) Then
                    CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim _row As DataRow = dt.Rows.Find(tsk_task_no.Text)
                    dgvShowData.CurrentCell = dgvShowData(4, dt.Rows.IndexOf(_row))
                End If
                updateDataGridView(buttonAction.DELETE, dsParam)
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB011", New String() {})
                resultFlag = False
            End If

            '清除資料並Disable按鈕
            UCLScreenUtil.CleanControls(Me.tlp_nonButton)

            Return resultFlag
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Overrides Function queryData() As Boolean
        Dim msgTitle As Integer = buttonAction.QUERY
        Dim resultFlag As Boolean = True
        Try
            '欄位檢查
            If fieldCheckResult(msgTitle) Then
                Return False
            End If

            Dim tsk_task_flag_no As String = ""
            If RdoBtnN.Checked Then
                tsk_task_flag_no = RdoBtnN.Tag
            ElseIf RdoBtnY.Checked Then
                tsk_task_flag_no = RdoBtnY.Tag
            End If

            Dim dsTemp As DataSet = ARM.TskGetAllSystem(app_system_no.SelectedValue, tsk_sub_system_no.SelectedValue, tsk_task_no.Text.Trim, tsk_task_name.Text.Trim, tsk_display_order.Text.Trim, tsk_task_flag_no)

            '顯示DataGridView的初始Table
            showResult(dsTemp)

            If dgvShowData.Rows.Count = 0 Then
                MessageHandling.ShowWarnMsg("CMMCMMB933", New String() {})
            End If

            Return resultFlag
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Overrides Sub clearData()
        Try
            '清除上方區域資料並Disable按鈕
            UCLScreenUtil.CleanControls(Me.tlp_nonButton)
            CType(dgvShowData.DataSource, DataTable).Clear()
            dgvShowData.Refresh()
            '清除欄位背景顏色
            cleanFieldsColor()
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Public Overrides Sub dgvCellClick()
        Try
            '清除欄位背景顏色
            cleanFieldsColor()
            If dgvShowData.CurrentCellAddress.Y >= 0 Then
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("tsk_task_no").Value.ToString.Trim <> "" Then
                    tsk_task_no.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("tsk_task_no").Value.ToString.Trim
                Else
                    tsk_task_no.Text = ""
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("tsk_task_name").Value.ToString.Trim <> "" Then
                    tsk_task_name.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("tsk_task_name").Value.ToString.Trim
                Else
                    tsk_task_name.Text = ""
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("tsk_display_order").Value.ToString.Trim <> "" Then
                    tsk_display_order.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("tsk_display_order").Value.ToString.Trim
                Else
                    tsk_display_order.Text = ""
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("app_system_no").Value.ToString.Trim <> "" Then
                    app_system_no.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("app_system_no").Value.ToString.Trim
                Else
                    app_system_no.SelectedValue = ""
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("tsk_sub_system_no").Value.ToString.Trim <> "" Then
                    tsk_sub_system_no.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("tsk_sub_system_no").Value.ToString.Trim
                Else
                    tsk_sub_system_no.SelectedValue = ""
                End If
                If dgvShowData.CurrentRow.Cells("tsk_task_flag_no").Value.ToString.Equals(RdoBtnY.Tag) Then
                    RdoBtnY.Checked = True
                ElseIf dgvShowData.CurrentRow.Cells("tsk_task_flag_no").Value.ToString.Equals(RdoBtnN.Tag) Then
                    RdoBtnN.Checked = True
                Else
                    RdoBtnY.Checked = False
                    RdoBtnN.Checked = False
                End If
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 載入ArmServiceManager的Instance
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadArmServiceManager()
        Try
            ARM = ArmServiceManager.getInstance()
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 顯示最新的資料在DataGridView
    ''' </summary>
    ''' <param name="dsTemp">要show在DataGridView中的資料</param>
    ''' <remarks></remarks>
    Private Sub showResult(ByVal dsTemp As DataSet)
        Try
            If dsTemp.Tables.Count > 0 Then
                dsTemp.Tables(0).PrimaryKey = New DataColumn() {dsTemp.Tables(0).Columns(4)}
                dgvShowData.DataSource = dsTemp.Tables(0)

                '將欄位名稱改成中文
                For i As Integer = 0 To columnName.Length - 1
                    dgvShowData.Columns(i).HeaderText = columnName(i)
                Next

                dgvShowData.Columns("tsk_create_datetime").DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
                dgvShowData.Columns("tsk_update_datetime").DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"

                '將DataGridView的欄位隱藏
                For i As Integer = 0 To visibleColumnNo.Count - 1
                    dgvShowData.Columns(visibleColumnNo(i)).Visible = False
                Next
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 同步更新DataGridView中的值
    ''' </summary>
    ''' <param name="mode"></param>
    ''' <param name="_ds"></param>
    ''' <remarks></remarks>
    Private Sub updateDataGridView(ByVal mode As Integer, ByVal _ds As DataSet)
        Try
            Select Case mode
                Case buttonAction.INSERT
                    CType(dgvShowData.DataSource, System.Data.DataTable).Rows.Add(_ds.Tables(0).Rows(0).ItemArray)
                Case buttonAction.UPDATE
                    dgvShowData.CurrentRow.SetValues(_ds.Tables(0).Rows(0).ItemArray)
            End Select
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 欄位檢查
    ''' </summary>
    ''' <param name="msgTitle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function fieldCheckResult(ByVal msgTitle As Integer) As Boolean
        Try
            Dim isError As Boolean = False
            Dim errorMsg1 As StringBuilder = New StringBuilder
            Dim errorMsg2 As StringBuilder = New StringBuilder

            '設定需要檢查的欄位
            Dim ctl_1 As Control = tsk_task_no
            Dim ctl_2 As Control = tsk_task_name
            Dim ctl_3 As Control = tsk_sub_system_no
            Dim ctl_4 As Control = tsk_display_order
            Dim ctl_5 As Control = app_system_no

            '繁中訊息
            Dim checkMsgTraditional As String() = New String() {"不可為空", "必須為數字"}

            '簡中訊息
            Dim checkMsgSimple As String() = New String() {"不可为空", "必须为数字"}

            '顯示訊息 - 預設繁中
            Dim checkMsg As String() = checkMsgTraditional

            '設定要使用哪一種語言
            Select Case AppConfigUtil.AppLanguage

                '繁體中文
                Case AppConfigUtil.Language.TraditionalChinese

                    checkMsg = checkMsgTraditional

                    '簡體中文
                Case AppConfigUtil.Language.TraditionalChinese

                    checkMsg = checkMsgSimple

            End Select

            '清除欄位背景顏色
            cleanFieldsColor()

            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case msgTitle
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not CheckControlHasValue(ctl_1) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '作業代碼
                        errorMsg1.Append(nvl(lbl_tsk_task_no.Text))
                        isError = True
                    End If
                    If Not CheckControlHasValue(ctl_2) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '作業名稱
                        errorMsg1.Append(nvl(lbl_tsk_task_name.Text))
                        isError = True
                    End If
                    If Not CheckControlHasValue(ctl_3) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '子系統代碼
                        errorMsg1.Append(nvl(lbl_tsk_sub_system_no.Text))
                        isError = True
                    End If
                    If Not CheckControlHasValue(ctl_4) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '排列順序
                        errorMsg1.Append(nvl(lbl_tsk_display_order.Text))
                        isError = True
                    End If
                    If Not CheckControlIsNumber(ctl_4) Then
                        If (errorMsg2.ToString.Trim.Length > 0) Then errorMsg2.Append(",")
                        '排列順序
                        errorMsg2.Append(nvl(lbl_tsk_display_order.Text))
                        isError = True
                    End If
                    If Not RdoBtnN.Checked And Not RdoBtnY.Checked Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '是否有效
                        errorMsg1.Append(nvl(lbl_DCYN.Text))
                        isError = True
                    End If
                    If Not CheckControlHasValue(ctl_5) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '系統代碼
                        errorMsg1.Append(nvl(lbl_app_system_no.Text))
                        isError = True
                    End If
                Case buttonAction.DELETE
                    If Not CheckControlHasValue(ctl_1) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '作業代碼
                        errorMsg1.Append(nvl(lbl_tsk_task_no.Text))
                        isError = True
                    End If
                Case buttonAction.QUERY
                    If Not CheckControlIsNumber(ctl_4) Then
                        If (errorMsg2.ToString.Trim.Length > 0) Then errorMsg2.Append(",")
                        '排列順序
                        errorMsg2.Append(nvl(lbl_tsk_display_order.Text))
                        isError = True
                    End If
            End Select

            If (isError) Then
                '欄位check錯誤
                Dim opt(0) As String
                Dim cnt = 0
                If (errorMsg1.Length > 0) Then
                    ReDim opt(cnt)
                    opt(cnt) = errorMsg1.ToString & checkMsg(0)
                    cnt += 1
                End If
                If (errorMsg2.Length > 0) Then
                    ReDim opt(cnt)
                    opt(cnt) = errorMsg2.ToString & checkMsg(1)
                    cnt += 1
                End If
                'MessageHandling.showErrors(opt)
                '********************2010/2/8 Modify By Alan**********************
                Dim pvtErrorMsg As String = ""
                For i = 0 To opt.Length - 1
                    If i <> 0 Then
                        pvtErrorMsg = pvtErrorMsg & vbCrLf & opt(i)
                    Else
                        pvtErrorMsg = opt(i)
                    End If
                Next
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {pvtErrorMsg}, "")
            End If
            Return isError
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 先將需要檢查欄位的back color設為default
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            '先將需要檢查欄位的back color設為default
            tsk_task_no.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            tsk_task_name.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            tsk_sub_system_no.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            tsk_display_order.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            app_system_no.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub app_system_no_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles app_system_no.SelectedIndexChanged
        Try
            If app_system_no.SelectedValue IsNot Nothing AndAlso TypeOf app_system_no.SelectedValue Is String Then
                ds2 = ARM.SubGetSubSystemCombobox(app_system_no.SelectedValue)
                If ds2.Tables(0).Rows.Count > 0 Then
                    ds2.Tables(0).PrimaryKey = New DataColumn() {ds2.Tables(0).Columns(0)}

                    '加入空白列
                    Dim _row As DataRow = ds2.Tables(0).NewRow
                    _row.Item("sub_system_no") = ""
                    _row.Item("sub_system_name") = ""
                    _row.Item("cbo_sub_system") = ""
                    ds2.Tables(0).Rows.InsertAt(_row, 0)

                    tsk_sub_system_no.DataSource = ds2.Tables(0)
                    tsk_sub_system_no.DisplayMember = "cbo_sub_system"
                    tsk_sub_system_no.ValueMember = "sub_system_no"
                Else
                    '空白
                    Dim dt As New DataTable
                    dt.Columns.Add("sub_system_no")
                    dt.Columns.Add("sub_system_name")
                    dt.Columns.Add("cbo_sub_system")
                    Dim empty As DataRow = dt.Rows.Add()
                    empty.Item("sub_system_no") = ""
                    empty.Item("sub_system_name") = ""
                    empty.Item("cbo_sub_system") = ""

                    tsk_sub_system_no.DataSource = dt
                    tsk_sub_system_no.DisplayMember = "cbo_sub_system"
                    tsk_sub_system_no.ValueMember = "sub_system_no"
                End If
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

End Class
