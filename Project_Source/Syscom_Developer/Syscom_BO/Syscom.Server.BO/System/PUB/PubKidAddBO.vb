Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubKidAddBO
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:50
    Public Shared ReadOnly tableName As String="PUB_Kid_Add"
    Private Shared myInstance As PubKidAddBO
    Public Shared Function GetInstance() As PubKidAddBO
        If myInstance Is Nothing Then
            myInstance = New PubKidAddBO()
        End If 
        Return myInstance 
    End Function

#Region " 新增"

    ''' <summary>
    '''新增
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Function insert(ByVal ds As System.Data.DataSet,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String="insert into " & tableName & "(" & _
            " Effect_Date , Main_Identity_Id , Pt_From_Id , Order_Code , Age_Type_Id ,  " & _ 
             " Age_Start , Age_End , Kid_Add_Ratio , Dc , End_Date ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time ) " & _ 
             " values( @Effect_Date , @Main_Identity_Id , @Pt_From_Id , @Order_Code , @Age_Type_Id ,  " & _ 
             " @Age_Start , @Age_End , @Kid_Add_Ratio , @Dc , @End_Date ,  " & _ 
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time             )"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Main_Identity_Id", row.Item("Main_Identity_Id"))
                        Command.Parameters.AddWithValue("@Pt_From_Id", row.Item("Pt_From_Id"))
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Age_Type_Id", row.Item("Age_Type_Id"))
                        Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                        Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                        Command.Parameters.AddWithValue("@Kid_Add_Ratio", row.Item("Kid_Add_Ratio"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
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
    Public Function insertByAssignCreateTime(ByVal ds As System.Data.DataSet,ByVal assignTime As DateTime,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
             currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String="insert into " & tableName & "(" & _
            " Effect_Date , Main_Identity_Id , Pt_From_Id , Order_Code , Age_Type_Id ,  " & _ 
             " Age_Start , Age_End , Kid_Add_Ratio , Dc , End_Date ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time ) " & _ 
             " values( @Effect_Date , @Main_Identity_Id , @Pt_From_Id , @Order_Code , @Age_Type_Id ,  " & _ 
             " @Age_Start , @Age_End , @Kid_Add_Ratio , @Dc , @End_Date ,  " & _ 
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time             )"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Main_Identity_Id", row.Item("Main_Identity_Id"))
                        Command.Parameters.AddWithValue("@Pt_From_Id", row.Item("Pt_From_Id"))
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Age_Type_Id", row.Item("Age_Type_Id"))
                        Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                        Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                        Command.Parameters.AddWithValue("@Kid_Add_Ratio", row.Item("Kid_Add_Ratio"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
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
    Public Function insertBySetCreateTime(ByVal ds As System.Data.DataSet,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String="insert into " & tableName & "(" & _
            " Effect_Date , Main_Identity_Id , Pt_From_Id , Order_Code , Age_Type_Id ,  " & _ 
             " Age_Start , Age_End , Kid_Add_Ratio , Dc , End_Date ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time ) " & _ 
             " values( @Effect_Date , @Main_Identity_Id , @Pt_From_Id , @Order_Code , @Age_Type_Id ,  " & _ 
             " @Age_Start , @Age_End , @Kid_Add_Ratio , @Dc , @End_Date ,  " & _ 
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time             )"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Main_Identity_Id", row.Item("Main_Identity_Id"))
                        Command.Parameters.AddWithValue("@Pt_From_Id", row.Item("Pt_From_Id"))
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Age_Type_Id", row.Item("Age_Type_Id"))
                        Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                        Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                        Command.Parameters.AddWithValue("@Kid_Add_Ratio", row.Item("Kid_Add_Ratio"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB912", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
    End Function 

#End Region

#Region " 修改"

    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function update(ByVal ds As System.Data.DataSet,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String ="update " & tableName & " set " & _
            " Age_End=@Age_End , Kid_Add_Ratio=@Kid_Add_Ratio , Dc=@Dc , End_Date=@End_Date " & _ 
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Effect_Date=@Effect_Date and Main_Identity_Id=@Main_Identity_Id and Pt_From_Id=@Pt_From_Id and Order_Code=@Order_Code and Age_Type_Id=@Age_Type_Id and  " & _ 
            " Age_Start=@Age_Start            "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                          .CommandText = sqlString
                          .CommandType = CommandType.Text
                          .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Main_Identity_Id", row.Item("Main_Identity_Id"))
                        Command.Parameters.AddWithValue("@Pt_From_Id", row.Item("Pt_From_Id"))
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Age_Type_Id", row.Item("Age_Type_Id"))
                        Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                        Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                        Command.Parameters.AddWithValue("@Kid_Add_Ratio", row.Item("Kid_Add_Ratio"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB913", ex)
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
    Public Function updateBySetCreateTime(ByVal ds As System.Data.DataSet,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String ="update " & tableName & " set " & _
            " Age_End=@Age_End , Kid_Add_Ratio=@Kid_Add_Ratio , Dc=@Dc , End_Date=@End_Date " & _ 
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Effect_Date=@Effect_Date and Main_Identity_Id=@Main_Identity_Id and Pt_From_Id=@Pt_From_Id and Order_Code=@Order_Code and Age_Type_Id=@Age_Type_Id and  " & _ 
            " Age_Start=@Age_Start            "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                          .CommandText = sqlString
                          .CommandType = CommandType.Text
                          .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Main_Identity_Id", row.Item("Main_Identity_Id"))
                        Command.Parameters.AddWithValue("@Pt_From_Id", row.Item("Pt_From_Id"))
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Age_Type_Id", row.Item("Age_Type_Id"))
                        Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                        Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                        Command.Parameters.AddWithValue("@Kid_Add_Ratio", row.Item("Kid_Add_Ratio"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB913", ex)
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
    Public Function updateByAssignCreateTime(ByVal ds As System.Data.DataSet,ByVal assignTime As DateTime,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String ="update " & tableName & " set " & _
            " Age_End=@Age_End , Kid_Add_Ratio=@Kid_Add_Ratio , Dc=@Dc , End_Date=@End_Date " & _ 
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            " where  Effect_Date=@Effect_Date and Main_Identity_Id=@Main_Identity_Id and Pt_From_Id=@Pt_From_Id and Order_Code=@Order_Code and Age_Type_Id=@Age_Type_Id and  " & _ 
            " Age_Start=@Age_Start            "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                          .CommandText = sqlString
                          .CommandType = CommandType.Text
                          .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Main_Identity_Id", row.Item("Main_Identity_Id"))
                        Command.Parameters.AddWithValue("@Pt_From_Id", row.Item("Pt_From_Id"))
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Age_Type_Id", row.Item("Age_Type_Id"))
                        Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                        Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                        Command.Parameters.AddWithValue("@Kid_Add_Ratio", row.Item("Kid_Add_Ratio"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB913", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
    End Function 

#End Region

#Region " 刪除"

    ''' <summary>
    '''以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function delete(ByRef pk_Effect_Date As System.DateTime,ByRef pk_Main_Identity_Id As System.String,ByRef pk_Pt_From_Id As System.String,ByRef pk_Order_Code As System.String,ByRef pk_Age_Type_Id As System.String,ByRef pk_Age_Start As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Effect_Date=@Effect_Date and Main_Identity_Id=@Main_Identity_Id and Pt_From_Id=@Pt_From_Id and Order_Code=@Order_Code and Age_Type_Id=@Age_Type_Id and  " & _ 
            " Age_Start=@Age_Start "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
                Using command As SqlCommand = New SqlCommand
                With Command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                Command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
                Command.Parameters.AddWithValue("@Main_Identity_Id", pk_Main_Identity_Id)
                Command.Parameters.AddWithValue("@Pt_From_Id", pk_Pt_From_Id)
                Command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
                Command.Parameters.AddWithValue("@Age_Type_Id", pk_Age_Type_Id)
                Command.Parameters.AddWithValue("@Age_Start", pk_Age_Start)
                count = Command.ExecuteNonQuery
                End Using
            Return count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB914", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
    End Function 

#End Region

#Region " 查詢"

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByPK(ByRef pk_Effect_Date As System.DateTime,ByRef pk_Main_Identity_Id As System.String,ByRef pk_Pt_From_Id As System.String,ByRef pk_Order_Code As System.String,ByRef pk_Age_Type_Id As System.String,ByRef pk_Age_Start As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder 
            content.AppendLine("select   ")
            content.AppendLine(" Effect_Date , Main_Identity_Id , Pt_From_Id , Order_Code , Age_Type_Id ,  ") 
            content.AppendLine(" Age_Start , Age_End , Kid_Add_Ratio , Dc , End_Date ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Effect_Date=@Effect_Date and Main_Identity_Id=@Main_Identity_Id and Pt_From_Id=@Pt_From_Id and Order_Code=@Order_Code and Age_Type_Id=@Age_Type_Id and Age_Start=@Age_Start            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Effect_Date",pk_Effect_Date)
            Command.Parameters.AddWithValue("@Main_Identity_Id",pk_Main_Identity_Id)
            Command.Parameters.AddWithValue("@Pt_From_Id",pk_Pt_From_Id)
            Command.Parameters.AddWithValue("@Order_Code",pk_Order_Code)
            Command.Parameters.AddWithValue("@Age_Type_Id",pk_Age_Type_Id)
            Command.Parameters.AddWithValue("@Age_Start",pk_Age_Start)
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
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
    End Function 

    ''' <summary>
    '''以ＰＫ Like 的方式查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByLikePK(ByRef pk_Effect_Date As System.DateTime,ByRef pk_Main_Identity_Id As System.String,ByRef pk_Pt_From_Id As System.String,ByRef pk_Order_Code As System.String,ByRef pk_Age_Type_Id As System.String,ByRef pk_Age_Start As System.Int32,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder 
            content.AppendLine("select   ")
            content.AppendLine(" Effect_Date , Main_Identity_Id , Pt_From_Id , Order_Code , Age_Type_Id ,  ") 
            content.AppendLine(" Age_Start , Age_End , Kid_Add_Ratio , Dc , End_Date ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time                from " & tableName)
            content.AppendLine("   where Effect_Date like @Effect_Date and Main_Identity_Id like @Main_Identity_Id and Pt_From_Id like @Pt_From_Id and Order_Code like @Order_Code and Age_Type_Id like @Age_Type_Id and Age_Start like @Age_Start "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Effect_Date",pk_Effect_Date & "%")
            Command.Parameters.AddWithValue("@Main_Identity_Id",pk_Main_Identity_Id & "%")
            Command.Parameters.AddWithValue("@Pt_From_Id",pk_Pt_From_Id & "%")
            Command.Parameters.AddWithValue("@Order_Code",pk_Order_Code & "%")
            Command.Parameters.AddWithValue("@Age_Type_Id",pk_Age_Type_Id & "%")
            Command.Parameters.AddWithValue("@Age_Start",pk_Age_Start & "%")
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
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
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
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder 
            content.AppendLine("select   ")
            content.AppendLine(" Effect_Date , Main_Identity_Id , Pt_From_Id , Order_Code , Age_Type_Id ,  ") 
            content.AppendLine(" Age_Start , Age_End , Kid_Add_Ratio , Dc , End_Date ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time                from " & tableName )
            command.CommandText = content .tostring
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
            Throw New CommonException("CMMCMMB911", ex)
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
    Public Function dynamicQuery(ByRef sqlString As String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = sqlString
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
            Throw New CommonException("CMMCMMB911", ex)
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
    Public Function dynamicQueryWithColumnValue(ByRef columnName As String(), ByRef columnValue As Object(),Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select   Effect_Date , Main_Identity_Id , Pt_From_Id , Order_Code , Age_Type_Id ,  " & _ 
             " Age_Start , Age_End , Kid_Add_Ratio , Dc , End_Date ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time            from " & tableName & " where 1=1 ")
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
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMB911", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
    End Function


#End Region

#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Kid_Add 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Kid_Add 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
