'/*
'*****************************************************************************
'*
'*    Page/Class Name:  統計查詢設定作業
'*              Title:	PubExportSetupUI
'*        Description:	資訊室人員設定”統計查詢項目”資料
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-08-10
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-08-10
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
Imports Syscom.Comm.TableFactory
Imports System.Text
Imports System.Windows.Forms



Public Class PubExportSetupUI
    Inherits Syscom.Client.UCL.BaseFormUI
#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection
    '檔案建立者
    Private globalCreateUser As String = ""

    '空的grid
    Private glbEmptyDT As New DataSet
#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    Dim Pub As IPubServiceManager

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubExportSetupUI
    Public Shared Function GetInstance() As PubExportSetupUI
        If myInstance Is Nothing Then
            myInstance = New PubExportSetupUI
        End If
        Return myInstance
    End Function

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

#Region "     新增 "
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Will,Lin on 2015-8-10</remarks>
    Public Function InsertData() As Boolean

        Try
            Dim returnBoolean As Boolean = False

            ''欄位檢查
            If fieldCheckResult("Insert") Then
                Return False
            End If

            '新增，建立者與修改者為同一人
            Dim InsertDS As DataSet = GetSaveDS(CurrentUserID, CurrentUserID)



            '*******************************************************************************
            '修改 insert 的 Method *********************************************************
            '*******************************************************************************

            '拿掉註解，修改 Insert 方法即可，修改完成後拿掉此行註解 
            '寫入資料庫
            Dim count As Integer = Pub.PUBExportInsertData(InsertDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                Dim queryDS As DataSet = Pub.PUBExportQueryForInsert(Me.ucl_reportId.Text)
                Dim dataDS As New DataSet
                dataDS.Tables.Add(queryDS.Tables(1).Copy)
                showResult(dgv_Export, queryDS)
                showResult(dgv_Export_detail, dataDS)
                '*******************************************************************************




            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
            Return False
        End Try

    End Function

#End Region

#Region "     修改 "

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Will.Lin on 2015-8-5</remarks>
    Public Function updateData() As Boolean

        Dim returnBoolean As Boolean = False
        Try
            '欄位檢查
            If fieldCheckResult("Update") Then
                Return False
            End If

            '修改，建立者與修改者為不同人
            Dim updateDS As DataSet = GetSaveDS(globalCreateUser, CurrentUserID)




            '*******************************************************************************
            '修改 update 的 Method *********************************************************
            '*******************************************************************************

            '拿掉註解，修改 Update 方法即可，修改完成後拿掉此行註解 
            '寫入資料庫
            Dim count As Integer = Pub.PUBExportUpdateData(Me.ucl_reportId.Text, updateDS)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                Dim queryDS As DataSet = Pub.PUBExportMasterDataQuery(Me.ucl_reportId.Text)

                '*******************************************************************************
                '修改  *************************************************************************
                '*******************************************************************************

                '拿掉註解，修改查詢ByPK 方法即可，修改完成後拿掉此行註解 
                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                showResult(dgv_Export, queryDS)
                '*******************************************************************************




            Else

                '無資料被修改
                MessageHandling.ShowWarnMsg("CMMCMMB310", New String() {"修改"})
                returnBoolean = True

            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB913", ex)
        End Try

    End Function

#End Region

#Region "     刪除 "

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Will.Lin on 2015-8-11</remarks>
    Public Function deleteData() As Boolean

        Dim returnBoolean As Boolean


        Try
            '欄位檢查
            If fieldCheckResult("Delete") Then
                Return False
            End If

            '自資料庫刪除
            Dim count As Integer = Pub.PUBExportDeleteData(Me.ucl_reportId.Text)

            '*******************************************************************************




            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                '拿掉註解，修改 清除的控制項 即可，修改完成後拿掉此行註解 
                '刪除成功，清除控制項
                CleanControls(tlp_Main)
                showResult(dgv_Export, genDataSet("dgv_Export"))
                showResult(dgv_Export_detail, genDataSet("dgv_Export_detail"))
            Else
                '無符合條件資料被刪除
                MessageHandling.ShowWarnMsg("CMMCMMB310", New String() {"刪除"})
                returnBoolean = True

            End If

            Return returnBoolean

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
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Private Function QueryData() As Boolean

        Dim returnBoolean As Boolean

        'Dim iButtonFlag As Integer = buttonAction.QUERY

        Try
            '欄位檢查
            If fieldCheckResult("Query") Then
                Return False
            End If

            '查詢成功後儲存的 DS
            Dim queryDS As New DataSet
            queryDS = Pub.PUBExportMasterDataQuery(Me.ucl_reportId.Text)


            '*******************************************************************************




            '有查到 Table 要回傳True
            If CheckHasTable(queryDS) Then

                '如果資料列為零要顯示查無符合條件資料
                If queryDS.Tables(0).Rows.Count = 0 Then

                    MessageHandling.ShowWarnMsg("CMMCMMB933", New String() {})

                End If

                '顯示資料在 Grid 上

                showResult(dgv_Export, queryDS)

                returnBoolean = True

            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB915", ex)
        End Try


    End Function

#End Region

#Region "     清除 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Private Function ClearData() As Boolean

        Try

            Dim returnBoolean As Boolean = False
            CleanControls(tlp_Main)
            showResult(dgv_Export, genDataSet("dgv_Export"))
            showResult(dgv_Export_detail, genDataSet("dgv_Export_detail"))
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


#End Region

#Region "     內部功能 "

#Region "     初始化設定 "

#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Public Sub ShownMe() Handles Me.Shown

        Try

            '載入服務管理員
            LoadServiceManager()

            '載入事件管理員
            LoadEventManager()
            '初始化combobox
            initialComboBox()
            '建構空的grid
            showResult(dgv_Export, genDataSet("dgv_Export"))
            'showResult(dgv_Export_detail, genDataSet("dgv_Export_detail"))
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub


#Region "### 顯示資料(DataGridView) ###"

    ''' <summary>
    ''' 取得欄位顯示的欄位資料
    ''' </summary>
    ''' <param name="dgvName">DataGridView的Name</param>
    ''' <remarks></remarks>
    Private Function getColumnData(ByVal dgvName As String) As String(,)
        Try
        'Array元素Index的對照：Grid欄位顯示名稱、資料庫欄位名稱、顯示與否、(日期欄位D,DT、金額M、數值NO)與否、顯示欄位的長度
        Select Case dgvName
            Case "dgv_Export"
                    '{"報表代碼", "報表名稱", "資料庫連線", "停用", "報表SQL"}
                    Return New String(,) {{"報表代碼", "Report_Id", "Y", "N", "200"},
                                      {"報表名稱", "Report_Name", "Y", "N", "200"},
                                      {"資料庫連線", "ConnectionName", "Y", "N", "250"},
                                      {"停用", "Dc", "Y", "N", "50"},
                                      {"報表SQL", "Report_SQL", "Y", "N", "250"},
                                      {"Footer1", "Footer1", "N", "N", ""},
                                      {"Footer2", "Footer2", "N", "N", ""},
                                      {"Create_User", "Create_User", "N", "N", ""},
                                      {"Modified_User", "Modified_User", "N", "N", ""}}
                Case "dgv_Export_detail"
                    '{"排序", "參數名稱", "參數代號", "參數說明", "元件類型"}
                    Return New String(,) {{"Report_Id", "Report_Id", "N", "N", ""},
                                      {"排序", "Sort_No", "Y", "N", "50"},
                                      {"參數名稱", "Field_Name", "Y", "N", "100"},
                                      {"參數代號", "Field_Code", "Y", "N", "100"},
                                      {"參數說明", "Field_Description", "Y", "N", "140"},
                                      {"元件類型", "Form_Control_Type", "Y", "N", "130"},
                                      {"是否為非必要查詢", "Is_Nreq", "Y", "N", "50"},
                                      {"非必要查詢條件", "Field_Nreq_Cond", "Y", "N", "120"},
                                      {"非必要查詢代號", "Field_Nreq_Code", "Y", "N", "120"},
                                      {"下拉選單資料來源(SQL)", "Cbo_Source_Data", "Y", "N", "120"},
                                      {"刪", "delete", "Y", "N", "50"},
                                      {"Default_Value", "Default_Value", "N", "N", "50"}}
            End Select

            Return Nothing
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB915", ex)
        End Try

    End Function

    ''' <summary>
    ''' 顯示最新的資料在DataGridView
    ''' </summary>
    ''' <param name="dgv"></param>
    ''' <param name="ExportDS">欲顯示的資料</param>
    ''' <remarks></remarks>
    Private Sub showResult(ByVal dgv As UCLDataGridViewUC, ByVal ExportDS As DataSet)
        Try
            'ScreenUtil.showDataGridViewResult(dgv, ds.Tables(0).Copy, getColumnData(dgv.Name), True)

            Dim headerTxtStr As String = ""
            Dim dgvColumn(,) As String = getColumnData(dgv.Name)
            For num As Integer = 0 To dgvColumn.GetUpperBound(0)
                If headerTxtStr.Length > 0 Then
                    headerTxtStr += ","
                End If
                headerTxtStr += dgvColumn(num, 0)
            Next

            Dim gridDS As DataSet = genDataSet(dgv.Name)
            For i As Int32 = 0 To ExportDS.Tables(0).Rows.Count - 1
                Dim dr As DataRow = gridDS.Tables(0).NewRow
                For Each c As DataColumn In ExportDS.Tables(0).Columns
                    If gridDS.Tables(0).Columns.Contains(c.ColumnName) Then
                        dr(c.ColumnName) = ExportDS.Tables(0).Rows(i).Item(c.ColumnName)
                    End If
                Next
                gridDS.Tables(0).Rows.Add(dr)
            Next

            Select Case dgv.Name
                Case "dgv_Export"

                    dgv_Export.uclHeaderText = headerTxtStr
                    dgv_Export.Initial(gridDS)
                    setDataGridViewVisibleColumnAndColumnWidth(dgv_Export)

                Case "dgv_Export_detail"

                    '子表單grid初始化
                    Dim hashTable As New Hashtable()
                    Dim cbo_controlTypeCell As New ComboBoxCell
                    Dim txt_SortNo As New TextBoxCell
                    Dim txt_FieldName As New TextBoxCell
                    Dim txt_FieldCode As New TextBoxCell
                    Dim txt_FieldDescription As New TextBoxCell
                    Dim btn_deleteCell As New ButtonCell
                    Dim CellDS As New DataSet
                    '各欄位基本設定
                    txt_SortNo.uclTextType = TextBoxCell.uclTextTypeData.Integer_Type
                    txt_SortNo.MaxLength = 2
                    txt_FieldCode.MaxLength = 20
                    txt_FieldName.MaxLength = 20
                    txt_FieldDescription.MaxLength = 50
                    '元件類型
                    If CheckHasValue(PubServiceManager.getInstance.queryPUBSysCode("50001")) Then
                        CellDS.Tables.Add(PubServiceManager.getInstance.queryPUBSysCode("50001").Tables(0).Copy)
                        cbo_controlTypeCell.Ds = CellDS.Copy
                        cbo_controlTypeCell.DisplayIndex = "2,1"
                        cbo_controlTypeCell.ValueIndex = "2"
                    End If


                    '設定刪除按鈕
                    btn_deleteCell.Text = "刪除"

                    '塞入基本資料
                    hashTable.Add(-1, gridDS)
                    '填入變型的cell元件
                    hashTable.Add(1, txt_SortNo)
                    hashTable.Add(2, txt_FieldName)
                    hashTable.Add(3, txt_FieldCode)
                    hashTable.Add(4, txt_FieldDescription)
                    hashTable.Add(5, cbo_controlTypeCell)
                    hashTable.Add(6, New CheckBoxCell)
                    hashTable.Add(7, New TextBoxCell)
                    hashTable.Add(8, New TextBoxCell)
                    hashTable.Add(10, btn_deleteCell)
                    '初始化表身grid
                    dgv_Export_detail.uclHeaderText = headerTxtStr
                    dgv_Export_detail.Initial(hashTable)
                    setDataGridViewVisibleColumnAndColumnWidth(dgv_Export_detail)
            End Select





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
        Using dt As New DataTable(dgvName)

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
        Dim gblColumnVisibleDgv As String = ""
        Dim clnObj(,) As String = getColumnData(uclDgv.Name)
        For num As Integer = 0 To clnObj.GetUpperBound(0)
            If clnWidthStr.Length > 0 Then
                clnWidthStr &= ","
            End If

            If clnObj(num, 4).Length.Equals(0) Then
                clnWidthStr &= "1"
            Else
                clnWidthStr &= clnObj(num, 4)
            End If
            If clnObj(num, 2).Equals("Y") Then
                gblColumnVisibleDgv &= num & ","
            End If

        Next


        uclDgv.uclVisibleColIndex = gblColumnVisibleDgv.Substring(0, gblColumnVisibleDgv.Length - 1)
        uclDgv.uclColumnWidth = clnWidthStr

    End Sub
#End Region

#End Region

#Region "     載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
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
    ''' <remarks>by Will,Lin on 2015-8-10</remarks>
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
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
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

#Region "     *初始化 - ComboBox "

    ''' <summary>
    ''' 初始化 - ComboBox
    ''' </summary>
    ''' <remarks>by Will.Lin on 2015-8-5</remarks>
    Private Sub initialComboBox()

        Try
            'glbControlType = PubServiceManager.getInstance.queryPUBSysCode("50001").Tables(0).Copy

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - ComboBox"})
        End Try

    End Sub

#End Region

#End Region

#Region "     必填檢查 "


#Region "     *欄位檢查 - True 檢查不通過;False 檢查通過 "

    ''' <summary>
    ''' 欄位檢查 - True 檢查不通過;False 檢查通過
    ''' </summary>
    ''' <remarks>by Will.Lin on 2015-8-5</remarks>
    Public Function fieldCheckResult(ByVal chkType As String) As Boolean

        Dim returnBoolean As Boolean = False

        '儲存要顯示 Error 字串
        Dim stbErrorCollection As StringBuilder = New StringBuilder

        Try



            '*******************************************************************************
            '如果上方的TableLayputPanel 命名為 tlp_Main 則不用修改  ************************
            '*******************************************************************************

            '拿掉註解，修改 清除欄位底色的控制項 即可，修改完成後拿掉此行註解 
            '清除傳入控制項的所有內含的控制項的欄位底色
            '清除欄位底色
            CleanControlsBackcolor(tlp_Main)

            '*******************************************************************************



            '*******************************************************************************************************************
            '修改成要設定檢查的控制項、檢查未通過的顯示名稱 EX: 護理站未輸入 只要設定成 [護理站] 即可  *************************
            '本檢查只會檢查有沒有值，如果是其他的檢查需求，須另行增加!  ********************************************************
            '*******************************************************************************************************************

            '設定檢查的控制項、檢查未通過的顯示名稱
            Dim objCheck1 As UCLTextBoxUC = ucl_reportId
            Dim errorStr1 As String = "報表代號"


            '*******************************************************************************************************************




            Select Case chkType

                '新增/修改時的檢查
                Case "Insert", "Update"

                    '報表代號 欄位檢查並設定檢查結果
                    If ucl_reportId.Text = "" Then
                        stbErrorCollection.Append("報表代號 、")
                        returnBoolean = True
                    End If

                    If CheckHasValue(dgv_Export_detail.GetDBDS) Then
                        For Each dr As DataRow In dgv_Export_detail.GetDBDS.Tables(0).Rows
                            If dr("Form_Control_Type").ToString.Trim = "ComboBox" AndAlso dr("Cbo_Source_Data").ToString.Trim = "" Then
                                stbErrorCollection.Append("下拉選單來源、")
                                returnBoolean = True
                                Exit For
                            End If
                        Next
                    End If

                    '刪除時的檢查
                Case "Delete"
                    If ucl_reportId.Text = "" Then
                        stbErrorCollection.Append("報表代號 、")
                        returnBoolean = True
                    End If
                    '*********************************************************************************************************************


            End Select

            '欄位check錯誤
            If returnBoolean Then

                Dim finalErrorString As String = stbErrorCollection.ToString

                '有值
                If finalErrorString.Length > 0 Then

                    '去掉最後一個逗號
                    finalErrorString = finalErrorString.Substring(0, finalErrorString.Length - 2)

                    finalErrorString = finalErrorString & "不得為空"

                    MessageHandling.ShowErrorMsg("CMMCMMB300", finalErrorString)

                End If

            End If

            Return returnBoolean

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"欄位檢查 - True 檢查不通過;False 檢查通過"})
        End Try

    End Function

