Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text


Public Class PUBHolidayBO_E1
    Inherits PubHolidayBO

    Dim tableName1 As String = "PUB_Syscode"
    Dim columnNameDB() As String = {"Holiday_Date", "SubSystem_Code", "Description", "Is_Holiday", "Create_User", "Create_Time", "Modified_User", "Modified_Time"}
    Dim columnCharOrNot() As Integer = {1, 1, 1, 1, 2, 1, 2}    '非Char的欄位索引

    Private Shared instance As PUBHolidayBO_E1

    Public Shared Shadows Function getInstance() As PUBHolidayBO_E1
        instance = New PUBHolidayBO_E1
        Return instance
    End Function

#Region "20090407 假日檔維護 BY James"

    '查詢假日
    Public Overloads Function queryPubHolidayAll() As DataSet 'Implements IPUBHolidayBO.queryPubHolidayAll


        Dim ds As Data.DataSet
        Dim cmdQueryStr As String = ""

        cmdQueryStr = "Select Holiday_Date as Holiday_Date, SubSystem_Code as SubSystem_Code,Description as Description ,Noon_Code" & _
                      "From " & tableName & "  Order By  SubSystem_Code,Holiday_Date"
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdQueryStr, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception

            Throw ex
        End Try

        Return ds
    End Function



    '查詢1假日
    Public Overloads Function queryPubHolidayByKey(ByVal holidayDate As String, ByVal subSysCode As String) As DataSet 'Implements IPUBHolidayBO.queryPubHolidayByKey


        Dim ds As Data.DataSet
        Dim cmdQueryStr As String = ""

        cmdQueryStr = "Select Holiday_Date , SubSystem_Code ,Description  ,Noon_Code" & _
                      "From " & tableName & " Where  Holiday_Date='" & holidayDate & "'  And SubSystem_Code='" & subSysCode & "'  Order By SubSystem_Code,Holiday_Date"
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdQueryStr, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception

            Throw ex
        End Try

        Return ds
    End Function

    Public Overloads Function queryPubHolidayByKey2(ByVal holidayDate As String, ByVal subSysCode As String) As DataSet 'Implements IPUBHolidayBO.queryPubHolidayByKey


        Dim ds As Data.DataSet
        Dim cmdQueryStr As String = ""

        cmdQueryStr = "Select Holiday_Date , SubSystem_Code ,Description, Is_Holiday ,Noon_Code" & _
                      "From " & tableName & " Where  Holiday_Date='" & holidayDate & "'  And SubSystem_Code='" & subSysCode & "'  Order By SubSystem_Code,Holiday_Date"
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdQueryStr, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception

            Throw ex
        End Try

        Return ds
    End Function

    '新增假日
    Public Overloads Function insertPubHoliday(ByVal ds As DataSet) As Integer 'Implements IPUBHolidayBO.insertPubHoliday
        Dim count As Integer = 0
        Try
            Dim insertSql As String = "insert into " & tableName & _
                                  " (Holiday_Date,SubSystem_Code,Description,Is_Holiday, Create_User,Create_Time,Modified_User,Modified_Time,Noon_Code) " & _
                                  " values(@Holiday_Date,@SubSystem_Code,@Description,@Is_Holiday, @Create_User, @Create_Time,@Modified_User,@Modified_Time,@Noon_Code) "


            Using conn As System.Data.IDbConnection = getConnection()
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = insertSql
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    For Each row As DataRow In ds.Tables(0).Rows
                        command.Parameters.AddWithValue("@Holiday_Date", row.Item("Holiday_Date"))
                        command.Parameters.AddWithValue("@SubSystem_Code", row.Item("SubSystem_Code"))
                        command.Parameters.AddWithValue("@Description", row.Item("Description"))
                        command.Parameters.AddWithValue("@Is_Holiday", row.Item("Is_Holiday"))
                        command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        command.Parameters.AddWithValue("@Create_Time", Now)
                        command.Parameters.AddWithValue("@Modified_User", row.Item("Create_User"))
                        command.Parameters.AddWithValue("@Modified_Time", Now)
                        command.Parameters.AddWithValue("@Noon_Code", row.Item("Noon_Code"))
                    Next
                    conn.Open()
                    count = command.ExecuteNonQuery
                End Using
            End Using

            Return count
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '刪除假日
    Public Overloads Function deletePubHoliday(ByVal holidayDate As String, ByVal subSysCode As String) As Integer 'Implements IPUBHolidayBO.deletePubHoliday

        Dim cmdDelStr As String = ""
        Dim flag As Integer

        cmdDelStr = "delete from " & tableName & " where Holiday_Date='" & holidayDate & "' and SubSystem_Code='" & subSysCode & "'"

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim cmdAdd As New SqlCommand(cmdDelStr, sqlConnection)
                sqlConnection.Open()
                flag = cmdAdd.ExecuteNonQuery()
            End Using
        Catch ex As Exception

            Throw ex
        End Try

        Return flag
    End Function

    '修改假日
    Public Overloads Function updatePubHoliday(ByVal ds As Data.DataSet) As Integer 'Implements IPUBHolidayBO.updatePubHoliday

        Try
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Description=@Description , Is_Holiday=@Is_Holiday , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Noon_Code=@Noon_Code" & _
            " where  Holiday_Date =@Holiday_Date  And SubSystem_Code=@SubSystem_Code "
            Using conn As System.Data.IDbConnection = getConnection()
                conn.Open()
                For Each row As DataRow In ds.Tables(0).Rows
                    Using command As SqlCommand = New SqlCommand
                        With command
                            .CommandText = sqlString
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                        End With

                        command.Parameters.AddWithValue("@Holiday_Date", row.Item("Holiday_Date"))

                        command.Parameters.AddWithValue("@SubSystem_Code", row.Item("SubSystem_Code"))
                        command.Parameters.AddWithValue("@Description", row.Item("Description"))
                        command.Parameters.AddWithValue("@Is_Holiday", row.Item("Is_Holiday"))
                        command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        command.Parameters.AddWithValue("@Modified_Time", Now)
                        command.Parameters.AddWithValue("@Noon_Code", row.Item("Noon_Code"))
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

    'Private Function getConnection() As IDbConnection
    '    Return SQLConnFactory.getInstance.getPubDBSqlConn
    'End Function


