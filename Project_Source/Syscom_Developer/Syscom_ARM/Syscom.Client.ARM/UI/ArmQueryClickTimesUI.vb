Imports Syscom.Comm.EXP
Imports Syscom.Client.CMM
Imports System.Windows.Forms

Public Class ArmQueryClickTimesUI

    Private Sub ArmQueryClickTimesUI_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim dsFun As DataSet = ARM.FunQueryByPK("")
            cbo_FunctionId.DataSource = dsFun.Tables(0)
            cbo_FunctionId.uclDisplayIndex = "6,7"
            cbo_FunctionId.uclValueIndex = "6"

            dtp_StartDate.SetValue(Now.AddMonths(-1))
            dtp_EndDate.SetValue(Now)
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub btn_Query_Click(sender As Object, e As EventArgs) Handles btn_Query.Click
        Try
            If dtp_StartDate.GetUsDateStr = "" Or dtp_EndDate.GetUsDateStr = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB305", New String() {"使用日期"})
                Exit Sub
            End If

            Dim ds As DataSet = ARM.queryArmRecord(tcq_EmployeeCode.getCode, cbo_FunctionId.SelectedValue, dtp_StartDate.GetUsDateStr, dtp_EndDate.GetUsDateStr)
            dgv_ShowData.Initial(ds)
            dgv_ShowData.uclHeaderText = ",子系統名稱,,功能名稱,使用次數"
            dgv_ShowData.uclVisibleColIndex = "1,3,4"
            dgv_ShowData.uclColumnWidth = "200,200,200,300,100"
            dgv_ShowData.uclIsSortable = True
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub btn_Excel_Click(sender As Object, e As EventArgs) Handles btn_Excel.Click
        Try
            If dgv_ShowData.GetDBDS Is Nothing Then
                Exit Sub
            End If
            Dim ds As New DataSet
            Dim condData As New DataTable
            condData.Columns.Add("Employee_Name")
            condData.Columns.Add("Start_Date")
            condData.Columns.Add("End_Date")
            condData.Rows.Add(New String() {tcq_EmployeeCode.getCodeName, dtp_StartDate.GetTwDateStr, dtp_EndDate.GetTwDateStr})
            ds.Tables.Add(condData)
            ds.Tables.Add(dgv_ShowData.GetDBDS.Tables(0).Copy)
            ds.Tables(1).TableName = "功能使用次數查詢統計表"
            Dim instance As New ARMRPT000001Client
            instance.preview(ds)
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#Region " HotKey設定"

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                '清除
                'MessageHandling.clearInfoMsg()
                'btnClear_Click(sender, e)
            Case Keys.F12
                '刪除 SF12
                'If e.Shift Then
                '    If (btnDelete.Enabled) Then btnDelete_Click(sender, e)
                'Else
                '    '新增F12
                '    'MessageHandling.clearInfoMsg()
                '    If (btnInsert.Enabled) Then btnInsert_Click(sender, e)
                'End If
            Case Keys.F10
                '修改
                'MessageHandling.clearInfoMsg()
                'If (btnUpdate.Enabled) Then btnUpdate_Click(sender, e)
            Case Keys.F1
                '查詢
                btn_Query.PerformClick()
            Case Keys.Enter
                Me.ProcessTabKey(True)
        End Select
    End Sub

#End Region

End Class