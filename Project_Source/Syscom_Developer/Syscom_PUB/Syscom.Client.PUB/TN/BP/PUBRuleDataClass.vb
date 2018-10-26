Imports Microsoft.VisualBasic
Imports System
Imports System.Collections

Public Class PUBRuleDataClass
    Inherits ArrayList

    Public Sub New()

        Me.Add(New PUBCheckRuleObj(Nothing, Nothing, Nothing, Nothing, "", 1, "", "", "", "", "", "", "", "", False, False, False, "", False, False, False))

    End Sub

End Class
