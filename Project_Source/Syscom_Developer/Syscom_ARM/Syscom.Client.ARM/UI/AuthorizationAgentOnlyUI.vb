Imports Syscom.Comm.Utility
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.CMM
Imports System.Windows.Forms

Public Class AuthorizationAgentOnlyUI
    Inherits Syscom.Client.UCL.BaseFormUI

    '加入接取訊息傳遞的Event
    Private WithEvents eventManager As EventManager = eventManager.getInstance

    ''' <summary>
    ''' 載入畫面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AuthorizationAgentOnlyUI_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Label3.Text = AppContext.userProfile.userName

            btn_Query.PerformClick()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Query_Click(sender As Object, e As EventArgs) Handles btn_Query.Click
        Try
            Dim ds As DataSet = ARM.queryByAgentEmployeeCode("", AppContext.userProfile.userId, "", dtp_EffectDate.GetUsDateStr, dtp_EndDate.GetUsDateStr)
            dgv_ShowData.Initial(ds)
            dgv_ShowData.uclHeaderText = "授權人,代理人,,角色,有效起日,有效迄日"
            dgv_ShowData.uclVisibleColIndex = "0,1,3,4,5"
            dgv_ShowData.uclColumnWidth = "100,100,100,250"
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' 進行開啟代理執行的畫面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_ShowData_CellDoubleClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgv_ShowData.CellDoubleClick
        Try
            If CDate(DateUtil.TransDateToWE(dgv_ShowData.Rows(e.RowIndex).Cells(5).Value)) < Now.Date Then
                Exit Sub
            End If

            Dim ds As DataSet = dgv_ShowData.GetDBDS
            Dim row As DataRow = dgv_ShowData.GetDBDS.Tables(0).Rows(e.RowIndex)
            Dim count As Integer = row("Role_Id").ToString.Trim.Split(",").Count
            Dim roleId() As String = {}
            ReDim roleId(count - 1)
            For i As Integer = 0 To count - 1
                roleId(i) = row("Role_Id").ToString.Trim.Split(",")(i)
            Next

            eventManager.RaiseOpenAgentInstance(row("Employee_Code"), row("Employee_Name"), AppContext.userProfile.userId, AppContext.userProfile.userName, roleId)
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 描繪灰底的失效授權
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_ShowData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv_ShowData.CellFormatting
        If e.RowIndex > 0 Then
            If CDate(DateUtil.TransDateToWE(dgv_ShowData.Rows(e.RowIndex).Cells(5).Value)) < Now.Date Then
                dgv_ShowData.SetRowColor(e.RowIndex, Drawing.Color.Gray)
            End If
        End If
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
                'btn_Clear.PerformClick()
            Case Keys.F12
                '刪除 SF12
                'If e.Shift Then
                '    If (btn_Delete.Enabled) Then btn_Delete.PerformClick()
                'Else
                '    '新增F12
                '    If (btn_Insert.Enabled) Then btn_Insert.PerformClick()
                'End If
            Case Keys.F10
                '修改
                'If (btnUpdate.Enabled) Then btnUpdate_Click(sender, e)
            Case Keys.F1
                '查詢
                btn_Query.PerformClick()
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                Me.ProcessTabKey(True)
        End Select
    End Sub

#End Region

End Class