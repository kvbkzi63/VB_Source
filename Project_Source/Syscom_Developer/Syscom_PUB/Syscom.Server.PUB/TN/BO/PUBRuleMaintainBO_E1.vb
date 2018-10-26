Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports System.Text

Public Class PUBRuleMaintainBO_E1
    Inherits PubRuleMaintainBO

    
#Region "########## getInstance ##########"

    Private Shared instance As PUBRuleMaintainBO_E1

    Public Overloads Shared Function getInstance() As PUBRuleMaintainBO_E1
        If instance Is Nothing Then
            instance = New PUBRuleMaintainBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region



End Class
