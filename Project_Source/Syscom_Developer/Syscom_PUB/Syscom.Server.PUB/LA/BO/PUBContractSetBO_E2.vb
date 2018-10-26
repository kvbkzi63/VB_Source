'/*
'*****************************************************************************
'*
'*    Page/Class Name:  合約身份折扣記帳設定檔維護
'*              Title:	PUBContractSetBO_E2
'*        Description:	合約身份折扣記帳設定檔維護
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
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports System.Text



Public Class PUBContractSetBO_E2
    Inherits PubContractSetBO
    Dim tableName1 As String = "PUB_Contract"
    Dim tableName2 As String = "PUB_SYSCode"
    Dim tableName3 As String = "PUB_Order"
    Dim tableName4 As String = "PUB_Sub_Identity"
#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBContractSetBO_E2
    Public Overloads Shared Function GetInstance() As PUBContractSetBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBContractSetBO_E2
        End If
        Return myInstance
    End Function

#End Region
    ''' <summary>
    ''' 根據生效日 合約機關代碼 醫令類型 院內費用項目 醫令項目代碼取得所有資料
    ''' </summary>
    ''' <param name="dateEffectDate"></param>
    ''' <param name="strContractCode"></param>
    ''' <param name="strSubIdentityCode"></param>
    ''' <param name="strOrderTypeId"></param>
    ''' <param name="strAccountId"></param>
    ''' <param name="strOrderCode"></param>
    ''' <param name="isNullQuerySubIdentityCode">True:按空字串查詢  False：不作為必要查詢條件</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBContractSetByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderTypeId As String, ByVal strAccountId As String, ByVal strOrderCode As String, ByVal isNullQuerySubIdentityCode As Boolean, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select A.*, B.Contract_Name , C.Code_Name as Order_Code_Name ,D.Code_Name as Account_Code_Name, E.Order_Name,F.Sub_Identity_Name from ")
            content.Append(" ").Append(tableName)
            content.Append(" ").Append("A left join ")
            content.Append(" ").Append(tableName1)
            content.Append(" ").Append("B on A.Contract_Code = B.Contract_Code and A.Sub_Identity_Code = B.Sub_Identity_Code")
            content.Append(" ").Append(" left join ")
            content.Append(" ").Append(tableName2)
            content.Append(" ").Append("C on (A.Order_Type_Id = C.Code_Id and C.Type_id =31 ) ")
            content.Append(" ").Append(" left join ")
            content.Append(" ").Append(tableName2)
            content.Append(" ").Append("D on (A.Account_Id = D.Code_Id and D.Type_id =41 ) ")
            content.Append(" ").Append(" left join ")
            content.Append(" ").Append(tableName3)
            content.Append(" ").Append("E on (A.Order_Code = E.Order_Code and E.Dc = 'N') ")
            content.Append(" ").Append(" left join ")
            content.Append(" ").Append(tableName4)
            content.Append(" ").Append("F on (A.Sub_Identity_Code = F.Sub_Identity_Code AND F.Dc ='N') ")
            content.Append(" where 1=1 ")
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                content.Append("and ").Append("A.Effect_Date =@Effect_Date ")
            End If
            If Not strContractCode.Equals("") Then
                content.Append("and ").Append("A.Contract_Code =@Contract_Code ")
            End If
            If Not strOrderTypeId.Equals("") Then
                content.Append("and ").Append("A.Order_Type_Id =@Order_Type_Id ")
            End If
            If Not strAccountId.Equals("") Then
                content.Append("and ").Append("A.Account_Id =@Account_Id ")
            End If
            If Not strOrderCode.Equals("") Then
                content.Append("and ").Append("A.Order_Code =@Order_Code ")
            End If
            If isNullQuerySubIdentityCode = True Then
                content.Append("and ").Append("A.Sub_Identity_Code =@Sub_Identity_Code ")
            Else
                If Not strSubIdentityCode.Equals("") Then
                    content.Append("and ").Append("A.Sub_Identity_Code =@Sub_Identity_Code ")
                End If
            End If
            content.Append("order by A.Contract_Code,A.Effect_Date,A.Sub_Identity_Code")
            command.CommandText = content.ToString
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                command.Parameters.AddWithValue("@Effect_Date", dateEffectDate)
            End If
            If Not strContractCode.Equals("") Then
                command.Parameters.AddWithValue("@Contract_Code", strContractCode)
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
            If isNullQuerySubIdentityCode = True Then
                command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
            Else
                If Not strSubIdentityCode.Equals("") Then
                    command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
                End If
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                'adapter.FillSchema(ds, SchemaType.Mapped, tableName)
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

