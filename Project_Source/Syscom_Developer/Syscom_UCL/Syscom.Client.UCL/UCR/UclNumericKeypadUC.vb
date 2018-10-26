Imports Syscom.Client.CMM

Public Class UclNumericKeypadUC


#Region "　變數宣告"

    Private gblNumericLength As String = "0.0"
    Private gblColor As Color = Color.Yellow
    Private gblNumberStr As String = ""
    Dim WithEvents keypad As New UclNumericKeypadUI
    Private gblDefaultValue As String = ""
    Private gblCheckValueFloor As String = ""
    Private gblCheckValueCeiling As String = ""
    Private gblDefaultStartValue As Decimal = 0.0
#End Region

#Region "　Property宣告"

    ''' <summary>
    ''' 設定被點選的顏色
    ''' </summary>
    ''' <value></value>
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

    ''' <summary>
    ''' 取得數字字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GetNumberStr() As String
        Get
            Return gblNumberStr
        End Get
        Set(value As String)
            gblNumberStr = value
        End Set
    End Property

    ''' <summary>
    ''' 設定顯示在TextBox上的數字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SetNumberText() As String
        Get
            Return gblNumberStr
        End Get
        Set(value As String)
            gblNumberStr = value
            txt_numeric.Text = gblNumberStr
        End Set
    End Property

    ''' <summary>
    ''' 給予使用者一個預設值的區間
    ''' 例如：0~90,100~190,30~40
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SetDefaultNumArea() As String
        Get
            Return gblDefaultValue
        End Get
        Set(value As String)
            gblDefaultValue = value
        End Set
    End Property

    ''' <summary>
    ''' 設定字串長度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SetDigits() As String
        Get
            Return gblNumericLength
        End Get
        Set(value As String)
            gblNumericLength = value
        End Set

    End Property


    ''' <summary>
    ''' 設定預設起始數字
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SetDefaultStart() As Decimal
        Get
            Return gblDefaultStartValue
        End Get
        Set(value As Decimal)
            gblDefaultStartValue = value
            '如果有設定預設值就先給起始值做初始化
            If value > 0 Then
                keypad.DefaultStartValue = gblDefaultStartValue
            End If
        End Set

    End Property
#End Region


#Region "　外部函數"
    Sub New()
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

    End Sub
    Private Sub UclNumericKeypadUC_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            CheckIniValue(gblDefaultValue, gblNumericLength)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CheckIniValue(ByVal DefaultNumAream As String, ByVal SetDigits As String)
        Try

 

            '設定位數
            If IsNumeric(gblNumericLength) Then

 


                '檢核設定位數
                If gblNumericLength.Contains(".") AndAlso Int(gblNumericLength.Split(".")(0)) + Int(gblNumericLength.Split(".")(1)) > 9 Then
                    MessageBox.Show("小數前位數+小數後位數總和不得超過9位數")
                    btn_OpenUI.Enabled = False
                ElseIf Int(gblNumericLength) < 1 Or Int(gblNumericLength) > 10 Then
                    MessageBox.Show("位數設定需介於1~10之間")
                    btn_OpenUI.Enabled = False
                Else
                    txt_numeric.uclIntCount = gblNumericLength.Split(".")(0)
                    If gblNumericLength.Contains(".") Then
                        txt_numeric.uclDotCount = gblNumericLength.Split(".")(1)
                    End If
                    gblNumericLength = SetDigits
                    keypad.Digits = SetDigits
                End If

                '設定預設值範圍
                If gblDefaultValue <> "" Then
                    keypad.DefaultNumArea = gblDefaultValue
                End If


            Else
                MessageBox.Show("位數區間未設定")
                btn_OpenUI.Enabled = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "　事件處理"

    ''' <summary>
    ''' 開啟數字鍵盤
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_OpenUI_Click(sender As Object, e As EventArgs) Handles btn_OpenUI.Click
        Try
            keypad.SetBackColorForClick = Me.SetColor()
            keypad.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 處理輸入數字時的事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UCLTimeUC_KeyUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_numeric.KeyUp
        Try
            SetNumberText = txt_numeric.Text
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Confirm(ByVal sender As System.Object, ByVal Value As String) Handles keypad.Confirm
        Try
            If Value.ToString.Contains(".") Then
                '   .01  .09 變成 1.01 1.09
                If Value.Split(".")(0).Equals("") Then
                    SetNumberText = "0" & Value.ToString
                Else
                    SetNumberText = Value
                End If
            Else
                SetNumberText = Value
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class
