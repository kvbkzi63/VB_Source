Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL


Public Class IccHealthUploadBO
    'Syscom's CodeGen Produced This VB Code @ 2016/9/9 下午 03:10:38
    Public Shared ReadOnly tableName As String="ICC_Health_Upload"
    Private Shared myInstance As IccHealthUploadBO
    Public Shared Function GetInstance() As IccHealthUploadBO
        If myInstance Is Nothing Then
            myInstance = New IccHealthUploadBO()
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
            " Health_Sn , A00 , A01 , A02 , A11 ,  " & _ 
             " A12 , A13 , A14 , A15 , A16 ,  " & _ 
             " A17 , A18 , A19 , A20 , A21 ,  " & _ 
             " A22 , A23 , A24 , A25 , A26 ,  " & _ 
             " A27 , A28 , A29 , A30 , A31 ,  " & _ 
             " A32 , A33 , A34 , A35 , A41 ,  " & _ 
             " A42 , A43 , A44 , A51 , A52 ,  " & _ 
             " A53 , A54 , A80 , A81_1 , A81_2 ,  " & _ 
             " A81_3 , Source_Type_Id1 , Source_Type_Id2 , Upload_Type_Id , Upload_Time ,  " & _ 
             " Is_Verify_Succeed , Verify_Fail_Message , Chart_No , Source_Sn , Error_Code_Message ,  " & _ 
             " Cancel , Cancel_User , Cancel_Time , Create_User , Create_Time ,  " & _ 
             " Create_SearchTime , Modified_User , Modified_Time , Is_History , Is_Fix ,  " & _ 
             " Fix_Health_Sn ) " & _ 
             " values( @Health_Sn , @A00 , @A01 , @A02 , @A11 ,  " & _ 
             " @A12 , @A13 , @A14 , @A15 , @A16 ,  " & _ 
             " @A17 , @A18 , @A19 , @A20 , @A21 ,  " & _ 
             " @A22 , @A23 , @A24 , @A25 , @A26 ,  " & _ 
             " @A27 , @A28 , @A29 , @A30 , @A31 ,  " & _ 
             " @A32 , @A33 , @A34 , @A35 , @A41 ,  " & _ 
             " @A42 , @A43 , @A44 , @A51 , @A52 ,  " & _ 
             " @A53 , @A54 , @A80 , @A81_1 , @A81_2 ,  " & _ 
             " @A81_3 , @Source_Type_Id1 , @Source_Type_Id2 , @Upload_Type_Id , @Upload_Time ,  " & _ 
             " @Is_Verify_Succeed , @Verify_Fail_Message , @Chart_No , @Source_Sn , @Error_Code_Message ,  " & _ 
             " @Cancel , @Cancel_User , @Cancel_Time , @Create_User , @Create_Time ,  " & _ 
             " @Create_SearchTime , @Modified_User , @Modified_Time , @Is_History , @Is_Fix ,  " & _ 
             " @Fix_Health_Sn             )"
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
                        Command.Parameters.AddWithValue("@Health_Sn", row.Item("Health_Sn"))
                        Command.Parameters.AddWithValue("@A00", row.Item("A00"))
                        Command.Parameters.AddWithValue("@A01", row.Item("A01"))
                        Command.Parameters.AddWithValue("@A02", row.Item("A02"))
                        Command.Parameters.AddWithValue("@A11", row.Item("A11"))
                        Command.Parameters.AddWithValue("@A12", row.Item("A12"))
                        Command.Parameters.AddWithValue("@A13", row.Item("A13"))
                        Command.Parameters.AddWithValue("@A14", row.Item("A14"))
                        Command.Parameters.AddWithValue("@A15", row.Item("A15"))
                        Command.Parameters.AddWithValue("@A16", row.Item("A16"))
                        Command.Parameters.AddWithValue("@A17", row.Item("A17"))
                        Command.Parameters.AddWithValue("@A18", row.Item("A18"))
                        Command.Parameters.AddWithValue("@A19", row.Item("A19"))
                        Command.Parameters.AddWithValue("@A20", row.Item("A20"))
                        Command.Parameters.AddWithValue("@A21", row.Item("A21"))
                        Command.Parameters.AddWithValue("@A22", row.Item("A22"))
                        Command.Parameters.AddWithValue("@A23", row.Item("A23"))
                        Command.Parameters.AddWithValue("@A24", row.Item("A24"))
                        Command.Parameters.AddWithValue("@A25", row.Item("A25"))
                        Command.Parameters.AddWithValue("@A26", row.Item("A26"))
                        Command.Parameters.AddWithValue("@A27", row.Item("A27"))
                        Command.Parameters.AddWithValue("@A28", row.Item("A28"))
                        Command.Parameters.AddWithValue("@A29", row.Item("A29"))
                        Command.Parameters.AddWithValue("@A30", row.Item("A30"))
                        Command.Parameters.AddWithValue("@A31", row.Item("A31"))
                        Command.Parameters.AddWithValue("@A32", row.Item("A32"))
                        Command.Parameters.AddWithValue("@A33", row.Item("A33"))
                        Command.Parameters.AddWithValue("@A34", row.Item("A34"))
                        Command.Parameters.AddWithValue("@A35", row.Item("A35"))
                        Command.Parameters.AddWithValue("@A41", row.Item("A41"))
                        Command.Parameters.AddWithValue("@A42", row.Item("A42"))
                        Command.Parameters.AddWithValue("@A43", row.Item("A43"))
                        Command.Parameters.AddWithValue("@A44", row.Item("A44"))
                        Command.Parameters.AddWithValue("@A51", row.Item("A51"))
                        Command.Parameters.AddWithValue("@A52", row.Item("A52"))
                        Command.Parameters.AddWithValue("@A53", row.Item("A53"))
                        Command.Parameters.AddWithValue("@A54", row.Item("A54"))
                        Command.Parameters.AddWithValue("@A80", row.Item("A80"))
                        Command.Parameters.AddWithValue("@A81_1", row.Item("A81_1"))
                        Command.Parameters.AddWithValue("@A81_2", row.Item("A81_2"))
                        Command.Parameters.AddWithValue("@A81_3", row.Item("A81_3"))
                        Command.Parameters.AddWithValue("@Source_Type_Id1", row.Item("Source_Type_Id1"))
                        Command.Parameters.AddWithValue("@Source_Type_Id2", row.Item("Source_Type_Id2"))
                        Command.Parameters.AddWithValue("@Upload_Type_Id", row.Item("Upload_Type_Id"))
                        Command.Parameters.AddWithValue("@Upload_Time", row.Item("Upload_Time"))
                        Command.Parameters.AddWithValue("@Is_Verify_Succeed", row.Item("Is_Verify_Succeed"))
                        Command.Parameters.AddWithValue("@Verify_Fail_Message", row.Item("Verify_Fail_Message"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Source_Sn", row.Item("Source_Sn"))
                        Command.Parameters.AddWithValue("@Error_Code_Message", row.Item("Error_Code_Message"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Create_SearchTime", row.Item("Create_SearchTime"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_History", row.Item("Is_History"))
                        Command.Parameters.AddWithValue("@Is_Fix", row.Item("Is_Fix"))
                        Command.Parameters.AddWithValue("@Fix_Health_Sn", row.Item("Fix_Health_Sn"))
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
            " Health_Sn , A00 , A01 , A02 , A11 ,  " & _ 
             " A12 , A13 , A14 , A15 , A16 ,  " & _ 
             " A17 , A18 , A19 , A20 , A21 ,  " & _ 
             " A22 , A23 , A24 , A25 , A26 ,  " & _ 
             " A27 , A28 , A29 , A30 , A31 ,  " & _ 
             " A32 , A33 , A34 , A35 , A41 ,  " & _ 
             " A42 , A43 , A44 , A51 , A52 ,  " & _ 
             " A53 , A54 , A80 , A81_1 , A81_2 ,  " & _ 
             " A81_3 , Source_Type_Id1 , Source_Type_Id2 , Upload_Type_Id , Upload_Time ,  " & _ 
             " Is_Verify_Succeed , Verify_Fail_Message , Chart_No , Source_Sn , Error_Code_Message ,  " & _ 
             " Cancel , Cancel_User , Cancel_Time , Create_User , Create_Time ,  " & _ 
             " Create_SearchTime , Modified_User , Modified_Time , Is_History , Is_Fix ,  " & _ 
             " Fix_Health_Sn ) " & _ 
             " values( @Health_Sn , @A00 , @A01 , @A02 , @A11 ,  " & _ 
             " @A12 , @A13 , @A14 , @A15 , @A16 ,  " & _ 
             " @A17 , @A18 , @A19 , @A20 , @A21 ,  " & _ 
             " @A22 , @A23 , @A24 , @A25 , @A26 ,  " & _ 
             " @A27 , @A28 , @A29 , @A30 , @A31 ,  " & _ 
             " @A32 , @A33 , @A34 , @A35 , @A41 ,  " & _ 
             " @A42 , @A43 , @A44 , @A51 , @A52 ,  " & _ 
             " @A53 , @A54 , @A80 , @A81_1 , @A81_2 ,  " & _ 
             " @A81_3 , @Source_Type_Id1 , @Source_Type_Id2 , @Upload_Type_Id , @Upload_Time ,  " & _ 
             " @Is_Verify_Succeed , @Verify_Fail_Message , @Chart_No , @Source_Sn , @Error_Code_Message ,  " & _ 
             " @Cancel , @Cancel_User , @Cancel_Time , @Create_User , @Create_Time ,  " & _ 
             " @Create_SearchTime , @Modified_User , @Modified_Time , @Is_History , @Is_Fix ,  " & _ 
             " @Fix_Health_Sn             )"
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
                        Command.Parameters.AddWithValue("@Health_Sn", row.Item("Health_Sn"))
                        Command.Parameters.AddWithValue("@A00", row.Item("A00"))
                        Command.Parameters.AddWithValue("@A01", row.Item("A01"))
                        Command.Parameters.AddWithValue("@A02", row.Item("A02"))
                        Command.Parameters.AddWithValue("@A11", row.Item("A11"))
                        Command.Parameters.AddWithValue("@A12", row.Item("A12"))
                        Command.Parameters.AddWithValue("@A13", row.Item("A13"))
                        Command.Parameters.AddWithValue("@A14", row.Item("A14"))
                        Command.Parameters.AddWithValue("@A15", row.Item("A15"))
                        Command.Parameters.AddWithValue("@A16", row.Item("A16"))
                        Command.Parameters.AddWithValue("@A17", row.Item("A17"))
                        Command.Parameters.AddWithValue("@A18", row.Item("A18"))
                        Command.Parameters.AddWithValue("@A19", row.Item("A19"))
                        Command.Parameters.AddWithValue("@A20", row.Item("A20"))
                        Command.Parameters.AddWithValue("@A21", row.Item("A21"))
                        Command.Parameters.AddWithValue("@A22", row.Item("A22"))
                        Command.Parameters.AddWithValue("@A23", row.Item("A23"))
                        Command.Parameters.AddWithValue("@A24", row.Item("A24"))
                        Command.Parameters.AddWithValue("@A25", row.Item("A25"))
                        Command.Parameters.AddWithValue("@A26", row.Item("A26"))
                        Command.Parameters.AddWithValue("@A27", row.Item("A27"))
                        Command.Parameters.AddWithValue("@A28", row.Item("A28"))
                        Command.Parameters.AddWithValue("@A29", row.Item("A29"))
                        Command.Parameters.AddWithValue("@A30", row.Item("A30"))
                        Command.Parameters.AddWithValue("@A31", row.Item("A31"))
                        Command.Parameters.AddWithValue("@A32", row.Item("A32"))
                        Command.Parameters.AddWithValue("@A33", row.Item("A33"))
                        Command.Parameters.AddWithValue("@A34", row.Item("A34"))
                        Command.Parameters.AddWithValue("@A35", row.Item("A35"))
                        Command.Parameters.AddWithValue("@A41", row.Item("A41"))
                        Command.Parameters.AddWithValue("@A42", row.Item("A42"))
                        Command.Parameters.AddWithValue("@A43", row.Item("A43"))
                        Command.Parameters.AddWithValue("@A44", row.Item("A44"))
                        Command.Parameters.AddWithValue("@A51", row.Item("A51"))
                        Command.Parameters.AddWithValue("@A52", row.Item("A52"))
                        Command.Parameters.AddWithValue("@A53", row.Item("A53"))
                        Command.Parameters.AddWithValue("@A54", row.Item("A54"))
                        Command.Parameters.AddWithValue("@A80", row.Item("A80"))
                        Command.Parameters.AddWithValue("@A81_1", row.Item("A81_1"))
                        Command.Parameters.AddWithValue("@A81_2", row.Item("A81_2"))
                        Command.Parameters.AddWithValue("@A81_3", row.Item("A81_3"))
                        Command.Parameters.AddWithValue("@Source_Type_Id1", row.Item("Source_Type_Id1"))
                        Command.Parameters.AddWithValue("@Source_Type_Id2", row.Item("Source_Type_Id2"))
                        Command.Parameters.AddWithValue("@Upload_Type_Id", row.Item("Upload_Type_Id"))
                        Command.Parameters.AddWithValue("@Upload_Time", row.Item("Upload_Time"))
                        Command.Parameters.AddWithValue("@Is_Verify_Succeed", row.Item("Is_Verify_Succeed"))
                        Command.Parameters.AddWithValue("@Verify_Fail_Message", row.Item("Verify_Fail_Message"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Source_Sn", row.Item("Source_Sn"))
                        Command.Parameters.AddWithValue("@Error_Code_Message", row.Item("Error_Code_Message"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Create_SearchTime", row.Item("Create_SearchTime"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_History", row.Item("Is_History"))
                        Command.Parameters.AddWithValue("@Is_Fix", row.Item("Is_Fix"))
                        Command.Parameters.AddWithValue("@Fix_Health_Sn", row.Item("Fix_Health_Sn"))
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
            " Health_Sn , A00 , A01 , A02 , A11 ,  " & _ 
             " A12 , A13 , A14 , A15 , A16 ,  " & _ 
             " A17 , A18 , A19 , A20 , A21 ,  " & _ 
             " A22 , A23 , A24 , A25 , A26 ,  " & _ 
             " A27 , A28 , A29 , A30 , A31 ,  " & _ 
             " A32 , A33 , A34 , A35 , A41 ,  " & _ 
             " A42 , A43 , A44 , A51 , A52 ,  " & _ 
             " A53 , A54 , A80 , A81_1 , A81_2 ,  " & _ 
             " A81_3 , Source_Type_Id1 , Source_Type_Id2 , Upload_Type_Id , Upload_Time ,  " & _ 
             " Is_Verify_Succeed , Verify_Fail_Message , Chart_No , Source_Sn , Error_Code_Message ,  " & _ 
             " Cancel , Cancel_User , Cancel_Time , Create_User , Create_Time ,  " & _ 
             " Create_SearchTime , Modified_User , Modified_Time , Is_History , Is_Fix ,  " & _ 
             " Fix_Health_Sn ) " & _ 
             " values( @Health_Sn , @A00 , @A01 , @A02 , @A11 ,  " & _ 
             " @A12 , @A13 , @A14 , @A15 , @A16 ,  " & _ 
             " @A17 , @A18 , @A19 , @A20 , @A21 ,  " & _ 
             " @A22 , @A23 , @A24 , @A25 , @A26 ,  " & _ 
             " @A27 , @A28 , @A29 , @A30 , @A31 ,  " & _ 
             " @A32 , @A33 , @A34 , @A35 , @A41 ,  " & _ 
             " @A42 , @A43 , @A44 , @A51 , @A52 ,  " & _ 
             " @A53 , @A54 , @A80 , @A81_1 , @A81_2 ,  " & _ 
             " @A81_3 , @Source_Type_Id1 , @Source_Type_Id2 , @Upload_Type_Id , @Upload_Time ,  " & _ 
             " @Is_Verify_Succeed , @Verify_Fail_Message , @Chart_No , @Source_Sn , @Error_Code_Message ,  " & _ 
             " @Cancel , @Cancel_User , @Cancel_Time , @Create_User , @Create_Time ,  " & _ 
             " @Create_SearchTime , @Modified_User , @Modified_Time , @Is_History , @Is_Fix ,  " & _ 
             " @Fix_Health_Sn             )"
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
                        Command.Parameters.AddWithValue("@Health_Sn", row.Item("Health_Sn"))
                        Command.Parameters.AddWithValue("@A00", row.Item("A00"))
                        Command.Parameters.AddWithValue("@A01", row.Item("A01"))
                        Command.Parameters.AddWithValue("@A02", row.Item("A02"))
                        Command.Parameters.AddWithValue("@A11", row.Item("A11"))
                        Command.Parameters.AddWithValue("@A12", row.Item("A12"))
                        Command.Parameters.AddWithValue("@A13", row.Item("A13"))
                        Command.Parameters.AddWithValue("@A14", row.Item("A14"))
                        Command.Parameters.AddWithValue("@A15", row.Item("A15"))
                        Command.Parameters.AddWithValue("@A16", row.Item("A16"))
                        Command.Parameters.AddWithValue("@A17", row.Item("A17"))
                        Command.Parameters.AddWithValue("@A18", row.Item("A18"))
                        Command.Parameters.AddWithValue("@A19", row.Item("A19"))
                        Command.Parameters.AddWithValue("@A20", row.Item("A20"))
                        Command.Parameters.AddWithValue("@A21", row.Item("A21"))
                        Command.Parameters.AddWithValue("@A22", row.Item("A22"))
                        Command.Parameters.AddWithValue("@A23", row.Item("A23"))
                        Command.Parameters.AddWithValue("@A24", row.Item("A24"))
                        Command.Parameters.AddWithValue("@A25", row.Item("A25"))
                        Command.Parameters.AddWithValue("@A26", row.Item("A26"))
                        Command.Parameters.AddWithValue("@A27", row.Item("A27"))
                        Command.Parameters.AddWithValue("@A28", row.Item("A28"))
                        Command.Parameters.AddWithValue("@A29", row.Item("A29"))
                        Command.Parameters.AddWithValue("@A30", row.Item("A30"))
                        Command.Parameters.AddWithValue("@A31", row.Item("A31"))
                        Command.Parameters.AddWithValue("@A32", row.Item("A32"))
                        Command.Parameters.AddWithValue("@A33", row.Item("A33"))
                        Command.Parameters.AddWithValue("@A34", row.Item("A34"))
                        Command.Parameters.AddWithValue("@A35", row.Item("A35"))
                        Command.Parameters.AddWithValue("@A41", row.Item("A41"))
                        Command.Parameters.AddWithValue("@A42", row.Item("A42"))
                        Command.Parameters.AddWithValue("@A43", row.Item("A43"))
                        Command.Parameters.AddWithValue("@A44", row.Item("A44"))
                        Command.Parameters.AddWithValue("@A51", row.Item("A51"))
                        Command.Parameters.AddWithValue("@A52", row.Item("A52"))
                        Command.Parameters.AddWithValue("@A53", row.Item("A53"))
                        Command.Parameters.AddWithValue("@A54", row.Item("A54"))
                        Command.Parameters.AddWithValue("@A80", row.Item("A80"))
                        Command.Parameters.AddWithValue("@A81_1", row.Item("A81_1"))
                        Command.Parameters.AddWithValue("@A81_2", row.Item("A81_2"))
                        Command.Parameters.AddWithValue("@A81_3", row.Item("A81_3"))
                        Command.Parameters.AddWithValue("@Source_Type_Id1", row.Item("Source_Type_Id1"))
                        Command.Parameters.AddWithValue("@Source_Type_Id2", row.Item("Source_Type_Id2"))
                        Command.Parameters.AddWithValue("@Upload_Type_Id", row.Item("Upload_Type_Id"))
                        Command.Parameters.AddWithValue("@Upload_Time", row.Item("Upload_Time"))
                        Command.Parameters.AddWithValue("@Is_Verify_Succeed", row.Item("Is_Verify_Succeed"))
                        Command.Parameters.AddWithValue("@Verify_Fail_Message", row.Item("Verify_Fail_Message"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Source_Sn", row.Item("Source_Sn"))
                        Command.Parameters.AddWithValue("@Error_Code_Message", row.Item("Error_Code_Message"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Create_SearchTime", row.Item("Create_SearchTime"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Is_History", row.Item("Is_History"))
                        Command.Parameters.AddWithValue("@Is_Fix", row.Item("Is_Fix"))
                        Command.Parameters.AddWithValue("@Fix_Health_Sn", row.Item("Fix_Health_Sn"))
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
            " A00=@A00 , A01=@A01 , A02=@A02 , A11=@A11 " & _ 
            "  , A12=@A12 , A13=@A13 , A14=@A14 , A15=@A15 , A16=@A16 " & _ 
            "  , A17=@A17 , A18=@A18 , A19=@A19 , A20=@A20 , A21=@A21 " & _ 
            "  , A22=@A22 , A23=@A23 , A24=@A24 , A25=@A25 , A26=@A26 " & _ 
            "  , A27=@A27 , A28=@A28 , A29=@A29 , A30=@A30 , A31=@A31 " & _ 
            "  , A32=@A32 , A33=@A33 , A34=@A34 , A35=@A35 , A41=@A41 " & _ 
            "  , A42=@A42 , A43=@A43 , A44=@A44 , A51=@A51 , A52=@A52 " & _ 
            "  , A53=@A53 , A54=@A54 , A80=@A80 , A81_1=@A81_1 , A81_2=@A81_2 " & _ 
            "  , A81_3=@A81_3 , Source_Type_Id1=@Source_Type_Id1 , Source_Type_Id2=@Source_Type_Id2 , Upload_Type_Id=@Upload_Type_Id , Upload_Time=@Upload_Time " & _ 
            "  , Is_Verify_Succeed=@Is_Verify_Succeed , Verify_Fail_Message=@Verify_Fail_Message , Chart_No=@Chart_No , Source_Sn=@Source_Sn , Error_Code_Message=@Error_Code_Message " & _ 
            "  , Cancel=@Cancel , Cancel_User=@Cancel_User , Cancel_Time=@Cancel_Time , Create_SearchTime=@Create_SearchTime , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_History=@Is_History , Is_Fix=@Is_Fix " & _ 
            "  , Fix_Health_Sn=@Fix_Health_Sn " & _ 
            " where  Health_Sn=@Health_Sn            "
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
                        Command.Parameters.AddWithValue("@Health_Sn", row.Item("Health_Sn"))
                        Command.Parameters.AddWithValue("@A00", row.Item("A00"))
                        Command.Parameters.AddWithValue("@A01", row.Item("A01"))
                        Command.Parameters.AddWithValue("@A02", row.Item("A02"))
                        Command.Parameters.AddWithValue("@A11", row.Item("A11"))
                        Command.Parameters.AddWithValue("@A12", row.Item("A12"))
                        Command.Parameters.AddWithValue("@A13", row.Item("A13"))
                        Command.Parameters.AddWithValue("@A14", row.Item("A14"))
                        Command.Parameters.AddWithValue("@A15", row.Item("A15"))
                        Command.Parameters.AddWithValue("@A16", row.Item("A16"))
                        Command.Parameters.AddWithValue("@A17", row.Item("A17"))
                        Command.Parameters.AddWithValue("@A18", row.Item("A18"))
                        Command.Parameters.AddWithValue("@A19", row.Item("A19"))
                        Command.Parameters.AddWithValue("@A20", row.Item("A20"))
                        Command.Parameters.AddWithValue("@A21", row.Item("A21"))
                        Command.Parameters.AddWithValue("@A22", row.Item("A22"))
                        Command.Parameters.AddWithValue("@A23", row.Item("A23"))
                        Command.Parameters.AddWithValue("@A24", row.Item("A24"))
                        Command.Parameters.AddWithValue("@A25", row.Item("A25"))
                        Command.Parameters.AddWithValue("@A26", row.Item("A26"))
                        Command.Parameters.AddWithValue("@A27", row.Item("A27"))
                        Command.Parameters.AddWithValue("@A28", row.Item("A28"))
                        Command.Parameters.AddWithValue("@A29", row.Item("A29"))
                        Command.Parameters.AddWithValue("@A30", row.Item("A30"))
                        Command.Parameters.AddWithValue("@A31", row.Item("A31"))
                        Command.Parameters.AddWithValue("@A32", row.Item("A32"))
                        Command.Parameters.AddWithValue("@A33", row.Item("A33"))
                        Command.Parameters.AddWithValue("@A34", row.Item("A34"))
                        Command.Parameters.AddWithValue("@A35", row.Item("A35"))
                        Command.Parameters.AddWithValue("@A41", row.Item("A41"))
                        Command.Parameters.AddWithValue("@A42", row.Item("A42"))
                        Command.Parameters.AddWithValue("@A43", row.Item("A43"))
                        Command.Parameters.AddWithValue("@A44", row.Item("A44"))
                        Command.Parameters.AddWithValue("@A51", row.Item("A51"))
                        Command.Parameters.AddWithValue("@A52", row.Item("A52"))
                        Command.Parameters.AddWithValue("@A53", row.Item("A53"))
                        Command.Parameters.AddWithValue("@A54", row.Item("A54"))
                        Command.Parameters.AddWithValue("@A80", row.Item("A80"))
                        Command.Parameters.AddWithValue("@A81_1", row.Item("A81_1"))
                        Command.Parameters.AddWithValue("@A81_2", row.Item("A81_2"))
                        Command.Parameters.AddWithValue("@A81_3", row.Item("A81_3"))
                        Command.Parameters.AddWithValue("@Source_Type_Id1", row.Item("Source_Type_Id1"))
                        Command.Parameters.AddWithValue("@Source_Type_Id2", row.Item("Source_Type_Id2"))
                        Command.Parameters.AddWithValue("@Upload_Type_Id", row.Item("Upload_Type_Id"))
                        Command.Parameters.AddWithValue("@Upload_Time", row.Item("Upload_Time"))
                        Command.Parameters.AddWithValue("@Is_Verify_Succeed", row.Item("Is_Verify_Succeed"))
                        Command.Parameters.AddWithValue("@Verify_Fail_Message", row.Item("Verify_Fail_Message"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Source_Sn", row.Item("Source_Sn"))
                        Command.Parameters.AddWithValue("@Error_Code_Message", row.Item("Error_Code_Message"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Create_SearchTime", row.Item("Create_SearchTime"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_History", row.Item("Is_History"))
                        Command.Parameters.AddWithValue("@Is_Fix", row.Item("Is_Fix"))
                        Command.Parameters.AddWithValue("@Fix_Health_Sn", row.Item("Fix_Health_Sn"))
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
            " A00=@A00 , A01=@A01 , A02=@A02 , A11=@A11 " & _ 
            "  , A12=@A12 , A13=@A13 , A14=@A14 , A15=@A15 , A16=@A16 " & _ 
            "  , A17=@A17 , A18=@A18 , A19=@A19 , A20=@A20 , A21=@A21 " & _ 
            "  , A22=@A22 , A23=@A23 , A24=@A24 , A25=@A25 , A26=@A26 " & _ 
            "  , A27=@A27 , A28=@A28 , A29=@A29 , A30=@A30 , A31=@A31 " & _ 
            "  , A32=@A32 , A33=@A33 , A34=@A34 , A35=@A35 , A41=@A41 " & _ 
            "  , A42=@A42 , A43=@A43 , A44=@A44 , A51=@A51 , A52=@A52 " & _ 
            "  , A53=@A53 , A54=@A54 , A80=@A80 , A81_1=@A81_1 , A81_2=@A81_2 " & _ 
            "  , A81_3=@A81_3 , Source_Type_Id1=@Source_Type_Id1 , Source_Type_Id2=@Source_Type_Id2 , Upload_Type_Id=@Upload_Type_Id , Upload_Time=@Upload_Time " & _ 
            "  , Is_Verify_Succeed=@Is_Verify_Succeed , Verify_Fail_Message=@Verify_Fail_Message , Chart_No=@Chart_No , Source_Sn=@Source_Sn , Error_Code_Message=@Error_Code_Message " & _ 
            "  , Cancel=@Cancel , Cancel_User=@Cancel_User , Cancel_Time=@Cancel_Time , Create_SearchTime=@Create_SearchTime , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_History=@Is_History , Is_Fix=@Is_Fix " & _ 
            "  , Fix_Health_Sn=@Fix_Health_Sn " & _ 
            " where  Health_Sn=@Health_Sn            "
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
                        Command.Parameters.AddWithValue("@Health_Sn", row.Item("Health_Sn"))
                        Command.Parameters.AddWithValue("@A00", row.Item("A00"))
                        Command.Parameters.AddWithValue("@A01", row.Item("A01"))
                        Command.Parameters.AddWithValue("@A02", row.Item("A02"))
                        Command.Parameters.AddWithValue("@A11", row.Item("A11"))
                        Command.Parameters.AddWithValue("@A12", row.Item("A12"))
                        Command.Parameters.AddWithValue("@A13", row.Item("A13"))
                        Command.Parameters.AddWithValue("@A14", row.Item("A14"))
                        Command.Parameters.AddWithValue("@A15", row.Item("A15"))
                        Command.Parameters.AddWithValue("@A16", row.Item("A16"))
                        Command.Parameters.AddWithValue("@A17", row.Item("A17"))
                        Command.Parameters.AddWithValue("@A18", row.Item("A18"))
                        Command.Parameters.AddWithValue("@A19", row.Item("A19"))
                        Command.Parameters.AddWithValue("@A20", row.Item("A20"))
                        Command.Parameters.AddWithValue("@A21", row.Item("A21"))
                        Command.Parameters.AddWithValue("@A22", row.Item("A22"))
                        Command.Parameters.AddWithValue("@A23", row.Item("A23"))
                        Command.Parameters.AddWithValue("@A24", row.Item("A24"))
                        Command.Parameters.AddWithValue("@A25", row.Item("A25"))
                        Command.Parameters.AddWithValue("@A26", row.Item("A26"))
                        Command.Parameters.AddWithValue("@A27", row.Item("A27"))
                        Command.Parameters.AddWithValue("@A28", row.Item("A28"))
                        Command.Parameters.AddWithValue("@A29", row.Item("A29"))
                        Command.Parameters.AddWithValue("@A30", row.Item("A30"))
                        Command.Parameters.AddWithValue("@A31", row.Item("A31"))
                        Command.Parameters.AddWithValue("@A32", row.Item("A32"))
                        Command.Parameters.AddWithValue("@A33", row.Item("A33"))
                        Command.Parameters.AddWithValue("@A34", row.Item("A34"))
                        Command.Parameters.AddWithValue("@A35", row.Item("A35"))
                        Command.Parameters.AddWithValue("@A41", row.Item("A41"))
                        Command.Parameters.AddWithValue("@A42", row.Item("A42"))
                        Command.Parameters.AddWithValue("@A43", row.Item("A43"))
                        Command.Parameters.AddWithValue("@A44", row.Item("A44"))
                        Command.Parameters.AddWithValue("@A51", row.Item("A51"))
                        Command.Parameters.AddWithValue("@A52", row.Item("A52"))
                        Command.Parameters.AddWithValue("@A53", row.Item("A53"))
                        Command.Parameters.AddWithValue("@A54", row.Item("A54"))
                        Command.Parameters.AddWithValue("@A80", row.Item("A80"))
                        Command.Parameters.AddWithValue("@A81_1", row.Item("A81_1"))
                        Command.Parameters.AddWithValue("@A81_2", row.Item("A81_2"))
                        Command.Parameters.AddWithValue("@A81_3", row.Item("A81_3"))
                        Command.Parameters.AddWithValue("@Source_Type_Id1", row.Item("Source_Type_Id1"))
                        Command.Parameters.AddWithValue("@Source_Type_Id2", row.Item("Source_Type_Id2"))
                        Command.Parameters.AddWithValue("@Upload_Type_Id", row.Item("Upload_Type_Id"))
                        Command.Parameters.AddWithValue("@Upload_Time", row.Item("Upload_Time"))
                        Command.Parameters.AddWithValue("@Is_Verify_Succeed", row.Item("Is_Verify_Succeed"))
                        Command.Parameters.AddWithValue("@Verify_Fail_Message", row.Item("Verify_Fail_Message"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Source_Sn", row.Item("Source_Sn"))
                        Command.Parameters.AddWithValue("@Error_Code_Message", row.Item("Error_Code_Message"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Create_SearchTime", row.Item("Create_SearchTime"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Is_History", row.Item("Is_History"))
                        Command.Parameters.AddWithValue("@Is_Fix", row.Item("Is_Fix"))
                        Command.Parameters.AddWithValue("@Fix_Health_Sn", row.Item("Fix_Health_Sn"))
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
            " A00=@A00 , A01=@A01 , A02=@A02 , A11=@A11 " & _ 
            "  , A12=@A12 , A13=@A13 , A14=@A14 , A15=@A15 , A16=@A16 " & _ 
            "  , A17=@A17 , A18=@A18 , A19=@A19 , A20=@A20 , A21=@A21 " & _ 
            "  , A22=@A22 , A23=@A23 , A24=@A24 , A25=@A25 , A26=@A26 " & _ 
            "  , A27=@A27 , A28=@A28 , A29=@A29 , A30=@A30 , A31=@A31 " & _ 
            "  , A32=@A32 , A33=@A33 , A34=@A34 , A35=@A35 , A41=@A41 " & _ 
            "  , A42=@A42 , A43=@A43 , A44=@A44 , A51=@A51 , A52=@A52 " & _ 
            "  , A53=@A53 , A54=@A54 , A80=@A80 , A81_1=@A81_1 , A81_2=@A81_2 " & _ 
            "  , A81_3=@A81_3 , Source_Type_Id1=@Source_Type_Id1 , Source_Type_Id2=@Source_Type_Id2 , Upload_Type_Id=@Upload_Type_Id , Upload_Time=@Upload_Time " & _ 
            "  , Is_Verify_Succeed=@Is_Verify_Succeed , Verify_Fail_Message=@Verify_Fail_Message , Chart_No=@Chart_No , Source_Sn=@Source_Sn , Error_Code_Message=@Error_Code_Message " & _ 
            "  , Cancel=@Cancel , Cancel_User=@Cancel_User , Cancel_Time=@Cancel_Time , Create_SearchTime=@Create_SearchTime , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_History=@Is_History , Is_Fix=@Is_Fix " & _ 
            "  , Fix_Health_Sn=@Fix_Health_Sn " & _ 
            " where  Health_Sn=@Health_Sn            "
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
                        Command.Parameters.AddWithValue("@Health_Sn", row.Item("Health_Sn"))
                        Command.Parameters.AddWithValue("@A00", row.Item("A00"))
                        Command.Parameters.AddWithValue("@A01", row.Item("A01"))
                        Command.Parameters.AddWithValue("@A02", row.Item("A02"))
                        Command.Parameters.AddWithValue("@A11", row.Item("A11"))
                        Command.Parameters.AddWithValue("@A12", row.Item("A12"))
                        Command.Parameters.AddWithValue("@A13", row.Item("A13"))
                        Command.Parameters.AddWithValue("@A14", row.Item("A14"))
                        Command.Parameters.AddWithValue("@A15", row.Item("A15"))
                        Command.Parameters.AddWithValue("@A16", row.Item("A16"))
                        Command.Parameters.AddWithValue("@A17", row.Item("A17"))
                        Command.Parameters.AddWithValue("@A18", row.Item("A18"))
                        Command.Parameters.AddWithValue("@A19", row.Item("A19"))
                        Command.Parameters.AddWithValue("@A20", row.Item("A20"))
                        Command.Parameters.AddWithValue("@A21", row.Item("A21"))
                        Command.Parameters.AddWithValue("@A22", row.Item("A22"))
                        Command.Parameters.AddWithValue("@A23", row.Item("A23"))
                        Command.Parameters.AddWithValue("@A24", row.Item("A24"))
                        Command.Parameters.AddWithValue("@A25", row.Item("A25"))
                        Command.Parameters.AddWithValue("@A26", row.Item("A26"))
                        Command.Parameters.AddWithValue("@A27", row.Item("A27"))
                        Command.Parameters.AddWithValue("@A28", row.Item("A28"))
                        Command.Parameters.AddWithValue("@A29", row.Item("A29"))
                        Command.Parameters.AddWithValue("@A30", row.Item("A30"))
                        Command.Parameters.AddWithValue("@A31", row.Item("A31"))
                        Command.Parameters.AddWithValue("@A32", row.Item("A32"))
                        Command.Parameters.AddWithValue("@A33", row.Item("A33"))
                        Command.Parameters.AddWithValue("@A34", row.Item("A34"))
                        Command.Parameters.AddWithValue("@A35", row.Item("A35"))
                        Command.Parameters.AddWithValue("@A41", row.Item("A41"))
                        Command.Parameters.AddWithValue("@A42", row.Item("A42"))
                        Command.Parameters.AddWithValue("@A43", row.Item("A43"))
                        Command.Parameters.AddWithValue("@A44", row.Item("A44"))
                        Command.Parameters.AddWithValue("@A51", row.Item("A51"))
                        Command.Parameters.AddWithValue("@A52", row.Item("A52"))
                        Command.Parameters.AddWithValue("@A53", row.Item("A53"))
                        Command.Parameters.AddWithValue("@A54", row.Item("A54"))
                        Command.Parameters.AddWithValue("@A80", row.Item("A80"))
                        Command.Parameters.AddWithValue("@A81_1", row.Item("A81_1"))
                        Command.Parameters.AddWithValue("@A81_2", row.Item("A81_2"))
                        Command.Parameters.AddWithValue("@A81_3", row.Item("A81_3"))
                        Command.Parameters.AddWithValue("@Source_Type_Id1", row.Item("Source_Type_Id1"))
                        Command.Parameters.AddWithValue("@Source_Type_Id2", row.Item("Source_Type_Id2"))
                        Command.Parameters.AddWithValue("@Upload_Type_Id", row.Item("Upload_Type_Id"))
                        Command.Parameters.AddWithValue("@Upload_Time", row.Item("Upload_Time"))
                        Command.Parameters.AddWithValue("@Is_Verify_Succeed", row.Item("Is_Verify_Succeed"))
                        Command.Parameters.AddWithValue("@Verify_Fail_Message", row.Item("Verify_Fail_Message"))
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Source_Sn", row.Item("Source_Sn"))
                        Command.Parameters.AddWithValue("@Error_Code_Message", row.Item("Error_Code_Message"))
                        Command.Parameters.AddWithValue("@Cancel", row.Item("Cancel"))
                        Command.Parameters.AddWithValue("@Cancel_User", row.Item("Cancel_User"))
                        Command.Parameters.AddWithValue("@Cancel_Time", row.Item("Cancel_Time"))
                        Command.Parameters.AddWithValue("@Create_SearchTime", row.Item("Create_SearchTime"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_History", row.Item("Is_History"))
                        Command.Parameters.AddWithValue("@Is_Fix", row.Item("Is_Fix"))
                        Command.Parameters.AddWithValue("@Fix_Health_Sn", row.Item("Fix_Health_Sn"))
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
    Public Function delete(ByRef pk_Health_Sn As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Health_Sn=@Health_Sn "
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
                Command.Parameters.AddWithValue("@Health_Sn", pk_Health_Sn)
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
    Public Function queryByPK(ByRef pk_Health_Sn As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Health_Sn , A00 , A01 , A02 , A11 ,  ") 
            content.AppendLine(" A12 , A13 , A14 , A15 , A16 ,  ") 
            content.AppendLine(" A17 , A18 , A19 , A20 , A21 ,  ") 
            content.AppendLine(" A22 , A23 , A24 , A25 , A26 ,  ") 
            content.AppendLine(" A27 , A28 , A29 , A30 , A31 ,  ") 
            content.AppendLine(" A32 , A33 , A34 , A35 , A41 ,  ") 
            content.AppendLine(" A42 , A43 , A44 , A51 , A52 ,  ") 
            content.AppendLine(" A53 , A54 , A80 , A81_1 , A81_2 ,  ") 
            content.AppendLine(" A81_3 , Source_Type_Id1 , Source_Type_Id2 , Upload_Type_Id , Upload_Time ,  ") 
            content.AppendLine(" Is_Verify_Succeed , Verify_Fail_Message , Chart_No , Source_Sn , Error_Code_Message ,  ") 
            content.AppendLine(" Cancel , Cancel_User , Cancel_Time , Create_User , Create_Time ,  ") 
            content.AppendLine(" Create_SearchTime , Modified_User , Modified_Time , Is_History , Is_Fix ,  ") 
            content.AppendLine(" Fix_Health_Sn                from " & tableName)
            content.AppendLine("   where Health_Sn=@Health_Sn            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Health_Sn",pk_Health_Sn)
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
    Public Function queryByLikePK(ByRef pk_Health_Sn As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Health_Sn , A00 , A01 , A02 , A11 ,  ") 
            content.AppendLine(" A12 , A13 , A14 , A15 , A16 ,  ") 
            content.AppendLine(" A17 , A18 , A19 , A20 , A21 ,  ") 
            content.AppendLine(" A22 , A23 , A24 , A25 , A26 ,  ") 
            content.AppendLine(" A27 , A28 , A29 , A30 , A31 ,  ") 
            content.AppendLine(" A32 , A33 , A34 , A35 , A41 ,  ") 
            content.AppendLine(" A42 , A43 , A44 , A51 , A52 ,  ") 
            content.AppendLine(" A53 , A54 , A80 , A81_1 , A81_2 ,  ") 
            content.AppendLine(" A81_3 , Source_Type_Id1 , Source_Type_Id2 , Upload_Type_Id , Upload_Time ,  ") 
            content.AppendLine(" Is_Verify_Succeed , Verify_Fail_Message , Chart_No , Source_Sn , Error_Code_Message ,  ") 
            content.AppendLine(" Cancel , Cancel_User , Cancel_Time , Create_User , Create_Time ,  ") 
            content.AppendLine(" Create_SearchTime , Modified_User , Modified_Time , Is_History , Is_Fix ,  ") 
            content.AppendLine(" Fix_Health_Sn                from " & tableName)
            content.AppendLine("   where Health_Sn like @Health_Sn "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Health_Sn",pk_Health_Sn & "%")
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
            content.AppendLine(" Health_Sn , A00 , A01 , A02 , A11 ,  ") 
            content.AppendLine(" A12 , A13 , A14 , A15 , A16 ,  ") 
            content.AppendLine(" A17 , A18 , A19 , A20 , A21 ,  ") 
            content.AppendLine(" A22 , A23 , A24 , A25 , A26 ,  ") 
            content.AppendLine(" A27 , A28 , A29 , A30 , A31 ,  ") 
            content.AppendLine(" A32 , A33 , A34 , A35 , A41 ,  ") 
            content.AppendLine(" A42 , A43 , A44 , A51 , A52 ,  ") 
            content.AppendLine(" A53 , A54 , A80 , A81_1 , A81_2 ,  ") 
            content.AppendLine(" A81_3 , Source_Type_Id1 , Source_Type_Id2 , Upload_Type_Id , Upload_Time ,  ") 
            content.AppendLine(" Is_Verify_Succeed , Verify_Fail_Message , Chart_No , Source_Sn , Error_Code_Message ,  ") 
            content.AppendLine(" Cancel , Cancel_User , Cancel_Time , Create_User , Create_Time ,  ") 
            content.AppendLine(" Create_SearchTime , Modified_User , Modified_Time , Is_History , Is_Fix ,  ") 
            content.AppendLine(" Fix_Health_Sn                from " & tableName )
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
            content.Append("select   Health_Sn , A00 , A01 , A02 , A11 ,  " & _ 
             " A12 , A13 , A14 , A15 , A16 ,  " & _ 
             " A17 , A18 , A19 , A20 , A21 ,  " & _ 
             " A22 , A23 , A24 , A25 , A26 ,  " & _ 
             " A27 , A28 , A29 , A30 , A31 ,  " & _ 
             " A32 , A33 , A34 , A35 , A41 ,  " & _ 
             " A42 , A43 , A44 , A51 , A52 ,  " & _ 
             " A53 , A54 , A80 , A81_1 , A81_2 ,  " & _ 
             " A81_3 , Source_Type_Id1 , Source_Type_Id2 , Upload_Type_Id , Upload_Time ,  " & _ 
             " Is_Verify_Succeed , Verify_Fail_Message , Chart_No , Source_Sn , Error_Code_Message ,  " & _ 
             " Cancel , Cancel_User , Cancel_Time , Create_User , Create_Time ,  " & _ 
             " Create_SearchTime , Modified_User , Modified_Time , Is_History , Is_Fix ,  " & _ 
             " Fix_Health_Sn            from " & tableName & " where 1=1 ")
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
    '''取得表格 ICC_Health_Upload 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function
#End Region

End Class
