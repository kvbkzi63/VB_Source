Imports System.Windows.Forms
Imports System.Text
Imports Syscom.Comm.BASE
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Client.UCL.UCLScreenUtil
Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling

Public Class IMaintainFormUI
    Implements IMaintainFunction

    Enum buttonAction
        INSERT
        UPDATE
        DELETE
        QUERY
        CLEAR
    End Enum

    Public Overridable Function insertData() As Boolean Implements IMaintainFunction.insertData

    End Function

    Public Overridable Function deleteData() As Boolean Implements IMaintainFunction.deleteData

    End Function

    Public Overridable Function updateData() As Boolean Implements IMaintainFunction.updateData

    End Function

    Public Overridable Function queryData() As Boolean Implements IMaintainFunction.queryData

    End Function

    Public Overridable Sub clearData() Implements IMaintainFunction.clearData

    End Sub

    Public Overridable Sub initialData() Implements IMaintainFunction.initialData

    End Sub

    Public Overridable Sub dgvCellClick() Implements IMaintainFunction.selectedDgvData

    End Sub

    ''' <summary>
    ''' 初始化畫面
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialize()
        Try
            IMaintainPanel.BringToFront()
            IMaintainPanel.Dock = System.Windows.Forms.DockStyle.Fill

            '根據語言 設定對應的 繁體/簡體 文字
            Select Case AppConfigUtil.AppLanguage

                Case AppConfigUtil.Language.TraditionalChinese

                    btnInsert.Text = "F12-新增"
                    btnUpdate.Text = "F10-修改"
                    btnDelete.Text = "SF12-刪除"
                    btnQuery.Text = "F1-查詢"
                    btnClear.Text = "F5-清除"
                    btnExit.Text = "ESC-退出"


                Case AppConfigUtil.Language.SimplifiedChinese

                    '設定成簡體字需要的格式
                    Me.Font = AppConfigUtil.ControlFont
                    btnInsert.Text = "新增(F3)"
                    btnUpdate.Text = "修改(F4)"
                    btnDelete.Text = "删除(F5)"
                    btnQuery.Text = "查询(F2)"
                    btnClear.Text = "清除(F6)"
                    btnExit.Text = "退出(ESC)"

            End Select

            initialData()

            initializeButton()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub IMaintainFormUI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        e.Handled = False
        Select Case e.KeyCode
            Case Keys.F5
                '清除
                btnClear_Click(sender, e)
            Case Keys.F12
                '刪除 SF12
                If e.Shift Then
                    If (btnDelete.Enabled) Then btnDelete_Click(sender, e)
                Else
                    '新增F12
                    If (btnInsert.Enabled) Then btnInsert_Click(sender, e)
                End If
            Case Keys.F10
                '修改
                If (btnUpdate.Enabled) Then btnUpdate_Click(sender, e)
            Case Keys.F1
                '查詢
                btnQuery_Click(sender, e)
            Case Keys.Escape
                '退出
                btnExit_Click(sender, e)
            Case Keys.Enter
                Me.ProcessTabKey(True)
        End Select
    End Sub

    Private Sub IMaintainFormUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            initialize()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Try
            UCLScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()
            If (insertData()) Then
                controlButton(buttonAction.INSERT)
                '將新增進去的資料反白
                For index As Integer = 0 To dgvShowData.Columns.Count - 1
                    If (dgvShowData.Columns(index).Visible = True) Then
                        dgvShowData.CurrentCell = dgvShowData(index, dgvShowData.RowCount - 1)
                        Exit For
                    End If
                Next
                'MessageHandling.showInfoByKey("CMMCMMB902")
                '********************2010/2/8 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("CMMCMMB902", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            ClientExceptionHandler.ProccessException(ex)
            'MessageHandling.showErrorByKey("CMMCMMB912")
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            UCLScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()
            If (updateData()) Then
                'MessageHandling.showInfoByKey("CMMCMMB903")
                '********************2010/2/8 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("CMMCMMB903", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            ClientExceptionHandler.ProccessException(ex)
            'MessageHandling.showErrorByKey("CMMCMMB913")
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            MessageHandling.ClearInfoMsg()
            'If (MessageHandling.showQuestionByKey("CMMCMMB932") = Windows.Forms.DialogResult.Yes) Then
            '********************2010/2/8 Modify By Alan**********************
            If (MessageHandling.ShowQuestionMsg("CMMCMMB932", New String() {}) = Windows.Forms.DialogResult.Yes) Then
                UCLScreenUtil.Lock(Me)
                If (deleteData()) Then
                    controlButton(buttonAction.DELETE)
                    '將資料從datagridview中移除
                    If dgvShowData.RowCount > 0 Then
                        dgvShowData.Rows.RemoveAt(dgvShowData.CurrentRow.Index)
                        If dgvShowData.CurrentRow IsNot Nothing Then
                            dgvShowData.CurrentRow.Selected = False
                        End If
                    End If
                    'MessageHandling.showInfoByKey("CMMCMMB904")
                    '********************2010/2/8 Modify By Alan**********************
                    MessageHandling.ShowInfoMsg("CMMCMMB904", New String() {})
                End If
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            ClientExceptionHandler.ProccessException(ex)
            'MessageHandling.showErrorByKey("CMMCMMB914")
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Try
            UCLScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()
            If (queryData()) Then
                controlButton(buttonAction.QUERY)
                If (dgvShowData.CurrentRow IsNot Nothing AndAlso dgvShowData.CurrentRow.Index >= 0) Then dgvShowData.CurrentRow.Selected = False
                'MessageHandling.showInfoByKey("CMMCMMB901")
                '********************2010/2/8 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("CMMCMMB901", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            ClientExceptionHandler.ProccessException(ex)
            'MessageHandling.showErrorByKey("CMMCMMB911")
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            clearData()
            controlButton(buttonAction.CLEAR)
            MessageHandling.ClearInfoMsg()
        Catch ex As Exception
            'log.Error(ex.ToString)
            ClientExceptionHandler.ProccessException(ex)
            'MessageHandling.showErrorByKey("CMMCMMB916")
        End Try
        MessageHandling.ClearInfoMsg()
    End Sub

    ''' <summary>
    ''' 離開
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Try
            MessageHandling.ClearInfoMsg()
            Me.Close()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 根據按下的按鈕控制按鈕的狀態
    ''' </summary>
    ''' <param name="action"></param>
    ''' <remarks></remarks>
    Private Sub controlButton(ByVal action As buttonAction)
        Try
            Select Case action
                Case buttonAction.QUERY, buttonAction.UPDATE, buttonAction.DELETE, buttonAction.CLEAR
                    initializeButton()
                Case buttonAction.INSERT
                    changedButton()
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化按鈕的狀態
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initializeButton()
        btnInsert.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnQuery.Enabled = True
        btnClear.Enabled = True
        If Me.Tag IsNot Nothing Then
            Dim funNo As String = Me.Tag.ToString.Split(",")(2)
            Dim queryRow As DataRow = Nothing
            If dsButtonControl.Tables(0).Rows.Contains(funNo) Then
                queryRow = dsButtonControl.Tables(0).Rows.Find(funNo)
                btnInsert.Enabled = False
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
                btnQuery.Enabled = False
                btnClear.Enabled = True
                If queryRow("btnInsert_Flag").ToString.Trim.Equals("Y") Then
                    btnInsert.Enabled = True
                End If
                If queryRow("btnQuery_Flag").ToString.Trim.Equals("Y") Then
                    btnQuery.Enabled = True
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 改變按鈕的狀態
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub changedButton()
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
        If Me.Tag IsNot Nothing Then
            Dim funNo As String = Me.Tag.ToString.Split(",")(2)
            Dim queryRow As DataRow = Nothing
            If dsButtonControl.Tables(0).Rows.Contains(funNo) Then
                queryRow = dsButtonControl.Tables(0).Rows.Find(funNo)
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
                If queryRow("btnUpdate_Flag").ToString.Trim.Equals("Y") Then
                    btnUpdate.Enabled = True
                End If
                If queryRow("btnDelete_Flag").ToString.Trim.Equals("Y") Then
                    btnDelete.Enabled = True
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 按下DatagridView的cell時,需處理的事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvShowData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShowData.CellClick
        Try
            If (e.RowIndex >= 0) Then
                dgvCellClick()
                changedButton()
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(New CommonException("CMMCMMB304"))
        End Try
    End Sub

#Region " 檢查功能"

#Region "     欄位檢查 - 檢查是否為空白 - 設定檢查結果 - 輸入為要檢查的控制項、要顯示的錯誤訊息字串、組合錯誤字串的StringBuilder、要回傳是否有錯的Flag "

    ''' <summary>
    '''      欄位檢查 - 檢查是否為空白 - 輸入為要檢查的控制項、要顯示的錯誤訊息字串、組合錯誤字串的StringBuilder、要回傳是否有錯的Flag
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-12-2</remarks>
    Public Sub SetCheckResult(ByRef objCheck As Object, ByVal errorStr As String, ByRef strErrMsg As StringBuilder, ByRef returnBoolean As Boolean)

        Try

            '沒有輸入值才會執行，有輸入值則不動作
            If Not CheckControlHasValue(objCheck) Then

                strErrMsg.Append(errorStr)

                objCheck.Focus()

                returnBoolean = True

            End If


        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "欄位檢查 - 檢查是否為空白", ex.Message)

        End Try

    End Sub

#End Region

#Region "     欄位檢查 - 檢查是否為數字(可空白) - 設定檢查結果 - 輸入為要檢查的控制項、要顯示的錯誤訊息字串、組合錯誤字串的StringBuilder、要回傳是否有錯的Flag "

    ''' <summary>
    '''      欄位檢查 - 檢查是否為數字(可空白) - 設定檢查結果 - 輸入為要檢查的控制項、要顯示的錯誤訊息字串、組合錯誤字串的StringBuilder、要回傳是否有錯的Flag
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-10-31</remarks>
    Public Sub SetCheckResultNumber(ByRef objCheck As Object, ByVal errorStr As String, ByRef strErrMsg As StringBuilder, ByRef returnBoolean As Boolean)

        Try

            '檢查是否為數字，不是數字則執行
            If Not CheckControlIsNumber(objCheck) Then

                strErrMsg.Append(errorStr)

                objCheck.Focus()

                returnBoolean = True

            End If


        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "欄位檢查 - 檢查是否為數字", ex.Message)

        End Try

    End Sub

#End Region

#End Region

End Class
