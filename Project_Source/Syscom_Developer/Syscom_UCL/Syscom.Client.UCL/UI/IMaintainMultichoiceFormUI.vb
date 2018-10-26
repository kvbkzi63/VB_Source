Imports System.Windows.Forms
Imports System.Text
Imports Syscom.Comm.BASE
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Client.UCL.UCLScreenUtil
Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Comm.EXP

Public Class IMaintainMultichoiceFormUI
    Inherits Syscom.Client.UCL.BaseFormUI
    Implements IMaintainMultichoiceFunction


#Region "     變數宣告 "

#Region "     使用者ID宣告　"

    '目前使用者的ID
    Public CurrentUserID As String = AppContext.userProfile.userId

#End Region

#Region "     建立者資訊 "

    Public globalCreateUser As String = ""

#End Region

#Region "     按鈕代表屬性宣告 - buttonAction "

    Enum buttonAction
        SAVE
        DELETE
        QUERY
        CLEAR
    End Enum

#End Region

#Region "     要設定的Column種類"

    Enum GridColumn
        CheckBoxCell
        TextBoxCell
        ComboBoxCell
        DateTimePickerCell
        ReadOnlyCell
    End Enum

#End Region

#Region "     要設定到 Hash Table 的 Column Structure"

    Structure GridAttribute

        Dim columnIndex As GridColumn
        Dim columnAttribute As GridColumn

        ' constructor

        ''' <summary>
        ''' 產生一個Structure
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New( _
           ByVal _columnIndex As GridColumn, ByVal _columnAttribute As GridColumn)
            columnIndex = _columnIndex
            columnAttribute = _columnAttribute
        End Sub 'New

    End Structure

#End Region

#End Region

#Region "     Overridable 函數宣告 "


    Public Overridable Function SaveData() As Boolean Implements IMaintainMultichoiceFunction.SaveData
        Throw New Exception("Method insertData must be Overridden")
    End Function
    Public Overridable Function DeleteData() As Boolean Implements IMaintainMultichoiceFunction.DeleteData
        Throw New Exception("Method deleteData must be Overridden")
    End Function
    Public Overridable Function QueryData() As Boolean Implements IMaintainMultichoiceFunction.QueryData
        Throw New Exception("Method queryData must be Overridden")
    End Function
    Public Overridable Sub ClearData() Implements IMaintainMultichoiceFunction.ClearData
        Throw New Exception("Method clearData must be Overridden")
    End Sub

    Public Overridable Sub dgvCellClick() Implements IMaintainMultichoiceFunction.SelectedDgvData
        Throw New Exception("Method dgvCellClick must be Overridden")
    End Sub


#End Region

#Region "     主要功能 "


#Region "     按鈕事件 "

    ''' <summary>
    ''' 確認
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Lock(Me)
            MessageHandling.ClearInfoMsg()
            If (SaveData()) Then
                controlButton(buttonAction.SAVE)
                '將新增進去的資料反白
                For index As Integer = 0 To dgvShowData.Columns.Count - 1
                    If (dgvShowData.Columns(index).Visible = True) Then
                        dgvShowData.CurrentCell = dgvShowData.Rows(dgvShowData.Rows.Count - 1).Cells(index)
                        Exit For
                    End If
                Next
                'MessageHandling.showInfoByKey("CMMCMMB002")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("CMMCMMB002", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD002")
            ClientExceptionHandler.ProccessException(ex)
        Finally
            UnLock(Me)
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
            '********************2010/2/9 Modify By Alan**********************
            If (MessageHandling.ShowQuestionMsg("CMMCMMB932", New String() {}) = Windows.Forms.DialogResult.Yes) Then
                Lock(Me)
                If (DeleteData()) Then
                    controlButton(buttonAction.DELETE)
                    '將資料從datagridview中移除
                    dgvShowData.RemoveRowAt(dgvShowData.CurrentRow.Index)
                    'MessageHandling.showInfoByKey("CMMCMMB904")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowInfoMsg("CMMCMMB904", New String() {})
                End If
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            ' MessageHandling.showErrorByKey("HEMCMMD014")
            ClientExceptionHandler.ProccessException(ex)
        Finally
            UnLock(Me)
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
            Lock(Me)
            MessageHandling.ClearInfoMsg()
            If (QueryData()) Then
                controlButton(buttonAction.QUERY)
                If (dgvShowData.CurrentRow IsNot Nothing AndAlso dgvShowData.CurrentRow.Index >= 0) Then dgvShowData.CurrentRow.Selected = False
                'MessageHandling.showInfoByKey("CMMCMMB001")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("CMMCMMB001", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            ' MessageHandling.showErrorByKey("CMMCMMD001")
            ClientExceptionHandler.ProccessException(ex)
        Finally
            UnLock(Me)
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
            ClearData()
            controlButton(buttonAction.CLEAR)
            MessageHandling.ClearInfoMsg()
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD006")
            ClientExceptionHandler.ProccessException(ex)
        End Try
        MessageHandling.ClearInfoMsg()
    End Sub

