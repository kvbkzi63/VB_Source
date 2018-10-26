
'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PubPatientPastDiseaseHistoryBO_E2.vb
'*              Title:	表單維護
'*        Description:	表單維護-查詢，增加，修改，刪除，清除，另存新檔，明細維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Tor
'*        Create Date:	2009/10/12
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions
Imports Syscom.Comm.TableFactory
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.SQL
Imports System.Reflection

    Public Class PubPatientPastDiseaseHistoryBO_E2
    Inherits PubPatientPastDiseaseHistoryBO
    Dim tableName1 As String = "PUB_Patient_Past_Disease_History"
    Private Shared myInstance As PubPatientPastDiseaseHistoryBO_E2

    Public Overloads Function getInstance() As PubPatientPastDiseaseHistoryBO_E2
        If myInstance Is Nothing Then
            myInstance = New PubPatientPastDiseaseHistoryBO_E2()
        End If
        Return myInstance
    End Function

#Region "20091012 查詢    by Add Tor"

    Function queryPUBPatientPastDiseaseHistoryByCode_L(ByVal code As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()

            content.Append(" SELECT DH.Diease_Name FROM PUB_Patient_Past_Disease_History DH WHERE DH.Chart_No = '" & code.Trim & "' ")

            command.CommandText = content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
