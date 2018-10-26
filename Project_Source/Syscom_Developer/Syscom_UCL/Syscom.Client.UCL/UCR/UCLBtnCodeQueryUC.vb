Imports Syscom.Client.servicefactory
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.log
Imports Syscom.Client.cmm
Imports System.Text
Imports System.Windows.Forms

Public Class UCLBtnCodeQueryUC


#Region "全域變數宣告"

    Dim pvtDS As DataSet
    Dim pvtFocusFlag = False
    '宣告EventManager
    'Private pvtSendMgr As EventManager = EventManager.getInstance
    Dim WithEvents pvtSendMgr As EventManager = EventManager.getInstance '宣告EventManager


    Public Shadows Event Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Private _uclXPosition As Integer = 225
    Private _uclYPosition As Integer = 120

    Private _uclSelectType As SelectType = SelectType.SingleSelect

    Private _uclIsReturnDS As Boolean = False  '是否要回傳DS(特殊用)..否則回傳name code1 code2   
    Private _uclBtnText As String = "..."

    Private ds As DataSet
    Private queryDS As DataSet
    Private index As Integer = -1

    Dim uclListBox As UCLListBoxUC
    Dim uclCheckListBox As UCLCheckListBoxUC

    Public keyIndex As Integer = -1
    Public selectedCodeStr As String()

    Private _uclTableName = uclQueryTable.PUB_Doctor      '定義要查詢的表格
    Private _uclQueryField As String                      '定義要查詢欄位名稱
    Private _uclQueryValue As String                      '定義要查詢欄位值

    '設定或取回元件欄位值
    Private _uclCodeValue1 As String            '代碼值1
    Private _uclCodeValue2 As String            '代碼值2(For 醫師檔- 例如:代碼值1=>員工代碼，代碼值2=>醫師代碼)
    Private _uclCodeName As String              '代碼所對應名稱
    Dim _uclEnableQueryList As Boolean = True

    Dim _uclRefHosp As uclRefHospData = uclRefHospData.All


    Dim OtherQueryConditionDS As DataSet

    Private _uclIsCheckDoctorOnDuty As Boolean = False   '是否檢核醫生是否在職中 (預設不檢核)
    Private _uclIsCanSelectReserveChartNoForMultiChartNo As Boolean = True '多個病歷號時,是否顯示最新的病歷號 (含被合併的)
    Private _uclAreaCode As String = ""
#End Region


