'/*
'*****************************************************************************
'*
'*    Page/Class Name:  登入失敗超過3次查詢
'*              Title:	ArmLogonFailureUI
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Hsiao,Kaiwen
'*        Create Date:	2016-02-18
'*      Last Modifier:	Hsiao,Kaiwen
'*   Last Modify Date:	2016-02-18
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

Imports System.Windows.Forms

Public Class ArmLogonFailureUI

#Region "     變數宣告 "

    '未來匯出Excel使用
    Dim ResultExcelDS As DataSet

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

#End Region

#Region "     Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = {"Employee_Code", "Employee_Name", "Login_Try_Date", "Login_Try_Times", "Machine_Name", "IP_Address"}

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = DataSetUtil.GenDataTable(gblColumnNameDB)

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "員工代碼,員工名稱,重新登入日期,重新登入次數,登入機器名稱,登入電腦IP"
    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "90,90,150,80,90,110"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1,2,3,4,5"

    '*******************************************************************************

#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim ArmSerMan As IArmServiceManager

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As ArmLogonFailureUI
    Public Shared Function GetInstance() As ArmLogonFailureUI
        If myInstance Is Nothing Then
            myInstance = New ArmLogonFailureUI
        End If
        Return myInstance
    End Function

#End Region

#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Hsiao,Kaiwen on 2016-02-18</remarks>
    Private Function QueryData() As Boolean

        Try

            Dim returnBoolean As Boolean = False

            '查詢成功後儲存的 DS
            Dim queryDS As DataSet
            queryDS = ArmSerMan.ArmLogonFailureQueryLoginFailure(nvl(dtp_StartDay.GetUsDateStr), nvl(dtp_EndDay.GetUsDateStr))

            '將資料放入之後要輸出的Excel Dataset
            ResultExcelDS = queryDS.Copy

            '有查到 Table 要回傳True
            If CheckHasTable(queryDS) Then

                '如果資料列為零要顯示查無符合條件資料
                If queryDS.Tables(0).Rows.Count = 0 Then

                    MessageHandling.ShowWarnMsg("CMMCMMB933", New String() {})

                End If

                '顯示資料在 Grid 上
                UCLScreenUtil.ShowDgv(dgvShowData, queryDS, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)

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

#Region "     匯出Excel "
    ''' <summary>
    ''' 匯出Excel
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GenExcelData() As Boolean
        Try
            '先檢查是否有資料
            If dgvShowData.GetDBDS Is Nothing Then
                'Exit Function
                Return False
            End If

            Dim returnBoolean As Boolean = False
            '報表欄位名稱
            Dim str_ColumnName As String() = {"員工代碼", "員工名稱", "重新登入日期", "重新登入次數", "登入機器名稱", "登入電腦IP"}
            '報表欄位寬度
            Dim str_ColumnWidth As String() = {"20", "20", "30", "20", "20", "30"}

            Syscom.Client.CMM.CmmMethodUtil.DataToExcelWithFormate(ResultExcelDS.Tables(0), str_ColumnName, str_ColumnWidth, DateUtil.TransDateTimeToROC(Date.Now) & "登入失敗次數超過3次", "ARMRPT00001", False)

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

#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Hsiao,Kaiwen on 2016-02-18</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region

#Region "     顯示空的Dataset 在　Grid 上 "

    ''' <summary>
    ''' 顯示空的Dataset 在　Grid 上
    ''' </summary>
    ''' <remarks>by Hsiao.Kaiwen on 2015-8-27</remarks>
    Private Sub ShowDgv()

        Try

            '顯示空的Dataset 在　Grid 上
            UCLScreenUtil.ShowDgv(dgvShowData, gblEmptyDT, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - DataGridView"})
        End Try

    End Sub

#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Hsiao,Kaiwen on 2016-02-18</remarks>
    Private Sub LoadServiceManager()

        Try

            ArmSerMan = ArmServiceManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB991", ex)
        End Try


    End Sub

#End Region

#End Region

#Region "     事件集合 "



#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     查詢 鎖定功能 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Hsiao,Kaiwen on 2016-02-18</remarks>
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

#Region "     匯出Excel 鎖定功能 "

    ''' <summary>
    ''' 匯出Excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Excel_Click(sender As Object, e As EventArgs) Handles btn_Excel.Click
        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (GenExcelData()) Then

                '左下方顯示 查詢 成功
                ShowInfoMsg("CMMCMMB301", "匯出Excel")

            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"匯出Excel 鎖定功能"})
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
    ''' <remarks>by Hsiao,Kaiwen on 2016-02-18</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode

                Case Keys.F1

                    '查詢
                    If btn_Query.Enabled Then
                        btn_Query.PerformClick()
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

