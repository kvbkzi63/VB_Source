'/*
'*****************************************************************************
'*
'*    Page/Class Name:  ICD9_ICD10對照檔
'*              Title:	PUBDiseaseICD10MappingBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Li,Han
'*        Create Date:	2016-06-28
'*      Last Modifier:	Li,Han
'*   Last Modify Date:	2016-06-28
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports System.Text
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Public Class PUBDiseaseICD10MappingBO_E2
    Inherits PubDiseaseIcd10MappingBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBDiseaseICD10MappingBO_E2
    Public Overloads Shared Function GetInstance() As PUBDiseaseICD10MappingBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBDiseaseICD10MappingBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     新增 Method"
    Public Function insertData(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Dim dsCount As New DataSet
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Disease_Type_Id,ICD_Code , ICD10_Code , Mapping_Status , Create_User , Create_Time ,  " & _
             " Modified_User , Modified_Time ) " & _
             " values( @Disease_Type_Id,@ICD_Code , @ICD10_Code , @Mapping_Status , @Create_User , @Create_Time ,  " & _
             " @Modified_User , @Modified_Time             )"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                dsCount = Me.queryByPK(row.Item("Disease_Type_Id"), row.Item("ICD_Code"), row.Item("ICD10_Code"))
                If dsCount.Tables(0).Rows.Count > 0 Then
                    Return count
                End If
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Disease_Type_Id", row.Item("Disease_Type_Id"))
                    command.Parameters.AddWithValue("@ICD_Code", row.Item("ICD_Code"))
                    command.Parameters.AddWithValue("@ICD10_Code", row.Item("ICD10_Code"))
                    command.Parameters.AddWithValue("@Mapping_Status", row.Item("Mapping_Status"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime)
                    command.Parameters.AddWithValue("@Modified_User", System.DBNull.Value)
                    command.Parameters.AddWithValue("@Modified_Time", System.DBNull.Value)
                    Dim cnt As Integer = command.ExecuteNonQuery
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

#Region "     修改 Method"
    Public Function updateData(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Mapping_Status=@Mapping_Status , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            " where   Disease_Type_Id=@Disease_Type_Id and ICD_Code=@ICD_Code and ICD10_Code=@ICD10_Code            "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Disease_Type_Id", row.Item("Disease_Type_Id"))
                    command.Parameters.AddWithValue("@ICD_Code", row.Item("ICD_Code"))
                    command.Parameters.AddWithValue("@ICD10_Code", row.Item("ICD10_Code"))
                    command.Parameters.AddWithValue("@Mapping_Status", row.Item("Mapping_Status"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Dim cnt As Integer = command.ExecuteNonQuery
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

#Region "     刪除 Method"
    Public Function deleteData(ByRef pk_Disease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            "  Disease_Type_Id=@Disease_Type_Id and ICD_Code=@ICD_Code and icd10_code=@icd10_code "
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
                command.Parameters.AddWithValue("@Disease_Type_Id", pk_Disease_Type_Id)
                command.Parameters.AddWithValue("@ICD_Code", pk_ICD_Code)
                command.Parameters.AddWithValue("@icd10_code", pk_ICD10_Code)
                count = command.ExecuteNonQuery
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

#Region "     查詢 Method "
    ''' <summary>
    ''' 取得Gird資料
    ''' </summary>
    ''' <param name="pkDisease_Type_Id"></param>
    ''' <param name="pk_ICD_Code"></param>
    ''' <param name="pk_ICD10_Code"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryGridData(ByRef pkDisease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder

            content.AppendLine("              SELECT TOP 1000  " & vbCrLf)
            content.AppendLine("              a.Disease_Type_Id,a.ICD_Code,a.ICD10_Code,a.Mapping_Status," & vbCrLf)
            content.AppendLine("              b.Disease_Name as icd9_name,c.Disease_Name as icd10_name," & vbCrLf)
            content.AppendLine("              a.Create_User,a.Create_Time,a.Modified_User ,a.Modified_Time  " & vbCrLf)
            content.AppendLine("               FROM   PUB_Disease_ICD10_Mapping a " & vbCrLf)
            content.AppendLine("                LEFT JOIN PUB_Disease b " & vbCrLf)
            content.AppendLine("               ON a.ICD_Code = b.Icd_Code " & vbCrLf)
            content.AppendLine("                AND a.Disease_Type_Id = b.Disease_Type_Id " & vbCrLf)
            content.AppendLine("               LEFT JOIN PUB_Disease_ICD10 c " & vbCrLf)
            content.AppendLine("               ON a.icd10_code = c.Icd_Code " & vbCrLf)
            content.AppendLine("               AND a.Disease_Type_Id = c.Disease_Type_Id" & vbCrLf)
            content.AppendLine("               WHERE  1 = 1 " & vbCrLf)
            If pkDisease_Type_Id.Length > 0 Then
                content.AppendLine("  AND a.Disease_Type_Id >=@PKDisease_Type_Id  ")
            End If
            If pk_ICD_Code.Length > 0 Then
                content.AppendLine("  AND a.Icd_Code >=@pk_ICD_Code  ")
            End If
            If pk_ICD10_Code.Length > 0 Then
                content.AppendLine(" AND a.icd10_code >=@pk_ICD10_Code  ")
            End If
            content.AppendLine(" Order By  a.Disease_Type_Id, a.ICD_Code, a.ICD10_Code")

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@PKDisease_Type_Id", pkDisease_Type_Id)
            command.Parameters.AddWithValue("@pk_ICD_Code", pk_ICD_Code)
            command.Parameters.AddWithValue("@pk_ICD10_Code", pk_ICD10_Code)
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
    ''' 取得Gird資料ByPk
    ''' </summary>
    ''' <param name="pkDisease_Type_Id"></param>
    ''' <param name="pk_ICD_Code"></param>
    ''' <param name="pk_ICD10_Code"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryGridDataByPk(ByRef pkDisease_Type_Id As System.String, ByRef pk_ICD_Code As System.String, ByRef pk_ICD10_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder

            content.AppendLine("              SELECT TOP 1000  " & vbCrLf)
            content.AppendLine("              a.Disease_Type_Id,a.ICD_Code,a.ICD10_Code,a.Mapping_Status," & vbCrLf)
            content.AppendLine("              b.Disease_Name as icd9_name,c.Disease_Name as icd10_name," & vbCrLf)
            content.AppendLine("              a.Create_User,a.Create_Time,a.Modified_User ,a.Modified_Time  " & vbCrLf)
            content.AppendLine("               FROM   PUB_Disease_ICD10_Mapping a " & vbCrLf)
            content.AppendLine("                LEFT JOIN PUB_Disease b " & vbCrLf)
            content.AppendLine("               ON a.ICD_Code = b.Icd_Code " & vbCrLf)
            content.AppendLine("                AND a.Disease_Type_Id = b.Disease_Type_Id " & vbCrLf)
            content.AppendLine("               LEFT JOIN PUB_Disease_ICD10 c " & vbCrLf)
            content.AppendLine("               ON a.icd10_code = c.Icd_Code " & vbCrLf)
            content.AppendLine("               AND a.Disease_Type_Id = c.Disease_Type_Id" & vbCrLf)
            content.AppendLine("               WHERE  1 = 1 " & vbCrLf)
            If pkDisease_Type_Id.Length > 0 Then
                content.AppendLine("  AND a.Disease_Type_Id =@PKDisease_Type_Id  ")
            End If
            If pk_ICD_Code.Length > 0 Then
                content.AppendLine("  AND a.Icd_Code =@pk_ICD_Code  ")
            End If
            If pk_ICD10_Code.Length > 0 Then
                content.AppendLine(" AND a.icd10_code =@pk_ICD10_Code  ")
            End If
            content.AppendLine(" Order By  a.Disease_Type_Id, a.ICD_Code, a.ICD10_Code")

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@PKDisease_Type_Id", pkDisease_Type_Id)
            command.Parameters.AddWithValue("@pk_ICD_Code", pk_ICD_Code)
            command.Parameters.AddWithValue("@pk_ICD10_Code", pk_ICD10_Code)
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
    ''' 取得Combox資料
    ''' </summary>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function quertCmbData(Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder

            content.AppendLine("SELECT * FROM PUB_SYSCODE WHERE TYPE_ID = 33" & vbCrLf)


            command.CommandText = content.ToString

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
    ''' 檢查該診斷是否存在
    ''' </summary>
    ''' <param name="strICD"></param>
    ''' <param name="strTBName"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function fCheckIcdCode(ByVal strICD As String, ByVal strTBName As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder

            content.AppendLine("SELECT * FROM " & strTBName & " WHERE ICD_Code = '" & strICD & "'" & vbCrLf)


            command.CommandText = content.ToString

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            If ds.Tables.Count = 0 Then
                Return 0
            Else
                Return ds.Tables(0).Rows.Count
            End If
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

End Class
