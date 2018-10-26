Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility


Public Class UCLChartNoUISample

    Dim WithEvents pvtReceiveChartNoMgr As EventManager = EventManager.getInstance
    Dim pvtPatient As UCLPatientData

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(UclChartNoUI1.GetPatientObj.Patient_Name)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub UclChartNoUI1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub







    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        UclChartNoUI1.SetTextToQuery("000001", UCLChartNoUI.uclTextTypeData.ChartNo)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        pvtPatient = UclChartNoUI1.GetPatientObj

        UclDataGridViewUI1.Initial(pvtPatient.PatientDS)

        RichTextBox1.Text += " Dim pvtPatient As UCLPatientData " + vbCrLf
        RichTextBox1.Text += " pvtPatient = UclChartNoUI1.GetPatientObj    取得 從病人物件" + vbCrLf
        RichTextBox1.Text += " pvtPatient.PatientDS       從 PUB_Patient取得  病人資料" + vbCrLf
        RichTextBox1.Text += " pvtPatient.PatientFlagDS   從 PUB_Patient_Flag取得 病人資料" + vbCrLf
        RichTextBox1.Text += " pvtPatient.PatientDisDS    從 PUB_Patient_Disability取得 病人資料" + vbCrLf
        RichTextBox1.Text += " pvtPatient.PatientSevereDisDS  從 PUB_Patient_Severe_Disease取得 病人資料 " + vbCrLf
        RichTextBox1.Text += " pvtPatient.Patient_Name 取得   病人姓名 " + vbCrLf
        RichTextBox1.Text += " 其他屬性請參照PUB_Patient 欄位 " + vbCrLf


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        UclChartNoUI1.Text = "00000001"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MessageBox.Show("ChartNo is " + UclChartNoUI1.Text)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        UclChartNoUI2.Text = "A100000001"
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        UclChartNoUI2.SetTextToQuery("A100000001", UCLChartNoUI.uclTextTypeData.IdNo)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        MessageBox.Show("IdNo is " + UclChartNoUI2.Text)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        pvtPatient = UclChartNoUI2.GetPatientObj

        UclDataGridViewUI1.Initial(pvtPatient.PatientDS)

        RichTextBox1.Text += " Dim pvtPatient As UCLPatientData " + vbCrLf
        RichTextBox1.Text += " pvtPatient = UclChartNoUI2.GetPatientObj    取得 從病人物件" + vbCrLf
        RichTextBox1.Text += " pvtPatient.PatientDS       從 PUB_Patient取得  病人資料" + vbCrLf
        RichTextBox1.Text += " pvtPatient.PatientFlagDS   從 PUB_Patient_Flag取得 病人資料" + vbCrLf
        RichTextBox1.Text += " pvtPatient.PatientDisDS    從 PUB_Patient_Disability取得 病人資料" + vbCrLf
        RichTextBox1.Text += " pvtPatient.PatientSevereDisDS  從 PUB_Patient_Severe_Disease取得 病人資料 " + vbCrLf
        RichTextBox1.Text += " pvtPatient.Patient_Name 取得   病人姓名 " + vbCrLf
        RichTextBox1.Text += " 其他屬性請參照PUB_Patient 欄位 " + vbCrLf
    End Sub

 

    Private Sub receiveChartNo(ByVal ctlName As String, ByVal uclCodeValue1 As String) Handles pvtReceiveChartNoMgr.UclOpenChartNoWindow
        If ctlName = "UclChartNoUI2" Then

            '  uclCodeValue1 為選到的ChartNo

            UclChartNoUI2.doFlag = True '進行查詢

            UclChartNoUI2.QueryPatientByKey(uclCodeValue1.Trim())  '將選到的ChartNo傳入進行查詢
            'SendKeys.Send("{TAB}")
        End If
    End Sub




    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(UclChartNoUI2.doFlag)
    End Sub

    Private Sub UclChartNoUI2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UclChartNoUI2.Leave
        '  UclChartNoUI2.doFlag = False
    End Sub

    Private Sub UCLChartNoUISample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UclChartNoUI1_Leave_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UclChartNoUI1.Leave
        UclChartNoUI1.doFlag = False

        'UclChartNoUI2.Text = "A100000001"
    End Sub

    'Private Sub UclChartNoUI1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UclChartNoUI1.KeyUp
    '    Select Case e.KeyCode
    '        Case Keys.Enter
    '            UclChartNoUI2.Text = "A100000001"
    '    End Select

    'End Sub

  
End Class