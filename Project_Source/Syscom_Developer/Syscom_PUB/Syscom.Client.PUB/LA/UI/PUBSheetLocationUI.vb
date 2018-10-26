'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBSheetLocationUI.vb
'*              Title:	表單位置檔
'*        Description:	表單位置檔
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Yunfei
'*        Create Date:	2011/03/29
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports Syscom.Client.Servicefactory
Imports System.Windows.Forms
Imports Syscom.Client.CMM
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports Syscom.Comm.LOG
Imports System.Text
Imports Syscom.Client.UCL
Public Class PUBSheetLocationUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI

    
    Private Sub PUBSheetLocationUI_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If UCLFormUtil.isResizeable = True Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
            UCLFormUtil.ReDrawForm(Me)
        End If
    End Sub
End Class