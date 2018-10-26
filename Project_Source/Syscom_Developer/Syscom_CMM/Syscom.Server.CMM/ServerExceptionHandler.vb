'/*
'*****************************************************************************
'*
'*    Page/Class Name:  伺服器端例外處理程式
'*              Title:	ServerExceptionHandler
'*        Description:	伺服器端例外處理程式
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-02-17
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-02-17
'*
'*****************************************************************************
'*/

Imports System.ServiceModel
Imports Syscom.Comm.EXP
Imports Syscom.Comm.LOG

Public Class ServerExceptionHandler

    Protected Const defaultStyle As LogStyle = LogStyle.DB

    ''' <summary>
    ''' 阻止外部直接宣告建立
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()

    End Sub

    ''' <summary>
    ''' 紀錄日誌的方式
    ''' </summary>
    ''' <remarks></remarks>
    Enum LogStyle
        FILE
        DB
        BOTH
    End Enum

    ''' <summary>
    ''' 例外處理
    ''' </summary>
    ''' <param name="ex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProccessException(ByRef ex As CommonException, Optional ByVal style As LogStyle = defaultStyle) As FaultException
        Dim strStackTrace As String = ex.getOriginalException.ToString
        Try
            If style = LogStyle.DB Then
                LOGDelegate.getInstance.dbDelegateErrorMsg(ex.getCallerInfo, ex.getOriginalException.Message, ex.getOriginalException)
            ElseIf style = LogStyle.FILE Then
                LOGDelegate.getInstance.fileDelegateErrorMsg(ex.getCallerInfo, ex.getOriginalException.Message, ex.getOriginalException)
            ElseIf style = LogStyle.BOTH Then
                LOGDelegate.getInstance.fileDelegateErrorMsg(ex.getCallerInfo, ex.getOriginalException.Message, ex.getOriginalException)
                LOGDelegate.getInstance.dbDelegateErrorMsg(ex.getCallerInfo, ex.getOriginalException.Message, ex.getOriginalException)
            End If

            Throw ex.getOriginalException
        Catch bs_ex As BusinessException '自定義企業邏輯類　Exception 
            Return New FaultException(bs_ex.getErrorMessage, New FaultCode(bs_ex.getErrorCode, strStackTrace))
        Catch cm_ex As CommonException '自定義一般類　Exception     
            Return New FaultException(cm_ex.getErrorMessage, New FaultCode(cm_ex.getErrorCode, strStackTrace))
        Catch sql_ex As SqlClient.SqlException 'SqlException
            '這裡可以再對SqlException做出更多error code分類，然後個別處理       
            Dim sqlMsg As String = "SQL 錯誤代碼(" & sql_ex.Number & ")、訊息(" & sql_ex.Message & ")"
            Select Case (sql_ex.Number)
                Case 2627 '資料庫處理失敗(重複的索引鍵) constraint   
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA008", strStackTrace))
                Case 2601 '資料庫處理失敗(重複的索引鍵) index
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA002", strStackTrace))
                Case 515 '資料庫處理失敗(無法插入 NULL 值到 NOT NULL欄位)
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA003", strStackTrace))
                Case 208 '資料庫處理失敗(無效的物件名稱)
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA004", strStackTrace))
                Case 4060 '錯誤的資料庫
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA005", strStackTrace))
                Case 18456 '資料庫登入失敗
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA006", strStackTrace))
                Case 547 '外部索引鍵錯誤    
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA007", strStackTrace))
                Case 10065 '傳送要求至伺服器時發生傳輸層級的錯誤(遠端主機已強制關閉一個現存的連線)
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA011", strStackTrace))
                Case Else '未歸類的ＳＱＬ例外
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA001", strStackTrace))
            End Select
        Catch io_ex As IO.IOException 'IO Exception    
            Return New FaultException(io_ex.GetBaseException.Message, New FaultCode("NIOCMMF001", strStackTrace))
        Catch undefined_ex As Exception '未處理到的Exception 
            Return New FaultException(undefined_ex.Message, New FaultCode("SYSCMMA001", strStackTrace))
        End Try
    End Function

    ''' <summary>
    ''' 針對 Aspx 的例外處理
    ''' </summary>
    ''' <param name="ex"></param>
    ''' <param name="style"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ProccessExceptionForAspx(ByRef ex As CommonException, Optional ByVal style As LogStyle = defaultStyle) As FaultException
        Dim strStackTrace As String = ex.getOriginalException.ToString
        Try
            If style = LogStyle.DB Then
                LOGDelegate.getInstance.dbDelegateErrorMsg(ex.getCallerInfo, ex.getOriginalException.Message, ex.getOriginalException)
            ElseIf style = LogStyle.FILE Then
                LOGDelegate.getInstance.fileDelegateErrorMsg(ex.getCallerInfo, ex.getOriginalException.Message, ex.getOriginalException)
            ElseIf style = LogStyle.BOTH Then
                LOGDelegate.getInstance.fileDelegateErrorMsg(ex.getCallerInfo, ex.getOriginalException.Message, ex.getOriginalException)
                LOGDelegate.getInstance.dbDelegateErrorMsg(ex.getCallerInfo, ex.getOriginalException.Message, ex.getOriginalException)
            End If

            Throw ex.getOriginalException
        Catch bs_ex As BusinessException '自定義企業邏輯類　Exception 
            Return New FaultException(bs_ex.getErrorMessage, New FaultCode(bs_ex.getErrorCode, strStackTrace))
        Catch cm_ex As CommonException '自定義一般類　Exception     
            Return New FaultException(cm_ex.getErrorMessage, New FaultCode(cm_ex.getErrorCode, strStackTrace))
        Catch sql_ex As SqlClient.SqlException 'SqlException
            '這裡可以再對SqlException做出更多error code分類，然後個別處理       
            Dim sqlMsg As String = "SQL 錯誤代碼(" & sql_ex.Number & ")、訊息(" & sql_ex.Message & ")"
            Select Case (sql_ex.Number)
                Case 2627 '資料庫處理失敗(重複的索引鍵) constraint   
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA008", strStackTrace))
                Case 2601 '資料庫處理失敗(重複的索引鍵) index
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA002", strStackTrace))
                Case 515 '資料庫處理失敗(無法插入 NULL 值到 NOT NULL欄位)
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA003", strStackTrace))
                Case 208 '資料庫處理失敗(無效的物件名稱)
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA004", strStackTrace))
                Case 4060 '錯誤的資料庫
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA005", strStackTrace))
                Case 18456 '資料庫登入失敗
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA006", strStackTrace))
                Case 547 '外部索引鍵錯誤    
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA007", strStackTrace))
                Case 10065 '傳送要求至伺服器時發生傳輸層級的錯誤(遠端主機已強制關閉一個現存的連線)
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA011", strStackTrace))
                Case Else '未歸類的ＳＱＬ例外
                    Return New FaultException(sqlMsg, New FaultCode("SQLCMMA001", strStackTrace))
            End Select
        Catch io_ex As IO.IOException 'IO Exception    
            Return New FaultException(io_ex.GetBaseException.Message, New FaultCode("NIOCMMF001", strStackTrace))
        Catch undefined_ex As Exception '未處理到的Exception 
            Return New FaultException(undefined_ex.Message, New FaultCode("SYSCMMA001", strStackTrace))
        End Try
    End Function

End Class
