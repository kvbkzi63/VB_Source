Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubContractBO
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:47
    Public Shared ReadOnly tableName As String="PUB_Contract"
    Private Shared myInstance As PubContractBO
    Public Shared Function GetInstance() As PubContractBO
        If myInstance Is Nothing Then
            myInstance = New PubContractBO()
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
            " Contract_Code , Sub_Identity_Code , Contract_Name , Is_Use_Set , Upper_Amt ,  " & _ 
             " Upper_Amt_Type_Id , Check_Quota_Id , Project_Director , Drug_Code , Drug_Name ,  " & _ 
             " Drug_Committee_Sn , Project_Effect_Date , Project_End_Date , Receipt_Title , Contact_Name ,  " & _ 
             " Contact_Tel , Contact_Tel_Mobile , Contact_Fax , Contact_Email , Contact_Postal_Code ,  " & _ 
             " Contact_Address , Dis_Rate , Add_Rate , Memo , Dc ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time , Contract_Type_Id " & _ 
             "  ) " & _ 
             " values( @Contract_Code , @Sub_Identity_Code , @Contract_Name , @Is_Use_Set , @Upper_Amt ,  " & _ 
             " @Upper_Amt_Type_Id , @Check_Quota_Id , @Project_Director , @Drug_Code , @Drug_Name ,  " & _ 
             " @Drug_Committee_Sn , @Project_Effect_Date , @Project_End_Date , @Receipt_Title , @Contact_Name ,  " & _ 
             " @Contact_Tel , @Contact_Tel_Mobile , @Contact_Fax , @Contact_Email , @Contact_Postal_Code ,  " & _ 
             " @Contact_Address , @Dis_Rate , @Add_Rate , @Memo , @Dc ,  " & _ 
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time , @Contract_Type_Id " & _ 
             "              )"
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
                        Command.Parameters.AddWithValue("@Contract_Code", row.Item("Contract_Code"))
                        Command.Parameters.AddWithValue("@Sub_Identity_Code", row.Item("Sub_Identity_Code"))
                        Command.Parameters.AddWithValue("@Contract_Name", row.Item("Contract_Name"))
                        Command.Parameters.AddWithValue("@Is_Use_Set", row.Item("Is_Use_Set"))
                        Command.Parameters.AddWithValue("@Upper_Amt", row.Item("Upper_Amt"))
                        Command.Parameters.AddWithValue("@Upper_Amt_Type_Id", row.Item("Upper_Amt_Type_Id"))
                        Command.Parameters.AddWithValue("@Check_Quota_Id", row.Item("Check_Quota_Id"))
                        Command.Parameters.AddWithValue("@Project_Director", row.Item("Project_Director"))
                        Command.Parameters.AddWithValue("@Drug_Code", row.Item("Drug_Code"))
                        Command.Parameters.AddWithValue("@Drug_Name", row.Item("Drug_Name"))
                        Command.Parameters.AddWithValue("@Drug_Committee_Sn", row.Item("Drug_Committee_Sn"))
                        Command.Parameters.AddWithValue("@Project_Effect_Date", row.Item("Project_Effect_Date"))
                        Command.Parameters.AddWithValue("@Project_End_Date", row.Item("Project_End_Date"))
                        Command.Parameters.AddWithValue("@Receipt_Title", row.Item("Receipt_Title"))
                        Command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                        Command.Parameters.AddWithValue("@Contact_Tel", row.Item("Contact_Tel"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Contact_Fax", row.Item("Contact_Fax"))
                        Command.Parameters.AddWithValue("@Contact_Email", row.Item("Contact_Email"))
                        Command.Parameters.AddWithValue("@Contact_Postal_Code", row.Item("Contact_Postal_Code"))
                        Command.Parameters.AddWithValue("@Contact_Address", row.Item("Contact_Address"))
                        Command.Parameters.AddWithValue("@Dis_Rate", row.Item("Dis_Rate"))
                        Command.Parameters.AddWithValue("@Add_Rate", row.Item("Add_Rate"))
                        Command.Parameters.AddWithValue("@Memo", row.Item("Memo"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Contract_Type_Id", row.Item("Contract_Type_Id"))
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
            " Contract_Code , Sub_Identity_Code , Contract_Name , Is_Use_Set , Upper_Amt ,  " & _ 
             " Upper_Amt_Type_Id , Check_Quota_Id , Project_Director , Drug_Code , Drug_Name ,  " & _ 
             " Drug_Committee_Sn , Project_Effect_Date , Project_End_Date , Receipt_Title , Contact_Name ,  " & _ 
             " Contact_Tel , Contact_Tel_Mobile , Contact_Fax , Contact_Email , Contact_Postal_Code ,  " & _ 
             " Contact_Address , Dis_Rate , Add_Rate , Memo , Dc ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time , Contract_Type_Id " & _ 
             "  ) " & _ 
             " values( @Contract_Code , @Sub_Identity_Code , @Contract_Name , @Is_Use_Set , @Upper_Amt ,  " & _ 
             " @Upper_Amt_Type_Id , @Check_Quota_Id , @Project_Director , @Drug_Code , @Drug_Name ,  " & _ 
             " @Drug_Committee_Sn , @Project_Effect_Date , @Project_End_Date , @Receipt_Title , @Contact_Name ,  " & _ 
             " @Contact_Tel , @Contact_Tel_Mobile , @Contact_Fax , @Contact_Email , @Contact_Postal_Code ,  " & _ 
             " @Contact_Address , @Dis_Rate , @Add_Rate , @Memo , @Dc ,  " & _ 
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time , @Contract_Type_Id " & _ 
             "              )"
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
                        Command.Parameters.AddWithValue("@Contract_Code", row.Item("Contract_Code"))
                        Command.Parameters.AddWithValue("@Sub_Identity_Code", row.Item("Sub_Identity_Code"))
                        Command.Parameters.AddWithValue("@Contract_Name", row.Item("Contract_Name"))
                        Command.Parameters.AddWithValue("@Is_Use_Set", row.Item("Is_Use_Set"))
                        Command.Parameters.AddWithValue("@Upper_Amt", row.Item("Upper_Amt"))
                        Command.Parameters.AddWithValue("@Upper_Amt_Type_Id", row.Item("Upper_Amt_Type_Id"))
                        Command.Parameters.AddWithValue("@Check_Quota_Id", row.Item("Check_Quota_Id"))
                        Command.Parameters.AddWithValue("@Project_Director", row.Item("Project_Director"))
                        Command.Parameters.AddWithValue("@Drug_Code", row.Item("Drug_Code"))
                        Command.Parameters.AddWithValue("@Drug_Name", row.Item("Drug_Name"))
                        Command.Parameters.AddWithValue("@Drug_Committee_Sn", row.Item("Drug_Committee_Sn"))
                        Command.Parameters.AddWithValue("@Project_Effect_Date", row.Item("Project_Effect_Date"))
                        Command.Parameters.AddWithValue("@Project_End_Date", row.Item("Project_End_Date"))
                        Command.Parameters.AddWithValue("@Receipt_Title", row.Item("Receipt_Title"))
                        Command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                        Command.Parameters.AddWithValue("@Contact_Tel", row.Item("Contact_Tel"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Contact_Fax", row.Item("Contact_Fax"))
                        Command.Parameters.AddWithValue("@Contact_Email", row.Item("Contact_Email"))
                        Command.Parameters.AddWithValue("@Contact_Postal_Code", row.Item("Contact_Postal_Code"))
                        Command.Parameters.AddWithValue("@Contact_Address", row.Item("Contact_Address"))
                        Command.Parameters.AddWithValue("@Dis_Rate", row.Item("Dis_Rate"))
                        Command.Parameters.AddWithValue("@Add_Rate", row.Item("Add_Rate"))
                        Command.Parameters.AddWithValue("@Memo", row.Item("Memo"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Contract_Type_Id", row.Item("Contract_Type_Id"))
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
            " Contract_Code , Sub_Identity_Code , Contract_Name , Is_Use_Set , Upper_Amt ,  " & _ 
             " Upper_Amt_Type_Id , Check_Quota_Id , Project_Director , Drug_Code , Drug_Name ,  " & _ 
             " Drug_Committee_Sn , Project_Effect_Date , Project_End_Date , Receipt_Title , Contact_Name ,  " & _ 
             " Contact_Tel , Contact_Tel_Mobile , Contact_Fax , Contact_Email , Contact_Postal_Code ,  " & _ 
             " Contact_Address , Dis_Rate , Add_Rate , Memo , Dc ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time , Contract_Type_Id " & _ 
             "  ) " & _ 
             " values( @Contract_Code , @Sub_Identity_Code , @Contract_Name , @Is_Use_Set , @Upper_Amt ,  " & _ 
             " @Upper_Amt_Type_Id , @Check_Quota_Id , @Project_Director , @Drug_Code , @Drug_Name ,  " & _ 
             " @Drug_Committee_Sn , @Project_Effect_Date , @Project_End_Date , @Receipt_Title , @Contact_Name ,  " & _ 
             " @Contact_Tel , @Contact_Tel_Mobile , @Contact_Fax , @Contact_Email , @Contact_Postal_Code ,  " & _ 
             " @Contact_Address , @Dis_Rate , @Add_Rate , @Memo , @Dc ,  " & _ 
             " @Create_User , @Create_Time , @Modified_User , @Modified_Time , @Contract_Type_Id " & _ 
             "              )"
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
                        Command.Parameters.AddWithValue("@Contract_Code", row.Item("Contract_Code"))
                        Command.Parameters.AddWithValue("@Sub_Identity_Code", row.Item("Sub_Identity_Code"))
                        Command.Parameters.AddWithValue("@Contract_Name", row.Item("Contract_Name"))
                        Command.Parameters.AddWithValue("@Is_Use_Set", row.Item("Is_Use_Set"))
                        Command.Parameters.AddWithValue("@Upper_Amt", row.Item("Upper_Amt"))
                        Command.Parameters.AddWithValue("@Upper_Amt_Type_Id", row.Item("Upper_Amt_Type_Id"))
                        Command.Parameters.AddWithValue("@Check_Quota_Id", row.Item("Check_Quota_Id"))
                        Command.Parameters.AddWithValue("@Project_Director", row.Item("Project_Director"))
                        Command.Parameters.AddWithValue("@Drug_Code", row.Item("Drug_Code"))
                        Command.Parameters.AddWithValue("@Drug_Name", row.Item("Drug_Name"))
                        Command.Parameters.AddWithValue("@Drug_Committee_Sn", row.Item("Drug_Committee_Sn"))
                        Command.Parameters.AddWithValue("@Project_Effect_Date", row.Item("Project_Effect_Date"))
                        Command.Parameters.AddWithValue("@Project_End_Date", row.Item("Project_End_Date"))
                        Command.Parameters.AddWithValue("@Receipt_Title", row.Item("Receipt_Title"))
                        Command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                        Command.Parameters.AddWithValue("@Contact_Tel", row.Item("Contact_Tel"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Contact_Fax", row.Item("Contact_Fax"))
                        Command.Parameters.AddWithValue("@Contact_Email", row.Item("Contact_Email"))
                        Command.Parameters.AddWithValue("@Contact_Postal_Code", row.Item("Contact_Postal_Code"))
                        Command.Parameters.AddWithValue("@Contact_Address", row.Item("Contact_Address"))
                        Command.Parameters.AddWithValue("@Dis_Rate", row.Item("Dis_Rate"))
                        Command.Parameters.AddWithValue("@Add_Rate", row.Item("Add_Rate"))
                        Command.Parameters.AddWithValue("@Memo", row.Item("Memo"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Contract_Type_Id", row.Item("Contract_Type_Id"))
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
            " Contract_Name=@Contract_Name , Is_Use_Set=@Is_Use_Set , Upper_Amt=@Upper_Amt " & _ 
            "  , Upper_Amt_Type_Id=@Upper_Amt_Type_Id , Check_Quota_Id=@Check_Quota_Id , Project_Director=@Project_Director , Drug_Code=@Drug_Code , Drug_Name=@Drug_Name " & _ 
            "  , Drug_Committee_Sn=@Drug_Committee_Sn , Project_Effect_Date=@Project_Effect_Date , Project_End_Date=@Project_End_Date , Receipt_Title=@Receipt_Title , Contact_Name=@Contact_Name " & _ 
            "  , Contact_Tel=@Contact_Tel , Contact_Tel_Mobile=@Contact_Tel_Mobile , Contact_Fax=@Contact_Fax , Contact_Email=@Contact_Email , Contact_Postal_Code=@Contact_Postal_Code " & _ 
            "  , Contact_Address=@Contact_Address , Dis_Rate=@Dis_Rate , Add_Rate=@Add_Rate , Memo=@Memo , Dc=@Dc " & _ 
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Contract_Type_Id=@Contract_Type_Id " & _ 
            "  " & _ 
            " where  Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code            "
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
                        Command.Parameters.AddWithValue("@Contract_Code", row.Item("Contract_Code"))
                        Command.Parameters.AddWithValue("@Sub_Identity_Code", row.Item("Sub_Identity_Code"))
                        Command.Parameters.AddWithValue("@Contract_Name", row.Item("Contract_Name"))
                        Command.Parameters.AddWithValue("@Is_Use_Set", row.Item("Is_Use_Set"))
                        Command.Parameters.AddWithValue("@Upper_Amt", row.Item("Upper_Amt"))
                        Command.Parameters.AddWithValue("@Upper_Amt_Type_Id", row.Item("Upper_Amt_Type_Id"))
                        Command.Parameters.AddWithValue("@Check_Quota_Id", row.Item("Check_Quota_Id"))
                        Command.Parameters.AddWithValue("@Project_Director", row.Item("Project_Director"))
                        Command.Parameters.AddWithValue("@Drug_Code", row.Item("Drug_Code"))
                        Command.Parameters.AddWithValue("@Drug_Name", row.Item("Drug_Name"))
                        Command.Parameters.AddWithValue("@Drug_Committee_Sn", row.Item("Drug_Committee_Sn"))
                        Command.Parameters.AddWithValue("@Project_Effect_Date", row.Item("Project_Effect_Date"))
                        Command.Parameters.AddWithValue("@Project_End_Date", row.Item("Project_End_Date"))
                        Command.Parameters.AddWithValue("@Receipt_Title", row.Item("Receipt_Title"))
                        Command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                        Command.Parameters.AddWithValue("@Contact_Tel", row.Item("Contact_Tel"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Contact_Fax", row.Item("Contact_Fax"))
                        Command.Parameters.AddWithValue("@Contact_Email", row.Item("Contact_Email"))
                        Command.Parameters.AddWithValue("@Contact_Postal_Code", row.Item("Contact_Postal_Code"))
                        Command.Parameters.AddWithValue("@Contact_Address", row.Item("Contact_Address"))
                        Command.Parameters.AddWithValue("@Dis_Rate", row.Item("Dis_Rate"))
                        Command.Parameters.AddWithValue("@Add_Rate", row.Item("Add_Rate"))
                        Command.Parameters.AddWithValue("@Memo", row.Item("Memo"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Contract_Type_Id", row.Item("Contract_Type_Id"))
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
            " Contract_Name=@Contract_Name , Is_Use_Set=@Is_Use_Set , Upper_Amt=@Upper_Amt " & _ 
            "  , Upper_Amt_Type_Id=@Upper_Amt_Type_Id , Check_Quota_Id=@Check_Quota_Id , Project_Director=@Project_Director , Drug_Code=@Drug_Code , Drug_Name=@Drug_Name " & _ 
            "  , Drug_Committee_Sn=@Drug_Committee_Sn , Project_Effect_Date=@Project_Effect_Date , Project_End_Date=@Project_End_Date , Receipt_Title=@Receipt_Title , Contact_Name=@Contact_Name " & _ 
            "  , Contact_Tel=@Contact_Tel , Contact_Tel_Mobile=@Contact_Tel_Mobile , Contact_Fax=@Contact_Fax , Contact_Email=@Contact_Email , Contact_Postal_Code=@Contact_Postal_Code " & _ 
            "  , Contact_Address=@Contact_Address , Dis_Rate=@Dis_Rate , Add_Rate=@Add_Rate , Memo=@Memo , Dc=@Dc " & _ 
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Contract_Type_Id=@Contract_Type_Id " & _ 
            "  " & _ 
            " where  Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code            "
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
                        Command.Parameters.AddWithValue("@Contract_Code", row.Item("Contract_Code"))
                        Command.Parameters.AddWithValue("@Sub_Identity_Code", row.Item("Sub_Identity_Code"))
                        Command.Parameters.AddWithValue("@Contract_Name", row.Item("Contract_Name"))
                        Command.Parameters.AddWithValue("@Is_Use_Set", row.Item("Is_Use_Set"))
                        Command.Parameters.AddWithValue("@Upper_Amt", row.Item("Upper_Amt"))
                        Command.Parameters.AddWithValue("@Upper_Amt_Type_Id", row.Item("Upper_Amt_Type_Id"))
                        Command.Parameters.AddWithValue("@Check_Quota_Id", row.Item("Check_Quota_Id"))
                        Command.Parameters.AddWithValue("@Project_Director", row.Item("Project_Director"))
                        Command.Parameters.AddWithValue("@Drug_Code", row.Item("Drug_Code"))
                        Command.Parameters.AddWithValue("@Drug_Name", row.Item("Drug_Name"))
                        Command.Parameters.AddWithValue("@Drug_Committee_Sn", row.Item("Drug_Committee_Sn"))
                        Command.Parameters.AddWithValue("@Project_Effect_Date", row.Item("Project_Effect_Date"))
                        Command.Parameters.AddWithValue("@Project_End_Date", row.Item("Project_End_Date"))
                        Command.Parameters.AddWithValue("@Receipt_Title", row.Item("Receipt_Title"))
                        Command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                        Command.Parameters.AddWithValue("@Contact_Tel", row.Item("Contact_Tel"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Contact_Fax", row.Item("Contact_Fax"))
                        Command.Parameters.AddWithValue("@Contact_Email", row.Item("Contact_Email"))
                        Command.Parameters.AddWithValue("@Contact_Postal_Code", row.Item("Contact_Postal_Code"))
                        Command.Parameters.AddWithValue("@Contact_Address", row.Item("Contact_Address"))
                        Command.Parameters.AddWithValue("@Dis_Rate", row.Item("Dis_Rate"))
                        Command.Parameters.AddWithValue("@Add_Rate", row.Item("Add_Rate"))
                        Command.Parameters.AddWithValue("@Memo", row.Item("Memo"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Contract_Type_Id", row.Item("Contract_Type_Id"))
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
            " Contract_Name=@Contract_Name , Is_Use_Set=@Is_Use_Set , Upper_Amt=@Upper_Amt " & _ 
            "  , Upper_Amt_Type_Id=@Upper_Amt_Type_Id , Check_Quota_Id=@Check_Quota_Id , Project_Director=@Project_Director , Drug_Code=@Drug_Code , Drug_Name=@Drug_Name " & _ 
            "  , Drug_Committee_Sn=@Drug_Committee_Sn , Project_Effect_Date=@Project_Effect_Date , Project_End_Date=@Project_End_Date , Receipt_Title=@Receipt_Title , Contact_Name=@Contact_Name " & _ 
            "  , Contact_Tel=@Contact_Tel , Contact_Tel_Mobile=@Contact_Tel_Mobile , Contact_Fax=@Contact_Fax , Contact_Email=@Contact_Email , Contact_Postal_Code=@Contact_Postal_Code " & _ 
            "  , Contact_Address=@Contact_Address , Dis_Rate=@Dis_Rate , Add_Rate=@Add_Rate , Memo=@Memo , Dc=@Dc " & _ 
            "  , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Contract_Type_Id=@Contract_Type_Id " & _ 
            "  " & _ 
            " where  Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code            "
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
                        Command.Parameters.AddWithValue("@Contract_Code", row.Item("Contract_Code"))
                        Command.Parameters.AddWithValue("@Sub_Identity_Code", row.Item("Sub_Identity_Code"))
                        Command.Parameters.AddWithValue("@Contract_Name", row.Item("Contract_Name"))
                        Command.Parameters.AddWithValue("@Is_Use_Set", row.Item("Is_Use_Set"))
                        Command.Parameters.AddWithValue("@Upper_Amt", row.Item("Upper_Amt"))
                        Command.Parameters.AddWithValue("@Upper_Amt_Type_Id", row.Item("Upper_Amt_Type_Id"))
                        Command.Parameters.AddWithValue("@Check_Quota_Id", row.Item("Check_Quota_Id"))
                        Command.Parameters.AddWithValue("@Project_Director", row.Item("Project_Director"))
                        Command.Parameters.AddWithValue("@Drug_Code", row.Item("Drug_Code"))
                        Command.Parameters.AddWithValue("@Drug_Name", row.Item("Drug_Name"))
                        Command.Parameters.AddWithValue("@Drug_Committee_Sn", row.Item("Drug_Committee_Sn"))
                        Command.Parameters.AddWithValue("@Project_Effect_Date", row.Item("Project_Effect_Date"))
                        Command.Parameters.AddWithValue("@Project_End_Date", row.Item("Project_End_Date"))
                        Command.Parameters.AddWithValue("@Receipt_Title", row.Item("Receipt_Title"))
                        Command.Parameters.AddWithValue("@Contact_Name", row.Item("Contact_Name"))
                        Command.Parameters.AddWithValue("@Contact_Tel", row.Item("Contact_Tel"))
                        Command.Parameters.AddWithValue("@Contact_Tel_Mobile", row.Item("Contact_Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Contact_Fax", row.Item("Contact_Fax"))
                        Command.Parameters.AddWithValue("@Contact_Email", row.Item("Contact_Email"))
                        Command.Parameters.AddWithValue("@Contact_Postal_Code", row.Item("Contact_Postal_Code"))
                        Command.Parameters.AddWithValue("@Contact_Address", row.Item("Contact_Address"))
                        Command.Parameters.AddWithValue("@Dis_Rate", row.Item("Dis_Rate"))
                        Command.Parameters.AddWithValue("@Add_Rate", row.Item("Add_Rate"))
                        Command.Parameters.AddWithValue("@Memo", row.Item("Memo"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Contract_Type_Id", row.Item("Contract_Type_Id"))
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
    Public Function delete(ByRef pk_Contract_Code As System.String,ByRef pk_Sub_Identity_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code "
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
                Command.Parameters.AddWithValue("@Contract_Code", pk_Contract_Code)
                Command.Parameters.AddWithValue("@Sub_Identity_Code", pk_Sub_Identity_Code)
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
    Public Function queryByPK(ByRef pk_Contract_Code As System.String,ByRef pk_Sub_Identity_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Contract_Code , Sub_Identity_Code , Contract_Name , Is_Use_Set , Upper_Amt ,  ") 
            content.AppendLine(" Upper_Amt_Type_Id , Check_Quota_Id , Project_Director , Drug_Code , Drug_Name ,  ") 
            content.AppendLine(" Drug_Committee_Sn , Project_Effect_Date , Project_End_Date , Receipt_Title , Contact_Name ,  ") 
            content.AppendLine(" Contact_Tel , Contact_Tel_Mobile , Contact_Fax , Contact_Email , Contact_Postal_Code ,  ") 
            content.AppendLine(" Contact_Address , Dis_Rate , Add_Rate , Memo , Dc ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time , Contract_Type_Id ") 
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where Contract_Code=@Contract_Code and Sub_Identity_Code=@Sub_Identity_Code            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Contract_Code",pk_Contract_Code)
            Command.Parameters.AddWithValue("@Sub_Identity_Code",pk_Sub_Identity_Code)
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
    Public Function queryByLikePK(ByRef pk_Contract_Code As System.String,ByRef pk_Sub_Identity_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Contract_Code , Sub_Identity_Code , Contract_Name , Is_Use_Set , Upper_Amt ,  ") 
            content.AppendLine(" Upper_Amt_Type_Id , Check_Quota_Id , Project_Director , Drug_Code , Drug_Name ,  ") 
            content.AppendLine(" Drug_Committee_Sn , Project_Effect_Date , Project_End_Date , Receipt_Title , Contact_Name ,  ") 
            content.AppendLine(" Contact_Tel , Contact_Tel_Mobile , Contact_Fax , Contact_Email , Contact_Postal_Code ,  ") 
            content.AppendLine(" Contact_Address , Dis_Rate , Add_Rate , Memo , Dc ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time , Contract_Type_Id ") 
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where Contract_Code like @Contract_Code and Sub_Identity_Code like @Sub_Identity_Code "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Contract_Code",pk_Contract_Code & "%")
            Command.Parameters.AddWithValue("@Sub_Identity_Code",pk_Sub_Identity_Code & "%")
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
            content.AppendLine(" Contract_Code , Sub_Identity_Code , Contract_Name , Is_Use_Set , Upper_Amt ,  ") 
            content.AppendLine(" Upper_Amt_Type_Id , Check_Quota_Id , Project_Director , Drug_Code , Drug_Name ,  ") 
            content.AppendLine(" Drug_Committee_Sn , Project_Effect_Date , Project_End_Date , Receipt_Title , Contact_Name ,  ") 
            content.AppendLine(" Contact_Tel , Contact_Tel_Mobile , Contact_Fax , Contact_Email , Contact_Postal_Code ,  ") 
            content.AppendLine(" Contact_Address , Dis_Rate , Add_Rate , Memo , Dc ,  ") 
            content.AppendLine(" Create_User , Create_Time , Modified_User , Modified_Time , Contract_Type_Id ") 
            content.AppendLine("                 from " & tableName )
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
            content.Append("select   Contract_Code , Sub_Identity_Code , Contract_Name , Is_Use_Set , Upper_Amt ,  " & _ 
             " Upper_Amt_Type_Id , Check_Quota_Id , Project_Director , Drug_Code , Drug_Name ,  " & _ 
             " Drug_Committee_Sn , Project_Effect_Date , Project_End_Date , Receipt_Title , Contact_Name ,  " & _ 
             " Contact_Tel , Contact_Tel_Mobile , Contact_Fax , Contact_Email , Contact_Postal_Code ,  " & _ 
             " Contact_Address , Dis_Rate , Add_Rate , Memo , Dc ,  " & _ 
             " Create_User , Create_Time , Modified_User , Modified_Time , Contract_Type_Id " & _ 
             "             from " & tableName & " where 1=1 ")
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
    '''取得表格 PUB_Contract 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Contract 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
