'/*
'*****************************************************************************
'*
'*    Page/Class Name:	UCLComboBoxUI.vb
'*              Title:	ComboBox元件
'*        Description:	ComboBox元件 功能設計
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	James,Sean
'*        Create Date:
'*      Last Modifier:
'*   Last Modify Date:
'*
'*****************************************************************************
'*/
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.BASE
Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory

''' <summary>
''' Class UCLComboBoxUC.
''' </summary>
''' <seealso cref="System.Windows.Forms.UserControl" />
Public Class UCLComboBoxUC

#Region "變數宣告與屬性設定"

#Region "全域變數宣告"

    ''' <summary>
    ''' The data source
    ''' </summary>
    Private _DataSource As DataTable = New DataTable()
    ''' <summary>
    ''' The selected value
    ''' </summary>
    Private _SelectedValue As String = ""
    ''' <summary>
    ''' The selected text
    ''' </summary>
    Private _SelectedText As String = ""
    ''' <summary>
    ''' The back color
    ''' </summary>
    Private _BackColor As Color
    ''' <summary>
    ''' The drop down width
    ''' </summary>
    Private _DropDownWidth As Integer = 20
    ''' <summary>
    ''' The ucl display index
    ''' </summary>
    Private _uclDisplayIndex As String = "0,1"
    ''' <summary>
    ''' The ucl value index
    ''' </summary>
    Private _uclValueIndex As String = "0"
    ''' <summary>
    ''' The ucl show MSG
    ''' </summary>
    Private _uclShowMsg As Boolean = False
    ''' <summary>
    ''' The drop down style
    ''' </summary>
    Private _DropDownStyle As System.Windows.Forms.ComboBoxStyle = ComboBoxStyle.DropDown
    ''' <summary>
    ''' The items
    ''' </summary>
    Private _Items As System.Windows.Forms.ComboBox.ObjectCollection
    ''' <summary>
    ''' The selection start
    ''' </summary>
    Private _SelectionStart As Integer = 0
    ''' <summary>
    ''' The selected item
    ''' </summary>
    Private _SelectedItem As Object
    ''' <summary>
    ''' The selected index
    ''' </summary>
    Private _SelectedIndex As Integer
    '   Private _Width As Integer = 50

    ''' <summary>
    ''' The ucl is automatic clear
    ''' </summary>
    Private _uclIsAutoClear As Boolean = True

    ''' <summary>
    ''' The ucl is text mode
    ''' </summary>
    Private _uclIsTextMode As Boolean = False
    ''' <summary>
    ''' The ucl is first item empty
    ''' </summary>
    Private _uclIsFirstItemEmpty As Boolean = True

    ''' <summary>
    ''' The PVT check flag
    ''' </summary>
    Dim pvtCheckFlag = False
    ''' <summary>
    ''' The pvtdo flag
    ''' </summary>
    Dim pvtdoFlag = True

    ''' <summary>
    ''' Occurs when [selected index changed].
    ''' </summary>
    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    ''' <summary>
    ''' Occurs when [ComboBoxCellSelectedValueChangedAndLeave].
    ''' </summary>
    Public Event ComboBoxCellSelectedValueChangedAndLeave(ByVal RowIndex As Integer, ByVal ColIndex As Integer)

    ''' <summary>
    ''' Occurs when [validated].
    ''' </summary>
    Public Shadows Event Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Occurs when [key up].
    ''' </summary>
    Public Shadows Event KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    ''' <summary>
    ''' Occurs when [key down].
    ''' </summary>
    Public Shadows Event KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    ''' <summary>
    ''' Occurs when [text changed].
    ''' </summary>
    Public Shadows Event TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Occurs when [drop down].
    ''' </summary>
    Public Shadows Event DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ''' <summary>
    ''' The text
    ''' </summary>
    Private _Text As String

    '用在datagridview的ComboBox
    ''' <summary>
    ''' The cbo DGV
    ''' </summary>
    Dim cbo_dgv As UCLDataGridViewUC = Nothing

    ''' <summary>
    ''' The ds database
    ''' </summary>
    Dim dsDB As DataSet = Nothing
    ''' <summary>
    ''' The ds grid
    ''' </summary>
    Dim dsGrid As DataSet = Nothing

    ''' <summary>
    ''' The cell row index
    ''' </summary>
    Public cellRowIndex, cellColIndex As Integer
    '用在datagridview的Cell剛進Combox時
    ''' <summary>
    ''' The first enter grid cell
    ''' </summary>
    Public FirstEnterGridCell As Boolean = False

    ''' <summary>
    ''' 隨輸隨選Cell初值設定
    ''' grid: Parent GridView
    ''' dDB:DB來源資料
    ''' dGrid:Grid來源資料
    ''' code:Cell初值
    ''' </summary>
    Public IsComboxClickTriggerDropDown As Boolean = False
    ''' <summary>
    ''' The selected ComboBox code value
    ''' </summary>
    Dim SelectedComboBoxCodeValue As String = "" '隨輸隨選特殊的Combox code

    ''' <summary>
    ''' OriSelectedComboBoxCodeValue
    ''' </summary>
    Dim OriSelectedComboBoxCodeValue As String = "" ' 

    ''' <summary>
    ''' The do text changed
    ''' </summary>
    Public doTextChanged As Boolean = False
    ''' <summary>
    ''' The tree grid col
    ''' </summary>
    Dim TreeGridCol As Integer = 0

    ''' <summary>
    ''' The MGR ComboBox
    ''' </summary>
    Dim WithEvents mgrComboBox As EventManager = EventManager.getInstance '宣告EventManager

#End Region

#Region "屬性設定"

    ''' <summary>
    ''' 設定ComboBox MaxLength
    ''' </summary>
    Public Property MaxLength() As Integer
        Get
            Return ComboBox1.MaxLength
        End Get
        Set(ByVal value As Integer)
            ComboBox1.MaxLength = value
        End Set
    End Property

    ''' <summary>
    ''' 設定是否要可自由輸入文字,True 可,False 不可,預設 False
    ''' </summary>
    ''' <value><c>true</c> if [ucl is first item empty]; otherwise, <c>false</c>.</value>
    ''' <remarks>by Sean.Lin on 2013-8-26</remarks>
    Public Property uclIsFirstItemEmpty() As Boolean
        Get
            Return _uclIsFirstItemEmpty
        End Get
        Set(ByVal value As Boolean)
            _uclIsFirstItemEmpty = value
        End Set
    End Property

    ''' <summary>
    ''' 開始選擇Index
    ''' </summary>
    ''' <value>ComboBox1.SelectionStart</value>
    Public Property SelectionStart() As Integer
        Get
            Return ComboBox1.SelectionStart
        End Get
        Set(ByVal value As Integer)
            Try

                If ComboBox1.Text.Length >= 0 AndAlso value >= 0 AndAlso value <= ComboBox1.Text.Length Then
                    If ComboBox1.SelectionStart >= 0 Then
                        ComboBox1.SelectionStart = value
                    End If

                End If
            Catch ex As Exception

            End Try
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ImeMode.
    ''' </summary>
    ''' <value>The ImeMode.</value>
    Public Property uclImeMode() As ImeMode
        Get
            Return ComboBox1.ImeMode
        End Get
        Set(ByVal value As ImeMode)
            ComboBox1.ImeMode = value
        End Set
    End Property

    ''' <summary>
    ''' 選擇的Index
    ''' </summary>
    ''' <value>The index of the selected.</value>
    Public Property SelectedIndex() As Integer
        Get
            Return ComboBox1.SelectedIndex
        End Get
        Set(ByVal value As Integer)

            ComboBox1.SelectedIndex = value

        End Set
    End Property

    ''' <summary>
    ''' 選擇的項目
    ''' </summary>
    ''' <value>The selected item.</value>
    Public Property SelectedItem() As Object
        Get
            Return ComboBox1.SelectedItem
        End Get
        Set(ByVal value As Object)
            ComboBox1.SelectedItem = value
        End Set
    End Property

    ''' <summary>
    ''' ComboBox項目
    ''' </summary>
    ''' <value>The items.</value>
    Public ReadOnly Property Items() As System.Windows.Forms.ComboBox.ObjectCollection
        Get
            Return ComboBox1.Items
        End Get
    End Property

    ''' <summary>
    ''' Text
    ''' </summary>
    ''' <value>The text.</value>
    Public Overrides Property Text() As String
        Get
            Return ComboBox1.Text

        End Get
        Set(ByVal value As String)
            ComboBox1.Text = value

        End Set
    End Property

    ''' <summary>
    ''' DropDownStyle
    ''' </summary>
    ''' <value>The drop down style.</value>
    Public Property DropDownStyle() As System.Windows.Forms.ComboBoxStyle
        Get
            Return ComboBox1.DropDownStyle
        End Get
        Set(ByVal value As System.Windows.Forms.ComboBoxStyle)
            ComboBox1.DropDownStyle = value
        End Set
    End Property

    ''' <summary>
    ''' DataSource
    ''' </summary>
    ''' <value>The data source.</value>
    Public Property DataSource() As DataTable
        Get
            Return _DataSource

        End Get
        Set(ByVal value As DataTable)
            pvtdoFlag = False
            doTextChanged = False

            If value IsNot Nothing Then

                '第一項為空白
                '   value.Rows.InsertAt(value.NewRow(), 0)

                If uclIsFirstItemEmpty Then
                    Dim nullData = value.NewRow()
                    For i = 0 To value.Columns.Count - 1

                        If value.Columns(i).DataType.ToString.ToUpper() = "SYSTEM.STRING" Then
                            nullData.Item(i) = " "
                        ElseIf value.Columns(i).DataType.ToString.ToUpper() = "INTEGER" Then
                            nullData.Item(i) = 0
                        ElseIf value.Columns(i).DataType.ToString.ToUpper() = "SYSTEM.DATETIME" Then
                            nullData.Item(i) = Now
                        ElseIf value.Columns(i).DataType.ToString.ToUpper() = "SYSTEM.DECIMAL" Then
                            nullData.Item(i) = 0.0
                        ElseIf value.Columns(i).DataType.ToString.ToUpper() = "SYSTEM.INT32" Then
                            nullData.Item(i) = 0
                        ElseIf value.Columns(i).DataType.ToString.ToUpper() = "SYSTEM.INT64" Then
                            nullData.Item(i) = 0
                        ElseIf value.Columns(i).DataType.ToString.ToUpper() = "SYSTEM.INT16" Then
                            nullData.Item(i) = 0
                        Else
                            nullData.Item(i) = " "
                        End If
                    Next

                    value.Rows.InsertAt(nullData, 0)
                End If

                _DataSource = value

                ComboBox1.DataSource = value

                SetComboField(_DataSource, "ValueField", _uclValueIndex)
                ComboBox1.ValueMember = "ValueField"

                doTextChanged = True

            Else
                ComboBox1.DataSource = Nothing
            End If
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the selected value.
    ''' </summary>
    ''' <value>The selected value.</value>
    Public Property SelectedValue() As String

        Get
            If ComboBox1.SelectedValue IsNot Nothing AndAlso ComboBox1.SelectedValue IsNot DBNull.Value AndAlso Not ComboBox1.SelectedValue.GetType.ToString = "System.Data.DataRowView" Then
                Return ComboBox1.SelectedValue

            ElseIf _SelectedValue <> "" Then
                Return _SelectedValue
            Else
                Return ""
            End If

        End Get
        Set(ByVal value As String)
            _SelectedValue = StringUtil.nvl(value)

            ComboBox1.SelectedValue = _SelectedValue
            If ComboBox1.SelectedValue IsNot Nothing AndAlso (ComboBox1.SelectedValue Is DBNull.Value Or ComboBox1.SelectedValue.Equals("")) Then
                'If ComboBox1.SelectedValue ="" Then
                _SelectedValue = ""

            End If
            If value = "" Then
                ComboBox1.Text = ""
            End If
        End Set

    End Property

    ''' <summary>
    ''' SelectedText
    ''' </summary>
    ''' <value>The selected text.</value>
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

    ''' <summary>
    ''' Combox 下拉寬度
    ''' </summary>
    ''' <value>The width of the drop down.</value>
    Public Property DropDownWidth() As Integer
        Get
            Return _DropDownWidth
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then
                _DropDownWidth = value
                ComboBox1.DropDownWidth = _DropDownWidth
            End If

        End Set
    End Property

    ''' <summary>
    ''' 設定要顯示的欄位Index(預設為0,1=&gt;代碼與名稱)
    ''' </summary>
    ''' <value>The display index of the ucl.</value>
    ''' <remarks>by Sean.Lin on 2013-8-26</remarks>
    Public Property uclDisplayIndex() As String
        Get
            Return _uclDisplayIndex
        End Get
        Set(ByVal value As String)
            pvtdoFlag = False
            _uclDisplayIndex = value
            SetComboField(_DataSource, "ShowField", _uclDisplayIndex)
            ComboBox1.DisplayMember = "ShowField"
        End Set
    End Property

    ''' <summary>
    ''' 設定要選取值的欄位Index(預設為0=&gt;代碼)
    ''' </summary>
    ''' <value>The index of the ucl value.</value>
    ''' <remarks>by Sean.Lin on 2013-8-26</remarks>
    Public Property uclValueIndex() As String
        Get
            Return _uclValueIndex
        End Get
        Set(ByVal value As String)
            _uclValueIndex = value
            SetComboField(_DataSource, "ValueField", _uclValueIndex)
            ComboBox1.ValueMember = "ValueField"

        End Set
    End Property

    ''' <summary>
    ''' 設定要顯示訊息(預設為false)
    ''' </summary>
    ''' <value><c>true</c> if [ucl show MSG]; otherwise, <c>false</c>.</value>
    ''' <remarks>by Sean.Lin on 2013-8-26</remarks>
    Public Property uclShowMsg() As Boolean
        Get
            Return _uclShowMsg
        End Get
        Set(ByVal value As Boolean)
            _uclShowMsg = value
        End Set
    End Property

    ''' <summary>
    ''' 設定是否要可自由輸入文字,True 可,False 不可,預設 False
    ''' </summary>
    ''' <value><c>true</c> if [ucl is text mode]; otherwise, <c>false</c>.</value>
    ''' <remarks>by Sean.Lin on 2013-8-26</remarks>
    Public Property uclIsTextMode() As Boolean
        Get
            Return _uclIsTextMode
        End Get
        Set(ByVal value As Boolean)
            _uclIsTextMode = value
        End Set
    End Property

    ''' <summary>
    ''' 設定自動清除(預設為false)
    ''' </summary>
    ''' <value><c>true</c> if [ucl is automatic clear]; otherwise, <c>false</c>.</value>
    ''' <remarks>by Sean.Lin on 2013-8-26</remarks>
    Public Property uclIsAutoClear() As Boolean
        Get
            Return _uclIsAutoClear
        End Get
        Set(ByVal value As Boolean)
            _uclIsAutoClear = value
        End Set
    End Property

    ''' <summary>
    ''' 底色
    ''' </summary>
    ''' <value>The color of the back.</value>
    ''' <PermissionSet>
    '''   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ''' </PermissionSet>
    ''' <remarks>by Sean.Lin on 2013-8-26</remarks>
    Public Overrides Property BackColor() As Color
        Get
            Return ComboBox1.BackColor
        End Get
        Set(ByVal value As Color)
            ComboBox1.BackColor = value
        End Set
    End Property

    ''' <summary>
    ''' ComboBox是否呈現下拉
    ''' </summary>
    ''' <value><c>true</c> if [dropped down]; otherwise, <c>false</c>.</value>
    Public Property DroppedDown() As Boolean
        Get
            Return ComboBox1.DroppedDown
        End Get
        Set(ByVal value As Boolean)
            ComboBox1.DroppedDown = value
        End Set
    End Property
