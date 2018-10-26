Public Class UCLGridViewPartnerUISample


    Dim mainDS, mainDS2 As New DataSet

    Dim hashTable As New Hashtable()


    Function genDataSet(ByVal saveData As DataSet, ByVal tableName As String, ByVal columnNameDB As Array) As DataSet

        saveData.Tables.Add(tableName)

        '新增Table的欄位
        For i As Integer = 0 To columnNameDB.Length - 1
            saveData.Tables(saveData.Tables.Count - 1).Columns.Add(columnNameDB(i))
        Next
        Return saveData
    End Function

    Private Sub UCLGridViewPartnerUISample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        row2("Main_Id_Code") = "02"
        row2("Main_Id_Name") = "A100000002"
        row2("CheckBox_Id_Name") = "Y"
        row2("Sub_Id_Code") = "002"
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
 
 

        mainDS2 = mainDS.Copy





        UclDataGridViewUI1.Initial(mainDS.Copy)  ' 初始化GridView1

        '  UclDataGridViewUI2.Initial(mainDS.Copy)

        UclGridRowUpDownUI1.Initial(UclDataGridViewUI1)  '初始化資料列移動按鈕UI
        UclGridRowUpDownUI2.Initial(UclDataGridViewUI2)  '初始化資料列移動按鈕UI

        UclGridUpComboBoxUI1.Initial(UclDataGridViewUI2)  '初始化整批修改UI



        hashTable.Add(-1, mainDS.Copy)

        Dim chk_cell1 As New CheckBoxCell()
        hashTable.Add(3, chk_cell1)
        UclDataGridViewUI2.Initial(hashTable)





    End Sub

    Private Sub UclDataGridViewUI2_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles UclDataGridViewUI2.ColumnHeaderMouseClick
        If e.ColumnIndex > 0 Then
            UclGridUpComboBoxUI1.SetColumnHeaderIndex(e.ColumnIndex)
            UclGridUpComboBoxUI1.Show()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(UclDataGridViewUI2.Rows(0).Cells(0).Value)
    End Sub
End Class