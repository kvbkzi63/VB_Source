Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms
Imports Syscom.Comm.Utility.PassWordUtil
Imports Syscom.Comm.Utility

Public Class ArmResetPwdUI


    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Me.Close()
    End Sub


    Private Sub Btn_Reset_Click(sender As Object, e As EventArgs) Handles Btn_Reset.Click
        Dim _ds As New DataSet
        _ds = genDataset()
        Try
            Dim count As Integer = ArmServiceManager.getInstance.ResetPassword(_ds)
            MessageBox.Show("修改成功!")
        Catch ex As Exception
            MessageBox.Show("修改失敗!")
        End Try


    End Sub
    Function genDataset() As DataSet
        Try
            Dim employeeCode As String = Txt_EmployeeCode.Text.Trim
            Dim password As String = Txt_Pwd.Text.Trim

            Dim ds As New DataSet
            Dim dt As New DataTable("ARMPassword")

            Dim dr As DataRow
            Dim employeeCodeCol As DataColumn
            Dim passwordCol As DataColumn



            'dt = New DataTable()
            employeeCodeCol = New DataColumn("userid", Type.GetType("System.String"))
            passwordCol = New DataColumn("newpass", Type.GetType("System.String"))


            dt.Columns.Add(employeeCodeCol)
            dt.Columns.Add(passwordCol)


            dr = dt.NewRow()
            dr("userid") = employeeCode
            dr("newpass") = Encrypt(password, PassWordUtil.getPrimaryKey)


            dt.Rows.Add(dr)

            ds.Tables.Add(dt)
            Return ds


        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class