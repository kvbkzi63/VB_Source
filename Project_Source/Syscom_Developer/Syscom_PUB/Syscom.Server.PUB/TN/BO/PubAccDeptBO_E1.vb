'/*
'*****************************************************************************
'*
'*    Page/Class Name:  成本中心設定維護
'*              Title:	PubAccDeptBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Chi,Wang
'*        Create Date:	2016-08-25
'*      Last Modifier:	Chi,Wang
'*   Last Modify Date:	2016-08-25
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.BO


Public Class PubAccDeptBO_E1
    Inherits PubAccDeptBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubAccDeptBO_E1
    Public Overloads Shared Function GetInstance() As PubAccDeptBO_E1
        If myInstance Is Nothing Then
            myInstance = New PubAccDeptBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     新增 Method "
#Region " 成本中心設定維護 新增 "

    ''' <summary>
    ''' 成本中心設定維護 新增
    ''' </summary>
    ''' <param name="ds" >新增資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function InsertPubAccDeptData(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("INSERT INTO [PUB_Acc_Dept]")
            Content.AppendLine("           ([Acc_Dept]")
            Content.AppendLine("           ,[Acc_Dept_Name]")
            Content.AppendLine("           ,[Acc_Dept_Upper]")
            Content.AppendLine("           ,[Acc_Dept_Type_Id]")
            Content.AppendLine("           ,[Acc_Level]")
            Content.AppendLine("           ,[Acc_Level_Same]")
            Content.AppendLine("           ,[Acc_Class_Id]")
            Content.AppendLine("           ,[Is_Primary]")
            Content.AppendLine("           ,[Is_Collect]")
            Content.AppendLine("           ,[Create_User]")
            Content.AppendLine("           ,[Create_Time]")
            Content.AppendLine("           ,[Modified_User]")
            Content.AppendLine("           ,[Modified_Time])")
            Content.AppendLine("     VALUES")
            Content.AppendLine("           (@Acc_Dept")
            Content.AppendLine("           ,@Acc_Dept_Name")
            Content.AppendLine("           ,@Acc_Dept_Upper")
            Content.AppendLine("           ,@Acc_Dept_Type_Id")
            Content.AppendLine("           ,@Acc_Level")
            Content.AppendLine("           ,@Acc_Level_Same")
            Content.AppendLine("           ,@Acc_Class_Id")
            Content.AppendLine("           ,@Is_Primary")
            Content.AppendLine("           ,@Is_Collect")
            Content.AppendLine("           ,@Create_User")
            Content.AppendLine("           ,@Create_Time")
            Content.AppendLine("           ,@Modified_User")
            Content.AppendLine("           ,@Modified_Time)")


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With Command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    For Each c As DataColumn In ds.Tables(0).Columns
                        command.Parameters.AddWithValue("@" & c.ColumnName, row.Item(c.ColumnName))
                    Next
   

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next

            Return count

        Catch sqlex As SQLException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#End Region

#Region "     修改 Method "
#Region " 成本中心設定維護 修改 "

    ''' <summary>
    ''' 成本中心設定維護 修改
    ''' </summary>
    ''' <param name="ds" >修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function UpdatePubAccDeptData(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("UPDATE PUB_Acc_Dept")
            'Content.AppendLine("   SET Acc_Dept = @Acc_Dept")
            Content.AppendLine("      SET Acc_Dept_Name = @Acc_Dept_Name")
            Content.AppendLine("      ,Acc_Dept_Upper = @Acc_Dept_Upper")
            Content.AppendLine("      ,Acc_Dept_Type_Id = @Acc_Dept_Type_Id")
            Content.AppendLine("      ,Acc_Level = @Acc_Level")
            Content.AppendLine("      ,Acc_Level_Same = @Acc_Level_Same")
            Content.AppendLine("      ,Acc_Class_Id = @Acc_Class_Id")
            Content.AppendLine("      ,Is_Primary = @Is_Primary")
            Content.AppendLine("      ,Is_Collect = @Is_Collect")
            'Content.AppendLine("      ,Create_User = @Create_User")
            'Content.AppendLine("      ,Create_Time = @Create_Time")
            Content.AppendLine("      ,Modified_User = @Modified_User")
            Content.AppendLine("      ,Modified_Time = @Modified_Time")
            Content.AppendLine(" WHERE Acc_Dept = @Acc_Dept")


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With Command
                        .CommandText = Content.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With

                    command.Parameters.AddWithValue("@Acc_Dept", row.Item("Acc_Dept"))
                    command.Parameters.AddWithValue("@Acc_Dept_Name", row.Item("Acc_Dept_Name"))
                    command.Parameters.AddWithValue("@Acc_Dept_Upper", row.Item("Acc_Dept_Upper"))
                    command.Parameters.AddWithValue("@Acc_Dept_Type_Id", row.Item("Acc_Dept_Type_Id"))
                    command.Parameters.AddWithValue("@Acc_Level", row.Item("Acc_Level"))
                    command.Parameters.AddWithValue("@Acc_Level_Same", row.Item("Acc_Level_Same"))
                    command.Parameters.AddWithValue("@Acc_Class_Id", row.Item("Acc_Class_Id"))
                    command.Parameters.AddWithValue("@Is_Primary", row.Item("Is_Primary"))
                    command.Parameters.AddWithValue("@Is_Collect", row.Item("Is_Collect"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next

            Return count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#End Region

#Region "     刪除 Method "
#Region " 成本中心設定維護 刪除 "

    ''' <summary>
    ''' 成本中心設定維護 刪除
    ''' </summary>
    ''' <param name="PK" >成本中心代號</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function DeletePubAccDeptData(ByVal PK As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim Content As New StringBuilder
            Content.AppendLine("DELETE FROM [PUB_Acc_Dept]")
            Content.AppendLine("      WHERE Acc_Dept=@Acc_Dept")

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = Content.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With


                command.Parameters.AddWithValue("@Acc_Dept", PK)

                count = command.ExecuteNonQuery
            End Using

            Return count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region


#End Region

#Region "     查詢 Method "

#Region " 成本中心設定維護 查詢 "

    ''' <summary>
    ''' 成本中心設定維護 查詢
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Chi,Wang on 2016-08-25</remarks>
    Public Function QueryPubAccDeptByPK(ByVal tmp As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT [Acc_Dept]")
            Content.AppendLine("      ,[Acc_Dept_Name]")
            Content.AppendLine("      ,[Acc_Dept_Upper]")
            Content.AppendLine("      ,[Acc_Dept_Type_Id]")
            Content.AppendLine("      ,[Acc_Level]")
            Content.AppendLine("      ,[Acc_Level_Same]")
            Content.AppendLine("      ,[Acc_Class_Id]")
            Content.AppendLine("      ,[Is_Primary]")
            Content.AppendLine("      ,[Is_Collect]")
            Content.AppendLine("      ,[Create_User]")
            Content.AppendLine("      ,[Create_Time]")
            Content.AppendLine("      ,[Modified_User]")
            Content.AppendLine("      ,[Modified_Time]")
            Content.AppendLine("  FROM [PUB_Acc_Dept]")
            Content.AppendLine(" Where 1=1")
            If Not tmp.Equals("") Then
                Content.AppendLine(" And Acc_Dept=@Acc_Dept")
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString

            If Not tmp.Equals("") Then
                command.Parameters.AddWithValue("@Acc_Dept", tmp)
            End If

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

#End Region


#Region " 成本中心部門 查詢 "

    ''' <summary>
    ''' 成本中心部門 查詢
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by 承毅 on 2016-09-19</remarks>
    Public Function QueryPubAccDeptName(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT [Acc_Dept]")
            Content.AppendLine("      ,[Acc_Dept_Name]")
            Content.AppendLine("  FROM [PUB_Acc_Dept]")
            Content.AppendLine(" order by Acc_Dept")


            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
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

#End Region


#End Region

End Class

