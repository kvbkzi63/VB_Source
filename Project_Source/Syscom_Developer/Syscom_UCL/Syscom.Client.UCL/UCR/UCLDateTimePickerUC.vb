Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Configuration
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.BASE

Public Class UCLDateTimePickerUC

#Region "     變數宣告"

    Dim data As StringBuilder = New StringBuilder
    Dim us As CultureInfo = New CultureInfo("en-US", True)
    Dim tw As CultureInfo = New CultureInfo("zh-TW", True)
    Private Shared dateFormats As String() = {"yyyy/MM/dd", "yyyy/MM/d", "yyyy/M/dd", "yyyy/M/d", "yyyyMMdd", _
                                                            "yyyy/MM/dd tt hh:mm:ss", "yyyy/MM/d tt hh:mm:ss", "yyyy/M/dd tt hh:mm:ss", "yyyy/M/d tt hh:mm:ss", _
                                                            "yyyy/MM/dd 上午 hh:mm:ss", "yyyy/MM/d 上午 hh:mm:ss", "yyyy/M/dd 上午 hh:mm:ss", "yyyy/M/d 上午 hh:mm:ss", _
                                                            "yyyy/MM/dd 下午 hh:mm:ss", "yyyy/MM/d 下午 hh:mm:ss", "yyyy/M/dd 下午 hh:mm:ss", "yyyy/M/d 下午 hh:mm:ss"}
    '西元年
    Private enDateString As String = ""
    '民國年
    Private twDateString As String = ""

    Private _DisplayLocale As Integer = Locale.US
    Private _DisplayMode As Integer = DisplayType.SystemDefault

    ' Private display As Locale

    Private Const startYear As Integer = 1930
    Private Const yearRange As Integer = 100

    Private _MaxDate As Date = CDate("9998/1/1")
    Private _MinDate As Date = CDate("1800/1/1")
    Private Date1, Date2 As String

    Public Event ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Shadows Event KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    Public Event DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs)

    Private _uclReadOnly As Boolean = False
    Private _uclIsFixedBackColor As Boolean = False
    Dim CanChangeValue As Boolean = True
    Dim IsShowError As Boolean = False
    Dim IsClear As Boolean = False

#End Region

#Region "     屬性設定"


    Public Enum Locale
        TW
        US
    End Enum

    Public Enum DisplayType
        SystemDefault
        Custom
    End Enum

    Public Property MaxDate() As Date
        Get
            Return baseDTP.MaxDate
        End Get
        Set(ByVal value As Date)
            baseDTP.MaxDate = value
        End Set
    End Property


    Public Property MinDate() As Date
        Get
            Return baseDTP.MinDate
        End Get
        Set(ByVal value As Date)
            baseDTP.MinDate = value
        End Set
    End Property

    ''' <summary>
    ''' 設定背景顏色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property BackColor() As Color
        Get
            Return baseMTB.BackColor
        End Get
        Set(ByVal value As Color)
            baseMTB.BackColor = value
        End Set
    End Property

    ''' <summary>
    ''' 設定為唯讀
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclReadOnly() As Boolean
        Get
            Return baseMTB.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            If Not value Then
                CanChangeValue = Not value
            End If

            baseMTB.ReadOnly = value
        End Set
    End Property


    ''' <summary>
    ''' 設定是否固定背景色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclIsFixedBackColor() As Boolean
        Get
            Return _uclIsFixedBackColor
        End Get
        Set(ByVal value As Boolean)
            _uclIsFixedBackColor = value
        End Set
    End Property

    ''' <summary>
    ''' 取得/設定 輸入的日期字串
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Overrides Property Text() As String

        Get
            Return baseMTB.Text
        End Get
        Set(ByVal value As String)
            If (value.Trim.Length = 0) Then
                Clear()
            Else
                Select Case DisplayLocale
                    Case Locale.TW
                        baseMTB.Text = value.PadLeft(7)
                    Case Locale.US
                        baseMTB.Text = value.PadLeft(8)
                End Select

            End If

        End Set
    End Property

    ''' <summary>
    ''' 顯示民國年或西元年
    ''' </summary>
    ''' <returns>DisplayType</returns>
    ''' <remarks></remarks>
    Public Property DisplayMode() As DisplayType
        Get
            Return _DisplayMode
        End Get
        Set(ByVal value As DisplayType)
            _DisplayMode = value
        End Set
    End Property

    ''' <summary>
    ''' 設定display民國年or西元年
    ''' </summary>
    ''' <returns>Locale</returns>
    ''' <remarks></remarks>
    Public Property DisplayLocale() As Locale
        Get
            Return _DisplayLocale
        End Get
        Set(ByVal value As Locale)
            _DisplayLocale = value
            If baseMTB.Mask = "" Then
                Select Case value

                    Case Locale.TW
                        baseMTB.Mask = "###/00/00"
                    Case Locale.US
                        baseMTB.Mask = "####/00/00"
                End Select
            End If

        End Set
    End Property


