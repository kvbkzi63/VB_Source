Public Class Other


    Dim mainDS, mainDS2 As New DataSet


    Function genDataSet(ByVal saveData As DataSet, ByVal tableName As String, ByVal columnNameDB As Array) As DataSet

        saveData.Tables.Add(tableName)

        '新增Table的欄位
        For i As Integer = 0 To columnNameDB.Length - 1
            saveData.Tables(saveData.Tables.Count - 1).Columns.Add(columnNameDB(i))
        Next
        Return saveData
    End Function


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UclIdentityUI1.Initial()
 
        Dim columnNameDB() As String = {"Main_Id_Code", "Main_Id_Name", "CheckBox_Id_Name", "Sub_Id_Code", "Sub_Id_Name", "Button", "CheckBox", "Name"}
        mainDS = genDataSet(mainDS, "mainID", columnNameDB)
        Dim row1 As DataRow '= mainDS.Tables(0).Rows.Add()
        Dim row2 As DataRow '= mainDS.Tables(0).Rows.Add()
        mainDS.Tables(0).Columns(4).DataType = System.Type.GetType("System.DateTime")

        'row("Main_Id_Code") = ""
        'row("Main_Id_Name") = ""

        row1 = mainDS.Tables(0).Rows.Add()
        row1("Main_Id_Code") = "01"
        row1("Main_Id_Name") = "A100000001"
        row1("CheckBox_Id_Name") = "N"
        row1("Sub_Id_Code") = "001"
        row1("Sub_Id_Name") = "2009/05/05"
        row1("Button") = "Button1"
        row1("CheckBox") = "Y"
        row1("Name") = "藥品1"


        row2 = mainDS.Tables(0).Rows.Add()
        row2("Main_Id_Code") = "06"
        row2("Main_Id_Name") = "A100000006"
        row2("CheckBox_Id_Name") = "Y"
        row2("Sub_Id_Code") = "006"
        row2("Sub_Id_Name") = "2009/05/05"
        row2("Button") = "Button1"
        row2("CheckBox") = "Y"


        row2 = mainDS.Tables(0).Rows.Add()
        row2("Main_Id_Code") = "03"
        row2("Main_Id_Name") = "A100000003"
        row2("CheckBox_Id_Name") = "Y"
        row2("Sub_Id_Code") = "003"
        row2("Sub_Id_Name") = "2009/05/05"
        row2("Button") = "Button1"
        row2("CheckBox") = "Y"

        row2 = mainDS.Tables(0).Rows.Add()
        row2("Main_Id_Code") = "07"
        row2("Main_Id_Name") = "A100000007"
        row2("CheckBox_Id_Name") = "Y"
        row2("Sub_Id_Code") = "007"
        row2("Sub_Id_Name") = "2009/05/05"
        row2("Button") = "Button1"
        row2("CheckBox") = "Y"


        row2 = mainDS.Tables(0).Rows.Add()
        row2("Main_Id_Code") = "04"
        row2("Main_Id_Name") = "A100000004"
        row2("CheckBox_Id_Name") = "Y"
        row2("Sub_Id_Code") = "004"
        row2("Sub_Id_Name") = "2009/05/05"
        row2("Button") = "Button1"
        row2("CheckBox") = "Y"

        row2 = mainDS.Tables(0).Rows.Add()
        row2("Main_Id_Code") = "05"
        row2("Main_Id_Name") = "A100000005"
        row2("CheckBox_Id_Name") = "Y"
        row2("Sub_Id_Code") = "005"
        row2("Sub_Id_Name") = "2009/05/05"
        row2("Button") = "Button1"
        row2("CheckBox") = "Y"

        row2 = mainDS.Tables(0).Rows.Add()
        row2("Main_Id_Code") = "08"
        row2("Main_Id_Name") = "A100000008"
        row2("CheckBox_Id_Name") = "Y"
        row2("Sub_Id_Code") = "008"
        row2("Sub_Id_Name") = "2009/05/05"
        row2("Button") = "Button1"
        row2("CheckBox") = "Y"


        row2 = mainDS.Tables(0).Rows.Add()
        row2("Main_Id_Code") = "02"
        row2("Main_Id_Name") = "A100000002"
        row2("CheckBox_Id_Name") = "Y"
        row2("Sub_Id_Code") = "002"
        row2("Sub_Id_Name") = "2009/05/05"
        row2("Button") = "Button1"
        row2("CheckBox") = "Y"

        'ComboBox1.p
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        UclListBoxUI1.uclItemShowFieldIndexStr = "0,1"
        UclListBoxUI1.uclCodeFieldIndexStr = "0"
        UclListBoxUI1.uclNameFieldIndexStr = "1"
        UclListBoxUI1.Initial(mainDS)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        UclCheckListBoxUI1.uclItemShowFieldIndexStr = "0,1"
        UclCheckListBoxUI1.uclCodeFieldIndexStr = "0"
        UclCheckListBoxUI1.uclNameFieldIndexStr = "1"
        UclCheckListBoxUI1.Initial(mainDS)
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If UclCheckListBoxUI1.GetSelectedItemCodes IsNot Nothing AndAlso UclCheckListBoxUI1.GetSelectedItemCodes.Count > 0 Then

            For i As Integer = 0 To UclCheckListBoxUI1.GetSelectedItemCodes.Count - 1
                MessageBox.Show(UclCheckListBoxUI1.GetSelectedItemCodes(i))
            Next
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If UclCheckListBoxUI1.GetSelectedItemNames IsNot Nothing AndAlso UclCheckListBoxUI1.GetSelectedItemNames.Count > 0 Then
            For i As Integer = 0 To UclCheckListBoxUI1.GetSelectedItemNames.Count - 1
                MessageBox.Show(UclCheckListBoxUI1.GetSelectedItemNames(i))
            Next
        End If

    End Sub

    

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        MessageBox.Show(UclCheckListBoxUI1.uclSelectedItemIndex)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If UclCheckListBoxUI1.GetNonSelectedItemCodes IsNot Nothing AndAlso UclCheckListBoxUI1.GetNonSelectedItemCodes.Count > 0 Then

            For i As Integer = 0 To UclCheckListBoxUI1.GetNonSelectedItemCodes.Count - 1
                MessageBox.Show(UclCheckListBoxUI1.GetNonSelectedItemCodes(i))
            Next
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If UclCheckListBoxUI1.GetNonSelectedItemNames IsNot Nothing AndAlso UclCheckListBoxUI1.GetNonSelectedItemNames.Count > 0 Then
            For i As Integer = 0 To UclCheckListBoxUI1.GetNonSelectedItemNames.Count - 1
                MessageBox.Show(UclCheckListBoxUI1.GetNonSelectedItemNames(i))
            Next
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        MessageBox.Show(UclCheckListBoxUI1.uclNonSelectedItemIndex)
    End Sub

     

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If UclCheckListBoxUI1.Items.Count > 1 Then
            UclCheckListBoxUI1.Items.RemoveAt(UclCheckListBoxUI1.Items.Count - 1)
        End If

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        
        UclCheckListBoxUI1.Sort(0)
      
    End Sub
 
End Class