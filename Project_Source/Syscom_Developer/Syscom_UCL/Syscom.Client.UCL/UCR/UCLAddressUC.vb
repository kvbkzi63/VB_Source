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

Public Class UCLAddressUC

#Region "     全域變數宣告"

    Private _uclCbo1Width As Integer = 125
    Private _uclCbo2Width As Integer = 80
    Private _uclTxtWidth As Integer = 150

    Private _SelectedValue1 As String = ""
    Private _SelectedValue2 As String = ""

    Private _uclCbo1DisplayIndex As String = "0,1"
    Private _uclCbo1ValueIndex As String = "0"

    Private _uclCbo2DisplayIndex As String = "0,1"
    Private _uclCbo2ValueIndex As String = "0"

    Private _SelectedAreaCode As String = ""
    Private _SelectedPostalCode As String = ""
    Private _SelectedDistCode As String = ""
    Private _SelectedVilCode As String = ""

    Private _uclShowQueryBtn As Boolean = True

    Private AllVilDS As DataSet
    Private VilDS As DataSet
    Private pvtDS As DataSet
    Private _uclShowType = uclShowData.showDist
    Private _uclShow1Field = uclFieldData.Name
    Private _uclShow2Field = uclFieldData.Name
    Private _uclShowTreeViewField = uclFieldData.Name

    Dim uclACQ As IUclServiceManager = UclServiceManager.getInstance
    Dim WithEvents pvtReceiveMgr As EventManager = EventManager.getInstance '宣告EventManager
    Dim cbo1TxtOld As String = ""
    Dim cbo2TxtOld As String = ""

#End Region

