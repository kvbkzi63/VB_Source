Public Class UCLComboBoxUISample


    Dim mainDS, mainDS2 As New DataSet


    Function genDataSet(ByVal saveData As DataSet, ByVal tableName As String, ByVal columnNameDB As Array) As DataSet

        saveData.Tables.Add(tableName)

        '新增Table的欄位
        For i As Integer = 0 To columnNameDB.Length - 1
            saveData.Tables(saveData.Tables.Count - 1).Columns.Add(columnNameDB(i))
        Next
        Return saveData
    End Function


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        RichTextBox1.Text += "UclComboBoxUI1.DataSource = mainDS.Tables(0) " + vbCrLf + vbCrLf
        RichTextBox1.Text += "UclComboBoxUI1.uclDisplayIndex = ""0,2,3,1""   text要顯示table對應的哪些欄位" + vbCrLf
        RichTextBox1.Text += "UclComboBoxUI1.uclValueIndex = ""0"" 設定ValueIndex,以查詢相對的項目" + vbCrLf
        RichTextBox1.Text += "會自動加入一個空白項到ComboBox內" + vbCrLf



        Dim columnNameDB() As String = {"Main_Id_Code", "Main_Id_Name", "CheckBox_Id_Name", "Sub_Id_Code", "Sub_Id_Name", "Button", "CheckBox", "Name"}
        mainDS = genDataSet(mainDS, "mainID", columnNameDB)
        Dim row1 As DataRow '= mainDS.Tables(0).Rows.Add()
        'Dim row2 As DataRow '= mainDS.Tables(0).Rows.Add()
        mainDS.Tables(0).Columns(4).DataType = System.Type.GetType("System.DateTime")
        mainDS.Tables(0).Columns(0).DataType = System.Type.GetType("System.Int32")
        'row("Main_Id_Code") = ""
        'row("Main_Id_Name") = ""

        row1 = mainDS.Tables(0).Rows.Add()
        row1("Main_Id_Code") = 1
        row1("Main_Id_Name") = "A100000001"
        row1("CheckBox_Id_Name") = "N"
        row1("Sub_Id_Code") = "001"
        row1("Sub_Id_Name") = "2009/05/05"
        row1("Button") = "Button1"
        row1("CheckBox") = "Y"
        row1("Name") = "藥品1"


        'row2 = mainDS.Tables(0).Rows.Add()
        'row2("Main_Id_Code") = "02"
        'row2("Main_Id_Name") = "A100000002"
        'row2("CheckBox_Id_Name") = "Y"
        'row2("Sub_Id_Code") = "002"
        'row2("Sub_Id_Name") = "2009/05/05"
        'row2("Button") = "Button1"
        'row2("CheckBox") = "Y"


        'row2 = mainDS.Tables(0).Rows.Add()
        'row2("Main_Id_Code") = "02"
        'row2("Main_Id_Name") = "A100000002"
        'row2("CheckBox_Id_Name") = "Y"
        'row2("Sub_Id_Code") = "002"
        'row2("Sub_Id_Name") = "2009/05/05"
        'row2("Button") = "Button1"
        'row2("CheckBox") = "Y"

        'row2 = mainDS.Tables(0).Rows.Add()
        'row2("Main_Id_Code") = "02"
        'row2("Main_Id_Name") = "A100000002"
        'row2("CheckBox_Id_Name") = "Y"
        'row2("Sub_Id_Code") = "002"
        'row2("Sub_Id_Name") = "2009/05/05"
        'row2("Button") = "Button1"
        'row2("CheckBox") = "Y"

        'row2 = mainDS.Tables(0).Rows.Add()
        'row2("Main_Id_Code") = "02"
        'row2("Main_Id_Name") = "A100000002"
        'row2("CheckBox_Id_Name") = "Y"
        'row2("Sub_Id_Code") = "002"
        'row2("Sub_Id_Name") = "2009/05/05"
        'row2("Button") = "Button1"
        'row2("CheckBox") = "Y"

        'row2 = mainDS.Tables(0).Rows.Add()
        'row2("Main_Id_Code") = "02"
        'row2("Main_Id_Name") = "A100000002"
        'row2("CheckBox_Id_Name") = "Y"
        'row2("Sub_Id_Code") = "002"
        'row2("Sub_Id_Name") = "2009/05/05"
        'row2("Button") = "Button1"
        'row2("CheckBox") = "Y"

        'row2 = mainDS.Tables(0).Rows.Add()
        'row2("Main_Id_Code") = "02"
        'row2("Main_Id_Name") = "A100000002"
        'row2("CheckBox_Id_Name") = "Y"
        'row2("Sub_Id_Code") = "002"
        'row2("Sub_Id_Name") = "2009/05/05"
        'row2("Button") = "Button1"
        'row2("CheckBox") = "Y"

        'row2("Name") = "藥品2"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        UclComboBoxUI1.DataSource = mainDS.Tables(0).Copy
        UclComboBoxUI1.uclDisplayIndex = "0,2,3,1"
        UclComboBoxUI1.uclValueIndex = "0"

    End Sub

    Private Sub UclComboBoxUI1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UclComboBoxUI1.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MessageBox.Show(UclComboBoxUI1.SelectedValue)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        UclComboBoxUI1.SelectedValue = ""
    End Sub
End Class