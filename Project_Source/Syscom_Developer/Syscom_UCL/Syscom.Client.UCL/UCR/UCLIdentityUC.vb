Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.Windows.Forms
Imports System.Drawing

''' <summary>
''' 程式說明：共用元件 身份別連動設定
''' 開發人員：James
''' 開發日期：2009/05/07
''' </summary>
''' <修改註記>
''' 1.2009/07/22, modified by 谷官, 增加Enabled的屬性
''' 2.2010/05/06, add by 谷官
''' 3.2010/05/11, add by 谷官, 身份2為""時也需帶出合約資料
''' </修改註記>
Public Class UCLIdentityUC


#Region "20090507 add by James ,共用元件 身份別連動設定"


#Region "全域變數宣告"

    Dim mainIdDS, DisIdDS As DataSet

    Private _uclShowId1 As Boolean = True
    Private _uclShowId2 As Boolean = True
    Private _uclShowDisId As Boolean = True
    Private _uclShowContract As ShowContractType = ShowContractType.ShowBoth
    Private _uclShowMedicalTypeId As Boolean = True
    Private _uclShowPartCode As Boolean = True
    Private _uclShowCardSn As Boolean = True

    Private _uclId1Width As Integer = 100
    Private _uclId2Width As Integer = 100
    Private _uclDisIdWidth As Integer = 100
    Private _uclContract1Width As Integer = 100
    Private _uclContract2Width As Integer = 100
    Private _uclMedicalTypeIdWidth As Integer = 100
    Private _uclPartCodeWidth As Integer = 80
    Private _uclCardSnWidth As Integer = 50


    Private _uclMainIdDisplayIndex As String = "0,1"
    Private _uclMainIdValueIndex As String = "0"

    Private _uclSubIdDisplayIndex As String = "0,1"
    Private _uclSubIdValueIndex As String = "0"

    Private _uclDisIdDisplayIndex As String = "0,1"
    Private _uclDisIdValueIndex As String = "0"

    Private _uclConDisplayIndex As String = "0,1"
    Private _uclConValueIndex As String = "0"

    Private _uclMedicalTypeIdDisplayIndex As String = "0,1"
    Private _uclMedicalTypeIdValueIndex As String = "0"

    Private _uclPartCodeDisplayIndex As String = "0,1"
    Private _uclPartCodeValueIndex As String = "0"

    Private g_MainId, g_SubId, g_DisId, g_Contract1, g_Contract2, g_MedicalTypeId, g_PartCode, g_CardSn, g_CaseTypeId, g_ICMedicalTypeId, g_InsuPaykindId As String
    Private g_DeptCode
    Private g_pubMedicalTypeDT

    '1.2009/07/22, modified by 谷官, 增加Enabled的屬性
    Private _uclEnabledId1 As Boolean = True
    Private _uclEnabledId2 As Boolean = True
    Private _uclEnabledDisId As Boolean = True
    Private _uclEnabledContract As Boolean = True
    Private _uclEnabledMedicalTypeId As Boolean = True
    Private _uclEnabledPartCode As Boolean = True
    Private _uclEnabledCardSn As Boolean = True


    '2.2010/05/06, add by 谷官
    Private pfamKind As String = ""
    Dim needChangeSubIDFlag As Boolean = True

    '4.2011/03/22, add by 谷官, 不可轉健保的身份二
    Private noNhiHT As New Hashtable
    Private subIdRec As String = ""

    '5.2015/07/09 add by Bella, 常數設定
    Private m_payMainId As String = "1" '自費
    Private m_healthMainId As String = "2"  '健保

    Dim ucl As IUclServiceManager = UclServiceManager.getInstance
    Dim OperSet As DataSet = Nothing
    Dim _Source As String = "O"
    Dim SortType As String = ""
    Enum SourceTypeValue
        O = 1
        E = 2
        I = 3
        H = 4
    End Enum

    Private _uclSourceType = SourceTypeValue.O

#End Region

#Region "屬性設定"

    Enum ShowContractType
        ShowBoth = 0
        ShowOne = 1
        None = 2
    End Enum

    ''' <summary>
    ''' 針對看診目的分門診急診住院來做不同的排序
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclSortType() As String
        Get
            Return SortType
        End Get
        Set(ByVal value As String)
            SortType = value
            Select Case value
                Case 1
                    SortType = "O"
                Case 2
                    SortType = "E"
                Case 3
                    SortType = "I"
                Case 4
                    SortType = "H"
            End Select

        End Set
    End Property

    ''' <summary>
    ''' 設定來源 O/E/I
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclSourceType() As SourceTypeValue
        Get
            Return _uclSourceType
        End Get
        Set(ByVal value As SourceTypeValue)
            _uclSourceType = value
            Select Case value
                Case 1
                    _Source = "O"
                Case 2
                    _Source = "E"
                Case 3
                    _Source = "I"
                Case 4
                    _Source = "H"
            End Select

        End Set
    End Property

    Public Property Source() As String
        Get
            Return _Source
        End Get
        Set(ByVal value As String)
            _Source = value
            Select Case value
                Case "O"
                    _uclSourceType = 1
                Case "E"
                    _uclSourceType = 2
                Case "I"
                    _uclSourceType = 3
                Case "H"
                    _uclSourceType = 4
            End Select

        End Set
    End Property

#Region "設定各欄位選取值的Index"

    ''' <summary>
    ''' 設定要顯示的欄位Index(預設為0,1=>代碼與名稱)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclMainIdDisplayIndex() As String
        Get
            Return _uclMainIdDisplayIndex
        End Get
        Set(ByVal value As String)
            _uclMainIdDisplayIndex = value
            cbo_MainId.uclDisplayIndex = value
        End Set
    End Property

    ''' <summary>
    ''' 設定要選取值的欄位Index(預設為0=>代碼)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclMainIdValueIndex() As String
        Get
            Return _uclMainIdValueIndex
        End Get
        Set(ByVal value As String)
            _uclMainIdValueIndex = value
            cbo_MainId.uclValueIndex = value
        End Set
    End Property

    ''' <summary>
    ''' 設定要顯示的欄位Index(預設為0,1=>代碼與名稱)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclSubIdDisplayIndex() As String
        Get
            Return _uclSubIdDisplayIndex
        End Get
        Set(ByVal value As String)
            _uclSubIdDisplayIndex = value
            cbo_SubId.uclDisplayIndex = value
        End Set
    End Property

    ''' <summary>
    ''' 設定要選取值的欄位Index(預設為0=>代碼)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclSubValueIndex() As String
        Get
            Return _uclSubIdValueIndex
        End Get
        Set(ByVal value As String)
            _uclSubIdValueIndex = value
            cbo_SubId.uclValueIndex = value
        End Set
    End Property

    ''' <summary>
    ''' 設定要顯示的欄位Index(預設為0,1=>代碼與名稱)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclDisIdDisplayIndex() As String
        Get
            Return _uclDisIdDisplayIndex
        End Get
        Set(ByVal value As String)
            _uclDisIdDisplayIndex = value
            cbo_DisId.uclDisplayIndex = value
        End Set
    End Property

    ''' <summary>
    ''' 設定要選取值的欄位Index(預設為0=>代碼)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclDisIdValueIndex() As String
        Get
            Return _uclDisIdValueIndex
        End Get
        Set(ByVal value As String)
            _uclDisIdValueIndex = value
            cbo_DisId.uclValueIndex = value
        End Set
    End Property

    ''' <summary>
    ''' 設定要顯示的欄位Index(預設為0,1=>代碼與名稱)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclConDisplayIndex() As String
        Get
            Return _uclConDisplayIndex
        End Get
        Set(ByVal value As String)
            _uclConDisplayIndex = value
            cbo_Contract1.uclDisplayIndex = value
            cbo_Contract2.uclDisplayIndex = value
        End Set
    End Property

    ''' <summary>
    ''' 設定要選取值的欄位Index(預設為0=>代碼)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclConValueIndex() As String
        Get
            Return _uclConValueIndex
        End Get
        Set(ByVal value As String)
            _uclConValueIndex = value
            cbo_Contract1.uclValueIndex = value
            cbo_Contract2.uclValueIndex = value
        End Set
    End Property

