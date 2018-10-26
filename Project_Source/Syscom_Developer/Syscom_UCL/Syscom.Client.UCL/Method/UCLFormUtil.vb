'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：UI畫面顯示相關功能及函式
'=======
'======= 程式說明：1.提供整體系統畫面底色、字體與字體大小設定功能。
'=======
'=======           2.提供依畫面解析度自動調整畫面及元件大小功能。
'=======
'======= 建立日期：2015-03-31
'=======
'======= 開發人員：Alan.Tsai
'=============================================================================
'=============================================================================
'=============================================================================
''' <summary>
''' UI畫面顯示相關功能及函式
''' </summary>
Public Class UCLFormUtil

    '除了高聯醫之外的醫院外，自動縮放都關閉
    ''' <summary>
    ''' The is resizeable
    ''' </summary>
    Public Shared isUiResizeable As Boolean = False                 '是否可依解析度調整元件大小
    ''' <summary>
    ''' The GBL back color
    ''' </summary>
    Public Shared gblBackColor As Color = Color.LightCyan         '系統背景顏色
    ''' <summary>
    ''' The GBL font
    ''' </summary>
    Public Shared gblFont As String = "微軟正黑體"                '系統字體
    ''' <summary>
    ''' The GBL font size 1024 768
    ''' </summary>
    Public Shared gblFontSize_1024_768 As Integer = 12            '系統字體大小(1024x768)
    ''' <summary>
    ''' The GBL font size 1920 1080
    ''' </summary>
    Public Shared gblFontSize_1920_1080 As Integer = 16           '系統字體大小(1920x1080)
    ''' <summary>
    ''' The GBL screen width
    ''' </summary>
    Public Shared gblScreenWidth As Integer                       '使用者端解析度(寬)
    ''' <summary>
    ''' The GBL screen height
    ''' </summary>
    Public Shared gblScreenHeight As Integer                      '使用者端解析度(高)
    ''' <summary>
    ''' The GBL grid header color
    ''' </summary>
    Public Shared gblGridHeaderColor As String = "CCCCCC"         'Grid標題列顏色(須於專案屬性中取消勾選【啟用XP視覺化樣式】，才會有作用)

    ''' <summary>
    ''' The gblUiLargeLayoutNameList
    ''' </summary>
    Public Shared gblUiLargeLayoutNameList As New ArrayList            '大畫面UI


    ''' <summary>
    ''' Res the draw form.
    ''' </summary>
    ''' <param name="ctrl">The control.</param>
    Public Shared Sub ReDrawForm(ByRef ctrl As Control)

        Dim compName As String = ""
        Dim itemName As String = ""

        Try
            'Debug.WriteLine("")

            '依isResizeable屬性值判斷是否調整元件大小
            If isResizeable(ctrl) = False Then
                Exit Sub
            End If

            '取得螢幕解析度
            gblScreenWidth = Screen.PrimaryScreen.Bounds.Width
            gblScreenHeight = Screen.PrimaryScreen.Bounds.Height

            'For Debug
            'gblScreenWidth = 1920
            'gblScreenHeight = 1080

            '取得表單上所有元件
            If ctrl.Controls.Count > 0 Then

                For Each elem As Control In ctrl.Controls
                    ReDrawForm(elem)
                Next

                '取得控制項的元件名稱
                compName = ctrl.GetType().ToString  '顯示完整階層元件名稱
                'Dim compName As String = ctrl.GetType.Name '顯示最底層名稱
                'Debug.Write(compName & "===>   ")

                '取得控制項的命名
                itemName = ctrl.Name
                'Debug.Write(itemName)

                If itemName.Length > 0 Then
                    ReDrawComponent(ctrl, itemName)
                End If

            Else
                '取得控制項的元件名稱
                compName = ctrl.GetType().ToString  '顯示完整階層元件名稱
                'Dim compName As String = ctrl.GetType.Name '顯示最底層名稱
                'Debug.Write(compName & "===>   ")

                '取得控制項的命名
                itemName = ctrl.Name
                'Debug.Write(itemName)

                If itemName.Length > 0 Then
                    ReDrawComponent(ctrl, itemName)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("元件重繪失敗---" & itemName)
        End Try

    End Sub

    ''' <summary>
    ''' Res the draw component.
    ''' </summary>
    ''' <param name="ctrl">The control.</param>
    ''' <param name="itemName">Name of the item.</param>
    Private Shared Sub ReDrawComponent(ByRef ctrl As Control, ByVal itemName As String)
        Dim pvtCompNo As String = ""    '元件代號

        '------------------------------------------------------------------------------
        ' 整張表單畫面設定
        '------------------------------------------------------------------------------
        If itemName.ToUpper.Contains("UI") Then

            ctrl.Width = ctrl.Width * (gblScreenWidth / 1024)
            ctrl.Height = ctrl.Height * (gblScreenHeight / 768)
            ctrl.BackColor = gblBackColor
            Exit Sub
        End If

        If gblScreenWidth < 1920 Then
            ctrl.Font = New Font(gblFont, gblFontSize_1024_768)
        Else
            ctrl.Font = New Font(gblFont, gblFontSize_1920_1080)
        End If

        '------------------------------------------------------------------------------
        ' For UCR使用者自訂元件
        '------------------------------------------------------------------------------

        Select Case itemName.Substring(0, 3).ToLower
            Case "ucr", "lbl", "txt", "btn", "chk", "clb", "cbo", "dtp", "ltb", "rbt", "rtb", "tip", "tre", "dgv", "grb", "pal", "flp", "tlp", "tbc", "tbp"

                'For Debug
                'If itemName.Substring(0, 3).ToLower = "dtp" Then
                '    Debug.Write("")
                'End If

                If itemName <> "dgv" Then '因UCLDataGridViewUC內含一層dgv元件，為避免錯誤，故加此判斷式

                    '若為ListBox，則需設定IntegralHeight屬性為False，才能自動調整高度
                    If itemName.Substring(0, 3).ToLower = "ltb" Then
                        Dim ltbCtl As New ListBox
                        ltbCtl = ctrl
                        ltbCtl.IntegralHeight = False
                    End If

                    'Debug.Write(",調整大小=(" & ctrl.Width & "," & ctrl.Height & ")")
                    ctrl.Width = ctrl.Width * (gblScreenWidth / 1024)
                    ctrl.Height = ctrl.Height * (gblScreenHeight / 768)
                    'ctrl.Size = New System.Drawing.Size(ctrl.Width * (gblScreenWidth / 1024), 38)
                    'Debug.Write(",調整大小=(" & ctrl.Width & "," & ctrl.Height & ")")

                    'Debug.Write(",原始位置=(" & ctrl.Left & "," & ctrl.Top & ")")
                    ctrl.Left = ctrl.Left * (gblScreenWidth / 1024)
                    ctrl.Top = ctrl.Top * (gblScreenHeight / 768)
                    'Debug.WriteLine(",調整位置=(" & ctrl.Left & "," & ctrl.Top & ")")

                    '2015-04-30 Add By Alan---將TableLayoutPanel調整為AutoSize
                    If itemName.Substring(0, 3).ToLower = "tlp" OrElse
                        ctrl.GetType().ToString = "System.Windows.Forms.TableLayoutPanel" Then
                        ReSetTableLayoutPanel(ctrl)

                        '2015-05-08 Add By Alan---將TabPage底色調整為系統預設
                    ElseIf itemName.Substring(0, 3).ToLower = "tbp" OrElse
                        ctrl.GetType().ToString = "System.Windows.Forms.TabPage" Then
                        ctrl.BackColor = gblBackColor

                    End If

                    If itemName.Substring(0, 3).ToLower = "dgv" Then
                        '自動設定列高
                        If TypeOf (ctrl) Is UCLDataGridViewUC Then
                            CType(ctrl, UCLDataGridViewUC).AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
                        ElseIf TypeOf (ctrl) Is DataGridView Then
                            CType(ctrl, DataGridView).AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
                        End If
                    End If
                End If

            Case Else
                '------------------------------------------------------------------------------
                ' For .NET內建元件
                '------------------------------------------------------------------------------
                Dim ctrlType As String = ctrl.GetType().ToString

                'Select Case ctrlType
                '    Case GetType(Label).ToString

                '    Case Else

                'End Select

                '2015-04-30 Add By Alan---將TableLayoutPanel調整為AutoSize
                If ctrl.GetType().ToString = "System.Windows.Forms.TableLayoutPanel" Then
                    ReSetTableLayoutPanel(ctrl)

                    '2015-05-08 Add By Alan---將TabPage底色調整為系統預設
                ElseIf ctrl.GetType().ToString = "System.Windows.Forms.TabPage" Then
                    ctrl.BackColor = gblBackColor

                End If

                'Debug.Write(",調整大小=(" & ctrl.Width & "," & ctrl.Height & ")")
                ctrl.Width = ctrl.Width * (gblScreenWidth / 1024)
                ctrl.Height = ctrl.Height * (gblScreenHeight / 768)
                'Debug.Write(",調整大小=(" & ctrl.Width & "," & ctrl.Height & ")")

                'Debug.Write(",原始位置=(" & ctrl.Left & "," & ctrl.Top & ")")
                ctrl.Left = ctrl.Left * (gblScreenWidth / 1024)
                ctrl.Top = ctrl.Top * (gblScreenHeight / 768)
                'Debug.WriteLine(",調整位置=(" & ctrl.Left & "," & ctrl.Top & ")")

        End Select

    End Sub

    ''' <summary>
    ''' Res the set table layout panel.
    ''' </summary>
    ''' <param name="ctrl">The control.</param>
    Private Shared Sub ReSetTableLayoutPanel(ByVal ctrl As Control)
        Dim ColStyles As TableLayoutColumnStyleCollection = CType(ctrl, TableLayoutPanel).ColumnStyles

        For Each style As ColumnStyle In ColStyles

            If style.SizeType <> SizeType.AutoSize Then

                style.SizeType = SizeType.AutoSize

            End If

        Next

        Dim RowStyles As TableLayoutRowStyleCollection = CType(ctrl, TableLayoutPanel).RowStyles

        For Each style As RowStyle In RowStyles

            If style.SizeType <> SizeType.AutoSize Then

                style.SizeType = SizeType.AutoSize

            End If

        Next
    End Sub

    ''' <summary>
    ''' Res the width of the set grid.
    ''' </summary>
    ''' <param name="inDgv">The in DGV.</param>
    ''' <param name="inColumnWidth">Width of the in column.</param>
    ''' <returns>System.String.</returns>
    Public Shared Function ReSetGridWidth(ByVal inDgv As UCLDataGridViewUC, ByVal inColumnWidth As String) As String
        Dim pvtGridWidth As String = ""
        Dim pvtCutIndex As Integer
        Dim pvtColIndex As Integer = 1
        Dim pvtWidth As String
        Dim pvtHashTable As New Hashtable
        Dim pvtIsNullWidth As Boolean

        pvtHashTable = inDgv.getCellHash

        '取得螢幕解析度
        gblScreenWidth = Screen.PrimaryScreen.Bounds.Width
        gblScreenHeight = Screen.PrimaryScreen.Bounds.Height

        'Debug.Write("調整前欄寬=>" & inColumnWidth)

        Do While (inColumnWidth <> "")

            pvtIsNullWidth = False

            pvtCutIndex = inColumnWidth.IndexOf(",")

            '取出原始欄寬
            If pvtCutIndex >= 0 Then
                pvtWidth = inColumnWidth.Substring(0, pvtCutIndex)

                If pvtWidth = "" Then
                    pvtIsNullWidth = True
                End If

            Else
                pvtWidth = inColumnWidth
            End If

            If pvtIsNullWidth = False Then
                '計算出調整後欄寬
                'Debug.Write("原始欄寬=>" & pvtWidth)
                pvtWidth = pvtWidth * (gblScreenWidth / 1024)
                'Debug.Write("，調整後欄寬=>" & pvtWidth)
            End If

            If pvtHashTable IsNot Nothing AndAlso pvtHashTable(pvtColIndex) IsNot Nothing Then
                '若為日期元件，則需再調整UCLDateTimePickerCellUC大小
                If pvtHashTable(pvtColIndex).GetType().ToString() = "Syscom.Client.UCL.DtpCell" Then
                    inDgv.Columns(pvtColIndex).Width = inDgv.Columns(pvtColIndex).Width * (gblScreenWidth / 1024)
                End If

                '設定Header顏色(須於專案屬性中取消勾選【啟用XP視覺化樣式】，才會有作用)
                inDgv.Columns(pvtColIndex).HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#" & gblGridHeaderColor)

            End If

            pvtColIndex += 1

            '將調整後寬度加入回傳字串中
            If pvtGridWidth <> "" Then

                If pvtWidth <> "" Then
                    pvtGridWidth &= "," & CInt(pvtWidth)
                Else
                    pvtGridWidth &= "," & pvtWidth
                End If

            Else
                If pvtIsNullWidth Then
                    pvtGridWidth = " "
                Else
                    pvtGridWidth = CInt(pvtWidth)
                End If

            End If

            '已調整欄寬自傳入字串中刪除
            If pvtCutIndex >= 0 Then
                inColumnWidth = inColumnWidth.Substring(pvtCutIndex + 1)
            Else
                inColumnWidth = ""
            End If

        Loop

        'Debug.Write("調整後欄寬=>" & pvtGridWidth)

        Return pvtGridWidth
    End Function

    ''' <summary>
    ''' Res the set loc to screen center.
    ''' </summary>
    ''' <param name="inForm">The in form.</param>
    Public Shared Sub ReSetLocToScreenCenter(ByVal inForm As Form)
        Dim pvtX As Integer = (gblScreenWidth - inForm.Width) / 2
        Dim pvtY As Integer = (gblScreenHeight - inForm.Height) / 2
        inForm.Location = New Point(pvtX, pvtY)
    End Sub

    ''' <summary>
    ''' DetermineUiLayout
    ''' </summary>
    ''' <param name="ctrl">Control.</param>
    Public Shared Function isResizeable(Optional ByVal ctrl As Control = Nothing) As Boolean
        Try
            '取得螢幕解析度
            gblScreenWidth = Screen.PrimaryScreen.Bounds.Width
            gblScreenHeight = Screen.PrimaryScreen.Bounds.Height

            If ctrl Is Nothing Then
                Return isUiResizeable                 '是否可依解析度調整元件大小
            Else
                Return IsCheckLargeLayout(ctrl)
            End If
            Return isUiResizeable
        Catch ex As Exception
            Return isUiResizeable
        End Try
    End Function

    ''' <summary>
    ''' IsCheckLargeLayout
    ''' </summary>
    ''' <param name="ctrl">Control.</param>
    Private Shared Function IsCheckLargeLayout(ByVal ctrl As Control) As Boolean
        If ctrl IsNot Nothing Then
            If ctrl.GetType.BaseType.Name = "BaseFormUI" Then
                If gblUiLargeLayoutNameList.Contains(ctrl.GetType.Name) Then
                    '落在放大的清單內
                    Return True
                Else
                    Return isUiResizeable  '是否可依解析度調整元件大小
                End If
            End If

            If ctrl.Parent IsNot Nothing Then
                Return IsCheckLargeLayout(ctrl.Parent)
            End If
        End If

        Return isUiResizeable  '是否可依解析度調整元件大小
    End Function

End Class