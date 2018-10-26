Imports System.Data.SqlClient

Imports log4net
Imports System.Text
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP

Public Class PUBSheetGroupBO_E1
    Inherits PubSheetGroupBO


    Private Shared instance As PUBSheetGroupBO_E1

    Public Overloads Shared Function getInstance() As PUBSheetGroupBO_E1
        If instance Is Nothing Then
            instance = New PUBSheetGroupBO_E1
        End If
        Return instance
    End Function

    ''' <summary>
    ''' 程式說明：取得表單群組
    ''' 開發人員：Alan
    ''' 開發日期：2009.12.23
    ''' </summary>
    ''' <returns>DataSet-取得表單群組</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' PUB_Sheet_Group
    ''' </使用表單>
    ''' <修改註記>
    ''' 
    ''' </修改註記>
    Public Function queryPUBSheetGroupBySheet(ByVal SheetCode As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            command.CommandText = "Select distinct Sheet_Group ,Sheet_Group_Name " & _
                                  "From  PUB_Sheet_Group " & _
                                  "Where  Sheet_Code='" & SheetCode & "' " & _
                                  "Order by Sheet_Group "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 以SheetCode刪除資料
    ''' </summary>
    ''' <param name="sheetCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function deleteBySheetCode(ByRef sheetCode As String, Optional ByRef conn As IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            If connFlag Then
                conn = getConnection()
            End If
            If conn.State <> ConnectionState.Open Then conn.Open()

            Dim count As Integer = 0
            Dim cmdStr As StringBuilder = New StringBuilder
            cmdStr.Append("delete from ").Append(tableName).AppendLine(" ")
            cmdStr.Append("where Sheet_Code = '").Append(sheetCode).AppendLine("'")

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = cmdStr.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With

                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function

End Class
