Imports Microsoft.VisualBasic.Devices
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Reflection
Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.IO
Imports System.Xml
Imports System.Globalization
Imports System.Deployment.Application
Imports System.Data
Imports System.Runtime.InteropServices
Imports Com.Syscom.WinFormsUI.Docking
Imports Syscom.Comm.BASE
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Client.UCL
Imports Syscom.Client.CMM
Imports Syscom.Client.ICC
Imports Syscom.Client.Servicefactory


Public Class MainForm

    Private Const XmlNodeTextAtt As String = "text"
    Private Const XmlNodeTagAtt As String = "tag"
    Private Const XmlNodeImageIndexAtt As String = "imageindex"
    Private Const XmlNodeTag As String = "node"

    Private m_bSaveLayout As Boolean = True
    Private m_deserializeDockContent As DeserializeDockContent
    Private ms As New MenuStrip()
    Private windowMenu As New ToolStripMenuItem()
    Private windowMenu1 As New ToolStripMenuItem()
    Private windowMenu2 As New ToolStripMenuItem()
    Private windowMenu3 As New ToolStripMenuItem()

    '預設顏色
    Dim _R As Integer = 240
    Dim _G As Integer = 255
    Dim _B As Integer = 255

    '字型
    Dim _fontName As String = "新細明體"
    Dim _fontSize As Single = 12
    Dim _fontStyle As System.Drawing.FontStyle = 0
    Dim notifyWindowCount As Integer = 0

    '記錄護理人員要查詢醫囑簽收的Timer 指數
    Private globalNurseSignTip As Integer = 0

    '記錄是否為護理人員，true: 為護理人員
    Private globalNurseFlag As Boolean = False

    '加入接取訊息傳遞的Event
    Private WithEvents eventManager As EventManager = eventManager.getInstance
    Private agentCount As Integer = 0
    Private loginDate As String = ""
    Private agentCode As String = ""

    Private titleWord As String = ""
    Private _userProfile As New UserProfile
    '
    Dim appIdleTime As Integer = 15
    Property thisUserProfile As UserProfile
        Get
            Return _userProfile
        End Get
        Set(ByVal value As UserProfile)
            _userProfile = value
        End Set
    End Property

    '接收切換使用者Event add on 2012-05-10 by Lits
    Public Sub EISSwitchUser() Handles eventManager.SwitchUserEvent
        Try
            SwitchUser()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    '接取訊息傳遞的Event
    Public Sub DisplayStatusBar(ByVal msg As String) Handles eventManager.DisplayStatusBar
        Try
            displayMessageBar(msg)
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    '自動打開 看診作業 Event 例如: showDockEvent("看診作業")
    Public Sub showDockEvent(ByVal dockFormName As String) Handles eventManager.showDockEven
        Try
            Dim f As DockContent = CType(FindDocument(dockFormName), Com.Syscom.WinFormsUI.Docking.DockContent)
            If f IsNot Nothing Then
                f.Show()
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Dim OpenWaitMessageDlg As UCLWaitingFormUI

    '接取Waiting 
    Public Sub showWaitingMsg(ByVal Action As String, ByVal Msg As String) Handles eventManager.UclWaitingForm
        Try
            If Action = "WaitingStart" Then
                If OpenWaitMessageDlg IsNot Nothing Then
                    OpenWaitMessageDlg.Dispose()
                End If
                OpenWaitMessageDlg = New UCLWaitingFormUI(Msg)
                OpenWaitMessageDlg.Show()
            ElseIf Action = "WaitingEnd" Then
                If OpenWaitMessageDlg IsNot Nothing Then
                    OpenWaitMessageDlg.FinishJob()
                End If
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    '接取Waiting 
    Public Sub showWaitingMsg2(ByVal Action As String, ByVal Msg As String, ByVal LocationX As Integer, ByVal LocationY As Integer) Handles eventManager.UclWaitingForm2
        Try
            If Action = "WaitingStart" Then
                If OpenWaitMessageDlg IsNot Nothing Then
                    OpenWaitMessageDlg.Dispose()
                End If
                OpenWaitMessageDlg = New UCLWaitingFormUI(Msg)
                OpenWaitMessageDlg.StartPosition = FormStartPosition.Manual
                OpenWaitMessageDlg.Location = New Point(LocationX, LocationY)
                OpenWaitMessageDlg.Show()
            ElseIf Action = "WaitingEnd" Then
                If OpenWaitMessageDlg IsNot Nothing Then
                    OpenWaitMessageDlg.FinishJob()
                End If
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        m_deserializeDockContent = New DeserializeDockContent(AddressOf GetContentFromPersistString)
        Me.thisUserProfile = AppContext.userProfile
    End Sub

    Public Sub New(ByVal tempUserProfile As UserProfile)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        m_deserializeDockContent = New DeserializeDockContent(AddressOf GetContentFromPersistString)
        Me.thisUserProfile = tempUserProfile
    End Sub

    Private Sub MainForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        AppContext.userProfile = Me.thisUserProfile
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            If Me.thisUserProfile.agentId = "unknown" Then
                System.Windows.Forms.Application.Exit()
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '關閉系統提示
        Try
            Dim MessageString As String = ""
            If agentCount > 0 Then
                MessageString = "離開時會一併關閉代理執行之系統，是否確定關閉系統"
            Else
                MessageString = "是否確定關閉系統"
            End If
            Dim Result As DialogResult = MessageHandling.ShowQuestionMsg("CMMCMMB300", New String() {MessageString})
            If Result = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            Else
                Dim retInt As Integer = ArmServiceManager.getInstance.updateLogoutDateBySystem(ModForm.SystemNo, loginDate, AppContext.userProfile.userIP, AppContext.userProfile.userId, agentCode, Environment.MachineName)
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '啟動APPIdleTime 計時器
            appIdleTime = AppContext.userProfile.appIdleTime
            Me.TimerX.Start()
            '自動載入我的最愛 add on 2012-09-24 by Lits--------------------------------------
            Try
                Dim myComputer As New Computer
                Dim configFile As String = myComputer.FileSystem.SpecialDirectories.MyDocuments & "\" & AppContext.userProfile.userId & "\Def\Default.xml"
                If Directory.Exists(myComputer.FileSystem.SpecialDirectories.MyDocuments & "\" & AppContext.userProfile.userId & "\Def") = False Then
                    Directory.CreateDirectory(myComputer.FileSystem.SpecialDirectories.MyDocuments & "\" & AppContext.userProfile.userId & "\Def\")
                End If
                LoadProfileDefault(configFile)

            Catch cmex As CommonException
                Throw cmex
            Catch ex As Exception
                Throw New CommonException("CMMCMMD001", ex)
            End Try
            
            'End If
           
            menuItemDockingWindow.Enabled = False

            menuItemDockingSdi.Enabled = False
            menuItemSystemMdi.Enabled = False
            'InitSelectTree()
            MenuTreeView()
            'dockPanel.LoadFromXml("c:\TempFile\D2", m_deserializeDockContent)
            toolBar.Visible = False
            setDocumentIcon()

            showNFCReader()

            loginDate = Now.ToString("yyyy/MM/dd HH:mm:ss.fff")
            If AppContext.userProfile.agentId <> "unknown" Then
                agentCode = AppContext.userProfile.agentId
            End If
            If ModForm.SystemNo.ToUpper.Trim = "" Then
                ModForm.SystemNo = "OPD"
            End If
            Dim retInt As Integer = ArmServiceManager.getInstance.insertLogonDateBySystem(ModForm.SystemNo, loginDate, AppContext.userProfile.userIP, AppContext.userProfile.userId, agentCode, Environment.MachineName)
            
            Me.Text = "認證授權系統"
            ''*********************************
            getDeployMessage() 'Deploy NotifyWindow

            Me.LogonInfo.Text = "單位:" & AppContext.userProfile.userDeptName & "  登入者:" & AppContext.userProfile.userName & "(" & AppContext.userProfile.userIP & ")  登入時間: " & DateUtil.TransDateToROC(Now.Date) & " " & Now.ToString("HH:mm:ss") & "  " & DisplayCurrentVersion()
            AppContext.userProfile.userOnStationNo = queryIpBystation(AppContext.userProfile.userIP)
            
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If AppContext.userProfile.agentId <> "unknown" Then
                Me.Text = String.Format("{0} ({1}  代理人 {2})", Me.titleWord, AppContext.userProfile.userName, AppContext.userProfile.agentName)
            Else
                Me.Text = String.Format("{0} ({1})", Me.titleWord, AppContext.userProfile.userName)
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub About()
        Try
            Dim aboutDialog As New AboutDialog()
            aboutDialog.ShowDialog(Me)
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Function FindDocument(ByVal text As String) As IDockContent
        Try
            If dockPanel.DocumentStyle = DocumentStyle.SystemMdi Then
                For Each form As Form In MdiChildren
                    If form.Text = text Then
                        Return TryCast(form, IDockContent)
                    End If
                Next
                Return Nothing
            Else
                For Each content As IDockContent In dockPanel.Contents
                    If content.DockHandler.TabText = text Then
                        Return content
                    End If
                Next
                Return Nothing
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Private Function MenuFindDocument(ByVal text As String) As IDockContent
        Try
            If dockPanel.DocumentStyle = DocumentStyle.SystemMdi Then
                For Each form As Form In Me.ParentForm.MdiChildren
                    If form.Text = text Then
                        Return TryCast(form, IDockContent)
                    End If
                Next
                Return Nothing
            Else
                For Each content As IDockContent In dockPanel.Contents '.Documents
                    If content.GetType().ToString = text Then
                        Return content
                    End If
                Next
                Return Nothing
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Private Function GetContentFromPersistString(ByVal persistString As String) As IDockContent
        Try
            Dim parsedStrings As String() = persistString.Split(New Char() {","c})
            If parsedStrings.Length <> 3 Then
                Return Nothing
            End If

            Dim dummyDoc As DockContent = ModForm.getFormObjectByDllAndClass(parsedStrings(1), parsedStrings(0))
            If dummyDoc IsNot Nothing Then
                If parsedStrings(2) <> String.Empty Then
                    dummyDoc.Text = parsedStrings(2)
                    dummyDoc.TabText = parsedStrings(2)
                End If
            End If

            Return dummyDoc
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function


    Private Sub showNFCReader()
        Try
            '顯示訊息通知 Dock 在右邊,自動隱藏
            Dim dockNFC As DockContent = ModForm.getFormObjectByDllAndClass("Syscom.Client.NFC.dll", "Syscom.Client.NFC.NFCDataReader")
            CType(dockNFC, Syscom.Client.NFC.NFCDataReader).Text = "訊息通知"
            CType(dockNFC, Syscom.Client.NFC.NFCDataReader).TabText = "訊息通知"
            If MenuFindDocument("Syscom.Client.NFC.NFCDataReader") IsNot Nothing Then
                MessageHandling.ShowInfoMsg("訊息通知 " & " 已經開啟!")
                Exit Sub
            End If
            dockPanel.Width = 300
            dockNFC.Show(dockPanel, DockState.DockRightAutoHide)
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub


    Private Sub CloseAllContents()
        closeAllDockPanel()
    End Sub

    Private Sub setDocumentIcon()
        dockPanel.ShowDocumentIcon = InlineAssignHelper(True, True)
    End Sub

    Private Sub showRightToLeftToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showRightToLeft.Click
        'CloseAllContents()
        'If showRightToLeft.Checked Then
        '    Me.RightToLeft = RightToLeft.No
        '    Me.RightToLeftLayout = False
        'Else
        '    Me.RightToLeft = RightToLeft.Yes
        '    Me.RightToLeftLayout = True
        'End If
        'showRightToLeft.Checked = Not showRightToLeft.Checked
    End Sub

    Private Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

    Public Sub SaveProfile()
        Try
            '儲存個人化設定檔
            Dim configFile As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), UserInfo.getUserName & "-Profile.config")
            dockPanel.SaveAsXml(configFile)
            SaveUserProfile(configFile, "N")
            MessageHandling.ShowInfoMsg("個人化設定儲存成功：" & UserInfo.getUserName & "-Profile.config")
            'Close()
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Public Sub SaveProfile(ByVal configFile As String, ByVal defFlag As String)
        Try
            '儲存個人化設定檔
            dockPanel.SaveAsXml(configFile)
            SaveUserProfile(configFile, defFlag)
            MessageHandling.ShowInfoMsg("我的最愛儲存成功!")
            'Close()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub SaveUserProfile(ByVal configFile As String, ByVal defFlag As String)
        Dim streamReader As StreamReader = New StreamReader(configFile)
        Dim contents As String = streamReader.ReadToEnd()
        streamReader.Close()

        Dim msLocationTmp() As String
        Dim msLocation As String = ""
        Dim msType As String = ""
        Dim msDescription As String = ""
        Dim newStr As String = ""
        Dim newContents As String = ""
        Dim newWriter As StreamWriter = New StreamWriter(configFile, False, EncodingUtil.unicodeEncoder)

        Try
            For Each content As IDockContent In Me.dockPanel.Contents '.Documents
                msType = content.GetType().ToString
                msLocationTmp = Split(content.GetType().Assembly.Location, "\")
                msLocation = msLocationTmp(msLocationTmp.Length - 1)
                msDescription = content.DockHandler.TabText
                newStr = msType & "," & msLocation & "," & msDescription

                If contents.IndexOf(msType) > 0 Then
                    '特別指定我的病人,因為它不再Menu選單
                    If msType = "NIS.Client.UCL.NISUCLMyPatientUI" OrElse msType = "syscom.client.nfc.NFCDataReader" OrElse checkIsMenuTree(msDescription) Then '判斷是否menu選單程式
                        newContents = contents.Replace(msType, newStr)
                        contents = newContents
                    End If
                End If

            Next

            If newContents = "" Then
                newWriter.Close()
                File.Delete(configFile)
            Else
                '寫入資料庫
                Try

                    ArmServiceManager.getInstance.insertProfile(genProfileXML(Path.GetFileName(configFile), contents, defFlag))

                Catch ex As Exception
                    Throw ex
                End Try


                newWriter.Write(newContents, True, EncodingUtil.unicodeEncoder)
                newWriter.Close()
                If defFlag = "Y" Then
                    Dim targetFile As String = Path.GetDirectoryName(configFile) & "\def\Default.xml"
                    File.Copy(configFile, targetFile, True)
                End If
                File.Delete(configFile)
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub closeAllDockPanel()
        Try
            Dim dockCount As Integer = 0
            dockCount = dockPanel.Contents.Count
            For dockCount = 1 To dockCount
                CType(dockPanel.Contents(0), Form).Close()
            Next
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub setLogonStyle(ByRef newStyle As DocumentStyle)
        Try
            dockPanel.DocumentStyle = newStyle
            menuItemDockingMdi.Checked = (newStyle = DocumentStyle.DockingMdi)
            menuItemDockingWindow.Checked = (newStyle = DocumentStyle.DockingWindow)
            menuItemDockingSdi.Checked = (newStyle = DocumentStyle.DockingSdi)
            menuItemSystemMdi.Checked = (newStyle = DocumentStyle.SystemMdi)
            toolBarButtonLayoutByXml.Enabled = (newStyle <> DocumentStyle.SystemMdi)
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub LoadProfile()
        Try
            Dim configFile As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), UserInfo.getUserName & "-Profile.config")
            If File.Exists(configFile) Then
                dockPanel.SuspendLayout(True)
                'CloseAllContents()
                dockPanel.LoadFromXml(configFile, m_deserializeDockContent)
            Else
                MessageBox.Show("找不到個人化設定檔！", "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub LoadProfile(ByVal configFile As String)
        Try
            Dim newWriter As StreamWriter = New StreamWriter(configFile, False, EncodingUtil.unicodeEncoder)
            If File.Exists(configFile) Then
                'dockPanel.SuspendLayout(True)
                CloseAllContents()
                Try
                    Dim ds As DataSet = ArmServiceManager.getInstance.queryProfileByPk(ModForm.SystemNo, AppContext.userProfile.userId, Path.GetFileName(configFile))
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim st As String = ds.Tables(0).Rows(0).Item("Sub_Xml").ToString.Trim
                        newWriter.Write(st, True, EncodingUtil.unicodeEncoder)
                        newWriter.Close()
                    End If
                    dockPanel.LoadFromXml(configFile, m_deserializeDockContent)
                    'add on 2013-0624 By Lits 載入我的最愛超過兩個頁簽Focus 在第一個
                    If dockPanel.Contents.Count > 1 Then
                        For Each content As IDockContent In dockPanel.Contents
                            content.DockHandler.DockPanel.Documents.First.DockHandler.Show()
                            Exit Sub
                        Next
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

            Else
                MessageBox.Show("找不到個人化設定檔！", "警告訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    '啟動自動載入預設值
    Private Sub LoadProfileDefault(ByVal configFile As String)
        Dim newWriter As StreamWriter = Nothing

        Try
            Dim st As String = ""
            Dim isDef As String = ""
            Dim ds As DataSet = ArmServiceManager.getInstance.queryProfile(ModForm.SystemNo, AppContext.userProfile.userId, "Y")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables(0).Rows
                    st = row.Item("Sub_Xml").ToString.Trim
                    isDef = row.Item("Is_Default").ToString.Trim
                    If isDef = "Y" Then
                        newWriter = New StreamWriter(configFile, False, EncodingUtil.unicodeEncoder)
                        CloseAllContents()
                        newWriter.Write(st, True, EncodingUtil.unicodeEncoder)
                        newWriter.Close()
                        dockPanel.LoadFromXml(configFile, m_deserializeDockContent)
                        'add on 2013-0624 By Lits 載入我的最愛超過兩個頁簽Focus 在第一個
                        If dockPanel.Contents.Count > 1 Then
                            For Each content As IDockContent In dockPanel.Contents
                                content.DockHandler.DockPanel.Documents.First.DockHandler.Show()
                                Exit Sub
                            Next
                        End If
                        Exit Sub
                    End If
                Next
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub setBlackColor()
        Try
            Dim MyDialog As New ColorDialog()
            MyDialog.AllowFullOpen = True
            MyDialog.ShowHelp = False
            If (MyDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                ColorUtil.RedColor = MyDialog.Color.R
                ColorUtil.GreenColor = MyDialog.Color.G
                ColorUtil.BlueColor = MyDialog.Color.B

                Dim dockCount As Integer = 0
                dockCount = dockPanel.Contents.Count
                For dockCount = 1 To dockCount
                    CType(dockPanel.Contents(dockCount - 1), Form).BackColor = System.Drawing.Color.FromArgb(ColorUtil.RedColor, ColorUtil.GreenColor, ColorUtil.BlueColor)
                Next
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub


    '設定字型
    Private Sub setFont()
        Dim fontDiaglog As New FontDialog
        Dim dockCount As Integer = 0
        dockCount = dockPanel.Contents.Count

        If (fontDiaglog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            _fontName = fontDiaglog.Font.Name
            _fontSize = fontDiaglog.Font.Size
            _fontStyle = fontDiaglog.Font.Style
            For dockCount = 0 To dockCount - 1
                '2015-05-15 Modify By Alan-加入依解析度自動調整畫面字體
                If UCLFormUtil.isResizeable Then
                    CType(dockPanel.Contents(dockCount), Form).Font = New System.Drawing.Font(UCLFormUtil.gblFont, InitFontSize)
                Else
                    CType(dockPanel.Contents(dockCount), Form).Font = New System.Drawing.Font(_fontName, _fontSize, _fontStyle, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
                End If

            Next
        End If
    End Sub
    '設定字型
    Private Sub _setFont()
        Dim fontDiaglog As New FontDialog
        Dim dockCount As Integer = 0
        dockCount = dockPanel.Contents.Count

        For dockCount = 0 To dockCount - 1
            '2015-05-15 Modify By Alan-加入依解析度自動調整畫面字體
            If UCLFormUtil.isResizeable Then
                CType(dockPanel.Contents(dockCount), Form).Font = New Font(UCLFormUtil.gblFont, InitFontSize)
            Else
                CType(dockPanel.Contents(dockCount), Form).Font = getScreenBoubdsFont()
            End If
            ' New System.Drawing.Font(fontDiaglog.Font.Name, fontDiaglog.Font.Size, fontDiaglog.Font.Style, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Next

    End Sub
    '取得螢幕解析度
    Function getScreenBoubdsFont() As System.Drawing.Font
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Try
            Return New System.Drawing.Font(_fontName, InitFontSize, _fontStyle, System.Drawing.GraphicsUnit.Point, CType(136, Byte))

        Catch ex As Exception
            Return New System.Drawing.Font("新細名體", 12, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        End Try

    End Function
    Function InitFontSize() As Integer
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Try
            Select Case screenWidth
                Case 1024
                    Return 12
                Case 1280
                    Return 12
                Case 1366
                    Return 12
                Case 1400
                    Return 14
                Case 1600
                    Return 14
                Case 1920
                    Return 16
                Case Else
                    Return 12
            End Select
        Catch ex As Exception
            Return 12
        End Try

    End Function

    Public Sub MenuTreeView()
        '載入Menu Item 選單
        Dim reader As XmlTextReader = Nothing

        Dim attri As String() = Nothing
        Dim level As String = ""
        Dim text As String = ""
        Dim tag As String = ""
        Dim subno As String = ""
        Dim tskno As String = ""
        Dim funno As String = ""
        Dim systemObj As String() = Nothing
        Dim count As Integer = 3

        '2015-05-15 Modify By Alan-加入依解析度自動調整畫面字體
        If UCLFormUtil.isResizeable Then
            ms.Font = New System.Drawing.Font(UCLFormUtil.gblFont, InitFontSize, Nothing, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Else
            ms.Font = New System.Drawing.Font("新細名體", 12, Nothing, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        End If


        Try
            ' disabling re-drawing of treeview till all nodes are added

            reader = New XmlTextReader("AuthList" & AppContext.userProfile.userId & ".xml")

            Dim parentNode As TreeNode = Nothing

            While reader.Read()
                If reader.NodeType = XmlNodeType.Element Then
                    If reader.Name.ToUpper = "TREEVIEW" Then
                        reader.MoveToAttribute(0)
                        Me.titleWord = reader.Value.ToString
                    End If
                    '取得system 選單
                    If reader.Name.ToUpper = "SYSTEM" Then
                        ReDim systemObj(reader.AttributeCount - 1)
                        For j As Integer = 0 To reader.AttributeCount - 1
                            reader.MoveToAttribute(j)
                            systemObj(j) = reader.Value.ToUpper
                        Next
                        setSystemMenu(systemObj)

                        '加入分隔
                        windowMenu.DropDownItems.Insert(reader.AttributeCount - 1, New ToolStripSeparator)
                    End If
                    '=====================================================
                    If reader.Name = XmlNodeTag Then
                        Dim newNode As New TreeNode()
                        Dim isEmptyElement As Boolean = reader.IsEmptyElement

                        '載入節點屬性
                        Dim attributeCount As Integer = reader.AttributeCount
                        ReDim attri(attributeCount)
                        For i As Integer = 0 To attributeCount - 1
                            reader.MoveToAttribute(i)
                            attri(i) = reader.Value.ToString
                        Next

                        level = attri(0).ToString
                        text = attri(1).ToString
                        tag = attri(3).ToString
                        subno = attri(4).ToString
                        tskno = attri(5).ToString
                        funno = attri(6).ToString

                        If level = "0" Then
                            windowMenu1 = New ToolStripMenuItem(text, Nothing, New EventHandler(AddressOf windowNewMenu0_Click))
                            windowMenu1.Tag = tag
                            windowMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {windowMenu1})
                        ElseIf level = "1" Then
                            windowMenu2 = New ToolStripMenuItem(text, Nothing, New EventHandler(AddressOf windowNewMenu1_Click))
                            windowMenu2.Tag = tag
                            windowMenu1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {windowMenu2})
                        ElseIf level = "2" Then
                            windowMenu3 = New ToolStripMenuItem(text, Nothing, New EventHandler(AddressOf windowNewMenu_Click))
                            windowMenu3.Tag = tag
                            windowMenu3.ToolTipText = subno & "," & tskno & "," & funno
                            windowMenu2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {windowMenu3})

                            If tag = "PCSUCL.dll,nckuh.client.pcsucl.PCSUCLMSReportViewer" And attri.Length >= 5 Then
                                windowMenu3.Tag = String.Format("{0};{1}", tag, attri(4).ToString)
                            End If
                        End If
                    End If
                End If
            End While
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            reader.Close()
        End Try
        setAboutWindow()
    End Sub

    Private Sub setAboutWindow()
        Try
            '設定關於,關閉視窗MenuItem
            windowMenu = New ToolStripMenuItem("視窗檢視") 'Menu頭
            'windowMenu1 = New ToolStripMenuItem("相關查詢作業", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu.DropDownItems.Add(windowMenu1)
            windowMenu1 = New ToolStripMenuItem("設定字型", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            windowMenu.DropDownItems.Add(windowMenu1)
            windowMenu1 = New ToolStripMenuItem("關閉所有視窗", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu1 = New ToolStripMenuItem("鎖定視窗", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu1 = New ToolStripMenuItem("檢查版本", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu1 = New ToolStripMenuItem("癌症診療指引", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu1 = New ToolStripMenuItem("治療計劃書", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu1 = New ToolStripMenuItem("AJCC分期工具", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu1 = New ToolStripMenuItem("問題反應")
            'windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu2 = New ToolStripMenuItem("住院問題反應", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu1.DropDownItems.Add(windowMenu2)
            'windowMenu1 = New ToolStripMenuItem("操作說明")
            'windowMenu2 = New ToolStripMenuItem("新住院系統操作說明", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu1.DropDownItems.Add(windowMenu2)
            windowMenu.DropDownItems.Add(windowMenu1)
            ms.MdiWindowListItem = windowMenu
            ms.Items.Add(windowMenu)
            Me.MainMenuStrip = ms
            Me.Controls.Add(ms)
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub showVersionInfo()
        Try
            '啟動版本資訊查詢 by Lits on 2010-07-01
            Dim dockShowVersionInfo As DockContent = ModForm.getFormObjectByDllAndClass("Client.PUB.dll", "Syscom.Client.UCL.PUBSystemVersionUI")
            CType(dockShowVersionInfo, Syscom.Client.UCL.PUBSystemVersionUI).Text = "版本資訊"
            CType(dockShowVersionInfo, Syscom.Client.UCL.PUBSystemVersionUI).TabText = "版本資訊"
            If MenuFindDocument("Syscom.Client.UCL.PUBSystemVersionUI") IsNot Nothing Then
                MessageHandling.ShowInfoMsg("版本資訊 " & " 已經開啟!")
                Exit Sub
            End If
            dockShowVersionInfo.Show(dockPanel)
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub


    Function displayMessageBar(ByVal s As String) As Object
        Me.MsgStatus.Text = s
        Return Nothing
    End Function

    Private Sub LockWindow()
        Try
            Me.Hide()
rep:        Using loginForm As New LoginForm()

                '鎖定螢幕 - For 我的病人
                eventManager.RaiseAPPLockWindow("True")

                loginForm.UsernameTextBox.Text = ModForm.UserInfo
                loginForm.UsernameTextBox.Enabled = False
                loginForm.Text = String.Format("使用者: {0} 鎖定畫面 - 輸入正確密碼後才能啟用", ModForm.UserInfo)
                loginForm.PasswordTextBox.Focus()
                loginForm.ShowDialog()
                loginForm.BringToFront()

                If loginForm.DialogResult = DialogResult.OK Then
                    If loginForm.PasswordTextBox.Text = ModForm.PasswdInfo Then
                        UnLockWindow()

                        '解除鎖定螢幕 - For 我的病人
                        eventManager.RaiseAPPLockWindow("False")

                    Else
                        MessageHandling.ShowErrorMsg("密碼錯誤!")
                        GoTo rep
                    End If
                Else
                    Application.Exit()
                End If
            End Using
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub UnLockWindow()
        Me.Show()
    End Sub

    Public Function DisplayCurrentVersion() As String
        Dim CurrentVersion As String = ""
        Try
            If ApplicationDeployment.IsNetworkDeployed Then
                CurrentVersion = "版本:V" & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
            End If
            Return CurrentVersion
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#Region "Menu相關動作"
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

    Private Sub windowNewMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            gcTEST()
            '設定第0層(Root)MenuItem 點選事件
            

            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "訊息通知" Then
                Me.showNFCReader()
                Exit Sub
            End If

            'If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "載入個人化設定" Then LoadProfile() : Exit Sub

            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "我的最愛" Then MyFavorites() : Exit Sub
            'If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "系統版本更新記錄查詢" Then showVersionInfo() : Exit Sub

            'add on 2012-05-10 by Lits for 急診切換使用者--------------------------------
            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "切換使用者" Then
                SwitchUser()
                Exit Sub
            End If

            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "登出" Then
                Me.Dispose(False)
                Exit Sub
            End If

            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "結束" Then
                Me.Dispose(True)
                Exit Sub
            End If

            'If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "關於" Then About() : Exit Sub
            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "關閉所有視窗" Then closeAllDockPanel() : Exit Sub
            'If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "鎖定視窗" Then LockWindow() : Exit Sub
            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "設定字型" Then
                'setFont()
                Exit Sub
            End If

            'If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "檢查版本" Then
            '    checkVersion()
            '    Exit Sub
            'End If


            Dim item As String = DirectCast(sender, ToolStripMenuItem).Text.ToUpper()
            Dim tag As String = ""

            Try
                tag = DirectCast(sender, ToolStripMenuItem).Tag.ToString
                If tag = "" Then
                    Exit Sub
                End If
            Catch ex As Exception
                MessageHandling.ShowErrorMsg(item & " 執行錯誤")
            End Try

            Dim tagStrings As String() = tag.Split(New Char() {","c})
            If tagStrings.Length <> 2 Then
                Exit Sub
            End If

            'If tagStrings(1).StartsWith("nckuh.client.pcsucl.PCSUCLMSReportViewer;") Then
            '    Dim temp As String() = tagStrings(1).Split(New Char() {";"c})

            '    Dim myForm As DockContent = ModForm.getFormObjectByDllAndClass(tagStrings(0), temp(0))
            '    If myForm Is Nothing Then
            '        MessageHandling.ShowErrorMsg("找不到元件: " & tag)
            '        Exit Sub
            '    End If
            '    myForm.Text = item
            '    myForm.TabText = item
            '    myForm.Tag = temp(1)
            '    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            '    myForm.Show(dockPanel)
            '    Me.Cursor = System.Windows.Forms.Cursors.Default
            '    Exit Sub
            'End If

            Dim isDockShow As DockContent = CType(MenuFindDocument(tagStrings(1)), Com.Syscom.WinFormsUI.Docking.DockContent)
            If isDockShow IsNot Nothing And tagStrings(0) <> "Dummy.dll" Then
                isDockShow.Show()

                MessageHandling.ShowInfoMsg("CMMCMMB300", New String() {item & "-已經開啟"})
                Exit Sub
            End If


            'Dim dockForm As DockContent = ModForm.getFormObjectByClass(tag)
            Dim dockForm As DockContent = ModForm.getFormObjectByDllAndClass(tagStrings(0), tagStrings(1))
            If dockForm Is Nothing Then
                MessageHandling.ShowErrorMsg("找不到元件: " & tag)
                Exit Sub
            End If

            dockForm.Text = item
            dockForm.TabText = item

            'add on 2014-12-10 By Lits 新增點擊作業紀錄================================
            Dim _systemName() As String = DirectCast(sender, ToolStripMenuItem).ToolTipText.Split(",")
            Dim dsRecord As DataSet = genFunRecordDS(_systemName(0), _systemName(2), item)
            ArmServiceManager.getInstance.insertFunRecord(dsRecord)
            '==========================================================================
            dockForm.Tag = _systemName(0) & "," & _systemName(1) & "," & _systemName(2)
            If dockPanel.DocumentStyle = DocumentStyle.SystemMdi Then
                dockForm.MdiParent = SyscomAPP.MainForm.ActiveForm
                dockForm.Show()
            Else
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                dockForm.Show(dockPanel) 'Com.Syscom.WinFormsUI.Docking.DockState.Float)
                'dockForm.BackColor = System.Drawing.Color.FromArgb(_R, _G, _B)
                Me.Cursor = System.Windows.Forms.Cursors.Default
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Function setSystemMenu(ByVal obj() As String) As Object
        Try
            windowMenu = New ToolStripMenuItem(obj(0).ToString, imageList.Images(0)) 'Menu 標頭
            ms.MdiWindowListItem = windowMenu
            ms.Items.Add(windowMenu)
            ms.Dock = DockStyle.Top
            Me.MainMenuStrip = ms
            Me.Controls.Add(ms)
            For k As Integer = 1 To obj.Length - 1
                windowMenu1 = New ToolStripMenuItem(obj(k), Nothing, New EventHandler(AddressOf windowNewMenu_Click))
                windowMenu.DropDownItems.Add(windowMenu1)
            Next
            Return Nothing
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Private Sub reMoveMenuItem()
        Try
            '移除上面選單(除了系統選單之外)
            For i As Integer = ms.Items.Count - 1 To 0 Step -1
                If ms.Items(i).Text.Equals("系統功能") Then
                    Exit For
                Else
                    ms.Items.RemoveAt(i)
                End If
            Next
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub windowNewMenu0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '設定第一層MenuItem 點選事件
        reMoveMenuItem()
        Dim name As String = DirectCast(sender, ToolStripMenuItem).Name
        Dim item As String = DirectCast(sender, ToolStripMenuItem).Text.ToUpper()
        Dim tag As String = ""
        Dim menuItem As ToolStripItem = DirectCast(sender, ToolStripItem)

        Try
            tag = DirectCast(sender, ToolStripMenuItem).Tag.ToString
            For i As Integer = 0 To DirectCast(sender, ToolStripMenuItem).DropDownItems.Count - 1
                menuItem = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i)
                If i < 5 Then
                    windowMenu = New ToolStripMenuItem(DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu頭
                    windowMenu.Tag = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Tag
                    windowMenu.ToolTipText = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).ToolTipText
                    ms.Items.Add(windowMenu)

                    For j As Integer = 0 To DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Count - 1
                        windowMenu1 = New ToolStripMenuItem(DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Item(j).Text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu頭
                        windowMenu1.Tag = DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Item(j).Tag
                        windowMenu1.ToolTipText = DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Item(j).ToolTipText
                        windowMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {windowMenu1})
                    Next
                Else
                    If i = 5 Then
                        windowMenu = New ToolStripMenuItem("其餘項目", imageList.Images(0)) 'Menu 標頭
                        ms.MdiWindowListItem = windowMenu
                        ms.Items.Add(windowMenu)


                    End If
                    windowMenu1 = New ToolStripMenuItem(DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu頭
                    windowMenu1.Tag = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Tag
                    windowMenu1.ToolTipText = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).ToolTipText
                    windowMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {windowMenu1})

                    For j As Integer = 0 To DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Count - 1
                        windowMenu2 = New ToolStripMenuItem(DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Item(j).Text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu頭
                        windowMenu2.Tag = DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Item(j).Tag
                        windowMenu2.ToolTipText = DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Item(j).ToolTipText
                        windowMenu1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {windowMenu2})
                    Next
                End If
            Next
            setAboutWindow()
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub windowNewMenu1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '設定第一層MenuItem 點選事件
        reMoveMenuItem()
        Dim name As String = DirectCast(sender, ToolStripMenuItem).Name
        Dim item As String = DirectCast(sender, ToolStripMenuItem).Text.ToUpper()
        Dim tag As String = ""
        Try
            tag = DirectCast(sender, ToolStripMenuItem).Tag.ToString
            For i As Integer = 0 To DirectCast(sender, ToolStripMenuItem).DropDownItems.Count - 1

                If i < 5 Then
                    windowMenu = New ToolStripMenuItem(DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu頭
                    windowMenu.Tag = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Tag
                    windowMenu.ToolTipText = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).ToolTipText
                    ms.Items.Add(windowMenu)
                Else
                    If i = 5 Then
                        windowMenu = New ToolStripMenuItem("其餘項目", imageList.Images(0)) 'Menu 標頭
                        ms.MdiWindowListItem = windowMenu
                        ms.Items.Add(windowMenu)

                    End If
                    windowMenu1 = New ToolStripMenuItem(DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu頭
                    windowMenu1.Tag = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Tag
                    windowMenu1.ToolTipText = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).ToolTipText
                    windowMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {windowMenu1})
                End If
            Next
            setAboutWindow()
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub RoleMenu(ByVal parmItem As String)
        reMoveMenuItem()
        '載入Menu Item 選單
        Dim reader As XmlTextReader = Nothing
        Dim attri As String() = Nothing
        Dim level As String = ""
        Dim text As String = ""
        Dim tag As String = ""
        'Dim systemObj As String() = Nothing
        Dim count As Integer = 3
        Dim cnt As Integer = 0
        Dim flag As Boolean = False

        Try
            reader = New XmlTextReader("AuthList" & AppContext.userProfile.userId & ".xml")
            Dim parentNode As TreeNode = Nothing
            While reader.Read()
                If reader.NodeType = XmlNodeType.Element Then

                    '=====================================================
                    If reader.Name = "node" Then
                        Dim newNode As New TreeNode()
                        Dim isEmptyElement As Boolean = reader.IsEmptyElement

                        '載入節點屬性
                        Dim attributeCount As Integer = reader.AttributeCount
                        ReDim attri(attributeCount)
                        For i As Integer = 0 To attributeCount - 1
                            reader.MoveToAttribute(i)
                            attri(i) = reader.Value.ToString
                        Next

                        level = attri(0).ToString
                        text = attri(1).ToString
                        tag = attri(3).ToString
                        If level = "0" Then
                            If text = parmItem Then
                                flag = True
                            Else
                                flag = False
                            End If
                        End If

                        If flag = True Then
                            If level = "0" Then
                                If cnt > 0 Then
                                    Exit Sub
                                End If
                                cnt = cnt + 1
                            ElseIf level = "1" Then
                                windowMenu = New ToolStripMenuItem(text, Nothing) 'Menu 標頭
                                ms.MdiWindowListItem = windowMenu
                                ms.Items.Add(windowMenu)
                            ElseIf level = "2" Then
                                windowMenu1 = New ToolStripMenuItem(text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu頭
                                windowMenu1.Tag = tag
                                windowMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {windowMenu1})
                            End If
                        End If
                    End If
                End If
            End While
            setAboutWindow()
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            reader.Close()
        End Try
    End Sub
#End Region



#Region "15分鐘自動登出"

    Private Declare Function GetLastInputInfo Lib "User32.dll" _
    (ByRef lastInput As LASTINPUTINFO) As Boolean

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure LASTINPUTINFO
        Public cbSize As Int32
        Public dwTime As Int32
    End Structure

    ''' <summary>
    ''' Get idle time in second.
    ''' </summary>
    ''' <value>idle time.</value>
    ''' <returns></returns>
    ''' <author>Ken</author>
    ''' <date>2011-11-17</date>
    ''' <remarks></remarks>
    Public ReadOnly Property IdleTime() As Integer
        Get
            Dim lastInput As New LASTINPUTINFO
            lastInput.cbSize = Marshal.SizeOf(lastInput)
            If GetLastInputInfo(lastInput) Then
                Return CInt((Environment.TickCount - lastInput.dwTime) / 1000)
            Else
                Return 0
            End If
        End Get
    End Property

    Private Sub TimerX_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerX.Tick
        Try
            ''**********************************************************************************************************************
            '' Modified by Sean
            ''**********************************************************************************************************************

            ''如果是護理人員30分鐘才鎖定
            'If globalNurseFlag Then

            '    '超過30分鐘，登出
            '    If Me.IdleTime >= (30 * 60) Then

            '        'Me.LockWindow()
            '        eventManager.RaiseSwitchUserEvent()

            '    End If

            '    '五分鐘查詢未簽收醫囑，因為每0.1秒跳一次，所以要*10
            '    If globalNurseSignTip >= (1 * 60 * 10) Then

            '        '取得醫囑未簽收資料
            '        ' MessageBox.Show("test" & Now.ToString)
            '        globalNurseSignTip = 0

            '    Else

            '        globalNurseSignTip = globalNurseSignTip + 1

            '    End If

            'ElseIf Me.IdleTime >= (15 * 60) Then

            '    'Me.LockWindow()
            '    eventManager.RaiseSwitchUserEvent()


            'End If

            ''**********************************************************************************************************************

            '30 分鐘登出 By Sean 暫時關掉2015-09-26-Lits
            Try
                displayMessageBar("閒置時間約：" & (CInt(Me.IdleTime / 60)).ToString & "分")
                If Me.IdleTime >= (appIdleTime * 60) Then
                    'Me.TimerX.Stop()
                    Dim retInt As Integer = ArmServiceManager.getInstance.updateLogoutDateBySystem(ModForm.SystemNo, loginDate, AppContext.userProfile.userIP, AppContext.userProfile.userId, agentCode, Environment.MachineName)
                    '刪除暫存檔User.txt
                    Dim UserFile As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\User.txt"
                    If File.Exists(UserFile) Then
                        File.Delete(UserFile)
                    End If
                    Dim AppProcessID As Integer = AppReadProcessID()
                    killAppProcess(AppProcessID)
                End If
            Catch ex As Exception
                Exit Sub
            End Try
            

        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally

            'Restart timer.
            'Me.TimerX.Start()
        End Try
    End Sub

#End Region

#Region "add on 2012-05-10 by Lits for 急診切換使用者"

    Private Sub SwitchUser()
        Try
            Dim loginForm As New SwitchUserUI()
            loginForm.Text = "切換使用者: "
            loginForm.PasswordTextBox.Focus()
            loginForm.ShowDialog()
            If loginForm.flag <> "" AndAlso loginForm.flag <> "N" Then
                closeAllDockPanel()
                ClearMenuItem()
                reLoad()
                If AppContext.userProfile.userMemberOf.Contains("'PCS_DR'") Then
                    'showEMOPatientList()
                End If
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    'add on 2012-05-10 by Lits for 切換使用者
    Private Sub reLoad()
        Try
            
            menuItemDockingWindow.Enabled = False
            menuItemDockingSdi.Enabled = False
            menuItemSystemMdi.Enabled = False
            'InitSelectTree()
            MenuTreeView()
            toolBar.Visible = False
            setDocumentIcon()
            showNFCReader()
            'Activate TimerX (added on 2011-11-17 by Ken)
            'Me.TimerX.Start()

            'Dim retInt As Integer = Syscom.Client.Servicefactory.ArmServiceManager.getInstance.insertLogonDateBySystem(ModForm.SystemNo, AppContext.userProfile.userIP, AppContext.userProfile.userId)


            '**********************************************************************************************
            '204-02-06 Sean Use Log with New Version 
            '**********************************************************************************************
            LOGDelegate.getInstance.fileDebugMsg("結束 MainForm 初始化程式：" & Now.ToString("yyyy-MM-dd HH:mm:ss"))
            '**********************************************************************************************



            Me.Text = String.Format("{0} ({1})", Me.titleWord, ModForm.UserInfoName)
            '登入時自動掛入到選單 on 2012-11-06 by Lits--------
            '判斷是否為護理人員
            '主任說不要預設帶入===============================
            Dim CurrentMenberOf As String = AppContext.userProfile.userMemberOf
            If CurrentMenberOf.Contains("CNC_Admin") Or CurrentMenberOf.Contains("CNC_DP") Or CurrentMenberOf.Contains("CNC_HN") Or CurrentMenberOf.Contains("CNC_MN") _
              Or CurrentMenberOf.Contains("CNC_NP") Or CurrentMenberOf.Contains("CNC_SUP") Or CurrentMenberOf.Contains("CNC_User") Then
                globalNurseFlag = True
            End If
            '護理人員 Dock 在左邊
            If globalNurseFlag Then
                'showDdcMyPatient()
            End If
            '--------------------------------------------------
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub ClearMenuItem()
        Try
            '移除全部上面選單
            For i As Integer = ms.Items.Count - 1 To 0 Step -1
                ms.Items.RemoveAt(i)
            Next
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

#End Region

#Region "add on 2012-09-18 by Lits for 我的最愛"

    Private Sub MyFavorites()
        Try
            MyFavoritesUI.ShowDialog()
            MyFavoritesUI.StartPosition = FormStartPosition.CenterScreen
            'MyFavoritesUI.Location = New System.Drawing.Point(1, 15)

            If MyFavoritesUI.Function_Name = "add" Then
                SaveProfile(MyFavoritesUI.Profile_Name, MyFavoritesUI.Default_Flag)
                Exit Sub

            ElseIf MyFavoritesUI.Function_Name = "run" Then
                LoadProfile(MyFavoritesUI.Profile_Name)
                Exit Sub
            Else
                Exit Sub
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            MyFavoritesUI.Dispose()
        End Try
    End Sub

    Function genProfileXML(ByVal profileName As String, ByVal xml As String, Optional ByVal isDefault As String = "N") As DataSet
        Try
            Dim LAbDB() As String = {"System_No", "Employee_Code", "Sub_File_Name", "Sub_Xml", "is_Default"}
            Dim tableName As String = "arm_Profile"
            Dim armProfileDS As DataSet = Syscom.Comm.Utility.DataSetUtil.GenDataSet(tableName, LAbDB)
            Dim row As DataRow

            row = armProfileDS.Tables(tableName).NewRow
            row("System_No") = ModForm.SystemNo
            row("Employee_Code") = AppContext.userProfile.userId
            row("Sub_File_Name") = profileName
            row("Sub_Xml") = xml
            row("is_Default") = isDefault
            armProfileDS.Tables(tableName).Rows.Add(row)
            Return armProfileDS
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    Function checkIsMenuTree(ByVal txt As String) As Boolean
        '檢查程式是否為Menu 選單程式
        Dim reader As XmlTextReader = Nothing

        Dim attri As String() = Nothing
        Dim level As String = ""
        Dim text As String = ""
        Dim tag As String = ""
        Dim systemObj As String() = Nothing
        Dim count As Integer = 3

        Try
            reader = New XmlTextReader("AuthList" & AppContext.userProfile.userId & ".xml")
            Dim parentNode As TreeNode = Nothing
            While reader.Read()
                If reader.NodeType = XmlNodeType.Element Then
                    If reader.Name.ToUpper = "TREEVIEW" Then
                        reader.MoveToAttribute(0)
                        Me.titleWord = reader.Value.ToString
                    End If

                    '=====================================================
                    If reader.Name = XmlNodeTag Then
                        Dim newNode As New TreeNode()
                        Dim isEmptyElement As Boolean = reader.IsEmptyElement

                        '載入節點屬性
                        Dim attributeCount As Integer = reader.AttributeCount
                        ReDim attri(attributeCount)
                        For i As Integer = 0 To attributeCount - 1
                            reader.MoveToAttribute(i)
                            attri(i) = reader.Value.ToString
                        Next

                        level = attri(0).ToString
                        text = attri(1).ToString
                        tag = attri(3).ToString
                        If text.Equals(txt) Then
                            Return True
                        End If

                    End If
                End If
            End While
            Return False
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            reader.Close()
        End Try
    End Function

#End Region

#Region "Check Version on 2012-11-23 by Lits"

    Private Function checkVersion() As Boolean
        Dim flag As Boolean = False
        Try
            Dim info As UpdateCheckInfo = Nothing
            Dim doUpdate As Boolean = False
            If (ApplicationDeployment.IsNetworkDeployed) Then
                Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

                Try
                    info = AD.CheckForDetailedUpdate()
                Catch dde As DeploymentDownloadException
                    MessageBox.Show("無法在此時更新. " + ControlChars.Lf & ControlChars.Lf & "請檢查網路是否正常. 錯誤: " + dde.Message)
                    Return False
                Catch ioe As InvalidOperationException
                    MessageBox.Show("更新失敗. 錯誤: " & ioe.Message)
                    Return False
                End Try

                If (info.UpdateAvailable) Then
                    doUpdate = True

                    If (Not info.IsUpdateRequired) Then
                        Dim dr As DialogResult = MessageBox.Show("有新的更新,是否現在更新?更新完成將重新啟動", "新醫療系統版本更新", MessageBoxButtons.OKCancel)
                        If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                            doUpdate = False
                        End If
                    Else
                        ' 顯示最小版本.
                        MessageBox.Show("有新的更新  " & _
                            "版本 " & info.MinimumRequiredVersion.ToString() & _
                            ". 更新完成將重新啟動.", _
                            "新醫療系統版本更新", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
                    End If

                    If (doUpdate) Then
                        Try
                            Me.Dispose(False)
                        Catch dde As DeploymentDownloadException
                            MessageBox.Show("無法安裝下載更新應用程式. " & ControlChars.Lf & ControlChars.Lf & "請檢查網路狀況或下次再更新.")
                            Return False
                        End Try
                    End If
                Else
                    MessageBox.Show("檢查沒有新的版本可更新", "新醫療系統版本檢查", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
            Return False
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

#End Region





#Region "add On 20120307 by Lits Deploy NotifyWindow"

    Private Sub TimerDeploy_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDeploy.Tick
        Try
            'getDeployMessage() '檢查發版時間

            UpdateApplication()  ' 自動檢查版本
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub getDeployMessage()
        Dim strDeploy As String = "W"
        Dim user As String = AppContext.userProfile.userId
        Try
            Dim retDS As DataSet = NfcServiceManager.getInstance.QueryDeployByToDay(strDeploy, user)
            If retDS.Tables(0).Rows.Count > 0 AndAlso notifyWindowCount = 0 Then
                notifyWindowCount = 1
                Dim strTitle As String = retDS.Tables(0).Rows(0).Item("Subject").ToString.Trim
                Dim strSub As String = retDS.Tables(0).Rows(0).Item("MsgBody").ToString.Trim
                Dim nw As NotifyWindows = New NotifyWindows(strTitle, strSub)
                nw.SetDimensions(250, 160)
                nw.WaitTime = 1800000
                nw.Font = New System.Drawing.Font("標楷體", 12.0F)
                nw.Notify()
            ElseIf retDS.Tables(0).Rows.Count = 0 Then
                notifyWindowCount = 0
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

#End Region

#Region "add On 20120423 by Lits 非同步Check Version & Update"

    Private sizeOfUpdate As Long = 0
    '紀錄非同步變數
    Dim WithEvents ADUpdateAsync As ApplicationDeployment

    Private Sub UpdateApplication()
        Try
            sizeOfUpdate = 0
            If (ApplicationDeployment.IsNetworkDeployed) Then
                ADUpdateAsync = ApplicationDeployment.CurrentDeployment
                Try
                    ADUpdateAsync.CheckForUpdateAsync()
                Catch cmex As CommonException
                    Throw cmex
                Catch ex As Exception
                    Throw New CommonException("CMMCMMD001", ex)
                End Try
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub ADUpdateAsync_CheckForUpdateProgressChanged(ByVal sender As Object, ByVal e As DeploymentProgressChangedEventArgs) Handles ADUpdateAsync.CheckForUpdateProgressChanged
        'eventManager.RaisDisplayStatusBar(("更新進度:" & [String].Format("{0:D}K of {1:D}K downloaded.", e.BytesCompleted / 1024, e.BytesTotal / 1024)))
    End Sub

    Private Sub ADUpdateAsync_CheckForUpdateCompleted(ByVal sender As Object, ByVal e As CheckForUpdateCompletedEventArgs) Handles ADUpdateAsync.CheckForUpdateCompleted
        Try
            If (e.Error IsNot Nothing) Then
                MessageBox.Show(("ERROR: Could not retrieve new version of the application. Reason: " + ControlChars.Lf + e.Error.Message + ControlChars.Lf + "Please report this error to the system administrator."))
                Return
            Else
                If (e.Cancelled = True) Then
                    MessageBox.Show("The update was cancelled.")
                End If
            End If

            ' Ask the user if they would like to update the application now.
            If (e.UpdateAvailable) Then
                sizeOfUpdate = e.UpdateSizeBytes
                Me.TimerDeploy.Stop()
                'If (Not e.IsUpdateRequired) Then
                '    'Dim dr As DialogResult = MessageBox.Show("有新的版本,是否馬上更新?(建議馬上更新)", "新版本更新", MessageBoxButtons.OKCancel)
                '    'If (System.Windows.Forms.DialogResult.OK = dr) Then
                BeginUpdate()
                '    'End If
                'Else
                '    MessageBox.Show("A mandatory update is available for your application. We will install the update now, after which we will save all of your in-progress data and restart your application.")
                '    BeginUpdate()
                'End If
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub BeginUpdate()
        Try
            ADUpdateAsync = ApplicationDeployment.CurrentDeployment
            ADUpdateAsync.UpdateAsync()
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    Private Sub ADUpdateAsync_UpdateProgressChanged(ByVal sender As Object, ByVal e As DeploymentProgressChangedEventArgs) Handles ADUpdateAsync.UpdateProgressChanged

        'Dim progressText As String = String.Format("{0:D}K out of {1:D}K downloaded - {2:D}% complete", e.BytesCompleted / 1024, e.BytesTotal / 1024, e.ProgressPercentage)
        'eventManager.RaisDisplayStatusBar(("更新進度:" & progressText))
    End Sub

    Private Sub ADUpdateAsync_UpdateCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles ADUpdateAsync.UpdateCompleted
        Try
            If (e.Cancelled) Then
                'MessageBox.Show("The update of the application's latest version was cancelled.")
                Me.TimerDeploy.Start()
                Exit Sub
            Else
                If (e.Error IsNot Nothing) Then
                    MessageBox.Show("錯誤!: 無法安裝最新版本. Reason: " + ControlChars.Lf + e.Error.Message + ControlChars.Lf + "請聯絡資訊室(#2065).")
                    Me.TimerDeploy.Start()
                    Exit Sub
                End If
            End If
            'AsyncUpdateUI.ShowDialog()
            'Me.Dispose(False)
            'Dim dr As DialogResult = MessageBox.Show("新版本下載完成. 請重新登入. (假如不重新登入, 系統將不會執行新的版本,不保證資料正確性.)", "醫療系統重新啟動", MessageBoxButtons.OKCancel)
            'Dim dr As DialogResult = MessageBox.Show("新版本下載完成.點選[確定]醫療系統將重新登入.如果有尚未完成的作業請先存檔後再點選[確定]", "醫療系統重新啟動", MessageBoxButtons.OK)
            Dim dr As DialogResult = MessageBox.Show("新版本下載完成!需要重新啟動後才會生效", "新版本通知", MessageBoxButtons.OK)
            If (dr = System.Windows.Forms.DialogResult.OK) Then
                Me.TimerDeploy.Stop()
                'Me.Dispose(False)
            ElseIf (dr = System.Windows.Forms.DialogResult.Cancel) Then
                Me.TimerDeploy.Start()
            Else

            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#Region "MessageHandling"

    '接取訊息傳遞的Event-Error(WCF專用)
    Public Sub showErrorMsgForWCF(ByVal inErrorCode As String, ByVal inMessage As String, ByVal inDetail As String) Handles eventManager.showErrorMsgForWCF
        Try

            If AppContext.userProfile.userName.ToLower <> "" AndAlso AppContext.userProfile.userName.ToLower <> "unknown" Then
                Dim OpenMessageDlg As New UCLMessageHandlingUI(UCLMessageHandlingUI.STATUS.ERR, inErrorCode, inMessage, inDetail)
                OpenMessageDlg.ShowDialog()
                Me.DialogResult = DialogResult.None
            Else
                MessageBox.Show(inMessage)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '接取訊息傳遞的Event-Error
    Public Sub showErrorMsg(ByVal inErrorCode As String, ByVal inMessage As String(), ByVal inDetail As String) Handles eventManager.showErrorMsg
        If AppContext.userProfile.userName.ToLower <> "" AndAlso AppContext.userProfile.userName.ToLower <> "unknown" Then
            Dim OpenMessageDlg As New UCLMessageHandlingUI(UCLMessageHandlingUI.STATUS.ERR, inErrorCode, inMessage, inDetail)
            OpenMessageDlg.ShowDialog()
            Me.DialogResult = DialogResult.None
        Else
            Dim gblMessage As String
            If inMessage IsNot Nothing AndAlso inMessage.Length <> 0 Then
                gblMessage = MessageValueObject.getMessageValue(inErrorCode, inMessage)
            Else
                gblMessage = MessageValueObject.getMessageValue(inErrorCode)
            End If
            MessageBox.Show(gblMessage)
        End If
    End Sub

    '接取訊息傳遞的Event-Warn
    Public Sub showWarnMsg(ByVal inErrorCode As String, ByVal inMessage As String()) Handles eventManager.showWarnMsg
        If AppContext.userProfile.userName.ToLower <> "" AndAlso AppContext.userProfile.userName.ToLower <> "unknown" Then
            Dim OpenMessageDlg As New UCLMessageHandlingUI(UCLMessageHandlingUI.STATUS.WARN, inErrorCode, inMessage)
            OpenMessageDlg.ShowDialog()
            Me.DialogResult = DialogResult.None
        Else
            Dim gblMessage As String
            If inMessage IsNot Nothing AndAlso inMessage.Length <> 0 Then
                gblMessage = MessageValueObject.getMessageValue(inErrorCode, inMessage)
            Else
                gblMessage = MessageValueObject.getMessageValue(inErrorCode)
            End If
            MessageBox.Show(gblMessage)
        End If
    End Sub

    '接取訊息傳遞的Event-Question
    Public Sub showQuestionMsg(ByVal inErrorCode As String, ByVal inMessage As String()) Handles eventManager.showQuestionMsg
        If AppContext.userProfile.userName.ToLower <> "" AndAlso AppContext.userProfile.userName.ToLower <> "unknown" Then
            Dim OpenMessageDlg As New UCLMessageHandlingUI(UCLMessageHandlingUI.STATUS.QUESTION, inErrorCode, inMessage)
            OpenMessageDlg.ShowDialog()
            Me.DialogResult = DialogResult.None
        Else
            Dim gblMessage As String
            If inMessage IsNot Nothing AndAlso inMessage.Length <> 0 Then
                gblMessage = MessageValueObject.getMessageValue(inErrorCode, inMessage)
            Else
                gblMessage = MessageValueObject.getMessageValue(inErrorCode)
            End If
            MessageBox.Show(gblMessage)
        End If
    End Sub

    '接取訊息傳遞的Event-Infomation
    Public Sub showInfoMsg(ByVal inErrorCode As String, ByVal inMessage As String()) Handles eventManager.showInfoMsg
        If AppContext.userProfile.userName.ToLower <> "" AndAlso AppContext.userProfile.userName.ToLower <> "unknown" Then
            Dim OpenMessageDlg As New UCLMessageHandlingUI(UCLMessageHandlingUI.STATUS.INFO, inErrorCode, inMessage)
            OpenMessageDlg.ShowDialog()
            Me.DialogResult = DialogResult.None
        Else
            Dim gblMessage As String
            If inMessage IsNot Nothing AndAlso inMessage.Length <> 0 Then
                gblMessage = MessageValueObject.getMessageValue(inErrorCode, inMessage)
            Else
                gblMessage = MessageValueObject.getMessageValue(inErrorCode)
            End If
            MessageBox.Show(gblMessage)
        End If
    End Sub

#End Region



#Region "紀錄/查詢使用者執行過的作業"
    Function insertFunRecord(ByVal subSystemNo As String, ByVal funSystemNo As String, funSystemName As String) As Int32
        Try
            Return ArmServiceManager.getInstance.insertFunRecord(genFunRecordDS(subSystemNo, funSystemNo, funSystemName))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function genFunRecordDS(ByVal subSystemNo As String, ByVal funSystemNo As String, funSystemName As String) As DataSet
        Dim LAbDB() As String = {"Rec_User", "Rec_DateTime", "Sub_System_No", "fun_function_no", "Fun_Function_Name"}
        Dim tableName As String = "Arm_Record"
        Dim armRecordDS As DataSet = Syscom.Comm.Utility.DataSetUtil.GenDataSet(tableName, LAbDB)
        Dim row As DataRow

        row = armRecordDS.Tables(tableName).NewRow
        row("Rec_User") = AppContext.userProfile.userId
        row("Rec_DateTime") = "" '改為後端Insert  
        row("Sub_System_No") = subSystemNo
        row("fun_function_no") = funSystemNo
        row("Fun_Function_Name") = funSystemName

        armRecordDS.Tables(tableName).Rows.Add(row)
        Return armRecordDS
    End Function
#End Region

#Region "授權代理"


    ''' <summary>
    ''' 授權代理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpenAgentInstance(ByVal LoginUserId As String, ByVal LoginUserName As String, ByVal AgentUserId As String, ByVal AgentUserName As String, ByVal userRoleList() As String) Handles eventManager.OpenAgentInstance
        If Me.thisUserProfile.agentId = "unknown" Then
            Dim ds As DataSet = ArmServiceManager.getInstance.LoginForAgent(LoginUserId, userRoleList)
            Program.genXML(ds.Tables("AppInfo"), LoginUserId)

            '建立登入資訊
            Dim tempProfile As New UserProfile
            tempProfile.userId = LoginUserId
            tempProfile.userName = LoginUserName
            'tempProfile.userPw = ModForm.PasswdInfo
            tempProfile.userDeptCode = ds.Tables("UserInfo").Rows(0).Item("user-departmentnumber").ToString.Trim
            tempProfile.userDeptName = ds.Tables("UserInfo").Rows(0).Item("user-department").ToString.Trim
            tempProfile.userMemberOf = ds.Tables("UserInfo").Rows(0).Item("user-memberof").ToString.Trim
            'tempProfile.userOnStationNo = ModForm.StationNo
            'tempProfile.userOnTermNo = ModForm.TermNo
            tempProfile.systemSourceTypeId = ""
            tempProfile.agentId = AgentUserId
            tempProfile.agentName = AgentUserName

            Dim instance As New MainForm(tempProfile)
            agentCount += 1
            AddHandler instance.FormClosed, AddressOf removeAgent
            instance.Show()
        End If
    End Sub

    Public Sub removeAgent()
        agentCount -= 1
    End Sub

    Private Sub LogonInfo_Click(sender As Object, e As EventArgs) Handles LogonInfo.Click
        Try
            '取得本機上ipv4及非Loopback的IP Address
            Dim IpAddressList As String = ""
            For Each nic As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                For Each ipInfo As System.Net.NetworkInformation.IPAddressInformation In nic.GetIPProperties().UnicastAddresses
                    If ipInfo.IsDnsEligible = True AndAlso System.Net.IPAddress.IsLoopback(ipInfo.Address) = False AndAlso ipInfo.Address.AddressFamily <> Net.Sockets.AddressFamily.InterNetworkV6 Then
                        IpAddressList &= ipInfo.Address.ToString.Trim & vbNewLine
                    End If
                Next
            Next
            MsgBox(IpAddressList, MsgBoxStyle.Information, "IP 列表")
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub
#End Region

#Region "處理ProcessID"
    ''' <summary>
    ''' 取得Precess UserName
    ''' </summary>
    ''' <param name="AppProcessName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAppProcessID(ByVal AppProcessName As String)
        Dim processes() As Process = Process.GetProcesses()
        Try

        
        ' Loop over processes.
        For Each p As Process In processes
            'Console.WriteLine(p.ProcessName + "/" + p.Id.ToString())
            'If p.ProcessName = AppProcessName + ".vshost" Then  'Debug用
            If p.ProcessName = AppProcessName Then
                'Console.WriteLine(p.ProcessName + "/" + p.Id.ToString())
                'MessageBox.Show(p.ProcessName + "/" + p.Id.ToString())
                '將AppProcessID寫入暫存檔
                AppWriteProcessID(p.Id.ToString())
            End If
            Next
        Catch ex As Exception
            Return -1
        End Try
        Return -1
    End Function


    ''' <summary>
    ''' 寫入ProcessID
    ''' </summary>
    ''' <param name="AppProcessID"></param>
    ''' <remarks></remarks>
    Private Sub AppWriteProcessID(ByVal AppProcessID As Integer)
        Dim AppProcessIdFile As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\AppProcessID.txt"
        Try
            Using outfile As System.IO.StreamWriter = New System.IO.StreamWriter(AppProcessIdFile, False)
                outfile.WriteLine(AppProcessID.ToString)
            End Using

        Catch ex As Exception
            System.Console.WriteLine(ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' 讀取ProcessID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AppReadProcessID() As Integer
        Dim AppProcessIdFile As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\AppProcessID.txt"
        Try
            Dim file As System.IO.StreamReader = New System.IO.StreamReader(AppProcessIdFile)
            Dim retStr As String = ""
            If System.IO.File.Exists(AppProcessIdFile) Then
                retStr = file.ReadLine()
            End If
            file.Close()
            If retStr <> "" Then
                Return CInt(retStr)
            Else
                Return -1
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.Message)
            Return -1
        End Try
    End Function

    Private Sub killAppProcess(ByVal AppProcessID As Integer)
        Try
            For Each p As Process In Process.GetProcesses()
                If p.Id = AppProcessID Then
                    p.Kill()
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "護理站&TermCode"

    Function queryIpBystation(ByVal myIP As String) As String
        'Default 護理站
        Dim stationNo As String = ""
        Try
            Dim retDs As DataSet = PubServiceManager.getInstance.queryStationByIP(myIP)
            If retDs.Tables(0).Rows.Count > 0 Then
                If retDs.Tables(0).Rows(0).Item("Is_Default").ToString.Trim = "Y" Then
                    stationNo = retDs.Tables(0).Rows(0).Item("Station_No").ToString.Trim
                End If
            End If
            Return stationNo
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region
End Class

