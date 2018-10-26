'*****************************************************************************
'*
'*    Page/Class Name:	PUBNhiCodeUI.vb
'*              Title:	健保支付標準檔
'*        Description:	健保支付標準檔
'*          Copyright:	Copyright(c) SysCom Computer Co,.Ltd
'*            Company:	SysCom Computer Co,.Ltd.
'*            @author:	tor_qin
'*        Create Date:	2010/06/02
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************


Imports System.Runtime.InteropServices
Imports System
Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.UCL.UCLDataGridViewUC
Imports Syscom.Comm.LOG
Imports Syscom.Client.UCL
Imports System.Text
Imports System.Drawing
Imports System.Linq
Imports Com.Syscom.WinFormsUI.Docking
Imports System.Windows.Forms.VisualStyles
Imports System.ServiceModel
Imports Syscom.Comm.EXP

Public Class PUBNhiCodeUI
    Inherits Syscom.Client.UCL.BaseFormUI

    Dim objPub As IPubServiceManager = Nothing 'PubServiceManager.getInstance
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

    '獲取維護表名
    Dim columnNameGrid() As String = {"生效日", "保健碼", "英文名稱", "中文名稱", _
                                      "單價", "停止日", "急診加成", "兒童加成", _
                                      "牙科轉診加成", "假日加成", "科別加成", "保險費用項目", "保險醫令類別", _
                                      "特定治療項目", "檢查折扣(健保用)", "停用", _
                                        "急件加成率", "牙科轉診加成率", _
                                      "科別加成率", "兒童加成率(未滿6個月)", "兒童加成率(小於2歲)", "兒童加成率(2歲-6歲)", _
                                      "兒童加成率(小於等於48個月)", "兒童加成率(4歲以下)", "健保科別"}
    'Dim columNameDB() As String = {"Effect_Date", "Insu_Code", "Insu_En_Name", "Insu_Name", _
    '                               "Price", "End_Date", "Is_Emg_Add", "Is_Kid_Add", _
    '                               "Is_Dental_Add", "Is_Holiday_Add", "Insu_Account_Id", "Insu_Order_Type_Id", _
    '                               "Majorcare_Code", "Is_Labdiscount"}
    Dim currentUserID As String = AppContext.userProfile.userId
    Dim strColumnNameDB() As String = PubNhiCodeDataTableFactory.columnsName
    Dim strTableDB As String = PubNhiCodeDataTableFactory.tableName
    Dim strColumnLen() As Integer = PubNhiCodeDataTableFactory.columnsLength
    Const MAXDATE As String = "9998/12/31"
    Dim hashTable As New Hashtable()

    Private dtInsuAccountId As DataTable
    Private dtInsuOrderTypeId As DataTable
    Private dtMajorcareCode As DataTable
    Dim drarrRow() As DataRow

    Enum buttonAction
        OK
        QUERY
        CLEAR
        Up
        Down
        Delete
    End Enum
    '控件類型定義
    Enum Control_Type
        DateTimePicker
        TextBox
    End Enum

    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum


    '設定欄位寬度
    Private m_ChemoHeaderWidth As String = "30,100,250,30,60,30,30,30,30,60,60,60,60,30,60,30,60,60,60,60,60,60,60,60,0,0"

#Region "Load 初始化"
    Private Sub PUBNhiCodeUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            '初始化頁面
            initialize()
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMB007")
            MessageHandling.ShowErrorMsg("CMMCMMB007", New String() {}, "")
        End Try
    End Sub
    ''' <summary>
    ''' 初始化對象  
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialize()
        Try
            objPub = PubServiceManager.getInstance
            '保險費用項目
            initInsuAccountId("43")
            '保險醫令類別  
            initInsuOrderTypeId("501")
            '特定治療項目 cmbMajorcareCode 
            initMajorcareCode()
            '初始化grid
            Dim dataset As DataSet = genDS(DataSet_Type.Grid)
            initialGridHead(dataset)
            'Me.dtEffectDate.SetValue(Now.ToString("yyyy/MM/dd"))
            Me.txtInsuCode.MaxLength = strColumnLen(1)
            Me.txtInsuEnName.MaxLength = strColumnLen(2)
            Me.txtInsuName.MaxLength = strColumnLen(3)
            Me.txtDeptCodeset.MaxLength = strColumnLen(29)
            '可按刪除健人員 pub_config config_name = 'PUBNhiCode_Del'
            If initchkDel(currentUserID) Then
                Me.btnDelete.Enabled = True
            Else
                Me.btnDelete.Enabled = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化Grid
    ''' </summary>
    ''' <remarks></remarks>
    Sub initialGridHead(ByVal dataset As DataSet)

        '停用注記

        hashTable.Add(-1, dataset)
        hashTable.Add(6, New CheckBoxCell)
        hashTable.Add(7, New CheckBoxCell)
        hashTable.Add(8, New CheckBoxCell)
        hashTable.Add(9, New CheckBoxCell)
        '20110815 add by yunfei
        hashTable.Add(10, New CheckBoxCell)
        hashTable.Add(14, New CheckBoxCell)

        Me.dgvData.Initial(hashTable)
        dgvData.Columns(15).Visible = False
    End Sub

    ''' <summary>
    ''' 初始化對象 保險費用項目
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initInsuAccountId(ByVal strType As String)

        Dim dsDB As DataSet
        '執行查詢
        dsDB = objPub.queryPUBSysCode(strType)
        Try
            If dsDB.Tables.Count > 0 Then
                dtInsuAccountId = dsDB.Tables(0)
                If dtInsuAccountId.Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                Else
                    '初始化性別 
                    Me.cmbInsuAccountId.DataSource = dtInsuAccountId
                    Me.cmbInsuAccountId.uclDisplayIndex = "0,1"
                    Me.cmbInsuAccountId.uclValueIndex = "0"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化對象 保險醫令類別
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initInsuOrderTypeId(ByVal strType As String)

        Dim dsDB As DataSet
        '執行查詢
        dsDB = objPub.queryPUBSysCode(strType)
        Try
            If dsDB.Tables.Count > 0 Then
                dtInsuOrderTypeId = dsDB.Tables(0)
                If dsDB.Tables(0).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                Else
                    '初始化性別 
                    Me.cmbInsuOrderTypeId.DataSource = dtInsuOrderTypeId
                    Me.cmbInsuOrderTypeId.uclDisplayIndex = "0,1"
                    Me.cmbInsuOrderTypeId.uclValueIndex = "0"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' 初始化對象 特定治療項目
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initMajorcareCode()
        Dim dsDB As DataSet
        '執行查詢
        dsDB = objPub.queryPUBMajorNoEquByCond_L("1")
        Try
            If dsDB.Tables.Count > 0 Then
                dtMajorcareCode = dsDB.Tables(0)
                If dsDB.Tables(0).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                Else
                    '初始化性別 
                    Me.cmbMajorcareCode.DataSource = dtMajorcareCode
                    Me.cmbMajorcareCode.uclDisplayIndex = "0,1"
                    Me.cmbMajorcareCode.uclValueIndex = "0"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ' <summary>
    ' 初始化對象 確認是否為健保支付標準檔有刪除權限的人員 黃南陽 2013/11/1
    ' </summary>
    ' <remarks></remarks>
    Public Function initchkDel(ByVal strCurrentID As String) As Boolean

        Dim dsDB As DataSet
        '執行查詢
        dsDB = objPub.queryPubConfigWhereConfigNameEquals("PUBNhiCode_Del")
        Try
            If dsDB.Tables(0).Rows.Count > 0 Then
                If dsDB.Tables(0).Rows(0).Item(2).ToString.Contains(strCurrentID) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "動作事件"
