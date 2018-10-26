'/*
'*****************************************************************************
'*
'*    Page/Class Name:	pubRuleParserBS.vb
'*              Title:	pubRuleParserBS
'*        Description:	pubRuleParserBS
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	liuye
'*        Create Date:	2012/05/23
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.Text
Imports System.IO
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Public Class pubRuleParserBS
    Public Shared token() As String
    Public Shared var() As String
    Public Shared vale() As String
    Public Shared errMsg As String
    Public Shared msg As New ArrayList
    Public Shared tmsg As New ArrayList
    Private Shared tempMsg As String

    Private Shared myInstance As pubRuleParserBS
    Public Shared Function GetInstance() As pubRuleParserBS
        If myInstance Is Nothing Then
            myInstance = New pubRuleParserBS()
        End If
        Return myInstance
    End Function

    Public Shared Function postFix(ByVal input As String) As Boolean
        Try
            Dim opdStack As Stack = New Stack
            Dim oprStack As Stack = New Stack
            Dim i As Integer = 0
            Dim chkStr As Integer = 0
            Dim chkNum As Integer = 0
            Dim chkOp As Integer = 0
            Dim chkVar As Integer = 0
            Dim comVar As String = ""
            Dim str As String = "'"
            Dim num As String = ""
            Dim opdFst As String = ""
            Dim opdSnd As String = ""
            Dim opr As String = ""
            Dim comOp As String = ""
            Dim res As String = ""
            While i < input.Length
                Select Case input(i)
                    Case " "
                        If (chkStr = 1) Then
                            str += input(i)
                            Exit Select
                        End If
                    Case "'"
                        If (chkStr = 0) Then
                            chkStr = 1
                        Else
                            str &= "'"
                            opdStack.Push(str)
                            str = "'"
                            chkStr = 0
                        End If
                    Case "("
                        If (chkNum = 1) Then
                            opdStack.Push(num)
                            num = ""
                            chkNum = 0
                        End If
                        oprStack.Push(input(i))
                    Case "=", ">", "<", "!"
                        If chkVar = 1 Then
                            opdStack.Push(comVar)
                            comVar = ""
                            chkVar = 0
                        End If
                        If (input(i + 1) = "=") Then
                            comOp = "" & input(i) & input(i + 1)
                            chkOp = 1
                            Exit Select
                        End If
                        If (chkNum = 1) Then
                            opdStack.Push(num)
                            num = ""
                            chkNum = 0
                        End If

                        '問題區塊=======================================================
                        If oprStack.Count > 0 Then
                            If chkOp = 0 Then
                                If priority(oprStack.Peek()) >= priority(input(i)) Then
                                    opdSnd = opdStack.Pop()
                                    opdFst = opdStack.Pop()
                                    opr = oprStack.Pop()
                                    res = calculate(opdFst, opdSnd, opr)
                                    If Not Boolean.Parse(res) AndAlso Not (opdFst.ToUpper.Equals("TRUE") Or opdFst.ToUpper.Equals("FALSE")) Then
                                        msg.Add(tempMsg)
                                    Else
                                        tmsg.Add(tempMsg)
                                    End If
                                    opdStack.Push(res)
                                End If
                            End If
                        End If
                        '===============================================================

                        If (chkOp = 1 And input(i) = "=") Then
                            oprStack.Push(comOp)
                            comOp = ""
                            chkOp = 0
                        Else
                            oprStack.Push(input(i))
                        End If
                    Case "|", "&"
                        If chkVar = 1 Then
                            opdStack.Push(comVar)
                            comVar = ""
                            chkVar = 0
                        End If
                        If (chkNum = 1) Then
                            opdStack.Push(num)
                            num = ""
                            chkNum = 0
                        End If

                        '問題區塊=======================================================
                        If oprStack.Count > 0 Then
                            If chkOp = 0 Then
                                If priority(oprStack.Peek()) >= priority(input(i)) Then
                                    opdSnd = opdStack.Pop()
                                    opdFst = opdStack.Pop()
                                    opr = oprStack.Pop()
                                    res = calculate(opdFst, opdSnd, opr)
                                    If Not Boolean.Parse(res) AndAlso Not (opdFst.ToUpper.Equals("TRUE") Or opdFst.ToUpper.Equals("FALSE")) Then
                                        msg.Add(tempMsg)
                                    Else
                                        tmsg.Add(tempMsg)
                                    End If
                                    opdStack.Push(res)
                                End If
                            End If
                        End If
                        '===============================================================

                        If (chkOp = 1 And input(i) = "=") Then
                            oprStack.Push(comOp)
                            comOp = ""
                            chkOp = 0
                        Else
                            oprStack.Push(input(i))
                        End If
                    Case ")"
                        If chkVar = 1 Then
                            opdStack.Push(comVar)
                            comVar = ""
                            chkVar = 0
                        End If
                        If (chkNum = 1) Then
                            opdStack.Push(num)
                            num = ""
                            chkNum = 0
                        End If
                        While Not oprStack.Peek.ToString.Equals("(")
                            opdSnd = opdStack.Pop()
                            opdFst = opdStack.Pop()
                            opr = oprStack.Pop()
                            res = calculate(opdFst, opdSnd, opr)
                            If Not Boolean.Parse(res) AndAlso Not (opdFst.ToUpper.Equals("TRUE") Or opdFst.ToUpper.Equals("FALSE")) Then
                                msg.Add(tempMsg)
                            Else
                                tmsg.Add(tempMsg)
                            End If
                            opdStack.Push(res)
                        End While
                        If (oprStack.Peek = "(") Then
                            oprStack.Pop()
                        End If
                    Case "-", ".", ",", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                        If (chkStr = 1) Then
                            str += input(i)
                        ElseIf Not comVar.Equals("") AndAlso Not IsNumeric(comVar) Then
                            comVar &= input(i)
                            chkVar = 1
                        Else
                            num += input(i)
                            chkNum = 1
                        End If
                    Case Else
                        If (chkStr = 1) Then
                            str += input(i)
                            Exit Select
                        End If
                        If (chkNum = 1) Then
                            opdStack.Push(num)
                            num = ""
                            chkNum = 0
                        Else
                            comVar &= input(i)
                            chkVar = 1
                        End If
                End Select
                i += 1
            End While
            While (opdStack.Count > 1)
                While (oprStack.Count > 0)
                    If Not oprStack.Peek.ToString.Equals("(") Then
                        opdSnd = opdStack.Pop()
                        opdFst = opdStack.Pop()
                        opr = oprStack.Pop()
                        res = calculate(opdFst, opdSnd, opr)
                        If Not Boolean.Parse(res) AndAlso Not (opdFst.ToUpper.Equals("TRUE") Or opdFst.ToUpper.Equals("FALSE")) Then
                            msg.Add(tempMsg)
                        Else
                            tmsg.Add(tempMsg)
                        End If
                        opdStack.Push(res)
                    Else
                        oprStack.Pop()
                    End If
                End While
            End While
            If (res.ToLower = "true") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function priority(ByVal opr As String) As Integer
        Try
            Dim level As Integer
            Select Case opr(0)
                Case "("
                    level = 1
                Case "|"
                    level = 2
                Case "&"
                    level = 3
                Case "=", ">", "<", "!"
                    level = 4
                Case Else
                    level = 0
            End Select
            Return level
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Shared Function calculate(ByVal opdFst As String, ByVal opdSnd As String, ByVal opr As String) As Boolean
        Try
            Dim x As Boolean = True
            Dim y As Boolean = True
            Dim a As Double = 0
            Dim b As Double = 0
            Dim msg As String = "(" & opdFst & " " & opr & " " & opdSnd & ") : "
            tempMsg = opdFst & ";" & opdFst & opr & opdSnd
            If opdFst.ToLower = "true" Then
                x = True
            ElseIf opdFst.ToLower = "false" Then
                x = False
            Else
                For i = 0 To token.Length - 1
                    If opdFst = var(i) Then
                        var(i) = ""
                        opdFst = vale(i)
                        If opdFst.ToLower = "true" Then
                            opdFst = "True"
                            x = True
                        ElseIf opdFst.ToLower = "false" Then
                            opdFst = "False"
                            x = False
                        End If
                    End If
                Next
            End If
            If opdSnd.ToLower = "true" Then
                y = True
            ElseIf opdSnd.ToLower = "false" Then
                y = False
            Else
                For i = 0 To token.Length - 1
                    If opdSnd = var(i) Then
                        var(i) = ""
                        opdSnd = vale(i)
                        If opdSnd.ToLower = "true" Then
                            opdSnd = "True"
                            y = True
                        ElseIf opdSnd.ToLower = "false" Then
                            opdSnd = "False"
                            y = False
                        End If
                    End If
                Next
            End If
            'TextBox3.Text &= "x: " & x & " , y: " & y & " , opr: " & opr & vbNewLine & vbNewLineyuuuu
            msg &= " " & opdFst & " " & opr & " " & opdSnd
            tempMsg &= ";" & opdFst
            'MsgBox(msg)
            If (opr.Equals("&")) Then
                Return (x And y)
            ElseIf (opr.Equals("|")) Then
                Return (x Or y)
            ElseIf (opr.Equals("=")) Then
                If (opdFst(0) = "'") Then

                    '20101028 add by Rich, TC ask to add this For "bypass OPH check when "As Order" or "prn" happened
                    Dim passStr As String = opdFst.Remove(opdFst.Length - 1, 1)
                    If passStr.ToUpper = "AS ORDER" Or passStr.ToUpper.Contains("PRN") Then
                        Return True
                    End If

                    '加入並存與不並存的判斷
                    If opdSnd.Contains(",") Or opdSnd.Contains("[") Or opdSnd.Contains("]") Then
                        Dim first As String = opdFst.Remove(opdFst.Length - 1, 1)
                        first = first.Remove(0, 1)
                        Dim second As String = opdSnd.Remove(opdSnd.Length - 1, 1)
                        second = second.Remove(0, 1)
                        Dim secondArray() As String = second.Split(",")
                        Dim rtnValue As Boolean = False
                        For Each obj As String In secondArray
                            If obj.Contains("[") Or obj.Contains("]") Then
                                Dim rangeStr As String = obj.Remove(obj.Length - 1, 1)
                                rangeStr = rangeStr.Remove(0, 1)
                                Dim range() As String = rangeStr.Split("-")
                                If range(0) < range(1) Then
                                    If range(0) <= first And first <= range(1) Then
                                        rtnValue = True
                                        Exit For
                                    End If
                                Else
                                    If range(1) <= first And first <= range(0) Then
                                        rtnValue = True
                                        Exit For
                                    End If
                                End If
                            Else
                                If first.Trim.ToUpper.Equals(obj.Trim.ToUpper) Then
                                    rtnValue = True
                                    Exit For
                                End If
                            End If
                        Next
                        Return rtnValue
                    Else
                        Return (opdFst.Trim.ToUpper.Equals(opdSnd.Trim.ToUpper))
                    End If
                ElseIf opdSnd.ToUpper = "TRUE" Or opdSnd.ToUpper = "FALSE" Then
                    Return (x = y)
                Else
                    '20110212 add by Rich, TC 要求加入數值的並存與不並存的判斷
                    If opdSnd.Contains(",") Or opdSnd.Contains("[") Or opdSnd.Contains("]") Then
                        Dim secondArray() As String = opdSnd.Split(",")
                        Dim rtnValue As Boolean = False
                        For Each obj As String In secondArray
                            If obj.Contains("[") Or obj.Contains("]") Then
                                Dim rangeStr As String = obj.Remove(obj.Length - 1, 1)
                                rangeStr = rangeStr.Remove(0, 1)
                                Dim range() As String = rangeStr.Split("-")
                                If CDec(range(0)) < CDec(range(1)) Then
                                    If CDec(range(0)) <= CDec(opdFst) And CDec(opdFst) <= CDec(range(1)) Then
                                        rtnValue = True
                                        Exit For
                                    End If
                                Else
                                    If CDec(range(1)) <= CDec(opdFst) And CDec(opdFst) <= CDec(range(0)) Then
                                        rtnValue = True
                                        Exit For
                                    End If
                                End If
                            Else
                                If (CDec(opdFst) = CDec(obj)) Then
                                    rtnValue = True
                                    Exit For
                                End If
                            End If
                        Next
                        Return rtnValue
                    Else
                        If IsNumeric(opdFst) AndAlso IsNumeric(opdSnd) Then
                            a = Double.Parse(opdFst)
                            b = Double.Parse(opdSnd)
                            Return (a = b)
                        Else
                            'MessageBox.Show("不是正確的數值", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            errMsg = "不是正確的數值"
                            Return False
                        End If
                    End If
                End If
            ElseIf (opr.Equals("!=")) Then
                If (opdFst(0) = "'") Then

                    '加入並存與不並存的判斷
                    If opdSnd.Contains(",") Or opdSnd.Contains("[") Or opdSnd.Contains("]") Then
                        Dim first As String = opdFst.Remove(opdFst.Length - 1, 1)
                        first = first.Remove(0, 1)
                        Dim second As String = opdSnd.Remove(opdSnd.Length - 1, 1)
                        second = second.Remove(0, 1)
                        Dim secondArray() As String = second.Split(",")
                        Dim rtnValue As Boolean = True
                        For Each obj As String In secondArray
                            If obj.Contains("[") Or obj.Contains("]") Then
                                Dim rangeStr As String = obj.Remove(obj.Length - 1, 1)
                                rangeStr = rangeStr.Remove(0, 1)
                                Dim range() As String = rangeStr.Split("-")
                                If range(0) < range(1) Then
                                    If range(0) <= obj And obj <= range(1) Then
                                        rtnValue = False
                                        Exit For
                                    End If
                                Else
                                    If range(1) <= obj And obj <= range(0) Then
                                        rtnValue = False
                                        Exit For
                                    End If
                                End If
                            Else
                                If first.Equals(obj) Then
                                    rtnValue = False
                                    Exit For
                                End If
                            End If
                        Next
                        Return rtnValue
                    Else
                        Return (Not opdFst.Equals(opdSnd))
                    End If
                ElseIf opdSnd.ToUpper = "TRUE" Or opdSnd.ToUpper = "FALSE" Then
                    Return (x <> y)
                Else
                    '20110509 add by Rich, TC 要求加入數值的並存與不並存的判斷
                    If opdSnd.Contains(",") Or opdSnd.Contains("[") Or opdSnd.Contains("]") Then
                        Dim secondArray() As String = opdSnd.Split(",")
                        Dim rtnValue As Boolean = True
                        For Each obj As String In secondArray
                            If obj.Contains("[") Or obj.Contains("]") Then
                                Dim rangeStr As String = obj.Remove(obj.Length - 1, 1)
                                rangeStr = rangeStr.Remove(0, 1)
                                Dim range() As String = rangeStr.Split("-")
                                If CDec(range(0)) < CDec(range(1)) Then
                                    If CDec(range(0)) <= CDec(opdFst) And CDec(opdFst) <= CDec(range(1)) Then
                                        rtnValue = False
                                        Exit For
                                    End If
                                Else
                                    If CDec(range(1)) <= CDec(opdFst) And CDec(opdFst) <= CDec(range(0)) Then
                                        rtnValue = False
                                        Exit For
                                    End If
                                End If
                            Else
                                If (CDec(opdFst) = CDec(obj)) Then
                                    rtnValue = False
                                    Exit For
                                End If
                            End If
                        Next
                        Return rtnValue
                    Else
                        If IsNumeric(opdFst) AndAlso IsNumeric(opdSnd) Then
                            a = Double.Parse(opdFst)
                            b = Double.Parse(opdSnd)
                            Return (a <> b)
                        Else
                            'MessageBox.Show("不是正確的數值", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            errMsg = "不是正確的數值"
                            Return False
                        End If
                    End If
                End If
            ElseIf (opr.Equals(">")) Then
                If IsNumeric(opdFst) AndAlso IsNumeric(opdSnd) Then
                    a = Double.Parse(opdFst)
                    b = Double.Parse(opdSnd)
                    Return (a > b)
                ElseIf (opdFst(0) = "'") AndAlso opdSnd(0) = "'" Then
                    Return (opdFst.ToUpper > opdSnd.ToUpper)
                Else
                    'MessageBox.Show("不是正確的數值", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    errMsg = "非相同變數型態進行比較"
                    Return False
                End If
            ElseIf (opr.Equals("<")) Then
                If IsNumeric(opdFst) AndAlso IsNumeric(opdSnd) Then
                    a = Double.Parse(opdFst)
                    b = Double.Parse(opdSnd)
                    Return (a < b)
                ElseIf (opdFst(0) = "'") AndAlso opdSnd(0) = "'" Then
                    Return (opdFst.ToUpper < opdSnd.ToUpper)
                Else
                    'MessageBox.Show("不是正確的數值", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    errMsg = "非相同變數型態進行比較"
                    Return False
                End If
            ElseIf (opr.Equals(">=")) Then
                If IsNumeric(opdFst) AndAlso IsNumeric(opdSnd) Then
                    a = Double.Parse(opdFst)
                    b = Double.Parse(opdSnd)
                    Return (a >= b)
                ElseIf (opdFst(0) = "'") AndAlso opdSnd(0) = "'" Then
                    Return (opdFst.ToUpper >= opdSnd.ToUpper)
                Else
                    'MessageBox.Show("不是正確的數值", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    errMsg = "非相同變數型態進行比較"
                    Return False
                End If
            ElseIf (opr.Equals("<=")) Then
                If IsNumeric(opdFst) AndAlso IsNumeric(opdSnd) Then
                    a = Double.Parse(opdFst)
                    b = Double.Parse(opdSnd)
                    Return (a <= b)
                ElseIf (opdFst(0) = "'") AndAlso opdSnd(0) = "'" Then
                    Return (opdFst.ToUpper <= opdSnd.ToUpper)
                Else
                    'MessageBox.Show("不是正確的數值", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    errMsg = "非相同變數型態進行比較"
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function checkValue(ByVal input As String, ByVal value As String) As Boolean
        Try
            token = value.Split(";")
            Dim tmp(token.Length) As String         '暫時用來接input切割的token
            Dim singleQuotationMark As Integer = 0  '單引號
            Dim leftBracket As Integer = 0          '左括號
            Dim rightBracket As Integer = 0         '右括號
            Dim equalMark As Integer = 0            '等號
            Dim greaterThan As Integer = 0          '大於
            Dim lessThan As Integer = 0             '小於
            Dim exclamationMark As Integer = 0      '驚歎號
            Dim andMark As Integer = 0              '關係等號
            Dim orMark As Integer = 0               '關係或者
            Dim valEqual As Integer = 0             '設定值字串的等於符號
            Dim valSingleQMark As Integer = 0       '設定值字串的單引號
            Dim comOp As Integer = 0                '判斷是否為複合運算子
            Dim chkStr As Integer = 0               '判斷是否為字串
            Dim chkNum As Integer = 0               '判斷是否為範圍數字
            ReDim var(token.Length - 1)
            ReDim vale(token.Length - 1)

            Dim i As Integer = 0
            Dim count As Integer = 0
            Dim j As String = ""                    '用來取代陣列值，才能擷取第一個字元

            'Expression 的判斷式
            While i < input.Length
                Select Case input(i)
                    Case " "
                    Case "'"
                        singleQuotationMark += 1
                        If (chkStr = 0) Then
                            chkStr = 1
                        Else
                            chkStr = 0
                        End If
                    Case "("
                        leftBracket += 1
                    Case "="
                        equalMark += 1
                    Case ">"
                        greaterThan += 1
                    Case "<"
                        lessThan += 1
                    Case "!"
                        If (input(i + 1) <> "=") Then
                            errMsg = "輸入錯誤的運算子！"
                            Return False
                        End If
                        exclamationMark += 1
                    Case "|"
                        orMark += 1
                    Case "&"
                        andMark += 1
                    Case ")"
                        rightBracket += 1
                    Case "-", ".", ",", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                        If chkStr = 1 Then
                            Exit Select
                        End If
                        Select Case input(i + 1)
                            Case "-", ".", ",", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                            Case ")", "|", "_", "="
                            Case Else
                                'TextBox3.Text &= "? " & input(i + 1)
                                errMsg = "Expression: 輸入錯誤的數值！"
                                Return False
                        End Select
                    Case "~", "`", "#", "$", "%", "^", "*", "-", "+", "/", "\", "{", "}"
                        errMsg = "Expression: 輸入錯誤的字元！"
                        Return False
                    Case Else

                End Select
                i += 1
            End While
            If (singleQuotationMark Mod 2) <> 0 Then
                errMsg = "Expression: 單引號數目錯誤！"
                Return False
            End If
            If leftBracket <> rightBracket Then
                errMsg = "Expression: 左右括號數目不相等！"
                Return False
            End If

            'Value 的判斷式
            For i = 0 To value.Length - 1
                Select Case value(i)
                    Case "="
                        valEqual += 1
                    Case "'"
                        valSingleQMark += 1
                End Select
            Next
            If (valSingleQMark Mod 2) <> 0 Then
                errMsg = "Value: 單引號數目錯誤！"
                Return False
            End If
            For i = 0 To token.Length - 1
                tmp = token(i).Split("=")
                If valEqual <> token.Length Then
                    errMsg = "Value: 分隔符號或等號錯誤！"
                    Return False
                Else
                    var(i) = tmp(0)
                    vale(i) = tmp(1)
                    j = vale(i)
                    If j.ToLower <> "true" Then
                        If j.ToLower <> "false" Then
                            Select Case j(0)
                                Case "'"
                                Case "-", ".", ",", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                                    While count < j.Length
                                        Select Case j(count)
                                            Case "-", ".", ",", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                                            Case Else
                                                errMsg = "Value: 變數值設定為不正確的數字！"
                                                Return False
                                        End Select
                                        count += 1
                                    End While
                                Case Else
                                    errMsg = "Value: 變數值設定錯誤！"
                                    Return False
                            End Select
                        End If
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
