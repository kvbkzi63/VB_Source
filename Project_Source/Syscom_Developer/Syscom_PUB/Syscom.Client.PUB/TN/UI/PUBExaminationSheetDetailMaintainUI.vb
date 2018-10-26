
Imports System
Imports System.Linq
Imports System.Text

Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.UCL
Imports Syscom.Comm.LOG
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports log4net



''' <summary>
''' 檢驗表單維護
''' </summary>
''' <remarks>UCF-290-031</remarks>
Public Class PUBExaminationSheetDetailMaintainUI

#Region "DataTable"

    Private m_HeaderText As String = "表單代碼,醫令代碼,名稱,拆單註記,互斥之拆單醫令," & _
                                     "IsIndication,IsPrintOrderNote,IsSeeReport,IsLimitHealth,OrderNote,OrderEntryNote,排序"
    Private m_HeaderColumnWidth As String = "100,100,170,200,250," & _
                                            "200,200,200,200,100,100,100"
    Private m_HeaderVisibleIndexOrderList As String = "2,3,12"
    Private m_HeaderVisibleIndex As String = "2,3"

    Private Function OrderListDataTableGenerator() As DataTable
        Dim _dt As New DataTable
        _dt.TableName = "Order_List"

        _dt.Columns.Add("Sheet_Code", GetType(String))
        _dt.Columns.Add("Order_Code", GetType(String))
        _dt.Columns.Add("Order_Name", GetType(String))
        _dt.Columns.Add("Separate_Mark", GetType(Int32))
        _dt.Columns.Add("Exclusive_Order_Code", GetType(String))
        _dt.Columns.Add("Is_Print_Indication", GetType(String))
        _dt.Columns.Add("Is_Print_Order_Note", GetType(String))
        _dt.Columns.Add("Is_InstantlyRpt", GetType(String))
        _dt.Columns.Add("Is_Limit_Health", GetType(String))
        _dt.Columns.Add("Order_Note", GetType(String))
        _dt.Columns.Add("Order_Entry_Note", GetType(String))
        _dt.Columns.Add("Sort_Value", GetType(Int32))

        Return _dt
    End Function

    Private Function TransformToOrderListHash(ByVal InputDt As DataTable) As Hashtable
        Dim _ds As New DataSet
        _ds.Tables.Add(InputDt.Copy)

        '隨輸隨選cell (Order_En_Name)
        Dim _examineCell As New ComboBoxGridCell
        _examineCell.CtlName = "ExamineOrderCell"
        _examineCell.DisplayIndex = "0,1"
        '_examineCell.NonVisibleColIndex = "2"
        _examineCell.ValueIndex = "0"

        _examineCell.GridWidth = 410
        _examineCell.GridHeight = 300
        _examineCell.ConnDBType = ComboBoxGridCell.DBType.RemoteSqlServer
        _examineCell.QueryData = ComboBoxGridCell.Data.PUB_Order_Examine
        _examineCell.QueryType = ComboBoxGridCell.By.Name
        _examineCell.HeaderText = "醫令名稱,醫令代碼"
        _examineCell.ColumnWidth = "250,150"
        _examineCell.VisibleColIndex = "0,1"
        '====================
        '隨輸隨選cell (Order_Code)
        Dim _examineCellCode As New ComboBoxGridCell
        _examineCellCode.CtlName = "ExamineOrderCodeCell"
        _examineCellCode.DisplayIndex = "0,1"
        '_examineCellCode.NonVisibleColIndex = "2"
        _examineCellCode.ValueIndex = "1"

        _examineCellCode.GridWidth = 410
        _examineCellCode.GridHeight = 300
        _examineCellCode.ConnDBType = ComboBoxGridCell.DBType.RemoteSqlServer
        _examineCellCode.QueryData = ComboBoxGridCell.Data.PUB_Order_Examine
        _examineCellCode.QueryType = ComboBoxGridCell.By.Code
        _examineCellCode.HeaderText = "醫令名稱,醫令代碼"
        _examineCellCode.ColumnWidth = "250,150"
        _examineCellCode.VisibleColIndex = "0,1"
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

    Private Sub SetOrderList(ByVal InputDataTable As DataTable)

        dgv_OrderList.HideControlCell("All")

        dgv_OrderList.Initial(Me.TransformToOrderListHash(InputDataTable))
        dgv_OrderList.uclHeaderText = m_HeaderText
        dgv_OrderList.uclColumnWidth = m_HeaderColumnWidth
        dgv_OrderList.uclVisibleColIndex = m_HeaderVisibleIndexOrderList
        dgv_OrderList.Columns("Sort_Value").ReadOnly = False

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

    Private Sub dgv_OrderList_ColumnWidthChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgv_OrderList.ColumnWidthChanged
        dgv_OrderList.uclHeaderText = m_HeaderText
        dgv_OrderList.uclColumnWidth = m_HeaderColumnWidth
        dgv_OrderList.uclVisibleColIndex = m_HeaderVisibleIndex
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

    Private Function SpecimenVesselDataTableGenerator() As DataTable
        Dim _dt As New DataTable
        _dt.TableName = "PUB_Order_Mapping_Specimen"

        _dt.Columns.Add("Specimen_Id", GetType(String))
        _dt.Columns.Add("Vessel_Id", GetType(String))
        _dt.Columns.Add("As_AddTo_Specimen", GetType(String))
        _dt.Columns.Add("Control_Value", GetType(Int32))
        _dt.Columns.Add("Time_Control_Id", GetType(String))
        _dt.Columns.Add("Is_Default", GetType(String))
        _dt.Columns.Add("Is_Default_Vessel", GetType(String))

        Return _dt
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

    ''' <summary>
    ''' 是否列印表單Indication於申請單
    ''' </summary>
    ''' <value></value>
    ''' <returns>True: 是; False: 否</returns>
    ''' <remarks></remarks>
    Private Property IsPrintSheetIndication() As Boolean
        Get
            Return chk_PrintSheetIndication.Checked
        End Get
        Set(ByVal value As Boolean)
            chk_PrintSheetIndication.Checked = value
        End Set
    End Property

    ''' <summary>
    ''' 是否列印醫令Indication於申請單
    ''' </summary>
    ''' <value></value>
    ''' <returns>True: 是; False: 否</returns>
    ''' <remarks></remarks>
    Private Property IsPrintOrderIndication() As Boolean
        Get
            Return chk_PrintOrderIndication.Checked
        End Get
        Set(ByVal value As Boolean)
            chk_PrintOrderIndication.Checked = value
        End Set
    End Property

    ''' <summary>
    ''' 醫令是否可排程
    ''' </summary>
    ''' <value></value>
    ''' <returns>True: 是; False: 否</returns>
    ''' <remarks></remarks>
    Private Property IsOrderScheduled() As Boolean
        Get
            Return Chk_IsScheduled.Checked
        End Get
        Set(ByVal value As Boolean)
            Chk_IsScheduled.Checked = value
        End Set
    End Property

    ''' <summary>
    ''' 是否立即查看報告
    ''' </summary>
    ''' <value></value>
    ''' <returns>True: 是; False: 否</returns>
    ''' <remarks></remarks>
    Private Property IsSeeReport() As Boolean
        Get
            Return Chk_IsSeeReport.Checked
        End Get
        Set(ByVal value As Boolean)
            Chk_IsSeeReport.Checked = value
        End Set
    End Property

    ''' <summary>
    ''' 是否限健檢用
    ''' </summary>
    ''' <value></value>
    ''' <returns>True: 是; False: 否</returns>
    ''' <remarks></remarks>
    Private Property IsLimitHealth() As Boolean
        Get
            Return Chk_IsLimitHealth.Checked
        End Get
        Set(ByVal value As Boolean)
            Chk_IsLimitHealth.Checked = value
        End Set
    End Property


    ''' <summary>
    ''' 是否有列印醫令的注意事項
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property IsPrintOrderNote() As Boolean
        Get
            Return chk_NoteForPrinting.Checked
        End Get
        Set(ByVal value As Boolean)
            chk_NoteForPrinting.Checked = value
        End Set
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

    Private m_SheetCode As String = String.Empty
    Private Property SheetCode() As String
        Get
            Return m_SheetCode
        End Get
        Set(ByVal value As String)
            m_SheetCode = value
        End Set
    End Property

    Private m_OrderCode As String = String.Empty
    Private Property OrderCode() As String
        Get
            Return m_OrderCode
        End Get
        Set(ByVal value As String)
            Me.m_OrderCode = value
            txt_ORderCode.Text = value
        End Set
    End Property

    Private m_OrderName As String = String.Empty
    Private Property OrderName() As String
        Get
            Return m_OrderName
        End Get
        Set(ByVal value As String)
            Me.m_OrderName = value
            txt_OrderEnName.Text = value
        End Set
    End Property

    Private m_SeparateMark As Int32 = 0
    Private Property SeparateMark() As Int32
        Get
            Return Me.m_SeparateMark
        End Get
        Set(ByVal value As Int32)
            Me.m_SeparateMark = value
        End Set
    End Property

    Private Property IsStandalone() As Boolean
        Get
            Return Me.chk_AloneOrderFlag.Checked
        End Get
        Set(ByVal value As Boolean)
            Me.chk_AloneOrderFlag.Checked = value
        End Set
    End Property

    'Private m_currentUser As String = "940114" 'A500
    'Private m_currentUser As String = "614129" '8200
    Private m_currentUser As String = AppContext.userProfile.userId
    Private ReadOnly Property CurrentUser() As String
        Get
            If m_currentUser Is Nothing Then m_currentUser = String.Empty
            Return m_currentUser
        End Get
    End Property
