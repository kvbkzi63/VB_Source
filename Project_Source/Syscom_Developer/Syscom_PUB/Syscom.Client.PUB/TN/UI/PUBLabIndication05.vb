﻿'/*
'*****************************************************************************
'*
'*    Page/Class Name:  特殊屬性輸入元件
'*              Title:	PUBLabIndication05
'*        Description:	醫師開單時，系統依檢驗單、檢體及醫令等符合條件進行額外資訊輸入。
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Brian
'*        Create Date:	2016-07-15
'*      Last Modifier:	Brian
'*   Last Modify Date:	2016-07-15
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


Public Class PUBLabIndication05
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

    Private Shared myInstance As PUBLabIndication05
    Public Shared Function GetInstance() As PUBLabIndication05
        If myInstance Is Nothing Then
            myInstance = New PUBLabIndication05
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
                MessageHandling.ShowWarnMsg("請選擇類別！")
                returnBoolean = False
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

            rbt_1.Checked = False

            '將傳入XML字傳值顯示畫面上對應欄位
            If gblXmlData <> "" Then
                Dim pvtData As New DataSet
                pvtData = XMLUtil.XmlToDataSet(gblXmlData)

                If pvtData.Tables("產檢類別").Rows(0).Item("產檢").ToString.Trim = "Y" Then
                    rbt_1.Checked = True
                    rbt_2.Checked = False
                End If

                If pvtData.Tables("產檢類別").Rows(0).Item("一般").ToString.Trim = "Y" Then
                    rbt_1.Checked = False
                    rbt_2.Checked = True
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

            PUB = PubServiceManager.getInstance()

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

        If rbt_1.Checked OrElse rbt_2.Checked Then
            Return False
        Else
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
        rowDt1.Item("特殊屬性表單代碼") = "PUBLabIndication05"
        rowDt1.Item("特殊屬性表單名稱") = "細菌檢驗申請單-Vaginal discharge & 130071"
        dsCheckData.Tables(0).Rows.Add(rowDt1)
        '--------------------------------------------------------------------------------
        'Dataset:建第2個table
        dsCheckData.Tables.Add()
        dsCheckData.Tables(1).TableName = "產檢類別"
        dsCheckData.Tables(1).Columns.Add("產檢")
        dsCheckData.Tables(1).Columns.Add("一般")
        '存值入各欄位
        Dim rowDt2 As DataRow = dsCheckData.Tables(1).NewRow
        If rbt_1.Checked Then
            rowDt2.Item("產檢") = "Y"
            rowDt2.Item("一般") = "N"
        ElseIf rbt_2.Checked Then
            rowDt2.Item("產檢") = "N"
            rowDt2.Item("一般") = "Y"
        End If
        dsCheckData.Tables(1).Rows.Add(rowDt2)
        '--------------------------------------------------------------------------------
        'Dataset:建第3個table
        dsCheckData.Tables.Add()
        dsCheckData.Tables(2).TableName = "Indication"
        dsCheckData.Tables(2).Columns.Add("Indication_Type")
        dsCheckData.Tables(2).Columns.Add("CheckType")
        '存值入各欄位
        Dim rowDt3 As DataRow = dsCheckData.Tables(2).NewRow

        rowDt3.Item("Indication_Type") = "2" '1:By檢驗單 2:By Order

        If rbt_1.Checked Then
            rowDt3.Item("CheckType") = "產檢"

        ElseIf rbt_2.Checked Then
            rowDt3.Item("CheckType") = "一般"

        End If
        dsCheckData.Tables(2).Rows.Add(rowDt3)

        Return dsCheckData

    End Function

    Private Function getCheckDataByArray() As String()

        Dim pvtResult(2) As String

        pvtResult(0) = "2"  '1:By檢驗單 2:By Order

        If rbt_1.Checked Then
            pvtResult(1) = "Aerobic culture--產檢類別：產檢"

        ElseIf rbt_2.Checked Then
            pvtResult(1) = "Aerobic culture--產檢類別：一般"

        End If

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

