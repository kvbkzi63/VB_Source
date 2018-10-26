Imports Com.Syscom.WinFormsUI.Docking

Imports System.Text

Imports log4net
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM


Public Class PUBRisDetailMaintainUI


    '============================
    '程式說明：檢查醫令明細維護
    '修改日期：2009.12.03
    '修改日期：2009.12.03
    '開發人員：Jen
    '============================

    Public Sub New(ByVal initDetailDR As DataRow, ByVal initSheetDT As DataTable, ByVal initBodySiteDT As DataTable, ByVal initSideDT As DataTable)

        detailDR = initDetailDR

        sheetDT = initSheetDT
        bodySiteDT = initBodySiteDT
        sideDT = initSideDT

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub


#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    'Dim pub As PUBDelegate = PUBDelegate.getInstance

    Dim ErrorKeyFlag As Boolean = False

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Private confirmFlag As Boolean = False

    Private sheetDT As DataTable = Nothing
    Private bodySiteDT As DataTable = Nothing
    Private sideDT As DataTable = Nothing

    Private sheetdetailDR As DataRow = Nothing

    Public Property detailDR() As DataRow
        Get
            Return sheetdetailDR
        End Get
        Set(ByVal value As DataRow)
            sheetdetailDR = value
        End Set
    End Property

    Private Property RegistOnOrdering() As String
        Get
            If Me.chk_RegistOnOrdering.Checked Then
                Return "Y"
            Else
                Return "N"
            End If
        End Get
        Set(ByVal value As String)
            If value.ToUpper = "Y" Then
                Me.chk_RegistOnOrdering.Checked = True
            Else
                Me.chk_RegistOnOrdering.Checked = False
            End If
        End Set
    End Property

    Private Property IsNoPrint() As String
        Get
            If Me.chk_IsNoPrint.Checked Then
                Return "Y"
            Else
                Return "N"
            End If
        End Get
        Set(ByVal value As String)
            If value.ToUpper = "Y" Then
                Me.chk_IsNoPrint.Checked = True
            Else
                Me.chk_IsNoPrint.Checked = False
            End If
        End Set
    End Property