#End Region

#Region "Event"
    Private Sub OnMynKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F12

                Me.btn_Confirm.Select()
                Me.btn_Confirm.PerformClick()
            Case Else
        End Select
    End Sub

    Private Sub PUBExaminationSheetDetailMaintainUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.MyInitialization()
    End Sub

    Private Sub cbo_SheetList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_SheetList.SelectedIndexChanged

        Me.QueryOrderList()
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
            Return
        End If

        Select Case ctlName
            Case "ExamineOrderCell", "ExamineOrderCodeCell"

                Dim _sheetCode As String = Me.cbo_SheetList.SelectedValue
                Dim _orderEnName As String = row.Cells("Order_En_Name").Value.ToString.TrimEnd
                Dim _orderCode As String = row.Cells("Order_Code").Value.ToString.TrimEnd
                'Dim _treatmentTypeId As String = row.Cells("Treatment_Type_Id").Value.ToString.TrimEnd
                Dim _separateMark As Int32 = 0
                Dim _exclusiveOrderCode As String = String.Empty
                Dim _isPrintIndication As String = "N"
                Dim _isPrintOrderNote As String = "N"
                Dim _IsSeeReport As String = "N"
                Dim _IsLimitHealth As String = "N"
                Dim _orderNote As String = String.Empty
                Dim _SortValue As String = String.Empty

                '先判斷此Order在資料庫中是否有Dc = 'Y' 的資料
                '若有則將Dc改為'N'並Refresh畫面
                '若無則將此order加入資料庫中

                Dim _pubService As PubServiceManager = PubServiceManager.getInstance

                Dim _dt As DataTable = Nothing
                Try
                    _dt = _pubService.PUBExaminationSheetDetailMaintainQuerySheetDetail(_sheetCode, _orderCode).Tables("PUB_Sheet_Detail")
                Catch ex As Exception
                    Syscom.client.cmm.ClientExceptionHandler.ProccessException(ex)
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
                    _drPubSheetDetail("Is_InstantlyRpt") = _IsSeeReport
                    _drPubSheetDetail("Is_Limit_Health") = _IsLimitHealth
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
                        _cnt = _pubService.PUBExaminationSheetDetailMaintainInsertIntoPubSheetDetail(_dsPubSheetDetail)
                    Catch ex As Exception
                        Syscom.client.cmm.ClientExceptionHandler.ProccessException(ex)
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

                    dgv_OrderList.Rows(rowIndex).Cells("Separate_Mark").Value = _separateMark
                    _dtDb.Rows(rowIndex).Item("Separate_Mark") = _separateMark
                    _dtGrid.Rows(rowIndex).Item("Separate_Mark") = _separateMark

                    dgv_OrderList.Rows(rowIndex).Cells("Exclusive_Order_Code").Value = _exclusiveOrderCode
                    _dtDb.Rows(rowIndex).Item("Exclusive_Order_Code") = _exclusiveOrderCode
                    _dtGrid.Rows(rowIndex).Item("Exclusive_Order_Code") = _exclusiveOrderCode

                    dgv_OrderList.Rows(rowIndex).Cells("Is_Print_Indication").Value = _isPrintIndication
                    _dtDb.Rows(rowIndex).Item("Is_Print_Indication") = _isPrintIndication
                    _dtGrid.Rows(rowIndex).Item("Is_Print_Indication") = _isPrintIndication

                    dgv_OrderList.Rows(rowIndex).Cells("Is_Print_Order_Note").Value = _isPrintOrderNote
                    _dtDb.Rows(rowIndex).Item("Is_Print_Order_Note") = _isPrintOrderNote
                    _dtGrid.Rows(rowIndex).Item("Is_Print_Order_Note") = _isPrintOrderNote

                    dgv_OrderList.Rows(rowIndex).Cells("Is_InstantlyRpt").Value = _IsSeeReport
                    _dtDb.Rows(rowIndex).Item("Is_InstantlyRpt") = _IsSeeReport
                    _dtGrid.Rows(rowIndex).Item("Is_InstantlyRpt") = _IsSeeReport

                    dgv_OrderList.Rows(rowIndex).Cells("Is_Limit_Health").Value = _IsLimitHealth
                    _dtDb.Rows(rowIndex).Item("Is_Limit_Health") = _IsLimitHealth
                    _dtGrid.Rows(rowIndex).Item("Is_Limit_Health") = _IsLimitHealth

                    dgv_OrderList.Rows(rowIndex).Cells("Order_Note").Value = _orderNote
                    _dtDb.Rows(rowIndex).Item("Order_Note") = _orderNote
                    _dtGrid.Rows(rowIndex).Item("Order_Note") = _orderNote

                    '取出 Sort_Value
                    Dim _dtForSortValue As DataTable = Nothing
                    Try
                        _dtForSortValue = GetOrderListFromDb(_sheetCode)
                    Catch ex As Exception
                        Syscom.client.cmm.ClientExceptionHandler.ProccessException(ex)
                    End Try

                    Dim _dtForSortValueE = _dtForSortValue.AsEnumerable
                    Dim _sortValueStr As String = _dtForSortValueE.Where(Function(r) r("Sheet_Code").ToString.TrimEnd = _sheetCode AndAlso r("Order_Code").ToString.TrimEnd = _orderCode).Select(Function(r) r("Sort_Value").ToString).FirstOrDefault()

                    If Not String.IsNullOrEmpty(_sortValueStr) Then
                        dgv_OrderList.Rows(rowIndex).Cells("Sort_Value").Value = CInt(_sortValueStr)
                        _dtDb.Rows(rowIndex).Item("Sort_Value") = CInt(_sortValueStr)
                        _dtGrid.Rows(rowIndex).Item("Sort_Value") = CInt(_sortValueStr)
                    End If

                    '==================================================

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
                            _drTreatmentTypeId("Treatment_Type_Id") = "3"
                            _dtTreatmentTypeId.Rows.Add(_drTreatmentTypeId)
                            _dsNew.Tables.Add(_dtTreatmentTypeId)

                            _cnt = _pubService.PUBExaminationSheetDetailMaintainUpdateDcOfPubSheetDetail(_dsNew, Me.CurrentUser)
                        Catch ex As Exception
                            Syscom.client.cmm.ClientExceptionHandler.ProccessException(ex)
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

                        dgv_OrderList.Rows(rowIndex).Cells("Separate_Mark").Value = _dr("Separate_Mark")
                        _dtDb.Rows(rowIndex).Item("Separate_Mark") = _dr("Separate_Mark")
                        _dtGrid.Rows(rowIndex).Item("Separate_Mark") = _dr("Separate_Mark")

                        dgv_OrderList.Rows(rowIndex).Cells("Exclusive_Order_Code").Value = _dr("Exclusive_Order_Code")
                        _dtDb.Rows(rowIndex).Item("Exclusive_Order_Code") = _dr("Exclusive_Order_Code")
                        _dtGrid.Rows(rowIndex).Item("Exclusive_Order_Code") = _dr("Exclusive_Order_Code")

                        dgv_OrderList.Rows(rowIndex).Cells("Is_Print_Indication").Value = _dr("Is_Print_Indication")
                        _dtDb.Rows(rowIndex).Item("Is_Print_Indication") = _dr("Is_Print_Indication")
                        _dtGrid.Rows(rowIndex).Item("Is_Print_Indication") = _dr("Is_Print_Indication")

                        dgv_OrderList.Rows(rowIndex).Cells("Is_Print_Order_Note").Value = _dr("Is_Print_Order_Note")
                        _dtDb.Rows(rowIndex).Item("Is_Print_Order_Note") = _dr("Is_Print_Order_Note")
                        _dtGrid.Rows(rowIndex).Item("Is_Print_Order_Note") = _dr("Is_Print_Order_Note")

                        dgv_OrderList.Rows(rowIndex).Cells("Order_Note").Value = _dr("Order_Note")
                        _dtDb.Rows(rowIndex).Item("Order_Note") = _dr("Order_Note")
                        _dtGrid.Rows(rowIndex).Item("Order_Note") = _dr("Order_Note")

                        '取出 Sort_Value
                        Dim _dtForSortValue As DataTable = Nothing
                        Try
                            _dtForSortValue = GetOrderListFromDb(_sheetCode)
                        Catch ex As Exception
                            Syscom.client.cmm.ClientExceptionHandler.ProccessException(ex)
                        End Try

                        Dim _dtForSortValueE = _dtForSortValue.AsEnumerable
                        Dim _sortValueStr As String = _dtForSortValueE.Where(Function(r) r("Sheet_Code").ToString.TrimEnd = _sheetCode AndAlso r("Order_Code").ToString.TrimEnd = _orderCode).Select(Function(r) r("Sort_Value").ToString).FirstOrDefault()

                        If Not String.IsNullOrEmpty(_sortValueStr) Then
                            dgv_OrderList.Rows(rowIndex).Cells("Sort_Value").Value = CInt(_sortValueStr)
                            _dtDb.Rows(rowIndex).Item("Sort_Value") = CInt(_sortValueStr)
                            _dtGrid.Rows(rowIndex).Item("Sort_Value") = CInt(_sortValueStr)
                        End If
                        '==================================================

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
        Me.QueryOrderList()
    End Sub

    Private Sub dgv_OrderList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_OrderList.CellClick

        If e.RowIndex < 0 OrElse e.ColumnIndex = 0 Then Return

        Me.OrderSelecting(e.RowIndex)
        IsKeyInPhoneNo()
    End Sub

    Private Sub chk_NoteForPrinting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_NoteForPrinting.CheckedChanged

        'If chk_NoteForPrinting.Checked Then
        '    txt_NoteForPrinting.Enabled = True
        'Else
        '    txt_NoteForPrinting.Enabled = False
        'End If
    End Sub

    Private Sub btn_AddToOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AddToSeparateOrder.Click, btn_AddToExclusiveOrder.Click, btn_AddToDuplicatedOrder.Click
        Dim src As UCLDataGridViewUC = Nothing
        Dim dest As UCLDataGridViewUC = Nothing
        Select Case CType(sender, Button).Name
            Case btn_AddToDuplicatedOrder.Name
                src = dgv_SelectoryOrderList2
                dest = dgv_DuplicatedOrder

                Me.MoveSelectedRowToAnotherGridView(src, dest)
            Case btn_AddToSeparateOrder.Name
                src = dgv_SelectoryOrderList
                dest = dgv_SeparateOrder

                '判斷所選醫令中是否有互斥醫令
                Dim _flag As Boolean = False 'Me.CheckIfContainExclusiveOrders(src, dest)
                If _flag Then
                    'MessageHandling.showError("所選醫令中包含互斥醫令或與已選之拆單醫令互斥！")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"所選醫令中包含互斥醫令或與已選之拆單醫令互斥！"}, "")
                    Return
                End If

                Me.SelectRowsFromSelectoryGridView(src, dest)
            Case btn_AddToExclusiveOrder.Name
                src = dgv_SelectoryOrderList
                dest = dgv_ExclusiveOrder

                '判斷所選醫令中是否有相同之拆單註記
                Dim _flag As Boolean = False 'Me.CheckIfContainOrdersSameSeparateMark(src, dest)
                If _flag Then
                    'MessageHandling.showError("所選醫令中包含相同拆單註記之醫令或與已選之互斥醫令有相同拆單註記！")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"所選醫令中包含相同拆單註記之醫令或與已選之互斥醫令有相同拆單註記！"}, "")
                    Return
                End If

                Me.SelectRowsFromSelectoryGridView(src, dest)
            Case Else
                src = Nothing
                dest = Nothing
        End Select
        IsKeyInPhoneNo()
        'Me.MoveSelectedRowToAnotherGridView(src, dest)
    End Sub

    Private Sub btn_RemoveFromOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RemoveFromSeparateOrder.Click, btn_RemoveFromExclusiveOrder.Click, btn_RemoveFromDuplicatedOrder.Click
        Dim dest As UCLDataGridViewUC = Nothing
        Dim src As UCLDataGridViewUC = Nothing
        Select Case CType(sender, Button).Name
            Case btn_RemoveFromDuplicatedOrder.Name
                src = dgv_DuplicatedOrder
                dest = dgv_SelectoryOrderList2

                Me.MoveSelectedRowToAnotherGridView(src, dest)
            Case btn_RemoveFromSeparateOrder.Name
                src = dgv_SeparateOrder
                dest = dgv_SelectoryOrderList

                Me.SelectRowsIntoSelectoryGridView(src)
            Case btn_RemoveFromExclusiveOrder.Name
                src = dgv_ExclusiveOrder
                dest = dgv_SelectoryOrderList

                Me.SelectRowsIntoSelectoryGridView(src)
            Case Else
                src = Nothing
                dest = Nothing
        End Select
        IsKeyInPhoneNo()
        'Me.MoveSelectedRowToAnotherGridView(src, dest)
    End Sub

    Private Sub btn_Confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Confirm.Click

        Me.Confirm()
    End Sub

    Private Sub dgv_SpecimenVessel_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_SpecimenVessel.DataError
        'If (e.Context = DataGridViewDataErrorContexts.Commit) _
        'Then
        '    MessageBox.Show("Commit error")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts _
        '    .CurrentCellChange) Then
        '    MessageBox.Show("Cell change")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts.Parsing) _
        '    Then
        '    MessageBox.Show("parsing error")
        'End If
        'If (e.Context = _
        '    DataGridViewDataErrorContexts.LeaveControl) Then
        '    MessageBox.Show("leave control error")
        'End If

        'If (TypeOf (e.Exception) Is ConstraintException) Then
        '    Dim view As DataGridView = CType(sender, DataGridView)
        '    view.Rows(e.RowIndex).ErrorText = "an error"
        '    view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
        '        .ErrorText = "an error"

        '    e.ThrowException = False
        'End If

    End Sub

    Private Sub dgv_SpecimenVessel_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv_SpecimenVessel.CurrentCellDirtyStateChanged

        Dim d = CType(sender, DataGridView)
        Dim c = d.CurrentCell
        Dim rowIndex = c.RowIndex
        Dim colIndex = c.ColumnIndex

        If colIndex = 5 OrElse colIndex = 6 Then 'Is_Default or Is_Default_Vessel
            '_dt.Columns.Add("Specimen_Id", GetType(String))
            '_dt.Columns.Add("Vessel_Id", GetType(String))
            Dim _specimenId As String = dgv_SpecimenVessel.Rows(rowIndex).Cells("ColumnSpecimenId").Value.ToString
            Dim _vesselId As String = dgv_SpecimenVessel.Rows(rowIndex).Cells("ColumnVesselId").Value.ToString

            If dgv_SpecimenVessel.IsCurrentCellDirty Then
                Dim _dt As DataTable = dgv_SpecimenVessel.DataSource
                Dim _dtE = _dt.AsEnumerable

                Dim CurrentCellValue As String = c.Value.ToString

                If colIndex = 5 AndAlso (CurrentCellValue = "N" OrElse CurrentCellValue = String.Empty) Then

                    If _dtE.Any(Function(r) r("Is_Default").ToString = "Y") Then
                        dgv_SpecimenVessel.CancelEdit()
                    End If

                ElseIf colIndex = 6 AndAlso (CurrentCellValue = "N" OrElse CurrentCellValue = String.Empty) Then

                    If _dtE.Any(Function(r) r("Specimen_Id").ToString = _specimenId AndAlso r("Is_Default_Vessel").ToString = "Y") Then
                        dgv_SpecimenVessel.CancelEdit()
                    End If

                Else
                End If

                '修改值
                dgv_SpecimenVessel.CommitEdit(DataGridViewDataErrorContexts.Commit)
                'dgv_SpecimenVessel.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
            End If
        End If

    End Sub

    Private Sub dgv_SpecimenVessel_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_SpecimenVessel.CellValueChanged

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        If e.ColumnIndex = 0 OrElse e.ColumnIndex = 1 Then

            Dim _currentRow As DataGridViewRow = dgv_SpecimenVessel.CurrentRow
            Dim _currentCell As DataGridViewCell = dgv_SpecimenVessel.CurrentCell

            Dim _dt As DataTable = dgv_SpecimenVessel.DataSource
            Dim _dtE = _dt.AsEnumerable

            Dim _specimenId As String = _currentRow.Cells("ColumnSpecimenId").Value.ToString
            Dim _vesselId As String = _currentRow.Cells("ColumnVesselId").Value.ToString

            _currentRow.Cells("ColumnIsDefault").Value = "N"
            _currentRow.Cells("ColumnIsDefaultVessel").Value = "N"

            If Not _dtE.Any(Function(r) r("Is_Default").ToString.TrimEnd = "Y") Then
                _currentRow.Cells("ColumnIsDefault").Value = "Y"
            End If

            If Not _dtE.Any(Function(r) r("Specimen_Id").ToString.TrimEnd = _specimenId AndAlso r("Vessel_Id").ToString.TrimEnd <> _vesselId AndAlso r("Is_Default_Vessel").ToString.TrimEnd = "Y") Then
                _currentRow.Cells("ColumnIsDefaultVessel").Value = "Y"
            End If
        End If
    End Sub

