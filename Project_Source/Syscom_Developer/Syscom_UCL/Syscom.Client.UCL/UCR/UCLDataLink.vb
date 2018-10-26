
Public Class UCLDataLink

    Dim pvtDGV As UCLDataGridViewUC
    Dim pvtLinkColumnIndex As Integer
    Dim pvtGroupColumnIndex As Integer


    '傳入參數: iDGV-處理之DataGridView
    '          iLinkColumnIndex-連結線欄位索引值
    '          iGroupColumnIndex-群組代碼欄位索引值
    Sub New(ByVal iDGV As UCLDataGridViewUC, ByVal iLinkColumnIndex As Integer, ByVal iGroupColumnIndex As Integer)
        Dim pvtColorIndex As Integer = 0        '顏色索引
        Dim pvtKeyValue As String = ""          '群組代碼
        Dim pvtIsDataLink As Boolean = False     '該群組代碼是否有連結線

        pvtDGV = iDGV
        pvtLinkColumnIndex = iLinkColumnIndex
        pvtGroupColumnIndex = iGroupColumnIndex


        '清除連結線
        For m = 0 To pvtDGV.Rows.Count - 1
            pvtDGV.Item(pvtLinkColumnIndex, m).Value = ""
        Next

        '取得相同群組並畫線
        For i = 0 To pvtDGV.Rows.Count - 1

            '若未有連結符號且群組代號有值時，才需執行設定
            If pvtDGV.Item(pvtLinkColumnIndex, i).Value.ToString.Trim <> "┌─" AndAlso _
               pvtDGV.Item(pvtLinkColumnIndex, i).Value.ToString.Trim <> "├─" AndAlso _
               pvtDGV.Item(pvtLinkColumnIndex, i).Value.ToString.Trim <> "└─" AndAlso _
               pvtDGV.Item(pvtGroupColumnIndex, i).Value.ToString.Trim <> "" Then

                '取出尚未設定之群組代號
                pvtKeyValue = pvtDGV.Item(pvtGroupColumnIndex, i).Value.ToString.Trim

                '依序取得群組要設定之顏色（暫時預設10組顏色）
                pvtColorIndex += 1

                For j = i + 1 To pvtDGV.Rows.Count - 1
                    If pvtDGV.Item(pvtGroupColumnIndex, j).Value.ToString.Trim = pvtKeyValue Then
                        pvtIsDataLink = True
                        DrawLink(i, j, pvtKeyValue, pvtColorIndex)
                    End If
                Next

                If pvtIsDataLink = False Then
                    pvtColorIndex -= 1
                End If

                pvtIsDataLink = False

            End If
        Next

    End Sub

    Private Sub DrawLink(ByVal pvtStartIndex As Integer, ByVal pvtEndIndex As Integer, ByVal pvtKeyValue As String, ByVal pvtColorIndex As Integer)
        Dim newFont As Font = New Font("Times New Roman", 28, FontStyle.Bold)
        Dim pvtColor As Color = GetColor(pvtColorIndex)

        For i = pvtStartIndex To pvtEndIndex
            If i <> pvtStartIndex And i <> pvtEndIndex Then

                If pvtDGV.Item(pvtLinkColumnIndex, i).Value.ToString.Trim <> "" Then

                    If pvtDGV.Item(pvtLinkColumnIndex, i).Value.ToString.Trim = "│" Then

                        If pvtDGV.Item(pvtLinkColumnIndex, i).Style.ForeColor <> pvtColor Then

                            pvtDGV.Item(pvtLinkColumnIndex, i).Style.ForeColor = Color.Black

                        End If

                    ElseIf pvtDGV.Item(pvtLinkColumnIndex, i).Value.ToString.Trim = "└─" AndAlso _
                           pvtDGV.Item(pvtGroupColumnIndex, i).Value.ToString.Trim = pvtKeyValue Then

                        pvtDGV.Item(pvtLinkColumnIndex, i).Value = "├─"

                    End If
                Else
                    pvtDGV.Item(pvtLinkColumnIndex, i).Value = "│"
                    pvtDGV.Item(pvtLinkColumnIndex, i).Style.ForeColor = pvtColor
                    pvtDGV.Item(pvtLinkColumnIndex, i).Style.Font = newFont
                End If

            ElseIf i = pvtStartIndex Then

                pvtDGV.Item(pvtLinkColumnIndex, i).Value = "┌─"
                pvtDGV.Item(pvtLinkColumnIndex, i).Style.ForeColor = pvtColor
                pvtDGV.Item(pvtLinkColumnIndex, i).Style.Font = newFont

            ElseIf i = pvtEndIndex Then

                pvtDGV.Item(pvtLinkColumnIndex, i).Value = "└─"
                pvtDGV.Item(pvtLinkColumnIndex, i).Style.ForeColor = pvtColor
                pvtDGV.Item(pvtLinkColumnIndex, i).Style.Font = newFont

            End If
        Next

    End Sub

    Private Function GetColor(ByVal pvtColorIndex As Integer) As Color
        '暫先不區分顏色
        pvtColorIndex = 99
        Select Case pvtColorIndex
            Case 1
                Return Color.Red
            Case 2
                Return Color.Blue
            Case 3
                Return Color.Green
            Case 4
                Return Color.Purple
            Case 5
                Return Color.Yellow
            Case 6
                Return Color.Aqua
            Case 7
                Return Color.Brown
            Case 8
                Return Color.Pink
            Case 9
                Return Color.DarkOrange
            Case 10
                Return Color.YellowGreen
            Case Else
                Return Color.Black
        End Select

    End Function


End Class
