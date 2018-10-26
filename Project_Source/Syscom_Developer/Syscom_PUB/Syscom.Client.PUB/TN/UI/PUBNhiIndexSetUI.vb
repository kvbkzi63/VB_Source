Imports Com.Syscom.WinFormsUI.Docking

Imports System.Text
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM

Public Class PUBNhiIndexSetUI


    '============================
    '程式說明：健保療程
    '修改日期：2009.09.30
    '修改日期：2009.09.30
    '開發人員：Jen
    '============================

    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Public Sub New(ByVal initOrderCode As String, ByVal initSyscode As DataTable, ByVal initNhiIndexDT As DataTable)

        OrderCode = initOrderCode
        SyscodeDT = initSyscode
        NhiIndexData = initNhiIndexDT

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    Dim ErrorKeyFlag As Boolean = False

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim NhiIndexColumn() As String = {"健保指標歸類項目", "Code_Id"}
    Dim NhiIndexColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim NhiIndexSetColumn() As String = {"Order_Code", "Nhi_Index_Type_Id"}
    Dim NhiIndexSetColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Private DialogFlag As Boolean = False
    Dim OrderCode As String = ""
    Private SyscodeDT As DataTable = Nothing
    Private NhiIndexDT As DataTable = Nothing

    Public Property NhiIndexData() As DataTable
        Get
            Return NhiIndexDT
        End Get
        Set(ByVal value As DataTable)
            NhiIndexDT = value
        End Set
    End Property

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBNhiIndexUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loadPubServiceManager()
        Me.KeyPreview = True
        ucl_dgv_list.uclHeaderText = UCL.UCLDataGridViewUC.convertColumnToHeader(NhiIndexColumn)
        ucl_dgv_list.uclColumnWidth = "380, 0" '380
        ucl_dgv_list.uclColumnAlignment = "0"
        ucl_dgv_list.uclNonVisibleColIndex = "2"


        'init Grid資料
        '----------------------------------------------
        Dim listDS As DataSet = New DataSet
        Dim listDT As DataTable = DataSetUtil.createDataTable("list", Nothing, NhiIndexColumn, NhiIndexColumnType)

        '初始
        'pub.....取得初始資料
        '510
        If Not DataSetUtil.IsContainsData(SyscodeDT) Then
            'Call WCF
            Dim typeId() As Integer = {510}
            SyscodeDT = pub.querySyscodeByTypeIds(typeId)
        End If

        Dim selectOutDRs() As DataRow

        '健保指標歸類項目
        selectOutDRs = SyscodeDT.Select(" Type_Id = 510 ")
        If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
            'uclcb_curetypeid.DataSource = createComboBoxTable("treatmenttype", selectOutDRs)
            'uclcb_curetypeid.uclValueIndex = "0"
            'uclcb_curetypeid.uclDisplayIndex = "0,1"
            For i As Integer = 0 To (selectOutDRs.Count - 1)
                Dim listdr As DataRow = listDT.NewRow
                listdr.Item(NhiIndexColumn(0)) = CType(selectOutDRs(i).Item("Code_Name"), String).Trim

                listdr.Item(NhiIndexColumn(1)) = CType(selectOutDRs(i).Item("Code_Id"), String).Trim
                listDT.Rows.Add(listdr)
            Next

        Else
            '
        End If

        listDS.Tables.Add(listDT)
        '----------------------------------------------

        ucl_dgv_list.Initial(listDS)

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
        DialogFlag = True
        Me.ShowDialog()

        Return True

    End Function

    Private Function confirm() As Boolean

        Dim selectedIndex() As Integer = ucl_dgv_list.GetSelectedIndex

        If selectedIndex IsNot Nothing AndAlso selectedIndex.Length > 0 Then
            '選
            ',[Order_Code]
            ',[Nhi_Index_Type_Id]

            Dim NhiDT As DataTable = DataSetUtil.createDataTable("nhiindex", Nothing, NhiIndexSetColumn, NhiIndexSetColumnType)
            Dim NhiDS As DataSet = ucl_dgv_list.GetDBDS.Copy
            If DataSetUtil.IsContainsData(NhiDS) Then
                For i As Integer = 0 To (NhiDS.Tables(0).Rows.Count - 1)
                    Dim nhidr As DataRow = NhiDT.NewRow
                    nhidr.Item(NhiIndexSetColumn(0)) = OrderCode
                    nhidr.Item(NhiIndexSetColumn(1)) = NhiDS.Tables(0).Rows(i).Item(NhiIndexColumn(1))

                    NhiDT.Rows.Add(nhidr)
                Next

                NhiIndexData = NhiDT
            Else
                NhiIndexData = Nothing
            End If

        Else
            '沒選
            NhiIndexData = Nothing
        End If

        ''check column
        ''if true do...
        ''塞值於DT中 供回傳
        'Dim CureTypeId As String = uclcb_curetypeid.SelectedValue
        'Dim TimeControlId As String = uclcb_timecontrolid.SelectedValue
        'Dim ControlValue As Integer = Integer.Parse(ucltxt_controlvalue.Text)
        'Dim MaxCnt As Integer = Integer.Parse(ucltxt_maxcnt.Text)

        ''[Cure_Type_Id]
        '',[Time_Control_Id]
        '',[Control_Value]
        '',[Max_Cnt]

        'Dim CureTypeColumn() As String = {"Cure_Type_Id", "Time_Control_Id", "Control_Value", "Max_Cnt", "Is_New"}
        'Dim CureTypeColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeInteger, _
        '                                       DataSetUtil.TypeInteger, DataSetUtil.TypeString}
        'Dim transCureControlDT As DataTable = DataSetUtil.createDataTable("curecontrol", Nothing, CureTypeColumn, CureTypeColumnType)

        'Dim cureDR As DataRow = transCureControlDT.NewRow
        'cureDR.Item(CureTypeColumn(0)) = CureTypeId
        'cureDR.Item(CureTypeColumn(1)) = TimeControlId
        'cureDR.Item(CureTypeColumn(2)) = ControlValue
        'cureDR.Item(CureTypeColumn(3)) = MaxCnt


        'If DataSetUtil.IsContainsData(CureControlData) Then
        '    If CType(CureControlData.Rows(0).Item(CureTypeColumn(0)), String).Equals(CureTypeId) Then
        '        cureDR.Item(CureTypeColumn(4)) = "N"
        '    Else
        '        cureDR.Item(CureTypeColumn(4)) = "Y"
        '    End If
        'Else
        '    cureDR.Item(CureTypeColumn(4)) = "Y"
        'End If


        'transCureControlDT.Rows.Add(cureDR)

        'CureControlData = transCureControlDT


    End Function

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBNhiIndexUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.F12
                confirm()
        End Select
    End Sub

    ''' <summary>
    ''' 確認
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_confirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirm.Click
        confirm()
    End Sub

#End Region



End Class
