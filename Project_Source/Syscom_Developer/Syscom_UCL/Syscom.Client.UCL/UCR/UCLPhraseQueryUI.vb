Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.Utility
Imports Syscom.Client.CMM

Public Class UCLPhraseQueryUI

    Dim pvtQueryFlag As Boolean                                    '啟用查詢註記
    Dim pvtSearchKey As Boolean                                    '啟用Key查詢註記
    Dim pvtKeyChar As String                                       '輸入字元
    Dim pvtBackSpaceFlag As Boolean                                '倒退鍵啟用註記
    Dim pvtTextOrginalNum1 As Integer                              '原始\符號前長度
    Dim pvtTextOrginalNum2 As Integer                              '原始\符號後長度
    Dim pvtTextOrginalContent1 As String                           '原始\符號前內容
    Dim pvtTextOrginalContent2 As String                           '原始\符號後內容
    Dim pvtTextAppendNum As Integer                                '新加入長度
    Dim pvtExitSubFlag As Boolean

    Private _uclPhraseDS As New DataSet                            '片語暫存區
    Private _uclUserTypeId As String = "1"                         '片語使用類別
    Private _uclDoctor_Dept_Code As String = ""                    '科別或使用者代碼
    Private _uclPhraseTypeId As String = uclPhraseType.S           '片語種類
    Private _uclQueryStr As String = ""                            '查詢關鍵字
    Private _uclMaxLength As Integer = 500                         '內容長度
    Private _uclScrollBars As uclScrollBarsType = uclScrollBarsType.None  '是否啟用捲軸
    Private _uclText As String = ""                                '片語內容

    Public Shadows Event TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Shadows Event KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    Public Shadows Event MouseDoubleClick(sender As Object, e As MouseEventArgs)
    Public Shadows Event MouseClick(sender As Object, e As MouseEventArgs)
    Public Shadows Event GotFocus(sender As Object, e As EventArgs)


    Enum uclPhraseType
        S = 1                           '1:Subject
        O = 2                           '2:Object
        A = 3                           '3:診斷
        P = 4                           '4:Assessment/Plan
    End Enum

    Enum uclScrollBarsType
        None = 1
        Vertical = 2
        Horizontal = 3
        Both = 4
    End Enum

    Public Property uclUserTypeId() As uclPhraseType
        Get
            Return _uclUserTypeId
        End Get
        Set(ByVal value As uclPhraseType)
            _uclUserTypeId = value
        End Set
    End Property

    Public Property uclDoctor_Dept_Code() As String
        Get
            Return _uclDoctor_Dept_Code
        End Get
        Set(ByVal value As String)
            _uclDoctor_Dept_Code = value
        End Set
    End Property

    Public Property uclPhraseTypeId() As String
        Get
            Return _uclPhraseTypeId
        End Get
        Set(ByVal value As String)
            _uclPhraseTypeId = value
        End Set
    End Property

    Public Property uclPhraseDS() As DataSet
        Get
            Return _uclPhraseDS
        End Get
        Set(ByVal value As DataSet)
            _uclPhraseDS = value
        End Set
    End Property

    Public Property uclQueryStr() As String
        Get
            Return _uclQueryStr
        End Get
        Set(ByVal value As String)
            _uclQueryStr = value
        End Set
    End Property

    Public Property uclMaxLength() As Integer
        Get
            Return _uclMaxLength
        End Get
        Set(ByVal value As Integer)
            _uclMaxLength = value
            RichTextBox1.MaxLength = value
        End Set
    End Property

    Public Property uclScrollBars() As uclScrollBarsType
        Get
            Return _uclScrollBars
        End Get
        Set(ByVal value As uclScrollBarsType)
            _uclScrollBars = value
            Select Case value
                Case 1
                    RichTextBox1.ScrollBars = ScrollBars.None
                Case 2
                    RichTextBox1.ScrollBars = ScrollBars.Vertical
                Case 3
                    RichTextBox1.ScrollBars = ScrollBars.Horizontal
                Case 4
                    RichTextBox1.ScrollBars = ScrollBars.Both
            End Select
        End Set
    End Property

    Public Property uclInsertText() As String
        Get
            _uclText = RichTextBox1.Text.Trim
            Return _uclText
        End Get
        Set(ByVal value As String)
            Dim NowStartIndex As Int32 = RichTextBox1.SelectionStart
            RichTextBox1.Text = RichTextBox1.Text.Substring(0, RichTextBox1.SelectionStart) & value & RichTextBox1.Text.Substring(RichTextBox1.SelectionStart, RichTextBox1.Text.Length - RichTextBox1.SelectionStart)
            RichTextBox1.SelectionStart = NowStartIndex + value.Length
            RichTextBox1.Focus()
        End Set
    End Property
    Public Property uclText() As String
        Get
            _uclText = RichTextBox1.Text.Trim
            Return _uclText
        End Get
        Set(ByVal value As String)
            _uclText = value
            RichTextBox1.Text = value
        End Set
    End Property
    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        Select Case e.KeyCode

            Case Keys.OemPipe
                pvtQueryFlag = True
                'alan
                'pvtTextOrginalNum = RichTextBox1.TextLength
                pvtTextOrginalNum1 = RichTextBox1.SelectionStart
                pvtKeyChar = "\"

                If pvtTextOrginalNum1 > 0 Then
                    pvtTextOrginalContent1 = RichTextBox1.Text.Substring(0, pvtTextOrginalNum1)
                    pvtTextOrginalContent2 = RichTextBox1.Text.Substring(RichTextBox1.SelectedText.Length + pvtTextOrginalNum1)
                    pvtTextOrginalNum2 = pvtTextOrginalContent2.Length
                Else
                    pvtTextOrginalContent2 = RichTextBox1.Text.Substring(RichTextBox1.SelectedText.Length + pvtTextOrginalNum1)
                    pvtTextOrginalNum2 = pvtTextOrginalContent2.Length
                End If


                'If uclPhraseDS.Tables.Count = 0 Then
                '    queryPhrase()
                'End If

            Case Keys.Space
                reSet()

            Case Keys.Enter
                If pvtQueryFlag Then
                    pvtSearchKey = True
                End If

            Case Keys.Back
                Dim pvtLength As Integer
                pvtLength = RichTextBox1.Text.Length
                If pvtQueryFlag AndAlso pvtLength - (pvtTextOrginalNum1 + pvtTextOrginalNum2) > 0 Then
                    pvtBackSpaceFlag = True
                Else
                    pvtBackSpaceFlag = False
                End If


            Case Else
                pvtKeyChar = ""

        End Select
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Dim pvtText As String
        Dim pvtLength As Integer

        If pvtExitSubFlag Then
            Exit Sub
        End If

        pvtText = RichTextBox1.Text
        pvtLength = pvtText.Length


        If pvtLength - pvtTextOrginalNum1 < 0 Or pvtLength = 0 Then
            reSet()
        End If


        '取得關鍵字
        If pvtBackSpaceFlag OrElse (pvtQueryFlag AndAlso pvtKeyChar <> "\" AndAlso pvtLength > (pvtTextOrginalNum1 + pvtTextOrginalNum2) AndAlso _
           pvtLength - (pvtTextOrginalNum1 + pvtTextOrginalNum2) <= 20) Then

            If pvtBackSpaceFlag Then
                pvtTextAppendNum -= 1
                pvtBackSpaceFlag = False
            Else
                pvtTextAppendNum += 1
            End If

            If pvtTextAppendNum >= 0 Then

                If pvtSearchKey = False Then
                    uclQueryStr = pvtText.Substring(pvtTextOrginalNum1 + 1, pvtTextAppendNum)
                End If

                '進行比對
                If pvtBackSpaceFlag = False AndAlso pvtSearchKey AndAlso uclPhraseDS.Tables.Count > 0 Then
                    For i = 0 To uclPhraseDS.Tables(0).Rows.Count - 1

                        If uclPhraseDS.Tables(0).Rows(i).Item("Phrase_Key").ToString.ToUpper.Trim = uclQueryStr.ToUpper Then

                            '判斷長度是否超出內容長度
                            If (pvtTextOrginalContent1 & _
                                                uclPhraseDS.Tables(0).Rows(i).Item("Phrase_Content").ToString.Trim() & _
                                                pvtTextOrginalContent2).Length <= RichTextBox1.MaxLength Then

                                pvtExitSubFlag = True

                                RichTextBox1.Text = pvtTextOrginalContent1 & _
                                                uclPhraseDS.Tables(0).Rows(i).Item("Phrase_Content").ToString.Trim() & _
                                                pvtTextOrginalContent2

                                RichTextBox1.SelectionStart = pvtTextOrginalNum1 + uclPhraseDS.Tables(0).Rows(i).Item("Phrase_Content").ToString.Trim().Length


                            Else
                                MessageHandling.ShowWarnMsg("CMMCMMB300", New String() {"該片語加入後會超出可輸入長度" & RichTextBox1.MaxLength & "個字!"})
                                RichTextBox1.Text = pvtTextOrginalContent1 & pvtTextOrginalContent2
                            End If

                            reSet()

                            Exit For

                        End If

                    Next

                    If pvtSearchKey Then
                        reSet()
                    End If

                End If

            Else
                reSet()
            End If

        ElseIf pvtQueryFlag = False AndAlso (pvtLength <= (pvtTextOrginalNum1 + pvtTextOrginalNum2) OrElse pvtLength - (pvtTextOrginalNum1 + pvtTextOrginalNum2) > 24) Then
            reSet()
        End If
    End Sub

    Private Sub RichTextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyUp
        RaiseEvent KeyUp(sender, e)
    End Sub

    Private Sub RichTextBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles RichTextBox1.MouseDoubleClick
        RaiseEvent MouseDoubleClick(sender, e)
    End Sub

    Private Sub RichTextBox1_GotFocus(sender As Object, e As EventArgs) Handles RichTextBox1.GotFocus
        RaiseEvent GotFocus(sender, e)
    End Sub
    Private Sub reSet()
        pvtQueryFlag = False
        pvtSearchKey = False
        uclQueryStr = ""
        pvtKeyChar = ""
        pvtTextAppendNum = 0
        pvtBackSpaceFlag = False
        pvtTextOrginalContent1 = ""
        pvtTextOrginalContent2 = ""
        pvtTextOrginalNum1 = 0
        pvtTextOrginalNum2 = 0
        pvtExitSubFlag = False
    End Sub

    Public Sub queryPhrase()
        Dim uclOW As IUclServiceManager = UclServiceManager.getInstance
        uclPhraseDS = uclOW.queryOMOPhraseForUCL(uclUserTypeId, uclDoctor_Dept_Code, uclPhraseTypeId, "")
    End Sub

#Region "滑鼠右鍵功能選單事件"
    Private Sub RichTextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles RichTextBox1.MouseClick
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                RichTextBox1.ContextMenuStrip.Show()
            End If

        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' 複製CTRL+C
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            SendKeys.Send("^C")
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' 貼上CTRL+V
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            SendKeys.Send("^V")
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' 剪下CTRL+X
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            SendKeys.Send("^{X}")
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' 復原CTRL+Z
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem.Click
        Try
            SendKeys.Send("^{Z}")
        Catch ex As Exception

        End Try
    End Sub

#End Region
End Class

