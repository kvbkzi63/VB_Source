Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM

Public Class UCLGridUpComboBoxUC

#Region "全域變數宣告"

    Private dgv As UCLDataGridViewUC
    Private colIndex As Integer
    Private ctlType As ControlType
    Dim WithEvents pvtReceiveComboBoxGridMgr As EventManager = EventManager.getInstance
#End Region

    ''' <summary>
    ''' TextBox 類型 或 ComboBox 類型
    ''' </summary>
    ''' <remarks></remarks>
    Enum ControlType
        TextBox
        ComboBox

    End Enum


    ''' <summary>
    ''' 初始化設定
    ''' grid:要整批修改的GridView
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initial(ByRef grid As UCLDataGridViewUC)

        dgv = grid

        ComboBox1.MaxLength = 50

    End Sub

    ''' <summary>
    ''' 設定ControlType ( TextBox , ComboBox )
    ''' </summary>
    ''' <param name="type"></param>
    ''' <remarks></remarks>
    Public Sub SetControlType(ByVal type As ControlType)
        ctlType = type
    End Sub



    ''' <summary>
    ''' 設定要整批修改的Column Index
    ''' index:Column Index
    ''' </summary>
    ''' <remarks></remarks> 
    Public Sub SetColumnHeaderIndex(ByVal ColumnIndex As Integer)
        colIndex = ColumnIndex
    End Sub


    ''' <summary>
    ''' fix ms bugs 無法輸入10個字元
    ''' </summary>
    ''' <param name="ch">修正字元</param>
    ''' <remarks></remarks>
    Private Sub Fix10Char(ByVal ch As String)

        If InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("美") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("英") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("US") Then

            Dim pos As Integer = ComboBox1.SelectionStart
            ComboBox1.Text = ComboBox1.Text.Substring(0, ComboBox1.SelectionStart) + ch + ComboBox1.Text.Substring(ComboBox1.SelectionStart)
            pos += 1
            ComboBox1.SelectionStart = pos
        End If

    End Sub


