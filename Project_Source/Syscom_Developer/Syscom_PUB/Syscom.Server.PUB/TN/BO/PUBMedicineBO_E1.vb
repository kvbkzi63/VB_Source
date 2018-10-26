'/*
'*****************************************************************************
'*
'*    Page/Class Name:  醫療支付公用主檔-藥品
'*              Title:	PUBMedicineBO_E1
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Hsiao,Kaiwen
'*        Create Date:	2016-04-19
'*      Last Modifier:	Hsiao,Kaiwen
'*   Last Modify Date:	2016-04-19
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text

Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL


Public Class PUBMedicineBO_E1
   
#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBMedicineBO_E1
    Public Shared Function GetInstance() As PUBMedicineBO_E1
        If myInstance Is Nothing Then
            myInstance = New PUBMedicineBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "      由Order_Code查詢藥品碼資料(舊程式OPHPB_queryPharmacyBaseByOrderCode(OrderCode)) "

    ''' <summary>
    ''' 由Order_Code查詢藥品碼資料
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPharmacyBaseByOrderCode(ByVal OrderCode As String) As DataTable

        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("SELECT top 1 * ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("from ").Append("OPH_Pharmacy_Base").AppendLine(" ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where Order_Code = @OrderCode and Dc <> @DcY ")
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim dt As DataTable = New DataTable("OPH_Pharmacy_Base")

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)
                        sqlCmd.Parameters.AddWithValue("@DcY", "Y")

                    End With
                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "      更新前審查項目基本資料 "

    ''' <summary>
    ''' 更新前審查項目基本資料
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateReviewOrder(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
       
            Dim connFlag As Boolean = conn Is Nothing
            Try
                Dim currentTime = Now
                Dim count As Integer = 0
                Dim sqlString As String = "update PRI_Review_Order set " & _
                " Item_Type_Id=@Item_Type_Id , Brand=@Brand , Class_Code=@Class_Code , ATC_Code=@ATC_Code , Dc=@Dc , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
                " where  Order_Code=@Order_Code "
                If connFlag Then
                    conn = getConnection()
                    conn.Open()
                End If
                For Each row As DataRow In ds.Tables(0).Rows

                    If row.Item("Dc").ToString.Trim.ToUpper = "N" Or row.Item("Dc").ToString.Trim = "" Then
                        Dim dsQuery As DataSet = queryByPK(row.Item("Order_Code").ToString.Trim, conn)
                        If dsQuery.Tables(0).Rows.Count <> 0 Then
                            sqlString = "update  PRI_Review_Order set " & _
                " Item_Type_Id=@Item_Type_Id , Brand=@Brand , Class_Code=@Class_Code , ATC_Code=@ATC_Code , Dc=@Dc , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
                " where  Order_Code=@Order_Code "
                            Dim dsTemp As DataSet = queryClassCodeAndATC(row.Item("Order_Code").ToString.Trim, conn)
                            Using command As SqlCommand = New SqlCommand
                                With command
                                    .CommandText = sqlString
                                    .CommandType = CommandType.Text
                                    .Connection = CType(conn, SqlConnection)
                                End With
                                command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))

                                If row.Item("Order_Type_Id").ToString.Trim = "E" Then
                                    command.Parameters.AddWithValue("@Item_Type_Id", "1")
                                ElseIf row.Item("Order_Type_Id").ToString.Trim = "G" Then
                                    command.Parameters.AddWithValue("@Item_Type_Id", "3")
                                Else
                                    command.Parameters.AddWithValue("@Item_Type_Id", "2")
                                End If

                                If dsTemp.Tables(0).Rows.Count <> 0 Then
                                    command.Parameters.AddWithValue("@Brand", dsTemp.Tables(0).Rows(0).Item("Supplier_Name").ToString.Trim)
                                    command.Parameters.AddWithValue("@Class_Code", dsTemp.Tables(0).Rows(0).Item("Class_Code").ToString.Trim)
                                    command.Parameters.AddWithValue("@ATC_Code", dsTemp.Tables(0).Rows(0).Item("ATC_Code").ToString.Trim)
                                Else
                                    command.Parameters.AddWithValue("@Brand", "")
                                    command.Parameters.AddWithValue("@Class_Code", "")
                                    command.Parameters.AddWithValue("@ATC_Code", "")
                                End If
                                command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                                command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                                command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                                Dim cnt As Integer = command.ExecuteNonQuery
                                count = count + cnt
                            End Using
                        Else
                            sqlString = "insert into PRI_Review_Order (" & _
                " Order_Code , Item_Type_Id , Brand , Branch_Office_Type_Id ,  " & _
                 " Accept_Sn , Memo ,  " & _
                 " Class_Code , ATC_Code , Dc , Create_User , Create_Time ,  " & _
                 " Modified_User , Modified_Time ) " & _
                 " values( @Order_Code , @Item_Type_Id , @Brand , @Branch_Office_Type_Id , " & _
                 " @Accept_Sn , @Memo ,  " & _
                 " @Class_Code , @ATC_Code , @Dc , @Create_User , @Create_Time ,  " & _
                 " @Modified_User , @Modified_Time             )"
                            Dim dsTemp As DataSet = queryClassCodeAndATC(row.Item("Order_Code").ToString.Trim, conn)
                            Using command As SqlCommand = New SqlCommand
                                With command
                                    .CommandText = sqlString
                                    .CommandType = CommandType.Text
                                    .Connection = CType(conn, SqlConnection)
                                End With
                                command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))

                                If row.Item("Order_Type_Id").ToString.Trim = "E" Then
                                    command.Parameters.AddWithValue("@Item_Type_Id", "1")
                                ElseIf row.Item("Order_Type_Id").ToString.Trim = "G" Then
                                    command.Parameters.AddWithValue("@Item_Type_Id", "3")
                                Else
                                    command.Parameters.AddWithValue("@Item_Type_Id", "2")
                                End If

                                command.Parameters.AddWithValue("@Brand", "")
                                command.Parameters.AddWithValue("@Branch_Office_Type_Id", "")
                                command.Parameters.AddWithValue("@Accept_Sn", "")
                                command.Parameters.AddWithValue("@Memo", "")

                                If dsTemp.Tables(0).Rows.Count <> 0 Then
                                    command.Parameters.AddWithValue("@Class_Code", dsTemp.Tables(0).Rows(0).Item("Class_Code").ToString.Trim)
                                    command.Parameters.AddWithValue("@ATC_Code", dsTemp.Tables(0).Rows(0).Item("ATC_Code").ToString.Trim)
                                Else
                                    command.Parameters.AddWithValue("@Class_Code", "")
                                    command.Parameters.AddWithValue("@ATC_Code", "")
                                End If

                                command.Parameters.AddWithValue("@Dc", "N")
                                command.Parameters.AddWithValue("@Create_User", row.Item("Modified_User"))
                                command.Parameters.AddWithValue("@Create_Time", currentTime)
                                command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                                command.Parameters.AddWithValue("@Modified_Time", currentTime)
                                Dim cnt As Integer = command.ExecuteNonQuery
                                count = count + cnt
                            End Using
                        End If
                    Else
                        sqlString = "update PRI_Review_Order set " & _
                " Item_Type_Id=@Item_Type_Id , Brand=@Brand , Class_Code=@Class_Code , ATC_Code=@ATC_Code , Dc=@Dc , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
                " where  Order_Code=@Order_Code "
                        Dim dsTemp As DataSet = queryClassCodeAndATC(row.Item("Order_Code").ToString.Trim, conn)
                        Using command As SqlCommand = New SqlCommand
                            With command
                                .CommandText = sqlString
                                .CommandType = CommandType.Text
                                .Connection = CType(conn, SqlConnection)
                            End With
                            command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))

                            If row.Item("Order_Type_Id").ToString.Trim = "E" Then
                                command.Parameters.AddWithValue("@Item_Type_Id", "1")
                            ElseIf row.Item("Order_Type_Id").ToString.Trim = "G" Then
                                command.Parameters.AddWithValue("@Item_Type_Id", "3")
                            Else
                                command.Parameters.AddWithValue("@Item_Type_Id", "2")
                            End If

                            If dsTemp.Tables(0).Rows.Count <> 0 Then
                                command.Parameters.AddWithValue("@Brand", dsTemp.Tables(0).Rows(0).Item("Supplier_Name").ToString.Trim)
                                command.Parameters.AddWithValue("@Class_Code", dsTemp.Tables(0).Rows(0).Item("Class_Code").ToString.Trim)
                                command.Parameters.AddWithValue("@ATC_Code", dsTemp.Tables(0).Rows(0).Item("ATC_Code").ToString.Trim)
                            Else
                                command.Parameters.AddWithValue("@Brand", "")
                                command.Parameters.AddWithValue("@Class_Code", "")
                                command.Parameters.AddWithValue("@ATC_Code", "")
                            End If
                            command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                            command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                            command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                            Dim cnt As Integer = command.ExecuteNonQuery
                            count = count + cnt
                        End Using
                    End If
                Next
                Return count

            Catch sqlex As SqlException
                Throw sqlex
            Catch ex As Exception
                Throw New CommonException("CMMCMMD003", ex)
            Finally
                If connFlag Then
                    conn.Close()
                    conn.Dispose()
                    conn = Nothing
                End If
            End Try

    End Function


