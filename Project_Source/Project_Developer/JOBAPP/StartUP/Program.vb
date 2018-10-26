Imports System.Windows.Forms
Imports System.Data
Imports System.Xml
Imports System.Xml.XPath
Imports System.IO
Imports System.ServiceModel
Imports System.Collections.Specialized
Imports System.Deployment.Application
Imports System.Web
Imports System.Diagnostics
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Client.CMM
Imports Syscom.Client.UCL
Imports Syscom.Client.Servicefactory
Imports System.Security.Cryptography
Imports System.Reflection
Imports System.Text

NotInheritable Class Program

    Private Sub New()
    End Sub

    '去除舊的APP (For 外部系統呼叫EMR使用) 2010-09-14 Add By Alan
    Private Shared Sub releaseOldInstance()
        Try
            Dim appName As String = Process.GetCurrentProcess.ProcessName
            Dim sameProcessTotal As Integer = Process.GetProcessesByName(appName).Length
            If sameProcessTotal > 1 Then
                For Each pc As Process In Process.GetProcessesByName(appName)
                    If pc.Id <> Process.GetCurrentProcess.Id Then
                        pc.Kill()
                        pc.Close()
                        pc.Dispose()
                        pc = Nothing
                    End If
                Next
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    '主要程式入口
    <STAThread()>
    Friend Shared Sub Main()
        Try
            ' add on 2012-11-21 by Lits-------------------------------------------------------
            Dim info As UpdateCheckInfo = Nothing
            Dim doUpdate As Boolean = False
            Dim curFile As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\user.txt"

            If (ApplicationDeployment.IsNetworkDeployed) Then
                Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

                Try
                    info = AD.CheckForDetailedUpdate()

                Catch dde As DeploymentDownloadException
                    MessageBox.Show("無法在此時更新. " + ControlChars.Lf & ControlChars.Lf & "請檢查網路是否正常. 錯誤: " + dde.Message)
                    Return
                Catch ioe As InvalidOperationException
                    MessageBox.Show("更新失敗. 錯誤: " & ioe.Message)
                    Return
                End Try

                If (info.UpdateAvailable) Then
                    doUpdate = True

                    If (Not info.IsUpdateRequired) Then
                        'Dim dr As DialogResult = MessageBox.Show("有新的更新,是否現在更新?", "新醫療系統版本更新", MessageBoxButtons.OKCancel)
                        'If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                        '    doUpdate = False
                        'End If
                    Else
                        ' 顯示最小版本.
                        MessageBox.Show("有新的更新  " &
                            "版本 " & info.MinimumRequiredVersion.ToString() &
                            ". 更新完成後自動重新啟動才生效.",
                            "新醫療系統版本更新", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
                    End If

                    If (doUpdate) Then
                        Try
                            UpdateVersionUI.ShowDialog()
                            'AD.Update()
                            Application.Restart()
                            Return
                        Catch dde As DeploymentDownloadException
                            MessageBox.Show("無法安裝下載更新應用程式. " & ControlChars.Lf & ControlChars.Lf & "請檢查網路狀況或下次再更新.")
                            Return
                        End Try
                    End If
                End If
            End If
            If (doUpdate) Then
                UpdateVersionUI.ShowDialog()

                Application.Restart()
            Else
                '======================================================

                '2010-09-14 Add By Alan
                Dim pvtConnectFlag As Boolean = True
                'Dim pvtQueryParameter As NameValueCollection
                'pvtQueryParameter = GetQueryStringParameters()
                'If pvtQueryParameter.Count > 0 Then
                '    'I : 住院    O: 門診   C: 腫瘤作業系統  E: 急診 V: CIS 加護病房臨床系統
                '    Dim strKey As String = "Pas5pr@s"   'Key 固定八個字元，多或少都不行
                '    Dim pvtLoginTime As String
                '    Dim pvtIntervalTime As Long
                '    ModForm.SystemNo = DESPlus.Decrypt(pvtQueryParameter.Get("SystemNo").ToString.Trim, strKey)
                '    ModForm.UserInfo = DESPlus.Decrypt(pvtQueryParameter.Get("UserInfo").ToString.Trim, strKey)
                '    ModForm.PasswdInfo = DESPlus.Decrypt(pvtQueryParameter.Get("PasswdInfo").ToString.Trim, strKey)
                '    ModForm.ChartNo = DESPlus.Decrypt(pvtQueryParameter.Get("ChartNo").ToString.Trim, strKey)
                '    '傳入時間若超過系統時間5分鐘，則不允許再登入
                '    pvtLoginTime = DESPlus.Decrypt(pvtQueryParameter.Get("LoginTime").ToString.Trim, strKey)
                '    pvtIntervalTime = DateDiff(DateInterval.Minute, CDate(pvtLoginTime), CDate(Now.ToString("yyyy/MM/dd H:m:s")))
                '    If pvtIntervalTime >= 5 Then
                '        pvtConnectFlag = False
                '    End If
                '    '關閉先前開啟的HISApp
                '    releaseOldInstance()
                'End If

                createICCardIni()
                Application.EnableVisualStyles()
                Application.SetCompatibleTextRenderingDefault(True)
                ModForm.DirectoryPath = My.Application.Info.DirectoryPath

                '2010-09-14 Modify By Alan
                Dim loginForm As New LoginForm()
                Dim PassPwdCheck As Boolean

                If ModForm.UserInfo = "" OrElse ModForm.PasswdInfo = "" Then
                    loginForm.ShowDialog()
                End If
                If pvtConnectFlag AndAlso ModForm.UserInfo <> "" OrElse loginForm.DialogResult = DialogResult.OK Then
                    AppContext.userProfile.userOnStationNo = ModForm.StationNo
                    AppContext.userProfile.userOnTermNo = ModForm.TermNo
                    '=====測試期間略過密碼過期的資訊======================================
                    PassPwdCheck = False
                    If (loginForm.UsernameTextBox.Text.Trim.StartsWith("#$")) Then
                        loginForm.UsernameTextBox.Text = loginForm.UsernameTextBox.Text.Substring(2)
                        PassPwdCheck = True
                    End If
                    '=====================================================================

                    '2010-09-14 Modify By Alan
                    If ModForm.UserInfo = "" Then
                        ModForm.UserInfo = loginForm.UsernameTextBox.Text.Trim.ToUpper
                        ModForm.PasswdInfo = loginForm.PasswordTextBox.Text
                    End If

                    If ModForm.UserInfo = "" Or ModForm.PasswdInfo = "" Then
                        MessageHandling.ShowWarnMsg("ARMCMME001", New String() {"帳號或密碼不得為空白"})
                        If System.IO.File.Exists(curFile) Then
                            System.IO.File.Delete(curFile)
                        End If
                        Application.Restart()
                    ElseIf 1 = 2 Then ' ModForm.UserInfo = "SYSCOMLIN" Or ModForm.PasswdInfo = "syscomlin" Then
                        '=========================================================
                        '   測試程式碼(1)：測試直接取得角色權限功能
                        '=========================================================
                        ModForm.UserInfo = "sysadmin"
                        ModForm.PasswdInfo = "syscom1"

                        Dim role As String = "SYS_Admin"
                        Dim dt As DataTable = ArmServiceManager.getInstance.LoginForSys(role)
                        If dt.Rows.Count > 0 Then
                            AppContext.userProfile.userId = ModForm.UserInfo
                            AppContext.userProfile.userName = "系統管理員"
                            AppContext.userProfile.userPw = ModForm.PasswdInfo
                            AppContext.userProfile.userDeptCode = "A5"
                            AppContext.userProfile.userDeptName = "資訊室"
                            AppContext.userProfile.userMemberOf = role
                            AppContext.userProfile.userDrLevel = ""
                            '20130112 add by Rich, 寫入系統來源代碼
                            AppContext.userProfile.systemSourceTypeId = "I"
                            AppContext.userProfile.userOnStationNo = ""

                            ModForm.UserInfoName = "系統管理員"

                            genXML(dt)
                            Application.Run(New MainForm())
                        End If

                    ElseIf ModForm.UserInfo = "test" Or ModForm.PasswdInfo = "test" Then
                        '=========================================================
                        '   測試程式碼(1)：測試直接取得角色權限功能
                        '=========================================================
                        ModForm.UserInfo = "testUser"
                        ModForm.PasswdInfo = "testUser"

                        Dim role As String = "CNC_Admin"
                        Dim dt As DataTable = ArmServiceManager.getInstance.LoginForSys(role)
                        If dt.Rows.Count > 0 Then
                            AppContext.userProfile.userId = ModForm.UserInfo
                            AppContext.userProfile.userName = "測試護理師"
                            AppContext.userProfile.userPw = ModForm.PasswdInfo
                            AppContext.userProfile.userDeptCode = "06B"
                            AppContext.userProfile.userDeptName = "護理部"
                            AppContext.userProfile.userMemberOf = role
                            AppContext.userProfile.userDrLevel = ""
                            '20130112 add by Rich, 寫入系統來源代碼
                            AppContext.userProfile.systemSourceTypeId = "I"

                            ModForm.UserInfoName = "測試護理師"

                            genXML(dt)
                            Application.Run(New MainForm())
                        End If

                    Else

                        Dim ds As DataSet = ArmServiceManager.getInstance.Login(ModForm.UserInfo, ModForm.PasswdInfo, "I")

                        '檢查是否過期
                        Dim userPwdExpireDate As Date = Now
                        '停用密碼過期功能
                        'If Date.TryParse(ds.Tables("UserInfo").Rows(0).Item("user-pwd-expired-date").ToString.Trim, userPwdExpireDate) Then
                        '    If DateDiff(DateInterval.Day, userPwdExpireDate, Now) >= 90 Then
                        '        ds.Tables("UserInfo").Rows(0).Item("user-ErrMessage") = "您的密碼已超過3個月無變更，請記得變更您的密碼並不得沿用上次的密碼，謝謝!!"
                        '    ElseIf DateDiff(DateInterval.Day, userPwdExpireDate, Now) >= 83 Then
                        '        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"您的密碼即將在" & (90 - DateDiff(DateInterval.Day, userPwdExpireDate, Now)) & "天到期，請記得變更您的密碼並不得沿用上次的密碼，謝謝!!"})
                        '    End If
                        'End If
                        If PassPwdCheck = True Then 'By all & CNC follow it Modify by Lits on 2010-07-20
                            If (ds.Tables("UserInfo").Rows(0).Item("user-ErrMessage").ToString.Trim.Contains("密碼已過期")) Or
                               (ds.Tables("UserInfo").Rows(0).Item("user-ErrMessage").ToString.Trim.Contains("密碼有誤")) Then
                                ds.Tables("UserInfo").Rows(0).Item("user-ErrMessage") = ""
                            End If
                        End If
                        '=====================================================================
                        If ds.Tables("UserInfo").Rows(0).Item("user-ErrMessage").ToString.Trim = "" Then
                            'added by cww 2013-7-10，有warning message時要Show
                            If ds.Tables("UserInfo").Rows(0).Item("user-WarningMessage").ToString.Trim <> "" Then
                                MsgBox(ds.Tables("UserInfo").Rows(0).Item("user-WarningMessage").ToString.Trim, MsgBoxStyle.Exclamation, "訊息")
                            End If
                            'end add 

                            AppContext.userProfile.userId = ModForm.UserInfo
                            AppContext.userProfile.userName = ds.Tables("UserInfo").Rows(0).Item("user-name").ToString.Trim
                            AppContext.userProfile.userPw = ModForm.PasswdInfo
                            AppContext.userProfile.userDeptCode = ds.Tables("UserInfo").Rows(0).Item("user-departmentnumber").ToString.Trim
                            AppContext.userProfile.userDeptName = ds.Tables("UserInfo").Rows(0).Item("user-department").ToString.Trim
                            AppContext.userProfile.userMemberOf = ds.Tables("UserInfo").Rows(0).Item("user-memberof").ToString.Trim
                            AppContext.userProfile.userOnStationNo = ""
                            AppContext.userProfile.userOnTermNo = ModForm.TermNo
                            'ADD 高聯醫-醫師所屬科 on 20161020 by Lits
                            AppContext.userProfile.userDrDeptCode = ds.Tables("UserInfo").Rows(0).Item("user-dr-Dept-Code").ToString.Trim
                            AppContext.userProfile.userDrDeptName = ds.Tables("UserInfo").Rows(0).Item("user-dr-Dept-Name").ToString.Trim
                            '20130112 add by Rich, 寫入系統來源代碼
                            AppContext.userProfile.systemSourceTypeId = "I"
                            AppContext.userProfile.userNrsLevelId = ds.Tables("UserInfo").Rows(0).Item("user-nrs-level-id").ToString.Trim

                            If ds.Tables("AppInfo").Rows.Count <> 0 Then
                                genXML(ds.Tables("AppInfo"))
                            Else
                                Dim dsTemp As DataSet = ArmServiceManager.getInstance.FunQueryByLogin
                                genXML(dsTemp.Tables("arm_fun_system"))
                            End If

                            ModForm.UserInfoName = ds.Tables("UserInfo").Rows(0).Item("user-name").ToString.Trim

                            Application.Run(New MainForm())
                        Else
                            If System.IO.File.Exists(curFile) Then
                                System.IO.File.Delete(curFile)
                            End If
                            Dim count As Integer = ArmServiceManager.getInstance.saveLogonFailure(ModForm.UserInfo, AppContext.userProfile.userIP, Environment.MachineName)

                            MessageHandling.ShowWarnMsg("CMMCMMB317", New String() {"登入", "，" & ds.Tables("UserInfo").Rows(0).Item("user-ErrMessage").ToString.Trim})
                            Application.Restart()
                            'Throw New Exception(ds.Tables("UserInfo").Rows(0).Item("user-ErrMessage").ToString.Trim)
                        End If
                    End If
                ElseIf pvtConnectFlag = False Then
                    'MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"已超過可查詢時間，請重新連結網頁"}, "")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            ClientExceptionHandler.ProccessException(ex)
            Dim curFile As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\user.txt"
            If System.IO.File.Exists(curFile) Then
                System.IO.File.Delete(curFile)
            End If
            'Application.Restart()
        End Try
    End Sub

    '建立 XML
    Shared Sub genXML(ByVal dtable As DataTable, Optional ByVal fileName As String = "")
        Try
            If fileName = "" Then
                fileName = AppContext.userProfile.userId
            End If

            Dim myDoc As XmlDocument = getDoc()
            Dim rootTree As Xml.XmlNode = myDoc.SelectSingleNode("TreeView")
            Dim lastsub_no As String = ""
            Dim lasttsk_no As String = ""
            Dim lastElement As XmlElement = Nothing

            For Each drow As DataRow In dtable.Rows

                Dim app_no As String = drow.Item("app_system_no").ToString
                Dim sub_no As String = drow.Item("sub_system_no").ToString
                Dim sub_name As String = drow.Item("sub_system_name").ToString
                Dim tsk_no As String = drow.Item("fun_task_no").ToString
                Dim tsk_name As String = drow.Item("tsk_task_name").ToString
                Dim fun_no As String = drow.Item("fun_function_no").ToString
                Dim fun_name As String = drow.Item("fun_function_name").ToString
                Dim tag As String = drow.Item("fun_content").ToString

                '若不為空又相等 表示不必新增
                'If app_no.Equals("NIS") OrElse app_no.Equals("ARM") Then

                If lastsub_no <> "" And sub_no = lastsub_no Then
                    '相同子系統則略過新增
                Else
                    lastElement = CType(rootTree.AppendChild(myDoc.CreateElement("node")), XmlElement)
                    lastElement.Attributes.Append(myDoc.CreateAttribute("level"))
                    lastElement.Attributes.Append(myDoc.CreateAttribute("text"))
                    lastElement.Attributes.Append(myDoc.CreateAttribute("imageindex"))
                    lastElement.Attributes.Append(myDoc.CreateAttribute("tag"))
                    lastElement.Attributes.Append(myDoc.CreateAttribute("subno"))
                    lastElement.Attributes.Append(myDoc.CreateAttribute("tskno"))
                    lastElement.Attributes.Append(myDoc.CreateAttribute("funno"))
                    lastElement.Attributes("level").Value = "0"
                    lastElement.Attributes("text").Value = sub_name
                    lastElement.Attributes("imageindex").Value = "0"
                    lastElement.Attributes("tag").Value = ""
                    lastElement.Attributes("subno").Value = sub_no
                    lastElement.Attributes("tskno").Value = tsk_no
                    lastElement.Attributes("funno").Value = fun_no
                    lastsub_no = sub_no
                End If

                If lasttsk_no <> "" And tsk_no = lasttsk_no Then
                    '相同作業則略過新增
                Else
                    Dim subnode As XmlElement = CType(lastElement.AppendChild(myDoc.CreateElement("node")), XmlElement)
                    subnode.Attributes.Append(myDoc.CreateAttribute("level"))
                    subnode.Attributes.Append(myDoc.CreateAttribute("text"))
                    subnode.Attributes.Append(myDoc.CreateAttribute("imageindex"))
                    subnode.Attributes.Append(myDoc.CreateAttribute("tag"))
                    subnode.Attributes.Append(myDoc.CreateAttribute("subno"))
                    subnode.Attributes.Append(myDoc.CreateAttribute("tskno"))
                    subnode.Attributes.Append(myDoc.CreateAttribute("funno"))
                    subnode.Attributes("level").Value = "1"
                    subnode.Attributes("text").Value = tsk_name
                    subnode.Attributes("imageindex").Value = "0"
                    subnode.Attributes("tag").Value = ""
                    subnode.Attributes("subno").Value = sub_no
                    subnode.Attributes("tskno").Value = tsk_no
                    subnode.Attributes("funno").Value = fun_no
                    lasttsk_no = tsk_no
                End If

                Dim funnode As XmlElement = CType(lastElement.AppendChild(myDoc.CreateElement("node")), XmlElement)
                funnode.Attributes.Append(myDoc.CreateAttribute("level"))
                funnode.Attributes.Append(myDoc.CreateAttribute("text"))
                funnode.Attributes.Append(myDoc.CreateAttribute("imageindex"))
                funnode.Attributes.Append(myDoc.CreateAttribute("tag"))
                funnode.Attributes.Append(myDoc.CreateAttribute("subno"))
                funnode.Attributes.Append(myDoc.CreateAttribute("tskno"))
                funnode.Attributes.Append(myDoc.CreateAttribute("funno"))
                funnode.Attributes("level").Value = "2"
                funnode.Attributes("text").Value = fun_name
                funnode.Attributes("imageindex").Value = "0"
                funnode.Attributes("tag").Value = tag
                funnode.Attributes("subno").Value = sub_no
                funnode.Attributes("tskno").Value = tsk_no
                funnode.Attributes("funno").Value = fun_no

                ' End If
            Next
            Dim myWriter As New Xml.XmlTextWriter("AuthList" & fileName & ".xml", System.Text.Encoding.Unicode)
            myWriter.Formatting = Xml.Formatting.Indented
            myDoc.Save(myWriter)
            myWriter.Close()
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    '建立系統功能選單
    Shared Function getDoc() As XmlDocument
        Try
            Dim doc As XmlDocument = New XmlDocument
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-16", String.Empty))
            Dim rootNode As XmlElement = CType(doc.AppendChild(doc.CreateElement("TreeView")), XmlElement)
            'Hospital", "成大醫院HIS系統"
            rootNode.Attributes.Append(doc.CreateAttribute("Hospital"))
            rootNode.Attributes("Hospital").Value = JOBAPP.ControlUtil.AppLoginFormTitle & "專案管理系統" ' HospUtil.AppName
            Dim systemNode As XmlElement = CType(rootNode.AppendChild(doc.CreateElement("system")), XmlElement)
            systemNode.Attributes.Append(doc.CreateAttribute("menu0"))
            systemNode.Attributes("menu0").Value = "系統功能"
            'systemNode.Attributes.Append(doc.CreateAttribute("menu1"))
            'systemNode.Attributes("menu1").Value = "我的病人"
            'systemNode.Attributes.Append(doc.CreateAttribute("menu2"))
            'systemNode.Attributes("menu2").Value = "我的最愛"
            '2016/10/27 限制顯示我的病人 BY 高佳慧
            Dim CurrentMenberOf As String = AppContext.userProfile.userMemberOf
            Dim CNCRole As String = PubServiceManager.getInstance.GetPubConfigValue("CNC_MyPatientRole")
            Dim aryRole As String() = Nothing
            Dim bolAddMyPatient As Boolean = False
            If CNCRole.Length > 0 Then
                aryRole = CNCRole.Split(",")
            End If
            If Not IsNothing(aryRole) Then
                For i As Integer = 0 To aryRole.Length - 1
                    If CurrentMenberOf.Contains(aryRole(i)) Then
                        bolAddMyPatient = True
                        Exit For
                    End If
                Next
            End If
            If bolAddMyPatient Then
                systemNode.Attributes.Append(doc.CreateAttribute("menu1"))
                systemNode.Attributes("menu1").Value = "我的病人"
                systemNode.Attributes.Append(doc.CreateAttribute("menu2"))
                systemNode.Attributes("menu2").Value = "我的最愛"
            Else
                systemNode.Attributes.Append(doc.CreateAttribute("menu1"))
                systemNode.Attributes("menu1").Value = "我的最愛"
            End If

            'If CurrentMenberOf.Contains("CNC_Admin") Or CurrentMenberOf.Contains("CNC_DP") Or CurrentMenberOf.Contains("CNC_HN") Or CurrentMenberOf.Contains("CNC_MN") _
            '  Or CurrentMenberOf.Contains("CNC_NP") Or CurrentMenberOf.Contains("CNC_SUP") Or CurrentMenberOf.Contains("CNC_User") or Or CurrentMenberOf.Contains("SYS_Admin") Then
            '    systemNode.Attributes.Append(doc.CreateAttribute("menu1"))
            '    systemNode.Attributes("menu1").Value = "我的病人"
            'End If

            'systemNode.Attributes.Append(doc.CreateAttribute("menu3"))
            ''systemNode.Attributes("menu3").Value = "系統版本更新記錄查詢"
            'systemNode.Attributes.Append(doc.CreateAttribute("menu4")) 'add on 2012-05-10 by Lits for 急診切換使用者-----
            'systemNode.Attributes("menu4").Value = "切換使用者"
            'systemNode.Attributes.Append(doc.CreateAttribute("menu5"))
            'systemNode.Attributes("menu5").Value = "登出"
            'systemNode.Attributes.Append(doc.CreateAttribute("menu6"))
            'systemNode.Attributes("menu6").Value = "結束"
            'systemNode.Attributes.Append(doc.CreateAttribute("menu6"))
            'systemNode.Attributes("menu6").Value = "關於"
            Return doc
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function

    '建立IC卡設定檔
    Shared Sub createICCardIni()
        Try
            Dim dirPath As String = "C:\Log"
            Dim dir As New DirectoryInfo(dirPath)

            If Not dir.Exists Then
                dir.Create()
            End If

            Dim file As New FileInfo(dirPath & "\ICCard.ini")
            If Not file.Exists Then
                Dim sw As StreamWriter = file.CreateText
                sw.WriteLine("CacheTime=8")
                sw.WriteLine("LogPath=C:\Log\ICCard.log")
                sw.WriteLine("ClientComPort=0")
                sw.WriteLine("HospitalComPort=0")
                sw.WriteLine("HomeComPort=0")
                sw.WriteLine("PsychiatricComPort=0")
                sw.WriteLine("Category=")
                sw.WriteLine("CardReader=Y")
                sw.Flush()
                sw.Close()
            End If
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub

    '取得URL傳入字串-2010-09-14 Add By Alan
    Shared Function GetQueryStringParameters() As NameValueCollection
        Try
            Dim NameValueTable As New NameValueCollection()
            Dim QueryString As String = ""

            If (ApplicationDeployment.IsNetworkDeployed) AndAlso ApplicationDeployment.CurrentDeployment.ActivationUri IsNot Nothing Then
                QueryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query
                NameValueTable = HttpUtility.ParseQueryString(QueryString)
            End If

            Return NameValueTable
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function


    Shared Sub UpdateHISVerUpdateExe(ByVal fileName As String)

        Try
            Dim _credentials As System.Net.NetworkCredential = New System.Net.NetworkCredential("ftpUser", "syscom")

            Dim _request As System.Net.FtpWebRequest = System.Net.FtpWebRequest.Create("ftp://Win-2017.syscom.com.tw/JOBCompare/Client/" & fileName)
            _request.KeepAlive = False
            _request.Method = System.Net.WebRequestMethods.Ftp.DownloadFile
            _request.Credentials = _credentials
            Dim _response As System.Net.FtpWebResponse = _request.GetResponse()
            Dim responseStream As System.IO.Stream = _response.GetResponseStream()
            Using fs As New System.IO.FileStream(System.Windows.Forms.Application.StartupPath & "\" & fileName, System.IO.FileMode.Create)
                responseStream.CopyTo(fs)
                responseStream.Close()
                _response.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Download Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ''' <summary>
    ''' 密碼的解密相關功能
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-9-2 Copy from Lits</remarks>
    Public Shared Function Decrypt(ByVal pToDecrypt As String, Optional ByVal sKey As String = "abcdefgh") As String
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim des As New DESCryptoServiceProvider()
            '把字符串放入byte數組
            Dim len As Integer
            len = pToDecrypt.Length / 2 - 1
            Dim inputByteArray(len) As Byte
            Dim x, i As Integer
            For x = 0 To len
                i = Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16)
                inputByteArray(x) = CType(i, Byte)
            Next
            '建立加密對象的密鑰和偏移量，此值重要，不能修改
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey)
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey)
            Dim ms As New System.IO.MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor, CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Encoding.Default.GetString(ms.ToArray)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



End Class
