'/*
'*****************************************************************************
'*
'*    Page/Class Name:  時間區間控制項
'*              Title:	UclTimeIntervalUC
'*        Description:	時間區間控制項
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2015-05-20
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2015-05-20
'*
'*****************************************************************************
'*/
 

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Comm.Utility.DateUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.UCL.UCLScreenUtil
 

Public Class UclTimeIntervalUC

#Region "     變數宣告 "

    'typeFlag 顯示模式，顯示模式：1：日期時間，2：日期
    Private gblDisplayFormate As String = ""

#End Region

#Region "     屬性宣告 "

    ''' <summary>
    ''' 根據 typeFlag 顯示模式，顯示模式：1：日期時間，2：日期
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Property uclDisplayFormate As String
        Get
            Return gblDisplayFormate
        End Get
        Set(ByVal value As String)
            gblDisplayFormate = value
            ShowByType(gblDisplayFormate)
        End Set
    End Property
     
#End Region

#Region "     主要功能 "

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "


#Region "     根據 typeFlag 顯示模式  "

    ''' <summary>
    ''' 根據 typeFlag 顯示模式
    ''' </summary>
    ''' <param name="typeFlag" >顯示模式：1：日期時間，2：日期</param> 
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub ShowByType(ByVal typeFlag As String)

        Try

            gblDisplayFormate = typeFlag

            '預設全部顯示
            '日期
            dtp_Start.Visible = True
            dtp_End.Visible = True
            '時間
            txt_StartTime.Visible = True
            txt_EndTime.Visible = True

            Select Case typeFlag

                Case 1
                    '顯示日期時間，不動作

                Case 2
                    '顯示日期
                    '關閉時間
                    txt_StartTime.Visible = False
                    txt_EndTime.Visible = False

            End Select


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"根據 typeFlag 顯示模式"})

        End Try

    End Sub

#End Region

#Region "     設定預設時間 "

    ''' <summary>
    ''' 設定預設時間，輸入格式為 yyyy/MM/dd HH:mm or  yyyy/MM/dd
    ''' </summary>
    ''' <param name="startTime" >開始時間</param>
    ''' <param name="EndTime" >結束時間</param>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub SetDefaultTime(ByVal startTime As String, ByVal EndTime As String)

        Try

            If startTime.Length = 16 And EndTime.Length = 16 Then


                '設定開始日期
                dtp_Start.SetValue(startTime.Substring(0, 10).Replace("-", "/"))

                '設定開始時間
                txt_StartTime.Text = startTime.Substring(11, 2) & startTime.Substring(14, 2)

                '設定結束日期
                dtp_End.SetValue(EndTime.Substring(0, 10).Replace("-", "/"))

                '設定結束時間
                txt_EndTime.Text = EndTime.Substring(11, 2) & EndTime.Substring(14, 2)


            ElseIf startTime.Length = 10 And EndTime.Length = 10 Then

                '設定開始日期
                dtp_Start.SetValue(startTime.Substring(0, 10).Replace("-", "/"))

                '設定結束日期
                dtp_End.SetValue(EndTime.Substring(0, 10).Replace("-", "/"))

            Else

                MessageHandling.ShowErrorMsg("CMMCMMB300", "時間格式不符")

            End If


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"設定預設時間"})

        End Try

    End Sub

#End Region

#Region "     設定時間Txt，輸入格式為 HHmm  "

    ''' <summary>
    ''' 設定時間Txt，輸入格式為 HHmm 
    ''' </summary>
    ''' <param name="startTime" >開始時間，4位數字</param>
    ''' <param name="EndTime" >結束時間，4位數字</param>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub SetTimeValue(ByVal startTime As String, ByVal EndTime As String)

        Try

            Dim errorStr As String = ""

            If startTime.Length = 4 AndAlso CheckTimeFormate(startTime) Then

                '設定開始時間
                txt_StartTime.Text = startTime

            ElseIf startTime.Length <> 0 Then

                errorStr = errorStr & "開始時間"

            End If

            If EndTime.Length = 4 AndAlso CheckTimeFormate(EndTime) Then

                '設定結束時間
                txt_EndTime.Text = EndTime

            ElseIf EndTime.Length <> 0 Then

                errorStr = errorStr & " 結束時間"

            End If

            If errorStr <> "" Then
                MessageHandling.ShowErrorMsg("CMMCMMB300", errorStr & "，時間格式不符，請重新設定4碼時間數字")
            End If


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"設定時間Txt，輸入格式為 HHmm "})

        End Try

    End Sub

