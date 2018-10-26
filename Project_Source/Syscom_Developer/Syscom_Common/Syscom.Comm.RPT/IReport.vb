'/*
'*****************************************************************************
'*
'*    Page/Class Name:  報表抽象類別
'*              Title:	IReport
'*        Description:	報表抽象類別，為所有 Common 中報表類別提供基底內容
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Rich, Chuang
'*        Create Date:	2014-03-10
'*      Last Modifier:	Rich, Chuang
'*   Last Modify Date:	2014-03-10
'*
'*****************************************************************************
'*/

Imports System.Text
''' <summary>
''' 報表抽象類別，為所有 Common 中報表類別提供基底內容
''' </summary>
''' <remarks></remarks>
Public MustInherit Class IReport

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

    Private _alarm_Count As Integer = 0          '警示筆數

    Private _System_Code As String = ""     '系統別(ex. CNC、OMO....)
    Private _Report_Desc As String = ""     '描述說明

    ''' <summary>
    ''' 回傳報表檔案的第一行資料 (Txt, Rtf)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' 印表機名稱;紙張大小;預設字體大小;報表類型;報表旋轉方向;印表機紙夾
    ''' </remarks>
    Public Overridable Function getReportFileTitle() As String
        Try
            Dim report_data As StringBuilder = New StringBuilder
            report_data.Append(";").Append(_reportSize).Append(";").Append(_defaultFontSize).Append(";").Append(_reportType).Append(";").Append(_reportTurning).Append(";").Append(_printerFolder).Append(vbCrLf)
            Return report_data.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 產出報表
    ''' </summary>
    ''' <param name="data">報表資料</param>
    ''' <returns>報表物件</returns>
    ''' <remarks></remarks>
    Public MustOverride Function genReport(ByRef data As DataSet) As Object

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
    ''' 警示筆數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Alarm_Count() As Integer
        Get
            Return _Alarm_Count
        End Get
        Set(ByVal value As Integer)
            _Alarm_Count = value
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
