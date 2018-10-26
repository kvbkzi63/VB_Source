'/*
'*****************************************************************************
'*
'*    Page/Class Name:  費用項目對應檔-BO
'*              Title:	PUBAccountBO_E2
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
Imports System.Text
Imports Syscom.Server.BO



Public Class PUBAccountBO_E2
    Inherits PubAccountBO

#Region "     使用的Instance宣告 "
    Public Shared ReadOnly tableNamePubsyscode As String = "PUB_SYSCODE"

    Private Shared myInstance As PUBAccountBO_E2
    Public Overloads Shared Function GetInstance() As PUBAccountBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBAccountBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     新增 Method "

#End Region

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strAccountId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBAccountByCond(ByVal strAccountId As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" ").Append(" Select A.*,B.Code_Name as Account_Name,")
        strSql.Append(" ").Append(" C.Code_Name as Receipt_Account_Name,")
        strSql.Append(" ").Append(" D.Code_Name as Insu_Account_Name,")
        strSql.Append(" ").Append(" E.Code_Name as Acc1_Account_Name,")
        strSql.Append(" ").Append(" F.Code_Name as Acc2_Account_Name ")
        strSql.Append(" ").Append("from")
        strSql.Append(" ").Append(tableName).Append("  A  ")
        strSql.Append(" ").Append("left join")
        strSql.Append(" ").Append(tableNamePubsyscode)
        strSql.Append(" ").Append(" B on (A.Account_Id=B.Code_Id and B.Type_Id=41 )")
        strSql.Append(" ").Append("left join")
        strSql.Append(" ").Append(tableNamePubsyscode)
        strSql.Append(" ").Append(" C on (A.Receipt_Account_Id=C.Code_Id and C.Type_Id=42 )")
        strSql.Append(" ").Append("left join")
        strSql.Append(" ").Append(tableNamePubsyscode)
        strSql.Append(" ").Append(" D on (A.Insu_Account_Id=D.Code_Id and D.Type_Id=43 )")
        strSql.Append(" ").Append("left join")
        strSql.Append(" ").Append(tableNamePubsyscode)
        strSql.Append(" ").Append(" E on (A.Acc1_Account_Id=E.Code_Id and E.Type_Id=44 )")
        strSql.Append(" ").Append("left join")
        strSql.Append(" ").Append(tableNamePubsyscode)
        strSql.Append(" ").Append(" F on (A.Acc2_Account_Id=F.Code_Id and F.Type_Id=45 )")
        strSql.Append(" ").Append(" Where 1=1 ")
        If strAccountId.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Account_Id ='").Append(strAccountId.Trim).Append("' ")
        End If
        strSql.Append(" ").Append("Order By A.Account_Id")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function

#End Region

End Class

