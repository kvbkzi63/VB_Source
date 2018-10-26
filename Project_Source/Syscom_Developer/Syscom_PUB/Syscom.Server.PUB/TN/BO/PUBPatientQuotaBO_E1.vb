Imports System.Data.SqlClient
'
'
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
'
Imports System.Text

 
Public Class PUBPatientQuotaBO_E1
    Inherits PubPatientQuotaBO
    Protected tableName1 As String = "PUB_Patient_Quota"

    Private Shared instance As PUBPatientQuotaBO_E1

    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

    Public Shared Shadows Function getInstance() As PUBPatientQuotaBO_E1
        instance = New PUBPatientQuotaBO_E1
        Return instance

    End Function

 
End Class
