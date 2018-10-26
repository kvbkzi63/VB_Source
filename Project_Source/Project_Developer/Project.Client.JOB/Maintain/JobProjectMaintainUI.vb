Imports System.Data
Imports System.Windows.Forms
Imports JOBClientServiceFactory
Imports Syscom.Client.CMM
Imports Syscom.Comm.EXP
Imports System.Linq
Imports Syscom.Comm.Utility
Imports System.ServiceModel
Imports Project.Client.JOB.ProjectClientBP
Imports Syscom.Client.Servicefactory

Public Class JobProjectMaintainUI
    Inherits Syscom.Client.UCL.BaseFormUI

#Region "     宣告變數"
    Dim job As IJOBServiceManager = Nothing
    Dim PrjListColumnName As String() = {"專案代碼", "專案名稱", "專案起日", "專案迄日", "專案狀態", "PM", "建立者", "建立時間", "修改者", "修改時間"}
    Dim PrjSystemListColumnName As String() = {"專案代碼", "系統代碼", "系統名稱", "負責SA", "建立者", "建立時間", "修改者", "修改時間"}
    Dim PrjFunctionListColumnName As String() = {"專案代碼", "系統代碼", "功能代碼", "功能名稱", "停用", "建立者", "建立時間", "修改者", "修改時間"}
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance
    Dim currentUser As String = AppContext.userProfile.userId


#End Region

#Region "     *初始化 - 畫面  "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-04-14</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()
            initialData()


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region


    ''' <summary>
    ''' 初始化畫面  
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-4-14</remarks>
    Public Sub initialData()

        Try

            '載入服務管理員
            LoadServiceManager()


            '*******************************************************************************
            '修改 初始化的Combox 沒有則不需要 **********************************************
            '*******************************************************************************

            '初始化 - ComboBox
            initialComboBox()

            '*******************************************************************************




        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

    Private Sub initialComboBox()


        Try
            Dim initialDS = job.PRJDoAction(ProjectClientBP.getInstance.GetActionDS(ActionName.initialSAAssignJobUI))

            If CheckMethodUtil.CheckHasValue(initialDS) Then
                If initialDS.Tables.Contains("SAList") Then
                    cbo_SA.DataSource = initialDS.Tables("SAList").Copy
                    cbo_SA.uclDisplayIndex = "1"
                    cbo_SA.uclValueIndex = "0"
                End If
            End If
            cbo_ProjectStatus.DataSource = PubServiceManager.getInstance.queryPUBSysCode("10000", False).Tables(0).Copy
            cbo_ProjectStatus.uclDisplayIndex = "0,1"
            cbo_ProjectStatus.uclValueIndex = "0"

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

#Region "     *載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-4-14</remarks>
    Private Sub LoadServiceManager()
        Try


            job = JOBServiceManager.getInstance()

            '*******************************************************************************

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"載入服務管理員"})
        End Try

    End Sub

#End Region

#End Region

#Region "     事件處理"

