﻿'/*
'*****************************************************************************
'*
'*    Page/Class Name:  醫事機構維護
'*              Title:	PubHospitalUI
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Alan.Tsai
'*        Create Date:	2014-11-09
'*      Last Modifier:	Alan.Tsai
'*   Last Modify Date:	2014-11-09
'*
'*****************************************************************************
'*/

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.TableFactory
Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.ServiceModel
Imports System.Configuration

Public Class PubHospitalUI
    Inherits Syscom.Client.UCL.BaseFormUI

#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

    '取得維護表格名稱
    Dim DBName As String = PubHospitalDataTableFactory.tableName

    'Grid使用的標題--"Status"與"ErrMsg","Check_Index"為新增隱藏字段
    Dim columnNameGrid() As String = {"類別", "醫院代碼", "生效日期", "結束日期", "醫院名稱", _
                                      "醫院簡稱", "電話", "傳真", "電腦語音專線", "郵遞區號", _
                                      "聯絡地址", "負責人姓名", "負責人Email", "醫療院所層級", "網址", _
                                      "醫院統編", "醫院開業執照", "醫院名稱(收據用)", "建立者", "建立時間", "修改者", _
                                      "修改時間", "Org_Effect_Date", "Org_End_Date", "Status", "ErrMsg", "Check_Index"}  'Add BY Elly 2016/10/19  醫院名稱(收據用)

    '設定Grid欄位寬度
    Dim columnWidth As String = "80,150,100,100,200," & _
                                "150,100,100,150,100," & _
                                "300,180,150,150,150," & _
                                "300,150,150,80,160,80,160"

    '設定Grid顯示欄位
    Dim columnVisible As String = "0,1,2,3,4,5,6,7,8,9,10," & _
                                  "11,12,13,14,15,16,17,18,19,20,21,22"

    '設定可編輯的欄位位置索引
    Dim columnEditIndex() As String = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", _
                                       "11", "12", "13", "14", "15", "16", "17", "18"}

    '設定必填欄位位置索引
    Dim columnNotNullIndex() As String = {"1", "2", "3", "4", "5", "14"}

    '設定PKey欄位位置索引
    Dim columnPKeyIndex() As String = {"1", "2"}

    '設定建立時間與修改時間的欄位索引
    Dim gblCreateTimeIdx As Integer = 18
    Dim gblModifiedTimeIdx As Integer = 20
    Dim gblOrgEffectTimeIdx As Integer = 21
    Dim gblOrgEndTimeIdx As Integer = 22

    '取得維護表字段名
    Dim columnNameDB() As String = PubHospitalDataTableFactory.columnsName

    '取得維護表字段長度
    Dim columnsLength() As Integer = PubHospitalDataTableFactory.columnsLength

    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        ComboBox
        TextBox

        DataRow

        Footer

        Separator

        Header

        Pager

    End Enum

    Dim gblErrMsg As String = ""
    Dim gblErrMsg2 As String = ""
    Dim gblIndex As Integer = -1
    Dim gblSysCodeType As New DataSet


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



#End Region

#Region "     主要功能 "

#Region "     按鈕事件 "

#Region "     複製 "
    ''' <summary>
    ''' 複製
    ''' </summary>
    ''' <remarks>by Alan.Tsai on 2014-12-03</remarks>
    Private Sub btn_Copy_Click(sender As Object, e As EventArgs) Handles btn_Copy.Click
        '取得點選記錄
        If gblIndex <> -1 Then

            '取的空白列位置
            Dim pvtRowIndex As Integer = dgv_Data.Rows.Count - 1

            '複製欄位資料
            dgv_Data.Rows(pvtRowIndex).Cells(0).Value = True
            For i = 1 To columnEditIndex.Length
                Select Case i
                    Case 1, 2, 10, 14
                        dgv_Data.Rows(pvtRowIndex).Cells(i).Value = dgv_Data.GetDBDS.Tables(0).Rows(gblIndex).Item(i - 1).ToString.Trim
                        dgv_Data.GetDBDS.Tables(0).Rows(pvtRowIndex).Item(i - 1) = dgv_Data.GetDBDS.Tables(0).Rows(gblIndex).Item(i - 1).ToString.Trim
                        dgv_Data.GetGridDS.Tables(0).Rows(pvtRowIndex).Item(i - 1) = dgv_Data.GetDBDS.Tables(0).Rows(gblIndex).Item(i - 1).ToString.Trim

                    Case 3
                        Dim pvtDate As String = DateAdd(DateInterval.Year, 1911, CDate(dgv_Data.Rows(gblIndex).Cells(i).Value)).ToString("yyyy/MM/dd")
                        dgv_Data.Rows(pvtRowIndex).Cells("生效日期").Value = pvtDate
                        dgv_Data.GetGridDS.Tables(0).Rows(pvtRowIndex).Item("生效日期") = pvtDate
                        dgv_Data.GetDBDS.Tables(0).Rows(pvtRowIndex).Item("生效日期") = pvtDate
                    Case 4
                        Dim pvtDate As String = DateAdd(DateInterval.Year, 1911, CDate(dgv_Data.Rows(gblIndex).Cells(i).Value)).ToString("yyyy/MM/dd")
                        dgv_Data.Rows(pvtRowIndex).Cells("結束日期").Value = pvtDate
                        dgv_Data.GetGridDS.Tables(0).Rows(pvtRowIndex).Item("結束日期") = pvtDate
                        dgv_Data.GetDBDS.Tables(0).Rows(pvtRowIndex).Item("結束日期") = pvtDate

                    Case Else
                        dgv_Data.Rows(pvtRowIndex).Cells(i).Value = dgv_Data.Rows(gblIndex).Cells(i).Value
                End Select

            Next

        Else
            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請點選要複製的資料!"})
        End If

    End Sub

#End Region

