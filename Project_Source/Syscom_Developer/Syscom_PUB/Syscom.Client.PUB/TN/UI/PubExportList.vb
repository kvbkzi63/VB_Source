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

Imports System.ServiceModel

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.Text

Public Class PubExportList

#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

    '表單代號
    Dim glbReport_Id As String = ""
    '查詢欄位資訊
    Private glbcolumnInfoDS As New DataSet
    '報表主要資訊
    Private glbmainDataInfoDS As New DataSet
    'Grid欄位資訊
    Private glbGridCloumnInfoDS As New DataSet
    '列印的報表資料
    Private glbReportDataDS As New DataSet
    'Excel欄位名稱設定
    Private columnNameExcelTitle As String = ""

#End Region

#Region "     定義各種長度或高度變數 "

    '定義TextBox的長度的比例
    Dim TextBox_Width_Const As Int32 = 5

    '定義TableLayout的行高度的比例
    Dim Global_Row_Height As Int32 = 40

    '輔助計算隱藏的Panel的高度的數值
    Dim Global_Int_Sub_Panel_Radio As Int32 = 0

    '一行的字數
    Dim gblTextMaxLength As Integer = 63

    '一行的寬度
    Dim Global_Row_Width As Double = (960 * 80 / 100)
    'Dim Global_Row_Width As Double = (Me.TableLayoutPanel1.Width * 80 / 100)

#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim Pub As IPubServiceManager

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubExportList
    Public Shared Function GetInstance() As PubExportList
        If myInstance Is Nothing Then
            myInstance = New PubExportList
        End If
        Return myInstance
    End Function

#End Region

#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager

#End Region

#End Region

#Region "     屬性設定 "