#End Region
#Region "欄位寬度設定"

    ''' <summary>
    ''' 設定Id1欄位寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclId1Width() As Integer
        Get
            Return _uclId1Width
        End Get
        Set(ByVal value As Integer)
            _uclId1Width = value

            cbo_MainId.Width = value
        End Set
    End Property

    ''' <summary>
    ''' 設定Id2欄位寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclId2Width() As Integer
        Get
            Return _uclId2Width
        End Get
        Set(ByVal value As Integer)
            _uclId2Width = value

            cbo_SubId.Width = value
        End Set
    End Property

    ''' <summary>
    ''' 設定DisId欄位寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclDisIdWidth() As Integer
        Get
            Return _uclDisIdWidth
        End Get
        Set(ByVal value As Integer)
            _uclDisIdWidth = value

            cbo_DisId.Width = value
        End Set
    End Property

    ''' <summary>
    ''' 設定合約1欄位寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclContract1Width() As Integer
        Get
            Return _uclContract1Width
        End Get
        Set(ByVal value As Integer)
            _uclContract1Width = value

            cbo_Contract1.Width = value
        End Set
    End Property

    ''' <summary>
    ''' 設定合約2欄位寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclContract2Width() As Integer
        Get
            Return _uclContract2Width
        End Get
        Set(ByVal value As Integer)
            _uclContract2Width = value

            cbo_Contract2.Width = value
        End Set
    End Property

    ''' <summary>
    ''' 設定看診目的欄位寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclMedicalTypeIdWidth() As Integer
        Get
            Return _uclMedicalTypeIdWidth
        End Get
        Set(ByVal value As Integer)
            _uclMedicalTypeIdWidth = value

            cbo_medical_type_id.Width = value
        End Set
    End Property

    ''' <summary>
    ''' 設定部分負擔碼欄位寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclPartCodeWidth() As Integer
        Get
            Return _uclPartCodeWidth
        End Get
        Set(ByVal value As Integer)
            _uclPartCodeWidth = value

            cbo_part_code.Width = value
        End Set
    End Property

    ''' <summary>
    ''' 設定卡序欄位寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclCardSnWidth() As Integer
        Get
            Return _uclCardSnWidth
        End Get
        Set(ByVal value As Integer)
            _uclCardSnWidth = value

            txt_card_sn.Width = value
        End Set
    End Property

#End Region

#Region "設定元件顯示與否"

    ''' <summary>
    ''' 設定欄位是否顯示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclShowId1() As Boolean
        Get
            Return _uclShowId1
        End Get
        Set(ByVal value As Boolean)
            _uclShowId1 = value
            'lbl_MainId.Visible = False '20150526 MODIFY BY BELLA 隱藏主身份
            cbo_MainId.Visible = False '20150526 MODIFY BY BELLA 隱藏主身份
        End Set
    End Property

    ''' <summary>
    ''' 設定欄位是否顯示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclShowId2() As Boolean
        Get
            Return _uclShowId2
        End Get
        Set(ByVal value As Boolean)
            _uclShowId2 = value
            lbl_SubId.Visible = value
            cbo_SubId.Visible = value
        End Set
    End Property

    ''' <summary>
    ''' 設定欄位是否顯示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclShowDisId() As Boolean
        Get
            Return _uclShowDisId
        End Get
        Set(ByVal value As Boolean)
            _uclShowDisId = value
            lbl_DisId.Visible = value
            cbo_DisId.Visible = value
        End Set
    End Property

    ''' <summary>
    ''' 設定欄位是否顯示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclShowContract() As ShowContractType
        Get
            Return _uclShowContract
        End Get
        Set(ByVal value As ShowContractType)
            If value = ShowContractType.ShowBoth Then
                lbl_Contract.Visible = True
                cbo_Contract1.Visible = True
                cbo_Contract2.Visible = True

                _uclShowContract = value
            ElseIf value = ShowContractType.ShowOne Then
                lbl_Contract.Visible = True
                cbo_Contract1.Visible = True
                cbo_Contract2.Visible = False
                _uclShowContract = value
            ElseIf value = ShowContractType.None Then
                lbl_Contract.Visible = False
                cbo_Contract1.Visible = False
                cbo_Contract2.Visible = False
                _uclShowContract = value
            End If

        End Set
    End Property

    ''' <summary>
    ''' 設定欄位是否顯示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclShowMedicalTypeId() As Boolean
        Get
            Return _uclShowMedicalTypeId
        End Get
        Set(ByVal value As Boolean)
            _uclShowMedicalTypeId = value
            lbl_medical_type_id.Visible = value
            cbo_medical_type_id.Visible = value
        End Set
    End Property

    ''' <summary>
    ''' 設定欄位是否顯示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclShowPartCodeId() As Boolean
        Get
            Return _uclShowPartCode
        End Get
        Set(ByVal value As Boolean)
            _uclShowPartCode = value
            lbl_part_code.Visible = value
            cbo_part_code.Visible = value
        End Set
    End Property

    ''' <summary>
    ''' 設定欄位是否顯示
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclShowCardSnId() As Boolean
        Get
            Return _uclShowCardSn
        End Get
        Set(ByVal value As Boolean)
            _uclShowCardSn = value
            lbl_card_sn.Visible = value
            txt_card_sn.Visible = value
        End Set
    End Property

#End Region

