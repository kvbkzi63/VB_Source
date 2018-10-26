'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患DNR記錄檔
'*              Title:	PubPatientDnrBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Eddie,Lu
'*        Create Date:	2016-05-20
'*      Last Modifier:	Eddie,Lu
'*   Last Modify Date:	2016-05-20
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


Public Class PubPatientDnrBO_E1
    Inherits PubPatientDnrBO

#Region "     新增 Method "

#Region " 新增With DNR流水號"

    ''' <summary>
    '''新增
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function insertWithDNRNo(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Chart_No , Source_Kind , DNR_No , DNR_Kind_Id , Cancel ,  " & _
             " Create_User , Create_Time , Modified_User ,  " & _
             " Modified_Time ) " & _
             " values( @Chart_No , @Source_Kind , @DNR_No , @DNR_Kind_Id , @Cancel ,  " & _
             " @Create_User , @Create_Time , @Modified_User ,  " & _
             " @Modified_Time             )"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                    command.Parameters.AddWithValue("@Source_Kind", row.Item("Source_Kind"))
                    command.Parameters.AddWithValue("@DNR_No", queryMaxDNRNo(row.Item("Chart_No"), conn))
                    command.Parameters.AddWithValue("@DNR_Kind_Id", row.Item("DNR_Kind_Id"))
                    command.Parameters.AddWithValue("@Cancel", "N")
                    'command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                    'command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime)
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
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
            Throw New CommonException("CMMCMMB912", ex)
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

#Region " 以ＰＫ查詢資料"

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByPKROC(ByRef pk_Chart_No As System.String, ByRef strDNRKindId As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT Chart_No")
            Content.AppendLine("	  ,(select IdNo from Pub_Patient where Chart_No = A.Chart_No) as Idno")
            Content.AppendLine("	  ,(select Patient_Name from Pub_Patient where Chart_No = A.Chart_No) as Patient_Name")
            Content.AppendLine("      ,Source_Kind")
            Content.AppendLine("	  ,Case Source_Kind when '1' then'健保局' when '2' then '醫院' end as Source_Kind_Name")
            Content.AppendLine("      ,DNR_No")
            Content.AppendLine("      ,DNR_Kind_Id")
            Content.AppendLine("	  ,(select Code_Name from Pub_Syscode where Type_Id = '512' and Code_Id = A.DNR_Kind_Id) as DNR_Kind_Id_Name")
            Content.AppendLine("      ,Cancel")
            Content.AppendLine("	  ,Case Cancel when 'Y' then'是' when 'N' then '否' end as Cancel_Name")
            Content.AppendLine("      ,Cancel_User")
            Content.AppendLine("      ,Cancel_Time")
            Content.AppendLine("	  ,dbo.adToROCTime(Cancel_Time) as Cancel_Time_ROC")
            Content.AppendLine("      ,Create_User")
            Content.AppendLine("      ,Create_Time")
            Content.AppendLine("	  ,dbo.adToROCTime(Create_Time) as Create_Time_ROC")
            Content.AppendLine("      ,Modified_User")
            Content.AppendLine("      ,Modified_Time")
            Content.AppendLine("	  ,dbo.adToROCTime(Modified_Time) as Modified_Time_ROC")
            Content.AppendLine("  FROM PUB_Patient_DNR A")
            Content.AppendLine("  Where Chart_No = @Chart_No")

            If strDNRKindId <> "" Then
                Content.AppendLine("  and DNR_Kind_Id = @DNR_Kind_Id")
            End If

            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)

            If strDNRKindId <> "" Then
                command.Parameters.AddWithValue("@DNR_Kind_Id", strDNRKindId)
            End If

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
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

#Region " 取得ComboBox資料 "

    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function queryCboDs(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " select Code_Id , Code_Name , Code_Id + '-' + Code_Name as Id_Name from Pub_Syscode where Type_Id = '512'  "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SQLException
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


#Region " 取得最大DNR流水號 "

    ''' <summary>
    ''' 取得最大DNR流水號
    ''' </summary>
    ''' <param name="strChartNo" >病歷號</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Eddie,Lu on 2016-05-20</remarks>
    Public Function queryMaxDNRNo(ByVal strChartNo As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim rtnString As String

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "  Select isNull(Max(DNR_No),'0') + '1' as DNR_No from PUB_Patient_DNR where Chart_No = @Chart_No"

            command.Parameters.AddWithValue("@Chart_No", strChartNo)

            rtnString = StringUtil.nvl(command.ExecuteScalar)

            Return rtnString

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

