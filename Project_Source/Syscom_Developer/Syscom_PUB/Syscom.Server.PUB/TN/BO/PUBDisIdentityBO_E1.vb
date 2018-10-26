Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PUBDisIdentityBO_E1
    Inherits PubDisIdentityBO

    Dim tableName1 As String = "PUB_Dis_Identity"
    Private Shared instance As PUBDisIdentityBO_E1

    Public Shared Shadows Function getInstance() As PUBDisIdentityBO_E1
        instance = New PUBDisIdentityBO_E1
        Return instance
    End Function

    'Private Function getConnection() As IDbConnection
    '    Return SQLConnFactory.getInstance.getPubDBSqlConn
    'End Function

    Public Function queryPUBDisIdentityAll() As System.Data.DataSet 'Implements IPUBDisIdentityBO.queryPUBDisIdentityAll
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "   Select RTRIM(Dis_Identity_Code) ,RTRIM(Dis_Identity_Name) ,RTRIM(Dis_Identity_Type_Id)  ,RTRIM(Is_Online_Choice)  " & _
                                    " From  " & tableName1 & " " & _
                                    " Where  DC='N' " & _
                                    " Order By Dis_Identity_Code,Dis_Identity_Name"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try


    End Function
End Class