#End Region


#End Region

#Region "     事件集合 "

#Region "     *表身刪除事件"
    Private Sub dgv_Export_detail_CellClick(sender As DataGridView, e As DataGridViewCellEventArgs) Handles dgv_Export_detail.CellClick
        'TODO - Button Clicked - Execute Code Here
        If dgv_Export_detail.Rows.Count <= 1 Then Exit Sub
        Select Case e.ColumnIndex
            Case 9
                If dgv_Export_detail.GetDBDS().Tables(0).Rows(e.RowIndex).Item("Form_Control_Type").ToString.Equals("ComboBox") Then
                    Dim ui As New UCLQuestionDialogUI(UCLQuestionDialogUI.CallType.TextBox, "輸入下拉選單來源SQL")
                    ui.SetData(New StringBuilder(dgv_Export_detail.GetDBDS().Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex).ToString))
                    dgv_Export_detail.GetDBDS().Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex) = ui.ShowDialog
                    dgv_Export_detail.GetGridDS().Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex) = dgv_Export_detail.GetDBDS().Tables(0).Rows(e.RowIndex).Item(e.ColumnIndex)
                End If
            Case 10
                dgv_Export_detail.Rows.Remove(dgv_Export_detail.Rows(e.RowIndex))

        End Select
    End Sub
