Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM

Public Class LoginModule
    Inherits Syscom.Client.UCL.BaseFormUI

    '加入接取訊息傳遞的Event
    Private WithEvents eventManager As EventManager = EventManager.getInstance

    ''' <summary>
    ''' 取消
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
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

End Class
