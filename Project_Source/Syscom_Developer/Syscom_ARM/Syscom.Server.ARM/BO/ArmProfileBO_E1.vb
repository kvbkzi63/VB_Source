Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.Utility
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP

Public Class ArmProfileBO_E1
    Inherits ArmProfileBO

    Dim log As LOGDelegate = LOGDelegate.getInstance
    Private userID As String = AppContext.userProfile.userId

#Region "   getInstance"
    Public Shadows ReadOnly Property getInstance()
        Get
            Return New ArmProfileBO_E1
        End Get
    End Property
#End Region

#Region "   Get SQL connection."
    ''' <summary>
    ''' Get SQL connection.
    ''' </summary>
    ''' <returns>sql connection</returns>
    ''' <remarks></remarks>
    Private Overloads Function getConnection() As SqlConnection

        Return SQLConnFactory.getInstance.getArmDBSqlConn
    End Function
#End Region

    Public Function queryProfile(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, Optional ByVal flag As String = "", Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim sqlString As New System.Text.StringBuilder
        sqlString.Append("SELECT * " & vbCrLf)
        sqlString.Append("FROM   arm_profile " & vbCrLf)
        sqlString.Append("WHERE  system_no = '" & pk_System_No & "' " & vbCrLf)
        sqlString.Append("       AND employee_code = '" & pk_Employee_Code & "' ")
        If flag = "Y" Then
            sqlString.Append("       AND Is_Default = '" & flag & "' ")
        End If

        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
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
    '清空is_Default
    Public Function updateProfile(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim sqlString As New System.Text.StringBuilder
        sqlString.Append("UPDATE arm_ProFile " & vbCrLf)
        sqlString.Append("SET    Is_Default = '' " & vbCrLf)
        sqlString.Append("WHERE  System_No = '" & pk_System_No & "' " & vbCrLf)
        sqlString.Append("       AND Employee_Code = '" & pk_Employee_Code & "' " & vbCrLf)


        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Connection = conn
            command.ExecuteNonQuery()
            Return 0
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    Public Function updateProfileDefault(ByVal pk_System_No As String, ByVal pk_Employee_Code As String, ByVal pk_Sub_File As String, Optional ByVal flag As String = "Y", Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim sqlString As New System.Text.StringBuilder
        sqlString.Append("UPDATE arm_ProFile " & vbCrLf)
        sqlString.Append("SET    Is_Default = '" & flag & "' " & vbCrLf)
        sqlString.Append("WHERE  System_No = '" & pk_System_No & "' " & vbCrLf)
        sqlString.Append("       AND Employee_Code = '" & pk_Employee_Code & "' " & vbCrLf)
        sqlString.Append("       AND Sub_File_Name = '" & pk_Sub_File & "' " & vbCrLf)

        updateProfile(pk_System_No, pk_Employee_Code)
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Connection = conn
            command.ExecuteNonQuery()
            Return 0
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

   

End Class