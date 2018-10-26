Imports Com.Syscom.WinFormsUI.Docking
Imports System.Reflection
Imports System.Xml

Public Module ModForm

#Region "Property"

    Private mUserInfo As String = ""
    Public Property UserInfo() As String
        Get
            Return mUserInfo
        End Get
        Set(ByVal Value As String)
            mUserInfo = StrConv(Value, VbStrConv.Narrow)
        End Set
    End Property

    Private mPasswdInfo As String = ""
    Public Property PasswdInfo() As String
        Get
            Return mPasswdInfo
        End Get
        Set(ByVal Value As String)
            mPasswdInfo = StrConv(Value, VbStrConv.Narrow)
        End Set
    End Property

    Private mUserInfoName As String = ""
    Public Property UserInfoName() As String
        Get
            Return mUserInfoName
        End Get
        Set(ByVal Value As String)
            mUserInfoName = Value
        End Set
    End Property

    '2011-12-07 ad by Lits For PCS
    Private mStationNo As String = ""
    Public Property StationNo() As String
        Get
            Return mStationNo
        End Get
        Set(ByVal Value As String)
            mStationNo = Value
        End Set
    End Property

    '2011-12-07 ad by Lits For PCS
    Private mTermNo As String = ""
    Public Property TermNo() As String
        Get
            Return mTermNo
        End Get
        Set(ByVal Value As String)
            mTermNo = Value
        End Set
    End Property

    '2010-06-22 Add By Alan
    Private mSystemNo As String = ""
    Public Property SystemNo() As String
        Get
            Return mSystemNo
        End Get
        Set(ByVal Value As String)
            mSystemNo = Value
        End Set
    End Property

    '2010-09-13 Add By Alan
    Private mChartNo As String = ""
    Public Property ChartNo() As String
        Get
            Return mChartNo
        End Get
        Set(ByVal Value As String)
            mChartNo = Value
        End Set
    End Property

    Private mDirectoryPath As String
    Public Property DirectoryPath() As String
        Get
            Return mDirectoryPath
        End Get
        Set(ByVal value As String)
            mDirectoryPath = value
        End Set
    End Property

#End Region

    Public Function getFormObjectByClass(ByVal clsTag As String) As DockContent
        Dim loadDLL As Reflection.Assembly = Nothing
        Dim obj As Object = Nothing
        If getDllName(clsTag) <> "" Then
            loadDLL = Assembly.LoadFrom(getDllName(clsTag))
            If loadDLL IsNot Nothing Then
                obj = loadDLL.CreateInstance(clsTag)
            End If
        End If
        Dim FormToShow As DockContent = CType(obj, DockContent)
        Return FormToShow
    End Function

    Public Function getFormObjectByDllAndClass(ByVal dllTag As String, ByVal clsTag As String) As DockContent
        Dim loadDLL As Reflection.Assembly
        Dim obj As Object = Nothing
        Try
            loadDLL = Assembly.LoadFrom("file:\\\" & DirectoryPath & "\" & dllTag)
            obj = loadDLL.CreateInstance(clsTag)
        Catch ex As Exception
            Return Nothing
        End Try

        Dim FormToShow As DockContent = CType(obj, DockContent)
        Return FormToShow
    End Function

    Public Function getDllName(ByVal className As String) As String
        Dim reader As New XmlTextReader("dllConfigPath.xml")
        Dim dllName As String = ""
        Dim xmlClassName As String = ""
        While reader.Read()
            dllName = reader.GetAttribute("dll")
            xmlClassName = reader.GetAttribute("class")
            If xmlClassName <> "" And xmlClassName = className Then
                If dllName <> "" Then
                    Return dllName
                End If
            End If
        End While
        Return ""
    End Function

End Module
