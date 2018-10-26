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


Public Class UCLIdentityBS
    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

    Public Function queryUclIdentityInitial(Optional ByVal inSourceType As String = "O") As System.Data.DataSet

        Dim ReturnDS As New DataSet
        Dim pub As PUBDelegate = PUBDelegate.getInstance
        Dim MainIdDS, SubIdDS, DisIdDS, ContractDS As New DataSet

        Try

            '身份1
            MainIdDS = pub.queryPUBSysCodebyTypeId("18")
            If MainIdDS.Tables.Count > 0 Then
                MainIdDS.Tables(0).TableName = "MainId"
            End If

            '身份2
            SubIdDS = pub.queryPUBSubIdentityBySourceType(inSourceType)
            If SubIdDS.Tables.Count > 0 Then
                SubIdDS.Tables(0).TableName = "SubId"
            End If

            '優待身份
            DisIdDS = pub.queryPUBDisIdentityAll()
            If DisIdDS.Tables.Count > 0 Then
                DisIdDS.Tables(0).TableName = "DisId"
            End If

            '合約
            ContractDS = pub.queryPUBContractAll()
            If ContractDS.Tables.Count > 0 Then
                ContractDS.Tables(0).TableName = "Contract"
            End If

            '不可轉健保的身份二
            '讀Config "OPC_No_Nhi"
            Dim cfgNoNhiDT As DataTable = pub.queryPUBConfigWhereConfigNameIn("'OPC_No_Nhi'").Tables(0).Copy
            cfgNoNhiDT.TableName = "cfgNoNhiDT"


            '看診目的
            'Using ds As DataSet = pub.queryPUBSysCodebyTypeId("20")
            '    If ds.Tables.Count > 0 Then
            '        ds.Tables(0).TableName = "MedicalTypeIdDT"
            '        ReturnDS.Tables.Add(ds.Tables(0).Copy)
            '    End If
            'End Using

            '部負
            Using dt As DataTable = PUBDelegate.getInstance.getPubPartComboBoxValueTable()
                dt.TableName = "PubPartDT"
                ReturnDS.Tables.Add(dt.Copy)
            End Using

            '看診目的的預設控制
            Dim medicalSQL As String = "select *  from PUB_Medical_Type where dc = 'N' order by IPD_Sort "
            Using dt As DataTable = PubMedicalTypeBO.GetInstance.dynamicQuery(medicalSQL).Tables(0).Copy
                dt.TableName = "PUBMedicalTypeDT"
                ReturnDS.Tables.Add(dt.Copy)
            End Using

            '案件類別
            Using dt As DataTable = pub.queryPUBSysCodebyTypeId("504").Tables(0).Copy
                dt.TableName = "CaseTypeIdDT"
                ReturnDS.Tables.Add(dt.Copy)
            End Using


            ReturnDS.Merge(MainIdDS)
            ReturnDS.Merge(SubIdDS)
            ReturnDS.Merge(DisIdDS)
            ReturnDS.Merge(ContractDS)
            ReturnDS.Tables.Add(cfgNoNhiDT)

            Return ReturnDS

        Catch ex As Exception

            Throw ex
        Finally
            If (MainIdDS IsNot Nothing) Then MainIdDS.Dispose()
            If (SubIdDS IsNot Nothing) Then SubIdDS.Dispose()
            If (DisIdDS IsNot Nothing) Then DisIdDS.Dispose()
            If (ContractDS IsNot Nothing) Then ContractDS.Dispose()

        End Try
    End Function

    

End Class
