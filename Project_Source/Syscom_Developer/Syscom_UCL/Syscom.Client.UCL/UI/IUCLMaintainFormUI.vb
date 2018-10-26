'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：基本維護檔底層UI
'=======
'======= 程式說明：基本維護檔底層UI
'=======
'======= 建立日期：2011-11-9
'=======
'======= 開發人員：James.Lee and Sean.Lin
'=============================================================================
'=============================================================================
'=============================================================================

Imports System.Windows.Forms
Imports System.Text
Imports Syscom.Comm.BASE
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Comm.EXP
Imports Syscom.Client.UCL.UCLScreenUtil
Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling

Public Class IUCLMaintainFormUI
    Implements IMaintainFunction

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
        INSERT
        UPDATE
        DELETE
        QUERY
        CLEAR
    End Enum

#End Region

#End Region

#Region "     Overridable 函數宣告 "

    Public Overridable Function insertData() As Boolean Implements IMaintainFunction.insertData
        Throw New Exception("Method insertData must be Overridden")
    End Function
    Public Overridable Function deleteData() As Boolean Implements IMaintainFunction.deleteData
        Throw New Exception("Method deleteData must be Overridden")
    End Function
    Public Overridable Function updateData() As Boolean Implements IMaintainFunction.updateData
        Throw New Exception("Method updateData must be Overridden")
    End Function
    Public Overridable Function queryData() As Boolean Implements IMaintainFunction.queryData
        Throw New Exception("Method queryData must be Overridden")
    End Function
    Public Overridable Sub clearData() Implements IMaintainFunction.clearData
        Throw New Exception("Method clearData must be Overridden")
    End Sub

    Public Overridable Sub dgvCellClick() Implements IMaintainFunction.selectedDgvData
        Throw New Exception("Method dgvCellClick must be Overridden")
    End Sub

#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Try
            Lock(Me)
            MessageHandling.ClearInfoMsg()
            If (insertData()) Then
                controlButton(buttonAction.INSERT)
                '將新增進去的資料反白
                For index As Integer = 0 To dgvShowData.Columns.Count - 1
                    If (dgvShowData.Columns(index).Visible = True) Then
                        dgvShowData.CurrentCell = dgvShowData.Rows(dgvShowData.Rows.Count - 1).Cells(index)
                        Exit For
                    End If
                Next
                'MessageHandling.showInfoByKey("CMMCMMB002")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("CMMCMMB902", New String() {})
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
    ''' 修改
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            Lock(Me)
            MessageHandling.ClearInfoMsg()
            If (updateData()) Then
                'MessageHandling.showInfoByKey("CMMCMMB003")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("CMMCMMB903", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD003")
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
                If (deleteData()) Then
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
            If (queryData()) Then
                controlButton(buttonAction.QUERY)
                If (dgvShowData.CurrentRow IsNot Nothing AndAlso dgvShowData.CurrentRow.Index >= 0) Then dgvShowData.CurrentRow.Selected = False
                'MessageHandling.showInfoByKey("CMMCMMB001")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("CMMCMMB901", New String() {})
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
            clearData()
            controlButton(buttonAction.CLEAR)
            MessageHandling.ClearInfoMsg()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
        MessageHandling.ClearInfoMsg()
    End Sub

    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Try
            MessageHandling.ClearInfoMsg()
            Me.Close()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

    ''' <summary>
    ''' 初始化資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub initialData() Implements IMaintainFunction.initialData

    End Sub

    ''' <summary>
    ''' 初始化畫面
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialize()
        Try
            IUCLMaintainPanel.BringToFront()
            IUCLMaintainPanel.Dock = System.Windows.Forms.DockStyle.Fill

            initialData()
            initializeButton()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#Region "     同步更新DataGridView中的值 "

    ''' <summary>
    ''' 同步更新DataGridView中的值
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-12-8</remarks>
    Public Sub updateDataGridView(ByVal mode As Integer, ByVal ds As DataSet)

        Try

            Select Case mode
                Case buttonAction.INSERT

                    dgvShowData.GetGridDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)

                    dgvShowData.GetDBDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)

                Case buttonAction.UPDATE

                    If ds.Tables(0).PrimaryKey.Count > 0 Then

                        '取得 ds 的 PK 值 
                        '產生一個 Pk 的 object
                        Dim objPkey As Object()
                        objPkey = New Object(ds.Tables(0).PrimaryKey.Count - 1) {}
                        For i As Integer = 0 To ds.Tables(0).PrimaryKey.Count - 1
                            objPkey(i) = ds.Tables(0).Rows(0).Item(ds.Tables(0).PrimaryKey(i).ColumnName).ToString.Trim
                        Next
                         
                        Dim drGrid As DataRow = dgvShowData.GetGridDS.Tables(0).Rows.Find(objPkey)

                            If drGrid Is Nothing Then
                                '不在Grid 上， insert 
                                updateDataGridView(buttonAction.INSERT, ds)

                            Else
                            '在Grid 上，Update Data
                            'update Grid Ds
                            updateDrData(ds.Tables(0).Rows(0), dgvShowData.GetGridDS.Tables(0).Rows.Find(objPkey))
                            'update DB Ds
                            updateDrData(ds.Tables(0).Rows(0), dgvShowData.GetDBDS.Tables(0).Rows.Find(objPkey))
  
                            End If


                        Else

                            dgvShowData.CurrentRow.SetValues(ds.Tables(0).Rows(0).ItemArray)

                        End If

            End Select

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"同步更新DataGridView中的值"})
        End Try

    End Sub

#End Region

#Region "     更新DataGridView中 Datarow 的值 "

    ''' <summary>
    ''' 更新DataGridView中 Datarow 的值
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-11-01</remarks>
    Private Sub updateDrData(ByVal drUpdate As DataRow, ByRef drDgv As DataRow)

        Try

            For i As Integer = 0 To drDgv.Table.Columns.Count - 1

                If drDgv.Table.Columns(i).ReadOnly = True Then
                    '如果是唯讀的欄位，先解唯讀，變更資料之後，繼續鎖定唯讀
                    drDgv.Table.Columns(i).ReadOnly = False
                    drDgv.Item(i) = drUpdate.Item(i).ToString.Trim
                    drDgv.Table.Columns(i).ReadOnly = True
                Else
                    '直接變更資料
                    drDgv.Item(i) = drUpdate.Item(i).ToString.Trim
                End If

            Next

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"更新DataGridView中 Datarow 的值"})
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
    Private Sub IUCLMaintainFormUI2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                '清除
                btnClear.PerformClick()
            Case Keys.F12
                '刪除 SF12
                If e.Shift Then
                    If (btnDelete.Enabled) Then btnDelete.PerformClick()
                Else
                    '新增F12
                    If (btnInsert.Enabled) Then btnInsert.PerformClick()
                End If
            Case Keys.F10
                '修改
                If (btnUpdate.Enabled) Then btnUpdate.PerformClick()
            Case Keys.F1
                '查詢
                btnQuery.PerformClick()
            Case Keys.Escape
                btnExit.PerformClick()
            Case Keys.Enter
                Me.ProcessTabKey(True)
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

#End Region

#End Region

    Private Sub IUCLMaintainFormUI2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
    End Sub

    Private Sub IUCLMaintainFormUI_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            initialize()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
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
            If Not CheckControlHasValue(objCheck) Then

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

   
End Class
