'/*
'*****************************************************************************
'*
'*    Page/Class Name:  特殊屬性輸入元件
'*              Title:	PUBLabIndication08
'*        Description:	醫師開單時，系統依檢驗單、檢體及醫令等符合條件進行額外資訊輸入。
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Alan
'*        Create Date:	2016-10-06
'*      Last Modifier:	Alan
'*   Last Modify Date:	2016-10-06
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


Public Class PUBLabIndication08
    Inherits BaseFormUI

#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

    '提供其他UI讀取XML檔案
    Public gblXmlData As String = ""
    Public gblArrayData(2) As String

#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim PUB As IPubServiceManager

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBLabIndication08
    Public Shared Function GetInstance() As PUBLabIndication08
        If myInstance Is Nothing Then
            myInstance = New PUBLabIndication08
        End If
        Return myInstance
    End Function

#End Region

#End Region

#Region "     屬性設定 "



#End Region

#Region "     主要功能 "

#Region "     儲存 "

    ''' <summary>
    ''' 儲存
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Robert.Huang on 2016-04-20</remarks>
    Private Function SaveData() As Boolean

        Dim dsResult As New DataSet

        Try

            Dim returnBoolean As Boolean = True
            Dim dsReturn As DataSet = Nothing


            '檢核RBT按鈕是否選取
            Dim errorCode As Boolean = ChkselectRbtRatio()

            If errorCode Then
                returnBoolean = False
                MessageHandling.ShowWarnMsg("請輸入[組織由來]、[臨床診斷敘述]、[病歷摘要]及[手術方式]！")
                Return returnBoolean
            End If

            '檢核通過開始抓值
            'dsReturn = getCheckDataByDataSet()
            'gblXmlData = XMLUtil.DataSetToXML(dsReturn)

            gblArrayData = getCheckDataByArray()


            Return returnBoolean

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB915", ex)
        End Try

    End Function

