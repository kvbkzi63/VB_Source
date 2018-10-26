Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports System.Text
Imports Syscom.Client.UCL

Public Class PUBRisFormMaintainUI


    '============================
    '程式說明：檢查表單維護
    '修改日期：2009.12.02
    '修改日期：2009.12.02
    '開發人員：Jen
    '============================

    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub


#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    'Dim pub As PUBDelegate = PUBDelegate.getInstance

    Dim loginUser As String = AppContext.userProfile.userId
    Dim ErrorKeyFlag As Boolean = False

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim SheetDetailColumn() As String = {"醫令代碼", "名稱", "排序", "單獨拆單註記", "明細", "Separate_No"}
    Dim SheetDetailColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeInteger}

    'modifyorder資料用
    Dim updateOrderColumn() As String = {"Order_Code", "Effect_Date", "Modified_User", "Is_Indication", "Order_Note", "Order_Entry_Note"}
    Dim updateOrderColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}
    Dim updateOrderExaminationColumn() As String = {"Order_Code", "Modified_User", "Default_Main_Body_Site_Code", "Default_Body_Site_Code", "Default_Side_Id", "Is_Scheduled", _
                                                    "Is_Print_Order_Note", "Is_Main_Body_Site", "Is_Body_Site", "Is_Side_Id", "Is_PACS", "Is_With_Contrast", "Opd_Report_Time", "Emg_Report_Time", "Ipd_Report_Time", "Nhi_Body_Site_Code", "Is_No_Check_In", "Is_No_Print"}
    Dim updateOrderExaminationColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                                         DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString, _
                                                         DataSetUtil.TypeDecimal, DataSetUtil.TypeDecimal, DataSetUtil.TypeDecimal, DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeString}

    'Private DialogFlag As Boolean = False
    Private SheetDT As DataTable = Nothing
    Private BodySiteDT As DataTable = Nothing
    Private SideDT As DataTable = Nothing
    Private DeptDT As DataTable = Nothing
    Private SheetHash As Hashtable = New Hashtable

    Private SheetDetailHash As Hashtable = New Hashtable 'Sheet_Code-Order_Code, dr

    Private ToSheetDetailDT As DataTable = Nothing

    Private systemDate As Date = DateUtil.getSystemDate

    Private gblColumnWidth = "170,500,100,100,75,0" '958
#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBRisFormMaintainUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loadPubServiceManager()

        Dim sheetDS As DataSet = pub.initSheetData()
        Dim SheetDT As DataSet = pub.PUBRisFormMaintainGetAvalibleSheet(loginUser)

        If DataSetUtil.IsContainsData(sheetDS) Then

            'BodySiteDT
            If sheetDS.Tables.Contains(PubSheetDataTableFactory.tableName) Then

                Dim combDT As DataTable = DataSetUtil.createDataTable("sheet", Nothing, ComboBoxColumn, ComboBoxColumnType)

                setSheetHash(SheetDT, combDT)

                initcboSheetCode()
            End If

            If sheetDS.Tables.Contains(PubBodySiteDataTableFactory.tableName) Then
                BodySiteDT = sheetDS.Tables(PubBodySiteDataTableFactory.tableName).Copy
            End If

            If sheetDS.Tables.Contains(PubSyscodeDataTableFactory.tableName) Then
                SideDT = sheetDS.Tables(PubSyscodeDataTableFactory.tableName).Copy
            End If

            If sheetDS.Tables.Contains(PubDepartmentDataTableFactory.tableName) Then
                DeptDT = sheetDS.Tables(PubDepartmentDataTableFactory.tableName).Copy
                ucl_comb_exedept.DataSource = DeptDT
                ucl_comb_exedept.uclValueIndex = "0"
                ucl_comb_exedept.uclDisplayIndex = "0,1"
            End If

            If sheetDS.Tables.Contains("systemdate") Then
                systemDate = CType(sheetDS.Tables("systemdate").Rows(0).Item("System_Date"), Date)
            End If

        End If


        ''init Grid資料
        ''----------------------------------------------
        Dim detailDS As DataSet = New DataSet
        Dim detailDT As DataTable = DataSetUtil.createDataTable("sheetdetail", Nothing, SheetDetailColumn, SheetDetailColumnType)

        'Hash版
        detailDS.Tables.Add(detailDT)
        Dim _hashTable As Hashtable = New Hashtable
        Dim txt_int_cell As New TextBoxCell()
        Dim chk_cell As New CheckBoxCell()
        Dim btn_cell As New ButtonCell()
        btn_cell.Text = "明細"

        'txt_int_cell.uclTextType = TextBoxCell.uclTextTypeData.Integer_Type

        _hashTable.Add(-1, detailDS)
        _hashTable.Add(2, txt_int_cell)
        _hashTable.Add(3, chk_cell)
        _hashTable.Add(4, btn_cell)
        ucl_dgv_detail.Initial(_hashTable)

        '初始化完再設定欄寬
        ucl_dgv_detail.uclHeaderText = UCLDataGridViewUC.convertColumnToHeader(SheetDetailColumn)
        ucl_dgv_detail.uclColumnAlignment = "0"
        ucl_dgv_detail.uclColumnWidth = gblColumnWidth
        ucl_dgv_detail.uclNonVisibleColIndex = "5"

        ucl_comb_sheetcode.Focus()
        Me.KeyPreview = True

    End Sub

#End Region

