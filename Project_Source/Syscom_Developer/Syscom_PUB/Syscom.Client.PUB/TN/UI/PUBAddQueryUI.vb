Imports Com.Syscom.WinFormsUI.Docking
Imports System.Text
Imports log4net
Imports Syscom.Client.Servicefactory



Public Class PUBAddQueryUI

    Dim KidAddQueryDT As DataTable = New DataTable
    Dim EmgAddQueryDT As DataTable = New DataTable
    Dim DentalAddQueryDT As DataTable = New DataTable
    Dim DeptAddQueryDT As DataTable = New DataTable

    Dim InfoDS As DataSet = New DataSet
    Dim InfoDS2 As DataSet = New DataSet
    Dim InfoDS3 As DataSet = New DataSet
    Dim InfoDS4 As DataSet = New DataSet

    'Dim PubSM As IPubServiceManager = PubServiceManager.getInstance
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub New(ByVal Order_Code As String, ByVal Order_Name As String)


        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        UclTextCodeQueryUI1.Text = Order_Code
        UclTextCodeQueryUI1.uclCodeName = Order_Name
        UclTextCodeQueryUI1_Leave(New Object, New EventArgs)
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub
    Private Sub UclTextCodeQueryUI1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UclTextCodeQueryUI1.Leave
        Try

            DGV_KidAdd.ClearDS()
            InfoDS.Tables.Clear()
            DGV_EmgAdd.ClearDS()
            InfoDS2.Tables.Clear()
            DGV_DentalAdd.ClearDS()
            InfoDS3.Tables.Clear()
            DGV_DeptAdd.ClearDS()
            InfoDS4.Tables.Clear()

            txt_OrderCnName.Text = UclTextCodeQueryUI1.uclCodeName
            KidAddQueryDT = PubServiceManager.getInstance.QueryAdd(UclTextCodeQueryUI1.Text)
            EmgAddQueryDT = PubServiceManager.getInstance.QueryAdd_Emg(UclTextCodeQueryUI1.Text)
            DentalAddQueryDT = PubServiceManager.getInstance.QueryAdd_Dental(UclTextCodeQueryUI1.Text)
            DeptAddQueryDT = PubServiceManager.getInstance.QueryAdd_Dept(UclTextCodeQueryUI1.Text)
            InfoDS.Tables.Add(KidAddQueryDT)
            DGV_KidAdd.Initial(InfoDS)
            InfoDS2.Tables.Add(EmgAddQueryDT)
            DGV_EmgAdd.Initial(InfoDS2)
            InfoDS3.Tables.Add(DentalAddQueryDT)
            DGV_DentalAdd.Initial(InfoDS3)
            InfoDS4.Tables.Add(DeptAddQueryDT)
            DGV_DeptAdd.Initial(InfoDS4)
        Catch ex As Exception
            Throw ex
        End Try


        'DGV_KidAdd.uclHeaderText("生效日", "主身份", "門急住", "計算年齡", "起", "迄", "加成率", "結束日")
    End Sub

End Class