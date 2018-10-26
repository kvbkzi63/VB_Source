'/*
'*****************************************************************************
'*
'*    Page/Class Name:  圖表
'*              Title:	UCLChartUC
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Hsiao,Kaiwen
'*        Create Date:	2016-02-22
'*      Last Modifier:	Hsiao,Kaiwen
'*   Last Modify Date:	2016-02-22
'*
'*****************************************************************************
'*/

Imports Syscom.Comm.EXP
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.Utility.CheckMethodUtil

Imports Syscom.Client.CMM
Imports Syscom.Client.CMM.MessageHandling
Imports Syscom.Client.Servicefactory
Imports Syscom.Client.UCL
Imports Syscom.Client.UCL.UCLScreenUtil
Imports System.Windows.Forms.DataVisualization.Charting

Public Class UCLChartUC

#Region "     變數宣告 "

#Region "     使用者宣告　"

    '目前使用者的ID
    Private CurrentUserID As String = AppContext.userProfile.userId

    '目前使用者的院區
    Private CurrentUserSection As String = AppContext.userProfile.userSection

#End Region

#Region "     使用的Instance宣告 "

    Private Shared myInstance As UCLChartUC
    Public Shared Function GetInstance() As UCLChartUC
        If myInstance Is Nothing Then
            myInstance = New UCLChartUC
        End If
        Return myInstance
    End Function

#End Region

#End Region

#Region "     屬性設定 "

    '圖表Dataset設定
    Private DsChart As DataSet = Nothing

    Public Property SeleDsChart() As DataSet
        Get
            Return DsChart.Copy
        End Get
        Set(ByVal Value As DataSet)
            DsChart = Value.Copy
        End Set
    End Property


#End Region

#Region "     主要功能 "



#End Region

#Region "     事件集合 "

#Region "     繪製圖表 "
    ''' <summary>
    ''' 繪製圖表
    ''' </summary>
    ''' <param name="ds">要繪製成圖表的Dataset</param>
    ''' <param name="Int_ChartType">圖表型態 1.折線圖 2.長條圖</param>
    ''' <param name="ChartTitle">圖表標題</param>
    ''' <param name="ChartXname">圖表X軸名稱</param>
    ''' <param name="ChartYname">圖表Y軸名稱</param>
    ''' <param name="ValueShownAsLabel">是否在圖表上顯示資料</param>
    ''' <remarks></remarks>
    Public Sub GetDatasetToChart(ByVal ds As DataSet, ByVal Int_ChartType As Integer, ByVal ChartTitle As String, ByVal ChartXname As String, ByVal ChartYname As String, ByVal ValueShownAsLabel As Boolean)

        '設定圖表的標題
        UCLChart.Titles.Add(ChartTitle)

        Dim area As Object = UCLChart.ChartAreas(0)

        '宣告chart1的X軸值
        area.Axes(0).Title = ChartXname

        '宣告chart1的Y軸值
        UCLChart.ChartAreas(0).Axes(1).Title = ChartYname

        '判斷Dataset裡有幾組資料，並新增至圖表當中。並將其TableName轉換資料圖例的名稱
        For SeriesNum = 0 To ds.Tables.Count - 1
            UCLChart.Series.Add(ds.Tables(SeriesNum).TableName)
        Next


        '將資料塞入XY軸裡面
        Dim pointIndex1 As Integer

        For SeriesNum = 0 To ds.Tables.Count - 1

            For pointIndex1 = 0 To ds.Tables(SeriesNum).Rows.Count - 1

                'Series()用於設定比較的數據量
                UCLChart.Series(SeriesNum).Points.AddXY(String.Concat(ds.Tables(SeriesNum).Rows(pointIndex1).Item(0)), String.Concat(ds.Tables(SeriesNum).Rows(pointIndex1).Item(1)))

            Next


        Next


        ' 調整X、Y軸刻度線
        'chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        'chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False



        ' Set series chart type(判別圖形的型態)
        Select Case Int_ChartType
            Case 1
                For SeriesNum = 0 To ds.Tables.Count - 1
                    UCLChart.Series(SeriesNum).ChartType = SeriesChartType.Line
                Next

            Case 2
                For SeriesNum = 0 To ds.Tables.Count - 1
                    UCLChart.Series(SeriesNum).ChartType = SeriesChartType.Column
                Next

        End Select

        ' 是否在圖表上顯示資料
        For SeriesNum = 0 To ds.Tables.Count - 1
            UCLChart.Series(0).IsValueShownAsLabel = ValueShownAsLabel
        Next

        '圖例設定
        UCLChart.Legends.Add("Report Legend")
        UCLChart.Legends("Report Legend").Title = "報表圖例"
        For SeriesNum = 0 To ds.Tables.Count - 1
            UCLChart.Series(0).LegendText = ds.Tables(SeriesNum).TableName
        Next

    End Sub

#End Region

#End Region


End Class

