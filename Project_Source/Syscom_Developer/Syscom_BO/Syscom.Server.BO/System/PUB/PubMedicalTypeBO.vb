Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubMedicalTypeBO
    'Syscom's CodeGen Produced This VB Code @ 2015/11/11 上午 11:01:34
    Public Shared ReadOnly tableName As String = "PUB_Medical_Type"
    Private Shared myInstance As PubMedicalTypeBO
    Public Shared Function GetInstance() As PubMedicalTypeBO
        If myInstance Is Nothing Then
            myInstance = New PubMedicalTypeBO()
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
    Public Function insert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Medical_Type_Id , Medical_Type_Name , Medical_Type_Ctrl_Id , Dis_Identity_Code , Contract_Code1 ,  " & _
             " Contract_Code2 , Part_Code , Card_Sn , IC_Medical_Type_Id , Case_Type_Id ,  " & _
             " Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _
             " PED_Sort , SUR_Sort , MED_Sort , ENT_Sort , URO_Sort ,  " & _
             " REH_Sort , IPD_Sort , Is_Register_Fee , Is_Examine , Is_Pha_Services ,  " & _
             " OPD_Sort , EMG_Sort ) " & _
             " values( @Medical_Type_Id , @Medical_Type_Name , @Medical_Type_Ctrl_Id , @Dis_Identity_Code , @Contract_Code1 ,  " & _
             " @Contract_Code2 , @Part_Code , @Card_Sn , @IC_Medical_Type_Id , @Case_Type_Id ,  " & _
             " @Dc , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _
             " @PED_Sort , @SUR_Sort , @MED_Sort , @ENT_Sort , @URO_Sort ,  " & _
             " @REH_Sort , @IPD_Sort , @Is_Register_Fee , @Is_Examine , @Is_Pha_Services ,  " & _
             " @OPD_Sort , @EMG_Sort             )"
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
                    Command.Parameters.AddWithValue("@Medical_Type_Id", row.Item("Medical_Type_Id"))
                    Command.Parameters.AddWithValue("@Medical_Type_Name", row.Item("Medical_Type_Name"))
                    Command.Parameters.AddWithValue("@Medical_Type_Ctrl_Id", row.Item("Medical_Type_Ctrl_Id"))
                    Command.Parameters.AddWithValue("@Dis_Identity_Code", row.Item("Dis_Identity_Code"))
                    Command.Parameters.AddWithValue("@Contract_Code1", row.Item("Contract_Code1"))
                    Command.Parameters.AddWithValue("@Contract_Code2", row.Item("Contract_Code2"))
                    Command.Parameters.AddWithValue("@Part_Code", row.Item("Part_Code"))
                    Command.Parameters.AddWithValue("@Card_Sn", row.Item("Card_Sn"))
                    Command.Parameters.AddWithValue("@IC_Medical_Type_Id", row.Item("IC_Medical_Type_Id"))
                    Command.Parameters.AddWithValue("@Case_Type_Id", row.Item("Case_Type_Id"))
                    Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                    Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    Command.Parameters.AddWithValue("@Create_Time", currentTime)
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@PED_Sort", row.Item("PED_Sort"))
                    Command.Parameters.AddWithValue("@SUR_Sort", row.Item("SUR_Sort"))
                    Command.Parameters.AddWithValue("@MED_Sort", row.Item("MED_Sort"))
                    Command.Parameters.AddWithValue("@ENT_Sort", row.Item("ENT_Sort"))
                    Command.Parameters.AddWithValue("@URO_Sort", row.Item("URO_Sort"))
                    Command.Parameters.AddWithValue("@REH_Sort", row.Item("REH_Sort"))
                    Command.Parameters.AddWithValue("@IPD_Sort", row.Item("IPD_Sort"))
                    Command.Parameters.AddWithValue("@Is_Register_Fee", row.Item("Is_Register_Fee"))
                    Command.Parameters.AddWithValue("@Is_Examine", row.Item("Is_Examine"))
                    Command.Parameters.AddWithValue("@Is_Pha_Services", row.Item("Is_Pha_Services"))
                    Command.Parameters.AddWithValue("@OPD_Sort", row.Item("OPD_Sort"))
                    Command.Parameters.AddWithValue("@EMG_Sort", row.Item("EMG_Sort"))
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
    Public Function insertByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Medical_Type_Id , Medical_Type_Name , Medical_Type_Ctrl_Id , Dis_Identity_Code , Contract_Code1 ,  " & _
             " Contract_Code2 , Part_Code , Card_Sn , IC_Medical_Type_Id , Case_Type_Id ,  " & _
             " Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _
             " PED_Sort , SUR_Sort , MED_Sort , ENT_Sort , URO_Sort ,  " & _
             " REH_Sort , IPD_Sort , Is_Register_Fee , Is_Examine , Is_Pha_Services ,  " & _
             " OPD_Sort , EMG_Sort ) " & _
             " values( @Medical_Type_Id , @Medical_Type_Name , @Medical_Type_Ctrl_Id , @Dis_Identity_Code , @Contract_Code1 ,  " & _
             " @Contract_Code2 , @Part_Code , @Card_Sn , @IC_Medical_Type_Id , @Case_Type_Id ,  " & _
             " @Dc , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _
             " @PED_Sort , @SUR_Sort , @MED_Sort , @ENT_Sort , @URO_Sort ,  " & _
             " @REH_Sort , @IPD_Sort , @Is_Register_Fee , @Is_Examine , @Is_Pha_Services ,  " & _
             " @OPD_Sort , @EMG_Sort             )"
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
                    Command.Parameters.AddWithValue("@Medical_Type_Id", row.Item("Medical_Type_Id"))
                    Command.Parameters.AddWithValue("@Medical_Type_Name", row.Item("Medical_Type_Name"))
                    Command.Parameters.AddWithValue("@Medical_Type_Ctrl_Id", row.Item("Medical_Type_Ctrl_Id"))
                    Command.Parameters.AddWithValue("@Dis_Identity_Code", row.Item("Dis_Identity_Code"))
                    Command.Parameters.AddWithValue("@Contract_Code1", row.Item("Contract_Code1"))
                    Command.Parameters.AddWithValue("@Contract_Code2", row.Item("Contract_Code2"))
                    Command.Parameters.AddWithValue("@Part_Code", row.Item("Part_Code"))
                    Command.Parameters.AddWithValue("@Card_Sn", row.Item("Card_Sn"))
                    Command.Parameters.AddWithValue("@IC_Medical_Type_Id", row.Item("IC_Medical_Type_Id"))
                    Command.Parameters.AddWithValue("@Case_Type_Id", row.Item("Case_Type_Id"))
                    Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                    Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    Command.Parameters.AddWithValue("@Create_Time", currentTime)
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@PED_Sort", row.Item("PED_Sort"))
                    Command.Parameters.AddWithValue("@SUR_Sort", row.Item("SUR_Sort"))
                    Command.Parameters.AddWithValue("@MED_Sort", row.Item("MED_Sort"))
                    Command.Parameters.AddWithValue("@ENT_Sort", row.Item("ENT_Sort"))
                    Command.Parameters.AddWithValue("@URO_Sort", row.Item("URO_Sort"))
                    Command.Parameters.AddWithValue("@REH_Sort", row.Item("REH_Sort"))
                    Command.Parameters.AddWithValue("@IPD_Sort", row.Item("IPD_Sort"))
                    Command.Parameters.AddWithValue("@Is_Register_Fee", row.Item("Is_Register_Fee"))
                    Command.Parameters.AddWithValue("@Is_Examine", row.Item("Is_Examine"))
                    Command.Parameters.AddWithValue("@Is_Pha_Services", row.Item("Is_Pha_Services"))
                    Command.Parameters.AddWithValue("@OPD_Sort", row.Item("OPD_Sort"))
                    Command.Parameters.AddWithValue("@EMG_Sort", row.Item("EMG_Sort"))
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
    Public Function insertBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Medical_Type_Id , Medical_Type_Name , Medical_Type_Ctrl_Id , Dis_Identity_Code , Contract_Code1 ,  " & _
             " Contract_Code2 , Part_Code , Card_Sn , IC_Medical_Type_Id , Case_Type_Id ,  " & _
             " Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _
             " PED_Sort , SUR_Sort , MED_Sort , ENT_Sort , URO_Sort ,  " & _
             " REH_Sort , IPD_Sort , Is_Register_Fee , Is_Examine , Is_Pha_Services ,  " & _
             " OPD_Sort , EMG_Sort ) " & _
             " values( @Medical_Type_Id , @Medical_Type_Name , @Medical_Type_Ctrl_Id , @Dis_Identity_Code , @Contract_Code1 ,  " & _
             " @Contract_Code2 , @Part_Code , @Card_Sn , @IC_Medical_Type_Id , @Case_Type_Id ,  " & _
             " @Dc , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _
             " @PED_Sort , @SUR_Sort , @MED_Sort , @ENT_Sort , @URO_Sort ,  " & _
             " @REH_Sort , @IPD_Sort , @Is_Register_Fee , @Is_Examine , @Is_Pha_Services ,  " & _
             " @OPD_Sort , @EMG_Sort             )"
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
                    Command.Parameters.AddWithValue("@Medical_Type_Id", row.Item("Medical_Type_Id"))
                    Command.Parameters.AddWithValue("@Medical_Type_Name", row.Item("Medical_Type_Name"))
                    Command.Parameters.AddWithValue("@Medical_Type_Ctrl_Id", row.Item("Medical_Type_Ctrl_Id"))
                    Command.Parameters.AddWithValue("@Dis_Identity_Code", row.Item("Dis_Identity_Code"))
                    Command.Parameters.AddWithValue("@Contract_Code1", row.Item("Contract_Code1"))
                    Command.Parameters.AddWithValue("@Contract_Code2", row.Item("Contract_Code2"))
                    Command.Parameters.AddWithValue("@Part_Code", row.Item("Part_Code"))
                    Command.Parameters.AddWithValue("@Card_Sn", row.Item("Card_Sn"))
                    Command.Parameters.AddWithValue("@IC_Medical_Type_Id", row.Item("IC_Medical_Type_Id"))
                    Command.Parameters.AddWithValue("@Case_Type_Id", row.Item("Case_Type_Id"))
                    Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                    Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                    Command.Parameters.AddWithValue("@PED_Sort", row.Item("PED_Sort"))
                    Command.Parameters.AddWithValue("@SUR_Sort", row.Item("SUR_Sort"))
                    Command.Parameters.AddWithValue("@MED_Sort", row.Item("MED_Sort"))
                    Command.Parameters.AddWithValue("@ENT_Sort", row.Item("ENT_Sort"))
                    Command.Parameters.AddWithValue("@URO_Sort", row.Item("URO_Sort"))
                    Command.Parameters.AddWithValue("@REH_Sort", row.Item("REH_Sort"))
                    Command.Parameters.AddWithValue("@IPD_Sort", row.Item("IPD_Sort"))
                    Command.Parameters.AddWithValue("@Is_Register_Fee", row.Item("Is_Register_Fee"))
                    Command.Parameters.AddWithValue("@Is_Examine", row.Item("Is_Examine"))
                    Command.Parameters.AddWithValue("@Is_Pha_Services", row.Item("Is_Pha_Services"))
                    Command.Parameters.AddWithValue("@OPD_Sort", row.Item("OPD_Sort"))
                    Command.Parameters.AddWithValue("@EMG_Sort", row.Item("EMG_Sort"))
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
    Public Function update(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Medical_Type_Name=@Medical_Type_Name , Medical_Type_Ctrl_Id=@Medical_Type_Ctrl_Id , Dis_Identity_Code=@Dis_Identity_Code , Contract_Code1=@Contract_Code1 " & _
            "  , Contract_Code2=@Contract_Code2 , Part_Code=@Part_Code , Card_Sn=@Card_Sn , IC_Medical_Type_Id=@IC_Medical_Type_Id , Case_Type_Id=@Case_Type_Id " & _
            "  , Dc=@Dc , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            "  , PED_Sort=@PED_Sort , SUR_Sort=@SUR_Sort , MED_Sort=@MED_Sort , ENT_Sort=@ENT_Sort , URO_Sort=@URO_Sort " & _
            "  , REH_Sort=@REH_Sort , IPD_Sort=@IPD_Sort , Is_Register_Fee=@Is_Register_Fee , Is_Examine=@Is_Examine , Is_Pha_Services=@Is_Pha_Services " & _
            "  , OPD_Sort=@OPD_Sort , EMG_Sort=@EMG_Sort " & _
            " where  Medical_Type_Id=@Medical_Type_Id            "
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
                    Command.Parameters.AddWithValue("@Medical_Type_Id", row.Item("Medical_Type_Id"))
                    Command.Parameters.AddWithValue("@Medical_Type_Name", row.Item("Medical_Type_Name"))
                    Command.Parameters.AddWithValue("@Medical_Type_Ctrl_Id", row.Item("Medical_Type_Ctrl_Id"))
                    Command.Parameters.AddWithValue("@Dis_Identity_Code", row.Item("Dis_Identity_Code"))
                    Command.Parameters.AddWithValue("@Contract_Code1", row.Item("Contract_Code1"))
                    Command.Parameters.AddWithValue("@Contract_Code2", row.Item("Contract_Code2"))
                    Command.Parameters.AddWithValue("@Part_Code", row.Item("Part_Code"))
                    Command.Parameters.AddWithValue("@Card_Sn", row.Item("Card_Sn"))
                    Command.Parameters.AddWithValue("@IC_Medical_Type_Id", row.Item("IC_Medical_Type_Id"))
                    Command.Parameters.AddWithValue("@Case_Type_Id", row.Item("Case_Type_Id"))
                    Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@PED_Sort", row.Item("PED_Sort"))
                    Command.Parameters.AddWithValue("@SUR_Sort", row.Item("SUR_Sort"))
                    Command.Parameters.AddWithValue("@MED_Sort", row.Item("MED_Sort"))
                    Command.Parameters.AddWithValue("@ENT_Sort", row.Item("ENT_Sort"))
                    Command.Parameters.AddWithValue("@URO_Sort", row.Item("URO_Sort"))
                    Command.Parameters.AddWithValue("@REH_Sort", row.Item("REH_Sort"))
                    Command.Parameters.AddWithValue("@IPD_Sort", row.Item("IPD_Sort"))
                    Command.Parameters.AddWithValue("@Is_Register_Fee", row.Item("Is_Register_Fee"))
                    Command.Parameters.AddWithValue("@Is_Examine", row.Item("Is_Examine"))
                    Command.Parameters.AddWithValue("@Is_Pha_Services", row.Item("Is_Pha_Services"))
                    Command.Parameters.AddWithValue("@OPD_Sort", row.Item("OPD_Sort"))
                    Command.Parameters.AddWithValue("@EMG_Sort", row.Item("EMG_Sort"))
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
    Public Function updateBySetCreateTime(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Medical_Type_Name=@Medical_Type_Name , Medical_Type_Ctrl_Id=@Medical_Type_Ctrl_Id , Dis_Identity_Code=@Dis_Identity_Code , Contract_Code1=@Contract_Code1 " & _
            "  , Contract_Code2=@Contract_Code2 , Part_Code=@Part_Code , Card_Sn=@Card_Sn , IC_Medical_Type_Id=@IC_Medical_Type_Id , Case_Type_Id=@Case_Type_Id " & _
            "  , Dc=@Dc , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            "  , PED_Sort=@PED_Sort , SUR_Sort=@SUR_Sort , MED_Sort=@MED_Sort , ENT_Sort=@ENT_Sort , URO_Sort=@URO_Sort " & _
            "  , REH_Sort=@REH_Sort , IPD_Sort=@IPD_Sort , Is_Register_Fee=@Is_Register_Fee , Is_Examine=@Is_Examine , Is_Pha_Services=@Is_Pha_Services " & _
            "  , OPD_Sort=@OPD_Sort , EMG_Sort=@EMG_Sort " & _
            " where  Medical_Type_Id=@Medical_Type_Id            "
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
                    Command.Parameters.AddWithValue("@Medical_Type_Id", row.Item("Medical_Type_Id"))
                    Command.Parameters.AddWithValue("@Medical_Type_Name", row.Item("Medical_Type_Name"))
                    Command.Parameters.AddWithValue("@Medical_Type_Ctrl_Id", row.Item("Medical_Type_Ctrl_Id"))
                    Command.Parameters.AddWithValue("@Dis_Identity_Code", row.Item("Dis_Identity_Code"))
                    Command.Parameters.AddWithValue("@Contract_Code1", row.Item("Contract_Code1"))
                    Command.Parameters.AddWithValue("@Contract_Code2", row.Item("Contract_Code2"))
                    Command.Parameters.AddWithValue("@Part_Code", row.Item("Part_Code"))
                    Command.Parameters.AddWithValue("@Card_Sn", row.Item("Card_Sn"))
                    Command.Parameters.AddWithValue("@IC_Medical_Type_Id", row.Item("IC_Medical_Type_Id"))
                    Command.Parameters.AddWithValue("@Case_Type_Id", row.Item("Case_Type_Id"))
                    Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                    Command.Parameters.AddWithValue("@PED_Sort", row.Item("PED_Sort"))
                    Command.Parameters.AddWithValue("@SUR_Sort", row.Item("SUR_Sort"))
                    Command.Parameters.AddWithValue("@MED_Sort", row.Item("MED_Sort"))
                    Command.Parameters.AddWithValue("@ENT_Sort", row.Item("ENT_Sort"))
                    Command.Parameters.AddWithValue("@URO_Sort", row.Item("URO_Sort"))
                    Command.Parameters.AddWithValue("@REH_Sort", row.Item("REH_Sort"))
                    Command.Parameters.AddWithValue("@IPD_Sort", row.Item("IPD_Sort"))
                    Command.Parameters.AddWithValue("@Is_Register_Fee", row.Item("Is_Register_Fee"))
                    Command.Parameters.AddWithValue("@Is_Examine", row.Item("Is_Examine"))
                    Command.Parameters.AddWithValue("@Is_Pha_Services", row.Item("Is_Pha_Services"))
                    Command.Parameters.AddWithValue("@OPD_Sort", row.Item("OPD_Sort"))
                    Command.Parameters.AddWithValue("@EMG_Sort", row.Item("EMG_Sort"))
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
    Public Function updateByAssignCreateTime(ByVal ds As System.Data.DataSet, ByVal assignTime As DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            currentTime = assignTime
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Medical_Type_Name=@Medical_Type_Name , Medical_Type_Ctrl_Id=@Medical_Type_Ctrl_Id , Dis_Identity_Code=@Dis_Identity_Code , Contract_Code1=@Contract_Code1 " & _
            "  , Contract_Code2=@Contract_Code2 , Part_Code=@Part_Code , Card_Sn=@Card_Sn , IC_Medical_Type_Id=@IC_Medical_Type_Id , Case_Type_Id=@Case_Type_Id " & _
            "  , Dc=@Dc , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            "  , PED_Sort=@PED_Sort , SUR_Sort=@SUR_Sort , MED_Sort=@MED_Sort , ENT_Sort=@ENT_Sort , URO_Sort=@URO_Sort " & _
            "  , REH_Sort=@REH_Sort , IPD_Sort=@IPD_Sort , Is_Register_Fee=@Is_Register_Fee , Is_Examine=@Is_Examine , Is_Pha_Services=@Is_Pha_Services " & _
            "  , OPD_Sort=@OPD_Sort , EMG_Sort=@EMG_Sort " & _
            " where  Medical_Type_Id=@Medical_Type_Id            "
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
                    Command.Parameters.AddWithValue("@Medical_Type_Id", row.Item("Medical_Type_Id"))
                    Command.Parameters.AddWithValue("@Medical_Type_Name", row.Item("Medical_Type_Name"))
                    Command.Parameters.AddWithValue("@Medical_Type_Ctrl_Id", row.Item("Medical_Type_Ctrl_Id"))
                    Command.Parameters.AddWithValue("@Dis_Identity_Code", row.Item("Dis_Identity_Code"))
                    Command.Parameters.AddWithValue("@Contract_Code1", row.Item("Contract_Code1"))
                    Command.Parameters.AddWithValue("@Contract_Code2", row.Item("Contract_Code2"))
                    Command.Parameters.AddWithValue("@Part_Code", row.Item("Part_Code"))
                    Command.Parameters.AddWithValue("@Card_Sn", row.Item("Card_Sn"))
                    Command.Parameters.AddWithValue("@IC_Medical_Type_Id", row.Item("IC_Medical_Type_Id"))
                    Command.Parameters.AddWithValue("@Case_Type_Id", row.Item("Case_Type_Id"))
                    Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@PED_Sort", row.Item("PED_Sort"))
                    Command.Parameters.AddWithValue("@SUR_Sort", row.Item("SUR_Sort"))
                    Command.Parameters.AddWithValue("@MED_Sort", row.Item("MED_Sort"))
                    Command.Parameters.AddWithValue("@ENT_Sort", row.Item("ENT_Sort"))
                    Command.Parameters.AddWithValue("@URO_Sort", row.Item("URO_Sort"))
                    Command.Parameters.AddWithValue("@REH_Sort", row.Item("REH_Sort"))
                    Command.Parameters.AddWithValue("@IPD_Sort", row.Item("IPD_Sort"))
                    Command.Parameters.AddWithValue("@Is_Register_Fee", row.Item("Is_Register_Fee"))
                    Command.Parameters.AddWithValue("@Is_Examine", row.Item("Is_Examine"))
                    Command.Parameters.AddWithValue("@Is_Pha_Services", row.Item("Is_Pha_Services"))
                    Command.Parameters.AddWithValue("@OPD_Sort", row.Item("OPD_Sort"))
                    Command.Parameters.AddWithValue("@EMG_Sort", row.Item("EMG_Sort"))
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
    Public Function delete(ByRef pk_Medical_Type_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Medical_Type_Id=@Medical_Type_Id "
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
                Command.Parameters.AddWithValue("@Medical_Type_Id", pk_Medical_Type_Id)
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
    Public Function queryByPK(ByRef pk_Medical_Type_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Medical_Type_Id , Medical_Type_Name , Medical_Type_Ctrl_Id , Dis_Identity_Code , Contract_Code1 ,  ")
            content.AppendLine(" Contract_Code2 , Part_Code , Card_Sn , IC_Medical_Type_Id , Case_Type_Id ,  ")
            content.AppendLine(" Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  ")
            content.AppendLine(" PED_Sort , SUR_Sort , MED_Sort , ENT_Sort , URO_Sort ,  ")
            content.AppendLine(" REH_Sort , IPD_Sort , Is_Register_Fee , Is_Examine , Is_Pha_Services ,  ")
            content.AppendLine(" OPD_Sort , EMG_Sort                from " & tableName)
            content.AppendLine("   where Medical_Type_Id=@Medical_Type_Id            ")
            command.CommandText = content.tostring
            Command.Parameters.AddWithValue("@Medical_Type_Id", pk_Medical_Type_Id)
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
    Public Function queryByLikePK(ByRef pk_Medical_Type_Id As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Medical_Type_Id , Medical_Type_Name , Medical_Type_Ctrl_Id , Dis_Identity_Code , Contract_Code1 ,  ")
            content.AppendLine(" Contract_Code2 , Part_Code , Card_Sn , IC_Medical_Type_Id , Case_Type_Id ,  ")
            content.AppendLine(" Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  ")
            content.AppendLine(" PED_Sort , SUR_Sort , MED_Sort , ENT_Sort , URO_Sort ,  ")
            content.AppendLine(" REH_Sort , IPD_Sort , Is_Register_Fee , Is_Examine , Is_Pha_Services ,  ")
            content.AppendLine(" OPD_Sort , EMG_Sort                from " & tableName)
            content.AppendLine("   where Medical_Type_Id like @Medical_Type_Id ")
            command.CommandText = content.tostring
            Command.Parameters.AddWithValue("@Medical_Type_Id", pk_Medical_Type_Id & "%")
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
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select   ")
            content.AppendLine(" Medical_Type_Id , Medical_Type_Name , Medical_Type_Ctrl_Id , Dis_Identity_Code , Contract_Code1 ,  ")
            content.AppendLine(" Contract_Code2 , Part_Code , Card_Sn , IC_Medical_Type_Id , Case_Type_Id ,  ")
            content.AppendLine(" Dc , Create_User , Right('0000'+ltrim(dbo.AdToRocDate (Create_Time)),9) AS  'Create_Time'   , Modified_User , Right('0000'+ltrim(dbo.AdToRocDate (Modified_Time)),9) AS  'Modified_Time'   ,  ")
            content.AppendLine(" PED_Sort , SUR_Sort , MED_Sort , ENT_Sort , URO_Sort ,  ")
            content.AppendLine(" REH_Sort , IPD_Sort , Is_Register_Fee , Is_Examine , Is_Pha_Services ,  ")
            content.AppendLine(" OPD_Sort , EMG_Sort                from " & tableName)
            command.CommandText = content.tostring
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
            content.Append("select   Medical_Type_Id , Medical_Type_Name , Medical_Type_Ctrl_Id , Dis_Identity_Code , Contract_Code1 ,  " & _
             " Contract_Code2 , Part_Code , Card_Sn , IC_Medical_Type_Id , Case_Type_Id ,  " & _
             " Dc , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _
             " PED_Sort , SUR_Sort , MED_Sort , ENT_Sort , URO_Sort ,  " & _
             " REH_Sort , IPD_Sort , Is_Register_Fee , Is_Examine , Is_Pha_Services ,  " & _
             " OPD_Sort , EMG_Sort            from " & tableName & " where 1=1 ")
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
    '''取得表格 PUB_Medical_Type 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Medical_Type 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function
#End Region


End Class
