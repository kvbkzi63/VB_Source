'/*
'*****************************************************************************
'*
'*    Page/Class Name:  統計查詢設定作業
'*              Title:	PubExportSetupBS
'*        Description:	1.新增、刪除、修改
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-08-10
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-08-10
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP



Public Class PubExportSetupBS

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubExportSetupBS
    Public Shared Function GetInstance() As PubExportSetupBS
        If myInstance Is Nothing Then
            myInstance = New PubExportSetupBS
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "
    ''' <summary>
    ''' 新增資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Public Function PUBExportInsertData(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing
        Dim count As Integer = 0
        Try

            Using Scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

                If connFlag Then
                    conn = getConnection()
                    conn.Open()
                End If
                Dim svrDS As New DataSet
                '建立表頭資料
                count = PUBExportBO_E1.GetInstance.insert(ds, conn)
                '建立表尾資料
                svrDS.Tables.Add(ds.Tables(1).Copy)
                count += PUBExportDetailBO_E1.GetInstance.insert(svrDS, conn)

                Scope.Complete()
            End Using
            Return count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"自行輸入提示"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region "     修改 Method "

    ''' <summary>
    ''' 修改資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Public Function PUBExportUpdateDataByPk(ByVal Report_Id As String, ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing
        Dim count As Integer = 0
        Try

            Using Scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

                If connFlag Then
                    conn = getConnection()
                    conn.Open()
                End If
                '先刪除表身資料
                count = PUBExportDetailBO_E1.GetInstance.deleteAll(Report_Id, conn)
                '修改表頭資料
                count = PUBExportBO_E1.GetInstance.update(ds, conn)
                '重新建立表尾資料
                Dim dataDS As New DataSet
                dataDS.Tables.Add(ds.Tables(1).Copy)
                count += PUBExportDetailBO_E1.GetInstance.insert(dataDS, conn)

                Scope.Complete()
            End Using
            Return count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"自行輸入提示"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region

#Region "     刪除 Method "

#Region " 刪除資料 "

    ''' <summary>
    ''' 刪除資料
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Public Function PUBExportDeleteData(ByVal Report_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing
        Dim count As Integer = 0
        Try

            Using Scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

                If connFlag Then
                    conn = getConnection()
                    conn.Open()
                End If
                count = PUBExportDetailBO_E1.GetInstance.deleteAll(Report_Id, conn)
                count = PUBExportBO_E1.GetInstance.delete(Report_Id, conn)
                Scope.Complete()
            End Using
            Return count

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"自行輸入提示"})
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

#Region " 統計查詢設定作業 "

    ''' <summary>
    ''' 查詢設定作業(Export)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Public Function PUBExportExportDataQuery(ByVal Report_id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As New DataSet
            Dim ExportDT As DataTable
            ExportDT = PUBExportBO_E1.GetInstance.queryData(Report_id)
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            ds.Merge(ExportDT)

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

    ''' <summary>
    ''' 查詢設定作業(Export_detail)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Public Function PUBExportExportDetailDataQuery(ByVal Report_id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As New DataSet
            Dim ExportDT As DataTable
            ExportDT = PUBExportDetailBO_E1.GetInstance.queryData(Report_id)
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            ds.Merge(ExportDT)

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

    ''' <summary>
    ''' 查詢設定作業(新增後查詢)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Public Function PUBExportQueryForInsert(ByVal Report_id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As New DataSet
            Dim ExportDT As DataTable
            Dim DetailDT As DataTable
            ExportDT = PUBExportBO_E1.GetInstance.queryData(Report_id)
            DetailDT = PUBExportDetailBO_E1.GetInstance.queryData(Report_id)
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            ds.Merge(ExportDT)
            ds.Merge(DetailDT)
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

#Region "    查詢報表平台"
    ''' <summary>
    ''' 查詢報表平台(報表動態查詢)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Public Function PubExportQueryData(ByVal sql As String, ByVal getConnection As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            Select Case getConnection
                Case "GetOpdSqlConn"
                    conn = SQLConnFactory.getInstance.getOpdDBSqlConn
                Case "GetEisSqlConn"
                    conn = SQLConnFactory.getInstance.getEisDBSqlConn
                Case "GetPcsSqlConn"
                    conn = SQLConnFactory.getInstance.getPcsDBSqlConn
                Case "GetNisSqlConn"
                    conn = SQLConnFactory.getInstance.getNisDBSqlConn
                Case "GetPubSqlConn"
                    conn = SQLConnFactory.getInstance.getPubDBSqlConn
            End Select

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Using command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = sql
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)

                    ds = New DataSet("DataDS")
                    adapter.Fill(ds, "DataDS")
                End Using
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
    ''' <summary>
    ''' 查詢報表平台(欄位以及報表相關資訊)
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Public Function PubExportListDataQuery(ByVal Report_id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As New DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            ds.Tables.Add(PUBExportBO_E1.GetInstance.queryData(Report_id, conn))
            ds.Tables.Add(PUBExportDetailBO_E1.GetInstance.queryData(Report_id, conn))

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

#End Region

#Region "     取得 DB 在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Public Function getConnection() As IDbConnection

        '自行設定正確的Connection 字串
        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class

