Imports Syscom.Comm.LOG
Imports Syscom.Client.servicefactory
Imports Syscom.Comm.Utility


Public Class DisplayNotifyWindowHandler

#Region "立即觸發Notify Window"
    ''' <summary>
    ''' 立即顯示訊息視窗，可自行設定顯示停留時間
    ''' </summary>
    ''' <param name="drEmpNo">通知對象</param>
    ''' <param name="subject">主旨</param>
    ''' <param name="displayMsg">內容</param>
    ''' <param name="external">條件</param>
    ''' <param name="waitTime">停留時間</param>
    ''' <remarks></remarks>
    Public Shared Sub NotifyUIRigthNowForWaitTime(ByRef drEmpNo As String, ByRef subject As String, ByRef displayMsg As String, _
                                Optional ByVal external As String = "", Optional ByVal waitTime As Integer = 18000)
        Try
            'write to nfc_notify_msg
            NFCServiceManager.getInstance.NotifyUIRigthNow(New String() {drEmpNo}, subject, displayMsg, external)
            EventManager.getInstance.RaiseNFCForceRefresh()
            'trigger notify window right now
            Dim nw As NotifyWindows = New NotifyWindows(subject, displayMsg)
            nw.SetDimensions(250, 160)
            nw.WaitTime = waitTime
            nw.Font = New System.Drawing.Font("標楷體", 12.0F)
            nw.Notify()
        Catch ex As Exception
            LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
        End Try
    End Sub
    ''' <summary>
    '''  立即顯示訊息視窗，可以自定義顯示視窗大小和字型和停留時間
    ''' </summary>
    ''' <param name="drEmpNo">通知對象</param>
    ''' <param name="subject">主旨</param>
    ''' <param name="displayMsg">內容</param>
    ''' <param name="external">條件</param>
    ''' <param name="waitTime">停留時間</param>
    ''' <param name="windowWidth">視窗寬度</param>
    ''' <param name="windowHeight">視窗高度</param>
    ''' <param name="strFont">字型</param>
    ''' <param name="size">字型大小</param>
    ''' <remarks></remarks>
    Public Shared Sub NotifyUIRigthNow(ByRef drEmpNo As String, ByRef subject As String, ByRef displayMsg As String, _
                                Optional ByRef external As String = "", Optional ByRef waitTime As Integer = 18000, _
                                Optional ByRef windowWidth As Integer = 250, Optional ByRef windowHeight As Integer = 160, _
                                Optional ByRef strFont As String = "標楷體", Optional ByRef size As Single = 12.0F)
        Try
            'write to nfc_notify_msg
            NFCServiceManager.getInstance.NotifyUIRigthNow(New String() {drEmpNo}, subject, displayMsg, external)
            'trigger notify window right now and setting display window
            Dim nw As NotifyWindows = New NotifyWindows(subject, displayMsg)
            nw.SetDimensions(windowWidth, windowHeight)
            nw.WaitTime = waitTime
            nw.Font = New System.Drawing.Font(strFont, size)
            nw.Notify()
        Catch ex As Exception
            LOGDelegate.getInstance.fileErrorMsg(ex.Message, ex)
        End Try
    End Sub
#End Region

End Class