#Region "     屬性設定"


    ''' <summary>
    ''' 顯示的資料
    ''' </summary>
    ''' <remarks></remarks>
    Enum uclShowData
        showDist = 1   '1:顯示行政區代碼
        showPostal = 2     '2:顯示郵遞區號代碼
        showArea = 3     '3:顯示戶籍地號代碼
    End Enum

    ''' <summary>
    ''' 顯示代碼或名稱
    ''' </summary>
    ''' <remarks></remarks>
    Enum uclFieldData
        Code = 1   '1:顯示代碼
        Name = 2     '2:顯示名稱
        CodeAndName = 3     '3:顯示名稱+代碼
    End Enum

    ''' <summary>
    ''' 資料類型
    ''' </summary>
    ''' <value>_uclShowType</value>
    ''' <returns>_uclShowType</returns>
    ''' <remarks></remarks>
    Public Property uclShowType() As uclShowData
        Get
            Return _uclShowType
        End Get
        Set(ByVal value As uclShowData)
            _uclShowType = value
        End Set
    End Property

    ''' <summary>
    ''' 顯示欄位1
    ''' </summary>
    ''' <value>_uclShow1Field</value>
    ''' <returns>_uclShow1Field</returns>
    ''' <remarks></remarks>
    Public Property uclShow1Field() As uclFieldData
        Get
            Return _uclShow1Field
        End Get
        Set(ByVal value As uclFieldData)
            _uclShow1Field = value
        End Set
    End Property

    ''' <summary>
    ''' 顯示欄位2
    ''' </summary>
    ''' <value>_uclShow2Field</value>
    ''' <returns>_uclShow2Field</returns>
    ''' <remarks></remarks>
    Public Property uclShow2Field() As uclFieldData
        Get
            Return _uclShow2Field
        End Get
        Set(ByVal value As uclFieldData)
            _uclShow2Field = value
        End Set
    End Property

    ''' <summary>
    ''' 顯示Tree欄位
    ''' </summary>
    ''' <value>_uclShowTreeViewField</value>
    ''' <returns>_uclShowTreeViewField</returns>
    ''' <remarks></remarks>
    Public Property uclShowTreeViewField() As uclFieldData
        Get
            Return _uclShowTreeViewField
        End Get
        Set(ByVal value As uclFieldData)
            _uclShowTreeViewField = value
        End Set
    End Property

    ''' <summary>
    ''' 區欄寬
    ''' </summary>
    ''' <value>_uclCbo1Width</value>
    ''' <returns>_uclCbo1Width</returns>
    ''' <remarks></remarks>
    Public Property uclCbo1Width() As Integer
        Get
            Return _uclCbo1Width
        End Get
        Set(ByVal value As Integer)
            _uclCbo1Width = value

            cbo_Area.Width = value
        End Set
    End Property

    ''' <summary>
    ''' 里欄寬
    ''' </summary>
    ''' <value>_uclCbo2Width</value>
    ''' <returns>_uclCbo2Width</returns>
    ''' <remarks></remarks>
    Public Property uclCbo2Width() As Integer
        Get
            Return _uclCbo2Width
        End Get
        Set(ByVal value As Integer)
            _uclCbo2Width = value

            cbo_Vil.Width = value
        End Set
    End Property

    ''' <summary>
    ''' 地址寬度
    ''' </summary>
    ''' <value>_uclTxtWidth</value>
    ''' <returns>_uclTxtWidth</returns>
    ''' <remarks></remarks>
    Public Property uclTxtWidth() As Integer
        Get
            Return _uclTxtWidth
        End Get
        Set(ByVal value As Integer)
            _uclTxtWidth = value

            Txt_Address.Width = value
        End Set
    End Property

    ''' <summary>
    ''' 區選擇值
    ''' </summary>
    ''' <value>_SelectedValue1</value>
    ''' <returns>_SelectedValue1</returns>
    ''' <remarks></remarks>
    Public Property SelectedValue1() As String
        Get
            Return _SelectedValue1
        End Get
        Set(ByVal value As String)
            _SelectedValue1 = value
            '   Cbo_Postal.SelectedValue = _SelectedValue
            SetCbo1Text(value)
        End Set
    End Property

    ''' <summary>
    ''' 里選擇值
    ''' </summary>
    ''' <value>_SelectedValue2</value>
    ''' <returns>_SelectedValue2</returns>
    ''' <remarks></remarks>
    Public Property SelectedValue2() As String
        Get
            Return _SelectedValue2
        End Get
        Set(ByVal value As String)
            _SelectedValue2 = value
            '   Cbo_Postal.SelectedValue = _SelectedValue
            SetCbo2Text(value)
        End Set
    End Property

    ''' <summary>
    ''' 地址
    ''' </summary>
    ''' <value>Txt_Address</value>
    ''' <returns>Txt_Address</returns>
    ''' <remarks></remarks>
    Public Property TxtAddress() As String
        Get
            Return Txt_Address.Text
        End Get
        Set(ByVal value As String)
            Txt_Address.Text = value
        End Set
    End Property

    ''' <summary>
    ''' 是否顯示查詢按鈕
    ''' </summary>
    ''' <value>_uclShowQueryBtn</value>
    ''' <returns>_uclShowQueryBtn</returns>
    ''' <remarks></remarks>
    Public Property uclShowQueryBtn() As Boolean
        Get
            Return _uclShowQueryBtn
        End Get
        Set(ByVal value As Boolean)
            _uclShowQueryBtn = value '

            'Btn_AreaCodeQuery.Visible = value

        End Set
    End Property

    ''' <summary>
    ''' 戶籍地碼
    ''' </summary>
    ''' <value>_SelectedAreaCode</value>
    ''' <returns>_SelectedAreaCode</returns>
    ''' <remarks></remarks>
    Public Property SelectedAreaCode As String
        Get
            Return _SelectedAreaCode
        End Get
        Set(ByVal value As String)
            _SelectedAreaCode = value
        End Set
    End Property

    ''' <summary>
    ''' 郵遞區號
    ''' </summary>
    ''' <value>_SelectedPostalCode</value>
    ''' <returns>_SelectedPostalCode</returns>
    ''' <remarks></remarks>
    Public Property SelectedPostalCode As String
        Get
            Return _SelectedPostalCode
        End Get
        Set(ByVal value As String)
            _SelectedPostalCode = value
        End Set
    End Property

    ''' <summary>
    ''' 區碼
    ''' </summary>
    ''' <value>_SelectedDistCode</value>
    ''' <returns>_SelectedDistCode</returns>
    ''' <remarks></remarks>
    Public Property SelectedDistCode As String
        Get
            Return _SelectedDistCode
        End Get
        Set(ByVal value As String)
            _SelectedDistCode = value
        End Set
    End Property

    ''' <summary>
    ''' 里代碼
    ''' </summary>
    ''' <value>_SelectedVilCode</value>
    ''' <returns>_SelectedVilCode</returns>
    ''' <remarks></remarks>
    Public Property SelectedVilCode As String
        Get
            Return _SelectedVilCode
        End Get
        Set(ByVal value As String)
            _SelectedVilCode = value
        End Set
    End Property

    ''' <summary>
    ''' 按鈕名稱
    ''' </summary>
    ''' <value>btn_Area.Name</value>
    ''' <returns>btn_Area.Name</returns>
    ''' <remarks></remarks>
    Public Property BtnAreaName As String
        Get
            Return btn_Area.Name
        End Get
        Set(ByVal value As String)
            btn_Area.Name = value
        End Set
    End Property


    ''' <summary>
    ''' 里按鈕名稱
    ''' </summary>
    ''' <value>btn_Vil.Name</value>
    ''' <returns>btn_Vil.Name</returns>
    ''' <remarks></remarks>
    Public Property BtnVilName As String
        Get
            Return btn_Vil.Name
        End Get
        Set(ByVal value As String)
            btn_Vil.Name = value
        End Set
    End Property

