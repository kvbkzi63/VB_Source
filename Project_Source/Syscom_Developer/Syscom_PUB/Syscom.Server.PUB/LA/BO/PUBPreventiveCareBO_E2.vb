'/*
'*****************************************************************************
'*
'*    Page/Class Name:  預防保健基本檔設定維護
'*              Title:	PUBPreventiveCareBO_E2
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd
'*            @author:	Remote_Liu
'*        Create Date:	2016-05-17
'*      Last Modifier:	Remote_Liu
'*   Last Modify Date:	2016-05-17
'*
'*****************************************************************************
'*/

Imports System.Data.SqlClient
Imports System.Transactions
Imports Syscom.Comm.Utility
Imports Syscom.Server.SQL
Imports Syscom.Server.BO
Imports System.Text
Imports System.Data
Imports Syscom.Comm.EXP




Public Class PUBPreventiveCareBO_E2
    Inherits PubPreventiveCareBO

#Region "     使用的Instance宣告 "
    Public Shared ReadOnly tableNamePUB_SYSCode As String = "Pub_Preventive_Care"

    Private Shared myInstance As PUBPreventiveCareBO_E2
    Public Overloads Shared Function GetInstance() As PUBPreventiveCareBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPreventiveCareBO_E2
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
            " Care_Item_Code , Care_Order_Code , Care_Cardseq , Care_Cardseq_Name , Age_Control_Id ,  " & _
             " Age_Start , Age_End , Preventive_Care_Memo , Package_Code , Limit_Sex_Id ,  " & _
             " Filter_Desc , Advisory_Unit , Opd_Memo , Preventive_Care_Note ) " & _
             " values( @Care_Item_Code , @Care_Order_Code , @Care_Cardseq , @Care_Cardseq_Name , @Age_Control_Id ,  " & _
             " @Age_Start , @Age_End , @Preventive_Care_Memo , @Package_Code , @Limit_Sex_Id ,  " & _
             " @Filter_Desc , @Advisory_Unit , @Opd_Memo , @Preventive_Care_Note             )"
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
                    Command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                    Command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                    Command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                    Command.Parameters.AddWithValue("@Care_Cardseq_Name", row.Item("Care_Cardseq_Name"))
                    Command.Parameters.AddWithValue("@Age_Control_Id", row.Item("Age_Control_Id"))
                    Command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                    Command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                    Command.Parameters.AddWithValue("@Preventive_Care_Memo", row.Item("Preventive_Care_Memo"))
                    Command.Parameters.AddWithValue("@Package_Code", row.Item("Package_Code"))
                    Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                    Command.Parameters.AddWithValue("@Filter_Desc", row.Item("Filter_Desc"))
                    Command.Parameters.AddWithValue("@Advisory_Unit", row.Item("Advisory_Unit"))
                    Command.Parameters.AddWithValue("@Opd_Memo", row.Item("Opd_Memo"))
                    Command.Parameters.AddWithValue("@Preventive_Care_Note", row.Item("Preventive_Care_Note"))
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

