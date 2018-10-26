Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports System.Text
Public Class PUBItemBO_E1
    Inherits PubItemBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBItemBO_E1

    Public Overloads Shared Function getInstance() As PUBItemBO_E1
        If instance Is Nothing Then
            instance = New PUBItemBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 程式說明：查詢檢核項目
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Item
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryPUBItemData() As DataTable

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