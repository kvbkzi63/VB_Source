Imports Syscom.Client.servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class UCLComboBoxGridUC




#Region "     全域變數宣告"


    ' Dim WithEvents ReceiveGridValueMgr As EventManager = EventManager.getInstance '宣告EventManager


    Private _ComboBoxText As String = ""

    Private _uclCboDataSource As DataTable = New DataTable()
    Private _SelectedValue As String = ""
    Private _SelectedText As String = ""
    Private _BackColor As Color
    Private _DropDownWidth As Integer = 20
    Private _uclDisplayIndex As String = "0,1"
    Private _uclValueIndex As String = "0"
    Private _uclShowMsg As Boolean = False
    Private _uclHeaderText As String = ""
    Private _uclColumnWidth As String = ""

    Private _uclGridHeight As Integer = 0
    Private _uclGridWidth As Integer = 0
    Private _uclStartQueryLength As Integer = 2
    Private _uclDiseaseTypeId As DiseaseTypeIdData = DiseaseTypeIdData.None
    Private _uclMultiDiseaseTypeId As String = ""
    Private _uclMultiOrderTypeId As String = ""

    Private _uclCtlName As String = Me.Name
    Private _uclOrderTypeId As OrderTypeIdData = OrderTypeIdData.None
    Private _DropDownStyle As System.Windows.Forms.ComboBoxStyle = ComboBoxStyle.DropDown
    Private _Items As System.Windows.Forms.ComboBox.ObjectCollection
    Private _uclNonVisibleColIndex As String
    Private _uclVisibleColIndex As String

    Private _uclBasicDateStr As String
    Private _uclIsPriorReview As String
    Private _uclQueryType As By = By.Code
    Private IsMultiSelect As Boolean = False
    Private _uclQueryData As Data = Data.PUB_Disease_IcdCode
    Dim pvtCheckFlag = False

    Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Shadows Event Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)

    Dim WithEvents ReceiveGridValueMgr As EventManager = EventManager.getInstance

    Private _Text As String

    Private _uclConnDBType As DBType = DBType.LocalAccess

    Dim pvtDS1 As DataSet = Nothing 'from SQL Server
    Dim pvtDS2 As New DataSet ' = Nothing 'local 

    Dim ucl As IUclServiceManager = UclServiceManager.getInstance

    Dim log As LOGDelegate = LOGDelegate.getInstance

    Public searchKey As String = ""
    Public hideGrid As Boolean = False
    ' Dim dgv As UCLDataGridViewUI
    Public dgv As New UCLComboBoxGridOpenWindowUC()

    '用在datagridview的ComboBoxGrid
    Dim cbo_dgv As UCLDataGridViewUC = Nothing

    Dim dsDB As DataSet = Nothing
    Dim dsGrid As DataSet = Nothing

    Dim cellRowIndex, cellColIndex As Integer
    '用在datagridview的Cell剛進Combox時
    Public FirstEnterGridCell As Boolean = False

    Dim TreeGridCol As Integer = 0

    Dim _uclIsTextBoxType As Boolean = False
    Private _uclEffectiveMode As Boolean = False
    Private _uclIsFreeText As Boolean = False


    Private _uclDoTextChanged As Boolean = True


    'test
    'Dim connStr As String = "Server=K5-849308-NB\SQLEXPRESS;database=nckuhDB;uid=sa;pwd=;"

    ' Dim sqlConn As SqlConnection

    Private connStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\nckuhDB.mdb"
    Private _uclIsComboBoxGridQuery As Boolean = True '化療藥ComboBoxGrid <=> ComboBox

    Private _uclEmpCode As String = ""
    Private _uclDepCode As String = ""

    Private _uclSource As DBSource = DBSource.O

    Private _uclIsOPD As OEIData = OEIData.Y
    Private _uclIsEPD As OEIData = OEIData.Y
    Private _uclIsIPD As OEIData = OEIData.Y


    Private _uclIsEqualMatch As EqualMatchData = EqualMatchData.N
    Private _uclIsCheckPubOrderDc As PubOrderDcData = PubOrderDcData.Y
    Private _IcdType As IcdTypeData = IcdTypeData.Icd9
    Private _IsAllowIcd9Empty As YNData = YNData.Y
    Private _IsAllowIcd10Empty As YNData = YNData.Y
    Private _Is_ChemoDrug As YNData = YNData.N
    Private _Is_AllChemoDrug As YNData = YNData.N

    Private _IsCanSelectDcOrder As YNData = YNData.Y

    Private IsUseFreeText As Boolean = False
    Private _IsLocalQuery As Boolean = False

    Private LocalDataSet As DataSet