#Region "     修改 Method "

    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Overloads Function update(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Care_Cardseq_Name=@Care_Cardseq_Name , Age_Control_Id=@Age_Control_Id " & _
            "  , Age_Start=@Age_Start , Age_End=@Age_End , Preventive_Care_Memo=@Preventive_Care_Memo , Package_Code=@Package_Code , Limit_Sex_Id=@Limit_Sex_Id " & _
            "  , Filter_Desc=@Filter_Desc , Advisory_Unit=@Advisory_Unit , Opd_Memo=@Opd_Memo , Preventive_Care_Note=@Preventive_Care_Note " & _
            " where  Care_Item_Code=@Care_Item_Code and Care_Order_Code=@Care_Order_Code and Care_Cardseq=@Care_Cardseq            "
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
                    command.Parameters.AddWithValue("@Care_Item_Code", row.Item("Care_Item_Code"))
                    command.Parameters.AddWithValue("@Care_Order_Code", row.Item("Care_Order_Code"))
                    command.Parameters.AddWithValue("@Care_Cardseq", row.Item("Care_Cardseq"))
                    command.Parameters.AddWithValue("@Care_Cardseq_Name", row.Item("Care_Cardseq_Name"))
                    command.Parameters.AddWithValue("@Age_Control_Id", row.Item("Age_Control_Id"))
                    command.Parameters.AddWithValue("@Age_Start", row.Item("Age_Start"))
                    command.Parameters.AddWithValue("@Age_End", row.Item("Age_End"))
                    command.Parameters.AddWithValue("@Preventive_Care_Memo", row.Item("Preventive_Care_Memo"))
                    command.Parameters.AddWithValue("@Package_Code", row.Item("Package_Code"))
                    command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                    command.Parameters.AddWithValue("@Filter_Desc", row.Item("Filter_Desc"))
                    command.Parameters.AddWithValue("@Advisory_Unit", row.Item("Advisory_Unit"))
                    command.Parameters.AddWithValue("@Opd_Memo", row.Item("Opd_Memo"))
                    command.Parameters.AddWithValue("@Preventive_Care_Note", row.Item("Preventive_Care_Note"))
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

#Region " 刪除"

    ''' <summary>
    '''以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Function delete(ByRef pk_Care_Item_Code As System.String, ByRef pk_Care_Order_Code As System.String, ByRef pk_Care_Cardseq As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "delete from " & tableName & " where " & _
            " Care_Item_Code=@Care_Item_Code and Care_Order_Code=@Care_Order_Code and Care_Cardseq=@Care_Cardseq "
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
                command.Parameters.AddWithValue("@Care_Item_Code", pk_Care_Item_Code)
                command.Parameters.AddWithValue("@Care_Order_Code", pk_Care_Order_Code)
                command.Parameters.AddWithValue("@Care_Cardseq", pk_Care_Cardseq)
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
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Function queryByPK(ByRef pk_Care_Item_Code As System.String, ByRef pk_Care_Order_Code As System.String, ByRef pk_Care_Cardseq As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Care_Item_Code , Care_Order_Code , Care_Cardseq , Care_Cardseq_Name , Age_Control_Id ,  ")
            content.AppendLine(" Age_Start , Age_End , Preventive_Care_Memo , Package_Code , Limit_Sex_Id ,  ")
            content.AppendLine(" Filter_Desc , Advisory_Unit , Opd_Memo , Preventive_Care_Note                from " & tableName)
            content.AppendLine("   where Care_Item_Code=@Care_Item_Code and Care_Order_Code=@Care_Order_Code and Care_Cardseq=@Care_Cardseq            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Care_Item_Code", pk_Care_Item_Code)
            command.Parameters.AddWithValue("@Care_Order_Code", pk_Care_Order_Code)
            command.Parameters.AddWithValue("@Care_Cardseq", pk_Care_Cardseq)
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
    Public Overloads Function queryAll(Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Care_Item_Code , Care_Order_Code , Care_Cardseq , Care_Cardseq_Name , Age_Control_Id ,  ")
            content.AppendLine(" Age_Start , Age_End , Preventive_Care_Memo , Package_Code , Limit_Sex_Id ,  ")
            content.AppendLine(" Filter_Desc , Advisory_Unit , Opd_Memo , Preventive_Care_Note                from " & tableName)
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
    '''以ＰＫ Like 的方式查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Function queryByLikePK(ByRef pk_Care_Item_Code As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Care_Item_Code , Care_Order_Code , Care_Cardseq , Care_Cardseq_Name , Age_Control_Id ,  ")
            content.AppendLine(" Age_Start , Age_End , Preventive_Care_Memo , Package_Code , Limit_Sex_Id ,  ")
            content.AppendLine(" Filter_Desc , Advisory_Unit , Opd_Memo , Preventive_Care_Note                from " & tableName)
            content.AppendLine("   where Care_Item_Code like @Care_Item_Code")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Care_Item_Code", pk_Care_Item_Code & "%")
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


#Region "    取得ComboBox資料（服務項目,服務時程代碼,年齡控制類型,性別限制） "
    ''' <summary>
    ''' 取得ComboBox資料
    ''' </summary>
    ''' <returns>System.Data.DataSet</returns>
    ''' <remarks>by Remote_Liu on 2016-05-18</remarks>
    Public Function queryPUBCareItemAgeSex() As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As StringBuilder = New StringBuilder()
            '服務項目
            'content.Append("SELECT DISTINCT Ohd_Code_Id, " & vbCrLf)
            'content.Append("                Ohd_Code_Name " & vbCrLf)
            'content.Append("FROM   Ohd_Code " & vbCrLf)
            'content.Append("              where Ohd_Type_Id = 'Care_Item_Code' ")

            content.Append("select code_id, " & vbCrLf)
            content.Append("                Code_En_Name " & vbCrLf)
            content.Append("from   PUB_Syscode " & vbCrLf)
            content.Append("              where type_id='106' ")



            ' 服務時程代碼
            content.Append(" " & vbCrLf)
            content.Append("SELECT DISTINCT Ohd_Code_Id, " & vbCrLf)
            content.Append("                Ohd_Code_Name " & vbCrLf)
            content.Append("FROM   Ohd_Code  " & vbCrLf)
            content.Append("              where Ohd_Type_Id = 'Care_Order_Code'")
            '年齡控制類型
            content.Append(" " & vbCrLf)
            content.Append("SELECT Code_Id, " & vbCrLf)
            content.Append("       Code_Name " & vbCrLf)
            content.Append("FROM   PUB_Syscode " & vbCrLf)
            content.Append("WHERE  Type_Id = 40")
            ' 性別限制
            content.Append(" " & vbCrLf)
            content.Append("SELECT Code_Id, " & vbCrLf)
            content.Append("       Code_Name " & vbCrLf)
            content.Append("FROM   PUB_Syscode " & vbCrLf)
            content.Append("WHERE  Type_Id = 21 ")

            command.CommandText = content.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class