#Region "屬性設定"

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
        OPH_Pharmacy_Base = 19          '19:藥品基本資料 (多選)
        OPH_Phrase = 20                 '20: OPH_Phrase , OPH_Rule_Reason
        PUB_OrderByTreatmentTypeId2 = 21 '21:醫令牙科約診

        PUB_SyscodeTypeId626 = 22
        PUB_SyscodeTypeId628 = 23
        PUB_SyscodeTypeId666 = 24
        PUB_SyscodeTypeId631 = 25
        PUB_SyscodeTypeId632 = 26

        PUB_SyscodeTypeId27 = 27

        REF_Referral_Patient = 28      '28:轉介病人檔
        REF_Referral_Out_Patient = 29   '29:轉出病人檔

        PUB_Department_MultiSelect = 31   '31:多選科室
        INP_Station_MultiSelect = 32      '32:多選戶理站
        'PUB_OrderForMantain = 33         '33:醫令查詢For醫令基本檔維護(UCLTextCodeQueryUI已定義,在此尚未實作)
        PUB_SyscodeTypeId29 = 35
        REG_Week_Schedule = 36           '11:週班表查詢

        PUB_SyscodeTypeId629 = 39
        PUB_DepartmentFroEmg = 41              '41:急診科室檔

        PUB_Area = 52  '地區
        PUB_Vil = 53    '里

        DRG_Drg_Base = 60       '60:TW_DRGs基本檔
        DRG_Mdc_Base = 61       '61:MDC主要疾病類別檔

        PUB_DoctorForOHD = 99              '99 OHD申報醫生

    End Enum

    Enum uclRefHospData
        All = 0
        SouthArea = 1
        NotSouthArea = 2
        IsDialysisCenter = 3
    End Enum

    Public Property uclIsCheckDoctorOnDuty() As Boolean
        Get
            Return _uclIsCheckDoctorOnDuty
        End Get
        Set(ByVal value As Boolean)
            _uclIsCheckDoctorOnDuty = value
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

    Public Property uclEnableQueryList() As Boolean
        Get
            Return _uclEnableQueryList
        End Get
        Set(ByVal value As Boolean)
            _uclEnableQueryList = value

        End Set
    End Property


    Enum SelectType
        SingleSelect = 1
        MultiSelect = 2
    End Enum

    Public Property uclIsCanSelectReserveChartNoForMultiChartNo() As Boolean
        Get
            Return _uclIsCanSelectReserveChartNoForMultiChartNo
        End Get
        Set(ByVal value As Boolean)
            _uclIsCanSelectReserveChartNoForMultiChartNo = value
        End Set
    End Property

    Public Property uclAreaCode() As String
        Get
            Return _uclAreaCode
        End Get
        Set(ByVal value As String)
            _uclAreaCode = value

        End Set
    End Property

    Public Property uclBtnText() As String
        Get
            Return _uclBtnText
        End Get
        Set(ByVal value As String)
            _uclBtnText = value
            Btn_CodeQuery.Text = value
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

    Public Property uclSelectType() As SelectType
        Get
            Return _uclSelectType
        End Get
        Set(ByVal value As SelectType)
            _uclSelectType = value
        End Set
    End Property

    Public ReadOnly Property uclCodeValue1() As String
        Get
            Return _uclCodeValue1
        End Get
    End Property

    Public ReadOnly Property uclCodeValue2() As String
        Get
            Return _uclCodeValue2
        End Get
    End Property

    Public ReadOnly Property uclCodeName() As String
        Get
            Return _uclCodeName
        End Get
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


#End Region


#Region "Function"


    Public Function getCodeName() As String
        Return _uclCodeName.Trim
    End Function
    Public Function getCode() As String
        Return _uclCodeValue1.Trim
    End Function
    Public Function getCode2() As String
        Return _uclCodeValue2.Trim
    End Function

    Public Sub SetSelectedCodeStr(ByRef arrStr As String())
        selectedCodeStr = arrStr
    End Sub

    Public Sub PerformClick()

        Btn_CodeQuery.PerformClick()

    End Sub

    ''' <summary>
    ''' 設定夥伴元件UCLListBoxUI
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Overloads Sub SetPartner(ByRef partner As UCLListBoxUC)
        uclListBox = partner
    End Sub

    ''' <summary>
    ''' 設定夥伴元件UCLCheckListBoxUI
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Overloads Sub SetPartner(ByRef partner As UCLCheckListBoxUC)
        uclCheckListBox = partner
    End Sub

    ''' <summary>
    ''' 設定要進行查詢的DataSet
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetQueryDS(ByVal queryDataDS As DataSet)
        queryDS = queryDataDS
    End Sub

#End Region

