Imports Com.Syscom.WinFormsUI.Docking
Imports System.Text
Imports Syscom.Client.UCL
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM

Public Class PUBExcludeDrugSetUI


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

    Public Sub New(ByVal initOrderCode As String, ByVal initSyscode As DataTable, ByVal initExclusiveDrugDT As DataTable)

        OrderCode = initOrderCode
        SyscodeDT = initSyscode
        ExclusiveDrugData = initExclusiveDrugDT

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Public Sub New(ByVal initOrderCode As String)

        OrderCode = initOrderCode

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    Dim ErrorKeyFlag As Boolean = False

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim ExclusiveColumn() As String = {"Exclude_Drug_Type_Id", "Effect_Date", "End_Date", "Exclude_Drug_Memo", "Code_Id"}
    Dim ExclusiveColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeDate, DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim ExclusiveSetColumn() As String = {"Order_Code", "Exclude_Drug_Type_Id", "Effect_Date", "End_Date", "Exclude_Drug_Memo"}
    Dim ExclusiveSetColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeDate, DataSetUtil.TypeDate, DataSetUtil.TypeString}
    Private DialogFlag As Boolean = False
    Dim OrderCode As String = ""
    Private SyscodeDT As DataTable = Nothing
    Private ExclusiveDrugDT As DataTable = Nothing

    Public Property ExclusiveDrugData() As DataTable
        Get
            Return ExclusiveDrugDT
        End Get
        Set(ByVal value As DataTable)
            ExclusiveDrugDT = value
        End Set
    End Property

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBExclusiveDrugUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loadPubServiceManager()
        Me.KeyPreview = True
        ucl_dgv_list.uclHeaderText = "排除藥費類型,生效日,停止日,備註"
        ucl_dgv_list.uclColumnWidth = "110, 80, 80, 110, 0" '380
        ucl_dgv_list.uclColumnAlignment = "0"
        ucl_dgv_list.uclNonVisibleColIndex = "5"


        'init Grid資料
        '----------------------------------------------
        Dim listDS As DataSet = New DataSet
        Dim listDT As DataTable = DataSetUtil.createDataTable("list", Nothing, ExclusiveColumn, ExclusiveColumnType)

        '傳入資料?
        If DataSetUtil.IsContainsData(ExclusiveDrugData) Then

        End If

        listDT = pub.queryExclusiveDrugSetData2(OrderCode)

        listDS.Tables.Add(listDT)
        '----------------------------------------------


        'Hash版
        Dim _hashTable As Hashtable = New Hashtable

        Dim txt_cell As New TextBoxCell()
        Dim date_cell As New DtpCell()

        _hashTable.Add(-1, listDS)


        _hashTable.Add(2, date_cell)
        _hashTable.Add(3, date_cell)
        _hashTable.Add(4, txt_cell)

        ucl_dgv_list.Initial(_hashTable)

        For i = 0 To ucl_dgv_list.GetDBDS.Tables(0).Rows.Count - 1
            If ucl_dgv_list.GetDBDS.Tables(0).Rows(i).Item("Effect_Date").ToString.Trim <> "" Then
                ucl_dgv_list.Rows(i).Cells(0).Value = True
            End If
        Next

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
    Private Function checkCell() As Boolean
        Dim comp As Object = Nothing
        Dim allPass As Boolean = True

        Dim selectedIndex() As Integer = ucl_dgv_list.GetSelectedIndex
        If selectedIndex IsNot Nothing AndAlso selectedIndex.Length > 0 Then
            ',"Order_Code", "Exclude_Drug_Type_Id", "Effect_Date", "End_Date", "Exclude_Drug_Memo"
        Else
            '沒選
            ExclusiveDrugData = Nothing
        End If


        Return allPass
    End Function

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


        Dim ExclusiveDT As DataTable = DataSetUtil.createDataTable("exclusive", Nothing, ExclusiveSetColumn, ExclusiveSetColumnType)
        Dim ExclusiveDS As DataSet = ucl_dgv_list.GetDBDS.Copy
        Dim pvtIndex As Integer = 0

        For i = 0 To ExclusiveDS.Tables(0).Rows.Count - 1
            If ucl_dgv_list.Rows(i).Cells(0).Value = True Then
                Dim excdr As DataRow = ExclusiveDT.NewRow
                Dim pvtExcludeDrugTypeName As String

                ExclusiveDT.Rows.Add()
                ExclusiveDT.Rows(pvtIndex).Item(ExclusiveSetColumn(0)) = OrderCode
                pvtExcludeDrugTypeName = ExclusiveDS.Tables(0).Rows(i).Item("Code_Name").ToString.Trim
                ExclusiveDT.Rows(pvtIndex).Item(ExclusiveSetColumn(1)) = ExclusiveDS.Tables(0).Rows(i).Item(ExclusiveColumn(4)).ToString.Trim
                If ExclusiveDS.Tables(0).Rows(i).Item(ExclusiveColumn(1)).ToString.Trim <> "" Then
                    ExclusiveDT.Rows(pvtIndex).Item(ExclusiveSetColumn(2)) = CDate(ExclusiveDS.Tables(0).Rows(i).Item(ExclusiveColumn(1)))
                Else
                    MessageHandling.ShowErrorMsg("CMMCMMB305", New String() {pvtExcludeDrugTypeName & "- 生效日"}, "")
                    Return False
                    'ExclusiveDT.Rows(pvtIndex).Item(ExclusiveSetColumn(2)) = ExclusiveDS.Tables(0).Rows(i).Item(ExclusiveColumn(1))
                End If

                If ExclusiveDS.Tables(0).Rows(i).Item(ExclusiveColumn(2)).ToString.Trim <> "" Then
                    ExclusiveDT.Rows(pvtIndex).Item(ExclusiveSetColumn(3)) = CDate(ExclusiveDS.Tables(0).Rows(i).Item(ExclusiveColumn(2)))
                Else
                    MessageHandling.ShowErrorMsg("CMMCMMB305", New String() {pvtExcludeDrugTypeName & "- 停止日"}, "")
                    Return False
                    'ExclusiveDT.Rows(pvtIndex).Item(ExclusiveSetColumn(3)) = ExclusiveDS.Tables(0).Rows(i).Item(ExclusiveColumn(2))
                End If

                If DateDiff(DateInterval.Day, CDate(ExclusiveDS.Tables(0).Rows(i).Item(ExclusiveColumn(1))), CDate(ExclusiveDS.Tables(0).Rows(i).Item(ExclusiveColumn(2)))) < 0 Then
                    MessageHandling.ShowErrorMsg("CMMCMMB307", New String() {pvtExcludeDrugTypeName & "- 生效日", "停止日"}, "")
                    Return False
                End If

                ExclusiveDT.Rows(pvtIndex).Item(ExclusiveSetColumn(4)) = ExclusiveDS.Tables(0).Rows(i).Item(ExclusiveColumn(3)).ToString.Trim
                pvtIndex += 1
            End If
        Next

        ExclusiveDrugData = ExclusiveDT

        Dispose()

    End Function

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBExclusiveDrugUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

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
