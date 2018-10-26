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

Public Class UCLCensusUC


#Region "全域變數宣告"

    Private _DataSource As DataTable = New DataTable()
    Private _SelectedValue As String = ""
    Private _uclDisplayIndex As String = "0,1"
    Private _uclValueIndex As String = "0"

    Private _uclXPosition As Integer = 225
    Private _uclYPosition As Integer = 120

    Private _uclCboWidth As Integer = 200

    Private _BackColor As Color = Color.White
    'Private _Text As String = ""

    Private _doFlag As Boolean = True

    Dim pvtCheckFlag = False
    Dim treeViewFlag = False
    Dim pvtDS As DataSet = Nothing
    Dim firstInitial As Boolean = True
    Dim nameStr As String = ""
    Private _uclShowType = uclShowData.showArea

    Private _SelectAreaCode As String = ""
    Private _SelectAreaName As String = ""

    Private _SelectPostalCode As String = ""
    Private _SelectPostalName As String = ""

    ' Private mgr As EventManager = EventManager.getInstance   '宣告EventManager
    Dim WithEvents pvtReceiveTreeMgr As EventManager = EventManager.getInstance
    Dim ParentName As String = "X"
    Private _IsUsePUBAreaCodeN As Boolean = False

#End Region


#Region "屬性設定"

    Public Property IsUsePUBAreaCodeN() As Boolean
        Get
            Return _IsUsePUBAreaCodeN
        End Get
        Set(ByVal value As Boolean)
            _IsUsePUBAreaCodeN = value
        End Set
    End Property

    Public Property SelectAreaCode() As String
        Get
            Return _SelectAreaCode
        End Get
        Set(ByVal value As String)
            _SelectAreaCode = value
        End Set
    End Property

    Public Property uclIsShowBtn() As Boolean
        Get
            Return Btn_AreaCodeQuery.Visible
        End Get
        Set(ByVal value As Boolean)

            Btn_AreaCodeQuery.Visible = value

        End Set
    End Property

    Public Property SelectAreaName() As String
        Get
            Return _SelectAreaName
        End Get
        Set(ByVal value As String)
            _SelectAreaName = value
        End Set
    End Property


    Public Property SelectPostalCode() As String
        Get
            Return _SelectPostalCode
        End Get
        Set(ByVal value As String)
            _SelectPostalCode = value
        End Set
    End Property


    Public Property SelectPostalName() As String
        Get
            Return _SelectPostalName
        End Get
        Set(ByVal value As String)
            _SelectPostalName = value
        End Set
    End Property


    Public Overrides Property BackColor() As Color
        Get
            Return Cbo_Area.BackColor
        End Get
        Set(ByVal value As Color)
            Cbo_Area.BackColor = value
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
    Public Property uclCboWidth() As Integer
        Get
            Return _uclCboWidth
        End Get
        Set(ByVal value As Integer)
            _uclCboWidth = value
            Cbo_Area.Width = value
        End Set
    End Property

    Public Property DataSource() As DataTable
        Get
            Return _DataSource
        End Get
        Set(ByVal value As DataTable)
            _DataSource = value
            Cbo_Area.DataSource = value

            Cbo_Area.SelectedIndex = 0

        End Set
    End Property


    Enum uclShowData
        showPostal = 1   '1:顯示郵遞區號代碼
        showArea = 2     '2:顯示戶籍地號代碼

    End Enum

    Public Property uclShowType() As uclShowData
        Get
            Return _uclShowType
        End Get
        Set(ByVal value As uclShowData)
            _uclShowType = value
        End Set
    End Property

    'Public Overrides Property Text() As String
    '    Get
    '        Return Cbo_Area.Text
    '    End Get
    '    Set(ByVal value As String)
    '        _Text = value
    '        Cbo_Area.Text = value
    '    End Set
    'End Property


    Public Property SelectedValue() As String
        Get
            Return _SelectedValue
        End Get
        Set(ByVal value As String)
            _SelectedValue = value
            ' Cbo_Area.SelectedValue = _SelectedValue
            SetText(value)
        End Set
    End Property

    '設定要顯示的欄位Index(預設為0,1=>代碼與名稱)
    Public Property uclDisplayIndex() As String
        Get
            Return _uclDisplayIndex
        End Get
        Set(ByVal value As String)
            _uclDisplayIndex = value
            SetComboField(_DataSource, "ShowField", _uclDisplayIndex)
            Cbo_Area.DisplayMember = "ShowField"
        End Set
    End Property

    '設定要選取值的欄位Index(預設為0=>代碼)
    Public Property uclValueIndex() As String
        Get
            Return _uclValueIndex
        End Get
        Set(ByVal value As String)
            _uclValueIndex = value
            SetComboField(_DataSource, "ValueField", _uclValueIndex)
            Cbo_Area.ValueMember = "ValueField"

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