#Region "Event"

    ''' <summary>
    ''' ComboBox1_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyUp

        Try
             
            Try
                 
                RaiseEvent KeyUp(sender, e)

                '    Console.WriteLine("cbo key up")

                'fix ms bugs 無法輸入10個字元
                Select Case e.KeyCode
                    Case Keys.OemPeriod ' .
                        If dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Not e.Shift Then
                            Fix10Char(".")
                        End If

                    Case Keys.Oem7 ' '
                        If dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Not e.Shift Then
                            Fix10Char("'")
                        ElseIf dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                            Fix10Char("""")
                        End If

                    Case Keys.D1 '!
                        If dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                            Fix10Char("!")
                        End If
                    Case Keys.D3 '#
                        If dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                            Fix10Char("#")
                        End If

                    Case Keys.D4 '$
                        If dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                            Fix10Char("$")
                        End If

                    Case Keys.D5 '%
                        If dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                            Fix10Char("%")
                        End If

                    Case Keys.D7 '&
                        If dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                            Fix10Char("&")
                        End If

                    Case Keys.D9 '(
                        If dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift Then
                            Fix10Char("(")
                        End If

                    Case Keys.Q ' q
                        If dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Not e.Shift AndAlso Not My.Computer.Keyboard.CapsLock Then
                            Fix10Char("q")
                        ElseIf dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso e.Shift AndAlso My.Computer.Keyboard.CapsLock Then
                            Fix10Char("q")
                        End If
                        'end ms bug



                End Select


            Catch ex As Exception
                Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            End Try



            Select Case e.KeyCode
                Case Keys.Enter
                    dgv.Columns(colIndex).ReadOnly = False
                    'If dgv.MultiSelect AndAlso dgv.uclColumnCheckBox Then


                    '    For i As Integer = 0 To dgv.Rows.Count - 1
                    '        If dgv.Rows(i).Cells(0).Value = True Then
                    '            dgv.Rows(i).Cells(colIndex).Value = ComboBox1.Text
                    '            dgv.ComboBoxCellSelectedValue (
                    '        End If

                    '    Next
                    '    dgv.Columns(colIndex).ReadOnly = True
                    '    ComboBox1.Text = ""
                    '    Me.Visible = False
                    'End If

                Case Keys.Escape
                    Me.Visible = False
            End Select

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' ProcessCmdKey
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        Dim uclIsComboxClickTriggerDropDown As Boolean = False

        If dgv IsNot Nothing Then
            uclIsComboxClickTriggerDropDown = dgv.uclIsComboxClickTriggerDropDown
            dgv.uclIsComboxClickTriggerDropDown = False
        End If
         
        Try

            Dim IsMultiSelect As Boolean = IIf(dgv.MultiSelect AndAlso dgv.uclColumnCheckBox, True, False)

            Select Case keyData
                Case Keys.Enter

                    If dgv IsNot Nothing Then
                        dgv.uclIsDoOrderCheck = False
                    End If

                    If ctlType = ControlType.TextBox Then
                        If ComboBox1.SelectedValue IsNot DBNull.Value AndAlso pvtdoFlag Then
                            If pvtReceiveComboBoxGridMgr Is Nothing Then
                                pvtReceiveComboBoxGridMgr = EventManager.getInstance
                            End If
                            pvtReceiveComboBoxGridMgr.RaiseUclWaitingForm("WaitingStart", "資料套用中，請稍後‧‧‧")

                            For i As Integer = 0 To dgv.Rows.Count - 1
                                '只有非刪除(可見的Row) 才需要套用

                                If dgv.Rows(i).Visible AndAlso (Not IsMultiSelect OrElse (IsMultiSelect AndAlso dgv.Rows(i).Cells(0).Value = True)) Then

                                    If IsMultiSelect Then
                                        dgv.GetDBDS.Tables(0).Rows(i).Item(colIndex - 1 - TreeGridCol) = ComboBox1.Text.Trim
                                        dgv.Rows(i).Cells(colIndex).Value = ComboBox1.Text.Trim
                                        dgv.GetGridDS.Tables(0).Rows(i).Item(colIndex - 1 - TreeGridCol) = ComboBox1.Text.Trim
                                    Else
                                        dgv.GetDBDS.Tables(0).Rows(i).Item(colIndex - TreeGridCol) = ComboBox1.Text.Trim
                                        dgv.Rows(i).Cells(colIndex).Value = ComboBox1.Text.Trim
                                        dgv.GetGridDS.Tables(0).Rows(i).Item(colIndex - TreeGridCol) = ComboBox1.Text.Trim
                                    End If

                                    If dgv.GetGridDS.Tables(0).Columns.Contains("ActionState") Then
                                        dgv.GetDBDS.Tables(0).Rows(i).Item("ActionState") = "Update"
                                        dgv.GetGridDS.Tables(0).Rows(i).Item("ActionState") = "Update"

                                    End If

                                    dgv.CurrentCell = dgv.Rows(i).Cells(colIndex)
                                    '                                    dgv.ComboBoxCellSelectedValue(ComboBox1.SelectedValue, i, colIndex)

                                    'SendKeys.Send("{TAB}")

                                    'dgv.CurrentCell = dgv.Rows(i).Cells(colIndex)
                                End If

                            Next
                            dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(colIndex)
                            dgv.Columns(colIndex).ReadOnly = True
                            ComboBox1.Text = ""
                        End If
                    End If

                    Me.Visible = False

                Case Keys.OemPeriod, Keys.Oem7

                    If dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Not Keys.Shift Then
                        Return True
                    End If

                    'Case Keys.D1, Keys.D3, Keys.D4, Keys.D5, Keys.D7, Keys.D9

                    '    If cbo_dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Keys.Shift Then
                    '        Return True
                    '    End If

                Case Keys.Q

                    If dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Not Keys.Shift AndAlso Not My.Computer.Keyboard.CapsLock Then
                        Return True
                    ElseIf dgv IsNot Nothing AndAlso ComboBox1.Text.Length < ComboBox1.MaxLength AndAlso Keys.Shift AndAlso My.Computer.Keyboard.CapsLock Then
                        Return True
                    End If

                Case Keys.Space

                    If dgv IsNot Nothing Then
                        If InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("美") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("英") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("US") Then

                            Dim pos As Integer = ComboBox1.SelectionStart
                            ComboBox1.Text = ComboBox1.Text.Substring(0, ComboBox1.SelectionStart) + " " + ComboBox1.Text.Substring(ComboBox1.SelectionStart)
                            pos += 1
                            ComboBox1.SelectionStart = pos
                        End If

                        Return True
                    End If

                Case Keys.Escape

                    Me.Visible = False

            End Select
        Catch ex As Exception

            If pvtReceiveComboBoxGridMgr Is Nothing Then
                pvtReceiveComboBoxGridMgr = EventManager.getInstance
            End If

            'pvtReceiveComboBoxGridMgr.RaiseUclWaitingForm("WaitingEnd", "")
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)

        Finally
            pvtReceiveComboBoxGridMgr.RaiseUclWaitingForm("WaitingEnd", "")
            If dgv IsNot Nothing Then
                dgv.uclIsDoOrderCheck = True
                dgv.uclIsComboxClickTriggerDropDown = uclIsComboxClickTriggerDropDown
                dgv.HideControlCell("All")
            End If
             
        End Try
    End Function


    ''' <summary>
    ''' UCLGridUpComboBoxUI_Resize
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UCLGridUpComboBoxUI_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        If UCLFormUtil.isResizeable Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
        End If

        If Screen.PrimaryScreen.Bounds.Width >= 1920 Then
            Me.Height = 28
        Else
            Me.Height = 25
        End If
    End Sub
#End Region

    ''' <summary>
    ''' UCLGridUpComboBoxUI_VisibleChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UCLGridUpComboBoxUI_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If Not Me.Visible AndAlso dgv IsNot Nothing Then
            If dgv.Controls.Contains(Me) Then
                dgv.Controls.Remove(Me)
            End If

        End If
    End Sub

    ''' <summary>
    ''' ComboBox1_SelectedIndexChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim uclIsComboxClickTriggerDropDown As Boolean = False

        If dgv IsNot Nothing Then
            uclIsComboxClickTriggerDropDown = dgv.uclIsComboxClickTriggerDropDown
            dgv.uclIsComboxClickTriggerDropDown = False
        End If

        Try

            If ComboBox1.SelectedValue.ToString.Trim = "System.Data.DataRowView" Then
                Exit Sub
            End If

            Dim IsMultiSelect As Boolean = IIf(dgv.MultiSelect AndAlso dgv.uclColumnCheckBox, True, False)
             
            If ctlType = ControlType.ComboBox AndAlso pvtdoFlag AndAlso ComboBox1.SelectedValue IsNot Nothing AndAlso ComboBox1.SelectedValue IsNot DBNull.Value Then

                If dgv IsNot Nothing Then
                    dgv.uclIsDoOrderCheck = False
                End If

                If pvtReceiveComboBoxGridMgr Is Nothing Then
                    pvtReceiveComboBoxGridMgr = EventManager.getInstance
                End If

                pvtReceiveComboBoxGridMgr.RaiseUclWaitingForm("WaitingStart", "資料套用中，請稍後‧‧‧")

                For i As Integer = 0 To dgv.Rows.Count - 1
                    '只有非刪除(可見的Row) 才需要套用
                    If dgv.Rows(i).Visible AndAlso (Not IsMultiSelect OrElse (IsMultiSelect AndAlso dgv.Rows(i).Cells(0).Value = True)) Then
                        ' dgv.Rows(i).Cells(colIndex).Value = ComboBox1.Text
                        dgv.CurrentCell = dgv.Rows(i).Cells(colIndex)
                        If dgv.GetDgvReadOnlyDS.Tables(0).Rows(i).Item(colIndex) Is DBNull.Value OrElse dgv.GetDgvReadOnlyDS.Tables(0).Rows(i).Item(colIndex) <> "TRUE" Then
                            dgv.ComboBoxCellSelectedValue(ComboBox1.SelectedValue, i, colIndex)
                            'SendKeys.Send("{TAB}")
                            'dgv.CurrentCell = dgv.Rows(i).Cells(colIndex)

                        End If

                    End If

                Next
                'dgv.Columns(colIndex).ReadOnly = True
                'dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(colIndex)
                ComboBox1.Text = ""
                Me.Visible = False

            End If
            pvtdoFlag = True

        Catch ex As Exception

        Finally

            If dgv IsNot Nothing Then
                dgv.uclIsDoOrderCheck = True
                dgv.uclIsComboxClickTriggerDropDown = uclIsComboxClickTriggerDropDown
                dgv.HideControlCell("All")
            End If
             
            If pvtReceiveComboBoxGridMgr Is Nothing Then
                pvtReceiveComboBoxGridMgr = EventManager.getInstance
            End If

            pvtReceiveComboBoxGridMgr.RaiseUclWaitingForm("WaitingEnd", "")
        End Try

    End Sub

    ''' <summary>
    ''' ComboBox1_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged

        If ctlType = ControlType.TextBox Then
            pvtdoFlag = True
        End If
    End Sub

#Region "ComboBox功能"

#Region "全域變數宣告"


    Private _DataSource As DataTable = New DataTable()
    Private _SelectedValue As String = ""
    Private _SelectedText As String = ""
    Private _BackColor As Color
    Private _DropDownWidth As Integer = 20
    Private _uclDisplayIndex As String = "0,1"
    Private _uclValueIndex As String = "0"
    Private _uclShowMsg As Boolean = False
    Private _DropDownStyle As System.Windows.Forms.ComboBoxStyle = ComboBoxStyle.DropDown
    Private _Items As System.Windows.Forms.ComboBox.ObjectCollection
    Private _SelectionStart As Integer = 0
    Private _SelectedItem As Object
    Private _SelectedIndex As Integer
    '   Private _Width As Integer = 50

    Dim pvtCheckFlag = False
    Dim pvtdoFlag = True

    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Shadows Event Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Shadows Event KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    Public Shadows Event KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)


    Private _Text As String


    '用在datagridview的ComboBox
    Dim cbo_dgv As UCLDataGridViewUC = Nothing


    'Dim dsDB As DataSet = Nothing
    'Dim dsGrid As DataSet = Nothing

    Public cellRowIndex, cellColIndex As Integer
    '用在datagridview的Cell剛進Combox時
    Public FirstEnterGridCell As Boolean = False

    Dim SelectedComboBoxCodeValue As String = "" '隨輸隨選特殊的Combox code
    Public doTextChanged As Boolean = False
    Dim TreeGridCol As Integer = 0



#End Region

#Region "屬性設定"

    'Public Overloads Property Width() As Integer
    '    Get
    '        Return _Width
    '    End Get
    '    Set(ByVal value As Integer)
    '        _Width = value

    '    End Set
    'End Property

    ''' <summary>
    ''' SelectionStart
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
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

    Public Property SelectedIndex() As Integer
        Get

            Return ComboBox1.SelectedIndex
        End Get
        Set(ByVal value As Integer)


            ComboBox1.SelectedIndex = value


        End Set
    End Property

    Public Property SelectedItem() As Object
        Get
            Return ComboBox1.SelectedItem
        End Get
        Set(ByVal value As Object)
            ComboBox1.SelectedItem = value
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
                    Else
                        nullData.Item(i) = " "
                    End If
                Next
                value.Rows.InsertAt(nullData, 0)


                _DataSource = value

                ComboBox1.DataSource = value
                ' ComboBox1.SelectedIndex = 0
                SetComboField(_DataSource, "ValueField", _uclValueIndex)
                ComboBox1.ValueMember = "ValueField"
                doTextChanged = True
                pvtdoFlag = True
            Else
                ComboBox1.DataSource = Nothing
            End If
        End Set
    End Property
    Public Property SelectedValue() As String
        Get
            If ComboBox1.SelectedValue IsNot Nothing AndAlso ComboBox1.SelectedValue IsNot DBNull.Value Then
                Return ComboBox1.SelectedValue
            Else
                Return ""
            End If

        End Get
        Set(ByVal value As String)
            _SelectedValue = value

            ComboBox1.SelectedValue = _SelectedValue
            If ComboBox1.SelectedValue = "" Then
                _SelectedValue = ""

            End If
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
    'Public Overrides Property BackColor() As Color
    '    Get
    '        Return ComboBox1.BackColor
    '    End Get
    '    Set(ByVal value As Color)
    '        ComboBox1.BackColor = value
    '    End Set
    'End Property
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
    ''' 設定要顯示的欄位Index(預設為0,1=>代碼與名稱)
    ''' </summary>
    ''' <remarks></remarks>
    Public Property uclDisplayIndex() As String
        Get
            Return _uclDisplayIndex
        End Get
        Set(ByVal value As String)
            pvtdoFlag = False
            _uclDisplayIndex = value
            SetComboField(_DataSource, "ShowField", _uclDisplayIndex)
            ComboBox1.DisplayMember = "ShowField"
            pvtdoFlag = True
        End Set
    End Property


    ''' <summary>
    ''' 設定要選取值的欄位Index(預設為0=>代碼)
    ''' </summary>
    ''' <remarks></remarks>
    Public Property uclValueIndex() As String
        Get
            Return _uclValueIndex
        End Get
        Set(ByVal value As String)
            pvtdoFlag = False
            _uclValueIndex = value
            SetComboField(_DataSource, "ValueField", _uclValueIndex)
            ComboBox1.ValueMember = "ValueField"
            pvtdoFlag = True
        End Set
    End Property

    ''' <summary>
    ''' 設定要顯示訊息(預設為false)
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Public Property uclShowMsg() As Boolean
        Get
            Return _uclShowMsg
        End Get
        Set(ByVal value As Boolean)
            _uclShowMsg = value
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

#End Region



    ''' <summary>
    '''  設定下拉選項值顯示欄位內容與選取值對應欄位
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetComboField(ByVal pvtTable As DataTable, ByVal pvtColumnName As String, ByVal pvtCutStr As String)

        If Not pvtTable.Columns.Contains(pvtColumnName) Then
            Dim pvtColumn As DataColumn = pvtTable.Columns.Add(pvtColumnName)
        End If

        Dim pvtArrayList As ArrayList = CutString(pvtCutStr, ",")


        'i這邊要注意~~
        For i = 1 To pvtTable.Rows.Count - 1


            For j = 0 To pvtArrayList.Count - 1

                If j = 0 Then

                    pvtTable.Rows(i).Item(pvtColumnName) = pvtTable.Rows(i).Item(Integer.Parse(pvtArrayList.Item(j).ToString))

                Else

                    pvtTable.Rows(i).Item(pvtColumnName) = pvtTable.Rows(i).Item(pvtColumnName).ToString().Trim() & " - " & pvtTable.Rows(i).Item(Integer.Parse(pvtArrayList.Item(j).ToString)).ToString().Trim()

                End If

            Next
        Next

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
    ''' ComboBox1_DropDown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBox1_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        DropDownWidth = ItemMaxLength() + 8
    End Sub

    ''' <summary>
    ''' Item最大Length
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Private Function ItemMaxLength() As Integer
        Dim length As Integer = ComboBox1.Width
        Dim Size As SizeF

        Dim g As System.Drawing.Graphics = CreateGraphics()


        If ComboBox1.DataSource IsNot Nothing Then
            For i As Integer = 1 To ComboBox1.DataSource.Rows.Count - 1
                Size = g.MeasureString(ComboBox1.DataSource.Rows(i).Item("ShowField").ToString.Trim(), ComboBox1.Font)
                If length < CInt(Size.Width) Then
                    length = CInt(Size.Width)
                End If
            Next
        End If

        Return length
    End Function

#End Region


End Class
