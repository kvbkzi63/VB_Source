'/*
'*****************************************************************************
'*
'*    Page/Class Name:  檢查函數方法
'*              Title:	CheckMethodUtil
'*        Description:	檢查函數方法
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2013-07-10
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2013-07-10
'*
'*****************************************************************************
'*/

Imports System.Reflection
Imports Syscom.Comm.EXP

Public Class CheckMethodUtil

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

#Region " 檢查傳入 Object 是否為 Nothing "

    ''' <summary>
    ''' 檢查是否為 Nothing 。
    '''
    ''' True : 不為 Nothing 。
    '''
    ''' False : Nothing。
    '''
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-07-10</remarks>
    Public Shared Function CheckIsNothing(ByVal inputObj As Object) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim returnFlag As Boolean = False
            If inputObj IsNot Nothing Then
                returnFlag = True
            End If
            Return returnFlag
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region " 檢查傳入 DataSet "

    ''' <summary>
    ''' 檢查Tables(0) 是否存在，輸入為DataSet。
    '''
    ''' True : 存在 。
    '''
    ''' False : Nothing or Tables count 為零。
    '''
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-12-02</remarks>
    Public Shared Function CheckHasTable(ByVal inputDS As DataSet) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim returnFlag As Boolean = False
            If CheckIsNothing(inputDS) Then
                If inputDS.Tables.Count > 0 Then
                    returnFlag = True
                End If
            End If
            Return returnFlag
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 檢查Tables(0) 是否有資料，輸入為DataSet。
    '''
    ''' True : 有值 。
    '''
    ''' False : Nothing or Tables count or Row count 為零。
    '''
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-10-31</remarks>
    Public Shared Function CheckHasValue(ByVal inputDS As DataSet) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim returnFlag As Boolean = False
            If CheckIsNothing(inputDS) Then
                If inputDS.Tables.Count > 0 Then
                    returnFlag = CheckHasValue(inputDS.Tables(0))
                End If
            End If
            Return returnFlag
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 檢查Tables(TableName) 是否有資料，輸入為DataSet，TableName。
    '''
    ''' True : 有值 。
    '''
    ''' False : Tables count or Row count 為零
    '''
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-10-31</remarks>
    Public Shared Function CheckHasValue(ByVal inputDS As DataSet, ByVal TableName As String) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim returnFlag As Boolean = False
            If CheckIsNothing(inputDS) Then
                If inputDS.Tables.Count > 0 Then
                    returnFlag = CheckHasValue(inputDS.Tables(TableName))
                End If
            End If
            Return returnFlag
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 檢查Table 是否有資料，輸入為DataTable 。
    '''
    ''' True : 有值 。
    '''
    ''' False : Tables count or Row count 為零
    '''
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-10-31</remarks>
    Public Shared Function CheckHasValue(ByVal inputDT As DataTable) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim returnFlag As Boolean = False
            If CheckIsNothing(inputDT) Then
                If inputDT.Rows.Count > 0 Then
                    returnFlag = True
                End If
            End If
            Return returnFlag
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 檢查Tables(TableName) 是否存在，輸入為DataSet，TableName。
    '''
    ''' True : 存在 。
    '''
    ''' False : Tables 不存在
    '''
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-12-02</remarks>
    Public Shared Function CheckHasTable(ByVal inputDS As DataSet, ByVal TableName As String) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim returnFlag As Boolean = False
            If CheckIsNothing(inputDS) Then
                If inputDS.Tables.Contains(TableName) Then
                    returnFlag = True
                End If
            End If
            Return returnFlag
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region " 檢查傳入字串 String "

    ''' <summary>
    ''' 檢查 字串 是否有資料 。
    '''
    ''' True : 有值 。
    '''
    ''' False : Nothing or Empty String。
    '''
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2011-10-31</remarks>
    Public Shared Function CheckHasValue(ByVal inputString As String) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            Dim returnFlag As Boolean = False
            If CheckIsNothing(inputString) Then
                If inputString.Length > 0 Then
                    returnFlag = True
                End If
            End If
            Return returnFlag
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 檢查時間是否不為Null 且為XX:XX or XXOO or XX:OO:XX 格式，
    '''
    ''' True : 正確 。
    '''
    ''' False : 錯誤，
    '''
    ''' </summary>
    ''' <param name="input_Time" >時間</param>
    ''' <returns>String</returns>
    ''' <remarks>by Sean.Lin on 2011-12-14</remarks>
    Public Shared Function CheckTimeFormate(ByVal input_Time As String) As Boolean
        Dim returnBoolean As String = False
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            '檢查 Nothing
            If CheckIsNothing(input_Time) AndAlso input_Time <> "" Then

                Dim HourStr As String = ""
                Dim MinuteStr As String = ""
                Dim SecondStr As String = ""

                '根據長度設定 時 分 秒
                Select Case input_Time.Length
                    Case 4
                        HourStr = input_Time.Substring(0, 2).ToString
                        MinuteStr = input_Time.Substring(2, 2).ToString
                    Case 5
                        HourStr = input_Time.Substring(0, 2).ToString
                        MinuteStr = input_Time.Substring(3, 2).ToString
                    Case 8
                        HourStr = input_Time.Substring(0, 2).ToString
                        MinuteStr = input_Time.Substring(3, 2).ToString
                        SecondStr = input_Time.Substring(6, 2).ToString
                End Select

                '檢查是否為數字
                If CheckIsNumber(HourStr) And CheckIsNumber(MinuteStr) _
                    AndAlso HourStr <> "" AndAlso MinuteStr <> "" Then
                    '檢查 Hour < 24 Minute < 60
                    If CType(HourStr, Int32) < 24 And CType(HourStr, Int32) > -1 _
                        And CType(MinuteStr, Int32) < 60 And CType(MinuteStr, Int32) > -1 Then
                        returnBoolean = True
                    End If
                End If

                '8碼才檢查 秒
                If input_Time.Length = 8 Then
                    '檢查是否為數字
                    If CheckIsNumber(SecondStr) AndAlso SecondStr <> "" Then
                        '檢查 Second < ​​60
                        If CType(SecondStr, Int32) < 60 Then
                            returnBoolean = True
                        End If
                    End If
                End If
            End If

            Return returnBoolean
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 檢查是否為數字 - 字串
    '''
    ''' True : 正確 。
    '''
    ''' False : 錯誤，
    '''
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>by Sean.Lin on 2011-12-14</remarks>
    Public Shared Function CheckIsNumber(ByVal inputTime As String) As Boolean
        Dim returnBoolean As Boolean = True
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            '檢查 Notthing
            If CheckIsNothing(inputTime) Then
                '檢查是否為Empty String or 是否為數字
                If inputTime.Trim.Length > 0 AndAlso Not IsNumeric(inputTime.ToString.Trim) Then
                    '非數字
                    returnBoolean = False
                End If
            Else
                '是Nothing 不合理
                returnBoolean = False
            End If
            Return returnBoolean
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

    ''' <summary>
    ''' 檢查是否為日期，(yyyy-MM-dd,yyyy/MM/dd,yyyyyMMdd)
    '''
    ''' True : 正確 。
    '''
    ''' False : 錯誤，
    ''' </summary>
    ''' <returns>boolean</returns>
    ''' <remarks>by Sean.Lin on 2012-2-10</remarks>
    Public Shared Function CheckIsDate(ByVal inputValue As String) As Boolean
        Dim returnboolean As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Try
            If inputValue = "" Then
                returnboolean = False
            Else
                'yyyyyMMdd 要轉型
                If inputValue.Length = 8 Then
                    inputValue = inputValue.Substring(0, 4) & "-" & inputValue.Substring(4, 2) & "-" & inputValue.Substring(6, 2)
                End If

                '判斷是否可轉成日期
                returnboolean = IsDate(inputValue)
            End If
            Return returnboolean
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex, caller:=caller)
        End Try
    End Function

