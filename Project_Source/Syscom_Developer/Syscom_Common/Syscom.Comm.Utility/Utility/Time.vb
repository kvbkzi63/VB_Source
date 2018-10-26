'/*
'*****************************************************************************
'*
'*    Page/Class Name:  Time
'*              Title:	Time
'*        Description:	Time
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Ken
'*        Create Date:	2009-07-09
'*      Last Modifier:	Ken
'*   Last Modify Date:	2009-07-09
'*
'*****************************************************************************
'*/

Public Class Time
    Implements IDisposable

    Private _hour As Int32 = 0
    Private _minute As Int32 = 0
    Private _second As Int32 = 0

    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' 釋放其他狀態 (Managed 物件)。
            End If

        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "

    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

#Region "Constructor"

    Public Sub New()
        Dim _now As Date = Now
        Me.p_Hour = _now.Hour
        Me.p_Minute = _now.Minute
        Me.p_Second = _now.Second
    End Sub

    Public Sub New(ByVal Hour As Int32, ByVal Minute As Int32)
        Me.p_Hour = Hour
        Me.p_Minute = Minute
        Me.p_Second = 0
    End Sub

    Public Sub New(ByVal Hour As Int32, ByVal Minute As Int32, ByVal Second As Int32)
        Me.p_Hour = Hour
        Me.p_Minute = Minute
        Me.p_Second = Second
    End Sub

    Public Sub New(ByVal TimeStr As String)
        Me.SetTime(TimeStr)
    End Sub

    Public Sub New(ByVal value As Time)
        Me.p_Hour = value.Hour
        Me.p_Minute = value.Minute
        Me.p_Second = value.Second
    End Sub

    Public Sub New(ByVal value As TimeSpan)

        Me.p_Hour = value.Hours Mod 24
        Me.p_Minute = value.Minutes Mod 60
        Me.p_Second = value.Seconds Mod 60
    End Sub

    Private Sub SetTime(ByVal TimeStr As String)

        Dim _regexHMS As New System.Text.RegularExpressions.Regex("^(20|21|22|23|[01]\d|\d)[:](([0-5]?\d))[:](([0-5]?\d))$")
        Dim _regexHM As New System.Text.RegularExpressions.Regex("^(20|21|22|23|[01]\d|\d)[:](([0-5]?\d))$")
        Dim _regexHM2 As New System.Text.RegularExpressions.Regex("^(20|21|22|23|[01]\d|\d)([0-5]\d)([0-5]\d)$")
        Dim _regexHM3 As New System.Text.RegularExpressions.Regex("^(20|21|22|23|[01]\d)(([0-5]\d))$")

        'Dim _retTime As Time = Nothing
        If _regexHMS.IsMatch(TimeStr) Then
            Dim _items As String() = System.Text.RegularExpressions.Regex.Split(TimeStr, ":")
            Me.p_Hour = Int32.Parse(_items(0))
            Me.p_Minute = Int32.Parse(_items(1))
            Me.p_Second = Int32.Parse(_items(2))
        ElseIf _regexHM.IsMatch(TimeStr) Then
            Dim _items As String() = System.Text.RegularExpressions.Regex.Split(TimeStr, ":")
            Me.p_Hour = Int32.Parse(_items(0))
            Me.p_Minute = Int32.Parse(_items(1))
        ElseIf _regexHM2.IsMatch(TimeStr) Then
            Me.p_Hour = Int32.Parse(TimeStr.Substring(0, 2))
            Me.p_Minute = Int32.Parse(TimeStr.Substring(2, 2))
            Me.p_Second = Int32.Parse(TimeStr.Substring(4, 2))
        ElseIf _regexHM3.IsMatch(TimeStr) Then
            Me.p_Hour = Int32.Parse(TimeStr.Substring(0, 2))
            Me.p_Minute = Int32.Parse(TimeStr.Substring(2, 2))
        Else
            Throw New Exception("The input format must be hh:mm:ss or hhmmss.")
        End If
    End Sub

#End Region

