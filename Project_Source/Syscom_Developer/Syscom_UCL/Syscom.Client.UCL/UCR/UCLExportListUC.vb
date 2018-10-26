'/*
'*****************************************************************************
'*
'*    Page/Class Name:  報表查詢平台
'*              Title:	PubExportList
'*        Description:	提供報表查詢作業
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-08-11
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-08-11
'*
'*****************************************************************************
'*/

'Imports System.ServiceModel

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports Syscom.Comm.Utility.DateUtil
Imports System.Text

Public Class UCLExportListUC

#Region "     變數宣告 "

#Region "     使用者宣告　"

    '表單代號
    Dim glbReport_Id As String = ""
 
    '查詢條件資訊
    Private glbQueryCond(,) As String
    '報表主要資訊
    Private gblMainDataInfoDS As New DataSet
    'Grid欄位資訊
    Private gblGridCloumnInfoDS As New DataSet
    '列印的報表資料
    Private gblReportDataDS As New DataSet
    '查詢欄位資訊
    Private gblColumnInfoDS As New DataSet

    'Excel欄位名稱設定
    Private gblColumnNameExcelTitle As String = ""
    'Sql指令字串
    Private glbSqlString As String = ""

#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim Pub As IPubServiceManager

#End Region

#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager

#End Region

#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "　　匯出Excel"

    ''' <summary>
    ''' 匯出
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-08-13</remarks>
    Private Sub btn_export_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_export.Click

        UCLScreenUtil.Lock(Me)



        If CheckHasTable(gblColumnInfoDS, "") Then
            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"無資料可匯出"})
            Exit Sub
        End If
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        Dim xlRange As Microsoft.Office.Interop.Excel.Range = Nothing

        Dim RowIndex As Integer = 1
        '----------------------------------------------------------------------------
        '#Step1.Create Excel物件
        '----------------------------------------------------------------------------
        'On Error Resume Next
        Try

            Dim ds As DataSet = Pub.getReportInfo(glbReport_Id, "1", "")
            Dim cond(gblColumnInfoDS.Tables(0).Rows.Count, 1) As String

            '一部電腦僅執行一個Excel Application, 就算中突開啟Excel也不會影響程式執行        
            '在工作管理員中只會看見一個EXCEL.exe在執行，不會浪費電腦資源        
            '引用正在執行的Excel Application        
            'xlApp = GetObject(, "Excel.Application")
            xlApp = New Microsoft.Office.Interop.Excel.Application
        Catch ex As Exception
            '若發生錯誤表示電腦沒有Excel正在執行，需重新建立一個新的應用程式        
            If Err.Number() <> 0 Then Err.Clear()

            '執行一個新的Excel Application            
            xlApp = CreateObject("Excel.Application")

            If Err.Number() <> 0 Then
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"電腦沒有安裝Excel!"}, "")
                Exit Sub
            End If
        End Try
        '--------------------------------------------------
        '----------------------------------------------------------------------------
        '#Step2.匯出DataSet的資料到Excel
        '----------------------------------------------------------------------------
        eventMgr.RaiseUclWaitingForm("WaitingStart", "匯出檔案中，請稍後‧‧‧")

        Try
            '取得表頭欄位名稱陣列
            Dim clnName As String() = gblColumnNameExcelTitle.Split(",")
            Dim printDT As System.Data.DataTable = CType(Me.btn_export.Tag, DataSet).Tables(0).Copy

            xlApp.Visible = False

            '開新活頁簿
            xlBook = xlApp.Workbooks.Add
            '設定活頁簿為焦點
            xlBook.Activate()
            '選取第1張活頁簿
            xlSheet = xlBook.Worksheets(1)
            '開始列印表頭部分資訊
            PrintHeadFont(nvl(gblMainDataInfoDS.Tables(0).Rows(0).Item("Report_Name")), xlSheet, printDT, clnName, glbQueryCond, RowIndex)

            '填入表身資料
            For iRow As Integer = 0 To printDT.Rows.Count - 1
                xlSheet.Range(xlSheet.Cells(iRow + RowIndex, 1), xlSheet.Cells(iRow + RowIndex, printDT.Columns.Count)).Value = printDT.Rows(iRow).ItemArray
            Next
            '畫下框線
            xlSheet.Range(xlSheet.Cells(RowIndex + printDT.Rows.Count - 1, 1), xlSheet.Cells(RowIndex + printDT.Rows.Count - 1, printDT.Columns.Count)).Borders(9).LineStyle = 1
            xlSheet.Range(xlSheet.Cells(RowIndex + printDT.Rows.Count - 1, 1), xlSheet.Cells(RowIndex + printDT.Rows.Count - 1, printDT.Columns.Count)).Borders(9).Weight = 2

            ' xlSheet.Range(xlSheet.Cells(RowIndex + printDT.Rows.Count + 1, 1), xlSheet.Cells(RowIndex + printDT.Rows.Count + 1, 1)).Value = {"院長                     主任                     組長                     經辦人"}

            If gblMainDataInfoDS.Tables(0).Rows(0).Item("Footer1") IsNot DBNull.Value Then
                xlSheet.Range(xlSheet.Cells(RowIndex + printDT.Rows.Count + 1, 1), xlSheet.Cells(RowIndex + printDT.Rows.Count + 1, 1)).Value = gblMainDataInfoDS.Tables(0).Rows(0).Item("Footer1")
            End If
      
            If gblMainDataInfoDS.Tables(0).Rows(0).Item("Footer2") IsNot DBNull.Value Then
                xlSheet.Range(xlSheet.Cells(RowIndex + printDT.Rows.Count + 2, 1), xlSheet.Cells(RowIndex + printDT.Rows.Count + 2, 1)).Value = gblMainDataInfoDS.Tables(0).Rows(0).Item("Footer2")
            End If

            ''儲存Excel
            'xlBook.SaveAs(filePath)
            xlApp.Visible = True


        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally

            UCLScreenUtil.UnLock(Me)
            eventMgr.RaiseUclWaitingForm("WaitingEnd", "")

            '回收Excel
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
            If xlApp IsNot Nothing Then xlApp = Nothing
            If xlBook IsNot Nothing Then xlBook = Nothing
            If xlSheet IsNot Nothing Then xlSheet = Nothing
            If xlRange IsNot Nothing Then xlRange = Nothing
            GC.Collect()
        End Try
    End Sub

