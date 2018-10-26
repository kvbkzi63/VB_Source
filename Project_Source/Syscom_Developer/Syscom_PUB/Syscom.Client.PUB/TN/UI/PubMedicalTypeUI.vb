'/*
'*****************************************************************************
'*
'*    Page/Class Name:  看診目的基本檔維護作業
'*              Title:	PubMedicalTypeUI
'*        Description:	1.新增 2.修改 3.刪除 4.查詢 5.清除
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Eddie,Lu
'*        Create Date:	2015-11-11
'*      Last Modifier:	Eddie,Lu
'*   Last Modify Date:	2015-11-11
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

'請修改成 TableFactory 所在的Utility
Imports Syscom.Comm.TableFactory

'請修改成使用到的Servicefactory
Imports Syscom.Client.Servicefactory


Public Class PubMedicalTypeUI
    Inherits IUCLMaintainFormUI

#Region "     變數宣告 "

#Region "全域變數宣告"

    Dim gblCboData As DataSet = Nothing

#End Region

#Region "     *Table 欄位 "

    '*******************************************************************************
    '修改 欄位等相關資訊   *********************************************************
    '*******************************************************************************

    '存檔的Table欄位
    Private gblColumnNameDB As String() = PubMedicalTypeDataTableFactory.columnsName

    '存檔的Table Name
    Private gblTableName As String = PubMedicalTypeDataTableFactory.tableName

    '空的DT，清空資料使用
    Private gblEmptyDT As DataTable = PubMedicalTypeDataTableFactory.getDataTable

    '要顯示在畫面上的Grid 中文標頭，不顯示的也要有名稱
    Private gblColumnTextDgv As String = "看診目的,看診目的名稱,看診目的管控分類,預設優待身分,預設合約機構1,預設合約機構2," & _
                                         "預設部分負擔,預設卡號,預設IC卡就醫類別,預設案件分類,停用,建立者,建立時間,修改者,修改時間," & _
                                         "兒科排序,外科排序,內科排序,耳鼻喉科排序,排序泌尿科,復健科排序,住院排序," & _
                                         "是否產生掛號費,是否產生診察費,是否產生藥服費,門診排序,急診排序"

    '要顯示在畫面上的Grid 欄位寬度，不顯示的設0
    Private gblColumnWidthDgv As String = "80,150,80,50,100,100," & _
                                          "50,80,80,80,80,150,80,150," & _
                                          "50,50,50,50,50,50,50," & _
                                          ",50,50,50,50,50"

    '要顯示在畫面上的Grid 欄位Index
    Private gblColumnVisibleDgv As String = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26"

    '*******************************************************************************

#End Region

#Region "     *使用的service宣告 "

    '*******************************************************************************
    '依呼叫的 service 修改    ******************************************************
    '*******************************************************************************

    '定義使用的service介面
    Dim Pub As IPubServiceManager

    '*******************************************************************************

#End Region

#Region "     主要功能 "

#Region "     *按鈕事件 "

#Region "     *新增 "

    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <returns >Boolean</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Overrides Function InsertData() As Boolean

        Try
            Dim returnBoolean As Boolean = False

            Dim iButtonFlag As Integer = buttonAction.INSERT

            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '新增，建立者與修改者為同一人
            Dim InsertDS As DataSet = GetSaveDS(CurrentUserID, CurrentUserID)


            '寫入資料庫
            Dim count As Integer = Pub.PUBMedicalTypeinsert(InsertDS)


            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                updateDataGridView(iButtonFlag, Pub.PUBMedicalTypequery(txtMedicalTypeId.Text, txtMedicalTypeName.Text, cboMedicalTypeCtrlId.SelectedValue, cboDisidentityCode.SelectedValue, cboContractCode1.SelectedValue, cboContractCode2.SelectedValue, cboPartCode.SelectedValue, txtCardSn.Text, cboICMedicalTypeId.SelectedValue, cboCaseTypeId.SelectedValue, txtPEDSort.Text, txtSURSort.Text, txtMEDSort.Text, txtENTSort.Text, txtUROSort.Text, txtREHSort.Text, txtIPDSort.Text, txtOPDSort.Text, txtEMGSort.Text))


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

