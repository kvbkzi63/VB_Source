Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Data.SqlTypes
Public Class PubRuleReasonBO_E1
    Inherits PubRuleReasonBO

    Dim log As LOGDelegate = LOGDelegate.getInstance

#Region "########## getInstance ##########"

    Private Shared instance As PubRuleReasonBO_E1

    Public Overloads Shared Function getInstance() As PubRuleReasonBO_E1
        If instance Is Nothing Then
            instance = New PubRuleReasonBO_E1
        End If
        Return instance
    End Function

#End Region

#Region "     以ＰＫ查詢資料 "

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryRuleReasonByRuleCode(ByVal pk_Rule_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Rule_Code , Rule_Reason_Id , Create_User , Create_Time , Modified_User ,  ")
            content.AppendLine(" Modified_Time                from " & tableName)
            content.AppendLine("   where Rule_Code=@Rule_Code           ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Rule_Code", pk_Rule_Code)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
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
