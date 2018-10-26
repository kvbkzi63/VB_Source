'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBExamineUI.vb
'*              Title:	診察費基本檔維護
'*        Description:	診察費基本檔維護介面
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	mark
'*        Create Date:	2009/07/17
'*      Last Modifier:	
'*   Last Modify Date:	
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
Public Class PUBExamineUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

    Dim objPub As IPubServiceManager = Nothing

    '目前使用者的ID
    'Dim currentUserID As String = AppContext.userProfile.userId
    Dim currentUserName As String = AppContext.userProfile.userName
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

    '獲取維護表名
    Dim strTableDB As String = PubExamineDataTableFactory.tableName
    Dim pubSyscodeTableName As String = PubSyscodeDataTableFactory.tableName

    '就醫類型Syscode
    Dim iMedicalTypeId As Integer = 20

    '診察費類別Syscode
    Dim iExamineTypeIdCode As Integer = 508

    '診別Syscode
    Dim iSectionIdCode As Integer = 11

    '獲取維護表字段名
    Dim strColumnNameDB() As String = PubExamineDataTableFactory.columnsName

    '獲取維護表字段長度
    Dim iColumnsLength() As Integer = PubExamineDataTableFactory.columnsLength

    'Grid使用的標題
    Dim columnNameGrid() As String = {"身份二", "初診", "院內科別", "診別", "看診目的", "診察費類別", "批價碼", "停用", _
                                      "建立者", "建立時間", "修改者", "修改時間", _
                                      "身份二DB", "院內科ID", "就醫類型", "就醫類型ID", "看診目的ID", "診察費類別ID", "診別ID", "批價碼ID"}
    '設定隱藏的欄位
    Dim visibleColumnNo() As Integer = {12, 13, 14, 15, 16, 17}

    '資料集類型定義
    Enum DataSet_Type
        Grid = 0
        DB = 1
    End Enum
    '控件類型定義
    Enum Control_Type
        ComboBox
        TextCodeQuery
    End Enum

    ''' <summary>
    ''' 初始化畫面 構建空的Grid 設定欄位長度
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub initialData()
        Try
            '初始化對象
            objPub = PubServiceManager.getInstance

            '構建DataGridView的初始Table
            'Mark By Will dgvShowData.DataSource = genDS(DataSet_Type.Grid).Tables(strTableDB)
            showResult(dgvShowData, genDataSet("dgvShowData"))
            '將DataGridView的欄位隱藏()
            'For i As Integer = 0 To visibleColumnNo.Count - 1
            '    dgvShowData.Columns(visibleColumnNo(i)).Visible = False
            'Next
            Me.chkFirstReg.Checked = False
            '設定Grid滿屏
            dgvShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            '初始化身份二Combox
            Me.initialCmbSubIdentityCode()
            '初始化診別Combox
            initialComboBox(iSectionIdCode)
            '初始化看診目的Combox
            initialComboBox(iMedicalTypeId)
            '初始化診察費類別Combox
            initialComboBox(iExamineTypeIdCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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
                '{"身份二", "初診", "院內科別", "診別", "就醫類型", "診察費類別", "批價碼", "停用", _
                '                     "建立者", "建立時間", "修改者", "修改時間", _
                '                     "身份二DB", "院內科ID", "就醫類型ID", "診察費類別ID", "診別ID", "批價碼ID"}
                Return New String(,) {{"身份二", "身份二", "Y", "N", ""}, _
                                      {"初診", "初診", "Y", "N", ""}, _
                                      {"院內科別", "院內科別", "Y", "N", ""}, _
                                      {"診別", "診別", "Y", "N", ""}, _
                                      {"看診目的", "就醫類型", "Y", "N", ""}, _
                                      {"診察費類別", "診察費類別", "Y", "N", ""}, _
                                      {"批價碼", "批價碼", "N", "N", ""}, _
                                      {"停用", "停用", "Y", "N", ""}, _
                                      {"建立者", "建立者", "Y", "N", ""}, _
                                      {"建立時間", "建立時間", "Y", "N", ""}, _
                                      {"修改者", "修改者", "Y", "N", ""}, _
                                      {"修改時間", "修改時間", "Y", "N", ""}, _
                                      {"身份二DB", "身份二DB", "N", "N", ""}, _
                                      {"院內科ID", "院內科ID", "N", "N", ""}, _
                                      {"看診目的ID", "就醫類型ID", "N", "N", ""}, _
                                      {"診察費類別ID", "診察費類別ID", "N", "N", ""}, _
                                      {"診別ID", "診別ID", "N", "N", ""}, _
                                      {"批價碼ID", "批價碼ID", "N", "N", ""}}

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

    ''' <summary>
    ''' 初始化ComboBox
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialComboBox(ByVal iTypeId As Integer)
        Dim dsDB As DataSet
        '執行查詢
        Dim objPub As IPubServiceManager = PubServiceManager.getInstance
        dsDB = objPub.queryPUBSysCode(iTypeId)

        Try
            If dsDB.Tables.Count > 0 Then
                If dsDB.Tables(pubSyscodeTableName).Rows.Count = 0 Then
                    '查無資料
                    'MessageHandling.showWarnByKey("CMMCMMB000")
                    '********************2010/2/9 Modify By Alan**********************
                    MessageHandling.showWarnMsg("CMMCMMB000", New String() {})
                Else
                    If iTypeId = iSectionIdCode Then
                        '初始化診別
                        Me.cmbSectionId.DataSource = dsDB.Tables(pubSyscodeTableName)
                        Me.cmbSectionId.uclDisplayIndex = "0,1"
                        Me.cmbSectionId.uclValueIndex = "0"
                    ElseIf iTypeId = iExamineTypeIdCode Then
                        '初始化診察費類別
                        Me.cmbExamineTypeId.DataSource = dsDB.Tables(pubSyscodeTableName)
                        Me.cmbExamineTypeId.uclDisplayIndex = "0,1"
                        Me.cmbExamineTypeId.uclValueIndex = "0"
                    ElseIf iTypeId = iMedicalTypeId Then
                        '初始化看診目的
                        Me.cmbMedicalTypeId.DataSource = objPub.getPUBMedicalTypeId().Tables(0).Copy
                        Me.cmbMedicalTypeId.uclDisplayIndex = "0,1"
                        Me.cmbMedicalTypeId.uclValueIndex = "0"
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化身份二
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialCmbSubIdentityCode()
        Dim dsDB As DataSet
        '執行查詢
        dsDB = objPub.queryPUBSubIdentityAll()
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
    ''' 查詢事件
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>True 查詢成功</remarks>
    Public Overrides Function queryData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.QUERY
        Dim blnReturnFlag As Boolean = True
        Dim dsDB As DataSet
        Dim dsGrid As DataSet = genDS(DataSet_Type.Grid)
        Dim strTemp As String = ""
        Dim strFirstReg As String = ""
        If Me.chkFirstReg.Checked Then
            strFirstReg = "Y"
        End If

        '輸入區欄位顏色初始化
        cleanFieldsColor()

        '執行查詢
        dsDB = objPub.queryPUBExamineByCond_L(Me.cmbSubIdentityCode.SelectedValue.Trim.Replace("'", "''"), _
                                             strFirstReg.ToString.Trim.Replace("'", "''"), _
                                             Me.txtDeptCode.uclCodeValue1.Trim.Replace("'", "''"), _
                                             Me.cmbSectionId.SelectedValue.Trim.Replace("'", "''"), _
                                             Me.cmbExamineTypeId.SelectedValue.Trim.Replace("'", "''"), _
                                             Me.cmbMedicalTypeId.SelectedValue.Trim.Replace("'", "''"), _
                                             Me.txtOrderCode.uclCodeValue1.Trim.Replace("'", "''"))
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
                        If dsDB.Tables(strTableDB).Rows(i)("Sub_Identity_Name").ToString.Trim() <> "" Then
                            strTemp = dsDB.Tables(strTableDB).Rows(i)("Sub_Identity_Code").ToString.Trim() & " - " & _
                                      dsDB.Tables(strTableDB).Rows(i)("Sub_Identity_Name").ToString.Trim()
                        Else
                            strTemp = dsDB.Tables(strTableDB).Rows(i)("Sub_Identity_Code").ToString.Trim()
                        End If
                        drGrid(i)("身份二") = strTemp
                        drGrid(i)("身份二DB") = dsDB.Tables(strTableDB).Rows(i)("Sub_Identity_Code").ToString.Trim()

                        If dsDB.Tables(strTableDB).Rows(i)("First_Reg").ToString.Trim = "Y" Then
                            drGrid(i)("初診") = "是"
                        Else
                            drGrid(i)("初診") = ""
                        End If

                        If dsDB.Tables(strTableDB).Rows(i)("Dept_Name").ToString.Trim() <> "" Then
                            drGrid(i)("院內科別") = dsDB.Tables(strTableDB).Rows(i)("Dept_Code").ToString.Trim() & " - " & _
                                                    dsDB.Tables(strTableDB).Rows(i)("Dept_Name").ToString.Trim()
                        Else
                            drGrid(i)("院內科別") = dsDB.Tables(strTableDB).Rows(i)("Dept_Code").ToString.Trim()
                        End If
                        drGrid(i)("院內科ID") = dsDB.Tables(strTableDB).Rows(i)("Dept_Code").ToString.Trim()


                        If dsDB.Tables(strTableDB).Rows(i)("Section_Id_Name").ToString.Trim() <> "" Then
                            drGrid(i)("診別") = dsDB.Tables(strTableDB).Rows(i)("Section_Id").ToString.Trim() & " - " & _
                                                    dsDB.Tables(strTableDB).Rows(i)("Section_Id_Name").ToString.Trim()
                        Else
                            drGrid(i)("診別") = dsDB.Tables(strTableDB).Rows(i)("Section_Id").ToString.Trim()
                        End If
                        drGrid(i)("診別ID") = dsDB.Tables(strTableDB).Rows(i)("Section_Id").ToString.Trim()

                        strTemp = dsDB.Tables(strTableDB).Rows(i)("Medical_Type_Id").ToString.Trim()
                        If Not strTemp.Equals("") Then
                            drGrid(i)("看診目的") = strTemp & " - " & _
                                                    dsDB.Tables(strTableDB).Rows(i)("Medical_Type_Id_Name").ToString.Trim()
                        End If
                        drGrid(i)("就醫類型ID") = dsDB.Tables(strTableDB).Rows(i)("Medical_Type_Id").ToString.Trim()


                        If dsDB.Tables(strTableDB).Rows(i)("Examine_Type_Id_Name").ToString.Trim() <> "" Then
                            drGrid(i)("診察費類別") = dsDB.Tables(strTableDB).Rows(i)("Examine_Type_Id").ToString.Trim() & " - " & _
                                                    dsDB.Tables(strTableDB).Rows(i)("Examine_Type_Id_Name").ToString.Trim()
                        Else
                            drGrid(i)("診察費類別") = dsDB.Tables(strTableDB).Rows(i)("Examine_Type_Id").ToString.Trim()
                        End If
                        drGrid(i)("診察費類別ID") = dsDB.Tables(strTableDB).Rows(i)("Examine_Type_Id").ToString.Trim()

                        If dsDB.Tables(strTableDB).Rows(i)("Order_Name").ToString.Trim() <> "" Then
                            drGrid(i)("批價碼") = dsDB.Tables(strTableDB).Rows(i)("Order_Code").ToString.Trim() & " - " & _
                                                dsDB.Tables(strTableDB).Rows(i)("Order_Name").ToString.Trim()
                        Else
                            drGrid(i)("批價碼") = dsDB.Tables(strTableDB).Rows(i)("Order_Code").ToString.Trim()
                        End If
                        drGrid(i)("批價碼ID") = dsDB.Tables(strTableDB).Rows(i)("Order_Code").ToString.Trim()

                        If dsDB.Tables(strTableDB).Rows(i)("Dc").ToString() = "N" Then
                            drGrid(i)("停用") = "否"
                        Else
                            drGrid(i)("停用") = "是"
                        End If
                        drGrid(i)("建立者") = dsDB.Tables(strTableDB).Rows(i)("Create_User").ToString.Trim()
                        drGrid(i)("建立時間") = dsDB.Tables(strTableDB).Rows(i)("Create_Time")
                        drGrid(i)("修改者") = dsDB.Tables(strTableDB).Rows(i)("Modified_User").ToString.Trim()
                        If dsDB.Tables(strTableDB).Rows(i)("Modified_Time").ToString <> "" Then
                            drGrid(i)("修改時間") = dsDB.Tables(strTableDB).Rows(i)("Modified_Time")
                        End If
                        dsGrid.Tables(strTableDB).Rows.Add(drGrid(i))
                    Next
                    '將查詢到的資料綁定到Grid上
                    'dgvShowData.DataSource = dsGrid.Tables(strTableDB)
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
            drDB("Sub_Identity_Code") = Me.cmbSubIdentityCode.SelectedValue.Trim
            If Me.chkFirstReg.Checked Then
                drDB("First_Reg") = "Y"
            Else
                drDB("First_Reg") = ""
            End If
            drDB("Dept_Code") = Me.txtDeptCode.uclCodeValue1.Trim
            drDB("Medical_Type_Id") = Me.cmbMedicalTypeId.SelectedValue.Trim
            drDB("Examine_Type_Id") = Me.cmbExamineTypeId.SelectedValue.Trim
            drDB("Section_Id") = Me.cmbSectionId.SelectedValue.Trim
            drDB("Order_Code") = Me.txtOrderCode.uclCodeValue1.Trim
            '停用
            If ckbDC.Checked = True Then
                drDB("Dc") = "Y"
            Else
                drDB("Dc") = "N"
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
            iCount = objPub.insertPUBExamine_L(dsDB)

            If iCount > 0 Then
                '將畫面輸入資料塞入Grid中
                Dim strTemp As String = ""
                strTemp = dsDB.Tables(strTableDB).Rows(0)("Sub_Identity_Code").ToString.Trim
                If Not strTemp.Equals("") Then
                    drGrid("身份二") = strTemp & " - " & Me.cmbSubIdentityCode.SelectedItem(2).ToString.Trim
                End If
                drGrid("身份二DB") = dsDB.Tables(strTableDB).Rows(0)("Sub_Identity_Code").ToString.Trim

                If dsDB.Tables(strTableDB).Rows(0)("First_Reg").ToString.Trim = "Y" Then
                    drGrid("初診") = "是"
                Else
                    drGrid("初診") = ""
                End If
                'drGrid("院內科別") = dsDB.Tables(strTableDB).Rows(0)("Dept_Code").ToString.Trim & " - " & Me.txtDeptCode.uclCodeName
                drGrid("院內科別") = Me.txtDeptCode.Text.ToString.Trim
                drGrid("院內科ID") = dsDB.Tables(strTableDB).Rows(0)("Dept_Code").ToString.Trim

                strTemp = dsDB.Tables(strTableDB).Rows(0)("Section_Id").ToString.Trim
                If Not strTemp.Equals("") Then
                    drGrid("診別") = strTemp & " - " & Me.cmbSectionId.SelectedItem(1).ToString.Trim
                End If
                drGrid("診別ID") = dsDB.Tables(strTableDB).Rows(0)("Section_Id").ToString.Trim

                strTemp = dsDB.Tables(strTableDB).Rows(0)("Medical_Type_Id").ToString.Trim()
                If Not strTemp.Equals("") Then
                    drGrid("就醫類型") = strTemp & " - " & Me.cmbMedicalTypeId.SelectedItem(1).ToString.Trim
                End If
                drGrid("就醫類型ID") = dsDB.Tables(strTableDB).Rows(0)("Medical_Type_Id").ToString.Trim()

                strTemp = dsDB.Tables(strTableDB).Rows(0)("Examine_Type_Id").ToString.Trim
                If Not strTemp.Equals("") Then
                    drGrid("診察費類別") = strTemp & " - " & Me.cmbExamineTypeId.SelectedItem(1).ToString.Trim
                End If
                drGrid("診察費類別ID") = dsDB.Tables(strTableDB).Rows(0)("Examine_Type_Id").ToString.Trim

                'drGrid("批價碼") = dsDB.Tables(strTableDB).Rows(0)("Order_Code").ToString.Trim & " - " & Me.txtOrderCode.uclCodeName
                drGrid("批價碼") = Me.txtOrderCode.Text.ToString.Trim
                drGrid("批價碼ID") = dsDB.Tables(strTableDB).Rows(0)("Order_Code").ToString.Trim
                '停用
                If dsDB.Tables(strTableDB).Rows(0)("Dc").ToString.Trim = "N" Then
                    drGrid("停用") = "否"
                Else
                    drGrid("停用") = "是"
                End If
                drGrid("建立者") = dsDB.Tables(strTableDB).Rows(0)("Create_User").ToString.Trim()
                drGrid("建立時間") = DateUtil.TransDateToROC(dsDB.Tables(strTableDB).Rows(0)("Create_Time"))
                drGrid("修改者") = dsDB.Tables(strTableDB).Rows(0)("Modified_User").ToString.Trim()
                drGrid("修改時間") = DateUtil.TransDateToROC(dsDB.Tables(strTableDB).Rows(0)("Modified_Time"))
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
    Public Overrides Function updateData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.UPDATE
        Dim blnReturnFlag As Boolean = True
        Dim strtag As String
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
            drDB("Sub_Identity_Code") = Me.cmbSubIdentityCode.SelectedValue.Trim
            If Me.chkFirstReg.Checked Then
                drDB("First_Reg") = "Y"
                strtag = "是"
            Else
                drDB("First_Reg") = ""
                strtag = ""
            End If
            drDB("Dept_Code") = Me.txtDeptCode.uclCodeValue1.Trim
            drDB("Section_Id") = Me.cmbSectionId.SelectedValue.Trim
            drDB("Medical_Type_Id") = Me.cmbMedicalTypeId.SelectedValue.Trim
            drDB("Examine_Type_Id") = Me.cmbExamineTypeId.SelectedValue.Trim
            drDB("Order_Code") = Me.txtOrderCode.uclCodeValue1.Trim
            '停用
            If ckbDC.Checked = True Then
                drDB("Dc") = "Y"
            Else
                drDB("Dc") = "N"
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
            iCount = objPub.updatePUBExamine_L(dsDB)

            If iCount > 0 Then
                '將畫面輸入資料塞入Grid中
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0).Copy

                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("身份二DB"), dtGrid.Columns("初診"), dtGrid.Columns("院內科ID"), _
                                                      dtGrid.Columns("診別ID"), dtGrid.Columns("診察費類別ID"), _
                                                      dtGrid.Columns("就醫類型ID")}
                Dim objPrimaryKey = New Object() {Me.cmbSubIdentityCode.SelectedValue.Trim, strtag, _
                                          Me.txtDeptCode.uclCodeValue1.Trim, _
                                          Me.cmbSectionId.SelectedValue.Trim, _
                                          Me.cmbExamineTypeId.SelectedValue.Trim, _
                                          Me.cmbMedicalTypeId.SelectedValue.Trim}
                If dtGrid.Rows.Contains(objPrimaryKey) Then
                    'CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                    Dim drGrid2 As DataRow = dtGrid.Rows.Find(objPrimaryKey)
                    'dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                    ''定位行
                    'ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)

                    Dim strTemp As String = ""
                    strTemp = dsDB.Tables(strTableDB).Rows(0)("Sub_Identity_Code").ToString.Trim()
                    If Not strTemp.Equals("") Then
                        drGrid("身份二") = strTemp & " - " & Me.cmbSubIdentityCode.SelectedItem(2).ToString.Trim
                    End If
                    drGrid("身份二DB") = dsDB.Tables(strTableDB).Rows(0)("Sub_Identity_Code").ToString.Trim

                    If dsDB.Tables(strTableDB).Rows(0)("First_Reg").ToString.Trim = "Y" Then
                        drGrid("初診") = "是"
                    Else
                        drGrid("初診") = ""
                    End If
                    'drGrid("院內科別") = dsDB.Tables(strTableDB).Rows(0)("Dept_Code").ToString.Trim & " - " & Me.txtDeptCode.uclCodeName
                    drGrid("院內科別") = Me.txtDeptCode.Text.ToString.Trim
                    drGrid("院內科ID") = dsDB.Tables(strTableDB).Rows(0)("Dept_Code").ToString.Trim

                    strTemp = dsDB.Tables(strTableDB).Rows(0)("Section_Id").ToString.Trim()
                    If Not strTemp.Equals("") Then
                        drGrid("診別") = strTemp & " - " & Me.cmbSectionId.SelectedItem(1).ToString.Trim
                    End If
                    drGrid("診別ID") = dsDB.Tables(strTableDB).Rows(0)("Section_Id").ToString.Trim

                    strTemp = dsDB.Tables(strTableDB).Rows(0)("Medical_Type_Id").ToString.Trim()
                    If Not strTemp.Equals("") Then
                        drGrid("就醫類型") = strTemp & " - " & Me.cmbMedicalTypeId.SelectedItem(1).ToString.Trim
                    End If
                    drGrid("就醫類型ID") = dsDB.Tables(strTableDB).Rows(0)("Medical_Type_Id").ToString.Trim()

                    strTemp = dsDB.Tables(strTableDB).Rows(0)("Examine_Type_Id").ToString.Trim()
                    If Not strTemp.Equals("") Then
                        drGrid("診察費類別") = strTemp & " - " & Me.cmbExamineTypeId.SelectedItem(1).ToString.Trim
                    End If
                    drGrid("診察費類別ID") = dsDB.Tables(strTableDB).Rows(0)("Examine_Type_Id").ToString.Trim

                    'drGrid("批價碼") = dsDB.Tables(strTableDB).Rows(0)("Order_Code").ToString.Trim & " - " & Me.txtOrderCode.uclCodeName
                    drGrid("批價碼") = Me.txtOrderCode.Text.ToString.Trim
                    drGrid("批價碼ID") = dsDB.Tables(strTableDB).Rows(0)("Order_Code").ToString.Trim
                    '停用
                    If dsDB.Tables(strTableDB).Rows(0)("Dc").ToString.Trim = "N" Then
                        drGrid("停用") = "否"
                    Else
                        drGrid("停用") = "是"
                    End If
                    drGrid("建立者") = drGrid2("建立者")
                    drGrid("建立時間") = drGrid2("建立時間")
                    drGrid("修改者") = dsDB.Tables(strTableDB).Rows(0)("Modified_User").ToString.Trim()
                    drGrid("修改時間") = DateUtil.TransDateToROC(dsDB.Tables(strTableDB).Rows(0)("Modified_Time"))
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
    Public Overrides Function deleteData() As Boolean
        Dim iButtonFlag As Integer = buttonAction.DELETE
        Dim blnReturnFlag As Boolean = True
        Dim iCount As Integer = 0
        Dim strFirstReg As String = ""
        Dim strTag As String = ""
        If Me.chkFirstReg.Checked Then
            strFirstReg = "Y"
            strTag = "是"
        End If


        '欄位檢查
        If fieldCheckResult(iButtonFlag) Then
            Return False
        End If

        Try
            '執行刪除
            iCount = objPub.deletePUBExamineByPK_L(Me.cmbSubIdentityCode.SelectedValue.Trim, _
                                                   strFirstReg.ToString.Trim, _
                                                   Me.txtDeptCode.uclCodeValue1.Trim, _
                                                   Me.cmbSectionId.SelectedValue.Trim, _
                                                   Me.cmbExamineTypeId.SelectedValue.Trim, _
                                                   Me.cmbMedicalTypeId.SelectedValue.Trim)

            If iCount > 0 Then
                Dim dtGrid As DataTable = dgvShowData.GetDBDS.Tables(0).Copy
                dtGrid.PrimaryKey = New DataColumn() {dtGrid.Columns("身份二DB"), dtGrid.Columns("初診"), dtGrid.Columns("院內科ID"), _
                                                      dtGrid.Columns("診別ID"), dtGrid.Columns("診察費類別ID"), _
                                                      dtGrid.Columns("就醫類型ID")}
                Dim objPrimaryKey = New Object() {Me.cmbSubIdentityCode.SelectedValue.Trim, strTag, _
                                                  Me.txtDeptCode.uclCodeValue1.Trim, _
                                                  Me.cmbSectionId.SelectedValue.Trim,
                                                  Me._cmbMedicalTypeId.SelectedValue.Trim, _
                                                  Me.cmbExamineTypeId.SelectedValue.Trim}
                'If dtGrid.Rows.Contains(objPrimaryKey) Then
                '    CType(dgvShowData.DataSource, DataTable).AcceptChanges()
                '    Dim drGrid2 As DataRow = dtGrid.Rows.Find(objPrimaryKey)
                '    dgvShowData.CurrentCell = dgvShowData(0, dtGrid.Rows.IndexOf(drGrid2))
                '    '定位行
                '    ScreenUtil.setRowFocusByDataRow(dgvShowData, drGrid2)
                'End If
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
            'Dim strErrMsg3 As StringBuilder = New StringBuilder

            '設定需要檢查的欄位
            Dim ctlCmbMainIdentityId As Control = Me.cmbSubIdentityCode
            Dim ctlTxtDeptCode As Control = Me.txtDeptCode
            Dim ctlCmbSectionId As Control = Me.cmbSectionId
            Dim ctlCmbExamineTypeId As Control = Me.cmbExamineTypeId
            Dim ctlTxtOrderCode As Control = Me.txtOrderCode
            Dim ctlObjFocus As Control = ctlCmbMainIdentityId
            '清除欄位背景色
            cleanFieldsColor()
            '針對五個按鈕的操作，設定須檢查的欄位以及檢查項目 (空白、資料型態)
            Select Case iButtonFlag
                Case buttonAction.INSERT, buttonAction.UPDATE
                    If Not fieldCheckNull(ctlCmbMainIdentityId, Control_Type.ComboBox) Then
                        strErrMsg1.Append("身份二")
                        ctlObjFocus = ctlCmbMainIdentityId
                        blnReturnFlag = True
                    End If
                    If Me.txtDeptCode.Text.Trim.Equals("") Then
                        If Not Me.cmbSectionId.SelectedValue.Trim.Equals("") Then
                            ctlTxtDeptCode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            strErrMsg2.Append("若要輸入診別，需先輸入院內科別代碼！")
                            If blnReturnFlag = False Then
                                ctlObjFocus = ctlTxtDeptCode
                            End If
                            blnReturnFlag = True
                        End If
                    End If
                    If Not fieldCheckNull(ctlCmbExamineTypeId, Control_Type.ComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("診察費類別")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlCmbExamineTypeId
                        End If
                        blnReturnFlag = True
                    End If
                    If Not fieldCheckNull(ctlTxtOrderCode, Control_Type.TextCodeQuery) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("批價碼")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlTxtDeptCode
                        End If
                        blnReturnFlag = True
                    End If
                Case buttonAction.DELETE
                    If Not fieldCheckNull(ctlCmbMainIdentityId, Control_Type.ComboBox) Then
                        strErrMsg1.Append("身份二")
                        ctlObjFocus = ctlCmbMainIdentityId
                        blnReturnFlag = True
                    End If
                    If Me.txtDeptCode.Text.Trim.Equals("") Then
                        If Not Me.cmbSectionId.SelectedValue.Trim.Equals("") Then
                            ctlTxtDeptCode.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                            strErrMsg2.Append("若要輸入診別，需先輸入院內科別代碼！")
                            If blnReturnFlag = False Then
                                ctlObjFocus = ctlTxtDeptCode
                            End If
                            blnReturnFlag = True
                        End If
                    End If
                    If Not fieldCheckNull(ctlCmbExamineTypeId, Control_Type.ComboBox) Then
                        If (strErrMsg1.ToString.Trim.Length > 0) Then strErrMsg1.Append(",")
                        strErrMsg1.Append("診察費類別")
                        If blnReturnFlag = False Then
                            ctlObjFocus = ctlCmbExamineTypeId
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
                If strErrMsg2.Length > 0 Then
                    ReDim Preserve strMsgs(i)
                    strMsgs(i) = strErrMsg2.ToString
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
            Case Control_Type.ComboBox
                If CType(ctl, Syscom.Client.UCL.UCLComboBoxUC).SelectedValue.Trim = "" Then
                    ctl.BackColor = ScreenUtil.BACK_COLOR_ERROR_INPUT
                    Return False
                Else
                    Return True
                End If
            Case Control_Type.TextCodeQuery
                If CType(ctl, UCLTextCodeQueryUI).uclCodeValue1.Trim.Equals("") Then
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
        'CType(dgvShowData.DataSource, DataTable).Clear()
        dgvShowData.ClearDS()
        dgvShowData.Refresh()
    End Sub

    ''' <summary>
    ''' 清除欄位資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cleanFieldsValue()
        Try
            Me.cmbSubIdentityCode.SelectedValue = ""
            Me.txtDeptCode.uclCodeName = ""
            Me.txtDeptCode.uclCodeValue1 = ""
            Me.txtDeptCode.Text = ""
            Me.txtDeptCode.doFlag = True
            Me.cmbSectionId.SelectedValue = ""
            Me.cmbMedicalTypeId.SelectedValue = ""
            Me.cmbExamineTypeId.SelectedValue = ""
            Me.txtOrderCode.uclCodeName = ""
            Me.txtOrderCode.uclCodeValue1 = ""
            Me.txtOrderCode.Text = ""
            Me.txtOrderCode.doFlag = True
            Me.ckbDC.Checked = False
            Me.chkFirstReg.Checked = False
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
            Me.cmbSubIdentityCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtDeptCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbSectionId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbMedicalTypeId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.cmbExamineTypeId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
            Me.txtOrderCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 選中Grid行資料並顯示在輸入區
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub dgvCellClick()
        Dim strTemp As String = ""
        Try
            '清除欄位背景顏色
            cleanFieldsColor()
            If dgvShowData.CurrentCellAddress.Y >= 0 Then
                Dim iRowCnt As Integer = dgvShowData.CurrentCellAddress.Y
                Me.cmbSubIdentityCode.SelectedValue = dgvShowData.Rows(iRowCnt).Cells("身份二DB").Value.ToString.Trim
                If dgvShowData.Rows(iRowCnt).Cells("初診").Value.ToString.Trim = "是" Then
                    Me.chkFirstReg.Checked = True
                Else
                    Me.chkFirstReg.Checked = False
                End If

                Me.txtDeptCode.uclCodeValue1 = dgvShowData.Rows(iRowCnt).Cells("院內科ID").Value.ToString.Trim()
                If Split(dgvShowData.Rows(iRowCnt).Cells("院內科別").Value.ToString.Trim(), " - ").Length > 1 Then
                    Me.txtDeptCode.uclCodeName = Split(dgvShowData.Rows(iRowCnt).Cells("院內科別").Value.ToString.Trim(), " - ")(1)
                End If
                Me.txtDeptCode.doFlag = False
                Me.txtDeptCode.Text = dgvShowData.Rows(iRowCnt).Cells("院內科別").Value.ToString.Trim()

                Me.cmbSectionId.SelectedValue = dgvShowData.Rows(iRowCnt).Cells("診別ID").Value.ToString.Trim
                Me.cmbMedicalTypeId.SelectedValue = dgvShowData.Rows(iRowCnt).Cells("就醫類型ID").Value.ToString.Trim
                Me.cmbExamineTypeId.SelectedValue = dgvShowData.Rows(iRowCnt).Cells("診察費類別ID").Value.ToString.Trim

                Me.txtOrderCode.uclCodeValue1 = dgvShowData.Rows(iRowCnt).Cells("批價碼ID").Value.ToString.Trim()
                If Split(dgvShowData.Rows(iRowCnt).Cells("批價碼").Value.ToString.Trim(), " - ").Length > 1 Then
                    Me.txtOrderCode.uclCodeName = Split(dgvShowData.Rows(iRowCnt).Cells("批價碼").Value.ToString.Trim(), " - ")(1)
                End If
                Me.txtOrderCode.doFlag = False
                Me.txtOrderCode.Text = dgvShowData.Rows(iRowCnt).Cells("批價碼").Value.ToString.Trim()

                If dgvShowData.Rows(iRowCnt).Cells("停用").Value.ToString.Trim = "是" Then
                    Me.ckbDC.Checked = True
                Else
                    Me.ckbDC.Checked = False
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
                dgvShowData.CurrentRow.SetValues(ds.Tables(strTableDB).Rows(0).ItemArray)
        End Select
    End Sub

    ''' <summary>
    ''' 身份二選擇非空時，清除欄位背景顏色
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbMainIdentityId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubIdentityCode.SelectedIndexChanged
        If cmbSubIdentityCode.SelectedValue.Trim <> "" Then
            Me.cmbSubIdentityCode.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        End If
    End Sub

    ''' <summary>
    ''' 診察費類別選擇非空時，清除欄位背景顏色
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbExamineTypeId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbExamineTypeId.SelectedIndexChanged
        If cmbExamineTypeId.SelectedValue.Trim <> "" Then
            Me.cmbExamineTypeId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        End If
    End Sub

    ''' <summary>
    ''' 診別選擇非空時，清除欄位背景顏色
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbSectionId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSectionId.SelectedIndexChanged
        If cmbSectionId.SelectedValue.Trim <> "" Then
            Me.cmbSectionId.BackColor = ScreenUtil.BACK_COLOR_DEFAULT
        End If
    End Sub

    ''' <summary>
    ''' 院內科別代碼的離開事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtDeptCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeptCode.Leave
        If Me.txtDeptCode.Text.Trim.Equals("") Then
            Me.cmbSectionId.SelectedValue = ""
        End If
    End Sub
End Class