#Region "     儲存 "

    ''' <summary>
    ''' 儲存
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Private Function SaveData() As Boolean

        Dim dsResult As New DataSet

        Try

            Dim returnBoolean As Boolean = True

            '欄位檢核
            If checkFieldIsNull() AndAlso checkIsDateOverlap() Then

                '取得存檔資料
                Dim dsSave As New DataSet
                dsSave = getCheckData()

                '執行存檔
                If dsSave IsNot Nothing AndAlso dsSave.Tables IsNot Nothing AndAlso dsSave.Tables(0).Rows.Count > 0 Then
                    dsResult = Pub.savePUBHospital(dsSave)

                    If dsResult IsNot Nothing AndAlso dsResult.Tables IsNot Nothing AndAlso dsResult.Tables(0).Rows.Count > 0 Then
                        '若失敗則將畫面上資料顏色、訊息做設定
                        setErrorData(dsResult)
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"存檔失敗，請確認!"})
                        returnBoolean = False
                    Else
                        '若成功則將畫面資料顏色、訊息與[選]恢復一般模式，且Status皆須更改為U
                        Dim pvtCheckIdx As Integer

                        For j = 0 To dsSave.Tables(0).Rows.Count - 1
                            pvtCheckIdx = CInt(dsSave.Tables(0).Rows(j).Item("Check_Index"))

                            '將原始生效與結束日期蓋回，以便能夠正確檢核日期區間
                            dgv_Data.SetCellReadOnly(gblOrgEffectTimeIdx, pvtCheckIdx, False)
                            Dim pvtEffectDate As String = DateAdd(DateInterval.Year, 1911, CDate(dgv_Data.Rows(pvtCheckIdx).Cells("生效日期").Value)).ToString("yyyy/MM/dd")
                            dgv_Data.Rows(pvtCheckIdx).Cells("Org_Effect_Date").Value = pvtEffectDate
                            dgv_Data.GetGridDS.Tables(0).Rows(pvtCheckIdx).Item("Org_Effect_Date") = pvtEffectDate
                            dgv_Data.GetDBDS.Tables(0).Rows(pvtCheckIdx).Item("Org_Effect_Date") = pvtEffectDate
                            dgv_Data.SetCellReadOnly(gblOrgEffectTimeIdx, pvtCheckIdx, True)

                            dgv_Data.SetCellReadOnly(gblOrgEndTimeIdx, pvtCheckIdx, False)
                            Dim pvtEndDate As String = DateAdd(DateInterval.Year, 1911, CDate(dgv_Data.Rows(pvtCheckIdx).Cells("結束日期").Value)).ToString("yyyy/MM/dd")
                            dgv_Data.Rows(pvtCheckIdx).Cells("Org_End_Date").Value = pvtEndDate
                            dgv_Data.GetGridDS.Tables(0).Rows(pvtCheckIdx).Item("Org_End_Date") = pvtEndDate
                            dgv_Data.GetDBDS.Tables(0).Rows(pvtCheckIdx).Item("Org_End_Date") = pvtEndDate
                            dgv_Data.SetCellReadOnly(gblOrgEndTimeIdx, pvtCheckIdx, True)


                            Me.dgv_Data.Rows(pvtCheckIdx).Cells(0).Value = False
                            Me.dgv_Data.SetRowColor(pvtCheckIdx, Color.White)

                            For k = 0 To columnEditIndex.Length - 1
                                Me.dgv_Data.SetCellColor(CInt(columnEditIndex(k)), pvtCheckIdx, Color.White)
                                Me.dgv_Data.Rows(pvtCheckIdx).Cells(k).ToolTipText = ""
                            Next

                            If dgv_Data.Rows(pvtCheckIdx).Cells("Status").Value.ToString.Trim = "I" Then
                                Me.dgv_Data.GetDBDS.Tables(0).Rows(pvtCheckIdx).Item("Status") = "U"
                                Me.dgv_Data.GetGridDS.Tables(0).Rows(pvtCheckIdx).Item("Status") = "U"
                                '顯示建立者與建立時間
                                dgv_Data.Rows(pvtCheckIdx).Cells("建立者").Value = CurrentUserID

                                If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then

                                    dgv_Data.SetCellReadOnly(gblCreateTimeIdx, pvtCheckIdx, False)

                                    Dim pvtDate As String = DateAdd(DateInterval.Year, -1911, CDate(dsResult.Tables(1).Rows(0).Item("Server_Time"))).ToString("yyyy/MM/dd HH:mm:ss")
                                    Dim pvtTWDate As String = CInt(pvtDate.Substring(0, 4)) & "/" & pvtDate.Substring(5)

                                    dgv_Data.Rows(pvtCheckIdx).Cells("建立時間").Value = pvtTWDate
                                    dgv_Data.GetDBDS.Tables(0).Rows(pvtCheckIdx).Item("建立時間") = pvtTWDate
                                    dgv_Data.GetGridDS.Tables(0).Rows(pvtCheckIdx).Item("建立時間") = pvtTWDate
                                    dgv_Data.SetCellReadOnly(gblCreateTimeIdx, pvtCheckIdx, True)
                                Else
                                    dgv_Data.SetCellReadOnly(gblCreateTimeIdx, pvtCheckIdx, False)
                                    Dim pvtDate As String = dsResult.Tables(1).Rows(0).Item("Server_Time")
                                    dgv_Data.Rows(pvtCheckIdx).Cells("建立時間").Value = pvtDate
                                    dgv_Data.GetDBDS.Tables(0).Rows(pvtCheckIdx).Item("建立時間") = pvtDate
                                    dgv_Data.GetGridDS.Tables(0).Rows(pvtCheckIdx).Item("建立時間") = pvtDate
                                    dgv_Data.SetCellReadOnly(gblCreateTimeIdx, pvtCheckIdx, True)
                                End If

                            End If

                            '更新修改者與修改時間
                            dgv_Data.Rows(pvtCheckIdx).Cells("修改者").Value = CurrentUserID

                            If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then

                                dgv_Data.SetCellReadOnly(gblModifiedTimeIdx, pvtCheckIdx, False)

                                Dim pvtDate As String = DateAdd(DateInterval.Year, -1911, CDate(dsResult.Tables(1).Rows(0).Item("Server_Time"))).ToString("yyyy/MM/dd HH:mm:ss")
                                Dim pvtTWDate As String = CInt(pvtDate.Substring(0, 4)) & "/" & pvtDate.Substring(5)

                                dgv_Data.Rows(pvtCheckIdx).Cells("修改時間").Value = pvtTWDate
                                dgv_Data.GetDBDS.Tables(0).Rows(pvtCheckIdx).Item("修改時間") = pvtTWDate
                                dgv_Data.GetGridDS.Tables(0).Rows(pvtCheckIdx).Item("修改時間") = pvtTWDate

                                dgv_Data.SetCellReadOnly(gblModifiedTimeIdx, pvtCheckIdx, True)
                            Else
                                dgv_Data.SetCellReadOnly(gblModifiedTimeIdx, pvtCheckIdx, False)
                                Dim pvtDate As String = dsResult.Tables(1).Rows(0).Item("Server_Time")
                                dgv_Data.Rows(pvtCheckIdx).Cells("修改時間").Value = pvtDate
                                dgv_Data.GetDBDS.Tables(0).Rows(pvtCheckIdx).Item("修改時間") = pvtDate
                                dgv_Data.GetGridDS.Tables(0).Rows(pvtCheckIdx).Item("修改時間") = pvtDate
                                dgv_Data.SetCellReadOnly(gblModifiedTimeIdx, pvtCheckIdx, True)
                            End If

                            Me.dgv_Data.Rows(pvtCheckIdx).Cells("ErrMsg").Value = ""
                        Next

                    End If

                Else
                    MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請勾選要存檔的資料!"})
                    returnBoolean = False
                End If

            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {gblErrMsg & vbCrLf & gblErrMsg2})
                returnBoolean = False
            End If

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

