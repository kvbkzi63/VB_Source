Public Class DynamicClass
    'Description：顯示在組合框中的窗體說明。
    'Location：窗體所在的 DLL 的文件名。
    'Type：窗體的 .NET 類型名稱（例如，PatientBase.DepBase）。
    Dim msLocation As String
    Dim msType As String
    Dim msDescription As String

    Public Sub New(ByVal sLocation As String, _
    ByVal sDescription As String, _
    ByVal sType As String)
        Me.Location = sLocation
        Me.Description = sDescription
        Me.Type = sType
    End Sub

    Public Property Location() As String
        Get
            Return msLocation
        End Get
        Set(ByVal Value As String)
            msLocation = Value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return msType
        End Get
        Set(ByVal Value As String)
            msType = Value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return msDescription
        End Get
        Set(ByVal Value As String)
            msDescription = Value
        End Set
    End Property

    Public ReadOnly Property Reference() As Object
        Get
            Return Me
        End Get
    End Property
End Class
