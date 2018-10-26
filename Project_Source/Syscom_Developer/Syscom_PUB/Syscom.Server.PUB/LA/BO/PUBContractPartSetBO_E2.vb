
Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO


Public Class PUBContractPartSetBO_E2
    Inherits PubContractPartSetBO
    Public Shared ReadOnly tableNamePUBContract As String = "PUB_Contract"
    Public Shared ReadOnly tableNamePUBSubIdentity As String = "PUB_Sub_Identity"
    Private Shared myInstance As PUBContractPartSetBO_E2

    Public Overloads Function getInstance() As PUBContractPartSetBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBContractPartSetBO_E2()
        End If
        Return myInstance
    End Function
    ''' <summary>
    ''' 根據生效日,合約機關代碼和身份二代碼取得所有資料
    ''' </summary>
    ''' <param name="dateEffectDate"></param>
    ''' <param name="strContractCode"></param>
    ''' <param name="strSubIdentityCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBContractPartSetByCond(ByVal dateEffectDate As Date, ByVal strContractCode As String, ByVal strSubIdentityCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select A.*, B.Contract_Name ,C.Sub_Identity_Name from " & tableName)
            content.Append(" ").Append("A left join ")
            content.Append(" ").Append(tableNamePUBContract)
            content.Append(" ").Append("B on A.Contract_Code = B.Contract_Code  and  A.Sub_Identity_Code = B.Sub_Identity_Code  ")
            content.Append(" ").Append(" left join ")
            content.Append(" ").Append(tableNamePUBSubIdentity)
            content.Append(" ").Append("C on (A.Sub_Identity_Code = C.Sub_Identity_Code AND A.Sub_Identity_Code = C.Sub_Identity_Code and C.Dc ='N') ")
            content.Append(" where 1=1 ")
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                content.Append("and ").Append("A.Effect_Date =@Effect_Date ")
            End If
            If Not strContractCode.Equals("") Then
                content.Append("and ").Append("A.Contract_Code =@Contract_Code ")
            End If
            If Not strSubIdentityCode.Equals("") Then
                content.Append("and ").Append("A.Sub_Identity_Code =@Sub_Identity_Code ")
            End If
            content.Append("order by A.Effect_Date,A.Contract_Code,A.Sub_Identity_Code")
            command.CommandText = content.ToString
            If Not dateEffectDate.Equals(System.DateTime.MinValue) Then
                command.Parameters.AddWithValue("@Effect_Date", dateEffectDate)
            End If
            If Not strContractCode.Equals("") Then
                command.Parameters.AddWithValue("@Contract_Code", strContractCode)
            End If
            If Not strSubIdentityCode.Equals("") Then
                command.Parameters.AddWithValue("@Sub_Identity_Code", strSubIdentityCode)
            End If
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

End Class
