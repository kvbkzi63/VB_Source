'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBInsuCodeBO_E2.vb
'*              Title:	醫令項目代碼對應健保碼檔
'*        Description:	醫令項目代碼對應健保碼檔
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Johsn
'*        Create Date:	2010/06/02
'*      Last Modifier:	 
'*   Last Modify Date:	 
'*
'*****************************************************************************
'*/
Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.BO
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP

Public Class PUBInsuCodeBO_E2
    Inherits PubInsuCodeBO

    Private Shared myInstance As PUBInsuCodeBO_E2
    Public Overloads Shared Function GetInstance() As PUBInsuCodeBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBInsuCodeBO_E2()
        End If
        Return myInstance
    End Function

    ''' <summary>
    ''' 查詢
    ''' </summary>
    ''' <param name="strOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPubInsuCode(ByVal strEffectDate As String, ByVal strOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        Dim connFlag As Boolean = conn Is Nothing

        If connFlag Then
            conn = getConnection()
            conn.Open()
        End If
        strSql.Append(" select A.*, B.Code_Name from PUB_Insu_Code A ")
        strSql.Append(" left join pub_syscode B on A.Insu_Account_Id =B.Code_Id and B.Type_Id ='43' ")
        strSql.Append("  WHERE 1=1 ")

        If strEffectDate.Trim <> "" Then
            strSql.Append("  and  A.Effect_Date =  @Effect_Date ")
        End If

        If strOrderCode.Trim <> "" Then
            strSql.Append("  and  A.Order_Code =  @Order_Code ")
        End If

        Try

            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = strSql.ToString
            command.Parameters.AddWithValue("@Effect_Date", strEffectDate)
            command.Parameters.AddWithValue("@Order_Code", strOrderCode)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            ds = New Data.DataSet(tableName)
            adapter.Fill(ds, tableName)

        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
        Return ds

    End Function

    ''' <summary>
    ''' 查詢生效日、停止日
    ''' </summary>
    ''' <param name="strOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPubInsuCode2(ByVal strOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        Dim connFlag As Boolean = conn Is Nothing

        If connFlag Then
            conn = getConnection()
            conn.Open()
        End If
        strSql.Append(" SELECT distinct Effect_Date, Order_Type_Id, Order_Code, End_Date, Dc from PUB_Insu_Code  ")
        strSql.Append("  WHERE  Order_Code =  @Order_Code  ")
        strSql.Append("  ORDER BY   Effect_Date   ")

        Try

            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = strSql.ToString
            command.Parameters.AddWithValue("@Order_Code", strOrderCode)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            ds = New Data.DataSet(tableName)
            adapter.Fill(ds, tableName)

        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
        Return ds

    End Function

    ''' <summary>
    ''' 根據OrderCode查出對應的健保碼
    ''' </summary>
    ''' <param name="strOrderCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryPubInsuCodeByOrderCode(ByVal strOrderCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder
        Dim connFlag As Boolean = conn Is Nothing

        If connFlag Then
            conn = getConnection()
            conn.Open()
        End If
        strSql.Append(" select A.*, B.Code_Name from PUB_Insu_Code A ")
        strSql.Append(" left join pub_syscode B on A.Insu_Account_Id =B.Code_Id and B.Type_Id ='43' ")
        strSql.Append("  WHERE A.Dc='N' And  A.Order_Code =  @Order_Code  ")

        Try

            Dim command As SqlCommand = conn.CreateCommand()
            command.CommandText = strSql.ToString
            command.Parameters.AddWithValue("@Order_Code", strOrderCode)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            ds = New Data.DataSet(tableName)
            adapter.Fill(ds, tableName)

        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
        Return ds

    End Function

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function deletePubInsuCode(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim result As Integer = 0
        Dim connFlag As Boolean = conn Is Nothing

        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            For Each dr As DataRow In ds.Tables(0).Rows
                result += delete(CDate(dr.Item("Effect_Date")), dr.Item("Order_Type_Id").ToString.Trim, dr.Item("Order_Code").ToString.Trim, dr.Item("Insu_Code_Seq").ToString.Trim, conn)
            Next

            Return result
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    '''  取序號
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPubInsuCodeBySeqNo(ByVal strOrderCode As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strSql As New StringBuilder
            strSql.Append(" ").Append(" select case when max(Insu_Code_Seq) is null  then 1 else MAX(Insu_Code_Seq)+1 end   as Insu_Code_Seq from PUB_Insu_Code  ").Append(vbCrLf)
            strSql.Append(" ").Append(" where Order_Code=@Order_Code ")
            command.CommandText = strSql.ToString()
            command.Parameters.AddWithValue("@Order_Code", strOrderCode)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException

            Throw sqlex
        Catch ex As Exception

            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function


    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePUBInsuCodeByEffectDate(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            "   End_Date=@End_Date, Dc=@Dc  " & _
            "   where  Effect_Date=@Effect_Date  and Order_Code=@Order_Code          "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Dim command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.Clear()
                command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag Then
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
    Public Function updatePUBInsuCodeByPK_L(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            "   End_Date=@End_Date, Dc=@Dc  " & _
            "   where  Effect_Date=@Effect_Date  and Order_Type_Id =@Order_Type_Id and Order_Code=@Order_Code and Insu_Code_Seq=@Insu_Code_Seq  "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Dim command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.Clear()
                command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                command.Parameters.AddWithValue("@Insu_Code_Seq", row.Item("Insu_Code_Seq"))
                command.Parameters.AddWithValue("@End_Date", Now.ToString("yyyy/MM/dd"))
                command.Parameters.AddWithValue("@Dc", "Y")
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag Then
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
    Public Function deletePUBInsuCode(ByRef pk_Effect_Date As System.DateTime, ByRef pk_Order_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Effect_Date=@Effect_Date  and Order_Code=@Order_Code  "
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
                command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
                command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
                count = command.ExecuteNonQuery
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag Then
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
    Public Function insertPUBInsuCode(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Effect_Date , Order_Type_Id , Order_Code , Insu_Code_Seq , Is_Multi_Map_Flag ,  " & _
             " Insu_Code , Insu_Name , Price , Tqty , Insu_Account_Id ,  " & _
             " Is_Emg_Add , Is_Kid_Add , Is_Dental_Add , Is_Holiday_Add , Dc ,  " & _
             " End_Date , Create_User , Create_Time , Modified_User , Modified_Time,Is_Dept_Add " & _
             "  ) " & _
             " values( @Effect_Date , @Order_Type_Id , @Order_Code , @Insu_Code_Seq , @Is_Multi_Map_Flag ,  " & _
             " @Insu_Code , @Insu_Name , @Price , @Tqty , @Insu_Account_Id ,  " & _
             " @Is_Emg_Add , @Is_Kid_Add , @Is_Dental_Add , @Is_Holiday_Add , @Dc ,  " & _
             " @End_Date , @Create_User , @Create_Time , @Modified_User , @Modified_Time, @Is_Dept_Add " & _
             "              )"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(0).Rows
                Dim command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                command.Parameters.AddWithValue("@Insu_Code_Seq", row.Item("Insu_Code_Seq"))
                command.Parameters.AddWithValue("@Is_Multi_Map_Flag", row.Item("Is_Multi_Map_Flag"))
                command.Parameters.AddWithValue("@Insu_Code", row.Item("Insu_Code"))
                command.Parameters.AddWithValue("@Insu_Name", row.Item("Insu_Name"))
                command.Parameters.AddWithValue("@Price", row.Item("Price"))
                command.Parameters.AddWithValue("@Tqty", row.Item("Tqty"))
                command.Parameters.AddWithValue("@Insu_Account_Id", row.Item("Insu_Account_Id"))
                command.Parameters.AddWithValue("@Is_Emg_Add", row.Item("Is_Emg_Add"))
                command.Parameters.AddWithValue("@Is_Kid_Add", row.Item("Is_Kid_Add"))
                command.Parameters.AddWithValue("@Is_Dental_Add", row.Item("Is_Dental_Add"))
                command.Parameters.AddWithValue("@Is_Holiday_Add", row.Item("Is_Holiday_Add"))
                command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                command.Parameters.AddWithValue("@Create_Time", currentTime)
                command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                command.Parameters.AddWithValue("@Modified_Time", currentTime)
                command.Parameters.AddWithValue("@Is_Dept_Add", row.Item("Is_Dept_Add"))
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt

            Next
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

End Class
