Imports System.ServiceModel
Imports System.Windows.Forms
Imports Syscom.Comm.EXP
Imports JOBClientServiceFactory
Imports System.Data
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports Syscom.Client.UCL

Public Class JobEmployeeMaintainBP
    Dim dgvColumns As String() = {"Employee_Code", "Employee_Name", "Employee_En_Name", "Assume_Effect_Date", "Assume_End_Date", "Nrs_Level_Id", "Role", "Tel_Mobile", "EMail"}
    Dim dgvColumnText As String = "員工編號,員工姓名,英文名稱,到職日,離職日,職級,角色,電話,EMail"
    Dim VisibleColIndex As String = "0,1,2,3,4,5,6,7,8"
    Dim gblLevelDT As DataTable
    Dim gblRoleDT As DataTable
    Dim gblPubEmployeeDT As DataSet = PubEmployeeDataTableFactory.getDataSet

#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobEmployeeMaintainBP
    Public Shared Function GetInstance() As JobEmployeeMaintainBP
        If myInstance Is Nothing Then
            myInstance = New JobEmployeeMaintainBP
        End If
        Return myInstance
    End Function

    Private Sub New()
    End Sub

#End Region

#Region "     按鈕事件"
#Region "查詢"
    ''' <summary>
    ''' 查詢事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <param name="ui"></param>
    Public Sub QueryData(sender As Object, e As EventArgs, ByRef ui As JobEmployeeMaintainUI)
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryJobEmployeeMaintainUI)
            SendDS.Tables(0).Rows.Add("QueryJobEmployeeMaintainUI", ui.txt_Employee_Code.Text, ui.txt_Employee_En_Name.Text, ui.txt_Employee_Name.Text)
            Dim RetDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasValue(RetDS) Then
                ShowDgv(GetDgvDS(RetDS), ui.dgv_ShowData)
            Else
                ShowDgv(GetDgvDS(New DataSet), ui.dgv_ShowData)
            End If


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        End Try


    End Sub
#End Region

#Region "新增"
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <param name="ui"></param>
    Public Sub Insert(sender As Object, e As EventArgs, ByRef ui As JobEmployeeMaintainUI)
        Try

            If CheckBeforeConfirm(ui, SaveType.Insert) Then
                Exit Sub
            End If
            Dim ArmRolesDT As DataTable = ArmRolesDataTableFactory.getDataTable
            Dim ArmPasswordDT As DataTable = ArmPasswordDataTableFactory.getDataTable
            Dim SendDS As DataSet = gblPubEmployeeDT.Copy
            SendDS.Tables(0).Columns.Add("Action")
            SendDS.Tables(0).Columns.Add("Role")
            Dim dr As DataRow = SendDS.Tables(0).NewRow
            dr("Action") = "InsertJobEmployeeMaintainUI"
            dr("Employee_Code") = ui.txt_Employee_Code.Text
            dr("Employee_En_Name") = ui.txt_Employee_En_Name.Text
            dr("Employee_Name") = ui.txt_Employee_Name.Text
            dr("Assume_Effect_Date") = ui.dtp_Assume_Effect_Date.GetUsDateStr
            dr("Assume_End_Date") = IIf(IsDate(ui.dtp_Assume_End_Date.GetUsDateStr), ui.dtp_Assume_End_Date.GetUsDateStr, DBNull.Value)
            dr("Nrs_Level_Id") = ui.cbo_Level.SelectedValue
            dr("Role") = ui.cbo_Role.SelectedValue
            dr("Tel_Mobile") = ui.txt_Tel_Mobile.Text
            dr("EMail") = ui.txt_EMail.Text
            dr("Create_User") = AppContext.userProfile.userId
            dr("Modified_User") = AppContext.userProfile.userId
            SendDS.Tables(0).Rows.Add(dr)

            Dim newRoleDr As DataRow = ArmRolesDT.NewRow
            newRoleDr("Employee_Code") = ui.txt_Employee_Code.Text
            newRoleDr("Role") = ui.cbo_Role.SelectedValue
            newRoleDr("Update_User") = AppContext.userProfile.userId
            newRoleDr("Update_Time") = Now.ToString("yyyy/MM/dd")
            ArmRolesDT.Rows.Add(newRoleDr.ItemArray)
            Dim newPasswordDr As DataRow = ArmPasswordDT.NewRow
            newPasswordDr("Employee_Code") = ui.txt_Employee_Code.Text
            newPasswordDr("Password") = Syscom.Comm.Utility.PassWordUtil.Encrypt(ui.txt_Employee_Code.Text, Syscom.Comm.Utility.PassWordUtil.getPrimaryKey)
            newPasswordDr("Password_org") = ui.txt_Employee_Code.Text
            newPasswordDr("Modified_Date") = Now.ToString("yyyy/MM/dd")
            ArmPasswordDT.Rows.Add(newPasswordDr.ItemArray)
            SendDS.Tables.Add(ArmRolesDT)
            SendDS.Tables.Add(ArmPasswordDT)

            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasValue(retDS) Then
                QueryData(sender, e, ui)
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "無資料被修改")
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        End Try


    End Sub
