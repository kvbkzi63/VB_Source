Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports System.Text

Public Class PUBItemValueUnitBO_E1
    Inherits PubItemValueUnitBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBItemValueUnitBO_E1

    Public Overloads Shared Function getInstance() As PUBItemValueUnitBO_E1
        If instance Is Nothing Then
            instance = New PUBItemValueUnitBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 程式說明：查詢單位
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.29
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Item_Value_Unit, Jen-PUB_Unit
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/29, XXX
    ''' </修改註記>
    Public Function queryItemValueUnitData() As DataTable

        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select IVU.Item_Code, IVU.Unit_Code, IVU.Is_Default, U.Unit_Name, U.Unit_En_Name ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("from ").Append(tableName).AppendLine(" IVU ")
        cmdStr.AppendLine("left join PUB_Unit U on IVU.Unit_Code = U.Unit_Code ")
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
