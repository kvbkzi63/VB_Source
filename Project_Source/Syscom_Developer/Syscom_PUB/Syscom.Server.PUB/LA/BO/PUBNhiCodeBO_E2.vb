'/*
'*****************************************************************************
'*
'*    Page/Class Name:  健保支付標準檔
'*              Title:	PUBNhiCodeBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Will,Lin
'*        Create Date:	2015-09-15
'*      Last Modifier:	Will,Lin
'*   Last Modify Date:	2015-09-15
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions

Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports System.Text



Public Class PUBNhiCodeBO_E2
    Inherits PubNhiCodeBO

#Region "     使用的Instance宣告 "

    Private Shared myInstance As PUBNhiCodeBO_E2
    Public Overloads Shared Function GetInstance() As PUBNhiCodeBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBNhiCodeBO_E2
        End If
        Return myInstance
    End Function

#End Region

#Region "     變數宣告 "


#End Region

#Region "2010/06/02 add Johsn"
    ''' <summary>
    ''' 查詢健保支付標準檔,(檢驗檢查) Dc = 'N'  
    ''' </summary>
    ''' <param name="strInsuCode">健保碼</param>
    ''' <returns>DataSet</returns>
    Public Function queryPubNhiCode(ByVal strInsuCode As String) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder

        strSql.Append("SELECT A.*,B.Code_Name  from PUB_Nhi_Code A  ")
        strSql.Append(" left join pub_syscode B on A.Insu_Account_Id =B.Code_Id and B.Type_Id ='43' ")
        strSql.Append("  WHERE  A.Dc = 'N'   ")
        strSql.Append("  AND A.Insu_Code =  @Insu_Code ")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim command As SqlCommand = sqlConnection.CreateCommand()
                command.CommandText = strSql.ToString
                command.Parameters.AddWithValue("@Insu_Code", strInsuCode)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.getInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds

    End Function
#End Region
#Region "2010/06/03 add Tor"
    ''' <summary>
    ''' 查詢健保支付標準檔,(檢驗檢查)  
    ''' </summary>
    ''' <param name="strEffectDate">起始日</param>
    ''' <param name="strInsuCode">健保碼</param>
    ''' <returns>DataSet</returns>
    Public Function queryPUBNhiCodeByCond(ByVal strEffectDate As Date, ByVal strInsuCode As String) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder

        'strSql.Append("SELECT top 10 A.*   from PUB_Nhi_Code A  ")
        strSql.Append("SELECT A.*   from PUB_Nhi_Code A  ") '用此方法時 會出現資料太多的問題
        strSql.Append("  WHERE  1=1   ")
        If Not strEffectDate = System.DateTime.MinValue Then
            strSql.Append("  AND A.Effect_Date =  @Effect_Date ")
        End If
        If strInsuCode.Trim.Length > 0 Then
            strSql.Append("  AND A.Insu_Code =  @Insu_Code ")
        End If

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim command As SqlCommand = sqlConnection.CreateCommand()
                command.CommandText = strSql.ToString

                If Not strEffectDate = System.DateTime.MinValue Then
                    command.Parameters.AddWithValue("@Effect_Date", strEffectDate)
                End If
                If strInsuCode.Trim.Length > 0 Then
                    command.Parameters.AddWithValue("@Insu_Code", strInsuCode)
                End If
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.getInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function
    ''' <summary>
    ''' 根據生效日和部份負擔代碼取得所有資料
    ''' </summary>
    ''' <param name="strEffectDate"></param>
    ''' <param name="strPartCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function queryPUBNhiCodeDateByCond(ByVal strEffectDate As Date, ByVal strPartCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet 'Implements IPUBPartBO.queryPUBPartByCond
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
            End If
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            content.Append("select * from " & tableName & " where 1=1 ")
            If Not strEffectDate.Equals(System.DateTime.MinValue) Then
                content.Append("and ").Append("Effect_Date =@Effect_Date ")
            End If
            If Not strPartCode.Equals("") Then
                content.Append("and ").Append("Insu_Code =@Insu_Code ")
            End If
            content.Append("order by Insu_Code,Effect_Date")
            command.CommandText = content.ToString
            If Not strEffectDate.Equals(System.DateTime.MinValue) Then
                command.Parameters.AddWithValue("@Effect_Date", strEffectDate)
            End If
            If Not strPartCode.Equals("") Then
                command.Parameters.AddWithValue("@Insu_Code", strPartCode)
            End If
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
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
    End Function
