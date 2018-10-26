Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL
Public Class PubRuleBO
    'Roger's CodeGen Produced This VB Code @ 2011/11/14 上午 11:54:00
    Public Shared ReadOnly tableName as String="PUB_Rule"
    Private Shared myInstance As PubRuleBO
    Public Shared Function GetInstance() As PubRuleBO
        If myInstance Is Nothing Then
            myInstance = New PubRuleBO()
        End If 
        Return myInstance 
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
            command.CommandText = "select * from "& tableName
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SQLException
            Throw sqlex
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
            Dim sqlString as String="insert into " & tableName & "(" & _
            " Rule_Code , Rule_Name , Check_Type , Expression_Str , Check_Identity ,  " & _ 
             " Limit_Alert_Level , Is_Sending_Alert_Mail , Is_Rule_Reason , Is_Enabled_Client , Is_Enabled_Server ,  " & _ 
             " Is_Only_SO , Is_Only_SE , Is_Only_SI , Is_Only_CO , Is_Only_CE ,  " & _ 
             " Is_Only_CI , True_Message , False_Message , Valid_Date_S , Valid_Date_E ,  " & _ 
             " Original_Rule_Code , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _ 
             " Info_Message , Parent_Rule_Code , Is_Bypass_Check , Input_Notice_Label , OPH_Rule_Reason ,  " & _ 
             " Is_Prior_Review , Ext_No , Is_Sorted_ByName ) " & _ 
             " values( @Rule_Code , @Rule_Name , @Check_Type , @Expression_Str , @Check_Identity ,  " & _ 
             " @Limit_Alert_Level , @Is_Sending_Alert_Mail , @Is_Rule_Reason , @Is_Enabled_Client , @Is_Enabled_Server ,  " & _ 
             " @Is_Only_SO , @Is_Only_SE , @Is_Only_SI , @Is_Only_CO , @Is_Only_CE ,  " & _ 
             " @Is_Only_CI , @True_Message , @False_Message , @Valid_Date_S , @Valid_Date_E ,  " & _ 
             " @Original_Rule_Code , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _ 
             " @Info_Message , @Parent_Rule_Code , @Is_Bypass_Check , @Input_Notice_Label , @OPH_Rule_Reason ,  " & _ 
             " @Is_Prior_Review , @Ext_No , @Is_Sorted_ByName             )"
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Rule_Code", row.Item("Rule_Code"))
                        Command.Parameters.AddWithValue("@Rule_Name", row.Item("Rule_Name"))
                        Command.Parameters.AddWithValue("@Check_Type", row.Item("Check_Type"))
                        Command.Parameters.AddWithValue("@Expression_Str", row.Item("Expression_Str"))
                        Command.Parameters.AddWithValue("@Check_Identity", row.Item("Check_Identity"))
                        Command.Parameters.AddWithValue("@Limit_Alert_Level", row.Item("Limit_Alert_Level"))
                        Command.Parameters.AddWithValue("@Is_Sending_Alert_Mail", row.Item("Is_Sending_Alert_Mail"))
                        Command.Parameters.AddWithValue("@Is_Rule_Reason", row.Item("Is_Rule_Reason"))
                        Command.Parameters.AddWithValue("@Is_Enabled_Client", row.Item("Is_Enabled_Client"))
                        Command.Parameters.AddWithValue("@Is_Enabled_Server", row.Item("Is_Enabled_Server"))
                        Command.Parameters.AddWithValue("@Is_Only_SO", row.Item("Is_Only_SO"))
                        Command.Parameters.AddWithValue("@Is_Only_SE", row.Item("Is_Only_SE"))
                        Command.Parameters.AddWithValue("@Is_Only_SI", row.Item("Is_Only_SI"))
                        Command.Parameters.AddWithValue("@Is_Only_CO", row.Item("Is_Only_CO"))
                        Command.Parameters.AddWithValue("@Is_Only_CE", row.Item("Is_Only_CE"))
                        Command.Parameters.AddWithValue("@Is_Only_CI", row.Item("Is_Only_CI"))
                        Command.Parameters.AddWithValue("@True_Message", row.Item("True_Message"))
                        Command.Parameters.AddWithValue("@False_Message", row.Item("False_Message"))
                        Command.Parameters.AddWithValue("@Valid_Date_S", row.Item("Valid_Date_S"))
                        Command.Parameters.AddWithValue("@Valid_Date_E", row.Item("Valid_Date_E"))
                        Command.Parameters.AddWithValue("@Original_Rule_Code", row.Item("Original_Rule_Code"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Info_Message", row.Item("Info_Message"))
                        Command.Parameters.AddWithValue("@Parent_Rule_Code", row.Item("Parent_Rule_Code"))
                        Command.Parameters.AddWithValue("@Is_Bypass_Check", row.Item("Is_Bypass_Check"))
                        Command.Parameters.AddWithValue("@Input_Notice_Label", row.Item("Input_Notice_Label"))
                        Command.Parameters.AddWithValue("@OPH_Rule_Reason", row.Item("OPH_Rule_Reason"))
                        Command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                        Command.Parameters.AddWithValue("@Ext_No", row.Item("Ext_No"))
                        Command.Parameters.AddWithValue("@Is_Sorted_ByName", row.Item("Is_Sorted_ByName"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
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
            Dim sqlString as String="insert into " & tableName & "(" & _
            " Rule_Code , Rule_Name , Check_Type , Expression_Str , Check_Identity ,  " & _ 
             " Limit_Alert_Level , Is_Sending_Alert_Mail , Is_Rule_Reason , Is_Enabled_Client , Is_Enabled_Server ,  " & _ 
             " Is_Only_SO , Is_Only_SE , Is_Only_SI , Is_Only_CO , Is_Only_CE ,  " & _ 
             " Is_Only_CI , True_Message , False_Message , Valid_Date_S , Valid_Date_E ,  " & _ 
             " Original_Rule_Code , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _ 
             " Info_Message , Parent_Rule_Code , Is_Bypass_Check , Input_Notice_Label , OPH_Rule_Reason ,  " & _ 
             " Is_Prior_Review , Ext_No , Is_Sorted_ByName ) " & _ 
             " values( @Rule_Code , @Rule_Name , @Check_Type , @Expression_Str , @Check_Identity ,  " & _ 
             " @Limit_Alert_Level , @Is_Sending_Alert_Mail , @Is_Rule_Reason , @Is_Enabled_Client , @Is_Enabled_Server ,  " & _ 
             " @Is_Only_SO , @Is_Only_SE , @Is_Only_SI , @Is_Only_CO , @Is_Only_CE ,  " & _ 
             " @Is_Only_CI , @True_Message , @False_Message , @Valid_Date_S , @Valid_Date_E ,  " & _ 
             " @Original_Rule_Code , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _ 
             " @Info_Message , @Parent_Rule_Code , @Is_Bypass_Check , @Input_Notice_Label , @OPH_Rule_Reason ,  " & _ 
             " @Is_Prior_Review , @Ext_No , @Is_Sorted_ByName             )"
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Rule_Code", row.Item("Rule_Code"))
                        Command.Parameters.AddWithValue("@Rule_Name", row.Item("Rule_Name"))
                        Command.Parameters.AddWithValue("@Check_Type", row.Item("Check_Type"))
                        Command.Parameters.AddWithValue("@Expression_Str", row.Item("Expression_Str"))
                        Command.Parameters.AddWithValue("@Check_Identity", row.Item("Check_Identity"))
                        Command.Parameters.AddWithValue("@Limit_Alert_Level", row.Item("Limit_Alert_Level"))
                        Command.Parameters.AddWithValue("@Is_Sending_Alert_Mail", row.Item("Is_Sending_Alert_Mail"))
                        Command.Parameters.AddWithValue("@Is_Rule_Reason", row.Item("Is_Rule_Reason"))
                        Command.Parameters.AddWithValue("@Is_Enabled_Client", row.Item("Is_Enabled_Client"))
                        Command.Parameters.AddWithValue("@Is_Enabled_Server", row.Item("Is_Enabled_Server"))
                        Command.Parameters.AddWithValue("@Is_Only_SO", row.Item("Is_Only_SO"))
                        Command.Parameters.AddWithValue("@Is_Only_SE", row.Item("Is_Only_SE"))
                        Command.Parameters.AddWithValue("@Is_Only_SI", row.Item("Is_Only_SI"))
                        Command.Parameters.AddWithValue("@Is_Only_CO", row.Item("Is_Only_CO"))
                        Command.Parameters.AddWithValue("@Is_Only_CE", row.Item("Is_Only_CE"))
                        Command.Parameters.AddWithValue("@Is_Only_CI", row.Item("Is_Only_CI"))
                        Command.Parameters.AddWithValue("@True_Message", row.Item("True_Message"))
                        Command.Parameters.AddWithValue("@False_Message", row.Item("False_Message"))
                        Command.Parameters.AddWithValue("@Valid_Date_S", row.Item("Valid_Date_S"))
                        Command.Parameters.AddWithValue("@Valid_Date_E", row.Item("Valid_Date_E"))
                        Command.Parameters.AddWithValue("@Original_Rule_Code", row.Item("Original_Rule_Code"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Info_Message", row.Item("Info_Message"))
                        Command.Parameters.AddWithValue("@Parent_Rule_Code", row.Item("Parent_Rule_Code"))
                        Command.Parameters.AddWithValue("@Is_Bypass_Check", row.Item("Is_Bypass_Check"))
                        Command.Parameters.AddWithValue("@Input_Notice_Label", row.Item("Input_Notice_Label"))
                        Command.Parameters.AddWithValue("@OPH_Rule_Reason", row.Item("OPH_Rule_Reason"))
                        Command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                        Command.Parameters.AddWithValue("@Ext_No", row.Item("Ext_No"))
                        Command.Parameters.AddWithValue("@Is_Sorted_ByName", row.Item("Is_Sorted_ByName"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
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
            Dim sqlString as String="insert into " & tableName & "(" & _
            " Rule_Code , Rule_Name , Check_Type , Expression_Str , Check_Identity ,  " & _ 
             " Limit_Alert_Level , Is_Sending_Alert_Mail , Is_Rule_Reason , Is_Enabled_Client , Is_Enabled_Server ,  " & _ 
             " Is_Only_SO , Is_Only_SE , Is_Only_SI , Is_Only_CO , Is_Only_CE ,  " & _ 
             " Is_Only_CI , True_Message , False_Message , Valid_Date_S , Valid_Date_E ,  " & _ 
             " Original_Rule_Code , Create_User , Create_Time , Modified_User , Modified_Time ,  " & _ 
             " Info_Message , Parent_Rule_Code , Is_Bypass_Check , Input_Notice_Label , OPH_Rule_Reason ,  " & _ 
             " Is_Prior_Review , Ext_No , Is_Sorted_ByName ) " & _ 
             " values( @Rule_Code , @Rule_Name , @Check_Type , @Expression_Str , @Check_Identity ,  " & _ 
             " @Limit_Alert_Level , @Is_Sending_Alert_Mail , @Is_Rule_Reason , @Is_Enabled_Client , @Is_Enabled_Server ,  " & _ 
             " @Is_Only_SO , @Is_Only_SE , @Is_Only_SI , @Is_Only_CO , @Is_Only_CE ,  " & _ 
             " @Is_Only_CI , @True_Message , @False_Message , @Valid_Date_S , @Valid_Date_E ,  " & _ 
             " @Original_Rule_Code , @Create_User , @Create_Time , @Modified_User , @Modified_Time ,  " & _ 
             " @Info_Message , @Parent_Rule_Code , @Is_Bypass_Check , @Input_Notice_Label , @OPH_Rule_Reason ,  " & _ 
             " @Is_Prior_Review , @Ext_No , @Is_Sorted_ByName             )"
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Rule_Code", row.Item("Rule_Code"))
                        Command.Parameters.AddWithValue("@Rule_Name", row.Item("Rule_Name"))
                        Command.Parameters.AddWithValue("@Check_Type", row.Item("Check_Type"))
                        Command.Parameters.AddWithValue("@Expression_Str", row.Item("Expression_Str"))
                        Command.Parameters.AddWithValue("@Check_Identity", row.Item("Check_Identity"))
                        Command.Parameters.AddWithValue("@Limit_Alert_Level", row.Item("Limit_Alert_Level"))
                        Command.Parameters.AddWithValue("@Is_Sending_Alert_Mail", row.Item("Is_Sending_Alert_Mail"))
                        Command.Parameters.AddWithValue("@Is_Rule_Reason", row.Item("Is_Rule_Reason"))
                        Command.Parameters.AddWithValue("@Is_Enabled_Client", row.Item("Is_Enabled_Client"))
                        Command.Parameters.AddWithValue("@Is_Enabled_Server", row.Item("Is_Enabled_Server"))
                        Command.Parameters.AddWithValue("@Is_Only_SO", row.Item("Is_Only_SO"))
                        Command.Parameters.AddWithValue("@Is_Only_SE", row.Item("Is_Only_SE"))
                        Command.Parameters.AddWithValue("@Is_Only_SI", row.Item("Is_Only_SI"))
                        Command.Parameters.AddWithValue("@Is_Only_CO", row.Item("Is_Only_CO"))
                        Command.Parameters.AddWithValue("@Is_Only_CE", row.Item("Is_Only_CE"))
                        Command.Parameters.AddWithValue("@Is_Only_CI", row.Item("Is_Only_CI"))
                        Command.Parameters.AddWithValue("@True_Message", row.Item("True_Message"))
                        Command.Parameters.AddWithValue("@False_Message", row.Item("False_Message"))
                        Command.Parameters.AddWithValue("@Valid_Date_S", row.Item("Valid_Date_S"))
                        Command.Parameters.AddWithValue("@Valid_Date_E", row.Item("Valid_Date_E"))
                        Command.Parameters.AddWithValue("@Original_Rule_Code", row.Item("Original_Rule_Code"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Info_Message", row.Item("Info_Message"))
                        Command.Parameters.AddWithValue("@Parent_Rule_Code", row.Item("Parent_Rule_Code"))
                        Command.Parameters.AddWithValue("@Is_Bypass_Check", row.Item("Is_Bypass_Check"))
                        Command.Parameters.AddWithValue("@Input_Notice_Label", row.Item("Input_Notice_Label"))
                        Command.Parameters.AddWithValue("@OPH_Rule_Reason", row.Item("OPH_Rule_Reason"))
                        Command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                        Command.Parameters.AddWithValue("@Ext_No", row.Item("Ext_No"))
                        Command.Parameters.AddWithValue("@Is_Sorted_ByName", row.Item("Is_Sorted_ByName"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD002", ex)
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
        Catch sqlex As SQLException
            Throw sqlex
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
            content.Append("select * from " & tableName & " where 1=1 ")
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
        Catch sqlex As SQLException
            Throw sqlex
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


    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByPK(ByRef pk_Rule_Code as System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection  = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from  "& tableName &" where Rule_Code=@Rule_Code            "
            Command.Parameters.AddWithValue("@Rule_Code",pk_Rule_Code)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SQLException
            Throw sqlex
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

    ''' <summary>
    '''以ＰＫ刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function delete(ByRef pk_Rule_Code as System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString as String="delete from " & tableName & " where " & _
            " Rule_Code=@Rule_Code "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                Using command As SqlCommand = New SqlCommand
                With Command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                Command.Parameters.AddWithValue("@Rule_Code", pk_Rule_Code)
                count = Command.ExecuteNonQuery
                End Using
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
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
    Public Function update(ByVal ds As System.Data.DataSet,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim sqlString as String ="update " & tableName & " set " & _
            " Rule_Name=@Rule_Name , Check_Type=@Check_Type , Expression_Str=@Expression_Str , Check_Identity=@Check_Identity " & _ 
            "  , Limit_Alert_Level=@Limit_Alert_Level , Is_Sending_Alert_Mail=@Is_Sending_Alert_Mail , Is_Rule_Reason=@Is_Rule_Reason , Is_Enabled_Client=@Is_Enabled_Client , Is_Enabled_Server=@Is_Enabled_Server " & _ 
            "  , Is_Only_SO=@Is_Only_SO , Is_Only_SE=@Is_Only_SE , Is_Only_SI=@Is_Only_SI , Is_Only_CO=@Is_Only_CO , Is_Only_CE=@Is_Only_CE " & _ 
            "  , Is_Only_CI=@Is_Only_CI , True_Message=@True_Message , False_Message=@False_Message , Valid_Date_S=@Valid_Date_S , Valid_Date_E=@Valid_Date_E " & _ 
            "  , Original_Rule_Code=@Original_Rule_Code , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  , Info_Message=@Info_Message , Parent_Rule_Code=@Parent_Rule_Code , Is_Bypass_Check=@Is_Bypass_Check , Input_Notice_Label=@Input_Notice_Label , OPH_Rule_Reason=@OPH_Rule_Reason " & _ 
            "  , Is_Prior_Review=@Is_Prior_Review , Ext_No=@Ext_No , Is_Sorted_ByName=@Is_Sorted_ByName " & _ 
            " where  Rule_Code=@Rule_Code            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                          .CommandText = sqlString
                          .CommandType = CommandType.Text
                          .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Rule_Code", row.Item("Rule_Code"))
                        Command.Parameters.AddWithValue("@Rule_Name", row.Item("Rule_Name"))
                        Command.Parameters.AddWithValue("@Check_Type", row.Item("Check_Type"))
                        Command.Parameters.AddWithValue("@Expression_Str", row.Item("Expression_Str"))
                        Command.Parameters.AddWithValue("@Check_Identity", row.Item("Check_Identity"))
                        Command.Parameters.AddWithValue("@Limit_Alert_Level", row.Item("Limit_Alert_Level"))
                        Command.Parameters.AddWithValue("@Is_Sending_Alert_Mail", row.Item("Is_Sending_Alert_Mail"))
                        Command.Parameters.AddWithValue("@Is_Rule_Reason", row.Item("Is_Rule_Reason"))
                        Command.Parameters.AddWithValue("@Is_Enabled_Client", row.Item("Is_Enabled_Client"))
                        Command.Parameters.AddWithValue("@Is_Enabled_Server", row.Item("Is_Enabled_Server"))
                        Command.Parameters.AddWithValue("@Is_Only_SO", row.Item("Is_Only_SO"))
                        Command.Parameters.AddWithValue("@Is_Only_SE", row.Item("Is_Only_SE"))
                        Command.Parameters.AddWithValue("@Is_Only_SI", row.Item("Is_Only_SI"))
                        Command.Parameters.AddWithValue("@Is_Only_CO", row.Item("Is_Only_CO"))
                        Command.Parameters.AddWithValue("@Is_Only_CE", row.Item("Is_Only_CE"))
                        Command.Parameters.AddWithValue("@Is_Only_CI", row.Item("Is_Only_CI"))
                        Command.Parameters.AddWithValue("@True_Message", row.Item("True_Message"))
                        Command.Parameters.AddWithValue("@False_Message", row.Item("False_Message"))
                        Command.Parameters.AddWithValue("@Valid_Date_S", row.Item("Valid_Date_S"))
                        Command.Parameters.AddWithValue("@Valid_Date_E", row.Item("Valid_Date_E"))
                        Command.Parameters.AddWithValue("@Original_Rule_Code", row.Item("Original_Rule_Code"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Info_Message", row.Item("Info_Message"))
                        Command.Parameters.AddWithValue("@Parent_Rule_Code", row.Item("Parent_Rule_Code"))
                        Command.Parameters.AddWithValue("@Is_Bypass_Check", row.Item("Is_Bypass_Check"))
                        Command.Parameters.AddWithValue("@Input_Notice_Label", row.Item("Input_Notice_Label"))
                        Command.Parameters.AddWithValue("@OPH_Rule_Reason", row.Item("OPH_Rule_Reason"))
                        Command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                        Command.Parameters.AddWithValue("@Ext_No", row.Item("Ext_No"))
                        Command.Parameters.AddWithValue("@Is_Sorted_ByName", row.Item("Is_Sorted_ByName"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
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
            Dim sqlString as String ="update " & tableName & " set " & _
            " Rule_Name=@Rule_Name , Check_Type=@Check_Type , Expression_Str=@Expression_Str , Check_Identity=@Check_Identity " & _ 
            "  , Limit_Alert_Level=@Limit_Alert_Level , Is_Sending_Alert_Mail=@Is_Sending_Alert_Mail , Is_Rule_Reason=@Is_Rule_Reason , Is_Enabled_Client=@Is_Enabled_Client , Is_Enabled_Server=@Is_Enabled_Server " & _ 
            "  , Is_Only_SO=@Is_Only_SO , Is_Only_SE=@Is_Only_SE , Is_Only_SI=@Is_Only_SI , Is_Only_CO=@Is_Only_CO , Is_Only_CE=@Is_Only_CE " & _ 
            "  , Is_Only_CI=@Is_Only_CI , True_Message=@True_Message , False_Message=@False_Message , Valid_Date_S=@Valid_Date_S , Valid_Date_E=@Valid_Date_E " & _ 
            "  , Original_Rule_Code=@Original_Rule_Code , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  , Info_Message=@Info_Message , Parent_Rule_Code=@Parent_Rule_Code , Is_Bypass_Check=@Is_Bypass_Check , Input_Notice_Label=@Input_Notice_Label , OPH_Rule_Reason=@OPH_Rule_Reason " & _ 
            "  , Is_Prior_Review=@Is_Prior_Review , Ext_No=@Ext_No , Is_Sorted_ByName=@Is_Sorted_ByName " & _ 
            " where  Rule_Code=@Rule_Code            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                          .CommandText = sqlString
                          .CommandType = CommandType.Text
                          .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Rule_Code", row.Item("Rule_Code"))
                        Command.Parameters.AddWithValue("@Rule_Name", row.Item("Rule_Name"))
                        Command.Parameters.AddWithValue("@Check_Type", row.Item("Check_Type"))
                        Command.Parameters.AddWithValue("@Expression_Str", row.Item("Expression_Str"))
                        Command.Parameters.AddWithValue("@Check_Identity", row.Item("Check_Identity"))
                        Command.Parameters.AddWithValue("@Limit_Alert_Level", row.Item("Limit_Alert_Level"))
                        Command.Parameters.AddWithValue("@Is_Sending_Alert_Mail", row.Item("Is_Sending_Alert_Mail"))
                        Command.Parameters.AddWithValue("@Is_Rule_Reason", row.Item("Is_Rule_Reason"))
                        Command.Parameters.AddWithValue("@Is_Enabled_Client", row.Item("Is_Enabled_Client"))
                        Command.Parameters.AddWithValue("@Is_Enabled_Server", row.Item("Is_Enabled_Server"))
                        Command.Parameters.AddWithValue("@Is_Only_SO", row.Item("Is_Only_SO"))
                        Command.Parameters.AddWithValue("@Is_Only_SE", row.Item("Is_Only_SE"))
                        Command.Parameters.AddWithValue("@Is_Only_SI", row.Item("Is_Only_SI"))
                        Command.Parameters.AddWithValue("@Is_Only_CO", row.Item("Is_Only_CO"))
                        Command.Parameters.AddWithValue("@Is_Only_CE", row.Item("Is_Only_CE"))
                        Command.Parameters.AddWithValue("@Is_Only_CI", row.Item("Is_Only_CI"))
                        Command.Parameters.AddWithValue("@True_Message", row.Item("True_Message"))
                        Command.Parameters.AddWithValue("@False_Message", row.Item("False_Message"))
                        Command.Parameters.AddWithValue("@Valid_Date_S", row.Item("Valid_Date_S"))
                        Command.Parameters.AddWithValue("@Valid_Date_E", row.Item("Valid_Date_E"))
                        Command.Parameters.AddWithValue("@Original_Rule_Code", row.Item("Original_Rule_Code"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Info_Message", row.Item("Info_Message"))
                        Command.Parameters.AddWithValue("@Parent_Rule_Code", row.Item("Parent_Rule_Code"))
                        Command.Parameters.AddWithValue("@Is_Bypass_Check", row.Item("Is_Bypass_Check"))
                        Command.Parameters.AddWithValue("@Input_Notice_Label", row.Item("Input_Notice_Label"))
                        Command.Parameters.AddWithValue("@OPH_Rule_Reason", row.Item("OPH_Rule_Reason"))
                        Command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                        Command.Parameters.AddWithValue("@Ext_No", row.Item("Ext_No"))
                        Command.Parameters.AddWithValue("@Is_Sorted_ByName", row.Item("Is_Sorted_ByName"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
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
            Dim sqlString as String ="update " & tableName & " set " & _
            " Rule_Name=@Rule_Name , Check_Type=@Check_Type , Expression_Str=@Expression_Str , Check_Identity=@Check_Identity " & _ 
            "  , Limit_Alert_Level=@Limit_Alert_Level , Is_Sending_Alert_Mail=@Is_Sending_Alert_Mail , Is_Rule_Reason=@Is_Rule_Reason , Is_Enabled_Client=@Is_Enabled_Client , Is_Enabled_Server=@Is_Enabled_Server " & _ 
            "  , Is_Only_SO=@Is_Only_SO , Is_Only_SE=@Is_Only_SE , Is_Only_SI=@Is_Only_SI , Is_Only_CO=@Is_Only_CO , Is_Only_CE=@Is_Only_CE " & _ 
            "  , Is_Only_CI=@Is_Only_CI , True_Message=@True_Message , False_Message=@False_Message , Valid_Date_S=@Valid_Date_S , Valid_Date_E=@Valid_Date_E " & _ 
            "  , Original_Rule_Code=@Original_Rule_Code , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _ 
            "  , Info_Message=@Info_Message , Parent_Rule_Code=@Parent_Rule_Code , Is_Bypass_Check=@Is_Bypass_Check , Input_Notice_Label=@Input_Notice_Label , OPH_Rule_Reason=@OPH_Rule_Reason " & _ 
            "  , Is_Prior_Review=@Is_Prior_Review , Ext_No=@Ext_No , Is_Sorted_ByName=@Is_Sorted_ByName " & _ 
            " where  Rule_Code=@Rule_Code            "
            If connFlag Then
                conn = getAuthenticConnection()
                conn.Open()
            End If
                For Each row As DataRow In ds.Tables(0).Rows
                  Using command As SqlCommand = New SqlCommand
                        With Command
                          .CommandText = sqlString
                          .CommandType = CommandType.Text
                          .Connection = CType(conn, SqlConnection)
                        End With
                        Command.Parameters.AddWithValue("@Rule_Code", row.Item("Rule_Code"))
                        Command.Parameters.AddWithValue("@Rule_Name", row.Item("Rule_Name"))
                        Command.Parameters.AddWithValue("@Check_Type", row.Item("Check_Type"))
                        Command.Parameters.AddWithValue("@Expression_Str", row.Item("Expression_Str"))
                        Command.Parameters.AddWithValue("@Check_Identity", row.Item("Check_Identity"))
                        Command.Parameters.AddWithValue("@Limit_Alert_Level", row.Item("Limit_Alert_Level"))
                        Command.Parameters.AddWithValue("@Is_Sending_Alert_Mail", row.Item("Is_Sending_Alert_Mail"))
                        Command.Parameters.AddWithValue("@Is_Rule_Reason", row.Item("Is_Rule_Reason"))
                        Command.Parameters.AddWithValue("@Is_Enabled_Client", row.Item("Is_Enabled_Client"))
                        Command.Parameters.AddWithValue("@Is_Enabled_Server", row.Item("Is_Enabled_Server"))
                        Command.Parameters.AddWithValue("@Is_Only_SO", row.Item("Is_Only_SO"))
                        Command.Parameters.AddWithValue("@Is_Only_SE", row.Item("Is_Only_SE"))
                        Command.Parameters.AddWithValue("@Is_Only_SI", row.Item("Is_Only_SI"))
                        Command.Parameters.AddWithValue("@Is_Only_CO", row.Item("Is_Only_CO"))
                        Command.Parameters.AddWithValue("@Is_Only_CE", row.Item("Is_Only_CE"))
                        Command.Parameters.AddWithValue("@Is_Only_CI", row.Item("Is_Only_CI"))
                        Command.Parameters.AddWithValue("@True_Message", row.Item("True_Message"))
                        Command.Parameters.AddWithValue("@False_Message", row.Item("False_Message"))
                        Command.Parameters.AddWithValue("@Valid_Date_S", row.Item("Valid_Date_S"))
                        Command.Parameters.AddWithValue("@Valid_Date_E", row.Item("Valid_Date_E"))
                        Command.Parameters.AddWithValue("@Original_Rule_Code", row.Item("Original_Rule_Code"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Info_Message", row.Item("Info_Message"))
                        Command.Parameters.AddWithValue("@Parent_Rule_Code", row.Item("Parent_Rule_Code"))
                        Command.Parameters.AddWithValue("@Is_Bypass_Check", row.Item("Is_Bypass_Check"))
                        Command.Parameters.AddWithValue("@Input_Notice_Label", row.Item("Input_Notice_Label"))
                        Command.Parameters.AddWithValue("@OPH_Rule_Reason", row.Item("OPH_Rule_Reason"))
                        Command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                        Command.Parameters.AddWithValue("@Ext_No", row.Item("Ext_No"))
                        Command.Parameters.AddWithValue("@Is_Sorted_ByName", row.Item("Is_Sorted_ByName"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                Next
            Return count
        Catch sqlex As SQLException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
               conn.Close()
               conn.Dispose()
               conn = Nothing
            End If
        End Try
    End Function 

    ''' <summary>
    '''取得表格 PUB_Rule 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOPDDBSqlConn
    End Function 


    ''' <summary>
    '''取得表格 PUB_Rule 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks>queryByPK 目前也用這個，因為是單檔查詢且為 PK 條件</remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 

End Class
