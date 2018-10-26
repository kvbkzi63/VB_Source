Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PUBPatientFlagBO_E1
    Inherits PubPatientFlagBO
    Private Shared instance As PUBPatientFlagBO_E1

    Public Overloads Shared Function getInstance() As PUBPatientFlagBO_E1
        instance = New PUBPatientFlagBO_E1
        Return instance
    End Function

    Public Function queryPubPatientFlagByKey(ByVal chartNo As String) As DataSet 'Implements IPUBPatientFlagBO.queryPubPatientFlagByKey

       Try
            Using conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Using command As SqlCommand = conn.CreateCommand

                    command.CommandText = "SELECT * " & _
                                           " FROM PUB_Patient_Flag A WITH(NOLOCK)" & _
                                          " INNER JOIN PUB_SYSCODE B WITH(NOLOCK) ON A.Flag_Id = B.Code_Id" & _
                                                                               " AND B.Type_Id = '30'" & _
                                                                               " AND B.DC = 'N'" & _
                                          " WHERE A.Chart_No = @Chart_No" & _
                                          " ORDER BY A.Flag_Id"

                    command.Parameters.AddWithValue("@Chart_No", chartNo)

                    Using da As SqlDataAdapter = New SqlDataAdapter(command)
                        Using ds As DataSet = New DataSet("resultDB")
                            da.FillSchema(ds, SchemaType.Source, "resulttable")
                            da.Fill(ds, "resulttable")
                            Return ds
                        End Using
                    End Using
                End Using
            End Using

        Catch ex As SqlClient.SqlException

            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得病患註記資料
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <returns>查詢結果</returns>
    ''' <author>Ken</author>
    ''' <remarks></remarks>
    Public Function GetPatientFlagInfoByChartNo(ByVal ChartNo As String) As DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(Chart_No) AS Chart_No, " & vbCrLf)
        var1.Append("       RTRIM(Flag_Id)  AS Flag_Id, " & vbCrLf)
        var1.Append("       Flag_Memo " & vbCrLf)
        var1.Append("FROM   PUB_Patient_Flag " & vbCrLf)
        var1.Append("WHERE  Chart_No = @Chart_No " & vbCrLf)

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = getConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Chart_No", ChartNo)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "PUB_Patient_Flag")
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "PUB_Patient_Flag")
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    Public Function getSpecialMark(ByVal Chart_No As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT Rtrim(A.Chart_No)      AS Chart_No, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Flag_Id)       AS Flag_Id, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Flag_Memo)     AS Flag_Memo, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Record_Date)   AS Record_Date, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Create_User)   AS Create_User, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Create_Time)   AS Create_Time, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Modified_User) AS Modified_User, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Modified_Time) AS Modified_Time, " & vbCrLf)
            sqlString.Append("       Rtrim(B.Code_Name)     AS Code_Name " & vbCrLf)
            sqlString.Append("FROM   PUB_Patient_Flag A " & vbCrLf)
            sqlString.Append("       INNER JOIN PUB_Syscode B " & vbCrLf)
            sqlString.Append("         ON B.Type_Id = '30' " & vbCrLf)
            sqlString.Append("            AND A.Flag_Id = B.Code_Id " & vbCrLf)
            sqlString.Append("WHERE  A.Chart_No = @Chart_No " & vbCrLf)
            sqlString.Append("       AND Substring(A.Flag_Id, 1, 1) NOT IN ( '1', '2', '3', '4', " & vbCrLf)
            sqlString.Append("                                               '5', '6', '7', '8', " & vbCrLf)
            sqlString.Append("                                               '9', '0' )")
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("SELECT Rtrim(A.Chart_No)      AS Chart_No, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Flag_Id)       AS Flag_Id, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Flag_Memo)     AS Flag_Memo, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Record_Date)   AS Record_Date, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Create_User)   AS Create_User, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Create_Time)   AS Create_Time, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Modified_User) AS Modified_User, " & vbCrLf)
            sqlString.Append("       Rtrim(A.Modified_Time) AS Modified_Time, " & vbCrLf)
            sqlString.Append("       Rtrim(B.Code_Name)     AS Code_Name " & vbCrLf)
            sqlString.Append("FROM   PUB_Patient_Flag A " & vbCrLf)
            sqlString.Append("       INNER JOIN PUB_Syscode B " & vbCrLf)
            sqlString.Append("         ON B.Type_Id = '30' " & vbCrLf)
            sqlString.Append("            AND A.Flag_Id = B.Code_Id " & vbCrLf)
            sqlString.Append("WHERE  A.Chart_No = @Chart_No " & vbCrLf)
            sqlString.Append("       AND Substring(A.Flag_Id, 1, 1) IN ( '1', '2', '3', '4', " & vbCrLf)
            sqlString.Append("                                           '5', '6', '7', '8', " & vbCrLf)
            sqlString.Append("                                           '9', '0' ) ")

            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Chart_No", Chart_No)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Patient_Flag")
                adapter.Fill(ds, tableName)
                'adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    Public Function getSpecialFlagPlusA(ByVal Chart_No As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("DECLARE @Flag_Id AS VARCHAR(1000)" & vbCrLf)
            sqlString.Append("SET @Flag_Id = ''" & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("SELECT @Flag_Id = Rtrim(B.Flag_Id) + ';' + Rtrim(@Flag_Id) " & vbCrLf)
            sqlString.Append("FROM   PUB_Patient A " & vbCrLf)
            sqlString.Append("       INNER JOIN PUB_Patient_Flag B " & vbCrLf)
            sqlString.Append("         ON A.Chart_No = B.Chart_No " & vbCrLf)
            sqlString.Append("            AND B.Flag_Id >= 'A' " & vbCrLf)
            sqlString.Append("WHERE  A.Chart_No = @Chart_No " & vbCrLf)
            sqlString.Append(" " & vbCrLf)
            sqlString.Append("SELECT @Flag_Id ")

            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Chart_No", Chart_No)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Patient_Flag")
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    '2011-03-28 Add By Alan
    '取得病患惡意欠款資料(FlagId='Y01')
    Public Function getPatientFlagByFlagId(ByVal Chart_No As String, ByVal Flag_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT * " & vbCrLf)
            sqlString.Append("FROM   PUB_Patient_Flag A " & vbCrLf)
            sqlString.Append("WHERE  Chart_No = @Chart_No  And " & vbCrLf)
            sqlString.Append("       Flag_Id= @Flag_Id " & vbCrLf)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Chart_No", Chart_No)
            command.Parameters.AddWithValue("@Flag_Id", Flag_Id)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Patient_Flag")
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
    Public Function getPatientFlagByFlagIdList(ByVal Chart_No As String, ByVal Flag_IdList As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT * " & vbCrLf)
            sqlString.Append("FROM   PUB_Patient_Flag A " & vbCrLf)
            sqlString.Append("WHERE  Chart_No = @Chart_No  And " & vbCrLf)
            sqlString.Append("       Flag_Id in (" & Flag_IdList & ")" & vbCrLf)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Chart_No", Chart_No)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Patient_Flag")
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#Region "關懷用藥"
    Public Function getPatientFlagByFlagIdListDate(ByVal Chart_No As String, ByVal Flag_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT * " & vbCrLf)
            sqlString.Append("FROM   PUB_Patient_Flag A " & vbCrLf)
            sqlString.Append("WHERE  Chart_No = @Chart_No  And " & vbCrLf)
            sqlString.Append("Flag_Id = @Flag_Id  " & vbCrLf)
            sqlString.Append("AND Record_Date=REPLACE(CONVERT(VARCHAR(10) , GETDATE(), 111 ), '/', '-') " & vbCrLf)

            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Chart_No", Chart_No)
            command.Parameters.AddWithValue("@Flag_Id", Flag_Id)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Patient_Flag")
                adapter.Fill(ds)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
    Public Function InsertPatientFlagByKey(ByVal Chart_No As String, ByVal Flag_Id As String, ByVal Flag_Memo As String, ByVal Record_Date As String, ByVal Create_User As String) As Integer
        Dim count As Integer = 0
        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
        Try
            Dim insertSql As String = "insert into PUB_Patient_Flag (" & _
            " Chart_No , Flag_Id , Flag_Memo , Record_Date , Create_User ,  " & _
             " Create_Time , Modified_User , Modified_Time ) " & _
             " values( @Chart_No , @Flag_Id , @Flag_Memo , @Record_Date , @Create_User ,  " & _
             " @Create_Time , @Modified_User , @Modified_Time             )"

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = insertSql
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Chart_No", Chart_No)
                command.Parameters.AddWithValue("@Flag_Id", Flag_Id)
                command.Parameters.AddWithValue("@Flag_Memo", Flag_Memo)
                command.Parameters.AddWithValue("@Record_Date", Record_Date)
                command.Parameters.AddWithValue("@Create_User", Create_User)
                command.Parameters.AddWithValue("@Create_Time", Now)
                command.Parameters.AddWithValue("@Modified_User", Create_User)
                command.Parameters.AddWithValue("@Modified_Time", Now)
                conn.Open()
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch ex As Exception
            Throw ex
        Finally
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End Try
    End Function
    Public Function deletetPatientFlagByKey(ByRef pk_Chart_No As System.String, ByRef pk_Flag_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from PUB_Patient_Flag where " & _
            " Chart_No=@Chart_No and Flag_Id=@Flag_Id "
            If connFlag Then
                conn = SQLConnFactory.getInstance.getPubDBSqlConn
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)
                command.Parameters.AddWithValue("@Flag_Id", pk_Flag_Id)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region
End Class
