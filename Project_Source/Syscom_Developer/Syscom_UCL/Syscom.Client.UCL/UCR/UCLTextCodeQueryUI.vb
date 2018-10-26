'/*
'*****************************************************************************
'*
'*    Page/Class Name:	UCLTextCodeQueryUI.vb
'*              Title:	UCLTextCodeQueryUI元件
'*        Description:	表格查詢
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	James
'*        Create Date:	
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
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Windows.Forms.Design

Public Class UCLTextCodeQueryUI



#Region "全域變數宣告"


    Dim pvtDS As DataSet
    'Dim exe_Status = False
    ' Private mgr As EventManager = EventManager.getInstance   '宣告EventManager
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance
    Public Shadows Event TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Shadows Event Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Shadows Event ProcessQueryDone(ByVal sender As System.Object)

    Private _uclXPosition As Integer = 225
    Private _uclYPosition As Integer = 120
    Private _uclCboWidth As Integer = 200
    Private _BackColor As Color
    Private _uclDropDownStyle As ComboBoxStyle = ComboBoxStyle.Simple
    Public Shadows Event KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    Private _uclBtnText As String = "..."
    Private _uclDisplayIndex As String = "0,1"
    Private _uclTextBoxShow As ShowText = ShowText.Code
    Private _uclDeptType As DeptType = DeptType.None
    Dim _uclDeptCode As String = ""

    Dim _uclRefHosp As uclRefHospData = uclRefHospData.All
    Dim OtherQueryConditionDS As DataSet
    Dim _uclControlFlag As Boolean = True
    Dim _uclIsBtnVisible As Boolean = True
    Dim _uclIsEnglishDept As Boolean = False
    Dim _uclIsShowMsgBox As Boolean = True
    Dim _uclIsTextAutoClear As Boolean = True
    Dim _uclIsAutoAddZero As Boolean = False
    Dim _uclTotalWidth As Integer = 8
    Dim _uclLabel As String = ""
    Dim _uclNoDataOpenWindow As Boolean = False
    Private _uclIsCheckDoctorOnDuty As Boolean = False   '是否檢核醫生是否在職中 (預設不檢核)


#End Region


