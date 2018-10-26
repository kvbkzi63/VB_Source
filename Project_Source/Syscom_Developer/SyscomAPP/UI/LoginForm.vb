Imports System.Windows.Forms
Imports System.Data
Imports System.Diagnostics
Imports System.ServiceModel
Imports System.Deployment.Application
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports Syscom.Client.UCL
Imports Syscom.Client.NFC
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.BASE
Imports System.IO


Public Class LoginForm

    '  插入程式碼，利用提供的使用者名稱和密碼執行自訂驗證
    ' (請參閱 http://go.microsoft.com/fwlink/?LinkId=35339)。
    ' 如此便可將自訂主體附加到目前執行緒的主體，如下所示:
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' 其中 CustomPrincipal 是用來執行驗證的 IPrincipal 實作。
    ' 接著，My.User 便會傳回封裝在 CustomPrincipal 物件中的識別資訊，
    ' 例如使用者名稱、顯示名稱等。

    '加入接取訊息傳遞的Event
    Dim WithEvents eventManager As EventManager = eventManager.getInstance
    Private ReadOnly myIP As String = AppContext.userProfile.userIP

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            ModForm.SystemNo = "OPD"
            Me.DialogResult = Windows.Forms.DialogResult.OK
            
        Catch ex As Exception

            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
       
        Me.Close()

    End Sub

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            '呼叫執行EFS前置作業
            'copyEFSToUserTemplate()

            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))

            Dim bmpTmp As System.Drawing.Bitmap

            Me.Text = "認證授權系統"
            bmpTmp = New System.Drawing.Bitmap("images\高雄市聯合醫院(開發機).jpg")
            Me.BackgroundImage = bmpTmp

            Dim domainName As String = System.Environment.UserDomainName 'userid.GetUserID().Split("\")(0)
            Dim domainUser As String = System.Environment.UserName 'userid.GetUserID().Split("\")(1)
            
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#Region "訊息傳遞的Event"

    '接取訊息傳遞的Event-Error
    Private Sub showErrorMsg(ByVal inErrorCode As String, ByVal inMessage As String(), ByVal inDetail As String)
        Try
            Dim OpenMessageDlg As New UCLMessageHandlingUI(UCLMessageHandlingUI.STATUS.ERR, inErrorCode, inMessage, inDetail)
            OpenMessageDlg.ShowDialog()
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    '接取訊息傳遞的Event-Warn
    Private Sub showWarnMsg(ByVal inErrorCode As String, ByVal inMessage As String())
        Try
            Dim OpenMessageDlg As New UCLMessageHandlingUI(UCLMessageHandlingUI.STATUS.WARN, inErrorCode, inMessage)
            OpenMessageDlg.ShowDialog()
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

#End Region

#Region "KeyPress Event"

    Private Sub UsernameTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UsernameTextBox.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PasswordTextBox.Focus()
        End If

    End Sub

    Private Sub PasswordTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PasswordTextBox.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            OK.Focus()
        End If
    End Sub

#End Region



End Class
