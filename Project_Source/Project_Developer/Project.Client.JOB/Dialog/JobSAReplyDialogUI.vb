'/*
'*****************************************************************************
'*
'*    Page/Class Name:  測試結果回覆
'*              Title:	JobSAReplyDialogUI
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2017-04-25
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2017-04-25
'*
'*****************************************************************************
'*/

Imports System.ServiceModel

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports JOBClientServiceFactory
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.Data
Imports System.IO
Imports System.Windows.Forms

Public Class JobSAReplyDialogUI
    Inherits Syscom.Client.UCL.BaseFormUI
#Region "     變數宣告 "

#Region "     使用者宣告　"
    Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\JOB\"

    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection
    '是否有修改或者單純關閉
    Private returnFlag As Boolean = False
#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim Job As IJOBServiceManager

#End Region


#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager

#End Region

#End Region

#Region "     屬性設定 "



#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     新增 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Will.Lin on 2017-04-25</remarks>
    Private Function InsertData() As Boolean
        Dim retDS As DataSet = Nothing
        Dim SendDS As DataSet = Nothing
        Try

            If rbt_Reject.Checked AndAlso rtb_Reply.Text.Trim.Length = 0 Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "必須填入退件理由")
                Return False
            End If
            Select Case MyCallType
                Case CallType.SAReply
                    SendDS = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.ReplyPGSubmit)
                    SendDS.Tables(0).Rows.Add("ReplyPGSubmit", m_JobCode, CurrentUserID, rbt_OK.Checked, rtb_Reply.Text, ProjectClientBP.getInstance.GetRTFFID(rtb_Reply), GetAttFID)
                Case CallType.DBAReply
                    SendDS = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.DBAReplyModify)
                    SendDS.Tables(0).Rows.Add("DBAReplyModify", m_ProjectID, m_SeqNo, rtb_Reply.Text.Trim, CurrentUserID)
            End Select




            retDS = Job.PRJDoAction(SendDS)


            If CheckMethodUtil.CheckHasValue(retDS) AndAlso retDS.Tables(0).Rows(0).Item(0) > 0 Then
                returnFlag = True
            Else
                returnFlag = False
            End If


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
        End Try
        Return returnFlag
    End Function



    Private Function GetAttFID() As String
        Dim _pathATT As String = path & "Att"
        Dim dir = New DirectoryInfo(_pathATT)
        Try

            If dir.Exists = False Then
                dir.Create()
            End If

            For i As Int32 = 0 To dgv_FilePath.Rows.Count - 1
                Dim FileName As String = dgv_FilePath.GetDBDS().Tables(0).Rows(i).Item("Path").ToString.Split("\")(dgv_FilePath.GetDBDS().Tables(0).Rows(i).Item("Path").ToString.Split("\").Length - 1)
                System.IO.File.Copy(dgv_FilePath.GetDBDS().Tables(0).Rows(i).Item("Path").ToString, dir.FullName & "\" & FileName, True)
            Next


            Return UploadFileToFTM(ProjectClientBP.getInstance.CompressFile(dir))

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
        End Try
    End Function

    Private Function UploadFileToFTM(ByVal FilePath As String) As String

        Dim strFilePath As String = ""
        Try
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "上傳中，請稍後‧‧‧")
            Dim dataSet As DataSet = New DataSet
            Dim dataTable As DataTable = FileTransferDataFormat.getDataTableWithSchema
            Dim dataRow As DataRow = dataTable.NewRow()
            '使用自己的資料來源取代 New Object 

            dataRow("File_Name") = FilePath  '檔案路徑
            dataRow("Order_Seq") = 1 '顯示順序
            dataRow("Image_Thumb") = Nothing '沒有縮圖的需求給nothing
            dataRow("File_Note") = "JobReply" '檔案註解
            dataRow("Create_User") = CurrentUserID '上傳人員
            dataRow("Create_Time") = Now '上傳時間
            dataRow("Modified_User") = CurrentUserID  '修改人員
            dataRow("Modified_Time") = Now '修改時間
            dataRow("FileByteArray") = FileTransferTool.convertFileToByteArray(FilePath) '將檔案轉成 byte array
            dataRow("FileType") = FileTransferTool.FileType_R '檔案型態 --> T / G /R /O /E / I
            If AppContext.userProfile.userId.Length > 8 Then
                dataRow("FileSub") = AppContext.userProfile.userId.Substring(0, 8)  ' 檔案系統八碼，如果是 EMR 系統，這裡填入八碼病歷號 
            Else
                dataRow("FileSub") = AppContext.userProfile.userId
            End If
            dataRow("FileTime") = Now '指定檔案時間
            dataRow("FID") = 0 '預設給0，後端會再重新給值
            dataTable.Rows.Add(dataRow)
            dataSet.Tables.Add(dataTable)

            Dim client = FtmServiceManager.getInstance
            Dim s() = client.uploadNewFile(dataSet)
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
            Return s(0)

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
        End Try
        Return ""
    End Function


    Private Overloads Function ShowDialog() As Boolean
        MyBase.ShowDialog()

        Return returnFlag

    End Function
#End Region

#Region "     清除 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Will.Lin on 2017-04-25</remarks>
    Private Function ClearData() As Boolean

        Try

            Dim returnBoolean As Boolean = False

            Return returnBoolean

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB916", ex)
        End Try

    End Function

#End Region

#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "



#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    Enum CallType As Integer
        SAReply
        PGCheck
        DBAReply
        SACheck
    End Enum

    Private m_Type As CallType
    Private m_JobCode As String = ""
    Private m_ProjectID As String = ""
    Private m_SeqNo As String = ""

    Private m_dgvColumns As String(,) = {{"檔案路徑", "Path"}}


    Private Property MyCallType As CallType
        Get
            Return m_Type
        End Get
        Set(value As CallType)
            m_Type = value
        End Set
    End Property

    Public Sub New(ByVal type As CallType, ByVal jobCode As String, ByVal IsOK As Boolean)

        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。

        MyCallType = type
        m_JobCode = jobCode

        If IsOK Then
            rbt_OK.Checked = True
        Else
            rbt_Reject.Checked = True
        End If
    End Sub

    Public Sub New(ByVal type As CallType, ByVal ProjectID As String, ByVal SeqNo As String, ByVal RejectReason As String, ByVal IsOK As Boolean)

        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。

        MyCallType = type
        m_ProjectID = ProjectID
        m_SeqNo = SeqNo
        rtb_Reply.Text = RejectReason

        Me.Text = "DB異動申請回覆"

        If IsOK Then
            rbt_OK.Checked = True
        Else
            rbt_Reject.Checked = True
        End If

    End Sub

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-04-25</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()

            initialUI()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

    Private Sub initialUI()

        Try
            Dim retDS As DataSet
            Dim SendDS As DataSet = Nothing
            Select Case MyCallType
                Case CallType.PGCheck, CallType.SAReply
                    SendDS = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.InitialSAReplyDialogUI)
                    SendDS.Tables(0).Rows.Add("InitialSAReplyDialogUI", m_JobCode)
                    retDS = Job.PRJDoAction(SendDS)
                    If CheckMethodUtil.CheckHasValue(retDS) Then
                        If retDS.Tables(0).Rows(0).Item("FID").ToString.Trim.Length > 0 Then
                            rtb_Reply.LoadFile(ProjectClientBP.getInstance.LoadFileByFID(retDS.Tables(0).Rows(0).Item("FID").ToString.Trim))
                        Else
                            rtb_Reply.Text = retDS.Tables(0).Rows(0).Item("Reply_Note").ToString.Trim
                        End If
                        btn_DownLoad.Enabled = retDS.Tables(0).Rows(0).Item("SA_Reply_ATT_FID").ToString.Trim.Length > 0
                        If btn_DownLoad.Enabled Then
                            btn_DownLoad.Tag = ProjectClientBP.getInstance.LoadFileByFID(retDS.Tables(0).Rows(0).Item("SA_Reply_ATT_FID").ToString)
                        End If
                    End If

            End Select

            ShowDgv(getDgvDs)
            btn_Insert.Enabled = (MyCallType = CallType.DBAReply OrElse MyCallType = CallType.SAReply)
            btn_Remove.Enabled = (MyCallType = CallType.DBAReply OrElse MyCallType = CallType.SAReply)
            btn_DownLoad.Enabled = Not (MyCallType = CallType.DBAReply OrElse MyCallType = CallType.SAReply)
            TableLayoutPanel1.Enabled = (MyCallType = CallType.DBAReply OrElse MyCallType = CallType.SAReply)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-04-25</remarks>
    Private Sub LoadServiceManager()

        Try

            Job = JOBServiceManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB991", ex)
        End Try


    End Sub