#Region "     按鈕事件"

    Private Sub btn_InsertNewProject_Click(sender As Object, e As EventArgs) Handles btn_InsertNewProject.Click
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.InsertNewProjectMaintainData)
            SendDS.Tables(0).Rows.Add("InsertNewProject", txt_ProjectID.Text _
                                                                    , txt_ProjectName.Text _
                                                                    , CDate(dtp_StartDate.Value).ToString("yyyy/MM/dd") _
                                                                    , DBNull.Value _
                                                                    , cbo_PM.SelectedValue _
                                                                    , currentUser _
                                                                    , currentUser _
                                                                     , cbo_ProjectStatus.SelectedValue)
            Dim resultDS As DataSet = job.PRJDoAction(SendDS)

            If resultDS IsNot Nothing AndAlso resultDS.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("存檔成功")
                pvtReceiveMgr.RaiseProjectModified()
            Else
                MessageBox.Show("無資料被儲存")
            End If

        Catch ex As Exception
            MessageBox.Show("無資料被儲存")
        End Try
    End Sub

    Private Sub btn_UpdateProject_Click(sender As Object, e As EventArgs) Handles btn_UpdateProject.Click
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.UpdateProjectMaintainData)
            SendDS.Tables(0).Rows.Add("UpdateProject", txt_ProjectID.Text _
                                                                    , txt_ProjectName.Text _
                                                                    , CDate(dtp_StartDate.Value).ToString("yyyy/MM/dd") _
                                                                    , IIf(ckb_IsClose.Checked, Now.ToString("yyyy/MM/dd"), DBNull.Value) _
                                                                    , cbo_PM.SelectedValue _
                                                                    , currentUser _
                                                                    , currentUser _
                                                                    , cbo_ProjectStatus.SelectedValue)
            Dim resultDS As DataSet = job.PRJDoAction(SendDS)

            If resultDS IsNot Nothing AndAlso resultDS.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("修改成功")
                pvtReceiveMgr.RaiseProjectModified()
            Else
                MessageBox.Show("無資料被修改")
            End If
            ClearProject()
            ClearSystem()
            ClearFunction()
            btn_QueryProject.PerformClick()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_CancelProject_Click(sender As Object, e As EventArgs) Handles btn_DeleteProject.Click
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.DeleteProject)
            SendDS.Tables(0).Rows.Add("DeleteProject", txt_ProjectID.Text)
            Dim resultDS As DataSet = job.PRJDoAction(SendDS)

            If resultDS IsNot Nothing AndAlso resultDS.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("刪除成功")
                pvtReceiveMgr.RaiseProjectModified()
                ClearProject()
                ClearSystem()
                ClearFunction()
                btn_QueryProject.PerformClick()
            Else
                MessageBox.Show("無任何資料被刪除")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_QueryProject_Click(sender As Object, e As EventArgs) Handles btn_QueryProject.Click
        Try

            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryJobProjectMaintainData)
            SendDS.Tables(0).Rows.Add("QueryJobProjectMaintainData", txt_ProjectID.Text, txt_ProjectName.Text, "", cbo_PM.SelectedValue)


            Dim resultDS As DataSet = job.PRJDoAction(SendDS)

            If resultDS IsNot Nothing Then
                dgv_ProjectList.ClearSelection()
                dgv_ProjectList.DataSource = resultDS.Tables(0).Copy
                For i As Int32 = 0 To PrjListColumnName.Length - 1
                    dgv_ProjectList.Columns(i).HeaderText = PrjListColumnName(i)
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub


    ''' <summary>
    ''' 匯入功能清單
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_ImportFunctionList_Click(sender As Object, e As EventArgs) Handles btn_ImportFunctionList.Click
        Try
            If txt_ProjectID.Text = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "請先輸入專案代號，並確認該專案已建檔")
                Exit Sub
            End If
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.ImportSystemAndFunctionList)
            SendDS.Tables(0).Rows.Add("ImportSystemAndFunctionList")

            If GetImportList(SendDS) Then Exit Sub

            Dim resultDS As DataSet = job.PRJDoAction(SendDS)

            If Syscom.Comm.Utility.CheckMethodUtil.CheckHasValue(resultDS) Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", String.Format("本次匯入資料共 系統共:{0}筆 成功:{1}筆  功能函數共: {2} 筆 成功: {3} 筆", resultDS.Tables(0).Rows(0).Item(0),
                                                                                                                                                   resultDS.Tables(0).Rows(0).Item(1),
                                                                                                                                                   resultDS.Tables(0).Rows(0).Item(2),
                                                                                                                                                   resultDS.Tables(0).Rows(0).Item(3)))
            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"匯入功能清單"})
        End Try
    End Sub



