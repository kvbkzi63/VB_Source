'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患合約機構記帳累積檔
'*              Title:	PUBPatientQuotaBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-08
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-08
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



Public Class PUBPatientQuotaBO_E2
    Inherits PubPatientQuotaBO
    Public Shared ReadOnly tableName1 As String = "PUB_Contract"
    Public Shared ReadOnly tableName2 As String = "PUB_Sub_Identity"
#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPatientQuotaBO_E2
    Public Overloads Shared Function GetInstance() As PUBPatientQuotaBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPatientQuotaBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "

    ''' <summary>
    ''' 查詢病患合約機構記帳累積檔資料
    ''' </summary>
    ''' <param name="dateEffectDate">生效日期</param>
    ''' <param name="strContractCode">機構代碼</param>
    ''' <param name="strChartNo">病歷號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBPatientQuotaByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strChartNo As String, ByVal strSubIdentityCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As Data.DataSet = New DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As New StringBuilder

            strSql.Append(" ").Append(" Select A.*,B.Contract_Name as Contract_Name,")
            strSql.Append(" ").Append("C.Sub_Identity_Name as Sub_Identity_Name")
            strSql.Append(" ").Append("from")
            strSql.Append(" ").Append(tableName).Append("  A  ")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(tableName1)
            strSql.Append(" ").Append(" B on (A.Contract_Code = B.Contract_Code and A.Sub_Identity_Code=B.Sub_Identity_Code and B.Dc='N' and B.Check_Quota_Id='1')")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(tableName2)
            strSql.Append(" ").Append(" C on (A.Sub_Identity_Code = C.Sub_Identity_Code and C.Dc='N' )")
            strSql.Append(" ").Append("where 1=1 ")
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                strSql.Append(" ").Append("and A.Effect_Date= @Effect_Date ")
            End If
            If strContractCode <> "" Then
                strSql.Append(" ").Append("and A.Contract_Code =@Contract_Code ")
            End If
            If strChartNo <> "" Then
                strSql.Append(" ").Append("and A.Chart_No =@Chart_No ")
            End If
            If strSubIdentityCode <> "" Then
                strSql.Append(" ").Append("and A.Sub_Identity_Code =@Sub_Identity_Code ")
            End If
            strSql.Append(" ").Append("order by A.Effect_Date, A.Contract_Code, A.Chart_No,A.Sub_Identity_Code ")
            command.CommandText = strSql.ToString
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                command.Parameters.AddWithValue("@Effect_Date", dateEffectDate)
            End If
            If Not strContractCode.Equals("") Then
                command.Parameters.AddWithValue("@Contract_Code", strContractCode)
            End If
            If Not strChartNo.Equals("") Then
                command.Parameters.AddWithValue("@Chart_No", strChartNo)
            End If
            If Not strSubIdentityCode.Equals("") Then
                command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
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

    ''' <summary>
    ''' for PIPWriteQSPatientQuota(補助的週數)
    ''' </summary>
    ''' <param name="strChartNo"></param>
    ''' <param name="strvisitDate"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBPatientQuotaQuotaAmt(ByVal strChartNo As String, ByVal strvisitDate As String, ByVal strSubIdentityCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As Data.DataSet = New DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As New StringBuilder

            strSql.Append(" ").Append("select SUM(A.Quota_Amt)  as Quota_Amt_Sum ,B.Case_Apply_Stage").Append(vbCrLf)
            strSql.Append(" ").Append("from PUB_Patient_Quota A ").Append(vbCrLf)
            strSql.Append(" ").Append("inner join PIP_Case_Main B on A.Chart_No=B.Chart_No and B.Pip_Type='QS' ").Append(vbCrLf)
            strSql.Append(" ").Append(" and @visitDate between B.Case_Apply_Date and ISNULL(B.Case_Close_Date,DATEADD(d,90,B.Case_Apply_Date)) ").Append(vbCrLf)
            strSql.Append(" ").Append("and A.Effect_Date>=B.Case_Apply_Date ").Append(vbCrLf)
            strSql.Append(" ").Append("where A.Chart_No=@Chart_No and A.Effect_Date<>@visitDate and A.Contract_Code='ZZ01' and A.Sub_Identity_Code=@Sub_Identity_Code  group by B.Case_Apply_Stage ").Append(vbCrLf)

            strSql.Append(" ").Append("select top 1 min(DATEDIFF(d,A.Effect_Date,@visitDate)) as mindays ,C.Effect_Date from PUB_Patient_Quota A ").Append(vbCrLf)
            strSql.Append(" ").Append("inner join PIP_Case_Main B on A.Chart_No=B.Chart_No and B.Pip_Type='QS' ").Append(vbCrLf)
            strSql.Append(" ").Append("and @visitDate between B.Case_Apply_Date and ISNULL(B.Case_Close_Date,DATEADD(d,90,B.Case_Apply_Date))").Append(vbCrLf)
            strSql.Append(" ").Append("and A.Effect_Date>=B.Case_Apply_Date ").Append(vbCrLf)
            strSql.Append(" ").Append("inner join PUB_Patient_Quota C on A.Chart_No=C.Chart_No and A.Contract_Code=C.Contract_Code ").Append(vbCrLf)
            strSql.Append(" ").Append(" and A.Effect_Date=C.Effect_Date and A.Sub_Identity_Code=C.Sub_Identity_Code").Append(vbCrLf)
            strSql.Append(" ").Append("where A.Chart_No=@Chart_No and A.Effect_Date<@visitDate and A.Contract_Code='ZZ01' and A.Sub_Identity_Code=@Sub_Identity_Code ").Append(vbCrLf)
            strSql.Append(" ").Append("group by C.Effect_Date").Append(vbCrLf)
            strSql.Append(" ").Append("order by C.Effect_Date desc").Append(vbCrLf)

            strSql.Append(" ").Append("select Case_Apply_Date from PIP_Case_Main B").Append(vbCrLf)
            strSql.Append(" ").Append(" where  B.Chart_No =@Chart_No and B.Pip_Type='QS' ").Append(vbCrLf)
            strSql.Append(" ").Append(" and (@visitDate between B.Case_Apply_Date and ISNULL(B.Case_Close_Date,DATEADD(d,90,B.Case_Apply_Date))) ").Append(vbCrLf)

            command.CommandText = strSql.ToString

            command.Parameters.AddWithValue("@Chart_No", strChartNo)
            command.Parameters.AddWithValue("@visitDate", strvisitDate)
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



#End Region

End Class

