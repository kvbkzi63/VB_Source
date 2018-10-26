Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports Syscom.Client.CMM
Imports System.Text
Imports System.Windows.Forms
Imports Syscom.Comm.BASE

Public Class UCLOpenWindowUI

#Region "全域變數宣告"

    Public pvtQueryTable As Integer
    Public pvtQueryValue As String
    Public pvtCodeVaule1 As String
    Public pvtCodeVaule2 As String
    Public pvtQueryField As String

    Public pvtCodeName As String
    Dim pvtStateFlag = True
    Dim pvtDS As DataSet
    Dim WithEvents mgr As EventManager = EventManager.getInstance '宣告EventManager
    Private _uclXPosition As Integer = 0
    Private _uclYPosition As Integer = 0
    Public ctlName As String
    Public returnDSFlag As Boolean = False
    Dim returnDS As New DataSet
    Dim queryDS As DataSet

    Public RefHosp As Integer = 0 ' 0:全部 1:Is_South_Area ='Y' 2:Is_South_Area<>'Y' 3:Is_Dialysis_Center='Y'
    Dim OtherQueryConditionDS As DataSet

    Public IsCheckDoctorOnDuty As Boolean = False
    Private IsCanSelectReserveChartNoForMultiChartNo As Boolean = True '多個病歷號時,是否顯示最新的病歷號 (含被合併的)
    Private Area_Code As String = ""

    Dim MyParent As UCLTextCodeQueryUI

#End Region

#Region "屬性設定"

    Public Property uclXPosition() As Integer
        Get
            Return _uclXPosition
        End Get
        Set(ByVal value As Integer)
            _uclXPosition = value
        End Set
    End Property
    Public Property uclYPosition() As Integer
        Get
            Return _uclYPosition
        End Get
        Set(ByVal value As Integer)
            _uclYPosition = value
        End Set
    End Property

#End Region

    Public Sub SetMyParent(ByRef MyParent As UCLTextCodeQueryUI)
        Me.MyParent = MyParent
    End Sub

    Public Sub SetOtherQueryConditionDS(ByRef ds)
        OtherQueryConditionDS = ds
    End Sub