#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "
    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        '設定成共用的字型
        Me.Font = AppConfigUtil.ControlFont

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。


    End Sub

    ''' <summary>
    ''' 是否為空
    ''' </summary>
    ''' <remarks>Boolean</remarks>
    Public Function IsEmpty() As Boolean
        Dim isFlag As Boolean = False
        Try
            Dim dateArr() As String
            Dim value As String = baseMTB.Text

            dateArr = splitDate(value.Trim)
            data.Length = 0
            For i = 0 To dateArr.Length - 1
                data.Append(dateArr(i))
            Next
            If (data.ToString.Trim.Length = 0) Then
                isFlag = True
            End If
            Return isFlag
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

    ''' <summary>
    ''' 是否為日期
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Function CheckIsDate() As Boolean
        Dim isFlag As Boolean = True
        Try
            isFlag = TransDate(baseMTB.Text.Trim)
            Return isFlag
        Catch ex As Exception
            isFlag = False
            clearDate()
            Return isFlag
        End Try
    End Function

    ''' <summary>
    ''' 設定日期
    ''' </summary>
    ''' <param name="dStr">日期字串 ex "2015/01/01"</param>
    ''' <remarks></remarks>
    Public Overloads Sub SetValue(ByVal dStr As String)
        Try
            DetermineDisplayType()
            If dStr = "" Then
                Clear()

            ElseIf IsDate(dStr) Then

                If CDate(dStr).ToString(DateUtil.DateTypeDash) = "1900-01-01" Then

                    Clear()

                Else
                    IsClear = False
                    baseDTP.Value = CDate(dStr).ToString
                    DoValueChanged()

                End If


            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 設定日期
    ''' </summary>
    ''' <param name="d">Date</param>
    ''' <remarks></remarks>
    Public Overloads Sub SetValue(ByVal d As Date)
        DetermineDisplayType()
        IsClear = False
        baseDTP.Value = d
        DoValueChanged()
    End Sub

    ''' <summary>
    ''' 取得民國年日期
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Function GetTwDateStr() As String
        If (baseMTB.Focused) Then baseDTP.Focus()

        If twDateString = "" Then
            Return twDateString ' "1900-01-01"
        Else
            Return twDateString
        End If

    End Function

    ''' <summary>
    ''' 取得西元年日期字串
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Function GetUsDateStr() As String
        If (baseMTB.Focused) Then baseDTP.Focus()

        If enDateString = "" Then
            Return enDateString '"1900-01-01"
        Else
            Return enDateString
        End If

    End Function

    ''' <summary>
    ''' 取得年份
    ''' </summary>
    ''' <param name="type">民國或西元</param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Function GetYear(ByVal type As Locale) As Integer
        Select Case type
            Case Locale.TW
                Return DateUtil.GetTwYear(GetTwDateStr())
            Case Locale.US
                Return DateUtil.GetUsYear(GetUsDateStr())
            Case Else
                Return 0
        End Select
    End Function

    ''' <summary>
    ''' 取得月份
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Function GetMonth() As Integer
        Return DateUtil.GetMonth(GetUsDateStr())
    End Function

    ''' <summary>
    ''' 取得日
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Function GetDay() As Integer
        Return DateUtil.GetDay(GetUsDateStr())


    End Function

    ''' <summary>
    ''' 清除畫面
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()

        IsClear = True

        baseMTB.Text = ""
        baseDTP.CustomFormat = " "
        enDateString = ""
        twDateString = ""
        If Not uclIsFixedBackColor Then
            baseMTB.BackColor = Color.White
        End If

        baseDTP.Value = Now
        RaiseEvent ValueChanged(Me, New System.EventArgs)

    End Sub