#Region "DataGridView中ComboBox Selected Index Changed事件"

    'Private Sub dgv_SpecimenVessel_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgv_SpecimenVessel.EditingControlShowing

    '    If e.Control.GetType.Name = "DataGridViewComboBoxEditingControl" Then
    '        Dim cbo = CType(e.Control, ComboBox)
    '        AddHandler cbo.SelectedIndexChanged, AddressOf Me.cbo_SelectedIndexChanged
    '    End If

    'End Sub

    'Private Sub cbo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

    '    Dim cbo As ComboBox = CType(sender, ComboBox)
    '    Try

    '        Dim _currentRow As DataGridViewRow = dgv_SpecimenVessel.CurrentRow
    '        Dim _currentCell As DataGridViewCell = dgv_SpecimenVessel.CurrentCell

    '        Dim _dt As DataTable = dgv_SpecimenVessel.DataSource
    '        Dim _dtE = _dt.AsEnumerable

    '        Dim _specimenId As String = String.Empty
    '        If _currentCell.ColumnIndex = 0 Then
    '            _specimenId = cbo.SelectedValue.ToString
    '        Else
    '            _specimenId = _currentRow.Cells("ColumnSpecimenId").Value.ToString
    '        End If

    '        _currentRow.Cells("ColumnIsDefault").Value = "N"
    '        _currentRow.Cells("ColumnIsDefaultVessel").Value = "N"

    '        If Not _dtE.Any(Function(r) r("Is_Default").ToString.TrimEnd = "Y") Then
    '            _currentRow.Cells("ColumnIsDefault").Value = "Y"
    '        End If

    '        If Not _dtE.Any(Function(r) r("Specimen_Id").ToString.TrimEnd = _specimenId AndAlso r("Is_Default").ToString.TrimEnd = "Y") Then
    '            _currentRow.Cells("ColumnIsDefaultVessel").Value = "Y"
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        'RemoveHandler cbo.SelectedIndexChanged, AddressOf Me.cbo_SelectedIndexChanged
    '        Dim del As MyDelegate = New MyDelegate(AddressOf cbo_SelectedIndexChanged)
    '        Me.RemoveAllEvent(sender, "SelectedIndexChanged", del)
    '    End Try
    'End Sub

    'Private Delegate Sub MyDelegate(ByVal sender As Object, ByVal e As EventArgs)

    'Public Sub RemoveAllEvent(ByVal sender As Object, ByVal eventName As String, ByVal del As [Delegate])
    '    Dim cbo As ComboBox = CType(sender, ComboBox)
    '    Dim type As Type = sender.[GetType]()
    '    Dim eventInfos As System.Reflection.EventInfo() = type.GetEvents()
    '    '獲取所有事件信息
    '    For Each var As System.Reflection.EventInfo In eventInfos
    '        If var.Name.Trim().ToUpper() = eventName.Trim().ToUpper() Then
    '            '移除指定的事件
    '            'var.RemoveEventHandler(sender, del)
    '            RemoveHandler cbo.SelectedIndexChanged, AddressOf Me.cbo_SelectedIndexChanged
    '        End If
    '    Next
    'End Sub
