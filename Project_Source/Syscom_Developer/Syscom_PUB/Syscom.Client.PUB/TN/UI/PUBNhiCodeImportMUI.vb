'/*
'*****************************************************************************
'*
'*    Page/Class Name:  轉入健保醫令價格異動檔-衛材
'*              Title:	PUBNhiCodeImportUI
'*        Description:	轉入健保醫令價格異動檔-衛材
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Chi,Wang
'*        Create Date:	2017-02-23
'*      Last Modifier:	Chi,Wang
'*   Last Modify Date:	2017-02-23
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
Imports Syscom.Client.CMM.CmmMethodUtil
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports Syscom.Comm.Utility.DateUtil

Public Class PUBNhiCodeImportMUI

#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

    Dim strNhi_Download_Sn As String = ""
    Dim strInsu_Code As String = ""
    Dim strEffect_Date As String = ""

    Dim glbDS As DataSet 'query後得資料


#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim pub As IpubServiceManager

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBNhiCodeImportMUI
    Public Shared Function GetInstance() As PUBNhiCodeImportMUI
        If myInstance Is Nothing Then
            myInstance = New PUBNhiCodeImportMUI
        End If
        Return myInstance
    End Function

#End Region

#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager

#End Region

#End Region


#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     匯入excel按鈕 "

    '匯入excel按鈕  宣告事件
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance

    '匯入excel按鈕  宣告方法
    Private Sub ImportMExcel(ByVal ImportDs As DataSet) Handles pvtReceiveMgr.ImportExcel
        Try
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "確定中，請稍後‧‧‧")
            Dim Sourceds As DataSet = ImportDs

            '過濾起訖日
            Dim OrderFilterDS As New DataSet

            Dim DateStart As String = Dtp_ExcelStart.GetTwDateStr
            Dim DateEnd As String = Dtp_ExcelEnd.GetTwDateStr
            If Len(Dtp_ExcelStart.GetTwDateStr) < 9 Then
                DateStart = "0" & DateStart
            End If
            If Len(Dtp_ExcelEnd.GetTwDateStr) < 9 Then
                DateEnd = "0" & DateEnd
            End If

            If ImportDs.Tables(0).Select("生效日期>='" & DateStart & "' and 生效日期<='" & DateEnd & "'").Any Then
                OrderFilterDS.Tables.Add(ImportDs.Tables(0).Select("生效日期>='" & DateStart & "' and 生效日期<='" & DateEnd & "'").CopyToDataTable)
            Else
                OrderFilterDS.Tables.Add(ImportDs.Tables(0).Clone)
            End If

            If txt_version.Text <> "" Then
                '匯入excel 資料
                pub.PUBNhiCodeImportMImportCase(OrderFilterDS, txt_version.Text.Trim, CurrentUserID)
                QueryData()
            End If
        Catch fex As FaultException
            If fex.Code.Name = "SYSCMMA001" Then
                ShowErrorMsg("CMMCMMB300", "請檢查日期格式是否為YYY/MM/DD or YYY/M/D or YYY/MM/D or YYY/M/DD or YYYMMDD")
            End If
        Catch ex As Exception
            If ex.Message = "遠端伺服器傳回未預期的回應: (413) Request Entity Too Large。" Then
                ShowErrorMsg("CMMCMMB300", "資料量過大，請縮小起訖日範圍!")
                Exit Sub
            End If
        Finally
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try


    End Sub
#End Region

#Region "     查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Private Function QueryData() As Boolean

        Try

            Dim returnBoolean As Boolean = False
            Dim queryds As DataSet = pub.PUBNhiCodeImportMquery(txt_version.Text.Trim, txt_insucode.Text.Trim, Ucldtp_effectdate.GetUsDateStr)

            glbDS = queryds.Copy
            ShowDgv(dgvLog, queryds, "版本號,發文號,項次,生效日,健保碼,名稱,原核定價,新核定價,院內碼,廠牌,成分及含量,轉檔者,轉檔時間", "0,0,0,100,120,200,80,80,100,200,200,80,150", "4,5,6,7,8,9,10,11,12,13", False)
            Return returnBoolean

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try

    End Function

#End Region

#Region "     轉入醫令價格檔 "

    ''' <summary>
    ''' 轉入醫令價格檔
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Private Function TransforData(ByVal ds As DataSet) As Boolean

        Try

            Dim returnBoolean As Boolean = False
            Dim count As Integer = pub.PUBNhiCodeImportMimportorderprice(ds, CurrentUserID)
            If count > 0 Then
                returnBoolean = True
            End If
            Return returnBoolean

            '使用到WCF服務的時候必須要抓取 FaultException 
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
    ''' <returns >Boolean</returns>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Private Function ClearData() As Boolean

        Try

            Dim returnBoolean As Boolean = False
            '清空textbox
            txt_version.Text = ""
            txt_insucode.Text = ""
            Ucldtp_effectdate.Text = ""
            '清空gridview
            dgvLog.ClearDS()
            Dtp_ExcelStart.Text = ""
            Dtp_ExcelEnd.Text = ""

            Return returnBoolean

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB916", ex)
        End Try

    End Function

#End Region

#Region "     匯出 "

    ''' <summary>
    ''' 匯出
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Private Function ExportData(ByVal checkboxds As DataSet) As Boolean

        Try

            Dim returnBoolean As Boolean = False



            If CheckHasValue(checkboxds) Then

                '匯出並開啟Excel
                DataToExcelWithFormate(checkboxds.Tables(0), "版本號,發文號,項次,生效日,健保碼,名稱,原核定價,新核定價,院內碼,廠牌,成分及含量,轉檔者,轉檔時間".Split(","), Nothing, "匯出健保醫令價格異動檔", "", False)
                returnBoolean = True

            Else

                ShowWarnMsg("CMMCMMB300", "無資料匯出")

            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        End Try

    End Function

#End Region

#End Region
#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try
            '載入服務管理員
            LoadServiceManager()
            '載入事件管理員
            LoadEventManager()
            '剛點進畫面 若沒有輸入版本號 匯入不可按
            UclExcelImportMUC1.Enabled = False
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
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Private Sub LoadServiceManager()

        Try

            pub = pubServiceManager.getInstance()

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
    ''' <remarks>by Chi,Wang on 2016-9-19</remarks>
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
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
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