#End Region

#Region "     載入事件管理員(EventManager) "

    ''' <summary>
    ''' 載入EventManager的Instance
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-4-25</remarks>
    Private Sub LoadEventManager()

        Try

            eventMgr = EventManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB992", ex)
        End Try

    End Sub

#End Region

#Region "     關閉事件管理員(EventManager) "

    ''' <summary>
    ''' 關閉事件管理員(EventManager)
    ''' </summary>
    ''' <remarks>by Will.Lin on 2017-04-25</remarks>
    Private Sub UIDisposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        Try

            eventMgr = Nothing

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB993", ex)
        End Try

    End Sub

#End Region

#End Region

#Region "     必填檢查 "



#End Region

#Region "     事件集合 "

    Private Sub rbt_CheckedChanged(sender As Object, e As EventArgs) Handles rbt_OK.CheckedChanged

        Try
            rtb_Reply.Enabled = rbt_Reject.Checked

            rtb_Reply.Text = ""

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"DB異動申請(完成/退件)"})
        End Try


    End Sub


    Private Function getDgvDs() As DataSet

        Dim ds As New DataSet
        Try

            ds.Tables.Add(New DataTable("dt"))

            For i As Int32 = 0 To m_dgvColumns.GetUpperBound(0)
                ds.Tables(0).Columns.Add(m_dgvColumns(i, 1))
            Next


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"顯示DGV"})
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' 顯示DGV
    ''' </summary>
    ''' <param name="ds"></param>
    Private Sub ShowDgv(ByVal ds As DataSet)

        Try
            Dim header As String = ""

            For i As Int32 = 0 To m_dgvColumns.GetUpperBound(0)
                header &= m_dgvColumns(i, 0) & ","
            Next
            header = header.Substring(0, header.Length - 1)
            dgv_FilePath.Initial(ds)
            dgv_FilePath.uclHeaderText = header
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"顯示DGV"})
        End Try
    End Sub
