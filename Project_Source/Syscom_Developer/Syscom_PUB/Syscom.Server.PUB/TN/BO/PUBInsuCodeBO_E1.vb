Imports System.Data.SqlClient
Imports log4net

Imports System.Text
Imports Syscom.Server.BO

Public Class PUBInsuCodeBO_E1
    Inherits PubInsuCodeBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBInsuCodeBO_E1

    Public Overloads Shared Function getInstance() As PUBInsuCodeBO_E1
        instance = New PUBInsuCodeBO_E1
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 程式說明：查詢資料
    ''' 開發人員：Alan
    ''' 開發日期：20010-06-09
    ''' </summary>
    ''' <returns>DataTable</returns>    
    Public Function queryPubInsuCodeEffectData(ByVal inEffectDate As String, ByVal inOrderTypeId As String, ByVal inOrderCode As String) As DataTable

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
        cmdStr.AppendLine("where Effect_Date<= @inEffectDate And Order_Type_Id=@inOrderTypeId  And Order_Code=@inInsuCode And  End_Date>=@inEffectDate And DC<>'Y' ")
        '----------------------------------------------------------------------------
        Try
            Dim dt As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@inEffectDate", inEffectDate)
                        .Parameters.AddWithValue("@inOrderTypeId", inOrderTypeId)
                        .Parameters.AddWithValue("@inInsuCode", inOrderCode)
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