#End Region

    Private Sub btn_DeleteOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DeleteOrder.Click

        Me.DeleteOrder()
    End Sub

    ''' <summary>
    ''' 修改醫令明細
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_UpdateSheetDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_UpdateSheetDetail.Click
        Dim SelectedIndices As Int32() = dgv_OrderList.SelectedIndex

        If SelectedIndices.Count = 0 Then Exit Sub

        'Dim _dtDb As DataTable = dgv_OrderList.GetDBDS.Tables(0)
        Dim _dtDb As DataTable = dgv_OrderList.GetGridDS.Tables(0)
        Dim _dtGrid As DataTable = dgv_OrderList.GetGridDS.Tables(0)

        Dim UpdateDataSet As New DataSet
        Dim UpdateDataTable As DataTable = Me.UpdateDetailDcDataTableGenerator
        For Each Index As Int32 In SelectedIndices
            Dim UpdateRow As DataRow = UpdateDataTable.NewRow
            Dim SheetCode As String = _dtDb.Rows(Index)("Sheet_Code").ToString
            Dim OrderCode As String = _dtDb.Rows(Index)("Order_Code").ToString
            Dim SortValue As String = _dtDb.Rows(Index)("Sort_Value").ToString

            If Index = dgv_OrderList.Rows.Count OrElse SheetCode = String.Empty OrElse OrderCode = String.Empty Then
                '跳過空白行
                Continue For
            End If

            UpdateRow("Sheet_Code") = SheetCode
            UpdateRow("Order_Code") = OrderCode
            UpdateRow("Sort_Value") = SortValue
            UpdateRow("Dc") = "N"
            UpdateDataTable.Rows.Add(UpdateRow)
        Next
        UpdateDataSet.Tables.Add(UpdateDataTable)

        Dim Service As PubServiceManager = PubServiceManager.getInstance

        Dim Cnt As Int32 = 0
        Try
            Cnt += Service.PUBExaminationSheetDetailMaintainUpdateDcOfPubSheetDetail(UpdateDataSet, Me.CurrentUser)
        Catch ex As Exception
            Syscom.client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return
        End Try

        _dtDb.AcceptChanges()
        _dtGrid.AcceptChanges()
    End Sub

    Private Sub btn_LimitTextBoxClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DoctLimitClear.Click, btn_DeptLimitClear.Click

        Dim _btn As Button = CType(sender, Button)

        Select Case _btn.Name
            Case btn_DoctLimitClear.Name

                txt_DoctLimit.Text = String.Empty
            Case btn_DeptLimitClear.Name

                txt_DeptLimit.Text = String.Empty
            Case Else

                Exit Sub
        End Select
        IsKeyInPhoneNo()
    End Sub

    Private Sub btn_LimitDoctDeptClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DoctLimit.Click, btn_DeptLimit.Click

        Dim _Btn As Button = CType(sender, Button)

        Dim _TxtDestination As TextBox = Nothing

        Dim _SelectedValue As String = String.Empty

        Select Case _Btn.Name
            Case btn_DoctLimit.Name
                _TxtDestination = txt_DoctLimit
                _SelectedValue = tcq_DoctLimit.getCode()
            Case btn_DeptLimit.Name
                _TxtDestination = txt_DeptLimit
                _SelectedValue = cbo_DeptLimit.SelectedValue.Trim
            Case Else
                Exit Sub
        End Select

        '若所選項目為空，則不處理
        If _SelectedValue = String.Empty Then Exit Sub

        Dim _LimitValue As String() = _TxtDestination.Text.Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries)

        '若所選項目已包含在已選項目中，則不處理
        If _LimitValue.Contains(_SelectedValue) Then Exit Sub

        Dim _LimitList As List(Of String) = New List(Of String)(_LimitValue.AsEnumerable)

        _LimitList.Add(_SelectedValue)
        _LimitList.Sort()

        _TxtDestination.Text = String.Join(",", _LimitList.ToArray)
        IsKeyInPhoneNo()
    End Sub

    Private Sub IsKeyInPhoneNo()
        Dim IsKeyIn As Boolean = False
        If Not txt_DoctLimit.Text.Trim.Equals("") Or _
           Not txt_DeptLimit.Text.Trim.Equals("") Or _
           Not cbo_SexLimit.SelectedValue.Equals("") Or _
           Not dgv_DuplicatedOrder.GetGridDS.Tables(0).Rows.Count = 0 Then
            IsKeyIn = True
        End If
        If Not IsKeyIn Then
            Txt_PhoneNumber.Text = ""
        End If
        Txt_PhoneNumber.Enabled = IsKeyIn
    End Sub

#Region "Added by Jen"
    Private Sub btn_SheetIndication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SheetIndication.Click
        popIndication(True)
    End Sub

    Private Sub btn_OrderIndication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OrderIndication.Click
        popIndication(False)
    End Sub
#End Region

