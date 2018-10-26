'/*
'*****************************************************************************
'*
'*    Page/Class Name:  年月控制項
'*              Title:	UCLYmPickerUC
'*        Description:	年月控制項
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Charles.Chiou
'*        Create Date:	2016-01-13
'*      Last Modifier:	Charles.Chiou
'*   Last Modify Date:	2016-01-13
'*
'*****************************************************************************
'*/



Imports Syscom.Comm.BASE
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.Configuration


Public Class UCLYmPickerUC

#Region "     變數宣告 "

    Private _DisplayLocale As Integer = Locale.US

    Private _DisplayMode As Integer = DisplayType.SystemDefault

    '西元年月
    Private enYmString As String = ""
    '民國年月
    Private twYmString As String = ""
    '西元年月日
    Private strDate As String = ""
    Dim IsShowError As Boolean = False
    Public Event ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

#End Region


#Region "     屬性設定 "

    ''' <summary>
    ''' 設定西元格式(US) 或 民國年格式(TW)
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Locale
        TW
        US
    End Enum

    ''' <summary>
    ''' 設定系統預設(SystemDefault) 或 自行設定(Custom)
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum DisplayType
        SystemDefault
        Custom
    End Enum

    ''' <summary>
    ''' 設定系統預設(SystemDefault) 或 自行設定(Custom)
    ''' </summary>
    ''' <returns>DisplayType</returns>
    ''' <remarks></remarks>
    Public Property DisplayMode() As DisplayType
        Get
            Return _DisplayMode
        End Get
        Set(ByVal value As DisplayType)
            _DisplayMode = value
        End Set
    End Property

    ''' <summary>
    ''' 設定display民國年月or西元年月
    ''' </summary>
    ''' <returns>Locale</returns>
    ''' <remarks></remarks>
    Public Property DisplayLocale() As Locale
        Get
            Return _DisplayLocale
        End Get
        Set(ByVal value As Locale)
            _DisplayLocale = value
            If txt_ym.MaskedTextBox1.Mask = "" Then
                Select Case value

                    Case Locale.TW
                        txt_ym.MaskedTextBox1.Mask = "###/00"
                    Case Locale.US
                        txt_ym.MaskedTextBox1.Mask = "####/00"
                End Select

            End If

        End Set
    End Property


    ''' <summary>
    ''' 設定背景顏色
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property BackColor() As Color
        Get
            Return txt_ym.BackColor
        End Get
        Set(ByVal value As Color)
            txt_ym.BackColor = value
        End Set
    End Property

    ''' <summary>
    ''' 設定唯獨屬性
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property uclReadOnly() As Boolean
        Get
            Return txt_ym.uclReadOnly
        End Get
        Set(ByVal value As Boolean)
            txt_ym.uclReadOnly = value
        End Set
    End Property

    ''' <summary>
    ''' 取得/設定 輸入的日期字串
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Overrides Property Text() As String

        Get
            Return txt_ym.Text
        End Get
        Set(ByVal value As String)
            If (value.Trim.Length = 0) Then
                Clear()
            Else
                Select Case DisplayLocale
                    Case Locale.TW
                        txt_ym.Text = value.PadLeft(5)
                    Case Locale.US
                        txt_ym.Text = value.PadLeft(6)
                End Select

            End If

        End Set
    End Property


#End Region

#Region "     主要功能 "

#Region "     初始化設定 "

    Sub New()

        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        '設定成共用的字型
        Me.Font = AppConfigUtil.ControlFont

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

        txt_ym.MaskedTextBox1.PromptChar = "_"

    End Sub


#End Region

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "

#Region "    設定年月"

    ''' <summary>
    ''' 程式說明：設定年月，輸入年月格式 yyyyMM (西元)
    ''' 開發人員：Charles
    ''' 開發日期：2016/01/13
    ''' </summary>
    ''' <param name="strYm">年月：yyyyMM(西元)</param>
    ''' <remarks></remarks>
    Public Overloads Sub SetValue(ByVal strYm As String)
        Try

            'yyyyMM
            If strYm.Length = 6 Then

                strYm = strYm.Substring(0, 4) & "/" & strYm.Substring(4, 2) & "/" & "01"


                '設定日期
                dtp_ym.SetValue(strYm)

            Else

                MessageHandling.ShowErrorMsg("CMMCMMB300", "時間格式不符")

            End If


        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"設定年月"})
        End Try
    End Sub



    ''' <summary>
    ''' 程式說明：設定年月，輸入日期
    ''' 開發人員：Charles
    ''' 開發日期：2016/01/13
    ''' </summary>
    ''' <param name="d">日期</param>
    ''' <remarks></remarks>
    Public Overloads Sub SetValue(ByVal d As Date)
        Try

            '設定日期
            dtp_ym.SetValue(d)

        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"設定年月"})
        End Try
    End Sub


#End Region