#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     查詢 鎖定功能 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Private Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_query.Click

        '鎖定螢幕
        Lock(Me)
        Try
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingStart", "查詢中，請稍後‧‧‧")
            '清除左下方訊息欄
            ClearInfoMsg()

            If (QueryData()) Then

                '左下方顯示 查詢 成功
                ShowInfoMsg("CMMCMMB301", "查詢")
            End If
            'Error 的最上層，處理例外訊息
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            '解除螢幕鎖定
            UnLock(Me)
            pvtReceiveMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try

    End Sub

#End Region

#Region "     清除 鎖定功能 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Private Sub btn_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (ClearData()) Then

                '左下方顯示 清除 成功
                ShowInfoMsg("CMMCMMB301", "清除")

            End If

            'Error 的最上層，處理例外訊息
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub

#End Region

#Region "    轉入醫令價格檔 鎖定功能 "

    ''' <summary>
    ''' 轉入醫令價格檔
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Private Sub btn_priceimport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_priceimport.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            Dim index As Int32() = dgvLog.GetSelectedIndex

            Dim checkboxds As New DataSet()
            If CheckHasTable(glbDS) = True Then
                If index IsNot Nothing Then
                    '取得使用者勾選資料
                    checkboxds.Tables.Add(glbDS.Tables(0).Clone)
                    For i As Integer = 0 To index.Count - 1 Step 1
                        For j As Integer = 0 To glbDS.Tables(0).Rows.Count - 1 Step 1
                            If index(i) = j Then
                                Dim row As DataRow = checkboxds.Tables(0).NewRow()
                                For Each col As DataColumn In glbDS.Tables(0).Columns
                                    row.Item(col.ColumnName) = glbDS.Tables(0).Rows(j).Item(col.ColumnName)
                                Next
                                checkboxds.Tables(0).Rows.Add(row)
                                Exit For
                            End If
                        Next
                    Next

                    '轉入醫令價格檔
                    If (TransforData(checkboxds)) Then
                        '左下方顯示 轉入醫令價格檔 成功
                        ShowInfoMsgBox("CMMCMMB301", "轉入醫令價格檔")
                    End If
                Else
                    ShowErrorMsg("CMMCMMB300", "需選擇要轉入的資料")
                End If
            Else
                ShowErrorMsg("CMMCMMB300", "需先查詢要轉入的資料")
            End If



            'Error 的最上層，處理例外訊息
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub

#End Region

#Region "     匯出 鎖定功能 "

    ''' <summary>
    ''' 匯出
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Private Sub btn_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_export.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()
            Dim index As Int32() = dgvLog.GetSelectedIndex
            Dim checkboxds As New DataSet()
            If CheckHasTable(glbDS) = True Then
                '取得使用者勾選資料
                If index IsNot Nothing Then
                    checkboxds.Tables.Add(glbDS.Tables(0).Clone)
                    For i As Integer = 0 To index.Count - 1 Step 1
                        For j As Integer = 0 To glbDS.Tables(0).Rows.Count - 1 Step 1
                            If index(i) = j Then
                                Dim row As DataRow = checkboxds.Tables(0).NewRow()
                                For Each col As DataColumn In glbDS.Tables(0).Columns
                                    row.Item(col.ColumnName) = glbDS.Tables(0).Rows(j).Item(col.ColumnName)
                                Next
                                checkboxds.Tables(0).Rows.Add(row)
                                Exit For
                            End If
                        Next
                    Next

                    If (ExportData(checkboxds)) Then

                        '左下方顯示 匯出 成功
                        ShowInfoMsg("CMMCMMB301", "匯出")

                    End If
                Else
                    ShowErrorMsg("CMMCMMB300", "需選擇要匯出的資料")
                End If
            Else
                ShowErrorMsg("CMMCMMB300", "需先查詢要匯出的資料")
            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"匯出 鎖定功能"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub

#End Region

#Region "txt_version.Text不可為空"
    Public Sub check() Handles txt_version.TextChanged, Dtp_ExcelStart.ValueChanged, Dtp_ExcelEnd.ValueChanged

        If txt_version.Text <> "" And Dtp_ExcelStart.GetTwDateStr <> "" And Dtp_ExcelEnd.GetTwDateStr <> "" Then
            UclExcelImportMUC1.Enabled = True
        Else
            UclExcelImportMUC1.Enabled = False
        End If
    End Sub

#End Region
#End Region

#Region "     HotKey設定 "

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Chi,Wang on 2016-09-19</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode


                Case Keys.F1

                    '查詢

                    If btn_query.Enabled Then
                        btn_query.PerformClick()
                    End If

                Case Keys.F5

                    '清除
                    If btn_clear.Enabled Then
                        btn_clear.PerformClick()
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



End Class

