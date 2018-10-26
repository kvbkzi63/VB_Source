'/*
'*****************************************************************************
'*
'*    Page/Class Name:  ICD9_ICD10對照檔
'*              Title:	PUBDiseaseICD10MappingBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Li,Han
'*        Create Date:	2016-06-29
'*      Last Modifier:	Li,Han
'*   Last Modify Date:	2016-06-29
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
Public Class PubIcd10DeptBO_E2
    Inherits PubIcd10DeptBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PubIcd10DeptBO_E2
    Public Overloads Shared Function GetInstance() As PubIcd10DeptBO_E2
        If myInstance Is Nothing Then
            myInstance = New PubIcd10DeptBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     新增 Method"
    Public Function insertData(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Kind_Code , Disease_Type_Id , ICD10_Code , Insu_Dept_Code , Insu_Sub_Dept_Code ,  " & _
             " Create_User , Create_Time , Modified_User , Modified_Time ) " & _
             " values( @Kind_Code , @Disease_Type_Id , @ICD10_Code , @Insu_Dept_Code , @Insu_Sub_Dept_Code ,  " & _
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time             )"
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
                    command.Parameters.AddWithValue("@Kind_Code", row.Item("Kind_Code"))
                    command.Parameters.AddWithValue("@Disease_Type_Id", row.Item("Disease_Type_Id"))
                    command.Parameters.AddWithValue("@ICD10_Code", row.Item("ICD10_Code"))
                    command.Parameters.AddWithValue("@Insu_Dept_Code", row.Item("Insu_Dept_Code"))
                    command.Parameters.AddWithValue("@Insu_Sub_Dept_Code", row.Item("Insu_Sub_Dept_Code"))
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

