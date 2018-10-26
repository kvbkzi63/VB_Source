
Imports Sybase.Data.AseClient
Imports Syscom.Server.SQL

Public Class SybAPI

#Region "取得資料庫連線"
    ''' <summary>
    ''' 取得Informix Connection 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getSybConnection() As AseConnection
        Try
            Dim conn As AseConnection = SQLConnFactory.getInstance.getSyBaseDBSqlConn
            Return conn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function test(ByVal sql As String) As DataSet
        Try
            Dim myDataAdapter As New AseDataAdapter(sql, getSybConnection)
            Dim ds As New DataSet()
            myDataAdapter.Fill(ds)

            Return ds

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

End Class
