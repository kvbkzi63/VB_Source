Imports System.Text
Imports System.Reflection
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports System.Text.RegularExpressions

Public Class StringUtil

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 列舉附加字元方向
    ''' 
    ''' appendToLeft：附加至左邊，appendToRight：附加至右邊
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum appendDirection
        appendToLeft
        appendToRight
    End Enum

    '****** 半形英數字附加方法 ******

    ''' <summary>
    ''' 將字串從左補滿字元(字元只限英數字元)，例如 appendCharToLeft("123","A",5)  ==> AA123
    ''' </summary>
    ''' <param name="srcString">來源字串</param>
    ''' <param name="apdChar">補滿字元</param>
    ''' <param name="totalLength">補滿長度</param>
    ''' <returns>從左補滿字元的字串</returns>
    ''' <remarks></remarks>
    Public Shared Function appendCharToLeft(ByVal srcString As String, ByVal apdChar As Char, ByVal totalLength As Integer) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return appendChar(srcString, apdChar, totalLength, appendDirection.appendToLeft)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將整數轉字串後，從左補滿字元(字元只限英數字元)，例如 appendCharToLeft(123,"A",5)  ==> AA123
    ''' </summary>
    ''' <param name="srcInteger">來源數值</param>
    ''' <param name="apdChar">補滿字元</param>
    ''' <param name="totalLength">補滿長度</param>
    ''' <returns>從左補滿字元的字串</returns>
    ''' <remarks></remarks>
    Public Shared Function appendCharToLeft(ByVal srcInteger As Integer, ByVal apdChar As Char, ByVal totalLength As Integer) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return appendChar(CStr(srcInteger), apdChar, totalLength, appendDirection.appendToLeft)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將字串從右補滿字元(字元只限英數字元)，例如 appendCharToRight("123","A",5)  ==> 123AA
    ''' </summary>
    ''' <param name="srcString">來源字串</param>
    ''' <param name="apdChar">補滿字元</param>
    ''' <param name="totalLength">補滿長度</param>
    ''' <returns>從右補滿字元的字串</returns>
    ''' <remarks></remarks>
    Public Shared Function appendCharToRight(ByVal srcString As String, ByVal apdChar As Char, ByVal totalLength As Integer) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return appendChar(srcString, apdChar, totalLength, appendDirection.appendToRight)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將整數轉字串後，從右補滿字元(字元只限英數字元)，例如 appendCharToLeft(123,"A",5)  ==> 123AA
    ''' </summary>
    ''' <param name="srcInteger"></param>
    ''' <param name="apdChar"></param>
    ''' <param name="totalLength"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function appendCharToRight(ByVal srcInteger As Integer, ByVal apdChar As Char, ByVal totalLength As Integer) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return appendChar(CStr(srcInteger), apdChar, totalLength, appendDirection.appendToRight)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將來源字串補滿需求長度的字元後回傳(字元只限英數字元)
    ''' </summary>
    ''' <param name="srcString">來源字串</param>
    ''' <param name="apdChar">補滿字元</param>
    ''' <param name="totalLength">補滿長度</param>
    ''' <param name="appendDirection">補滿方向</param>
    ''' <returns>補滿需求長度字元的字串</returns>
    ''' <remarks></remarks>
    Public Shared Function appendChar(ByVal srcString As String, ByVal apdChar As Char, ByVal totalLength As Integer, ByVal appendDirection As appendDirection) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If (srcString Is Nothing) Then
                srcString = ""
            End If
            If srcString.Length > totalLength Then
                srcString = srcString.Substring(0, totalLength)
            ElseIf srcString.Length < totalLength Then
                For i = 1 To totalLength - srcString.Length
                    If appendDirection = appendDirection.appendToLeft Then
                        srcString = apdChar & srcString
                    Else
                        srcString = srcString & apdChar
                    End If
                Next
            End If
            Return srcString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    '****** 所有字串附加方法 ******

    ''' <summary>
    ''' 計算字串長度(英半：1，中：2)
    ''' </summary>
    ''' <param name="DestStr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function StringLengthCount(ByRef DestStr As String) As Integer
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If DestStr IsNot Nothing Then
                Try
                    Return System.Text.Encoding.Default.GetBytes(DestStr).Length
                Catch ex As Exception
                    Return 0
                End Try
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
    ''' 將字串加入原字串的左邊或是右邊，直到所指定的大小
    ''' 注意：本方法中 srcString 與 appendStr 的中文字會被當作2個字元來計算
    ''' </summary>
    ''' <param name="srcString"></param>
    ''' <param name="appendStr"></param>
    ''' <param name="totalLength"></param>
    ''' <param name="appendDirection"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function appendCString(ByVal srcString As String, ByVal appendStr As String, ByVal totalLength As Integer, ByVal appendDirection As appendDirection) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If (srcString Is Nothing) Then
                srcString = ""
            End If

            Dim srcLength As Integer = StringLengthCount(srcString) '來源字串的位元數
            Dim appLength As Integer = StringLengthCount(appendStr) '附加字串的位元數

            If srcLength > totalLength Then
                Dim tmpString As String = ""
                '有可能會發生中文碼被切一半的問題
                Dim sumLength As Integer = 0
                Dim length As Integer = 0
                '一個一個文字去算所佔的位元
                For Each c As Char In srcString.ToCharArray
                    length = StringLengthCount(c & "")
                    sumLength += length
                    If sumLength > totalLength Then
                        If sumLength - length = totalLength - 1 Then
                            tmpString += " "
                        End If

                        Exit For
                    End If
                    tmpString += c
                Next
                srcString = tmpString
            ElseIf srcLength < totalLength Then
                Dim diff As Integer = totalLength - srcLength
                '若 appendStr 為中文字,則可能因為 srcString+appendStr 的位元數大於 totalLength 而不被加入
                For i = appLength To diff Step appLength
                    If appendDirection = appendDirection.appendToLeft Then
                        srcString = appendStr & srcString
                    Else 'appendToRight
                        srcString = srcString & appendStr
                    End If
                Next
            End If
            Return srcString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 預設將字串附加到字串的右邊
    ''' </summary>
    ''' <param name="srcString"></param>
    ''' <param name="appendStr"></param>
    ''' <param name="totalLength"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function appendCString(ByVal srcString As String, ByVal appendStr As String, ByVal totalLength As Integer) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return appendCString(srcString, appendStr, totalLength, appendDirection.appendToRight)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    '******************************

    ''' <summary>
    ''' 檢查字串內是否有資料
    ''' </summary>
    ''' <param name="exeString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Function isStringContainsInfo(ByRef exeString As String) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If exeString IsNot Nothing AndAlso exeString.Length > 0 Then
                Return True
            Else
                Return False
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    Public Shared Function num(ByVal srcString As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim rsString As String
            If srcString Is Nothing OrElse srcString Is DBNull.Value OrElse srcString.ToString = "" Then
                rsString = "0"
            Else
                rsString = srcString.Trim
            End If
            Return rsString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    Public Shared Function num(ByVal srcObj As Object, Optional ByVal IsReplaceSpace As Boolean = False) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If (srcObj Is Nothing OrElse IsDBNull(srcObj)) Then
                Return "0"
            Else
                If IsReplaceSpace AndAlso srcObj.ToString.Trim.Length = 0 Then
                    Return "0"
                Else
                    Return srcObj.ToString.Trim
                End If
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    Public Shared Function nvl(ByVal srcString As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim rsString As String = srcString
            If rsString Is Nothing OrElse rsString Is DBNull.Value Then 'p.s 基本上rsString不可能等於DBNull.Value, 因為就算是DBNull.Value丟進來,但 ToString 後會變成空字串
                rsString = String.Empty
            Else
                rsString = srcString.Trim
            End If
            Return rsString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    Public Shared Function nvl(ByVal srcString As String, ByVal defaultValue As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim rsString As String = srcString
            If rsString Is Nothing OrElse rsString Is DBNull.Value Then 'p.s 基本上rsString不可能等於DBNull.Value, 因為就算是DBNull.Value丟進來,但 ToString 後會變成空字串
                rsString = defaultValue
            Else
                rsString = srcString.Trim
            End If
            Return rsString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    Public Shared Function nvl(ByVal srcObj As Object) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If (srcObj Is Nothing Or IsDBNull(srcObj)) Then
                Return ""
            Else
                Return srcObj.ToString.Trim
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 將數字轉大寫字
    ''' </summary>
    ''' <param name="Money"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertMoney(ByVal Money As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim tw_str As String() = New String(9) {"零", "壹", "貳", "叁", "肆", "伍", "陸", "柒", "捌", "玖"}
            Dim tw_unit As String() = New String(16) {"", "", "拾", "佰", "仟", "萬", "拾", "佰", "仟", "億", "拾", "佰", "仟", "兆", "拾", "佰", "仟"}
            Dim len As Integer = 0
            Dim ls_retstr As String = String.Empty
            Dim ls_tmp As String = String.Empty

            Money = nvl(Money)
            If (Money.Length = 0 Or (Money.Length > 0 AndAlso CLng(Money) = 0)) Then
                Return "零"
            Else
                Money = CLng(Money).ToString
            End If

            '判斷是否帶有小數點
            If Money.IndexOf(".") <> -1 Then
                len = Money.Substring(0, Money.IndexOf(".")).Length
            Else
                '無小數點
                len = Money.Length

            End If

            Dim cnt, cnt_mod As Integer
            cnt = len \ 4
            cnt_mod = len Mod 4
            If (cnt_mod > 0) Then
                cnt = cnt + 1
                Money = appendCharToLeft(Money, CChar("0"), cnt * 4)
            End If
            len = Money.Length
            For j As Integer = 1 To cnt
                If (CInt(Money.Substring(len - (4 * j), 4)) > 0) Then
                    For i As Integer = len - (4 * j) + 4 To len - (4 * j) + 1 Step -1
                        ls_tmp = Money.Substring(i - 1, 1)
                        ls_retstr = String.Concat(tw_str(Int32.Parse(ls_tmp)) + tw_unit(len - i + 1), ls_retstr)
                    Next
                End If
            Next

            Return doReplaceWord(ls_retstr)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    Private Shared Function doReplaceWord(ByVal data As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If (data.Length > 0) Then
                data = data.Replace("零拾", "零")
                data = data.Replace("零佰", "零")
                data = data.Replace("零仟", "零")
                data = replaceZeroWord(data)
                data = data.Replace("零萬", "萬")
                data = data.Replace("零億", "億")
                data = data.Replace("零兆", "兆")
                data = replaceZeroWord(data)
                If data.Substring(0, 1) = "零" Then data = data.Substring(1)
                If data.Substring(data.Length - 1, 1) = "零" Then data = data.Substring(0, data.Length - 1)
            End If
            Return data
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    Private Shared Function replaceZeroWord(ByVal data As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Do While data.Contains("零零")
                data = data.Replace("零零", "零")
            Loop
            Return data
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    '''  設假設輸入一字串 '8211001!CHOL8=200)!(8211001!CHOL8=240)，我們要取得8xx8裡邊字串
    ''' </summary>
    ''' <param name="srcString">(8211001!CHOL8=200)!(8211001!CHOL8=240)</param>
    ''' <param name="filterString">8</param>
    ''' <returns>string(0) = 211001!CHOL ，string(1) = 211001!CHOL</returns>
    ''' <remarks></remarks>
    Private Function GetFilterString(ByVal srcString As String, ByVal filterString As String) As String()
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim strLength As Integer = 0
            Dim strPoint As Integer = 0
            Dim getpoint As String = ""
            Dim getpoint_1 As String = ""
            Dim rtnStr() As String = Nothing

            If Not "".Equals(srcString) Then
                If srcString.Contains(filterString) Then
                    strLength = srcString.Length
                    While (strPoint < srcString.Length)
                        If strPoint = -1 Then
                            Exit While
                        End If

                        If getpoint.Equals("") Then
                            strPoint = srcString.IndexOf(filterString, strPoint)
                            If strPoint = -1 Then
                                Exit While
                            End If
                            getpoint += CStr(strPoint)
                        Else
                            strPoint = srcString.IndexOf(filterString, strPoint)
                            If strPoint = -1 Then
                                Exit While
                            End If
                            getpoint += "," + CStr(strPoint)

                        End If

                        If Not getpoint.Equals(getpoint_1) Then
                            getpoint_1 = getpoint
                            strPoint += 1
                        End If
                    End While

                    If Not "".Equals(getpoint) Then
                        Dim mysplit As String() = Split(getpoint, ",", , CompareMethod.Binary)
                        ReDim rtnStr(CType(mysplit.Count / 2 - 1, Integer))
                        Dim rtnstrcount As Integer = 0
                        For i As Integer = 0 To rtnStr.Count - 1
                            rtnStr(i) = srcString.Substring(Integer.Parse(mysplit(rtnstrcount)), Integer.Parse(mysplit(rtnstrcount + 1)) - Integer.Parse(mysplit(rtnstrcount)) + 1)
                            'i += 1
                            rtnstrcount += 2
                        Next
                    Else
                        rtnStr = Nothing
                    End If
                End If
            Else
                rtnStr = Nothing
            End If

            Return rtnStr
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ' ''' <summary>
    ' '''  取代字串方法 (2014/10/23移除)
    ' ''' </summary>
    ' ''' <param name="srcString">8211001!200</param>
    ' ''' <param name="oldstring">8211001</param>
    ' ''' <param name="newstring">ABC</param>
    ' ''' <returns>ABC!200</returns>
    ' ''' <remarks></remarks>
    'Private Function GetString(ByVal srcString As String, ByVal oldstring As String, ByVal newstring As String) As String
    '    Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
    '    Try
    '        Dim strLength As Integer = 0
    '        Dim rtnStr As String = ""
    '        If Not "".Equals(srcString) Then
    '            rtnStr = srcString.Replace(oldstring, newstring)
    '        Else
    '            rtnStr = Nothing
    '        End If
    '        Return rtnStr
    '    Catch cmex As CommonException
    '        Throw cmex
    '    Catch ex As Exception
    '        Throw New CommonException("CMMCMMD001", ex, caller:=caller)
    '    End Try
    'End Function

    ''' <summary>
    ''' 去除字串中最後一個逗號，若最後一個字不是逗號，回傳原值
    ''' </summary>
    ''' <param name="inputStr" >輸入的字串</param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2012-3-30</remarks>
    Public Shared Function DeleteLastComa(ByVal inputStr As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim returnString As String = inputStr
        Try
            '檢查 Nothing
            If CheckIsNothing(inputStr) Then
                If Not inputStr = "" Then
                    '最後一個字是逗號
                    If inputStr.IndexOf(",") = inputStr.Length - 1 Then
                        returnString = inputStr.Substring(0, inputStr.Length - 1)
                    End If
                End If
            End If
            Return returnString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 判斷傳入字元是否為英文字母 (只判斷第一個字元)
    ''' </summary>
    ''' <param name="letterChar">傳入字元</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsLetter(ByVal letterChar As String) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If letterChar Is Nothing OrElse letterChar.Length = 0 Then
                Return False
            Else
                Return Char.IsLetter(letterChar, 0)
            End If
            'If Asc(letterChar.ToUpper) >= 65 AndAlso Asc(letterChar.ToUpper) <= 90 Then
            '    Return True
            'Else
            '    Return False
            'End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    '***********************************************************************************************
    '通常在.NET裡面，轉半形全形，最簡單的方法會透過
    'Microsoft.VisualBasic.Strings 裡面的 StrConv() 來幫忙轉換。
    '例如：
    '1	Me.textbox1.Text=Strings.StrConv(Me.textbox1.Text, VbStrConv.Wide)
    '2	Me.textbox1.Text=Strings.StrConv(Me.textbox1.Text, VbStrConv.Narrow)
    '但是，這個方式遇到難字，例如「堃」，會轉成「？」。
    '因為 StrConv 跟 VbStrConv 的列舉型別與文化特性有關。
    '其實最簡單的方式，還是「判斷字串是否為需要轉換的字」，因為半形轉全形，通常只針對「特殊符號」跟「英數字」。
    '這邊有兩個 function 可以用來轉換半形跟全形(已經處理掉難字跟空白)，有興趣的可以直接拿去用。
    '***********************************************************************************************
    ''' <summary>
    ''' 半形轉全形
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ToWide(ByRef data As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return Microsoft.VisualBasic.Strings.StrConv(data, VbStrConv.Wide)

            'Dim sb As New StringBuilder
            'Dim ascii As Integer = 0
            'For Each c As Char In data.ToCharArray()
            '    ascii = Convert.ToInt32(c)
            '    If ascii = 32 Then
            '        sb.Append(Convert.ToChar(12288))
            '    Else
            '        sb.Append(Convert.ToChar(ascii + IIf(ascii < 127, 65248, 0)))
            '    End If
            'Next
            'Return sb.ToString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 全形轉半形
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ToNarrow(ByRef data As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return Microsoft.VisualBasic.Strings.StrConv(data, VbStrConv.Narrow)

            'Dim sb As New StringBuilder
            'Dim ascii As Integer = 0
            'For Each c As Char In data.Replace("〔", "[").Replace("〕", "]").Replace("'", "'").ToCharArray()
            '    ascii = Convert.ToInt32(c)
            '    If ascii = 12288 Then
            '        sb.Append(Convert.ToChar(32))
            '    Else
            '        If ascii > 65280 And ascii < 65375 Then
            '            sb.Append(Convert.ToChar(ascii - 65248))
            '        Else
            '            sb.Append(Convert.ToChar(ascii))
            '        End If
            '    End If
            'Next
            'Return sb.ToString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 繁體中文轉換成簡體中文
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ToTraditionalChinese(ByRef data As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return Microsoft.VisualBasic.Strings.StrConv(data, VbStrConv.TraditionalChinese)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 簡體中文轉換成繁體中文
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ToSimplifiedChinese(ByRef data As String) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return Microsoft.VisualBasic.Strings.StrConv(data, VbStrConv.SimplifiedChinese)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#Region "ADD on 2015-11-06 by Lits"
    ''' <summary>
    ''' 判斷字串是否為Boolean值
    ''' </summary>
    ''' <param name="_str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsBoolean(ByVal _str As String) As Boolean
        If _str Is Nothing OrElse _str.Length = 0 Then
            Return False
        ElseIf _str.Trim.ToLower.Equals(False.ToString.ToLower) OrElse _
        _str.Trim.ToLower.Equals(True.ToString.ToLower) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' 判斷字串是否為 Y/N 值
    ''' </summary>
    ''' <param name="_str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsYN(ByVal _str As String) As Boolean
        If _str Is Nothing OrElse _str.Length = 0 Then
            Return False
        ElseIf _str.Trim.ToLower.Equals("y") OrElse _str.Trim.ToLower.Equals("n") Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' 將 Boolean 轉換為 Y / N
    ''' </summary>
    ''' <param name="_bol"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TransBoolean2YN(ByVal _bol As Boolean) As String

        Dim _rtnValue As String = "N"

        If IsBoolean(_bol) Then

            If _bol Then
                _rtnValue = "Y"
            Else
                _rtnValue = "N"
            End If

        End If

        Return _rtnValue

    End Function

    ''' <summary>
    ''' 將 Y/N 轉換為 Boolean 值
    ''' </summary>
    ''' <param name="_bol"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TransYN2Boolean(ByVal _bol As String) As Boolean

        Dim _rtnValue As Boolean = False

        If _bol.ToString.Trim.ToUpper.Equals("Y") Then

            _rtnValue = True

        ElseIf _bol.ToString.Trim.ToUpper.Equals("N") Then

            _rtnValue = False

        End If

        Return _rtnValue

    End Function

    ''' <summary>
    ''' 字串陣列轉換為字串, 以分隔符號連結
    ''' </summary>
    ''' <param name="_ary"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TransArrayToString(ByRef _ary() As String) As String

        Dim _rtnValue As String = ""

        For i As Integer = 0 To _ary.Length - 1

            If _rtnValue.Length > 0 Then
                _rtnValue &= ";"
            End If

            _rtnValue &= _ary(i)

        Next

        Return _rtnValue

    End Function

    ''' <summary>
    ''' Tab 轉換為固定 Space長度
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="tabSize"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Tab2Space(ByVal source As String, Optional ByVal tabSize As Integer = 8) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            Dim result As New System.Text.StringBuilder

            For index As Integer = 0 To source.Length - 1
                If source.Chars(index) = vbTab Then
                    Do
                        result.Append(Space(1))
                    Loop Until ((result.Length Mod tabSize) = 0)

                Else
                    result.Append(source.Chars(index))
                End If

            Next

            Return result.ToString
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' Tab 轉換為固定 Space長度
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="tabSize"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Tab2SpaceAlign(ByVal source As String, Optional ByVal tabSize As Integer = 8) As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try

            If source.IndexOf(vbTab) < 0 Then
                Return source
            End If

            If tabSize <= 0 Then
                tabSize = 8
            End If

            Dim arySrc() As String = source.Split(vbTab)

            Dim result As New System.Text.StringBuilder
            Dim divide As Integer
            Dim left As Integer
            Dim totalSpace As Integer
            Dim appendSpace As Integer = 0


            For i As Integer = 0 To arySrc.Length - 1

                divide = arySrc(i).Trim.Length / tabSize
                left = arySrc(i).Trim.Length Mod tabSize
                divide = IIf(left = 0, divide + 1, divide)
                totalSpace = IIf(divide * tabSize >= arySrc(i).Trim.Length, divide * tabSize, (divide + 1) * tabSize)
                appendSpace = totalSpace - arySrc(i).Trim.Length

                result.Append(arySrc(i)).Append(Space(appendSpace))

            Next

            Return result.ToString

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 切割多行字串
    ''' </summary>
    ''' <param name="vstrData">要切割的字串</param>
    ''' <param name="vintCountPerLine">每行字數</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CutPrintMultiLines(ByVal vstrData As String, ByVal vintCountPerLine As Integer) As ArrayList
        Dim aryLines() As String = Split(vstrData, vbCrLf)
        Dim strT As String
        Dim colLine As New Collection
        Dim returnStr As New ArrayList
        For Each strT In aryLines
            Dim intLen As Integer, i As Integer
            intLen = 0
            'strT = strT.ToString.TrimStart
            strT = strT.ToString
            Do While True
                For i = 1 To strT.Length
                    If Math.Abs(AscW(Mid(strT, i, 1))) > 255 Then '非英文字寬度是2
                        intLen = intLen + 2
                    Else
                        intLen = intLen + 1
                    End If

                    If intLen > vintCountPerLine Then
                        Dim strTemp As String
                        strTemp = Mid(strT, 1, i - 1)
                        If Math.Abs(AscW(Right(strTemp, 1))) > 255 Then '最後一字是中文可斷行
                            strT = Mid(strT, i)
                        ElseIf AscW(Mid(strT, i, 1)) = 32 Or Math.Abs(AscW(Mid(strT, i, 1))) > 255 Then '下一字是空白或中文，可斷行 
                            strT = Mid(strT, i)
                        Else '最後一字是英文，且下一個字不是空白與中文，代表不能斷行
                            Dim k As Integer
                            For k = strTemp.Length To 1 Step -1
                                If AscW(Mid(strTemp, k, 1)) = 32 Or Math.Abs(AscW(Mid(strTemp, k, 1))) > 255 Then '遇上空白或中文字
                                    Exit For
                                End If
                            Next
                            If k = 0 Then '向前找沒有找到中文或Space，只好斷行
                                k = vintCountPerLine
                            End If
                            strTemp = Mid(strTemp, 1, k)
                            strT = Mid(strT, k + 1)
                        End If
                        colLine.Add(strTemp)
                        intLen = 0
                        Exit For
                    End If
                Next
                If intLen <> 0 Or strT.Length = 0 Then
                    colLine.Add(strT)
                    Exit Do
                End If
            Loop
        Next

        For j = 0 To colLine.Count - 1
            returnStr.Add(colLine.Item(j + 1))
        Next

        Return returnStr
    End Function

    ''' <summary>
    ''' 計算字串中共含有多少個符號
    ''' </summary>
    ''' <param name="_str"></param>
    ''' <param name="_sign"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CountSign(ByVal _str As String, ByVal _sign As String) As Integer

        Dim _str2 As String = _str
        Dim _rtnValue As Integer = 0

        While _str2.Length > 0

            If _str2.IndexOf(_sign) >= 0 Then
                _rtnValue += 1

                _str2 = _str2.Substring(_str2.IndexOf(_sign) + _sign.Length)
            Else
                _str2 = ""
            End If

        End While

        Return _rtnValue

    End Function

    ''' <summary>
    ''' 找尋符號所在位置
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="sign"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FindSignIndex(ByVal str As String, ByVal sign As String) As Integer()

        Dim spiltStr() As String = str.Split(sign)

        Dim index(spiltStr.Length - 2) As Integer

        For i As Integer = 0 To spiltStr.Length - 2

            If i = 0 Then
                index(i) = spiltStr(i).Length
            Else
                index(i) = spiltStr(i).Length + index(i - 1) + 2
            End If

        Next

        Return index

    End Function

    Public Shared Function InsertString(ByRef str As String, ByVal idx As Integer, ByVal insertChar As String) As String

        Dim spaceCnt As Integer = 0
        If str.Length < idx Then
            spaceCnt = idx - str.Length
        End If

        For i As Integer = 0 To spaceCnt - 1
            str &= insertChar
        Next

        Return str

    End Function

#End Region

#Region "取得字串中的資料"
    Enum PatternOptions As Integer
        ''' <summary>
        ''' 大括號{}
        ''' </summary>
        ''' <remarks></remarks>
        pattern1 = 1
        ''' <summary>
        ''' 大括號和小括號{()}
        ''' </summary>
        ''' <remarks></remarks>
        pattern2 = 2

    End Enum
    ''' <summary>
    ''' 字串依據模組分割資料
    ''' </summary>
    ''' <param name="inputData">輸入的字串資料</param>
    ''' <param name="options">模組(分割符號)</param>
    ''' <param name="IsOnlyData">是否只有資料;不包含分割符號</param>
    ''' <returns>
    ''' matches：符合分割字串陣列
    ''' </returns>
    ''' <remarks>比對英文不分大小寫</remarks>
    Public Shared Function GetSpecificData(ByVal inputData As String, ByVal options As PatternOptions _
                                           , Optional ByVal IsOnlyData As Boolean = True) As String()
        Try
            Dim strMatches() As String

            Select Case options
                Case PatternOptions.pattern1
                    Dim matches As Match() = Regex.Matches(nvl(inputData), "{.+?}", RegexOptions.IgnoreCase).Cast(Of Match).ToArray()
                    If IsOnlyData Then
                        strMatches = matches.Select(Function(r) r.ToString.Replace("{", "").Replace("}", "")).ToArray
                    Else
                        strMatches = matches.Select(Function(r) r.ToString).ToArray
                    End If
                Case PatternOptions.pattern2
                    Dim matches As Match() = Regex.Matches(nvl(inputData), "{\(.+?\)}", RegexOptions.IgnoreCase).Cast(Of Match).ToArray()
                    If IsOnlyData Then
                        strMatches = matches.Select(Function(r) r.ToString.Replace("{(", "").Replace(")}", "")).ToArray
                    Else
                        strMatches = matches.Select(Function(r) r.ToString).ToArray
                    End If
                Case Else
                    Throw New Exception("無此分割模組")
            End Select

            Return strMatches

        Catch ex As Exception
            Throw
        End Try
    End Function
#End Region


    '<STAThread()> _
    'Shared Sub Main()
    '    'Application.Run(New StringUtil())
    '    '測試中文字串
    '    'Dim a As String = "1" '1
    '    'Dim b As String = "a" '1
    '    'Dim c As String = "中" '2
    '    'Dim d As String = "1文" '3
    '    'Dim f As String = "2金a" '4
    '    ''Console.WriteLine("a=" & count(a) & ", b=" & count(b) & ", c=" & count(c) & ", d=" & count(d) & ", f=" & count(f))
    '    'Console.WriteLine("c=" & c.Length)
    '    'Console.WriteLine("d=" & appendCString(d, " ", 5))
    '    'Console.WriteLine("d=" & appendCString(d, "王", 5, True))
    '    Console.WriteLine("" & appendCString("我是中文字", " ", 7, True))
    '    Console.WriteLine("" & appendCString("我是中a文字", " ", 7, True))
    '    '全半形轉換
    '    'd = toWide(d)
    '    'Console.WriteLine("d=" & d)
    '    'Console.WriteLine("d=" & d.Length)
    '    'Console.WriteLine("d=" & appendCString(d, " ", 5))

    'End Sub

End Class
