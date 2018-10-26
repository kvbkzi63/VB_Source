Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubMaterialSelfpayApplyBO
    'Roger's CodeGen Produced This VB Code @ 2013/5/13 上午 09:16:09
    Public Shared ReadOnly tableName As String = "PUB_Material_Selfpay_Apply"
    Private Shared myInstance As PubMaterialSelfpayApplyBO
    Public Shared Function GetInstance() As PubMaterialSelfpayApplyBO
        If myInstance Is Nothing Then
            myInstance = New PubMaterialSelfpayApplyBO()
        End If
        Return myInstance
    End Function
    ''' <summary>
    '''查詢全部
    ''' </summary>
    ''' <returns>查詢資料全部資料內容</returns>
    ''' <remarks></remarks>
    Public Function queryAll(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from " & tableName
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
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''新增
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function insert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Order_Code , Effect_Date , End_Date , Self_Insu_Code , Apply_Status_Id ,  " & _
             " Equipment_License , Equipment_License_No , Product_Features , Use_Reason , Precautions ,  " & _
             " Side_Effect , Efficacy_Comparison , Insu_Order_Type_Id , Is_Alter , Alternative_Insu_Code_1 ,  " & _
             " Alternative_Insu_Code_2 , Alternative_Insu_Code_3 , Alternative_Insu_Code_4 , Alternative_Insu_Code_5 , Alternative_Insu_Code_6 ,  " & _
             " Alternative_Insu_Code_7 , Alternative_Insu_Code_8 , Alternative_Insu_Code_9 , Alternative_Insu_Code_10 , Is_Agreement_Print ,  " & _
             " Is_Instruction_Print , Create_User , Create_Time , Modified_User , Modified_Time " & _
             "  ) " & _
             " values( @Order_Code , @Effect_Date , @End_Date , @Self_Insu_Code , @Apply_Status_Id ,  " & _
             " @Equipment_License , @Equipment_License_No , @Product_Features , @Use_Reason , @Precautions ,  " & _
             " @Side_Effect , @Efficacy_Comparison , @Insu_Order_Type_Id , @Is_Alter , @Alternative_Insu_Code_1 ,  " & _
             " @Alternative_Insu_Code_2 , @Alternative_Insu_Code_3 , @Alternative_Insu_Code_4 , @Alternative_Insu_Code_5 , @Alternative_Insu_Code_6 ,  " & _
             " @Alternative_Insu_Code_7 , @Alternative_Insu_Code_8 , @Alternative_Insu_Code_9 , @Alternative_Insu_Code_10 , @Is_Agreement_Print ,  " & _
             " @Is_Instruction_Print , @Create_User , @Create_Time , @Modified_User , @Modified_Time " & _
             "              )"
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    command.Parameters.AddWithValue("@Self_Insu_Code", row.Item("Self_Insu_Code"))
                    command.Parameters.AddWithValue("@Apply_Status_Id", row.Item("Apply_Status_Id"))
                    command.Parameters.AddWithValue("@Equipment_License", row.Item("Equipment_License"))
                    command.Parameters.AddWithValue("@Equipment_License_No", row.Item("Equipment_License_No"))
                    command.Parameters.AddWithValue("@Product_Features", row.Item("Product_Features"))
                    command.Parameters.AddWithValue("@Use_Reason", row.Item("Use_Reason"))
                    command.Parameters.AddWithValue("@Precautions", row.Item("Precautions"))
                    command.Parameters.AddWithValue("@Side_Effect", row.Item("Side_Effect"))
                    command.Parameters.AddWithValue("@Efficacy_Comparison", row.Item("Efficacy_Comparison"))
                    command.Parameters.AddWithValue("@Insu_Order_Type_Id", row.Item("Insu_Order_Type_Id"))
                    command.Parameters.AddWithValue("@Is_Alter", row.Item("Is_Alter"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_1", row.Item("Alternative_Insu_Code_1"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_2", row.Item("Alternative_Insu_Code_2"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_3", row.Item("Alternative_Insu_Code_3"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_4", row.Item("Alternative_Insu_Code_4"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_5", row.Item("Alternative_Insu_Code_5"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_6", row.Item("Alternative_Insu_Code_6"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_7", row.Item("Alternative_Insu_Code_7"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_8", row.Item("Alternative_Insu_Code_8"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_9", row.Item("Alternative_Insu_Code_9"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_10", row.Item("Alternative_Insu_Code_10"))
                    command.Parameters.AddWithValue("@Is_Agreement_Print", row.Item("Is_Agreement_Print"))
                    command.Parameters.AddWithValue("@Is_Instruction_Print", row.Item("Is_Instruction_Print"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime)
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''新增(傳入單一Create_Time)
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <param name="assignTime">傳入單一Create_Time</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function insertByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Order_Code , Effect_Date , End_Date , Self_Insu_Code , Apply_Status_Id ,  " & _
             " Equipment_License , Equipment_License_No , Product_Features , Use_Reason , Precautions ,  " & _
             " Side_Effect , Efficacy_Comparison , Insu_Order_Type_Id , Is_Alter , Alternative_Insu_Code_1 ,  " & _
             " Alternative_Insu_Code_2 , Alternative_Insu_Code_3 , Alternative_Insu_Code_4 , Alternative_Insu_Code_5 , Alternative_Insu_Code_6 ,  " & _
             " Alternative_Insu_Code_7 , Alternative_Insu_Code_8 , Alternative_Insu_Code_9 , Alternative_Insu_Code_10 , Is_Agreement_Print ,  " & _
             " Is_Instruction_Print , Create_User , Create_Time , Modified_User , Modified_Time " & _
             "  ) " & _
             " values( @Order_Code , @Effect_Date , @End_Date , @Self_Insu_Code , @Apply_Status_Id ,  " & _
             " @Equipment_License , @Equipment_License_No , @Product_Features , @Use_Reason , @Precautions ,  " & _
             " @Side_Effect , @Efficacy_Comparison , @Insu_Order_Type_Id , @Is_Alter , @Alternative_Insu_Code_1 ,  " & _
             " @Alternative_Insu_Code_2 , @Alternative_Insu_Code_3 , @Alternative_Insu_Code_4 , @Alternative_Insu_Code_5 , @Alternative_Insu_Code_6 ,  " & _
             " @Alternative_Insu_Code_7 , @Alternative_Insu_Code_8 , @Alternative_Insu_Code_9 , @Alternative_Insu_Code_10 , @Is_Agreement_Print ,  " & _
             " @Is_Instruction_Print , @Create_User , @Create_Time , @Modified_User , @Modified_Time " & _
             "              )"
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    command.Parameters.AddWithValue("@Self_Insu_Code", row.Item("Self_Insu_Code"))
                    command.Parameters.AddWithValue("@Apply_Status_Id", row.Item("Apply_Status_Id"))
                    command.Parameters.AddWithValue("@Equipment_License", row.Item("Equipment_License"))
                    command.Parameters.AddWithValue("@Equipment_License_No", row.Item("Equipment_License_No"))
                    command.Parameters.AddWithValue("@Product_Features", row.Item("Product_Features"))
                    command.Parameters.AddWithValue("@Use_Reason", row.Item("Use_Reason"))
                    command.Parameters.AddWithValue("@Precautions", row.Item("Precautions"))
                    command.Parameters.AddWithValue("@Side_Effect", row.Item("Side_Effect"))
                    command.Parameters.AddWithValue("@Efficacy_Comparison", row.Item("Efficacy_Comparison"))
                    command.Parameters.AddWithValue("@Insu_Order_Type_Id", row.Item("Insu_Order_Type_Id"))
                    command.Parameters.AddWithValue("@Is_Alter", row.Item("Is_Alter"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_1", row.Item("Alternative_Insu_Code_1"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_2", row.Item("Alternative_Insu_Code_2"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_3", row.Item("Alternative_Insu_Code_3"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_4", row.Item("Alternative_Insu_Code_4"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_5", row.Item("Alternative_Insu_Code_5"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_6", row.Item("Alternative_Insu_Code_6"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_7", row.Item("Alternative_Insu_Code_7"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_8", row.Item("Alternative_Insu_Code_8"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_9", row.Item("Alternative_Insu_Code_9"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_10", row.Item("Alternative_Insu_Code_10"))
                    command.Parameters.AddWithValue("@Is_Agreement_Print", row.Item("Is_Agreement_Print"))
                    command.Parameters.AddWithValue("@Is_Instruction_Print", row.Item("Is_Instruction_Print"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime)
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''新增(設定單一Create_Time)
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function insertBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Order_Code , Effect_Date , End_Date , Self_Insu_Code , Apply_Status_Id ,  " & _
             " Equipment_License , Equipment_License_No , Product_Features , Use_Reason , Precautions ,  " & _
             " Side_Effect , Efficacy_Comparison , Insu_Order_Type_Id , Is_Alter , Alternative_Insu_Code_1 ,  " & _
             " Alternative_Insu_Code_2 , Alternative_Insu_Code_3 , Alternative_Insu_Code_4 , Alternative_Insu_Code_5 , Alternative_Insu_Code_6 ,  " & _
             " Alternative_Insu_Code_7 , Alternative_Insu_Code_8 , Alternative_Insu_Code_9 , Alternative_Insu_Code_10 , Is_Agreement_Print ,  " & _
             " Is_Instruction_Print , Create_User , Create_Time , Modified_User , Modified_Time " & _
             "  ) " & _
             " values( @Order_Code , @Effect_Date , @End_Date , @Self_Insu_Code , @Apply_Status_Id ,  " & _
             " @Equipment_License , @Equipment_License_No , @Product_Features , @Use_Reason , @Precautions ,  " & _
             " @Side_Effect , @Efficacy_Comparison , @Insu_Order_Type_Id , @Is_Alter , @Alternative_Insu_Code_1 ,  " & _
             " @Alternative_Insu_Code_2 , @Alternative_Insu_Code_3 , @Alternative_Insu_Code_4 , @Alternative_Insu_Code_5 , @Alternative_Insu_Code_6 ,  " & _
             " @Alternative_Insu_Code_7 , @Alternative_Insu_Code_8 , @Alternative_Insu_Code_9 , @Alternative_Insu_Code_10 , @Is_Agreement_Print ,  " & _
             " @Is_Instruction_Print , @Create_User , @Create_Time , @Modified_User , @Modified_Time " & _
             "              )"
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    command.Parameters.AddWithValue("@Self_Insu_Code", row.Item("Self_Insu_Code"))
                    command.Parameters.AddWithValue("@Apply_Status_Id", row.Item("Apply_Status_Id"))
                    command.Parameters.AddWithValue("@Equipment_License", row.Item("Equipment_License"))
                    command.Parameters.AddWithValue("@Equipment_License_No", row.Item("Equipment_License_No"))
                    command.Parameters.AddWithValue("@Product_Features", row.Item("Product_Features"))
                    command.Parameters.AddWithValue("@Use_Reason", row.Item("Use_Reason"))
                    command.Parameters.AddWithValue("@Precautions", row.Item("Precautions"))
                    command.Parameters.AddWithValue("@Side_Effect", row.Item("Side_Effect"))
                    command.Parameters.AddWithValue("@Efficacy_Comparison", row.Item("Efficacy_Comparison"))
                    command.Parameters.AddWithValue("@Insu_Order_Type_Id", row.Item("Insu_Order_Type_Id"))
                    command.Parameters.AddWithValue("@Is_Alter", row.Item("Is_Alter"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_1", row.Item("Alternative_Insu_Code_1"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_2", row.Item("Alternative_Insu_Code_2"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_3", row.Item("Alternative_Insu_Code_3"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_4", row.Item("Alternative_Insu_Code_4"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_5", row.Item("Alternative_Insu_Code_5"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_6", row.Item("Alternative_Insu_Code_6"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_7", row.Item("Alternative_Insu_Code_7"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_8", row.Item("Alternative_Insu_Code_8"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_9", row.Item("Alternative_Insu_Code_9"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_10", row.Item("Alternative_Insu_Code_10"))
                    command.Parameters.AddWithValue("@Is_Agreement_Print", row.Item("Is_Agreement_Print"))
                    command.Parameters.AddWithValue("@Is_Instruction_Print", row.Item("Is_Instruction_Print"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''以 SQL String 動態查詢
    ''' </summary>
    ''' <param name="sqlString">查詢的 SQL 字串</param>
    ''' <returns>查詢資料</returns>
    ''' <remarks>不建議直接使用此方法</remarks>
    Public Function dynamicQuery(ByRef sqlString As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString
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
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''動態查詢
    ''' </summary>
    ''' <param name="columnName">查詢的欄位名稱</param>
    ''' <param name="columnValue">查詢的欄位值</param>
    ''' <returns>查詢資料</returns>
    ''' <remarks></remarks>
    Public Function dynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object(), Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select * from " & tableName & " where 1=1 ")
            For i = 0 To columnName.Length - 1
                content.Append("and ").Append(columnName(i)).Append("=@").Append(columnName(i)).AppendLine(" ")
            Next
            command.CommandText = content.ToString
            For i = 0 To columnName.Length - 1
                command.Parameters.AddWithValue("@" & columnName(i), columnValue(i))
            Next
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
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function


    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByPK(ByRef pk_Order_Code As System.String, ByRef pk_Effect_Date As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getAuthenticConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  " & tableName & " where Order_Code=@Order_Code and Effect_Date=@Effect_Date            "
            command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
            command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
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
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function delete(ByRef pk_Order_Code As System.String, ByRef pk_Effect_Date As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Order_Code=@Order_Code and Effect_Date=@Effect_Date "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
                command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function update(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " End_Date=@End_Date , Self_Insu_Code=@Self_Insu_Code , Apply_Status_Id=@Apply_Status_Id " & _
            "  , Equipment_License=@Equipment_License , Equipment_License_No=@Equipment_License_No , Product_Features=@Product_Features , Use_Reason=@Use_Reason , Precautions=@Precautions " & _
            "  , Side_Effect=@Side_Effect , Efficacy_Comparison=@Efficacy_Comparison , Insu_Order_Type_Id=@Insu_Order_Type_Id , Is_Alter=@Is_Alter , Alternative_Insu_Code_1=@Alternative_Insu_Code_1 " & _
            "  , Alternative_Insu_Code_2=@Alternative_Insu_Code_2 , Alternative_Insu_Code_3=@Alternative_Insu_Code_3 , Alternative_Insu_Code_4=@Alternative_Insu_Code_4 , Alternative_Insu_Code_5=@Alternative_Insu_Code_5 , Alternative_Insu_Code_6=@Alternative_Insu_Code_6 " & _
            "  , Alternative_Insu_Code_7=@Alternative_Insu_Code_7 , Alternative_Insu_Code_8=@Alternative_Insu_Code_8 , Alternative_Insu_Code_9=@Alternative_Insu_Code_9 , Alternative_Insu_Code_10=@Alternative_Insu_Code_10 , Is_Agreement_Print=@Is_Agreement_Print " & _
            "  , Is_Instruction_Print=@Is_Instruction_Print , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            "  " & _
            " where  Order_Code=@Order_Code and Effect_Date=@Effect_Date            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    command.Parameters.AddWithValue("@Self_Insu_Code", row.Item("Self_Insu_Code"))
                    command.Parameters.AddWithValue("@Apply_Status_Id", row.Item("Apply_Status_Id"))
                    command.Parameters.AddWithValue("@Equipment_License", row.Item("Equipment_License"))
                    command.Parameters.AddWithValue("@Equipment_License_No", row.Item("Equipment_License_No"))
                    command.Parameters.AddWithValue("@Product_Features", row.Item("Product_Features"))
                    command.Parameters.AddWithValue("@Use_Reason", row.Item("Use_Reason"))
                    command.Parameters.AddWithValue("@Precautions", row.Item("Precautions"))
                    command.Parameters.AddWithValue("@Side_Effect", row.Item("Side_Effect"))
                    command.Parameters.AddWithValue("@Efficacy_Comparison", row.Item("Efficacy_Comparison"))
                    command.Parameters.AddWithValue("@Insu_Order_Type_Id", row.Item("Insu_Order_Type_Id"))
                    command.Parameters.AddWithValue("@Is_Alter", row.Item("Is_Alter"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_1", row.Item("Alternative_Insu_Code_1"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_2", row.Item("Alternative_Insu_Code_2"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_3", row.Item("Alternative_Insu_Code_3"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_4", row.Item("Alternative_Insu_Code_4"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_5", row.Item("Alternative_Insu_Code_5"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_6", row.Item("Alternative_Insu_Code_6"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_7", row.Item("Alternative_Insu_Code_7"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_8", row.Item("Alternative_Insu_Code_8"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_9", row.Item("Alternative_Insu_Code_9"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_10", row.Item("Alternative_Insu_Code_10"))
                    command.Parameters.AddWithValue("@Is_Agreement_Print", row.Item("Is_Agreement_Print"))
                    command.Parameters.AddWithValue("@Is_Instruction_Print", row.Item("Is_Instruction_Print"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''更新資料庫內容,設定單一Create_Time
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updateBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " End_Date=@End_Date , Self_Insu_Code=@Self_Insu_Code , Apply_Status_Id=@Apply_Status_Id " & _
            "  , Equipment_License=@Equipment_License , Equipment_License_No=@Equipment_License_No , Product_Features=@Product_Features , Use_Reason=@Use_Reason , Precautions=@Precautions " & _
            "  , Side_Effect=@Side_Effect , Efficacy_Comparison=@Efficacy_Comparison , Insu_Order_Type_Id=@Insu_Order_Type_Id , Is_Alter=@Is_Alter , Alternative_Insu_Code_1=@Alternative_Insu_Code_1 " & _
            "  , Alternative_Insu_Code_2=@Alternative_Insu_Code_2 , Alternative_Insu_Code_3=@Alternative_Insu_Code_3 , Alternative_Insu_Code_4=@Alternative_Insu_Code_4 , Alternative_Insu_Code_5=@Alternative_Insu_Code_5 , Alternative_Insu_Code_6=@Alternative_Insu_Code_6 " & _
            "  , Alternative_Insu_Code_7=@Alternative_Insu_Code_7 , Alternative_Insu_Code_8=@Alternative_Insu_Code_8 , Alternative_Insu_Code_9=@Alternative_Insu_Code_9 , Alternative_Insu_Code_10=@Alternative_Insu_Code_10 , Is_Agreement_Print=@Is_Agreement_Print " & _
            "  , Is_Instruction_Print=@Is_Instruction_Print , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            "  " & _
            " where  Order_Code=@Order_Code and Effect_Date=@Effect_Date            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    command.Parameters.AddWithValue("@Self_Insu_Code", row.Item("Self_Insu_Code"))
                    command.Parameters.AddWithValue("@Apply_Status_Id", row.Item("Apply_Status_Id"))
                    command.Parameters.AddWithValue("@Equipment_License", row.Item("Equipment_License"))
                    command.Parameters.AddWithValue("@Equipment_License_No", row.Item("Equipment_License_No"))
                    command.Parameters.AddWithValue("@Product_Features", row.Item("Product_Features"))
                    command.Parameters.AddWithValue("@Use_Reason", row.Item("Use_Reason"))
                    command.Parameters.AddWithValue("@Precautions", row.Item("Precautions"))
                    command.Parameters.AddWithValue("@Side_Effect", row.Item("Side_Effect"))
                    command.Parameters.AddWithValue("@Efficacy_Comparison", row.Item("Efficacy_Comparison"))
                    command.Parameters.AddWithValue("@Insu_Order_Type_Id", row.Item("Insu_Order_Type_Id"))
                    command.Parameters.AddWithValue("@Is_Alter", row.Item("Is_Alter"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_1", row.Item("Alternative_Insu_Code_1"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_2", row.Item("Alternative_Insu_Code_2"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_3", row.Item("Alternative_Insu_Code_3"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_4", row.Item("Alternative_Insu_Code_4"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_5", row.Item("Alternative_Insu_Code_5"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_6", row.Item("Alternative_Insu_Code_6"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_7", row.Item("Alternative_Insu_Code_7"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_8", row.Item("Alternative_Insu_Code_8"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_9", row.Item("Alternative_Insu_Code_9"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_10", row.Item("Alternative_Insu_Code_10"))
                    command.Parameters.AddWithValue("@Is_Agreement_Print", row.Item("Is_Agreement_Print"))
                    command.Parameters.AddWithValue("@Is_Instruction_Print", row.Item("Is_Instruction_Print"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''更新資料庫內容,傳入單一更新時間
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <param name="assignTime">單一更新時間</param>
    ''' <remarks></remarks>
    Public Function updateByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " End_Date=@End_Date , Self_Insu_Code=@Self_Insu_Code , Apply_Status_Id=@Apply_Status_Id " & _
            "  , Equipment_License=@Equipment_License , Equipment_License_No=@Equipment_License_No , Product_Features=@Product_Features , Use_Reason=@Use_Reason , Precautions=@Precautions " & _
            "  , Side_Effect=@Side_Effect , Efficacy_Comparison=@Efficacy_Comparison , Insu_Order_Type_Id=@Insu_Order_Type_Id , Is_Alter=@Is_Alter , Alternative_Insu_Code_1=@Alternative_Insu_Code_1 " & _
            "  , Alternative_Insu_Code_2=@Alternative_Insu_Code_2 , Alternative_Insu_Code_3=@Alternative_Insu_Code_3 , Alternative_Insu_Code_4=@Alternative_Insu_Code_4 , Alternative_Insu_Code_5=@Alternative_Insu_Code_5 , Alternative_Insu_Code_6=@Alternative_Insu_Code_6 " & _
            "  , Alternative_Insu_Code_7=@Alternative_Insu_Code_7 , Alternative_Insu_Code_8=@Alternative_Insu_Code_8 , Alternative_Insu_Code_9=@Alternative_Insu_Code_9 , Alternative_Insu_Code_10=@Alternative_Insu_Code_10 , Is_Agreement_Print=@Is_Agreement_Print " & _
            "  , Is_Instruction_Print=@Is_Instruction_Print , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            "  " & _
            " where  Order_Code=@Order_Code and Effect_Date=@Effect_Date            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                    command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    command.Parameters.AddWithValue("@Self_Insu_Code", row.Item("Self_Insu_Code"))
                    command.Parameters.AddWithValue("@Apply_Status_Id", row.Item("Apply_Status_Id"))
                    command.Parameters.AddWithValue("@Equipment_License", row.Item("Equipment_License"))
                    command.Parameters.AddWithValue("@Equipment_License_No", row.Item("Equipment_License_No"))
                    command.Parameters.AddWithValue("@Product_Features", row.Item("Product_Features"))
                    command.Parameters.AddWithValue("@Use_Reason", row.Item("Use_Reason"))
                    command.Parameters.AddWithValue("@Precautions", row.Item("Precautions"))
                    command.Parameters.AddWithValue("@Side_Effect", row.Item("Side_Effect"))
                    command.Parameters.AddWithValue("@Efficacy_Comparison", row.Item("Efficacy_Comparison"))
                    command.Parameters.AddWithValue("@Insu_Order_Type_Id", row.Item("Insu_Order_Type_Id"))
                    command.Parameters.AddWithValue("@Is_Alter", row.Item("Is_Alter"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_1", row.Item("Alternative_Insu_Code_1"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_2", row.Item("Alternative_Insu_Code_2"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_3", row.Item("Alternative_Insu_Code_3"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_4", row.Item("Alternative_Insu_Code_4"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_5", row.Item("Alternative_Insu_Code_5"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_6", row.Item("Alternative_Insu_Code_6"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_7", row.Item("Alternative_Insu_Code_7"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_8", row.Item("Alternative_Insu_Code_8"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_9", row.Item("Alternative_Insu_Code_9"))
                    command.Parameters.AddWithValue("@Alternative_Insu_Code_10", row.Item("Alternative_Insu_Code_10"))
                    command.Parameters.AddWithValue("@Is_Agreement_Print", row.Item("Is_Agreement_Print"))
                    command.Parameters.AddWithValue("@Is_Instruction_Print", row.Item("Is_Instruction_Print"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''取得表格 PUB_Material_Selfpay_Apply 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function


    ''' <summary>
    '''取得表格 PUB_Material_Selfpay_Apply 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>queryByPK 目前也用這個，因為是單檔查詢且為 PK 條件</remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

End Class
