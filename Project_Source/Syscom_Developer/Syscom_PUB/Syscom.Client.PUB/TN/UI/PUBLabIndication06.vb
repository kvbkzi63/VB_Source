'/*
'*****************************************************************************
'*
'*    Page/Class Name:  特殊屬性輸入元件
'*              Title:	PUBLabIndication06
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


Public Class PUBLabIndication06
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

    '醫令代碼
    Public gblOrderCode As String = ""

    Public gblOrderName As String = ""

#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim PUB As IPubServiceManager

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBLabIndication06
    Public Shared Function GetInstance() As PUBLabIndication06
        If myInstance Is Nothing Then
            myInstance = New PUBLabIndication06
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
            Dim errorCode As Integer = ChkselectRbtRatio()

            If errorCode < 0 Then
                returnBoolean = False
                Select Case errorCode
                    Case -1
                        MessageHandling.ShowWarnMsg("請選擇檢體！")
                        Return returnBoolean
                    Case -2
                        MessageHandling.ShowWarnMsg("請輸入檢體備註！")
                        Return returnBoolean
                End Select
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

            Dim pvtComboDt As New DataTable
            pvtComboDt.Columns.Add("Specimen_Code")
            pvtComboDt.Columns.Add("Specimen_Name")

            If gblOrderCode = "130063" Then
                pvtComboDt.Rows.Add()
                pvtComboDt.NewRow()
                pvtComboDt.Rows(0).Item("Specimen_Code") = "60"
                pvtComboDt.Rows(0).Item("Specimen_Name") = "CSF"
            Else
                For i = 0 To 10
                    pvtComboDt.Rows.Add()
                    pvtComboDt.NewRow()
                    Select Case i
                        Case 0
                            pvtComboDt.Rows(i).Item("Specimen_Code") = "16"
                            pvtComboDt.Rows(i).Item("Specimen_Name") = "Abscess"

                        Case 1
                            pvtComboDt.Rows(i).Item("Specimen_Code") = "13"
                            pvtComboDt.Rows(i).Item("Specimen_Name") = "Sputum"

                        Case 2
                            pvtComboDt.Rows(i).Item("Specimen_Code") = "19"
                            pvtComboDt.Rows(i).Item("Specimen_Name") = "Bronchial washing"

                        Case 3
                            pvtComboDt.Rows(i).Item("Specimen_Code") = "28"
                            pvtComboDt.Rows(i).Item("Specimen_Name") = "Pleural effusion"

                        Case 4
                            pvtComboDt.Rows(i).Item("Specimen_Code") = "31"
                            pvtComboDt.Rows(i).Item("Specimen_Name") = "Ascites"

                        Case 5
                            pvtComboDt.Rows(i).Item("Specimen_Code") = "32"
                            pvtComboDt.Rows(i).Item("Specimen_Name") = "Synovia fluid"

                        Case 6
                            pvtComboDt.Rows(i).Item("Specimen_Code") = "33"
                            pvtComboDt.Rows(i).Item("Specimen_Name") = "Wound pus"

                        Case 7
                            pvtComboDt.Rows(i).Item("Specimen_Code") = "46"
                            pvtComboDt.Rows(i).Item("Specimen_Name") = "Pericardial effusion"

                        Case 8
                            pvtComboDt.Rows(i).Item("Specimen_Code") = "59"
                            pvtComboDt.Rows(i).Item("Specimen_Name") = "Bile"

                        Case 9
                            pvtComboDt.Rows(i).Item("Specimen_Code") = "60"
                            pvtComboDt.Rows(i).Item("Specimen_Name") = "CSF"

                        Case 10
                            pvtComboDt.Rows(i).Item("Specimen_Code") = "99"
                            pvtComboDt.Rows(i).Item("Specimen_Name") = "Other"

                    End Select
                Next

            End If

            Me.cbo_Specimen.DataSource = pvtComboDt
            Me.cbo_Specimen.uclDisplayIndex = "1"
            Me.cbo_Specimen.uclValueIndex = "0"

            Label4.Text = "開立" & gblOrderCode & "-" & gblOrderName & "，請選取檢體："

            '將傳入XML字傳值顯示畫面上對應欄位
            'If gblXmlData <> "" Then
            '    Dim pvtData As New DataSet
            '    pvtData = XMLUtil.XmlToDataSet(gblXmlData)

            '    If pvtData.Tables("使用抗生素").Rows(0).Item("是").ToString.Trim = "Y" Then
            '        rbt_Y.Checked = True
            '    Else
            '        rbt_N.Checked = True
            '    End If

            '    If pvtData.Tables("檢體來源").Rows(0).Item("Voided midstream urine").ToString.Trim = "Y" Then
            '        rbt_1.Checked = True
            '        rbt_2.Checked = False
            '        rbt_3.Checked = False
            '        rbt_4.Checked = False
            '    End If

            '    If pvtData.Tables("檢體來源").Rows(0).Item("catheter").ToString.Trim = "Y" Then
            '        rbt_1.Checked = False
            '        rbt_2.Checked = True
            '        rbt_3.Checked = False
            '        rbt_4.Checked = False
            '    End If

            '    If pvtData.Tables("檢體來源").Rows(0).Item("puncture").ToString.Trim = "Y" Then
            '        rbt_1.Checked = False
            '        rbt_2.Checked = False
            '        rbt_3.Checked = True
            '        rbt_4.Checked = False
            '    End If

            '    If pvtData.Tables("檢體來源").Rows(0).Item("PCN").ToString.Trim = "Y" Then
            '        rbt_1.Checked = False
            '        rbt_2.Checked = False
            '        rbt_3.Checked = False
            '        rbt_4.Checked = True
            '    End If

            'End If

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

    Private Function ChkselectRbtRatio() As Integer

        If cbo_Specimen.SelectedValue <> "" Then
            If cbo_Specimen.SelectedValue <> "99" Then
                Return 0
            Else
                If txt_SpecimenNote.Text = "" Then
                    Return -2  '檢體備註沒輸
                End If
            End If
        Else
            Return -1  '檢體沒選
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
        rowDt1.Item("特殊屬性表單代碼") = "PUBLabIndication06"
        rowDt1.Item("特殊屬性表單名稱") = "細菌檢驗申請單-Stain"
        dsCheckData.Tables(0).Rows.Add(rowDt1)
        '--------------------------------------------------------------------------------
        'Dataset:建第2個table
        dsCheckData.Tables.Add()
        dsCheckData.Tables(1).TableName = "檢體"
        dsCheckData.Tables(1).Columns.Add("檢體代碼")
        '存值入各欄位
        Dim rowDt2 As DataRow = dsCheckData.Tables(1).NewRow
        rowDt2.Item("檢體代碼") = cbo_Specimen.SelectedValue
        dsCheckData.Tables(1).Rows.Add(rowDt2)
        '--------------------------------------------------------------------------------
        'Dataset:建第3個table
        dsCheckData.Tables.Add()
        dsCheckData.Tables(2).TableName = "檢體備註"
        dsCheckData.Tables(2).Columns.Add("檢體備註說明")
        '存值入各欄位
        Dim rowDt3 As DataRow = dsCheckData.Tables(2).NewRow
        rowDt3.Item("檢體備註說明") = nvl(txt_SpecimenNote.Text)
        dsCheckData.Tables(2).Rows.Add(rowDt3)
        '--------------------------------------------------------------------------------
        'Dataset:建第4個table
        dsCheckData.Tables.Add()
        dsCheckData.Tables(3).TableName = "Indication"
        dsCheckData.Tables(3).Columns.Add("Indication_Type")
        dsCheckData.Tables(3).Columns.Add("Specimen_Code")
        dsCheckData.Tables(3).Columns.Add("Specimen_Memo")
        '存值入各欄位
        Dim rowDt4 As DataRow = dsCheckData.Tables(3).NewRow
        rowDt4.Item("Indication_Type") = "2" '1:By檢驗單 2:By Order
        rowDt4.Item("Specimen_Code") = cbo_Specimen.SelectedValue
        rowDt4.Item("Specimen_Memo") = txt_SpecimenNote.Text.Trim
        dsCheckData.Tables(3).Rows.Add(rowDt4)


        Return dsCheckData

    End Function

    Private Function getCheckDataByArray() As String()

        Dim pvtResult(2) As String

        pvtResult(0) = "2"  '1:By檢驗單 2:By Order

        If cbo_Specimen.SelectedValue <> "99" Then
            pvtResult(1) = gblOrderName & "--檢體：" & cbo_Specimen.Text.Trim

        Else
            pvtResult(1) = gblOrderName & "--檢體：" & cbo_Specimen.Text.Trim
            pvtResult(1) &= "   檢體備註：" & txt_SpecimenNote.Text.Trim

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

