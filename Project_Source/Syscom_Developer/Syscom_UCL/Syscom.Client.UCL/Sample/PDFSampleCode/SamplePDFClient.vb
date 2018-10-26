'/*
'*****************************************************************************
'*
'*    Page/Class Name:  SamplePDF
'*              Title:	範例報表
'*        Description:	PDF共用範例報表測試
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2016-06-24
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2016-06-24
'*
'*****************************************************************************
'*/


Imports Syscom.Client.Servicefactory
Imports Syscom.Client.CMM
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.DataSetUtil
Imports Syscom.Comm.Utility.CheckMethodUtil
Imports Syscom.Comm.EXP
Imports Syscom.Comm.BASE.HospConfigUtil

Imports System.Linq
Imports System.Text
Imports Syscom.Client.UCL
Imports Syscom.Comm.BASE
Imports Syscom.Client.RPT

Public Class SamplePDFClient
    Inherits Syscom.Client.RPT.IRPTPrintClient


#Region "     屬性宣告 "

#Region "     報表定義 "

    '定義報表
    Private report As SamplePDF = New SamplePDF()

#End Region

#Region "     使用的service宣告 "

    '定義使用的service介面
    '***********************請依系統需求做改變***********************
    'Dim pub As Syscom.Client.Servicefactory.IPubServiceManager

#End Region

#End Region

#Region "     內部功能 "

#Region "     PDF 指定或預設印表機的程式 "

    ''' <summary>
    ''' 指定印表機
    ''' 由外部給予取得印表機的附加條件，無特殊需求不做異動
    ''' </summary>
    ''' <param name="RptParam"></param>
    ''' <remarks> ByWill.Lin</remarks>
    Public Sub New(ByVal RptParam As Object)
        getReportInfo(RptParam)
    End Sub
    ''' <summary>
    ''' 取得報表資訊，無特殊需求不做異動
    ''' </summary>
    ''' <param name="RptParam"></param>
    ''' <remarks> ByWill.Lin</remarks>
    Private Overloads Sub getReportInfo(ByVal RptParam As Object())

        Try
            Dim rptInfo As ReportInfoClient = New ReportInfoClient(RptParam)
            report.reportId = rptInfo.reportId
            report.printerName = rptInfo.printerName
            report.reportTitle = rptInfo.reportTitle
            report.Hospital_Name = rptInfo.Hospital_Name
            report.Fax = rptInfo.Fax

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region "     PDF 建立報表 "

    ''' <summary>
    ''' 使用NIS.comm.rpt來建置報表
    ''' </summary>
    ''' <param name="data">資料</param>
    ''' <returns>報表物件</returns>
    ''' <remarks> ByWill.Lin</remarks>
    Protected Overrides Function genReport(ByRef data As System.Data.DataSet) As Object
        Dim stbDebug As New StringBuilder
        Try
            Return report.genReport(data)
        Catch ex As Exception
            Throw ex
        Finally
            Syscom.Client.CMM.LOGDelegate.getInstance.dbDebugMsg(stbDebug.ToString)
        End Try

    End Function

#End Region

#Region "     PDF 取得報表資料 "

    ''' <summary>
    ''' Call WCF 取得報表資料
    ''' queryCondition()
    ''' 報表條件由前端傳入
    ''' </summary>
    ''' <param name="queryCondition">查詢條件 Object Array</param>
    ''' <returns>報表資料 DataSet</returns>
    ''' <remarks> ByWill.Lin</remarks>
    Protected Overrides Function queryRPTData(ByRef queryCondition() As Object) As System.Data.DataSet
        Try


            Dim ds As New DataSet
            Dim dt As New DataTable

            Dim LoginUserDT As New DataTable
            '**************************↓傳至PDF主程式的DataSet組成邏輯區↓**************************

            '所有關於後端資料的查詢與取得後的邏輯處理

            'ds = pub.PubReportDescQueryByPK("") '<-----這只是範例，請自行修改

            dt.Columns.Add("Column1")
            dt.Columns.Add("Column2")
            dt.Columns.Add("Column3")
            dt.Columns.Add("Column4")
            dt.Columns.Add("Column5")
            dt.Columns.Add("Column6")

            For i As Int32 = 0 To 5
                dt.Rows.Add(i + 1, i + 2, i + 3, i + 4, i + 5, i + 6)
            Next

            '組合列印者的相關資訊
            LoginUserDT.TableName = "Login_User"
            LoginUserDT.Columns.Add("UserName")
            LoginUserDT.Rows.Add("測試人員")


            ds.Tables.Add(LoginUserDT)
            ds.Tables.Add(dt)
            '**************************↑傳至PDF主程式的DataSet組成邏輯區↑**************************

            Return ds

        Catch ex As Exception
            Syscom.Client.CMM.LOGDelegate.getInstance.dbErrorMsg(ex.ToString, ex)
            Throw ex
        End Try
    End Function

#End Region

#Region "     PDF 列印報表 "

    ''' <summary>
    ''' 列印報表
    ''' </summary>
    ''' <param name="rpt">報表物件</param>
    ''' <remarks> ByWill.Lin</remarks>
    Protected Overrides Sub printReport(ByRef rpt As Object)

        Try
            rpt.Visible = False
            PrintOut(rpt, getPrinterName(report.reportId))
        Catch ex As Exception
            Throw New RPTBusinessException("RPTCMMA003")
        End Try
    End Sub

#End Region

#End Region




End Class

