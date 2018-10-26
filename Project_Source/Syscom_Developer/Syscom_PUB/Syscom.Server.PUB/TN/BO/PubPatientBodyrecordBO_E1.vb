'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PubPatientBodyrecordBO_E1
'*              Title:	身高體重登記作業
'*        Description:	身高體重登記作業
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Sharon
'*        Create Date:	2015/05/26
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.BO
Imports Syscom.Server.SQL
Imports System.Reflection
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports System.Transactions

Public Class PubPatientBodyrecordBO_E1
    Inherits PubPatientBodyrecordBO

    Private Shared myInstance As PubPatientBodyrecordBO_E1
    Public Shared Shadows Function getInstance() As PubPatientBodyrecordBO_E1
        If myInstance Is Nothing Then
            myInstance = New PubPatientBodyrecordBO_E1
        End If
        Return myInstance
    End Function
#Region "20150526 PubPatientBodyrecordBO 身高體重登記作業, add by Syscom Sharon"
    ''' <summary>
    ''' 新增
    ''' </summary>
    ''' <param name="dsBodyRecord"></param>
    ''' <returns>成功/失敗</returns>
    ''' <remarks></remarks>
    Public Function insertPubPatientBodyrecordBO(ByVal dsBodyRecord As DataSet) As Integer
        Dim blnDoOk As Integer = 0
        Dim BO As New PubPatientBodyrecordBO
        Dim icount As Integer
        Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope '(IsolationLevel.ReadUncommitted)
            Try
                Using hisConn As SqlConnection = BO.getConnection
                    hisConn.Open()
                    icount = BO.insert(dsBodyRecord, hisConn)
                    '同時交易成功，提交保護
                    If icount > 0 Then
                        ts.Complete()
                        blnDoOk = 1
                    Else
                        ts.Dispose()
                        blnDoOk = -1
                    End If
                    hisConn.Close()
                End Using
            Catch commEx As CommonException
                ts.Dispose()
                Throw commEx
            Catch ex As Exception
                ts.Dispose()
                blnDoOk = 0
                Throw ex
            End Try
        End Using
        Return blnDoOk
    End Function


    ''' <summary>
    ''' 修改
    ''' </summary>
    ''' <param name="dsBodyRecord">身高體重</param>
    ''' <returns>成功/失敗</returns>
    ''' <remarks></remarks>
    Public Function updatePubPatientBodyrecordBO(ByVal dsBodyRecord As DataSet) As Integer
        Dim blnDoOk As Integer = 0
        Dim BO As New PubPatientBodyrecordBO
        Dim icount As Integer

        Using ts As TransactionScope = SQLConnFactory.getInstance.getRequiredTransactionScope '(IsolationLevel.ReadUncommitted)
            Try
                Using hisConn As SqlConnection = BO.getConnection
                    hisConn.Open()
                    icount = BO.update(dsBodyRecord, hisConn)
                    '同時交易成功，提交保護
                    If icount > 0 Then
                        ts.Complete()
                        blnDoOk = 1
                    Else
                        ts.Dispose()
                        blnDoOk = -1
                    End If
                    hisConn.Close()
                End Using
            Catch commEx As CommonException
                ts.Dispose()
                Throw commEx
            Catch ex As Exception
                ts.Dispose()
                blnDoOk = 0
                Throw ex
            End Try
        End Using
        Return blnDoOk
    End Function

    ''' <summary>
    '''刪除
    ''' </summary>
    ''' <remarks></remarks>
    Public Function deletePubPatientBodyrecordBO(ByVal dsBodyRecord As DataSet) As Integer
        Try
            Dim BO As New PubPatientBodyrecordBO
            Dim icount As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Source_Type_Id=@Source_Type_Id and Keyin_Unit=@Keyin_Unit "
            Using conn As System.Data.IDbConnection = BO.getConnection
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Source_Type_Id", gblSourceTypeId)
                    command.Parameters.AddWithValue("@Keyin_Unit", gblKeyinUnit)
                    conn.Open()
                    icount = command.ExecuteNonQuery
                End Using
            End Using
            Return icount
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        End Try
    End Function

    ''' <summary>
    ''' 根據條件查詢對應的資料
    ''' </summary>
    ''' <param name="gblSourceTypeId">來源別</param>
    ''' <param name="gblKeyinUnit">登錄單位</param>
    ''' <param name="ChartNo">病歷號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPubPatientBodyrecordBO(ByVal gblSourceTypeId As String, ByVal gblKeyinUnit As String, _
                                                     ByVal ChartNo As String) As System.Data.DataSet
        Dim BO As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("select *")
        strSql.Append(" ").Append("from PUB_Patient_BodyRecord A")
        strSql.Append(" ").Append("Where 1=1 ")

        If ChartNo.Trim <> "" Then
            strSql.Append(" AND A.Chart_No=@Chart_No ")
        End If
        If gblSourceTypeId.Trim <> "" Then
            strSql.Append(" AND A.Source_Type_Id=@Source_Type_Id ")
        End If
        If gblKeyinUnit.Trim <> "" Then
            strSql.Append(" AND A.Keyin_Unit=@Keyin_Unit ")
        End If

        Dim ds As Data.DataSet
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim command As SqlCommand = sqlConnection.CreateCommand()
                command.CommandText = strSql.ToString
                command.Parameters.AddWithValue("@Chart_No", ChartNo)
                command.Parameters.AddWithValue("@Source_Type_Id", gblSourceTypeId)
                command.Parameters.AddWithValue("@Keyin_Unit", gblKeyinUnit)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:" & ex.Message, Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbErrorMsg(FunctName & ex.Message, ex)
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' 根據條件查詢對應的資料
    ''' </summary>
    ''' <param name="gblSourceTypeId">來源別</param>
    ''' <param name="gblKeyinUnit">登錄單位</param>
    ''' <param name="ChartNo">病歷號</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPubPatientBodyrecordByCond(ByVal gblSourceTypeId As String, ByVal gblKeyinUnit As String, ByVal ChartNo As String) As System.Data.DataSet
        Dim BO As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("select  Chart_No,dbo.adtoRoctime(Measure_Time) as Measure_Time,Height,Weight,Pulse,Breath,Temperature,Blood_Diastolic,Blood_Pressure,Create_User,Create_Time ,Source_Type_Id,Keyin_Unit")
        strSql.Append(" ").Append("from PUB_Patient_BodyRecord A  ")
        strSql.Append(" ").Append("Where 1=1 ")

        If ChartNo.Trim <> "" Then
            strSql.Append(" AND A.Chart_No=@Chart_No ")
        End If
        If gblSourceTypeId.Trim <> "" Then
            strSql.Append(" AND A.Source_Type_Id=@Source_Type_Id ")
        End If
        If gblKeyinUnit.Trim <> "" Then
            strSql.Append(" AND A.Keyin_Unit=@Keyin_Unit ")
        End If
        strSql.Append(" order by  Measure_Time desc ")

        Dim ds As Data.DataSet
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim command As SqlCommand = sqlConnection.CreateCommand()
                command.CommandText = strSql.ToString
                command.Parameters.AddWithValue("@Chart_No", ChartNo)
                command.Parameters.AddWithValue("@Source_Type_Id", gblSourceTypeId)
                command.Parameters.AddWithValue("@Keyin_Unit", gblKeyinUnit)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:" & ex.Message, Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbErrorMsg(FunctName & ex.Message, ex)
            Throw ex
        End Try
        Return ds
    End Function