#Region "     *修改 "

    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Overrides Function updateData() As Boolean

        Dim returnBoolean As Boolean = False

        Dim iButtonFlag As Integer = buttonAction.UPDATE

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '修改，建立者與修改者為不同人
            Dim updateDS As DataSet = GetSaveDS(globalCreateUser, CurrentUserID)

            '寫入資料庫
            Dim count As Integer = Pub.PUBMedicalTypeupdate(updateDS)


            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True
                '根據修改成功後的PK Value，查詢取得單筆資料(Query by PK )，然後更新畫面上的Grid
                updateDataGridView(iButtonFlag, Pub.PUBMedicalTypequery(txtMedicalTypeId.Text, txtMedicalTypeName.Text, cboMedicalTypeCtrlId.SelectedValue, cboDisidentityCode.SelectedValue, cboContractCode1.SelectedValue, cboContractCode2.SelectedValue, cboPartCode.SelectedValue, txtCardSn.Text, cboICMedicalTypeId.SelectedValue, cboCaseTypeId.SelectedValue, txtPEDSort.Text, txtSURSort.Text, txtMEDSort.Text, txtENTSort.Text, txtUROSort.Text, txtREHSort.Text, txtIPDSort.Text, txtOPDSort.Text, txtEMGSort.Text))


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

#Region "     *刪除 "

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Overrides Function deleteData() As Boolean

        Dim returnBoolean As Boolean

        Dim iButtonFlag As Integer = buttonAction.DELETE

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '自資料庫刪除
            Dim count As Integer = Pub.PUBMedicalTypedelete(txtMedicalTypeId.Text)


            '有寫入資料要回傳True
            If count > 0 Then

                returnBoolean = True

                '刪除成功，清除控制項
                CleanControls(tlp_Main)

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

#Region "     *查詢 "

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Overrides Function queryData() As Boolean

        Dim returnBoolean As Boolean

        Dim iButtonFlag As Integer = buttonAction.QUERY

        Try
            '欄位檢查
            If fieldCheckResult(iButtonFlag) Then
                Return False
            End If

            '查詢成功後儲存的 DS
            Dim queryDS As DataSet

            '查詢 
            If txtMedicalTypeId.Text <> "" Or txtMedicalTypeName.Text <> "" Or cboMedicalTypeCtrlId.SelectedValue <> "" Or cboDisidentityCode.SelectedValue <> "" Or cboContractCode1.SelectedValue <> "" Or cboContractCode2.SelectedValue <> "" Or cboPartCode.SelectedValue <> "" Or txtCardSn.Text <> "" Or cboICMedicalTypeId.SelectedValue <> "" Or cboCaseTypeId.SelectedValue <> "" Or txtPEDSort.Text <> "" Or txtSURSort.Text <> "" Or txtMEDSort.Text <> "" Or txtENTSort.Text <> "" Or txtUROSort.Text <> "" Or txtREHSort.Text <> "" Or txtIPDSort.Text <> "" Or txtOPDSort.Text <> "" Or txtEMGSort.Text <> "" Then
                '全部參數傳入
                '整數欄位若為空字串,則帶入9999
                If txtPEDSort.Text = "" Then
                    txtPEDSort.Text = "9999"
                End If
                If txtSURSort.Text = "" Then
                    txtSURSort.Text = "9999"
                End If
                If txtMEDSort.Text = "" Then
                    txtMEDSort.Text = "9999"
                End If
                If txtENTSort.Text = "" Then
                    txtENTSort.Text = "9999"
                End If
                If txtUROSort.Text = "" Then
                    txtUROSort.Text = "9999"
                End If
                If txtREHSort.Text = "" Then
                    txtREHSort.Text = "9999"
                End If
                If txtIPDSort.Text = "" Then
                    txtIPDSort.Text = "9999"
                End If
                If txtOPDSort.Text = "" Then
                    txtOPDSort.Text = "9999"
                End If
                If txtEMGSort.Text = "" Then
                    txtEMGSort.Text = "9999"
                End If
                queryDS = Pub.PUBMedicalTypequery(txtMedicalTypeId.Text, txtMedicalTypeName.Text, cboMedicalTypeCtrlId.SelectedValue, cboDisidentityCode.SelectedValue, cboContractCode1.SelectedValue, cboContractCode2.SelectedValue, cboPartCode.SelectedValue, txtCardSn.Text, cboICMedicalTypeId.SelectedValue, cboCaseTypeId.SelectedValue, CType(txtPEDSort.Text, Integer), CType(txtSURSort.Text, Integer), CType(txtMEDSort.Text, Integer), CType(txtENTSort.Text, Integer), CType(txtUROSort.Text, Integer), CType(txtREHSort.Text, Integer), CType(txtIPDSort.Text, Integer), CType(txtOPDSort.Text, Integer), CType(txtEMGSort.Text, Integer))
                '查詢完畢再清空
                If txtPEDSort.Text = "9999" Then
                    txtPEDSort.Text = ""
                End If
                If txtSURSort.Text = "9999" Then
                    txtSURSort.Text = ""
                End If
                If txtMEDSort.Text = "9999" Then
                    txtMEDSort.Text = ""
                End If
                If txtENTSort.Text = "9999" Then
                    txtENTSort.Text = ""
                End If
                If txtUROSort.Text = "9999" Then
                    txtUROSort.Text = ""
                End If
                If txtREHSort.Text = "9999" Then
                    txtREHSort.Text = ""
                End If
                If txtIPDSort.Text = "9999" Then
                    txtIPDSort.Text = ""
                End If
                If txtOPDSort.Text = "9999" Then
                    txtOPDSort.Text = ""
                End If
                If txtEMGSort.Text = "9999" Then
                    txtEMGSort.Text = ""
                End If
            Else
                '全空則全查
                queryDS = Pub.PUBMedicalTypequeryAll()
            End If


            '有查到 Table 要回傳True
            If CheckHasTable(queryDS) Then

                '如果資料列為零要顯示查無符合條件資料
                If queryDS.Tables(0).Rows.Count = 0 Then

                    MessageHandling.ShowWarnMsg("CMMCMMB933", New String() {})

                End If

                '顯示資料在 Grid 上
                UCLScreenUtil.ShowDgv(dgvShowData, queryDS, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)

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

