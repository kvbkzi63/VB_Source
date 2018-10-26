'/*
'*****************************************************************************
'*
'*    Page/Class Name:  報表查詢匯出基礎畫面
'*              Title:	UclExportUI
'*        Description:	報表查詢匯出基礎畫面
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Sean.Lin  Copy from Will.Lin
'*        Create Date:	2015-12-03
'*      Last Modifier:	Sean.Lin  
'*   Last Modify Date:	2015-12-03
'*
'*****************************************************************************
'*/ 

Imports Syscom.Client.CMM
Imports Syscom.Comm.EXP



Public Class UclExportUI
    Inherits BaseFormUI

#Region "     變數宣告 "
    Private WithEvents eventManager As EventManager = EventManager.getInstance

#End Region

#Region "     屬性設定 "



#End Region

#Region "     主要功能 "

#Region "     外部參數傳遞 (提供其他UI呼叫、傳入參數) "


#Region "     初始化 - 顯示UI "

    ''' <summary>
    ''' 初始化 - 顯示UI
    ''' </summary> 
    ''' <remarks>by Sean.Lin on 2015-12-03</remarks>
    Public Sub showMe() Handles Me.Shown

        Try
            Me.IsActiveAutoSize = False
            '設定KeyPreview
            Me.KeyPreview = True



        Catch cmex As CommonException
        Catch ex As Exception
        End Try

    End Sub

#End Region

#End Region

#End Region

#Region "     內部功能 "

#Region "     初始化設定 "


#End Region

#End Region

#Region "     事件處理"
    Private Sub ReceiveReportID(ByVal tag As String, ByVal Report_Name As String) Handles eventManager.ReceiveReportName
        If tag <> Me.Tag Then Exit Sub
        Try
            '設定元件 Report Id
            ucl_report.initialize(tag.Split(",")(2))
            Me.Text = Report_Name
        Catch ex As Exception
            MessageHandling.ShowErrorMsg("CMMCMMB300", "UI名稱設定格式", ex.ToString)
        End Try
    End Sub



#End Region

#Region "     關閉事件管理員(EventManager) "

    ''' <summary>
    ''' 關閉事件管理員(EventManager)
    ''' </summary>
    ''' <remarks>by Sean.Lin on 2017-09-02</remarks>
    Private Sub UIDisposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        Try

            eventManager = Nothing
            ucl_report.Dispose()
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB993", ex)
        End Try

    End Sub

#End Region


End Class

