Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.DataSetUtil
Imports Syscom.Comm.BASE.HospConfigUtil
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.BASE

''' <summary>
''' 程式說明：常用醫令選取
''' 開發人員：Alan
''' 開發日期：2010.12.07
''' </summary>
Public Class UCLOrderFavorDialogUI
    Dim gblHospCode As String = ""         '院區
    Dim gblDebugFlag As Boolean = False    'DebugFlag
    Dim gblShowType As String = "V"        'Grid顯示方式(H：水平拖拉；V：垂直拖拉) 
    Dim gblInitFlag As Boolean = True      '初始化註記
    Dim gblInitCount As Integer = 0        '初始化筆數
    Dim gblSourceType As String = "O"       '門急住別 O:門診 E:急診 I:住院
    Dim gblDoctorCode As String = ""       '醫師代碼
    Dim gblUserId As String = AppContext.userProfile.userId  '操作者
    Dim gblUserDrDeptCode As String = AppContext.userProfile.userDrDeptCode '操作者所屬醫療科別
    Dim gblUserDeptCode As String = AppContext.userProfile.userDeptCode  '操作者所屬行政科別
    Dim gblDeptCode As String = ""         '科別代碼
    Dim gblChartNo As String = ""          '病歷號(可不傳值---For診間判斷病患過敏藥，視作業需求才傳值)
    Dim gblOutpatientSn As String = ""     '門急住號 
    Dim gblFavorTypeId As String = ""      '常用類別代碼(A-診斷D-治療處置D1-復健處置G-衛材E-藥品H1-檢驗H2-檢查J-手術)
    Dim gblDrugType As String = ""         '藥品種類(1:一般藥品, 2:TPN, 3:化療藥,4:疫苗,5:大量點滴)
    Dim gblStation As String = ""          '護理站代碼(For住院處置-全院套裝)
    Dim gblIsChoiceDcOrder As String = "N"  '啟用醫令替代藥註記(For 停用 & 過期醫令)
    '藥品種類細項(For化療藥 1:化療藥, 2:一般藥品, 3:常備藥,4:治療處置, 5:衛材)
    '藥品種類細項(ForTPN 1:TPN, 2:混合)
    Dim gblSubDrugType As String = ""
    Dim glbIsFromOhm As Boolean = False

    Dim gblTreeViewCheckedFlag As Boolean = False

    Dim dsCateDoc As New DataSet        '醫師常用的分類
    Dim dsCateDept As New DataSet       '科常用的分類
    Dim dsCateOrder As New DataSet      '處置常用的分類
    Dim dsOrderName As New DataSet      '藥品英文名稱
    Dim dsChineseName As New DataSet    '藥品中文名稱
    Dim ds As New DataSet               '查詢的結果
    Dim dsInit As New DataSet           '初始化資料
    Dim dsSheet As New DataSet          '表單資料
    Dim gblSheetData As ArrayList       '表單資訊
    Dim gblSheetGroup As String         '表單檢體或部位
    Dim gblIsSelectGroup As Boolean = False
    Dim dsAllergy As New DataSet
    Dim gblCboDept As String = ""
    Dim gblTreeNodeLevel As Integer
    Dim gblTreeSelIndex(3) As Integer
    Dim gblFavorUseType As String = "1" '常用醫令查詢使用類別-1:For 診間 , 2:For 常用維護
    Dim gblFavorId As String = ""       '常用類別 1:個人常用 2:科常用
    Dim gblOrderCode As String          '選取的醫令代碼
    Dim gblRowIndex As Integer = 0
    Dim gblColumnIndex As Integer = 0
    Dim gblSelectAll As Boolean = False
    Dim gblDBClickFlag As Boolean = False
    Dim gblRoleID As String
    Dim gblDataRows As Integer = 0      '查詢筆數
    Dim gblShowRows As Integer = 0      'Grid顯示列數
    Dim gblShowColumns As Integer = 0   'Grid顯示行數
    Dim gblColumnWidth As String        'Grid各欄位寬度
    Dim gblEmgDrugQuery As Boolean = False '急診藥品檢索註記
    Dim gblEmgOpFlag As Boolean = False     '急診手術註記
    Dim gblInpNrsFlag As Boolean = False    '住院全院套裝註記
    Dim gblInpDrpFlag As Boolean = False    '住院大量點滴註記
    Dim gblEmgExam As Boolean = False       '急診檢驗檢查註記
    Dim gblOrgExamDs As DataSet             '急診已開立檢驗檢查單資料
    Dim gblIsReturnLackDrug As Boolean = True '是否回傳缺藥醫令
    Dim gblSheetIndex As Integer = -1
    Dim gblDeptIndex, gblOrderNodeIndex As Integer
    Dim gblClearSelect As Boolean
    Dim gblEmgExamList As New ArrayList         '急診檢驗檢查已開立表單

    '利用 ArrayList 儲存藥品的 OrderName、ChineseName、Color、同藥理藥品
    Dim MedicineOrderName As ArrayList = New ArrayList
    Dim MedicineChineseName As ArrayList = New ArrayList

    Private OMOSourceUI As New Object    '呼叫來源UI

    Dim uclService As IUclServiceManager = UclServiceManager.getInstance

    Private WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance
    '設定已選取Grid
    Dim gblOrderFavorData As New DataSet
    Dim gblFavorcolumnName() As String

    Public Sub New()
        Try
            InitializeComponent()
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Sub New(ByVal DoctorCode As String, ByVal DeptCode As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal FavorTypeId As String, ByVal DrugType As String, ByVal SourceType As String, ByRef OMOSourceUI As Object)
        Try
            InitializeComponent()
            Me.gblSourceType = SourceType
            Me.gblDoctorCode = DoctorCode
            Me.gblDeptCode = DeptCode
            Me.gblChartNo = ChartNo
            Me.gblOutpatientSn = OutpatientSn
            Me.gblFavorTypeId = FavorTypeId
            If FavorTypeId = "D" AndAlso SourceType = "I" Then
                Me.gblStation = DrugType
            Else
                Me.gblDrugType = DrugType
            End If

            If gblDrugType = "3" Then
                gblSubDrugType = "3"
            End If
            Me.OMOSourceUI = OMOSourceUI
            gblFavorUseType = "1"
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Sub New(ByVal DoctorCode As String, ByVal DeptCode As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal FavorTypeId As String, ByVal DrugType As String, _
                   ByVal SubDrugType As String, ByVal SourceType As String, ByRef OMOSourceUI As Object)
        Try
            InitializeComponent()
            Me.gblSourceType = SourceType
            Me.gblDoctorCode = DoctorCode
            Me.gblDeptCode = DeptCode
            Me.gblChartNo = ChartNo
            Me.gblOutpatientSn = OutpatientSn
            Me.gblFavorTypeId = FavorTypeId
            Me.gblDrugType = DrugType
            Me.gblSubDrugType = SubDrugType
            If gblDrugType = "3" And gblSubDrugType = "" Then
                gblSubDrugType = "1"
            End If
            Me.OMOSourceUI = OMOSourceUI
            gblFavorUseType = "1"
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub


    Public Sub New(ByVal IsFromOhm As Boolean, ByVal DoctorCode As String, ByVal DeptCode As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal FavorTypeId As String, ByVal DrugType As String, _
                   ByVal SubDrugType As String, ByVal SourceType As String, ByRef OMOSourceUI As Object)
        Try
            InitializeComponent()
            Me.gblSourceType = SourceType
            Me.gblDoctorCode = DoctorCode
            Me.gblDeptCode = DeptCode
            Me.gblChartNo = ChartNo
            Me.gblOutpatientSn = OutpatientSn
            Me.gblFavorTypeId = FavorTypeId
            Me.gblDrugType = DrugType
            Me.gblSubDrugType = SubDrugType
            If gblDrugType = "3" And gblSubDrugType = "" Then
                gblSubDrugType = "1"
            End If
            Me.OMOSourceUI = OMOSourceUI
            gblFavorUseType = "1"
            Me.glbIsFromOhm = IsFromOhm
            Me.gblUserDeptCode = gblDeptCode
            Me.gblUserDrDeptCode = DoctorCode
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Sub New(ByVal FavorTypeId As String, ByVal DrugType As String, ByVal SourceType As String, ByRef OMOSourceUI As Object)
        Try
            InitializeComponent()
            '為讓程式正常執行，gblDoctorCode、gblDeptCode、gblChartNo隨便給個值
            Me.gblSourceType = "ABC"
            Me.gblDoctorCode = "ABC"
            Me.gblDeptCode = "ABC"
            Me.gblChartNo = "ABC"
            Me.gblFavorTypeId = FavorTypeId
            Me.gblDrugType = DrugType
            If gblDrugType = "3" Then
                gblSubDrugType = "3"
            End If
            Me.OMOSourceUI = OMOSourceUI
            gblFavorUseType = "2"
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Sub New(ByVal FavorTypeId As String, ByVal DrugType As String, ByVal SubDrugType As String, ByVal SourceType As String, ByRef OMOSourceUI As Object)
        Try
            InitializeComponent()
            '為讓程式正常執行，gblDoctorCode、gblDeptCode、gblChartNo隨便給個值
            Me.gblSourceType = "ABC"
            Me.gblDoctorCode = "ABC"
            Me.gblDeptCode = "ABC"
            Me.gblChartNo = "ABC"
            Me.gblFavorTypeId = FavorTypeId
            Me.gblDrugType = DrugType
            Me.gblSubDrugType = SubDrugType
            If gblDrugType = "3" And gblSubDrugType = "" Then
                gblSubDrugType = "1"
            End If
            Me.OMOSourceUI = OMOSourceUI
            gblFavorUseType = "2"
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    '20111205 Add By Alan
    Public Sub New(ByVal DoctorCode As String, ByVal DeptCode As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal FavorTypeId As String, ByVal DrugType As String, ByVal SourceType As String, ByVal OrgDs As DataSet, ByRef OMOSourceUI As Object)
        Try
            InitializeComponent()
            Me.gblSourceType = SourceType
            Me.gblDoctorCode = DoctorCode
            Me.gblDeptCode = DeptCode
            Me.gblChartNo = ChartNo
            Me.gblOutpatientSn = OutpatientSn
            Me.gblFavorTypeId = FavorTypeId
            Me.gblDrugType = DrugType
            If gblDrugType = "3" Then
                gblSubDrugType = "3"
            End If
            Me.OMOSourceUI = OMOSourceUI
            gblFavorUseType = "1"
            gblEmgExam = True
            gblOrgExamDs = OrgDs
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Sub New(ByVal DoctorCode As String, ByVal DeptCode As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal FavorTypeId As String, ByVal DrugType As String, _
                   ByVal SubDrugType As String, ByVal SourceType As String, ByVal FavorUseTypeId As String, ByRef OMOSourceUI As Object)
        Try
            InitializeComponent()
            Me.gblSourceType = SourceType
            Me.gblDoctorCode = DoctorCode
            Me.gblDeptCode = DeptCode
            Me.gblChartNo = ChartNo
            Me.gblOutpatientSn = OutpatientSn
            Me.gblFavorTypeId = FavorTypeId
            Me.gblDrugType = DrugType
            Me.gblSubDrugType = SubDrugType
            If gblDrugType = "3" And gblSubDrugType = "" Then
                gblSubDrugType = "1"
            End If
            Me.OMOSourceUI = OMOSourceUI
            gblFavorUseType = FavorUseTypeId
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Sub SetData(ByVal DoctorCode As String, ByVal DeptCode As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal FavorTypeId As String, ByVal DrugType As String, ByVal SourceType As String, ByRef OMOSourceUI As Object)
        Try
            ' InitializeComponent()
            Me.gblSourceType = SourceType
            Me.gblDoctorCode = DoctorCode
            Me.gblDeptCode = DeptCode
            Me.gblChartNo = ChartNo
            Me.gblOutpatientSn = OutpatientSn
            Me.gblFavorTypeId = FavorTypeId
            Me.gblDrugType = DrugType
            If gblDrugType = "3" Then
                gblSubDrugType = "3"
            End If

            ShowForm()

        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Sub SetData(ByVal DoctorCode As String, ByVal DeptCode As String, ByVal ChartNo As String, ByVal OutpatientSn As String, ByVal FavorTypeId As String, ByVal DrugType As String, ByVal SubDrugType As String, ByVal SourceType As String, ByRef OMOSourceUI As Object)
        Try
            Me.gblSourceType = SourceType
            Me.gblDoctorCode = DoctorCode
            Me.gblDeptCode = DeptCode
            Me.gblChartNo = ChartNo
            Me.gblOutpatientSn = OutpatientSn
            Me.gblFavorTypeId = FavorTypeId
            Me.gblDrugType = DrugType
            Me.gblSubDrugType = SubDrugType
            If gblDrugType = "3" And gblSubDrugType = "" Then
                gblSubDrugType = "1"
            End If

            ShowForm()

        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub ShowForm()
        Try
            If HospConfigUtil.HospConfig = HospConfigUtil.hospConfigList.Tw_Kmuh Then
                gblHospCode = "KMUH"
            End If

            Me.Visible = False
            '------For Test------
            If gblFavorTypeId = "" Then
                gblSourceType = "E"
                gblFavorUseType = "1"
                gblDebugFlag = True

                ''2016-10-22 Modidfy By Alan,Tsai---[醫師]改為Login ID
                'gblDoctorCode = "A03598" '"006684" '"006626" '"025162"   '"027071" '"618185"
                gblUserId = "A09233"
                gblDoctorCode = gblUserId

                gblUserDrDeptCode = "09"
                gblUserDeptCode = "JJ"
                gblDeptCode = gblUserDrDeptCode      '"71"

                gblChartNo = "" '"00050005"
                gblOutpatientSn = "" '"O20101111000001"
                gblFavorTypeId = "E"
                gblDrugType = "1"
                gblSubDrugType = "1"
                gblRoleID = ""
                gblStation = "06B"

                'gblFavorUseType = "2"
                'gblDebugFlag = True
                'gblDoctorCode = "ABC"   '"603714" '"618185"
                'gblDeptCode = "ABC"     '"71"
                'gblChartNo = "ABC"
                'gblFavorTypeId = "D"
                'gblDrugType = "1"


            End If
            '---------------------

            If AppContext.userProfile.userMemberOf.ToUpper.Contains("OMO_NURSE") Then
                gblRoleID = "OMO_NURSE"
            End If

            '科常用先Disable
            cbo_Dept.Enabled = False
            cbo_Dept2.Enabled = False

            '檢查檢驗選項設定
            If gblFavorTypeId <> "H" AndAlso gblFavorTypeId <> "H1" AndAlso gblFavorTypeId <> "H2" Then
                rbt_FavorId4.Enabled = False
            Else
                rbt_FavorId4.Enabled = True
            End If

            Dim pvtqueryData As New DataSet
            Dim pvtFavorCategory As New DataSet 'ComboBox選項值-常用分類

            '------------------測試資料-Start--------------------
            Dim columnNameDB1() As String = {"Favor_Type_Id", "Doctor_Code", "Dept_Code", "Chart_No", "Drug_Type", "FavorUse_Type", "Sub_Drug_Type", "Source_Type", "User_Dept_Code"}
            pvtqueryData = genDataSet(pvtqueryData, "Query_Data", columnNameDB1)
            Dim row1 As DataRow
            row1 = pvtqueryData.Tables(0).Rows.Add()
            row1("Favor_Type_Id") = gblFavorTypeId

            '2016-10-22 Modidfy By Alan,Tsai---[醫師]改為Login ID
            gblDoctorCode = gblUserId
            row1("Doctor_Code") = gblDoctorCode

            '2016-10-22 Modidfy By Alan,Tsai---[科別]改為userDrDeptCode，若查無資料，則另以userDeptCode再次查詢
            gblDeptCode = gblUserDrDeptCode
            row1("Dept_Code") = gblDeptCode
            row1("User_Dept_Code") = gblUserDeptCode

            row1("Chart_No") = gblChartNo
            row1("Drug_Type") = gblDrugType
            row1("FavorUse_Type") = gblFavorUseType
            row1("Sub_Drug_Type") = gblSubDrugType
            row1("Source_Type") = gblSourceType

            If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "J" Then
                gblEmgOpFlag = True
            Else
                gblEmgOpFlag = False
            End If


            '查詢初始化資料
            dsInit = uclService.queryOMOOrderFavorInit(pvtqueryData)

            If dsInit IsNot Nothing AndAlso dsInit.Tables IsNot Nothing AndAlso dsInit.Tables(0).Rows.Count > 0 Then
                gblIsChoiceDcOrder = dsInit.Tables("PUB_Config").Rows(0).Item("Config_Value").ToString.Trim
            End If

            If dsAllergy Is Nothing AndAlso dsAllergy.Tables(0) Is Nothing Then
                dsAllergy.Tables.Add(dsInit.Tables(5).Copy)
            End If

            '設定分類-預設為醫師
            If gblFavorUseType = "1" Then
                setCategory(dsInit.Tables(0).Copy)
            End If

            '設定科室
            Dim pvtDataRow As DataRow = dsInit.Tables(2).NewRow
            pvtDataRow("Dept_Code") = "++"
            pvtDataRow("Dept_Name") = "共通"
            pvtDataRow("Dept_En_Name") = "共通"
            dsInit.Tables(2).Rows.InsertAt(pvtDataRow, 0)
            'Dim pvtDataRow1 As DataRow = dsInit.Tables(2).NewRow
            'pvtDataRow1("Dept_Code") = "OP"
            'pvtDataRow1("Dept_Name") = "手術室"
            'pvtDataRow1("Dept_En_Name") = "手術室"
            'dsInit.Tables(2).Rows.InsertAt(pvtDataRow1, 1)

            If gblDrugType = "3" And gblSubDrugType <> "" Then
                pvtDataRow = dsInit.Tables(2).NewRow
                pvtDataRow("Dept_Code") = "PHCT"
                pvtDataRow("Dept_Name") = "化療"
                pvtDataRow("Dept_En_Name") = "化療"
                dsInit.Tables(2).Rows.InsertAt(pvtDataRow, 1)
            End If

            If gblDrugType = "5" Then
                pvtDataRow = dsInit.Tables(2).NewRow
                pvtDataRow("Dept_Code") = "IVFUse"
                pvtDataRow("Dept_Name") = "大量點滴"
                pvtDataRow("Dept_En_Name") = "大量點滴"
                dsInit.Tables(2).Rows.InsertAt(pvtDataRow, 1)
            End If

            If gblSourceType = "E" And gblDeptCode = "ENR" Then
                Dim pvtDataRow2 As DataRow = dsInit.Tables(2).NewRow
                pvtDataRow2("Dept_Code") = "ENR"
                pvtDataRow2("Dept_Name") = "急診護理計價"
                pvtDataRow2("Dept_En_Name") = "急診護理計價"
                dsInit.Tables(2).Rows.InsertAt(pvtDataRow2, 1)
            End If

            cbo_Dept.DataSource = dsInit.Tables(2).Copy
            cbo_Dept.uclDisplayIndex = "0, 1"
            cbo_Dept.uclValueIndex = "0"

            cbo_Dept2.DataSource = dsInit.Tables(2).Copy
            cbo_Dept2.uclDisplayIndex = "0, 1"
            cbo_Dept2.uclValueIndex = "0"



            If gblFavorTypeId <> "A" Then
                If gblSourceType = "E" Then
                    gblFavorcolumnName = New String() {"Order_Code", "Order_En_Name", "Order_Name", "Dosage", "Dosage_Unit", "Frequency_Code", _
                                              "Usage_Code", "Days", "Qty", "Unit", "Default_Body_Site_Code", "Default_Side_Id", _
                                              "Specimen_Id", "Pharmacy_12_Code", "OPD_Lack_Id", "Nhi_Price", "Own_Price", "Drug_Type", "Order_Type_Id", "Form_Kind_Id", "Show_Name", _
                                              "Doctor_Dept_Code", "Age_Group_Id", "Op_Nameplate_Id", "Is_IVF", "Sheet_Group", "Sheet_Group_Name", "Is_Prior_Review", "Times", "Remark", "EMG_Lack_Id", "Default_Main_Body_Site_Code", "Is_Valid_Order"}
                    '2013-08-08 hujs for emg_lack_id
                Else
                    gblFavorcolumnName = New String() {"Order_Code", "Order_En_Name", "Order_Name", "Dosage", "Dosage_Unit", "Frequency_Code", _
                                                   "Usage_Code", "Days", "Qty", "Unit", "Default_Body_Site_Code", "Default_Side_Id", _
                                                   "Specimen_Id", "Pharmacy_12_Code", "OPD_Lack_Id", "Nhi_Price", "Own_Price", "Drug_Type", "Order_Type_Id", "Form_Kind_Id", "Show_Name", _
                                                   "Doctor_Dept_Code", "Age_Group_Id", "Op_Nameplate_Id", "Is_IVF", "Sheet_Group", "Sheet_Group_Name", "Is_Prior_Review", "Times", "Remark", "Default_Main_Body_Site_Code", "Is_Valid_Order"}
                End If
                '2013-08-08 hujs for emg_lack_id
            Else
                gblFavorcolumnName = New String() {"Icd_Code", "Disease_En_Name", "Disease_Type_Id", "Effect_Date", _
                                                "Disease_Name", "Disease_Hosp_Name", "Majorcare_Code", "Limit_Sex_Id", "Infection_Type_Id", _
                                                "Limit_Age", "Age_Start_Year", "Age_Start_Month", "Age_Start_Day", _
                                                "Age_End_Year", "Age_End_Month", "Age_End_Day", "Is_Exclude_Labdiscount", "Is_Chronic_Disease", _
                                                "Is_Severe_Disease", "Is_Psy_Severe_Disease", "Is_Rare_Diseases", "Is_Major_P", "Is_Minor_P", _
                                                "Is_Mcc", "Is_Cc", "End_Date", "Show_Name", "Is_Valid_Order"}
            End If

            gblOrderFavorData = genDataSet(gblOrderFavorData, "Favor_Data", gblFavorcolumnName)

            Dim hashTable As New Hashtable()

            hashTable.Add(-1, gblOrderFavorData.Copy)
            dgv_Selected.Initial(hashTable)
            If gblFavorTypeId <> "A" Then
                dgv_Selected.uclVisibleColIndex = "0,21"
            Else
                dgv_Selected.uclVisibleColIndex = "0," & gblFavorcolumnName.Length
            End If
            dgv_Selected.uclHeaderText = ",,,,,,,,,,,,,,,,,,,,已選取醫令"
            dgv_Selected.uclColumnWidth = ",,,,,,,,,,,,,,,,,,,,170"
            dgv_Selected.SetColReadOnly(1, True)

            '設定初始化資料
            '2011-08-30 Modify By Alan
            'If gblSourceType <> "O" OrElse gblFavorTypeId <> "H" Then

            '    If gblFavorUseType = "1" Then

            '        If Not ((gblSourceType = "E" OrElse gblSourceType = "I") AndAlso (gblFavorTypeId = "E" OrElse gblFavorTypeId = "H" OrElse gblFavorTypeId = "D")) Then
            '            rbt_FavorId1.Checked = True
            '        End If

            '        If gblFavorTypeId = "J" Then
            '            rbt_FavorId3.Enabled = False
            '            If (gblSourceType = "E" OrElse gblSourceType = "I") Then setCategory(dsInit.Tables(9).Copy)
            '        End If
            '    Else
            '        rbt_FavorId1.Enabled = False
            '        rbt_FavorId2.Enabled = False
            '        rbt_FavorId3.Checked = True
            '    End If

            'Else

            '    '若為門診醫囑開立常用檢驗檢查，則自動預設為『科常用』
            'If gblSourceType = "O" AndAlso gblFavorTypeId = "H" AndAlso gblFavorUseType = "1" Then
            gblInitFlag = False

            If gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" Then
                rbt_FavorId4.Checked = True
            Else
                rbt_FavorId1.Checked = True
            End If

            'Else
            '    rbt_FavorId4.Checked = True
            'End If

            If gblFavorUseType = "2" Then
                rbt_FavorId1.Enabled = False
                rbt_FavorId2.Enabled = False
                rbt_FavorId3.Enabled = False
            End If

            chk_Chinese.Enabled = False
            txt_OrderName.Enabled = False
            btn_Query.Enabled = False

            'End If


            If gblFavorTypeId <> "E" Then
                chk_ScientificName.Enabled = False
                chk_TradenName.Enabled = False
                chk_AliasName.Enabled = False
                chk_ChineseName.Enabled = False
                chk_Normal.Enabled = False
            Else
                chk_ScientificName.Checked = True
                chk_TradenName.Checked = True
                chk_AliasName.Checked = True
                chk_ChineseName.Checked = True
                If gblDrugType <> 2 AndAlso gblDrugType <> 3 Then
                    chk_Normal.Checked = False
                    chk_Normal.Enabled = False
                End If

            End If

            Me.KeyPreview = True '啟用才能觸發快速鍵功能

            gblInitFlag = False

            If gblDrugType = "3" And gblSubDrugType <> "" Then
                If gblSubDrugType = "2" OrElse gblSubDrugType = "3" Then
                    gblDrugType = "1"
                End If
                gblDeptCode = "PHCT"
                rbt_FavorId2.Checked = True
            End If
            gblTreeViewCheckedFlag = False

            'If gblFavorUseType = "2" Then
            btn_Package.Visible = False
            'End If

            If gblRoleID = "OMO_NURSE" Then
                rbt_FavorId2.Checked = True
            End If

            '若為急診且為藥品、檢驗檢查或治療處置，則自動預設為科常用
            If gblSourceType = "E" AndAlso (gblFavorTypeId = "H" OrElse gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" OrElse gblFavorTypeId = "D") Then
                'gblInitFlag = True
                'rbt_FavorId2.Checked = True
                'gblInitFlag = False

                'If gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" Then
                '    rbt_FavorId4.Checked = True

                'Else
                '    If dsInit.Tables("FavorData").Rows(0).Item("Favor_Type_Id") = "2" Then
                '        rbt_FavorId2.Checked = True
                '    ElseIf dsInit.Tables("FavorData").Rows(0).Item("Favor_Type_Id") = "3" Then
                '        gblDeptCode = gblUserDeptCode
                '        rbt_FavorId2.Checked = True
                '    End If
                'End If

            End If

            If gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" Then
                rbt_FavorId4.Checked = True

            Else
                If dsInit.Tables("FavorData").Rows(0).Item("Favor_Type_Id") = "2" Then
                    rbt_FavorId2.Checked = True
                ElseIf dsInit.Tables("FavorData").Rows(0).Item("Favor_Type_Id") = "3" Then
                    gblDeptCode = gblUserDeptCode
                    rbt_FavorId2.Checked = True
                End If
            End If


            '常用類別代碼(A-診斷D-治療處置G-衛材E-藥品H-檢驗檢查J-手術)--'藥品種類(1:一般藥品, 2:TPN, 3:化療藥,4:疫苗)
            Select Case gblFavorTypeId
                Case "D"
                    Me.Text = "常用查詢-治療處置"
                Case "G"
                    Me.Text = "常用查詢-衛材"
                Case "H"
                    Me.Text = "常用查詢-檢驗檢查"
                Case "J"
                    Me.Text = "常用查詢-手術"
                Case "E"
                    Select Case gblDrugType
                        Case "1"
                            Me.Text = "常用查詢-一般藥品"
                        Case "2"
                            Me.Text = "常用查詢-TPN"
                        Case "3"
                            Me.Text = "常用查詢-化療藥"
                        Case "4"
                            Me.Text = "常用查詢-疫苗"
                        Case "5"
                            Me.Text = "常用查詢-大量點滴"
                    End Select
            End Select

            If Not ((gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "A") AndAlso (gblFavorTypeId <> "H" AndAlso gblFavorTypeId <> "H1" AndAlso gblFavorTypeId <> "H2") Then
                If tre_Category IsNot Nothing AndAlso tre_Category.Nodes.Count > 0 Then
                    tre_Category.Nodes(0).BackColor = Color.DeepSkyBlue
                    tre_Category.Nodes(0).ForeColor = Color.White
                End If
            End If

            Me.GroupBox1.Visible = False
            Me.Panel3.Visible = False
            btn_QueryAll.Visible = False

            'If (gblSourceType = "E" OrElse gblSourceType = "I") Then
            '    Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            '    Me.Height = 315
            '    Me.dgv_Selected.Visible = False
            '    Me.Panel1.Width = 952
            '    Me.Panel1.Height = 45
            '    Me.TableLayoutPanel1.Width = 898
            '    Me.FlowLayoutPanel1.Width = 898
            '    Me.btn_QueryAll.Visible = False
            '    Me.FlowLayoutPanel2.Visible = False
            '    Me.FlowLayoutPanel3.Visible = False
            '    Me.FlowLayoutPanel4.Visible = False
            '    Me.FlowLayoutPanel5.Visible = False
            '    Me.FlowLayoutPanel6.Visible = False

            '    If gblFavorTypeId <> "E" AndAlso gblFavorTypeId <> "J" AndAlso gblFavorTypeId <> "A" Then
            '        Me.rbt_Query1.Visible = False
            '        Me.rbt_Query2.Visible = False
            '        Me.btn_Query3.Visible = False
            '        If gblSourceType = "I" Then
            '            rbt_FavorId1.Checked = True
            '        End If
            '    Else
            '        If gblFavorTypeId = "E" Then
            '            Me.GroupBox1.Location = New Point(4, 45)
            '            Me.GroupBox1.Visible = True

            '            Me.Panel2.Location = New Point(4, 80)
            '            Me.Panel2.Height = 230
            '            Me.Panel2.Width = 200

            '            btn_Query3.Enabled = False
            '            If gblDrugType = "5" Then
            '                rbt_FavorId2.Checked = True
            '                cbo_Dept2.SelectedValue = "IVFUse"
            '            End If

            '            Me.Label6.Text = ""
            '            Me.Label6.Width = 180
            '            Me.txt_OrderName2.Visible = False
            '            Me.btn_Query2.Visible = False
            '            Me.rbt_Query1.Visible = False
            '            Me.rbt_Query2.Checked = True
            '            If gblFavorTypeId = "E" AndAlso gblDrugType = "5" Then
            '                Me.btn_Query2_Click(New Object, New System.EventArgs)
            '            End If
            '            txt_OrderName.Text = txt_OrderName2.Text.Trim

            '            '2012-11-16 Add By Alan 住院查詢加入分類Combox
            '            If gblSourceType = "I" Then
            '                Me.Label6.Width = 10
            '                Me.cbo_Station.Visible = True
            '                Me.cbo_Station.Enabled = True
            '                Me.cbo_Station.Width = 150
            '                cbo_Station.DataSource = dsInit.Tables(0).Copy
            '                cbo_Station.uclDisplayIndex = "0"
            '                cbo_Station.uclValueIndex = "0"
            '            End If

            '            If gblSourceType = "I" AndAlso gblFavorTypeId = "E" Then
            '                rbt_FavorId3.Checked = True
            '            Else
            '                rbt_FavorId2.Checked = True
            '            End If

            '            Me.tre_Category.Height = 238
            '            Me.tre_Category.Width = 200

            '        ElseIf gblFavorTypeId = "J" Then
            '            rbt_FavorId1.Enabled = False
            '            rbt_FavorId2.Enabled = False
            '            cbo_Dept2.Enabled = False
            '            cbo_Dept2.SelectedValue = ""

            '            Me.GroupBox1.Visible = False
            '            Me.Panel2.Location = New Point(4, 48)
            '            Me.Panel2.Height = 500
            '            Me.Panel2.Width = 200

            '            btn_Query2.Visible = False
            '            Me.Label6.Text = ""
            '            Me.Label6.Width = 180
            '            Me.txt_OrderName2.Visible = False
            '            Me.tre_Category.Height = 430
            '            Me.tre_Category.Width = 200
            '            rbt_FavorId1.Checked = False
            '            rbt_FavorId2.Checked = False
            '            rbt_FavorId3.Checked = False
            '            rbt_FavorId4.Checked = False
            '            tre_Category.Font = New Font("新細明體", 11)
            '        ElseIf gblFavorTypeId = "A" Then
            '            Me.GroupBox1.Visible = False
            '            Me.Panel2.Location = New Point(4, 48)
            '            Me.Panel2.Height = 500
            '            Me.Panel2.Width = 200

            '            'btn_Query2.Visible = False
            '            'Me.Label6.Text = ""
            '            'Me.Label6.Width = 180
            '            'Me.txt_OrderName2.Visible = False
            '            Me.tre_Category.Height = 430
            '            Me.tre_Category.Width = 200
            '            tre_Category.Font = New Font("新細明體", 11)
            '        End If
            '    End If
            '    Me.TableLayoutPanel2.Location = New Point(202, 48)
            '    If gblSourceType = "I" Then
            '        Me.dgv_FavorData.Height = 190
            '    Else
            '        If gblFavorTypeId = "E" Then
            '            Me.dgv_FavorData.Height = 213
            '        Else
            '            Me.dgv_FavorData.Height = 260
            '        End If

            '    End If

            '    Me.dgv_FavorData.Width = 745
            '    Me.btn_OK.Location = New Point(860, 13)
            '    Me.btn_Query2.Text = "查詢"
            '    Me.btn_Query2.Width = 50
            '    Me.btn_OK.Text = "帶入"
            '    Me.btn_OK.Width = 90
            '    Me.lbl_OrderName.Width = 170
            '    If gblFavorTypeId <> "E" Then
            '        If gblFavorTypeId <> "A" Then
            '            Me.btn_Massrefer.Visible = False
            '            Me.btn_Looks.Visible = False
            '        Else
            '            Me.btn_Massrefer.Visible = False
            '            Me.btn_Looks.Visible = False
            '            Me.btn_Looks.Text = "關閉"
            '            Me.lbl_OrderName.Width = 80
            '            Me.chk_Diabetes.Visible = True
            '            Me.chk_HighBlood.Visible = True
            '        End If
            '    End If
            '    'If gblFavorTypeId <> "H" Then
            '    rbt_FavorId4.Visible = False
            '    'End If

            '    '2013-04-01 Add By Alan-若為住院藥品，則需顯示大量點滴
            '    If gblSourceType = "I" AndAlso gblFavorTypeId = "E" AndAlso gblDrugType <> "2" Then
            '        'rbt_FavorId4.Visible = True
            '        'rbt_FavorId4.Enabled = True
            '        'rbt_FavorId4.Text = "大量點滴"
            '        Me.lbl_OrderName.Width = 80
            '        Me.chk_Diabetes.Visible = True
            '        chk_Diabetes.Text = "大量點滴"
            '        gblInpDrpFlag = True
            '    End If


            '    '2011-08-30 Modify By Alan
            '    If gblFavorTypeId = "D" Or gblFavorTypeId = "H" Then
            '        Me.Panel2.Visible = False
            '        Me.tre_Category.Visible = False
            '        Me.TableLayoutPanel2.Location = New Point(0, 54)
            '        If gblSourceType = "I" Then
            '            'Me.dgv_FavorData.Height = 320
            '            Me.dgv_FavorData.Width = 965
            '        Else
            '            Me.dgv_FavorData.Height = 420
            '            Me.dgv_FavorData.Width = 965
            '        End If

            '        Me.dgv_FavorData.DefaultCellStyle.Font = New Font("新細明體", 10)

            '        '2012-06-01 Add By Alan-若為住院處置，則需顯示全院套裝選項
            '        If gblSourceType = "I" AndAlso gblFavorTypeId = "D" Then
            '            rbt_FavorId4.Visible = True
            '            rbt_FavorId4.Enabled = True
            '            rbt_FavorId4.Text = "全院套裝"
            '            Me.cbo_Station.Visible = True
            '            Me.cbo_Station.Enabled = True
            '            gblInpNrsFlag = True
            '        End If

            '        If gblFavorTypeId = "H" Then
            '            rbt_FavorId4.Visible = True

            '            If gblSourceType = "I" Then
            '                btn_SelAll.Visible = True
            '            End If

            '            If gblEmgExam Then
            '                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            '                Me.Height = 500
            '                rbt_FavorId1.Enabled = False
            '                rbt_FavorId2.Enabled = False
            '                rbt_FavorId3.Enabled = False
            '                rbt_FavorId4.Checked = True
            '                lst_OrgExam.Visible = True
            '                lst_OrgExam.Location = New Point(208, 398)
            '                lst_OrgExam.Width = 746
            '                lst_OrgExam.Height = 84
            '                '自動選取表單&檢體
            '                setExamOrder(gblOrgExamDs.Tables(0).TableName)
            '            End If
            '        End If

            '        If gblFavorTypeId = "D" AndAlso gblDeptCode = "ENR" Then
            '            rbt_FavorId1.Enabled = False
            '            cbo_Dept2.Enabled = False
            '            Me.Label6.Width = 150
            '            btn_UclQueryAll.Visible = False


            '            Me.TableLayoutPanel2.Location = New Point(202, 48)
            '            Me.dgv_FavorData.Height = 300
            '            Me.Panel2.Height = 300
            '            Me.tre_Category.Height = 300

            '            Me.dgv_FavorData.Width = 745
            '            Me.Panel2.Visible = True
            '            Me.tre_Category.Visible = True
            '            Me.Panel2.Location = New Point(4, 45)
            '            Me.Panel2.Width = 200
            '            Me.tre_Category.Width = 200
            '            tre_Category.Font = New Font("新細明體", 11)
            '        End If
            '    ElseIf gblFavorTypeId = "J" OrElse gblFavorTypeId = "A" Then
            '        Me.Height = 500
            '        Me.dgv_FavorData.Height = 500
            '        'If gblFavorTypeId = "A" Then
            '        '    tre_Category.SelectedNode = tre_Category.Nodes(1)
            '        'End If
            '    End If
            'Else
            Me.Panel2.Location = New Point(545, 0)
            Me.Panel2.Height = 159
            Me.Panel2.Width = 177
            Me.tre_Category.Height = 159
            Me.tre_Category.Width = 177

            Me.cbo_Dept2.Visible = False
            Me.Label6.Visible = False
            Me.txt_OrderName2.Visible = False
            Me.btn_Query2.Visible = False
            Me.lbl_OrderName.Visible = False
            Me.btn_Massrefer.Visible = False
            Me.btn_Looks.Visible = False
            'End If

            '2012-12-07 Add By Alan-若為常用處置維護，則需顯示全院套裝選項
            If gblFavorUseType = "2" AndAlso gblFavorTypeId = "D" Then
                rbt_FavorId4.Visible = True
                rbt_FavorId4.Enabled = True
                rbt_FavorId4.Text = "全院套裝"
                Me.cbo_Station.Visible = True
                Me.cbo_Station.Enabled = True
                gblInpNrsFlag = True
                cbo_Station.Width = 90
            End If

            If gblFavorUseType = "2" Then
                TableLayoutPanel2.Width = 720
                dgv_FavorData.Width = 720
                dgv_Selected.Height = 560
                Me.btn_OK.Location = New Point(860, 570)
            End If

            Me.dgv_Selected.Location = New Point(544, 3)
            Me.dgv_Selected.Width = 410
            dgv_Selected.uclColumnWidth = ",,,,,,,,,,,,,,,,,,,,340"

            Me.Panel2.Width = 235
            Me.Panel2.Height = 435
            Me.tre_Category.Width = 235
            Me.tre_Category.Height = 435
            Me.Panel2.Location = New Point(3, 165)

            If gblFavorTypeId <> "E" Then
                chk_AliasName.Visible = False
                chk_ChineseName.Visible = False
                chk_ScientificName.Visible = False
                chk_TradenName.Visible = False
            End If

            chk_Normal.Visible = False
            chk_Chinese.Visible = False

            Me.Visible = True

            '依解析度等比例放大
            If UCLFormUtil.isResizeable Then
                Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
                UCLFormUtil.ReDrawForm(Me)
                UCLFormUtil.ReSetLocToScreenCenter(Me)
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 設定 FavorTypeId
    ''' </summary>
    ''' <param name="FavorTypeId"></param>
    ''' <remarks></remarks>
    Public Sub setFavorTypeId(ByVal FavorTypeId As String)
        Try
            Me.gblFavorTypeId = FavorTypeId
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 設定 DrugType
    ''' </summary>
    ''' <param name="DrugType"></param>
    ''' <remarks></remarks>
    Public Sub setDrugType(ByVal DrugType As String)
        Try
            Me.gblDrugType = DrugType
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    '查詢
    Private Sub btn_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query.Click
        TableLayoutPanel2.Visible = False

        Try
            Dim OrderCode As String = ""
            Dim pvtExeQueryFlag As Boolean = True

            UCLScreenUtil.Lock(Me)

            ds.Clear()
            lbl_OrderName.Text = ""

            txt_Pharmacy12Code.Text = ""
            txt_NhiPrice.Text = ""
            txt_OwnPrice.Text = ""

            '2011-09-01 Add By Alan-急診藥品檢索欄位檢核
            If rbt_Query2.Checked Then gblEmgDrugQuery = True

            If gblEmgDrugQuery Then
                If txt_Index1.Text.Trim = "" AndAlso txt_Index2.Text.Trim = "" AndAlso txt_Index3.Text.Trim = "" AndAlso _
                   txt_Index4.Text.Trim = "" AndAlso txt_Index5.Text.Trim = "" Then
                    'MessageHandling.showErrorMsg("CMMCMMB300", New String() {"檢索不可全為空白"}, "")
                    'txt_Index1.Focus()
                    'pvtExeQueryFlag = False
                    gblEmgDrugQuery = False
                End If

                'If pvtExeQueryFlag Then
                '    If chk_Chinese.Checked = False AndAlso txt_Index1.Text.Trim <> "" AndAlso txt_Index1.Text.Trim.Length < 3 Then
                '        MessageHandling.showErrorMsg("CMMCMMB300", New String() {"檢索至少輸入3碼"}, "")
                '        txt_Index1.Focus()
                '        pvtExeQueryFlag = False
                '    End If

                '    If pvtExeQueryFlag AndAlso chk_Chinese.Checked = False AndAlso txt_Index2.Text.Trim <> "" AndAlso txt_Index2.Text.Trim.Length < 3 Then
                '        MessageHandling.showErrorMsg("CMMCMMB300", New String() {"檢索至少輸入3碼"}, "")
                '        txt_Index2.Focus()
                '        pvtExeQueryFlag = False
                '    End If

                '    If pvtExeQueryFlag AndAlso chk_Chinese.Checked = False AndAlso txt_Index3.Text.Trim <> "" AndAlso txt_Index3.Text.Trim.Length < 3 Then
                '        MessageHandling.showErrorMsg("CMMCMMB300", New String() {"檢索至少輸入3碼"}, "")
                '        txt_Index3.Focus()
                '        pvtExeQueryFlag = False
                '    End If

                '    If pvtExeQueryFlag AndAlso chk_Chinese.Checked = False AndAlso txt_Index4.Text.Trim <> "" AndAlso txt_Index4.Text.Trim.Length < 3 Then
                '        MessageHandling.showErrorMsg("CMMCMMB300", New String() {"檢索至少輸入3碼"}, "")
                '        txt_Index4.Focus()
                '        pvtExeQueryFlag = False
                '    End If

                '    If pvtExeQueryFlag AndAlso chk_Chinese.Checked = False AndAlso txt_Index5.Text.Trim <> "" AndAlso txt_Index5.Text.Trim.Length < 3 Then
                '        MessageHandling.showErrorMsg("CMMCMMB300", New String() {"檢索至少輸入3碼"}, "")
                '        txt_Index5.Focus()
                '        pvtExeQueryFlag = False
                '    End If

                'End If
            End If

            If gblEmgOpFlag Then
                pvtExeQueryFlag = False
            End If

            If gblEmgDrugQuery = False AndAlso gblDrugType <> "2" AndAlso gblDrugType <> "3" AndAlso gblDrugType <> "4" AndAlso rbt_FavorId3.Checked Then

                If gblFavorTypeId <> "E" Then
                    If gblFavorTypeId <> "D" OrElse gblDeptCode = "ENR" Then
                        If gblSourceType = "I" AndAlso (gblFavorTypeId = "H" AndAlso gblFavorTypeId = "H1" AndAlso gblFavorTypeId = "H2") Then
                            If chk_Chinese.Checked = False AndAlso txt_OrderName.Text.Trim.Length < 2 Then
                                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"檢索至少輸入2碼"}, "")
                                txt_OrderName.Focus()
                                pvtExeQueryFlag = False
                            ElseIf chk_Chinese.Checked AndAlso txt_OrderName.Text.Trim.Length < 1 Then
                                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"檢索不可為空白"}, "")
                                txt_OrderName.Focus()
                                pvtExeQueryFlag = False
                            End If
                        Else
                            If chk_Chinese.Checked = False AndAlso txt_OrderName.Text.Trim.Length < 3 Then
                                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"檢索至少輸入3碼"}, "")
                                txt_OrderName.Focus()
                                pvtExeQueryFlag = False
                            ElseIf chk_Chinese.Checked AndAlso txt_OrderName.Text.Trim.Length < 1 Then
                                MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"檢索不可為空白"}, "")
                                txt_OrderName.Focus()
                                pvtExeQueryFlag = False
                            End If
                        End If

                    End If
                Else

                    If gblInpDrpFlag = False AndAlso getCategory() = "" Then
                        If chk_Chinese.Checked = False AndAlso txt_OrderName.Text.Trim.Length < 3 Then
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"檢索至少輸入3碼"}, "")
                            txt_OrderName.Focus()
                            pvtExeQueryFlag = False
                        ElseIf chk_Chinese.Checked AndAlso txt_OrderName.Text.Trim.Length < 1 Then
                            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"檢索不可為空白"}, "")
                            txt_OrderName.Focus()
                            pvtExeQueryFlag = False
                        End If
                    End If
                End If
            End If

            If rbt_FavorId2.Checked And pvtExeQueryFlag Then
                If gblSourceType = "O" AndAlso cbo_Dept.SelectedValue.ToString.Trim = "" Then
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"科別不可為空白"}, "")
                    cbo_Dept.Focus()
                    pvtExeQueryFlag = False
                ElseIf (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso cbo_Dept.SelectedValue.ToString.Trim = "" Then
                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"科別不可為空白"}, "")
                    cbo_Dept2.Focus()
                    pvtExeQueryFlag = False
                End If
            End If

            If rbt_FavorId4.Checked Then
                pvtExeQueryFlag = False
            End If


            Dim PharmacyQueryFlag() As String = {"N", "N", "N", "N", "N", "", "N", "", "N", "", "", "", "", ""}

            If chk_ScientificName.Checked Then PharmacyQueryFlag(0) = "Y"

            If chk_TradenName.Checked Then PharmacyQueryFlag(1) = "Y"

            If chk_AliasName.Checked Then PharmacyQueryFlag(2) = "Y"

            If chk_ChineseName.Checked Then PharmacyQueryFlag(3) = "Y"

            If chk_Chinese.Checked Then PharmacyQueryFlag(4) = "Y" '若勾選顯示中文，則採全文檢索搜尋

            If gblFavorTypeId = "E" And rbt_FavorId3.Checked Then
                PharmacyQueryFlag(5) = getCategory() '藥品&全院時，可依藥理分類查詢
            End If


            If chk_Normal.Checked Then PharmacyQueryFlag(6) = "Y"

            PharmacyQueryFlag(7) = gblSubDrugType

            If gblEmgDrugQuery Then
                PharmacyQueryFlag(8) = "Y"
                PharmacyQueryFlag(9) = txt_Index1.Text.Trim
                PharmacyQueryFlag(10) = txt_Index2.Text.Trim
                PharmacyQueryFlag(11) = txt_Index3.Text.Trim
                PharmacyQueryFlag(12) = txt_Index4.Text.Trim
                PharmacyQueryFlag(13) = txt_Index5.Text.Trim
            End If


            If rbt_FavorId1.Checked And pvtExeQueryFlag Then '醫師常用

                If gblInitFlag = False Then
                    ds = uclService.queryOMOOrderFavorByCond3(gblSourceType, "1", gblFavorTypeId, gblDoctorCode, getCategory, OrderCode, txt_OrderName.Text.Trim, gblDrugType, PharmacyQueryFlag, gblChartNo, gblOutpatientSn, gblIsChoiceDcOrder)
                Else
                    If dsInit.Tables(8).Rows(0).Item("Favor_Type_Id").ToString.Trim = "1" Then ds.Tables.Add(dsInit.Tables(7).Copy)
                End If

                '因藥品關聯OPH_Property後會產生多筆，故需再執行下列轉換
                If ds.Tables.Count > 0 Then

                    If gblFavorTypeId = "E" Then
                        ds = MergeRowData(ds, New String() {"Order_Code"}, New String() {"Property_Id"}, " | ")
                    End If

                End If

            ElseIf rbt_FavorId2.Checked And pvtExeQueryFlag Then '科常用

                Dim pvtDeptCode As String = ""
                'If gblSourceType = "O" Then
                pvtDeptCode = cbo_Dept.SelectedValue
                'ElseIf (gblSourceType = "E" OrElse gblSourceType = "I") Then
                '    pvtDeptCode = cbo_Dept2.SelectedValue
                'End If
                If gblInitFlag = False Then
                    ds = uclService.queryOMOOrderFavorByCond3(gblSourceType, "2", gblFavorTypeId, pvtDeptCode, getCategory, OrderCode, txt_OrderName.Text.Trim, gblDrugType, PharmacyQueryFlag, gblChartNo, gblOutpatientSn, gblIsChoiceDcOrder)
                Else
                    If dsInit.Tables(8).Rows(0).Item("Favor_Type_Id").ToString.Trim = "2" Then ds.Tables.Add(dsInit.Tables(7).Copy)
                End If


                '因藥品關聯OPH_Property後會產生多筆，故需再執行下列轉換
                If gblFavorTypeId = "E" Then
                    ds = MergeRowData(ds, New String() {"Order_Code"}, New String() {"Property_Id"}, " | ")
                End If

            ElseIf (rbt_FavorId3.Checked AndAlso pvtExeQueryFlag) Or gblEmgOpFlag Then '一般

                If gblFavorTypeId = "E" Then
                    ds = uclService.queryOPHPharmacyByCond3(gblSourceType, OrderCode, txt_OrderName.Text.Trim, gblDrugType, PharmacyQueryFlag, gblIsChoiceDcOrder)
                    '因藥品關聯OPH_Property後會產生多筆，故需再執行下列轉換
                    ds = MergeRowData(ds, New String() {"Order_Code"}, New String() {"Property_Id"}, " | ")

                ElseIf (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "D" Then
                    '若為急診治療處置時，則自動預設為科常用的++共通
                    If gblDeptCode <> "ENR" Then
                        Dim pvtDeptCode As String = ""
                        If gblSourceType = "O" Then
                            pvtDeptCode = cbo_Dept.SelectedValue
                        ElseIf (gblSourceType = "E" OrElse gblSourceType = "I") Then
                            pvtDeptCode = cbo_Dept2.SelectedValue
                        End If
                        'If gblSourceType = "E" Then
                        '    ds = uclService.queryOMOOrderFavorByCond3(gblSourceType, "2", gblFavorTypeId, pvtDeptCode, getCategory, OrderCode, txt_OrderName.Text.Trim, gblDrugType, PharmacyQueryFlag, gblChartNo, gblOutpatientSn, gblIsChoiceDcOrder)
                        'Else
                        If txt_OrderName.Text.Trim <> "" Then
                            ds = uclService.queryPUBOrderByLanguage3(gblSourceType, OrderCode, txt_OrderName.Text.Trim, gblFavorTypeId, getCategory, "", "", PharmacyQueryFlag(4), gblChartNo, gblOutpatientSn, gblIsChoiceDcOrder)
                        End If
                        'End If

                    Else
                        'For護理計價查詢=>Order_Code傳入固定值'ENR'
                        ds = uclService.queryPUBOrderByLanguage3(gblSourceType, "ENR", txt_OrderName.Text.Trim, gblFavorTypeId, getCategory, "", "", PharmacyQueryFlag(4), gblChartNo, gblOutpatientSn, gblIsChoiceDcOrder)
                    End If

                Else
                    If gblFavorTypeId <> "A" Then
                        If gblEmgOpFlag Then
                            If gblSheetData IsNot Nothing Then
                                ds = uclService.queryPUBOrderByLanguage3(gblSourceType, gblSheetData(1), gblSheetData(2), gblFavorTypeId, getCategory, "", "", PharmacyQueryFlag(4), gblChartNo, gblOutpatientSn, gblIsChoiceDcOrder)
                                pvtExeQueryFlag = True
                            End If
                        Else
                            ds = uclService.queryPUBOrderByLanguage3(gblSourceType, OrderCode, txt_OrderName.Text.Trim, gblFavorTypeId, getCategory, "", "", PharmacyQueryFlag(4), gblChartNo, gblOutpatientSn, gblIsChoiceDcOrder)
                        End If
                    Else
                        If chk_Chinese.Checked Then
                            ds = uclService.queryPUBDiseaseByFavor2(gblSourceType, "", "", txt_OrderName.Text.Trim, "1")
                        Else
                            ds = uclService.queryPUBDiseaseByFavor2(gblSourceType, "", txt_OrderName.Text.Trim, "", "1")
                        End If
                    End If

                End If

            ElseIf rbt_FavorId4.Checked Then '檢驗檢查單位 & 檢驗檢查單

                If (gblSourceType = "I" AndAlso gblFavorTypeId = "E") Then
                    ds = uclService.queryOPHPharmacyByCond3(gblSourceType, OrderCode, txt_OrderName.Text.Trim, "5", PharmacyQueryFlag, gblIsChoiceDcOrder)
                    '因藥品關聯OPH_Property後會產生多筆，故需再執行下列轉換
                    ds = MergeRowData(ds, New String() {"Order_Code"}, New String() {"Property_Id"}, " | ")
                    pvtExeQueryFlag = True

                ElseIf (gblSourceType = "I" AndAlso gblFavorTypeId = "D") OrElse (gblFavorUseType = "2" AndAlso gblFavorTypeId = "D") Then

                    'ds = uclService.queryOMOFavorForINPNurse("D1", cbo_Station.SelectedValue, txt_OrderName.Text.Trim)
                    ds = uclService.querySTAPackageDataByCategory("D1", cbo_Station.SelectedValue, getCategory, txt_OrderName.Text.Trim)
                    pvtExeQueryFlag = True

                Else
                    If gblInitFlag = False Then
                        If gblFavorTypeId = "H1" Then
                            dsSheet = uclService.queryOMOOrderFavorSheetDept2(gblSourceType, gblFavorTypeId, "")
                        Else
                            dsSheet = uclService.queryOMOOrderFavorSheetDept2(gblSourceType, gblFavorTypeId, gblHospCode)
                        End If

                    Else
                        dsSheet.Clear()
                        dsSheet.Tables.Add(dsInit.Tables(7).Copy)
                    End If

                    If gblIsSelectGroup Then
                        If gblSheetData(1).ToString = "1" Then
                            ds = uclService.queryOMOOrderFavorSheetDetailByLabGroup(gblSourceType, gblSheetData(0), gblSheetGroup, gblChartNo, gblOutpatientSn, txt_OrderName.Text.Trim, gblIsChoiceDcOrder)
                        Else
                            If gblFavorTypeId = "H2" AndAlso gblHospCode = "KMUH" Then
                                ds = uclService.queryOMOOrderFavorSheetDetailByExamGroupForKMUH(gblSourceType, gblSheetData(0), gblSheetData(4), gblChartNo, gblOutpatientSn, txt_OrderName.Text.Trim, gblIsChoiceDcOrder)
                            Else
                                ds = uclService.queryOMOOrderFavorSheetDetailByExamGroup(gblSourceType, gblSheetData(0), gblSheetGroup, gblChartNo, gblOutpatientSn, txt_OrderName.Text.Trim, gblIsChoiceDcOrder)
                            End If

                        End If
                        pvtExeQueryFlag = True
                    Else
                        setSheetDeptNode()
                    End If

                End If

            End If

            If pvtExeQueryFlag AndAlso ds IsNot Nothing AndAlso ds.Tables IsNot Nothing AndAlso _
               (rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked OrElse rbt_FavorId3.Checked OrElse _
                gblIsSelectGroup OrElse gblEmgOpFlag OrElse gblInpNrsFlag OrElse gblInpDrpFlag) Then

                If gblShowType = "H" Then
                    setHorizontal()
                Else
                    setVertical()
                End If


            End If

            If chk_Chinese.Checked Then chk_Chinese_CheckedChanged(sender, e)

            TableLayoutPanel2.Visible = True

            gblEmgDrugQuery = False



        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
            TableLayoutPanel2.Visible = True
        Finally
            UCLScreenUtil.UnLock(Me)
            TableLayoutPanel2.Visible = True
        End Try
    End Sub

    Private Sub setHorizontal()
        '清除 ArrayList 內容
        MedicineOrderName.Clear()
        MedicineChineseName.Clear()
        '資料筆數
        gblDataRows = 0
        '設定列數
        If gblSourceType = "O" OrElse gblSourceType = "E" OrElse gblSourceType = "I" Then
            gblShowRows = 17
        End If

        '計算行數
        gblShowColumns = 0

        If ds.Tables.Count > 0 Then

            gblDataRows = ds.Tables(0).Rows.Count

            For Each row As DataRow In ds.Tables(0).Rows

                'Console.WriteLine("****" & row.Item("Order_Code").ToString.Trim)

                If gblFavorTypeId = "E" Then

                    Select Case gblSourceType
                        Case "O"
                            If rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked Then
                                '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                'MedicineOrderName.Add(row.Item("Favor_Name").ToString.Trim)
                                MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Favor_Name").ToString.Trim)
                            Else
                                '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                'MedicineOrderName.Add(row.Item("Order_Name").ToString.Trim)
                                MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_Name").ToString.Trim)
                            End If

                            '2015-05-06 Modify by Alan---名稱前加上醫令碼
                            'MedicineChineseName.Add(row.Item("Chinese_Name").ToString.Trim)
                            MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Chinese_Name").ToString.Trim)

                        Case "E", "I"
                            Dim pvtNoteStr As String = ""

                            If (rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked) AndAlso row.Item("Is_Package").ToString.Trim = "Y" Then
                                pvtNoteStr = "【套】"
                            End If

                            If pvtNoteStr = "" Then
                                pvtNoteStr = getPropertyId(row.Item("M_Property_Id").ToString.Trim)
                            Else
                                pvtNoteStr &= getPropertyId(row.Item("M_Property_Id").ToString.Trim)
                            End If


                            'If row.Item("M_Property_Id").ToString.Trim <> "" AndAlso _
                            '   row.Item("M_Property_Id").ToString.Trim.Substring(0, 2) = "01" Then
                            '    If pvtNoteStr = "" Then
                            '        pvtNoteStr = "【管】"
                            '    Else
                            '        pvtNoteStr &= "【管】"
                            '    End If
                            'End If

                            'If row.Item("M_Property_Id").ToString.Trim <> "" AndAlso _
                            '   row.Item("M_Property_Id").ToString.Trim.Substring(0, 2) = "11" Then
                            '    If pvtNoteStr = "" Then
                            '        pvtNoteStr = "【抗】"
                            '    Else
                            '        pvtNoteStr &= "【抗】"
                            '    End If
                            'End If

                            'If row.Item("M_Property_Id").ToString.Trim <> "" AndAlso _
                            '   row.Item("M_Property_Id").ToString.Trim.Substring(0, 2) = "06" Then
                            '    If pvtNoteStr = "" Then
                            '        pvtNoteStr = "【審】"
                            '    Else
                            '        pvtNoteStr &= "【審】"
                            '    End If
                            'End If

                            If gblSourceType = "E" AndAlso row.Item("Is_OrderStanding").ToString.Trim <> "" Then
                                If pvtNoteStr = "" Then
                                    pvtNoteStr = "【常】"
                                Else
                                    pvtNoteStr &= "【常】"
                                End If
                            End If

                            If rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked Then
                                If row.Item("Order_Name").ToString.Trim = "" Then
                                    MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                                    MedicineChineseName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                                Else
                                    '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                    'MedicineOrderName.Add(pvtNoteStr & row.Item("Favor_Name").ToString.Trim)
                                    MedicineOrderName.Add(pvtNoteStr & row.Item("Order_Code").ToString.Trim & "-" & row.Item("Favor_Name").ToString.Trim)
                                End If
                            Else
                                '2011-09-05 Modify By Alan
                                If (rbt_FavorId3.Checked AndAlso rbt_Query2.Checked) AndAlso _
                                   row.Item("Order_Name").ToString.Trim = "" Then
                                    MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                                Else
                                    '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                    'MedicineOrderName.Add(pvtNoteStr & row.Item("Order_Name").ToString.Trim)
                                    MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & pvtNoteStr & row.Item("Order_Name").ToString.Trim)
                                End If
                            End If

                            '2015-05-06 Modify by Alan---名稱前加上醫令碼
                            'MedicineChineseName.Add(pvtNoteStr & row.Item("Chinese_Name").ToString.Trim)
                            MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & pvtNoteStr & row.Item("Chinese_Name").ToString.Trim)

                    End Select

                Else
                    Dim pvtNameplateName As String = ""
                    If gblSourceType = "O" AndAlso gblFavorTypeId = "J" Then
                        pvtNameplateName = row.Item("Nameplate_Name").ToString.Trim
                    End If

                    If rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked Then
                        If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso _
                          (gblFavorTypeId = "H" OrElse gblFavorTypeId = "D") AndAlso _
                          row.Item("Order_Code").ToString.Trim = "" Then
                            If pvtNameplateName = "" Then
                                MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                                MedicineChineseName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                            Else
                                MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "(" & pvtNameplateName & ")" & "****")
                                MedicineChineseName.Add("****" & row.Item("Favor_Category").ToString.Trim & "(" & pvtNameplateName & ")" & "****")
                            End If
                        Else
                            Dim pvtBlankStr As String
                            If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso _
                               (gblFavorTypeId = "H" OrElse gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" OrElse gblFavorTypeId = "D") Then
                                '2015-05-06 Modify by Alan---名稱前加上醫令碼，故將空白取消
                                'pvtBlankStr = "    "
                                pvtBlankStr = ""
                            Else
                                pvtBlankStr = ""
                            End If

                            If pvtNameplateName = "" Then
                                '若為急診檢驗檢查，則需於名稱後面新增檢體名稱
                                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso (gblFavorTypeId = "H" AndAlso gblFavorTypeId = "H1" AndAlso gblFavorTypeId = "H2") AndAlso _
                                   pvtBlankStr & row.Item("Specimen_Name").ToString.Trim <> "" AndAlso _
                                   pvtBlankStr & row.Item("Specimen_Name").ToString.Trim <> "    " Then

                                    '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                    'MedicineOrderName.Add(pvtBlankStr & row.Item("Favor_Name").ToString.Trim & " " & vbTab & _
                                    '                      pvtBlankStr & row.Item("Specimen_Name").ToString.Trim)
                                    MedicineOrderName.Add(pvtBlankStr & row.Item("Order_Code").ToString.Trim & "-" & row.Item("Favor_Name").ToString.Trim & " " & vbTab & _
                                                          pvtBlankStr & row.Item("Specimen_Name").ToString.Trim)
                                Else
                                    '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                    'MedicineOrderName.Add(pvtBlankStr & row.Item("Favor_Name").ToString.Trim)
                                    MedicineOrderName.Add(pvtBlankStr & row.Item("Order_Code").ToString.Trim & "-" & pvtBlankStr & row.Item("Favor_Name").ToString.Trim)
                                End If
                                '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                'MedicineChineseName.Add(pvtBlankStr & pvtBlankStr & row.Item("Order_Name").ToString.Trim)
                                MedicineChineseName.Add(pvtBlankStr & row.Item("Order_Code").ToString.Trim & "-" & pvtBlankStr & row.Item("Order_Name").ToString.Trim)
                            Else
                                '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                'MedicineOrderName.Add(pvtBlankStr & row.Item("Favor_Name").ToString.Trim & "(" & pvtNameplateName & ")")
                                'MedicineChineseName.Add(pvtBlankStr & row.Item("Order_Name").ToString.Trim & "(" & pvtNameplateName & ")")
                                MedicineOrderName.Add(pvtBlankStr & row.Item("Order_Code").ToString.Trim & "-" & row.Item("Favor_Name").ToString.Trim & "(" & pvtNameplateName & ")")
                                MedicineChineseName.Add(pvtBlankStr & row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_Name").ToString.Trim & "(" & pvtNameplateName & ")")
                            End If
                        End If
                    Else
                        '2011-08-30 Modify By Alan
                        If rbt_FavorId3.Checked AndAlso (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso _
                          gblFavorTypeId = "D" AndAlso cbo_Dept2.SelectedValue = "++" AndAlso _
                          row.Item("Order_Code").ToString.Trim = "" Then
                            If pvtNameplateName = "" Then
                                MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                                MedicineChineseName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                            Else
                                MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "(" & pvtNameplateName & ")" & "****")
                                MedicineChineseName.Add("****" & row.Item("Favor_Category").ToString.Trim & "(" & pvtNameplateName & ")" & "****")
                            End If

                        ElseIf (rbt_FavorId4.Checked AndAlso gblSourceType = "I" AndAlso _
                               gblFavorTypeId = "D" AndAlso row.Item("Order_Code").ToString.Trim = "") OrElse _
                               (rbt_FavorId4.Checked AndAlso gblFavorUseType = "2" AndAlso _
                               gblFavorTypeId = "D" AndAlso row.Item("Order_Code").ToString.Trim = "") Then
                            MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                            MedicineChineseName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")

                        ElseIf (gblFavorTypeId <> "H" AndAlso gblFavorTypeId <> "H1" AndAlso gblFavorTypeId <> "H2") Then
                            If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "A" AndAlso rbt_FavorId3.Checked Then

                                '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                'MedicineOrderName.Add(row.Item("Order_En_Name").ToString.Trim & " (" & row.Item("Order_Code").ToString.Trim & ")")
                                'MedicineChineseName.Add(row.Item("Order_Name").ToString.Trim & " (" & row.Item("Order_Code").ToString.Trim & ")")
                                MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim)
                                MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_Name").ToString.Trim & " (" & row.Item("Order_Code").ToString.Trim & ")")
                            Else

                                '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                'MedicineOrderName.Add(row.Item("Order_En_Name").ToString.Trim)
                                'MedicineChineseName.Add(row.Item("Order_Name").ToString.Trim)
                                MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim)
                                MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_Name").ToString.Trim)
                            End If
                        Else
                            If gblSheetData IsNot Nothing AndAlso gblSheetData(1) = "1" Then
                                If row.Item("Order_En_Short_Name").ToString.Trim <> "" Then
                                    If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso rbt_FavorId4.Checked Then
                                        '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                        'MedicineOrderName.Add(row.Item("Order_En_Short_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim & " " & vbTab & row.Item("Order_Code").ToString.Trim)
                                        'MedicineChineseName.Add(row.Item("Order_En_Short_Name").ToString.Trim)
                                        MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Short_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim)
                                        MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Short_Name").ToString.Trim)
                                    Else
                                        '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                        'MedicineOrderName.Add(row.Item("Order_En_Short_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim)
                                        'MedicineChineseName.Add(row.Item("Order_En_Short_Name").ToString.Trim)
                                        MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Short_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim)
                                        MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Short_Name").ToString.Trim)
                                    End If

                                Else
                                    If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso rbt_FavorId4.Checked Then
                                        '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                        'MedicineOrderName.Add(row.Item("Order_En_Name").ToString.Trim & vbTab & " " & row.Item("Sheet_Group_Name").ToString.Trim & " " & vbTab & row.Item("Order_Code").ToString.Trim)
                                        'MedicineChineseName.Add(row.Item("Order_En_Name").ToString.Trim)
                                        MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim & vbTab & " " & row.Item("Sheet_Group_Name").ToString.Trim)
                                        MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim)
                                    Else
                                        '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                        'MedicineOrderName.Add(row.Item("Order_En_Name").ToString.Trim & vbTab & " " & row.Item("Sheet_Group_Name").ToString.Trim)
                                        'MedicineChineseName.Add(row.Item("Order_En_Name").ToString.Trim)
                                        MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim & vbTab & " " & row.Item("Sheet_Group_Name").ToString.Trim)
                                        MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim)
                                    End If
                                End If
                            Else
                                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso rbt_FavorId4.Checked Then
                                    '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                    'MedicineOrderName.Add(row.Item("Order_En_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim & " " & vbTab & row.Item("Order_Code").ToString.Trim)
                                    'MedicineChineseName.Add(row.Item("Order_Name").ToString.Trim)
                                    MedicineOrderName.Add(row.Item(row.Item("Order_Code").ToString.Trim & "-" & "Order_En_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim)
                                    MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_Name").ToString.Trim)
                                Else
                                    '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                    'MedicineOrderName.Add(row.Item("Order_En_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim)
                                    'MedicineChineseName.Add(row.Item("Order_Name").ToString.Trim)
                                    MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim)
                                    MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_Name").ToString.Trim)
                                End If
                            End If

                        End If

                    End If

                End If

            Next
        End If

        If gblDataRows Mod gblShowRows <> 0 Then
            If gblDataRows < gblShowRows Then
                gblShowColumns = 1
            Else
                gblShowColumns = (gblDataRows \ gblShowRows) + 1
            End If
        Else
            gblShowColumns = gblDataRows \ gblShowRows
        End If

        gblColumnWidth = ResetGridData(gblShowColumns)

        '根據一列兩欄的排列方式給予 DataSet 值
        If ds.Tables.Count > 0 Then
            For i As Integer = 0 To gblDataRows - 1

                dsOrderName.Tables("OrderName").Rows.Add()
                dsChineseName.Tables("ChineseName").Rows.Add()
                For j = 0 To gblShowColumns - 1
                    dsOrderName.Tables("OrderName").Rows(i).Item(j * 2) = "N"
                    dsChineseName.Tables("ChineseName").Rows(i).Item(j * 2) = "N"
                    If (gblShowRows * j + i + 1) <= gblDataRows Then
                        dsOrderName.Tables("OrderName").Rows(i).Item(j * 2 + 1) = MedicineOrderName(i + gblShowRows * j)
                        dsChineseName.Tables("ChineseName").Rows(i).Item(j * 2 + 1) = MedicineChineseName(i + gblShowRows * j)
                    End If
                Next
                If i = gblShowRows - 1 Then Exit For
            Next
        End If


        Dim hashTable As New Hashtable()
        hashTable.Add(-1, dsOrderName.Copy)

        Dim pvtNonVisible As String = ""

        For m = 0 To gblShowColumns - 1
            hashTable.Add(m * 2, New CheckBoxCell())
            If m <> 0 Then
                pvtNonVisible &= "," & m * 2
            Else
                pvtNonVisible = "0"
            End If
        Next

        dgv_FavorData.Initial(hashTable)
        dgv_FavorData.uclColumnWidth = gblColumnWidth
        dgv_FavorData.uclNonVisibleColIndex = pvtNonVisible

        '設定顏色
        If (gblFavorTypeId = "E" OrElse gblFavorTypeId = "D" OrElse gblFavorTypeId = "G" OrElse gblFavorTypeId = "H" OrElse gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" OrElse _
              ((gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "A")) AndAlso ds.Tables.Count > 0 Then
            For i As Integer = 0 To gblDataRows - 1
                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso (gblFavorTypeId = "D" Or gblFavorTypeId = "H" Or gblFavorTypeId = "H1" Or gblFavorTypeId = "H2") Then
                    'Me.dgv_FavorData.Rows(i).Height = 15
                End If
                For j = 0 To gblShowColumns - 1
                    Select Case gblSourceType
                        Case "O"
                            If gblFavorTypeId = "E" AndAlso (gblShowRows * j + i + 1) <= gblDataRows Then
                                '缺藥 
                                If ds.Tables(0).Rows(gblShowRows * j + i).Item("OPD_Lack_Id").ToString.Trim <> "N" Then
                                    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightGray
                                End If

                                '麻醉管制藥品(一級針劑)
                                If ds.Tables(0).Rows(gblShowRows * j + i).Item("M_Property_Id").ToString.Trim.Contains("011B") Then
                                    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.ForeColor = Color.Red
                                End If

                            End If

                            If gblFavorUseType = "2" AndAlso gblFavorTypeId = "D" AndAlso (gblShowRows * j + i + 1) <= gblDataRows AndAlso ds.Tables(0).Rows(gblShowRows * j + i).Item("Order_Name").ToString.Trim = "" Then
                                dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightYellow
                            End If

                            '停用
                            If (gblShowRows * j + i + 1) <= gblDataRows AndAlso ds.Tables(0).Rows(gblShowRows * j + i).Item("Is_Valid_Order").ToString.Trim = "N" Then
                                dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightGray
                            End If


                        Case "E", "I"
                            If (gblShowRows * j + i + 1) <= gblDataRows Then
                                '缺藥 
                                If gblFavorTypeId = "E" Then
                                    If ds.Tables(0).Rows(gblShowRows * j + i).Item("Order_Name").ToString.Trim = "" Then
                                        dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightYellow
                                    ElseIf (gblSourceType = "E" AndAlso ds.Tables(0).Rows(gblShowRows * j + i).Item("EMG_Lack_Id").ToString.Trim <> "N") OrElse _
                                           (gblSourceType = "I" AndAlso ds.Tables(0).Rows(gblShowRows * j + i).Item("Ipd_Lack_Id").ToString.Trim <> "N") OrElse _
                                           (ds.Tables(0).Rows(gblShowRows * j + i).Item("Is_Valid_Order").ToString.Trim) Then
                                        dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightGray
                                    End If

                                End If
                                If ds.Tables(0).Rows(gblShowRows * j + i).Item("Order_Code").ToString.Trim = "" Then
                                    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightYellow
                                    'If gblFavorTypeId = "E" Then
                                    '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.Font = New Font("新細明體", 12, FontStyle.Bold)
                                    'Else
                                    '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.Font = New Font("新細明體", 10, FontStyle.Bold)
                                    '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None
                                    'End If
                                End If

                                '停用
                                If (gblShowRows * j + i + 1) <= gblDataRows AndAlso ds.Tables(0).Rows(gblShowRows * j + i).Item("Is_Valid_Order").ToString.Trim = "N" Then
                                    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightGray
                                End If

                                'If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "A" Then
                                '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None
                                'End If

                                'If ((gblSourceType = "I") AndAlso (gblFavorTypeId = "H" OrElse gblFavorTypeId = "D")) Then
                                '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None
                                '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.Font = New Font("新細明體", 10, FontStyle.Regular)
                                'End If

                                'If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "E" AndAlso _
                                '   ds.Tables(0).Rows(gblShowRows * j + i).Item("Order_Code").ToString.Trim <> "" Then
                                '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.Font = New Font("新細明體", 10, FontStyle.Regular)
                                'End If

                            End If
                    End Select

                Next
                If i = gblShowRows - 1 Then Exit For
            Next
        End If

        'If  (gblSourceType = "E" ORELSE gblSourceType = "I")  AndAlso (gblFavorTypeId = "D" Or gblFavorTypeId = "H") Then
        '    Me.dgv_FavorData.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)
        'End If

        dgv_FavorData.AllowUserToResizeRows = False
        dgv_FavorData.AllowDrop = False

        dgv_FavorData.ClearSelection()
    End Sub

    Private Sub setVertical()
        '清除 ArrayList 內容
        MedicineOrderName.Clear()
        MedicineChineseName.Clear()
        '資料筆數
        gblDataRows = 0

        '設定列數
        'If gblSourceType = "O" OrElse gblSourceType = "E" OrElse gblSourceType = "I" Then
        '    gblShowRows = 17
        'End If

        '計算行數
        gblShowColumns = 0

        If ds.Tables.Count > 0 Then

            gblDataRows = ds.Tables(0).Rows.Count

            '設定列數
            If gblDataRows > 0 Then

                gblShowRows = gblDataRows \ 2

                If gblDataRows Mod 2 = 1 Then
                    gblShowRows += 1

                Else
                    'If gblShowType = "V" And gblDataRows = 2 Then
                    '    gblShowRows += 1
                    'End If
                End If

            End If

            For Each row As DataRow In ds.Tables(0).Rows

                'Console.WriteLine("****" & row.Item("Order_Code").ToString.Trim)

                If gblFavorTypeId = "E" Then

                    Select Case gblSourceType
                        Case "O"
                            If rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked Then
                                '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                'MedicineOrderName.Add(row.Item("Favor_Name").ToString.Trim)
                                MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Favor_Name").ToString.Trim)
                            Else
                                '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                'MedicineOrderName.Add(row.Item("Order_Name").ToString.Trim)
                                MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_Name").ToString.Trim)
                            End If

                            '2015-05-06 Modify by Alan---名稱前加上醫令碼
                            'MedicineChineseName.Add(row.Item("Chinese_Name").ToString.Trim)
                            MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Chinese_Name").ToString.Trim)

                        Case "E", "I"
                            Dim pvtNoteStr As String = ""

                            If (rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked) AndAlso row.Item("Is_Package").ToString.Trim = "Y" Then
                                pvtNoteStr = "【套】"
                            End If

                            If pvtNoteStr = "" Then
                                pvtNoteStr = getPropertyId(row.Item("M_Property_Id").ToString.Trim)
                            Else
                                pvtNoteStr &= getPropertyId(row.Item("M_Property_Id").ToString.Trim)
                            End If


                            'If row.Item("M_Property_Id").ToString.Trim <> "" AndAlso _
                            '   row.Item("M_Property_Id").ToString.Trim.Substring(0, 2) = "01" Then
                            '    If pvtNoteStr = "" Then
                            '        pvtNoteStr = "【管】"
                            '    Else
                            '        pvtNoteStr &= "【管】"
                            '    End If
                            'End If

                            'If row.Item("M_Property_Id").ToString.Trim <> "" AndAlso _
                            '   row.Item("M_Property_Id").ToString.Trim.Substring(0, 2) = "11" Then
                            '    If pvtNoteStr = "" Then
                            '        pvtNoteStr = "【抗】"
                            '    Else
                            '        pvtNoteStr &= "【抗】"
                            '    End If
                            'End If

                            'If row.Item("M_Property_Id").ToString.Trim <> "" AndAlso _
                            '   row.Item("M_Property_Id").ToString.Trim.Substring(0, 2) = "06" Then
                            '    If pvtNoteStr = "" Then
                            '        pvtNoteStr = "【審】"
                            '    Else
                            '        pvtNoteStr &= "【審】"
                            '    End If
                            'End If

                            If gblSourceType = "E" AndAlso row.Item("Is_OrderStanding").ToString.Trim <> "" Then
                                If pvtNoteStr = "" Then
                                    pvtNoteStr = "【常】"
                                Else
                                    pvtNoteStr &= "【常】"
                                End If
                            End If

                            If rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked Then
                                If row.Item("Order_Name").ToString.Trim = "" Then
                                    MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                                    MedicineChineseName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                                Else
                                    '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                    'MedicineOrderName.Add(pvtNoteStr & row.Item("Favor_Name").ToString.Trim)
                                    MedicineOrderName.Add(pvtNoteStr & row.Item("Order_Code").ToString.Trim & "-" & row.Item("Favor_Name").ToString.Trim)
                                End If
                            Else
                                '2011-09-05 Modify By Alan
                                If (rbt_FavorId3.Checked AndAlso rbt_Query2.Checked) AndAlso _
                                   row.Item("Order_Name").ToString.Trim = "" Then
                                    MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                                Else
                                    '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                    'MedicineOrderName.Add(pvtNoteStr & row.Item("Order_Name").ToString.Trim)
                                    MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & pvtNoteStr & row.Item("Order_Name").ToString.Trim)
                                End If
                            End If

                            '2015-05-06 Modify by Alan---名稱前加上醫令碼
                            'MedicineChineseName.Add(pvtNoteStr & row.Item("Chinese_Name").ToString.Trim)
                            MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & pvtNoteStr & row.Item("Chinese_Name").ToString.Trim)

                    End Select

                Else
                    Dim pvtNameplateName As String = ""
                    If gblSourceType = "O" AndAlso gblFavorTypeId = "J" Then
                        pvtNameplateName = row.Item("Nameplate_Name").ToString.Trim
                    End If

                    If rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked Then
                        If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso _
                          (gblFavorTypeId = "H" OrElse gblFavorTypeId = "D") AndAlso _
                          row.Item("Order_Code").ToString.Trim = "" Then
                            If pvtNameplateName = "" Then
                                MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                                MedicineChineseName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                            Else
                                MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "(" & pvtNameplateName & ")" & "****")
                                MedicineChineseName.Add("****" & row.Item("Favor_Category").ToString.Trim & "(" & pvtNameplateName & ")" & "****")
                            End If
                        Else
                            Dim pvtBlankStr As String
                            If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso _
                               (gblFavorTypeId = "H" OrElse gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" OrElse gblFavorTypeId = "D") Then
                                '2015-05-06 Modify by Alan---名稱前加上醫令碼，故將空白取消
                                'pvtBlankStr = "    "
                                pvtBlankStr = ""
                            Else
                                pvtBlankStr = ""
                            End If

                            If pvtNameplateName = "" Then
                                '若為急診檢驗檢查，則需於名稱後面新增檢體名稱
                                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso (gblFavorTypeId = "H" AndAlso gblFavorTypeId = "H1" AndAlso gblFavorTypeId = "H2") AndAlso _
                                   pvtBlankStr & row.Item("Specimen_Name").ToString.Trim <> "" AndAlso _
                                   pvtBlankStr & row.Item("Specimen_Name").ToString.Trim <> "    " Then

                                    '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                    'MedicineOrderName.Add(pvtBlankStr & row.Item("Favor_Name").ToString.Trim & " " & vbTab & _
                                    '                      pvtBlankStr & row.Item("Specimen_Name").ToString.Trim)
                                    MedicineOrderName.Add(pvtBlankStr & row.Item("Order_Code").ToString.Trim & "-" & row.Item("Favor_Name").ToString.Trim & " " & vbTab & _
                                                          pvtBlankStr & row.Item("Specimen_Name").ToString.Trim)
                                Else
                                    '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                    'MedicineOrderName.Add(pvtBlankStr & row.Item("Favor_Name").ToString.Trim)
                                    MedicineOrderName.Add(pvtBlankStr & row.Item("Order_Code").ToString.Trim & "-" & pvtBlankStr & row.Item("Favor_Name").ToString.Trim)
                                End If
                                '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                'MedicineChineseName.Add(pvtBlankStr & pvtBlankStr & row.Item("Order_Name").ToString.Trim)
                                MedicineChineseName.Add(pvtBlankStr & row.Item("Order_Code").ToString.Trim & "-" & pvtBlankStr & row.Item("Order_Name").ToString.Trim)
                            Else
                                '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                'MedicineOrderName.Add(pvtBlankStr & row.Item("Favor_Name").ToString.Trim & "(" & pvtNameplateName & ")")
                                'MedicineChineseName.Add(pvtBlankStr & row.Item("Order_Name").ToString.Trim & "(" & pvtNameplateName & ")")
                                MedicineOrderName.Add(pvtBlankStr & row.Item("Order_Code").ToString.Trim & "-" & row.Item("Favor_Name").ToString.Trim & "(" & pvtNameplateName & ")")
                                MedicineChineseName.Add(pvtBlankStr & row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_Name").ToString.Trim & "(" & pvtNameplateName & ")")
                            End If
                        End If
                    Else
                        '2011-08-30 Modify By Alan
                        If rbt_FavorId3.Checked AndAlso (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso _
                          gblFavorTypeId = "D" AndAlso cbo_Dept2.SelectedValue = "++" AndAlso _
                          row.Item("Order_Code").ToString.Trim = "" Then
                            If pvtNameplateName = "" Then
                                MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                                MedicineChineseName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                            Else
                                MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "(" & pvtNameplateName & ")" & "****")
                                MedicineChineseName.Add("****" & row.Item("Favor_Category").ToString.Trim & "(" & pvtNameplateName & ")" & "****")
                            End If

                        ElseIf (rbt_FavorId4.Checked AndAlso gblSourceType = "I" AndAlso _
                               gblFavorTypeId = "D" AndAlso row.Item("Order_Code").ToString.Trim = "") OrElse _
                               (rbt_FavorId4.Checked AndAlso gblFavorUseType = "2" AndAlso _
                               gblFavorTypeId = "D" AndAlso row.Item("Order_Code").ToString.Trim = "") Then
                            MedicineOrderName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")
                            MedicineChineseName.Add("****" & row.Item("Favor_Category").ToString.Trim & "****")

                        ElseIf (gblFavorTypeId <> "H" AndAlso gblFavorTypeId <> "H1" AndAlso gblFavorTypeId <> "H2") Then
                            If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "A" AndAlso rbt_FavorId3.Checked Then

                                '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                'MedicineOrderName.Add(row.Item("Order_En_Name").ToString.Trim & " (" & row.Item("Order_Code").ToString.Trim & ")")
                                'MedicineChineseName.Add(row.Item("Order_Name").ToString.Trim & " (" & row.Item("Order_Code").ToString.Trim & ")")
                                MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim)
                                MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_Name").ToString.Trim & " (" & row.Item("Order_Code").ToString.Trim & ")")
                            Else

                                '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                'MedicineOrderName.Add(row.Item("Order_En_Name").ToString.Trim)
                                'MedicineChineseName.Add(row.Item("Order_Name").ToString.Trim)
                                MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim)
                                MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_Name").ToString.Trim)
                            End If
                        Else
                            If gblSheetData IsNot Nothing AndAlso gblSheetData(1) = "1" Then
                                If row.Item("Order_En_Short_Name").ToString.Trim <> "" Then
                                    If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso rbt_FavorId4.Checked Then
                                        '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                        'MedicineOrderName.Add(row.Item("Order_En_Short_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim & " " & vbTab & row.Item("Order_Code").ToString.Trim)
                                        'MedicineChineseName.Add(row.Item("Order_En_Short_Name").ToString.Trim)
                                        MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Short_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim)
                                        MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Short_Name").ToString.Trim)
                                    Else
                                        '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                        'MedicineOrderName.Add(row.Item("Order_En_Short_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim)
                                        'MedicineChineseName.Add(row.Item("Order_En_Short_Name").ToString.Trim)
                                        MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Short_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim)
                                        MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Short_Name").ToString.Trim)
                                    End If

                                Else
                                    If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso rbt_FavorId4.Checked Then
                                        '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                        'MedicineOrderName.Add(row.Item("Order_En_Name").ToString.Trim & vbTab & " " & row.Item("Sheet_Group_Name").ToString.Trim & " " & vbTab & row.Item("Order_Code").ToString.Trim)
                                        'MedicineChineseName.Add(row.Item("Order_En_Name").ToString.Trim)
                                        MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim & vbTab & " " & row.Item("Sheet_Group_Name").ToString.Trim)
                                        MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim)
                                    Else
                                        '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                        'MedicineOrderName.Add(row.Item("Order_En_Name").ToString.Trim & vbTab & " " & row.Item("Sheet_Group_Name").ToString.Trim)
                                        'MedicineChineseName.Add(row.Item("Order_En_Name").ToString.Trim)
                                        MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim & vbTab & " " & row.Item("Sheet_Group_Name").ToString.Trim)
                                        MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim)
                                    End If
                                End If
                            Else
                                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso rbt_FavorId4.Checked Then
                                    '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                    'MedicineOrderName.Add(row.Item("Order_En_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim & " " & vbTab & row.Item("Order_Code").ToString.Trim)
                                    'MedicineChineseName.Add(row.Item("Order_Name").ToString.Trim)
                                    MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim)
                                    MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_Name").ToString.Trim)
                                Else
                                    '2015-05-06 Modify by Alan---名稱前加上醫令碼
                                    'MedicineOrderName.Add(row.Item("Order_En_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim)
                                    'MedicineChineseName.Add(row.Item("Order_Name").ToString.Trim)
                                    MedicineOrderName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_En_Name").ToString.Trim & " " & vbTab & row.Item("Sheet_Group_Name").ToString.Trim)
                                    MedicineChineseName.Add(row.Item("Order_Code").ToString.Trim & "-" & row.Item("Order_Name").ToString.Trim)
                                End If
                            End If

                        End If

                    End If

                End If

            Next
        End If

        If gblShowRows > 0 Then
            If gblDataRows Mod gblShowRows <> 0 Then
                If gblDataRows < gblShowRows Then
                    gblShowColumns = 1
                Else
                    gblShowColumns = (gblDataRows \ gblShowRows) + 1
                End If
            Else
                gblShowColumns = gblDataRows \ gblShowRows

                If gblShowType = "V" Then
                    gblShowColumns = 2
                End If
            End If

            gblColumnWidth = ResetGridDataForVertical(gblShowColumns)
        End If


        '根據一列兩欄的排列方式給予 DataSet 值
        If ds.Tables.Count > 0 Then
            For i As Integer = 0 To gblDataRows - 1
                '    ---先由上而下，再由左而右排列
                '    dsOrderName.Tables("OrderName").Rows.Add()
                '    dsChineseName.Tables("ChineseName").Rows.Add()
                '    For j = 0 To gblShowColumns - 1
                '        dsOrderName.Tables("OrderName").Rows(i).Item(j * 2) = "N"
                '        dsChineseName.Tables("ChineseName").Rows(i).Item(j * 2) = "N"
                '        If (gblShowRows * j + i + 1) <= gblDataRows Then
                '            dsOrderName.Tables("OrderName").Rows(i).Item(j * 2 + 1) = MedicineOrderName(i + gblShowRows * j)
                '            dsChineseName.Tables("ChineseName").Rows(i).Item(j * 2 + 1) = MedicineChineseName(i + gblShowRows * j)
                '        End If
                '    Next
                '    If i = gblShowRows - 1 Then Exit For

                '---先由左而右，再由上而下排列 
                If i Mod 2 = 0 Then
                    dsOrderName.Tables("OrderName").Rows.Add()
                    dsChineseName.Tables("ChineseName").Rows.Add()
                    dsOrderName.Tables("OrderName").Rows(i \ 2).Item(0) = "N"
                    dsChineseName.Tables("ChineseName").Rows(i \ 2).Item(0) = "N"
                    dsOrderName.Tables("OrderName").Rows(i \ 2).Item(1) = MedicineOrderName(i)
                    dsChineseName.Tables("ChineseName").Rows(i \ 2).Item(1) = MedicineChineseName(i)

                Else
                    If i <= gblDataRows - 1 Then
                        dsOrderName.Tables("OrderName").Rows(i \ 2).Item(2) = "N"
                        dsChineseName.Tables("ChineseName").Rows(i \ 2).Item(2) = "N"
                        dsOrderName.Tables("OrderName").Rows(i \ 2).Item(3) = MedicineOrderName(i)
                        dsChineseName.Tables("ChineseName").Rows(i \ 2).Item(3) = MedicineChineseName(i)
                    End If

                End If

            Next

        End If


        Dim hashTable As New Hashtable()
        hashTable.Add(-1, dsOrderName.Copy)

        Dim pvtNonVisible As String = ""

        For m = 0 To gblShowColumns - 1
            hashTable.Add(m * 2, New CheckBoxCell())
            If m <> 0 Then
                pvtNonVisible &= "," & m * 2
            Else
                pvtNonVisible = "0"
            End If
        Next

        dgv_FavorData.Initial(hashTable)
        dgv_FavorData.uclColumnWidth = gblColumnWidth
        dgv_FavorData.uclNonVisibleColIndex = pvtNonVisible

        '設定顏色
        If (gblFavorTypeId = "E" OrElse gblFavorTypeId = "D" OrElse gblFavorTypeId = "G" OrElse gblFavorTypeId = "H" OrElse gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" OrElse _
              ((gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "A")) AndAlso ds.Tables.Count > 0 Then
            For i As Integer = 0 To gblDataRows - 1
                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso (gblFavorTypeId = "D" Or gblFavorTypeId = "H" Or gblFavorTypeId = "H1" Or gblFavorTypeId = "H2") Then
                    'Me.dgv_FavorData.Rows(i).Height = 15
                End If

                If gblFavorTypeId = "E" Then
                    '缺藥 
                    If ds.Tables(0).Rows(i).Item("OPD_Lack_Id").ToString.Trim <> "N" Then
                        If i Mod 2 = 0 Then
                            dgv_FavorData.Rows(i \ 2).Cells.Item(1).Style.BackColor = Color.LightGray
                        Else
                            dgv_FavorData.Rows(i \ 2).Cells.Item(3).Style.BackColor = Color.LightGray
                        End If
                    End If

                    '麻醉管制藥品(一級針劑)
                    If ds.Tables(0).Rows(i).Item("M_Property_Id").ToString.Trim.Contains("011B") Then
                        If i Mod 2 = 0 Then
                            dgv_FavorData.Rows(i \ 2).Cells.Item(1).Style.ForeColor = Color.Red
                        Else
                            dgv_FavorData.Rows(i \ 2).Cells.Item(3).Style.ForeColor = Color.Red
                        End If
                    End If

                End If

                If gblFavorUseType = "2" AndAlso gblFavorTypeId = "D" AndAlso ds.Tables(0).Rows(i).Item("Order_Name").ToString.Trim = "" Then
                    If i Mod 2 = 0 Then
                        dgv_FavorData.Rows(i \ 2).Cells.Item(1).Style.BackColor = Color.LightYellow
                    Else
                        dgv_FavorData.Rows(i \ 2).Cells.Item(3).Style.BackColor = Color.LightYellow
                    End If
                End If

                '停用
                If ds.Tables(0).Rows(i).Item("Is_Valid_Order").ToString.Trim = "N" Then
                    If i Mod 2 = 0 Then
                        dgv_FavorData.Rows(i \ 2).Cells.Item(1).Style.BackColor = Color.LightGray
                    Else
                        dgv_FavorData.Rows(i \ 2).Cells.Item(3).Style.BackColor = Color.LightGray
                    End If
                End If


                'For j = 0 To gblShowColumns - 1
                '    Select Case gblSourceType
                '        Case "O"
                '            If gblFavorTypeId = "E" AndAlso (gblShowRows * j + i + 1) <= gblDataRows Then
                '                '缺藥 
                '                If ds.Tables(0).Rows(gblShowRows * j + i).Item("OPD_Lack_Id").ToString.Trim <> "N" Then
                '                    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightGray
                '                End If

                '                '麻醉管制藥品(一級針劑)
                '                If ds.Tables(0).Rows(gblShowRows * j + i).Item("M_Property_Id").ToString.Trim.Contains("011B") Then
                '                    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.ForeColor = Color.Red
                '                End If

                '            End If

                '            If gblFavorUseType = "2" AndAlso gblFavorTypeId = "D" AndAlso (gblShowRows * j + i + 1) <= gblDataRows AndAlso ds.Tables(0).Rows(gblShowRows * j + i).Item("Order_Name").ToString.Trim = "" Then
                '                dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightYellow
                '            End If

                '            '停用
                '            If (gblShowRows * j + i + 1) <= gblDataRows AndAlso ds.Tables(0).Rows(gblShowRows * j + i).Item("Is_Valid_Order").ToString.Trim = "N" Then
                '                dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightGray
                '            End If

                '        Case "E", "I"
                '            If (gblShowRows * j + i + 1) <= gblDataRows Then
                '                '缺藥 
                '                If gblFavorTypeId = "E" Then
                '                    If ds.Tables(0).Rows(gblShowRows * j + i).Item("Order_Name").ToString.Trim = "" Then
                '                        dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightYellow
                '                    ElseIf (gblSourceType = "E" AndAlso ds.Tables(0).Rows(gblShowRows * j + i).Item("EMG_Lack_Id").ToString.Trim <> "N") OrElse _
                '                           (gblSourceType = "I" AndAlso ds.Tables(0).Rows(gblShowRows * j + i).Item("Ipd_Lack_Id").ToString.Trim <> "N") Then
                '                        dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightGray
                '                    End If

                '                End If
                '                If ds.Tables(0).Rows(gblShowRows * j + i).Item("Order_Code").ToString.Trim = "" Then
                '                    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightYellow
                '                    'If gblFavorTypeId = "E" Then
                '                    '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.Font = New Font("新細明體", 12, FontStyle.Bold)
                '                    'Else
                '                    '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.Font = New Font("新細明體", 10, FontStyle.Bold)
                '                    '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None
                '                    'End If
                '                End If

                '                '停用
                '                If (gblShowRows * j + i + 1) <= gblDataRows AndAlso ds.Tables(0).Rows(gblShowRows * j + i).Item("Is_Valid_Order").ToString.Trim = "N" Then
                '                    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.BackColor = Color.LightGray
                '                End If

                '                'If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "A" Then
                '                '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None
                '                'End If

                '                'If ((gblSourceType = "I") AndAlso (gblFavorTypeId = "H" OrElse gblFavorTypeId = "D")) Then
                '                '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None
                '                '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.Font = New Font("新細明體", 10, FontStyle.Regular)
                '                'End If

                '                'If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "E" AndAlso _
                '                '   ds.Tables(0).Rows(gblShowRows * j + i).Item("Order_Code").ToString.Trim <> "" Then
                '                '    dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Style.Font = New Font("新細明體", 10, FontStyle.Regular)
                '                'End If

                '            End If
                '    End Select

                'Next
                'If i = gblShowRows - 1 Then Exit For
            Next
        End If

        'If  (gblSourceType = "E" ORELSE gblSourceType = "I")  AndAlso (gblFavorTypeId = "D" Or gblFavorTypeId = "H") Then
        '    Me.dgv_FavorData.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)
        'End If

        dgv_FavorData.AllowUserToResizeRows = False
        dgv_FavorData.AllowDrop = False

        dgv_FavorData.ClearSelection()

    End Sub


    Private Sub btn_Query2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query2.Click
        txt_OrderName.Text = txt_OrderName2.Text.Trim
        btn_Query_Click(sender, e)
    End Sub

    '醫師常用
    Private Sub rbt_FavorId1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbt_FavorId1.CheckedChanged
        Try
            If rbt_FavorId1.Checked Then

                gblFavorId = "1"

                cbo_Dept.Enabled = False
                cbo_Dept2.Enabled = False
                cbo_Station.Enabled = False

                If gblFavorTypeId <> "J" Then
                    tre_Category.Enabled = True
                End If

                cbo_Dept.SelectedValue = ""
                cbo_Dept2.SelectedValue = ""

                '2012-11-16 Add By Alan 住院查詢加入分類Combox
                'If gblSourceType = "I" AndAlso (gblFavorTypeId = "E" OrElse gblFavorTypeId = "H" OrElse gblFavorTypeId = "D") Then
                '    Me.cbo_Station.Visible = True
                '    Me.cbo_Station.Enabled = True
                '    cbo_Station.DataSource = dsInit.Tables(0).Copy
                '    cbo_Station.uclDisplayIndex = "0"
                '    cbo_Station.uclValueIndex = "0"
                'End If

                '若為急診且為診斷查詢，則需清空檢索欄位
                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "A" Then
                    txt_OrderName2.Text = ""
                End If

                '設定分類-預設為醫師
                setCategory(dsInit.Tables(0).Copy)

                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "A" AndAlso tre_Category IsNot Nothing AndAlso tre_Category.Nodes.Count > 1 Then
                    tre_Category.SelectedNode = tre_Category.Nodes(1)
                End If

                If rbt_FavorId1.Checked = True Then btn_Query_Click(sender, e)

                If gblInitFlag AndAlso dsInit.Tables(8).Rows(0).Item("Favor_Type_Id").ToString.Trim = "2" Then
                    If gblDrugType = "3" And gblSubDrugType <> "" Then
                        If gblSubDrugType = "2" OrElse gblSubDrugType = "3" Then
                            gblDrugType = "1"
                        End If
                        gblDeptCode = "PHCT"
                    End If
                    rbt_FavorId2.Checked = True
                End If

                chk_Chinese.Enabled = True
                txt_OrderName.Enabled = True
                btn_Query.Enabled = True

                'If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso (gblFavorTypeId = "H" OrElse gblFavorTypeId = "D") Then
                '    Me.Panel2.Visible = False
                '    Me.tre_Category.Visible = False
                '    Me.TableLayoutPanel2.Location = New Point(0, 54)
                '    If gblSourceType = "I" Then
                '        Me.dgv_FavorData.Height = 190
                '    Else
                '        Me.dgv_FavorData.Height = 420
                '    End If

                '    Me.dgv_FavorData.Width = 965
                '    Me.dgv_FavorData.DefaultCellStyle.Font = New Font("新細明體", 10)
                'End If

            End If
        Catch ex As Exception
            'Console.WriteLine(ex.ToString)
        End Try
    End Sub

    '科常用
    Private Sub rbt_FavorId2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbt_FavorId2.CheckedChanged
        Try
            If rbt_FavorId2.Checked Then

                gblFavorId = "2"

                cbo_Dept.Enabled = True
                cbo_Dept2.Enabled = True


                '若為手術，則將科別與分類Lock，不可更改
                If gblFavorTypeId <> "J" Then
                    tre_Category.Enabled = True
                Else
                    'tre_Category.Enabled = False
                End If

                '若為急診且為診斷查詢，則需清空檢索欄位
                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "A" Then
                    txt_OrderName2.Text = ""
                End If

                '設定分類-科別
                setCategory(dsInit.Tables(1).Copy)

                '若為急診大量點滴，則預設科別為IVFUse
                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "E" AndAlso gblDrugType = "5" Then
                    gblDeptCode = "IVFUse"
                End If

                cbo_Dept.SelectedValue = gblDeptCode
                cbo_Dept2.SelectedValue = gblDeptCode

                '2012-11-16 Add By Alan 住院查詢加入分類Combox
                'If gblSourceType = "I" AndAlso (gblFavorTypeId = "E" OrElse gblFavorTypeId = "H" OrElse gblFavorTypeId = "D") Then
                '    Me.cbo_Station.Visible = True
                '    Me.cbo_Station.Enabled = True
                '    cbo_Station.DataSource = dsInit.Tables(1).Copy
                '    cbo_Station.uclDisplayIndex = "0"
                '    cbo_Station.uclValueIndex = "0"
                'End If

                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "A" AndAlso tre_Category IsNot Nothing AndAlso tre_Category.Nodes.Count > 1 Then
                    tre_Category.SelectedNode = tre_Category.Nodes(0)
                    gblInitFlag = False
                End If

                If rbt_FavorId2.Checked Then btn_Query_Click(sender, e)

                chk_Chinese.Enabled = True
                txt_OrderName.Enabled = True
                btn_Query.Enabled = True
                btn_OK.Enabled = True
                'If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso (gblFavorTypeId = "H" OrElse gblFavorTypeId = "D") Then
                '    Me.Panel2.Visible = False
                '    Me.tre_Category.Visible = False
                '    Me.TableLayoutPanel2.Location = New Point(0, 54)
                '    If gblSourceType = "I" Then
                '        Me.dgv_FavorData.Height = 190
                '    Else
                '        Me.dgv_FavorData.Height = 420
                '    End If
                '    Me.dgv_FavorData.Width = 965
                '    Me.dgv_FavorData.DefaultCellStyle.Font = New Font("新細明體", 10)

                '    If gblDeptCode = "ENR" Then
                '        Me.TableLayoutPanel2.Location = New Point(202, 48)
                '        Me.dgv_FavorData.Height = 300
                '        Me.Panel2.Height = 300
                '        Me.tre_Category.Height = 300

                '        Me.dgv_FavorData.Width = 745
                '        Me.Panel2.Visible = True
                '        Me.tre_Category.Visible = True
                '        Me.Panel2.Location = New Point(4, 45)
                '        Me.Panel2.Width = 200
                '        Me.tre_Category.Width = 200
                '        tre_Category.Font = New Font("新細明體", 11)
                '    End If

                'End If

            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    '全院
    Private Sub rbt_FavorId3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbt_FavorId3.CheckedChanged
        Try
            If rbt_FavorId3.Checked Then

                gblFavorId = ""

                gblInitFlag = True '因修改分類值會觸發查詢功能,因此設定註記為True以避免觸發查詢

                cbo_Dept.Enabled = False
                cbo_Dept2.Enabled = False
                cbo_Station.Enabled = False
                tre_Category.Enabled = False
                tre_Category.Nodes.Clear()
                cbo_Dept.SelectedValue = ""
                cbo_Dept2.SelectedValue = ""

                txt_Pharmacy12Code.Text = ""
                txt_NhiPrice.Text = ""
                txt_OwnPrice.Text = ""

                dgv_FavorData.ClearDS()


                '若為急診且為診斷查詢，則需清空檢索欄位
                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "A" Then
                    txt_OrderName2.Text = ""
                    ds.Clear()
                End If

                '2012-11-16 Add By Alan 住院查詢加入分類Combox
                If gblSourceType = "I" AndAlso (gblFavorTypeId = "E" OrElse gblFavorTypeId = "H" OrElse gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" OrElse gblFavorTypeId = "D") Then
                    cbo_Station.SelectedValue = ""
                End If

                '若為藥品或處置，才啟用分類
                If gblFavorTypeId = "E" Then
                    tre_Category.Enabled = True
                    setCategory(dsInit.Tables(6).Copy)
                ElseIf gblFavorTypeId = "D" Then

                    If (gblSourceType <> "E" AndAlso gblSourceType <> "I") Then
                        tre_Category.Enabled = True
                        If dsCateOrder.Tables.Count = 0 Then
                            dsCateOrder.Tables.Add("Order_Category")
                            dsCateOrder.Tables(0).Columns.Add("Favor_Category")
                            dsCateOrder.Tables(0).Rows.Add()
                            dsCateOrder.Tables(0).Rows(0).Item("Favor_Category") = "治療處置"
                            dsCateOrder.Tables(0).Rows.Add()
                            dsCateOrder.Tables(0).Rows(1).Item("Favor_Category") = "手術"
                        End If
                        setCategory(dsCateOrder.Tables(0).Copy)
                    Else
                        If gblDeptCode <> "ENR" Then
                            cbo_Dept.SelectedValue = "++"
                            cbo_Dept2.SelectedValue = "++"
                            Dim pvtDeptCode As String = ""
                            If gblSourceType = "O" Then
                                pvtDeptCode = cbo_Dept.SelectedValue
                            ElseIf (gblSourceType = "E" OrElse gblSourceType = "I") Then
                                pvtDeptCode = cbo_Dept2.SelectedValue
                            End If

                            dsCateDept = uclService.queryOMOFavorCategory2(gblSourceType, "2", gblFavorTypeId, pvtDeptCode, gblIsChoiceDcOrder)
                            setCategory(dsCateDept.Tables(0).Copy)
                            If gblSourceType = "O" Then
                                gblCboDept = cbo_Dept.SelectedValue.ToString.Trim
                            ElseIf (gblSourceType = "E" OrElse gblSourceType = "I") Then
                                gblCboDept = cbo_Dept2.SelectedValue.ToString.Trim
                            End If

                        End If
                        cbo_Dept.Enabled = False
                        cbo_Dept2.Enabled = False
                        tre_Category.Enabled = True
                        btn_Query_Click(sender, e)
                    End If

                End If

                gblInitFlag = False '因修改分類值會觸發查詢功能,因此設定註記為True以避免觸發查詢

                If (gblSourceType = "E" AndAlso rbt_Query2.Checked) OrElse _
                   (gblSourceType = "I" AndAlso gblFavorTypeId = "E" AndAlso gblDrugType = "2") OrElse _
                   (gblSourceType = "I" AndAlso gblFavorTypeId = "E" AndAlso gblDrugType = "5") Then
                    btn_Query3_Click(New Object, New System.EventArgs)
                End If

                chk_Chinese.Enabled = True
                txt_OrderName.Enabled = True
                btn_Query.Enabled = True
                btn_OK.Enabled = True

            End If

            'If (gblSourceType = "E" OrElse gblSourceType = "I") Then
            '    If gblFavorTypeId = "H" Then
            '        Me.Panel2.Visible = False
            '        Me.tre_Category.Visible = False
            '        Me.TableLayoutPanel2.Location = New Point(0, 54)
            '        If gblSourceType = "I" Then
            '            Me.dgv_FavorData.Height = 190
            '        Else
            '            Me.dgv_FavorData.Height = 420
            '        End If
            '        Me.dgv_FavorData.Width = 965
            '        Me.dgv_FavorData.DefaultCellStyle.Font = New Font("新細明體", 10)
            '    ElseIf gblFavorTypeId = "D" Then
            '        Me.TableLayoutPanel2.Location = New Point(202, 48)
            '        Me.dgv_FavorData.Width = 745
            '        Me.Panel2.Visible = True
            '        Me.tre_Category.Visible = True
            '        Me.Panel2.Location = New Point(4, 45)
            '        Me.Panel2.Width = 200
            '        Me.tre_Category.Width = 200
            '        tre_Category.Font = New Font("新細明體", 11)
            '        If gblDeptCode = "ENR" Then
            '            tre_Category.Visible = False
            '            Me.TableLayoutPanel2.Location = New Point(0, 54)
            '            Me.dgv_FavorData.Height = 300
            '            Me.dgv_FavorData.Width = 965
            '            Me.Panel2.Visible = False
            '        Else
            '            If gblSourceType = "I" Then
            '                Me.dgv_FavorData.Height = 190
            '                Me.Panel2.Height = 190
            '                Me.tre_Category.Height = 190
            '            Else
            '                Me.dgv_FavorData.Height = 430
            '                Me.Panel2.Height = 430
            '                Me.tre_Category.Height = 430
            '            End If
            '        End If
            '    End If
            'End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    '檢驗(查)科室
    Private Sub rbt_FavorId4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbt_FavorId4.CheckedChanged
        Try

            If rbt_FavorId4.Checked Then

                '2012-11-16 Add By Alan 住院查詢加入分類Combox
                If gblSourceType = "I" AndAlso (gblFavorTypeId = "E" OrElse gblFavorTypeId = "H" OrElse gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2") Then
                    cbo_Station.SelectedValue = ""
                    cbo_Station.Enabled = False
                End If


                '2012-11-22 Modify By Alan
                'If (gblSourceType = "I" AndAlso gblFavorTypeId = "D" AndAlso rbt_FavorId4.Checked) Then

                '    gblFavorId = ""

                '    Me.cbo_Station.Enabled = False
                '    cbo_Station.DataSource = dsInit.Tables(10).Copy
                '    cbo_Station.uclDisplayIndex = "0, 1"
                '    cbo_Station.uclValueIndex = "0"

                '    gblInitFlag = True '因修改分類值會觸發查詢功能,因此設定註記為True以避免觸發查詢

                '    cbo_Dept.Enabled = False
                '    cbo_Dept2.Enabled = False
                '    cbo_Station.Enabled = True
                '    tre_Category.Enabled = True
                '    tre_Category.Nodes.Clear()
                '    cbo_Dept.SelectedValue = ""
                '    cbo_Dept2.SelectedValue = ""

                '    txt_Pharmacy12Code.Text = ""
                '    txt_NhiPrice.Text = ""
                '    txt_OwnPrice.Text = ""

                '    dgv_FavorData.ClearDS()

                '    gblInitFlag = False '因修改分類值會觸發查詢功能,因此設定註記為True以避免觸發查詢

                '    Me.TableLayoutPanel2.Location = New Point(202, 48)
                '    Me.dgv_FavorData.Width = 745
                '    Me.Panel2.Visible = True
                '    Me.tre_Category.Visible = True
                '    Me.Panel2.Location = New Point(4, 45)
                '    Me.Panel2.Width = 200
                '    Me.tre_Category.Width = 200
                '    tre_Category.Font = New Font("新細明體", 11)
                '    'Me.dgv_FavorData.Height = 430
                '    If gblSourceType = "I" Then
                '        Me.Panel2.Height = 190
                '        Me.tre_Category.Height = 190
                '    Else
                '        Me.Panel2.Height = 320
                '        Me.tre_Category.Height = 320
                '    End If

                '    dsCateDept = uclService.querySTAPackageDataCategory("D1", gblStation)
                '    setCategory(dsCateDept.Tables(0).Copy)
                '    tre_Category.SelectedNode = tre_Category.Nodes(0)

                '    cbo_Station.SelectedValue = ""
                'ElseIf (gblFavorUseType = "2" AndAlso gblFavorTypeId = "D") Then

                '    Me.cbo_Station.Enabled = True
                '    cbo_Station.DataSource = dsInit.Tables(10).Copy
                '    cbo_Station.uclDisplayIndex = "0, 1"
                '    cbo_Station.uclValueIndex = "0"

                '    tre_Category.Nodes.Clear()
                '    dsCateDept = uclService.querySTAPackageDataCategory("D1", gblStation)
                '    setCategory(dsCateDept.Tables(0).Copy)
                '    tre_Category.SelectedNode = tre_Category.Nodes(0)

                'Else

                '    If (gblSourceType = "E" OrElse (gblSourceType = "I" AndAlso gblFavorTypeId <> "E")) Then

                '        If gblSourceType = "E" Then
                '            Me.TableLayoutPanel2.Location = New Point(202, 48)
                '        Else
                '            Me.TableLayoutPanel2.Location = New Point(302, 48)
                '        End If


                '        If gblEmgExam Then
                '            Me.dgv_FavorData.Height = 345
                '        Else
                '            If gblSourceType = "I" Then
                '                Me.dgv_FavorData.Height = 190
                '                Me.dgv_FavorData.Width = 645
                '            Else
                '                Me.dgv_FavorData.Height = 430
                '                Me.dgv_FavorData.Width = 745
                '            End If
                '        End If

                '        Me.Panel2.Visible = True
                '        Me.tre_Category.Visible = True
                '        Me.Panel2.Location = New Point(4, 45)
                '        If gblSourceType = "I" Then
                '            Me.Panel2.Height = 190
                '            Me.tre_Category.Height = 190
                '            Me.Panel2.Width = 300
                '            Me.tre_Category.Width = 300
                '        Else
                '            Me.Panel2.Height = 430
                '            Me.tre_Category.Height = 430
                '            Me.Panel2.Width = 200
                '            Me.tre_Category.Width = 200
                '        End If

                '        tre_Category.Font = New Font("新細明體", 11)

                '    End If

                tre_Category.Enabled = True
                gblFavorId = ""
                gblIsSelectGroup = False
                cbo_Dept.Enabled = False
                cbo_Dept2.Enabled = False
                cbo_Dept.SelectedValue = ""
                cbo_Dept2.SelectedValue = ""

                dgv_FavorData.ClearDS()
                tre_Category.Nodes.Clear()
                btn_Query_Click(sender, e)

                chk_Chinese.Enabled = False
                txt_OrderName.Text = ""
                txt_OrderName.Enabled = False
                btn_Query.Enabled = False
                'btn_OK.Enabled = False

                'End If

            End If

        Catch ex As Exception

            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ' 切換中英文名稱    
    Private Sub chk_Chinese_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Chinese.CheckedChanged
        Try
            TableLayoutPanel2.Visible = False
            If chk_Chinese.Checked = True Then
                dgv_FavorData.SetDS(dsChineseName.Copy)
                dgv_FavorData.uclColumnWidth = gblColumnWidth
            Else
                dgv_FavorData.SetDS(dsOrderName.Copy)
                dgv_FavorData.uclColumnWidth = gblColumnWidth
            End If
            TableLayoutPanel2.Visible = True
        Catch ex As Exception
            ' ClientExceptionHandler.ProccessException(ex)
            'Console.WriteLine(ex.ToString)
            TableLayoutPanel2.Visible = True
        End Try
    End Sub

    Private Function getCategory() As String
        Dim pvtCategory As String = ""
        '因第0行為空白，故由第1行開始判斷是否選取
        If rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked OrElse _
           ((gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "D") OrElse _
           (gblFavorUseType = "2" AndAlso gblFavorTypeId = "D") Then
            If gblSourceType = "E" AndAlso gblFavorTypeId = "A" Then
                For i = 0 To tre_Category.Nodes.Count - 2
                    If tre_Category.Nodes(i).IsSelected Then
                        pvtCategory = tre_Category.Nodes(i).Text.ToString.Trim
                        Exit For
                    End If
                Next
            Else
                If gblSourceType = "I" OrElse (gblFavorUseType = "2" AndAlso gblFavorTypeId = "D" AndAlso rbt_FavorId4.Checked) Then
                    For i = 0 To tre_Category.Nodes.Count - 2
                        If tre_Category.Nodes(i).IsSelected Then

                            '2016-09-24 Modify by Alan
                            pvtCategory = tre_Category.Nodes(i).Text.ToString.Trim
                            'pvtCategory = dsCateDept.Tables(0).Rows(i).Item("Code_Id").ToString.Trim

                            Exit For
                        End If
                    Next
                Else
                    For i = 1 To tre_Category.Nodes.Count - 1
                        If tre_Category.Nodes(i).IsSelected Then
                            pvtCategory = tre_Category.Nodes(i).Text.ToString.Trim
                            Exit For
                        End If
                    Next
                End If

            End If

        Else
            For i = 1 To tre_Category.Nodes.Count - 1
                If tre_Category.Nodes(i).IsSelected Then
                    'pvtCategory = dsInit.Tables(6).Rows(i - 1).Item(0).ToString.Trim
                    pvtCategory = tre_Category.Nodes(i).Text.ToString.Trim
                    Exit For
                End If
            Next
        End If

        '2012-11-16 Add By Alan 住院查詢加入分類Combox
        If gblSourceType = "I" AndAlso (gblFavorTypeId = "E" OrElse gblFavorTypeId = "H" OrElse gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" OrElse gblFavorTypeId = "D") AndAlso (rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked) Then
            '2016-09-25 Delete by Alan
            'pvtCategory = cbo_Station.SelectedValue
        End If


        pvtCategory = pvtCategory.Replace("'", "''")

        Return pvtCategory
    End Function

    Private Sub setCategory(ByVal dt As DataTable)
        tre_Category.Nodes.Clear()

        If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso dt.TableName = "EMO_Op_Menu" Then

            Dim pvtTag As ArrayList      '節點Tag
            'Dim pvtNode As String
            Dim pvtChildNodes As Integer
            Dim pvtFindFlag As Boolean

            For i = 0 To dt.Rows.Count - 1
                pvtFindFlag = False
                pvtTag = New ArrayList
                'Console.WriteLine("i=" & i)
                'Console.WriteLine("Value=" & dt.Rows(i).Item("Category_Code").ToString.Trim)
                'If i = 33 Then
                '    Console.WriteLine("i=" & i)
                'End If
                '建立第1層節點
                If dt.Rows(i).Item("Parent_Category_Code").ToString.Trim = "" Then
                    tre_Category.Nodes.Add(dt.Rows(i).Item("Category_Name").ToString.Trim)
                    pvtTag.Add(dt.Rows(i).Item("Category_Code").ToString.Trim)
                    pvtTag.Add(dt.Rows(i).Item("Code_Start_Bound").ToString.Trim)
                    pvtTag.Add(dt.Rows(i).Item("Code_End_Bound").ToString.Trim)
                    pvtChildNodes = tre_Category.Nodes.Count
                    tre_Category.Nodes(pvtChildNodes - 1).Tag = pvtTag
                Else
                    '搜尋第1層
                    For p = 0 To tre_Category.Nodes.Count - 1
                        If dt.Rows(i).Item("Parent_Category_Code").ToString.Trim = tre_Category.Nodes(p).Tag(0) Then
                            tre_Category.Nodes(p).Nodes.Add(dt.Rows(i).Item("Category_Name").ToString.Trim)
                            pvtTag.Add(dt.Rows(i).Item("Category_Code").ToString.Trim)
                            pvtTag.Add(dt.Rows(i).Item("Code_Start_Bound").ToString.Trim)
                            pvtTag.Add(dt.Rows(i).Item("Code_End_Bound").ToString.Trim)
                            pvtChildNodes = tre_Category.Nodes(p).Nodes.Count
                            tre_Category.Nodes(p).Nodes(pvtChildNodes - 1).Tag = pvtTag
                            Exit For
                        Else

                            '搜尋第2層
                            If tre_Category.Nodes(p).Nodes.Count > 0 Then
                                For q = 0 To tre_Category.Nodes(p).Nodes.Count - 1
                                    If dt.Rows(i).Item("Parent_Category_Code").ToString.Trim = tre_Category.Nodes(p).Nodes(q).Tag(0) Then
                                        tre_Category.Nodes(p).Nodes(q).Nodes.Add(dt.Rows(i).Item("Category_Name").ToString.Trim)
                                        pvtTag.Add(dt.Rows(i).Item("Category_Code").ToString.Trim)
                                        pvtTag.Add(dt.Rows(i).Item("Code_Start_Bound").ToString.Trim)
                                        pvtTag.Add(dt.Rows(i).Item("Code_End_Bound").ToString.Trim)
                                        pvtChildNodes = tre_Category.Nodes(p).Nodes(q).Nodes.Count
                                        tre_Category.Nodes(p).Nodes(q).Nodes(pvtChildNodes - 1).Tag = pvtTag

                                        pvtFindFlag = True

                                        Exit For

                                    End If
                                Next
                            End If

                            If pvtFindFlag Then Exit For

                        End If
                    Next

                End If
            Next
        Else
            If rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked Then
                If gblSourceType = "E" AndAlso gblFavorTypeId = "A" Then
                    For i = 0 To dt.Rows.Count - 1
                        tre_Category.Nodes.Add(dt.Rows(i).Item("Favor_Category").ToString.Trim)
                    Next
                    tre_Category.Nodes.Add("全部")
                Else
                    For i = 0 To dt.Rows.Count
                        If i <> 0 Then
                            tre_Category.Nodes.Add(dt.Rows(i - 1).Item("Favor_Category").ToString.Trim)
                        Else
                            tre_Category.Nodes.Add("全部")
                        End If
                    Next
                End If

            ElseIf rbt_FavorId3.Checked Then
                If gblSourceType = "E" AndAlso gblFavorTypeId = "A" Then
                    For i = 0 To dt.Rows.Count - 1
                        tre_Category.Nodes.Add(dt.Rows(i - 1).Item("Favor_Category").ToString.Trim)
                    Next
                    tre_Category.Nodes.Add("全部")
                Else
                    For i = 0 To dt.Rows.Count
                        If i <> 0 Then
                            If gblFavorTypeId = "E" Then
                                tre_Category.Nodes.Add(dt.Rows(i - 1).Item("Class_En_Name").ToString.Trim)
                            Else
                                tre_Category.Nodes.Add(dt.Rows(i - 1).Item("Favor_Category").ToString.Trim)
                            End If

                        Else
                            tre_Category.Nodes.Add("全部")
                        End If
                    Next
                End If

            ElseIf rbt_FavorId4.Checked Then

                If (gblSourceType = "I" AndAlso gblFavorTypeId = "D") OrElse (gblFavorUseType = "2" AndAlso gblFavorTypeId = "D") Then
                    For i = 0 To dt.Rows.Count - 1
                        tre_Category.Nodes.Add(dt.Rows(i).Item("Code_Name").ToString.Trim)
                    Next
                    tre_Category.Nodes.Add("全部")
                End If

            End If
        End If

    End Sub

    Private Function ResetGridData(ByVal inColumns As Integer) As String
        Dim outColumnWidth As String = ""
        Dim columnNameDB(inColumns * 2 - 1) As String

        For i = 0 To inColumns - 1
            columnNameDB(i * 2) = "Flag" & i
            columnNameDB(i * 2 + 1) = "OrderName" & i
            If outColumnWidth <> "" Then
                If (gblSourceType = "E" OrElse gblSourceType = "I") Then
                    '2011-08-30 Modify By Alan
                    If gblFavorTypeId <> "H" AndAlso gblFavorTypeId <> "H1" AndAlso gblFavorTypeId <> "H2" AndAlso gblFavorTypeId <> "D" Then
                        If gblFavorTypeId = "E" Then
                            outColumnWidth &= ",5,245"
                        Else
                            outColumnWidth &= ",20,245"
                        End If

                    Else
                        If rbt_FavorId4.Checked Then
                            outColumnWidth &= ",5,350"
                        Else
                            outColumnWidth &= ",5,280"
                        End If
                    End If
                Else
                    outColumnWidth &= ",20,245"
                End If

            Else
                If (gblSourceType = "E" OrElse gblSourceType = "I") Then
                    '2011-08-30 Modify By Alan
                    If gblFavorTypeId <> "H" AndAlso gblFavorTypeId <> "H1" AndAlso gblFavorTypeId <> "H2" AndAlso gblFavorTypeId <> "D" Then
                        If gblFavorTypeId = "E" Then
                            outColumnWidth &= "5,245"
                        Else
                            outColumnWidth &= "20,245"
                        End If
                    Else
                        If rbt_FavorId4.Checked Then
                            outColumnWidth &= "5,350"
                        Else
                            outColumnWidth &= "5,280"
                        End If
                    End If
                Else
                    outColumnWidth &= "20,245"
                End If

            End If

        Next

        If dsOrderName.Tables.Contains("OrderName") Then
            dsOrderName.Tables.Remove("OrderName")
        End If

        If dsChineseName.Tables.Contains("ChineseName") Then
            dsChineseName.Tables.Remove("ChineseName")
        End If

        dsOrderName = genDataSet(dsOrderName, "OrderName", columnNameDB)
        dsChineseName = genDataSet(dsChineseName, "ChineseName", columnNameDB)

        Return outColumnWidth
    End Function

    Private Function ResetGridDataForVertical(ByVal inColumns As Integer) As String
        Dim outColumnWidth As String = ""
        Dim columnNameDB(inColumns * 2 - 1) As String

        For i = 0 To inColumns - 1
            columnNameDB(i * 2) = "Flag" & i
            columnNameDB(i * 2 + 1) = "OrderName" & i
            If outColumnWidth <> "" Then
                If (gblSourceType = "E" OrElse gblSourceType = "I") Then
                    '2011-08-30 Modify By Alan
                    If gblFavorTypeId <> "H" AndAlso gblFavorTypeId <> "H1" AndAlso gblFavorTypeId <> "H2" AndAlso gblFavorTypeId <> "D" Then
                        If gblFavorTypeId = "E" Then
                            outColumnWidth &= ",5,340"
                        Else
                            outColumnWidth &= ",20,340"
                        End If

                    Else
                        If rbt_FavorId4.Checked Then
                            outColumnWidth &= ",5,350"
                        Else
                            outColumnWidth &= ",5,280"
                        End If
                    End If
                Else
                    outColumnWidth &= ",20,340"
                End If

            Else
                If (gblSourceType = "E" OrElse gblSourceType = "I") Then
                    '2011-08-30 Modify By Alan
                    If gblFavorTypeId <> "H" AndAlso gblFavorTypeId <> "H1" AndAlso gblFavorTypeId <> "H2" AndAlso gblFavorTypeId <> "D" Then
                        If gblFavorTypeId = "E" Then
                            outColumnWidth &= "5,340"
                        Else
                            outColumnWidth &= "20,340"
                        End If
                    Else
                        If rbt_FavorId4.Checked Then
                            outColumnWidth &= "5,350"
                        Else
                            outColumnWidth &= "5,280"
                        End If
                    End If
                Else
                    outColumnWidth &= "20,340"
                End If

            End If

        Next

        If dsOrderName.Tables.Contains("OrderName") Then
            dsOrderName.Tables.Remove("OrderName")
        End If

        If dsChineseName.Tables.Contains("ChineseName") Then
            dsChineseName.Tables.Remove("ChineseName")
        End If

        dsOrderName = genDataSet(dsOrderName, "OrderName", columnNameDB)
        dsChineseName = genDataSet(dsChineseName, "ChineseName", columnNameDB)

        Return outColumnWidth
    End Function

    Function genDataSet(ByVal saveData As DataSet, ByVal tableName As String, ByVal columnNameDB As Array) As DataSet

        saveData.Tables.Add(tableName)

        '新增Table的欄位
        For i As Integer = 0 To columnNameDB.Length - 1
            saveData.Tables(saveData.Tables.Count - 1).Columns.Add(columnNameDB(i))
        Next
        Return saveData
    End Function

    Private Sub UCLOrderFavorDialogUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ShowForm()
    End Sub

    Private Sub tre_Category_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tre_Category.AfterSelect

        If gblEmgOpFlag Then

            Dim pvtLevel As Integer
            pvtLevel = e.Node.Level

            Select Case pvtLevel
                Case 1
                    gblSheetData = tre_Category.Nodes(e.Node.Parent.Index).Nodes(e.Node.Index).Tag
                Case 2
                    gblSheetData = tre_Category.Nodes(e.Node.Parent.Parent.Index).Nodes(e.Node.Parent.Index).Nodes(e.Node.Index).Tag
            End Select

            If gblSheetData(1) <> "" Then
                btn_Query_Click(sender, e)
            End If

        ElseIf rbt_FavorId1.Checked OrElse rbt_FavorId2.Checked OrElse rbt_FavorId3.Checked Then

            If gblInitFlag = False Then
                btn_Query_Click(sender, e)
            End If

            For i = 0 To tre_Category.Nodes.Count - 1
                If tre_Category.Nodes(i).IsSelected Then
                    tre_Category.Nodes(i).BackColor = Color.DeepSkyBlue
                    tre_Category.Nodes(i).ForeColor = Color.White
                Else
                    tre_Category.Nodes(i).BackColor = Color.White
                    tre_Category.Nodes(i).ForeColor = Color.Black
                End If
            Next

        Else    '檢驗檢查單

            If (gblSourceType = "I" AndAlso gblFavorTypeId = "D") OrElse (gblFavorUseType = "2" AndAlso gblFavorTypeId = "D") Then
                btn_Query_Click(sender, e)
                For i = 0 To tre_Category.Nodes.Count - 1
                    If tre_Category.Nodes(i).IsSelected Then
                        tre_Category.Nodes(i).BackColor = Color.DeepSkyBlue
                        tre_Category.Nodes(i).ForeColor = Color.White
                    Else
                        tre_Category.Nodes(i).BackColor = Color.White
                        tre_Category.Nodes(i).ForeColor = Color.Black
                    End If
                Next
            Else

                If e.Node.Level = 2 Then
                    gblSheetData = tre_Category.Nodes(e.Node.Parent.Parent.Index).Nodes(e.Node.Parent.Index).Tag
                    gblSheetGroup = tre_Category.Nodes(e.Node.Parent.Parent.Index).Nodes(e.Node.Parent.Index).Nodes(e.Node.Index).Tag
                    gblIsSelectGroup = True
                    btn_Query_Click(sender, e)
                ElseIf e.Node.Level = 1 Then
                    gblSheetData = tre_Category.Nodes(e.Node.Parent.Index).Nodes(e.Node.Index).Tag
                    gblSheetGroup = ""
                    gblIsSelectGroup = True
                    btn_Query_Click(sender, e)

                    For p = 0 To gblEmgExamList.Count - 1
                        If gblEmgExamList(p).ToString.Trim = gblSheetData(0).ToString.Trim Then
                            setExamOrder(gblEmgExamList.Item(p))
                        End If
                    Next
                End If

            End If

        End If

    End Sub

    '設定科室與表單節點
    Private Sub setSheetDeptNode()
        Dim pvtSheetDept As String = ""
        Dim pvtSheetCode As String = ""
        Dim pvtSheetName As String = ""
        Dim pvtTreeIndex As Integer       '科別節點索引
        Dim pvtSheetIndex As Integer      '表單節點索引
        Dim pvtSheetTag As ArrayList      '表單節點Tag  

        tre_Category.Nodes.Clear()

        For i = 0 To dsSheet.Tables(0).Rows.Count - 1

            pvtSheetTag = New ArrayList

            If pvtSheetDept = "" OrElse pvtSheetDept <> dsSheet.Tables(0).Rows(i).Item("Dept_Name").ToString.Trim Then

                If pvtSheetDept <> "" Then
                    pvtTreeIndex += 1
                Else
                    pvtTreeIndex = 0
                End If

                pvtSheetIndex = 0

                pvtSheetDept = dsSheet.Tables(0).Rows(i).Item("Dept_Name").ToString.Trim

                tre_Category.Nodes.Add(pvtSheetDept)
                tre_Category.Nodes(pvtTreeIndex).Tag = dsSheet.Tables(0).Rows(i).Item("Dept_Code").ToString.Trim

                If (gblSourceType = "E" OrElse gblSourceType = "I") Then
                    tre_Category.Nodes(pvtTreeIndex).Nodes.Add("(" & dsSheet.Tables(0).Rows(i).Item("Sheet_Code").ToString.Trim & ")" & _
                                                           dsSheet.Tables(0).Rows(i).Item("Sheet_Name").ToString.Trim)
                Else
                    tre_Category.Nodes(pvtTreeIndex).Nodes.Add(dsSheet.Tables(0).Rows(i).Item("Sheet_Name").ToString.Trim & _
                                                               "(" & dsSheet.Tables(0).Rows(i).Item("Sheet_Code").ToString.Trim & ")")
                End If

                pvtSheetCode = dsSheet.Tables(0).Rows(i).Item("Sheet_Code").ToString.Trim
                pvtSheetName = dsSheet.Tables(0).Rows(i).Item("Sheet_Name").ToString.Trim

                pvtSheetTag.Add(pvtSheetCode)     '表單代碼
                pvtSheetTag.Add(dsSheet.Tables(0).Rows(i).Item("Sheet_Type_Id").ToString.Trim)  '表單類別=> 1:檢驗表單 2:檢查表單
                pvtSheetTag.Add(pvtTreeIndex)                                                   '父節點索引
                pvtSheetTag.Add(pvtSheetName)
                pvtSheetTag.Add(dsSheet.Tables(0).Rows(i).Item("Dept_Code").ToString.Trim)

                tre_Category.Nodes(pvtTreeIndex).Nodes(pvtSheetIndex).Tag = pvtSheetTag
            Else

                If pvtSheetCode <> dsSheet.Tables(0).Rows(i).Item("Sheet_Code").ToString.Trim Then
                    pvtSheetIndex += 1

                    If (gblSourceType = "E" OrElse gblSourceType = "I") Then
                        tre_Category.Nodes(pvtTreeIndex).Nodes.Add("(" & dsSheet.Tables(0).Rows(i).Item("Sheet_Code").ToString.Trim & ")" & _
                                                               dsSheet.Tables(0).Rows(i).Item("Sheet_Name").ToString.Trim)
                    Else
                        tre_Category.Nodes(pvtTreeIndex).Nodes.Add(dsSheet.Tables(0).Rows(i).Item("Sheet_Name").ToString.Trim & _
                                                                   "(" & dsSheet.Tables(0).Rows(i).Item("Sheet_Code").ToString.Trim & ")")
                    End If


                    pvtSheetTag.Add(dsSheet.Tables(0).Rows(i).Item("Sheet_Code").ToString.Trim)     '表單代碼
                    pvtSheetTag.Add(dsSheet.Tables(0).Rows(i).Item("Sheet_Type_Id").ToString.Trim) '表單類別=> 1:檢驗表單 2:檢查表單
                    pvtSheetTag.Add(pvtTreeIndex)                                                   '父節點索引
                    pvtSheetTag.Add(dsSheet.Tables(0).Rows(i).Item("Sheet_Name").ToString.Trim)
                    pvtSheetTag.Add(dsSheet.Tables(0).Rows(i).Item("Dept_Code").ToString.Trim)


                    tre_Category.Nodes(pvtTreeIndex).Nodes(pvtSheetIndex).Tag = pvtSheetTag
                    tre_Category.Nodes(pvtTreeIndex).Nodes(pvtSheetIndex).Checked = False
                End If

            End If

            '先行新增子節點
            If gblEmgExam = False Then
                tre_Category.Nodes(pvtTreeIndex).Nodes(pvtSheetIndex).Nodes.Add("")
            End If

        Next

        If gblFavorTypeId = "H1" Then
            tre_Category.Nodes(0).Expand()
        End If

    End Sub

    Private Sub tre_Category_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tre_Category.BeforeExpand
        Select Case e.Node.Level
            Case 1
                If rbt_FavorId4.Checked AndAlso gblEmgExam = False Then
                    '未展開SheetDetail才需執行展開動作
                    If tre_Category.Nodes(e.Node.Parent.Index).Nodes(e.Node.Index).Nodes.Count > 0 AndAlso _
                       tre_Category.Nodes(e.Node.Parent.Index).Nodes(e.Node.Index).Nodes(0).Name = "" Then
                        Dim pvtSheetData As New ArrayList
                        tre_Category.Nodes(e.Node.Parent.Index).Nodes(e.Node.Index).Nodes(0).Remove()
                        pvtSheetData = tre_Category.Nodes(e.Node.Parent.Index).Nodes(e.Node.Index).Tag
                        ExpandSheetDetail(e, pvtSheetData.Item(0), pvtSheetData.Item(1))
                    End If
                End If
        End Select
    End Sub

    Private Sub ExpandSheetDetail(ByVal e As System.Windows.Forms.TreeViewCancelEventArgs, ByVal SheetCode As String, ByVal SheetTypeId As String)

        Dim pvtSheetDetail As DataSet

        If SheetTypeId = "1" Then   '檢驗醫令
            pvtSheetDetail = uclService.queryOMOOrderFavorSheetDetailByLab2(gblSourceType, SheetCode, gblIsChoiceDcOrder)
        Else    '檢查醫令
            pvtSheetDetail = uclService.queryOMOOrderFavorSheetDetailByExam2(gblSourceType, SheetCode, gblIsChoiceDcOrder)
        End If

        Dim pvtSheetGroup As String = ""
        Dim pvtTreeIndex As Integer       '表單群組節點索引

        tre_Category.Nodes(e.Node.Parent.Index).Nodes(e.Node.Index).Nodes.Clear()

        For i = 0 To pvtSheetDetail.Tables(0).Rows.Count - 1


            If pvtSheetGroup = "" OrElse pvtSheetGroup <> pvtSheetDetail.Tables(0).Rows(i).Item("Sheet_Group").ToString.Trim Then

                If pvtSheetGroup <> "" Then
                    pvtTreeIndex += 1
                Else
                    pvtTreeIndex = 0
                End If

                pvtSheetGroup = pvtSheetDetail.Tables(0).Rows(i).Item("Sheet_Group").ToString.Trim

                tre_Category.Nodes(e.Node.Parent.Index).Nodes(e.Node.Index).Nodes.Add(pvtSheetDetail.Tables(0).Rows(i).Item("Sheet_Group_Name").ToString.Trim)

                tre_Category.Nodes(e.Node.Parent.Index).Nodes(e.Node.Index).Nodes(pvtTreeIndex).Tag = pvtSheetGroup

            End If

        Next

    End Sub

    Private Sub dgv_FavorData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_FavorData.CellClick
        gblRowIndex = e.RowIndex
        gblColumnIndex = e.ColumnIndex \ 2

        Dim pvtIsEmgDrugGroup As Boolean = False

        If ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim <> "" Then
            If gblSourceType = "E" AndAlso (gblFavorTypeId = "E" OrElse gblFavorTypeId = "I") Then
                If ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Favor_Category").ToString.Trim = _
                   ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim Then
                    pvtIsEmgDrugGroup = True
                End If
            End If
        End If

        If gblDBClickFlag = False Then
            If gblShowRows * gblColumnIndex + gblRowIndex < gblDataRows Then
                txt_Pharmacy12Code.Text = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim
                If (gblSourceType = "E" OrElse gblSourceType = "I") Then
                    If ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim <> "" AndAlso _
                       dgv_FavorData.Rows(gblRowIndex).Cells(gblColumnIndex * 2).Value = False And pvtIsEmgDrugGroup = False Then
                        If gblFavorTypeId = "A" Then
                            lbl_OrderName.Text = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim
                        Else
                            lbl_OrderName.Text = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim & "[" & _
                                                 ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim & "]"
                        End If

                    Else
                        lbl_OrderName.Text = ""
                    End If
                Else
                    lbl_OrderName.Text = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
                End If

                txt_NhiPrice.Text = ""
                txt_OwnPrice.Text = ""
                gblOrderCode = txt_Pharmacy12Code.Text

                '若點選CheckBox，則將資料設定至已選取醫令Grid中
                If (gblSourceType = "O" OrElse gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblOrderCode <> "" AndAlso (e.ColumnIndex Mod 2 = 1) AndAlso _
                       (dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Style.BackColor <> Color.LightGray OrElse _
                       (dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Style.BackColor = Color.LightGray AndAlso gblIsReturnLackDrug)) AndAlso
                       dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Style.ForeColor <> Color.Red AndAlso pvtIsEmgDrugGroup = False Then

                    If dgv_FavorData.Rows(gblRowIndex).Cells(gblColumnIndex * 2).Value Then
                        dgv_FavorData.Rows(gblRowIndex).Cells(gblColumnIndex * 2).Value = False
                        '2012-05-29 Add By Alan-若為急診診斷，則需依點選的診斷順序回傳，而非在Grid清單中的排列順序
                        '在此為自選取清單中移除取消的診斷
                        If gblSourceType = "E" And gblFavorTypeId = "A" Then
                            removeSelItem(gblOrderCode)
                        End If
                        If gblEmgExam Then
                            setExamList(tre_Category.SelectedNode.Tag(0), tre_Category.SelectedNode.Tag(3), _
                                    ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim, _
                                    ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Sheet_Group").ToString.Trim, _
                                    False)
                        End If

                    Else
                        dgv_FavorData.Rows(gblRowIndex).Cells(gblColumnIndex * 2).Value = True
                        '2012-05-29 Add By Alan-若為急診診斷，則需依點選的診斷順序回傳，而非在Grid清單中的排列順序
                        '在此為自選取清單中新增選取的診斷
                        If gblSourceType = "E" And gblFavorTypeId = "A" Then
                            returnRowDataForKmuh(False)
                        End If
                        If gblEmgExam Then
                            setExamList(tre_Category.SelectedNode.Tag(0), tre_Category.SelectedNode.Tag(3), _
                                    ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim, _
                                    ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Sheet_Group").ToString.Trim, _
                                    True)
                        End If

                        '若為急診 & 檢驗檢查，則再Chcek是否可選取其他部位
                        If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "H" AndAlso gblFavorTypeId = "H1" AndAlso gblFavorTypeId = "H2" AndAlso _
                           ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Option_Order").ToString.Trim <> "" Then
                            Dim pvtDs As New DataSet
                            pvtDs = uclService.queryPUBExamItemByOrder(gblOrderCode)
                            If pvtDs IsNot Nothing AndAlso pvtDs.Tables IsNot Nothing AndAlso pvtDs.Tables(0).Rows.Count > 0 Then
                                Dim pvtOpenWin As UCLOptionOrderUI = New UCLOptionOrderUI(pvtDs, "    " & ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Favor_Name").ToString.Trim)
                                pvtOpenWin.ShowDialog()
                                dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value = pvtOpenWin.gblOptionName

                                Select Case pvtOpenWin.gblOptionIndex
                                    Case 1
                                        ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code") = pvtDs.Tables(0).Rows(0).Item("Other_Side_Code1").ToString.Trim

                                    Case 2
                                        ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code") = pvtDs.Tables(0).Rows(0).Item("Other_Side_Code2").ToString.Trim

                                End Select


                            End If
                        End If

                    End If

                End If
            End If
        Else
            gblDBClickFlag = False
        End If
    End Sub

    'Private Sub dgv_FavorData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_FavorData.CellDoubleClick
    '    gblDBClickFlag = True
    '    gblRowIndex = e.RowIndex
    '    gblColumnIndex = e.ColumnIndex \ 2

    '    If gblShowRows * gblColumnIndex + gblRowIndex < gblDataRows Then
    '        txt_Pharmacy12Code.Text = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Code").ToString.Trim
    '        txt_NhiPrice.Text = ""
    '        txt_OwnPrice.Text = ""
    '        gblOrderCode = txt_Pharmacy12Code.Text
    '    End If

    '    If gblOrderCode <> "" Then
    '        'If gblFavorTypeId = "E" OrElse gblFavorTypeId = "I" Then
    '        '    If gblFavorUseType = "2" OrElse ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Favor_Category").ToString.Trim <> gblOrderCode Then
    '        '        returnRowData(True)
    '        '    End If
    '        'Else
    '        '    returnRowData(True)

    '        'End If

    '        returnRowData(True)

    '    End If

    'End Sub

    Private Sub dgv_FavorData_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_FavorData.CellValueChanged
        Select Case e.ColumnIndex Mod 2
            Case 0
                If (gblSourceType = "O" OrElse gblSourceType = "E" OrElse gblSourceType = "I") Then
                    If dgv_FavorData.Rows(gblRowIndex).Cells(gblColumnIndex * 2).Value Then
                        '設為選取&變換顏色
                        dgv_FavorData.GetDBDS.Tables(0).Rows(gblRowIndex).Item(gblColumnIndex * 2) = "Y"
                        dgv_FavorData.GetGridDS.Tables(0).Rows(gblRowIndex).Item(gblColumnIndex * 2) = "Y"
                        dgv_FavorData.Rows(gblRowIndex).Cells(gblColumnIndex * 2 + 1).Style.BackColor = Color.Coral   'Color.PaleTurquoise

                        '將選取資料新增至已選取Grid中
                        'dgv_FavorData_CellDoubleClick(sender, e)
                        returnRowDataForKmuh(True)
                    Else
                        dgv_FavorData.GetDBDS.Tables(0).Rows(gblRowIndex).Item(gblColumnIndex * 2) = "N"
                        dgv_FavorData.GetGridDS.Tables(0).Rows(gblRowIndex).Item(gblColumnIndex * 2) = "N"
                        dgv_FavorData.Rows(gblRowIndex).Cells(gblColumnIndex * 2 + 1).Style.BackColor = Color.White

                        '將該Order自已選取Grid中清除
                        'ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Code").ToString.Trim
                        For p = 0 To dgv_Selected.GetDBDS.Tables(0).Rows.Count - 1

                            If gblFavorTypeId = "H1" AndAlso dgv_Selected.GetDBDS.Tables(0).Columns.Contains("Show_Name") Then
                                If dgv_Selected.GetDBDS.Tables(0).Rows(p).Item("Order_Code").ToString.Trim = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim Then
                                    dgv_Selected.GetDBDS.Tables(0).Rows.RemoveAt(p)
                                    dgv_Selected.GetGridDS.Tables(0).Rows.RemoveAt(p)
                                    dgv_Selected.Refresh()
                                    Exit For
                                End If
                            ElseIf ds.Tables(0).Columns.Contains("Order_En_Name") Then
                                If dgv_Selected.GetDBDS.Tables(0).Rows(p).Item("Order_Code").ToString.Trim & dgv_Selected.GetDBDS.Tables(0).Rows(p).Item("Order_En_Name").ToString.Trim = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim & ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_En_Name").ToString.Trim Then
                                    dgv_Selected.GetDBDS.Tables(0).Rows.RemoveAt(p)
                                    dgv_Selected.GetGridDS.Tables(0).Rows.RemoveAt(p)
                                    dgv_Selected.Refresh()
                                    Exit For
                                End If
                            ElseIf ds.Tables(0).Columns.Contains("Order_Name") Then
                                If dgv_Selected.GetDBDS.Tables(0).Rows(p).Item("Order_Code").ToString.Trim & dgv_Selected.GetDBDS.Tables(0).Rows(p).Item("Order_En_Name").ToString.Trim = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim & ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Name").ToString.Trim Then
                                    dgv_Selected.GetDBDS.Tables(0).Rows.RemoveAt(p)
                                    dgv_Selected.GetGridDS.Tables(0).Rows.RemoveAt(p)
                                    dgv_Selected.Refresh()
                                    Exit For
                                End If
                            End If
                             
                        Next
                         
                    End If

                    dgv_FavorData.ClearSelection()

                End If

        End Select
    End Sub

    'Private Sub returnRowData(ByVal IsDBClick As Boolean)
    '    Try
    '        Dim pvtIsAllowOrder As Boolean = True

    '        '判斷是否超過總筆數
    '        If gblColumnIndex * gblShowRows + gblRowIndex >= gblDataRows Then
    '            pvtIsAllowOrder = False
    '        End If

    '        '若缺藥或高警示藥(麻醉一級管制藥),則不允許開立
    '        If gblFavorTypeId = "E" Then
    '            If gblShowRows * gblColumnIndex + gblRowIndex < gblDataRows AndAlso _
    '                       ((dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Style.BackColor = Color.LightGray AndAlso gblIsReturnLackDrug = False) OrElse _
    '                        dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Style.ForeColor = Color.Red) Then
    '                pvtIsAllowOrder = False
    '            End If
    '        End If

    '        If pvtIsAllowOrder Then
    '            '取得已選取筆數
    '            Dim pvtInsertIndex As Integer = 0
    '            pvtInsertIndex = dgv_Selected.GetDBDS.Tables(0).Rows.Count

    '            '新增資料列
    '            Dim row1 As DataRow
    '            If rbt_FavorId1.Checked = True Or rbt_FavorId2.Checked = True Then
    '                row1 = gblOrderFavorData.Tables(0).NewRow
    '                row1("Show_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
    '                If gblFavorTypeId = "A" Then
    '                    row1("Icd_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Code").ToString.Trim
    '                    row1("Disease_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Name").ToString.Trim
    '                    row1("Is_Chronic_Disease") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Is_Chronic_Disease").ToString.Trim
    '                    row1("Disease_En_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_En_Name").ToString.Trim
    '                Else
    '                    row1("Order_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Code").ToString.Trim
    '                    row1("Order_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Name").ToString.Trim
    '                    row1("Dosage") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Dosage").ToString.Trim
    '                    row1("Dosage_Unit") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Dosage_Unit").ToString.Trim
    '                    row1("Frequency_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Frequency_Code").ToString.Trim
    '                    row1("Usage_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Usage_Code").ToString.Trim
    '                    row1("Days") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Days").ToString.Trim
    '                    row1("Qty") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Qty").ToString.Trim
    '                    row1("Unit") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Unit").ToString.Trim

    '                    If gblFavorTypeId = "J" Then
    '                        row1("Doctor_Dept_Code") = ds.Tables(0).Rows((gblRowIndex * 2) + gblColumnIndex).Item("Doctor_Dept_Code").ToString.Trim
    '                        row1("Age_Group_Id") = ds.Tables(0).Rows((gblRowIndex * 2) + gblColumnIndex).Item("Age_Group_Id").ToString.Trim
    '                        row1("Op_Nameplate_Id") = ds.Tables(0).Rows((gblRowIndex * 2) + gblColumnIndex).Item("Op_Nameplate_Id").ToString.Trim
    '                    End If

    '                    If gblFavorTypeId <> "E" Then row1("Default_Body_Site_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Default_Body_Site_Code").ToString.Trim

    '                    If gblFavorTypeId = "E" Then
    '                        row1("Pharmacy_12_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Pharmacy_12_Code").ToString.Trim
    '                        row1("OPD_Lack_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("OPD_Lack_Id").ToString.Trim
    '                        row1("Drug_Type") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Drug_Type").ToString.Trim
    '                        row1("Order_En_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Name").ToString.Trim
    '                        row1("Form_Kind_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Form_Kind_Id").ToString.Trim
    '                        If ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("M_Property_Id").ToString.Trim.Contains("16") Then
    '                            row1("Is_IVF") = "Y"
    '                        Else
    '                            row1("Is_IVF") = "N"
    '                        End If

    '                        '2012-10-24 Add By Alan-若為急診，需再回傳Times與Remark
    '                        If gblSourceType = "E" Then
    '                            row1("Times") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Times").ToString.Trim
    '                            row1("Remark") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Remark").ToString.Trim
    '                            row1("EMG_Lack_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("EMG_Lack_Id").ToString.Trim
    '                        End If

    '                    Else
    '                        row1("Order_En_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_En_Name").ToString.Trim
    '                    End If

    '                    If gblFavorTypeId = "D" Then
    '                        row1("Default_Side_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Default_Side_Id").ToString.Trim
    '                    Else
    '                        row1("Default_Side_Id") = ""
    '                    End If

    '                    If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "H" AndAlso gblFavorTypeId = "H1" AndAlso gblFavorTypeId = "H2" Then
    '                        row1("Sheet_Group") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Sheet_Group").ToString.Trim
    '                        row1("Sheet_Group_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Sheet_Group_Name").ToString.Trim
    '                    End If

    '                    row1("Nhi_Price") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Nhi_Price").ToString.Trim
    '                    row1("Own_Price") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Own_Price").ToString.Trim
    '                    row1("Specimen_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Specimen_Id").ToString.Trim
    '                    row1("Order_Type_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Type_Id").ToString.Trim

    '                    '2012-05-15 Add By Alan
    '                    '若為急診且為處置或衛材，則需回傳事前審查註記
    '                    If gblSourceType = "E" AndAlso (gblFavorTypeId = "D" OrElse gblFavorTypeId = "G") Then
    '                        row1("Is_Prior_Review") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Is_Prior_Review").ToString.Trim
    '                    End If

    '                    row1("Is_Valid_Order") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Is_Valid_Order").ToString.Trim

    '                End If

    '                gblOrderCode = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Code").ToString.Trim

    '                If ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Is_Package").ToString.Trim <> "Y" Then
    '                    dgv_Selected.InsertRowDbDsAt(row1, pvtInsertIndex)
    '                    dgv_Selected.InsertRowGridDsAt(row1, pvtInsertIndex)
    '                Else
    '                    '取得組合細項醫令
    '                    Dim pvtPackageDs As New DataSet
    '                    If rbt_FavorId1.Checked Then
    '                        pvtPackageDs = uclService.queryOMOOrderFavorDetailOrder3(gblSourceType, gblFavorTypeId, gblDrugType, gblFavorId, gblDoctorCode, ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Code").ToString.Trim, gblChartNo, gblOutpatientSn, gblIsChoiceDcOrder)
    '                    ElseIf rbt_FavorId2.Checked Then
    '                        Dim pvtDeptCode As String = ""
    '                        If gblSourceType = "O" Then
    '                            pvtDeptCode = cbo_Dept.SelectedValue
    '                        ElseIf (gblSourceType = "E" OrElse gblSourceType = "I") Then
    '                            pvtDeptCode = cbo_Dept2.SelectedValue
    '                        End If

    '                        pvtPackageDs = uclService.queryOMOOrderFavorDetailOrder3(gblSourceType, gblFavorTypeId, gblDrugType, gblFavorId, pvtDeptCode, ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Code").ToString.Trim, gblChartNo, gblOutpatientSn, gblIsChoiceDcOrder)
    '                    End If


    '                    If pvtPackageDs IsNot Nothing AndAlso pvtPackageDs.Tables IsNot Nothing AndAlso pvtPackageDs.Tables(0).Rows.Count > 0 Then

    '                        If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "E" Then
    '                            Dim queryUI As New UCLDrugPackageDtlUI With {.seleDs = pvtPackageDs} '呼叫並傳入數據DataSet

    '                            queryUI.StartPosition = FormStartPosition.CenterScreen
    '                            queryUI.Text = "藥品Package之選擇(" & ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Favor_Name").ToString.Trim & ")"
    '                            queryUI.ShowDialog()

    '                            Dim dsReturn As DataSet = queryUI.seleDs '獲取選中資料

    '                            pvtPackageDs = dsReturn

    '                        End If

    '                        For pvtRow = 0 To pvtPackageDs.Tables(0).Rows.Count - 1

    '                            '取得已選取筆數
    '                            pvtInsertIndex = dgv_Selected.GetDBDS.Tables(0).Rows.Count

    '                            row1 = gblOrderFavorData.Tables(0).NewRow
    '                            row1("Show_Name") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Order_Name").ToString.Trim
    '                            row1("Order_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Order_Code").ToString.Trim
    '                            row1("Order_Name") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Order_Name").ToString.Trim
    '                            row1("Dosage") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Dosage").ToString.Trim
    '                            row1("Dosage_Unit") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Dosage_Unit").ToString.Trim
    '                            row1("Frequency_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Frequency_Code").ToString.Trim
    '                            row1("Usage_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Usage_Code").ToString.Trim
    '                            row1("Days") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Days").ToString.Trim
    '                            row1("Qty") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Qty").ToString.Trim
    '                            row1("Unit") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Unit").ToString.Trim

    '                            If gblFavorTypeId = "J" Then
    '                                row1("Doctor_Dept_Code") = ds.Tables(0).Rows((gblRowIndex * 2) + gblColumnIndex).Item("Doctor_Dept_Code").ToString.Trim
    '                                row1("Age_Group_Id") = ds.Tables(0).Rows((gblRowIndex * 2) + gblColumnIndex).Item("Age_Group_Id").ToString.Trim
    '                                row1("Op_Nameplate_Id") = ds.Tables(0).Rows((gblRowIndex * 2) + gblColumnIndex).Item("Op_Nameplate_Id").ToString.Trim
    '                            End If

    '                            If gblFavorTypeId <> "E" Then row1("Default_Body_Site_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Default_Body_Site_Code").ToString.Trim

    '                            If gblFavorTypeId = "E" Then
    '                                row1("Pharmacy_12_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Pharmacy_12_Code").ToString.Trim
    '                                row1("OPD_Lack_Id") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("OPD_Lack_Id").ToString.Trim
    '                                row1("Drug_Type") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Drug_Type").ToString.Trim
    '                                row1("Order_En_Name") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Order_Name").ToString.Trim
    '                                row1("Form_Kind_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Form_Kind_Id").ToString.Trim
    '                                If ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("M_Property_Id").ToString.Trim.Contains("16") Then
    '                                    row1("Is_IVF") = "Y"
    '                                Else
    '                                    row1("Is_IVF") = "N"
    '                                End If

    '                                '2012-10-24 Add By Alan-若為急診，需再回傳Times與Remark
    '                                If gblSourceType = "E" Then
    '                                    row1("Times") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Times").ToString.Trim
    '                                    row1("Remark") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Remark").ToString.Trim
    '                                    row1("EMG_Lack_Id") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("EMG_Lack_Id").ToString.Trim
    '                                    '2013-08-08 hujs for EMG_Lack_Id
    '                                End If

    '                            Else
    '                                row1("Order_En_Name") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Order_En_Name").ToString.Trim
    '                            End If

    '                            If gblFavorTypeId = "D" Then
    '                                row1("Default_Side_Id") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Default_Side_Id").ToString.Trim
    '                            Else
    '                                row1("Default_Side_Id") = ""
    '                            End If

    '                            If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "H" AndAlso gblFavorTypeId = "H1" AndAlso gblFavorTypeId = "H2" Then
    '                                row1("Sheet_Group") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Sheet_Group").ToString.Trim
    '                                row1("Sheet_Group_Name") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Sheet_Group_Name").ToString.Trim
    '                            End If

    '                            If gblFavorTypeId = "H2" Then
    '                                row1("Default_Main_Body_Site_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Default_Main_Body_Site_Code").ToString.Trim
    '                                row1("Default_Body_Site_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Default_Body_Site_Code").ToString.Trim
    '                                row1("Default_Side_Id") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Default_Side_Id").ToString.Trim
    '                            End If

    '                            row1("Nhi_Price") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Nhi_Price").ToString.Trim
    '                            row1("Own_Price") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Own_Price").ToString.Trim
    '                            row1("Specimen_Id") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Specimen_Id").ToString.Trim
    '                            row1("Order_Type_Id") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Order_Type_Id").ToString.Trim
    '                            dgv_Selected.InsertRowDbDsAt(row1, pvtInsertIndex)
    '                            dgv_Selected.InsertRowGridDsAt(row1, pvtInsertIndex)
    '                        Next

    '                    End If

    '                End If


    '            ElseIf (gblSourceType = "I" AndAlso gblFavorTypeId = "E" AndAlso rbt_FavorId4.Checked) OrElse rbt_FavorId3.Checked OrElse gblEmgOpFlag Then  '--------全院-----------

    '                row1 = gblOrderFavorData.Tables(0).NewRow

    '                If gblFavorTypeId <> "A" Then
    '                    row1("Show_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
    '                    row1("Order_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Code").ToString.Trim
    '                    row1("Order_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Name").ToString.Trim
    '                    row1("Dosage") = ""
    '                    row1("Dosage_Unit") = ""
    '                    row1("Frequency_Code") = ""
    '                    row1("Usage_Code") = ""
    '                    row1("Days") = ""
    '                    row1("Qty") = ""
    '                    row1("Unit") = ""

    '                    If gblFavorTypeId = "E" Then
    '                        row1("Pharmacy_12_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Pharmacy_12_Code").ToString.Trim
    '                        row1("OPD_Lack_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("OPD_Lack_Id").ToString.Trim
    '                        'row1("Drug_Type") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Drug_Type").ToString.Trim
    '                        row1("Order_En_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Name").ToString.Trim
    '                        row1("Form_Kind_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Form_Kind_Id").ToString.Trim
    '                        If ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("M_Property_Id").ToString.Trim.Contains("16") Then
    '                            row1("Is_IVF") = "Y"
    '                        Else
    '                            row1("Is_IVF") = "N"
    '                        End If
    '                    Else
    '                        row1("Order_En_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_En_Name").ToString.Trim
    '                    End If

    '                    If gblFavorTypeId = "H" OrElse gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" Then

    '                        If gblFavorTypeId = "H2" Then
    '                            row1("Default_Main_Body_Site_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Default_Main_Body_Site_Code").ToString.Trim
    '                        End If

    '                        row1("Default_Body_Site_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Default_Body_Site_Code").ToString.Trim
    '                        row1("Default_Side_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Default_Side_Id").ToString.Trim
    '                        row1("Specimen_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Specimen_Id").ToString.Trim
    '                        If (gblSourceType = "E" OrElse gblSourceType = "I") Then
    '                            row1("Sheet_Group") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Sheet_Group").ToString.Trim
    '                            row1("Sheet_Group_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Sheet_Group_Name").ToString.Trim
    '                        End If
    '                    Else
    '                        row1("Default_Body_Site_Code") = ""
    '                        row1("Default_Side_Id") = ""
    '                        row1("Specimen_Id") = ""
    '                    End If
    '                    row1("Nhi_Price") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Nhi_Price").ToString.Trim
    '                    row1("Own_Price") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Own_Price").ToString.Trim
    '                    row1("Order_Type_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Type_Id").ToString.Trim
    '                    '2012-05-15 Add By Alan
    '                    '若為急診且為處置或衛材，則需回傳事前審查註記
    '                    If gblSourceType = "E" AndAlso (gblFavorTypeId = "D" OrElse gblFavorTypeId = "G") Then
    '                        row1("Is_Prior_Review") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Is_Prior_Review").ToString.Trim
    '                    End If

    '                    gblOrderCode = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Code").ToString.Trim
    '                    dgv_Selected.InsertRowDbDsAt(row1, pvtInsertIndex)
    '                    dgv_Selected.InsertRowGridDsAt(row1, pvtInsertIndex)
    '                Else
    '                    row1("Icd_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Code").ToString.Trim
    '                    row1("Disease_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Name").ToString.Trim
    '                    row1("Is_Chronic_Disease") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Is_Chronic_Disease").ToString.Trim
    '                    row1("Disease_En_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_En_Name").ToString.Trim
    '                    dgv_Selected.InsertRowDbDsAt(row1, pvtInsertIndex)
    '                    dgv_Selected.InsertRowGridDsAt(row1, pvtInsertIndex)
    '                End If

    '            ElseIf rbt_FavorId4.Checked Then
    '                If (gblSourceType = "I" AndAlso gblFavorTypeId = "D") OrElse _
    '                   (gblFavorUseType = "2" AndAlso gblFavorTypeId = "D") Then
    '                    row1 = gblOrderFavorData.Tables(0).NewRow
    '                    row1("Show_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
    '                    row1("Order_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
    '                    row1("Order_En_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
    '                    row1("Order_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Code").ToString.Trim
    '                    row1("Order_Type_Id") = "P"
    '                Else
    '                    row1 = gblOrderFavorData.Tables(0).NewRow
    '                    row1("Show_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
    '                    row1("Order_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Code").ToString.Trim

    '                    '若為檢驗，則回傳簡稱；若為檢查，則回傳英文名稱 
    '                    If gblSheetData(1) = "1" Then
    '                        row1("Order_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_En_Short_Name").ToString.Trim
    '                        row1("Order_En_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_En_Short_Name").ToString.Trim
    '                    Else
    '                        row1("Order_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_En_Name").ToString.Trim
    '                        row1("Order_En_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_En_Name").ToString.Trim
    '                    End If
    '                    row1("Order_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Name").ToString.Trim
    '                    row1("Dosage") = ""
    '                    row1("Dosage_Unit") = ""
    '                    row1("Frequency_Code") = ""
    '                    row1("Usage_Code") = ""
    '                    row1("Days") = ""
    '                    row1("Qty") = ""
    '                    row1("Unit") = ""
    '                    If gblFavorTypeId = "H2" Then
    '                        row1("Default_Main_Body_Site_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Default_Main_Body_Site_Code").ToString.Trim
    '                    End If
    '                    row1("Default_Body_Site_Code") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Default_Body_Site_Code").ToString.Trim
    '                    row1("Default_Side_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Default_Side_Id").ToString.Trim
    '                    row1("Specimen_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Specimen_Id").ToString.Trim
    '                    row1("Order_Type_Id") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Order_Type_Id").ToString.Trim
    '                    If (gblSourceType = "E" OrElse gblSourceType = "I") Then
    '                        row1("Sheet_Group") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Sheet_Group").ToString.Trim
    '                        row1("Sheet_Group_Name") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Sheet_Group_Name").ToString.Trim
    '                    End If
    '                End If

    '                dgv_Selected.InsertRowDbDsAt(row1, pvtInsertIndex)
    '                dgv_Selected.InsertRowGridDsAt(row1, pvtInsertIndex)
    '            End If

    '            If dgv_Selected.Rows.Count > 0 Then
    '                dgv_Selected.Rows(pvtInsertIndex).Selected = True
    '                dgv_Selected.CurrentCell = dgv_Selected.Item(0, dgv_Selected.Rows.Count - 1)
    '            End If

    '        End If

    '        'If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso IsDBClick Then
    '        '    btn_OK_Click(New Object, New System.EventArgs)
    '        'End If

    '    Catch ex As Exception
    '        Console.WriteLine(ex.ToString)
    '    End Try

    'End Sub

    Private Sub returnRowDataForKmuh(ByVal IsDBClick As Boolean)
        Try
            Dim pvtIsAllowOrder As Boolean = True

            '判斷是否超過總筆數
            If gblColumnIndex * gblShowRows + gblRowIndex >= gblDataRows Then
                pvtIsAllowOrder = False
            End If

            '若缺藥或高警示藥(麻醉一級管制藥),則不允許開立
            If gblFavorTypeId = "E" Then
                If gblShowRows * gblColumnIndex + gblRowIndex < gblDataRows AndAlso _
                           ((dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Style.BackColor = Color.LightGray AndAlso gblIsReturnLackDrug = False) OrElse _
                            dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Style.ForeColor = Color.Red) Then
                    pvtIsAllowOrder = False
                End If
            End If

            If pvtIsAllowOrder Then
                '取得已選取筆數
                Dim pvtInsertIndex As Integer = 0
                pvtInsertIndex = dgv_Selected.GetDBDS.Tables(0).Rows.Count

                '新增資料列
                Dim row1 As DataRow
                If rbt_FavorId1.Checked = True Or rbt_FavorId2.Checked = True Then
                    row1 = gblOrderFavorData.Tables(0).NewRow
                    row1("Show_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
                    If gblFavorTypeId = "A" Then
                        row1("Icd_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim
                        row1("Disease_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Name").ToString.Trim
                        row1("Is_Chronic_Disease") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Is_Chronic_Disease").ToString.Trim
                        row1("Disease_En_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_En_Name").ToString.Trim
                    Else
                        row1("Order_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim
                        row1("Order_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Name").ToString.Trim
                        row1("Dosage") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Dosage").ToString.Trim
                        row1("Dosage_Unit") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Dosage_Unit").ToString.Trim
                        row1("Frequency_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Frequency_Code").ToString.Trim
                        row1("Usage_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Usage_Code").ToString.Trim
                        row1("Days") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Days").ToString.Trim
                        row1("Qty") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Qty").ToString.Trim
                        row1("Unit") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Unit").ToString.Trim

                        If gblFavorTypeId = "J" Then
                            row1("Doctor_Dept_Code") = ds.Tables(0).Rows((gblRowIndex * 2) + gblColumnIndex).Item("Doctor_Dept_Code").ToString.Trim
                            row1("Age_Group_Id") = ds.Tables(0).Rows((gblRowIndex * 2) + gblColumnIndex).Item("Age_Group_Id").ToString.Trim
                            row1("Op_Nameplate_Id") = ds.Tables(0).Rows((gblRowIndex * 2) + gblColumnIndex).Item("Op_Nameplate_Id").ToString.Trim
                        End If

                        If gblFavorTypeId <> "E" Then row1("Default_Body_Site_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Default_Body_Site_Code").ToString.Trim

                        If gblFavorTypeId = "E" Then
                            row1("Pharmacy_12_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Pharmacy_12_Code").ToString.Trim
                            row1("OPD_Lack_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("OPD_Lack_Id").ToString.Trim
                            row1("Drug_Type") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Drug_Type").ToString.Trim
                            row1("Order_En_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Name").ToString.Trim
                            row1("Form_Kind_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Form_Kind_Id").ToString.Trim
                            If ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("M_Property_Id").ToString.Trim.Contains("16") Then
                                row1("Is_IVF") = "Y"
                            Else
                                row1("Is_IVF") = "N"
                            End If

                            '2012-10-24 Add By Alan-若為急診，需再回傳Times與Remark
                            If gblSourceType = "E" Then
                                row1("Times") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Times").ToString.Trim
                                row1("Remark") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Remark").ToString.Trim
                                row1("EMG_Lack_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("EMG_Lack_Id").ToString.Trim
                            End If

                        Else
                            row1("Order_En_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_En_Name").ToString.Trim
                        End If

                        If gblFavorTypeId = "D" Then
                            row1("Default_Side_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Default_Side_Id").ToString.Trim
                        Else
                            row1("Default_Side_Id") = ""
                        End If

                        If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "H" AndAlso gblFavorTypeId = "H1" AndAlso gblFavorTypeId = "H2" Then
                            row1("Sheet_Group") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Sheet_Group").ToString.Trim
                            row1("Sheet_Group_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Sheet_Group_Name").ToString.Trim
                        End If

                        row1("Nhi_Price") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Nhi_Price").ToString.Trim
                        row1("Own_Price") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Own_Price").ToString.Trim
                        row1("Specimen_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Specimen_Id").ToString.Trim
                        row1("Order_Type_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Type_Id").ToString.Trim

                        '2012-05-15 Add By Alan
                        '若為急診且為處置或衛材，則需回傳事前審查註記
                        If gblSourceType = "E" AndAlso (gblFavorTypeId = "D" OrElse gblFavorTypeId = "G") Then
                            row1("Is_Prior_Review") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Is_Prior_Review").ToString.Trim
                        End If

                        row1("Is_Valid_Order") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Is_Valid_Order").ToString.Trim

                    End If

                    gblOrderCode = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim

                    If ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Is_Package").ToString.Trim <> "Y" Then
                        dgv_Selected.InsertRowDbDsAt(row1, pvtInsertIndex)
                        dgv_Selected.InsertRowGridDsAt(row1, pvtInsertIndex)
                    Else
                        '取得組合細項醫令
                        Dim pvtPackageDs As New DataSet
                        If rbt_FavorId1.Checked Then
                            pvtPackageDs = uclService.queryOMOOrderFavorDetailOrder3(gblSourceType, gblFavorTypeId, gblDrugType, gblFavorId, gblDoctorCode, ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim, gblChartNo, gblOutpatientSn, gblIsChoiceDcOrder)
                        ElseIf rbt_FavorId2.Checked Then
                            Dim pvtDeptCode As String = ""
                            If gblSourceType = "O" Then
                                pvtDeptCode = cbo_Dept.SelectedValue
                            ElseIf (gblSourceType = "E" OrElse gblSourceType = "I") Then
                                pvtDeptCode = cbo_Dept2.SelectedValue
                            End If

                            pvtPackageDs = uclService.queryOMOOrderFavorDetailOrder3(gblSourceType, gblFavorTypeId, gblDrugType, gblFavorId, pvtDeptCode, ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim, gblChartNo, gblOutpatientSn, gblIsChoiceDcOrder)
                        End If


                        If pvtPackageDs IsNot Nothing AndAlso pvtPackageDs.Tables IsNot Nothing AndAlso pvtPackageDs.Tables(0).Rows.Count > 0 Then

                            If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "E" Then
                                Dim queryUI As New UCLDrugPackageDtlUI With {.seleDs = pvtPackageDs} '呼叫並傳入數據DataSet

                                queryUI.StartPosition = FormStartPosition.CenterScreen
                                queryUI.Text = "藥品Package之選擇(" & ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Favor_Name").ToString.Trim & ")"
                                queryUI.ShowDialog()

                                Dim dsReturn As DataSet = queryUI.seleDs '獲取選中資料

                                pvtPackageDs = dsReturn

                            End If

                            For pvtRow = 0 To pvtPackageDs.Tables(0).Rows.Count - 1

                                '取得已選取筆數
                                pvtInsertIndex = dgv_Selected.GetDBDS.Tables(0).Rows.Count

                                row1 = gblOrderFavorData.Tables(0).NewRow
                                row1("Show_Name") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Order_Name").ToString.Trim
                                row1("Order_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Order_Code").ToString.Trim
                                row1("Order_Name") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Order_Name").ToString.Trim
                                row1("Dosage") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Dosage").ToString.Trim
                                row1("Dosage_Unit") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Dosage_Unit").ToString.Trim
                                row1("Frequency_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Frequency_Code").ToString.Trim
                                row1("Usage_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Usage_Code").ToString.Trim
                                row1("Days") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Days").ToString.Trim
                                row1("Qty") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Qty").ToString.Trim
                                row1("Unit") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Unit").ToString.Trim

                                If gblFavorTypeId = "J" Then
                                    row1("Doctor_Dept_Code") = ds.Tables(0).Rows((gblRowIndex * 2) + gblColumnIndex).Item("Doctor_Dept_Code").ToString.Trim
                                    row1("Age_Group_Id") = ds.Tables(0).Rows((gblRowIndex * 2) + gblColumnIndex).Item("Age_Group_Id").ToString.Trim
                                    row1("Op_Nameplate_Id") = ds.Tables(0).Rows((gblRowIndex * 2) + gblColumnIndex).Item("Op_Nameplate_Id").ToString.Trim
                                End If

                                If gblFavorTypeId <> "E" Then row1("Default_Body_Site_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Default_Body_Site_Code").ToString.Trim

                                If gblFavorTypeId = "E" Then
                                    row1("Pharmacy_12_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Pharmacy_12_Code").ToString.Trim
                                    row1("OPD_Lack_Id") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("OPD_Lack_Id").ToString.Trim
                                    row1("Drug_Type") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Drug_Type").ToString.Trim
                                    row1("Order_En_Name") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Order_Name").ToString.Trim
                                    row1("Form_Kind_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Form_Kind_Id").ToString.Trim
                                    If ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("M_Property_Id").ToString.Trim.Contains("16") Then
                                        row1("Is_IVF") = "Y"
                                    Else
                                        row1("Is_IVF") = "N"
                                    End If

                                    '2012-10-24 Add By Alan-若為急診，需再回傳Times與Remark
                                    If gblSourceType = "E" Then
                                        row1("Times") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Times").ToString.Trim
                                        row1("Remark") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Remark").ToString.Trim
                                        row1("EMG_Lack_Id") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("EMG_Lack_Id").ToString.Trim
                                        '2013-08-08 hujs for EMG_Lack_Id
                                    End If

                                Else
                                    row1("Order_En_Name") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Order_En_Name").ToString.Trim
                                End If

                                If gblFavorTypeId = "D" Then
                                    row1("Default_Side_Id") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Default_Side_Id").ToString.Trim
                                Else
                                    row1("Default_Side_Id") = ""
                                End If

                                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "H" AndAlso gblFavorTypeId = "H1" AndAlso gblFavorTypeId = "H2" Then
                                    row1("Sheet_Group") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Sheet_Group").ToString.Trim
                                    row1("Sheet_Group_Name") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Sheet_Group_Name").ToString.Trim
                                End If

                                If gblFavorTypeId = "H2" Then
                                    row1("Default_Main_Body_Site_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Default_Main_Body_Site_Code").ToString.Trim
                                    row1("Default_Body_Site_Code") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Default_Body_Site_Code").ToString.Trim
                                    row1("Default_Side_Id") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Default_Side_Id").ToString.Trim
                                End If

                                row1("Nhi_Price") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Nhi_Price").ToString.Trim
                                row1("Own_Price") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Own_Price").ToString.Trim
                                row1("Specimen_Id") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Specimen_Id").ToString.Trim
                                row1("Order_Type_Id") = pvtPackageDs.Tables(0).Rows(pvtRow).Item("Order_Type_Id").ToString.Trim
                                dgv_Selected.InsertRowDbDsAt(row1, pvtInsertIndex)
                                dgv_Selected.InsertRowGridDsAt(row1, pvtInsertIndex)
                            Next

                        End If

                    End If


                ElseIf (gblSourceType = "I" AndAlso gblFavorTypeId = "E" AndAlso rbt_FavorId4.Checked) OrElse rbt_FavorId3.Checked OrElse gblEmgOpFlag Then  '--------全院-----------

                    row1 = gblOrderFavorData.Tables(0).NewRow

                    If gblFavorTypeId <> "A" Then
                        row1("Show_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
                        row1("Order_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim
                        row1("Order_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Name").ToString.Trim
                        row1("Dosage") = ""
                        row1("Dosage_Unit") = ""
                        row1("Frequency_Code") = ""
                        row1("Usage_Code") = ""
                        row1("Days") = ""
                        row1("Qty") = ""
                        row1("Unit") = ""

                        If gblFavorTypeId = "E" Then
                            row1("Pharmacy_12_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Pharmacy_12_Code").ToString.Trim
                            row1("OPD_Lack_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("OPD_Lack_Id").ToString.Trim
                            'row1("Drug_Type") = ds.Tables(0).Rows(gblShowRows * gblColumnIndex + gblRowIndex).Item("Drug_Type").ToString.Trim
                            row1("Order_En_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Name").ToString.Trim
                            row1("Form_Kind_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Form_Kind_Id").ToString.Trim
                            If ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("M_Property_Id").ToString.Trim.Contains("16") Then
                                row1("Is_IVF") = "Y"
                            Else
                                row1("Is_IVF") = "N"
                            End If
                        Else
                            row1("Order_En_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_En_Name").ToString.Trim
                        End If

                        If gblFavorTypeId = "H" OrElse gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" Then

                            If gblFavorTypeId = "H2" Then
                                row1("Default_Main_Body_Site_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Default_Main_Body_Site_Code").ToString.Trim
                            End If

                            row1("Default_Body_Site_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Default_Body_Site_Code").ToString.Trim
                            row1("Default_Side_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Default_Side_Id").ToString.Trim
                            row1("Specimen_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Specimen_Id").ToString.Trim
                            If (gblSourceType = "E" OrElse gblSourceType = "I") Then
                                row1("Sheet_Group") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Sheet_Group").ToString.Trim
                                row1("Sheet_Group_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Sheet_Group_Name").ToString.Trim
                            End If
                        Else
                            row1("Default_Body_Site_Code") = ""
                            row1("Default_Side_Id") = ""
                            row1("Specimen_Id") = ""
                        End If
                        row1("Nhi_Price") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Nhi_Price").ToString.Trim
                        row1("Own_Price") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Own_Price").ToString.Trim
                        row1("Order_Type_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Type_Id").ToString.Trim
                        '2012-05-15 Add By Alan
                        '若為急診且為處置或衛材，則需回傳事前審查註記
                        If gblSourceType = "E" AndAlso (gblFavorTypeId = "D" OrElse gblFavorTypeId = "G") Then
                            row1("Is_Prior_Review") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Is_Prior_Review").ToString.Trim
                        End If

                        gblOrderCode = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim
                        dgv_Selected.InsertRowDbDsAt(row1, pvtInsertIndex)
                        dgv_Selected.InsertRowGridDsAt(row1, pvtInsertIndex)
                    Else
                        row1("Icd_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim
                        row1("Disease_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Name").ToString.Trim
                        row1("Is_Chronic_Disease") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Is_Chronic_Disease").ToString.Trim
                        row1("Disease_En_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_En_Name").ToString.Trim
                        dgv_Selected.InsertRowDbDsAt(row1, pvtInsertIndex)
                        dgv_Selected.InsertRowGridDsAt(row1, pvtInsertIndex)
                    End If

                ElseIf rbt_FavorId4.Checked Then
                    If (gblSourceType = "I" AndAlso gblFavorTypeId = "D") OrElse _
                       (gblFavorUseType = "2" AndAlso gblFavorTypeId = "D") Then
                        row1 = gblOrderFavorData.Tables(0).NewRow
                        row1("Show_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
                        row1("Order_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
                        row1("Order_En_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
                        row1("Order_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim
                        row1("Order_Type_Id") = "P"
                    Else
                        row1 = gblOrderFavorData.Tables(0).NewRow
                        row1("Show_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
                        row1("Order_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim

                        '若為檢驗，則回傳簡稱；若為檢查，則回傳英文名稱 
                        If gblSheetData(1) = "1" Then
                            row1("Order_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_En_Short_Name").ToString.Trim
                            row1("Order_En_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_En_Short_Name").ToString.Trim
                        Else
                            row1("Order_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_En_Name").ToString.Trim
                            row1("Order_En_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_En_Name").ToString.Trim
                        End If
                        row1("Order_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Name").ToString.Trim
                        row1("Dosage") = ""
                        row1("Dosage_Unit") = ""
                        row1("Frequency_Code") = ""
                        row1("Usage_Code") = ""
                        row1("Days") = ""
                        row1("Qty") = ""
                        row1("Unit") = ""
                        If gblFavorTypeId = "H2" Then
                            row1("Default_Main_Body_Site_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Default_Main_Body_Site_Code").ToString.Trim
                        End If
                        row1("Default_Body_Site_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Default_Body_Site_Code").ToString.Trim
                        row1("Default_Side_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Default_Side_Id").ToString.Trim
                        row1("Specimen_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Specimen_Id").ToString.Trim
                        row1("Order_Type_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Type_Id").ToString.Trim
                        If (gblSourceType = "E" OrElse gblSourceType = "I") Then
                            row1("Sheet_Group") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Sheet_Group").ToString.Trim
                            row1("Sheet_Group_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Sheet_Group_Name").ToString.Trim
                        End If
                    End If

                    dgv_Selected.InsertRowDbDsAt(row1, pvtInsertIndex)
                    dgv_Selected.InsertRowGridDsAt(row1, pvtInsertIndex)
                End If

                If dgv_Selected.Rows.Count > 0 Then
                    dgv_Selected.Rows(pvtInsertIndex).Selected = True
                    dgv_Selected.CurrentCell = dgv_Selected.Item(0, dgv_Selected.Rows.Count - 1)
                End If

            End If

            'If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso IsDBClick Then
            '    btn_OK_Click(New Object, New System.EventArgs)
            'End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

    End Sub

    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click

        If gblEmgExam Then

            OMOSourceUI.InsertFavorOrder("1", gblOrgExamDs)
            Me.Dispose()

        Else
            '若為急診且非DoubleClick，則先將勾選資料塞入已選取GridView中
            'If (gblSourceType = "E" OrElse gblSourceType = "I") Then
            '    If gblFavorTypeId <> "A" Then
            '        Dim pvtTotalCount As Integer = 0
            '        pvtTotalCount = ds.Tables(0).Rows.Count
            '        For p = 0 To pvtTotalCount - 1
            '            gblRowIndex = p Mod gblShowRows
            '            gblColumnIndex = p \ gblShowRows

            '            If dgv_FavorData.Rows(gblRowIndex).Cells(gblColumnIndex * 2).Value Then

            '                If gblDBClickFlag = False Then
            '                    returnRowData(False)
            '                End If

            '                '清除勾選與顏色設定
            '                dgv_FavorData.Rows(gblRowIndex).Cells(gblColumnIndex * 2).Value = False
            '            End If
            '        Next
            '    End If


            '    If gblFavorTypeId = "A" AndAlso (chk_Diabetes.Checked OrElse chk_HighBlood.Checked) Then
            '        '若為急診診斷，且勾選糖尿病或高血壓的處理
            '        If chk_Diabetes.Checked Then
            '            Dim row2 As DataRow
            '            Dim pvtInsertIndex As Integer = 0
            '            pvtInsertIndex = dgv_Selected.GetDBDS.Tables(0).Rows.Count
            '            row2 = gblOrderFavorData.Tables(0).NewRow
            '            row2("Show_Name") = "DM"
            '            row2("Icd_Code") = "25000"
            '            row2("Disease_Name") = "第二型(非胰島素依賴型，成人型)或未明示型糖尿病，未提及併發症，未敘述為無法控制"
            '            row2("Is_Chronic_Disease") = "Y"
            '            row2("Disease_En_Name") = "Diabetes mellitus without mention of complication, Type II [non-insulin dependent type][NIDDM type] [ adult-onset type] or unspecified type, not stated as uncontrolled"
            '            gblOrderCode = "25000"
            '            dgv_Selected.InsertRowDbDsAt(row2, pvtInsertIndex)
            '            dgv_Selected.InsertRowGridDsAt(row2, pvtInsertIndex)
            '        End If

            '        If chk_HighBlood.Checked Then
            '            Dim row2 As DataRow
            '            Dim pvtInsertIndex As Integer = 0
            '            pvtInsertIndex = dgv_Selected.GetDBDS.Tables(0).Rows.Count
            '            row2 = gblOrderFavorData.Tables(0).NewRow
            '            row2("Show_Name") = "Hypertension"
            '            row2("Icd_Code") = "4019"
            '            row2("Disease_Name") = "本態性高血壓"
            '            row2("Is_Chronic_Disease") = "Y"
            '            row2("Disease_En_Name") = "Essential hypertension, unspecified"
            '            gblOrderCode = "4019"
            '            dgv_Selected.InsertRowDbDsAt(row2, pvtInsertIndex)
            '            dgv_Selected.InsertRowGridDsAt(row2, pvtInsertIndex)
            '        End If
            '    End If
            'End If

            Dim pvtCount As Integer = dgv_Selected.GetDBDS.Tables(0).Rows.Count - 1
            For i = 0 To pvtCount
                If dgv_Selected.Rows(i).Cells.Item(0).Value IsNot Nothing AndAlso _
                   dgv_Selected.Rows(i).Cells.Item(0).Value Then
                    dgv_Selected.GetDBDS.Tables(0).Rows.RemoveAt(i)
                    dgv_Selected.GetGridDS.Tables(0).Rows.RemoveAt(i)
                    i -= 1
                    pvtCount -= 1
                    If i = pvtCount Then Exit For
                Else
                    If gblDebugFlag = True Then
                        Console.WriteLine("Order_Code=>" & dgv_Selected.GetDBDS.Tables(0).Rows(i).Item("Order_Code").ToString.Trim & "---" & dgv_Selected.GetDBDS.Tables(0).Rows(i).Item("Show_Name").ToString.Trim)
                        dgv_Selected.GetDBDS.Tables(0).Rows.RemoveAt(i)
                        dgv_Selected.GetGridDS.Tables(0).Rows.RemoveAt(i)
                        i -= 1
                        pvtCount -= 1

                        If i = pvtCount Then Exit For
                    End If

                End If

                If i = pvtCount Then Exit For
            Next

            If gblDebugFlag = False Then

                '若為急診 & 藥品 & 大量點滴則傳回DataSet，其餘逐筆傳回
                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso (gblFavorTypeId = "A" OrElse (gblFavorTypeId = "E" AndAlso gblDrugType = "5")) Then
                    If dgv_Selected.GetDBDS.Tables(0).Rows.Count > 0 Then
                        OMOSourceUI.InsertFavorOrder("1", dgv_Selected.GetDBDS)
                        dgv_Selected.GetDBDS.Tables(0).Rows.Clear()
                        dgv_Selected.GetGridDS.Tables(0).Rows.Clear()
                    End If
                Else
                    If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso (gblFavorTypeId = "E" OrElse gblFavorTypeId = "D" OrElse gblFavorTypeId = "H" OrElse gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" OrElse gblFavorTypeId = "G") Then
                        If dgv_Selected.GetDBDS.Tables(0).Rows.Count > 0 Then
                            OMOSourceUI.InsertFavorOrder("1", dgv_Selected.GetDBDS)
                            dgv_Selected.GetDBDS.Clear()
                            dgv_Selected.GetGridDS.Clear()
                        End If
                    Else
                        Dim pvtRows As Integer
                        pvtRows = dgv_Selected.GetDBDS.Tables(0).Rows.Count
                        For m = 0 To pvtRows - 1
                            OMOSourceUI.InsertFavorOrder("1", dgv_Selected.GetDBDS)
                            dgv_Selected.GetDBDS.Tables(0).Rows.RemoveAt(0)
                        Next
                    End If

                End If

            End If

            Me.dgv_FavorData.ClearSelection()
            lbl_OrderName.Text = ""

            'If gblDebugFlag = False AndAlso gblSourceType = "O" Then Me.Close()
            If gblDebugFlag = False Then Me.Close()
        End If

    End Sub

    Private Sub btn_QueryPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_QueryPrice.Click
        Dim returnPrice As New DataSet
        returnPrice = uclService.queryPUBOrderOwnAndNhiPrice(gblOrderCode)
        If returnPrice IsNot Nothing AndAlso returnPrice.Tables IsNot Nothing AndAlso returnPrice.Tables(0).Rows.Count > 0 Then

            If returnPrice.Tables(0).Rows(0).Item("Own_Price").ToString.Trim <> "" Then
                txt_OwnPrice.Text = returnPrice.Tables(0).Rows(0).Item("Own_Price")
            Else
                txt_OwnPrice.Text = ""
            End If

            If returnPrice.Tables(0).Rows(0).Item("Nhi_Price").ToString.Trim <> "" Then
                txt_NhiPrice.Text = returnPrice.Tables(0).Rows(0).Item("Nhi_Price")
            Else
                txt_NhiPrice.Text = ""
            End If

        Else
            txt_OwnPrice.Text = ""
            txt_NhiPrice.Text = ""
        End If
    End Sub

    Private Sub btn_QueryAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_QueryAll.Click
        btn_UclQueryAll.ucl_Query_Click(sender, e)
    End Sub

    Private Sub btn_Package_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Package.Click
        OMOSourceUI.MyParent.CreateOrderForm.ProcessPackageClick()
    End Sub

    Private Sub cbo_Dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Dept.SelectedIndexChanged
        Try
            If gblInitFlag = False AndAlso gblCboDept <> cbo_Dept.SelectedValue.ToString.Trim Then

                dsCateDept = uclService.queryOMOFavorCategory2(gblSourceType, "2", gblFavorTypeId, cbo_Dept.SelectedValue, gblIsChoiceDcOrder)
                setCategory(dsCateDept.Tables(0).Copy)
                gblCboDept = cbo_Dept.SelectedValue.ToString.Trim

            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Private Sub cbo_Dept2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Dept2.SelectedIndexChanged
        Try
            If gblInitFlag = False AndAlso gblCboDept <> cbo_Dept2.SelectedValue.ToString.Trim Then
                dsCateDept = uclService.queryOMOFavorCategory2(gblSourceType, "2", gblFavorTypeId, cbo_Dept2.SelectedValue, gblIsChoiceDcOrder)
                setCategory(dsCateDept.Tables(0).Copy)
                gblCboDept = cbo_Dept2.SelectedValue.ToString.Trim
                If gblSourceType = "E" AndAlso gblFavorTypeId = "A" Then
                    tre_Category.SelectedNode = tre_Category.Nodes(0)
                End If
                '2012-11-16 Add By Alan 住院查詢加入分類Combox
                If gblSourceType = "I" AndAlso (gblFavorTypeId = "E" OrElse gblFavorTypeId = "H" OrElse gblFavorTypeId = "H1" OrElse gblFavorTypeId = "H2" OrElse gblFavorTypeId = "D") Then
                    cbo_Station.DataSource = dsCateDept.Tables(0).Copy
                    cbo_Station.uclDisplayIndex = "0"
                    cbo_Station.uclValueIndex = "0"
                End If
                btn_Query2_Click(sender, e)
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Dim MyParent As Object
    Public Sub SetParent(ByRef Parent As Object)
        MyParent = Parent
    End Sub

    Private Sub btn_Massrefer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Massrefer.Click

        If gblFavorTypeId = "A" Then
            Me.Dispose()
        Else
            Try
                Dim pvtOrderCode As String
                pvtOrderCode = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim

                'Dim Site As String = "http://172.19.14.107/newhomepage/massrefer_prescription.asp?D_id=" & pvtOrderCode & "&SearchItem1=處方集"
                'Dim Site As String = HospConfig.Prescription107Web & "?D_id=" & pvtOrderCode & "&SearchItem1=處方集"

                Try
                    'System.Diagnostics.Process.Start(Site)
                Catch ex As Exception

                End Try
            Catch ex As Exception
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請先選取要查詢的藥品"})
            End Try

        End If


    End Sub

    Private Sub btn_Looks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Looks.Click

        If gblFavorTypeId = "A" Then
            Me.Dispose()
        Else
            Try
                Dim pvtOrderCode As String
                pvtOrderCode = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim

                'Dim Site As String = "http://172.19.14.107/newhomepage/massrefer_looks.asp?D_id=" & pvtOrderCode & "&SearchItem1=藥品外觀"
                'Dim Site As String = HospConfig.Looks107Web & "?D_id=" & pvtOrderCode & "&SearchItem1=藥品外觀"

                Try

                    'System.Diagnostics.Process.Start(Site)
                Catch ex As Exception

                End Try
            Catch ex As Exception
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請先選取要查詢的藥品"})
            End Try

        End If

    End Sub

    Private Sub rbt_Query1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbt_Query1.CheckedChanged
        If rbt_Query1.Checked Then
            Me.Panel2.Location = New Point(4, 75)
            Me.Panel3.Visible = False
            Me.Panel2.Visible = True
            btn_Query3.Enabled = False
            txt_Index1.Text = ""
            txt_Index2.Text = ""
            txt_Index3.Text = ""
            txt_Index4.Text = ""
            txt_Index5.Text = ""
            If rbt_FavorId1.Checked Then
                rbt_FavorId1_CheckedChanged(sender, e)
            ElseIf rbt_FavorId2.Checked Then
                rbt_FavorId2_CheckedChanged(sender, e)
            Else
                rbt_FavorId3_CheckedChanged(sender, e)
            End If


        End If
    End Sub

    Private Sub rbt_Query2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbt_Query2.CheckedChanged
        If rbt_Query2.Checked Then
            Me.Panel3.Location = New Point(4, 75)
            Me.Panel2.Visible = False
            Me.Panel3.Visible = True
            btn_Query3.Enabled = True
            txt_Index1.Focus()
            tre_Category.Nodes.Clear()
            dgv_FavorData.ClearDS()
        End If
    End Sub

    Private Sub btn_Query3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Query3.Click
        gblEmgDrugQuery = True
        btn_Query_Click(sender, e)
        gblEmgDrugQuery = False
        If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "E" Then
            If gblSourceType = "E" Then rbt_FavorId3.Checked = True
            txt_Index1.Text = ""
            txt_Index2.Text = ""
            txt_Index3.Text = ""
            txt_Index4.Text = ""
            txt_Index5.Text = ""
        End If
    End Sub

    Public Sub ClearSearchIndex()
        Try
            Me.txt_Index1.Text = ""
            Me.txt_Index2.Text = ""
            Me.txt_Index3.Text = ""
            Me.txt_Index4.Text = ""
            Me.txt_Index5.Text = ""
            dgv_FavorData.ClearDS()
            'rbt_FavorId2.Checked = False
            'rbt_FavorId1.Checked = True
            If ds IsNot Nothing AndAlso ds.Tables IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count = 0 Then
                rbt_FavorId2.Checked = True
            End If
            txt_Index1.Focus()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub ClearSearchIndex2()
        Try
            Me.txt_Index1.Text = ""
            Me.txt_Index2.Text = ""
            Me.txt_Index3.Text = ""
            Me.txt_Index4.Text = ""
            Me.txt_Index5.Text = ""
            dgv_FavorData.ClearDS()
            'rbt_FavorId2.Checked = False
            'rbt_FavorId1.Checked = True
            txt_Index1.Focus()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub setExamOrder(ByVal inSheetCode As String)
        Dim pvtSheetCode As String
        Dim pvtOrgRowCount As Integer
        Dim IsSpecimen As Boolean = True
        Dim IsMatch, IsFind As Boolean

        '取得表單代碼
        pvtSheetCode = inSheetCode

        '取得該醫令在樹狀結構中科別與表單的位置
        For i = 0 To tre_Category.Nodes.Count - 1
            gblDeptIndex = i

            For j = 0 To tre_Category.Nodes(i).Nodes.Count - 1
                If tre_Category.Nodes(i).Nodes(j).Tag(0).ToString.Trim = pvtSheetCode Then
                    'Console.WriteLine(tre_Category.Nodes(i).Nodes(j).Tag(0))
                    tre_Category.Nodes(gblDeptIndex).Expand()
                    'pvtSheetName = tre_Category.Nodes(i).Nodes(j).Tag(3)
                    gblSheetIndex = j
                    tre_Category.SelectedNode = tre_Category.Nodes(gblDeptIndex).Nodes(gblSheetIndex)
                    tre_Category.SelectedNode.BackColor = Color.DodgerBlue

                    For p = 0 To gblEmgExamList.Count - 1
                        If gblEmgExamList.Item(p).ToString.Trim = inSheetCode Then
                            IsFind = True
                            Exit For
                        End If
                    Next

                    If IsFind = False Then
                        gblEmgExamList.Add(inSheetCode)
                    End If

                    gblClearSelect = True
                    Exit For
                End If
            Next

            If gblClearSelect Then
                Exit For
            End If
        Next

        pvtOrgRowCount = gblOrgExamDs.Tables(inSheetCode).Rows.Count

        '設定已開立的醫令為選取
        For m = 0 To pvtOrgRowCount - 1
            IsMatch = False
            For j As Integer = 0 To gblShowColumns - 1
                'Console.WriteLine("j=>" & j)
                For i = 0 To gblDataRows - 1
                    'Console.WriteLine("i=>" & i)
                    If gblOrgExamDs.Tables(inSheetCode).Rows(m).Item("Order_Code").ToString.Trim = _
                       ds.Tables(0).Rows(gblShowRows * j + i).Item("Order_Code").ToString.Trim AndAlso _
                       (gblOrgExamDs.Tables(inSheetCode).Rows(m).Item("Sheet_Group").ToString.Trim = _
                        ds.Tables(0).Rows(gblShowRows * j + i).Item("Sheet_Group").ToString.Trim OrElse _
                        gblOrgExamDs.Tables(inSheetCode).Rows(m).Item("Sheet_Group").ToString.Trim = "") Then
                        dgv_FavorData.Rows(i).Cells(j * 2).Value = False
                        dgv_FavorData_CellClick(New Object, New DataGridViewCellEventArgs(2 * j + 1, i))
                        IsMatch = True
                        Exit For
                    End If
                    If i = gblShowRows - 1 OrElse IsMatch Then Exit For
                Next

                If j = gblShowColumns - 1 Then Exit For
            Next
        Next


        '刪除原有的資料
        For p = 0 To pvtOrgRowCount - 1
            gblOrgExamDs.Tables(inSheetCode).Rows.RemoveAt(0)
        Next


    End Sub

    Private Sub setExamList(ByVal inSheetCode As String, ByVal inSheetName As String, _
                            ByVal inOrderCode As String, ByVal inSheetGroup As String, _
                            ByVal inNewFlag As Boolean)

        Dim pvtListIndex As Integer = -1
        Dim pvtTabIndex As Integer
        Dim pvtShowText, pvtOrderName As String
        Dim pvtAddFlag As Boolean

        '先判斷表單是否已存在ListBox中
        For p = 0 To gblEmgExamList.Count - 1
            If gblEmgExamList.Item(p).ToString.Trim = inSheetCode Then
                pvtListIndex = p
                Exit For
            End If
        Next

        If pvtListIndex <> -1 Then
            insertExamData(inSheetCode, inOrderCode, inSheetGroup, inNewFlag)
        Else
            genDataSet(inSheetCode)
            insertExamData(inSheetCode, inOrderCode, inSheetGroup, inNewFlag)
        End If

        If ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Sheet_Group_Name").ToString.Trim <> "" Then
            pvtShowText = inSheetName & "[" & ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Sheet_Group_Name").ToString.Trim & "]. ["
        Else
            pvtShowText = inSheetName & " ["
        End If


        For j As Integer = 0 To gblShowColumns - 1
            For i = 0 To gblDataRows - 1
                If dgv_FavorData.Rows(i).Cells(j * 2).Value Then

                    pvtOrderName = dgv_FavorData.Rows(i).Cells.Item(j * 2 + 1).Value

                    pvtTabIndex = pvtOrderName.IndexOf(vbTab)
                    If pvtTabIndex > 0 Then
                        pvtOrderName = pvtOrderName.Substring(0, pvtTabIndex).Trim
                    End If

                    If pvtAddFlag Then
                        pvtShowText &= "," & pvtOrderName
                    Else
                        pvtShowText &= pvtOrderName
                        pvtAddFlag = True
                    End If

                End If

                If i = gblShowRows - 1 Then Exit For
            Next
        Next

        pvtShowText &= "]"

        '若不存在則新增
        If pvtListIndex = -1 Then
            gblEmgExamList.Add(inSheetCode)
            lst_OrgExam.Tag = gblEmgExamList
            lst_OrgExam.Items.Add(pvtShowText)
        Else
            If lst_OrgExam.Items.Count > 0 Then
                lst_OrgExam.Items.RemoveAt(pvtListIndex)
                lst_OrgExam.Items.Insert(pvtListIndex, pvtShowText)
            Else
                lst_OrgExam.Items.Insert(pvtListIndex, pvtShowText)
            End If
        End If

    End Sub

    Private Sub tre_Category_BeforeSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs)
        If gblClearSelect Then
            ClearBackColor()
            gblClearSelect = False
        End If

    End Sub

    Private Sub insertExamData(ByVal inTable As String, ByVal inOrderCode As String, _
                               ByVal inSheetGroup As String, ByVal inNewFlag As Boolean)

        If inNewFlag Then
            Dim row1 As DataRow
            row1 = gblOrgExamDs.Tables(inTable).NewRow
            row1("Show_Name") = dgv_FavorData.Rows(gblRowIndex).Cells.Item(gblColumnIndex * 2 + 1).Value.ToString.Trim
            row1("Order_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Code").ToString.Trim

            '若為檢驗，則回傳簡稱；若為檢查，則回傳英文名稱 
            If gblSheetData(1) = "1" Then
                row1("Order_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_En_Short_Name").ToString.Trim
            Else
                row1("Order_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_En_Name").ToString.Trim
            End If
            row1("Order_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Name").ToString.Trim
            row1("Dosage") = ""
            row1("Dosage_Unit") = ""
            row1("Frequency_Code") = ""
            row1("Usage_Code") = ""
            row1("Days") = ""
            row1("Qty") = ""
            row1("Unit") = ""
            row1("Default_Body_Site_Code") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Default_Body_Site_Code").ToString.Trim
            row1("Default_Side_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Default_Side_Id").ToString.Trim
            row1("Specimen_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Specimen_Id").ToString.Trim
            row1("Order_Type_Id") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Order_Type_Id").ToString.Trim
            row1("Sheet_Group") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Sheet_Group").ToString.Trim
            row1("Sheet_Group_Name") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Sheet_Group_Name").ToString.Trim
            row1("Is_Valid_Order") = ds.Tables(0).Rows(gblColumnIndex + gblRowIndex * 2).Item("Is_Valid_Order").ToString.Trim
            gblOrgExamDs.Tables(inTable).Rows.Add(row1)
        Else
            For i = 0 To gblOrgExamDs.Tables(inTable).Rows.Count - 1
                If gblOrgExamDs.Tables(inTable).Rows(i).Item("Order_Code").ToString.Trim = inOrderCode AndAlso _
                   gblOrgExamDs.Tables(inTable).Rows(i).Item("Sheet_Group").ToString.Trim = inSheetGroup Then
                    gblOrgExamDs.Tables(inTable).Rows.RemoveAt(i)
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub lst_OrgExam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_OrgExam.Click
        If lst_OrgExam.SelectedIndex <> -1 AndAlso lst_OrgExam.SelectedIndex < gblEmgExamList.Count Then
            setExamOrder(gblEmgExamList.Item(lst_OrgExam.SelectedIndex))
        End If
    End Sub

    Private Sub genDataSet(ByVal inTable As String)
        Dim columnNameDB() As String
        columnNameDB = New String() {"Order_Code", "Order_En_Name", "Order_Name", "Dosage", "Dosage_Unit", "Frequency_Code", _
                                     "Usage_Code", "Days", "Qty", "Unit", "Default_Body_Site_Code", "Default_Side_Id", _
                                     "Specimen_Id", "Pharmacy_12_Code", "OPD_Lack_Id", "Nhi_Price", "Own_Price", "Drug_Type", "Order_Type_Id", "Form_Kind_Id", "Show_Name", _
                                     "Doctor_Dept_Code", "Age_Group_Id", "Op_Nameplate_Id", "Is_IVF", "Sheet_Group", "Sheet_Group_Name"}

        gblOrgExamDs.Tables.Add(inTable)

        '新增Table的欄位
        For i As Integer = 0 To columnNameDB.Length - 1
            gblOrgExamDs.Tables(inTable).Columns.Add(columnNameDB(i))
        Next
    End Sub

#Region "Remove BackColor"

    'recursively move through the treeview nodes
    'and reset backcolors to white
    Private Sub ClearBackColor()

        Dim nodes As TreeNodeCollection
        nodes = tre_Category.Nodes
        Dim n As TreeNode

        For Each n In nodes
            ClearRecursive(n)
        Next

    End Sub

    'called by ClearBackColor function
    Private Sub ClearRecursive(ByVal treeNode As TreeNode)

        Dim tn As TreeNode

        For Each tn In treeNode.Nodes
            tn.BackColor = Color.White
            ClearRecursive(tn)
        Next

    End Sub

#End Region


    Private Sub UCLOrderFavorDialogUI_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                '查詢
                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "E" Then
                    If rbt_FavorId3.Checked Then
                        rbt_FavorId3.Checked = False
                        rbt_FavorId3.Checked = True
                        If gblSourceType = "I" Then btn_Query_Click(sender, e)
                    Else
                        If gblSourceType = "E" Then rbt_FavorId3.Checked = True
                        If gblSourceType = "I" Then btn_Query_Click(sender, e)
                    End If

                Else
                    btn_Query_Click(sender, e)
                End If

            Case Keys.Enter

                If txt_Index1.Focused Then
                    txt_Index2.Focus()
                ElseIf txt_Index2.Focused Then
                    txt_Index3.Focus()
                ElseIf txt_Index3.Focused Then
                    txt_Index4.Focus()
                ElseIf txt_Index4.Focused Then
                    txt_Index5.Focus()
                ElseIf txt_Index5.Focused Then
                    txt_Index1.Focus()
                End If

        End Select
    End Sub

    '2012-05-29 Add By Alan-若取消選取診斷，則自選取清單中移除
    Private Sub removeSelItem(ByVal inOrderCode As String)
        Dim pvtCount As Integer
        pvtCount = dgv_Selected.GetDBDS.Tables(0).Rows.Count
        For i = 0 To pvtCount - 1
            If dgv_Selected.GetDBDS.Tables(0).Rows(i).Item("Icd_Code").ToString.Trim = inOrderCode Then
                dgv_Selected.GetDBDS.Tables(0).Rows.RemoveAt(i)
                dgv_Selected.GetGridDS.Tables(0).Rows.RemoveAt(i)
                dgv_Selected.Refresh()
                Exit For
            End If
        Next
    End Sub


    Private Sub cbo_Station_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Station.SelectedIndexChanged
        Try
            If gblInitFlag = False Then

                If gblFavorTypeId = "D" AndAlso rbt_FavorId4.Checked Then
                    tre_Category.Nodes.Clear()
                    dsCateDept = uclService.querySTAPackageDataCategory("D1", cbo_Station.SelectedValue)
                    setCategory(dsCateDept.Tables(0).Copy)
                End If

                btn_Query_Click(sender, e)
            End If
        Catch ex As Exception
            ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    Public Function getPropertyId(ByVal inStr As String) As String

        Dim pvtOrgStr, pvtNewStr, pvtReturnStr As String
        Dim pvtCutIndex As Integer
        pvtReturnStr = ""

        pvtOrgStr = inStr

        If pvtOrgStr.Trim.Length = 1 AndAlso pvtOrgStr = "|" Then
            pvtOrgStr = ""
        End If

        Do
            pvtCutIndex = pvtOrgStr.ToString.IndexOf("|")

            If pvtCutIndex >= 0 Then
                If pvtCutIndex = 0 Then
                    pvtNewStr = pvtOrgStr.ToString.Substring(1).Substring(0, 2)
                    pvtOrgStr = pvtOrgStr.ToString.Substring(pvtCutIndex + 1)
                Else
                    pvtNewStr = pvtOrgStr.ToString.Substring(0, pvtCutIndex).Substring(0, 2)
                    pvtOrgStr = pvtOrgStr.ToString.Substring(pvtCutIndex + 1)
                End If


            Else
                pvtNewStr = pvtOrgStr
            End If


            Select Case pvtNewStr
                Case "01"
                    If pvtReturnStr = "" Then
                        pvtReturnStr = "【管】"
                    Else
                        pvtReturnStr &= "【管】"
                    End If
                Case "11"
                    If pvtReturnStr = "" Then
                        pvtReturnStr = "【抗】"
                    Else
                        If Not pvtReturnStr.Contains("抗") Then
                            pvtReturnStr &= "【抗】"
                        End If

                    End If
                Case "06"
                    If pvtReturnStr = "" Then
                        pvtReturnStr = "【審】"
                    Else
                        pvtReturnStr &= "【審】"
                    End If
            End Select
        Loop Until (pvtCutIndex < 0)

        Return pvtReturnStr

    End Function

    Private Sub btn_SelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SelAll.Click
        For i = 0 To dgv_FavorData.Columns.Count - 1
            For j = 0 To dgv_FavorData.Rows.Count - 1
                If gblShowRows * i + j >= gblDataRows Then
                    Exit For
                End If

                setGridData(i, j)
            Next
        Next
    End Sub

    Private Sub setGridData(ByVal inColumnIndex As Integer, ByVal inRowIndex As Integer)

        gblRowIndex = inRowIndex
        gblColumnIndex = inColumnIndex

        If dgv_FavorData.Rows(inRowIndex).Cells(inColumnIndex * 2).Value Then
            dgv_FavorData.Rows(inRowIndex).Cells(inColumnIndex * 2).Value = False
        Else
            dgv_FavorData.Rows(inRowIndex).Cells(inColumnIndex * 2).Value = True
        End If


        '若點選CheckBox，則將資料設定至已選取醫令Grid中
        If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso _
           ds.Tables(0).Rows(gblShowRows * inColumnIndex + inRowIndex).Item("Order_Code").ToString.Trim <> "" Then

            If dgv_FavorData.Rows(inRowIndex).Cells(inColumnIndex * 2).Value Then

                If gblEmgExam Then
                    setExamList(tre_Category.SelectedNode.Tag(0), tre_Category.SelectedNode.Tag(3), _
                            ds.Tables(0).Rows(gblShowRows * inColumnIndex + inRowIndex).Item("Order_Code").ToString.Trim, _
                            ds.Tables(0).Rows(gblShowRows * inColumnIndex + inRowIndex).Item("Sheet_Group").ToString.Trim, _
                            False)
                End If

            Else
                '2012-05-29 Add By Alan-若為急診診斷，則需依點選的診斷順序回傳，而非在Grid清單中的排列順序
                '在此為自選取清單中新增選取的診斷
                If gblSourceType = "E" And gblFavorTypeId = "A" Then
                    returnRowDataForKmuh(False)
                End If
                If gblEmgExam Then
                    setExamList(tre_Category.SelectedNode.Tag(0), tre_Category.SelectedNode.Tag(3), _
                            ds.Tables(0).Rows(gblShowRows * inColumnIndex + inRowIndex).Item("Order_Code").ToString.Trim, _
                            ds.Tables(0).Rows(gblShowRows * inColumnIndex + inRowIndex).Item("Sheet_Group").ToString.Trim, _
                            True)
                End If

                '若為急診 & 檢驗檢查，則再Chcek是否可選取其他部位
                If (gblSourceType = "E" OrElse gblSourceType = "I") AndAlso gblFavorTypeId = "H" AndAlso gblFavorTypeId = "H1" AndAlso gblFavorTypeId = "H2" AndAlso _
                   ds.Tables(0).Rows(gblShowRows * inColumnIndex + inRowIndex).Item("Option_Order").ToString.Trim <> "" Then
                    Dim pvtDs As New DataSet
                    pvtDs = uclService.queryPUBExamItemByOrder(gblOrderCode)
                    If pvtDs IsNot Nothing AndAlso pvtDs.Tables IsNot Nothing AndAlso pvtDs.Tables(0).Rows.Count > 0 Then
                        Dim pvtOpenWin As UCLOptionOrderUI = New UCLOptionOrderUI(pvtDs, "    " & ds.Tables(0).Rows(gblShowRows * inColumnIndex + inRowIndex).Item("Favor_Name").ToString.Trim)
                        pvtOpenWin.ShowDialog()
                        dgv_FavorData.Rows(inRowIndex).Cells.Item(inColumnIndex * 2 + 1).Value = pvtOpenWin.gblOptionName

                        Select Case pvtOpenWin.gblOptionIndex
                            Case 1
                                ds.Tables(0).Rows(gblShowRows * inColumnIndex + inRowIndex).Item("Order_Code") = pvtDs.Tables(0).Rows(0).Item("Other_Side_Code1").ToString.Trim

                            Case 2
                                ds.Tables(0).Rows(gblShowRows * inColumnIndex + inRowIndex).Item("Order_Code") = pvtDs.Tables(0).Rows(0).Item("Other_Side_Code2").ToString.Trim

                        End Select


                    End If
                End If

            End If

        End If

    End Sub

    Private Sub chk_Diabetes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Diabetes.CheckedChanged
        If gblSourceType = "I" Then
            If chk_Diabetes.Checked Then
                gblDrugType = "5"
                gblInpDrpFlag = True
                btn_Query_Click(sender, e)
            Else
                gblDrugType = "1"
                gblInpDrpFlag = False
                If rbt_FavorId3.Checked = False Then
                    btn_Query_Click(sender, e)
                Else
                    dgv_FavorData.ClearDS()
                End If
            End If
        End If
    End Sub

    Private Sub chk_SelAll_CheckedChanged(sender As Object, e As EventArgs) Handles chk_SelAll.CheckedChanged

        For i = 0 To dgv_FavorData.Columns.Count - 1
            For j = 0 To dgv_FavorData.Rows.Count - 1
                If gblShowRows * i + j >= gblDataRows Then
                    Exit For
                End If

                setGridData(i, j)
            Next
        Next

    End Sub

End Class