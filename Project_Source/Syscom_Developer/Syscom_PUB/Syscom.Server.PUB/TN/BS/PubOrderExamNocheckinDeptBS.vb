'/*
'*****************************************************************************
'*
'*    Page/Class Name:  檢查醫令不須報到部門維護作業
'*              Title:	PubOrderExamNocheckinDeptBS
'*        Description:	檢查醫令不須報到部門維護作業
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Jun
'*        Create Date:	2016-06-30
'*      Last Modifier:	Jun
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
Imports Syscom.Comm.TableFactory


Public Class PubOrderExamNocheckinDeptBS

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubOrderExamNocheckinDeptBS
    Public Shared Function GetInstance() As PubOrderExamNocheckinDeptBS
        If myInstance Is Nothing Then
            myInstance = New PubOrderExamNocheckinDeptBS
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "
    Dim tableName As String = PubOrderExamNocheckinDeptDataTableFactory.tableName

#End Region

#Region "     新增 Method "

#End Region

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "

#Region " 取得門急住個別的不需報到科別 "

    ''' <summary>
    ''' 取得門急住個別的不需報到科別
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Public Function getInitialOrderExamNoCheckinDept(ByVal orderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strBuilder As New StringBuilder

            'O
            strBuilder.AppendLine("select  ")
            strBuilder.AppendLine("A.Dept_Code, ")
            strBuilder.AppendLine("isnull(A.Section_Id,'') as Section_Id, ")
            strBuilder.AppendLine("A.Dept_Sect_Name, ")
            strBuilder.AppendLine("ISNULL(B.Order_Code,'') as Order_Code, ")
            strBuilder.AppendLine("'O' as Kind_Id  ")
            strBuilder.AppendLine("from PUB_Dept_Sect A ")
            strBuilder.AppendLine("Left Join  PUB_Order_Exam_Nocheckin_Dept B ")
            strBuilder.AppendLine("on ( A.dept_code=B.Dept_Code and A.Section_Id=B.Section_Id and B.Kind_Id='O'and B.Order_Code=@Order_Code) ")
            strBuilder.AppendLine("where A.dc='N' ; ")
            'E
            strBuilder.AppendLine("select  ")
            strBuilder.AppendLine("A.Dept_Code, ")
            strBuilder.AppendLine("'' as Section_Id,  ")
            strBuilder.AppendLine("A.Dept_Name, ")
            strBuilder.AppendLine("ISNULL(B.Order_Code,'') as Order_Code, ")
            strBuilder.AppendLine("'E' as Kind_Id  ")
            strBuilder.AppendLine("from PUB_Department A ")
            strBuilder.AppendLine("Left Join  PUB_Order_Exam_Nocheckin_Dept B ")
            strBuilder.AppendLine("on (A.dept_code=B.Dept_Code  and B.Kind_Id='E' and B.Order_Code=@Order_Code) ")
            strBuilder.AppendLine("where A.dc='N' and A.Is_Emg_Dept='Y'; ")
            'I
            strBuilder.AppendLine("select  ")
            strBuilder.AppendLine("A.Dept_Code, ")
            strBuilder.AppendLine("'' as Section_Id,  ")
            strBuilder.AppendLine("A.Dept_Name, ")
            strBuilder.AppendLine("ISNULL(B.Order_Code,'') as Order_Code, ")
            strBuilder.AppendLine("'I' as Kind_Id  ")
            strBuilder.AppendLine("from PUB_Department A ")
            strBuilder.AppendLine("Left Join  PUB_Order_Exam_Nocheckin_Dept B ")
            strBuilder.AppendLine("on (A.dept_code=B.Dept_Code  and B.Kind_Id='I' and B.Order_Code=@Order_Code) ")
            strBuilder.AppendLine("where A.dc='N' and A.Is_Ipd_Dept='Y';  ")
            command.CommandText = strBuilder.ToString
            command.Parameters.AddWithValue("@Order_Code", orderCode)
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

#Region "     取得 DB 在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 DB 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>by Jun on 2016-06-30</remarks>
    Public Function getConnection() As IDbConnection

        '自行設定正確的Connection 字串
        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class