#End Region

#Region "     查詢 "


    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Private Function QueryData() As Boolean

        Dim returnBoolean As Boolean

        'Dim iButtonFlag As Integer = buttonAction.QUERY

        Try
            ''欄位檢查
            If fieldCheckResult() Then
                Return False
            End If
            '查詢成功後儲存的 DS
            Dim param As Object = GetQueryCondition()
            gblReportDataDS = Pub.PubExportQueryData(param(0), param(1))


            '******************************************************************************




            '有查到 Table 要回傳True
            If CheckHasTable(gblReportDataDS) Then

                '如果資料列為零要顯示查無符合條件資料
                If gblReportDataDS.Tables(0).Rows.Count = 0 Then

                    MessageHandling.ShowWarnMsg("CMMCMMB933", New String() {})
                    returnBoolean = False
                    btn_export.Visible = False
                Else
                    Me.btn_export.Tag = gblReportDataDS

                    '顯示資料在 Grid 上
                    dgv_ShowReport.Visible = True
                    'Mark By Will 20160706 Rick說因為科別代號會被數字化處理  就不對數字做轉換處理了
                    'For Each dr As DataRow In gblReportDataDS.Tables(0).Rows
                    '    For i As Integer = 0 To gblReportDataDS.Tables(0).Columns.Count - 1
                    '        If nvl(IsNumeric(dr.Item(i))) Then
                    '            dr.Item(i) = Convert.ToDecimal(dr.Item(i))
                    '        End If
                    '    Next
                    'Next
                    dgv_ShowReport.DataSource = gblReportDataDS
                    dgv_ShowReport.uclReadOnly = True
                    For Each dc As DataColumn In gblReportDataDS.Tables(0).Columns
                        gblColumnNameExcelTitle += dc.ColumnName + ","
                    Next
                    gblColumnNameExcelTitle = gblColumnNameExcelTitle.Substring(0, gblColumnNameExcelTitle.Length - 1)
                    returnBoolean = True
                    btn_export.Visible = True
                End If
            Else
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查無資料！"}, "")

                returnBoolean = False
            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB915", ex)
        End Try

    End Function

#End Region


#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "
    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub
    Sub New(ByVal report_id As String)
        Try
            '初始化控制項
            InitializeComponent()

            Me.glbReport_Id = report_id

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - 初始化控制項"})
        End Try
    End Sub