#End Region

#Region "2009-08-19 Added by Ken for 全院排程系統"

    ''' <summary>
    ''' 依輸入條件查詢假日
    ''' </summary>
    ''' <param name="dateBegin">開始日期</param>
    ''' <param name="dateEnd">結束日期</param>
    ''' <param name="subSystemCode">子系統碼</param>
    ''' <returns>假日日期</returns>
    ''' <author>Ken</author>
    ''' <date>2009-08-19</date>
    ''' <tables>
    ''' PUB_Holiday
    ''' </tables>
    ''' <remarks></remarks>
    Public Function queryHolidayByKeys(ByVal dateBegin As String, ByVal dateEnd As String, ByVal subSystemCode As String) As DataSet

        Dim var1 As New System.Text.StringBuilder
        var1.AppendFormat("SELECT DISTINCT Holiday_Date " & vbCrLf)
        var1.AppendFormat("FROM   PUB_Holiday " & vbCrLf)
        'var1.AppendFormat("WHERE  (SubSystem_Code = '++' " & vbCrLf)
        'var1.AppendFormat("         OR SubSystem_Code = '{0}') " & vbCrLf, subSystemCode.Replace("'", "''"))
        var1.AppendFormat("WHERE  (SubSystem_Code = '{0}') " & vbCrLf, subSystemCode.Replace("'", "''"))
        var1.AppendFormat("       AND Is_Holiday = 'Y' " & vbCrLf)
        var1.AppendFormat("       AND Holiday_Date BETWEEN '{0}' AND '{1}' " & vbCrLf, dateBegin.Replace("'", "''"), dateEnd.Replace("'", "''"))
        'var1.AppendFormat("EXCEPT  " & vbCrLf)
        'var1.AppendFormat("SELECT Holiday_Date " & vbCrLf)
        'var1.AppendFormat("FROM   PUB_Holiday " & vbCrLf)
        'var1.AppendFormat("WHERE  SubSystem_Code = '{0}' " & vbCrLf, subSystemCode.Replace("'", "''"))
        'var1.AppendFormat("       AND Is_Holiday = 'N' " & vbCrLf)
        'var1.AppendFormat("       AND Holiday_Date BETWEEN '{0}' AND '{0}' " & vbCrLf, dateBegin.Replace("'", "''"), dateEnd.Replace("'", "''"))

        Dim _ds As New DataSet

        Try
            Using _sqlConnection As SqlConnection = getConnection()
                Dim _dataAdapter As SqlDataAdapter = New SqlDataAdapter(var1.ToString, _sqlConnection)
                _dataAdapter.Fill(_ds, PubHolidayDataTableFactory.tableName)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return _ds
    End Function
#End Region


#Region "查詢大於某日的所有假日"

    Public Function queryPubHolidayByDate(ByVal holidayDate As String, ByVal subSysCode As String) As DataSet


        Dim ds As Data.DataSet
        Dim cmdQueryStr As String = ""

        cmdQueryStr = "Select Holiday_Date , SubSystem_Code ,Description, Is_Holiday ,Noon_Code" & _
                      "From " & tableName & " Where  Holiday_Date>='" & holidayDate & "'  And SubSystem_Code='" & subSysCode & "'  Order By SubSystem_Code,Holiday_Date"
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdQueryStr, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception

            Throw ex
        End Try

        Return ds
    End Function


#End Region


#Region "展開有效的日期"

    Public Function queryPubHolidayForEffectExpandDate(ByVal StartDate As String, ByVal subSysCode As String) As DataSet

        Dim HolidayDS As Data.DataSet
        Dim cmdQueryStr As String = ""
        Dim ReturnDS As New DataSet
        Dim CurrentProcessDate As Date
        Dim ContinueNextDate As Boolean = True

        ReturnDS.Tables.Add()
        ReturnDS.Tables(0).Columns.Add("Effect_Expand_Date")


        cmdQueryStr = "Select Holiday_Date , SubSystem_Code ,Description, Is_Holiday ,Noon_Code" & _
                      "From " & tableName & " Where  Holiday_Date>='" & StartDate & "' And Is_Holiday='Y'  And SubSystem_Code='" & subSysCode & "'   Order By SubSystem_Code,Holiday_Date"
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdQueryStr, sqlConnection)
                HolidayDS = New Data.DataSet(tableName)
                adapter.Fill(HolidayDS, tableName)
                adapter.FillSchema(HolidayDS, Data.SchemaType.Mapped, tableName)
            End Using

            If HolidayDS IsNot Nothing AndAlso HolidayDS.Tables.Count > 0 AndAlso HolidayDS.Tables(0).Rows.Count > 0 AndAlso IsDate(StartDate) Then

                CurrentProcessDate = CDate(StartDate)


                'StartDate=假日 , 不執行
                If HolidayDS.Tables(0).Select("Holiday_Date='" & CurrentProcessDate.ToShortDateString & "'").Count > 0 Then

                    ReturnDS.Tables(0).Rows.Add()
                    ReturnDS.Tables(0).Rows(ReturnDS.Tables(0).Rows.Count - 1).Item(0) = CDate(StartDate).ToShortDateString

                    While ContinueNextDate

                        CurrentProcessDate = DateAdd(DateInterval.Day, 1, CurrentProcessDate)

                        If GetWeekDay(CurrentProcessDate) = "7" Then
                            ReturnDS.Tables(0).Rows.Add()
                            ReturnDS.Tables(0).Rows(ReturnDS.Tables(0).Rows.Count - 1).Item(0) = CDate(StartDate).ToShortDateString
                            Continue While
                        End If

                        If HolidayDS.Tables(0).Select("Holiday_Date='" & CurrentProcessDate.ToShortDateString & "'").Count > 0 Then
                            '是假日,要加入
                            ReturnDS.Tables(0).Rows.Add()
                            ReturnDS.Tables(0).Rows(ReturnDS.Tables(0).Rows.Count - 1).Item(0) = CDate(StartDate).ToShortDateString
                        Else
                            '遇到非假日,停止
                            ContinueNextDate = False
                        End If

                    End While

                End If

            End If

            Return ReturnDS

        Catch ex As Exception

            Return Nothing
        End Try

        Return ReturnDS



    End Function


    Public Function GetWeekDay(ByVal DateTime As Date) As String

        Select Case Weekday(DateTime)
            Case 1
                '星期日
                Return "7"
            Case 2
                '星期一
                Return "1"
            Case 3
                '星期二
                Return "2"
            Case 4
                '星期三
                Return "3"
            Case 5
                '星期四
                Return "4"
            Case 6
                '星期五
                Return "5"
            Case 7
                '星期六
                Return "6"

                '2015/05/30 加入 其他的判斷式
            Case Else

                Return "0"
        End Select

    End Function


#End Region

#Region "查某一假日"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strHolidayYear"></param>
    ''' <param name="dateHolidayDate"></param>
    ''' <param name="strSubSystemCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBHolidayByCond(ByVal strHolidayYear As String, ByVal dateHolidayDate As Date, ByVal strSubSystemCode As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("Select A.Holiday_Date,A.SubSystem_Code,")
        strSql.Append(" ").Append("A.Description,A.Is_Holiday,")
        strSql.Append(" ").Append(" A.Create_User, A.Create_Time,")
        strSql.Append(" ").Append("A.Modified_User,A.Modified_Time, ")
        strSql.Append(" ").Append("B.Code_Name As SubSystem_Name, ")
        strSql.Append(" ").Append("A.Noon_Code ")
        strSql.Append(" ").Append("from")
        strSql.Append(" ").Append(tableName).Append("  A ")
        strSql.Append(" ").Append("left join")
        strSql.Append(" ").Append(tableName1).Append(" B on (A.SubSystem_Code = B.Code_Id and B.Type_Id=74 ) ")
        strSql.Append(" ").Append("Where 1=1 ")

        If strHolidayYear.Trim <> "" Then
            strSql.Append(" ").Append("AND left (CONVERT(char(10),A.Holiday_Date,111),4) = '").Append(strHolidayYear.Trim).Append("' ")
        End If
        If dateHolidayDate <> System.DateTime.MinValue Then
            strSql.Append(" AND CONVERT(char(10),A.Holiday_Date,111) ='").Append(dateHolidayDate.ToString("yyyy/MM/dd")).Append("' ")
        End If
        If strSubSystemCode.Trim <> "" Then
            strSql.Append(" ").Append("AND A.SubSystem_Code = '").Append(strSubSystemCode.Trim).Append("' ")
        End If
        strSql.Append(" ").Append("order by Holiday_Date")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function
#End Region



End Class
