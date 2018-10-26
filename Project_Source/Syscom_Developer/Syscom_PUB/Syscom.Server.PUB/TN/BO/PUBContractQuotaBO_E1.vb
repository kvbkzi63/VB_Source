Imports System.Data.SqlClient
'
'
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
'
Imports System.Text

Public Class PUBContractQuotaBO_E1
    Inherits PubContractQuotaBO
 
    Private Shared instance As PUBContractQuotaBO_E1

    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

    Public Shared Shadows Function getInstance() As PUBContractQuotaBO_E1
        instance = New PUBContractQuotaBO_E1
        Return instance

    End Function
 

 
End Class