#Region "Event"

    Public Sub ucl_Query_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Btn_CodeQuery_Click(sender, e)
    End Sub

    Private Sub Btn_CodeQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CodeQuery.Click

        Try

            RaiseEvent Click(sender, e) '啟動外面的Click事件

            Dim pvtCallFlag = True

            If _uclTableName = 2 And _uclQueryValue = "" Then
                MessageBox.Show("請輸入看診區")
                pvtCallFlag = False
            End If
            If _uclTableName = 13 And _uclQueryValue = "" Then
                MessageBox.Show("請輸入科別")
                pvtCallFlag = False
            End If

            If _uclTableName = 14 And _uclQueryValue = "" Then
                MessageBox.Show("請輸入醫令類別")
                pvtCallFlag = False
            End If

            Select Case uclTableName
                Case uclQueryTable.PUB_Doctor
                    keyIndex = 0
                Case uclQueryTable.PUB_Zone_Room
                    keyIndex = 0
            End Select


            If pvtCallFlag Then
                If _uclSelectType = SelectType.SingleSelect Then
                     
                    Dim pvtOW1 As UCLOpenWindowUI = New UCLOpenWindowUI()

                    If Not uclIsCanSelectReserveChartNoForMultiChartNo Then
                        pvtOW1.SetIsCanSelectReserveChartNoForMultiChartNo(False)
                    End If

                    If uclAreaCode <> "" Then
                        pvtOW1.SetAreaCode(uclAreaCode)
                    End If

                    If uclRefHosp = uclRefHospData.All Then
                        pvtOW1.RefHosp = 0
                    ElseIf uclRefHosp = uclRefHospData.SouthArea Then
                        pvtOW1.RefHosp = 1
                    ElseIf uclRefHosp = uclRefHospData.NotSouthArea Then
                        pvtOW1.RefHosp = 2
                    ElseIf uclRefHosp = uclRefHospData.IsDialysisCenter Then
                        pvtOW1.RefHosp = 3
                    End If

                    If pvtSendMgr Is Nothing Then
                        pvtSendMgr = EventManager.getInstance
                    End If
                    '啟動EventManager的RaiseEvent
                    pvtOW1.IsCheckDoctorOnDuty = uclIsCheckDoctorOnDuty
                    pvtSendMgr.RaiseUclOpenWindow2(ParentForm.Name & Me.Name, _uclTableName, _uclQueryField, _uclQueryValue)

                    pvtOW1.uclXPosition = _uclXPosition
                    pvtOW1.uclYPosition = _uclYPosition

                    If queryDS IsNot Nothing Then
                        pvtOW1.SetQueryData(queryDS, uclIsReturnDS)
                    End If

                    pvtOW1.returnDSFlag = uclIsReturnDS

                    pvtOW1.UCLOpenWindowUI_Load(sender, e)


                Else '多選查詢
                     
                    Dim pvtOW2 As UCLOpenWindowMultiSelectUI = New UCLOpenWindowMultiSelectUI()
                    pvtOW2.IsCheckDoctorOnDuty = uclIsCheckDoctorOnDuty

                    If Not uclEnableQueryList Then
                        pvtOW2.SetDisableQuery()
                    End If
                     
                    If uclCheckListBox IsNot Nothing Then
                        pvtOW2.Initial(ParentForm.Name & Me.Name, uclCheckListBox.GetSelectedItemCodes, uclTableName, uclQueryValue)

                        If queryDS IsNot Nothing Then
                            pvtOW2.SetQueryData(queryDS)
                        End If
                         
                    ElseIf uclListBox IsNot Nothing Then
                        pvtOW2.Initial(ParentForm.Name & Me.Name, uclListBox.GetAllItemCodes, uclTableName, uclQueryValue)

                        If queryDS IsNot Nothing Then
                            pvtOW2.SetQueryData(queryDS)
                        End If

                    ElseIf selectedCodeStr IsNot Nothing Then
                        pvtOW2.Initial(ParentForm.Name & Me.Name, selectedCodeStr, uclTableName, uclQueryValue)

                        If queryDS IsNot Nothing Then
                            pvtOW2.SetQueryData(queryDS)
                        End If
                    Else

                        If uclTableName = uclQueryTable.OPH_Pharmacy_Base OrElse uclTableName = uclQueryTable.OPH_Phrase Then
                            pvtOW2.Initial(ParentForm.Name & Me.Name, selectedCodeStr, uclTableName, uclQueryValue)
                        End If

                    End If

                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub



    Private Sub UCLBtnCodeQueryUI_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Height = 27
        Me.Width = 29
    End Sub
#End Region

End Class