#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBRisDetailMaintainUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        loadPubServiceManager()

        '開啟keypreview
        Me.KeyPreview = True

        '隸屬表單不可編輯
        ucl_sheetbelong.Enabled = False

        '表單
        Dim sheetCombDT As DataTable = DataSetUtil.createDataTable("sheet", Nothing, ComboBoxColumn, ComboBoxColumnType)
        If DataSetUtil.IsContainsData(sheetDT) Then
            For Each dr As DataRow In sheetDT.Rows

                If (Not IsDBNull(dr.Item("Sheet_Code"))) AndAlso (Not IsDBNull(dr.Item("Sheet_Name"))) Then
                    Dim sheetdr As DataRow = sheetCombDT.NewRow
                    sheetdr.Item(ComboBoxColumn(0)) = CType(dr.Item("Sheet_Code"), String).Trim
                    sheetdr.Item(ComboBoxColumn(1)) = CType(dr.Item("Sheet_Name"), String).Trim
                    sheetCombDT.Rows.Add(sheetdr)
                End If

            Next
        End If
        ucl_sheetbelong.DataSource = sheetCombDT
        ucl_sheetbelong.uclValueIndex = "0"
        ucl_sheetbelong.uclDisplayIndex = "1"

        '部位
        Dim bsiteCombDT As DataTable = DataSetUtil.createDataTable("ssite", Nothing, ComboBoxColumn, ComboBoxColumnType)
        If DataSetUtil.IsContainsData(bodySiteDT) Then

            Dim bsiteDr() As DataRow = bodySiteDT.Select(" Dc <> 'Y' and Main_Body_Site_Code = Body_Site_Code ", "Body_Site_Code")

            If bsiteDr IsNot Nothing AndAlso bsiteDr.Length > 0 Then
                For Each dr As DataRow In bsiteDr
                    If (Not IsDBNull(dr.Item("Body_Site_Code"))) AndAlso (Not IsDBNull(dr.Item("Body_Site_Name"))) Then
                        Dim sitedr As DataRow = bsiteCombDT.NewRow
                        sitedr.Item(ComboBoxColumn(0)) = CType(dr.Item("Body_Site_Code"), String).Trim
                        sitedr.Item(ComboBoxColumn(1)) = CType(dr.Item("Body_Site_Name"), String).Trim
                        bsiteCombDT.Rows.Add(sitedr)
                    End If
                Next
            End If

        End If
        ucl_comb_bsite.DataSource = bsiteCombDT
        ucl_comb_bsite.uclValueIndex = "0"
        ucl_comb_bsite.uclDisplayIndex = "0,1"

        '測未
        Dim sideCombDT As DataTable = DataSetUtil.createDataTable("side", Nothing, ComboBoxColumn, ComboBoxColumnType)
        If DataSetUtil.IsContainsData(sideDT) Then
            For Each dr As DataRow In sideDT.Rows
                If (Not IsDBNull(dr.Item("Code_Id"))) AndAlso (Not IsDBNull(dr.Item("Code_Name"))) Then
                    Dim sidedr As DataRow = sideCombDT.NewRow
                    sidedr.Item(ComboBoxColumn(0)) = CType(dr.Item("Code_Id"), String).Trim
                    sidedr.Item(ComboBoxColumn(1)) = CType(dr.Item("Code_Name"), String).Trim
                    sideCombDT.Rows.Add(sidedr)
                End If
            Next
        End If
        ucl_comb_side.DataSource = sideCombDT
        ucl_comb_side.uclValueIndex = "0"
        ucl_comb_side.uclDisplayIndex = "0,1"


        'put資料入ui
        detailRowToUI()

        'setChkRegistOnOrderingStatus()
        If "Y".Equals(StringUtil.nvl(detailDR.Item("Is_No_Check_In"))) Then
            chk_RegistOnOrdering.Checked = True
        Else
            chk_RegistOnOrdering.Checked = False
        End If

        If "Y".Equals(StringUtil.nvl(detailDR.Item("Is_No_Print"))) Then
            chk_IsNoPrint.Checked = True
        Else
            chk_IsNoPrint.Checked = False
        End If

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
            MessageHandling.ShowInfoMsg("CMMCMMB001", New String() {})
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

    '----------------------------------------------------------------------------
    '用對話視窗方式開啟，不執行資料庫動作(存DataSet)
    '----------------------------------------------------------------------------
    ''' <summary>
    ''' 用dialog方式開啟
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ShowAndPrepareReturnData() As Boolean
        Me.ShowDialog()

        Return confirmFlag

    End Function

    Private Sub detailRowToUI()

        If detailDR IsNot Nothing Then
            If Not IsDBNull(detailDR.Item("Order_Code")) Then
                ucl_txt_ordercode.Text = CType(detailDR.Item("Order_Code"), String).Trim
            Else
                ucl_txt_ordercode.Text = ""
            End If

            If Not IsDBNull(detailDR.Item("Effect_Date")) Then
                ucl_dtp_enabledate.SetValue(CType(detailDR.Item("Effect_Date"), Date).ToString("yyyy/MM/dd"))
            Else

            End If

            If Not IsDBNull(detailDR.Item("End_Date")) Then
                ucl_dtp_disabledate.SetValue(CType(detailDR.Item("End_Date"), Date).ToString("yyyy/MM/dd"))
            Else

            End If

            If Not IsDBNull(detailDR.Item("Dc_Reason")) Then
                ucl_txt_dcreason.Text = CType(detailDR.Item("Dc_Reason"), String).Trim
            Else
                ucl_txt_dcreason.Text = ""
            End If

            If Not IsDBNull(detailDR.Item("Order_Name")) Then
                ucl_tst_Zh_name.Text = CType(detailDR.Item("Order_Name"), String).Trim
            Else
                ucl_tst_Zh_name.Text = ""
            End If

            'Added by Ken @2010-05-21
            If detailDR.Table.Columns.Contains("Order_Entry_Note") Then
                txt_OrderEntryNote.Text = detailDR("Order_Entry_Note").ToString
            End If

            If Not IsDBNull(detailDR.Item("Order_En_Name")) Then
                ucl_txt_En_name.Text = CType(detailDR.Item("Order_En_Name"), String).Trim
            Else
                ucl_txt_En_name.Text = ""
            End If

            If Not IsDBNull(detailDR.Item("Sheet_Code")) Then
                ucl_sheetbelong.SelectedValue = CType(detailDR.Item("Sheet_Code"), String).Trim
            Else
                ucl_sheetbelong.SelectedIndex = -1
            End If

            If Not IsDBNull(detailDR.Item("Default_Main_Body_Site_Code")) Then
                ucl_comb_bsite.SelectedValue = CType(detailDR.Item("Default_Main_Body_Site_Code"), String).Trim
                smallSiteComboBoxRefresh()

                If Not IsDBNull(detailDR.Item("Default_Body_Site_Code")) Then
                    ucl_comb_ssite.SelectedValue = CType(detailDR.Item("Default_Body_Site_Code"), String).Trim
                Else
                    ucl_comb_ssite.SelectedIndex = -1
                End If
            Else
                ucl_comb_bsite.SelectedIndex = -1
                ucl_comb_ssite.SelectedIndex = -1
            End If

            If Not IsDBNull(detailDR.Item("Default_Side_Id")) Then
                ucl_comb_side.SelectedValue = CType(detailDR.Item("Default_Side_Id"), String).Trim
            Else
                ucl_comb_side.SelectedIndex = -1
            End If

            If Not IsDBNull(detailDR.Item("Is_Scheduled")) Then
                If CType(detailDR.Item("Is_Scheduled"), String).Trim.Equals("Y") Then
                    cb_canscheduleflag.Checked = True
                Else
                    cb_canscheduleflag.Checked = False
                End If
            Else
                cb_canscheduleflag.Checked = False
            End If

            If Not IsDBNull(detailDR.Item("Is_Order_Check")) Then
                If CType(detailDR.Item("Is_Order_Check"), String).Trim.Equals("Y") Then
                    btn_ordercheck.Enabled = True
                Else
                    btn_ordercheck.Enabled = False
                End If
            Else
                btn_ordercheck.Enabled = False
            End If

            If Not IsDBNull(detailDR.Item("Is_Indication")) Then
                If CType(detailDR.Item("Is_Indication"), String).Trim.Equals("Y") Then
                    btn_orderindi.Enabled = True
                Else
                    btn_orderindi.Enabled = False
                End If
            Else
                btn_orderindi.Enabled = False
            End If

            If Not IsDBNull(detailDR.Item("Is_Print_Indication")) Then
                If CType(detailDR.Item("Is_Print_Indication"), String).Trim.Equals("Y") Then
                    cb_printindi.Checked = True
                Else
                    cb_printindi.Checked = False
                End If
            Else
                cb_printindi.Checked = False
            End If
            '

            If Not IsDBNull(detailDR.Item("Is_Print_Order_Note")) Then
                If CType(detailDR.Item("Is_Print_Order_Note"), String).Trim.Equals("Y") Then
                    cb_printapplynotif.Checked = True
                    'ucl_rt_notify.Enabled = True
                Else
                    cb_printapplynotif.Checked = False
                    'ucl_rt_notify.Enabled = False
                End If
            Else
                cb_printapplynotif.Checked = False
                'ucl_rt_notify.Enabled = False
            End If


            'Opd_Report_Time
            Dim opdRptTime As Decimal = 0
            If Not IsDBNull(detailDR.Item("Opd_Report_Time")) Then
                Try
                    opdRptTime = CType(detailDR.Item("Opd_Report_Time"), Decimal)
                Catch ex As Exception
                End Try
            Else

            End If
            ucl_txt_Orpttime.Text = opdRptTime


            'Emg_Report_Time
            Dim emgRptTime As Decimal = 0
            If Not IsDBNull(detailDR.Item("Emg_Report_Time")) Then
                Try
                    emgRptTime = CType(detailDR.Item("Emg_Report_Time"), Decimal)
                Catch ex As Exception
                End Try
            Else

            End If
            ucl_txt_Erpttime.Text = emgRptTime


            'Ipd_Report_Time
            Dim ipdRptTime As Decimal = 0
            If Not IsDBNull(detailDR.Item("Ipd_Report_Time")) Then
                Try
                    ipdRptTime = CType(detailDR.Item("Ipd_Report_Time"), Decimal)
                Catch ex As Exception
                End Try
            Else

            End If
            ucl_txt_Irpttime.Text = ipdRptTime


            If Not IsDBNull(detailDR.Item("Order_Note")) Then
                ucl_rt_notify.Text = CType(detailDR.Item("Order_Note"), String).Trim
            Else
                ucl_rt_notify.Text = ""
            End If

            If Not IsDBNull(detailDR.Item("Is_Main_Body_Site")) Then
                If CType(detailDR.Item("Is_Main_Body_Site"), String).Trim.Equals("Y") Then
                    cb_bsite_need.Checked = True
                Else
                    cb_bsite_need.Checked = False
                End If
            Else
                cb_bsite_need.Checked = False
            End If

            If Not IsDBNull(detailDR.Item("Is_Body_Site")) Then
                If CType(detailDR.Item("Is_Body_Site"), String).Trim.Equals("Y") Then
                    cb_ssite_need.Checked = True
                Else
                    cb_ssite_need.Checked = False
                End If
            Else
                cb_ssite_need.Checked = False
            End If

            If Not IsDBNull(detailDR.Item("Is_Side_Id")) Then
                If CType(detailDR.Item("Is_Side_Id"), String).Trim.Equals("Y") Then
                    cb_side_need.Checked = True
                Else
                    cb_side_need.Checked = False
                End If
            Else
                cb_side_need.Checked = False
            End If

            If Not IsDBNull(detailDR.Item("Is_PACS")) Then
                If CType(detailDR.Item("Is_PACS"), String).Trim.Equals("Y") Then
                    cb_transferPACS.Checked = True
                Else
                    cb_transferPACS.Checked = False
                End If
            Else
                cb_transferPACS.Checked = False
            End If

            If Not IsDBNull(detailDR.Item("Is_With_Contrast")) Then
                If CType(detailDR.Item("Is_With_Contrast"), String).Trim.Equals("Y") Then
                    cb_useCM.Checked = True
                Else
                    cb_useCM.Checked = False
                End If
            Else
                cb_useCM.Checked = False
            End If

            '健檢申報部位
            If detailDR.Table.Columns.Contains("Nhi_Body_Site_Code") Then
                txt_NhiBodySiteCode.Text = detailDR.Item("Nhi_Body_Site_Code").ToString.TrimEnd
            End If

            '開立醫令即報到
            Me.RegistOnOrdering = detailDR.Item("Is_No_Check_In").ToString.TrimEnd

            '不列印檢查單
            Me.IsNoPrint = detailDR.Item("Is_No_Print").ToString.TrimEnd
        Else
            '清空
        End If


    End Sub

    Private Sub UIToDetailRow()

        If detailDR IsNot Nothing Then

            If Not ucl_txt_dcreason.Text.Trim.Equals("") Then
                detailDR.Item("Dc_Reason") = ucl_txt_dcreason.Text
            Else
                detailDR.Item("Dc_Reason") = DBNull.Value
            End If

            If ucl_comb_bsite.SelectedIndex > 0 Then
                detailDR.Item("Default_Main_Body_Site_Code") = CType(ucl_comb_bsite.SelectedValue, String).Trim
                If ucl_comb_ssite.SelectedIndex > 0 Then
                    detailDR.Item("Default_Body_Site_Code") = CType(ucl_comb_ssite.SelectedValue, String).Trim
                Else
                    detailDR.Item("Default_Body_Site_Code") = DBNull.Value
                End If
            Else
                detailDR.Item("Default_Main_Body_Site_Code") = DBNull.Value
            End If

            If ucl_comb_side.SelectedIndex > 0 Then
                detailDR.Item("Default_Side_Id") = CType(ucl_comb_side.SelectedValue, String).Trim
            Else
                detailDR.Item("Default_Side_Id") = DBNull.Value
            End If

            If cb_canscheduleflag.Checked Then
                detailDR.Item("Is_Scheduled") = "Y"
            Else
                detailDR.Item("Is_Scheduled") = "N"
            End If

            If btn_orderindi.Enabled Then
                detailDR.Item("Is_Indication") = "Y"
            Else
                detailDR.Item("Is_Indication") = "N"
            End If

            If cb_printindi.Checked Then
                detailDR.Item("Is_Print_Indication") = "Y"
            Else
                detailDR.Item("Is_Print_Indication") = "N"
            End If

            If cb_printapplynotif.Checked Then
                detailDR.Item("Is_Print_Order_Note") = "Y"
            Else
                detailDR.Item("Is_Print_Order_Note") = "N"
            End If


            Dim orptTime As Decimal = 0
            If Not ucl_txt_Orpttime.Text.Trim.Equals("") Then
                Try
                    orptTime = Decimal.Parse(ucl_txt_Orpttime.Text.Trim)
                Catch ex As Exception
                End Try
            Else

            End If
            detailDR.Item("Opd_Report_Time") = orptTime

            Dim erptTime As Decimal = 0
            If Not ucl_txt_Erpttime.Text.Trim.Equals("") Then
                Try
                    erptTime = Decimal.Parse(ucl_txt_Erpttime.Text.Trim)
                Catch ex As Exception
                End Try
            Else

            End If
            detailDR.Item("Emg_Report_Time") = erptTime

            Dim irptTime As Decimal = 0
            If Not ucl_txt_Irpttime.Text.Trim.Equals("") Then
                Try
                    irptTime = Decimal.Parse(ucl_txt_Irpttime.Text.Trim)
                Catch ex As Exception
                End Try
            Else

            End If
            detailDR.Item("Ipd_Report_Time") = irptTime


            If Not ucl_rt_notify.Text.Trim.Equals("") Then
                detailDR.Item("Order_Note") = ucl_rt_notify.Text
            Else
                detailDR.Item("Order_Note") = DBNull.Value
            End If

            'Added by Ken @2010-05-21
            If detailDR.Table.Columns.Contains("Order_Entry_Note") Then
                detailDR("Order_Entry_Note") = txt_OrderEntryNote.Text
            End If

            If cb_bsite_need.Checked Then
                detailDR.Item("Is_Main_Body_Site") = "Y"
            Else
                detailDR.Item("Is_Main_Body_Site") = "N"
            End If

            If cb_ssite_need.Checked Then
                detailDR.Item("Is_Body_Site") = "Y"
            Else
                detailDR.Item("Is_Body_Site") = "N"
            End If

            If cb_side_need.Checked Then
                detailDR.Item("Is_Side_Id") = "Y"
            Else
                detailDR.Item("Is_Side_Id") = "N"
            End If

            If cb_transferPACS.Checked Then
                detailDR.Item("Is_PACS") = "Y"
            Else
                detailDR.Item("Is_PACS") = "N"
            End If

            If cb_useCM.Checked Then
                detailDR.Item("Is_With_Contrast") = "Y"
            Else
                detailDR.Item("Is_With_Contrast") = "N"
            End If

            '健保申報部位
            If detailDR.Table.Columns.Contains("Nhi_Body_Site_Code") Then
                detailDR("Nhi_Body_Site_Code") = txt_NhiBodySiteCode.Text.TrimEnd
            End If

            '開立醫令即報到
            detailDR("Is_No_Check_In") = Me.RegistOnOrdering

            '不列印檢查單
            detailDR("Is_No_Print") = Me.IsNoPrint
        Else
            'detail nothing
        End If


    End Sub

    ''' <summary>
    ''' 更新細部位
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub smallSiteComboBoxRefresh()
        If ucl_comb_bsite.SelectedIndex > 0 Then
            Dim bsiteCode As String = ucl_comb_bsite.SelectedValue.Trim

            Dim ssiteCombDT As DataTable = DataSetUtil.createDataTable("ssite", Nothing, ComboBoxColumn, ComboBoxColumnType)
            Dim ssiteDr() As DataRow = bodySiteDT.Select(" Dc <> 'Y' and Main_Body_Site_Code <> Body_Site_Code and Main_Body_Site_Code = '" & bsiteCode & "'", "Body_Site_Code")

            If ssiteDr IsNot Nothing AndAlso ssiteDr.Length > 0 Then
                For Each dr As DataRow In ssiteDr
                    If (Not IsDBNull(dr.Item("Body_Site_Code"))) AndAlso (Not IsDBNull(dr.Item("Body_Site_Name"))) Then
                        Dim sitedr As DataRow = ssiteCombDT.NewRow
                        sitedr.Item(ComboBoxColumn(0)) = CType(dr.Item("Body_Site_Code"), String).Trim
                        sitedr.Item(ComboBoxColumn(1)) = CType(dr.Item("Body_Site_Name"), String).Trim
                        ssiteCombDT.Rows.Add(sitedr)
                    End If
                Next
            End If

            ucl_comb_ssite.DataSource = ssiteCombDT
            ucl_comb_ssite.uclValueIndex = "0"
            ucl_comb_ssite.uclDisplayIndex = "0,1"

        Else
            ucl_comb_ssite.DataSource = Nothing
        End If
    End Sub

    Private Sub confirm()


        Try
            ScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()

            'set data to detailDR
            UIToDetailRow()
            confirmFlag = True

            'MessageHandling.showInfoByKey("CMMCMMB015")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowInfoMsg("CMMCMMB015", New String() {})

        Catch ex As Exception
        Finally
            ScreenUtil.UnLock(Me)
            Me.Dispose()
        End Try


    End Sub


    Private Sub popIndication()
        'If ucl_txt_ordercode.Text.Trim.Length > 0 Then
        '    Dim indicationUI As PUBIndicationUI = New PUBIndicationUI
        '    indicationUI.orderCode = ucl_txt_ordercode.Text.Trim
        '    indicationUI.ShowDialog()
        'Else
        '    ucl_txt_ordercode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
        '    ucl_txt_ordercode.Focus()
        '    'MessageHandling.showErrorByKey("CMMCMMB009")
        '    '********************2010/2/9 Modify By Alan**********************
        '    MessageHandling.ShowErrorMsg("CMMCMMB009", New String() {}, "")
        'End If
    End Sub

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBRisDetailMaintainUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.F10
                confirm()
        End Select
    End Sub

    ''' <summary>
    ''' 確認
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        confirm()
    End Sub

    Private Sub btn_confirm_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        confirm()
    End Sub

    Private Sub cb_printindi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_printindi.CheckedChanged
        If cb_printindi.Checked Then
            btn_orderindi.Enabled = True
        Else
            btn_orderindi.Enabled = False
        End If
    End Sub

    Private Sub ucl_comb_bsite_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ucl_comb_bsite.SelectedIndexChanged
        smallSiteComboBoxRefresh()
    End Sub

    Private Sub btn_orderindi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_orderindi.Click
        popIndication()
    End Sub

    Private Sub btn_OpenNoCheckinDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OpenNoCheckinDept.Click
        Dim ui As PubOrderExamNocheckinDeptUI = New PubOrderExamNocheckinDeptUI(StringUtil.nvl(ucl_txt_ordercode.Text))
        ui.ShowDialog()
        'setChkRegistOnOrderingStatus()
    End Sub

    Private Sub btn_OpenNoPrintDept_Click(sender As Object, e As EventArgs) Handles btn_OpenNoPrintDept.Click
        Dim ui As PubOrderExamNoPrintDeptUI = New PubOrderExamNoPrintDeptUI(StringUtil.nvl(ucl_txt_ordercode.Text))
        ui.ShowDialog()
    End Sub
