'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBInsuCodeUI.vb
'*              Title:	院內碼對應健保碼檔
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Johsn
'*        Create Date:	2010/06/02
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/


Imports System.Windows.Forms

Imports log4net
Imports System.Text
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.UCL
Imports Syscom.Client.CMM

Public Class PUBInsuCodeUI
    Inherits Com.Syscom.WinFormsUI.Docking.DockContent

    Dim objPub As IPubServiceManager = PubServiceManager.getInstance

    Dim currentUserID As String = AppContext.userProfile.userId

    '獲取維護表名
    Dim tableDB As String = PubInsuCodeDataTableFactory.tableName
    'Grid使用的標題
    Dim columnNameGrid() As String = {"生效日", "健保碼", "名稱", "單價", "數量", _
                                      "急診加成", "兒童加成", "牙科轉診加成", "假日加成", "科別加成", _
                                      "保險費用項目", "停用", "停止日", "Dc", "保險費用項目DB", _
                                      "序號", "醫令代碼", "醫令類別"} ', "狀態"}
    '獲取維護表字段名
    Dim columnNameDB() As String = PubInsuCodeDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubInsuCodeDataTableFactory.columnsLength
    Dim nonVisible As String = "14,15,16,17,18"
    Dim arrreturn As New ArrayList
    Dim strOrderTypeId As String
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        DateTimePicker
        TextBox
        ComboBox
        TextCodeQuery
    End Enum
    Enum buttonAction
        OK
        QUERY
        CLEAR
        DELETE
    End Enum
    Const MAXDATE As String = "9998/12/31"




#Region "初始化"

    Private strOrderCode As String = ""

    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    Public Sub New(ByVal pvtOrderCode As String, ByVal pvtOrderTypeId As String)

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        strOrderCode = pvtOrderCode
        strOrderTypeId = pvtOrderTypeId
    End Sub

#End Region

