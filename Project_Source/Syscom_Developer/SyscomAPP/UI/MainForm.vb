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

    '�w�]�C��
    Dim _R As Integer = 240
    Dim _G As Integer = 255
    Dim _B As Integer = 255

    '�r��
    Dim _fontName As String = "�s�ө���"
    Dim _fontSize As Single = 12
    Dim _fontStyle As System.Drawing.FontStyle = 0
    Dim notifyWindowCount As Integer = 0

    '�O���@�z�H���n�d������ñ����Timer ����
    Private globalNurseSignTip As Integer = 0

    '�O���O�_���@�z�H���Atrue: ���@�z�H��
    Private globalNurseFlag As Boolean = False

    '�[�J�����T���ǻ���Event
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

    '���������ϥΪ�Event add on 2012-05-10 by Lits
    Public Sub EISSwitchUser() Handles eventManager.SwitchUserEvent
        Try
            SwitchUser()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    '�����T���ǻ���Event
    Public Sub DisplayStatusBar(ByVal msg As String) Handles eventManager.DisplayStatusBar
        Try
            displayMessageBar(msg)
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    '�۰ʥ��} �ݶE�@�~ Event �Ҧp: showDockEvent("�ݶE�@�~")
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

    '����Waiting 
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

    '����Waiting 
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

        ' �����]�p�u��һݪ��I�s�C
        InitializeComponent()

        ' �b InitializeComponent() �I�s����[�J�����l�]�w�C
        m_deserializeDockContent = New DeserializeDockContent(AddressOf GetContentFromPersistString)
        Me.thisUserProfile = AppContext.userProfile
    End Sub

    Public Sub New(ByVal tempUserProfile As UserProfile)

        ' �����]�p�u��һݪ��I�s�C
        InitializeComponent()

        ' �b InitializeComponent() �I�s����[�J�����l�]�w�C
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
        '�����t�δ���
        Try
            Dim MessageString As String = ""
            If agentCount > 0 Then
                MessageString = "���}�ɷ|�@�������N�z���椧�t�ΡA�O�_�T�w�����t��"
            Else
                MessageString = "�O�_�T�w�����t��"
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
            '�Ұ�APPIdleTime �p�ɾ�
            appIdleTime = AppContext.userProfile.appIdleTime
            Me.TimerX.Start()
            '�۰ʸ��J�ڪ��̷R add on 2012-09-24 by Lits--------------------------------------
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
            
            Me.Text = "�{�ұ��v�t��"
            ''*********************************
            getDeployMessage() 'Deploy NotifyWindow

            Me.LogonInfo.Text = "���:" & AppContext.userProfile.userDeptName & "  �n�J��:" & AppContext.userProfile.userName & "(" & AppContext.userProfile.userIP & ")  �n�J�ɶ�: " & DateUtil.TransDateToROC(Now.Date) & " " & Now.ToString("HH:mm:ss") & "  " & DisplayCurrentVersion()
            AppContext.userProfile.userOnStationNo = queryIpBystation(AppContext.userProfile.userIP)
            
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub MainForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If AppContext.userProfile.agentId <> "unknown" Then
                Me.Text = String.Format("{0} ({1}  �N�z�H {2})", Me.titleWord, AppContext.userProfile.userName, AppContext.userProfile.agentName)
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
            '��ܰT���q�� Dock �b�k��,�۰�����
            Dim dockNFC As DockContent = ModForm.getFormObjectByDllAndClass("Syscom.Client.NFC.dll", "Syscom.Client.NFC.NFCDataReader")
            CType(dockNFC, Syscom.Client.NFC.NFCDataReader).Text = "�T���q��"
            CType(dockNFC, Syscom.Client.NFC.NFCDataReader).TabText = "�T���q��"
            If MenuFindDocument("Syscom.Client.NFC.NFCDataReader") IsNot Nothing Then
                MessageHandling.ShowInfoMsg("�T���q�� " & " �w�g�}��!")
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
            '�x�s�ӤH�Ƴ]�w��
            Dim configFile As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), UserInfo.getUserName & "-Profile.config")
            dockPanel.SaveAsXml(configFile)
            SaveUserProfile(configFile, "N")
            MessageHandling.ShowInfoMsg("�ӤH�Ƴ]�w�x�s���\�G" & UserInfo.getUserName & "-Profile.config")
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
            '�x�s�ӤH�Ƴ]�w��
            dockPanel.SaveAsXml(configFile)
            SaveUserProfile(configFile, defFlag)
            MessageHandling.ShowInfoMsg("�ڪ��̷R�x�s���\!")
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
                    '�S�O���w�ڪ��f�H,�]�������AMenu���
                    If msType = "NIS.Client.UCL.NISUCLMyPatientUI" OrElse msType = "syscom.client.nfc.NFCDataReader" OrElse checkIsMenuTree(msDescription) Then '�P�_�O�_menu���{��
                        newContents = contents.Replace(msType, newStr)
                        contents = newContents
                    End If
                End If

            Next

            If newContents = "" Then
                newWriter.Close()
                File.Delete(configFile)
            Else
                '�g�J��Ʈw
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
                MessageBox.Show("�䤣��ӤH�Ƴ]�w�ɡI", "ĵ�i�T��", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                    'add on 2013-0624 By Lits ���J�ڪ��̷R�W�L��ӭ�ñFocus �b�Ĥ@��
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
                MessageBox.Show("�䤣��ӤH�Ƴ]�w�ɡI", "ĵ�i�T��", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    '�Ұʦ۰ʸ��J�w�]��
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
                        'add on 2013-0624 By Lits ���J�ڪ��̷R�W�L��ӭ�ñFocus �b�Ĥ@��
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


    '�]�w�r��
    Private Sub setFont()
        Dim fontDiaglog As New FontDialog
        Dim dockCount As Integer = 0
        dockCount = dockPanel.Contents.Count

        If (fontDiaglog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            _fontName = fontDiaglog.Font.Name
            _fontSize = fontDiaglog.Font.Size
            _fontStyle = fontDiaglog.Font.Style
            For dockCount = 0 To dockCount - 1
                '2015-05-15 Modify By Alan-�[�J�̸ѪR�צ۰ʽվ�e���r��
                If UCLFormUtil.isResizeable Then
                    CType(dockPanel.Contents(dockCount), Form).Font = New System.Drawing.Font(UCLFormUtil.gblFont, InitFontSize)
                Else
                    CType(dockPanel.Contents(dockCount), Form).Font = New System.Drawing.Font(_fontName, _fontSize, _fontStyle, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
                End If

            Next
        End If
    End Sub
    '�]�w�r��
    Private Sub _setFont()
        Dim fontDiaglog As New FontDialog
        Dim dockCount As Integer = 0
        dockCount = dockPanel.Contents.Count

        For dockCount = 0 To dockCount - 1
            '2015-05-15 Modify By Alan-�[�J�̸ѪR�צ۰ʽվ�e���r��
            If UCLFormUtil.isResizeable Then
                CType(dockPanel.Contents(dockCount), Form).Font = New Font(UCLFormUtil.gblFont, InitFontSize)
            Else
                CType(dockPanel.Contents(dockCount), Form).Font = getScreenBoubdsFont()
            End If
            ' New System.Drawing.Font(fontDiaglog.Font.Name, fontDiaglog.Font.Size, fontDiaglog.Font.Style, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Next

    End Sub
    '���o�ù��ѪR��
    Function getScreenBoubdsFont() As System.Drawing.Font
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Try
            Return New System.Drawing.Font(_fontName, InitFontSize, _fontStyle, System.Drawing.GraphicsUnit.Point, CType(136, Byte))

        Catch ex As Exception
            Return New System.Drawing.Font("�s�ӦW��", 12, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
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
        '���JMenu Item ���
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

        '2015-05-15 Modify By Alan-�[�J�̸ѪR�צ۰ʽվ�e���r��
        If UCLFormUtil.isResizeable Then
            ms.Font = New System.Drawing.Font(UCLFormUtil.gblFont, InitFontSize, Nothing, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Else
            ms.Font = New System.Drawing.Font("�s�ӦW��", 12, Nothing, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
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
                    '���osystem ���
                    If reader.Name.ToUpper = "SYSTEM" Then
                        ReDim systemObj(reader.AttributeCount - 1)
                        For j As Integer = 0 To reader.AttributeCount - 1
                            reader.MoveToAttribute(j)
                            systemObj(j) = reader.Value.ToUpper
                        Next
                        setSystemMenu(systemObj)

                        '�[�J���j
                        windowMenu.DropDownItems.Insert(reader.AttributeCount - 1, New ToolStripSeparator)
                    End If
                    '=====================================================
                    If reader.Name = XmlNodeTag Then
                        Dim newNode As New TreeNode()
                        Dim isEmptyElement As Boolean = reader.IsEmptyElement

                        '���J�`�I�ݩ�
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
            '�]�w����,��������MenuItem
            windowMenu = New ToolStripMenuItem("�����˵�") 'Menu�Y
            'windowMenu1 = New ToolStripMenuItem("�����d�ߧ@�~", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu.DropDownItems.Add(windowMenu1)
            windowMenu1 = New ToolStripMenuItem("�]�w�r��", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            windowMenu.DropDownItems.Add(windowMenu1)
            windowMenu1 = New ToolStripMenuItem("�����Ҧ�����", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu1 = New ToolStripMenuItem("��w����", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu1 = New ToolStripMenuItem("�ˬd����", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu1 = New ToolStripMenuItem("���g�E������", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu1 = New ToolStripMenuItem("�v���p����", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu1 = New ToolStripMenuItem("AJCC�����u��", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu1 = New ToolStripMenuItem("���D����")
            'windowMenu.DropDownItems.Add(windowMenu1)
            'windowMenu2 = New ToolStripMenuItem("��|���D����", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
            'windowMenu1.DropDownItems.Add(windowMenu2)
            'windowMenu1 = New ToolStripMenuItem("�ާ@����")
            'windowMenu2 = New ToolStripMenuItem("�s��|�t�ξާ@����", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
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
            '�Ұʪ�����T�d�� by Lits on 2010-07-01
            Dim dockShowVersionInfo As DockContent = ModForm.getFormObjectByDllAndClass("Client.PUB.dll", "Syscom.Client.UCL.PUBSystemVersionUI")
            CType(dockShowVersionInfo, Syscom.Client.UCL.PUBSystemVersionUI).Text = "������T"
            CType(dockShowVersionInfo, Syscom.Client.UCL.PUBSystemVersionUI).TabText = "������T"
            If MenuFindDocument("Syscom.Client.UCL.PUBSystemVersionUI") IsNot Nothing Then
                MessageHandling.ShowInfoMsg("������T " & " �w�g�}��!")
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

                '��w�ù� - For �ڪ��f�H
                eventManager.RaiseAPPLockWindow("True")

                loginForm.UsernameTextBox.Text = ModForm.UserInfo
                loginForm.UsernameTextBox.Enabled = False
                loginForm.Text = String.Format("�ϥΪ�: {0} ��w�e�� - ��J���T�K�X��~��ҥ�", ModForm.UserInfo)
                loginForm.PasswordTextBox.Focus()
                loginForm.ShowDialog()
                loginForm.BringToFront()

                If loginForm.DialogResult = DialogResult.OK Then
                    If loginForm.PasswordTextBox.Text = ModForm.PasswdInfo Then
                        UnLockWindow()

                        '�Ѱ���w�ù� - For �ڪ��f�H
                        eventManager.RaiseAPPLockWindow("False")

                    Else
                        MessageHandling.ShowErrorMsg("�K�X���~!")
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
                CurrentVersion = "����:V" & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
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

#Region "Menu�����ʧ@"
    Private Sub gcTEST()
        For i As Integer = 1 To GC.MaxGeneration
            ' �i�� GC �����ʧ@ 
            GC.Collect()
        Next
        For i As Integer = 0 To GC.MaxGeneration
            ' �j��ߧY����h�N�s�ܫ��w�h�N���O����^���C 
            GC.Collect(i)
            ' �Ȥ�ثe��������A����B�z��������C��������w�g�M�ŸӦ�C����C 
            GC.WaitForPendingFinalizers()
        Next
    End Sub

    Private Sub windowNewMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            gcTEST()
            '�]�w��0�h(Root)MenuItem �I��ƥ�
            

            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "�T���q��" Then
                Me.showNFCReader()
                Exit Sub
            End If

            'If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "���J�ӤH�Ƴ]�w" Then LoadProfile() : Exit Sub

            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "�ڪ��̷R" Then MyFavorites() : Exit Sub
            'If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "�t�Ϊ�����s�O���d��" Then showVersionInfo() : Exit Sub

            'add on 2012-05-10 by Lits for ��E�����ϥΪ�--------------------------------
            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "�����ϥΪ�" Then
                SwitchUser()
                Exit Sub
            End If

            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "�n�X" Then
                Me.Dispose(False)
                Exit Sub
            End If

            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "����" Then
                Me.Dispose(True)
                Exit Sub
            End If

            'If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "����" Then About() : Exit Sub
            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "�����Ҧ�����" Then closeAllDockPanel() : Exit Sub
            'If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "��w����" Then LockWindow() : Exit Sub
            If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "�]�w�r��" Then
                'setFont()
                Exit Sub
            End If

            'If DirectCast(sender, ToolStripMenuItem).Text.ToUpper() = "�ˬd����" Then
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
                MessageHandling.ShowErrorMsg(item & " ������~")
            End Try

            Dim tagStrings As String() = tag.Split(New Char() {","c})
            If tagStrings.Length <> 2 Then
                Exit Sub
            End If

            'If tagStrings(1).StartsWith("nckuh.client.pcsucl.PCSUCLMSReportViewer;") Then
            '    Dim temp As String() = tagStrings(1).Split(New Char() {";"c})

            '    Dim myForm As DockContent = ModForm.getFormObjectByDllAndClass(tagStrings(0), temp(0))
            '    If myForm Is Nothing Then
            '        MessageHandling.ShowErrorMsg("�䤣�줸��: " & tag)
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

                MessageHandling.ShowInfoMsg("CMMCMMB300", New String() {item & "-�w�g�}��"})
                Exit Sub
            End If


            'Dim dockForm As DockContent = ModForm.getFormObjectByClass(tag)
            Dim dockForm As DockContent = ModForm.getFormObjectByDllAndClass(tagStrings(0), tagStrings(1))
            If dockForm Is Nothing Then
                MessageHandling.ShowErrorMsg("�䤣�줸��: " & tag)
                Exit Sub
            End If

            dockForm.Text = item
            dockForm.TabText = item

            'add on 2014-12-10 By Lits �s�W�I���@�~����================================
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
            windowMenu = New ToolStripMenuItem(obj(0).ToString, imageList.Images(0)) 'Menu ���Y
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
            '�����W�����(���F�t�ο�椧�~)
            For i As Integer = ms.Items.Count - 1 To 0 Step -1
                If ms.Items(i).Text.Equals("�t�Υ\��") Then
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
        '�]�w�Ĥ@�hMenuItem �I��ƥ�
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
                    windowMenu = New ToolStripMenuItem(DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu�Y
                    windowMenu.Tag = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Tag
                    windowMenu.ToolTipText = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).ToolTipText
                    ms.Items.Add(windowMenu)

                    For j As Integer = 0 To DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Count - 1
                        windowMenu1 = New ToolStripMenuItem(DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Item(j).Text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu�Y
                        windowMenu1.Tag = DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Item(j).Tag
                        windowMenu1.ToolTipText = DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Item(j).ToolTipText
                        windowMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {windowMenu1})
                    Next
                Else
                    If i = 5 Then
                        windowMenu = New ToolStripMenuItem("��l����", imageList.Images(0)) 'Menu ���Y
                        ms.MdiWindowListItem = windowMenu
                        ms.Items.Add(windowMenu)


                    End If
                    windowMenu1 = New ToolStripMenuItem(DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu�Y
                    windowMenu1.Tag = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Tag
                    windowMenu1.ToolTipText = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).ToolTipText
                    windowMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {windowMenu1})

                    For j As Integer = 0 To DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Count - 1
                        windowMenu2 = New ToolStripMenuItem(DirectCast(menuItem, ToolStripMenuItem).DropDownItems.Item(j).Text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu�Y
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
        '�]�w�Ĥ@�hMenuItem �I��ƥ�
        reMoveMenuItem()
        Dim name As String = DirectCast(sender, ToolStripMenuItem).Name
        Dim item As String = DirectCast(sender, ToolStripMenuItem).Text.ToUpper()
        Dim tag As String = ""
        Try
            tag = DirectCast(sender, ToolStripMenuItem).Tag.ToString
            For i As Integer = 0 To DirectCast(sender, ToolStripMenuItem).DropDownItems.Count - 1

                If i < 5 Then
                    windowMenu = New ToolStripMenuItem(DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu�Y
                    windowMenu.Tag = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Tag
                    windowMenu.ToolTipText = DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).ToolTipText
                    ms.Items.Add(windowMenu)
                Else
                    If i = 5 Then
                        windowMenu = New ToolStripMenuItem("��l����", imageList.Images(0)) 'Menu ���Y
                        ms.MdiWindowListItem = windowMenu
                        ms.Items.Add(windowMenu)

                    End If
                    windowMenu1 = New ToolStripMenuItem(DirectCast(sender, ToolStripMenuItem).DropDownItems.Item(i).Text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu�Y
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
        '���JMenu Item ���
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

                        '���J�`�I�ݩ�
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
                                windowMenu = New ToolStripMenuItem(text, Nothing) 'Menu ���Y
                                ms.MdiWindowListItem = windowMenu
                                ms.Items.Add(windowMenu)
                            ElseIf level = "2" Then
                                windowMenu1 = New ToolStripMenuItem(text, Nothing, New EventHandler(AddressOf windowNewMenu_Click)) 'Menu�Y
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



#Region "15�����۰ʵn�X"

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

            ''�p�G�O�@�z�H��30�����~��w
            'If globalNurseFlag Then

            '    '�W�L30�����A�n�X
            '    If Me.IdleTime >= (30 * 60) Then

            '        'Me.LockWindow()
            '        eventManager.RaiseSwitchUserEvent()

            '    End If

            '    '�������d�ߥ�ñ������A�]���C0.1����@���A�ҥH�n*10
            '    If globalNurseSignTip >= (1 * 60 * 10) Then

            '        '���o����ñ�����
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

            '30 �����n�X By Sean �Ȯ�����2015-09-26-Lits
            Try
                displayMessageBar("���m�ɶ����G" & (CInt(Me.IdleTime / 60)).ToString & "��")
                If Me.IdleTime >= (appIdleTime * 60) Then
                    'Me.TimerX.Stop()
                    Dim retInt As Integer = ArmServiceManager.getInstance.updateLogoutDateBySystem(ModForm.SystemNo, loginDate, AppContext.userProfile.userIP, AppContext.userProfile.userId, agentCode, Environment.MachineName)
                    '�R���Ȧs��User.txt
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

#Region "add on 2012-05-10 by Lits for ��E�����ϥΪ�"

    Private Sub SwitchUser()
        Try
            Dim loginForm As New SwitchUserUI()
            loginForm.Text = "�����ϥΪ�: "
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

    'add on 2012-05-10 by Lits for �����ϥΪ�
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
            LOGDelegate.getInstance.fileDebugMsg("���� MainForm ��l�Ƶ{���G" & Now.ToString("yyyy-MM-dd HH:mm:ss"))
            '**********************************************************************************************



            Me.Text = String.Format("{0} ({1})", Me.titleWord, ModForm.UserInfoName)
            '�n�J�ɦ۰ʱ��J���� on 2012-11-06 by Lits--------
            '�P�_�O�_���@�z�H��
            '�D�������n�w�]�a�J===============================
            Dim CurrentMenberOf As String = AppContext.userProfile.userMemberOf
            If CurrentMenberOf.Contains("CNC_Admin") Or CurrentMenberOf.Contains("CNC_DP") Or CurrentMenberOf.Contains("CNC_HN") Or CurrentMenberOf.Contains("CNC_MN") _
              Or CurrentMenberOf.Contains("CNC_NP") Or CurrentMenberOf.Contains("CNC_SUP") Or CurrentMenberOf.Contains("CNC_User") Then
                globalNurseFlag = True
            End If
            '�@�z�H�� Dock �b����
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
            '���������W�����
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

#Region "add on 2012-09-18 by Lits for �ڪ��̷R"

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
        '�ˬd�{���O�_��Menu ���{��
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

                        '���J�`�I�ݩ�
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
                    MessageBox.Show("�L�k�b���ɧ�s. " + ControlChars.Lf & ControlChars.Lf & "���ˬd�����O�_���`. ���~: " + dde.Message)
                    Return False
                Catch ioe As InvalidOperationException
                    MessageBox.Show("��s����. ���~: " & ioe.Message)
                    Return False
                End Try

                If (info.UpdateAvailable) Then
                    doUpdate = True

                    If (Not info.IsUpdateRequired) Then
                        Dim dr As DialogResult = MessageBox.Show("���s����s,�O�_�{�b��s?��s�����N���s�Ұ�", "�s�����t�Ϊ�����s", MessageBoxButtons.OKCancel)
                        If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                            doUpdate = False
                        End If
                    Else
                        ' ��̤ܳp����.
                        MessageBox.Show("���s����s  " & _
                            "���� " & info.MinimumRequiredVersion.ToString() & _
                            ". ��s�����N���s�Ұ�.", _
                            "�s�����t�Ϊ�����s", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
                    End If

                    If (doUpdate) Then
                        Try
                            Me.Dispose(False)
                        Catch dde As DeploymentDownloadException
                            MessageBox.Show("�L�k�w�ˤU����s���ε{��. " & ControlChars.Lf & ControlChars.Lf & "���ˬd�������p�ΤU���A��s.")
                            Return False
                        End Try
                    End If
                Else
                    MessageBox.Show("�ˬd�S���s�������i��s", "�s�����t�Ϊ����ˬd", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            'getDeployMessage() '�ˬd�o���ɶ�

            UpdateApplication()  ' �۰��ˬd����
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
                nw.Font = New System.Drawing.Font("�з���", 12.0F)
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

#Region "add On 20120423 by Lits �D�P�BCheck Version & Update"

    Private sizeOfUpdate As Long = 0
    '�����D�P�B�ܼ�
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
        'eventManager.RaisDisplayStatusBar(("��s�i��:" & [String].Format("{0:D}K of {1:D}K downloaded.", e.BytesCompleted / 1024, e.BytesTotal / 1024)))
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
                '    'Dim dr As DialogResult = MessageBox.Show("���s������,�O�_���W��s?(��ĳ���W��s)", "�s������s", MessageBoxButtons.OKCancel)
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
        'eventManager.RaisDisplayStatusBar(("��s�i��:" & progressText))
    End Sub

    Private Sub ADUpdateAsync_UpdateCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles ADUpdateAsync.UpdateCompleted
        Try
            If (e.Cancelled) Then
                'MessageBox.Show("The update of the application's latest version was cancelled.")
                Me.TimerDeploy.Start()
                Exit Sub
            Else
                If (e.Error IsNot Nothing) Then
                    MessageBox.Show("���~!: �L�k�w�˳̷s����. Reason: " + ControlChars.Lf + e.Error.Message + ControlChars.Lf + "���p����T��(#2065).")
                    Me.TimerDeploy.Start()
                    Exit Sub
                End If
            End If
            'AsyncUpdateUI.ShowDialog()
            'Me.Dispose(False)
            'Dim dr As DialogResult = MessageBox.Show("�s�����U������. �Э��s�n�J. (���p�����s�n�J, �t�αN���|����s������,���O�Ҹ�ƥ��T��.)", "�����t�έ��s�Ұ�", MessageBoxButtons.OKCancel)
            'Dim dr As DialogResult = MessageBox.Show("�s�����U������.�I��[�T�w]�����t�αN���s�n�J.�p�G���|���������@�~�Х��s�ɫ�A�I��[�T�w]", "�����t�έ��s�Ұ�", MessageBoxButtons.OK)
            Dim dr As DialogResult = MessageBox.Show("�s�����U������!�ݭn���s�Ұʫ�~�|�ͮ�", "�s�����q��", MessageBoxButtons.OK)
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

    '�����T���ǻ���Event-Error(WCF�M��)
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

    '�����T���ǻ���Event-Error
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

    '�����T���ǻ���Event-Warn
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

    '�����T���ǻ���Event-Question
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

    '�����T���ǻ���Event-Infomation
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



#Region "����/�d�ߨϥΪ̰���L���@�~"
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
        row("Rec_DateTime") = "" '�אּ���Insert  
        row("Sub_System_No") = subSystemNo
        row("fun_function_no") = funSystemNo
        row("Fun_Function_Name") = funSystemName

        armRecordDS.Tables(tableName).Rows.Add(row)
        Return armRecordDS
    End Function
#End Region

#Region "���v�N�z"


    ''' <summary>
    ''' ���v�N�z
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpenAgentInstance(ByVal LoginUserId As String, ByVal LoginUserName As String, ByVal AgentUserId As String, ByVal AgentUserName As String, ByVal userRoleList() As String) Handles eventManager.OpenAgentInstance
        If Me.thisUserProfile.agentId = "unknown" Then
            Dim ds As DataSet = ArmServiceManager.getInstance.LoginForAgent(LoginUserId, userRoleList)
            Program.genXML(ds.Tables("AppInfo"), LoginUserId)

            '�إߵn�J��T
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
            '���o�����Wipv4�ΫDLoopback��IP Address
            Dim IpAddressList As String = ""
            For Each nic As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                For Each ipInfo As System.Net.NetworkInformation.IPAddressInformation In nic.GetIPProperties().UnicastAddresses
                    If ipInfo.IsDnsEligible = True AndAlso System.Net.IPAddress.IsLoopback(ipInfo.Address) = False AndAlso ipInfo.Address.AddressFamily <> Net.Sockets.AddressFamily.InterNetworkV6 Then
                        IpAddressList &= ipInfo.Address.ToString.Trim & vbNewLine
                    End If
                Next
            Next
            MsgBox(IpAddressList, MsgBoxStyle.Information, "IP �C��")
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub
#End Region

#Region "�B�zProcessID"
    ''' <summary>
    ''' ���oPrecess UserName
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
            'If p.ProcessName = AppProcessName + ".vshost" Then  'Debug��
            If p.ProcessName = AppProcessName Then
                'Console.WriteLine(p.ProcessName + "/" + p.Id.ToString())
                'MessageBox.Show(p.ProcessName + "/" + p.Id.ToString())
                '�NAppProcessID�g�J�Ȧs��
                AppWriteProcessID(p.Id.ToString())
            End If
            Next
        Catch ex As Exception
            Return -1
        End Try
        Return -1
    End Function


    ''' <summary>
    ''' �g�JProcessID
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
    ''' Ū��ProcessID
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

#Region "�@�z��&TermCode"

    Function queryIpBystation(ByVal myIP As String) As String
        'Default �@�z��
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

