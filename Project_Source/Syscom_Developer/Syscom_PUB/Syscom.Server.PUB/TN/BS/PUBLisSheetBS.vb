Imports System.Transactions
Imports System.Data.SqlClient
Imports System.Text

Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports log4net

Public Class PUBLisSheetBS

    Private Shared _instance As PUBLisSheetBS = Nothing

    Public Shared Function GetInstance() As PUBLisSheetBS
        If _instance Is Nothing Then
            _instance = New PUBLisSheetBS
        End If

        Return _instance
    End Function

    ''' <summary>
    ''' 取得資料庫連線資訊
    ''' </summary>
    ''' <returns>資料庫連線資訊</returns>
    ''' <author>Ken</author>
    ''' <date>2010-01-15</date>
    ''' <remarks></remarks>
    Private Function GetSqlConnection() As SqlConnection

        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

    Public Function Insert(ByVal InputData As DataSet) As Int32

        Dim _bo As PubSheetBO = PubSheetBO.GetInstance

        Dim _cnt As Int32 = 0

        Using trans As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope 'TransactionScopeFactory.getInstance.GetRequiredTransactionScope()

            Using _sqlConnection As SqlConnection = Me.GetSqlConnection
                Try
                    _sqlConnection.Open()

                    Dim _now As DateTime = Now

                    _cnt += _bo.insertByAssignCreateTime(InputData, _now, _sqlConnection)
                    'TODO: 填入pub_sheet_detail.

                    trans.Complete()
                Catch ex As Exception
                    Throw ex
                Finally
                    _sqlConnection.Close()
                End Try
            End Using
        End Using

        Return _cnt
    End Function

    Public Function UpdateData(ByVal SheetCode As String, _
                               ByVal SheetName As String, _
                               ByVal DeptCode As String, _
                               ByVal IsEmergencySheet As String, _
                               ByVal SheetCollectNote As String, _
                               ByVal SheetNote As String, _
                               ByVal SheetContactTel As String, _
                               ByVal Dc As String, _
                               ByVal User As String) As Int32

        Dim var1 As New System.Text.StringBuilder
        var1.Append("UPDATE PUB_Sheet " & vbCrLf)
        var1.Append("SET    Sheet_Name = @Sheet_Name, " & vbCrLf)
        var1.Append("       Dept_Code = @Dept_Code, " & vbCrLf)
        var1.Append("       Is_Emergency_Sheet = @Is_Emergency_Sheet, " & vbCrLf)
        var1.Append("       Sheet_Collect_Note = @Sheet_Collect_Note, " & vbCrLf)
        var1.Append("       Sheet_Note = @Sheet_Note, " & vbCrLf)
        var1.Append("       Sheet_Contect_Tel = @Sheet_Contect_Tel, " & vbCrLf)
        var1.Append("       Dc = @Dc " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)
        var1.Append("       AND Sheet_Type_Id = '1' " & vbCrLf)

        Using _sqlConnection As SqlConnection = Me.GetSqlConnection
            Try
                _sqlConnection.Open()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)
                _command.Parameters.AddWithValue("@Sheet_Name", SheetName)
                _command.Parameters.AddWithValue("@Dept_Code", DeptCode)
                _command.Parameters.AddWithValue("@Is_Emergency_Sheet", IsEmergencySheet)
                _command.Parameters.AddWithValue("@Sheet_Collect_Note", SheetCollectNote)
                _command.Parameters.AddWithValue("@Sheet_Note", SheetNote)
                _command.Parameters.AddWithValue("@Sheet_Contect_Tel", SheetContactTel)
                _command.Parameters.AddWithValue("@Dc", Dc)

                Return _command.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            Finally
                _sqlConnection.Close()
            End Try
        End Using
    End Function

    Public Function Delete(ByVal SheetCode As String) As Int32

        Dim _bo As PubSheetBO = PubSheetBO.GetInstance

        Dim _cnt As Int32 = 0

        Using transs As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope 'TransactionScopeFactory.getInstance.GetRequiredTransactionScope()

            Using _sqlConnection As SqlConnection = Me.GetSqlConnection
                Try
                    _sqlConnection.Open()

                    _cnt += _bo.delete(SheetCode, _sqlConnection)

                    Me.DeletePubSheetDetailBySheetCode(SheetCode, _sqlConnection)

                    transs.Complete()
                Catch ex As Exception
                    Throw ex
                Finally
                    _sqlConnection.Close()
                End Try
            End Using
        End Using

        Return _cnt

    End Function

    Private Function DeletePubSheetDetailBySheetCode(ByVal SheetCode As String, ByVal conn As SqlConnection) As Int32
        Dim var1 As New System.Text.StringBuilder
        var1.Append("DELETE PUB_Sheet_Detail " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = @Sheet_Code " & vbCrLf)

        If conn.State <> ConnectionState.Open Then
            conn.Open()
        End If

        Dim _command As New SqlCommand(var1.ToString(), conn)
        _command.CommandType = CommandType.Text
        _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)

        Return _command.ExecuteNonQuery()

    End Function

    Public Function Query(ByVal SheetCode As String, _
                          ByVal SheetName As String, _
                          ByVal DeptCode As String, _
                          ByVal SheetContactTel As String) As DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(Sheet_Code) AS Sheet_Code, " & vbCrLf)
        var1.Append("       Sheet_Name, " & vbCrLf)
        var1.Append("       RTRIM(Dept_Code)  AS Dept_Code, " & vbCrLf)
        var1.Append("       RTRIM(Sheet_Contect_Tel) AS Sheet_Contect_Tel, " & vbCrLf)
        var1.Append("       Is_Emergency_Sheet, " & vbCrLf)
        var1.Append("       Sheet_Collect_Note, " & vbCrLf)
        var1.Append("       Sheet_Note, " & vbCrLf)
        var1.Append("       Dc " & vbCrLf)
        var1.Append("FROM   PUB_Sheet " & vbCrLf)
        var1.Append("WHERE  Sheet_Code = CASE " & vbCrLf)
        var1.Append("                      WHEN @Sheet_Code = '' THEN Sheet_Code " & vbCrLf)
        var1.Append("                      ELSE @Sheet_Code " & vbCrLf)
        var1.Append("                    END " & vbCrLf)
        var1.Append("       AND Dept_Code = CASE " & vbCrLf)
        var1.Append("                         WHEN @Dept_Code = '' THEN Dept_Code " & vbCrLf)
        var1.Append("                         ELSE @Dept_Code " & vbCrLf)
        var1.Append("                       END " & vbCrLf)
        var1.Append("       AND Sheet_Name LIKE '%' + @Sheet_Name + '%' " & vbCrLf)
        var1.Append("       AND Sheet_Type_Id = '1' " & vbCrLf)

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = GetSqlConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@Sheet_Code", SheetCode)
                _command.Parameters.AddWithValue("@Sheet_Name", SheetName)
                _command.Parameters.AddWithValue("@Dept_Code", DeptCode)
                _command.Parameters.AddWithValue("@Sheet_Contect_Tel", SheetContactTel)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, "Sheet_Code")
                '_dataAdapter.FillSchema(_ds, SchemaType.Mapped, "Sheet_Code")
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

End Class
