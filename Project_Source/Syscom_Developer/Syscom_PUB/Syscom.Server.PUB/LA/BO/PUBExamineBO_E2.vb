'/*
'*****************************************************************************
'*
'*    Page/Class Name:  診察費基本檔BO
'*              Title:	PUBExamineBO_E2
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



Public Class PUBExamineBO_E2
    Inherits PubExamineBO

#Region "     使用的Instance宣告 "
    Public Shared ReadOnly pubSyscodeTableName As String = "PUB_SYSCODE"
    Public Shared ReadOnly pubSubIdentityTableName As String = "PUB_Sub_Identity"
    Public Shared ReadOnly pubDepartmentTableName As String = "PUB_Department"
    Public Shared ReadOnly pubOrderTableName As String = "PUB_Order"
    Private Shared myInstance As PUBExamineBO_E2
    Public Overloads Shared Function GetInstance() As PUBExamineBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBExamineBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     新增 Method "

#End Region

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "
    ''' <summary>
    ''' 依傳入保險別(身份1)代碼,初診,院內科別代碼,診察費類別,就醫類型,醫令項目代碼取得有效診察費相關資料
    ''' </summary>
    ''' <param name="strSubIdentityId">身份二代碼</param>
    ''' <param name="strFirstReg">初診</param>
    ''' <param name="strDeptCode">院內科別代碼</param>
    ''' <param name="strSectionId">診別</param>
    ''' <param name="strExamineTypeId">診察費類別</param>
    ''' <param name="strMedicalTypeId">就醫類型</param>
    ''' <param name="strOrderCode">醫令項目代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBExamineByCond(ByVal strSubIdentityId As String, ByVal strFirstReg As String, _
                                                    ByVal strDeptCode As String, ByVal strSectionId As String, _
                                                    ByVal strExamineTypeId As String, ByVal strMedicalTypeId As String, _
                                                    ByVal strOrderCode As String) As System.Data.DataSet

        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("Select A.Sub_Identity_Code,")
        strSql.Append(" ").Append("       A.First_Reg,")
        strSql.Append(" ").Append("       A.Dept_Code,")
        strSql.Append(" ").Append("       A.Section_Id,")
        strSql.Append(" ").Append("       A.Medical_Type_Id,")
        strSql.Append(" ").Append("       A.Examine_Type_Id,")
        strSql.Append(" ").Append("       A.Order_Code,")
        strSql.Append(" ").Append("       A.Dc,")
        strSql.Append(" ").Append("       A.Create_User,")
        strSql.Append(" ").Append("       substring(dbo.AdToRocTime(A.Create_Time),0,10) as  Create_Time,")
        strSql.Append(" ").Append("       A.Modified_User,")
        strSql.Append(" ").Append("       substring(dbo.AdToRocTime(A.Modified_Time),0,10) as  Modified_Time,")
        strSql.Append(" ").Append("B.Sub_Identity_Name as Sub_Identity_Name,")
        strSql.Append(" ").Append("C.Dept_Name,")
        strSql.Append(" ").Append("D.Code_Name as Examine_Type_Id_Name,")
        strSql.Append(" ").Append("E.Order_Name,")
        strSql.Append(" ").Append("F.Code_Name as Section_Id_Name")
        strSql.Append(" ").Append(",G.Medical_Type_Name as Medical_Type_Id_Name")
        strSql.Append(" ").Append("From")
        strSql.Append(" ").Append(tableName).Append(" A ")
        strSql.Append(" ").Append("left join")
        strSql.Append(" ").Append(pubSubIdentityTableName).Append(" B on (A.Sub_Identity_Code = B.Sub_Identity_Code)")
        strSql.Append(" ").Append("left join")
        strSql.Append(" ").Append(pubDepartmentTableName).Append(" C on (A.Dept_Code = C.Dept_Code)")
        strSql.Append(" ").Append("left join")
        strSql.Append(" ").Append(pubSyscodeTableName).Append(" D on (A.Examine_Type_Id = D.Code_Id AND D.Type_Id = '508')")
        strSql.Append(" ").Append("left join")
        strSql.Append(" ").Append(pubOrderTableName).Append(" E on (A.Order_Code = E.Order_Code and E.Dc = 'N')")
        strSql.Append(" ").Append("left join")
        strSql.Append(" ").Append(pubSyscodeTableName).Append(" F on (A.Section_Id = F.Code_Id AND F.Type_Id = '11')")
        strSql.Append(" ").Append("left join")
        strSql.Append(" ").Append("PUB_Medical_Type").Append(" G on A.Medical_Type_Id = G.Medical_Type_Id")
        strSql.Append(" ").Append("Where 1=1 ")

        If strSubIdentityId.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Sub_Identity_Code = '").Append(strSubIdentityId.Trim).Append("' ")
        End If

        If strDeptCode.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Dept_Code = '").Append(strDeptCode.Trim).Append("' ")
        End If

        If strSectionId.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Section_Id = '").Append(strSectionId.Trim).Append("' ")
        End If

        If strExamineTypeId.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Examine_Type_Id = '").Append(strExamineTypeId.Trim).Append("' ")
        End If

        If strFirstReg.Trim <> "" Then
            strSql.Append(" ").Append("AND A.First_Reg = '").Append(strFirstReg.Trim).Append("' ")
        End If

        If strMedicalTypeId.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Medical_Type_Id = '").Append(strMedicalTypeId.Trim).Append("' ")
        End If

        If strOrderCode.Trim <> "" Then
            strSql.Append(" ").Append("AND A.Order_Code = '").Append(strOrderCode.Trim).Append("' ")
        End If

        strSql.Append(" ").Append("Order By A.Sub_Identity_Code,A.First_Reg,A.Dept_Code,A.Section_Id,A.Examine_Type_Id,A.Medical_Type_Id")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                'adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function

#End Region

End Class

