Imports Syscom.Client.CMM

Public Class UclNumericKeypadUI
    Inherits Syscom.Client.UCL.BaseFormUI
#Region "　變數宣告"

    '設定字數的字元的長度
    Private gblNumericArrLength As Decimal = 0
    Private gblDotCount As Integer = 0
    '組成的數字字串
    Private gblNumericStr As String = "0"
    Private gblPanel As TableLayoutPanel
    Private gblBackColor As Color = Color.Yellow
    Dim WithEvents pvtSendMgr As EventManager = EventManager.getInstance
    Public Event Confirm(ByVal sender As System.Object, ByVal value As String)
    '預設的數字範圍
    Private gblDefaultNum As String = ""
    '數字上下限
    Private gblValueFloor As Decimal = 0.0
    Private gblValueCeiling As Decimal = 0.0
    '預設0=整數,1=小數
    Private gblSettingType As Integer = 0
    '基數 最小單位的間隔數字
    Private gblCardinalNumber As Decimal = 0.0
    Private gblDefaultStartValue As Decimal = 0.0
    Private gblDefaultBtnIndex As Int32 = 1
#End Region

#Region "　Property宣告"

    ''' <summary>
    ''' 設定字串長度，並且根據傳入的數字去決定要開啟幾列鍵盤
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Digits() As String
        Get
            Return gblNumericArrLength
        End Get
        Set(value As String)
            gblNumericArrLength = value
            iniKeypadValue(gblNumericArrLength)
        End Set
    End Property

    ''' <summary>
    ''' 設定背景顏色(按鈕被點時)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SetBackColorForClick() As Color
        Get
            Return gblBackColor
        End Get
        Set(value As Color)
            gblBackColor = value
        End Set
    End Property

    ''' <summary>
    ''' 取得數字字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GetNumericStr() As Decimal
        Get
            Return gblNumericStr
        End Get
        Set(value As Decimal)
            gblNumericStr = value
        End Set
    End Property

    ''' <summary>
    ''' 給予使用者一個預設值的區間
    ''' 例如：0~90,100~190,30~40
    ''' </summary>
    ''' <remarks></remarks>
    Public Property DefaultNumArea() As String

        Get
            Return gblDefaultNum
        End Get
        Set(value As String)
            gblDefaultNum = value
        End Set
    End Property

    ''' <summary>
    ''' 設定初始化區間按鈕位置
    ''' </summary>
    ''' <remarks></remarks>
    Public Property DefaultStartValue() As String

        Get
            Return gblDefaultStartValue
        End Get
        Set(value As String)
            gblDefaultStartValue = value
        End Set
    End Property

#End Region

#Region "　外部函數"
    Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
    End Sub
    Sub New(ByVal numStr As String)
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        gblNumericStr = numStr
        txt_num.Text = numStr
        Me.KeyPreview = True
    End Sub
#End Region

#Region "　內部函數"

#Region "     初始化"
    ''' <summary>
    ''' 初始化數字鍵盤
    ''' </summary>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Private Sub iniKeypadValue(ByVal value As String)
        Try


            ''value傳入如果是3.2則表示小數點前有3位，後2位
            ''否則則是為Int型態，只根據長度做初始化
            If value.Contains(".") AndAlso value.Split(".")(1) > 0 Then
                gblNumericArrLength = (Int(value.Split(".")(0)) + Int(value.Split(".")(1)) + 1)
                txt_num.uclIntCount = value.Split(".")(0)
                txt_num.uclDotCount = value.Split(".")(1)
                gblSettingType = 1
                gblCardinalNumber = 10 ^ (-txt_num.uclDotCount)
            Else

                '2016/04/23 Sean: 取得最小的數字是三
                '因為整數，左邊最小為10分位
                If gblNumericArrLength < 3 Then
                    txt_num.uclIntCount = 3
                Else
                    txt_num.uclIntCount = gblNumericArrLength
                End If
                gblSettingType = 0
                gblCardinalNumber = 10 ^ (txt_num.uclIntCount) / 100

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 初始化顯示預設值
    ''' </summary>
    ''' <remarks></remarks>
    Private Overloads Sub Show() Handles Me.Shown
        Try
            Me.KeyPreview = True

            If gblDefaultNum <> "" Then
                ProcessDefaultNum()
                GetNumRange()
            Else
                ShowPad()
                btn_Back.Visible = False
            End If

            '優先處理如果有設定預設區間的選項
            If gblDefaultBtnIndex > 1 Then

                CType(flp_DefaultButtonPanel.Controls.Item("btn_Default" & gblDefaultBtnIndex), Button).PerformClick()

            ElseIf btn_Default1.Visible Then
                btn_Default1.PerformClick()
            Else
                '沒預設值就開數字鍵盤
                btn_ChangePad.PerformClick()
            End If
            txt_num.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "     事件集合"

    ''' <summary>
    ''' 數字區按鈕的事件集合(預設區)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEventHandle(sender As Object, e As EventArgs) Handles btn_DefaultRow0_0.Click, btn_DefaultRow0_1.Click, btn_DefaultRow0_2.Click, btn_DefaultRow0_3.Click, btn_DefaultRow0_4.Click, btn_DefaultRow0_5.Click, btn_DefaultRow0_6.Click, btn_DefaultRow0_7.Click, btn_DefaultRow0_8.Click, btn_DefaultRow0_9.Click, _
                                                                         btn_DefaultRow1_0.Click, btn_DefaultRow1_1.Click, btn_DefaultRow1_2.Click, btn_DefaultRow1_3.Click, btn_DefaultRow1_4.Click, btn_DefaultRow1_5.Click, btn_DefaultRow1_6.Click, btn_DefaultRow1_7.Click, btn_DefaultRow1_8.Click, btn_DefaultRow1_9.Click, _
                                                                         btn_DefaultRow2_0.Click, btn_DefaultRow2_1.Click, btn_DefaultRow2_2.Click, btn_DefaultRow2_3.Click, btn_DefaultRow2_4.Click, btn_DefaultRow2_5.Click, btn_DefaultRow2_6.Click, btn_DefaultRow2_7.Click, btn_DefaultRow2_8.Click, btn_DefaultRow2_9.Click, _
                                                                         btn_DefaultRow3_0.Click, btn_DefaultRow3_1.Click, btn_DefaultRow3_2.Click, btn_DefaultRow3_3.Click, btn_DefaultRow3_4.Click, btn_DefaultRow3_5.Click, btn_DefaultRow3_6.Click, btn_DefaultRow3_7.Click, btn_DefaultRow3_8.Click, btn_DefaultRow3_9.Click, _
                                                                         btn_DefaultRow4_0.Click, btn_DefaultRow4_1.Click, btn_DefaultRow4_2.Click, btn_DefaultRow4_3.Click, btn_DefaultRow4_4.Click, btn_DefaultRow4_5.Click, btn_DefaultRow4_6.Click, btn_DefaultRow4_7.Click, btn_DefaultRow4_8.Click, btn_DefaultRow4_9.Click, _
                                                                         btn_DefaultRow5_0.Click, btn_DefaultRow5_1.Click, btn_DefaultRow5_2.Click, btn_DefaultRow5_3.Click, btn_DefaultRow5_4.Click, btn_DefaultRow5_5.Click, btn_DefaultRow5_6.Click, btn_DefaultRow5_7.Click, btn_DefaultRow5_8.Click, btn_DefaultRow5_9.Click, _
                                                                         btn_DefaultRow6_0.Click, btn_DefaultRow6_1.Click, btn_DefaultRow6_2.Click, btn_DefaultRow6_3.Click, btn_DefaultRow6_4.Click, btn_DefaultRow6_5.Click, btn_DefaultRow6_6.Click, btn_DefaultRow6_7.Click, btn_DefaultRow6_8.Click, btn_DefaultRow6_9.Click, _
                                                                         btn_DefaultRow7_0.Click, btn_DefaultRow7_1.Click, btn_DefaultRow7_2.Click, btn_DefaultRow7_3.Click, btn_DefaultRow7_4.Click, btn_DefaultRow7_5.Click, btn_DefaultRow7_6.Click, btn_DefaultRow7_7.Click, btn_DefaultRow7_8.Click, btn_DefaultRow7_9.Click, _
                                                                         btn_DefaultRow8_0.Click, btn_DefaultRow8_1.Click, btn_DefaultRow8_2.Click, btn_DefaultRow8_3.Click, btn_DefaultRow8_4.Click, btn_DefaultRow8_5.Click, btn_DefaultRow8_6.Click, btn_DefaultRow8_7.Click, btn_DefaultRow8_8.Click, btn_DefaultRow8_9.Click, _
                                                                         btn_DefaultRow9_0.Click, btn_DefaultRow9_1.Click, btn_DefaultRow9_2.Click, btn_DefaultRow9_3.Click, btn_DefaultRow9_4.Click, btn_DefaultRow9_5.Click, btn_DefaultRow9_6.Click, btn_DefaultRow9_7.Click, btn_DefaultRow9_8.Click, btn_DefaultRow9_9.Click

        Try
            Dim rowIndex As Integer = sender.Name.ToString.Split("_")(1).Substring(sender.Name.ToString.Split("_")(1).Length - 1, 1)
            Dim Num As String = ""
            If tlp_DefaultPanel.Controls.Item("txt_DefaultNumHead_" & rowIndex).Text <> "0" Then
                Num = tlp_DefaultPanel.Controls.Item("txt_DefaultNumHead_" & rowIndex).Text & sender.Name.ToString.Substring(sender.Name.ToString.Length - 1, 1)
            Else
                Num = sender.Name.ToString.Substring(sender.Name.ToString.Length - 1, 1)
            End If
            gblNumericStr = Num
            txt_num.Text = Num
            '設定該排按鈕背景色
            SetButtonColor(sender.Name.ToString, rowIndex)
            '檢核文字數值
            If CheckValueFloorAndCeiling() Then
                ClearColorAndText()
            Else
                btn_confirm.PerformClick()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 數字區按鈕的事件集合(數字鍵盤)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub KeyPadEventHandle(sender As Object, e As EventArgs) Handles btn_NumPad0.Click, btn_NumPad1.Click, btn_NumPad2.Click, btn_NumPad3.Click, btn_NumPad4.Click, btn_NumPad5.Click, btn_NumPad6.Click, btn_NumPad7.Click, btn_NumPad8.Click, btn_NumPad9.Click, btn_NumPadDot.Click

        Try
            Dim Num As String = sender.Name.ToString.Substring(sender.Name.ToString.Length - 1, 1)

            If Not IsNumeric(Num) Then
                Num = "."
            End If

            '設定與組成數字字串
            gblNumericStr = gblNumericStr & Num
            If gblNumericStr.Split(".").Length > 2 Then
                gblNumericStr = gblNumericStr.Substring(0, gblNumericStr.Length - 1)
            End If
            CheckValue(gblNumericStr)
            txt_num.Text = gblNumericStr

            '設定該排按鈕背景色
            For Each c As Control In tlp_NumPad.Controls
                If Not c.Name.ToString.Equals("btn_NumPad" & IIf(IsNumeric(Num), Num, "Dot")) Then
                    c.BackColor = SystemColors.Control
                Else
                    c.BackColor = SetBackColorForClick
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 數字檢核
    ''' </summary>
    ''' <param name="numStr"></param>
    ''' <remarks></remarks>
    Private Sub CheckValue(ByRef numStr As String)
        Try
            Dim DotNum As String = ""
            Dim IntNum As String = ""
            If numStr.Contains(".") Then
                '1.1 判斷小數點前後位數是否大於設定值
                DotNum = numStr.Split(".")(1)
                IntNum = numStr.Split(".")(0)
                If DotNum.Length > txt_num.uclDotCount Then
                    DotNum = DotNum.Substring(0, DotNum.Length - 1)
                End If
                '1.2 判斷小數點前位數是否大於設定值
                If IntNum.Length > txt_num.uclIntCount Then
                    IntNum = IntNum.Substring(0, IntNum.Length - 1)
                End If
                numStr = IntNum & "." & DotNum
            Else
                IntNum = numStr
                '2. 單純整數型態判斷
                If IntNum.Length > txt_num.uclIntCount Then
                    IntNum = IntNum.Substring(0, IntNum.Length - 1)
                End If
                numStr = IntNum
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 熱鍵相關事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_num_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    btn_confirm.PerformClick()
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "     清除事件"

    ''' <summary>
    ''' 清除按鈕顏色與文字
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearColorAndText()

        Try

            txt_num.Text = ""
            gblNumericStr = ""

            Dim tempPanel As TableLayoutPanel
            '清除預設鍵盤的按鈕底色
            For i As Integer = 0 To 9
                tempPanel = tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & i)
                For Each c As Control In tempPanel.Controls
                    c.BackColor = SystemColors.Control
                Next
            Next
            '清除數字鍵盤的按鈕底色
            For i As Integer = 0 To 10
                For Each c As Control In tlp_NumPad.Controls
                    c.BackColor = SystemColors.Control
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    ''' <summary>
    ''' 設定與清除按鈕背景色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetButtonColor(ByVal btnName As String, ByVal rowIndex As Integer)
        Try
            '先全部顏色清除
            Dim tempPanel As TableLayoutPanel

            For i As Integer = 0 To 9
                tempPanel = tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & i)
                For Each c As Control In tempPanel.Controls
                    c.BackColor = SystemColors.Control
                Next
            Next

            gblPanel = tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & rowIndex)
            For Each ctl As Control In gblPanel.Controls
                If Not ctl.Name.ToString.Equals(btnName) Then
                    ctl.BackColor = SystemColors.Control
                Else
                    ctl.BackColor = SetBackColorForClick
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region "     檢核與設定"

    ''' <summary>
    ''' 設定預設值區間
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcessDefaultNum()
        Try
            'TrimEnd的處理方法只適用帶有.00之類的decimal字串，帶有小數會造成後續Head判讀異常
            If Not gblDefaultNum.Split("~")(1).ToString.Contains(".") Then
                gblValueFloor = gblDefaultNum.Split("~")(1)
            Else
                gblValueFloor = gblDefaultNum.Split("~")(1).TrimEnd(New String({"0", "."}))
            End If

            If Not gblDefaultNum.Split("~")(0).ToString.Contains(".") Then
                gblValueCeiling = gblDefaultNum.Split("~")(0)
            Else
                gblValueCeiling = gblDefaultNum.Split("~")(0).TrimEnd(New String({"0", "."}))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 分割傳進來的參數設定數字區間數
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetNumRange()
        Dim defaultValueArr As String() = {}

        Try
            Select Case gblSettingType
                '處理整數型態的Case
                Case 0
                    '設定數字區間，用來設定顯示按鈕來改變顯示的預設值
                    '個位數=0,十位數=10,百位數=100，用來處理顯示預設按鈕
                    '2016/04/23 Sean: 
                    '每一個區間只允許十個十位數字，所以固定除以10
                    Dim BtnCount As Integer = Math.Ceiling(((gblValueFloor - gblValueCeiling) / gblCardinalNumber) / 10) '+ 1

                    '2016/04/23 Sean: 
                    '如果沒有餘數，表示剛好臨界值要多一個按鈕
                    If ((gblValueFloor - gblValueCeiling) / gblCardinalNumber) Mod 10 = 0 Then
                        BtnCount += 1
                    End If

                    Dim TempNum As Integer = 0
                    If BtnCount > 8 Then
                        MessageBox.Show("區間過大，請使用基本數字鍵盤!")
                        ShowPad()
                        btn_Back.Enabled = False
                        Exit Sub
                    End If

                    For i As Decimal = 1D To BtnCount

                        flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Visible = True
                        If i = 1 AndAlso BtnCount > 1 Then
                            '第一個區間按鈕
                            '2016/04/23 Sean: 乘以10(去掉最後的1, 因為是下一個區間的第一個)
                            If Not CInt(DefaultStartValue).Equals(0) Then
                                TempNum = gblValueCeiling + DefaultStartValue - 1
                            Else
                                TempNum = gblValueCeiling + gblCardinalNumber * 10 - 1
                            End If

                            If TempNum > gblValueFloor Then
                                flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = gblValueCeiling & "~" & gblValueFloor
                            Else
                                If DefaultStartValue > gblValueCeiling + gblCardinalNumber * 10 - 1 Then
                                    flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = Math.Abs(DefaultStartValue - (gblCardinalNumber * 10)) & "~" & TempNum
                                Else

                                    flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = gblValueCeiling & "~" & TempNum
                                End If
                            End If
                            '只有一個區間
                        ElseIf BtnCount = 1 AndAlso i = 1 Then
                            'flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = gblValueCeiling & "~" & (gblValueFloor - 1)
                            flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = gblValueCeiling & "~" & (gblValueFloor)
                            'ElseIf BtnCount = i Then
                            '    flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = gblValueFloor & "~" & gblValueFloor
                        Else
                            '其他情況，一個以上區間，且非第一個或最後一個
                            '2016/04/23 Sean: 根據區間，10個數字進一位
                            TempNum = TempNum + gblCardinalNumber * 10 '- 1
                            If TempNum > gblValueFloor Then
                                '2016/04/23 Sean: 因為是下一個區間的第一個，所以要把上一個區間的最後一個加1)
                                flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = flp_DefaultButtonPanel.Controls.Item("btn_Default" & i - 1).Text.Split("~")(1) + 1 & "~" & gblValueFloor
                            Else
                                '2016/04/23 Sean: 因為是下一個區間的第一個，所以要把上一個區間的最後一個加1)
                                flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = flp_DefaultButtonPanel.Controls.Item("btn_Default" & i - 1).Text.Split("~")(1) + 1 & "~" & TempNum
                            End If
                        End If

                            defaultValueArr = flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text.Split("~")
                            '找出預設按鈕的Index
                            If gblDefaultStartValue >= defaultValueArr(0) AndAlso gblDefaultStartValue <= defaultValueArr(1) Then
                                gblDefaultBtnIndex = i
                            End If
                    Next
                Case 1
                    '設定數字區間，用來設定顯示按鈕來改變顯示的預設值
                    '根據SetDigits傳進來的小數位去處理

                    Dim BtnCount As Integer = Math.Ceiling(((gblValueFloor - gblValueCeiling) / gblCardinalNumber) / 100) '+ 1
                    '2016/04/23 Sean: 
                    '如果沒有餘數，表示剛好臨界值要多一個按鈕
                    If ((gblValueFloor - gblValueCeiling) / gblCardinalNumber) Mod 100 = 0 Then
                        BtnCount += 1
                    End If

                    Dim TempNum As Double = 0.0
                    If BtnCount > 8 Then
                        MessageBox.Show("區間過大，請使用基本數字鍵盤!")
                        ShowPad()
                        btn_Back.Enabled = False
                        Exit Sub
                    End If
                    For i As Decimal = 1D To BtnCount
                        flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Visible = True
                        If i = 1 AndAlso BtnCount > 1 Then
                            '表示有一個以上區間，且為區間的第一個按鈕
                            TempNum = gblValueCeiling + gblCardinalNumber * 90
                            flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = gblValueCeiling & "~" & TempNum
                            '只有一個區間
                        ElseIf BtnCount = 1 AndAlso i = 1 Then
                            flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = gblValueCeiling & "~" & gblValueFloor
                        ElseIf BtnCount = i Then
                            flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = TempNum & "~" & gblValueFloor
                        Else
                            '其他情況，一個以上區間，且非第一個或最後一個
                            If TempNum + gblCardinalNumber * 90 > gblValueFloor Then
                                flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = TempNum & "~" & gblValueFloor
                            Else
                                flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text = TempNum & "~" & TempNum + gblCardinalNumber * 90
                            End If
                            TempNum = TempNum + gblCardinalNumber * 90
                        End If
                        defaultValueArr = flp_DefaultButtonPanel.Controls.Item("btn_Default" & i).Text.Split("~")
                        '找出預設按鈕的Index
                        If gblDefaultStartValue >= defaultValueArr(0) AndAlso gblDefaultStartValue <= defaultValueArr(1) Then
                            gblDefaultBtnIndex = i
                        End If
                    Next
            End Select
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' 檢核輸入數值是否超出上下限
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckValueFloorAndCeiling() As Boolean
        Try

            If txt_num.uclDotCount > 0 Then
                '檢核小數點模式
                If CDec(txt_num.Text) > gblValueFloor Then
                    MessageBox.Show("超出上限值")
                    Return True
                ElseIf CDec(txt_num.Text) < gblValueCeiling Then
                    MessageBox.Show("低於下限值")
                    Return True
                End If
            Else
                '檢核整數模式
                If CInt(txt_num.Text) > gblValueFloor Then
                    MessageBox.Show("超出上限值")
                    Return True
                ElseIf CInt(txt_num.Text) < gblValueCeiling Then
                    MessageBox.Show("低於下限值")
                    Return True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "     按鈕事件"

    ''' <summary>
    ''' 開啟數字九宮格，關閉預設相關按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_ChangePad_Click(sender As Object, e As EventArgs) Handles btn_ChangePad.Click
        Try
            ShowPad()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Show九宮格
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowPad()
        txt_num.Text = ""
        gblNumericStr = ""
        tlp_DefaultPanel.Visible = False
        flp_Default.Visible = False
        flp_NumPadPanel.Visible = True
        tlp_NumPad.Visible = True
        btn_ChangePad.Visible = False
        btn_Back.Visible = True
        btn_Clear.Visible = True
        txt_num.Focus()
    End Sub

    ''' <summary>
    ''' 關閉九宮格，回到預設按鈕鍵盤
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Back_Click(sender As Object, e As EventArgs) Handles btn_Back.Click
        Try
            btn_Clear.PerformClick()
            flp_Default.Visible = True
            tlp_DefaultPanel.Visible = True
            flp_NumPadPanel.Visible = False


            btn_ChangePad.Visible = True
            btn_Back.Visible = False
            btn_Clear.Visible = False
            btn_Default1.PerformClick()
            txt_num.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 確認
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click
        Try
            gblNumericStr = txt_num.Text
            Me.Close()
            RaiseEvent Confirm(sender, gblNumericStr)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 取消
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 預設數字區間設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Default_Click(sender As Object, e As EventArgs) Handles btn_Default1.Click, btn_Default2.Click, btn_Default3.Click, _
                                                                            btn_Default4.Click, btn_Default5.Click, btn_Default6.Click, _
                                                                            btn_Default7.Click, btn_Default8.Click

        Dim RangeAmount As Integer = 0
        Dim TempNum As Decimal = 0.0
        Try
            ClearColorAndText()
            '先把所有欄位都藏起來
            For i As Integer = 0 To 9
                tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & i).Visible = False
                tlp_DefaultPanel.Controls.Item("txt_DefaultNumHead_" & i).Visible = False
                For y As Int32 = 0 To 9
                    tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & i).Controls.Item("btn_DefaultRow" & i & "_" & y).Visible = True
                Next
            Next
            '如果相減大於10， 10~30、100~190...等情況
            Select Case gblSettingType
                '處理整數型態的Case
                Case 0
                    flp_Default.Visible = True

                    RangeAmount = Math.Ceiling((CDec(sender.text.ToString.Split("~")(1)) - CDec(sender.text.ToString.Split("~")(0)) + 1) / gblCardinalNumber)

                    '在依照列數開放
                    For i = 0 To RangeAmount - 1
                        tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & i).Visible = True
                        tlp_DefaultPanel.Controls.Item("txt_DefaultNumHead_" & i).Visible = True

                        If i = 0 Then
                            If sender.text.ToString.Split("~")(0).Length > 1 Then
                                TempNum = sender.text.ToString.Split("~")(0).Substring(0, sender.text.ToString.Split("~")(0).Length - 1)
                            Else
                                TempNum = sender.text.ToString.Split("~")(0)
                            End If
                            '第一列=下限值
                            For y As Int32 = 0 To 9
                                Dim num As Decimal = CDec(TempNum & tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & i).Controls.Item("btn_DefaultRow" & i & "_" & y).Text)
                                If num < sender.text.ToString.Split("~")(0) OrElse num > sender.text.ToString.Split("~")(1) Then
                                    tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & i).Controls.Item("btn_DefaultRow" & i & "_" & y).Visible = False
                                End If
                            Next
                        ElseIf i = RangeAmount - 1 Then
                            '最後一列=上限值
                            TempNum = TempNum + 1
                            For y As Int32 = 0 To 9
                                Dim num As Decimal = CDec(TempNum & tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & i).Controls.Item("btn_DefaultRow" & i & "_" & y).Text)
                                '大於小於按鈕區間的Btn不顯示
                                If num < sender.text.ToString.Split("~")(0) OrElse num > sender.text.ToString.Split("~")(1) Then
                                    tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & i).Controls.Item("btn_DefaultRow" & i & "_" & y).Visible = False
                                End If
                            Next
                        Else
                            TempNum = TempNum + 1
                        End If
                        'Head數字的處理

                        tlp_DefaultPanel.Controls.Item("txt_DefaultNumHead_" & i).Text = TempNum

                    Next

                Case 1

                    Dim TempNumDot As String = ""
                    RangeAmount = Math.Ceiling((CDec(sender.text.ToString.Split("~")(1)) - CDec(sender.text.ToString.Split("~")(0))) / gblCardinalNumber / 10) + 1

                    If RangeAmount > 10 Then
                        MessageBox.Show("區間過大，請使用基本數字鍵盤!")
                        ShowPad()
                        btn_Back.Enabled = False
                        Exit Sub
                    End If


                    '在依照列數開放
                    For i = 0 To RangeAmount - 1
                        tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & i).Visible = True
                        tlp_DefaultPanel.Controls.Item("txt_DefaultNumHead_" & i).Visible = True
                        If i = 0 Then
                            '第一列=下限值
                            If sender.text.ToString.Contains(".") Then
                                TempNumDot = sender.text.ToString.Split("~")(0).Substring(0, sender.text.ToString.Split("~")(0).Length - 1)
                            Else
                                TempNumDot = sender.text.ToString.Split("~")(0)
                            End If
                        ElseIf i = RangeAmount - 1 Then
                            TempNumDot = Math.Round(TempNumDot + 1 / (10 ^ (txt_num.uclDotCount - 1)), CInt(txt_num.uclDotCount - 1))
                            '最後一列=上限值
                        Else
                            TempNumDot = Math.Round(TempNumDot + 1 / (10 ^ (txt_num.uclDotCount - 1)), CInt(txt_num.uclDotCount - 1))
                        End If
                        If Not TempNumDot.Contains(".") Then
                            TempNumDot = TempNumDot & "."
                            For y As Int32 = 1 To txt_num.uclDotCount - 1
                                TempNumDot = TempNumDot & "0"
                            Next
                            tlp_DefaultPanel.Controls.Item("txt_DefaultNumHead_" & i).Text = TempNumDot
                        Else
                            tlp_DefaultPanel.Controls.Item("txt_DefaultNumHead_" & i).Text = TempNumDot
                        End If

                        For y As Int32 = 0 To 9
                            Dim num As Decimal = CDec(TempNumDot & tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & i).Controls.Item("btn_DefaultRow" & i & "_" & y).Text)
                            If num > sender.Text.ToString().Split("~")(1) Or num < sender.Text.ToString().Split("~")(0) Then
                                tlp_DefaultPanel.Controls.Item("tlp_DefaultRow" & i).Controls.Item("btn_DefaultRow" & i & "_" & y).Visible = False
                            End If
                        Next
                    Next

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 清除數字
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        ClearColorAndText()
        txt_num.Focus()
    End Sub

#End Region

#Region "     Cbk點擊事件"

    ''' <summary>
    ''' 測不到
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ckb_NoneMeasure_CheckedChanged(sender As Object, e As EventArgs)
        Try
            If ckb_NoneMeasure.Checked Then
                Me.Close()
                ckb_NoneMeasure.Checked = False
                RaiseEvent Confirm(sender, ckb_NoneMeasure.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 拒量
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbk_Reject_CheckedChanged(sender As Object, e As EventArgs)
        Try
            If cbk_Reject.Checked Then
                Me.Close()
                cbk_Reject.Checked = False
                RaiseEvent Confirm(sender, cbk_Reject.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 無法測量
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ckb_NoMeasure_CheckedChanged(sender As Object, e As EventArgs)
        Try
            If cbk_noMeasure.Checked Then
                Me.Close()
                cbk_noMeasure.Checked = False
                RaiseEvent Confirm(sender, cbk_noMeasure.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 問號
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbk_quesMark_CheckedChanged(sender As Object, e As EventArgs)
        Try
            If cbk_quesMark.Checked Then
                Me.Close()
                cbk_quesMark.Checked = False
                RaiseEvent Confirm(sender, cbk_quesMark.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' V
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkV_CheckedChanged(sender As Object, e As EventArgs)
        Try
            If chkV.Checked Then
                Me.Close()
                chkV.Checked = False
                RaiseEvent Confirm(sender, chkV.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' X
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkX_CheckedChanged(sender As Object, e As EventArgs)
        Try
            If chkX.Checked Then
                Me.Close()
                chkX.Checked = False
                RaiseEvent Confirm(sender, chkX.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 請假
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ckb_takeDateoff_CheckedChanged(sender As Object, e As EventArgs)
        Try
            If ckb_takedateoff.Checked Then
                Me.Close()
                ckb_takedateoff.Checked = False
                RaiseEvent Confirm(sender, ckb_takedateoff.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#End Region



 
 

End Class