#End Region

#Region "     *資料被點選時的相應動作 "

    ''' <summary>
    ''' 資料被點選時的相應動作
    ''' </summary>
    ''' <remarks>by Will,Lin on 2015-8-10</remarks>
    Public Sub dgvExport_CellClick() Handles dgv_Export.CellClick

        Try


            '清除欄位背景顏色
            CleanControlsBackcolor(tlp_Main)
            '********************************************************************************

            '被點選的資料列大於零，才執行動作
            If dgv_Export.CurrentCellAddress.Y >= 0 Then
                '*************************************************************************************************************************
                '設定點選後，畫面上方要跟著異動的控制項，譬如說 TextBox 的文字，Combobox 的 select Value *********************************
                '*************************************************************************************************************************
                '取得查詢資料的表身明細
                Dim queryDS As DataSet = Pub.PUBExportDetailDataQuery(dgv_Export.Rows(dgv_Export.CurrentCellAddress.Y).Cells("Report_Id").Value)
                If queryDS.Tables.Count > 0 AndAlso queryDS.Tables(0).Rows.Count > 0 Then
                    showResult(dgv_Export_detail, queryDS)
                Else
                    showResult(dgv_Export_detail, genDataSet("dgv_Export_detail"))
                End If

                '報表代號
                ucl_reportId.Text = StringUtil.nvl(dgv_Export.Rows(dgv_Export.CurrentCellAddress.Y).Cells("Report_Id").Value)
                '報表名稱
                ucl_reportName.Text = StringUtil.nvl(dgv_Export.Rows(dgv_Export.CurrentCellAddress.Y).Cells("Report_Name").Value)
                '資料庫連線
                ucl_connectionName.Text = StringUtil.nvl(dgv_Export.Rows(dgv_Export.CurrentCellAddress.Y).Cells("ConnectionName").Value)

                '停用
                If StringUtil.nvl(dgv_Export.Rows(dgv_Export.CurrentCellAddress.Y).Cells("Dc").Value) = "Y" Then
                    rbt_dcY.Checked = True
                Else
                    rbt_dcN.Checked = True
                End If
                'SQL
                ucl_reportSql.Text = StringUtil.nvl(dgv_Export.Rows(dgv_Export.CurrentCellAddress.Y).Cells("Report_SQL").Value)

                '設定建立者的資料 - 必須要填寫!
                globalCreateUser = StringUtil.nvl(dgv_Export.Rows(dgv_Export.CurrentCellAddress.Y).Cells("Create_User").Value)

                '*************************************************************************************************************************




            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"資料被點選時的相應動作"})
        End Try

    End Sub

