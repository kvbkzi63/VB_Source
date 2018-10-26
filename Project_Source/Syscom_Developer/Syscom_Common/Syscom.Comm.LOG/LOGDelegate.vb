'/*
'*****************************************************************************
'*
'*    Page/Class Name:  日誌紀錄
'*              Title:	LOGDelegate
'*        Description:	日誌紀錄，為所有程式碼提供紀錄資訊
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-01-20
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-01-20
'*
'*****************************************************************************
'*/

Imports log4net
Imports log4net.Config
Imports log4net.Appender
Imports log4net.Repository
Imports log4net.Repository.Hierarchy
Imports System.IO
Imports System.Reflection
Imports System.Configuration
Imports System.Transactions
Imports Syscom.Comm.BASE

Public MustInherit Class LOGDelegate
    Inherits BaseClass

    ''' <summary>
    ''' 日誌等級
    ''' </summary>
    ''' <remarks></remarks>
    Enum LogLevel
        DEBUG
        INFO
        WARN
        ERR
        FATAL
    End Enum

    ''' <summary>
    ''' 取得組件名稱(對應於 log4net.xml 中)
    ''' </summary>
    ''' <param name="objType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function getLoggerName(ByRef objType As String) As String

        '判斷的組件名稱必須完全部小寫，因為已經來源強制轉為小寫!
        If LCase(objType).Contains("syscom.comm") Then
            Return "Syscom.Comm"
        ElseIf (LCase(objType).Contains("syscom.server") Or LCase(objType).Contains("syscomserverwcfservice")) Then
            Return "Syscom.Server"
        ElseIf (LCase(objType).Contains("syscom.client") Or LCase(objType).Contains("syscom.client.servicefactory")) Then
            Return "Syscom.Client"
        ElseIf (LCase(objType).Contains("opd.comm")) Then
            Return "OPD.Comm"
        ElseIf (LCase(objType).Contains("opd.server") Or LCase(objType).Contains("opdservicewcfservice")) Then
            Return "OPD.Server"
        ElseIf (LCase(objType).Contains("opd.client") Or LCase(objType).Contains("opdapp") Or LCase(objType).Contains("opd.client.servicefactory")) Then
            Return "OPD.Client"
        ElseIf LCase(objType).Contains("nis.comm") Then
            Return "NIS.Comm"
        ElseIf (LCase(objType).Contains("nis.server") Or LCase(objType).Contains("serverwcfservice")) Then
            Return "NIS.Server"
        ElseIf (LCase(objType).Contains("nis.client") Or LCase(objType).Contains("nisapp") Or LCase(objType).Contains("nis.client.servicefactory")) Then
            Return "NIS.Client"
        ElseIf LCase(objType).Contains("eis.comm") Then
            Return "EIS.Comm"
        ElseIf (LCase(objType).Contains("eis.server") Or LCase(objType).Contains("eisserverwcfservice")) Then
            Return "EIS.Server"
        ElseIf (LCase(objType).Contains("eis.client") Or LCase(objType).Contains("eisapp") Or LCase(objType).Contains("eis.client.servicefactory")) Then
            Return "EIS.Client"
        ElseIf LCase(objType).Contains("pcs.comm") Then
            Return "PCS.Comm"
        ElseIf (LCase(objType).Contains("pcs.server") Or LCase(objType).Contains("pcsserverwcfservice")) Then
            Return "PCS.Server"
        ElseIf (LCase(objType).Contains("pcs.client") Or LCase(objType).Contains("pcsapp") Or LCase(objType).Contains("pcs.client.servicefactory")) Then
            Return "PCS.Client"
        ElseIf LCase(objType).Contains("cdr.comm") Then
            Return "CDR.Comm"
        ElseIf (LCase(objType).Contains("cdr.server") Or LCase(objType).Contains("cdrserverwcfservice")) Then
            Return "CDR.Server"
        ElseIf (LCase(objType).Contains("cdr.client") Or LCase(objType).Contains("cdrapp") Or LCase(objType).Contains("cdr.client.servicefactory")) Then
            Return "CDR.Client"
        Else
            Return "Unknown"   '固定的預設值
        End If
    End Function

#Region " 寫入檔案 "

    ''' <summary>
    ''' 寫入檔案的日誌檔(層級 Debug)
    ''' </summary>
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub fileDebugMsg(ByRef msg As String, Optional ByRef ex As Exception = Nothing)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        getFileLogger(caller.DeclaringType.FullName).Debug(caller.DeclaringType.FullName & "--" & caller.Name & "()--" & msg, ex)
    End Sub

    ''' <summary>
    ''' 寫入檔案的日誌檔(層級 Info)
    ''' </summary>
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub fileInfoMsg(ByRef msg As String, Optional ByRef ex As Exception = Nothing)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        getFileLogger(caller.DeclaringType.FullName).Info(caller.DeclaringType.FullName & "--" & caller.Name & "()--" & msg, ex)
    End Sub

    ''' <summary>
    '''寫入檔案的日誌檔(層級 Warn)
    ''' </summary>  
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub fileWarnMsg(ByRef msg As String, Optional ByRef ex As Exception = Nothing)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        getFileLogger(caller.DeclaringType.FullName).Warn(caller.DeclaringType.FullName & "--" & caller.Name & "()--" & msg, ex)
    End Sub

    ''' <summary>
    '''寫入檔案的日誌檔(層級 Error)
    ''' </summary>  
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub fileErrorMsg(ByRef msg As String, ByRef ex As Exception)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        getFileLogger(caller.DeclaringType.FullName).Error(caller.DeclaringType.FullName & "--" & caller.Name & "()--" & msg, ex)
    End Sub

    ''' <summary>
    ''' 寫入檔案的日誌檔(層級 Fatal)
    ''' </summary>
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub fileFatalMsg(ByRef msg As String, ByRef ex As Exception)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        getFileLogger(caller.DeclaringType.FullName).Fatal(caller.DeclaringType.FullName & "--" & caller.Name & "()--" & msg, ex)
    End Sub

    ''' <summary>
    ''' 由中介訊息處理機制寫入檔案的日誌檔(※限制僅中介訊息處理機制呼叫用，前後端皆相同)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub fileDelegateErrorMsg(ByRef caller As MethodBase, ByRef msg As String, Optional ByRef ex As Exception = Nothing)
        Dim fileLog As ILog = LogManager.GetLogger("File." & getLoggerName(caller.DeclaringType.FullName))
        fileLog.Error(caller.DeclaringType.FullName & "--" & caller.Name & "()--" & msg, ex)
    End Sub

    ''' <summary>
    ''' 取得檔案紀錄器(對應於 log4net.xml 中)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function getFileLogger(ByRef caller As String) As ILog
        Dim fileLog As ILog = LogManager.GetLogger("File." & getLoggerName(caller))
        Return fileLog
    End Function

#End Region

End Class
