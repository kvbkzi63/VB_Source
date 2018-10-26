Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text


Public Class PUBSystemVersionBO_E1
    ' Inherits PUBPartBO

    Private Shared instance As PUBSystemVersionBO_E1

    Dim log As LOGDelegate = LOGDelegate.getInstance
    Dim tableName1 As String = "PUB_System_Version"

    Public Shared Function getInstance() As PUBSystemVersionBO_E1
        instance = New PUBSystemVersionBO_E1
        Return instance
    End Function



    Public Function DynamicQueryByColumn(ByRef queryData As DataSet) As System.Data.DataSet
        Dim ds, ds1, ds2, ds3 As New DataSet

        Try
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            If queryData Is Nothing Then
                command.CommandText = " Select sub_system_no ,sub_system_name  " & _
                                      " From arm_sub_system  " & _
                                      " Order By sub_system_no "
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds1 = New DataSet("arm_sub_system")
                    adapter.Fill(ds1, "arm_sub_system")
                End Using



                command.CommandText = " Select  distinct Version_No ,Version_No As Version_Name  " & _
                                      " From PUB_System_Version " & _
                                      " Order By Version_No Desc "
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds2 = New DataSet("Version_No")
                    adapter.Fill(ds2, "Version_No")
                End Using


                If ds2 IsNot Nothing AndAlso ds2.Tables IsNot Nothing AndAlso ds2.Tables(0).Rows.Count > 0 Then
                    command.CommandText = " Select B.sub_system_name,A.Problem_Description,A.Version_No,A.Update_Date " & _
                                                     " From  " & tableName1 & " As A, arm_sub_system AS B" & _
                                                     " where 1=1 "
                    command.CommandText &= "and A.Version_No ='" & ds2.Tables(0).Rows(0).Item("Version_No").ToString.Trim & "'  " & _
                                           "and B.sub_system_no=A.System_Name "

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        ds3 = New DataSet(tableName1)
                        adapter.Fill(ds3, tableName1)
                        adapter.FillSchema(ds3, SchemaType.Mapped, tableName1)
                    End Using
                End If

                ds.Merge(ds1)
                ds.Merge(ds2)
                ds.Merge(ds3)

            Else
                command.CommandText = " Select B.sub_system_name,A.Problem_Description,A.Version_No,A.Update_Date " & _
                                      " From  " & tableName1 & " As A, arm_sub_system AS B" & _
                                      " where 1=1 "
                If queryData.Tables(0).Rows(0).Item("System_Name").ToString.Trim <> "" Then
                    command.CommandText &= "and A.System_Name like '" & queryData.Tables(0).Rows(0).Item("System_Name").ToString.Trim & "%'"
                End If

                If queryData.Tables(0).Rows(0).Item("BringUp_ST_Date").ToString.Trim <> "" Then
                    command.CommandText &= "and A.BringUp_Date >= '" & queryData.Tables(0).Rows(0).Item("BringUp_ST_Date").ToString.Trim & "'"
                    command.CommandText &= "and A.BringUp_Date <= '" & queryData.Tables(0).Rows(0).Item("BringUp_ED_Date").ToString.Trim & "'"
                End If

                If queryData.Tables(0).Rows(0).Item("Function_Name").ToString.Trim <> "" Then
                    command.CommandText &= "and A.Function_Name like '" & queryData.Tables(0).Rows(0).Item("Function_Name").ToString.Trim & "%'"
                End If

                If queryData.Tables(0).Rows(0).Item("Problem_Description").ToString.Trim <> "" Then
                    command.CommandText &= "and A.Problem_Description like '" & queryData.Tables(0).Rows(0).Item("Problem_Description").ToString.Trim & "%'"
                End If

                If queryData.Tables(0).Rows(0).Item("Version_No").ToString.Trim <> "" Then
                    command.CommandText &= "and A.Version_No ='" & queryData.Tables(0).Rows(0).Item("Version_No").ToString.Trim & "'"
                End If

                If queryData.Tables(0).Rows(0).Item("Update_ST_Date").ToString.Trim <> "" Then
                    command.CommandText &= "and A.Update_Date >= '" & queryData.Tables(0).Rows(0).Item("Update_ST_Date").ToString.Trim & "'"
                    command.CommandText &= "and A.Update_Date <= '" & queryData.Tables(0).Rows(0).Item("Update_ED_Date").ToString.Trim & "'"
                End If

                command.CommandText &= "and B.sub_system_no=A.System_Name "

                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds = New DataSet(tableName1)
                    adapter.Fill(ds, tableName1)
                    adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
                End Using

            End If

            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If (ds1 IsNot Nothing) Then ds1.Dispose()
            If (ds2 IsNot Nothing) Then ds2.Dispose()
            If (ds3 IsNot Nothing) Then ds3.Dispose()
        End Try

    End Function

    Public Function insertPUBSystermVersion(ByVal queryData As System.Data.DataSet) As Integer
        Try

            '取得該版本最大號
            Dim pvtMaxSeqNo As Integer = 0
            Dim ds As New DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command1 As SqlCommand = sqlConn.CreateCommand()
            command1.CommandText = " Select Max(Seq_No) As Seq_No " & _
                                  " From  " & tableName1 & " Where Version_No ='" & queryData.Tables(0).Rows(0).Item("Version_No").ToString.Trim & "' "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command1)
                ds = New DataSet(tableName1)
                adapter.Fill(ds, tableName1)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName1)
            End Using

            If ds.Tables IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 AndAlso _
               ds.Tables(0).Rows(0).Item("Seq_No").ToString.Trim <> "" Then
                pvtMaxSeqNo = CInt(ds.Tables(0).Rows(0).Item("Seq_No").ToString.Trim)
            End If

            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName1 & "(" & _
            " System_Name , BringUp_Date , Function_Name , Problem_Description , Version_No , Seq_No , " & _
             " Update_Date ) " & _
             " values( @System_Name , @BringUp_Date , @Function_Name , @Problem_Description , @Version_No ,  @Seq_No , " & _
             " @Update_Date )"
            Using conn As System.Data.IDbConnection = getConnection()
                conn.Open()
                For Each row As DataRow In queryData.Tables(0).Rows
                    Using command As SqlCommand = New SqlCommand
                        With command
                            .CommandText = sqlString
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                        End With
                        pvtMaxSeqNo += 1
                        command.Parameters.AddWithValue("@System_Name", row.Item("System_Name"))
                        command.Parameters.AddWithValue("@BringUp_Date", CDate(row.Item("BringUp_Date")))
                        command.Parameters.AddWithValue("@Function_Name", row.Item("Function_Name"))
                        command.Parameters.AddWithValue("@Problem_Description", row.Item("Problem_Description"))
                        command.Parameters.AddWithValue("@Version_No", row.Item("Version_No"))
                        command.Parameters.AddWithValue("@Seq_No", pvtMaxSeqNo)
                        command.Parameters.AddWithValue("@Update_Date", CDate(Now.ToString("yyyy/MM/dd")))

                        Dim cnt As Integer = command.ExecuteNonQuery
                        count = count + cnt
                    End Using
                Next
            End Using

            Return 1
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)

        End Try
    End Function


    Protected Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

End Class
