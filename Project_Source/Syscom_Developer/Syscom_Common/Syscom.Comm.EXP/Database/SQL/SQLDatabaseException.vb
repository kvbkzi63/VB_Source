'/*
'*****************************************************************************
'*
'*    Page/Class Name:  SQL Server 資料庫例外狀況
'*              Title:	SQLDatabaseException
'*        Description:	SQL Server 資料庫例外狀況
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-02-18
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-02-18
'*
'*****************************************************************************
'*/

Public Class SQLDatabaseException
    Inherits DatabaseException
    Public Sub New(ByRef ex As Exception)
        MyBase.New("", ex, formatArg:=Nothing, caller:=New StackTrace().GetFrames(1).GetMethod())
    End Sub
    '此建構式為標準用法，ErrorMessage　會自動取得系統定義檔裡的資訊，亦可直接拿來顯示給使用者看
    Private Sub New(ByRef code As String, Optional ByRef formatArg As String() = Nothing)
        MyBase.New(code, formatArg, New StackTrace().GetFrames(1).GetMethod())
    End Sub
    '此建構式為標準用法，ErrorMessage　會自動取得系統定義檔裡的資訊，ex為原始例外
    Private Sub New(ByRef code As String, ByRef ex As Exception, Optional ByRef formatArg As String() = Nothing)
        MyBase.New(code, ex, formatArg, New StackTrace().GetFrames(1).GetMethod())
    End Sub
End Class
