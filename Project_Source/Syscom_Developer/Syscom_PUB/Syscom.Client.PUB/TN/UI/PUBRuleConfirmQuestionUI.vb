Imports Com.Syscom.WinFormsUI.Docking
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM
Imports System.Text

Public Class PUBRuleConfirmQuestionUI


    '============================
    '程式說明：確認規則
    '修改日期：2009.12.30
    '修改日期：2009.12.30
    '開發人員：Jen
    '============================

    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Public Sub New(ByVal initIsOldCanModify As Boolean)

        isOldCanModify = initIsOldCanModify
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"

    Dim pub As IPubServiceManager = Nothing 'WCF
    Dim comfirmClick As Boolean = False
    Dim ErrorKeyFlag As Boolean = False
    Dim DialogFlag As Boolean = False
    Dim isOldCanModify As Boolean = False

    Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    Dim ComboBoxColumnType() As Integer = {DataSetUtil.TypeString, DataSetUtil.TypeString}

    Dim confirmType As String = ""

    Public Property SelectedConfirmType() As String
        Get
            Return confirmType
        End Get
        Set(ByVal value As String)
            confirmType = value
        End Set
    End Property

#End Region

#Region "########## 啟動載入 ##########"

    Private Sub PUBRuleConfirmQuestionUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        'loadPubServiceManager()

        Me.KeyPreview = True

        If isOldCanModify Then
            cb_modifyerror.Checked = True
        Else
            '只能新增
            cb_add.Checked = True

            cb_modifyerror.Enabled = False
            cb_insertanother.Enabled = False
        End If

        '1:.我要建立新規則
        '   對應處理--> 將目前畫面上資料, 另取新 Rule_Code 存檔.
        '2:.只是修正現行規則的錯誤
        '   對應處理--> 將目前畫面上資料, update目前 Rule_Code 內容.
        '3. 調整目前規則,增加新版本.
        '   對應處理--> 3-1. 將目前畫面上資料(先視為新的rule)
        '               3-2. 比對新rule中有效起日要大於來源rule內容中的有效起日,
        '                    若沒有則提室使用者錯誤, 並放棄儲存.
        '               3-3. 若 3-2 PASS, 將新rule內容另取新Rule_Code 儲存. 
        '                    同時將來源Rule 中的有效迄日改為新rule 有效起日的前一日曆天.
        '                    同時將新Rule 中的來源規則代碼[Original_Rule_Code]填入來源rule的 Rule_Code.

        

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

        Return comfirmClick

    End Function

    Private Function confirm() As Boolean
        comfirmClick = True

        If cb_add.Checked Then
            SelectedConfirmType = SQLDataUtil.ADD_TYPE
        ElseIf cb_modifyerror.Checked Then
            SelectedConfirmType = SQLDataUtil.MOD_TYPE
        ElseIf cb_insertanother.Checked Then
            SelectedConfirmType = SQLDataUtil.CLONE_TYPE
        Else
            SelectedConfirmType = ""
        End If

        Me.Dispose()
    End Function

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub PUBRuleConfirmQuestionUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

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

    Private Sub cb_add_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_add.CheckedChanged
        If cb_add.Checked Then
            cb_modifyerror.Checked = False
            cb_insertanother.Checked = False
        Else

        End If
    End Sub

    Private Sub cb_modifyerror_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_modifyerror.CheckedChanged
        If cb_modifyerror.Checked Then
            cb_add.Checked = False
            cb_insertanother.Checked = False
        Else

        End If
    End Sub

    Private Sub cb_insertanother_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_insertanother.CheckedChanged
        If cb_insertanother.Checked Then
            cb_add.Checked = False
            cb_modifyerror.Checked = False
        Else

        End If
    End Sub

End Class
