'/*
'*****************************************************************************
'*
'*    Page/Class Name:  特定醫師加成控制檔維護
'*              Title:	PubDrAddControlBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Hsu-Yuan,Ynag
'*        Create Date:	2017-04-13
'*      Last Modifier:	Yang,Hsu-Yuan
'*   Last Modify Date:	2017-04-13
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Imports Syscom.Server.BO


Public Class PubDrAddControlBO_E1
    Inherits PubDrAddControlBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubDrAddControlBO_E1
    Public Overloads Shared Function GetInstance() As PubDrAddControlBO_E1
        If myInstance Is Nothing Then
            myInstance = New PubDrAddControlBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "
    
#End Region

#Region "     修改 Method "
    
#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "
    ''' <summary>
    ''' 查詢(依PKey傳入值進行複合查詢，若傳入值皆為空，則全查)
    ''' </summary>
    ''' <param name="deptCode" >院內看診科別</param>
    ''' <param name="orderCode" >醫令碼</param>
    ''' <param name="employeeCode" >醫師代號</param>
    ''' <returns>查詢DataSet結果</returns>
    ''' <remarks>by Hsu-Yuan,Yang on 2017-04-14</remarks>
    Public Function QueryPubDrAddControlByPK(ByRef deptCode As String, ByRef orderCode As String, ByRef employeeCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("SELECT PADC.Dept_Code,PD.Dept_Name, PADC.Order_Code, PO.Order_En_Name, PADC.Employee_Code, PE.Employee_Name,")
            content.AppendLine("       PADC.Dc, PADC.Create_User, PADC.Create_Time, dbo.adToRocTime(PADC.Create_Time) as Create_Time_ROC,")
            content.AppendLine("       PADC.Modified_User, PADC.Modified_Time, dbo.adToRocTime(PADC.Modified_Time) as Modified_Time_ROC")
            content.AppendLine(" FROM PUB_Dr_Add_Control PADC")
            content.AppendLine(" LEFT JOIN PUB_Department PD")
            content.AppendLine("   ON (PADC.Dept_Code = PD.Dept_Code)")
            content.AppendLine(" LEFT JOIN PUB_Order PO")
            content.AppendLine("   ON (PADC.Order_Code = PO.Order_Code)")
            content.AppendLine(" LEFT JOIN PUB_Employee PE")
            content.AppendLine("   ON (PADC.Employee_Code = PE.Employee_Code)")
            content.AppendLine(" WHERE 1 = 1")

            If deptCode.Trim() <> "" Then
                content.AppendLine("   AND PADC.Dept_Code=@Dept_Code")
                command.Parameters.AddWithValue("@Dept_Code", deptCode)
            End If

            If orderCode.Trim() <> "" Then
                content.AppendLine("   AND PADC.Order_Code=@Order_Code")
                command.Parameters.AddWithValue("@Order_Code", orderCode)
            End If

            If employeeCode.Trim() <> "" Then
                content.AppendLine("   AND PADC.Employee_Code=@Employee_Code")
                command.Parameters.AddWithValue("@Employee_Code", employeeCode)
            End If

            command.CommandText = content.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region

End Class