Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility

Public Class Form4



    Dim mainDS As New DataSet
    Dim mainDS1 As New DataSet
    Dim cbo1DS As New DataSet
    Dim cbo2DS As New DataSet

    Dim hashTable As New Hashtable()



    Dim WithEvents pvtReceiveComboBoxGridMgr As EventManager = EventManager.getInstance

    Private Sub receiveComboBoxGrid(ByVal ctlName As String, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal row As DataGridViewRow) Handles pvtReceiveComboBoxGridMgr.UclOpenWindowComboBoxGridValue
        If ctlName = "1" Then
            uclDgv.Rows(rowIndex).Cells(colIndex).Value = row.Cells(1).Value
            If uclDgv.MultiSelect And uclDgv.uclColumnCheckBox Then
                uclDgv.GetGridDS.Tables(0).Rows(rowIndex).Item(colIndex - 1) = row.Cells(2).Value
                uclDgv.GetDBDS.Tables(0).Rows(rowIndex).Item(colIndex - 1) = row.Cells(1).Value


                uclDgv.GetGridDS.Tables(0).Rows(rowIndex).Item(1) = row.Cells(2).Value
                uclDgv.GetDBDS.Tables(0).Rows(rowIndex).Item(1) = row.Cells(2).Value



            Else
                uclDgv.GetGridDS.Tables(0).Rows(rowIndex).Item(colIndex) = row.Cells(2).Value
                uclDgv.GetDBDS.Tables(0).Rows(rowIndex).Item(colIndex) = row.Cells(1).Value


                uclDgv.GetGridDS.Tables(0).Rows(rowIndex).Item(1) = row.Cells(2).Value
                uclDgv.GetDBDS.Tables(0).Rows(rowIndex).Item(1) = row.Cells(2).Value


            End If
           
        End If
    End Sub




    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' UclTextCodeQueryUI1.Txt_CodeValue_TextChanged()

        'UclIdentityUI1.Initial()
        ' UclComboBoxGridUI1.Initial(UclDataGridViewUI1)
        ' UclDataGridViewUI1.addPartnerCbo(UclComboBoxGridUI1)
        'UclComboBoxGridUI2.uclNonVisibleColIndex = "0,1,2,3,4,9,10,11,12"

        'UclComboBoxGridUI2.uclDisplayIndex = "7"
        'UclComboBoxGridUI2.uclValueIndex = "5"


        'Me.AddOwnedForm(UclComboBoxGridUI2.GetGridForm())
        Dim columnNameDB() As String = {"Main_Id_Code", "Main_Id_Name", "CheckBox_Id_Name", "Sub_Id_Code", "Sub_Id_Name", "Button", "CheckBox", "Name"}
        mainDS = genDataSet(mainDS, "mainID", columnNameDB)
        Dim row1 As DataRow '= mainDS.Tables(0).Rows.Add()

        mainDS.Tables(0).Columns(4).DataType = System.Type.GetType("System.DateTime")

        'row("Main_Id_Code") = ""
        'row("Main_Id_Name") = ""

        row1 = mainDS.Tables(0).Rows.Add()
        row1("Main_Id_Code") = "01"
        row1("Main_Id_Name") = "02"
        row1("CheckBox_Id_Name") = "N"
        row1("Sub_Id_Code") = "001"
        row1("Sub_Id_Name") = "2009/05/05"
        row1("Button") = "Button1"
        row1("CheckBox") = "Y"
        row1("Name") = "藥品1"


        row1 = mainDS.Tables(0).Rows.Add()
        row1("Main_Id_Code") = "02"
        row1("Main_Id_Name") = "1234"
        row1("CheckBox_Id_Name") = "Y"
        row1("Sub_Id_Code") = "002"
        row1("Sub_Id_Name") = "2009/06/06"
        row1("Button") = "Button2"
        row1("CheckBox") = "N"
        row1("Name") = "藥品2"

        row1 = mainDS.Tables(0).Rows.Add()
        row1("Main_Id_Code") = "03"
        row1("Main_Id_Name") = "12345"
        row1("CheckBox_Id_Name") = "Y"
        row1("Sub_Id_Code") = "003"
        row1("Sub_Id_Name") = "2009/07/07"
        row1("Button") = "Button3"
        row1("CheckBox") = "Y"
        row1("Name") = "藥品3"

        Dim columnNameDB1() As String = {"Main_Id_Code", "Main_Id_Name"}
        cbo1DS = genDataSet(cbo1DS, "cbo1DS", columnNameDB1)
        Dim row As DataRow '= mainDS.Tables(0).Rows.Add()

        'row("Main_Id_Code") = ""
        'row("Main_Id_Name") = ""

        row = cbo1DS.Tables(0).Rows.Add()
        row("Main_Id_Code") = "01"
        row("Main_Id_Name") = "身份1健保"

        row = cbo1DS.Tables(0).Rows.Add()
        row("Main_Id_Code") = "02"
        row("Main_Id_Name") = "身份1自費"


        row = cbo1DS.Tables(0).Rows.Add()
        row("Main_Id_Code") = "03"
        row("Main_Id_Name") = "身份1其他"



        Dim columnNameDB2() As String = {"Main_Id_Code", "Main_Id_Name"}
        cbo2DS = genDataSet(cbo2DS, "cbo1DS", columnNameDB2)
        Dim row2 As DataRow '= mainDS.Tables(0).Rows.Add()

        'row("Main_Id_Code") = ""
        'row("Main_Id_Name") = ""

        row2 = cbo2DS.Tables(0).Rows.Add()
        row2("Main_Id_Code") = "001"
        row2("Main_Id_Name") = "身份2健保"

        row2 = cbo2DS.Tables(0).Rows.Add()
        row2("Main_Id_Code") = "002"
        row2("Main_Id_Name") = "身份2自費"


        row2 = cbo2DS.Tables(0).Rows.Add()
        row2("Main_Id_Code") = "003"
        row2("Main_Id_Name") = "身份2其他"



        ' uclDgv.Initial(mainDS)

        Dim cbo_cell1 As New ComboBoxCell()
        Dim cbo_cell2 As New ComboBoxCell()
        cbo_cell1.Ds = cbo1DS
        cbo_cell2.Ds = cbo2DS

        Dim txt_cell1 As New TextBoxCell()

        txt_cell1.uclTextType = TextBoxCell.uclTextTypeData.Any_Type

        Dim txt_cell2 As New TextBoxCell()

        txt_cell2.uclTextType = TextBoxCell.uclTextTypeData.Time_Hour24AndMinute

        Dim dtp_cell1 As New DtpCell()


        Dim btn_cell1 As New ButtonCell()

        btn_cell1.Text = "Button1"

        Dim btn_cell2 As New ButtonCell()

        btn_cell2.Text = "Button2"

        Dim chk_cell1 As New CheckBoxCell()
        Dim chk_cell2 As New CheckBoxCell()

        Dim cboGrid_cell1 As New ComboBoxGridCell()
        '  cboGrid_cell

        cboGrid_cell1.DisplayIndex = "1"
        cboGrid_cell1.ValueIndex = "1"
        ' cboGrid_cell1.NonVisibleColIndex = "0,1,2,3,4,5,9,10,11,12"
        cboGrid_cell1.GridWidth = 200
        cboGrid_cell1.GridHeight = 400
        cboGrid_cell1.ConnDBType = ComboBoxGridCell.DBType.RemoteSqlServer
        cboGrid_cell1.QueryData = ComboBoxGridCell.Data.PUB_Disease_IcdCode
        cboGrid_cell1.QueryType = ComboBoxGridCell.By.Code
        cboGrid_cell1.CtlName = "1"

        hashTable.Add(-1, mainDS.Copy)
        hashTable.Add(1, cbo_cell1)
        hashTable.Add(2, txt_cell1)

        ' hashTable.Add(1, cbo_cell1)
        hashTable.Add(3, chk_cell1)

        ' hashTable.Add(3, btn_cell1)
        hashTable.Add(5, dtp_cell1)
        hashTable.Add(6, btn_cell2)
        hashTable.Add(7, chk_cell1)
        hashTable.Add(8, cboGrid_cell1)

        uclDgv.Initial(hashTable)

        ' uclDgv.uclHeaderText = "11,22"
        DataGridView1.DataSource = uclDgv.GetGridDS().Tables(0)
        DataGridView2.DataSource = uclDgv.GetDBDS.Tables(0)

        uclDgv.uclBatchColIndex = "3"
        UclGridRowUpDownUI1.Initial(uclDgv)
    End Sub

    Function genDataSet(ByVal saveData As DataSet, ByVal tableName As String, ByVal columnNameDB As Array) As DataSet

        saveData.Tables.Add(tableName)

        '新增Table的欄位
        For i As Integer = 0 To columnNameDB.Length - 1
            saveData.Tables(saveData.Tables.Count - 1).Columns.Add(columnNameDB(i))
        Next
        Return saveData
    End Function



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MessageBox.Show(uclDgv.Rows(1).Cells(1).Value.ToString())
    End Sub


    Dim cbo As New ComboBox()

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
        'cbo.Visible = False
        'cbo.DataSource = mainDS.Tables(0)
        'Try
        '    If DataGridView1.CurrentCell.ColumnIndex = 1 Then

        '        Dim rect As Rectangle = DataGridView1.GetCellDisplayRectangle(DataGridView1.CurrentCell.ColumnIndex, DataGridView1.CurrentCell.RowIndex, False)
        '        Dim sexValue As String = DataGridView1.CurrentCell.Value.ToString()
        '        cbo.Left = rect.Left
        '        cbo.Top = rect.Top
        '        cbo.Width = rect.Width
        '        cbo.Height = rect.Height
        '        cbo.Visible = True

        '    End If


        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim columnNameDB2() As String = {"Main_Id_Code", "Main_Id_Name"}
        mainDS1 = genDataSet(mainDS1, "mainID1", columnNameDB2)
        Dim row As DataRow '= mainDS.Tables(0).Rows.Add()

        'row("Main_Id_Code") = ""
        'row("Main_Id_Name") = ""

        row = mainDS1.Tables(0).Rows.Add()
        row("Main_Id_Code") = "001"
        row("Main_Id_Name") = "健保"

        row = mainDS1.Tables(0).Rows.Add()
        row("Main_Id_Code") = "002"
        row("Main_Id_Name") = "自費"


        row = mainDS1.Tables(0).Rows.Add()
        row("Main_Id_Code") = "003"
        row("Main_Id_Name") = "其它"

        'UclComboBoxUI1.DataSource = mainDS1.Tables(0)
        'UclComboBoxUI1.uclDisplayIndex = "0,1"
        'UclComboBoxUI1.uclValueIndex = "0"


        ' DataGridView1.short()
    End Sub



    Private Sub DataGridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        '    MessageBox.Show("aaa")
    End Sub

    Private Sub uclDgv_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles uclDgv.CellValueChanged
        ' MessageBox.Show("cell value changed form")
    End Sub



    Private Sub DataGridView1_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellLeave

    End Sub

    Private Sub uclDgv_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles uclDgv.CellLeave
        'MessageBox.Show(uclDgv.Rows(0).Cells(0).Value.ToString())
    End Sub

    Private Sub uclDgv_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles uclDgv.KeyUp
        Select Case e.KeyCode
            Case Windows.Forms.Keys.Enter
                Console.WriteLine("dgv keyUp form1" + " enter")
        End Select

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'MessageBox.Show(uclDgv.CurrentCell.RowIndex.ToString() + "  Row , " + uclDgv.CurrentCell.ColumnIndex.ToString() + " Col")
        'UclComboBoxUI1.Width = 100

        DataGridView2.Rows(0).Cells(0).Value = "aa"
    End Sub


    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub uclDgv_ColumnWidthChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles uclDgv.ColumnWidthChanged

    End Sub
 


    Private Sub UclTextCodeQueryUI1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine("aaaaaaaaa")
    End Sub


    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        'uclDgv.SetDS(mainDS.Copy)
        uclDgv.Rows(0).Cells(0).Value = True
        'Console.WriteLine(uclDgv.CurrentCell.RowIndex.ToString() + " row ," + uclDgv.CurrentCell.ColumnIndex.ToString())
        'Console.WriteLine(uclDgv.CurrentCell.Value.ToString() + " value")
        'Console.WriteLine(uclDgv.GetDBDS().Tables(0).Rows(0).Item(2) + " string")
        'Console.WriteLine(uclDgv.GetDBDS().Tables(0).Rows(1).Item(2) + " string")
        'Console.WriteLine(uclDgv.GetDBDS().Tables(0).Rows(2).Item(2) + " string")
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        uclDgv.AddNewRow()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        UclIdentityUI1.SetSubIdValue("01")
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Console.WriteLine(UclIdentityUI1.GetCon1Value.ToString() + "  " + UclIdentityUI1.GetCon2Value.ToString())
        Console.WriteLine(UclIdentityUI1.GetMainIdValue.Trim() + " mainvalue")
        Console.WriteLine(UclIdentityUI1.GetDisIdValue.Trim() + " disvalue")
    End Sub

    Private Sub UclTextCodeQueryUI1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode

            Case Windows.Forms.Keys.Enter
                Console.WriteLine("aaaaaaaaaa")



        End Select
    End Sub

    Private Sub uclDgv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub uclDgv_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uclDgv.CurrentCellDirtyStateChanged


        If uclDgv.CurrentCell.ColumnIndex = 2 Then
            Console.WriteLine("aaaa")


        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '  Console .WriteLine (uclDgv.SetDS 
    End Sub

    Dim a As New UCLWaitingFormUI("aaaaaaaa")
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        a.Show()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        a.FinishJob()

    End Sub

    Private Sub uclDgv_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles uclDgv.ColumnHeaderMouseClick

        If e.ColumnIndex = 3 Then '


            For i As Integer = 0 To uclDgv.GetSelectedIndex.Count - 1


                uclDgv.Rows(CInt(uclDgv.GetSelectedIndex(i))).Cells(3).Value = True
                SendKeys.Send("{TAB}")
                uclDgv.CurrentCell = uclDgv.Rows(CInt(uclDgv.GetSelectedIndex(i))).Cells(3)
                uclDgv.UpdateCellValue(3, i)
                uclDgv.GetGridDS.Tables(0).Rows(CInt(uclDgv.GetSelectedIndex(i))).Item(2) = "Y"
                uclDgv.GetDBDS.Tables(0).Rows(CInt(uclDgv.GetSelectedIndex(i))).Item(2) = "Y"

            Next
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        uclDgv.RemoveRowAt(0)
    End Sub
End Class