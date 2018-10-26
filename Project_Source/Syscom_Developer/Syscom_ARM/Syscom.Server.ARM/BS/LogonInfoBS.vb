Imports System.Configuration
Imports Syscom.Comm.LOG
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports System.Data.SqlClient
Imports Syscom.Server.PUB
Imports System.Transactions

Public Class LogonInfoBS
    Dim armCconn As SqlConnection = Nothing
    Private Function getArmConnection() As IDbConnection
        Try
            If armCconn Is Nothing Then
                armCconn = SQLConnFactory.getInstance.getArmDBSqlConn
            End If
            Return armCconn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function insertLogonDate(ByVal ip As String, ByVal employeeCode As String) As Int32
        Dim conn As System.Data.IDbConnection = Nothing
        Dim inDate As String = Now.ToString("yyyy-MM-dd")
        Dim inTime As String = Now.ToString("HH:mm:ss")
        Dim sql As String = "insert into arm_logon_info(IP,Employee_Code,In_Date,In_Time,Out_Date,Out_Time,Status) " _
        & " values('" & ip & "','" & employeeCode & "','" & inDate & "','" & inTime & "','','','')"
        Try
            conn = getArmConnection()
            conn.Open()
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sql
                    .CommandType = CommandType.Text
                    .Connection = CType(getArmConnection(), SqlConnection)
                    .ExecuteNonQuery()
                End With
            End Using
            getArmConnection.Close()
            Return 999
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
        Return Nothing
    End Function
    Public Function updateLogoutDate(ByVal ip As String, ByVal employeeCode As String) As Int32
        Dim conn As System.Data.IDbConnection = Nothing
        Dim outDate As String = Now.ToString("yyyy-MM-dd")
        Dim outTime As String = Now.ToString("HH:mm:ss")
        Dim sql As String = "update arm_logon_info " _
        & " set Out_Date='" & outDate & "'" _
        & ",Out_Time='" & outTime & "' " _
        & " where IP='" & ip & "' " _
        & " and Employee_Code='" & employeeCode & "' " _
        & " and In_Date='" & outDate & "'" _
        & " and Out_Date=''"
        Try
            conn = getArmConnection()
            conn.Open()
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sql
                    .CommandType = CommandType.Text
                    .Connection = CType(getArmConnection(), SqlConnection)
                    .ExecuteNonQuery()
                End With
            End Using
            getArmConnection.Close()
            Return 0
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
        Return Nothing
    End Function
    Public Function queryIP() As DataSet
        Dim conn As System.Data.IDbConnection = Nothing
        Dim inDate As String = Now.ToString("yyyy-MM-dd")
        Dim inTime As String = Now.ToString("HH:mm:ss")
        Dim cmd As New SqlCommand()
        Dim ds As DataSet = Nothing
        Dim sql As String = "select IP from arm_Logon_Info" _
        & " where In_Date='" & inDate & "'" _
        & " and Out_date=''"
        conn = getArmConnection()
        cmd.CommandText = sql
        cmd.Connection = conn
        Try
            Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
                ds = New DataSet("IPTable")
                adapter.Fill(ds, "IPTable")
                adapter.FillSchema(ds, SchemaType.Mapped, "IPTable")
            End Using
            getArmConnection.Close()
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
        Return Nothing
    End Function

    Public Function insertLogonDateBySystem(ByVal systemNo As String, ByVal loginDate As String, ByVal ip As String, ByVal employeeCode As String, ByVal agentCode As String, ByVal machineName As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("INSERT INTO ARM_Logon_Info " & vbCrLf)
            sqlString.Append("            (App_System_No, " & vbCrLf)
            sqlString.Append("             Machine_Name, " & vbCrLf)
            sqlString.Append("             IP_Address, " & vbCrLf)
            sqlString.Append("             Employee_Code, " & vbCrLf)
            sqlString.Append("             Agent_Employee_Code, " & vbCrLf)
            sqlString.Append("             Login_Date, " & vbCrLf)
            sqlString.Append("             Logout_Date) " & vbCrLf)
            sqlString.Append("VALUES      (@App_System_No, " & vbCrLf)
            sqlString.Append("             @Machine_Name, " & vbCrLf)
            sqlString.Append("             @IP_Address, " & vbCrLf)
            sqlString.Append("             @Employee_Code, " & vbCrLf)
            sqlString.Append("             @Agent_Employee_Code, " & vbCrLf)
            sqlString.Append("             @Login_Date, " & vbCrLf)
            sqlString.Append("             @Logout_Date) ")

            If connFlag Then
                conn = getArmConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@App_System_No", systemNo)
                command.Parameters.AddWithValue("@Machine_Name", machineName)
                command.Parameters.AddWithValue("@IP_Address", ip)
                command.Parameters.AddWithValue("@Employee_Code", employeeCode)
                command.Parameters.AddWithValue("@Agent_Employee_Code", agentCode)
                command.Parameters.AddWithValue("@Login_Date", loginDate)
                command.Parameters.AddWithValue("@Logout_Date", DBNull.Value)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    Public Function updateLogoutDateBySystem(ByVal systemNo As String, ByVal loginDate As String, ByVal ip As String, ByVal employeeCode As String, ByVal agentCode As String, ByVal machineName As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("UPDATE ARM_Logon_Info " & vbCrLf)
            sqlString.Append("SET    Logout_Date = @Logout_Date " & vbCrLf)
            sqlString.Append("WHERE  App_System_No = @App_System_No " & vbCrLf)
            sqlString.Append("       AND Machine_Name = @Machine_Name " & vbCrLf)
            sqlString.Append("       AND IP_Address = @IP_Address " & vbCrLf)
            sqlString.Append("       AND Employee_Code = @Employee_Code " & vbCrLf)
            sqlString.Append("       AND Agent_Employee_Code = @Agent_Employee_Code " & vbCrLf)
            sqlString.Append("       AND Login_Date = @Login_Date ")

            If connFlag Then
                conn = getArmConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@App_System_No", systemNo)
                command.Parameters.AddWithValue("@Machine_Name", machineName)
                command.Parameters.AddWithValue("@IP_Address", ip)
                command.Parameters.AddWithValue("@Employee_Code", employeeCode)
                command.Parameters.AddWithValue("@Agent_Employee_Code", agentCode)
                command.Parameters.AddWithValue("@Login_Date", loginDate)
                command.Parameters.AddWithValue("@Logout_Date", Now.ToString("yyyy/MM/dd HH:mm:ss.fff"))
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    Public Function queryIPBySystem(ByVal systemNo As String) As DataSet
        Dim conn As System.Data.IDbConnection = Nothing
        Dim inDate As String = Now.ToString("yyyy-MM-dd")
        Dim inTime As String = Now.ToString("HH:mm:ss")
        Dim cmd As New SqlCommand()
        Dim ds As DataSet = Nothing
        Dim sql As String = "select IP from arm_Logon_Info" _
        & " where System_No='" & systemNo & "' " _
        & " and In_Date='" & inDate & "'" _
        & " and Out_date=''"
        conn = getArmConnection()
        cmd.CommandText = sql
        cmd.Connection = conn
        Try
            Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
                ds = New DataSet("IPTable")
                adapter.Fill(ds, "IPTable")
                adapter.FillSchema(ds, SchemaType.Mapped, "IPTable")
            End Using
            getArmConnection.Close()
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
        Return Nothing
    End Function
    Public Function queryEmployeeRoleData(ByVal role As String, ByVal employeeCode As String) As DataSet

        Dim pvtAppInfoDS, pvtEmployeeDS As New DataSet

        Try

            Dim instance As LoginModuleBO = New LoginModuleBO
            pvtAppInfoDS.Tables.Add(instance.LoginForSys(role))

            Dim callEmployeeBO As PUBEmployeeBO_E1 = PUBEmployeeBO_E1.getInstance

            '2014-09-01 Sean 統一取得Employee Method
            ' pvtEmployeeDS = callEmployeeBO.queryEmployeeData(employeeCode)
            pvtEmployeeDS = callEmployeeBO.queryEmployeeByEmpCodeAndDate(employeeCode, Now.Date)

            Using ds As DataSet = New DataSet
                ds.Merge(pvtAppInfoDS)
                ds.Merge(pvtEmployeeDS)
                Return ds
            End Using

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If (pvtAppInfoDS IsNot Nothing) Then pvtAppInfoDS.Dispose()
            If (pvtEmployeeDS IsNot Nothing) Then pvtEmployeeDS.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function GetPassword(ByVal user As String) As String
        Dim conn As System.Data.IDbConnection = Nothing
        Dim cmd As New SqlCommand()
        Dim ds As DataSet = Nothing
        Dim sql As String = "SELECT   Password FROM ARM_Password  where Employee_Code='" & user & "'"
        cmd.CommandText = sql
        conn = getArmConnection()
        cmd.Connection = conn
        Try
            Using adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
                ds = New DataSet("IPTable")
                adapter.Fill(ds, "IPTable")
                adapter.FillSchema(ds, SchemaType.Mapped, "IPTable")
            End Using
            getArmConnection.Close()
            If ds.Tables(0).Rows.Count > 0 Then
                Dim pwd As String = ds.Tables(0).Rows(0).Item("Password").ToString.Trim
                Return Syscom.Comm.Utility.PassWordUtil.Decrypt(pwd, "abcdefgh")
            End If
            Return ""
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' 進行登入失敗判斷紀錄
    ''' </summary>
    ''' <param name="employeeCode"></param>
    ''' <param name="ip"></param>
    ''' <param name="machineName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function saveLogonFailure(ByVal employeeCode As String, ByVal ip As String, ByVal machineName As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim instance As ArmLogonFailureBO_E1 = ArmLogonFailureBO_E1.getInstance
            Using trans As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope

                If connFlag Then
                    conn = instance.getConnection
                    conn.Open()
                End If

                'Step.1.先取得最近資料
                Dim dsQuery As DataSet = instance.queryByEmployeeCode(employeeCode, conn)
                If dsQuery.Tables(0).Rows.Count = 0 Then

                    'Step.2.若為第一次輸入錯誤
                    Dim newRow As DataRow = dsQuery.Tables(0).NewRow
                    newRow("Employee_Code") = employeeCode
                    newRow("Login_Try_Date") = Now
                    newRow("Login_Try_Times") = "1"
                    newRow("Machine_Name") = machineName
                    newRow("IP_Address") = ip
                    dsQuery.Tables(0).Rows.Add(newRow)
                    count = instance.insert(dsQuery, conn)
                Else
                    'Step.3.若已有資料則判斷是否超過 30 分鐘
                    Dim Recent_Try_Date As Date = CDate(dsQuery.Tables(0).Rows(0).Item("Login_Try_Date"))
                    If Recent_Try_Date.AddMinutes(30) < Now Then

                        'Step.4.若超過 30 分鐘，直接新增新的一筆紀錄
                        With dsQuery.Tables(0).Rows(0)
                            .Item("Login_Try_Date") = Now
                            .Item("Login_Try_Times") = "1"
                            .Item("Machine_Name") = machineName
                            .Item("IP_Address") = ip
                        End With
                        count = instance.insert(dsQuery, conn)
                    Else
                        'Step.5.若小於等於 30 分鐘，再判斷是否嘗試次數超過 3 次
                        With dsQuery.Tables(0).Rows(0)
                            If CInt(.Item("Login_Try_Times")) < 4 Then
                                '尚未達到需處理等級，次數 + 1
                                .Item("Login_Try_Times") = CInt(.Item("Login_Try_Times")) + 1
                                .Item("Machine_Name") = machineName
                                .Item("IP_Address") = ip
                                count = instance.update(dsQuery, conn)
                            End If
                        End With
                    End If
                End If

                trans.Complete()
            End Using
            Return count
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

End Class