#Region "Properties"

    Public ReadOnly Property Hour() As Int32
        Get
            Return _hour
        End Get
    End Property

    Public ReadOnly Property Minute() As Int32
        Get
            Return _minute
        End Get
    End Property

    Public ReadOnly Property Second() As Int32
        Get
            Return _second
        End Get
    End Property

    Private Property p_Hour() As Int32
        Get
            Return _hour
        End Get
        Set(ByVal value As Int32)
            If value < 0 OrElse value > 23 Then
                Throw New Exception("The value of Hour must between 0 and 23")
            End If

            Me._hour = value
        End Set
    End Property

    Private Property p_Minute() As Int32
        Get
            Return _minute
        End Get
        Set(ByVal value As Int32)
            If value < 0 OrElse value > 59 Then
                Throw New Exception("The value of Minute must between 0 and 59")
            End If

            Me._minute = value
        End Set
    End Property

    Private Property p_Second() As Int32
        Get
            Return _second
        End Get
        Set(ByVal value As Int32)
            If value < 0 OrElse value > 59 Then
                Throw New Exception("The value of Second must between 0 and 59")
            End If

            Me._second = value
        End Set
    End Property

#End Region

#Region "Operator"

    Public Shared Operator -(ByVal Time1 As Time, ByVal Time2 As Time) As TimeSpan
        Return Time.TimeDiff(Time2, Time1)
    End Operator

    Public Shared Operator -(ByVal Time1 As String, ByVal Time2 As Time) As TimeSpan
        Return Time.TimeDiff(Time2, Time.Parse(Time1))
    End Operator

    Public Shared Operator -(ByVal Time1 As Time, ByVal Time2 As String) As TimeSpan
        Return Time.TimeDiff(Time.Parse(Time2), Time1)
    End Operator

    Public Shared Operator -(ByVal Time1 As Time, ByVal Time2 As TimeSpan) As Time
        Return Time1.Substract(Time2)
    End Operator

    Public Shared Operator =(ByVal Time1 As Time, ByVal Time2 As Time) As Boolean
        Return Time1.To6DigitString = Time2.To6DigitString
    End Operator

    Public Shared Operator <>(ByVal Time1 As Time, ByVal Time2 As Time) As Boolean
        Return Time1.To6DigitString <> Time2.To6DigitString
    End Operator

    Public Shared Operator <(ByVal Time1 As Time, ByVal Time2 As Time) As Boolean
        Return Time1.To6DigitString < Time2.To6DigitString
    End Operator

    Public Shared Operator >(ByVal Time1 As Time, ByVal Time2 As Time) As Boolean
        Return Time1.To6DigitString > Time2.To6DigitString
    End Operator

    Public Shared Operator <=(ByVal Time1 As Time, ByVal Time2 As Time) As Boolean
        Return Time1.To6DigitString <= Time2.To6DigitString
    End Operator

    Public Shared Operator >=(ByVal Time1 As Time, ByVal Time2 As Time) As Boolean
        Return Time1.To6DigitString >= Time2.To6DigitString
    End Operator

    Public Shared Operator =(ByVal Time1 As String, ByVal Time2 As Time) As Boolean
        Return Time.Parse(Time1).To6DigitString = Time2.To6DigitString
    End Operator

    Public Shared Operator <>(ByVal Time1 As String, ByVal Time2 As Time) As Boolean
        Return Time.Parse(Time1).To6DigitString <> Time2.To6DigitString
    End Operator

    Public Shared Operator <(ByVal Time1 As String, ByVal Time2 As Time) As Boolean
        Return Time.Parse(Time1).To6DigitString < Time2.To6DigitString
    End Operator

    Public Shared Operator >(ByVal Time1 As String, ByVal Time2 As Time) As Boolean
        Return Time.Parse(Time1).To6DigitString > Time2.To6DigitString
    End Operator

    Public Shared Operator <=(ByVal Time1 As String, ByVal Time2 As Time) As Boolean
        Return Time.Parse(Time1).To6DigitString <= Time2.To6DigitString
    End Operator

    Public Shared Operator >=(ByVal Time1 As String, ByVal Time2 As Time) As Boolean
        Return Time.Parse(Time1).To6DigitString >= Time2.To6DigitString
    End Operator

    Public Shared Operator =(ByVal Time1 As Time, ByVal Time2 As String) As Boolean
        Return Time1.To6DigitString = Time.Parse(Time2).To6DigitString
    End Operator

    Public Shared Operator <>(ByVal Time1 As Time, ByVal Time2 As String) As Boolean
        Return Time1.To6DigitString <> Time.Parse(Time2).To6DigitString
    End Operator

    Public Shared Operator <(ByVal Time1 As Time, ByVal Time2 As String) As Boolean
        Return Time1.To6DigitString < Time.Parse(Time2).To6DigitString
    End Operator

    Public Shared Operator >(ByVal Time1 As Time, ByVal Time2 As String) As Boolean
        Return Time1.To6DigitString > Time.Parse(Time2).To6DigitString
    End Operator

    Public Shared Operator <=(ByVal Time1 As Time, ByVal Time2 As String) As Boolean
        Return Time1.To6DigitString <= Time.Parse(Time2).To6DigitString
    End Operator

    Public Shared Operator >=(ByVal Time1 As Time, ByVal Time2 As String) As Boolean
        Return Time1.To6DigitString >= Time.Parse(Time2).To6DigitString
    End Operator

