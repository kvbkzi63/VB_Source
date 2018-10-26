'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBOrderStandingBO_E2.vb
'*              Title:	醫令項目基本檔維護
'*        Description:	醫令項目基本檔維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	william,wang
'*        Create Date:	2009/08/20
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports System.Text

Public Class PUBOrderStandingBO_E2
    Inherits PubOrderStandingBO
    Private Shared myInstance As PUBOrderStandingBO_E2
    Public Shared ReadOnly tableName1 As String = "PUB_Department"
    Public Shared ReadOnly tableName2 As String = "PUB_Order"

    Public Overloads Function getInstance() As PUBOrderStandingBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBOrderStandingBO_E2()
        End If
        Return myInstance
    End Function


    Public Function queryPUBOrderStandingTimeIsExist(ByVal strDept_Code As String, ByVal strOrder_Code As String, ByVal strStart_Time As String, ByVal strEnd_Time As String, ByVal iWeek As Integer) As Boolean
        Dim ds As DataSet
        Dim striWeek As String = CType(iWeek, String)
        Dim strSql As New StringBuilder
        strSql.Append(" SELECT * FROM  PUB_Order_Standing where  ")
        strSql.Append(" ( convert(datetime, '" + strStart_Time + "',120)   between convert(datetime, Service_Start_Time +':00',120) ")
        strSql.Append(" and convert(datetime, Service_End_Time +':00',120)")
        strSql.Append(" or ")
        strSql.Append(" convert(datetime, '" + strEnd_Time + "',120)   between convert(datetime, Service_Start_Time +':00',120)  ")
        strSql.Append(" and convert(datetime, Service_End_Time +':00',120)")
        strSql.Append("  ) and Dept_Code = '" + strDept_Code + "' and Order_Code ='" + strOrder_Code + "' and Week ='" + striWeek + "'")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        If ds.Tables(tableName).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' 查詢醫令項目
    ''' </summary>
    ''' <param name="strDeptCode">科別代碼</param>
    ''' <param name="strOrderCode">醫令項目代碼</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>科別代碼完全匹配;科別名稱與科別英文左匹配</remarks>
    Public Overloads Function queryPUBOrderStandingByCond(ByVal strDeptCode As String, ByVal strOrderCode As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append("Select A.*, RTRIM(A.Dept_Code) + ' - ' + LTRIM(B.Dept_Name) AS Dept_Code_Name, RTRIM(A.Order_Code) + ' - ' + LTRIM(C.Order_Name) AS Order_Code_Name from ")
        strSql.Append(tableName).Append(" A ")
        strSql.Append(" left join ").Append(tableName1).Append(" B ")
        strSql.Append("     ON A.Dept_Code = B.Dept_Code ")
        strSql.Append(" left join ").Append(tableName2).Append(" C ")
        strSql.Append("     ON A.Order_Code = C.Order_Code and C.Dc = 'N'")
        strSql.Append(" Where 1=1 ")
        If strDeptCode.Trim <> "" Then
            strSql.Append(" AND A.Dept_Code = '").Append(strDeptCode).Append("' ")
        End If
        If strOrderCode.Trim <> "" Then
            strSql.Append(" AND A.Order_Code = '").Append(strOrderCode).Append("' ")
        End If
        strSql.Append(" Order By A.Dept_Code,A.Order_Code")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' 查詢科別/護理站選單
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>查詢科別/護理站選單內容</remarks>
    Public Function queryPUBOrderStandingByDept(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim Content As New StringBuilder
            Content.AppendLine("select dept_code,dept_Name from PUB_Department  where dc='N' and Is_Reg_Dept='Y'")
            Content.AppendLine("union all")
            Content.AppendLine("select station_no,Station_Name from PUB_Station  where   dc='N' ")
            Content.AppendLine("union all")
            Content.AppendLine("select 'ER','急診' ")
            Content.AppendLine("union all")
            Content.AppendLine("select 'SUR','開刀房'")

            command.CommandText = Content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function


End Class
