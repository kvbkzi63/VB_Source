Imports Syscom.Client.ucl

Public Class UCLGridViewUISample


    Dim mainDS, mainDS2, mainDS3, pvtDS1, pvtDS2 As New DataSet
    Dim load1 As Boolean = False
    Dim load2 As Boolean = False

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetTestDS()
        SetTestDS3()
        mainDS2 = mainDS.Copy

    End Sub

    Private Sub SetTestDS3()


        If mainDS3.Tables.Count > 0 Then
            mainDS3.Tables(0).Columns.Clear()
            mainDS3.Tables.Clear()
        End If

        'row("Main_Id_Code") = ""
        'row("Main_Id_Name") = ""


        Dim columnNameDB2() As String = {"Main_Id_Code", "Main_Id_Name", "Sub_Id_Code", "Sub_Id_Name", "Button", "Date", "CheckBox"}
        mainDS3 = genDataSet(mainDS3, "mainID", columnNameDB2)
        Dim row As DataRow '= mainDS.Tables(0).Rows.Add()


        row = mainDS3.Tables(0).Rows.Add()
        row("Main_Id_Code") = "001"
        row("Main_Id_Name") = "主身份xxx"
        row("Sub_Id_Code") = "1"
        row("Sub_Id_Name") = "次身份xxx"
        row("Button") = "btn"
        row("Date") = "2009/1/1"
        row("CheckBox") = "Y"

        row = mainDS3.Tables(0).Rows.Add()
        row("Main_Id_Code") = "002"
        row("Main_Id_Name") = "主身份fff"
        row("Sub_Id_Code") = "2"
        row("Sub_Id_Name") = "次身份ffff"
        row("Button") = "btn"
        row("Date") = "2009/1/2"
        row("CheckBox") = "N"


    End Sub

    Private Sub SetTestDS()


        If mainDS.Tables.Count > 0 Then
            mainDS.Tables(0).Columns.Clear()
            mainDS.Tables.Clear()
        End If

        'row("Main_Id_Code") = ""
        'row("Main_Id_Name") = ""


        Dim columnNameDB2() As String = {"Main_Id_Code", "Main_Id_Name", "Sub_Id_Code", "Sub_Id_Name", "Button", "Date", "CheckBox"}
        mainDS = genDataSet(mainDS, "mainID", columnNameDB2)
        Dim row As DataRow '= mainDS.Tables(0).Rows.Add()


        row = mainDS.Tables(0).Rows.Add()
        row("Main_Id_Code") = "001"
        row("Main_Id_Name") = "主身份1"
        row("Sub_Id_Code") = "1"
        row("Sub_Id_Name") = "次身份1"
        row("Button") = "btn"
        row("Date") = "2009/1/1"
        row("CheckBox") = "Y"

        row = mainDS.Tables(0).Rows.Add()
        row("Main_Id_Code") = "002"
        row("Main_Id_Name") = "主身份2"
        row("Sub_Id_Code") = "2"
        row("Sub_Id_Name") = "次身份2"
        row("Button") = "btn"
        row("Date") = "2009/1/2"
        row("CheckBox") = "N"


        row = mainDS.Tables(0).Rows.Add()
        row("Main_Id_Code") = "003"
        row("Main_Id_Name") = "主身份3"
        row("Sub_Id_Code") = "3"
        row("Sub_Id_Name") = "次身份3"
        row("Button") = "btn"
        row("Date") = "2009/1/3"
        row("CheckBox") = "N"

        row = mainDS.Tables(0).Rows.Add()
        row("Main_Id_Code") = "004"
        row("Main_Id_Name") = "主身份4"
        row("Sub_Id_Code") = "4"
        row("Sub_Id_Name") = "次身份4"
        row("Button") = "btn"
        row("Date") = "2009/1/4"
        row("CheckBox") = "Y"

        row = mainDS.Tables(0).Rows.Add()
        row("Main_Id_Code") = "005"
        row("Main_Id_Name") = "主身份5"
        row("Sub_Id_Code") = "5"
        row("Sub_Id_Name") = "次身份5"
        row("Button") = "btn"
        row("Date") = "2009/1/5"
        row("CheckBox") = "N"


        row = mainDS.Tables(0).Rows.Add()
        row("Main_Id_Code") = "006"
        row("Main_Id_Name") = "主身份6"
        row("Sub_Id_Code") = "6"
        row("Sub_Id_Name") = "次身份6"
        row("Button") = "btn"
        row("Date") = "2009/1/6"
        row("CheckBox") = "N"


        row = mainDS.Tables(0).Rows.Add()
        row("Main_Id_Code") = "007"
        row("Main_Id_Name") = "主身份7"
        row("Sub_Id_Code") = "7"
        row("Sub_Id_Name") = "次身份7"
        row("Button") = "btn"
        row("Date") = "2009/1/7"
        row("CheckBox") = "N"


        row = mainDS.Tables(0).Rows.Add()
        row("Main_Id_Code") = "008"
        row("Main_Id_Name") = "主身份8"
        row("Sub_Id_Code") = "8"
        row("Sub_Id_Name") = "次身份8"
        row("Button") = "btn"
        row("Date") = "2009/1/2"
        row("CheckBox") = "Y"
    End Sub
    Function genDataSet(ByVal saveData As DataSet, ByVal tableName As String, ByVal columnNameDB As Array) As DataSet

        saveData.Tables.Add(tableName)

        '新增Table的欄位
        For i As Integer = 0 To columnNameDB.Length - 1
            saveData.Tables(saveData.Tables.Count - 1).Columns.Add(columnNameDB(i))
        Next
        Return saveData
    End Function



    Private Sub ReSet()
        UclDataGridViewUI1.uclHeaderText = ""
        UclDataGridViewUI1.uclColumnWidth = ""
        UclDataGridViewUI1.uclNonVisibleColIndex = ""

        UclDataGridViewUI1.MultiSelect = False
        UclDataGridViewUI1.uclColumnCheckBox = False
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.SelectedIndex = 0 Then
            '1:給一Dataset(並在GridView中顯示其內容)
            UclDataGridViewUI2.Visible = False
            UclDataGridViewUI3.Visible = False
            UclDataGridViewUI1.Visible = True
            UclDataGridViewUI4.Visible = False

            Button1.Visible = False
            SetTestDS()
            ReSet()
            UclDataGridViewUI1.Initial(mainDS.Copy)
            RichTextBox1.Text = "UclDataGridViewUI1.Initial(mainDS) " + vbCrLf + vbCrLf
        ElseIf ComboBox1.SelectedIndex = 1 Then
            UclDataGridViewUI2.Visible = False
            UclDataGridViewUI3.Visible = False
            UclDataGridViewUI1.Visible = True
            UclDataGridViewUI4.Visible = False

            Button1.Visible = False
            '2:拖拉列交換()
            SetTestDS()
            ReSet()
            UclDataGridViewUI1.Initial(mainDS.Copy)

            RichTextBox1.Text = "AllowDrop 屬性設定成為True" + vbCrLf
            RichTextBox1.Text += "在下方選擇一列試拖拉看看..." + vbCrLf + vbCrLf

        ElseIf ComboBox1.SelectedIndex = 2 Then
            '3.設定Column Header Text
            UclDataGridViewUI2.Visible = False
            UclDataGridViewUI3.Visible = False
            UclDataGridViewUI1.Visible = True
            UclDataGridViewUI4.Visible = False

            Button1.Visible = False
            SetTestDS()
            ReSet()
            UclDataGridViewUI1.Initial(mainDS.Copy)

            UclDataGridViewUI1.uclHeaderText = "A,B,C"
            RichTextBox1.Text = "UclDataGridViewUI1.Initial(mainDS) " + vbCrLf
            RichTextBox1.Text += "UclDataGridViewUI1.uclHeaderText = ""A,B,C""  " + vbCrLf + vbCrLf
            RichTextBox1.Text += "沒設定的Column則以DataSet裡的名稱為主 " + vbCrLf

        ElseIf ComboBox1.SelectedIndex = 3 Then
            '4.設定Column Header Width
            UclDataGridViewUI2.Visible = False
            UclDataGridViewUI3.Visible = False
            UclDataGridViewUI1.Visible = True
            UclDataGridViewUI4.Visible = False

            Button1.Visible = False
            SetTestDS()

            ReSet()
            UclDataGridViewUI1.Initial(mainDS.Copy)

            UclDataGridViewUI1.uclColumnWidth = "200,100,20,180"
            RichTextBox1.Text = "UclDataGridViewUI1.Initial(mainDS) " + vbCrLf
            RichTextBox1.Text += "UclDataGridViewUI1.uclColumnWidth = ""200,100,20,180""  " + vbCrLf + vbCrLf
            RichTextBox1.Text += "沒設定的Column則以DataSet裡的名稱Width為主 " + vbCrLf

        ElseIf ComboBox1.SelectedIndex = 4 Then
            '5:設定要隱藏的Column()
            UclDataGridViewUI2.Visible = False
            UclDataGridViewUI3.Visible = False
            UclDataGridViewUI1.Visible = True
            UclDataGridViewUI4.Visible = False

            Button1.Visible = False
            SetTestDS()
            ReSet()
            UclDataGridViewUI1.Initial(mainDS.Copy)

            UclDataGridViewUI1.uclNonVisibleColIndex = "1,3"
            RichTextBox1.Text = "UclDataGridViewUI1.Initial(mainDS) " + vbCrLf
            RichTextBox1.Text += "UclDataGridViewUI1.uclNonVisibleColIndex = ""1,3""  " + vbCrLf + vbCrLf
            RichTextBox1.Text += "隱藏Column Index  1 ,3 " + vbCrLf

        ElseIf ComboBox1.SelectedIndex = 5 Then
            '6:固定顯示某些Column()

            UclDataGridViewUI2.Visible = False
            UclDataGridViewUI3.Visible = False
            UclDataGridViewUI1.Visible = True
            UclDataGridViewUI4.Visible = False

            Button1.Visible = False
            SetTestDS()
            ReSet()
            UclDataGridViewUI1.Initial(mainDS.Copy)
            UclDataGridViewUI1.Columns(0).Frozen = True
            UclDataGridViewUI1.uclColumnWidth = "100,300,120,180"
            RichTextBox1.Text = "UclDataGridViewUI1.Initial(mainDS) " + vbCrLf
            RichTextBox1.Text += "UclDataGridViewUI1.Columns(0).Frozen = True" + vbCrLf + vbCrLf
            RichTextBox1.Text += "固定Column 0 的設定方法 " + vbCrLf



        ElseIf ComboBox1.SelectedIndex = 6 Then
            '7:設定可進行排序的Column()

            SetTestDS()
            ReSet()
            UclDataGridViewUI2.Visible = False
            UclDataGridViewUI3.Visible = False
            UclDataGridViewUI1.Visible = True
            UclDataGridViewUI4.Visible = False

            Button1.Visible = False
            UclDataGridViewUI1.Initial(mainDS.Copy)
            UclDataGridViewUI1.uclSortColIndex = "0,2"
            RichTextBox1.Text = "UclDataGridViewUI1.Initial(mainDS) " + vbCrLf
            RichTextBox1.Text += "UclDataGridViewUI1.uclSortColIndex = ""0,2""  " + vbCrLf + vbCrLf
            RichTextBox1.Text += "沒設定的Column則無法點擊排序 " + vbCrLf



        ElseIf ComboBox1.SelectedIndex = 7 Then
            '8:GridView Cell中加入UCL元件 (單選)
            SetTestDS()
            ReSet()
            Button1.Visible = True
            UclDataGridViewUI1.Visible = False
            UclDataGridViewUI3.Visible = False
            UclDataGridViewUI4.Visible = True
            UclDataGridViewUI2.Visible = False
            If Not load1 Then







                '首先 New一個HashTable物件
                Dim hashTable As New Hashtable()


                '建立GridView所需要的Cell元件
                Dim cbo_cell1 As New ComboBoxCell()
                Dim txt_cell1 As New TextBoxCell()
                Dim chk_cell1 As New CheckBoxCell()
                Dim dtp_cell1 As New DtpCell()
                Dim btn_cell1 As New ButtonCell()

                '設定各個Cell的屬性(初始化)
                'combobox
                cbo_cell1.Ds = mainDS2.Copy
                cbo_cell1.DisplayIndex = "0,1"
                cbo_cell1.ValueIndex = "0"

                'button
                btn_cell1.Text = "按我"

                Console.WriteLine(mainDS.Tables(0).Columns.Count.ToString)

                '將Cell加入到 hashTable中, 第一個參數代表Index位置  ,-1位置代表要在GridView顯示的DS
                hashTable.Add(-1, mainDS.Copy)
                hashTable.Add(1, txt_cell1)

                hashTable.Add(4, btn_cell1)
                hashTable.Add(5, dtp_cell1)
                hashTable.Add(6, chk_cell1)

                UclDataGridViewUI4.Initial(hashTable)

                Console.WriteLine(UclDataGridViewUI4.GetDBDS.Tables(0).Columns.Count.ToString & "GetDBDS")
                Console.WriteLine(UclDataGridViewUI4.Columns.Count.ToString & "GridDS")
            Else
                UclDataGridViewUI4.SetDS(mainDS.Copy)
            End If
            load1 = True

            'UclDataGridViewUI4.DataSource = mainDS2.Copy

            RichTextBox1.Text = "1.Imports Syscom.Client.ucl  " + vbCrLf + vbCrLf
            RichTextBox1.Text += "2.首先 New一個HashTable物件  " + vbCrLf
            RichTextBox1.Text += "   Dim hashTable As New Hashtable()  " + vbCrLf + vbCrLf

            RichTextBox1.Text += "3.建立GridView中需求的Cell格式,每一個Column使用建立一個(舉例如下)  " + vbCrLf
            RichTextBox1.Text += "   Dim cbo_cell1 As New ComboBoxCell()   => ComboBox Cell " + vbCrLf
            RichTextBox1.Text += "   Dim txt_cell1 As New TextBoxCell()  => TextBox Cell " + vbCrLf
            RichTextBox1.Text += "   Dim chk_cell1 As New CheckBoxCell()  => CheckBox Cell " + vbCrLf
            RichTextBox1.Text += "   Dim dtp_cell1 As New DtpCell()  => DateTimePicker Cell " + vbCrLf
            RichTextBox1.Text += "   Dim btn_cell1 As New ButtonCell()  => Button Cell " + vbCrLf + vbCrLf

            RichTextBox1.Text += "4.設定 每一種Cell元件的屬性 " + vbCrLf
            RichTextBox1.Text += "   cbo_cell1.Ds = mainDS2" + vbCrLf
            RichTextBox1.Text += "   cbo_cell1.DisplayIndex = ""0,1""  " + vbCrLf
            RichTextBox1.Text += "   cbo_cell1.ValueIndex = ""0""  " + vbCrLf
            RichTextBox1.Text += "   btn_cell1.Text = ""按我""  " + vbCrLf
            RichTextBox1.Text += "   其餘設定請參考此Form原始碼..." + vbCrLf + vbCrLf

            RichTextBox1.Text += "5.將Cell加入到 hashTable中, 第一個參數代表Index在Grid中的位置(DS第一行算0)  ,-1位置代表要在GridView顯示的DS " + vbCrLf
            RichTextBox1.Text += "  hashTable.Add(-1, mainDS)" + vbCrLf
            RichTextBox1.Text += "  hashTable.Add(1, txt_cell1)" + vbCrLf
            RichTextBox1.Text += "  hashTable.Add(4, btn_cell1)" + vbCrLf
            RichTextBox1.Text += "  hashTable.Add(5, dtp_cell1)" + vbCrLf
            RichTextBox1.Text += "  hashTable.Add(6, chk_cell1)" + vbCrLf + vbCrLf

            RichTextBox1.Text += "6.將hashTable物件傳給GridView進行初始化 " + vbCrLf
            RichTextBox1.Text += "  UclDataGridViewUI1.Initial(hashTable) " + vbCrLf + vbCrLf

            RichTextBox1.Text += "7.要編輯Cell請在Cell上點擊2下 " + vbCrLf




        ElseIf ComboBox1.SelectedIndex = 8 Then
            '9:GridView Cell中加入UCL元件 
            SetTestDS()
            ReSet()

            UclDataGridViewUI1.Visible = False
            UclDataGridViewUI3.Visible = False
            UclDataGridViewUI2.Visible = True
            UclDataGridViewUI4.Visible = False
            Button1.Visible = True
            If Not load2 Then




                UclDataGridViewUI2.MultiSelect = True
                UclDataGridViewUI2.uclColumnCheckBox = True


                '首先 New一個HashTable物件
                Dim hashTable As New Hashtable()


                '建立GridView所需要的Cell元件
                Dim cbo_cell1 As New ComboBoxCell()
                Dim txt_cell1 As New TextBoxCell()
                Dim chk_cell1 As New CheckBoxCell()
                Dim dtp_cell1 As New DtpCell()
                Dim btn_cell1 As New ButtonCell()

                '設定各個Cell的屬性(初始化)
                'combobox
                cbo_cell1.Ds = mainDS2.Copy
                cbo_cell1.DisplayIndex = "0,1"
                cbo_cell1.ValueIndex = "0"

                'button
                btn_cell1.Text = "按我"



                '將Cell加入到 hashTable中, 第一個參數代表Index位置  ,-1位置代表要在GridView顯示的DS
                hashTable.Add(-1, mainDS.Copy)
                hashTable.Add(2, txt_cell1)

                hashTable.Add(5, btn_cell1)
                hashTable.Add(6, dtp_cell1)
                hashTable.Add(7, chk_cell1)

                UclDataGridViewUI2.Initial(hashTable)
            Else
                UclDataGridViewUI2.SetDS(mainDS.Copy)
            End If
            load2 = True

            '  UclDataGridViewUI2.DataSource = mainDS2.Copy

            RichTextBox1.Text = "1.Imports Syscom.Client.ucl  " + vbCrLf + vbCrLf
            RichTextBox1.Text += "2.首先 New一個HashTable物件  " + vbCrLf
            RichTextBox1.Text += "   Dim hashTable As New Hashtable()  " + vbCrLf + vbCrLf

            RichTextBox1.Text += "3.建立GridView中需求的Cell格式,每一個Column使用建立一個(舉例如下)  " + vbCrLf
            RichTextBox1.Text += "   Dim cbo_cell1 As New ComboBoxCell()   => ComboBox Cell " + vbCrLf
            RichTextBox1.Text += "   Dim txt_cell1 As New TextBoxCell()  => TextBox Cell " + vbCrLf
            RichTextBox1.Text += "   Dim chk_cell1 As New CheckBoxCell()  => CheckBox Cell " + vbCrLf
            RichTextBox1.Text += "   Dim dtp_cell1 As New DtpCell()  => DateTimePicker Cell " + vbCrLf
            RichTextBox1.Text += "   Dim btn_cell1 As New ButtonCell()  => Button Cell " + vbCrLf + vbCrLf

            RichTextBox1.Text += "4.設定 每一種Cell元件的屬性 " + vbCrLf
            RichTextBox1.Text += "   cbo_cell1.Ds = mainDS2" + vbCrLf
            RichTextBox1.Text += "   cbo_cell1.DisplayIndex = ""0,1""  " + vbCrLf
            RichTextBox1.Text += "   cbo_cell1.ValueIndex = ""0""  " + vbCrLf
            RichTextBox1.Text += "   btn_cell1.Text = ""按我""  " + vbCrLf
            RichTextBox1.Text += "   其餘設定請參考此Form原始碼..." + vbCrLf + vbCrLf

            RichTextBox1.Text += "5.將Cell加入到 hashTable中, 第一個參數代表Index在Grid中的位置(多選第一行算0)  ,-1位置代表要在GridView顯示的DS " + vbCrLf
            RichTextBox1.Text += "  hashTable.Add(-1, mainDS)" + vbCrLf
            RichTextBox1.Text += "  hashTable.Add(2, txt_cell1)" + vbCrLf
            RichTextBox1.Text += "  hashTable.Add(5, btn_cell1)" + vbCrLf
            RichTextBox1.Text += "  hashTable.Add(6, dtp_cell1)" + vbCrLf
            RichTextBox1.Text += "  hashTable.Add(7, chk_cell1)" + vbCrLf + vbCrLf

            RichTextBox1.Text += "6.將hashTable物件傳給GridView進行初始化 " + vbCrLf
            RichTextBox1.Text += "  UclDataGridViewUI1.Initial(hashTable) " + vbCrLf + vbCrLf

            RichTextBox1.Text += "7.要編輯Cell請在Cell上點擊2下 " + vbCrLf

        ElseIf ComboBox1.SelectedIndex = 9 Then
            '10:GridView多選設定


            UclDataGridViewUI1.Visible = False
            UclDataGridViewUI2.Visible = False
            UclDataGridViewUI3.Visible = True
            UclDataGridViewUI4.Visible = False

            SetTestDS()
            ReSet()
            UclDataGridViewUI3.MultiSelect = True
            UclDataGridViewUI3.uclColumnCheckBox = True
            UclDataGridViewUI3.Initial(mainDS.Copy)
            RichTextBox1.Text = "MultiSelect 屬性設定成為True , uclColumnCheckBox 屬性設定成為True  " + vbCrLf
            RichTextBox1.Text += "再初始化DataGridView   " + vbCrLf
        End If




    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex = 7 Then
            UclDataGridViewUI4.SetDS(mainDS3)

        ElseIf ComboBox1.SelectedIndex = 8 Then
            UclDataGridViewUI2.SetDS(mainDS3)

        End If



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(UclDataGridViewUI4.GetDBDS.Tables(0).Rows.Count)
    End Sub
End Class