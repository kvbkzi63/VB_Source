Imports System.Windows.Forms

Imports Syscom.Client.UCL
Imports System.Data
'Imports System.Diagnostics
'
Imports Syscom.Comm.Utility
Imports System.Xml
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM
'

Public Class SwitchUserUI
    Dim PassPwdCheck As Boolean

#Region "   功能函數"

    Private Sub SwitchUserUI_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        PasswordTextBox.Focus()
    End Sub
    Private Sub SwitchUserUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "切換使用者"
        UsernameTextBox.Text = AppContext.userProfile.userId
        TxtStationNo.Text = AppContext.userProfile.userOnStationNo

    End Sub

    Private Sub Btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OK.Click

        switchLogin()
    End Sub
    Shared Function queryStationByTermCode(ByVal tCode As String) As String
        'Default 護理站
        Dim retDs As DataSet = PubServiceManager.getInstance.queryStationByTermCode(tCode)
        If retDs.Tables(0).Rows.Count > 0 Then

            Return retDs.Tables(0).Rows(0).Item("Station_No").ToString.Trim
        End If
        Return ""
    End Function
    Private Sub switchLogin()
        If checkStation() = True Then
            '=====測試期間略過密碼過期的資訊======================================
            PassPwdCheck = False
            If (Me.UsernameTextBox.Text.Trim.StartsWith("#$")) Then
                Me.UsernameTextBox.Text = Me.UsernameTextBox.Text.Substring(2)
                PassPwdCheck = True
            End If
            '=====================================================================
            Dim retMsg As String = ""
            Dim _user As String = Me.UsernameTextBox.Text
            Dim _pwd As String = Me.PasswordTextBox.Text
            Dim _stationNo As String = Me.TxtStationNo.Text
            retMsg = checkUser(_user, _pwd, _stationNo)
            If retMsg = "" Then
                Me.Close()
            Else
                showWarnMsg("ARMCMME001", New String() {retMsg})
                Exit Sub
            End If
        Else
            Exit Sub

        End If

    End Sub

    Private Sub Btn_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Exit.Click
        'Me.flag = "N"
        'Me.Close()
        Application.ExitThread()
        Application.Exit()
    End Sub


    '輸入6碼自動跳到Password
    Private Sub UsernameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsernameTextBox.TextChanged
        Try
            Dim str As String = (UsernameTextBox.Text).Substring(0, 1)
            If str >= "0" And str <= "9" Then
                If UsernameTextBox.Text.Length = 6 Then
                    PasswordTextBox.Focus()
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub TxtStationNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStationNo.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Enter)
                switchLogin()
        End Select
    End Sub
#End Region

#Region "   檢查邏輯"
    Function checkStation() As Boolean
        Dim parmTxt As String = (Me.TxtStationNo.Text).ToUpper
        If parmTxt.Length = 1 Then
            parmTxt = "00" & parmTxt
        ElseIf parmTxt.Length = 2 Then
            parmTxt = "0" & parmTxt
        End If
        Dim stationNo As String = queryStationByTermCode(parmTxt)
        If stationNo <> "" Then

            '判斷單位長度，等於2要補零
            If stationNo.Length = 2 Then

                stationNo = "0" & stationNo

            End If

            ModForm.StationNo = stationNo
            Return True

        Else
            showWarnMsg("ARMCMME001", New String() {"單位不存在或單位不能為空白"})
            Return False
            Exit Function
        End If


    End Function
    Function checkUser(ByVal userID As String, ByVal pwd As String, ByVal stationNo As String) As String
        Dim ds As DataSet = Syscom.Client.Servicefactory.ArmServiceManager.getInstance.Login(userID, pwd)

        '2014-01-27 Sean 移除醫師判斷
        'Dim drInfor = Syscom.Client.Servicefactory.PubServiceManager.getInstance.loginDr(userID)
        'If drInfor <> "" Then
        '    Return drInfor
        'End If

        If (ds.Tables("UserInfo").Rows(0).Item("user-ErrMessage").ToString.Trim.Contains("密碼已過期")) Or _
                           (ds.Tables("UserInfo").Rows(0).Item("user-ErrMessage").ToString.Trim.Contains("密碼有誤")) Then
            If PassPwdCheck = True Then
                ModForm.UserInfo = userID
                ModForm.PasswdInfo = pwd
                ModForm.StationNo = stationNo

                ds.Tables("UserInfo").Rows(0).Item("user-ErrMessage") = ""
            Else
                Return ds.Tables("UserInfo").Rows(0).Item("user-ErrMessage").ToString.Trim
            End If
            newMenu(ds)
        Else
            ModForm.UserInfo = userID
            ModForm.PasswdInfo = pwd
            ModForm.StationNo = stationNo
            newMenu(ds)

        End If
        Return ""
    End Function
