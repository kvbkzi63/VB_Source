Public Class ServerUserProfile
    Inherits Syscom.Comm.Utility.UserProfile
    'Server 需要被複寫，所以開成 Overrides
    Public Overrides Property userIP() As String
        Get
            Return ip
        End Get
        Set(ByVal value As String)
            ip = value  'Server  端需要 set
        End Set
    End Property
End Class
