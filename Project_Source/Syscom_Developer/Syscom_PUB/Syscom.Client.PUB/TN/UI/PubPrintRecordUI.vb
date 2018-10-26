'/*
'*****************************************************************************
'*
'*    Page/Class Name:  報表列印記錄檔查詢作業
'*              Title:	PubPrintRecordUI
'*        Description:	1.查詢 2.清除 3.匯出
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	ChenYu.Guo
'*        Create Date:	2015-06-02
'*      Last Modifier:	ChenYu.Guo
'*   Last Modify Date:	2015-06-02
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
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.PUB.PubConfigUI
Imports System.Text


Public Class PubPrintRecordUI
    Inherits Syscom.Client.UCL.BaseFormUI

#Region "     變數宣告 "

#Region "     使用者宣告　"

    '存檔的Table欄位
    Private gblColumnNameDB As String() = PubPrintRecordDataTableFactory.columnsName

    '存檔的Table Name
    Private gblTableName As String = PubPrintRecordDataTableFactory.tableName

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = PubPrintRecordDataTableFactory.getDataTable

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "報表代碼,報表名稱,列印者,列印時間,機器名稱,IP,IPv6"

    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "150,150,100,200,100,200,300"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1,2,3,4,5,6"

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

#Region "     屬性設定 "

    Dim dsDB As DataSet

#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by ChenYu.Guo on 2015-06-02</remarks>
    Private Function QueryData() As Boolean

        Try

            Dim returnBoolean As Boolean
            
            dsDB = Pub.PubPrintRecordQueryPrintRecord(nvl(txt_Report_ID.Text), nvl(txt_Report_Name.Text), nvl(txt_Create_User.Text), nvl(ti_Create_Time.GetTimeInterval(0)), nvl(ti_Create_Time.GetTimeInterval(1)), nvl(txt_Print_IP.Text))

            '有查到 Table 要回傳True
            If CheckHasTable(dsDB) Then

                '如果資料列為零要顯示查無符合條件資料
                If dsDB.Tables(0).Rows.Count = 0 Then

                    MessageHandling.ShowWarnMsg("CMMCMMB933", New String() {})

                End If

                '顯示資料在 Grid 上

                UCLScreenUtil.ShowDgv(dgv_Data, dsDB, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)

                returnBoolean = True

            End If

            Return returnBoolean
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try

    End Function

#End Region

#Region "     清除 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by ChenYu.Guo on 2015-06-02</remarks>
    Private Function ClearData() As Boolean

        Try

            Dim returnBoolean As Boolean = True

            CleanControls(tlp_Main)

            Return returnBoolean

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB916", ex)
        End Try

    End Function

#End Region

#Region "     匯出Excel "

    Private Sub btn_ExportExcel_Click(sender As Object, e As EventArgs) Handles btn_ExportExcel.Click
        If dsDB IsNot Nothing Then
            DataSetUtil.DataSetToExcel(dsDB, New String() {"報表代碼", "報表名稱", "列印者", "列印時間", "機器名稱", "IP", "IPv6"})
        End If
    End Sub

#End Region

#End Region

#Region "     Grid事件 "

#Region "     資料被點選時的相應動作 "
    Private Sub dgv_Data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Data.CellClick
        dgvCellClick()
    End Sub
#End Region

#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by ChenYu.Guo on 2015-06-02</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()

            '初始化 - DataGridView
            ShowDgv()

            Me.KeyPreview = True

        Catch fex As FaultException
            Throw fex
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
    ''' <remarks>by ChenYu.Guo on 2015-06-02</remarks>
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
    ''' <remarks>by ChenYu.Guo on 2015-06-02</remarks>
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
    ''' <remarks>by ChenYu.Guo on 2015-06-02</remarks>
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

#Region "     顯示空的Dataset 在　Grid 上 "

    ''' <summary>
    ''' 顯示空的Dataset 在　Grid 上
    ''' </summary>
    ''' <remarks>by ChenYu.Guo on 2015-6-1</remarks>
    Private Sub ShowDgv()

        Try

            '顯示空的Dataset 在　Grid 上
            UCLScreenUtil.ShowDgv(dgv_Data, gblEmptyDT, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - DataGridView"})
        End Try

    End Sub

#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     查詢 鎖定功能 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (QueryData()) Then

                '左下方顯示 查詢 成功
                ShowInfoMsg("CMMCMMB301", "查詢")

            End If

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

#Region "     清除 鎖定功能 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Sub btn_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Clear.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (ClearData()) Then

                '左下方顯示 清除 成功
                ShowInfoMsg("CMMCMMB301", "清除")

            End If

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
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

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Alan.Tsai on 2014-11-04</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode

                Case Keys.F12



                Case Keys.F1

                    '查詢
                    If btn_Query.Enabled Then
                        btn_Query.PerformClick()
                    End If

                Case Keys.F5

                    '清除
                    If btn_Clear.Enabled Then
                        btn_Clear.PerformClick()
                    End If

                    'Case Keys.Enter
                    'Me.ProcessTabKey(True)

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

#Region "     資料被點選時的相應動作 "

    ''' <summary>
    ''' 資料被點選時的相應動作
    ''' </summary>
    ''' <remarks>by ChenYu.Guo on 2015-6-1</remarks>
    Public Sub dgvCellClick()

        Try

            CleanControlsBackcolor(tlp_Main)

            If dgv_Data.CurrentCellAddress.Y >= 0 Then

                '設定報表代碼的控制項
                txt_Report_ID.Text = StringUtil.nvl(dgv_Data.Rows(dgv_Data.CurrentCellAddress.Y).Cells("Report_ID").Value)

                '設定報表名稱的控制項
                txt_Report_Name.Text = StringUtil.nvl(dgv_Data.Rows(dgv_Data.CurrentCellAddress.Y).Cells("Report_Name").Value)

                '設定建立者的控制項
                txt_Create_User.Text = StringUtil.nvl(dgv_Data.Rows(dgv_Data.CurrentCellAddress.Y).Cells("Create_User").Value)

                If StringUtil.nvl(dgv_Data.Rows(dgv_Data.CurrentCellAddress.Y).Cells("Print_IP").Value) <> "" Then
                    '設定列印IPv4的控制項
                    txt_Print_IP.Text = StringUtil.nvl(dgv_Data.Rows(dgv_Data.CurrentCellAddress.Y).Cells("Print_IP").Value)
                Else
                    '設定列印IPv6的控制項
                    txt_Print_IP.Text = StringUtil.nvl(dgv_Data.Rows(dgv_Data.CurrentCellAddress.Y).Cells("Print_IPv6").Value)
                End If

            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"資料被點選時的相應動作"})
        End Try

    End Sub

#End Region

#End Region

End Class