#End Region

#Region "     設定本日時間 00:00~23:59 "

    ''' <summary>
    ''' 設定本日時間 00:00~23:59
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub SetToday()

        Try

            Dim nowDate As String = Now.ToString("yyyy/MM/dd")

            Dim startDateTime As String = nowDate & " 00:00"
            Dim endDateTime As String = nowDate & " 23:59"

            setDefaultTime(startDateTime, endDateTime)


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception 
            Throw New CommonException("CMMCMMB302", ex, New String() {"設定本日時間 00:00~23:59"}) 
        End Try

    End Sub

#End Region

#Region "     設定日期當月的月初~月末 "

    ''' <summary>
    ''' 設定日期當月的月初~月末
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub SetByMonth(ByVal monDate As Date)

        Try

            Dim firstDate As String = New DateTime(monDate.Year, monDate.Month, 1).ToString("yyyy-MM-dd") & " 00:00"

            Dim lastDate As String = New DateTime(monDate.AddMonths(1).Year, monDate.AddMonths(1).Month, 1).AddDays(-1).ToString("yyyy-MM-dd") & " 23:59"

            setDefaultTime(firstDate, lastDate)


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception 
            Throw New CommonException("CMMCMMB302", ex, New String() {"設定預設時間"}) 
        End Try

    End Sub

#End Region

#Region "     鎖定時間欄位 "

    ''' <summary>
    ''' 鎖定時間欄位
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub LockTime()

        Try

            txt_StartTime.Enabled = False

            txt_EndTime.Enabled = False


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"鎖定時間欄位"})

        End Try

    End Sub

#End Region

#Region "     解除鎖定時間欄位 "

    ''' <summary>
    ''' 解除鎖定時間欄位
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub UnlockTime()

        Try

            txt_StartTime.Enabled = True

            txt_EndTime.Enabled = True


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"解除鎖定時間欄位"})

        End Try

    End Sub

#End Region

#Region "     鎖定開始日期與時間欄位 "

    ''' <summary>
    ''' 鎖定開始日期與時間欄位
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub LockStartDateTime()

        Try

            dtp_Start.Enabled = False
            txt_StartTime.Enabled = False


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"鎖定開始日期與時間欄位"})

        End Try

    End Sub

#End Region

#Region "     解除鎖定開始日期與時間欄位 "

    ''' <summary>
    ''' 解除鎖定開始日期與時間欄位
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub UnlockStartDateTime()

        Try

            dtp_Start.Enabled = True
            txt_StartTime.Enabled = True


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"解除鎖定開始日期與時間欄位"})

        End Try

    End Sub

#End Region

#Region "     鎖定結束日期與時間欄位 "

    ''' <summary>
    ''' 鎖定結束日期與時間欄位
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub LockEndDateTime()

        Try

            dtp_End.Enabled = False
            txt_EndTime.Enabled = False


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"鎖定結束日期與時間欄位"})

        End Try

    End Sub

#End Region

#Region "     解除鎖定結束日期與時間欄位 "

    ''' <summary>
    ''' 解除鎖定結束日期與時間欄位
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub UnlockEndDateTime()

        Try

            dtp_End.Enabled = True
            txt_EndTime.Enabled = True


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"解除鎖定結束日期與時間欄位"})

        End Try

    End Sub

#End Region

