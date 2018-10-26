Imports System.Data.SqlClient

Imports log4net
Imports System.Text
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports Syscom.Comm.TableFactory

Public Class PUBOrderMajorcareBO_E1
    Inherits PubOrderMajorcareBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBOrderMajorcareBO_E1

    Public Overloads Shared Function getInstance() As PUBOrderMajorcareBO_E1
        If instance Is Nothing Then
            instance = New PUBOrderMajorcareBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 特殊項目
    ''' </summary>
    ''' <param name="OrderCode"></param>
    ''' <returns></returns>
    ''' <remarks>PUB_Order_Majorcare</remarks>
    Public Function queryMajorcareData(ByVal OrderCode As String) As DataTable

        Dim cmdStrOrderMajorcare As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------

        'Order_Majorcare
        cmdStrOrderMajorcare.AppendLine("select * ")
        cmdStrOrderMajorcare.Append("from ").Append(tableName).AppendLine(" ")
        cmdStrOrderMajorcare.Append("where Order_Code = @OrderCode ")
        cmdStrOrderMajorcare.AppendLine("Order by Majorcare_Code asc ")
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

            Dim dtOrderMajorcare As DataTable = New DataTable(PubOrderMajorcareDataTableFactory.tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()

                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrderMajorcare.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)

                        Using daOM As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                            daOM.Fill(dtOrderMajorcare)
                        End Using

                    End With
                End Using

            End Using

            Return dtOrderMajorcare

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function deleteByOrderCode(ByRef pk_Order_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Order_Code=@Order_Code  "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
                count = command.ExecuteNonQuery
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

End Class
