Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.StringUtil
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports System.Text
Imports Syscom.Comm.TableFactory

Public Class PUBPreventiveCareExeBO_E1
    Inherits PubPreventiveCareExeBO

    Private Shared instance As PUBPreventiveCareExeBO_E1

    Public Overloads Shared Function getInstance() As PUBPreventiveCareExeBO_E1
        instance = New PUBPreventiveCareExeBO_E1
        Return instance
    End Function



    Public Function queryPUBPreventiveCareExeNext(ByVal PreCareOrderCode As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = _
            "SELECT * " & _
            "FROM PUB_Preventive_Care_Exe " & _
            "WHERE   Pre_Care_Order_Code = '" & PreCareOrderCode & "'  "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryPUBPreventiveCareExeByCond(ByVal PreCareOrderCode As String, ByVal CareOrderCode As String, ByVal AgeControlId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet


            If connFlag Then
                conn = getConnection()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim Content As New StringBuilder
            Content.AppendLine("Select Care_Order_Code, Pre_Care_Order_Code, Age_Control_Id, Age_Start, Age_End  ")
            Content.AppendLine("from PUB_Preventive_Care_Exe")
            Content.AppendLine("")
            Content.AppendLine("WHERE 1=1 ")

            If PreCareOrderCode.Trim <> "" Then
                Content.AppendLine(" AND Pre_Care_Order_Code = @Pre_Care_Order_Code")
            End If

            If CareOrderCode.Trim <> "" Then
                Content.AppendLine(" AND Care_Order_Code = @Care_Order_Code")
            End If

            If AgeControlId.Trim <> "" Then
                Content.AppendLine(" AND Age_Control_Id = @Age_Control_Id")
            End If
           
            Content.Append("Order by Care_Order_Code, Pre_Care_Order_Code ")

            command.CommandText = Content.ToString
            command.Parameters.AddWithValue("@Care_Order_Code", nvl(CareOrderCode))
            command.Parameters.AddWithValue("@Pre_Care_Order_Code", nvl(PreCareOrderCode))
            command.Parameters.AddWithValue("@Age_Control_Id", nvl(AgeControlId))


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
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try

    End Function

    Public Function getPUBPreventiveCareExeCombodata(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim ds As DataSet
        Try
            ds = New DataSet
            
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Using RtnDs As DataSet = PUBSysCodeBO_E1.getInstance.queryPUBSysCodebyCombobox("108")
                RtnDs.Tables(0).TableName = "UclCbo_Care_Order_Code"

                ds.Tables.Add(RtnDs.Tables(0).Copy)
            End Using

            Using RtnDs As DataSet = PUBSysCodeBO_E1.getInstance.queryPUBSysCodebyCombobox("108")
                RtnDs.Tables(0).TableName = "UclCbo_Pre_Care_Order_Code"

                ds.Tables.Add(RtnDs.Tables(0).Copy)
            End Using

            Using RtnDs As DataSet = PUBSysCodeBO_E1.getInstance.queryPUBSysCodebyCombobox("40")
                RtnDs.Tables(0).TableName = "UclCbo_Age_Control_Id"

                ds.Tables.Add(RtnDs.Tables(0).Copy)
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
