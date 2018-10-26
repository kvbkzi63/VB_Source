Imports System.Text
Imports System.Globalization
Imports System.Reflection
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility.CheckMethodUtil

Public Class DateUtil


    ''' <summary>
    ''' yyyy-MM-dd HH:mm:ss.fff
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared DateTimeFullTypeDash As String = "yyyy-MM-dd HH:mm:ss.fff"
    ''' <summary>
    ''' yyyy-MM-dd HH:mm:ss
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared DateTimeTypeDash As String = "yyyy-MM-dd HH:mm:ss"
    ''' <summary>
    ''' yyyy-MM-dd HH:mm
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared DateTimeMinuteTypeDash As String = "yyyy-MM-dd HH:mm"
    ''' <summary>
    ''' yyyy-MM-dd
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared DateTypeDash As String = "yyyy-MM-dd"
    ''' <summary>
    ''' yyyy/MM/dd HH:mm:ss.fff
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared DateTimeFullTypeSlash As String = "yyyy/MM/dd HH:mm:ss.fff"
    ''' <summary>
    ''' yyyy/MM/dd HH:mm:ss
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared DateTimeTypeSlash As String = "yyyy/MM/dd HH:mm:ss"
    ''' <summary>
    ''' yyyy/MM/dd HH:mm
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared DateTimeMinuteTypeSlash As String = "yyyy/MM/dd HH:mm"
    ''' <summary>
    ''' yyyy/MM/dd
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared DateTypeSlash As String = "yyyy/MM/dd"

    Private Shared _datetimeFormats() As String = { _
        "yyyy/M/d tt hh:mm:ss", "yyyy/MM/dd tt hh:mm:ss", "yyyy/MM/dd HH:mm:ss", "yyyy/M/d HH:mm:ss", "yyyy/M/d", "M/d/yyyy", _
        "yyyy/MM/dd", "MM/dd/yyyy", "yyyy/MM/dd 上午 hh:mm:ss", "yyyy/MM/d 上午 hh:mm:ss", "yyyy/M/dd 上午 hh:mm:ss", _
        "yyyy/M/d 上午 hh:mm:ss", "yyyy/MM/dd 下午 hh:mm:ss", "MM/d/yyyy 下午 hh:mm:ss", "yyyy/M/dd 下午 hh:mm:ss", _
        "yyyy/M/d 下午 hh:mm:ss", "MM/dd/yyyy hh:mm:ss 下午", "MM/d/yyyy hh:mm:ss 下午", "M/dd/yyyy hh:mm:ss 下午", _
        "M/d/yyyy hh:mm:ss 下午", "MM/dd/yyyy hh:mm:ss 上午", "MM/d/yyyy hh:mm:ss 上午", "M/dd/yyyy hh:mm:ss 上午", _
        "M/d/yyyy hh:mm:ss 上午", "MM/dd/yyyy hh:mm:ss tt", "MM/d/yyyy hh:mm:ss tt", "M/dd/yyyy hh:mm:ss tt", "M/d/yyyy hh:mm:ss tt"}


    Public Enum DateTimeType
        DateTimeFullTypeDash
        DateTimeTypeDash
        DateTypeDash
        DateTimeFullTypeSlash
        DateTimeTypeSlash
        DateTypeSlash
    End Enum



    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

#Region "     取得年齡(歲月天) "