#End Region
#Region "     屬性設定 "

    Enum Data
        OPH_Pharmacy_Base_OnlyName = 0 '使用於輸入藥品代碼回傳藥名
        PUB_Disease_IcdCode = 1 '醫囑診斷

        OPH_Pharmacy_Base_Normal = 2   '一般藥品
        OPH_Pharmacy_Base_Chemo = 3   '化療藥品
        OPH_Pharmacy_Base_TPN = 4   'TPN藥品
        OPH_Pharmacy_Base_Vaccine = 5   '疫苗接種藥品
        PUB_Order = 6                    'PUB_Order
        PUB_Order_Material = 7   '醫令 -衛材
        PUB_Order_Cure = 8   '醫令 -治療處置
        PUB_Order_Often = 9   '醫令 -常用處置維護
        PUB_Order_DepOftenH = 10   ' 醫令 -科常用醫令 (For EMR)
        PUB_Order_Examine = 11   ' 醫令 -檢驗檢查
        PUB_Order_Operation = 12   ' 醫令 -手術法
        OPH_Pharmacy_Base_TPNAndNormal = 13   'TPN 一般藥品
        OPH_Pharmacy_Base_ChemoAndNormal = 14   'Chemo 一般藥品


        PUB_Disease_IsSevereDisease = 15 '醫囑診斷-重傷ICD
        PUB_Order_InsuCode = 16   ' 醫令 -成大碼轉健保碼

        OMO_Chemo_Dilute_Map = 17 '化療藥 稀釋

        OPH_Pharmacy_Base_TPNAdd = 18   'TPN 添加藥品
        Nut_Recipe = 19   '19 
        Nut_Diet_Type = 20   '20
        Nut_Recipe_Compose_Detail = 21   '21 
        Sysblood = 22
        STA_Package = 23
        IHD_Appeal_Dispute_Reason = 24
        PTW_Clinical_Path = 25
        OPH_Pharmacy_Base_Chemo_For_IMO_Package_Chemo = 26   '化療藥品 住院套裝
        OPH_Pharmacy_Base_Normal_Combine = 27   '一般藥品 整合Name Code
        PUB_Order_Examine_Combine = 28   ' 醫令 -檢驗檢查整合  Code

        OPH_Pharmacy_Base_Chemo_Combine = 29   '化療藥品
        OPH_Pharmacy_Base_TPN_Combine = 30   'TPN藥品
        OPH_Pharmacy_Base_TPNAndNormal_Combine = 31   'TPN 一般藥品
        OPH_Pharmacy_Base_ChemoAndNormal_Combine = 32   'Chemo 一般藥品
        OPH_Pharmacy_Base_TPNAdd_Combine = 33

        PUB_Order_Mixed = 35 '混合開立
        PUB_Order_Insu = 36   ' 醫令 -取得健保碼
    End Enum

    Enum OrderTypeIdData
        None = 0
        E = 1 '藥品  
        D = 2 '-共通性處置(行政類醫令) 
        G = 3 '-衛材 
        H = 4 '-檢驗檢查 
        J = 5 '-手術    
        K = 6 ':麻醉  
        I = 7 '-健保申報用
        NckuCode = 8 '成大碼轉健保碼
    End Enum

    Enum DiseaseTypeIdData
        None = 0
        OutHospital = 1
        Operation = 2
        Accident = 3
        Tumour = 4
    End Enum
    Enum By
        Code = 1
        Name = 2
    End Enum

    Enum DBType
        RemoteSqlServer = 0
        LocalAccess = 1
        RemoteThenLocal = 2
        LocalThenRemote = 3
        NonQuery = 4
    End Enum

    Enum OEIData
        N = 0
        Y = 1
        C = 2
        H = 3
    End Enum

    Enum EqualMatchData
        N = 0
        Y = 1

    End Enum

    Enum PubOrderDcData
        N = 0
        Y = 1

    End Enum

    Enum DBSource
        O = 0
        E = 1
        I = 2
        All = 3
    End Enum

    Enum IcdTypeData
        Icd9 = 0
        Icd10 = 1
        OnlyIcd9 = 2
        OnlyIcd10 = 3
    End Enum

    Enum YNData
        N = 0
        Y = 1

    End Enum


    Public Property uclSource() As DBSource
        Get
            Return _uclSource
        End Get
        Set(ByVal value As DBSource)
            _uclSource = value
        End Set
    End Property

    Public Property uclIsCheckPubOrderDc() As PubOrderDcData
        Get
            Return _uclIsCheckPubOrderDc
        End Get
        Set(ByVal value As PubOrderDcData)
            _uclIsCheckPubOrderDc = value
        End Set
    End Property

    Public Property uclIsEqualMatch() As EqualMatchData
        Get
            Return _uclIsEqualMatch
        End Get
        Set(ByVal value As EqualMatchData)
            _uclIsEqualMatch = value
        End Set
    End Property

    Public Property uclIsOPD() As OEIData
        Get
            Return _uclIsOPD
        End Get
        Set(ByVal value As OEIData)
            _uclIsOPD = value
        End Set
    End Property


    Public Property uclIsEPD() As OEIData
        Get
            Return _uclIsEPD
        End Get
        Set(ByVal value As OEIData)
            _uclIsEPD = value
        End Set
    End Property

    Public Property uclIsIPD() As OEIData
        Get
            Return _uclIsIPD
        End Get
        Set(ByVal value As OEIData)
            _uclIsIPD = value
        End Set
    End Property


    Public Property IcdType() As IcdTypeData
        Get
            Return _IcdType
        End Get
        Set(ByVal value As IcdTypeData)
            _IcdType = value
        End Set
    End Property

    Public Property IsAllowIcd9Empty() As YNData
        Get
            Return _IsAllowIcd9Empty
        End Get
        Set(ByVal value As YNData)
            _IsAllowIcd9Empty = value
        End Set
    End Property

    Public Property IsAllowIcd10Empty() As YNData
        Get
            Return _IsAllowIcd10Empty
        End Get
        Set(ByVal value As YNData)
            _IsAllowIcd10Empty = value
        End Set
    End Property

    Public Property IsCanSelectDcOrder() As YNData
        Get
            Return _IsCanSelectDcOrder
        End Get
        Set(ByVal value As YNData)
            _IsCanSelectDcOrder = value
        End Set
    End Property

    Public Property Is_AllChemoDrug() As YNData
        Get
            Return _Is_AllChemoDrug
        End Get
        Set(ByVal value As YNData)
            _Is_AllChemoDrug = value
        End Set
    End Property

    Public Property Is_ChemoDrug() As YNData
        Get
            Return _Is_ChemoDrug
        End Get
        Set(ByVal value As YNData)
            _Is_ChemoDrug = value
        End Set
    End Property

    Public Property uclIsPriorReview() As String
        Get
            Return _uclIsPriorReview
        End Get
        Set(ByVal value As String)
            _uclIsPriorReview = value

        End Set
    End Property


    Public Property uclEmpCode() As String
        Get
            Return _uclEmpCode
        End Get
        Set(ByVal value As String)
            _uclEmpCode = value

        End Set
    End Property

    Public Property uclDepCode() As String
        Get
            Return _uclDepCode
        End Get
        Set(ByVal value As String)
            _uclDepCode = value

        End Set
    End Property


    Public Property IsLocalQuery() As Boolean
        Get
            Return _IsLocalQuery
        End Get
        Set(ByVal value As Boolean)
            _IsLocalQuery = value
        End Set
    End Property

    Public Property uclIsTextBoxType() As Boolean
        Get
            Return _uclIsTextBoxType
        End Get
        Set(ByVal value As Boolean)
            _uclIsTextBoxType = value
        End Set
    End Property

    Public Property uclEffectiveMode() As Boolean
        Get
            Return _uclEffectiveMode
        End Get
        Set(ByVal value As Boolean)
            _uclEffectiveMode = value
        End Set
    End Property

    Public Property uclIsFreeText() As Boolean
        Get
            Return _uclIsFreeText
        End Get
        Set(ByVal value As Boolean)
            _uclIsFreeText = value
        End Set
    End Property

    Public Property uclIsComboBoxGridQuery() As Boolean
        Get
            Return _uclIsComboBoxGridQuery
        End Get
        Set(ByVal value As Boolean)
            _uclIsComboBoxGridQuery = value
        End Set
    End Property

    Public Property uclDoTextChanged() As Boolean
        Get
            Return _uclDoTextChanged
        End Get
        Set(ByVal value As Boolean)
            _uclDoTextChanged = value
        End Set
    End Property

    Public Property uclBasicDateStr() As String
        Get
            Return _uclBasicDateStr
        End Get
        Set(ByVal value As String)
            _uclBasicDateStr = value
        End Set
    End Property


    Public Property uclCtlName() As String
        Get
            Return _uclCtlName
        End Get
        Set(ByVal value As String)
            _uclCtlName = value
        End Set
    End Property

    Public Property uclMultiDiseaseTypeId() As String
        Get
            Return _uclMultiDiseaseTypeId
        End Get
        Set(ByVal value As String)
            _uclMultiDiseaseTypeId = value
        End Set
    End Property

    Public Property uclMultiOrderTypeId() As String
        Get
            Return _uclMultiOrderTypeId
        End Get
        Set(ByVal value As String)
            _uclMultiOrderTypeId = value
        End Set
    End Property

    Public Property uclOrderTypeId() As OrderTypeIdData
        Get
            Return _uclOrderTypeId
        End Get
        Set(ByVal value As OrderTypeIdData)
            _uclOrderTypeId = value
        End Set
    End Property


    Public Property uclDiseaseTypeId() As DiseaseTypeIdData
        Get
            Return _uclDiseaseTypeId
        End Get
        Set(ByVal value As DiseaseTypeIdData)
            _uclDiseaseTypeId = value
        End Set
    End Property

    Public Property uclConnStr() As String
        Get
            Return connStr
        End Get
        Set(ByVal value As String)
            connStr = value
        End Set
    End Property

    Public Property uclHeaderText() As String
        Get
            Return _uclHeaderText
        End Get
        Set(ByVal value As String)
            _uclHeaderText = value
        End Set
    End Property


    Public Property uclColumnWidth() As String
        Get
            Return _uclColumnWidth
        End Get
        Set(ByVal value As String)
            _uclColumnWidth = value
        End Set
    End Property

    Public Property uclStartQueryLength() As Integer
        Get
            Return _uclStartQueryLength
        End Get
        Set(ByVal value As Integer)
            _uclStartQueryLength = value
        End Set
    End Property

    Public Property uclGridWidth() As Integer
        Get
            Return _uclGridWidth
        End Get
        Set(ByVal value As Integer)
            _uclGridWidth = value
        End Set
    End Property

    Public Property uclGridHeight() As Integer
        Get
            Return _uclGridHeight
        End Get
        Set(ByVal value As Integer)
            _uclGridHeight = value
        End Set
    End Property

    Public Property uclConnDBType() As DBType
        Get
            Return _uclConnDBType
        End Get
        Set(ByVal value As DBType)
            _uclConnDBType = value
        End Set
    End Property

    Public Property uclQueryType() As By
        Get
            Return _uclQueryType
        End Get
        Set(ByVal value As By)
            _uclQueryType = value
        End Set
    End Property

    Public Property uclQueryData() As Data
        Get
            Return _uclQueryData
        End Get
        Set(ByVal value As Data)
            _uclQueryData = value
        End Set


    End Property

    Public ReadOnly Property Items() As System.Windows.Forms.ComboBox.ObjectCollection
        Get
            Return ComboBox1.Items
        End Get

    End Property


    Public Overrides Property Text() As String
        Get
            Return ComboBox1.Text


        End Get
        Set(ByVal value As String)
            ComboBox1.Text = value
        End Set
    End Property

    Public Property DropDownStyle() As System.Windows.Forms.ComboBoxStyle
        Get
            Return ComboBox1.DropDownStyle
        End Get
        Set(ByVal value As System.Windows.Forms.ComboBoxStyle)
            ComboBox1.DropDownStyle = value
        End Set
    End Property


    Public Property uclCboDataSource() As DataTable
        Get
            Return _uclCboDataSource

        End Get
        Set(ByVal value As DataTable)
            If value IsNot Nothing Then
                _uclCboDataSource = value
                ComboBox1.DataSource = value
                ComboBox1.SelectedIndex = 0
                SetComboField(_uclCboDataSource, "ValueField", _uclValueIndex)
                ComboBox1.ValueMember = "ValueField"
            Else
                ComboBox1.DataSource = Nothing
            End If
        End Set
    End Property


    Public Property SelectedValue() As String
        Get
            Return _SelectedValue
        End Get
        Set(ByVal value As String)
            _SelectedValue = value

            ComboBox1.SelectedValue = _SelectedValue

            If value = "" Then
                ComboBox1.Text = ""
            End If
        End Set
    End Property
    Public Property SelectedText() As String
        Get
            Return _SelectedText
        End Get
        Set(ByVal value As String)
            _SelectedText = value

            ComboBox1.SelectedText = _SelectedText
            pvtCheckFlag = False
        End Set
    End Property
    Public Overrides Property BackColor() As Color
        Get
            Return ComboBox1.BackColor
        End Get
        Set(ByVal value As Color)
            ComboBox1.BackColor = value
        End Set
    End Property
    Public Property DropDownWidth() As Integer
        Get
            Return _DropDownWidth
        End Get
        Set(ByVal value As Integer)
            _DropDownWidth = value
            ComboBox1.DropDownWidth = _DropDownWidth
        End Set
    End Property

    '設定要顯示的欄位Index(預設為0,1=>代碼與名稱)
    Public Property uclDisplayIndex() As String
        Get
            Return _uclDisplayIndex
        End Get
        Set(ByVal value As String)
            _uclDisplayIndex = value

        End Set
    End Property


    '設定要選取值的欄位Index(預設為0=>代碼)
    Public Property uclValueIndex() As String
        Get
            Return _uclValueIndex
        End Get
        Set(ByVal value As String)
            _uclValueIndex = value


        End Set
    End Property


    Public Property uclNonVisibleColIndex() As String
        Get
            Return _uclNonVisibleColIndex
        End Get
        Set(ByVal value As String)
            _uclNonVisibleColIndex = value
        End Set
    End Property

    Public Property uclVisibleColIndex() As String
        Get
            Return _uclVisibleColIndex
        End Get
        Set(ByVal value As String)
            _uclVisibleColIndex = value
        End Set
    End Property


    '設定要顯示訊息(預設為false)
    Public Property uclShowMsg() As Boolean
        Get
            Return _uclShowMsg
        End Get
        Set(ByVal value As Boolean)
            _uclShowMsg = value
        End Set
    End Property


