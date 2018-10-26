Public Class UclTimeUC

#Region "　　變數宣告"
    '定義是否需要開啟數字鍵盤
    Private timeKeypadFlag As Boolean = False
    Private bColor As Color = Color.Yellow
    Private timeStr As String = ""
    Private timeNumberStr As String = "0000"
    Dim WithEvents keypadUI As UclTimeKeypadUI
    Public Event ValueChange(ByVal sender As Object, ByVal e As EventArgs)

#End Region
#Region "　　屬性宣告"
    ''' <summary>
    ''' 根據傳入數值決定是否開啟數字鍵盤功能
    ''' </summary>
    ''' <value>True or False</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsKeyPad() As Boolean
        Get
            Return timeKeypadFlag
        End Get
        Set(value As Boolean)
            timeKeypadFlag = value
            '設定是否啟用數字鍵盤
            btn_KeypadOpen.Enabled = IsKeyPad
        End Set
    End Property
    ''' <summary>
    ''' 提供使用者更換按鈕背景顏色的選擇
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SetBackColor() As Color
        Get
            Return bColor
        End Get
        Set(value As Color)
            bColor = value
        End Set
    End Property
    ''' <summary>
    ''' 取得時間字串
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GetTimeStr() As String
        Get
            Return timeStr
        End Get
        Set(value As String)
            timeStr = value
            timeNumberStr = timeStr.Split(":")(0) & timeStr.Split(":")(1)
        End Set
    End Property

    ''' <summary>
    ''' 取得時間字串(數字)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GetTimeNumberStr() As Integer
        Get
            Return timeNumberStr
        End Get
        Set(value As Integer)
            'timeNumberStr = value
        End Set
    End Property

    ''' <summary>
    ''' 取得時間字串(數字)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SetTimeText() As String
        Get
            Return timeStr
        End Get
        Set(value As String)
            timeStr = value
            txt_Time.Text = timeStr
        End Set
    End Property

#End Region
#Region "　　外部函數"

#Region "初始化"
    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub


#End Region

#End Region
#Region "　　內部函數"
 
#Region "　　開啟數字鍵盤"
    Private Sub btn_KeypadOpen_Click(sender As Object, e As EventArgs) Handles btn_KeypadOpen.Click
        Try
 
            keypadUI = New UclTimeKeypadUI(IIf(txt_Time.Text.Trim = ":", timeStr, txt_Time.Text))
            keypadUI.SetColor = SetBackColor
            keypadUI.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "　　鍵盤按下後的事件處理"
    Private Sub UCLTimeUC_KeyUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Time.KeyUp
        Try
            SetTimeText = txt_Time.Text
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Confirm(ByVal sender As System.Object, ByVal Value As String, ByVal noInputFlag As Boolean) Handles keypadUI.Confirm
        Try
            If noInputFlag = False Then
                Me.GetTimeStr = Value
                txt_Time.Text = GetTimeStr
            Else
                txt_Time.Text = ""
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "事件拋出處理"
    ''' <summary>
    ''' text改變時拋出事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub keypadUI_ValueChange(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Time.TextChanged
        Try
            RaiseEvent ValueChange(sender, e)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
#End Region

#End Region


End Class
