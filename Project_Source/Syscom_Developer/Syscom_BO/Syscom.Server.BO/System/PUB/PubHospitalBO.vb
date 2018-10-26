Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Reflection
Imports System.Data
Imports System.Diagnostics
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubHospitalBO
    Inherits Syscom.Comm.LOG.LOGDelegate
    'Syscom's CodeGen Produced This VB Code @ 2016/10/19 下午 05:41:46
    Public Shared ReadOnly tableName As String = "PUB_Hospital"
    Private Shared myInstance As PubHospitalBO
    Public Shared Function GetInstance() As PubHospitalBO
        If myInstance Is Nothing Then
            myInstance = New PubHospitalBO()
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
            " Language_Type_Id , Hospital_Code , Effect_Date , End_Date , Hospital_Name ,  " & _
             " Hospital_Short_Name , Telephone , Fax , Voice_Tel , Postal_Code ,  " & _
             " Address , Principal_Name , Principal_Email , Hospital_Level_Id , URL ,  " & _
             " Unified_Business_No , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _
             " License_No , Receipt_Hospital_Name ) " & _
             " values( @Language_Type_Id , @Hospital_Code , @Effect_Date , @End_Date , @Hospital_Name ,  " & _
             " @Hospital_Short_Name , @Telephone , @Fax , @Voice_Tel , @Postal_Code ,  " & _
             " @Address , @Principal_Name , @Principal_Email , @Hospital_Level_Id , @URL ,  " & _
             " @Unified_Business_No , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _
             " @License_No , @Receipt_Hospital_Name             )"
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
                    Command.Parameters.AddWithValue("@Language_Type_Id", row.Item("Language_Type_Id"))
                    Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                    Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    Command.Parameters.AddWithValue("@Hospital_Name", row.Item("Hospital_Name"))
                    Command.Parameters.AddWithValue("@Hospital_Short_Name", row.Item("Hospital_Short_Name"))
                    Command.Parameters.AddWithValue("@Telephone", row.Item("Telephone"))
                    Command.Parameters.AddWithValue("@Fax", row.Item("Fax"))
                    Command.Parameters.AddWithValue("@Voice_Tel", row.Item("Voice_Tel"))
                    Command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                    Command.Parameters.AddWithValue("@Address", row.Item("Address"))
                    Command.Parameters.AddWithValue("@Principal_Name", row.Item("Principal_Name"))
                    Command.Parameters.AddWithValue("@Principal_Email", row.Item("Principal_Email"))
                    Command.Parameters.AddWithValue("@Hospital_Level_Id", row.Item("Hospital_Level_Id"))
                    Command.Parameters.AddWithValue("@URL", row.Item("URL"))
                    Command.Parameters.AddWithValue("@Unified_Business_No", row.Item("Unified_Business_No"))
                    Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    Command.Parameters.AddWithValue("@Create_Time", currentTime)
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@License_No", row.Item("License_No"))
                    Command.Parameters.AddWithValue("@Receipt_Hospital_Name", row.Item("Receipt_Hospital_Name"))
                    Dim cnt As Integer = Command.ExecuteNonQuery
                    count = count + cnt
                End Using
                insertBackup(row, conn) '備份機制
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
            " Language_Type_Id , Hospital_Code , Effect_Date , End_Date , Hospital_Name ,  " & _
             " Hospital_Short_Name , Telephone , Fax , Voice_Tel , Postal_Code ,  " & _
             " Address , Principal_Name , Principal_Email , Hospital_Level_Id , URL ,  " & _
             " Unified_Business_No , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _
             " License_No , Receipt_Hospital_Name ) " & _
             " values( @Language_Type_Id , @Hospital_Code , @Effect_Date , @End_Date , @Hospital_Name ,  " & _
             " @Hospital_Short_Name , @Telephone , @Fax , @Voice_Tel , @Postal_Code ,  " & _
             " @Address , @Principal_Name , @Principal_Email , @Hospital_Level_Id , @URL ,  " & _
             " @Unified_Business_No , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _
             " @License_No , @Receipt_Hospital_Name             )"
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
                    Command.Parameters.AddWithValue("@Language_Type_Id", row.Item("Language_Type_Id"))
                    Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                    Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    Command.Parameters.AddWithValue("@Hospital_Name", row.Item("Hospital_Name"))
                    Command.Parameters.AddWithValue("@Hospital_Short_Name", row.Item("Hospital_Short_Name"))
                    Command.Parameters.AddWithValue("@Telephone", row.Item("Telephone"))
                    Command.Parameters.AddWithValue("@Fax", row.Item("Fax"))
                    Command.Parameters.AddWithValue("@Voice_Tel", row.Item("Voice_Tel"))
                    Command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                    Command.Parameters.AddWithValue("@Address", row.Item("Address"))
                    Command.Parameters.AddWithValue("@Principal_Name", row.Item("Principal_Name"))
                    Command.Parameters.AddWithValue("@Principal_Email", row.Item("Principal_Email"))
                    Command.Parameters.AddWithValue("@Hospital_Level_Id", row.Item("Hospital_Level_Id"))
                    Command.Parameters.AddWithValue("@URL", row.Item("URL"))
                    Command.Parameters.AddWithValue("@Unified_Business_No", row.Item("Unified_Business_No"))
                    Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    Command.Parameters.AddWithValue("@Create_Time", currentTime)
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@License_No", row.Item("License_No"))
                    Command.Parameters.AddWithValue("@Receipt_Hospital_Name", row.Item("Receipt_Hospital_Name"))
                    Dim cnt As Integer = Command.ExecuteNonQuery
                    count = count + cnt
                End Using
                insertBackup(row, conn) '備份機制
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
            " Language_Type_Id , Hospital_Code , Effect_Date , End_Date , Hospital_Name ,  " & _
             " Hospital_Short_Name , Telephone , Fax , Voice_Tel , Postal_Code ,  " & _
             " Address , Principal_Name , Principal_Email , Hospital_Level_Id , URL ,  " & _
             " Unified_Business_No , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _
             " License_No , Receipt_Hospital_Name ) " & _
             " values( @Language_Type_Id , @Hospital_Code , @Effect_Date , @End_Date , @Hospital_Name ,  " & _
             " @Hospital_Short_Name , @Telephone , @Fax , @Voice_Tel , @Postal_Code ,  " & _
             " @Address , @Principal_Name , @Principal_Email , @Hospital_Level_Id , @URL ,  " & _
             " @Unified_Business_No , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _
             " @License_No , @Receipt_Hospital_Name             )"
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
                    Command.Parameters.AddWithValue("@Language_Type_Id", row.Item("Language_Type_Id"))
                    Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                    Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    Command.Parameters.AddWithValue("@Hospital_Name", row.Item("Hospital_Name"))
                    Command.Parameters.AddWithValue("@Hospital_Short_Name", row.Item("Hospital_Short_Name"))
                    Command.Parameters.AddWithValue("@Telephone", row.Item("Telephone"))
                    Command.Parameters.AddWithValue("@Fax", row.Item("Fax"))
                    Command.Parameters.AddWithValue("@Voice_Tel", row.Item("Voice_Tel"))
                    Command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                    Command.Parameters.AddWithValue("@Address", row.Item("Address"))
                    Command.Parameters.AddWithValue("@Principal_Name", row.Item("Principal_Name"))
                    Command.Parameters.AddWithValue("@Principal_Email", row.Item("Principal_Email"))
                    Command.Parameters.AddWithValue("@Hospital_Level_Id", row.Item("Hospital_Level_Id"))
                    Command.Parameters.AddWithValue("@URL", row.Item("URL"))
                    Command.Parameters.AddWithValue("@Unified_Business_No", row.Item("Unified_Business_No"))
                    Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                    Command.Parameters.AddWithValue("@License_No", row.Item("License_No"))
                    Command.Parameters.AddWithValue("@Receipt_Hospital_Name", row.Item("Receipt_Hospital_Name"))
                    Dim cnt As Integer = Command.ExecuteNonQuery
                    count = count + cnt
                End Using
                insertBackup(row, conn) '備份機制
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
            " End_Date=@End_Date , Hospital_Name=@Hospital_Name " & _
            "  , Hospital_Short_Name=@Hospital_Short_Name , Telephone=@Telephone , Fax=@Fax , Voice_Tel=@Voice_Tel , Postal_Code=@Postal_Code " & _
            "  , Address=@Address , Principal_Name=@Principal_Name , Principal_Email=@Principal_Email , Hospital_Level_Id=@Hospital_Level_Id , URL=@URL " & _
            "  , Unified_Business_No=@Unified_Business_No , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            "  , License_No=@License_No , Receipt_Hospital_Name=@Receipt_Hospital_Name " & _
            " where  Language_Type_Id=@Language_Type_Id and Hospital_Code=@Hospital_Code and Effect_Date=@Effect_Date            "
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
                    Command.Parameters.AddWithValue("@Language_Type_Id", row.Item("Language_Type_Id"))
                    Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                    Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    Command.Parameters.AddWithValue("@Hospital_Name", row.Item("Hospital_Name"))
                    Command.Parameters.AddWithValue("@Hospital_Short_Name", row.Item("Hospital_Short_Name"))
                    Command.Parameters.AddWithValue("@Telephone", row.Item("Telephone"))
                    Command.Parameters.AddWithValue("@Fax", row.Item("Fax"))
                    Command.Parameters.AddWithValue("@Voice_Tel", row.Item("Voice_Tel"))
                    Command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                    Command.Parameters.AddWithValue("@Address", row.Item("Address"))
                    Command.Parameters.AddWithValue("@Principal_Name", row.Item("Principal_Name"))
                    Command.Parameters.AddWithValue("@Principal_Email", row.Item("Principal_Email"))
                    Command.Parameters.AddWithValue("@Hospital_Level_Id", row.Item("Hospital_Level_Id"))
                    Command.Parameters.AddWithValue("@URL", row.Item("URL"))
                    Command.Parameters.AddWithValue("@Unified_Business_No", row.Item("Unified_Business_No"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@License_No", row.Item("License_No"))
                    Command.Parameters.AddWithValue("@Receipt_Hospital_Name", row.Item("Receipt_Hospital_Name"))
                    Dim cnt As Integer = Command.ExecuteNonQuery
                    count = count + cnt
                End Using
                updateBackup(row, conn) '備份機制
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
            " End_Date=@End_Date , Hospital_Name=@Hospital_Name " & _
            "  , Hospital_Short_Name=@Hospital_Short_Name , Telephone=@Telephone , Fax=@Fax , Voice_Tel=@Voice_Tel , Postal_Code=@Postal_Code " & _
            "  , Address=@Address , Principal_Name=@Principal_Name , Principal_Email=@Principal_Email , Hospital_Level_Id=@Hospital_Level_Id , URL=@URL " & _
            "  , Unified_Business_No=@Unified_Business_No , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            "  , License_No=@License_No , Receipt_Hospital_Name=@Receipt_Hospital_Name " & _
            " where  Language_Type_Id=@Language_Type_Id and Hospital_Code=@Hospital_Code and Effect_Date=@Effect_Date            "
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
                    Command.Parameters.AddWithValue("@Language_Type_Id", row.Item("Language_Type_Id"))
                    Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                    Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    Command.Parameters.AddWithValue("@Hospital_Name", row.Item("Hospital_Name"))
                    Command.Parameters.AddWithValue("@Hospital_Short_Name", row.Item("Hospital_Short_Name"))
                    Command.Parameters.AddWithValue("@Telephone", row.Item("Telephone"))
                    Command.Parameters.AddWithValue("@Fax", row.Item("Fax"))
                    Command.Parameters.AddWithValue("@Voice_Tel", row.Item("Voice_Tel"))
                    Command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                    Command.Parameters.AddWithValue("@Address", row.Item("Address"))
                    Command.Parameters.AddWithValue("@Principal_Name", row.Item("Principal_Name"))
                    Command.Parameters.AddWithValue("@Principal_Email", row.Item("Principal_Email"))
                    Command.Parameters.AddWithValue("@Hospital_Level_Id", row.Item("Hospital_Level_Id"))
                    Command.Parameters.AddWithValue("@URL", row.Item("URL"))
                    Command.Parameters.AddWithValue("@Unified_Business_No", row.Item("Unified_Business_No"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                    Command.Parameters.AddWithValue("@License_No", row.Item("License_No"))
                    Command.Parameters.AddWithValue("@Receipt_Hospital_Name", row.Item("Receipt_Hospital_Name"))
                    Dim cnt As Integer = Command.ExecuteNonQuery
                    count = count + cnt
                End Using
                updateBackup(row, conn) '備份機制
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
            " End_Date=@End_Date , Hospital_Name=@Hospital_Name " & _
            "  , Hospital_Short_Name=@Hospital_Short_Name , Telephone=@Telephone , Fax=@Fax , Voice_Tel=@Voice_Tel , Postal_Code=@Postal_Code " & _
            "  , Address=@Address , Principal_Name=@Principal_Name , Principal_Email=@Principal_Email , Hospital_Level_Id=@Hospital_Level_Id , URL=@URL " & _
            "  , Unified_Business_No=@Unified_Business_No , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            "  , License_No=@License_No , Receipt_Hospital_Name=@Receipt_Hospital_Name " & _
            " where  Language_Type_Id=@Language_Type_Id and Hospital_Code=@Hospital_Code and Effect_Date=@Effect_Date            "
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
                    Command.Parameters.AddWithValue("@Language_Type_Id", row.Item("Language_Type_Id"))
                    Command.Parameters.AddWithValue("@Hospital_Code", row.Item("Hospital_Code"))
                    Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                    Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                    Command.Parameters.AddWithValue("@Hospital_Name", row.Item("Hospital_Name"))
                    Command.Parameters.AddWithValue("@Hospital_Short_Name", row.Item("Hospital_Short_Name"))
                    Command.Parameters.AddWithValue("@Telephone", row.Item("Telephone"))
                    Command.Parameters.AddWithValue("@Fax", row.Item("Fax"))
                    Command.Parameters.AddWithValue("@Voice_Tel", row.Item("Voice_Tel"))
                    Command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                    Command.Parameters.AddWithValue("@Address", row.Item("Address"))
                    Command.Parameters.AddWithValue("@Principal_Name", row.Item("Principal_Name"))
                    Command.Parameters.AddWithValue("@Principal_Email", row.Item("Principal_Email"))
                    Command.Parameters.AddWithValue("@Hospital_Level_Id", row.Item("Hospital_Level_Id"))
                    Command.Parameters.AddWithValue("@URL", row.Item("URL"))
                    Command.Parameters.AddWithValue("@Unified_Business_No", row.Item("Unified_Business_No"))
                    Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Command.Parameters.AddWithValue("@License_No", row.Item("License_No"))
                    Command.Parameters.AddWithValue("@Receipt_Hospital_Name", row.Item("Receipt_Hospital_Name"))
                    Dim cnt As Integer = Command.ExecuteNonQuery
                    count = count + cnt
                End Using
                updateBackup(row, conn) '備份機制
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
    Public Function delete(ByRef pk_Language_Type_Id As System.String, ByRef pk_Hospital_Code As System.String, ByRef pk_Effect_Date As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Language_Type_Id=@Language_Type_Id and Hospital_Code=@Hospital_Code and Effect_Date=@Effect_Date "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            deleteBackup(pk_Language_Type_Id, pk_Hospital_Code, pk_Effect_Date, conn) '備份機制
            Using command As SqlCommand = New SqlCommand
                With Command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                Command.Parameters.AddWithValue("@Language_Type_Id", pk_Language_Type_Id)
                Command.Parameters.AddWithValue("@Hospital_Code", pk_Hospital_Code)
                Command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
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
    Public Function queryByPK(ByRef pk_Language_Type_Id As System.String, ByRef pk_Hospital_Code As System.String, ByRef pk_Effect_Date As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Unified_Business_No , Create_User , Create_Time , Modified_User , Modified_Time ,  ")
            content.AppendLine(" License_No , Receipt_Hospital_Name                from " & tableName)
            content.AppendLine("   where Language_Type_Id=@Language_Type_Id and Hospital_Code=@Hospital_Code and Effect_Date=@Effect_Date            ")
            command.CommandText = content.tostring
            Command.Parameters.AddWithValue("@Language_Type_Id", pk_Language_Type_Id)
            Command.Parameters.AddWithValue("@Hospital_Code", pk_Hospital_Code)
            Command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
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
    Public Function queryByLikePK(ByRef pk_Language_Type_Id As System.String, ByRef pk_Hospital_Code As System.String, ByRef pk_Effect_Date As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Unified_Business_No , Create_User , Create_Time , Modified_User , Modified_Time ,  ")
            content.AppendLine(" License_No , Receipt_Hospital_Name                from " & tableName)
            content.AppendLine("   where Language_Type_Id like @Language_Type_Id and Hospital_Code like @Hospital_Code and Effect_Date like @Effect_Date ")
            command.CommandText = content.tostring
            Command.Parameters.AddWithValue("@Language_Type_Id", pk_Language_Type_Id & "%")
            Command.Parameters.AddWithValue("@Hospital_Code", pk_Hospital_Code & "%")
            Command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date & "%")
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
            content.AppendLine(" Language_Type_Id , Hospital_Code , Effect_Date , End_Date , Hospital_Name ,  ")
            content.AppendLine(" Hospital_Short_Name , Telephone , Fax , Voice_Tel , Postal_Code ,  ")
            content.AppendLine(" Address , Principal_Name , Principal_Email , Hospital_Level_Id , URL ,  ")
            content.AppendLine(" Unified_Business_No , Create_User , Create_Time , Modified_User , Modified_Time ,  ")
            content.AppendLine(" License_No , Receipt_Hospital_Name                from " & tableName)
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
            content.Append("select   Language_Type_Id , Hospital_Code , Effect_Date , End_Date , Hospital_Name ,  " & _
             " Hospital_Short_Name , Telephone , Fax , Voice_Tel , Postal_Code ,  " & _
             " Address , Principal_Name , Principal_Email , Hospital_Level_Id , URL ,  " & _
             " Unified_Business_No , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _
             " License_No , Receipt_Hospital_Name            from " & tableName & " where 1=1 ")
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

#Region " 備份"

    ''' <summary>
    '''取得資料庫備份表格的 DataTable 加上各欄位的資料型態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTableBKWithSchema() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName & "_BK")
            dt.Columns.Add("Action")
            dt.Columns("Action").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Backup_Time")
            dt.Columns("Backup_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Language_Type_Id")
            dt.Columns("Language_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Code")
            dt.Columns("Hospital_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Effect_Date")
            dt.Columns("Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("End_Date")
            dt.Columns("End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Hospital_Name")
            dt.Columns("Hospital_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Short_Name")
            dt.Columns("Hospital_Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Telephone")
            dt.Columns("Telephone").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fax")
            dt.Columns("Fax").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Voice_Tel")
            dt.Columns("Voice_Tel").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Postal_Code")
            dt.Columns("Postal_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Address")
            dt.Columns("Address").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Principal_Name")
            dt.Columns("Principal_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Principal_Email")
            dt.Columns("Principal_Email").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Level_Id")
            dt.Columns("Hospital_Level_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("URL")
            dt.Columns("URL").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Unified_Business_No")
            dt.Columns("Unified_Business_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("License_No")
            dt.Columns("License_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Receipt_Hospital_Name")
            dt.Columns("Receipt_Hospital_Name").DataType = System.Type.GetType("System.String")
            Dim pkColArray(4) As DataColumn
            pkColArray(2) = dt.Columns("Language_Type_Id")
            pkColArray(3) = dt.Columns("Hospital_Code")
            pkColArray(4) = dt.Columns("Effect_Date")
            pkColArray(0) = dt.Columns("Action")
            pkColArray(1) = dt.Columns("Backup_Time")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' 備份新增資料
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Protected Sub insertBackup(ByVal row As DataRow, ByRef conn As System.Data.IDbConnection)
        dataBackup("Insert", row, conn)
    End Sub


    ''' <summary>
    ''' 備份新增資料
    ''' </summary>
    ''' <param name="table"></param>
    ''' <remarks></remarks>
    Protected Sub insertBackupTable(ByVal table As DataTable, ByRef conn As System.Data.IDbConnection)
        If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
            For Each row In table.Rows
                insertBackup(row, conn)
            Next
        End If
    End Sub


    ''' <summary>
    ''' 備份更新資料
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Protected Sub updateBackup(ByVal row As DataRow, Optional ByRef conn As System.Data.IDbConnection = Nothing)
        dataBackup("Update", row, conn)
    End Sub


    ''' <summary>
    ''' 備份更新資料
    ''' </summary>
    ''' <param name="table"></param>
    ''' <remarks></remarks>
    Protected Sub updateBackupTable(ByVal table As DataTable, ByRef conn As System.Data.IDbConnection)
        If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
            For Each row In table.Rows
                updateBackup(row, conn)
            Next
        End If
    End Sub


    ''' <summary>
    ''' 備份主程式
    ''' </summary>
    ''' <param name="action"></param>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Protected Sub dataBackup(ByRef action As String, ByRef row As DataRow, ByRef conn As System.Data.IDbConnection)
        Dim bkDS = New DataSet
        Dim bkTable = getDataTableBKWithSchema()
        Dim bkRow = bkTable.NewRow()
        bkRow("Action") = action
        bkRow("Backup_Time") = Now
        bkRow("Language_Type_Id") = row.Item("Language_Type_Id")
        bkRow("Hospital_Code") = row.Item("Hospital_Code")
        bkRow("Effect_Date") = row.Item("Effect_Date")
        bkRow("End_Date") = row.Item("End_Date")
        bkRow("Hospital_Name") = row.Item("Hospital_Name")
        bkRow("Hospital_Short_Name") = row.Item("Hospital_Short_Name")
        bkRow("Telephone") = row.Item("Telephone")
        bkRow("Fax") = row.Item("Fax")
        bkRow("Voice_Tel") = row.Item("Voice_Tel")
        bkRow("Postal_Code") = row.Item("Postal_Code")
        bkRow("Address") = row.Item("Address")
        bkRow("Principal_Name") = row.Item("Principal_Name")
        bkRow("Principal_Email") = row.Item("Principal_Email")
        bkRow("Hospital_Level_Id") = row.Item("Hospital_Level_Id")
        bkRow("URL") = row.Item("URL")
        bkRow("Unified_Business_No") = row.Item("Unified_Business_No")
        bkRow("Create_User") = row.Item("Create_User")
        bkRow("Create_Time") = row.Item("Create_Time")
        bkRow("Modified_User") = row.Item("Modified_User")
        bkRow("Modified_Time") = row.Item("Modified_Time")
        bkRow("License_No") = row.Item("License_No")
        bkRow("Receipt_Hospital_Name") = row.Item("Receipt_Hospital_Name")
        bkTable.Rows.Add(bkRow)
        bkDS.Tables.Add(bkTable)
        If bkDS.Tables(0).Rows.Count > 0 Then
            Try
                Dim Content As New StringBuilder
                Content.AppendLine("	 Insert Into " & tableName & "_BK (Action,Backup_Time")
                Content.AppendLine("      , Language_Type_Id")
                Content.AppendLine("      , Hospital_Code")
                Content.AppendLine("      , Effect_Date")
                Content.AppendLine("      , End_Date")
                Content.AppendLine("      , Hospital_Name")
                Content.AppendLine("      , Hospital_Short_Name")
                Content.AppendLine("      , Telephone")
                Content.AppendLine("      , Fax")
                Content.AppendLine("      , Voice_Tel")
                Content.AppendLine("      , Postal_Code")
                Content.AppendLine("      , Address")
                Content.AppendLine("      , Principal_Name")
                Content.AppendLine("      , Principal_Email")
                Content.AppendLine("      , Hospital_Level_Id")
                Content.AppendLine("      , URL")
                Content.AppendLine("      , Unified_Business_No")
                Content.AppendLine("      , Create_User")
                Content.AppendLine("      , Create_Time")
                Content.AppendLine("      , Modified_User")
                Content.AppendLine("      , Modified_Time")
                Content.AppendLine("      , License_No")
                Content.AppendLine("      , Receipt_Hospital_Name")
                Content.AppendLine("      )")
                Content.AppendLine("Select '" & action & "','" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "' ,* From " & tableName & " Where 1=1 ")
                Content.AppendLine("   And Language_Type_Id=@Language_Type_Id")
                Content.AppendLine("   And Hospital_Code=@Hospital_Code")
                Content.AppendLine("   And Effect_Date=@Effect_Date")
                Using Command As SqlCommand = conn.CreateCommand
                    Command.CommandText = Content.ToString
                    Command.Parameters.AddWithValue("@Language_Type_Id", bkRow("Language_Type_Id"))
                    Command.Parameters.AddWithValue("@Hospital_Code", bkRow("Hospital_Code"))
                    Command.Parameters.AddWithValue("@Effect_Date", bkRow("Effect_Date"))
                    Dim cnt As Integer = Command.ExecuteNonQuery
                End Using
            Catch ex As Exception
                Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()

                '寫入DBLog
                Dim logConn As IDbConnection = SQLConnFactory.getInstance.getBKDBSqlConn
                logConn.Open()
                Dim command As SqlCommand = New SqlCommand("InsertLog", logConn)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add("@LOG_Thread", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Level", SqlDbType.VarChar, 50)
                command.Parameters.Add("@LOG_Logger", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Class", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Method", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Message", SqlDbType.NVarChar, 4000)
                command.Parameters.Add("@LOG_Exception", SqlDbType.NVarChar, 2000)

                command.Parameters("@LOG_Thread").Value = System.Threading.Thread.CurrentThread.ManagedThreadId
                command.Parameters("@LOG_Level").Value = "ERROR"
                command.Parameters("@LOG_Logger").Value = getLoggerName(caller.DeclaringType.FullName)
                command.Parameters("@LOG_Class").Value = "PUBHospitalBO.vb"
                command.Parameters("@LOG_Method").Value = "dataBackup"
                command.Parameters("@LOG_Message").Value = "備份失敗:" & bkDS.GetXml
                command.Parameters("@LOG_Exception").Value = ex.StackTrace
                Try
                    command.ExecuteNonQuery()
                Catch logex As Exception
                Finally
                    logConn.Close()
                    logConn.Dispose()
                End Try
            End Try
        End If
    End Sub


    ''' <summary>
    ''' 備份刪除資料
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks>BO刪除動作要在這個方法之後，不然刪掉就沒資料了可以備份了；有 PKey 而不想太麻煩，用另一個方法，傳入PKey</remarks>
    Protected Sub deleteBackup(ByVal row As DataRow, Optional ByRef conn As System.Data.IDbConnection = Nothing)
        row("Modified_Time") = Now
        dataBackup("Delete", row, conn)
    End Sub


    ''' <summary>
    ''' 備份刪除資料
    ''' </summary>
    ''' <param name="table"></param>
    ''' <remarks></remarks>
    Protected Sub deleteBackupTable(ByVal table As DataTable, Optional ByRef conn As System.Data.IDbConnection = Nothing)
        If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
            For Each row In table.Rows
                deleteBackup(row, conn)
            Next
        End If
    End Sub

    ''' <summary>
    ''' 備份刪除資料
    ''' </summary>       
    Protected Sub deleteBackup(ByVal pk_Language_Type_Id As System.String, ByVal pk_Hospital_Code As System.String, ByVal pk_Effect_Date As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing)

        Dim bkDS As System.Data.DataSet = queryByPK(pk_Language_Type_Id, pk_Hospital_Code, pk_Effect_Date, conn)
        If bkDS IsNot Nothing _
        AndAlso bkDS.Tables.Count > 0 _
        AndAlso bkDS.Tables(0) IsNot Nothing _
        AndAlso bkDS.Tables(0).Rows.Count > 0 _
        AndAlso bkDS.Tables(0).Rows(0) IsNot Nothing _
        Then
            deleteBackup(bkDS.Tables(0).Rows(0), conn)
        Else
            'Throw New Exception("No Data To Delete")
        End If
    End Sub

#End Region

#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Hospital 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        '請加入SQL Connection 於 SD CodeGen 中
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Hospital 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function
#End Region


End Class
