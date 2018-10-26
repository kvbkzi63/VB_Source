'/*
'*****************************************************************************
'*
'*    Page/Class Name:  住院護理站基本檔維護
'*              Title:	queryByCond
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Hanru
'*        Create Date:	2016-06-30
'*      Last Modifier:	Hanru
'*   Last Modify Date:	2016-06-30
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


Public Class PubStationBO_E1
    Inherits PubStationBO

#Region "     查詢 Method "

#Region " 查詢護理站基本檔資料 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="pk_Station_No" >護理站代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Hanru on 2016-06-30</remarks>
    Public Function queryByCond(ByVal pk_Station_No As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select ")
            content.AppendLine("Station_No, Station_Name, ")
            content.AppendLine("Expand_Date, Floor, ")
            content.AppendLine("Unit_Dosage_Nature_Sign, ")
            content.AppendLine("Region_Kind, ")
            content.AppendLine("Consumption_Unit, ")
            content.AppendLine("Consumption_Name, ")
            content.AppendLine("Station_Email, Station_Ext_Tel, ")
            content.AppendLine("Dc, ")
            content.AppendLine("Create_User, [dbo].[AdToRocTime] (Create_Time) as Create_Time, ")
            content.AppendLine("Modified_User, [dbo].[AdToRocTime](Modified_Time) as Modified_Time ")
            content.AppendLine("From PUB_Station ")
            content.AppendLine("Where 1=1 ")
            If pk_Station_No <> "" Then
                content.AppendLine("And Station_No = @Station_No ")
            End If

            command.CommandText = content.ToString

            If pk_Station_No <> "" Then
                command.Parameters.AddWithValue("@Station_No", pk_Station_No)
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

#End Region

End Class

