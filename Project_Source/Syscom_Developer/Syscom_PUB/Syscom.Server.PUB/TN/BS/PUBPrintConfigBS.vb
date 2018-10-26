'/*
'*****************************************************************************
'*
'*    Page/Class Name:  報表維護資料
'*              Title:	PUBPrintConfigBS
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Hsiao.Kaiwen
'*        Create Date:	2015-09-21
'*      Last Modifier:	Hsiao.Kaiwen
'*   Last Modify Date:	2015-09-21
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports System.Text


Public Class PUBPrintConfigBS

    Public Shared ReadOnly tableNamePrintConfig As String = "PUB_Print_Config"
    Public Shared ReadOnly tableNameReportDesc As String = "PUB_Report_Desc"

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPrintConfigBS
    Public Shared Function GetInstance() As PUBPrintConfigBS
        If myInstance Is Nothing Then
            myInstance = New PUBPrintConfigBS
        End If
        Return myInstance
    End Function

#End Region

#Region "     新增 PUB_Print_Config、PUB_Report_Desc 資料 "

    Public Function PUBPrintConfigBSInsert(ByVal dsPubPrintConfig As DataSet, ByVal dsPubReportDesc As System.Data.DataSet) As Integer

        Dim scope As TransactionScope = Nothing
        scope = SQLConnFactory.getInstance.getRequiredTransactionScope()

        Dim mPubPrintConfigBO As New PubPrintConfigBO
        Dim mPubReportDescBO As New PubReportDescBO

        Try

            Using conn As System.Data.IDbConnection = CType(getConnection(), SqlConnection)
                conn.Open()

                '查詢是否有重複
                Dim Qds As DataSet
                Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
                Dim Qcommand As SqlCommand = sqlConn.CreateCommand()
                Dim content As New StringBuilder

                content.AppendLine("select   ")
                content.AppendLine(" Report_ID , Report_Name , System_Code , Report_Desc , Create_User ,  ")
                content.AppendLine(" Create_Time , Modified_User , Modified_Time                from " & tableNameReportDesc)
                content.AppendLine("   where Report_ID=@Report_ID            ")
                Qcommand.CommandText = content.ToString
                Qcommand.Parameters.AddWithValue("@Report_ID", dsPubReportDesc.Tables(0).Rows(0).Item("Report_ID").ToString.Trim)
                Using adapter As SqlDataAdapter = New SqlDataAdapter(Qcommand)
                    Qds = New DataSet(tableNameReportDesc)
                    adapter.Fill(Qds, tableNameReportDesc)
                End Using


                '判斷PUB_Report_Desc是否有值，有就用update的方式，沒有用insert
                If Qds.Tables(0).Rows.Count = 0 Then
                    mPubPrintConfigBO.insert(dsPubPrintConfig, conn)
                    mPubReportDescBO.insert(dsPubReportDesc, conn)

                ElseIf Qds.Tables(0).Rows.Count <> 0 Then
                    mPubPrintConfigBO.insert(dsPubPrintConfig, conn)
                    mPubReportDescBO.update(dsPubReportDesc, conn)

                End If

                scope.Complete()
                Return 2

            End Using

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally

            Try
                If scope IsNot Nothing Then scope.Dispose()
            Catch ex As Exception
                Throw ex
            End Try

        End Try

    End Function

#End Region

