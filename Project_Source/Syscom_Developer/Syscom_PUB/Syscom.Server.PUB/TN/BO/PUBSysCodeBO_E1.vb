Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PUBSysCodeBO_E1
    Inherits PubSyscodeBO

    Dim tableName1 As String = "PUB_SYSCODE"
    Dim log As LOGDelegate = LOGDelegate.getInstance
    Private Shared instance As PUBSysCodeBO_E1

    Public Overloads Shared Function getInstance() As PUBSysCodeBO_E1
        instance = New PUBSysCodeBO_E1
        Return instance
    End Function

#Region "     查詢 Method (For多筆維護UI用，使用LIKE 'PKey%') "
    ''' <summary>
    '''查詢(依PKey)
    ''' </summary>
    ''' <returns>查詢結果</returns>
    ''' <remarks>by Alan Tsai on 2014-11-09</remarks>
    Public Function queryPUBSyscodeLikePKey(ByVal inType_Id As String, ByVal inCode_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
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
            content.AppendLine(" RTRIM(Code_Id) as Code_Id , RTRIM(Code_En_Name) as Code_En_Name  , RTRIM(Code_Name) as Code_Name  , Is_Default ,  ")
            content.AppendLine(" Sort_Value , Dc , Create_User , dbo.ADTOROCTime(Create_Time) , Modified_User ,  ")
            content.AppendLine(" dbo.ADTOROCTime(Modified_Time)                from " & tableName)
            content.AppendLine("   where Type_Id=@Type_Id         ")

            If inCode_Id <> "" Then
                content.AppendLine("   and Code_Id=@Code_Id            ")
            End If

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Type_Id", inType_Id)
            command.Parameters.AddWithValue("@Code_Id", inCode_Id & "%")

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
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

    ''' <summary>
    '''查詢(依PKey)
    ''' </summary>
    ''' <returns>查詢結果</returns>
    ''' <remarks>by James on 2014-11-09</remarks>
    Public Function queryPUBSyscodePKey(ByVal inType_Id As String, ByVal inCode_Id As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
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
            content.AppendLine(" Code_Id , Code_En_Name , Code_Name , Is_Default ,  ")
            content.AppendLine(" Sort_Value , Dc , Create_User , dbo.ADTOROCTime(Create_Time) , Modified_User ,  ")
            content.AppendLine(" dbo.ADTOROCTime(Modified_Time)                from " & tableName)
            content.AppendLine("   where Type_Id=@Type_Id         ")

            If inCode_Id <> "" Then
                content.AppendLine("   and Code_Id=@Code_Id            ")
            End If

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Type_Id", inType_Id)
            command.Parameters.AddWithValue("@Code_Id", inCode_Id)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
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


    ''' <summary>
    '''查詢全部
    ''' </summary>
    ''' <returns>查詢結果</returns>
    ''' <remarks>by Alan Tsai on 2014-11-09</remarks>
    Public Overloads Function queryPUBSyscodeAll(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
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
            content.AppendLine(" Code_Id , Code_En_Name , Code_Name , Is_Default ,  ")
            content.AppendLine(" Sort_Value , Dc , Create_User , dbo.ADTOROCTime(Create_Time) , Modified_User ,  ")
            content.AppendLine(" dbo.ADTOROCTime(Modified_Time)                from " & tableName)
            command.CommandText = content.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
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

    '依傳入TypeID取得代碼檔資料
    Public Overloads Function queryPUBSysCodeAll(ByVal TypeID As String, Optional ByVal multiCodeIdFlag As Boolean = False, Optional ByRef conn As IDbConnection = Nothing) As System.Data.DataSet 'Implements IPUBSysCodeBO.queryPUBSysCodeAll

        Dim cmdStr As New StringBuilder

        Try
            Dim typeIDArray() As String = TypeID.Split(New Char() {","})
            Dim tbName(typeIDArray.Length - 1) As String

            For iIndex As Integer = 0 To typeIDArray.Length - 1

                tbName(iIndex) = "typeId" & typeIDArray(iIndex)

                'SQL
                cmdStr.AppendLine("select")
                cmdStr.AppendLine("rtrim(Code_Id) as Code_Id,")
                cmdStr.AppendLine("rtrim(Code_Name) as Code_Name,")
                cmdStr.AppendLine("rtrim(Code_En_Name) as Code_En_Name,")
                cmdStr.AppendLine("Is_Default")
                cmdStr.AppendLine("from " & tableName1)
                cmdStr.AppendLine("where 1=1")
                cmdStr.AppendLine("and DC <> 'Y'")
                cmdStr.AppendLine("and Type_Id='" & typeIDArray(iIndex) & "'")
                cmdStr.AppendLine("Order By Sort_Value,Code_Id")
                cmdStr.AppendLine("---------------------------------------")

                If Not multiCodeIdFlag Then
                    Exit For
                End If
            Next

            '執行SQL
            If multiCodeIdFlag Then
                Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select2", tbName, conn)
            Else
                '原Code
                Using sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
                    Using command As SqlCommand = sqlConn.CreateCommand()

                        command.CommandText = cmdStr.ToString

                        Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                            Using ds As DataSet = New DataSet(tableName1)
                                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                                adapter.Fill(ds, tableName1)

                                Return ds
                            End Using
                        End Using
                    End Using
                End Using
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

#Region "     新增 Method (For多筆維護UI用) "
    ''' <summary>
    '''新增
    ''' </summary>
    ''' <returns>新增筆數</returns>
    ''' <remarks>by Alan Tsai on 2014-11-09</remarks>
    Public Function insertPUBSyscodeByRowData(ByVal inTypeId As String,
                                              ByVal inCodeId As String,
                                              ByVal inCodeEnName As String,
                                              ByVal inCodeName As String,
                                              ByVal inIsDefault As String,
                                              ByVal inSortValue As String,
                                              ByVal inDc As String,
                                              ByVal inCreate_User As String,
                                              ByVal inCreate_Time As DateTime,
                                              ByVal inModified_Name As String,
                                              ByVal inModified_Time As DateTime,
                                              Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Type_Id , Code_Id , Code_En_Name , Code_Name , Is_Default ,  " & _
             " Sort_Value , Dc , Create_User , Create_Time , Modified_User ,  " & _
             " Modified_Time ) " & _
             " values( @Type_Id , @Code_Id , @Code_En_Name , @Code_Name , @Is_Default ,  " & _
             " @Sort_Value , @Dc , @Create_User , @Create_Time , @Modified_User ,  " & _
             " @Modified_Time             )"
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
                command.Parameters.AddWithValue("@Type_Id", inTypeId)
                command.Parameters.AddWithValue("@Code_Id", inCodeId)
                command.Parameters.AddWithValue("@Code_En_Name", inCodeEnName)
                command.Parameters.AddWithValue("@Code_Name", inCodeName)
                command.Parameters.AddWithValue("@Is_Default", inIsDefault)
                command.Parameters.AddWithValue("@Sort_Value", inSortValue)
                command.Parameters.AddWithValue("@Dc", inDc)
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
    ''' <remarks>by Alan Tsai on 2014-11-09</remarks>
    Public Function updatePUBSyscodeByRowData(ByVal inTypeId As String,
                                              ByVal inCodeId As String,
                                              ByVal inCodeEnName As String,
                                              ByVal inCodeName As String,
                                              ByVal inIsDefault As String,
                                              ByVal inSortValue As String,
                                              ByVal inDc As String,
                                              ByVal inModified_Name As String,
                                              ByVal inModified_Time As DateTime,
                                              Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Code_En_Name=@Code_En_Name , Code_Name=@Code_Name , Is_Default=@Is_Default " & _
            "  , Sort_Value=@Sort_Value , Dc=@Dc , Modified_User=@Modified_User " & _
            "  , Modified_Time=@Modified_Time " & _
            " where  Type_Id=@Type_Id and Code_Id=@Code_Id            "
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
                command.Parameters.AddWithValue("@Type_Id", inTypeId)
                command.Parameters.AddWithValue("@Code_Id", inCodeId)
                command.Parameters.AddWithValue("@Code_En_Name", inCodeEnName)
                command.Parameters.AddWithValue("@Code_Name", inCodeName)
                command.Parameters.AddWithValue("@Is_Default", inIsDefault)
                command.Parameters.AddWithValue("@Sort_Value", inSortValue)
                command.Parameters.AddWithValue("@Dc", inDc)
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
    Public Function deletePubSyscodeByPK(ByRef pk_Type_Id As System.Int32, ByRef pk_Code_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
             " Type_Id=@Type_Id and Code_Id=@Code_Id "
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
                command.Parameters.AddWithValue("@Type_Id", pk_Type_Id)
                command.Parameters.AddWithValue("@Code_Id", pk_Code_Id)
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

    ''依傳入TypeID取得代碼檔資料
    'Public Overloads Function queryPUBSysCodeAll(ByVal TypeID As String, Optional ByVal multiCodeIdFlag As Boolean = False, Optional ByRef conn As IDbConnection = Nothing) As System.Data.DataSet 'Implements IPUBSysCodeBO.queryPUBSysCodeAll

    '    Dim cmdStr As New StringBuilder

    '    Try
    '        Dim typeIDArray() As String = TypeID.Split(New Char() {","})
    '        Dim tbName(typeIDArray.Length - 1) As String

    '        For iIndex As Integer = 0 To typeIDArray.Length - 1

    '            tbName(iIndex) = "typeId" & typeIDArray(iIndex)

    '            'SQL
    '            cmdStr.AppendLine("select")
    '            cmdStr.AppendLine("rtrim(Code_Id) as Code_Id,")
    '            cmdStr.AppendLine("rtrim(Code_Name) as Code_Name,")
    '            cmdStr.AppendLine("rtrim(Code_En_Name) as Code_En_Name,")
    '            cmdStr.AppendLine("Is_Default")
    '            cmdStr.AppendLine("from " & tableName1)
    '            cmdStr.AppendLine("where 1=1")
    '            cmdStr.AppendLine("and DC <> 'Y'")
    '            cmdStr.AppendLine("and Type_Id='" & typeIDArray(iIndex) & "'")
    '            cmdStr.AppendLine("Order By Sort_Value,Code_Id")
    '            cmdStr.AppendLine("---------------------------------------")

    '            If Not multiCodeIdFlag Then
    '                Exit For
    '            End If
    '        Next

    '        '執行SQL
    '        If multiCodeIdFlag Then
    '            Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select2", tbName, conn)
    '        Else
    '            '原Code
    '            Using sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
    '                Using command As SqlCommand = sqlConn.CreateCommand()

    '                    command.CommandText = cmdStr.ToString

    '                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
    '                        Using ds As DataSet = New DataSet(tableName1)
    '                            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
    '                            adapter.Fill(ds, tableName1)

    '                            Return ds
    '                        End Using
    '                    End Using
    '                End Using
    '            End Using
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Overloads Function queryPUBSysCodeAll2(ByVal SourceType As String, ByVal TypeID As String, Optional ByVal multiCodeIdFlag As Boolean = False, Optional ByRef conn As IDbConnection = Nothing) As System.Data.DataSet

    '    Dim cmdStr As New StringBuilder
    '    Dim pvtMergeSQL As String = "'"

    '    Select Case SourceType
    '        Case "O"
    '            pvtMergeSQL = " And Is_Opd='Y' "
    '        Case "E"
    '            pvtMergeSQL = " And Is_Emg='Y' "
    '        Case "I"
    '            pvtMergeSQL = " And Is_Ipd='Y' "
    '    End Select

    '    Try
    '        Dim typeIDArray() As String = TypeID.Split(New Char() {","})
    '        Dim tbName(typeIDArray.Length - 1) As String

    '        For iIndex As Integer = 0 To typeIDArray.Length - 1

    '            tbName(iIndex) = "typeId" & typeIDArray(iIndex)

    '            'SQL
    '            cmdStr.AppendLine("select")
    '            cmdStr.AppendLine("rtrim(Code_Id) as Code_Id,")
    '            cmdStr.AppendLine("rtrim(Code_Name) as Code_Name,")
    '            cmdStr.AppendLine("rtrim(Code_En_Name) as Code_En_Name,")
    '            cmdStr.AppendLine("Is_Default")
    '            cmdStr.AppendLine("from " & tableName1)
    '            cmdStr.AppendLine("where 1=1")
    '            cmdStr.AppendLine("and DC <> 'Y'")
    '            cmdStr.AppendLine("and Type_Id='" & typeIDArray(iIndex) & "'")
    '            cmdStr.AppendLine(pvtMergeSQL)
    '            cmdStr.AppendLine("Order By Sort_Value,Code_Id")
    '            cmdStr.AppendLine("---------------------------------------")

    '            If Not multiCodeIdFlag Then
    '                Exit For
    '            End If
    '        Next

    '        '執行SQL
    '        If multiCodeIdFlag Then
    '            Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select2", tbName, conn)
    '        Else
    '            '原Code
    '            Dim ds As DataSet
    '            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
    '            Dim command As SqlCommand = sqlConn.CreateCommand()
    '            command.CommandText = cmdStr.ToString
    '            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
    '                ds = New DataSet(tableName1)
    '                adapter.Fill(ds, tableName1)
    '                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
    '            End Using
    '            Return ds
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    '依傳入TypeID取得代碼檔資料
    Public Overloads Function queryPUBSysCodebyCombobox(ByVal TypeID As String) As System.Data.DataSet 'Implements IPUBSysCodeBO.queryPUBSysCodeAll
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "   Select RTRIM(Code_Id) as Code_Id,RTRIM(Code_Name) as Code_Name ,RTRIM(Code_En_Name) as Code_En_Name ,Code_Id +' - '+ Code_Name as cbo_Name " & _
                                    " From " & tableName1 & " " & _
                                    " Where Type_Id='" & TypeID & "' And DC='N' " & _
                                    " Order By Sort_Value,Code_Id"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
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
    ''' 給號組別基本設定
    ''' </summary>
    ''' <param name="TypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function queryPUBSysCodebyTypeId(ByVal TypeId As Integer) As DataSet

        Try
            Dim ds As DataSet
            Using sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
                Using command As SqlCommand = sqlConn.CreateCommand()

                    command.CommandText = "SELECT * " & _
                                           " FROM " & tableName1 & " WITH(NOLOCK)" & _
                                          " WHERE Type_Id = @TypeID" & _
                                            " AND DC='N'" & _
                                          " ORDER BY Sort_Value,Code_Id"

                    command.Parameters.AddWithValue("@TypeID", TypeId)

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        ds = New DataSet(tableName1)
                        adapter.Fill(ds, tableName1)
                        adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
                    End Using
                    Return ds
                End Using
            End Using
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try

    End Function

    '''' <summary>
    '''' 查詢代碼資料
    '''' </summary>
    '''' <param name="TypeId">代碼</param>
    '''' <returns></returns>
    '''' <remarks>20090803 add by Rich</remarks>
    Public Function queryPUBSysCodeInCond(ByVal TypeId As String, Optional ByVal multiCodeIdFlag As Boolean = False, Optional ByRef conn As IDbConnection = Nothing) As DataSet

        Dim cmdStr As New StringBuilder

        Try
            'SQL
            cmdStr.AppendLine("select")
            cmdStr.AppendLine("rtrim(Code_Id) as Code_Id,")
            cmdStr.AppendLine("rtrim(Code_Name) as Code_Name,")
            cmdStr.AppendLine("rtrim(Code_En_Name) as Code_En_Name,")
            cmdStr.AppendLine("Is_Default,")
            cmdStr.AppendLine("rtrim(Type_Id) as Type_Id")
            cmdStr.AppendLine("from " & tableName1)
            cmdStr.AppendLine("where 1=1")
            cmdStr.AppendLine("and DC <> 'Y'")
            cmdStr.AppendLine("and Type_Id in (" & TypeId & ")")
            cmdStr.AppendLine("Order By Type_Id,Sort_Value,Code_Id")

            '執行SQL
            If multiCodeIdFlag Then
                Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select2", Nothing, conn)
            Else
                '原Code
                Dim ds As DataSet
                Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = cmdStr.ToString
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds = New DataSet(tableName1)
                    adapter.Fill(ds, tableName1)
                    adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
                End Using
                Return ds
            End If



            'Dim ds As DataSet
            'Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            'Dim command As SqlCommand = sqlConn.CreateCommand()
            'command.CommandText = " Select RTRIM(Code_Id) as Code_Id, RTRIM(Code_Name) as Code_Name, " & _
            '                      "        RTRIM(Code_En_Name) as Code_En_Name, Is_Default, RTRIM(Type_Id) as Type_Id " & _
            '                      " From " & tableName1 & " " & _
            '                      " Where Type_Id IN (" & TypeId & ") And DC='N' " & _
            '                      " Order By Type_Id, Sort_Value, Code_Id "
            'Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
            '    ds = New DataSet(tableName1)
            '    adapter.Fill(ds, tableName1)
            '    adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            'End Using
            'Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢代碼資料
    ''' </summary>
    ''' <param name="Code_Id">組別代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBSysCodeByCode(ByVal Code_Id As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " Select  RTRIM(Code_Id) as Code_Id, RTRIM(Code_Name) as Code_Name, " & _
                                  "        RTRIM(Code_En_Name) as Code_En_Name,RTRIM(DC) as DC, Is_Default " & _
                                  " From " & tableName1 & " " & _
                                  " Where  TYPE_Id=10"
            If Not Code_Id.Equals("") Then
                command.CommandText = command.CommandText + " and Code_Id='" + Code_Id + "'"

            End If



            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
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
    ''' 給號組別基本設定
    ''' </summary>
    ''' <param name="select1"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function InitUI(ByVal select1 As Integer) As DataSet

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Select Case select1
                Case 0
                    command.CommandText = " Select RTRIM(Code_Id) as Code_Id, RTRIM(Code_Name) as Code_Name " & _
                                          " From " & tableName1 & " " & _
                                          " Where Type_Id=73 And DC='N' "


                Case 1
                    command.CommandText = " Select RTRIM(Code_Id) as Code_Id, RTRIM(Code_Name) as Code_Name " & _
                                          " From " & tableName1 & " " & _
                                          " Where Type_Id=9 And DC='N' "


            End Select

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
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


    Public Overloads Function Update(ByVal ds As DataTable) As Integer
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Type_Id=@Type_Id " & _
            "  , Dc=@Dc , Code_Id=@Code_Id , Code_En_Name=@Code_En_Name,Code_Name=@Code_Name" & _
            "" & _
            " where  Type_Id=@Type_Id and Code_Id=@Code_Id"
            Using conn As System.Data.IDbConnection = getConnection()
                conn.Open()
                For Each row As DataRow In ds.Rows
                    Using command As SqlCommand = New SqlCommand
                        With command
                            .CommandText = sqlString
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                        End With
                        command.Parameters.AddWithValue("@Type_Id", row.Item("Type_Id"))
                        command.Parameters.AddWithValue("@Code_Id", row.Item("Code_Id"))
                        command.Parameters.AddWithValue("@Code_En_Name", row.Item("Code_En_Name"))
                        command.Parameters.AddWithValue("@Code_Name", row.Item("Code_Name"))
                        command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Dim cnt As Integer = command.ExecuteNonQuery
                        count = count + cnt
                    End Using
                Next
            End Using
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Public Overloads Function delete(ByRef Type_Id As System.String, ByRef Code_Id As System.String) As Integer
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & "" & _
           " where  Type_Id=@Type_Id and Code_Id=@Code_Id"
            Using conn As System.Data.IDbConnection = getConnection()
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Type_Id", Type_Id)
                    command.Parameters.AddWithValue("@Code_Id", Code_Id)
                    conn.Open()
                    count = command.ExecuteNonQuery
                End Using
            End Using
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
    Public Function QuerySn(ByVal Sn_id As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " Select RTRIM(Reg_Sn) as Reg_Sn,RTRIM(Reg_Sn_Id) as Reg_Sn_Id" & _
                                         " From REG_Sn_Group " & _
                                         " Where Reg_Group_Id='" + Sn_id + "'"
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
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
    Public Function QueryPharmacy(ByVal Duty_id) As DataSet
        Try


            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select RTRIM(OJS.Employee_Code) as Code,Employee_Name as Name,OJS.Employee_Code +' - '+ Employee_Name as display    from  OPH_Job_Sheet as OJS  inner join OPH_Pharmacist as OPHP on OPHP.Employee_Code=OJS.Employee_Code  where OJS.Available_Duty_Id=@DutyID and getdate() between OJS.Effect_date  and OJS.End_Date"
            command.Parameters.AddWithValue("@DutyID", Duty_id)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Init")
                adapter.Fill(ds, "t1")
                adapter.FillSchema(ds, SchemaType.Mapped, "t1")
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
    ''' 找多個TypeId的syscode
    ''' </summary>
    ''' <param name="TypeIds"></param>
    ''' <returns></returns>
    ''' <remarks>Add by Jen</remarks>
    Public Function querySyscodeByTypeIds(ByVal TypeIds() As Integer) As DataTable

        '----------------------------------------------------------------------------
        'select * from PUB_Syscode where Type_Id in (").Append("23, 24, 28, 29, 34, 209, 210, 615, 616, 617, 618, 619, 622").Append(") and Dc <> 'Y' ")
        'CommandStr.Append("order by Type_Id, Sort_Value asc
        Dim typeStr As New StringBuilder

        If TypeIds IsNot Nothing AndAlso TypeIds.Length > 0 Then

            For i As Integer = 0 To (TypeIds.Length - 1)
                typeStr.Append(TypeIds(i)).Append(",")
            Next

            If typeStr.Length > 0 Then
                typeStr.Remove(typeStr.Length - 1, 1)
            End If

            Dim cmdStr As New StringBuilder
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
            cmdStr.AppendLine("where Type_Id in ( ")
            cmdStr.AppendLine(typeStr.ToString)
            cmdStr.AppendLine(") ")
            '----------------------------------------------------------------------------
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("order by Type_Id, Sort_Value asc ")
            '----------------------------------------------------------------------------
            Try
                Dim dt As DataTable = Nothing

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()

                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            'sqlCmd.Parameters.AddWithValue("@ChartNo", ChartNo)

                        End With

                        conn.Open()

                        Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                            dt = New DataTable(tableName)
                            da.Fill(dt)
                        End Using

                    End Using
                End Using

                Return dt
            Catch sqlex As SqlException
                Throw New SQLDatabaseException(sqlex)
            Catch cmex As CommonException
                Throw cmex
            Catch ex As Exception
                Throw New CommonException("CMMCMMD001", ex)
            End Try
        Else
            '沒傳參數進來
            Return Nothing
        End If

    End Function
    '依傳入TypeID取得代碼檔資料
    Public Function queryPUBSyscode(ByVal TypeID As String, ByVal tblName As String) As System.Data.DataTable
        Try
            Using sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
                Using command As SqlCommand = sqlConn.CreateCommand()

                    command.CommandText = "SELECT RTRIM(Code_Id) AS Code_Id, RTRIM(Code_Name) AS Code_Name" & _
                                           " FROM " & tableName1 & " WITH(NOLOCK)" & _
                                          " WHERE Type_Id = @TypeID" & _
                                            " AND DC='N'" & _
                                          " ORDER BY Sort_Value,Code_Id"

                    command.Parameters.AddWithValue("@TypeID", TypeID)

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        Using dt As DataTable = New DataTable(tblName)
                            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            adapter.Fill(dt)

                            Return dt
                        End Using
                    End Using
                End Using
            End Using
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    '#Region "20100210 醫令查詢 by yaya"
    '    ''' <summary>
    '    ''' 醫令查詢畫面初始化ComboBox載入資料
    '    ''' </summary>
    '    ''' <returns>DataSet</returns>
    '    ''' <remarks>
    '    ''' Pub_Syscode_Order:醫令類型
    '    ''' Pub_Syscode_Fee:費用項目
    '    ''' </remarks>
    '    Public Function InitialOrderItems() As DataSet
    '        Try
    '            Dim sqlCommand As StringBuilder = New StringBuilder()
    '            Using conn As System.Data.IDbConnection = getConnection()
    '                '醫令類型
    '                sqlCommand.Append("Select  RTRIM(Code_Id) as Code_Id,RTRIM(Code_Name) as Code_Name,(RTRIM(Code_Id)+' - '+RTRIM(Code_Name)) as Code_CB ")
    '                sqlCommand.Append(" FROM PUB_Syscode WHERE Type_Id=@Type_Id_Order and Dc=@DC_N")
    '                '間隔
    '                sqlCommand.Append(" ; ")
    '                '費用項目
    '                sqlCommand.Append("Select  RTRIM(Code_Id) as Code_Id,RTRIM(Code_Name) as Code_Name,(RTRIM(Code_Id)+' - '+RTRIM(Code_Name)) as Code_CB ")
    '                sqlCommand.Append(" FROM PUB_Syscode WHERE Type_Id=@Type_Id_Fee and Dc=@DC_N")
    '                Using _dataset As DataSet = New DataSet()
    '                    Using command As SqlCommand = New SqlCommand
    '                        With command
    '                            .Parameters.AddWithValue("@Type_Id_Order", MagicNumbers.PUB_ORDER_CODE)
    '                            .Parameters.AddWithValue("@Type_Id_Fee", MagicNumbers.PUB_FEE_ITEMS)
    '                            .Parameters.AddWithValue("@DC_N", MagicNumbers.CODE_NO_DC_NO)
    '                            .CommandType = CommandType.Text
    '                            .Connection = CType(conn, SqlConnection)
    '                            .CommandText = sqlCommand.ToString
    '                        End With
    '                        Using _dataAdapter As SqlDataAdapter = New SqlDataAdapter(command)
    '                            _dataAdapter.TableMappings.Add("Table", "Pub_Syscode_Order")
    '                            _dataAdapter.TableMappings.Add("Table1", "Pub_Syscode_Fee")
    '                            _dataAdapter.Fill(_dataset)
    '                        End Using
    '                    End Using
    '                    Return _dataset
    '                End Using
    '            End Using
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function
    '#End Region

    Public Overloads Function queryPUBSysCodeAll2(ByVal SourceType As String, ByVal TypeID As String, Optional ByVal multiCodeIdFlag As Boolean = False, Optional ByRef conn As IDbConnection = Nothing) As System.Data.DataSet

        Dim cmdStr As New StringBuilder
        Dim pvtMergeSQL As String = " "

        'Select Case SourceType
        '    Case "O"
        '        pvtMergeSQL = " AND Is_Opd='Y' "
        '    Case "E"
        '        pvtMergeSQL = " AND Is_Emg='Y' "
        '    Case "I"
        '        pvtMergeSQL = " AND Is_Ipd='Y' "
        'End Select

        Try
            Dim typeIDArray() As String = TypeID.Split(New Char() {","})
            Dim tbName(typeIDArray.Length - 1) As String

            For iIndex As Integer = 0 To typeIDArray.Length - 1

                tbName(iIndex) = "typeId" & typeIDArray(iIndex)

                'SQL
                cmdStr.AppendLine("SELECT RTRIM(Code_Id) AS Code_Id" & _
                                       ", RTRIM(Code_Name) AS Code_Name" & _
                                       ", RTRIM(Code_En_Name) AS Code_En_Name" & _
                                       ", Is_Default" & _
                                   " FROM " & tableName1 & " WITH(NOLOCK)" & _
                                  " WHERE DC = 'N'" & _
                                    " AND Type_Id= '" & typeIDArray(iIndex) & "'" & _
                                    pvtMergeSQL & _
                                  " ORDER BY Sort_Value, Code_Id" & _
                                  "---------------------------------------")

                If Not multiCodeIdFlag Then
                    Exit For
                End If
            Next

            '執行SQL
            If multiCodeIdFlag Then
                Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select2", tbName, conn)
            Else
                '原Code
                Dim ds As DataSet
                Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = cmdStr.ToString
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds = New DataSet(tableName1)
                    adapter.Fill(ds, tableName1)
                    adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
                End Using
                Return ds
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#Region " 查詢"
    ''' <summary>
    '''以Type_Id查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByTypeId(ByRef pk_Type_Id As System.Int32, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Type_Id , ltrim(rtrim(Code_Id)) as Code_Id, Code_En_Name , Code_Name , Is_Default ,  ")
            content.AppendLine(" Sort_Value , Dc , Create_User , Create_Time , Modified_User ,  ")
            content.AppendLine(" Modified_Time                from " & tableName)
            content.AppendLine("   where Type_Id=@Type_Id            ")
            content.AppendLine("   order by Code_Id            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Type_Id", pk_Type_Id)
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
            Throw New CommonException("CMMCMMB911", ex)
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
