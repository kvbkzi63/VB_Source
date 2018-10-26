Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports System.Text

Public Class PUBItemOperatorBO_E1
    Inherits PubItemOperatorBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBItemOperatorBO_E1

    Public Overloads Shared Function getInstance() As PUBItemOperatorBO_E1
        If instance Is Nothing Then
            instance = New PUBItemOperatorBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region


    ''' <summary>
    ''' 程式說明：查詢適用運算子
    ''' 開發人員：Jen
    ''' 開發日期：2009.12.20
    ''' </summary>
    ''' <param name="ItemCodes">項目碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Item_Operator
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/12/20, XXX
    ''' </修改註記>
    Public Function queryOperatorData(ByVal ItemCodes() As String) As DataTable

        If ItemCodes IsNot Nothing AndAlso ItemCodes.Length > 0 Then
            Dim itemStr As New StringBuilder

            For i As Integer = 0 To (ItemCodes.Length - 1)
                itemStr.Append("'").Append(ItemCodes(i).Trim).Append("',")
            Next
            If itemStr.Length > 0 Then
                itemStr.Remove(itemStr.Length - 1, 1)
            End If

            If itemStr.Length > 0 Then
                Dim cmdStr As New StringBuilder
                '----------------------------------------------------------------------------
                'Select SQL
                '----------------------------------------------------------------------------
                cmdStr.AppendLine("select * ")
                '----------------------------------------------------------------------------
                'From&Join SQL
                '----------------------------------------------------------------------------
                cmdStr.Append("from ").Append(tableName).AppendLine(" ")
                '----------------------------------------------------------------------------
                'Where SQL
                '----------------------------------------------------------------------------
                cmdStr.AppendLine("where Item_Code in (").Append(itemStr).Append(") ")
                '----------------------------------------------------------------------------
                '----------------------------------------------------------------------------
                'Order By SQL
                '----------------------------------------------------------------------------
                cmdStr.AppendLine("Order By Item_Code, Operator_Code asc ")
                '----------------------------------------------------------------------------
                Try
                    Dim dt As DataTable = New DataTable(tableName)

                    Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                        Using sqlCmd As SqlCommand = New SqlCommand
                            With sqlCmd
                                .CommandText = cmdStr.ToString
                                .CommandType = CommandType.Text
                                .Connection = conn

                                'sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)
                                'sqlCmd.Parameters.AddWithValue("@MainIdentityId", MainIdentityId)
                                'sqlCmd.Parameters.AddWithValue("@EffectDate", EffectDate)
                                'sqlCmd.Parameters.AddWithValue("@DcY", "Y")

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
            Else
                Return Nothing
            End If
            
        Else
            Return Nothing
        End If

    End Function

End Class
