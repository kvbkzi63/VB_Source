Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.BO
Imports log4net
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP

Public Class PUBAddOrderDetailBO_E1
    Inherits PubAddOrderDetailBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBAddOrderDetailBO_E1

    Public Overloads Shared Function getInstance() As PUBAddOrderDetailBO_E1
        If instance Is Nothing Then
            instance = New PUBAddOrderDetailBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region


    Public Function queryPUBAddOrderDetail(ByVal OpdAddOrderCode As String) As DataSet


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
    ''' 程式說明：查詢群組醫令細目
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
    Public Function queryAddOrderDetailData(ByVal AddOrderCode As String) As DataTable

        Dim SystemDate As Date = DateUtil.getSystemDate
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select A.*, O.Order_Name, Order_En_Name, 'N' As Is_New ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("from ").Append(tableName).AppendLine(" A ")
        cmdStr.AppendLine("left join PUB_Order O on A.Order_Code = O.Order_Code and O.Dc <> @DcY and O.Effect_Date < @SystemDate ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where A.Add_Order_Code = @AddOrderCode and A.Dc <> @DcY ")
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

                        sqlCmd.Parameters.AddWithValue("@AddOrderCode", AddOrderCode)
                        sqlCmd.Parameters.AddWithValue("@SystemDate", SystemDate)
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
    ''' 程式說明：移除群組醫令明細
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
    Public Function removeAddOrderDetailData(ByVal AddOrderCode As String) As Integer

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
                ' Next
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
        conn.Open()
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
