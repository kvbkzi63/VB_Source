
'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBPostalCodeBO_E2.vb
'*              Title:	郵遞區號
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	pearl
'*        Create Date:	2011/03/07
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
Public Class PUBPostalCodeBO_E2
    Inherits PUBPostalCodeBO
    Private Shared myInstance As PUBPostalCodeBO_E2
    Public Overloads Shared Function GetInstance() As PUBPostalCodeBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPostalCodeBO_E2()
        End If
        Return myInstance
    End Function
  

#Region "郵遞區號查詢 add by pearl 20110307"
    ''' <summary>
    ''' 郵遞區號查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBPostalCodeByCond(ByVal strPostalCode As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" ").Append(" Select * ")
            content.Append(" ").Append(" From " & tableName)
            content.Append(" ").Append(" Where  1=1")
            If strPostalCode <> "" Then
                content.Append(" ").Append("and Postal_Code = '" & strPostalCode & "' ")
            End If

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

#Region "縣市鎮及區查詢 add by mark zhang 20111009"
    ''' <summary>
    ''' 縣市鎮查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBPostalCodeForCountryName() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" ").Append(" Select distinct county_name")
            content.Append(" ").Append(" From " & tableName)

            command.CommandText = content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                'adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 區查詢
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBPostalCodeForTownName(ByVal strCountryName As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" ").Append(" Select distinct town_name ")
            content.Append(" ").Append(" From " & tableName)
            content.Append(" ").Append(" Where  1=1")
            If strCountryName <> "" Then
                content.Append(" ").Append("and county_name = '" & strCountryName & "' ")
            End If

            command.CommandText = content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                'adapter.FillSchema(ds, SchemaType.Mapped, tableName)
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

