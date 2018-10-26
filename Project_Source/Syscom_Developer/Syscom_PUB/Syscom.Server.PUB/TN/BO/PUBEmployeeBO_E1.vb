Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Data.SqlTypes

Public Class PUBEmployeeBO_E1
    Inherits PubEmployeeBO

    Dim log As LOGDelegate = LOGDelegate.getInstance

#Region "########## getInstance ##########"

    Private Shared instance As PUBEmployeeBO_E1

    Public Overloads Shared Function getInstance() As PUBEmployeeBO_E1
        If instance Is Nothing Then
            instance = New PUBEmployeeBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region


#Region " 根據員工編號取得員工資料 "

    ''' <summary>
    ''' 根據員工編號取得員工資料
    ''' </summary>
    ''' <param name="EmployeeCode" >員工編號</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2014-09-01</remarks>
    Public Function queryEmployeeByEmpCode(ByVal EmployeeCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            '根據員工編號取得員工資料
            ds = queryEmployeeByType(EmployeeCode, Nothing, 1, conn)

            Return ds

        Catch sqlex As SqlException
            Throw sqlex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function

#End Region

#Region " 根據員工編號和日期取得有效期限的員工資料 "

    ''' <summary>
    ''' 根據員工編號和日期取得有效期限的員工資料
    ''' </summary>
    ''' <param name="EmployeeCode" >員工編號</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2014-09-01</remarks>
    Public Function queryEmployeeByEmpCodeAndDate(ByVal EmployeeCode As String, ByVal JudgeDate As Date, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            '根據員工編號和日期取得有效期限的員工資料
            ds = queryEmployeeByType(EmployeeCode, JudgeDate, 2, conn)

            Return ds

        Catch sqlex As SqlException
            Throw sqlex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function

#End Region

#Region " 根據員工編號、日期、型態、取得符合條件的員工資料 "

    ''' <summary>
    ''' 根據員工編號、日期、型態、取得符合條件的員工資料
    ''' 
    ''' TypeFlag: 1.依員工號 2.依員工號和日期的有效資料
    ''' 
    ''' </summary>
    ''' <param name="EmployeeCode" >員工編號</param>
    ''' <param name="JudgeDate" >作為判斷依據的日期</param>
    ''' <param name="TypeFlag" >條件的分類型態:1.依員工號 2.依員工號和日期的有效資料</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2014-09-01</remarks>
    Private Function queryEmployeeByType(ByVal EmployeeCode As String, ByVal JudgeDate As Date, ByVal TypeFlag As Integer, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT PE.Employee_Code, " & vbCrLf)
            sqlString.Append("       PE.Employee_Name, " & vbCrLf)
            sqlString.Append("       PE.Employee_En_Name, " & vbCrLf)
            sqlString.Append("       PE.Idno, " & vbCrLf)
            sqlString.Append("       PE.Assume_Effect_Date, " & vbCrLf)
            sqlString.Append("       PE.Assume_End_Date, " & vbCrLf)
            sqlString.Append("       PE.Professal_Kind_Id, " & vbCrLf)
            sqlString.Append("       PE.Emp_Status_Id, " & vbCrLf)
            sqlString.Append("       PE.Dept_Code, " & vbCrLf)
            sqlString.Append("       PD.Dept_Name, " & vbCrLf)
            sqlString.Append("       PE.Acc_Dept, " & vbCrLf)
            sqlString.Append("       PE.Email, " & vbCrLf)
            sqlString.Append("       PE.Tel_Mobile, " & vbCrLf)
            sqlString.Append("       PE.Nrs_Level_Id , PD.Dept_Code as dr_Dept_Code,PD1.Dept_Name as dr_Dept_Name " & vbCrLf)
            sqlString.Append("FROM   PUB_Employee AS PE " & vbCrLf)
            sqlString.Append("       Left JOIN PUB_Department AS PD " & vbCrLf)
            sqlString.Append("         ON PE.Dept_Code = PD.Dept_Code " & vbCrLf)
            'sqlString.Append("       Left JOIN PUB_Doctor AS PDR " & vbCrLf)
            'sqlString.Append("         ON PE.Employee_Code = PDR.Employee_Code " & vbCrLf)
            sqlString.Append("       Left JOIN PUB_Department AS PD1 " & vbCrLf)
            sqlString.Append("         ON PD.Dept_Code = PD1.Dept_Code " & vbCrLf)
            sqlString.Append("WHERE  PE.Employee_Code = @Employee_Code ")

            Select Case TypeFlag

                Case 1
                    '1.依員工號，不動作 

                Case 2
                    '2.依員工號和日期的有效資料，增加有效日期判斷
                    sqlString.Append("       AND @JudgeDate BETWEEN PE.Assume_Effect_Date AND PE.Assume_End_Date ")

            End Select


            command.CommandText = sqlString.ToString

            command.Parameters.AddWithValue("@Employee_Code", EmployeeCode)


            Select Case TypeFlag

                Case 1
                    '1.依員工號，不動作 

                Case 2
                    '2.依員工號和日期的有效資料，增加有效日期參數
                    command.Parameters.AddWithValue("@JudgeDate", JudgeDate.ToString("yyyy-MM-dd"))

            End Select


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw sqlex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function

#End Region

#Region "取得全部員工歸屬資料"
    ''' <summary>
    ''' 根據員工編號和日期取得有效期限的員工資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Lits on 2014-12-02</remarks>
    Public Function queryEmployeeALL(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            'Dim SqlString As New System.Text.StringBuilder
            'SqlString.Append("SELECT B.Dept_Code, " & vbCrLf)
            'SqlString.Append("       B.Dept_Name, " & vbCrLf)
            'SqlString.Append("       A.Employee_Code, " & vbCrLf)
            'SqlString.Append("       A.Employee_Name, " & vbCrLf)
            'SqlString.Append("       B.Dept_Level_Id, " & vbCrLf)
            'SqlString.Append("       B.Upper_Dept_Code, " & vbCrLf)
            'SqlString.Append("       C.Dept_Name " & vbCrLf)
            'SqlString.Append("FROM   PUB_Employee A " & vbCrLf)
            'SqlString.Append("       INNER JOIN PUB_Department B " & vbCrLf)
            'SqlString.Append("               ON A.Dept_Code = B.Dept_Code " & vbCrLf)
            'SqlString.Append("       INNER JOIN PUB_Department C " & vbCrLf)
            'SqlString.Append("               ON B.Upper_Dept_Code = C.Dept_Code " & vbCrLf)
            'SqlString.Append("       where Assume_End_Date >='" & Now.Date.ToString("yyyy-MM-dd HH:mm:ss") & "' " & vbCrLf)
            'SqlString.Append("ORDER  BY B.Dept_Code")

            'command.CommandText = SqlString.ToString

            ''根據員工編號和日期取得有效期限的員工資料
            'Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
            '    ds = New DataSet(tableName)
            '    adapter.Fill(ds, tableName)
            'End Using

            '有空單位========================================================================================================
            'Dim  SqlString As new System.Text.StringBuilder
            'SqlString.Append("SELECT DISTINCT  T.Dept1 , T.Name1 , T.Dept2 , T.Name2, T.Dept3, T.Name3 " & vbCrLf)
            'SqlString.Append(",T.Dept_Code , T.Short_Name ,  T.Upper_Dept_Code , T.Dept_Level_Id , T.Down_Level " & vbCrLf)
            'SqlString.Append(", P.Employee_Code , P.Employee_Name , P.Dept_Code  AS EMPLOYEE_DEPT " & vbCrLf)
            'SqlString.Append("into #tempdept " & vbCrLf)
            'SqlString.Append("  FROM " & vbCrLf)
            'SqlString.Append("( " & vbCrLf)
            'SqlString.Append("select distinct  A.Dept_Code , A.Short_Name , A.Upper_Dept_Code, A.Dept_Level_Id , D.Dept_Level_Id  AS Down_Level " & vbCrLf)
            'SqlString.Append(", A.Dept_Code as Dept1, A.Short_Name as Name1, '' as Dept2 , '' as Name2 " & vbCrLf)
            'SqlString.Append(", '' as Dept3 , '' as Name3 " & vbCrLf)
            'SqlString.Append("from PUB_Department A " & vbCrLf)
            'SqlString.Append("left join PUB_Department D on A.Dept_Code = D.Upper_Dept_Code  and D.Dept_Code <> D.Upper_Dept_Code " & vbCrLf)
            'SqlString.Append("where A.Dept_Level_Id = '1' " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("UNION " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("select distinct  A.Dept_Code , A.Short_Name , A.Upper_Dept_Code , A.Dept_Level_Id  , isnull(D.Dept_Level_Id,'')  AS Down_Level " & vbCrLf)
            'SqlString.Append(", A1.Dept_Code as Dept1, A1.Short_Name as Name1, '' as Dept2 , '' as Name2 " & vbCrLf)
            'SqlString.Append(", '' as Dept3 , '' as Name3 " & vbCrLf)
            'SqlString.Append("from PUB_Department A " & vbCrLf)
            'SqlString.Append("LEFT join PUB_Department A1 ON A.Upper_Dept_Code = A1.Dept_Code  AND A1.Dept_Level_Id = '1' AND A.Dept_Level_Id = '2' " & vbCrLf)
            'SqlString.Append("left join PUB_Department D on A.Dept_Code = D.Upper_Dept_Code  and D.Dept_Code <> D.Upper_Dept_Code " & vbCrLf)
            'SqlString.Append("where A.Upper_Dept_Code is not null " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select distinct  A.Dept_Code , A.Short_Name , A.Upper_Dept_Code , A.Dept_Level_Id  , isnull(D.Dept_Level_Id,'')  AS Down_Level " & vbCrLf)
            'SqlString.Append(", A3.Dept_Code as Dept1, A3.Short_Name as Name1, A2.Dept_Code as Dept2 , A2.Short_Name as Name2 " & vbCrLf)
            'SqlString.Append(", '' as Dept3 , '' as Name3 " & vbCrLf)
            'SqlString.Append("from PUB_Department A " & vbCrLf)
            'SqlString.Append("LEFT join PUB_Department A2 ON A.Upper_Dept_Code = A2.Dept_Code  AND A2.Dept_Level_Id = '2' AND A.Dept_Level_Id = '3' " & vbCrLf)
            'SqlString.Append("LEFT join PUB_Department A3 ON A2.Upper_Dept_Code = A3.Dept_Code  AND A3.Dept_Level_Id = '1' " & vbCrLf)
            'SqlString.Append("left join PUB_Department D on A.Dept_Code = D.Upper_Dept_Code  and D.Dept_Code <> D.Upper_Dept_Code " & vbCrLf)
            'SqlString.Append("where A.Upper_Dept_Code is not null " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select distinct  A.Dept_Code , A.Short_Name , A.Upper_Dept_Code , A.Dept_Level_Id   , isnull(D.Dept_Level_Id,'')  AS Down_Level " & vbCrLf)
            'SqlString.Append(", A4.Dept_Code as Dept1, A4.Short_Name as Name1, A3.Dept_Code as Dept2 , A3.Short_Name as Name2 " & vbCrLf)
            'SqlString.Append(", A2.Dept_Code  as Dept3 , A2.short_name  as Name3 " & vbCrLf)
            'SqlString.Append("from PUB_Department A " & vbCrLf)
            'SqlString.Append("LEFT join PUB_Department A2 ON A.Upper_Dept_Code = A2.Dept_Code  AND A2.Dept_Level_Id = '3' AND A.Dept_Level_Id = '4' " & vbCrLf)
            'SqlString.Append("LEFT join PUB_Department A3 ON A2.Upper_Dept_Code = A3.Dept_Code  AND A3.Dept_Level_Id = '2' " & vbCrLf)
            'SqlString.Append("LEFT join PUB_Department A4 ON A3.Upper_Dept_Code = A4.Dept_Code  AND A4.Dept_Level_Id = '1' " & vbCrLf)
            'SqlString.Append("left join PUB_Department D on A.Dept_Code = D.Upper_Dept_Code  and D.Dept_Code <> D.Upper_Dept_Code " & vbCrLf)
            'SqlString.Append("where A.Upper_Dept_Code is not null  ) T " & vbCrLf)
            'SqlString.Append("LEFT JOIN PUB_Employee  P ON T.Dept_Code = P.Dept_Code  AND P.Assume_End_Date > GETDATE () " & vbCrLf)
            'SqlString.Append("WHERE DEPT1 IS NOT NULL " & vbCrLf)
            'SqlString.Append("ORDER BY T.Dept1 , T.Dept2, T.DEPT3, T.DEPT_CODE, P.Employee_Code;" & vbCrLf)


            'SqlString.Append("select '' as code1, '' as  name1, Dept_Code as  code2, Short_Name  name2 " & vbCrLf)
            'SqlString.Append("from #tempdept " & vbCrLf)
            'SqlString.Append("where Dept_Level_Id = '1' " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select Dept_Code as code1, Short_Name as code2 ,  Employee_Code as code2, Employee_Name as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept " & vbCrLf)
            'SqlString.Append("where Dept_Level_Id = '1' " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select DISTINCT  B.Dept_Code as code1, B.Short_Name  as name1, A.Dept_Code  as code2, A.Short_Name  as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept  A " & vbCrLf)
            'SqlString.Append("inner join  #tempdept B ON B.Dept_Code  = A.Upper_Dept_Code " & vbCrLf)
            'SqlString.Append("where A.Dept_Level_Id   = '2' " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select distinct  Dept_Code as code1, Short_Name as code2 ,  Employee_Code as code2, Employee_Name as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept " & vbCrLf)
            'SqlString.Append("where Dept_Level_Id = '2' AND EMPLOYEE_CODE IS NOT NULL " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select DISTINCT  B.Dept_Code as code1, B.Short_Name  as name1, A.Dept_Code  as code2, A.Short_Name  as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept  A " & vbCrLf)
            'SqlString.Append("inner join  #tempdept B ON B.Dept_Code  = A.Upper_Dept_Code " & vbCrLf)
            'SqlString.Append("where A.Dept_Level_Id   = '3' " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select  Dept_Code as code1, Short_Name as code2 ,  Employee_Code as code2, Employee_Name as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept " & vbCrLf)
            'SqlString.Append("where Dept_Level_Id = '3' AND EMPLOYEE_CODE IS NOT NULL " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select DISTINCT  B.Dept_Code as code1, B.Short_Name  as name1, A.Dept_Code  as code2, A.Short_Name  as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept  A " & vbCrLf)
            'SqlString.Append("inner join  #tempdept B ON B.Dept_Level_Id = A.Down_Level " & vbCrLf)
            'SqlString.Append("where A.Dept_Level_Id  = '4' " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select  Dept_Code as code1, Short_Name as code2 ,  Employee_Code as code2, Employee_Name as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept " & vbCrLf)
            'SqlString.Append("where Dept_Level_Id = '4' AND EMPLOYEE_CODE IS NOT NULL;" & vbCrLf)

            'SqlString.Append("drop table  #tempdept")
            ' 無空單位================================================================================================================
            'Dim SqlString As New System.Text.StringBuilder
            'SqlString.Append("SELECT DISTINCT  T.Dept1 , T.Name1 , T.Dept2 , T.Name2, T.Dept3, T.Name3 " & vbCrLf)
            'SqlString.Append(",T.Dept_Code , T.Short_Name ,  T.Upper_Dept_Code , T.Dept_Level_Id , T.Down_Level " & vbCrLf)
            'SqlString.Append(", P.Employee_Code , P.Employee_Name , P.Dept_Code  AS EMPLOYEE_DEPT " & vbCrLf)
            'SqlString.Append("into #tempdept " & vbCrLf)
            'SqlString.Append("  FROM " & vbCrLf)
            'SqlString.Append("( " & vbCrLf)
            'SqlString.Append("select distinct  A.Dept_Code , A.Short_Name , A.Upper_Dept_Code, A.Dept_Level_Id , D.Dept_Level_Id  AS Down_Level " & vbCrLf)
            'SqlString.Append(", A.Dept_Code as Dept1, A.Short_Name as Name1, '' as Dept2 , '' as Name2 " & vbCrLf)
            'SqlString.Append(", '' as Dept3 , '' as Name3 " & vbCrLf)
            'SqlString.Append("from PUB_Department A " & vbCrLf)
            'SqlString.Append("left join PUB_Department D on A.Dept_Code = D.Upper_Dept_Code  and D.Dept_Code <> D.Upper_Dept_Code " & vbCrLf)
            'SqlString.Append("where A.Dept_Level_Id = '1' " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("UNION " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("select distinct  A.Dept_Code , A.Short_Name , A.Upper_Dept_Code , A.Dept_Level_Id  , isnull(D.Dept_Level_Id,'')  AS Down_Level " & vbCrLf)
            'SqlString.Append(", A1.Dept_Code as Dept1, A1.Short_Name as Name1, '' as Dept2 , '' as Name2 " & vbCrLf)
            'SqlString.Append(", '' as Dept3 , '' as Name3 " & vbCrLf)
            'SqlString.Append("from PUB_Department A " & vbCrLf)
            'SqlString.Append("LEFT join PUB_Department A1 ON A.Upper_Dept_Code = A1.Dept_Code  AND A1.Dept_Level_Id = '1' AND A.Dept_Level_Id = '2' " & vbCrLf)
            'SqlString.Append("left join PUB_Department D on A.Dept_Code = D.Upper_Dept_Code  and D.Dept_Code <> D.Upper_Dept_Code " & vbCrLf)
            'SqlString.Append("where A.Upper_Dept_Code is not null " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select distinct  A.Dept_Code , A.Short_Name , A.Upper_Dept_Code , A.Dept_Level_Id  , isnull(D.Dept_Level_Id,'')  AS Down_Level " & vbCrLf)
            'SqlString.Append(", A3.Dept_Code as Dept1, A3.Short_Name as Name1, A2.Dept_Code as Dept2 , A2.Short_Name as Name2 " & vbCrLf)
            'SqlString.Append(", '' as Dept3 , '' as Name3 " & vbCrLf)
            'SqlString.Append("from PUB_Department A " & vbCrLf)
            'SqlString.Append("LEFT join PUB_Department A2 ON A.Upper_Dept_Code = A2.Dept_Code  AND A2.Dept_Level_Id = '2' AND A.Dept_Level_Id = '3' " & vbCrLf)
            'SqlString.Append("LEFT join PUB_Department A3 ON A2.Upper_Dept_Code = A3.Dept_Code  AND A3.Dept_Level_Id = '1' " & vbCrLf)
            'SqlString.Append("left join PUB_Department D on A.Dept_Code = D.Upper_Dept_Code  and D.Dept_Code <> D.Upper_Dept_Code " & vbCrLf)
            'SqlString.Append("where A.Upper_Dept_Code is not null " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select distinct  A.Dept_Code , A.Short_Name , A.Upper_Dept_Code , A.Dept_Level_Id   , isnull(D.Dept_Level_Id,'')  AS Down_Level " & vbCrLf)
            'SqlString.Append(", A4.Dept_Code as Dept1, A4.Short_Name as Name1, A3.Dept_Code as Dept2 , A3.Short_Name as Name2 " & vbCrLf)
            'SqlString.Append(", A2.Dept_Code  as Dept3 , A2.short_name  as Name3 " & vbCrLf)
            'SqlString.Append("from PUB_Department A " & vbCrLf)
            'SqlString.Append("LEFT join PUB_Department A2 ON A.Upper_Dept_Code = A2.Dept_Code  AND A2.Dept_Level_Id = '3' AND A.Dept_Level_Id = '4' " & vbCrLf)
            'SqlString.Append("LEFT join PUB_Department A3 ON A2.Upper_Dept_Code = A3.Dept_Code  AND A3.Dept_Level_Id = '2' " & vbCrLf)
            'SqlString.Append("LEFT join PUB_Department A4 ON A3.Upper_Dept_Code = A4.Dept_Code  AND A4.Dept_Level_Id = '1' " & vbCrLf)
            'SqlString.Append("left join PUB_Department D on A.Dept_Code = D.Upper_Dept_Code  and D.Dept_Code <> D.Upper_Dept_Code " & vbCrLf)
            'SqlString.Append("where A.Upper_Dept_Code is not null  ) T " & vbCrLf)
            'SqlString.Append("LEFT JOIN PUB_Employee  P ON T.Dept_Code = P.Dept_Code  AND P.Assume_End_Date > GETDATE () " & vbCrLf)
            'SqlString.Append("WHERE DEPT1 IS NOT NULL " & vbCrLf)
            'SqlString.Append("ORDER BY T.Dept1 , T.Dept2, T.DEPT3, T.DEPT_CODE, P.Employee_Code;" & vbCrLf)

            'SqlString.Append("select '' as code1, '' as  name1, Dept_Code as  code2, Short_Name  name2 " & vbCrLf)
            'SqlString.Append("from #tempdept " & vbCrLf)
            'SqlString.Append("where Dept_Level_Id = '1' " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select Dept_Code as code1, Short_Name as code2 ,  Employee_Code as code2, Employee_Name as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept " & vbCrLf)
            'SqlString.Append("where Dept_Level_Id = '1' " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select DISTINCT  B.Dept_Code as code1, B.Short_Name  as name1, A.Dept_Code  as code2, A.Short_Name  as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept  A " & vbCrLf)
            'SqlString.Append("inner join  #tempdept B ON B.Dept_Code  = A.Upper_Dept_Code " & vbCrLf)
            'SqlString.Append("where A.Dept_Level_Id   = '2' " & vbCrLf)
            'SqlString.Append("AND A.Dept_Code IN (select DISTINCT  Dept_Code from #tempdept where Dept_Level_Id = '2' and ( Down_Level <> ''  or Employee_Code is not null ) ) " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select distinct  Dept_Code as code1, Short_Name as code2 ,  Employee_Code as code2, Employee_Name as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept " & vbCrLf)
            'SqlString.Append("where Dept_Level_Id = '2' AND EMPLOYEE_CODE IS NOT NULL " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select DISTINCT  B.Dept_Code as code1, B.Short_Name  as name1, A.Dept_Code  as code2, A.Short_Name  as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept  A " & vbCrLf)
            'SqlString.Append("inner join  #tempdept B ON B.Dept_Code  = A.Upper_Dept_Code " & vbCrLf)
            'SqlString.Append("where A.Dept_Level_Id   = '3' " & vbCrLf)
            'SqlString.Append("AND A.Dept_Code IN (select distinct   Dept_Code from #tempdept where Dept_Level_Id = '3' and ( Down_Level <> ''  or Employee_Code is not null ) ) " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select  Dept_Code as code1, Short_Name as code2 ,  Employee_Code as code2, Employee_Name as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept " & vbCrLf)
            'SqlString.Append("where Dept_Level_Id = '3' AND EMPLOYEE_CODE IS NOT NULL " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select DISTINCT  B.Dept_Code as code1, B.Short_Name  as name1, A.Dept_Code  as code2, A.Short_Name  as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept  A " & vbCrLf)
            'SqlString.Append("inner join  #tempdept B ON B.Dept_Level_Id = A.Down_Level " & vbCrLf)
            'SqlString.Append("where A.Dept_Level_Id  = '4' " & vbCrLf)
            'SqlString.Append("AND A.Dept_Code IN (select distinct  Dept_Code from #tempdept where Dept_Level_Id = '4'  and ( Down_Level <> ''  or Employee_Code is not null ) ) " & vbCrLf)
            'SqlString.Append(" " & vbCrLf)
            'SqlString.Append("union " & vbCrLf)
            'SqlString.Append("select  Dept_Code as code1, Short_Name as code2 ,  Employee_Code as code2, Employee_Name as name2 " & vbCrLf)
            'SqlString.Append("from #tempdept " & vbCrLf)
            'SqlString.Append("where Dept_Level_Id = '4' AND EMPLOYEE_CODE IS NOT NULL;" & vbCrLf)

            'SqlString.Append("drop table  #tempdept")

            '調整第一層為全院，院本部歸到第二層=======================================================
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT DISTINCT  T.Dept1 , T.Name1 , T.Dept2 , T.Name2, T.Dept3, T.Name3 " & vbCrLf)
            sqlString.Append(",T.Dept_Code , T.Short_Name ,  T.Upper_Dept_Code , T.Dept_Level_Id , T.Down_Level " & vbCrLf)
            sqlString.Append(", P.Employee_Code , P.Employee_Name , P.Dept_Code  AS EMPLOYEE_DEPT " & vbCrLf)
            sqlString.Append("into #tempdept " & vbCrLf)
            sqlString.Append("  FROM " & vbCrLf)
            sqlString.Append("( " & vbCrLf)
            sqlString.Append("select distinct  '00000' as Dept_Code, '全院' as Short_Name, '00000' as  Upper_Dept_Code, '0'  as Dept_Level_Id " & vbCrLf)
            sqlString.Append(", '2'  AS Down_Level,  '00000' as Dept1, '全院'  as Name1, '' as Dept2 , '' as Name2, '' as Dept3 , '' as Name3 " & vbCrLf)
            sqlString.Append("from PUB_Department A " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("UNION " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("select distinct  A.Dept_Code , A.Short_Name ,'00000' " & vbCrLf)
            sqlString.Append(", case when A.Dept_Level_Id = '1' then '2' else  A.Dept_Level_Id end as Dept_Level_Id " & vbCrLf)
            sqlString.Append("  , case when A.Dept_Level_Id = '1' then '' else isnull(D.Dept_Level_Id,'') end  AS Down_Level " & vbCrLf)
            sqlString.Append(", case when A.Dept_Level_Id in ( '1' ,'2') then '00000' else A1.Dept_Code end  as Dept1 " & vbCrLf)
            sqlString.Append(", case when A.Dept_Level_Id in ( '1' ,'2') then '全院' else A1.Short_Name end  as Name1 " & vbCrLf)
            sqlString.Append(", '' as Dept2 , '' as Name2 " & vbCrLf)
            sqlString.Append(", '' as Dept3 , '' as Name3 " & vbCrLf)
            sqlString.Append("from PUB_Department A " & vbCrLf)
            sqlString.Append("LEFT join PUB_Department A1 ON A.Upper_Dept_Code = A1.Dept_Code " & vbCrLf)
            sqlString.Append("left join PUB_Department D on A.Dept_Code = D.Upper_Dept_Code  and D.Dept_Code <> D.Upper_Dept_Code " & vbCrLf)
            sqlString.Append("where A.Upper_Dept_Code is not null  AND A.Dept_Level_Id in ('1', '2' ) " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("union " & vbCrLf)
            sqlString.Append("select distinct  A.Dept_Code , A.Short_Name , A.Upper_Dept_Code , A.Dept_Level_Id  , isnull(D.Dept_Level_Id,'')  AS Down_Level " & vbCrLf)
            sqlString.Append(", '00000' as Dept1, '全院' as Name1, A2.Dept_Code as Dept2 , A2.Short_Name as Name2 " & vbCrLf)
            sqlString.Append(", '' as Dept3 , '' as Name3 " & vbCrLf)
            sqlString.Append("from PUB_Department A " & vbCrLf)
            sqlString.Append("LEFT join PUB_Department A2 ON A.Upper_Dept_Code = A2.Dept_Code  AND A2.Dept_Level_Id = '2' " & vbCrLf)
            sqlString.Append("--LEFT join PUB_Department A3 ON A2.Upper_Dept_Code = A3.Dept_Code  AND A3.Dept_Level_Id = '1' " & vbCrLf)
            sqlString.Append("left join PUB_Department D on A.Dept_Code = D.Upper_Dept_Code  and D.Dept_Code <> D.Upper_Dept_Code " & vbCrLf)
            sqlString.Append("where A.Upper_Dept_Code is not null AND  A.Dept_Level_Id = '3' " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("union " & vbCrLf)
            sqlString.Append("select distinct  A.Dept_Code , A.Short_Name , A.Upper_Dept_Code , A.Dept_Level_Id   , isnull(D.Dept_Level_Id,'')  AS Down_Level " & vbCrLf)
            sqlString.Append(", '00000' as Dept1, '全院' as Name1, A3.Dept_Code as Dept2 , A3.Short_Name as Name2 " & vbCrLf)
            sqlString.Append(", A2.Dept_Code  as Dept3 , A2.short_name  as Name3 " & vbCrLf)
            sqlString.Append("from PUB_Department A " & vbCrLf)
            sqlString.Append("LEFT join PUB_Department A2 ON A.Upper_Dept_Code = A2.Dept_Code  AND A2.Dept_Level_Id = '3' " & vbCrLf)
            sqlString.Append("LEFT join PUB_Department A3 ON A2.Upper_Dept_Code = A3.Dept_Code  AND A3.Dept_Level_Id = '2' " & vbCrLf)
            sqlString.Append("--LEFT join PUB_Department A4 ON A3.Upper_Dept_Code = A4.Dept_Code  AND A4.Dept_Level_Id = '1' " & vbCrLf)
            sqlString.Append("left join PUB_Department D on A.Dept_Code = D.Upper_Dept_Code  and D.Dept_Code <> D.Upper_Dept_Code " & vbCrLf)
            sqlString.Append("where A.Upper_Dept_Code is not null AND A.Dept_Level_Id = '4'  ) T " & vbCrLf)
            sqlString.Append("LEFT JOIN PUB_Employee  P ON T.Dept_Code = P.Dept_Code  AND P.Assume_End_Date > GETDATE () " & vbCrLf)
            sqlString.Append("WHERE DEPT1 IS NOT NULL " & vbCrLf)
            sqlString.Append("ORDER BY T.Dept1 , T.Dept2, T.DEPT3, T.DEPT_CODE, P.Employee_Code;")

            sqlString.Append("select '' as code1, '' as  name1, Dept_Code as  code2, Short_Name  name2 " & vbCrLf)
            sqlString.Append("from #tempdept " & vbCrLf)
            sqlString.Append("where Dept_Level_Id = '0' " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("union " & vbCrLf)
            sqlString.Append("select DISTINCT  B.Dept_Code as code1, B.Short_Name  as name1, A.Dept_Code  as code2, A.Short_Name  as name2 " & vbCrLf)
            sqlString.Append("from #tempdept  A " & vbCrLf)
            sqlString.Append("inner join  #tempdept B ON B.Dept_Code  = A.Upper_Dept_Code " & vbCrLf)
            sqlString.Append("where A.Dept_Level_Id   = '2' " & vbCrLf)
            sqlString.Append("AND A.Dept_Code IN (select DISTINCT  Dept_Code from #tempdept where Dept_Level_Id = '2' and ( Down_Level <> ''  or Employee_Code is not null ) ) " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("union " & vbCrLf)
            sqlString.Append("select distinct  Dept_Code as code1, Short_Name as code2 ,  Employee_Code as code2, Employee_Name as name2 " & vbCrLf)
            sqlString.Append("from #tempdept " & vbCrLf)
            sqlString.Append("where Dept_Level_Id = '2' AND EMPLOYEE_CODE IS NOT NULL " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("union " & vbCrLf)
            sqlString.Append("select DISTINCT  B.Dept_Code as code1, B.Short_Name  as name1, A.Dept_Code  as code2, A.Short_Name  as name2 " & vbCrLf)
            sqlString.Append("from #tempdept  A " & vbCrLf)
            sqlString.Append("inner join  #tempdept B ON B.Dept_Code  = A.Upper_Dept_Code " & vbCrLf)
            sqlString.Append("where A.Dept_Level_Id   = '3' " & vbCrLf)
            sqlString.Append("AND A.Dept_Code IN (select distinct   Dept_Code from #tempdept where Dept_Level_Id = '3' and ( Down_Level <> ''  or Employee_Code is not null ) ) " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("union " & vbCrLf)
            sqlString.Append("select  Dept_Code as code1, Short_Name as code2 ,  Employee_Code as code2, Employee_Name as name2 " & vbCrLf)
            sqlString.Append("from #tempdept " & vbCrLf)
            sqlString.Append("where Dept_Level_Id = '3' AND EMPLOYEE_CODE IS NOT NULL " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("union " & vbCrLf)
            sqlString.Append("select DISTINCT  B.Dept_Code as code1, B.Short_Name  as name1, A.Dept_Code  as code2, A.Short_Name  as name2 " & vbCrLf)
            sqlString.Append("from #tempdept  A " & vbCrLf)
            sqlString.Append("inner join  #tempdept B ON B.Dept_Level_Id = A.Down_Level " & vbCrLf)
            sqlString.Append("where A.Dept_Level_Id  = '4' " & vbCrLf)
            sqlString.Append("AND A.Dept_Code IN (select distinct  Dept_Code from #tempdept where Dept_Level_Id = '4'  and ( Down_Level <> ''  or Employee_Code is not null ) ) " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("union " & vbCrLf)
            sqlString.Append("select  Dept_Code as code1, Short_Name as code2 ,  Employee_Code as code2, Employee_Name as name2 " & vbCrLf)
            sqlString.Append("from #tempdept " & vbCrLf)
            sqlString.Append("where Dept_Level_Id = '4' AND EMPLOYEE_CODE IS NOT NULL;")

            sqlString.Append("drop table  #tempdept")

            '=========================================================================================

            command.CommandText = SqlString.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            '部門
            Dim ds1 As DataSet = queryDeoartment(conn)
            ds.Tables.Add(ds1.Tables(0).Copy)
            '群組
            Dim ds2 As DataSet = queryGroup()
            ds.Tables.Add(ds2.Tables(0).Copy)
            Return ds


        Catch sqlex As SqlException
            Throw sqlex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function
    '取得部門Tree資料
    Function queryDeoartment(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            '調整第一層為全院，院本部歸到第二層=======================================================
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("Select '00000' as code1 , '科室' as name1 , " & vbCrLf)
            sqlString.Append("RTRIM(Dept_Code) as code2 , RTRIM(Dept_Name) as name2 " & vbCrLf)
            sqlString.Append("From  PUB_Department  Where  DC<>'Y' and Is_Reg_Dept='N'")


            '=========================================================================================

            command.CommandText = sqlString.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("department")
                adapter.Fill(ds, "department")
            End Using
            ds.Tables(0).Rows.Add("", "", "00000", "科室")
            Return ds

        Catch sqlex As SqlException
            Throw sqlex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function
    '取得群組Tree
    Function queryGroup(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            '調整第一層為全院，院本部歸到第二層=======================================================
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("Select '2021' as code1 , '群組' as name1 , " & vbCrLf)
            sqlString.Append("RTRIM(Code_Id) as code2 , RTRIM(Code_Name) as name2 " & vbCrLf)
            sqlString.Append("From  PUB_Syscode  Where Type_ID='2021'")


            '=========================================================================================

            command.CommandText = sqlString.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("NfcGroup")
                adapter.Fill(ds, "NfcGroup")
            End Using
            ds.Tables(0).Rows.Add("", "", "2021", "群組")

            Return ds

        Catch sqlex As SqlException
            Throw sqlex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function

    '根據科室取得員工資料
    Public Function queryEmployeeByDept(ByVal dept As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("Select '00000' as code1 , '科室' as name1 , " & vbCrLf)
            sqlString.Append("RTRIM(Employee_Code) as code2 , RTRIM(Employee_Name) as name2 " & vbCrLf)
            sqlString.Append("From  PUB_Employee  Where dept_Code=@deptCode")


            '=========================================================================================

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@deptCode", dept)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Employee")
                adapter.Fill(ds, "PUB_Employee")
            End Using
            'ds.Tables(0).Rows.Add("", "", "00000", "員工")
            Return ds

        Catch sqlex As SqlException
            Throw sqlex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function

#End Region

#Region " 根據員工編號、日期、取得符合條件的員工資料 "

    ''' <summary>
    ''' 根據員工編號、日期、取得符合條件的員工資料
    ''' 
    ''' TypeFlag: 1.依員工號 2.依員工號和日期的有效資料
    ''' 
    ''' </summary>
    ''' <param name="EmployeeCode" >員工編號</param>
    ''' <param name="JudgeDate" >作為判斷依據的日期</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by James on 2014-09-01</remarks>
    Public Function queryEmployeeByDate(ByVal EmployeeCode As String, ByVal JudgeDate As String) As DataSet

        Dim conn = Nothing
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT PE.Employee_Code, " & vbCrLf)
            sqlString.Append("       PE.Employee_Name, " & vbCrLf)
            sqlString.Append("       PE.Employee_En_Name, " & vbCrLf)
            sqlString.Append("       PE.Idno, " & vbCrLf)
            sqlString.Append("       PE.Assume_Effect_Date, " & vbCrLf)
            sqlString.Append("       PE.Assume_End_Date, " & vbCrLf)
            sqlString.Append("       PE.Professal_Kind_Id, " & vbCrLf)
            sqlString.Append("       PE.Emp_Status_Id, " & vbCrLf)
            sqlString.Append("       PE.Dept_Code, " & vbCrLf)
            sqlString.Append("       PD.Dept_Name, " & vbCrLf)
            sqlString.Append("       PE.Acc_Dept, " & vbCrLf)
            sqlString.Append("       PE.Email, " & vbCrLf)
            sqlString.Append("       PE.Nrs_Level_Id " & vbCrLf)
            sqlString.Append("FROM   PUB_Employee AS PE " & vbCrLf)
            sqlString.Append("       INNER JOIN PUB_Department AS PD " & vbCrLf)
            sqlString.Append("         ON PE.Dept_Code = PD.Dept_Code " & vbCrLf)
            sqlString.Append("WHERE  PE.Employee_Code = @Employee_Code ")

            Select Case JudgeDate

                Case ""
                    '1.依員工號，不動作 

                Case Else
                    '2.依員工號和日期的有效資料，增加有效日期判斷
                    sqlString.Append("       AND @JudgeDate BETWEEN PE.Assume_Effect_Date AND PE.Assume_End_Date ")

            End Select


            command.CommandText = sqlString.ToString

            command.Parameters.AddWithValue("@Employee_Code", EmployeeCode)


            Select Case JudgeDate

                Case ""
                    '1.依員工號，不動作 

                Case Else
                    '2.依員工號和日期的有效資料，增加有效日期參數
                    command.Parameters.AddWithValue("@JudgeDate", CDate(JudgeDate).ToString("yyyy-MM-dd"))

            End Select


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw sqlex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function

#End Region

    ''' <summary>
    ''' 程式說明：取得所有員工
    ''' 開發人員：Jen
    ''' 開發日期：2009.07.31
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Employee
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/07/31, XXX
    ''' </修改註記>
    Public Function queryAllEmployeeForComboBox() As DataTable
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select Employee_Code, Employee_Name, Employee_En_Name ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from " & tableName & " ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where Assume_End_Date >= @SystemDate ")

        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("Order By Employee_Code ")
        '----------------------------------------------------------------------------
        Try
            Dim dt As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@SystemDate", Now)

                    End With

                    conn.Open()

                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dt)
                    End Using

                End Using
            End Using

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：取得員工姓名
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.22
    ''' </summary>
    ''' <param name="empCode">員工編號</param>
    ''' <returns>Employee_Name</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.Nick-PUB_Employee
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/07/22, XXX
    ''' </修改註記>
    Public Function getEmpName(ByVal empCode As String) As String
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select")
        cmdStr.AppendLine("Employee_Name")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from PUB_Employee")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where 1=1")
        cmdStr.AppendLine("and Employee_Code = @Employee_Code")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@Employee_Code", empCode)

                    End With

                    conn.Open()

                    Return sqlCmd.ExecuteScalar

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "2009/08/11, Add By 谷官, ComboBox的Data Source"

    ''' <summary>
    ''' 程式說明：取得看診醫師ComboBox的Data Source
    ''' 開發人員：谷官
    ''' 開發日期：2009.08.11
    ''' </summary>
    ''' <param name="professalKindFlag">
    ''' 職務類別
    ''' 
    ''' "*"：全部員工
    ''' "0"：主治醫師
    ''' "1"：住院醫師
    ''' "2"：藥師
    ''' "0,1..."：組合條件(ex：主治醫師+住院醫師...)
    ''' </param>
    ''' <returns>Employee_Code, Employee_Name</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.Nick-PUB_Employee
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/20, 修改Professal_Kind_Id欄位資料異動
    ''' </修改註記>
    Public Function getComboBoxValueTable(ByVal professalKindFlag As String, Optional ByRef conn As IDbConnection = Nothing) As DataTable
        '1.2009/11/20, 修改Professal_Kind_Id欄位資料異動
        '----------------------------------------------------------------------------
        '設定職務類別：MIS所維護的Code 2010-主治醫師;2004-住院醫師;2046-護士2047-藥師...
        '----------------------------------------------------------------------------
        Dim professalKindIdArray As String() = {"2010", "2004", "2047"}
        Dim professalKindId As String = ""

        If professalKindFlag.Length > 0 Then
            If professalKindFlag.Equals("*") Then
                professalKindId = ""
            Else
                Dim flag As String() = professalKindFlag.Split(New Char() {","})

                For iIndex As Integer = 0 To flag.Length - 1
                    If professalKindId.Length > 0 Then
                        professalKindId += ","
                    End If
                    professalKindId += "'" & professalKindIdArray(Val(flag(iIndex))) & "'"
                Next
            End If
        Else
            professalKindId = "'2010','2004','2047'"
        End If
        '----------------------------------------------------------------------------
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select")
        cmdStr.AppendLine("rtrim(PE.Employee_Code) as Employee_Code,")
        cmdStr.AppendLine("rtrim(PE.Employee_Name) as Employee_Name,")
        cmdStr.AppendLine("rtrim(PE.Employee_En_Name) as Employee_En_Name,")
        cmdStr.AppendLine("rtrim(PE.Idno) as Idno,")
        cmdStr.AppendLine("rtrim(PD.Doctor_Code) as Doctor_Code")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from PUB_Employee as PE")
        cmdStr.AppendLine("left join PUB_Doctor as PD on PD.Employee_Code = PE.Employee_Code")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where 1=1")
        If professalKindId.Length > 0 Then
            cmdStr.AppendLine("and PE.Professal_Kind_Id in (" & professalKindId & ")")
        End If
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("Order by PE.Employee_Code")
        '----------------------------------------------------------------------------
        Try
            Dim tableName As String() = {"doctorDT"}
            Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select1", tableName, conn)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