#Region "     初始化 - 顯示UI "
    ''' <summary>
    ''' 取得初始化相關資訊
    ''' </summary>
    ''' <param name="defaultValue">傳入二維陣列 元件名稱+預設值</param>
    ''' <param name="Report_Id">報表ID</param>
    ''' <remarks>by Will,Lin on 2015-08-11</remarks>
    Public Sub initialize(ByVal Report_Id As String, Optional ByVal defaultValue As String(,) = Nothing)

        Try

            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()




            '取得report_id
            Me.glbReport_Id = Report_Id
            If glbReport_Id = "" Then
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"報表代號錯誤！"}, "")
                Exit Sub
            End If

            Dim InitialDS As DataSet = Pub.PubExportListDataQuery(Me.glbReport_Id)
            '取得報表列印相關資訊
            gblMainDataInfoDS.Tables.Add(InitialDS.Tables("ExportDT").Copy)

            '確認報表是否已被停用
            If gblColumnInfoDS.Tables.Count > 0 AndAlso gblColumnInfoDS.Tables(0).Rows.Count > 0 AndAlso nvl(gblMainDataInfoDS.Tables(0).Rows(0).Item("Dc")) = "Y" Then
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"報表已停用，請洽資訊室！"}, "")
                Exit Sub
            End If

            '取得畫面上查詢欄位資訊
            gblColumnInfoDS.Tables.Add(InitialDS.Tables("ExportDetailDT").Copy)
            If gblColumnInfoDS.Tables.Count = 0 Or gblColumnInfoDS.Tables(0).Rows.Count = 0 Then
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查詢條件尚未設定，無法初始化查詢條件！"}, "")
            Else
                ReDim glbQueryCond(gblColumnInfoDS.Tables(0).Rows.Count, 1)
                '設定畫面上的查詢條件欄位
                setControl(gblColumnInfoDS, tbl_Main)
                '對元件做預設值處理
                SetControlDefaultValue(gblColumnInfoDS)
            End If

            '設定表單名稱
            If nvl(gblMainDataInfoDS.Tables(0).Rows(0).Item("Report_Name")) <> "" Then
                Me.Text = gblMainDataInfoDS.Tables(0).Rows(0).Item("Report_Name")
            End If
 
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub


    ''' <summary>
    ''' 設定panel的基本參數與欄列長寬
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-08-11</remarks>
    Public Sub setControl(ByVal DS_Input As DataSet, ByRef Panel_Input As Windows.Forms.TableLayoutPanel)

        Try
            Dim RowCount As Integer = 0
            Dim ColumnCount As Integer = 0
            Dim RowIndex As Integer = 0
            '依照資料筆數來取得畫面上的列數
            Panel_Input.RowCount = CInt(DS_Input.Tables(0).Rows.Count / 2)
            If DS_Input.Tables(0).Rows.Count < 2 Then
                Panel_Input.RowCount = 1
            End If
            Panel_Input.ColumnCount = 6

            For Each dr As DataRow In DS_Input.Tables(0).Rows
                '每四列換行，並且欄位的Index+3
                If RowIndex = 4 Then
                    RowIndex = 0
                    ColumnCount = ColumnCount + 3
                End If
                SetControlOfContent(dr, ColumnCount, RowIndex, Panel_Input)
                RowIndex += 1
            Next


            '設定欄位寬度autosize()
            Dim ColumnStyles As TableLayoutColumnStyleCollection = Me.tbl_Main.ColumnStyles
            For Each style As ColumnStyle In ColumnStyles
                style.SizeType = SizeType.AutoSize
            Next


            ''設定列高
            Dim RowStyles As TableLayoutRowStyleCollection = Me.tbl_Main.RowStyles
            For Each style As RowStyle In RowStyles
                style.SizeType = SizeType.AutoSize
            Next


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub


    ''' <summary>
    ''' 設定畫面上的欄位，將之加入panel
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-08-11</remarks>
    Public Sub SetControlOfContent(ByRef Row_Input As DataRow, ByRef Column_Index As Integer, ByVal Row_Count As Integer, ByRef Panel_Input As Windows.Forms.TableLayoutPanel)

        Try
            '新增要加到Panel上的控制項
            '要新增的控制項
            Dim Control_Obj As Object = New Object
            '----------------------------------------'
            '-------------↓欄位名稱區↓-------------'
            '----------------------------------------'
            If Not nvl(Row_Input.Item("Field_Name")) = "" Then
                '要新增的Label
                Dim Label_Obj As Label = New Label
                Label_Obj.AutoSize = True

                '設定Label
                Label_Obj.Text = nvl(Row_Input.Item("Field_Name"))
                Label_Obj.ForeColor = IIf(nvl(Row_Input.Item("Is_Nreq")).Equals("Y"), Color.Black, Color.Red)
                '設定文字標籤對齊格式
                Label_Obj.Anchor = AnchorStyles.Right
                '將Label加至TextBox前方
                Panel_Input.Controls.Add(Label_Obj, Column_Index, Row_Count)
            End If
            '----------------------------------------'
            '-------------↑欄位名稱區↑-------------'
            '----------------------------------------'

            '----------------------------------------'
            '-------------↓控制項區↓---------------'
            '----------------------------------------'
            Select Case nvl(Row_Input.Item("Form_Control_Type"))

                Case "ComboBox"
                    '設定物件為 Text Box 
                    Control_Obj = New UCLComboBoxUC
                    '設定控制項
                    Control_Obj.Name = nvl(Row_Input.Item("Field_Code"))
                    Control_Obj.Tag = nvl(Row_Input.Item("Field_Name"))

                    Control_Obj.Anchor = AnchorStyles.Left
                    '定義元件位置
                    Panel_Input.Controls.Add(Control_Obj, Column_Index + 1, Row_Count)
                    If Not Row_Input.Item("Cbo_Source_Data").ToString.Trim.Equals("") Then
                        Dim SendDS As New DataSet
                        SendDS.Tables.Add(New DataTable("Action"))
                        SendDS.Tables(0).Columns.Add("Action")
                        SendDS.Tables(0).Columns.Add("Cbo_Source_Data")
                        SendDS.Tables(0).Rows.Add("QueryComboBoxUCDataSource", Row_Input.Item("Cbo_Source_Data").ToString.Trim)
                        Dim ResultDS As DataSet = UclServiceManager.getInstance.DoUclAction(SendDS)

                        If CheckHasValue(ResultDS) Then
                            CType(Control_Obj, UCLComboBoxUC).DataSource = ResultDS.Tables(0).Copy
                            CType(Control_Obj, UCLComboBoxUC).uclDisplayIndex = "0,1"
                            CType(Control_Obj, UCLComboBoxUC).uclValueIndex = "0"
                        End If
                    End If


                Case "TextBox"
                    '設定物件為 Text Box 
                    Control_Obj = New TextBox
                    '設定控制項
                    Control_Obj.Name = nvl(Row_Input.Item("Field_Code"))
                    Control_Obj.Tag = nvl(Row_Input.Item("Field_Name"))

                    Control_Obj.Anchor = AnchorStyles.Left
                    '定義元件位置
                    Panel_Input.Controls.Add(Control_Obj, Column_Index + 1, Row_Count)
                Case "yyyymmdd"
                    '設定物件為 Date 
                    Control_Obj = New UCLDateTimePickerUC
                    Control_Obj.tag = "yyyymmdd"
                    '設定控制項
                    Control_Obj.Name = nvl(Row_Input.Item("Field_Code"))

                    Control_Obj.Anchor = AnchorStyles.Left
                    Control_Obj.DisplayLocale = "1"
                    '定義元件位置
                    Panel_Input.Controls.Add(Control_Obj, Column_Index + 1, Row_Count)
                Case "yyyymm"
                    '設定物件為 Date 
                    Control_Obj = New UCLDateTimePickerUC
                    Control_Obj.tag = "yyyymm"
                    '設定控制項
                    Control_Obj.Name = nvl(Row_Input.Item("Field_Code"))

                    Control_Obj.Anchor = AnchorStyles.Left
                    Control_Obj.DisplayLocale = "1"
                    '定義元件位置
                    Panel_Input.Controls.Add(Control_Obj, Column_Index + 1, Row_Count)

                Case "ym"

                    '設定物件為 Date 
                    Control_Obj = New UCLYmPickerUC
                    Control_Obj.tag = "ym"
                    '設定控制項
                    Control_Obj.Name = nvl(Row_Input.Item("Field_Code"))

                    Control_Obj.Anchor = AnchorStyles.Left
                    Control_Obj.DisplayLocale = "1"
                    '定義元件位置
                    Panel_Input.Controls.Add(Control_Obj, Column_Index + 1, Row_Count)


                Case "Chart_no"
                    '設定物件為 UCLChartNoUC
                    Control_Obj = New UCLChartNoUC
                    '設定控制項
                    Control_Obj.Name = nvl(Row_Input.Item("Field_Code"))

                    Control_Obj.Anchor = AnchorStyles.Left
                    '定義元件位置
                    Panel_Input.Controls.Add(Control_Obj, Column_Index + 1, Row_Count)
                Case "TextEmployee"
                    '設定物件為 UCLTextCodeQueryUI
                    Control_Obj = New UCLTextCodeQueryUI
                    '設定控制項
                    Control_Obj.Name = nvl(Row_Input.Item("Field_Code"))

                    Control_Obj.Anchor = AnchorStyles.Left
                    Control_Obj.uclTableName = 12
                    Control_Obj.uclTextBoxShow = 2
                    '定義元件位置
                    Panel_Input.Controls.Add(Control_Obj, Column_Index + 1, Row_Count)
                Case "TextDepartment"
                    '設定物件為 UCLTextCodeQueryUI
                    Control_Obj = New UCLTextCodeQueryUI
                    '設定控制項
                    Control_Obj.Name = nvl(Row_Input.Item("Field_Code"))

                    Control_Obj.Anchor = AnchorStyles.Left
                    Control_Obj.uclTableName = 6
                    Control_Obj.uclTextBoxShow = 2
                    '定義元件位置
                    Panel_Input.Controls.Add(Control_Obj, Column_Index + 1, Row_Count)
                Case "TextDeptSect"
                    '設定物件為 UCLTextCodeQueryUI
                    Control_Obj = New UCLTextCodeQueryUI
                    '設定控制項
                    Control_Obj.Name = nvl(Row_Input.Item("Field_Code"))

                    Control_Obj.Anchor = AnchorStyles.Left
                    Control_Obj.uclTableName = 43 'PUB_DepartmentAndSection
                    Control_Obj.uclTextBoxShow = 2
                    '定義元件位置
                    Panel_Input.Controls.Add(Control_Obj, Column_Index + 1, Row_Count)
                Case "TextOrder"
                    '設定物件為 UCLTextCodeQueryUI
                    Control_Obj = New UCLTextCodeQueryUI
                    '設定控制項
                    Control_Obj.Name = nvl(Row_Input.Item("Field_Code"))

                    Control_Obj.Anchor = AnchorStyles.Left
                    Control_Obj.uclTableName = 9
                    Control_Obj.uclTextBoxShow = 2
                    '定義元件位置
                    Panel_Input.Controls.Add(Control_Obj, Column_Index + 1, Row_Count)
                Case "TextStation" '護理站
                    '設定物件為 UCLTextCodeQueryUI
                    Control_Obj = New UCLTextCodeQueryUI
                    '設定控制項
                    Control_Obj.Name = nvl(Row_Input.Item("Field_Code"))

                    Control_Obj.Anchor = AnchorStyles.Left
                    CType(Control_Obj, UCLTextCodeQueryUI).uclTableName = UCLTextCodeQueryUI.uclQueryTable.PUB_Sation
                    Control_Obj.uclTextBoxShow = 2
                    '定義元件位置
                    Panel_Input.Controls.Add(Control_Obj, Column_Index + 1, Row_Count)
            End Select

            '----------------------------------------'
            '-------------↑控制項區↑---------------'
            '----------------------------------------'


            '----------------------------------------'
            '-------------↓備註區↓-----------------'
            '----------------------------------------'
            If Not nvl(Row_Input.Item("Field_Description")) = "" Then
                '要新增的Label
                Dim Label_Obj As Label = New Label
                Label_Obj.AutoSize = True
                '設定Label
                Label_Obj.Text = nvl(Row_Input.Item("Field_Description"))
                Label_Obj.ForeColor = Color.DarkGray
                Label_Obj.Anchor = AnchorStyles.Left
                '將Label加至TextBox後方
                Panel_Input.Controls.Add(Label_Obj, Column_Index + 2, Row_Count)
            End If

            '----------------------------------------'
            '-------------↑備註區↑-----------------'
            '----------------------------------------'
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub


#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-08-11</remarks>
    Private Sub LoadServiceManager()

        Try

            Pub = PubServiceManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB991", ex)
        End Try


    End Sub

#End Region

#Region "     載入事件管理員(EventManager) "

    ''' <summary>
    ''' 載入EventManager的Instance
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-8-11</remarks>
    Private Sub LoadEventManager()

        Try

            eventMgr = EventManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB992", ex)
        End Try

    End Sub

#End Region

#Region "     關閉事件管理員(EventManager) "

    ''' <summary>
    ''' 關閉事件管理員(EventManager)
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-08-11</remarks>
    Private Sub UIDisposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        Try

            eventMgr = Nothing
            Pub = Nothing
            If gblMainDataInfoDS IsNot Nothing Then
                gblMainDataInfoDS.Clear()
                gblMainDataInfoDS = Nothing
            End If
            If gblGridCloumnInfoDS IsNot Nothing Then
                gblGridCloumnInfoDS.Clear()
                gblGridCloumnInfoDS = Nothing
            End If
            If gblReportDataDS IsNot Nothing Then
                gblReportDataDS.Clear()
                gblReportDataDS = Nothing
            End If
            If gblColumnInfoDS IsNot Nothing Then
                gblColumnInfoDS.Clear()
                gblColumnInfoDS = Nothing
            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB993", ex)
        End Try

    End Sub

