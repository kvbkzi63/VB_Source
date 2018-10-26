Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.DataSetUtil
Imports Syscom.Comm.EXP
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.ServiceModel
Imports Syscom.Comm.TableFactory

Public Class NFCGroupMantainUI
    Inherits Syscom.Client.UCL.BaseFormUI

#Region "     變數宣告 "
    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId
    Private NfcService As NfcServiceManager = Nothing
    Private Pubservice As PubServiceManager = PubServiceManager.getInstance()
#End Region

#Region "     按鈕事件 "
    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        SaveData()
    End Sub
    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        ClearData()
    End Sub
#End Region

#Region "     初始化 - 初始化控制項 "

    ''' <summary>
    ''' 初始化 - 初始化控制項
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Public Sub New()
        Try
            '初始化控制項
            InitializeComponent()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - 初始化控制項"})
        End Try
    End Sub

#End Region

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Public Sub ShownMe() Handles Me.Shown
        Try

            '取得所有員工資料
            Dim InitialDS As DataSet = Pubservice.queryEmployeeALL()

            '初始化Combobox
            InitialCbo(InitialDS)

            '產生群組的基本的樹
            createBasicTreeDept()

            '產生我的病人的基本的樹
            createBasicTreeGroup()

            '將資料設定至我的病人的樹狀結構
            'setTreeListGroup(InitialDS)

            '將登入群組資料設定至Cbo
            'PcsuclCbo_Station.SelectedValue = AppContext.userProfile.userOnStationNo


        Catch cmex As CommonException
            ClientExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(New CommonException("CMMCMMB302", ex, New String() {"初始化 - 顯示UI"}))
        End Try
    End Sub

#End Region

#Region "     初始化Combobox "

    ''' <summary>
    ''' 初始化Combobox
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-1-9</remarks>
    Private Sub InitialCbo(ByVal inputDS As DataSet)
        Try
            '初始化 科室(uclCbo_Dept)
            If inputDS.Tables("department").Rows.Count > 0 Then
                uclCbo_Dept.DataSource = inputDS.Tables("department").Copy
                uclCbo_Dept.uclDisplayIndex = "3"
                uclCbo_Dept.uclValueIndex = "2"
            End If
            '初始化 群組(uclCbo_NfcGroup)
            'If inputDS.Tables("NfcGroup").Rows.Count > 0 Then
            '    uclCbo_NfcGroup.DataSource = inputDS.Tables("NfcGroup").Copy
            '    uclCbo_NfcGroup.uclDisplayIndex = "3"
            '    uclCbo_NfcGroup.uclValueIndex = "2"
            'End If
            refanceGroup()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化Combobox"})
        End Try
    End Sub

#End Region

#Region "更新群組cbo"
    Private Sub refanceGroup()
        Try
            Dim groupDS As DataSet = NfcServiceManager.getInstance.queryGroupByUser(CurrentUserID)
            If groupDS.Tables(0).Rows.Count > 0 Then
                uclCbo_NfcGroup.DataSource = groupDS.Tables(0)
                uclCbo_NfcGroup.uclDisplayIndex = "3"
                uclCbo_NfcGroup.uclValueIndex = "2"
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化Combobox"})
        End Try
    End Sub
#End Region

#Region "     將資料顯示至樹狀結構 - tre_Group  "

    ''' <summary>
    ''' 將資料顯示至樹狀結構 - tre_Group 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Sub setTreeListGroup(ByVal inputDS As DataSet)
        Try
            'M.	我的病人

            '建立基本的Node
            createBasicTreeGroup()

            '檢查有沒有 我的病人 病患
            If inputDS.Tables("Nfc_Group_Maintain").Rows.Count > 0 Then

                '因檢查過，有值才長樹，所以不再檢查
                For i As Integer = 0 To inputDS.Tables("Nfc_Group_Maintain").Rows.Count - 1

                    '產生節點
                    InsertNode(inputDS.Tables("Nfc_Group_Maintain").Rows(i), tre_MyPatient.Nodes.Find("M", False)(0))
                Next

                '展開所有的樹
                tre_MyPatient.ExpandAll()
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"將資料顯示至樹狀結構 - tre_MyPatient"})
        End Try
    End Sub

#End Region

#Region "     產生基本的樹跟根節點 - tre_Group "

    ''' <summary>
    ''' 產生基本的樹跟根節點 - tre_Group 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Sub createBasicTreeGroup()
        Try
            'M.	我的病人
            '清除所有節點
            Me.tre_MyPatient.Nodes.Clear()
            tre_MyPatient.Nodes.Add("M", "群組")
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"產生基本的樹跟根節點 - tre_MyPatient"})
        End Try
    End Sub

#End Region