#Region "     刪除 Method"
    Public Function deleteData(ByRef pk_Kind_Code As System.String, ByRef pk_Disease_Type_Id As System.String, ByRef pk_ICD10_Code As System.String, ByRef pk_Insu_Dept_Code As System.String, ByRef pk_Insu_Sub_Dept_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Kind_Code=@Kind_Code and Disease_Type_Id=@Disease_Type_Id and ICD10_Code=@ICD10_Code and Insu_Dept_Code=@Insu_Dept_Code and Insu_Sub_Dept_Code=@Insu_Sub_Dept_Code " & _
            "  "
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
                command.Parameters.AddWithValue("@Kind_Code", pk_Kind_Code)
                command.Parameters.AddWithValue("@Disease_Type_Id", pk_Disease_Type_Id)
                command.Parameters.AddWithValue("@ICD10_Code", pk_ICD10_Code)
                command.Parameters.AddWithValue("@Insu_Dept_Code", pk_Insu_Dept_Code)
                command.Parameters.AddWithValue("@Insu_Sub_Dept_Code", pk_Insu_Sub_Dept_Code)
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
    '''  取得Gird資料
    ''' </summary>
    ''' <param name="Kind_Code"></param>
    ''' <param name="Disease_Type_Id"></param>
    ''' <param name="Icd10_Code"></param>
    ''' <param name="Insu_Dept_Code"></param>
    ''' <param name="Insu_Sub_Dept_Code"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryGridData(ByRef Kind_Code As System.String, ByRef Disease_Type_Id As System.String, ByRef Icd10_Code As System.String, _
                                  ByRef Insu_Dept_Code As System.String, ByRef Insu_Sub_Dept_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine("              a.kind_Code,a.Disease_Type_Id," & vbCrLf)
            content.AppendLine("              a.ICD10_Code," & vbCrLf)
            content.AppendLine("              c.Disease_Name        AS icd10_name," & vbCrLf)
            content.AppendLine("              a.Insu_Dept_Code," & vbCrLf)
            content.AppendLine("              b.Insu_Dept_Code_Name AS insu_dept_name," & vbCrLf)
            content.AppendLine("              a.Insu_Sub_Dept_Code," & vbCrLf)
            content.AppendLine("              d.Insu_Dept_Code_Name AS insu_sub_dept_name,  " & vbCrLf)
            content.AppendLine("              a.Create_User,a.Create_Time,a.Modified_User,a.Modified_Time")
            content.AppendLine("              FROM   PUB_ICD10_Dept a " & vbCrLf)
            content.AppendLine("              LEFT JOIN PUB_Insu_Dept b " & vbCrLf)
            content.AppendLine("              ON a.Insu_Dept_Code = b.Insu_Dept_Code " & vbCrLf)
            content.AppendLine("              LEFT JOIN PUB_Disease_ICD10 c " & vbCrLf)
            content.AppendLine("              ON a.icd10_code = c.Icd_Code " & vbCrLf)
            content.AppendLine("              AND a.Disease_Type_Id = c.Disease_Type_Id " & vbCrLf)
            content.AppendLine("              LEFT JOIN PUB_Insu_Dept d" & vbCrLf)
            content.AppendLine("              ON a.Insu_Sub_Dept_Code = d.Insu_Dept_Code " & vbCrLf)
            content.AppendLine("              where 1=1 " & vbCrLf)

            If Kind_Code.Length > 0 Then
                content.AppendLine("  AND a.Kind_Code=@Kind_Code  ")
            End If

            If Disease_Type_Id.Length > 0 Then
                content.AppendLine("  AND a.Disease_Type_Id >=@Disease_Type_Id  ")
            End If

            If Icd10_Code.Length > 0 Then
                content.AppendLine("  AND a.Icd10_Code >=@Icd10_Code  ")
            End If

            If Insu_Dept_Code.Length > 0 Then
                content.AppendLine("  AND a.Insu_Dept_Code >=@Insu_Dept_Code  ")
            End If

            If Insu_Sub_Dept_Code.Length > 0 Then
                content.AppendLine("  AND a.Insu_Sub_Dept_Code >=@Insu_Sub_Dept_Code  ")
            End If

            content.AppendLine("  Order By   a.Kind_Code,a.Disease_Type_Id,a.Icd10_Code,a.Insu_Dept_Code,a.Insu_Sub_Dept_Code")

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Kind_Code", Kind_Code)
            command.Parameters.AddWithValue("@Disease_Type_Id", Disease_Type_Id)
            command.Parameters.AddWithValue("@Icd10_Code", Icd10_Code)
            command.Parameters.AddWithValue("@Insu_Dept_Code", Insu_Dept_Code)
            command.Parameters.AddWithValue("@Insu_Sub_Dept_Code", Insu_Sub_Dept_Code)
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
    '''  取得Gird資料ByPK
    ''' </summary>
    ''' <param name="Kind_Code"></param>
    ''' <param name="Disease_Type_Id"></param>
    ''' <param name="Icd10_Code"></param>
    ''' <param name="Insu_Dept_Code"></param>
    ''' <param name="Insu_Sub_Dept_Code"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryGridDataByPk(ByRef Kind_Code As System.String, ByRef Disease_Type_Id As System.String, ByRef Icd10_Code As System.String, _
                                  ByRef Insu_Dept_Code As System.String, ByRef Insu_Sub_Dept_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine("              a.kind_Code,a.Disease_Type_Id," & vbCrLf)
            content.AppendLine("              a.ICD10_Code," & vbCrLf)
            content.AppendLine("              c.Disease_Name        AS icd10_name," & vbCrLf)
            content.AppendLine("              a.Insu_Dept_Code," & vbCrLf)
            content.AppendLine("              b.Insu_Dept_Code_Name AS insu_dept_name," & vbCrLf)
            content.AppendLine("              a.Insu_Sub_Dept_Code," & vbCrLf)
            content.AppendLine("              d.Insu_Dept_Code_Name AS insu_sub_dept_name,  " & vbCrLf)
            content.AppendLine("              a.Create_User,a.Create_Time,a.Modified_User,a.Modified_Time")
            content.AppendLine("              FROM   PUB_ICD10_Dept a " & vbCrLf)
            content.AppendLine("              LEFT JOIN PUB_Insu_Dept b " & vbCrLf)
            content.AppendLine("              ON a.Insu_Dept_Code = b.Insu_Dept_Code " & vbCrLf)
            content.AppendLine("              LEFT JOIN PUB_Disease_ICD10 c " & vbCrLf)
            content.AppendLine("              ON a.icd10_code = c.Icd_Code " & vbCrLf)
            content.AppendLine("              AND a.Disease_Type_Id = c.Disease_Type_Id " & vbCrLf)
            content.AppendLine("              LEFT JOIN PUB_Insu_Dept d" & vbCrLf)
            content.AppendLine("              ON a.Insu_Sub_Dept_Code = d.Insu_Dept_Code " & vbCrLf)
            content.AppendLine("              where 1=1 " & vbCrLf)

            If Kind_Code.Length > 0 Then
                content.AppendLine("  AND a.Kind_Code=@Kind_Code  ")
            End If

            If Disease_Type_Id.Length > 0 Then
                content.AppendLine("  AND a.Disease_Type_Id =@Disease_Type_Id  ")
            End If

            If Icd10_Code.Length > 0 Then
                content.AppendLine(" AND a.Icd10_Code =@Icd10_Code  ")
            End If

            If Insu_Dept_Code.Length > 0 Then
                content.AppendLine(" AND a.Insu_Dept_Code =@Insu_Dept_Code  ")
            End If

            If Insu_Sub_Dept_Code.Length > 0 Then
                content.AppendLine(" AND a.Insu_Sub_Dept_Code =@Insu_Sub_Dept_Code  ")
            End If

            content.AppendLine("  Order By   a.Kind_Code,a.Disease_Type_Id,a.Icd10_Code,a.Insu_Dept_Code,a.Insu_Sub_Dept_Code")

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Kind_Code", Kind_Code)
            command.Parameters.AddWithValue("@Disease_Type_Id", Disease_Type_Id)
            command.Parameters.AddWithValue("@Icd10_Code", Icd10_Code)
            command.Parameters.AddWithValue("@Insu_Dept_Code", Insu_Dept_Code)
            command.Parameters.AddWithValue("@Insu_Sub_Dept_Code", Insu_Sub_Dept_Code)
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
    Public Function queryCmbData(ByRef strTBName As String, ByRef strWhere As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder

            content.AppendLine("SELECT * FROM " & strTBName & " WHERE " & strWhere & "" & vbCrLf)


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