#Region "Event"

    Private Sub doUclOpenWindow(ByVal uclName As String, ByVal uclTableName As String, ByVal uclQueryValue As String) Handles mgr.UclOpenWindow
        '取得前依畫面傳入參數值
        ctlName = uclName
        pvtQueryTable = uclTableName
        pvtQueryField = ""
        pvtQueryValue = uclQueryValue
    End Sub

    Private Sub doUclOpenWindow2(ByVal uclName As String, ByVal uclTableName As String, ByVal uclQueryField As String, ByVal uclQueryValue As String) Handles mgr.UclOpenWindow2
        '取得前依畫面傳入參數值
        ctlName = uclName
        pvtQueryTable = uclTableName
        pvtQueryField = uclQueryField
        pvtQueryValue = uclQueryValue
    End Sub

    Public Sub UCLOpenWindowUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            '畫面初始設定
            setInitData()

            If queryDS IsNot Nothing Then
                Cbo_QueryField.SelectedValue = queryDS.Tables(0).Rows(0).Item(0).ToString.Trim
                Txt_QueryValue.Text = queryDS.Tables(0).Rows(0).Item(1).ToString.Trim

                QueryProcess()
            End If


            If pvtStateFlag = True Then
                pvtStateFlag = False
                Txt_QueryValue.Focus()

                If UCLFormUtil.isResizeable Then
                    UCLFormUtil.ReDrawForm(Me)
                End If

                If queryDS IsNot Nothing Then
                    Me.Show()
                Else
                    Me.ShowDialog()
                End If


            End If

            If pvtQueryTable = 1 Then
                Me.Text = "醫師"
            ElseIf pvtQueryTable = 2 Then
                Me.Text = "診間號"
            ElseIf pvtQueryTable = 3 Then
                Me.Text = "病患基本"
            ElseIf pvtQueryTable = 4 Then
                Me.Text = "重大傷病"
            ElseIf pvtQueryTable = 5 Then
                Me.Text = "排程醫令"
            ElseIf pvtQueryTable = 6 Then
                Me.Text = "科室"
            ElseIf pvtQueryTable = 7 Then
                Me.Text = "表單類別"
            ElseIf pvtQueryTable = 8 Then
                Me.Text = "轉診醫院"
                Dim uclOW As IUclServiceManager = UclServiceManager.getInstance
                Dim ds As DataSet = uclOW.queryOpenWindow(108, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                If ds.Tables.Count > 0 Then
                    DGV_DataView.DataSource = ds.Tables(0)
                End If
            ElseIf pvtQueryTable = 9 Then
                Me.Text = "醫令項目基本"
            ElseIf pvtQueryTable = 10 Then
                Me.Text = "檢查儀器維護"
            ElseIf pvtQueryTable = 11 Then
                Me.Text = "日班表"
            ElseIf pvtQueryTable = 12 Then
                Me.Text = "員工"
            ElseIf pvtQueryTable = 13 Then
                Me.Text = "醫師"
            ElseIf pvtQueryTable = 14 Then
                Me.Text = "醫令項目"
            ElseIf pvtQueryTable = 15 Then
                Me.Text = "藥師基本"
            ElseIf pvtQueryTable = 16 Then
                Me.Text = "次專科基本"
            ElseIf pvtQueryTable = 17 Then
                Me.Text = "藥理分類"
            ElseIf pvtQueryTable = 18 Then
                Me.Text = "藥品代碼分類明細"
            ElseIf pvtQueryTable = 21 Then
                Me.Text = "醫令項目基本"
            ElseIf pvtQueryTable = 27 Then
                Me.Text = "代碼"
            ElseIf pvtQueryTable = 28 Then
                Me.Text = "轉介病人"
            ElseIf pvtQueryTable = 29 Then
                Me.Text = "轉出病人"
            ElseIf pvtQueryTable = 30 Then
                Me.Text = "藥品基本"
            ElseIf pvtQueryTable = 33 Then
                Me.Text = "醫令項目"
            ElseIf pvtQueryTable = 34 Then
                Me.Text = "醫令項目"
            ElseIf pvtQueryTable = 36 Then
                Me.Text = "日班表"
            ElseIf pvtQueryTable = 37 Then
                Me.Text = "醫師"
            ElseIf pvtQueryTable = 38 Then
                Me.Text = "合約機構基本"
            ElseIf pvtQueryTable = 40 Then
                Me.Text = "醫師"
            ElseIf pvtQueryTable = 41 Then
                Me.Text = "科室"
            ElseIf pvtQueryTable = 42 Then
                Me.Text = "員工代碼檔"

            ElseIf pvtQueryTable = 50 Then
                Me.Text = "疾病分類"
            ElseIf pvtQueryTable = 51 Then
                Me.Text = "健保科別"
            ElseIf pvtQueryTable = 52 Then
                Me.Text = "地區查詢"
            ElseIf pvtQueryTable = 53 Then
                Me.Text = "地區查詢"
            ElseIf pvtQueryTable = 54 Then
                Me.Text = "健保碼查詢"
            ElseIf pvtQueryTable = 60 Then
                Me.Text = "TW_DRGs基本檔"
            ElseIf pvtQueryTable = 61 Then
                Me.Text = "MDC主要疾病類別檔"
            ElseIf pvtQueryTable = 62 Then
                Me.Text = "護理站科別檔"
            ElseIf pvtQueryTable = 63 Then
                Me.Text = "消耗單位基本檔"
            ElseIf pvtQueryTable = 70 Then
                Me.Text = "細菌/結果"
            ElseIf pvtQueryTable = 98 Then
                Me.Text = "醫師"
            ElseIf pvtQueryTable = 99 Then
                Me.Text = "醫師"
            ElseIf pvtQueryTable = 303 Then
                Me.Text = "院內藥品屬性"
            ElseIf pvtQueryTable = 501 Then
                Me.Text = "員工"
            ElseIf pvtQueryTable = 502 Then
                Me.Text = "院內藥品屬性"
            End If

            Me.Text += " 資料查詢"

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Sub SetAreaCode(ByVal AreaCode As String)
        Area_Code = AreaCode
    End Sub

    Public Sub SetIsCanSelectReserveChartNoForMultiChartNo(ByVal Is_CanSelectReserveChartNoForMultiChartNo As Boolean)
        IsCanSelectReserveChartNoForMultiChartNo = Is_CanSelectReserveChartNoForMultiChartNo
    End Sub

    Private Sub UCLOpenWindowUI_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        'Me.Location = New Drawing.Point(_uclXPosition, _uclYPosition)
    End Sub

    Private Sub UCLOpenWindowUI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Btn_Query_Click(sender, e)
            Case Keys.F5
                Me.Close()
        End Select

    End Sub


    Private Sub Btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Query.Click

        Try

            UCLScreenUtil.Lock(Me)

            If Txt_QueryValue.Text.Contains("'") Then
                Txt_QueryValue.Text.Replace("'", "''")
            End If

            If pvtQueryTable = 3 Then

                If Txt_QueryValue.Visible Then


                    '病患基本檔  不能輸入空白查詢 資料太多
                    If Cbo_QueryField.SelectedValue = "Chart_No" AndAlso Txt_QueryValue.Text.Trim.Length < 4 Then
                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"病歷號至少輸入4碼!"}, "")
                        Exit Sub

                    End If

                    If Txt_QueryValue.Text.Trim = "" Then
                        'MessageHandling.showError("查詢欄位不可為空白!")
                        '********************2010/2/9 Modify By Alan**********************

                        MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查詢欄位不可為空白!"}, "")
                        Exit Sub
                    End If
                End If

                If dtp.Visible AndAlso Not IsDate(dtp.GetUsDateStr) Then

                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"日期不可為空白!"}, "")
                    Exit Sub
                End If

            End If


            If pvtQueryTable = 11 OrElse pvtQueryTable = 36 Then '日, 週班表查詢

                If Txt_QueryValue.Text.Trim = "" Then
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查詢條件不可為空白!"}, "")
                    Exit Sub
                End If

            End If


            If pvtQueryTable = 33 OrElse pvtQueryTable = 34 Then

                If Txt_QueryValue.Text.Trim = "" Then
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查詢條件不可為空白!"}, "")
                    Exit Sub
                End If

            End If

            If pvtQueryTable = 40 Then

                If Txt_QueryValue.Text.Trim = "" Then
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查詢條件不可為空白!"}, "")
                    Exit Sub
                End If

            End If

            If pvtQueryTable = 53 AndAlso Area_Code = "" Then

                If Txt_QueryValue.Text.Trim = "" Then
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查詢條件不可為空白!"}, "")
                    Exit Sub
                End If

            End If


            QueryProcess()


        Catch ex As Exception
            'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try

    End Sub



    ''' <summary>
    ''' 醫生檢核
    ''' </summary>
    ''' <param name="EmpCode">醫師代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckLoginDr(ByVal EmpCode As String) As Boolean
        Return True
    End Function


    Private Sub DGV_DataView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV_DataView.DoubleClick

        Try
            Dim pDataRowView As DataRowView = Nothing
            If DGV_DataView.ContainsFocus AndAlso DGV_DataView.CurrentCellAddress.Y >= 0 Then
                pDataRowView = DGV_DataView.Rows(DGV_DataView.CurrentCellAddress.Y).DataBoundItem
            End If

            'Dim pvtSelRow As Integer = DGV_DataView.CurrentCellAddress.Y  'DGV_DataView.SelectedRows(0).Index

            If pDataRowView Is Nothing Then
                Exit Sub
            End If

            returnDS.Tables.Clear()

            returnDS.Tables.Add(DGV_DataView.DataSource.Clone)
            returnDS.Tables(0).Rows.Add(pDataRowView.Row.ItemArray)

            If pvtDS IsNot Nothing AndAlso pvtDS.Tables.Count > 1 Then
                returnDS.Tables.Add(pvtDS.Tables(1).Clone)
                returnDS.Tables(1).Rows.Add(pvtDS.Tables(1).Rows(DGV_DataView.CurrentCellAddress.Y).ItemArray)
            End If

            Select Case pvtQueryTable
                Case 1

                    If IsCheckDoctorOnDuty Then

                        If CheckLoginDr(pDataRowView.Item(3).ToString) Then
                            '檢核通過
                            pvtCodeVaule1 = pDataRowView.Item(3).ToString
                            pvtCodeVaule2 = pDataRowView.Item(0).ToString
                            pvtCodeName = pDataRowView.Item(1).ToString

                        Else
                            '檢核未通過
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"此醫師非在職!!"}, "")

                            Exit Sub
                        End If

                    Else

                        '不進行 檢核 
                        pvtCodeVaule1 = pDataRowView.Item(3).ToString
                        pvtCodeVaule2 = pDataRowView.Item(0).ToString
                        pvtCodeName = pDataRowView.Item(1).ToString


                    End If


                Case 2
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(4).ToString
                    pvtCodeName = pDataRowView.Item(1).ToString


                Case 3
                    '病歷主檔
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(3).ToString
                    pvtCodeName = pDataRowView.Item(1).ToString

                    If Not IsCanSelectReserveChartNoForMultiChartNo AndAlso pDataRowView.Item(9) IsNot DBNull.Value AndAlso pDataRowView.Item(9).ToString.Trim <> "" Then
                        MessageBox.Show("此病歷號已被合併，不可選擇！")
                        Exit Sub
                    End If

                Case 4
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(2).ToString
                    pvtCodeName = pDataRowView.Item(1).ToString


                Case 5
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = ""
                    pvtCodeName = pDataRowView.Item(1).ToString


                Case 6
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    Try
                        pvtCodeVaule2 = pDataRowView.Item(2).ToString
                    Catch ex As Exception
                        pvtCodeVaule2 = ""
                    End Try

                    pvtCodeName = pDataRowView.Item(1).ToString


                Case 7
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = ""
                    pvtCodeName = pDataRowView.Item(1).ToString


                Case 8
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(6).ToString '以前抓是否為策略聯盟，目前改抓地址
                    pvtCodeName = pDataRowView.Item(1).ToString

                Case 9
                    If returnDS IsNot Nothing AndAlso returnDS.Tables.Count > 0 AndAlso returnDS.Tables(0).Rows.Count > 0 Then

                        If returnDS.Tables(0).Columns.Contains("健保碼") Then
                            pvtCodeVaule1 = pDataRowView.Item(2).ToString
                            pvtCodeVaule2 = pDataRowView.Item(0).ToString
                            pvtCodeName = pDataRowView.Item(3).ToString


                        Else
                            pvtCodeVaule1 = pDataRowView.Item(0).ToString
                            pvtCodeVaule2 = pDataRowView.Item(3).ToString   'modified by LingAn merry_jing 2009/6/26 醫令類型
                            pvtCodeName = pDataRowView.Item(1).ToString  'modified by LingAn merry_jing 2009/6/26

                        End If

                    End If


                Case 10
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = ""
                    pvtCodeName = pDataRowView.Item(1).ToString


                Case 11
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = ""
                    pvtCodeName = pDataRowView.Item(1).ToString


                Case 12
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(3).ToString
                    pvtCodeName = pDataRowView.Item(1).ToString

                Case 13
                    pvtCodeVaule1 = pDataRowView.Item(3).ToString
                    pvtCodeVaule2 = pDataRowView.Item(0).ToString

                    pvtCodeName = pDataRowView.Item(1).ToString


                Case 14

                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(2).ToString
                    pvtCodeName = pDataRowView.Item(1).ToString

                Case 15

                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(5).ToString
                    pvtCodeName = pDataRowView.Item(1).ToString

                Case 16

                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(2).ToString '次專科英文名稱
                    pvtCodeName = pDataRowView.Item(1).ToString  '次專科名稱

                Case 17

                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(2).ToString '中文名稱
                    pvtCodeName = pDataRowView.Item(1).ToString  '英文名稱

                Case 18

                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(2).ToString '中文名稱
                    pvtCodeName = pDataRowView.Item(1).ToString  '英文名稱

                    '18,19,20多選


                Case 21

                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(3).ToString   'modified by LingAn merry_jing 2009/6/26 醫令類型
                    pvtCodeName = pDataRowView.Item(1).ToString  'modified by LingAn merry_jing 2009/6/26

                Case 27

                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = "" ' "' pDataRowView.Item(3).ToString    "
                    pvtCodeName = pDataRowView.Item(1).ToString  'modified by LingAn merry_jing 2009/6/26


                Case 28

                    pvtCodeVaule1 = pDataRowView.Item(14).ToString
                    pvtCodeVaule2 = pDataRowView.Item(14).ToString
                    pvtCodeName = pDataRowView.Item(14).ToString


                Case 29

                    pvtCodeVaule1 = pDataRowView.Item(14).ToString
                    pvtCodeVaule2 = pDataRowView.Item(14).ToString
                    pvtCodeName = pDataRowView.Item(14).ToString


                Case 30

                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(1).ToString
                    pvtCodeName = pDataRowView.Item(2).ToString

                Case 33

                    If returnDS IsNot Nothing AndAlso returnDS.Tables.Count > 0 AndAlso returnDS.Tables(0).Rows.Count > 0 Then
                        If returnDS.Tables(0).Columns.Contains("健保碼") Then

                            pvtCodeVaule1 = pDataRowView.Item(2).ToString
                            pvtCodeVaule2 = pDataRowView.Item(0).ToString
                            pvtCodeName = pDataRowView.Item(3).ToString

                        Else
                            pvtCodeVaule1 = pDataRowView.Item(0).ToString
                            pvtCodeVaule2 = pDataRowView.Item(2).ToString
                            pvtCodeName = pDataRowView.Item(1).ToString

                        End If
                    End If


                Case 34

                    If returnDS IsNot Nothing AndAlso returnDS.Tables.Count > 0 AndAlso returnDS.Tables(0).Rows.Count > 0 Then
                        If returnDS.Tables(0).Columns.Contains("健保碼") Then

                            pvtCodeVaule1 = pDataRowView.Item(2).ToString
                            pvtCodeVaule2 = pDataRowView.Item(0).ToString
                            pvtCodeName = pDataRowView.Item(3).ToString

                        Else
                            pvtCodeVaule1 = pDataRowView.Item(0).ToString
                            pvtCodeVaule2 = pDataRowView.Item(2).ToString
                            pvtCodeName = pDataRowView.Item(1).ToString

                        End If
                    End If


                Case 36
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = ""
                    pvtCodeName = pDataRowView.Item(1).ToString

                Case 37
                    If IsCheckDoctorOnDuty Then

                        If CheckLoginDr(pDataRowView.Item(3).ToString) Then
                            '檢核通過
                            pvtCodeVaule1 = pDataRowView.Item(3).ToString
                            pvtCodeVaule2 = pDataRowView.Item(0).ToString
                            pvtCodeName = pDataRowView.Item(1).ToString

                        Else
                            '檢核未通過
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"此醫師非在職!!"}, "")

                            Exit Sub
                        End If

                    Else

                        '不進行 檢核 
                        pvtCodeVaule1 = pDataRowView.Item(3).ToString
                        pvtCodeVaule2 = pDataRowView.Item(0).ToString
                        pvtCodeName = pDataRowView.Item(1).ToString


                    End If

                Case 38
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = ""
                    pvtCodeName = pDataRowView.Item(1).ToString

                Case 40
                    pvtCodeVaule1 = pDataRowView.Item(3).ToString
                    pvtCodeVaule2 = pDataRowView.Item(0).ToString
                    pvtCodeName = pDataRowView.Item(1).ToString

                Case 41
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    Try
                        pvtCodeVaule2 = pDataRowView.Item(2).ToString
                    Catch ex As Exception
                        pvtCodeVaule2 = ""
                    End Try

                    pvtCodeName = pDataRowView.Item(1).ToString

                Case 42
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(3).ToString
                    pvtCodeName = pDataRowView.Item(1).ToString

                Case 50
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(1).ToString
                    pvtCodeName = pDataRowView.Item(2).ToString

                Case 51
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    Try
                        pvtCodeVaule2 = pDataRowView.Item(2).ToString
                    Catch ex As Exception
                        pvtCodeVaule2 = ""
                    End Try

                    pvtCodeName = pDataRowView.Item(1).ToString


                Case 52
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString 'Area_Code
                    pvtCodeVaule2 = pDataRowView.Item(9).ToString 'Dist_Code
                    pvtCodeName = pDataRowView.Item(1).ToString 'Area_Name

                Case 53
                    pvtCodeVaule1 = pDataRowView.Item(3).ToString 'Vil_Code
                    pvtCodeVaule2 = pDataRowView.Item(11).ToString 'Dist_Code
                    pvtCodeName = pDataRowView.Item(0).ToString 'Vil_Name
                Case 54
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString '健保碼
                    pvtCodeVaule2 = pDataRowView.Item(1).ToString '健保中文名稱
                    pvtCodeName = pDataRowView.Item(2).ToString '健保英文名稱
                Case 60

                    pvtCodeName = pDataRowView.Item(1).ToString.Trim()    'TW_DRGs英文名稱
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString.Trim()  'TW_DRGs碼
                    pvtCodeVaule2 = pDataRowView.Item(2).ToString.Trim()  'TW_DRGs名稱

                Case 61

                    pvtCodeName = pDataRowView.Item(1).ToString.Trim()    '主要疾病類別MDC英文名稱
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString.Trim()  '主要疾病類別MDC碼
                    pvtCodeVaule2 = pDataRowView.Item(2).ToString.Trim()  '主要疾病類別MDC名稱
                Case 62
                    pvtCodeName = pDataRowView.Item(1).ToString   '護理站代碼
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString.Trim()  '護理站名稱
                    pvtCodeVaule2 = pDataRowView.Item(3).ToString.Trim()  '消耗單位
                Case 63
                    pvtCodeName = pDataRowView.Item(1).ToString   '消耗單位名稱
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString.Trim()  '消耗單位代碼
                    pvtCodeVaule2 = pDataRowView.Item(0).ToString.Trim()  '消耗單位代碼
                Case 70 '細菌/結果
                    pvtCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '代碼
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString                    '名稱
                Case 98
                    '所有醫生
                    '不進行 檢核 
                    pvtCodeVaule1 = pDataRowView.Item(3).ToString
                    pvtCodeVaule2 = pDataRowView.Item(0).ToString
                    pvtCodeName = pDataRowView.Item(1).ToString

                Case 99
                    'OHD 申報醫生
                    '不進行 檢核 
                    pvtCodeVaule1 = pDataRowView.Item(3).ToString
                    pvtCodeVaule2 = pDataRowView.Item(0).ToString
                    pvtCodeName = pDataRowView.Item(1).ToString

                Case 303   '303:院內藥品屬性 TypeId=303

                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(2).ToString '英文名稱
                    pvtCodeName = pDataRowView.Item(1).ToString  '中文名稱


                Case 500 '500:LAB_Item

                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(2).ToString '英文名稱
                    pvtCodeName = pDataRowView.Item(1).ToString  '中文名稱

                Case 501
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(3).ToString
                    pvtCodeName = pDataRowView.Item(1).ToString

                Case 502
                    pvtCodeVaule1 = pDataRowView.Item(0).ToString
                    pvtCodeVaule2 = pDataRowView.Item(2).ToString
                    pvtCodeName = pDataRowView.Item(1).ToString

            End Select

            '啟動EventManager的RaiseEvent
            If mgr Is Nothing Then
                mgr = EventManager.getInstance
            End If
            If returnDSFlag Then
                mgr.RaiseUclOpenWindowValue2(ctlName, returnDS)
            Else
                '不知道為啥Close沒作用  只好先把它隱藏起來以免遮到後續會用到的視窗
                Me.Visible = False
                Try
                    mgr.RaiseUclOpenWindowValue(ctlName, pvtCodeVaule1, pvtCodeVaule2, pvtCodeName)
                Catch ex As Exception
                    Me.MyParent.doUclOpenWindowValue(ctlName, pvtCodeVaule1, pvtCodeVaule2, pvtCodeName)
                End Try
            End If

            If Me.MyParent IsNot Nothing Then
                Me.MyParent.OpenWindowDoubleClick()
            End If


        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            'MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {ex.ToString}, "")
        Finally
            Me.Close()
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