#End Region

#End Region

#Region "     必填檢查 "

#Region "     *欄位檢查 - True 檢查不通過;False 檢查通過 "

    ''' <summary>
    ''' 欄位檢查 - True 檢查不通過;False 檢查通過
    ''' </summary>
    ''' <remarks>by Will.Lin on 2015-8-5</remarks>
    Public Function fieldCheckResult() As Boolean

        Dim returnBoolean As Boolean = False

        '儲存要顯示 Error 字串
        Dim stbErrorCollection As StringBuilder = New StringBuilder

        Try

            Dim Controls As Control
            Dim ColumnName As String = ""
            '針對不同控制項作必填檢查，控制項前一個label必為控制項的欄位名稱
            For Each Controls In Me.tbl_Main.Controls
                Dim IsNreq = gblColumnInfoDS.Tables(0).AsEnumerable(). _
                                      Where(Function(c) c("Field_Code").ToString.Trim = Controls.Name.ToString.Trim And c("Is_Nreq").ToString.Trim = "Y").Count

                If IsNreq = 0 Then
                    Select Case Controls.GetType
                        Case GetType(TextBox)
                            If Controls.Text.ToString = "" Then
                                stbErrorCollection.Append(ColumnName & "、")
                            End If
                        Case GetType(Label)
                            ColumnName = Controls.Text.ToString
                        Case GetType(UCLDateTimePickerUC)

                            If Not IsDate(Controls.Text.Trim) Then
                                stbErrorCollection.Append(ColumnName & "、")
                            End If

                        Case GetType(UCLChartNoUC)
                            If Controls.Text.ToString = "" Then
                                stbErrorCollection.Append(ColumnName & "、")
                            End If
                        Case GetType(UCLTextCodeQueryUI)
                            If Controls.Text.ToString = "" Then
                                stbErrorCollection.Append(ColumnName & "、")
                            End If
                    End Select
                End If
            Next

            '欄位check錯誤


            Dim finalErrorString As String = stbErrorCollection.ToString

            '有值
            If finalErrorString.Length > 0 Then

                '去掉最後一個逗號
                finalErrorString = finalErrorString.Substring(0, finalErrorString.Length - 1)

                finalErrorString = finalErrorString & "不得為空"

                MessageHandling.ShowErrorMsg("CMMCMMB300", finalErrorString)
                returnBoolean = True
            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"欄位檢查 - True 檢查不通過;False 檢查通過"})
        End Try

    End Function

#End Region

#End Region

#Region "     事件集合 "

