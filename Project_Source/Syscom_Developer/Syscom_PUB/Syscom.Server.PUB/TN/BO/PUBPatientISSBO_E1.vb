'/*
'*****************************************************************************
'*
'*    Page/Class Name:  ISS
'*              Title:	PUBPatientISSBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2016-06-17
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2016-06-17
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


Public Class PUBPatientISSBO_E1
    Inherits PubPatientIssBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPatientISSBO_E1
    Public Overloads Function GetInstance() As PUBPatientISSBO_E1
        If myInstance Is Nothing Then
            myInstance = New PUBPatientISSBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "

#End Region

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "
    Public Function PubPatientIssDelete(ByVal Medical_Sn As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from PUB_Patient_ISS where " & _
            " Medical_Sn=@Medical_Sn"
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
                command.Parameters.AddWithValue("@Medical_Sn", Medical_Sn)
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

#Region "     查詢 Method "
    ''' <summary>
    ''' 查詢最近一筆評分資料
    ''' </summary>
    ''' <param name="pk_Chart_No"></param>
    ''' <param name="pk_Medical_Sn"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PUBPatientISSBOqueryByPK(ByRef pk_Chart_No As System.String, ByRef pk_Medical_Sn As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim Content As New StringBuilder
            Content.AppendLine("SELECT TOP 1 [Chart_No]")
            Content.AppendLine("      ,[Evaluate_Date]")
            Content.AppendLine("      ,[Medical_Sn]")
            Content.AppendLine("      ,[HeadNeck_AIS]")
            Content.AppendLine("      ,[HeadNeck_Item]")
            Content.AppendLine("      ,[Face_AIS]")
            Content.AppendLine("      ,[Face_Item]")
            Content.AppendLine("      ,[Chest_AIS]")
            Content.AppendLine("      ,[Chest_Item]")
            Content.AppendLine("      ,[Abdomen_AIS]")
            Content.AppendLine("      ,[Abdomen_Item]")
            Content.AppendLine("      ,[Extremity_AIS]")
            Content.AppendLine("      ,[Extremity_Item]")
            Content.AppendLine("      ,[External_AIS]")
            Content.AppendLine("      ,[External_Item]")
            Content.AppendLine("      ,[ISS_Score]")
            Content.AppendLine("      ,[Create_User]")
            Content.AppendLine("      ,[Create_Time]")
            Content.AppendLine("      ,[Modified_User]")
            Content.AppendLine("      ,[Modified_Time]")
            Content.AppendLine("  FROM [PUB_Patient_ISS]")
            Content.AppendLine("  Where Chart_No=@ChartNo")
            Content.AppendLine("    And Medical_Sn=@MedicalSn")
            Content.AppendLine("Order By Evaluate_Date Desc ")
            Content.AppendLine("")

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@ChartNo", pk_Chart_No)
            command.Parameters.AddWithValue("@MedicalSn", pk_Medical_Sn)
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

End Class

