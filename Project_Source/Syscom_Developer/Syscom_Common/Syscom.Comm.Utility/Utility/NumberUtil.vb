Imports System.Text
Imports System.Reflection
Imports Syscom.Comm.EXP

Public Class NumberUtil

    '大寫數字
    Private Shared NUMBERS() As String = {"零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖"}
    '整數
    Private Shared IUNIT() As String = {"元", "拾", "佰", "仟", "萬", "拾", "佰", "仟", "億", "拾", "佰", "仟", "萬", "拾", "佰", "仟"}
    '小數
    Private Shared DUNIT() As String = {"角", "分", "厘"}

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 大寫金額
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Convert(ByVal str As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            str = str.Replace(",", "") '// 去掉","
            Dim integerStr As String ';// 整數
            Dim decimalStr As String ';// 小數

            '// 分離小數整數
            If (str.IndexOf(".") > 0) Then
                integerStr = str.Substring(0, str.IndexOf("."))
                decimalStr = str.Substring(str.IndexOf(".") + 1)
            ElseIf (str.IndexOf(".") = 0) Then
                integerStr = ""
                decimalStr = str.Substring(1)
            Else
                integerStr = str
                decimalStr = ""
            End If
            '// integerStr去掉首0，不必去掉decimalStr的尾0(超出部分除去)
            If Not integerStr.Equals("") Then
                integerStr = CStr((Long.Parse(integerStr)))
                If integerStr.Equals("0") Then
                    integerStr = ""
                End If
            End If
            '// overflow超出處理範圍
            If (integerStr.Length() > IUNIT.Length) Then
                Return str
            End If

            Dim integers() As Integer = toArray(integerStr) ';// 整數部份
            Dim isMust5 As Boolean = isMust5w(integerStr) ';// 配置萬
            Dim decimals() As Integer = toArray(decimalStr) ';//小數
            Return getChineseInteger(integers, isMust5) + getChineseDecimal(decimals)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 檢查開始值(區間)與比較值(區間)是否重疊
    ''' </summary>
    ''' <param name="startPeriod"></param>
    ''' <param name="endPeriod"></param>
    ''' <param name="compareStartPeriod"></param>
    ''' <param name="compareEndPeriod"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function isPeriodLapped(ByRef startPeriod As Integer, ByRef endPeriod As Integer, ByRef compareStartPeriod As Integer, ByRef compareEndPeriod As Integer) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If startPeriod > compareStartPeriod AndAlso startPeriod < compareEndPeriod Then
                Return True
            End If

            If endPeriod > compareStartPeriod AndAlso endPeriod < compareEndPeriod Then
                Return True
            End If

            If startPeriod < compareStartPeriod AndAlso endPeriod > compareEndPeriod Then
                Return True
            End If

            If startPeriod = compareStartPeriod AndAlso startPeriod <> endPeriod Then
                Return True
            End If

            If endPeriod = compareEndPeriod And startPeriod <> endPeriod Then
                Return True
            End If

            Return False
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 加入千分隔號,
    ''' </summary>
    ''' <param name="money"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function thousandDivide(ByVal money As Integer) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim moneyStr As String = "" & money
            Dim moneyLenCnt As Integer = moneyStr.Length



            If moneyLenCnt > 3 Then

                Dim thStr As New StringBuilder

                Dim redun As Integer = (moneyLenCnt Mod 3)
                Dim divid As Integer = (moneyLenCnt - redun) / 3
                If redun > 0 Then
                    thStr.Append(moneyStr.Substring(0, redun))
                    thStr.Append(",")

                    moneyStr = moneyStr.Substring(redun, (moneyLenCnt - redun))

                    For i As Integer = 0 To (divid - 1)
                        Dim index As Integer = i * 3
                        thStr.Append(moneyStr.Substring(index, 1))
                        thStr.Append(moneyStr.Substring(index + 1, 1))
                        thStr.Append(moneyStr.Substring(index + 2, 1))
                        thStr.Append(",")
                    Next

                Else
                    For i As Integer = 0 To (divid - 1)
                        Dim index As Integer = i * 3
                        thStr.Append(moneyStr.Substring(index, 1))
                        thStr.Append(moneyStr.Substring(index + 1, 1))
                        thStr.Append(moneyStr.Substring(index + 2, 1))
                        thStr.Append(",")
                    Next
                End If

                Dim returnMoneyStr As String = thStr.ToString
                If returnMoneyStr.Length > 0 AndAlso returnMoneyStr.Substring(thStr.Length - 1, 1).Equals(",") Then
                    returnMoneyStr = returnMoneyStr.Substring(0, (returnMoneyStr.Length - 1))
                End If

                Return returnMoneyStr

            Else
                Return moneyStr
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 小數轉分數
    ''' </summary>
    ''' <param name="inPoint">傳入小數值</param>
    ''' <returns>分數字串</returns>
    ''' <remarks></remarks>
    Public Shared Function PointToScore(ByVal inPoint As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim pvtNumber, pvtDecimal As String
            Dim pvtCutIndex As Integer
            Dim pvtDecimalValue As Decimal


            '先進行四捨五入運算
            inPoint = Math.Round(CDec(inPoint), 2)

            '取得小數點位置
            pvtCutIndex = inPoint.ToString.IndexOf(".")

            '若無小數，則直接回傳整數
            If pvtCutIndex = -1 Then
                Return inPoint.ToString
            End If

            pvtNumber = inPoint.ToString.Substring(0, pvtCutIndex)
            pvtDecimal = inPoint.ToString.Substring(pvtCutIndex + 1)
            pvtDecimalValue = CDec("0." & pvtDecimal)

            '若小數位數長度1位，且第1位為0，則直接回傳至整數
            If pvtDecimal.Length = 1 AndAlso pvtDecimal = "0" Then
                Return pvtNumber

                '若小數位數長度2位，且第2位為0，則直接回傳至小數第1位
            ElseIf pvtDecimal.Length = 2 AndAlso pvtDecimal.Substring(1, 1) = "0" Then
                Return pvtNumber & "." & pvtDecimal.Substring(0, 1)

            End If

            Return inPoint


            'Dim pvtNumber, pvtDecimal As String
            'Dim pvtCutIndex As Integer
            'Dim pvtDecimalValue As Decimal

            'pvtCutIndex = inPoint.ToString.IndexOf(".")
            'If pvtCutIndex = -1 Then
            '    Return inPoint.ToString
            'End If
            'pvtNumber = inPoint.ToString.Substring(0, pvtCutIndex)
            'pvtDecimal = inPoint.ToString.Substring(pvtCutIndex + 1)
            'pvtDecimalValue = CDec("0." & pvtDecimal)

            'If pvtNumber = "0" Then
            '    pvtNumber = ""
            'End If

            'If CDec(pvtDecimal) = 0 Then
            '    pvtDecimal = ""
            'End If
            'If pvtDecimalValue = 0.0 Then
            '    Return CInt(pvtNumber)
            'End If

            'If pvtDecimalValue = 0.1 Then
            '    Return pvtNumber & " " & "1/10"

            'ElseIf pvtDecimalValue >= 0.12 AndAlso pvtDecimalValue <= 0.13 Then
            '    Return pvtNumber & " " & "1/8"

            'ElseIf pvtDecimalValue >= 0.137 AndAlso pvtDecimalValue <= 0.147 Then
            '    Return pvtNumber & " " & "1/7"

            'ElseIf pvtDecimalValue >= 0.161 AndAlso pvtDecimalValue <= 0.171 Then
            '    Return pvtNumber & " " & "1/6"

            'ElseIf pvtDecimalValue = 0.2 Then
            '    Return pvtNumber & " " & "1/5"

            'ElseIf pvtDecimalValue = 0.25 Then
            '    Return pvtNumber & " " & "1/4"

            'ElseIf pvtDecimalValue >= 0.28 AndAlso pvtDecimalValue <= 0.29 Then
            '    Return pvtNumber & " " & "2/7"

            'ElseIf pvtDecimalValue = 0.3 Then
            '    Return pvtNumber & " " & "3/10"

            'ElseIf pvtDecimalValue >= 0.328 AndAlso pvtDecimalValue <= 0.338 Then
            '    Return pvtNumber & " " & "1/3"

            'ElseIf pvtDecimalValue >= 0.37 AndAlso pvtDecimalValue <= 0.38 Then
            '    Return pvtNumber & " " & "3/8"

            'ElseIf pvtDecimalValue = 0.4 Then
            '    Return pvtNumber & " " & "2/5"

            'ElseIf pvtDecimalValue >= 0.423 AndAlso pvtDecimalValue <= 0.433 Then
            '    Return pvtNumber & " " & "3/7"

            'ElseIf pvtDecimalValue = 0.5 Then
            '    Return pvtNumber & " " & "1/2"

            'ElseIf pvtDecimalValue >= 0.566 AndAlso pvtDecimalValue <= 0.576 Then
            '    Return pvtNumber & " " & "4/7"

            'ElseIf pvtDecimalValue = 0.6 Then
            '    Return pvtNumber & " " & "3/5"

            'ElseIf pvtDecimalValue >= 0.66 AndAlso pvtDecimalValue <= 0.671 Then
            '    Return pvtNumber & " " & "2/3"

            'ElseIf pvtDecimalValue >= 0.62 AndAlso pvtDecimalValue <= 0.63 Then
            '    Return pvtNumber & " " & "5/8"

            'ElseIf pvtDecimalValue = 0.7 Then
            '    Return pvtNumber & " " & "7/10"

            'ElseIf pvtDecimalValue >= 0.709 AndAlso pvtDecimalValue <= 0.719 Then
            '    Return pvtNumber & " " & "5/7"

            'ElseIf pvtDecimalValue = 0.75 Then
            '    Return pvtNumber & " " & "3/4"

            'ElseIf pvtDecimalValue = 0.8 Then
            '    Return pvtNumber & " " & "4/5"

            'ElseIf pvtDecimalValue >= 0.828 AndAlso pvtDecimalValue <= 0.838 Then
            '    Return pvtNumber & " " & "5/6"

            'ElseIf pvtDecimalValue >= 0.852 AndAlso pvtDecimalValue <= 0.862 Then
            '    Return pvtNumber & " " & "6/7"

            'ElseIf pvtDecimalValue >= 0.87 AndAlso pvtDecimalValue <= 0.88 Then
            '    Return pvtNumber & " " & "7/8"

            'ElseIf pvtDecimalValue = 0.9 Then
            '    Return pvtNumber & " " & "9/10"

            'End If



            'Return Math.Round(CDec(inPoint), 2)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 分數轉整數或小數2位
    ''' </summary>
    ''' <param name="inPoint">傳入小數值</param>
    ''' <returns>分數字串</returns>
    ''' <remarks></remarks>
    Public Shared Function PointToScore1(ByVal inPoint As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim pvtNumber, pvtDecimal As String
            Dim pvtCutIndex As Integer
            Dim pvtDecimalValue As Decimal

            pvtCutIndex = inPoint.ToString.IndexOf(".")
            If pvtCutIndex = -1 Then
                Return inPoint.ToString
            End If
            pvtNumber = inPoint.ToString.Substring(0, pvtCutIndex)
            pvtDecimal = inPoint.ToString.Substring(pvtCutIndex + 1)
            pvtDecimalValue = CDec("0." & pvtDecimal)

            If pvtNumber = "0" Then
                pvtNumber = ""
            End If

            If CInt(pvtDecimal) = 0 Then
                pvtDecimal = ""
            End If
            If pvtDecimalValue = 0.0 Then
                Return CInt(pvtNumber)
            End If

            Return Math.Round(CDec(inPoint), 2)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 整數與小數部分轉換 由高至低位
    ''' </summary>
    ''' <param name="number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function toArray(ByVal number As String) As Integer()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim cnt As Integer = number.Length - 1
            Dim array(cnt) As Integer

            Dim numArray() As Char = number.ToArray

            For i As Integer = 0 To cnt
                array(i) = Integer.Parse(numArray(i))
            Next
            Return array
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 中文金額整數
    ''' </summary>
    ''' <param name="integers"></param>
    ''' <param name="isMust5"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getChineseInteger(ByVal integers() As Integer, ByVal isMust5 As Boolean) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim chineseInteger As StringBuilder = New StringBuilder
            Dim length As Integer
            length = integers.Length
            For i As Integer = 0 To (length - 1)
                '// 0出現在關鍵位置: 1234萬5678億9012萬3456元
                '// 特殊情況 : 10(拾元, 壹拾元, 壹拾萬元, 拾萬元)
                Dim key As String = ""
                If integers(i) = 0 Then
                    If (length - i) = 13 Then '// 萬(億) 必填
                        key = IUNIT(4)
                    ElseIf (length - i) = 9 Then '// 億
                        key = IUNIT(8)
                    ElseIf (length - i) = 5 AndAlso isMust5 Then '萬(不必填)
                        key = IUNIT(4)
                    ElseIf (length - i) = 1 Then '元
                        key = IUNIT(0)
                        '// 0遇到非0時補0,不包含最後一位
                    End If
                    If (length - i) > 1 AndAlso (integers(i + 1) <> 0) Then
                        key = key + NUMBERS(0)
                    End If
                End If
                chineseInteger.Append(IIf(integers(i) = 0, key, (NUMBERS(integers(i)) + IUNIT(length - i - 1))))
            Next

            Dim returnChinese As String = chineseInteger.ToString().Trim

            If returnChinese.Length = 0 Then
                returnChinese = "零元整"
            Else
                returnChinese = returnChinese & "整"
            End If

            Return returnChinese
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 小數部分中文
    ''' </summary>
    ''' <param name="decimals"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getChineseDecimal(ByVal decimals() As Integer) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim chineseDecimal As StringBuilder = New StringBuilder
            For i As Integer = 0 To (decimals.Length - 1)
                '// 捨棄三位後小數
                If (i = 3) Then
                    Exit For
                End If
                chineseDecimal.Append(IIf(decimals(i) = 0, "", (NUMBERS(decimals(i)) + DUNIT(i))))
            Next
            Return chineseDecimal.ToString()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 判斷萬單位是否要加入
    ''' </summary>
    ''' <param name="integerStr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function isMust5w(ByVal integerStr As String) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim length As Integer
            length = integerStr.Length
            If (length > 4) Then
                Dim subInteger As String = ""
                If (length > 8) Then
                    '// 第五位到第八位字串
                    subInteger = integerStr.Substring(length - 8, length - 4)
                Else
                    subInteger = integerStr.Substring(0, length - 4)
                End If
                Return (Integer.Parse(subInteger) > 0)
            Else
                Return False
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 數字範圍展開
    ''' </summary>
    ''' <param name="RangeStr"></param>
    ''' <returns></returns>
    ''' <remarks>1,2,4-7 => 1,2,4,5,6,7</remarks>
    ''' <author>Ken</author>
    Public Shared Function RangeExpanding(RangeStr As String) As List(Of Integer)
        Dim _list As New List(Of String)
        Dim _regex As New System.Text.RegularExpressions.Regex("^\s*(-?\d+)\s*[-]\s*(-?\d+)\s*$")
        Dim _tmp As Int32 = 0

        _list.AddRange(RangeStr.Replace(" ", String.Empty).Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries))
        Dim _itemRange = _list.Where(Function(r) _regex.IsMatch(r))
        Dim _items = (_list.Except(_itemRange)).Where(Function(r) Int32.TryParse(r, _tmp)).Select(Function(r) CInt(r))
        Dim x = _itemRange.Select(Function(r) Enumerable.Range(Math.Min(CInt(_regex.Match(r).Groups(1).Value), CInt(_regex.Match(r).Groups(2).Value)), Math.Max(CInt(_regex.Match(r).Groups(1).Value), CInt(_regex.Match(r).Groups(2).Value)) - Math.Min(CInt(_regex.Match(r).Groups(1).Value), CInt(_regex.Match(r).Groups(2).Value)) + 1))
        Dim _totalList As List(Of Int32) = _items.Union(x.SelectMany(Function(r) r)).OrderBy(Function(r) r).ToList()

        Return _totalList
    End Function

End Class
