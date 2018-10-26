Imports System.Data
Imports System.ServiceModel
Imports JOBClientServiceFactory
Imports Project.Client.JOB.ProjectClientBP
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Client.CMM


Public Class JobModifiyUI

#Region "     變數宣告"



    Enum Character As Integer
        SA
        SD
    End Enum

    Private m_Character As Character = Character.SA
    Private m_JobCode As String = ""
    Dim JobData As DataSet = Nothing
    Private Property UserCharacter As Character
        Get
            Return m_Character
        End Get
        Set(value As Character)
            m_Character = value
        End Set
    End Property

#End Region

#Region "     初始化"

    Public Sub New(ByVal User As Character, ByVal JobCode As String)

        UserCharacter = User
        m_JobCode = JobCode
        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。

        Select Case UserCharacter
            Case Character.SA
                gup_SD.Enabled = False
        End Select
        Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ActionName.QueryJobForModifiy)
        SendDS.Tables(0).Rows.Add("QueryJobForModifiy", JobCode)
        JobData = JOBClientServiceFactory.JOBServiceManager.getInstance.PRJDoAction(SendDS)


        initialComboBox()
        SetData()
    End Sub


    Private Sub initialComboBox()


        Try
            Dim initialDS = JOBServiceManager.getInstance.PRJDoAction(ProjectClientBP.getInstance.GetActionDS(ActionName.initialSAAssignJobUI))

            cbo_IssueClassify.DataSource = PubServiceManager.getInstance.queryPUBSysCode("9999", False).Tables(0).Copy
            cbo_IssueClassify.DisplayMember = "Code_Name"
            cbo_IssueClassify.ValueMember = "Code_Id"


            If initialDS.Tables.Contains("HospList") Then
                cbo_Hosp.DataSource = initialDS.Tables("HospList").Copy
                cbo_Hosp.uclDisplayIndex = "0,1"
                cbo_Hosp.uclValueIndex = "0"
            End If



            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

    Private Sub SetData()


        Try

            If CheckHasValue(JobData) Then
                Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.QueryFunctionDataByProjectIDandSystemCode)
                SendDS.Tables(0).Rows.Add("QueryFunctionDataByProjectIDandSystemCode", JobData.Tables(0).Rows(0).Item("Project_Id").ToString.Trim, JobData.Tables(0).Rows(0).Item("System_Code").ToString.Trim)
                Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)
                If CheckHasValue(retDS) Then
                    cbo_Function.DataSource = retDS.Tables(0).Copy
                    cbo_Function.uclDisplayIndex = "3"
                    cbo_Function.uclValueIndex = "2"
                End If
                cbo_Hosp.SelectedValue = JobData.Tables(0).Rows(0).Item("Hospital_Code").ToString.Trim
                cbo_Function.SelectedValue = JobData.Tables(0).Rows(0).Item("Function_Code").ToString.Trim
                cbo_IssueClassify.SelectedValue = JobData.Tables(0).Rows(0).Item("Issue_Classify").ToString.Trim
                dtp_DeadLine.SetValue(JobData.Tables(0).Rows(0).Item("Issue_Deadline"))
                rtb_Desc.LoadFile(ProjectClientBP.getInstance.LoadFileByFID(JobData.Tables(0).Rows(0).Item("RTF_FID").ToString.Trim))
                txt_Subject.Text = JobData.Tables(0).Rows(0).Item("Mail_Subject").ToString.Trim
                txt_EstimateCost.Text = JobData.Tables(0).Rows(0).Item("Estimate_Cost").ToString.Trim
                txt_SD_Cost_Time.Text = JobData.Tables(0).Rows(0).Item("SD_Cost_Time").ToString.Trim
                txt_SD_Estimate_Cost.Text = JobData.Tables(0).Rows(0).Item("SD_Estimate_Cost").ToString.Trim
                If IsDate(JobData.Tables(0).Rows(0).Item("SD_Issue_Deadline").ToString.Trim) Then
                    dtp_SD_Issue_Deadline.SetValue(JobData.Tables(0).Rows(0).Item("SD_Issue_Deadline"))
                End If
                rtb_SDNote.Text = JobData.Tables(0).Rows(0).Item("SD_Note").ToString.Trim
            End If


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub

    Private Function GetSaveDS() As DataSet

        Try
            JobData.Tables(0).Rows(0).Item("SD_Cost_Time") = txt_SD_Cost_Time.Text
            JobData.Tables(0).Rows(0).Item("SD_Issue_Deadline") = dtp_SD_Issue_Deadline.GetUsDateStr
            JobData.Tables(0).Rows(0).Item("SD_Note") = rtb_SDNote.Text
            JobData.Tables(0).Rows(0).Item("SD_Estimate_Cost") = txt_SD_Estimate_Cost.Text
            JobData.Tables(0).Rows(0).Item("Hospital_Code") = cbo_Hosp.SelectedValue
            JobData.Tables(0).Rows(0).Item("Function_Code") = cbo_Function.SelectedValue
            JobData.Tables(0).Rows(0).Item("Issue_Classify") = cbo_IssueClassify.SelectedValue
            JobData.Tables(0).Rows(0).Item("Issue_Deadline") = dtp_DeadLine.GetUsDateStr
            JobData.Tables(0).Rows(0).Item("Mail_Subject") = txt_Subject.Text
            JobData.Tables(0).Rows(0).Item("Estimate_Cost") = txt_EstimateCost.Text
            JobData.Tables(0).Rows(0).Item("Action") = "JobModifiy"


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
        Return JobData
    End Function
#End Region


#Region "     事件處理"

    Private Sub btn_Update_Click(sender As Object, e As EventArgs) Handles btn_Update.Click
        Try
            Dim retDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(GetSaveDS)

            If CheckHasValue(retDS) AndAlso retDS.Tables(0).Rows(0).Item(0) > 0 Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "修改成功")
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", "無資料被異動")
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        Finally
            Me.Close()
            Me.Dispose()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Select Case UserCharacter
                Case Character.SD
                    txt_SD_Cost_Time.Text = ""
                    dtp_SD_Issue_Deadline.Clear()
                    txt_SD_Estimate_Cost.Text = ""
                Case Character.SA
                    cbo_Hosp.SelectedValue = ""
                    cbo_Function.SelectedValue = ""
                    cbo_IssueClassify.SelectedValue = ""
                    dtp_DeadLine.Clear()
                    txt_Subject.Text = ""
                    txt_EstimateCost.Text = ""
            End Select


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try
    End Sub


#End Region

End Class