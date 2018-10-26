Imports Syscom.Server.SQL
Imports System.Data.SqlClient

Public Class UclPrintConditionBS

    Private Shared instance As UclPrintConditionBS = Nothing

#Region "Constructor"

    Public Shared Function GetInstance() As UclPrintConditionBS
        Return New UclPrintConditionBS
    End Function

#End Region

    ''' <summary>
    ''' 查詢 Print Condition與Station_No
    ''' </summary>
    ''' <param name="Param">查詢參數</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryPrintCondition(ByVal Param As Dictionary(Of String, Object), Optional ByRef conn As IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Dim _ds As New DataSet

        Try
            If connFlag Then
                conn = getConnection()
            End If

            _ds.Tables.Add(Me.GetLoginUserPrintCond(Param, conn))
            _ds.Tables.Add(Me.GetAllStationNo(Param, conn))

        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

        Return _ds
    End Function

    ''' <summary>
    ''' 取得所有Station之Station_No
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAllStationNo(ByVal Param As Dictionary(Of String, Object), Optional ByRef conn As IDbConnection = Nothing) As DataTable

        Dim var1 As New System.Text.StringBuilder
        var1.Append("DECLARE @User_Station_No NVARCHAR(20) " & vbCrLf)
        var1.Append("SET @User_Station_No = (SELECT TOP (1) RTRIM(B.Station_No) AS Station_No " & vbCrLf)
        var1.Append("                        FROM   INP_Check_In_Out A " & vbCrLf)
        var1.Append("                               INNER JOIN INP_Bed B " & vbCrLf)
        var1.Append("                                 ON A.Bed_No = B.Bed_No " & vbCrLf)
        var1.Append("                        WHERE  A.Chart_No = @Chart_No " & vbCrLf)
        var1.Append("                               AND A.Case_No = @Case_No " & vbCrLf)
        var1.Append("                               AND A.In_Date <= @Now " & vbCrLf)
        var1.Append("                               AND ( A.Out_Date >= @Now " & vbCrLf)
        var1.Append("                                      OR A.Out_Date IS NULL )) " & vbCrLf)
        var1.Append(" ")
        var1.Append("SELECT RTRIM(A.Station_No) + ' - ' " & vbCrLf)
        var1.Append("       + RTRIM(ISNULL(A.Station_Name, '')) AS Station_Name, " & vbCrLf)
        var1.Append("       RTRIM(A.Station_No)                 AS Station_No, " & vbCrLf)
        var1.Append("       CASE " & vbCrLf)
        var1.Append("         WHEN @User_Station_No = A.Station_No THEN 'Y' " & vbCrLf)
        var1.Append("         ELSE 'N' " & vbCrLf)
        var1.Append("       END                                 AS Is_Default, " & vbCrLf)
        var1.Append("       RTRIM(B.Print_Cond)                 AS Print_Cond " & vbCrLf)
        var1.Append("FROM   Pub_Station A " & vbCrLf)
        var1.Append("       LEFT OUTER JOIN PUB_Terminal_Config B " & vbCrLf)
        var1.Append("                    ON A.Station_No = B.Term_Code " & vbCrLf)
        var1.Append("WHERE  1 = 1 " & vbCrLf)
        'var1.Append("       AND ( A.Stop_Flag = '' " & vbCrLf)
        'var1.Append("              OR A.Stop_Flag IS NULL " & vbCrLf)
        'var1.Append("              OR A.Stop_Flag = 'N' ) ")

        ' Param ------------------------------------------
        Dim _chartNo As String = String.Empty
        If Param.ContainsKey("Chart_No") Then
            _chartNo = Param("Chart_No")
        End If

        Dim _caseNo As String = String.Empty
        If Param.ContainsKey("Case_No") Then
            _caseNo = Param("Case_No")
        End If
        '-------------------------------------------------

        Dim connFlag As Boolean = conn Is Nothing

        Dim _dt As New DataTable
        _dt.TableName = "Station_No"

        Dim _now As Date = Now()

        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = conn
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = var1.ToString
            command.Parameters.AddWithValue("@Chart_No", _chartNo)
            command.Parameters.AddWithValue("@Case_No", _caseNo)
            command.Parameters.AddWithValue("@Now", _now.Date)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                adapter.Fill(_dt)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

        Return _dt
    End Function

    ''' <summary>
    ''' 取得登入者Term_Code所囑之Print Condition
    ''' </summary>
    ''' <param name="Param"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLoginUserPrintCond(ByVal Param As Dictionary(Of String, Object), Optional ByRef conn As IDbConnection = Nothing) As DataTable

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT RTRIM(A.Term_Code)              AS Term_Code, " & vbCrLf)
        var1.Append("       RTRIM(ISNULL(A.Station_No, '')) AS Station_No, " & vbCrLf)
        var1.Append("       RTRIM(ISNULL(A.Print_Cond, '')) AS Print_Cond " & vbCrLf)
        var1.Append("FROM   PUB_Terminal_Config A " & vbCrLf)
        var1.Append("WHERE  A.Term_Code = @Term_Code " & vbCrLf)


        ' Param ------------------------------------------
        Dim _termCode As String = String.Empty
        If Param.ContainsKey("Term_Code") Then
            _termCode = Param("Term_Code")
        End If
        '-------------------------------------------------

        Dim connFlag As Boolean = conn Is Nothing

        Dim _dt As New DataTable
        _dt.TableName = "Term_Code"

        Dim _now As Date = Now()

        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = conn
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = var1.ToString
            command.Parameters.AddWithValue("@Term_Code", _termCode)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                adapter.Fill(_dt)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

        Return _dt
    End Function

    Private Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn()
    End Function

End Class
