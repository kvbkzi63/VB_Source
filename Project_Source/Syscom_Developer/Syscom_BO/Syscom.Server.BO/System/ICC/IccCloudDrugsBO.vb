Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class IccCloudDrugsBO
    'Syscom's CodeGen Produced This VB Code @ 2015/11/11 下午 05:55:50
    Public Shared ReadOnly tableName As String = "ICC_Cloud_Drugs"
    Private Shared myInstance As IccCloudDrugsBO
    Public Shared Function GetInstance() As IccCloudDrugsBO
        If myInstance Is Nothing Then
            myInstance = New IccCloudDrugsBO()
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
            " ID_No , Drug_No , Source , Icd_Code , Icd_Name ,  " & _
             " ATC5_Code , ATC5_Name , Element_Code , Element_Name , Insu_Code ,  " & _
             " Drug_Name , Spec_Qty , Spec_Qty_Unit , Dosage_Method , Medical_Date ,  " & _
             " Chronic_Receive_Date , Dosage , Days , Left_Days , Download_Time ,  " & _
             " Chart_No ) " & _
             " values( @ID_No , @Drug_No , @Source , @Icd_Code , @Icd_Name ,  " & _
             " @ATC5_Code , @ATC5_Name , @Element_Code , @Element_Name , @Insu_Code ,  " & _
             " @Drug_Name , @Spec_Qty , @Spec_Qty_Unit , @Dosage_Method , @Medical_Date ,  " & _
             " @Chronic_Receive_Date , @Dosage , @Days , @Left_Days , @Download_Time ,  " & _
             " @Chart_No             )"
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
                    Command.Parameters.AddWithValue("@ID_No", row.Item("ID_No"))
                    Command.Parameters.AddWithValue("@Drug_No", row.Item("Drug_No"))
                    Command.Parameters.AddWithValue("@Source", row.Item("Source"))
                    Command.Parameters.AddWithValue("@Icd_Code", row.Item("Icd_Code"))
                    Command.Parameters.AddWithValue("@Icd_Name", row.Item("Icd_Name"))
                    Command.Parameters.AddWithValue("@ATC5_Code", row.Item("ATC5_Code"))
                    Command.Parameters.AddWithValue("@ATC5_Name", row.Item("ATC5_Name"))
                    Command.Parameters.AddWithValue("@Element_Code", row.Item("Element_Code"))
                    Command.Parameters.AddWithValue("@Element_Name", row.Item("Element_Name"))
                    Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                    Command.Parameters.AddWithValue("@Drug_Name", row.Item("Drug_Name"))
                    Command.Parameters.AddWithValue("@Spec_Qty", row.Item("Spec_Qty"))
                    Command.Parameters.AddWithValue("@Spec_Qty_Unit", row.Item("Spec_Qty_Unit"))
                    Command.Parameters.AddWithValue("@Dosage_Method", row.Item("Dosage_Method"))
                    Command.Parameters.AddWithValue("@Medical_Date", row.Item("Medical_Date"))
                    Command.Parameters.AddWithValue("@Chronic_Receive_Date", row.Item("Chronic_Receive_Date"))
                    Command.Parameters.AddWithValue("@Dosage", row.Item("Dosage"))
                    Command.Parameters.AddWithValue("@Days", row.Item("Days"))
                    Command.Parameters.AddWithValue("@Left_Days", row.Item("Left_Days"))
                    Command.Parameters.AddWithValue("@Download_Time", row.Item("Download_Time"))
                    Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
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
            " ID_No , Drug_No , Source , Icd_Code , Icd_Name ,  " & _
             " ATC5_Code , ATC5_Name , Element_Code , Element_Name , Insu_Code ,  " & _
             " Drug_Name , Spec_Qty , Spec_Qty_Unit , Dosage_Method , Medical_Date ,  " & _
             " Chronic_Receive_Date , Dosage , Days , Left_Days , Download_Time ,  " & _
             " Chart_No ) " & _
             " values( @ID_No , @Drug_No , @Source , @Icd_Code , @Icd_Name ,  " & _
             " @ATC5_Code , @ATC5_Name , @Element_Code , @Element_Name , @Insu_Code ,  " & _
             " @Drug_Name , @Spec_Qty , @Spec_Qty_Unit , @Dosage_Method , @Medical_Date ,  " & _
             " @Chronic_Receive_Date , @Dosage , @Days , @Left_Days , @Download_Time ,  " & _
             " @Chart_No             )"
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
                    Command.Parameters.AddWithValue("@ID_No", row.Item("ID_No"))
                    Command.Parameters.AddWithValue("@Drug_No", row.Item("Drug_No"))
                    Command.Parameters.AddWithValue("@Source", row.Item("Source"))
                    Command.Parameters.AddWithValue("@Icd_Code", row.Item("Icd_Code"))
                    Command.Parameters.AddWithValue("@Icd_Name", row.Item("Icd_Name"))
                    Command.Parameters.AddWithValue("@ATC5_Code", row.Item("ATC5_Code"))
                    Command.Parameters.AddWithValue("@ATC5_Name", row.Item("ATC5_Name"))
                    Command.Parameters.AddWithValue("@Element_Code", row.Item("Element_Code"))
                    Command.Parameters.AddWithValue("@Element_Name", row.Item("Element_Name"))
                    Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                    Command.Parameters.AddWithValue("@Drug_Name", row.Item("Drug_Name"))
                    Command.Parameters.AddWithValue("@Spec_Qty", row.Item("Spec_Qty"))
                    Command.Parameters.AddWithValue("@Spec_Qty_Unit", row.Item("Spec_Qty_Unit"))
                    Command.Parameters.AddWithValue("@Dosage_Method", row.Item("Dosage_Method"))
                    Command.Parameters.AddWithValue("@Medical_Date", row.Item("Medical_Date"))
                    Command.Parameters.AddWithValue("@Chronic_Receive_Date", row.Item("Chronic_Receive_Date"))
                    Command.Parameters.AddWithValue("@Dosage", row.Item("Dosage"))
                    Command.Parameters.AddWithValue("@Days", row.Item("Days"))
                    Command.Parameters.AddWithValue("@Left_Days", row.Item("Left_Days"))
                    Command.Parameters.AddWithValue("@Download_Time", row.Item("Download_Time"))
                    Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
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
            " ID_No , Drug_No , Source , Icd_Code , Icd_Name ,  " & _
             " ATC5_Code , ATC5_Name , Element_Code , Element_Name , Insu_Code ,  " & _
             " Drug_Name , Spec_Qty , Spec_Qty_Unit , Dosage_Method , Medical_Date ,  " & _
             " Chronic_Receive_Date , Dosage , Days , Left_Days , Download_Time ,  " & _
             " Chart_No ) " & _
             " values( @ID_No , @Drug_No , @Source , @Icd_Code , @Icd_Name ,  " & _
             " @ATC5_Code , @ATC5_Name , @Element_Code , @Element_Name , @Insu_Code ,  " & _
             " @Drug_Name , @Spec_Qty , @Spec_Qty_Unit , @Dosage_Method , @Medical_Date ,  " & _
             " @Chronic_Receive_Date , @Dosage , @Days , @Left_Days , @Download_Time ,  " & _
             " @Chart_No             )"
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
                    Command.Parameters.AddWithValue("@ID_No", row.Item("ID_No"))
                    Command.Parameters.AddWithValue("@Drug_No", row.Item("Drug_No"))
                    Command.Parameters.AddWithValue("@Source", row.Item("Source"))
                    Command.Parameters.AddWithValue("@Icd_Code", row.Item("Icd_Code"))
                    Command.Parameters.AddWithValue("@Icd_Name", row.Item("Icd_Name"))
                    Command.Parameters.AddWithValue("@ATC5_Code", row.Item("ATC5_Code"))
                    Command.Parameters.AddWithValue("@ATC5_Name", row.Item("ATC5_Name"))
                    Command.Parameters.AddWithValue("@Element_Code", row.Item("Element_Code"))
                    Command.Parameters.AddWithValue("@Element_Name", row.Item("Element_Name"))
                    Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                    Command.Parameters.AddWithValue("@Drug_Name", row.Item("Drug_Name"))
                    Command.Parameters.AddWithValue("@Spec_Qty", row.Item("Spec_Qty"))
                    Command.Parameters.AddWithValue("@Spec_Qty_Unit", row.Item("Spec_Qty_Unit"))
                    Command.Parameters.AddWithValue("@Dosage_Method", row.Item("Dosage_Method"))
                    Command.Parameters.AddWithValue("@Medical_Date", row.Item("Medical_Date"))
                    Command.Parameters.AddWithValue("@Chronic_Receive_Date", row.Item("Chronic_Receive_Date"))
                    Command.Parameters.AddWithValue("@Dosage", row.Item("Dosage"))
                    Command.Parameters.AddWithValue("@Days", row.Item("Days"))
                    Command.Parameters.AddWithValue("@Left_Days", row.Item("Left_Days"))
                    Command.Parameters.AddWithValue("@Download_Time", row.Item("Download_Time"))
                    Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
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
            " Source=@Source , Icd_Code=@Icd_Code , Icd_Name=@Icd_Name " & _
            "  , ATC5_Code=@ATC5_Code , ATC5_Name=@ATC5_Name , Element_Code=@Element_Code , Element_Name=@Element_Name , Insu_Code=@Insu_Code " & _
            "  , Drug_Name=@Drug_Name , Spec_Qty=@Spec_Qty , Spec_Qty_Unit=@Spec_Qty_Unit , Dosage_Method=@Dosage_Method , Medical_Date=@Medical_Date " & _
            "  , Chronic_Receive_Date=@Chronic_Receive_Date , Dosage=@Dosage , Days=@Days , Left_Days=@Left_Days , Download_Time=@Download_Time " & _
            "  , Chart_No=@Chart_No " & _
            " where  ID_No=@ID_No and Drug_No=@Drug_No            "
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
                    Command.Parameters.AddWithValue("@ID_No", row.Item("ID_No"))
                    Command.Parameters.AddWithValue("@Drug_No", row.Item("Drug_No"))
                    Command.Parameters.AddWithValue("@Source", row.Item("Source"))
                    Command.Parameters.AddWithValue("@Icd_Code", row.Item("Icd_Code"))
                    Command.Parameters.AddWithValue("@Icd_Name", row.Item("Icd_Name"))
                    Command.Parameters.AddWithValue("@ATC5_Code", row.Item("ATC5_Code"))
                    Command.Parameters.AddWithValue("@ATC5_Name", row.Item("ATC5_Name"))
                    Command.Parameters.AddWithValue("@Element_Code", row.Item("Element_Code"))
                    Command.Parameters.AddWithValue("@Element_Name", row.Item("Element_Name"))
                    Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                    Command.Parameters.AddWithValue("@Drug_Name", row.Item("Drug_Name"))
                    Command.Parameters.AddWithValue("@Spec_Qty", row.Item("Spec_Qty"))
                    Command.Parameters.AddWithValue("@Spec_Qty_Unit", row.Item("Spec_Qty_Unit"))
                    Command.Parameters.AddWithValue("@Dosage_Method", row.Item("Dosage_Method"))
                    Command.Parameters.AddWithValue("@Medical_Date", row.Item("Medical_Date"))
                    Command.Parameters.AddWithValue("@Chronic_Receive_Date", row.Item("Chronic_Receive_Date"))
                    Command.Parameters.AddWithValue("@Dosage", row.Item("Dosage"))
                    Command.Parameters.AddWithValue("@Days", row.Item("Days"))
                    Command.Parameters.AddWithValue("@Left_Days", row.Item("Left_Days"))
                    Command.Parameters.AddWithValue("@Download_Time", row.Item("Download_Time"))
                    Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
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
            " Source=@Source , Icd_Code=@Icd_Code , Icd_Name=@Icd_Name " & _
            "  , ATC5_Code=@ATC5_Code , ATC5_Name=@ATC5_Name , Element_Code=@Element_Code , Element_Name=@Element_Name , Insu_Code=@Insu_Code " & _
            "  , Drug_Name=@Drug_Name , Spec_Qty=@Spec_Qty , Spec_Qty_Unit=@Spec_Qty_Unit , Dosage_Method=@Dosage_Method , Medical_Date=@Medical_Date " & _
            "  , Chronic_Receive_Date=@Chronic_Receive_Date , Dosage=@Dosage , Days=@Days , Left_Days=@Left_Days , Download_Time=@Download_Time " & _
            "  , Chart_No=@Chart_No " & _
            " where  ID_No=@ID_No and Drug_No=@Drug_No            "
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
                    Command.Parameters.AddWithValue("@ID_No", row.Item("ID_No"))
                    Command.Parameters.AddWithValue("@Drug_No", row.Item("Drug_No"))
                    Command.Parameters.AddWithValue("@Source", row.Item("Source"))
                    Command.Parameters.AddWithValue("@Icd_Code", row.Item("Icd_Code"))
                    Command.Parameters.AddWithValue("@Icd_Name", row.Item("Icd_Name"))
                    Command.Parameters.AddWithValue("@ATC5_Code", row.Item("ATC5_Code"))
                    Command.Parameters.AddWithValue("@ATC5_Name", row.Item("ATC5_Name"))
                    Command.Parameters.AddWithValue("@Element_Code", row.Item("Element_Code"))
                    Command.Parameters.AddWithValue("@Element_Name", row.Item("Element_Name"))
                    Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                    Command.Parameters.AddWithValue("@Drug_Name", row.Item("Drug_Name"))
                    Command.Parameters.AddWithValue("@Spec_Qty", row.Item("Spec_Qty"))
                    Command.Parameters.AddWithValue("@Spec_Qty_Unit", row.Item("Spec_Qty_Unit"))
                    Command.Parameters.AddWithValue("@Dosage_Method", row.Item("Dosage_Method"))
                    Command.Parameters.AddWithValue("@Medical_Date", row.Item("Medical_Date"))
                    Command.Parameters.AddWithValue("@Chronic_Receive_Date", row.Item("Chronic_Receive_Date"))
                    Command.Parameters.AddWithValue("@Dosage", row.Item("Dosage"))
                    Command.Parameters.AddWithValue("@Days", row.Item("Days"))
                    Command.Parameters.AddWithValue("@Left_Days", row.Item("Left_Days"))
                    Command.Parameters.AddWithValue("@Download_Time", row.Item("Download_Time"))
                    Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
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
            " Source=@Source , Icd_Code=@Icd_Code , Icd_Name=@Icd_Name " & _
            "  , ATC5_Code=@ATC5_Code , ATC5_Name=@ATC5_Name , Element_Code=@Element_Code , Element_Name=@Element_Name , Insu_Code=@Insu_Code " & _
            "  , Drug_Name=@Drug_Name , Spec_Qty=@Spec_Qty , Spec_Qty_Unit=@Spec_Qty_Unit , Dosage_Method=@Dosage_Method , Medical_Date=@Medical_Date " & _
            "  , Chronic_Receive_Date=@Chronic_Receive_Date , Dosage=@Dosage , Days=@Days , Left_Days=@Left_Days , Download_Time=@Download_Time " & _
            "  , Chart_No=@Chart_No " & _
            " where  ID_No=@ID_No and Drug_No=@Drug_No            "
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
                    Command.Parameters.AddWithValue("@ID_No", row.Item("ID_No"))
                    Command.Parameters.AddWithValue("@Drug_No", row.Item("Drug_No"))
                    Command.Parameters.AddWithValue("@Source", row.Item("Source"))
                    Command.Parameters.AddWithValue("@Icd_Code", row.Item("Icd_Code"))
                    Command.Parameters.AddWithValue("@Icd_Name", row.Item("Icd_Name"))
                    Command.Parameters.AddWithValue("@ATC5_Code", row.Item("ATC5_Code"))
                    Command.Parameters.AddWithValue("@ATC5_Name", row.Item("ATC5_Name"))
                    Command.Parameters.AddWithValue("@Element_Code", row.Item("Element_Code"))
                    Command.Parameters.AddWithValue("@Element_Name", row.Item("Element_Name"))
                    Command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                    Command.Parameters.AddWithValue("@Drug_Name", row.Item("Drug_Name"))
                    Command.Parameters.AddWithValue("@Spec_Qty", row.Item("Spec_Qty"))
                    Command.Parameters.AddWithValue("@Spec_Qty_Unit", row.Item("Spec_Qty_Unit"))
                    Command.Parameters.AddWithValue("@Dosage_Method", row.Item("Dosage_Method"))
                    Command.Parameters.AddWithValue("@Medical_Date", row.Item("Medical_Date"))
                    Command.Parameters.AddWithValue("@Chronic_Receive_Date", row.Item("Chronic_Receive_Date"))
                    Command.Parameters.AddWithValue("@Dosage", row.Item("Dosage"))
                    Command.Parameters.AddWithValue("@Days", row.Item("Days"))
                    Command.Parameters.AddWithValue("@Left_Days", row.Item("Left_Days"))
                    Command.Parameters.AddWithValue("@Download_Time", row.Item("Download_Time"))
                    Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
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
    Public Function delete(ByRef pk_ID_No As System.String, ByRef pk_Drug_No As System.Int32, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " ID_No=@ID_No and Drug_No=@Drug_No "
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
                Command.Parameters.AddWithValue("@ID_No", pk_ID_No)
                Command.Parameters.AddWithValue("@Drug_No", pk_Drug_No)
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
    Public Function queryByPK(ByRef pk_ID_No As System.String, ByRef pk_Drug_No As System.Int32, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" ID_No , Drug_No , Source , Icd_Code , Icd_Name ,  ")
            content.AppendLine(" ATC5_Code , ATC5_Name , Element_Code , Element_Name , Insu_Code ,  ")
            content.AppendLine(" Drug_Name , Spec_Qty , Spec_Qty_Unit , Dosage_Method , Medical_Date ,  ")
            content.AppendLine(" Chronic_Receive_Date , Dosage , Days , Left_Days , Download_Time ,  ")
            content.AppendLine(" Chart_No                from " & tableName)
            content.AppendLine("   where ID_No=@ID_No and Drug_No=@Drug_No            ")
            command.CommandText = content.tostring
            Command.Parameters.AddWithValue("@ID_No", pk_ID_No)
            Command.Parameters.AddWithValue("@Drug_No", pk_Drug_No)
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
    Public Function queryByLikePK(ByRef pk_ID_No As System.String, ByRef pk_Drug_No As System.Int32, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" ID_No , Drug_No , Source , Icd_Code , Icd_Name ,  ")
            content.AppendLine(" ATC5_Code , ATC5_Name , Element_Code , Element_Name , Insu_Code ,  ")
            content.AppendLine(" Drug_Name , Spec_Qty , Spec_Qty_Unit , Dosage_Method , Medical_Date ,  ")
            content.AppendLine(" Chronic_Receive_Date , Dosage , Days , Left_Days , Download_Time ,  ")
            content.AppendLine(" Chart_No                from " & tableName)
            content.AppendLine("   where ID_No like @ID_No and Drug_No like @Drug_No ")
            command.CommandText = content.tostring
            Command.Parameters.AddWithValue("@ID_No", pk_ID_No & "%")
            Command.Parameters.AddWithValue("@Drug_No", pk_Drug_No & "%")
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
            content.AppendLine(" ID_No , Drug_No , Source , Icd_Code , Icd_Name ,  ")
            content.AppendLine(" ATC5_Code , ATC5_Name , Element_Code , Element_Name , Insu_Code ,  ")
            content.AppendLine(" Drug_Name , Spec_Qty , Spec_Qty_Unit , Dosage_Method , Medical_Date ,  ")
            content.AppendLine(" Chronic_Receive_Date , Dosage , Days , Left_Days , Download_Time ,  ")
            content.AppendLine(" Chart_No                from " & tableName)
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
            content.Append("select   ID_No , Drug_No , Source , Icd_Code , Icd_Name ,  " & _
             " ATC5_Code , ATC5_Name , Element_Code , Element_Name , Insu_Code ,  " & _
             " Drug_Name , Spec_Qty , Spec_Qty_Unit , Dosage_Method , Medical_Date ,  " & _
             " Chronic_Receive_Date , Dosage , Days , Left_Days , Download_Time ,  " & _
             " Chart_No            from " & tableName & " where 1=1 ")
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
    '''取得表格 ICC_Cloud_Drugs 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function
#End Region

End Class
