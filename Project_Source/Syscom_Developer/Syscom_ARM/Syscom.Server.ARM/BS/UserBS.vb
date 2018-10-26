Imports System.Configuration
Imports Syscom.Comm.LOG
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP

Public Class UserBS

    ''' <summary>
    ''' 認證與授權
    ''' 1.進行認證 確認帳號密碼是否正確以及是否有值
    ''' 2.取得該人員所有角色資訊
    ''' 3.取得角色下所屬權限的部分
    ''' </summary>
    ''' <param name="password"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ArmForUser(ByVal id As String, ByVal password As String) As DataSet
        Try
            Dim userSet As DataSet = ARMDelegate.getInstance.Login(id, password)
            If userSet Is Nothing Then
                Return userSet
            End If

            Dim ds As DataSet = New DataSet
            Dim dt As DataTable = New DataTable("User")
            dt.Columns.Add("userid")
            dt.Columns.Add("username")
            Dim valueobject() As Object = {id, ""}
            dt.Rows.Add(valueobject)
            ds.Tables.Add(dt)

            '準備資料後準備取得 該登入帳號所屬角色以及可使用的功能
            Dim funSet As DataSet = getFunctionOfUser(ds)
            If funSet Is Nothing Then
                Return userSet
            End If

            '將取得的功能權限和個人基本資料一併回傳
            userSet.Merge(funSet)
            Return userSet
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 取得使用者的角色歸屬
    ''' </summary>
    ''' <param name="paraSet">depid, secid, userid, ""</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getFunctionOfUser(ByVal paraSet As DataSet) As DataSet
        Try
            '先取得User所有的角色
            Dim roleInfo As DataSet = ARMDelegate.getInstance.RoleBelongQuery(paraSet)
            Dim roleList As ArrayList = New ArrayList
            For Each row As DataRow In roleInfo.Tables("Role").Rows
                '若是否歸屬欄位資料是1 則表示該User有屬於該角色 這查詢由谷官提供
                If row.Item("是否歸屬").ToString = "1" Then
                    roleList.Add(row.Item("角色名稱"))
                End If
            Next

            If roleList.Count = 0 Then
                Return Nothing
            End If

            Dim authSet As DataSet = New DataSet
            Dim rolearray(roleList.Count - 1) As String
            For index As Integer = 0 To roleList.Count - 1
                rolearray(index) = roleList.Item(index).ToString
            Next
            Return getAllFunctionOfRoles(rolearray)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 長度至少為1啊
    ''' 若效能有問題可犧牲tsk 和sub的部分
    ''' </summary>
    ''' <param name="roleid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getAllFunctionOfRoles(ByVal roleid() As String) As DataSet
        Dim MyConnect As SqlClient.SqlConnection = CType(getConnection(), System.Data.SqlClient.SqlConnection)
        '訂Dataset
        Dim MyDt As New DataSet
        Dim MyTable As New DataTable
        Dim preSqlBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim roleRightsSqlBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim sbuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim roleBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Try
            MyConnect.Open()
            '準備前面的sql
            preSqlBuilder.Append("SELECT fun_function_no, fun_function_name, fun_display_order, fun_content, sub_system_no, sub_system_name, sub_display_order, fun_task_no, tsk_task_name, tsk_display_order ") _
            .Append("FROM arm_fun_system, arm_tsk_system, arm_sub_system ")

            '湊條件
            For Each id As String In roleid
                roleBuilder.Append("'").Append(id).Append("',")
            Next
            roleBuilder.Length = roleBuilder.Length - 1

            '準備後方的sql
            roleRightsSqlBuilder.Append("SELECT rrs_rights_id FROM arm_rolerights WHERE (rrs_role_id IN (")
            roleRightsSqlBuilder.Append(roleBuilder)

            'check fun
            sbuilder.Append(preSqlBuilder).Append(" WHERE arm_sub_system.sub_system_no = tsk_sub_system_no and arm_tsk_system.tsk_task_no = fun_task_no and fun_function_no IN (")
            sbuilder.Append(roleRightsSqlBuilder).Append(") AND RRS_RIGHTS_TYPE = 'fun')) ")
            sbuilder.Append(" UNION ")
            'check task
            sbuilder.Append(preSqlBuilder).Append(" WHERE arm_sub_system.sub_system_no = tsk_sub_system_no and arm_tsk_system.tsk_task_no = fun_task_no and fun_task_no IN (")
            sbuilder.Append(roleRightsSqlBuilder).Append(") AND rrs_rights_type = 'tsk')) ")
            sbuilder.Append(" UNION ")
            'check sub
            sbuilder.Append(preSqlBuilder).Append(" WHERE arm_sub_system.sub_system_no = tsk_sub_system_no and arm_tsk_system.tsk_task_no = fun_task_no and sub_system_no IN (")
            sbuilder.Append(roleRightsSqlBuilder).Append(") AND rrs_rights_type = 'sub')) ")
            sbuilder.Append(" ORDER BY sub_display_order, tsk_display_order, fun_display_order ")
            Using Mycommand As SqlClient.SqlCommand = New SqlClient.SqlCommand(sbuilder.ToString, MyConnect)
                Using MyAdapter As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(Mycommand)
                    MyAdapter.FillSchema(MyTable, SchemaType.Source)
                    MyAdapter.Fill(MyTable)
                    MyTable.TableName = "arm_fun_system"
                    MyDt.Tables.Add(MyTable)
                    MyConnect.Close()
                End Using
            End Using
        Catch sqlex As SqlClient.SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If MyConnect IsNot Nothing AndAlso MyConnect.State <> ConnectionState.Closed Then
                MyConnect.Close()
                MyConnect.Dispose()
                MyConnect = Nothing
            End If
        End Try
        Return MyDt
    End Function

    Private Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getArmDBSqlConn
    End Function

End Class
