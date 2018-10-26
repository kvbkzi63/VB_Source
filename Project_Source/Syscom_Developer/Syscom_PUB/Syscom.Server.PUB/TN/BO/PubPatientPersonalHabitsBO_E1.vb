'/*
'*****************************************************************************
'*
'*    Page/Class Name:  PUB_Patient_Personal_Habits
'*              Title:	PubPatientPersonalHabitsBO_E1
'*        Description:	吸菸嚼檳榔問卷作業
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	ChenYu.Guo
'*        Create Date:	2015-08-12
'*      Last Modifier:	ChenYu.Guo
'*   Last Modify Date:	2015-08-12
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP

Public Class PubPatientPersonalHabitsBO_E1
    Inherits PubPatientPersonalHabitsBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubPatientPersonalHabitsBO_E1
    Public Shared Shadows Function GetInstance() As PubPatientPersonalHabitsBO_E1
        If myInstance Is Nothing Then
            myInstance = New PubPatientPersonalHabitsBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢該病患最近一年內的勸戒之記錄 "

    ''' <summary>
    ''' 查詢該病患最近一年內的勸戒之記錄
    ''' </summary>
    ''' <param name="ChartNo" >病患病歷號</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by ChenYu.Guo on 2015-08-12</remarks>
    Public Function QueryInOneYearAdmonishRecord(ByRef ChartNo As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT * " & vbCrLf)
            varname1.Append("FROM   PUB_Patient_Personal_Habits " & vbCrLf)
            varname1.Append("WHERE  Chart_no = @ChartNo " & vbCrLf)
            varname1.Append("       AND Datediff(yy, Last_Ask_Date, '" + Now().ToString("yyyy/MM/dd") + "') < 1 ")
            'varname1.Append("       AND Advise_Date IS NOT NULL " & vbCrLf)
            'varname1.Append("       AND Advise_Date >= Last_Ask_Date ")

            command.CommandText = varname1.ToString
            command.Parameters.AddWithValue("@ChartNo", ChartNo)

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