#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Brian on 2016-07-15</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '將傳入XML字傳值顯示畫面上對應欄位
            If gblXmlData <> "" Then
                Dim pvtData As New DataSet
                pvtData = XMLUtil.XmlToDataSet(gblXmlData)

                If pvtData.Tables("組織由來").Rows(0).Item("組織由來內容").ToString.Trim <> "" Then
                    txt_Bilolgy_Orign.Text = pvtData.Tables("組織由來").Rows(0).Item("組織由來內容").ToString.Trim
                End If

                If pvtData.Tables("臨床診斷敘述").Rows(0).Item("臨床診斷敘述內容").ToString.Trim <> "" Then
                    txt_Diagnosis.Text = pvtData.Tables("臨床診斷敘述").Rows(0).Item("臨床診斷敘述內容").ToString.Trim
                End If

                If pvtData.Tables("病歷摘要").Rows(0).Item("病歷摘要內容").ToString.Trim <> "" Then
                    txt_Chart_Summary.Text = pvtData.Tables("病歷摘要").Rows(0).Item("病歷摘要內容").ToString.Trim
                End If

                If pvtData.Tables("手術方式").Rows(0).Item("手術方式內容").ToString.Trim <> "" Then
                    txt_Surgical.Text = pvtData.Tables("手術方式").Rows(0).Item("手術方式內容").ToString.Trim
                End If

            End If

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
    ''' <remarks>by Brian on 2016-07-15</remarks>
    Private Sub LoadServiceManager()

        Try

            PUB = PUBServiceManager.getInstance()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB991", ex)
        End Try


    End Sub

#End Region

#End Region

#Region "     事件集合 "

    Private Function ChkselectRbtRatio() As Boolean

        If nvl(txt_Bilolgy_Orign.Text) = "" Then
            Return True
        End If

        If nvl(txt_Diagnosis.Text) = "" Then
            Return True
        End If

        If nvl(txt_Chart_Summary.Text) = "" Then
            Return True
        End If

        If nvl(txt_Surgical.Text) = "" Then
            Return True
        End If

    End Function

#End Region

#Region "     取得勾選的Dataset資料 "

    Private Function getCheckDataByDataSet() As DataSet

        Dim dsCheckData As New DataSet
        'Dataset:建第1個table
        dsCheckData.Tables.Add()
        dsCheckData.Tables(0).TableName = "特殊屬性表單"
        dsCheckData.Tables(0).Columns.Add("特殊屬性表單代碼")
        dsCheckData.Tables(0).Columns.Add("特殊屬性表單名稱")
        '存值入各欄位
        Dim rowDt1 As DataRow = dsCheckData.Tables(0).NewRow
        rowDt1.Item("特殊屬性表單代碼") = "PUBLabIndication08"
        rowDt1.Item("特殊屬性表單名稱") = "病理切片申請單"
        dsCheckData.Tables(0).Rows.Add(rowDt1)
        '--------------------------------------------------------------------------------
        'Dataset:建第2個table
        dsCheckData.Tables.Add()
        dsCheckData.Tables(1).TableName = "組織由來"
        dsCheckData.Tables(1).Columns.Add("組織由來內容")

        '存值入各欄位
        Dim rowDt2 As DataRow = dsCheckData.Tables(1).NewRow
        rowDt2.Item("組織由來內容") = nvl(txt_Bilolgy_Orign.Text)
        dsCheckData.Tables(1).Rows.Add(rowDt2)

        '--------------------------------------------------------------------------------
        'Dataset:建第3個table
        dsCheckData.Tables.Add()
        dsCheckData.Tables(2).TableName = "臨床診斷敘述"
        dsCheckData.Tables(2).Columns.Add("臨床診斷敘述內容")

        '存值入各欄位
        Dim rowDt3 As DataRow = dsCheckData.Tables(2).NewRow
        rowDt3.Item("臨床診斷敘述內容") = nvl(txt_Diagnosis.Text)
        dsCheckData.Tables(2).Rows.Add(rowDt3)

        '--------------------------------------------------------------------------------
        'Dataset:建第4個table
        dsCheckData.Tables.Add()
        dsCheckData.Tables(3).TableName = "病歷摘要"
        dsCheckData.Tables(3).Columns.Add("病歷摘要內容")

        '存值入各欄位
        Dim rowDt4 As DataRow = dsCheckData.Tables(3).NewRow
        rowDt4.Item("病歷摘要內容") = nvl(txt_Chart_Summary.Text)
        dsCheckData.Tables(3).Rows.Add(rowDt4)

        '--------------------------------------------------------------------------------
        'Dataset:建第5個table
        dsCheckData.Tables.Add()
        dsCheckData.Tables(4).TableName = "手術方式"
        dsCheckData.Tables(4).Columns.Add("手術方式內容")

        '存值入各欄位
        Dim rowDt5 As DataRow = dsCheckData.Tables(4).NewRow
        rowDt5.Item("手術方式內容") = nvl(txt_Surgical.Text)
        dsCheckData.Tables(4).Rows.Add(rowDt5)

        '--------------------------------------------------------------------------------
        dsCheckData.Tables.Add()
        dsCheckData.Tables(5).TableName = "Indication"
        dsCheckData.Tables(5).Columns.Add("Indication_Type")
        dsCheckData.Tables(5).Columns.Add("Bilolgy_Orign")
        dsCheckData.Tables(5).Columns.Add("Diagnosis_Memo")
        dsCheckData.Tables(5).Columns.Add("Chart_Summary")
        dsCheckData.Tables(5).Columns.Add("Surgical")

        '存值入各欄位
        Dim rowDt6 As DataRow = dsCheckData.Tables(5).NewRow
        rowDt6.Item("Indication_Type") = "1" '1:By檢驗單 2:By Order
        rowDt6.Item("Bilolgy_Orign") = nvl(txt_Bilolgy_Orign.Text)
        rowDt6.Item("Diagnosis_Memo") = nvl(txt_Diagnosis.Text)
        rowDt6.Item("Chart_Summary") = nvl(txt_Chart_Summary.Text)
        rowDt6.Item("Surgical") = nvl(txt_Surgical.Text)
        dsCheckData.Tables(5).Rows.Add(rowDt6)

        Return dsCheckData

    End Function

    Private Function getCheckDataByArray() As String()

        Dim pvtResult(2) As String

        pvtResult(0) = "1"  '1:By檢驗單 2:By Order

        pvtResult(1) = "組織由來：" & nvl(txt_Bilolgy_Orign.Text.Trim & vbCrLf & vbCrLf)
        pvtResult(1) &= "臨床診斷敘述：" & nvl(txt_Diagnosis.Text & vbCrLf & vbCrLf)
        pvtResult(1) &= "病歷摘要：" & nvl(txt_Chart_Summary.Text & vbCrLf & vbCrLf)
        pvtResult(1) &= "手術方式：" & nvl(txt_Surgical.Text & vbCrLf & vbCrLf)

        Return pvtResult

    End Function

#End Region

#Region "     清除功能 "



#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     儲存 鎖定功能 "

    ''' <summary>
    ''' 儲存
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Robert.Huang on 2016-04-20</remarks>
    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (SaveData()) Then

                '左下方顯示 儲存 成功
                ShowInfoMsg("CMMCMMB301", "儲存")

                Me.Close()

            End If

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"儲存 鎖定功能"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub

#End Region

#Region "     HotKey設定 "

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>by Robert.Huang on 2016-04-20</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode

                Case Keys.F12

                    '如果按下Shift，則為刪除
                    If e.Shift = False Then
                        ''刪除
                        'If (btn_Delete.Enabled) Then
                        '    btn_Delete.PerformClick()
                        'End If
                        '如果未按下Shift，則為新增/儲存
                        'Else

                        '儲存
                        If (btn_Save.Enabled) Then
                            btn_Save.PerformClick()
                        End If
                    End If
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

#End Region


End Class