#Region "屬性設定"

    ''' <summary>
    ''' 顯示方式
    ''' </summary>
    ''' <remarks></remarks>
    Enum ShowText
        Code = 1
        Name = 2
        CodeAndName = 3
        Code2 = 4
        Code2AndName = 5
    End Enum

    ''' <summary>
    ''' 科別 None全部 , Dept 行政科 , OEIDept 門急住科別 , ODept 門診科 , EDept 急診科,IDept 住院科
    ''' </summary>
    ''' <remarks></remarks>
    Enum DeptType
        None
        Dept
        OEIDept
        ODept
        EDept
        IDept
    End Enum

    ''' <summary>
    ''' 轉介醫院
    ''' </summary>
    ''' <remarks></remarks>
    Enum uclRefHospData
        All = 0
        SouthArea = 1
        NotSouthArea = 2
        IsDialysisCenter = 3
        IsAlliance = 4
        '20140226 by ccr 增加含dc data
        AllIncludeDC = 5
    End Enum

    ''' <summary>
    ''' 元件寬度
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Property uclTotalWidth() As Integer
        Get
            Return _uclTotalWidth
        End Get
        Set(ByVal value As Integer)
            _uclTotalWidth = value
        End Set
    End Property

    ''' <summary>
    ''' 是否為英文科
    ''' </summary>
    ''' <value></value>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsEnglishDept() As Boolean
        Get
            Return _uclIsEnglishDept
        End Get
        Set(ByVal value As Boolean)
            _uclIsEnglishDept = value
        End Set
    End Property

    ''' <summary>
    ''' 病歷號自動補0
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsAutoAddZero() As Boolean
        Get
            Return _uclIsAutoAddZero
        End Get
        Set(ByVal value As Boolean)
            _uclIsAutoAddZero = value
        End Set
    End Property

    ''' <summary>
    ''' 是否顯示按鈕
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsBtnVisible() As Boolean
        Get
            Return _uclIsBtnVisible
        End Get
        Set(ByVal value As Boolean)
            _uclIsBtnVisible = value
            Btn_CodeQuery.Visible = value
        End Set
    End Property


    Public Property uclIsCheckDoctorOnDuty() As Boolean
        Get
            Return _uclIsCheckDoctorOnDuty
        End Get
        Set(ByVal value As Boolean)
            _uclIsCheckDoctorOnDuty = value
        End Set
    End Property

    Public Property uclLabel() As String
        Get
            Return _uclLabel
        End Get
        Set(ByVal value As String)
            _uclLabel = value
        End Set
    End Property

    Public Property uclRefHosp() As uclRefHospData
        Get
            Return _uclRefHosp
        End Get
        Set(ByVal value As uclRefHospData)
            _uclRefHosp = value
        End Set
    End Property
     
    Public Property uclDeptCode() As String
        Get
            Return _uclDeptCode
        End Get
        Set(ByVal value As String)
            _uclDeptCode = value
        End Set
    End Property

    ''' <summary>
    ''' 如果查無資料是否開啟查詢視窗
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclNoDataOpenWindow() As Boolean
        Get
            Return _uclNoDataOpenWindow
        End Get
        Set(ByVal value As Boolean)
            _uclNoDataOpenWindow = value
        End Set
    End Property

    ''' <summary>
    ''' 查詢的資料表
    ''' </summary>
    ''' <remarks></remarks>
    Enum uclQueryTable
        PUB_Doctor = 1                  '1:醫師檔
        PUB_Zone_Room = 2               '2:診間號
        PUB_Patient = 3                 '3:病患基本檔
        PUB_Disease = 4                 '4:重大傷病ICD
        PUB_Order_Examination = 5       '5:排程醫令
        PUB_Department = 6              '6:科室檔
        PUB_Sheet = 7                   '7:表單類別
        REF_Referral_Hospital = 8       '8:轉診醫院
        PUB_Order = 9                   '9:醫令項目基本檔
        SCH_Apparatus = 10              '10:檢查儀器維護檔
        REG_Day_Schedule = 11           '11:日班表查詢
        PUB_Employee = 12               '12:員工檔
        PUB_DoctorByDep = 13            '13:醫師檔 附加綁科別
        PUB_OrderByOrderTypeId = 14     '14:綁OrderTypeId查詢
        OPH_Pharmacist = 15             '15:藥師基本主檔
        REG_Profess_Base = 16           '16:次專科基本檔
        OPH_Pharmacy_Class = 17         '17:藥理分類
        OPH_Code_TypeId19 = 18          '18:藥品代碼分類明細檔 TypeId=19
        '19,20多選
        PUB_OrderByTreatmentTypeId2 = 21 '21:醫令牙科約診
        PUB_SyscodeByTypeId98 = 27

        REF_Referral_Patient = 28      '28:轉介病人檔
        REF_Referral_Out_Patient = 29   '29:轉出病人檔
        OPH_Pharmacy_Base = 30             '30:藥品基本主檔
        'PUB_Department_MultiSelect = 31   '31:多選科室(UCLBtnCodeQueryUI已定義,在此尚未實作)
        'INP_Station_MultiSelect = 32      '32:多選戶理站(UCLBtnCodeQueryUI已定義,在此尚未實作)
        PUB_OrderForMantain = 33           '33:醫令查詢For醫令基本檔維護
        PUB_OrderForDrugMantain = 34           '34:醫令查詢For醫令基本檔維護-藥品
        REG_Week_Schedule = 36           '35:日班表查詢
        PUB_DoctorVS = 37                  '37:醫師檔 for 主治醫師
        PUB_Contract = 38                  '38:合約機構基本檔
        PUB_DoctorByDate = 40              '40:醫師檔 附加綁日期(還在職的日期)
        PUB_DepartmentFroEmg = 41              '41:急診科室檔
        PUBEmployeeProfessalKindId = 42      '42:員工檔-職稱

        PUB_DepartmentAndSection = 43              '43 取得科診
        PUB_Disease_ICD10 = 50                 '50:ICD10
        PUB_Insu_Dept = 51                 '51:健保科別

        'PUB_Area = 52  '地區
        'PUB_Vil = 53    '里
        PUB_NHI_Code = 54

        DRG_Drg_Base = 60       '60:TW_DRGs基本檔
        DRG_Mdc_Base = 61       '61:MDC主要疾病類別檔
        PUB_Sation = 62         '科別檔
        STA_Consumpation = 63         '消耗單位基本檔
        LAB_BacOrgan = 70
        PUB_DoctorForAll = 98              '98 All醫生 不限時間
        PUB_DoctorForOHD = 99              '99 OHD申報醫生

        OPH_Code_TypeId303 = 303            '303:院內藥品屬性 TypeId=303

        LAB_Item = 500                      '500:LAB_Item
        PUB_EmployeeRoles = 501     '501:員工檔-角色

        OPH_Code19 = 502     '502:OPH_Code19

    End Enum

    Private _uclTableName = uclQueryTable.PUB_Doctor      '定義要查詢的表格
    Private _uclQueryField As String                      '定義要查詢欄位名稱
    Private _uclQueryValue As String                      '定義要查詢欄位值
    Private _uclMsgValue As String                        '定義要顯示錯誤訊息的欄位名稱

    '設定或取回元件欄位值
    Private _uclCodeValue As String = ""            '代碼值 
    Private _uclCodeValue1 As String = ""            '代碼值1
    Private _uclCodeValue2 As String = ""            '代碼值2 

    Private _uclCodeName As String = ""              '代碼所對應名稱

    Private _uclCodeName1 As String = ""              '代碼所對應名稱
    Private _uclCodeName2 As String = ""              '代碼所對應名稱

    Private _Text As String
    Private _doFlag As Boolean = True

    Private _uclIsReturnDS As Boolean = False
    Private _uclPUBEmployeeProfessalKindId As String = ""
    Private _uclIsCheckTime As Boolean = True
    Private _uclBaseDate As String = "" ' Now.ToString("yyyy/MM/dd")
    Private _uclIsCheckDrLicense As Boolean = True
    Private _uclRegionKind As String = ""
    Private _uclRoles As String = ""

    ''' <summary>
    ''' 是否檢核醫師證照檔 
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsCheckDrLicense() As Boolean
        Get
            Return _uclIsCheckDrLicense
        End Get
        Set(ByVal value As Boolean)
            _uclIsCheckDrLicense = value
        End Set
    End Property

    ''' <summary>
    ''' 是否檢核時間Assume_End_Date , Assume_Effect_Date 
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsCheckTime() As Boolean
        Get
            Return _uclIsCheckTime
        End Get
        Set(ByVal value As Boolean)
            _uclIsCheckTime = value
        End Set
    End Property

    ''' <summary>
    ''' 是否顯示找不到資料的MsgBox
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsShowMsgBox() As Boolean
        Get
            Return _uclIsShowMsgBox
        End Get
        Set(ByVal value As Boolean)
            _uclIsShowMsgBox = value
        End Set
    End Property

    ''' <summary>
    ''' 找不到資料時是否自動清除TextBox資料
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclIsTextAutoClear() As Boolean
        Get
            Return _uclIsTextAutoClear
        End Get
        Set(ByVal value As Boolean)
            _uclIsTextAutoClear = value
        End Set
    End Property


    Public Property uclControlFlag() As Boolean
        Get
            Return _uclControlFlag
        End Get
        Set(ByVal value As Boolean)
            _uclControlFlag = value
        End Set
    End Property


    Public Property uclTextBoxShow() As ShowText
        Get
            Return _uclTextBoxShow
        End Get
        Set(ByVal value As ShowText)
            _uclTextBoxShow = value
        End Set
    End Property

    Public Property uclDeptType() As DeptType
        Get
            Return _uclDeptType
        End Get
        Set(ByVal value As DeptType)
            _uclDeptType = value
        End Set
    End Property

    '設定要顯示的欄位Index(預設為0,1=>代碼與名稱)
    Public Property uclDisplayIndex() As String
        Get
            Return _uclDisplayIndex
        End Get
        Set(ByVal value As String)
            'doFlag = False
            '_uclDisplayIndex = value
            'SetComboField(_DataSource, "ShowField", _uclDisplayIndex)
            'ComboBox1.DisplayMember = "ShowField"
        End Set
    End Property

    Public Property uclDropDownStyle() As ComboBoxStyle
        Get
            Return cbo_CodeValue.DropDownStyle
        End Get
        Set(ByVal value As ComboBoxStyle)
            cbo_CodeValue.DropDownStyle = value
        End Set
    End Property

    Public Property uclTableName() As uclQueryTable
        Get
            Return _uclTableName
        End Get
        Set(ByVal value As uclQueryTable)
            _uclTableName = value
        End Set
    End Property

    Public Property uclQueryField() As String
        Get
            Return _uclQueryField
        End Get

        Set(ByVal value As String)
            _uclQueryField = value
        End Set
    End Property

    Public Property uclQueryValue() As String
        Get
            Return _uclQueryValue
        End Get

        Set(ByVal value As String)
            _uclQueryValue = value
        End Set
    End Property

    Public Property uclMsgValue() As String
        Get
            Return _uclMsgValue
        End Get

        Set(ByVal value As String)
            _uclMsgValue = value
        End Set
    End Property


    Public Property uclCodeValue() As String
        Get
            Return _uclCodeValue
        End Get
        Set(ByVal value As String)
            _uclCodeValue = value
        End Set
    End Property


    Public Property uclCodeValue1() As String
        Get
            Return _uclCodeValue1
        End Get
        Set(ByVal value As String)
            _uclCodeValue1 = value
        End Set
    End Property

    Public Property uclCodeValue2() As String
        Get
            Return _uclCodeValue2
        End Get
        Set(ByVal value As String)
            _uclCodeValue2 = value
        End Set
    End Property


    Public Property uclCodeName() As String
        Get
            Return _uclCodeName
        End Get
        Set(ByVal value As String)
            _uclCodeName = value
        End Set
    End Property

    Public Property uclCodeName1() As String
        Get
            Return _uclCodeName1
        End Get
        Set(ByVal value As String)
            _uclCodeName1 = value
        End Set
    End Property

    Public Property uclCodeName2() As String
        Get
            Return _uclCodeName2
        End Get
        Set(ByVal value As String)
            _uclCodeName2 = value
        End Set
    End Property


    Public Property uclBaseDate() As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
            '_uclBaseDate = value
        End Set
    End Property

    Public Property uclConditionDate() As String
        Get
            Return _uclBaseDate
        End Get
        Set(ByVal value As String)
            _uclBaseDate = value
        End Set
    End Property


    ''' <summary>
    ''' 根據角色查PUB_Employee  , uclRoles='ARM_Admin','PUB_Admin'
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclRoles() As String
        Get
            Return _uclRoles
        End Get
        Set(ByVal value As String)
            _uclRoles = value
        End Set
    End Property


    Public Property uclPUBEmployeeProfessalKindId() As String
        Get
            Return _uclPUBEmployeeProfessalKindId
        End Get
        Set(ByVal value As String)
            _uclPUBEmployeeProfessalKindId = value
        End Set
    End Property

    Public Property uclIsReturnDS() As Boolean
        Get
            Return _uclIsReturnDS
        End Get
        Set(ByVal value As Boolean)
            _uclIsReturnDS = value
        End Set
    End Property

    Public Overrides Property BackColor() As Color
        Get
            Return cbo_CodeValue.BackColor
        End Get
        Set(ByVal value As Color)
            cbo_CodeValue.BackColor = value
            TableLayoutPanel1.BackColor = value
        End Set
    End Property

    Public Overrides Property Text() As String
        Get
            _Text = cbo_CodeValue.Text.Trim
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
            cbo_CodeValue.Text = value

        End Set
    End Property

    Public Property uclCboWidth() As Integer
        Get
            Return cbo_CodeValue.Width
        End Get
        Set(ByVal value As Integer)
            _uclCboWidth = value
            cbo_CodeValue.Width = value
        End Set
    End Property

    Public Property doFlag() As Boolean
        Get
            Return _doFlag
        End Get
        Set(ByVal value As Boolean)
            _doFlag = value
        End Set
    End Property
    Public Property uclXPosition() As Integer
        Get
            Return _uclXPosition
        End Get
        Set(ByVal value As Integer)
            _uclXPosition = value
        End Set
    End Property
    Public Property uclYPosition() As Integer
        Get
            Return _uclYPosition
        End Get
        Set(ByVal value As Integer)
            _uclYPosition = value
        End Set
    End Property

    ''' <summary>
    ''' 消耗單位條件設定
    ''' 區域種類 R=住院專用,E=急診專用,O=開刀房專用
    ''' 可傳入多種組合例如 "R,E,O"
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclRegionKind() As String
        Get
            Return _uclRegionKind
        End Get
        Set(ByVal value As String)
            _uclRegionKind = value
        End Set
    End Property
