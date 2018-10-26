'/*
'*****************************************************************************
'*
'*    Page/Class Name:	ARMRPT000001Client.vb
'*              Title:	點擊次數查詢表
'*        Description:	點擊次數查詢表
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Rich
'*        Create Date:	2014/12/11
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/

Imports Microsoft.Office.Interop.Excel
Imports System.Drawing.Printing
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.RPT
Imports Syscom.Comm.EXP
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.RPT

Public Class ARMRPT000001Client
    Inherits IRPTPrintClient

    Private report As New ARMRPT000001

    ''' <summary>
    ''' 無取得印表機的附加條件，給"*"
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        printerCondition = "*"
    End Sub

    ''' <summary>
    ''' 建置報表
    ''' </summary>
    ''' <param name="data">資料</param>
    ''' <returns>報表物件</returns>
    ''' <remarks></remarks>
    Protected Overrides Function genReport(ByRef data As System.Data.DataSet) As Object
        Return report.genReport(data)
    End Function

    ''' <summary>
    ''' 列印報表
    ''' </summary>
    ''' <param name="rpt">報表物件</param>
    ''' <remarks></remarks>
    Protected Overrides Sub printReport(ByRef rpt As Object)
        Dim objApp As Microsoft.Office.Interop.Excel.Application = rpt
        If objApp Is Nothing Then
            '要先genReport
            Throw New RPTBusinessException("RPTCMMA006")
        Else
            Try
                rpt.Visible = False
                PrintOut(rpt, getPrinterName(report.reportId))
            Catch ex As Exception
                Throw New RPTBusinessException("RPTCMMA003")
            Finally
                FinishWork(objApp) '<--放在  Finally
            End Try
        End If
    End Sub

    ''' <summary>
    ''' 後端直接查詢資料
    ''' </summary>
    ''' <param name="queryCondition"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function queryRPTData(ByRef queryCondition() As Object) As System.Data.DataSet
        Dim returnDS As DataSet = New DataSet
        Return returnDS
    End Function

End Class
