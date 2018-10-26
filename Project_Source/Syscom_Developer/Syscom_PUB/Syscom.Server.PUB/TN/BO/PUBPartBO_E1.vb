Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP


Public Class PUBPartBO_E1
    ' Inherits PUBPartBO

    Private Shared instance As PUBPartBO_E1


    Dim tableName1 As String = "PUB_Part"

    Public Shared Function getInstance() As PUBPartBO_E1
        instance = New PUBPartBO_E1
        Return instance
    End Function


    Public Function queryPubPartByKey(ByVal regDate As String) As DataSet

        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
        'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)
        Dim SqlCmd As SqlCommand
        Dim cmdStr As String = ""
        Dim myReader As SqlDataReader = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim ds As DataSet


        cmdStr = "select * from  " & tableName1 & " where Effect_Date <='" & regDate & "' And End_Date>'" & regDate & "' And DC<>'Y' "


        ds = New DataSet("resultDB")
        Try
            If cmdStr <> "" Then
                conn.Open()
                SqlCmd = New SqlCommand(cmdStr, conn)
                da = New SqlDataAdapter(New SqlCommand(cmdStr, conn))
                da.FillSchema(ds, SchemaType.Source, "resulttable")
                da.Fill(ds.Tables("resulttable"))
            End If
        Catch ex As SqlClient.SqlException
            Throw New SQLDatabaseException(ex)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Return ds
    End Function



    Public Function queryAll() As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from " & tableName1
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function insert(ByVal ds As System.Data.DataSet) As Integer
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName1 & "(" & _
            " Effect_Date , Part_Code , Part_Name , Part_Ratio , Part_Amt ,  " & _
             " Dc , End_Date , Create_User , Create_Time , Modified_User ,  " & _
             " Modified_Time ) " & _
             " values( @Effect_Date , @Part_Code , @Part_Name , @Part_Ratio , @Part_Amt ,  " & _
             " @Dc , @End_Date , @Create_User , @Create_Time , @Modified_User ,  " & _
             " @Modified_Time             )"
            Using conn As System.Data.IDbConnection = getConnection()
                conn.Open()
                For Each row As DataRow In ds.Tables(0).Rows
                    Using command As SqlCommand = New SqlCommand
                        With command
                            .CommandText = sqlString
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                        End With
                        command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        command.Parameters.AddWithValue("@Part_Code", row.Item("Part_Code"))
                        command.Parameters.AddWithValue("@Part_Name", row.Item("Part_Name"))
                        command.Parameters.AddWithValue("@Part_Ratio", row.Item("Part_Ratio"))
                        command.Parameters.AddWithValue("@Part_Amt", row.Item("Part_Amt"))
                        command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        command.Parameters.AddWithValue("@Create_Time", Now)
                        command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        command.Parameters.AddWithValue("@Modified_Time", Now)
                        Dim cnt As Integer = command.ExecuteNonQuery
                        count = count + cnt
                    End Using
                Next
            End Using
            Return count
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function dynamicQuery(ByRef sqlString As String, Optional ByRef conn As IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = Nothing '
            If connFlag Then
                sqlConn = CType(getConnection(), SqlConnection)
            Else
                sqlConn = conn
            End If

            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds
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

    Public Function dynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As String()) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select * from " & tableName1 & " where 1=1 ")
            For i = 0 To columnName.Length - 1
                content.Append("and ").Append(columnName(i)).Append("=@").Append(columnName(i)).AppendLine(" ")
            Next
            command.CommandText = content.ToString
            For i = 0 To columnName.Length - 1
                command.Parameters.AddWithValue("@" & columnName(i), columnValue(i))
            Next
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function queryByPK(ByRef pk_Effect_Date As System.DateTime, ByRef pk_Part_Code As System.String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  " & tableName1 & " where Effect_Date=@Effect_Date and Part_Code=@Part_Code            "
            command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
            command.Parameters.AddWithValue("@Part_Code", pk_Part_Code)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function delete(ByRef pk_Effect_Date As System.DateTime, ByRef pk_Part_Code As System.String) As Integer
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName1 & " where " & _
            " Effect_Date=@Effect_Date and Part_Code=@Part_Code "
            Using conn As System.Data.IDbConnection = getConnection()
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
                    command.Parameters.AddWithValue("@Part_Code", pk_Part_Code)
                    conn.Open()
                    count = command.ExecuteNonQuery
                End Using
            End Using
            Return count
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function update(ByVal ds As System.Data.DataSet) As Integer
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName1 & " set " & _
            " Part_Name=@Part_Name , Part_Ratio=@Part_Ratio , Part_Amt=@Part_Amt ,  " & _
            " Dc=@Dc , End_Date=@End_Date , Modified_User=@Modified_User ,  " & _
            " Modified_Time=@Modified_Time " & _
            " where  Effect_Date=@Effect_Date and Part_Code=@Part_Code            "
            Using conn As System.Data.IDbConnection = getConnection()
                conn.Open()
                For Each row As DataRow In ds.Tables(tableName1).Rows
                    Using command As SqlCommand = New SqlCommand
                        With command
                            .CommandText = sqlString
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                        End With
                        command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        command.Parameters.AddWithValue("@Part_Code", row.Item("Part_Code"))
                        command.Parameters.AddWithValue("@Part_Name", row.Item("Part_Name"))
                        command.Parameters.AddWithValue("@Part_Ratio", row.Item("Part_Ratio"))
                        command.Parameters.AddWithValue("@Part_Amt", row.Item("Part_Amt"))
                        command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        command.Parameters.AddWithValue("@Modified_Time", Now)
                        Dim cnt As Integer = command.ExecuteNonQuery
                        count = count + cnt
                    End Using
                Next
            End Using
            Return count
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：取得ComboBox的Data Source
    ''' 開發人員：谷官
    ''' 開發日期：2009.07.24
    ''' </summary>
    ''' <returns>cboValue:Part_Code, Part_Name</returns>
    ''' <remarks></remarks>
    ''' <使用表單>
    ''' 1.Nick-PUB_Part
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/07/22, XXX
    ''' </修改註記>
    Public Function getComboBoxValueTable(Optional ByRef conn As IDbConnection = Nothing) As DataTable
        Dim cmdStr As New StringBuilder

        Try
            'SQL
            cmdStr.AppendLine("select")
            cmdStr.AppendLine("rtrim(Part_Code) as Part_Code,")
            cmdStr.AppendLine("rtrim(Part_Name) as Part_Name")
            cmdStr.AppendLine("from " + Me.tableName1)
            cmdStr.AppendLine("where 1=1")
            cmdStr.AppendLine("and DC <> 'Y'")
            cmdStr.AppendLine("Order by Part_Code")

            '執行SQL
            Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select1", Nothing, conn)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

End Class