#Region "     Date 型態 - 取得年齡(歲月天)，輸入西元生日與西元計算年齡截止日期。回傳 age(0):歲,age(1):月,age(2):天,age(3):幾歲幾月幾天(依規定顯示月或天) "

    ''' <summary>
    ''' 取得年齡(歲月天)，輸入西元生日與西元計算年齡截止日期。回傳 age(0):歲,age(1):月,age(2):天,age(3):幾歲幾月幾天(依規定顯示月或天)
    ''' </summary>
    ''' ''' <param name="birthDate">出生日期(yyyy/MM/dd)</param>
    ''' <param name="endDate">計算年齡截止日期(yyyy/MM/dd)</param>
    ''' <returns> Integer()</returns>
    ''' <remarks>by Sean.Lin Refactory on 2011-11-8</remarks>
    Public Shared Function GetAge(ByVal birthDate As Date, ByVal endDate As Date) As String()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        'Base 的Function，所有的計算年齡皆以本Method 為主

        Dim age(4) As String

        Try
            If CheckIsNothing(birthDate) And CheckIsNothing(endDate) And Not birthDate = "1900/01/01" Then

                Dim iYears, iMonths, iDays As Long

                iYears = 0
                iMonths = 0
                iDays = 0
                If (DateDiff(DateInterval.Day, birthDate, endDate) >= 0) Then
                    '先算月份   
                    iMonths = DateDiff(DateInterval.Month, birthDate, endDate)
                    '再算天數   
                    If (endDate.Day < birthDate.Day) Then
                        iMonths -= 1
                    End If
                    iDays = DateDiff(DateInterval.Day, DateAdd(DateInterval.Month, iMonths, birthDate), endDate)
                    If (iMonths >= 12) Then
                        iYears = CLng(iMonths \ 12)
                        iMonths = iMonths Mod 12
                    End If
                End If
                age(0) = (iYears)
                age(1) = (iMonths)
                age(2) = (iDays)

                Select Case Syscom.Comm.BASE.HospConfigUtil.HospConfig
                    Case BASE.HospConfigUtil.hospConfigList.Tw_Kmuh
                        '未滿18歲  顯示 0歲0月0天
                        If CInt(iYears) < 18 Then
                            age(3) = age(0) & "歲" & age(1) & "月" & age(2) & "天"
                            '未滿1歲 顯示 0月0天
                        ElseIf CInt(iYears) < 1 AndAlso CInt(iMonths) > 1 Then
                            age(3) = age(1) & "月" & age(2) & "天"
                            '未滿一個月 顯示 0天
                        ElseIf CInt(iYears) < 1 AndAlso CInt(iMonths) < 1 Then
                            age(3) = age(2) & "天"
                        Else
                            '2016/07/07 Sean: SA Sophia 這邊應為歲+月
                            age(3) = age(0) & "歲" & age(1) & "月"
                        End If
                    Case Else
                        '零歲
                        If CInt(iYears) < 1 Then

                            age(3) = iMonths & "月" & iDays & "天"

                            '六歲 ~ 一歲，零歲的不會進入此條件
                        ElseIf CInt(iYears) < 6 Then

                            age(3) = iYears & "歲" & iMonths & "月"

                            '其他
                        Else

                            age(3) = iYears & "歲"

                        End If
                End Select



            Else

                age(0) = ""

                age(1) = ""

                age(2) = ""

                age(3) = ""

            End If

            Return age
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region "     String 型態 - 取得年齡(歲月天)，輸入西元生日與西元計算年齡截止日期。回傳 age(0):歲,age(1):月,age(2):天,age(3):幾歲幾月幾天(依規定顯示月或天) "

    ''' <summary>
    ''' 取得年齡(歲月天)，輸入西元生日與西元計算年齡截止日期。回傳 age(0):歲,age(1):月,age(2):天,age(3):幾歲幾月幾天(依規定顯示月或天)
    ''' </summary>
    ''' ''' <param name="birthDate">出生日期(yyyy/MM/dd)</param>
    ''' <param name="endDate">計算年齡截止日期(yyyy/MM/dd)</param>
    ''' <returns> Integer()</returns>
    ''' <remarks>by Sean.Lin Refactory on 2011-11-8</remarks>
    Public Shared Function GetAge(ByVal birthDate As String, ByVal endDate As String) As String()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim age(4) As String
        Try
            birthDate = transDateStringToDate(birthDate)

            endDate = transDateStringToDate(endDate)

            If CheckIsDate(birthDate) And CheckIsDate(endDate) Then

                age = GetAge(CDate(birthDate), CDate(endDate))

            Else
                '不是 Date 回傳空字串
                age = New String() {"", "", "", ""}

            End If


            Return age
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try

    End Function

#End Region

#Region "     Date 型態 - 取得年齡(歲月天)，輸入西元生日。回傳 age(0):歲,age(1):月,age(2):天,age(3):幾歲幾月幾天(依規定顯示月或天) "

    '''  ''' <summary>
    ''' 取得年齡(歲月天)，輸入西元生日。回傳 age(0):歲,age(1):月,age(2):天,age(3):幾歲幾月幾天(依規定顯示月或天)
    ''' </summary>
    ''' <param name="birthDate">出生日期(yyyy/MM/dd)</param>
    ''' <returns> Integer()</returns>
    ''' <remarks>by Sean.Lin Refactory on 2011-11-8</remarks>
    Public Shared Function GetAge(ByVal birthDate As Date) As String()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim endDate As Date = Date.Today

            Return GetAge(birthDate, endDate)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region "     String 型態 - 取得年齡(歲月天)，輸入西元生日。回傳 age(0):歲,age(1):月,age(2):天,age(3):幾歲幾月幾天(依規定顯示月或天) "

    '''  ''' <summary>
    ''' 取得年齡(歲月天)，輸入西元生日。回傳 age(0):歲,age(1):月,age(2):天,age(3):幾歲幾月幾天(依規定顯示月或天)
    ''' </summary>
    ''' <param name="birthDate">出生日期(yyyy/MM/dd)</param>
    ''' <returns> Integer()</returns>
    ''' <remarks>by Sean.Lin Refactory on 2011-11-8</remarks>
    Public Shared Function GetAge(ByVal birthDate As String) As String()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim age(4) As String
        Try
            birthDate = transDateStringToDate(birthDate)

            Dim endDate As Date = Date.Today

            If CheckIsDate(birthDate) Then

                age = GetAge(CDate(birthDate), endDate)

            Else
                '不是 Date 回傳空字串
                age = New String() {"", "", "", ""}

            End If

            Return age
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#End Region

#Region " 將日期轉換成字串(""yyyy/MM/dd HH:mm:ss"")；若為null 則回傳空字串 "

    ''' <summary>
    ''' 將日期轉換成字串(“yyyy/MM/dd HH:mm:ss”)；若為null 則回傳空字串
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-08-19</remarks>
    Public Shared Function transTimeToString(ByVal transDate As Object) As String

        Try

            If transDate Is Nothing Or transDate Is DBNull.Value Then

                Return ""

            ElseIf IsDate(transDate) Then

                Return CDate(transDate).ToString(DateTimeTypeSlash)

            Else
                Throw New Exception("非日期格式使用此Method，無法轉換!")
            End If



        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("將日期轉換成字串(""yyyy/MM/dd HH:mm:ss"")；若為null 則回傳空字串", ex)
        End Try

    End Function

#End Region

