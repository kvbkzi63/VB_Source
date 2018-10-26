'/*
'*****************************************************************************
'*
'*    Page/Class Name:  部位檔維護
'*              Title:	PUBBodySiteBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-15
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-15
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



Public Class PUBBodySiteBO_E2
    Inherits PubBodySiteBO
    Public Shared ReadOnly tableName1 As String = "PUB_SYSCODE"

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBBodySiteBO_E2
    Public Overloads Shared Function GetInstance() As PUBBodySiteBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBBodySiteBO_E2
        End If
        Return myInstance
    End Function

#End Region

    ''' <summary>
    ''' 查詢部位檔
    ''' </summary>
    ''' <param name="strBodySiteCode">部位代碼</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>部位代碼</remarks>
    Public Overloads Function queryPUBBodySiteByCond(ByVal strBodySiteCode As String) As System.Data.DataSet
        'Public Overloads Function queryPUBBodySiteByCond(ByVal strBodySiteCode As String, ByVal strBodySiteName As String, ByVal strMainBodySiteCode As String, ByVal strNhiBodySiteCoded As String, ByVal strDc As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        strSql.Append("Select A.Body_Site_Code, A.Body_Site_Name,A.Main_Body_Site_Code,A.Dc,")
        strSql.Append(" A.Create_User,A.Create_Time,A.Modified_User,A.Modified_Time From ")
        strSql.Append(tableName)
        strSql.Append(" A  Where  1=1 ")
        If strBodySiteCode.Trim <> "" Then
            strSql.Append(" AND A.Body_Site_Code = '").Append(strBodySiteCode).Append("' ")
        End If
        'If strBodySiteName.Trim <> "" Then
        '    strSql.Append(" AND A.Body_Site_Name like '").Append(strBodySiteName).Append("%' ")
        'End If
        'If strMainBodySiteCode.Trim <> "" Then
        '    strSql.Append(" AND A.Main_Body_Site_Code = '").Append(strMainBodySiteCode).Append("' ")
        'End If
        'If strNhiBodySiteCoded.Trim <> "" Then
        '    strSql.Append(" AND A.Nhi_Body_Site_Code = '").Append(strNhiBodySiteCoded).Append("' ")
        'End If
        'If strDc.Trim <> "" Then
        '    strSql.Append(" AND A.Dc = '").Append(strDc).Append("' ")
        'End If
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

    Public Overloads Function queryMainBodySiteCodeByCond(ByVal strBodySiteCode As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        'strSql.Append("Select A.Body_Site_Code, A.Body_Site_Name,A.Main_Body_Site_Code,A.Dc,")
        'strSql.Append(" A.Nhi_Body_Site_Code,B.Code_Name,")
        'strSql.Append(" A.Create_User,A.Create_Time,A.Modified_User,A.Modified_Time From ")
        'strSql.Append(tableName)
        'strSql.Append(" A left join  ").Append(tableName1).Append(" B on (A.Nhi_Body_Site_Code=B.Code_Id AND B.Type_Id=115) ")
        'strSql.Append(" Where  1=1 ")
        'If strBodySiteCode.Trim <> "" Then
        '    strSql.Append(" AND A.Body_Site_Code = '").Append(strBodySiteCode).Append("' ")
        'End If
        strSql.Append("Select distinct Body_Site_Code, Body_Site_Name From ")
        strSql.Append(tableName)
        strSql.Append(" Where  Body_Site_Code = Main_Body_Site_Code")
        'If strBodySiteCode.Trim <> "" Then
        '    strSql.Append(" AND Body_Site_Code <> '").Append(strBodySiteCode).Append("' ")
        'End If
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


#Region "     2016/06/28 部位(PUBBodySiteBO_E2) by Remote  "
    ''' <summary>
    ''' 側位
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function PUBBodySiteBodyparts() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select distinct RTRIM(Body_Site_Code) as Body_Site_Code, RTRIM(Body_Site_Name) as Body_Site_Name ")
            content.Append(" From PUB_Body_Site")
            content.Append(" Where   DC='N' ")
            command.CommandText = content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Body_Site")
                adapter.Fill(ds, "PUB_Body_Site")
                adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Body_Site")
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class

