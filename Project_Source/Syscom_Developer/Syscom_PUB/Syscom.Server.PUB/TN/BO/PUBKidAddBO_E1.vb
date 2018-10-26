Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PUBKidAddBO_E1
    Inherits PubKidAddBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBKidAddBO_E1

    Public Overloads Shared Function getInstance() As PUBKidAddBO_E1
        If instance Is Nothing Then
            instance = New PUBKidAddBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 程式說明：孩童加成
    ''' 開發人員：Jen
    ''' 開發日期：2009.09.24
    ''' </summary>
    ''' <param name="OrderCode">醫令</param>
    ''' <param name="MainIdentityId">主身分</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Kid_Add
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/09/24, XXX
    ''' </修改註記>
    Public Function queryActiveKidAddData(ByVal OrderCode As String, ByVal MainIdentityId As String, ByVal EffectDate As Date) As DataTable

        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select *, 'N' As Is_New ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("from ").Append(tableName).AppendLine(" ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where Order_Code = @OrderCode and Main_Identity_Id = @MainIdentityId and Effect_Date = @EffectDate and Dc <> @DcY ")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("Order By Pt_From_Id desc ")
        '----------------------------------------------------------------------------
        Try
            Dim dt As DataTable = New DataTable(tableName)

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@OrderCode", OrderCode)
                        sqlCmd.Parameters.AddWithValue("@MainIdentityId", MainIdentityId)
                        sqlCmd.Parameters.AddWithValue("@EffectDate", EffectDate)
                        sqlCmd.Parameters.AddWithValue("@DcY", "Y")

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
 
    ''' <summary>
    ''' 程式說明：孩童加成
    ''' 開發人員：Jen
    ''' 開發日期：2009.09.24
    ''' </summary>
    ''' <param name="Condition">條件</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Kid_Add
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/09/24, XXX
    ''' </修改註記>
    Public Function queryKidAddByCondition(ByVal Condition As DataTable) As DataTable

        If DataSetUtil.IsContainsData(Condition) Then

            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("select *, 'N' As Is_New  ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where Order_Code = @OrderCode and Dc <> @DcY ")

            '"Effect_Date", "Main_Identity_Id", "Pt_From_Id", "Order_Code", "Age_Type_Id", "Age_Start", "Age_End", "End_Date"


            If Not IsDBNull(Condition.Rows(0).Item("Effect_Date")) Then
                cmdStr.Append("and Effect_Date >= '").Append(CType(Condition.Rows(0).Item("Effect_Date"), String).Trim).Append("' ")
            End If

            If Not IsDBNull(Condition.Rows(0).Item("Main_Identity_Id")) Then
                cmdStr.Append("and Main_Identity_Id = '").Append(CType(Condition.Rows(0).Item("Main_Identity_Id"), String).Trim).Append("' ")
            End If

            If Not IsDBNull(Condition.Rows(0).Item("Pt_From_Id")) Then
                cmdStr.Append("and Pt_From_Id in (").Append(CType(Condition.Rows(0).Item("Pt_From_Id"), String).Trim).Append(") ")
            End If

            If Not IsDBNull(Condition.Rows(0).Item("Age_Type_Id")) Then
                cmdStr.Append("and Age_Type_Id = '").Append(CType(Condition.Rows(0).Item("Age_Type_Id"), String).Trim).Append("' ")
            End If

            If Not IsDBNull(Condition.Rows(0).Item("Age_Start")) Then
                cmdStr.Append("and Age_Start >= ").Append(CType(Condition.Rows(0).Item("Age_Start"), String).Trim).Append(" ")
            End If

            If Not IsDBNull(Condition.Rows(0).Item("Age_End")) Then
                cmdStr.Append("and Age_End <= ").Append(CType(Condition.Rows(0).Item("Age_End"), String).Trim).Append(" ")
            End If

            If Not IsDBNull(Condition.Rows(0).Item("End_Date")) Then
                cmdStr.Append("and End_Date <= '").Append(CType(Condition.Rows(0).Item("End_Date"), String).Trim).Append("' ")
            End If


            '----------------------------------------------------------------------------
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By Effect_Date, Main_Identity_Id, Pt_From_Id desc ")
            '----------------------------------------------------------------------------
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@OrderCode", CType(Condition.Rows(0).Item("Order_Code"), String).Trim)
                            sqlCmd.Parameters.AddWithValue("@DcY", "Y")

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

        Else
            Return Nothing
        End If
    End Function


    Public Overloads Function delete(ByRef inOrderCode As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "Delete From PUB_Kid_Add " & _
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

    ' "20110906 Immy --- 孩童加成查詢"
    Public Function QueryAdd(ByVal Order_Code As String) As DataTable
        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select A.order_code as 院內碼 ,A.Effect_Date as 生效日, B.Code_Name as 主身份, C.Code_Name as 門急住, D.Code_Name as 計算年齡, A.Age_Start as 起, A.Age_End as 迄, A.Kid_Add_Ratio as 加成率, A.End_Date as 結束日 ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from PUB_Kid_Add as A left join pub_syscode as B ON A.Main_Identity_Id = B.Code_Id and B.Type_Id='18' ")
        cmdStr.AppendLine("left join PUB_Syscode as C ON A.Pt_From_Id=C.Code_Id and C.Type_Id='50' ")
        cmdStr.AppendLine(" left join PUB_Syscode as D ON A.Age_Type_Id = D.Code_Id and D.Type_Id='19'")
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

    Public Function queryKidAddData(ByVal EffectDate As String, ByVal EffectDateSymbol As String, ByVal OrderCode As String, ByVal MainIdentityId As String, _
                                    ByVal PtFromId As String, ByVal AgeTypeId As String, ByVal AgeStart As String, ByVal Dc As String) As DataTable

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

        If AgeTypeId <> "" Then
            cmdStrOrder.AppendLine("And Age_Type_Id = @AgeTypeId ")
        End If

        If AgeStart <> "" Then
            cmdStrOrder.AppendLine("And Age_Start = @AgeStart ")
        End If

        If Dc <> "" Then
            cmdStrOrder.AppendLine("And Dc = @Dc ")
        End If

        cmdStrOrder.AppendLine("Order By Effect_Date Desc,Order_Code,Main_Identity_Id,Pt_From_Id,Age_Type_Id,Age_Start ")


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
                        sqlCmd.Parameters.AddWithValue("@AgeTypeId", AgeTypeId)
                        sqlCmd.Parameters.AddWithValue("@AgeStart", AgeStart)
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

    Public Function DeletePUBKidAddByEffectDateAndDc(ByVal EffectDate As String, ByVal OrderCode As String, ByVal MainIdentityId As String, ByVal PtFromId As String, _
                                                     ByVal AgeTypeId As String, ByVal AgeStart As String) As Integer

        Dim conn As IDbConnection = getConnection()

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "Delete From " & tableName & " " & _
                                      "Where  Effect_Date>=@Effect_Date and Order_Code=@Order_Code and Main_Identity_Id=@Main_Identity_Id and Pt_From_Id=@PtFromId and " & _
                                      "       Age_Type_Id=@AgeTypeId and Age_Start=@AgeStart "


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
                command.Parameters.AddWithValue("@AgeTypeId", AgeTypeId)
                command.Parameters.AddWithValue("@AgeStart", AgeStart)

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

    Public Function updatePUBKidAddEndDateAndDc(ByVal EffectDate As String, ByVal OrderCode As String, ByVal MainIdentityId As String, ByVal PtFromId As String, _
                                                ByVal AgeTypeId As String, ByVal AgeStart As String, ByVal EndDate As String, ByVal Dc As String, ByVal ModifyUser As String) As Integer

        Dim conn As IDbConnection = getConnection()

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " End_Date=@End_Date , Dc=@Dc , Modified_User=@Modified_User, Modified_Time=@Modified_Time " & _
            " where  Effect_Date=@Effect_Date and Order_Code=@Order_Code And Main_Identity_Id=@Main_Identity_Id and Pt_From_Id=@PtFromId and " & _
            "        Age_Type_Id=@AgeTypeId and Age_Start=@AgeStart "

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
                command.Parameters.AddWithValue("@AgeTypeId", AgeTypeId)
                command.Parameters.AddWithValue("@AgeStart", AgeStart)
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
