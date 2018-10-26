Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.BASE
Imports Syscom.Comm.EXP
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports Syscom.Comm.BASE.HospConfigUtil
Imports System.Windows.Forms

Public Class UserMtnUI
    Inherits Syscom.Client.UCL.BaseFormUI

    Enum buttonAction
        INSERT
        UPDATE
        DELETE
        QUERY
        CLEAR
        CHANGEPWD
        ROLESET
    End Enum

    Private CMM As ICmmServiceManager = Nothing
    Private tableName As String = "User"

    '繁體中文的顯示名稱
    Private columnNameTraditional As String = "使用者代碼,使用者姓名,使用者英文姓名,身分證號,生日,是否有效代碼,是否有效,電子郵件,行動電話,職稱代碼,職稱,部門代碼,部門,院區代碼,院區,到職日期,離職日期,建立者,建立時間,角色修改者,角色修改時間"

    '台南增加職級欄位
    Private columnNameTraditionalTn As String = "使用者代碼,使用者姓名,使用者英文姓名,身分證號,生日,是否有效代碼,是否有效,電子郵件,行動電話,職稱代碼,職稱,部門代碼,部門,院區代碼,院區,到職日期,離職日期,建立者,建立時間,修改者,修改時間,職級"

    '簡體體中文的顯示名稱
    Private columnNameSimple As String = "使用者代码,使用者姓名,使用者英文姓名,身分证号,生日,是否有效代码,是否有效,电子邮件,行动电话,职称代码,职称,部门代码,部门,院区代码,院区,到职日期,离职日期,建立者,建立时间,修改者,修改时间"

    '要顯示的名稱 - 在 initial 時 會根據 AppConfigUtil.AppLanguage 的值去設定，預設繁體中文
    Private columnName As String = ""

    Private columnNameDB() As String = {"userid", "username", "Employee_En_Name", "idno", "birthday", "isvalid", "isvalidName", "mail", "Tel_Mobile", "Professal_Kind_Id", "Professal_Kind_Name", "Dept_Code", "Dept_Name", "Section_Code", "Section_Name", _
                                    "Assume_Effect_Date", "Assume_End_Date", "creator_no", "create_datetime", "operator_no", "update_datetime"}

    '台南增加職級欄位
    Private columnNameTnDB() As String = {"userid", "username", "Employee_En_Name", "idno", "birthday", "isvalid", "isvalidName", "mail", "Tel_Mobile", "Professal_Kind_Id", "Professal_Kind_Name", "Dept_Code", "Dept_Name", "Section_Code", "Section_Name", _
                                "Assume_Effect_Date", "Assume_End_Date", "creator_no", "create_datetime", "operator_no", "update_datetime", "Nrs_Level_Id"}

    '設定隱藏的欄位
    Private visibleColumnNo As String = "2,4,5,6,8,9,13,14"

    '目前使用者的ID
    Private currentUserID As String = AppContext.userProfile.userId

    '是否的 Code Type 代號
    Private CodeTypeDC As String = "9000"
    Private CodeTypeJobTitle As String = "1101"

    '存放院區選單資料的DS
    Private globalSectionDs As DataSet

    '存放部門選單資料的DS
    Private globalDeptDs As DataSet

    Private CodeDs As DataSet = Nothing
    Private DCTable As DataTable = Nothing
    Private JobTitleTable As DataTable = Nothing

    Public Sub initialData()
        '只限台南醫院====================================
        Btn_ResetPwd.Visible = False
        Select Case HospConfigUtil.HospConfig
            Case HospConfigUtil.hospConfigList.Tw_Tnhosp
                Btn_ResetPwd.Visible = True
                '職級
                lblNrsLevelID.Visible = True
                txtNrsLevelID.Visible = True
        End Select
        '================================================
        Try
            '載入ServiceManager的Instance()
            loadServiceManager()

            '設定Column 要使用哪一個，必須在 顯示DataGridView(showResult) 之前
            '設定UI的名稱字樣
            Select Case AppConfigUtil.AppLanguage
                Case AppConfigUtil.Language.TraditionalChinese

                    '繁體中文
                    If HospConfig = hospConfigList.Tw_Tnhosp Then
                        '台南增加職級欄位
                        columnName = columnNameTraditionalTn
                    Else
                        columnName = columnNameTraditional
                    End If
                    lbl_userid.Text = "*使用者代號"
                    lbl_username.Text = "*使用者姓名"
                    lbl_birthday.Text = "*生日"
                    lbl_DCYN.Text = "*是否有效"
                    lbl_Dept_Name.Text = "*部門"

                    lbl_mail.Text = "*電子郵件"
                    lbl_Section.Text = "*院區"
                    btnInsert.Text = "F12-新增"
                    btnUpdate.Text = "F10-修改"
                    btnDelete.Text = "SF12-刪除"
                    btnClear.Text = "F5-清除"
                    btnQuery.Text = "F1-查詢"
                    btnResetPw.Text = "修改密碼"
                    btnRoleSet.Text = "角色設定"

                Case AppConfigUtil.Language.SimplifiedChinese

                    '簡體中文
                    columnName = columnNameSimple
                    lbl_userid.Text = "*使用者代号"
                    lbl_username.Text = "*使用者姓名"
                    lbl_birthday.Text = "*生日"
                    lbl_DCYN.Text = "*是否有效"
                    lbl_Dept_Name.Text = "*部门"

                    lbl_mail.Text = "*电子邮件"
                    lbl_Section.Text = "*院区"
                    btnInsert.Text = "F3-新增"
                    btnUpdate.Text = "F4-修改"
                    btnDelete.Text = "F5-删除"
                    btnClear.Text = "F6-清除"
                    btnQuery.Text = "F2-查询"
                    btnResetPw.Text = "修改密码"
                    btnRoleSet.Text = "角色设定"

            End Select

            showResult(getDataSetFromUI())
            clearData()

            '*****************************************************************************
            '取得 顯示在畫面上的 RadioButton 的文字【是否】
            '*****************************************************************************
            '取得代碼的 Dataset  與 Datatable
            CodeDs = CMM.CMMSysCodeBSSysCodeQueryMuti(New Integer() {CodeTypeDC, CodeTypeJobTitle})
            DCTable = CodeDs.Tables(CodeTypeDC)

            '設定至畫面上
            RdoBtnY.Text = DCTable.Rows(0).Item("code_name").ToString.Trim
            RdoBtnY.Tag = DCTable.Rows(0).Item("code_ID").ToString.Trim
            RdoBtnN.Text = DCTable.Rows(1).Item("code_name").ToString.Trim
            RdoBtnN.Tag = DCTable.Rows(1).Item("code_ID").ToString.Trim
            '*****************************************************************************
            '取得 顯示在畫面上的 RadioButton 的文字【是否】
            '*****************************************************************************
            '取得代碼的 Dataset  與 Datatable
            JobTitleTable = CodeDs.Tables(CodeTypeJobTitle)

            cbo_JobTitle.Initial(JobTitleTable)
            cbo_JobTitle.uclDisplayIndex = "1"
            cbo_JobTitle.uclValueIndex = "0"

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
        Dim user As DataSet = getDataSetFromUI()
        Dim resultFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(buttonAction.INSERT) Then
            Return False
        End If

        Try
            With user.Tables(0).Rows(0)
                .Item("creator_no") = AppContext.userProfile.userId
                .Item("create_datetime") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                .Item("operator_no") = AppContext.userProfile.userId
                .Item("update_datetime") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            End With

            Try

                ARM.AddUser(user)

            Catch ex As Exception
                'Pkey重複 - 更改錯誤訊息
                If ex.ToString.Contains("SQL 錯誤代碼(2627)") Then
                    Syscom.Client.CMM.MessageHandling.ShowWarnMsg("CMMCMMB300", "使用者已經存在，新增失敗!")
                    Return False
                    Exit Function
                End If
            End Try

            Dim valid As String
            Dim validName As String
            If RdoBtnY.Checked Then
                valid = RdoBtnY.Tag
                validName = RdoBtnY.Text
            ElseIf RdoBtnN.Checked Then
                valid = RdoBtnN.Tag
                validName = RdoBtnN.Text
            Else
                valid = ""
                validName = ""
            End If

            If HospConfig = hospConfigList.Tw_Tnhosp Then
                '台南增加職級欄位
                Dim row() As String = {userid.Text, username.Text, "", IdTxtBox.Text.Trim.ToUpper, user.Tables("User").Rows(0).Item("birthday"), valid, validName, mail.Text, "", "", "", _
                                      tcq_DeptCode.getCode, tcq_DeptCode.getCodeName, UclCbo_Section.SelectedValue, UclCbo_Section.SelectedText, DateUtil.TransDateToROC(Now), DateUtil.TransDateToROC("2099/12/31"), AppContext.userProfile.userId, _
                                       DateUtil.TransDateToROC(Now) & Now.ToString(" HH:mm:ss"), AppContext.userProfile.userId, _
                                       DateUtil.TransDateToROC(Now) & Now.ToString(" HH:mm:ss"), txtNrsLevelID.Text}
                dgv_ShowData.GetGridDS.Tables(0).Rows.Add(row)
                dgv_ShowData.GetDBDS.Tables(0).Rows.Add(row)
            Else
                Dim row() As String = {userid.Text, username.Text, "", IdTxtBox.Text.Trim.ToUpper, user.Tables("User").Rows(0).Item("birthday"), valid, validName, mail.Text, "", "", "", _
                                      tcq_DeptCode.getCode, tcq_DeptCode.getCodeName, UclCbo_Section.SelectedValue, UclCbo_Section.SelectedText, DateUtil.TransDateToROC(Now), DateUtil.TransDateToROC("2099/12/31"), AppContext.userProfile.userId, _
                                       DateUtil.TransDateToROC(Now) & Now.ToString(" HH:mm:ss"), AppContext.userProfile.userId, _
                                       DateUtil.TransDateToROC(Now) & Now.ToString(" HH:mm:ss")}
                dgv_ShowData.GetGridDS.Tables(0).Rows.Add(row)
                dgv_ShowData.GetDBDS.Tables(0).Rows.Add(row)
            End If
            dgv_ShowData.Refresh()
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
        Dim user As DataSet = getDataSetFromUI()
        Dim resultFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(buttonAction.UPDATE) Then
            Return False
        End If

        Try
            Arm.ModifyUser(user)

            Dim dt As DataTable = dgv_ShowData.GetDBDS.Tables(0)
            'dt.PrimaryKey = New DataColumn() {dt.Columns("userid")}
            'If dt.Rows.Contains(userid.Text) Then
            If dt.Select("userid = '" & userid.Text.Trim & "'").Length > 0 Then
                'dgv_ShowData.CurrentCell = dgv_ShowData.Rows(dt.Rows.IndexOf(dt.Rows.Find(userid.Text))).Cells(0)
                dgv_ShowData.CurrentCell = dgv_ShowData.Rows(dt.Rows.IndexOf(dt.Select("userid = '" & userid.Text.Trim & "'").First)).Cells(0)
                dgv_ShowData.CurrentRow.Cells("userid").Value = user.Tables(0).Rows(0).Item("userid")
                dgv_ShowData.CurrentRow.Cells("username").Value = user.Tables(0).Rows(0).Item("username")
                dgv_ShowData.CurrentRow.Cells("idno").Value = user.Tables(0).Rows(0).Item("idno")
                dgv_ShowData.CurrentRow.Cells("birthday").Value = user.Tables(0).Rows(0).Item("birthday")
                dgv_ShowData.CurrentRow.Cells("isvalid").Value = user.Tables(0).Rows(0).Item("isvalid")
                If user.Tables(0).Rows(0).Item("isvalid").ToString.Equals("Y") Then
                    dgv_ShowData.CurrentRow.Cells("isvalidName").Value = nvl(RdoBtnY.Text)
                ElseIf user.Tables(0).Rows(0).Item("isvalid").ToString.Equals("N") Then
                    dgv_ShowData.CurrentRow.Cells("isvalidName").Value = nvl(RdoBtnN.Text)
                Else
                    dgv_ShowData.CurrentRow.Cells("isvalidName").Value = ""
                End If
                dgv_ShowData.CurrentRow.Cells("mail").Value = user.Tables(0).Rows(0).Item("mail")
                dgv_ShowData.CurrentRow.Cells("Tel_Mobile").Value = user.Tables(0).Rows(0).Item("Tel_Mobile")
                dgv_ShowData.CurrentRow.Cells("Dept_Code").Value = user.Tables(0).Rows(0).Item("Dept_Code")
                dgv_ShowData.CurrentRow.Cells("Dept_Name").Value = user.Tables(0).Rows(0).Item("Dept_Name")
                dgv_ShowData.CurrentRow.Cells("Section_Code").Value = user.Tables(0).Rows(0).Item("Section_Code")
                dgv_ShowData.CurrentRow.Cells("Section_Name").Value = user.Tables(0).Rows(0).Item("Section_Name")
                dgv_ShowData.CurrentRow.Cells("Assume_Effect_Date").Value = user.Tables(0).Rows(0).Item("Assume_Effect_Date")
                dgv_ShowData.CurrentRow.Cells("Assume_End_Date").Value = user.Tables(0).Rows(0).Item("Assume_End_Date")
                dgv_ShowData.CurrentRow.Cells("operator_no").Value = user.Tables(0).Rows(0).Item("operator_no")
                dgv_ShowData.CurrentRow.Cells("update_datetime").Value = user.Tables(0).Rows(0).Item("update_datetime")
                If HospConfig = hospConfigList.Tw_Tnhosp Then
                    '台南增加職級欄位
                    dgv_ShowData.CurrentRow.Cells("Nrs_Level_Id").Value = user.Tables(0).Rows(0).Item("Nrs_Level_Id")
                End If
            Else
                Dim valid As String
                If RdoBtnY.Checked Then
                    valid = RdoBtnY.Tag
                ElseIf RdoBtnN.Checked Then
                    valid = RdoBtnN.Tag
                Else
                    valid = ""
                End If
                If valid.Equals("Y") Then
                    dt.Rows(0).Item("isvalidName") = nvl(RdoBtnY.Text)
                ElseIf valid.Equals("N") Then
                    dt.Rows(0).Item("isvalidName") = nvl(RdoBtnN.Text)
                Else
                    dt.Rows(0).Item("isvalidName") = ""
                End If

                If HospConfig = hospConfigList.Tw_Tnhosp Then
                    '台南增加職級欄位
                    Dim row() As String = {userid.Text, username.Text, "", "", user.Tables("User").Rows(0).Item("birthday"), valid, dt.Rows(0).Item("isvalidName"), mail.Text, "", "", "", _
                                          tcq_DeptCode.getCode, tcq_DeptCode.getCodeName, UclCbo_Section.SelectedValue, UclCbo_Section.SelectedText, DateUtil.TransDateToROC(Now), DateUtil.TransDateToROC("2099/12/31"), AppContext.userProfile.userId, _
                                           DateUtil.TransDateToROC(Now) & Now.ToString(" HH:mm:ss"), AppContext.userProfile.userId, _
                                           DateUtil.TransDateToROC(Now) & Now.ToString(" HH:mm:ss"), txtNrsLevelID.Text}
                    dgv_ShowData.GetDBDS.Tables(0).Rows.Add(row)
                    dgv_ShowData.GetGridDS.Tables(0).Rows.Add(row)
                Else
                    Dim row() As String = {userid.Text, username.Text, "", "", user.Tables("User").Rows(0).Item("birthday"), valid, dt.Rows(0).Item("isvalidName"), mail.Text, "", "", "", _
                                          tcq_DeptCode.getCode, tcq_DeptCode.getCodeName, UclCbo_Section.SelectedValue, UclCbo_Section.SelectedText, DateUtil.TransDateToROC(Now), DateUtil.TransDateToROC("2099/12/31"), AppContext.userProfile.userId, _
                                           DateUtil.TransDateToROC(Now) & Now.ToString(" HH:mm:ss"), AppContext.userProfile.userId, _
                                           DateUtil.TransDateToROC(Now) & Now.ToString(" HH:mm:ss")}
                    dgv_ShowData.GetDBDS.Tables(0).Rows.Add(row)
                    dgv_ShowData.GetGridDS.Tables(0).Rows.Add(row)
                End If
                dgv_ShowData.Refresh()
                dgv_ShowData.CurrentCell = dgv_ShowData.Rows(dgv_ShowData.Rows.Count - 1).Cells(0)
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
        Dim user As DataSet = getDataSetFromUI()
        Dim resultFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(buttonAction.DELETE) Then
            Return False
        End If

        Try
            Arm.DeleteUser(user)
            Dim dt As DataTable = dgv_ShowData.GetDBDS.Tables(0)
            dt.PrimaryKey = New DataColumn() {dt.Columns("userid")}
            If dt.Rows.Contains(userid.Text.Trim) Then
                Dim row As DataRow = dt.Rows.Find(userid.Text.Trim)
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
        Dim user As DataSet = getDataSetFromUI()
        Dim resultFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(buttonAction.QUERY) Then
            Return False
        End If

        Try
            Dim resultDSet As DataSet = Arm.QueryUser(user)
            If resultDSet.Tables.Count = 0 Then
                resultDSet = getDataSetFromUI()
                resultDSet.Tables(0).Rows.Clear()
            End If

            showResult(resultDSet)

            If dgv_ShowData.GetDBDS.Tables(0).Rows.Count = 0 Then
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

            '預設 是 被點選
            RdoBtnY.Checked = True
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
                If dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("userid").Value.ToString.Trim <> "" Then
                    userid.Text = dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("userid").Value.ToString.Trim
                Else
                    userid.Text = ""
                End If
                If dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("username").Value.ToString.Trim <> "" Then
                    username.Text = dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("username").Value.ToString.Trim
                Else
                    username.Text = ""
                End If

                If dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("idno").Value.ToString.Trim <> "" Then
                    IdTxtBox.Text = dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("idno").Value.ToString.Trim
                Else
                    IdTxtBox.Text = ""
                End If
                If dgv_ShowData.CurrentRow.Cells("isvalid").Value.ToString.ToUpper.Trim.Equals(RdoBtnY.Tag) Then
                    RdoBtnY.Checked = True
                ElseIf dgv_ShowData.CurrentRow.Cells("isvalid").Value.ToString.ToUpper.Trim.Equals(RdoBtnN.Tag) Then
                    RdoBtnN.Checked = True
                Else
                    RdoBtnY.Checked = False
                    RdoBtnN.Checked = False
                End If
                If dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("mail").Value.ToString.Trim <> "" Then
                    mail.Text = dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("mail").Value.ToString.Trim
                Else
                    mail.Text = ""
                End If

                '臺南對照部門不對照科別
                Select Case ConfigSystemHospital()
                    Case hospConfigList.Tw_Tnhosp
                        tcq_DeptCode.Clear()
                    Case Else
                        If dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("Dept_Code").Value.ToString.Trim <> "" Then
                            tcq_DeptCode.ProcessQuery(dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("Dept_Code").Value.ToString.Trim)
                        Else
                            tcq_DeptCode.Clear()
                        End If
                End Select

                If dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("birthday").Value.ToString.Trim <> "" Then
                    Dim birStr As String = dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("birthday").Value.ToString.Trim
                    If birStr.Contains("/") Then
                        Dim token() As String = birStr.Split("/")
                        birthday.SetValue(birStr.Replace(token(0), (CType(token(0), Integer) + 1911).ToString))
                    Else
                        Dim day As String = birStr.Substring(birStr.Length - 2, 2)
                        birStr = birStr.Remove(birStr.Length - 2, 2)
                        Dim month As String = birStr.Substring(birStr.Length - 2, 2)
                        birStr = birStr.Remove(birStr.Length - 2, 2)
                        Dim year As String = birStr
                        birthday.SetValue((CType(year, Integer) + 1911).ToString & "/" & month & "/" & day)
                    End If
                Else
                    birthday.Clear()
                End If

                If dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("Section_Code").Value.ToString.Trim <> "" Then
                    UclCbo_Section.SelectedValue = dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("Section_Code").Value.ToString.Trim
                Else
                    UclCbo_Section.SelectedValue = ""
                End If

                cbo_JobTitle.SelectedValue = dgv_ShowData.GetDBDS.Tables(0).Rows(dgv_ShowData.CurrentCellAddress.Y).Item("Professal_Kind_Id").ToString.Trim


                If IsDate(dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("Assume_Effect_Date").Value.ToString.Trim()) AndAlso
                    IsDate(dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("Assume_End_Date").Value.ToString.Trim()) Then
                    Dim Effect_Date As Date = CDate(DateUtil.TransDateToWE(dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("Assume_Effect_Date").Value.ToString.Trim()))

                    Dim End_Date As Date = CDate(DateUtil.TransDateToWE(dgv_ShowData.Rows(dgv_ShowData.CurrentCellAddress.Y).Cells("Assume_End_Date").Value.ToString.Trim()))
                    If Now.Date >= Effect_Date AndAlso Now.Date <= End_Date Then
                        rdo_inJobY.Checked = True
                    Else
                        rdo_inJobN.Checked = True
                    End If
                End If
                If Syscom.Comm.BASE.HospConfigUtil.HospConfig = hospConfigList.Tw_Tnhosp Then
                        txtNrsLevelID.Text = nvl(dgv_ShowData.GetDBDS.Tables(0).Rows(dgv_ShowData.CurrentCellAddress.Y).Item("Nrs_Level_Id")).ToString.Trim
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
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadServiceManager()
        Try
            CMM = CmmServiceManager.getInstance()
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
            Dim ctl_1 As Control = userid
            Dim ctl_2 As Control = username
            Dim ctl_3 As Control = tcq_DeptCode
            Dim ctl_5 As Control = mail

            '繁中訊息
            Dim checkMsgTraditional As String() = New String() {"不可為空", "必須為數字"}

            '簡中訊息
            Dim checkMsgSimple As String() = New String() {"不可为空", "必须为数字"}

            '顯示訊息 - 預設繁中
            Dim checkMsg As String() = checkMsgTraditional

            '設定要使用哪一種語言
            Select Case AppConfigUtil.AppLanguage
                Case AppConfigUtil.Language.TraditionalChinese
                    '繁體中文
                    checkMsg = checkMsgTraditional
                Case AppConfigUtil.Language.TraditionalChinese
                    '簡體中文
                    checkMsg = checkMsgSimple
            End Select

            '清除欄位背景顏色
            cleanFieldsColor()

            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case msgTitle
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not CheckControlHasValue(ctl_1) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '使用者代碼
                        errorMsg1.Append(nvl(lbl_userid.Text))
                        isError = True
                    End If
                    If Not CheckControlHasValue(ctl_2) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '使用者姓名
                        errorMsg1.Append(nvl(lbl_username.Text))
                        isError = True
                    End If
                    If Not RdoBtnN.Checked And Not RdoBtnY.Checked Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '是否有效
                        errorMsg1.Append(nvl(lbl_DCYN.Text))
                        isError = True
                    End If
                    'If Not CheckControlHasValue(ctl_3) Then
                    '    If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                    '    '部門
                    '    errorMsg1.Append(nvl(lbl_Dept_Name.Text))
                    '    isError = True
                    'End If

                    'If Not CheckControlHasValue(ctl_5) Then
                    '    If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                    '    '電子郵件
                    '    errorMsg1.Append(nvl(lbl_mail.Text))
                    '    isError = True
                    'End If
                    'If birthday.GetValue = "" Then
                    '    If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                    '    '生日
                    '    errorMsg1.Append(nvl(lbl_birthday.Text))
                    '    isError = True
                    'End If
                    'If UclCbo_Section.SelectedValue = "" Then
                    '    If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                    '    '院區
                    '    errorMsg1.Append(nvl(lbl_Section.Text))
                    '    isError = True
                    'End If
                Case buttonAction.DELETE
                    If Not CheckControlHasValue(ctl_1) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '使用者代碼
                        errorMsg1.Append(nvl(lbl_userid.Text))
                        isError = True
                    End If
                Case buttonAction.CHANGEPWD, buttonAction.ROLESET
                    If Not CheckControlHasValue(ctl_1) Then
                        If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                        '使用者代碼
                        errorMsg1.Append(nvl(lbl_userid.Text))
                        isError = True
                    End If
                    'If Not CheckControlHasValue(ctl_2) Then
                    '    If (errorMsg1.ToString.Trim.Length > 0) Then errorMsg1.Append(",")
                    '    '使用者姓名
                    '    errorMsg1.Append(nvl(lbl_username.Text))
                    '    isError = True
                    'End If
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
            userid.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            username.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            tcq_DeptCode.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT

            mail.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

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
        Catch ex As Exception
            If HospConfig = hospConfigList.Tw_Tnhosp AndAlso ex.ToString.Contains("SQL 錯誤代碼(2627)") Then
                MessageHandling.ShowErrorMsg("CMMCMMB300", "使用者代號已重複，請檢查。")
            Else
                ClientExceptionHandler.ProccessException(ex)
            End If
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
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            MessageHandling.ClearInfoMsg()
            If (MessageHandling.ShowQuestionMsg("CMMCMMB932", New String() {}) = Windows.Forms.DialogResult.Yes) Then
                UCLScreenUtil.Lock(Me)
                If (deleteData()) Then
                    controlButton(buttonAction.DELETE)
                    '將資料從datagridview中移除
                    dgv_ShowData.Rows.RemoveAt(dgv_ShowData.CurrentRow.Index)
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
                If (dgv_ShowData.CurrentRow IsNot Nothing AndAlso dgv_ShowData.CurrentRow.Index >= 0) Then
                    dgv_ShowData.CurrentRow.Selected = False
                End If
                MessageHandling.ShowInfoMsg("CMMCMMB901", New String() {})
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
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

    ''' <summary>
    ''' 重設密碼
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-8-30</remarks>
    Private Sub btnResetPw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetPw.Click
        Try
            MessageHandling.ClearInfoMsg()
            If Not fieldCheckResult(buttonAction.CHANGEPWD) Then
                Dim dialog As New ChangePwdMtnUI()
                dialog.userId.Text = userid.Text
                dialog.ShowDialog(Me)
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 角色權限設定
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-8-30</remarks>
    Private Sub btnRoleSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoleSet.Click
        Try
            MessageHandling.ClearInfoMsg()
            If Not fieldCheckResult(buttonAction.ROLESET) Then

                Dim dsTemp As New DataSet

                '新增一個Table
                dsTemp.Tables.Add("User")
                dsTemp.Tables("User").Columns.Add("userid")
                dsTemp.Tables("User").Columns.Add("username")
                dsTemp.Tables("User").Columns.Add("birthday")
                dsTemp.Tables("User").Columns.Add("isvalid")
                Dim flag As String = "N"
                If RdoBtnY.Checked Then
                    flag = "Y"
                End If

                Dim value() As Object = {userid.Text, username.Text, "", flag}
                dsTemp.Tables(0).Rows.Add(value)

                Dim dialog As New RoleSetMtnUI(dsTemp)
                dialog.ShowDialog(Me)
                btnQuery.PerformClick()
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
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
                        'MessageHandling.clearInfoMsg()
                        btnClear_Click(sender, e)
                    Case Keys.F12

                        '刪除 SF12
                        If e.Shift Then
                            If (btnDelete.Enabled) Then btnDelete_Click(sender, e)

                        Else
                            '新增F12
                            'MessageHandling.clearInfoMsg()
                            If (btnInsert.Enabled) Then btnInsert_Click(sender, e)

                        End If

                    Case Keys.F10
                        '修改
                        'MessageHandling.clearInfoMsg()
                        If (btnUpdate.Enabled) Then btnUpdate_Click(sender, e)

                    Case Keys.F1
                        '查詢
                        'MessageHandling.clearInfoMsg()
                        btnQuery_Click(sender, e)
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

    Private Sub UserMtnUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '高雄 加回 行動電話欄位 (排除不顯示欄位內)
            If HospConfig = hospConfigList.Tw_Kmuh Then
                visibleColumnNo = "2,4,5,6,9,13,14"
            End If

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
            Select Case HospConfigUtil.HospConfig
                Case HospConfigUtil.hospConfigList.Tw_Kmuh
                    btnInsert.Visible = False
                    btnUpdate.Visible = False
                    btnDelete.Visible = False
                    btnInsert.Enabled = False
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    btnQuery.Enabled = True
                    btnClear.Enabled = True
                    btnResetPw.Visible = False
                    btnRoleSet.Enabled = False
                Case Else
                    btnInsert.Enabled = True
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    btnQuery.Enabled = True
                    btnClear.Enabled = True
                    btnResetPw.Enabled = False
                    btnRoleSet.Enabled = False
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
    ''' 改變按鈕的狀態
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub changedButton()
        Try
            Select Case HospConfigUtil.HospConfig
                Case HospConfigUtil.hospConfigList.Tw_Kmuh
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    btnResetPw.Enabled = False
                    btnRoleSet.Enabled = True
                Case Else
                    btnUpdate.Enabled = True
                    btnDelete.Enabled = True
                    btnResetPw.Enabled = True
                    btnRoleSet.Enabled = True
            End Select
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
            dtable.TableName = "User"

            If HospConfig = hospConfigList.Tw_Tnhosp Then
                '台南增加職級欄位
                For Each columnName As String In columnNameTnDB
                    dtable.Columns.Add(columnName)
                Next
            Else
                For Each columnName As String In columnNameDB
                    dtable.Columns.Add(columnName)
                Next
            End If

            Dim birStr = birthday.GetValue
            If birStr <> "" Then
                birStr = (CType(birStr.Substring(0, 4), Integer) - 1911).ToString & "/" & birStr.Substring(5, 2) & "/" & birStr.Substring(8, 2)
            End If

            Dim valid As String
            If RdoBtnY.Checked Then
                valid = "Y"
            ElseIf RdoBtnN.Checked Then
                valid = "N"
            Else
                valid = ""
            End If

            Dim inJob As String
            If rdo_inJobY.Checked Then
                inJob = "Y"
            ElseIf rdo_inJobN.Checked Then
                inJob = "N"
            Else
                inJob = ""
            End If

            If HospConfig = hospConfigList.Tw_Tnhosp Then
                '台南增加職級欄位
                Dim valueArray() As Object = {userid.Text, username.Text, "", IdTxtBox.Text.Trim.ToUpper, birStr, inJob, "", mail.Text, "", cbo_JobTitle.SelectedValue, cbo_JobTitle.Text, tcq_DeptCode.getCode, tcq_DeptCode.getCodeName, UclCbo_Section.SelectedValue, UclCbo_Section.Text, DateUtil.TransDateToROC(Now.ToString("yyyy/MM/dd")), DateUtil.TransDateToROC("2099/12/31"), AppContext.userProfile.userId, DateUtil.TransDateToROC(Now.ToString("yyyy/MM/dd HH:mm:ss")), AppContext.userProfile.userId, DateUtil.TransDateToROC(Now) & Now.ToString(" HH:mm:ss"), txtNrsLevelID.Text}
                dtable.Rows.Add(valueArray)
            Else
                Dim valueArray() As Object = {userid.Text, username.Text, "", IdTxtBox.Text.Trim.ToUpper, birStr, inJob, "", mail.Text, "", cbo_JobTitle.SelectedValue, cbo_JobTitle.Text, tcq_DeptCode.getCode, tcq_DeptCode.getCodeName, UclCbo_Section.SelectedValue, UclCbo_Section.Text, DateUtil.TransDateToROC(Now.ToString("yyyy/MM/dd")), DateUtil.TransDateToROC("2099/12/31"), AppContext.userProfile.userId, DateUtil.TransDateToROC(Now.ToString("yyyy/MM/dd HH:mm:ss")), AppContext.userProfile.userId, DateUtil.TransDateToROC(Now) & Now.ToString(" HH:mm:ss")}
                dtable.Rows.Add(valueArray)
            End If

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

    Private Sub dgvShowData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_ShowData.CellClick
        Try
            If (e.RowIndex >= 0) Then
                dgvCellClick()
                changedButton()
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
            dgv_ShowData.Initial(ds)
            dgv_ShowData.uclHeaderText = columnName
            dgv_ShowData.uclNonVisibleColIndex = visibleColumnNo
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub Btn_ResetPwd_Click(sender As Object, e As EventArgs) Handles Btn_ResetPwd.Click
        If userid.Text <> "" Then
            Dim frmPwd As New ArmResetPwdUI
            frmPwd.Txt_EmployeeCode.Text = userid.Text.Trim
            frmPwd.Lab_EmployeeName.Text = username.Text.Trim
            frmPwd.ShowDialog()
        Else
            MessageHandling.ShowWarnMsg("請選擇使用者!")
        End If
       

    End Sub

#Region " 取得客戶端的醫院設定 "

    ''' <summary>
    ''' 取得客戶端的醫院設定
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Stacey.Hsiao on 2016-04-19</remarks>
    Public Shared Function ConfigSystemHospital() As hospConfigList

        Try

            '暫時關閉，還須測試
            'Sean

            ''如果沒有設定過醫院設定，則需要重新設定
            'If gblCheckHosp = False Then

            '    '取得醫療組織代碼
            '    Dim hospOragnizationCode As String = ConfigUtil.GetConfigValue("Hospital_Code")

            '    '如果沒有預設醫院，則必須根據醫療組織代碼重新設定
            '    If HospConfig = hospConfigList.none Then

            '        '根據醫療組織代碼重新設定 醫院 Config
            '        SetHospconfigByHospCode(hospOragnizationCode)

            '    End If

            '    '根據醫療組織代碼 檢核目前的 醫院 Config 是否正確
            '    If CheckHospconfigByHospCode(hospOragnizationCode) = False Then
            '        gblCheckHosp = False
            '        Throw New Exception("客戶端的醫院的醫療組織代碼與醫院代碼不相符合，請確認設定!")

            '    Else
            '        gblCheckHosp = True
            '    End If

            'End If

            Return HospConfig

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得客戶端的醫院設定"})
        End Try

    End Function

#End Region
End Class