#Region "     取得查詢條件"

    Private Function GetQueryCondition() As Object
        Dim querySql As String
        Dim connectionName As String
        Dim controls As Control
        Dim Index As Int32 = 0
        Try
            '取得連線名稱
            connectionName = nvl(gblMainDataInfoDS.Tables(0).Rows(0).Item("ConnectionName"))
            '取得報表查詢SQL
            querySql = nvl(gblMainDataInfoDS.Tables(0).Rows(0).Item("Report_Sql"))

            '根據各種欄位型別下去取得控制項名稱與內容
            For Each controls In Me.tbl_Main.Controls
                Dim query = (From g In gblColumnInfoDS.Tables(0).AsEnumerable.Where(Function(r) r("Field_Code").ToString.Trim = controls.Name.ToString.Trim). _
                             Select(Function(r) New With {.Is_Nreq = r.Item("Is_Nreq"), .Field_Nreq_Code = r.Item("Field_Nreq_Code").ToString.Trim, .Field_Nreq_Cond = r.Item("Field_Nreq_Cond").ToString.Trim})).ToList

                '=====2017/03/09  若該控制項為非必要(Is_Nreq=Y)則將Field_Nreq_Code 取代為空白或者 Field_Nreq_Cond===

                Select Case controls.GetType
                    Case GetType(TextBox)
                        If query(0).Is_Nreq.ToString.Equals("Y") AndAlso controls.Text.ToString = "" Then
                            querySql = querySql.Replace(query(0).Field_Nreq_Code, query(0).Field_Nreq_Cond)
                        Else
                            querySql = querySql.Replace(controls.Name.ToString, "'" & controls.Text.ToString & "'")
                        End If
                         '順便填入查詢條件資料
                        'glbQueryCond(Index, 0) = controls.Name.ToString
                        glbQueryCond(Index, 1) = controls.Text.ToString
                        Index += 1
                    Case GetType(UCLDateTimePickerUC)
                        Dim obj As Object = controls
                        '順便填入查詢條件資料
                        If obj.tag = "yyyymmdd" Then
                            '非必要欄位如果沒填就replace掉
                            If query(0).Is_Nreq.ToString.Equals("Y") AndAlso CType(controls, UCLDateTimePickerUC).GetUsDateStr = "" Then
                                querySql = querySql.Replace(query(0).Field_Nreq_Code, query(0).Field_Nreq_Cond)
                            Else
                                querySql = querySql.Replace(controls.Name.ToString, "'" & obj.GetUsDateStr.ToString & "'")
                            End If
                            glbQueryCond(Index, 1) = obj.GetUsDateStr.ToString
                        Else
                            '非必要欄位如果沒填就replace掉
                            If query(0).Is_Nreq.ToString.Equals("Y") AndAlso CType(controls, UCLDateTimePickerUC).GetUsDateStr = "" Then
                                querySql = querySql.Replace(query(0).Field_Nreq_Code, query(0).Field_Nreq_Cond)
                            Else
                                querySql = querySql.Replace(controls.Name.ToString, "'" & obj.GetUsDateStr.ToString.Substring(0, 8) & "'")
                            End If
                            glbQueryCond(Index, 1) = obj.GetUsDateStr.ToString.Substring(0, 8)
                        End If
                        Index += 1
                    Case GetType(UCLYmPickerUC)
                        Dim obj As Object = controls
                        '順便填入查詢條件資料
                        If obj.tag = "ym" Then
                            '非必要欄位如果沒填就replace掉
                            If query(0).Is_Nreq.ToString.Equals("Y") AndAlso CType(controls, UCLYmPickerUC).GetUsYmStr = "" Then
                                querySql = querySql.Replace(query(0).Field_Nreq_Code, query(0).Field_Nreq_Cond)
                            Else
                                querySql = querySql.Replace(controls.Name.ToString, "'" & obj.GetUsYmStr.ToString & "'")
                            End If
                            glbQueryCond(Index, 1) = CType(obj, UCLYmPickerUC).GetTwYmStr
                        Else
                            '非必要欄位如果沒填就replace掉
                            If query(0).Is_Nreq.ToString.Equals("Y") AndAlso CType(controls, UCLYmPickerUC).GetUsYmStr = "" Then
                                querySql = querySql.Replace(query(0).Field_Nreq_Code, query(0).Field_Nreq_Cond)
                            Else
                                querySql = querySql.Replace(controls.Name.ToString, "'" & obj.GetUsYmStr & "'")
                            End If
                            glbQueryCond(Index, 1) = obj.GetUsYmStr
                        End If
                        Index += 1
                    Case GetType(UCLChartNoUC)
                        '非必要欄位如果沒填就replace掉
                        If query(0).Is_Nreq.ToString.Equals("Y") AndAlso controls.Text.ToString = "" Then
                            querySql = querySql.Replace(query(0).Field_Nreq_Code, query(0).Field_Nreq_Cond)
                        Else
                            querySql = querySql.Replace(controls.Name.ToString, "'" & controls.Text.ToString & "'")
                        End If
                        '順便填入查詢條件資料
                        glbQueryCond(Index, 1) = controls.Text.ToString
                        Index += 1
                    Case GetType(UCLTextCodeQueryUI)
                        Dim obj As Object = controls
                        '非必要欄位如果沒填就replace掉
                        If query(0).Is_Nreq.ToString.Equals("Y") AndAlso controls.Text.ToString = "" Then
                            querySql = querySql.Replace(query(0).Field_Nreq_Code, query(0).Field_Nreq_Cond)
                        Else
                            querySql = querySql.Replace(obj.Name.ToString, "'" & obj.uclCodeValue1 & "'")
                        End If
                         '順便填入查詢條件資料
                        glbQueryCond(Index, 1) = obj.uclCodeValue1
                        Index += 1
                    Case GetType(UCLComboBoxUC)
                        Dim obj As Object = controls
                        '非必要欄位如果沒填就replace掉
                        If query(0).Is_Nreq.ToString.Equals("Y") AndAlso controls.Text.ToString = "" Then
                            querySql = querySql.Replace(query(0).Field_Nreq_Code, query(0).Field_Nreq_Cond)
                        Else
                            querySql = querySql.Replace(obj.Name.ToString, "'" & CType(obj, UCLComboBoxUC).SelectedValue & "'")

                        End If
                        '順便填入查詢條件資料
                        glbQueryCond(Index, 1) = CType(obj, UCLComboBoxUC).SelectedValue
                        Index += 1
                    Case GetType(Label)
                        glbQueryCond(Index, 0) = controls.Text.ToString
                End Select
            Next
            glbSqlString = querySql

            Return {querySql, connectionName}
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "     列印表頭"

    ''' <summary>
    ''' 列印時負責處理表頭與標題欄位的部分
    ''' <paramref name=" xlSheet ">列印中的sheet元件</paramref>
    ''' <paramref name=" printDT ">要匯出的資料集</paramref>
    ''' <paramref name=" clnName ">標題欄位名稱陣列</paramref>
    ''' </summary>
    ''' <remarks>by Will.Lin on 2015-8-5</remarks>
    Private Sub PrintHeadFont(ByVal Report_Name As String, ByRef xlSheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal printDT As DataTable, ByVal clnName As String(), ByVal cond As String(,), ByRef RowIndex As Integer)
        Try

            Dim columnEnd As Integer = 3
            If printDT.Columns.Count > 3 Then
                columnEnd = printDT.Columns.Count
            End If
            '列印報表名稱
            xlSheet.Cells(RowIndex, 1) = Report_Name
            xlSheet.Cells(RowIndex, 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlSheet.Cells(RowIndex, 1).Font.Size = 20
            xlSheet.Cells(RowIndex, 1).Font.Name = "標楷體"
            '設定第一列儲存格合併
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, printDT.Columns.Count)).Merge()
            RowIndex += 1

            '列印報表編號
            xlSheet.Cells(RowIndex, 1) = "報表編號：" & glbReport_Id
            xlSheet.Cells(RowIndex, 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
            xlSheet.Cells(RowIndex, 1).Font.Size = 10
            xlSheet.Cells(RowIndex, 1).Font.Name = "標楷體"
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, 3)).Merge()
            RowIndex += 1
            '列印查詢時間
            xlSheet.Cells(RowIndex, columnEnd - 1) = "列印日期：" & TransDateToROC(Now.ToString("yyyy/MM/dd")) & " " & Now.ToString("HH:mm")
            xlSheet.Cells(RowIndex, columnEnd - 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            xlSheet.Cells(RowIndex, columnEnd - 1).Font.Size = 10
            xlSheet.Cells(RowIndex, columnEnd - 1).Font.Name = "標楷體"
            xlSheet.Range(xlSheet.Cells(RowIndex, printDT.Columns.Count - 1), xlSheet.Cells(RowIndex, printDT.Columns.Count)).Merge()

            '列印查詢人員
            xlSheet.Cells(RowIndex, 1) = "列印人員：" & AppContext.userProfile.userName
            xlSheet.Cells(RowIndex, 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
            xlSheet.Cells(RowIndex, 1).Font.Size = 10
            xlSheet.Cells(RowIndex, 1).Font.Name = "標楷體"
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, 2)).Merge()
            RowIndex += 1

            '列印查詢條件
            Dim condStr As String = ""
            For i As Int32 = 0 To gblColumnInfoDS.Tables(0).Rows.Count - 1
                '對日期做轉民國年的輸出
                If IsDate(cond(i, 1)) AndAlso (cond(i, 1).Length >= 8 AndAlso cond(i, 1).Length <= 10) Then
                    condStr += cond(i, 0) & "：【" & TransDateToROC(cond(i, 1)) & "】 /"
                Else
                    condStr += cond(i, 0) & "：【" & cond(i, 1) & "】 /"
                End If
            Next
            If condStr.Length > 0 Then
                condStr = condStr.Substring(0, condStr.Length - 1)
            Else
                condStr = "【查詢全部】"
            End If
             xlSheet.Cells(RowIndex, 1) = "查詢條件：" & condStr
            xlSheet.Cells(RowIndex, 1).Font.Size = 10
            xlSheet.Cells(RowIndex, 1).Font.Name = "標楷體"
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, printDT.Columns.Count)).Merge()
            xlSheet.Cells(RowIndex, 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
            RowIndex += 1



            '填入表頭的Title
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, printDT.Columns.Count)).Value = clnName
            '設置表頭字體、大小並且置中
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, printDT.Columns.Count)).Font.Name = "標楷體"
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, printDT.Columns.Count)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            '依照欄位標題字體長度去計算欄位寬度
            Dim clnWidth As Int32 = 0
            For i As Integer = 0 To clnName.Length - 1
                clnWidth = clnName(i).Length
                xlSheet.Columns(i + 1).ColumnWidth = (2.5 * clnWidth)
            Next
            '畫上框線
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, printDT.Columns.Count)).Borders(8).LineStyle = 1
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, printDT.Columns.Count)).Borders(8).Weight = 2
            '畫下框線
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, printDT.Columns.Count)).Borders(9).LineStyle = 1
            xlSheet.Range(xlSheet.Cells(RowIndex, 1), xlSheet.Cells(RowIndex, printDT.Columns.Count)).Borders(9).Weight = 2
            RowIndex += 1

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "



#Region "     查詢/清除 鎖定功能 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Public Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_query.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (QueryData()) Then

                '左下方顯示 查詢 成功
                ShowInfoMsg("CMMCMMB301", "查詢")
            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FormatException
            Throw fex
        Catch cmex As CommonException
            MessageHandling.ShowErrorMsg("CMMCMMB300", "SQL查詢錯誤：" & vbCrLf & glbSqlString)
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢 鎖定功能"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub
    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Will,Lin on 2015-09-23</remarks>
    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            dgv_ShowReport.Visible = False
            btn_export.Visible = False
            '根據各種欄位型別下去個別清除
            Dim Controls As Control
            For Each Controls In Me.tbl_Main.Controls
                Select Case Controls.GetType
                    Case GetType(TextBox), GetType(UCLDateTimePickerUC), GetType(UCLTextCodeQueryUI)
                        Controls.Text = ""
                    Case GetType(UCLYmPickerUC)
                        Dim obj As Object = Controls
                        CType(Controls, UCLYmPickerUC).Clear()
                    Case GetType(UCLChartNoUC)
                        Dim obj As Object = Controls
                        obj.ClearPatientData()
                        obj.ClearPatientObj()
                End Select
            Next
  

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FormatException
            Throw fex
        Catch cmex As CommonException
            MessageHandling.ShowErrorMsg("CMMCMMB300", "")
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"清除 鎖定功能"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try
    End Sub

#End Region


#End Region

#Region "     HotKey設定 "

    ' ''' <summary>
    ' ''' HotKey設定
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks>by Will,Lin on 2015-08-11</remarks>
    Public Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode
                Case Keys.F1
                    '查詢
                    'MessageHandling.clearInfoMsg()
                    btn_Query_Click(sender, e)

                Case Keys.F5
                    '清除
                    btn_clear_Click(sender, e)
                Case Keys.F7
                    '匯出
                    'MessageHandling.clearInfoMsg()
                    btn_export_Click(sender, e)
                Case Keys.Enter
                    Me.ProcessTabKey(True)
            End Select

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"HotKey設定"})

        Finally

            '解除螢幕鎖定
            UnLock(Me)

        End Try

    End Sub