#End Region

#Region "      求得藥理分類代碼和ATC碼 "

    ''' <summary>
    ''' 求得藥理分類代碼和ATC碼
    ''' </summary>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function queryClassCodeAndATC(ByVal Order_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim sqlString As New System.Text.StringBuilder
            sqlString.Append("SELECT Rtrim(PB.Class_Code) AS Class_Code, " & vbCrLf)
            sqlString.Append("       Rtrim(PB.ATC_Code) AS ATC_Code, " & vbCrLf)
            sqlString.Append("       CASE " & vbCrLf)
            sqlString.Append("         WHEN Len(Rtrim(OS.Supplier_Name)) > 50 THEN LEFT(Rtrim(OS.Supplier_Name), 50) " & vbCrLf)
            sqlString.Append("         ELSE Rtrim(OS.Supplier_Name) " & vbCrLf)
            sqlString.Append("       END AS Supplier_Name " & vbCrLf)
            sqlString.Append("FROM   OPH_Pharmacy_Base PB " & vbCrLf)
            sqlString.Append("       LEFT OUTER JOIN OPH_Supplier OS " & vbCrLf)
            sqlString.Append("         ON PB.Supplier_Id = OS.Supplier_Code " & vbCrLf)
            sqlString.Append("WHERE  PB.Order_Code = @Order_Code ")

            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString.ToString
            command.Parameters.AddWithValue("@Order_Code", Order_Code)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("OPH_Pharmacy_Base")
                adapter.Fill(ds, "OPH_Pharmacy_Base")
                adapter.FillSchema(ds, SchemaType.Mapped, "OPH_Pharmacy_Base")
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

#Region "      原程式(PriReviewOrderBO)以ＰＫ查詢資料 "

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByPK(ByRef pk_Order_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  Pri_Review_Order where Order_Code=@Order_Code            "
            command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Pri_Review_Order")
                adapter.Fill(ds, "Pri_Review_Order")
                adapter.FillSchema(ds, SchemaType.Mapped, "Pri_Review_Order")
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
 

#Region "    取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Examine 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function
#End Region

End Class