#Region "     *清除 "

    ''' <summary>
    ''' 清除
    ''' </summary>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Overrides Sub clearData()

        Try

            '清除傳入控制項的所有內含的控制項
            CleanControls(tlp_Main)
            dgvShowData.ClearDS()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB916", ex)
        End Try

    End Sub

#End Region

#End Region

#End Region

#Region "     內部功能 "

#Region "     *初始化設定 "



#Region "     *初始化 - 畫面 - 繼承UCLMaintainUI "

    ''' <summary>
    ''' 初始化畫面 - 繼承UCLMaintainUI
    ''' </summary>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Overrides Sub initialData()

        Try

            '載入服務管理員
            LoadServiceManager()

            '初始化 - DataGridView
            ShowDgv()

            '取得ComboBox資料
            gblCboData = Pub.PUBMedicalTypequeryCboData()

            '初始化 - ComboBox
            initialComboBox()

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB990", ex)
        End Try

    End Sub

#End Region

#Region "     顯示空的Dataset 在　Grid 上 "

    ''' <summary>
    ''' 顯示空的Dataset 在　Grid 上
    ''' </summary>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Private Sub ShowDgv()

        Try

            '顯示空的Dataset 在　Grid 上
            UCLScreenUtil.ShowDgv(dgvShowData, gblEmptyDT, gblColumnTextDgv, gblColumnWidthDgv, gblColumnVisibleDgv, False)

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - DataGridView"})
        End Try

    End Sub

#End Region

#Region "     *初始化 - ComboBox "

    ''' <summary>
    ''' 初始化 - ComboBox
    ''' </summary>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Private Sub initialComboBox()

        Try

            '***********************************************************************************************************
            '視需要進行修改，如果一次要取得多個 ComboBox，請取一個DS 回來，內包含各個DataTable，不可呼叫WCF多次 ********
            '***********************************************************************************************************

            '取得 Combobox的 資料
            Dim cboDS As DataSet = gblCboData

            '檢查資料來源
            If CheckHasTable(cboDS, "20") Then

                '設定資料來源
                cboMedicalTypeCtrlId.Initial(cboDS.Tables("20"))
                cboMedicalTypeCtrlId.uclDisplayIndex = "0,1"

            End If

            '檢查資料來源
            If CheckHasTable(cboDS, "PUB_Dis_Identity") Then

                '設定資料來源
                cboDisidentityCode.Initial(cboDS.Tables("PUB_Dis_Identity"))
                cboDisidentityCode.uclDisplayIndex = "0,1"

            End If

            '檢查資料來源
            If CheckHasTable(cboDS, "PUB_Contract") Then

                '設定資料來源
                cboContractCode1.Initial(cboDS.Tables("PUB_Contract"))
                cboContractCode1.uclDisplayIndex = "0,1"

            End If
            
            '檢查資料來源
            If CheckHasTable(cboDS, "PUB_Contract") Then

                '設定資料來源
                cboContractCode2.Initial(cboDS.Tables("PUB_Contract"))
                cboContractCode2.uclDisplayIndex = "0,1"

            End If

            '檢查資料來源
            If CheckHasTable(cboDS, "PUB_Part") Then

                '設定資料來源
                cboPartCode.Initial(cboDS.Tables("PUB_Part"))
                cboPartCode.uclDisplayIndex = "0,1"

            End If

            '檢查資料來源
            If CheckHasTable(cboDS, "102") Then

                '設定資料來源
                cboICMedicalTypeId.Initial(cboDS.Tables("102"))
                cboICMedicalTypeId.uclDisplayIndex = "0,1"

            End If

            '檢查資料來源
            If CheckHasTable(cboDS, "504") Then

                '設定資料來源
                cboCaseTypeId.Initial(cboDS.Tables("504"))
                cboCaseTypeId.uclDisplayIndex = "0,1"

            End If

            '**********************************************************************************************************

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化 - ComboBox"})
        End Try

    End Sub

