Imports System.Data.SqlClient
Imports Syscom.Server.BO
Imports log4net
Imports System.Text
Imports Syscom.Comm.EXP

Public Class PUBDeptAddBO_E1
    Inherits PubDeptAddBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBDeptAddBO_E1

    Public Overloads Shared Function getInstance() As PUBDeptAddBO_E1
        If instance Is Nothing Then
            instance = New PUBDeptAddBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region


    Public Overloads Function delete(ByRef inOrderCode As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "Delete From PUB_Dept_Add " & _
                                      "Where Order_Code='" & inOrderCode & "' "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ' "20110907 Immy --- 科別加成查詢"
    Public Function QueryAdd_Dept(ByVal Order_Code As String) As DataTable
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select A.order_code as 院內碼,A.Effect_Date as 生效日, B.Code_Name as 主身份, C.Code_Name as 門急住, A.Dept_Code as 科別,A.Dept_Add_Ratio as 加成率, A.End_Date as 結束日 ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from PUB_Dept_Add as A left join pub_syscode as B ON A.Main_Identity_Id = B.Code_Id and B.Type_Id='18' ")
        cmdStr.AppendLine("left join PUB_Syscode as C ON A.Pt_From_Id=C.Code_Id and C.Type_Id='50' ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where A.order_code=@OrderCode and A.dc='N' ")


        Try
            Dim dt As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@OrderCode", Order_Code)


                    End With
                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryDeptAddData(ByVal EffectDate As String, ByVal EffectDateSymbol As String, ByVal OrderCode As String, ByVal MainIdentityId As String, ByVal PtFromId As String, ByVal DeptCode As String, ByVal Dc As String) As DataTable

        Dim cmdStrOrder As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStrOrder.AppendLine("select * ")
        cmdStrOrder.Append("from ").Append(tableName).AppendLine(" ")
        cmdStrOrder.AppendLine("where 1=1 ")

        If EffectDate <> "" Then
            cmdStrOrder.AppendLine("And Effect_Date " & EffectDateSymbol & " @EffectDate ")
        End If

        If OrderCode <> "" Then
            cmdStrOrder.AppendLine("And Order_Code = @OrderCode ")
        End If

        If MainIdentityId <> "" Then
            cmdStrOrder.AppendLine("And Main_Identity_Id = @MainIdentityId ")
        End If

        If PtFromId <> "" Then
            cmdStrOrder.AppendLine("And Pt_From_Id = @PtFromId ")
        End If

        If DeptCode <> "" Then
            cmdStrOrder.AppendLine("And Dept_Code=@DeptCode ")
        End If

        If Dc <> "" Then
            cmdStrOrder.AppendLine("And Dc = @Dc ")
        End If

        cmdStrOrder.AppendLine("Order By Effect_Date Desc,Order_Code,Main_Identity_Id,Pt_From_Id,Dept_Code ")


        Try
            Dim dtOrder As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStrOrder.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                        sqlCmd.Parameters.AddWithValue("@EffectDate", EffectDate)
                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)
                        sqlCmd.Parameters.AddWithValue("@MainIdentityId", MainIdentityId)
                        sqlCmd.Parameters.AddWithValue("@PtFromId", PtFromId)
                        sqlCmd.Parameters.AddWithValue("@DeptCode", DeptCode)
                        sqlCmd.Parameters.AddWithValue("@Dc", Dc)

                    End With

                    conn.Open()
                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        da.Fill(dtOrder)
                    End Using

                End Using

            End Using

            Return dtOrder

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DeletePUBDeptAddByEffectDateAndDc(ByVal EffectDate As String, ByVal OrderCode As String, ByVal MainIdentityId As String, ByVal PtFromId As String, ByVal DeptCode As String) As Integer

        Dim conn As IDbConnection = getConnection()

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "Delete From " & tableName & " " & _
                                      "Where  Effect_Date>=@Effect_Date and Order_Code=@Order_Code and Main_Identity_Id=@Main_Identity_Id and Pt_From_Id=@PtFromId and Dept_Code=@DeptCode "

            conn.Open()


            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Effect_Date", EffectDate)
                command.Parameters.AddWithValue("@Order_Code", OrderCode)
                command.Parameters.AddWithValue("@Main_Identity_Id", MainIdentityId)
                command.Parameters.AddWithValue("@PtFromId", PtFromId)
                command.Parameters.AddWithValue("@DeptCode", DeptCode)

                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End Try
    End Function

    Public Function updatePUBDeptAddEndDateAndDc(ByVal EffectDate As String, ByVal OrderCode As String, ByVal MainIdentityId As String, ByVal PtFromId As String, _
                                                 ByVal DeptCode As String, ByVal EndDate As String, ByVal Dc As String, ByVal ModifyUser As String) As Integer

        Dim conn As IDbConnection = getConnection()

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " End_Date=@End_Date , Dc=@Dc , Modified_User=@Modified_User, Modified_Time=@Modified_Time " & _
            " where  Effect_Date=@Effect_Date and Order_Code=@Order_Code And Main_Identity_Id=@Main_Identity_Id and Pt_From_Id=@PtFromId and Dept_Code=@DeptCode "

            conn.Open()


            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Effect_Date", EffectDate)
                command.Parameters.AddWithValue("@Order_Code", OrderCode)
                command.Parameters.AddWithValue("@Main_Identity_Id", MainIdentityId)
                command.Parameters.AddWithValue("@PtFromId", PtFromId)
                command.Parameters.AddWithValue("@DeptCode", DeptCode)
                command.Parameters.AddWithValue("@End_Date", EndDate)
                command.Parameters.AddWithValue("@Dc", Dc)
                command.Parameters.AddWithValue("@Modified_User", ModifyUser)
                command.Parameters.AddWithValue("@Modified_Time", currentTime)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End Try
    End Function

End Class

