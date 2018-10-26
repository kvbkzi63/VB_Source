Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility

Public Class UCLTextCodeQueryUISample


    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance '宣告EventManager
    Dim mainDS, mainDS2 As New DataSet

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    UclTextCodeQueryUI1.uclQueryValue = "ER"
    'End Sub

    Private Sub doUcrOpenWindowValue2(ByVal uclName As String, ByVal ds As DataSet) Handles pvtReceiveMgr.UclOpenWindowValue2

        If ds.Tables.Count > 0 Then

        End If

    End Sub

    Private Sub doUcrOpenWindowValue(ByVal uclName As String, ByVal uclCodeValue1 As String, ByVal uclCodeValue2 As String, ByVal uclCodeName As String) Handles pvtReceiveMgr.UclOpenWindowValue
        Select Case uclName
            Case Me.Name & "UclTextCodeQueryUI1"
                UclTextCodeQueryUI1.uclCodeValue1 = uclCodeValue1.Trim
                UclTextCodeQueryUI1.uclCodeValue2 = uclCodeValue2.Trim
                UclTextCodeQueryUI1.uclCodeName = uclCodeName.Trim

                Label8.Text = "uclCodeValue1:" + uclCodeValue1.Trim
                Label9.Text = "uclCodeValue2:" + uclCodeValue2.Trim
                Label10.Text = "uclCodeName:" + uclCodeName.Trim



            Case Me.Name & "UclBtnCodeQueryUI1"

                Label1.Text = "uclCodeValue1:" + uclCodeValue1.Trim
                Label2.Text = "uclCodeValue2:" + uclCodeValue2.Trim
                Label3.Text = "uclCodeName:" + uclCodeName.Trim

            Case Me.Name & "UclTextCodeQueryUI2"
                Label5.Text = "uclCodeValue1:" + uclCodeValue1.Trim
                Label6.Text = "uclCodeValue2:" + uclCodeValue2.Trim
                Label7.Text = "uclCodeName:" + uclCodeName.Trim

        End Select

    End Sub

    '多選 接收UclBtnCodeQueryUI2 所選的資料(Dataset)
    Private Sub doUcrOpenWindowMultiSelectValue(ByVal uclName As String, ByVal ds As DataSet) Handles pvtReceiveMgr.UclOpenWindowMultiSelectValue
        If uclName = Me.Name & "UclBtnCodeQueryUI2" Then
            UclCheckListBoxUI1.uclItemShowFieldIndexStr = "0,1"
            UclCheckListBoxUI1.uclCodeFieldIndexStr = "0"
            UclCheckListBoxUI1.uclNameFieldIndexStr = "1"

            UclCheckListBoxUI1.Initial(ds)

        End If

        If uclName = Me.Name & "UclBtnCodeQueryUI3" Then
            UclListBoxUI1.uclItemShowFieldIndexStr = "0,1"
            UclListBoxUI1.uclCodeFieldIndexStr = "0"
            UclListBoxUI1.uclNameFieldIndexStr = "1"

            UclListBoxUI1.Initial(ds)

        End If
    End Sub

    Private Sub UclTextCodeQueryUI1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UclTextCodeQueryUI1.Leave
        Label8.Text = "uclCodeValue1:" + UclTextCodeQueryUI1.uclCodeValue1
        Label9.Text = "uclCodeValue2:" + UclTextCodeQueryUI1.uclCodeValue2
        Label10.Text = "uclCodeName:" + UclTextCodeQueryUI1.uclCodeName
    End Sub

    Private Sub UclTextCodeQueryUI2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UclTextCodeQueryUI2.Leave
        Label8.Text = "uclCodeValue1:" + UclTextCodeQueryUI2.uclCodeValue1
        Label9.Text = "uclCodeValue2:" + UclTextCodeQueryUI2.uclCodeValue2
        Label10.Text = "uclCodeName:" + UclTextCodeQueryUI2.uclCodeName
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UclTextCodeQueryUI1.uclQueryValue = "D"
    End Sub





    Function genDataSet(ByVal saveData As DataSet, ByVal tableName As String, ByVal columnNameDB As Array) As DataSet

        saveData.Tables.Add(tableName)

        '新增Table的欄位
        For i As Integer = 0 To columnNameDB.Length - 1
            saveData.Tables(saveData.Tables.Count - 1).Columns.Add(columnNameDB(i))
        Next
        Return saveData
    End Function



    Private Sub UCLTextCodeQueryUISample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim columnNameDB() As String = {"Code_Id", "Code_Name"}
        mainDS = genDataSet(mainDS, "mainID", columnNameDB)
        Dim row1 As DataRow '= mainDS.Tables(0).Rows.Add()
        Dim row2 As DataRow '= mainDS.Tables(0).Rows.Add()
        Dim row3 As DataRow '= mainDS.Tables(0).Rows.Add()

        'row1 = mainDS.Tables(0).Rows.Add()
        'row1("Code_Id") = "1"
        'row1("Code_Name") = "a"


        'row2 = mainDS.Tables(0).Rows.Add()
        'row2("Code_Id") = "2"
        'row2("Code_Name") = "b"

        'row3 = mainDS.Tables(0).Rows.Add()
        'row3("Code_Id") = "3"
        'row3("Code_Name") = "c"

        UclCheckListBoxUI1.uclItemShowFieldIndexStr = "0,1"
        UclCheckListBoxUI1.uclCodeFieldIndexStr = "0"
        UclCheckListBoxUI1.uclNameFieldIndexStr = "1"
        UclCheckListBoxUI1.Initial(mainDS.Copy)

        UclBtnCodeQueryUI2.SetPartner(UclCheckListBoxUI1)



        UclListBoxUI1.uclItemShowFieldIndexStr = "0,1"
        UclListBoxUI1.uclCodeFieldIndexStr = "0"
        UclListBoxUI1.uclNameFieldIndexStr = "1"
        UclListBoxUI1.Initial(mainDS.Copy)

        UclBtnCodeQueryUI3.SetPartner(UclListBoxUI1)

    End Sub




    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim a As New UCLTextCodeQueryUISample
        'a.Name = "aa"
        'a.Show()

        Console.WriteLine(UclTextCodeQueryUI1.getCode)
        Console.WriteLine(UclTextCodeQueryUI1.getCode2)

    End Sub

  
End Class



 