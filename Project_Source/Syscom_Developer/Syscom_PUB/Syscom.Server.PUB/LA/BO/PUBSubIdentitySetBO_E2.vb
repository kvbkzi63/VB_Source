'/*
'*****************************************************************************
'*
'*    Page/Class Name:  身份二代碼計價設定檔維護
'*              Title:	PUBSubIdentitySetBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-04
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-04
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.BO
Imports System.Text



Public Class PUBSubIdentitySetBO_E2
    Inherits PubSubIdentitySetBO

#Region "     使用的Instance宣告 "

    Public Shared ReadOnly pubSubIdentityTableName As String = "PUB_SUB_IDENTITY"
    Public Shared ReadOnly pubSyscodeTableName As String = "PUB_SYSCODE"
    Public Shared ReadOnly pubOrderTableName As String = "PUB_ORDER"
    Private Shared myInstance As PUBSubIdentitySetBO_E2
    Public Overloads Shared Function GetInstance() As PUBSubIdentitySetBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBSubIdentitySetBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     新增 Method "
    ''' <summary>
    ''' 根據生效日、身份二代碼、醫令類型、院內費用項目、醫令項目代碼取得所有資料
    ''' </summary>
    ''' <param name="dateEffectDate"></param>
    ''' <param name="strSubIdentityCode"></param>
    ''' <param name="strOrderTypeId"></param>
    ''' <param name="strAccountId"></param>
    ''' <param name="strOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBSubIdentitySetByCond(ByVal dateEffectDate As Date, ByVal strSubIdentityCode As String, _
                                                           ByVal strOrderTypeId As String, ByVal strAccountId As String, _
                                                           ByVal strOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As StringBuilder = New StringBuilder()

            strSql.Append(" ").Append("Select A.Effect_Date,A.Sub_Identity_Code,A.Order_Type_Id,A.Account_Id,")
            strSql.Append(" ").Append("A.Order_Code,A.Main_Identity_Id,A.End_Date,")
            strSql.Append(" ").Append("A.Dc,A.Create_User,A.Create_Time,A.Modified_User,A.Modified_Time,")
            strSql.Append(" ").Append("B.Sub_Identity_Name,")
            strSql.Append(" ").Append("C.Code_Name as Order_Type_Name,")
            strSql.Append(" ").Append("D.Code_Name as Account_Name,")
            strSql.Append(" ").Append("E.Order_Name,")
            strSql.Append(" ").Append("F.Code_Name as Main_Identity_Name")
            strSql.Append(" ").Append("From")
            strSql.Append(" ").Append(tableName).Append(" A ")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(pubSubIdentityTableName).Append(" B on (A.Sub_Identity_Code = B.Sub_Identity_Code) AND B.DC = 'N'")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(pubSyscodeTableName).Append(" C on (A.Order_Type_Id = C.Code_Id AND C.Type_Id = '31')")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(pubSyscodeTableName).Append(" D on (A.Account_Id = D.Code_Id AND D.Type_Id = '41')")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(pubOrderTableName).Append(" E on (A.Order_Code = E.Order_Code and E.Dc <> 'Y')")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(pubSyscodeTableName).Append(" F on (A.Main_Identity_Id = F.Code_Id AND F.Type_Id = '18')")
            strSql.Append(" ").Append("Where 1=1 ")

            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                strSql.Append(" ").Append("And A.Effect_Date =@Effect_Date ")
            End If
            If Not strSubIdentityCode.Equals("") Then
                strSql.Append(" ").Append("And A.Sub_Identity_Code =@Sub_Identity_Code ")
            End If
            If Not strOrderTypeId.Equals("") Then
                strSql.Append(" ").Append("And A.Order_Type_Id =@Order_Type_Id ")
            End If
            If Not strAccountId.Equals("") Then
                strSql.Append(" ").Append("And A.Account_Id =@Account_Id ")
            End If
            If Not strOrderCode.Equals("") Then
                strSql.Append(" ").Append("And A.Order_Code =@Order_Code ")
            End If
            strSql.Append(" ").Append("Order By A.Effect_Date,A.Sub_Identity_Code,A.Order_Type_Id,A.Account_Id,A.Order_Code ")

            command.CommandText = strSql.ToString

            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                command.Parameters.AddWithValue("@Effect_Date", dateEffectDate)
            End If
            If Not strSubIdentityCode.Equals("") Then
                command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
            End If
            If Not strOrderTypeId.Equals("") Then
                command.Parameters.AddWithValue("@Order_Type_Id", strOrderTypeId)
            End If
            If Not strAccountId.Equals("") Then
                command.Parameters.AddWithValue("@Account_Id", strAccountId)
            End If
            If Not strOrderCode.Equals("") Then
                command.Parameters.AddWithValue("@Order_Code", strOrderCode)
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

#Region "     修改 Method "

#End Region

End Class

