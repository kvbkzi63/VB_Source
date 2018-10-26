Imports System
Imports System.Linq
Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports System.Text
Imports Syscom.Client.UCL

Public Class PUBRisFormMaintainSheetDetailUI


#Region "DataTable"

    'Private m_HeaderText As String = "表單代碼,醫令代碼,名稱,拆單註記,互斥之拆單醫令," & _
    '                                 "IsIndication,IsPrintOrderNote,OrderNote,OrderEntryNote,排序"
    'Private m_HeaderColumnWidth As String = "100,100,170,200,250," & _
    '                                        "200,200,200,200,100"
    'Private m_HeaderVisibleIndexOrderList As String = "2,3,10"
    Private m_HeaderVisibleIndex As String = "2,3"

    Private m_HeaderText As String = "表單代碼,醫令代碼,名稱"
    Private m_HeaderColumnWidth As String = "100,100,300"
    Private m_HeaderVisibleIndexOrderList As String = "2,3"

    Private Function OrderListDataTableGenerator() As DataTable
        Dim _dt As New DataTable
        _dt.TableName = "Order_List"

        _dt.Columns.Add("Sheet_Code", GetType(String))
        _dt.Columns.Add("Order_Code", GetType(String))
        _dt.Columns.Add("Order_Name", GetType(String))
        '_dt.Columns.Add("Separate_Mark", GetType(Int32))
        '_dt.Columns.Add("Exclusive_Order_Code", GetType(String))
        '_dt.Columns.Add("Is_Print_Indication", GetType(String))
        '_dt.Columns.Add("Is_Print_Order_Note", GetType(String))
        '_dt.Columns.Add("Order_Note", GetType(String))
        '_dt.Columns.Add("Order_Entry_Note", GetType(String))
        '_dt.Columns.Add("Sort_Value", GetType(Int32))

        Return _dt
    End Function

    Private Function TransformToOrderListHash(ByVal InputDt As DataTable) As Hashtable
        Dim _ds As New DataSet
        _ds.Tables.Add(InputDt.Copy)

        '隨輸隨選cell (Order_En_Name)
        Dim _examineCell As New ComboBoxGridCell
        _examineCell.CtlName = "ExamineSheetDetailOrderCell"
        _examineCell.DisplayIndex = "1,2"
        '_examineCell.NonVisibleColIndex = "2"
        _examineCell.ValueIndex = "0"

        _examineCell.GridWidth = 550
        _examineCell.GridHeight = 300
        _examineCell.ConnDBType = ComboBoxGridCell.DBType.RemoteSqlServer
        _examineCell.QueryData = ComboBoxGridCell.Data.PUB_Order
        _examineCell.QueryType = ComboBoxGridCell.By.Name
        _examineCell.MultiOrderTypeId = "'H'"
        '_examineCell.OrderTypeId = ComboBoxGridCell.OrderTypeIdData.H
        _examineCell.HeaderText = "X,代碼,英文,中文"
        _examineCell.ColumnWidth = "1,120,200,200"
        _examineCell.VisibleColIndex = "1,2,3"
        '====================
        '隨輸隨選cell (Order_Code)
        Dim _examineCellCode As New ComboBoxGridCell
        _examineCellCode.CtlName = "ExamineSheetDetailOrderCodeCell"
        _examineCellCode.DisplayIndex = "1,2"
        '_examineCellCode.NonVisibleColIndex = "2"
        _examineCellCode.ValueIndex = "1"

        _examineCellCode.GridWidth = 550
        _examineCellCode.GridHeight = 300
        _examineCellCode.ConnDBType = ComboBoxGridCell.DBType.RemoteSqlServer
        _examineCellCode.QueryData = ComboBoxGridCell.Data.PUB_Order
        _examineCellCode.QueryType = ComboBoxGridCell.By.Code
        _examineCellCode.MultiOrderTypeId = "'H'"
        '_examineCellCode.OrderTypeId = ComboBoxGridCell.OrderTypeIdData.H
        _examineCellCode.HeaderText = "X,代碼,英文,中文"
        _examineCellCode.ColumnWidth = "1,120,200,200"
        _examineCellCode.VisibleColIndex = "1,2,3"
        '====================


        Dim _hashTable As New Hashtable
        _hashTable.Add(-1, _ds)
        '0 刪
        '1 Sheet_Code
        _hashTable.Add(2, _examineCellCode)
        _hashTable.Add(3, _examineCell)
        '4 Separate_Mark
        '5 Exclusive_Order_Code
        '6 Is_Print_Indication
        '7 Is_Print_Order_Note
        '8 Order_Note
        '9 Order_Entry_Note

        Return _hashTable
    End Function

    Private Function UpdateDetailDcDataTableGenerator() As DataTable
        Dim _dt As New DataTable
        _dt.TableName = "UpdatePubSheetDetailDc"
        _dt.Columns.Add("Sheet_Code", GetType(String))
        _dt.Columns.Add("Order_Code", GetType(String))
        _dt.Columns.Add("Sort_Value", GetType(String))
        _dt.Columns.Add("Dc", GetType(String))
        Return _dt
    End Function
