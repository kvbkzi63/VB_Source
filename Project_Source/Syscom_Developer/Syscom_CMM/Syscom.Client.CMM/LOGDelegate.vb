Imports System.Reflection
Imports Syscom.Client.Servicefactory
Imports System.IO

Public Class LOGDelegate
    Inherits Syscom.Comm.LOG.LOGDelegate

    Private pub As IPubServiceManager = Nothing

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub New()
        refreshLogSetting()
        pub = PubServiceManager.getInstance
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property getInstance() As LOGDelegate
        Get
            Return Nested.instance
        End Get
    End Property

    ''' <summary>
    ''' 巢狀類別存放建立的類別實體
    ''' </summary>
    ''' <remarks></remarks>
    Private Class Nested
        Shared Sub New()
        End Sub

        Public Shared ReadOnly instance As New LOGDelegate()
    End Class

#End Region

    ''' <summary>
    ''' 即時讀取 log4net.xml 更新 log4net 檔案設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub refreshLogSetting()
        Dim byteData As Byte() = System.Text.Encoding.Default.GetBytes(My.Resources.log4net)
        Dim ms As MemoryStream = New MemoryStream(byteData)
        log4net.Config.XmlConfigurator.Configure(ms)
        ms.Close()
    End Sub

#Region " 寫入資料庫，加入排除交易範圍目的在於不被回溯 "

    ''' <summary>
    ''' 寫入 DB 的日誌檔(層級 Debug)
    ''' </summary>
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub dbDebugMsg(ByRef msg As String, Optional ByRef ex As Exception = Nothing)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        pub.doClientLog(LogLevel.DEBUG, caller.DeclaringType.FullName, caller.Name, msg)
    End Sub

    ''' <summary>
    ''' 寫入 DB 的日誌檔(層級 Info)
    ''' </summary>
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub dbInfoMsg(ByRef msg As String, Optional ByRef ex As Exception = Nothing)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        pub.doClientLog(LogLevel.INFO, caller.DeclaringType.FullName, caller.Name, msg)
    End Sub

    ''' <summary>
    '''寫入 DB 的日誌檔(層級 Warn)
    ''' </summary>  
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub dbWarnMsg(ByRef msg As String, Optional ByRef ex As Exception = Nothing)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        pub.doClientLog(LogLevel.WARN, caller.DeclaringType.FullName, caller.Name, msg)
    End Sub

    ''' <summary>
    '''寫入 DB 的日誌檔(層級 Error)
    ''' </summary>  
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub dbErrorMsg(ByRef msg As String, ByRef ex As Exception)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        pub.doClientLog(LogLevel.ERR, caller.DeclaringType.FullName, caller.Name, msg)
    End Sub

    ''' <summary>
    ''' 寫入 DB 的日誌檔(層級 Fatal)
    ''' </summary>
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub dbFatalMsg(ByRef msg As String, ByRef ex As Exception)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        pub.doClientLog(LogLevel.FATAL, caller.DeclaringType.FullName, caller.Name, msg)
    End Sub

    ''' <summary>
    ''' 禁止使用 (僅限特定函式呼叫用)
    ''' </summary>
    ''' <param name="callerType"></param>
    ''' <param name="methodName"></param>
    ''' <param name="msg"></param>
    ''' <remarks></remarks>
    Public Sub dbClientErrorMsg(ByVal level As LogLevel, ByVal callerType As String, ByVal methodName As String, ByVal msg As String)
        pub.doClientLog(level, callerType, methodName, msg)
    End Sub

#End Region

End Class
