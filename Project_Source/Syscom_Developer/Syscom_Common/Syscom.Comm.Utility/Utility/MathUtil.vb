'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：數學運算相關功能
'=======
'======= 程式說明：1.將數值四捨五入到小數第n位。
'=======
'=======           2.將數值四捨五入到整數。
'=======
'=======           3.將數值無條件進位。
'=======
'=======
'======= 建立日期：2011-11-8
'=======
'======= 開發人員：Sean.Lin
'=============================================================================
'=============================================================================
'=============================================================================

Imports Syscom.Comm.EXP

Public Class MathUtil

    ' ''' <summary>
    ' ''' 計算身體質量指數 (FormulaUnit已有相同的Method, 請盡量使用FormulaUnit中的Function)
    ' ''' 
    ' ''' 傳入 1.身高 2.體重 3.進位規則{1:四捨五入 2: 無條件捨去 3: 無條件進位}  4.小數點幾位(只有四捨五入有效) )
    ' ''' </summary>
    ' ''' <param name="Height">身高</param>
    ' ''' <param name="Weight">體重</param>
    ' ''' <param name="rule" >進位規則</param>
    ' ''' <param name="digit" >小數點幾位</param>
    ' ''' <returns>BMI</returns>
    ' ''' <author>Ken</author>
    ' ''' <remarks></remarks>
    'Public Shared Function GetBMI(ByVal Height As Decimal, ByVal Weight As Decimal, ByVal rule As String, Optional ByVal digit As Integer = 1) As Decimal

    '    Try

    '        If Height = 0 Then
    '            Return 0
    '        Else

    '            Dim BMI As Decimal = (Weight / (Height * Height / 10000))

    '            Select Case rule

    '                '1:四捨五入(round)
    '                Case 1

    '                    Return Math.Round(BMI, digit, MidpointRounding.AwayFromZero)

    '                    '2: 無條件捨去(floor) 
    '                Case 2

    '                    Return Math.Floor(BMI)

    '                    '3: 無條件進位(Celling))
    '                Case 3

    '                    Return Math.Ceiling(BMI)

    '                Case Else

    '                    Return 0

    '            End Select

    '        End If

    '    Catch ex As Exception
    '        Throw New CommonException("CMMCMMB302", ex, New String() {"計算身體質量指數"})
    '    End Try

    'End Function

    ''' <summary>
    ''' 十進制轉換為 n 進制, n 介於 2~36
    ''' </summary>
    ''' <param name="number">數值</param>
    ''' <param name="base"> n 進制</param>
    ''' <param name="len">回傳字串長度</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FromBase10(ByVal number As Integer, ByVal base As Integer, Optional ByVal len As Integer = 0) As String
        Try

            If base < 2 OrElse base > 36 Then
                Return ""
            End If

            If base.Equals(10) Then
                Return number.ToString
            End If

            Dim q As Integer = number
            Dim r As Integer
            Dim rtn As String = ""

            While q >= base

                r = q Mod base
                q = Fix(q / base)

                If r < 10 Then
                    rtn = r.ToString + rtn
                Else
                    rtn = Convert.ToChar(r + 55).ToString + rtn
                End If

            End While

            If q < 10 Then
                rtn = q.ToString + rtn
            Else
                rtn = Convert.ToChar(q + 55).ToString + rtn
            End If

            If len > 0 AndAlso len > rtn.Length Then
                Dim diff As Integer = len - rtn.Length
                For i As Integer = 0 To diff - 1
                    rtn = "0" & rtn
                Next
            End If

            Return rtn

        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"十進制轉換為 n 進制"})
            
        End Try
    End Function

    ''' <summary>
    ''' 從 n 進制轉換為十進制, n 介於 2~36
    ''' </summary>
    ''' <param name="number">數值</param>
    ''' <param name="base">n 進制</param>
    ''' <param name="len">回傳字串長度</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ToBase10(ByVal number As String, ByVal base As Integer, Optional ByVal len As Integer = 0) As String
        Try

            If base < 2 OrElse base > 36 Then
                Return ""
            End If

            If base.Equals(10) Then
                Return number.ToString
            End If

            Dim chrs As Char() = number.ToCharArray
            Dim m As Integer = chrs.Length - 1
            Dim x As Integer
            Dim rtn As Integer

            For Each elem As Char In chrs

                If Char.IsNumber(elem) Then
                    x = Integer.Parse(elem.ToString)
                Else
                    x = Convert.ToInt32(elem) - 55
                End If

                rtn += x * (Convert.ToInt32(Math.Pow(base, m)))

                m -= 1

            Next

            Dim strRtn As String = rtn.ToString

            If len > 0 AndAlso len > strRtn.Length Then
                Dim diff As Integer = len - strRtn.Length
                For i As Integer = 0 To diff - 1
                    strRtn = "0" & strRtn
                Next
            End If

            Return strRtn

        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"從 n 進制轉換為十進制"})

        End Try
    End Function

    ''' <summary>
    ''' 四捨五入到小數第n位
    ''' </summary>
    ''' <param name="num"></param>
    ''' <param name="decimals">小數第n位</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Round(ByVal num As Object, ByVal decimals As Integer) As Decimal

        If decimals < 0 Then
            Return num
        End If

        Dim value As Decimal = CDec(0)

        Try
            value = CDec(num)
        Catch ex As Exception
            Return num
        End Try

        Return Decimal.Round(value, decimals, MidpointRounding.AwayFromZero)
    End Function

    ''' <summary>
    ''' 四捨五入到整數
    ''' </summary>
    ''' <param name="num"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Round(ByVal num As Object) As Decimal
        Return Round(num, 0)
    End Function

End Class
