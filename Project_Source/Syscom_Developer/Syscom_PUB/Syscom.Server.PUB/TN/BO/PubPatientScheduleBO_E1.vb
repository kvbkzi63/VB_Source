Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PubPatientScheduleBO_E1
    Inherits PubPatientScheduleBO

#Region "########## getInstance ##########"
    Private Shared instance As PubPatientScheduleBO_E1
    Public Overloads Shared Function getInstance() As PubPatientScheduleBO_E1
        If instance Is Nothing Then
            instance = New PubPatientScheduleBO_E1
        End If
        Return instance
    End Function
    Private Sub New()
    End Sub
#End Region

    Public Function QueryByKeys(ByVal _chartNo As String, ByVal _bookDateBegin As Date) As DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.Append("SELECT Rtrim(Chart_No)          AS Chart_No, " & vbCrLf)
        var1.Append("       Book_Date, " & vbCrLf)
        var1.Append("       Book_Time, " & vbCrLf)
        var1.Append("       Rtrim(CheckIn_Dept_Code) AS CheckIn_Dept_Code " & vbCrLf)
        var1.Append("FROM   PUB_Patient_Schedule " & vbCrLf)
        var1.Append("WHERE  Chart_No = @chartNo " & vbCrLf)
        var1.Append("       AND Book_Date >= @date " & vbCrLf)


        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = getConnection()

                Dim _command As New SqlCommand(var1.ToString(), _sqlConnection)
                _command.CommandType = CommandType.Text
                _command.Parameters.AddWithValue("@chartNo", _chartNo)
                _command.Parameters.AddWithValue("@date", _bookDateBegin.Date)

                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(_command)
                _dataAdapter.Fill(_ds, tableName)
                _dataAdapter.FillSchema(_ds, SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds


        Return Nothing
    End Function

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="pk_Chart_No">Chart No</param>
    ''' <param name="pk_Book_Date">Book Date</param>
    ''' <param name="pk_Book_Time">Book Time</param>
    ''' <param name="pk_CheckIn_Dept_Code">Checkin Dept Code</param>
    ''' <param name="conn">connection</param>
    ''' <returns></returns>
    ''' <remarks>修改自Code Gen</remarks>
    Public Function DeleteByKeys(ByRef pk_Chart_No As System.String, ByRef pk_Book_Date As System.DateTime, ByRef pk_Book_Time As System.String, ByRef pk_CheckIn_Dept_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Chart_No=@Chart_No and Book_Date=@Book_Date and Book_Time=@Book_Time and CheckIn_Dept_Code=@CheckIn_Dept_Code " & _
            "  "
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
                command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)
                command.Parameters.AddWithValue("@Book_Date", pk_Book_Date)
                command.Parameters.AddWithValue("@Book_Time", pk_Book_Time)
                command.Parameters.AddWithValue("@CheckIn_Dept_Code", pk_CheckIn_Dept_Code)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="pk_Chart_No">Chart No</param>
    ''' <param name="pk_Book_Date">Book Date</param>
    ''' <param name="pk_Book_Time">Book Time</param>
    ''' <param name="pk_CheckIn_Dept_Code">Checkin Dept Code</param>
    ''' <param name="conn">connection</param>
    ''' <returns></returns>
    ''' <remarks>修改自Code Gen</remarks>
    Public Function QueryByPK2(ByRef pk_Chart_No As System.String, ByRef pk_Book_Date As System.DateTime, ByRef pk_Book_Time As System.String, ByRef pk_CheckIn_Dept_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  " & tableName & " where Chart_No=@Chart_No and Book_Date=@Book_Date and Book_Time=@Book_Time and CheckIn_Dept_Code=@CheckIn_Dept_Code           "
            command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)
            command.Parameters.AddWithValue("@Book_Date", pk_Book_Date)
            command.Parameters.AddWithValue("@Book_Time", pk_Book_Time)
            command.Parameters.AddWithValue("@CheckIn_Dept_Code", pk_CheckIn_Dept_Code)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#Region "For OPCAPI用 2009/09/22 Add By 谷官"

    ''' <summary>
    ''' 檢查是否要收掛號費
    ''' </summary>
    ''' <param name="outpatientSn">門診號</param>
    ''' <param name="chargeDate">門診批價日</param>
    ''' <returns>是否要收掛號費</returns>
    ''' <remarks>For OPCAPI用</remarks>
    Public Function checkNeedPayRegFeeOrNotForOPCAPI(ByVal outpatientSn As String, ByVal chargeDate As String) As String
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select")
        cmdStr.AppendLine("case count(*)")
        cmdStr.AppendLine("when 0 then 'N'")
        cmdStr.AppendLine("else 'Y'")
        cmdStr.AppendLine("End")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from PUB_Patient_Schedule")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where 1=1")
        cmdStr.AppendLine("and Medical_Sn=@Medical_Sn")
        cmdStr.AppendLine("and Book_Date=@Book_Date")
        cmdStr.AppendLine("and Is_PreLend_Chart=@Is_PreLend_Chart")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@Medical_Sn", outpatientSn)
                        sqlCmd.Parameters.AddWithValue("@Book_Date", chargeDate)
                        sqlCmd.Parameters.AddWithValue("@Is_PreLend_Chart", "Y")

                    End With

                    conn.Open()

                    Return sqlCmd.ExecuteScalar()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    Public Function queryPUBPatientScheduleSchema() As DataSet
        Try
            Using sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
                Using command As SqlCommand = sqlConn.CreateCommand()
                    command.CommandText = "SELECT * FROM PUB_Patient_Schedule WITH(NOLOCK) WHERE 1=2"

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        Using ds As DataSet = New DataSet("PUB_Patient_Schedule")
                            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            adapter.Fill(ds, "PUB_Patient_Schedule")

                            Return ds
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function DeleteByKeysForOrderSchedule(ByVal ChartNo As String, ByVal BookDate As Date, ByVal BookTime As String, ByVal CheckInDeptCode As String, ByVal CheckInSectionId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Int32

        Dim connFlag As Boolean = conn Is Nothing

        Dim var1 As New System.Text.StringBuilder
        var1.Append("DELETE PUB_Patient_Schedule " & vbCrLf)
        var1.Append("WHERE  Chart_No = @Chart_No " & vbCrLf)
        var1.Append("       AND Book_Date = @Book_Date " & vbCrLf)
        var1.Append("       AND Book_Time = @Book_Time " & vbCrLf)
        var1.Append("       AND CheckIn_Dept_Code = @CheckIn_Dept_Code " & vbCrLf)
        var1.Append("       AND CheckIn_Section_Id = @CheckIn_Section_Id " & vbCrLf)

        Try
            If connFlag Then
                conn = getConnection()
            End If

            Dim count As Int32 = 0
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = var1.ToString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Chart_No", ChartNo)
                command.Parameters.AddWithValue("@Book_Date", BookDate.Date)
                command.Parameters.AddWithValue("@Book_Time", BookTime)
                command.Parameters.AddWithValue("@CheckIn_Dept_Code", CheckInDeptCode)
                command.Parameters.AddWithValue("@CheckIn_Section_Id", CheckInSectionId)

                If conn.State <> ConnectionState.Open Then conn.Open()

                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag Then
                conn.Dispose()
            End If
        End Try

    End Function

#Region "住院健檢 申請調閱病歷/取消調閱病歷"
    ''' <summary>
    ''' 申請調閱病歷
    ''' </summary>
    ''' <param name="typeId">E:健檢</param>
    ''' <param name="chartNo">病歷號</param>
    ''' <param name="prelendDate">調閱日期</param>
    ''' <param name="bookingTime">調閱時間</param>
    ''' <param name="deptCode">科</param>
    ''' <param name="sectionId">診</param>
    ''' <param name="IsPrelendChart">是否要調閱</param>
    ''' <param name="bookState"></param>
    ''' <returns>-1:表示錯誤</returns>
    ''' <remarks></remarks>
    Public Function InsertPatientSchedule(ByVal typeId As String, ByVal chartNo As String, ByVal prelendDate As String, ByVal bookingTime As String, _
                                          ByVal deptCode As String, ByVal sectionId As String, Optional ByVal IsPrelendChart As String = "Y", _
                                          Optional ByVal bookState As String = "1", Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Try
            Dim count As Integer = 0
            Using ds As DataSet = New DataSet
                Using dt As DataTable = PubPatientScheduleDataTableFactory.getDataTableWithSchema
                    Dim row As DataRow = dt.NewRow
                    row("Book_Type_Id") = "E"
                    row("Chart_No") = chartNo
                    row("Book_Date") = CDate(prelendDate)
                    row("Book_Time") = bookingTime
                    row("CheckIn_Dept_Code") = deptCode
                    row("CheckIn_Section_Id") = sectionId
                    row("Is_PreLend_Chart") = IsPrelendChart
                    row("Book_State") = "1"
                    row("Create_User") = AppContext.userProfile.userId
                    row("Create_Time") = Now
                    row("Modified_User") = AppContext.userProfile.userId
                    row("Modified_Time") = Now
                    dt.Rows.Add(row)
                    ds.Tables.Add(dt)
                End Using
                count = PubPatientScheduleBO.GetInstance.insert(ds, conn)
            End Using
            Return count
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Return -1
        End Try
    End Function
    ''' <summary>
    ''' 取消調閱病歷
    ''' </summary>
    ''' <param name="typeId">E:健檢</param>
    ''' <param name="chartNo">病歷號</param>
    ''' <param name="prelendDate">調閱日期</param>
    ''' <param name="bookingTime">調閱時間</param>
    ''' <param name="deptCode">科</param>
    ''' <param name="sectionId">診</param>
    ''' <param name="IsPrelendChart">是否要調閱</param>
    ''' <param name="conn">connection</param>
    ''' <returns>-1:表示錯誤</returns>
    ''' <remarks></remarks>
    Public Function DeletePatientSchedule(ByVal typeId As String, ByVal chartNo As String, ByVal prelendDate As String, ByVal bookingTime As String, _
                                          ByVal deptCode As String, ByVal sectionId As String, Optional ByVal IsPrelendChart As String = "Y", _
                                          Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim PreLend_No As String = ""
            Dim sqlString As String = "Delete from " & tableName & " where " & _
            " Book_Type_Id=@Book_Type_Id and Chart_No=@Chart_No and Book_Date=@Book_Date and Book_Time=@Book_Time and CheckIn_Dept_Code=@CheckIn_Dept_Code and  " & _
            " CheckIn_Section_Id=@CheckIn_Section_Id and Is_PreLend_Chart=@Is_PreLend_Chart and  ISNULL(PreLend_No,'') = @PreLend_No  "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Book_Type_Id", typeId)
                command.Parameters.AddWithValue("@Chart_No", chartNo)
                command.Parameters.AddWithValue("@Book_Date", prelendDate)
                command.Parameters.AddWithValue("@Book_Time", bookingTime)
                command.Parameters.AddWithValue("@CheckIn_Dept_Code", deptCode)
                command.Parameters.AddWithValue("@CheckIn_Section_Id", sectionId)
                command.Parameters.AddWithValue("@Is_PreLend_Chart", IsPrelendChart)
                command.Parameters.AddWithValue("@PreLend_No", PreLend_No)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(sqlex.ToString, sqlex)
            Return -1
        Catch ex As Exception
            Syscom.Server.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Return -1
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

#End Region

End Class
