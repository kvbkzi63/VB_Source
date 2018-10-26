Public Class UclTimeKeypadUI
    Inherits BaseFormUI

#Region "  變數宣告"
    '時間欄位字串
    Public gblTimeStr As String = ""
    '背景顏色
    Private gblColor As Color = Color.Yellow
    '暫存數字變數
    Private gblHourTens As Integer = 0
    Private gblHourDigits As Integer = 0
    Private gblMiTens As Integer = 0
    Private gblMiDigits As Integer = 0
    Public Event Confirm(ByVal sender As System.Object, ByVal value As String, ByVal noInputFlag As Boolean)
    Public Event ValueChange(ByVal sender As Object, ByVal e As EventArgs)


#End Region

#Region "  屬性設定"
    ''' <summary>
    ''' 依據使用者喜好傳入顏色參數
    ''' </summary>
    ''' <value>True or False</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SetColor() As Color
        Get
            Return gblColor
        End Get
        Set(value As Color)
            gblColor = value
        End Set
    End Property
#End Region

#Region "  初始化設定"

    Public Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub
    Public Sub New(ByVal TimeStr As String)

        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        gblTimeStr = TimeStr
        If TimeStr.Length = 5 Then
            gblHourTens = gblTimeStr.Substring(0, 1)
            gblHourDigits = gblTimeStr.Substring(1, 1)
            gblMiTens = gblTimeStr.Substring(3, 1)
            gblMiDigits = gblTimeStr.Substring(4, 1)
            SetDefaultButtonColor()
        End If
    End Sub
    Public Sub UclTimeKeypadUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            txt_time.Focus()
            txt_time.Text = gblTimeStr
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

#End Region

