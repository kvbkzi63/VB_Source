Imports Com.Syscom.WinFormsUI.Docking
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports System.Text

Public Class PUBRuleRangeInputUI


    '============================
    '程式說明：規則值域輸入
    '修改日期：2009.12.20
    '修改日期：2009.12.20
    '開發人員：Jen
    '============================

    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Public Sub New(ByVal initConditionMsg As String)

        ConfirmMsg = initConditionMsg

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    Dim ErrorKeyFlag As Boolean = False

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    'Dim NhiIndexColumn() As String = {"健保指標歸類項目", "Code_Id"}
    'Dim NhiIndexColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    'Dim NhiIndexSetColumn() As String = {"Order_Code", "Nhi_Index_Type_Id"}
    'Dim NhiIndexSetColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Private DialogFlag As Boolean = False
    Dim ConditionMsg As String = ""


    'Private SyscodeDT As DataTable = Nothing
    'Private NhiIndexDT As DataTable = Nothing

    Public Property ConfirmMsg() As String
        Get
            Return ConditionMsg
        End Get
        Set(ByVal value As String)
            ConditionMsg = value
        End Set
    End Property

    Dim SplitConditionMsg As ArrayList = New ArrayList

    Public Property SplitConfirmMsg() As ArrayList
        Get
            Return SplitConditionMsg
        End Get
        Set(ByVal value As ArrayList)
            SplitConditionMsg = value
        End Set
    End Property

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBConditionMessageUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loadPubServiceManager()


        Dim msgStr As StringBuilder = New StringBuilder
        msgStr.Append("1. 個別值以逗號 ',' 區隔.").Append(vbCrLf)
        msgStr.Append("2. 一個範圍的值以左右中括號 '[]', ").Append(vbCrLf)
        msgStr.Append("   包含中間以() '-' 區隔範圍臨界值.").Append(vbCrLf)
        msgStr.Append("   Ex: 734002C, 734005C, 734009C, [742001C-734008C]").Append(vbCrLf)
        msgStr.Append("3. ICD-9 Code 可輸入 '250X', 表示所有 ICD 前3碼為 ").Append(vbCrLf)
        msgStr.Append("   250 的範圍, 注意此表示法僅適用個別 ICD 輸入").Append(vbCrLf)
        msgStr.Append("   正確範例: 560X, 561X, 562X, 563X ").Append(vbCrLf)
        msgStr.Append("   錯誤範例: [560-563X]").Append(vbCrLf)

        lb_conditionmsg.Text = msgStr.ToString

        ucl_rbt_range.Text = ConfirmMsg

        'ucl_dgv_list.uclHeaderText = UCLDataGridViewUI.convertColumnToHeader(NhiIndexColumn)
        'ucl_dgv_list.uclColumnWidth = "380, 0" '380
        'ucl_dgv_list.uclColumnAlignment = "0"
        'ucl_dgv_list.uclNonVisibleColIndex = "2"


        ''init Grid資料
        ''----------------------------------------------
        'Dim listDS As DataSet = New DataSet
        'Dim listDT As DataTable = DataSetUtil.createDataTable("list", Nothing, NhiIndexColumn, NhiIndexColumnType)

        ''初始
        ''pub.....取得初始資料
        ''510
        'If Not DataSetUtil.IsContainsData(SyscodeDT) Then
        '    'Call WCF
        '    Dim typeId() As Integer = {510}
        '    SyscodeDT = pub.querySyscodeByTypeIds(typeId)
        'End If

        'Dim selectOutDRs() As DataRow

        ''健保指標歸類項目
        'selectOutDRs = SyscodeDT.Select(" Type_Id = 510 ")
        'If selectOutDRs IsNot Nothing AndAlso selectOutDRs.Length > 0 Then
        '    'uclcb_curetypeid.DataSource = createComboBoxTable("treatmenttype", selectOutDRs)
        '    'uclcb_curetypeid.uclValueIndex = "0"
        '    'uclcb_curetypeid.uclDisplayIndex = "0,1"
        '    For i As Integer = 0 To (selectOutDRs.Count - 1)
        '        Dim listdr As DataRow = listDT.NewRow
        '        listdr.Item(NhiIndexColumn(0)) = CType(selectOutDRs(i).Item("Code_Name"), String).Trim

        '        listdr.Item(NhiIndexColumn(1)) = CType(selectOutDRs(i).Item("Code_Id"), String).Trim
        '        listDT.Rows.Add(listdr)
        '    Next

        'Else
        '    '
        'End If

        'listDS.Tables.Add(listDT)
        ''----------------------------------------------

        'ucl_dgv_list.Initial(listDS)
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
            MessageHandling.ShowInfoMsg("CMMCMMB901")
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

    'ucl_rbt_range
    ''' <summary>
    ''' 檢核訊息是否正確格式
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkMessageCorrect() As Boolean
        Dim unprocessMsg As String = ucl_rbt_range.Text.Trim

        If unprocessMsg.Length > 0 Then

            Dim processResult As Boolean = True

            If unprocessMsg.Length > 0 AndAlso unprocessMsg.IndexOf(vbCrLf) > -1 Then
                unprocessMsg = Replace(unprocessMsg, vbCrLf, "")
            End If

            If unprocessMsg.Substring(unprocessMsg.Length - 1, 1).Equals(",") Then
                unprocessMsg = unprocessMsg.Substring(0, unprocessMsg.Length - 1)
            End If

            ucl_rbt_range.Text = unprocessMsg

            Dim splitMsg() As String = unprocessMsg.Split(",")
            If splitMsg IsNot Nothing AndAlso splitMsg.Length > 0 Then
                For i As Integer = 0 To (splitMsg.Length - 1)
                    If isSplitMessageCorrect(splitMsg(i)) Then

                    Else
                        processResult = False
                    End If
                Next

            Else
                processResult = False
            End If

            Return processResult
        Else
            'no need check
            Return True

        End If

    End Function

    ''' <summary>
    ''' 細分的每項是否合法?
    ''' </summary>
    ''' <param name="splitMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isSplitMessageCorrect(ByRef splitMsg As String) As Boolean
        If splitMsg IsNot Nothing AndAlso splitMsg.Length > 0 Then
            If splitMsg.Contains("-") Then
                'range
                Dim rangeSplit() As String = splitMsg.Split("-")
                If rangeSplit IsNot Nothing AndAlso rangeSplit.Length = 2 Then
                    Dim stepCorrect As Boolean = True

                    For i As Integer = 0 To (rangeSplit.Length - 1)
                        If rangeSplit(i).IndexOf("X") > -1 Then
                            stepCorrect = False
                        Else

                        End If
                    Next

                    If rangeSplit(0).CompareTo(rangeSplit(1)) > 0 Then
                        stepCorrect = False
                    End If

                    Return stepCorrect

                Else
                    '不合規則
                    Return False
                End If
            Else
                'not range
                Return True
            End If
        Else
            Return False
        End If

    End Function

    Private Function splitMessageToData() As String()

        Return Nothing
    End Function

    ''' <summary>
    ''' 用dialog方式開啟
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ShowAndPrepareReturnData() As Boolean

        Me.ShowDialog()
        Return DialogFlag

    End Function

    Private Function confirm() As Boolean

        If checkMessageCorrect() Then
            '訊息格式正確, 確認回去
            ConfirmMsg = ucl_rbt_range.Text.Trim
            DialogFlag = True

            Me.Close()

            Return True
        Else
            '訊息格式錯誤
            DialogFlag = False
            Return False
        End If

    End Function

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBConditionMessageUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

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
