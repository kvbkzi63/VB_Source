'/*
'*****************************************************************************
'*
'*    Page/Class Name:  訊息處理
'*              Title:	MessageHandling
'*        Description:	顯示訊息，包含錯誤、警告、疑問、一般提示四種訊息
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin
'*        Create Date:	2013-12-12
'*      Last Modifier:	Sean.Lin
'*   Last Modify Date:	2013-12-12
'*
'*****************************************************************************
'*/

Imports Syscom.Comm.BASE
Imports Syscom.Comm.LOG
Imports Syscom.Comm.Utility
Imports System.Windows.Forms
Imports System.Reflection

Public Class MessageHandling

    ''' <summary>
    ''' 阻止外部直接進行新建立的宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
    End Sub

#Region " 顯示錯誤訊息視窗"

    ''' <summary>
    ''' 顯示錯誤訊息視窗，單一訊息。
    ''' 
    ''' inMessage:訊息內容。
    ''' 
    ''' </summary>
    ''' <param name="inMessage" >訊息內容</param>
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Sub ShowErrorMsg(ByVal inMessage As String, Optional ByRef caller As MethodBase = Nothing, Optional ByVal doLog As Boolean = True)
        If caller Is Nothing Then
            caller = New StackTrace().GetFrames(1).GetMethod()
        End If
        Dim returnMessage As String = MessageValueObject.getMessageValue(inMessage)
        If returnMessage.Contains("{") Or returnMessage.Contains("}") Then
            '有對應到代碼，但缺少字串陣列
            ShowErrorMsg("CMMCMMB300", New String() {inMessage}, "", caller, doLog)
        ElseIf returnMessage.Contains("無資料") Then
            '沒有對應到代碼
            ShowErrorMsg("CMMCMMB300", New String() {returnMessage}, "", caller, doLog)
        Else
            '有對應到代碼，使用訊息代碼內容
            ShowErrorMsg(inMessage, New String() {}, "", caller, doLog)
        End If
    End Sub

    ''' <summary>
    ''' 顯示錯誤訊息視窗，單一訊息。
    ''' 
    ''' inErrorCode:訊息代碼。inMessage:訊息內容
    ''' 
    ''' </summary>
    ''' <param name="inErrorCode" >訊息代碼</param>
    ''' <param name="inMessage" >訊息內容</param>
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Sub ShowErrorMsg(ByVal inErrorCode As String, ByVal inMessage As String, Optional ByRef caller As MethodBase = Nothing, Optional ByVal doLog As Boolean = True)
        If caller Is Nothing Then
            caller = New StackTrace().GetFrames(1).GetMethod()
        End If
        ShowErrorMsg(inErrorCode, New String() {inMessage}, "", caller, doLog)
    End Sub

    ''' <summary>
    ''' 顯示錯誤訊息視窗，單一訊息。
    ''' 
    ''' inErrorCode:訊息代碼。inMessage:訊息內容。inDetail:Exception 的內容
    ''' 
    ''' </summary>
    ''' <param name="inErrorCode" >訊息代碼</param>
    ''' <param name="inMessage" >訊息內容</param>
    ''' <param name="inDetail" >Ex 的內容</param>
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Sub ShowErrorMsg(ByVal inErrorCode As String, ByVal inMessage As String, ByVal inDetail As String, Optional ByRef caller As MethodBase = Nothing, Optional ByVal doLog As Boolean = True)
        If caller Is Nothing Then
            caller = New StackTrace().GetFrames(1).GetMethod()
        End If
        ShowErrorMsg(inErrorCode, New String() {inMessage}, inDetail, caller, doLog)
    End Sub

    ''' <summary>
    ''' 顯示錯誤訊息視窗，多個訊息，EX:inMessage{0}不得小於inMessage{1}。
    ''' 
    ''' inErrorCode:訊息代碼。inMessage:訊息內容陣列。inDetail:Exception 的內容
    ''' 
    ''' </summary>
    ''' <param name="inErrorCode" >訊息代碼</param>
    ''' <param name="inMessage" >訊息內容陣列</param>
    ''' <param name="inDetail" >Ex 的內容</param>
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Sub ShowErrorMsg(ByVal inErrorCode As String, ByVal inMessage As String(), ByVal inDetail As String, Optional ByRef caller As MethodBase = Nothing, Optional ByVal doLog As Boolean = True)

        '自動儲存錯誤訊息至 Log
        If caller Is Nothing Then
            caller = New StackTrace().GetFrames(1).GetMethod()
        End If

        Dim gblMessage As String = ""
        If inMessage IsNot Nothing AndAlso inMessage.Length <> 0 Then
            gblMessage = MessageValueObject.getMessageValue(inErrorCode, inMessage)
        Else
            gblMessage = MessageValueObject.getMessageValue(inErrorCode)
        End If

        If doLog Then
            LOGDelegate.getInstance.fileDelegateErrorMsg(caller, gblMessage)
        End If

        If AppContext.userProfile.userName.ToLower <> "" AndAlso AppContext.userProfile.userName.ToLower <> "unknown" Then
            Dim mgr As EventManager = EventManager.getInstance '宣告EventManager
            mgr.RaiseShowErrorMsgForWCF(inErrorCode, gblMessage, inDetail)
        Else
            MessageBox.Show(gblMessage)
        End If
    End Sub

    ''' <summary>
    ''' 顯示錯誤訊息視窗，並自動儲存錯誤訊息至Client端 Log，多個訊息，EX:inMessage{0}不得小於inMessage{1}。(WCF專用)
    ''' 
    ''' inErrorCode:訊息代碼。inMessage:訊息內容。inDetail:Exception 的內容
    ''' 
    ''' </summary>
    ''' <param name="inErrorCode" >訊息代碼</param>
    ''' <param name="inMessage" >訊息內容</param>
    ''' <param name="inDetail" >Ex 的內容</param>
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Sub ShowErrorMsgForWCF(ByVal inErrorCode As String, ByVal inMessage As String, ByVal inDetail As String, Optional ByRef caller As MethodBase = Nothing, Optional ByVal doLog As Boolean = True)

        '自動儲存錯誤訊息至 Log
        If caller Is Nothing Then
            caller = New StackTrace().GetFrames(1).GetMethod()
        End If

        If doLog Then
            LOGDelegate.getInstance.fileDelegateErrorMsg(caller, inMessage)
        End If

        If AppContext.userProfile.userName.ToLower <> "" AndAlso AppContext.userProfile.userName.ToLower <> "unknown" Then
            Dim mgr As EventManager = EventManager.getInstance '宣告EventManager
            mgr.RaiseShowErrorMsgForWCF(inErrorCode, inMessage, inDetail)
        Else
            MessageBox.Show(inMessage)
        End If
    End Sub

