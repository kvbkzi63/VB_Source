'/*
'*****************************************************************************
'*
'*    Page/Class Name:  PubDiseaseIcd10pcsInsuMappingBO_E2對照檔
'*              Title:	PubDiseaseIcd10pcsInsuMappingBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Qun
'*        Create Date:	2016-09-9
'*      Last Modifier:	Qun
'*   Last Modify Date:	2016-09-9
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM


Public Class PubDiseaseIcd10pcsInsuMappingBO_E2
    Inherits PubDiseaseIcd10pcsInsuMappingBO

#Region "     使用的Instance宣告 "
    Private Shared myInstance As PubDiseaseIcd10pcsInsuMappingBO_E2
    Public Overloads Shared Function GetInstance() As PubDiseaseIcd10pcsInsuMappingBO_E2
        If myInstance Is Nothing Then
            myInstance = New PubDiseaseIcd10pcsInsuMappingBO_E2
        End If
        Return myInstance
    End Function
#End Region
#Region "依據健保碼內容查詢主手術碼設定下拉選單"
    Public Function queryICD10PCS_Code(ByVal strInsuCode As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder

            content.AppendLine("   select ICD10PCS_Code,disease_name " & vbCrLf)
            content.AppendLine("   from PUB_Disease_ICD10PCS_Insu_Mapping  " & vbCrLf)
            content.AppendLine("   WHERE  1 = 1 " & vbCrLf)

            If strInsuCode.Length > 0 Then
                content.AppendLine("  AND insu_code =@insu_code  ")
            End If

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@insu_code", strInsuCode)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region

End Class