#Region "     刪除 "

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Private Function DeleteData() As Boolean

        Try

            Dim dsResult As New DataSet
            Dim returnBoolean As Boolean = True


            '取得刪除資料
            Dim dsDelete As New DataSet
            dsDelete = getCheckData()

            If dsDelete IsNot Nothing AndAlso dsDelete.Tables IsNot Nothing AndAlso dsDelete.Tables(0).Rows.Count > 0 Then

                If (MessageHandling.ShowQuestionMsg("CMMCMMB932", New String() {}) = Windows.Forms.DialogResult.Yes) Then

                    '執行刪除
                    dsResult = Pub.deletePUBHospital(dsDelete)

                    If dsResult IsNot Nothing AndAlso dsResult.Tables IsNot Nothing AndAlso dsResult.Tables(0).Rows.Count > 0 Then
                        '若失敗則將畫面上資料顏色、訊息做設定
                        setErrorData(dsResult)
                        returnBoolean = False
                    Else
                        '若成功則將畫面資料移除
                        Dim pvtCheckIdx As Integer

                        For j = 0 To dsDelete.Tables(0).Rows.Count - 1
                            pvtCheckIdx = CInt(dsDelete.Tables(0).Rows(j).Item("Check_Index"))
                            '必需連GetDBDB的資料一併刪除
                            dgv_Data.GetDBDS.Tables(0).Rows.RemoveAt(pvtCheckIdx - j)
                            dgv_Data.GetGridDS.Tables(0).Rows.RemoveAt(pvtCheckIdx - j)
                        Next
                    End If
                End If

            Else
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請勾選要刪除的資料!"})
                returnBoolean = False
            End If

            Return returnBoolean

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
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Private Function QueryData() As Boolean

        Try

            Dim returnBoolean As Boolean = False

            Dim dsDB As DataSet

            If cbo_Language_Type_Id.SelectedValue = "" AndAlso txt_Hospital_Code.Text.Trim = "" Then
                dsDB = Pub.qureyPUBHospitalAll

            Else
                dsDB = Pub.queryPUBHospitalLikePKey(cbo_Language_Type_Id.SelectedValue, "", txt_Hospital_Code.Text.Trim)

            End If

            ShowDgv(dsDB)

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
    ''' <returns >Boolean</returns>
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Private Function ClearData() As Boolean

        Try

            Dim returnBoolean As Boolean = True

            '將畫面資料顏色、訊息與[選]恢復一般模式
            For i = 0 To dgv_Data.Rows.Count - 2

                If Me.dgv_Data.Rows(i).Cells(0).Value Then

                    Me.dgv_Data.Rows(i).Cells(0).Value = False
                    Me.dgv_Data.SetRowColor(i, Color.White)

                    For j = 0 To columnEditIndex.Length - 1
                        Me.dgv_Data.SetCellColor(j, i, Color.White)
                        Me.dgv_Data.Rows(i).Cells(j).ToolTipText = ""
                    Next

                    Me.dgv_Data.Rows(i).Cells("ErrMsg").Value = ""

                End If

            Next

            cbo_Language_Type_Id.SelectedValue = ""
            txt_Hospital_Code.Text = ""

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

#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()

            '取得畫面初始化資料
            gblSysCodeType = Pub.initPubHospital

            '設定類別ComboBox資料
            cbo_Language_Type_Id.DataSource = gblSysCodeType.Tables(0).Copy
            cbo_Language_Type_Id.uclDisplayIndex = "0,1"
            cbo_Language_Type_Id.uclValueIndex = "0"

            '自動依解析度調整畫面元件大小
            'If UCLFormUtil.isResizeable Then
            '    Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
            '    UCLFormUtil.ReDrawForm(Me)
            'End If

            '初始化 - DataGridView
            ShowDgv(New DataSet)

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
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
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
    ''' <remarks>by Alan.Tsai on 2014-11-4</remarks>
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
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
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