#End Region

#Region " 檢查 物件 是否為 DBNull "

    ''' <summary>
    ''' 檢查 物件 是否為 DBNull
    '''  True ：不是DBNull 
    '''  False： 是DBNull  
    ''' </summary>
    ''' <param name= "inputObj" > 傳入值 </param>
    ''' <returns>
    ''' </returns>
    ''' <remarks>by Sean.Lin on 2015-01-21 Copy From CNC </remarks>
    Public Shared Function checkIsDBNull(ByVal inputObj As Object) As Boolean
        Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()
        Dim return_Flag As Boolean = False
        Try
             
            '檢查 物件 是否為 DBNull
            If Not inputObj Is DBNull.Value Then
                return_Flag = True
            End If

            Return return_Flag
             
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢查 物件 是否為DBNull"}, caller:=caller)
        End Try


    End Function


#End Region

#Region " 檢查是否有權限 "

#Region " 檢查是否有權限，True：有；False：無 "

    ''' <summary>
    ''' 檢查是否有權限，True：有；False：無
    ''' </summary>
    ''' <param name="authorityName" >權限(XXX_User)，判斷會統一轉成大寫判斷</param>
    ''' <returns>boolean</returns>
    ''' <remarks>by Sean.Lin on 2015-10-23</remarks>
    Public Shared Function CheckHasAuthority(ByVal authorityName As String) As Boolean

        Dim returnboolean As Boolean

        Try

            '登入者的權限
            Dim menberList As String() = AppContext.userProfile.userMemberOf.Split(",")

            For Each strMenber As String In menberList

                '判斷 登入者的權限 是否包含 傳入的權限
                If strMenber.ToString.ToUpper.Contains(authorityName.ToString.ToUpper) Then

                    returnboolean = True

                End If

            Next


            Return returnboolean

            '使用到WCF服務的時候必須要抓取 FaultException 
        Catch cmex As CommonException
            Throw cmex
            Return False
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢查是否有權限，True：有；False：無"})
            Return False
        End Try

    End Function

#End Region

#Region " 檢查是否有權限，True：有；False：無 "

    ''' <summary>
    ''' 檢查是否有權限，True：有；False：無
    ''' </summary>
    ''' <param name="authorityNameArray" >權限(XXX_User)的集合，判斷會統一轉成大寫判斷</param>
    ''' <returns>boolean</returns>
    ''' <remarks>by Sean.Lin on 2015-10-23</remarks>
    Public Shared Function CheckHasAuthority(ByVal authorityNameArray As String()) As Boolean

        Dim returnboolean As Boolean

        Try

            For Each authorityName As String In authorityNameArray
                '判斷是否有包含其中一個權限
                If CheckHasAuthority(authorityName) = True Then
                    '有的直接 Return，不用一直判斷到最後
                    Return True
                End If
            Next

            Return returnboolean


        Catch cmex As CommonException
            Throw cmex
            Return False
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"檢查是否有權限，True：有；False：無"})
            Return False
        End Try

    End Function

#End Region

#End Region

End Class
