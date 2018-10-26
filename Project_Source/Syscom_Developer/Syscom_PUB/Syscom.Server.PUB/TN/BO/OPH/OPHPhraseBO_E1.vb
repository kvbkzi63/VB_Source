Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM

Public Class OPHPhraseBO_E1
    Inherits OphPhraseBO

    Private Shared instance As OPHPhraseBO_E1

    Private Sub New()
    End Sub

    Public Overloads Shared Function getInstance() As OPHPhraseBO_E1
        If instance Is Nothing Then
            instance = New OPHPhraseBO_E1
        End If
        Return instance
    End Function

    ''' <summary>
    ''' 據RuleCode查詢Phrase_Name
    ''' </summary>
    ''' <param name="OPH_Rule_Reason"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPhraseNameByOPHRuleReason(ByVal OPH_Rule_Reason As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = _
            " Select Phrase_Name " & _
            " From " & tableName & " " & _
            " Where Phrase_Code_Id = @Phrase_Code_Id "
            command.Parameters.AddWithValue("@Phrase_Code_Id", OPH_Rule_Reason)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    Public Overloads Function dynamicQuery(ByVal sql As String) As DataSet
        Try
            Dim ds As New DataSet
            Dim dt As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = sql
                        .CommandType = CommandType.Text
                        .Connection = conn

                    End With
                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
            ds.Tables.Add(dt)
            Return ds

        Catch ex As Exception
            Throw ex
        End Try


    End Function

End Class
