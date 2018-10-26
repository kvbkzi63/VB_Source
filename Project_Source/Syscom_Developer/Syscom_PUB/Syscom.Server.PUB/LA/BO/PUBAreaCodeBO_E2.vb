'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBAreaCodeBO_E2.vb
'*              Title:	
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Johsn
'*        Create Date:	2009/07/28
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.BO

Public Class PUBAreaCodeBO_E2
    Inherits PubAreaCodeBO
    Private Shared myInstance As PUBAreaCodeBO_E2
    Public Overloads Shared Function GetInstance() As PUBAreaCodeBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBAreaCodeBO_E2()
        End If
        Return myInstance
    End Function
    ''' <summary>
    ''' 取得縣市別資料來源
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBAreaCode() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" Select DISTINCT RTRIM( Area_Code) as Area_Code ,RTRIM(Area_Name) as Area_Name ")
            content.Append(" From " & tableName)
            content.Append(" Where  Area_Code = County_Code ")
            content.Append(" Order By Area_Code")
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

    ''' <summary>
    ''' 取得 鄉鎮市區
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBAreaCodeByAreaCode(ByVal strAreaCode As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" SELECT DISTINCT PA.Postal_Code, PC.Town_Name ")
            content.Append(" FROM PUB_Area_Code AC, PUB_Postal_Area PA, PUB_Postal_Code PC  ")
            content.Append(" WHERE AC.County_Code = '").Append(strAreaCode).Append("'")
            content.Append(" AND PA.Area_Code = AC.Area_Code AND PC.Postal_Code = PA.Postal_Code")
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

#Region "戶籍地檔維護  add by runxia 20110307"
    ''' <summary>
    ''' 戶籍地檔資料
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBAreaCodeByCond(ByVal strAreaCode As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append(" ").Append(" Select DISTINCT  Area_Code ,Area_Name,County_Code ")
            content.Append(" ").Append(" From " & tableName)
            content.Append(" ").Append(" Where  1=1")
            If strAreaCode <> "" Then
                content.Append(" ").Append(" and Area_Code = '" & strAreaCode & "' ")
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
End Class
