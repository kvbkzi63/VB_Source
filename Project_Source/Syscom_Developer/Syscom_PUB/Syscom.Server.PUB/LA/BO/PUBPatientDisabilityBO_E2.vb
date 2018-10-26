'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患殘障記錄檔
'*              Title:	PUBPatientDisabilityBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2015-09-18
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2015-09-18
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



Public Class PUBPatientDisabilityBO_E2
    Inherits PubPatientDisabilityBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPatientDisabilityBO_E2
    Public Overloads Shared Function GetInstance() As PUBPatientDisabilityBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPatientDisabilityBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "
    ''' <summary>
    ''' 查詢病患殘障記錄檔
    ''' </summary>
    ''' <param name=" strChartNo">病歷號</param>
    ''' <param name=" strEffectDate">生效日</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function queryPUBPatientDisabilityByCond(ByVal strChartNo As String, ByVal strEffectDate As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("select A.Chart_No, A.Patient_Disability_No,             ")
        strSql.Append(" ").Append("convert(char(10),A.Effect_Date,111) as Effect_Date,     ")
        strSql.Append(" ").Append("convert(char(10),A.End_Date,111) as End_Date,           ")
        strSql.Append(" ").Append("A.Disability_Degree_Id,A.Disability_Type_Id,            ")
        strSql.Append(" ").Append("A.Patient_Disability_Memo,                              ")
        strSql.Append(" ").Append("B.Code_Name As Disability_Type_Name,                    ")
        strSql.Append(" ").Append("C.Code_Name As Disability_Degree_Name,                  ")
        strSql.Append(" ").Append("D.Patient_Name                                          ")
        strSql.Append(" ").Append("from PUB_Patient_Disability A                           ")
        strSql.Append(" ").Append("left join PUB_SYSCode B                                 ")
        strSql.Append(" ").Append("on A.Disability_Type_Id=B.Code_Id and B.Type_Id='212'   ")
        strSql.Append(" ").Append("left join PUB_SYSCode C                                 ")
        strSql.Append(" ").Append("on A.Disability_Degree_Id=C.Code_Id and C.Type_Id='214' ")
        strSql.Append(" ").Append("left join PUB_Patient D                                 ")
        strSql.Append(" ").Append("on A.Chart_No=D.Chart_No                                ")
        strSql.Append(" ").Append("where 1=1 ")
        If strChartNo <> "" Then
            strSql.Append(" ").Append(" and A.Chart_No = '" & strChartNo & "' ")
        End If
        If strEffectDate <> "" Then
            strSql.Append(" ").Append(" and A.Effect_Date <= '" & strEffectDate & "' ")
            strSql.Append(" ").Append(" and A.End_Date >= '" & strEffectDate & "' ")
        End If
        strSql.Append(" ").Append("Order By  A.Chart_No Asc, A.Effect_Date Asc")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                ' adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    '''  取序號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryMaxPatientDisabilityNo(ByVal strChartNo As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As New StringBuilder
            strSql.Append(" ").Append(" select case when max(Patient_Disability_No) is null ").Append(vbCrLf)
            strSql.Append(" ").Append(" then 1 ").Append(vbCrLf)
            strSql.Append(" ").Append("else MAX(Patient_Disability_No)+1 ").Append(vbCrLf)
            strSql.Append(" ").Append("end as Patient_Disability_No ").Append(vbCrLf)
            strSql.Append(" ").Append("from PUB_Patient_Disability  ").Append(vbCrLf)
            strSql.Append(" ").Append(" where Chart_No=@Chart_No ")
            command.CommandText = strSql.ToString()
            command.Parameters.AddWithValue("@Chart_No", strChartNo)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(sqlex.ToString)
            Throw sqlex
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    '''以病歷號and生效日期刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function deleteByCond(ByRef strChartNo As System.String, ByRef strEffectDate As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try

            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Chart_No=@Chart_No and Effect_Date <= @Effect_Date  " & _
            " and End_Date >= @Effect_Date "

            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Chart_No", strChartNo)
                command.Parameters.AddWithValue("@Effect_Date", strEffectDate)
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

#Region "     新增 Method "

#End Region
#Region "     修改 Method "

#End Region

End Class

