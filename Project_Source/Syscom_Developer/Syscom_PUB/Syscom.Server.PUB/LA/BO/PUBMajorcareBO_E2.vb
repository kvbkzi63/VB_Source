'/*
'*****************************************************************************
'*
'*    Page/Class Name:  特定治療項目基本檔維護
'*              Title:	PUBMajorcareBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-04
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-04
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



Public Class PUBMajorcareBO_E2
    Inherits PubMajorcareBO

#Region "     使用的Instance宣告 "
    Public Shared ReadOnly tableNamePUB_SYSCode As String = "PUB_SYSCode"

    Private Shared myInstance As PUBMajorcareBO_E2
    Public Overloads Shared Function GetInstance() As PUBMajorcareBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBMajorcareBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     新增 Method "
    ''' <summary>
    '''新增
    ''' </summary>
    ''' <param name="ds">新增資料</param>
    ''' <returns>新增筆數</returns>
    ''' <remarks></remarks>
    Public Overloads Function insert(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "insert into " & tableName & "(" & _
            " Majorcare_Code , Majorcare_Name , Majorcare_Type_Id , Case_Type_Id , Is_Dr_Use ,  " & _
             " Add_Ratio , Examine_Order_Code , Create_User , Create_Time   " & _
             "  ) " & _
             " values( @Majorcare_Code , @Majorcare_Name , @Majorcare_Type_Id , @Case_Type_Id , @Is_Dr_Use ,  " & _
             " @Add_Ratio , @Examine_Order_Code , @Create_User , @Create_Time   " & _
             "  )"
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
                    command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                    command.Parameters.AddWithValue("@Majorcare_Name", row.Item("Majorcare_Name"))
                    command.Parameters.AddWithValue("@Majorcare_Type_Id", row.Item("Majorcare_Type_Id"))
                    command.Parameters.AddWithValue("@Case_Type_Id", row.Item("Case_Type_Id"))
                    command.Parameters.AddWithValue("@Is_Dr_Use", row.Item("Is_Dr_Use"))
                    command.Parameters.AddWithValue("@Add_Ratio", row.Item("Add_Ratio"))
                    command.Parameters.AddWithValue("@Examine_Order_Code", row.Item("Examine_Order_Code"))
                    command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                    command.Parameters.AddWithValue("@Create_Time", currentTime)

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

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "
    ''' <summary>
    ''' 查詢特定治療項目基本檔資料
    ''' </summary>
    ''' <param name="strMajorcareCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    ''' modify by remote 2016/05/26
    Function queryPUBMajorcareByCond(ByVal strMajorcareCode As String) As DataSet
        Dim ds As Data.DataSet
        'Dim strSql As New StringBuilder

        'strSql.Append("Select M.Majorcare_Code , M.Majorcare_Name , M.Majorcare_Type_Id, ")
        'strSql.Append(" S.Code_Name,M.Create_User, dbo.Adtoroctime(M.Create_Time)   AS Create_Time_ROC,M.Modified_User,dbo.Adtoroctime(M.Modified_Time)   AS Modified_Time_ROC From ")
        'strSql.Append(tableName)
        'strSql.Append(" M left join  ").Append(tableNamePUB_SYSCode).Append(" S on (M.Majorcare_Type_Id=S.Code_Id AND S.Type_Id=502) ")
        'strSql.Append(" Where 1=1 ")
        'If strMajorcareCode.Trim <> "" Then
        '    strSql.Append(" AND M.Majorcare_Code = '").Append(strMajorcareCode).Append("' ")
        'End If
        'strSql.Append(" Order By M.Majorcare_Code")

     Dim  content As new System.Text.StringBuilder
        content.Append("SELECT Majorcare_Code " & vbCrLf)
        content.Append("      ,Majorcare_Name " & vbCrLf)
        content.Append("      ,Majorcare_Type_Id " & vbCrLf)
        content.Append("      ,Case_Type_Id " & vbCrLf)
        content.Append("      ,Is_Dr_Use " & vbCrLf)
        content.Append("      ,Add_Ratio " & vbCrLf)
        content.Append("      ,Examine_Order_Code " & vbCrLf)
        content.Append("      ,Order_Code_List " & vbCrLf)
        content.Append("      ,Create_User " & vbCrLf)
        content.Append("      ,Create_Time " & vbCrLf)
        content.Append("      ,Modified_User " & vbCrLf)
        content.Append("      ,Modified_Time " & vbCrLf)

        content.Append("  FROM PUB_Majorcare")
        If strMajorcareCode.Trim <> "" Then
            content.Append(" where Majorcare_Code = '").Append(strMajorcareCode).Append("' ")
        End If
     

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(content.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)

                End Using
        Catch ex As Exception

            Throw ex
            End Try
        Return ds
    End Function
    ''' <summary>
    ''' 查詢特定治療項目基本檔資料 Add By Tor
    ''' </summary>
    ''' <param name="strMajorcareCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBMajorNoEquByCond(ByVal strMajorcareCode As String) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder

        strSql.Append("Select M.Majorcare_Code , M.Majorcare_Name , M.Majorcare_Type_Id From ")
        strSql.Append(tableName)
        strSql.Append(" M  ")
        strSql.Append(" Where 1=1 ")
        If strMajorcareCode.Trim <> "" Then
            strSql.Append(" AND M.Majorcare_Code <> '").Append(strMajorcareCode).Append("' ")
        End If
        strSql.Append(" Order By M.Majorcare_Code")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function
#End Region

End Class

