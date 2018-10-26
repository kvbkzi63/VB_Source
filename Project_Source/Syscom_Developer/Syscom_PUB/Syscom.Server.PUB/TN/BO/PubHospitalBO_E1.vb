Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PubHospitalBO_E1
    Inherits PubHospitalBO

    Dim log As LOGDelegate = LOGDelegate.getInstance

#Region "########## getInstance ##########"
    Private Shared instance As PubHospitalBO_E1
    Public Overloads Shared Function getInstance() As PubHospitalBO_E1
        If instance Is Nothing Then
            instance = New PubHospitalBO_E1
        End If
        Return instance
    End Function
    Public Sub New()
    End Sub
#End Region

#Region "     查詢 Method (For多筆維護UI用，使用LIKE 'PKey%') "
    ''' <summary>
    '''查詢(依PKey)
    ''' </summary>
    ''' <returns>查詢結果</returns>
    ''' <remarks>by Alan Tsai on 2014-11-09</remarks>
    Public Function queryPubHospitalLikePKey(ByVal inLanguageTypeId As String, _
                                             ByVal inEffectDate As String, _
                                             ByVal inHospitalCode As String, _
                                             Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
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
            content.AppendLine(" Language_Type_Id , Hospital_Code , Effect_Date , End_Date , Hospital_Name ,  ")
            content.AppendLine(" Hospital_Short_Name , Telephone , Fax , Voice_Tel , Postal_Code ,  ")
            content.AppendLine(" Address , Principal_Name , Principal_Email , Hospital_Level_Id , URL ,  ")
            'Modify BY Elly 2016/10/19  --start
            ' content.AppendLine(" Unified_Business_No , License_No, Create_User , dbo.ADTOROCTime(Create_Time) , Modified_User , dbo.ADTOROCTime(Modified_Time), Effect_Date As Org_Effect_Date, End_Date As Org_End_Date ")
            content.AppendLine(" Unified_Business_No , License_No, Receipt_Hospital_Name,Create_User , dbo.ADTOROCTime(Create_Time) , Modified_User , dbo.ADTOROCTime(Modified_Time), Effect_Date As Org_Effect_Date, End_Date As Org_End_Date ")
            '--end
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where 1=1 ")

            If inLanguageTypeId <> "" Then
                content.AppendLine("         and Language_Type_Id = @Language_Type_Id ")
            End If

            If inHospitalCode <> "" Then
                content.AppendLine("         and Hospital_Code Like @Hospital_Code ")
            End If

            If inEffectDate <> "" Then
                content.AppendLine("         and Effect_Date = @Effect_Date ")
            End If

            content.AppendLine("  Order By Language_Type_Id,Hospital_Code,Effect_Date ")

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Language_Type_Id", inLanguageTypeId)

            If inHospitalCode <> "" Then
                command.Parameters.AddWithValue("@Hospital_Code", inHospitalCode & "%")
            End If

            If inEffectDate <> "" Then
                command.Parameters.AddWithValue("@Effect_Date", inEffectDate)
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
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

    ''' <summary>
    '''查詢全部
    ''' </summary>
    ''' <returns>查詢結果</returns>
    ''' <remarks>by Alan Tsai on 2014-11-09</remarks>
    Public Function queryPubHospitalAll(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
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
            content.AppendLine(" Language_Type_Id , Hospital_Code , Effect_Date , End_Date , Hospital_Name ,  ")
            content.AppendLine(" Hospital_Short_Name , Telephone , Fax , Voice_Tel , Postal_Code ,  ")
            content.AppendLine(" Address , Principal_Name , Principal_Email , Hospital_Level_Id , URL ,  ")
            'Modify BY Elly 2016/10/19  --start
            '   content.AppendLine(" Unified_Business_No , License_No , Create_User , dbo.ADTOROCTime(Create_Time) , Modified_User , dbo.ADTOROCTime(Modified_Time), Effect_Date As Org_Effect_Date, End_Date As Org_End_Date ")
            content.AppendLine(" Unified_Business_No , License_No , Receipt_Hospital_Name,Create_User , dbo.ADTOROCTime(Create_Time) , Modified_User , dbo.ADTOROCTime(Modified_Time), Effect_Date As Org_Effect_Date, End_Date As Org_End_Date ")
            '--end
            content.AppendLine("                 from " & tableName)
            content.AppendLine("  Order By Language_Type_Id,Hospital_Code,Effect_Date ")
            command.CommandText = content.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
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

#End Region

#Region "     新增 Method (For多筆維護UI用) "
    ''' <summary>
    '''新增
    ''' </summary>
    ''' <returns>新增筆數</returns>
    ''' <remarks>by Alan Tsai on 2014-11-09</remarks>
    Public Function insertPubHospitalByRowData(ByVal inLanguageTypeId As String,
                                               ByVal inHospitalCode As String,
                                               ByVal inEffectDate As String,
                                               ByVal inEndDate As String,
                                               ByVal inHospitalName As String,
                                               ByVal inHospitalShortName As String,
                                               ByVal inTelephone As String,
                                               ByVal inFax As String,
                                               ByVal inVoiceTel As String,
                                               ByVal inPostalCode As String,
                                               ByVal inAddress As String,
                                               ByVal inPrincipalName As String,
                                               ByVal inPrincipalEmail As String,
                                               ByVal inHospitalLevelId As String,
                                               ByVal inURL As String,
                                               ByVal inUnifiedBusinessNo As String,
                                               ByVal inCreateUser As String,
                                               ByVal inCreateTime As DateTime,
                                               ByVal inModifiedUser As String,
                                               ByVal inModifiedTime As DateTime,
                                               ByVal inLicenseNo As String,
                                                ByVal Receipt_Hospital_Name As String,
                                               Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer              'add BY Elly 2016/10/19     ByVal Receipt_Hospital_Name As String,

        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Language_Type_Id , Hospital_Code , Effect_Date , End_Date , Hospital_Name ,  " & _
             " Hospital_Short_Name , Telephone , Fax , Voice_Tel , Postal_Code ,  " & _
             " Address , Principal_Name , Principal_Email , Hospital_Level_Id , URL ,  " & _
             " Unified_Business_No , Receipt_Hospital_Name, Create_User , Create_Time , Modified_User , Modified_Time , License_No " & _
             "  ) " & _
             " values( @Language_Type_Id , @Hospital_Code , @Effect_Date , @End_Date , @Hospital_Name ,  " & _
             " @Hospital_Short_Name , @Telephone , @Fax , @Voice_Tel , @Postal_Code ,  " & _
             " @Address , @Principal_Name , @Principal_Email , @Hospital_Level_Id , @URL ,  " & _
             " @Unified_Business_No ,@Receipt_Hospital_Name, @Create_User , @Create_Time , @Modified_User , @Modified_Time , @License_No  " & _
             "              )"
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
                command.Parameters.AddWithValue("@Language_Type_Id", inLanguageTypeId)
                command.Parameters.AddWithValue("@Hospital_Code", inHospitalCode)
                command.Parameters.AddWithValue("@Effect_Date", inEffectDate)
                command.Parameters.AddWithValue("@End_Date", inEndDate)
                command.Parameters.AddWithValue("@Hospital_Name", inHospitalName)
                command.Parameters.AddWithValue("@Hospital_Short_Name", inHospitalShortName)
                command.Parameters.AddWithValue("@Telephone", inTelephone)
                command.Parameters.AddWithValue("@Fax", inFax)
                command.Parameters.AddWithValue("@Voice_Tel", inVoiceTel)
                command.Parameters.AddWithValue("@Postal_Code", inPostalCode)
                command.Parameters.AddWithValue("@Address", inAddress)
                command.Parameters.AddWithValue("@Principal_Name", inPrincipalName)
                command.Parameters.AddWithValue("@Principal_Email", inPrincipalEmail)
                command.Parameters.AddWithValue("@Hospital_Level_Id", inHospitalLevelId)
                command.Parameters.AddWithValue("@URL", inURL)
                command.Parameters.AddWithValue("@Unified_Business_No", inUnifiedBusinessNo)
                command.Parameters.AddWithValue("@Create_User", inCreateUser)
                command.Parameters.AddWithValue("@Create_Time", inCreateTime)
                command.Parameters.AddWithValue("@Modified_User", inModifiedUser)
                command.Parameters.AddWithValue("@Modified_Time", inModifiedTime)
                command.Parameters.AddWithValue("@License_No", inLicenseNo)
                command.Parameters.AddWithValue("@Receipt_Hospital_Name", Receipt_Hospital_Name)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count

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

#End Region

#Region "     修改 Method (For多筆維護UI用) "
    ''' <summary>
    '''修改
    ''' </summary>
    ''' <returns>修改筆數</returns>
    ''' <remarks>by Alan Tsai on 2014-11-09</remarks>
    Public Function updatePubHospitalByRowData(ByVal inLanguageTypeId As String,
                                               ByVal inHospitalCode As String,
                                               ByVal inEffectDate As String,
                                               ByVal inEndDate As String,
                                               ByVal inHospitalName As String,
                                               ByVal inHospitalShortName As String,
                                               ByVal inTelephone As String,
                                               ByVal inFax As String,
                                               ByVal inVoiceTel As String,
                                               ByVal inPostalCode As String,
                                               ByVal inAddress As String,
                                               ByVal inPrincipalName As String,
                                               ByVal inPrincipalEmail As String,
                                               ByVal inHospitalLevelId As String,
                                               ByVal inURL As String,
                                               ByVal inUnifiedBusinessNo As String,
                                               ByVal inModifiedUser As String,
                                               ByVal inModifiedTime As DateTime,
                                               ByVal inOrgEffectDate As String,
                                               ByVal inLicenseNo As String,
                                                ByVal Receipt_Hospital_Name As String,
                                               Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer   'add BY Elly 2016/10/19     ByVal Receipt_Hospital_Name As String,
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Effect_Date=@Effect_Date,End_Date=@End_Date , Hospital_Name=@Hospital_Name " & _
            "  , Hospital_Short_Name=@Hospital_Short_Name , Telephone=@Telephone , Fax=@Fax , Voice_Tel=@Voice_Tel , Postal_Code=@Postal_Code " & _
            "  , Address=@Address , Principal_Name=@Principal_Name , Principal_Email=@Principal_Email , Hospital_Level_Id=@Hospital_Level_Id , URL=@URL " & _
            "  , Unified_Business_No=@Unified_Business_No , Modified_User=@Modified_User , Modified_Time=@Modified_Time , License_No=@License_No , Receipt_Hospital_Name=@Receipt_Hospital_Name" & _
            "  " & _
            " where  Language_Type_Id=@Language_Type_Id and Hospital_Code=@Hospital_Code and Effect_Date=@Org_Effect_Date            "
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
                command.Parameters.AddWithValue("@Language_Type_Id", inLanguageTypeId)
                command.Parameters.AddWithValue("@Hospital_Code", inHospitalCode)
                command.Parameters.AddWithValue("@Effect_Date", inEffectDate)
                command.Parameters.AddWithValue("@End_Date", inEndDate)
                command.Parameters.AddWithValue("@Hospital_Name", inHospitalName)
                command.Parameters.AddWithValue("@Hospital_Short_Name", inHospitalShortName)
                command.Parameters.AddWithValue("@Telephone", inTelephone)
                command.Parameters.AddWithValue("@Fax", inFax)
                command.Parameters.AddWithValue("@Voice_Tel", inVoiceTel)
                command.Parameters.AddWithValue("@Postal_Code", inPostalCode)
                command.Parameters.AddWithValue("@Address", inAddress)
                command.Parameters.AddWithValue("@Principal_Name", inPrincipalName)
                command.Parameters.AddWithValue("@Principal_Email", inPrincipalEmail)
                command.Parameters.AddWithValue("@Hospital_Level_Id", inHospitalLevelId)
                command.Parameters.AddWithValue("@URL", inURL)
                command.Parameters.AddWithValue("@Unified_Business_No", inUnifiedBusinessNo)
                command.Parameters.AddWithValue("@Modified_User", inModifiedUser)
                command.Parameters.AddWithValue("@Modified_Time", inModifiedTime)
                command.Parameters.AddWithValue("@Org_Effect_Date", inOrgEffectDate)
                command.Parameters.AddWithValue("@License_No", inLicenseNo)
                command.Parameters.AddWithValue("@Receipt_Hospital_Name", Receipt_Hospital_Name)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count

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

#End Region

#Region "     刪除 Method (For多筆維護UI用) "
    ''' <summary>
    '''刪除
    ''' </summary>
    ''' <returns>刪除筆數</returns>
    ''' <remarks>by Alan Tsai on 2014-11-03</remarks>
    Public Function deletePubHospitalByPK(ByVal pk_Language_Type_Id As System.String, _
                                          ByVal pk_Hospital_Code As System.String, _
                                          ByVal pk_Effect_Date As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
             " Language_Type_Id=@Language_Type_Id and  Hospital_Code=@Hospital_Code and Effect_Date=@Effect_Date "
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
                command.Parameters.AddWithValue("@Language_Type_Id", pk_Language_Type_Id)
                command.Parameters.AddWithValue("@Hospital_Code", pk_Hospital_Code)
                command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
                count = command.ExecuteNonQuery
            End Using
            Return count
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

#End Region

#Region "     取得醫院資訊 "

    ''' <summary>
    ''' 取得醫院資訊
    ''' </summary>
    ''' <param name="HospitalCode"></param>
    ''' <param name="LanguageTypeId"></param>
    ''' <param name="EffectDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryHospitalInfo(ByVal HospitalCode As String, ByVal LanguageTypeId As String, ByVal EffectDate As Date) As DataSet

        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select * ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("from ").Append(tableName).AppendLine(" ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where ")
        cmdStr.AppendLine(" Language_Type_Id = @LanguageTypeId ")
        cmdStr.AppendLine("and Effect_Date < @EffectDate ")
        cmdStr.AppendLine("and End_Date >= @EffectDate ")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------

        Try
            Dim ds As DataSet = New DataSet

            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@LanguageTypeId", LanguageTypeId)
                        sqlCmd.Parameters.AddWithValue("@EffectDate", EffectDate)

                    End With

                    conn.Open()

                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        Using dt As DataTable = New DataTable(tableName)

                            da.Fill(dt)
                            ds.Tables.Add(dt)

                        End Using
                    End Using

                End Using
            End Using

            Return ds

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "     查詢透析院所代號 (For KLH 用) "

    ''' <summary>
    '''查詢透析院所代號
    ''' </summary>
    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    Public Function queryByNow(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Dim strNow As String = Now().ToString("yyyy-MM-dd")

        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select top 1  ")
            content.AppendLine(" PUB_Hospital.* from PUB_Hospital  ")
            content.AppendLine(" where ltrim(rtrim(Language_Type_Id)) ='1' and @dateNow between Effect_Date and End_Date   ")
            content.AppendLine(" order by Hospital_Code desc            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@dateNow", strNow)
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

End Class