#Region "     將資料顯示至樹狀結構 - tre_Dept  "

    ''' <summary>
    ''' 將資料顯示至樹狀結構 - tre_Dept 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Sub setTreeListDept(ByVal inputDS As DataSet)
        Try
            'S.	科室

            '建立基本的Node
            createBasicTreeDept()

            '檢查有沒有 我的病人 病患
            If inputDS.Tables("PUB_Employee").Rows.Count > 0 Then

                '因檢查過，有值才長樹，所以不再檢查
                For i As Integer = 0 To inputDS.Tables("PUB_Employee").Rows.Count - 1

                    '產生節點
                    InsertNode(inputDS.Tables("PUB_Employee").Rows(i), tre_Dept.Nodes.Find("S", False)(0))
                Next

                '展開所有的樹
                tre_Dept.ExpandAll()
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"將資料顯示至樹狀結構 - tre_Station"})
        End Try
    End Sub

#End Region

#Region "     產生基本的樹跟根節點 - tre_Dept "

    ''' <summary>
    ''' 產生基本的樹跟根節點 - tre_Dept 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Sub createBasicTreeDept()
        Try
            'S.	群組
            '清除所有節點
            Me.tre_Dept.Nodes.Clear()
            tre_Dept.Nodes.Add("S", uclCbo_Dept.SelectedValue)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"產生基本的樹跟根節點 - tre_Station"})
        End Try
    End Sub

#End Region

#Region "     產生節點 "

    ''' <summary>
    ''' 產生節點
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Sub InsertNode(ByVal inputDR As DataRow, ByRef inputNode As TreeNode)
        Dim returntreeNode As TreeNode
        Try
            '病床號 + 姓名
            Dim localPatientName As String = nvl(inputDR.Item("name2").ToString)

            '住院號
            Dim localCaseNo As String = nvl(inputDR.Item("code2").ToString)

            '產生病患姓名的節點
            returntreeNode = New TreeNode(localPatientName)

            '將住院號加入節點中
            returntreeNode.Tag = localCaseNo
            inputNode.Nodes.Add(localCaseNo, localPatientName)
            inputNode.Nodes.Find(localCaseNo, False)(0).Tag = localCaseNo

            '將節點加入樹狀結構
            'inputNode.Nodes.(localCaseNo, returntreeNode)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"產生節點"})
        End Try
    End Sub

#End Region

#Region "     科室 Cbo 選擇時的相應動作 "

    ''' <summary>
    ''' 科室 Cbo 選擇時的相應動作
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Sub uclCbo_DeptSelectIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uclCbo_Dept.SelectedIndexChanged
        Try
            '鎖定螢幕
            Lock(Me)

            '如果有選到值
            If Not uclCbo_Dept.SelectedValue = "" Then

                '查詢科室的員工
                Dim QueryDS As DataSet = Pubservice.queryEmployeeByDept(uclCbo_Dept.SelectedValue)

                '將資料設定至科室病人的樹狀結構
                setTreeListDept(QueryDS)
            End If
        Catch cmex As CommonException
            ClientExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(New CommonException("CMMCMMB302", ex, New String() {"科室 Cbo 選擇時的相應動作"}))
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try
    End Sub
    ''' <summary>
    ''' 群組 Cbo 選擇時的相應動作
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Sub uclCbo_NfcGroupSelectIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uclCbo_NfcGroup.SelectedIndexChanged
        Try

            '鎖定螢幕
            Lock(Me)

            '如果有選到值
            If Not uclCbo_NfcGroup.SelectedValue = "" Then

                '查詢科室的員工
                NfcService = NfcServiceManager.getInstance
                Dim QueryDS As DataSet = NfcService.queryGroupMember(uclCbo_NfcGroup.SelectedValue)
                'NfcService.NotifyUIWithStartAndEndTime({"1,", "2"}, "qqq", "msg", "2015-01-21 00:00", "2099-01-21 00:00", "111", "222", "333", "444", "sys", "Y")
                '將資料設定至群組病人的樹狀結構
                setTreeListGroup(QueryDS)
                btn_AddFromTree.Enabled = True
                If QueryDS.Tables(0).Rows.Count = 0 Then

                    txt_GroupID.Text = uclCbo_NfcGroup.SelectedValue
                    txt_groupName.Text = uclCbo_NfcGroup.Text
                Else
                    txt_GroupID.Text = ""
                    txt_groupName.Text = ""
                End If
            Else
                btn_AddFromTree.Enabled = False
                txt_GroupID.Text = ""
                txt_groupName.Text = ""
            End If
        Catch cmex As CommonException
            ClientExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(New CommonException("CMMCMMB302", ex, New String() {"群組 Cbo 選擇時的相應動作"}))
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try
    End Sub
#End Region

