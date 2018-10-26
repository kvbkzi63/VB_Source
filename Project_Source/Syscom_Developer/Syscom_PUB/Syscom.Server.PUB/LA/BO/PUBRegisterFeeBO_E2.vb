'/*
'*****************************************************************************
'*
'*    Page/Class Name:  掛號費基本檔維護
'*              Title:	PUBRegisterFeeBO_E2
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

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Server.CMM
Imports System.Text



Public Class PUBRegisterFeeBO_E2
    Inherits PubRegisterFeeBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBRegisterFeeBO_E2
    Public Overloads Shared Function GetInstance() As PUBRegisterFeeBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBRegisterFeeBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     查詢 Method "
    ''' <summary>
    ''' 查詢掛號費基本檔資料
    ''' </summary>
    ''' <param name="strSubIdentityCode"></param>
    ''' <param name="strDeptCode"></param>
    ''' <param name="strMedicalTypeId"></param>
    ''' <param name="strOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBRegisterFeeByCond(ByVal pk_Source_Id As String, ByVal strSubIdentityCode As String, ByVal strDeptCode As String, ByVal strMedicalTypeId As String, ByVal strOrderCode As String, ByVal strSectionId As String, ByVal strFirstReg As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("SELECT A.*,")
        strSql.Append(" ").Append("B.Sub_Identity_Name AS Sub_Identity_Name, ")
        strSql.Append(" ").Append("C.Code_Name AS Medical_Type_Id_Name, ")
        strSql.Append(" ").Append("D.Dept_Name AS Dept_Code_Name, ")
        strSql.Append(" ").Append("E.Order_Name AS Order_Code_Name,F.Code_Name AS Section_Id_Name ")
        strSql.Append(" ").Append("FROM ")
        strSql.Append(" ").Append(tableName + " A")
        strSql.Append(" ").Append("LEFT JOIN PUB_SUB_IDENTITY B ON A.Sub_Identity_Code=B.Sub_Identity_Code ")
        strSql.Append(" ").Append("LEFT JOIN PUB_SYSCode C ON A.Medical_Type_Id=C.Code_Id AND C.Type_Id = '20' ")
        strSql.Append(" ").Append("LEFT JOIN PUB_Department D ON A.Dept_Code=D.Dept_Code ")
        strSql.Append(" ").Append("LEFT JOIN PUB_Order E ON A.Order_Code=E.Order_Code and E.Dc = 'N' ")
        strSql.Append(" ").Append("LEFT JOIN PUB_SYSCode F ON A.Section_Id=F.Code_Id AND F.Type_Id = '11' ")
        strSql.Append(" ").Append("WHERE 1=1 ")
        If pk_Source_Id.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Source_Id ='" + pk_Source_Id + "'")
        End If
        If strSubIdentityCode.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Sub_Identity_Code ='" + strSubIdentityCode + "'")
        End If

        If strDeptCode.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Dept_Code ='" + strDeptCode + "'")
        End If

        If strMedicalTypeId.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Medical_Type_Id ='" + strMedicalTypeId + "'")
        End If

        If strOrderCode.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Order_Code ='" + strOrderCode + "'")
        End If

        If strSectionId.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Section_Id ='" + strSectionId + "'")
        End If
        If strFirstReg.Trim <> "" Then
            strSql.Append(" ").Append("AND A.First_Reg ='" + strFirstReg + "'")
        End If
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)

            End Using
        Catch ex As Exception
            'LOGDelegate.getInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function


#End Region

End Class

