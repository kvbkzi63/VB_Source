'/*
'*****************************************************************************
'*
'*    Page/Class Name:	OMOOrderDiagnosisBO_E2.vb
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

Public Class PUBOrderPriceBO_E2
    Inherits PUBOrderPriceBO_E1
    Public Shared ReadOnly OmoOrderDiagnosisTableName As String = "PUB_Order_Price"
    Private Shared myInstance As PUBOrderPriceBO_E2
    Public Overloads Shared Function GetInstance() As PUBOrderPriceBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBOrderPriceBO_E2()
        End If
        Return myInstance
    End Function

    ''' <summary>
    ''' 項目健保碼
    ''' </summary>
    ''' <param name="strEffectDate"></param>
    ''' <param name="strOrderCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBOrderPriceByCode(ByVal strEffectDate As String, ByVal strOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataTable
        Dim Mycommand As SqlClient.SqlCommand = Nothing
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If

            Dim resultTable As DataTable
            Dim strSql As New StringBuilder
            strSql.Append("  SELECT Insu_Code FROM PUB_Order_Price ")
            strSql.Append(" WHERE 1=1 AND Main_Identity_Id = 2 ")

            If strOrderCode.Trim <> "" Then
                strSql.Append(" AND Order_Code = '").Append(strOrderCode).Append("' ")
            End If

            If strEffectDate.Trim <> "" Then
                strSql.Append(" AND Effect_Date <=  '").Append(strEffectDate).Append("' ")
                strSql.Append(" AND End_Date  >  '").Append(strEffectDate).Append("' ")
            End If

            Mycommand = New SqlCommand(strSql.ToString, CType(conn, SqlConnection))
            strSql.Length = 0
            Dim MyAdapter As SqlDataAdapter = New SqlDataAdapter(Mycommand)
            resultTable = New DataTable
            resultTable.TableName = "PUB_Order_Price"
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

#Region "20160628 PUBOrderBO 取得取得費用 by Remote"

    ''' <summary>
    ''' 查詢醫令項目基本檔  Dc = 'N'  
    ''' </summary>
    ''' <param name="inParam"></param>
    ''' <returns>DataSet</returns>
    Public Function PUBOrderPrice(ByVal inParam() As String) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        ' Select Order_Name From PUB_Order where DC='N' And Order_Code= @ Material_No
        strSql.Append(" Select Price From PUB_Order_Price  ")
        strSql.Append("  WHERE  Dc = 'N'   ")
        strSql.Append("  AND Order_Code = '" & inParam(0) & "'")


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
