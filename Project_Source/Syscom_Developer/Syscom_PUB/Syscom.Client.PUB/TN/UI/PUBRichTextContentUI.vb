Public Class PUBRichTextContentUI
    Public pvtContent As String = ""

    Sub New(ByVal inTitleName As String, ByVal inContent As String)
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        pvtContent = inContent
        Me.Text = inTitleName & "編輯"

    End Sub

    Private Sub PUBRichTextContentUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_Content.Text = pvtContent
    End Sub

    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        pvtContent = txt_Content.Text.Trim
        Me.Dispose()
    End Sub
End Class