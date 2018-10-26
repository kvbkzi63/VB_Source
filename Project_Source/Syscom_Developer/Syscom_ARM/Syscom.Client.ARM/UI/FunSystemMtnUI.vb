Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.DataSetUtil
Imports Syscom.Comm.Utility
Imports Syscom.Comm.BASE
Imports Syscom.Comm.LOG
Imports Syscom.Comm.EXP
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.Windows.Forms

Public Class FunSystemMtnUI
    Inherits IMaintainFormUI

    Dim tableName As String = "arm_fun_system"

    '繁體中文的顯示名稱
    Dim columnNameTraditional() As String = {"系統代碼", "系統名稱", "子系統代碼", "子系統名稱", "作業代碼", "作業名稱", "功能代碼", "功能名稱", "功能明細", "系統備註", "按鈕權限代碼", "按鈕權限", "排列順序", "是否有效代碼", "是否有效",
                               "建立者", "建立時間", "修改者", "修改時間"}


    '簡體體中文的顯示名稱
    Dim columnNameSimple() As String = {"系统代码", "系统名称", "子系统代码", "子系统名称", "作业代码", "作业名称", "功能代码", "功能名称", "功能明细", "系統備註", "按钮权限代码", "按钮权限", "排列顺序", "是否有效代码", "是否有效",
                               "建立者", "建立时间", "修改者", "修改时间"}


    '要顯示的名稱 - 在 initial 時 會根據 AppConfigUtil.AppLanguage 的值去設定，預設繁體中文
    Dim columnName() As String = {}

    Dim columnNameDB() As String = {"arm_system_no", "arm_system_name", "sub_system_no", "sub_system_name", "fun_task_no", "tsk_task_name", "fun_function_no", "fun_function_name", "fun_content", "Fun_System_Memo", "fun_special_flag", "fun_special_flag_name",
                                    "fun_display_order", "fun_flag_no", "fun_flag_name", "fun_creator_no", "fun_create_datetime", "fun_operator_no", "fun_update_datetime"}

    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {0, 1, 2, 3, 4, 5, 10, 13}

    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId

    '是否的 Code Type 代號
    Dim CodeTypeDC As String = "9000"

    Private CodeDs As DataSet = Nothing
    Private DCTable As DataTable = Nothing
    Dim ds1 As DataSet
    Dim ds2 As DataSet
    Dim ds3 As DataSet

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
                    lbl_SystemNo.Text = "*系統代碼"
                    lbl_SubSystemNo.Text = "*子系統代碼"
                    lbl_FunTaskNo.Text = "*作業代碼"
                    lbl_FunFunctionNo.Text = "*功能代碼"
                    lbl_FunFunctionName.Text = "*功能名稱"
                    lbl_Sort.Text = "*排列順序"
                    lbl_FunContent.Text = "*功能明細"
                    lbl_Memo.Text = "*按鈕權限"
                    lbl_DC.Text = "*是否有效"
                Case AppConfigUtil.Language.SimplifiedChinese

                    '簡體中文
                    columnName = columnNameSimple
                    lbl_SystemNo.Text = "*系统代码"
                    lbl_SubSystemNo.Text = "*子系统代码"
                    lbl_FunTaskNo.Text = "*作业代码"
                    lbl_FunFunctionNo.Text = "*功能代码"
                    lbl_FunFunctionName.Text = "*功能名称"
                    lbl_Sort.Text = "*排列顺序"
                    lbl_FunContent.Text = "*功能明细"
                    lbl_Memo.Text = "*按钮权限"
                    lbl_DC.Text = "*是否有效"
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
            sub_system_no.DataSource = dt
            sub_system_no.DisplayMember = "cbo_sub_system"
            sub_system_no.ValueMember = "sub_system_no"

            '加入空白列
            Dim dt1 As New DataTable
            dt1.Columns.Add("tsk_task_no")
            dt1.Columns.Add("tsk_task_name")
            dt1.Columns.Add("cbo_tsk_system")
            Dim empty1 As DataRow = dt1.Rows.Add()
            empty1.Item("tsk_task_no") = ""
            empty1.Item("tsk_task_name") = ""
            empty1.Item("cbo_tsk_system") = ""

            fun_task_no.DataSource = dt1
            fun_task_no.DisplayMember = "cbo_tsk_system"
            fun_task_no.ValueMember = "tsk_task_no"

            '*****************************************************************************
            '取得 顯示在畫面上的 RadioButton 的文字【是否】
            '*****************************************************************************
            '取得代碼的 Dataset  與 Datatable
            CodeDs = CmmServiceManager.getInstance.CMMSysCodeBSSysCodeQuery(CodeTypeDC)
            DCTable = CodeDs.Tables(CodeTypeDC)

            '設定至畫面上
            rbt_DCY.Text = DCTable.Rows(0).Item("code_name").ToString.Trim
            rbt_DCY.Tag = DCTable.Rows(0).Item("code_ID").ToString.Trim
            rbt_DCN.Text = DCTable.Rows(1).Item("code_name").ToString.Trim
            rbt_DCN.Tag = DCTable.Rows(1).Item("code_ID").ToString.Trim

            rbt_SpecialY.Text = rbt_DCY.Text
            rbt_SpecialY.Tag = rbt_DCY.Tag
            rbt_SpecialN.Text = rbt_DCN.Text
            rbt_SpecialN.Tag = rbt_DCN.Tag
            '*****************************************************************************

            '設定長度
            fun_function_no.MaxLength = 40
            fun_function_name.MaxLength = 60
            fun_content.MaxLength = 100
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

            row("fun_function_no") = Me.fun_function_no.Text
            row("fun_function_name") = Me.fun_function_name.Text
            row("fun_task_no") = Me.fun_task_no.SelectedValue
            row("fun_display_order") = Me.fun_display_order.Text
            row("fun_content") = Me.fun_content.Text
            If rbt_SpecialN.Checked Then
                row("fun_special_flag") = rbt_SpecialN.Tag
            ElseIf rbt_SpecialY.Checked Then
                row("fun_special_flag") = rbt_SpecialY.Tag
            End If
            If rbt_DCN.Checked Then
                row("fun_flag_no") = rbt_DCN.Tag
            ElseIf rbt_DCY.Checked Then
                row("fun_flag_no") = rbt_DCY.Tag
            End If
            row("fun_creator_no") = Me.currentUserID
            row("fun_operator_no") = row("fun_creator_no")
            row(ArmFunSystemDataTableFactory.DBColumnName.Fun_System_Memo) = txt_Memo.Text
            count = ARM.FunInsert(dsParam)

            If Not count.Equals(0) Then
                '同步更新DataGridView中的值
                updateDataGridView(buttonAction.INSERT, ARM.FunQueryByPK(dsParam.Tables(0).Rows(0).Item("fun_function_no")))
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

            row("fun_function_no") = Me.fun_function_no.Text
            row("fun_function_name") = Me.fun_function_name.Text
            row("fun_task_no") = Me.fun_task_no.SelectedValue
            row("fun_display_order") = Me.fun_display_order.Text
            row("fun_content") = Me.fun_content.Text
            If rbt_SpecialN.Checked Then
                row("fun_special_flag") = rbt_SpecialN.Tag
            ElseIf rbt_SpecialY.Checked Then
                row("fun_special_flag") = rbt_SpecialY.Tag
            End If
            If rbt_DCN.Checked Then
                row("fun_flag_no") = rbt_DCN.Tag
            ElseIf rbt_DCY.Checked Then
                row("fun_flag_no") = rbt_DCY.Tag
            End If
            row("fun_creator_no") = Me.currentUserID
            row("fun_operator_no") = row("fun_creator_no")
            row(ArmFunSystemDataTableFactory.DBColumnName.Fun_System_Memo) = txt_Memo.Text

            count = ARM.FunUpdate(dsParam)

            If Not count.Equals(0) Then
                Dim dt As DataTable = dgvShowData.DataSource
                If dt.Rows.Contains(fun_function_no.Text) Then
                    CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim _row As DataRow = dt.Rows.Find(fun_function_no.Text)
                    dgvShowData.CurrentCell = dgvShowData(6, dt.Rows.IndexOf(_row))
                    '同步更新DataGridView中的值
                    updateDataGridView(buttonAction.UPDATE, ARM.FunQueryByPK(dsParam.Tables(0).Rows(0).Item("fun_function_no")))
                Else
                    updateDataGridView(buttonAction.INSERT, ARM.FunQueryByPK(dsParam.Tables(0).Rows(0).Item("fun_function_no")))
                    dgvShowData.CurrentCell = dgvShowData(6, dgvShowData.Rows.Count - 1)
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
            row("fun_function_no") = Me.fun_function_no.Text

            count = ARM.FunDelete(dsParam.Tables(0).Rows(0).Item("fun_function_no"))

            '同步更新DataGridView中的值
            If Not count.Equals(0) Then
                Dim dt As DataTable = dgvShowData.DataSource
                If dt.Rows.Contains(fun_function_no.Text) Then
                    CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim _row As DataRow = dt.Rows.Find(fun_function_no.Text)
                    dgvShowData.CurrentCell = dgvShowData(6, dt.Rows.IndexOf(_row))
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
        Dim resultFlag As Boolean = True
        Try
            '欄位檢查
            If fieldCheckResult(buttonAction.QUERY) Then
                Return False
            End If

            Dim fun_special_flag As String = ""
            If rbt_SpecialN.Checked Then
                fun_special_flag = rbt_SpecialN.Tag
            ElseIf rbt_SpecialY.Checked Then
                fun_special_flag = rbt_SpecialY.Tag
            End If
            Dim fun_flag_no As String = ""
            If rbt_DCN.Checked Then
                fun_flag_no = rbt_DCN.Tag
            ElseIf rbt_DCY.Checked Then
                fun_flag_no = rbt_DCY.Tag
            End If

            Dim dsTemp As DataSet = ARM.FunGetAllSystem(app_system_no.SelectedValue, sub_system_no.SelectedValue, fun_task_no.SelectedValue, fun_function_no.Text.Trim, fun_function_name.Text.Trim, fun_content.Text.Trim, fun_special_flag, fun_display_order.Text.Trim, fun_flag_no)

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
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("fun_function_no").Value.ToString.Trim <> "" Then
                    fun_function_no.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("fun_function_no").Value.ToString.Trim
                Else
                    fun_function_no.Text = ""
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("fun_function_name").Value.ToString.Trim <> "" Then
                    fun_function_name.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("fun_function_name").Value.ToString.Trim
                Else
                    fun_function_name.Text = ""
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("fun_display_order").Value.ToString.Trim <> "" Then
                    fun_display_order.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("fun_display_order").Value.ToString.Trim
                Else
                    fun_display_order.Text = ""
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("fun_content").Value.ToString.Trim <> "" Then
                    fun_content.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("fun_content").Value.ToString.Trim
                Else
                    fun_content.Text = ""
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Fun_System_Memo").Value.ToString.Trim <> "" Then
                    txt_Memo.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Fun_System_Memo").Value.ToString.Trim
                Else
                    txt_Memo.Text = ""
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("app_system_no").Value.ToString.Trim <> "" Then
                    app_system_no.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("app_system_no").Value.ToString.Trim
                Else
                    app_system_no.SelectedValue = ""
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("sub_system_no").Value.ToString.Trim <> "" Then
                    sub_system_no.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("sub_system_no").Value.ToString.Trim
                Else
                    sub_system_no.SelectedValue = ""
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("fun_task_no").Value.ToString.Trim <> "" Then
                    fun_task_no.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("fun_task_no").Value.ToString.Trim
                Else
                    fun_task_no.SelectedValue = ""
                End If
                If dgvShowData.CurrentRow.Cells("fun_special_flag").Value.ToString.Equals(rbt_SpecialY.Tag) Then
                    rbt_SpecialY.Checked = True
                ElseIf dgvShowData.CurrentRow.Cells("fun_special_flag").Value.ToString.Equals(rbt_SpecialN.Tag) Then
                    rbt_SpecialN.Checked = True
                Else
                    rbt_SpecialY.Checked = False
                    rbt_SpecialN.Checked = False
                End If

                If dgvShowData.CurrentRow.Cells("fun_flag_no").Value.ToString.Equals(rbt_DCY.Tag) Then
                    rbt_DCY.Checked = True
                ElseIf dgvShowData.CurrentRow.Cells("fun_flag_no").Value.ToString.Equals(rbt_DCN.Tag) Then
                    rbt_DCN.Checked = True
                Else
                    rbt_DCY.Checked = False
                    rbt_DCN.Checked = False
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
                dsTemp.Tables(0).PrimaryKey = New DataColumn() {dsTemp.Tables(0).Columns(6)}
                dgvShowData.DataSource = dsTemp.Tables(0)

                '將欄位名稱改成中文
                For i As Integer = 0 To columnName.Length - 1
                    dgvShowData.Columns(i).HeaderText = columnName(i)
                Next

                dgvShowData.Columns("fun_create_datetime").DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"
                dgvShowData.Columns("fun_update_datetime").DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss"

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
            Dim ctl_1 As Control = fun_function_no
            Dim ctl_2 As Control = fun_function_name
            Dim ctl_3 As Control = fun_task_no
            Dim ctl_4 As Control = fun_display_order
            Dim ctl_5 As Control = fun_content
            Dim ctl_6 As Control = app_system_no
            Dim ctl_7 As Control = sub_system_no

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

                    '功能代碼
                    If Not CheckControlHasValue(ctl_1) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        errorMsg1.Append(nvl(lbl_FunFunctionNo.Text))
                        isError = True
                    End If

                    '功能名稱
                    If Not CheckControlHasValue(ctl_2) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        errorMsg1.Append(nvl(lbl_FunFunctionName.Text))
                        isError = True
                    End If

                    '作業代碼
                    If Not CheckControlHasValue(ctl_3) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        errorMsg1.Append(nvl(lbl_FunTaskNo.Text))
                        isError = True
                    End If

                    '排列順序
                    If Not CheckControlHasValue(ctl_4) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        errorMsg1.Append(nvl(lbl_Sort.Text))
                        isError = True

                        '排列順序 - 檢查是否為數字
                    ElseIf Not CheckControlIsNumber(ctl_4) Then
                        If (errorMsg2.ToString.Trim.Length > 0) Then errorMsg2.Append(",")
                        errorMsg2.Append(nvl(lbl_Sort.Text))
                        isError = True
                    End If

                    '功能明細
                    If Not CheckControlHasValue(ctl_5) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        errorMsg1.Append(nvl(lbl_FunContent.Text))
                        isError = True
                    End If

                    '特殊設定
                    If Not rbt_SpecialN.Checked And Not rbt_SpecialY.Checked Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        errorMsg1.Append(nvl(lbl_Special.Text))
                        isError = True
                    End If

                    '是否有效
                    If Not rbt_DCN.Checked And Not rbt_DCY.Checked Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        errorMsg1.Append(nvl(lbl_DC.Text))
                        isError = True
                    End If

                    '系統代碼
                    If Not CheckControlHasValue(ctl_6) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        errorMsg1.Append(nvl(lbl_SystemNo.Text))
                        isError = True
                    End If

                    '子系統代碼
                    If Not CheckControlHasValue(ctl_7) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        errorMsg1.Append(nvl(lbl_SubSystemNo.Text))
                        isError = True
                    End If

                Case buttonAction.DELETE

                    '功能代碼
                    If Not CheckControlHasValue(ctl_1) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        errorMsg1.Append(nvl(lbl_FunFunctionNo.Text))
                        isError = True
                    End If
                Case buttonAction.QUERY

                    '排列順序
                    If Not CheckControlIsNumber(ctl_4) Then
                        If (errorMsg2.ToString.Trim.Length > 0) Then errorMsg2.Append(",")
                        errorMsg2.Append(nvl(lbl_Sort.Text))
                        isError = True
                    End If
            End Select

            If (isError) Then
                '欄位check錯誤
                Dim opt(0) As String
                Dim cnt = 0
                If (errorMsg1.Length > 0) Then
                    ReDim opt(cnt)
                    '不可為空
                    opt(cnt) = errorMsg1.ToString & checkMsg(0)
                    cnt += 1
                End If
                If (errorMsg2.Length > 0) Then
                    ReDim opt(cnt)
                    '必須為數字
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
            fun_function_no.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            fun_function_name.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            fun_task_no.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            fun_display_order.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            fun_content.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            app_system_no.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            sub_system_no.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
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

                    sub_system_no.DataSource = ds2.Tables(0)
                    sub_system_no.DisplayMember = "cbo_sub_system"
                    sub_system_no.ValueMember = "sub_system_no"
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

                    sub_system_no.DataSource = dt
                    sub_system_no.DisplayMember = "cbo_sub_system"
                    sub_system_no.ValueMember = "sub_system_no"
                End If
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub sub_system_no_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sub_system_no.SelectedIndexChanged
        Try
            If sub_system_no.SelectedValue IsNot Nothing AndAlso TypeOf sub_system_no.SelectedValue Is String Then
                ds3 = ARM.TskGetTskSystemCombobox(sub_system_no.SelectedValue)
                If ds3.Tables(0).Rows.Count > 0 Then
                    ds3.Tables(0).PrimaryKey = New DataColumn() {ds3.Tables(0).Columns(0)}

                    '加入空白列
                    Dim _row As DataRow = ds3.Tables(0).NewRow
                    _row.Item("tsk_task_no") = ""
                    _row.Item("tsk_task_name") = ""
                    _row.Item("cbo_tsk_system") = ""
                    ds3.Tables(0).Rows.InsertAt(_row, 0)

                    fun_task_no.DataSource = ds3.Tables(0)
                    fun_task_no.DisplayMember = "cbo_tsk_system"
                    fun_task_no.ValueMember = "tsk_task_no"
                Else
                    '空白
                    Dim dt As New DataTable
                    dt.Columns.Add("tsk_task_no")
                    dt.Columns.Add("tsk_task_name")
                    dt.Columns.Add("cbo_tsk_system")
                    Dim empty As DataRow = dt.Rows.Add()
                    empty.Item("tsk_task_no") = ""
                    empty.Item("tsk_task_name") = ""
                    empty.Item("cbo_tsk_system") = ""

                    fun_task_no.DataSource = dt
                    fun_task_no.DisplayMember = "cbo_tsk_system"
                    fun_task_no.ValueMember = "tsk_task_no"
                End If
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

End Class
