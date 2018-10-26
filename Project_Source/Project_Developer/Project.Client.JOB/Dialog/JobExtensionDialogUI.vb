Imports System.Data
Imports Syscom.Client.CMM
Imports JOBClientServiceFactory
Imports Syscom.Comm.Utility.CheckMethodUtil

Public Class JobExtensionDialogUI

    Dim m_originalDate As String = ""
    Dim m_JobCode As String = ""
    Dim QueryFlag As Boolean = False

    Public Sub New(ByVal JobCode As String, ByVal oriDate As String)

        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。
        Me.m_originalDate = oriDate
        m_JobCode = JobCode
        dtp_NewDate.SetValue(oriDate)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            If Not IsDate(dtp_NewDate.GetUsDateStr) OrElse CDate(m_originalDate) >= CDate(dtp_NewDate.GetUsDateStr) Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "展延日期不得小於等於原日期")
                Exit Sub
            End If
            Dim SendDS As DataSet = ProjectClientBP.getInstance.GetActionDS(ProjectClientBP.ActionName.IssueExtension)
            SendDS.Tables(0).Rows.Add("IssueExtension", m_JobCode, dtp_NewDate.GetUsDateStr)
            Dim RetDS As DataSet = JOBServiceManager.getInstance.PRJDoAction(SendDS)

            If CheckHasValue(RetDS) AndAlso RetDS.Tables(0).Rows(0).Item(0) > 0 Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", "展延成功")
                QueryFlag = True
            End If
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Overloads Function Showdialog(ByVal IsExtension As Boolean) As Boolean
        MyBase.ShowDialog()
        Return QueryFlag
    End Function

End Class