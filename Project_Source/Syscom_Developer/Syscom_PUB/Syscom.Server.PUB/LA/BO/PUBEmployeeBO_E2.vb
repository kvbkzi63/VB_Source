'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBEmployeeBO_E2.vb
'*              Title:	
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Johsn
'*        Create Date:	2009/07/23
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions
Imports Syscom.Comm.TableFactory
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.SQL
Imports System.Reflection


Public Class PUBEmployeeBO_E2
    Inherits PubEmployeeBO
    Private Shared myInstance As PUBEmployeeBO_E2

    Public Overloads Function getInstance() As PUBEmployeeBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBEmployeeBO_E2()
        End If
        Return myInstance
    End Function

#Region "20090724 查詢批價項目作業  當strKindId='1'時取得看診醫師資料來源 by Add Johsn"
    ''' <summary>
    ''' 取得看診醫師資料來源
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBEmployeeCode(ByVal strKindId As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select RTRIM(Employee_Code) as Employee_Code, RTRIM(Employee_Name) as Employee_Name, RTRIM(Employee_En_Name) as Employee_En_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where  Professal_Kind_Id ='" & strKindId.Trim & "'")
            content.Append(" and Assume_Effect_Date <= GETDATE() and Assume_End_Date >= GETDATE()   ")
            content.Append(" Order By Employee_Code")
            command.CommandText = content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "20090724 取得登錄人員信息 by Add Ming"
    ''' <summary>
    ''' 取得登錄人員信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBEmployeeByCode(ByVal EmployeeCode As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select A.Employee_Code, A.Employee_Name, A.Employee_En_Name ,A.Dept_Code,B.Dept_Name , A.Acc_Dept  ")
            content.Append(" From " & tableName)
            content.Append(" A left join PUB_Department B on (A.Dept_Code=B.Dept_Code) ")
            content.Append("  Where  Employee_Code ='" & EmployeeCode & "'")
            content.Append(" Order By Employee_Code")
            command.CommandText = content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "20090918 取得全院員工信息 by Add tony"
    ''' <summary>
    ''' 取得全院員工信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBEmployeeByall() As DataSet
        'Try
        '    Dim ds As DataSet
        '    Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
        '    Dim command As SqlCommand = sqlConn.CreateCommand()
        '    Dim content As StringBuilder = New StringBuilder()
        '    content.Append(" Select Employee_Code, Employee_Name ")
        '    content.Append(" From " & tableName)
        '    content.Append(" Order By Employee_Code ")
        '    command.CommandText = content.ToString
        '    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
        '        ds = New DataSet(tableName)
        '        adapter.Fill(ds, tableName)
        '        adapter.FillSchema(ds, SchemaType.Mapped, tableName)
        '    End Using
        '    Return ds
        'Catch sqlex As SqlException
        '    Throw sqlex
        'Catch ex As Exception
        '    Throw ex
        'End Try
        Dim ds As Data.DataSet
        Dim strSql As StringBuilder = New StringBuilder()
        strSql.Append(" ").Append("Select Employee_Code, Employee_Name")
        strSql.Append(" ").Append("From")
        strSql.Append(" ").Append(tableName)
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)

            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds
    End Function
#End Region
#Region "20091012 查詢 醫師名稱  當工作時間在strReferralOutDate 時 取得看診醫師資料來源 by Add Tor"
    ''' <summary>
    ''' 取得看診醫師資料來源
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBEmployeeCodeByReferralOutDate_L(ByVal strCode As String, ByVal strReferralOutDate As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            '20130815 by ccr 因發現有些傳入之 strCode 為醫師代號故修正
            If strCode.Length < 6 Then
                content.Append("SELECT E.Employee_Name " & vbCrLf)
                content.Append("FROM   PUB_doctor d " & vbCrLf)
                content.Append("       LEFT JOIN pub_employee e " & vbCrLf)
                content.Append("         ON d.Employee_Code = e.Employee_Code " & vbCrLf)
                content.Append("WHERE  d.Doctor_Code = '" & strCode.Trim & "' " & vbCrLf)
                content.Append("       AND d.Announce_Effect_Date <= '" & strReferralOutDate.Trim & "' " & vbCrLf)
                content.Append("       AND d.Announce_End_Date >= '" & strReferralOutDate.Trim & "' " & vbCrLf)
                content.Append("       AND E.Assume_Effect_Date <= '" & strReferralOutDate.Trim & "' " & vbCrLf)
                content.Append("       AND E.Assume_End_Date >= '" & strReferralOutDate.Trim & "' ")
            Else
                content.Append(" SELECT E.Employee_Name FROM PUB_Employee E   ")
                content.Append(" Where  E.Employee_Code ='" & strCode.Trim & "' ")
                content.Append(" AND E.Assume_Effect_Date <='" & strReferralOutDate.Trim & "' ")
                content.Append(" AND E.Assume_End_Date >='" & strReferralOutDate.Trim & "' ")
            End If
            'content.Append(" SELECT E.Employee_Name FROM PUB_Employee E   ")
            'content.Append(" Where  E.Employee_Code ='" & strCode.Trim & "' ")
            'content.Append(" AND E.Assume_Effect_Date <='" & strReferralOutDate.Trim & "' ")
            'content.Append(" AND E.Assume_End_Date >='" & strReferralOutDate.Trim & "' ")
            command.CommandText = content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "20110303 依登入的ID(操作人員)取得員工信息 by Add Runxia"
    ''' <summary>
    ''' 取得全院員工信息
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBEmployeeByID(ByVal strEmployeeCode As String) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As StringBuilder = New StringBuilder()
        strSql.Append(" ").Append("Select *")
        strSql.Append(" ").Append("From")
        strSql.Append(" ").Append(tableName)
        strSql.Append(" ").Append("where (Dept_Code like 'M5%' or Dept_Code like 'A5%')")
        strSql.Append(" ").Append("and Employee_Code='" & strEmployeeCode & "'")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return ds
    End Function
#End Region

End Class