#End Region

#Region "Property"

    Private WithEvents pvtReceiveComboBoxGridMgrNormal As EventManager = EventManager.getInstance

    'Private m_currentUser As String = "940114" 'A500
    'Private m_currentUser As String = "614129" '8200
    Private m_currentUser As String = AppContext.userProfile.userId
    Private ReadOnly Property CurrentUser() As String
        Get
            If m_currentUser Is Nothing Then m_currentUser = String.Empty
            Return m_currentUser
        End Get
    End Property

    ''' <summary>
    ''' 所選擇表單之表單代碼
    ''' </summary>
    ''' <value>表單代碼</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property SelectedSheetCode() As String
        Get
            Return cbo_SheetList.SelectedValue
        End Get
    End Property

#End Region

#Region "Event"

    Private Sub PUBRisFormMaintainSheetDetailUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.MyInitialization()
    End Sub

    ''' <summary>
    ''' 由隨輸隨選元件取得檢驗檢查之Order
    ''' </summary>
    ''' <param name="ctlName"></param>
    ''' <param name="rowIndex"></param>
    ''' <param name="colIndex"></param>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Sub receiveComboBoxGrid(ByVal ctlName As String, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal row As System.Windows.Forms.DataGridViewRow) Handles pvtReceiveComboBoxGridMgrNormal.UclOpenWindowComboBoxGridValue

        Dim _selectedDataGridView As UCLDataGridViewUC = Nothing

        '取得當前頁面
        _selectedDataGridView = dgv_OrderList

        '若datagridview為空
        If _selectedDataGridView Is Nothing OrElse _selectedDataGridView.Rows.Count = 0 Then
            Exit Sub
        End If

        Select Case ctlName
            Case "ExamineSheetDetailOrderCell", "ExamineSheetDetailOrderCodeCell"

                Dim _sheetCode As String = Me.cbo_SheetList.SelectedValue
                Dim _orderEnName As String = row.Cells("Order_En_Name").Value.ToString.TrimEnd
                Dim _orderCode As String = row.Cells("Order_Code").Value.ToString.TrimEnd
                'Dim _treatmentTypeId As String = row.Cells("Treatment_Type_Id").Value.ToString.TrimEnd
                Dim _separateMark As Int32 = 0
                Dim _exclusiveOrderCode As String = String.Empty
                Dim _isPrintIndication As String = "N"
                Dim _isPrintOrderNote As String = "N"
                Dim _orderNote As String = String.Empty
                Dim _SortValue As String = String.Empty

                '先判斷此Order在資料庫中是否有Dc = 'Y' 的資料
                '若有則將Dc改為'N'並Refresh畫面
                '若無則將此order加入資料庫中

                Dim _pubService As PubServiceManager = PubServiceManager.getInstance

                Dim chk_res As DataSet = queryPubSheetDetailByOrderCode(_orderCode)
                If chk_res.Tables(0).Rows.Count > 0 Then
                    cbo_SheetList.SelectedValue = chk_res.Tables(0).Rows(0).Item("Sheet_Code").ToString.Trim
                    Dim msg As String = "此醫令" & _orderCode & "已存在" & chk_res.Tables(0).Rows(0).Item("Sheet_Code").ToString.Trim & "表單, 若要更換表單請先於原表單執行刪除, 才可再新增"
                    MessageHandling.ShowErrorMsg("CMMCMMB300", msg, "")
                    Return
                End If

                Dim _dt As DataTable = Nothing
                Try
                    _dt = _pubService.PUBExaminationSheetDetailMaintainQuerySheetDetail(_sheetCode, _orderCode).Tables("PUB_Sheet_Detail")
                Catch ex As Exception
                    Throw ex
                    Return
                End Try
                If _dt Is Nothing Then Return

                If _dt.Rows.Count = 0 Then
                    '=================資料庫中無資料, 新增一筆資料至資料庫=================================

                    Dim _dsPubSheetDetail As New DataSet
                    Dim _dtPubSheetDetail As DataTable = PubSheetDetailDataTableFactory.getDataTableWithSchema
                    Dim _drPubSheetDetail As DataRow = _dtPubSheetDetail.NewRow
                    _drPubSheetDetail("Sheet_Code") = _sheetCode
                    _drPubSheetDetail("Order_Code") = _orderCode
                    _drPubSheetDetail("Is_Indication") = "N"
                    _drPubSheetDetail("Is_Print_Indication") = _isPrintIndication
                    _drPubSheetDetail("Order_Note") = _orderNote
                    _drPubSheetDetail("Is_Print_Order_Note") = _isPrintOrderNote
                    _drPubSheetDetail("Separate_Mark") = _separateMark
                    _drPubSheetDetail("Exclusive_Order_Code") = _exclusiveOrderCode
                    _drPubSheetDetail("Sheet_Detail_Sort_Value") = DBNull.Value
                    _drPubSheetDetail("Dc") = "N"
                    _drPubSheetDetail("Create_User") = m_currentUser
                    _drPubSheetDetail("Create_Time") = Now
                    _dtPubSheetDetail.Rows.Add(_drPubSheetDetail)
                    _dsPubSheetDetail.Tables.Add(_dtPubSheetDetail)

                    Dim _cnt As Int32 = 0
                    Try
                        _cnt = _pubService.InsertIntoPubSheetDetailAndPubOrderExamination(_dsPubSheetDetail, Me.CurrentUser)
                    Catch ex As Exception
                        Throw ex
                        Return
                    End Try

                    '=================新增完成後，將值填入DataGrid中=================================
                    '填入Sheet_Code
                    Dim _dtDb As DataTable = dgv_OrderList.GetDBDS.Tables(0)
                    Dim _dtGrid As DataTable = dgv_OrderList.GetGridDS.Tables(0)
                    dgv_OrderList.Rows(rowIndex).Cells("Sheet_Code").Value = _sheetCode
                    _dtDb.Rows(rowIndex).Item("Sheet_Code") = _sheetCode
                    _dtGrid.Rows(rowIndex).Item("Sheet_Code") = _sheetCode

                    '填入Order_Code
                    dgv_OrderList.Rows(rowIndex).Cells("Order_Code").Value = _orderCode
                    _dtDb.Rows(rowIndex).Item("Order_Code") = _orderCode
                    _dtGrid.Rows(rowIndex).Item("Order_Code") = _orderCode

                    '填入Order_En_Name
                    dgv_OrderList.Rows(rowIndex).Cells("Order_Name").Value = _orderEnName
                    _dtDb.Rows(rowIndex).Item("Order_Name") = _orderEnName
                    _dtGrid.Rows(rowIndex).Item("Order_Name") = _orderEnName

                    'dgv_OrderList.Rows(rowIndex).Cells("Separate_Mark").Value = _separateMark
                    '_dtDb.Rows(rowIndex).Item("Separate_Mark") = _separateMark
                    '_dtGrid.Rows(rowIndex).Item("Separate_Mark") = _separateMark

                    'dgv_OrderList.Rows(rowIndex).Cells("Exclusive_Order_Code").Value = _exclusiveOrderCode
                    '_dtDb.Rows(rowIndex).Item("Exclusive_Order_Code") = _exclusiveOrderCode
                    '_dtGrid.Rows(rowIndex).Item("Exclusive_Order_Code") = _exclusiveOrderCode

                    'dgv_OrderList.Rows(rowIndex).Cells("Is_Print_Indication").Value = _isPrintIndication
                    '_dtDb.Rows(rowIndex).Item("Is_Print_Indication") = _isPrintIndication
                    '_dtGrid.Rows(rowIndex).Item("Is_Print_Indication") = _isPrintIndication

                    'dgv_OrderList.Rows(rowIndex).Cells("Is_Print_Order_Note").Value = _isPrintOrderNote
                    '_dtDb.Rows(rowIndex).Item("Is_Print_Order_Note") = _isPrintOrderNote
                    '_dtGrid.Rows(rowIndex).Item("Is_Print_Order_Note") = _isPrintOrderNote

                    'dgv_OrderList.Rows(rowIndex).Cells("Order_Note").Value = _orderNote
                    '_dtDb.Rows(rowIndex).Item("Order_Note") = _orderNote
                    '_dtGrid.Rows(rowIndex).Item("Order_Note") = _orderNote

                    ''取出 Sort_Value
                    'Dim _dtForSortValue As DataTable = Nothing
                    'Try
                    '    _dtForSortValue = GetOrderListFromDb(_sheetCode)
                    'Catch ex As Exception
                    '    nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
                    'End Try

                    'Dim _dtForSortValueE = _dtForSortValue.AsEnumerable
                    'Dim _sortValueStr As String = _dtForSortValueE.Where(Function(r) r("Sheet_Code").ToString.TrimEnd = _sheetCode AndAlso r("Order_Code").ToString.TrimEnd = _orderCode).Select(Function(r) r("Sort_Value").ToString).FirstOrDefault()

                    'If Not String.IsNullOrEmpty(_sortValueStr) Then
                    '    dgv_OrderList.Rows(rowIndex).Cells("Sort_Value").Value = CInt(_sortValueStr)
                    '    _dtDb.Rows(rowIndex).Item("Sort_Value") = CInt(_sortValueStr)
                    '    _dtGrid.Rows(rowIndex).Item("Sort_Value") = CInt(_sortValueStr)
                    'End If
                    '==================================================

                    dgv_OrderList.CurrentCell = Nothing

                    '鎖住此Row
                    dgv_OrderList.SetRowReadOnly(rowIndex, True)

                    '新增一空白行
                    Me.DgvOrderListAddNewRow()
                Else
                    '資料庫中有資料
                    Dim _dr As DataRow = _dt.Rows(0)
                    Dim _dc As String = _dr("Dc").ToString

                    Dim _cnt As Int32 = 0
                    If _dc = "Y" Then
                        '若Dc = 'Y' 則將Dc更新成 'N'
                        Try
                            Dim _dsNew As New DataSet
                            Dim _dtNew As DataTable = Me.UpdateDetailDcDataTableGenerator
                            Dim _drNew As DataRow = _dtNew.NewRow
                            _drNew("Sheet_Code") = _sheetCode
                            _drNew("Order_Code") = _orderCode
                            _drNew("Dc") = "N"
                            _dtNew.Rows.Add(_drNew)
                            _dsNew.Tables.Add(_dtNew)

                            Dim _dtTreatmentTypeId As New DataTable
                            _dtTreatmentTypeId.TableName = "Treatment_Type_Id"
                            _dtTreatmentTypeId.Columns.Add("Treatment_Type_Id", GetType(String))
                            Dim _drTreatmentTypeId As DataRow = _dtTreatmentTypeId.NewRow
                            _drTreatmentTypeId("Treatment_Type_Id") = "4"
                            _dtTreatmentTypeId.Rows.Add(_drTreatmentTypeId)
                            _dsNew.Tables.Add(_dtTreatmentTypeId)

                            _cnt = _pubService.PUBExaminationSheetDetailMaintainUpdateDcOfPubSheetDetail(_dsNew, Me.CurrentUser)
                        Catch ex As Exception
                            Throw ex
                            Return
                        End Try

                        '=================修改完成後，將值填入DataGrid中=================================
                        '填入Sheet_Code
                        Dim _dtDb As DataTable = dgv_OrderList.GetDBDS.Tables(0)
                        Dim _dtGrid As DataTable = dgv_OrderList.GetGridDS.Tables(0)
                        dgv_OrderList.Rows(rowIndex).Cells("Sheet_Code").Value = _dr("Sheet_Code")
                        _dtDb.Rows(rowIndex).Item("Sheet_Code") = _dr("Sheet_Code")
                        _dtGrid.Rows(rowIndex).Item("Sheet_Code") = _dr("Sheet_Code")

                        '填入Order_Code
                        dgv_OrderList.Rows(rowIndex).Cells("Order_Code").Value = _dr("Order_Code")
                        _dtDb.Rows(rowIndex).Item("Order_Code") = _dr("Order_Code")
                        _dtGrid.Rows(rowIndex).Item("Order_Code") = _dr("Order_Code")

                        '填入Order_En_Name
                        dgv_OrderList.Rows(rowIndex).Cells("Order_Name").Value = _dr("Order_Name")
                        _dtDb.Rows(rowIndex).Item("Order_Name") = _dr("Order_Name")
                        _dtGrid.Rows(rowIndex).Item("Order_Name") = _dr("Order_Name")

                        'dgv_OrderList.Rows(rowIndex).Cells("Separate_Mark").Value = _dr("Separate_Mark")
                        '_dtDb.Rows(rowIndex).Item("Separate_Mark") = _dr("Separate_Mark")
                        '_dtGrid.Rows(rowIndex).Item("Separate_Mark") = _dr("Separate_Mark")

                        'dgv_OrderList.Rows(rowIndex).Cells("Exclusive_Order_Code").Value = _dr("Exclusive_Order_Code")
                        '_dtDb.Rows(rowIndex).Item("Exclusive_Order_Code") = _dr("Exclusive_Order_Code")
                        '_dtGrid.Rows(rowIndex).Item("Exclusive_Order_Code") = _dr("Exclusive_Order_Code")

                        'dgv_OrderList.Rows(rowIndex).Cells("Is_Print_Indication").Value = _dr("Is_Print_Indication")
                        '_dtDb.Rows(rowIndex).Item("Is_Print_Indication") = _dr("Is_Print_Indication")
                        '_dtGrid.Rows(rowIndex).Item("Is_Print_Indication") = _dr("Is_Print_Indication")

                        'dgv_OrderList.Rows(rowIndex).Cells("Is_Print_Order_Note").Value = _dr("Is_Print_Order_Note")
                        '_dtDb.Rows(rowIndex).Item("Is_Print_Order_Note") = _dr("Is_Print_Order_Note")
                        '_dtGrid.Rows(rowIndex).Item("Is_Print_Order_Note") = _dr("Is_Print_Order_Note")

                        'dgv_OrderList.Rows(rowIndex).Cells("Order_Note").Value = _dr("Order_Note")
                        '_dtDb.Rows(rowIndex).Item("Order_Note") = _dr("Order_Note")
                        '_dtGrid.Rows(rowIndex).Item("Order_Note") = _dr("Order_Note")

                        ''取出 Sort_Value
                        'Dim _dtForSortValue As DataTable = Nothing
                        'Try
                        '    _dtForSortValue = GetOrderListFromDb(_sheetCode)
                        'Catch ex As Exception
                        '    nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
                        'End Try

                        'Dim _dtForSortValueE = _dtForSortValue.AsEnumerable
                        'Dim _sortValueStr As String = _dtForSortValueE.Where(Function(r) r("Sheet_Code").ToString.TrimEnd = _sheetCode AndAlso r("Order_Code").ToString.TrimEnd = _orderCode).Select(Function(r) r("Sort_Value").ToString).FirstOrDefault()

                        'If Not String.IsNullOrEmpty(_sortValueStr) Then
                        '    dgv_OrderList.Rows(rowIndex).Cells("Sort_Value").Value = CInt(_sortValueStr)
                        '    _dtDb.Rows(rowIndex).Item("Sort_Value") = CInt(_sortValueStr)
                        '    _dtGrid.Rows(rowIndex).Item("Sort_Value") = CInt(_sortValueStr)
                        'End If
                        '==================================================

                        dgv_OrderList.CurrentCell = Nothing

                        '鎖住此Row
                        dgv_OrderList.SetRowReadOnly(rowIndex, True)

                        '新增一空白行
                        Me.DgvOrderListAddNewRow()
                    Else
                        '若Dc = 'N' 則不允許動作
                    End If
                End If

            Case Else
                Return
        End Select
    End Sub

    Private Sub cbo_SheetList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_SheetList.SelectedIndexChanged

        Me.QueryOrderList()
    End Sub

    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click

        Me.DeleteOrder()
    End Sub

    Private Sub btn_OCQuery_Click(sender As Object, e As EventArgs) Handles btn_OCQuery.Click
        Dim res As DataSet = queryPubSheetDetailByOrderCode(txt_OrderCode.Text.Trim)
        If res.Tables(0).Rows.Count > 0 Then
            cbo_SheetList.SelectedValue = res.Tables(0).Rows(0).Item("Sheet_Code").ToString.Trim
        Else
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"此醫令不存在"}, "")
        End If
    End Sub