#Region "  事件處理"
    ''' <summary>
    ''' 確定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Try

            Me.Close()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' 取消
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Confirm_Click(sender As Object, e As EventArgs) Handles btn_Confirm.Click
        Try
            Dim noInputFlag As Boolean = False
            gblTimeStr = txt_time.Text
            If gblTimeStr = "" Then
                noInputFlag = True
            End If

            RaiseEvent Confirm(sender, gblTimeStr, noInputFlag)
            Me.Close()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 處理所有按鍵被點擊的事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Numbers_Click(sender As Object, e As EventArgs) Handles btn_HTens0.Click, btn_HTens1.Click, btn_HTens2.Click, _
                                                                            btn_HDigits0.Click, btn_HDigits1.Click, btn_HDigits2.Click, _
                                                                            btn_HDigits3.Click, btn_HDigits4.Click, btn_HDigits5.Click, _
                                                                            btn_HDigits6.Click, btn_HDigits7.Click, btn_HDigits8.Click, btn_HDigits9.Click, _
                                                                            btn_MTens0.Click, btn_MTens1.Click, btn_MTens2.Click, _
                                                                            btn_MTens3.Click, btn_MTens4.Click, btn_MTens5.Click, _
                                                                            btn_MDigits0.Click, btn_MDigits1.Click, btn_MDigits2.Click, btn_MDigits3.Click, _
                                                                            btn_MDigits4.Click, btn_MDigits5.Click, btn_MDigits6.Click, btn_MDigits7.Click, _
                                                                            btn_MDigits8.Click, btn_MDigits9.Click
        Try
            Dim rowIndex As Integer = 0
            Dim getBtnName As String = sender.Name.ToString
            'Step.1 先找出使用者到底點的是第幾排的按鈕
            If getBtnName.Contains("H") Then
                CheckHours(getBtnName)
            ElseIf getBtnName.Contains("M") Then
                CheckMins(getBtnName)
            End If
            SetButtonColor(getBtnName)
            sender.BackColor = SetColor

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 時間被改變時的事件拋出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_time_TextChanged(sender As Object, e As EventArgs) Handles txt_time.TextChanged
        Try
            RaiseEvent ValueChange(sender, e)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 熱鍵相關事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_time_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_time.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    btn_Confirm.PerformClick()
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "  內部函數"
    ''' <summary>
    ''' 檢查並確認按鈕數字
    ''' </summary>
    ''' <param name="getBtnName"></param>
    ''' <remarks></remarks>
    Private Sub CheckHours(ByVal getBtnName As String)
        Try


            If getBtnName.Contains("HTens") AndAlso getBtnName.Substring(getBtnName.Length - 1, 1).Equals("2") Then
                btn_HDigits4.Enabled = False
                btn_HDigits5.Enabled = False
                btn_HDigits6.Enabled = False
                btn_HDigits7.Enabled = False
                btn_HDigits8.Enabled = False
                btn_HDigits9.Enabled = False
                If gblHourDigits > 5 Then
                    gblHourDigits = 0
                    gblHourTens = getBtnName.Substring(getBtnName.Length - 1, 1)
                    SetButtonColor("HDigits")
                End If
                gblHourTens = getBtnName.Substring(getBtnName.Length - 1, 1)
                SetTimeStr()
            ElseIf getBtnName.Contains("HTens") AndAlso Not getBtnName.Substring(getBtnName.Length - 1, 1).Equals("2") Then
                btn_HDigits4.Enabled = True
                btn_HDigits5.Enabled = True
                btn_HDigits6.Enabled = True
                btn_HDigits7.Enabled = True
                btn_HDigits8.Enabled = True
                btn_HDigits9.Enabled = True
                gblHourTens = getBtnName.Substring(getBtnName.Length - 1, 1)
                SetTimeStr()
            ElseIf getBtnName.Contains("HDigits") Then
                gblHourDigits = getBtnName.Substring(getBtnName.Length - 1, 1)
                SetTimeStr()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' 檢查並確認按鈕數字
    ''' </summary>
    ''' <param name="getBtnName"></param>
    ''' <remarks></remarks>
    Private Sub CheckMins(ByVal getBtnName As String)
        Try
            If getBtnName.Contains("MTens") Then
                gblMiTens = getBtnName.Substring(getBtnName.Length - 1, 1)
                SetTimeStr()
            Else
                gblMiDigits = getBtnName.Substring(getBtnName.Length - 1, 1)
                SetTimeStr()
            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' 清除該排按鈕的背景色，根據傳入的按鈕名稱去找到對應的容器
    ''' </summary>
    ''' <param name="getBtnName"></param>
    ''' <remarks></remarks>
    Private Sub SetButtonColor(ByVal getBtnName As String)
        Try
            If getBtnName.Contains("HTens") Then
                For Each ctl As Control In tlp_Htens.Controls
                    ctl.BackColor = SystemColors.Control
                Next
            ElseIf getBtnName.Contains("HDigits") Then
                For Each ctl As Control In tlp_HDigits.Controls
                    ctl.BackColor = SystemColors.Control
                Next
            ElseIf getBtnName.Contains("MTens") Then
                For Each ctl As Control In tlp_MTens.Controls
                    ctl.BackColor = SystemColors.Control
                Next
            Else
                For Each ctl As Control In tlp_MDigits.Controls
                    ctl.BackColor = SystemColors.Control
                Next
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 預設帶入時間的按鈕顏色
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDefaultButtonColor()
        Try
            CType(Me.Controls.Find("btn_HTens" & gblTimeStr.Substring(0, 1), True)(0), Button).BackColor = SetColor
            CType(Me.Controls.Find("btn_HDigits" & gblTimeStr.Substring(1, 1), True)(0), Button).BackColor = SetColor
            CType(Me.Controls.Find("btn_MTens" & gblTimeStr.Substring(3, 1), True)(0), Button).BackColor = SetColor
            CType(Me.Controls.Find("btn_MDigits" & gblTimeStr.Substring(4, 1), True)(0), Button).BackColor = SetColor
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' 設定時間字串，並且傳入控制項內
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetTimeStr()
        Try
            gblTimeStr = gblHourTens & gblHourDigits & ":" & gblMiTens & gblMiDigits
            txt_time.Text = gblTimeStr
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

#End Region



End Class