#End Region

#End Region

#Region "初始化設定函數"
    ''' <summary>
    ''' Initializes a new instance of the <see cref="UCLComboBoxUC"/> class.
    ''' </summary>
    Public Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ''設定成共用的字型
        'Me.Font = ControlFont

        'ComboBox1.Font = AppConfigUtil.ControlFont

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

#Region "     初始化下拉式選單 - Index "

    ''' <summary>
    ''' 初始化下拉式選單 - Index
    ''' </summary>
    ''' <param name="SourceDt">要顯示的資料 DataTable</param>
    ''' <param name="DisplayIndex">顯示在畫面上的資料行 Index</param>
    ''' <param name="ValueIndex">儲存在資料庫的資料行 Index</param>
    ''' <remarks>by Sean.Lin on 2013-7-25</remarks>
    Public Overloads Sub Initial(ByVal SourceDt As DataTable, ByVal DisplayIndex As Integer, ByVal ValueIndex As Integer)

        Try

            pvtdoFlag = False
            doTextChanged = False

            ''設定使用的文字格式
            'Me.Font = AppConfigUtil.ControlFont

            'ComboBox1.Font = AppConfigUtil.ControlFont

            '設定 Cbo 要顯示的 Table 來源
            Me.DataSource = SourceDt.Copy

            '儲存在資料庫的資料行 Index
            Me.uclValueIndex = ValueIndex

            '顯示在畫面上的資料行 Index
            Me.uclDisplayIndex = DisplayIndex

            '根據是否可以輸入，設定下拉式的選單性質
            '可輸入
            If _uclIsTextMode = True Then

                ComboBox1.DropDownStyle = ComboBoxStyle.DropDown

                '不可輸入
            Else

                ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList

            End If

            doTextChanged = True
            pvtdoFlag = True

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "初始化下拉式選單 - Index ", ex.ToString)

        End Try

    End Sub

