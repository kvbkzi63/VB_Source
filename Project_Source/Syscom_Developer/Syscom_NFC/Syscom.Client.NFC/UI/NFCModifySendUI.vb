Imports Syscom.Client.Servicefactory
Imports System.ServiceModel
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility

Public Class NFCModifySendUI
    Private nfcClient As NfcServiceManager = NfcServiceManager.getInstance

    Sub New(ByVal ds As DataSet)
        InitializeComponent()
        Try
            For Each row As DataRow In ds.Tables(0).Rows
                Dim startDate As String = row.Item("Start_Time").ToString
                Dim endDate As String = row.Item("End_Time").ToString
                dtp_StartDate.SetValue(DateUtil.TransDateToWE(startDate.Split(" "c)(0)))
                mtb_StartTime.Text = startDate.Split(" "c)(1)
                dtp_EndDate.SetValue(DateUtil.TransDateToWE(endDate.Split(" "c)(0)))
                mtb_EndTime.Text = endDate.Split(" "c)(1)
                txt_Subject.Text = row.Item("Subject")
                rtb_Msg.Text = row.Item("MsgBody")
                txt_GroupTxId.Text = row.Item("Group_tx_Id")
            Next

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Sub


    Private Sub NFCModifySendUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = "訊息發布異動"
        Catch ex As Exception

        End Try
    End Sub

#Region "   按鈕事件"
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Me.Close()
    End Sub

    Private Sub btn_Update_Click(sender As Object, e As EventArgs) Handles btn_Update.Click
        Try
            nfcClient.updateSender(genDs)
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        Try
            nfcClient.deleteSenderByGroupTxId(txt_GroupTxId.Text)
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "   產生更新Dataset"
    Function genDs() As DataSet
        Try
            Dim updateDS As DataSet = New DataSet("updateNfcDS")
            Dim updateTable As DataTable = New DataTable("updateNfcTable")
            updateDS.Tables.Add(updateTable)
            updateTable.Columns.Add("Start_Time", Type.GetType("System.String"))
            updateTable.Columns.Add("End_Time", Type.GetType("System.String"))
            updateTable.Columns.Add("Subject", Type.GetType("System.String"))
            updateTable.Columns.Add("MsgBody", Type.GetType("System.String"))
            updateTable.Columns.Add("Group_tx_Id", Type.GetType("System.String"))

            Dim row As DataRow = updateDS.Tables(0).NewRow
            row("Start_Time") = dtp_StartDate.GetUsDateStr + " " + mtb_StartTime.Text + ":00.000"
            row("End_Time") = dtp_EndDate.GetUsDateStr + " " + mtb_EndTime.Text + ":00.000"
            row("Subject") = txt_Subject.Text.Trim
            row("MsgBody") = rtb_Msg.Text.Trim
            row("Group_tx_Id") = txt_GroupTxId.Text.Trim

            updateDS.Tables(0).Rows.Add(row)
            Return updateDS

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