#End Region

#Region "Function"

    Private Sub MyInitialization()

        MessageHandling.clearInfoMsg()

        Me.SetOrderList(OrderListDataTableGenerator())

        Dim _service As PubServiceManager = PubServiceManager.getInstance

        Try
            Dim sheetTypeId As String = "2"
            Dim whereClause As String = "Sheet_Type_Id='" & sheetTypeId & "'"
            Dim orderByClause As String = "Dept_Code asc"
            Dim dtSheetCode As DataTable = _service.queryPUBSheet().Tables(0).Select(whereClause, orderByClause).CopyToDataTable
            cbo_SheetList.DataSource = dtSheetCode
            cbo_SheetList.uclDisplayIndex = "0,1"
            cbo_SheetList.uclValueIndex = "0"
        Catch ex As Exception
            Throw ex
            Exit Sub
        End Try

    End Sub

    Private Sub SetOrderList(ByVal InputDataTable As DataTable)

        dgv_OrderList.HideControlCell("All")

        dgv_OrderList.Initial(Me.TransformToOrderListHash(InputDataTable))
        dgv_OrderList.uclHeaderText = m_HeaderText
        dgv_OrderList.uclColumnWidth = m_HeaderColumnWidth
        dgv_OrderList.uclVisibleColIndex = m_HeaderVisibleIndexOrderList
        'dgv_OrderList.Columns("Sort_Value").ReadOnly = False

        '鎖住Orders
        For Each _dgvRow As DataGridViewRow In dgv_OrderList.Rows
            dgv_OrderList.SetCellReadOnly(2, _dgvRow.Index, True)
            dgv_OrderList.SetCellReadOnly(3, _dgvRow.Index, True)
            'dgv_OrderList.SetRowReadOnly(_dgvRow.Index, True)
        Next

        '若畫面上無資料列，則新增一資料列
        If dgv_OrderList.Rows.Count = 0 Then
            DgvOrderListAddNewRow()
        ElseIf dgv_OrderList.Rows(dgv_OrderList.Rows.Count - 1).Cells("Order_Name").Value.ToString.Trim <> "" Then
            DgvOrderListAddNewRow()
        End If
    End Sub

    ''' <summary>
    ''' 在GridView最後新增一空白行
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DgvOrderListAddNewRow()
        If dgv_OrderList.Rows.Count = 0 Then

            Me.DgvOrderListAddNewRow(0)
        Else
            Dim _dtDB As DataTable = dgv_OrderList.GetDBDS.Tables(0)

            '若最後一行不為空
            Dim _dr As DataRow = _dtDB.AsEnumerable.LastOrDefault
            If _dr Is Nothing OrElse (_dr("Order_Code").ToString.Trim <> String.Empty OrElse _dr("Order_Name").ToString.Trim <> String.Empty) Then

                Me.DgvOrderListAddNewRow(dgv_OrderList.Rows.Count)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 在指定位置新增一空白行
    ''' </summary>
    ''' <param name="RowIndex">position of target.</param>
    ''' <remarks></remarks>
    Private Sub DgvOrderListAddNewRow(ByVal RowIndex As Int32)
        dgv_OrderList.AddNewRowAt(RowIndex)

        'Order_Code欄位唯讀
        'dgv_OrderList.SetCellReadOnly(2, RowIndex, True) 'Order_Code

    End Sub

    ''' <summary>
    ''' 由Sheet_Code取得表單中所包含之Order.
    ''' </summary>
    ''' <param name="SheetCode">表單代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetOrderListFromDb(ByVal SheetCode As String) As DataTable
        Dim _service As PubServiceManager = PubServiceManager.getInstance

        Dim _dtOrderCodeList As DataTable = Nothing

        Try
            Dim _ds As DataSet = _service.PUBExaminationSheetDetailMaintainGetOrderList(Me.SelectedSheetCode)

            _dtOrderCodeList = _ds.Tables("Order_List")

        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try

        Return IIf(_dtOrderCodeList Is Nothing, Me.OrderListDataTableGenerator, _dtOrderCodeList)
    End Function

    ''' <summary>
    ''' 查詢表單中所包含的Order.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub QueryOrderList()

        Dim _service As PubServiceManager = PubServiceManager.getInstance

        Dim _dtOrderCodeList As DataTable = Nothing
        Dim _dtSheetLimitCnt As DataTable = Nothing

        Try
            Dim _ds As DataSet = _service.PUBExaminationSheetDetailMaintainGetOrderList(Me.SelectedSheetCode)

            _dtOrderCodeList = _ds.Tables("Order_List")
            _dtSheetLimitCnt = _ds.Tables("Sheet_Limit_Cnt")

        Catch ex As Exception
            Throw ex
            Return
        End Try

        'dgv_OrderList.DataSource = IIf(_dtOrderCodeList Is Nothing, Me.OrderListDataTableGenerator, _dtOrderCodeList)
        Me.SetOrderList(IIf(_dtOrderCodeList Is Nothing, Me.OrderListDataTableGenerator, _dtOrderCodeList))

    End Sub

    ''' <summary>
    ''' 刪除(Dc)所選擇的Order_Code
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteOrder()

        Dim _indexS = dgv_OrderList.SelectedIndex.Reverse().ToArray()

        If _indexS.Count = 0 Then Return

        Dim _result = MsgBox("是否確定移除表單醫令？", MsgBoxStyle.YesNo, "移除")
        If _result <> MsgBoxResult.Yes Then
            Return
        End If

        Dim _dtDb As DataTable = dgv_OrderList.GetDBDS.Tables(0)
        Dim _dtGrid As DataTable = dgv_OrderList.GetGridDS.Tables(0)

        Dim _dsNew As New DataSet
        Dim _dtNew As DataTable = Me.UpdateDetailDcDataTableGenerator
        For Each _index As Int32 In _indexS
            Dim _drNew As DataRow = _dtNew.NewRow
            Dim _SheetCode As String = _dtDb.Rows(_index)("Sheet_Code").ToString
            Dim _OrderCode As String = _dtDb.Rows(_index)("Order_Code").ToString
            'Dim _SortValue As Int32 = _dtDb.Rows(_index)("Sort_Value").ToString
            If _index = dgv_OrderList.Rows.Count OrElse _SheetCode = String.Empty OrElse _OrderCode = String.Empty Then
                '跳過空白行
                Continue For
            End If

            _drNew("Sheet_Code") = _SheetCode
            _drNew("Order_Code") = _OrderCode
            '_drNew("Sort_Value") = _SortValue
            _drNew("Dc") = "Y"
            _dtNew.Rows.Add(_drNew)
        Next
        _dsNew.Tables.Add(_dtNew)

        Dim _service As PubServiceManager = PubServiceManager.getInstance

        Dim _cnt As Int32 = 0
        Try
            _cnt += _service.PUBExaminationSheetDetailMaintainUpdateDcOfPubSheetDetail(_dsNew, Me.CurrentUser)
        Catch ex As Exception
            Throw ex
            Return
        End Try

        For Each _index As Int32 In _indexS

            If _index = dgv_OrderList.Rows.Count Then
                '跳過最後一行空白行
                Continue For
            End If

            _dtDb.Rows(_index).Delete()
            _dtGrid.Rows(_index).Delete()
        Next
        _dtDb.AcceptChanges()
        _dtGrid.AcceptChanges()

        '解除最後一行空白的唯讀
        dgv_OrderList.SetRowReadOnly(dgv_OrderList.Rows.Count - 1, False)
    End Sub

    ''' <summary>
    ''' 查詢醫令是否已存在(PUB_Sheet_Detail)
    ''' </summary>
    ''' <remarks></remarks>
    Private Function queryPubSheetDetailByOrderCode(ByVal OrderCode As String) As DataSet
        Dim _service As PubServiceManager = PubServiceManager.getInstance
        Try
            Dim _ds As DataSet = _service.queryPubSheetDetailByOrderCode(OrderCode)
            Return _ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class