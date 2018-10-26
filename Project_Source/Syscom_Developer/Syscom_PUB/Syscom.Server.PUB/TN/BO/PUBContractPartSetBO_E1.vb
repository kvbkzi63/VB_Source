Imports System.Data.SqlClient
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
'
Imports System.Text
Public Class PUBContractPartSetBO_E1
    Inherits PubContractPartSetBO

#Region "########## getInstance ##########"
    Private Shared instance As PUBContractPartSetBO_E1
    Public Overloads Shared Function getInstance() As PUBContractPartSetBO_E1
        instance = New PUBContractPartSetBO_E1
        Return instance
    End Function
    Private Sub New()
    End Sub
#End Region

End Class