#End Region

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
    ''' 進行戶籍地與郵遞區號查詢
    ''' code:查詢代碼
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub queryAreaCode(ByVal code As String)
        Try



            Dim find As Boolean = False


            If (code.Length = 2) OrElse (code.Length = 4) Then ' IsNumeric(code) AndAlso
                For Each dr As DataRow In pvtDS.Tables(0).Rows
                    If code.Trim = dr.Item(0).ToString().Trim() Then

                        If uclShowType = uclShowData.showArea Then
                            Cbo_Area.Text = dr.Item(0).ToString().Trim() & " - " & dr.Item(4).ToString().Trim
                            _SelectedValue = dr.Item(0).ToString().Trim()

                        ElseIf uclShowType = uclShowData.showPostal Then
                            Cbo_Area.Text = dr.Item(3).ToString().Trim() & " - " & dr.Item(4).ToString().Trim
                            _SelectedValue = dr.Item(3).ToString().Trim()
                        End If


                        nameStr = dr.Item(4).ToString().Trim

                        _SelectAreaCode = dr.Item(0).ToString().Trim()
                        _SelectAreaName = dr.Item(4).ToString().Trim

                        _SelectPostalCode = dr.Item(3).ToString().Trim()
                        _SelectPostalName = dr.Item(4).ToString()


                        find = True
                        pvtReceiveTreeMgr.RaiseUclOpenAreaWindow(ParentName, Cbo_Area.Text.Trim)
                        Exit For
                    End If
                Next

            ElseIf (code.Length = 3) Then 'IsNumeric(code) AndAlso
                For Each dr As DataRow In pvtDS.Tables(0).Rows
                    If code.Trim.Trim = dr.Item(3).ToString().Trim() Then


                        If uclShowType = uclShowData.showArea Then

                            Cbo_Area.Text = dr.Item(0).ToString().Trim() & " - " & dr.Item(4).ToString().Trim()
                            _SelectedValue = dr.Item(0).ToString().Trim()

                        ElseIf uclShowType = uclShowData.showPostal Then
                            Cbo_Area.Text = dr.Item(3).ToString().Trim() & " - " & dr.Item(4).ToString().Trim()
                            _SelectedValue = dr.Item(3).ToString().Trim()
                        End If



                        nameStr = dr.Item(4).ToString().Trim

                        _SelectAreaCode = dr.Item(0).ToString().Trim()
                        _SelectAreaName = dr.Item(4).ToString().Trim

                        _SelectPostalCode = dr.Item(3).ToString().Trim()
                        _SelectPostalName = dr.Item(4).ToString()


                        find = True
                        pvtReceiveTreeMgr.RaiseUclOpenAreaWindow(ParentName, Cbo_Area.Text.Trim)
                        Exit For
                    End If
                Next
            Else
                find = False
            End If
            If Not find Then
                Cbo_Area.Text = ""
                _SelectedValue = ""

                _SelectAreaCode = ""
                _SelectAreaName = ""

                _SelectPostalCode = ""
                _SelectPostalName = ""
                nameStr = ""

            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub


    ''' <summary>
    ''' 進行戶籍地與郵遞區號查詢
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub queryAreaPostal()
        Try

            Dim uclACQ As IUclServiceManager = UclServiceManager.getInstance
            If Not IsUsePUBAreaCodeN Then
                pvtDS = uclACQ.queryUclPostalAreaAll()

            Else
                pvtDS = uclACQ.queryUclPostalAreaAllNew()
            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 設定住址Text
    ''' text:住址
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub SetText(ByVal text As String)
        firstInitial = True
        Cbo_Area.Text = text
    End Sub

    ''' <summary>
    ''' 初始化設定
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub Initial(Optional ByVal Parent_Name As String = "")
        If pvtDS Is Nothing Then
            Cbo_Area.DropDownWidth = 180
            queryAreaPostal()
            ParentName = Parent_Name
        End If
    End Sub

    ''' <summary>
    ''' 初始化設定
    ''' </summary>
    ''' <remarks></remarks>''' 
    Public Sub Initial(ByVal dt As DataTable, Optional ByVal Parent_Name As String = "")
        If pvtDS Is Nothing Then
            pvtDS = New DataSet
            pvtDS.Tables.Add(dt.Copy)
            Cbo_Area.DropDownWidth = 180
            ParentName = Parent_Name
        End If
    End Sub




    Public Function GetName() As String
        Return nameStr
    End Function

