Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PubSyscodeTypeBO_E1
    Inherits PubSyscodeTypeBO

    Dim log As LOGDelegate = LOGDelegate.getInstance

#Region "########## getInstance ##########"
    Private Shared instance As PubSyscodeTypeBO_E1
    Public Overloads Shared Function getInstance() As PubSyscodeTypeBO_E1
        If instance Is Nothing Then
            instance = New PubSyscodeTypeBO_E1
        End If
        Return instance
    End Function
    Public Sub New()
    End Sub
#End Region

#Region "     查詢 Method (For多筆維護UI用，使用LIKE 'PKey%') "
    ''' <summary>
    '''查詢(依PKey)
    ''' </summary>
    ''' <returns>查詢結果</returns>
    ''' <remarks>by Alan Tsai on 2014-11-08</remarks>
    Public Function queryPUBSyscodeTypeLikePKey(ByVal inTypeId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine("  RTRIM(Type_Id) as Type_Id ,  RTRIM(Type_Name) as Type_Name ,'' As Btn_Detail, Create_User , dbo.ADTOROCTime(Create_Time) , Modified_User ,  ")
            content.AppendLine(" dbo.ADTOROCTime(Modified_Time)                from " & tableName)
            content.AppendLine("   where Type_Id Like @Type_Id            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Type_Id", inTypeId & "%")

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds
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

    ''' <summary>
    '''查詢全部
    ''' </summary>
    ''' <returns>查詢結果</returns>
    ''' <remarks>by Alan Tsai on 2014-11-08</remarks>
    Public Function queryPUBSyscodeTypeAll(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Type_Id , Type_Name ,'' As Btn_Detail, Create_User ,dbo.ADTOROCTime(Create_Time), Modified_User ,  ")
            content.AppendLine("   dbo.ADTOROCTime(Modified_Time)               from " & tableName)
            command.CommandText = content.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds
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

#End Region

#Region "     新增 Method (For多筆維護UI用) "
    ''' <summary>
    '''新增
    ''' </summary>
    ''' <returns>新增筆數</returns>
    ''' <remarks>by Alan Tsai on 2014-11-08</remarks>
    Public Function insertPUBSyscodeTypeByRowData(ByVal inType_Id As String,
                                                  ByVal inType_Name As String,
                                                  ByVal inCreate_User As String,
                                                  ByVal inCreate_Time As DateTime,
                                                  ByVal inModified_Name As String,
                                                  ByVal inModified_Time As DateTime,
                                                  Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Type_Id , Type_Name , Create_User , Create_Time , Modified_User ,  " & _
             " Modified_Time ) " & _
             " values( @Type_Id , @Type_Name , @Create_User , @Create_Time , @Modified_User ,  " & _
             " @Modified_Time             )"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Type_Id", inType_Id)
                command.Parameters.AddWithValue("@Type_Name", inType_Name)
                command.Parameters.AddWithValue("@Create_User", inCreate_User)
                command.Parameters.AddWithValue("@Create_Time", inCreate_Time)
                command.Parameters.AddWithValue("@Modified_User", inModified_Name)
                command.Parameters.AddWithValue("@Modified_Time", inModified_Time)
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

#End Region

#Region "     修改 Method (For多筆維護UI用) "
    ''' <summary>
    '''修改
    ''' </summary>
    ''' <returns>修改筆數</returns>
    ''' <remarks>by Alan Tsai on 2014-11-08</remarks>
    Public Function updatePUBSyscodeTypeByRowData(ByVal inType_Id As String,
                                                  ByVal inType_Name As String,
                                                  ByVal inModified_Name As String,
                                                  ByVal inModified_Time As DateTime,
                                                  Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Type_Name=@Type_Name , Modified_User=@Modified_User " & _
            "  , Modified_Time=@Modified_Time " & _
            " where  Type_Id=@Type_Id            "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Type_Id", inType_Id)
                command.Parameters.AddWithValue("@Type_Name", inType_Name)
                command.Parameters.AddWithValue("@Modified_User", inModified_Name)
                command.Parameters.AddWithValue("@Modified_Time", inModified_Time)
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

#End Region

#Region "     刪除 Method (For多筆維護UI用) "
    ''' <summary>
    '''刪除
    ''' </summary>
    ''' <returns>刪除筆數</returns>
    ''' <remarks>by Alan Tsai on 2014-11-03</remarks>
    Public Function deletePubSyscodeTypeByPK(ByRef pk_Type_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Type_Id=@Type_Id "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Type_Id", pk_Type_Id)
                count = command.ExecuteNonQuery
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

#End Region

End Class
