'/*
'*****************************************************************************
'*
'*    Page/Class Name:  部份負擔基本檔維護
'*              Title:	PUBPartBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2015-09-10
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2015-09-10
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports System.Text



Public Class PUBPartBO_E2
    Inherits PubPartBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPartBO_E2
    Public Overloads Shared Function GetInstance() As PUBPartBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPartBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "
    ''' <summary>
    ''' 根據生效日和部份負擔代碼取得所有資料
    ''' </summary>
    ''' <param name="dateEffectDate"></param>
    ''' <param name="strPartCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBPartByCond(ByVal dateEffectDate As Date, ByVal strPartCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet 'Implements IPUBPartBO.queryPUBPartByCond
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select * from " & tableName & " where 1=1 ")
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                content.Append("and ").Append("Effect_Date =@Effect_Date ")
            End If
            If Not strPartCode.Equals("") Then
                content.Append("and ").Append("Part_Code =@Part_Code ")
            End If
            content.Append("order by Part_Code,Effect_Date")
            command.CommandText = content.ToString
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                command.Parameters.AddWithValue("@Effect_Date", dateEffectDate)
            End If
            If Not strPartCode.Equals("") Then
                command.Parameters.AddWithValue("@Part_Code", strPartCode)
            End If
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region

End Class

