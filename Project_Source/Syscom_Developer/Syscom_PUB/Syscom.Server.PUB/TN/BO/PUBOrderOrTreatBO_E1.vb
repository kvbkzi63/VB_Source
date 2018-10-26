Imports System.Data.SqlClient
Imports log4net
Imports System.Text
Imports Syscom.Server.BO

Public Class PUBOrderOrTreatBO_E1
    Inherits PubOrderOrTreatBO

#Region "########## getInstance ##########"
    Private Shared instance As PUBOrderOrTreatBO_E1
    Public Overloads Shared Function getInstance() As PUBOrderOrTreatBO_E1
        If instance Is Nothing Then
            instance = New PUBOrderOrTreatBO_E1
        End If
        Return instance
    End Function
#End Region


#Region "2010/01/18 Add By Jen 手術資料"

    ''' <summary>
    ''' 手術資料
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order, PUB_Order_Price</remarks>
    Public Function queryByOrderCode(ByVal OrderCode As String) As DataTable

        Dim cmdStrOrder As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStrOrder.AppendLine("select * ")
        cmdStrOrder.Append("from ").Append(tableName).AppendLine(" ")
        cmdStrOrder.AppendLine("where Order_Code = @OrderCode ")

        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim dtOrder As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrder.ToString
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

#End Region

End Class