#End Region




#End Region

#Region "     取得存檔的Dataset資料 "

    ''' <summary>
    ''' 取得要存檔的Dataset
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Will,Lin on 2015-8-10</remarks>
    Private Function GetSaveDS(ByVal inputCreateUser As String, ByVal inputModifiedUser As String) As DataSet

        Dim ExportDS As DataSet
        Dim ExportDtlDS As DataSet
        Try

            '產生要存檔的Dataset
            ExportDS = genDataSet("dgv_Export")
            ExportDtlDS = genDataSet("dgv_Export_detail")
            ExportDS.Tables.Add(ExportDtlDS.Tables(0).Clone)
            Dim drSave As DataRow = ExportDS.Tables(0).NewRow()


            '*************************************************************************************************************************
            '設定 要儲存的資料 *******************************************************************************************************
            '*************************************************************************************************************************
            '設定表頭資料
            drSave("Report_Id") = nvl(ucl_reportId.Text)
            drSave("Report_Name") = nvl(ucl_reportName.Text)
            drSave("ConnectionName") = nvl(ucl_connectionName.Text)
            If Me.rbt_dcY.Checked Then
                drSave("Dc") = "Y"
            ElseIf rbt_dcN.Checked Then
                drSave("Dc") = "N"
            End If
            drSave("Report_SQL") = nvl(ucl_reportSql.Text)
            drSave("Footer1") = nvl(txt_Footer1.Text)
            drSave("Footer2") = nvl(txt_Footer2.Text)
            drSave("Create_User") = inputCreateUser
            drSave("Modified_User") = inputModifiedUser
            ExportDS.Tables(0).Rows.Add(drSave)
            '取得表身資料

            If dgv_Export_detail.GetDBDS.Tables(0).Rows.Count > 1 Then
                For Each dr As DataRow In dgv_Export_detail.GetDBDS.Tables(0).Rows
                    If dr("Sort_No").ToString.Trim <> "" AndAlso
                       dr("Field_Name").ToString.Trim <> "" AndAlso
                       dr("Field_Code").ToString.Trim <> "" AndAlso
                       dr("Form_Control_Type").ToString.Trim <> "" Then
                        drSave = ExportDS.Tables(1).NewRow()
                        drSave("Report_Id") = Me.ucl_reportId.Text
                        drSave("Sort_No") = dr("Sort_No")
                        drSave("Field_Name") = dr("Field_Name")
                        drSave("Field_Code") = dr("Field_Code")
                        drSave("Field_Description") = dr("Field_Description")
                        drSave("Form_Control_Type") = dr("Form_Control_Type")
                        drSave("Is_Nreq") = dr("Is_Nreq")
                        drSave("Field_Nreq_Cond") = dr("Field_Nreq_Cond")
                        drSave("Field_Nreq_Code") = dr("Field_Nreq_Code")
                        drSave("Cbo_Source_Data") = dr("Cbo_Source_Data")

                        ExportDS.Tables(1).Rows.Add(drSave)
                    End If
                Next
            End If

            Return ExportDS

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得要存檔的Dataset"})
        End Try

    End Function