#Region "     加入-> 鎖定功能 "

    ''' <summary>
    ''' 加入-> 鎖定功能
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Sub btn_AddFromTree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddFromTree.Click
        Try
            Lock(Me)
            ClearInfoMsg()
            If (AddFromTree()) Then

                '左下方顯示 清除 成功
                ShowInfoMsg("CMMCMMB301", "加入")
            End If
        Catch cmex As CommonException
            ClientExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(New CommonException("CMMCMMB302", ex, New String() {"加入-> 鎖定功能"}))
        Finally
            UnLock(Me)
        End Try
    End Sub

#End Region

#Region "     <-移除 鎖定功能 "

    ''' <summary>
    ''' 移除 鎖定功能
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Sub btn_RemoveFromTree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RemoveFromTree.Click
        Try
            Lock(Me)
            ClearInfoMsg()
            If (RemoveFromTree()) Then

                '左下方顯示 清除 成功
                ShowInfoMsg("CMMCMMB301", "移除")
            End If
        Catch cmex As CommonException
            ClientExceptionHandler.ProccessException(cmex)
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(New CommonException("CMMCMMB302", ex, New String() {"<-移除 鎖定功能"}))
        Finally
            UnLock(Me)
        End Try
    End Sub

#End Region

#Region "     按鈕事件 "

    ''' <summary>
    ''' 儲存
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Function SaveData() As Boolean
        Try
            Dim returnBoolean As Boolean = False

            '建立一個格式為 CNCMyPatient的 DS
            Dim insertDS As DataSet = GetSaveData()

            '判斷是否有資料，有的話才存檔；或者是允許為零
            If insertDS.Tables(0).Rows.Count > 0 Then

                '儲存至 DB
                Dim count As Integer = NfcService.insertGroupMember(insertDS)
                '左下方顯示 清除 成功
                ShowInfoMsg("CMMCMMB301", "新增")
            Else
                ShowWarnMsg("CMMCMMB300", "群組或成員不可為空，請重新選擇")
            End If
            Return returnBoolean
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"儲存"})
        End Try
    End Function

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Function ClearData() As Boolean
        Try
            Dim returnBoolean As Boolean = False

            '初始化至原始狀態
            createBasicTreeGroup()
            '左下方顯示 清除 成功
            ShowInfoMsg("CMMCMMB301", "清除")
            Return returnBoolean
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"清除"})
        End Try
    End Function

    ''' <summary>
    ''' 加入->
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Function AddFromTree() As Boolean
        Try
            Dim returnBoolean As Boolean = True

            If Not tre_Dept.Nodes.Find("S", False) Is Nothing Then

                For i As Integer = tre_Dept.Nodes.Find("S", False)(0).Nodes.Count - 1 To 0 Step -1
                    If tre_Dept.Nodes.Find("S", False)(0).Nodes(i).Checked Then

                        '有選到節點才能加入，故不再判斷是否存在
                        Dim AddNode As TreeNode = tre_Dept.Nodes.Find("S", False)(0).Nodes(i).Clone

                        '還原打勾狀態
                        AddNode.Checked = False

                        '如果沒有才加入 我的病人 樹狀結構
                        If tre_MyPatient.Nodes.Find(AddNode.Tag.ToString, True).Length = 0 Then

                            '將節點加入 我的病人 樹狀結構
                            tre_MyPatient.Nodes.Find("M", False)(0).Nodes.Add(AddNode.Tag.ToString, AddNode.Text.ToString)

                            '加入Tag
                            tre_MyPatient.Nodes.Find("M", False)(0).Nodes.Find(AddNode.Tag.ToString, False)(0).Tag = AddNode.Tag.ToString
                        End If

                        '將節點移出 群組查詢 樹狀結構
                        tre_Dept.Nodes.Find("S", False)(0).Nodes(i).Remove()
                    End If
                Next

            Else

                ShowWarnMsg("CMMCMMB300", "未正確點選病人!")

            End If


            '展開樹
            tre_MyPatient.ExpandAll()
            Return returnBoolean
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"加入->"})
        End Try
    End Function

    ''' <summary>
    ''' 移除
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Function RemoveFromTree() As Boolean
        Try
            Dim returnBoolean As Boolean = True
            For i As Integer = tre_MyPatient.Nodes.Find("M", False)(0).Nodes.Count - 1 To 0 Step -1
                If tre_MyPatient.Nodes.Find("M", False)(0).Nodes(i).Checked Then

                    '有選到節點才能移除，故不再判斷是否存在
                    Dim AddNode As TreeNode = tre_MyPatient.Nodes.Find("M", False)(0).Nodes(i).Clone

                    '還原打勾狀態
                    AddNode.Checked = False

                    '如果沒有才加入 群組查詢 樹狀結構
                    If Not tre_Dept.Nodes.ContainsKey(AddNode.Tag.ToString) Then

                        '將節點加入 群組查詢 樹狀結構
                        tre_Dept.Nodes.Find("S", False)(0).Nodes.Add(AddNode.Tag.ToString, AddNode.Text.ToString)

                        '加入Tag
                        tre_Dept.Nodes.Find("S", False)(0).Nodes.Find(AddNode.Tag.ToString, False)(0).Tag = AddNode.Tag.ToString
                    End If

                    '將節點移出 我的病人 樹狀結構
                    tre_MyPatient.Nodes.Find("M", False)(0).Nodes(i).Remove()
                End If
            Next
            Return returnBoolean
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"<-移除"})
        End Try
    End Function


    ''' <summary>
    ''' 離開
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2012-3-14</remarks>
    Private Sub ExitData() Handles btn_Exit.Click
        Try
            Me.Dispose()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(New CommonException("CMMCMMB302", ex, New String() {"離開"}))
        End Try
    End Sub

