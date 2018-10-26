Imports System.Reflection
Imports System.Xml
Imports System.IO

'/*
'*****************************************************************************
'*
'*    Page/Class Name:  記錄 對外連結網址 的設定值
'*              Title:	WebConfigUtil
'*        Description:	記錄 醫院 的設定值，以處理連結的設定
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	LITS
'*        Create Date:	2015-07-30
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
''' <summary>
''' 對外連結網址設定檔
''' </summary>
''' <remarks>回傳網址</remarks>
Public Class WebConfigUtil
    Private Shared WebConfigUtil As New WebConfigUtil

#Region "   變數宣告"

    Private Shared _LISWeb As String
    Private Shared _PACSWeb As String
    Private Shared _EMRWeb As String
    Private Shared _OhmReportPrintWeb As String
    Private Shared _Prescription135Web As String
    Private Shared _PCSBatchLv1Web As String

#End Region


    ''' <summary>
    ''' 阻止外部直接宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
        createDaemons()
    End Sub
    ''' <summary>
    ''' 初始化變數
    ''' </summary>
    ''' <remarks>取得設定檔資料</remarks>
    Private Sub createDaemons()
        Try
            Dim doXmlDocument As New XmlDocument
            Dim ftpXMLConfigs As XmlNodeList = Nothing
            Dim xmlFile As FileInfo = New FileInfo(New FileInfo(System.Reflection.Assembly.GetExecutingAssembly.Location()).DirectoryName & "\WebConfig.xml")

            doXmlDocument.Load(xmlFile.FullName)
            Dim root As XmlNode = doXmlDocument.SelectSingleNode("root")
            ftpXMLConfigs = root.SelectNodes("HOSP")

            For Each dm As XmlNode In ftpXMLConfigs

                _LISWeb = (dm.SelectSingleNode("LISWeb").InnerText)
                _PACSWeb = (dm.SelectSingleNode("PACSWeb").InnerText)
                _EMRWeb = (dm.SelectSingleNode("EMRWeb").InnerText)
                _OhmReportPrintWeb = (dm.SelectSingleNode("OhmReportPrintWeb").InnerText)
                _Prescription135Web = (dm.SelectSingleNode("Prescription135Web").InnerText)
                _PCSBatchLv1Web = (dm.SelectSingleNode("PCSBatchLv1").InnerText)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "屬性"
    ''' <summary>
    ''' LIS外部連結
    ''' </summary>
    ''' <value></value>
    ''' <returns>LIS網址</returns>
    ''' <remarks>回傳LIS 連結網址</remarks>
    Public Shared Property LISWeb() As String
        Get
            Return _LISWeb
        End Get
        Set(ByVal value As String)
            _LISWeb = value
        End Set
    End Property
    
    ''' <summary>
    ''' PACS外部連結
    ''' </summary>
    ''' <value></value>
    ''' <returns>PACS 連結網址</returns>
    ''' <remarks>回傳PACS 連結網址</remarks>
    Public Shared Property PACSWeb() As String
        Get
            Return _PACSWeb
        End Get
        Set(ByVal value As String)
            _PACSWeb = value
        End Set
    End Property

    ''' <summary>
    ''' EMR外部連結
    ''' </summary>
    ''' <value></value>
    ''' <returns>EMR 連結網址</returns>
    ''' <remarks>回傳EMR 連結網址</remarks>
    Public Shared Property EMRWeb() As String
        Get
            Return _EMRWeb
        End Get
        Set(ByVal value As String)
            _EMRWeb = value
        End Set
    End Property

    'Public Shared Property OhmReportPrintWeb() As String

    ''' <summary>
    ''' 健檢問卷調查網址
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property OhmReportPrintWeb() As String
        Get
            Return _OhmReportPrintWeb
        End Get
        Set(ByVal value As String)
            _OhmReportPrintWeb = value
        End Set
    End Property

    ''' <summary>
    ''' 藥品基本檔網址
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property Prescription135Web() As String
        Get
            Return _Prescription135Web
        End Get
        Set(ByVal value As String)
            _Prescription135Web = value
        End Set
    End Property

    ''' <summary>
    ''' 取得Batch網址
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property PCSBatchLv1Web() As String
        Get
            Return _PCSBatchLv1Web
        End Get
        Set(ByVal value As String)
            _PCSBatchLv1Web = value
        End Set
    End Property


#End Region

End Class

