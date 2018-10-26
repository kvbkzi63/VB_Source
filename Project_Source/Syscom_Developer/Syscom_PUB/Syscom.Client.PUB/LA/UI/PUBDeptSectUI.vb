'/*
'*****************************************************************************
'*
'*    Page/Class Name:  部位檔維護
'*              Title:	PUBDeptSectUI
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-15
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-15
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
Imports Syscom.Comm.TableFactory


Public Class PUBDeptSectUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

    Dim objpub As IPubServiceManager = Nothing
    '目前使用者的ID
    'Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.getInstance.getFileLogger(Me)
    '獲取維護表名
    Dim tableDB As String = PubDeptSectDataTableFactory.tableName
    'Grid使用的標題
    Dim columnNameGrid() As String = {"科別代碼", "診別代碼", "診別名稱", "診別英文", "科診別名", "科診英文別名", "停用", "科診屬性", "建立者", "建立時間", "修改者", "修改時間"}
    '獲取維護表字段名
    Dim columnNameDB() As String = PubDeptSectDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubDeptSectDataTableFactory.columnsLength
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum

    '控件類型定義
    Enum Control_Type
        TextBox
    End Enum

    ''' <summary>
    ''' 產生一個空的DataSet
    ''' </summary>
    ''' <param name="type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function genDS(ByVal type As Integer) As DataSet
        Dim dsTemp As New DataSet
        Select Case type
            Case DataSet_Type.Grid
                '給Grid用Table()
                dsTemp.Tables.Add(tableDB)
                For i As Integer = 0 To columnNameGrid.Length - 1
                    dsTemp.Tables(tableDB).Columns.Add(columnNameGrid(i))
                Next
            Case DataSet_Type.DB
                '給DB用Table()
                dsTemp.Tables.Add(tableDB)
                For i As Integer = 0 To columnNameDB.Length - 1
                    dsTemp.Tables(tableDB).Columns.Add(columnNameDB(i))
                Next
        End Select
        Return dsTemp
    End Function

    Public Overrides Sub initialData()
        Try
            '初始化對象()
            objpub = PubServiceManager.getInstance
            '構建空的Grid()
            'dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(tableDB)
            showResult(dgvShowData, genDataSet("dgvShowData"))
            '設定Grid滿屏()
            'dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ''門診健保科別代碼和住院健保科別代碼
            'initialCmbHealthIpdDeptCode()
            'initialCmbHealthOpdDeptCode()

            Me.txtDeptCode.MaxLength = Me.columnsLength(0)
            Me.txtSectionId.MaxLength = Me.columnsLength(1)
            Me.txtSectionName.MaxLength = Me.columnsLength(2)
            Me.txtSectionEnName.MaxLength = Me.columnsLength(3)
            Me.txtDeptAliasName.MaxLength = Me.columnsLength(4)
            Me.txtDeptAliasEnName.MaxLength = Me.columnsLength(5)

            '2015/11/11 Eddie,Lu: 新增欄位"科診屬性"
            initialComboBox()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化 - ComboBox
    ''' </summary>
    ''' <remarks>by Eddie,Lu on 2015-10-29</remarks>
    Private Sub initialComboBox()

        Try

            '***********************************************************************************************************
            '視需要進行修改，如果一次要取得多個 ComboBox，請取一個DS 回來，內包含各個DataTable，不可呼叫WCF多次 ********
            '***********************************************************************************************************

            '取得 Combobox的 資料
            Dim cboDS As DataSet = objpub.PUBDeptSectqueryCboData(97)

            '檢查資料來源
            If CheckHasTable(cboDS, "97") Then

                '設定資料來源
                cboDeptSectKindId.Initial(cboDS.Tables("97"))
                cboDeptSectKindId.uclDisplayIndex = "0,1"

            End If

            '**********************************************************************************************************

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - ComboBox"})
        End Try

    End Sub

    ' ''' <summary>
    ' ''' 門診健保科別代碼
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Sub initialCmbHealthIpdDeptCode()
    '    Dim dsDB As DataSet
    '    '執行查詢()
    '    dsDB = objpub.queryPUBInsuDeptCodeAndName_L()
    '    Try
    '        If dsDB.Tables.Count > 0 Then
    '            If dsDB.Tables(0).Rows.Count = 0 Then
    '                ' '查無資料
    '                ' MessageHandling.showWarnByKey("CMMCMMB000")
    '            Else
    '                Me.cmbHealthIpdDeptCode.DataSource = dsDB.Tables(0)
    '                Me.cmbHealthIpdDeptCode.uclValueIndex = "0"
    '                Me.cmbHealthIpdDeptCode.uclDisplayIndex = "0,1"
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    ' ''' <summary>
    ' ''' 住院健保科別代碼
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Sub initialCmbHealthOpdDeptCode()
    '    Dim dsDB As DataSet
    '    '執行查詢()
    '    dsDB = objpub.queryPUBInsuDeptCodeAndName_L()
    '    Try
    '        If dsDB.Tables.Count > 0 Then
    '            If dsDB.Tables(0).Rows.Count = 0 Then
    '                ' '查無資料
    '                ' MessageHandling.showWarnByKey("CMMCMMB000")
    '            Else
    '                Me.cmbHealthOpd_DeptCode.DataSource = dsDB.Tables(0)
    '                Me.cmbHealthOpd_DeptCode.uclValueIndex = "0"
    '                Me.cmbHealthOpd_DeptCode.uclDisplayIndex = "0,1"
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub


    ''' <summary>
    ''' 查詢事件
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 查詢成功</remarks>
    Public Overrides Function queryData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.QUERY
        Dim blnReturnFlag As Boolean = True
        Dim dsDB As DataSet
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        Dim strTemp As String
        '欄位檢查()
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        '執行查詢()
        dsDB = objpub.queryPubDeptSectByCond_L(Me.txtDeptCode.Text.Trim, Me.txtSectionId.Text.Trim)
        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(tableDB).Rows.Count = 0 Then
                    '查無資料()
                    MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {})
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                Else
                    Dim drGrid(dsDB.Tables(tableDB).Rows.Count - 1) As DataRow
                    '將查出的資料塞入Grid中()
                    ' {"科別代碼", "診別代碼", "診別名稱", "診別英文", "科診別名", "科診英文別名", "門診健保科別代碼", "門診健保科別名稱", "住院健保科別代碼", "住院健保科別名稱", "停用", "建立者", "建立時間", "修改者", "修改時間"}
                    '2015/11/11 Eddie,Lu: 新增欄位 "科診屬性"
                    For i As Integer = 0 To dsDB.Tables(tableDB).Rows.Count - 1
                        drGrid(i) = dsGrid.Tables(tableDB).NewRow()
                        drGrid(i)("科別代碼") = dsDB.Tables(tableDB).Rows(i)("Dept_Code").ToString.Trim()
                        drGrid(i)("診別代碼") = dsDB.Tables(tableDB).Rows(i)("Section_Id").ToString.Trim()
                        drGrid(i)("診別名稱") = dsDB.Tables(tableDB).Rows(i)("Dept_Sect_Name").ToString.Trim()
                        drGrid(i)("診別英文") = dsDB.Tables(tableDB).Rows(i)("Dept_Sect_En_Name").ToString.Trim()
                        drGrid(i)("科診別名") = dsDB.Tables(tableDB).Rows(i)("Dept_Sect_Alias_Name").ToString.Trim()
                        drGrid(i)("科診英文別名") = dsDB.Tables(tableDB).Rows(i)("Dept_Sect_Alias_En_Name").ToString.Trim()
                        '20110705 add by yunfei
                        'drGrid(i)("門診健保科別代碼") = dsDB.Tables(tableDB).Rows(i)("Health_Opd_Dept_Code").ToString.Trim()
                        'drGrid(i)("門診健保科別名稱") = dsDB.Tables(tableDB).Rows(i)("Health_Opd_Dept_Name").ToString.Trim()
                        'drGrid(i)("住院健保科別代碼") = dsDB.Tables(tableDB).Rows(i)("Health_Ipd_Dept_Code").ToString.Trim()
                        'drGrid(i)("住院健保科別名稱") = dsDB.Tables(tableDB).Rows(i)("Health_Ipd_Dept_Name").ToString.Trim()

                        If (dsDB.Tables(tableDB).Rows(i)("DC").Equals("Y")) Then
                            drGrid(i)("停用") = "是"
                        Else
                            drGrid(i)("停用") = "否"
                        End If
                        '2015/11/11 Eddie,Lu: 新增欄位 "科診屬性"
                        drGrid(i)("科診屬性") = dsDB.Tables(tableDB).Rows(i)("Dept_Sect_Kind_Id").ToString.Trim()

                        drGrid(i)("建立者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_User"))
                        If StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_Time")) <> "" Then
                            drGrid(i)("建立時間") = CDate(StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_Time"))).Year - 1911 & CDate(StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Create_Time"))).ToString("/MM/dd HH:mm:ss")
                        End If
                        drGrid(i)("修改者") = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Modified_User"))
                        strTemp = StringUtil.nvl(dsDB.Tables(tableDB).Rows(i)("Modified_Time"))
                        If strTemp <> "" Then
                            drGrid(i)("修改時間") = CDate(strTemp).Year - 1911 & CDate(strTemp).ToString("/MM/dd HH:mm:ss")
                        End If
                        dsGrid.Tables(tableDB).Rows.Add(drGrid(i))
                    Next
                    '資料邦定到Grid()
                    'dgvShowData.DataSource = dsGrid.Tables(tableDB)
                    showResult(dgvShowData, dsGrid)
                End If
                Return blnReturnFlag
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 新增事件
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 新增成功</remarks>
    Public Overrides Function insertData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.INSERT
        Dim blnReturnFlag As Boolean = True

        '欄位檢查()
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        Try
            Dim iCount As Integer = 0
            Dim dsDB As DataSet = genDS(DataSet_Type.DB)
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
            Dim drGrid As DataRow = dsGrid.Tables(tableDB).NewRow()
            Dim drDB As DataRow = dsDB.Tables(tableDB).NewRow()
            '將輸入區資料塞入DB中()
            drDB("Dept_Code") = Me.txtDeptCode.Text.Trim
            drDB("Section_Id") = Me.txtSectionId.Text.Trim
            drDB("Dept_Sect_Name") = Me.txtSectionName.Text.Trim
            drDB("Dept_Sect_En_Name") = Me.txtSectionEnName.Text.Trim
            drDB("Dept_Sect_Alias_Name") = Me.txtDeptAliasName.Text.Trim
            drDB("Dept_Sect_Alias_En_Name") = Me.txtDeptAliasEnName.Text.Trim
            '20110705 add by yunfei
            'drDB("Health_Opd_Dept_Code") = Me.cmbHealthOpd_DeptCode.SelectedValue.Trim
            'drDB("Health_Ipd_Dept_Code") = Me.cmbHealthIpdDeptCode.SelectedValue.Trim
            If (Me.chkDC.Checked = True) Then
                drDB("DC") = "Y"
            Else
                drDB("DC") = "N"
            End If

            '2015/11/11 Eddie,Lu: 新增欄位 "科診屬性"
            drDB("Dept_Sect_Kind_Id") = Me.cboDeptSectKindId.SelectedValue

            If (currentUserID.Trim.Equals("")) Then
                currentUserID = "pubuser"
            End If
            drDB("Create_User") = currentUserID
            drDB("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = drDB("Create_Time")
            dsDB.Tables(tableDB).Rows.Add(drDB)
            '執行新增()
            iCount = objpub.insertPubDeptSect_L(dsDB)
            If iCount > 0 Then
                ' {"科別代碼", "診別代碼", "診別名稱", "診別英文", "科診別名", "科診英文別名", "門診健保科別代碼", "門診健保科別名稱", "住院健保科別代碼", "住院健保科別名稱", "停用", "建立者", "建立時間", "修改者", "修改時間"}
                drGrid("科別代碼") = dsDB.Tables(tableDB).Rows(0)("Dept_Code").ToString.Trim()
                drGrid("診別代碼") = dsDB.Tables(tableDB).Rows(0)("Section_Id").ToString.Trim()
                drGrid("診別名稱") = dsDB.Tables(tableDB).Rows(0)("Dept_Sect_Name").ToString.Trim()
                drGrid("診別英文") = dsDB.Tables(tableDB).Rows(0)("Dept_Sect_En_Name").ToString.Trim()
                drGrid("科診別名") = dsDB.Tables(tableDB).Rows(0)("Dept_Sect_Alias_Name").ToString.Trim()
                drGrid("科診英文別名") = dsDB.Tables(tableDB).Rows(0)("Dept_Sect_Alias_En_Name").ToString.Trim()

                '20110705 add by yunfei
                'drGrid("門診健保科別代碼") = dsDB.Tables(tableDB).Rows(0)("Health_Opd_Dept_Code").ToString.Trim()
                'drGrid("門診健保科別名稱") = IIf(Me.cmbHealthOpd_DeptCode.SelectedValue.Trim <> "", Me.cmbHealthOpd_DeptCode.SelectedItem(1).ToString.Trim, "")
                'drGrid("住院健保科別代碼") = dsDB.Tables(tableDB).Rows(0)("Health_Ipd_Dept_Code").ToString.Trim()
                'drGrid("住院健保科別名稱") = IIf(Me.cmbHealthIpdDeptCode.SelectedValue.Trim <> "", Me.cmbHealthIpdDeptCode.SelectedItem(1).ToString.Trim, "")

                If (dsDB.Tables(tableDB).Rows(0)("DC").Equals("Y")) Then
                    drGrid("停用") = "是"
                Else
                    drGrid("停用") = "否"
                End If
                '2015/11/11 Eddie,Lu: 新增欄位 "科診屬性"
                drGrid("科診屬性") = dsDB.Tables(tableDB).Rows(0)("Dept_Sect_Kind_Id").ToString.Trim()

                drGrid("建立者") = dsDB.Tables(tableDB).Rows(0)("Create_User").ToString.Trim
                drGrid("建立時間") = dsDB.Tables(tableDB).Rows(0)("Create_Time").ToString.Trim
                drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim
                drGrid("修改時間") = dsDB.Tables(tableDB).Rows(0)("Modified_Time").ToString.Trim
                dsGrid.Tables(tableDB).Rows.Add(drGrid)
                '同步更新()
                updateDataGridView(iButtonFlag, dsGrid)
            Else
                blnReturnFlag = False
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 修改事件
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 修改成功</remarks>
    Public Overrides Function updateData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.UPDATE
        Dim blnReturnFlag As Boolean = True

        '欄位檢查()
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        Try
            Dim iCount As Integer = 0
            Dim dsDB As DataSet = genDS(DataSet_Type.DB)
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
            Dim drGrid As DataRow = dsGrid.Tables(tableDB).NewRow()
            Dim drDB As DataRow = dsDB.Tables(tableDB).NewRow()
            '將輸入區資料塞入DB中()
            drDB("Dept_Code") = Me.txtDeptCode.Text.Trim
            drDB("Section_Id") = Me.txtSectionId.Text.Trim
            drDB("Dept_Sect_Name") = Me.txtSectionName.Text.Trim
            drDB("Dept_Sect_En_Name") = Me.txtSectionEnName.Text.Trim
            drDB("Dept_Sect_Alias_Name") = Me.txtDeptAliasName.Text.Trim
            drDB("Dept_Sect_Alias_En_Name") = Me.txtDeptAliasEnName.Text.Trim
            '20110705 add by yunfei
            'drDB("Health_Opd_Dept_Code") = Me.cmbHealthOpd_DeptCode.SelectedValue.Trim
            'drDB("Health_Ipd_Dept_Code") = Me.cmbHealthIpdDeptCode.SelectedValue.Trim
            If (Me.chkDC.Checked = True) Then
                drDB("DC") = "Y"
            Else
                drDB("DC") = "N"
            End If

            '2015/11/11 Eddie,Lu: 新增欄位 "科診屬性"
            drDB("Dept_Sect_Kind_Id") = Me.cboDeptSectKindId.SelectedValue

            drDB("Create_User") = Nothing
            drDB("Create_Time") = Nothing
            If (currentUserID.Trim.Equals("")) Then
                currentUserID = "pubuser"
            End If
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            dsDB.Tables(tableDB).Rows.Add(drDB)
            '執行修改()
            iCount = objpub.updatePubDeptSectByCond_L(dsDB)
            If iCount > 0 Then
                '將DB資料塞入Grid中()
                ' {"科別代碼", "診別代碼", "診別名稱", "診別英文", "科診別名", "科診英文別名", "門診健保科別代碼", "門診健保科別名稱", "住院健保科別代碼", "住院健保科別名稱", "停用", "建立者", "建立時間", "修改者", "修改時間"}
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0)
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("科別代碼"), dtGrid.Columns("診別代碼")}
                If dtGrid.Rows.Contains(New Object() {Me.txtDeptCode.Text.Trim, Me.txtSectionId.Text.Trim}) Then
                    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.txtDeptCode.Text.Trim, Me.txtSectionId.Text.Trim})
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                    drGrid("科別代碼") = dsDB.Tables(tableDB).Rows(0)("Dept_Code").ToString.Trim()
                    drGrid("診別代碼") = dsDB.Tables(tableDB).Rows(0)("Section_Id").ToString.Trim()
                    drGrid("診別名稱") = dsDB.Tables(tableDB).Rows(0)("Dept_Sect_Name").ToString.Trim()
                    drGrid("診別英文") = dsDB.Tables(tableDB).Rows(0)("Dept_Sect_En_Name").ToString.Trim()
                    drGrid("科診別名") = dsDB.Tables(tableDB).Rows(0)("Dept_Sect_Alias_Name").ToString.Trim()
                    drGrid("科診英文別名") = dsDB.Tables(tableDB).Rows(0)("Dept_Sect_Alias_En_Name").ToString.Trim()
                    '20110705 add by yunfei
                    'drGrid("門診健保科別代碼") = dsDB.Tables(tableDB).Rows(0)("Health_Opd_Dept_Code").ToString.Trim()
                    'drGrid("門診健保科別名稱") = IIf(Me.cmbHealthOpd_DeptCode.SelectedValue.Trim <> "", Me.cmbHealthOpd_DeptCode.SelectedItem(1).ToString.Trim, "")
                    'drGrid("住院健保科別代碼") = dsDB.Tables(tableDB).Rows(0)("Health_Ipd_Dept_Code").ToString.Trim()
                    'drGrid("住院健保科別名稱") = IIf(Me.cmbHealthIpdDeptCode.SelectedValue.Trim <> "", Me.cmbHealthIpdDeptCode.SelectedItem(1).ToString.Trim, "")

                    If (dsDB.Tables(tableDB).Rows(0)("DC").Equals("Y")) Then
                        drGrid("停用") = "是"
                    Else
                        drGrid("停用") = "否"
                    End If
                    '2015/11/11 Eddie,Lu: 新增欄位 "科診屬性"
                    drGrid("科診屬性") = dsDB.Tables(tableDB).Rows(0)("Dept_Sect_Kind_Id").ToString.Trim()

                    drGrid("建立者") = drGrid2("建立者")
                    drGrid("建立時間") = drGrid2("建立時間")
                    drGrid("修改者") = dsDB.Tables(tableDB).Rows(0)("Modified_User").ToString.Trim()
                    drGrid("修改時間") = dsDB.Tables(tableDB).Rows(0)("Modified_Time").ToString.Trim
                    dsGrid.Tables(tableDB).Rows.Add(drGrid)
                    '同步更新()
                    updateDataGridView(iButtonFlag, dsGrid)
                End If
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB010", New String() {})
                'MessageHandling.showWarnByKey("CMMCMMB010")
                blnReturnFlag = False
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 刪除事件
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 刪除成功</remarks>
    Public Overrides Function deleteData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.DELETE
        Dim blnReturnFlag As Boolean = True
        '欄位檢查()
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        Try
            Dim iCount As Integer = 0
            '執行刪除()
            iCount = objpub.deletePubDeptSectByPK_L(Me.txtDeptCode.Text, Me.txtSectionId.Text)
            If iCount > 0 Then
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0)
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("科別代碼"), dtGrid.Columns("診別代碼")}
                If dtGrid.Rows.Contains(New Object() {Me.txtDeptCode.Text.Trim, Me.txtSectionId.Text.Trim}) Then
                    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drDrid As DataRow = dtGrid.Rows.Find(New Object() {Me.txtDeptCode.Text.Trim, Me.txtSectionId.Text.Trim})
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drDrid)
                End If
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB011", New String() {})
                'MessageHandling.showWarnByKey("CMMCMMB011")
                blnReturnFlag = False
            End If
            '清除欄位背景色()
            cleanFieldsColor()
            '清除欄位資料()
            cleanFieldsValue()
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 欄位檢查
    ''' </summary>
    ''' <param name="iButtonFlag">BUTTON標記</param>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 檢查不通過;False 檢查通過</remarks>
    Private Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean
        Try
            Dim blnReturnFlag As Boolean = False
            Dim strErrMsg1 As StringBuilder = New StringBuilder
            '設定需要檢查的欄位()
            Dim ctltxtDeptCode As Control = Me.txtDeptCode
            Dim ctltxtSectionId As Control = Me.txtSectionId
            Dim ctlObjFocus As Control = ctltxtDeptCode
            '清除欄位背景色()
            cleanFieldsColor()
            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE, buttonAction.DELETE
                    If Not fieldCheckNull(ctltxtDeptCode, Control_Type.TextBox) Then
                        strErrMsg1.Append("科別代碼")
                        ctlObjFocus = ctltxtDeptCode
                        blnReturnFlag = True
                    End If

                    If Not fieldCheckNull(ctltxtSectionId, Control_Type.TextBox) Then
                        strErrMsg1.Append("診別代碼")
                        ctlObjFocus = ctltxtSectionId
                        blnReturnFlag = True
                    End If
            End Select
            '欄位check錯誤()
            If blnReturnFlag Then
                Dim strMsgs(0) As String
                Dim i As Integer = 0
                If strErrMsg1.Length > 0 Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB101", New String() {strErrMsg1.ToString})
                    i += 1
                End If
                Dim pvtErrorMsg As String = ""
                For i = 0 To strMsgs.Length - 1
                    If i <> 0 Then
                        pvtErrorMsg = pvtErrorMsg & vbCrLf & strMsgs(i)
                    Else
                        pvtErrorMsg = strMsgs(i)
                    End If
                Next
                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {pvtErrorMsg}, "")
                'MessageHandling.showErrors(strMsgs)
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
        End Select
    End Function

    ''' <summary>
    ''' 清除事件
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub clearData()
        '清除欄位資料()
        cleanFieldsValue()
        '清除欄位背景顏色()
        cleanFieldsColor()
        dgvShowData.ClearDS()
        dgvShowData.Refresh()
    End Sub

    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.txtDeptCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtSectionId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 清除欄位資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsValue()
        Try
            Me.txtDeptCode.Text = ""
            Me.txtSectionId.Text = ""
            Me.txtSectionName.Text = ""
            Me.txtSectionEnName.Text = ""
            Me.txtDeptAliasName.Text = ""
            Me.txtDeptAliasEnName.Text = ""
            Me.chkDC.Checked = False
            '2015/11/11 Eddie,Lu: 新增欄位 "科診屬性"
            Me.cboDeptSectKindId.SelectedValue = ""
            'Me.cmbHealthIpdDeptCode.SelectedValue = ""
            'Me.cmbHealthOpd_DeptCode.SelectedValue = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 點選行資料,塞入輸入區
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub dgvCellClick()
        Try
            '清除欄位背景顏色()
            cleanFieldsColor()
            If dgvShowData.CurrentCellAddress.Y >= 0 Then
                ' {"科別代碼", "診別代碼", "診別名稱", "診別英文", "科診別名", "科診英文別名", "門診健保科別代碼", "門診健保科別名稱", "住院健保科別代碼", "住院健保科別名稱", "停用", "建立者", "建立時間", "修改者", "修改時間"}
                Me.txtDeptCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("科別代碼").Value
                Me.txtSectionId.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("診別代碼").Value
                Me.txtSectionName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("診別名稱").Value
                Me.txtSectionEnName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("診別英文").Value
                Me.txtDeptAliasName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("科診別名").Value
                Me.txtDeptAliasEnName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("科診英文別名").Value
                '20110705 add by yunfei
                'Me.cmbHealthOpd_DeptCode.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("門診健保科別代碼").Value
                'Me.cmbHealthOpd_DeptCode.Text = IIf(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("門診健保科別代碼").Value.ToString.Trim <> "", dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("門診健保科別代碼").Value.ToString.Trim + " - " + _
                '                                dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("門診健保科別名稱").Value.ToString.Trim, "")
                'Me.cmbHealthIpdDeptCode.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("住院健保科別代碼").Value
                'Me.cmbHealthIpdDeptCode.Text = IIf(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("住院健保科別代碼").Value.ToString.Trim <> "", dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("住院健保科別代碼").Value.ToString.Trim + " - " + _
                '                               dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("住院健保科別名稱").Value.ToString.Trim, "")

                If (dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停用").Value) = "是" Then
                    chkDC.Checked = True
                Else
                    chkDC.Checked = False
                End If
                '2015/11/11 Eddie,Lu: 新增欄位 "科診屬性"
                cboDeptSectKindId.SelectedIndex = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("科診屬性").Value
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 同步更新DataGridView中的值
    ''' </summary>
    ''' <param name="mode">BUTTON類型</param>
    ''' <param name="ds">更新數據集</param>
    ''' <remarks></remarks>
    Private Overloads Sub updateDataGridView(ByVal mode As Integer, ByVal ds As DataSet)
        Select Case mode
            Case buttonAction.INSERT
                dgvShowData.GetGridDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
                dgvShowData.GetDBDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
            Case buttonAction.UPDATE
                dgvShowData.CurrentRow.SetValues(ds.Tables(tableDB).Rows(0).ItemArray)
        End Select
    End Sub

#Region "### 顯示資料(DataGridView) ###"

    ''' <summary>
    ''' 取得欄位顯示的欄位資料
    ''' </summary>
    ''' <param name="dgvName">DataGridView的Name</param>
    ''' <remarks></remarks>
    Private Function getColumnData(ByVal dgvName As String) As String(,)
        'Array元素Index的對照：Grid欄位顯示名稱、資料庫欄位名稱、顯示與否、(日期欄位D,DT、金額M、數值NO)與否、顯示欄位的長度
        Select Case dgvName
            Case "dgvShowData"
                '{"科別代碼", "科別名稱", "科別英文", "上層科室", "生效起日", "迄日", "簡稱",  "班表使用科別", "停用", "建立者", "建立時間", "修改者", "修改時間"}

                Return New String(,) {{"科別代碼", "科別代碼", "Y", "N", ""}, _
                                      {"科別名稱", "科別名稱", "Y", "N", ""}, _
                                      {"科別英文", "科別英文", "Y", "N", ""}, _
                                      {"上層科室", "上層科室", "Y", "N", ""}, _
                                      {"生效起日", "生效起日", "Y", "N", ""}, _
                                      {"迄日", "迄日", "Y", "N", ""}, _
                                      {"簡稱", "簡稱", "Y", "N", ""}, _
                                      {"班表使用科別", "班表使用科別", "Y", "N", ""}, _
                                      {"停用", "停用", "Y", "N", ""}, _
                                      {"建立者", "建立者", "Y", "N", ""}, _
                                      {"建立時間", "建立時間", "Y", "N", ""}, _
                                      {"修改者", "修改者", "Y", "N", ""}, _
                                      {"修改時間", "修改時間", "Y", "N", ""}}

        End Select
        Return Nothing
    End Function

    ''' <summary>
    ''' 顯示最新的資料在DataGridView
    ''' </summary>
    ''' <param name="ds">欲顯示的資料</param>
    ''' <remarks></remarks>
    Private Sub showResult(ByRef dgv As UCLDataGridViewUC, ByVal ds As DataSet)
        Try
            Dim headerTxtStr As String = ""
            Dim Visible As String = ""
            Dim hashTable As New Hashtable()

            Dim clnObj(,) As String = getColumnData(dgv.Name)
            For num As Integer = 0 To clnObj.GetUpperBound(0)
                If headerTxtStr.Length > 0 Then
                    headerTxtStr += ","
                End If
                headerTxtStr += clnObj(num, 0)
            Next
            '設定不被顯示的欄位
            For num As Integer = 0 To clnObj.GetUpperBound(0)
                If clnObj(num, 2) = "N" Then
                    Visible += num & ","
                End If
            Next
            If Visible.Length > 0 Then
                Visible = Visible.Substring(0, Visible.Length - 1)
            End If
            hashTable.Add(-1, ds)
            dgv.uclNonVisibleColIndex = Visible
            dgv.uclHeaderText = headerTxtStr
            dgv.uclNonVisibleColIndex = Visible
            dgv.Initial(hashTable)
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '----------------------------------------------------------------------------
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.ShowErrorMsg("CMMCMMB013", New String() {}, "")
        End Try
    End Sub


    ''' <summary>
    ''' 利用ColumnData的資料產生一個Data Set且包含一個空的Table
    ''' </summary>
    ''' <param name="dgvName">欲顯示資料的DataGridView名稱</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function genDataSet(ByVal dgvName As String) As DataSet
        '----------------------------------------------------------------------------
        '#Step1.取得欄位顯示的欄位資料
        '----------------------------------------------------------------------------
        Dim columnNameMap As String(,) = getColumnData(dgvName)
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        '#Step2.回傳Data Set
        '----------------------------------------------------------------------------
        Using dt As New DataTable("dataDT")

            For iIndex As Integer = 0 To columnNameMap.GetUpperBound(0)
                dt.Columns.Add(columnNameMap(iIndex, 1))
            Next

            Using ds As New DataSet
                ds.Tables.Add(dt.Copy)

                Return ds
            End Using
        End Using
        '----------------------------------------------------------------------------
    End Function


    ''' <summary>
    ''' 設定DataGridView的顯示欄位
    ''' </summary>
    ''' <param name="uclDgv"></param>
    ''' <remarks></remarks>
    Private Sub setDataGridViewVisibleColumnAndColumnWidth(ByVal uclDgv As UCLDataGridViewUC)

        Dim clnWidthStr As String = ""

        Dim clnObj(,) As String = getColumnData(uclDgv.Name)
        For num As Integer = 0 To clnObj.GetUpperBound(0)
            If clnWidthStr.Length > 0 Then
                clnWidthStr += ","
            End If

            If clnObj(num, 4).Length.Equals(0) Then
                clnWidthStr += "1"
            Else
                clnWidthStr += clnObj(num, 4)
            End If
        Next
        uclDgv.uclColumnWidth = clnWidthStr

    End Sub

#End Region
End Class