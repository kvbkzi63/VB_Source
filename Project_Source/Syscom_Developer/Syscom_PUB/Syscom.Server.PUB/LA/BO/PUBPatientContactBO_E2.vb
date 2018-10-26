'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBPatientContactBO_E2.vb
'*              Title:	病患關系檔維護
'*        Description:	病患關系檔維護
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Dashan
'*        Create Date:	2009/10/15
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions
Imports Syscom.Comm.TableFactory
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.SQL
Imports System.Reflection

Public Class PUBPatientContactBO_E2
    Inherits PubPatientContactBO
        Private Shared myInstance As PUBPatientContactBO_E2

    Public Overloads Shared Function getInstance() As PUBPatientContactBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPatientContactBO_E2()
        End If
        Return myInstance
    End Function

    ''' <summary>
    ''' 查詢病患關系檔
    ''' </summary>
    ''' <param name=" strChartNo">病歷號</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>查詢條件完全匹配</remarks>
    Public Function queryPUBPatientContactByChartNo(ByVal strChartNo As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder
        strSql.Append(" ").Append("select * from PUB_Patient_Contact  where ")
        strSql.Append(" ").Append(" Chart_No = '" & strChartNo & "' ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function



    ''' <summary>
    ''' 查詢病患關系檔
    ''' </summary>
    ''' <param name=" strChartNo">病歷號</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>查詢條件完全匹配</remarks>
    Public Function queryPUBPatientContactByCond(ByVal strChartNo As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("select A.* from PUB_Patient_Contact as A where ")
        strSql.Append(" ").Append(" A.Patient_Contact_No = ")
        strSql.Append(" ").Append("(select MIN(Patient_Contact_No)  ")
        strSql.Append(" ").Append("from PUB_Patient_Contact  ")
        strSql.Append(" ").Append("where Chart_No = '" & strChartNo & "' )")
        strSql.Append(" ").Append("and A.Chart_No = '" & strChartNo & "' ")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function


    ''' <summary>
    ''' 查詢聯系人信息以及重大傷病卡號
    ''' </summary>
    ''' <param name=" strChartNo">病歷號</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>查詢條件完全匹配</remarks>
    Public Function queryPUBPatientContactByCond(ByVal strChartNo As String, ByVal strIdNo As String) As System.Data.DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder


        '重大傷病卡號查询
        strSql.Append(" ").Append("select End_Date,A.Certificate_Sn from  ")
        strSql.Append(" ").Append("PUB_Patient_Severe_Disease A left join  ")
        strSql.Append(" ").Append("pub_Patient B on B.Chart_No=A.Chart_No  ")
        strSql.Append(" ").Append("where A.End_Date  = (select MAX(End_Date) from PUB_Patient_Severe_Disease) ")
        strSql.Append(" ").Append("and A.Effect_Date>=convert(char(10),getDate(),111) ")
        If strChartNo <> "" Then
            strSql.Append(" ").Append("and B.Chart_No='" & strChartNo & "'")
        Else
            If strIdNo <> "" Then
                strSql.Append(" ").Append("and B.Idno='" & strIdNo & "'")
            End If
        End If
        '紧急联络人查询
        strSql.Append(" ").Append("select A.Contact_Name,A.Contact_Address,A.Contact_Tel_Home from  ")
        strSql.Append(" ").Append("PUB_Patient_Contact  A ")
        strSql.Append(" ").Append("left join pub_Patient B on B.Chart_No=A.Chart_No  ")
        strSql.Append(" ").Append("where A.Patient_Contact_No  = (select MIN(Patient_Contact_No) from PUB_Patient_Contact) ")
        If strChartNo <> "" Then
            strSql.Append(" ").Append("and B.Chart_No='" & strChartNo & "'")
        Else
            If strIdNo <> "" Then
                strSql.Append(" ").Append("and B.Idno='" & strIdNo & "'")
            End If
        End If
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function


#Region "20100220 HDSPatientManagementBO_E2 病人透析紀錄管理, add by Merry"

    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Function updatePUBPatientContactByPK(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Contact_Name=@Contact_Name , Relation_Type_Id=@Relation_Type_Id , " & _
            " Contact_Tel_Mobile=@Contact_Tel_Mobile ,  " & _
            " Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            " where  Chart_No=@Chart_No and Patient_Contact_No=@Patient_Contact_No"
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            For Each row As DataRow In ds.Tables(tableName).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                    command.Parameters.AddWithValue("@Patient_Contact_No", row.Item("Patient_Contact_No"))
                    command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                    command.Parameters.AddWithValue("@Relation_Type_Id", row.Item("Relation_Type_Id"))
                    command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", currentTime)
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
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
    ''' 選出最大Patient_Contact_No,用於新增時Patient_Contact_No遞增
    ''' </summary>
    ''' <param name="strChartNo">病歷號</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBPatientContactForMaxNo(ByVal strChartNo As String) As System.Data.DataSet
        Dim dsDB As New Data.DataSet
        Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
        Dim command As SqlCommand = sqlConn.CreateCommand()
        Dim content As StringBuilder = New StringBuilder()

        Try
            content.Append(" ").Append("Select ISNULL(MAX (A.Patient_Contact_No), 0) as MaxPatient_Contact_No ")
            content.Append(" ").Append("from PUB_Patient_Contact A ")

            content.Append(" ").Append("where  A.Chart_No = @Chart_No ")

            command.CommandText = content.ToString

            command.Parameters.AddWithValue("@Chart_No", strChartNo)

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                dsDB = New DataSet(tableName)
                adapter.Fill(dsDB, tableName)
                adapter.FillSchema(dsDB, Data.SchemaType.Mapped, tableName)
            End Using
            Return dsDB
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region
End Class
