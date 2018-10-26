Imports System.Data
Imports System.Data.SqlClient

Public Class DBConnection

    Private Shared instance As DBConnection
    Public Shared Function getInstance() As DBConnection
        Try
            Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("zh-TW", False)
            If instance Is Nothing Then
                instance = New DBConnection
            End If
            Return New DBConnection
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub New()

    End Sub

    Public Function QueryDataBySql(ByVal s As String) As DataSet
        Dim conn = GetConnection()
        Dim ds As DataSet = Nothing
        Try
            conn.Open()

            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = s
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet()
                adapter.Fill(ds)
                adapter.FillSchema(ds, SchemaType.Mapped)
            End Using
        Catch ex As Exception

        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Return ds
    End Function


    Private Function GetConnection() As SqlConnection
        Dim conn As New SqlClient.SqlConnection("Data Source=DESKTOP-0A25QSL;Initial Catalog=JobManagementDB;User ID=Will_Lin;Password=kvbkzi63;Application Name=Will;Pooling=true")
        Return conn
    End Function

End Class
