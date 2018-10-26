Imports System.ServiceModel
Imports System.Windows.Forms
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility.ScreenUtil


Public Class JobEmployeeMaintainUI
    Inherits Syscom.Client.UCL.BaseFormUI

#Region "     按鈕事件"

    Private Sub btn_Query_Click(sender As Object, e As EventArgs) Handles btn_Query.Click
        Lock(Me)
        Try
            JobEmployeeMaintainBP.GetInstance.QueryData(sender, e, Me)


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
        Finally
            UnLock(Me)
        End Try
    End Sub

    Private Sub btn_Insert_Click(sender As Object, e As EventArgs) Handles btn_Insert.Click
        Try
            JobEmployeeMaintainBP.GetInstance.Insert(sender, e, Me)


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally
            UnLock(Me)
        End Try
    End Sub

    Private Sub btn_Update_Click(sender As Object, e As EventArgs) Handles btn_Update.Click
        Try
            JobEmployeeMaintainBP.GetInstance.Update(sender, e, Me)


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改"})
        Finally
            UnLock(Me)
        End Try
    End Sub

    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        Try
            JobEmployeeMaintainBP.GetInstance.Delete(sender, e, Me)


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除"})
        Finally
            UnLock(Me)
        End Try
    End Sub

    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        Try
            JobEmployeeMaintainBP.GetInstance.Clear(sender, e, Me)


            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"清除"})
        Finally
            UnLock(Me)
        End Try
    End Sub


#End Region
#Region "     Grid事件"
    Private Sub dgv_ShowData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ShowData.CellClick
        Try
            JobEmployeeMaintainBP.GetInstance.dgv_ShowData_CellClick(sender, e, Me)
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"Grid事件"})
        End Try

    End Sub
#End Region

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-07-03</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            JobEmployeeMaintainBP.GetInstance.Initial(Me)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region
End Class