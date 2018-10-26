Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubPreventiveCareBO
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:53
    Public Shared ReadOnly tableName As String="PUB_Preventive_Care"
    Private Shared myInstance As PubPreventiveCareBO
    Public Shared Function GetInstance() As PubPreventiveCareBO
        If myInstance Is Nothing Then
            myInstance = New PubPreventiveCareBO()
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
            " Care_Item_Code , Care_Order_Code , Care_Cardseq , Care_Cardseq_Name , Age_Control_Id ,  " & _ 
             " Age_Start , Age_End , Preventive_Care_Memo , Package_Code , Limit_Sex_Id ,  " & _ 
             " Filter_Desc , Advisory_Unit , Opd_Memo , Preventive_Care_Note ) " & _ 
             " values( @Care_Item_Code , @Care_Order_Code , @Care_Cardseq , @Care_Cardseq_Name , @Age_Control_Id ,  " & _ 
             " @Age_Start , @Age_End , @Preventive_Care_Memo , @Package_Code , @Limit_Sex_Id ,  " & _ 
             " @Filter_Desc , @Advisory_Unit , @Opd_Memo , @Preventive_Care_Note             )"
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
                        Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                        Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                        Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                        Command.Parameters.AddWithValue("@Care_Cardseq_Name", row.Item("Care_Cardseq_Name"))
                        Command.Parameters.AddWithValue("@Age_Control_Id", row.Item("Age_Control_Id"))
                        Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                        Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                        Command.Parameters.AddWithValue("@Preventive_Care_Memo", row.Item("Preventive_Care_Memo"))
                        Command.Parameters.AddWithValue("@Package_Code", row.Item("Package_Code"))
                        Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                        Command.Parameters.AddWithValue("@Filter_Desc", row.Item("Filter_Desc"))
                        Command.Parameters.AddWithValue("@Advisory_Unit", row.Item("Advisory_Unit"))
                        Command.Parameters.AddWithValue("@Opd_Memo", row.Item("Opd_Memo"))
                        Command.Parameters.AddWithValue("@Preventive_Care_Note", row.Item("Preventive_Care_Note"))
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
            " Care_Item_Code , Care_Order_Code , Care_Cardseq , Care_Cardseq_Name , Age_Control_Id ,  " & _ 
             " Age_Start , Age_End , Preventive_Care_Memo , Package_Code , Limit_Sex_Id ,  " & _ 
             " Filter_Desc , Advisory_Unit , Opd_Memo , Preventive_Care_Note ) " & _ 
             " values( @Care_Item_Code , @Care_Order_Code , @Care_Cardseq , @Care_Cardseq_Name , @Age_Control_Id ,  " & _ 
             " @Age_Start , @Age_End , @Preventive_Care_Memo , @Package_Code , @Limit_Sex_Id ,  " & _ 
             " @Filter_Desc , @Advisory_Unit , @Opd_Memo , @Preventive_Care_Note             )"
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
                        Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                        Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                        Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                        Command.Parameters.AddWithValue("@Care_Cardseq_Name", row.Item("Care_Cardseq_Name"))
                        Command.Parameters.AddWithValue("@Age_Control_Id", row.Item("Age_Control_Id"))
                        Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                        Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                        Command.Parameters.AddWithValue("@Preventive_Care_Memo", row.Item("Preventive_Care_Memo"))
                        Command.Parameters.AddWithValue("@Package_Code", row.Item("Package_Code"))
                        Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                        Command.Parameters.AddWithValue("@Filter_Desc", row.Item("Filter_Desc"))
                        Command.Parameters.AddWithValue("@Advisory_Unit", row.Item("Advisory_Unit"))
                        Command.Parameters.AddWithValue("@Opd_Memo", row.Item("Opd_Memo"))
                        Command.Parameters.AddWithValue("@Preventive_Care_Note", row.Item("Preventive_Care_Note"))
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
            " Care_Item_Code , Care_Order_Code , Care_Cardseq , Care_Cardseq_Name , Age_Control_Id ,  " & _ 
             " Age_Start , Age_End , Preventive_Care_Memo , Package_Code , Limit_Sex_Id ,  " & _ 
             " Filter_Desc , Advisory_Unit , Opd_Memo , Preventive_Care_Note ) " & _ 
             " values( @Care_Item_Code , @Care_Order_Code , @Care_Cardseq , @Care_Cardseq_Name , @Age_Control_Id ,  " & _ 
             " @Age_Start , @Age_End , @Preventive_Care_Memo , @Package_Code , @Limit_Sex_Id ,  " & _ 
             " @Filter_Desc , @Advisory_Unit , @Opd_Memo , @Preventive_Care_Note             )"
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
                        Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                        Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                        Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                        Command.Parameters.AddWithValue("@Care_Cardseq_Name", row.Item("Care_Cardseq_Name"))
                        Command.Parameters.AddWithValue("@Age_Control_Id", row.Item("Age_Control_Id"))
                        Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                        Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                        Command.Parameters.AddWithValue("@Preventive_Care_Memo", row.Item("Preventive_Care_Memo"))
                        Command.Parameters.AddWithValue("@Package_Code", row.Item("Package_Code"))
                        Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                        Command.Parameters.AddWithValue("@Filter_Desc", row.Item("Filter_Desc"))
                        Command.Parameters.AddWithValue("@Advisory_Unit", row.Item("Advisory_Unit"))
                        Command.Parameters.AddWithValue("@Opd_Memo", row.Item("Opd_Memo"))
                        Command.Parameters.AddWithValue("@Preventive_Care_Note", row.Item("Preventive_Care_Note"))
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
            " Care_Cardseq_Name=@Care_Cardseq_Name , Age_Control_Id=@Age_Control_Id " & _ 
            "  , Age_Start=@Age_Start , Age_End=@Age_End , Preventive_Care_Memo=@Preventive_Care_Memo , Package_Code=@Package_Code , Limit_Sex_Id=@Limit_Sex_Id " & _ 
            "  , Filter_Desc=@Filter_Desc , Advisory_Unit=@Advisory_Unit , Opd_Memo=@Opd_Memo , Preventive_Care_Note=@Preventive_Care_Note " & _ 
            " where  Care_Item_Code=@Care_Item_Code and Care_Order_Code=@Care_Order_Code and Care_Cardseq=@Care_Cardseq            "
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
                        Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                        Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                        Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                        Command.Parameters.AddWithValue("@Care_Cardseq_Name", row.Item("Care_Cardseq_Name"))
                        Command.Parameters.AddWithValue("@Age_Control_Id", row.Item("Age_Control_Id"))
                        Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                        Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                        Command.Parameters.AddWithValue("@Preventive_Care_Memo", row.Item("Preventive_Care_Memo"))
                        Command.Parameters.AddWithValue("@Package_Code", row.Item("Package_Code"))
                        Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                        Command.Parameters.AddWithValue("@Filter_Desc", row.Item("Filter_Desc"))
                        Command.Parameters.AddWithValue("@Advisory_Unit", row.Item("Advisory_Unit"))
                        Command.Parameters.AddWithValue("@Opd_Memo", row.Item("Opd_Memo"))
                        Command.Parameters.AddWithValue("@Preventive_Care_Note", row.Item("Preventive_Care_Note"))
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
            " Care_Cardseq_Name=@Care_Cardseq_Name , Age_Control_Id=@Age_Control_Id " & _ 
            "  , Age_Start=@Age_Start , Age_End=@Age_End , Preventive_Care_Memo=@Preventive_Care_Memo , Package_Code=@Package_Code , Limit_Sex_Id=@Limit_Sex_Id " & _ 
            "  , Filter_Desc=@Filter_Desc , Advisory_Unit=@Advisory_Unit , Opd_Memo=@Opd_Memo , Preventive_Care_Note=@Preventive_Care_Note " & _ 
            " where  Care_Item_Code=@Care_Item_Code and Care_Order_Code=@Care_Order_Code and Care_Cardseq=@Care_Cardseq            "
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
                        Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                        Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                        Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                        Command.Parameters.AddWithValue("@Care_Cardseq_Name", row.Item("Care_Cardseq_Name"))
                        Command.Parameters.AddWithValue("@Age_Control_Id", row.Item("Age_Control_Id"))
                        Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                        Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                        Command.Parameters.AddWithValue("@Preventive_Care_Memo", row.Item("Preventive_Care_Memo"))
                        Command.Parameters.AddWithValue("@Package_Code", row.Item("Package_Code"))
                        Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                        Command.Parameters.AddWithValue("@Filter_Desc", row.Item("Filter_Desc"))
                        Command.Parameters.AddWithValue("@Advisory_Unit", row.Item("Advisory_Unit"))
                        Command.Parameters.AddWithValue("@Opd_Memo", row.Item("Opd_Memo"))
                        Command.Parameters.AddWithValue("@Preventive_Care_Note", row.Item("Preventive_Care_Note"))
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
            " Care_Cardseq_Name=@Care_Cardseq_Name , Age_Control_Id=@Age_Control_Id " & _ 
            "  , Age_Start=@Age_Start , Age_End=@Age_End , Preventive_Care_Memo=@Preventive_Care_Memo , Package_Code=@Package_Code , Limit_Sex_Id=@Limit_Sex_Id " & _ 
            "  , Filter_Desc=@Filter_Desc , Advisory_Unit=@Advisory_Unit , Opd_Memo=@Opd_Memo , Preventive_Care_Note=@Preventive_Care_Note " & _ 
            " where  Care_Item_Code=@Care_Item_Code and Care_Order_Code=@Care_Order_Code and Care_Cardseq=@Care_Cardseq            "
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
                        Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                        Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                        Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                        Command.Parameters.AddWithValue("@Care_Cardseq_Name", row.Item("Care_Cardseq_Name"))
                        Command.Parameters.AddWithValue("@Age_Control_Id", row.Item("Age_Control_Id"))
                        Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                        Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                        Command.Parameters.AddWithValue("@Preventive_Care_Memo", row.Item("Preventive_Care_Memo"))
                        Command.Parameters.AddWithValue("@Package_Code", row.Item("Package_Code"))
                        Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                        Command.Parameters.AddWithValue("@Filter_Desc", row.Item("Filter_Desc"))
                        Command.Parameters.AddWithValue("@Advisory_Unit", row.Item("Advisory_Unit"))
                        Command.Parameters.AddWithValue("@Opd_Memo", row.Item("Opd_Memo"))
                        Command.Parameters.AddWithValue("@Preventive_Care_Note", row.Item("Preventive_Care_Note"))
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
    Public Function delete(ByRef pk_Care_Item_Code As System.String,ByRef pk_Care_Order_Code As System.String,ByRef pk_Care_Cardseq As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Care_Item_Code=@Care_Item_Code and Care_Order_Code=@Care_Order_Code and Care_Cardseq=@Care_Cardseq "
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
                Command.Parameters.AddWithValue("@Care_Item_Code", pk_Care_Item_Code)
                Command.Parameters.AddWithValue("@Care_Order_Code", pk_Care_Order_Code)
                Command.Parameters.AddWithValue("@Care_Cardseq", pk_Care_Cardseq)
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
    Public Function queryByPK(ByRef pk_Care_Item_Code As System.String,ByRef pk_Care_Order_Code As System.String,ByRef pk_Care_Cardseq As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Care_Item_Code , Care_Order_Code , Care_Cardseq , Care_Cardseq_Name , Age_Control_Id ,  ") 
            content.AppendLine(" Age_Start , Age_End , Preventive_Care_Memo , Package_Code , Limit_Sex_Id ,  ") 
            content.AppendLine(" Filter_Desc , Advisory_Unit , Opd_Memo , Preventive_Care_Note                from " & tableName)
            content.AppendLine("   where Care_Item_Code=@Care_Item_Code and Care_Order_Code=@Care_Order_Code and Care_Cardseq=@Care_Cardseq            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Care_Item_Code",pk_Care_Item_Code)
            Command.Parameters.AddWithValue("@Care_Order_Code",pk_Care_Order_Code)
            Command.Parameters.AddWithValue("@Care_Cardseq",pk_Care_Cardseq)
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
    Public Function queryByLikePK(ByRef pk_Care_Item_Code As System.String,ByRef pk_Care_Order_Code As System.String,ByRef pk_Care_Cardseq As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Care_Item_Code , Care_Order_Code , Care_Cardseq , Care_Cardseq_Name , Age_Control_Id ,  ") 
            content.AppendLine(" Age_Start , Age_End , Preventive_Care_Memo , Package_Code , Limit_Sex_Id ,  ") 
            content.AppendLine(" Filter_Desc , Advisory_Unit , Opd_Memo , Preventive_Care_Note                from " & tableName)
            content.AppendLine("   where Care_Item_Code like @Care_Item_Code and Care_Order_Code like @Care_Order_Code and Care_Cardseq like @Care_Cardseq "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Care_Item_Code",pk_Care_Item_Code & "%")
            Command.Parameters.AddWithValue("@Care_Order_Code",pk_Care_Order_Code & "%")
            Command.Parameters.AddWithValue("@Care_Cardseq",pk_Care_Cardseq & "%")
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
            content.AppendLine(" Care_Item_Code , Care_Order_Code , Care_Cardseq , Care_Cardseq_Name , Age_Control_Id ,  ") 
            content.AppendLine(" Age_Start , Age_End , Preventive_Care_Memo , Package_Code , Limit_Sex_Id ,  ") 
            content.AppendLine(" Filter_Desc , Advisory_Unit , Opd_Memo , Preventive_Care_Note                from " & tableName )
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
            content.Append("select   Care_Item_Code , Care_Order_Code , Care_Cardseq , Care_Cardseq_Name , Age_Control_Id ,  " & _ 
             " Age_Start , Age_End , Preventive_Care_Memo , Package_Code , Limit_Sex_Id ,  " & _ 
             " Filter_Desc , Advisory_Unit , Opd_Memo , Preventive_Care_Note            from " & tableName & " where 1=1 ")
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
    '''取得表格 PUB_Preventive_Care 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Preventive_Care 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