#End Region

#Region "修改"
    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <param name="ui"></param>
    Public Sub Update(sender As Object, e As EventArgs, ByRef ui As JobEmployeeMaintainUI)
        Try
            If CheckBeforeConfirm(ui, SaveType.Update) Then
                Exit Sub
            End If


            Dim SendDS As DataSet = gblPubEmployeeDT.Copy
            SendDS.Tables(0).Columns.Add("Action")
            SendDS.Tables(0).Columns.Add("Role")
            Dim dr As DataRow = SendDS.Tables(0).NewRow
            dr("Action") = "UpdateJobEmployeeMaintainUI"
            dr("Employee_Code") = ui.txt_Employee_Code.Text
            dr("Employee_En_Name") = ui.txt_Employee_En_Name.Text
            dr("Employee_Name") = ui.txt_Employee_Name.Text
            dr("Assume_Effect_Date") = ui.dtp_Assume_Effect_Date.GetUsDateStr
            dr("Assume_End_Date") = IIf(ui.dtp_Assume_End_Date.GetUsDateStr.Length > 0, "", DBNull.Value)
            dr("Nrs_Level_Id") = ui.cbo_Level.SelectedValue
            dr("Role") = ui.cbo_Role.SelectedValue
            dr("Tel_Mobile") = ui.txt_Tel_Mobile.Text
            dr("EMail") = ui.txt_EMail.Text
            dr("Modified_User") = AppContext.userProfile.userId
            SendDS.Tables(0).Rows.Add(dr)
            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasValue(retDS) Then
                QueryData(sender, e, ui)
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "無資料被修改")
            End If


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})
        End Try


    End Sub
#End Region

#Region "刪除"
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <param name="ui"></param>
    Public Sub Delete(sender As Object, e As EventArgs, ByRef ui As JobEmployeeMaintainUI)
        Try

            If CheckBeforeConfirm(ui, SaveType.Update) Then
                Exit Sub
            End If


            Dim SendDS As DataSet = gblPubEmployeeDT.Copy
            SendDS.Tables(0).Columns.Add("Action")
            SendDS.Tables(0).Columns.Add("Role")
            Dim dr As DataRow = SendDS.Tables(0).NewRow
            dr("Action") = "DeleteJobEmployeeMaintainUI"
            dr("Employee_Code") = ui.txt_Employee_Code.Text
            dr("Role") = ui.cbo_Role.SelectedValue

            SendDS.Tables(0).Rows.Add(dr)
            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasValue(retDS) Then
                Clear(sender, e, ui)
                QueryData(sender, e, ui)
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "無資料被修改")
            End If


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})
        End Try


    End Sub
