Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.BASE
Imports System.Globalization
Imports System.Text

Public Class UCLDateTimePickerCellUC

#Region "變數宣告"


    Private _DisplayLocale As Locale = Locale.TW

    Private _Text As String

    '用在datagridview的DTP
    Dim dtp_dgv As UCLDataGridViewUC = Nothing

    Dim dsDB As DataSet = Nothing
    Dim dsGrid As DataSet = Nothing

    Dim cellRowIndex, cellColIndex As Integer
    Public FirstEnterGridCell As Boolean = False

    Private Const startYear As Integer = 1930
    Private Const yearRange As Integer = 100
    Dim data As StringBuilder = New StringBuilder
    Private _MaxDate As Date = CDate("9998/1/1")
    Private _MinDate As Date = CDate("1800/1/1")
    Dim TreeGridCol As Integer = 0
    Dim colWidth As Integer = 0
    Dim doCellValueChange As Boolean = True
    Dim IsShowError As Boolean = False

    Dim us As CultureInfo = New CultureInfo("en-US", True)
    Dim tw As CultureInfo = New CultureInfo("zh-TW", True)
    Private Shared dateFormats As String() = {"yyyy/MM/dd", "yyyy/MM/d", "yyyy/M/dd", "yyyy/M/d", "yyyyMMdd", _
                                                            "yyyy/MM/dd tt hh:mm:ss", "yyyy/MM/d tt hh:mm:ss", "yyyy/M/dd tt hh:mm:ss", "yyyy/M/d tt hh:mm:ss", _
                                                            "yyyy/MM/dd 上午 hh:mm:ss", "yyyy/MM/d 上午 hh:mm:ss", "yyyy/M/dd 上午 hh:mm:ss", "yyyy/M/d 上午 hh:mm:ss", _
                                                            "yyyy/MM/dd 下午 hh:mm:ss", "yyyy/MM/d 下午 hh:mm:ss", "yyyy/M/dd 下午 hh:mm:ss", "yyyy/M/d 下午 hh:mm:ss"}
    '西元年
    Private enDateString As String = ""
    '民國年
    Private twDateString As String = ""
#End Region


#Region "屬性設定"



    Enum Locale
        US = 0
        TW = 1
    End Enum


    Public Property MaxDate() As Date
        Get
            Return dtp1.MaxDate
        End Get
        Set(ByVal value As Date)
            dtp1.MaxDate = value
        End Set
    End Property


    Public Property MinDate() As Date
        Get
            Return dtp1.MinDate
        End Get
        Set(ByVal value As Date)
            dtp1.MinDate = value
        End Set
    End Property

    Public Property DisplayLocale() As Locale
        Get
            Return _DisplayLocale
        End Get
        Set(ByVal value As Locale)
            _DisplayLocale = value
            SetLocale()
        End Set
    End Property

    Public Overrides Property Text() As String
        Get
            Return MaskedTextBox1.Text
        End Get
        Set(ByVal value As String)

            SetValue(value)
        End Set
    End Property


