Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports Syscom.Comm.BASE
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.Windows.Forms

Public Class RoleMtnUI
    Inherits BaseFormUI

    Enum buttonAction
        INSERT
        UPDATE
        DELETE
        QUERY
        CLEAR
        ROLERIGHTS
    End Enum

    Dim tableName As String = "Role"

    '繁體中文的顯示名稱
    Dim columnNameTraditional As String = "角色代碼,角色名稱,是否有效代碼,是否有效,是否允許授權代碼,是否允許授權,建立者,建立時間,修改者,修改時間,opd_flag, eis_flag, pcs_flag,備註,控制刪除"

    '簡體體中文的顯示名稱
    Dim columnNameSimple As String = "角色代码,角色名称,是否有效代码,是否有效,是否允许授权代码,是否允许授权,建立者,建立时间,修改者,修改时间,opd_flag, eis_flag, pcs_flag,备注,控制删除"

    '要顯示的名稱 - 在 initial 時 會根據 AppConfigUtil.AppLanguage 的值去設定，預設繁體中文
    Dim columnName As String = ""

    Dim columnNameDB() As String = {"roleID", "roleName", "isValid", "isValidName", "isAgent", "isAgentName", _
                                    "creator_no", "create_datetime", "operator_no", "update_datetime", "opd_flag", "eis_flag", "pcs_flag", "roleMember", "del_Flag"}

    '設定隱藏的欄位
    Dim visibleColumnNo As String = "2,4,10,11,12"

    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId

    '是否的 Code Type 代號
    Dim CodeTypeDC As String = "9000"

    Private CodeDs As DataSet = Nothing
    Private DCTable As DataTable = Nothing
    Private AgentTable As DataTable = Nothing

    Public Sub initialData()
        Try
            '載入ArmServiceManager的Instance()
            loadArmServiceManager()

            '設定Column 要使用哪一個，必須在 顯示DataGridView(showResult) 之前
            '設定UI的名稱字樣
            Select Case AppConfigUtil.AppLanguage
                Case AppConfigUtil.Language.TraditionalChinese

                    '繁體中文
                    columnName = columnNameTraditional
                    lbl_roleID.Text = "*角色代碼"
                    lbl_roleName.Text = "*角色名稱"
                    lbl_DC.Text = "*是否有效"
                    lbl_isAgent.Text = "是否允許授權"
                    lbl_Member.Text = "備註"
                    btnInsert.Text = "F12-新增"
                    btnUpdate.Text = "F10-修改"
                    btnDelete.Text = "SF12-刪除"
                    btnClear.Text = "F5-清除"
                    btnQuery.Text = "F1-查詢"
                    btn_RoleRightsMtn.Text = "角色權限設定"
                Case AppConfigUtil.Language.SimplifiedChinese

                    '簡體中文
                    columnName = columnNameSimple
                    lbl_roleID.Text = "*角色代码"
                    lbl_roleName.Text = "*角色名称"
                    lbl_DC.Text = "*是否有效"
                    lbl_isAgent.Text = "是否允许授权"
                    lbl_Member.Text = "备注"
                    btnInsert.Text = "F3-新增"
                    btnUpdate.Text = "F4-修改"
                    btnDelete.Text = "F5-删除"
                    btnClear.Text = "F6-清除"
                    btnQuery.Text = "F2-查询"
                    btn_RoleRightsMtn.Text = "角色权限设定"
            End Select
 

            showResult(getDataSetFromUI())
            clearData()

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

            AgentTable = CodeDs.Tables(CodeTypeDC).Copy
            '設定至畫面上
            rdo_IsAgentY.Text = AgentTable.Rows(0).Item("code_name").ToString.Trim
            rdo_IsAgentY.Tag = AgentTable.Rows(0).Item("code_ID").ToString.Trim
            rdo_IsAgentN.Text = AgentTable.Rows(1).Item("code_name").ToString.Trim
            rdo_IsAgentN.Tag = AgentTable.Rows(1).Item("code_ID").ToString.Trim
            '*****************************************************************************

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Public Function insertData() As Boolean
        Dim role As DataSet = getDataSetFromUI()
        Dim resultFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(buttonAction.INSERT) Then
            Return False
        End If

        Try
            role.Tables(0).Rows(0).Item("creator_no") = AppContext.userProfile.userId
            role.Tables(0).Rows(0).Item("create_datetime") = Now.ToString("yyyy/MM/dd HH:mm:ss")

            ARM.AddRole(role)

            Dim valid As String
            If RdoBtnY.Checked Then
                valid = RdoBtnY.Tag
            ElseIf RdoBtnN.Checked Then
                valid = RdoBtnN.Tag
            Else
                valid = ""
            End If
            Dim validName As String
            If valid.Equals(RdoBtnY.Tag) Then
                validName = nvl(RdoBtnY.Text)
            ElseIf valid.Equals(RdoBtnN.Tag) Then
                validName = nvl(RdoBtnN.Text)
            Else
                validName = ""
            End If
            Dim agent As String
            If rdo_IsAgentY.Checked Then
                agent = rdo_IsAgentY.Tag
            ElseIf rdo_IsAgentN.Checked Then
                agent = rdo_IsAgentN.Tag
            Else
                agent = ""
            End If
            Dim agentName As String
            If agent.Equals(rdo_IsAgentY.Tag) Then
                agentName = nvl(rdo_IsAgentY.Text)
            ElseIf agent.Equals(rdo_IsAgentN.Tag) Then
                agentName = nvl(rdo_IsAgentN.Text)
            Else
                agentName = ""
            End If

            Dim chkdeleteFlag As String = ""
            If Chk_DeleteFlag.Checked = True Then
                chkdeleteFlag = "Y"
            End If

            Dim row() As String = {roleID.Text, roleName.Text, valid, validName, agent, agentName, AppContext.userProfile.userId, _
                                   Now.ToString("yyyy/MM/dd HH:mm:ss"), AppContext.userProfile.userId, _
                                   Now.ToString("yyyy/MM/dd HH:mm:ss"), "Y", "Y", "Y", txt_Member.Text.Trim, chkdeleteFlag}

            dgv_ShowData.GetGridDS.Tables(0).Rows.Add(row)
            dgv_ShowData.GetDBDS.Tables(0).Rows.Add(row)
            'dgv_ShowData.Refresh()
            Return resultFlag
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Function updateData() As Boolean
        Dim arole As DataSet = getDataSetFromUI()
        Dim resultFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(buttonAction.UPDATE) Then
            Return False
        End If

        Try
            Dim count As Integer = ARM.ModifyRole(arole)
            If count > 0 Then
                Dim dt As DataTable = dgv_ShowData.GetDBDS.Tables(0)
                dt.PrimaryKey = New DataColumn() {dt.Columns("roleID")}
                If dt.Rows.Contains(roleID.Text) Then
                    Dim row As DataRow = dt.Rows.Find(roleID.Text)
                    dgv_ShowData.CurrentCell = dgv_ShowData.Rows(dt.Rows.IndexOf(row)).Cells(0)
                    dgv_ShowData.CurrentRow.Cells("roleID").Value = arole.Tables(0).Rows(0).Item("roleID")
                    dgv_ShowData.CurrentRow.Cells("roleName").Value = arole.Tables(0).Rows(0).Item("roleName")
                    dgv_ShowData.CurrentRow.Cells("isValid").Value = arole.Tables(0).Rows(0).Item("isValid")
                    If arole.Tables(0).Rows(0).Item("isValid").ToString.Equals("Y") Then
                        dgv_ShowData.CurrentRow.Cells("isValidName").Value = nvl(RdoBtnY.Text)
                    ElseIf arole.Tables(0).Rows(0).Item("isValid").ToString.Equals("N") Then
                        dgv_ShowData.CurrentRow.Cells("isValidName").Value = nvl(RdoBtnN.Text)
                    Else
                        Throw New Exception("不明的有效註記!")
                    End If
                    If arole.Tables(0).Rows(0).Item("isAgent").ToString.Equals("Y") Then
                        dgv_ShowData.CurrentRow.Cells("isAgentName").Value = nvl(RdoBtnY.Text)
                    ElseIf arole.Tables(0).Rows(0).Item("isAgent").ToString.Equals("N") Then
                        dgv_ShowData.CurrentRow.Cells("isAgentName").Value = nvl(RdoBtnN.Text)
                    Else
                        Throw New Exception("不明的註記!")
                    End If
                    dgv_ShowData.CurrentRow.Cells("operator_no").Value = arole.Tables(0).Rows(0).Item("operator_no")
                    dgv_ShowData.CurrentRow.Cells("update_datetime").Value = arole.Tables(0).Rows(0).Item("update_datetime")
                    dgv_ShowData.CurrentRow.Cells("roleMember").Value = arole.Tables(0).Rows(0).Item("roleMember")
                    dgv_ShowData.CurrentRow.Cells("del_Flag").Value = arole.Tables(0).Rows(0).Item("del_Flag")

                Else
                    Dim valid As String
                    If RdoBtnY.Checked Then
                        valid = RdoBtnY.Tag
                    ElseIf RdoBtnN.Checked Then
                        valid = RdoBtnN.Tag
                    Else
                        valid = ""
                    End If
                    If valid.Equals(RdoBtnY.Tag) Then
                        dt.Rows(0).Item("isValidName") = nvl(RdoBtnY.Text)
                    ElseIf valid.Equals(RdoBtnN.Tag) Then
                        dt.Rows(0).Item("isValidName") = nvl(RdoBtnN.Text)
                    Else
                        dt.Rows(0).Item("isValidName") = ""
                    End If
                    Dim agent As String
                    If rdo_IsAgentY.Checked Then
                        agent = rdo_IsAgentY.Tag
                    ElseIf rdo_IsAgentN.Checked Then
                        agent = rdo_IsAgentN.Tag
                    Else
                        agent = ""
                    End If
                    If agent.Equals(rdo_IsAgentY.Tag) Then
                        dt.Rows(0).Item("isAgentName") = nvl(rdo_IsAgentY.Text)
                    ElseIf valid.Equals(rdo_IsAgentN.Tag) Then
                        dt.Rows(0).Item("isAgentName") = nvl(rdo_IsAgentN.Text)
                    Else
                        dt.Rows(0).Item("isAgentName") = ""
                    End If
                    Dim chkdeleteFlag As String = ""
                    If Chk_DeleteFlag.Checked = True Then
                        chkdeleteFlag = "Y"
                    End If

                    Dim row() As String = {roleID.Text, roleName.Text, valid, dt.Rows(0).Item("isValidName"), agent, dt.Rows(0).Item("isAgentName"), AppContext.userProfile.userId, _
                                       Now.ToString("yyyy/MM/dd HH:mm:ss"), AppContext.userProfile.userId, _
                                       Now.ToString("yyyy/MM/dd HH:mm:ss"), txt_Member.Text.Trim, chkdeleteFlag}
                    dgv_ShowData.GetGridDS.Tables(0).Rows.Add(row)
                    dgv_ShowData.CurrentCell = dgv_ShowData.Rows(dgv_ShowData.Rows.Count - 1).Cells(0)
                End If
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB310", New String() {"修改"})
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

    Public Function deleteData() As Boolean
        Dim arole As DataSet = getDataSetFromUI()
        Dim resultFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(buttonAction.DELETE) Then
            Return False
        End If

        Try
            ARM.DeleteRole(arole)

            Dim dt As DataTable = dgv_ShowData.GetDBDS.Tables(0)
            dt.PrimaryKey = New DataColumn() {dt.Columns("roleID")}
            If dt.Rows.Contains(roleID.Text) Then
                Dim row As DataRow = dt.Rows.Find(roleID.Text)
                dgv_ShowData.CurrentCell = dgv_ShowData.Rows(dt.Rows.IndexOf(row)).Cells(0)
            End If
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

    Public Function queryData() As Boolean
        Dim arole As DataSet = getDataSetFromUI()
        Dim resultFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(buttonAction.QUERY) Then
            Return False
        End If

        Try
            Dim isValid As String = ""
            If RdoBtnY.Checked Then
                isValid = "Y"
            ElseIf RdoBtnN.Checked Then
                isValid = "N"
            Else
                isValid = ""
            End If

            Dim resultDSet As DataSet = ARM.QueryRole(roleID.Text.Trim, roleName.Text.Trim, isValid)
            If resultDSet.Tables.Count = 0 Then
                resultDSet = getDataSetFromUI()
                resultDSet.Tables(0).Rows.Clear()
            End If

            showResult(resultDSet)

            If dgv_ShowData.Rows.Count = 0 Then
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

    Public Sub clearData()
        Try
            '清除上方區域資料並Disable按鈕
            UCLScreenUtil.CleanControls(Me.tlp_nonButton)
            dgv_ShowData.ClearDS()

            '清除欄位背景顏色
            cleanFieldsColor()

            RdoBtnY.Checked = True
            rdo_IsAgentN.Checked = True


        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Public Sub dgvCellClick()
        Try
            '清除欄位背景顏色
            cleanFieldsColor()
            If dgv_ShowData.CurrentCellAddress.Y >= 0 Then
                If dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("roleID").Value.ToString.Trim <> "" Then
                    roleID.Text = dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("roleID").Value.ToString.Trim
                Else
                    roleID.Text = ""
                End If
                If dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("roleName").Value.ToString.Trim <> "" Then
                    roleName.Text = dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("roleName").Value.ToString.Trim
                Else
                    roleName.Text = ""
                End If
                If dgv_ShowData.CurrentRow.Cells("isValid").Value.ToString.ToUpper.Trim.Equals(RdoBtnY.Tag) Then
                    RdoBtnY.Checked = True
                ElseIf dgv_ShowData.CurrentRow.Cells("isValid").Value.ToString.ToUpper.Trim.Equals(RdoBtnN.Tag) Then
                    RdoBtnN.Checked = True
                Else
                    RdoBtnY.Checked = False
                    RdoBtnN.Checked = False
                End If
                If dgv_ShowData.CurrentRow.Cells("isAgent").Value.ToString.ToUpper.Trim.Equals(rdo_IsAgentY.Tag) Then
                    rdo_IsAgentY.Checked = True
                ElseIf dgv_ShowData.CurrentRow.Cells("isAgent").Value.ToString.ToUpper.Trim.Equals(rdo_IsAgentN.Tag) Then
                    rdo_IsAgentN.Checked = True
                Else
                    rdo_IsAgentY.Checked = False
                    rdo_IsAgentN.Checked = False
                End If

                txt_Member.Text = dgv_ShowData.CurrentRow.Cells("roleMember").Value.ToString

                If dgv_ShowData.CurrentRow.Cells("del_Flag").Value.ToString = "Y" Then
                    Chk_DeleteFlag.Checked = True
                Else
                    Chk_DeleteFlag.Checked = False
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
            Dim ctl_1 As Control = roleID
            Dim ctl_2 As Control = roleName

            '清除欄位背景顏色
            cleanFieldsColor()

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

            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case msgTitle
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not CheckControlHasValue(ctl_1) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '角色代碼
                        errorMsg1.Append(nvl(lbl_roleID.Text))
                        isError = True
                    End If
                    If Not CheckControlHasValue(ctl_2) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '角色名稱
                        errorMsg1.Append(nvl(lbl_roleName.Text))
                        isError = True
                    End If
                    If Not RdoBtnN.Checked And Not RdoBtnY.Checked Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '是否有效
                        errorMsg1.Append(nvl(lbl_DC.Text))
                        isError = True
                    End If
                Case buttonAction.DELETE
                    If Not CheckControlHasValue(ctl_1) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '角色代碼
                        errorMsg1.Append(nvl(lbl_roleID.Text))
                        isError = True
                    End If
                Case buttonAction.ROLERIGHTS
                    If Not CheckControlHasValue(ctl_1) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '角色代碼
                        errorMsg1.Append(nvl(lbl_roleID.Text))
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
            roleID.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            roleName.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
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

