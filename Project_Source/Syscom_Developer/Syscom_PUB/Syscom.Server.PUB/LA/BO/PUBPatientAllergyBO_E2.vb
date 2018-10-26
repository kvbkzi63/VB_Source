'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBPatientAllergyBO_E2.vb
'*              Title:	
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	jianhui
'*        Create Date:	2009/10/14
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

Public Class PUBPatientAllergyBO_E2
    Inherits PubPatientAllergyBO

    Private Shared myInstance As PUBPatientAllergyBO_E2

    Public Overloads Function getInstance() As PUBPatientAllergyBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPatientAllergyBO_E2()
        End If
        Return myInstance
    End Function

    ''' <summary>
    ''' 匯入藥物過敏資料：
    ''' </summary>
    ''' <param name="strREFCHARTNO">病歷號碼</param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBPatientAllergyByREFCHARTNO(ByVal strREFCHARTNO As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataTable
        Dim Mycommand As SqlClient.SqlCommand = Nothing
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim resultTable As DataTable
            Dim strSql As New StringBuilder
            strSql.Append(" SELECT PA.Allergy_Kind_Id, PA.Allergy_Item, PA.Allergy_Severity, ")
            strSql.Append(" PA.Allergy_Reaction, S.Code_Name, PA.Allergy_Date  ")
            strSql.Append("   FROM PUB_Patient_Allergy PA, PUB_Syscode S ")
            strSql.Append(" Where 1=1 AND S.Type_Id = '29' AND S.Code_Id = PA.Allergy_Reaction ")

            If strREFCHARTNO.Trim <> "" Then
                strSql.Append(" AND PA.Chart_No  = '").Append(strREFCHARTNO).Append("' ")
            End If

            Mycommand = New SqlCommand(strSql.ToString, CType(conn, SqlConnection))
            strSql.Length = 0
            Dim MyAdapter As SqlDataAdapter = New SqlDataAdapter(Mycommand)
            resultTable = New DataTable
            resultTable.TableName = "PUB_Patient_Allergy"
            MyAdapter.FillSchema(resultTable, SchemaType.Source)
            MyAdapter.Fill(resultTable)
            Return resultTable
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
#Region "20100625 過敏史查詢 add by liuye"
    Function queryPUBPatientAllergyByWithChartNo(ByVal strChartNo As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As New StringBuilder

            strSql.Append(" ").Append(" select Allergy_Item, Allergy_Date from PUB_Patient_Allergy  ").Append(vbCrLf)
            strSql.Append(" ").Append(" where Chart_No = @Chart_No and Cancel = 'N'   ").Append(vbCrLf)
            strSql.Append(" ").Append(" order by Allergy_Date     ").Append(vbCrLf)

            command.CommandText = strSql.ToString
            command.Parameters.AddWithValue("@Chart_No", strChartNo)
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
        End Try
    End Function
#End Region
   
End Class