#Region "########## 共用函式 ##########"

    ''' <summary>
    ''' 取得clientservice
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadPubServiceManager()
        Try
            pub = PubServiceManager.getInstance
        Catch ex As Exception
            'MessageHandling.showInfoByKey("CMMCMMB001")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showInfoMsg("CMMCMMB001", New String() {})
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 欄位檢查
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkColumn() As Boolean
        Dim comp As Object = Nothing
        Dim allPass As Boolean = True
        'If Not UclComboBoxUILender.SelectedIndex > 0 Then
        '    UclComboBoxUILender.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    allPass = False
        '    comp = UclComboBoxUILender
        'End If


        If allPass Then
            cleanFieldsColor()
        Else
            ErrorKeyFlag = True
            comp.Focus()
        End If

        Return allPass
    End Function

    ''' <summary>
    ''' 先將需要檢查欄位的back color設為default
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            '先將需要檢查欄位的back color設為default
            'UclComboBoxUILender.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'UclComboBoxUILendType.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'UclComboBoxUILendReason.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            'UclComboBoxUILendDept.BackColor = ScreenUtil.BACK_COLOR_DEFAULT

            ErrorKeyFlag = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''----------------------------------------------------------------------------
    ''用對話視窗方式開啟，不執行資料庫動作(存DataSet)
    ''----------------------------------------------------------------------------
    '''' <summary>
    '''' 用dialog方式開啟
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function ShowAndPrepareReturnData() As Boolean
    '    DialogFlag = True
    '    Me.ShowDialog()

    '    Return True

    'End Function

    ''' <summary>
    ''' 表單資料導向畫面
    ''' </summary>
    ''' <param name="sheetDR"></param>
    ''' <remarks></remarks>
    Private Sub sheetDataToUI(ByRef sheetDR As DataRow)
        If sheetDR IsNot Nothing Then

            If Not IsDBNull(sheetDR.Item("Sheet_Code")) Then

                'sheet 資料
                If Not IsDBNull(sheetDR.Item("Sheet_Name")) Then
                    ucl_txt_sheetname.Text = CType(sheetDR.Item("Sheet_Name"), String).Trim
                Else
                    ucl_txt_sheetname.Text = ""
                End If

                'sheet 資料
                If Not IsDBNull(sheetDR.Item("Dept_Code")) Then
                    ucl_comb_exedept.SelectedValue = CType(sheetDR.Item("Dept_Code"), String).Trim
                Else
                    ucl_comb_exedept.SelectedIndex = -1
                End If


                If Not IsDBNull(sheetDR.Item("Is_Emergency_Sheet")) Then
                    If CType(sheetDR.Item("Is_Emergency_Sheet"), String).Trim.Equals("Y") Then
                        cb_emgsheet.Checked = True
                    Else
                        cb_emgsheet.Checked = False
                    End If
                Else
                    cb_emgsheet.Checked = False
                End If

                'If Not IsDBNull(sheetDR.Item("Is_Indication")) Then
                '    If CType(sheetDR.Item("Is_Indication"), String).Trim.Equals("Y") Then
                '        btn_indication.Enabled = True
                '    Else
                '        btn_indication.Enabled = False
                '    End If
                'Else
                '    btn_indication.Enabled = False
                'End If

                If Not IsDBNull(sheetDR.Item("Is_Print_Indication")) Then
                    If CType(sheetDR.Item("Is_Print_Indication"), String).Trim.Equals("Y") Then
                        cb_printindication.Checked = True
                    Else
                        cb_printindication.Checked = False
                    End If
                Else
                    cb_printindication.Checked = False
                End If

                'If Not IsDBNull(sheetDR.Item("Sheet_Contect_Tel")) Then
                '    ucl_txt_connecttel.Text = CType(sheetDR.Item("Sheet_Contect_Tel"), String).Trim
                'Else
                ucl_txt_connecttel.Text = ""
                'End If

                If Not IsDBNull(sheetDR.Item("Sheet_Note")) Then
                    ucl_rt_msg.Text = CType(sheetDR.Item("Sheet_Note"), String).Trim
                Else
                    ucl_rt_msg.Text = ""
                End If

                'sheet detail資料
                Dim SheetCode As String = CType(sheetDR.Item("Sheet_Code"), String).Trim
                Dim sheetDetailDT As DataTable = pub.querySheetDetailData(SheetCode)
                'detail to grid
                sheetDetailToGrid(sheetDetailDT)

            Else
                sheetDataToUI(Nothing)
            End If
        Else
            '表示青空
            ucl_txt_sheetname.Text = ""
            cb_emgsheet.Checked = False
            'btn_indication.Enabled = False
            cb_printindication.Checked = False
            ucl_txt_connecttel.Text = ""
            ucl_rt_msg.Text = ""

            ucl_dgv_detail.ClearDS()

            SheetDetailHash.Clear()
        End If

    End Sub

    Private Sub sheetDetailToGrid(ByRef sheetDetailDT As DataTable)

        '清除存的detail內容
        SheetDetailHash.Clear()

        Dim detailDS As New DataSet
        Dim detailDT As DataTable = DataSetUtil.createDataTable("sheetdetail", Nothing, SheetDetailColumn, SheetDetailColumnType)
        If DataSetUtil.IsContainsData(sheetDetailDT) Then
            For Each dr As DataRow In sheetDetailDT.Rows
                If (Not IsDBNull(dr.Item("Sheet_Code"))) AndAlso (Not IsDBNull(dr.Item("Order_Code"))) Then
                    'detail的hash
                    Dim key As String = CType(dr.Item("Sheet_Code"), String).Trim & "-" & CType(dr.Item("Order_Code"), String).Trim
                    SheetDetailHash.Add(key, dr)

                    Dim detaildr As DataRow = detailDT.NewRow

                    If Not IsDBNull(dr.Item("Order_Code")) Then
                        detaildr.Item(SheetDetailColumn(0)) = CType(dr.Item("Order_Code"), String).Trim
                    Else
                        detaildr.Item(SheetDetailColumn(0)) = ""
                    End If

                    If Not IsDBNull(dr.Item("Order_Name")) Then
                        detaildr.Item(SheetDetailColumn(1)) = CType(dr.Item("Order_Name"), String).Trim
                    Else
                        detaildr.Item(SheetDetailColumn(1)) = ""
                    End If

                    If Not IsDBNull(dr.Item("Sheet_Detail_Sort_Value")) Then
                        detaildr.Item(SheetDetailColumn(2)) = CType(dr.Item("Sheet_Detail_Sort_Value"), String).Trim
                    Else
                        detaildr.Item(SheetDetailColumn(2)) = ""
                    End If

                    If Not IsDBNull(dr.Item("Separate_Mark")) Then
                        Dim separateMark As Integer = 0
                        Try
                            separateMark = CType(dr.Item("Separate_Mark"), Integer)
                        Catch ex As Exception

                        End Try

                        If separateMark > 0 Then
                            detaildr.Item(SheetDetailColumn(3)) = "Y"
                            detaildr.Item(SheetDetailColumn(5)) = CType(dr.Item("Separate_Mark"), Integer)
                        Else
                            detaildr.Item(SheetDetailColumn(3)) = "N"
                            detaildr.Item(SheetDetailColumn(5)) = 0
                        End If

                    Else
                        detaildr.Item(SheetDetailColumn(3)) = "N"
                        detaildr.Item(SheetDetailColumn(5)) = 0
                    End If

                    detaildr.Item(SheetDetailColumn(4)) = ""

                    detailDT.Rows.Add(detaildr)
                End If
            Next

        Else
            '帶出 "H" + SheetCode 頭的 order_code資料  ex: ordercode like 'H0951%'

            Dim likeCode As String = "H" & CType(ucl_comb_sheetcode.SelectedValue, String).Trim

            Dim likeDT As DataTable = pub.queryLikeOrderData(likeCode)

            If DataSetUtil.IsContainsData(likeDT) Then
                For Each dr As DataRow In likeDT.Rows
                    Dim detaildr As DataRow = detailDT.NewRow



                    If Not IsDBNull(dr.Item("Order_Code")) Then
                        'detail的hash
                        Dim hashdr As DataRow = sheetDetailDT.NewRow
                        Dim key As String = CType(ucl_comb_sheetcode.SelectedValue, String).Trim & "-" & CType(dr.Item("Order_Code"), String).Trim
                        hashdr.Item("Order_Code") = CType(dr.Item("Order_Code"), String).Trim
                        hashdr.Item("Sheet_Code") = CType(ucl_comb_sheetcode.SelectedValue, String).Trim

                        detaildr.Item(SheetDetailColumn(0)) = CType(dr.Item("Order_Code"), String).Trim

                        If Not IsDBNull(dr.Item("Order_Name")) Then
                            hashdr.Item("Order_Name") = CType(dr.Item("Order_Name"), String).Trim

                            detaildr.Item(SheetDetailColumn(1)) = CType(dr.Item("Order_Name"), String).Trim
                        Else
                            detaildr.Item(SheetDetailColumn(1)) = ""
                        End If

                        detailDT.Rows.Add(detaildr)
                        SheetDetailHash.Add(key, hashdr)


                    Else
                        detaildr.Item(SheetDetailColumn(0)) = ""
                    End If


                Next
            End If

        End If

        detailDS.Tables.Add(detailDT)

        setDSAndRefresh(detailDS)







        refreshSequenceNo()

    End Sub

    ''' <summary>
    ''' ui資料導向datatable
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function uiToSheetData() As DataTable

        Dim uiToSheetDT As DataTable = PubSheetDataTableFactory.getDataTableWithSchema
        'ui to a sheet data
        Dim sheetDR As DataRow = uiToSheetDT.NewRow

        sheetDR.Item("Sheet_Code") = IIf(StringUtil.nvl(ucl_comb_sheetcode.SelectedValue).Length > 0, StringUtil.nvl(ucl_comb_sheetcode.SelectedValue), StringUtil.nvl(ucl_comb_sheetcode.Text))
        sheetDR.Item("Sheet_Name") = ucl_txt_sheetname.Text.Trim

        If ucl_comb_exedept.SelectedIndex > 0 Then
            sheetDR.Item("Dept_Code") = ucl_comb_exedept.SelectedValue.Trim
        Else
            sheetDR.Item("Dept_Code") = "" '暫緩
        End If

        If cb_emgsheet.Checked Then
            sheetDR.Item("Is_Emergency_Sheet") = "Y"
        Else
            sheetDR.Item("Is_Emergency_Sheet") = "N"
        End If

        '---------------
        '查 pub_indication

        sheetDR.Item("Is_Indication") = "N"

        If cb_printindication.Checked Then
            sheetDR.Item("Is_Print_Indication") = "Y"
        Else
            sheetDR.Item("Is_Print_Indication") = "N"
        End If

        sheetDR.Item("Sheet_Note") = ucl_rt_msg.Text.Trim
        'sheetDR.Item("Sheet_Contect_Tel") = ucl_txt_connecttel.Text.Trim
        sheetDR.Item("Is_Print") = "Y"
        sheetDR.Item("Sheet_Type_Id") = "2"
        sheetDR.Item("Lis_Sheet_Limit_Cnt") = 9999
        sheetDR.Item("Sheet_Sort_Value") = 1
        sheetDR.Item("Dc") = "N"

        'loginUser
        sheetDR.Item("Create_User") = loginUser
        sheetDR.Item("Create_Time") = systemDate

        uiToSheetDT.Rows.Add(sheetDR)

        Return uiToSheetDT

    End Function

    Private Function uiToSheetDetailAndGroupData() As DataSet

        Dim sheetAndGroupDS As New DataSet

        Dim bodySiteHash As New Hashtable
        If DataSetUtil.IsContainsData(BodySiteDT) Then
            For Each dr As DataRow In BodySiteDT.Rows
                Dim bscode As String = ""
                If Not IsDBNull(dr.Item("Body_Site_Code")) Then
                    bscode = CType(dr.Item("Body_Site_Code"), String).Trim
                End If

                Dim bsname As String = ""
                If Not IsDBNull(dr.Item("Body_Site_Name")) Then
                    bsname = CType(dr.Item("Body_Site_Name"), String).Trim
                End If

                If (bscode IsNot Nothing AndAlso bscode.Length > 0) AndAlso (bsname IsNot Nothing AndAlso bsname.Length > 0) Then
                    bodySiteHash.Add(bscode, bsname)
                End If
            Next
        End If

        Dim sheetGroupDT As DataTable = PubSheetGroupDataTableFactory.getDataTableWithSchema

        Dim gridDS As DataSet = ucl_dgv_detail.GetDBDS.Copy
        If DataSetUtil.IsContainsData(gridDS) Then

            Dim uiToSheetDetailDT As DataTable = PubSheetDetailDataTableFactory.getDataTableWithSchema
            'grid, and hash data
            Dim nowSheetCode As String = ucl_comb_sheetcode.SelectedValue.Trim

            For Each dr As DataRow In gridDS.Tables(0).Rows
                Dim orderCode As String = CType(dr.Item(SheetDetailColumn(0)), String).Trim

                Dim detailDR As DataRow = uiToSheetDetailDT.NewRow
                detailDR.Item("Sheet_Code") = nowSheetCode
                detailDR.Item("Order_Code") = orderCode

                detailDR.Item("Is_Indication") = "N"

                If (Not IsDBNull(dr.Item(SheetDetailColumn(5)))) AndAlso (CType(dr.Item(SheetDetailColumn(5)), Integer) > 0) Then
                    detailDR.Item("Separate_Mark") = CType(dr.Item(SheetDetailColumn(5)), Integer)
                Else
                    'no... null?
                    detailDR.Item("Separate_Mark") = 0
                End If

                If (Not IsDBNull(dr.Item(SheetDetailColumn(2)))) AndAlso (CType(dr.Item(SheetDetailColumn(2)), Integer) > 0) Then
                    detailDR.Item("Sheet_Detail_Sort_Value") = CType(dr.Item(SheetDetailColumn(2)), Integer)
                Else
                    'no... null?
                    detailDR.Item("Sheet_Detail_Sort_Value") = 0
                End If

                detailDR.Item("Dc") = "N"
                'loginUser
                detailDR.Item("Create_User") = loginUser
                detailDR.Item("Create_Time") = systemDate


                Dim detailkey As String = nowSheetCode & "-" & CType(dr.Item(SheetDetailColumn(0)), String).Trim


                'TODO 依訂要先存在???
                If SheetDetailHash.ContainsKey(detailkey) Then
                    Dim storeDR As DataRow = CType(SheetDetailHash.Item(detailkey), DataRow)

                    If Not IsDBNull(storeDR.Item("Is_Print_Indication")) Then
                        detailDR.Item("Is_Print_Indication") = CType(storeDR.Item("Is_Print_Indication"), String).Trim
                    Else
                        detailDR.Item("Is_Print_Indication") = "N"
                    End If

                    If Not IsDBNull(storeDR.Item("Order_Note")) Then
                        detailDR.Item("Order_Note") = CType(storeDR.Item("Order_Note"), String).Trim
                    Else
                        detailDR.Item("Order_Note") = ""
                    End If

                    detailDR.Item("Order_Entry_Note") = storeDR.Item("Order_Entry_Note").ToString

                    If Not IsDBNull(storeDR.Item("Is_Print_Order_Note")) Then
                        detailDR.Item("Is_Print_Order_Note") = CType(storeDR.Item("Is_Print_Order_Note"), String).Trim
                    Else
                        detailDR.Item("Is_Print_Order_Note") = "N"
                    End If

                    'Exclusive_Order_Code ?_?


                    uiToSheetDetailDT.Rows.Add(detailDR)

                    Dim defaultMBSC As String = ""
                    If Not IsDBNull(storeDR.Item("Default_Main_Body_Site_Code")) Then
                        defaultMBSC = CType(storeDR.Item("Default_Main_Body_Site_Code"), String).Trim

                        If defaultMBSC IsNot Nothing AndAlso defaultMBSC.Length > 0 Then
                            Dim sheetGdr As DataRow = sheetGroupDT.NewRow
                            sheetGdr.Item("Sheet_Group") = defaultMBSC
                            sheetGdr.Item("Sheet_Code") = nowSheetCode
                            sheetGdr.Item("Order_Code") = orderCode

                            If bodySiteHash.ContainsKey(defaultMBSC) Then
                                sheetGdr.Item("Sheet_Group_Name") = CType(bodySiteHash.Item(defaultMBSC), String).Trim
                            End If

                            sheetGdr.Item("Is_Custom_Group") = "N"

                            sheetGroupDT.Rows.Add(sheetGdr)
                        End If

                    End If

                End If

            Next

            sheetAndGroupDS.Tables.Add(uiToSheetDetailDT)
            sheetAndGroupDS.Tables.Add(sheetGroupDT)

            Return sheetAndGroupDS

        Else
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' pop出sheet_detail內函order的異動資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function modifyOrderData() As DataTable

        Dim modifyOrderDT As DataTable = DataSetUtil.createDataTable("order", Nothing, updateOrderColumn, updateOrderColumnType)

        Dim gridDS As DataSet = ucl_dgv_detail.GetDBDS.Copy
        If DataSetUtil.IsContainsData(gridDS) Then

            Dim nowSheetCode As String = ucl_comb_sheetcode.SelectedValue.Trim
            For Each dr As DataRow In gridDS.Tables(0).Rows
                Dim detailkey As String = nowSheetCode & "-" & CType(dr.Item(SheetDetailColumn(0)), String).Trim
                If SheetDetailHash.ContainsKey(detailkey) Then
                    Dim storeDR As DataRow = CType(SheetDetailHash.Item(detailkey), DataRow)

                    'modifyOrderDT
                    If (Not IsDBNull(storeDR.Item(updateOrderColumn(0)))) AndAlso (Not IsDBNull(storeDR.Item(updateOrderColumn(1)))) Then
                        Dim modOrderDR As DataRow = modifyOrderDT.NewRow
                        modOrderDR.Item(updateOrderColumn(0)) = CType(storeDR.Item(updateOrderColumn(0)), String).Trim
                        modOrderDR.Item(updateOrderColumn(1)) = CType(storeDR.Item(updateOrderColumn(1)), Date)

                        modOrderDR.Item(updateOrderColumn(2)) = loginUser

                        If (Not IsDBNull(storeDR.Item(updateOrderColumn(3)))) Then
                            modOrderDR.Item(updateOrderColumn(3)) = CType(storeDR.Item(updateOrderColumn(3)), String).Trim
                        Else
                            modOrderDR.Item(updateOrderColumn(3)) = "N"
                        End If
                        If (Not IsDBNull(storeDR.Item(updateOrderColumn(4)))) Then
                            modOrderDR.Item(updateOrderColumn(4)) = CType(storeDR.Item(updateOrderColumn(4)), String).Trim
                        Else
                            modOrderDR.Item(updateOrderColumn(4)) = ""
                        End If
                        If (Not IsDBNull(storeDR.Item(updateOrderColumn(5)))) Then
                            modOrderDR.Item(updateOrderColumn(5)) = CType(storeDR.Item(updateOrderColumn(5)), String).Trim
                        Else
                            modOrderDR.Item(updateOrderColumn(5)) = ""
                        End If

                        modifyOrderDT.Rows.Add(modOrderDR)
                    End If

                End If

            Next
        End If

        Return modifyOrderDT

    End Function

    ''' <summary>
    ''' pop出sheet_detail內函order_exam的異動資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function modifyOrderExaminationData() As DataTable

        '{"Order_Code", "Modified_User", "Default_Main_Body_Site_Code", "Default_Body_Site_Code", "Default_Side_Id", "Is_Scheduled", _
        ' "Is_Print_Order_Note", "Is_Main_Body_Site", "Is_Body_Site", "Is_Side_Id", "Is_PACS", "Is_With_Contrast"}

        Dim modifyOrderExamDT As DataTable = DataSetUtil.createDataTable("orderexam", Nothing, updateOrderExaminationColumn, updateOrderExaminationColumnType)

        Dim gridDS As DataSet = ucl_dgv_detail.GetDBDS.Copy
        If DataSetUtil.IsContainsData(gridDS) Then

            Dim nowSheetCode As String = ucl_comb_sheetcode.SelectedValue.Trim
            For Each dr As DataRow In gridDS.Tables(0).Rows
                Dim detailkey As String = nowSheetCode & "-" & CType(dr.Item(SheetDetailColumn(0)), String).Trim
                If SheetDetailHash.ContainsKey(detailkey) Then
                    Dim storeDR As DataRow = CType(SheetDetailHash.Item(detailkey), DataRow)

                    'modifyOrderExamDT
                    If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(0)))) Then
                        Dim modOrderExamDR As DataRow = modifyOrderExamDT.NewRow
                        modOrderExamDR.Item(updateOrderExaminationColumn(0)) = CType(storeDR.Item(updateOrderExaminationColumn(0)), String).Trim

                        modOrderExamDR.Item(updateOrderExaminationColumn(1)) = loginUser


                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(2)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(2)) = CType(storeDR.Item(updateOrderExaminationColumn(2)), String).Trim
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(2)) = ""
                        End If

                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(3)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(3)) = CType(storeDR.Item(updateOrderExaminationColumn(3)), String).Trim
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(3)) = ""
                        End If

                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(4)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(4)) = CType(storeDR.Item(updateOrderExaminationColumn(4)), String).Trim
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(4)) = ""
                        End If

                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(5)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(5)) = CType(storeDR.Item(updateOrderExaminationColumn(5)), String).Trim
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(5)) = "N"
                        End If
                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(6)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(6)) = CType(storeDR.Item(updateOrderExaminationColumn(6)), String).Trim
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(6)) = "N"
                        End If



                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(7)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(7)) = CType(storeDR.Item(updateOrderExaminationColumn(7)), String).Trim
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(7)) = "N"
                        End If
                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(8)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(8)) = CType(storeDR.Item(updateOrderExaminationColumn(8)), String).Trim
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(8)) = "N"
                        End If
                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(9)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(9)) = CType(storeDR.Item(updateOrderExaminationColumn(9)), String).Trim
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(9)) = "N"
                        End If
                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(10)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(10)) = CType(storeDR.Item(updateOrderExaminationColumn(10)), String).Trim
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(10)) = "N"
                        End If
                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(11)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(11)) = CType(storeDR.Item(updateOrderExaminationColumn(11)), String).Trim
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(11)) = "N"
                        End If

                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(12)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(12)) = CType(storeDR.Item(updateOrderExaminationColumn(12)), Decimal)
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(12)) = 0
                        End If

                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(13)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(13)) = CType(storeDR.Item(updateOrderExaminationColumn(13)), Decimal)
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(13)) = 0
                        End If

                        If (Not IsDBNull(storeDR.Item(updateOrderExaminationColumn(14)))) Then
                            modOrderExamDR.Item(updateOrderExaminationColumn(14)) = CType(storeDR.Item(updateOrderExaminationColumn(14)), Decimal)
                        Else
                            modOrderExamDR.Item(updateOrderExaminationColumn(14)) = 0
                        End If

                        '健保申報部位
                        modOrderExamDR.Item(updateOrderExaminationColumn(15)) = storeDR.Item(updateOrderExaminationColumn(15)).ToString.TrimEnd

                        '開立醫令即報到
                        modOrderExamDR.Item(updateOrderExaminationColumn(16)) = storeDR.Item(updateOrderExaminationColumn(16)).ToString.TrimEnd

                        '不列印檢查單
                        modOrderExamDR.Item(updateOrderExaminationColumn(17)) = storeDR.Item(updateOrderExaminationColumn(17)).ToString.TrimEnd

                        modifyOrderExamDT.Rows.Add(modOrderExamDR)
                    End If

                End If

            Next
        End If

        Return modifyOrderExamDT

    End Function


    Private Sub sheetCodeChanged()

        ucl_txt_sheetname.Focus()

        If ucl_comb_sheetcode.SelectedIndex > 0 Then

            Dim selectKey As String = ucl_comb_sheetcode.SelectedValue
            'SheetHash
            If SheetHash.ContainsKey(selectKey) Then
                sheetDataToUI(CType(SheetHash.Item(selectKey), DataRow))
            Else
                '清空
                sheetDataToUI(Nothing)
            End If

        End If
    End Sub

    '-------------------------------------------------------------------------

    Private Function checkGridDataComplete() As Boolean
        Dim gridDS As DataSet = ucl_dgv_detail.GetDBDS

        If DataSetUtil.IsContainsData(gridDS) Then
            'has data
            For Each dr As DataRow In gridDS.Tables(0).Rows
                'SheetDetailColumn "醫令代碼", "名稱", "排序", "單獨拆單註記", "明細"}
                If (Not IsDBNull(dr.Item(SheetDetailColumn(0)))) AndAlso (Not IsDBNull(dr.Item(SheetDetailColumn(1)))) AndAlso (Not IsDBNull(dr.Item(SheetDetailColumn(2)))) Then

                    If CType(dr.Item(SheetDetailColumn(0)), String).Trim.Equals("") Or CType(dr.Item(SheetDetailColumn(1)), String).Trim.Equals("") Or (Not (CType(dr.Item(SheetDetailColumn(2)), Integer) > 0)) Then
                        Return False
                    Else
                        Return True
                    End If

                Else
                    'MessageHandling.showInfoByKey("CMMCMMB001")
                    Return False
                End If
            Next
        Else
            'no data
            Return True
        End If

    End Function

    Private Sub addRow()
        '先檢查資料完整
        If checkGridDataComplete() Then
            ucl_dgv_detail.Visible = False

            ucl_dgv_detail.AddNewRow()
            'Dim detailDS As DataSet = ucl_dgv_detail.GetDBDS.Copy
            'detailDS.Tables(0).Rows(detailDS.Tables(0).Rows.Count - 1).Item(RuleDetailColumn(12)) = maxSeqNo + 1
            'detailDS.Tables(0).Rows(detailDS.Tables(0).Rows.Count - 1).Item(RuleDetailColumn(13)) = "Y"
            'ucl_dgv_detail.SetDS(detailDS)

            ucl_dgv_detail.uclColumnWidth = "190,467,100,150,100,0" '1007

            ucl_dgv_detail.Visible = True
        Else
            'MessageHandling.showError("表單細項資料不完整")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMB300", New String() {"表單細項資料不完整"}, "")
        End If

    End Sub

    Private Sub deleteRow()

        Dim detailDS As DataSet = ucl_dgv_detail.GetDBDS.Copy
        If DataSetUtil.IsContainsData(detailDS) Then
            Dim selectedIndex() As Integer = ucl_dgv_detail.GetSelectedIndex

            If selectedIndex IsNot Nothing AndAlso selectedIndex.Length > 0 Then

                Dim unselectedIndex() As Integer = ucl_dgv_detail.GetUnSelectedIndex
                detailDS.Tables(0).Clear()

                If unselectedIndex IsNot Nothing AndAlso unselectedIndex.Length > 0 Then

                    For i As Integer = 0 To (unselectedIndex.Length - 1)
                        detailDS.Tables(0).Rows.Add(ucl_dgv_detail.GetDBDS.Tables(0).Rows(unselectedIndex(i)).ItemArray)
                    Next

                Else
                    '全刪了
                End If

                ucl_dgv_detail.Visible = False

                ucl_dgv_detail.SetDS(detailDS)

                ucl_dgv_detail.uclColumnWidth = "190,467,100,150,100,0" '1007

                ucl_dgv_detail.Visible = True

                'MessageHandling.showInfo("刪除完畢")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showInfoMsg("CMMCMMB300", New String() {"刪除完畢"})

            Else
                '尚未選擇
                'MessageHandling.showError("尚未勾選刪除項目")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showErrorMsg("CMMCMMB300", New String() {"尚未勾選刪除項目"}, "")
            End If
        Else
            'MessageHandling.showError("無可刪除項目")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMB300", New String() {"無可刪除項目"}, "")
        End If

    End Sub

    Private Sub popSheetDetail(ByRef rowIndex As Integer, ByRef columnIndex As Integer)

        If rowIndex > -1 AndAlso columnIndex = 4 Then

            Dim gridDS As DataSet = ucl_dgv_detail.GetDBDS
            If DataSetUtil.IsContainsData(gridDS) Then
                If gridDS.Tables(0).Rows.Count > rowIndex Then
                    If ucl_comb_sheetcode.SelectedIndex > 0 Then
                        '"醫令代碼", "名稱", "排序", "單獨拆單註記", "明細"
                        If Not IsDBNull(gridDS.Tables(0).Rows(rowIndex).Item(SheetDetailColumn(0))) Then
                            Dim orderCode As String = CType(gridDS.Tables(0).Rows(rowIndex).Item(SheetDetailColumn(0)), String).Trim
                            Dim key As String = CType(ucl_comb_sheetcode.SelectedValue, String).Trim & "-" & orderCode

                            If SheetDetailHash.ContainsKey(key) Then

                                Dim toDetailNewDR As DataRow = CType(SheetDetailHash.Item(key), DataRow)

                                If toDetailNewDR IsNot Nothing Then
                                    Dim detailUI As PUBRisDetailMaintainUI = New PUBRisDetailMaintainUI(toDetailNewDR, SheetDT, BodySiteDT, SideDT)
                                    Dim result As Boolean = detailUI.ShowAndPrepareReturnData()

                                    '-----------------------------------------------------------------
                                    '確認
                                    '-----------------------------------------------------------------

                                    If result Then
                                        '友確認
                                        SheetDetailHash.Item(key) = detailUI.detailDR
                                    Else
                                        '不變動
                                    End If

                                Else
                                    '資料失敗
                                    'MessageHandling.showError("明細資料錯誤")
                                    '********************2010/2/9 Modify By Alan**********************
                                    MessageHandling.showErrorMsg("CMMCMMB300", New String() {"明細資料錯誤"}, "")
                                End If
                            Else
                                '無符合資料,新增
                                Dim detailUI As PUBRisDetailMaintainUI = New PUBRisDetailMaintainUI(Nothing, SheetDT, BodySiteDT, SideDT)
                                detailUI.ShowAndPrepareReturnData()
                            End If

                        End If
                        '重整排序
                    Else
                        'ucl_comb_sheetcode 錯誤
                        'TODO ㄧ個檢核欄位機制
                        'MessageHandling.showError("尚未選擇表單代碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.showErrorMsg("CMMCMMB300", New String() {"尚未選擇表單代碼"}, "")
                        ucl_comb_sheetcode.Focus()
                    End If
                End If
            End If
        Else
            'do nothing
        End If

    End Sub


    ''' <summary>
    ''' 更新序號 check to seq
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub refreshSequenceNo()
        Dim orderSeqHash As New Hashtable
        Dim seq As Integer = 0

        Dim detailDS As DataSet = ucl_dgv_detail.GetDBDS.Copy
        If DataSetUtil.IsContainsData(detailDS) Then
            For i As Integer = 0 To (detailDS.Tables(0).Rows.Count - 1)

                If Not IsDBNull(detailDS.Tables(0).Rows(i).Item(SheetDetailColumn(3))) Then
                    '
                Else
                    detailDS.Tables(0).Rows(i).Item(SheetDetailColumn(3)) = "N"
                End If

                Dim orderCode As String = CType(detailDS.Tables(0).Rows(i).Item(SheetDetailColumn(0)), String).Trim

                If CType(detailDS.Tables(0).Rows(i).Item(SheetDetailColumn(3)), String).Trim.Equals("Y") Then

                    seq = seq + 1

                    If Not orderSeqHash.ContainsKey(orderCode) Then
                        orderSeqHash.Add(orderCode, seq)
                    End If
                Else
                    '不拆單
                End If

            Next

            'process

            For Each dr As DataRow In detailDS.Tables(0).Rows

                If Not IsDBNull(dr.Item(SheetDetailColumn(0))) Then
                    Dim orderCode As String = CType(dr.Item(SheetDetailColumn(0)), String).Trim
                    If orderSeqHash.ContainsKey(orderCode) Then
                        dr.Item(SheetDetailColumn(5)) = CType(orderSeqHash.Item(orderCode), Integer)
                    Else
                        dr.Item(SheetDetailColumn(5)) = 0
                    End If
                Else

                End If

                If Not IsDBNull(dr.Item(SheetDetailColumn(5))) Then
                    If CType(dr.Item(SheetDetailColumn(5)), Integer) = 0 Then
                        dr.Item(SheetDetailColumn(3)) = "N"
                    Else
                        dr.Item(SheetDetailColumn(3)) = "Y"
                    End If
                End If

            Next

            'detailDS
            setDSAndRefresh(detailDS)

        Else
            '無資料
        End If


    End Sub

    'Private Sub refreshDivideList()

    '    '1.勾選拆單 自己一個號
    '    Dim detailDS As DataSet = ucl_dgv_detail.GetDBDS.Copy
    '    If DataSetUtil.IsContainsData(detailDS) Then

    '        For Each dr As DataRow In detailDS.Tables(0).Rows

    '            If Not IsDBNull(dr.Item(SheetDetailColumn(5))) Then
    '                If CType(dr.Item(SheetDetailColumn(5)), Integer) = 0 Then
    '                    dr.Item(SheetDetailColumn(3)) = "N"
    '                Else
    '                    dr.Item(SheetDetailColumn(3)) = "Y"
    '                End If
    '            End If
    '        Next

    '        setDSAndRefresh(detailDS)
    '    Else
    '        '無資料
    '    End If

    'End Sub

    Private Sub setDSAndRefresh(ByRef detailDS As DataSet)
        'detailDS
        ucl_dgv_detail.Visible = False
        ucl_dgv_detail.SetDS(detailDS)
        ucl_dgv_detail.uclColumnWidth = gblColumnWidth
        ucl_dgv_detail.Visible = True
    End Sub

    Private Function confirm() As Boolean


        Try
            ScreenUtil.Lock(Me)
            MessageHandling.clearInfoMsg()
            '若有勾選拆單註記，進行拆單，更新SequenceNo
            refreshSequenceNo()

            'TODO : check data complete?
            'sheet > uitosheet
            'sheetdetail > uitosheetdetail
            'update order, order_exam > uitoorder, uitoorderexam
            '
            Dim uiSheet As DataTable = uiToSheetData()
            If DataSetUtil.IsContainsData(uiSheet) Then


                If checkGridDataComplete() Then
                    Dim sheetConfirmDS As New DataSet
                    sheetConfirmDS.Tables.Add(uiSheet)

                    Dim uiSheetDetailAndGroupDS As DataSet = uiToSheetDetailAndGroupData()
                    If DataSetUtil.IsContainsData(uiSheetDetailAndGroupDS) Then

                        'uiSheetDetail
                        'PUB_Sheet_Group

                        If uiSheetDetailAndGroupDS.Tables.Contains(PubSheetDetailDataTableFactory.tableName) Then
                            sheetConfirmDS.Tables.Add(uiSheetDetailAndGroupDS.Tables(PubSheetDetailDataTableFactory.tableName).Copy)
                        End If

                        If uiSheetDetailAndGroupDS.Tables.Contains(PubSheetGroupDataTableFactory.tableName) Then
                            sheetConfirmDS.Tables.Add(uiSheetDetailAndGroupDS.Tables(PubSheetGroupDataTableFactory.tableName).Copy)
                        End If

                    End If

                    'modify order 
                    Dim modifyOrderDT As DataTable = modifyOrderData()
                    If DataSetUtil.IsContainsData(modifyOrderDT) Then
                        sheetConfirmDS.Tables.Add(modifyOrderDT)
                    End If
                    'modify order_exam
                    Dim modifyOrderExamDT As DataTable = modifyOrderExaminationData()
                    If DataSetUtil.IsContainsData(modifyOrderExamDT) Then
                        sheetConfirmDS.Tables.Add(modifyOrderExamDT)
                    End If

                    Dim result As Boolean = pub.confirmSheetData(sheetConfirmDS)

                    If result Then
                        'MessageHandling.showInfo("確認成功")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.showInfoMsg("CMMCMMB300", New String() {"確認成功"})
                    Else
                        'MessageHandling.showError("確認失敗")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.showErrorMsg("CMMCMMB300", New String() {"確認失敗"}, "")
                    End If
                Else
                    'MessageHandling.showError("表單細項資料不完整")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showErrorMsg("CMMCMMB300", New String() {"表單細項資料不完整"}, "")
                End If



            Else
                'MessageHandling.showError("無需確認的資料")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showErrorMsg("CMMCMMB300", New String() {"無需確認的資料"}, "")
                Return False
            End If



            '----
            Dim sheetDS As DataSet = pub.initSheetData()

            If DataSetUtil.IsContainsData(sheetDS) Then

                SheetHash.Clear()

                'BodySiteDT
                If sheetDS.Tables.Contains(PubSheetDataTableFactory.tableName) Then
                    SheetDT = sheetDS.Tables(PubSheetDataTableFactory.tableName).Copy
                    Dim combDT As DataTable = DataSetUtil.createDataTable("sheet", Nothing, ComboBoxColumn, ComboBoxColumnType)

                    setSheetHash(sheetDS, combDT)

                    initcboSheetCode()
                End If

            End If

            'MessageHandling.showInfoByKey("CMMCMMB015")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showInfoMsg("CMMCMMB015", New String() {})

        Catch ex As Exception
        
        Finally
            ScreenUtil.UnLock(Me)
        End Try

    End Function

    Private Sub clear()
        '表示青空
        ucl_comb_sheetcode.SelectedIndex = -1
        ucl_txt_sheetname.Text = ""
        cb_emgsheet.Checked = False
        'btn_indication.Enabled = False
        cb_printindication.Checked = False
        ucl_txt_connecttel.Text = ""
        ucl_rt_msg.Text = ""
        ucl_comb_exedept.SelectedIndex = -1

        ucl_dgv_detail.ClearDS()

        SheetDetailHash.Clear()

        ucl_comb_sheetcode.Focus()
    End Sub

    Private Sub popIndication()
        'If ucl_comb_sheetcode.SelectedIndex > 0 Then
        '    Dim indicationUI As PUBIndicationUI = New PUBIndicationUI
        '    indicationUI.sheetCode = ucl_comb_sheetcode.SelectedValue.Trim
        '    indicationUI.ShowDialog()
        'Else
        '    ucl_comb_sheetcode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    ucl_comb_sheetcode.Focus()
        '    'MessageHandling.showErrorByKey("CMMCMMB009")
        '    '********************2010/2/9 Modify By Alan**********************
        '    MessageHandling.showErrorMsg("CMMCMMB009", New String() {}, "")
        'End If
    End Sub

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBRisFormMaintainUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.F12
                confirm()
            Case Keys.Enter
                'sheetCodeChanged() 'Disabled on 2011-4-19
        End Select
    End Sub

    Private Sub ucl_comb_sheetcode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ucl_comb_sheetcode.SelectedIndexChanged
        sheetCodeChanged()
    End Sub

    Private Sub ucl_dgv_detail_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ucl_dgv_detail.CellClick
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 4 Then
                popSheetDetail(e.RowIndex, e.ColumnIndex)
            End If

        End If


    End Sub

    'Private Sub btn_addrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addrow.Click
    '    addRow()
    'End Sub

    Private Sub btn_removerow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_removerow.Click
        deleteRow()
    End Sub

    Private Sub btn_confirm_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        Dim isValid As Boolean = checkHasNeededParameter()
        If isValid Then
            confirm()
        End If
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        clear()
    End Sub

#End Region


    Private Sub btn_indication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_indication.Click
        popIndication()
    End Sub

    Private Sub btn_Insert_Click() Handles btn_Insert.Click
        Dim sheetCode As String = StringUtil.nvl(ucl_comb_sheetcode.Text.Trim)
        Dim isValid As Boolean = checkHasNeededParameter()
        If isValid Then
            'SheetHash
            If SheetHash.ContainsKey(sheetCode) Then
                sheetDataToUI(CType(SheetHash.Item(sheetCode), DataRow))
            Else
                If MessageHandling.ShowQuestionMsg("CMMCMMB300", New String() {"查無此表單編號，是否新增表單?"}) = Windows.Forms.DialogResult.Yes Then
                    InsertPubSheet()
                Else
                    sheetDataToUI(Nothing)
                    sheetDetailToGrid(Nothing)
                End If
                '清空
            End If
        Else
            sheetDataToUI(Nothing)
            sheetDataToUI(Nothing)
        End If
    End Sub

    Private Function getPubSheetDataset() As DataSet
        Dim ds As New DataSet("Pub_Sheet")
        Dim dt As DataTable = PubSheetDataTableFactory.getDataTable
        Dim dr As DataRow = dt.NewRow()
        dr.Item("Sheet_Code") = IIf(StringUtil.nvl(ucl_comb_sheetcode.SelectedValue).Length > 0, StringUtil.nvl(ucl_comb_sheetcode.SelectedValue), StringUtil.nvl(ucl_comb_sheetcode.Text))
        dr.Item("Sheet_Name") = StringUtil.nvl(ucl_txt_sheetname.Text).Trim
        dr.Item("Dept_Code") = ucl_comb_exedept.SelectedValue
        dr.Item("Is_Emergency_Sheet") = "N"
        dr.Item("Is_Indication") = "N"
        dr.Item("Is_Print_Indication") = "N"
        dr.Item("Sheet_Collect_Note") = DBNull.Value
        dr.Item("Sheet_Note") = StringUtil.nvl(ucl_rt_msg.Text).Trim
        dr.Item("Sheet_Type_Id") = "2"
        dr.Item("Lis_Sheet_Limit_Cnt") = "0"
        dr.Item("Sheet_Sort_Value") = "0"
        dr.Item("Dc") = "N"
        dr.Item("Create_User") = loginUser
        dr.Item("Create_Time") = Now
        dr.Item("Modified_User") = DBNull.Value
        dr.Item("Modified_Time") = DBNull.Value
        dr.Item("Is_Print") = "N"
        dr.Item("Lab_Group_Id") = DBNull.Value
        dr.Item("Report_Title") = DBNull.Value
        dr.Item("Sheet_Short_Name") = DBNull.Value
        dr.Item("Finish_Sign_Hours") = DBNull.Value
        dr.Item("Finish_Rpt_Hours") = DBNull.Value
        dt.Rows.Add(dr)
        ds.Tables.Add(dt)
        Return ds
    End Function

    Private Sub InsertPubSheet()
        Dim count As Int32 = 0
        Dim ds As DataSet = getPubSheetDataset()
        If CheckMethodUtil.CheckHasValue(ds) Then
            count = pub.PubLisSheetInsert(ds)
            '若新增成功，開啟明細畫面
            If count > 0 Then
                Dim ui As New PUBRisFormMaintainSheetDetailUI
                ui.ShowDialog()
                initcboSheetCode()
            End If
        End If
    End Sub

    Private Function checkHasNeededParameter() As Boolean
        Dim sheetCode As String = StringUtil.nvl(ucl_comb_sheetcode.Text.Trim)
        Dim sheetName As String = StringUtil.nvl(ucl_txt_sheetname.Text.Trim)
        Dim returnBoolean As Boolean = True
        Dim strBuilder As New StringBuilder
        If Not sheetCode.Length > 0 Then
            returnBoolean = False
            strBuilder.Append("表單代碼、")
        End If
        If Not sheetName.Length > 0 Then
            returnBoolean = False
            strBuilder.Append("表單名稱、")
        End If
        If strBuilder.Length > 0 Then
            strBuilder.ToString(0, strBuilder.Length - 1)
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"請選擇" & strBuilder.ToString}, "")
        End If
        Return returnBoolean
    End Function

    Private Sub setSheetHash(ByVal ds As DataSet, ByVal combDT As DataTable)
        If DataSetUtil.IsContainsData(ds) Then
            For Each dr As DataRow In ds.Tables(0).Rows
                Dim combdr As DataRow = combDT.NewRow
                combdr.Item(ComboBoxColumn(0)) = CType(dr.Item("Sheet_Code"), String).Trim
                combdr.Item(ComboBoxColumn(1)) = CType(dr.Item("Sheet_Name"), String).Trim

                combDT.Rows.Add(combdr)

                SheetHash.Add(CType(dr.Item("Sheet_Code"), String).Trim, dr)
            Next
        End If
    End Sub

    Private Sub initcboSheetCode()
        Dim sheetTypeId As String = "2"
        Dim whereClause As String = "Sheet_Type_Id='" & sheetTypeId & "'"
        Dim orderByClause As String = "Dept_Code asc"
        Dim dtSheetCode As DataTable = pub.queryPUBSheet().Tables(0).Select(whereClause, orderByClause).CopyToDataTable
        If DataSetUtil.IsContainsData(dtSheetCode) Then
            ucl_comb_sheetcode.DataSource = dtSheetCode
            ucl_comb_sheetcode.uclValueIndex = "0"
            ucl_comb_sheetcode.uclDisplayIndex = "0,1"
        End If
    End Sub
End Class
