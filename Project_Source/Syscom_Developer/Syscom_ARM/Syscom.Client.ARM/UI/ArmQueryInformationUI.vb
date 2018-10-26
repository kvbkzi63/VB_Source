Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports System.Windows.Forms

Public Class ArmQueryInformationUI

    Private dsRole As DataSet

    ''' <summary>
    ''' 頁面載入
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ArmQueryInformationUI_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            dsRole = ARM.QueryRole("", "", "")
            dsRole.Tables(0).PrimaryKey = New DataColumn() {dsRole.Tables(0).Columns("roleID")}
            Dim dtRoleGroup As New DataTable
            Dim roleGroupId As String = ""
            Dim roleGroupName As String = ""
            dtRoleGroup.Columns.Add("Role_Group_Id")
            dtRoleGroup.Columns.Add("Role_Group_Name")
            dtRoleGroup.PrimaryKey = New DataColumn() {dtRoleGroup.Columns("Role_Group_Id")}
            For Each singleRow As DataRow In dsRole.Tables(0).Rows
                roleGroupId = singleRow("roleID").ToString.Trim.Substring(0, 3)
                roleGroupName = roleGroupId
                If Not dtRoleGroup.Rows.Contains(roleGroupId) Then
                    Dim ds As DataSet = ARM.SubQueryByPK(roleGroupId)
                    If ds.Tables(0).Rows.Count > 0 Then
                        roleGroupName = ds.Tables(0).Rows(0).Item("sub_system_name").ToString.Trim
                    End If
                    dtRoleGroup.Rows.Add(New String() {roleGroupId, roleGroupName})
                End If
            Next

            cbo_RoleGroup.DataSource = dtRoleGroup
            cbo_RoleGroup.uclDisplayIndex = "1"
            cbo_RoleGroup.uclValueIndex = "0"

            Dim dsFun As DataSet = ARM.FunQueryByPK("")
            cbo_FunctionId.DataSource = dsFun.Tables(0)
            cbo_FunctionId.uclDisplayIndex = "6,7"
            cbo_FunctionId.uclValueIndex = "6"
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Query_Click(sender As Object, e As EventArgs) Handles btn_Query.Click
        Try
            Dim ds As DataSet
            If rbo_Employee.Checked Then

                If tcq_EmployeeCode.getCode = "" Then
                    MessageHandling.ShowWarnMsg("CMMCMMB305", New String() {"員工代碼"})
                    Exit Sub
                End If

                ds = ARM.RoleQueryByEmployee(tcq_EmployeeCode.getCode)
                dgv_ShowData.Initial(ds)
            ElseIf rbo_Role.Checked Then

                If cbo_RoleId.SelectedValue = "" Then
                    MessageHandling.ShowWarnMsg("CMMCMMB305", New String() {"角色代碼"})
                    Exit Sub
                End If

                ds = ARM.EmployeeQueryByRole(cbo_RoleId.SelectedValue)
                dgv_ShowData.Initial(ds)
            ElseIf rbo_Function.Checked Then

                If cbo_FunctionId.SelectedValue = "" Then
                    MessageHandling.ShowWarnMsg("CMMCMMB305", New String() {"功能代碼"})
                    Exit Sub
                End If

                ds = ARM.EmployeeQueryByFunction(cbo_FunctionId.SelectedValue)
                dgv_ShowData.Initial(ds)

                If ds.Tables(0).Rows.Count > 0 Then
                    MessageHandling.ShowInfoMsg("CMMCMMB901")
                Else
                    MessageHandling.ShowWarnMsg("CMMCMMB933")
                End If
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        Try
            MessageHandling.ClearInfoMsg()
            rbo_Employee.Checked = False
            rbo_Role.Checked = False
            rbo_Function.Checked = False
            tcq_EmployeeCode.Clear()
            cbo_RoleId.SelectedValue = ""
            cbo_FunctionId.SelectedValue = ""
            dgv_ShowData.ClearDS()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 匯出 Excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Excel_Click(sender As Object, e As EventArgs) Handles btn_Excel.Click
        Try
            If dgv_ShowData.GetDBDS Is Nothing Then
                Exit Sub
            End If
            Dim ds As New DataSet
            Dim condData As New DataTable
            condData.Columns.Add("Employee_Name")
            condData.Columns.Add("Role_Name")
            condData.Columns.Add("Fun_Function_Name")
            For Each col As DataColumn In dgv_ShowData.GetDBDS.Tables(0).Columns
                condData.Columns.Add(col.ColumnName)
            Next
            condData.Rows.Add(New String() {tcq_EmployeeCode.getCodeName, cbo_RoleId.Text, cbo_FunctionId.Text})
            ds.Tables.Add(condData)
            ds.Tables.Add(dgv_ShowData.GetDBDS.Tables(0).Copy)
            ds.Tables(1).TableName = "多面相查詢匯出表"
            Dim instance As New ARMRPT000002Client
            instance.preview(ds)
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub cbo_RoleGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_RoleGroup.SelectedIndexChanged
        If cbo_RoleGroup.SelectedValue = "" Then
            cbo_RoleId.DataSource = Nothing
        Else
            Dim dt As DataTable = dsRole.Tables(0).Select("Substring(roleID, 1, 3) = '" & cbo_RoleGroup.SelectedValue & "'").CopyToDataTable

            cbo_RoleId.DataSource = dt
            cbo_RoleId.uclDisplayIndex = "1"
            cbo_RoleId.uclValueIndex = "0"
        End If
    End Sub

#Region " HotKey設定"

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                '清除
                'MessageHandling.clearInfoMsg()
                btn_Clear.PerformClick()
            Case Keys.F12
                '刪除 SF12
                'If e.Shift Then
                '    If (btn_Delete.Enabled) Then btn_Delete.PerformClick()
                'Else
                '    '新增F12
                '    If (btn_Insert.Enabled) Then btn_Insert.PerformClick()
                'End If
            Case Keys.F10
                '修改
                'If (btnUpdate.Enabled) Then btnUpdate_Click(sender, e)
            Case Keys.F1
                '查詢
                btn_Query.PerformClick()
            Case Keys.Enter
                Me.ProcessTabKey(True)
        End Select
    End Sub

#End Region

End Class