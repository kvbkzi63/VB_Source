Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.BO

Public Class PUBMajorcareBO_E1
    Inherits PubMajorcareBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBMajorcareBO_E1

    Public Overloads Shared Function getInstance() As PUBMajorcareBO_E1
        instance = New PUBMajorcareBO_E1
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 程式說明：特定治療下拉選單
    ''' 開發人員：Jen
    ''' 開發日期：2009.09.16
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Majorcare
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/09/16, XXX
    ''' </修改註記>
    Public Function queryMajorcareForCombo(ByVal majorcareTypeId As String) As DataTable

        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select Majorcare_Code, Majorcare_Name ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("from ").Append(tableName).AppendLine(" ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        If majorcareTypeId IsNot Nothing AndAlso majorcareTypeId.Length > 0 Then
            cmdStr.AppendLine("where Majorcare_Type_Id = @Majorcare_Type_Id ")
        End If

        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("order by Majorcare_Code ")
        '----------------------------------------------------------------------------
        Try
            Dim dt As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text

                        If majorcareTypeId IsNot Nothing AndAlso majorcareTypeId.Length > 0 Then
                            .Parameters.AddWithValue("@Majorcare_Type_Id", majorcareTypeId)
                        End If

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