#End Region

#Region "     清除功能 "



#End Region

#Region "     按鍵鎖定、熱鍵功能設定 "

#Region "     主要功能的按鍵鎖定，避免重複Click造成資料或UI出問題 "

#Region "     新增 鎖定功能 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Private Sub btn_Insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Insert.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (InsertData()) Then

                '左下方顯示 新增 成功
                ShowInfoMsg("CMMCMMB301", "新增")

            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增 鎖定功能"})
        Finally
            '解除螢幕鎖定
            UnLock(Me)
        End Try

    End Sub

#End Region

#Region "     修改 鎖定功能 "

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="Sender">按鈕物件</param>
    ''' <param name="e">事件</param>
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
    Private Sub btn_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Update.Click

        '鎖定螢幕
        Lock(Me)
        Try

            '清除左下方訊息欄
            ClearInfoMsg()

            If (UpdateData()) Then

                '左下方顯示 修改 成功
                ShowInfoMsg("CMMCMMB301", "修改")

            End If

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch fex As FaultException
            Throw fex
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"修改 鎖定功能"})
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
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
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

            '使用到WCF服務的時候必須要抓取 FaultException 
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
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
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

            '使用到WCF服務的時候必須要抓取 FaultException 
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
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
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

            '使用到WCF服務的時候必須要抓取 FaultException 
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
    ''' <remarks>by Will,Lin on 2015-08-10</remarks>
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

                        '新增

                        If (btn_Insert.Enabled) Then

                            btn_Insert.PerformClick()

                        End If

                    End If

                Case Keys.F10

                    '修改
                    If btn_Update.Enabled Then
                        btn_Update.PerformClick()
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

