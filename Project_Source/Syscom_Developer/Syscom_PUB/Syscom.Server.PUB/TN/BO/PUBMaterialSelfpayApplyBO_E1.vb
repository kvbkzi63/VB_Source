'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBMaterialSelfpayApplyBO_E1
'*              Title:	科室維護
'*        Description:	科室維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	ming
'*        Create Date:	2009/06/16
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports Syscom.Server.BO
Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Comm.EXP

Public Class PUBMaterialSelfpayApplyBO_E1
    Inherits PubMaterialSelfpayApplyBO

    Private Shared myInstance As PUBMaterialSelfpayApplyBO_E1
    Public Overloads Shared Function GetInstance() As PUBMaterialSelfpayApplyBO_E1
        If myInstance Is Nothing Then
            myInstance = New PUBMaterialSelfpayApplyBO_E1()
        End If
        Return myInstance
    End Function

    Public Function dynamicQuery2(ByVal sqlString As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString
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
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    Public Function queryLastData(ByVal inOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim cmdStrOrder As New StringBuilder
            cmdStrOrder.AppendLine("Select A.* ")
            cmdStrOrder.AppendLine("From  PUB_Material_Selfpay_Apply  A ")
            cmdStrOrder.AppendLine("Where A.Order_Code='" & inOrderCode & "' and ")
            cmdStrOrder.AppendLine("      A.Effect_Date =(Select MAX(B.Effect_Date) ")
            cmdStrOrder.AppendLine("                      From PUB_Material_Selfpay_Apply B ")
            cmdStrOrder.AppendLine("                      Where B.Order_Code=A.Order_Code ) ")


            command.CommandText = cmdStrOrder.ToString
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
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function


#Region "     以ＰＫ Like 查詢資料 "
    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryPubMaterialSelfpayApplyByPKLike(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            pk_Effect_Date = pk_Effect_Date.Replace("/", "-")

            Dim content As New StringBuilder
            content.AppendLine("select * from  " & tableName & " where Order_Code like @Order_Code       ")
       
            If pk_Effect_Date <> "" Then
                content.AppendLine("and Effect_Date like @Effect_Date      ")
            End If

            command.CommandText = content.ToString

            command.Parameters.AddWithValue("@Order_Code", pk_Order_Code & "%")
            command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date & "%")

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
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region

#Region "     以ＰＫ查詢資料 "
    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryPubMaterialSelfpayApplyByPK(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  " & tableName & " where Order_Code=@Order_Code and Effect_Date=@Effect_Date            "
            command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
            command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
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
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region

#Region "    以ＰＫ刪除資料 "
    ''' <summary>
    '''以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function PUBMaterialSelfpayApplyDelete(ByVal pk_Order_Code As System.String, ByVal pk_Effect_Date As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Order_Code=@Order_Code and Effect_Date=@Effect_Date "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
                command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
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


