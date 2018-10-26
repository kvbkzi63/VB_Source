Public Class UCLWaitingFormUI



    Dim CurrentTag As String = "∣"
    Dim ShowMsg As String = ""

    Private _EnableAnimation As Boolean = False

    Public Property EnableAnimation() As Boolean
        Get
            Return _EnableAnimation
        End Get
        Set(ByVal value As Boolean)
            _EnableAnimation = value

            If _EnableAnimation Then
                Timer1.Enabled = True
            Else
                Timer1.Enabled = False
            End If

        End Set
    End Property

    Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        'Label1.Text = ""
        'Timer1.Enabled = True
        'Me.TopMost = True
    End Sub

    Sub New(ByVal msg As String, Optional ByVal Enable_Animation As Boolean = False)

        InitializeComponent()


        'Timer1.Enabled = True
        'Label1.Text = msg

        EnableAnimation = Enable_Animation
        ShowMsg = msg
        Me.Text = ShowMsg
        Me.TopMost = True

        Me.Height = 25
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        '＼／─∣
        If CurrentTag = "∣" Then
            CurrentTag = "／"

        ElseIf CurrentTag = "／" Then
            CurrentTag = "─"

        ElseIf CurrentTag = "─" Then
            CurrentTag = "＼"

        ElseIf CurrentTag = "＼" Then
            CurrentTag = "∣"
        End If

        Me.Text = ShowMsg & " " & CurrentTag
    End Sub


    Public Sub FinishJob()
        Timer1.Enabled = False
        Me.Close()
    End Sub



    Private Sub UCLWaitingFormUI_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
     
    End Sub
End Class