#End Region

#Region "Action"

    Private Sub MyInitialization()
        Me.TabControlMain.Controls.Remove(Me.TabDuplidatedOrder)
        'dgv_OrderList.DataSource = OrderListDataTableGenerator()
        Me.SetOrderList(OrderListDataTableGenerator())

        Dim _service As PubServiceManager = PubServiceManager.getInstance

        Try
            Dim _ds As DataSet = _service.PUBExaminationSheetDetailMaintainGetInitInfo(Me.CurrentUser)

            Dim _dtSheetCode As DataTable = _ds.Tables(PubSheetDataTableFactory.tableName)
            cbo_SheetList.DataSource = _dtSheetCode
            cbo_SheetList.uclDisplayIndex = "0,1"
            cbo_SheetList.uclValueIndex = "0"

            Dim _dtSpecimen As DataTable = _ds.Tables("Specimen").Copy
            'Dim _newDrSpecimen As DataRow = _dtSpecimen.NewRow
            '_newDrSpecimen(0) = ""
            '_newDrSpecimen(1) = ""
            '_newDrSpecimen(2) = ""
            '_newDrSpecimen(3) = ""
            '_dtSpecimen.Rows.InsertAt(_newDrSpecimen, 0)
            ColumnSpecimenId.DataSource = _dtSpecimen.Copy
            ColumnSpecimenId.DisplayMember = "Code_Name"
            ColumnSpecimenId.ValueMember = "Code_Id"

            Dim _dtVessel As DataTable = _ds.Tables("Vessel").Copy
            'Dim _newDrVessel As DataRow = _dtVessel.NewRow
            '_newDrVessel(0) = ""
            '_newDrVessel(1) = ""
            '_newDrVessel(2) = ""
            '_newDrVessel(3) = ""
            '_dtVessel.Rows.InsertAt(_newDrVessel, 0)
            ColumnVesselId.DataSource = _dtVessel
            ColumnVesselId.DisplayMember = "Code_Name"
            ColumnVesselId.ValueMember = "Code_Id"

            Dim _dtTimeUnit As DataTable = _ds.Tables("Time_Unit").Copy
            Dim _newDrTimeUnit As DataRow = _dtTimeUnit.NewRow
            _newDrTimeUnit(0) = ""
            _newDrTimeUnit(1) = ""
            _newDrTimeUnit(2) = ""
            _newDrTimeUnit(3) = ""
            _dtTimeUnit.Rows.InsertAt(_newDrTimeUnit, 0)
            ColumnTimeControlId.DataSource = _dtTimeUnit.Copy
            ColumnTimeControlId.DisplayMember = "Code_Name"
            ColumnTimeControlId.ValueMember = "Code_Id"

            Dim _dtSexType As DataTable = _ds.Tables("Sex_Type").Copy
            cbo_SexLimit.DataSource = _dtSexType
            cbo_SexLimit.uclDisplayIndex = "0,1"
            cbo_SexLimit.uclValueIndex = "0"

            Dim _dtDeptCode As DataTable = _ds.Tables("Dept_Code").Copy
            cbo_DeptLimit.DataSource = _dtDeptCode
            cbo_DeptLimit.uclDisplayIndex = "0,1"
            cbo_SexLimit.uclValueIndex = "0"

        Catch ex As Exception
            Syscom.client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return
        End Try

        ClearSettingInfo()
    End Sub

    ''' <summary>
    ''' 清除畫面右方之基本資料與開單拆單設定之畫面資料
    ''' </summary>
    ''' <remarks>當選取表單時，先呼叫此method.</remarks>
    Private Sub ClearSettingInfo()

        Me.SheetCode = String.Empty
        Me.OrderCode = String.Empty
        Me.OrderName = String.Empty

        dtp_StartDate.SetValue("")
        dtp_EndDate.SetValue("")

        Me.IsPrintOrderIndication = False
        Me.IsPrintOrderNote = False
        Me.SeparateMark = 0
        Me.IsStandalone = False
        Me.txt_NoteForPrinting.Text = ""

        Me.dgv_SpecimenVessel.DataSource = Me.SpecimenVesselDataTableGenerator()
        Me.SetUclDataGridView(dgv_SelectoryOrderList2, Me.OrderListDataTableGenerator)
        Me.SetUclDataGridView(dgv_SelectoryOrderList, Me.OrderListDataTableGenerator)
        Me.SetUclDataGridView(dgv_DuplicatedOrder, Me.OrderListDataTableGenerator)
        Me.SetUclDataGridView(dgv_SeparateOrder, Me.OrderListDataTableGenerator)
        Me.SetUclDataGridView(dgv_ExclusiveOrder, Me.OrderListDataTableGenerator)
    End Sub

    Private Sub SetUclDataGridView(ByVal dgv As UCLDataGridViewUC, ByVal inputData As DataTable)

        Dim _ds As New DataSet
        _ds.Tables.Add(inputData.Copy)

        dgv.Initial(_ds)
        dgv.uclHeaderText = Me.m_HeaderText
        dgv.uclColumnWidth = Me.m_HeaderColumnWidth
        If dgv.Name = dgv_OrderList.Name Then
            dgv.uclVisibleColIndex = Me.m_HeaderVisibleIndexOrderList
        Else
            dgv.uclVisibleColIndex = Me.m_HeaderVisibleIndex
        End If

        dgv.SetSelectAll(False)
    End Sub

    ''' <summary>
    ''' 查詢表單中所包含的Order.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub QueryOrderList()

        Me.ClearSettingInfo()

        Dim _service As PubServiceManager = PubServiceManager.getInstance

        Dim _dtOrderCodeList As DataTable = Nothing
        Dim _dtSheetLimitCnt As DataTable = Nothing

        Try
            Dim _ds As DataSet = _service.PUBExaminationSheetDetailMaintainGetOrderList(Me.SelectedSheetCode)

            _dtOrderCodeList = _ds.Tables("Order_List")
            _dtSheetLimitCnt = _ds.Tables("Sheet_Limit_Cnt")

        Catch ex As Exception
            Syscom.client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return
        End Try

        'dgv_OrderList.DataSource = IIf(_dtOrderCodeList Is Nothing, Me.OrderListDataTableGenerator, _dtOrderCodeList)
        Me.SetOrderList(IIf(_dtOrderCodeList Is Nothing, Me.OrderListDataTableGenerator, _dtOrderCodeList))

        Try
            txt_SheetLimitCnt.Text = _dtSheetLimitCnt.Rows(0)("Lis_Sheet_Limit_Cnt")
        Catch ex As Exception
            txt_SheetLimitCnt.Text = "-1"
        End Try

        Try
            Me.IsPrintSheetIndication = IIf(_dtSheetLimitCnt.Rows(0)("Is_Print_Indication") = "Y", True, False)
        Catch ex As Exception
            Me.IsPrintSheetIndication = False
        End Try
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
            'Dim _ds As DataSet = Nothing '_service.PUBExaminationSheetDetailMaintainGetOrderList(Me.SelectedSheetCode)
            Dim _ds As DataSet = _service.PUBExaminationSheetDetailMaintainGetOrderList(Me.SelectedSheetCode)
            _dtOrderCodeList = _ds.Tables("Order_List")

        Catch ex As Exception
            Syscom.client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try

        Return IIf(_dtOrderCodeList Is Nothing, Me.OrderListDataTableGenerator, _dtOrderCodeList)
    End Function

    Private Sub OrderSelecting(ByVal RowIndex As Int32)
        MessageHandling.ClearInfoMsg()

        Me.ClearSettingInfo()

        Dim _dt As DataTable = dgv_OrderList.GetDBDS.Tables(0)
        Dim _SheetCode As String = _dt.Rows(RowIndex)("Sheet_Code").ToString
        Dim _OrderCode As String = _dt.Rows(RowIndex)("Order_Code").ToString

        If _SheetCode = String.Empty OrElse _OrderCode = String.Empty Then
            Return
        End If

        Dim _dtDuplicateOrder As DataTable = Me.OrderListDataTableGenerator()
        Dim _dtSeparateOrder As DataTable = Me.OrderListDataTableGenerator()
        Dim _dtExclusiveOrder As DataTable = Me.OrderListDataTableGenerator()
        Dim _dtSelectory As DataTable = Me.GetOrderListFromDb(SheetCode)
        Dim _drSelectory As DataRow = _dtSelectory.AsEnumerable.Where(Function(r) r("Sheet_Code") = _SheetCode And r("Order_Code") = _OrderCode).FirstOrDefault '_dt.Rows(RowIndex)

        '所選醫令之屬性

        Dim _OrderName As String = _drSelectory("Order_Name").ToString
        Dim _SeparateMark As Int32 = _drSelectory("Separate_Mark")
        Dim _ExclusiveOrderCode As String = _drSelectory("Exclusive_Order_Code").ToString
        'Dim _IsIndication As Boolean = IIf(_drSelectory("Is_Indication").ToString = "Y", True, False)
        Dim _IsPrintIndication As Boolean = IIf(_drSelectory("Is_Print_Indication").ToString = "Y", True, False)
        Dim _IsScheduled As Boolean = IIf(_drSelectory("Is_Scheduled").ToString = "Y", True, False)
        Dim _IsSeeReport As Boolean = IIf(_drSelectory("Is_InstantlyRpt").ToString = "Y", True, False)
        Dim _IsLimitHealth As Boolean = IIf(_drSelectory("Is_Limit_Health").ToString = "Y", True, False)
        Dim _IsPrintOrderNote As Boolean = IIf(_drSelectory("Is_Print_Order_Note").ToString = "Y", True, False)
        Dim _Note As String = _drSelectory("Order_Note").ToString
        Dim _OrderEntryNote As String = _drSelectory("Order_Entry_Note").ToString

        Me.SheetCode = _SheetCode
        Me.OrderCode = _OrderCode
        Me.OrderName = _OrderName
        Me.SeparateMark = _SeparateMark

        Me.IsPrintOrderIndication = _IsPrintIndication
        Me.IsOrderScheduled = _IsScheduled
        Me.IsSeeReport = _IsSeeReport
        Me.IsLimitHealth = _IsLimitHealth
        Me.IsPrintOrderNote = _IsPrintOrderNote
        txt_NoteForPrinting.Text = _Note
        txt_NoteForOrdering.Text = _OrderEntryNote


        '先將所選之醫令自全部的醫令中移除
        If _drSelectory IsNot Nothing Then
            _dtSelectory.Rows.Remove(_drSelectory)
        End If


        '設定重覆醫令用之Selectory DataGridView
        Me.SetUclDataGridView(dgv_SelectoryOrderList2, _dtSelectory.Copy)

        '========== 處理互斥醫令 ==========
        '取出互斥醫令之醫令碼
        Dim _exclusiveOrderCodes As String() = _ExclusiveOrderCode.Replace(" ", String.Empty).Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries)

        '取出與原醫令互斥之醫令
        Dim _exclusiveOrders = _dtSelectory.AsEnumerable.Where(Function(r) _exclusiveOrderCodes.Contains(r("Order_Code").ToString))
        For Each _order In _exclusiveOrders
            _dtExclusiveOrder.ImportRow(_order)
        Next
        '====================================

        '========== 處理併單醫令 ==========
        If _SeparateMark <> 0 Then '0為預設值，不屬於任何一張單
            Dim _mergedOrders = _dtSelectory.AsEnumerable.Where(Function(r) _SeparateMark = r("Separate_Mark"))
            For Each _order In _mergedOrders
                _dtSeparateOrder.ImportRow(_order)
            Next
        End If
        '====================================

        '======== 處理可選醫令清單 ========

        '取出每筆醫令之互斥醫令
        Dim _ordersX = From dr In _dtSelectory _
                       Select New With {.OrderCode = dr.Field(Of String)("Order_Code"), _
                                        .ExclusiveOrders = dr("Exclusive_Order_Code").ToString.Replace(" ", String.Empty).Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries)}

        '把可選醫令中，有互斥的醫令移除
        'Dim _indexX1 = _dtSelectory.AsEnumerable.Where(Function(r) _ordersX.Where(Function(rX) rX.OrderCode <> r("Order_Code")).Any(Function(rX) rX.ExclusiveOrders.Contains(r("Order_Code")))).Select(Function(r) _dtSelectory.Rows.IndexOf(r)).OrderByDescending(Function(r) r)
        'For Each _i In _indexX1
        '    _dtSelectory.Rows.RemoveAt(_i)
        'Next

        '##### 2010-04/21 可選醫令除了所選醫令外，其餘保留，不移除 #####
        ''把可選醫令中，與所選醫令互斥的選項移除
        'Dim _indexX2 = _dtSelectory.AsEnumerable.Where(Function(r) _exclusiveOrderCodes.Contains(r("Order_Code"))).Select(Function(r) _dtSelectory.Rows.IndexOf(r)).OrderByDescending(Function(r) r)
        'For Each _i In _indexX2
        '    _dtSelectory.Rows.RemoveAt(_i)
        'Next

        ''把可選醫令中，與所選醫令在同一張單上的選項移除
        'If _SeparateMark <> 0 Then
        '    For Each _dr As DataRow In _dtSelectory.Rows
        '        If _dr("Separate_Mark") = _SeparateMark Then
        '            _dr.Delete()
        '        End If
        '    Next
        'End If
        '_dtSelectory.AcceptChanges()
        '##### END 2010-04/21 可選醫令除了所選醫令外，其餘保留，不移除 #####
        '====================================

        'dgv_SelectoryOrderList.set
        Me.SetUclDataGridView(dgv_SelectoryOrderList, _dtSelectory)
        Me.SetUclDataGridView(dgv_SeparateOrder, _dtSeparateOrder)
        Me.SetUclDataGridView(dgv_ExclusiveOrder, _dtExclusiveOrder)

        '================= 取得Order之額外資訊 ================
        Dim _pubService As PubServiceManager = PubServiceManager.getInstance
        'Dim _dsOrderInfo As DataSet = Nothing '_pubService.PUBExaminationSheetDetailMaintainGetOrderInfo(Me.OrderCode)
        Dim _dsOrderInfo As DataSet = _pubService.PUBExaminationSheetDetailMaintainGetOrderInfo(Me.OrderCode)
        Dim _dtOrder As DataTable = _dsOrderInfo.Tables("PUB_Order")
        Dim _dtSpecimenVessel As DataTable = _dsOrderInfo.Tables("PUB_Order_Mapping_Specimen")
        Dim _dtRules As DataTable = _dsOrderInfo.Tables("Rules")
        If Me.SeparateMark <> 0 AndAlso _dtSeparateOrder.Rows.Count = 0 Then
            Me.IsStandalone = True
        End If

        '設定檢體/容器

        dgv_SpecimenVessel.DataSource = _dtSpecimenVessel

        '設定起迄日
        Try
            Dim _StartDate As String = CDate(_dtOrder.Rows(0)("Effect_Date")).ToShortDateString
            Dim _EndDate As String = CDate(_dtOrder.Rows(0)("End_Date")).ToShortDateString
            dtp_StartDate.SetValue(_StartDate)
            dtp_EndDate.SetValue(_EndDate)
        Catch ex As Exception
            dtp_StartDate.SetValue(String.Empty)
            dtp_EndDate.SetValue(String.Empty)
        End Try

        '================= 設定重覆醫令之資訊 ================
        Me.SetOrderRule(_dtRules)
    End Sub

    ''' <summary>
    ''' 將來源所選擇之資料列，移動至目地資料列
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MoveSelectedRowToAnotherGridView(ByVal src As UCLDataGridViewUC, ByVal dest As UCLDataGridViewUC)
        If src Is Nothing OrElse dest Is Nothing Then Return

        Dim _selectedIndex As Int32() = src.SelectedIndex

        Dim _dtDBSrc As DataTable = src.GetDBDS.Tables(0)
        Dim _dtGridSrc As DataTable = src.GetGridDS.Tables(0)
        Dim _dtDBDest As DataTable = dest.GetDBDS.Tables(0)
        Dim _dtGridDest As DataTable = dest.GetGridDS.Tables(0)

        For Each _index As Int32 In _selectedIndex
            _dtDBDest.ImportRow(_dtDBSrc.Rows(_index))
            _dtGridDest.ImportRow(_dtGridSrc.Rows(_index))
            _dtDBSrc.Rows(_index).Delete()
            _dtGridSrc.Rows(_index).Delete()
        Next

        _dtDBSrc.AcceptChanges()
        _dtGridSrc.AcceptChanges()

        src.SetSelectAll(False)
        dest.SetSelectAll(False)
    End Sub

    ''' <summary>
    ''' 將所選的資料自待選GridView 新增至目地GridView
    ''' </summary>
    ''' <param name="selectory">待選GridView</param>
    ''' <param name="dest">目地GridView</param>
    ''' <remarks></remarks>
    Private Sub SelectRowsFromSelectoryGridView(ByVal selectory As UCLDataGridViewUC, ByVal dest As UCLDataGridViewUC)
        If selectory Is Nothing OrElse dest Is Nothing Then Return

        Dim _selectedIndex As Int32() = selectory.SelectedIndex

        Dim _dtDBSrc As DataTable = selectory.GetDBDS.Tables(0)
        Dim _dtGridSrc As DataTable = selectory.GetGridDS.Tables(0)
        Dim _dtDBDest As DataTable = dest.GetDBDS.Tables(0)
        Dim _dtGridDest As DataTable = dest.GetGridDS.Tables(0)

        For Each _index As Int32 In _selectedIndex

            '若目地GridView已有此資料，則略過此筆
            Dim _orderCodeX As String = _dtDBSrc.Rows(_index)("Order_Code").ToString
            If _dtDBDest.AsEnumerable.Any(Function(r) r("Order_Code").ToString = _orderCodeX) Then
                Continue For
            End If

            _dtDBDest.ImportRow(_dtDBSrc.Rows(_index))
            _dtGridDest.ImportRow(_dtGridSrc.Rows(_index))
        Next

        _dtDBSrc.AcceptChanges()
        _dtGridSrc.AcceptChanges()

        selectory.SetSelectAll(False)
        dest.SetSelectAll(False)
    End Sub

    ''' <summary>
    ''' 將所選的資料自GridView移除
    ''' </summary>
    ''' <param name="src">目標GridView</param>
    ''' <remarks></remarks>
    Private Sub SelectRowsIntoSelectoryGridView(ByVal src As UCLDataGridViewUC)
        If src Is Nothing Then Return

        Dim _selectedIndex As Int32() = src.SelectedIndex

        Dim _dtDBSrc As DataTable = src.GetDBDS.Tables(0)
        Dim _dtGridSrc As DataTable = src.GetGridDS.Tables(0)

        For Each _index As Int32 In _selectedIndex
            _dtDBSrc.Rows(_index).Delete()
            _dtGridSrc.Rows(_index).Delete()
        Next

        _dtDBSrc.AcceptChanges()
        _dtGridSrc.AcceptChanges()

        src.SetSelectAll(False)
    End Sub

    ''' <summary>
    ''' 設定醫令規則
    ''' </summary>
    ''' <param name="Rules">Rules</param>
    ''' <remarks></remarks>
    Private Sub SetOrderRule(ByVal Rules As DataTable)

        Dim _ruleE = Rules.AsEnumerable
        Dim _orderCodes = _ruleE.Where(Function(r) r("Item_Code") = "A00005")
        Dim _sexCodes = _ruleE.Where(Function(r) r("Item_Code") = "E00002")
        Dim _deptCodes = _ruleE.Where(Function(r) r("Item_Code") = "D00003")
        Dim _doctCodes = _ruleE.Where(Function(r) r("Item_Code") = "D00012")
        Dim _ExtNo = _ruleE.Select(Function(r) r("Ext_No").ToString)
        Dim _dtDB As DataTable = dgv_SelectoryOrderList2.GetDBDS.Tables(0)
        Dim _dtGrid As DataTable = dgv_SelectoryOrderList2.GetGridDS.Tables(0)
        Dim _dtDuplicatedOrder As DataTable = Me.OrderListDataTableGenerator()

        Dim _selectedOrderIndexes = _dtDB.AsEnumerable.Where(Function(r) _orderCodes.Any(Function(r2) r2("Value_Data") = r("Order_Code"))).Select(Function(r) _dtDB.Rows.IndexOf(r))

        For Each _index As Int32 In _selectedOrderIndexes
            _dtDuplicatedOrder.ImportRow(_dtDB.Rows(_index))
            _dtDB.Rows(_index).Delete()
            _dtGrid.Rows(_index).Delete()
        Next
        _dtDB.AcceptChanges()
        _dtGrid.AcceptChanges()

        Me.SetUclDataGridView(dgv_DuplicatedOrder, _dtDuplicatedOrder)

        If _sexCodes.Count = 0 Then
            cbo_SexLimit.SelectedValue = ""
        Else
            cbo_SexLimit.SelectedValue = _sexCodes(0).Item("Value_Data").ToString
        End If

        If _deptCodes.Count = 0 Then
            Me.txt_DeptLimit.Text = String.Empty
        Else
            Me.txt_DeptLimit.Text = _deptCodes(0)("Value_Data").ToString.TrimEnd
        End If

        If _doctCodes.Count = 0 Then
            Me.txt_DoctLimit.Text = String.Empty
        Else
            Me.txt_DoctLimit.Text = _doctCodes(0)("Value_Data").ToString.TrimEnd
        End If

        If _ExtNo.Count = 0 Then
            Me.Txt_PhoneNumber.Text = String.Empty
        Else
            Me.Txt_PhoneNumber.Text = _ExtNo(0)
        End If

    End Sub

    ''' <summary>
    ''' 判斷輸入的醫令中是否含有互斥醫令
    ''' </summary>
    ''' <param name="src">來源醫令</param>
    ''' <param name="dest">目地醫令</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckIfContainExclusiveOrders(ByVal src As UCLDataGridViewUC, ByVal dest As UCLDataGridViewUC) As Boolean
        Dim InputData As DataTable = src.GetDBDS.Tables(0).Copy
        Dim InputData2 As DataTable = dest.GetDBDS.Tables(0).Copy
        Dim SelectedIndex As Int32() = src.SelectedIndex

        Dim _OrdersE1 As EnumerableRowCollection(Of DataRow) = InputData.AsEnumerable.Where(Function(r) SelectedIndex.Contains(InputData.Rows.IndexOf(r)))
        Dim _OrdersE2 As EnumerableRowCollection(Of DataRow) = InputData2.AsEnumerable
        Dim _OrdersE = _OrdersE1.Select(Function(r) New With {.Order_Code = r.Field(Of String)("Order_Code"), .Exclusive_Order_Code = r("Exclusive_Order_Code").ToString}).Union(_OrdersE2.Select(Function(r) New With {.Order_Code = r.Field(Of String)("Order_Code"), .Exclusive_Order_Code = r("Exclusive_Order_Code").ToString}))

        '取出每筆醫令之互斥醫令
        Dim _ordersX = From dr In _OrdersE _
                       Select New With {.OrderCode = dr.Order_Code, _
                                        .ExclusiveOrders = dr.Exclusive_Order_Code.Replace(" ", String.Empty).Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries)}

        Dim _flag = _OrdersE.Any(Function(r) _ordersX.Where(Function(rX) rX.OrderCode <> r.Order_Code).Any(Function(rX) rX.ExclusiveOrders.Contains(r.Order_Code)))

        Return _flag
    End Function

    ''' <summary>
    ''' 判斷輸入的醫令中是否含有相同的拆單註記
    ''' </summary>
    ''' <param name="src">來源醫令</param>
    ''' <param name="dest">目地醫令</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckIfContainOrdersSameSeparateMark(ByVal src As UCLDataGridViewUC, ByVal dest As UCLDataGridViewUC) As Boolean
        Dim InputData As DataTable = src.GetDBDS.Tables(0).Copy
        Dim InputData2 As DataTable = dest.GetDBDS.Tables(0).Copy
        Dim SelectedIndex As Int32() = src.SelectedIndex

        Dim _OrdersE1 As EnumerableRowCollection(Of DataRow) = InputData.AsEnumerable.Where(Function(r) SelectedIndex.Contains(InputData.Rows.IndexOf(r)))
        Dim _OrdersE2 As EnumerableRowCollection(Of DataRow) = InputData2.AsEnumerable
        Dim _OrdersE = _OrdersE1.Select(Function(r) New With {.Order_Code = r.Field(Of String)("Order_Code"), .Separate_Mark = r.Field(Of Int32)("Separate_Mark")}).Union(_OrdersE2.Select(Function(r) New With {.Order_Code = r.Field(Of String)("Order_Code"), .Separate_Mark = r.Field(Of Int32)("Separate_Mark")}))

        Dim _flag = _OrdersE.Any(Function(r) r.Separate_Mark <> 0 AndAlso _OrdersE.Any(Function(rX) rX.Order_Code <> r.Order_Code AndAlso rX.Separate_Mark = r.Separate_Mark))

        Return _flag
    End Function

    Private Sub Confirm()
        MessageHandling.ClearInfoMsg()

        dtp_StartDate.SetValue("1911/01/01")
        dtp_EndDate.SetValue("2910/12/31")

        Dim _flagDate As Boolean = dtp_StartDate.GetUsDateStr = String.Empty OrElse dtp_EndDate.GetUsDateStr = String.Empty
        If _flagDate Then
            'MessageHandling.showError("請輸入啟用/停用日期！")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"請輸入啟用/停用日期！"}, "")
            Return
        End If

        Dim _dsX As New DataSet

        Dim _dtSpecimenVessel As DataTable = Me.dgv_SpecimenVessel.DataSource
        If _dtSpecimenVessel Is Nothing Then _dtSpecimenVessel = Me.SpecimenVesselDataTableGenerator
        _dtSpecimenVessel = _dtSpecimenVessel.Copy
        _dtSpecimenVessel.TableName = "SpecimenVessel"
        _dsX.Tables.Add(_dtSpecimenVessel)

        _dtSpecimenVessel.AcceptChanges()
        '========== 驗証檢體/容器資料之正確性 ==========
        '判斷檢體與容器欄位是否都有值
        Dim _flagSpecimenVessel1 As Boolean = _dtSpecimenVessel.AsEnumerable.Any(Function(r) r("Specimen_Id").ToString = String.Empty AndAlso r("Vessel_Id").ToString = String.Empty)
        If _flagSpecimenVessel1 Then
            'MessageHandling.showError("'檢體' 與 '容器' 欄位不可空白！")
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"'檢體' 與 '容器' 欄位不可空白！"}, "")
            Return
        End If

        '取出勾選 同檢體加作 且資料不完整之項目
        'Dim _flagSpecimenVessel2 As Boolean = _dtSpecimenVessel.AsEnumerable.Any(Function(r) "Y" = r("As_AddTo_Specimen").ToString AndAlso (r("Control_Value").ToString = String.Empty OrElse r("Time_Control_Id").ToString = String.Empty))
        'If _flagSpecimenVessel2 Then
        '    'MessageHandling.showError("檢體/容器中有勾選""同檢體加作""者 " & vbCrLf & " 需填入時間與時間單位")
        '    '********************2010/2/9 Modify By Alan**********************
        '    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"檢體/容器中有勾選""同檢體加作""者 " & vbCrLf & " 需填入時間與時間單位"}, "")
        '    Return
        'End If
        '===================================================

        Dim _dtSelectory As DataTable = Me.dgv_SelectoryOrderList.GetDBDS.Tables(0).Copy
        _dtSelectory.TableName = "SelectoryOrder"
        _dsX.Tables.Add(_dtSelectory)

        Dim _dtDuplicatedOrder As DataTable = Me.dgv_DuplicatedOrder.GetDBDS.Tables(0).Copy
        _dtDuplicatedOrder.TableName = "DuplicateOrder"
        _dsX.Tables.Add(_dtDuplicatedOrder)

        Dim _dtSeparatedOrder As DataTable = Me.dgv_SeparateOrder.GetDBDS.Tables(0).Copy
        _dtSeparatedOrder.TableName = "SeparatedOrder"
        _dsX.Tables.Add(_dtSeparatedOrder)

        Dim _dtExclusiveOrder As DataTable = Me.dgv_ExclusiveOrder.GetDBDS.Tables(0).Copy
        _dtExclusiveOrder.TableName = "ExclusiveOrder"
        _dsX.Tables.Add(_dtExclusiveOrder)

        Dim _xxx As Date = Now
        Dim _xxx2 As Int32 = 0

        Dim _dtOrderInfo As New DataTable
        _dtOrderInfo.TableName = "OrderInfo"
        _dtOrderInfo.Columns.Add("Sheet_Code", GetType(String))
        _dtOrderInfo.Columns.Add("Order_Code", GetType(String))
        _dtOrderInfo.Columns.Add("Effect_Date", GetType(Date))
        _dtOrderInfo.Columns.Add("End_Date", GetType(Date))
        _dtOrderInfo.Columns.Add("Lis_Sheet_Limit_Cnt", GetType(Int32))
        _dtOrderInfo.Columns.Add("Is_Print_Indication_Sheet", GetType(String))
        _dtOrderInfo.Columns.Add("Is_Print_Indication", GetType(String))
        _dtOrderInfo.Columns.Add("Is_Scheduled", GetType(String))
        _dtOrderInfo.Columns.Add("Is_Print_Order_Note", GetType(String))
        _dtOrderInfo.Columns.Add("Is_InstantlyRpt", GetType(String))
        _dtOrderInfo.Columns.Add("Is_Limit_Health", GetType(String))
        _dtOrderInfo.Columns.Add("Order_Note", GetType(String))
        _dtOrderInfo.Columns.Add("Separate_Mark", GetType(Int32))
        _dtOrderInfo.Columns.Add("Is_Standalone", GetType(String))
        _dtOrderInfo.Columns.Add("Sex_Id", GetType(String))
        _dtOrderInfo.Columns.Add("Dept_Code", GetType(String))
        _dtOrderInfo.Columns.Add("Doct_Code", GetType(String))
        _dtOrderInfo.Columns.Add("Ext_No", GetType(String))
        _dtOrderInfo.Columns.Add("Order_Entry_Note", GetType(String))
        Dim _drOrderInfo As DataRow = _dtOrderInfo.NewRow
        _drOrderInfo("Sheet_Code") = Me.SheetCode
        _drOrderInfo("Order_Code") = Me.OrderCode
        _drOrderInfo("Effect_Date") = IIf(Date.TryParse(dtp_StartDate.GetUsDateStr, _xxx), Date.Parse(dtp_StartDate.GetUsDateStr), DBNull.Value)
        _drOrderInfo("End_Date") = IIf(Date.TryParse(dtp_EndDate.GetUsDateStr, _xxx), Date.Parse(dtp_EndDate.GetUsDateStr), DBNull.Value)
        _drOrderInfo("Lis_Sheet_Limit_Cnt") = IIf(Int32.TryParse(txt_SheetLimitCnt.Text, _xxx2), Int32.Parse(txt_SheetLimitCnt.Text), DBNull.Value)
        _drOrderInfo("Is_Print_Indication_Sheet") = IIf(Me.IsPrintSheetIndication, "Y", "N")
        _drOrderInfo("Is_Print_Indication") = IIf(Me.IsPrintOrderIndication, "Y", "N")
        _drOrderInfo("Is_Scheduled") = IIf(Me.IsOrderScheduled, "Y", "N")
        _drOrderInfo("Is_Print_Order_Note") = IIf(Me.IsPrintOrderNote, "Y", "N")
        _drOrderInfo("Is_InstantlyRpt") = IIf(Me.IsSeeReport, "Y", "N")
        _drOrderInfo("Is_Limit_Health") = IIf(Me.IsLimitHealth, "Y", "N")
        _drOrderInfo("Order_Note") = txt_NoteForPrinting.Text
        _drOrderInfo("Order_Entry_Note") = txt_NoteForOrdering.Text
        _drOrderInfo("Separate_Mark") = Me.SeparateMark
        _drOrderInfo("Is_Standalone") = IIf(Me.IsStandalone, "Y", "N")
        _drOrderInfo("Sex_Id") = cbo_SexLimit.SelectedValue
        _drOrderInfo("Dept_Code") = txt_DeptLimit.Text 'cbo_DeptLimit.SelectedValue
        _drOrderInfo("Doct_Code") = txt_DoctLimit.Text
        _drOrderInfo("Ext_No") = Txt_PhoneNumber.Text
        _dtOrderInfo.Rows.Add(_drOrderInfo)
        _dsX.Tables.Add(_dtOrderInfo)

        Dim _pubService As PubServiceManager = PubServiceManager.getInstance

        Dim _cnt As Int32 = 0
        Try
            _cnt += _pubService.PUBExaminationSheetDetailMaintainWriteBackEditedInfo(_dsX, Me.CurrentUser)
        Catch ex As Exception
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
            Return
        End Try

        'MessageHandling.showInfo("確認成功")
        '********************2010/2/9 Modify By Alan**********************
        MessageHandling.ShowInfoMsg("CMMCMMB300", New String() {"確認成功"})
    End Sub

    Private Sub DeleteOrder()

        Dim _indexS As Int32() = dgv_OrderList.SelectedIndex

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
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
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

#Region "Added by Jen"

    Private Sub popIndication(ByVal isSheet As Boolean)
        If isSheet Then
            If cbo_SheetList.SelectedIndex > 0 Then
                'Dim indicationUI As PUBIndicationUI = New PUBIndicationUI
                'indicationUI.sheetCode = cbo_SheetList.SelectedValue.Trim
                'indicationUI.ShowDialog()
            Else
                cbo_SheetList.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                cbo_SheetList.Focus()
                'MessageHandling.showErrorByKey("CMMCMMB009")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowErrorMsg("CMMCMMB009", New String() {}, "")
            End If
        Else
            If txt_ORderCode.Text.Trim.Length > 0 Then
                'Dim indicationUI As PUBIndicationUI = New PUBIndicationUI
                'indicationUI.orderCode = txt_ORderCode.Text.Trim
                'indicationUI.ShowDialog()
            Else
                txt_ORderCode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                cbo_SheetList.Focus()
                'MessageHandling.showErrorByKey("CMMCMMB009")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowErrorMsg("CMMCMMB009", New String() {}, "")
            End If
        End If
    End Sub
#End Region

#End Region

End Class


