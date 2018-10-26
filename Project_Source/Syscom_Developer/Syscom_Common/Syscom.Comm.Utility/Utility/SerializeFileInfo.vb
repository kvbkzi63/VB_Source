<Serializable()> _
Public Class SerializeFileInfo
    Private globalFileName As String
    Private globalFileBuffer() As Byte

    Public Sub New(ByVal name As String, ByVal buffer() As Byte)
        globalFileName = name
        globalFileBuffer = buffer
    End Sub

    Public Property FileName() As String
        Get
            Return globalFileName
        End Get
        Set(ByVal value As String)
            globalFileName = value
        End Set
    End Property

    Public Property FileBuffer() As Byte()
        Get
            Return globalFileBuffer
        End Get
        Set(ByVal Value As Byte())
            globalFileBuffer = Value
        End Set
    End Property
End Class