#Region "    查詢"
    Private Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()
            If (queryData()) Then
                'controlButton(buttonAction.QUERY)
                'ming 20091013 del
                'If (dgvData.CurrentRow IsNot Nothing AndAlso dgvData.CurrentRow.Index >= 0) Then dgvData.CurrentRow.Selected = False


                If (dgvData.CurrentRow IsNot Nothing AndAlso dgvData.CurrentRow.Index >= 0) Then
                    '清除選中資料行 ming 20091013 add
                    dgvData.CurrentRow.Selected = False
                    '清除選中資料項 ming 20091013 add
                    dgvData.CurrentCell = Nothing
                End If
                '清除全局變量 ming 20091013 add
                'pDataRowView = Nothing
                'MessageHandling.showInfoByKey("CMMCMMB001")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("CMMCMMB001", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD001")
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub
    Private Function queryData(Optional ByVal Action As buttonAction = buttonAction.QUERY) As Boolean
        Dim iButtonFlag As Integer = buttonAction.QUERY
        Dim blnReturnFlag As Boolean = True
        Dim dsDB As New DataSet
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        Dim dateEffectDate As Date
        Dim strDC As String = ""
        '輸入區欄位顏色初始化
        cleanFieldsColor()

        Dim strInsuCode As String = Me.txtInsuCode.Text.ToString.Trim.Replace("'", "''")

        Try
            If Me.dtEffectDate.IsEmpty Then
                dateEffectDate = System.DateTime.MinValue
            Else
                dateEffectDate = CDate(Me.dtEffectDate.GetUsDateStr).ToString("yyyy/MM/dd").Trim
            End If
            '執行查詢
            If Action = buttonAction.QUERY Then
                dsDB = objPub.queryPUBNhiCodeByCond_L(dateEffectDate, strInsuCode)
            ElseIf Action = buttonAction.Down Then
                dsDB = objPub.queryPUBNhiCodeUpDown_L(dateEffectDate, strInsuCode, 2)
            ElseIf Action = buttonAction.Up Then
                dsDB = objPub.queryPUBNhiCodeUpDown_L(dateEffectDate, strInsuCode, 1)
            End If

            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(strTableDB).Rows.Count = 0 Then
                    '查無符合條件之資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {})
                Else
                    Dim drGrid(dsDB.Tables(strTableDB).Rows.Count - 1) As DataRow
                    '將查詢的數據插入到Grid表中並顯示在畫面上
                    For i As Integer = 0 To dsDB.Tables(strTableDB).Rows.Count - 1
                        drGrid(i) = dsGrid.Tables(strTableDB).NewRow()

                        drGrid(i)("生效日") = DateUtil.TransDateToROC(CDate(dsDB.Tables(strTableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd").Trim())
                        drGrid(i)("保健碼") = dsDB.Tables(strTableDB).Rows(i)("Insu_Code").ToString.Trim()
                        drGrid(i)("英文名稱") = dsDB.Tables(strTableDB).Rows(i)("Insu_En_Name").ToString.Trim()
                        drGrid(i)("中文名稱") = dsDB.Tables(strTableDB).Rows(i)("Insu_Name").ToString.Trim()
                        drGrid(i)("單價") = dsDB.Tables(strTableDB).Rows(i)("Price").ToString.Trim()
                        drGrid(i)("停止日") = DateUtil.TransDateToROC(CDate(dsDB.Tables(strTableDB).Rows(i)("End_Date")).ToString("yyyy/MM/dd").Trim())
                        drGrid(i)("急診加成") = dsDB.Tables(strTableDB).Rows(i)("Is_Emg_Add").ToString.Trim()
                        drGrid(i)("兒童加成") = dsDB.Tables(strTableDB).Rows(i)("Is_Kid_Add").ToString.Trim()
                        drGrid(i)("牙科轉診加成") = dsDB.Tables(strTableDB).Rows(i)("Is_Dental_Add").ToString.Trim()
                        drGrid(i)("假日加成") = dsDB.Tables(strTableDB).Rows(i)("Is_Holiday_Add").ToString.Trim()

                        '20110421 update by yunfei
                        If dsDB.Tables(strTableDB).Rows(i)("Insu_Account_Id").ToString.Trim() <> "" Then
                            drarrRow = dtInsuAccountId.Select("Code_Id ='" + dsDB.Tables(strTableDB).Rows(i)("Insu_Account_Id").ToString.Trim() + "'")
                            If drarrRow.Length > 0 Then
                                drGrid(i)("保險費用項目") = drarrRow(0)("Code_Id").ToString & " - " & drarrRow(0)("Code_Name").ToString
                            Else
                                drGrid(i)("保險費用項目") = ""
                            End If
                        Else
                            drGrid(i)("保險費用項目") = ""
                        End If
                        If dsDB.Tables(strTableDB).Rows(i)("Insu_Order_Type_Id").ToString.Trim() <> "" Then
                            drarrRow = dtInsuOrderTypeId.Select("Code_Id ='" + dsDB.Tables(strTableDB).Rows(i)("Insu_Order_Type_Id").ToString.Trim() + "'")
                            If drarrRow.Length > 0 Then
                                drGrid(i)("保險醫令類別") = drarrRow(0)("Code_Id").ToString & " - " & drarrRow(0)("Code_Name").ToString
                            Else
                                drGrid(i)("保險醫令類別") = ""
                            End If
                        Else
                            drGrid(i)("保險醫令類別") = ""
                        End If
                        If dsDB.Tables(strTableDB).Rows(i)("Majorcare_Code").ToString.Trim() <> "" Then
                            drarrRow = dtMajorcareCode.Select("Majorcare_Code ='" + dsDB.Tables(strTableDB).Rows(i)("Majorcare_Code").ToString.Trim() + "'")
                            If drarrRow.Length > 0 Then
                                drGrid(i)("特定治療項目") = drarrRow(0)("Majorcare_Code").ToString & " - " & drarrRow(0)("Majorcare_Name").ToString
                            Else
                                drGrid(i)("特定治療項目") = ""
                            End If
                        Else
                            drGrid(i)("特定治療項目") = ""
                        End If

                        drGrid(i)("檢查折扣(健保用)") = dsDB.Tables(strTableDB).Rows(i)("Is_Labdiscount").ToString.Trim()
                        '是否停用
                        If dsDB.Tables(strTableDB).Rows(i)("DC").ToString.Trim().Equals("N") Then
                            strDC = "否"
                        Else
                            strDC = "是"
                        End If
                        drGrid(i)("停用") = strDC
                        strDC = ""
                        '20110809 add by yunfei
                        drGrid(i)("科別加成") = dsDB.Tables(strTableDB).Rows(i)("Is_Dept_Add").ToString.Trim()
                        drGrid(i)("急件加成率") = dsDB.Tables(strTableDB).Rows(i)("Emg_Add_Ratio").ToString.Trim()
                        drGrid(i)("牙科轉診加成率") = dsDB.Tables(strTableDB).Rows(i)("Dental_Add_Ratio").ToString.Trim()
                        drGrid(i)("科別加成率") = dsDB.Tables(strTableDB).Rows(i)("Dept_Add_Ratio").ToString.Trim()
                        drGrid(i)("兒童加成率(未滿6個月)") = dsDB.Tables(strTableDB).Rows(i)("Kid_Add_Ratio1").ToString.Trim()
                        drGrid(i)("兒童加成率(小於2歲)") = dsDB.Tables(strTableDB).Rows(i)("Kid_Add_Ratio2").ToString.Trim()
                        drGrid(i)("兒童加成率(2歲-6歲)") = dsDB.Tables(strTableDB).Rows(i)("Kid_Add_Ratio3").ToString.Trim()
                        drGrid(i)("兒童加成率(小於等於48個月)") = dsDB.Tables(strTableDB).Rows(i)("Kid_Add_Ratio4").ToString.Trim()
                        drGrid(i)("兒童加成率(4歲以下)") = dsDB.Tables(strTableDB).Rows(i)("Kid_Add_Ratio5").ToString.Trim()
                        drGrid(i)("健保科別") = dsDB.Tables(strTableDB).Rows(i)("Dept_Code_set").ToString.Trim()
                        dsGrid.Tables(strTableDB).Rows.Add(drGrid(i))
                    Next

                    hashTable.Item(-1) = dsGrid

                    dgvData.Initial(hashTable)
                    dgvData.Columns(15).Visible = False
                End If
                Return blnReturnFlag
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
#Region "    确定"
    ''' <summary>
    ''' 確定 
    ''' </summary>
    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()
            If (confirmPUBPart()) Then
                'MessageHandling.showInfoByKey("HEMCMMB005")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowInfoMsg("HEMCMMB005", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("HEMCMMD015")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("HEMCMMD015", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub
    ''' <summary>
    ''' 確定儲存健保部份負擔資料
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 成功</remarks>
    Public Function confirmPUBPart() As Boolean
        Dim iButtonFlag As Integer = buttonAction.OK
        Dim blnReturnFlag As Boolean = True

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            Dim iCount As Integer = 0
            Dim dsDB As DataSet = genDS(DataSet_Type.DB)
            Dim dsReturn As DataSet
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
            Dim drGrid As DataRow = dsGrid.Tables(strTableDB).NewRow()
            Dim drDB As DataRow = dsDB.Tables(strTableDB).NewRow()

            'DB檢查
            If dbCheck() Then
                Return False
            End If

            '將輸入區資料塞入DB1中
            drDB("Effect_Date") = Me.dtEffectDate.GetUsDateStr.ToString.Trim
            drDB("Insu_Code") = Me.txtInsuCode.Text.Trim
            drDB("Insu_En_Name") = Me.txtInsuEnName.Text.Trim.Replace("'", "''")
            drDB("Insu_Name") = Me.txtInsuName.Text.Trim.Replace("'", "''")
            drDB("Price") = Me.txtPrice.Text.Trim
            If Me.dtEndDate.IsEmpty Or Me.dtEndDate.GetUsDateStr > MAXDATE Then
                drDB("End_Date") = MAXDATE
            Else
                drDB("End_Date") = Me.dtEndDate.GetUsDateStr
            End If
            If Me.cbIsEmgAdd.Checked = True Then
                drDB("Is_Emg_Add") = "Y"
            Else
                drDB("Is_Emg_Add") = "N"
            End If
            If Me.cbIsKidAdd.Checked = True Then
                drDB("Is_Kid_Add") = "Y"
            Else
                drDB("Is_Kid_Add") = "N"
            End If
            If Me.cbIsDentalAdd.Checked = True Then
                drDB("Is_Dental_Add") = "Y"
            Else
                drDB("Is_Dental_Add") = "N"
            End If
            If Me.cbIsHolidayAdd.Checked = True Then
                drDB("Is_Holiday_Add") = "Y"
            Else
                drDB("Is_Holiday_Add") = "N"
            End If
            If Me.chkIsLabdiscount.Checked = True Then
                drDB("Is_Labdiscount") = "Y"
            Else
                drDB("Is_Labdiscount") = "N"
            End If

            drDB("Dc") = "N"

            drDB("Insu_Account_Id") = cmbInsuAccountId.SelectedValue.ToString.Trim
            drDB("Insu_Order_Type_Id") = cmbInsuOrderTypeId.SelectedValue.ToString.Trim
            drDB("Majorcare_Code") = cmbMajorcareCode.SelectedValue.ToString.Trim
            If currentUserID.Trim() = "" Then
                currentUserID = "pubuser"
            End If
            drDB("Create_User") = currentUserID
            drDB("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = drDB("Create_Time")
            '20110809 add by yunfei
            If Me.ckbIsDeptAdd.Checked = True Then
                drDB("Is_Dept_Add") = "Y"
            Else
                drDB("Is_Dept_Add") = "N"
            End If
            If Me.txtEmgAddRatio.Text.Trim <> "" Then
                drDB("Emg_Add_Ratio") = Me.txtEmgAddRatio.Text.Trim
            Else
                drDB("Emg_Add_Ratio") = Nothing
            End If
            If Me.txtDentalAddRatio.Text.Trim <> "" Then
                drDB("Dental_Add_Ratio") = Me.txtDentalAddRatio.Text.Trim
            Else
                drDB("Dental_Add_Ratio") = Nothing
            End If
            If Me.txtDeptAddRatio.Text.Trim <> "" Then
                drDB("Dept_Add_Ratio") = Me.txtDeptAddRatio.Text.Trim
            Else
                drDB("Dept_Add_Ratio") = Nothing
            End If
            If Me.txtKidAddRatio1.Text.Trim <> "" Then
                drDB("Kid_Add_Ratio1") = Me.txtKidAddRatio1.Text.Trim
            Else
                drDB("Kid_Add_Ratio1") = Nothing
            End If
            If Me.txtKidAddRatio2.Text.Trim <> "" Then
                drDB("Kid_Add_Ratio2") = Me.txtKidAddRatio2.Text.Trim
            Else
                drDB("Kid_Add_Ratio2") = Nothing
            End If
            If Me.txtKidAddRatio3.Text.Trim <> "" Then
                drDB("Kid_Add_Ratio3") = Me.txtKidAddRatio3.Text.Trim
            Else
                drDB("Kid_Add_Ratio3") = Nothing
            End If
            If Me.txtKidAddRatio4.Text.Trim <> "" Then
                drDB("Kid_Add_Ratio4") = Me.txtKidAddRatio4.Text.Trim
            Else
                drDB("Kid_Add_Ratio4") = Nothing
            End If
            If Me.txtKidAddRatio5.Text.Trim <> "" Then
                drDB("Kid_Add_Ratio5") = Me.txtKidAddRatio5.Text.Trim
            Else
                drDB("Kid_Add_Ratio5") = Nothing
            End If
            drDB("Kid_Add_Ratio6") = Nothing
            drDB("Dept_Code_set") = Me.txtDeptCodeset.Text.ToString.Trim()


            dsDB.Tables(strTableDB).Rows.Add(drDB)

            '確定儲存健保部份負擔資料
            dsReturn = objPub.confirmPUBNhiCode_L(dsDB)

            If dsReturn.Tables.Count > 0 Then
                '邦定Grid
                bindDataGridView(dsReturn, buttonAction.OK)
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 邦定DataGridView
    ''' </summary>
    ''' <param name="ds">更新數據集</param>
    ''' <param name="iButtonFlag">Button標記</param>
    ''' <remarks></remarks>
    Private Sub bindDataGridView(ByVal ds As DataSet, ByVal iButtonFlag As Integer)
        Try
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
            Dim drGrid(ds.Tables(strTableDB).Rows.Count - 1) As DataRow
            Dim iIndex As Integer
            '將查出的資料塞入Grid中
            For i As Integer = 0 To ds.Tables(strTableDB).Rows.Count - 1

                drGrid(i) = dsGrid.Tables(strTableDB).NewRow()

                drGrid(i)("生效日") = CDate(ds.Tables(strTableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd")
                drGrid(i)("保健碼") = ds.Tables(strTableDB).Rows(i)("Insu_Code").ToString.Trim()
                drGrid(i)("英文名稱") = ds.Tables(strTableDB).Rows(i)("Insu_En_Name").ToString.Trim()
                drGrid(i)("中文名稱") = ds.Tables(strTableDB).Rows(i)("Insu_Name").ToString.Trim()
                drGrid(i)("單價") = ds.Tables(strTableDB).Rows(i)("Price").ToString.Trim()
                drGrid(i)("停止日") = CDate(ds.Tables(strTableDB).Rows(i)("End_Date")).ToString("yyyy/MM/dd")

                drGrid(i)("急診加成") = ds.Tables(strTableDB).Rows(i)("Is_Emg_Add").ToString.Trim()
                drGrid(i)("兒童加成") = ds.Tables(strTableDB).Rows(i)("Is_Kid_Add").ToString.Trim()
                drGrid(i)("牙科轉診加成") = ds.Tables(strTableDB).Rows(i)("Is_Dental_Add").ToString.Trim()
                drGrid(i)("假日加成") = ds.Tables(strTableDB).Rows(i)("Is_Holiday_Add").ToString.Trim()
                drGrid(i)("檢查折扣(健保用)") = ds.Tables(strTableDB).Rows(i)("Is_Labdiscount").ToString.Trim()
                If ds.Tables(strTableDB).Rows(i)("DC").ToString.Trim() = "Y" Then
                    drGrid(i)("停用") = "是"  '停用"
                Else
                    drGrid(i)("停用") = "否"
                End If

                If ds.Tables(strTableDB).Rows(i)("Insu_Account_Id").ToString.Trim() <> "" Then
                    drarrRow = dtInsuAccountId.Select("Code_Id ='" + ds.Tables(strTableDB).Rows(i)("Insu_Account_Id").ToString.Trim() + "'")
                    If drarrRow.Count > 0 Then
                        drGrid(i)("保險費用項目") = drarrRow(0)("Code_Id").ToString & " - " & drarrRow(0)("Code_Name").ToString
                    Else
                        drGrid(i)("保險費用項目") = ""
                    End If
                Else
                    drGrid(i)("保險費用項目") = ""
                End If
                If ds.Tables(strTableDB).Rows(i)("Insu_Order_Type_Id").ToString.Trim() <> "" Then
                    drarrRow = dtInsuOrderTypeId.Select("Code_Id ='" + ds.Tables(strTableDB).Rows(i)("Insu_Order_Type_Id").ToString.Trim() + "'")
                    If drarrRow.Count > 0 Then
                        drGrid(i)("保險醫令類別") = drarrRow(0)("Code_Id").ToString & " - " & drarrRow(0)("Code_Name").ToString
                    Else
                        drGrid(i)("保險醫令類別") = ""
                    End If
                Else
                    drGrid(i)("保險醫令類別") = ""
                End If
                If ds.Tables(strTableDB).Rows(i)("Majorcare_Code").ToString.Trim() <> "" Then
                    drarrRow = dtMajorcareCode.Select("Majorcare_Code ='" + ds.Tables(strTableDB).Rows(i)("Majorcare_Code").ToString.Trim() + "'")
                    If drarrRow.Count > 0 Then
                        drGrid(i)("特定治療項目") = drarrRow(0)("Majorcare_Code").ToString & " - " & drarrRow(0)("Majorcare_Name").ToString
                    Else
                        drGrid(i)("特定治療項目") = ""
                    End If
                Else
                    drGrid(i)("特定治療項目") = ""
                End If
                '20110809 add by yunfei
                drGrid(i)("科別加成") = ds.Tables(strTableDB).Rows(i)("Is_Dept_Add").ToString.Trim()
                drGrid(i)("急件加成率") = ds.Tables(strTableDB).Rows(i)("Emg_Add_Ratio").ToString.Trim()
                drGrid(i)("牙科轉診加成率") = ds.Tables(strTableDB).Rows(i)("Dental_Add_Ratio").ToString.Trim()
                drGrid(i)("科別加成率") = ds.Tables(strTableDB).Rows(i)("Dept_Add_Ratio").ToString.Trim()
                drGrid(i)("兒童加成率(未滿6個月)") = ds.Tables(strTableDB).Rows(i)("Kid_Add_Ratio1").ToString.Trim()
                drGrid(i)("兒童加成率(小於2歲)") = ds.Tables(strTableDB).Rows(i)("Kid_Add_Ratio2").ToString.Trim()
                drGrid(i)("兒童加成率(2歲-6歲)") = ds.Tables(strTableDB).Rows(i)("Kid_Add_Ratio3").ToString.Trim()
                drGrid(i)("兒童加成率(小於等於48個月)") = ds.Tables(strTableDB).Rows(i)("Kid_Add_Ratio4").ToString.Trim()
                drGrid(i)("兒童加成率(4歲以下)") = ds.Tables(strTableDB).Rows(i)("Kid_Add_Ratio5").ToString.Trim()
                drGrid(i)("健保科別") = ds.Tables(strTableDB).Rows(i)("Dept_Code_set").ToString.Trim()
                dsGrid.Tables(strTableDB).Rows.Add(drGrid(i))
            Next
            '資料邦定到Grid
            hashTable.Item(-1) = dsGrid
            dgvData.Initial(hashTable)
            dgvData.Columns(15).Visible = False
            If iButtonFlag = buttonAction.OK Then
                '選中沒有停用列
                dgvData.CurrentCell = dgvData.Rows(iIndex).Cells(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    ''' <summary>
    ''' DB檢查
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 失敗;False 成功</remarks>
    Private Function dbCheck() As Boolean
        Dim dsDB As DataSet
        Dim strEffectDate As String = String.Empty
        Dim i As Integer
        Dim iIndex As Integer
        Dim strMsg As String
        Dim strInsuCode As String = Me.txtInsuCode.Text.ToString.Trim
        Try
            'queryPUBNhiCodeByCond_L(dateEffectDate, strInsuCode)
            dsDB = objPub.queryPUBNhiCodeByCond_L(System.DateTime.MinValue, strInsuCode)

            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count = 0 Then
                    Return False
                End If
                For i = 0 To dsDB.Tables(0).Rows.Count - 1
                    If dsDB.Tables(0).Rows(i)("Dc").ToString() = "N" Then
                        Exit For
                    End If
                Next
                If i = dsDB.Tables(0).Rows.Count Then
                    iIndex = dsDB.Tables(0).Rows.Count - 1
                Else
                    iIndex = i - 1
                End If
                If iIndex < 0 Then
                    strEffectDate = System.DateTime.MinValue.ToString("yyyy/MM/dd")
                Else
                    strEffectDate = CDate(dsDB.Tables(0).Rows(iIndex)("Effect_Date")).ToString("yyyy/MM/dd")
                End If
                '生效日必需大於表中已停用的生效日
                If Me.dtEffectDate.GetUsDateStr <= strEffectDate Then
                    strMsg = ResourceUtil.getString("CMMCMMB102", New String() {"生效日", "已停用的生效日"})
                    'MessageHandling.showError(strMsg)
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {strMsg}, "")
                    Me.dtEffectDate.Focus()
                    Return True
                End If
                '詢問User需Delete已存在的record
                If i < dsDB.Tables(0).Rows.Count Then
                    strEffectDate = CDate(dsDB.Tables(0).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd")
                    If Not strEffectDate.Equals(Me.dtEffectDate.GetUsDateStr) Then
                        If (Me.dtEffectDate.GetUsDateStr <= Now.ToString("yyyy/MM/dd") And Me.dtEffectDate.GetUsDateStr < strEffectDate) Or _
                           (Me.dtEffectDate.GetUsDateStr > Now.ToString("yyyy/MM/dd") And i < dsDB.Tables(0).Rows.Count - 1) Then
                            'If (MessageHandling.showQuestionByKey("HEMCMMB007") <> Windows.Forms.DialogResult.Yes) Then
                            '********************2010/2/9 Modify By Alan**********************
                            If (MessageHandling.ShowQuestionMsg("HEMCMMB007", New String() {}) <> Windows.Forms.DialogResult.Yes) Then
                                Return True
                            End If
                        End If
                    End If
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "    清除"
    Private Sub btn_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Clear.Click
        Try
            clearData()

            '清除全局變量  
            drarrRow = Nothing

            MessageHandling.ClearInfoMsg()
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD006")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMD006", New String() {}, "")
        End Try
        MessageHandling.ClearInfoMsg()
    End Sub
#End Region
#Region "    快捷键"
    Private Sub PUBNhiCodeUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                '清除
                'MessageHandling.clearInfoMsg()
                btn_Clear_Click(sender, e)
            Case Keys.F1
                '查詢
                'MessageHandling.clearInfoMsg()
                btn_Query_Click(sender, e)
            Case Keys.F12
                '刪除 SF12
                If e.Shift Then
                    If (btnDelete.Enabled) Then btnDelete_Click(sender, e)
                Else
                    '確定
                    If Me.btn_OK.Enabled = True Then btn_OK_Click(sender, e)
                End If

            Case Keys.Enter
                Me.ProcessTabKey(True)
        End Select
    End Sub

#End Region
#Region "TextBox 事件"
    ''' <summary>
    ''' 急件加成
    ''' </summary>
    ''' <param name="send"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtEmgAddRatio_TextChanged(ByVal send As Object, ByVal e As System.EventArgs) Handles txtEmgAddRatio.TextChanged
        Try
            If send.ToString.Trim <> "" Then
                cbIsEmgAdd.Checked = True
            Else
                cbIsEmgAdd.Checked = False
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"急件"})
        End Try

    End Sub

    ''' <summary>
    ''' 牙科加成
    ''' </summary>
    ''' <param name="send"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtDentalAddRatio_TextChanged(ByVal send As Object, ByVal e As System.EventArgs) Handles txtDentalAddRatio.TextChanged
        Try
            If send.ToString.Trim <> "" Then
                cbIsDentalAdd.Checked = True
            Else
                cbIsDentalAdd.Checked = False
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"牙科"})
        End Try

    End Sub

    ''' <summary>
    ''' 科別加成
    ''' </summary>
    ''' <param name="send"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtDeptAddRatio_TextChanged(ByVal send As Object, ByVal e As System.EventArgs) Handles txtDeptAddRatio.TextChanged
        Try
            If send.ToString.Trim <> "" Then
                ckbIsDeptAdd.Checked = True
            Else
                ckbIsDeptAdd.Checked = False
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"牙科"})
        End Try

    End Sub


    ''' <summary>
    ''' 兒科加成
    ''' </summary>
    ''' <param name="send"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub KidAddRatio_TextChanged(ByVal send As Object, ByVal e As System.EventArgs) Handles txtKidAddRatio1.TextChanged, txtDentalAddRatio.TextChanged, txtKidAddRatio3.TextChanged, _
                                                                                                   txtKidAddRatio4.TextChanged, txtKidAddRatio5.TextChanged

        Try
            If send.ToString.Trim <> "" Then
                cbIsKidAdd.Checked = True
            Else
                cbIsKidAdd.Checked = False
            End If
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"牙科"})
        End Try

    End Sub
#End Region
#Region "查詢科別"
    Private Sub btn_QueryDept_Click(sender As Object, e As EventArgs) Handles btn_QueryDept.Click
        Try
            Dim deptDS As DataSet = objPub.queryPUBNhiDeptCode()
            If deptDS Is Nothing Then
                Exit Sub
            End If
            Dim ht As Hashtable = GetHashTable(deptDS)

            Dim OpenUI As UclMutiGridUI = New UclMutiGridUI
            OpenUI.ShowDialog("健保科別", ht, "科別代碼,科別名稱", "1,2", "80,100", True)

            If OpenUI.DialogResult = Windows.Forms.DialogResult.OK Then
                '取得打勾的資料
                Dim dscheck As DataSet = OpenUI.GetSelectedDS()

                Dim strDeptCode As String = ""

                '組合提醒字眼
                For Each dr As DataRow In dscheck.Tables(0).Rows
                    strDeptCode += dr.Item("Insu_Dept_Code").ToString.Trim & ","
                Next

                '去掉最後的逗號
                If strDeptCode.Length > 0 Then
                    strDeptCode = strDeptCode.Substring(0, strDeptCode.Length - 1)
                    txtDeptCodeset.Text = strDeptCode
                End If




            Else

            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢科別"})
        End Try

    End Sub

#End Region
#End Region
#Region "DataGrid 的事件"


    ''' <summary>
    ''' 按下DatagridView的cell時,需處理的事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvData_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellValueChanged
        Try
            If (e.RowIndex >= 0) Then
                'GRID點擊后，將選中行給全局變量 ming 20091013 add
                'If dgvData.ContainsFocus AndAlso dgvData.CurrentCellAddress.Y >= 0 Then
                '    pDataRowView = dgvData.Rows(dgvData.CurrentCellAddress.Y).DataBoundItem
                'End If

                '急診加成
                If (Me.dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(6).Value) Then
                    Me.cbIsEmgAdd.Checked = True
                Else
                    Me.cbIsEmgAdd.Checked = False
                End If
                '兒童加成
                If (dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(7).Value) Then
                    Me.cbIsKidAdd.Checked = True
                Else
                    Me.cbIsKidAdd.Checked = False
                End If
                '牙科轉診加成
                If (dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(8).Value) Then
                    Me.cbIsDentalAdd.Checked = True
                Else
                    Me.cbIsDentalAdd.Checked = False
                End If
                '假日加成
                If (dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(9).Value) Then
                    Me.cbIsHolidayAdd.Checked = True
                Else
                    Me.cbIsHolidayAdd.Checked = False
                End If
                '
                If (dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(14).Value) Then
                    Me.chkIsLabdiscount.Checked = True
                Else
                    Me.chkIsLabdiscount.Checked = False
                End If
                '20110815 add by yunfei
                If (dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(10).Value) Then
                    Me.ckbIsDeptAdd.Checked = True
                Else
                    Me.ckbIsDeptAdd.Checked = False
                End If

            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showError(ResourceUtil.getString("HEMCMMB203", New String(0) {"資料"}))
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("HEMCMMB203", New String() {}, "")
        End Try
    End Sub
    Private Sub dgvData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellClick
        Try
            If (e.RowIndex >= 0) Then
                'GRID點擊后，將選中行給全局變量 ming 20091013 add
                'If dgvData.ContainsFocus AndAlso dgvData.CurrentCellAddress.Y >= 0 Then
                '    pDataRowView = dgvData.Rows(dgvData.CurrentCellAddress.Y).DataBoundItem
                'End If

                dgvCellClick()
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showError(ResourceUtil.getString("HEMCMMB203", New String(0) {"資料"}))
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("HEMCMMB203", New String() {}, "")
        End Try
    End Sub

    ''' <summary>
    ''' 點選行資料,塞入輸入區
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub dgvCellClick()
        Try
            '清除欄位資料
            cleanFieldsValue()
            '清除欄位背景顏色
            cleanFieldsColor()
            If dgvData.CurrentCellAddress.Y >= 0 Then

                Me.dtEffectDate.SetValue(DateUtil.TransDateToWE(dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("生效日").Value.ToString.Trim))
                Me.dtEndDate.SetValue(DateUtil.TransDateToWE(dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("停止日").Value.ToString.Trim))
                Me.txtInsuCode.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("保健碼").Value.ToString.Trim
                Me.txtInsuEnName.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("英文名稱").Value.ToString.Trim
                Me.txtInsuName.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("中文名稱").Value.ToString.Trim
                Me.txtPrice.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("單價").Value.ToString.Trim
                'If dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("急診加成").Value.ToString.Trim.Equals("Y") Then
                '急診加成
                If (Me.dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(6).Value) Then
                    Me.cbIsEmgAdd.Checked = True
                Else
                    Me.cbIsEmgAdd.Checked = False
                End If
                '兒童加成
                If (dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(7).Value) Then
                    Me.cbIsKidAdd.Checked = True
                Else
                    Me.cbIsKidAdd.Checked = False
                End If
                '牙科轉診加成
                If (dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(8).Value) Then
                    Me.cbIsDentalAdd.Checked = True
                Else
                    Me.cbIsDentalAdd.Checked = False
                End If
                '  假日加成
                If (dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(9).Value) Then
                    Me.cbIsHolidayAdd.Checked = True
                Else
                    Me.cbIsHolidayAdd.Checked = False
                End If
                Me.cmbInsuAccountId.SelectedValue = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("保險費用項目").Value.ToString.Trim.Split(" ")(0)
                Me.cmbInsuOrderTypeId.SelectedValue = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("保險醫令類別").Value.ToString.Trim.Split(" ")(0)
                Me.cmbMajorcareCode.SelectedValue = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("特定治療項目").Value.ToString.Trim.Split(" ")(0)
                '  檢查折扣(健保用)
                If (dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(14).Value) Then
                    Me.chkIsLabdiscount.Checked = True
                Else
                    Me.chkIsLabdiscount.Checked = False
                End If
                '  停用
                If (dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(15).Value).ToString.Trim = "否" Then
                    Me.btn_OK.Enabled = True
                Else
                    Me.btn_OK.Enabled = False
                End If
                '20110815 add by yunfei
                '科別是否加成
                If (dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells(10).Value) Then
                    Me.ckbIsDeptAdd.Checked = True
                Else
                    Me.ckbIsDeptAdd.Checked = False
                End If
                Me.txtEmgAddRatio.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("急件加成率").Value.ToString.Trim
                Me.txtDentalAddRatio.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("牙科轉診加成率").Value.ToString.Trim
                Me.txtDeptAddRatio.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("科別加成率").Value.ToString.Trim
                Me.txtKidAddRatio1.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("兒童加成率(未滿6個月)").Value.ToString.Trim
                Me.txtKidAddRatio2.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("兒童加成率(小於2歲)").Value.ToString.Trim
                Me.txtKidAddRatio3.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("兒童加成率(2歲-6歲)").Value.ToString.Trim
                Me.txtKidAddRatio4.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("兒童加成率(小於等於48個月)").Value.ToString.Trim
                Me.txtKidAddRatio5.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("兒童加成率(4歲以下)").Value.ToString.Trim
                Me.txtDeptCodeset.Text = dgvData.Rows(dgvData.CurrentCellAddress.Y).Cells("健保科別").Value.ToString.Trim

                'If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停用").Value.ToString.Trim = "否" Then
                '    Me.dtpEffectDate.SetValue(Now.ToString("yyyy/MM/dd"))
                '    Me.btnOK.Enabled = True
                'Else
                '    Me.dtpEffectDate.SetValue(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("生效日").Value.ToString)
                '    Me.btnOK.Enabled = False
                'End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 點選行資料,塞入輸入區
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub dgvCellClick2()
        Try
            '清除欄位資料
            cleanFieldsValue()
            '清除欄位背景顏色
            cleanFieldsColor()

            Me.dtEffectDate.SetValue(DateUtil.TransDateToWE(dgvData.Rows(0).Cells("生效日").Value.ToString.Trim))
            Me.dtEndDate.SetValue(DateUtil.TransDateToWE(dgvData.Rows(0).Cells("停止日").Value.ToString.Trim))
            Me.txtInsuCode.Text = dgvData.Rows(0).Cells("保健碼").Value.ToString.Trim
            Me.txtInsuEnName.Text = dgvData.Rows(0).Cells("英文名稱").Value.ToString.Trim
            Me.txtInsuName.Text = dgvData.Rows(0).Cells("中文名稱").Value.ToString.Trim
            Me.txtPrice.Text = dgvData.Rows(0).Cells("單價").Value.ToString.Trim
            'If dgvData.Rows(0).Cells("急診加成").Value.ToString.Trim.Equals("Y") Then
            '急診加成
            If (Me.dgvData.Rows(0).Cells(6).Value) Then
                Me.cbIsEmgAdd.Checked = True
            Else
                Me.cbIsEmgAdd.Checked = False
            End If
            '兒童加成
            If (dgvData.Rows(0).Cells(7).Value) Then
                Me.cbIsKidAdd.Checked = True
            Else
                Me.cbIsKidAdd.Checked = False
            End If
            '牙科轉診加成
            If (dgvData.Rows(0).Cells(8).Value) Then
                Me.cbIsDentalAdd.Checked = True
            Else
                Me.cbIsDentalAdd.Checked = False
            End If
            '  假日加成
            If (dgvData.Rows(0).Cells(9).Value) Then
                Me.cbIsHolidayAdd.Checked = True
            Else
                Me.cbIsHolidayAdd.Checked = False
            End If
            Me.cmbInsuAccountId.SelectedValue = dgvData.Rows(0).Cells("保險費用項目").Value.ToString.Trim.Split(" ")(0)
            Me.cmbInsuOrderTypeId.SelectedValue = dgvData.Rows(0).Cells("保險醫令類別").Value.ToString.Trim.Split(" ")(0)
            Me.cmbMajorcareCode.SelectedValue = dgvData.Rows(0).Cells("特定治療項目").Value.ToString.Trim.Split(" ")(0)
            '  檢查折扣(健保用)
            If (dgvData.Rows(0).Cells(14).Value) Then
                Me.chkIsLabdiscount.Checked = True
            Else
                Me.chkIsLabdiscount.Checked = False
            End If
            '  停用
            If (dgvData.Rows(0).Cells(15).Value).ToString.Trim = "否" Then
                Me.btn_OK.Enabled = True
            Else
                Me.btn_OK.Enabled = False
            End If
            '20110815 add by yunfei
            '科別是否加成
            If (dgvData.Rows(0).Cells(10).Value) Then
                Me.ckbIsDeptAdd.Checked = True
            Else
                Me.ckbIsDeptAdd.Checked = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "功能方法"
    ''' <summary>
    ''' 清除事件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub clearData()
        '清除欄位資料
        cleanFieldsValue()
        '清除欄位背景顏色
        cleanFieldsColor()
        '確定變可用
        Me.btn_OK.Enabled = True
        dgvData.ClearDS()
        'CType(dgvData.DataSource, DataTable).Clear()
        'dgvData.Refresh()
        Dim dataset As DataSet = genDS(DataSet_Type.Grid)
        'initialGridHead(dataset)
    End Sub
    ''' <summary>
    ''' 清除欄位資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsValue()
        Try
            'Me.dtEffectDate.SetValue(Now.ToString("yyyy/MM/dd"))
            Me.dtEndDate.Text = ""
            'Me.dtEffectDate.SetValue("")
            Me.dtEffectDate.Text = ""
            Me.cmbInsuAccountId.SelectedValue = ""
            Me.cmbInsuOrderTypeId.SelectedValue = ""
            Me.cmbMajorcareCode.SelectedValue = ""
            Me.txtInsuCode.Text = ""
            Me.txtInsuEnName.Text = ""
            Me.txtInsuName.Text = ""
            Me.txtPrice.Text = ""
            Me.cbIsDentalAdd.Checked = False
            Me.cbIsEmgAdd.Checked = False
            Me.cbIsHolidayAdd.Checked = False
            Me.cbIsKidAdd.Checked = False
            Me.chkIsLabdiscount.Checked = False
            '20110809 add by yunfei
            Me.ckbIsDeptAdd.Checked = False
            Me.txtEmgAddRatio.Text = ""
            Me.txtDentalAddRatio.Text = ""
            Me.txtDeptAddRatio.Text = ""
            Me.txtKidAddRatio1.Text = ""
            Me.txtKidAddRatio2.Text = ""
            Me.txtKidAddRatio3.Text = ""
            Me.txtKidAddRatio4.Text = ""
            Me.txtKidAddRatio5.Text = ""
            Me.txtDeptCodeset.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 產生一個DataSet並包含空的Table用於Grid更新或者DB操作
    ''' </summary>
    ''' <param name="type">資料集類型</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function genDS(ByVal type As Integer) As DataSet
        Dim dsTemp As New DataSet
        Select Case type
            Case DataSet_Type.Grid
                '給Grid用Table
                dsTemp.Tables.Add(strTableDB)
                For i As Integer = 0 To columnNameGrid.Length - 1
                    dsTemp.Tables(strTableDB).Columns.Add(columnNameGrid(i))
                Next
            Case DataSet_Type.DB
                '給DB用Table
                dsTemp.Tables.Add(strTableDB)
                For i As Integer = 0 To strColumnNameDB.Length - 1
                    dsTemp.Tables(strTableDB).Columns.Add(strColumnNameDB(i))
                Next
        End Select
        Return dsTemp
    End Function

    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.cmbInsuAccountId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbInsuOrderTypeId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbMajorcareCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.dtEffectDate.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.dtEndDate.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtInsuCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtInsuEnName.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtInsuName.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtPrice.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 欄位檢查
    ''' </summary>
    ''' <param name="iButtonFlag">BUTTON標記</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 失敗;False 成功</remarks>
    Private Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean
        Try
            Dim blnReturnFlag As Boolean = False
            Dim strErrMsg1 As StringBuilder = New StringBuilder
            Dim strErrMsg2 As StringBuilder = New StringBuilder
            Dim strErrMsg3 As StringBuilder = New StringBuilder
            Dim strErrMsg4 As StringBuilder = New StringBuilder
            '設定需要檢查的欄位
            Dim ctlEffectDate As Control = Me.dtEffectDate
            Dim ctlTxtInsuCode As Control = Me.txtInsuCode
            'Dim ctlEndDate As Control = Me.dtEndDate
            Dim ctlTxtInsuEnName As Control = Me.txtInsuEnName
            Dim ctlTxtInsuName As Control = Me.txtInsuName
            Dim ctlTxtPrice As Control = Me.txtPrice
            Dim ctlObjFocus As Control = ctlEffectDate
            '清除欄位背景色
            cleanFieldsColor()
            '針對確定按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.OK
                    If Not fieldCheckNull(ctlEffectDate, Control_Type.DateTimePicker) Then
                        strErrMsg1.Append("生效日")
                        ctlObjFocus = ctlEffectDate
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtInsuCode, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("健保碼")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtInsuCode
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtInsuEnName, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("英文名稱")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtInsuEnName
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtInsuName, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("中文名稱")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtInsuName
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtPrice, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("單價")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtPrice
                        End If
                        blnReturnFlag = True
                    End If
                    'If Me.txtPartRatio.Text.ToString.Trim <> "" And Me.txtPartAmt.Text.ToString.Trim <> "" Then
                    '    If Me.txtPartRatio.Text > 0 And Me.txtPartAmt.Text > 0 Then
                    '        strErrMsg4.Append("負擔比率與負擔金額只能同時存在一種 > 0，但允許皆為0!")
                    '        Me.txtPartRatio.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    '        Me.txtPartAmt.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    '        If blnReturnFlag = False Then
                    '            ctlObjFocus = Me.txtPartAmt
                    '        End If
                    '        blnReturnFlag = True
                    '    End If
                    'End If
                    If Not Me.dtEndDate.IsEmpty Then
                        If Me.dtEffectDate.GetUsDateStr > Me.dtEndDate.GetUsDateStr Then
                            strErrMsg2.Append("結束日" & "," & "生效日")
                            Me.dtEndDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            If blnReturnFlag = False Then
                                ctlObjFocus = Me.dtEndDate
                            End If
                            blnReturnFlag = True
                        End If
                    End If
                Case buttonAction.Down, buttonAction.Up
                    If Not fieldCheckNull(ctlEffectDate, Control_Type.DateTimePicker) Then
                        strErrMsg1.Append("生效日")
                        ctlObjFocus = ctlEffectDate
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtInsuCode, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("健保碼")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtInsuCode
                        End If
                        blnReturnFlag = True
                    End If
                Case buttonAction.Delete
                    If Not fieldCheckNull(ctlTxtInsuCode, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("健保碼")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtInsuCode
                        End If
                        blnReturnFlag = True
                    End If
            End Select

            '欄位check錯誤
            If blnReturnFlag Then
                Dim strMsgs(0) As String
                Dim i As Integer = 0
                If strErrMsg1.Length > 0 Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB101", New String() {strErrMsg1.ToString})
                    i += 1
                End If
                If (strErrMsg2.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB102", New String() {"結束日", "生效日"})
                    i += 1
                End If
                If (strErrMsg3.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = strErrMsg3.ToString + ResourceUtil.getString("CMMCMMB009")
                    i += 1
                End If
                'If (strErrMsg4.Length > 0) Then
                '    ReDim Preserve strMsgs(i)
                '    strMsgs(i) = ResourceUtil.getString("CMMCMMB204", New String() {strErrMsg4.ToString})
                '    i += 1
                'End If 
                Dim pvtErrorMsg As String = ""
                For i = 0 To strMsgs.Length - 1
                    If i <> 0 Then
                        pvtErrorMsg = pvtErrorMsg & vbCrLf & strMsgs(i)
                    Else
                        pvtErrorMsg = strMsgs(i)
                    End If
                Next
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {pvtErrorMsg}, "")
                ctlObjFocus.Focus()
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 檢查是否為空白
    ''' </summary>
    ''' <param name="ctl">控件</param>
    ''' <param name="ctType">控件類型</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 合法;False 非法</remarks>
    Private Function fieldCheckNull(ByVal ctl As Control, ByVal ctType As Integer) As Boolean
        Select Case ctType
            Case Control_Type.TextBox
                If ctl.Text.Trim.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.DateTimePicker
                Dim objCtl As Syscom.Client.UCL.UCLDateTimePickerUC = ctl
                If objCtl.GetUsDateStr.Equals("") Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
        End Select
    End Function

#Region "取得HashTable"

    Private Function GetHashTable(ByVal ds As DataSet) As Hashtable
        Dim ht As New Hashtable
        Try
            'Dim hCboUnCloseReason As New ComboBoxCell
            'Dim cboDs As New DataSet
            'Dim cboDt As New DataTable
            'cboDt.Columns.Add("Reason")
            'cboDt.Rows.Add("門診追蹤")
            'cboDt.Rows.Add("出服")
            'cboDt.Rows.Add("居家")
            'cboDs.Tables.Add(cboDt)
            'hCboUnCloseReason.Ds = cboDs.Copy
            'hCboUnCloseReason.DisplayIndex = "0"
            'hCboUnCloseReason.ValueIndex = 0
            ht.Add(-1, ds)
            'ht.Add(3, hCboUnCloseReason)
            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("組成Ht", ex)
        End Try
        Return ht
    End Function
#End Region
#End Region

#Region "20100929 增加上一筆、下一筆功能 add by liuye"
    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()
            If fieldCheckResult(buttonAction.Up) Then
                Return
            End If
            If (queryData(buttonAction.Up)) Then

                If (dgvData.CurrentRow IsNot Nothing AndAlso dgvData.CurrentRow.Index >= 0) Then
                    dgvData.CurrentRow.Selected = False
                    dgvData.CurrentCell = Nothing
                    If dgvData.Rows.Count > 0 Then
                        dgvCellClick2()
                        dgvData.Rows(0).Selected = True
                    End If
                End If
                MessageHandling.ShowInfoMsg("CMMCMMB001", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()
            If fieldCheckResult(buttonAction.Down) Then
                Return
            End If
            If (queryData(buttonAction.Down)) Then

                If (dgvData.CurrentRow IsNot Nothing AndAlso dgvData.CurrentRow.Index >= 0) Then
                    dgvData.CurrentRow.Selected = False
                    dgvData.CurrentCell = Nothing
                    If dgvData.Rows.Count > 0 Then
                        dgvCellClick2()
                        dgvData.Rows(0).Selected = True
                    End If
                End If
                MessageHandling.ShowInfoMsg("CMMCMMB001", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

#End Region
#Region "20100929 增加刪除功能(依健保碼刪除) add by liuye"
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageHandling.ShowQuestionMsg("CMMCMMB303", New String() {"刪除"}) <> Windows.Forms.DialogResult.Yes Then Return
            ScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()
            If (deleteDate()) Then
                MessageHandling.ShowInfoMsg("HEMCMMB004", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            Syscom.Client.CMM.ClientExceptionHandler.ProccessException(ex)
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    Function deleteDate() As Boolean
        Dim returnValue As Boolean = False
        Try
            If fieldCheckResult(buttonAction.Delete) Then
                Return False
            End If
            Dim strInsuCode As String = Me.txtInsuCode.Text.Trim
            Dim icount As Integer = objPub.deletePUBNhiCodeByInsuCode_L(strInsuCode)
            If icount > 0 Then
                returnValue = True
                Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
                Me.dgvData.Initial(dsGrid)
            Else
                Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
                Me.dgvData.Initial(dsGrid)
                MessageHandling.ShowWarnMsg("CMMCMMB011", New String() {})
                returnValue = False
            End If
            Return returnValue
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region



End Class