'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBContractUI.vb
'*              Title:	合約機構基本檔維護
'*        Description:	合約機構基本檔維護 新增,修改,刪除和查詢
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	merry_jing
'*        Create Date:	2009/07/21
'*      Last Modifier:	merry_jing
'*   Last Modify Date:	2010/04/07
'*
'*****************************************************************************
'*/

Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports System.Text
Imports Syscom.Client.UCL
Public Class PUBContractUI
    Inherits Syscom.Client.UCL.BaseFormUI


    Dim objPub As IPubServiceManager = Nothing

    '目前使用者的ID
    Dim currentUserID As String = AppContext.userProfile.userId
    ' Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)
    '獲取維護表名
    '合約機構基本檔-PUB_Contract
    Dim strTableDB As String = PubContractDataTableFactory.tableName
    Dim pDataRowView As DataRowView
    '獲取維護表字段名
    Dim strColumnNameDB() As String = PubContractDataTableFactory.columnsName

    '獲取維護表字段長度
    Dim iColumnsLength() As Integer = PubContractDataTableFactory.columnsLength

    'Grid使用的標題
    Dim columnNameGrid() As String = {"合約機關代碼", "合約機關名稱", "隸屬身份二", "身份二代號", _
                                        "記帳上限金額", "記帳上限處理方式", "方式代號", "檢查累積記帳額度", _
                                        "額度代號", "停用", "建立者", "建立時間", "修改者", "修改時間", _
                                        "計畫主持人", "計畫藥品", "計畫藥品名", "藥委會編號", "計畫起日", _
                                        "計畫迄日", "收據抬頭", "聯絡人", "聯絡人電話", "聯絡人電話(M)", _
                                        "FAX", "聯絡人E-Mail", "郵遞區號", "聯絡人住址", "折數", "分成", "備註", "合約機構請款類型", "是否參考折扣及記帳檔"}

    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {3, 6, 8} '從0開始
    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum

    '控件類型定義
    Enum Control_Type
        ComboBox
        TextBox
    End Enum
    '按鈕類型定義
    Enum buttonAction
        INSERT
        UPDATE
        DELETE
        QUERY
        CLEAR
    End Enum


    Private Sub PUBContractUI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            initialData()
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("HEMCMMB006")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("HEMCMMB006", New String() {}, "")
        End Try
    End Sub

    ''' <summary>
    ''' 初始化畫面 構建空的Grid 設定欄位長度
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance
            Me.txtContractCode.MaxLength = PubContractDataTableFactory.columnsLength(0)
            '顯示DataGridView的初始Table
            dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(strTableDB)

            'Dim frmDialog As client.ucl.IUCLMaintainFormUI = New client.ucl.IUCLMaintainFormUI() With {._uclDeleteOK = False}
            '設定Grid滿屏
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            '初始化隸屬身份二
            Me.initialCmbSubIdentityCode()

            '初始化記帳上限處理方式
            Me.initialCmbUpperAmtTypeId()

            '初始化檢查累積記帳額度
            Me.initialCmbCheckQuotaId()

            '初始化聯絡地址控件
            Me.UclZipCodeAddress.Initial()

            '初始化合約機構請款類型()
            Me.initialCmbContractTypeId()

            '將DataGridView的欄位隱藏
            For i As Integer = 0 To visibleColumnNo.Length - 1
                dgvShowData.Columns(visibleColumnNo(i)).Visible = False
            Next
            For i As Integer = 14 To 32
                dgvShowData.Columns(i).Visible = False
            Next
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
                dsTemp.Tables(strTableDB).Columns("記帳上限金額").DataType = System.Type.GetType("System.Decimal")
                dsTemp.Tables(strTableDB).Columns("折數").DataType = System.Type.GetType("System.Decimal")
                dsTemp.Tables(strTableDB).Columns("分成").DataType = System.Type.GetType("System.Decimal")
            Case DataSet_Type.DB
                '給DB用Table
                '合約機構基本檔-PUB_Contract
                dsTemp.Tables.Add(strTableDB)
                For i As Integer = 0 To strColumnNameDB.Length - 1
                    dsTemp.Tables(strTableDB).Columns.Add(strColumnNameDB(i))
                Next
        End Select
        Return dsTemp
    End Function

    ''' <summary>
    ''' 查詢事件
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 查詢成功</remarks>
    Public Function queryData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.QUERY
        Dim blnReturnFlag As Boolean = True
        Dim dsDB As DataSet
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)

        '輸入區欄位顏色初始化
        cleanFieldsColor()

        '執行查詢
        dsDB = objPub.queryPUBContractByCond(Me.txtContractCode.Text.ToString.Trim, Me.cmbSubIdentityCode.SelectedValue.ToString.Trim)
        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(strTableDB).Rows.Count = 0 Then
                    '查無符合條件之資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    Dim drGrid(dsDB.Tables(strTableDB).Rows.Count - 1) As DataRow
                    '將查詢的數據插入到Grid表中並顯示在畫面上
                    For i As Integer = 0 To dsDB.Tables(strTableDB).Rows.Count - 1
                        drGrid(i) = dsGrid.Tables(strTableDB).NewRow()
                        drGrid(i)("合約機關代碼") = dsDB.Tables(strTableDB).Rows(i)("Contract_Code").ToString.Trim()
                        drGrid(i)("合約機關名稱") = dsDB.Tables(strTableDB).Rows(i)("Contract_Name").ToString.Trim()

                        drGrid(i)("隸屬身份二") = dsDB.Tables(strTableDB).Rows(i)("Sub_Identity_Name").ToString.Trim()
                        drGrid(i)("身份二代號") = dsDB.Tables(strTableDB).Rows(i)("Sub_Identity_Code").ToString.Trim()
                        drGrid(i)("記帳上限金額") = dsDB.Tables(strTableDB).Rows(i)("Upper_Amt")
                        '記帳上限處理方式為空的處理
                        If dsDB.Tables(strTableDB).Rows(i)("Upper_Amt_Type_Id").ToString.Trim() <> "" Then
                            drGrid(i)("記帳上限處理方式") = dsDB.Tables(strTableDB).Rows(i)("Upper_Name").ToString.Trim()
                        Else
                            drGrid(i)("記帳上限處理方式") = "無"
                        End If
                        drGrid(i)("方式代號") = dsDB.Tables(strTableDB).Rows(i)("Upper_Amt_Type_Id").ToString.Trim()
                        '檢查累積記帳額度為空的處理
                        If dsDB.Tables(strTableDB).Rows(i)("Check_Quota_Id").ToString.Trim() <> "" Then
                            drGrid(i)("檢查累積記帳額度") = dsDB.Tables(strTableDB).Rows(i)("Check_Quota_Name").ToString.Trim()
                        Else
                            drGrid(i)("檢查累積記帳額度") = "無"
                        End If
                        drGrid(i)("額度代號") = dsDB.Tables(strTableDB).Rows(i)("Check_Quota_Id").ToString.Trim()

                        If dsDB.Tables(strTableDB).Rows(i)("Dc").ToString() = "N" Then
                            drGrid(i)("停用") = "否"
                        Else
                            drGrid(i)("停用") = "是"
                        End If
                        drGrid(i)("建立者") = dsDB.Tables(strTableDB).Rows(i)("Create_User").ToString.Trim()
                        If dsDB.Tables(strTableDB).Rows(i)("Create_Time").ToString <> "" Then
                            drGrid(i)("建立時間") = DateUtil.TransDateToROC(CDate(dsDB.Tables(strTableDB).Rows(i)("Create_Time")).ToString("yyyy/MM/dd")) & " " & CDate(dsDB.Tables(strTableDB).Rows(i)("Create_Time")).ToString("HH:mm:ss")
                        End If
                        drGrid(i)("修改者") = dsDB.Tables(strTableDB).Rows(i)("Modified_User").ToString.Trim()
                        If dsDB.Tables(strTableDB).Rows(i)("Modified_Time").ToString <> "" Then
                            drGrid(i)("修改時間") = DateUtil.TransDateToROC(CDate(dsDB.Tables(strTableDB).Rows(i)("Modified_Time")).ToString("yyyy/MM/dd")) & " " & CDate(dsDB.Tables(strTableDB).Rows(i)("Modified_Time")).ToString("HH:mm:ss")
                        End If

                        drGrid(i)("計畫主持人") = dsDB.Tables(strTableDB).Rows(i)("Project_Director").ToString.Trim()
                        drGrid(i)("計畫藥品") = dsDB.Tables(strTableDB).Rows(i)("Drug_Code").ToString.Trim()
                        drGrid(i)("計畫藥品名") = dsDB.Tables(strTableDB).Rows(i)("Drug_Name").ToString.Trim()
                        drGrid(i)("藥委會編號") = dsDB.Tables(strTableDB).Rows(i)("Drug_Committee_Sn").ToString.Trim()
                        If dsDB.Tables(strTableDB).Rows(i)("Project_Effect_Date").ToString <> "" Then
                            drGrid(i)("計畫起日") = CDate(dsDB.Tables(strTableDB).Rows(i)("Project_Effect_Date")).ToString("yyyy/MM/dd HH:mm:ss")
                        End If
                        If dsDB.Tables(strTableDB).Rows(i)("Project_End_Date").ToString <> "" Then
                            drGrid(i)("計畫迄日") = CDate(dsDB.Tables(strTableDB).Rows(i)("Project_End_Date")).ToString("yyyy/MM/dd HH:mm:ss")
                        End If
                        drGrid(i)("收據抬頭") = dsDB.Tables(strTableDB).Rows(i)("Receipt_Title").ToString.Trim()
                        drGrid(i)("聯絡人") = dsDB.Tables(strTableDB).Rows(i)("Contact_Name").ToString.Trim()
                        drGrid(i)("聯絡人電話") = dsDB.Tables(strTableDB).Rows(i)("Contact_Tel").ToString.Trim()
                        drGrid(i)("聯絡人電話(M)") = dsDB.Tables(strTableDB).Rows(i)("Contact_Tel_Mobile").ToString.Trim()
                        drGrid(i)("FAX") = dsDB.Tables(strTableDB).Rows(i)("Contact_Fax").ToString.Trim()
                        drGrid(i)("聯絡人E-Mail") = dsDB.Tables(strTableDB).Rows(i)("Contact_Email").ToString.Trim()
                        drGrid(i)("郵遞區號") = dsDB.Tables(strTableDB).Rows(i)("Contact_Postal_Code").ToString.Trim()
                        drGrid(i)("聯絡人住址") = dsDB.Tables(strTableDB).Rows(i)("Contact_Address").ToString.Trim()
                        drGrid(i)("折數") = dsDB.Tables(strTableDB).Rows(i)("Dis_Rate")
                        drGrid(i)("分成") = dsDB.Tables(strTableDB).Rows(i)("Add_Rate")
                        drGrid(i)("備註") = dsDB.Tables(strTableDB).Rows(i)("Memo").ToString.Trim()
                        '20110310 add by yunfei
                        drGrid(i)("建立者") = dsDB.Tables(strTableDB).Rows(i)("Create_User").ToString.Trim()
                        'drGrid(i)("建立時間") = CDate(dsDB.Tables(strTableDB).Rows(i)("Create_Time")).ToString("yyyy/MM/dd HH:mm:ss")
                        drGrid(i)("修改者") = dsDB.Tables(strTableDB).Rows(i)("Modified_User").ToString.Trim()
                        'If dsDB.Tables(strTableDB).Rows(i)("Modified_Time").ToString <> "" Then
                        '    drGrid(i)("修改時間") = CDate(dsDB.Tables(strTableDB).Rows(i)("Modified_Time")).ToString("yyyy/MM/dd HH:mm:ss")
                        'End If

                        '20110418 ADD BY YUNFEI
                        ' "合約機構請款類型", "是否參考折扣及記帳檔"
                        drGrid(i)("是否參考折扣及記帳檔") = dsDB.Tables(strTableDB).Rows(i)("Is_Use_Set").ToString.Trim
                        drGrid(i)("合約機構請款類型") = dsDB.Tables(strTableDB).Rows(i)("Contract_Type_Id").ToString.Trim()

                        dsGrid.Tables(strTableDB).Rows.Add(drGrid(i))
                    Next
                    '將查詢到的資料綁定到Grid上
                    dgvShowData.DataSource = dsGrid.Tables(strTableDB)
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
    Public Function insertData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.INSERT
        Dim blnReturnFlag As Boolean = True

        '創建Grid更新用DataSet和DataRow
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        Dim drGrid As DataRow = dsGrid.Tables(strTableDB).NewRow()
        Dim iCount As Integer = 0

        '創建DB新增用DataSet和DataRow
        Dim dsDB As DataSet = genDS(DataSet_Type.DB)
        Dim drDB As DataRow = dsDB.Tables(strTableDB).NewRow()

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            '將輸入區資料添加到DB中
            drDB("Contract_Code") = Me.txtContractCode.Text.ToString.Trim
            drDB("Contract_Name") = Me.txtContractName.Text.ToString.Trim
            drDB("Sub_Identity_Code") = Me.cmbSubIdentityCode.SelectedValue.ToString
            drDB("Is_Use_Set") = "N"
            '記帳上限金額為空時的處理
            If Me.txtUpperAmt.Text.Trim <> "" Then
                drDB("Upper_Amt") = Me.txtUpperAmt.Text.Trim
            Else
                drDB("Upper_Amt") = Nothing
            End If
            drDB("Upper_Amt_Type_Id") = Me.cmbUpperAmtTypeId.SelectedValue.ToString
            drDB("Check_Quota_Id") = Me.cmbCheckQuotaId.SelectedValue.ToString
            drDB("Project_Director") = Me.txtProjectDirector.Text.Trim
            drDB("Drug_Code") = Me.txtDrugCode.Text.Trim
            drDB("Drug_Name") = Me.txtDrugName.Text.Trim
            drDB("Drug_Committee_Sn") = Me.txtDrugCommitteeSn.Text.Trim

            If Me.dtpProjectEffectDate.GetUsDateStr().Replace("/", "") <> "" Then
                drDB("Project_Effect_Date") = Me.dtpProjectEffectDate.GetUsDateStr()
            Else
                drDB("Project_Effect_Date") = Nothing
            End If
            If Me.dtpProjectEndDate.GetUsDateStr().Replace("/", "") <> "" Then
                drDB("Project_End_Date") = Me.dtpProjectEndDate.GetUsDateStr()
            Else
                drDB("Project_End_Date") = Nothing
            End If

            drDB("Contact_Name") = Me.txtContactName.Text.Trim
            drDB("Receipt_Title") = Me.txtReceiptTitle.Text.Trim

            '聯絡人電話的設定
            Dim strTel As StringBuilder = New StringBuilder
            If Me.txtContactTel1.Text.Trim <> "" Then
                strTel.Append(Me.txtContactTel1.Text.Trim)
            End If
            If Me.txtContactTel2.Text.Trim <> "" Then
                If strTel.Length > 0 Then strTel.Append("-")
                strTel.Append(Me.txtContactTel2.Text.Trim)
            End If
            If Me.txtContactTel3.Text.Trim <> "" Then
                If strTel.Length > 0 Then strTel.Append("-")
                strTel.Append(Me.txtContactTel3.Text.Trim)
            End If
            drDB("Contact_Tel") = strTel.ToString

            drDB("Contact_Tel_Mobile") = Me.txtContactTelMobile.Text.Trim
            drDB("Contact_Fax") = Me.txtContactFax.Text.Trim
            drDB("Contact_Email") = Me.txtContactEmail.Text.Trim
            drDB("Contact_Postal_Code") = Me.UclZipCodeAddress.SelectedValue.Trim
            drDB("Contact_Address") = Me.UclZipCodeAddress.TxtAddress.Trim
            '折數為空時的處理
            If Me.txtDisRate.Text.Trim <> "" Then
                drDB("Dis_Rate") = Me.txtDisRate.Text.Trim
            Else
                drDB("Dis_Rate") = Nothing
            End If
            '分成為空時的處理
            If Me.txtAddRate.Text.Trim <> "" Then
                drDB("Add_Rate") = Me.txtAddRate.Text.Trim
            Else
                drDB("Add_Rate") = Nothing
            End If

            drDB("Memo") = Me.txtMemo.Text.Trim
            '停用
            If chkDC.Checked = True Then
                drDB("Dc") = "Y"
            Else
                drDB("Dc") = "N"
            End If
            '20110418 ADD BY YUNFEI
            ' "合約機構請款類型", "是否參考折扣及記帳檔"
            drDB("Contract_Type_Id") = Me.cmbContractTypeId.SelectedValue.Trim
            If chbIsUseSet.Checked = True Then
                drDB("Is_Use_Set") = "Y"
            Else
                drDB("Is_Use_Set") = "N"
            End If
            '創建者/修改者設定
            If currentUserID.Trim() = "" Then
                currentUserID = "pubuser"
            End If
            drDB("Create_User") = currentUserID
            drDB("Create_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = drDB("Create_Time")
            dsDB.Tables(strTableDB).Rows.Add(drDB)
            '執行新增
            iCount = objPub.insertPUBContract(dsDB)

            If iCount > 0 Then
                '將畫面輸入資料塞入Grid中
                drGrid("合約機關代碼") = dsDB.Tables(strTableDB).Rows(0)("Contract_Code").ToString.Trim()
                drGrid("合約機關名稱") = dsDB.Tables(strTableDB).Rows(0)("Contract_Name").ToString.Trim()

                drGrid("隸屬身份二") = Me.cmbSubIdentityCode.Text.ToString.Trim()
                drGrid("身份二代號") = dsDB.Tables(strTableDB).Rows(0)("Sub_Identity_Code").ToString.Trim()

                If dsDB.Tables(strTableDB).Rows(0)("Upper_Amt").ToString.Trim <> "" Then
                    drGrid("記帳上限金額") = dsDB.Tables(strTableDB).Rows(0)("Upper_Amt")
                End If

                '記帳上限處理方式為空的處理
                If Me.cmbUpperAmtTypeId.Text.ToString.Trim() <> "" Then
                    drGrid("記帳上限處理方式") = Me.cmbUpperAmtTypeId.Text.ToString.Trim()
                Else
                    drGrid("記帳上限處理方式") = "無"
                End If
                drGrid("方式代號") = dsDB.Tables(strTableDB).Rows(0)("Upper_Amt_Type_Id").ToString.Trim()

                '檢查累積記帳額度為空的處理
                If Me.cmbCheckQuotaId.Text.ToString.Trim() <> "" Then
                    drGrid("檢查累積記帳額度") = Me.cmbCheckQuotaId.Text.ToString.Trim()
                Else
                    drGrid("檢查累積記帳額度") = "無"
                End If
                drGrid("額度代號") = dsDB.Tables(strTableDB).Rows(0)("Check_Quota_Id").ToString.Trim()

                If dsDB.Tables(strTableDB).Rows(0)("Dc").ToString() = "N" Then
                    drGrid("停用") = "否"
                Else
                    drGrid("停用") = "是"
                End If
                drGrid("建立者") = dsDB.Tables(strTableDB).Rows(0)("Create_User").ToString.Trim()
                If dsDB.Tables(strTableDB).Rows(0)("Create_Time").ToString <> "" Then
                    drGrid("建立時間") = CDate(dsDB.Tables(strTableDB).Rows(0)("Create_Time")).ToString("yyyy/MM/dd HH:mm:ss")
                End If
                drGrid("修改者") = dsDB.Tables(strTableDB).Rows(0)("Modified_User").ToString.Trim()
                If dsDB.Tables(strTableDB).Rows(0)("Modified_Time").ToString <> "" Then
                    drGrid("修改時間") = CDate(dsDB.Tables(strTableDB).Rows(0)("Modified_Time")).ToString("yyyy/MM/dd HH:mm:ss")
                End If
                drGrid("計畫主持人") = dsDB.Tables(strTableDB).Rows(0)("Project_Director").ToString.Trim()
                drGrid("計畫藥品") = dsDB.Tables(strTableDB).Rows(0)("Drug_Code").ToString.Trim()
                drGrid("計畫藥品名") = dsDB.Tables(strTableDB).Rows(0)("Drug_Name").ToString.Trim()
                drGrid("藥委會編號") = dsDB.Tables(strTableDB).Rows(0)("Drug_Committee_Sn").ToString.Trim()
                drGrid("計畫起日") = Me.dtpProjectEffectDate.GetUsDateStr()
                drGrid("計畫迄日") = Me.dtpProjectEndDate.GetUsDateStr()
                drGrid("收據抬頭") = dsDB.Tables(strTableDB).Rows(0)("Receipt_Title").ToString.Trim()
                drGrid("聯絡人") = dsDB.Tables(strTableDB).Rows(0)("Contact_Name").ToString.Trim()
                drGrid("聯絡人電話") = dsDB.Tables(strTableDB).Rows(0)("Contact_Tel").ToString.Trim()
                drGrid("聯絡人電話(M)") = dsDB.Tables(strTableDB).Rows(0)("Contact_Tel_Mobile").ToString.Trim()
                drGrid("FAX") = dsDB.Tables(strTableDB).Rows(0)("Contact_Fax").ToString.Trim()
                drGrid("聯絡人E-Mail") = dsDB.Tables(strTableDB).Rows(0)("Contact_Email").ToString.Trim()
                drGrid("郵遞區號") = dsDB.Tables(strTableDB).Rows(0)("Contact_Postal_Code").ToString.Trim()
                drGrid("聯絡人住址") = dsDB.Tables(strTableDB).Rows(0)("Contact_Address").ToString.Trim()
                If dsDB.Tables(strTableDB).Rows(0)("Dis_Rate").ToString.Trim <> "" Then
                    drGrid("折數") = dsDB.Tables(strTableDB).Rows(0)("Dis_Rate")
                End If
                If dsDB.Tables(strTableDB).Rows(0)("Add_Rate").ToString.Trim <> "" Then
                    drGrid("分成") = dsDB.Tables(strTableDB).Rows(0)("Add_Rate")
                End If
                drGrid("備註") = dsDB.Tables(strTableDB).Rows(0)("Memo").ToString.Trim()
                '20110310 add by yunfei
                drGrid("建立者") = dsDB.Tables(strTableDB).Rows(0)("Create_User").ToString.Trim()
                drGrid("建立時間") = DateUtil.TransDateToROC(dsDB.Tables(strTableDB).Rows(0)("Create_Time"))
                drGrid("修改者") = dsDB.Tables(strTableDB).Rows(0)("Modified_User").ToString.Trim()
                drGrid("修改時間") = DateUtil.TransDateToROC(dsDB.Tables(strTableDB).Rows(0)("Modified_Time"))

                '20110418 ADD BY YUNFEI
                ' "合約機構請款類型", "是否參考折扣及記帳檔"
                drGrid("是否參考折扣及記帳檔") = dsDB.Tables(strTableDB).Rows(0)("Is_Use_Set").ToString.Trim
                drGrid("合約機構請款類型") = dsDB.Tables(strTableDB).Rows(0)("Contract_Type_Id").ToString.Trim

                dsGrid.Tables(strTableDB).Rows.Add(drGrid)
                '同步更新Grid內容
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
    Public Function updateData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.UPDATE
        Dim blnReturnFlag As Boolean = True
        '創建DB修改用DataSet和DataRow
        Dim dsDB As DataSet = genDS(DataSet_Type.DB)
        Dim drDB As DataRow = dsDB.Tables(strTableDB).NewRow()
        Dim iCount As Integer = 0
        '創建Grid更新用DataSet和DataRow
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        Dim drGrid As DataRow = dsGrid.Tables(strTableDB).NewRow()

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            '將輸入區資料添加到DB中
            drDB("Contract_Code") = Me.txtContractCode.Text.ToString.Trim
            drDB("Contract_Name") = Me.txtContractName.Text.ToString.Trim
            drDB("Sub_Identity_Code") = Me.cmbSubIdentityCode.SelectedValue.ToString
            drDB("Is_Use_Set") = "N"
            '記帳上限金額為空時的處理
            If Me.txtUpperAmt.Text.Trim <> "" Then
                drDB("Upper_Amt") = Me.txtUpperAmt.Text.Trim
            Else
                drDB("Upper_Amt") = Nothing
            End If
            drDB("Upper_Amt_Type_Id") = Me.cmbUpperAmtTypeId.SelectedValue.ToString
            drDB("Check_Quota_Id") = Me.cmbCheckQuotaId.SelectedValue.ToString
            drDB("Project_Director") = Me.txtProjectDirector.Text.Trim
            drDB("Drug_Code") = Me.txtDrugCode.Text.Trim
            drDB("Drug_Name") = Me.txtDrugName.Text.Trim
            drDB("Drug_Committee_Sn") = Me.txtDrugCommitteeSn.Text.Trim

            If Me.dtpProjectEffectDate.GetUsDateStr().Replace("/", "") <> "" Then
                drDB("Project_Effect_Date") = Me.dtpProjectEffectDate.GetUsDateStr()
            Else
                drDB("Project_Effect_Date") = Nothing
            End If
            If Me.dtpProjectEndDate.GetUsDateStr().Replace("/", "") <> "" Then
                drDB("Project_End_Date") = Me.dtpProjectEndDate.GetUsDateStr()
            Else
                drDB("Project_End_Date") = Nothing
            End If

            drDB("Contact_Name") = Me.txtContactName.Text.Trim
            drDB("Receipt_Title") = Me.txtReceiptTitle.Text.Trim

            '聯絡人電話的設定
            Dim strTel As StringBuilder = New StringBuilder
            If Me.txtContactTel1.Text.Trim <> "" Then
                strTel.Append(Me.txtContactTel1.Text.Trim)
            End If
            If Me.txtContactTel2.Text.Trim <> "" Then
                If strTel.Length > 0 Then strTel.Append("-")
                strTel.Append(Me.txtContactTel2.Text.Trim)
            End If
            If Me.txtContactTel3.Text.Trim <> "" Then
                If strTel.Length > 0 Then strTel.Append("-")
                strTel.Append(Me.txtContactTel3.Text.Trim)
            End If
            drDB("Contact_Tel") = strTel.ToString

            drDB("Contact_Tel_Mobile") = Me.txtContactTelMobile.Text.Trim
            drDB("Contact_Fax") = Me.txtContactFax.Text.Trim
            drDB("Contact_Email") = Me.txtContactEmail.Text.Trim
            drDB("Contact_Postal_Code") = Me.UclZipCodeAddress.SelectedValue.Trim
            drDB("Contact_Address") = Me.UclZipCodeAddress.TxtAddress.Trim
            '折數為空時的處理
            If Me.txtDisRate.Text.Trim <> "" Then
                drDB("Dis_Rate") = Me.txtDisRate.Text.Trim
            Else
                drDB("Dis_Rate") = Nothing
            End If
            '分成為空時的處理
            If Me.txtAddRate.Text.Trim <> "" Then
                drDB("Add_Rate") = Me.txtAddRate.Text.Trim
            Else
                drDB("Add_Rate") = Nothing
            End If

            drDB("Memo") = Me.txtMemo.Text.Trim
            '停用
            If chkDC.Checked = True Then
                drDB("Dc") = "Y"
            Else
                drDB("Dc") = "N"
            End If

            '20110418 ADD BY YUNFEI
            ' "合約機構請款類型", "是否參考折扣及記帳檔"
            drDB("Contract_Type_Id") = Me.cmbContractTypeId.SelectedValue.Trim
            If chbIsUseSet.Checked = True Then
                drDB("Is_Use_Set") = "Y"
            Else
                drDB("Is_Use_Set") = "N"
            End If

            '創建者/修改者設定
            If currentUserID.Trim() = "" Then
                currentUserID = "pubuser"
            End If
            drDB("Create_User") = Nothing
            drDB("Create_Time") = Nothing
            drDB("Modified_User") = currentUserID
            drDB("Modified_Time") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            dsDB.Tables(strTableDB).Rows.Add(drDB)

            '執行修改
            iCount = objPub.updatePUBContract(dsDB)

            If iCount > 0 Then
                '將畫面輸入資料塞入Grid中
                Dim dtGrid As DataTable = dgvShowData.DataSource
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("合約機關代碼"), dtGrid.Columns("身份二代號")}
                If dtGrid.Rows.Contains(New Object() {Me.txtContractCode.Text.Trim, Me.cmbSubIdentityCode.SelectedValue.ToString.Trim}) Then
                    CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(New Object() {Me.txtContractCode.Text.Trim, Me.cmbSubIdentityCode.SelectedValue.ToString.Trim})
                    dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)

                    drGrid("合約機關代碼") = dsDB.Tables(strTableDB).Rows(0)("Contract_Code").ToString.Trim()
                    drGrid("合約機關名稱") = dsDB.Tables(strTableDB).Rows(0)("Contract_Name").ToString.Trim()

                    drGrid("隸屬身份二") = Me.cmbSubIdentityCode.Text.ToString.Trim()
                    drGrid("身份二代號") = dsDB.Tables(strTableDB).Rows(0)("Sub_Identity_Code").ToString.Trim()
                    If dsDB.Tables(strTableDB).Rows(0)("Upper_Amt").ToString.Trim <> "" Then
                        drGrid("記帳上限金額") = dsDB.Tables(strTableDB).Rows(0)("Upper_Amt")
                    End If
                    '記帳上限處理方式為空的處理
                    If Me.cmbUpperAmtTypeId.Text.ToString.Trim() <> "" Then
                        drGrid("記帳上限處理方式") = Me.cmbUpperAmtTypeId.Text.ToString.Trim()
                    Else
                        drGrid("記帳上限處理方式") = "無"
                    End If
                    drGrid("方式代號") = dsDB.Tables(strTableDB).Rows(0)("Upper_Amt_Type_Id").ToString.Trim()

                    '檢查累積記帳額度為空的處理
                    If Me.cmbCheckQuotaId.Text.ToString.Trim() <> "" Then
                        drGrid("檢查累積記帳額度") = Me.cmbCheckQuotaId.Text.ToString.Trim()
                    Else
                        drGrid("檢查累積記帳額度") = "無"
                    End If
                    drGrid("額度代號") = dsDB.Tables(strTableDB).Rows(0)("Check_Quota_Id").ToString.Trim()

                    If dsDB.Tables(strTableDB).Rows(0)("Dc").ToString() = "N" Then
                        drGrid("停用") = "否"
                    Else
                        drGrid("停用") = "是"
                    End If
                    drGrid("建立者") = drGrid2("建立者")
                    drGrid("建立時間") = drGrid2("建立時間")
                    drGrid("修改者") = dsDB.Tables(strTableDB).Rows(0)("Modified_User").ToString.Trim()
                    'If dsDB.Tables(strTableDB).Rows(0)("Modified_Time").ToString <> "" Then
                    '    drGrid("修改時間") = CDate(dsDB.Tables(strTableDB).Rows(0)("Modified_Time")).ToString("yyyy/MM/dd HH:mm:ss")
                    'End If

                    drGrid("計畫主持人") = dsDB.Tables(strTableDB).Rows(0)("Project_Director").ToString.Trim()
                    drGrid("計畫藥品") = dsDB.Tables(strTableDB).Rows(0)("Drug_Code").ToString.Trim()
                    drGrid("計畫藥品名") = dsDB.Tables(strTableDB).Rows(0)("Drug_Name").ToString.Trim()
                    drGrid("藥委會編號") = dsDB.Tables(strTableDB).Rows(0)("Drug_Committee_Sn").ToString.Trim()
                    drGrid("計畫起日") = Me.dtpProjectEffectDate.GetUsDateStr()
                    drGrid("計畫迄日") = Me.dtpProjectEndDate.GetUsDateStr()
                    drGrid("收據抬頭") = dsDB.Tables(strTableDB).Rows(0)("Receipt_Title").ToString.Trim()
                    drGrid("聯絡人") = dsDB.Tables(strTableDB).Rows(0)("Contact_Name").ToString.Trim()
                    drGrid("聯絡人電話") = dsDB.Tables(strTableDB).Rows(0)("Contact_Tel").ToString.Trim()
                    drGrid("聯絡人電話(M)") = dsDB.Tables(strTableDB).Rows(0)("Contact_Tel_Mobile").ToString.Trim()
                    drGrid("FAX") = dsDB.Tables(strTableDB).Rows(0)("Contact_Fax").ToString.Trim()
                    drGrid("聯絡人E-Mail") = dsDB.Tables(strTableDB).Rows(0)("Contact_Email").ToString.Trim()
                    drGrid("郵遞區號") = dsDB.Tables(strTableDB).Rows(0)("Contact_Postal_Code").ToString.Trim()
                    drGrid("聯絡人住址") = dsDB.Tables(strTableDB).Rows(0)("Contact_Address").ToString.Trim()
                    If dsDB.Tables(strTableDB).Rows(0)("Dis_Rate").ToString.Trim <> "" Then
                        drGrid("折數") = dsDB.Tables(strTableDB).Rows(0)("Dis_Rate")
                    End If
                    If dsDB.Tables(strTableDB).Rows(0)("Add_Rate").ToString.Trim <> "" Then
                        drGrid("分成") = dsDB.Tables(strTableDB).Rows(0)("Add_Rate")
                    End If
                    drGrid("備註") = dsDB.Tables(strTableDB).Rows(0)("Memo").ToString.Trim()
                    '20110310 add by yunfei
                    drGrid("建立者") = drGrid2("建立者")
                    drGrid("建立時間") = drGrid2("建立時間")
                    drGrid("修改者") = dsDB.Tables(strTableDB).Rows(0)("Modified_User").ToString.Trim()
                    drGrid("修改時間") = DateUtil.TransDateToROC(dsDB.Tables(strTableDB).Rows(0)("Modified_Time"))
                    '20110418 ADD BY YUNFEI
                    ' "合約機構請款類型", "是否參考折扣及記帳檔"
                    drGrid("是否參考折扣及記帳檔") = dsDB.Tables(strTableDB).Rows(0)("Is_Use_Set").ToString.Trim
                    drGrid("合約機構請款類型") = dsDB.Tables(strTableDB).Rows(0)("Contract_Type_Id").ToString.Trim

                    dsGrid.Tables(strTableDB).Rows.Add(drGrid)
                    '同步更新Grid內容
                    updateDataGridView(iButtonFlag, dsGrid)
                End If
            Else
                '無符合條件資料被修改
                'MessageHandling.showWarnByKey("CMMCMMB010")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showWarnMsg("CMMCMMB010", New String() {})
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
    Public Function deleteData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.DELETE
        Dim blnReturnFlag As Boolean = True
        Dim iCount As Integer = 0
        '創建Grid更新用DataSet和DataRow
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        Dim drGrid2 As DataRow = dsGrid.Tables(strTableDB).NewRow()

        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            '執行刪除
            iCount = objPub.deletePUBContractByPK(Me.txtContractCode.Text.ToString.Trim, Me.cmbSubIdentityCode.SelectedValue.ToString.Trim)

            If iCount > 0 Then
                Dim dtGrid As DataTable = dgvShowData.DataSource
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("合約機關代碼"), dtGrid.Columns("身份二代號")}
                If dtGrid.Rows.Contains(New Object() {Me.txtContractCode.Text.Trim, Me.cmbSubIdentityCode.SelectedValue.ToString.Trim}) Then
                    CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    drGrid2 = dtGrid.Rows.Find(New Object() {Me.txtContractCode.Text.Trim, Me.cmbSubIdentityCode.SelectedValue.ToString.Trim})
                    dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    '定位行
                    ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                End If
            Else
                '無符合條件資料被刪除
                'MessageHandling.showWarnByKey("CMMCMMB011")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showWarnMsg("CMMCMMB011", New String() {})
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
    ''' <remarks>True 失敗;False 成功</remarks>
    Private Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean
        Try
            Dim blnReturnFlag As Boolean = False
            Dim strErrMsg1 As StringBuilder = New StringBuilder
            Dim strErrMsg2 As StringBuilder = New StringBuilder

            '設定需要檢查的欄位
            Dim ctlTxtContractCode As Control = Me.txtContractCode
            Dim ctlTxtContractName As Control = Me.txtContractName
            Dim ctlCmbSubIdentityCode As Control = Me.cmbSubIdentityCode
            Dim ctlDtpProjectEffectDate As Control = Me.dtpProjectEffectDate
            Dim ctlDtpProjectEndDate As Control = Me.dtpProjectEndDate

            Dim ctlObjFocus As Control = ctlTxtContractCode
            '清除欄位背景色
            cleanFieldsColor()
            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Me.txtContractCode.Text.Trim <> "" Then
                        If Me.txtContractName.Text.Trim = "" Then
                            If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                            strErrMsg1.Append("合約機關名稱")
                            If blnReturnFlag = False Then
                                ctlObjFocus = ctlTxtContractName
                                Me.txtContractName.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            End If
                            blnReturnFlag = True
                        End If
                    Else
                        If Me.cmbSubIdentityCode.SelectedValue.Trim = "" Then
                            If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                            strErrMsg1.Append("合約機關代碼和隸屬身份二同時")
                            If blnReturnFlag = False Then
                                ctlObjFocus = ctlTxtContractCode
                                Me.cmbSubIdentityCode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                                Me.txtContractCode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            End If
                            blnReturnFlag = True
                        End If
                    End If
                    If Me.dtpProjectEffectDate.GetUsDateStr() > Me.dtpProjectEndDate.GetUsDateStr() Then
                        strErrMsg2.Append("計畫迄日" & "," & "計畫起日")
                        Me.dtpProjectEndDate.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                        If blnReturnFlag = False Then
                            ctlObjFocus = dtpProjectEndDate
                        End If
                        blnReturnFlag = True
                    End If
                Case buttonAction.DELETE
                    If Not fieldCheckNull(ctlTxtContractCode, Control_Type.TextBox) Then
                        strErrMsg1.Append("合約機關代碼")
                        ctlObjFocus = ctlTxtContractCode
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
                    strMsgs(i) = ResourceUtil.getString("CMMCMMB102", New String() {"計畫迄日", "計畫起日"})
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
                MessageHandling.showErrorMsg("CMMCMMB300", New String() {pvtErrorMsg}, "")
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
            Case Control_Type.ComboBox
                Dim objCtl As Syscom.Client.UCL.UCLComboBoxUC = ctl
                If objCtl.SelectedValue.ToString.Trim.Equals("") Then
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
    Public Sub clearData()
        '清除欄位資料
        cleanFieldsValue()
        '清除欄位背景顏色
        cleanFieldsColor()
        CType(dgvShowData.DataSource, DataTable).Clear()
        dgvShowData.Refresh()
    End Sub

    ''' <summary>
    ''' 清除欄位資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsValue()
        Try
            Me.txtContractCode.Text = ""
            Me.txtContractName.Text = ""
            Me.cmbSubIdentityCode.SelectedValue = ""

            Me.txtUpperAmt.Text = ""
            Me.cmbUpperAmtTypeId.SelectedValue = ""
            Me.cmbCheckQuotaId.SelectedValue = ""
            Me.txtProjectDirector.Text = ""
            Me.txtDrugCode.Text = ""
            Me.txtDrugName.Text = ""
            Me.txtDrugCommitteeSn.Text = ""
            Me.dtpProjectEffectDate.Clear()
            Me.dtpProjectEndDate.Clear()
            Me.txtContactName.Text = ""
            Me.txtReceiptTitle.Text = ""
            Me.txtContactTel1.Text = ""
            Me.txtContactTel2.Text = ""
            Me.txtContactTel3.Text = ""
            Me.txtContactTelMobile.Text = ""
            Me.txtContactFax.Text = ""
            Me.txtContactEmail.Text = ""

            '聯絡人地址【UclZipCodeAddress】
            Me.UclZipCodeAddress.SelectedValue = ""
            '清空此欄位后的 地址欄
            Me.UclZipCodeAddress.TxtAddress = ""

            Me.txtDisRate.Text = ""
            Me.txtAddRate.Text = ""
            Me.txtContactEmail.Text = ""
            Me.txtMemo.Text = ""

            Me.chkDC.Checked = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 清除欄位背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsColor()
        Try
            Me.txtContractCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtContractName.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbSubIdentityCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 選中Grid行資料並顯示在輸入區
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub dgvCellClick()
        Try
            '清除欄位背景顏色
            cleanFieldsColor()
            If dgvShowData.CurrentCellAddress.Y >= 0 Then
                Me.txtContractCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("合約機關代碼").Value.ToString.Trim
                Me.txtContractName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("合約機關名稱").Value.ToString.Trim
                Me.cmbSubIdentityCode.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("身份二代號").Value.ToString.Trim

                Me.txtUpperAmt.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("記帳上限金額").Value.ToString.Trim
                Me.cmbUpperAmtTypeId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("方式代號").Value.ToString.Trim
                Me.cmbCheckQuotaId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("額度代號").Value.ToString.Trim
                Me.txtProjectDirector.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("計畫主持人").Value.ToString.Trim
                Me.txtDrugCode.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("計畫藥品").Value.ToString.Trim
                Me.txtDrugName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("計畫藥品名").Value.ToString.Trim
                Me.txtDrugCommitteeSn.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("藥委會編號").Value.ToString.Trim

                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("計畫起日").Value.ToString.Trim <> "" Then
                    Dim strTemp As String = CDate(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("計畫起日").Value).ToString("yyyy/MM/dd HH:mm:ss")
                    Me.dtpProjectEffectDate.SetValue(CDate(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("計畫起日").Value).ToString("yyyy/MM/dd HH:mm:ss"))
                Else
                    Me.dtpProjectEffectDate.Clear()
                End If

                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("計畫迄日").Value.ToString.Trim <> "" Then
                    Dim strTemp As String = CDate(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("計畫迄日").Value).ToString("yyyy/MM/dd HH:mm:ss")
                    Me.dtpProjectEndDate.SetValue(CDate(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("計畫迄日").Value).ToString("yyyy/MM/dd HH:mm:ss"))
                Else
                    Me.dtpProjectEndDate.Clear()
                End If

                Me.txtContactName.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("聯絡人").Value.ToString.Trim
                Me.txtReceiptTitle.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("收據抬頭").Value.ToString.Trim
                '聯絡人電話的分割
                splitTel(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("聯絡人電話").Value.ToString.Trim)

                Me.txtContactTelMobile.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("聯絡人電話(M)").Value.ToString.Trim
                Me.txtContactFax.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("FAX").Value.ToString.Trim

                Me.UclZipCodeAddress.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("郵遞區號").Value.ToString.Trim
                Me.UclZipCodeAddress.TxtAddress = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("聯絡人住址").Value.ToString.Trim

                Me.txtDisRate.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("折數").Value.ToString.Trim
                Me.txtAddRate.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("分成").Value.ToString.Trim
                Me.txtContactEmail.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("聯絡人E-Mail").Value.ToString.Trim
                Me.txtMemo.Text = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("備註").Value.ToString.Trim
                '停用
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("停用").Value.ToString.Trim = "是" Then
                    Me.chkDC.Checked = True
                Else
                    Me.chkDC.Checked = False
                End If
                '20110418 ADD BY YUNFEI
                ' "合約機構請款類型", "是否參考折扣及記帳檔"
                If dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("是否參考折扣及記帳檔").Value.ToString.Trim = "Y" Then
                    Me.chbIsUseSet.Checked = True
                Else
                    Me.chbIsUseSet.Checked = False
                End If
                Me.cmbContractTypeId.SelectedValue = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("合約機構請款類型").Value.ToString.Trim
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
    Private Sub updateDataGridView(ByVal mode As Integer, ByVal ds As DataSet)
        Select Case mode
            Case buttonAction.INSERT
                CType(dgvShowData.DataSource, System.Data.DataTable).Rows.Add(ds.Tables(strTableDB).Rows(0).ItemArray)
            Case buttonAction.UPDATE
                dgvShowData.CurrentRow.SetValues(ds.Tables(strTableDB).Rows(0).ItemArray)
        End Select
    End Sub

    ''' <summary>
    ''' 初始化隸屬身份二
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbSubIdentityCode()
        Dim dsDB As DataSet
        '執行查詢
        dsDB = objPub.queryPUBSubIdentityAll("All")

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count > 0 Then
                    Me.cmbSubIdentityCode.DataSource = dsDB.Tables(0)
                    Me.cmbSubIdentityCode.uclValueIndex = "0"
                    Me.cmbSubIdentityCode.uclDisplayIndex = "0,2"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化記帳上限處理方式
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbUpperAmtTypeId()
        Dim dsDB As DataSet
        '執行查詢
        dsDB = objPub.queryPUBSysCode("51")

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count > 0 Then
                    Me.cmbUpperAmtTypeId.DataSource = dsDB.Tables(0)
                    Me.cmbUpperAmtTypeId.uclValueIndex = "0"
                    Me.cmbUpperAmtTypeId.uclDisplayIndex = "0,1"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化檢查累積記帳額度
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbCheckQuotaId()
        Dim dsDB As DataSet
        '執行查詢
        dsDB = objPub.queryPUBSysCode("52")

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count > 0 Then
                    Me.cmbCheckQuotaId.DataSource = dsDB.Tables(0)
                    Me.cmbCheckQuotaId.uclValueIndex = "0"
                    Me.cmbCheckQuotaId.uclDisplayIndex = "0,1"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化合約機構請款類型
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbContractTypeId()
        Dim dsDB As DataSet
        '執行查詢
        dsDB = objPub.queryPUBSysCode("70")

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(0).Rows.Count > 0 Then
                    Me.cmbContractTypeId.DataSource = dsDB.Tables(0)
                    Me.cmbContractTypeId.uclValueIndex = "0"
                    Me.cmbContractTypeId.uclDisplayIndex = "0,1"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 聯絡電話處理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub splitTel(ByVal strTel As String)
        Try
            Dim strTemp() As String = Split(strTel, "-")
            Dim iLenth As Integer = strTemp.Length
            Select Case iLenth
                Case 1
                    Me.txtContactTel1.Text = ""
                    Me.txtContactTel2.Text = strTemp(0)
                    Me.txtContactTel3.Text = ""
                Case 2
                    Me.txtContactTel1.Text = strTemp(0)
                    Me.txtContactTel2.Text = strTemp(1)
                    Me.txtContactTel3.Text = ""
                Case 3
                    Me.txtContactTel1.Text = strTemp(0)
                    Me.txtContactTel2.Text = strTemp(1)
                    Me.txtContactTel3.Text = strTemp(2)
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.clearInfoMsg()
            If (insertData()) Then
                controlButton(buttonAction.INSERT)

                '將新增的資料選中 
                ScreenUtil.setRowFocusByDataRow(dgvShowData, CType(dgvShowData.DataSource, DataTable).Rows(CType(dgvShowData.DataSource, DataTable).Rows.Count - 1))
                '將選中資料給全局變量 
                pDataRowView = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).DataBoundItem


                'MessageHandling.showInfoByKey("CMMCMMB002")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showInfoMsg("CMMCMMB002", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD002")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMD002", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.clearInfoMsg()
            If (updateData()) Then
                '將選中資料給全局變量 ming 20091013 add
                pDataRowView = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).DataBoundItem
                'MessageHandling.showInfoByKey("CMMCMMB003")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showInfoMsg("CMMCMMB003", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD003")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMD003", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Try
            ScreenUtil.Lock(Me)
            MessageHandling.clearInfoMsg()
            If (queryData()) Then
                controlButton(buttonAction.QUERY)

                If (dgvShowData.CurrentRow IsNot Nothing AndAlso dgvShowData.CurrentRow.Index >= 0) Then
                    '清除選中資料行
                    dgvShowData.CurrentRow.Selected = False
                    '清除選中資料項
                    dgvShowData.CurrentCell = Nothing
                End If
                '清除全局變量 
                pDataRowView = Nothing
                'MessageHandling.showInfoByKey("CMMCMMB001")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.showInfoMsg("CMMCMMB001", New String() {})
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD001")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMD001", New String() {}, "")
        Finally
            ScreenUtil.UnLock(Me)
        End Try
    End Sub

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            clearData()
            '清除全局變量 
            pDataRowView = Nothing

            controlButton(buttonAction.CLEAR)
            MessageHandling.clearInfoMsg()
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showErrorByKey("CMMCMMD006")
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("CMMCMMD006", New String() {}, "")
        End Try
        MessageHandling.clearInfoMsg()
    End Sub

    ''' <summary>
    ''' 根據按下的按鈕控制按鈕的狀態
    ''' </summary>
    ''' <param name="action"></param>
    ''' <remarks></remarks>
    Private Sub controlButton(ByVal action As buttonAction)
        Try
            Select Case action
                Case buttonAction.QUERY, buttonAction.UPDATE, buttonAction.CLEAR
                    initializeButton()
                Case buttonAction.INSERT
                    changedButton()
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化按鈕的狀態
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initializeButton()
        btnInsert.Enabled = True
        btnUpdate.Enabled = False
        btnQuery.Enabled = True
        btnClear.Enabled = True
    End Sub

    ''' <summary>
    ''' 改變按鈕的狀態
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub changedButton()
        btnUpdate.Enabled = True
    End Sub

    ''' <summary>
    ''' 按下DatagridView的cell時,需處理的事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvShowData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShowData.CellClick
        Try
            If (e.RowIndex >= 0) Then
                'GRID點擊后，將選中行給全局變量 
                If dgvShowData.ContainsFocus AndAlso dgvShowData.CurrentCellAddress.Y >= 0 Then
                    pDataRowView = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).DataBoundItem
                End If

                dgvCellClick()
                changedButton()
            End If
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showError(ResourceUtil.getString("HEMCMMB203", New String(0) {"資料"}))
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("HEMCMMB203", New String() {}, "")
        End Try
    End Sub

    ''' <summary>
    ''' 按下DatagridView的Sorted時,需處理的事件 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvShowData_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvShowData.Sorted
        Try
            '排序后更新選中行
            ScreenUtil.setRowFocusByDataRowView(dgvShowData, pDataRowView)
        Catch ex As Exception
            'log.Error(ex.ToString)
            'MessageHandling.showError(ResourceUtil.getString("HEMCMMB203", New String(0) {"資料"}))
            '********************2010/2/9 Modify By Alan**********************
            MessageHandling.showErrorMsg("HEMCMMB203", New String() {}, "")
        End Try
    End Sub
    ''' <summary>
    ''' 焦點在grid上時候，上，下，回車鍵改變選中行資料 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvShowData_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvShowData.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter, Keys.Down, Keys.Up
                If dgvShowData.CurrentCellAddress.Y <> -1 Then
                    dgvCellClick()
                    pDataRowView = dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).DataBoundItem
                End If
        End Select
    End Sub
    ''' <summary>
    ''' 焦點在grid上時候,回車鍵改變選中行資料,避開IUCLMaintainFormUI_KeyDown衝突 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvShowData_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvShowData.KeyDown
        Dim nextIndex As Integer = -1
        Select Case e.KeyCode
            Case Keys.Enter
                nextIndex = dgvShowData.CurrentRow.Index + 1
                If (nextIndex >= 0 And nextIndex < dgvShowData.Rows.Count) Then
                    Me.dgvShowData.Focus()
                    Me.dgvShowData.Rows(nextIndex).Cells(0).Selected = True
                End If
        End Select
    End Sub

    ''' <summary>
    ''' HotKey設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PUBContractUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                '清除
                btnClear_Click(sender, e)
            Case Keys.F12
                '刪除 SF12
                If e.Shift Then
                    'If (btnDelete.Enabled) Then btnDelete_Click(sender, e)
                Else
                    '新增F12
                    If (btnInsert.Enabled) Then btnInsert_Click(sender, e)
                End If
            Case Keys.F10
                '修改
                If (btnUpdate.Enabled) Then btnUpdate_Click(sender, e)
            Case Keys.F1
                '查詢
                btnQuery_Click(sender, e)
            Case Keys.Enter
                Me.ProcessTabKey(True)
        End Select
    End Sub

End Class