#End Region

    Sub New()

        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        '設定成共用的字型
        Me.Font = AppConfigUtil.ControlFont

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        MaskedTextBox1.Mask = "9999/99/99"
    End Sub


    ''' <summary>
    ''' 設定Locale
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetLocale()
        If _DisplayLocale = Locale.US Then
            MaskedTextBox1.Mask = "9999/99/99"
        ElseIf _DisplayLocale = Locale.TW Then
            MaskedTextBox1.Mask = "999/99/99"
        End If
    End Sub

    ''' <summary>
    ''' 取得年份
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetYear() As Integer
        'Select Case type
        '    Case DateTimePickerUCT.Locale.TW
        '        Return DateUtil.GetTwYear(dtp.getTwDate())
        '    Case DateTimePickerUCT.Locale.US
        '        Return DateUtil.GetUsYear(dtp.getValue())
        '    Case Else
        '        Return 0
        'End Select
        Return DateUtil.GetUsYear(dtp1.Value)
    End Function

    ''' <summary>
    ''' 取得月份
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMonth() As Integer
        Return DateUtil.GetMonth(dtp1.Value)
    End Function

    ''' <summary>
    ''' 取得日
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDay() As Integer
        Return DateUtil.GetDay(dtp1.Value)
    End Function


    ''' <summary>
    ''' 取得民國年日期
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTwDateStr() As String
        Return DateUtil.TransDateToROC(dtp1.Value)
    End Function

    ''' <summary>
    ''' 取得西元年日期
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUsDateStr() As String

        Return dtp1.Value
    End Function

    ''' <summary>
    ''' 設定日期
    ''' </summary>
    ''' <param name="dStr">日期:2015/01/01</param>
    ''' <remarks></remarks>
    Public Overloads Sub SetValue(ByVal dStr As String)
        Try

            If IsDate(dStr) Then
                doCellValueChange = False
                dtp1.Value = CDate(dStr).AddDays(1)
                doCellValueChange = True
                dtp1.Value = CDate(dStr)
            Else
                doCellValueChange = False
                MaskedTextBox1.Text = ""
            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 設定日期
    ''' </summary>
    ''' <param name="d">Date</param>
    ''' <remarks></remarks>
    Public Overloads Sub SetValue(ByVal d As Date)
        dtp1.Value = d
        doCellValueChange = True

    End Sub

    ''' <summary>
    ''' 判斷是否有效日
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InvalidDate()
        If IsShowError Then
            MaskedTextBox1.BackColor = Color.Pink

            MessageBox.Show("日期格式錯誤")
            MaskedTextBox1.Focus()
            IsShowError = False

        End If

    End Sub

    ''' <summary>
    '''  Focus
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetFocus()
        MaskedTextBox1.Focus()
    End Sub

    ''' <summary>
    ''' Initial Dtp Cell
    ''' </summary>
    ''' <param name="grid">來源grid</param>
    ''' <param name="dDB">dbDS</param>
    ''' <param name="dGrid">gridDS</param>
    ''' <param name="ConIndex">Con Index</param>
    ''' <param name="RowIndex">Row Index</param>
    ''' <remarks></remarks>
    Public Sub InitialDtpCell(ByRef grid As UCLDataGridViewUC, ByRef dDB As DataSet, ByRef dGrid As DataSet, ByVal ConIndex As Integer, ByVal RowIndex As Integer)
        Try

            dtp_dgv = grid
            cellRowIndex = RowIndex
            cellColIndex = ConIndex
            colWidth = dtp_dgv.dgv.Columns(cellColIndex).Width
            dsDB = dDB
            dsGrid = dGrid


        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' dtp_Enter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtp_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp1.Enter
        Try

            '  datagridview cell剛轉為dtp時~~ dtp value為current cell值
            If dtp_dgv IsNot Nothing AndAlso Me.FirstEnterGridCell Then

                If dtp_dgv.dgv.CurrentCell.Value IsNot DBNull.Value AndAlso dtp_dgv.dgv.CurrentCell.Value.ToString.Trim <> "" Then


                    If DisplayLocale = Locale.TW Then
                        '  MaskedTextBox1.Mask = "###0000"
                        dtp1.Value = CDate(TranEW(dtp_dgv.dgv.CurrentCell.Value, "/"))
                        MaskedTextBox1.Mask = ""
                        If (dtp_dgv.dgv.CurrentCell.Value.ToString.Trim.Contains("-")) Then
                            MaskedTextBox1.Text = "-" & MaskedTextBox1.Text.Trim.Replace("/", "")
                        Else
                            MaskedTextBox1.Text = MaskedTextBox1.Text.Trim.Replace("/", "")
                        End If

                    ElseIf DisplayLocale = Locale.US Then
                        dtp1.Value = CDate(dtp_dgv.dgv.CurrentCell.Value)
                        'MaskedTextBox1.Mask = "####0000"
                        MaskedTextBox1.Mask = ""
                        MaskedTextBox1.Text = MaskedTextBox1.Text.Trim.Replace("/", "")
                    End If

                Else
                    dtp1.Value = Now
                    MaskedTextBox1.Mask = ""
                    MaskedTextBox1.Text = " "

                End If

                '此行不可刪
                FirstEnterGridCell = False
                MaskedTextBox1.SelectAll()


            End If

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 取得日期
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetValue() As String
        Return MaskedTextBox1.Text.ToString()
    End Function

#Region "Event"

    ''' <summary>
    ''' dtp_ValueChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp1.ValueChanged
        Try

            If Not doCellValueChange AndAlso MaskedTextBox1.Text = "" Then
                Exit Sub
            End If

            IsShowError = True
            '  MessageBox.Show(dtp1.Value)
            Dim year As String = dtp1.Value.Year.ToString()
            Dim month As String = dtp1.Value.Month.ToString()
            Dim day As String = dtp1.Value.Day.ToString()
            MaskedTextBox1.BackColor = Color.White
            If _DisplayLocale = Locale.TW Then

                If year >= 1912 Then
                    year = year - 1911
                    If year.Length = 1 Then
                        year = "00" & year
                    ElseIf year.Length = 2 Then
                        year = "0" & year
                    End If
                Else
                    '民國前
                    year = year - 1912
                    year = Math.Abs(CInt(year)).ToString
                    If year.Length = 1 Then
                        year = "00" & year
                    ElseIf year.Length = 2 Then
                        year = "0" & year
                    End If

                    year = "-" & year
                End If

               
            End If

            If dtp1.Value.Month < 10 Then
                month = "0" & month
            End If

            If dtp1.Value.Day < 10 Then
                day = "0" & day
            End If

            MaskedTextBox1.Text = year & "/" & month & "/" & day

            'If dtp_dgv IsNot Nothing Then
            '    Me.Visible = False
            'End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' UCLDateTimePickerCellUI_Leave
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UCLDateTimePickerCellUI_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        ProcessLeave()

    End Sub

    ''' <summary>
    ''' Leave Event
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Private Function ProcessLeave() As Boolean
        Try
            MaskedTextBox1.BackColor = Color.White
            If MaskedTextBox1.Text.Replace("/", "").Trim = "" Then
                If dtp_dgv IsNot Nothing AndAlso Not Me.FirstEnterGridCell Then
                    Me.Visible = False
                    Console.WriteLine(dtp1.Value.ToShortDateString)
                    If dtp_dgv.uclTreeMode Then
                        TreeGridCol = 1
                    End If

                    If dtp_dgv.MultiSelect Then
                        '更新Grid的Cell Value
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = DBNull.Value

                        'dsDB 存code
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = DBNull.Value
                        dtp_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = DBNull.Value
                    Else
                        '更新Grid的Cell Value
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = DBNull.Value

                        'dsDB 存code
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = DBNull.Value
                        dtp_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = DBNull.Value
                    End If

                    '縮回去適當行寬
                    dtp_dgv.dgv.Columns(cellColIndex).Width = colWidth
                End If
                Return True
                Exit Function
            End If

            Dim isDate = False
            Dim maskStr As String = MaskedTextBox1.Mask

            If DisplayLocale = Locale.TW Then

                If MaskedTextBox1.Text.Trim = "" Then
                    ' clearDate()

                    MaskedTextBox1.Mask = "###/00/00"
                    Return True
                    Exit Function

                Else

                    MaskedTextBox1.Mask = ""
                    MaskedTextBox1.Text = MaskedTextBox1.Text.Trim.Replace("/", "")


                    If IsNumeric(MaskedTextBox1.Text.Trim) AndAlso MaskedTextBox1.Text.Trim.Length >= 5 Then
                        If MaskedTextBox1.Text.Trim.Contains("-") AndAlso MaskedTextBox1.Text.Trim.Length <= 8 Then

                            If MaskedTextBox1.Text.Trim.Length = 6 Then
                                MaskedTextBox1.Text = "00" & MaskedTextBox1.Text.Substring(0, 2) & "/" & MaskedTextBox1.Text.Substring(2, 2) & "/" & MaskedTextBox1.Text.Substring(4, 2)
                            ElseIf MaskedTextBox1.Text.Trim.Length = 7 Then
                                MaskedTextBox1.Text = "0" & MaskedTextBox1.Text.Substring(0, 3) & "/" & MaskedTextBox1.Text.Substring(3, 2) & "/" & MaskedTextBox1.Text.Substring(5, 2)
                            ElseIf MaskedTextBox1.Text.Trim.Length = 8 Then
                                MaskedTextBox1.Text = MaskedTextBox1.Text.Substring(0, 4) & "/" & MaskedTextBox1.Text.Substring(4, 2) & "/" & MaskedTextBox1.Text.Substring(6, 2)
                            End If

                            MaskedTextBox1.Text = MaskedTextBox1.Text.Trim.Replace("-", "")
                            MaskedTextBox1.Text = "-" & MaskedTextBox1.Text
                            isDate = True
                        ElseIf Not MaskedTextBox1.Text.Trim.Contains("-") AndAlso MaskedTextBox1.Text.Trim.Length <= 7 Then
                            If MaskedTextBox1.Text.Trim.Length = 5 Then
                                MaskedTextBox1.Text = "00" & MaskedTextBox1.Text.Substring(0, 1) & "/" & MaskedTextBox1.Text.Substring(1, 2) & "/" & MaskedTextBox1.Text.Substring(3, 2)
                            ElseIf MaskedTextBox1.Text.Trim.Length = 6 Then
                                MaskedTextBox1.Text = "0" & MaskedTextBox1.Text.Substring(0, 2) & "/" & MaskedTextBox1.Text.Substring(2, 2) & "/" & MaskedTextBox1.Text.Substring(4, 2)
                            ElseIf MaskedTextBox1.Text.Trim.Length = 7 Then
                                MaskedTextBox1.Text = MaskedTextBox1.Text.Substring(0, 3) & "/" & MaskedTextBox1.Text.Substring(3, 2) & "/" & MaskedTextBox1.Text.Substring(5, 2)
                            End If
                            isDate = True

                        Else
                            InvalidDate()
                            Return False
                            Exit Function
                        End If

                    Else
                        InvalidDate()
                        Return False
                        Exit Function

                    End If

                End If

            ElseIf DisplayLocale = Locale.US Then

                MaskedTextBox1.Text = MaskedTextBox1.Text.Replace("/", "")

                If MaskedTextBox1.Text.Trim = "" Then

                    MaskedTextBox1.Mask = "####/00/00"
                    Exit Function

                Else

                    If IsNumeric(MaskedTextBox1.Text.Trim) AndAlso MaskedTextBox1.Text.Trim.Length = 8 Then
                        MaskedTextBox1.Text = MaskedTextBox1.Text.Substring(0, 4) & "/" & MaskedTextBox1.Text.Substring(4, 2) & "/" & MaskedTextBox1.Text.Substring(6, 2)
                        isDate = True
                    ElseIf IsNumeric(MaskedTextBox1.Text.Trim) AndAlso MaskedTextBox1.Text.Trim.Length = 6 Then
                        MaskedTextBox1.Text = "20" & MaskedTextBox1.Text.Substring(0, 2) & "/" & MaskedTextBox1.Text.Substring(2, 2) & "/" & MaskedTextBox1.Text.Substring(4, 2)
                        isDate = True
                    Else
                        InvalidDate()
                        Return False
                        Exit Function
                    End If
                End If

            End If


            MaskedTextBox1.Mask = maskStr

            '日期格式才能存進去
            If TransDate(MaskedTextBox1.Text) Then
                'gridview cell
                If dtp_dgv IsNot Nothing AndAlso Not Me.FirstEnterGridCell Then
                    Me.Visible = False

                    If dtp_dgv.uclTreeMode Then
                        TreeGridCol = 1
                    End If

                    If dtp_dgv.MultiSelect Then

                        '更新Grid的Cell Value
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = MaskedTextBox1.Text.Trim()

                        'dsDB 存code
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - 1 - TreeGridCol) = enDateString  ' MaskedTextBox1.Text.Trim()


                    Else

                        '更新Grid的Cell Value
                        dsGrid.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = MaskedTextBox1.Text.Trim()

                        'dsDB 存code
                        dsDB.Tables(0).Rows(cellRowIndex).Item(cellColIndex - TreeGridCol) = enDateString 'MaskedTextBox1.Text.Trim()

                    End If

                    dtp_dgv.doCellValueChange = False
                    dtp_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = "1800/1/1"
                    dtp_dgv.doCellValueChange = True
                    dtp_dgv.Rows(cellRowIndex).Cells(cellColIndex).Value = MaskedTextBox1.Text.Trim()


                    '縮回去適當行寬
                    dtp_dgv.dgv.Columns(cellColIndex).Width = colWidth


                    If dtp_dgv.AllowUserToAddRows AndAlso cellRowIndex = dsGrid.Tables(0).Rows.Count - 1 Then
                        dtp_dgv.AddNewRow()
                    End If
                End If


            Else
                InvalidDate()
                'MessageBox.Show("日期格式錯誤")
                Return False
            End If
        Catch ex As Exception
            InvalidDate()
            ' Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try


    End Function
 
    ''' <summary>
    ''' 日期正確性檢驗 日期轉換
    ''' </summary>
    ''' <param name="value">日期字串 2015/01/01</param>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Private Function TransDate(ByVal value As String) As Boolean
        Dim isDateFlag As Boolean = False
        Try
            Dim enDate As String = ""
            Dim twDate As String = ""
            Dim dateArr() As String
            Dim en_Date As DateTime

            dateArr = splitDate(value.Trim)
            If (DisplayLocale = Locale.TW) Then
                If (value.Trim.Substring(0, 1).Equals("-") Or dateArr(0).Trim.Equals("0")) Then
                    value = ROCBefore(value)
                Else
                    value = TranEW(value.Trim, "/")
                End If
            Else
                Select Case dateArr(0).Trim.Length
                    Case 1, 2
                        dateArr(0) = checkYear(dateArr(0).Trim)
                        data.Length = 0
                        data.Append(dateArr(0)).Append("/").Append(dateArr(1)).Append("/").Append(dateArr(2))
                        value = data.ToString
                        MaskedTextBox1.Text = value
                End Select
            End If

            If (dateArr.Length = 1 AndAlso dateArr(0).Trim.Equals("")) Then
                isDateFlag = True
            Else
                en_Date = DateTime.ParseExact(value, dateFormats, us, DateTimeStyles.AllowWhiteSpaces)
                '西元年(格式:yyyy/MM/dd)
                enDate = combineEnDate(en_Date.ToString("yyyy/MM/dd", us), "/")
                twDate = TranWE(en_Date, "/")

                isDateFlag = True
            End If
            twDateString = twDate
            enDateString = enDate
            Return isDateFlag
        Catch ex As Exception
            'Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return isDateFlag
        End Try

    End Function

    ''' <summary>
    ''' 西元年轉民國年
    ''' </summary>
    ''' <param name="value">日期</param>
    ''' <param name="delimiter">分隔字元</param>
    ''' <remarks></remarks>
    '''
    Private Function TranWE(ByVal value As Date, ByVal delimiter As String) As String
        Try
            Dim twDate As String
            Dim year, month, day, format As String
            data.Length = 0
            If (value.Year <= 1911) Then
                year = (value.Year - 1912).ToString.PadLeft(3)
                month = appendChar(value.Month.ToString, CChar("0"), 2)
                day = appendChar(value.Day.ToString, CChar("0"), 2)
                twDate = (data.Append(year).Append(delimiter).Append(month).Append(delimiter).Append(day)).ToString
            Else
                format = (data.Append("yyyy").Append(delimiter).Append("MM").Append(delimiter).Append("dd")).ToString
                tw.DateTimeFormat.Calendar = New TaiwanCalendar
                twDate = value.ToString(format, tw)
            End If
            Return twDate
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' 民國年轉西元年(不含日期正確性檢驗)
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="delimiter"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function TranEW(ByVal value As String, ByVal delimiter As String) As String
        Try
            Dim year, month, day As String
            data.Length = 0
            Dim dateArr() As String = splitDate(value.Trim)

            If (dateArr.Length > 1) Then
                If CInt(dateArr(0).Trim) > 0 Then
                    year = (CInt(dateArr(0).Trim) + 1911).ToString
                Else
                    year = (CInt(dateArr(0).Trim) + 1912).ToString
                End If

                month = IIf((dateArr(1).Trim).Length = 1, "0" + dateArr(1).Trim, dateArr(1).Trim).ToString
                day = IIf((dateArr(2).Trim).Length = 1, "0" + dateArr(2).Trim, dateArr(2).Trim).ToString
                data.Append(year).Append(delimiter).Append(month).Append(delimiter).Append(day)
            End If
            Return data.ToString
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' 結合日期
    ''' </summary>
    ''' <param name="value">DateTime</param>
    ''' <param name="delimiter">分隔符號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function combineEnDate(ByVal value As DateTime, ByVal delimiter As String) As String
        Try
            Dim year, month, day As String

            data.Length = 0
            year = appendChar(value.Year.ToString, CChar("0"), 4)
            month = appendChar(value.Month.ToString, CChar("0"), 2)
            day = appendChar(value.Day.ToString, CChar("0"), 2)
            data.Append(year).Append(delimiter).Append(month).Append(delimiter).Append(day)
            Return data.ToString
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' 結合日期
    ''' </summary>
    ''' <param name="value">DateTime</param>
    ''' <param name="delimiter">分隔符號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function combineEnDate(ByVal value As String, ByVal delimiter As String) As String
        Try
            Dim year, month, day As String
            Dim dateArr() As String
            data.Length = 0
            dateArr = splitDate(value)
            If (dateArr.Length > 1) Then
                year = appendChar(dateArr(0).Trim.ToString, CChar("0"), 4)
                month = appendChar(dateArr(1).Trim.ToString, CChar("0"), 2)
                day = appendChar(dateArr(2).Trim.ToString, CChar("0"), 2)
                data.Append(year).Append(delimiter).Append(month).Append(delimiter).Append(day)
            End If

            Return data.ToString
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' 檢查年份
    ''' </summary>
    ''' <param name="year">西元年</param>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function checkYear(ByVal year As String) As String
        Try
            Dim value As String = ""
            Dim nowYear As Integer = CInt(IIf(Date.Today.Year < 1930, 1930, Date.Today.Year))
            Dim sYear, eYear, oYear, cYear As Integer
            oYear = CInt(year)
            cYear = 1900
            For i = 0 To 1000
                cYear = cYear + (yearRange * i)
                sYear = startYear + (yearRange * i)
                eYear = sYear + yearRange
                If (nowYear >= sYear AndAlso nowYear < eYear) Then
                    Select Case CInt(year)
                        Case 0 To 29
                            value = appendChar((cYear + yearRange + oYear).ToString, CChar("0"), 4)
                        Case Else
                            value = appendChar((cYear + oYear).ToString, CChar("0"), 4)
                    End Select
                    Exit For
                End If
            Next
            Return value

        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return ""
        End Try
    End Function

 
    ''' <summary>
    ''' 民國前 傳回西元年格式yyyy/MM/dd
    ''' </summary>
    ''' <param name="value">西元日期</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ROCBefore(ByVal value As String) As String
        Dim return_date As String = ""
        Try
            Dim year, month, day As String
            Dim dateArr() As String


            dateArr = splitDate(value)
            If (dateArr.Length = 1) Then
                year = value.Trim.Substring(0, value.Trim.Length - 4)
                month = appendChar(value.Trim.Substring(value.Trim.Length - 4, 2), CChar("0"), 2)
                day = appendChar(value.Trim.Substring(value.Trim.Length - 2, 2), CChar("0"), 2)
            Else
                year = dateArr(0).Trim
                month = appendChar(dateArr(1), CChar("0"), 2)
                day = appendChar(dateArr(2), CChar("0"), 2)
            End If

            If CInt(year) > 0 Then
                year = (1911 + CInt(year)).ToString
            Else
                year = (1912 + CInt(year)).ToString
            End If

            data.Length = 0
            data.Append(year).Append("/").Append(month).Append("/").Append(day)
            return_date = data.ToString
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
        Return return_date
    End Function

    Private Function appendChar(ByVal srcString As String, ByVal apdChar As Char, ByVal totalLength As Integer) As String
        If (srcString Is Nothing) Then
            srcString = ""
        End If
        If srcString.Length > totalLength Then
            srcString = srcString.Substring(0, totalLength)
        ElseIf srcString.Length < totalLength Then
            For i = 1 To totalLength - srcString.Length
                srcString = apdChar & srcString
            Next
        End If
        Return srcString
    End Function

    ''' <summary>
    ''' 拆日期
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function splitDate(ByVal value As String) As String()
        Dim dateArr() As String
        Try
            data.Length = 0
            Dim separator() As String = {"/"}
            dateArr = value.Trim.Split(separator, StringSplitOptions.RemoveEmptyEntries)
            Return dateArr
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' dtp1_Resize
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtp1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp1.Resize
        If UCLFormUtil.isResizeable Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
        Else
            Me.Height = 27
        End If

    End Sub
