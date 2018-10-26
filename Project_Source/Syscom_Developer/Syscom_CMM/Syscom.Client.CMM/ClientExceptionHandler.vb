'/*
'*****************************************************************************
'*
'*    Page/Class Name:  用戶端例外處理程式
'*              Title:	ClientExceptionHandler
'*        Description:	用戶端例外處理程式
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-02-17
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-02-17
'*
'*****************************************************************************
'*/

Imports Syscom.Client.Servicefactory
Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports System.ServiceModel
Imports System.Reflection

Public Class ClientExceptionHandler

    ''' <summary>
    ''' 阻止外部直接宣告建立
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()

    End Sub

    ''' <summary>
    ''' 例外處理
    ''' </summary>
    ''' <param name="ex"></param>
    ''' <remarks></remarks>
    Public Shared Sub ProccessException(ByRef ex As Exception, Optional ByVal caller As MethodBase = Nothing)

        '取得呼叫程式資訊
        Dim strStackTrace As String = ""
        If TypeOf ex Is CommonException Then
            strStackTrace = CType(ex, CommonException).getOriginalException.ToString
            If caller Is Nothing Then
                caller = CType(ex, CommonException).getCallerInfo
            End If
        Else
            strStackTrace = ex.ToString
            If caller Is Nothing Then
                caller = New StackTrace().GetFrames(1).GetMethod()
            End If
        End If

        Try
            '紀錄前端錯誤到後端資料庫
            Throw ex
        Catch wcf_fau_ex As FaultException 'WCF unrecognized faults
            MessageHandling.ShowErrorMsgForWCF(wcf_fau_ex.Code.Name, wcf_fau_ex.Message, wcf_fau_ex.Code.Namespace, caller, False)
        Catch wcf_cmu_ex As CommunicationException 'WCF Standard communication fault
            MessageHandling.ShowErrorMsg("SYSWCFA002", "", strStackTrace, caller)
        Catch bs_ex As BusinessException '自定義企業邏輯類　Exception
            LOGDelegate.getInstance.dbClientErrorMsg(Comm.LOG.LOGDelegate.LogLevel.ERR, caller.DeclaringType.FullName, caller.Name, "{" & AppContext.userProfile.userId & "} {" & Environment.MachineName & "} {" & AppContext.userProfile.userIP & "} " & strStackTrace)
            MessageHandling.ShowErrorMsg(bs_ex.getErrorCode, bs_ex.getErrorCodeArg, strStackTrace, caller)
        Catch cm_ex As CommonException '自定義一般類　Exception
            LOGDelegate.getInstance.dbClientErrorMsg(Comm.LOG.LOGDelegate.LogLevel.ERR, caller.DeclaringType.FullName, caller.Name, "{" & AppContext.userProfile.userId & "} {" & Environment.MachineName & "} {" & AppContext.userProfile.userIP & "} " & strStackTrace)
            MessageHandling.ShowErrorMsg(cm_ex.getErrorCode, cm_ex.getErrorCodeArg, strStackTrace, caller)
        Catch io_ex As IO.IOException 'IO Exception  
            LOGDelegate.getInstance.dbClientErrorMsg(Comm.LOG.LOGDelegate.LogLevel.ERR, caller.DeclaringType.FullName, caller.Name, "{" & AppContext.userProfile.userId & "} {" & Environment.MachineName & "} {" & AppContext.userProfile.userIP & "} " & strStackTrace)
            MessageHandling.ShowErrorMsg("NIOCMMF001", io_ex.Message, strStackTrace, caller)
        Catch undefined_ex As Exception '未處理到的Exception 
            LOGDelegate.getInstance.dbClientErrorMsg(Comm.LOG.LOGDelegate.LogLevel.ERR, caller.DeclaringType.FullName, caller.Name, "{" & AppContext.userProfile.userId & "} {" & Environment.MachineName & "} {" & AppContext.userProfile.userIP & "} " & strStackTrace)
            'MessageHandling.ShowErrorMsg("SYSCMMA001", undefined_ex.Message, strStackTrace, caller)
            MessageHandling.ShowErrorMsg("CMMCMMB300", undefined_ex.Message, strStackTrace, caller)
        End Try
    End Sub

End Class