#End Region

    ''' <summary>
    ''' 設定查詢資料
    ''' qDS:查詢資料
    ''' IsReturnDS:是否回傳DataSet 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetQueryData(ByVal qDS As DataSet, ByVal IsReturnDS As Boolean)

        queryDS = qDS

        returnDSFlag = IsReturnDS

    End Sub


    ''' <summary>
    '''  進行查詢
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub QueryProcess()

        Try


            Dim pvtExeQuery = True

            '取得資料

            Dim uclOW As IUclServiceManager = UclServiceManager.getInstance

            Select Case pvtQueryTable
                Case 1
                    If Cbo_QueryField.SelectedValue = "B.Employee_Name" Then
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)
                    Else
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)
                    End If

                Case 2
                    'If pvtQueryValue = "" Then
                    '    'MessageHandling.showWarn("請輸入診間號")
                    '    '********************2010/2/9 Modify By Alan**********************
                    '    MessageHandling.showWarnMsg("CMMCMMB300",New String(){"請輸入診間號"} )
                    '    pvtExeQuery = False
                    'Else
                    '    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, "Zone_Id︿" & Cbo_QueryField.SelectedValue, pvtQueryValue & "︿" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    'End If
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, "Zone_Id︿" & Cbo_QueryField.SelectedValue, pvtQueryValue & " ︿" & "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 3

                    If Not dtp.Visible Then
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    Else
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, dtp.GetUsDateStr, "=", Nothing)
                    End If

                Case 4
                    '20130424 by ccr  icd code 處置碼有些有二碼,故不能控制長度必需為 3,改為2
                    If Cbo_QueryField.SelectedValue = "Icd_Code" AndAlso Txt_QueryValue.Text.Trim.Length < 2 Then
                        'MessageBox.Show("疾病分類碼之條件值至少輸入3碼")
                        'MessageHandling.showWarn("疾病分類碼之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"疾病分類碼之條件值至少輸入2碼"})
                        pvtExeQuery = False
                    ElseIf Cbo_QueryField.SelectedValue = "Disease_En_Name" AndAlso Txt_QueryValue.Text.Trim.Length < 3 Then
                        'MessageBox.Show("英文名稱之條件值至少輸入3碼")
                        'MessageHandling.showWarn("英文名稱之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"英文名稱之條件值至少輸入3碼"})
                        pvtExeQuery = False
                    ElseIf Cbo_QueryField.SelectedValue = "Disease_Name" AndAlso Txt_QueryValue.Text.Trim.Length < 3 Then
                        ' MessageBox.Show("中文名稱之條件值至少輸入3碼")
                        'MessageHandling.showWarn("中文名稱之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"中文名稱之條件值至少輸入3碼"})
                        pvtExeQuery = False
                    Else
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    End If


                Case 5
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                Case 6
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)

                Case 7
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 8 '轉診醫院

                    'If Cbo_QueryField.SelectedValue = "A.Hospital_Name" AndAlso Txt_QueryValue.Text.Trim.Length < 2 Then
                    '    MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"醫院名稱之條件值至少輸入2碼"})
                    '    pvtExeQuery = False

                    'Else

                    Dim allQuery As String = ""

                    If Cbo_QueryField.SelectedValue = "A.Hospital_Name" Then
                        allQuery = "%"
                    End If

                    If RefHosp = 0 Then
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, allQuery & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    ElseIf RefHosp = 1 Then

                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, allQuery & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)

                    ElseIf RefHosp = 2 Then


                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, allQuery & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)

                    ElseIf RefHosp = 3 Then


                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, allQuery & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)


                    End If


                    'End If



                Case 9
                    If Cbo_QueryField.SelectedValue = "Order_Code" AndAlso Txt_QueryValue.Text.Trim.Length < 3 Then
                        'MessageBox.Show("醫令項目代碼之條件值至少輸入3碼")
                        'MessageHandling.showWarn("醫令項目代碼之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"醫令項目代碼之條件值至少輸入3碼"})
                        pvtExeQuery = False
                    ElseIf Cbo_QueryField.SelectedValue = "Order_En_Name" AndAlso Txt_QueryValue.Text.Length < 3 Then
                        'MessageBox.Show("英文名稱之條件值至少輸入3碼")
                        'MessageHandling.showWarn("英文名稱之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"英文名稱之條件值至少輸入3碼"})
                        pvtExeQuery = False
                    ElseIf Cbo_QueryField.SelectedValue = "Order_Name" AndAlso Txt_QueryValue.Text.Length < 3 Then
                        'MessageBox.Show("中文名稱之條件值至少輸入3碼")
                        'MessageHandling.showWarn("中文名稱之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"中文名稱之條件值至少輸入3碼"})
                        pvtExeQuery = False
                    ElseIf Cbo_QueryField.SelectedValue = "Insu_Code" AndAlso Txt_QueryValue.Text.Trim = "" Then
                        'MessageBox.Show("醫令類型之條件值不可為空白")
                        'MessageHandling.showWarn("醫令類型之條件值不可為空白")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"健保碼不可為空白"})
                        pvtExeQuery = False

                    ElseIf Cbo_QueryField.SelectedValue = "Order_Type_Id" AndAlso Txt_QueryValue.Text.Trim = "" Then

                    Else
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    End If


                Case 10
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)


                Case 11

                    '日班表查詢

                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                    If pvtDS IsNot Nothing AndAlso pvtDS.Tables.Count > 0 Then
                        pvtDS.Tables(0).Columns("星期").ReadOnly = False

                        For i As Integer = 0 To pvtDS.Tables(0).Rows.Count - 1

                            If IsDate(pvtDS.Tables(0).Rows(i).Item("日期")) Then

                                If Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 1 Then
                                    '星期日
                                    pvtDS.Tables(0).Rows(i).Item("星期") = "星期日"

                                ElseIf Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 2 Then
                                    pvtDS.Tables(0).Rows(i).Item("星期") = "星期一"

                                ElseIf Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 3 Then
                                    pvtDS.Tables(0).Rows(i).Item("星期") = "星期二"

                                ElseIf Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 4 Then
                                    pvtDS.Tables(0).Rows(i).Item("星期") = "星期三"

                                ElseIf Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 5 Then
                                    pvtDS.Tables(0).Rows(i).Item("星期") = "星期四"

                                ElseIf Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 6 Then
                                    pvtDS.Tables(0).Rows(i).Item("星期") = "星期五"

                                ElseIf Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 7 Then

                                    '星期6
                                    pvtDS.Tables(0).Rows(i).Item("星期") = "星期六"

                                End If

                            End If

                        Next

                    End If


                Case 12
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)

                Case 13
                    If pvtQueryValue = "" Then
                        'MessageBox.Show("請輸入科別")
                        'MessageHandling.showWarn("請輸入科別")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入科別"})
                        pvtExeQuery = False
                    Else
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, "A.Dept_Code︿" & Cbo_QueryField.SelectedValue, pvtQueryValue & "︿" & "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    End If

                Case 14
                    If pvtQueryValue = "" Then
                        'MessageBox.Show("請輸入醫令類別")
                        'MessageHandling.showWarn("請輸入醫令類別")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入醫令類別"})
                        pvtExeQuery = False
                    Else
                        If Txt_QueryValue.Text.Trim = "" Then
                            Txt_QueryValue.Text = "Nothing"
                        End If
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue & "︿A.Order_Type_Id", "%" & Txt_QueryValue.Text.Trim & "%" & "︿" & pvtQueryValue & "", " Like ", Nothing)

                        If Txt_QueryValue.Text = "Nothing" Then
                            Txt_QueryValue.Text = ""
                        End If

                    End If
                Case 15
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 16
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 17
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 18
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)


                    '18,19,20多選
                Case 21
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 27
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)


                Case 28
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)


                Case 29
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 30
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 33
                    If pvtQueryValue = "" Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入醫令類別"})
                        pvtExeQuery = False
                    Else

                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue & "︿A.Order_Type_Id", "%" & Txt_QueryValue.Text.Trim & "%" & "︿" & pvtQueryValue & "", " Like ", Nothing)

                    End If

                Case 34
                    If pvtQueryValue = "" Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入醫令類別"})
                        pvtExeQuery = False
                    Else

                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue & "︿A.Order_Type_Id", "%" & Txt_QueryValue.Text.Trim & "%" & "︿" & pvtQueryValue & "", " Like ", Nothing)

                    End If


                Case 36

                    '週班表查詢

                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                    If pvtDS IsNot Nothing AndAlso pvtDS.Tables.Count > 0 Then
                        'pvtDS.Tables(0).Columns("星期").ReadOnly = False

                        'For i As Integer = 0 To pvtDS.Tables(0).Rows.Count - 1

                        '    If IsDate(pvtDS.Tables(0).Rows(i).Item("星期")) Then

                        '        If Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 1 Then
                        '            '星期日
                        '            pvtDS.Tables(0).Rows(i).Item("星期") = "星期日"

                        '        ElseIf Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 2 Then
                        '            pvtDS.Tables(0).Rows(i).Item("星期") = "星期一"

                        '        ElseIf Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 3 Then
                        '            pvtDS.Tables(0).Rows(i).Item("星期") = "星期二"

                        '        ElseIf Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 4 Then
                        '            pvtDS.Tables(0).Rows(i).Item("星期") = "星期三"

                        '        ElseIf Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 5 Then
                        '            pvtDS.Tables(0).Rows(i).Item("星期") = "星期四"

                        '        ElseIf Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 6 Then
                        '            pvtDS.Tables(0).Rows(i).Item("星期") = "星期五"

                        '        ElseIf Weekday(CDate(pvtDS.Tables(0).Rows(i).Item("日期"))) = 7 Then

                        '            '星期6
                        '            pvtDS.Tables(0).Rows(i).Item("星期") = "星期六"

                        '        End If

                        '    End If

                        'Next

                    End If
                Case 37
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 38
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 40
                    If pvtQueryValue = "" Then
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入日期"})
                        pvtExeQuery = False
                    Else
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%" & "︿" & pvtQueryValue, " Like ", Nothing)
                    End If

                Case 41
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                Case 42
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)

                Case 50
                    '20130424 by ccr  icd code 處置碼有些有二碼,故不能控制長度必需為 3,改為2
                    If (Cbo_QueryField.SelectedValue = "Icd9_Code" OrElse Cbo_QueryField.SelectedValue = "Icd10_Code") AndAlso Txt_QueryValue.Text.Trim.Length < 2 Then
                        'MessageBox.Show("疾病分類碼之條件值至少輸入3碼")
                        'MessageHandling.showWarn("疾病分類碼之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"疾病分類碼之條件值至少輸入前2碼"})
                        pvtExeQuery = False
                    ElseIf Cbo_QueryField.SelectedValue = "Icd10_Name" AndAlso Txt_QueryValue.Text.Trim.Length < 3 Then
                        'MessageBox.Show("英文名稱之條件值至少輸入3碼")
                        'MessageHandling.showWarn("英文名稱之條件值至少輸入3碼")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"英文名稱之條件值至少輸入3碼"})
                        pvtExeQuery = False

                    Else
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "" & Txt_QueryValue.Text.Trim & "", " Like ", Nothing)
                    End If

                Case 51
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)

                Case 52

                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)

                Case 53

                    If Area_Code <> "" Then
                        If OtherQueryConditionDS Is Nothing Then
                            OtherQueryConditionDS = New DataSet
                            OtherQueryConditionDS.Tables.Add()
                        End If
                        OtherQueryConditionDS.Tables(0).TableName = Area_Code
                    End If

                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)
                Case 54

                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " = ", OtherQueryConditionDS)

                Case 60
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 61

                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 62

                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)
                Case 63

                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)
                Case 70

                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)


                Case 98

                    If Cbo_QueryField.SelectedValue = "B.Employee_Name" Then
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    Else
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    End If

                Case 99

                    If Cbo_QueryField.SelectedValue = "B.Employee_Name" Then
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    Else
                        pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)
                    End If

                Case 303
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 500
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", Nothing)

                Case 501
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)

                Case 502
                    pvtDS = uclOW.queryOpenWindow(pvtQueryTable, Cbo_QueryField.SelectedValue, "%" & Txt_QueryValue.Text.Trim & "%", " Like ", OtherQueryConditionDS)


            End Select

            If pvtExeQuery = True Then
                If pvtDS.Tables.Count > 0 Then
                    DGV_DataView.DataSource = pvtDS.Tables(0)

                    If pvtQueryTable = 1 Then
                        ' PUB_Doctor = 1   不顯示 醫師代碼 身分證號
                        DGV_DataView.Columns(0).Visible = False
                        DGV_DataView.Columns(5).Visible = False
                    End If

                    If pvtQueryTable = 2 Then
                        DGV_DataView.Columns(4).Visible = False
                    End If

                    If pvtQueryTable = 9 AndAlso Cbo_QueryField.SelectedValue = "Insu_Code" Then
                        DGV_DataView.Columns(1).Visible = False
                        DGV_DataView.Columns(5).Visible = False
                        DGV_DataView.Columns(6).Visible = False
                    End If

                    If pvtQueryTable = 12 OrElse pvtQueryTable = 501 Then
                        'PUB_Employee = 12 
                        DGV_DataView.Columns(3).Visible = False
                    End If

                    If pvtQueryTable = 11 Then

                        DGV_DataView.Columns(5).Visible = False
                        DGV_DataView.Columns(6).Visible = False
                        DGV_DataView.Columns(7).Visible = False

                    End If

                    If pvtQueryTable = 13 Then
                        '不顯示 醫師代碼  
                        DGV_DataView.Columns(0).Visible = False

                    End If

                    If pvtQueryTable = 14 Then
                        For i As Integer = 3 To pvtDS.Tables(0).Columns.Count - 1
                            DGV_DataView.Columns(i).Visible = False
                        Next
                    End If

                    If pvtQueryTable = 33 Then
                        If Cbo_QueryField.SelectedValue = "Insu_Code" Then
                            DGV_DataView.Columns(1).Visible = False
                            DGV_DataView.Columns(5).Visible = False
                            DGV_DataView.Columns(6).Visible = False
                        Else
                            For i As Integer = 3 To pvtDS.Tables(0).Columns.Count - 1
                                DGV_DataView.Columns(i).Visible = False
                            Next
                        End If

                    End If

                    If pvtQueryTable = 34 Then
                        If Cbo_QueryField.SelectedValue = "Insu_Code" Then
                            DGV_DataView.Columns(1).Visible = False
                            DGV_DataView.Columns(5).Visible = False
                            DGV_DataView.Columns(6).Visible = False
                        Else
                            For i As Integer = 5 To pvtDS.Tables(0).Columns.Count - 1
                                DGV_DataView.Columns(i).Visible = False
                            Next
                        End If

                    End If

                    If pvtQueryTable = 36 Then

                        DGV_DataView.Columns(4).Visible = False
                        DGV_DataView.Columns(5).Visible = False
                        DGV_DataView.Columns(6).Visible = False

                    End If

                    If pvtQueryTable = 37 Then
                        ' PUB_Doctor = 37  不顯示身分證號
                        DGV_DataView.Columns(5).Visible = False

                        '不顯示 醫師代碼  
                        DGV_DataView.Columns(0).Visible = False

                    End If

                    If pvtQueryTable = 40 Then
                        ' PUB_Doctor = 1  不顯示身分證號
                        DGV_DataView.Columns(5).Visible = False

                        '不顯示 醫師代碼  
                        DGV_DataView.Columns(0).Visible = False

                    End If

                    If pvtQueryTable = 52 Then
                        For i As Integer = 2 To pvtDS.Tables(0).Columns.Count - 1
                            DGV_DataView.Columns(i).Visible = False
                        Next
                    End If

                    If pvtQueryTable = 53 Then
                        For i As Integer = 4 To pvtDS.Tables(0).Columns.Count - 1
                            DGV_DataView.Columns(i).Visible = False
                        Next
                    End If

                    If pvtQueryTable = 98 Then

                        '不顯示 醫師代碼  
                        DGV_DataView.Columns(0).Visible = False

                    End If

                    If pvtQueryTable = 99 Then

                        '不顯示 醫師代碼  
                        DGV_DataView.Columns(0).Visible = False

                    End If


                    returnDS.Clear()
                    returnDS = pvtDS.Clone()
                End If
            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub


    ''' <summary>
    '''  初始化查詢視窗條件
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setInitData()
        Dim pvtTable As New DataTable
        Dim pvtColumn As DataColumn
        Dim pvtRow As DataRow
        Me.KeyPreview = True '啟用才能觸發快速鍵功能     

        '設定[查詢欄位]下拉選項值
        Try

            If pvtStateFlag = True Then
                Select Case pvtQueryTable
                    Case 1, 40, 98, 99
                        pvtTable.TableName = "PUB_Doctor"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        If HospConfigUtil.HospConfig = HospConfigUtil.hospConfigList.Tw_TPEHOSP Then
                            pvtRow = pvtTable.NewRow()
                            pvtRow("Code") = "A.Doctor_Code"
                            pvtRow("CodeName") = "醫師代碼"
                            pvtTable.Rows.Add(pvtRow)

                            pvtRow = pvtTable.NewRow()
                            pvtRow("Code") = "B.Employee_Name"
                            pvtRow("CodeName") = "醫師姓名"
                            pvtTable.Rows.Add(pvtRow)

                        Else
                            pvtRow = pvtTable.NewRow()
                            pvtRow("Code") = "B.Employee_Name"
                            pvtRow("CodeName") = "醫師姓名"
                            pvtTable.Rows.Add(pvtRow)

                            'pvtRow = pvtTable.NewRow()
                            'pvtRow("Code") = "A.Doctor_Code"
                            'pvtRow("CodeName") = "醫師代碼"
                            'pvtTable.Rows.Add(pvtRow)

                            pvtRow = pvtTable.NewRow()
                            pvtRow("Code") = "A.Employee_Code"
                            pvtRow("CodeName") = "員工編號"
                            pvtTable.Rows.Add(pvtRow)

                            pvtRow = pvtTable.NewRow()
                            pvtRow("Code") = "D.License_Dept_Code"
                            pvtRow("CodeName") = "所屬科別代碼"
                            pvtTable.Rows.Add(pvtRow)


                            pvtRow = pvtTable.NewRow()
                            pvtRow("Code") = "C.Dept_Name"
                            pvtRow("CodeName") = "科別名稱"
                            pvtTable.Rows.Add(pvtRow)

                        End If


                    Case 2
                        pvtTable.TableName = "PUB_Zone_Room"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Room_Code"
                        pvtRow("CodeName") = "診間代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Room_Name"
                        pvtRow("CodeName") = "診間名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 3
                        pvtTable.TableName = "PUB_Patient"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        'pvtRow = pvtTable.NewRow()
                        'pvtRow("Code") = "Chart_No"
                        'pvtRow("CodeName") = "病歷號"
                        'pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Idno"
                        pvtRow("CodeName") = "証號"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Patient_Name"
                        pvtRow("CodeName") = "姓名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Birth_Date"
                        pvtRow("CodeName") = "生日"
                        pvtTable.Rows.Add(pvtRow)

                    Case 4
                        pvtTable.TableName = "PUB_Disease"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Icd_Code"
                        pvtRow("CodeName") = "疾病分類碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Disease_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Disease_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)



                    Case 5
                        pvtTable.TableName = "PUB_Order_Examination"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_Code"
                        pvtRow("CodeName") = "醫令項目代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_Type_Id"
                        pvtRow("CodeName") = "醫令類型"
                        pvtTable.Rows.Add(pvtRow)


                    Case 6
                        pvtTable.TableName = "PUB_Department"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Dept_Code"
                        pvtRow("CodeName") = "科別代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Dept_Name"
                        pvtRow("CodeName") = "科別名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 7
                        pvtTable.TableName = "PUB_Sheet"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Sheet_Code"
                        pvtRow("CodeName") = "表單代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Sheet_Name"
                        pvtRow("CodeName") = "表單名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 8
                        pvtTable.TableName = "REF_Referral_Hospital"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Hospital_Name"
                        pvtRow("CodeName") = "醫院名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Hospital_Code"
                        pvtRow("CodeName") = "醫院代碼"
                        pvtTable.Rows.Add(pvtRow)


                    Case 9
                        pvtTable.TableName = "PUB_Order"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_Code"
                        pvtRow("CodeName") = "醫令項目代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_Type_Id"
                        pvtRow("CodeName") = "醫令類型"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Insu_Code"
                        pvtRow("CodeName") = "健保碼"
                        pvtTable.Rows.Add(pvtRow)



                    Case 10
                        pvtTable.TableName = "SCH_Apparatus"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Apparatus_Code"
                        pvtRow("CodeName") = "儀器代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Apparatus_Name"
                        pvtRow("CodeName") = "儀器名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 11
                        pvtTable.TableName = "REG_Day_Schedule"




                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Employee_Code"
                        pvtRow("CodeName") = "員工代碼"
                        pvtTable.Rows.Add(pvtRow)

                        'pvtRow = pvtTable.NewRow()
                        'pvtRow("Code") = "A.Doctor_Code"
                        'pvtRow("CodeName") = "醫師代碼"
                        'pvtTable.Rows.Add(pvtRow)



                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Reg_Date"
                        pvtRow("CodeName") = "日期"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Noon_Code"
                        pvtRow("CodeName") = "午別代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Dept_Code"
                        pvtRow("CodeName") = "科別代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Section_Id"
                        pvtRow("CodeName") = "診別代碼"
                        pvtTable.Rows.Add(pvtRow)




                    Case 12
                        pvtTable.TableName = "PUB_Employee"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Employee_Code"
                        pvtRow("CodeName") = "員工代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Employee_Name"
                        pvtRow("CodeName") = "姓名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Employee_En_Name"
                        pvtRow("CodeName") = "英文姓名"
                        pvtTable.Rows.Add(pvtRow)

                        'pvtRow = pvtTable.NewRow()
                        'pvtRow("Code") = "Idno"
                        'pvtRow("CodeName") = "身份證號"
                        'pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Dept_Code"
                        pvtRow("CodeName") = "所屬科別"
                        pvtTable.Rows.Add(pvtRow)


                    Case 13
                        pvtTable.TableName = "PUB_Doctor"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Doctor_Code"
                        pvtRow("CodeName") = "醫師代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "B.Employee_Name"
                        pvtRow("CodeName") = "醫師姓名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Employee_Code"
                        pvtRow("CodeName") = "員工編號"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Dept_Code"
                        pvtRow("CodeName") = "科別"
                        pvtTable.Rows.Add(pvtRow)

                    Case 14
                        pvtTable.TableName = "PUB_Order"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_Code"
                        pvtRow("CodeName") = "醫令項目代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)


                    Case 15
                        pvtTable.TableName = "OPH_Pharmacist"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Employee_Code"
                        pvtRow("CodeName") = "員工編號"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Employee_Name"
                        pvtRow("CodeName") = "員工姓名"
                        pvtTable.Rows.Add(pvtRow)


                    Case 16
                        pvtTable.TableName = "REG_Profess_Base"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Professional_Code"
                        pvtRow("CodeName") = "次專科代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Professional_Name"
                        pvtRow("CodeName") = "次專科名稱"
                        pvtTable.Rows.Add(pvtRow)


                    Case 17
                        pvtTable.TableName = "OPH_Pharmacy_Class"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Class_Code"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Class_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Class_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 18
                        pvtTable.TableName = "OPH_Code"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Id"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)


                    Case 21
                        pvtTable.TableName = "PUB_Order"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_Code"
                        pvtRow("CodeName") = "醫令項目代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_Type_Id"
                        pvtRow("CodeName") = "醫令類型"
                        pvtTable.Rows.Add(pvtRow)

                    Case 27
                        pvtTable.TableName = "PUB_Syscode"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Id"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Name"
                        pvtRow("CodeName") = "名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 28
                        pvtTable.TableName = "REF_Referral_Patient"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Idno"
                        pvtRow("CodeName") = "身份證號"
                        pvtTable.Rows.Add(pvtRow)

                        'pvtRow = pvtTable.NewRow()
                        'pvtRow("Code") = "A.Chart_No"
                        'pvtRow("CodeName") = "病歷號"
                        'pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Patient_Name"
                        pvtRow("CodeName") = "姓名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Treatment_Date"
                        pvtRow("CodeName") = "看診日期"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Hospital_Code"
                        pvtRow("CodeName") = "轉介醫院代號"
                        pvtTable.Rows.Add(pvtRow)

                    Case 29
                        pvtTable.TableName = "REF_Referral_Out_Patient"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Idno"
                        pvtRow("CodeName") = "身份證號"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Chart_No"
                        pvtRow("CodeName") = "病歷號"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Patient_Name"
                        pvtRow("CodeName") = "姓名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Referral_Out_Date"
                        pvtRow("CodeName") = "轉出日期"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Hospital_Code"
                        pvtRow("CodeName") = "轉出醫院代號"
                        pvtTable.Rows.Add(pvtRow)


                    Case 30
                        pvtTable.TableName = "OPH_Pharmacy_Base"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Pharmacy_12_Code"
                        pvtRow("CodeName") = "藥品碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Order_Code"
                        pvtRow("CodeName") = "醫令項目代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Scientific_Name"
                        pvtRow("CodeName") = "學名"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Trade_Name"
                        pvtRow("CodeName") = "商品名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Chinese_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Chinese_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Class_Code"
                        pvtRow("CodeName") = "藥理分類"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Alias_Name"
                        pvtRow("CodeName") = "俗名"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Insu_Code"
                        pvtRow("CodeName") = "健保碼"
                        pvtTable.Rows.Add(pvtRow)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "License"
                        pvtRow("CodeName") = "衛署字號"
                        pvtTable.Rows.Add(pvtRow)


                    Case 33
                        pvtTable.TableName = "PUB_Order"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_Code"
                        pvtRow("CodeName") = "醫令項目代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Insu_Code"
                        pvtRow("CodeName") = "健保碼"
                        pvtTable.Rows.Add(pvtRow)

                    Case 34
                        pvtTable.TableName = "OPH_Pharmacy_Base"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_Code"
                        pvtRow("CodeName") = "醫令項目代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Order_Name"
                        pvtRow("CodeName") = "藥囑藥名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Scientific_Name"
                        pvtRow("CodeName") = "學名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Trade_Name"
                        pvtRow("CodeName") = "商品名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Alias_Name"
                        pvtRow("CodeName") = "俗名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Insu_Code"
                        pvtRow("CodeName") = "健保碼"
                        pvtTable.Rows.Add(pvtRow)

                    Case 36
                        pvtTable.TableName = "REG_Week_Schedule"




                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Employee_Code"
                        pvtRow("CodeName") = "員工代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Doctor_Code"
                        pvtRow("CodeName") = "醫師代碼"
                        pvtTable.Rows.Add(pvtRow)



                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Week_Id"
                        pvtRow("CodeName") = "星期別"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Noon_Code"
                        pvtRow("CodeName") = "午別代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Dept_Code"
                        pvtRow("CodeName") = "科別代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Section_Id"
                        pvtRow("CodeName") = "診別代碼"
                        pvtTable.Rows.Add(pvtRow)

                    Case 37
                        pvtTable.TableName = "PUB_Doctor"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "B.Employee_Name"
                        pvtRow("CodeName") = "醫師姓名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Doctor_Code"
                        pvtRow("CodeName") = "醫師代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Employee_Code"
                        pvtRow("CodeName") = "員工編號"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "B.Dept_Code"
                        pvtRow("CodeName") = "所屬科別代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()   '20110930 Immy 新增科別名稱
                        pvtRow("Code") = "C.Dept_Name"
                        pvtRow("CodeName") = "科別名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 38
                        pvtTable.TableName = "PUB_Contract"
                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Contract_Code"
                        pvtRow("CodeName") = "合約機關代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Contract_Name"
                        pvtRow("CodeName") = "合約機關名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 41
                        pvtTable.TableName = "PUB_Department"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Dept_Code"
                        pvtRow("CodeName") = "科別代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Dept_Name"
                        pvtRow("CodeName") = "科別名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 42
                        pvtTable.TableName = "PUB_Employee"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Employee_Code"
                        pvtRow("CodeName") = "員工編號"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Employee_Name"
                        pvtRow("CodeName") = "姓名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Employee_En_Name"
                        pvtRow("CodeName") = "英文姓名"
                        pvtTable.Rows.Add(pvtRow)

                        If Not OtherQueryConditionDS.Tables.Contains("PUBEmployeeProfessalKindId") Then
                            pvtRow = pvtTable.NewRow()
                            pvtRow("Code") = "A.Professal_Kind_Id"
                            pvtRow("CodeName") = "職稱"
                            pvtTable.Rows.Add(pvtRow)
                        End If


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Dept_Code"
                        pvtRow("CodeName") = "科室代號"
                        pvtTable.Rows.Add(pvtRow)

                    Case 50
                        pvtTable.TableName = "PUB_Disease_ICD10"
                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)


                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Icd9_Code"
                        pvtRow("CodeName") = "Icd9碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Icd10_Code"
                        pvtRow("CodeName") = "Icd10碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Icd10_Name"
                        pvtRow("CodeName") = "Icd10英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 51
                        pvtTable.TableName = "PUB_Insu_Dept"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Insu_Dept_Code"
                        pvtRow("CodeName") = "科別代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Insu_Dept_Code_Name"
                        pvtRow("CodeName") = "科別名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Insu_Dept_Code_En_Name"
                        pvtRow("CodeName") = "科別英文名稱"
                        pvtTable.Rows.Add(pvtRow)


                    Case 52
                        pvtTable.TableName = "PUB_Postal_Area"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "PUB_Area_Code_N.Area_Name"
                        pvtRow("CodeName") = "地區名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "PUB_Postal_Area.Area_Code"
                        pvtRow("CodeName") = "地區代碼"
                        pvtTable.Rows.Add(pvtRow)

                    Case 53
                        pvtTable.TableName = "PUB_Postal_Area"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "PUB_Area_Code_Gov.Vil_Name"
                        pvtRow("CodeName") = "里名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "PUB_Area_Code_N.Area_Name"
                        pvtRow("CodeName") = "地區名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "PUB_Area_Code_N.Area_Code"
                        pvtRow("CodeName") = "地區代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "PUB_Area_Code_Gov.Vil_Code"
                        pvtRow("CodeName") = "里代碼"
                        pvtTable.Rows.Add(pvtRow)

                    Case 54
                        pvtTable.TableName = "PUB_Nhi_Code"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Insu_Code"
                        pvtRow("CodeName") = "健保碼"
                        pvtTable.Rows.Add(pvtRow)

                    Case 60

                        pvtTable.TableName = "DRG_Drg_Base"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Drg_Code"
                        pvtRow("CodeName") = "TW_DRGs碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Drg_Name"
                        pvtRow("CodeName") = "TW_DRGs名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Drg_En_Name"
                        pvtRow("CodeName") = "TW_DRGs英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 61

                        pvtTable.TableName = "DRG_Mdc_Base"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "MDC_Code"
                        pvtRow("CodeName") = "主要疾病類別MDC碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "MDC_Name"
                        pvtRow("CodeName") = "主要疾病類別MDC名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "MDC_En_Name"
                        pvtRow("CodeName") = "主要疾病類別MDC英文名稱"
                        pvtTable.Rows.Add(pvtRow)
                    Case 62

                        pvtTable.TableName = "PUB_Station"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Station_No"
                        pvtRow("CodeName") = "護理站代號"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Station_Name"
                        pvtRow("CodeName") = "護理站名稱"
                        pvtTable.Rows.Add(pvtRow)
                    Case 63

                        pvtTable.TableName = "STA_Consumpation "

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Consumpation_Unit"
                        pvtRow("CodeName") = "消耗單位代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Consumpation_Name"
                        pvtRow("CodeName") = "消耗單位名稱"
                        pvtTable.Rows.Add(pvtRow)
                    Case 70
                        pvtTable.TableName = "LAB_BacOrgan"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "BacOrgan_Code"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "BacOrgan_Name"
                        pvtRow("CodeName") = "名稱"
                        pvtTable.Rows.Add(pvtRow)



                    Case 303
                        pvtTable.TableName = "OPH_Code"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Id"
                        pvtRow("CodeName") = "代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_Name"
                        pvtRow("CodeName") = "中文名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Code_En_Name"
                        pvtRow("CodeName") = "英文名稱"
                        pvtTable.Rows.Add(pvtRow)

                    Case 500

                        pvtTable.TableName = "LAB_Item"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Item_Code"
                        pvtRow("CodeName") = "檢驗代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Item_Name"
                        pvtRow("CodeName") = "檢驗名稱"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "Sheet_Code"
                        pvtRow("CodeName") = "表單代碼"
                        pvtTable.Rows.Add(pvtRow)

                    Case 501
                        pvtTable.TableName = "PUB_Employee"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Employee_Code"
                        pvtRow("CodeName") = "員工代碼"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Employee_Name"
                        pvtRow("CodeName") = "姓名"
                        pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Employee_En_Name"
                        pvtRow("CodeName") = "英文姓名"
                        pvtTable.Rows.Add(pvtRow)

                        'pvtRow = pvtTable.NewRow()
                        'pvtRow("Code") = "Idno"
                        'pvtRow("CodeName") = "身份證號"
                        'pvtTable.Rows.Add(pvtRow)

                        pvtRow = pvtTable.NewRow()
                        pvtRow("Code") = "A.Dept_Code"
                        pvtRow("CodeName") = "所屬科別"
                        pvtTable.Rows.Add(pvtRow)

                    Case 502

                        pvtTable.TableName = "OPH_Code"

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "Code"
                        pvtTable.Columns.Add(pvtColumn)

                        pvtColumn = New DataColumn()
                        pvtColumn.DataType = System.Type.GetType("System.String")
                        pvtColumn.ColumnName = "CodeName"
                        pvtTable.Columns.Add(pvtColumn)

                        'pvtRow = pvtTable.NewRow()
                        'pvtRow("Code") = "A.Order_Code"
                        'pvtRow("CodeName") = "醫令代碼"
                        'pvtTable.Rows.Add(pvtRow)


                End Select

                Cbo_QueryField.DataSource = pvtTable
                Cbo_QueryField.DisplayMember = "CodeName"
                Cbo_QueryField.ValueMember = "Code"

                '查詢欄位ComboBox設定
                If pvtQueryField IsNot Nothing AndAlso pvtQueryField.Trim <> "" Then
                    For i = 0 To Cbo_QueryField.Items.Count - 1
                        If pvtTable.Rows(i).Item("Code").ToString.Trim = pvtQueryField.Trim OrElse _
                           pvtTable.Rows(i).Item("CodeName").ToString.Trim = pvtQueryField.Trim Then
                            Cbo_QueryField.SelectedValue = pvtTable.Rows(i).Item("Code").ToString.Trim
                            Exit For
                        End If
                    Next
                End If

            End If

            pvtCodeVaule1 = ""
            pvtCodeVaule2 = ""
            pvtCodeName = ""

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub Cbo_QueryField_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_QueryField.SelectedIndexChanged


        Select Case pvtQueryTable
            Case 3
                If Cbo_QueryField.Text.Trim = "生日" Then

                    Txt_QueryValue.Visible = False
                    dtp.Visible = True
                Else
                    Txt_QueryValue.Visible = True
                    dtp.Visible = False
                End If
            Case Else
                Txt_QueryValue.Visible = True
                dtp.Visible = False
        End Select

    End Sub


    Private Sub Txt_QueryValue_KeyUp(sender As Object, e As KeyEventArgs) Handles Txt_QueryValue.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    Btn_Query.PerformClick()
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class