#Region "事件"

    'load
    Private Sub PUBInsuCodeUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '生效日、停止日
            '20100929 modified by liuye  生效日不要預設值
            'dtpEffectDate.SetValue(Now)
            dtpEndDate.SetValue(MAXDATE)
            'dgv
            dgvShowData.uclColumnCheckBox = True
            dgvShowData.MultiSelect = True

        Catch ex As Exception
            'MessageHandling.showErrorByKey("HEMCMMB006")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("HEMCMMB006", New String() {}, "")
        End Try
    End Sub

    'shown
    Private Sub PUBInsuCodeUI_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Dim dsData As DataSet = genDS(DataSet_Type.Grid)
            Dim drNewRow As DataRow = dsData.Tables(0).NewRow
            Dim cellTextBox As New TextBoxCell
            Dim cellCheckBox1 As New CheckBoxCell
            Dim cellCheckBox2 As New CheckBoxCell
            Dim cellCheckBox3 As New CheckBoxCell
            Dim cellCheckBox4 As New CheckBoxCell
            Dim cellCheckBox5 As New CheckBoxCell
            Dim hashTbl As New Hashtable

            dsData.Tables(0).Rows.Add(drNewRow)
            ' dsData.Tables(0).Rows(0).Item("狀態") = "Insert"
            cellTextBox.MaxLength = 20
            hashTbl.Add(-1, dsData)
            hashTbl.Add(2, cellTextBox)
            '20100929 
            Dim cellTextBoxTqty As New TextBoxCell
            cellTextBoxTqty.uclTextType = TextBoxCell.uclTextTypeData.Integer_Type
            cellTextBoxTqty.uclIntCount = 7
            cellTextBoxTqty.uclDotCount = 2
            hashTbl.Add(5, cellTextBoxTqty)
            hashTbl.Add(6, cellCheckBox1)
            hashTbl.Add(7, cellCheckBox2)
            hashTbl.Add(8, cellCheckBox3)
            hashTbl.Add(9, cellCheckBox4)
            hashTbl.Add(10, cellCheckBox5)
            dgvShowData.Initial(hashTbl)
            dgvShowData.uclNonVisibleColIndex = nonVisible
            dgvShowData.Columns(0).Frozen = True
            If strOrderCode <> "" Then
                txtOrderCode.Text = strOrderCode
                txtOrderCode.Enabled = False
                txtOrderCode.Tag = strOrderTypeId
            End If
            Dim dsInsuCode As DataSet = objPub.queryPubInsuCodeByOrderCode_L(strOrderCode)
            showDgvData(dsInsuCode)
            If txtOrderCode.Enabled Then
                'txtOrderCode.Tag = ""
                If dsInsuCode.Tables(0).Rows.Count > 0 Then
                    txtOrderCode.Tag = dsInsuCode.Tables(0).Rows(0).Item("Order_Type_Id").ToString.Trim
                End If
            End If

            dgvShowData.uclColumnWidth = "90,85,190,75,70,70,70,70,70,70,100,50,90"

        Catch ex As Exception
            'MessageHandling.showErrorByKey("HEMCMMB006")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("HEMCMMB006", New String() {}, "")
        End Try
    End Sub

    Private Sub dgvShowData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShowData.CellClick
        Try
            If Me.txtOrderCode.Enabled Then
                If e.RowIndex <> dgvShowData.Rows.Count - 1 Then
                    Me.dtpEffectDate.Clear()
                    Me.dtpEndDate.Clear()
                    Me.dtpEffectDate.SetValue(dgvShowData.CurrentRow.Cells("生效日").Value.ToString.Trim)
                    Me.dtpEndDate.SetValue(dgvShowData.CurrentRow.Cells("停止日").Value.ToString.Trim)
                    Me.txtOrderCode.Text = dgvShowData.CurrentRow.Cells("醫令代碼").Value.ToString.Trim
                    Me.txtOrderCode.Tag = dgvShowData.CurrentRow.Cells("醫令類別").Value.ToString.Trim

                    btnSure.Enabled = True
                    If dgvShowData.CurrentRow.Cells("Dc").Value.ToString.Trim = "Y" Then
                        btnSure.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'cellValueChanged
    Private Sub dgvShowData_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShowData.CellValueChanged
        Try
            If e.ColumnIndex = 2 Then
                If dgvShowData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim <> "" Then
                    '存在
                    Dim dtData As DataTable = objPub.queryPubNhiCode_L(dgvShowData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim).Tables(0)
                    If dtData.Rows.Count > 0 Then
                        '帶出健保支付資料
                        '名稱
                        dgvShowData.Rows(e.RowIndex).Cells("名稱").Value = dtData.Rows(0).Item("Insu_En_Name").ToString.Trim & dtData.Rows(0).Item("Insu_Name").ToString.Trim
                        '單價
                        dgvShowData.Rows(e.RowIndex).Cells("單價").Value = dtData.Rows(0).Item("Price").ToString.Trim
                        dgvShowData.Rows(e.RowIndex).Cells("數量").Value = "1.00"
                        '急診加成
                        If dtData.Rows(0).Item("Is_Emg_Add").ToString.Trim = "Y" Then
                            dgvShowData.Rows(e.RowIndex).Cells(6).Value = True
                        Else
                            dgvShowData.Rows(e.RowIndex).Cells(6).Value = False
                        End If
                        '兒童加成
                        If dtData.Rows(0).Item("Is_Kid_Add").ToString.Trim = "Y" Then
                            dgvShowData.Rows(e.RowIndex).Cells(7).Value = True
                        Else
                            dgvShowData.Rows(e.RowIndex).Cells(7).Value = False
                        End If
                        '牙科轉診加成
                        If dtData.Rows(0).Item("Is_Dental_Add").ToString.Trim = "Y" Then
                            dgvShowData.Rows(e.RowIndex).Cells(8).Value = True
                        Else
                            dgvShowData.Rows(e.RowIndex).Cells(8).Value = False
                        End If
                        '假日加成
                        If dtData.Rows(0).Item("Is_Holiday_Add").ToString.Trim = "Y" Then
                            dgvShowData.Rows(e.RowIndex).Cells(9).Value = True
                        Else
                            dgvShowData.Rows(e.RowIndex).Cells(9).Value = False
                        End If
                        '科別加成
                        If dtData.Rows(0).Item("Is_Dept_Add").ToString.Trim = "Y" Then
                            dgvShowData.Rows(e.RowIndex).Cells(10).Value = True
                        Else
                            dgvShowData.Rows(e.RowIndex).Cells(10).Value = False
                        End If
                        'Dc
                        dgvShowData.Rows(e.RowIndex).Cells("Dc").Value = "N"
                        dgvShowData.Rows(e.RowIndex).Cells("醫令代碼").Value = ""
                        '保險費用項目
                        dgvShowData.Rows(e.RowIndex).Cells("保險費用項目").Value = dtData.Rows(0).Item("Insu_Account_Id").ToString.Trim & "-" & dtData.Rows(0).Item("Code_Name").ToString.Trim
                        dgvShowData.Rows(e.RowIndex).Cells("保險費用項目DB").Value = dtData.Rows(0).Item("Insu_Account_Id").ToString.Trim
                        '添加空白row
                        If e.RowIndex = dgvShowData.Rows.Count - 1 Then
                            addDgvRow()
                        End If
                    Else
                        '否則彈出窗口
                        MessageBox.Show("健保支付標準檔中不存在健保碼" & dgvShowData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.Trim)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub



    'leave
    Private Sub txtOrderCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrderCode.Leave
        Try
            ScreenUtil.Lock(Me)
            If txtOrderCode.Text.Trim <> "" Then
                '存在
                Dim dtData As DataTable = objPub.queryPubOrderByOrderCode2_L(txtOrderCode.Text.Trim).Tables(0)
                If dtData.Rows.Count > 0 Then
                    txtOrderCode.Tag = dtData.Rows(0).Item("Order_Type_Id").ToString.Trim
                Else
                    '否則
                    txtOrderCode.Tag = ""
                    MessageBox.Show("醫令項目基本檔中不存在醫令項目代碼" & txtOrderCode.Text.Trim & "!!!")
                End If
            Else
                txtOrderCode.Tag = ""
            End If
        Catch ex As Exception
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    'Click
    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Try
            MessageHandling.ClearInfoMsg()
            btnQuery.Focus()
            '清空dgv資料
            clearDgvRow()

            Dim dsData As DataSet = objPub.queryPubInsuCode_L(dtpEffectDate.GetUsDateStr, txtOrderCode.Text.Trim)
            If dsData.Tables(0).Rows.Count = 0 Then
                '查無符合資料
                MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {})
            Else
                showDgvData(dsData)
                MessageHandling.ShowInfoMsg("CMMCMMB001", New String() {})
            End If

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 在dgv中顯示資料
    ''' </summary>
    ''' <param name="dsData"></param>
    ''' <remarks></remarks>
    Sub showDgvData(ByVal dsData As DataSet)

        Dim dsGrid As DataSet = dgvShowData.GetGridDS
        For i As Integer = 0 To dsData.Tables(0).Rows.Count - 1
            '添加新row
            dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("健保碼") = dsData.Tables(0).Rows(i).Item("Insu_Code").ToString.Trim
            dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("名稱") = dsData.Tables(0).Rows(i).Item("Insu_Name").ToString.Trim
            dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("單價") = dsData.Tables(0).Rows(i).Item("Price").ToString.Trim
            dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("數量") = dsData.Tables(0).Rows(i).Item("Tqty").ToString.Trim
            dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("保險費用項目") = dsData.Tables(0).Rows(i).Item("Insu_Account_Id").ToString.Trim & "-" & dsData.Tables(0).Rows(i).Item("Code_Name").ToString.Trim
            dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("保險費用項目DB") = dsData.Tables(0).Rows(i).Item("Insu_Account_Id").ToString.Trim
            dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("序號") = dsData.Tables(0).Rows(i).Item("Insu_Code_Seq").ToString.Trim
            dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("Dc") = dsData.Tables(0).Rows(i).Item("Dc").ToString.Trim
            If dsData.Tables(0).Rows(i).Item("Dc").ToString.Trim = "Y" Then
                dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("停用") = "是"
            Else
                dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("停用") = "否"
            End If
            dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("醫令代碼") = dsData.Tables(0).Rows(i).Item("Order_Code").ToString.Trim
            dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("醫令類別") = dsData.Tables(0).Rows(i).Item("Order_Type_Id").ToString.Trim
            dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("停止日") = CDate(dsData.Tables(0).Rows(i).Item("End_Date").ToString.Trim).ToString("yyyy/MM/dd")
            dsGrid.Tables(0).Rows(dsGrid.Tables(0).Rows.Count - 1).Item("生效日") = CDate(dsData.Tables(0).Rows(i).Item("Effect_Date").ToString.Trim).ToString("yyyy/MM/dd")
            '勾選CheckBox
            If dsData.Tables(0).Rows(i).Item("Is_Emg_Add").ToString.Trim = "Y" Then
                '急診加成
                dgvShowData.Rows(dgvShowData.Rows.Count - 1).Cells(6).Value = True
            End If
            If dsData.Tables(0).Rows(i).Item("Is_Kid_Add").ToString.Trim = "Y" Then
                '兒童加成
                dgvShowData.Rows(dgvShowData.Rows.Count - 1).Cells(7).Value = True
            End If
            If dsData.Tables(0).Rows(i).Item("Is_Dental_Add").ToString.Trim = "Y" Then
                '牙科轉診加成
                dgvShowData.Rows(dgvShowData.Rows.Count - 1).Cells(8).Value = True
            End If
            If dsData.Tables(0).Rows(i).Item("Is_Holiday_Add").ToString.Trim = "Y" Then
                '假日加成
                dgvShowData.Rows(dgvShowData.Rows.Count - 1).Cells(9).Value = True
            End If
            If dsData.Tables(0).Rows(i).Item("Is_Dept_Add").ToString.Trim = "Y" Then
                '科別加成
                dgvShowData.Rows(dgvShowData.Rows.Count - 1).Cells(10).Value = True
            End If
            'dgvShowData.AddNewRow()
            addDgvRow()
        Next

    End Sub


    '''' <summary>
    '''' HotKey設定
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    Private Sub PUBInsuCodeUI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                '清除
                btnClear_Click(sender, e)
            Case Keys.F1
                '查詢
                btnQuery_Click(sender, e)
            Case Keys.F12
                '確定
                If (Me.btnSure.Enabled) Then btnSure_Click(sender, e)
            Case Keys.Shift
                If Keys.F12 Then
                    btnDelete_Click(sender, e)
                End If
            Case Keys.Enter
                Me.ProcessTabKey(True)
        End Select
    End Sub

    Private Sub btnSure_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSure.Click
        Try
            MessageHandling.ClearInfoMsg()
            ScreenUtil.Lock(Me)
            btnSure.Focus()
            '檢核欄位
            If fieldCheckResult(buttonAction.OK) Then
                Exit Sub
            End If
            '取得資料
            If dgvShowData.Rows.Count > 1 Then
                Dim dsData As DataSet = genDS(DataSet_Type.DB)
                Dim sqNo As Integer = objPub.queryPubInsuCodeBySeqNo_L(txtOrderCode.Text.Trim).Tables(0).Rows(0).Item(0)
                Dim SumPriceQ As Decimal = 0
                For i As Integer = 0 To dgvShowData.Rows.Count - 2
                    If dgvShowData.Rows(i).Cells("Dc").Value.ToString.Trim = "N" Then
                        If dgvShowData.Rows(i).Cells("醫令代碼").Value.ToString.Trim = Me.txtOrderCode.Text.Trim OrElse _
                                 dgvShowData.Rows(i).Cells("醫令代碼").Value.ToString.Trim = "" Then
                            Dim drNew As DataRow = dsData.Tables(0).NewRow
                            drNew.Item("Effect_Date") = dtpEffectDate.GetUsDateStr
                            drNew.Item("Order_Type_Id") = txtOrderCode.Tag.ToString.Trim
                            drNew.Item("Order_Code") = txtOrderCode.Text.Trim
                            '序號
                            'If dgvShowData.Rows(i).Cells("狀態").Value.ToString.Trim = "Insert" Then
                            '    drNew.Item("Insu_Code_Seq") = ""
                            '    dgvShowData.Rows(i).Cells("序號").Value = drNew.Item("Insu_Code_Seq")
                            'Else
                            '    drNew.Item("Insu_Code_Seq") = dgvShowData.Rows(i).Cells("序號").Value
                            'End If
                            If dgvShowData.Rows(i).Cells("序號").Value.ToString.Trim = "" Then
                                drNew.Item("Insu_Code_Seq") = sqNo
                                dgvShowData.Rows(i).Cells("序號").Value = sqNo
                                sqNo += 1
                            Else
                                drNew.Item("Insu_Code_Seq") = dgvShowData.Rows(i).Cells("序號").Value.ToString.Trim
                            End If
                            drNew.Item("Is_Multi_Map_Flag") = "Y"
                            drNew.Item("Insu_Code") = dgvShowData.Rows(i).Cells("健保碼").Value
                            drNew.Item("Insu_Name") = dgvShowData.Rows(i).Cells("名稱").Value
                            drNew.Item("Price") = dgvShowData.Rows(i).Cells("單價").Value
                            drNew.Item("Tqty") = dgvShowData.Rows(i).Cells("數量").Value
                            drNew.Item("Insu_Account_Id") = dgvShowData.Rows(i).Cells("保險費用項目DB").Value
                            '急診加成
                            If dgvShowData.Rows(i).Cells(6).Value Then
                                drNew.Item("Is_Emg_Add") = "Y"
                            Else
                                drNew.Item("Is_Emg_Add") = "N"
                            End If
                            '兒童加成
                            If dgvShowData.Rows(i).Cells(7).Value Then
                                drNew.Item("Is_Kid_Add") = "Y"
                            Else
                                drNew.Item("Is_Kid_Add") = "N"
                            End If
                            '牙科轉診加成
                            If dgvShowData.Rows(i).Cells(8).Value Then
                                drNew.Item("Is_Dental_Add") = "Y"
                            Else
                                drNew.Item("Is_Dental_Add") = "N"
                            End If
                            '假日加成
                            If dgvShowData.Rows(i).Cells(9).Value Then
                                drNew.Item("Is_Holiday_Add") = "Y"
                            Else
                                drNew.Item("Is_Holiday_Add") = "N"
                            End If
                            '科別加成
                            If dgvShowData.Rows(i).Cells(10).Value Then
                                drNew.Item("Is_Dept_Add") = "Y"
                            Else
                                drNew.Item("Is_Dept_Add") = "N"
                            End If
                            drNew.Item("Dc") = "N"
                            'drNew.Item("Tqty") = 0
                            drNew.Item("End_Date") = MAXDATE
                            drNew.Item("Create_User") = currentUserID
                            drNew.Item("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                            drNew.Item("Modified_User") = currentUserID
                            drNew.Item("Modified_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                            dsData.Tables(0).Rows.Add(drNew)
                            SumPriceQ = SumPriceQ + ((IIf(dgvShowData.Rows(i).Cells("單價").Value.ToString.Trim = "", 0, dgvShowData.Rows(i).Cells("單價").Value.ToString.Trim)) * IIf(dgvShowData.Rows(i).Cells("數量").Value.ToString.Trim = "", 0, dgvShowData.Rows(i).Cells("數量").Value.ToString.Trim))
                        End If
                    End If
                Next

                If dsData.Tables(0).Rows.Count > 0 Then
                    Dim dsResult As DataSet = objPub.confirmPUBInsuCode_L(dsData)
                    '清空dgv資料
                    clearDgvRow()
                    showDgvData(dsResult)
                    arrreturn.Add("ZZZZZZ")
                    arrreturn.Add(SumPriceQ)
                    'If objPub.confirmPUBInsuCode_L(dsData) > 0 Then

                    'If dgvShowData.Rows.Count > 1 Then
                    '    For i As Integer = 0 To dgvShowData.Rows.Count - 2
                    '        '    If dgvShowData.Rows(i).Cells("狀態").Value.ToString.Trim = "Insert" Then
                    '        '        dgvShowData.Rows(i).Cells("狀態").Value = ""
                    '        '    End If
                    '        dgvShowData.Rows(i).Cells("醫令代碼").Value = Me.txtOrderCode.Text.Trim
                    '    Next
                    'End If
                    MessageHandling.ShowInfoMsg("HEMCMMB005", New String() {})
                    'End If
                End If
            End If

            If Not (Me.txtOrderCode.Enabled) Then
                Me.Close()
            End If

        Catch ex As Exception
            MessageHandling.ShowErrorMsg("HEMCMMD015", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            MessageHandling.ClearInfoMsg()
            ScreenUtil.Lock(Me)
            btnDelete.Focus()
            'If fieldCheckResult(buttonAction.DELETE) Then
            '    Exit Sub
            'End If
            If dgvShowData.Rows.Count > 1 Then
                Dim dsDelete As DataSet = genDS(DataSet_Type.DB)

                For i As Integer = 0 To dgvShowData.Rows.Count - 2
                    If dgvShowData.Rows(i).Cells(0).Value = True Then
                        If dgvShowData.Rows(i).Cells("生效日").Value.ToString.Trim <> "" AndAlso _
                            dgvShowData.Rows(i).Cells("醫令代碼").Value.ToString.Trim <> "" Then
                            Dim drNew As DataRow = dsDelete.Tables(0).NewRow
                            drNew.Item("Effect_Date") = dgvShowData.Rows(i).Cells("生效日").Value.ToString.Trim
                            drNew.Item("Order_Type_Id") = dgvShowData.Rows(i).Cells("醫令類別").Value.ToString.Trim
                            drNew.Item("Order_Code") = dgvShowData.Rows(i).Cells("醫令代碼").Value.ToString.Trim
                            drNew.Item("Insu_Code_Seq") = dgvShowData.Rows(i).Cells("序號").Value.ToString.Trim
                            dsDelete.Tables(0).Rows.Add(drNew)
                        End If
                    End If
                Next

                If dsDelete.Tables(0).Rows.Count > 0 Then
                    objPub.deletePubInsuCode_L(dsDelete)
                End If

                For i As Integer = dgvShowData.Rows.Count - 2 To 0 Step -1
                    If dgvShowData.Rows(i).Cells(0).Value = True Then
                        dgvShowData.Rows.RemoveAt(i)
                    End If
                Next
                MessageHandling.ShowInfoMsg("CMMCMMB004", New String() {})

            End If
        Catch ex As Exception
            
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Try
            If dgvShowData.Rows.Count > 1 Then
                Dim dsUpdate As DataSet = genDS(DataSet_Type.DB)

                For i As Integer = 0 To dgvShowData.Rows.Count - 2
                    If dgvShowData.Rows(i).Cells(0).Value = True Then
                        If dgvShowData.Rows(i).Cells("生效日").Value.ToString.Trim <> "" AndAlso _
                            dgvShowData.Rows(i).Cells("醫令代碼").Value.ToString.Trim <> "" Then
                            Dim drNew As DataRow = dsUpdate.Tables(0).NewRow
                            drNew.Item("Effect_Date") = dgvShowData.Rows(i).Cells("生效日").Value.ToString.Trim
                            drNew.Item("Order_Type_Id") = dgvShowData.Rows(i).Cells("醫令類別").Value.ToString.Trim
                            drNew.Item("Order_Code") = dgvShowData.Rows(i).Cells("醫令代碼").Value.ToString.Trim
                            drNew.Item("Insu_Code_Seq") = dgvShowData.Rows(i).Cells("序號").Value.ToString.Trim
                            dsUpdate.Tables(0).Rows.Add(drNew)
                        End If
                    End If
                Next

                If dsUpdate.Tables(0).Rows.Count > 0 Then
                    objPub.updatePUBInsuCodeByPK_L(dsUpdate)
                End If

                For i As Integer = dgvShowData.Rows.Count - 2 To 0 Step -1
                    If dgvShowData.Rows(i).Cells(0).Value = True Then
                        dgvShowData.Rows(i).Cells("停止日").Value = Now.ToString("yyyy/MM/dd")
                        dgvShowData.Rows(i).Cells("Dc").Value = "Y"
                        dgvShowData.Rows(i).Cells("停用").Value = "是"
                    End If
                Next

            End If
            MessageHandling.ShowInfoMsg("CMMCMMB004", New String() {})
            MessageHandling.ClearInfoMsg()
            ScreenUtil.Lock(Me)
            btnStop.Focus()
        Catch ex As Exception
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            cleanFieldsColor()
            '清除時要清除有效日 20100929
            dtpEffectDate.Clear()
            dtpEndDate.SetValue(MAXDATE)
            If txtOrderCode.Enabled Then
                txtOrderCode.Text = ""
                txtOrderCode.Tag = ""
            End If
            btnSure.Enabled = True

            '清空
            Dim dsGrid As DataSet = dgvShowData.GetGridDS()
            For i As Integer = dsGrid.Tables(0).Rows.Count - 1 To 0 Step -1
                dsGrid.Tables(0).Rows.RemoveAt(i)
            Next
            '添加空row
            addDgvRow()
            MessageHandling.ClearInfoMsg()
        Catch ex As Exception
            MessageHandling.ShowErrorMsg("CMMCMMD006", New String() {}, "")
        End Try
    End Sub

#End Region

#Region "功能"

    ''' <summary>
    ''' 產生一個DataSet並包含一個空的Table 給Grid用 或 DB用
    ''' </summary>
    ''' <param name="type">資料集類型</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function genDS(ByVal type As Integer) As DataSet
        Dim dsTemp As New DataSet
        Select Case type
            Case DataSet_Type.Grid
                '給Grid用Table
                dsTemp.Tables.Add(tableDB)
                For i As Integer = 0 To columnNameGrid.Length - 1
                    dsTemp.Tables(tableDB).Columns.Add(columnNameGrid(i))
                Next
            Case DataSet_Type.DB
                '給DB用Table
                dsTemp.Tables.Add(tableDB)
                For i As Integer = 0 To columnNameDB.Length - 1
                    dsTemp.Tables(tableDB).Columns.Add(columnNameDB(i))
                Next
        End Select
        Return dsTemp
    End Function

    '添加空白row
    Sub addDgvRow()
        'Dim dsGrid As DataSet = dgvShowData.GetGridDS
        'Dim drNew As DataRow = dsGrid.Tables(0).NewRow
        'dsGrid.Tables(0).Rows.Add(drNew)
        'dgvShowData.Rows(dgvShowData.Rows.Count - 1).Cells("狀態").Value = "Insert"
        dgvShowData.AddNewRow()
    End Sub

    '清除資料
    Sub clearDgvRow()
        If dgvShowData.Rows.Count > 1 Then
            For i As Integer = dgvShowData.Rows.Count - 2 To 0 Step -1
                dgvShowData.Rows.RemoveAt(i)
            Next
        End If
    End Sub

    '''' <summary>
    '''' 欄位檢查
    '''' </summary>
    '''' <param name="iButtonFlag">BUTTON標記</param>
    '''' <returns>Boolean</returns>
    '''' <remarks>True 失敗;False 成功</remarks>
    Private Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean
        Try
            Dim blnReturnFlag As Boolean = False
            Dim strErrMsg1 As StringBuilder = New StringBuilder
            '設定需要檢查的欄位
            Dim ctlDtpEffectDate As Control = Me.dtpEffectDate
            Dim ctlTxtOrderCode As Control = Me.txtOrderCode
            Dim ctlObjFocus As Control = ctlDtpEffectDate
            '清除欄位背景色
            cleanFieldsColor()
            '針對確定按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.OK, buttonAction.DELETE
                    If Not fieldCheckNull(ctlDtpEffectDate, Control_Type.DateTimePicker) Then
                        strErrMsg1.Append("生效日")
                        ctlObjFocus = ctlDtpEffectDate
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtOrderCode, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("醫令項目代碼")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtOrderCode
                        End If
                        blnReturnFlag = True
                    End If
            End Select

            '欄位check錯誤
            If blnReturnFlag Then
                Dim strMsgs(0) As String
                Dim i As Integer = 0
                If strErrMsg1.Length > 0 Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB101", New String() {strErrMsg1.ToString})
                    i += 1
                End If
                'MessageHandling.showErrors(strMsgs)
                '********************2010/2/9 Modify By Alan**********************
                Dim pvtErrorMsg As String = ""
                For i = 0 To strMsgs.Length - 1
                    If i <> 0 Then
                        pvtErrorMsg = pvtErrorMsg & vbCrLf & strMsgs(i)
                    Else
                        pvtErrorMsg = strMsgs(i)
                    End If
                Next
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {pvtErrorMsg}, "")
                ctlObjFocus.Focus()
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 檢查是否為空白
    ''' </summary>
    ''' <param name="ctl">控件</param>
    ''' <param name="ctType">控件類型</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 合法;False 非法</remarks>
    Private Function fieldCheckNull(ByVal ctl As Control, ByVal ctType As Integer) As Boolean
        Select Case ctType
            Case Control_Type.TextBox
                If ctl.Text.Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.ComboBox
                Dim objCtl As Syscom.Client.UCL.UCLComboBoxUC = ctl
                If objCtl.SelectedValue.Trim = "" Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.DateTimePicker
                Dim objCtl As Syscom.Client.UCL.UCLDateTimePickerUC = ctl
                If objCtl.GetUsDateStr.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.TextCodeQuery
                If CType(ctl, UCLTextCodeQueryUI).uclCodeValue1.Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
        End Select
    End Function


    Sub cleanFieldsColor()
        Me.dtpEffectDate.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        Me.txtOrderCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
    End Sub
#End Region


#Region "回傳"
    Public Overloads Function ShowDialog() As ArrayList
        Try
            MyBase.ShowDialog()
            Return arrreturn
            'If arrreturn IsNot Nothing Then
            '    Return arrreturn
            'Else
            '    Return Nothing
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region



End Class