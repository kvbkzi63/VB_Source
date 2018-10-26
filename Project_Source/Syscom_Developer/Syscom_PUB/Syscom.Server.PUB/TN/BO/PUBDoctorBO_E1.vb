'/*
'*****************************************************************************
'*
'*    Page/Class Name:  醫師基本檔
'*              Title:	PUBDOCTORBO_E1
'*        Description:	醫師基本檔
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2013-09-25
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2013-09-25
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Server.CMM
Imports System.Text

Public Class PUBDOCTORBO_E1
    Inherits PubDoctorBO

#Region "     變數宣告 "

    '宣告Log
    Dim log As LOGDelegate = LOGDelegate.getInstance
    Private Shared instance As PUBDOCTORBO_E1
#End Region

    Public Overloads Shared Function getInstance() As PUBDOCTORBO_E1
        instance = New PUBDOCTORBO_E1
        Return instance

    End Function

#Region "     新增 Method "

#End Region

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "

#Region " 查詢醫師檔作為CBO 資料 "

    ''' <summary>
    ''' 查詢醫師檔作為CBO 資料
    ''' </summary>
    ''' <param name="SectionCode" >院區代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2013-09-25</remarks>
    Public Function queryForCbo(ByVal SectionCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

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
            sqlString.Append("SELECT [DOCTOR_CODE]                                        AS Code_ID, " & vbCrLf)
            sqlString.Append("       [DOCTOR_NAME]                                        AS Code_Name, " & vbCrLf)
            sqlString.Append("       [DOCTOR_EN_NAME]                                     AS Code_EN_Name, " & vbCrLf)
            sqlString.Append("       Rtrim([DOCTOR_CODE]) + '-' + Rtrim([DOCTOR_NAME])    AS Combine_Name, " & vbCrLf)
            sqlString.Append("       Rtrim([DOCTOR_CODE]) + '-' + Rtrim([DOCTOR_EN_NAME]) AS Combine_Name, " & vbCrLf)
            sqlString.Append("       [CREATE_USER], " & vbCrLf)
            sqlString.Append("       [CREATE_TIME], " & vbCrLf)
            sqlString.Append("       [MODIFIED_USER], " & vbCrLf)
            sqlString.Append("       [MODIFIED_TIME], " & vbCrLf)
            sqlString.Append("       [SECTION_CODE] " & vbCrLf)
            sqlString.Append("FROM   [PUB_DOCTOR] " & vbCrLf)
            sqlString.Append("WHERE  SECTION_CODE = @SECTION_CODE ")


            command.CommandText = sqlString.ToString

            command.Parameters.AddWithValue("@SECTION_CODE", SectionCode)

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

            Throw New CommonException("CMMCMMD001", ex)

        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

    ''' <summary>
    ''' 進行醫師驗證
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function queryDoctorFromEmployee(ByVal Employee_Code As String, ByVal Doctor_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
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
            sqlString.Append(" SELECT a.Employee_Code, " & vbCrLf)
            sqlString.Append("       a.Employee_Name, C.License_Dept_Code As Dept_Code " & vbCrLf)
            sqlString.Append(" FROM   PUB_Employee a " & vbCrLf)
            'sqlString.Append("       INNER JOIN PUB_Doctor b " & vbCrLf)
            'sqlString.Append("         ON a.Employee_Code = b.Employee_Code " & vbCrLf)
            sqlString.Append("       INNER JOIN PMS_Emp_License C " & vbCrLf)
            sqlString.Append("         ON a.Employee_Code = C.Employee_Code " & vbCrLf)
            sqlString.Append(" WHERE  1 = 1 " & vbCrLf)
            If Employee_Code <> "" Then
                sqlString.Append("       AND a.Employee_Code = @Employee_Code " & vbCrLf)
            End If
            If Doctor_Code <> "" Then
                'sqlString.Append("       AND b.Doctor_Code = @Doctor_Code " & vbCrLf)
                sqlString.Append("       AND C.Employee_Code = @Doctor_Code " & vbCrLf)
            End If

            'sqlString.Append("       AND b.Announce_Effect_Date<='" & Now.ToShortDateString & "' " & vbCrLf)
            'sqlString.Append("       AND b.Announce_End_Date >='" & Now.ToShortDateString & "' " & vbCrLf)

            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Employee_Code", Employee_Code)
            command.Parameters.AddWithValue("@Doctor_Code", Doctor_Code)
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
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

    ''' <summary>
    ''' getEmployeeCodeByDoctorCode
    ''' </summary>
    ''' <param name="DoctorCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks>從舊系統搬過來的</remarks>
    Public Function getEmployeeCodeByDoctorCode(ByVal DoctorCode As String, Optional ByVal conn As SqlConnection = Nothing) As DataSet
        Dim sqlString As New System.Text.StringBuilder
        sqlString.Append("SELECT Rtrim(A.Doctor_Code)   AS Doctor_Code, " & vbCrLf)
        sqlString.Append("       Rtrim(B.Employee_Code) AS Employee_Code, " & vbCrLf)
        sqlString.Append("       Rtrim(B.Employee_Name) AS Employee_Name, " & vbCrLf)
        sqlString.Append("       B.Assume_Effect_Date, " & vbCrLf)
        sqlString.Append("       B.Assume_End_Date " & vbCrLf)
        sqlString.Append("FROM   PUB_Doctor A " & vbCrLf)
        sqlString.Append("       INNER JOIN PUB_Employee B " & vbCrLf)
        sqlString.Append("         ON A.Employee_Code = B.Employee_Code " & vbCrLf)
        sqlString.Append("WHERE  A.Doctor_Code = @Doctor_Code ")
        sqlString.Append("       AND GETDATE() BETWEEN Isnull(B.Assume_Effect_Date, '1900/01/01') AND Isnull(B.Assume_End_Date, '2999/01/01') ")

        Dim _ds As New DataSet

        If conn Is Nothing Then
            conn = getConnection()
        End If

        Try
            Using _sqlConnection As SqlConnection = conn

                Dim _command As New SqlCommand(sqlString.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Doctor_Code", DoctorCode)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' Combobox所有醫師
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>從舊系統搬過來的</remarks>
    Public Function queryComboboxAllDoctor(Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim cmdStr As New StringBuilder

        Try
            'SQL
            cmdStr.AppendLine("select")
            cmdStr.AppendLine("rtrim(A.Doctor_Code) as Doctor_Code,")
            cmdStr.AppendLine("rtrim(B.Employee_Name) as Employee_Name,")
            cmdStr.AppendLine("rtrim(A.Employee_Code) as Employee_Code")
            cmdStr.AppendLine("from PUB_Doctor as A")
            cmdStr.AppendLine("inner join PUB_Employee B on A.Employee_Code = B.Employee_Code")
            cmdStr.AppendLine("where 1=1")
            cmdStr.AppendLine("Order By A.Doctor_Code")

            '執行SQL
            Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select2", Nothing, conn)

            'Dim ds As DataSet
            'Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            'Dim command As SqlCommand = sqlConn.CreateCommand()
            'command.CommandText = _
            '" Select rtrim(A.Doctor_Code) as Doctor_Code, rtrim(B.Employee_Name) as Employee_Name, rtrim(A.Employee_Code) as Employee_Code" & _
            '" From PUB_Doctor A " & _
            '" 	inner join PUB_Employee B on A.Employee_Code = B.Employee_Code " & _
            '" Order By A.Doctor_Code "
            'Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
            '    ds = New DataSet(tableName)
            '    adapter.Fill(ds, tableName)
            '    adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            'End Using
            'Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 依傳入醫師代碼取得有效醫師相關資料 註:醫師是否有效以Announce_Effect_Date與Announce_End_Date判斷
    ''' </summary>
    ''' <param name="DoctorCode"></param>
    ''' <returns></returns>
    ''' <remarks>從舊系統搬過來的</remarks>
    Public Overloads Function queryPUBDoctor(ByVal DoctorCode As String) As System.Data.DataSet 'Implements IPUBDoctorBO.queryPUBDoctor
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            If DoctorCode.Trim.Contains("@") Then

                DoctorCode = DoctorCode.Trim.Replace("@", "")

                command.CommandText = " Select RTRIM(A.Doctor_Code) as '醫師代碼', RTRIM(B.Employee_Name) as '醫師姓名'," & _
                        "       RTRIM(C.Dept_Name) as '所屬科別', RTRIM(A.Employee_Code) as '員工編號', RTRIM(A.Level_Id) as '職級' , " & _
                        "       RTRIM(B.Idno) as '身分證號' , RTRIM(B.Employee_En_Name) as '醫師英文姓名' " & _
                        " From  PUB_Doctor A Left Join PUB_Department C  On A.Dept_Code = C.Dept_Code And C.DC <>'Y'  ,PUB_Employee B " & _
                        " Where A.Employee_Code='" & DoctorCode & "' And " & _
                        "      A.Announce_Effect_Date <= '" & Now().ToString("yyyy/M/d") & "' And " & _
                        "      A.Announce_End_Date >= '" & Now().ToString("yyyy/M/d") & "' And " & _
                        "      B.Employee_Code = A.Employee_Code And '" & Now().ToString("yyyy/M/d") & "' >= B.Assume_Effect_Date And '" & Now().ToString("yyyy/M/d") & "'<= B.Assume_End_Date    " & _
                        " Order By A.Doctor_Code "

            ElseIf DoctorCode.Trim.Contains("||") Then

                DoctorCode = DoctorCode.Trim.Replace("QueryDrIdno", "")

                Dim Opd_Visit_Date As Date = Now
                Dim Employee_Code As String = Split(DoctorCode.Trim, "||")(0).Trim
                If IsDate(Split(DoctorCode.Trim, "||")(1).Trim) Then
                    Opd_Visit_Date = CDate(Split(DoctorCode.Trim, "||")(1).Trim)
                End If

                command.CommandText = " Select RTRIM(A.Doctor_Code) as '醫師代碼', RTRIM(B.Employee_Name) as '醫師姓名'," & _
                        "       RTRIM(C.Dept_Name) as '所屬科別', RTRIM(A.Employee_Code) as '員工編號', RTRIM(A.Level_Id) as '職級' , " & _
                        "       RTRIM(B.Idno) as '身分證號' , RTRIM(B.Employee_En_Name) as '醫師英文姓名' " & _
                        " From  PUB_Doctor A,PUB_Employee B,PUB_Department C " & _
                        " Where A.Employee_Code='" & Employee_Code & "' And " & _
                        "      A.Announce_Effect_Date <= '" & Opd_Visit_Date.ToString("yyyy/M/d") & "' And " & _
                        "      A.Announce_End_Date >= '" & Opd_Visit_Date.ToString("yyyy/M/d") & "' And " & _
                        "      B.Employee_Code = A.Employee_Code And '" & Opd_Visit_Date.ToString("yyyy/M/d") & "' >= B.Assume_Effect_Date And '" & Opd_Visit_Date.ToString("yyyy/M/d") & "'<= B.Assume_End_Date  And " & _
                        "      C.Dept_Code = A.Dept_Code And " & _
                        "      C.DC <>'Y' " & _
                        " Order By A.Doctor_Code "

            Else
                command.CommandText = "   Select A.Employee_Code, A.Doctor_Code, A.Level_Id, A.Dept_Code, B.Dept_Name  ,Announce_Effect_Date,  A.Announce_End_Date," & _
                               "           A.License_No, A.License_Effect_Date, A.License_End_Date " & _
                                  " From  PUB_Doctor A , PUB_Department B " & _
                                  " Where A.Dept_Code=B.Dept_Code And A.Announce_Effect_Date<= '" & Now.ToShortDateString & "' And A.Announce_End_Date >= '" & Now.ToShortDateString & "' And A.Doctor_Code='" & DoctorCode & "' " & _
                                  " Order By A.Doctor_Code"

            End If


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    '依傳入員工代碼取得有效醫師相關資料 註:醫師是否有效以Announce_Effect_Date與Announce_End_Date判斷
    Public Overloads Function queryPUBDoctorByKey(ByVal EmployeeCode As String) As System.Data.DataSet 'Implements IPUBDoctorBO.queryPUBDoctor
        Try
            Dim strSQL As String
            Dim Opd_Visit_Date As String
            Dim Employee_Code As String

            strSQL = " SELECT RTRIM(A.Doctor_Code) AS '醫師代碼', RTRIM(B.Employee_Name) AS '醫師姓名'" & _
                           ", RTRIM(C.Dept_Name) AS '所屬科別', RTRIM(A.Employee_Code) AS '員工編號', RTRIM(A.Level_Id) AS '職級'" & _
                           ", RTRIM(B.Idno) AS '身分證號', RTRIM(B.Employee_En_Name) AS '醫師英文姓名'" & _
                       " FROM PUB_Doctor A WITH(NOLOCK)" & _
                      "  Left JOIN PUB_Employee B WITH(NOLOCK) ON B.Employee_Code = A.Employee_Code" & _
                                                            " AND @Opd_Visit_Date >= B.Assume_Effect_Date" & _
                                                            " AND @Opd_Visit_Date <= B.Assume_End_Date" & _
                      "  Left JOIN PUB_Department C WITH(NOLOCK) ON C.Dept_Code = A.Dept_Code" & _
                                                              " AND C.Dc = 'N'" & _
                      " WHERE A.Employee_Code = @Employee_Code" & _
                        " AND A.Announce_Effect_Date <= @Opd_Visit_Date" & _
                        " AND A.Announce_End_Date >= @Opd_Visit_Date" & _
                      " ORDER BY A.Doctor_Code"

            If EmployeeCode.Trim.Contains("@") Then

                Employee_Code = EmployeeCode.Trim.Replace("@", "")
                Opd_Visit_Date = Now().ToString("yyyy/M/d")

            ElseIf EmployeeCode.Trim.Contains("||") Then

                EmployeeCode = EmployeeCode.Trim.Replace("QueryDrIdno", "")
                Employee_Code = Split(EmployeeCode.Trim, "||")(0).Trim

                Dim OpdVisitDate As Date = Now

                If IsDate(Split(EmployeeCode.Trim, "||")(1).Trim) Then
                    OpdVisitDate = CDate(Split(EmployeeCode.Trim, "||")(1).Trim)
                End If

                Opd_Visit_Date = OpdVisitDate.ToString("yyyy/M/d")

            Else
                Opd_Visit_Date = Now().ToShortDateString
                Employee_Code = EmployeeCode

                strSQL = " SELECT A.Employee_Code, A.Doctor_Code, A.Level_Id, A.Dept_Code, B.Dept_Name, A.Announce_Effect_Date, A.Announce_End_Date" & _
                               " " & _
                           " FROM PUB_Doctor A WITH(NOLOCK)" & _
                          " Left JOIN PUB_Department B WITH(NOLOCK) ON A.Dept_Code=B.Dept_Code" & _
                          " WHERE A.Employee_Code = @Employee_Code" & _
                            " AND A.Announce_Effect_Date <= @Opd_Visit_Date" & _
                            " AND A.Announce_End_Date >= @Opd_Visit_Date" & _
                          " ORDER BY A.Doctor_Code"
            End If

            Using sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
                Using command As SqlCommand = sqlConn.CreateCommand()
                    command.CommandText = strSQL
                    command.Parameters.AddWithValue("@Opd_Visit_Date", Opd_Visit_Date)
                    command.Parameters.AddWithValue("@Employee_Code", Employee_Code)

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        Using ds As DataSet = New DataSet(tableName)
                            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            adapter.Fill(ds, tableName)

                            Return ds
                        End Using
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：依員工碼查醫師資料(for 規則編輯器)
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="employeeCodes">員工碼</param>
    ''' <returns>DataTable</returns>
    Public Function queryRuleDoctorByEmployeeCodes(ByVal employeeCodes() As String) As DataTable
        Dim systemDate As Date = DateUtil.getSystemDate
        If employeeCodes IsNot Nothing AndAlso employeeCodes.Length > 0 Then

            Dim empStr As New StringBuilder
            For i As Integer = 0 To (employeeCodes.Length - 1)
                empStr.Append("'").Append(employeeCodes(i)).Append("',")
            Next
            If empStr.Length > 0 Then
                empStr.Remove(empStr.Length - 1, 1)

                Dim cmdStr As New StringBuilder
                '----------------------------------------------------------------------------
                'Select SQL
                '----------------------------------------------------------------------------
                cmdStr.AppendLine("select d.Doctor_Code, e.Employee_Name, d.Dept_Code, dept.Dept_Name, d.Employee_Code  ")
                '----------------------------------------------------------------------------
                'From&Join SQL
                '----------------------------------------------------------------------------
                cmdStr.Append("from ").Append(tableName).AppendLine(" d ")
                cmdStr.Append("left join PUB_Employee e on d.Employee_Code = e.Employee_Code ")
                cmdStr.Append("left join PUB_Department dept on d.Dept_Code = dept.Dept_Code and dept.Effect_Date <= '").Append(systemDate.ToString("yyyy/MM/dd")).Append("' ")

                cmdStr.Append("and (dept.End_Date >= '").Append(systemDate.ToString("yyyy/MM/dd")).Append("' or dept.End_Date is null) ")
                '----------------------------------------------------------------------------
                'Where SQL
                '----------------------------------------------------------------------------
                cmdStr.Append("where d.Employee_Code in ( ").Append(empStr.ToString).Append(" ) ")

                Try
                    Dim dt As DataTable = New DataTable(tableName)

                    Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                        Using sqlCmd As SqlCommand = New SqlCommand
                            With sqlCmd
                                .CommandText = cmdStr.ToString
                                .CommandType = CommandType.Text
                                .Connection = conn

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
            Else
                Return Nothing
            End If

        Else
            '無輸入資料
            Return Nothing
        End If

    End Function

    Public Function QueryByDoctorCode(ByVal DoctorCode As String, Optional ByVal conn As SqlConnection = Nothing) As DataSet
        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(A.Doctor_Code)   AS Doctor_Code, " & vbCrLf)
        var1.Append("       RTRIM(B.Employee_Code) AS Employee_Code, " & vbCrLf)
        var1.Append("       RTRIM(B.Employee_Name) AS Employee_Name " & vbCrLf)
        var1.Append("FROM   PUB_Doctor A " & vbCrLf)
        var1.Append("       INNER JOIN PUB_Employee B " & vbCrLf)
        var1.Append("         ON A.Employee_Code = B.Employee_Code " & vbCrLf)
        var1.Append("WHERE  A.Doctor_Code = @Doctor_Code ")
        var1.Append("       AND @Now BETWEEN A.Announce_Effect_Date AND A.Announce_End_Date  " & vbCrLf)

        Dim _ds As New DataSet

        If conn Is Nothing Then
            conn = getConnection()
        End If

        Try
            Using _sqlConnection As SqlConnection = conn

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Doctor_Code", DoctorCode)
                _command.Parameters.AddWithValue("@Now", Now.Date)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function
End Class