#Region "     初始化 - DataGridView "

    ''' <summary>
    ''' 初始化 - DataGridView
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-2-23</remarks>
    Private Sub ShowDgv(ByVal inDsData As DataSet)

        Try

            '構建空的Grid
            Dim htGrid As New Hashtable()
            Dim dsData As New DataSet

            Dim cbo_cell1 As New ComboBoxCell()
            Dim dsCboCell1 As New DataSet
            If gblSysCodeType IsNot Nothing AndAlso gblSysCodeType.Tables IsNot Nothing Then
                dsCboCell1.Tables.Add(gblSysCodeType.Tables(0).Copy)
                cbo_cell1.Ds = dsCboCell1
                cbo_cell1.DisplayIndex = "0,1"
                cbo_cell1.ValueIndex = "0"
            End If

            Dim txt_cell2 As New TextBoxCell()
            txt_cell2.MaxLength = 10

            Dim date_cell3 As New DtpCell()

            Dim date_cell4 As New DtpCell()

            Dim txt_cell5 As New TextBoxCell()
            txt_cell5.MaxLength = 50

            Dim txt_cell6 As New TextBoxCell()
            txt_cell6.MaxLength = 20

            Dim txt_cell7 As New TextBoxCell()
            txt_cell7.MaxLength = 20

            Dim txt_cell8 As New TextBoxCell()
            txt_cell8.MaxLength = 20

            Dim txt_cell9 As New TextBoxCell()
            txt_cell9.MaxLength = 20

            Dim cbo_cell10 As New ComboBoxCell()
            Dim dsCboCell10 As New DataSet
            If gblSysCodeType IsNot Nothing AndAlso gblSysCodeType.Tables IsNot Nothing Then
                dsCboCell10.Tables.Add(gblSysCodeType.Tables(1).Copy)
                cbo_cell10.Ds = dsCboCell10
                cbo_cell10.DisplayIndex = "0,1"
                cbo_cell10.ValueIndex = "0"
            End If

            Dim txt_cell11 As New TextBoxCell()
            txt_cell11.MaxLength = 100

            Dim txt_cell12 As New TextBoxCell()
            txt_cell12.MaxLength = 20

            Dim txt_cell13 As New TextBoxCell()
            txt_cell13.MaxLength = 100

            Dim cbo_cell14 As New ComboBoxCell()
            Dim dsCboCell14 As New DataSet
            If gblSysCodeType IsNot Nothing AndAlso gblSysCodeType.Tables IsNot Nothing Then
                dsCboCell14.Tables.Add(gblSysCodeType.Tables(2).Copy)
                cbo_cell14.Ds = dsCboCell14
                cbo_cell14.DisplayIndex = "0,1"
                cbo_cell14.ValueIndex = "0"
            End If

            Dim txt_cell15 As New TextBoxCell()
            txt_cell15.MaxLength = 100

            Dim txt_cell16 As New TextBoxCell()
            txt_cell16.MaxLength = 8

            Dim txt_cell17 As New TextBoxCell()
            txt_cell17.MaxLength = 10

            Dim txt_cell18 As New TextBoxCell()

            Dim txt_cell19 As New TextBoxCell()
            txt_cell19.MaxLength = 10

            Dim txt_cell20 As New TextBoxCell()


            htGrid.Add(1, cbo_cell1)
            htGrid.Add(2, txt_cell2)
            htGrid.Add(3, date_cell3)
            htGrid.Add(4, date_cell4)
            htGrid.Add(5, txt_cell5)
            htGrid.Add(6, txt_cell6)
            htGrid.Add(7, txt_cell7)
            htGrid.Add(8, txt_cell8)
            htGrid.Add(9, txt_cell9)
            htGrid.Add(10, cbo_cell10)
            htGrid.Add(11, txt_cell11)
            htGrid.Add(12, txt_cell12)
            htGrid.Add(13, txt_cell13)
            htGrid.Add(14, cbo_cell14)
            htGrid.Add(15, txt_cell15)
            htGrid.Add(16, txt_cell16)
            htGrid.Add(17, txt_cell17)
            htGrid.Add(18, txt_cell18)
            htGrid.Add(19, txt_cell19)
            htGrid.Add(20, txt_cell20)

            If inDsData IsNot Nothing AndAlso inDsData.Tables.Count > 0 Then

                ' 修改查詢結果中欄位名稱
                For i = 0 To inDsData.Tables(0).Columns.Count - 1
                    inDsData.Tables(0).Columns(i).ColumnName = columnNameGrid(i)
                Next

                '在查詢結果中加入"Status"與"ErrMsg,"Check_Index"隱藏欄位"
                inDsData.Tables(0).Columns.Add("Status")
                inDsData.Tables(0).Columns.Add("ErrMsg")
                inDsData.Tables(0).Columns.Add("Check_Index")

                If Not inDsData.Tables(0).Columns.Contains("Org_Effect_Date") Then
                    inDsData.Tables(0).Columns.Add("Org_Effect_Date")
                End If

                If Not inDsData.Tables(0).Columns.Contains("Org_End_Date") Then
                    inDsData.Tables(0).Columns.Add("Org_End_Date")
                End If

                For j = 0 To inDsData.Tables(0).Rows.Count - 1
                    inDsData.Tables(0).Rows(j).Item("Status") = "U"
                Next

                dsData = inDsData.Copy

            Else
                dsData = genDS(DataSet_Type.Grid, DBName)
            End If
            dsData.Tables(0).PrimaryKey = Nothing
            htGrid.Add(-1, dsData)
            dgv_Data.Initial(htGrid)

            'Grid內容設定
            setGridData()

        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - DataGridView"})

        End Try

    End Sub

    ''' <summary>
    ''' Grid 綁值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setGridData()

        '設定攔寬
        dgv_Data.uclColumnWidth = columnWidth


        '設定隱藏欄位
        dgv_Data.uclVisibleColIndex = columnVisible

        '新增空白列
        dgv_Data.AddNewRow()

        '設定Status值為I
        dgv_Data.GetDBDS.Tables(0).Rows(dgv_Data.GetDBDS.Tables(0).Rows.Count - 1).Item("Status") = "I"
        dgv_Data.GetGridDS.Tables(0).Rows(dgv_Data.GetDBDS.Tables(0).Rows.Count - 1).Item("Status") = "I"
        dgv_Data.Rows(dgv_Data.Rows.Count - 1).Cells("Status").Value = "I"

        '除了[選]以外，其它欄位設定為不啟用
        For i As Integer = 0 To dgv_Data.Rows.Count - 1
            Me.dgv_Data.SetRowReadOnly(i, True)
            Me.dgv_Data.SetCellReadOnly(0, i, False)
        Next

        '設定固定欄位，不隨著水平捲軸移動
        Me.dgv_Data.Columns(1).Frozen = True

        Me.dgv_Data.Refresh()
    End Sub