#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

    ''' <summary>
    ''' 初始化資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub initialData() Implements IMaintainMultichoiceFunction.InitialData

    End Sub

    ''' <summary>
    ''' 初始化畫面
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialize()
        Try
            IUCLMaintainPanel.BringToFront()
            IUCLMaintainPanel.Dock = System.Windows.Forms.DockStyle.Fill

            '根據語言 設定對應的 繁體/簡體 文字
            Select Case AppConfigUtil.AppLanguage

                Case AppConfigUtil.Language.TraditionalChinese

                    btnSave.Text = "F12-確定"
                    btnDelete.Text = "SF12-刪除"
                    btnQuery.Text = "F1-查詢"
                    btnClear.Text = "F5-清除"



                Case AppConfigUtil.Language.SimplifiedChinese

                    '設定成簡體字需要的格式
                    Me.Font = AppConfigUtil.ControlFont
                    btnSave.Text = "确认(F3)"
                    btnDelete.Text = "删除(F5)"
                    btnQuery.Text = "查询(F2)"
                    btnClear.Text = "清除(F6)"


            End Select

            initialData()



        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region "     HotKey設定 "

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Console.WriteLine(e.KeyCode.ToString)
        'If (UCLScreenUtil.flag) Then
        '    e.Handled = False
        '    UCLScreenUtil.flag = False
        'End If

        e.Handled = False

        Select Case AppConfigUtil.AppLanguage

            Case AppConfigUtil.Language.TraditionalChinese


                Select Case e.KeyCode

                    Case Keys.F5
                        '清除
                        'MessageHandling.clearInfoMsg()
                        btnClear_Click(sender, e)
                    Case Keys.F12

                        '刪除 SF12
                        If e.Shift Then
                            If (btnDelete.Enabled) Then btnDelete_Click(sender, e)

                        Else
                            '確認F12
                            'MessageHandling.clearInfoMsg()
                            If (btnSave.Enabled) Then btnSave_Click(sender, e)

                        End If

                        'Case Keys.F10
                        '    '修改
                        '    'MessageHandling.clearInfoMsg()
                        '    If (btnUpdate.Enabled) Then btnUpdate_Click(sender, e)

                    Case Keys.F1
                        '查詢
                        'MessageHandling.clearInfoMsg()
                        btnQuery_Click(sender, e)
                    Case Keys.Enter
                        Me.ProcessTabKey(True)
                End Select

            Case AppConfigUtil.Language.SimplifiedChinese

                Select Case e.KeyCode

                    'Enter 模擬 Tab
                    Case Keys.Enter

                        Me.ProcessTabKey(True)

                    Case Keys.F2

                        '查詢
                        If btnQuery.Enabled Then
                            btnQuery.PerformClick()
                        End If

                    Case Keys.F3

                        '新增
                        If (btnSave.Enabled) Then
                            btnSave.PerformClick()
                        End If

                        'Case Keys.F4

                        '    '修改
                        '    If btnUpdate.Enabled Then
                        '        btnUpdate.PerformClick()
                        '    End If

                    Case Keys.F5

                        '刪除
                        If (btnDelete.Enabled) Then
                            btnDelete.PerformClick()
                        End If

                    Case Keys.F6

                        '清除
                        If btnClear.Enabled Then
                            btnClear.PerformClick()
                        End If
                    Case Keys.Enter
                        Me.ProcessTabKey(True)

                End Select

        End Select


    End Sub

#End Region