#End Region

    ''' <summary>
    ''' MaskedTextBox1_KeyDown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown


        Select Case e.KeyCode
            Case Windows.Forms.Keys.Left
                If dtp_dgv IsNot Nothing Then

                    dtp_dgv.SetEditCell(cellRowIndex, cellColIndex - 1)
                End If


            Case Windows.Forms.Keys.Up
                If dtp_dgv IsNot Nothing Then

                    dtp_dgv.SetEditCell(cellRowIndex - 1, cellColIndex)
                End If
            Case Windows.Forms.Keys.Down
                If dtp_dgv IsNot Nothing Then

                    dtp_dgv.SetEditCell(cellRowIndex + 1, cellColIndex)
                End If
            Case Windows.Forms.Keys.Right
                If dtp_dgv IsNot Nothing Then
                    dtp_dgv.SetEditCell(cellRowIndex, cellColIndex + 1)
                End If


            Case Else


        End Select


    End Sub

    ''' <summary>
    ''' MaskedTextBox1_KeyUp
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MaskedTextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter

        End Select
    End Sub

    ''' <summary>
    ''' 日曆關起來時
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtp1_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp1.CloseUp

        Me.Visible = False
        SendKeys.Send("{TAB}")
    End Sub

    ''' <summary>
    ''' ProcessCmdKey
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try

            Select Case keyData

                Case Keys.Tab, Keys.Enter

                    If Not ProcessLeave() Then

                        Return True
                    End If
                Case Keys.Escape, Keys.Left, Keys.Right, Keys.Up, Keys.Down
                    Me.Visible = False

                Case Keys.Space

                    If InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("美") OrElse InputLanguage.CurrentInputLanguage.LayoutName.Trim.Contains("英") Then

                        Dim pos As Integer = MaskedTextBox1.SelectionStart
                        MaskedTextBox1.Text = MaskedTextBox1.Text.Substring(0, MaskedTextBox1.SelectionStart) + " " + MaskedTextBox1.Text.Substring(MaskedTextBox1.SelectionStart)
                        pos += 1
                        MaskedTextBox1.SelectionStart = pos
                    End If

                    Return True


            End Select
        Catch ex As Exception
            Console.WriteLine(ex.ToString)   'Syscom.Client.cmm.ClientExceptionHandler.ProccessException(ex)
        End Try
    End Function

    ''' <summary>
    ''' MaskedTextBox1_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MaskedTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.TextChanged
        IsShowError = True
        MaskedTextBox1.BackColor = Color.White
    End Sub
     
End Class