#End Region

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Function queryByPK(ByRef pk_Chart_No As System.String, ByRef pk_Measure_Time As System.DateTime, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Chart_No , dbo.adtoRoctime(Measure_Time) as Measure_Time, Height , Weight , Pulse ,  ")
            content.AppendLine(" Breath , Temperature , Blood_Pressure , Blood_Diastolic , Create_User ,  ")
            content.AppendLine(" Create_Time , Source_Type_Id,Keyin_Unit from " & tableName)
            content.AppendLine("   where Chart_No=@Chart_No and Measure_Time=@Measure_Time            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)
            command.Parameters.AddWithValue("@Measure_Time", CDate(pk_Measure_Time))
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
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    Private Function gblKeyinUnit() As Object
        Throw New NotImplementedException
    End Function

    Private Function gblSourceTypeId() As Object
        Throw New NotImplementedException
    End Function

#Region "     通過Chart_No查詢PUB_Patient_BodyRecord中[Measure_Time]最近的一筆紀錄 (For KLH 用) "
    ''' <summary>
    ''' 通過Chart_No查詢PUB_Patient_BodyRecord中[Measure_Time]最近的一筆紀錄
    ''' </summary>
    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    Public Function queryByChartNo(ByRef pk_Chart_No As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine("select top 1  ")
            content.AppendLine(" Chart_No , Measure_Time , Height , Weight , Pulse ,  ")
            content.AppendLine(" Breath , Temperature , Blood_Pressure , Blood_Diastolic , Create_User ,  ")
            content.AppendLine(" Create_Time , Source_Type_Id , Keyin_Unit                from " & tableName)
            content.AppendLine("   where Chart_No=@Chart_No             ")
            content.AppendLine("   order by Measure_Time desc            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)
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



#Region "20160623 For tpe 入院護理評估的身高體重儲存"
    ''' <summary>
    ''' 根據
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpdateHBbyChartNoForMohw(ByVal ds As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Dim PubPatientBodyrecordColStr() As String = Syscom.Comm.TableFactory.PubPatientBodyrecordDataTableFactory.columnsName
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim Count As Integer = 0
            Dim currentTime = Now

            For Each dr As DataRow In ds.Tables(tableName).Rows
                Dim sqlString As String = "update " & tableName & " set "
                For Each RowColName As String In PubPatientBodyrecordColStr
                    If Not New String() {"Chart_No", "Measure_Time"}.Contains(RowColName) AndAlso Not dr(RowColName).ToString.Trim.Equals("") Then
                        sqlString &= RowColName & "= @" & RowColName

                        If RowColName <> PubPatientBodyrecordColStr.Last Then
                            sqlString &= ","
                        End If
                    End If
                Next
                sqlString &= " where  Chart_No=@Chart_No  and Measure_Time=@Measure_Time     "

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Chart_No", dr.Item("Chart_No"))
                    command.Parameters.AddWithValue("@Measure_Time", dr.Item("Measure_Time"))
                    command.Parameters.AddWithValue("@Height", dr.Item("Height"))
                    command.Parameters.AddWithValue("@Weight", dr.Item("Weight"))
                    command.Parameters.AddWithValue("@Pulse", dr.Item("Pulse"))
                    command.Parameters.AddWithValue("@Breath", dr.Item("Breath"))
                    command.Parameters.AddWithValue("@Temperature", dr.Item("Temperature"))
                    command.Parameters.AddWithValue("@Blood_Pressure", dr.Item("Blood_Pressure"))
                    command.Parameters.AddWithValue("@Blood_Diastolic", dr.Item("Blood_Diastolic"))
                    command.Parameters.AddWithValue("@Create_User", dr.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime)
                    command.Parameters.AddWithValue("@Source_Type_Id", dr.Item("Source_Type_Id"))
                    command.Parameters.AddWithValue("@Keyin_Unit", dr.Item("Keyin_Unit"))



                    Count = command.ExecuteNonQuery

                    If Count <= 0 AndAlso (Not (IsDBNull(dr.Item("Height")) Or IsDBNull(dr.Item("Weight")))) Then
                        Dim dsInsert As DataSet = New DataSet
                        dsInsert.Tables.Add(ds.Tables(tableName).Copy)

                        Count = insert(dsInsert, conn)
                    End If


                End Using

            Next

            Return Count
        Catch sqlex As SqlException
            Throw New SQLDatabaseException(sqlex)
        Catch cmex As CommonException
            Throw cmex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
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