#End Region

#Region "     *載入服務管理員 "

    ''' <summary>
    ''' 載入ServiceManager的Instance
    ''' </summary>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Private Sub LoadServiceManager()
        Try



            '*******************************************************************************
            '根據系統別進行修改  ***********************************************************
            '*******************************************************************************

            Pub = PubServiceManager.getInstance()

            '*******************************************************************************




        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"載入服務管理員"})
        End Try

    End Sub

#End Region

#End Region

#Region "     *欄位檢查 "

#Region "     *欄位檢查 - True 檢查不通過;False 檢查通過 "

    ''' <summary>
    ''' 欄位檢查 - True 檢查不通過;False 檢查通過
    ''' </summary>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Function fieldCheckResult(ByVal iButtonFlag As Integer) As Boolean

        Dim returnBoolean As Boolean = False

        '儲存要顯示 Error 字串
        Dim stbErrorCollection As StringBuilder = New StringBuilder

        Try

            '清除傳入控制項的所有內含的控制項的欄位底色
            '清除欄位底色
            CleanControlsBackcolor(tlp_Main)

            '設定檢查的控制項、檢查未通過的顯示名稱
            Dim objCheck1 As TextBox = txtMedicalTypeId
            Dim errorStr1 As String = "看診目的、"




            Select Case iButtonFlag

                '新增/修改時的檢查
                Case buttonAction.INSERT, buttonAction.UPDATE


                    '看診目的 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)




                    '刪除時的檢查
                Case buttonAction.DELETE


                    '看診目的 欄位檢查並設定檢查結果
                    SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)


                    '查詢時的檢查
                Case buttonAction.QUERY

                    '*********************************************************************************************************************
                    '設定查詢要檢查的控制項，修改傳入控制項跟檢查失敗的字串即可，objCheck1 和   errorStr1 ********************************
                    '*********************************************************************************************************************

                    '看診目的 欄位檢查並設定檢查結果
                    'SetCheckResult(objCheck1, errorStr1, stbErrorCollection, returnBoolean)
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

