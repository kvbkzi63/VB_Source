'/*
'*****************************************************************************
'*
'*    Page/Class Name:  全國醫療服務卡維護檔新增修改
'*              Title:	PubPatientFlagBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-14
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-14
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.BO



Public Class PubPatientFlagBO_E2
    Inherits PubPatientFlagBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubPatientFlagBO_E2
    Public Overloads Shared Function GetInstance() As PubPatientFlagBO_E2
        If myInstance Is Nothing Then
            myInstance = New PubPatientFlagBO_E2
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

#End Region

#Region "     查詢 Method "
#Region "20110908 全國醫療服務卡維護檔-新增與修改 add by Runxia"
    ''' <summary>
    ''' 查詢PUB_Patient_Flag中Flag_Id ='124'之資料
    ''' </summary>
    ''' <param name="strChartNo">病歷號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPubPatientFlagByChartNo(ByVal strChartNo As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As StringBuilder = New StringBuilder()

            strSql.Append("select * from PUB_Patient_Flag where Flag_Id = '124' ")
            strSql.Append(" and Chart_No = ").Append(" @Chart_No ")

            command.CommandText = strSql.ToString()
            command.Parameters.AddWithValue("@Chart_No", strChartNo)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            'LOGDelegate.getInstance.getFileLogger(Me).Error(sqlex.ToString)
            Throw sqlex
        Catch ex As Exception
            'LOGDelegate.getInstance.getFileLogger(Me).Error(ex.ToString)
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
#End Region

End Class

