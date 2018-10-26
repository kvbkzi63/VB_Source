Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PUBContractBO_E1
    Inherits PubContractBO

    Dim tableName1 As String = "PUB_Contract"
    Private Shared instance As PUBContractBO_E1

    Public Overloads Shared Function getInstance() As PUBContractBO_E1
        instance = New PUBContractBO_E1
        Return instance
    End Function

    'Private Function getConnection() As IDbConnection
    '    Return SQLConnFactory.getInstance.getPubDBSqlConn
    'End Function



    Public Function queryPUBContractAll() As System.Data.DataSet 'Implements IPUBContractBO.queryPUBContractAll


        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "   Select RTRIM(Contract_Code) ,RTRIM(Contract_Name) , RTRIM(Sub_Identity_Code)" & _
                                    " From  " & tableName1 & " " & _
                                    " Where  DC='N' " & _
                                    " Order By Contract_Code,Contract_Name"

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



    Public Function queryPUBContractByContractCode(ByVal ContractCode As String, ByVal SubIdentityCode As String, Optional ByRef conn As IDbConnection = Nothing) As System.Data.DataSet 'Implements IPUBContractBO.queryPUBContractAll
   
            
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet = New DataSet
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("   SELECT CT.Is_Use_Set, CT.Upper_Amt_Type_Id, CT.Upper_Amt, CT.Check_Quota_Id " & _
                                    " From  " & tableName1 & " CT " & _
                                    " Where CT.DC = 'N' and (CT.Contract_Code = '' or CT.Contract_Code = '" & ContractCode & "') and (CT.Sub_Identity_Code = '' or CT.Sub_Identity_Code = '" & SubIdentityCode & "') order by Sub_Identity_Code Desc")


            command.CommandText = sqlStr.ToString
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
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function


End Class
