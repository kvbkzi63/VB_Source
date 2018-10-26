'/*
'*****************************************************************************
'*
'*    Page/Class Name:  訊息代碼物件
'*              Title:	MessageValueObject
'*        Description:	訊息代碼與訊息內容清單
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-01-20
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-01-20
'*
'*****************************************************************************
'*/

Imports System.Text
Imports System.Reflection

Public Class MessageValueObject

    Private Shared msgTable As Hashtable = getMsgTable()
    Private Shared rptTable As Hashtable = getRptTable()

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 取得訊息代碼
    ''' </summary>
    ''' <param name="key">訊息代碼</param>
    ''' <param name="formatArg">額外的格式化參數字串</param>
    ''' <returns>訊息內容</returns>
    ''' <remarks></remarks>
    Public Shared Function getMessageValue(ByRef key As String, Optional ByRef formatArg As String() = Nothing) As String
        Try
            If key Is Nothing Or key Is DBNull.Value Then
                key = ""
            Else
                key = key.Trim
            End If
            Dim value As String = CType(msgTable.Item(key), String)
            Dim returnStr As String = ""

            If value = "" Then

                '取得Ex 發生那層的 Method Name，1 是 CommonException，2 是發生Ex 的那層Method
                Dim callerFromExMethod As MethodBase = New StackTrace().GetFrames(2).GetMethod()

                '取得Ex 路徑的完整名稱
                Dim exPathFullName As String = callerFromExMethod.DeclaringType.FullName

                Select Case AppConfigUtil.AppLanguage
                    Case AppConfigUtil.Language.TraditionalChinese
                        '
                        returnStr = "訊息代碼(" & key & ")無資料，" & exPathFullName
                    Case AppConfigUtil.Language.SimplifiedChinese
                        returnStr = "讯息代码(" & key & ")无资料，" & exPathFullName
                End Select
            Else
                returnStr = getFormatString(value, formatArg)
            End If

            Return returnStr
        Catch ex As Exception
            Return "取得訊息代碼發生錯誤(" & key & ")"
        End Try
    End Function

    ''' <summary>
    ''' 取得報表抬頭
    ''' </summary>
    ''' <param name="key">報表代碼</param>
    ''' <param name="formatArg">額外的格式化參數字串</param>
    ''' <returns>報表抬頭內容</returns>
    ''' <remarks></remarks>
    Public Shared Function getReportTitle(ByRef key As String, Optional ByRef formatArg As String() = Nothing) As String
        Try
            If key Is Nothing Or key Is DBNull.Value Then
                key = ""
            Else
                key = key.Trim
            End If
            Dim value As String = CType(rptTable.Item(key), String)
            Dim returnStr As String = ""

            If value = "" Then
                Select Case AppConfigUtil.AppLanguage
                    Case AppConfigUtil.Language.TraditionalChinese
                        returnStr = "報表抬頭代碼(" & key & ")無資料"
                    Case AppConfigUtil.Language.SimplifiedChinese
                        returnStr = "报表抬头代码(" & key & ")无资料"
                End Select
            Else
                returnStr = getFormatString(value, formatArg)
            End If

            Return returnStr
        Catch ex As Exception
            Return "取得報表抬頭發生錯誤(" & key & ")"
        End Try
    End Function

    ''' <summary>
    ''' 重新整理訊息內容
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub refreshMessageValue()
        msgTable = getMsgTable()
        rptTable = getRptTable()
    End Sub

    ''' <summary>
    ''' 格式化字串處理
    ''' </summary>
    ''' <param name="sourceString">原始字串</param>
    ''' <param name="formatArg">額外的格式化參數字串</param>
    ''' <returns>格式化字串</returns>
    ''' <remarks></remarks>
    Private Shared Function getFormatString(ByRef sourceString As String, ByRef formatArg As String()) As String
        If formatArg IsNot Nothing AndAlso formatArg.Length > 0 Then
            Try
                Dim sb As New StringBuilder
                Return sb.AppendFormat(sourceString, formatArg).ToString
            Catch ex As Exception
                Throw ex
            End Try
        Else
            Return sourceString
        End If
    End Function

End Class