#End Region
#Region "     Grid事件"
    Private Sub dgv_ProjectList_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv_ProjectList.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Try
            txt_ProjectID.Text = dgv_ProjectList.Rows(e.RowIndex).Cells("Project_ID").Value.ToString
            txt_ProjectName.Text = dgv_ProjectList.Rows(e.RowIndex).Cells("Project_Name").Value.ToString
            dtp_StartDate.Value = CDate(dgv_ProjectList.Rows(e.RowIndex).Cells("Start_Date").Value.ToString)
            cbo_PM.SelectedValue = dgv_ProjectList.Rows(e.RowIndex).Cells("Project_Manager").Value.ToString
            ckb_IsClose.Checked = Not dgv_ProjectList.Rows(e.RowIndex).Cells("End_Date").Value Is DBNull.Value

            Select Case dgv_ProjectList.Rows(e.RowIndex).Cells("Project_Status").Value.ToString
                Case "開發中"
                    cbo_ProjectStatus.SelectedValue = 1
                Case "保固中"
                    cbo_ProjectStatus.SelectedValue = 2
            End Select

            QuerySystemList()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_ProjectList_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv_ProjectList.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Try
            txt_ProjectID.Text = dgv_ProjectList.Rows(e.RowIndex).Cells("Project_ID").Value.ToString
            TabControl1.SelectedIndex = 1
            QuerySystemList()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub dgv_System_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv_System.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Try
            txt_SystemCode.Text = dgv_System.Rows(e.RowIndex).Cells("System_Code").Value.ToString
            TabControl1.SelectedIndex = 2
            QueryFunctionList()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_System_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv_System.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Try
            txt_SystemCode.Text = dgv_System.Rows(e.RowIndex).Cells("System_Code").Value.ToString
            txt_SystemName.Text = dgv_System.Rows(e.RowIndex).Cells("System_Name").Value.ToString
            cbo_SA.SelectedValue = dgv_System.Rows(e.RowIndex).Cells("SA_Employee_Code").Value.ToString
            ClearFunction()
            QueryFunctionList()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub dgv_Function_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgv_Function.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Try
            txt_FunctionCode.Text = dgv_Function.Rows(e.RowIndex).Cells("Function_Code").Value.ToString
            txt_FunctionName.Text = dgv_Function.Rows(e.RowIndex).Cells("Function_Name").Value.ToString
            ckb_Dc.Checked = dgv_Function.Rows(e.RowIndex).Cells("Function_Name").Value.ToString.Equals("Y")
        Catch ex As Exception

        End Try

    End Sub
#End Region
#Region "     系統"
    Private Function CheckInputSystemCodeAndName() As Boolean
        Try

            If txt_SystemCode.Text.Length = 0 OrElse txt_SystemName.Text.Length = 0 Then
                MessageBox.Show("代碼或名稱不得為空")
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Sub btn_InsertNewProjectSystem_Click(sender As Object, e As EventArgs) Handles btn_InsertNewProjectSystem.Click

        Try

            If CheckInputSystemCodeAndName() Then
                Exit Sub
            End If
            Dim sendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.InsertNewProjectSystem)
            sendDS.Tables(0).Rows.Add("InsertNewSystem", txt_ProjectID.Text, txt_SystemCode.Text, txt_SystemName.Text, cbo_SA.SelectedValue, "Will", "Will")
            Dim resultDS As DataSet = job.PRJDoAction(sendDS)


            If resultDS IsNot Nothing AndAlso CInt(resultDS.Tables(0).Rows(0).Item(0).ToString.Trim > 0) Then
                MessageBox.Show("新增成功")
                QuerySystemList()
                pvtReceiveMgr.RaiseProjectModified()

            Else
                MessageBox.Show("無資料被修改")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_UpdateProjectSystem_Click(sender As Object, e As EventArgs) Handles btn_UpdateProjectSystem.Click
        Try

            If CheckInputSystemCodeAndName() Then
                Exit Sub
            End If
            Dim sendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.UpdateProjectSystem)
            sendDS.Tables(0).Rows.Add("UpdateProjectSystem", txt_ProjectID.Text, txt_SystemCode.Text, txt_SystemName.Text, cbo_SA.SelectedValue, "Will", "Will")
            Dim resultDS As DataSet = job.PRJDoAction(sendDS)


            If resultDS IsNot Nothing AndAlso CInt(resultDS.Tables(0).Rows(0).Item(0).ToString.Trim > 0) Then
                MessageBox.Show("修改成功")
                pvtReceiveMgr.RaiseProjectModified()

                QuerySystemList()
            Else
                MessageBox.Show("無資料被修改")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_DeleteProjectSystem_Click(sender As Object, e As EventArgs) Handles btn_DeleteProjectSystem.Click
        Try

            If CheckInputSystemCodeAndName() Then
                Exit Sub
            End If
            Dim sendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.DeleteProjectSystem)
            sendDS.Tables(0).Rows.Add("DeleteProjectSystem", txt_ProjectID.Text, txt_SystemCode.Text)
            Dim resultDS As DataSet = job.PRJDoAction(sendDS)


            If resultDS IsNot Nothing AndAlso CInt(resultDS.Tables(0).Rows(0).Item(0).ToString.Trim > 0) Then
                MessageBox.Show("刪除成功")
                pvtReceiveMgr.RaiseProjectModified()
                ClearSystem()
                ClearFunction()
                QuerySystemList()
            Else
                MessageBox.Show("無資料被刪除")
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region
#Region "     功能"

    Private Function CheckInputFunctionCodeAndName() As Boolean
        Try

            If txt_FunctionCode.Text.Length = 0 OrElse txt_FunctionName.Text.Length = 0 Then
                MessageBox.Show("代碼或名稱不得為空")
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub btn_InsertNewSystemFunction_Click(sender As Object, e As EventArgs) Handles btn_InsertNewSystemFunction.Click
        Try
            If CheckInputFunctionCodeAndName() Then
                Exit Sub
            End If

            Dim sendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.InsertNewFunction)
            sendDS.Tables(0).Rows.Add("InsertNewFunction", txt_ProjectID.Text, txt_SystemCode.Text, txt_FunctionCode.Text, txt_FunctionName.Text, "Will", "Will")
            Dim resultDS As DataSet = job.PRJDoAction(sendDS)


            If resultDS IsNot Nothing AndAlso CInt(resultDS.Tables(0).Rows(0).Item(0).ToString.Trim > 0) Then
                MessageBox.Show("新增成功")
                pvtReceiveMgr.RaiseProjectModified()
                ClearFunction()
                QueryFunctionList()
            Else
                MessageBox.Show("無資料被修改")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_UpdateSystemFunction_Click(sender As Object, e As EventArgs) Handles btn_UpdateSystemFunction.Click
        Try
            If CheckInputFunctionCodeAndName() Then
                Exit Sub
            End If
            Dim sendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.UpdateProjectFunction)
            sendDS.Tables(0).Rows.Add("UpdateProjectFunction", txt_ProjectID.Text, txt_SystemCode.Text, txt_FunctionCode.Text, txt_FunctionName.Text, "Will", "Will", "Dc")
            Dim resultDS As DataSet = job.PRJDoAction(sendDS)


            If resultDS IsNot Nothing AndAlso CInt(resultDS.Tables(0).Rows(0).Item(0).ToString.Trim > 0) Then
                MessageBox.Show("新增成功")
                pvtReceiveMgr.RaiseProjectModified()
                QueryFunctionList()
            Else
                MessageBox.Show("無資料被修改")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_DeleteSystemFunction_Click(sender As Object, e As EventArgs) Handles btn_DeleteSystemFunction.Click
        Try
            If CheckInputFunctionCodeAndName() Then
                Exit Sub
            End If
            Dim sendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.DeleteProjectSystemFunction)
            sendDS.Tables(0).Rows.Add("DeleteProjectSystemFunction", txt_ProjectID.Text, txt_SystemCode.Text, txt_FunctionCode.Text)
            Dim resultDS As DataSet = job.PRJDoAction(sendDS)


            If resultDS IsNot Nothing AndAlso CInt(resultDS.Tables(0).Rows(0).Item(0).ToString.Trim > 0) Then
                MessageBox.Show("刪除成功")
                pvtReceiveMgr.RaiseProjectModified()
                ClearFunction()
                QueryFunctionList()
            Else
                MessageBox.Show("無資料被刪除")
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

