Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports System.Text

Public Class PUBPreventiveCareBO_E1
    Inherits PUBPreventiveCareBO

    Private Shared instance As PUBPreventiveCareBO_E1

    Public Overloads Shared Function getInstance() As PUBPreventiveCareBO_E1
        instance = New PUBPreventiveCareBO_E1
        Return instance
    End Function

    Public Function queryPUBPreventiveCareByCond(ByVal Care_Item_Code As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = _
            "SELECT MIN(Care_Cardseq), Care_Order_Code " & _
            "FROM PUB_Preventive_Care " & _
            "WHERE Care_Item_Code = '" & Care_Item_Code & "'"
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


    Public Function queryPUBPreventiveCareNext(ByVal Care_Item_Code As String, ByVal Care_Order_Code As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing

        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            If Care_Item_Code = "01" OrElse Care_Item_Code = "04" Then

                command.CommandText = _
                  "SELECT * " & _
                  "FROM PUB_Preventive_Care " & _
                  "WHERE   Care_Item_Code = '" & Care_Item_Code & "' "
                '" Care_Order_Code>'" & Care_Order_Code & "'  " ' & _

            ElseIf Care_Item_Code = "05" Then

                command.CommandText = _
            "SELECT * " & _
            "FROM PUB_Preventive_Care " & _
            "WHERE   Care_Item_Code = '" & Care_Item_Code & "'  And " & _
                  " Care_Order_Code = '" & Care_Order_Code & "'  " ' & _


            Else

                command.CommandText = _
                  "SELECT * " & _
                  "FROM PUB_Preventive_Care " & _
                  "WHERE   Care_Item_Code = '" & Care_Item_Code & "' And " & _
                  " Care_Order_Code>'" & Care_Order_Code & "'  " ' & _



            End If


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB302", ex, New String() {"¬d¸ß¹w¨¾«O°·"})
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function



    Public Function queryPUBPreventiveCareByCond2(ByVal Care_Item_Code As String, ByVal Care_Order_Code As String, ByVal Care_Cardseq As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            If Care_Cardseq = "" Then
                command.CommandText = _
                      "SELECT * " & _
                      "FROM PUB_Preventive_Care " & _
                      "WHERE Care_Item_Code = '" & Care_Item_Code & "' " 'And Care_Order_Code='" & Care_Order_Code & "' And Care_Cardseq='" & Care_Cardseq & "' "
            Else

                command.CommandText = _
                      "SELECT * " & _
                      "FROM PUB_Preventive_Care " & _
                      "WHERE Care_Item_Code = '" & Care_Item_Code & "'   And Care_Cardseq='" & Care_Cardseq & "' Order By Care_Item_Code , Care_Cardseq "

            End If
          
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

    Public Function getPUBPreventiveCareSeq(ByVal Care_Item_Code As String, ByVal Care_Order_Code As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()


            command.CommandText = _
                  "SELECT * " & _
                  "FROM PUB_Preventive_Care " & _
                  "WHERE Care_Item_Code = '" & Care_Item_Code & "' And Care_Order_Code='" & Care_Order_Code & "' "


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

    Public Function queryOMOPreventationHealthCareByItem(ByVal ChartNo As String, ByVal ServiceItemId As String, _
                                                         ByVal ExamItemId As String, ByVal CareEffectDate As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select * From OMO_Preventation_Health_Care " & _
                                  "Where Chart_No='" & ChartNo & "' And Care_Item_Code='" & ServiceItemId & "' And " & _
                                  "      Care_Order_Code='" & ExamItemId & "' And Effect_Date<='" & CareEffectDate & "' And " & _
                                  "      End_Date>='" & CareEffectDate & "' "
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("OMO_Preventation_Health_Care")
                adapter.Fill(ds, "OMO_Preventation_Health_Care")
                adapter.FillSchema(ds, SchemaType.Mapped, "OMO_Preventation_Health_Care")
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function queryOMOPreventationHealthCareByDate(ByVal ChartNo As String, ByVal ServiceItemId As String, _
                                                               ByVal ExamItemId As String, ByVal CareEffectDate As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select * From  OMO_Preventation_Health_Care " & _
                                  "Where Chart_No='" & ChartNo & "' And Care_Item_Code='" & ServiceItemId & "' And " & _
                                  "      Care_Order_Code='" & ExamItemId & "' And Effect_Date>'" & CareEffectDate & "' "
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("OMO_Preventation_Health_Care")
                adapter.Fill(ds, "OMO_Preventation_Health_Care")
                adapter.FillSchema(ds, SchemaType.Mapped, "OMO_Preventation_Health_Care")
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function queryOMOPreventationHealthCareMaxNo(ByVal ChartNo As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select Max(Prevent_No) As Prevent_No From OMO_Preventation_Health_Care " & _
                                  "Where Chart_No='" & ChartNo & "' "
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("OMO_Preventation_Health_Care")
                adapter.Fill(ds, "OMO_Preventation_Health_Care")
                adapter.FillSchema(ds, SchemaType.Mapped, "OMO_Preventation_Health_Care")
            End Using
            Return ds
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function updateOMOPreventationHealthCareByItem(ByVal ChartNo As String, ByVal PreventNo As String, _
                                                          ByVal ExecuteDateExternal As String, ByVal ExecuteHospitalExternal As String) As Integer
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Update SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine(" Update OMO_Preventation_Health_Care ")
        cmdStr.AppendLine(" Set")
        cmdStr.AppendLine(" Execute_Date_External = '" & ExecuteDateExternal & "', ")
        cmdStr.AppendLine(" Exexute_External_Hospital = '" & ExecuteHospitalExternal & "' ")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine(" Where ")
        cmdStr.AppendLine(" Chart_No = '" & ChartNo & "' ")
        cmdStr.AppendLine(" And Prevent_No = '" & PreventNo & "' ")
        '----------------------------------------------------------------------------
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                    End With

                    conn.Open()

                    Return sqlCmd.ExecuteNonQuery()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function updateOMOPreventationHealthCareByDate(ByVal ChartNo As String, ByVal PreventNo As String, _
                                                          ByVal EffectDate As String, ByVal EndDate As String) As Integer
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Update SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine(" Update OMO_Preventation_Health_Care ")
        cmdStr.AppendLine(" Set")
        cmdStr.AppendLine(" Effect_Date = '" & EffectDate & "', ")
        cmdStr.AppendLine(" End_Date = '" & EndDate & "' ")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine(" Chart_No = '" & ChartNo & "' ")
        cmdStr.AppendLine(" And Prevent_No = '" & PreventNo & "' ")
        '----------------------------------------------------------------------------
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                    End With

                    conn.Open()

                    Return sqlCmd.ExecuteNonQuery()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function insertOMOPreventationHealthCareByICCard(ByVal ChartNo As String, ByVal PreventNo As String, ByVal CareItemCode As String, _
                                                            ByVal CareOrderCode As String, ByVal CareCardseq As String, ByVal EffectDate As String, _
                                                            ByVal EndDate As String, ByVal CreateUser As String) As Integer
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Insert SQL
        '----------------------------------------------------------------------------
        cmdStr.Append(" Insert into OMO_Preventation_Health_Care ")
        cmdStr.Append(" (Chart_No,Prevent_No,Care_Item_Code,Care_Order_Code,Care_Cardseq,Effect_Date,End_Date,Create_User,Create_Time) Values ")
        cmdStr.Append(" ('" & ChartNo & "'," & PreventNo & ",'" & CareItemCode.Trim & "','" & CareOrderCode.Trim & "','" & CareCardseq.Trim & "','")
        cmdStr.Append( EffectDate & "','" & EndDate & "','" & CreateUser.Trim & "','" & Now.ToString("yyyy/MM/dd") & "')")
        'LOGDelegate.GetInstance.dbDebugMsg("PUBPreventiveCareBO_E1-insertOMOPreventationHealthCareByICCard : " & cmdStr.ToString)'add on 2011-05-07 by Lits
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                    End With

                    conn.Open()

                    Return sqlCmd.ExecuteNonQuery()

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class