#Region "     修改 PUB_Print_Config、PUB_Report_Desc 資料 "

    Public Function PUBPrintConfigBSUpdate(ByVal dsPubPrintConfig As DataSet, ByVal dsPubReportDesc As System.Data.DataSet) As Integer

        Dim scope As TransactionScope = Nothing
        scope = SQLConnFactory.getInstance.getRequiredTransactionScope()

        Dim mPubPrintConfigBO As New PubPrintConfigBO
        Dim mPubReportDescBO As New PubReportDescBO

        Try

            Using conn As System.Data.IDbConnection = CType(getConnection(), SqlConnection)
                conn.Open()

                '查詢是否有重複
                Dim Qds As DataSet
                Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
                Dim Qcommand As SqlCommand = sqlConn.CreateCommand()
                Dim content As New StringBuilder

                content.AppendLine("select   ")
                content.AppendLine(" Report_ID , Report_Name , System_Code , Report_Desc , Create_User ,  ")
                content.AppendLine(" Create_Time , Modified_User , Modified_Time                from " & tableNameReportDesc)
                content.AppendLine("   where Report_ID=@Report_ID            ")
                Qcommand.CommandText = content.ToString
                Qcommand.Parameters.AddWithValue("@Report_ID", dsPubReportDesc.Tables(0).Rows(0).Item("Report_ID").ToString.Trim)
                Using adapter As SqlDataAdapter = New SqlDataAdapter(Qcommand)
                    Qds = New DataSet(tableNameReportDesc)
                    adapter.Fill(Qds, tableNameReportDesc)
                End Using


                '判斷PUB_Report_Desc是否有值，有就用update的方式，沒有用insert
                If Qds.Tables(0).Rows.Count = 0 Then
                    mPubPrintConfigBO.update(dsPubPrintConfig, conn)
                    mPubReportDescBO.insert(dsPubReportDesc, conn)

                ElseIf Qds.Tables(0).Rows.Count <> 0 Then
                    mPubPrintConfigBO.update(dsPubPrintConfig, conn)
                    mPubReportDescBO.update(dsPubReportDesc, conn)

                End If

                scope.Complete()
                Return 2

            End Using

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally

            Try
                If scope IsNot Nothing Then scope.Dispose()
            Catch ex As Exception
                Throw ex
            End Try

        End Try

    End Function

#End Region

#Region "     刪除 PUB_Print_Config、PUB_Report_Desc 資料 "
    Public Function PUBPrintConfigBSDelete(ByVal pk_Report_Id As System.String, ByVal pk_Print_Type As System.String, ByVal pk_Print_Cond As System.String) As Integer

        Dim scope As TransactionScope = Nothing
        scope = SQLConnFactory.getInstance.getRequiredTransactionScope()

        Dim mPubPrintConfigBO As New PubPrintConfigBO
        Dim mPubReportDescBO As New PubReportDescBO

        Try

            Using conn As System.Data.IDbConnection = CType(getConnection(), SqlConnection)
                conn.Open()

                '查詢是否有重複
                Dim Qds As DataSet
                Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
                Dim Qcommand As SqlCommand = sqlConn.CreateCommand()
                Dim content As New StringBuilder

                content.AppendLine("select   ")
                content.AppendLine(" Report_ID , Report_Name , System_Code , Report_Desc , Create_User ,  ")
                content.AppendLine(" Create_Time , Modified_User , Modified_Time                from " & tableNameReportDesc)
                content.AppendLine("   where Report_ID=@Report_ID            ")
                Qcommand.CommandText = content.ToString
                Qcommand.Parameters.AddWithValue("@Report_ID", pk_Report_Id)
                Using adapter As SqlDataAdapter = New SqlDataAdapter(Qcommand)
                    Qds = New DataSet(tableNameReportDesc)
                    adapter.Fill(Qds, tableNameReportDesc)
                End Using


                '判斷PUB_Report_Desc是否有值，有就用update的方式，沒有用insert
                If Qds.Tables(0).Rows.Count = 0 Then
                    mPubPrintConfigBO.delete(pk_Report_Id, pk_Print_Type, pk_Print_Cond, conn)

                ElseIf Qds.Tables(0).Rows.Count <> 0 Then
                    mPubPrintConfigBO.delete(pk_Report_Id, pk_Print_Type, pk_Print_Cond, conn)
                    mPubReportDescBO.delete(pk_Report_Id, conn)

                End If

                scope.Complete()
                Return 2

            End Using

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally

            Try
                If scope IsNot Nothing Then scope.Dispose()
            Catch ex As Exception
                Throw ex
            End Try

        End Try

    End Function

#End Region

#Region "     取得 DB 在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>by Hsiao.Kaiwen on 2015-09-21</remarks>
    Public Function getConnection() As IDbConnection

        '自行設定正確的Connection 字串
        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class

