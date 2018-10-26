'/*
'*****************************************************************************
'*
'*    Page/Class Name:  看診目的排序設定
'*              Title:	PUBMedicalTypeSortSetupUI
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Chi,Wang
'*        Create Date:	2017-04-06
'*      Last Modifier:	Chi,Wang
'*   Last Modify Date:	2017-04-06
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

Public Class PUBMedicalTypeSortSetupUI

#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim Pub As IPubServiceManager

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBMedicalTypeSortSetupUI
    Public Shared Function GetInstance() As PUBMedicalTypeSortSetupUI
        If myInstance Is Nothing Then
            myInstance = New PUBMedicalTypeSortSetupUI
        End If
        Return myInstance
    End Function

#End Region

#Region "     使用的欄位宣告 "

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "看診目的,名稱"

    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "100,200"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1" 

#End Region

#End Region

#Region "     使用的Event宣告 "

    '定義使用的Event介面
    Dim WithEvents eventMgr As EventManager

#End Region

#Region "     屬性設定 "



#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     儲存 "

    ''' <summary>
    ''' 儲存
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Private Function SaveData() As Boolean

        Try

            Dim returnBoolean As Boolean = False
            Dim ViewDs As DataSet = dgv_show.GetGridDS
            If tcq_employeecode.getCode <> "" Then
                Dim count As Integer = Pub.UpdatePubMedicalTypeSort(ViewDs, tcq_employeecode.getCode)

                If count = 1 Then
                    ShowInfoMsgBox("CMMCMMB300", "儲存完成!")
                End If
            End If
          
            Return returnBoolean

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB915", ex)
        End Try

    End Function

#End Region


#Region "     刪除 "

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Private Function DeleteData() As Boolean

        Try

            Dim returnBoolean As Boolean = False
            'DeletePubMedicalTypeSort
            If tcq_employeecode.getCode <> "" Then
                If MessageBox.Show("確定是否刪除?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Pub.DeletePubMedicalTypeSort(tcq_employeecode.getCode)

                    ShowInfoMsgBox("CMMCMMB300", "刪除成功!")
                    '清空
                    dgv_show.ClearDS()
                    tcq_employeecode.Clear()
                End If
            Else
                ShowWarnMsg("CMMCMMB300", "請輸入員工代號!")
            End If
          
            Return returnBoolean

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB914", ex)
        End Try

    End Function

#End Region

#Region "     查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Private Function QueryData() As Boolean

        Try

            Dim returnBoolean As Boolean = False
            Dim queryDS As DataSet
            Dim count As Integer = 0
            If tcq_employeecode.getCode <> "" Then

                '1.	新增排序檔
                count = Pub.InsertPubMedicalTypeSort(tcq_employeecode.getCode)

                '2.	Refresh Grid, 查詢sql如下
                queryDS = Pub.QueryPubMedicalTypeSort(tcq_employeecode.getCode)
                If queryDS.Tables.Count > 0 Then
                    If queryDS.Tables(0).Rows.Count > 0 Then
                        '顯示資料在 Grid 上
                        UCLScreenUtil.ShowDgv(dgv_show, queryDS, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)
                    Else
                        ShowInfoMsgBox("CMMCMMB300", "查無資料!")
                    End If
                Else
                    ShowInfoMsgBox("CMMCMMB300", "查無資料!")
                End If

            Else
                ShowWarnMsg("CMMCMMB300", "請輸入員工代號!")
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
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Private Function ClearData() As Boolean

        Try

            Dim returnBoolean As Boolean = False

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

#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "



#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()
            '載入事件管理員
            LoadEventManager()

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
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
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
    ''' <remarks>by ChenYu.Guo on 2015-9-22</remarks>
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
    ''' <remarks>by ChenYu.Guo on 2015-09-22</remarks>
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

#Region "     儲存 鎖定功能 "

    ''' <summary>
    ''' 儲存
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            clearInfoMsg()

            If (SaveData()) Then

                '左下方顯示 儲存 成功
                showInfoMsg("CMMCMMB301", "儲存")

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

#Region "     刪除 鎖定功能 "

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            clearInfoMsg()

            If (DeleteData()) Then

                '左下方顯示 刪除 成功
                showInfoMsg("CMMCMMB301", "刪除")

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

#Region "     查詢 鎖定功能 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Private Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            clearInfoMsg()

            If (QueryData()) Then

                '左下方顯示 查詢 成功
                showInfoMsg("CMMCMMB301", "查詢")

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

#End Region

#Region "     HotKey設定 "

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Chi,Wang on 2017-04-06</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode

                Case Keys.F12

                    '如果按下Shift，則為刪除
                    If e.Shift = True Then

                        '刪除
                        If (btn_Delete.Enabled) Then

                            btn_Delete.PerformClick()

                        End If


                        '如果未按下Shift，則為新增/儲存
                    Else

                        '儲存

                        If (btn_Save.Enabled) Then

                            btn_Save.PerformClick()

                        End If

                    End If

                Case Keys.F10

                    ''修改
                    'If btn_Update.Enabled Then
                    '    btn_Update.PerformClick()
                    'End If

                Case Keys.F1

                    '查詢
                    If btn_Query.Enabled Then
                        btn_Query.PerformClick()
                    End If

            End Select

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"HotKey設定"})

        Finally

            '解除螢幕鎖定
            Unlock(Me)

        End Try

    End Sub

#End Region

#End Region

#End Region

#Region "     按鈕向上 "
    ''' <summary>
    '''按鈕向上
    ''' </summary>
    Private Sub btn_up_Click(sender As Object, e As EventArgs) Handles btn_up.Click

        Dim tmpID As String = ""
        Dim tmpName As String = ""

        If dgv_show.CurrentRow.Index <> 0 Then
            If dgv_show.GetGridDS.Tables(0).Rows.Count > 0 Then
                tmpID = dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index).Item("medical_type_id").ToString.Trim
                tmpName = dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index).Item("medical_type_name").ToString.Trim

                dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index).Item("medical_type_id") = dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index - 1).Item("medical_type_id").ToString.Trim
                dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index).Item("medical_type_name") = dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index - 1).Item("medical_type_name").ToString.Trim

                dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index - 1).Item("medical_type_id") = tmpID
                dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index - 1).Item("medical_type_name") = tmpName

                dgv_show.CurrentCell = dgv_show.Rows(dgv_show.CurrentRow.Index - 1).Cells(0)
            End If
        End If
    End Sub
#End Region

#Region "     按鈕向下 "
    ''' <summary>
    '''按鈕向下
    ''' </summary>
    Private Sub btn_down_Click(sender As Object, e As EventArgs) Handles btn_down.Click

        Dim tmpID As String = ""
        Dim tmpName As String = ""

        If dgv_show.CurrentRow.Index <> dgv_show.Rows.Count - 1 Then
            If dgv_show.GetGridDS.Tables(0).Rows.Count > 0 Then
                tmpID = dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index).Item("medical_type_id").ToString.Trim
                tmpName = dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index).Item("medical_type_name").ToString.Trim

                dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index).Item("medical_type_id") = dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index + 1).Item("medical_type_id").ToString.Trim
                dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index).Item("medical_type_name") = dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index + 1).Item("medical_type_name").ToString.Trim

                dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index + 1).Item("medical_type_id") = tmpID
                dgv_show.GetGridDS.Tables(0).Rows(dgv_show.CurrentRow.Index + 1).Item("medical_type_name") = tmpName

                dgv_show.CurrentCell = dgv_show.Rows(dgv_show.CurrentRow.Index + 1).Cells(0)
            End If
        End If   
    End Sub
#End Region

End Class

