Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PUBSubIdentityBO_E1
    Inherits PubSubIdentityBO


    Dim tableName1 As String = "PUB_SUB_IDENTITY"
    Private Shared instance As PUBSubIdentityBO_E1

    Public Shared Shadows Function getInstance() As PUBSubIdentityBO_E1
        instance = New PUBSubIdentityBO_E1
        Return instance
    End Function

    'Private Function getConnection() As IDbConnection
    '    Return SQLConnFactory.getInstance.getPubDBSqlConn
    'End Function

    Public Function queryPUBSubIdentityAll(Optional ByVal inSourceType As String = "O") As System.Data.DataSet 'Implements IPUBSubIdentityBO.queryPUBSubIdentityAll
        Dim pvtAddSql As String = ""
        Select Case inSourceType.ToString.Trim
            Case "O"
                pvtAddSql = " And Is_Opd='Y' "

            Case "E"
                pvtAddSql = " And Is_Emg='Y' "

            Case "I"
                pvtAddSql = " And Is_Ipd='Y' "
            Case "H"
                pvtAddSql = " And Is_Ohm='Y' "

            Case "All"
                pvtAddSql = " And 1=1 "
        End Select

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "   Select RTRIM(Sub_Identity_Code) ,RTRIM(Main_Identity_Id) ,RTRIM(Sub_Identity_Name)  " & _
                                    " From  " & tableName1 & " " & _
                                    " Where  DC='N' " & pvtAddSql & _
                                    " Order By Sub_Identity_Code,Main_Identity_Id"

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

    ''' <summary>
    ''' 查詢計價主身分資料
    ''' </summary>
    ''' <param name="subIdentityCode">身分二代碼</param>
    ''' <returns>查詢結果</returns>
    ''' <author>Ken</author>
    ''' <tables>
    ''' PUB_Sub_Identity
    ''' </tables>
    ''' <remarks></remarks>
    Public Function queryPUBSubIdentityMainIdentity(ByVal subIdentityCode As String, Optional ByVal inSourceType As String = "O") As DataSet

        Dim var1 As New System.Text.StringBuilder
        Dim pvtAddSql As String = ""
        Select Case inSourceType.ToString.Trim
            Case "O"
                pvtAddSql = " And Is_Opd='Y' "

            Case "E"
                pvtAddSql = " And Is_Emg='Y' "

            Case "I"
                pvtAddSql = " And Is_Ipd='Y' "

        End Select

        var1.AppendFormat("SELECT Main_identity_id " & vbCrLf)
        var1.AppendFormat("FROM   Pub_sub_identity " & vbCrLf)
        var1.AppendFormat("WHERE  Sub_identity_code = '{0}' " & vbCrLf, subIdentityCode.Replace("'", "''"))
        var1.AppendFormat("       AND Dc <> 'Y' " & pvtAddSql & vbCrLf)

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = getConnection()
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(var1.ToString, _sqlConnection)
                _dataAdapter.Fill(_ds, "PUB_Sub_Identity")
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 查詢身分二所有資料
    ''' </summary>
    ''' <param name="MainIdentityId">主身分代碼</param>
    ''' <returns>查詢結果</returns>
    ''' <author>Alan</author>
    ''' <tables>
    ''' PUB_Sub_Identity
    ''' </tables>
    ''' <remarks></remarks>
    Public Function queryPUBSubIdentityByMain(ByVal MainIdentityId As String, Optional ByVal inSourceType As String = "O") As DataSet

        Dim var1 As New System.Text.StringBuilder
        Dim pvtAddSql As String = ""
        Select Case inSourceType.ToString.Trim
            Case "O"
                pvtAddSql = " And Is_Opd='Y' "

            Case "E"
                pvtAddSql = " And Is_Emg='Y' "

            Case "I"
                pvtAddSql = " And Is_Ipd='Y' "

        End Select

        var1.AppendFormat("SELECT Sub_Identity_Code,Sub_Identity_Name " & vbCrLf)
        var1.AppendFormat("FROM   Pub_Sub_Identity " & vbCrLf)
        var1.AppendFormat("WHERE  Main_Identity_Id = '{0}' " & vbCrLf, MainIdentityId.Replace("'", "''"))
        var1.AppendFormat("       AND Dc <> 'Y' " & pvtAddSql & vbCrLf)

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = getConnection()
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(var1.ToString, _sqlConnection)
                _dataAdapter.Fill(_ds, "PUB_Sub_Identity")
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function

    Public Function queryPUBSubIdentityByPK(ByVal mainIdentityId As String, ByVal subIdentityCode As String, Optional ByRef conn As IDbConnection = Nothing, Optional ByVal inSourceType As String = "O") As DataTable
        Try
            Dim cmdStr As New StringBuilder
            Dim connFlag As Boolean = conn Is Nothing
            Dim pvtAddSql As String = ""
            Select Case inSourceType.ToString.Trim
                Case "O"
                    pvtAddSql = " And Is_Opd='Y' "

                Case "E"
                    pvtAddSql = " And Is_Emg='Y' "

                Case "I"
                    pvtAddSql = " And Is_Ipd='Y' "

            End Select

            'SQL
            cmdStr.AppendLine("select * from Pub_Sub_Identity")
            cmdStr.AppendLine("where 1=1")
            cmdStr.AppendLine("and Sub_Identity_Code = '" & subIdentityCode & "'")
            cmdStr.AppendLine("and Main_Identity_Id = '" & mainIdentityId & "'")
            cmdStr.AppendLine("and isnull(Dc,'') = 'N'" & pvtAddSql)

            Dim _ds As New DataSet

            Try
                If connFlag Then
                    conn = getConnection()
                    conn.Open()
                End If

                Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
                Using _dataAdapter As SqlDataAdapter = New SqlDataAdapter(cmdStr.ToString, sqlConn)
                    _dataAdapter.Fill(_ds, "PUB_Sub_Identity")
                End Using
            Catch ex As Exception
                Throw ex
            Finally

                If connFlag AndAlso conn IsNot Nothing Then
                    conn.Close()
                    conn.Dispose()
                    conn = Nothing
                End If
            End Try

            Return _ds.Tables(0)

            '執行SQL
            'Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "select1", Nothing, conn)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
