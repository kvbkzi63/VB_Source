Imports System.Messaging
Imports System.Configuration
Imports Syscom.Comm.EXP
Imports Syscom.Comm.BASE

Public Class MessageQueueUtil

    Private Shared ReadOnly MQPathConfigName As String = "MSMQMPath"
    Private Shared ReadOnly MQPathConfigNameTx As String = "MSMQMPathTx"

#Region "Singleton Design Pattern - Fully Thread Safety"

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 屬性取得類別實體
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property getInstance() As MessageQueueUtil
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

        Public Shared ReadOnly instance As New MessageQueueUtil()
    End Class

#End Region

    ''' <summary>
    ''' 後端列印機制使用的MSMQ
    ''' </summary>
    ''' <param name="data">報表擋案的FID</param>
    ''' <remarks></remarks>
    Public Sub sendReportMessage(ByRef data As Object)
        Try
            sendMessage("RPT", data)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub
    ''' <summary>
    ''' 後端列印機制使用的MSMQ Tx
    ''' </summary>
    ''' <param name="data">報表擋案的FID</param>
    ''' <remarks></remarks>
    Public Sub sendReportMessageTx(ByRef data As Object)
        Try
            sendMessageTx("RPT", data)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub
    ''' <summary>
    ''' 後端列印機制使用的MSMQ Message Body
    ''' </summary>    
    ''' <remarks>Message Body 的資料格式</remarks>
    Public Function getReportMessageBody() As DataSet
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = New DataTable("RPT")
        dataTable.Columns.Add("Med_NO")
        dataTable.Columns.Add("ReportID")
        dataTable.Columns.Add("ReportFileFID")
        dataTable.Columns.Add("PrinterName")
        dataTable.Columns.Add("PrintUser")
        dataSet.Tables.Add(dataTable)
        Return dataSet
    End Function

    ''' <summary>
    ''' Notification Module 使用的MSMQ
    ''' </summary>
    ''' <param name="data">訊息字串</param>
    ''' <remarks></remarks>
    Public Sub sendNotificationMessage(ByRef data As Object)
        Try
            sendMessage("NFC", data)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub
    ''' <summary>
    ''' Notification Module 使用的MSMQ Tx
    ''' </summary>
    ''' <param name="data">訊息字串</param>
    ''' <remarks></remarks>
    Public Sub sendNotificationMessageTx(ByRef data As Object)
        Try
            sendMessageTx("NFC", data)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub
    ''' <summary>
    ''' Notification Module 使用的MSMQ
    ''' </summary>    
    ''' <remarks>Message Body 的資料格式</remarks>
    Public Function getNotificationMessageBody() As DataSet
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = New DataTable("NFC")
        dataTable.Columns.Add("NFCID")
        dataTable.Columns.Add("Message")
        dataSet.Tables.Add(dataTable)
        Return dataSet
    End Function

    ''' <summary>
    ''' 敏感資料備份 使用的MSMQ
    ''' </summary>
    ''' <param name="data">訊息字串</param>
    ''' <remarks></remarks>
    Public Sub sendBackupTableMessage(ByRef data As Object)
        Try
            sendMessage("BKT", data)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub
    ''' <summary>
    ''' 敏感資料備份 使用的MSMQ Tx
    ''' </summary>
    ''' <param name="data">訊息字串</param>
    ''' <remarks></remarks>
    Public Sub sendBackupTableMessageTx(ByRef data As Object)
        Try
            sendMessageTx("BKT", data)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 個資法Log 使用的MSMQ
    ''' </summary>
    ''' <param name="data">訊息字串</param>
    ''' <remarks></remarks>
    Public Sub sendPILogMessage(ByRef data As Object)
        Try
            Dim PILMSMQMOpen As String = ConfigurationManager.AppSettings.Item("PILMSMQMOpen")
            If PILMSMQMOpen IsNot Nothing AndAlso PILMSMQMOpen.Equals("Y") Then
                sendMessage("PIL", data)
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub
    ''' <summary>
    ''' 個資法Log 使用的MSMQ Tx
    ''' </summary>
    ''' <param name="data">訊息字串</param>
    ''' <remarks></remarks>
    Public Sub sendPILogMessageTx(ByRef data As Object)
        Try
            Dim PILMSMQMOpen As String = ConfigurationManager.AppSettings.Item("PILMSMQMOpen")
            If PILMSMQMOpen IsNot Nothing AndAlso PILMSMQMOpen.Equals("Y") Then
                sendMessageTx("PIL", data)
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 一般AP程式使用的MSMQ
    ''' </summary>
    ''' <param name="data">物件</param>
    ''' <remarks></remarks>
    Public Sub sendApplicationMessage(ByRef data As Object)
        Try
            sendMessage("APP", data)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub
    ''' <summary>
    ''' 一般AP程式使用的MSMQ Tx
    ''' </summary>
    ''' <param name="data">物件</param>
    ''' <remarks></remarks>
    Public Sub sendApplicationMessageTx(ByRef data As Object)
        Try
            sendMessageTx("APP", data)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    ''' <summary>
    ''' 傳送 MSMQ 訊息
    ''' </summary>
    ''' <param name="mqLabel">標籤</param>
    ''' <param name="mqData">資料</param>
    ''' <remarks></remarks>
    Private Sub sendMessage(ByRef mqLabel As String, ByRef mqData As Object)
        Dim newQueue As MessageQueue = Nothing
        Try
            Select Case HospConfigUtil.HospConfig
                Case HospConfigUtil.hospConfigList.Tw_Taci
                    Exit Sub
            End Select
            newQueue = getNewMessageQueue(mqLabel)
            newQueue.DefaultPropertiesToSend.Recoverable = True 'MSMQ 不會因為機器 crash 消失
            If newQueue IsNot Nothing Then
                Dim msg As Message = New Message()
                msg.Label = mqLabel
                msg.Body = mqData
                newQueue.Send(msg)
                'LOGDelegate.getInstance.fileDebugMsg("newQueue id=" & newQueue.Id.ToString & " send @" & Now)
            Else
                Throw New CommonException("SYSMSQA001")
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            'LOGDelegate.getInstance.dbErrorMsg("MessageQueueUtil sendMessage exception:" & ex.Message & ",mqLabel:" & mqLabel, ex)
            Throw New CommonException("SYSMSQA002", ex)
        Finally
            If newQueue IsNot Nothing Then
                'LOGDelegate.getInstance.fileDebugMsg("newQueue id=" & newQueue.Id.ToString & " close @" & Now)
                newQueue.Close()
                newQueue.Dispose()
                newQueue = Nothing
            End If
        End Try
    End Sub
    ''' <summary>
    ''' 傳送 MSMQ 訊息 Tx
    ''' </summary>
    ''' <param name="mqLabel">標籤</param>
    ''' <param name="mqData">資料</param>
    ''' <remarks></remarks>
    Private Sub sendMessageTx(ByRef mqLabel As String, ByRef mqData As Object)
        'Dim newQueue As MessageQueue = getNewMessageQueueTx(mqLabel) '因為 Load Balance 問題，所以 Tx 暫時無法使用
        Dim newQueue As MessageQueue = Nothing
        Try
            Select Case HospConfigUtil.HospConfig
                Case HospConfigUtil.hospConfigList.Tw_Taci
                    Exit Sub
            End Select
            newQueue = getNewMessageQueue(mqLabel)
            newQueue.DefaultPropertiesToSend.Recoverable = True 'MSMQ 不會因為機器 crash 消失
            If newQueue IsNot Nothing Then
                Dim msg As Message = New Message()
                msg.Label = mqLabel
                msg.Body = mqData
                'newQueue.Send(msg, MessageQueueTransactionType.Automatic) '因為 Load Balance 問題，所以 Tx 暫時無法使用
                newQueue.Send(msg)
            Else
                Throw New CommonException("SYSMSQA001")
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            'LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
            Throw New CommonException("SYSMSQA002", ex)
        Finally
            If newQueue IsNot Nothing Then
                newQueue.Close()
                newQueue.Dispose()
                newQueue = Nothing
            End If
        End Try
    End Sub

    ''' <summary>
    ''' 取得新的 MessageQueue
    ''' </summary>
    ''' <returns>MessageQueue</returns>
    ''' <remarks></remarks>
    Private Function getNewMessageQueue(ByRef mqLabel As String) As MessageQueue
        Try
            'LOGDelegate.getInstance.fileDebugMsg("MessageQueue Setting" & ConfigurationManager.AppSettings.Item(mqLabel & MQPathConfigName))
            Return New MessageQueue(ConfigurationManager.AppSettings.Item(mqLabel & MQPathConfigName))
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            'LOGDelegate.getInstance.dbErrorMsg("getNewMessageQueue exception:" & ex.Message & ",MessageQueue Setting:" & ConfigurationManager.AppSettings.Item(mqLabel & MQPathConfigName), ex)
            Throw New CommonException("SYSMSQA001", ex)
        End Try
    End Function
    ''' <summary>
    ''' 取得新的 MessageQueueTx
    ''' </summary>
    ''' <returns>MessageQueueTx</returns>
    ''' <remarks></remarks>
    Private Function getNewMessageQueueTx(ByRef mqLabel As String) As MessageQueue
        Try
            'LOGDelegate.getInstance.fileDebugMsg("MessageQueueTx Setting" & ConfigurationManager.AppSettings.Item(mqLabel & MQPathConfigNameTx))
            Return New MessageQueue(ConfigurationManager.AppSettings.Item(mqLabel & MQPathConfigNameTx))
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            'LOGDelegate.getInstance.dbErrorMsg("getNewMessageQueueTx exception:" & ex.Message & ",MessageQueue Setting:" & ConfigurationManager.AppSettings.Item(mqLabel & MQPathConfigNameTx), ex)
            Throw New CommonException("SYSMSQA001", ex)
        End Try
    End Function

End Class