#Region "設定元件欄位是否可用"

    ''' <summary>
    ''' 設定Id1欄位是否Enable
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclEnabledId1() As Boolean
        Get
            Return _uclEnabledId1
        End Get
        Set(ByVal value As Boolean)
            cbo_MainId.Enabled = value
            _uclEnabledId1 = value
        End Set
    End Property

    ''' <summary>
    ''' 設定Id2欄位是否Enable
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclEnabledId2() As Boolean
        Get
            Return _uclEnabledId2
        End Get
        Set(ByVal value As Boolean)
            cbo_SubId.Enabled = value
            _uclEnabledId2 = value
        End Set
    End Property

    ''' <summary>
    ''' 設定DisId欄位是否Enable
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclEnabledDisId() As Boolean
        Get
            Return _uclEnabledDisId
        End Get
        Set(ByVal value As Boolean)
            cbo_DisId.Enabled = value
            _uclEnabledDisId = value
        End Set
    End Property

    ''' <summary>
    ''' 設定合約欄位是否Enable
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclEnabledContract() As Boolean
        Get
            Return _uclEnabledContract
        End Get
        Set(ByVal value As Boolean)
            cbo_Contract1.Enabled = value
            cbo_Contract2.Enabled = value
            _uclEnabledContract = value
        End Set
    End Property

    ''' <summary>
    ''' 設定看診目的是否Enable
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclEnabledMedicalTypeId() As Boolean
        Get
            Return _uclEnabledMedicalTypeId
        End Get
        Set(ByVal value As Boolean)
            cbo_medical_type_id.Enabled = value
            _uclEnabledMedicalTypeId = value
        End Set

    End Property

#End Region
    'Public Property uclEnabledPartCode() As Boolean
    '    Get
    '        Return _uclEnabledPartCode
    '    End Get
    '    Set(ByVal value As Boolean)
    '        cbo_part_code.Enabled = value
    '        _uclEnabledPartCode = value
    '    End Set
    'End Property

    'Public Property uclEnabledCardSn() As Boolean
    '    Get
    '        Return _uclEnabledCardSn
    '    End Get
    '    Set(ByVal value As Boolean)
    '        txt_card_sn.Enabled = value
    '        _uclEnabledCardSn = value
    '    End Set
    'End Property

#End Region

#Region "初始化"

    ''' <summary>
    ''' 初始化設定
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub Initial()

        Try
            g_MainId = ""
            g_SubId = ""
            g_DisId = ""
            g_Contract1 = ""
            g_Contract2 = ""
            g_MedicalTypeId = ""
            g_PartCode = ""
            g_CardSn = ""




            '1.2009/07/22, modified by 谷官, 增加Enabled的屬性
            'cbo_MainId.Enabled = False

            '2015/06/25 by Bella, 修改為以method方式初始化combobox
            initComboboxData()

            '3.2010/05/11, add by 谷官, 身份2為""時也需帶出合約資料
            setContractSourceData("")

            '4.2011/03/22, add by 谷官, 不可轉健保的身份二
            setNoNhiData(OperSet)

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 初始化設定
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub Initial(ByVal ds As DataSet)

        Try
            g_MainId = ""
            g_SubId = ""
            g_DisId = ""
            g_Contract1 = ""
            g_Contract2 = ""
            g_MedicalTypeId = ""
            g_PartCode = ""
            g_CardSn = ""

            OperSet = ds.Copy

            '1.2009/07/22, modified by 谷官, 增加Enabled的屬性
            'cbo_MainId.Enabled = False

            '2015/06/25 by Bella, 修改為以method方式初始化combobox
            initComboboxData()

            '3.2010/05/11, add by 谷官, 身份2為""時也需帶出合約資料
            setContractSourceData("")

            '4.2011/03/22, add by 谷官, 不可轉健保的身份二
            setNoNhiData(ds)

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Console.WriteLine(ex.ToString)
        End Try
    End Sub

#End Region

#Region "外部函數"