#End Region
#Region "     主要功能 "

    Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

    End Sub

    ''' <summary>
    '''  取得隨輸隨選的GridView
    ''' </summary>
    ''' <returns>none</returns>
    ''' <remarks></remarks>''' 
    Public Function GetGridForm() As System.Windows.Forms.Form
        Return dgv
    End Function

    ''' <summary>
    '''  隱藏隨輸隨選元件
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetBothNonVisible()
        Me.Visible = False
        If dgv IsNot Nothing Then
            dgv.Visible = False
        End If

    End Sub

    ''' <summary>
    '''  設定下拉選項值顯示欄位內容與選取值對應欄位
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetComboField(ByVal pvtTable As DataTable, ByVal pvtColumnName As String, ByVal pvtCutStr As String)
        Try

            If Not pvtTable.Columns.Contains(pvtColumnName) Then
                Dim pvtColumn As DataColumn = pvtTable.Columns.Add(pvtColumnName)
            End If

            Dim pvtArrayList As ArrayList = CutString(pvtCutStr, ",")
            For i = 0 To pvtTable.Rows.Count - 1

                For j = 0 To pvtArrayList.Count - 1

                    If j = 0 Then

                        pvtTable.Rows(i).Item(pvtColumnName) = pvtTable.Rows(i).Item(Integer.Parse(pvtArrayList.Item(j).ToString)).ToString().Trim()
                    Else
                        pvtTable.Rows(i).Item(pvtColumnName) += " - " & pvtTable.Rows(i).Item(Integer.Parse(pvtArrayList.Item(j).ToString)).ToString().Trim()

                    End If

                Next
            Next
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    '''  字串處理
    ''' pvtStr:處理的字串
    ''' pvtCutSysbol:處理的符號
    ''' </summary>
    ''' <returns>處理後的字串陣列</returns>
    ''' <remarks></remarks>''' 
    Public Function CutString(ByVal pvtStr As String, ByVal pvtCutSysbol As String) As ArrayList
        Dim pvtListData As ArrayList = New ArrayList()
        Dim pvtCount As Integer = 0
        Dim pvtCutStr As String = ""

        Do
            pvtCount = pvtStr.IndexOf(pvtCutSysbol)
            If (pvtCount > 0) Then
                pvtCutStr = pvtStr.Substring(0, pvtCount)
                pvtStr = pvtStr.Substring(pvtCount + 1)
            Else
                pvtCutStr = pvtStr
            End If
            pvtListData.Add(pvtCutStr)
        Loop While pvtCount > 0

        Return pvtListData
    End Function

    ''' <summary>
    ''' 按下Enter時進行的動作
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub cellPressEnter()
        If cbo_dgv IsNot Nothing Then
            If Not dgv.Visible Then
                queryAction(False)
            End If
        End If

    End Sub

    ''' <summary>
    ''' 隨輸隨選查詢
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub queryAction(ByVal IsEqualMatch As Boolean)

        Try
            If Not cbo_dgv.uclIsDoQueryComboBoxGrid Then
                '不進行查詢, 正在處理發出去的Event 避免按到Enter
                Exit Sub
            End If

            If Not uclIsComboBoxGridQuery Then

                dgv.SetGridVisible(False)
                Dim t As New DataTable
                t.Columns.Add()
                t.Columns.Add()
                t.Rows.Add()


                t.Rows(0).Item(0) = "ComboBoxType"
                t.Rows(0).Item(1) = ComboBox1.Text
                dgv.getGridView.DataSource = t.Copy
                If ReceiveGridValueMgr Is Nothing Then
                    ReceiveGridValueMgr = EventManager.getInstance
                End If
                ReceiveGridValueMgr.RaiseUclOpenWindowComboBoxGridValue(uclCtlName, cellRowIndex, cellColIndex, dgv.getGridView.Rows(0))
                Exit Sub

            End If

            If uclSource = DBSource.I AndAlso IsLocalQuery Then
                If LocalDataSet IsNot Nothing AndAlso LocalDataSet.Tables.Count > 0 Then
                    searchKey = ComboBox1.Text
                    If pvtDS1 Is Nothing Then
                        pvtDS1 = New DataSet
                    End If

                    pvtDS1.Tables.Clear()
                    pvtDS1.Tables.Add(LocalDataSet.Tables(0).Copy)
                    pvtDS2.Tables.Clear()
                    pvtDS2.Tables.Add(pvtDS1.Tables(0).Clone)
                End If
            End If

            If ComboBox1.Text.Length >= uclStartQueryLength AndAlso ComboBox1.Text.Trim <> "" AndAlso Not IsLocalQuery Then 'AndAlso ComboBox1.Text.ToUpper() <> searchKey.ToUpper() Then
                searchKey = ComboBox1.Text.Replace("'", "''")

                If uclSource = DBSource.O Then
                    pvtDS1 = SelectConnDBForOEI(IsEqualMatch) 'SelectConnDB()

                ElseIf uclSource = DBSource.E Then

                    pvtDS1 = SelectConnDBForOEI(IsEqualMatch)

                ElseIf uclSource = DBSource.I Then

                    pvtDS1 = SelectConnDBForOEI(IsEqualMatch)

                End If


                If pvtDS1 IsNot Nothing AndAlso pvtDS1.Tables(0).Rows.Count > 1 Then

                    IsUseFreeText = False

                    If dgv.uclHeaderText.Trim = "" AndAlso uclHeaderText.Trim <> "" OrElse (dgv.uclHeaderText.Trim <> uclHeaderText.Trim) Then
                        dgv.uclHeaderText = uclHeaderText
                    End If

                    If dgv.uclColumnWidth.Trim = "" AndAlso uclColumnWidth.Trim <> "" OrElse (dgv.uclColumnWidth.Trim <> uclColumnWidth.Trim) Then
                        dgv.uclColumnWidth = uclColumnWidth
                    End If


                    '設定隱藏的column  要放在 dgv.show 後面 ,否則沒辦法隱藏
                    '_uclNonVisibleColIndex ="0,1,2,3,4,9,10,11,12"
                    dgv.uclNonVisibleColIndex = _uclNonVisibleColIndex

                    dgv.uclVisibleColIndex = _uclVisibleColIndex

                    dgv.Initial(uclCtlName, pvtDS1, cellColIndex, cellRowIndex, cbo_dgv)

                    _uclCboDataSource = pvtDS1.Tables(0)



                    dgv.SetNonVisibleCol()

                    dgv.SetGridVisible(True)
                    dgv.ProcessDrugColor(uclSource)

                    'Dim ScreenPos As Point = Me.PointToScreen(New Point(0, 0))
                    'dgv.Left = ScreenPos.X
                    'dgv.Top = ScreenPos.Y + Me.Height



                    If _uclGridWidth > 0 Then
                        dgv.Width = _uclGridWidth
                    Else
                        dgv.Width = Me.Width
                    End If


                    If _uclGridHeight > 0 Then
                        dgv.Height = _uclGridHeight
                    Else
                        dgv.Height = 200
                    End If


                    dgv.Show()
                    SetTextBoxFocused()

                    If pvtDS2.Tables.Count > 0 Then
                        pvtDS2.Tables.RemoveAt(0)
                        pvtDS2.Tables.Add(pvtDS1.Tables(0).Clone())
                    Else
                        pvtDS2.Tables.Add(pvtDS1.Tables(0).Clone())
                    End If

                    pvtDS2.Tables(0).Rows.Clear()
                    dgv.cbo_dgv.ClearSelection()

                ElseIf pvtDS1 IsNot Nothing AndAlso pvtDS1.Tables(0).Rows.Count = 1 Then

                    IsUseFreeText = False
                    'Dim code As String = pvtDS1.Tables(0).Rows(0).Item(CInt(_uclValueIndex))
                    'Dim name As String = pvtDS1.Tables(0).Rows(0).Item(CInt(_uclDisplayIndex))
                    Dim CanSetOrderData As Boolean = True

                    'If Not IsCanSelectDcOrder Then
                    '    If pvtDS1.Tables(0).Columns.Contains("DC") AndAlso pvtDS1.Tables(0).Rows(0).Item("DC").ToString.ToUpper.Trim = "Y" Then
                    '        CanSetOrderData = False
                    '    End If
                    'End If

                    If CanSetOrderData Then
                        dgv.Initial(uclCtlName, pvtDS1, cellColIndex, cellRowIndex, cbo_dgv)
                        dgv.Visible = False
                        If ReceiveGridValueMgr Is Nothing Then
                            ReceiveGridValueMgr = EventManager.getInstance
                        End If
                        ReceiveGridValueMgr.RaiseUclOpenWindowComboBoxGridValue(uclCtlName, cellRowIndex, cellColIndex, dgv.getGridView.Rows(0))
                    Else
                        dgv.Visible = False
                    End If

                Else
                    IsUseFreeText = True
                    '找不到符合的資料
                    'MessageBox.Show("找不到符合的資料")
                    'MessageHandling.showInfo("找不到符合的資料")
                    dgv.Visible = False

                End If

            ElseIf pvtDS1 IsNot Nothing AndAlso ComboBox1.Text.Length >= uclStartQueryLength AndAlso ComboBox1.Text.Substring(0, uclStartQueryLength) = searchKey Then



                pvtDS2.Tables(0).Rows.Clear()

                For i As Integer = 0 To pvtDS1.Tables(0).Rows.Count - 1

                    If Not _uclValueIndex.Contains(",") Then

                        If uclSource = DBSource.I AndAlso IsLocalQuery Then
                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(_uclValueIndex)).ToString().Length Then

                                If pvtDS1.Tables(0).Rows(i).Item(CInt(_uclValueIndex)).ToString().Substring(0, ComboBox1.Text.Length).Trim().ToUpper() = ComboBox1.Text.Trim.ToUpper() Then
                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                            If pvtDS2.Tables(0).Rows.Count > 0 Then
                                If _uclGridWidth > 0 Then
                                    dgv.Width = _uclGridWidth
                                Else
                                    dgv.Width = Me.Width
                                End If


                                If _uclGridHeight > 0 Then
                                    dgv.Height = _uclGridHeight
                                Else
                                    dgv.Height = 200
                                End If


                                'dgv.Show()
                                SetTextBoxFocused()

                                '設定隱藏的column  要放在 dgv.show 後面 ,否則沒辦法隱藏
                                '_uclNonVisibleColIndex ="0,1,2,3,4,9,10,11,12"
                                dgv.uclNonVisibleColIndex = _uclNonVisibleColIndex

                                dgv.uclVisibleColIndex = _uclVisibleColIndex
                                dgv.uclHeaderText = _uclHeaderText
                                dgv.uclColumnWidth = _uclColumnWidth

                            End If

                        Else
                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(_uclValueIndex)).ToString().Length Then

                                If pvtDS1.Tables(0).Rows(i).Item(CInt(_uclValueIndex)).ToString().Substring(0, ComboBox1.Text.Length).Trim().ToUpper() = ComboBox1.Text.ToUpper() Then
                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If
                        End If


                    Else

                        If uclQueryData = Data.OPH_Pharmacy_Base_Normal Then
                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length Then

                                If pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.OPH_Pharmacy_Base_Normal_Combine Then

                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length Then

                                If pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.OPH_Pharmacy_Base_Chemo_Combine Then

                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length Then

                                If pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.OPH_Pharmacy_Base_ChemoAndNormal_Combine Then

                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length Then

                                If pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.OPH_Pharmacy_Base_TPN_Combine Then

                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length Then

                                If pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.OPH_Pharmacy_Base_TPNAndNormal_Combine Then

                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length Then

                                If pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.OPH_Pharmacy_Base_TPNAdd_Combine Then

                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length Then

                                If pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.PUB_Order_Examine_Combine Then
                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length Then

                                If pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() OrElse pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If


                        End If

                    End If


                Next

                '  ComboBox1.DataSource = pvtDS2.Tables(0)
                dgv.Initial(uclCtlName, pvtDS2, cellColIndex, cellRowIndex, cbo_dgv)


                If pvtDS2.Tables(0).Rows.Count > 1 Then
                    dgv.SetGridVisible(True)
                    dgv.Visible = True
                    dgv.ProcessDrugColor(uclSource)
                ElseIf pvtDS2.Tables(0).Rows.Count = 1 Then
                    'Dim code As String = pvtDS2.Tables(0).Rows(0).Item(CInt(_uclValueIndex))
                    'Dim name As String = pvtDS2.Tables(0).Rows(0).Item(CInt(_uclDisplayIndex))

                    'ComboBox1.Text = name.Trim()

                    'If dsDB IsNot Nothing AndAlso dsGrid IsNot Nothing Then
                    '    dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex) = code.Trim()
                    '    dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex) = name.Trim()
                    'End If

                    dgv.Initial(uclCtlName, pvtDS2, cellColIndex, cellRowIndex, cbo_dgv)
                    dgv.Visible = False
                    If ReceiveGridValueMgr Is Nothing Then
                        ReceiveGridValueMgr = EventManager.getInstance
                    End If
                    ReceiveGridValueMgr.RaiseUclOpenWindowComboBoxGridValue(uclCtlName, cellRowIndex, cellColIndex, dgv.getGridView.Rows(0))


                Else

                    dgv.Visible = False
                End If

                '  SetTextBoxFocused()

            ElseIf pvtDS1 IsNot Nothing AndAlso ComboBox1.Text.Length < uclStartQueryLength Then
                dgv.SetGridVisible(False)
            End If

            ' pvtCheckFlag = True


            ' Console.WriteLine(dgv.Visible.ToString)
            dgv.AutoAdjust()

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' SQL Server查詢
    ''' </summary>
    ''' <returns>查詢到的資料</returns>
    ''' <remarks></remarks>''' 
    Private Function SelectConnDB() As DataSet
        Try

            Dim IsEqualMatch As String = "N"
            Dim BasicDateStr As String = ""

            If uclIsEqualMatch = EqualMatchData.Y Then
                IsEqualMatch = "Y"
                BasicDateStr = "EqualMatch"
            End If

            Select Case _uclConnDBType

                Case DBType.LocalAccess

                    If _uclQueryType = By.Code Then
                        Return queryOMOFavorByFavorId("1", "D001", "E", "001", searchKey.Trim, "")
                    Else
                        Return queryOMOFavorByFavorId("1", "D001", "E", "001", "", searchKey.Trim)
                    End If

                Case DBType.RemoteSqlServer
                    Return Nothing
                Case DBType.LocalThenRemote
                    Return Nothing
                Case DBType.RemoteThenLocal
                    Return Nothing
                Case Else
                    Return Nothing
            End Select
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function


    Private Function GetDiseaseTypeId() As String
        If uclDiseaseTypeId = DiseaseTypeIdData.None Then
            Return ""
        ElseIf uclDiseaseTypeId = DiseaseTypeIdData.OutHospital Then
            Return "'1'"
        ElseIf uclDiseaseTypeId = DiseaseTypeIdData.Operation Then
            Return "'2'"
        ElseIf uclDiseaseTypeId = DiseaseTypeIdData.Accident Then
            Return "'3'"
        ElseIf uclDiseaseTypeId = DiseaseTypeIdData.Tumour Then
            Return "'4'"
        Else
            Return ""
        End If
    End Function

    Private Function GetOrderTypeId() As String
        If uclOrderTypeId = OrderTypeIdData.None Then
            Return ""
        ElseIf uclOrderTypeId = OrderTypeIdData.E Then
            Return "E"
        ElseIf uclOrderTypeId = OrderTypeIdData.D Then
            Return "D"
        ElseIf uclOrderTypeId = OrderTypeIdData.G Then
            Return "G"
        ElseIf uclOrderTypeId = OrderTypeIdData.H Then
            Return "H"
        ElseIf uclOrderTypeId = OrderTypeIdData.J Then
            Return "J"
        ElseIf uclOrderTypeId = OrderTypeIdData.K Then
            Return "K"
        ElseIf uclOrderTypeId = OrderTypeIdData.I Then
            Return "I"
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' local access db
    ''' </summary>
    ''' <returns>none</returns>
    ''' <remarks></remarks>''' 
    Public Function queryOMOFavorByFavorId(ByVal favorId As String, _
                                          ByVal doctorDeptCode As String, _
                                          ByVal favorTypeId As String, _
                                          ByVal favorCategory As String, _
                                          ByVal code As String, _
                                          ByVal codeName As String _
                                        ) As DataSet


        Try

            Dim ds As DataSet
            Dim sqlconn As OleDbConnection = New OleDbConnection(connStr)
            '  sqlConn = New SqlConnection(connStr)
            sqlconn.Open()
            Dim sqlStr As String = ""
            If code <> "" Then
                sqlStr = " Select *  " & _
                                      " From  OMO_Favor " & _
                                      " Where  DC<>'Y' And Order_Code like  '" & code & "%'" & _
                                      " Order By Order_Code"
            ElseIf codeName <> "" Then
                sqlStr = " Select *  " & _
                                      " From  OMO_Favor " & _
                                      " Where  DC<>'Y' And Favor_Name like  '" & codeName & "%'" & _
                                      " Order By Order_Code"
            End If

            Dim command As OleDbCommand = New OleDbCommand(sqlStr, sqlconn)

            Using adapter As OleDbDataAdapter = New OleDbDataAdapter(command)
                ds = New DataSet("OMO_Favor")
                adapter.Fill(ds, "OMO_Favor")
                adapter.FillSchema(ds, SchemaType.Mapped, "OMO_Favor")
            End Using
            sqlconn.Close()
            Return ds


        Catch ex As Exception
            Throw ex
        End Try


    End Function


    Public Sub SetTextBoxFocused()
        ComboBox1.Focus()
        ComboBox1.SelectionStart = ComboBox1.Text.Length
    End Sub

    ''' <summary>
    ''' 初始化Cell設定
    ''' grid:Parent  DataGridView
    ''' dDB:DB來源資料
    ''' dGrid:Grid來源資料
    ''' MultiSelect:GridView是否具多選
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitialComboBoxGridCell(ByRef grid As UCLDataGridViewUC, ByRef dDB As DataSet, ByRef dGrid As DataSet, ByVal MultiSelect As Boolean)

        cbo_dgv = grid
        cellRowIndex = cbo_dgv.dgv.CurrentCell.RowIndex
        cellColIndex = cbo_dgv.dgv.CurrentCell.ColumnIndex

        IsMultiSelect = MultiSelect
        dsDB = dDB
        dsGrid = dGrid


    End Sub


    'Public Sub Initial(ByRef grid As UCLDataGridViewUI)


    '    'dgv = grid
    '    'dgv.Visible = False
    '    'dgv.addPartnerCbo(Me)
    '    'pvtDS2 = New DataSet

    'End Sub


    'Private Sub ReceiveGridValue(ByVal CboName As String, ByVal SelectedValue As String, ByVal SelectedName As String) Handles ReceiveGridValueMgr.UclOpenComboBoxGridWindow

    '    If Me.Name = CboName Then

    '        ComboBox1.Text = SelectedName

    '        If dsDB IsNot Nothing AndAlso dsGrid IsNot Nothing Then
    '            dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex) = SelectedValue
    '            dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex) = SelectedName



    '            dgv.Visible = False
    '            Me.Visible = False

    '        End If
    '    End If

    'End Sub

#End Region
#Region "     事件集合 "


    Private Sub UCLComboBoxUI_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        Try

            If uclConnDBType = DBType.NonQuery Then


                ReceiveGridValueMgr.RaiseUclOpenWindowValue(uclCtlName, cellRowIndex, cellColIndex, ComboBox1.Text)
                Exit Sub
            End If

            Dim pvtTextValue As String = ComboBox1.Text.Trim
            Dim pvtCodeValue As String = ""
            Dim pvtMatchFlag = False


            If Not uclIsComboBoxGridQuery AndAlso pvtCheckFlag Then

                dgv.SetGridVisible(False)
                Dim t As New DataTable
                t.Columns.Add()
                t.Columns.Add()
                t.Rows.Add()


                t.Rows(0).Item(0) = "ComboBoxType"
                t.Rows(0).Item(1) = ComboBox1.Text
                dgv.getGridView.DataSource = t.Copy
                If ReceiveGridValueMgr Is Nothing Then
                    ReceiveGridValueMgr = EventManager.getInstance
                End If
                ReceiveGridValueMgr.RaiseUclOpenWindowComboBoxGridValue(uclCtlName, cellRowIndex, cellColIndex, dgv.getGridView.Rows(0))
                Exit Sub

            End If


            If pvtCheckFlag Then
                For i = 0 To _uclCboDataSource.Rows.Count - 1

                    pvtCodeValue = _uclCboDataSource.Rows(i).Item("ValueField").ToString.Trim

                    If pvtCodeValue = pvtTextValue Then
                        ComboBox1.SelectedIndex() = i
                        pvtMatchFlag = True
                        Exit For
                    End If
                Next

                If pvtMatchFlag = False Then
                    If _uclShowMsg = True Then
                        MessageBox.Show("代碼：" & pvtTextValue & " 不存在")
                    End If
                    ComboBox1.Text = ""
                End If

                pvtCheckFlag = False

            End If

            If IsNothing(ComboBox1.SelectedValue) Then
                ComboBox1.SelectedValue = ""
                _SelectedValue = ""
            Else
                _SelectedValue = ComboBox1.SelectedValue.ToString.Trim()
            End If

            '   queryAction()
            If dgv.Visible Then
                dgv.Visible = False
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub


    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pvtCheckFlag = False
    End Sub

    Private Sub ComboBox1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent Validated(sender, e)

    End Sub


    Private Sub ComboBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged
        Try

            If Not uclDoTextChanged Then
                Exit Sub
            End If

            If ComboBox1.Focused AndAlso cbo_dgv IsNot Nothing AndAlso FirstEnterGridCell Then
                FirstEnterGridCell = False
            End If

            If Not uclIsComboBoxGridQuery Then


                'dgv.SetGridVisible(False)
                'Dim t As New DataTable
                't.Columns.Add()
                't.Rows.Add()


                't.Rows(0).Item(0) = ComboBox1.Text
                'dgv.getGridView.DataSource = t.Copy
                'ReceiveGridValueMgr.RaiseUclOpenWindowComboBoxGridValue(uclCtlName, cellRowIndex, cellColIndex, dgv.getGridView.Rows(0))

                Exit Sub

            End If


            If uclConnDBType = DBType.NonQuery Then
                Exit Sub
            End If

            If uclIsEqualMatch = EqualMatchData.Y Then
                Exit Sub
            End If

            If ComboBox1.Text.Length = uclStartQueryLength Then

                queryAction(False)

            End If


            If pvtDS1 IsNot Nothing AndAlso ComboBox1.Text.Length > uclStartQueryLength AndAlso ComboBox1.Text.Substring(0, uclStartQueryLength).ToUpper() = searchKey.ToUpper() AndAlso Not hideGrid AndAlso pvtDS2.Tables.Count > 0 Then

                pvtDS2.Tables(0).Rows.Clear()

                For i As Integer = 0 To pvtDS1.Tables(0).Rows.Count - 1

                    If Not _uclValueIndex.Contains(",") Then
                        If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(_uclValueIndex)).ToString().Length Then

                            '前幾碼
                            'If pvtDS1.Tables(0).Rows(i).Item(CInt(_uclValueIndex)).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper() Then
                            '    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                            'End If

                            '全文
                            If uclQueryData = Data.PUB_Disease_IcdCode Then
                                If pvtDS1.Tables(0).Rows(i).Item(CInt(_uclValueIndex)).ToString().Replace(".", "").ToUpper().Contains(ComboBox1.Text.Replace(".", "").ToUpper()) Then
                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            Else
                                If pvtDS1.Tables(0).Rows(i).Item(CInt(_uclValueIndex)).ToString().ToUpper().Contains(ComboBox1.Text.ToUpper()) Then
                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        End If

                    Else

                        If uclQueryData = Data.OPH_Pharmacy_Base_Normal Then
                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length Then

                                If (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.OPH_Pharmacy_Base_Normal_Combine Then

                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length Then

                                If (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.OPH_Pharmacy_Base_Chemo_Combine Then

                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length Then

                                If (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.OPH_Pharmacy_Base_ChemoAndNormal_Combine Then

                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length Then

                                If (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.OPH_Pharmacy_Base_TPN_Combine Then

                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length Then

                                If (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.OPH_Pharmacy_Base_TPNAndNormal_Combine Then

                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length Then

                                If (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.OPH_Pharmacy_Base_TPNAdd_Combine Then

                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length Then

                                If (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(2))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(3))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        ElseIf uclQueryData = Data.PUB_Order_Examine_Combine Then
                            Dim ValueIndex As String() = Split(_uclValueIndex, ",")

                            If ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length OrElse ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length Then

                                If (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(0))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) _
                            OrElse (ComboBox1.Text.Length <= pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Length AndAlso pvtDS1.Tables(0).Rows(i).Item(CInt(ValueIndex(1))).ToString().Substring(0, ComboBox1.Text.Length).ToUpper() = ComboBox1.Text.ToUpper()) Then

                                    pvtDS2.Tables(0).Rows.Add(pvtDS1.Tables(0).Rows(i).ItemArray)
                                End If
                            End If

                        End If

                    End If

                Next

                dgv.Initial(uclCtlName, pvtDS2, cellColIndex, cellRowIndex, cbo_dgv)


                If pvtDS2.Tables(0).Rows.Count > 1 Then
                    IsUseFreeText = True
                    dgv.SetGridVisible(True)
                    dgv.ProcessDrugColor(uclSource)
                ElseIf pvtDS2.Tables(0).Rows.Count = 1 Then
                    'Dim code As String = pvtDS2.Tables(0).Rows(0).Item(CInt(_uclValueIndex)).ToString.Trim
                    'Dim name As String = pvtDS2.Tables(0).Rows(0).Item(CInt(_uclDisplayIndex)).ToString.Trim

                    IsUseFreeText = False
                    If dsDB IsNot Nothing AndAlso dsGrid IsNot Nothing Then

                        If cbo_dgv.AllowUserToAddRows Then
                            If cellRowIndex = dsGrid.Tables(0).Rows.Count - 1 Then
                                cbo_dgv.AddNewRow()
                            End If
                        End If


                    End If

                    cbo_dgv.ComboBoxGridFlag = True


                    dgv.Visible = False
                    Me.Visible = False
                    Dim CanSetOrderData As Boolean = True

                    'If Not IsCanSelectDcOrder Then
                    '    If pvtDS2.Tables(0).Columns.Contains("DC") AndAlso pvtDS2.Tables(0).Rows(0).Item("DC").ToString.ToUpper.Trim = "Y" Then
                    '        CanSetOrderData = False
                    '    End If
                    'End If

                    If CanSetOrderData Then
                        If ReceiveGridValueMgr Is Nothing Then
                            ReceiveGridValueMgr = EventManager.getInstance
                        End If
                        ReceiveGridValueMgr.RaiseUclOpenWindowComboBoxGridValue(uclCtlName, cellRowIndex, cellColIndex, dgv.getGridView.Rows(0))
                    End If
                 
                Else
                    IsUseFreeText = True
                    dgv.Visible = False
                End If

                SetTextBoxFocused()

            ElseIf pvtDS1 IsNot Nothing AndAlso ComboBox1.Text.Length < uclStartQueryLength Then
                dgv.SetGridVisible(False)


            End If

            If ComboBox1.Focused AndAlso cbo_dgv IsNot Nothing AndAlso FirstEnterGridCell Then
                FirstEnterGridCell = False
            End If

            dgv.AutoAdjust()


            Dim ScreenPos As Point = Me.PointToScreen(New Point(0, 0))
            dgv.Left = ScreenPos.X
            dgv.Top = ScreenPos.Y + Me.Height

            '處理 隨輸隨選視窗超出畫面時
            If ScreenPos.X + dgv.Width > Screen.PrimaryScreen.Bounds.Width Then
                dgv.Left = Screen.PrimaryScreen.Bounds.Width - dgv.Width
            End If

            If ScreenPos.Y + Me.Height + dgv.Height > Screen.PrimaryScreen.Bounds.Height Then
                'If ScreenPos.Y > 600 Then
                '    dgv.Height = 300
                'End If
                'dgv.Top = dgv.Top - dgv.Height - 24
                dgv.Height = Screen.PrimaryScreen.Bounds.Height - ScreenPos.Y - 24
            End If


            Me.BackColor = System.Drawing.SystemColors.Window


        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub


    Private Sub ComboBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyUp


        Try


            'fix ms bugs 無法輸入10個字元
            Select Case e.KeyCode
                Case Keys.OemPeriod, Keys.OemPeriod ' .
                    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Not e.Shift Then
                        Fix10Char(".")
                    End If

                Case Keys.Oem7 ' '
                    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Not e.Shift Then
                        Fix10Char("'")
                    ElseIf cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                        Fix10Char("""")
                    End If

                Case Keys.D1 '!
                    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                        Fix10Char("!")
                    End If
                Case Keys.D3 '#
                    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                        Fix10Char("#")
                    End If

                Case Keys.D4 '$
                    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                        Fix10Char("$")
                    End If

                Case Keys.D5 '%
                    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                        Fix10Char("%")
                    End If

                Case Keys.D7 '&
                    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                        Fix10Char("&")
                    End If

                Case Keys.D9 '(
                    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                        Fix10Char("(")
                    End If

                Case Keys.Q ' q
                    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Not e.Shift AndAlso Not My.Computer.Keyboard.CapsLock Then
                        Fix10Char("q")
                    ElseIf cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift AndAlso My.Computer.Keyboard.CapsLock Then
                        Fix10Char("q")

                    ElseIf cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso My.Computer.Keyboard.CapsLock Then
                        Fix10Char("Q")
                    End If
                    'end ms bug

                Case Windows.Forms.Keys.Enter
                    pvtCheckFlag = True
                    UCLComboBoxUI_Leave(sender, e)
                    ComboBox1.SelectionStart = ComboBox1.Text.Trim.Length




            End Select



            Select Case e.KeyCode

                Case Windows.Forms.Keys.Enter
                    If Not dgv.Visible AndAlso uclConnDBType <> DBType.NonQuery Then

                        queryAction(False)

                    End If

                    If uclConnDBType = DBType.NonQuery Then


                        ReceiveGridValueMgr.RaiseUclOpenWindowValue(uclCtlName, cellRowIndex, cellColIndex, ComboBox1.Text)
                        Exit Sub
                    End If


                Case Windows.Forms.Keys.Escape
                    dgv.Visible = False

            End Select

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try

            Select Case keyData

                Case Keys.Enter
                    'If uclIsEqualMatch = EqualMatchData.Y Then
                    '    queryAction()
                    'End If
                    If dgv.Visible AndAlso uclQueryData = Data.PUB_Disease_IcdCode Then
                        'dgv.GetFirstRow()
                        dgv.Focus()
                        Dim x As Integer = 0
                        If IsMultiSelect Then
                            x = 1
                        End If

                        For i As Integer = x To dgv.cbo_dgv.Columns.Count
                            If dgv.cbo_dgv.Columns(i).Visible Then
                                dgv.cbo_dgv.CurrentCell = dgv.cbo_dgv.Rows(0).Cells(i)
                                Exit For
                            End If
                        Next

                        Return True
                    Else
                        queryAction(True)
                    End If


                Case Keys.Escape, Keys.Left, Keys.Right, Keys.Up
                    Me.Visible = False


                Case Keys.OemPeriod, Keys.Oem7

                    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Not Keys.Shift Then
                        Return True
                    End If



                    'Case Keys.D1, Keys.D3, Keys.D4, Keys.D5, Keys.D7, Keys.D9

                    '    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Keys.Shift Then
                    '        Return True
                    '    End If




                Case Keys.Q

                    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Not Keys.Shift AndAlso Not My.Computer.Keyboard.CapsLock Then
                        Return True
                    ElseIf cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Keys.Shift AndAlso My.Computer.Keyboard.CapsLock Then
                        Return True
                    End If

                Case Keys.Space

                    If InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("美") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("英") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("US") Then

                        Dim pos As Integer = ComboBox1.SelectionStart
                        ComboBox1.Text = ComboBox1.Text.Substring(0, ComboBox1.SelectionStart) + " " + ComboBox1.Text.Substring(ComboBox1.SelectionStart)
                        pos += 1
                        ComboBox1.SelectionStart = pos
                    End If

                    Return True

                Case Keys.Down

                    If dgv.Visible Then
                        dgv.Focus()
                        Dim x As Integer = 0
                        If IsMultiSelect Then
                            x = 1
                        End If

                        For i As Integer = x To dgv.cbo_dgv.Columns.Count
                            If dgv.cbo_dgv.Columns(i).Visible Then
                                dgv.cbo_dgv.CurrentCell = dgv.cbo_dgv.Rows(0).Cells(i)
                                Exit For
                            End If
                        Next

                        Return True
                    Else
                        Me.Visible = False
                    End If

            End Select
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

    Private Sub UCLComboBoxGridUI_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Height = 24
    End Sub

    Private Sub ReceiveGridValue(ByVal ctlName As String, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal row As DataGridViewRow) Handles ReceiveGridValueMgr.UclOpenWindowComboBoxGridValue
        Try


            If uclCtlName = ctlName Then

                If dsDB IsNot Nothing AndAlso dsGrid IsNot Nothing Then

                    'IsUseFreeText = False
                    'dgv.Visible = False
                    'Me.Visible = False

                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub


    'fix ms bugs 無法輸入10個字元
    Private Sub Fix10Char(ByVal ch As String)

        If InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("美") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("英") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("US") Then

            Dim pos As Integer = ComboBox1.SelectionStart
            ComboBox1.Text = ComboBox1.Text.Substring(0, ComboBox1.SelectionStart) + ch + ComboBox1.Text.Substring(ComboBox1.SelectionStart)
            pos += 1
            ComboBox1.SelectionStart = pos
        End If

    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave

        Try

            If uclIsEqualMatch = EqualMatchData.Y Then
                queryAction(True)
            End If

            If uclIsFreeText AndAlso IsUseFreeText Then
                If cbo_dgv IsNot Nothing Then
                    If cbo_dgv.MultiSelect Then

                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.Text.Trim
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.Text.Trim
                        cbo_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = ComboBox1.Text.Trim
                        ReceiveGridValueMgr.RaiseUclOpenWindowValue("FreeText" & uclCtlName, cellRowIndex, cellColIndex, ComboBox1.Text.Trim)
                    Else

                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ComboBox1.Text.Trim
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.Text.Trim
                        cbo_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = ComboBox1.Text.Trim
                        ReceiveGridValueMgr.RaiseUclOpenWindowValue("FreeText" & uclCtlName, cellRowIndex, cellColIndex, ComboBox1.Text.Trim)

                    End If
                End If

            End If

            IsUseFreeText = False

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

    End Sub

#End Region
#Region "門急住"

    ''' <summary>
    ''' SQL Server查詢
    ''' </summary>
    ''' <returns>查詢到的資料</returns>
    ''' <remarks></remarks>''' 
    Private Function SelectConnDBForOEI(ByVal IsEqualMatch As Boolean) As DataSet
        Try

            Dim DataDS As New DataSet
            DataDS.Tables.Add()

            DataDS.Tables(0).Columns.Add("Action")
            DataDS.Tables(0).Columns.Add("Code")
            DataDS.Tables(0).Columns.Add("Name")
            DataDS.Tables(0).Columns.Add("DiseaseTypeId")
            DataDS.Tables(0).Columns.Add("OrderTypeId")
            DataDS.Tables(0).Columns.Add("MultiOrderTypeId")
            DataDS.Tables(0).Columns.Add("Source")
            DataDS.Tables(0).Columns.Add("Is_OPD")
            DataDS.Tables(0).Columns.Add("Is_IPD")
            DataDS.Tables(0).Columns.Add("Is_EPD")
            DataDS.Tables(0).Columns.Add("IsSevereDisease")
            DataDS.Tables(0).Columns.Add("IsEqualMatch")
            DataDS.Tables(0).Columns.Add("Is_ShowPrice")
            DataDS.Tables(0).Columns.Add("IcdType")
            DataDS.Tables(0).Columns.Add("IsAllowIcd9Empty")
            DataDS.Tables(0).Columns.Add("IsAllowIcd10Empty")
            DataDS.Tables(0).Columns.Add("Is_ChemoDrug")
            DataDS.Tables(0).Columns.Add("Is_AllChemoDrug")

            DataDS.Tables(0).Columns.Add("Is_Prior_Review")
            DataDS.Tables(0).Columns.Add("IsCheckPubOrderDc")
            DataDS.Tables(0).Columns.Add("BasicDateStr")
            DataDS.Tables(0).Rows.Add()

            DataDS.Tables(0).Rows(0).Item("Source") = uclSource
            DataDS.Tables(0).Rows(0).Item("MultiOrderTypeId") = uclMultiOrderTypeId
            DataDS.Tables(0).Rows(0).Item("BasicDateStr") = uclBasicDateStr

            If uclIsEqualMatch = EqualMatchData.Y OrElse IsEqualMatch Then
                DataDS.Tables(0).Rows(0).Item("IsEqualMatch") = "Y"
            Else
                DataDS.Tables(0).Rows(0).Item("IsEqualMatch") = "N"
            End If

            If uclIsCheckPubOrderDc = PubOrderDcData.Y Then
                DataDS.Tables(0).Rows(0).Item("IsCheckPubOrderDc") = "Y"
            Else
                DataDS.Tables(0).Rows(0).Item("IsCheckPubOrderDc") = "N"
            End If

            If uclIsPriorReview = "Y" Then
                DataDS.Tables(0).Rows(0).Item("Is_Prior_Review") = "Y"
            End If

            If Is_ChemoDrug = YNData.Y Then
                DataDS.Tables(0).Rows(0).Item("Is_ChemoDrug") = "Y"
            Else
                DataDS.Tables(0).Rows(0).Item("Is_ChemoDrug") = "N"
            End If

            If Is_AllChemoDrug = YNData.Y Then
                DataDS.Tables(0).Rows(0).Item("Is_AllChemoDrug") = "Y"
            Else
                DataDS.Tables(0).Rows(0).Item("Is_AllChemoDrug") = "N"
            End If

            Select Case _uclConnDBType

                Case DBType.LocalAccess
                    Return Nothing


                Case DBType.RemoteSqlServer

                    If uclQueryData = Data.PUB_Disease_IcdCode Then
                        '隨輸隨選 醫囑診斷 PUB_Disease

                        If IcdType = IcdTypeData.Icd9 Then
                            DataDS.Tables(0).Rows(0).Item("IcdType") = "Icd9"
                        ElseIf IcdType = IcdTypeData.Icd10 Then
                            DataDS.Tables(0).Rows(0).Item("IcdType") = "Icd10"
                        ElseIf IcdType = IcdTypeData.OnlyIcd9 Then
                            DataDS.Tables(0).Rows(0).Item("IcdType") = "OnlyIcd9"
                        ElseIf IcdType = IcdTypeData.OnlyIcd10 Then
                            DataDS.Tables(0).Rows(0).Item("IcdType") = "OnlyIcd10"
                        End If


                        If IsAllowIcd9Empty = YNData.Y Then
                            DataDS.Tables(0).Rows(0).Item("IsAllowIcd9Empty") = "Y"
                        Else
                            DataDS.Tables(0).Rows(0).Item("IsAllowIcd9Empty") = "N"
                        End If

                        If IsAllowIcd10Empty = YNData.Y Then
                            DataDS.Tables(0).Rows(0).Item("IsAllowIcd10Empty") = "Y"
                        Else
                            DataDS.Tables(0).Rows(0).Item("IsAllowIcd10Empty") = "N"
                        End If

                        If _uclQueryType = By.Code Then
                            If uclMultiDiseaseTypeId <> "" Then
                                'Return ucl.queryOMOOrderDiagnosis(searchKey.Trim, "", uclMultiDiseaseTypeId)

                                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Disease_IcdCode"
                                DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                                DataDS.Tables(0).Rows(0).Item("Name") = ""
                                DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                                DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                                DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                                DataDS.Tables(0).Rows(0).Item("DiseaseTypeId") = uclMultiDiseaseTypeId

                                Return ucl.DoUclAction(DataDS)

                            Else
                                'Return ucl.queryOMOOrderDiagnosis(searchKey.Trim, "", GetDiseaseTypeId())

                                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Disease_IcdCode"
                                DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                                DataDS.Tables(0).Rows(0).Item("Name") = ""
                                DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                                DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                                DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                                DataDS.Tables(0).Rows(0).Item("DiseaseTypeId") = GetDiseaseTypeId()

                                Return ucl.DoUclAction(DataDS)

                            End If

                        Else

                            If uclMultiDiseaseTypeId <> "" Then
                                'Return ucl.queryOMOOrderDiagnosis("", searchKey.Trim, uclMultiDiseaseTypeId)

                                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Disease_IcdCode"
                                DataDS.Tables(0).Rows(0).Item("Code") = ""
                                DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                                DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                                DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                                DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                                DataDS.Tables(0).Rows(0).Item("DiseaseTypeId") = uclMultiDiseaseTypeId

                                Return ucl.DoUclAction(DataDS)

                            Else
                                'Return ucl.queryOMOOrderDiagnosis("", searchKey.Trim, GetDiseaseTypeId())

                                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Disease_IcdCode"
                                DataDS.Tables(0).Rows(0).Item("Code") = ""
                                DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                                DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                                DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                                DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                                DataDS.Tables(0).Rows(0).Item("DiseaseTypeId") = GetDiseaseTypeId()

                                Return ucl.DoUclAction(DataDS)

                            End If


                        End If

                    ElseIf uclQueryData = Data.PUB_Disease_IsSevereDisease Then

                        If _uclQueryType = By.Code Then
                            If uclMultiDiseaseTypeId <> "" Then
                                'Return ucl.queryOMOOrderDiagnosis(searchKey.Trim, "", uclMultiDiseaseTypeId, "Y")

                                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Disease_IsSevereDisease"
                                DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                                DataDS.Tables(0).Rows(0).Item("Name") = ""
                                DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                                DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                                DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                                DataDS.Tables(0).Rows(0).Item("IsSevereDisease") = "Y"
                                DataDS.Tables(0).Rows(0).Item("DiseaseTypeId") = uclMultiDiseaseTypeId

                                Return ucl.DoUclAction(DataDS)

                            Else
                                'Return ucl.queryOMOOrderDiagnosis(searchKey.Trim, "", GetDiseaseTypeId(), "Y")

                                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Disease_IsSevereDisease"
                                DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                                DataDS.Tables(0).Rows(0).Item("Name") = ""
                                DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                                DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                                DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                                DataDS.Tables(0).Rows(0).Item("IsSevereDisease") = "Y"
                                DataDS.Tables(0).Rows(0).Item("DiseaseTypeId") = GetDiseaseTypeId()

                                Return ucl.DoUclAction(DataDS)

                            End If



                        Else

                            If uclMultiDiseaseTypeId <> "" Then
                                'Return ucl.queryOMOOrderDiagnosis("", searchKey.Trim, uclMultiDiseaseTypeId, "Y")

                                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Disease_IsSevereDisease"
                                DataDS.Tables(0).Rows(0).Item("Code") = ""
                                DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                                DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                                DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                                DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                                DataDS.Tables(0).Rows(0).Item("IsSevereDisease") = "Y"
                                DataDS.Tables(0).Rows(0).Item("DiseaseTypeId") = uclMultiDiseaseTypeId

                                Return ucl.DoUclAction(DataDS)


                            Else
                                'Return ucl.queryOMOOrderDiagnosis("", searchKey.Trim, GetDiseaseTypeId(), "Y")

                                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Disease_IsSevereDisease"
                                DataDS.Tables(0).Rows(0).Item("Code") = ""
                                DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                                DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                                DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                                DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                                DataDS.Tables(0).Rows(0).Item("IsSevereDisease") = "Y"
                                DataDS.Tables(0).Rows(0).Item("DiseaseTypeId") = GetDiseaseTypeId()

                                Return ucl.DoUclAction(DataDS)

                            End If


                        End If



                    ElseIf uclQueryData = Data.PUB_Order_Mixed Then
                        '隨輸隨選 混合開立
                        If _uclQueryType = By.Code Then

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Mixed"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = GetOrderTypeId()
                            Return ucl.DoUclAction(DataDS)

                        Else

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Mixed"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = GetOrderTypeId()
                            Return ucl.DoUclAction(DataDS)
                        End If

                    ElseIf uclQueryData = Data.PUB_Order_Insu Then
                        '隨輸隨選  

                        DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Insu"
                        DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                        DataDS.Tables(0).Rows(0).Item("Name") = ""
                        DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                        DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                        DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                        DataDS.Tables(0).Rows(0).Item("OrderTypeId") = GetOrderTypeId()
                        Return ucl.DoUclAction(DataDS)

                    ElseIf uclQueryData = Data.OPH_Pharmacy_Base_Normal Then
                        '隨輸隨選 一般藥品  
                        If _uclQueryType = By.Code Then


                            'Return ucl.queryOPHPharmacyBase(searchKey.Trim, "", "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "NormalDrug2"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD


                            Return ucl.DoUclAction(DataDS)


                        Else

                            'Return ucl.queryOPHPharmacyBase("", searchKey.Trim, "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "NormalDrug2"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD


                            Return ucl.DoUclAction(DataDS)
                        End If


                    ElseIf uclQueryData = Data.OPH_Pharmacy_Base_Normal_Combine Then
                        '隨輸隨選 一般藥品  
                        If _uclQueryType = By.Code Then


                            'Return ucl.queryOPHPharmacyBase(searchKey.Trim, "", "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "NormalDrug2"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD


                            Return ucl.DoUclAction(DataDS)


                        Else

                            'Return ucl.queryOPHPharmacyBase("", searchKey.Trim, "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "NormalDrug3"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD


                            Return ucl.DoUclAction(DataDS)
                        End If

                    ElseIf uclQueryData = Data.OPH_Pharmacy_Base_Chemo_For_IMO_Package_Chemo Then
                        '隨輸隨選 一般藥品  
                        If _uclQueryType = By.Code Then


                            'Return ucl.queryOPHPharmacyBase(searchKey.Trim, "", "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "ChemoDrugForIMOPackageChemo"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD


                            Return ucl.DoUclAction(DataDS)


                        Else

                            'Return ucl.queryOPHPharmacyBase("", searchKey.Trim, "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "ChemoDrugForIMOPackageChemo"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD


                            Return ucl.DoUclAction(DataDS)
                        End If


                    ElseIf uclQueryData = Data.OPH_Pharmacy_Base_Chemo_Combine Then
                        '隨輸隨選 一般藥品  
                        If _uclQueryType = By.Code Then


                            'Return ucl.queryOPHPharmacyBase(searchKey.Trim, "", "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "ChemoDrug3"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)

                        Else

                            'Return ucl.queryOPHPharmacyBase("", searchKey.Trim, "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "ChemoDrug3"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                        End If

                    ElseIf uclQueryData = Data.OPH_Pharmacy_Base_ChemoAndNormal_Combine Then
                        '隨輸隨選 一般藥品  
                        If _uclQueryType = By.Code Then


                            'Return ucl.queryOPHPharmacyBase(searchKey.Trim, "", "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "ChemoAndNormalDrug3"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)

                        Else

                            'Return ucl.queryOPHPharmacyBase("", searchKey.Trim, "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "ChemoAndNormalDrug3"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                        End If

                    ElseIf uclQueryData = Data.OPH_Pharmacy_Base_TPN_Combine Then
                        '隨輸隨選 TPN藥品 
                        If _uclQueryType = By.Code Then


                            'Return ucl.queryOPHPharmacyBase(searchKey.Trim, "", "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "TPNDrug3"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)

                        Else

                            'Return ucl.queryOPHPharmacyBase("", searchKey.Trim, "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "TPNDrug3"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                        End If

                    ElseIf uclQueryData = Data.OPH_Pharmacy_Base_TPNAndNormal_Combine Then
                        '隨輸隨選 TPN藥品 
                        If _uclQueryType = By.Code Then


                            'Return ucl.queryOPHPharmacyBase(searchKey.Trim, "", "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "TPNAndNormalDrug3"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)

                        Else

                            'Return ucl.queryOPHPharmacyBase("", searchKey.Trim, "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "TPNAndNormalDrug3"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                        End If


                    ElseIf uclQueryData = Data.OPH_Pharmacy_Base_TPNAdd_Combine Then
                        '隨輸隨選 TPN藥品 
                        If _uclQueryType = By.Code Then


                            'Return ucl.queryOPHPharmacyBase(searchKey.Trim, "", "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "TPNAddDrug3"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)

                        Else

                            'Return ucl.queryOPHPharmacyBase("", searchKey.Trim, "NormalDrug2")

                            DataDS.Tables(0).Rows(0).Item("Action") = "TPNAddDrug3"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                        End If


                    ElseIf uclQueryData = Data.PUB_Order Then

                        '隨輸隨選 PUB_Order 
                        If _uclQueryType = By.Code Then
                            If uclMultiOrderTypeId <> "" Then
                                'Return ucl.queryPUBOrder(searchKey.Trim, "", uclMultiOrderTypeId)

                                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order"
                                DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                                DataDS.Tables(0).Rows(0).Item("Name") = ""
                                DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                                DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                                DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                                DataDS.Tables(0).Rows(0).Item("OrderTypeId") = uclMultiOrderTypeId

                                Return ucl.DoUclAction(DataDS)

                            Else
                                'Return ucl.queryPUBOrder(searchKey.Trim, "", GetOrderTypeId())

                                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order"
                                DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                                DataDS.Tables(0).Rows(0).Item("Name") = ""
                                DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                                DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                                DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                                DataDS.Tables(0).Rows(0).Item("OrderTypeId") = GetOrderTypeId()

                                Return ucl.DoUclAction(DataDS)

                            End If
                        Else
                            If uclMultiOrderTypeId <> "" Then
                                'Return ucl.queryPUBOrder("", searchKey.Trim, uclMultiOrderTypeId)

                                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order"
                                DataDS.Tables(0).Rows(0).Item("Code") = ""
                                DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                                DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                                DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                                DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                                DataDS.Tables(0).Rows(0).Item("OrderTypeId") = uclMultiOrderTypeId()

                                Return ucl.DoUclAction(DataDS)

                            Else
                                'Return ucl.queryPUBOrder("", searchKey.Trim, GetOrderTypeId())

                                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order"
                                DataDS.Tables(0).Rows(0).Item("Code") = ""
                                DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                                DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                                DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                                DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                                DataDS.Tables(0).Rows(0).Item("OrderTypeId") = GetOrderTypeId()

                                Return ucl.DoUclAction(DataDS)

                            End If
                        End If

                    ElseIf uclQueryData = Data.PUB_Order_Material Then
                        '隨輸隨選 PUB_Order_Material 衛材 Order_Type_Id="G"
                        If _uclQueryType = By.Code Then
                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "G")

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Material"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "G"
                            Return ucl.DoUclAction(DataDS)

                        Else
                            'Return ucl.queryPUBOrder("", searchKey.Trim, "G")

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Material"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "G"
                            Return ucl.DoUclAction(DataDS)

                        End If


                    ElseIf uclQueryData = Data.PUB_Order_Cure Then
                        '隨輸隨選 PUB_Order_Cure 治療處置 Order_Type_Id="D"

                        If _uclQueryType = By.Code Then
                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "D")

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Cure"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "D"
                            Return ucl.DoUclAction(DataDS)

                        Else
                            'Return ucl.queryPUBOrder("", searchKey.Trim, "D")

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Cure"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "D"
                            Return ucl.DoUclAction(DataDS)

                        End If

                    ElseIf uclQueryData = Data.PUB_Order_Examine Then
                        '隨輸隨選 PUB_Order_Cure 檢驗檢查 Order_Type_Id="H"

                        If _uclQueryType = By.Code Then
                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "H")

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Examine"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "H"
                            Return ucl.DoUclAction(DataDS)

                        Else
                            'Return ucl.queryPUBOrder("", searchKey.Trim, "H")

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Examine"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "H"
                            Return ucl.DoUclAction(DataDS)

                        End If

                    ElseIf uclQueryData = Data.PUB_Order_Examine_Combine Then
                        '隨輸隨選 PUB_Order_Examine_Combine 檢驗檢查 Order_Type_Id="H"

                        If _uclQueryType = By.Code Then
                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "H")

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Examine_Combine"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "H"
                            Return ucl.DoUclAction(DataDS)

                        Else
                            'Return ucl.queryPUBOrder("", searchKey.Trim, "H")

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Examine_Combine"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "H"
                            Return ucl.DoUclAction(DataDS)

                        End If

                    ElseIf uclQueryData = Data.PUB_Order_Operation Then
                        '隨輸隨選 PUB_Order_Operation  手術 Order_Type_Id="J"
                        Dim SearchStr As String = ""

                        If _uclQueryType = By.Code Then

                            SearchStr = searchKey.Trim

                            If uclEmpCode.Trim <> "" Then
                                SearchStr += "|" & uclEmpCode.Trim
                            End If

                            If uclDepCode.Trim <> "" Then
                                SearchStr += "|" & uclDepCode.Trim
                            End If


                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Operation"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "J"
                            Return ucl.DoUclAction(DataDS)

                            'Return ucl.queryPUBOrder(SearchStr.Trim, "", "J")
                        Else

                            SearchStr = searchKey.Trim

                            If uclEmpCode.Trim <> "" Then
                                SearchStr += "|" & uclEmpCode.Trim
                            End If

                            If uclDepCode.Trim <> "" Then
                                SearchStr += "|" & uclDepCode.Trim
                            End If

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Operation"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "J"
                            Return ucl.DoUclAction(DataDS)

                            'Return ucl.queryPUBOrder("", SearchStr.Trim, "J")
                        End If

                    ElseIf uclQueryData = Data.PUB_Order_Often Then
                        '隨輸隨選 PUB_Order_Often  常用處置維護                          
                        If _uclQueryType = By.Code Then

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Often"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "Often"
                            Return ucl.DoUclAction(DataDS)

                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "Often")
                        Else

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Often"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "Often"
                            Return ucl.DoUclAction(DataDS)


                            'Return ucl.queryPUBOrder("", searchKey.Trim, "Often")
                        End If

                    ElseIf uclQueryData = Data.PUB_Order_DepOftenH Then
                        '隨輸隨選 PUB_Order_DepOftenH  醫令 -科常用醫令                      
                        If _uclQueryType = By.Code Then

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_DepOftenH"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "DepOftenH"
                            Return ucl.DoUclAction(DataDS)

                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "DepOftenH")
                        Else


                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_DepOftenH"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "DepOftenH"
                            Return ucl.DoUclAction(DataDS)


                            'Return ucl.queryPUBOrder("", searchKey.Trim, "DepOftenH")
                        End If


                    ElseIf uclQueryData = Data.PUB_Order_InsuCode Then

                        '隨輸隨選 PUB_Order_Often  常用處置維護                          
                        If _uclQueryType = By.Code Then

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_InsuCode"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "NckuCode"
                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "NckuCode", uclBasicDateStr)
                        Else

                            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_InsuCode"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD
                            DataDS.Tables(0).Rows(0).Item("OrderTypeId") = "NckuCode"
                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder("", searchKey.Trim, "NckuCode", uclBasicDateStr)
                        End If

                    ElseIf uclQueryData = Data.Nut_Recipe Then

                        If _uclQueryType = By.Code Then

                            DataDS.Tables(0).Rows(0).Item("Action") = "Nut_Recipe"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "NckuCode", uclBasicDateStr)
                        Else

                            DataDS.Tables(0).Rows(0).Item("Action") = "Nut_Recipe"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder("", searchKey.Trim, "NckuCode", uclBasicDateStr)
                        End If

                    ElseIf uclQueryData = Data.Nut_Diet_Type Then

                        If _uclQueryType = By.Code Then

                            DataDS.Tables(0).Rows(0).Item("Action") = "Nut_Diet_Type"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "NckuCode", uclBasicDateStr)
                        Else

                            DataDS.Tables(0).Rows(0).Item("Action") = "Nut_Diet_Type"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder("", searchKey.Trim, "NckuCode", uclBasicDateStr)
                        End If

                    ElseIf uclQueryData = Data.Nut_Recipe_Compose_Detail Then

                        If _uclQueryType = By.Code Then

                            DataDS.Tables(0).Rows(0).Item("Action") = "Nut_Recipe_Compose_Detail"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "NckuCode", uclBasicDateStr)
                        Else

                            DataDS.Tables(0).Rows(0).Item("Action") = "Nut_Recipe_Compose_Detail"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder("", searchKey.Trim, "NckuCode", uclBasicDateStr)
                        End If

                    ElseIf uclQueryData = Data.Sysblood Then

                        If _uclQueryType = By.Code Then

                            DataDS.Tables(0).Rows(0).Item("Action") = "Sysblood"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "NckuCode", uclBasicDateStr)
                        Else

                            DataDS.Tables(0).Rows(0).Item("Action") = "Sysblood"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder("", searchKey.Trim, "NckuCode", uclBasicDateStr)
                        End If

                    ElseIf uclQueryData = Data.STA_Package Then

                        If _uclQueryType = By.Code Then

                            DataDS.Tables(0).Rows(0).Item("Action") = "STA_Package"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "NckuCode", uclBasicDateStr)
                        Else

                            DataDS.Tables(0).Rows(0).Item("Action") = "STA_Package"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder("", searchKey.Trim, "NckuCode", uclBasicDateStr)
                        End If

                    ElseIf uclQueryData = Data.PTW_Clinical_Path Then

                        If _uclQueryType = By.Code Then

                            DataDS.Tables(0).Rows(0).Item("Action") = "PTW_Clinical_Path"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "NckuCode", uclBasicDateStr)
                        Else

                            DataDS.Tables(0).Rows(0).Item("Action") = "PTW_Clinical_Path"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder("", searchKey.Trim, "NckuCode", uclBasicDateStr)
                        End If


                    ElseIf uclQueryData = Data.IHD_Appeal_Dispute_Reason Then

                        If _uclQueryType = By.Code Then

                            DataDS.Tables(0).Rows(0).Item("Action") = "IHD_Appeal_Dispute_Reason"
                            DataDS.Tables(0).Rows(0).Item("Code") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Name") = ""
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder(searchKey.Trim, "", "NckuCode", uclBasicDateStr)
                        Else

                            DataDS.Tables(0).Rows(0).Item("Action") = "IHD_Appeal_Dispute_Reason"
                            DataDS.Tables(0).Rows(0).Item("Code") = ""
                            DataDS.Tables(0).Rows(0).Item("Name") = searchKey.Trim
                            DataDS.Tables(0).Rows(0).Item("Is_OPD") = uclIsOPD
                            DataDS.Tables(0).Rows(0).Item("Is_IPD") = uclIsIPD
                            DataDS.Tables(0).Rows(0).Item("Is_EPD") = uclIsEPD

                            Return ucl.DoUclAction(DataDS)
                            'Return ucl.queryPUBOrder("", searchKey.Trim, "NckuCode", uclBasicDateStr)
                        End If
                    Else
                        Return Nothing
                    End If

                Case DBType.LocalThenRemote
                    Return Nothing
                Case DBType.RemoteThenLocal
                    Return Nothing
                Case Else
                    Return Nothing
            End Select
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    Public Sub SetLocalData(ByVal ds As DataSet)

        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            If LocalDataSet Is Nothing Then
                LocalDataSet = New DataSet
            End If

            LocalDataSet.Tables.Clear()
            LocalDataSet.Tables.Add(ds.Tables(0).Copy)
        Else
            LocalDataSet.Tables.Clear()
        End If

    End Sub

#End Region

End Class