#Region "     取得查詢條件，回傳一個字串陣列，第一個為起始時間，第二個為結束時間(yyyy/MM/dd HH:mm) "

    ''' <summary>
    ''' 取得查詢條件，回傳一個字串陣列，第一個為起始時間，第二個為結束時間(yyyy/MM/dd HH:mm)
    ''' 若沒有資料，或不正確，會回傳兩個空字串 的字串陣列
    ''' </summary>
    ''' <returns>String()</returns>
    ''' <remarks>by Sean.Lin on 2015-05-20</remarks>
    Public Function GetTimeInterval() As String()

        Dim returnString As String() = New String() {"", ""}

        Try

            Dim startDate As String = dtp_Start.GetUsDateStr
            Dim endDate As String = dtp_End.GetUsDateStr

            Dim startTime As String = nvl(txt_StartTime.Text)
            Dim endTime As String = nvl(txt_EndTime.Text)


            '設定成正確顏色
            dtp_Start.BackColor = Color.White
            dtp_End.BackColor = Color.White
            txt_StartTime.BackColor = BACK_COLOR_DEFAULT
            txt_EndTime.BackColor = BACK_COLOR_DEFAULT

            '只有日期的話
            If nvl(uclDisplayFormate) = "2" Then

                '有日期為空
                If startDate = "" Or endDate = "" Then
                    returnString = New String() {startDate, endDate}
                    '開始日 > 結束日
                ElseIf startDate > endDate Then
                    returnString = New String() {endDate, startDate}
                Else
                    returnString = New String() {startDate, endDate}
                End If

                '日期時間
            Else

                Dim startDateTime As String = ""
                Dim endDateTime As String = ""

                '判斷開始時間
                If CheckTimeFormate(startTime) And dtp_Start.GetUsDateStr <> "" Then
                    startDateTime = dtp_Start.GetUsDateStr & " " & TransStrToTime(startTime)

                ElseIf startTime = "" And dtp_Start.GetUsDateStr = "" Then
                    '空白時間不動作
                Else
                    '設定成錯誤顏色
                    dtp_Start.BackColor = BACK_COLOR_ERROR_INPUT
                    txt_StartTime.BackColor = BACK_COLOR_ERROR_INPUT
                    'startDateTime = dtp_Start.GetUsDateStr & " 00:00"
                    'txt_StartTime.Text = "0000"

                    MessageHandling.ShowWarnMsg("CMMCMMB300", "開始時間未輸入完整 或 格式不正確!")

                End If

                '判斷結束時間
                If CheckTimeFormate(endTime) And dtp_End.GetUsDateStr <> "" Then
                    endDateTime = dtp_End.GetUsDateStr & " " & TransStrToTime(endTime)
                ElseIf endTime = "" And dtp_End.GetUsDateStr = "" Then
                    '空白時間不動作
                Else
                    '設定成錯誤顏色 
                    dtp_End.BackColor = BACK_COLOR_ERROR_INPUT
                    txt_EndTime.BackColor = BACK_COLOR_ERROR_INPUT
                    'endDateTime = dtp_End.GetUsDateStr & " 00:00"
                    'txt_EndTime.Text = "0000"

                    MessageHandling.ShowWarnMsg("CMMCMMB300", "結束時間未輸入完整 或 格式不正確!")
                End If

                '有日期為空
                If startDateTime = "" Or endDateTime = "" Then
                    returnString = New String() {startDateTime, endDateTime}
                    '開始日 > 結束日
                ElseIf startDate > endDate Then
                    returnString = New String() {endDateTime, startDateTime}
                Else
                    returnString = New String() {startDateTime, endDateTime}
                End If
            End If

            Return returnString


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"取得查詢條件，回傳一個字串陣列，第一個為起始時間，第二個為結束時間"})


        End Try

    End Function

#End Region

#Region "     清除 "

    ''' <summary>
    ''' 清除日期與時間
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-09-01</remarks>
    Public Sub Clear()
         
        Try

            txt_StartTime.Text = ""
            txt_EndTime.Text = ""
            dtp_Start.Clear()
            dtp_End.Clear()
 
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"清除"})
             
        End Try

    End Sub

#End Region


#End Region

#End Region

End Class

