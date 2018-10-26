Imports Syscom.Comm.Utility
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.CMM
Imports System.Windows.Forms

Public Class AuthorizationAgentUI
    Inherits Syscom.Client.UCL.BaseFormUI

    Private dsRole As DataSet

    ''' <summary>
    ''' 載入畫面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AuthorizationAgentUI_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Label3.Text = AppContext.userProfile.userName

            If AppContext.userProfile.agentId <> "unknown" Then
                Me.Enabled = False
            End If

            dsRole = ARM.QueryRole("", "", "")
            dsRole.Tables(0).PrimaryKey = New DataColumn() {dsRole.Tables(0).Columns("roleID")}

            dtp_EffectDate.SetValue(Now)
            dtp_EndDate.SetValue(Now.AddMonths(1))

            Dim dtRoleInfo As New DataTable
            dtRoleInfo.Columns.Add("Parent_Code_Id")
            dtRoleInfo.Columns.Add("Parent_Code_Name")
            dtRoleInfo.Columns.Add("Layer_Code_Id")
            dtRoleInfo.Columns.Add("Layer_Code_Name")
            Dim row As DataRow = dtRoleInfo.NewRow
            row.Item("Parent_Code_Id") = ""
            row.Item("Parent_Code_Name") = ""
            row.Item("Layer_Code_Id") = "All_Role"
            row.Item("Layer_Code_Name") = "所有角色"
            dtRoleInfo.Rows.Add(row)

            Dim userMemberOf As String = AppContext.userProfile.userMemberOf
            For Each obj As String In userMemberOf.Split(",")
                If obj.Replace("'", "").Trim <> "" Then
                    If dsRole.Tables(0).Rows.Contains(obj.Replace("'", "")) Then
                        Dim queryRow As DataRow = dsRole.Tables(0).Rows.Find(obj.Replace("'", ""))
                        If queryRow.Item("isAgent").ToString.Trim = "Y" Then
                            row = dtRoleInfo.NewRow
                            row.Item("Parent_Code_Id") = "All_Role"
                            row.Item("Parent_Code_Name") = "所有角色"
                            row.Item("Layer_Code_Id") = obj.Replace("'", "")
                            row.Item("Layer_Code_Name") = queryRow("roleName").ToString.Trim
                            dtRoleInfo.Rows.Add(row)
                        End If
                    End If
                End If
            Next

            tree_Review.TreeViewName = "角色清單"
            tree_Review.SetTreeView(dtRoleInfo, "Parent_Code_Id", "Parent_Code_Name", "Layer_Code_Id", "Layer_Code_Name", True)
            tree_Review.ExpandAll()

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

            btn_Query.PerformClick()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Insert_Click(sender As Object, e As EventArgs) Handles btn_Insert.Click
        Try
            If tcq_AgentCode.getCode = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB305", New String() {"代理人"})
                Exit Sub
            End If

            If dtp_EffectDate.GetUsDateStr = "" Or dtp_EndDate.GetUsDateStr = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB305", New String() {"有效日期"})
                Exit Sub
            Else
                If CDate(dtp_EffectDate.GetUsDateStr) < Now.Date Then
                    MessageHandling.ShowWarnMsg("CMMCMMB306", New String() {"有效日期起日", "今天"})
                    Exit Sub
                ElseIf CDate(dtp_EffectDate.GetUsDateStr) > CDate(dtp_EndDate.GetUsDateStr) Then
                    MessageHandling.ShowWarnMsg("CMMCMMB307", New String() {"有效日期起日", "迄日"})
                    Exit Sub
                End If
            End If

            If tree_Review.GetSelectedItemsResultInDataTable(False).Rows.Count = 0 Then
                MessageHandling.ShowWarnMsg("CMMCMMB305", New String() {"角色"})
                Exit Sub
            End If

            Dim ds As DataSet = ArmAgentAuthorizationDataTableFactory.getDataSet
            ds.Tables(0).Columns.Add("Agent_Employee_Name")
            ds.Tables(0).Columns.Add("Employee_Name")
            ds.Tables(0).Columns("Agent_Employee_Name").SetOrdinal(0)
            ds.Tables(0).Columns("Employee_Name").SetOrdinal(0)

            Dim agentName As String = tcq_AgentCode.getCodeName
            Dim roleId As String = ""
            Dim dt As DataTable = tree_Review.GetSelectedItemsResultInDataTable(False)
            For Each _row As DataRow In dt.Rows
                If roleId <> "" Then
                    roleId &= ","
                End If
                roleId &= _row("Layer_Code_Id")
            Next

            '檢查是否完全重疊
            Dim dsCheck As DataSet = ARM.queryByAgentEmployeeCode(AppContext.userProfile.userId, tcq_AgentCode.getCode, roleId, "", "")
            For Each chkRow As DataRow In dsCheck.Tables(0).Rows
                If CDate(dtp_EffectDate.GetUsDateStr) >= CDate(DateUtil.TransDateToWE(chkRow("Effect_Date"))) AndAlso CDate(dtp_EndDate.GetUsDateStr) <= CDate(DateUtil.TransDateToWE(chkRow("End_Date"))) Then
                    MessageHandling.ShowWarnMsg("CMMCMMB308", New String() {"授權設定中"})
                    Exit Sub
                End If
            Next

            Dim row As DataRow = ds.Tables(0).NewRow
            row.Item("Employee_Code") = AppContext.userProfile.userId
            row.Item("Employee_Name") = AppContext.userProfile.userName
            row.Item("Agent_Employee_Code") = tcq_AgentCode.getCode
            row.Item("Agent_Employee_Name") = agentName
            row.Item("Role_Id") = roleId
            row.Item("Effect_Date") = dtp_EffectDate.GetUsDateStr
            row.Item("End_Date") = dtp_EndDate.GetUsDateStr
            ds.Tables(0).Rows.Add(row)

            Dim count As Integer = ARM.insertArmAgentAuth(ds)
            If count > 0 Then
                btn_Query.PerformClick()
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        If dgv_ShowData.CurrentRow Is Nothing Then
            MessageHandling.ShowWarnMsg("CMMCMMB304", New String() {"欲刪除的"})
            Exit Sub
        End If
        With dgv_ShowData.GetDBDS.Tables(0).Rows(dgv_ShowData.CurrentRow.Index)
            Dim count As Integer = ARM.deleteArmAgentAuth(.Item("Employee_Code").ToString.Trim, .Item("Agent_Employee_Code").ToString.Trim, .Item("Role_Id").ToString.Trim, DateUtil.TransDateToWE(.Item("Effect_Date")))
            If count > 0 Then
                btn_Query.PerformClick()
            End If
        End With
    End Sub

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Query_Click(sender As Object, e As EventArgs) Handles btn_Query.Click
        Try
            If dtp_EffectDateQuery.GetUsDateStr <> "" AndAlso dtp_EndDateQuery.GetUsDateStr <> "" Then
                If dtp_EffectDate.GetUsDateStr = "" Or dtp_EndDate.GetUsDateStr = "" Then
                    MessageHandling.ShowWarnMsg("CMMCMMB305", New String() {"有效日期起訖"})
                    Exit Sub
                ElseIf CDate(dtp_EffectDateQuery.GetUsDateStr) > CDate(dtp_EndDateQuery.GetUsDateStr) Then
                    MessageHandling.ShowWarnMsg("CMMCMMB307", New String() {"有效日期起日", "迄日"})
                    Exit Sub
                End If
            End If

            Dim ds As DataSet = ARM.queryByAgentEmployeeCode(AppContext.userProfile.userId, tcq_AgentCodeQuery.getCode, cbo_RoleIdQuery.SelectedValue, dtp_EffectDateQuery.GetUsDateStr, dtp_EndDateQuery.GetUsDateStr)
            dgv_ShowData.Initial(ds)
            dgv_ShowData.uclHeaderText = "授權人,代理人,,角色,有效起日,有效迄日"
            dgv_ShowData.uclVisibleColIndex = "0,1,3,4,5"
            dgv_ShowData.uclColumnWidth = "100,100,100,250"
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
            tcq_AgentCodeQuery.Clear()
            dtp_EffectDateQuery.Clear()
            dtp_EndDateQuery.Clear()
            cbo_RoleGroup.SelectedValue = ""

            tcq_AgentCode.Clear()
            dtp_EffectDate.SetValue(Now)
            dtp_EndDate.SetValue(Now.AddMonths(1))
            tree_Review.ClearAllChecked()
            dgv_ShowData.ClearDS()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub

    Private Sub cbo_RoleGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_RoleGroup.SelectedIndexChanged
        If cbo_RoleGroup.SelectedValue = "" Then
            cbo_RoleIdQuery.DataSource = Nothing
        Else
            Dim dt As DataTable = dsRole.Tables(0).Select("Substring(roleID, 1, 3) = '" & cbo_RoleGroup.SelectedValue & "'").CopyToDataTable

            cbo_RoleIdQuery.DataSource = dt
            cbo_RoleIdQuery.uclDisplayIndex = "1"
            cbo_RoleIdQuery.uclValueIndex = "0"
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
                If e.Shift Then
                    If (btn_Delete.Enabled) Then btn_Delete.PerformClick()
                Else
                    '新增F12
                    If (btn_Insert.Enabled) Then btn_Insert.PerformClick()
                End If
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