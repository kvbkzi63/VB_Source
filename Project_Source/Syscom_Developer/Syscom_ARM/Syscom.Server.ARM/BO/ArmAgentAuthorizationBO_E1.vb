Imports System.Data.SqlClient
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP

Public Class ArmAgentAuthorizationBO_E1
    Inherits ArmAgentAuthorizationBO

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Shadows ReadOnly Property getInstance() As ArmAgentAuthorizationBO_E1
        Get
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New ArmAgentAuthorizationBO_E1()
    End Class

#End Region

    ''' <summary>
    ''' 查詢資料
    ''' </summary>
    ''' <param name="pk_employee_code">授權人</param>
    ''' <param name="pk_agent_code">代理人</param>
    ''' <param name="conn">資料庫連結</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryByAgentEmployeeCode(ByRef pk_employee_code As System.String, ByRef pk_agent_code As System.String, ByVal role_id As String, ByVal effect_date As String, ByVal end_date As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT Rtrim(PE1.Employee_Name)                   AS Employee_Name, " & vbCrLf)
            sqlString.Append("       Rtrim(PE2.Employee_Name)                   AS Agent_Employee_Name, " & vbCrLf)
            sqlString.Append("       Agent.Role_Id                              AS Role_Id, " & vbCrLf)
            sqlString.Append("       ''                                         AS Role_Name, " & vbCrLf)
            sqlString.Append("       dbo.AdtoRocDate(Agent.Effect_Date)         AS Effect_Date, " & vbCrLf)
            sqlString.Append("       dbo.AdtoRocDate(Agent.End_Date)            AS End_Date, " & vbCrLf)
            sqlString.Append("       Agent.Employee_Code, " & vbCrLf)
            sqlString.Append("       Agent.Agent_Employee_Code " & vbCrLf)
            sqlString.Append("FROM   ARM_Agent_Authorization AS Agent " & vbCrLf)
            sqlString.Append("       LEFT JOIN PUB_Employee AS PE1 " & vbCrLf)
            sqlString.Append("         ON Agent.Employee_Code = PE1.Employee_Code " & vbCrLf)
            sqlString.Append("       LEFT JOIN PUB_Employee AS PE2 " & vbCrLf)
            sqlString.Append("         ON Agent.Agent_Employee_Code = PE2.Employee_Code " & vbCrLf)
            sqlString.Append("WHERE  1 = 1 " & vbCrLf)

            If pk_employee_code <> "" Then
                sqlString.Append("       AND Agent.Employee_Code = @Employee_Code " & vbCrLf)
            End If

            If pk_agent_code <> "" Then
                sqlString.Append("       AND Agent.Agent_Employee_Code = @Agent_Employee_Code " & vbCrLf)
            End If

            If role_id <> "" Then
                sqlString.Append("       AND Agent.Role_Id LIKE @Role_Id " & vbCrLf)
            End If

            If effect_date <> "" AndAlso end_date <> "" Then
                sqlString.Append("       AND ( Agent.Effect_Date BETWEEN @Effect_Date AND @End_Date " & vbCrLf)
                sqlString.Append("             OR Agent.End_Date BETWEEN @Effect_Date AND @End_Date ) " & vbCrLf)
            End If

            sqlString.Append("ORDER  BY Agent.Effect_Date, " & vbCrLf)
            sqlString.Append("          Agent.End_Date ")

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Employee_Code", pk_employee_code)
            command.Parameters.AddWithValue("@Agent_Employee_Code", pk_agent_code)
            command.Parameters.AddWithValue("@Role_Id", "%" & role_id & "%")
            command.Parameters.AddWithValue("@Effect_Date", effect_date)
            command.Parameters.AddWithValue("@End_Date", end_date)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                'adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using

            Dim roleName As String = ""
            Dim instance As New RoleBO
            For Each row As DataRow In ds.Tables(0).Rows
                If row("Role_Id").ToString.Trim <> "" Then
                    Dim role() As String = row("Role_Id").ToString.Trim.Split(",")
                    For Each roleStr As String In role
                        Dim dsResult As DataSet = instance.QueryRole(roleStr, "", "", conn)
                        If dsResult.Tables(0).Rows.Count > 0 Then
                            If roleName <> "" Then
                                roleName &= ","
                            End If
                            roleName &= dsResult.Tables(0).Rows(0).Item("roleName").ToString.Trim
                        End If
                    Next
                    row("Role_Name") = roleName
                    roleName = ""
                End If
            Next

            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

End Class
