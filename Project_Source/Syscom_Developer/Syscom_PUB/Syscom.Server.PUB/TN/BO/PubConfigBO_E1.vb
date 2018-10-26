Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PubConfigBO_E1
    Inherits PubConfigBO

    Dim log As LOGDelegate = LOGDelegate.getInstance

#Region "########## getInstance ##########"
    Private Shared instance As PubConfigBO_E1
    Public Overloads Shared Function getInstance() As PubConfigBO_E1
        If instance Is Nothing Then
            instance = New PubConfigBO_E1
        End If
        Return instance
    End Function
    Public Sub New()
    End Sub
#End Region

#Region "     查詢 Method (For多筆維護UI用，使用LIKE 'PKey%') "
    ''' <summary>
    '''查詢(依PKey)
    ''' </summary>
    ''' <returns>查詢結果</returns>
    ''' <remarks>by Alan Tsai on 2014-11-06</remarks>
    Public Function queryPUBConfigLikePKey(ByVal inConfig_Name As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" RTRIM(Config_Name) as Config_Name , RTRIM(Config_Description) as Config_Description , RTRIM(Config_Value) as Config_Value , Create_User , dbo.ADTOROCTime(Create_Time) ,  ")
            content.AppendLine(" Modified_User , dbo.ADTOROCTime(Modified_Time)                from " & tableName)
            content.AppendLine("   where Config_Name Like @Config_Name            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Config_Name", inConfig_Name & "%")
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                'adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
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

#End Region

#Region "     新增 Method (For多筆維護UI用) "
    ''' <summary>
    '''新增
    ''' </summary>
    ''' <returns>新增筆數</returns>
    ''' <remarks>by Alan Tsai on 2014-11-03</remarks>
    Public Function insertPUBConfigByRowData(ByVal inConfig_Name As String,
                                             ByVal inConfig_Description As String,
                                             ByVal inConfig_Value As String,
                                             ByVal inCreate_User As String,
                                             ByVal inCreate_Time As DateTime,
                                             ByVal inModified_Name As String,
                                             ByVal inModified_Time As DateTime,
                                             Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Config_Name , Config_Description , Config_Value , Create_User , Create_Time ,  " & _
             " Modified_User , Modified_Time ) " & _
             " values( @Config_Name , @Config_Description , @Config_Value , @Create_User , @Create_Time ,  " & _
             " @Modified_User , @Modified_Time             )"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Config_Name", inConfig_Name)
                command.Parameters.AddWithValue("@Config_Description", inConfig_Description)
                command.Parameters.AddWithValue("@Config_Value", inConfig_Value)
                command.Parameters.AddWithValue("@Create_User", inCreate_User)
                command.Parameters.AddWithValue("@Create_Time", inCreate_Time)
                command.Parameters.AddWithValue("@Modified_User", inModified_Name)
                command.Parameters.AddWithValue("@Modified_Time", inModified_Time)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count

        Catch sqlex As SqlException
            Throw sqlex
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

#End Region

#Region "     修改 Method (For多筆維護UI用) "
    ''' <summary>
    '''修改
    ''' </summary>
    ''' <returns>修改筆數</returns>
    ''' <remarks>by Alan Tsai on 2014-11-03</remarks>
    Public Function updatePUBConfigByRowData(ByVal inConfig_Name As String,
                                             ByVal inConfig_Description As String,
                                             ByVal inConfig_Value As String,
                                             ByVal inModified_Name As String,
                                             ByVal inModified_Time As DateTime,
                                             Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Config_Description=@Config_Description , Config_Value=@Config_Value , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            " where  Config_Name=@Config_Name            "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Config_Name", inConfig_Name)
                command.Parameters.AddWithValue("@Config_Description", inConfig_Description)
                command.Parameters.AddWithValue("@Config_Value", inConfig_Value)
                command.Parameters.AddWithValue("@Modified_User", inModified_Name)
                command.Parameters.AddWithValue("@Modified_Time", inModified_Time)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count

        Catch sqlex As SqlException
            Throw sqlex
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

#End Region

#Region "     刪除 Method (For多筆維護UI用) "
    ''' <summary>
    '''刪除
    ''' </summary>
    ''' <returns>刪除筆數</returns>
    ''' <remarks>by Alan Tsai on 2014-11-03</remarks>
    Public Function deletePubConfigByPK(ByRef pk_Config_Name As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Config_Name=@Config_Name "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Config_Name", pk_Config_Name)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
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

#End Region

#Region " 查詢By參數名稱 "

    ''' <summary>
    ''' 查詢By參數名稱
    ''' </summary>
    ''' <param name="configName" >查詢參數</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2014-11-04</remarks>
    Public Function QueryByConfigName(ByVal configName As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim Content As New StringBuilder
            Content.AppendLine("SELECT Config_Name")
            Content.AppendLine("      ,Config_Description")
            Content.AppendLine("      ,Config_Value")
            Content.AppendLine("      ,Create_User")
            Content.AppendLine("      ,Create_Time")
            Content.AppendLine("      ,Modified_User")
            Content.AppendLine("      ,Modified_Time")
            Content.AppendLine("  FROM PUB_Config")
            Content.AppendLine("  where Config_Name like '" & configName.Replace("'", "''") & "%'  ")

            command.CommandText = Content.ToString

            command.Parameters.AddWithValue("@configName", configName)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using

            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMD001", ex)

        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

#End Region



    Public Function queryPubConfigWhereConfigNameEquals(ByVal ConfigName As String, Optional ByRef conn As IDbConnection = Nothing) As System.Data.DataSet 'Implements IPubConfigBO.queryPubConfigWhereConfigNameEquals
        Dim connFlag As Boolean = conn Is Nothing
        Try
            'Dim sqlStr As String = "select Config_Name, Config_Description, Config_Value from " & tableName & " where Config_Name = '" & ConfigName & "'"

            ''執行SQL
            'Using rtnDS As New DataSet
            '    Using tempDT As DataTable = SQLDataUtil.getInstance.execSQL(sqlStr, Nothing, "select1", New String() {tableName})
            '        rtnDS.Tables.Add(tempDT)

            '        Return rtnDS
            '    End Using
            'End Using
            Dim ds As DataSet


            '2014-10-14 Sean 將 Arm connection 改成 Connection
            'Dim sqlConn As SqlConnection = CType(getAuthenticConnection(), SqlConnection)

            Dim sqlConn As SqlConnection = Nothing 'CType(getConnection(), SqlConnection)

            If connFlag Then
                sqlConn = CType(getConnection(), SqlConnection)
                sqlConn.Open()
            Else
                sqlConn = conn
            End If

            Dim command As SqlCommand = sqlConn.CreateCommand()


            command.CommandText = "select Config_Name, Config_Description, Config_Value from " & tableName & " where Config_Name = '" & ConfigName & "'"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using


            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' get confing
    ''' </summary>
    ''' <param name="configName">config name</param>
    ''' <returns>selected data.</returns>
    ''' <remarks></remarks>
    Public Function queryPUBConfigConsumptionDept(ByVal configName As String) As DataSet

        Dim _ds As New DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.AppendFormat("SELECT Rtrim(Config_Value)       AS Consumption_Dept, " & vbCrLf)
        var1.AppendFormat("       'N'                       AS Is_Standing " & vbCrLf)
        var1.AppendFormat("FROM   PUB_Config " & vbCrLf)
        var1.AppendFormat("WHERE  Config_Name = '{0}' " & vbCrLf, configName.Replace("'", "''"))

        Try
            Using _sqlConnection As SqlConnection = CType(getConnection(), SqlConnection)
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(var1.ToString, _sqlConnection)
                _dataAdapter.Fill(_ds, "PUB_Config")
            End Using
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

        Return _ds
    End Function

    Public Function queryPUBConfigWhereConfigNameIn(ByVal configName As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = " Select * From " & tableName & " Where Config_Name In (" & configName & ") "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    ''' <summary>
    ''' 取得所有國際疫苗之醫令碼
    ''' </summary>
    ''' <returns>國際疫苗</returns>
    ''' <author>Ken</author>
    ''' <date>2009-10-31</date>
    ''' <tables>
    ''' Pub_Config
    ''' </tables>
    ''' <remarks></remarks>
    Public Function GetInternationalVaccines() As List(Of String)
        Dim _list As New List(Of String)

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT A.Config_Name, " & vbCrLf)
        var1.Append("       A.Config_Description, " & vbCrLf)
        var1.Append("       A.Config_Value " & vbCrLf)
        var1.Append("FROM   Pub_Config A " & vbCrLf)
        var1.Append("WHERE  A.Config_Name = 'OMO_Vaccines_Apply'")

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = getConnection()

                Dim _command As New SqlCommand(var1.ToString, _sqlConnection)
                _command.CommandType = CommandType.Text

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, tableName)
            End Using
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

        Dim _dt As DataTable = _ds.Tables(tableName)

        Dim _vaccinesStr As String = ""

        Try
            _vaccinesStr = _dt.Rows(0)("Config_Value").ToString.Trim
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

        If String.Compare(_vaccinesStr, String.Empty) = 0 Then Return _list

        Dim _vaccines() As String = _vaccinesStr.Split(",")

        _list.AddRange(_vaccines)

        Return _list
    End Function

    Public Function GetDentalExtendDays() As Int32

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(Config_Value) DEP_Dental_Extend_Days " & vbCrLf)
        var1.Append("FROM   PUB_Config " & vbCrLf)
        var1.Append("WHERE  Config_Name = 'DEP_Dental_Ext_Days' " & vbCrLf)

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = getConnection()

                Dim _command As New SqlCommand(var1.ToString, _sqlConnection)
                _command.CommandType = CommandType.Text

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, tableName)
            End Using
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

        Dim _dt As DataTable = _ds.Tables(tableName)

        Dim _ExtDays As Int32 = 0
        Try
            Dim _ExtDaysStr As String = _dt.Rows(0)("DEP_Dental_Extend_Days").ToString
            _ExtDays = CInt(_ExtDaysStr)
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

        Return _ExtDays
    End Function

#Region " 查診展班週數 "

    ''' <summary>
    ''' 查診展班週數
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by ChenYu on 2015-09-10</remarks>
    Public Function QueryExpandWeek(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT Config_Value " & vbCrLf)
            varname1.Append("FROM   PUB_Config " & vbCrLf)
            varname1.Append("WHERE  Config_Name = 'REG_ExpandWeeks' ")


            command.CommandText = varname1.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Config")
                adapter.Fill(ds, "PUB_Config")
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

#End Region

#Region " 查詢TOCC關閉視窗之控制 "

    ''' <summary>
    ''' 查詢TOCC關閉視窗之控制
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by ChenYu on 2015-10-05</remarks>
    Public Function QueryTOCCCloseWindows(Optional ByRef conn As System.Data.IDbConnection = Nothing) As String

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT Config_Value " & vbCrLf)
            varname1.Append("FROM   PUB_Config " & vbCrLf)
            varname1.Append("WHERE  Config_Name = 'OMO_TOCC' ")


            command.CommandText = varname1.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Config")
                adapter.Fill(ds, "PUB_Config")
            End Using

            If CheckMethodUtil.CheckHasValue(ds) Then
                Return ds.Tables(0).Rows(0).Item("Config_Value").ToString.Trim
            Else
                Return "N"
            End If

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

#End Region

End Class
