'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患殘障記錄檔
'*              Title:	PUBPtDisabilityBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-09
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-09
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports Syscom.Server.BO

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports System.Text



Public Class PUBPtDisabilityBO_E2
    Inherits PubPatientDisabilityBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBPtDisabilityBO_E2
    Public Overloads Shared Function GetInstance() As PUBPtDisabilityBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPtDisabilityBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "
    ''' <summary>
    ''' 查詢病患殘障記錄檔
    ''' </summary>
    ''' <param name=" pk_Chart_No">病歷號</param>
    ''' <param name=" pk_Patient_Disability_No">序號</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function queryPUBPtDisabilityByCond_L(ByVal pk_Chart_No As String, ByVal pk_Patient_Disability_No As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("select A.Chart_No, A.Patient_Disability_No,             ")
        strSql.Append(" ").Append("substring(dbo.AdToRocTime(A.Effect_Date),0,10) as Effect_Date,     ")
        strSql.Append(" ").Append("substring(dbo.AdToRocTime(A.End_Date),0,10) as End_Date,           ")
        strSql.Append(" ").Append("A.Disability_Degree_Id,A.Disability_Type_Id,            ")
        strSql.Append(" ").Append("A.Patient_Disability_Memo,                              ")
        strSql.Append(" ").Append("A.Create_User,                                          ")
        strSql.Append(" ").Append("substring(dbo.AdToRocTime(A.Create_Time),0,10) as Create_Time,                                          ")
        strSql.Append(" ").Append("A.Modified_User,                                        ")
        strSql.Append(" ").Append("substring(dbo.AdToRocTime(A.Modified_Time),0,10) as Modified_Time,                                        ")
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
        If pk_Chart_No <> "" Then
            strSql.Append(" ").Append(" and A.Chart_No = '" & pk_Chart_No & "' ")
        End If
        If pk_Patient_Disability_No <> "" Then
            strSql.Append(" ").Append(" and A.Patient_Disability_No = " & CInt(pk_Patient_Disability_No) & " ")
        End If
        strSql.Append(" ").Append("Order By  A.Chart_No Asc, A.Patient_Disability_No Asc")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                ' adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            '  LOGDelegate.getInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function


#End Region

End Class

