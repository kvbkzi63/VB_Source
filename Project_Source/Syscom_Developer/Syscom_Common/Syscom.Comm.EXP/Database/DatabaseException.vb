'/*
'*****************************************************************************
'*
'*    Page/Class Name:  資料庫例外狀況
'*              Title:	DatabaseException
'*        Description:	資料庫例外狀況
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-02-18
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-02-18
'*
'*****************************************************************************
'*/

Imports System.Reflection

Public Class DatabaseException
    Inherits CommonException
    '此建構式為標準用法，ErrorMessage　會自動取得系統定義檔裡的資訊，亦可直接拿來顯示給使用者看
    Public Sub New(ByRef code As String, Optional ByRef formatArg As String() = Nothing, Optional ByVal caller As MethodBase = Nothing)
        MyBase.New(code, formatArg, IIf(caller Is Nothing, New StackTrace().GetFrames(1).GetMethod(), caller))
    End Sub
    '此建構式為標準用法，ErrorMessage　會自動取得系統定義檔裡的資訊，ex為原始例外
    Public Sub New(ByRef code As String, ByRef ex As Exception, Optional ByRef formatArg As String() = Nothing, Optional ByVal caller As MethodBase = Nothing)
        MyBase.New(code, ex, formatArg, IIf(caller Is Nothing, New StackTrace().GetFrames(1).GetMethod(), caller))
    End Sub
End Class
