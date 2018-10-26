Public Class UCLOptionOrderUI
    Dim gblOptionDs As New DataSet
    Public gblOptionIndex As Integer = -1
    Public gblOptionName As String
    Dim gblOptionData As New ArrayList

    Public Sub New(ByVal inOptionDs As DataSet, ByVal inFavorName As String)

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        gblOptionDs = inOptionDs
        gblOptionData.Clear()
        gblOptionName = inFavorName
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub


    Private Sub UCLOptionOrderUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_Msg.Text = "請選" & gblOptionDs.Tables(0).Rows(0).Item("Display_Name").ToString.Trim & "的部位"

        Dim pvtItemOption As String
        Dim pvtCutIndex As Integer

        pvtItemOption = gblOptionDs.Tables(0).Rows(0).Item("Item_Option").ToString.Trim

        While pvtItemOption.Contains(vbTab)
            pvtCutIndex = pvtItemOption.IndexOf(vbTab)
            gblOptionData.Add(pvtItemOption.Substring(0, pvtCutIndex))
            pvtItemOption = pvtItemOption.Substring(pvtCutIndex + 1)
        End While
        gblOptionData.Add(pvtItemOption)


        For i = 0 To gblOptionData.Count - 1
            lst_Option.Items.Add(gblOptionData.Item(i).ToString.Trim)
        Next
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        gblOptionIndex = -1
        Me.Dispose()
    End Sub

    Private Sub lst_Option_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_Option.Click
        If lst_Option.SelectedItem IsNot Nothing Then
            gblOptionIndex = lst_Option.SelectedIndex
            If gblOptionIndex <> 0 Then
                gblOptionName = "    " & gblOptionDs.Tables(0).Rows(0).Item("Display_Name").ToString.Trim.Replace(gblOptionData.Item(0).ToString.Trim, gblOptionData.Item(gblOptionIndex).ToString.Trim)
            Else
                gblOptionName = "    " & gblOptionDs.Tables(0).Rows(0).Item("Display_Name").ToString.Trim
            End If
            Me.Close()
        End If
    End Sub
End Class