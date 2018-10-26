'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：日期相關的公用BS
'=======
'======= 程式說明：1.日期相關的公用BS
'=======
'======= 建立日期：2012-8-6
'=======
'======= 開發人員：Sean.Lin
'=============================================================================
'=============================================================================
'=============================================================================


Imports System.Data.SqlClient
Imports System.Transactions
Imports Syscom.Server.SQL
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.EXP

Public Class PcsPubDateBS


#Region "     查詢 Method "

#Region "     根據傳入的 subsystem_Code 取得 PUB Holiday 的 DT "

    ''' <summary>
    ''' 根據傳入的 subsystem_Code 取得 PUB Holiday 的 DT
    ''' </summary>
    ''' <param name="SubsystemCode" >假日類別代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2012-8-6</remarks>
    Public Function getPubHolidayWithSubsystemCode(ByVal SubsystemCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataTable

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim dt As New DataTable("PUb_Holiday")

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT Holiday_Date, " & vbCrLf)
            varname1.Append("       Description, " & vbCrLf)
            varname1.Append("       subsystem_Code " & vbCrLf)
            varname1.Append("FROM   PUb_Holiday " & vbCrLf)
            varname1.Append("WHERE  subsystem_Code = @subsystem_Code " & vbCrLf)
            varname1.Append("       AND Is_Holiday = 'Y' ")


            command.CommandText = varname1.ToString

            command.Parameters.AddWithValue("@subsystem_Code", SubsystemCode)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                adapter.Fill(dt)
            End Using

            Return dt

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

#End Region

#Region "     找到傳入的日期之後的第一個上班日(不算傳入日) "

    ''' <summary>
    ''' 找到傳入的日期之後的第一個上班日(不算傳入日)；weekendFlag:true，要考慮Weekend；False，不考慮 Weekend
    ''' </summary>
    ''' <param name="JudegeDate" >要判斷的日期</param>
    ''' <param name="SubSystemCode" >Pub Holiday 的類別代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2012-8-6</remarks>
    Public Function findNextWorkDate(ByVal JudegeDate As Date, ByVal SubSystemCode As String, ByVal weekendFlag As Boolean) As Date

        Try

            '取得 Pub Holiday 資料
            Dim dt As DataTable = getPubHolidayWithSubsystemCode(SubSystemCode)

            '轉換成 Hash Table
            Dim Ht As Hashtable = TransHolidayDTToHash(dt)

            Dim returnDate As Date = findWorkDateRecursive(JudegeDate.AddDays(1), Ht, weekendFlag)

            Return returnDate
 
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"找到傳入的日期之後的第一個上班日(不算傳入日)；weekendFlag:true，要考慮Weekend；False，不考慮 Weekend"})
 
        End Try

    End Function

#End Region

#Region "     找到傳入的日期之後的第二個上班日(不算傳入日) "

    ''' <summary>
    ''' 找到傳入的日期之後的第二個上班日(不算傳入日)，weekendFlag:true，要考慮Weekend；False，不考慮 Weekend
    ''' </summary>
    ''' <param name="JudegeDate" >要判斷的日期</param>
    ''' <param name="SubSystemCode" >Pub Holiday 的類別代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2012-8-6</remarks>
    Public Function findNextTwoWokDate(ByVal JudegeDate As Date, ByVal SubSystemCode As String, ByVal weekendFlag As Boolean) As Date

        Try

            '取得 Pub Holiday 資料
            Dim dt As DataTable = getPubHolidayWithSubsystemCode(SubSystemCode)

            '轉換成 Hash Table
            Dim Ht As Hashtable = TransHolidayDTToHash(dt)

            '第一個上班日
            Dim firstDate As Date = findWorkDateRecursive(JudegeDate.AddDays(1), Ht, weekendFlag)

            '第二個上班日
            Dim returnDate As Date = findWorkDateRecursive(firstDate.AddDays(1), Ht, weekendFlag)

            Return returnDate


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"找到傳入的日期之後的第二個上班日(不算傳入日)"})

        End Try


    End Function

#End Region

