Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PUBPostalCodeBO_E1
    Inherits PubPostalCodeBO

#Region "########## getInstance ##########"
    Private Shared instance As PUBPostalCodeBO_E1
    Public Overloads Shared Function getInstance() As PUBPostalCodeBO_E1
        If instance Is Nothing Then
            instance = New PUBPostalCodeBO_E1
        End If
        Return instance
    End Function
    Public Sub New()
    End Sub
#End Region

#Region "     查詢 Method "
    ''' <summary>
    ''' 郵遞區號設定維護查詢
    ''' </summary>
    ''' <param name="Postal_Code">郵遞區號</param>
    ''' <param name="Postal_Name">郵遞區號名稱</param>
    ''' <param name="County_Name">縣市名稱</param>
    ''' <param name="Town_Name">鄉鎮區</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Public Function QueryPubPostalCode(ByVal Postal_Code As String, ByVal Postal_Name As String, ByVal County_Name As String, ByVal Town_Name As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing

        Try

            Dim ds As Data.DataSet

            If connFlag Then
                conn = getConnection()
            End If

            Dim Content As New StringBuilder
            Content.AppendLine("SELECT Postal_Code")
            Content.AppendLine("      ,Postal_Name")
            Content.AppendLine("      ,County_Name")
            Content.AppendLine("      ,Town_Name")
            Content.AppendLine("FROM PUB_Postal_Code")
            Content.AppendLine("where 1=1")


            If Postal_Code.Trim <> "" Then
                Content.Append(" AND Postal_Code like '%").Append(Postal_Code.Trim).Append("%' ")
            End If

            If Postal_Name.Trim <> "" Then
                Content.Append(" AND Postal_Name like '%").Append(Postal_Name.Trim).Append("%' ")
            End If

            If County_Name.Trim <> "" Then
                Content.Append(" AND County_Name like '%").Append(County_Name.Trim).Append("%' ")
            End If

            If Town_Name.Trim <> "" Then
                Content.Append(" AND Town_Name like '%").Append(Town_Name.Trim).Append("%' ")
            End If

            Content.Append("Order by Postal_Code ")


            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(Content.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
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