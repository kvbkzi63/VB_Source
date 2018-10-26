Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports System.Text

''' <summary>
''' Class UCLTextBoxUC.
''' </summary>
''' <seealso cref="System.Windows.Forms.UserControl" />
Public Class UCLTextBoxUC

#Region "全域變數宣告"

    ''' <summary>
    ''' The MGR ComboBox
    ''' </summary>
    Dim WithEvents mgrComboBox As EventManager = EventManager.getInstance '宣告EventManager

    ''' <summary>
    ''' The maximum length
    ''' </summary>
    Private _MaxLength As Integer = 10  '字串最大Bytes
    ''' <summary>
    ''' The ucl read only
    ''' </summary>
    Private _uclReadOnly As Boolean = False

    ''' <summary>
    ''' The uclTransferForFractions 
    ''' </summary>
    Private _uclTransferForFractions As Boolean = False

    ''' <summary>
    ''' The text
    ''' </summary>
    Private _Text As String
    ''' <summary>
    ''' The ucl minus
    ''' </summary>
    Private _uclMinus As Boolean = False
    ''' <summary>
    ''' The ucl dollar sign
    ''' </summary>
    Private _uclDollarSign As Boolean = False
    ''' <summary>
    ''' The ucl trim zero
    ''' </summary>
    Private _uclTrimZero As Boolean = True

    ''' <summary>
    ''' The ucl int count
    ''' </summary>
    Private _uclIntCount As Integer = 2  '整數位數
    ''' <summary>
    ''' The ucl dot count
    ''' </summary>
    Private _uclDotCount As Integer = 0  '小數點位數
    ''' <summary>
    ''' The ucl text type
    ''' </summary>
    Private _uclTextType = uclTextTypeData.Any_Type
    ''' <summary>
    ''' The text mask format
    ''' </summary>
    Private _TextMaskFormat As System.Windows.Forms.MaskFormat
    ''' <summary>
    ''' The text align
    ''' </summary>
    Private _TextAlign As System.Windows.Forms.HorizontalAlignment = HorizontalAlignment.Left

    ''' <summary>
    ''' The back color
    ''' </summary>
    Private _BackColor As Color = Color.White
    ''' <summary>
    ''' The fore color
    ''' </summary>
    Private _ForeColor As Color = Color.Black

    ''' <summary>
    ''' The string CH10
    ''' </summary>
    Private strCh10 As String = ""
    ''' <summary>
    ''' Occurs when [text changed].
    ''' </summary>
    Public Shadows Event TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Occurs when [key up].
    ''' </summary>
    Public Shadows Event KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    ''' <summary>
    ''' Occurs when [mouse move].
    ''' </summary>
    Public Shadows Event MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    ''' <summary>
    ''' Occurs when [key down].
    ''' </summary>
    Public Shadows Event KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    '用在datagridview的TextBox
    ''' <summary>
    ''' The text DGV
    ''' </summary>
    Dim txt_dgv As UCLDataGridViewUC = Nothing

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
    Dim cellRowIndex, cellColIndex As Integer
    ''' <summary>
    ''' The first enter grid cell
    ''' </summary>
    Public FirstEnterGridCell As Boolean = False

    ''' <summary>
    ''' The tree grid col
    ''' </summary>
    Dim TreeGridCol As Integer = 0
    ''' <summary>
    ''' The GBL text number
    ''' </summary>
    Dim gblTextNum As Integer = 0

    ''' <summary>
    ''' OriText
    ''' </summary>
    Dim OriText As String = ""

#End Region

#Region "屬性設定"

    ''' <summary>
    ''' Enum uclTextTypeData
    ''' </summary>
    Enum uclTextTypeData

        ''' <summary>
        ''' Any type
        ''' </summary>
        Any_Type = 1
        ''' <summary>
        ''' The integer type
        ''' </summary>
        Integer_Type = 2
        ''' <summary>
        ''' The money type
        ''' </summary>
        Money_Type = 3
        ''' <summary>
        ''' The identifier type
        ''' </summary>
        ID_Type = 4
        ''' <summary>
        ''' The time hour24 and minute
        ''' </summary>
        Time_Hour24AndMinute = 5
        ''' <summary>
        ''' The time hour12 and minute
        ''' </summary>
        Time_Hour12AndMinute = 6
        ''' <summary>
        ''' The time hour24
        ''' </summary>
        Time_Hour24 = 7
        ''' <summary>
        ''' The time hour12
        ''' </summary>
        Time_Hour12 = 8
        ''' <summary>
        ''' The time minute
        ''' </summary>
        Time_Minute = 9
        ''' <summary>
        ''' The time second
        ''' </summary>
        Time_Second = 10
        ''' <summary>
        ''' The database integer type
        ''' </summary>
        DBInteger_Type = 11
        ''' <summary>
        ''' The English letters type
        ''' </summary>
        OnlyEnCharacters = 12
    End Enum

    ''' <summary>
    ''' Gets or sets the text align.
    ''' </summary>
    ''' <value>The text align.</value>
    Public Property TextAlign() As System.Windows.Forms.HorizontalAlignment
        Get
            Return MaskedTextBox1.TextAlign
        End Get
        Set(ByVal value As System.Windows.Forms.HorizontalAlignment)
            MaskedTextBox1.TextAlign = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the selection start.
    ''' </summary>
    ''' <value>The selection start.</value>
    Public Property SelectionStart() As Integer
        Get
            Return MaskedTextBox1.SelectionStart
        End Get
        Set(ByVal value As Integer)
            MaskedTextBox1.SelectionStart = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ImeMode.
    ''' </summary>
    ''' <value>The ImeMode.</value>
    Public Property uclImeMode() As ImeMode
        Get
            Return MaskedTextBox1.ImeMode
        End Get
        Set(ByVal value As ImeMode)
            MaskedTextBox1.ImeMode = value
        End Set
    End Property


    ''' <summary>
    ''' 取得或設定控制項的背景色彩。
    ''' </summary>
    ''' <value>The color of the back.</value>
    ''' <PermissionSet>
    '''   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ''' </PermissionSet>
    Public Overrides Property BackColor() As Color
        Get
            Return MaskedTextBox1.BackColor
        End Get
        Set(ByVal value As Color)
            MaskedTextBox1.BackColor = value
        End Set
    End Property

    ''' <summary>
    ''' 取得或設定控制項的前景色彩。
    ''' </summary>
    ''' <value>The color of the fore.</value>
    ''' <PermissionSet>
    '''   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ''' </PermissionSet>
    Public Overrides Property ForeColor() As Color
        Get
            Return MaskedTextBox1.ForeColor
        End Get
        Set(ByVal value As Color)
            MaskedTextBox1.ForeColor = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the text mask format.
    ''' </summary>
    ''' <value>The text mask format.</value>
    Public Property TextMaskFormat() As System.Windows.Forms.MaskFormat
        Get
            Return MaskedTextBox1.TextMaskFormat
        End Get
        Set(ByVal value As System.Windows.Forms.MaskFormat)
            MaskedTextBox1.TextMaskFormat = value

        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the type of the ucl text.
    ''' </summary>
    ''' <value>The type of the ucl text.</value>
    Public Property uclTextType() As uclTextTypeData
        Get
            Return _uclTextType
        End Get
        Set(ByVal value As uclTextTypeData)
            _uclTextType = value
            ProcessMask()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the password character.
    ''' </summary>
    ''' <value>The password character.</value>
    Public Property PasswordChar() As String
        Get
            Return MaskedTextBox1.PasswordChar
        End Get
        Set(ByVal value As String)
            MaskedTextBox1.PasswordChar = value
        End Set
    End Property

    Public Property HideSelection() As Boolean
        Get
            Return MaskedTextBox1.HideSelection
        End Get
        Set(ByVal value As Boolean)
            MaskedTextBox1.HideSelection = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the text.
    ''' </summary>
    ''' <value>The text.</value>
    Public Overrides Property Text() As String
        Get
            Return MaskedTextBox1.Text
        End Get
        Set(ByVal value As String)
            MaskedTextBox1.Text = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl read only].
    ''' </summary>
    ''' <value><c>true</c> if [ucl read only]; otherwise, <c>false</c>.</value>
    Public Property uclReadOnly() As Boolean
        Get
            Return MaskedTextBox1.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            MaskedTextBox1.ReadOnly = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl read only].
    ''' </summary>
    ''' <value><c>true</c> if [ucl read only]; otherwise, <c>false</c>.</value>
    Public Property uclTransferForFractions() As Boolean
        Get
            Return _uclTransferForFractions
        End Get
        Set(ByVal value As Boolean)
            _uclTransferForFractions = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl trim zero].
    ''' </summary>
    ''' <value><c>true</c> if [ucl trim zero]; otherwise, <c>false</c>.</value>
    Public Property uclTrimZero() As Boolean
        Get
            Return _uclTrimZero
        End Get
        Set(ByVal value As Boolean)
            _uclTrimZero = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl minus].
    ''' </summary>
    ''' <value><c>true</c> if [ucl minus]; otherwise, <c>false</c>.</value>
    Public Property uclMinus() As Boolean
        Get
            Return _uclMinus
        End Get
        Set(ByVal value As Boolean)
            _uclMinus = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [ucl dollar sign].
    ''' </summary>
    ''' <value><c>true</c> if [ucl dollar sign]; otherwise, <c>false</c>.</value>
    Public Property uclDollarSign() As Boolean
        Get
            Return _uclDollarSign
        End Get
        Set(ByVal value As Boolean)
            _uclDollarSign = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ucl int count.
    ''' </summary>
    ''' <value>The ucl int count.</value>
    Public Property uclIntCount() As Integer
        Get
            Return _uclIntCount
        End Get
        Set(ByVal value As Integer)
            _uclIntCount = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ucl dot count.
    ''' </summary>
    ''' <value>The ucl dot count.</value>
    Public Property uclDotCount() As Integer
        Get
            Return _uclDotCount
        End Get
        Set(ByVal value As Integer)
            _uclDotCount = value
        End Set
    End Property

    '設定或取得字串最大Bytes
    ''' <summary>
    ''' Gets or sets the maximum length.
    ''' </summary>
    ''' <value>The maximum length.</value>
    Public Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            MaskedTextBox1.MaxLength = value
        End Set
    End Property

    ''' <summary>
    ''' 設定控制項的Tip
    ''' </summary>
    ''' <value>The tool tip tag.</value>
    ''' <remarks>by Sean.Lin on 2015-11-01</remarks>
    Public Property ToolTipTag() As String
        Get
            Return MaskedTextBox1.Tag
        End Get
        Set(ByVal value As String)
            MaskedTextBox1.Tag = value
        End Set
    End Property

#End Region

    ''' <summary>
    ''' Initializes a new instance of the <see cref="UCLTextBoxUC"/> class.
    ''' </summary>
    Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub

    ''' <summary>
    ''' ASCII
    ''' </summary>
    ''' <param name="e">The <see cref="System.Windows.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
    Private Sub ASCII(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Debug.WriteLine(Asc(e.KeyChar).ToString())

        Select Case Asc(e.KeyChar)
            Case 33
                strCh10 = "!"
            Case 34
                strCh10 = """"
            Case 35
                strCh10 = "#"
            Case 36
                strCh10 = "$"
            Case 37
                strCh10 = "%"
            Case 38
                strCh10 = "&"
            Case 39
                strCh10 = "'"
            Case 40
                strCh10 = "("

            Case 46
                strCh10 = "."
            Case 71
                strCh10 = "q"
        End Select
    End Sub

#Region "Event"

    ''' <summary>
    ''' ProcessCmdKey
    ''' </summary>
    ''' <param name="msg">以傳址方式傳遞的 <see cref="T:System.Windows.Forms.Message" />，表示要處理的視窗訊息。</param>
    ''' <param name="keyData">其中一個 <see cref="T:System.Windows.Forms.Keys" /> 值，表示要處理的按鍵。</param>
    ''' <returns>如果字元由控制項處理，為 true，否則為 false。</returns>
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try
            If uclReadOnly Then
                Exit Function
            End If

            Select Case keyData

                Case Keys.Decimal

                    Try
                        If txt_dgv IsNot Nothing Then
                            'If Not MaskedTextBox1.Text.Contains(".") Then
                            '    Dim pos As Integer = MaskedTextBox1.SelectionStart
                            '    MaskedTextBox1.Text = MaskedTextBox1.Text.Substring(0, MaskedTextBox1.SelectionStart) + "." + MaskedTextBox1.Text.Substring(MaskedTextBox1.SelectionStart)
                            '    pos += 1
                            '    MaskedTextBox1.SelectionStart = pos
                            'End If
                            Return True
                        End If

                    Catch ex As Exception

                    End Try

                Case Keys.Escape, Keys.Left, Keys.Right, Keys.Up, Keys.Down

                    If txt_dgv IsNot Nothing Then
                        Me.Visible = False

                    End If

                Case Keys.OemPeriod, Keys.Oem7

                    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.Text.Length < MaskedTextBox1.MaxLength AndAlso Not Keys.Shift Then
                        Return True
                    End If

                    'Case Keys.D1, Keys.D3, Keys.D4, Keys.D5, Keys.D7, Keys.D9

                    '    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.Text.Length < MaskedTextBox1.MaxLength AndAlso Keys.Shift Then
                    '        Return True
                    '    End If

                Case Keys.Q

                    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.Text.Length < MaskedTextBox1.MaxLength AndAlso Not Keys.Shift AndAlso Not My.Computer.Keyboard.CapsLock Then
                        Return True
                    ElseIf txt_dgv IsNot Nothing AndAlso MaskedTextBox1.Text.Length < MaskedTextBox1.MaxLength AndAlso Keys.Shift AndAlso My.Computer.Keyboard.CapsLock Then
                        Return True
                    End If

                Case Keys.Enter
                    'If txt_dgv IsNot Nothing Then
                    '    mgrComboBox.RaiseUclOpenWindow2(Parent.Parent.Parent.Parent.Name & "TextBoxCellPressEnter", MaskedTextBox1.Text.Trim, cellColIndex, cellRowIndex)
                    'End If
                    If txt_dgv IsNot Nothing Then
                        mgrComboBox.RaiseUclOpenWindow2(Parent.Parent.Parent.Name & "TextBoxCellPressEnter", MaskedTextBox1.Text.Trim, cellColIndex, cellRowIndex)
                    End If
                    Return False
                Case Keys.Shift
                    Return False

                Case Keys.Space

                    If txt_dgv IsNot Nothing Then
                        If InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("美") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("英") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("US") Then

                            Dim pos As Integer = MaskedTextBox1.SelectionStart
                            MaskedTextBox1.Text = MaskedTextBox1.Text.Substring(0, MaskedTextBox1.SelectionStart) + " " + MaskedTextBox1.Text.Substring(MaskedTextBox1.SelectionStart)
                            pos += 1
                            MaskedTextBox1.SelectionStart = pos
                        End If

                        Return True
                    End If
            End Select

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
        End Try

    End Function

    ''' <summary>
    ''' MaskedTextBox1_KeyPress
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
    Private Sub MaskedTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MaskedTextBox1.KeyPress
        Dim blnHandled As Boolean = False

        'ASCII(e)
        If uclReadOnly Then
            Exit Sub
        End If

        Select Case _uclTextType

            Case uclTextTypeData.OnlyEnCharacters
                '只能輸入英文字母
                If Not (Asc(e.KeyChar) = 8) Then
                    If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then
                        e.KeyChar = ChrW(0)
                        e.Handled = True
                    End If
                End If

            Case uclTextTypeData.Integer_Type, uclTextTypeData.DBInteger_Type

                Select Case Asc(e.KeyChar)
                    Case Asc("-")   '負號,僅能在最前頭
                        If Not (MaskedTextBox1.SelectionStart = 0 And _uclMinus = True) Then blnHandled = True

                    Case Asc(".") '小數點,小數位數大於0,在字串中没有“.”，且加了“.”後小數位能滿足要求

                        If _uclDotCount <= 0 Then
                            blnHandled = True
                        Else
                            If Not (InStr(MaskedTextBox1.Text, ".") = 0 And (Len(MaskedTextBox1.Text) - MaskedTextBox1.SelectionStart <= _uclDotCount)) Then blnHandled = True
                        End If

                        '整數
                        If MaskedTextBox1.Text.Contains("-") Then
                            If MaskedTextBox1.SelectionStart - 1 > uclIntCount Then
                                blnHandled = True
                            End If
                        Else
                            If MaskedTextBox1.SelectionStart > uclIntCount Then
                                blnHandled = True
                            End If

                        End If

                    Case 8, 13                      '倒退鍵

                    Case Asc("0") To Asc("9")       '   0-9

                        If InStr(MaskedTextBox1.Text, ".") > 0 AndAlso MaskedTextBox1.SelectionStart > MaskedTextBox1.Text.IndexOf(".") Then
                            If MaskedTextBox1.SelectionStart > InStr(MaskedTextBox1.Text, ".") Then                                '

                                If Len(MaskedTextBox1.Text) - InStr(MaskedTextBox1.Text, ".") >= _uclDotCount Then blnHandled = True
                            Else
                                If Len(MaskedTextBox1.Text) - InStr(MaskedTextBox1.Text, ".") >= _uclDotCount AndAlso MaskedTextBox1.SelectionStart > MaskedTextBox1.Text.IndexOf(".") Then blnHandled = True
                            End If
                            'If blnHandled Then
                            '    Exit Select
                            'End If
                        Else

                            '整數
                            If MaskedTextBox1.Text.Contains("-") Then
                                If Not MaskedTextBox1.Text.Contains(".") Then
                                    If MaskedTextBox1.Text.Length - 1 >= uclIntCount Then
                                        blnHandled = True
                                    End If
                                Else
                                    If MaskedTextBox1.Text.IndexOf(".") <> -1 AndAlso MaskedTextBox1.Text.IndexOf(".") - 1 >= uclIntCount Then
                                        blnHandled = True
                                    End If
                                End If
                            Else
                                If Not MaskedTextBox1.Text.Contains(".") Then
                                    If MaskedTextBox1.Text.Length >= uclIntCount Then
                                        blnHandled = True
                                    End If
                                Else
                                    If MaskedTextBox1.Text.IndexOf(".") <> -1 AndAlso MaskedTextBox1.Text.IndexOf(".") >= uclIntCount Then
                                        blnHandled = True
                                    End If
                                End If

                            End If

                        End If

                    Case Else
                        blnHandled = True

                End Select
                e.Handled = blnHandled
            Case uclTextTypeData.Any_Type

                blnHandled = True

            Case uclTextTypeData.Money_Type

                blnHandled = True
                '     e.Handled = blnHandled
                ' MaskedTextBox1.Mask = "##,###.##"
            Case uclTextTypeData.ID_Type '身分證輸入
                MaskedTextBox1.Mask = ">L000000000"
                blnHandled = True

            Case uclTextTypeData.Time_Hour12, uclTextTypeData.Time_Hour24, uclTextTypeData.Time_Minute, uclTextTypeData.Time_Second
                MaskedTextBox1.Mask = "00"

            Case uclTextTypeData.Time_Hour24AndMinute, uclTextTypeData.Time_Hour12AndMinute
                MaskedTextBox1.Mask = "00:00"

        End Select

    End Sub

    ''' <summary>
    ''' 處理各類Mask
    ''' </summary>
    Private Sub ProcessMask()
        Select Case _uclTextType

            Case uclTextTypeData.ID_Type '身分證輸入
                MaskedTextBox1.Mask = ">L000000000"

            Case uclTextTypeData.Money_Type
                MaskedTextBox1.TextAlign = HorizontalAlignment.Right

            Case uclTextTypeData.Time_Hour12AndMinute, uclTextTypeData.Time_Hour24AndMinute
                MaskedTextBox1.Mask = "00:00"

            Case uclTextTypeData.Time_Hour12, uclTextTypeData.Time_Hour24
                MaskedTextBox1.Mask = "00"

            Case uclTextTypeData.Time_Minute, uclTextTypeData.Time_Second
                MaskedTextBox1.Mask = "00"
            Case Else
                MaskedTextBox1.Mask = ""

        End Select

    End Sub

    ''' <summary>
    ''' MaskedTextBox1_Leave
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave
        Try
            If uclReadOnly Then
                Exit Sub
            End If


            Dim IsError As Boolean = False
            Select Case _uclTextType
                Case uclTextTypeData.DBInteger_Type
                    Try

                        Dim IntDB As Integer = CInt(MaskedTextBox1.Text)
                    Catch of_ex As OverflowException
                        IsError = True
                        MessageBox.Show("輸入數值長度過長!")
                        Exit Sub
                    End Try
                Case uclTextTypeData.Integer_Type

                    If IsNumeric(MaskedTextBox1.Text) Then

                        If Not uclTrimZero Then
                            Dim tag As String = "0."
                            For I As Integer = 0 To uclDotCount - 2
                                tag += "#"
                            Next

                            If tag <> "0." Then
                                MaskedTextBox1.Text = Val(CDec(MaskedTextBox1.Text).ToString(tag & "0"))
                            End If
                        Else
                            MaskedTextBox1.Text = Val(MaskedTextBox1.Text)
                        End If

                    End If

                Case uclTextTypeData.ID_Type '身分證輸入
                    If Not checkId(MaskedTextBox1.Text) AndAlso MaskedTextBox1.Text <> "" Then


                        If txt_dgv Is Nothing Then
                            IsError = True
                            MessageBox.Show(MaskedTextBox1.Text & ":無效的身份證號碼")
                        End If
                        setErrorColor()
                        setTextBoxFocused()
                    Else
                        setDefaultColor()
                    End If
                Case uclTextTypeData.Money_Type
                    MaskedTextBox1.TextAlign = HorizontalAlignment.Right

                Case uclTextTypeData.Time_Hour12AndMinute
                    If MaskedTextBox1.Text.Trim.Replace(":", "") <> "" Then
                        Dim str() As String = Split(MaskedTextBox1.Text.Trim, ":")
                        If Not IsNumeric(str(0)) OrElse Not IsNumeric(str(1)) OrElse CInt(str(0)) > 12 OrElse CInt(str(0)) < 1 OrElse CInt(str(1)) < 0 OrElse CInt(str(1)) > 59 Then
                            MessageBox.Show("時間格式錯誤!")
                            If txt_dgv Is Nothing Then
                                MaskedTextBox1.Focus()
                            End If

                            MaskedTextBox1.BackColor = Color.Pink
                        End If
                    End If
                    'MaskedTextBox1.Mask = "00:00"
                    If MaskedTextBox1.Text.Trim = ":" Then
                        ' MaskedTextBox1.Text = ""
                        MaskedTextBox1.Mask = ""
                        MaskedTextBox1.Text = ""
                        'Exit Sub
                    End If

                Case uclTextTypeData.Time_Hour24AndMinute
                    If MaskedTextBox1.Text.Trim.Replace(":", "") <> "" Then
                        Dim str() As String = Split(MaskedTextBox1.Text.Trim, ":")
                        If Not IsNumeric(str(0)) OrElse Not IsNumeric(str(1)) OrElse CInt(str(0)) > 23 OrElse CInt(str(0)) < 0 OrElse CInt(str(1)) < 0 OrElse CInt(str(1)) > 59 OrElse str(0).Length <> 2 OrElse str(1).Length <> 2 Then
                            IsError = True
                            MessageBox.Show("時間格式錯誤!")
                            If txt_dgv Is Nothing Then
                                MaskedTextBox1.Focus()
                            End If
                            MaskedTextBox1.BackColor = Color.Pink
                        End If
                    End If


                    'MaskedTextBox1.Mask = "00:00"
                    If MaskedTextBox1.Text.Trim = ":" Then
                        ' MaskedTextBox1.Text = ""
                        MaskedTextBox1.Mask = ""
                        MaskedTextBox1.Text = ""
                        'Exit Sub
                    End If

                Case uclTextTypeData.Time_Hour12
                    If MaskedTextBox1.Text.Trim <> "" AndAlso CInt(MaskedTextBox1.Text.Trim) > 12 Then
                        IsError = True
                        MessageBox.Show("時間格式錯誤!")
                        If txt_dgv Is Nothing Then
                            MaskedTextBox1.Focus()
                        End If
                        MaskedTextBox1.BackColor = Color.Pink
                    End If
                Case uclTextTypeData.Time_Hour24
                    If MaskedTextBox1.Text.Trim <> "" AndAlso CInt(MaskedTextBox1.Text.Trim) > 23 Then
                        IsError = True
                        MessageBox.Show("時間格式錯誤!")
                        If txt_dgv Is Nothing Then
                            MaskedTextBox1.Focus()
                        End If
                        MaskedTextBox1.BackColor = Color.Pink
                    End If

                Case uclTextTypeData.Time_Minute, uclTextTypeData.Time_Second
                    If MaskedTextBox1.Text.Trim <> "" AndAlso CInt(MaskedTextBox1.Text.Trim) > 59 Then
                        IsError = True
                        MessageBox.Show("時間格式錯誤!")
                        If txt_dgv Is Nothing Then
                            MaskedTextBox1.Focus()
                        End If
                        MaskedTextBox1.BackColor = Color.Pink
                    End If
            End Select

            If IsError Then
                MaskedTextBox1.Text = "00:00"
                Exit Sub
            End If

            'gridview cell
            If txt_dgv IsNot Nothing AndAlso Not Me.FirstEnterGridCell Then
                ' dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex) = MaskedTextBox1.Text.Trim()
                Me.Visible = False

                If txt_dgv.uclTreeMode Then
                    TreeGridCol = 1
                End If

                'dsDB 存code
                If txt_dgv.MultiSelect Then

                    'dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).DataType = System.Type.GetType("System.String")
                    'dsGrid.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).DataType = System.Type.GetType("System.String")



                    If MaskedTextBox1.Text.Trim = "" AndAlso dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).AllowDBNull AndAlso (dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).DataType.ToString = "System.Int32" OrElse dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).DataType.ToString = "System.Decimal") Then
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = DBNull.Value
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = DBNull.Value

                    ElseIf MaskedTextBox1.Text.Trim = "" AndAlso Not dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).AllowDBNull AndAlso (dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).DataType.ToString = "System.Int32" OrElse dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).DataType.ToString = "System.Decimal") Then
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = "0"
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = "0"

                    Else
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = MaskedTextBox1.Text.Trim()
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = MaskedTextBox1.Text.Trim()
                    End If

                    txt_dgv.doCellValueChange = False

                    If MaskedTextBox1.Text.Trim().Length = 1 Then
                        If (txt_dgv.Columns(cellColIndex).ValueType.ToString = "System.Int32" AndAlso txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value <> 9) OrElse txt_dgv.Columns(cellColIndex).ValueType.ToString = "System.Decimal" Then
                            txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value + 1
                        ElseIf (txt_dgv.Columns(cellColIndex).ValueType.ToString = "System.Int32" AndAlso txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = 9) OrElse txt_dgv.Columns(cellColIndex).ValueType.ToString = "System.Decimal" Then
                            txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value - 1
                        ElseIf txt_dgv.Columns(cellColIndex).ValueType.ToString = "System.String" Then
                            txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = ""
                        End If



                    ElseIf MaskedTextBox1.Text.Trim().Length > 1 Then

                        If (MaskedTextBox1.Text.Trim().Substring(0, 1).Trim = "." OrElse MaskedTextBox1.Text.Trim().Substring(0, 1).Trim = "-") AndAlso IsNumeric(MaskedTextBox1.Text.Trim()) Then
                            txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = CInt(MaskedTextBox1.Text.Trim()) + 1

                        Else
                            txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = MaskedTextBox1.Text.Trim().Substring(0, 1)

                        End If

                    Else

                        txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = "1"
                    End If

                    If OriText.Trim = MaskedTextBox1.Text.Trim() Then
                        txt_dgv.doCellValueChange = False
                    Else
                        txt_dgv.doCellValueChange = True
                    End If

                    If MaskedTextBox1.Text.Trim = "" AndAlso dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).AllowDBNull AndAlso (dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).DataType.ToString = "System.Int32" OrElse dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).DataType.ToString = "System.Decimal") Then
                        txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = DBNull.Value

                    ElseIf MaskedTextBox1.Text.Trim = "" AndAlso Not dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).AllowDBNull AndAlso (dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).DataType.ToString = "System.Int32" OrElse dsDB.Tables(0).Columns(cellColIndex - 1 - TreeGridCol).DataType.ToString = "System.Decimal") Then
                        txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = 0
                    Else
                        txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = GetMaskedTextBoxText()
                    End If

                    txt_dgv.doCellValueChange = True

                Else

                    If MaskedTextBox1.Text.Trim = "" AndAlso dsDB.Tables(0).Columns(cellColIndex - TreeGridCol).AllowDBNull AndAlso (dsDB.Tables(0).Columns(cellColIndex - TreeGridCol).DataType.ToString = "System.Int32" OrElse dsDB.Tables(0).Columns(cellColIndex - TreeGridCol).DataType.ToString = "System.Decimal") Then
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = DBNull.Value
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = DBNull.Value

                    ElseIf MaskedTextBox1.Text.Trim = "" AndAlso Not dsDB.Tables(0).Columns(cellColIndex - TreeGridCol).AllowDBNull AndAlso (dsDB.Tables(0).Columns(cellColIndex - TreeGridCol).DataType.ToString = "System.Int32" OrElse dsDB.Tables(0).Columns(cellColIndex - TreeGridCol).DataType.ToString = "System.Decimal") Then
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = "0"
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = "0"

                    Else
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = MaskedTextBox1.Text.Trim()
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = MaskedTextBox1.Text.Trim()
                    End If

                    txt_dgv.doCellValueChange = False

                    If MaskedTextBox1.Text.Trim().Length = 1 Then

                        If (txt_dgv.Columns(cellColIndex).ValueType.ToString = "System.Int32" AndAlso txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value <> 9) OrElse txt_dgv.Columns(cellColIndex).ValueType.ToString = "System.Decimal" Then
                            txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value + 1
                        ElseIf (txt_dgv.Columns(cellColIndex).ValueType.ToString = "System.Int32" AndAlso txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = 9) OrElse txt_dgv.Columns(cellColIndex).ValueType.ToString = "System.Decimal" Then
                            txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value - 1
                        ElseIf txt_dgv.Columns(cellColIndex).ValueType.ToString = "System.String" Then
                            txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = ""
                        End If

                    ElseIf MaskedTextBox1.Text.Trim().Length > 1 Then
                        txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = MaskedTextBox1.Text.Trim().Substring(0, 1)
                    Else
                        txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = "1"
                    End If

                    If OriText.Trim = MaskedTextBox1.Text.Trim() Then
                        txt_dgv.doCellValueChange = False
                    Else
                        txt_dgv.doCellValueChange = True
                    End If

                    If MaskedTextBox1.Text.Trim = "" AndAlso dsDB.Tables(0).Columns(cellColIndex - TreeGridCol).AllowDBNull AndAlso (dsDB.Tables(0).Columns(cellColIndex - TreeGridCol).DataType.ToString = "System.Int32" OrElse dsDB.Tables(0).Columns(cellColIndex - TreeGridCol).DataType.ToString = "System.Decimal") Then
                        txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = DBNull.Value

                    ElseIf MaskedTextBox1.Text.Trim = "" AndAlso Not dsDB.Tables(0).Columns(cellColIndex - TreeGridCol).AllowDBNull AndAlso (dsDB.Tables(0).Columns(cellColIndex - TreeGridCol).DataType.ToString = "System.Int32" OrElse dsDB.Tables(0).Columns(cellColIndex - TreeGridCol).DataType.ToString = "System.Decimal") Then
                        txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = 0
                    Else

                        txt_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = GetMaskedTextBoxText()
                    End If

                    txt_dgv.doCellValueChange = True

                End If

                If txt_dgv.AllowUserToAddRows AndAlso cellRowIndex = dsGrid.Tables(0).Rows.Count - 1 AndAlso MaskedTextBox1.Text.Trim <> "" Then
                    txt_dgv.AddNewRow()
                End If
            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' GetMaskedTextBoxText
    ''' </summary>
    Private Function GetMaskedTextBoxText() As String

        Try
            If uclTransferForFractions AndAlso MaskedTextBox1.Text.Contains("/") And IsNumeric(MaskedTextBox1.Text.Split("/")(0)) And IsNumeric(MaskedTextBox1.Text.Split("/")(1)) Then

                Dim val As Decimal = CDec(MaskedTextBox1.Text.Split("/")(0)) / CDec(MaskedTextBox1.Text.Split("/")(1))

                Return String.Format("{0:F3}", val)
            End If

            Return MaskedTextBox1.Text.Trim()

        Catch ex As Exception
            Return MaskedTextBox1.Text.Trim()
        End Try
    End Function

    ''' <summary>
    ''' MaskedTextBox1_Enter
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub MaskedTextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Enter
        Try
            Select Case _uclTextType
                Case uclTextTypeData.Integer_Type
                Case uclTextTypeData.ID_Type '身分證輸入
                Case uclTextTypeData.Time_Hour24AndMinute
                    MaskedTextBox1.Mask = "00:00"
                Case uclTextTypeData.Time_Hour12AndMinute
                    MaskedTextBox1.Mask = "00:00"
                Case uclTextTypeData.Money_Type
                    MaskedTextBox1.TextAlign = HorizontalAlignment.Right
            End Select

            '  datagridview cell剛轉為textbox時~~ textbox text為current cell值
            If txt_dgv IsNot Nothing AndAlso Me.FirstEnterGridCell Then
                If txt_dgv.CurrentCell.Value Is DBNull.Value Then
                    MaskedTextBox1.Text = ""
                Else
                    'James 修正TimeSpan錯誤
                    MaskedTextBox1.Text = txt_dgv.CurrentCell.Value.ToString
                    'MaskedTextBox1.Text = txt_dgv.CurrentCell.Value
                    MaskedTextBox1.SelectAll()
                End If

                '此行不可刪
                FirstEnterGridCell = False
                setTextBoxFocused()
            End If
        Catch ex As Exception
            MessageHandling.ShowErrorMsg("CMMCMMB300", New String() {"MaskedTextBox1_Enter錯誤-" & ex.ToString.Trim}, "")
        End Try

    End Sub

    ''' <summary>
    ''' MaskedTextBox1_MouseMove
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    Private Sub MaskedTextBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MaskedTextBox1.MouseMove
        ' RaiseEvent MouseMove(sender, e)

    End Sub

    ''' <summary>
    ''' Handles the Resize event of the UCLTextBoxUC control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub UCLTextBoxUC_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        If UCLFormUtil.isResizeable(Me) Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
        Else
            Me.Height = 27
        End If

    End Sub

    ''' <summary>
    ''' MaskedTextBox1_TextChanged
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub MaskedTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.TextChanged

        Try
            RaiseEvent TextChanged(sender, e)
            'Debug.WriteLine("TextChanged=>" & MaskedTextBox1.Text.Length)
            'If Not StringUtil.CheckMaxLength(MaskedTextBox1.Text, _MaxLength) Then
            '    While Not StringUtil.CheckMaxLength(MaskedTextBox1.Text, _MaxLength)
            '        MaskedTextBox1.Text = MaskedTextBox1.Text.Substring(0, MaskedTextBox1.Text.Length - 1)
            '    End While
            '    MaskedTextBox1.SelectionStart = _MaxLength
            '    ' setTextBoxFocused()

            'End If

            While MaskedTextBox1.Text.Length > MaxLength
                MaskedTextBox1.Text = MaskedTextBox1.Text.Substring(0, MaskedTextBox1.Text.Length - 1)
                MaskedTextBox1.SelectionStart = _MaxLength
            End While

            If MaskedTextBox1.Text <> "" Then

                Select Case _uclTextType

                    Case uclTextTypeData.Time_Hour24AndMinute
                        'MaskedTextBox1.Mask = "00:00"
                        'If MaskedTextBox1.Text.Trim = ":" Then
                        '    ' MaskedTextBox1.Text = ""
                        '    MaskedTextBox1.Mask = ""
                        '    Exit Sub
                        'End If

                        Dim time As String() = MaskedTextBox1.Text.Split(":")

                        If time(0).Trim() <> "" Then
                            Dim time_hour_part As Integer = CInt(time(0))
                            If time_hour_part > 23 OrElse time_hour_part < 0 Then
                                SendKeys.Send("{BACKSPACE}")
                                SendKeys.Send("{BACKSPACE}")
                            End If
                        End If

                        If time(1).Trim() <> "" Then
                            Dim time_minute_part As Integer = CInt(time(1))
                            If time_minute_part > 59 OrElse time_minute_part < 0 Then
                                SendKeys.Send("{BACKSPACE}")
                                SendKeys.Send("{BACKSPACE}")
                            End If
                        End If

                    Case uclTextTypeData.Time_Hour12AndMinute
                        'MaskedTextBox1.Mask = "00:00"
                        'If MaskedTextBox1.Text.Trim = ":" Then
                        '    ' MaskedTextBox1.Text = ""
                        '    MaskedTextBox1.Mask = ""
                        '    Exit Sub
                        'End If

                        Dim time As String() = MaskedTextBox1.Text.Split(":")

                        If time(0).Trim() <> "" Then
                            Dim time_hour_part As Integer = CInt(time(0))
                            If time_hour_part > 11 OrElse time_hour_part < 0 Then
                                SendKeys.Send("{BACKSPACE}")
                                SendKeys.Send("{BACKSPACE}")
                            End If
                        End If

                        If time(1).Trim() <> "" Then
                            Dim time_minute_part As Integer = CInt(time(1))
                            If time_minute_part > 59 OrElse time_minute_part < 0 Then
                                SendKeys.Send("{BACKSPACE}")
                                SendKeys.Send("{BACKSPACE}")
                            End If
                        End If

                    Case uclTextTypeData.Time_Hour12
                        Dim hour As Integer = CInt(MaskedTextBox1.Text)
                        If hour > 11 OrElse hour < 0 OrElse MaskedTextBox1.Text = "00" Then
                            TextReset()
                        End If

                    Case uclTextTypeData.Time_Hour24
                        Dim hour As Integer = CInt(MaskedTextBox1.Text)
                        If hour > 23 OrElse hour < 0 OrElse MaskedTextBox1.Text = "00" Then
                            TextReset()

                        End If

                    Case uclTextTypeData.Time_Minute, uclTextTypeData.Time_Second

                        Dim min_sec As Integer = CInt(MaskedTextBox1.Text)
                        If min_sec > 59 OrElse min_sec < 0 Then
                            TextReset()

                        End If

                End Select

            End If
            setDefaultColor()

        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' MaskedTextBox1_KeyUp
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
    Private Sub MaskedTextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyUp

        Try

            RaiseEvent KeyUp(sender, e)
            If uclReadOnly Then
                Exit Sub
            End If
            'fix ms bugs 無法輸入10個字元
            'Debug.WriteLine("KeyUp=>" & MaskedTextBox1.Text.Length)
            Select Case e.KeyCode
                Case Keys.Decimal ' .

                    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.TextLength < MaxLength AndAlso Not e.Shift Then

                        If MaskedTextBox1.Text.Contains(".") AndAlso uclTextType = uclTextTypeData.Integer_Type Then

                        Else
                            Fix10Char(".")
                        End If

                    End If

                Case Keys.OemPeriod
                    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.TextLength < MaxLength AndAlso Not e.Shift Then
                        If MaskedTextBox1.Text.Contains(".") AndAlso uclTextType = uclTextTypeData.Integer_Type Then

                        Else
                            Fix10Char(".")
                        End If

                    End If

                Case Keys.Oem7 ' '
                    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.TextLength < MaxLength AndAlso Not e.Shift Then
                        Fix10Char("'")
                    ElseIf txt_dgv IsNot Nothing AndAlso MaskedTextBox1.TextLength < MaxLength AndAlso e.Shift Then
                        Fix10Char("""")
                    End If

                Case Keys.D1 '!
                    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.TextLength < MaxLength AndAlso e.Shift Then
                        Fix10Char("!")
                    End If
                Case Keys.D3 '#
                    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.TextLength < MaxLength AndAlso e.Shift Then
                        Fix10Char("#")
                    End If

                Case Keys.D4 '$
                    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.TextLength < MaxLength AndAlso e.Shift Then
                        Fix10Char("$")
                    End If

                Case Keys.D5 '%
                    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.TextLength < MaxLength AndAlso e.Shift Then
                        Fix10Char("%")
                    End If

                Case Keys.D7 '&
                    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.TextLength < MaxLength AndAlso e.Shift Then
                        Fix10Char("&")
                    End If

                Case Keys.D9 '(
                    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.TextLength < MaxLength AndAlso e.Shift Then
                        Fix10Char("(")
                    End If

                Case Keys.Q ' q
                    If txt_dgv IsNot Nothing AndAlso MaskedTextBox1.TextLength < MaxLength AndAlso Not e.Shift AndAlso Not My.Computer.Keyboard.CapsLock Then
                        Fix10Char("q")
                    ElseIf txt_dgv IsNot Nothing AndAlso MaskedTextBox1.TextLength < MaxLength AndAlso e.Shift AndAlso My.Computer.Keyboard.CapsLock Then
                        Fix10Char("q")
                    ElseIf txt_dgv IsNot Nothing AndAlso MaskedTextBox1.Text.Length < MaskedTextBox1.MaxLength AndAlso My.Computer.Keyboard.CapsLock Then
                        Fix10Char("Q")
                    End If
                    'end ms bug

                Case Keys.Enter
                    Select Case _uclTextType
                        Case uclTextTypeData.Integer_Type
                        Case uclTextTypeData.ID_Type '身分證輸入
                            If Not checkId(MaskedTextBox1.Text) AndAlso MaskedTextBox1.Text <> "" Then
                                If txt_dgv Is Nothing Then
                                    MessageBox.Show(MaskedTextBox1.Text & ":無效的身份證號碼")
                                End If

                                setErrorColor()
                            Else
                                setDefaultColor()
                            End If
                        Case uclTextTypeData.Money_Type
                            MaskedTextBox1.TextAlign = HorizontalAlignment.Right
                    End Select

                    'Case Windows.Forms.Keys.Left
                    '    If txt_dgv IsNot Nothing Then
                    '        '    SendKeys.Send("{TAB}")
                    '        txt_dgv.CurrentCell = txt_dgv.Rows(cellRowIndex).Cells(cellColIndex - 1)
                    '    End If

                    'Case Windows.Forms.Keys.Up

                    'Case Windows.Forms.Keys.Down

                    'Case Windows.Forms.Keys.Right
                    '    If txt_dgv IsNot Nothing Then
                    '        SendKeys.Send("{TAB}")
                    '    End If

                Case Else
                    ' Fix10Char()
                    '   Debug.WriteLine(e.KeyData.ToString())
                    '     Debug.WriteLine("textbox key up-------")

            End Select
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' MaskedTextBox1_KeyDown
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown

        RaiseEvent KeyDown(sender, e)

        If uclReadOnly Then
            Exit Sub
        End If
        gblTextNum = MaskedTextBox1.Text.Length
        'Debug.WriteLine("KeyDown=>" & MaskedTextBox1.Text.Length)

        If MaskedTextBox1.SelectedText.Count > 0 Then

            Select Case e.KeyCode
                Case Keys.Shift, Keys.Control, Keys.Alt, Keys.ShiftKey, Keys.ControlKey, Keys.Tab, Keys.Escape, Keys.Capital, Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.End, Keys.Home, Keys.PageDown, Keys.PageUp, Keys.Insert, Keys.Delete

                Case Else
                    MaskedTextBox1.SelectedText = ""

            End Select

        End If

        Select Case e.KeyCode

            'Case Windows.Forms.Keys.Left
            '    If txt_dgv IsNot Nothing Then
            '        '    SendKeys.Send("{TAB}")
            '        txt_dgv.SetEditCell(cellRowIndex, cellColIndex - 1)
            '    End If

            'Case Windows.Forms.Keys.Up
            '    If txt_dgv IsNot Nothing Then
            '        '    SendKeys.Send("{TAB}")
            '        txt_dgv.SetEditCell(cellRowIndex - 1, cellColIndex)
            '    End If
            'Case Windows.Forms.Keys.Down
            '    If txt_dgv IsNot Nothing Then
            '        '    SendKeys.Send("{TAB}")
            '        txt_dgv.SetEditCell(cellRowIndex + 1, cellColIndex)
            '    End If
            'Case Windows.Forms.Keys.Right
            '    If txt_dgv IsNot Nothing Then
            '        txt_dgv.SetEditCell(cellRowIndex, cellColIndex + 1)
            '    End If

            'Case Else
            '    ' Fix10Char()
            '    '   Debug.WriteLine(e.KeyData.ToString())
            '    '     Debug.WriteLine("textbox key up-------"
        End Select
    End Sub

#End Region

#Region "身分證檢查"

    ''' <summary>
    ''' Checks the identifier.
    ''' </summary>
    ''' <param name="id">The identifier.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    Private Function checkId(ByVal id As String) As Boolean

        Try

            Dim idvalue As Integer, checkvalue As Integer

            If id.Length <> 10 Then
                Return False
            End If

            idvalue = Int(getCountyCode(Microsoft.VisualBasic.Left(id, 1)) / 10)
            idvalue = idvalue + (getCountyCode(Microsoft.VisualBasic.Left(id, 1)) Mod 10) * 9

            For i = 2 To 9
                idvalue = idvalue + Mid(id, i, 1) * (10 - i)
            Next

            checkvalue = (10 - (idvalue Mod 10)) Mod 10

            If (checkvalue = Microsoft.VisualBasic.Right(id, 1)) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)   'nckuh.client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function
    ''' <summary>
    ''' Gets the county code.
    ''' </summary>
    ''' <param name="county">The county.</param>
    ''' <returns>System.Int32.</returns>
    Private Function getCountyCode(ByVal county As String) As Integer
        Select Case UCase(county)
            Case "A" : getCountyCode = 10
            Case "B" : getCountyCode = 11
            Case "C" : getCountyCode = 12
            Case "D" : getCountyCode = 13
            Case "E" : getCountyCode = 14
            Case "F" : getCountyCode = 15
            Case "G" : getCountyCode = 16
            Case "H" : getCountyCode = 17
            Case "J" : getCountyCode = 18
            Case "K" : getCountyCode = 19
            Case "L" : getCountyCode = 20
            Case "M" : getCountyCode = 21
            Case "N" : getCountyCode = 22
            Case "P" : getCountyCode = 23
            Case "Q" : getCountyCode = 24
            Case "R" : getCountyCode = 25
            Case "S" : getCountyCode = 26
            Case "T" : getCountyCode = 27
            Case "U" : getCountyCode = 28
            Case "V" : getCountyCode = 29
            Case "W" : getCountyCode = 30
            Case "X" : getCountyCode = 31
            Case "Y" : getCountyCode = 32
            Case "Z" : getCountyCode = 33
            Case "I" : getCountyCode = 34
            Case "O" : getCountyCode = 35
        End Select
    End Function
#End Region

    ''' <summary>
    ''' Reset Text
    ''' </summary>
    Private Sub TextReset()

        '   MaskedTextBox1.Text = ""
        MaskedTextBox1.Focus()
        MaskedTextBox1.SelectionStart = 0 'MS Bug
        SendKeys.Send("{BACKSPACE}")
        SendKeys.Send("{BACKSPACE}")

    End Sub

    ''' <summary>
    ''' set TextBox Focused
    ''' </summary>
    Private Sub setTextBoxFocused()
        'MaskedTextBox1.Focus()
        ' MaskedTextBox1.SelectionStart = MaskedTextBox1.TextLength
    End Sub

    ''' <summary>
    ''' set uclSelect
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub uclSelect(ByVal start As Integer, ByVal length As Integer)
        MaskedTextBox1.Select(start, length)
    End Sub

    ''' <summary>
    ''' set Error Color
    ''' </summary>
    Private Sub setErrorColor()
        '  MaskedTextBox1.BackColor = UCLScreenUtil.BACK_COLOR_ERROR_INPUT
    End Sub

    ''' <summary>
    ''' set Default Color
    ''' </summary>
    Private Sub setDefaultColor()
        Me.BackColor = System.Drawing.SystemColors.Window
        ' MaskedTextBox1.BackColor = UCLScreenUtil.BACK_COLOR_DEFAULT
    End Sub

    ''' <summary>
    ''' Cells the press enter.
    ''' </summary>
    Public Sub cellPressEnter()
        If txt_dgv IsNot Nothing Then

        End If
    End Sub

    ''' <summary>
    ''' fix ms bugs 無法輸入10個字元
    ''' </summary>
    ''' <param name="ch">字元</param>
    Private Sub Fix10Char(ByVal ch As String)
        If InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("美") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("英") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("US") Then
            If (uclTextType = uclTextTypeData.Integer_Type OrElse uclTextType = uclTextTypeData.DBInteger_Type) AndAlso Not ((ch.Equals(".") AndAlso _uclDotCount > 0) OrElse IsNumeric("-") OrElse IsNumeric(ch)) Then
                '限制數值型輸入只能填入數字,- ,.
                Exit Sub
            End If
            Dim pos As Integer = MaskedTextBox1.SelectionStart
            MaskedTextBox1.Text = MaskedTextBox1.Text.Substring(0, MaskedTextBox1.SelectionStart) + ch + MaskedTextBox1.Text.Substring(MaskedTextBox1.SelectionStart)
            pos += 1
            MaskedTextBox1.SelectionStart = pos
        End If

    End Sub

    ''' <summary>
    ''' Initial TextBox Cell
    ''' </summary>
    ''' <param name="grid">來源grid</param>
    ''' <param name="dDB">dbDS</param>
    ''' <param name="dGrid">gridDS</param>
    ''' <param name="ColIndex">Col Index</param>
    ''' <param name="RowIndex">Row Index</param>
    Public Sub InitialTextBoxCell(ByRef grid As UCLDataGridViewUC, ByRef dDB As DataSet, ByRef dGrid As DataSet, ByVal ColIndex As Integer, ByVal RowIndex As Integer)

        txt_dgv = grid
        cellRowIndex = RowIndex
        cellColIndex = ColIndex

        dsDB = dDB
        dsGrid = dGrid

        Try
            If txt_dgv.MultiSelect Then
                OriText = dDB.Tables(0).Rows(RowIndex).Item(ColIndex - 1).ToString.Trim()
            Else
                OriText = dDB.Tables(0).Rows(RowIndex).Item(ColIndex).ToString.Trim()
            End If
        Catch ex As Exception
        End Try

    End Sub

    ''' <summary>
    ''' MaskedTextBox1_MouseClick
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    Private Sub MaskedTextBox1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MaskedTextBox1.MouseClick
        Try
            Select Case _uclTextType
                Case uclTextTypeData.Time_Hour24AndMinute, uclTextTypeData.Time_Hour12AndMinute
                    If Me.MaskedTextBox1.Text.Trim.Replace(":", "") = "" Then
                        Me.MaskedTextBox1.SelectionStart = 0
                        Me.MaskedTextBox1.SelectionLength = 0
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub

End Class