#Region "     判斷傳入的日期是不是假日，回傳值 True:假日；False:非假日。 SubSystemCode: 假日檔的類別。weekendFlag:true，要考慮Weekend；False，不考慮。 "

    ''' <summary>
    ''' 判斷傳入的日期是不是假日，回傳值 True:假日；False:非假日。
    ''' 
    ''' SubSystemCode: 假日檔的類別。
    ''' 
    ''' weekendFlag:true，要考慮Weekend；False，不考慮。
    ''' </summary>
    ''' <param name="JudegeDate" >要判斷的日期</param>
    ''' <param name="SubSystemCode" >Pub Holiday 的類別代碼</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2012-8-6</remarks>
    Public Function findIsHoliday(ByVal JudegeDate As Date, ByVal SubSystemCode As String, ByVal weekendFlag As Boolean, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Boolean


        Dim connFlag As Boolean = conn Is Nothing

        Try

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If


            '取得 Pub Holiday 資料
            Dim dt As DataTable = getPubHolidayWithSubsystemCode(SubSystemCode, conn)

            '轉換成 Hash Table
            Dim Ht As Hashtable = TransHolidayDTToHash(dt)

            '要考慮Weekend
            If weekendFlag Then

                Return IsHolidayAndWeekend(JudegeDate, Ht)

            Else

                Return IsHoliday(JudegeDate, Ht)

            End If

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

#Region "     遞迴，找到傳入的日期之後的第一個非假日 "

    ''' <summary>
    ''' 遞迴，找到傳入的日期之後的第一個非假日，weekendFlag:true，要考慮Weekend；False，不考慮 Weekend
    ''' </summary>
    ''' <param name="JudegeDate" >要判斷的日期</param>
    ''' <param name="HolidayHashDT" >存放假日的HashTable</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2012-8-6</remarks>
    Private Function findWorkDateRecursive(ByVal JudegeDate As Date, ByRef HolidayHashDT As Hashtable, ByRef weekendFlag As Boolean) As Date

        Try

            '要考慮Weekend
            If weekendFlag Then

                '是假日，繼續做
                If IsHolidayAndWeekend(JudegeDate, HolidayHashDT) Then

                    Return findWorkDateRecursive(JudegeDate.AddDays(1), HolidayHashDT, weekendFlag)

                Else

                    Return JudegeDate

                End If



            Else
                '不考慮 Weekend

                '是假日，繼續做
                If IsHoliday(JudegeDate, HolidayHashDT) Then

                    Return findWorkDateRecursive(JudegeDate.AddDays(1), HolidayHashDT, weekendFlag)

                Else

                    Return JudegeDate

                End If


            End If



        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"遞迴，找到傳入的日期之後的第一個非假日"})

        End Try

    End Function

#End Region

#Region "     判斷傳入的日期是否為假日，即日期是否存在Table 中，true:假日 "

    ''' <summary>
    ''' 判斷傳入的日期是否為假日，即日期是否存在Table 中，true:假日
    ''' </summary>
    ''' <param name="JudegeDate" >要判斷的日期</param>
    ''' <param name="HolidayHashDT" >存放假日的HashTable</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2012-8-6</remarks>
    Private Function IsHoliday(ByVal JudegeDate As Date, ByRef HolidayHashDT As Hashtable) As Boolean

        Dim returnBoolean As Boolean = False
        Try

            returnBoolean = HolidayHashDT.ContainsKey(JudegeDate.ToString("yyyyMMdd"))

            Return returnBoolean



        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"判斷傳入的日期是否為假日，即日期是否存在Table 中，true:假日"})

        End Try

    End Function

#End Region

#Region "     判斷傳入的日期是否為假日，即日期是否存在Table 中，並額外判斷是否為六日，true:假日 "

    ''' <summary>
    ''' 判斷傳入的日期是否為假日，即日期是否存在Table 中，並額外判斷是否為六日 ，true:假日
    ''' </summary>
    ''' <param name="JudegeDate" >要判斷的日期</param>
    ''' <param name="HolidayHashDT" >存放假日的HashTable</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2012-8-6</remarks>
    Private Function IsHolidayAndWeekend(ByVal JudegeDate As Date, ByRef HolidayHashDT As Hashtable) As Boolean

        Try

            If JudegeDate.DayOfWeek = DayOfWeek.Saturday Or JudegeDate.DayOfWeek = DayOfWeek.Sunday Then

                Return True

            Else

                Return IsHoliday(JudegeDate, HolidayHashDT)

            End If



        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"判斷傳入的日期是否為假日，即日期是否存在Table 中，並額外判斷是否為六日 ，true:假日"})

        End Try

    End Function

#End Region

#Region "     將假日的DT 轉換成 HashTable "

    ''' <summary>
    ''' 將假日的DT 轉換成 HashTable
    ''' </summary>
    ''' <param name="HolidayDT" >存放假日的Table</param>a
    ''' <returns>Dataset</returns>
    ''' <remarks>by Sean.Lin on 2012-8-6</remarks>
    Private Function TransHolidayDTToHash(ByVal HolidayDT As DataTable) As Hashtable

        Try

            Dim Ht As New Hashtable

            For Each dr As DataRow In HolidayDT.Rows

                Ht.Add(CDate(dr.Item("Holiday_Date")).ToString("yyyyMMdd"), nvl(dr.Item("Description")))

            Next

            Return Ht



        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"將假日的DT 轉換成 HashTable"})

        End Try

    End Function

#End Region

#Region "     取得 住院DB 在所屬資料庫的連線 "

    ''' <summary>
    ''' 取得 住院DB 在所屬資料庫的連線
    ''' </summary>
    ''' ''' <returns>資料庫連線</returns>
    ''' <remarks>by Sean.Lin on 2012-8-6</remarks>
    Public Function getConnection() As IDbConnection

        Return SQLConnFactory.getInstance.getPubDBSqlConn

    End Function

#End Region

End Class