#End Region

#Region "     初始化下拉式選單 - ColumnName "

    ''' <summary>
    ''' 初始化下拉式選單 - ColumnName
    ''' </summary>
    ''' <param name="SourceDt">要顯示的資料 DataTable</param>
    ''' <param name="DisplayColumnName">顯示在畫面上的資料行 名稱</param>
    ''' <param name="ValueColumnName">儲存在資料庫的資料行 名稱</param>
    ''' <remarks>by Sean.Lin on 2013-7-25</remarks>
    Public Overloads Sub Initial(ByVal SourceDt As DataTable, ByVal DisplayColumnName As String, ByVal ValueColumnName As String)

        Try

            Initial(SourceDt, SourceDt.Columns(DisplayColumnName).Ordinal, SourceDt.Columns(ValueColumnName).Ordinal)

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "初始化下拉式選單 - ColumnName", ex.ToString)

        End Try

    End Sub

#End Region

#Region "     初始化下拉式選單 - Pub Syscode 專用 "

    ''' <summary>
    ''' 初始化下拉式選單 - Pub Syscode 專用
    ''' </summary>
    ''' <param name="SourceDt">要顯示的資料 DataTable</param>
    ''' <remarks>by Sean.Lin on 2013-7-25</remarks>
    Public Overloads Sub Initial(ByVal SourceDt As DataTable)

        Try

            Initial(SourceDt, "Code_Name", "Code_ID")

        Catch ex As Exception

            ShowErrorMsg("CMMCMMB302", "初始化下拉式選單 - Pub Syscode 專用", ex.ToString)

        End Try

    End Sub