#Region " 將日期轉換成字串(""yyyy/MM/dd"")；若為null 則回傳空字串 "

    ''' <summary>
    ''' 將日期轉換成字串(“yyyy/MM/dd”)；若為null 則回傳空字串
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-08-19</remarks>
    Public Shared Function transDateToString(ByVal transDate As Object) As String

        Try

            If transDate Is Nothing Or transDate Is DBNull.Value Then

                Return ""

            ElseIf IsDate(transDate) Then

                Return CDate(transDate).ToString(DateTypeSlash)

            Else
                Throw New Exception("非日期格式使用此Method，無法轉換!")
            End If



        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("將日期轉換成字串(""yyyy/MM/dd"")；若為null 則回傳空字串", ex)
        End Try

    End Function

#End Region

#Region "     西元年、民國年轉換 "


#Region "     西元年轉成民國年 "

    ''' <summary>
    ''' 西元年轉成民國年
    ''' 
    ''' 輸入為字串格式，為 yyyy  => 回傳 yy or yyy。
    ''' 
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2015-11-24</remarks>
    Public Shared Function TransYearToROC(ByVal dateValue As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""
        Try
            Dim dateTrans As String = dateValue.ToString.Trim
            '補上日期，用基礎的轉換處理，處理完之後回傳正確的年月
            If dateTrans.Length = 4 Then
                dateTrans = dateTrans.ToString.Trim & "0101"
            Else
                Throw New CommonException("CMMCMMB300", "傳入值並非四碼長度的西元年：" & dateValue)
            End If

            Dim dateStr As String() = TransDateToROCBase(dateTrans)

            '組合年月日
            returnString = dateStr(1).ToString

            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB300", ex, New String() {"西元年轉成民國年"}, caller:=caller)
        End Try
    End Function

#End Region

#Region "     西元年轉成民國年 "

    ''' <summary>
    ''' 西元年月轉成民國年月，
    ''' 
    ''' 輸入為字串格式，為 yyyyMM  => 回傳 yyMM or yyyMM。
    ''' 
    ''' 輸入為字串格式，為 yyyy/MM => 回傳 yy/MM or yyy/MM。
    ''' 
    ''' 輸入為字串格式，為 yyyy-MM => 回傳 yy-MM or yyy-MM。
    ''' 
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2015-11-24</remarks>
    Public Shared Function TransYMToROC(ByVal dateValue As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""
        Try
            Dim dateTrans As String = dateValue.ToString.Trim
            '補上日期，用基礎的轉換處理，處理完之後回傳正確的年月
            If dateTrans.Length = 6 Then
                dateTrans = dateTrans & "01"
            ElseIf dateTrans.Length = 7 Then

                If dateTrans.Contains("/") Then
                    dateTrans = dateTrans & "/01"
                ElseIf dateTrans.Contains("-") Then
                    dateTrans = dateTrans & "-01"
                End If

            Else
                Throw New CommonException("CMMCMMB300", "傳入值並非六碼或七碼長度的西元年月：" & dateValue)
            End If

            Dim dateStr As String() = TransDateToROCBase(dateTrans)

            '組合年月日
            returnString = dateStr(1).ToString & dateStr(0).ToString & dateStr(2).ToString

            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB300", ex, New String() {"西元年月轉成民國年月"}, caller:=caller)
        End Try
    End Function

#End Region

#Region "     將西元年月日轉成民國年月日 "

    ''' <summary>
    ''' 將西元年月日轉成民國年月日，輸入為Date格式，回傳 yy/MM/dd or  yyy/MM/dd 
    ''' </summary>
    ''' <param name="dateValue" ></param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2011-11-8</remarks>
    Public Shared Function TransDateToROC(ByVal dateValue As Date) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""
        Try
            returnString = TransDateToROC(dateValue.ToString("yyyy/MM/dd"))

            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region "     將西元年月日轉成民國年月日 "

    ''' <summary>
    ''' 將西元年月日轉成民國年月日，
    ''' 
    ''' 輸入為字串格式，為 yyyyMMdd   => 回傳 yyMMdd or yyyMMdd。
    ''' 
    ''' 輸入為字串格式，為 yyyy/MM/dd => 回傳 yy/MM/dd or yyy/MM/dd。
    ''' 
    ''' 輸入為字串格式，為 yyyy-MM-dd => 回傳 yy-MM-dd or yyy-MM-dd。
    ''' 
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2011-11-8</remarks>
    Public Shared Function TransDateToROC(ByVal dateValue As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""
        Try
            Dim dateStr As String() = TransDateToROCBase(dateValue)

            '組合年月日
            returnString = dateStr(1).ToString & dateStr(0).ToString & dateStr(2).ToString & dateStr(0).ToString & dateStr(3).ToString

            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region "     將西元年日期時分轉成民國年日期時分 "

    ''' <summary>
    ''' 將西元年日期時分轉成民國年日期時分，
    ''' 輸入為DateTime格式，回傳 yy/MM/dd HH:mm or  yyy/MM/dd HH:mm 。
    ''' </summary>
    ''' <param name="dateTimeValue" >西元年日期時分</param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2011-11-8</remarks>
    Public Shared Function TransDateTimeToROC(ByVal dateTimeValue As DateTime) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""
        Try
            returnString = TransDateTimeToROC(dateTimeValue.ToString("yyyy/MM/dd HH:mm"))

            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region "     將西元年日期時分轉成民國年日期時分 "

    ''' <summary>
    ''' 將西元年日期時分轉成民國年日期時分，
    ''' 
    ''' 輸入為字串格式，為 yyyy/MM/dd HH:mm:ss => 回傳 yy/MM/dd HH:mm:ss or yyy/MM/dd HH:mm:ss。
    ''' 
    ''' 輸入為字串格式，為 yyyy-MM-dd HH:mm:ss => 回傳 yy-MM-dd HH:mm:ss or yyy-MM-dd HH:mm:ss。
    ''' 
    ''' 輸入為字串格式，為 yyyy/MM/dd HH:mm => 回傳 yy/MM/dd HH:mm or yyy/MM/dd HH:mm。
    ''' 
    ''' 輸入為字串格式，為 yyyy-MM-dd HH:mm => 回傳 yy-MM-dd HH:mm or yyy-MM-dd HH:mm。
    ''' 
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2011-11-8</remarks>
    Public Shared Function TransDateTimeToROC(ByVal dateTimeValue As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""
        Try
            Dim dateStr As String() = TransDateToROCBase(dateTimeValue)

            '組合年月日 + 傳入字串的時分或秒
            returnString = dateStr(1).ToString & dateStr(0).ToString & dateStr(2).ToString & dateStr(0).ToString & dateStr(3).ToString & " " & dateTimeValue.Substring(dateTimeValue.IndexOf(" ") + 1)

            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region "     將西元年轉成民國 X 年 X 月 X 日 (一) "

    ''' <summary>
    ''' 將西元年轉成民國 X 年 X 月 X 日 (一)，
    ''' 
    ''' 輸入為字串格式，為 yyyyMMdd  or  yyyy/MM/dd or yyyy-MM-dd => 回傳 民國 yyy 年 M 月 d 日 (一)
    ''' 
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2012-8-8</remarks>
    Public Shared Function TransDateToROCText(ByVal dateValue As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""
        Try
            Dim dateStr As String() = TransDateToROCBase(dateValue)

            '組合年月日
            returnString = "民國" & dateStr(1).ToString & "年" & dateStr(2).ToString & "月" & dateStr(3).ToString & "日" & "(" & dateStr(4).ToString & ")"

            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region "     將西元年轉成民國年月日星期，回傳為一個字串陣列包含五個值，依序為分隔符號、年、月、日、星期幾 "

    ''' <summary>
    ''' 將西元年轉成民國年月日星期，回傳為一個字串陣列包含五個值，依序為分隔符號、年、月、日、星期幾
    ''' 
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2011-11-8</remarks>
    Private Shared Function TransDateToROCBase(ByVal dateValue As String) As String()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String() = New String() {"", "", "", "", ""}
        Try
            '定義年月日的參數

            '分隔符號
            Dim delimiter As String = ""

            '年
            Dim year As Integer = 0

            '月
            Dim mon As String = ""

            '日
            Dim day As String = ""

            '星期
            Dim weekDay As String = ""

            '檢查日期
            If CheckIsDate(dateValue) Then

                '輸入為字串格式，為 yyyy/MM/dd => 回傳 yy/MM/dd or yyy/MM/dd
                If dateValue.Contains("/") Then

                    '去掉後面六位，從0開始取得，即為幾年
                    year = CInt(dateValue.Substring(0, 4))

                    '去掉後面五位，即為幾月的開頭
                    mon = dateValue.Substring(5, 2)

                    '去掉後面兩位，即為幾日的開頭
                    day = dateValue.Substring(8, 2)

                    '分隔符號
                    delimiter = "/"


                    '輸入為字串格式，為 yyyy/MM/dd => 回傳 yy/MM/dd or yyy/MM/dd 
                ElseIf dateValue.Contains("-") Then

                    '去掉後面六位，從0開始取得，即為幾年
                    year = CInt(dateValue.Substring(0, 4))

                    '去掉後面五位，即為幾月的開頭
                    mon = dateValue.Substring(5, 2)

                    '去掉後面兩位，即為幾日的開頭
                    day = dateValue.Substring(8, 2)

                    '分隔符號
                    delimiter = "-"



                    '輸入為字串格式，為 yyyyMMdd   => 回傳 yyMMdd or yyyMMdd
                ElseIf dateValue.Length = 8 Then

                    '去掉後面四位，從0開始取得，即為幾年
                    year = CInt(dateValue.Substring(0, 4))

                    '去掉後面四位，即為幾月的開頭
                    mon = dateValue.Substring(4, 2)

                    '去掉後面兩位，即為幾日的開頭
                    day = dateValue.Substring(6, 2)

                    '分隔符號
                    delimiter = ""

                End If

                '判斷是否為民國前， (1911年) 是的話要多減一，因為沒有民國 0 年
                If year <= 1911 Then

                    year = year - 1911 - 1

                Else

                    year = year - 1911

                End If

                'yyyyyMMdd 要轉型，不然.Net 會判斷錯誤
                dateValue = transDateStringToDate(dateValue)

                '判斷星期幾
                Select Case CDate(dateValue).DayOfWeek

                    Case DayOfWeek.Monday

                        weekDay = "一"

                    Case DayOfWeek.Tuesday

                        weekDay = "二"

                    Case DayOfWeek.Wednesday

                        weekDay = "三"

                    Case DayOfWeek.Thursday

                        weekDay = "四"

                    Case DayOfWeek.Friday

                        weekDay = "五"

                    Case DayOfWeek.Saturday

                        weekDay = "六"

                    Case DayOfWeek.Sunday

                        weekDay = "日"

                End Select

                '組合年月日
                returnString = New String() {delimiter, year, mon, day, weekDay}

            ElseIf dateValue = "" Then

                Return New String() {"", "", "", "", ""}

            Else


                Throw New Exception("日期格式不正確")

            End If

            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region "     民國年轉成西元年 "

    ''' <summary>
    ''' 民國年轉成西元年，
    ''' 
    ''' 輸入為字串格式，為 y or yy or yyy     => 回傳 yyyy。
    ''' 
    ''' 若不為民國年，則回傳原始字串
    ''' 
    ''' </summary>
    ''' <param name="dateValue">民國年日期：y、yy、yyy</param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2015-11-24</remarks>
    Public Shared Function TransYearToWE(ByVal dateValue As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""
        Try
            Dim dateTrans As String = dateValue.ToString.Trim

            '補上日期方便轉換
            dateTrans = dateTrans & "0101"

            '回傳組合後 年月日
            returnString = TransDateToWE(dateTrans, "")

            '去掉日期
            returnString = returnString.Substring(0, returnString.Length - 4)


            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB300", ex, New String() {"民國年月轉成西元年月"}, caller:=caller)
        End Try
    End Function

#End Region

#Region "     民國年月轉成西元年月 "

    ''' <summary>
    ''' 民國年月轉成西元年月，
    ''' 
    ''' 輸入為字串格式，為 yMMdd or yyMM or yyyMM     => 回傳 yyyyMM。
    ''' 
    ''' 輸入為字串格式，為 y/MM/dd or  yy/MM or yyy/MM => 回傳 yyyy/MM。
    ''' 
    ''' 輸入為字串格式，為 y-MM-dd or  yy-MM or yyy-MM => 回傳 yyyy-MM。
    ''' 
    ''' 若不為民國年，則回傳原始字串
    ''' 
    ''' </summary>
    ''' <param name="dateValue">民國年日期：yMMdd、yyMMdd、yyyMMdd、y/MM/dd、yy/MM/dd、yyy/MM/dd、y-MM-dd、yy-MM-dd、yyy-MM-dd </param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2015-11-24</remarks>
    Public Shared Function TransYMToWE(ByVal dateValue As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""
        Try
            Dim dateTrans As String = dateValue.ToString.Trim

            '輸入為字串格式，為 yy/MM/dd or yyy/MM/dd => 回傳 yyyy/MM/dd
            If dateTrans.Contains("/") Then

                '補上日期方便轉換
                dateTrans = dateTrans & "/01"

                '回傳組合後 年月日
                returnString = TransDateToWE(dateTrans, "/")

                '去掉日期
                returnString = returnString.Substring(0, returnString.Length - 3)

                '輸入為字串格式，為 yy-MM-dd or yyy-MM-dd => 回傳 yyyy-MM-dd
            ElseIf dateTrans.Contains("-") Then

                '補上日期方便轉換
                dateTrans = dateTrans & "-01"

                '回傳組合後 年月日
                returnString = TransDateToWE(dateTrans, "-")

                '去掉日期
                returnString = returnString.Substring(0, returnString.Length - 3)

                '輸入為字串格式，為 yyMMdd or yyyMMdd => 回傳 yyyyMMdd
            Else


                '補上日期方便轉換
                dateTrans = dateTrans & "01"

                '回傳組合後 年月日
                returnString = TransDateToWE(dateTrans, "")

                '去掉日期
                returnString = returnString.Substring(0, returnString.Length - 2)


            End If

            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB300", ex, New String() {"民國年月轉成西元年月"}, caller:=caller)
        End Try
    End Function

#End Region

#Region "     將民國年月日轉成西元年月日 "

    ''' <summary>
    ''' 將民國年月日轉成西元年月日，
    ''' 
    ''' 輸入為字串格式，為 yMMdd or yyMMdd or yyyMMdd     => 回傳 yyyyMMdd。
    ''' 
    ''' 輸入為字串格式，為 y/MM/dd oryy/MM/dd or yyy/MM/dd => 回傳 yyyy/MM/dd。
    ''' 
    ''' 輸入為字串格式，為 y-MM-dd oryy-MM-dd or yyy-MM-dd => 回傳 yyyy-MM-dd。
    ''' 
    ''' 若不為民國年，則回傳原始字串
    ''' 
    ''' </summary>
    ''' <param name="dateValue">民國年日期：yMMdd、yyMMdd、yyyMMdd、y/MM/dd、yy/MM/dd、yyy/MM/dd、y-MM-dd、yy-MM-dd、yyy-MM-dd </param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2012-8-8</remarks>
    Public Shared Function TransDateToWE(ByVal dateValue As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""
        Try

            '輸入為字串格式，為 yy/MM/dd or yyy/MM/dd => 回傳 yyyy/MM/dd
            If dateValue.Contains("/") Then

                '回傳組合後 年月日
                returnString = TransDateToWE(dateValue, "/")

                '輸入為字串格式，為 yy-MM-dd or yyy-MM-dd => 回傳 yyyy-MM-dd
            ElseIf dateValue.Contains("-") Then

                '回傳組合後 年月日
                returnString = TransDateToWE(dateValue, "-")

                '輸入為字串格式，為 yyMMdd or yyyMMdd => 回傳 yyyyMMdd
            Else

                '回傳組合後 年月日
                returnString = TransDateToWE(dateValue, "")

            End If

            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region "     將民國年月日轉成西元年月日，並指定分隔符號 "

    ''' <summary>
    ''' 將民國年月日轉成西元年月日，delimiter 為分隔符號，以指定的分隔符號隔開
    ''' 
    ''' 輸入為字串格式，為 yMMdd or yyMMdd or yyyMMdd  , y/MM/dd or yy/MM/dd or yyy/MM/dd ,y-MM-dd or yy-MM-dd or yyy-MM-dd 
    ''' 
    ''' 回傳 yyyy delimiter MM delimiter dd。
    ''' 
    ''' 若不為民國年，則回傳原始字串
    ''' 
    ''' </summary>
    ''' <param name="dateValue">民國年日期：yMMdd、yyMMdd、yyyMMdd、y/MM/dd、yy/MM/dd、yyy/MM/dd、y-MM-dd、yy-MM-dd、yyy-MM-dd </param>
    ''' <param name="delimiter">分隔符號</param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2012-8-8</remarks>
    Public Shared Function TransDateToWE(ByVal dateValue As String, ByVal delimiter As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""

        '判斷是否為 民國年
        'True：是；False：不是
        Dim rocFlag As Boolean = True
        Try
            '定義年月日的參數
            Dim year As Integer = 0

            Dim mon As String = ""

            Dim day As String = ""

            '2016/02/02 Eddie,Lu: 將空格 Replace成空字串
            dateValue = dateValue.Replace(" ", "")

            '輸入為字串格式，為 y/MM/dd or yy/MM/dd or yyy/MM/dd => 回傳 yyyy/MM/dd
            If dateValue.Contains("/") And (dateValue.Length = 7 Or dateValue.Length = 8 Or dateValue.Length = 9) Then

                '去掉後面六位，從0開始取得，即為幾年
                year = CInt(dateValue.Substring(0, dateValue.Length - 6))

                '去掉後面五位，即為幾月的開頭
                mon = dateValue.Substring(dateValue.Length - 5, 2)

                '去掉後面兩位，即為幾日的開頭
                day = dateValue.Substring(dateValue.Length - 2, 2)


                '輸入為字串格式，為 y-MM-dd or yy-MM-dd or yyy-MM-dd => 回傳 yyyy-MM-dd
            ElseIf dateValue.Contains("-") And (dateValue.Length = 7 Or dateValue.Length = 8 Or dateValue.Length = 9) Then

                '去掉後面六位，從0開始取得，即為幾年
                year = CInt(dateValue.Substring(0, dateValue.Length - 6))

                '去掉後面五位，即為幾月的開頭
                mon = dateValue.Substring(dateValue.Length - 5, 2)

                '去掉後面兩位，即為幾日的開頭
                day = dateValue.Substring(dateValue.Length - 2, 2)

                '輸入為字串格式，為 yMMdd or yyMMdd or yyyMMdd => 回傳 yyyyMMdd
            ElseIf (dateValue.Length = 5 Or dateValue.Length = 6 Or dateValue.Length = 7) And Not (dateValue.Contains("-") Or dateValue.Contains("/")) Then

                '去掉後面四位，從0開始取得，即為幾年
                year = CInt(dateValue.Substring(0, dateValue.Length - 4))

                '去掉後面四位，即為幾月的開頭
                mon = dateValue.Substring(dateValue.Length - 4, 2)

                '去掉後面兩位，即為幾日的開頭
                day = dateValue.Substring(dateValue.Length - 2, 2)

            Else

                '不是民國年的正確格式
                rocFlag = False

            End If

            '判斷是否為民國前，是的話要多加一，因為沒有民國 0 年
            If year < 1 Then

                year = year + 1911 + 1

            Else

                year = year + 1911

            End If

            '判斷是否為合法的民國年
            '是的話, 回傳轉換結果
            '不是的話，回傳原值
            If rocFlag = True Then
                '組合年月日
                returnString = year.ToString.Trim & delimiter & mon & delimiter & day
            Else
                returnString = dateValue
            End If


            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region


#Region "     將民國年月日轉成西元年月日，並指定分隔符號 - 2 "


    ''' <summary>
    ''' 將民國年月日轉成西元年月日，delimiter 為分隔符號，以指定的分隔符號隔開
    ''' 
    ''' 輸入為字串格式，為 yyMMdd or yyyMMdd  , yy/MM/dd or yyy/MM/dd , yy-MM-dd or yyy-MM-dd 
    ''' 
    ''' 回傳 yyyy delimiter MM delimiter dd。
    ''' 
    ''' 若不為民國年，則回傳原始字串
    ''' 
    ''' </summary>
    ''' <param name="dateValue">民國年日期：yyMMdd、yyyMMdd、yy/MM/dd、yyy/MM/dd、yy-MM-dd、yyy-MM-dd </param>
    ''' <param name="delimiter">分隔符號</param>
    ''' <returns>String</returns>
    ''' <remarks>by Charles on 2016-6-28</remarks>
    Public Shared Function TransDateToGlobal(ByVal dateValue As String, ByVal delimiter As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""

        '判斷是否為 民國年
        'True：是；False：不是
        Dim rocFlag As Boolean = True
        Try
            '定義年月日的參數
            Dim year As Integer = 0

            Dim mon As String = ""

            Dim day As String = ""

            '取得TaiwanCultureInfo 時間
            Dim taiwanCultureInfo As CultureInfo
            taiwanCultureInfo = New CultureInfo("zh-TW")
            taiwanCultureInfo.DateTimeFormat.Calendar = New TaiwanCalendar()

            dateValue = dateValue.Replace(" ", "")

            '輸入為字串格式，為 yy/MM/dd or yyy/MM/dd => 回傳 yyyy/MM/dd
            '輸入為字串格式，為 yy-MM-dd or yyy-MM-dd => 回傳 yyyy-MM-dd
            If dateValue.Contains("/") OrElse dateValue.Contains("-") Then


                '正確的時間值：Date.Parse(theDate, taiwanCultureInfo)
                returnString = Date.Parse(dateValue, taiwanCultureInfo).Date.ToString("yyyy" & delimiter & "MM" & delimiter & "dd")

                '輸入為字串格式，為 yyMMdd or yyyMMdd => 回傳 yyyyMMdd
            ElseIf dateValue.Length = 6 Or dateValue.Length = 7 Then

                returnString = TransDateToWE(dateValue, delimiter)

            Else

                '不是民國年的正確格式
                rocFlag = False

            End If

            '判斷是否為合法的民國年
            '是的話, 回傳轉換結果
            '不是的話，回傳原值
            If Not rocFlag = True Then
                returnString = dateValue
            End If


            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function


#End Region

#End Region

#Region " 轉換時間，將四位數的時間數字OOXX，轉換成OO:XX，不為四位數則會回傳空字串"

    ''' <summary>
    ''' 轉換時間，將四位數的時間數字OOXX，轉換成OO:XX，不為四位數則會回傳空字串
    ''' </summary>
    ''' <param name="inputTime" >四位數的時間數字OOXX</param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2012-3-30</remarks>
    Public Shared Function TransStrToTime(ByVal inputTime As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""
        Try
            If inputTime.Length = 4 Then
                returnString = inputTime.Substring(0, 2) & ":" & inputTime.Substring(2, 2)
            End If
            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"轉換時間，將四位數的時間數字OOXX，轉換成OO:XX，不為四位數則會回傳空字串"}, caller:=caller)
        End Try
    End Function

#End Region

#Region " 轉換時間，將OO:XX，轉換成四位數的時間數字OOXX，不為OO:XX則會回傳空字串"

    ''' <summary>
    ''' 轉換時間，將OO:XX，轉換成四位數的時間數字OOXX，不為OO:XX則會回傳空字串
    ''' </summary>
    ''' <param name="inputTime" >時間OO:XX</param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2012-3-30</remarks>
    Public Shared Function TransTimeToStr(ByVal inputTime As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = ""
        Try
            If inputTime.Length = 5 And inputTime.IndexOf(":") = 2 Then
                returnString = inputTime.Substring(0, 2) & inputTime.Substring(3, 2)
            End If
            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region " 日期形態要 Insert 時使用，判斷是否是空字串，是的話，改成Null，否的話回傳原值 "

    ''' <summary>
    ''' 日期形態要 Insert 時使用，判斷是否是空字串，是的話，改成Null，否的話回傳原值，
    ''' 主要用於 將空字串轉成Null， 避免Insert DB 失敗
    ''' </summary>
    ''' <param name="dateString">字串型態的日期</param>
    ''' <remarks>by Sean.Lin on 2015-08-18</remarks>
    Private Function transDateToDBFormate(ByVal dateString As String) As Object

        Try

            '空字串轉成Null
            If dateString = "" Then

                Return DBNull.Value

            Else
                '非空則傳回原值
                Return dateString

            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("日期形態要 Insert 時使用，判斷是否是空字串，是的話，改成Null，否的話回傳原值", ex)
        End Try

    End Function

#End Region

    ''' <summary>
    ''' 將字串轉為特定的日期格式
    ''' </summary>
    ''' <param name="_strDateTime">日期字串</param>
    ''' <param name="_format">傳回的日期格式</param>
    ''' <returns>日期</returns>
    ''' <remarks>
    ''' 1.若是傳進來的日期可以轉換成指定的日期格式則傳會傳回轉換完成的日期字串否則傳回空白字串
    ''' 2.傳回的日期格式可以自己指定會是不指定會統一傳回yyyy/MM/dd HH:mm:ss的格式
    ''' </remarks>
    Public Shared Function toDateString(ByRef _strDateTime As Object, Optional ByVal _format As String = "yyyy/MM/dd HH:mm:ss") As String
        Try
            Dim _dt As Date
            If _strDateTime IsNot Nothing AndAlso _strDateTime IsNot DBNull.Value AndAlso DateTime.TryParse(_strDateTime, _dt) Then
                Return _dt.ToString(_format)
            Else
                'If (_strDateTime.Length = 0) Then log.Debug("toDateString Date=" + _strDateTime)
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 西元年轉7位民國年(yyymmdd)
    ''' </summary>
    ''' <param name="UsDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTwDate7StrForICCard(ByVal UsDate As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim Year As String = ""
            Dim Month As String = ""
            Dim Day As String = ""

            If IsDate(UsDate) Then
                Dim tempYear As Integer = CDate(UsDate).Year - 1911
                Dim tempYearAbsStr As String = Math.Abs(tempYear).ToString.Trim
                Dim bitNum As Integer = 3 - tempYearAbsStr.Length

                If tempYear < 0 Then
                    bitNum -= 1
                End If

                For iIndex As Integer = 1 To bitNum
                    Year += "0"
                Next

                Year += tempYearAbsStr

                If tempYear < 0 Then
                    Year = "-" + Year
                End If

                Month = CDate(UsDate).Month.ToString.Trim
                Day = CDate(UsDate).Day.ToString.Trim

                If Month.Length = 1 Then
                    Month = "0" & Month
                End If

                If Day.Length = 1 Then
                    Day = "0" & Day
                End If

                Return Year & Month & Day
            Else
                Return ""
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#Region " 將日期字串轉換成可轉成Date的字串(yyyyMMdd => yyyy-MM-dd)"
    ''' <summary>
    ''' 將日期字串轉換成可轉成Date的字串(yyyyMMdd => yyyy-MM-dd)。
    ''' </summary>
    ''' <param name="dateString" ></param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2011-11-8</remarks>
    Private Shared Function transDateStringToDate(ByVal dateString As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            'yyyyyMMdd 要轉型
            If dateString.Length = 8 Then
                dateString = dateString.Substring(0, 4) & "-" & dateString.Substring(4, 2) & "-" & dateString.Substring(6, 2)
            End If
            Return dateString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function
#End Region

    ''' <summary>
    ''' 回傳民國日期是否符合檢核模式
    ''' 考慮移除，聯絡敬發，只有OHMRptDataNewUI 使用
    ''' </summary>
    ''' <param name="VerifyDate"></param>
    ''' <param name="Length"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Modify@2011/07/18
    ''' By Charles
    ''' </remarks>
    Public Shared Function IsDateTextPassVerify(ByVal VerifyDate As String, ByVal Length As Integer) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            'YY、 YYY、YYMM、YYYMM、YYMMDD、YYYMMDD
            Dim RtnBool = False
            Select Case Length
                Case 2
                    'YY
                    RtnBool = RegularExpressions.Regex.Match(VerifyDate, "(\d{2})").Success
                Case 3
                    'YYY
                    RtnBool = RegularExpressions.Regex.Match(VerifyDate, "(\d{3})").Success
                Case 4
                    'YYMM
                    RtnBool = RegularExpressions.Regex.Match(VerifyDate, "(\d{2})([1])([0-2])|(\d{2})([0])(\d{1})").Success
                Case 5
                    'YYYMM
                    RtnBool = RegularExpressions.Regex.Match(VerifyDate, "(\d{3})([1])([0-2])|(\d{3})([0])(\d{1})").Success
                Case 6
                    'YYMMDD
                    RtnBool = RegularExpressions.Regex.Match(VerifyDate, "([0-9]{2})([1])([0-2])([0-2])(\d{1})|([0-9]{2})([0])(\d{1})([0-2])(\d{1})|" & _
                                                             "([0-9]{2})([1])([0-2])([3])([0-1])|([0-9]{2})([0])(\d{1})([3])([0-1])").Success
                    Try
                        Dim MyYear As String = VerifyDate.Substring(0, 2)
                        MyYear = CInt(MyYear) + 1911
                        Dim Mydate = CDate(MyYear & "/" & VerifyDate.Substring(2, 2) & "/" & VerifyDate.Substring(4, 2))
                        RtnBool = True
                    Catch ex As Exception
                        RtnBool = False
                    End Try
                Case 7
                    'YYYMMDD
                    RtnBool = RegularExpressions.Regex.Match(VerifyDate, "([0-9]{3})([1])([0-2])([0-2])(\d{1})|([0-9]{3})([0])(\d{1})([0-2])(\d{1})|" & _
                                                             "([0-9]{3})([1])([0-2])([3])([0-1])|([0-9]{3})([0])(\d{1})([3])([0-1])").Success
                    Try
                        Dim MyYear As String = VerifyDate.Substring(0, 3)
                        MyYear = CInt(MyYear) + 1911
                        Dim Mydate = CDate(MyYear & "/" & VerifyDate.Substring(3, 2) & "/" & VerifyDate.Substring(5, 2))
                        RtnBool = True
                    Catch ex As Exception
                        RtnBool = False
                    End Try
            End Select

            Return RtnBool
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#Region "UCL用 2010/7/19"

    ''' <summary>
    ''' 回傳台灣日期的年份
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTwYear(ByVal d As String) As Integer
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If d <> "" Then
                Dim temp As String() = d.Split("/")

                Return CType(temp(0), Integer)
            Else
                Return 0
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 回傳西元日期的年份
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetUsYear(ByVal d As String) As Integer
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If d <> "" Then
                Dim da As Date = CType(d, Date)
                Return da.Year
            Else
                Return 0
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 回傳日期的月份
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMonth(ByVal d As String) As Integer
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If d <> "" Then
                Dim da As Date = CType(d, Date)
                Return da.Month
            Else
                Return 0
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 回傳日期的日數
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDay(ByVal d As String) As Integer
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If d <> "" Then
                Dim da As Date = CType(d, Date)
                Return da.Day
            Else
                Return 0
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

    ''' <summary>
    ''' 暫時加上以接上舊有多個程式使用
    ''' </summary>
    ''' <param name="targetValue"></param>
    ''' <param name="Format"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseStringToDateTime(ByVal targetValue As String, ByVal Format As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            '2015/10/16 註解 By Charles
            'Return CDate(targetValue).ToString(Format)

            '2015/10/16 先改用舊版
            Dim _dt As DateTime
            If (DateTime.TryParseExact(targetValue, _datetimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, _dt)) Then
                Return _dt.ToString(Format)
            Else

                Return ""
            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 取得系統日期(西元年)
    ''' </summary>
    ''' <returns>西元年系統日期</returns>
    ''' <remarks></remarks>
    Public Shared Function getSystemDate() As Date
        Try
            Return CDate(String.Format("{0:u}", Now.AddHours(-8)))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得系統日期(西元年)
    ''' </summary>
    ''' <param name="format">日期格式</param>
    ''' <returns>西元年系統日期</returns>
    ''' <remarks></remarks>
    Public Shared Function SystemDate(ByVal format As String) As String
        Try
            Return CDate(String.Format("{0:u}", Now.AddHours(-8))).ToString(format)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得傳入日期所對應之星期
    ''' </summary>
    ''' <param name="USDate">日期(YYYY/MM/DD)</param>
    ''' <returns>星期別(1:星期一,2:星期二,...,7:星期日</returns>
    ''' <remarks></remarks>
    Public Shared Function computeDayOfWeek(ByVal USDate As String) As Integer
        Try
            Dim pvtWeek As Integer


            pvtWeek = CDate(USDate).DayOfWeek()

            If pvtWeek = 0 Then
                pvtWeek = 7
            End If

            Return pvtWeek
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