#End Region

#Region "清除"
    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <param name="ui"></param>
    Public Sub Clear(sender As Object, e As EventArgs, ByRef ui As JobEmployeeMaintainUI)
        Try

            For Each ctl As Control In ui.Controls
                Select Case ctl.GetType.ToString
                    Case "System.Windows.Forms.Panel", "System.Windows.Forms.TableLayoutPanel", "System.Windows.Forms.GroupBox", "System.Windows.Forms.TabControl", "System.Windows.Forms.TabPage"
                        clearFieldValue(ctl)
                End Select

            Next

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"清除"})
        End Try


    End Sub

    ''' <summary>
    ''' 清除欄位資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub clearFieldValue(ByRef container As Control)
        Try

            For Each ctl As Control In container.Controls
                Select Case ctl.GetType.ToString
                    Case "System.Windows.Forms.TextBox", "Syscom.Client.UCL.UCLTextBoxUC", "Syscom.Client.UCL.UCLChartNoUC"
                        'TextBox, UCLTextBoxUI, UCLChartNoUC
                        ctl.Text = ""
                        ctl.Tag = ""

                        If ctl.GetType.ToString.Equals("Syscom.Client.UCL.UCLChartNoUC") Then
                            CType(ctl, UCLChartNoUC).ClearPatientData()
                            CType(ctl, UCLChartNoUC).ClearPatientObj()
                        End If
                    Case "System.Windows.Forms.ComboBox"
                        'ComboBox
                        With CType(ctl, System.Windows.Forms.ComboBox)
                            If .DataSource IsNot Nothing Then
                                .SelectedIndex = 0
                            End If
                        End With
                    Case "System.Windows.Forms.CheckBox"
                        'CheckBox
                        CType(ctl, System.Windows.Forms.CheckBox).Checked = False
                    Case "System.Windows.Forms.RadioButton"
                        'RadioButton
                        CType(ctl, System.Windows.Forms.RadioButton).Checked = False
                    Case "System.Windows.Forms.Panel", "System.Windows.Forms.TableLayoutPanel", "System.Windows.Forms.GroupBox", "System.Windows.Forms.TabControl", "System.Windows.Forms.TabPage"
                        'Container

                        '設定Container的Tag屬性為""，避免為nothing
                        ctl.Tag = ""
                        clearFieldValue(ctl)
                    'TODO Bella Mark For Move 20150511'Case "DateTimePickerUCT.DateTimePickerUCT"
                    'TODO Bella Mark For Move 20150511'    'DateTimePickerUCT yaya寫的User Control
                    'TODO Bella Mark For Move 20150511'    CType(ctl, DateTimePickerUCT.DateTimePickerUCT).Clear()
                    Case "Syscom.Client.UCL.UCLComboBoxUC"
                        'UCLComboBoxUC
                        With CType(ctl, Syscom.Client.UCL.UCLComboBoxUC)
                            If DataSetUtil.IsContainsData(.DataSource.Copy) Then
                                .SelectedValue = ""
                            End If
                        End With
                    Case "Syscom.Client.UCL.UCLDateTimePickerUC"
                        'UCLDateTimePickerUI
                        CType(ctl, Syscom.Client.UCL.UCLDateTimePickerUC).Clear()
                    Case "System.Windows.Forms.DataGridView"
                        'showResult(CType(ctl, System.Windows.Forms.DataGridView), genDataSet(CType(ctl, System.Windows.Forms.DataGridView).Name))
                        ctl.Tag = Nothing
                    Case "nckuh.client.ucl.UCLDataGridViewUC"
                        ctl.Tag = Nothing
                    Case "Syscom.Client.UCL.UCLIdentityUC"
                        CType(ctl, UCLIdentityUC).Clear()
                    Case "Syscom.Client.UCL.UCLTextCodeQueryUI"
                        CType(ctl, Syscom.Client.UCL.UCLTextCodeQueryUI).Clear()
                End Select


            Next

        Catch ex As Exception

        End Try
    End Sub