#Region "門診健檢套餐報價作業 click 定價頁簽-刪除button or shift+f12"

    ''' <summary>
    ''' 門診健檢套餐報價作業 Click 定價頁簽-刪除button or shift+f12 查詢
    ''' </summary>
    ''' <param name="strEffectDate"></param>
    ''' <param name="strContractCode"></param>
    ''' <param name="strSubIdentityCode"></param>
    ''' <param name="strOrderCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBContractSet0(ByVal strEffectDate As String, _
                                         ByVal strContractCode As String, _
                                         ByVal strSubIdentityCode As String, _
                                         ByVal strOrderCode As String, _
                                         Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As StringBuilder = New StringBuilder()

            strSql.Append(" ").Append("  select *                                 ")
            strSql.Append(" ").Append("  from PUB_Contract_Set                    ")
            strSql.Append(" ").Append("  where Effect_Date=@Effect_Date           ")
            strSql.Append(" ").Append("  and Contract_Code=@Contract_Code         ")
            strSql.Append(" ").Append("  and Sub_Identity_Code=@Sub_Identity_Code ")
            strSql.Append(" ").Append("  and (Order_Code=@Order_Code              ")
            strSql.Append(" ").Append("       or Order_Type_Id in (select Order_Type_Id from OHM_Bottom_Dis_Set) ")
            strSql.Append(" ").Append("       or Account_Id in (select Account_Id from OHM_Bottom_Dis_Set) ")
            strSql.Append(" ").Append("       or Order_Code in (select Order_Code from OHM_Bottom_Dis_Set) ")
            strSql.Append(" ").Append("       ) ")

            command.CommandText = strSql.ToString
            command.Parameters.AddWithValue("@Effect_Date", strEffectDate)
            command.Parameters.AddWithValue("@Contract_Code", strContractCode)
            command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
            command.Parameters.AddWithValue("@Order_Code", strOrderCode)

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

    ''' <summary>
    ''' 門診健檢套餐報價作業 click 定價頁簽-刪除button or shift+f12
    ''' </summary>
    ''' <param name="dateEffectDate"></param>
    ''' <param name="strContractCode"></param>
    ''' <param name="strSubIdentityCode"></param>
    ''' <param name="strOrderCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deletePubContractSet(ByVal dateEffectDate As String, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Effect_Date=@Effect_Date and Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code and " & _
            " (Order_Code=@Order_Code or Order_Type_Id in (select Order_Type_Id from OHM_Bottom_Dis_Set) " & _
            " or Account_Id in (select Account_Id from OHM_Bottom_Dis_Set) " & _
            " or Order_Code in (select Order_Code from OHM_Bottom_Dis_Set))"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Effect_Date", dateEffectDate)
                command.Parameters.AddWithValue("@Contract_Code", strContractCode)
                command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)

                command.Parameters.AddWithValue("@Order_Code", strOrderCode)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region

    ''' <summary>
    '''門診健檢套餐報價作業  Click 加作折扣設定頁籤-加作折扣設定Grid-刪除(X) Button
    ''' </summary>
    ''' <param name="strEffectDate"></param>
    ''' <param name="strContractCode"></param>
    ''' <param name="strSubIdentityCode"></param>
    ''' <param name="strOrderTypeId"></param>
    ''' <param name="strAccountId"></param>
    ''' <param name="strOrderCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deletePubContractSet1(ByVal strEffectDate As String, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderTypeId As String, ByVal strAccountId As String, ByVal strOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Effect_Date=@Effect_Date and Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code and " & _
            " Order_Type_Id=@Order_Type_Id and Account_Id=@Account_Id and Order_Code=@Order_Code "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Effect_Date", strEffectDate)
                command.Parameters.AddWithValue("@Contract_Code", strContractCode)
                command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
                command.Parameters.AddWithValue("@Order_Type_Id", strOrderTypeId)
                command.Parameters.AddWithValue("@Account_Id", strAccountId)
                command.Parameters.AddWithValue("@Order_Code", strOrderCode)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
    ''' <summary>
    ''' 門診健檢套餐報價作業 Click 加作折扣設定頁籤- 存檔Button or F10
    ''' </summary>
    ''' <param name="strEffectDate"></param>
    ''' <param name="strContractCode"></param>
    ''' <param name="strSubIdentityCode"></param>
    ''' <param name="strOrderCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBContractSet(ByVal strEffectDate As String, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As StringBuilder = New StringBuilder()
            strSql.Append(" ").Append("  select count(1) as count        ")
            strSql.Append(" ").Append("  from PUB_Contract_Set           ")
            strSql.Append(" ").Append("   where Effect_Date=@Effect_Date")
            strSql.Append(" ").Append("   and Contract_Code=@Contract_Code         ")
            strSql.Append(" ").Append("   and Sub_Identity_Code=@Sub_Identity_Code     ")
            'modified by mark zhang 2011/03/24 begin
            'strSql.Append(" ").Append("    and Order_Code<>@Order_Code            ")
            strSql.Append(" ").Append("    and Order_Code not in (select Charge_Code from ohm_package_set where Contract_Code=@Contract_Code2 and Sub_Identity_Code=@Sub_Identity_Code2)            ")
            'modified by mark zhang 2011/03/24 end
            command.CommandText = strSql.ToString
            command.Parameters.AddWithValue("@Effect_Date", strEffectDate)
            command.Parameters.AddWithValue("@Contract_Code", strContractCode)
            command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
            command.Parameters.AddWithValue("@Contract_Code2", strContractCode)
            command.Parameters.AddWithValue("@Sub_Identity_Code2", strSubIdentityCode)
            'command.Parameters.AddWithValue("@Order_Code", strOrderCode) 'delete by mark zhang 2011/03/24 begin
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
    ''' <summary>
    ''' 門診健檢套餐報價作業 Click 加作折扣設定頁籤- 全部刪除Button or Shift+F12
    ''' </summary>
    ''' <param name="dateEffectDate"></param>
    ''' <param name="strContractCode"></param>
    ''' <param name="strSubIdentityCode"></param>
    ''' <param name="strOrderCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deletePubContractSet2(ByVal dateEffectDate As String, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Effect_Date=@Effect_Date and Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code and " & _
           "Order_Code<>@Order_Code"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Effect_Date", dateEffectDate)
                command.Parameters.AddWithValue("@Contract_Code", strContractCode)
                command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
                command.Parameters.AddWithValue("@Order_Code", strOrderCode)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 門診健檢套餐報價作業 Click 直接delete原本存在pub_contract_set的資料 (但是不可delete套餐的批價代碼)
    ''' </summary>
    ''' <param name="dateEffectDate"></param>
    ''' <param name="strContractCode"></param>
    ''' <param name="strSubIdentityCode"></param>
    ''' <param name="strOrderCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deletePubContractSet3(ByVal dateEffectDate As String, ByVal strContractCode As String, ByVal strSubIdentityCode As String, ByVal strOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            'modified by mark zhang 2011/03/24 begin
            ' Dim sqlString As String = "delete from " & tableName & " where " & _
            ' " Effect_Date=@Effect_Date and Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code and " & _
            '"Order_Code<>@Order_Code"
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Effect_Date=@Effect_Date and Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code and " & _
            " Order_Code not in (select Charge_Code from ohm_package_set where Contract_Code=@Contract_Code2 and Sub_Identity_Code=@Sub_Identity_Code2)"
            'modified by mark zhang 2011/03/24 end
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Effect_Date", dateEffectDate)
                command.Parameters.AddWithValue("@Contract_Code", strContractCode)
                command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
                'add by mark zhang 2011/03/24 begin
                command.Parameters.AddWithValue("@Contract_Code2", strContractCode)
                command.Parameters.AddWithValue("@Sub_Identity_Code2", strSubIdentityCode)
                'add by mark zhang 2011/03/24 end
                'command.Parameters.AddWithValue("@Order_Code", strOrderCode) 'delete by mark zhang 2011/03/24 begin
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
    ''' <summary>
    ''' 門診健檢套餐報價作業 Click加作折扣設定頁籤- 查詢Button or F3
    ''' </summary>
    ''' <param name="strEffectDate"></param>
    ''' <param name="strContractCode"></param>
    ''' <param name="strSubIdentityCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBContractSet2(ByVal strEffectDate As String, ByVal strContractCode As String, ByVal strSubIdentityCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As StringBuilder = New StringBuilder()
            strSql.Append(" ").Append(" select rtrim(B.Code_Id)+'-'+B.Code_Name as Order_Type_Name,    ")
            strSql.Append(" ").Append("rtrim(C.Code_Id)+'-'+C.Code_Name as Account_Name,               ")
            strSql.Append(" ").Append("A.Order_Code ,                                           ")
            strSql.Append(" ").Append("D.Order_Name ,                                           ")
            strSql.Append(" ").Append("'' as Discount_Ratio1,                                   ")
            strSql.Append(" ").Append("A.Discount_Ratio                                         ")
            strSql.Append(" ").Append("from PUB_Contract_Set A                                  ")
            strSql.Append(" ").Append("left outer join PUB_Syscode B on B.Type_Id=31            ")
            strSql.Append(" ").Append("and A.Order_Type_Id=B.Code_Id                            ")
            strSql.Append(" ").Append("left outer join PUB_Syscode C on C.Type_Id=41            ")
            strSql.Append(" ").Append("and A.Account_Id=C.Code_Id                               ")
            strSql.Append(" ").Append("left outer join PUB_Order D on A.Order_Code=D.Order_Code ")
            strSql.Append(" ").Append("and A.Effect_Date between D.Effect_Date                  ")
            strSql.Append(" ").Append("and D.End_Date                                           ")
            strSql.Append(" ").Append("where A.Effect_Date=@Effect_Date                                   ")
            strSql.Append(" ").Append("and A.Contract_Code=@Contract_Code                                   ")
            strSql.Append(" ").Append("and A.Sub_Identity_Code=@Sub_Identity_Code                               ")
            command.CommandText = strSql.ToString
            command.Parameters.AddWithValue("@Effect_Date", strEffectDate)
            command.Parameters.AddWithValue("@Contract_Code", strContractCode)
            command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
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


End Class