#End Region

#Region "     初始化下拉式選單 -DataGridView 專用 """

    ''' <summary>
    ''' Initial ComboBox Cell
    ''' </summary>
    ''' <param name="grid">Parent GridView</param>
    ''' <param name="dDB">dbDB</param>
    ''' <param name="dGrid">gridDS</param>
    ''' <param name="code">Combobox 代碼</param>
    ''' <param name="ColIndex">Col Index</param>
    ''' <param name="RowIndex">Row Index</param>
    Public Sub InitialComboBoxCell(ByRef grid As UCLDataGridViewUC, ByRef dDB As DataSet, ByRef dGrid As DataSet, ByRef code As String, ByVal ColIndex As Integer, ByVal RowIndex As Integer)

        cbo_dgv = grid
        cellRowIndex = RowIndex
        cellColIndex = ColIndex
        SelectedComboBoxCodeValue = code

        dsDB = dDB
        dsGrid = dGrid

        Try
            If cbo_dgv.MultiSelect Then
                OriSelectedComboBoxCodeValue = dDB.Tables(0).Rows(RowIndex).Item(ColIndex - 1).ToString.Trim()
            Else
                OriSelectedComboBoxCodeValue = dDB.Tables(0).Rows(RowIndex).Item(ColIndex).ToString.Trim()
            End If
        Catch ex As Exception
        End Try

    End Sub

    ''' <summary>
    ''' 初始化隨輸隨選Cell
    ''' grid: Parent GridView
    ''' dGrid:Grid來源資料
    ''' cboDS:ComboBox資料來源
    ''' colIndex:目前Cell的Column Index
    ''' code:ValueIndex
    ''' Name:DisplayIndex
    ''' </summary>
    ''' <param name="grid">The grid.</param>
    ''' <param name="dGrid">The d grid.</param>
    ''' <param name="cboDS">The cbo ds.</param>
    ''' <param name="colIndex">Index of the col.</param>
    ''' <param name="code">The code.</param>
    ''' <param name="name">The name.</param>
    Public Sub InitialGridCellValue(ByRef grid As UCLDataGridViewUC, ByRef dGrid As DataSet, ByVal cboDS As DataSet, ByVal colIndex As Integer, ByVal code As String, ByVal name As String)

        Dim pvtTextValue As String = ComboBox1.Text.Trim
        Dim pvtCodeValue As String = ""
        Dim pvtMatchFlag = False

        Try

            DataSource = cboDS.Tables(0).Copy()

            uclDisplayIndex = name
            uclValueIndex = code

            For j As Integer = 0 To dGrid.Tables(0).Rows.Count - 1

                If grid.uclTreeMode Then
                    TreeGridCol = 1
                End If

                If grid.MultiSelect Then

                    pvtTextValue = dGrid.Tables(0).Rows(j).Item(colIndex - 1 - TreeGridCol).ToString().Trim()
                    dGrid.Tables(0).Columns(colIndex - 1 - TreeGridCol).MaxLength = 100
                Else
                    pvtTextValue = dGrid.Tables(0).Rows(j).Item(colIndex - TreeGridCol).ToString().Trim()
                    dGrid.Tables(0).Columns(colIndex - TreeGridCol).MaxLength = 100
                End If

                For i = 0 To ComboBox1.DataSource.Rows.Count - 1

                    pvtCodeValue = _DataSource.Rows(i).Item("ValueField").ToString.Trim()

                    If pvtCodeValue = pvtTextValue Then
                        ComboBox1.SelectedIndex = i
                        pvtMatchFlag = True
                        If grid.MultiSelect Then
                            dGrid.Tables(0).Rows(j).Item(colIndex - 1 - TreeGridCol) = ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim()
                        Else
                            dGrid.Tables(0).Rows(j).Item(colIndex - TreeGridCol) = ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim()
                        End If

                        Exit For
                    End If
                Next

                If pvtMatchFlag = False Then

                    ComboBox1.Text = ""
                End If

                If IsNothing(ComboBox1.SelectedValue) Then
                    ComboBox1.SelectedValue = ""
                    _SelectedValue = ""
                Else
                    _SelectedValue = ComboBox1.SelectedValue.ToString.Trim()
                End If

            Next
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

#End Region

#End Region

#Region "內部函數"