#End Region

#Region "     產生一個DataSet並包含一個空的Table 給Grid用 或 DB用 "
    ''' <summary>
    ''' 產生一個DataSet並包含一個空的Table 給Grid用 或 DB用
    ''' </summary>
    ''' <param name="type">資料集類型</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function genDS(ByVal type As Integer, ByVal table As String) As DataSet
        Dim dsTemp As New DataSet

        Select Case type
            Case DataSet_Type.Grid
                '給Grid用Table
                dsTemp.Tables.Add(table)
                For i As Integer = 0 To columnNameGrid.Length - 1
                    dsTemp.Tables(table).Columns.Add(columnNameGrid(i))
                Next
            Case DataSet_Type.DB
                '給DB用Table
                dsTemp.Tables.Add(table)
                For i As Integer = 0 To columnNameDB.Length - 1
                    dsTemp.Tables(table).Columns.Add(columnNameDB(i))
                Next

                '新增Status與ErrMsg,"Check_Index"欄位
                dsTemp.Tables(table).Columns.Add("Status")
                dsTemp.Tables(table).Columns.Add("ErrMsg")
                dsTemp.Tables(table).Columns.Add("Check_Index")

                If Not dsTemp.Tables(table).Columns.Contains("Org_Effect_Date") Then
                    dsTemp.Tables(table).Columns.Add("Org_Effect_Date")
                End If


        End Select
        Return dsTemp
    End Function
#End Region

#End Region

#Region "     必填檢查 "
    ''' <summary>
    ''' 檢查欄位是否為空白
    ''' </summary>
    ''' <remarks></remarks>
    Private Function checkFieldIsNull() As Boolean

        Dim pvtCheckFlag As Boolean = True

        '-------------------------------------------------------------
        '僅需針對[選]有打勾的欄位做檢核
        '-------------------------------------------------------------
        gblErrMsg = ""
        gblErrMsg2 = ""
        For i = 0 To dgv_Data.GetDBDS.Tables(0).Rows.Count - 1

            If dgv_Data.Rows(i).Cells(0).Value Then

                For j = 0 To columnNotNullIndex.Length - 1

                    If dgv_Data.Rows(i).Cells(CInt(columnNotNullIndex(j))).Value.ToString.Trim = "" Then
                        If gblErrMsg <> "" Then
                            gblErrMsg &= "," & columnNameGrid(CInt(columnNotNullIndex(j)) - 1)
                            dgv_Data.SetCellColor(CInt(columnNotNullIndex(j)), i, Color.Pink)
                        Else
                            gblErrMsg = columnNameGrid(CInt(columnNotNullIndex(j)) - 1)
                            dgv_Data.SetCellColor(CInt(columnNotNullIndex(j)), i, Color.Pink)
                        End If

                        pvtCheckFlag = False

                    Else
                        Me.dgv_Data.SetRowColor(i, Color.White)
                        dgv_Data.SetCellColor(CInt(columnNotNullIndex(j)), i, Color.White)
                    End If

                Next

                If dgv_Data.Rows(i).Cells(13).Value.ToString.Trim <> "" AndAlso (Not dgv_Data.Rows(i).Cells(13).Value.ToString.Trim.Contains("@")) Then
                    If gblErrMsg2 <> "" Then
                        gblErrMsg2 &= "," & columnNameGrid(13)
                        dgv_Data.SetCellColor(13, i, Color.Pink)
                    Else
                        gblErrMsg2 = columnNameGrid(12)
                        dgv_Data.SetCellColor(13, i, Color.Pink)
                    End If

                    pvtCheckFlag = False
                End If

                If gblErrMsg <> "" Then
                    gblErrMsg &= "欄位值不可為空白!"
                End If

                If gblErrMsg2 <> "" Then
                    gblErrMsg2 &= "欄位值必須包含@符號!"
                End If

                dgv_Data.Rows(i).Cells("ErrMsg").Value = gblErrMsg & vbCrLf & gblErrMsg2

                For p = 0 To columnNameGrid.Count - 1
                    dgv_Data.Rows(i).Cells(p).ToolTipText = gblErrMsg & vbCrLf & gblErrMsg2
                Next

            End If

        Next
        '-------------------------------------------------------------

        Return pvtCheckFlag
    End Function


#End Region

