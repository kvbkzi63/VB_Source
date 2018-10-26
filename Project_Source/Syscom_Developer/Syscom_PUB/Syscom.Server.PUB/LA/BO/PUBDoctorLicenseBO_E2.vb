'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBDoctorLicenseBO_E2.vb
'*              Title:	醫師書
'*        Description:	醫師書
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	mark zhang
'*        Create Date:	2011/10/09
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

Public Class PUBDoctorLicenseBO_E2
    'Inherits PubDoctorLicenseBO
    Private Shared myInstance As PUBDoctorLicenseBO_E2
    Dim tableName As String = "PUBDoctorLicense"
    Public Overloads Function getInstance() As PUBDoctorLicenseBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBDoctorLicenseBO_E2()
        End If
        Return myInstance
    End Function

    ''' <summary>
    '''查詢醫師書
    ''' </summary>
    ''' <returns>查詢資料全部資料內容</returns>
    ''' <remarks></remarks>
    Public Function queryPUBDoctorLicenseByEmployeeCode(ByVal EmployeeCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
            End If

            Dim content As New StringBuilder()
            'content.Append(" select  License_No  ").Append(vbCrLf)
            'content.Append(" from PUB_Doctor_License  ").Append(vbCrLf)
            'content.Append(" where Employee_Code = @Employee_Code  ").Append(vbCrLf)
            'content.Append(" and License_Dept_Code = 'A1'  ").Append(vbCrLf)
            'content.Append(" and License_Effect_Date <= @Date  ").Append(vbCrLf)
            'content.Append(" and License_End_Date >=@Date  ").Append(vbCrLf)
            'content.Append("   ").Append(vbCrLf)

            '2013-03-26 Modify By Alan - 醫師證書改查詢FPW202K表格
            content.Append(" Select  paperno AS License_No  ").Append(vbCrLf)
            content.Append(" From FPW202K  ").Append(vbCrLf)
            content.Append(" Where Wcode Like '%' +'" & EmployeeCode & "' and kind = '01'  ").Append(vbCrLf)

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = content.ToString

            command.Parameters.AddWithValue("@Employee_Code", EmployeeCode)
            command.Parameters.AddWithValue("@Date", Now.ToString("yyyy/MM/dd"))

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
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
    '''取得資料庫連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function

End Class