#End Region

#Region " 顯示警告訊息視窗"

    ''' <summary>
    ''' 顯示警告訊息視窗，單一訊息。
    ''' 
    ''' inMessage:訊息內容 
    ''' 
    ''' </summary>
    ''' <param name="inMessage" >訊息內容</param>
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Sub ShowWarnMsg(ByVal inMessage As String)
        Dim returnMessage As String = MessageValueObject.getMessageValue(inMessage)
        If returnMessage.Contains("{") Or returnMessage.Contains("}") Then
            '有對應到代碼，但缺少字串陣列
            ShowWarnMsg("CMMCMMB300", New String() {inMessage})
        ElseIf returnMessage.Contains("無資料") Then
            '沒有對應到代碼
            ShowWarnMsg("CMMCMMB300", New String() {returnMessage})
        Else
            '有對應到代碼，使用訊息代碼內容
            ShowWarnMsg(inMessage, New String() {})
        End If
    End Sub

    ''' <summary>
    ''' 顯示警告訊息視窗，單一訊息。
    ''' 
    ''' inErrorCode:訊息代碼。inMessage:訊息內容。
    ''' 
    ''' </summary>
    ''' <param name="inErrorCode" >訊息代碼</param>
    ''' <param name="inMessage" >訊息內容陣列</param> 
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Sub ShowWarnMsg(ByVal inErrorCode As String, ByVal inMessage As String)
        ShowWarnMsg(inErrorCode, New String() {inMessage})
    End Sub

    ''' <summary>
    ''' 顯示警告訊息視窗，多個訊息，EX:inMessage{0}不得小於inMessage{1}。
    ''' 
    ''' inErrorCode:訊息代碼。inMessage:訊息內容陣列。
    ''' 
    ''' </summary>
    ''' <param name="inErrorCode" >訊息代碼</param>
    ''' <param name="inMessage" >訊息內容陣列</param> 
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Sub ShowWarnMsg(ByVal inErrorCode As String, ByVal inMessage As String())
        If AppContext.userProfile.userName.ToLower <> "" AndAlso AppContext.userProfile.userName.ToLower <> "unknown" Then
            Dim mgr As EventManager = EventManager.getInstance '宣告EventManager
            mgr.RaiseShowWarnMsg(inErrorCode, inMessage)
        Else
            Dim gblMessage As String
            If inMessage IsNot Nothing AndAlso inMessage.Length <> 0 Then
                gblMessage = MessageValueObject.getMessageValue(inErrorCode, inMessage)
            Else
                gblMessage = MessageValueObject.getMessageValue(inErrorCode)
            End If
            MessageBox.Show(gblMessage)
        End If
    End Sub

#End Region

#Region " 顯示疑問訊息視窗"

    ''' <summary>
    ''' 顯示疑問訊息視窗，單一訊息。
    ''' 
    ''' inMessage:訊息代碼。 
    ''' 
    ''' </summary>
    ''' <param name="inMessage" >訊息內容</param>
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Function ShowQuestionMsg(ByVal inMessage As String) As DialogResult
        Dim returnMessage As String = MessageValueObject.getMessageValue(inMessage)
        If returnMessage.Contains("{") Or returnMessage.Contains("}") Then
            '有對應到代碼，但缺少字串陣列
            Return ShowQuestionMsg("CMMCMMB300", New String() {inMessage})
        ElseIf returnMessage.Contains("無資料") Then
            '沒有對應到代碼
            Return ShowQuestionMsg("CMMCMMB300", New String() {returnMessage})
        Else
            '有對應到代碼，使用訊息代碼內容
            Return ShowQuestionMsg(inMessage, New String() {})
        End If
    End Function

    ''' <summary>
    ''' 顯示疑問訊息視窗，單一訊息。
    ''' 
    ''' inErrorCode:訊息代碼。inMessage:訊息內容。
    ''' 
    ''' </summary>
    ''' <param name="inErrorCode" >訊息代碼</param>
    ''' <param name="inMessage" >訊息內容陣列</param> 
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Function ShowQuestionMsg(ByVal inErrorCode As String, ByVal inMessage As String) As DialogResult
        Return ShowQuestionMsg(inErrorCode, New String() {inMessage})
    End Function

    ''' <summary>
    ''' 顯示疑問訊息視窗，多個訊息，EX:inMessage{0}不得小於inMessage{1}。
    ''' 
    ''' inErrorCode:訊息代碼。inMessage:訊息內容陣列。
    ''' 
    ''' </summary>
    ''' <param name="inErrorCode" >訊息代碼</param>
    ''' <param name="inMessage" >訊息內容陣列</param> 
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Function ShowQuestionMsg(ByVal inErrorCode As String, ByVal inMessage As String()) As DialogResult
        If inMessage IsNot Nothing AndAlso inMessage.Length <> 0 Then
            Return MessageBox.Show(MessageValueObject.getMessageValue(inErrorCode, inMessage), _
                        "訊息代碼：" & inErrorCode, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Else
            Return MessageBox.Show(MessageValueObject.getMessageValue(inErrorCode), _
                        "訊息代碼：" & inErrorCode, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End If
    End Function

#End Region

#Region "顯示一般訊息視窗(左下角訊息欄)"

    ''' <summary>
    ''' 顯示一般訊息於左下方訊息欄，單一訊息。
    ''' 
    ''' inMessage:訊息內容。
    ''' 
    ''' </summary> 
    ''' <param name="inMessage" >訊息內容陣列</param> 
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Sub ShowInfoMsg(ByVal inMessage As String)
        Dim returnMessage As String = MessageValueObject.getMessageValue(inMessage)
        If returnMessage.Contains("{") Or returnMessage.Contains("}") Then
            '有對應到代碼，但缺少字串陣列
            ShowInfoMsg("CMMCMMB300", New String() {inMessage})
        ElseIf returnMessage.Contains("無資料") Then
            '沒有對應到代碼
            ShowInfoMsg("CMMCMMB300", New String() {returnMessage})
        Else
            '有對應到代碼，使用訊息代碼內容
            ShowInfoMsg(inMessage, New String() {})
        End If
    End Sub

    ''' <summary>
    ''' 顯示一般訊息於左下方訊息欄，單一訊息。
    ''' 
    ''' inErrorCode:訊息代碼。inMessage:訊息內容。
    ''' 
    ''' </summary>
    ''' <param name="inErrorCode" >訊息代碼</param>
    ''' <param name="inMessage" >訊息內容陣列</param> 
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Sub ShowInfoMsg(ByVal inErrorCode As String, ByVal inMessage As String)
        ShowInfoMsg(inErrorCode, New String() {inMessage})
    End Sub

    ''' <summary>
    ''' 顯示一般訊息於左下方訊息欄，多個訊息，EX:inMessage{0}不得小於inMessage{1}。
    ''' 
    ''' inErrorCode:訊息代碼。inMessage:訊息內容陣列。
    ''' 
    ''' </summary>
    ''' <param name="inErrorCode" >訊息代碼</param>
    ''' <param name="inMessage" >訊息內容陣列</param> 
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Sub ShowInfoMsg(ByVal inErrorCode As String, ByVal inMessage As String())
        Try
            Dim pvtMessageStr As String

            If inMessage IsNot Nothing AndAlso inMessage.Length <> 0 Then
                pvtMessageStr = MessageValueObject.getMessageValue(inErrorCode, inMessage)
            Else
                pvtMessageStr = MessageValueObject.getMessageValue(inErrorCode)
            End If

            EventManager.getInstance.RaisDisplayStatusBar(pvtMessageStr)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 清除訊息欄。
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2013-7-22</remarks>
    Public Shared Sub ClearInfoMsg()
        EventManager.getInstance.RaisDisplayStatusBar("")
    End Sub

#End Region

#Region " 顯示一般訊息視窗"

    ''' <summary>
    ''' 顯示一般訊息，單一訊息。
    ''' 
    ''' inMessage:訊息內容。
    ''' 
    ''' </summary> 
    ''' <param name="inMessage" >訊息內容陣列</param> 
    ''' <remarks>by Charles.Chiou on 2016-7-05</remarks>
    Public Shared Sub ShowInfoMsgBox(ByVal inMessage As String)
        Dim returnMessage As String = MessageValueObject.getMessageValue(inMessage)
        If returnMessage.Contains("{") Or returnMessage.Contains("}") Then
            '有對應到代碼，但缺少字串陣列
            ShowInfoMsgBox("CMMCMMB300", New String() {inMessage})
        ElseIf returnMessage.Contains("無資料") Then
            '沒有對應到代碼
            ShowInfoMsgBox("CMMCMMB300", New String() {returnMessage})
        Else
            '有對應到代碼，使用訊息代碼內容
            ShowInfoMsgBox(inMessage, New String() {})
        End If
    End Sub

    ''' <summary>
    ''' 顯示一般訊息，單一訊息。
    ''' 
    ''' inErrorCode:訊息代碼。inMessage:訊息內容。
    ''' 
    ''' </summary>
    ''' <param name="inErrorCode" >訊息代碼</param>
    ''' <param name="inMessage" >訊息內容陣列</param> 
    ''' <remarks>by Charles.Chiou on 2016-7-05</remarks>
    Public Shared Sub ShowInfoMsgBox(ByVal inErrorCode As String, ByVal inMessage As String)
        ShowInfoMsgBox(inErrorCode, New String() {inMessage})
    End Sub


    ''' <summary>
    ''' 顯示一般訊息，多個訊息，EX:inMessage{0}不得小於inMessage{1}。
    ''' 
    ''' inErrorCode:訊息代碼。inMessage:訊息內容陣列。
    ''' 
    ''' </summary>
    ''' <param name="inErrorCode" >訊息代碼</param>
    ''' <param name="inMessage" >訊息內容陣列</param> 
    ''' <remarks>by Charles.Chiou on 2016-7-05</remarks>
    Public Shared Sub ShowInfoMsgBox(ByVal inErrorCode As String, ByVal inMessage As String())
        Try
            If AppContext.userProfile.userName.ToLower <> "" AndAlso AppContext.userProfile.userName.ToLower <> "unknown" Then
                Dim mgr As EventManager = EventManager.getInstance '宣告EventManager
                mgr.RaiseShowInfoMsg(inErrorCode, inMessage)
            Else
                Dim gblMessage As String
                If inMessage IsNot Nothing AndAlso inMessage.Length <> 0 Then
                    gblMessage = MessageValueObject.getMessageValue(inErrorCode, inMessage)
                Else
                    gblMessage = MessageValueObject.getMessageValue(inErrorCode)
                End If
                MessageBox.Show(gblMessage)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

    ''' <summary>
    ''' 取得 Method Base 相關資訊，根據判斷使用到的需求通常為 Shared 函式呼叫
    ''' 故取得前兩層呼叫函式基本資訊
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getMethodBase() As MethodBase
        Return New StackTrace().GetFrames(2).GetMethod()
    End Function

End Class
