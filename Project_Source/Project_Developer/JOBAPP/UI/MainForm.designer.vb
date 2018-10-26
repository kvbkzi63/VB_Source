<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits Syscom.Client.UCL.BaseFormUI

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                MyBase.Dispose(disposing)
            Else
                System.Windows.Forms.Application.ExitThread()
                System.Windows.Forms.Application.Exit()
                System.Windows.Forms.Application.Restart()
            End If
        Finally
            'MyBase.Dispose(disposing)
            Dim mydocpath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Templates)
            If System.IO.File.Exists(mydocpath + "\user.txt") Then
                System.IO.File.Delete(mydocpath + "\user.txt")
            End If
            If System.Environment.UserDomainName.ToUpper <> "KMUH" Then
                'If System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\DeskTopEXE.exe") Then
                '    'Process.Start(System.Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\DeskTopEXE.exe")
                'End If
            End If
            Dim AppProcessID As Integer = AppReadProcessID()
            killAppProcess(AppProcessID)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.mainMenu = New System.Windows.Forms.MenuStrip()
        Me.menuItemWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemNewWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseAllWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSetBlackColor = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitAsSaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemView = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuItemToolBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemStatusBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuItemTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemLockLayout = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemShowDocumentIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuItemDockingMdi = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemDockingSdi = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemDockingWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemSystemMdi = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.showRightToLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.statusBar = New System.Windows.Forms.StatusStrip()
        Me.LogonInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MsgStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.imageList = New System.Windows.Forms.ImageList(Me.components)
        Me.toolBar = New System.Windows.Forms.ToolStrip()
        Me.toolBarButtonNew = New System.Windows.Forms.ToolStripButton()
        Me.toolBarButtonOpen = New System.Windows.Forms.ToolStripButton()
        Me.toolBarButtonSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolBarButtonSolutionExplorer = New System.Windows.Forms.ToolStripButton()
        Me.toolBarButtonPropertyWindow = New System.Windows.Forms.ToolStripButton()
        Me.toolBarButtonToolbox = New System.Windows.Forms.ToolStripButton()
        Me.toolBarButtonOutputWindow = New System.Windows.Forms.ToolStripButton()
        Me.toolBarButtonTaskList = New System.Windows.Forms.ToolStripButton()
        Me.toolBarButtonSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolBarButtonLayoutByCode = New System.Windows.Forms.ToolStripButton()
        Me.toolBarButtonLayoutByXml = New System.Windows.Forms.ToolStripButton()
        Me.dockPanel = New Com.Syscom.WinFormsUI.Docking.DockPanel()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.TimerDeploy = New System.Windows.Forms.Timer(Me.components)
        Me.statusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu
        '
        Me.mainMenu.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.mainMenu.Font = New System.Drawing.Font("標楷體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.mainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mainMenu.MdiWindowListItem = Me.menuItemWindow
        Me.mainMenu.Name = "mainMenu"
        Me.mainMenu.Size = New System.Drawing.Size(821, 24)
        Me.mainMenu.TabIndex = 7
        Me.mainMenu.Visible = False
        '
        'menuItemWindow
        '
        Me.menuItemWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuItemNewWindow, Me.CloseAllWindowsToolStripMenuItem, Me.ToolStripMenuItemSetBlackColor})
        Me.menuItemWindow.MergeIndex = 2
        Me.menuItemWindow.Name = "menuItemWindow"
        Me.menuItemWindow.Size = New System.Drawing.Size(52, 20)
        Me.menuItemWindow.Text = "視窗"
        Me.menuItemWindow.Visible = False
        '
        'menuItemNewWindow
        '
        Me.menuItemNewWindow.Name = "menuItemNewWindow"
        Me.menuItemNewWindow.Size = New System.Drawing.Size(146, 22)
        Me.menuItemNewWindow.Text = "新視窗"
        '
        'CloseAllWindowsToolStripMenuItem
        '
        Me.CloseAllWindowsToolStripMenuItem.Name = "CloseAllWindowsToolStripMenuItem"
        Me.CloseAllWindowsToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.CloseAllWindowsToolStripMenuItem.Text = "關閉所有視窗"
        '
        'ToolStripMenuItemSetBlackColor
        '
        Me.ToolStripMenuItemSetBlackColor.Name = "ToolStripMenuItemSetBlackColor"
        Me.ToolStripMenuItemSetBlackColor.Size = New System.Drawing.Size(146, 22)
        Me.ToolStripMenuItemSetBlackColor.Text = "改變視窗底色"
        '
        'menuItemFile
        '
        Me.menuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitAsSaveToolStripMenuItem, Me.openToolStripMenuItem, Me.ToolStripSeparator1, Me.FontToolStripMenuItem, Me.menuItem4, Me.ExitToolStripMenuItem, Me.CloseToolStripMenuItem1})
        Me.menuItemFile.Name = "menuItemFile"
        Me.menuItemFile.Size = New System.Drawing.Size(52, 20)
        Me.menuItemFile.Text = "檔案"
        '
        'ExitAsSaveToolStripMenuItem
        '
        Me.ExitAsSaveToolStripMenuItem.Name = "ExitAsSaveToolStripMenuItem"
        Me.ExitAsSaveToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ExitAsSaveToolStripMenuItem.Text = "儲存個人化設定"
        '
        'openToolStripMenuItem
        '
        Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
        Me.openToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.openToolStripMenuItem.Text = "載入個人化設定"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(155, 6)
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FontToolStripMenuItem1})
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.FontToolStripMenuItem.Text = "字形設定"
        Me.FontToolStripMenuItem.Visible = False
        '
        'FontToolStripMenuItem1
        '
        Me.FontToolStripMenuItem1.Name = "FontToolStripMenuItem1"
        Me.FontToolStripMenuItem1.Size = New System.Drawing.Size(122, 22)
        Me.FontToolStripMenuItem1.Text = "字體設定"
        '
        'menuItem4
        '
        Me.menuItem4.Name = "menuItem4"
        Me.menuItem4.Size = New System.Drawing.Size(155, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ExitToolStripMenuItem.Text = "登出"
        '
        'CloseToolStripMenuItem1
        '
        Me.CloseToolStripMenuItem1.Name = "CloseToolStripMenuItem1"
        Me.CloseToolStripMenuItem1.Size = New System.Drawing.Size(158, 22)
        Me.CloseToolStripMenuItem1.Text = "結束"
        '
        'menuItemView
        '
        Me.menuItemView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuItem1, Me.menuItemToolBar, Me.menuItemStatusBar, Me.menuItem2})
        Me.menuItemView.MergeIndex = 1
        Me.menuItemView.Name = "menuItemView"
        Me.menuItemView.Size = New System.Drawing.Size(52, 20)
        Me.menuItemView.Text = "檢視"
        Me.menuItemView.Visible = False
        '
        'menuItem1
        '
        Me.menuItem1.Name = "menuItem1"
        Me.menuItem1.Size = New System.Drawing.Size(131, 6)
        '
        'menuItemToolBar
        '
        Me.menuItemToolBar.Enabled = False
        Me.menuItemToolBar.Name = "menuItemToolBar"
        Me.menuItemToolBar.Size = New System.Drawing.Size(134, 22)
        Me.menuItemToolBar.Text = "顯示工具列"
        '
        'menuItemStatusBar
        '
        Me.menuItemStatusBar.Checked = True
        Me.menuItemStatusBar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuItemStatusBar.Name = "menuItemStatusBar"
        Me.menuItemStatusBar.Size = New System.Drawing.Size(134, 22)
        Me.menuItemStatusBar.Text = "顯示狀態欄"
        '
        'menuItem2
        '
        Me.menuItem2.Name = "menuItem2"
        Me.menuItem2.Size = New System.Drawing.Size(131, 6)
        '
        'menuItemTools
        '
        Me.menuItemTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuItemLockLayout, Me.menuItemShowDocumentIcon, Me.menuItem3, Me.menuItem6, Me.menuItemDockingMdi, Me.menuItemDockingSdi, Me.menuItemDockingWindow, Me.menuItemSystemMdi, Me.menuItem5, Me.showRightToLeft})
        Me.menuItemTools.MergeIndex = 2
        Me.menuItemTools.Name = "menuItemTools"
        Me.menuItemTools.Size = New System.Drawing.Size(52, 20)
        Me.menuItemTools.Text = "工具"
        Me.menuItemTools.Visible = False
        '
        'menuItemLockLayout
        '
        Me.menuItemLockLayout.Name = "menuItemLockLayout"
        Me.menuItemLockLayout.Size = New System.Drawing.Size(266, 22)
        Me.menuItemLockLayout.Text = "&Lock Layout"
        '
        'menuItemShowDocumentIcon
        '
        Me.menuItemShowDocumentIcon.Name = "menuItemShowDocumentIcon"
        Me.menuItemShowDocumentIcon.Size = New System.Drawing.Size(266, 22)
        Me.menuItemShowDocumentIcon.Text = "顯示視窗圖示"
        '
        'menuItem3
        '
        Me.menuItem3.Name = "menuItem3"
        Me.menuItem3.Size = New System.Drawing.Size(263, 6)
        '
        'menuItem6
        '
        Me.menuItem6.Name = "menuItem6"
        Me.menuItem6.Size = New System.Drawing.Size(263, 6)
        '
        'menuItemDockingMdi
        '
        Me.menuItemDockingMdi.Checked = True
        Me.menuItemDockingMdi.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuItemDockingMdi.Name = "menuItemDockingMdi"
        Me.menuItemDockingMdi.Size = New System.Drawing.Size(266, 22)
        Me.menuItemDockingMdi.Text = "Document Style: Docking &MDI"
        '
        'menuItemDockingSdi
        '
        Me.menuItemDockingSdi.Name = "menuItemDockingSdi"
        Me.menuItemDockingSdi.Size = New System.Drawing.Size(266, 22)
        Me.menuItemDockingSdi.Text = "Document Style: Docking &SDI"
        '
        'menuItemDockingWindow
        '
        Me.menuItemDockingWindow.Name = "menuItemDockingWindow"
        Me.menuItemDockingWindow.Size = New System.Drawing.Size(266, 22)
        Me.menuItemDockingWindow.Text = "Document Style: Docking &Window"
        '
        'menuItemSystemMdi
        '
        Me.menuItemSystemMdi.Name = "menuItemSystemMdi"
        Me.menuItemSystemMdi.Size = New System.Drawing.Size(266, 22)
        Me.menuItemSystemMdi.Text = "Document Style: S&ystem MDI"
        '
        'menuItem5
        '
        Me.menuItem5.Name = "menuItem5"
        Me.menuItem5.Size = New System.Drawing.Size(263, 6)
        '
        'showRightToLeft
        '
        Me.showRightToLeft.Name = "showRightToLeft"
        Me.showRightToLeft.Size = New System.Drawing.Size(266, 22)
        Me.showRightToLeft.Text = "Show &Right-To-Left"
        '
        'menuItemHelp
        '
        Me.menuItemHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuItemAbout})
        Me.menuItemHelp.MergeIndex = 3
        Me.menuItemHelp.Name = "menuItemHelp"
        Me.menuItemHelp.Size = New System.Drawing.Size(52, 20)
        Me.menuItemHelp.Text = "關於"
        '
        'menuItemAbout
        '
        Me.menuItemAbout.Name = "menuItemAbout"
        Me.menuItemAbout.Size = New System.Drawing.Size(98, 22)
        Me.menuItemAbout.Text = "說明"
        '
        'statusBar
        '
        Me.statusBar.AllowDrop = True
        Me.statusBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.statusBar.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogonInfo, Me.MsgStatus})
        Me.statusBar.Location = New System.Drawing.Point(0, 467)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.statusBar.Size = New System.Drawing.Size(821, 22)
        Me.statusBar.TabIndex = 4
        '
        'LogonInfo
        '
        Me.LogonInfo.ForeColor = System.Drawing.Color.Yellow
        Me.LogonInfo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LogonInfo.Name = "LogonInfo"
        Me.LogonInfo.Size = New System.Drawing.Size(60, 17)
        Me.LogonInfo.Text = "登入資訊"
        Me.LogonInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MsgStatus
        '
        Me.MsgStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MsgStatus.ForeColor = System.Drawing.Color.Cornsilk
        Me.MsgStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MsgStatus.Name = "MsgStatus"
        Me.MsgStatus.Size = New System.Drawing.Size(746, 17)
        Me.MsgStatus.Spring = True
        Me.MsgStatus.Text = "訊息欄"
        Me.MsgStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imageList
        '
        Me.imageList.ImageStream = CType(resources.GetObject("imageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList.Images.SetKeyName(0, "")
        Me.imageList.Images.SetKeyName(1, "")
        Me.imageList.Images.SetKeyName(2, "")
        Me.imageList.Images.SetKeyName(3, "")
        Me.imageList.Images.SetKeyName(4, "")
        Me.imageList.Images.SetKeyName(5, "")
        Me.imageList.Images.SetKeyName(6, "")
        Me.imageList.Images.SetKeyName(7, "")
        Me.imageList.Images.SetKeyName(8, "")
        '
        'toolBar
        '
        Me.toolBar.ImageList = Me.imageList
        Me.toolBar.Location = New System.Drawing.Point(0, 0)
        Me.toolBar.Name = "toolBar"
        Me.toolBar.Size = New System.Drawing.Size(821, 25)
        Me.toolBar.TabIndex = 6
        Me.toolBar.Visible = False
        '
        'toolBarButtonNew
        '
        Me.toolBarButtonNew.Name = "toolBarButtonNew"
        Me.toolBarButtonNew.Size = New System.Drawing.Size(23, 22)
        Me.toolBarButtonNew.ToolTipText = "DummyDoc"
        '
        'toolBarButtonOpen
        '
        Me.toolBarButtonOpen.Name = "toolBarButtonOpen"
        Me.toolBarButtonOpen.Size = New System.Drawing.Size(23, 22)
        Me.toolBarButtonOpen.ToolTipText = "Open"
        '
        'toolBarButtonSeparator1
        '
        Me.toolBarButtonSeparator1.Name = "toolBarButtonSeparator1"
        Me.toolBarButtonSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolBarButtonSolutionExplorer
        '
        Me.toolBarButtonSolutionExplorer.Name = "toolBarButtonSolutionExplorer"
        Me.toolBarButtonSolutionExplorer.Size = New System.Drawing.Size(23, 22)
        Me.toolBarButtonSolutionExplorer.ToolTipText = "Solution Explorer"
        '
        'toolBarButtonPropertyWindow
        '
        Me.toolBarButtonPropertyWindow.Name = "toolBarButtonPropertyWindow"
        Me.toolBarButtonPropertyWindow.Size = New System.Drawing.Size(23, 22)
        Me.toolBarButtonPropertyWindow.ToolTipText = "Property Window"
        '
        'toolBarButtonToolbox
        '
        Me.toolBarButtonToolbox.Name = "toolBarButtonToolbox"
        Me.toolBarButtonToolbox.Size = New System.Drawing.Size(23, 22)
        Me.toolBarButtonToolbox.ToolTipText = "Tool Box"
        '
        'toolBarButtonOutputWindow
        '
        Me.toolBarButtonOutputWindow.Name = "toolBarButtonOutputWindow"
        Me.toolBarButtonOutputWindow.Size = New System.Drawing.Size(23, 22)
        Me.toolBarButtonOutputWindow.ToolTipText = "Output Window"
        '
        'toolBarButtonTaskList
        '
        Me.toolBarButtonTaskList.Name = "toolBarButtonTaskList"
        Me.toolBarButtonTaskList.Size = New System.Drawing.Size(23, 22)
        Me.toolBarButtonTaskList.ToolTipText = "Task List"
        '
        'toolBarButtonSeparator2
        '
        Me.toolBarButtonSeparator2.Name = "toolBarButtonSeparator2"
        Me.toolBarButtonSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolBarButtonLayoutByCode
        '
        Me.toolBarButtonLayoutByCode.Name = "toolBarButtonLayoutByCode"
        Me.toolBarButtonLayoutByCode.Size = New System.Drawing.Size(23, 22)
        Me.toolBarButtonLayoutByCode.ToolTipText = "Show Layout By Code"
        '
        'toolBarButtonLayoutByXml
        '
        Me.toolBarButtonLayoutByXml.Name = "toolBarButtonLayoutByXml"
        Me.toolBarButtonLayoutByXml.Size = New System.Drawing.Size(23, 22)
        Me.toolBarButtonLayoutByXml.ToolTipText = "Show layout by predefined XML file"
        '
        'dockPanel
        '
        Me.dockPanel.ActiveAutoHideContent = Nothing
        Me.dockPanel.BackColor = System.Drawing.SystemColors.Window
        Me.dockPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dockPanel.DockBottomPortion = 150.0R
        Me.dockPanel.DockLeftPortion = 200.0R
        Me.dockPanel.DockRightPortion = 200.0R
        Me.dockPanel.DockTopPortion = 150.0R
        Me.dockPanel.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dockPanel.Location = New System.Drawing.Point(0, 0)
        Me.dockPanel.Name = "dockPanel"
        Me.dockPanel.Size = New System.Drawing.Size(821, 467)
        Me.dockPanel.TabIndex = 0
        '
        'TimerDeploy
        '
        Me.TimerDeploy.Enabled = True
        Me.TimerDeploy.Interval = 7200000
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(821, 489)
        Me.Controls.Add(Me.dockPanel)
        Me.Controls.Add(Me.statusBar)
        Me.Controls.Add(Me.mainMenu)
        Me.Controls.Add(Me.toolBar)
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mainMenu
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Shadows WithEvents dockPanel As Com.Syscom.WinFormsUI.Docking.DockPanel
    Private WithEvents imageList As System.Windows.Forms.ImageList
    Private WithEvents toolBar As System.Windows.Forms.ToolStrip
    Private WithEvents toolBarButtonNew As System.Windows.Forms.ToolStripButton
    Private WithEvents toolBarButtonOpen As System.Windows.Forms.ToolStripButton
    Private WithEvents toolBarButtonSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolBarButtonSolutionExplorer As System.Windows.Forms.ToolStripButton
    Private WithEvents toolBarButtonPropertyWindow As System.Windows.Forms.ToolStripButton
    Private WithEvents toolBarButtonToolbox As System.Windows.Forms.ToolStripButton
    Private WithEvents toolBarButtonOutputWindow As System.Windows.Forms.ToolStripButton
    Private WithEvents toolBarButtonTaskList As System.Windows.Forms.ToolStripButton
    Private WithEvents toolBarButtonSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolBarButtonLayoutByCode As System.Windows.Forms.ToolStripButton
    Private WithEvents toolBarButtonLayoutByXml As System.Windows.Forms.ToolStripButton
    Private WithEvents mainMenu As System.Windows.Forms.MenuStrip
    Private WithEvents menuItemFile As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItem4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents menuItemView As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItem1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents menuItemToolBar As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItemStatusBar As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItem2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents menuItemTools As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItemLockLayout As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItem3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents menuItem6 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents menuItemDockingMdi As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItemDockingSdi As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItemDockingWindow As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItemSystemMdi As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItem5 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents menuItemShowDocumentIcon As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItemWindow As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItemNewWindow As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItemHelp As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuItemAbout As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents statusBar As System.Windows.Forms.StatusStrip
    Private WithEvents showRightToLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents showRightToLeftToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitAsSaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogonInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CloseAllWindowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSetBlackColor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents FontToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MsgStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimerDeploy As System.Windows.Forms.Timer

End Class
