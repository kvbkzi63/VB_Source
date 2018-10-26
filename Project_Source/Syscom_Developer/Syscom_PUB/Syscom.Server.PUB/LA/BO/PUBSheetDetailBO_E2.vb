'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBSheetDetailBO_E2.vb
'*              Title:	表單明細維護
'*        Description:	表單明細維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Yunfei
'*        Create Date:	2009/07/24
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports System.Text
Imports Syscom.Server.BO
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP

Public Class PUBSheetDetailBO_E2
    Inherits PubSheetDetailBO
    Private Shared myInstance As PUBSheetDetailBO_E2

    Public Overloads Function getInstance() As PUBSheetDetailBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBSheetDetailBO_E2()
        End If
        Return myInstance
    End Function


#Region "20090731 PUBSheetDetailBO 表單明細維護 , add by Mark"
    Public Shared ReadOnly pubOrderTableName As String = "PUB_ORDER"
#End Region


    ''' <summary>
    '''以表單代碼刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Function deletePUBSheetDetailBySheetCode(ByRef pk_Sheet_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Sheet_Code=@Sheet_Code  "
            Using conn2 As System.Data.IDbConnection = CType(conn, SqlConnection)
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn2, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Sheet_Code", pk_Sheet_Code)
                    conn.Open()
                    count = command.ExecuteNonQuery
                End Using
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#Region "20090731 PUBSheetDetailBO 表單明細維護 , add by Mark"
    Public Overloads Function queryPUBSheetDetailByCond(ByVal strSheetCode As String, ByVal blnAllFlag As Boolean, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As Data.DataSet = New DataSet
            Dim strSql As New StringBuilder

            'modified by mark 2010/02/02 begin
            strSql.Append(" ").Append("Select A.*,")
            'modified by mark 2010/02/02 end
            strSql.Append(" ").Append("B.Order_Name,B.Order_En_Name")
            strSql.Append(" ").Append("From")
            strSql.Append(" ").Append(tableName).Append(" A ")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(pubOrderTableName).Append(" B on (A.Order_Code = B.Order_Code AND ")
            strSql.Append(" ").Append("B.Order_Type_Id='H' AND B.DC<>'Y' ")
            strSql.Append(" ").Append("AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' >= B.Effect_Date ")
            strSql.Append(" ").Append("AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' <= B.End_Date ")
            strSql.Append(" ").Append(")")
            strSql.Append(" ").Append("Where 1=1 ")

            If strSheetCode.Trim <> "" Then
                strSql.Append(" ").Append("AND A.Sheet_Code = '").Append(strSheetCode.Trim).Append("' ")
            End If
            If Not blnAllFlag Then
                strSql.Append(" ").Append("AND A.DC = 'N' ")
            End If

            strSql.Append(" ").Append("Order By A.Sheet_Code,A.Order_Code")

            Using sqlConnection As SqlConnection = CType(conn, SqlConnection)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
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
#End Region
#Region "20091209 PUBSheetDetailBO 不可彙總醫令grid , add by tony"

    Public Function queryOrderCodeMerge(ByVal strSheetCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As Data.DataSet = New DataSet
            Dim strSql As New StringBuilder

            strSql.Append(" ").Append("select A.Sheet_Code,")
            strSql.Append(" ").Append("A .Order_Code ,")
            strSql.Append(" ").Append("CASE WHEN A.Order_Code  IN (SELECT B.Order_Code  FROM PUB_Sheet_Merge B )THEN 1 ELSE 0 END AS flag,")
            strSql.Append(" ").Append("C.Order_En_Name as Order_En_Name")
            strSql.Append(" ").Append("From")
            strSql.Append(" ").Append(tableName).Append(" A ")
            strSql.Append(" ").Append("left join PUB_Order as C ON A .Order_Code = C.Order_Code and C.Dc='N'")
            strSql.Append(" ").Append("Where 1=1 ")
            strSql.Append(" ").Append("and A.Dc ='N'")
            strSql.Append(" ").Append("and Sheet_Code in (" & strSheetCode & ")")
            strSql.Append(" ").Append(" order by A .Sheet_Code ")
            Using sqlConnection As SqlConnection = CType(conn, SqlConnection)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
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
#End Region
#Region "20100112 PUBSheetDetailBO 排成醫令維護 , add by coco"
    '依傳入保險別(身份1)代碼,院內科別代碼,診察費類別,醫令項目代碼取得有效診察費相關資料
    Public Overloads Function queryPUBSheetDetailByCond1(ByVal strSheetCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As Data.DataSet = New DataSet
            Dim strSql As New StringBuilder

            strSql.Append(" ").Append("Select A.Order_Code,B.Order_Name,A.Sheet_Code,A.Is_InstantlyRpt")
            strSql.Append(" ").Append("From")
            strSql.Append(" ").Append(tableName).Append(" A ")
            strSql.Append(" ").Append("left join")
            strSql.Append(" ").Append(pubOrderTableName).Append(" B on (A.Order_Code = B.Order_Code AND ")
            strSql.Append(" ").Append("B.DC<>'Y' ")
            strSql.Append(" ").Append("AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' >= B.Effect_Date ")
            strSql.Append(" ").Append("AND '").Append(Now().ToString("yyyy/MM/dd")).Append("' <= B.End_Date ")
            strSql.Append(" ").Append(")")
            strSql.Append(" ").Append("Where 1=1 ")
            'If strSheetCode.Trim <> "" Then
            '    strSql.Append(" ").Append("AND A.Sheet_Code = '").Append(strSheetCode.Trim).Append("' ")
            'End If
            strSql.Append(" ").Append("AND A.DC = 'N' ")
            strSql.Append(" ").Append("Order By A.Order_Code")

            Using sqlConnection As SqlConnection = CType(conn, SqlConnection)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
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
#End Region
End Class