#Region "    日期起迄重疊檢查 "
    ''' <summary>
    ''' 檢查日期起迄是否重疊
    ''' </summary>
    ''' <remarks></remarks>
    Private Function checkIsDateOverlap() As Boolean

        Dim pvtCheckFlag As Boolean = True

        gblErrMsg = ""

        For t = 0 To dgv_Data.GetDBDS.Tables(0).Rows.Count - 1
            dgv_Data.SetCellColor(3, t, Color.White)
            dgv_Data.SetCellColor(4, t, Color.White)
        Next
        dgv_Data.Refresh()

        '-------------------------------------------------------------
        '1.先判斷起迄是否正確
        '-------------------------------------------------------------
        For i = 0 To dgv_Data.GetDBDS.Tables(0).Rows.Count - 1

            If dgv_Data.Rows(i).Cells(0).Value Then
                If DateDiff(DateInterval.Day, _
                             CDate(dgv_Data.GetDBDS.Tables(0).Rows(i).Item("生效日期").ToString), _
                             CDate(dgv_Data.GetDBDS.Tables(0).Rows(i).Item("結束日期").ToString)) < 0 Then

                    gblErrMsg = "生效日期不可大於結束日期!"
                    dgv_Data.SetCellColor(3, i, Color.Pink)
                    dgv_Data.SetCellColor(4, i, Color.Pink)

                    pvtCheckFlag = False

                    If gblErrMsg <> "" Then

                        dgv_Data.Rows(i).Cells("ErrMsg").Value = gblErrMsg

                        For p = 0 To columnNameGrid.Count - 1
                            dgv_Data.Rows(i).Cells(p).ToolTipText = gblErrMsg
                        Next

                    End If

                End If

            End If
        Next

        If pvtCheckFlag = False Then
            Return pvtCheckFlag
        End If

        '-------------------------------------------------------------

        '-------------------------------------------------------------
        '2.再判斷起迄是否重疊
        '-------------------------------------------------------------
        gblErrMsg = ""
        Dim pvtLanguageType As String
        Dim pvtHospitalCode As String
        Dim pvtStartDate As Date

        For i = 0 To dgv_Data.GetDBDS.Tables(0).Rows.Count - 1

            '須排除新增且未勾選的項目
            If dgv_Data.Rows(i).Cells("Status").Value.ToString = "U" OrElse _
               (dgv_Data.Rows(i).Cells(1).Value.ToString.Trim <> "" AndAlso dgv_Data.Rows(i).Cells("Status").Value.ToString = "I" AndAlso dgv_Data.Rows(i).Cells(0).Value = True) Then

                pvtLanguageType = dgv_Data.GetDBDS.Tables(0).Rows(i).Item("類別").ToString.Trim
                pvtHospitalCode = dgv_Data.GetDBDS.Tables(0).Rows(i).Item("醫院代碼").ToString.Trim
                pvtStartDate = CDate(dgv_Data.GetDBDS.Tables(0).Rows(i).Item("生效日期").ToString.Trim)

                For j = 0 To dgv_Data.GetDBDS.Tables(0).Rows.Count - 1

                    '須排除新增且未勾選的項目
                    If dgv_Data.Rows(j).Cells("Status").Value.ToString = "U" OrElse _
                       (dgv_Data.Rows(j).Cells(1).Value.ToString.Trim <> "" AndAlso dgv_Data.Rows(j).Cells("Status").Value.ToString = "I" AndAlso dgv_Data.Rows(j).Cells(0).Value = True) Then

                        If j <> i Then

                            If pvtLanguageType = dgv_Data.GetDBDS.Tables(0).Rows(j).Item("類別").ToString.Trim AndAlso _
                               pvtHospitalCode = dgv_Data.GetDBDS.Tables(0).Rows(j).Item("醫院代碼").ToString.Trim Then
                                If DateDiff(DateInterval.Day, CDate(dgv_Data.GetDBDS.Tables(0).Rows(j).Item("生效日期").ToString.Trim), pvtStartDate) >= 0 AndAlso _
                                   DateDiff(DateInterval.Day, CDate(dgv_Data.GetDBDS.Tables(0).Rows(j).Item("結束日期").ToString.Trim), pvtStartDate) <= 0 Then
                                    gblErrMsg = "生效起迄日期區間有重疊，請確認!"
                                    dgv_Data.SetCellColor(3, i, Color.Pink)
                                    dgv_Data.SetCellColor(4, i, Color.Pink)

                                    dgv_Data.SetCellColor(3, j, Color.Pink)
                                    dgv_Data.SetCellColor(4, j, Color.Pink)

                                    pvtCheckFlag = False

                                    If gblErrMsg <> "" Then

                                        dgv_Data.Rows(i).Cells("ErrMsg").Value = gblErrMsg

                                        For p = 0 To columnNameGrid.Count - 1
                                            dgv_Data.Rows(i).Cells(p).ToolTipText = gblErrMsg
                                            dgv_Data.Rows(j).Cells(p).ToolTipText = gblErrMsg
                                        Next

                                    End If

                                End If

                            End If

                        End If

                    End If

                Next

            End If

        Next

        '-------------------------------------------------------------

        Return pvtCheckFlag
    End Function


#End Region

#Region "     事件集合 "