#Region " HotKey設定"

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case AppConfigUtil.AppLanguage
            Case AppConfigUtil.Language.TraditionalChinese
                Select Case e.KeyCode
                    Case Keys.F5
                        '清除
                        btnClear_Click(sender, e)
                    Case Keys.F12
                        '刪除 SF12
                        If e.Shift Then
                            If (btnDelete.Enabled) Then btnDelete_Click(sender, e)
                        Else
                            '新增F12
                            If (btnInsert.Enabled) Then btnInsert_Click(sender, e)
                        End If
                    Case Keys.F10
                        '修改
                        If (btnUpdate.Enabled) Then btnUpdate_Click(sender, e)
                    Case Keys.F1
                        '查詢
                        btnQuery_Click(sender, e)
                    Case Keys.Escape
                        '退出
                        btnEsc_Click(sender, e)
                    Case Keys.Enter
                        Me.ProcessTabKey(True)
                End Select
            Case AppConfigUtil.Language.SimplifiedChinese
                Select Case e.KeyCode
                    'Enter 模擬 Tab
                    Case Keys.Enter
                        Me.ProcessTabKey(True)
                    Case Keys.F2
                        '查詢
                        If btnQuery.Enabled Then
                            btnQuery.PerformClick()
                        End If
                    Case Keys.F3
                        '新增
                        If (btnInsert.Enabled) Then
                            btnInsert.PerformClick()
                        End If
                    Case Keys.F4
                        '修改
                        If btnUpdate.Enabled Then
                            btnUpdate.PerformClick()
                        End If
                    Case Keys.F5
                        '刪除
                        If (btnDelete.Enabled) Then
                            btnDelete.PerformClick()
                        End If
                    Case Keys.F6
                        '清除
                        If btnClear.Enabled Then
                            btnClear.PerformClick()
                        End If
                    Case Keys.Enter
                        Me.ProcessTabKey(True)
                End Select
        End Select
    End Sub