#Region "     設定下拉選項值顯示欄位內容與選取值對應欄位 (內部使用) "

    ''' <summary>
    ''' 設定下拉選項值顯示欄位內容與選取值對應欄位 (內部使用)
    ''' </summary>
    ''' <param name="pvtTable">The PVT table.</param>
    ''' <param name="pvtColumnName">Name of the PVT column.</param>
    ''' <param name="pvtCutStr">The PVT cut string.</param>
    Private Sub SetComboField(ByVal pvtTable As DataTable, ByVal pvtColumnName As String, ByVal pvtCutStr As String)


        If Not pvtTable.Columns.Contains(pvtColumnName) Then
            Dim pvtColumn As DataColumn = pvtTable.Columns.Add(pvtColumnName)
        End If

        Dim pvtArrayList As ArrayList = CutString(pvtCutStr, ",")

        Dim iValue As Integer = 0
        If uclIsFirstItemEmpty Then
            iValue = 1
        End If

        'i這邊要注意~~
        Dim CodeMaxLength As Integer = 1

        Try
            For i = iValue To pvtTable.Rows.Count - 1
                If pvtArrayList.Count > 0 AndAlso pvtTable.Rows(i).Item(Integer.Parse(pvtArrayList.Item(0).ToString)).ToString().Trim.Length > CodeMaxLength Then
                    CodeMaxLength = pvtTable.Rows(i).Item(Integer.Parse(pvtArrayList.Item(0).ToString)).ToString().Trim.Length
                End If
            Next
        Catch ex As Exception
        End Try


        For i = iValue To pvtTable.Rows.Count - 1

            For j = 0 To pvtArrayList.Count - 1

                If j = 0 Then
                    pvtTable.Rows(i).Item(pvtColumnName) = pvtTable.Rows(i).Item(Integer.Parse(pvtArrayList.Item(j).ToString)).ToString.Trim
                Else
                    pvtTable.Rows(i).Item(pvtColumnName) = pvtTable.Rows(i).Item(pvtColumnName).ToString().Trim.PadRight(CodeMaxLength, " ") & " - " & pvtTable.Rows(i).Item(Integer.Parse(pvtArrayList.Item(j).ToString)).ToString().Trim
                End If

            Next
        Next

    End Sub

#End Region

#Region "     字串處理 (內部使用) "

    ''' <summary>
    ''' 字串處理 (內部使用)
    ''' pvtStr:處理的字串
    ''' pvtCutSysbol:處理的符號
    ''' </summary>
    ''' <param name="pvtStr">The PVT string.</param>
    ''' <param name="pvtCutSysbol">The PVT cut sysbol.</param>
    ''' <returns>處理後的字串陣列</returns>
    Private Function CutString(ByVal pvtStr As String, ByVal pvtCutSysbol As String) As ArrayList
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

#End Region

    '#Region "     設定Item最大Length (內部使用) "
    '    ''' <summary>
    '    ''' 設定Item最大Length
    '    ''' </summary>
    '    ''' <returns>System.Int32.</returns>
    '    Private Function ItemMaxLength() As Integer
    '        Dim length As Integer = ComboBox1.Width
    '        Dim Size As SizeF

    '        Dim g As System.Drawing.Graphics = CreateGraphics()

    '        Dim emSize As Single = 12.0

    '        If Screen.PrimaryScreen.Bounds.Width >= 1920 Then
    '            emSize = 16.0
    '        End If

    '        If ComboBox1.DataSource IsNot Nothing Then
    '            For i As Integer = 1 To ComboBox1.DataSource.Rows.Count - 1
    '                'Size = g.MeasureString(ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim(), AppConfigUtil.ControlFont)

    '                'If ComboBox1.Font.OriginalFontName <> "Courier New" Then
    '                '    Size = g.MeasureString(ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim(), AppConfigUtil.ControlFont)
    '                'Else
    '                '    Size = g.MeasureString(ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim(), New Font("Courier New", emSize, FontStyle.Regular))
    '                'End If

    '                If ComboBox1.Font.OriginalFontName <> "Consolas" Then
    '                    Size = g.MeasureString(ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim(), AppConfigUtil.ControlFont)
    '                Else
    '                    Size = g.MeasureString(ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim(), New Font("Consolas", emSize, FontStyle.Regular))
    '                End If


    '                If length < CInt(Size.Width) Then
    '                    length = CInt(Size.Width)
    '                End If
    '            Next
    '        End If

    '        Return length + 30
    '    End Function
    '#End Region

#Region "     設定Item最大Length (內部使用) "
    ''' <summary>
    ''' 設定Item最大Length
    ''' </summary>
    ''' <returns>System.Int32.</returns>
    Private Function ItemMaxLength() As Integer
        Dim length As Integer = ComboBox1.Width
        Dim Size As SizeF

        Dim g As System.Drawing.Graphics = CreateGraphics()

        If ComboBox1.DataSource IsNot Nothing Then
            For i As Integer = 1 To ComboBox1.DataSource.Rows.Count - 1
                Size = g.MeasureString(ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim(), AppConfigUtil.ControlFont)
                If length < CInt(Size.Width) Then
                    length = CInt(Size.Width)
                End If
            Next
        End If

        Return length
    End Function
#End Region

#End Region

