Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Server.SQL

Public Class JobEmployeeMaintainBO_E1
    Inherits Syscom.Server.BO.PubEmployeeBO
#Region "     使用的Instance宣告 "

    Private Shared myInstance As JobEmployeeMaintainBO_E1
    Public Overloads Shared Function GetInstance() As JobEmployeeMaintainBO_E1
        If myInstance Is Nothing Then
            myInstance = New JobEmployeeMaintainBO_E1
        End If
        Return myInstance
    End Function

#End Region

#Region "     初始化"


    ''' <summary>
    ''' 初始化相關資料
    ''' </summary>
    ''' <returns>Dataset</returns>
    ''' <remarks>by Will.Lin on 2017-07-03</remarks>
    Public Function InitialJobEmployeeMaintainUI(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet
            Dim retDS As New DataSet
            Dim TempDT As New DataTable()
            TempDT.Columns.Add("Code_Id")
            TempDT.Columns.Add("Code_Name")

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim Content As New StringBuilder
            Content.AppendLine("Select Config_Value From pub_config Where config_name='Job_Employee_Level'")
            Content.AppendLine("Select Config_Value From pub_config Where config_name='Job_Employee_Role'")
            Content.AppendLine("")

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet()
                adapter.Fill(ds)
            End Using



            Return ds

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"初始化"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function


#End Region


#Region "     新增刪除修改查詢"
    Friend Function InsertJobEmployeeMaintainUI(ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("RESULT"))
        retDS.Tables(0).Columns.Add("Result")
        Dim RolesBO As Syscom.Server.BO.ArmRolesBO = New Syscom.Server.BO.ArmRolesBO
        Dim PasswordBO As Syscom.Server.BO.ArmPasswordBO = New Syscom.Server.BO.ArmPasswordBO
        Dim RolesDS As New DataSet
        Dim PasswordDS As New DataSet
        Try
            Dim currentTime = Now
            Dim count As Integer = 0


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope


                If ds.Tables.Contains("Arm_Roles") Then
                    RolesDS.Tables.Add(ds.Tables("Arm_Roles").Copy)
                    RolesBO.insert(RolesDS, conn)
                End If
                If ds.Tables.Contains("Arm_Password") Then
                    PasswordDS.Tables.Add(ds.Tables("Arm_Password").Copy)
                    PasswordBO.insert(PasswordDS, conn)
                End If

                retDS.Tables(0).Rows.Add(insert(ds, conn))
                scope.Complete()
            End Using
            Return retDS

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

    Friend Function UpdateJobEmployeeMaintainUI(ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("RESULT"))
        retDS.Tables(0).Columns.Add("Result")
        Try


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            retDS.Tables(0).Rows.Add(update(ds, conn))

            Return retDS

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

    Friend Function DeleteJobEmployeeMaintainUI(ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing
        Dim retDS As New DataSet
        retDS.Tables.Add(New DataTable("RESULT"))
        retDS.Tables(0).Columns.Add("Result")
        Dim count As Int32 = 0
        Dim RolesBO As Syscom.Server.BO.ArmRolesBO = New Syscom.Server.BO.ArmRolesBO
        Dim PasswordBO As Syscom.Server.BO.ArmPasswordBO = New Syscom.Server.BO.ArmPasswordBO
        Try

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            '使用 Transaction
            Using scope As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope

                For Each dr As DataRow In ds.Tables("Pub_Employee").Rows
                    count += delete(dr("Employee_Code"), conn)
                    count += RolesBO.delete(dr("Employee_Code"), dr("Role").ToString.Trim, conn)
                    count += PasswordBO.delete(dr("Employee_Code"), conn)
                Next
                retDS.Tables(0).Rows.Add(count)
                scope.Complete()
            End Using


            Return retDS

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"新增"})
        Finally

            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try

    End Function

    Friend Function QueryJobEmployeeMaintainUI(ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet


        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim retDS As DataSet
            Dim Content As New StringBuilder
            Content.AppendLine("Select Isnull(PE.Employee_Code,'') Employee_Code")
            Content.AppendLine("      ,Isnull(PE.Employee_Name,'') Employee_Name")
            Content.AppendLine("	  ,Isnull(PE.Employee_En_Name,'') Employee_En_Name")
            Content.AppendLine("	  ,Isnull(PE.Assume_Effect_Date,'') Assume_Effect_Date")
            Content.AppendLine("	  ,PE.Assume_End_Date Assume_End_Date")
            Content.AppendLine("	  ,Isnull(PE.Nrs_Level_Id,'') Nrs_Level_Id")
            Content.AppendLine("	  ,Isnull(AR.Role,'') as 'Role'")
            Content.AppendLine("	  ,Isnull(PE.Tel_Mobile,'') Tel_Mobile")
            Content.AppendLine("	  ,Isnull(PE.EMail,'') EMail")
            Content.AppendLine("  From Pub_Employee PE")
            Content.AppendLine("Left Join ARM_Roles AR on AR.Employee_Code=PE.Employee_Code ")
            Content.AppendLine("Where 1=1")
            If ds.Tables(0).Rows(0).Item("Employee_Code").ToString.Trim.Length > 0 Then
                Content.AppendLine("  And PE.Employee_Code=@Employee_Code")
            End If
            If ds.Tables(0).Rows(0).Item("Employee_Name").ToString.Trim.Length > 0 Then
                Content.AppendLine("  And PE.Employee_Name=@Employee_Name")
            End If
            If ds.Tables(0).Rows(0).Item("Employee_En_Name").ToString.Trim.Length > 0 Then
                Content.AppendLine("  And PE.Employee_En_Name=@Employee_En_Name")
            End If
            Content.AppendLine("")

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = Content.ToString
            If ds.Tables(0).Rows(0).Item("Employee_Code").ToString.Trim.Length > 0 Then
                command.Parameters.AddWithValue("@Employee_Code", ds.Tables(0).Rows(0).Item("Employee_Code"))
            End If
            If ds.Tables(0).Rows(0).Item("Employee_Name").ToString.Trim.Length > 0 Then
                command.Parameters.AddWithValue("@Employee_Name", ds.Tables(0).Rows(0).Item("Employee_Name"))
            End If
            If ds.Tables(0).Rows(0).Item("Employee_En_Name").ToString.Trim.Length > 0 Then
                command.Parameters.AddWithValue("@Employee_En_Name", ds.Tables(0).Rows(0).Item("Employee_En_Name"))
            End If
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                retDS = New DataSet(tableName)
                adapter.Fill(retDS, tableName)
            End Using

            Return retDS

        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"查詢"})
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