#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "　　匯出Excel"

    ''' <summary>
    ''' 匯出
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-08-13</remarks>
    Private Sub btn_export_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_export.Click

        If Me.btn_export.Tag Is Nothing Then
            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"無資料可匯出"})
            Exit Sub
        End If
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim xlBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        Dim xlRange As Microsoft.Office.Interop.Excel.Range = Nothing

        '----------------------------------------------------------------------------
        '#Step1.Create Excel物件
        '----------------------------------------------------------------------------
        'On Error Resume Next
        Try
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
            Dim clnName As String() = columnNameExcelTitle.Split(",")
            Dim printDT As System.Data.DataTable = CType(Me.btn_export.Tag, DataSet).Tables(0).Copy

            xlApp.Visible = False

            '開新活頁簿
            xlBook = xlApp.Workbooks.Add
            '設定活頁簿為焦點
            xlBook.Activate()
            '選取第1張活頁簿
            xlSheet = xlBook.Worksheets(1)
            '填入表頭的Title
            xlSheet.Range(xlSheet.Cells(1, 1), xlSheet.Cells(1, printDT.Columns.Count)).Value = clnName

            '填入表身資料
            For iRow As Integer = 0 To printDT.Rows.Count - 1
                xlSheet.Range(xlSheet.Cells(iRow + 2, 1), xlSheet.Cells(iRow + 2, printDT.Columns.Count)).Value = printDT.Rows(iRow).ItemArray
            Next

            ''儲存Excel
            'xlBook.SaveAs(filePath)
            xlApp.Visible = True


        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
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
            Dim param As Object = getQueryCondition()
            glbReportDataDS = Pub.PubExportQueryData(param(0), param(1))


            '******************************************************************************




            '有查到 Table 要回傳True
            If CheckHasTable(glbReportDataDS) Then

                '如果資料列為零要顯示查無符合條件資料
                If glbReportDataDS.Tables(0).Rows.Count = 0 Then

                    MessageHandling.ShowWarnMsg("CMMCMMB933", New String() {})
                    returnBoolean = False
                Else
                    Me.btn_export.Tag = glbReportDataDS

                    '顯示資料在 Grid 上
                    dgv_ShowReport.Visible = True
                    dgv_ShowReport.DataSource = glbReportDataDS
                    dgv_ShowReport.uclReadOnly = True
                    For Each dc As DataColumn In glbReportDataDS.Tables(0).Columns
                        columnNameExcelTitle += dc.ColumnName + ","
                    Next
                    columnNameExcelTitle = columnNameExcelTitle.Substring(0, columnNameExcelTitle.Length - 1)
                    returnBoolean = True
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

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "



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
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-08-11</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()

            '取得初始化資料
            initialize()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

    ''' <summary>
    ''' 取得初始化相關資訊
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-08-11</remarks>
    Public Sub initialize()

        Try
            '取得report_id
            If Me.glbReport_Id = "" Then

            End If
            Me.KeyPreview = True
            Dim InitialDS As DataSet = Pub.PubExportListDataQuery(Me.glbReport_Id)
            '取得報表列印相關資訊
            glbmainDataInfoDS.Tables.Add(InitialDS.Tables("ExportDT").Copy)
            '取得畫面上查詢欄位資訊
            glbcolumnInfoDS.Tables.Add(InitialDS.Tables("ExportDetailDT").Copy)
            If glbcolumnInfoDS.Tables.Count = 0 AndAlso glbcolumnInfoDS.Tables(0).Rows.Count < 1 AndAlso nvl(glbcolumnInfoDS.Tables(0).Rows.Item("Dc")) = "Y" Then
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"查無資料！"}, "")
                Me.Close()
            End If
            '設定畫面上的查詢條件欄位
            setControl(glbcolumnInfoDS, tbl_Main)
            '設定表單名稱
            If nvl(glbmainDataInfoDS.Tables(0).Rows(0).Item("Report_Name")) <> "" Then
                Me.Text = glbmainDataInfoDS.Tables(0).Rows(0).Item("Report_Name")
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
            Select Case nvl(Row_Input.Item("Form_Control_Type"))
                Case "TextBox"
                    '文字輸入 ; 文字在前 EX: 其他____

                    '設定物件為 Text Box ，並加入Tag (Text Box 不需要 Event) 
                    Control_Obj = New TextBox
                    Control_Obj.tag = Row_Input
                    'AddHandler CType(Control_Obj, TextBox).Click, AddressOf ObjectClick
                    If Not nvl(Row_Input.Item("Field_Name")) = "" Then
                        '要新增的Label
                        Dim Label_Obj As Label = New Label
                        Label_Obj.Tag = Row_Input
                        Label_Obj.AutoSize = True

                        '設定Label
                        Label_Obj.Text = nvl(Row_Input.Item("Field_Name"))
                        Label_Obj.ForeColor = Color.Red
                        '設定文字標籤長度
                        Label_Obj.Anchor = AnchorStyles.Right
                        '將Label加至TextBox前方
                        Panel_Input.Controls.Add(Label_Obj, Column_Index, Row_Count)
                    End If

                    '設定控制項
                    Control_Obj.Name = nvl(Row_Input.Item("Field_Code"))
                    Control_Obj.Anchor = AnchorStyles.Left
                    '設定TextBox長度
                    Panel_Input.Controls.Add(Control_Obj, Column_Index + 1, Row_Count)


                    If Not nvl(Row_Input.Item("Field_Description")) = "" Then
                        '要新增的Label
                        Dim Label_Obj As Label = New Label
                        Label_Obj.Tag = Row_Input
                        Label_Obj.AutoSize = True
                        '設定Label
                        Label_Obj.Text = nvl(Row_Input.Item("Field_Description"))
                        Label_Obj.ForeColor = Color.DarkGray
                        Label_Obj.Anchor = AnchorStyles.Left
                        '將Label加至TextBox後方
                        Panel_Input.Controls.Add(Label_Obj, Column_Index + 2, Row_Count)
                    End If
            End Select
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
            For Each Controls In Me.tbl_Main.Controls
                Select Case Controls.GetType
                    Case GetType(TextBox)
                        If Controls.Text.ToString = "" Then
                            stbErrorCollection.Append(ColumnName & "、")
                        End If
                    Case GetType(Label)
                        ColumnName = Controls.Text.ToString
                End Select
            Next

            '欄位check錯誤


            Dim finalErrorString As String = stbErrorCollection.ToString

            '有值
            If finalErrorString.Length > 0 Then

                '去掉最後一個逗號
                finalErrorString = finalErrorString.Substring(0, finalErrorString.Length - 2)

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

    Private Function getQueryCondition() As Object
        Dim querySql As String
        Dim connectionName As String
        Dim controls As Control
        '取得連線名稱
        connectionName = nvl(glbmainDataInfoDS.Tables(0).Rows(0).Item("ConnectionName"))
        '取得報表查詢SQL
        querySql = nvl(glbmainDataInfoDS.Tables(0).Rows(0).Item("Report_Sql"))

        '根據各種欄位型別下去取得控制項名稱與內容
        For Each controls In Me.tbl_Main.Controls
            Select Case controls.GetType
                Case GetType(TextBox)
                    querySql = querySql.Replace(controls.Name.ToString, controls.Text.ToString)
            End Select
        Next

        Return {querySql, connectionName}

    End Function
#End Region


#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "



#Region "     查詢 鎖定功能 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Private Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_query.Click

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
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢 鎖定功能"})
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
    'Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    '    Try

    '        '鎖定螢幕
    '        Lock(Me)

    '        Select Case e.KeyCode

    '            Case Keys.F12

    '                '如果按下Shift，則為刪除
    '                If e.Shift = True Then

    '                    '如果未按下Shift，則為新增/儲存
    '                Else

    '                    '儲存

    '                    If (btn_Save.Enabled) Then

    '                        btn_Save.PerformClick()

    '                    End If

    '                End If

    '                'Case Keys.Enter
    '                'Me.ProcessTabKey(True)

    '        End Select

    '    Catch cmex As CommonException
    '        Throw cmex
    '    Catch ex As Exception
    '        Throw New CommonException("CMMCMMB302", ex, New String() {"HotKey設定"})

    '    Finally

    '        '解除螢幕鎖定
    '        Unlock(Me)

    '    End Try

    'End Sub

#End Region

#End Region

#End Region

End Class

