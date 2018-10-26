'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBDentalAddControlUI.vb
'*              Title:	牙科轉診加成控制檔
'*        Description:	牙科轉診加成控制檔
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	zxy
'*        Create Date:	2009/10/12
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

Public Class PUBDentalAddControlUI
    Inherits Syscom.Client.UCL.IUCLMaintainFormUI



    Private Sub PUBDentalAddControlUI_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If UCLFormUtil.isResizeable = True Then
            Me.AutoScaleMode = Windows.Forms.AutoScaleMode.None
            UCLFormUtil.ReDrawForm(Me)
        End If
    End Sub
End Class

