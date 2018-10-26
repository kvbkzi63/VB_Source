'/*
'*****************************************************************************
'*
'*    Page/Class Name:  一般例外狀況
'*              Title:	CommonException
'*        Description:	一般例外狀況
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-02-18
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-02-18
'*
'*****************************************************************************
'*/

Imports Syscom.Comm.BASE
Imports System.Reflection

''' <summary>
''' 一般例外狀況
''' </summary>
''' <seealso cref="System.Exception" />
Public Class CommonException
    Inherits System.Exception

    ''' <summary>
    ''' The caller information
    ''' </summary>
    Private CallerInfo As MethodBase = Nothing
    ''' <summary>
    ''' The error code
    ''' </summary>
    Private ErrorCode As String = ""
    ''' <summary>
    ''' The error code argument
    ''' </summary>
    Private ErrorCodeArg As String() = Nothing
    ''' <summary>
    ''' The error message ex
    ''' </summary>
    Private ErrorMessageEx As String
    ''' <summary>
    ''' The original ex
    ''' </summary>
    Private OriginalEx As Exception

    ''' <summary>
    ''' 覆寫底層訊息
    ''' </summary>
    ''' <returns></returns>
    Public Overrides ReadOnly Property Message As String
        Get
            If OriginalEx IsNot Nothing Then
                Return OriginalEx.Message
            Else
                Return MyBase.Message
            End If
        End Get
    End Property

    ''' <summary>
    ''' 此建構式為標準用法，ErrorMessage　會自動取得系統定義檔裡的資訊，亦可直接拿來顯示給使用者看
    ''' </summary>
    ''' <param name="code">The code.</param>
    ''' <param name="formatArg">The format argument.</param>
    ''' <param name="caller">The caller.</param>
    Public Sub New(ByRef code As String, Optional ByRef formatArg As String() = Nothing, Optional ByVal caller As MethodBase = Nothing)
        ErrorCode = code
        ErrorCodeArg = formatArg
        OriginalEx = Me

        If caller Is Nothing Then
            CallerInfo = New StackTrace().GetFrames(1).GetMethod()
        Else
            CallerInfo = caller
        End If
    End Sub
    ''' <summary>
    ''' 此建構式為標準用法，ErrorMessage　會自動取得系統定義檔裡的資訊，ex為原始例外
    ''' </summary>
    ''' <param name="code">The code.</param>
    ''' <param name="ex">The ex.</param>
    ''' <param name="formatArg">The format argument.</param>
    ''' <param name="caller">The caller.</param>
    Public Sub New(ByRef code As String, ByRef ex As Exception, Optional ByRef formatArg As String() = Nothing, Optional ByVal caller As MethodBase = Nothing)
        ErrorCode = code
        ErrorCodeArg = formatArg
        OriginalEx = ex

        If caller Is Nothing Then
            '取得前一個呼叫者的 Method Name ； GetFrames(0) 為本身，1 為上一層，以此類推
            CallerInfo = New StackTrace().GetFrames(1).GetMethod()
        Else
            CallerInfo = caller
        End If
    End Sub

    ''' <summary>
    ''' 取得 CallerInfo
    ''' </summary>
    ''' <returns></returns>
    Public Function getCallerInfo() As MethodBase
        Return CallerInfo
    End Function
    ''' <summary>
    ''' 取得 ErrorCode
    ''' </summary>
    ''' <returns></returns>
    Public Function getErrorCode() As String
        Return ErrorCode
    End Function
    ''' <summary>
    ''' 取得 ErrorCodeArg
    ''' </summary>
    ''' <returns></returns>
    Public Function getErrorCodeArg() As String()
        Return ErrorCodeArg
    End Function
    ''' <summary>
    ''' 取得原始例外 OriginalEx
    ''' </summary>
    ''' <returns></returns>
    Public Function getOriginalException() As Exception
        Return OriginalEx
    End Function

    ''' <summary>
    ''' 取得由ErrorCode mapping 系統定義檔裡的資訊
    ''' </summary>
    ''' <exception cref="Exception">拋出</exception>
    ''' <returns></returns>
    Public Function getErrorMessage() As String
        Try
            If ErrorCodeArg IsNot Nothing AndAlso ErrorCodeArg.Length > 0 Then
                Return MessageValueObject.getMessageValue(getErrorCode, ErrorCodeArg)
            Else
                Return MessageValueObject.getMessageValue(getErrorCode)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '此建構式為特殊用法，請勿濫用。ErrorCode 取得系統定義檔裡的資訊，但，另外亦使用 ErrorMessage 當作自訂義的訊息供某些邏輯使用
    ''' <summary>
    ''' Initializes a new instance of the <see cref="CommonException"/> class.
    ''' </summary>
    ''' <param name="code">The code.</param>
    ''' <param name="msg">The MSG.</param>
    ''' <param name="formatArg">The format argument.</param>
    Public Sub New(ByRef code As String, ByRef msg As String, Optional ByRef formatArg As String() = Nothing)
        MyBase.New()
        ErrorCode = code
        If Not formatArg Is Nothing Then
            ErrorCodeArg = formatArg
        Else
            ErrorCodeArg = New String() {""}
        End If
        ErrorMessageEx = msg
        OriginalEx = Me
    End Sub
    '此建構式為特殊用法，請勿濫用。ErrorCode 取得系統定義檔裡的資訊，但，另外亦使用 ErrorMessage 當作自訂義的訊息供某些邏輯使用，ex為原始例外
    ''' <summary>
    ''' Initializes a new instance of the <see cref="CommonException"/> class.
    ''' </summary>
    ''' <param name="code">The code.</param>
    ''' <param name="msg">The MSG.</param>
    ''' <param name="ex">The ex.</param>
    ''' <param name="formatArg">The format argument.</param>
    Public Sub New(ByRef code As String, ByRef msg As String, ByRef ex As Exception, Optional ByRef formatArg As String() = Nothing)
        MyBase.New()
        ErrorCode = code
        If Not formatArg Is Nothing Then
            ErrorCodeArg = formatArg
        Else
            ErrorCodeArg = New String() {""}
        End If
        ErrorMessageEx = msg
        OriginalEx = ex
    End Sub

    '取得特殊用法的自訂義ErrorMessage
    ''' <summary>
    ''' Gets the error message ex.
    ''' </summary>
    ''' <returns></returns>
    Public Function getErrorMessageEX() As String
        Return ErrorMessageEx
    End Function

End Class