#Region "     按鈕控制按鈕的狀態設定 "

    ''' <summary>
    ''' 根據按下的按鈕控制按鈕的狀態
    ''' </summary>
    ''' <param name="action"></param>
    ''' <remarks></remarks>
    Private Sub controlButton(ByVal action As buttonAction)
        Try
            Select Case action
                Case buttonAction.QUERY, buttonAction.DELETE, buttonAction.CLEAR
                    initializeButton()
                Case buttonAction.SAVE
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
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnQuery.Enabled = True
        btnClear.Enabled = True
    End Sub
    ''' <summary>
    ''' 改變按鈕的狀態
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub changedButton()
        btnDelete.Enabled = True
    End Sub

#End Region

#End Region


    Private Sub IUCLMaintainFormUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            initialize()
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMB007")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB007", New String() {}, "")
        End Try

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
            'log.Error(ex.ToString)
            'MessageHandling.showError(ResourceUtil.getString("HEMCMMB203", New String(0) {"資料"}))
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub


#Region "     欄位檢查 - 設定檢查結果 - 輸入為要檢查的控制項、要顯示的錯誤訊息字串、組合錯誤字串的StringBuilder、要回傳是否有錯的Flag "

    ''' <summary>
    '''      欄位檢查 - 設定檢查結果 - 輸入為要檢查的控制項、要顯示的錯誤訊息字串、組合錯誤字串的StringBuilder、要回傳是否有錯的Flag
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-12-2</remarks>
    Public Sub SetCheckResult(ByRef objCheck As Object, ByVal errorStr As String, ByRef strErrMsg As StringBuilder, ByRef returnBoolean As Boolean)

        Try

            '沒有輸入值才會執行，有輸入值則不動作
            If Not CheckHasValue(objCheck) Then

                strErrMsg.Append(errorStr)

                objCheck.Focus()

                returnBoolean = True

            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"欄位檢查 - 設定檢查結果 - 輸入為要檢查的控制項、要顯示的錯誤訊息字串、組合錯誤字串的StringBuilder、要回傳是否有錯的Flag"})
        End Try

    End Sub

#End Region


#Region "     設定要有 Cbo Ckb Dtp Column 的 Hash Table "

    ''' <summary>
    ''' 設定要有 Cbo Ckb Dtp Column 的 Hash Table
    ''' </summary>
    ''' <param name="_ds"></param>
    ''' <remarks>by Sean.Lin on 2012-1-17</remarks>
    Public Function TransforDatatableToHashTable(ByVal _ds As DataSet, ByVal gridAttributeArray As GridAttribute()) As Hashtable

        Dim _hash As New Hashtable()

        _hash.Add(-1, _ds)

        '根據 Column 的屬性 取得 Column的Cell，並加入至Hash Table 中
        For i As Integer = 0 To gridAttributeArray.Count - 1


            Select Case gridAttributeArray(i).columnAttribute

                Case GridColumn.CheckBoxCell

                    Dim tempCheckBoxCell As New Syscom.Client.UCL.CheckBoxCell
                    _hash.Add(gridAttributeArray(i).columnIndex, tempCheckBoxCell)

                Case GridColumn.ComboBoxCell

                    Dim tempComboBoxCell As New Syscom.Client.UCL.ComboBoxCell
                    _hash.Add(gridAttributeArray(i).columnIndex, tempComboBoxCell)


                Case GridColumn.DateTimePickerCell

                    Dim tempUCLDateTimePickerCellUC As New Syscom.Client.UCL.UCLDateTimePickerCellUC
                    _hash.Add(gridAttributeArray(i).columnIndex, tempUCLDateTimePickerCellUC)

                Case GridColumn.TextBoxCell

                    Dim tempTextBoxCell As New Syscom.Client.UCL.TextBoxCell
                    _hash.Add(gridAttributeArray(i).columnIndex, tempTextBoxCell)


                Case GridColumn.ReadOnlyCell

                    Return Nothing

            End Select


        Next

        'Dim txtCell_One As New Syscom.Client.UCL.TextBoxCell
        '_hash.Add(0, txtCell_One)

        'Dim txtCell_Two As New Syscom.Client.UCL.TextBoxCell
        '_hash.Add(1, txtCell_Two)

        'Dim txtCell_Three As New Syscom.Client.UCL.TextBoxCell
        '_hash.Add(2, txtCell_Three)

        'Dim txtCell_Four As New Syscom.Client.UCL.TextBoxCell
        '_hash.Add(3, txtCell_Four)

        'Dim dtpCell_One As New Syscom.Client.UCL.UCLDateTimePickerCellUC
        '_hash.Add(4, dtpCell_One)

        'Dim txtCell_Five As New Syscom.Client.UCL.TextBoxCell
        '_hash.Add(5, txtCell_Five)


        'Dim dtpCell_Two As New Syscom.Client.UCL.UCLDateTimePickerCellUC
        '_hash.Add(6, dtpCell_Two)
         

        Return _hash

    End Function

#End Region
     
End Class
