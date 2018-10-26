Imports Com.Syscom.WinFormsUI.Docking
Imports System.Text
Imports Syscom.Client.CMM
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility

Public Class PUBCureControlUI

    '============================
    '程式說明：健保療程
    '修改日期：2009.09.30
    '修改日期：2009.09.30
    '開發人員：Jen
    '============================

    Public Sub New(ByVal initCureTypeId As String, ByVal initSyscode As DataTable, ByVal initCureControlDT As DataTable)

        CureTypeId = initCureTypeId
        SyscodeDT = initSyscode
        CureControlData = initCureControlDT

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    Dim ErrorKeyFlag As Boolean = False

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim CureTypeColumn() As String = {"Cure_Type_Id", "Time_Control_Id", "Control_Value", "Max_Cnt", "Is_Reg_Fee", "Is_Fee_Check"}
    Dim CureTypeColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString, DataSetUtil.TypeInteger, _
                                           DataSetUtil.TypeInteger, DataSetUtil.TypeString, DataSetUtil.TypeString}

    Private confirmFlag As Boolean = False
    Dim CureTypeId As String = ""
    Private SyscodeDT As DataTable = Nothing
    Private CureControlDT As DataTable = Nothing

    Public Property CureControlData() As DataTable
        Get
            Return CureControlDT
        End Get
        Set(ByVal value As DataTable)
            CureControlDT = value
        End Set
    End Property

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBCureControlUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loadPubServiceManager()

        '初始
        'pub.....取得初始資料
        '40, 511
        If Not DataSetUtil.IsContainsData(SyscodeDT) Then
            'Call WCF
            Dim typeId() As Integer = {40, 511}
            SyscodeDT = pub.querySyscodeByTypeIds(typeId)
        End If

        Dim selectOutDRs() As DataRow

        '療程類型
        selectOutDRs = SyscodeDT.Select(" Type_Id = 511 ")
        If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
            uclcb_curetypeid.DataSource = createComboBoxTable("treatmenttype", selectOutDRs)
            uclcb_curetypeid.uclValueIndex = "0"
            uclcb_curetypeid.uclDisplayIndex = "0,1"
        Else
            '
        End If

        '時間控制類型
        selectOutDRs = SyscodeDT.Select(" Type_Id = 40 ")
        If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
            uclcb_timecontrolid.DataSource = createComboBoxTable("periodcontroltype", selectOutDRs)
            uclcb_timecontrolid.uclValueIndex = "0"
            uclcb_timecontrolid.uclDisplayIndex = "0,1"
        Else
            '
        End If

        If DataSetUtil.IsContainsData(CureControlData) Then

            uclcb_curetypeid.SelectedValue = CType(CureControlData.Rows(0).Item("Cure_Type_Id"), String).Trim()
            uclcb_timecontrolid.SelectedValue = CType(CureControlData.Rows(0).Item("Time_Control_Id"), String).Trim()
            ucltxt_controlvalue.Text = CType(CureControlData.Rows(0).Item("Control_Value"), Integer)
            ucltxt_maxcnt.Text = CType(CureControlData.Rows(0).Item("Max_Cnt"), Integer)

            If CType(CureControlData.Rows(0).Item("Is_Reg_Fee"), String).Trim() = "Y" Then
                cb_IsRegFee.Checked = True
            Else
                cb_IsRegFee.Checked = False
            End If

            If CType(CureControlData.Rows(0).Item("Is_Fee_Check"), String).Trim() = "Y" Then
                cb_IsFeeCheck.Checked = True
            Else
                cb_IsFeeCheck.Checked = False
            End If

        End If
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
            MessageHandling.ShowInfoMsg("CMMCMMB001", New String() {})
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Create DataTable By DataSource Parameter Column 0 key, column 1 value
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <param name="dataSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function createComboBoxTable(ByVal tableName As String, ByRef dataSource As DataTable) As DataTable
        Dim returnDT As DataTable = DataSetUtil.createDataTable(tableName, Nothing, ComboBoxColumn, ComboBoxColumnType)

        For i As Integer = 0 To (dataSource.Rows.Count - 1)
            Dim dr As DataRow = returnDT.NewRow
            dr.Item(ComboBoxColumn(0)) = CType(dataSource.Rows(i).Item(0), String).Trim
            dr.Item(ComboBoxColumn(1)) = CType(dataSource.Rows(i).Item(1), String).Trim
            returnDT.Rows.Add(dr)
        Next

        Return returnDT

    End Function

    ''' <summary>
    ''' (從syscode)Create DataTable By DataRows Parameter Column 1 key, column 3 value
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <param name="dataRows"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function createComboBoxTable(ByVal tableName As String, ByRef dataRows() As DataRow) As DataTable

        If dataRows IsNot Nothing AndAlso dataRows.Length > 0 Then
            Dim returnDT As DataTable = DataSetUtil.createDataTable(tableName, Nothing, ComboBoxColumn, ComboBoxColumnType)

            For i As Integer = 0 To (dataRows.Length - 1)
                Dim dr As DataRow = returnDT.NewRow
                dr.Item(ComboBoxColumn(0)) = CType(dataRows(i).Item(1), String).Trim
                dr.Item(ComboBoxColumn(1)) = CType(dataRows(i).Item(3), String).Trim
                returnDT.Rows.Add(dr)
            Next

            Return returnDT
        Else
            Return Nothing
        End If

    End Function

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

    Public Function ShowAndPrepareReturnData() As Boolean
        Me.ShowDialog()

        Return confirmFlag

    End Function

    Private Function confirm() As Boolean
        confirmFlag = True
        'check column
        'if true do...
        '塞值於DT中 供回傳
        Dim CureTypeId As String = uclcb_curetypeid.SelectedValue
        Dim TimeControlId As String = uclcb_timecontrolid.SelectedValue

        Dim ControlValue As Integer = 0
        If ucltxt_controlvalue.Text <> "" Then
            ControlValue = Integer.Parse(ucltxt_controlvalue.Text)
        End If

        Dim MaxCnt As Integer = 0
        If ucltxt_maxcnt.Text <> "" Then
            MaxCnt = Integer.Parse(ucltxt_maxcnt.Text)
        End If

        Dim pvtIsRegFee As String = "N"
        Dim pvtIsFeeCheck As String = "N"

        If cb_IsRegFee.Checked Then
            pvtIsRegFee = "Y"
        End If

        If cb_IsFeeCheck.Checked Then
            pvtIsFeeCheck = "Y"
        End If

        '[Cure_Type_Id]
        ',[Time_Control_Id]
        ',[Control_Value]
        ',[Max_Cnt]


        Dim transCureControlDT As DataTable = DataSetUtil.createDataTable("curecontrol", Nothing, CureTypeColumn, CureTypeColumnType)

        Dim cureDR As DataRow = transCureControlDT.NewRow
        cureDR.Item(CureTypeColumn(0)) = CureTypeId
        cureDR.Item(CureTypeColumn(1)) = TimeControlId
        cureDR.Item(CureTypeColumn(2)) = ControlValue
        cureDR.Item(CureTypeColumn(3)) = MaxCnt
        cureDR.Item(CureTypeColumn(4)) = pvtIsRegFee
        cureDR.Item(CureTypeColumn(5)) = pvtIsFeeCheck

        transCureControlDT.Rows.Add(cureDR)

        CureControlData = transCureControlDT

        Me.Dispose()

    End Function

#End Region



#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBTreatmentControlUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

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

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        uclcb_curetypeid.SelectedValue = 0
        uclcb_timecontrolid.SelectedValue = 0
        ucltxt_controlvalue.Text = ""
        ucltxt_maxcnt.Text = ""
    End Sub
#End Region

   
End Class