#End Region

#Region "     內部函數 "
    ''' <summary>
    ''' 日期正確性檢驗
    ''' </summary>
    ''' <param name="value">日期</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Private Function TransDate(ByVal value As String) As Boolean
        Dim isDateFlag As Boolean = False
        Try
            Dim enDate As String = ""
            Dim twDate As String = ""
            Dim dateArr() As String
            Dim en_Date As DateTime

            dateArr = splitDate(value.Trim)
            If (DisplayLocale = Locale.TW) Then
                If (value.Trim.Substring(0, 1).Equals("-") Or dateArr(0).Trim.Equals("0")) Then
                    value = ROCBefore(value)
                Else
                    value = TranEW(value.Trim, "/")
                End If
            Else
                Select Case dateArr(0).Trim.Length
                    Case 1, 2
                        dateArr(0) = checkYear(dateArr(0).Trim)
                        data.Length = 0
                        data.Append(dateArr(0)).Append("/").Append(dateArr(1)).Append("/").Append(dateArr(2))
                        value = data.ToString
                        baseMTB.Text = value
                End Select
            End If

            If (dateArr.Length = 1 AndAlso dateArr(0).Trim.Equals("")) Then
                isDateFlag = True
            Else
                en_Date = DateTime.ParseExact(value, dateFormats, us, DateTimeStyles.AllowWhiteSpaces)
                '西元年(格式:yyyy/MM/dd)
                enDate = combineEnDate(en_Date.ToString("yyyy/MM/dd", us), "/")
                twDate = TranWE(en_Date, "/")

                isDateFlag = True
            End If
            twDateString = twDate
            enDateString = enDate
            Return isDateFlag
        Catch ex As Exception
            'Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return isDateFlag
        End Try

    End Function

    ''' <summary>
    ''' 傳回西元年格式yyyy/MM/dd
    ''' </summary>
    ''' <param name="value">日期</param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function ROCBefore(ByVal value As String) As String
        Dim return_date As String = ""
        Try
            Dim year, month, day As String
            Dim dateArr() As String


            dateArr = splitDate(value)
            If (dateArr.Length = 1) Then
                year = value.Trim.Substring(0, value.Trim.Length - 4)
                month = appendChar(value.Trim.Substring(value.Trim.Length - 4, 2), CChar("0"), 2)
                day = appendChar(value.Trim.Substring(value.Trim.Length - 2, 2), CChar("0"), 2)
            Else
                year = dateArr(0).Trim
                month = appendChar(dateArr(1), CChar("0"), 2)
                day = appendChar(dateArr(2), CChar("0"), 2)
            End If

            If CInt(year) > 0 Then
                year = (1911 + CInt(year)).ToString
            Else
                year = (1912 + CInt(year)).ToString
            End If

            data.Length = 0
            data.Append(year).Append("/").Append(month).Append("/").Append(day)
            return_date = data.ToString
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
        Return return_date
    End Function

    ''' <summary>
    ''' 西元年轉民國年(格式:yyyyMMdd)
    ''' </summary>
    ''' <param name="value">日期</param>
    ''' <remarks></remarks>
    Private Function TranWE(ByVal value As Date) As String
        Try
            Dim twDate As String
            Dim year, month, day As String
            data.Length = 0
            If (value.Year <= 1911) Then
                year = (value.Year - 1912).ToString.PadLeft(3)
                month = appendChar(value.Month.ToString, CChar("0"), 2)
                day = appendChar(value.Day.ToString, CChar("0"), 2)
                twDate = (data.Append(year).Append(month).Append(day)).ToString
            Else
                tw.DateTimeFormat.Calendar = New TaiwanCalendar
                twDate = value.ToString("yyyyMMdd", tw)
            End If

            Return twDate
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' 西元年轉民國年
    ''' </summary>
    ''' <param name="value">日期</param>
    ''' <param name="delimiter">分隔字元</param>
    ''' <remarks></remarks>
    '''
    Private Function TranWE(ByVal value As Date, ByVal delimiter As String) As String
        Try
            Dim twDate As String
            Dim year, month, day, format As String
            data.Length = 0
            If (value.Year <= 1911) Then
                year = (value.Year - 1912).ToString.PadLeft(3)
                month = appendChar(value.Month.ToString, CChar("0"), 2)
                day = appendChar(value.Day.ToString, CChar("0"), 2)
                twDate = (data.Append(year).Append(delimiter).Append(month).Append(delimiter).Append(day)).ToString
            Else
                format = (data.Append("yyyy").Append(delimiter).Append("MM").Append(delimiter).Append("dd")).ToString
                tw.DateTimeFormat.Calendar = New TaiwanCalendar
                twDate = value.ToString(format, tw)
            End If
            Return twDate
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

    Private Function splitDate(ByVal value As String) As String()
        Dim dateArr() As String
        Try
            data.Length = 0
            Dim separator() As String = {"/"}
            dateArr = value.Trim.Split(separator, StringSplitOptions.RemoveEmptyEntries)
            Return dateArr
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 民國年轉西元年(不含日期正確性檢驗)
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="delimiter"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TranEW(ByVal value As String, ByVal delimiter As String) As String
        Try
            Dim year, month, day As String
            data.Length = 0
            Dim dateArr() As String = splitDate(value.Trim)

            If (dateArr.Length > 1) Then
                If CInt(dateArr(0).Trim) > 0 Then
                    year = (CInt(dateArr(0).Trim) + 1911).ToString
                Else
                    year = (CInt(dateArr(0).Trim) + 1912).ToString
                End If

                month = IIf((dateArr(1).Trim).Length = 1, "0" + dateArr(1).Trim, dateArr(1).Trim).ToString
                day = IIf((dateArr(2).Trim).Length = 1, "0" + dateArr(2).Trim, dateArr(2).Trim).ToString
                data.Append(year).Append(delimiter).Append(month).Append(delimiter).Append(day)
            End If
            Return data.ToString
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' 民國年轉西元年(不含日期正確性檢驗)
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TranEW(ByVal value As String) As String
        Try
            Return TranEW(value, "")
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

    Private Sub DoValueChanged()
        Try

            If Not CanChangeValue Then
                Exit Sub
            End If

            If IsClear Then
                IsClear = False
                Exit Sub

            End If

            IsShowError = True
            Dim twDate As String = ""

            Dim TwMinDate As Date = New Date(1912, 1, 1)



            baseDTP.CustomFormat = ""
            tw.DateTimeFormat.Calendar = New TaiwanCalendar

            If TwMinDate <= baseDTP.Value Then
                twDate = baseDTP.Value.ToString("yyyyMMdd", tw)
                twDateString = baseDTP.Value.ToString("yyyy/MM/dd", tw)

            Else
                baseMTB.Text = baseDTP.Value.Year & "/" & baseDTP.Value.Month & "/" & baseDTP.Value.Day
                If baseDTP.Value.Year < 1912 Then
                    twDateString = baseDTP.Value.Year - 1912 & "/" & baseDTP.Value.Month & "/" & baseDTP.Value.Day
                End If
            End If


            Dim maskStr = baseMTB.Mask
            baseMTB.Mask = ""

            If DisplayLocale = Locale.TW AndAlso baseDTP.Value.Year < 1912 Then
                baseMTB.Text = baseDTP.Value.Year - 1912 & "/" & baseDTP.Value.Month & "/" & baseDTP.Value.Day
                twDateString = baseMTB.Text
                enDateString = baseDTP.Value.Year & "/" & baseDTP.Value.Month & "/" & baseDTP.Value.Day

            Else

                Select Case DisplayLocale



                    Case Locale.TW
                        Dim HasMinus As Boolean = False
                        baseMTB.Text = twDate.PadLeft(7)
                        If baseMTB.Text.Trim = "" Then
                            clearDate()
                            baseMTB.Mask = "###/00/00"
                            Exit Sub

                        Else

                            ' baseMTB.Text = baseDTP.Value.Year & "/" & baseDTP.Value.Month & "/" & baseDTP.Value.Day
                            If baseMTB.Text.Contains("-") Then
                                HasMinus = True
                            End If

                            baseMTB.Text = baseMTB.Text.Trim.Replace("/", "")
                            baseMTB.Text = baseMTB.Text.Trim.Replace("-", "")

                            If baseMTB.Text.Trim = 5 Then
                                baseMTB.Text = "00" & baseMTB.Text.Substring(0, 1) & "/" & baseMTB.Text.Substring(1, 2) & "/" & baseMTB.Text.Substring(3, 2)
                            ElseIf baseMTB.Text.Trim.Length = 6 Then
                                baseMTB.Text = "0" & baseMTB.Text.Substring(0, 2) & "/" & baseMTB.Text.Substring(2, 2) & "/" & baseMTB.Text.Substring(4, 2)
                            ElseIf baseMTB.Text.Trim.Length = 7 Then
                                baseMTB.Text = baseMTB.Text.Substring(0, 3) & "/" & baseMTB.Text.Substring(3, 2) & "/" & baseMTB.Text.Substring(5, 2)
                            End If

                            If HasMinus Then
                                baseMTB.Text = "-" & baseMTB.Text
                            End If
                        End If
                    Case Locale.US

                        baseMTB.Text = TranEW(twDateString)

                        If baseMTB.Text.Trim = "" Then
                            clearDate()
                            baseMTB.Mask = "####/00/00"
                            Exit Sub

                        Else

                            If IsNumeric(baseMTB.Text.Trim) AndAlso baseMTB.Text.Trim.Length = 8 Then
                                baseMTB.Text = baseMTB.Text.Substring(0, 4) & "/" & baseMTB.Text.Substring(4, 2) & "/" & baseMTB.Text.Substring(6, 2)

                            ElseIf IsNumeric(baseMTB.Text.Trim) AndAlso baseMTB.Text.Trim.Length = 6 Then
                                baseMTB.Text = "20" & baseMTB.Text.Substring(0, 2) & "/" & baseMTB.Text.Substring(2, 2) & "/" & baseMTB.Text.Substring(4, 2)
                            Else
                                InvalidDate()
                                Exit Sub
                            End If
                        End If



                        '  SetValue(baseDTP.Value)
                End Select
                enDateString = TranEW(twDateString, "/")

            End If

            Select Case DisplayLocale
                Case Locale.TW
                    If (baseMTB.Text.Contains("-")) Then
                        maskStr = "####/00/00"
                    Else
                        maskStr = "###/00/00"
                    End If

                Case Locale.US
                    maskStr = "####/00/00"
            End Select


            baseMTB.Mask = maskStr

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub InvalidDate()
        If IsShowError Then
            'baseMTB.Focus()
            clearDate()

            If Not uclIsFixedBackColor Then
                baseMTB.BackColor = Color.Pink
            End If
             
            MessageBox.Show("日期格式錯誤")
            IsShowError = False
        End If

    End Sub

    Private Function checkYear(ByVal year As String) As String
        Try
            Dim value As String = ""
            Dim nowYear As Integer = CInt(IIf(Date.Today.Year < 1930, 1930, Date.Today.Year))
            Dim sYear, eYear, oYear, cYear As Integer
            oYear = CInt(year)
            cYear = 1900
            For i = 0 To 1000
                cYear = cYear + (yearRange * i)
                sYear = startYear + (yearRange * i)
                eYear = sYear + yearRange
                If (nowYear >= sYear AndAlso nowYear < eYear) Then
                    Select Case CInt(year)
                        Case 0 To 29
                            value = appendChar((cYear + yearRange + oYear).ToString, CChar("0"), 4)
                        Case Else
                            value = appendChar((cYear + oYear).ToString, CChar("0"), 4)
                    End Select
                    Exit For
                End If
            Next
            Return value

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

    Private Function appendChar(ByVal srcString As String, ByVal apdChar As Char, ByVal totalLength As Integer) As String
        If (srcString Is Nothing) Then
            srcString = ""
        End If
        If srcString.Length > totalLength Then
            srcString = srcString.Substring(0, totalLength)
        ElseIf srcString.Length < totalLength Then
            For i = 1 To totalLength - srcString.Length
                srcString = apdChar & srcString
            Next
        End If
        Return srcString
    End Function

    Private Sub DetermineDisplayType()
        If (DisplayMode = DisplayType.SystemDefault) Then
            Dim dateText As String = baseMTB.Text.Trim
            Try


                If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then
                    DisplayLocale = Locale.TW
                    If (dateText.Contains("-")) Then
                        baseMTB.Mask = "####/00/00"
                    End If
                Else
                    DisplayLocale = Locale.US
                End If


                baseMTB.Text = dateText
            Catch ex As Exception
                DisplayLocale = Locale.TW
                baseMTB.Text = dateText
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 清除日期
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearDate()
        enDateString = ""
        twDateString = ""

    End Sub

    ''' <summary>
    ''' 組合日期
    ''' </summary>
    ''' <param name="value">DateTime</param>
    ''' <param name="delimiter">分隔符號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function combineEnDate(ByVal value As DateTime, ByVal delimiter As String) As String
        Try
            Dim year, month, day As String

            data.Length = 0
            year = appendChar(value.Year.ToString, CChar("0"), 4)
            month = appendChar(value.Month.ToString, CChar("0"), 2)
            day = appendChar(value.Day.ToString, CChar("0"), 2)
            data.Append(year).Append(delimiter).Append(month).Append(delimiter).Append(day)
            Return data.ToString
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' 組合日期
    ''' </summary>
    ''' <param name="value">String</param>
    ''' <param name="delimiter">分隔符號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function combineEnDate(ByVal value As String, ByVal delimiter As String) As String
        Try
            Dim year, month, day As String
            Dim dateArr() As String
            data.Length = 0
            dateArr = splitDate(value)
            If (dateArr.Length > 1) Then
                year = appendChar(dateArr(0).Trim.ToString, CChar("0"), 4)
                month = appendChar(dateArr(1).Trim.ToString, CChar("0"), 2)
                day = appendChar(dateArr(2).Trim.ToString, CChar("0"), 2)
                data.Append(year).Append(delimiter).Append(month).Append(delimiter).Append(day)
            End If

            Return data.ToString
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function
#End Region