#Region "    取得年月"


    ''' <summary>
    ''' 取得西元年月字串
    ''' </summary>
    ''' <returns>String(yyyyMM)</returns>
    ''' <remarks></remarks>
    Public Function GetUsYmStr() As String
        If (txt_ym.Focused) Then dtp_ym.Focus()

        Return enYmString

    End Function


    ''' <summary>
    ''' 取得民國年月字串
    ''' </summary>
    ''' <returns>String(yyyyMM)</returns>
    ''' <remarks></remarks>
    Public Function GetTwYmStr() As String
        If (txt_ym.Focused) Then dtp_ym.Focus()

        Return twYmString

    End Function

#End Region


#Region "    取得年月日"


#Region "    取得西元年月日(月初)"


    ''' <summary>
    ''' 取的西元年月日(月初)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUsYmStartDateStr() As String
        Dim RtnDateStr As String = ""
        Try

            If Not "".Equals(enYmString) Then

                RtnDateStr = enYmString.Substring(0, 4) & "/" & enYmString.Substring(4, 2) & "/01"

            End If


        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
        Return RtnDateStr
    End Function


#End Region


#Region "    取得西元年月日(月底)"


    ''' <summary>
    ''' 取得西元年月日(月底)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUsYmEndDateStr() As String
        Dim RtnDateStr As String = ""
        Try

            If Not "".Equals(enYmString) Then

                RtnDateStr = enYmString.Substring(0, 4) & "/" & enYmString.Substring(4, 2) & "/01"

                RtnDateStr = CDate(RtnDateStr).AddMonths(1).ToShortDateString()

                RtnDateStr = CDate(RtnDateStr).AddDays(-1).ToShortDateString()

            End If


        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
        Return RtnDateStr
    End Function


#End Region



#End Region


#Region "     清除年月 "

    ''' <summary>
    ''' 程式說明：清除年月元件
    ''' 開發人員：Charles
    ''' 開發日期：2016/1/13
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()

        dtp_ym.Clear()
        txt_ym.Text = ""
        clearYm()
    End Sub

    ''' <summary>
    ''' 清除年月
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearYm()
        enYmString = ""
        twYmString = ""
        strDate = ""
    End Sub



#End Region


#End Region

#End Region

#Region "     內部功能 "

