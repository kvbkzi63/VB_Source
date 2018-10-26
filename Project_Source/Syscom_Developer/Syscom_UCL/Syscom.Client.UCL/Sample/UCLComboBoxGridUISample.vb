Imports Syscom.Client.cmm
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG

Imports Syscom.Client.ucl
Imports System.Windows.Forms
Imports Syscom.Client.servicefactory


Public Class UCLComboBoxGridUISample

    '加入必要的Event Handle
    Dim WithEvents pvtReceiveComboBoxGridMgr As EventManager = EventManager.getInstance
 
    '處理隨輸隨選選擇一筆資料時所觸發的Event
    Private Sub receiveComboBoxGrid(ByVal ctlName As String, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal row As DataGridViewRow) Handles pvtReceiveComboBoxGridMgr.UclOpenWindowComboBoxGridValue

        If Not dgv_DiagnosisFavor.IsComboBoxGridSetValue Then
            '此段請加上
            Exit Sub
        End If

        If ctlName = "cboGrid_cell1" Then

            '回寫資料到GridDS , DBDS 的Order_Code
            dgv_DiagnosisFavor.GetGridDS.Tables(0).Rows(rowIndex).Item(0) = row.Cells(1).Value.ToString.Trim
            dgv_DiagnosisFavor.GetDBDS.Tables(0).Rows(rowIndex).Item(0) = row.Cells(1).Value.ToString.Trim


            '回寫資料到GridDS , DBDS 的 Order_En_name
            dgv_DiagnosisFavor.GetGridDS.Tables(0).Rows(rowIndex).Item(1) = row.Cells(2).Value.ToString.Trim
            dgv_DiagnosisFavor.GetDBDS.Tables(0).Rows(rowIndex).Item(1) = row.Cells(2).Value.ToString.Trim

            'row的值是根據隨輸隨選 所選擇某一筆資料整個Row的值
            '以上適情況將row.Cell的值填入 GridView GridDS , DBDS 中

            dgv_DiagnosisFavor.CommitEdit(DataGridViewDataErrorContexts.Commit)

            If rowIndex = dgv_DiagnosisFavor.Rows.Count - 1 Then

                '適需要添加此行,會自動在最後一行新增一空白列,可讓使用者繼續輸入
                dgv_DiagnosisFavor.AddNewRow()
            End If

            dgv_DiagnosisFavor.Refresh()

        End If
    End Sub


    Private Sub UCLComboBoxGridUISample_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim ds As New DataSet

        Dim hashTable As New Hashtable

        ds.Tables.Add()
        ds.Tables(0).Columns.Add("Order_Code")
        ds.Tables(0).Columns.Add("Order_En_Name")

        Dim cboGrid_cell1 As New ComboBoxGridCell()


        '設定隨輸隨選所開起的GridView大小
        cboGrid_cell1.GridWidth = 400
        cboGrid_cell1.GridHeight = 300

        '從SQLServer查詢資料
        cboGrid_cell1.ConnDBType = ComboBoxGridCell.DBType.RemoteSqlServer

        '設定隨輸隨選要查詢哪一種Table  可參考 UCLComboBoxGridBO 會從DB中查詢的值
        cboGrid_cell1.QueryData = ComboBoxGridCell.Data.OPH_Pharmacy_Base_Normal

        '根據Order_Code 作隨輸隨選 
        cboGrid_cell1.QueryType = ComboBoxGridCell.By.Name
        ' cboGrid_cell1.ValueIndex = "0"
        cboGrid_cell1.OrderTypeId = ComboBoxGridCell.OrderTypeIdData.E
        '根據Order_En_Name 作隨輸隨選  (同時間只能選擇一種 By.Code  or By.Name)
        'cboGrid_cell1.QueryType = ComboBoxGridCell.By.Name
        cboGrid_cell1.ValueIndex = "0"
        cboGrid_cell1.EffectiveMode = True

        '設定隨輸隨選所開起的GridView 的欄位名稱
        'cboGrid_cell1.HeaderText = " 隱藏欄位0,名稱Order_Code,名稱Order_En_Name"

        '設定隨輸隨選所開起的GridView 要隱藏哪些欄位
        ' cboGrid_cell1.NonVisibleColIndex = "0,3,4,5,6,7,8,10,11,12,13,14"
        'cboGrid_cell1.VisibleColIndex = "1,2"

        '隨輸隨選元件名稱   配合 receiveComboBoxGrid Event的 CtlName
        cboGrid_cell1.CtlName = "cboGrid_cell1"

        'hashTable.Add(-1, ds)
        'hashTable.Add(1, cboGrid_cell1)

        'dgv_DiagnosisFavor.Initial(hashTable)
        'dgv_DiagnosisFavor.uclHeaderText = "Order_Code,Order_En_Name"
        'dgv_DiagnosisFavor.uclColumnWidth = "100, 300"





        Dim cboLeftHospDiagGrid_cell1 As New ComboBoxGridCell()
        cboLeftHospDiagGrid_cell1.DisplayIndex = "1,2,3"
        cboLeftHospDiagGrid_cell1.ValueIndex = "1"
        cboLeftHospDiagGrid_cell1.VisibleColIndex = "1,2,3"
        cboLeftHospDiagGrid_cell1.GridHeight = 300
        cboLeftHospDiagGrid_cell1.ConnDBType = ComboBoxGridCell.DBType.RemoteSqlServer
        cboLeftHospDiagGrid_cell1.QueryData = ComboBoxGridCell.Data.PUB_Disease_IcdCode
        cboLeftHospDiagGrid_cell1.QueryType = ComboBoxGridCell.By.Code
        cboLeftHospDiagGrid_cell1.DiseaseTypeId = ComboBoxGridCell.DiseaseTypeIdData.OutHospital
        cboLeftHospDiagGrid_cell1.IcdType = ComboBoxGridCell.IcdTypeData.Icd10
        cboLeftHospDiagGrid_cell1.HeaderText = " ,診斷碼,診斷名稱(En),診斷名稱(Zh)"
        'Dim cboLeftHospDiagGrid_cell1 As New ComboBox20GridCell()

        ''設定隨輸隨選所開起的GridView大小
        cboLeftHospDiagGrid_cell1.GridWidth = 420
        cboLeftHospDiagGrid_cell1.GridHeight = 300



        hashTable.Add(-1, ds)
        hashTable.Add(1, cboLeftHospDiagGrid_cell1)

        dgv_DiagnosisFavor.Initial(hashTable)
        cboLeftHospDiagGrid_cell1.HeaderText = " ,診斷碼,診斷名稱(En),診斷名稱(Zh)"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim screenWidth = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight = Screen.PrimaryScreen.Bounds.Height
        MessageBox.Show("螢幕解析度為 " + screenWidth.ToString() + "*" + screenHeight.ToString())


    End Sub
End Class