'/*
'*****************************************************************************
'*
'*    Page/Class Name:  非藥品替代醫令檔維護作業
'*              Title:	PUBOrderAlternativeBO_E2
'*        Description:	非藥品替代醫令檔維護作業
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Xiaozhi,Yu
'*        Create Date:	2016-09-23
'*      Last Modifier:	Xiaozhi,Yu
'*   Last Modify Date:	2016-09-23
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

Public Class PUBOrderAlternativeBO_E2
    Inherits PubOrderAlternativeBO

#Region "     使用的Instance宣告 "

    'Public Shared ReadOnly tableName As String = "DRG_MDC24_Diagnosis"
    'Private Shared myInstance As PUBInsuDeptSetupBO_E2
    'Public Shared Function GetInstance() As PUBInsuDeptSetupBO_E2
    '    If myInstance Is Nothing Then
    '        myInstance = New PUBInsuDeptSetupBO_E2
    '    End If
    '    Return myInstance
    'End Function
    Private Shared myInstance As PUBOrderAlternativeBO_E2
    Public Overloads Shared Function GetInstance() As PUBOrderAlternativeBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBOrderAlternativeBO_E2()
        End If
        Return myInstance
    End Function
#End Region

#Region "     查詢 Method "

#Region "     以PK查詢資料(醫令碼)"

    ''' <summary>
    ''' 以PK查詢資料(醫令碼)
    ''' </summary>
    ''' <remarks></remarks>
    Public Shadows Function queryByPKOrderCode(ByRef Order_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim Content As New StringBuilder
            Content.Append("SELECT A.Order_Code,B1.Order_En_Name " & vbCrLf)
            Content.Append("      ,Alternative_Code,B2.Order_En_Name " & vbCrLf)
            Content.Append("      ,A.Create_User " & vbCrLf)
            Content.Append("      ,CASE " & _
                           " WHEN Isdate(A.Create_Time) = 1 THEN CONVERT(VARCHAR(3), CONVERT(INT, Year(A.Create_Time)-1911))" & _
                                            " + '-'" & _
                                            " + Substring(CONVERT(CHAR(19), A.Create_Time, 120), 6, Len(A.Create_Time)-4)" & _
                                            " ELSE ''       END AS Create_Time_ROC " & vbCrLf)
            Content.Append("      ,A.Modified_User " & vbCrLf)
            Content.Append("      ,CASE " & _
                           " WHEN Isdate(A.Modified_Time) = 1 THEN CONVERT(VARCHAR(3), CONVERT(INT, Year(A.Modified_Time)-1911))" & _
                                            " + '-'" & _
                                            " + Substring(CONVERT(CHAR(19), A.Modified_Time, 120), 6, Len(A.Modified_Time)-4)" & _
                                            " ELSE ''       END AS Modified_Time_ROC " & vbCrLf)
            Content.Append("  FROM  PUB_Order_Alternative A " & vbCrLf)
            Content.Append("  LEFT JOIN PUB_Order B1 " & vbCrLf)
            Content.Append("  ON (A.Order_Code=B1.Order_Code ) " & vbCrLf)
            Content.Append("  LEFT JOIN PUB_Order B2 " & vbCrLf)
            Content.Append("  ON (A.Alternative_Code=B2.Order_Code AND B2.Dc='N') " & vbCrLf)
            If Order_Code.Length > 0 Then
                Content.AppendLine(" WHERE A.order_code = @order_code " & vbCrLf)
            End If

            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@order_code", Order_Code)

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

#End Region

#Region "     刪除 Method "

    ''' <summary>
    ''' 多筆刪除資料(勾選項目)
    ''' </summary>
    ''' <remarks></remarks>
    Public Function deleteChoose(ByVal dsDelete As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim countTemp As Integer = 0
            Dim sqlString As String = "delete from PUB_Order_Alternative where Order_Code=@Order_Code and Alternative_Code=@Alternative_Code "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In dsDelete.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                    command.Parameters.AddWithValue("@Alternative_Code", row.Item("Alternative_Code"))
                    countTemp = command.ExecuteNonQuery
                    count += countTemp
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB914", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region


#Region "          2017/1/16 非藥品替代醫令檔維護 add by Michelle"

#Region "   2017/1/16 非藥品替代醫令檔維護 add by Michelle"
    ''' <summary>
    ''' 非藥品替代醫令檔維護作業新增/修改 by Michelle 2017/1/16"
    ''' </summary>
    ''' <param name="dsData">PUBOrderAlternative</param>
    ''' <param name="conn"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Michelle on 2017/1/16</remarks>
    Public Function newPUBOrderByOrderCode(ByVal dsData As DataSet, ByVal actin As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim count As Integer = 0
        Dim connFlag As Boolean = conn Is Nothing
        Dim order_code As String = ""

        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using Scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

                order_code = StringUtil.nvl(dsData.Tables(0).Rows(0)("Order_Code"))

                If actin = "Insert" Then
                    count = PUBOrderAlternativeBO_E2.GetInstance.insert(dsData, conn)
                End If
                If actin = "Update" Then
                    count = PUBOrderAlternativeBO_E2.GetInstance.update(dsData, conn)
                End If

                '修改 PUB_Order
                updatePubOrder(order_code, conn)

                'PUBOrderAlternativeBO_E2.GetInstance.insert(dsData, conn)

                Scope.Complete()
            End Using


        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

        Return count
    End Function

#End Region

#Region "  2017/1/16  非藥品替代醫令檔維護刪除 add by Michelle"
    ''' <summary>
    ''' 非藥品替代醫令檔維護刪除 by Michelle 2017/1/16"
    ''' </summary>
    ''' <param name="dsDelete">dsDelete</param>
    ''' <param name="conn"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Michelle on 2017-1-16</remarks>
    Public Function DeletePUBOrderAlternativeByOrderCode(ByVal dsDelete As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim count As Integer = 0
        Dim connFlag As Boolean = conn Is Nothing
        Dim order_code As String = ""

        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            '-------------------------------------------------------------------------
            '　　　　　　　　　　　報　到　登　記　開　始　交　易
            '-------------------------------------------------------------------------
            Using Scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope()

                order_code = StringUtil.nvl(dsDelete.Tables(0).Rows(0)("Order_Code"))

                '刪除增加處理，更新病床資料歷史檔
                updatePUBOrderByDelete(order_code, conn)

                count = PUBOrderAlternativeBO_E2.GetInstance.deleteChoose(dsDelete, conn)


                Scope.Complete()
            End Using


        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

        Return count
    End Function

#End Region

#Region " 修改 Pub_Order By delete "

    ''' <summary>
    '''以ＰＫ刪除資料(Pub_Order)
    ''' </summary>
    ''' <remarks>by Michelle on 2017/1/16</remarks>
    Public Function updatePUBOrderByDelete(ByVal order_code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim count As Integer = 0
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlString As String = "                " & _
                                      "       update PUB_Order set Is_Alternative = 'N'  " & _
                                      "       WHERE 1 = 1  AND Order_Code = @order_code "


            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@order_code", order_code)
                count = command.ExecuteNonQuery
            End Using

        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

        Return count
    End Function

#End Region

#Region " 修改 Pub_Order By order_code "

    ''' <summary>
    '''以ＰＫ修改資料(Pub_Order)
    ''' </summary>
    ''' <remarks>by Michelle on 2017/1/16</remarks>
    Public Function updatePubOrder(ByVal order_code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim count As Integer = 0
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlString As String = "               " & _
                                      "       update PUB_Order set Is_Alternative = 'Y'  " & _
                                      "       WHERE 1 = 1  AND Order_Code = @order_code  "


            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@order_code", order_code)
                count = command.ExecuteNonQuery
            End Using

        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

        Return count
    End Function

#End Region


#End Region

End Class