#End Region

#Region "     取得存檔的Dataset資料 "

    ''' <summary>
    ''' 取得存檔的Dataset資料
    ''' </summary>
    ''' <returns >DataSet</returns>
    ''' <remarks>by Sean.Lin on 2013-4-22</remarks>
    Private Function GetSaveData() As DataSet
        Try
            '建立一個格式為 CNCMyPatient的 DS
            Dim insertDS As DataSet = New DataSet
            insertDS.Tables.Add(GenDataTable(NfcGroupMaintainDataTableFactory.tableName, NfcGroupMaintainDataTableFactory.columnsName))

            '將我的病人樹狀結構加入 要儲存的 DS 中
            For i As Integer = 0 To tre_MyPatient.Nodes.Find("M", False)(0).Nodes.Count - 1
                If Not tre_MyPatient.Nodes.Find("M", False)(0).Nodes(i).Tag = "" Then
                    Dim TempDR As DataRow = insertDS.Tables(0).NewRow
                    TempDR.Item("Group_Id") = uclCbo_NfcGroup.SelectedValue
                    TempDR.Item("Employee_Code") = tre_MyPatient.Nodes.Find("M", False)(0).Nodes(i).Tag
                    TempDR.Item("Create_User") = CurrentUserID
                    TempDR.Item("Modified_User") = CurrentUserID
                    insertDS.Tables(0).Rows.Add(TempDR)
                End If
            Next
            Return insertDS
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得存檔的Dataset資料"})
        End Try
    End Function

#End Region

#Region "     群組全選"

    ''' <summary>
    ''' 群組全選
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>2013/05/29 Joyce</remarks>
    Private Sub tre_Station_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tre_Dept.NodeMouseClick
        Try
            Dim selNode As TreeNode = e.Node
            If IsNothing(selNode.Parent) Then
                If selNode.Checked Then
                    For Each ndPati As TreeNode In selNode.Nodes
                        ndPati.Checked = True
                    Next
                Else
                    For Each ndPati As TreeNode In selNode.Nodes
                        ndPati.Checked = False
                    Next
                End If
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#Region "     科室全選"

    ''' <summary>
    ''' 科室全選
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>2016/04/07 Steven</remarks>
    Private Sub tre_MyPatient_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tre_MyPatient.NodeMouseClick
        Try
            Dim selNode As TreeNode = e.Node
            If IsNothing(selNode.Parent) Then
                If selNode.Checked Then
                    For Each ndPati As TreeNode In selNode.Nodes
                        ndPati.Checked = True
                    Next
                Else
                    For Each ndPati As TreeNode In selNode.Nodes
                        ndPati.Checked = False
                    Next
                End If
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

    Private Sub btn_SaveGroup_Click(sender As Object, e As EventArgs) Handles btn_SaveGroup.Click
        Try
            Dim groupName As String = txt_groupName.Text.Trim
            NfcService = NfcServiceManager.getInstance

            If groupName <> "" Then
                NfcService.insertGroup(groupName, CurrentUserID)
                ShowInfoMsg("CMMCMMB301", "新增")
                txt_GroupID.Text = ""
                txt_groupName.Text = ""
                refanceGroup() '更新群組Commbox
            Else
                ShowWarnMsg("CMMCMMB300", "請輸入群組名稱!")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_DeleteGroup_Click(sender As Object, e As EventArgs) Handles btn_DeleteGroup.Click
        Try
            Dim groupID As String = txt_GroupID.Text.Trim
            NfcService = NfcServiceManager.getInstance

            If groupID <> "" Then
                NfcService.deleteGroup(groupID)
                ShowInfoMsg("CMMCMMB301", "刪除")
                txt_GroupID.Text = ""
                txt_groupName.Text = ""
                refanceGroup() '更新群組Commbox
            Else
                ShowWarnMsg("CMMCMMB300", "請輸入群組名稱!")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class