#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "

    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    ''' <summary>
    '''清除畫面 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        Try
            If cbo_Area.Items.Count > 0 Then
                cbo_Area.SelectedIndex = 0
            End If

            If cbo_Vil.Items.Count > 0 Then
                cbo_Vil.SelectedIndex = 0
            End If

            Txt_Address.Text = ""

            SelectedDistCode = ""
            SelectedPostalCode = ""
            SelectedVilCode = ""
            TxtAddress = ""

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 初始化設定
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub Initial()

        cbo_Area.DropDownWidth = 180

        Try

            If pvtDS Is Nothing Then
                queryAreaPostal()
            End If
            If cbo_Area.Items.Count = 0 Then


                '加入一個空白項目
                cbo_Area.Items.Add("")

                For i As Integer = 0 To pvtDS.Tables(0).Rows.Count - 1
                    '1:顯示郵遞區號代碼  col(3):Postal_Code ,col(4): Postal_Name
                    If _uclShowType = uclShowData.showDist Then
                        If uclShow1Field = uclFieldData.Code Then
                            cbo_Area.Items.Add(pvtDS.Tables(0).Rows(i).Item(9).ToString().Trim())
                        ElseIf uclShow1Field = uclFieldData.Name Then
                            'cbo_Area.Items.Add(pvtDS.Tables(0).Rows(i).Item(8).ToString().Trim() & pvtDS.Tables(0).Rows(i).Item(10).ToString().Trim())
                            cbo_Area.Items.Add(pvtDS.Tables(0).Rows(i).Item(1).ToString().Trim())
                        ElseIf uclShow1Field = uclFieldData.CodeAndName Then
                            cbo_Area.Items.Add(pvtDS.Tables(0).Rows(i).Item(9).ToString().Trim() & " - " & pvtDS.Tables(0).Rows(i).Item(10).ToString().Trim())

                        End If

                    ElseIf _uclShowType = uclShowData.showPostal Then
                        If uclShow1Field = uclFieldData.Code Then
                            cbo_Area.Items.Add(pvtDS.Tables(0).Rows(i).Item(3).ToString().Trim())
                        ElseIf uclShow1Field = uclFieldData.Name Then
                            cbo_Area.Items.Add(pvtDS.Tables(0).Rows(i).Item(4).ToString().Trim())
                        ElseIf uclShow1Field = uclFieldData.CodeAndName Then
                            cbo_Area.Items.Add(pvtDS.Tables(0).Rows(i).Item(3).ToString().Trim() & " - " & pvtDS.Tables(0).Rows(i).Item(4).ToString().Trim())

                        End If

                    ElseIf _uclShowType = uclShowData.showArea Then
                        If uclShow1Field = uclFieldData.Code Then
                            cbo_Area.Items.Add(pvtDS.Tables(0).Rows(i).Item(0).ToString().Trim())
                        ElseIf uclShow1Field = uclFieldData.Name Then
                            cbo_Area.Items.Add(pvtDS.Tables(0).Rows(i).Item(1).ToString().Trim())
                        ElseIf uclShow1Field = uclFieldData.CodeAndName Then
                            cbo_Area.Items.Add(pvtDS.Tables(0).Rows(i).Item(0).ToString().Trim() & " - " & pvtDS.Tables(0).Rows(i).Item(1).ToString().Trim())

                        End If
                    End If

                Next

            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try


    End Sub

    ''' <summary>
    '''  設定下拉選項值顯示欄位內容與選取值對應欄位
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetComboField(ByVal pvtTable As DataTable, ByVal pvtColumnName As String, ByVal pvtCutStr As String)
        Try


            Dim pvtColumn As DataColumn = pvtTable.Columns.Add(pvtColumnName)
            Dim pvtArrayList As ArrayList = CutString(pvtCutStr, ",")


            For i = 1 To pvtTable.Rows.Count - 1


                For j = 0 To pvtArrayList.Count - 1

                    If j = 0 Then

                        pvtTable.Rows(i).Item(pvtColumnName) = pvtTable.Rows(i).Item(Integer.Parse(pvtArrayList.Item(j).ToString))

                    Else

                        pvtTable.Rows(i).Item(pvtColumnName) += "-" & pvtTable.Rows(i).Item(Integer.Parse(pvtArrayList.Item(j).ToString))

                    End If

                Next
            Next
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    '''  字串處理
    ''' pvtStr:處理的字串
    ''' pvtCutSysbol:處理的符號
    ''' </summary>
    ''' <returns>處理後的字串陣列</returns>
    ''' <remarks></remarks>''' 
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

    ''' <summary>
    ''' 設定地址
    ''' </summary>
    ''' <param name="cbo1CodeValue">區值</param>
    ''' <param name="cbo2CodeValue">里值</param>
    ''' <param name="showType">顯示類型</param>
    ''' <remarks></remarks>
    Public Sub SetCboValue(ByVal cbo1CodeValue As String, ByVal cbo2CodeValue As String, ByVal showType As uclShowData)
        Try
            If cbo2CodeValue = "" Then
                cbo_Vil.Items.Clear()
            End If

            If cbo1CodeValue = "" Then
                cbo_Area.SelectedIndex = 0
                Exit Sub
            End If

            For i As Integer = 0 To pvtDS.Tables(0).Rows.Count - 1
                If showType = uclShowData.showDist AndAlso pvtDS.Tables(0).Rows(i).Item("Dist_Code").ToString.Trim = cbo1CodeValue Then
                    cbo_Area.SelectedIndex = i + 1
                    Exit For
                ElseIf showType = uclShowData.showArea AndAlso pvtDS.Tables(0).Rows(i).Item("Area_Code").ToString.Trim = cbo1CodeValue Then
                    cbo_Area.SelectedIndex = i + 1
                    Exit For
                ElseIf showType = uclShowData.showPostal AndAlso pvtDS.Tables(0).Rows(i).Item("Postal_Code").ToString.Trim = cbo1CodeValue Then
                    cbo_Area.SelectedIndex = i + 1
                    Exit For
                End If
            Next


            For i As Integer = 0 To VilDS.Tables(0).Rows.Count - 1
                If showType = uclShowData.showDist AndAlso VilDS.Tables(0).Rows(i).Item("Vil_Code").ToString.Trim = cbo2CodeValue Then
                    cbo_Vil.SelectedIndex = i + 1
                    Exit For
                End If
            Next

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

    End Sub

