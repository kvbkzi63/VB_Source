Imports Syscom.Server.SQL
Imports System.Data.SqlClient
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM

Public Class PCSIpConfigBO_E1

    Dim log As LOGDelegate = LOGDelegate.getInstance

    ''' <summary>
    ''' 輸入註解
    ''' </summary>
    ''' <param name="ip"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryStationByIP(ByVal ip As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim tableName As String = "PUB_Ip_Config"
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet = New DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("SELECT IP, " & vbCrLf)
            sqlStr.Append("       IP_Name, " & vbCrLf)
            sqlStr.Append("       Station_No, " & vbCrLf)
            sqlStr.Append("       Is_Default " & vbCrLf)
            sqlStr.Append("FROM   PUB_Ip_Config " & vbCrLf)
            sqlStr.Append("WHERE  IP = '" & ip & "' ")

            command.CommandText = sqlStr.ToString
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

    ''' <summary>
    '''取得Term_Code設定資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function queryStationByTermCode(ByVal inTermCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim tableName As String = "PUB_Terminal_Config1"
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet = New DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("SELECT Term_Code, " & vbCrLf)
            sqlStr.Append("       Term_Name, " & vbCrLf)
            sqlStr.Append("       Station_No, " & vbCrLf)
            sqlStr.Append("       Consumpation_Unit, " & vbCrLf)
            sqlStr.Append("       Print_Cond, " & vbCrLf)
            sqlStr.Append("       Create_User, " & vbCrLf)
            sqlStr.Append("       Create_Time, " & vbCrLf)
            sqlStr.Append("       Modified_User, " & vbCrLf)
            sqlStr.Append("       Modified_Time " & vbCrLf)
            sqlStr.Append("FROM   PUB_Terminal_Config " & vbCrLf)
            sqlStr.Append("WHERE  Term_Code = '" & inTermCode & "' ")

            command.CommandText = sqlStr.ToString
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

    ''' <summary>
    '''依Station_No取得所有Print_Cond設定資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function queryPrintCondByStation(ByVal inStationNo As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim tableName As String = "PCS_Terminal_Config2"
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet = New DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("SELECT Print_Cond " & vbCrLf)
            sqlStr.Append("FROM   PCS_Terminal_Config " & vbCrLf)
            sqlStr.Append("WHERE  Station_No = '" & inStationNo & "' ")


            command.CommandText = sqlStr.ToString

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

    ''' <summary>
    '''依Report_ID取得報表設定資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks></remarks>
    Public Function queryReportConfigByReportId(ByVal inReportId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim tableName As String = "PUB_Print_Config1"
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet = New DataSet
            If connFlag Then
                conn = getPUBConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("SELECT * " & vbCrLf)
            sqlStr.Append("FROM   PUB_Print_Config " & vbCrLf)
            sqlStr.Append("WHERE  Report_Id = '" & inReportId & "' ")

            command.CommandText = sqlStr.ToString
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

    ''' <summary>
    ''' 依Report_ID取得報表列印模式
    ''' </summary>
    ''' <param name="inReportId">報表代碼</param>
    ''' <param name="conn">資料庫連結</param>
    ''' <returns>String</returns>
    ''' <remarks>L:本機印表 , R:遠端印表 , A:本機 and 遠端印表</remarks>
    Public Function queryReportMode(ByVal inReportId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Dim tableName As String = "PUB_Print_Config"
        Dim connFlag As Boolean = conn Is Nothing
        Dim pvtLocalFlag, pvtRemoteFlag As Boolean
        Dim pvtPrintMode As String = ""

        Try
            Dim ds As DataSet = New DataSet
            If connFlag Then
                conn = getPUBConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("SELECT * " & vbCrLf)
            sqlStr.Append("FROM   PUB_Print_Config " & vbCrLf)
            sqlStr.Append("WHERE  Report_Id = '" & inReportId & "' ")

            command.CommandText = sqlStr.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            '判斷列印模式處理
            For i = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(i).Item("Print_Type").ToString.Trim = "1" Then
                    pvtLocalFlag = True
                    pvtPrintMode = "L"
                ElseIf ds.Tables(0).Rows(i).Item("Print_Type").ToString.Trim = "2" Then
                    pvtRemoteFlag = True
                    pvtPrintMode = "R"
                End If

                If pvtLocalFlag AndAlso pvtRemoteFlag Then
                    pvtPrintMode = "A"
                    Exit For
                End If
            Next

            Return pvtPrintMode
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

    ''' <summary>
    ''' 取得 NIS DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getNISDBSqlConn
    End Function

    ''' <summary>
    ''' 取得 PUB DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPUBConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

End Class