#End Region

#Region "     取得存檔的Dataset資料 "



#End Region

#Region "     清除功能 "



#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     新增 鎖定功能 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Will.Lin on 2017-04-25</remarks>
    Private Sub btn_Confrim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Confrim.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (InsertData()) Then

                '左下方顯示 新增 成功
                ShowInfoMsg("CMMCMMB301", "新增")

            End If

            'Error 的最上層，處理例外訊息
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            '解除螢幕鎖定
            UnLock(Me)
            Me.Close()
        End Try

    End Sub

    Private Sub btn_Insert_Click(sender As Object, e As EventArgs) Handles btn_Insert.Click
        Lock(Me)
        Try
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                For Each s In OpenFileDialog1.FileNames

                    dgv_FilePath.AddNewRow()
                    dgv_FilePath.GetDBDS.Tables(0).Rows(dgv_FilePath.Rows.Count - 1).Item("Path") = s
                    dgv_FilePath.GetGridDS.Tables(0).Rows(dgv_FilePath.Rows.Count - 1).Item("Path") = s
                Next

            End If

        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            UnLock(Me)

        End Try
    End Sub

    Private Sub btn_Remove_Click(sender As Object, e As EventArgs) Handles btn_Remove.Click
        Lock(Me)
        Try
            If dgv_FilePath.Rows.Count <= 0 OrElse dgv_FilePath.SelectedIndex.Length = 0 Then
                Exit Sub
            Else
                dgv_FilePath.RemoveAllSelectedRow()
            End If

        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            UnLock(Me)

        End Try
    End Sub

    Private Sub btn_DownLoad_Click(sender As Object, e As EventArgs) Handles btn_DownLoad.Click
        Lock(Me)
        Try
            If btn_DownLoad.Tag IsNot Nothing Then
                System.Diagnostics.Process.Start(btn_DownLoad.Tag)
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            UnLock(Me)

        End Try
    End Sub

#End Region

#End Region

#End Region

#End Region

End Class

