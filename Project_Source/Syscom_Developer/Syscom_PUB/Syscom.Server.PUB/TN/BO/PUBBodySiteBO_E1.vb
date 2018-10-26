Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility

Imports System.Text

Public Class PUBBodySiteBO_E1
    Inherits PubBodySiteBO

    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

#Region "########## getInstance ##########"

    Private Shared instance As PUBBodySiteBO_E1

    Public Overloads Shared Function getInstance() As PUBBodySiteBO_E1
        If instance Is Nothing Then
            instance = New PUBBodySiteBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 查詢大分類部位資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBBodySiteMainSiteData(Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim cmdStr As String

        Try
            'SQL
            cmdStr = "SELECT RTRIM(Body_Site_Code) AS Body_Site_Code" & _
                          ", RTRIM(Body_Site_Name) AS Body_Site_Name" & _
                      " FROM " & tableName & " WITH(NOLOCK)" & _
                     " WHERE Main_Body_Site_Code = Body_Site_Code" & _
                       " AND DC = 'N'"

            '執行SQL
            Try
                If conn Is Nothing Then
                    conn = getConnection()
                End If

                Using Command As SqlCommand = CType(conn, SqlConnection).CreateCommand

                    Command.CommandText = cmdStr.ToString

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                        Using ds As DataSet = New DataSet
                            adapter.Fill(ds, "table0")
                            Return ds
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try


            'Return SQLDataUtil.getInstance.execSQL(cmdStr, Nothing, "select2", Nothing, conn)

            'Dim returnDS As DataSet
            'Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            'Dim command As SqlCommand = sqlConn.CreateCommand()
            'command.CommandText = " Select Body_Site_Code,Body_Site_Name " & _
            '                      " From " & tableName & " " & _
            '                      " Where Main_Body_Site_Code = Body_Site_Code And DC = 'N' "
            'Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
            '    returnDS = New DataSet(tableName)
            '    adapter.Fill(returnDS, tableName)
            '    adapter.FillSchema(returnDS, SchemaType.Mapped, tableName)
            'End Using
            'Return returnDS
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢大分類部位資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBBodySiteMainSiteDataForApplyFlagREH(Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim cmdStr As String

        Try
            'SQL
            cmdStr = "SELECT RTRIM(Body_Site_Code) AS Body_Site_Code" & _
                          ", RTRIM(Body_Site_Name) AS Body_Site_Name" & _
                      " FROM " & tableName & " WITH(NOLOCK)" & _
                     " WHERE   Apply_Flag like 'RE%' " & _
                       " AND DC = 'N' " & _
                       " order by apply_flag "

            '執行SQL
            Try
                If conn Is Nothing Then
                    conn = getConnection()
                End If

                Using Command As SqlCommand = CType(conn, SqlConnection).CreateCommand

                    Command.CommandText = cmdStr.ToString

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                        Using ds As DataSet = New DataSet
                            adapter.Fill(ds, "table0")
                            Return ds
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try


            'Return SQLDataUtil.getInstance.execSQL(cmdStr, Nothing, "select2", Nothing, conn)

            'Dim returnDS As DataSet
            'Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            'Dim command As SqlCommand = sqlConn.CreateCommand()
            'command.CommandText = " Select Body_Site_Code,Body_Site_Name " & _
            '                      " From " & tableName & " " & _
            '                      " Where Main_Body_Site_Code = Body_Site_Code And DC = 'N' "
            'Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
            '    returnDS = New DataSet(tableName)
            '    adapter.Fill(returnDS, tableName)
            '    adapter.FillSchema(returnDS, SchemaType.Mapped, tableName)
            'End Using
            'Return returnDS
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 查詢部位資料
    ''' </summary>
    ''' <param name="MainBodySiteCode">部位大分類</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBBodySiteNotMainSiteData(ByVal MainBodySiteCode As String, Optional ByRef conn As IDbConnection = Nothing) As DataSet
        Dim cmdStr As New StringBuilder

        Try
            'SQL
            cmdStr.AppendLine("select")
            cmdStr.AppendLine("rtrim(Body_Site_Code) as Body_Site_Code,")
            cmdStr.AppendLine("rtrim(Body_Site_Name) as Body_Site_Name,")
            cmdStr.AppendLine("rtrim(Main_Body_Site_Code) as Main_Body_Site_Code")
            cmdStr.AppendLine("from " + tableName)
            cmdStr.AppendLine("where 1=1")
            cmdStr.AppendLine("and DC <> 'Y'")

            If MainBodySiteCode <> "" AndAlso MainBodySiteCode <> "MO" Then
                cmdStr.AppendLine("and Main_Body_Site_Code = '" & MainBodySiteCode & "'")
                cmdStr.AppendLine("and Main_Body_Site_Code <> Body_Site_Code")
            ElseIf MainBodySiteCode = "MO" Then
                cmdStr.AppendLine("and Body_Site_Code like '71%'")
            Else
                cmdStr.AppendLine("and Main_Body_Site_Code <> Body_Site_Code")
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim ReturnDS As DataSet

            command.CommandText = cmdStr.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ReturnDS = New DataSet()
                adapter.Fill(ReturnDS)
            End Using
             
            Return ReturnDS


            'Dim returnDS As DataSet
            'Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            'Dim command As SqlCommand = sqlConn.CreateCommand()
            'command.CommandText = " Select Body_Site_Code,Body_Site_Name,Main_Body_Site_Code " & _
            '                      " From " & tableName & " "
            'If MainBodySiteCode <> "" AndAlso MainBodySiteCode <> "MO" Then

            '    command.CommandText &= " Where Main_Body_Site_Code = '" & MainBodySiteCode & "' And Main_Body_Site_Code <> Body_Site_Code  And DC = 'N' "

            'ElseIf MainBodySiteCode = "MO" Then

            '    command.CommandText &= " Where Body_Site_Code like '71%'  And DC = 'N' "
            'Else
            '    command.CommandText &= " Where Main_Body_Site_Code <> Body_Site_Code And DC = 'N' "
            'End If
            'Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
            '    returnDS = New DataSet(tableName)
            '    adapter.Fill(returnDS, tableName)
            '    adapter.FillSchema(returnDS, SchemaType.Mapped, tableName)
            'End Using
            'Return returnDS
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：部位資訊
    ''' 開發人員：Jen
    ''' 開發日期：2009.12.07
    ''' </summary>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Body_Site
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/12/07, XXX
    ''' </修改註記>
    Public Function queryBodySideData() As DataTable

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
        cmdStr.AppendLine("where Dc <> @DcY ")
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("Order By Body_Site_Code ")
        Try
            Dim dt As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@DcY", "Y")

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

    ''' <summary>
    ''' 查詢外來片專用的部位代碼
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPUBBodySiteOnly1239() As DataSet

        Try
            '執行SQL
            Try
                Using conn = getConnection()
                    Using Command As SqlCommand = CType(conn, SqlConnection).CreateCommand

                        Command.CommandText = "SELECT RTRIM(Body_Site_Code) AS Body_Site_Code" & _
                                                   ", RTRIM(Body_Site_Name) AS Body_Site_Name" & _
                                               " FROM " & tableName & " WITH(NOLOCK)" & _
                                              " WHERE Main_Body_Site_Code = Body_Site_Code" & _
                                                " AND Body_Site_Code IN ('1','2','3','9')" & _
                                                " AND DC = 'N'" & _
                                              " ORDER BY Body_Site_Code ASC"

                        Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                            Using ds As DataSet = New DataSet
                                adapter.Fill(ds, "table0")
                                Return ds
                            End Using
                        End Using
                    End Using
                End Using

            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class