#Region "Event"

    ''' <summary>
    ''' 接收TreeView所選的項目
    ''' </summary>
    ''' <remarks></remarks>''' 
    Private Sub receiveTreeNodeValue(ByVal ctlName As String, ByVal uclCodeValue1 As String) Handles pvtReceiveTreeMgr.UclOpenAreaWindow
        Try

            If ctlName = Me.Name Then


                Select Case _uclShowType
                    Case uclShowData.showPostal

                        For Each dr As DataRow In pvtDS.Tables(0).Rows
                            If uclCodeValue1.Substring(0, 4) = dr.Item(0).ToString().Trim() Then
                                Cbo_Area.Text = dr.Item(3).ToString().Trim() & " - " & dr.Item(4).ToString().Trim()
                                _SelectedValue = dr.Item(3).ToString().Trim()
                                nameStr = dr.Item(4).ToString()


                                _SelectAreaCode = dr.Item(0).ToString().Trim()
                                _SelectAreaName = dr.Item(4).ToString().Trim

                                _SelectPostalCode = dr.Item(3).ToString().Trim()
                                _SelectPostalName = dr.Item(4).ToString()

                                treeViewFlag = True
                                pvtReceiveTreeMgr.RaiseUclOpenAreaWindow(ParentName, Cbo_Area.Text.Trim)

                                Exit For

                            Else
                                Cbo_Area.Text = ""
                                _SelectedValue = ""

                                _SelectAreaCode = ""
                                _SelectAreaName = ""

                                _SelectPostalCode = ""
                                _SelectPostalName = ""


                                nameStr = ""


                            End If

                        Next


                    Case uclShowData.showArea
                        'treeViewFlag = True
                        'Cbo_Area.Text = uclCodeValue1
                        'Dim s() As String = Split(uclCodeValue1, "-")
                        'If s.Length = 2 Then
                        '    _SelectedValue = s(0)
                        '    nameStr = s(1)
                        'End If


                        For Each dr As DataRow In pvtDS.Tables(0).Rows
                            If uclCodeValue1.Substring(0, 4) = dr.Item(0).ToString().Trim() Then




                                Cbo_Area.Text = dr.Item(0).ToString().Trim() & " - " & dr.Item(4).ToString().Trim()
                                _SelectedValue = dr.Item(0).ToString().Trim()
                                nameStr = dr.Item(1).ToString()

                                _SelectAreaCode = dr.Item(0).ToString().Trim()
                                _SelectAreaName = dr.Item(4).ToString().Trim

                                _SelectPostalCode = dr.Item(3).ToString().Trim()
                                _SelectPostalName = dr.Item(4).ToString()

                                treeViewFlag = True
                                pvtReceiveTreeMgr.RaiseUclOpenAreaWindow(ParentName, Cbo_Area.Text.Trim)

                                Exit For

                            Else

                                Cbo_Area.Text = ""
                                _SelectedValue = ""

                                _SelectAreaCode = ""
                                _SelectAreaName = ""

                                _SelectPostalCode = ""
                                _SelectPostalName = ""
                                nameStr = ""


                            End If

                        Next

                End Select
            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

    End Sub

    Private Sub Cbo_Area_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Area.TextChanged
        Try


            doFlag = True
            If (Not pvtCheckFlag OrElse Cbo_Area.Text.Trim().Length = 3 OrElse Cbo_Area.Text.Trim().Length = 4) AndAlso firstInitial Then

                Select Case _uclShowType
                    Case uclShowData.showPostal
                        If Cbo_Area.Text.Trim().Length = 3 Then

                            queryAreaCode(Cbo_Area.Text.Trim().Substring(0, 3))

                        End If
                    Case uclShowData.showArea
                        If Cbo_Area.Text.Trim().Length = 4 Then
                            queryAreaCode(Cbo_Area.Text.Trim().Substring(0, 4))
                        End If
                End Select

            End If

            firstInitial = False

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub Btn_AreaCodeQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AreaCodeQuery.Click
        If pvtDS Is Nothing Then
            queryAreaPostal()
        End If

        Dim pvtAreaList As UCLAreaOpenWindowUC = New UCLAreaOpenWindowUC(pvtDS, Me.Name)
        pvtAreaList.Location = New Point(MousePosition.X, MousePosition.Y)
        pvtAreaList.ShowDialog()

    End Sub

    ' 把查詢到table中所有戶籍地資料加到(combox) 
    Private Sub Cbo_Area_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Area.DropDown
        Try

            If pvtDS Is Nothing Then
                queryAreaPostal()
            End If
            If Cbo_Area.Items.Count = 0 Then

                '加入一個空白項目
                Cbo_Area.Items.Add("")

                For i As Integer = 0 To pvtDS.Tables(0).Rows.Count - 1
                    '1:顯示郵遞區號代碼  col(3):Postal_Code ,col(4): Postal_Name
                    If _uclShowType = uclShowData.showPostal Then

                        Cbo_Area.Items.Add(pvtDS.Tables(0).Rows(i).Item(3).ToString().Trim() & " - " & pvtDS.Tables(0).Rows(i).Item(4).ToString().Trim())

                        '2:顯示戶籍地號代碼 col(0):Area_Code ,col(1): Area_Name
                    ElseIf _uclShowType = uclShowData.showArea Then
                        Cbo_Area.Items.Add(pvtDS.Tables(0).Rows(i).Item(0).ToString().Trim() & " - " & pvtDS.Tables(0).Rows(i).Item(4).ToString().Trim())
                    End If
                Next
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub Cbo_Area_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Area.Enter
        If pvtDS Is Nothing Then
            queryAreaPostal()
        End If
    End Sub

    Private Sub Cbo_Area_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Area.SelectionChangeCommitted
        Try

            pvtCheckFlag = True
            If _uclShowType = uclShowData.showPostal AndAlso Cbo_Area.SelectedIndex > 0 Then
                _SelectedValue = pvtDS.Tables(0).Rows(Cbo_Area.SelectedIndex - 1).Item(3).ToString().Trim()
                nameStr = pvtDS.Tables(0).Rows(Cbo_Area.SelectedIndex - 1).Item(4).ToString().Trim()

                SelectAreaCode = pvtDS.Tables(0).Rows(Cbo_Area.SelectedIndex - 1).Item(0).ToString().Trim()
                SelectAreaName = pvtDS.Tables(0).Rows(Cbo_Area.SelectedIndex - 1).Item(1).ToString().Trim()

                SelectPostalCode = pvtDS.Tables(0).Rows(Cbo_Area.SelectedIndex - 1).Item(3).ToString().Trim()
                SelectPostalName = pvtDS.Tables(0).Rows(Cbo_Area.SelectedIndex - 1).Item(4).ToString().Trim()

            ElseIf _uclShowType = uclShowData.showArea AndAlso Cbo_Area.SelectedIndex > 0 Then
                _SelectedValue = pvtDS.Tables(0).Rows(Cbo_Area.SelectedIndex - 1).Item(0).ToString().Trim()
                nameStr = pvtDS.Tables(0).Rows(Cbo_Area.SelectedIndex - 1).Item(1).ToString().Trim()

                SelectAreaCode = pvtDS.Tables(0).Rows(Cbo_Area.SelectedIndex - 1).Item(0).ToString().Trim()
                SelectAreaName = pvtDS.Tables(0).Rows(Cbo_Area.SelectedIndex - 1).Item(1).ToString().Trim()

                SelectPostalCode = pvtDS.Tables(0).Rows(Cbo_Area.SelectedIndex - 1).Item(3).ToString().Trim()
                SelectPostalName = pvtDS.Tables(0).Rows(Cbo_Area.SelectedIndex - 1).Item(4).ToString().Trim()


            Else
                _SelectedValue = ""
                nameStr = ""


                SelectAreaCode = ""
                SelectAreaName = ""

                SelectPostalCode = ""
                SelectPostalName = ""
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

    End Sub

    Private Sub Cbo_Area_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cbo_Area.KeyUp

        Select Case e.KeyCode
            Case Keys.Enter

                Select Case _uclShowType
                    Case uclShowData.showPostal
                        queryAreaCode(Cbo_Area.Text.Trim())
                    Case uclShowData.showArea
                        queryAreaCode(Cbo_Area.Text.Trim())
                End Select

        End Select

    End Sub

    Private Sub Cbo_Area_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Area.Leave

        Try

            If doFlag Then



                If (Not pvtCheckFlag OrElse Cbo_Area.Text.Trim().Length = 2 OrElse Cbo_Area.Text.Trim().Length = 3 OrElse Cbo_Area.Text.Trim().Length = 4) Then

                    Select Case _uclShowType
                        Case uclShowData.showPostal
                            If Cbo_Area.Text.Trim().Length = 3 Then
                                queryAreaCode(Cbo_Area.Text.Trim().Substring(0, 3))
                            End If
                        Case uclShowData.showArea
                            If Cbo_Area.Text.Trim().Length = 2 Then
                                queryAreaCode(Cbo_Area.Text.Trim().Substring(0, 2))
                            End If

                            If Cbo_Area.Text.Trim().Length = 4 Then
                                queryAreaCode(Cbo_Area.Text.Trim().Substring(0, 4))
                            End If

                    End Select
                Else
                    If Not treeViewFlag AndAlso Not pvtCheckFlag Then
                        Cbo_Area.Text = ""
                        _SelectedValue = ""

                        _SelectAreaCode = ""
                        _SelectAreaName = ""

                        _SelectPostalCode = ""
                        _SelectPostalName = ""
                        nameStr = ""
                    End If
                End If

            End If

            doFlag = False

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub


    Private Sub UCLCensusUI_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        If UCLFormUtil.isResizeable Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
        Else
            Me.Height = 26
            If Btn_AreaCodeQuery.Visible Then
                uclCboWidth = Me.Width - 36
            Else
                uclCboWidth = Me.Width
            End If
        End If

    End Sub

#End Region

    Private Sub Cbo_Area_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Area.SelectedValueChanged
        Try

            If ParentName.Trim <> "X" Then
                If pvtReceiveTreeMgr Is Nothing Then
                    pvtReceiveTreeMgr = EventManager.getInstance
                End If
                pvtReceiveTreeMgr.RaiseUclOpenAreaWindow(ParentName, Cbo_Area.Text.Trim)
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class


