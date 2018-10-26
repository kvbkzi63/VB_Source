'/*
'*****************************************************************************
'*
'*    Page/Class Name:  部份負擔優待基本檔維護
'*              Title:	PUBPartDiscountBO_E2
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



Public Class PUBPartDiscountBO_E2
    Inherits PubPartDiscountBO
    Public Shared ReadOnly tableName1 As String = "PUB_Dis_Identity"
    Public Shared ReadOnly tableName2 As String = "PUB_Part"
    Public Shared ReadOnly tableName3 As String = "PUB_Sub_Identity"

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPartDiscountBO_E2
    Public Overloads Shared Function GetInstance() As PUBPartDiscountBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPartDiscountBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "
    ''' <summary>
    ''' 根據生效日和部份負擔代碼、優待身份取得所有資料
    ''' </summary>
    ''' <param name="dateEffectDate"></param>
    ''' <param name="strDisIdentityCode"></param>
    ''' <param name="strPartCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBPartDiscountByCond(ByVal dateEffectDate As Date, ByVal strDisIdentityCode As String, ByVal strPartCode As String, ByVal strSubIdentityCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim ds As Data.DataSet = New DataSet
            Dim strSql As New StringBuilder

            strSql.Append(" ").Append("Select A.Effect_Date,A.Dis_Identity_Code,A.Sub_Identity_Code,D.Sub_Identity_Name,")
            strSql.Append(" ").Append("A.Part_Code,A.Discount_Ratio,A.End_Date,")
            strSql.Append(" ").Append("A.Dc, A.Create_User, A.Create_Time,")
            strSql.Append(" ").Append("A.Modified_User,A.Modified_Time, ")
            strSql.Append(" ").Append("B.Dis_Identity_Name As Dis_Identity_Name ,")
            strSql.Append(" ").Append("C.Part_Name As Part_Name from")
            strSql.Append(" ").Append(tableName).Append(" A ")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(tableName1).Append(" B on (A.Dis_Identity_Code = B.Dis_Identity_Code ) ")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(tableName2).Append(" C on (A.Part_Code = C.Part_Code and C.DC = 'N' ) ")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(tableName3).Append(" D on (A.Sub_Identity_Code = D.Sub_Identity_Code and D.DC = 'N' ) ")
            strSql.Append(" ").Append("Where 1=1 ")
            If dateEffectDate <> System.DateTime.MinValue Then
                strSql.Append(" AND CONVERT(char(10),A.Effect_Date,111) ='").Append(dateEffectDate.ToString("yyyy/MM/dd")).Append("' ")
            End If
            If strDisIdentityCode.Trim <> "" Then
                strSql.Append(" ").Append("AND A.Dis_Identity_Code = '").Append(strDisIdentityCode.Trim).Append("' ")
            End If
            If strPartCode.Trim <> "" Then
                strSql.Append(" ").Append("AND A.Part_Code = '").Append(strPartCode.Trim).Append("' ")
            End If

            If strSubIdentityCode <> "" Then
                strSql.Append(" ").Append("AND A.Sub_Identity_Code = '").Append(strSubIdentityCode).Append("' ")
            End If
            strSql.Append(" ").Append("order by Part_Code,Effect_Date,Dis_Identity_Code,Sub_Identity_Code")

            Dim sqlConnection As SqlConnection = CType(conn, SqlConnection)
            'Using sqlConnection As SqlConnection = CType(conn, SqlConnection)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
            ds = New Data.DataSet(tableName)
            adapter.Fill(ds, tableName)
            adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            'End Using
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
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBPartByAll() As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("Select Part_Code,Part_Name from")
        strSql.Append(" ").Append(tableName2)
        strSql.Append(" ").Append("Where 1=1 ")
        strSql.Append(" ").Append("AND Effect_Date <= '").Append(Now.Date.ToString("yyyy-MM-dd")).Append("'")
        strSql.Append(" ").Append("AND End_Date >= '").Append(Now.Date.ToString("yyyy-MM-dd")).Append("'")
        strSql.Append(" ").Append("AND DC = 'N'")
        strSql.Append(" ").Append("order by Part_Code")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName2)
                adapter.Fill(ds, tableName2)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName2)
            End Using
        Catch ex As Exception
            'LOGDelegate.getInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function
#End Region

End Class