#Region "設定畫面的值 & 取得畫面的值"

    ''' <summary>
    ''' 設定身份一代碼
    ''' value:身份一代碼
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetMainIdValue(ByVal value As String)
        g_MainId = value
        cbo_MainId.SelectedValue = value

    End Sub

    ''' <summary>
    ''' 設定身份二代碼
    ''' value:身份二代碼
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetSubIdValue(ByVal value As String)
        g_SubId = value
        cbo_SubId.SelectedValue = value
    End Sub

    ''' <summary>
    ''' 設定優待身份代碼
    ''' value:優待身份代碼
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetDisIdValue(ByVal value As String)
        g_DisId = value
        cbo_DisId.SelectedValue = value

    End Sub

    ''' <summary>
    ''' 設定合約廠商一代碼
    ''' value:合約廠商一代碼
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetCon1Value(ByVal value As String)
        g_Contract1 = value
        cbo_Contract1.SelectedValue = value

    End Sub

    ''' <summary>
    ''' 設定合約廠商二代碼
    ''' value:合約廠商二代碼
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetCon2Value(ByVal value As String)
        g_Contract2 = value
        cbo_Contract2.SelectedValue = value

    End Sub

    ''' <summary>
    ''' 設定看診目的
    ''' value:看診目的
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetMedicalTypeIdValue(ByVal value As String)
        g_MedicalTypeId = value
        cbo_medical_type_id.SelectedValue = value
    End Sub

    ''' <summary>
    ''' 設定部負
    ''' value:部負
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetPartCodeValue(ByVal value As String)
        g_PartCode = value
        cbo_part_code.SelectedValue = value

    End Sub

    ''' <summary>
    ''' 設定卡序
    ''' value:卡序
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetCardSnValue(ByVal value As String)
        g_CardSn = value
        txt_card_sn.Text = value

    End Sub

    ''' <summary>
    ''' 設定案件類別
    ''' value:案件類別
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetCaseTypeIdValue(ByVal value As String)
        g_CaseTypeId = value
    End Sub

    ''' <summary>
    ''' 設定IC卡就醫類別
    ''' value:設定IC卡就醫類別
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetICMedicalTypeIdValue(ByVal value As String)
        g_ICMedicalTypeId = value
    End Sub

    ''' <summary>
    ''' 設定給付類別
    ''' value:設定給付類別
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetInsuPaykindIdValue(ByVal value As String)
        g_InsuPaykindId = value
    End Sub

    '-----------------------------------------------------------------'

    ''' <summary>
    ''' 取得身份一Text
    ''' </summary>
    ''' <returns>身份一Text</returns>
    ''' <remarks></remarks>''' 
    Public Function GetMainIdText() As String
        Return nvl(cbo_MainId.Text)
    End Function

    ''' <summary>
    ''' 取得身份一Code
    ''' </summary>
    ''' <returns>身份一Code</returns>
    ''' <remarks></remarks>''' 
    Public Function GetMainIdValue() As String
        Return nvl(g_MainId)
    End Function

    ''' <summary>
    ''' 取得身份二Text
    ''' </summary>
    ''' <returns>身份二Text</returns>
    ''' <remarks></remarks>''' 
    Public Function GetSubIdText() As String
        Return nvl(cbo_SubId.Text)
    End Function

    ''' <summary>
    ''' 取得身份二Code
    ''' </summary>
    ''' <returns>身份二Code</returns>
    ''' <remarks></remarks>''' 
    Public Function GetSubIdValue() As String
        Return nvl(g_SubId)
    End Function

    ''' <summary>
    ''' 取得優待身份Text
    ''' </summary>
    ''' <returns>優待身份Text</returns>
    ''' <remarks></remarks>''' 
    Public Function GetDisIdText() As String
        Return nvl(cbo_DisId.Text)
    End Function

    ''' <summary>
    ''' 取得優待身份Code
    ''' </summary>
    ''' <returns>優待身份Code</returns>
    ''' <remarks></remarks>''' 
    Public Function GetDisIdValue() As String
        Return nvl(g_DisId)
    End Function

    ''' <summary>
    ''' 取得合約廠商一Text
    ''' </summary>
    ''' <returns>合約廠商一Text</returns>
    ''' <remarks></remarks>''' 
    Public Function GetCon1Text() As String
        Return nvl(cbo_Contract1.Text)
    End Function

    ''' <summary>
    ''' 取得合約廠商一Code
    ''' </summary>
    ''' <returns>合約廠商一Code</returns>
    ''' <remarks></remarks>''' 
    Public Function GetCon1Value() As String
        Return nvl(g_Contract1)
    End Function

    ''' <summary>
    ''' 取得合約廠商二Text
    ''' </summary>
    ''' <returns>合約廠商二Text</returns>
    ''' <remarks></remarks>''' 
    Public Function GetCon2Text() As String
        Return nvl(cbo_Contract2.Text)
    End Function

    ''' <summary>
    ''' 取得合約廠商二Code
    ''' </summary>
    ''' <returns>合約廠商二Code</returns>
    ''' <remarks></remarks>''' 
    Public Function GetCon2Value() As String
        Return nvl(g_Contract2)
    End Function

    ''' <summary>
    ''' 取得看診目的Code
    ''' </summary>
    ''' <returns>看診目的Code</returns>
    ''' <remarks></remarks>''' 
    Public Function GetMedicalTypeIdValue() As String
        Return nvl(g_MedicalTypeId)
    End Function

    ''' <summary>
    ''' 取得看診目的Text
    ''' </summary>
    ''' <returns>看診目的Text</returns>
    ''' <remarks></remarks>''' 
    Public Function GetMedicalTypeIdText() As String
        Return nvl(cbo_medical_type_id.Text)
    End Function

    ''' <summary>
    ''' 取得部負Code
    ''' </summary>
    ''' <returns>部負Code</returns>
    ''' <remarks></remarks>''' 
    Public Function GetPartCodeValue() As String
        Return nvl(g_PartCode)
    End Function

    ''' <summary>
    ''' 取得部負Text
    ''' </summary>
    ''' <returns>部負Text</returns>
    ''' <remarks></remarks>''' 
    Public Function GetPartCodeText() As String
        Return nvl(cbo_part_code.Text)
    End Function

    ''' <summary>
    ''' 取得卡序Code
    ''' </summary>
    ''' <returns>部負Code</returns>
    ''' <remarks></remarks>''' 
    Public Function GetCardSnValue() As String
        Return nvl(g_CardSn)
    End Function

    ''' <summary>
    ''' 取得卡序Text
    ''' </summary>
    ''' <returns>部負Text</returns>
    ''' <remarks></remarks>''' 
    Public Function GetCardSnText() As String
        Return nvl(txt_card_sn.Text)
    End Function

    ''' <summary>
    ''' 取得PUB_Medical_Type Datatable
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPUBMedicalTypeDT() As DataTable
        Return g_pubMedicalTypeDT
    End Function

    ''' <summary>
    ''' 取得案件類別
    ''' </summary>
    ''' <returns>案件類別</returns>
    ''' <remarks></remarks>''' 
    Public Function GetCaseTypeIdValue() As String
        Return nvl(g_CaseTypeId)
    End Function

    ''' <summary>
    ''' 取得IC卡就醫類型
    ''' </summary>
    ''' <returns>IC卡就醫類型</returns>
    ''' <remarks></remarks>''' 
    Public Function GetICMedicalTypeIdValue() As String
        Return nvl(g_ICMedicalTypeId)
    End Function

    ''' <summary>
    ''' 取得給付類別
    ''' </summary>
    ''' <returns>給付類別</returns>
    ''' <remarks></remarks>''' 
    Public Function GetInusPayKindIdValue() As String
        Return nvl(g_InsuPaykindId)
    End Function

#End Region

#Region "元件背景顏色設定"
    ''' <summary>
    ''' 設定MainId背景顏色
    ''' </summary>
    ''' <param name="ColorValue"></param>
    ''' <remarks></remarks>
    Public Sub SetMainIdColor(ByVal ColorValue As Color)
        cbo_MainId.BackColor = ColorValue
    End Sub
    ''' <summary>
    ''' 設定SubId背景顏色
    ''' </summary>
    ''' <param name="ColorValue"></param>
    ''' <remarks></remarks>
    Public Sub SetSubIdColor(ByVal ColorValue As Color)
        cbo_SubId.BackColor = ColorValue
    End Sub
    ''' <summary>
    ''' 設定MainIdLabel背景顏色
    ''' </summary>
    ''' <param name="ColorValue"></param>
    ''' <remarks></remarks>
    Public Sub SetMainIdLabelColor(ByVal ColorValue As Color)
        'lbl_MainId.ForeColor = ColorValue
    End Sub
    ''' <summary>
    ''' 設定SubIdLabel背景顏色
    ''' </summary>
    ''' <param name="ColorValue"></param>
    ''' <remarks></remarks>
    Public Sub SetSubIdLabelColor(ByVal ColorValue As Color)
        lbl_SubId.ForeColor = ColorValue
    End Sub
    ''' <summary>
    ''' 設定MedicalTypeId背景顏色
    ''' </summary>
    ''' <param name="ColorValue"></param>
    ''' <remarks></remarks>
    Public Sub SetMedicalTypeIdColor(ByVal ColorValue As Color)
        cbo_medical_type_id.BackColor = ColorValue
    End Sub
    ''' <summary>
    ''' 設定CardSn背景顏色
    ''' </summary>
    ''' <param name="ColorValue"></param>
    ''' <remarks></remarks>
    Public Sub SetCardSnColor(ByVal ColorValue As Color)
        txt_card_sn.BackColor = ColorValue
    End Sub
    ''' <summary>
    ''' 設定Default背景顏色
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaultColor()
        'lbl_MainId.ForeColor = Label1.ForeColor
        lbl_SubId.ForeColor = Label1.ForeColor
        lbl_Contract.ForeColor = Label1.ForeColor

        cbo_MainId.BackColor = TextBox1.BackColor
        cbo_SubId.BackColor = TextBox1.BackColor
        cbo_DisId.BackColor = TextBox1.BackColor
        cbo_Contract1.BackColor = TextBox1.BackColor
        cbo_Contract2.BackColor = TextBox1.BackColor
        cbo_medical_type_id.BackColor = TextBox1.BackColor
        cbo_part_code.BackColor = TextBox1.BackColor
        txt_card_sn.BackColor = TextBox1.BackColor
    End Sub
#End Region

#Region "其他控制設定"

    ''' <summary>
    ''' 1.當此IDNo是院內員工且Pfam_kind=01(from Pfam)，則優待身分default為"員工"，但需排除身分二為17
    ''' 2.非01~05的其他Pfam_kind直接default 合約1
    ''' </summary>
    ''' <param name="idNo">ID No</param>
    ''' <remarks></remarks>
    Public Sub SetDefaultDisID(ByVal idNo As String)
        Try
            If idNo.Length > 0 Then
                'Me.pfamKind = ucl.getPfamKindFromNCKM_CommonDB_PfamDT(idNo)
            End If

            SetDisIdValue("")
            SetCon1Value("")
            SetCon2Value("")

            Select Case Me.pfamKind
                Case "01", "02", "03", "04", "05"
                    If (Me.pfamKind.Equals("01") Or Me.pfamKind.Equals("05")) And Not Me.g_SubId.Equals("17") Then
                        SetDisIdValue("1")
                    Else
                        SetDisIdValue("")
                    End If
                Case Else
                    SetCon1Value(Me.pfamKind)
            End Select
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 1.設定生日,以算年齡是否為百歲
    ''' </summary>
    ''' <param name="Birthday">生日</param>
    ''' <remarks></remarks>
    Public Sub SetBirthDay(ByVal Birthday As String)
        Try
            If IsDate(Birthday) Then

                Dim Age As String() = Syscom.Comm.Utility.DateUtil.GetAge(CDate(Birthday), Now)

                If CInt(Age(0)) > 99 Then
                    SetDisIdValue("3") '百歲人瑞
                End If

            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 設定科別，變更排序
    ''' </summary>
    ''' <param name="DeptCode">生日</param>
    ''' <remarks></remarks>
    Public Sub SetDeptCode(ByVal DeptCode As String)
        Try
            g_DeptCode = DeptCode
            setMedicalTypeIdSourceData(g_MainId, g_DeptCode)

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 清除所有選擇的資料
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub Clear()
        Me.pfamKind = ""
        Me.subIdRec = ""

        cbo_MainId.Text = ""
        cbo_SubId.Text = ""
        cbo_DisId.Text = ""
        cbo_Contract1.Text = ""
        cbo_Contract2.Text = ""
        cbo_medical_type_id.Text = ""
        cbo_part_code.Text = ""
        txt_card_sn.Text = ""

        g_MainId = ""
        g_SubId = ""
        g_DisId = ""
        g_Contract1 = ""
        g_Contract2 = ""
        g_MedicalTypeId = ""
        g_PartCode = ""
        g_CardSn = ""

        SetDefaultColor()
    End Sub

    ''' <summary>
    ''' 欄位檢核
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function checkFiledValue() As Boolean

        'If Me.cbo_medical_type_id.SelectedValue.Equals("IC07") Then
        '    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"戒煙請用櫃台批價作業處理!!"}, "")
        '    Me.cbo_medical_type_id.BackColor = Colors.BACK_COLOR_ERROR_INPUT
        '    Me.cbo_medical_type_id.Focus()
        '    Return False
        'Else
        '    'If StringUtil.nvl(Me.dgv_charge.CurrentRow.Cells("Medical_Type_Id").Value).Equals("IC07") Then
        '    '    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"戒煙請用櫃台批價作業處理!!"}, "")
        '    '    Me.ucl_medical_type_id.BackColor = Colors.BACK_COLOR_ERROR_INPUT
        '    '    Me.ucl_medical_type_id.Focus()
        '    '    Return False
        '    'End If
        'End If
        '2012.01.03 add by bella, 無法在費用重計加入omo審核(pbc無法往下參考)，只好先以提示訊息擋住
        '遇到IC06開頭的則需至轉身份處理，才有檢核
        'If Me.cbo_medical_type_id.SelectedValue.Length >= 4 AndAlso Me.cbo_medical_type_id.SelectedValue.Substring(0, 4).Equals("IC06") Then
        '    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"此就醫類型須涉及醫師檢核，請用轉身份處理!!"}, "")
        '    Me.cbo_medical_type_id.BackColor = Colors.BACK_COLOR_ERROR_INPUT
        '    Me.cbo_medical_type_id.Focus()
        '    Return False
        'Else
        '    'If StringUtil.nvl(Me.dgv_charge.CurrentRow.Cells("Medical_Type_Id").Value).Length >= 4 AndAlso StringUtil.nvl(Me.dgv_charge.CurrentRow.Cells("Medical_Type_Id").Value).Equals("IC06") Then
        '    '    MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"此就醫類型須涉及醫師檢核，請用轉身份處理!!"}, "")
        '    '    Me.cbo_medical_type_id.BackColor = Colors.BACK_COLOR_ERROR_INPUT
        '    '    Me.cbo_medical_type_id.Focus()
        '    '    Return False
        '    'End If
        'End If
    End Function

    ''' <summary>
    ''' 傳入DataTable，將裡面各個欄位的值填到畫面上
    ''' </summary>
    ''' <param name="valueDT"></param>
    ''' <returns></returns>
    ''' <remarks>可以用在健保資料設定回來後，將datatable丟進來</remarks>
    Public Function setAllValueByDT(ByVal valueDT As DataTable)
        Try
            If valueDT IsNot Nothing AndAlso valueDT.Rows.Count > 0 Then
                With valueDT.Rows(0)

                    '給付類別
                    If valueDT.Columns.Contains("Insu_Paykind_Id") Then
                        SetInsuPaykindIdValue(.Item("Insu_Paykind_Id"))
                    End If

                    '部份負擔
                    If valueDT.Columns.Contains("Part_Code") Then
                        SetPartCodeValue(.Item("Part_Code"))
                    End If

                    '案件分類
                    If valueDT.Columns.Contains("Case_Type_Id") Then
                        SetCaseTypeIdValue(.Item("Case_Type_Id"))
                    End If

                    '卡序 (不管畫面有沒有卡序，一律清掉改成預設，若原本已有取到卡序，之後再來做判斷) 2015.07.13 mark by bella
                    If valueDT.Columns.Contains("Card_Sn") Then
                        SetCardSnValue(.Item("Card_Sn"))
                    End If

                    'IC就醫類別
                    If valueDT.Columns.Contains("IC_Medical_Type_Id") Then
                        SetICMedicalTypeIdValue(.Item("IC_Medical_Type_Id"))
                    End If

                    '合約1
                    If valueDT.Columns.Contains("Contract_Code1") Then
                        SetCon1Value(.Item("Contract_Code1"))
                    End If

                    '合約2
                    If valueDT.Columns.Contains("Contract_Code2") Then
                        SetCon2Value(.Item("Contract_Code2"))
                    End If

                    '優待 2015.07.10 add by Bella
                    If valueDT.Columns.Contains("Dis_Identity_Code") Then
                        SetDisIdValue(.Item("Dis_Identity_Code"))
                    End If

                End With
            End If

            Return Nothing

        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB915", ex)
        End Try

    End Function

#End Region

#End Region

#Region "內部函數"

    ''' <summary>
    ''' 設定不可轉健保的身份二
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Private Sub setNoNhiData(ByVal ds As DataSet)
        Try
            '3.2011/03/22, add by 谷官, 不可轉健保的身份二
            'If DataSetUtil.CheckTableExistOrNot(ds, "cfgNoNhiDT", True) Then
            '    Dim tempStr As String = StringUtil.nvl(ds.Tables("cfgNoNhiDT").Rows(0).Item("Config_Value"))
            '    Dim tempAL() As String = tempStr.Split(New Char() {","})

            '    For iIndex As Integer = 0 To tempAL.Length - 1
            '        If Not Me.noNhiHT.Contains(tempAL(iIndex)) Then
            '            Me.noNhiHT.Add(tempAL(iIndex), "")
            '        End If
            '    Next
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 初始化combobox資料
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initComboboxData()

        If OperSet Is Nothing Then

            Dim pvtSourceType As String = "O"
            Select Case _uclSourceType
                Case 1
                    pvtSourceType = "O"
                Case 2
                    pvtSourceType = "E"
                Case 3
                    pvtSourceType = "I"
                Case 4
                    pvtSourceType = "H"
            End Select

            OperSet = ucl.queryUclIdentityInitial2(pvtSourceType)

        End If

        cbo_MainId.DataSource = CType(OperSet.Tables("MainId"), DataTable).Copy
        cbo_MainId.uclDisplayIndex = "0,1"
        cbo_MainId.uclValueIndex = "0"

        cbo_SubId.DataSource = CType(OperSet.Tables("SubId"), DataTable).Copy
        cbo_SubId.uclDisplayIndex = "0,2"
        cbo_SubId.uclValueIndex = "0"

        cbo_DisId.DataSource = CType(OperSet.Tables("DisId"), DataTable).Copy
        cbo_DisId.uclDisplayIndex = "0,1"
        cbo_DisId.uclValueIndex = "0"

        cbo_Contract1.DataSource = CType(OperSet.Tables("Contract"), DataTable).Copy
        cbo_Contract1.uclDisplayIndex = "0,1"
        cbo_Contract1.uclValueIndex = "0"

        cbo_Contract2.DataSource = CType(OperSet.Tables("Contract"), DataTable).Copy
        cbo_Contract2.uclDisplayIndex = "0,1"
        cbo_Contract2.uclValueIndex = "0"

        cbo_medical_type_id.DataSource = CType(OperSet.Tables("PUBMedicalTypeDT"), DataTable).Copy
        cbo_medical_type_id.uclDisplayIndex = "0,1"
        cbo_medical_type_id.uclValueIndex = "0"
        g_pubMedicalTypeDT = CType(OperSet.Tables("PUBMedicalTypeDT"), DataTable).Copy

        cbo_part_code.DataSource = CType(OperSet.Tables("PubPartDT"), DataTable).Copy
        cbo_part_code.uclDisplayIndex = "0,1"
        cbo_part_code.uclValueIndex = "0"

        cbo_caseTypeId.DataSource = CType(OperSet.Tables("CaseTypeIdDT"), DataTable).Copy
        cbo_caseTypeId.uclDisplayIndex = "0,1"
        cbo_caseTypeId.uclValueIndex = "0"

    End Sub
#End Region

#Region "Event"

    Public Event cboMainId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event cboSubId_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event cboDisId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event cboContract1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event cboContract2_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event cboMedicalTypeId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


    Private Sub cbo_MainId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_MainId.SelectedIndexChanged
        If cbo_MainId.SelectedIndex > 0 Then
            RaiseEvent cboMainId_SelectedIndexChanged(sender, e)
        End If

    End Sub

    ''' <summary>
    ''' 改變身份二的值
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' (1)主身份跟著改變(from PUB_Sub_Identity)
    ''' (2)合約的顯示下拉資料跟著改變(from PUB_Contract_Set)
    ''' (3)若主身份等於自費時，清除健保相關資訊（但看診目的不變）
    ''' (4)若主身份等於健保時，保留畫面資訊，不跑任何規則
    ''' </remarks>
    Private Sub cbo_SubId_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_SubId.SelectedIndexChanged
        Try
            If cbo_SubId.SelectedIndex >= 0 Then

                '4.2011/03/22, add by 谷官, 不可轉健保的身份二
                If Me.noNhiHT.Contains(Me.subIdRec) Then
                    cbo_SubId.SelectedValue = Me.subIdRec
                    Exit Sub
                End If

                Dim ConDS As New DataSet

                g_MainId = ""
                g_SubId = nvl(cbo_SubId.SelectedValue)

                '(1)主身份跟著改變(from PUB_Sub_Identity)
                If Me.OperSet IsNot Nothing AndAlso Me.OperSet.Tables.Contains("SubId") Then
                    Dim dr As DataRow() = Me.OperSet.Tables("SubId").Select("Column1 = '" & g_SubId & "'")
                    If dr.Length > 0 Then
                        Me.g_MainId = nvl(dr(0).Item("Column2"))
                        Me.cbo_MainId.SelectedValue = g_MainId
                    End If
                End If

                '(2)合約的顯示下拉資料跟著改變(from PUB_Contract_Set)
                setContractSourceData(g_SubId)

                '(3)看診目的跟著改變(from PUB_Medical_Typd)
                setMedicalTypeIdSourceData(g_MainId, g_DeptCode)


                '(4)若主身份等於自費時，清除健保相關資訊
                If g_MainId.Equals(m_payMainId) Then
                    'SetMedicalTypeIdValue("")
                    SetPartCodeValue("")
                    SetCardSnValue("")
                    Me.cbo_caseTypeId.SelectedValue = ""
                End If
                '判斷如果主身分是健保  卻選了自費看診目的時，清空看診目的 避免批價錯誤
                If GetMainIdValue.Equals("2") AndAlso GetMedicalTypeIdValue() <> "" Then
                    If OperSet.Tables("PUBMedicalTypeDT").AsEnumerable().Where(Function(r) r.Field(Of String)("Medical_Type_Id").ToString.Trim = GetMedicalTypeIdValue()). _
                        Select(Function(c) c("Medical_Type_Ctrl_Id").ToString.Trim).DefaultIfEmpty("").FirstOrDefault = "S" Then
                        SetMedicalTypeIdValue("")
                    End If
                End If

                '2010.07.12 Add by 谷官   此為成醫邏輯，不符合聯醫 先mark掉 2015.07.13 by Bella
                '====================
                'Select Case g_SubId
                '    Case "17", "38"
                '        If Not Me.pfamKind.Equals("01") Then

                '            If needChangeSubIDFlag Then
                '                'MessageHandling.showWarn("此病患非員工，不可使用此身分")
                '                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"此病患非員工，不可使用此身分"})
                '                needChangeSubIDFlag = False
                '            End If

                '            cbo_SubId.SelectedValue = ""
                '            'SetDisIdValue("")

                '            needChangeSubIDFlag = True

                '        End If

                '        '需排除身份17
                '        If g_SubId.Equals("17") And cbo_DisId.SelectedValue.Equals("1") Then
                '            cbo_DisId.SelectedValue = ""
                '        End If

                '        '17員工的優待
                '        If g_SubId.Equals("17") Then
                '            cbo_DisId.SelectedValue = "A"
                '        End If

                '    Case "36"
                '        cbo_Contract1.SelectedValue = "RS"

                '        '20121116 by ccr 依需求單1201211080020醫事室陳舜玲取消53身份自動帶入合約
                '        'Case "53"
                '        '    cbo_Contract1.SelectedValue = "T9"

                '        '20121116 by ccr 依需求單1201205210030醫事室桂芳29身份自動帶入合約
                '    Case "29"
                '        If Me.pfamKind >= "HA" And Me.pfamKind <= "HZ" Then
                '            cbo_Contract1.SelectedValue = "LBR"
                '            cbo_Contract2.SelectedValue = Me.pfamKind
                '        Else
                '            cbo_Contract1.SelectedValue = "LBR"
                '        End If

                '    Case "97"
                '        cbo_Contract1.SelectedValue = "C015"

                '    Case "11", "12"
                '        cbo_Contract1.SelectedValue = "UA"

                '        '20130122 by ccr 依需求單1201301180080醫事室陳舜玲6B身份自動帶入合約      
                '    Case "49", "6B"
                '        cbo_Contract1.SelectedValue = "A012"
                '    Case "57"
                '        If Me.pfamKind >= "HA" And Me.pfamKind <= "HZ" Then
                '            cbo_Contract1.Text = ""
                '            cbo_Contract2.SelectedValue = Me.pfamKind
                '        End If
                '    Case Else
                '        If Me.pfamKind >= "HA" And Me.pfamKind <= "HZ" Then
                '            'cbo_Contract2.DataSource.Clear()
                '            cbo_Contract2.Text = ""
                '            cbo_Contract1.SelectedValue = Me.pfamKind
                '        End If
                'End Select
                '====================

                RaiseEvent cboSubId_SelectedIndexChange(sender, e)

                '3.2010/05/11, add by 谷官, 身份2為""時也需帶出合約資料

                'ElseIf cbo_SubId.SelectedIndex = 0 Then

                '    cbo_Contract1.DataSource.Clear()
                '    cbo_Contract2.DataSource.Clear()

                '    'cbo_Contract1.Items.Clear()
                '    'cbo_Contract2.Items.Clear()
                '    cbo_Contract1.Text = ""
                '    cbo_Contract2.Text = ""
                '    'cbo_Contract1.Items.Add("")
                '    'cbo_Contract2.Items.Add("")
                '    cbo_MainId.Text = ""

                '    g_MainId = ""
                '    g_SubId = ""
                '    g_Contract1 = ""
                '    g_Contract2 = ""

                '    RaiseEvent cboSubId_SelectedIndexChange(sender, e)

                '4.2011/03/22, add by 谷官, 不可轉健保的身份二
                Me.subIdRec = g_SubId
            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 設定合約的下拉選單(by身份二)
    ''' </summary>
    ''' <param name="subId"></param>
    ''' <remarks></remarks>
    Private Sub setContractSourceData(ByVal subId As String)
        Try

            cbo_Contract1.DataSource.Clear()
            cbo_Contract2.DataSource.Clear()

            cbo_Contract1.Text = ""
            cbo_Contract2.Text = ""

            Dim ConDT As DataTable = OperSet.Tables("Contract").Copy

            If Me.OperSet IsNot Nothing AndAlso Me.OperSet.Tables.Contains("Contract") Then
                Dim dr As DataRow() = Me.OperSet.Tables("Contract").Select("Column3='" & subId & "' or Column3 = ''")
                ConDT = dr.CopyToDataTable
            End If

            cbo_Contract1.DataSource = ConDT.Copy
            cbo_Contract1.uclDisplayIndex = "0,1"
            cbo_Contract1.uclValueIndex = "0"

            cbo_Contract2.DataSource = ConDT.Copy
            cbo_Contract2.uclDisplayIndex = "0,1"
            cbo_Contract2.uclValueIndex = "0"

            cbo_Contract1.SelectedValue = g_Contract1
            cbo_Contract2.SelectedValue = g_Contract2

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 設定看診目的的下拉選單(by主身份)
    ''' </summary>
    ''' <param name="mainId"></param>
    ''' <remarks></remarks>
    Public Sub setMedicalTypeIdSourceData(ByVal mainId As String, ByVal deptCode As String)
        Try

            cbo_medical_type_id.DataSource.Clear()

            cbo_medical_type_id.Text = ""

            Dim medicalDT As New DataTable

            If Me.OperSet IsNot Nothing AndAlso Me.OperSet.Tables.Contains("PUBMedicalTypeDT") Then
                Using dt As DataTable = Me.OperSet.Tables("PUBMedicalTypeDT").Copy
                    Dim dr As DataRow()
                    If g_MainId.Equals(m_payMainId) Then
                        '自費
                        dr = dt.Select("Medical_Type_Ctrl_Id = 'S'")
                    Else
                        '健保
                        dr = dt.Select("ISNULL(Medical_Type_Ctrl_Id,'') <> 'S'")
                    End If
                    If dr.Length > 0 Then
                        medicalDT = dr.CopyToDataTable
                        If nvl(deptCode).Length > 0 Then
                            Select Case deptCode
                                '目前為寫死院內科別代碼
                                Case "04", "41"
                                    'PED_sort (兒科):
                                    medicalDT.DefaultView.Sort = "PED_sort"
                                Case "03", "06", "07", "10", "11", "15", "40", "93", "99"
                                    'SUR_sort (外科):
                                    medicalDT.DefaultView.Sort = "SUR_sort"
                                Case "01", "05", "13", "17", "13A", "16", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "2A", "2B", "2C", "2D", "70", "81", "82", "83", "84", "85", "86", "90", "91", "94", "EA"
                                    'MED_sort (內科): 
                                    medicalDT.DefaultView.Sort = "MED_sort"
                                Case "09"
                                    'ENT_sort (耳鼻喉): 
                                    medicalDT.DefaultView.Sort = "ENT_sort"
                                Case "08"
                                    'URO_sort (泌尿科): 
                                    medicalDT.DefaultView.Sort = "URO_sort"
                                Case "14"
                                    'REH_sort (復健): 
                                    medicalDT.DefaultView.Sort = "REH_sort"
                            End Select

                            medicalDT = medicalDT.DefaultView.ToTable()
                            g_pubMedicalTypeDT = medicalDT.Copy
                        End If
                    End If
                End Using
            End If

            '目前這個排序是針對急診以及門診收退費使用
            If SortType.Length > 0 Then
                Select Case SortType
                    Case "O"
                        medicalDT.DefaultView.Sort = "OPD_sort"
                    Case "E"
                        medicalDT.DefaultView.Sort = "EMG_sort"
                End Select
                medicalDT = medicalDT.DefaultView.ToTable()
                g_pubMedicalTypeDT = medicalDT.Copy
            End If

            cbo_medical_type_id.DataSource = medicalDT.Copy
            cbo_medical_type_id.uclDisplayIndex = "0,1"
            cbo_medical_type_id.uclValueIndex = "0"

            cbo_medical_type_id.SelectedValue = g_MedicalTypeId

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cbo_DisId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_DisId.SelectedIndexChanged
        g_DisId = ""
        If cbo_DisId.SelectedIndex > 0 Then

            g_DisId = nvl(Me.cbo_DisId.SelectedValue)
            'g_DisId = OperSet.Tables(2).Rows(cbo_DisId.SelectedIndex - 1).Item(0).ToString().Trim()

            '2010.07.12 Add by 谷官  高聯醫還要再確認是否需要此需求
            '====================
            'Select Case g_DisId
            '    Case "1"
            '        If Me.pfamKind.Length.Equals(0) Then
            '            'MessageHandling.showWarn("此人非員工，不可使用此優待")
            '            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"此人非員工，不可使用此優待"})

            '            cbo_DisId.SelectedValue = ""
            '            'ElseIf cbo_SubId.SelectedValue.Equals("17") Or cbo_SubId.SelectedValue.Equals("13") Then
            '        ElseIf cbo_SubId.SelectedValue.Equals("17") Then
            '            'MessageHandling.showWarn("此員工使用此身份，不可使用此優待")
            '            MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"此員工使用此身份，不可使用此優待"})

            '            cbo_DisId.SelectedValue = ""
            '        End If
            '    Case Else
            'End Select
            '====================

            RaiseEvent cboDisId_SelectedIndexChanged(sender, e)

        End If

    End Sub

    Private Sub cbo_Contract1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Contract1.SelectedIndexChanged

        If cbo_Contract1.SelectedIndex > 0 Then


            If cbo_Contract1.Text <> "" AndAlso cbo_Contract1.Text = cbo_Contract2.Text Then
                MessageBox.Show("合約廠商不能相同")
                cbo_Contract1.Text = ""
                g_Contract1 = ""


            ElseIf cbo_Contract1.SelectedIndex > 0 Then
                Dim s() As String = cbo_Contract1.Text.Trim().Split("-")
                If s.Length > 0 Then
                    g_Contract1 = s(0).Trim()

                End If

            End If
            RaiseEvent cboContract1_SelectedIndexChange(sender, e)

        ElseIf cbo_Contract1.SelectedIndex = 0 Then
            cbo_Contract1.Text = ""
            g_Contract1 = ""
            RaiseEvent cboContract1_SelectedIndexChange(sender, e)
        End If

    End Sub

    Private Sub cbo_Contract2_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Contract2.SelectedIndexChanged

        If cbo_Contract2.SelectedIndex > 0 Then
            '20121205 by ccr 依醫事部舜玲需求若合約一為LBR, 合約二為A012 二者位置對調
            Dim c1() As String
            Dim c2() As String
            If cbo_Contract1.SelectedIndex > 0 Then
                c1 = cbo_Contract1.Text.Trim().Split("-")
            End If
            If cbo_Contract2.SelectedIndex > 0 Then
                c2 = cbo_Contract2.Text.Trim().Split("-")
            End If
            'If c1(0).Trim() = "LBR" AndAlso c2(0).Trim = "A012" Then
            '    cbo_Contract2.Text = ""
            '    cbo_Contract1.SelectedValue = "A012"
            '    cbo_Contract2.SelectedValue = "LBR"
            'End If


            If cbo_Contract1.Text <> "" AndAlso cbo_Contract1.Text = cbo_Contract2.Text Then
                MessageBox.Show("合約廠商不能相同")
                cbo_Contract2.Text = ""
                g_Contract2 = ""

            ElseIf cbo_Contract2.SelectedIndex > 0 Then
                Dim s() As String = cbo_Contract2.Text.Trim().Split("-")
                If s.Length > 0 Then
                    g_Contract2 = s(0).Trim()
                End If
            End If
            RaiseEvent cboContract2_SelectedIndexChange(sender, e)

        ElseIf cbo_Contract2.SelectedIndex = 0 Then
            cbo_Contract2.Text = ""
            g_Contract2 = ""
            RaiseEvent cboContract2_SelectedIndexChange(sender, e)
        End If

    End Sub

    Private Sub UCLIdentityUC_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub UCLIdentityUI_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        If UCLFormUtil.isResizeable Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
            'Else
            '    Me.Height = 28
        End If

    End Sub

    ''' <summary>
    ''' 看診目的變更
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Private Sub cbo_medical_type_id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_medical_type_id.SelectedIndexChanged
        g_MedicalTypeId = nvl(Me.cbo_medical_type_id.SelectedValue)
        RaiseEvent cboMedicalTypeId_SelectedIndexChanged(sender, e)
    End Sub


#End Region


    'Public Sub Initial(ByVal MainIdObj As IdentityObj, ByVal SubIdObj As IdentityObj, ByVal DisIdObj As IdentityObj, ByVal ConObj As IdentityObj)

    '    Try
    '        g_MainId = ""
    '        g_SubId = ""
    '        g_DisId = ""
    '        g_Contract1 = ""
    '        g_Contract2 = ""
    '        g_MedicalTypeId = ""
    '        g_PartCode = ""
    '        g_CardSn = ""

    '        If OperSet Is Nothing Then
    '            OperSet = New DataSet
    '            OperSet.Tables.Add(MainIdObj.SourceDt.Copy)
    '            OperSet.Tables.Add(SubIdObj.SourceDt.Copy)
    '            OperSet.Tables.Add(DisIdObj.SourceDt.Copy)
    '            OperSet.Tables.Add(ConObj.SourceDt.Copy)

    '        End If


    '        '1.2009/07/22, modified by 谷官, 增加Enabled的屬性
    '        'cbo_MainId.Enabled = False

    '        'cbo_MainId.DataSource = CType(OperSet.Tables(0), DataTable).Copy
    '        'cbo_MainId.uclDisplayIndex = "0,1"
    '        'cbo_MainId.uclValueIndex = "0"

    '        cbo_MainId.Initial(OperSet.Tables(0).Copy, MainIdObj.DisplayIndex, MainIdObj.ValueIndex)



    '        'cbo_SubId.DataSource = CType(OperSet.Tables(1), DataTable).Copy
    '        'cbo_SubId.uclDisplayIndex = "0,2"
    '        'cbo_SubId.uclValueIndex = "0"

    '        cbo_SubId.Initial(OperSet.Tables(1).Copy, SubIdObj.DisplayIndex, SubIdObj.ValueIndex)


    '        'cbo_DisId.DataSource = CType(OperSet.Tables(2), DataTable).Copy
    '        'cbo_DisId.uclDisplayIndex = "0,1"
    '        'cbo_DisId.uclValueIndex = "0"

    '        cbo_DisId.Initial(OperSet.Tables(2).Copy, DisIdObj.DisplayIndex, DisIdObj.ValueIndex)

    '        '3.2010/05/11, add by 谷官, 身份2為""時也需帶出合約資料
    '        setContractSourceData("")

    '    Catch ex As Exception
    '        Console.WriteLine(ex.ToString)   'Console.WriteLine(ex.ToString)
    '    End Try
    'End Sub











#End Region




End Class
