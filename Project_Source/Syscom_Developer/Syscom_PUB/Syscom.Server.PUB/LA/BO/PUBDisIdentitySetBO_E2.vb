'/*
'*****************************************************************************
'*
'*    Page/Class Name:  優待身份折扣設定檔
'*              Title:	PUBDisIdentitySetBO_E2
'*        Description:	優待身份折扣設定檔
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2015-08-31
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2015-08-31
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO



Public Class PUBDisIdentitySetBO_E2
    Inherits PubDisIdentitySetBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBDisIdentitySetBO_E2
    Public Overloads Shared Function GetInstance() As PUBDisIdentitySetBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBDisIdentitySetBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "
    Public Shared ReadOnly tableName1 As String = "PUB_Dis_Identity"
    Public Shared ReadOnly tableName2 As String = "PUB_SYSCODE"
    Public Shared ReadOnly tableName3 As String = "PUB_Sub_Identity"
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
    ''' <param name="dateEffectDate"></param>
    ''' <param name="strDisIdentityCode"></param>
    ''' <param name="strOrderTypeId"></param>
    ''' <param name="strAccountId"></param>
    ''' <param name="strOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBDisIdentitySetByCond(ByVal dateEffectDate As Date, ByVal strSubIdentityCode As String, ByVal strDisIdentityCode As String, ByVal strOrderTypeId As String, ByRef strAccountId As String, ByRef strOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As Data.DataSet = New DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As New StringBuilder
            strSql.Append(" ").Append(" Select substring(dbo.AdToRocTime(A.Effect_Date),0,10) as Effect_Date,")
            strSql.Append(" ").Append("        A.Sub_Identity_Code,")
            strSql.Append(" ").Append("        A.Dis_Identity_Code,")
            strSql.Append(" ").Append("        A.Order_Type_Id,")
            strSql.Append(" ").Append("        A.Account_Id,")
            strSql.Append(" ").Append("        A.Order_Code,")
            strSql.Append(" ").Append("        A.Discount_Ratio,")
            strSql.Append(" ").Append("        A.Dc,")
            strSql.Append(" ").Append("        substring(dbo.AdToRocTime(A.End_Date),0,10) as End_Date,")
            strSql.Append(" ").Append("        A.Create_User,")
            strSql.Append(" ").Append("        substring(dbo.AdToRocTime(A.Create_Time),0,10) as Create_Time,")
            strSql.Append(" ").Append("        A.Modified_User,")
            strSql.Append(" ").Append("        substring(dbo.AdToRocTime(A.Modified_Time),0,10) as Modified_Time,")
            strSql.Append(" ").Append("        A.Is_Payself_Flag,")
            strSql.Append(" ").Append("  E.Sub_Identity_Name as Sub_Identity_Name, B.Dis_Identity_Name as Dis_Identity_Name,")
            strSql.Append(" ").Append(" C.Code_Name as Order_Type_Name,D.Code_Name as Account_Name ")
            strSql.Append(" ").Append("from")
            strSql.Append(" ").Append(tableName).Append("  A  ")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(tableName3)
            strSql.Append(" ").Append(" E on (A.Sub_Identity_Code = E.Sub_Identity_Code and E.Dc='N')")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(tableName1)
            strSql.Append(" ").Append(" B on (A.Dis_Identity_Code = B.Dis_Identity_Code and B.Dc='N')")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(tableName2)
            strSql.Append(" ").Append(" C on (A.Order_Type_Id = C.Code_Id and C.Type_Id=31)")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(tableName2)
            strSql.Append(" ").Append(" D on (A.Account_Id = D.Code_Id and D.Type_Id=41)")
            strSql.Append(" ").Append("where 1=1 ")
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                strSql.Append(" ").Append("and A.Effect_Date= @Effect_Date ")
            End If
            If strSubIdentityCode <> "" Then
                strSql.Append(" ").Append("and A.Sub_Identity_Code= @Sub_Identity_Code ")
            End If
            If strDisIdentityCode <> "" Then
                strSql.Append(" ").Append("and A.Dis_Identity_Code =@Dis_Identity_Code ")
            End If
            If strOrderTypeId <> "" Then
                strSql.Append(" ").Append("and A.Order_Type_Id =@Order_Type_Id ")
            End If
            If strAccountId <> "" Then
                strSql.Append(" ").Append("and A.Account_Id =@Account_Id ")
            End If
            If strOrderCode <> "" Then
                strSql.Append(" ").Append("and A.Order_Code =@Order_Code ")
            End If
            strSql.Append(" ").Append("order by A.Effect_Date, A.Dis_Identity_Code, A.Order_Type_Id, A.Account_Id, Order_Code")
            command.CommandText = strSql.ToString

            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                command.Parameters.AddWithValue("@Effect_Date", dateEffectDate)
            End If
            command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
            If Not strDisIdentityCode.Equals("") Then
                command.Parameters.AddWithValue("@Dis_Identity_Code", strDisIdentityCode)
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

End Class