#End Region


    Public Function getCodeName() As String
        Return StringUtil.nvl(_uclCodeName)
    End Function
    Public Function getCode() As String
        Return StringUtil.nvl(_uclCodeValue1)
    End Function
    Public Function getCode2() As String
        Return StringUtil.nvl(_uclCodeValue2)
    End Function

    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    ''' <summary>
    ''' 設定文字
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Sub SetText(ByVal text As String)

        doFlag = False
        cbo_CodeValue.Text = text
        doFlag = False

    End Sub

    ''' <summary>
    ''' 清除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()

        uclCodeName = ""
        uclCodeName1 = ""
        uclCodeName2 = ""

        uclCodeValue = ""
        uclCodeValue1 = ""
        uclCodeValue2 = ""
        cbo_CodeValue.Text = ""
    End Sub


#Region "Event"

    ''' <summary>
    ''' 進行查詢
    ''' </summary>
    ''' <param name="code">查詢代碼</param>
    ''' <param name="baseDate">基準日</param>
    ''' <param name="IsCheckDc">是否檢核DC欄位</param>
    ''' <remarks></remarks>
    Public Sub ProcessQuery(ByVal code As String, Optional ByVal baseDate As String = "", Optional ByVal IsCheckDc As Boolean = True)
        Try

            If _uclTableName = 3 Then

                If code.Trim = "" Then
                    Exit Sub
                End If
                If uclIsAutoAddZero Then
                    cbo_CodeValue.Text = code.Trim.PadLeft(uclTotalWidth, "0")
                Else
                    cbo_CodeValue.Text = code
                End If

            Else
                cbo_CodeValue.Text = code
            End If

            cbo_CodeValue.Text = cbo_CodeValue.Text.Replace("'", "''")

            If doFlag And cbo_CodeValue.Text.Trim <> "" Then


                Dim ucl As IUclServiceManager = UclServiceManager.getInstance

                OtherQueryConditionDS = New DataSet
                Dim dBDate As Date
                Dim blnIsDate As Boolean = False
                If Date.TryParse(baseDate, dBDate) Then
                    blnIsDate = True
                    baseDate = dBDate.ToShortDateString
                    OtherQueryConditionDS = New DataSet
                    OtherQueryConditionDS.Tables.Add("UseBaseDate")
                    OtherQueryConditionDS.Tables("UseBaseDate").Columns.Add("baseDate")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("UseBaseDate").NewRow
                    drNew.Item("baseDate") = baseDate
                    OtherQueryConditionDS.Tables("UseBaseDate").Rows.Add(drNew)
                End If

                If Not IsCheckDc Then
                    OtherQueryConditionDS.Tables.Add("CheckDc")
                    OtherQueryConditionDS.Tables("CheckDc").Columns.Add("IsCheckDc")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("CheckDc").NewRow
                    drNew.Item("IsCheckDc") = "N"
                    OtherQueryConditionDS.Tables("CheckDc").Rows.Add(drNew)
                End If

                If uclDeptType <> DeptType.None Then
                    OtherQueryConditionDS.Tables.Add("DeptType")
                    OtherQueryConditionDS.Tables("DeptType").Columns.Add("Type")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("DeptType").NewRow
                    drNew.Item("Type") = uclDeptType.ToString
                    OtherQueryConditionDS.Tables("DeptType").Rows.Add(drNew)
                End If

                If uclPUBEmployeeProfessalKindId <> "" Then
                    OtherQueryConditionDS.Tables.Add("PUBEmployeeProfessalKindId")
                    OtherQueryConditionDS.Tables("PUBEmployeeProfessalKindId").Columns.Add("Professal_Kind_Id")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("PUBEmployeeProfessalKindId").NewRow
                    drNew.Item("Professal_Kind_Id") = uclPUBEmployeeProfessalKindId.ToString
                    OtherQueryConditionDS.Tables("PUBEmployeeProfessalKindId").Rows.Add(drNew)
                End If

                If uclRoles <> "" Then
                    OtherQueryConditionDS.Tables.Add("uclRoles")
                    OtherQueryConditionDS.Tables("uclRoles").Columns.Add("uclRoles")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("uclRoles").NewRow
                    drNew.Item("uclRoles") = uclRoles.ToString
                    OtherQueryConditionDS.Tables("uclRoles").Rows.Add(drNew)
                End If
                 
                If uclIsCheckTime = False Then
                    OtherQueryConditionDS.Tables.Add("IsCheckTime")
                    OtherQueryConditionDS.Tables("IsCheckTime").Columns.Add("IsCheckTime")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("IsCheckTime").NewRow
                    drNew.Item("IsCheckTime") = "N"
                    OtherQueryConditionDS.Tables("IsCheckTime").Rows.Add(drNew)
                End If

                If uclIsCheckDrLicense = False Then
                    OtherQueryConditionDS.Tables.Add("IsCheckDrLicense")
                    OtherQueryConditionDS.Tables("IsCheckDrLicense").Columns.Add("IsCheckDrLicense")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("IsCheckDrLicense").NewRow
                    drNew.Item("IsCheckDrLicense") = "N"
                    OtherQueryConditionDS.Tables("IsCheckDrLicense").Rows.Add(drNew)
                End If
                 
                If uclRegionKind <> "" Then
                    OtherQueryConditionDS.Tables.Add("RegionKind")
                    OtherQueryConditionDS.Tables("RegionKind").Columns.Add("Region_Kind")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("RegionKind").NewRow
                    Dim regionKindArr As String() = uclRegionKind.Split(",")
                    For Each s As String In regionKindArr
                        drNew.Item("Region_Kind") = drNew.Item("Region_Kind") & "'" & s & "',"
                    Next
                    drNew.Item("Region_Kind") = drNew.Item("Region_Kind").ToString.Trim.Substring(0, drNew.Item("Region_Kind").ToString.Trim.Length - 1)
                    OtherQueryConditionDS.Tables("RegionKind").Rows.Add(drNew)
                End If

                Dim labQueryItem As String = ""
                Select Case _uclTableName
                    Case 1
                        labQueryItem = "醫師員工號(" & cbo_CodeValue.Text.Trim & "),"
                        If cbo_CodeValue.Text.Trim.Length = 4 Then
                            '使用Doctor_Code
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Doctor_Code", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)

                        ElseIf cbo_CodeValue.Text.Trim.Length = 6 Then
                            '使用Employee_Code
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "B.Employee_Code", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)
                        Else
                            '使用Employee_Code
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "B.Employee_Code", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)

                        End If

                    Case 2
                        'If _uclQueryValue = "" Then
                        '    'MessageBox.Show("請輸入看診區")
                        '    'MessageHandling.showWarn("請輸入看診區")
                        '    '********************2010/2/9 Modify By Alan**********************
                        '    MessageHandling.showWarnMsg("CMMCMMB300",New String(){"請輸入看診區"} )
                        'Else
                        '    pvtDS = ucl.queryOpenWindow(_uclTableName, "Zone_Id︿Room_Code", _uclQueryValue & "︿" & cbo_CodeValue.Text.Trim, "=", Nothing)
                        'End If
                        labQueryItem = "看診區(" & cbo_CodeValue.Text.Trim & "),"
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Zone_Id︿Room_Code", _uclQueryValue & " ︿" & cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 3

                        labQueryItem = "病歷號or身分證號(" & cbo_CodeValue.Text.Trim & "),"
                        If uclControlFlag Then


                            pvtDS = ucl.queryOpenWindow(_uclTableName, "Chart_No", cbo_CodeValue.Text.Trim, "=", Nothing)
                        Else

                            If cbo_CodeValue.Text.Trim <> "" Then '身分證號不回空才去查
                                pvtDS = ucl.queryOpenWindow(_uclTableName, "Idno", cbo_CodeValue.Text.Trim, "=", Nothing)
                            End If

                        End If
                    Case 4
                        labQueryItem = "診斷代碼(" & cbo_CodeValue.Text.Trim & "),"
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Icd_Code", cbo_CodeValue.Text.Trim, "=", Nothing)


                    Case 5
                        labQueryItem = "醫囑代碼(" & cbo_CodeValue.Text.Trim & "),"
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Order_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 6

                        labQueryItem = "科別(" & cbo_CodeValue.Text.Trim & "),"
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Dept_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 7
                        labQueryItem = "診間(" & cbo_CodeValue.Text.Trim & "),"
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Sheet_Code", cbo_CodeValue.Text.Trim, "=", Nothing)


                    Case 8
                        labQueryItem = "院區(" & cbo_CodeValue.Text.Trim & "),"
                        If uclRefHosp = uclRefHospData.All Then
                            OtherQueryConditionDS.Tables.Add("AllHospital")
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Hospital_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                        ElseIf uclRefHosp = uclRefHospData.SouthArea Then

                            OtherQueryConditionDS.Tables.Add("SouthArea")
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Hospital_Code", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)


                        ElseIf uclRefHosp = uclRefHospData.NotSouthArea Then

                            OtherQueryConditionDS.Tables.Add("NotSouthArea")
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Hospital_Code", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)


                        ElseIf uclRefHosp = uclRefHospData.IsDialysisCenter Then

                            OtherQueryConditionDS.Tables.Add("IsDialysisCenter")
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Hospital_Code", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)

                        ElseIf uclRefHosp = uclRefHospData.IsAlliance Then

                            OtherQueryConditionDS.Tables.Add("IsAlliance")
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Hospital_Code", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)

                            '20140226 by ccr 增加含dc data
                        ElseIf uclRefHosp = uclRefHospData.AllIncludeDC Then
                            OtherQueryConditionDS.Tables.Add("AllIncludeDC")
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Hospital_Code", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)

                        End If
                    Case 9
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Order_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 10
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Apparatus_Code", cbo_CodeValue.Text.Trim, "=", Nothing)
                    Case 11
                        labQueryItem = "醫師(" & cbo_CodeValue.Text.Trim & "),"
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Doctor_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 12

                        labQueryItem = "員工號(" & cbo_CodeValue.Text.Trim & "),"
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Employee_Code", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)
                    Case 13
                        If _uclQueryValue = "" Then
                            'MessageBox.Show("請輸入科別")
                            'MessageHandling.showWarn("請輸入科別")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入科別"})
                            Exit Sub
                        Else
                            labQueryItem = "科別(" & cbo_CodeValue.Text.Trim & "),"
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Dept_Code︿A.Doctor_Code", _uclQueryValue & "︿" & cbo_CodeValue.Text.Trim, "=", Nothing)
                        End If

                    Case 14
                        If _uclQueryValue = "" Then
                            'MessageBox.Show("請輸入醫令類別")
                            'MessageHandling.showWarn("請輸入醫令類別")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入醫令類別"})
                            Exit Sub
                        Else
                            labQueryItem = "醫令類別(" & cbo_CodeValue.Text.Trim & "),"
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Order_Code︿A.Order_Type_Id", cbo_CodeValue.Text.Trim & "︿" & _uclQueryValue, "=", Nothing)
                        End If
                    Case 15
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Employee_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 16
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Professional_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 17
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Class_Code", cbo_CodeValue.Text.Trim, "=", Nothing)


                    Case 21
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Order_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 27
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Code_Id", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 28
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Chart_No", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 29
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Chart_No", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 30
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Pharmacy_12_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 33
                        If _uclQueryValue = "" Then
                            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入醫令類別"})
                            Exit Sub
                        Else
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Order_Code︿A.Order_Type_Id", cbo_CodeValue.Text.Trim & "︿" & _uclQueryValue, "=", Nothing)
                        End If

                    Case 34
                        If _uclQueryValue = "" Then
                            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入醫令類別"})
                            Exit Sub
                        Else
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Order_Code︿A.Order_Type_Id", cbo_CodeValue.Text.Trim & "︿" & _uclQueryValue, "=", Nothing)
                        End If

                    Case 36
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Doctor_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case uclQueryTable.PUB_DoctorVS
                        If cbo_CodeValue.Text.Trim.Length = 4 Then
                            '使用Doctor_Code
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Doctor_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                        ElseIf cbo_CodeValue.Text.Trim.Length = 6 Then
                            '使用Employee_Code
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "B.Employee_Code", cbo_CodeValue.Text.Trim, "=", Nothing)
                        Else
                            '使用Employee_Code
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "B.Employee_Code", cbo_CodeValue.Text.Trim, "=", Nothing)
                        End If
                    Case 38
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Contract_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 40
                        If _uclQueryValue = "" Then
                            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入" & uclMsgValue})
                            Exit Sub
                        Else
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Doctor_Code", _
                                                         cbo_CodeValue.Text.Trim & "︿" & _uclQueryValue, "=", Nothing)
                        End If

                    Case 41
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Dept_Code", cbo_CodeValue.Text.Trim, "=", Nothing)
                    Case 42
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Employee_Code", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)

                    Case 43
                        If cbo_CodeValue.Text.Trim.Length = 4 Then
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "DeptAndSectionCode", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)
                        End If

                    Case 50
                        If cbo_CodeValue.Text.Trim = "" Then
                            'MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入Icd10"})
                            Exit Sub
                        Else
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "Icd10_Code", cbo_CodeValue.Text.Trim, "Like", Nothing)
                        End If

                    Case 51

                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Insu_Dept_Code", cbo_CodeValue.Text.Trim, "=", Nothing)
                    Case 54

                        pvtDS = ucl.queryOpenWindow(_uclTableName, "PUB_NHI_Code", cbo_CodeValue.Text.Trim, "=", Nothing)
                    Case 60
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Drg_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 61
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "MDC_Code", cbo_CodeValue.Text.Trim, "=", Nothing)
                    Case 62
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Station_No", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)
                    Case 63
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Consumpation_Unit", cbo_CodeValue.Text.Trim, "=", Nothing)
                    Case 70
                        pvtDS = ucl.queryOpenWindow(_uclTableName, "BacOrgan_Code", cbo_CodeValue.Text.Trim, "=", Nothing)


                    Case 98
                        'All醫師

                        If cbo_CodeValue.Text.Trim.Length = 4 Then
                            '使用Doctor_Code
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Doctor_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                        ElseIf cbo_CodeValue.Text.Trim.Length = 6 Then
                            '使用Employee_Code
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "B.Employee_Code", cbo_CodeValue.Text.Trim, "=", Nothing)
                        End If

                    Case 99
                        'OHD 申報醫師

                        If cbo_CodeValue.Text.Trim.Length = 4 Then
                            '使用Doctor_Code
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Doctor_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                        ElseIf cbo_CodeValue.Text.Trim.Length = 6 Then
                            '使用Employee_Code
                            pvtDS = ucl.queryOpenWindow(_uclTableName, "B.Employee_Code", cbo_CodeValue.Text.Trim, "=", Nothing)
                        End If


                    Case 500

                        pvtDS = ucl.queryOpenWindow(_uclTableName, "Item_Code", cbo_CodeValue.Text.Trim, "=", Nothing)

                    Case 501

                        pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Employee_Code", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)

                    Case 502

                        pvtDS = ucl.queryOpenWindow(_uclTableName, "A.Order_Code", cbo_CodeValue.Text.Trim, "=", OtherQueryConditionDS)

                End Select


                If pvtDS IsNot Nothing Then
                    If pvtDS.Tables.Count = 0 Or pvtDS.Tables(0).Rows.Count = 0 Then
                        If uclIsTextAutoClear Then
                            cbo_CodeValue.Text = ""
                            _uclCodeName = ""
                            _uclCodeValue1 = ""
                            _uclCodeValue2 = ""
                        Else
                            _uclCodeName = ""
                            _uclCodeValue1 = cbo_CodeValue.Text
                            _uclCodeValue2 = ""
                        End If

                        If uclIsShowMsgBox Then
                            'MessageBox.Show("查無該筆資料")
                            'MessageHandling.showWarn("查無該筆資料")
                            '********************2010/2/9 Modify By Alan**********************
                            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {labQueryItem & "查無" & uclLabel & "資料"})
                        Else
                            '2010.07.16 Modified by 谷官, 不show Msg
                            ''MessageHandling.showInfo("查無該筆資料")
                            ''********************2010/2/9 Modify By Alan**********************
                            'MessageHandling.showInfoMsg("CMMCMMB300",New String(){"查無該筆資料"} )
                        End If

                        'cbo_CodeValue.Focus()
                        '查無資料開啟查詢視窗
                        If uclNoDataOpenWindow Then
                            Btn_CodeQuery_Click(Btn_CodeQuery, New EventArgs)
                        End If
                    ElseIf pvtDS.Tables(0).Rows.Count >= 1 Then

                        If _uclTableName = 1 OrElse _uclTableName = 37 Then

                            If uclIsCheckDoctorOnDuty Then
                                Dim CheckDrResult As String = CheckLoginDr(pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim())

                                If CheckDrResult = "" Then
                                    '檢核通過
                                    _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() '醫師姓名
                                    _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() '員工編號
                                    _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '醫師代碼

                                Else
                                    '檢核沒通過

                                    _uclCodeName = ""
                                    _uclCodeValue1 = ""
                                    _uclCodeValue2 = ""
                                    _uclQueryValue = ""
                                    cbo_CodeValue.Text = ""
                                    cbo_CodeValue.Focus()
                                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {CheckDrResult}, "")

                                    Exit Sub
                                End If

                            Else

                                '不 檢核
                                _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() '醫師姓名
                                _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() '員工編號
                                _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '醫師代碼


                            End If

                        ElseIf _uclTableName = 2 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()  '診間名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '診間號
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(4).ToString.Trim() '看診區

                        ElseIf _uclTableName = 3 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() '病患姓名
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '病歷號
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() 'idno

                        ElseIf _uclTableName = 4 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() '英文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '疾病分類碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim() '中文名稱

                        ElseIf _uclTableName = 5 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() '英文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '醫令項目代碼
                            _uclCodeValue2 = ""

                        ElseIf _uclTableName = 6 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()   '科別名稱
                            _uclCodeName2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()   '科別英文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '科別代碼

                            Try
                                _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()

                            Catch ex As Exception
                                _uclCodeValue2 = ""

                            End Try

                        ElseIf _uclTableName = 7 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() ' 表單名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '表單代碼
                            _uclCodeValue2 = ""

                        ElseIf _uclTableName = 8 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()   '醫院名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '醫院代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '健保特約醫院

                        ElseIf _uclTableName = 9 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()   '英文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '醫令項目代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() '醫令類型

                        ElseIf _uclTableName = 10 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '儀器名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '儀器代碼
                            _uclCodeValue2 = ""

                        ElseIf _uclTableName = 11 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()
                            _uclCodeValue2 = ""

                        ElseIf _uclTableName = 12 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '員工姓名
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '員工代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim()  'ID

                        ElseIf _uclTableName = 13 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()   '醫師姓名
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() '員工編號
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '醫師代碼


                        ElseIf _uclTableName = 14 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '英文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '醫令項目代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()  '中文名稱

                        ElseIf _uclTableName = 15 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '員工姓名
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '員工代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(5).ToString.Trim()  '組別名稱

                        ElseIf _uclTableName = 16 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '次專科名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '次專科代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()  '次專科英文名稱



                        ElseIf _uclTableName = 17 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '英文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()  '中文名稱

                        ElseIf _uclTableName = 18 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '英文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()  '中文名稱

                            '18,19,20多選

                        ElseIf _uclTableName = 21 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()   '英文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '醫令項目代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() '醫令類型

                        ElseIf _uclTableName = 27 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()   ' 名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() ' 代碼
                            _uclCodeValue2 = "" 'pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() '醫令類型


                        ElseIf _uclTableName = 28 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(14).ToString.Trim()   '  
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(14).ToString.Trim() '  
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(14).ToString.Trim()


                        ElseIf _uclTableName = 29 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(14).ToString.Trim()   '  
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(14).ToString.Trim() ' 
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(14).ToString.Trim() ' 

                        ElseIf _uclTableName = 30 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()   '  
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() ' 
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() ' 

                        ElseIf _uclTableName = 33 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '英文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '醫令項目代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()  '中文名稱

                        ElseIf _uclTableName = 34 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '英文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '醫令項目代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()  '中文名稱

                        ElseIf _uclTableName = 36 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()
                            _uclCodeValue2 = ""

                        ElseIf _uclTableName = uclQueryTable.PUB_DoctorVS Then
                            If uclIsCheckDoctorOnDuty Then
                                If CheckLoginDr(pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim()) Then
                                    '檢核通過
                                    _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() '醫師姓名
                                    _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() '員工編號
                                    _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '醫師代碼

                                Else
                                    '檢核沒通過

                                    _uclCodeName = ""
                                    _uclCodeValue1 = ""
                                    _uclCodeValue2 = ""
                                    _uclQueryValue = ""
                                    cbo_CodeValue.Focus()
                                    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"此醫師非在職!!"}, "")

                                    Exit Sub
                                End If

                            Else

                                '不 檢核
                                _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() '醫師姓名
                                _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() '員工編號
                                _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '醫師代碼


                            End If
                        ElseIf _uclTableName = 38 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()
                            _uclCodeValue2 = ""

                        ElseIf _uclTableName = 40 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()   '醫師姓名
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() '員工編號
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '醫師代碼

                        ElseIf _uclTableName = 41 Then '急診
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()   '科別名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '科別代碼

                            Try
                                _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()

                            Catch ex As Exception
                                _uclCodeValue2 = ""

                            End Try

                        ElseIf _uclTableName = 42 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '員工姓名
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '員工代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim()  '科室代號

                        ElseIf _uclTableName = 43 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()
                            _uclCodeValue = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() & pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()
                            _uclCodeName1 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim()
                            _uclCodeName2 = pvtDS.Tables(0).Rows(0).Item(4).ToString.Trim()

                        ElseIf _uclTableName = 50 Then

                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item("Icd9").ToString.Trim()
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item("Icd10").ToString.Trim()
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item("診斷英文名稱").ToString.Trim()
                            _uclCodeName1 = pvtDS.Tables(0).Rows(0).Item("診斷英文名稱").ToString.Trim()
                            _uclCodeName2 = pvtDS.Tables(0).Rows(0).Item("診斷中文名稱").ToString.Trim()


                        ElseIf _uclTableName = 51 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()   '科別名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '科別代碼

                            Try
                                _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()

                            Catch ex As Exception
                                _uclCodeValue2 = ""

                            End Try
                        ElseIf _uclTableName = 54 Then
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '健保碼
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()   '健保中文名稱

                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '健保碼
                            _uclCodeName2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()   '健保英文名稱


                        ElseIf _uclTableName = 60 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    'TW_DRGs英文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  'TW_DRGs碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()  'TW_DRGs名稱

                        ElseIf _uclTableName = 61 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '主要疾病類別MDC英文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '主要疾病類別MDC碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()  '主要疾病類別MDC名稱

                        ElseIf _uclTableName = 62 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '護理站名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '護理站代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()  '消耗單位
                            _uclCodeName2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()   '消耗單位名稱

                        ElseIf _uclTableName = 63 Then
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()    '消耗單位代碼
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()  '消耗單位名稱
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '消耗單位代碼

                        ElseIf _uclTableName = 70 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()   '名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '代碼

                        ElseIf _uclTableName = 98 Then

                            '不 檢核
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() '醫師姓名
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() '員工編號
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '醫師代碼

                        ElseIf _uclTableName = 99 Then

                            '不 檢核
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() '醫師姓名
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() '員工編號
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() '醫師代碼

                        ElseIf _uclTableName = 303 Then

                            'OPH_Code_Type_Id= 303
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() '中文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim() ' 藥物代碼

                        ElseIf _uclTableName = 500 Then

                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim() 'Item_Code
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim() ' Item_Name
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim() ' Sheet_Code

                        ElseIf _uclTableName = 501 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '員工姓名
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  '員工代碼
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(3).ToString.Trim()  'ID

                        ElseIf _uclTableName = 502 Then
                            _uclCodeName = pvtDS.Tables(0).Rows(0).Item(1).ToString.Trim()    '中文名稱
                            _uclCodeValue1 = pvtDS.Tables(0).Rows(0).Item(0).ToString.Trim()  'Code_Id
                            _uclCodeValue2 = pvtDS.Tables(0).Rows(0).Item(2).ToString.Trim()  '英文名稱

                        End If

                        If uclTextBoxShow = ShowText.Code Then
                            If uclTableName = uclQueryTable.PUB_Doctor Then
                                cbo_CodeValue.Text = _uclCodeValue2.Trim
                            Else
                                cbo_CodeValue.Text = _uclCodeValue1.Trim
                            End If

                        ElseIf uclTextBoxShow = ShowText.Name Then
                            cbo_CodeValue.Text = _uclCodeName.Trim

                        ElseIf uclTextBoxShow = ShowText.CodeAndName Then
                            If uclTableName = uclQueryTable.PUB_Department And uclIsEnglishDept Then
                                cbo_CodeValue.Text = _uclCodeValue1.Trim & " - " & _uclCodeName2.Trim
                            Else
                                cbo_CodeValue.Text = _uclCodeValue1.Trim & " - " & _uclCodeName.Trim
                            End If

                        ElseIf uclTextBoxShow = ShowText.Code2 Then
                            If uclTableName = uclQueryTable.PUB_Doctor Then
                                cbo_CodeValue.Text = _uclCodeValue1.Trim
                            Else
                                cbo_CodeValue.Text = _uclCodeValue2.Trim
                            End If

                        ElseIf uclTextBoxShow = ShowText.Code2AndName Then
                            cbo_CodeValue.Text = _uclCodeValue2.Trim & " - " & _uclCodeName.Trim
                        End If



                    End If
                Else
                    If uclIsShowMsgBox Then
                        'MessageBox.Show("查無該筆資料")
                        'MessageHandling.showWarn("查無該筆資料")
                        '********************2010/2/9 Modify By Alan**********************
                        MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"查無" & uclLabel & "資料"})
                    Else
                        '2010.07.16 Modified by 谷官, 不show Msg
                        ''MessageHandling.showInfo("查無該筆資料")
                        ''********************2010/2/9 Modify By Alan**********************
                        'MessageHandling.showInfoMsg("CMMCMMB300", New String() {"查無該筆資料"})
                    End If

                    If uclIsTextAutoClear Then

                        cbo_CodeValue.Text = ""

                    End If

                    _uclCodeName = ""
                    _uclCodeName1 = ""
                    _uclCodeName2 = ""

                    _uclCodeValue = ""
                    _uclCodeValue1 = ""
                    _uclCodeValue2 = ""
                    _uclQueryValue = ""
                    cbo_CodeValue.Focus()
                    '啟動EventManager的RaiseEvent

                End If

                If uclIsReturnDS Then
                    If pvtReceiveMgr Is Nothing Then
                        pvtReceiveMgr = EventManager.getInstance
                    End If
                    pvtReceiveMgr.RaiseUclOpenWindowValue2(Me.Parent.Name & Me.Name, pvtDS)

                End If

            End If

            If cbo_CodeValue.Text.Trim = "" Then
                _uclCodeName = ""
                _uclCodeName1 = ""
                _uclCodeName2 = ""

                _uclCodeValue = ""
                _uclCodeValue1 = ""
                _uclCodeValue2 = ""

            End If

            If uclCodeValue1 <> "" Then
                doFlag = False
            End If

            RaiseEvent ProcessQueryDone(Me)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Double Click UCLOpenWindowUI
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OpenWindowDoubleClick()
        RaiseEvent ProcessQueryDone(Me)
    End Sub
     

    ''' <summary>
    ''' Txt_CodeValue_Leave
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Txt_CodeValue_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_CodeValue.Leave
        If cbo_CodeValue.Text.Contains("'") Then
            cbo_CodeValue.Text.Replace("'", "''")
        End If
        ProcessQuery(cbo_CodeValue.Text.Trim, uclConditionDate)
        RaiseEvent Leave(sender, e)
        doFlag = False
    End Sub

    ''' <summary>
    ''' Txt_CodeValue_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Txt_CodeValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_CodeValue.TextChanged
        RaiseEvent TextChanged(sender, e)
        If cbo_CodeValue.Text.Trim = "" Then
            uclCodeName = ""
            uclCodeName1 = ""
            uclCodeName2 = ""

            uclCodeValue = ""
            uclCodeValue1 = ""
            uclCodeValue2 = ""

        End If
        doFlag = True
    End Sub


    ''' <summary>
    ''' Btn_CodeQuery_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_CodeQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CodeQuery.Click
        Try

            Dim pvtCallFlag = True

            'If _uclTableName = 2 And _uclQueryValue = "" Then
            '    'MessageBox.Show("請輸入看診區")
            '    'MessageHandling.showWarn("請輸入看診區")
            '    '********************2010/2/9 Modify By Alan**********************
            '    MessageHandling.showWarnMsg("CMMCMMB300",New String(){"請輸入看診區"} )
            '    pvtCallFlag = False
            'End If


            If _uclTableName = 13 And _uclQueryValue = "" Then
                'MessageBox.Show("請輸入科別")
                'MessageHandling.showWarn("請輸入科別")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入科別"})
                pvtCallFlag = False
            End If

            If _uclTableName = 14 And _uclQueryValue = "" Then
                'MessageBox.Show("請輸入醫令類別")
                'MessageHandling.showWarn("請輸入醫令類別")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入醫令類別"})
                pvtCallFlag = False
            End If

            If _uclTableName = 33 And _uclQueryValue = "" Then
                'MessageBox.Show("請輸入醫令類別")
                'MessageHandling.showWarn("請輸入醫令類別")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入醫令類別"})
                pvtCallFlag = False
            End If

            If _uclTableName = 34 And _uclQueryValue = "" Then
                'MessageBox.Show("請輸入醫令類別")
                'MessageHandling.showWarn("請輸入醫令類別")
                '********************2010/2/9 Modify By Alan**********************
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入醫令類別"})
                pvtCallFlag = False
            End If

            If _uclTableName = 40 And _uclQueryValue = "" Then
                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"請輸入" & uclMsgValue})
                pvtCallFlag = False
            End If


            If pvtCallFlag Then
                Dim pvtOW As UCLOpenWindowUI = New UCLOpenWindowUI()

                OtherQueryConditionDS = New DataSet
                Dim dBDate As Date
                Dim blnIsDate As Boolean = False
                If IsDate(uclConditionDate) AndAlso Date.TryParse(uclConditionDate, dBDate) Then
                    blnIsDate = True
                    uclConditionDate = dBDate.ToShortDateString
                    OtherQueryConditionDS = New DataSet
                    OtherQueryConditionDS.Tables.Add("UseBaseDate")
                    OtherQueryConditionDS.Tables("UseBaseDate").Columns.Add("baseDate")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("UseBaseDate").NewRow
                    drNew.Item("baseDate") = uclConditionDate
                    OtherQueryConditionDS.Tables("UseBaseDate").Rows.Add(drNew)
                End If

                'If Not IsCheckDc Then
                '    OtherQueryConditionDS.Tables.Add("CheckDc")
                '    OtherQueryConditionDS.Tables("CheckDc").Columns.Add("IsCheckDc")
                '    Dim drNew As DataRow = OtherQueryConditionDS.Tables("CheckDc").NewRow
                '    drNew.Item("IsCheckDc") = "N"
                '    OtherQueryConditionDS.Tables("CheckDc").Rows.Add(drNew)
                'End If

                If uclDeptType <> DeptType.None Then
                    OtherQueryConditionDS.Tables.Add("DeptType")
                    OtherQueryConditionDS.Tables("DeptType").Columns.Add("Type")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("DeptType").NewRow
                    drNew.Item("Type") = uclDeptType.ToString
                    OtherQueryConditionDS.Tables("DeptType").Rows.Add(drNew)
                End If

                If uclPUBEmployeeProfessalKindId <> "" Then
                    OtherQueryConditionDS.Tables.Add("PUBEmployeeProfessalKindId")
                    OtherQueryConditionDS.Tables("PUBEmployeeProfessalKindId").Columns.Add("Professal_Kind_Id")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("PUBEmployeeProfessalKindId").NewRow
                    drNew.Item("Professal_Kind_Id") = uclPUBEmployeeProfessalKindId.ToString
                    OtherQueryConditionDS.Tables("PUBEmployeeProfessalKindId").Rows.Add(drNew)
                End If

                If uclRoles <> "" Then
                    OtherQueryConditionDS.Tables.Add("uclRoles")
                    OtherQueryConditionDS.Tables("uclRoles").Columns.Add("uclRoles")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("uclRoles").NewRow
                    drNew.Item("uclRoles") = uclRoles.ToString
                    OtherQueryConditionDS.Tables("uclRoles").Rows.Add(drNew)
                End If

                If uclIsCheckTime = False Then
                    OtherQueryConditionDS.Tables.Add("IsCheckTime")
                    OtherQueryConditionDS.Tables("IsCheckTime").Columns.Add("IsCheckTime")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("IsCheckTime").NewRow
                    drNew.Item("IsCheckTime") = "N"
                    OtherQueryConditionDS.Tables("IsCheckTime").Rows.Add(drNew)
                End If

                If uclIsCheckDrLicense = False Then
                    OtherQueryConditionDS.Tables.Add("IsCheckDrLicense")
                    OtherQueryConditionDS.Tables("IsCheckDrLicense").Columns.Add("IsCheckDrLicense")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("IsCheckDrLicense").NewRow
                    drNew.Item("IsCheckDrLicense") = "N"
                    OtherQueryConditionDS.Tables("IsCheckDrLicense").Rows.Add(drNew)
                End If

                If uclRegionKind <> "'" Then
                    OtherQueryConditionDS.Tables.Add("RegionKind")
                    OtherQueryConditionDS.Tables("RegionKind").Columns.Add("Region_Kind")
                    Dim drNew As DataRow = OtherQueryConditionDS.Tables("RegionKind").NewRow
                    Dim regionKindArr As String() = uclRegionKind.Split(",")
                    For Each s As String In regionKindArr
                        drNew.Item("Region_Kind") = drNew.Item("Region_Kind") & "'" & s & "',"
                    Next
                    drNew.Item("Region_Kind") = drNew.Item("Region_Kind").ToString.Trim.Substring(0, drNew.Item("Region_Kind").ToString.Trim.Length - 1)
                    OtherQueryConditionDS.Tables("RegionKind").Rows.Add(drNew)
                End If
                pvtOW.SetMyParent(Me)
                pvtOW.SetOtherQueryConditionDS(OtherQueryConditionDS)

                '20140226 by ccr 增加含dc data
                If uclRefHosp = uclRefHospData.All Then
                    pvtOW.RefHosp = 0
                ElseIf uclRefHosp = uclRefHospData.SouthArea Then
                    pvtOW.RefHosp = 1
                ElseIf uclRefHosp = uclRefHospData.NotSouthArea Then
                    pvtOW.RefHosp = 2
                ElseIf uclRefHosp = uclRefHospData.IsDialysisCenter Then
                    pvtOW.RefHosp = 3
                ElseIf uclRefHosp = uclRefHospData.IsAlliance Then
                    pvtOW.RefHosp = 4
                ElseIf uclRefHosp = uclRefHospData.AllIncludeDC Then
                    pvtOW.RefHosp = 5

                End If

                If uclDeptCode <> "" Then
                    Dim QueryDS As New DataSet
                    QueryDS.Tables.Add()
                    QueryDS.Tables(0).Columns.Add("QueryField")
                    QueryDS.Tables(0).Columns.Add("QueryValue")

                    QueryDS.Tables(0).Rows.Add()
                    If uclTableName = uclQueryTable.PUB_Doctor Then
                        QueryDS.Tables(0).Rows(0).Item("QueryField") = "D.License_Dept_Code"
                        QueryDS.Tables(0).Rows(0).Item("QueryValue") = uclDeptCode

                        pvtOW.SetQueryData(QueryDS, uclIsReturnDS)
                    End If
                 
                End If

                '啟動EventManager的RaiseEvent
                If pvtReceiveMgr Is Nothing Then
                    pvtReceiveMgr = EventManager.getInstance
                End If
                pvtReceiveMgr.RaiseUclOpenWindow2(Me.ParentForm.Name & Me.Name, _uclTableName, _uclQueryField, _uclQueryValue)
                pvtOW.IsCheckDoctorOnDuty = uclIsCheckDoctorOnDuty

                pvtOW.returnDSFlag = uclIsReturnDS
                pvtOW.uclXPosition = _uclXPosition
                pvtOW.uclYPosition = _uclYPosition

                pvtOW.UCLOpenWindowUI_Load(sender, e)

            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 接收Windows 所選的項目 by UCLOpenWindowUI
    ''' </summary>
    ''' <param name="uclName"></param>
    ''' <param name="CodeValue1"></param>
    ''' <param name="CodeValue2"></param>
    ''' <param name="CodeName"></param>
    ''' <remarks></remarks>
    Public Sub doUclOpenWindowValue(ByVal uclName As String, ByVal CodeValue1 As String, ByVal CodeValue2 As String, ByVal CodeName As String) Handles pvtReceiveMgr.UclOpenWindowValue
        Try


            If Me.ParentForm IsNot Nothing AndAlso uclName.Trim = Me.ParentForm.Name & Me.Name Then

                If uclTableName = uclQueryTable.PUB_Department Then
                    _uclCodeValue1 = CodeValue1
                    _uclCodeName2 = CodeValue2 '英文名稱

                    _uclCodeName = CodeName
                Else
                    _uclCodeValue1 = CodeValue1
                    _uclCodeValue2 = CodeValue2

                    _uclCodeName = CodeName
                End If


                If uclTextBoxShow = ShowText.Code Then
                    If uclTableName = uclQueryTable.PUB_Doctor Then
                        cbo_CodeValue.Text = _uclCodeValue2.Trim

                    Else
                        cbo_CodeValue.Text = _uclCodeValue1.Trim

                    End If

                ElseIf uclTextBoxShow = ShowText.Name Then
                    cbo_CodeValue.Text = _uclCodeName.Trim

                ElseIf uclTextBoxShow = ShowText.CodeAndName Then
                    If uclTableName = uclQueryTable.PUB_Doctor Then
                        cbo_CodeValue.Text = _uclCodeValue2.Trim & " - " & _uclCodeName.Trim

                    ElseIf uclTableName = uclQueryTable.PUB_Department Then
                        If Not uclIsEnglishDept Then
                            cbo_CodeValue.Text = _uclCodeValue1.Trim & " - " & _uclCodeName.Trim
                        Else
                            cbo_CodeValue.Text = _uclCodeValue1.Trim & " - " & _uclCodeName2.Trim
                        End If
                    Else
                        cbo_CodeValue.Text = _uclCodeValue1.Trim & " - " & _uclCodeName.Trim
                    End If

                ElseIf uclTextBoxShow = ShowText.Code2 Then
                    If uclTableName = uclQueryTable.PUB_Doctor Then
                        cbo_CodeValue.Text = _uclCodeValue1.Trim

                    Else
                        cbo_CodeValue.Text = _uclCodeValue2.Trim

                    End If

                ElseIf uclTextBoxShow = ShowText.Code2AndName Then
                    If uclTableName = uclQueryTable.PUB_Doctor Then
                        cbo_CodeValue.Text = _uclCodeValue1.Trim & " - " & _uclCodeName.Trim
                    Else
                        cbo_CodeValue.Text = _uclCodeValue2.Trim & " - " & _uclCodeName.Trim
                    End If

                End If

                If uclCodeValue1 <> "" Then
                    doFlag = False
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Txt_CodeValue_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Txt_CodeValue_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_CodeValue.KeyUp
        RaiseEvent KeyUp(sender, e)
        Select Case e.KeyCode
            Case Keys.Enter
                Txt_CodeValue_Leave(sender, e)

        End Select
    End Sub

    ''' <summary>
    ''' UCLTextCodeQueryUI_Resize
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UCLTextCodeQueryUI_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        If UCLFormUtil.isResizeable Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
        Else
            Me.Height = 26
            uclCboWidth = Me.Width - 36
        End If

    End Sub



#End Region


    ''' <summary>
    ''' 醫生檢核
    ''' </summary>
    ''' <param name="EmpCode">醫生代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckLoginDr(ByVal EmpCode As String) As String

        Return ""

    End Function


End Class

