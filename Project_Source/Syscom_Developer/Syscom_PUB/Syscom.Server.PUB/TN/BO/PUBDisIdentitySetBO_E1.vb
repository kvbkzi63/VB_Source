Imports System.Data.SqlClient
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory

'
Imports System.Text
Imports Syscom.Server.SQL


Public Class PUBDisIdentitySetBO_E1
    Inherits PubDisIdentitySetBO
    Protected tableName1 As String = "PUB_Dis_Identity_Set"

    Private Shared instance As PUBDisIdentitySetBO_E1
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

    Public Overloads Shared Function getInstance() As PUBDisIdentitySetBO_E1
        instance = New PUBDisIdentitySetBO_E1
        Return instance

    End Function



#Region "2009/07/14 Add by Jen "

    ''' <summary>
    ''' 回傳優待身份折扣後費用
    ''' </summary>
    ''' <param name="DisIdentityCode">身分</param>
    ''' <param name="RegDate">掛號日</param>
    ''' <param name="firstFlag">第一次查詢</param>
    ''' <returns>回傳優待身份折扣後費用</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.Jen-PUB_Dis_Identity_Set
    ''' 2.Jen-PUB_Order
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/08/14, XXX
    ''' </修改註記>
    Public Function queryDisIdentitySetRegisterFee(ByVal DisIdentityCode As String, ByVal RegDate As Date, ByVal OrderCode As String, ByVal firstFlag As Boolean) As DataSet


        Dim ds As DataSet

        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("SELECT ")
        cmdStr.AppendLine("DIS.Discount_Ratio ")

        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("FROM PUB_Dis_Identity_Set DIS, PUB_Order O ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("WHERE DIS.Effect_Date <= @RegDate ")
        cmdStr.AppendLine("AND AND DIS.End_Date > @RegDate ")

        cmdStr.AppendLine("AND DIS.Dis_Identity_Code = @DisIdentityCode ")
        cmdStr.AppendLine("AND DIS.Dc <> @CancelY ")
        cmdStr.AppendLine("AND DIS.Dc = O.Dc ")
        cmdStr.AppendLine("AND DIS.Order_Type_Id = O.Order_Type_Id ")
        cmdStr.AppendLine("AND DIS.Account_Id = O.Account_Id ")
        cmdStr.AppendLine("AND O.Effect_Date <= @RegDate ")
        cmdStr.AppendLine("AND O.End_Date > @RegDate ")
        cmdStr.AppendLine("AND O.Order_Code = @OrderCode ")

        If firstFlag Then
            cmdStr.AppendLine("AND DIS.Order_Code = @OrderCode ")
        Else
            cmdStr.AppendLine("AND DIS.Order_Code = '' ")
        End If

        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@RegDate", RegDate)
                        sqlCmd.Parameters.AddWithValue("@DisIdentityCode", DisIdentityCode)
                        sqlCmd.Parameters.AddWithValue("@CancelY", "Y")
                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)

                    End With

                    conn.Open()

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        ds = New DataSet(tableName1)
                        adapter.Fill(ds, tableName1)
                        adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
                    End Using
                    Return ds

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try



    End Function

    'pub2.queryDisIdentitySetRegisterFee(DisIdentityCode, RegDate, True)
#End Region

End Class
