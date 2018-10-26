'/*
'*****************************************************************************
'*
'*    Page/Class Name:  比較的Util
'*              Title:	CompareUtil
'*        Description:	比較各種傳入參數的結果
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2013-10-01
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2013-10-01
'*
'*****************************************************************************
'*/

Imports System.Reflection
Imports Syscom.Comm.EXP

Public Class CompareUtil

    '目前使用者的ID
    Private Shared CurrentUserID As String = AppContext.userProfile.userId

    ''目前使用者的院區
    'Private CurrentUserSection As String = AppContext.userProfile.userSection

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 比對傳入的資料建立者，是否為目前的登入者，相同回傳True，不同回傳False
    ''' </summary>
    ''' <param name="CreateUser" >資料建立者</param>
    ''' <remarks>by Sean.Lin on 2013-10-01</remarks>
    Public Shared Function CompareLoginCreateUser(ByVal CreateUser As String) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Return CompareLoginCreateUser(CreateUser, CurrentUserID)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 比對傳入的資料建立者、登入者，是否相同，相同回傳True，不同回傳False
    ''' </summary>
    ''' <param name="CreateUser" >資料建立者</param>
    ''' <remarks>by Sean.Lin on 2013-10-01</remarks>
    Public Shared Function CompareLoginCreateUser(ByVal CreateUser As String, ByVal LoginUser As String) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If StringUtil.nvl(CreateUser) = StringUtil.nvl(LoginUser) Then
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

End Class

