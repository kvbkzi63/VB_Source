'/*
'*****************************************************************************
'*
'*    Page/Class Name:	UCLRangeInputUI.vb
'*              Title:	UCLRangeInputUI元件
'*        Description:	彈出放大輸入範圍視窗
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Jen
'*        Create Date:	
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/

Imports Com.Syscom.WinFormsUI.Docking
Imports Syscom.Client.servicefactory
Imports Syscom.Client.ucl
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.cmm
Imports System.Text

Public Class UCLRangeInputUI

    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Public Sub New(ByVal initConditionMsg As String, ByVal initMaxLength As Integer)

        ConfirmMsg = initConditionMsg
        maxLength = initMaxLength

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "########## 宣告物件 ##########"

    Dim ErrorKeyFlag As Boolean = False

    'Dim ComboBoxColumn() As String = {"Code_Id", "Code_Name"}
    'Dim ComboBoxColumnType() As Integer = {"10242", "10242"}

    Private maxLength As Integer = 100
    Private confirmFlag As Boolean = False
    Dim ConditionMsg As String = ""

    '儲存回傳的訊息
    Private Property ConfirmMsg() As String
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
        'loadPubServiceManager()


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

        ucl_rbt_range.uclMaxLength = maxLength

        ucl_rbt_range.Text = ConfirmMsg

    End Sub

#End Region

#Region "########## 共用函式 ##########"

    '''' <summary>
    '''' 取得clientservice
    '''' </summary>
    '''' <remarks></remarks>
    'Private Sub loadPubServiceManager()
    '    Try
    '        pub = PubServiceManager.getInstance
    '    Catch ex As Exception
    '        MessageHandling.showInfoByKey("CMMCMMB001")
    '        Throw ex
    '    End Try
    'End Sub

    ''' <summary>
    ''' 欄位檢查
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function checkColumn() As Boolean
        Dim comp As Object = Nothing
        Dim allPass As Boolean = True
        'If Not UclComboBoxUILender.SelectedIndex > 0 Then
        '    UclComboBoxUILender.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
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
            'UclComboBoxUILender.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            'UclComboBoxUILendType.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            'UclComboBoxUILendReason.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
            'UclComboBoxUILendDept.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT

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

    'Private Function splitMessageToData() As String()

    '    Return Nothing
    'End Function

    ''' <summary>
    ''' 用dialog方式開啟
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ShowAndPrepareReturnData() As Boolean

        Me.ShowDialog()
        Return confirmFlag

    End Function

    Private Function confirm() As Boolean

        If checkMessageCorrect() Then
            '訊息格式正確, 確認回去
            ConfirmMsg = ucl_rbt_range.Text.Trim
            confirmFlag = True

            Me.Close()

            Return True
        Else
            '訊息格式錯誤
            confirmFlag = False
            Return False
        End If

    End Function

    Public Function getConfirmMessageAndLeave() As String
        Dim confirmMessage As String = ""

        If confirmFlag Then
            confirmMessage = "" + ConfirmMsg
        Else

        End If

        ConfirmMsg = ""

        Return confirmMessage

    End Function

#End Region

#Region "########## 觸發事件 ##########"

    ''' <summary>
    ''' HotKey運作
    ''' Enter:載入ㄧ筆ChartNo
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub UCLRangeInputUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
