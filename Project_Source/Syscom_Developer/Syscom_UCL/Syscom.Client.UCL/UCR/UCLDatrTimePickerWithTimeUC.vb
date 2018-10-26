'/*
'*****************************************************************************
'*
'*    Page/Class Name:  日期與時間元件
'*              Title:	UCLDatrTimePickerWithTimeUC
'*        Description:	日期與時間元件
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2015-07-29
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2015-07-29
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
 



Public Class UCLDatrTimePickerWithTimeUC

#Region "     變數宣告 "
 
#End Region

#Region "     屬性設定 "
     

#End Region

#Region "     主要功能 "

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "

#Region "     設定預設時間 "

    ''' <summary>
    ''' 設定預設日期時間，輸入格式為 yyyy/MM/dd HH:mm:ss  or yyyy/MM/dd HH:mm or  yyyy/MM/dd   
    ''' </summary>
    ''' <param name="startTime" >時間：yyyy/MM/dd HH:mm:ss  or yyyy/MM/dd HH:mm or  yyyy/MM/dd </param>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub SetDefaultTime(ByVal startTime As String)

        Try

            ' yyyy/MM/dd HH:mm:ss or  yyyy/MM/dd HH:mm
            If startTime.Length = 19 Or startTime.Length = 16 Then

                '設定日期
                dtp_Date.SetValue(startTime.Substring(0, 10).Replace("-", "/"))

                '設定時間
                txt_Time.Text = startTime.Substring(11, 2) & startTime.Substring(14, 2)

            ElseIf startTime.Length = 10 Then

                '設定日期
                dtp_Date.SetValue(startTime.Substring(0, 10).Replace("-", "/"))

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
    ''' <param name="startTime" >時間，4位數字</param>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub SetTimeValue(ByVal startTime As String)

        Try

            Dim errorStr As String = ""

            If startTime.Length = 4 AndAlso CheckTimeFormate(startTime) Then

                '設定時間
                txt_Time.Text = startTime

            ElseIf startTime.Length <> 0 Then

                errorStr = errorStr & "時間"

            End If

         
            If errorStr <> "" Then
                MessageHandling.ShowErrorMsg("CMMCMMB300", "時間格式不符，請重新設定4碼時間數字")
            End If



        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"設定時間Txt，輸入格式為 HHmm"})

        End Try

      

    End Sub

#End Region

#Region "     設定當下時間 "

    ''' <summary>
    ''' 設定當下時間 
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub SetToday()

        Try

            Dim nowDate As String = Now.ToString("yyyy-MM-dd HH:mm")

            SetDefaultTime(nowDate)


        Catch cmex As CommonException
            Throw cmex 
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"設定當下時間"})

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

            txt_Time.Enabled = False


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

            txt_Time.Enabled = True


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"解除鎖定時間欄位"})

        End Try

    End Sub

#End Region

#Region "     鎖定日期與時間欄位 "

    ''' <summary>
    ''' 鎖定日期與時間欄位
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub LockDateTime()

        Try

            dtp_Date.Enabled = False
            txt_Time.Enabled = False


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"鎖定日期與時間欄位"})

        End Try

    End Sub

#End Region

#Region "     解除鎖定日期與時間欄位 "

    ''' <summary>
    ''' 解除鎖定日期與時間欄位
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2015-5-20</remarks>
    Public Sub UnlockStartDateTime()

        Try

            dtp_Date.Enabled = True
            txt_Time.Enabled = True


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"解除鎖定日期與時間欄位"})

        End Try

    End Sub

#End Region

#Region "     清除日期與時間欄位 "

    ''' <summary>
    ''' 解除鎖定日期與時間欄位
    ''' </summary>
    ''' <remarks>by Kevin.kai on 2015-07-30</remarks>
    Public Sub Clear()

        '2015/09/01 調整函式名稱 ClearStartDateTime => Clear

        dtp_Date.Clear()
        txt_Time.Clear()
    End Sub

#End Region

#Region "     取得時間資料(yyyy/MM/dd HH:mm) "

    ''' <summary>
    ''' 取得時間資料(yyyy/MM/dd HH:mm)
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2015-05-20</remarks>
    Public Function GetTime() As String

        Dim returnString As String = ""

        Try

            Dim startTime As String = nvl(txt_Time.Text)


            If CheckTimeFormate(startTime) Then

                returnString = dtp_Date.GetUsDateStr & " " & TransStrToTime(startTime)

                '設定成正確顏色
                txt_Time.BackColor = BACK_COLOR_DEFAULT

            ElseIf startTime = "" And dtp_Date.GetUsDateStr = "" Then
                '全都不填

                '設定成正確顏色
                txt_Time.BackColor = BACK_COLOR_DEFAULT

            Else

                '設定成錯誤顏色
                txt_Time.BackColor = BACK_COLOR_ERROR_INPUT

                MessageHandling.ShowWarnMsg("CMMCMMB300", "查詢時間未輸入完整 或 格式不正確，請重新輸入!")

            End If

            Return returnString


        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception

            Throw New CommonException("CMMCMMB302", ex, New String() {"取得查詢條件，回傳一個字串陣列，第一個為起始時間，第二個為結束時間"})


        End Try

    End Function

#End Region

#End Region

#End Region

#Region "     內部功能 "
     

#End Region

End Class

