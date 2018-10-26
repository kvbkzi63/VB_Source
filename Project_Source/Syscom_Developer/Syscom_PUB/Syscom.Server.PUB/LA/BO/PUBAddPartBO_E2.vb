'/*
'*****************************************************************************
'*
'*    Page/Class Name:  加收部分負擔基本檔
'*              Title:	PUBAddPartBO_E2
'*        Description:	加收部分負擔基本檔
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will.Lin
'*        Create Date:	2015-08-31
'*      Last Modifier:	Will.Lin
'*   Last Modify Date:	2015-08-31
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports System.Text



Public Class PUBAddPartBO_E2
    Inherits PubAddPartBO
    Public Shared ReadOnly tableNamePUB_SYSCode As String = "PUB_SYSCode"
    Public Shared ReadOnly tableNamePUB_Order As String = "PUB_Order"
#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBAddPartBO_E2
    Public Overloads Shared Function GetInstance() As PUBAddPartBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBAddPartBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "     新增 Method "
    ''' <summary>
    ''' 查詢加收部分負擔基本檔資料
    ''' </summary>
    ''' <param name="dateEffectDate"></param>
    ''' <param name="strPartTypeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function queryPUBAddPartByCond(ByVal dateEffectDate As Date, ByVal strPartTypeId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" Select A.Effect_Date, A.Part_Type_Id, A.Add_Part_No, A.Start_Value, A.End_Value, A.Order_Code, A.Add_Part_Amt,A.Dc, A.End_Date, A.Create_User, A.Create_Time, A.Modified_User, A.Modified_Time, S.Code_Name, O.Order_Name ")
        strSql.Append(" From ")
        strSql.Append(tableName)
        strSql.Append(" A left join  ").Append(tableNamePUB_SYSCode).Append(" S on (A.Part_Type_Id=S.Code_Id AND S.Type_Id=509) ")
        strSql.Append(" left join  ").Append(tableNamePUB_Order).Append(" O on (A.Order_Code=O.Order_Code AND O.Dc='N') ")
        strSql.Append(" Where 1=1 ")
        If Not dateEffectDate.Equals(Date.MinValue) Then
            strSql.Append(" AND CONVERT(char(10),A.Effect_Date,111) ='").Append(dateEffectDate.ToString("yyyy/MM/dd")).Append("' ")
        End If
        If strPartTypeId.Trim <> "" Then
            strSql.Append(" AND A.Part_Type_Id = '").Append(strPartTypeId.Trim).Append("' ")
        End If
        strSql.Append(" Order By A.Part_Type_Id, A.Effect_Date, A.Add_Part_No")
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim sqlConnection As SqlConnection = conn
            'Using sqlConnection As SqlConnection = conn
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
            ds = New Data.DataSet(tableName)
            adapter.Fill(ds, tableName)
            adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            'End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
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
    ''' 新增加收部分負擔基本檔資料
    ''' </summary>
    ''' <param name="dsSaveData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function insertPUBAddPart(ByVal dsSaveData As DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim count As Integer = 0
        Dim strSql As New StringBuilder

        strSql.Append(" Insert Into ")
        strSql.Append(tableName & " ( ")
        strSql.Append(" Effect_Date, Part_Type_Id, Add_Part_No, Order_Code, Start_Value, End_Value, Add_Part_Amt, Dc, End_Date, Create_User, Create_Time, Modified_User, Modified_Time")
        strSql.Append(" ) ")
        strSql.Append(" Values ( ")
        strSql.Append(" @Effect_Date, @Part_Type_Id, Case When (Select COUNT(*) From PUB_Add_Part ) = 0 Then 1 else (Select MAX(Add_Part_No) From PUB_Add_Part)+1 end, @Order_Code,")
        strSql.Append(" @Start_Value, @End_Value, @Add_Part_Amt, @Dc, @End_Date, ")
        strSql.Append(" @Create_User, @Create_Time, @Modified_User, @Modified_Time ) ")
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim conn2 As System.Data.IDbConnection = conn
            Dim command As SqlCommand = New SqlCommand
            command.CommandType = CommandType.Text
            command.Connection = CType(conn2, SqlConnection)
            For Each row As DataRow In dsSaveData.Tables(tableName).Rows
                command.CommandText = strSql.ToString
                command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                command.Parameters.AddWithValue("@Part_Type_Id", row.Item("Part_Type_Id"))
                command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                command.Parameters.AddWithValue("@Start_Value", row.Item("Start_Value"))
                command.Parameters.AddWithValue("@End_Value", row.Item("End_Value"))
                command.Parameters.AddWithValue("@Add_Part_Amt", row.Item("Add_Part_Amt"))
                command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                command.Parameters.AddWithValue("@Create_Time", Now)
                command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                command.Parameters.AddWithValue("@Modified_Time", Now)
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
#End Region

#Region "     修改 Method "

#End Region

#Region "     刪除 Method "

#End Region

#Region "     查詢 Method "

#End Region

End Class

