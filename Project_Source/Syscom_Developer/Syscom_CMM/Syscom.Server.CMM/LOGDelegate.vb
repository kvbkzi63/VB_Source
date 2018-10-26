
Imports log4net.Config
Imports log4net.Appender
Imports log4net.Repository
Imports log4net.Repository.Hierarchy
Imports Syscom.Server.SQL
Imports System.Reflection
Imports System.Transactions
Imports System.Configuration
Imports System.IO
Imports System.Data.SqlClient
Imports log4net
Imports System.Net.Mail

Public Class LOGDelegate
    Inherits Syscom.Comm.LOG.LOGDelegate

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub New()
        refreshLogSetting()
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
        Using Scope As TransactionScope = SQLConnFactory.getInstance.getSuppressTransactionScope
            InsertLog(LogLevel.DEBUG, getLoggerName(caller.DeclaringType.FullName), caller.DeclaringType.FullName, caller.Name, msg, ex)
            Scope.Complete()
        End Using
    End Sub

    ''' <summary>
    ''' 寫入 DB 的日誌檔(層級 Info)
    ''' </summary>
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub dbInfoMsg(ByRef msg As String, Optional ByRef ex As Exception = Nothing)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Using Scope As TransactionScope = SQLConnFactory.getInstance.getSuppressTransactionScope
            InsertLog(LogLevel.INFO, getLoggerName(caller.DeclaringType.FullName), caller.DeclaringType.FullName, caller.Name, msg, ex)
            Scope.Complete()
        End Using
    End Sub

    ''' <summary>
    '''寫入 DB 的日誌檔(層級 Warn)
    ''' </summary>  
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub dbWarnMsg(ByRef msg As String, Optional ByRef ex As Exception = Nothing)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Using Scope As TransactionScope = SQLConnFactory.getInstance.getSuppressTransactionScope
            InsertLog(LogLevel.WARN, getLoggerName(caller.DeclaringType.FullName), caller.DeclaringType.FullName, caller.Name, msg, ex)
            Scope.Complete()
        End Using
    End Sub

    ''' <summary>
    '''寫入 DB 的日誌檔(層級 Error)
    ''' </summary>  
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub dbErrorMsg(ByRef msg As String, ByRef ex As Exception)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Using Scope As TransactionScope = SQLConnFactory.getInstance.getSuppressTransactionScope
            InsertLog(LogLevel.ERR, getLoggerName(caller.DeclaringType.FullName), caller.DeclaringType.FullName, caller.Name, msg, ex)
            Scope.Complete()
        End Using
        If msg.Contains("交易無效") Then
            gcTEST()
        End If

    End Sub

    ''' <summary>
    ''' 寫入 DB 的日誌檔(層級 Fatal)
    ''' </summary>
    ''' <param name="msg">訊息</param>
    ''' <param name="ex">例外</param>
    ''' <remarks></remarks>
    Public Sub dbFatalMsg(ByRef msg As String, ByRef ex As Exception)
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Using Scope As TransactionScope = SQLConnFactory.getInstance.getSuppressTransactionScope
            InsertLog(LogLevel.FATAL, getLoggerName(caller.DeclaringType.FullName), caller.DeclaringType.FullName, caller.Name, msg, ex)
            Scope.Complete()
        End Using
    End Sub

    ''' <summary>
    ''' 由中介例外處理機制寫入 DB 的日誌檔(※限制僅中介例外處理機制呼叫用)
    ''' </summary>
    ''' <param name="caller"></param>
    ''' <param name="msg"></param>
    ''' <param name="ex"></param>
    ''' <remarks></remarks>
    Public Sub dbDelegateErrorMsg(ByRef caller As MethodBase, ByRef msg As String, Optional ByRef ex As Exception = Nothing)
        Using Scope As TransactionScope = SQLConnFactory.getInstance.getSuppressTransactionScope
            InsertLog(LogLevel.ERR, getLoggerName(caller.DeclaringType.FullName), caller.DeclaringType.FullName, caller.Name, msg, ex)
            Scope.Complete()
        End Using
    End Sub

    ''' <summary>
    ''' 禁止使用 (僅限特定函式呼叫用)
    ''' </summary>
    ''' <param name="callerType"></param>
    ''' <param name="methodName"></param>
    ''' <param name="msg"></param>
    ''' <remarks></remarks>
    Public Sub dbClientErrorMsg(ByVal level As LogLevel, ByVal callerType As String, ByVal methodName As String, ByVal msg As String)
        Using Scope As TransactionScope = SQLConnFactory.getInstance.getSuppressTransactionScope
            InsertLog(level, getLoggerName(callerType), callerType, methodName, msg, Nothing)
            Scope.Complete()
        End Using
    End Sub

    ''' <summary>
    ''' 利用預存程序寫入資料庫
    ''' </summary>
    ''' <param name="LOG_Level"></param>
    ''' <param name="LOG_Logger"></param>
    ''' <param name="LOG_Class"></param>
    ''' <param name="LOG_Method"></param>
    ''' <param name="LOG_Message"></param>
    ''' <param name="LOG_Exception"></param>
    ''' <param name="conn"></param>
    ''' <remarks></remarks>
    Private Sub InsertLog(ByVal LOG_Level As LogLevel, ByVal LOG_Logger As String, ByVal LOG_Class As String, ByVal LOG_Method As String, ByVal LOG_Message As String, ByVal LOG_Exception As Exception, Optional ByVal conn As IDbConnection = Nothing)
        Try
            If conn Is Nothing Then
                conn = getLogConnection()
            End If

            Using conn
                Dim command As SqlCommand = New SqlCommand("InsertLog", conn)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add("@LOG_Thread", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Level", SqlDbType.VarChar, 50)
                command.Parameters.Add("@LOG_Logger", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Class", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Method", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Message", SqlDbType.NVarChar, 4000)
                command.Parameters.Add("@LOG_Exception", SqlDbType.NVarChar, 2000)

                Dim Level As String = ""
                Select Case LOG_Level
                    Case LogLevel.DEBUG
                        Level = "DEBUG"
                    Case LogLevel.INFO
                        Level = "INFO"
                    Case LogLevel.WARN
                        Level = "WARN"
                    Case LogLevel.ERR
                        Level = "ERROR"
                    Case LogLevel.FATAL
                        Level = "FATAL"
                End Select
                LOG_Logger = Environment.MachineName & "--" & LOG_Logger
                Dim StackTrace As String = ""
                If LOG_Exception IsNot Nothing Then
                    StackTrace = LOG_Exception.StackTrace
                End If

                command.Parameters("@LOG_Thread").Value = System.Threading.Thread.CurrentThread.ManagedThreadId
                command.Parameters("@LOG_Level").Value = Level
                command.Parameters("@LOG_Logger").Value = LOG_Logger
                command.Parameters("@LOG_Class").Value = LOG_Class
                command.Parameters("@LOG_Method").Value = LOG_Method
                command.Parameters("@LOG_Message").Value = LOG_Message
                command.Parameters("@LOG_Exception").Value = StackTrace

                If conn.State <> ConnectionState.Open Then
                    conn.Open()
                End If

                command.ExecuteNonQuery()
                
            End Using
        Catch ex As Exception
            System.Console.WriteLine(ex.Message)
        Finally
            If conn.State = ConnectionState.Open AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Sub

    ''' <summary>
    ''' get database logger to write message to database log table
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getDBLogger(ByVal callerType As String, ByVal methodName As String) As ILog
        Dim dbLog As ILog = LogManager.GetLogger(getLoggerName(callerType))
        Dim connectionAppender As Core.IAppenderAttachable = dbLog.Logger
        Try
            connectionAppender.RemoveAppender("appAdoNetAppender")
            connectionAppender.AddAppender(getAdoNetAppender(callerType, methodName))
        Catch ex As Exception
            fileErrorMsg(ex.Message, ex)
        End Try
        Return dbLog
    End Function

    ''' <summary>
    ''' 為了實現動態寫入不同DB，只好將 AdoNetAppender 用程式設定
    ''' </summary>
    ''' <returns>AdoNetAppender</returns>
    ''' <remarks></remarks>
    Private Function getAdoNetAppender(ByVal callerType As String, ByVal methodName As String) As AdoNetAppender
        Dim ado As New AdoNetAppender
        ado.Name = "appAdoNetAppender"
        ado.ConnectionType = "System.Data.SqlClient.SqlConnection, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ado.ConnectionString = ConfigurationManager.ConnectionStrings("DBLogConnectionString").ConnectionString
        'ado.ConnectionString = "Data Source=172.16.20.55;Initial Catalog=NISDB;User ID=sa;Password=syscom@123;Max Pool Size=50;Min Pool Size=5;Pooling=True"
        ado.CommandText = "INSERT INTO LOG_HIS_OPD_Application ([LOG_Date],[LOG_Thread],[LOG_Level],[LOG_Logger],[LOG_Class],[LOG_Method],[LOG_Message],[LOG_Exception]) VALUES (@log_date, @thread, @log_level, @logger, @class, @method, @message, @exception)"
        'ado.BufferSize = 2

        Dim param As AdoNetAppenderParameter

        param = New AdoNetAppenderParameter
        param.ParameterName = "@log_date"
        param.DbType = DbType.DateTime
        param.Layout = New log4net.Layout.RawTimeStampLayout()
        ado.AddParameter(param)

        param = New AdoNetAppenderParameter
        param.ParameterName = "@thread"
        param.DbType = DbType.String
        param.Size = 255
        param.Layout = New Layout.Layout2RawLayoutAdapter(New Layout.PatternLayout("%t"))
        ado.AddParameter(param)

        param = New AdoNetAppenderParameter
        param.ParameterName = "@log_level"
        param.DbType = DbType.String
        param.Size = 50
        param.Layout = New Layout.Layout2RawLayoutAdapter(New Layout.PatternLayout("%p"))
        ado.AddParameter(param)

        param = New AdoNetAppenderParameter
        param.ParameterName = "@logger"
        param.DbType = DbType.String
        param.Size = 255
        param.Layout = New Layout.Layout2RawLayoutAdapter(New Layout.PatternLayout("%c"))
        ado.AddParameter(param)

        param = New AdoNetAppenderParameter
        param.ParameterName = "@class"
        param.DbType = DbType.String
        param.Size = 255
        param.Layout = New Layout.Layout2RawLayoutAdapter(New Layout.PatternLayout(callerType))
        ado.AddParameter(param)

        param = New AdoNetAppenderParameter
        param.ParameterName = "@method"
        param.DbType = DbType.String
        param.Size = 255
        param.Layout = New Layout.Layout2RawLayoutAdapter(New Layout.PatternLayout(methodName))
        ado.AddParameter(param)

        param = New AdoNetAppenderParameter
        param.ParameterName = "@message"
        param.DbType = DbType.String
        param.Size = 4000
        param.Layout = New Layout.Layout2RawLayoutAdapter(New Layout.PatternLayout("%m"))
        ado.AddParameter(param)

        param = New AdoNetAppenderParameter
        param.ParameterName = "@exception"
        param.DbType = DbType.String
        param.Size = 2000
        param.Layout = New Layout.Layout2RawLayoutAdapter(New Layout.ExceptionLayout)
        ado.AddParameter(param)
        ado.UseTransactions = False
        ado.ActivateOptions()

        Return ado
    End Function

    ''' <summary>
    ''' 取得資料庫連結
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getLogConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

#End Region

#Region "GC"
    Private Sub gcTEST()
        For i As Integer = 1 To GC.MaxGeneration
            ' 進行 GC 收集動作 
            GC.Collect()
        Next
        For i As Integer = 0 To GC.MaxGeneration
            ' 強制立即執行層代零至指定層代的記憶體回收。 
            GC.Collect(i)
            ' 暫止目前的執行緒，直到處理完成項佇列的執行緒已經清空該佇列為止。 
            GC.WaitForPendingFinalizers()
        Next
    End Sub
#End Region

End Class