#Region "     內部函數"

    Private Function GetImportList(ByRef ds As DataSet) As Boolean
        Try
            Dim ProjectSystemDataTable As DataTable = Project.Comm.JOB.PrjProjectSystemDataTableFactory.getDataTable
            Dim ProjectSystemFunction As DataTable = Project.Comm.JOB.PrjProjectSystemFunctionDataTableFactory.getDataTable


            If MessageBox.Show("是否匯入功能清單 專案代號:" & txt_ProjectID.Text, "提示", MessageBoxButtons.YesNo) = DialogResult.Yes AndAlso OpenFileDialog1.ShowDialog = DialogResult.OK Then
                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
                Dim ReadAccess As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & OpenFileDialog1.FileName & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";" ' "provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & OpenFileDialog1.FileName & "'; Extended Properties=Excel 8.0;"
                MyConnection = New System.Data.OleDb.OleDbConnection(ReadAccess)
                MyCommand = New System.Data.OleDb.OleDbDataAdapter _
                ("select * from [Sheet1$]", MyConnection)
                MyCommand.TableMappings.Add("Table", "TestTable")
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)
                MyConnection.Close()

                Dim q2 = (From r In DtSet.Tables(0)
                          Group By app_system_name = r.Item("app_system_name"),
                                       sub_system_no = r.Item("sub_system_no"),
                                       fun_content = r.Item("fun_content").ToString.Split(",")(1).Split(".")(r.Item("fun_content").ToString.Split(",")(1).Split(".").Length - 1),
                                       fun_function_name = r.Item("fun_function_name") Into grp = Group).Select(Function(c) New With {.app_system_name = c.app_system_name, .sub_system_no = c.sub_system_no, .fun_content = c.fun_content, .fun_function_name = c.fun_function_name}).ToList

                For Each S In (From r In DtSet.Tables(0)
                               Group By sub_system_no = r.Item("sub_system_no"), sub_system_name = r.Item("sub_system_name") Into grp = Group).
                                     Select(Function(c) New With {.sub_system_no = c.sub_system_no, .sub_system_name = c.sub_system_name}).ToList
                    Dim newPsDR As DataRow = ProjectSystemDataTable.NewRow
                    Dim pt As New Project.Comm.JOB.PrjProjectSystemDataTableFactory.PRJProjectSystemPt
                    newPsDR(pt.Project_ID) = txt_ProjectID.Text
                    newPsDR(pt.System_Code) = S.sub_system_no
                    newPsDR(pt.System_Name) = S.sub_system_name
                    newPsDR(pt.Modified_User) = currentUser
                    newPsDR(pt.Create_User) = currentUser
                    ProjectSystemDataTable.Rows.Add(newPsDR)
                Next
                For Each S In q2
                    Dim newPsfDR As DataRow = ProjectSystemFunction.NewRow
                    Dim pt As New Project.Comm.JOB.PrjProjectSystemFunctionDataTableFactory.PRJProjectSystemFunctionPt
                    If ProjectSystemFunction.Select(pt.Function_Code & "='" & S.fun_content & "'").Length > 0 Then Continue For
                    newPsfDR(pt.Project_ID) = txt_ProjectID.Text
                    newPsfDR(pt.System_Code) = S.sub_system_no
                    newPsfDR(pt.Function_Code) = S.fun_content
                    newPsfDR(pt.Function_Name) = S.fun_function_name
                    newPsfDR(pt.Modified_User) = currentUser
                    newPsfDR(pt.Create_User) = currentUser
                    ProjectSystemFunction.Rows.Add(newPsfDR)
                Next

                ds.Tables.Add(ProjectSystemDataTable)
                ds.Tables.Add(ProjectSystemFunction)
            Else
                Return True
            End If
        Catch cmex As CommonException
            MessageHandling.ShowWarnMsg("CMMCMMB300", cmex.ToString)
            Throw cmex
        Catch ex As Exception
            MessageHandling.ShowWarnMsg("CMMCMMB300", ex.ToString)
            Throw New CommonException("CMMCMMB302", ex, New String() {"匯入功能清單"})
        End Try
        Return False
    End Function

    Private Function QuerySystemList() As Boolean
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryProjectSystem)
            SendDS.Tables(0).Rows.Add("QueryJobProjectSystem", txt_ProjectID.Text)


            Dim resultDS As DataSet = job.PRJDoAction(SendDS)

            If resultDS IsNot Nothing Then
                dgv_System.ClearSelection()
                dgv_System.DataSource = resultDS.Tables(0).Copy
                For i As Int32 = 0 To PrjSystemListColumnName.Length - 1
                    dgv_System.Columns(i).HeaderText = PrjSystemListColumnName(i)
                Next
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function QueryFunctionList() As Boolean
        Try
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryJobProjectSystemFunction)
            SendDS.Tables(0).Rows.Add("QueryJobProjectSystemFunction", txt_ProjectID.Text, txt_SystemCode.Text)


            Dim resultDS As DataSet = job.PRJDoAction(SendDS)

            If resultDS IsNot Nothing Then
                dgv_Function.ClearSelection()
                dgv_Function.DataSource = resultDS.Tables(0).Copy
                For i As Int32 = 0 To PrjFunctionListColumnName.Length - 1
                    dgv_Function.Columns(i).HeaderText = PrjFunctionListColumnName(i)
                Next
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub ClearFunction()
        txt_FunctionCode.Text = ""
        txt_FunctionName.Text = ""
        dgv_Function.ClearSelection()
        dgv_Function.DataSource = Nothing
    End Sub
    Private Sub ClearSystem()
        txt_SystemCode.Text = ""
        txt_SystemName.Text = ""
        dgv_System.ClearSelection()
        dgv_System.DataSource = Nothing
        cbo_SA.SelectedValue = ""
    End Sub
    Private Sub ClearProject()
        txt_ProjectID.Text = ""
        txt_ProjectName.Text = ""
        cbo_PM.SelectedValue = ""
    End Sub


#End Region

#Region "      檢核"



#End Region
End Class