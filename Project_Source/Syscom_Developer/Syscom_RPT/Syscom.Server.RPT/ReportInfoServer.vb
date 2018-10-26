﻿
Public Class ReportInfoServer

#Region "   變數宣告"

    Private _reportId As String = ""            '報表代碼
    Private _reportTitle As String = ""         '報表抬頭
    Private _printerName As String = ""         '印表機名稱
    Private _printerType As String = ""         '報表型態
    Private _printerCond As String = ""         '報表條件
    Private _hospital_CH As String = ""         '醫院中文名稱
    Private _hospital_EN As String = ""         '醫院英文名稱

    Private _Language_Type_Id As String = ""   '中英文類別(1-中文; 2-英文)
    Private _Hospital_Code As String = ""       '醫院代碼
    Private _Effect_Date As String = ""         '生效日期
    Private _End_Date As String = ""            '結束日期
    Private _Hospital_Name As String = ""       '醫院名稱
    Private _Hospital_Short_Name As String = "" '醫院簡稱
    Private _Telephone As String = ""          '電話
    Private _Fax As String = ""                '傳真
    Private _Voice_Tel As String = ""          '電腦語音專線
    Private _Postal_Code As String = ""        '郵遞區號
    Private _Address As String = ""             '聯絡地址
    Private _Principal_Name As String = ""      '負責人姓名
    Private _Principal_Email As String = ""     '負責人Email
    Private _Hospital_Level_Id As String = ""   '醫療院所層級(A-醫學中心; B-區域醫院; C-地區醫院; D-基層院所)
    Private _URL As String = ""                 '網址
    Private _Unified_Business_No As String = "" '醫院統編

    Private _reportSize As Object = Nothing     '報表紙張大小
    Private _defaultFontSize As Integer         '報表預設字體大小
    Private _reportType As String = ""          '報表類型(預設為11)
    Private _reportTurning As Integer           '報表旋轉的方向(1:垂直; 2:水平)
    Private _printerFolder As String = ""       '印表機紙夾(A5-->固定為第二紙夾)

    Private _Alarm_Count As Integer = 0              '警示筆數

    Private _System_Code As String = ""     '系統別(ex. CNC、OMO....)
    Private _Report_Desc As String = ""     '描述說明

#End Region

#Region "阻止外部直接宣告"
    Public Sub New(ByRef parm() As Object)
        Info(parm)
    End Sub

    Public Sub Info(ByRef RptParam As Object())
        Dim pubDelgate As RPTDelegate = RPTDelegate.getInstance
        Try
            Dim ds As DataSet = pubDelgate.getReportInfo(RptParam(0), RptParam(1), RptParam(2))
            reportId = RptParam(0)
            PrinterType = RptParam(1)
            PrinterCond = RptParam(2)
            If ds.Tables("PUB_Print_Config").Rows.Count > 0 Then
                With ds.Tables("PUB_Print_Config").Rows(0)
                    reportTitle = .Item("Report_Name")
                    printerName = .Item("Printer_Name")
                    _System_Code = .Item("System_Code")
                    _Report_Desc = .Item("Report_Desc")
                End With


            End If

            If ds.Tables("PUB_Hospital").Rows.Count > 0 Then
                With ds.Tables("PUB_Hospital").Rows(0)
                    _Language_Type_Id = .Item("Language_Type_Id")
                    _Hospital_Code = .Item("Hospital_Code")
                    _Effect_Date = .Item("Effect_Date")
                    _End_Date = .Item("End_Date")
                    _Hospital_Name = .Item("Hospital_Name")
                    _Hospital_Short_Name = .Item("Hospital_Short_Name")
                    _Telephone = .Item("Telephone")
                    _Fax = .Item("Fax")
                    _Voice_Tel = .Item("Voice_Tel")
                    _Postal_Code = .Item("Postal_Code")
                    _Address = .Item("Address")
                    _Principal_Name = .Item("Principal_Name")
                    _Principal_Email = .Item("Principal_Email")
                    _Hospital_Level_Id = .Item("Hospital_Level_Id")
                    _URL = .Item("URL")
                    _Unified_Business_No = .Item("Unified_Business_No")


                End With
            End If
            If ds.Tables("PUB_Report_Alarm").Rows.Count > 0 Then
                _Alarm_Count = CInt(ds.Tables("PUB_Report_Alarm").Rows(0).Item("Rpt_Alarm_Count"))
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region