#End Region

#Region "2010/06/08 職病健檢必要檢查項目設定的查詢健保支付點數  add Mark"
    ''' <summary>
    ''' 查詢健保支付點數  
    ''' </summary>
    ''' <param name="strInsuCode">健保碼</param>
    ''' <returns>DataSet</returns>
    Public Function queryPubNhiCodeForPrice(ByVal strInsuCode As String) As DataSet
        Dim ds As Data.DataSet
        Dim strSql As New StringBuilder

        strSql.Append("SELECT Price from PUB_Nhi_Code ")
        strSql.Append("  WHERE  Dc = 'N' and GETDATE() Between Effect_Date And End_Date  ")
        If Not strInsuCode.Trim.Equals("") Then
            strSql.Append("  AND Insu_Code =  @Insu_Code ")
        End If

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim command As SqlCommand = sqlConnection.CreateCommand()
                command.CommandText = strSql.ToString
                If Not strInsuCode.Trim.Equals("") Then
                    command.Parameters.AddWithValue("@Insu_Code", strInsuCode)
                End If
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.getInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds

    End Function
#End Region
#Region "20100929 健保支付標準檔  查詢上一筆下一筆和刪除事件 add by liuye"
    ''' <summary>
    ''' 查詢上一筆下一筆
    ''' </summary>
    ''' <param name="strEffectDate">生效日</param>
    ''' <param name="strInsuCode">健保碼</param>
    ''' <param name="itype">1：上一筆；2：下一筆</param>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBNhiCodeUpDown(ByVal strEffectDate As Date, ByVal strInsuCode As String, ByVal itype As Integer) As DataSet
        Dim ds As DataSet
        Try
            Dim strSql As New StringBuilder
            strSql.Append("select top 1 * from PUB_Nhi_Code").Append(vbCrLf)
            If itype = "1" Then
                strSql.Append("where (rtrim(LTRIM(Insu_Code))+convert(char(8),Effect_Date,112)) <'" & strInsuCode & CDate(strEffectDate).ToString("yyyyMMdd") & "' ").Append(vbCrLf)
                strSql.Append("order by Insu_Code desc ,Effect_Date desc ").Append(vbCrLf)
            ElseIf itype = "2" Then
                strSql.Append("where (rtrim(LTRIM(Insu_Code))+convert(char(8),Effect_Date,112)) >'" & strInsuCode & CDate(strEffectDate).ToString("yyyyMMdd") & "' ").Append(vbCrLf)
                strSql.Append("order by Insu_Code  ,Effect_Date  ").Append(vbCrLf)
            End If

            Using SqlConn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim commond As SqlCommand = SqlConn.CreateCommand
                commond.CommandText = strSql.ToString
                commond.Parameters.AddWithValue("@Effect_Date", strEffectDate)
                commond.Parameters.AddWithValue("@Insu_Code", strInsuCode)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(commond)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
            End Using
        Catch ex As Exception
            'LOGDelegate.getInstance.getFileLogger(Me).Error(ex.ToString)
            Throw ex
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' 依健保碼刪除
    ''' </summary>
    ''' <param name="strInsuCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function deletePUBNhiCodeByInsuCode(ByVal strInsuCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            "  Insu_Code=@Insu_Code "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With

                command.Parameters.AddWithValue("@Insu_Code", strInsuCode)
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

#End Region

#Region "20160510 查詢健保科別(加成) By Will"

    ''' <summary>
    ''' 查詢健保科別(加成)
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks></remarks>
    Function queryPUBNhiDeptCode() As DataSet
        Dim ds As DataSet
        Try
            Dim strSql As New StringBuilder
            strSql.Append("select  Insu_Dept_Code,Insu_Dept_Code_Name  from  PUB_Insu_dept  where dc='N'").Append(vbCrLf)


            Using SqlConn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim commond As SqlCommand = SqlConn.CreateCommand
                commond.CommandText = strSql.ToString
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(commond)
                ds = New Data.DataSet("PUB_Insu_dept")
                adapter.Fill(ds, "PUB_Insu_dept")
            End Using
        Catch ex As Exception
             Throw ex
        End Try
        Return ds
    End Function


#End Region

End Class