#End Region

#Region "     事件集合 "

    ''' <summary>
    ''' cbo_Area_Leave
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbo_Area_Leave(sender As Object, e As EventArgs) Handles cbo_Area.Leave
        If IsNumeric(cbo_Area.Text) Then
            SetCboValue(cbo_Area.Text, "", uclShowData.showArea)
        End If
    End Sub

    ''' <summary>
    ''' cbo_Area_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbo_Area_KeyUp(sender As Object, e As KeyEventArgs) Handles cbo_Area.KeyUp
        Select Case e.KeyCode
            Case Windows.Forms.Keys.Enter
                cbo_Area_Leave(sender, e)
                cbo_Vil.Focus()
        End Select
    End Sub

    ''' <summary>
    ''' 區文字
    ''' </summary>
    ''' <param name="text">區文字</param>
    ''' <remarks></remarks>
    Private Sub SetCbo1Text(ByVal text As String)

        cbo_Area.Text = text
    End Sub

    ''' <summary>
    ''' 里文字
    ''' </summary>
    ''' <param name="text">里文字</param>
    ''' <remarks></remarks>
    Private Sub SetCbo2Text(ByVal text As String)

        cbo_Vil.Text = text
    End Sub

    ''' <summary>
    ''' cbo_Area_SelectedIndexChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbo_Area_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Area.SelectedIndexChanged
        Try
            If pvtDS Is Nothing Then
                queryAreaPostal()
            End If

            cbo_Vil.Items.Clear()
            '加入一個空白項目
            cbo_Vil.Items.Add("")

            SelectedAreaCode = ""
            SelectedPostalCode = ""
            SelectedDistCode = ""
            SelectedVilCode = ""
            btn_Vil.uclAreaCode = ""

            If cbo2TxtOld <> "" AndAlso Txt_Address.Text.Contains(cbo2TxtOld) Then
                Txt_Address.Text = Txt_Address.Text.Replace(cbo2TxtOld, "")
                cbo2TxtOld = ""
                cbo_Vil.Text = ""
            End If

            If cbo_Area.SelectedIndex = 0 Then
                If cbo1TxtOld <> "" AndAlso Txt_Address.Text.Contains(cbo1TxtOld) Then
                    Txt_Address.Text = Txt_Address.Text.Replace(cbo1TxtOld, "")
                    cbo1TxtOld = ""
                End If
                Exit Sub
            End If


            Dim code1 As String = ""
            Dim code2 As String = ""
            Dim type As String = ""

            Dim txtAddr As String = ""
            If _uclShowType = uclShowData.showDist Then
                type = "1"
                code1 = pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("Gov_County_Code").ToString.Trim
                code2 = pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("Dist_Code").ToString.Trim
                txtAddr = pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("Area_Name").ToString.Trim ' pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("Gov_County_Name").ToString.Trim & pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("Dist_Name").ToString.Trim

            ElseIf _uclShowType = uclShowData.showPostal Then
                type = "2"
                code1 = pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("Postal_Code").ToString.Trim
                'code2 = pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("").ToString.Trim
                txtAddr = pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("Postal_Name").ToString.Trim

            ElseIf _uclShowType = uclShowData.showArea Then
                type = "3"
                code1 = pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("Area_Code").ToString.Trim
                'code2 = pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("").ToString.Trim
                txtAddr = pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("Area_Name").ToString.Trim

            End If

            If code1 = "" Then
                Exit Sub
            End If

            SelectedAreaCode = pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("Area_Code").ToString.Trim
            SelectedPostalCode = pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("Postal_Code").ToString.Trim
            SelectedDistCode = pvtDS.Tables(0).Rows(cbo_Area.SelectedIndex - 1).Item("Dist_Code").ToString.Trim

            btn_Vil.uclAreaCode = SelectedAreaCode

            If Txt_Address.Text = "" Then
                Txt_Address.Text = txtAddr
            ElseIf cbo1TxtOld <> "" AndAlso Txt_Address.Text.Contains(cbo1TxtOld) Then
                Txt_Address.Text = Txt_Address.Text.Replace(cbo1TxtOld, txtAddr)

            ElseIf Txt_Address.Text <> "" Then
                Txt_Address.Text = txtAddr & Txt_Address.Text
            End If

            cbo1TxtOld = txtAddr

            VilDS = uclACQ.queryUclPUBAreaCodeGovVilCodeName(code1, code2, type)

            For i As Integer = 0 To VilDS.Tables(0).Rows.Count - 1
                If uclShow2Field = uclFieldData.Code Then
                    cbo_Vil.Items.Add(VilDS.Tables(0).Rows(i).Item(11).ToString().Trim())
                ElseIf uclShow2Field = uclFieldData.Name Then
                    cbo_Vil.Items.Add(VilDS.Tables(0).Rows(i).Item(12).ToString().Trim())
                ElseIf uclShow2Field = uclFieldData.CodeAndName Then
                    cbo_Vil.Items.Add(VilDS.Tables(0).Rows(i).Item(11).ToString().Trim() & " - " & VilDS.Tables(0).Rows(i).Item(12).ToString().Trim())

                End If

            Next

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' cbo_Vil_SelectedIndexChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbo_Vil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Vil.SelectedIndexChanged
        Try

            SelectedVilCode = ""
            If cbo_Vil.SelectedIndex = 0 Then
                If cbo2TxtOld <> "" AndAlso Txt_Address.Text.Contains(cbo2TxtOld) Then
                    Txt_Address.Text = Txt_Address.Text.Replace(cbo2TxtOld, "")
                    cbo2TxtOld = ""
                End If
                Exit Sub
            End If

            Dim txtAddr As String = ""
            txtAddr = VilDS.Tables(0).Rows(cbo_Vil.SelectedIndex - 1).Item("Vil_Name").ToString.Trim
            SelectedVilCode = VilDS.Tables(0).Rows(cbo_Vil.SelectedIndex - 1).Item("Vil_Code").ToString.Trim

            If Txt_Address.Text = "" Then
                Txt_Address.Text = txtAddr
            ElseIf cbo2TxtOld <> "" AndAlso Txt_Address.Text.Contains(cbo2TxtOld) Then
                Txt_Address.Text = Txt_Address.Text.Replace(cbo2TxtOld, txtAddr)

            ElseIf Txt_Address.Text <> "" Then
                Txt_Address.Text = Txt_Address.Text & txtAddr
            End If

            cbo2TxtOld = txtAddr

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Btn_AreaCodeQuery_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn_AreaCodeQuery_Click(sender As Object, e As EventArgs)
        If AllVilDS Is Nothing Then
            AllVilDS = uclACQ.queryUclPostalAreaAllNew()
        End If

        'Dim pvtAreaList As UCLAreaOpenWindowUC = New UCLAreaOpenWindowUC(AllVilDS, Me.Name)
        'pvtAreaList.Location = New Point(MousePosition.X, MousePosition.Y)
        'pvtAreaList.ShowDialog()

        Dim pvtAreaList As UCLDistOpenWindowUC = New UCLDistOpenWindowUC(AllVilDS, Me, pvtDS.Tables(0).Rows.Count, uclShowTreeViewField, uclShowType)
        pvtAreaList.Location = New Point(MousePosition.X, MousePosition.Y)
        pvtAreaList.ShowDialog()

    End Sub

    ''' <summary>
    ''' cbo_Area_DropDown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbo_Area_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_Area.DropDown


    End Sub

    ''' <summary>
    ''' 進行戶籍地與郵遞區號查詢
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub queryAreaPostal()
        Try

            pvtDS = uclACQ.queryUclPostalAreaAll()

            Dim Area_Code As String = ""
            Dim Dist_Code As String = ""

            '處理特殊情況
            For i As Integer = pvtDS.Tables(0).Rows.Count - 1 To 0 Step -1

                Area_Code = pvtDS.Tables(0).Rows(i).Item("Area_Code").ToString.Trim
                Dist_Code = pvtDS.Tables(0).Rows(i).Item("Dist_Code").ToString.Trim
                '新竹
                If Area_Code = "1200" AndAlso (Dist_Code = "1001802" OrElse Dist_Code = "1001803") Then
                    pvtDS.Tables(0).Rows.RemoveAt(i)
                End If

                If Area_Code = "1201" AndAlso (Dist_Code = "1001802" OrElse Dist_Code = "1001803") Then
                    pvtDS.Tables(0).Rows.RemoveAt(i)
                End If

                If Area_Code = "1204" AndAlso (Dist_Code = "1001801" OrElse Dist_Code = "1001803") Then
                    pvtDS.Tables(0).Rows.RemoveAt(i)
                End If

                If Area_Code = "1205" AndAlso (Dist_Code = "1001801" OrElse Dist_Code = "1001802") Then
                    pvtDS.Tables(0).Rows.RemoveAt(i)
                End If
                '=================================================================================================
                '嘉義
                If Area_Code = "2200" AndAlso Dist_Code = "1002002" Then
                    pvtDS.Tables(0).Rows.RemoveAt(i)
                End If

                If Area_Code = "2201" AndAlso Dist_Code = "1002002" Then
                    pvtDS.Tables(0).Rows.RemoveAt(i)
                End If

                If Area_Code = "2202" AndAlso Dist_Code = "1002001" Then
                    pvtDS.Tables(0).Rows.RemoveAt(i)
                End If
            Next

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
#Region "查詢收到的Event"

    ''' <summary>
    ''' 處理看診醫師,病歷號Button選擇,轉診醫院查詢結果
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub doUcrOpenWindowValue(ByVal uclName As String, ByVal uclCodeValue1 As String, ByVal uclCodeValue2 As String, ByVal uclCodeName As String) Handles pvtReceiveMgr.UclOpenWindowValue
        Select Case uclName

            Case ParentForm.Name & Me.Name & "Area"
                SetCboValue(uclCodeValue2, "", uclShowData.showDist)
            Case ParentForm.Name & Me.Name & "Vil"
                SetCboValue(uclCodeValue2, uclCodeValue1, uclShowData.showDist)
            Case ParentForm.Name & btn_Area.Name
                SetCboValue(uclCodeValue2, "", uclShowData.showDist)
            Case ParentForm.Name & btn_Vil.Name
                SetCboValue(uclCodeValue2, uclCodeValue1, uclShowData.showDist)

        End Select

    End Sub


#End Region

#End Region
End Class