#End Region

#End Region

#End Region

#Region "     外部函數"
    ''' <summary>
    ''' 針對元件填入預設值  傳入二維陣列 元件名稱+預設值
    ''' </summary>
    ''' <param name="ds">dat</param>
    ''' <remarks></remarks>
    Public Sub SetControlDefaultValue(ByVal ds As DataSet)
        Dim crlName As String = ""
        Dim crlValue As String = ""
        Try
            If CheckMethodUtil.CheckHasValue(ds, "ExportDetailDT") Then
                For i As Int32 = 0 To ds.Tables("ExportDetailDT").Rows.Count - 1
                    crlName = ds.Tables("ExportDetailDT").Rows(i).Item("Field_Code").ToString.Trim
                    crlValue = ds.Tables("ExportDetailDT").Rows(i).Item("Default_Value").ToString.Trim
                    Dim crl As Control = Me.Controls.Find(crlName, True)(0)
                    Select Case crl.GetType
                        Case GetType(TextBox)
                            crl.Text = crlValue
                        Case GetType(UCLDateTimePickerUC)
                            If IsDate(crlValue) Then
                                CType(crl, UCLDateTimePickerUC).SetValue(crlValue)
                            ElseIf IsNumeric(crlValue) Then
                                CType(crl, UCLDateTimePickerUC).SetValue(Now.AddDays(crlValue))
                            End If
                        Case GetType(UCLYmPickerUC)
                            If crlValue.ToString.Trim <> "" Then
                                CType(crl, UCLYmPickerUC).SetValue(crlValue)
                            End If
                        Case GetType(UCLTextCodeQueryUI)
                            CType(crl, UCLTextCodeQueryUI).ProcessQuery(crlValue)
                        Case GetType(UCLChartNoUC)
                            CType(crl, UCLChartNoUC).SetTextToQuery(crlValue, UCLChartNoUC.uclTextTypeData.ChartNo)
                        Case GetType(UCLComboBoxUC)
                            CType(crl, UCLComboBoxUC).SelectedValue = crlValue

                    End Select
                Next
            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化預設值"})
        End Try

    End Sub
#End Region
End Class

