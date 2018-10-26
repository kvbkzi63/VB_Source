Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.BO

Public Class PUBNhiCodeBO_E1
    Inherits PubNhiCodeBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBNhiCodeBO_E1

    Public Overloads Shared Function getInstance() As PUBNhiCodeBO_E1
        instance = New PUBNhiCodeBO_E1
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 程式說明：查詢健保支付標準檔資料
    ''' 開發人員：Alan
    ''' 開發日期：20010-05-13
    ''' </summary>
    ''' <returns>DataTable</returns>    
    Public Function queryPubNhiCodeEffectData(ByVal inEffectDate As String, ByVal inInsuCode As String, ByVal inOrderCode As String) As DataTable
        Dim cmdStr As New StringBuilder
        Dim cmdStr1 As New StringBuilder

        If inInsuCode = "ZZZZZZ" Then
            cmdStr1.AppendLine("Select top 1 Insu_Code ")
            cmdStr1.AppendLine("FROM PUB_Insu_Code ")
            cmdStr1.AppendLine("Where Order_Code='" & inOrderCode & "' ")
            cmdStr1.AppendLine("Order By Insu_Code_Seq ")

            Dim dt1 As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr1.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                    End With
                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dt1)
                    End Using
                End Using
            End Using

            If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then
                inInsuCode = dt1.Rows(0).Item("Insu_Code").ToString.Trim
            End If

        End If
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
        cmdStr.AppendLine("where Effect_Date<= @inEffectDate  And Insu_Code=@inInsuCode And  End_Date>=@inEffectDate  ")
        '----------------------------------------------------------------------------
        Try
            Dim dt As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@inEffectDate", inEffectDate)
                        .Parameters.AddWithValue("@inInsuCode", inInsuCode)
                        .Connection = conn
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

End Class