#End Region

#Region "   功能選單"
    Shared Function newMenu(ByVal ds As DataSet) As String

        LOGDelegate.getInstance.fileDebugMsg("開始呼叫主畫面的前置程序：" & Now.ToString("yyyy-MM-dd HH:mm:ss"))

        AppContext.userProfile.userId = ModForm.UserInfo
        AppContext.userProfile.userName = ds.Tables("UserInfo").Rows(0).Item("user-name").ToString.Trim
        AppContext.userProfile.userPw = ModForm.PasswdInfo
        AppContext.userProfile.userDeptCode = ds.Tables("UserInfo").Rows(0).Item("user-departmentnumber").ToString.Trim
        AppContext.userProfile.userDeptName = ds.Tables("UserInfo").Rows(0).Item("user-department").ToString.Trim
        AppContext.userProfile.userMemberOf = ds.Tables("UserInfo").Rows(0).Item("user-memberof").ToString.Trim
        AppContext.userProfile.userOnStationNo = ModForm.StationNo

        ModForm.UserInfoName = ds.Tables("UserInfo").Rows(0).Item("user-name").ToString.Trim

        'Dim drDS As DataSet = ArmServiceManager.getInstance.queryPubDoctorByEmployeeCodeK(ModForm.UserInfo)
        'If drDS IsNot Nothing AndAlso drDS.Tables.Count > 0 AndAlso drDS.Tables(0).Rows.Count > 0 Then
        '    AppContext.userProfile.userDrLevel = drDS.Tables(0).Rows(0).Item("Level_Id").ToString.Trim
        'Else
        AppContext.userProfile.userDrLevel = ""
        'End If

        If ds.Tables("AppInfo").Rows.Count <> 0 Then
            genXML(ds.Tables("AppInfo"))
        Else
            Dim dsTemp As DataSet = ArmServiceManager.getInstance.FunQueryByLogin
            genXML(dsTemp.Tables("arm_fun_system"))
        End If
        Return ""
    End Function

    '建立XML
    Shared Sub genXML(ByVal dtable As DataTable)
        Try
            Dim myDoc As XmlDocument = Program.getDoc()
            Dim rootTree As Xml.XmlNode = myDoc.SelectSingleNode("TreeView")

            Dim lastsub_no As String = ""
            Dim lasttsk_no As String = ""
            Dim lastElement As XmlElement = Nothing
            For Each drow As DataRow In dtable.Rows
                Dim tsk_no As String = drow.Item("fun_task_no").ToString
                Dim sub_no As String = drow.Item("sub_system_no").ToString
                Dim tag As String = drow.Item("fun_content").ToString
                Dim fun_name As String = drow.Item("fun_function_name").ToString
                '20090224 add by Rich
                Dim sub_name As String = drow.Item("sub_system_name").ToString
                Dim tsk_name As String = drow.Item("tsk_task_name").ToString
                Dim app_no As String = drow.Item("app_system_no").ToString
                Dim fun_no As String = drow.Item("fun_function_no").ToString
                '若不為空又相等 表示不必新增
                If app_no.Equals("PCS") OrElse app_no.Equals("HIS") Then
                    If lastsub_no <> "" And sub_no = lastsub_no Then
                    Else
                        lastElement = CType(rootTree.AppendChild(myDoc.CreateElement("node")), XmlElement)
                        lastElement.Attributes.Append(myDoc.CreateAttribute("level"))
                        lastElement.Attributes.Append(myDoc.CreateAttribute("text"))
                        lastElement.Attributes.Append(myDoc.CreateAttribute("imageindex"))
                        lastElement.Attributes.Append(myDoc.CreateAttribute("tag"))
                        lastElement.Attributes.Append(myDoc.CreateAttribute("functionno"))
                        lastElement.Attributes("level").Value = "0"
                        lastElement.Attributes("text").Value = sub_name
                        lastElement.Attributes("imageindex").Value = "0"
                        lastElement.Attributes("tag").Value = ""
                        lastElement.Attributes("functionno").Value = ""
                        lastsub_no = sub_no
                    End If

                    If lasttsk_no <> "" And tsk_no = lasttsk_no Then
                    Else
                        Dim subnode As XmlElement = CType(lastElement.AppendChild(myDoc.CreateElement("node")), XmlElement)
                        subnode.Attributes.Append(myDoc.CreateAttribute("level"))
                        subnode.Attributes.Append(myDoc.CreateAttribute("text"))
                        subnode.Attributes.Append(myDoc.CreateAttribute("imageindex"))
                        subnode.Attributes.Append(myDoc.CreateAttribute("tag"))
                        subnode.Attributes.Append(myDoc.CreateAttribute("functionno"))
                        subnode.Attributes("level").Value = "1"
                        subnode.Attributes("text").Value = tsk_name
                        subnode.Attributes("imageindex").Value = "0"
                        subnode.Attributes("tag").Value = ""
                        subnode.Attributes("functionno").Value = ""
                        lasttsk_no = tsk_no
                    End If


                    Dim funnode As XmlElement = CType(lastElement.AppendChild(myDoc.CreateElement("node")), XmlElement)
                    funnode.Attributes.Append(myDoc.CreateAttribute("level"))
                    funnode.Attributes.Append(myDoc.CreateAttribute("text"))
                    funnode.Attributes.Append(myDoc.CreateAttribute("imageindex"))
                    funnode.Attributes.Append(myDoc.CreateAttribute("tag"))
                    funnode.Attributes.Append(myDoc.CreateAttribute("functionno"))
                    funnode.Attributes("level").Value = "2"
                    funnode.Attributes("text").Value = fun_name
                    funnode.Attributes("imageindex").Value = "0"
                    funnode.Attributes("tag").Value = tag
                    funnode.Attributes("functionno").Value = fun_no
                End If
            Next
            Dim myWriter As New Xml.XmlTextWriter("AuthList.xml", System.Text.Encoding.Unicode)
            myWriter.Formatting = Xml.Formatting.Indented
            myDoc.Save(myWriter)
            myWriter.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '    '<system menu0="系統功能" menu1="儲存個人化設定" menu2="載入個人化設定" menu3="啟動程式選單" menu4="登出" menu5="結束" menu6="關於" />
    '    Shared Function getDoc() As XmlDocument
    '        Try
    '            Dim doc As XmlDocument = New XmlDocument
    '            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-16", String.Empty))
    '            Dim rootNode As XmlElement = CType(doc.AppendChild(doc.CreateElement("TreeView")), XmlElement)
    '            'Hospital", "成大醫院HIS系統"
    '            rootNode.Attributes.Append(doc.CreateAttribute("Hospital"))

    '            rootNode.Attributes("Hospital").Value = "成大醫院PCS系統"

    '            Dim systemNode As XmlElement = CType(rootNode.AppendChild(doc.CreateElement("system")), XmlElement)
    '            systemNode.Attributes.Append(doc.CreateAttribute("menu0"))
    '            systemNode.Attributes("menu0").Value = "系統功能"
    '            'systemNode.Attributes.Append(doc.CreateAttribute("menu1"))
    '            'systemNode.Attributes("menu1").Value = "儲存個人化設定"
    '            'systemNode.Attributes.Append(doc.CreateAttribute("menu2"))
    '            'systemNode.Attributes("menu2").Value = "載入個人化設定"
    '            systemNode.Attributes.Append(doc.CreateAttribute("menu3"))
    '            systemNode.Attributes("menu3").Value = "系統版本更新記錄查詢"
    '            systemNode.Attributes.Append(doc.CreateAttribute("menu4"))
    '            systemNode.Attributes("menu4").Value = "切換使用者"
    '            systemNode.Attributes.Append(doc.CreateAttribute("menu5"))
    '            systemNode.Attributes("menu5").Value = "登出"
    '            systemNode.Attributes.Append(doc.CreateAttribute("menu6"))
    '            systemNode.Attributes("menu6").Value = "結束"
    '            Return doc
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Function

#End Region

#Region "   屬性"
    Private m_Flag As String = "" '取消
    Public Property flag() As System.String
        Get
            Return m_Flag
        End Get

        Set(ByVal _value As String)
            m_Flag = _value
        End Set
    End Property

#End Region

#Region "   訊息傳遞的Event"
    '接取訊息傳遞的Event-Error
    Shared Sub showErrorMsg(ByVal inErrorCode As String, ByVal inMessage As String(), ByVal inDetail As String)
        Try
            Dim OpenMessageDlg As New UCLMessageHandlingUI(UCLMessageHandlingUI.STATUS.ERR, inErrorCode, inMessage, inDetail)
            OpenMessageDlg.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '接取訊息傳遞的Event-Warn
    Shared Sub showWarnMsg(ByVal inErrorCode As String, ByVal inMessage As String())
        Try
            Dim OpenMessageDlg As New UCLMessageHandlingUI(UCLMessageHandlingUI.STATUS.WARN, inErrorCode, inMessage)
            OpenMessageDlg.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


    Private Sub TxtStationNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtStationNo.TextChanged

    End Sub
End Class