#Region "     事件集合 "

    ''' <summary>
    ''' 程式說明：年月輸入事件
    ''' 開發人員：Charles
    ''' 開發日期：2016/01/13
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_ym_Enter(ByVal sender As Object, e As EventArgs) Handles txt_ym.Enter
        Dim col As Color = txt_ym.BackColor
        If DisplayLocale = Locale.TW Then
            '  baseMTB.Mask = "###0000"


            txt_ym.MaskedTextBox1.Mask = ""
            txt_ym.Text = txt_ym.Text.Trim.Replace("/", "")

        ElseIf DisplayLocale = Locale.US Then
            'baseMTB.Mask = "####0000"
            txt_ym.MaskedTextBox1.Mask = ""
            txt_ym.Text = txt_ym.Text.Trim.Replace("/", "")
        End If
        txt_ym.BackColor = col
    End Sub

    ''' <summary>
    ''' 程式說明：年月改變事件
    ''' 開發人員：Charles
    ''' 開發日期：2016/01/13
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_ym_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ym.TextChanged
        IsShowError = True
        txt_ym.BackColor = Color.White
    End Sub

    ''' <summary>
    ''' 程式說明：呼叫離開年月元件事件
    ''' 開發人員：Charles
    ''' 開發日期：2016/01/13
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_ym_KeyUp(sender As Object, e As KeyEventArgs) Handles txt_ym.KeyUp
        If e.KeyCode = Keys.Enter Then
            'baseMTB.Focus()
            txt_ym_Leave(sender, e)
        End If

        'RaiseEvent KeyUp(sender, e)
    End Sub

    ''' <summary>
    ''' 程式說明：離開年月元件事件
    ''' 開發人員：Charles
    ''' 開發日期：2016/01/13
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_ym_Leave(sender As Object, e As EventArgs) Handles txt_ym.Leave
        Try
            DetermineDisplayType()

            Dim maskStr As String = txt_ym.MaskedTextBox1.Mask
            txt_ym.MaskedTextBox1.Mask = ""
            txt_ym.Text = txt_ym.Text.Trim.Replace("/", "")


            Dim txtym_length As Integer = txt_ym.Text.Trim.Length
            Dim txtStr As String = txt_ym.Text.Trim

            Select Case DisplayLocale

                Case Locale.TW

                    If "".Equals(txtStr) Then
                        clearYm()

                        txt_ym.MaskedTextBox1.Mask = "###/00"

                        'Date2 = baseMTB.Text.Trim
                        Exit Sub
                    Else

                        If IsNumeric(txtStr) AndAlso txtym_length >= 3 AndAlso txtym_length <= 5 Then



                            If txtym_length = 3 Then    ' 民國1年1月 101

                                If CInt(txtStr.Substring(0, 1)) = 0 Then
                                    InvalidDate()
                                    Exit Sub
                                End If

                                'txt_ym.Text = "00" & txtStr.Substring(0, 1) & "/" & txtStr.Substring(1, 2)
                                txtStr = "00" & txtStr.Substring(0, 1) & "/" & txtStr.Substring(1, 2)


                            ElseIf txtym_length = 4 Then '民國90年1月  9001

                                If CInt(txtStr.Substring(0, 2)) = 0 Then
                                    InvalidDate()
                                    Exit Sub
                                End If

                                'txt_ym.Text = "0" & txtStr.Substring(0, 2) & "/" & txtStr.Substring(2, 2)
                                txtStr = "0" & txtStr.Substring(0, 2) & "/" & txtStr.Substring(2, 2)

                            ElseIf txtym_length = 5 Then '民國104年1月  10401

                                If CInt(txtStr.Substring(0, 3)) = 0 Then
                                    InvalidDate()
                                    Exit Sub
                                End If

                                txtStr = txtStr.Substring(0, 3) & "/" & txtStr.Substring(3, 2)
                            End If

                        Else
                            InvalidDate()
                            Exit Sub
                        End If

                    End If

                Case Locale.US

                    If "".Equals(txtStr) Then
                        clearYm()

                        txt_ym.MaskedTextBox1.Mask = "####/00"

                        'Date2 = baseMTB.Text.Trim
                        Exit Sub
                    Else

                        If IsNumeric(txtStr) AndAlso txtym_length = 6 Then

                            If CInt(txtStr.Substring(0, 4)) = 0 Then
                                InvalidDate()
                                Exit Sub
                            End If

                            txtStr = txtStr.Substring(0, 4) & "/" & txtStr.Substring(4, 2)

                        ElseIf IsNumeric(txtStr) AndAlso txtym_length = 4 Then

                            'txt_ym.Text = "20" & txtStr.Substring(0, 2) & "/" & txtStr.Substring(2, 2)
                            txtStr = "20" & txtStr.Substring(0, 2) & "/" & txtStr.Substring(2, 2)

                        Else
                            InvalidDate()
                            Exit Sub
                        End If

                    End If


            End Select

            Dim flag As Boolean = True
            Try

                'Dim strYm As String = txt_ym.Text
                Dim strYm As String = txtStr.Replace("/", "")

                Select Case DisplayLocale

                    Case Locale.TW

                        enYmString = DateUtil.TransYMToWE(strYm)
                        twYmString = strYm


                    Case Locale.US


                        enYmString = strYm
                        twYmString = DateUtil.TransYMToROC(strYm)

                End Select

            Catch ex As Exception
                flag = False
            End Try

            If (Not flag) Then
                InvalidDate()
                Exit Sub
            Else
                txt_ym.BackColor = Color.White
            End If



            Try

                strDate = enYmString.Substring(0, 4) & "/" & enYmString.Substring(4, 2) & "/" & "01"
                dtp_ym.SetValue(strDate)

            Catch ex As Exception

            End Try

            txt_ym.MaskedTextBox1.Mask = maskStr
            txt_ym.Text = txtStr
            RaiseEvent ValueChanged(Me, e)
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"年月輸入"})
        End Try
    End Sub

    ''' <summary>
    ''' 程式說明：dtp_ym->txt_ym
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtp_ym_ValueChanged(sender As Object, e As EventArgs) Handles dtp_ym.ValueChanged
        Try
            If dtp_ym.GetUsDateStr IsNot Nothing And dtp_ym.GetUsDateStr IsNot DBNull.Value And dtp_ym.Text <> "" Then


                enYmString = Me.dtp_ym.GetYear(UCLDateTimePickerUC.Locale.US) & Me.dtp_ym.GetMonth.ToString("00")
                twYmString = Me.dtp_ym.GetYear(UCLDateTimePickerUC.Locale.TW) & Me.dtp_ym.GetMonth.ToString("00")


                DetermineDisplayType()
               
                Select Case DisplayLocale

                    Case Locale.TW

                        Me.txt_ym.Text = twYmString
                        RaiseEvent ValueChanged(Me, e)
                    Case Locale.US

                        Me.txt_ym.Text = enYmString
                        RaiseEvent ValueChanged(Me, e)
                End Select


            End If
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"年月UI控制"})
        End Try
    End Sub

#End Region

#Region "方法集合"

    ''' <summary>
    ''' 程式說明：決定顯示方式
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DetermineDisplayType()

        Dim dateText As String = txt_ym.Text.Trim
        If (DisplayMode = DisplayType.SystemDefault) Then

            Try

                If StringUtil.nvl(ConfigurationManager.AppSettings.Item("isDefaultDisplayUS")).ToUpper().Equals("FALSE") Then
                    DisplayLocale = Locale.TW
                    txt_ym.MaskedTextBox1.Mask = "###/00"
                Else
                    DisplayLocale = Locale.US
                End If

                txt_ym.Text = dateText
            Catch ex As Exception
                DisplayLocale = Locale.TW
                txt_ym.Text = dateText
            End Try
        Else
            DisplayLocale = _DisplayLocale

        End If


    End Sub

    ''' <summary>
    ''' 程式說明：顯示年月格式錯誤
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InvalidDate()
        If IsShowError Then

            clearYm()
            txt_ym.BackColor = Color.Pink

            'MessageBox.Show("日期格式錯誤")
            MessageHandling.ShowErrorMsg("CMMCMMB302", "年月格式錯誤")
            IsShowError = False
        End If

    End Sub



#End Region

#End Region



End Class