#End Region
#End Region

#Region "     Grid事件"

    Public Sub dgv_ShowData_CellClick(sender As Object, e As DataGridViewCellEventArgs, ByRef ui As JobEmployeeMaintainUI)

        If e.RowIndex < 0 Then Exit Sub
        Try
            ui.txt_Employee_Code.Text = ui.dgv_ShowData.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Employee_Code").ToString.Trim
            ui.txt_Employee_En_Name.Text = ui.dgv_ShowData.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Employee_En_Name").ToString.Trim
            ui.txt_Employee_Name.Text = ui.dgv_ShowData.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Employee_Name").ToString.Trim
            ui.dtp_Assume_Effect_Date.SetValue(ui.dgv_ShowData.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Assume_Effect_Date").ToString.Trim)
            ui.dtp_Assume_End_Date.SetValue(ui.dgv_ShowData.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Assume_End_Date").ToString.Trim)
            ui.txt_EMail.Text = ui.dgv_ShowData.GetDBDS.Tables(0).Rows(e.RowIndex).Item("EMail").ToString.Trim
            ui.txt_Tel_Mobile.Text = ui.dgv_ShowData.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Tel_Mobile").ToString.Trim
            ui.cbo_Level.SelectedValue = ui.dgv_ShowData.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Nrs_Level_Id").ToString.Trim
            ui.cbo_Role.SelectedValue = ui.dgv_ShowData.GetDBDS.Tables(0).Rows(e.RowIndex).Item("Role").ToString.Trim.Split("-")(0)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"Grid事件"})
        End Try

    End Sub

#End Region

