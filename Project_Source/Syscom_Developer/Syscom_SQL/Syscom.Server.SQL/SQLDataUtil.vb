Imports System.Text
Imports System.Data.SqlClient
Imports Syscom.Comm.Utility
Public Class SQLDataUtil

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As SQLDataUtil
        Return New SQLDataUtil
    End Function

    ''' <summary>
    ''' Server端執行"確認"完畢後的結果(待補)
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared EXECUTE_SUCCESS As Integer = 1024001
    Public Shared EXECUTE_FAIL As Integer = 1024002
    Public Shared EXECUTE_LACK_OF_BASIC As Integer = 1024003
    Public Shared EXECUTE_LACK_OF_DATA As Integer = 1024004

    ''' <summary>
    ''' 取得資料後的編輯狀態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ADD_TYPE As String = "ADD_TYPE"
    Public Shared MOD_TYPE As String = "MOD_TYPE"
    Public Shared CLONE_TYPE As String = "CLONE_TYPE"


    ''' <summary>
    ''' 取得Table的欄位集合
    ''' </summary>
    ''' <param name="tbNames">Table名稱，可傳入多個，以","隔開</param>
    ''' <returns>DataSet:Table對映的欄位清單</returns>
    ''' <remarks></remarks>
    Public Shared Function getTableColumns(ByVal tbNames As String) As DataSet
        Dim conn As SqlConnection = SQLConnFactory.getInstance.getOpdDBSqlConn
        Dim dsTemp As New DataSet

        Dim table As String() = tbNames.Split(",".ToCharArray)

        For i As Integer = 0 To table.Length - 1
            '新增一個Table
            dsTemp.Tables.Add(table(i))

            Dim cmdStr As String = ""
            cmdStr = "select A.name from sys.columns A"
            cmdStr += "left join sys.tables B on A.object_id=B.object_id"
            cmdStr += "where B.name='" + table(i) + "'"

            Try
                conn.Open()
                'SqlDataAdapter
                Dim da As SqlDataAdapter = New SqlDataAdapter(New SqlCommand(cmdStr, conn))

                ''載入table的metadata
                'da.FillSchema(dsTemp, SchemaType.Source, Me.tableName)
                da.Fill(dsTemp.Tables(table(i)))
            Catch ex As SqlClient.SqlException
                'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
                Throw ex
            Finally
                conn.Close()
                conn.Dispose()
            End Try
        Next

        Return dsTemp
    End Function
    ''' <summary>
    ''' 取得ConvertDatetime
    ''' </summary>
    ''' <param name="d">datetime的欄位</param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Shared Function convertDatetime(ByVal d As String) As String
        If d.Equals("getdate()") Then
            Return d
        End If
        Return "convert(datetime,'" + d + "')"
    End Function
    ''' <summary>
    ''' 日期欄位輸出的轉換
    ''' </summary>
    ''' <param name="dateColumnName">datetime的欄位名稱</param>
    ''' <param name="type">轉換形式, 0: 西元->民國、只回傳曰期     2009/1/2 12:00:00 -> 98/1/2,
    '''                              1: 西元->民國、回傳曰期和時間 2009/1/2 12:00:00 -> 98/1/2 12:00:00,
    '''                              2: 西元      、只回傳曰期     2009/1/2 12:00:00 -> 2009/1/2
    '''</param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Shared Function convertDateType(ByVal dateColumnName As String, ByVal type As Integer) As String
        Dim strSql As String = ""

        Select Case type
            Case 0
                strSql = "case isnull(@dateColumnName,'') when '' then '' " + _
                         "else convert(varchar,year(@dateColumnName)-1911)+right(convert(varchar,@dateColumnName,111),len(convert(varchar,@dateColumnName,111))-4) " + _
                         "end"
            Case 1
                strSql = "case isnull(@dateColumnName,'') when '' then '' " + _
                         "else replace(convert(varchar,convert(int,left(convert(varchar,@dateColumnName,20),4))-1911)+right(convert(varchar,@dateColumnName,20),len(convert(varchar,@dateColumnName,20))-4),'-','/') " + _
                         "end"
            Case 2
                strSql = "case isnull(@dateColumnName,'') when '' then '' " + _
                         "else convert(varchar,year(@dateColumnName))+right(convert(varchar,@dateColumnName,111),len(convert(varchar,@dateColumnName,111))-4) " + _
                         "end"
        End Select

        strSql = strSql.Replace("@dateColumnName", dateColumnName)

        Return strSql
    End Function

    ''' <summary>
    ''' 程式說明：執行SQL，並取得資料(PCS)
    ''' 開發人員：Charles
    ''' 開發日期：2012.01.06
    ''' </summary>
    ''' <param name="cmdStr">SQL字串</param>
    ''' <param name="paramDT">SQL參數，參數名稱需和欄位名稱一樣</param>
    ''' <param name="queryType">
    ''' SQL的類型
    ''' 
    ''' update：更新
    ''' delete：修改
    ''' select1、select2：查詢
    ''' value：取得值
    ''' </param>
    ''' <param name="returnTableName">回傳的Table Name</param>
    ''' <param name="conn">DB Connection</param>
    ''' <returns>
    ''' 依SQL的類型回傳不同的資料
    ''' 
    ''' insert、update、delete：回傳成功的筆數Integer
    ''' select1：回傳DataTable
    ''' select2：回傳DataSet
    ''' value：回傳取得的值本身的Type
    ''' </returns>
    ''' <remarks></remarks>
    Public Function PCSexecSQL(ByRef cmdStr As String, ByRef paramDT As DataTable, ByRef queryType As String, ByVal returnTableName() As String, Optional ByRef conn As IDbConnection = Nothing, Optional ByVal Timeout As Integer = 0) As Object
        Dim needCloseConnFlag As Boolean = conn Is Nothing

        Try
            If conn Is Nothing Then conn = SQLConnFactory.getInstance.getPcsDBSqlConn

            Return execSQLDetail(needCloseConnFlag, cmdStr, paramDT, queryType, returnTableName, conn, Timeout)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：執行SQL，並取得資料
    ''' 開發人員：谷官
    ''' 開發日期：2009.11.17
    ''' </summary>
    ''' <param name="cmdStr">SQL字串</param>
    ''' <param name="paramDT">SQL參數，參數名稱需和欄位名稱一樣</param>
    ''' <param name="queryType">
    ''' SQL的類型
    ''' 
    ''' update：更新
    ''' delete：修改
    ''' select1、select2：查詢
    ''' value：取得值
    ''' </param>
    ''' <param name="returnTableName">回傳的Table Name</param>
    ''' <param name="conn">DB Connection</param>
    ''' <returns>
    ''' 依SQL的類型回傳不同的資料
    ''' 
    ''' insert、update、delete：回傳成功的筆數Integer
    ''' select1：回傳DataTable
    ''' select2：回傳DataSet
    ''' value：回傳取得的值本身的Type
    ''' </returns>
    ''' <remarks></remarks>
    Public Function execSQL(ByRef cmdStr As String, ByRef paramDT As DataTable, ByRef queryType As String, ByVal returnTableName() As String, Optional ByRef conn As IDbConnection = Nothing, Optional ByVal Timeout As Integer = 0) As Object
        Dim needCloseConnFlag As Boolean = conn Is Nothing

        Try
            If conn Is Nothing Then conn = SQLConnFactory.getInstance.getOpdDBSqlConn

            Return execSQLDetail(needCloseConnFlag, cmdStr, paramDT, queryType, returnTableName, conn, Timeout)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：執行SQL，並取得資料(for Batch呼叫用)
    ''' 開發人員：谷官
    ''' 開發日期：2011.03.31
    ''' </summary>
    ''' <param name="cmdStr">SQL字串</param>
    ''' <param name="paramDT">SQL參數，參數名稱需和欄位名稱一樣</param>
    ''' <param name="queryType">
    ''' SQL的類型
    ''' 
    ''' update：更新
    ''' delete：修改
    ''' select1、select2：查詢
    ''' value：取得值
    ''' </param>
    ''' <param name="returnTableName">回傳的Table Name</param>
    ''' <param name="conn">DB Connection</param>
    ''' <returns>
    ''' 依SQL的類型回傳不同的資料
    ''' 
    ''' insert、update、delete：回傳成功的筆數Integer
    ''' select1：回傳DataTable
    ''' select2：回傳DataSet
    ''' value：回傳取得的值本身的Type
    ''' </returns>
    ''' <remarks></remarks>
    Public Function execSQLForBatch(ByRef cmdStr As String, ByRef paramDT As DataTable, ByRef queryType As String, ByVal returnTableName() As String, ByRef conn As IDbConnection, Optional ByVal Timeout As Integer = 0) As Object
        Dim needCloseConnFlag As Boolean = conn Is Nothing

        Try
            If conn Is Nothing Then Return Nothing

            Return execSQLDetail(needCloseConnFlag, cmdStr, paramDT, queryType, returnTableName, conn, Timeout)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function execSQLDetail(ByRef needCloseConnFlag As Boolean, ByRef cmdStr As String, ByRef paramDT As DataTable, ByRef queryType As String, ByVal returnTableName() As String, ByRef conn As IDbConnection, Optional ByVal Timeout As Integer = 0) As Object
        Try
            Using sqlCmd As SqlCommand = New SqlCommand
                With sqlCmd
                    If Timeout > 0 Then
                        .CommandTimeout = Timeout
                    End If
                    .CommandText = cmdStr
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)

                    If DataSetUtil.IsContainsData(paramDT) Then
                        For Each column As DataColumn In paramDT.Columns
                            If Not paramDT.Rows(0).Item(column.ColumnName).Equals(DBNull.Value) Then
                                sqlCmd.Parameters.AddWithValue("@" & column.ColumnName, paramDT.Rows(0).Item(column.ColumnName))
                            End If
                        Next
                    End If

                End With

                If needCloseConnFlag And conn.State = ConnectionState.Closed Then conn.Open()

                Select Case queryType.ToLower
                    Case "insert", "update", "delete"
                        Return sqlCmd.ExecuteNonQuery()
                    Case "select1"
                        Dim tableName As String = "queryResultDT"

                        If returnTableName IsNot Nothing AndAlso returnTableName.Length > 0 AndAlso returnTableName(0).ToString.Length > 0 Then
                            tableName = returnTableName(0)
                        End If

                        Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                            Using dt As DataTable = New DataTable(tableName)

                                da.Fill(dt)

                                Return dt
                            End Using
                        End Using
                    Case "select2"
                        Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                            Using ds As DataSet = New DataSet

                                da.Fill(ds)

                                Dim useDefaultTBNameFlag As Boolean = True
                                If returnTableName IsNot Nothing AndAlso returnTableName.Length.Equals(ds.Tables.Count) Then

                                End If

                                Dim num As Integer = 0
                                For iTable As Integer = 0 To ds.Tables.Count - 1
                                    Dim tableName As String = ""

                                    If returnTableName IsNot Nothing AndAlso iTable < returnTableName.Length AndAlso returnTableName(iTable).Length > 0 Then
                                        tableName = returnTableName(iTable)
                                    Else
                                        tableName = "table" & num.ToString.Trim
                                        num += 1
                                    End If

                                    ds.Tables(iTable).TableName = tableName
                                Next

                                Return ds
                            End Using
                        End Using
                    Case "value"
                        Return sqlCmd.ExecuteScalar()
                    Case Else
                        Return Nothing
                End Select
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            If needCloseConnFlag And conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Function
    ''' <summary>
    ''' Convert 2-way Object Array to a Dictionary
    ''' 開發人員：Fang-Chen Hwang
    ''' 開發日期：2012.11.06
    ''' </summary>
    Public Shared Function convert2Dictionary(ByVal param(,) As Object) As Dictionary(Of Object, Object)
        Dim paramlist As New Dictionary(Of Object, Object)

        Dim numParam As Integer = param.GetUpperBound(0)
        For j As Integer = 0 To numParam
            paramlist.Add(param(j, 0), param(j, 1))
        Next
        Return paramlist
    End Function
End Class