#End Region

#Region "Operation"

    Public Function Substract(ByVal value As Time) As TimeSpan
        Return Time.TimeDiff(value, Me)
    End Function

    Public Function Substract(ByVal value As TimeSpan) As Time
        Dim _date As New Date(Now.Year, Now.Month, Now.Day, _hour, _minute, _second)
        _date = _date.Subtract(value)

        Dim _time As New Time(_date.Hour, _date.Minute, _date.Second)
        Return _time
    End Function

    Public Function Add(ByVal value As TimeSpan) As Time
        Dim _date As New Date(Now.Year, Now.Month, Now.Day, _hour, _minute, _second)
        _date = _date.Add(value)

        Dim _time As New Time(_date.Hour, _date.Minute, _date.Second)
        Return _time
    End Function

    Public Function AddHour(ByVal Hours As Int32) As Time
        Dim _date As New Date(Now.Year, Now.Month, Now.Day, _hour, _minute, _second)
        _date = _date.AddHours(Hours)

        Dim _time As New Time(_date.Hour, _date.Minute, _date.Second)
        Return _time
    End Function

    Public Function AddMinute(ByVal Minutes As Int32) As Time
        Dim _date As New Date(Now.Year, Now.Month, Now.Day, _hour, _minute, _second)
        _date = _date.AddMinutes(Minutes)

        Dim _time As New Time(_date.Hour, _date.Minute, _date.Second)
        Return _time
    End Function

    Public Function AddSecond(ByVal Seconds As Int32) As Time
        Dim _date As New Date(Now.Year, Now.Month, Now.Day, _hour, _minute, _second)
        _date = _date.AddSeconds(Seconds)

        Dim _time As New Time(_date.Hour, _date.Minute, _date.Second)
        Return _time
    End Function

    Public Shared Function TimeDiff(ByVal Time1 As Time, ByVal Time2 As Time) As TimeSpan
        Dim _now As Date = Date.Now
        Dim _date1 As New Date(_now.Year, _now.Month, _now.Day, Time1.Hour, Time1.Minute, Time1.Second)
        Dim _date2 As New Date(_now.Year, _now.Month, _now.Day, Time2.Hour, Time2.Minute, Time2.Second)

        Return _date2.Subtract(_date1)
    End Function

#End Region

    Public Shared Function Parse(ByVal TimeStr As String) As Time
        Return New Time(TimeStr)
    End Function

    Public Shared Function Parse(ByVal value As TimeSpan) As Time
        Return New Time(value.Hours Mod 24, value.Minutes Mod 60, value.Seconds Mod 60)
    End Function

    Public Shared Function Validate(ByVal value As String) As Boolean
        Dim _regex As New System.Text.RegularExpressions.Regex("^(20|21|22|23|[01]\d|\d)[:]([0-5]?\d)([:]([0-5]?\d))?$")
        Dim _regex2 As New System.Text.RegularExpressions.Regex("^(20|21|22|23|[01]\d|\d)([0-5]\d)([0-5]\d)?$")

        Return _regex.IsMatch(value) Or _regex2.IsMatch(value)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("{0:00}:{1:00}:{2:00}", _hour, _minute, _second)
    End Function

    Public Function ToStringHHmm()
        Return String.Format("{0:00}:{1:00}", _hour, _minute)
    End Function

    Public Function To4DigitString() As String
        Return String.Format("{0:00}{1:00}", _hour, _minute)
    End Function

    Public Function To6DigitString() As String
        Return String.Format("{0:00}{1:00}{2:00}", _hour, _minute, _second)
    End Function

    Public Function ToTimeSpan() As TimeSpan
        Return New TimeSpan(Me._hour, Me._minute, Me._second)
    End Function

End Class