#Region "Property"

    ''' <summary>
    ''' 報表代碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property reportId() As String
        Get
            Return _reportId
        End Get
        Set(ByVal value As String)
            _reportId = value
        End Set
    End Property
    ''' <summary>
    ''' 印表機型態'1'=local列印  '2'=遠端列印
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PrinterType() As String
        Get
            Return _printerType
        End Get
        Set(ByVal value As String)
            _printerType = value
        End Set
    End Property
    ''' <summary>
    ''' 印表條件 Defaule='*'
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PrinterCond() As String
        Get
            Return _printerCond
        End Get
        Set(ByVal value As String)
            _printerCond = value
        End Set
    End Property

    ''' <summary>
    ''' 報表抬頭
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property reportTitle() As String
        Get
            Return _reportTitle
        End Get
        Set(ByVal value As String)
            _reportTitle = value
        End Set
    End Property

    ''' <summary>
    ''' 報表紙張大小
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property reportSize() As Object
        Get
            Return _reportSize
        End Get
        Set(ByVal value As Object)
            _reportSize = value
        End Set
    End Property

    ''' <summary>
    ''' 報表預設字體大小
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property defaultFontSize() As Integer
        Get
            Return _defaultFontSize
        End Get
        Set(ByVal value As Integer)
            _defaultFontSize = value
        End Set
    End Property

    ''' <summary>
    ''' 報表類型(預設為11)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property reportType() As String
        Get
            Return _reportType
        End Get
        Set(ByVal value As String)
            _reportType = value
        End Set
    End Property

    ''' <summary>
    ''' 報表旋轉的方向(1:垂直; 2:水平)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property reportTurning() As Integer
        Get
            Return _reportTurning
        End Get
        Set(ByVal value As Integer)
            _reportTurning = value
        End Set
    End Property

    ''' <summary>
    ''' 印表機紙夾(A5-->固定為第二紙夾)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property printerFolder() As String
        Get
            Return _printerFolder
        End Get
        Set(ByVal value As String)
            _printerFolder = value
        End Set
    End Property
    ''' <summary>
    ''' 印表機名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property printerName() As String
        Get
            Return _printerName
        End Get
        Set(ByVal value As String)
            _printerName = value
        End Set
    End Property
    ''' <summary>
    ''' 醫院中文名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property hospital_CH() As String
        Get
            Return _hospital_CH
        End Get
        Set(ByVal value As String)
            _hospital_CH = value
        End Set
    End Property
    ''' <summary>
    ''' 醫院英文名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property hospital_EN() As String
        Get
            Return _hospital_EN
        End Get
        Set(ByVal value As String)
            _hospital_EN = value
        End Set
    End Property
    ''' <summary>
    ''' 中英文類別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Language_Type_Id() As String
        Get
            Return _Language_Type_Id
        End Get
        Set(ByVal value As String)
            _Language_Type_Id = value
        End Set
    End Property
    ''' <summary>
    ''' 醫院代碼
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Hospital_Code() As String
        Get
            Return _Hospital_Code
        End Get
        Set(ByVal value As String)
            _Hospital_Code = value
        End Set
    End Property
    ''' <summary>
    ''' 生效日期
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Effect_Date() As String
        Get
            Return _Effect_Date
        End Get
        Set(ByVal value As String)
            _Effect_Date = value
        End Set
    End Property
    ''' <summary>
    ''' 結束日期
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property End_Date() As String
        Get
            Return _End_Date
        End Get
        Set(ByVal value As String)
            _End_Date = value
        End Set
    End Property
    ''' <summary>
    ''' 醫院名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Hospital_Name() As String
        Get
            Return _Hospital_Name
        End Get
        Set(ByVal value As String)
            _Hospital_Name = value
        End Set
    End Property
    ''' <summary>
    ''' 醫院簡稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Hospital_Short_Name() As String
        Get
            Return _Hospital_Short_Name
        End Get
        Set(ByVal value As String)
            _Hospital_Short_Name = value
        End Set
    End Property
    ''' <summary>
    ''' 電話
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Telephone() As String
        Get
            Return _Telephone
        End Get
        Set(ByVal value As String)
            _Telephone = value
        End Set
    End Property
    ''' <summary>
    ''' 傳真
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal value As String)
            _Fax = value
        End Set
    End Property
    ''' <summary>
    ''' 電腦語音專線
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Voice_Tel() As String
        Get
            Return _Voice_Tel
        End Get
        Set(ByVal value As String)
            _Voice_Tel = value
        End Set
    End Property
    ''' <summary>
    ''' 郵遞區號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Postal_Code() As String
        Get
            Return _Postal_Code
        End Get
        Set(ByVal value As String)
            _Postal_Code = value
        End Set
    End Property
    ''' <summary>
    ''' 聯絡地址
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property
    ''' <summary>
    ''' 負責人姓名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Principal_Name() As String
        Get
            Return _Principal_Name
        End Get
        Set(ByVal value As String)
            _Principal_Name = value
        End Set
    End Property
    ''' <summary>
    ''' 負責人Email
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Principal_Email() As String
        Get
            Return _Principal_Email
        End Get
        Set(ByVal value As String)
            _Principal_Email = value
        End Set
    End Property
    ''' <summary>
    ''' 醫療院所層級
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Hospital_Level_Id() As String
        Get
            Return _Hospital_Level_Id
        End Get
        Set(ByVal value As String)
            _Hospital_Level_Id = value
        End Set
    End Property
    ''' <summary>
    ''' 網址
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property URL() As String
        Get
            Return _URL
        End Get
        Set(ByVal value As String)
            _URL = value
        End Set
    End Property
    ''' <summary>
    ''' 醫院統編
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Unified_Business_No() As String
        Get
            Return _Unified_Business_No
        End Get
        Set(ByVal value As String)
            _Unified_Business_No = value
        End Set
    End Property

    ''' <summary>
    ''' 系統別(Ex:CNC、OMO....)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property System_Code() As String
        Get
            Return _System_Code
        End Get
        Set(ByVal value As String)
            _System_Code = value
        End Set
    End Property

    ''' <summary>
    ''' 描述說明
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Report_Desc() As String
        Get
            Return _Report_Desc
        End Get
        Set(ByVal value As String)
            _Report_Desc = value
        End Set
    End Property



#End Region


End Class
