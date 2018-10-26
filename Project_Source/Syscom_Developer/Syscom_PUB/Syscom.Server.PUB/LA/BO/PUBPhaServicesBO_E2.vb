'/*
'*****************************************************************************
'*
'*    Page/Class Name:  藥事服務費基本檔
'*              Title:	PUBPhaServicesBO_E2
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



Public Class PUBPhaServicesBO_E2
    Inherits PubPhaServicesBO

#Region "     使用的Instance宣告 "
    Public Shared ReadOnly tableName1 As String = "PUB_Pha_Services"

    Private Shared myInstance As PUBPhaServicesBO_E2
    Public Overloads Shared Function GetInstance() As PUBPhaServicesBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPhaServicesBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "
    ''' <summary>
    ''' 查詢藥事服務費基本檔
    ''' </summary>
    ''' <param name="strMainIdentityId"></param>
    ''' <param name="strDeptCode"></param>
    ''' <param name="strPhaServicesTypeId"></param>
    ''' <param name="strOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBPhaServicesByCond(ByVal strMainIdentityId As String, ByVal strDeptCode As String, ByVal strPhaServicesTypeId As String, ByVal strOrderCode As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("SELECT A.Main_Identity_Id,")
        strSql.Append(" ").Append("       A.Dept_Code,")
        strSql.Append(" ").Append("       A.Pha_Services_Type_Id,")
        strSql.Append(" ").Append("       A.Order_Code,")
        strSql.Append(" ").Append("       A.Dc,")
        strSql.Append(" ").Append("       A.Create_User,")
        strSql.Append(" ").Append("       substring(dbo.AdToRocTime(A.Create_Time),0,10) as Create_Time,")
        strSql.Append(" ").Append("       A.Modified_User,")
        strSql.Append(" ").Append("       substring(dbo.AdToRocTime(A.Modified_Time),0,10) as Modified_Time,")
        strSql.Append(" ").Append("B.Code_Name AS Main_Identity_Id_Value,")
        strSql.Append(" ").Append("C.Code_Name AS Pha_Services_Type_Id_Value,")
        strSql.Append(" ").Append("D.Dept_Name AS Dept_Code_Value,")
        strSql.Append(" ").Append("E.Order_Name AS Order_Code_Value")
        strSql.Append(" ").Append("FROM")
        strSql.Append(" ").Append(tableName1 + " A")
        strSql.Append(" ").Append("LEFT JOIN PUB_SYSCode B ON A.Main_Identity_Id=B.Code_Id AND B.Type_Id = '18'")
        strSql.Append(" ").Append("LEFT JOIN PUB_SYSCode C ON A.Pha_Services_Type_Id=C.Code_Id AND C.Type_Id = '507'")
        strSql.Append(" ").Append("LEFT JOIN PUB_Department D ON A.Dept_Code=D.Dept_Code")
        strSql.Append(" ").Append("LEFT JOIN PUB_Order E ON A.Order_Code=E.Order_Code and E.Dc = 'N' ")
        strSql.Append(" ").Append("WHERE 1=1")

        If strMainIdentityId.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Main_Identity_Id='" + strMainIdentityId + "'")
        End If

        If strDeptCode.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Dept_Code='" + strDeptCode + "'")
        End If

        If strPhaServicesTypeId.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Pha_Services_Type_Id='" + strPhaServicesTypeId + "'")
        End If

        If strOrderCode.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Order_Code='" + strOrderCode + "'")
        End If
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            ' LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function

#End Region

End Class

