'/*
'*****************************************************************************
'*
'*    Page/Class Name:  優待身份基本檔維護
'*              Title:	PUBDisIdentityBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-11
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-11
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM



Public Class PUBDisIdentityBO_E2
    Inherits PubDisIdentityBO
    Dim tableName1 As String = "PUB_SYSCODE"

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBDisIdentityBO_E2
    Public Overloads Shared Function GetInstance() As PUBDisIdentityBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBDisIdentityBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "
    ''' <summary>
    ''' 獲取PUB_Dis_Identity資料
    ''' </summary>
    ''' <param name="DisIdentityCode">優待身份</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function queryPUBDisIdentityByCond(ByVal DisIdentityCode As String) As System.Data.DataSet
        Dim ds As DataSet
        Dim strSql As New StringBuilder
        strSql.Append("select A.Dis_Identity_Code ,A.Dis_Identity_Name, A.Dis_Identity_Type_Id, A.Is_Online_Choice, A.Dc, A.Create_User, A.Create_Time, A.Modified_User, A.Modified_Time, RTRIM(B.Code_Name) as Dis_Identity_Type_Name  From ")
        strSql.Append(tableName)
        strSql.Append(" AS A left  outer join  ").Append(tableName1).Append("  as B on (A.Dis_Identity_Type_Id = B.Code_Id and B.Type_Id = '49' )")

        strSql.Append(" Where 1=1 ")

        If DisIdentityCode.Trim <> "" Then
            strSql.Append(" AND Dis_Identity_Code = '").Append(DisIdentityCode).Append("' ")
        End If

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.getInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds

    End Function

#Region "2012/03/07 優待身分下拉選單查詢 add by liuye"
    Public Function QueryPubDisIdentityBOWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object(), Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select Dis_Identity_Code,Dis_Identity_Name  from " & tableName & " where 1=1 ")
            For i = 0 To columnName.Length - 1
                content.Append("and ").Append(columnName(i)).Append("=@").Append(columnName(i)).AppendLine(" ")
            Next
            command.CommandText = content.ToString
            For i = 0 To columnName.Length - 1
                command.Parameters.AddWithValue("@" & columnName(i), columnValue(i))
            Next
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

#End Region

End Class

