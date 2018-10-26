Public Class UCLPatientInfoUISample
    Private Sub ChartNoLeaveProcess(ByVal ChartNo As String) Handles UclPatientInfoUI1.ChartNoLeaveProcess
        UclPatientContactUI1.setContactData(ChartNo)
    End Sub
End Class