#End Region

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Try
            UCLScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()
            If (insertData()) Then
                controlButton(buttonAction.INSERT)
                '將新增進去的資料反白
                dgv_ShowData.CurrentCell = dgv_ShowData.Rows(dgv_ShowData.Rows.Count - 1).Cells(0)
                MessageHandling.ShowInfoMsg("CMMCMMB902", New String() {})
            End If
            checkDeleteFlag()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            MessageHandling.ClearInfoMsg()
            UCLScreenUtil.Lock(Me)
            If (updateData()) Then
                MessageHandling.ShowInfoMsg("CMMCMMB903", New String() {})
            End If
            checkDeleteFlag()
        Catch ex As Exception
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            MessageHandling.ClearInfoMsg()
            Dim ds As DataSet = ARM.EmployeeQueryByRole(roleID.Text.Trim)
            Dim Result As Windows.Forms.DialogResult = Nothing
            If ds.Tables(0).Rows.Count > 0 Then 'CMMCMMB300
                Result = MessageHandling.ShowQuestionMsg("CMMCMMB300", New String() {"仍有使用者賦予該角色，是否仍要刪除"})
            Else
                Result = MessageHandling.ShowQuestionMsg("CMMCMMB932", New String() {})
            End If
            If Result = Windows.Forms.DialogResult.Yes Then
                UCLScreenUtil.Lock(Me)
                If (deleteData()) Then
                    controlButton(buttonAction.DELETE)
                    '將資料從datagridview中移除
                    dgv_ShowData.GetDBDS.Tables(0).Rows.RemoveAt(dgv_ShowData.CurrentRow.Index)
                    dgv_ShowData.GetGridDS.Tables(0).Rows.RemoveAt(dgv_ShowData.CurrentRow.Index)
                    If dgv_ShowData.CurrentRow IsNot Nothing Then
                        dgv_ShowData.CurrentRow.Selected = False
                    End If
                    MessageHandling.ShowInfoMsg("CMMCMMB904", New String() {})
                End If
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Try
            MessageHandling.ClearInfoMsg()
            UCLScreenUtil.Lock(Me)
            If (queryData()) Then
                controlButton(buttonAction.QUERY)
                If (dgv_ShowData.CurrentRow IsNot Nothing AndAlso dgv_ShowData.CurrentRow.Index >= 0) Then dgv_ShowData.CurrentRow.Selected = False
                MessageHandling.ShowInfoMsg("CMMCMMB901", New String() {})
            End If
        Catch ex As Exception
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            MessageHandling.ClearInfoMsg()
            clearData()
            controlButton(buttonAction.CLEAR)
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub btnEsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEsc.Click
        Try
            MessageHandling.ClearInfoMsg()
            Me.Close()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub RoleRightsMtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RoleRightsMtn.Click
        Try
            MessageHandling.ClearInfoMsg()
            If Not fieldCheckResult(buttonAction.ROLERIGHTS) Then
                Dim roleRight As New RoleRightsMtnUI(roleID.Text, roleName.Text)
                roleRight.ShowDialog()
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub RoleMtnUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            initialData()
            initializeButton()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 根據按下的按鈕控制按鈕的狀態
    ''' </summary>
    ''' <param name="action"></param>
    ''' <remarks></remarks>
    Private Sub controlButton(ByVal action As buttonAction)
        Try
            Select Case action
                Case buttonAction.QUERY, buttonAction.UPDATE, buttonAction.DELETE, buttonAction.CLEAR
                    initializeButton()
                Case buttonAction.INSERT
                    changedButton()
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
    ''' 初始化按鈕的狀態
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initializeButton()
        Try
            If Me.Tag IsNot Nothing Then
                Dim funNo As String = Me.Tag.ToString.Split(",")(2)
                Dim queryRow As DataRow = Nothing
                If dsButtonControl.Tables(0).Rows.Contains(funNo) Then
                    queryRow = dsButtonControl.Tables(0).Rows.Find(funNo)
                    btnInsert.Enabled = False
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    btnQuery.Enabled = False
                    btnClear.Enabled = True
                    If queryRow("btnInsert_Flag").ToString.Trim.Equals("Y") Then
                        btnInsert.Enabled = True
                    End If
                    If queryRow("btnQuery_Flag").ToString.Trim.Equals("Y") Then
                        btnQuery.Enabled = True
                    End If
                Else
                    btnInsert.Enabled = True
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    btnQuery.Enabled = True
                    btnClear.Enabled = True
                End If
            End If

            btn_RoleRightsMtn.Enabled = False
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 改變按鈕的狀態
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub changedButton()
        Try
            If Me.Tag IsNot Nothing Then
                Dim funNo As String = Me.Tag.ToString.Split(",")(2)
                Dim queryRow As DataRow = Nothing
                If dsButtonControl.Tables(0).Rows.Contains(funNo) Then
                    queryRow = dsButtonControl.Tables(0).Rows.Find(funNo)
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    If queryRow("btnUpdate_Flag").ToString.Trim.Equals("Y") Then
                        btnUpdate.Enabled = True
                    End If
                    If queryRow("btnDelete_Flag").ToString.Trim.Equals("Y") Then
                        btnDelete.Enabled = True
                    End If

                Else
                    btnUpdate.Enabled = True
                    btnDelete.Enabled = True
                End If
            End If



            btn_RoleRightsMtn.Enabled = True
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Function getDataSetFromUI() As DataSet
        Try
            Dim roleSet As DataSet = New DataSet
            Dim dtable As DataTable = New DataTable
            dtable.TableName = "Role"

            For Each columnName As String In columnNameDB
                dtable.Columns.Add(columnName)
            Next

            Dim valid As String = ""
            Dim validName As String = ""
            If RdoBtnY.Checked Then
                valid = RdoBtnY.Tag
                validName = RdoBtnY.Text
            ElseIf RdoBtnN.Checked Then
                valid = RdoBtnN.Tag
                validName = RdoBtnN.Text
            End If

            Dim agent As String = ""
            Dim agentName As String = ""
            If rdo_IsAgentY.Checked Then
                agent = rdo_IsAgentY.Tag
                agentName = rdo_IsAgentY.Text
            ElseIf rdo_IsAgentN.Checked Then
                agent = rdo_IsAgentN.Tag
                agentName = rdo_IsAgentN.Text
            End If

            Dim chkdeleteFlag As String = ""
            If Chk_DeleteFlag.Checked = True Then
                chkdeleteFlag = "Y"
            End If


            Dim valueArray() As Object = {roleID.Text.Trim, roleName.Text.Trim, valid, validName, agent, agentName, AppContext.userProfile.userId, Now.ToString("yyyy/MM/dd HH:mm:ss"), AppContext.userProfile.userId, Now.ToString("yyyy/MM/dd HH:mm:ss"), "Y", "Y", "Y", txt_Member.Text.Trim, chkdeleteFlag}
            dtable.Rows.Add(valueArray)
            roleSet.Tables.Add(dtable)
            Return roleSet
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Private Sub dgv_ShowData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_ShowData.CellClick
        Try
            If (e.RowIndex >= 0) Then
                dgvCellClick()
                changedButton()
                checkDeleteFlag()
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 顯示最新的資料在DataGridView
    ''' </summary>
    ''' <param name="ds">要show在DataGridView中的資料</param>
    ''' <remarks></remarks>
    Private Sub showResult(ByVal ds As DataSet)
        Try
            '清除所有的欄位
            If ds.Tables.Count > 0 Then
                ds.Tables(0).PrimaryKey = New DataColumn() {ds.Tables(0).Columns(0)}
                dgv_ShowData.Initial(ds)
                dgv_ShowData.uclHeaderText = columnName
                dgv_ShowData.uclNonVisibleColIndex = visibleColumnNo
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub
    Sub checkDeleteFlag()
        If Chk_DeleteFlag.Checked = True Then
            btnDelete.Enabled = False
        Else
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub Chk_DeleteFlag_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_DeleteFlag.CheckedChanged
        If roleID.Text.Trim <> "" Then
            checkDeleteFlag()
        End If

    End Sub
End Class
