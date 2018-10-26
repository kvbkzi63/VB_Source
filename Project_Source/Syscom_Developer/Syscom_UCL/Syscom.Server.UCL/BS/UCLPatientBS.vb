Imports System.Data.SqlClient
Imports System.IO
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.BO
Imports System.String
Imports Syscom.Comm.Utility.StringUtil
Imports System.Text
Imports System.Transactions
Imports Syscom.Server.SQL
Imports Syscom.Server.PUB
Imports Syscom.Comm.Utility

Public Class UCLPatientBS



#Region "20090414 UCRChartNoBS 共用元件-病歷號查詢  by James"

    Public Function queryUclChartNoByKey(ByVal codeNo As String, ByVal codeType As String) As DataSet
        ' Dim PatientDS, PatientFlagDS, PatientDisDS, PatientSevereDisDS As DataSet

        Dim pub As PUBDelegate = PUBDelegate.getInstance()


        Return pub.queryPubChartNoByKey(codeNo, codeType)

        'PatientDS = pub.queryPubChartNoByKey(codeNo, codeType)
        'If codeType = "ChartNo" Then
        '    PatientFlagDS = pub.queryPubPatientFlagByKey(codeNo)
        '    PatientDisDS = pub.queryPubPatientDisabilityByKey(codeNo)
        '    PatientSevereDisDS = pub.queryPubPatientSevereDiseaseByKey(codeNo)

        '    If PatientFlagDS.Tables.Count > 0 Then
        '        PatientFlagDS.Tables(0).TableName = "Flag"
        '    End If

        '    If PatientDisDS.Tables.Count > 0 Then
        '        PatientDisDS.Tables(0).TableName = "Dis"
        '    End If

        '    If PatientSevereDisDS.Tables.Count > 0 Then
        '        PatientSevereDisDS.Tables(0).TableName = "SevereDis"
        '    End If

        '    Using ds As DataSet = New DataSet
        '        ds.Merge(PatientDS)
        '        ds.Merge(PatientFlagDS)
        '        ds.Merge(PatientDisDS)
        '        ds.Merge(PatientSevereDisDS)

        '        Return ds
        '    End Using

        'Else
        '    Return pub.queryPubChartNoByKey(codeNo, codeType)

        'End If

    End Function

#End Region
End Class
