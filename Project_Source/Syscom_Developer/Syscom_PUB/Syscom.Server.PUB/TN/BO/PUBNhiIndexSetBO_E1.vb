Imports System.Data.SqlClient
Imports log4net
Imports System.Text
Imports Syscom.Server.BO
Public Class PUBNhiIndexSetBO_E1
    Inherits PubNhiIndexSetBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBNhiIndexSetBO_E1

    Public Overloads Shared Function getInstance() As PUBNhiIndexSetBO_E1
        If instance Is Nothing Then
            instance = New PUBNhiIndexSetBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 查詢健保指標資料
    ''' </summary>
    ''' <param name="OrderCode">醫令碼</param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order</remarks>
    Public Function queryNhiIndexSetData(ByVal OrderCode As String) As DataTable

        Dim cmdStrExc As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStrExc.AppendLine("select * ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStrExc.Append("from ").Append(tableName).AppendLine(" ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStrExc.AppendLine("where Order_Code = @OrderCode ")
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim dtOrder As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrExc.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)

                    End With

                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dtOrder)
                    End Using

                End Using

            End Using

            Return dtOrder

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 刪除健保指標資料
    ''' </summary>
    ''' <param name="OrderCode">醫令碼</param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order</remarks>
    Public Function deleteNhiIndexSetByOrderCode(ByVal OrderCode As String) As Integer

        Dim cmdStrExc As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStrExc.AppendLine("delete ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStrExc.Append("from ").Append(tableName).AppendLine(" ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStrExc.AppendLine("where Order_Code = @OrderCode ")
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim count As Integer = -1

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand

                    conn.Open()

                    With sqlCmd
                        .CommandText = cmdStrExc.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)

                        count = sqlCmd.ExecuteNonQuery
                    End With
                End Using

            End Using

            Return count

        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class