#Region "     *資料被點選時的相應動作 "

    ''' <summary>
    ''' 資料被點選時的相應動作
    ''' </summary>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Public Overrides Sub dgvCellClick()

        Try

            '清除傳入控制項的所有內含的控制項的欄位底色
            '清除欄位背景顏色
            CleanControlsBackcolor(tlp_Main)

            '被點選的資料列大於零，才執行動作
            If dgvShowData.CurrentCellAddress.Y >= 0 Then



                '*************************************************************************************************************************
                '設定點選後，畫面上方要跟著異動的控制項，譬如說 TextBox 的文字，Combobox 的 select Value *********************************
                '*************************************************************************************************************************

                '{"Medical_Type_Id", "Medical_Type_Name", "Medical_Type_Ctrl_Id", "Dis_Identity_Code", "Contract_Code1", _
                '"Contract_Code2", "Part_Code", "Card_Sn", "IC_Medical_Type_Id", "Case_Type_Id", _
                '"Dc", "Create_User", "Create_Time", "Modified_User", "Modified_Time", _
                '"PED_Sort", "SUR_Sort", "MED_Sort", "ENT_Sort", "URO_Sort", _
                '"REH_Sort", "IPD_Sort", "Is_Register_Fee", "Is_Examine", "Is_Pha_Services", _
                ' "OPD_Sort", "EMG_Sort"}

                '設定看診目的的控制項
                txtMedicalTypeId.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Medical_Type_Id").Value)

                '設定看診目的名稱的控制項
                txtMedicalTypeName.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Medical_Type_Name").Value)

                '設定看診目的管控分類的控制項
                cboMedicalTypeCtrlId.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Medical_Type_Ctrl_Id").Value)

                '設定預設優待身分的控制項
                cboDisidentityCode.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Dis_Identity_Code").Value)

                '設定預設合約機構1的控制項
                cboContractCode1.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Contract_Code1").Value)

                '設定預設合約機構2的控制項
                cboContractCode2.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Contract_Code2").Value)

                '設定預設部分負擔的控制項
                cboPartCode.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Part_Code").Value)

                '設定預設卡號的控制項
                txtCardSn.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Card_Sn").Value)

                '設定預設IC卡就醫類別的控制項
                cboICMedicalTypeId.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("IC_Medical_Type_Id").Value)

                '設定預設案件分類的控制項
                cboCaseTypeId.SelectedValue = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Case_Type_Id").Value)

                '設定停用的控制項
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Dc").Value) = "Y" Then
                    chkDc.Checked = True
                Else
                    chkDc.Checked = False
                End If

                '設定兒科排序的控制項
                txtPEDSort.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("PED_Sort").Value)

                '設定外科排序的控制項
                txtSURSort.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("SUR_Sort").Value)

                '設定內科排序的控制項
                txtMEDSort.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("MED_Sort").Value)

                '設定耳鼻喉科排序的控制項
                txtENTSort.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("ENT_Sort").Value)

                '設定泌尿科排序的控制項
                txtUROSort.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("URO_Sort").Value)

                '設定復健科排序的控制項
                txtREHSort.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("REH_Sort").Value)

                '設定住院排序的控制項
                txtIPDSort.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("IPD_Sort").Value)

                '設定是否產生掛號費的控制項
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_Register_Fee").Value) = "Y" Then
                    chkIsRegisterFee.Checked = True
                Else
                    chkIsRegisterFee.Checked = False
                End If

                '設定是否產生診察費的控制項
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_Examine").Value) = "Y" Then
                    chkIsExamine.Checked = True
                Else
                    chkIsExamine.Checked = False
                End If

                '設定是否產生藥服費的控制項
                If StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Is_Pha_Services").Value) = "Y" Then
                    chkIsPhaServices.Checked = True
                Else
                    chkIsPhaServices.Checked = False
                End If

                '設定門診排序的控制項
                txtOPDSort.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("OPD_Sort").Value)

                '設定急診排序的控制項
                txtEMGSort.Text = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("EMG_Sort").Value)

                '設定建立者的資料 - 必須要填寫!
                globalCreateUser = StringUtil.nvl(dgvShowData.Rows(dgvShowData.CurrentCellAddress.Y).Cells("Create_User").Value)

                '*************************************************************************************************************************




            End If

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"資料被點選時的相應動作"})
        End Try

    End Sub

#End Region

#Region "     *取得要存檔的Dataset "

    ''' <summary>
    ''' 取得要存檔的Dataset
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>by Eddie,Lu on 2015-11-11</remarks>
    Private Function GetSaveDS(ByVal inputCreateUser As String, ByVal inputModifiedUser As String) As DataSet

        Dim returnDataSet As DataSet

        Try

            '產生要存檔的Dataset
            returnDataSet = GenDataSet(gblTableName, gblColumnNameDB)

            Dim drSave As DataRow = returnDataSet.Tables(gblTableName).NewRow()


            '*************************************************************************************************************************
            '設定 要儲存的資料 *******************************************************************************************************
            '*************************************************************************************************************************

            '{"Medical_Type_Id", "Medical_Type_Name", "Medical_Type_Ctrl_Id", "Dis_Identity_Code", "Contract_Code1", _
            '"Contract_Code2", "Part_Code", "Card_Sn", "IC_Medical_Type_Id", "Case_Type_Id", _
            '"Dc", "Create_User", "Create_Time", "Modified_User", "Modified_Time", _
            '"PED_Sort", "SUR_Sort", "MED_Sort", "ENT_Sort", "URO_Sort", _
            '"REH_Sort", "IPD_Sort", "Is_Register_Fee", "Is_Examine", "Is_Pha_Services", _
            ' "OPD_Sort", "EMG_Sort"}
            drSave("Medical_Type_Id") = nvl(txtMedicalTypeId.Text)

            drSave("Medical_Type_Name") = nvl(txtMedicalTypeName.Text)
            
            drSave("Medical_Type_Ctrl_Id") = nvl(cboMedicalTypeCtrlId.SelectedValue.ToString)

            drSave("Dis_Identity_Code") = nvl(cboDisidentityCode.SelectedValue.ToString)

            drSave("Contract_Code1") = nvl(cboContractCode1.SelectedValue.ToString)

            drSave("Contract_Code2") = nvl(cboContractCode2.SelectedValue.ToString)

            drSave("Part_Code") = nvl(cboPartCode.SelectedValue.ToString)

            drSave("Card_Sn") = nvl(txtCardSn.Text)

            drSave("IC_Medical_Type_Id") = nvl(cboICMedicalTypeId.SelectedValue.ToString)

            drSave("Case_Type_Id") = nvl(cboCaseTypeId.SelectedValue.ToString)

            If chkDc.Checked Then
                drSave("Dc") = "Y"
            Else
                drSave("Dc") = "N"
            End If
            
            drSave("PED_Sort") = nvl(txtPEDSort.Text)

            drSave("SUR_Sort") = nvl(txtSURSort.Text)

            drSave("MED_Sort") = nvl(txtMEDSort.Text)

            drSave("ENT_Sort") = nvl(txtENTSort.Text)

            drSave("URO_Sort") = nvl(txtUROSort.Text)

            drSave("REH_Sort") = nvl(txtREHSort.Text)

            drSave("IPD_Sort") = nvl(txtIPDSort.Text)

            If chkIsRegisterFee.Checked Then
                drSave("Is_Register_Fee") = "Y"
            Else
                drSave("Is_Register_Fee") = "N"
            End If

            If chkIsExamine.Checked Then
                drSave("Is_Examine") = "Y"
            Else
                drSave("Is_Examine") = "N"
            End If

            If chkIsPhaServices.Checked Then
                drSave("Is_Pha_Services") = "Y"
            Else
                drSave("Is_Pha_Services") = "N"
            End If

            drSave("OPD_Sort") = nvl(txtOPDSort.Text)

            drSave("EMG_Sort") = nvl(txtEMGSort.Text)

            drSave("Create_User") = inputCreateUser

            drSave("Modified_User") = inputModifiedUser

            '*************************************************************************************************************************

            'Create_Time 後端會自動產生

            'Modified_Time 後端會自動產生

            returnDataSet.Tables(gblTableName).Rows.Add(drSave)

            Return returnDataSet

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"取得要存檔的Dataset"})
        End Try

    End Function

#End Region

#End Region

#End Region



End Class