#Region "     事件集合 "

    Private Sub UCLDateTimePickerUI_Temp_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        If UCLFormUtil.isResizeable Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
            baseMTB.Anchor = AnchorStyles.Left
            baseMTB.Anchor = AnchorStyles.Right
            baseMTB.Dock = DockStyle.None

            '調整UCLDateTimePickerUC的寬度，避免遮住日曆圖示
            baseMTB.Width = Me.Width - 35
            baseMTB.Top = 2
            baseMTB.Left = 2
        Else
            Me.Height = 27
        End If

    End Sub
    Private Sub baseDTP_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles baseDTP.ValueChanged ', baseDTP.CloseUp

        DoValueChanged()
        RaiseEvent ValueChanged(sender, e)
    End Sub
    Private Sub baseMTB_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles baseMTB.Enter
        Dim col As Color = baseMTB.BackColor
        If DisplayLocale = Locale.TW Then
            '  baseMTB.Mask = "###0000"

            Date1 = baseMTB.Text.Trim
            baseMTB.Mask = ""
            baseMTB.Text = baseMTB.Text.Trim.Replace("/", "")

        ElseIf DisplayLocale = Locale.US Then
            'baseMTB.Mask = "####0000"
            baseMTB.Mask = ""
            baseMTB.Text = baseMTB.Text.Trim.Replace("/", "")
        End If
        If Not uclIsFixedBackColor Then
            baseMTB.BackColor = col
        End If

    End Sub
    Private Sub baseMTB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles baseMTB.TextChanged
        IsShowError = True
        If Not uclIsFixedBackColor Then
            baseMTB.BackColor = Color.White
        End If

    End Sub
    Private Sub baseDTP_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles baseDTP.DropDown
        If uclReadOnly Then
            CanChangeValue = False
        End If
        IsClear = False

        'If baseDTP.Value = CDate("1900/01/01") Then
        '    baseDTP.
        'End If
        RaiseEvent DropDown(sender, e)
    End Sub
    Private Sub baseDTP_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles baseDTP.CloseUp
        Dim IsChanged As Boolean = False

        Dim CurrentDateStr As String = baseMTB.Text

        DoValueChanged()

        If Not IsDate(CurrentDateStr) OrElse (IsDate(CurrentDateStr) AndAlso CDate(CurrentDateStr).Date <> CDate(baseMTB.Text).Date) Then

            RaiseEvent ValueChanged(sender, e)
        End If

        RaiseEvent CloseUp(sender, e)


    End Sub
    Private Sub baseMTB_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles baseMTB.KeyUp
        If e.KeyCode = Keys.Enter Then
            'baseMTB.Focus()
            baseMTB_Leave(sender, e)
        End If

        RaiseEvent KeyUp(sender, e)

    End Sub
    Private Sub baseMTB_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles baseMTB.Leave
        Try
            DetermineDisplayType()
            Dim maskStr As String = baseMTB.Mask
            baseMTB.Mask = ""
            baseMTB.Text = baseMTB.Text.Trim.Replace("/", "")


            If DisplayLocale = Locale.TW Then

                If baseMTB.Text.Trim = "" Then
                    clearDate()

                    baseMTB.Mask = "###/00/00"

                    Date2 = baseMTB.Text.Trim

                    If Date1 <> Date2 Then
                        RaiseEvent ValueChanged(sender, e)
                    End If

                    Exit Sub

                Else

                    If IsNumeric(baseMTB.Text.Trim) AndAlso baseMTB.Text.Trim.Length >= 5 Then
                        If baseMTB.Text.Trim.Contains("-") AndAlso baseMTB.Text.Trim.Length <= 8 Then

                            If baseMTB.Text.Trim.Length = 6 Then
                                baseMTB.Text = "00" & baseMTB.Text.Substring(0, 2) & "/" & baseMTB.Text.Substring(2, 2) & "/" & baseMTB.Text.Substring(4, 2)
                                'If CInt(baseMTB.Text.Substring(0, 2)) = 0 Then
                                '    InvalidDate()
                                '    Exit Sub
                                'End If
                            ElseIf baseMTB.Text.Trim.Length = 7 Then
                                baseMTB.Text = "0" & baseMTB.Text.Substring(0, 3) & "/" & baseMTB.Text.Substring(3, 2) & "/" & baseMTB.Text.Substring(5, 2)

                            ElseIf baseMTB.Text.Trim.Length = 8 Then
                                baseMTB.Text = baseMTB.Text.Substring(0, 4) & "/" & baseMTB.Text.Substring(4, 2) & "/" & baseMTB.Text.Substring(6, 2)

                            End If

                            baseMTB.Text = baseMTB.Text.Trim.Replace("-", "")
                            baseMTB.Text = "-" & baseMTB.Text

                        ElseIf Not baseMTB.Text.Trim.Contains("-") AndAlso baseMTB.Text.Trim.Length <= 7 Then
                            If baseMTB.Text.Trim.Length = 5 Then

                                If CInt(baseMTB.Text.Substring(0, 1)) = 0 Then
                                    InvalidDate()
                                    Exit Sub
                                End If

                                baseMTB.Text = "00" & baseMTB.Text.Substring(0, 1) & "/" & baseMTB.Text.Substring(1, 2) & "/" & baseMTB.Text.Substring(3, 2)

                            ElseIf baseMTB.Text.Trim.Length = 6 Then

                                If CInt(baseMTB.Text.Substring(0, 2)) = 0 Then
                                    InvalidDate()
                                    Exit Sub
                                End If

                                baseMTB.Text = "0" & baseMTB.Text.Substring(0, 2) & "/" & baseMTB.Text.Substring(2, 2) & "/" & baseMTB.Text.Substring(4, 2)

                            ElseIf baseMTB.Text.Trim.Length = 7 Then

                                If CInt(baseMTB.Text.Substring(0, 3)) = 0 Then
                                    InvalidDate()
                                    Exit Sub
                                End If

                                baseMTB.Text = baseMTB.Text.Substring(0, 3) & "/" & baseMTB.Text.Substring(3, 2) & "/" & baseMTB.Text.Substring(5, 2)

                            End If
                        Else
                            InvalidDate()
                            Exit Sub
                        End If

                    Else
                        InvalidDate()
                        Exit Sub

                    End If

                End If

            ElseIf DisplayLocale = Locale.US Then

                If baseMTB.Text.Trim = "" Then
                    clearDate()
                    baseMTB.Mask = "####/00/00"

                    Date2 = baseMTB.Text.Trim

                    If Date1 <> Date2 Then
                        RaiseEvent ValueChanged(sender, e)
                    End If

                    Exit Sub

                Else

                    If IsNumeric(baseMTB.Text.Trim) AndAlso baseMTB.Text.Trim.Length = 8 Then
                        baseMTB.Text = baseMTB.Text.Substring(0, 4) & "/" & baseMTB.Text.Substring(4, 2) & "/" & baseMTB.Text.Substring(6, 2)

                    ElseIf IsNumeric(baseMTB.Text.Trim) AndAlso baseMTB.Text.Trim.Length = 6 Then
                        baseMTB.Text = "20" & baseMTB.Text.Substring(0, 2) & "/" & baseMTB.Text.Substring(2, 2) & "/" & baseMTB.Text.Substring(4, 2)
                    Else
                        InvalidDate()
                        Exit Sub
                    End If
                End If

            End If

            '  Console.WriteLine("Text:" & baseMTB.Text)

            Dim flag As Boolean = TransDate(baseMTB.Text.Trim)
            If (Not flag) Then
                InvalidDate()
                Exit Sub
            Else
                If Not uclIsFixedBackColor Then
                    baseMTB.BackColor = Color.White
                End If

            End If

            Date2 = baseMTB.Text.Trim

            If Date1 <> Date2 Then
                RaiseEvent ValueChanged(sender, e)
            End If
            baseMTB.Mask = maskStr
        Catch ex As Exception
            InvalidDate()
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub
    Private Sub UCLDateTimePickerUC_Layout(sender As Object, e As LayoutEventArgs) Handles MyBase.Layout
        DetermineDisplayType()
    End Sub
#End Region
End Class