#Region "     初始化"

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-07-03</remarks>
    Public Sub Initial(ByRef ui As JobEmployeeMaintainUI)

        Try
            InitialComboBox(ui)
            ShowDgv(GetDgvDS(New DataSet), ui.dgv_ShowData)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

    Private Sub InitialComboBox(ByRef ui As JobEmployeeMaintainUI)
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.InitialJOBEmployeeMaintainUI)
            SendDS.Tables(0).Rows.Add("InitialJOBEmployeeMaintainUI")
            Dim resultDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasTable(resultDS) Then
                gblLevelDT = New DataTable
                gblLevelDT.Columns.Add("Code_Id")
                gblLevelDT.Columns.Add("Code_Name")
                gblRoleDT = gblLevelDT.Clone

                If CheckHasValue(resultDS.Tables(0)) Then
                    gblLevelDT.Clear()
                    For Each dr As DataRow In resultDS.Tables(0).Rows
                        For Each s As String In dr(0).ToString.Trim.Split(",")
                            Dim newDR As DataRow = gblLevelDT.NewRow
                            newDR("Code_Id") = s.Split("-")(0)
                            newDR("Code_Name") = s.Split("-")(1)
                            gblLevelDT.Rows.Add(newDR.ItemArray)
                        Next
                    Next
                    ui.cbo_Level.DataSource = gblLevelDT.Copy
                    ui.cbo_Level.uclDisplayIndex = "0,1"
                    ui.cbo_Level.uclValueIndex = "0"

                End If
                If CheckHasValue(resultDS.Tables(1)) Then
                    gblRoleDT.Clear()
                    For Each dr As DataRow In resultDS.Tables(1).Rows
                        For Each s As String In dr(0).ToString.Trim.Split(",")
                            Dim newDR As DataRow = gblRoleDT.NewRow
                            newDR("Code_Id") = s.Split("-")(0)
                            newDR("Code_Name") = s.Split("-")(1)
                            gblRoleDT.Rows.Add(newDR.ItemArray)
                        Next
                    Next
                    ui.cbo_Role.DataSource = gblRoleDT.Copy
                    ui.cbo_Role.uclDisplayIndex = "0,1"
                    ui.cbo_Role.uclValueIndex = "0"
                End If
            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 設定Grid顯示
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="dgv"></param>

    Private Sub ShowDgv(ByVal ds As DataSet, ByRef dgv As Syscom.Client.UCL.UCLDataGridViewUC)


        Try
            dgv.Initial(ds)
            dgv.uclHeaderText = dgvColumnText
            dgv.uclVisibleColIndex = VisibleColIndex


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"病人主檔維護作業"})
        End Try

    End Sub
    ''' <summary>
    ''' 取得顯示用DS
    ''' </summary>
    ''' <param name="inputDS"></param>
    ''' <returns></returns>
    Private Function GetDgvDS(ByVal inputDS As DataSet) As DataSet
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("GridDS"))
        Try
            For Each c As String In dgvColumns
                retDS.Tables(0).Columns.Add(c)
            Next

            If Syscom.Comm.Utility.CheckMethodUtil.CheckHasValue(inputDS) Then

                For Each dr As DataRow In inputDS.Tables(0).Rows
                    Dim newDR As DataRow = retDS.Tables(0).NewRow
                    For Each c As DataColumn In inputDS.Tables(0).Columns
                        If retDS.Tables(0).Columns.Contains(c.ColumnName) Then
                            newDR(c.ColumnName) = dr(c.ColumnName)
                            Exit For
                        End If
                    Next
                    retDS.Tables(0).Rows.Add(dr.ItemArray)
                Next



            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
        Return retDS
    End Function
#End Region


#End Region

#Region "     檢核"

    Enum SaveType As Int32
        Insert
        Update
        Delete
    End Enum

    ''' <summary>
    ''' 存檔前檢核
    ''' </summary>
    ''' <returns></returns>
    Private Function CheckBeforeConfirm(ByRef ui As JobEmployeeMaintainUI, ByVal type As SaveType) As Boolean

        Try
            If ui.txt_Employee_Code.Text.Length = 0 Then
                ui.txt_Employee_Code.ForeColor = System.Drawing.Color.Red
                MessageHandling.ShowWarnMsg("CMMCMMB300", "員工編號不得為空")
                Return True
            Else
                ui.txt_Employee_Code.ForeColor = System.Drawing.SystemColors.WindowText
            End If




            If type = SaveType.Insert Then
                If ui.txt_EMail.Text.Length = 0 Then
                    ui.txt_EMail.ForeColor = System.Drawing.Color.Red
                    MessageHandling.ShowWarnMsg("CMMCMMB300", "電子郵件必須輸入")
                    Return True
                Else
                    ui.txt_EMail.ForeColor = System.Drawing.SystemColors.WindowText
                End If
                If ui.txt_Employee_Name.Text.Length = 0 Then
                    ui.txt_Employee_Name.ForeColor = System.Drawing.Color.Red
                    MessageHandling.ShowWarnMsg("CMMCMMB300", "員工姓名必須輸入")
                    Return True
                Else
                    ui.txt_Employee_Name.ForeColor = System.Drawing.SystemColors.WindowText
                End If
                If ui.cbo_Level.SelectedValue = "" Then
                    ui.cbo_Level.ForeColor = System.Drawing.Color.Red
                    MessageHandling.ShowWarnMsg("CMMCMMB300", "必須選擇職級")
                    Return True
                Else
                    ui.cbo_Level.ForeColor = System.Drawing.SystemColors.WindowText
                End If

                If ui.cbo_Role.SelectedValue = "" Then
                    ui.cbo_Role.ForeColor = System.Drawing.Color.Red
                    MessageHandling.ShowWarnMsg("CMMCMMB300", "未選角色")
                    Return True
                Else
                    ui.cbo_Role.ForeColor = System.Drawing.SystemColors.WindowText
                End If
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"存檔前檢核"})
        End Try
        Return False
    End Function

#End Region
End Class
