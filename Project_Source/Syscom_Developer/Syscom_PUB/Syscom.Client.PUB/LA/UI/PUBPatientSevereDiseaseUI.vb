'/*
'*****************************************************************************
'*
'*    Page/Class Name:  病患重大傷病記錄檔
'*              Title:	PUBPatientSevereDiseaseUI
'*        Description:	病患重大傷病記錄檔-增刪改查查
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-14
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-14
'*
'*****************************************************************************
'*/

Imports System.Text

Imports Syscom.Client.CMM
Imports Syscom.Client.UCL.UCLScreenUtil
Imports Syscom.Client.UCL

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Comm.Utility.DataSetUtil
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility
Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.TableFactory

'請修改成 TableFactory 所在的Utility
'Imports NIS.Comm.TableFactory

'請修改成使用到的Servicefactory
'Imports NIS.Client.ServiceFactory


Public Class PUBPatientSevereDiseaseUI
    Inherits IUCLMaintainFormUI


    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance
    Dim objPub As IPubServiceManager = Nothing
    '目前使用者的ID
    'Dim currentUserID As String = AppContext.userProfile.userId
    'Dim log As ILog = LOGDelegate.getInstance.getFileLogger(Me)
    '獲取維護表名
    Dim tableDB As String = PubPatientSevereDiseaseDataTableFactory.tableName
    'Grid使用的標題
    Dim columnNameGrid() As String = {"病歷號", "身份證號", "姓名", "生效日", "ICD_Code", "診斷英文名", "診斷中文名", "證明文號", "結束日", "Is_From_IcCard(代碼)", "Is_From_IcCard", "建立者", "建立時間"}
    '獲取維護表字段名
    Dim columnNameDB() As String = PubPatientSevereDiseaseDataTableFactory.columnsName
    '獲取維護表字段長度
    Dim columnsLength() As Integer = PubPatientSevereDiseaseDataTableFactory.columnsLength

    Dim CurrentIcdCode As String = ""

    Const MAXDATE As String = "9998/12/31"
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum

    '控件類型定義
    Enum Control_Type
        TextBox
        DateTimePicker
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
                '給Grid用Table
                dsTemp.Tables.Add(tableDB)
                For i As Integer = 0 To columnNameGrid.Length - 1
                    dsTemp.Tables(tableDB).Columns.Add(columnNameGrid(i))
                Next
            Case DataSet_Type.DB
                '給DB用Table
                dsTemp.Tables.Add(tableDB)
                For i As Integer = 0 To columnNameDB.Length - 1
                    dsTemp.Tables(tableDB).Columns.Add(columnNameDB(i))
                Next
        End Select
        Return dsTemp
    End Function

    ''' <summary>
    ''' 初始化畫面 構建空的Grid 設定欄位長度
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance

            '構建空的Grid
            'Mark By Will dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(tableDB)
            ''showResult(dgvShowData, genDataSet("dgvShowData"))

            '設定Grid滿屏
            'dgvShowData.MultiSelect = True
            'dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ''dgvShowData.Columns(3).FillWeight = 350
            '**2014-04-15 add by 長禎 - DobuleClick dgvShowData 帶出該筆資料的異動紀錄
            'Mark By Will AddHandler dgvShowData.CellDoubleClick, AddressOf DataGridView_CellDoubleClick
            '&&2014-04-15 add by 長禎 - DobuleClick dgvShowData 帶出該筆資料的異動紀錄

            '設定欄位長度
            ''Me.txtCertificateSn.MaxLength = columnsLength(3)

            '顯示空的Dataset 在　Grid 上
            '建立空的DataSet
            Dim gblEmptyDT As DataSet = genDS(DataSet_Type.DB)
            '取得欄位名稱
            '{"病歷號", "身份證號", "姓名", "生效日", "ICD_Code", "診斷英文名", "證明文號", "結束日", "Is_From_IcCard(代碼)", "Is_From_IcCard", "建立者", "建立時間"}
            Dim columnName() As String = {"病歷號", "身份證號", "姓名", "生效日", "ICD_Code", "診斷英文名", "診斷中文名", "證明文號", "結束日", "Is_From_IcCard(代碼)", "Is_From_IcCard", "建立者", "建立時間"}
            Dim columnTextDgv As String = columnName(0)
            For i = 1 To columnName.GetLength(0) - 1 Step +1
                columnTextDgv += "," & columnName(i)
            Next

            '建立空的DataSet(初始化欄位用)
            Dim strTemp As String = "Chart_No,Idno,Patient_Name,Effect_Date,Icd_Code,Disease_En_Name,Disease_Name,Certificate_Sn,End_Date,Is_Form_Iccard,Is_Form_Iccard_Name,Create_User,Create_Time"
            Dim tableColumnName() As String = strTemp.Split(",")
            Dim emptyDT As DataTable = DataSetUtil.GenDataTable(tableColumnName)

            '欄位長度
            Dim columnWidthDgv As String = "80,100,80,100,80,150,150,80,100,0,50,70,100"
            '欲顯示的欄位索引
            Dim columnVisibleDgv As String = "0,1,2,3,4,5,6,7,8,10,11,12"

            UCLScreenUtil.ShowDgv(dgvShowData, emptyDT, columnTextDgv, columnWidthDgv, columnVisibleDgv, False)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 查詢事件
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 查詢成功</remarks>
    Public Overrides Function queryData() As Boolean
        'Dim iButtonFlag As Integer = buttonAction.QUERY
        'Dim blnReturnFlag As Boolean = True
        'Dim dsDB As DataSet = genDS(DataSet_Type.DB)
        'Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        'Dim dateEffectDate As Date

        ''欄位檢查
        'If fieldCheckResult(iButtonFlag) Then
        '    Return False
        'End If
        'Dim strChkIsFromIcCard As String
        'If (Me.chkIsFromIcCard.Checked) Then
        '    strChkIsFromIcCard = "Y"
        'Else
        '    strChkIsFromIcCard = "N"
        'End If
        'If dtpEffectDate.IsEmpty Then
        '    dateEffectDate = System.DateTime.MinValue
        'Else
        '    dateEffectDate = CDate(dtpEffectDate.GetUsDateStr)
        'End If
        ''執行查詢
        ''dsDB = objPub.queryPUBPatientSevereDiseaseByCond_L(Me.txtChartNo.Text.ToString.Trim, Me.txtIcdCode.Text.ToString.Trim, dateEffectDate)
        'dsDB = objPub.PUBPatientSevereDiseasequeryByPKYNShow(Me.txtChartNo.Text.ToString.Trim)
        'Try
        '    If dsDB.Tables.Count > 0 Then
        '        If dsDB.Tables(tableDB).Rows.Count = 0 Then
        '            '查無資料
        '            MessageHandling.ShowWarnMsg("CMMCMMB000", New String() {})
        '            dgvShowData.ClearDS()
        '            dgvShowData.Refresh()
        '        Else
        '            Dim drGrid(dsDB.Tables(tableDB).Rows.Count - 1) As DataRow
        '            '將查出的資料塞入Grid中
        '            For i As Integer = 0 To dsDB.Tables(tableDB).Rows.Count - 1
        '                drGrid(i) = dsGrid.Tables(tableDB).NewRow()
        '                drGrid(i)("病歷號") = dsDB.Tables(tableDB).Rows(i)("Chart_No").ToString().Trim
        '                drGrid(i)("身份證號") = dsDB.Tables(tableDB).Rows(i)("Idno").ToString().Trim
        '                drGrid(i)("姓名") = dsDB.Tables(tableDB).Rows(i)("Patient_Name").ToString().Trim
        '                drGrid(i)("ICD_Code") = dsDB.Tables(tableDB).Rows(i)("Icd_Code").ToString().Trim
        '                drGrid(i)("診斷英文名") = dsDB.Tables(tableDB).Rows(i)("Disease_En_Name").ToString().Trim
        '                drGrid(i)("生效日") = CDate(dsDB.Tables(tableDB).Rows(i)("Effect_Date")).ToString("yyyy/MM/dd")
        '                drGrid(i)("證明文號") = dsDB.Tables(tableDB).Rows(i)("Certificate_Sn").ToString().Trim
        '                drGrid(i)("結束日") = CDate(dsDB.Tables(tableDB).Rows(i)("End_Date")).ToString("yyyy/MM/dd")
        '                If dsDB.Tables(tableDB).Rows(i)("Is_From_Iccard").ToString() = "Y" Then
        '                    drGrid(i)("Is_From_Iccard") = "是"
        '                Else
        '                    drGrid(i)("Is_From_Iccard") = "否"
        '                End If
        '                drGrid(i)("建立者") = dsDB.Tables(tableDB).Rows(i)("Create_User").ToString().Trim
        '                If dsDB.Tables(tableDB).Rows(i)("Create_Time").ToString <> "" Then
        '                    drGrid(i)("建立時間") = CDate(dsDB.Tables(tableDB).Rows(i)("Create_Time")).ToString("yyyy/MM/dd HH:mm:ss").Trim
        '                End If
        '                dsGrid.Tables(tableDB).Rows.Add(drGrid(i))

        '                '將身分證字號及姓名在查詢的同時填入上方欄位
        '                Me.txtIdNo.Text = dsDB.Tables(tableDB).Rows(i)("Idno").ToString().Trim
        '                Me.txtPatientName.Text = dsDB.Tables(tableDB).Rows(i)("Patient_Name").ToString().Trim

        '            Next
        '            '資料邦定到Grid
        '            'Mark By Will dgvShowData.DataSource = dsGrid.Tables(tableDB)
        '            showResult(dgvShowData, dsGrid)
        '        End If
        '        '清除欄位背景色
        '        cleanFieldsColor()
        '        Return blnReturnFlag
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try

        '2016/12/13 by Michelle 更改ICD_Code元件為TextBox

        Dim returnBoolean As Boolean

        Dim iButtonFlag As Integer = buttonAction.QUERY

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '查詢成功後儲存的 DS
            Dim queryDS As DataSet

            '取得欄位名稱
            '{"病歷號", "身份證號", "姓名", "生效日", "ICD_Code", "診斷英文名", "證明文號", "結束日", "Is_From_IcCard(代碼)", "Is_From_IcCard", "建立者", "建立時間"}
            Dim columnName() As String = {"病歷號", "身份證號", "姓名", "生效日", "ICD_Code", "診斷英文名", "診斷中文名", "證明文號", "結束日", "Is_From_IcCard(代碼)", "Is_From_IcCard", "建立者", "建立時間"}
            Dim columnTextDgv As String = columnName(0)
            For i = 1 To columnName.GetLength(0) - 1 Step +1
                columnTextDgv += "," & columnName(i)
            Next

            ''建立空的DataSet(初始化欄位用)
            'Dim strTemp As String = "Chart_No,Idno,Patient_Name,Effect_Date,Icd_Code,Disease_En_Name,Certificate_Sn,End_Date,Is_Form_Iccard,Is_Form_Iccard_Name,Create_User,Create_Time"
            'Dim tableColumnName() As String = strTemp.Split(",")
            'Dim emptyDT As DataTable = DataSetUtil.GenDataTable(tableColumnName)

            '欄位長度
            Dim columnWidthDgv As String = "80,100,80,100,80,150,150,80,100,0,50,70,100"
            '欲顯示的欄位索引
            Dim columnVisibleDgv As String = "0,1,2,3,4,5,6,7,8,10,11,12"

            '查詢 
            If dtpEffectDate.GetUsDateStr() = "" Then
                queryDS = objPub.PUBPatientSevereDiseasequeryByPKYNShow(txtChartNo.Text.ToString.Trim, txtIcdCode.Text.ToString.Trim, Nothing)
            Else
                queryDS = objPub.PUBPatientSevereDiseasequeryByPKYNShow(txtChartNo.Text.ToString.Trim, txtIcdCode.Text.ToString.Trim, CDate(dtpEffectDate.GetUsDateStr()))
            End If


            '有查到 Table 要回傳True
            If CheckHasTable(queryDS) Then

                '如果資料列為零要顯示查無符合條件資料
                If queryDS.Tables(0).Rows.Count = 0 Then

                    MessageHandling.ShowWarnMsg("CMMCMMB933", New String() {})

                End If

                '顯示資料在 Grid 上
                UCLScreenUtil.ShowDgv(dgvShowData, queryDS, columnTextDgv, columnWidthDgv, columnVisibleDgv, False)

                returnBoolean = True

            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB915", ex)
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
        Dim dsDBQuery As DataSet = genDS(DataSet_Type.DB)
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        Try
            Dim iCount As Integer = 0
            Dim dsDB As DataSet = genDS(DataSet_Type.DB)
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
            Dim drGrid As DataRow = dsGrid.Tables(tableDB).NewRow()
            Dim drDB As DataRow = dsDB.Tables(tableDB).NewRow()
            '將輸入區資料塞入DB中
            drDB("Chart_No") = Me.txtChartNo.Text.ToString.Trim
            drDB("Icd_Code") = Me.txtIcdCode.Text.ToString.Trim
            drDB("Effect_Date") = Me.dtpEffectDate.GetUsDateStr
            If Me.dtpEndDate.IsEmpty Or Me.dtpEndDate.GetUsDateStr > MAXDATE Then
                drDB("End_Date") = MAXDATE
            Else
                drDB("End_Date") = Me.dtpEndDate.GetUsDateStr
            End If
            drDB("Certificate_Sn") = Me.txtCertificateSn.Text.ToString.Trim
            If Me.chkIsFromIcCard.Checked Then
                drDB("Is_From_Iccard") = "Y"
            Else
                drDB("Is_From_Iccard") = "N"
            End If
            If CurrentUserID.Trim() = "" Then
                CurrentUserID = "pubuser"
            End If
            drDB("Create_User") = CurrentUserID
            drDB("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss").Trim
            dsDB.Tables(tableDB).Rows.Add(drDB)
            '執行新增
            iCount = objPub.insertPUBPatientSevereDisease_L(dsDB)
            If iCount > 0 Then
                drGrid("病歷號") = dsDB.Tables(tableDB).Rows(0)("Chart_No").ToString().Trim
                drGrid("身份證號") = Me.txtIdNo.Text.ToString().Trim
                drGrid("姓名") = Me.txtPatientName.Text.ToString.Trim
                drGrid("ICD_Code") = dsDB.Tables(tableDB).Rows(0)("Icd_Code").ToString().Trim
                drGrid("診斷英文名") = Me.txtEnName.Text.ToString().Trim
                drGrid("診斷中文名") = Me.txtCnName.Text.ToString().Trim
                drGrid("生效日") = dsDB.Tables(tableDB).Rows(0)("Effect_Date").ToString().Trim
                drGrid("結束日") = dsDB.Tables(tableDB).Rows(0)("End_Date").ToString().Trim
                drGrid("證明文號") = dsDB.Tables(tableDB).Rows(0)("Certificate_Sn").ToString().Trim
                If dsDB.Tables(tableDB).Rows(0)("Is_From_Iccard") = "Y" Then
                    drGrid("Is_From_Iccard") = "是"
                    drGrid("Is_From_IcCard(代碼)") = "Y"
                Else
                    drGrid("Is_From_Iccard") = "否"
                    drGrid("Is_From_IcCard(代碼)") = "N"
                End If
                drGrid("建立者") = dsDB.Tables(tableDB).Rows(0)("Create_User").ToString().Trim
                drGrid("建立時間") = Now.ToString("yyyy/MM/dd").Trim
                dsGrid.Tables(tableDB).Rows.Add(drGrid)
                '同步更新
                updateDataGridView(iButtonFlag, dsGrid)
                Me.btnQuery.PerformClick()
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
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        Try
            Dim iCount As Integer = 0
            Dim dsDB As DataSet = genDS(DataSet_Type.DB)
            Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
            Dim drGrid As DataRow = dsGrid.Tables(tableDB).NewRow()
            Dim drDB As DataRow = dsDB.Tables(tableDB).NewRow()
            Dim dsDBQuery As DataSet = genDS(DataSet_Type.DB)
            '將輸入區資料塞入DB中
            drDB("Chart_No") = Me.txtChartNo.Text.ToString.Trim
            drDB("Icd_Code") = Me.txtIcdCode.Text.ToString.Trim
            drDB("Effect_Date") = Me.dtpEffectDate.GetUsDateStr
            'drDB("End_Date") = Me.dtpEndDate.Text.ToString.Trim
            If Me.dtpEndDate.IsEmpty Or Me.dtpEndDate.GetUsDateStr > MAXDATE Then
                drDB("End_Date") = MAXDATE
            Else
                drDB("End_Date") = Me.dtpEndDate.GetUsDateStr
            End If
            drDB("Certificate_Sn") = Me.txtCertificateSn.Text.ToString.Trim
            If Me.chkIsFromIcCard.Checked Then
                drDB("Is_From_Iccard") = "Y"
            Else
                drDB("Is_From_Iccard") = "N"
            End If
            drDB("Create_User") = Nothing
            drDB("Create_Time") = Nothing
            dsDB.Tables(tableDB).Rows.Add(drDB)
            '執行修改
            iCount = objPub.updatePUBPatientSevereDisease_L(dsDB)
            If iCount > 0 Then
                ''**2014-04-10 modify by 長禎 for 維護異動紀錄 寫入Log檔 (新增、修改時)
                'Dim Modify_User As String = AppContext.userProfile.userId '取得使用者ID
                ''Mark By Will 目前無此機制 iCount = objPub.updatePUBPatientSevereDiseaseWithLog_L(dsDB, Modify_User)
                ''&&2014-04-10 modify by 長禎 for 維護異動紀錄 寫入Log檔 (新增、修改時)


                ''將DB資料塞入Grid中
                'Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0)
                'dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("病歷號"), dtGrid.Columns("ICD_Code"), dtGrid.Columns("生效日")}
                'If dtGrid.Rows.Contains(New Object() {Me.txtChartNo.Text.Trim, Me.txtIcdCode.Text.Trim, Me.dtpEffectDate.Text.Trim}) Then
                '    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                '    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.txtChartNo.Text.Trim, Me.txtIcdCode.Text.Trim, Me.dtpEffectDate.Text.Trim})
                '    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                '    drGrid("病歷號") = dsDB.Tables(tableDB).Rows(0)("Chart_No").ToString().Trim
                '    drGrid("身份證號") = Me.txtIdNo.Text.ToString().Trim
                '    drGrid("姓名") = Me.txtPatientName.Text.ToString.Trim
                '    drGrid("ICD_Code") = dsDB.Tables(tableDB).Rows(0)("Icd_Code").ToString().Trim
                '    drGrid("診斷英文名") = Me.txtEnName.Text.ToString().Trim
                '    drGrid("生效日") = dsDB.Tables(tableDB).Rows(0)("Effect_Date").ToString().Trim
                '    drGrid("結束日") = dsDB.Tables(tableDB).Rows(0)("End_Date").ToString().Trim
                '    drGrid("證明文號") = dsDB.Tables(tableDB).Rows(0)("Certificate_Sn").ToString().Trim
                '    If dsDB.Tables(tableDB).Rows(0)("Is_From_Iccard") = "Y" Then
                '        drGrid("Is_From_Iccard") = "是"
                '    Else
                '        drGrid("Is_From_Iccard") = "否"
                '    End If
                '    drGrid("建立者") = drGrid2("建立者").ToString().Trim
                '    drGrid("建立時間") = drGrid2("建立時間").ToString().Trim
                '    dsGrid.Tables(tableDB).Rows.Add(drGrid)




                '同步更新                
                If dtpEffectDate.GetUsDateStr() = "" Then
                    updateDataGridView(iButtonFlag, objPub.PUBPatientSevereDiseasequeryByPKYNShow(Me.txtChartNo.Text.Trim, Me.txtIcdCode.Text.Trim, Nothing))
                Else
                    updateDataGridView(iButtonFlag, objPub.PUBPatientSevereDiseasequeryByPKYNShow(Me.txtChartNo.Text.Trim, Me.txtIcdCode.Text.Trim, CDate(dtpEffectDate.GetUsDateStr())))
                End If
                Me.btnQuery.PerformClick()
                'End If
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB010", New String() {})
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
        Dim dsDB As DataSet = genDS(DataSet_Type.DB)
        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If
        Try
            Dim iCount As Integer = 0


            '**2014-04-10 add by 長禎 for 維護異動紀錄 寫入Log檔 (新增、修改時)
            '記錄刪除前資料
            Dim ChartNo As String = Me.txtChartNo.Text.ToString.Trim
            Dim IcdCode As String = Me.txtIcdCode.Text.Trim
            Dim EffectDate As String = Me.dtpEffectDate.Text.Trim
            Dim Certificate_Sn As String = Me.txtCertificateSn.Text.Trim
            Dim Is_From_IcCard As String = "N"
            If chkIsFromIcCard.Checked Then
                Is_From_IcCard = "Y"
            End If

            '取得使用者ID
            Dim Modify_User As String = AppContext.userProfile.userId

            '寫入Log檔 目前無此機制
            'iCount = objPub.deletePUBPatientSevereDiseaseWithLog_L(Me.txtChartNo.Text.ToString.Trim, Me.txtIcdCode.Text.Trim, Me.dtpEffectDate.Text.Trim, Is_From_IcCard, Modify_User)
            '&&2014-04-10 add by 長禎 for 維護異動紀錄 寫入Log檔 (新增、修改時)

            '將民國年改西元年
            Dim dtpEffectDateUS As String = Me.dtpEffectDate.GetUsDateStr().Trim
            'Dim dtpEndDateUS As String = Me.dtpEndDate.GetUsDateStr().Trim

            '執行刪除
            iCount = objPub.deletePUBPatientSevereDisease_L(Me.txtChartNo.Text.ToString.Trim, Me.txtIcdCode.Text.Trim, dtpEffectDateUS)
            If iCount > 0 Then
                '**2014-04-10 add by 長禎 for 維護異動紀錄 寫入Log檔
                'Mark By Will  objPub.deletePUBPatientSevereDiseaseWithLog_L(ChartNo, IcdCode, EffectDate, Certificate_Sn, Is_From_IcCard, Modify_User)
                '&&2014-04-10 add by 長禎 for 維護異動紀錄 寫入Log檔

                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0)
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("Chart_No"), dtGrid.Columns("Icd_Code"), dtGrid.Columns("Effect_Date"), dtGrid.Columns("End_Date")}
                If dtGrid.Rows.Contains(New Object() {Me.txtChartNo.Text.ToString.Trim, Me.txtIcdCode.Text.Trim, Me.dtpEffectDate.GetUsDateStr, Me.dtpEndDate.GetUsDateStr}) Then
                    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.txtChartNo.Text.ToString.Trim, Me.txtIcdCode.Text.Trim, Me.dtpEffectDate.GetUsDateStr, Me.dtpEndDate.GetUsDateStr})
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                End If
            Else
                MessageHandling.ShowWarnMsg("CMMCMMB011", New String() {})
                blnReturnFlag = False
            End If
            '清除欄位背景色
            cleanFieldsColor()
            '清除欄位資料
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
            Dim strErrMsg2 As StringBuilder = New StringBuilder
            '設定需要檢查的欄位
            Dim ctltxtChartNo As Control = Me.txtChartNo
            Dim cltdtpEffectDate As Control = Me.dtpEffectDate
            Dim cltdtpEndDate As Control = Me.dtpEndDate
            Dim clttxtIcdCode As Control = Me.txtIcdCode
            'Dim clttxtEnName As Control = Me.txtEnName
            'Dim clttxtCnName As Control = Me.txtCnName
            Dim ctlObjFocus As Control = ctltxtChartNo
            '清除欄位背景色
            cleanFieldsColor()
            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not fieldCheckNull(ctltxtChartNo, Control_Type.TextBox) Then
                        strErrMsg1.Append("病歷號")
                        ctlObjFocus = txtChartNo
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(txtIcdCode, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("ICD_Code")
                        ctlObjFocus = txtIcdCode
                        blnReturnFlag = True
                    End If
                    If Me.txtEnName.Text.Equals("") And Me.txtCnName.Text.Equals("") Then
                        Me.txtIcdCode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                        MessageHandling.ShowErrorMsg("CMMCMMB300", "非重大傷病診斷不能新增!")
                        ctlObjFocus = txtIcdCode
                        'ctlObjFocus = txtEnName
                        'ctlObjFocus = txtCnName
                        blnReturnFlag = True
                    End If
                    'If Not fieldCheckNull(clttxtCnName, Control_Type.TextBox) Then
                    'If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                    'strErrMsg1.Append("診斷中文名")
                    'MessageHandling.ShowErrorMsg("CMMCMMB300", "非重大傷病診斷不能新增!")
                    'ctlObjFocus = txtCnName
                    'blnReturnFlag = True
                    'End If
                    If Not fieldCheckNull(cltdtpEffectDate, Control_Type.DateTimePicker) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("生效日")
                        ctlObjFocus = cltdtpEffectDate
                        blnReturnFlag = True
                    End If

                    If Not dtpEndDate.GetUsDateStr.Equals("") Then
                        If Me.dtpEffectDate.GetUsDateStr() > Me.dtpEndDate.GetUsDateStr() Then
                            strErrMsg2.Append("結束日" & "," & "生效日")
                            Me.dtpEndDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            If blnReturnFlag = False Then
                                ctlObjFocus = dtpEndDate
                            End If
                            blnReturnFlag = True
                        End If
                    End If
                Case buttonAction.DELETE
                    If Not fieldCheckNull(ctltxtChartNo, Control_Type.TextBox) Then
                        strErrMsg1.Append("病歷號")
                        ctlObjFocus = txtChartNo
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(txtIcdCode, Control_Type.TextBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("ICD_Code")
                        ctlObjFocus = txtIcdCode
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(cltdtpEffectDate, Control_Type.DateTimePicker) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("生效日")
                        ctlObjFocus = cltdtpEffectDate
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(cltdtpEndDate, Control_Type.DateTimePicker) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("結束日")
                        ctlObjFocus = cltdtpEndDate
                        blnReturnFlag = True
                    End If

                    If Not dtpEndDate.GetUsDateStr.Equals("") Then
                        If Me.dtpEffectDate.GetUsDateStr() > Me.dtpEndDate.GetUsDateStr() Then
                            strErrMsg2.Append("結束日" & "," & "生效日")
                            Me.dtpEndDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            If blnReturnFlag = False Then
                                ctlObjFocus = dtpEndDate
                            End If
                            blnReturnFlag = True
                        End If
                    End If
                Case buttonAction.QUERY  '病歷號查詢條件不能為空,查詢會超時而失敗
                    'If (Not fieldCheckNull(ctltxtChartNo, Control_Type.TextBox)) And _
                    '(Not fieldCheckNull(txtIcdCode, Control_Type.TextBox)) And _
                    '(Not fieldCheckNull(cltdtpEffectDate, Control_Type.DateTimePicker)) Then
                    If Not fieldCheckNull(ctltxtChartNo, Control_Type.TextBox) Then
                        'strErrMsg1.Append("病歷號,ICD_Code,生效日三個查詢條件全部")
                        strErrMsg1.Append("病歷號")
                        MessageHandling.ShowWarnMsg("CMMCMMB305", New String() {strErrMsg1.ToString})
                        ctlObjFocus = ctltxtChartNo
                        ctlObjFocus.Focus()
                        blnReturnFlag = True
                        Return blnReturnFlag
                        Exit Function
                    End If

            End Select

            '欄位check錯誤
            If blnReturnFlag Then
                Dim strMsgs(0) As String
                Dim i As Integer = 0
                If strErrMsg1.Length > 0 Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB305", New String() {strErrMsg1.ToString})
                    i += 1
                End If
                If (strErrMsg2.Length > 0) Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB306", New String() {"結束日", "生效日"})
                    i += 1
                End If
                'MessageHandling.showErrors(strMsgs)
                '********************2010/2/9 Modify By Alan**********************
                Dim pvtErrorMsg As String = ""
                For i = 0 To strMsgs.Length - 1
                    If i <> 0 Then
                        pvtErrorMsg = pvtErrorMsg & vbCrLf & strMsgs(i)
                    Else
                        pvtErrorMsg = strMsgs(i)
                    End If
                Next
                If pvtErrorMsg IsNot Nothing AndAlso pvtErrorMsg.ToString.Trim <> "" Then
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {pvtErrorMsg}, "")
                End If

                'MessageHandling.ShowErrorMsg("CMMCMMB300", "非重大傷病診斷不能新增!")
                ctlObjFocus.Focus()
            End If
            Return blnReturnFlag
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '''' <summary>
    '''' 檢查是否為空白
    '''' </summary>
    '''' <param name="ctl">控件</param>
    '''' <param name="ctType">控件類型</param>
    '''' <returns>Boolean</returns>
    '''' <remarks>True 合法;False 非法</remarks>
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

    ''' <summary>
    ''' 清除事件
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub clearData()
        '清除欄位資料
        cleanFieldsValue()
        '清除欄位背景顏色
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
            Me.txtChartNo.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.dtpEffectDate.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtIcdCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
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
            Me.txtChartNo.Text = ""
            Me.dtpEffectDate.Clear()
            Me.dtpEndDate.Clear()
            Me.txtIdNo.Text = ""
            Me.txtIcdCode.Text = ""
            Me.txtPatientName.Text = ""
            Me.txtCertificateSn.Text = ""
            Me.txtEnName.Text = ""
            Me.txtCnName.Text = ""
            Me.chkIsFromIcCard.Checked = False
            CurrentIcdCode = ""
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
            '清除欄位背景顏色
            cleanFieldsColor()
            If dgvShowData.CurrentCellAddress.Y >= 0 Then
                Me.txtChartNo.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Chart_No").Value.ToString.Trim
                Me.txtIdNo.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Idno").Value.ToString.Trim
                Me.txtPatientName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Patient_Name").Value.ToString.Trim
                Me.txtIcdCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Icd_Code").Value.ToString.Trim
                CurrentIcdCode = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Icd_Code").Value.ToString.Trim
                Me.txtEnName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Disease_En_Name").Value.ToString.Trim
                Me.txtCnName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Disease_Name").Value.ToString.Trim
                Me.txtCertificateSn.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Certificate_Sn").Value.ToString.Trim
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Effect_Date").Value.ToString.Trim <> "" Then
                    Me.dtpEffectDate.SetValue(DateUtil.TransDateToWE(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Effect_Date").Value.ToString.Trim))
                Else
                    Me.dtpEffectDate.Clear()
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("End_Date").Value.ToString.Trim <> "" Then
                    Me.dtpEndDate.SetValue(DateUtil.TransDateToWE(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("End_Date").Value.ToString.Trim))
                Else
                    Me.dtpEndDate.Clear()
                End If
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_From_Iccard").Value.ToString.Trim = "Y" Then
                    Me.chkIsFromIcCard.Checked = True
                Else
                    Me.chkIsFromIcCard.Checked = False
                End If
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
                'CType(dgvShowData.DataSource, System.Data.DataTable).Rows.Add(ds.Tables(strTableDB).Rows(0).ItemArray)
                dgvShowData.GetGridDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
                dgvShowData.GetDBDS.Tables(0).Rows.Add(ds.Tables(0).Rows(0).ItemArray)
            Case buttonAction.UPDATE
                dgvShowData.CurrentRow.SetValues(ds.Tables(tableDB).Rows(0).ItemArray)
                'Case buttonAction.DELETE
                '    dgvShowData.CurrentRow.SetValues(ds.Tables(tableDB).Rows(0).ItemArray)
        End Select
    End Sub

    ''' <summary>
    ''' 病歷號光標離開事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtChartNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()

            '設定身份證號
            PatientMessageSet()

        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD001")
            MessageHandling.ShowErrorMsg("CMMCMMD001", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 病患信息設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PatientMessageSet()
        If Me.txtChartNo.Text.Trim <> "" Then
            Me.txtIdNo.Text = Me.txtIdNo.Text.Trim
            Me.txtPatientName.Text = Me.txtPatientName.Text.Trim
        Else
            Me.txtIdNo.Text = ""
            Me.txtPatientName.Text = ""
        End If

    End Sub

    'Private Sub doUcrOpenWindowValue(ByVal uclName As String, ByVal uclCodeValue1 As String, ByVal uclCodeValue2 As String, ByVal uclCodeName As String) Handles pvtReceiveMgr.UclOpenWindowValue

    '    If uclName = Me.Name & Me.txtIcdCode.Name Then
    '        'Me.txtIcdCode.uclCodeValue1 = uclCodeValue1.Trim
    '        'Me.txtIcdCode.uclCodeValue2 = uclCodeValue2.Trim
    '        'Me.txtIcdCode.uclCodeName = uclCodeName.Trim  '診斷英文名稱

    '        Me.txtEnName.Text = uclCodeName.Trim
    '    End If
    'End Sub

    ''' <summary>
    ''' ICD_Code光標離開事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtIcdCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIcdCode.Leave
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.ClearInfoMsg()

            Dim dsDB As DataSet

            txtIcdCode.CharacterCasing = CharacterCasing.Upper

            If Me.txtIcdCode.Text.Trim <> "" Then
                dsDB = objPub.queryPubDiseaseEnNameByIcdCode_L(Me.txtIcdCode.Text.ToString.Trim)
                If dsDB.Tables.Count > 0 Then
                    If dsDB.Tables(0).Rows.Count = 0 Then
                        Me.txtEnName.Text = ""
                        Me.txtCnName.Text = ""

                        If CurrentIcdCode <> Me.txtIcdCode.Text.Trim Then
                            MessageBox.Show("無此重大傷病Icd_Code基本資料")
                        End If
                         

                    Else
                        Me.txtEnName.Text = dsDB.Tables(0).Rows(0).Item("Disease_En_Name").ToString().Trim()
                        Me.txtCnName.Text = dsDB.Tables(0).Rows(0).Item("Disease_Name").ToString().Trim()
                    End If
                End If

            Else
                Me.txtEnName.Text = ""
                Me.txtCnName.Text = ""
            End If

            CurrentIcdCode = Me.txtIcdCode.Text.Trim

        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD001")
            MessageHandling.ShowErrorMsg("CMMCMMD001", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub


    '#Region "**2014-04-15 add by 陳長禎 - show 異動Log 的 Form"
    '    Private Sub btnQueryModifyLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQueryModifyLog.Click
    '        'Dim f As DockContent = FindDocument("PUBPatientSevereDiseaseLogQueryUI")
    '        'If f IsNot Nothing Then
    '        '    f.Show()
    '        'End If

    '        Dim f As PUBPatientSevereDiseaseLogQueryUI = New PUBPatientSevereDiseaseLogQueryUI()

    '        If f IsNot Nothing Then
    '            '由 Button 觸發 (查全部)
    '            f.CharNo = txtChartNo.Text
    '            f.EffectDate = dtpEffectDate.Text
    '            If dtpEffectDate.Text.Replace("/", "").Trim = "" Then '或 dtpEffectDate.Text = "    /  /" -> dtpEffectDate.Text 沒輸入字串時的處理
    '                f.EffectDate = ""
    '            End If
    '            f.IcdCode = txtIcdCode.Text
    '            f.ShowQueryBar = False
    '            'Dialog 視窗，為父視窗的 0.9
    '            f.Width = Me.Width * 0.9
    '            f.Height = Me.Height * 0.9



    '            ''由 DataGridView 觸發 (查單筆)
    '            'If sender Is Nothing Then
    '            '    f.ShowQueryBar = False
    '            'End If

    '            'f.Show()
    '            f.ShowDialog()
    '            f.Dispose()
    '        End If
    '    End Sub


    '    '**2014-04-15 add by 長禎 - DobuleClick dgvShowData 帶出該筆資料的異動紀錄
    '    Private Sub DataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '        btnQueryModifyLog_Click(Nothing, Nothing)
    '    End Sub


    '#End Region


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
                ' {"病歷號", "身份證號", "姓名", "生效日", "ICD_Code", "診斷英文名", "證明文號", "結束日", "Is_From_IcCard", "建立者", "建立時間"}
                Return New String(,) {{"病歷號", "病歷號", "Y", "N", ""}, _
                                      {"身份證號", "身份證號", "Y", "N", ""}, _
                                      {"姓名", "姓名", "Y", "N", ""}, _
                                      {"生效日", "生效日", "Y", "N", ""}, _
                                      {"ICD_Code", "ICD_Code", "Y", "N", ""}, _
                                      {"診斷英文名", "診斷英文名", "Y", "N", ""}, _
                                      {"診斷中文名", "診斷中文名", "Y", "N", ""}, _
                                      {"證明文號", "證明文號", "Y", "N", ""}, _
                                      {"結束日", "結束日", "Y", "N", ""}, _
                                      {"Is_From_IcCard", "Is_From_IcCard", "Y", "N", ""}, _
                                      {"建立者", "建立者", "Y", "N", ""}, _
                                      {"建立時間", "建立時間", "Y", "N", ""}}

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