#Region "Grid相關處理"

    ''' <summary>
    ''' CellValueChanged 事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv_Data_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Data.CellValueChanged

        Dim pvtRowIndex As Integer = e.RowIndex

        '-------------------------------------------------------------
        '若[選]打勾，才則該列欄位啟用
        '-------------------------------------------------------------
        If e.ColumnIndex = 0 Then
            If dgv_Data.Rows(pvtRowIndex).Cells(0).Value Then
                setField(dgv_Data.GetDBDS.Tables(0).Rows(pvtRowIndex).Item("Status").ToString.Trim, pvtRowIndex, False)
            Else
                setField(dgv_Data.GetDBDS.Tables(0).Rows(pvtRowIndex).Item("Status").ToString.Trim, pvtRowIndex, True)
            End If

        ElseIf e.ColumnIndex = 10 Then
            '-------------------------------------------------------------
            '若選取郵遞區號且住址為空白，則將郵遞區號名稱帶入地址欄位
            '-------------------------------------------------------------
            If dgv_Data.GetDBDS.Tables(0).Rows(pvtRowIndex).Item("聯絡地址").ToString.Trim = "" Then
                Dim pvtCountry As String
                pvtCountry = dgv_Data.GetGridDS.Tables(0).Rows(pvtRowIndex).Item("郵遞區號").ToString.Trim.Substring(5).Trim
                dgv_Data.Rows(pvtRowIndex).Cells("聯絡地址").Value = pvtCountry
                dgv_Data.GetGridDS.Tables(0).Rows(pvtRowIndex).Item("聯絡地址") = pvtCountry
                dgv_Data.GetDBDS.Tables(0).Rows(pvtRowIndex).Item("聯絡地址") = pvtCountry
            End If

        End If
        '-------------------------------------------------------------


        '-------------------------------------------------------------
        '若離開的Cell為最後一列，且第1個Cell有值，則自動新增空白列
        '-------------------------------------------------------------
        If e.ColumnIndex = 1 AndAlso _
           pvtRowIndex = dgv_Data.Rows.Count - 1 AndAlso _
           dgv_Data.Rows(pvtRowIndex).Cells(1).Value.ToString.Trim <> "" Then
            '新增空白列
            dgv_Data.AddNewRow()

            '設定Status值為I
            dgv_Data.Rows(dgv_Data.Rows.Count - 1).Cells("Status").Value = "I"
            dgv_Data.GetDBDS.Tables(0).Rows(dgv_Data.Rows.Count - 1).Item("Status") = "I"
            dgv_Data.GetGridDS.Tables(0).Rows(dgv_Data.Rows.Count - 1).Item("Status") = "I"

            '除了[選]以外，其它欄位設定為不啟用
            Me.dgv_Data.SetRowReadOnly(dgv_Data.GetDBDS.Tables(0).Rows.Count - 1, True)
            Me.dgv_Data.SetCellReadOnly(0, dgv_Data.GetDBDS.Tables(0).Rows.Count - 1, False)

        End If
        '-------------------------------------------------------------

        Me.dgv_Data.Refresh()
    End Sub

    ''' <summary>
    ''' 設定欄位是否啟用編輯，若為修改Status，則PKey不可改
    ''' </summary>
    ''' <param name="inStatus">I:新增,U:修改</param>
    ''' <param name="inRowIndex">勾選位置索引</param>
    ''' <param name="inIsReadOnly">唯讀註記</param>
    ''' <remarks></remarks>
    Private Sub setField(ByVal inStatus As String, ByVal inRowIndex As Integer, ByVal inIsReadOnly As Boolean)

        If inIsReadOnly Then
            '若取消勾選，則所有可編輯欄位皆設為不啟用(顏色與訊息皆恢復正常)
            For i = 0 To columnEditIndex.Length - 1
                Me.dgv_Data.SetCellReadOnly(columnEditIndex(i), inRowIndex, inIsReadOnly)

                Me.dgv_Data.SetRowColor(inRowIndex, Color.White)

                For j = 0 To columnEditIndex.Length - 1
                    Me.dgv_Data.SetCellColor(CInt(columnEditIndex(j)), inRowIndex, Color.White)
                    Me.dgv_Data.Rows(inRowIndex).Cells(j).ToolTipText = ""
                Next

                Me.dgv_Data.Rows(inRowIndex).Cells("ErrMsg").Value = ""
            Next

            '若為狀態="U"，將原始生效與結束日期蓋回，以便能夠正確檢核日期區間
            If dgv_Data.Rows(inRowIndex).Cells("Status").Value = "U" Then

                Dim pvtEffectDate As String = CDate(dgv_Data.GetGridDS.Tables(0).Rows(inRowIndex).Item("Org_Effect_Date")).ToString("yyyy/MM/dd")
                dgv_Data.SetCellDateValue(dgv_Data.Rows(inRowIndex).Cells("生效日期").ColumnIndex, inRowIndex, pvtEffectDate)

                Dim pvtEndDate As String = CDate(dgv_Data.GetGridDS.Tables(0).Rows(inRowIndex).Item("Org_End_Date")).ToString("yyyy/MM/dd")
                dgv_Data.SetCellDateValue(dgv_Data.Rows(inRowIndex).Cells("結束日期").ColumnIndex, inRowIndex, pvtEndDate)

            End If

        Else

            '若[選]打勾，且該筆為新增，則所有可編輯欄位皆設為啟用
            If inStatus = "I" Then
                For i = 0 To columnEditIndex.Length - 1
                    Me.dgv_Data.SetCellReadOnly(CInt(columnEditIndex(i)), inRowIndex, inIsReadOnly)
                Next
            Else

                Dim pvtIsContinue As Boolean

                '若[選]打勾，且該筆為修改，則除PKey外，其餘可編輯欄位皆設為啟用
                For i = 0 To columnEditIndex.Length - 1

                    pvtIsContinue = False

                    For j = 0 To columnPKeyIndex.Length - 1

                        If columnEditIndex(i) = columnPKeyIndex(j) Then
                            pvtIsContinue = True
                            Exit For
                        End If
                    Next

                    If pvtIsContinue Then
                        Continue For
                    End If

                    Me.dgv_Data.SetCellReadOnly(CInt(columnEditIndex(i)), inRowIndex, inIsReadOnly)
                Next
            End If

        End If


    End Sub

    ''' <summary>
    ''' 存檔或刪除失敗有關Grid處理
    ''' </summary>    
    ''' <remarks></remarks>
    Private Sub setErrorData(ByVal dsError As DataSet)
        Dim pvtCheckIdx As Integer

        '失敗資料畫面顯示處理
        For i = 0 To dsError.Tables(0).Rows.Count - 1

            pvtCheckIdx = CInt(dsError.Tables(0).Rows(i).Item("Check_Index"))

            dgv_Data.SetRowColor(pvtCheckIdx, Color.Pink)

            For j = 0 To columnEditIndex.Length - 1
                Me.dgv_Data.SetCellColor(CInt(columnEditIndex(j)), pvtCheckIdx, Color.Pink)
            Next

            dgv_Data.Rows(pvtCheckIdx).Cells("ErrMsg").Value = dsError.Tables(0).Rows(i).Item("ErrMsg").ToString.Trim

            For p = 0 To columnNameGrid.Count - 1
                dgv_Data.Rows(pvtCheckIdx).Cells(p).ToolTipText = dgv_Data.Rows(pvtCheckIdx).Cells("ErrMsg").Value
            Next
        Next
    End Sub

    ''' <summary>
    ''' 取得選取的Row
    ''' </summary>    
    ''' <remarks></remarks>
    Private Sub dgv_Data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Data.CellClick
        gblIndex = e.RowIndex
    End Sub

#End Region

#End Region

#Region "     取得勾選的Dataset資料 "

    Private Function getCheckData() As DataSet

        Dim pvtSysTime As String

        pvtSysTime = Now.ToString("yyyy/MM/dd HH:mm:ss")

        Dim dsCheckData As New DataSet
        dsCheckData = genDS(DataSet_Type.DB, DBName)

        '將勾選資料加入至DataSet
        For i = 0 To dgv_Data.Rows.Count - 1
            If dgv_Data.Rows(i).Cells(0).Value Then

                Dim drCheckData As DataRow = dsCheckData.Tables(DBName).NewRow()
                drCheckData("Language_Type_Id") = dgv_Data.GetDBDS.Tables(0).Rows(i).Item("類別").ToString.Trim
                drCheckData("Hospital_Code") = dgv_Data.Rows(i).Cells("醫院代碼").Value.ToString.Trim
                drCheckData("Effect_Date") = CDate(dgv_Data.GetDBDS.Tables(0).Rows(i).Item("生效日期")).ToString("yyyy-MM-dd")
                drCheckData("End_Date") = CDate(dgv_Data.GetDBDS.Tables(0).Rows(i).Item("結束日期")).ToString("yyyy-MM-dd")
                drCheckData("Hospital_Name") = dgv_Data.Rows(i).Cells("醫院名稱").Value.ToString.Trim
                drCheckData("Hospital_Short_Name") = dgv_Data.Rows(i).Cells("醫院簡稱").Value.ToString.Trim
                drCheckData("Telephone") = dgv_Data.Rows(i).Cells("電話").Value.ToString.Trim
                drCheckData("Fax") = dgv_Data.Rows(i).Cells("傳真").Value.ToString.Trim
                drCheckData("Voice_Tel") = dgv_Data.Rows(i).Cells("電腦語音專線").Value.ToString.Trim
                drCheckData("Postal_Code") = dgv_Data.GetDBDS.Tables(0).Rows(i).Item("郵遞區號").ToString.Trim
                drCheckData("Address") = dgv_Data.Rows(i).Cells("聯絡地址").Value.ToString.Trim
                drCheckData("Principal_Name") = dgv_Data.Rows(i).Cells("負責人姓名").Value.ToString.Trim
                drCheckData("Principal_Email") = dgv_Data.Rows(i).Cells("負責人Email").Value.ToString.Trim
                drCheckData("Hospital_Level_Id") = dgv_Data.GetDBDS.Tables(0).Rows(i).Item("醫療院所層級").ToString.Trim
                drCheckData("URL") = dgv_Data.Rows(i).Cells("網址").Value.ToString.Trim
                drCheckData("Unified_Business_No") = dgv_Data.Rows(i).Cells("醫院統編").Value.ToString.Trim
                'add by Elly 2016/10/19  --start
                drCheckData("Receipt_Hospital_Name") = dgv_Data.Rows(i).Cells("醫院名稱(收據用)").Value.ToString.Trim
                '--end
                drCheckData("Create_User") = CurrentUserID

                If dgv_Data.Rows(i).Cells("Status").Value.ToString.Trim = "I" Then
                    drCheckData("Create_Time") = pvtSysTime
                Else
                    If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then
                        drCheckData("Create_Time") = DateAdd(DateInterval.Year, 1911, CDate(dgv_Data.GetDBDS.Tables(0).Rows(i).Item("建立時間"))).ToString("yyyy/MM/dd HH:mm:ss")
                    Else
                        drCheckData("Create_Time") = CDate(dgv_Data.GetDBDS.Tables(0).Rows(i).Item("建立時間")).ToString("yyyy/MM/dd HH:mm:ss")
                    End If
                End If

                drCheckData("Modified_User") = CurrentUserID
                drCheckData("Modified_Time") = pvtSysTime
                If dgv_Data.Rows(i).Cells("Status").Value.ToString.Trim = "U" Then
                    drCheckData("Org_Effect_Date") = CDate(dgv_Data.Rows(i).Cells("Org_Effect_Date").Value.ToString.Trim).ToString("yyyy-MM-dd")
                End If
                drCheckData("Status") = dgv_Data.Rows(i).Cells("Status").Value.ToString.Trim
                drCheckData("ErrMsg") = ""
                drCheckData("Check_Index") = i.ToString
                dsCheckData.Tables(DBName).Rows.Add(drCheckData)
            End If
        Next

        Return dsCheckData

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
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (SaveData()) Then

                '左下方顯示 儲存 成功
                ShowInfoMsg("CMMCMMB301", "儲存")

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

#Region "     刪除 鎖定功能 "

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Private Sub btn_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Delete.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (DeleteData()) Then

                '左下方顯示 刪除 成功
                ShowInfoMsg("CMMCMMB301", "刪除")

            End If

        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"刪除 鎖定功能"})
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
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
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
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
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
    ''' <remarks>by Alan.Tsai on 2014-11-09</remarks>
    Private Sub KeyDownBottuns(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            '鎖定螢幕
            Lock(Me)

            Select Case e.KeyCode

                Case Keys.F10   '複製
                    btn_Copy.PerformClick()

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

End Class

