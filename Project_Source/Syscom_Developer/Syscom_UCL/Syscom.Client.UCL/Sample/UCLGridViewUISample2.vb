Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM

Public Class UCLGridViewUISample2
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance '宣告EventManager


    Dim hashTable As New Hashtable()
    Dim gblXPosition, gblYPosition As Integer
    Dim gblOrginalColor As Color



    Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        'SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        'UclChartNoUI2.BackColor = Color.Transparent
        'UclDataGridViewUI1.s()

    End Sub




    Function genDataSet(ByVal saveData As DataSet, ByVal tableName As String, ByVal columnNameDB As Array) As DataSet

        saveData.Tables.Add(tableName)

        '新增Table的欄位
        For i As Integer = 0 To columnNameDB.Length - 1
            saveData.Tables(saveData.Tables.Count - 1).Columns.Add(columnNameDB(i))
        Next
        Return saveData
    End Function

    Dim mainDS, mainDS2 As New DataSet

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        row2("Main_Id_Name") = "A100000121212002" & vbCrLf & "aaaabbbbcc"
        row2("CheckBox_Id_Name") = "Y"
        row2("Sub_Id_Code") = "002"
        row2("Sub_Id_Name") = "2009/05/05"
        row2("Button") = "Button1"
        row2("CheckBox") = "Y"


        row2 = mainDS.Tables(0).Rows.Add()
        row2("Main_Id_Code") = "03"
        row2("Main_Id_Name") = "A100001231232130003 A100000003"
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

        row2 = mainDS.Tables(0).Rows.Add()
        row2("Main_Id_Code") = "06"
        row2("Main_Id_Name") = "A100000006"
        row2("CheckBox_Id_Name") = "Y"
        row2("Sub_Id_Code") = "006"
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

        row2("Name") = "藥品2"


        mainDS2 = genDataSet(mainDS2, "mainID", columnNameDB)
        Dim row3 As DataRow '= mainDS.Tables(0).Rows.Add()
        Dim row4 As DataRow '= mainDS.Tables(0).Rows.Add()
        mainDS2.Tables(0).Columns(4).DataType = System.Type.GetType("System.DateTime")

        'row("Main_Id_Code") = ""
        'row("Main_Id_Name") = ""

        row3 = mainDS2.Tables(0).Rows.Add()
        row3("Main_Id_Code") = "03"
        row3("Main_Id_Name") = "A100000003"
        row3("CheckBox_Id_Name") = "N"
        row3("Sub_Id_Code") = "003"
        row3("Sub_Id_Name") = "2009/05/05"
        row3("Button") = "Button3"
        row3("CheckBox") = "Y"
        row3("Name") = "藥品1"


        row4 = mainDS2.Tables(0).Rows.Add()
        row4("Main_Id_Code") = "04"
        row4("Main_Id_Name") = "A100000004"
        row4("CheckBox_Id_Name") = "Y"
        row4("Sub_Id_Code") = "004"
        row4("Sub_Id_Name") = "2009/05/05"
        row4("Button") = "Button4"
        row4("CheckBox") = "Y"


        row4("Name") = "藥品2"

        hashTable.Add(-1, mainDS.Copy)

        Dim chk_cell1 As New CheckBoxCell()
        hashTable.Add(2, chk_cell1)
        'UclDataGridViewUI3.Initial(hashTable)
        UclDataGridViewUI3.Initial(mainDS.Copy)
        ds = mainDS.Copy
        UclDataGridViewUI3.uclHeaderText = "aa,bb"
        ' DataGridView1.Columns (0).h
        'UclDataGridViewUI3.Columns(1).HeaderText = "123"
        'UclDataGridViewUI3.Columns(2).HeaderText = "1234"
        UCLScreenUtil.SetGridWrap(UclDataGridViewUI3)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.DataSource = mainDS.Tables(0)
        UclDataGridViewUI1.Initial(mainDS)
        UclDataGridViewUI2.Initial(mainDS)

        DataGridView1(2, 2).Style.BackColor = Color.Red
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If mainDS.Tables(0).Rows.Count > 0 Then
            mainDS.Tables(0).Rows.RemoveAt(0)
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DataGridView1.DataSource = mainDS2.Tables(0).Copy
        UclDataGridViewUI1.Initial(mainDS2.Copy)
        UclDataGridViewUI2.Initial(mainDS2.Copy)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If mainDS2.Tables(0).Rows.Count > 0 Then
            mainDS2.Tables(0).Rows.RemoveAt(0)
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        UclDataGridViewUI1.ClearDS()
        UclDataGridViewUI2.ClearDS()
    End Sub




    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(UclDataGridViewUI3.CurrentCell.ColumnIndex.ToString)
    End Sub


    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(UclDataGridViewUI3.Rows(0).Cells(3).Value.ToString)
    End Sub
    Dim ds As New DataSet

    Private Sub Button6_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ds.Tables(0).Rows.RemoveAt(0)
        UclDataGridViewUI3.SetDS(ds.Copy)


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(UclDataGridViewUI3.GetDBDS.Tables(0).Rows(0).Item(2).ToString)
    End Sub

    Private Sub Button6_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If UclDataGridViewUI2.GetSelectedIndex IsNot Nothing AndAlso UclDataGridViewUI2.GetSelectedIndex.Count > 0 Then
            For i As Integer = 0 To UclDataGridViewUI2.GetSelectedIndex.Count - 1
                Console.WriteLine(UclDataGridViewUI2.GetSelectedIndex(i).ToString & UclDataGridViewUI2.GetGridDS.Tables(0).Rows(UclDataGridViewUI2.GetSelectedIndex(i)).Item(0).ToString.Trim)
            Next
        End If


    End Sub


    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Dim pvtColor As System.Drawing.Color

        '判斷是否點選Cell(避免因點選Header時造成錯誤)
        If e.ColumnIndex <> -1 AndAlso e.RowIndex <> -1 Then

            '取得原Cell背景顏色
            pvtColor = DataGridView1(e.ColumnIndex, e.RowIndex).Style.BackColor

            '將選取Cell設回原Cell背景顏色
            If pvtColor <> Color.Empty Then
                DataGridView1(e.ColumnIndex, e.RowIndex).Style.SelectionBackColor = pvtColor
            Else
                DataGridView1(e.ColumnIndex, e.RowIndex).Style.SelectionBackColor = Color.White
                DataGridView1(e.ColumnIndex, e.RowIndex).Style.SelectionForeColor = Color.Black
            End If
        End If

    End Sub

   
  
End Class