'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患特殊註記顯示排序檔
'*              Title:	PubPatFlagSortBO_E1
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


Public Class PubPatFlagSortBO_E1
    Inherits PubPatFlagSortBO

#Region "     查詢 Method "

#Region " 以ＰＫ查詢資料"

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByPKROC(ByRef pk_Flag_Id As System.String, ByRef strFlagSortId As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT Flag_Id")
            Content.AppendLine("	  ,(select Code_Name from Pub_Syscode where Type_Id = '30' and Code_Id = a.Flag_Id) as Flag_Id_Name")
            Content.AppendLine("      ,Flag_Sort_Id")
            Content.AppendLine("	  ,Case Flag_Sort_Id when '1' then '系統別' when '2' then '角色' end as Flag_Sort_Id_Name")
            Content.AppendLine("      ,Flag_Sort_Content")
            Content.AppendLine("      ,Create_User")
            Content.AppendLine("      ,Create_Time")
            Content.AppendLine("	  ,dbo.adToROCTime(Create_Time) as Create_Time_Name")
            Content.AppendLine("      ,Modified_User")
            Content.AppendLine("      ,Modified_Time")
            Content.AppendLine("	  ,dbo.adToROCTime(Modified_Time) as Modified_Time_Name")
            Content.AppendLine("  FROM PUB_Pat_Flag_Sort A")
            Content.AppendLine("  Where 1=1 ")

            If pk_Flag_Id <> "" Then
                Content.AppendLine("  and Flag_Id = @Flag_Id ")
            End If
            If strFlagSortId <> "" Then
                Content.AppendLine("  and Flag_Sort_Id = @Flag_Sort_Id")
            End If

            command.CommandText = Content.ToString
            If pk_Flag_Id <> "" Then
                command.Parameters.AddWithValue("@Flag_Id", pk_Flag_Id)
            End If
            If strFlagSortId <> "" Then
                command.Parameters.AddWithValue("@Flag_Sort_Id", strFlagSortId)
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
            command.CommandText = "  select Code_Id , Code_Name , Code_Id + '-' + Code_Name as Id_Name from Pub_Syscode where Type_Id = '30'"

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

#End Region

End Class