#End Region

    Private Sub setChkRegistOnOrderingStatus()

        Dim ds As DataSet = pub.getInitialOrderExamNoCheckinDept(StringUtil.nvl(ucl_txt_ordercode.Text))

        Dim _dtERC_O As EnumerableRowCollection(Of DataRow) = ds.Tables(0).AsEnumerable
        Dim _dtERCControl_O As EnumerableRowCollection(Of DataRow) = _dtERC_O.Where(Function(r) (r("Order_Code").ToString.Trim <> ""))
        Dim _dtERC_E As EnumerableRowCollection(Of DataRow) = ds.Tables(1).AsEnumerable
        Dim _dtERCControl_E As EnumerableRowCollection(Of DataRow) = _dtERC_E.Where(Function(r) (r("Order_Code").ToString.Trim <> ""))
        Dim _dtERC_I As EnumerableRowCollection(Of DataRow) = ds.Tables(2).AsEnumerable
        Dim _dtERCControl_I As EnumerableRowCollection(Of DataRow) = _dtERC_I.Where(Function(r) (r("Order_Code").ToString.Trim <> ""))

        If CheckMethodUtil.CheckHasValue(ds) AndAlso _
            (_dtERCControl_O.Count > 0 OrElse _
            _dtERCControl_E.Count > 0 OrElse _
            _dtERCControl_I.Count > 0) Then
            chk_RegistOnOrdering.Checked = True
        Else
            chk_RegistOnOrdering.Checked = False
        End If
    End Sub


End Class