#Region "Event"

    ''' <summary>
    ''' ComboBox離開的事件
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub UCLComboBoxUI_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        Dim pvtTextValue As String = ComboBox1.Text.Trim()
        Dim pvtCodeValue As String = ""
        Dim pvtMatchFlag = False

        Try


            If pvtCheckFlag Then
                For i = 0 To ComboBox1.DataSource.Rows.Count - 1
                    _SelectedValue = ""
                    pvtCodeValue = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim

                    If pvtCodeValue.Trim.ToUpper = pvtTextValue.Trim.ToUpper Then
                        _SelectedValue = pvtCodeValue
                        ComboBox1.SelectedIndex = i
                        pvtMatchFlag = True
                        Exit For
                    End If
                Next

                If pvtMatchFlag = False Then
                    If _uclShowMsg = True Then
                        MessageBox.Show("代碼：" & pvtTextValue & " 不存在")
                    End If
                    If uclIsAutoClear AndAlso Not uclIsTextMode Then

                        ComboBox1.Text = ""

                    End If

                End If

                pvtCheckFlag = False

            End If

            If IsNothing(ComboBox1.SelectedValue) Then

                If Not uclIsAutoClear Then
                    ComboBox1.SelectedValue = ""
                    _SelectedValue = ""
                End If

            Else
                _SelectedValue = ComboBox1.SelectedValue.ToString.Trim
            End If


            'gridview cell
            If cbo_dgv IsNot Nothing AndAlso Not FirstEnterGridCell Then

                'Dim ex As System.Windows.Forms.DataGridViewCellEventArgs

                If cbo_dgv.uclTreeMode Then
                    TreeGridCol = 1
                End If
                If cbo_dgv.MultiSelect Then
                    If ComboBox1.Text.Trim = "System.Data.DataRowView" Then
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ""
                    Else
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.Text.Trim

                        If uclIsTextMode Then
                            dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.Text.Trim
                        End If

                    End If

                Else

                    If ComboBox1.Text.Trim = "System.Data.DataRowView" Then
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ""
                    Else
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ComboBox1.Text.Trim

                        If uclIsTextMode Then
                            dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ComboBox1.Text.Trim
                        End If

                    End If
                End If

                Me.Visible = False

                'dsDB 存code
                For i = 0 To ComboBox1.DataSource.Rows.Count - 1

                    If ComboBox1.Text.Trim() = ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim() Then

                        If cbo_dgv.MultiSelect Then

                            dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()
                            SelectedComboBoxCodeValue = _DataSource.Rows(i).Item("ValueField").ToString.Trim()
                        Else

                            dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()
                            SelectedComboBoxCodeValue = _DataSource.Rows(i).Item("ValueField").ToString.Trim()

                        End If

                        'Console.WriteLine("UCLComboBoxUI_Leave")

                        If OriSelectedComboBoxCodeValue <> SelectedComboBoxCodeValue Then
                            'Console.WriteLine("ComboBoxCellSelectedValueChangedAndLeave")
                            RaiseEvent ComboBoxCellSelectedValueChangedAndLeave(cellRowIndex, cellColIndex)
                        End If

                        Exit For

                    End If

                Next

                If cbo_dgv.AllowUserToAddRows Then
                    If cellRowIndex = dsGrid.Tables(0).Rows.Count - 1 AndAlso ComboBox1.Text.Trim <> "" Then
                        cbo_dgv.AddNewRow()
                    End If

                End If
            End If
        Catch ex As Exception
            UclSaveClientLog(Me.Name, "UCLComboBoxUC-UCLComboBoxUI_LeaveError-" & ex.ToString)
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' ComboBox SelectedIndexChanged 的事件
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        UCLScreenUtil.Lock(Me)

        Try

            Try
                If pvtdoFlag Then
                    If cbo_dgv IsNot Nothing AndAlso Me.Visible Then

                        If mgrComboBox Is Nothing Then
                            mgrComboBox = EventManager.getInstance
                        End If

                        If ComboBox1.SelectedValue Is DBNull.Value Then
                            mgrComboBox.RaiseUclOpenWindowValue(Me.Name, cbo_dgv.CurrentCell.RowIndex.ToString, cbo_dgv.CurrentCell.ColumnIndex.ToString, "")
                        Else
                            mgrComboBox.RaiseUclOpenWindowValue(Me.Name, cbo_dgv.CurrentCell.RowIndex.ToString, cbo_dgv.CurrentCell.ColumnIndex.ToString, ComboBox1.SelectedValue)
                        End If

                    End If
                    RaiseEvent SelectedIndexChanged(sender, e)
                End If
            Catch ex As Exception
                UclSaveClientLog(Me.Name, "UCLComboBoxUC-SelectedIndexChangedError-RaiseEvent-" & ex.ToString)
            End Try

            If Not doTextChanged Then
                Exit Sub
            End If

            pvtdoFlag = True

            If cbo_dgv IsNot Nothing AndAlso Not FirstEnterGridCell Then
                '  ComboBox1.Text = cbo_dgv.CurrentCell.Value
                If cbo_dgv.uclTreeMode Then
                    TreeGridCol = 1
                End If

                If cbo_dgv.MultiSelect Then

                    dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.Text

                Else

                    dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ComboBox1.Text

                End If

                Me.Visible = False

                'dsDB 存code
                For i = 0 To ComboBox1.DataSource.Rows.Count - 1
                    If ComboBox1.Text.Trim() = ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim() Then
                        If cbo_dgv.MultiSelect Then
                            dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()
                        Else
                            dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()
                        End If
                        'Console.WriteLine("ComboBox1_SelectedIndexChanged")
                        SelectedComboBoxCodeValue = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()
                        Exit For
                    End If

                Next

                cbo_dgv.doCellValueChange = False

                If ComboBox1.Text.Trim.Length = 1 Then
                    cbo_dgv.dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = ""
                ElseIf ComboBox1.Text.Trim.Length > 1 Then
                    cbo_dgv.dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = ComboBox1.Text.Trim.Substring(0, 1)
                Else
                    cbo_dgv.dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = "1"
                End If

                cbo_dgv.doCellValueChange = True

                cbo_dgv.dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = ComboBox1.Text.Trim


                If cbo_dgv.AllowUserToAddRows Then
                    If cellRowIndex = dsGrid.Tables(0).Rows.Count - 1 Then
                        cbo_dgv.AddNewRow()
                    End If

                End If

            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            UclSaveClientLog(Me.Name, "UCLComboBoxUC-SelectedIndexChangedError-" & ex.ToString)
        Finally
            UCLScreenUtil.UnLock(Me)
        End Try
    End Sub
    ''' <summary>
    ''' Handles the TextChanged event of the ComboBox1 control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub ComboBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged

        RaiseEvent TextChanged(sender, e)

        If Not doTextChanged Then
            Exit Sub
        End If

        pvtCheckFlag = True
        Me.BackColor = System.Drawing.SystemColors.Window

        If ComboBox1.Focused AndAlso cbo_dgv IsNot Nothing AndAlso FirstEnterGridCell Then
            FirstEnterGridCell = False
        End If
    End Sub

    ''' <summary>
    ''' 設定pvtCheckFlag
    ''' </summary>
    ''' <param name="Value">pvtCheckFlag value</param>
    Public Sub SetPvtCheckFlag(ByVal Value As Boolean)
        pvtCheckFlag = Value
    End Sub

    ''' <summary>
    ''' bombobox Cell 按下enter 時
    ''' </summary>
    Public Sub cellPressEnter()
        Try

            If cbo_dgv IsNot Nothing Then

                Dim pvtTextValue As String = ComboBox1.Text.Trim()
                Dim pvtCodeValue As String = ""
                Dim pvtMatchFlag = False

                If cbo_dgv.uclTreeMode Then
                    TreeGridCol = 1
                End If

                If pvtCheckFlag Then
                    For i = 0 To _DataSource.Rows.Count - 1

                        pvtCodeValue = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim

                        If pvtCodeValue.Trim.ToUpper = pvtTextValue.Trim.ToUpper Then
                            ComboBox1.SelectedIndex = i
                            pvtMatchFlag = True
                            Exit For
                        End If
                    Next

                    If pvtMatchFlag = False Then
                        If _uclShowMsg = True Then
                            MessageBox.Show("代碼：" & pvtTextValue & " 不存在")
                        End If

                        If uclIsAutoClear AndAlso Not uclIsTextMode Then
                            ComboBox1.Text = ""
                        End If

                    End If

                    pvtCheckFlag = False

                End If

                If IsNothing(ComboBox1.SelectedValue) Then
                    ComboBox1.SelectedValue = ""
                    _SelectedValue = ""
                Else
                    _SelectedValue = ComboBox1.SelectedValue.ToString.Trim
                End If

                'gridview cell
                If cbo_dgv IsNot Nothing AndAlso Not FirstEnterGridCell Then

                    If cbo_dgv.MultiSelect Then
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.Text

                    Else
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ComboBox1.Text

                    End If

                    Me.Visible = False

                    'dsDB 存code
                    For i = 0 To ComboBox1.DataSource.Rows.Count - 1

                        If ComboBox1.Text.Trim() = ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim() Then

                            If cbo_dgv.MultiSelect Then

                                dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()

                            Else

                                dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()

                            End If

                            SelectedComboBoxCodeValue = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()
                        End If

                    Next

                    If cbo_dgv.AllowUserToAddRows Then
                        If cellRowIndex = dsGrid.Tables(0).Rows.Count - 1 Then
                            cbo_dgv.AddNewRow()
                        End If

                    End If
                End If

            End If
            Me.Visible = False
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' ProcessCmdKey
    ''' </summary>
    ''' <param name="msg">以傳址方式傳遞的 <see cref="T:System.Windows.Forms.Message" />，表示要處理的視窗訊息。</param>
    ''' <param name="keyData">其中一個 <see cref="T:System.Windows.Forms.Keys" /> 值，表示要處理的按鍵。</param>
    ''' <returns>如果字元由控制項處理，為 true，否則為 false。</returns>
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        Try

            Select Case keyData

                Case Keys.Escape, Keys.Left, Keys.Right, Keys.Up, Keys.Down
                    If cbo_dgv IsNot Nothing Then
                        Me.Visible = False
                    End If

                Case Keys.OemPeriod, Keys.Oem7

                    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Not Keys.Shift Then
                        Return True
                    End If

                Case Keys.Enter
                    Return False
                Case Keys.Shift
                    Return False

                Case Keys.Space

                    If cbo_dgv IsNot Nothing Then
                        If InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("美") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("英") Then

                            Dim pos As Integer = ComboBox1.SelectionStart
                            ComboBox1.Text = ComboBox1.Text.Substring(0, ComboBox1.SelectionStart) + " " + ComboBox1.Text.Substring(ComboBox1.SelectionStart)
                            pos += 1
                            ComboBox1.SelectionStart = pos
                        End If

                        Return True
                    End If
            End Select

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try

    End Function

    ''' <summary>
    ''' KeyDown
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        Try
            RaiseEvent KeyDown(sender, e)

            Select Case e.KeyCode

                'Case Windows.Forms.Keys.Left
                '    If cbo_dgv IsNot Nothing Then
                '        cbo_dgv.SetEditCell(cellRowIndex, cellColIndex - 1)
                '    End If

                'Case Windows.Forms.Keys.Right
                '    If cbo_dgv IsNot Nothing Then
                '        cbo_dgv.SetEditCell(cellRowIndex, cellColIndex + 1)
                '    End If

                Case Windows.Forms.Keys.Up
                    'If cbo_dgv IsNot Nothing Then

                    '    ' cbo_dgv.SetEditCell(cellRowIndex - 1, cellColIndex)
                    '    If ComboBox1.SelectedIndex > 0 Then
                    '        ComboBox1.SelectedIndex = ComboBox1.SelectedIndex - 1
                    '    End If

                    'End If
                Case Windows.Forms.Keys.Down
                    'If cbo_dgv IsNot Nothing Then

                    '    ' cbo_dgv.SetEditCell(cellRowIndex + 1, cellColIndex)

                    '    If ComboBox1.SelectedIndex < ComboBox1.Items.Count - 1 Then
                    '        ComboBox1.SelectedIndex = ComboBox1.SelectedIndex + 1
                    '    End If
                    'End If

            End Select

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' KeyUp
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
    Public Sub ComboBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyUp
        Try

            RaiseEvent KeyUp(sender, e)

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

                    '2016/10/03  不知道怎麼解，先Mark掉重複出現q的問題
                    'If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Not e.Shift AndAlso Not My.Computer.Keyboard.CapsLock Then
                    '    Fix10Char("q")
                    'ElseIf cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift AndAlso My.Computer.Keyboard.CapsLock Then
                    '    Fix10Char("q")
                    'End If
                    'end ms bug

                Case Windows.Forms.Keys.Enter
                    pvtCheckFlag = True
                    UCLComboBoxUI_Leave(sender, e)
                    ComboBox1.SelectionStart = ComboBox1.Text.Trim.Length

            End Select

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' fix ms bugs 無法輸入10個字元
    ''' </summary>
    ''' <param name="ch">修正的字元</param>
    Private Sub Fix10Char(ByVal ch As String)

        If InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("美") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("英") Then
            Dim pos As Integer = ComboBox1.SelectionStart
            ComboBox1.Text = ComboBox1.Text.Substring(0, ComboBox1.SelectionStart) + ch + ComboBox1.Text.Substring(ComboBox1.SelectionStart + ComboBox1.SelectionLength)
            ComboBox1.SelectionStart = pos + 1
        End If

    End Sub

    ''' <summary>
    ''' ComboBox SelectedValueChanged
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        pvtCheckFlag = False
    End Sub

    ''' <summary>
    ''' ComboBox Validated
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub ComboBox1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Validated
        RaiseEvent Validated(sender, e)
    End Sub

    ''' <summary>
    ''' ComboBox MouseMove
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    Private Sub ComboBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboBox1.MouseMove

        '  datagridview cell剛轉為comboox時~~ combobox text為current cell值
        If cbo_dgv IsNot Nothing AndAlso FirstEnterGridCell Then
            If cbo_dgv.CurrentCell.Value Is DBNull.Value Then
                ComboBox1.Text = ""
            Else
                ComboBox1.Text = cbo_dgv.CurrentCell.Value
            End If

            '此行不可刪
            FirstEnterGridCell = False
        End If
    End Sub

    ''' <summary>
    ''' SelectionChangeCommitted
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub ComboBox1_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectionChangeCommitted
        'SendKeys.Send("{Tab}")
        If IsNothing(ComboBox1.SelectedValue) Then
            ComboBox1.SelectedValue = ""
            _SelectedValue = ""
        Else
            _SelectedValue = ComboBox1.SelectedValue.ToString.Trim
        End If
    End Sub

    ''' <summary>
    ''' 設定ComboBox Cell Value
    ''' </summary>
    ''' <param name="grid">grid</param>
    ''' <param name="dDB">dbDS</param>
    ''' <param name="dGrid">gridDS</param>
    ''' <param name="Code">代碼</param>
    ''' <param name="RowIndex">Row Index</param>
    ''' <param name="ColIndex">Col Index</param>
    Public Sub SetComboBoxCellValue(ByRef grid As UCLDataGridViewUC, ByRef dDB As DataSet, ByRef dGrid As DataSet, ByRef Code As String, ByVal RowIndex As Integer, ByVal ColIndex As Integer)
        cbo_dgv = grid

        '  ComboBox1.Text = Code
        cellColIndex = ColIndex
        cellRowIndex = RowIndex

        dsDB = dDB
        dsGrid = dGrid

        Dim pvtTextValue As String = Code.Trim ' ComboBox1.Text.Trim()
        Dim pvtCodeValue As String = ""
        Dim pvtMatchFlag = False

        If Not doTextChanged Then
            Exit Sub
        End If

        If pvtTextValue = "" Then

            ComboBox1.Text = ""

            If cbo_dgv.MultiSelect Then

                If ComboBox1.Text.Trim = "System.Data.DataRowView" Then
                    dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ""

                Else
                    dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.Text

                End If

            Else
                If ComboBox1.Text.Trim = "System.Data.DataRowView" Then
                    dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ""

                Else
                    dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ComboBox1.Text

                End If

            End If

            For i = 0 To ComboBox1.DataSource.Rows.Count - 1

                If ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim() = "" Then
                    If cbo_dgv.MultiSelect Then
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()
                        SelectedComboBoxCodeValue = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()
                    Else
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()
                        SelectedComboBoxCodeValue = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()

                    End If

                    Exit For

                End If

            Next

            Me.Visible = False
            Exit Sub

        End If

        Try

            If grid.uclTreeMode Then
                TreeGridCol = 1
            End If

            If pvtCheckFlag Then
                For i = 0 To ComboBox1.DataSource.Rows.Count - 1
                    _SelectedValue = ""
                    pvtCodeValue = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim

                    If pvtCodeValue.Trim.ToUpper = pvtTextValue.Trim.ToUpper Then
                        _SelectedValue = pvtCodeValue
                        ComboBox1.SelectedIndex = i
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
                _SelectedValue = ComboBox1.SelectedValue.ToString.Trim
            End If

            'gridview cell
            If cbo_dgv IsNot Nothing AndAlso Not FirstEnterGridCell Then

                'cbo_dgv.CurrentCell = cbo_dgv.Rows(cellRowIndex).Cells(cellColIndex)

                If cbo_dgv.MultiSelect Then

                    If ComboBox1.Text.Trim = "System.Data.DataRowView" Then
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ""

                    Else
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.Text

                    End If

                Else
                    If ComboBox1.Text.Trim = "System.Data.DataRowView" Then
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ""

                    Else
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ComboBox1.Text

                    End If

                End If

                Me.Visible = False

                Dim Str As String = ""
                'dsDB 存code
                If ComboBox1.Text.Trim = "System.Data.DataRowView" Then
                    Str = ""
                Else
                    Str = ComboBox1.Text.Trim
                End If

                For i = 0 To ComboBox1.DataSource.Rows.Count - 1

                    If Str = ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim() Then
                        If cbo_dgv.MultiSelect Then
                            dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()
                            SelectedComboBoxCodeValue = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()
                        Else
                            dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()
                            SelectedComboBoxCodeValue = ComboBox1.DataSource.Rows(i).Item("ValueField").ToString.Trim()

                        End If

                        Exit For

                    End If

                Next

            End If

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Resize
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub UCLComboBoxUI_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        If UCLFormUtil.isResizeable(Me) Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
        Else
            Me.Height = 24
        End If

    End Sub

    ''' <summary>
    ''' ComboBox1_DropDown
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub ComboBox1_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        DropDownWidth = ItemMaxLength() + 8
        RaiseEvent DropDown(sender, e)
    End Sub

    ''' <summary>
    ''' UclSaveClientLog
    ''' </summary>
    Public Sub UclSaveClientLog(ByVal TaskUI As String, ByVal MsgStr As String)
        Try
            Dim uclService As IUclServiceManager = UclServiceManager.getInstance
            Dim resultDS As DataSet
            Dim dataDS As New DataSet

            dataDS.Tables.Add()

            dataDS.Tables(0).Columns.Add("Msg")
            dataDS.Tables(0).Columns.Add("Action")

            Dim row As DataRow
            row = dataDS.Tables(0).Rows.Add()

            row("Action") = "UclSaveClientLog"
            row("Msg") = TaskUI & "-" & MsgStr

            resultDS = uclService.DoUclAction(dataDS)

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub


#End Region

End Class