Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.BO
Imports log4net
Imports Syscom.Comm.EXP

Public Class PUBAddOrderBO_E1
    Inherits PubAddOrderBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBAddOrderBO_E1

    Public Overloads Shared Function getInstance() As PUBAddOrderBO_E1
        If instance Is Nothing Then
            instance = New PUBAddOrderBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    Public Function queryPUBAddOrder(ByVal OpdAddOrderCode As String) As DataSet

        Try
            Dim returnDS As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " Select *  " & _
                                  " From " & tableName & " " & _
                                  " Where Add_Order_Code <='" & OpdAddOrderCode & "'   And DC = 'N' "
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                returnDS = New DataSet(tableName)
                adapter.Fill(returnDS, tableName)
                adapter.FillSchema(returnDS, SchemaType.Mapped, tableName)
            End Using
            Return returnDS
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 程式說明：查詢群組醫令
    ''' 開發人員：Jen
    ''' 開發日期：2009.10.31
    ''' </summary>
    ''' <param name="AddOrderCode">群組醫令碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Add_Order
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/10/31, XXX
    ''' </修改註記>
    Public Function queryAddOrderData(ByVal AddOrderCode As String) As DataTable

        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select Add_Order_Code")
        cmdStr.AppendLine("       , Add_Order_Name ")
        cmdStr.AppendLine("       , Group_Id ")
        cmdStr.AppendLine("       , Dc ")
        cmdStr.AppendLine("       , Create_User ")
        cmdStr.AppendLine("       , substring(dbo.AdToRocTime(Create_Time),0,16) AS Create_Time   ")
        cmdStr.AppendLine("       , Modified_User ")
        cmdStr.AppendLine("       , substring(dbo.AdToRocTime(Modified_Time),0,16) Modified_Time ")
        cmdStr.AppendLine("       , 'N' As Is_New ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("from ").Append(tableName).AppendLine(" ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where 1=1  ")
        If AddOrderCode.Length > 0 Then
            cmdStr.AppendLine("  And Add_Order_Code = @AddOrderCode  ")
        End If
         cmdStr.AppendLine("  And Dc <> @DcY ")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        Try
            Dim dt As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                        If AddOrderCode.Length > 0 Then
                            sqlCmd.Parameters.AddWithValue("@AddOrderCode", AddOrderCode)
                        End If
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

    ''' <summary>
    ''' 程式說明：移除群組醫令
    ''' 開發人員：Jen
    ''' 開發日期：2009.10.31
    ''' </summary>
    ''' <param name="AddOrderCode">群組醫令碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Add_Order
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/10/31, XXX
    ''' </修改註記>
    Public Function removeAddOrderData(ByVal AddOrderCode As String) As Integer

        Try
            Dim currentTime = Now
            Dim count As Integer = 0



            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'update SQL
            cmdStr.Append("update ").Append(tableName).AppendLine(" ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("set Dc = @DcY ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where Add_Order_Code = @AddOrderCode ")


            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                conn.Open()
                'For Each AddOrderCode As String In AddOrderCodes
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@DcY", "Y")
                    command.Parameters.AddWithValue("@AddOrderCode", AddOrderCode)

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
                'Next
            End Using

            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally

        End Try


    End Function

    ''' <summary>
    '''以addOrderCode刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function deleteByAddOrderCode(ByRef addOrderCode As String) As Integer

        Dim conn As IDbConnection = getConnection()

        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Add_Order_Code=@Add_Order_Code "

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Add_Order_Code", addOrderCode)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End Try
    End Function

End Class
