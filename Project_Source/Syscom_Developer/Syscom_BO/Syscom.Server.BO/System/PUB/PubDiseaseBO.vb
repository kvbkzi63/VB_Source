Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Data
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubDiseaseBO
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:48
    Public Shared ReadOnly tableName As String="PUB_Disease"
    Private Shared myInstance As PubDiseaseBO
    Public Shared Function GetInstance() As PubDiseaseBO
        If myInstance Is Nothing Then
            myInstance = New PubDiseaseBO()
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
            " Effect_Date , Icd_Code , Disease_Type_Id , Disease_En_Name , Disease_Name ,  " & _ 
             " Disease_En_Short_Name , Disease_Short_Name , Disease_Hosp_Name , Majorcare_Code , Limit_Sex_Id ,  " & _ 
             " Infection_Type_Id , Limit_Age , Age_Start_Year , Age_Start_Month , Age_Start_Day ,  " & _ 
             " Age_End_Year , Age_End_Month , Age_End_Day , Is_Exclude_Labdiscount , Is_Chronic_Disease ,  " & _ 
             " Is_Severe_Disease , Is_Psy_Severe_Disease , Is_Rare_Diseases , Is_AIDS , Is_Major_P ,  " & _ 
             " Is_Minor_P , Is_Mcc , Is_Cc , Main_Diagnosis_Id , Is_Opd ,  " & _ 
             " Is_Emg , Is_Ipd , Pip_Type_Id , Is_Occ_Injury , Is_Pre5_Diagnosis ,  " & _ 
             " Is_Hem_Original_Disease , Dc , End_Date , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time , Is_Or , Is_Drg ) " & _ 
             " values( @Effect_Date , @Icd_Code , @Disease_Type_Id , @Disease_En_Name , @Disease_Name ,  " & _ 
             " @Disease_En_Short_Name , @Disease_Short_Name , @Disease_Hosp_Name , @Majorcare_Code , @Limit_Sex_Id ,  " & _ 
             " @Infection_Type_Id , @Limit_Age , @Age_Start_Year , @Age_Start_Month , @Age_Start_Day ,  " & _ 
             " @Age_End_Year , @Age_End_Month , @Age_End_Day , @Is_Exclude_Labdiscount , @Is_Chronic_Disease ,  " & _ 
             " @Is_Severe_Disease , @Is_Psy_Severe_Disease , @Is_Rare_Diseases , @Is_AIDS , @Is_Major_P ,  " & _ 
             " @Is_Minor_P , @Is_Mcc , @Is_Cc , @Main_Diagnosis_Id , @Is_Opd ,  " & _ 
             " @Is_Emg , @Is_Ipd , @Pip_Type_Id , @Is_Occ_Injury , @Is_Pre5_Diagnosis ,  " & _ 
             " @Is_Hem_Original_Disease , @Dc , @End_Date , @Create_User , @Create_Time ,  " & _ 
             " @Modified_User , @Modified_Time , @Is_Or , @Is_Drg             )"
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
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Icd_Code", row.Item("Icd_Code"))
                        Command.Parameters.AddWithValue("@Disease_Type_Id", row.Item("Disease_Type_Id"))
                        Command.Parameters.AddWithValue("@Disease_En_Name", row.Item("Disease_En_Name"))
                        Command.Parameters.AddWithValue("@Disease_Name", row.Item("Disease_Name"))
                        Command.Parameters.AddWithValue("@Disease_En_Short_Name", row.Item("Disease_En_Short_Name"))
                        Command.Parameters.AddWithValue("@Disease_Short_Name", row.Item("Disease_Short_Name"))
                        Command.Parameters.AddWithValue("@Disease_Hosp_Name", row.Item("Disease_Hosp_Name"))
                        Command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                        Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                        Command.Parameters.AddWithValue("@Infection_Type_Id", row.Item("Infection_Type_Id"))
                        Command.Parameters.AddWithValue("@Limit_Age", row.Item("Limit_Age"))
                        Command.Parameters.AddWithValue("@Age_Start_Year", row.Item("Age_Start_Year"))
                        Command.Parameters.AddWithValue("@Age_Start_Month", row.Item("Age_Start_Month"))
                        Command.Parameters.AddWithValue("@Age_Start_Day", row.Item("Age_Start_Day"))
                        Command.Parameters.AddWithValue("@Age_End_Year", row.Item("Age_End_Year"))
                        Command.Parameters.AddWithValue("@Age_End_Month", row.Item("Age_End_Month"))
                        Command.Parameters.AddWithValue("@Age_End_Day", row.Item("Age_End_Day"))
                        Command.Parameters.AddWithValue("@Is_Exclude_Labdiscount", row.Item("Is_Exclude_Labdiscount"))
                        Command.Parameters.AddWithValue("@Is_Chronic_Disease", row.Item("Is_Chronic_Disease"))
                        Command.Parameters.AddWithValue("@Is_Severe_Disease", row.Item("Is_Severe_Disease"))
                        Command.Parameters.AddWithValue("@Is_Psy_Severe_Disease", row.Item("Is_Psy_Severe_Disease"))
                        Command.Parameters.AddWithValue("@Is_Rare_Diseases", row.Item("Is_Rare_Diseases"))
                        Command.Parameters.AddWithValue("@Is_AIDS", row.Item("Is_AIDS"))
                        Command.Parameters.AddWithValue("@Is_Major_P", row.Item("Is_Major_P"))
                        Command.Parameters.AddWithValue("@Is_Minor_P", row.Item("Is_Minor_P"))
                        Command.Parameters.AddWithValue("@Is_Mcc", row.Item("Is_Mcc"))
                        Command.Parameters.AddWithValue("@Is_Cc", row.Item("Is_Cc"))
                        Command.Parameters.AddWithValue("@Main_Diagnosis_Id", row.Item("Main_Diagnosis_Id"))
                        Command.Parameters.AddWithValue("@Is_Opd", row.Item("Is_Opd"))
                        Command.Parameters.AddWithValue("@Is_Emg", row.Item("Is_Emg"))
                        Command.Parameters.AddWithValue("@Is_Ipd", row.Item("Is_Ipd"))
                        Command.Parameters.AddWithValue("@Pip_Type_Id", row.Item("Pip_Type_Id"))
                        Command.Parameters.AddWithValue("@Is_Occ_Injury", row.Item("Is_Occ_Injury"))
                        Command.Parameters.AddWithValue("@Is_Pre5_Diagnosis", row.Item("Is_Pre5_Diagnosis"))
                        Command.Parameters.AddWithValue("@Is_Hem_Original_Disease", row.Item("Is_Hem_Original_Disease"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_Or", row.Item("Is_Or"))
                        Command.Parameters.AddWithValue("@Is_Drg", row.Item("Is_Drg"))
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
            " Effect_Date , Icd_Code , Disease_Type_Id , Disease_En_Name , Disease_Name ,  " & _ 
             " Disease_En_Short_Name , Disease_Short_Name , Disease_Hosp_Name , Majorcare_Code , Limit_Sex_Id ,  " & _ 
             " Infection_Type_Id , Limit_Age , Age_Start_Year , Age_Start_Month , Age_Start_Day ,  " & _ 
             " Age_End_Year , Age_End_Month , Age_End_Day , Is_Exclude_Labdiscount , Is_Chronic_Disease ,  " & _ 
             " Is_Severe_Disease , Is_Psy_Severe_Disease , Is_Rare_Diseases , Is_AIDS , Is_Major_P ,  " & _ 
             " Is_Minor_P , Is_Mcc , Is_Cc , Main_Diagnosis_Id , Is_Opd ,  " & _ 
             " Is_Emg , Is_Ipd , Pip_Type_Id , Is_Occ_Injury , Is_Pre5_Diagnosis ,  " & _ 
             " Is_Hem_Original_Disease , Dc , End_Date , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time , Is_Or , Is_Drg ) " & _ 
             " values( @Effect_Date , @Icd_Code , @Disease_Type_Id , @Disease_En_Name , @Disease_Name ,  " & _ 
             " @Disease_En_Short_Name , @Disease_Short_Name , @Disease_Hosp_Name , @Majorcare_Code , @Limit_Sex_Id ,  " & _ 
             " @Infection_Type_Id , @Limit_Age , @Age_Start_Year , @Age_Start_Month , @Age_Start_Day ,  " & _ 
             " @Age_End_Year , @Age_End_Month , @Age_End_Day , @Is_Exclude_Labdiscount , @Is_Chronic_Disease ,  " & _ 
             " @Is_Severe_Disease , @Is_Psy_Severe_Disease , @Is_Rare_Diseases , @Is_AIDS , @Is_Major_P ,  " & _ 
             " @Is_Minor_P , @Is_Mcc , @Is_Cc , @Main_Diagnosis_Id , @Is_Opd ,  " & _ 
             " @Is_Emg , @Is_Ipd , @Pip_Type_Id , @Is_Occ_Injury , @Is_Pre5_Diagnosis ,  " & _ 
             " @Is_Hem_Original_Disease , @Dc , @End_Date , @Create_User , @Create_Time ,  " & _ 
             " @Modified_User , @Modified_Time , @Is_Or , @Is_Drg             )"
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
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Icd_Code", row.Item("Icd_Code"))
                        Command.Parameters.AddWithValue("@Disease_Type_Id", row.Item("Disease_Type_Id"))
                        Command.Parameters.AddWithValue("@Disease_En_Name", row.Item("Disease_En_Name"))
                        Command.Parameters.AddWithValue("@Disease_Name", row.Item("Disease_Name"))
                        Command.Parameters.AddWithValue("@Disease_En_Short_Name", row.Item("Disease_En_Short_Name"))
                        Command.Parameters.AddWithValue("@Disease_Short_Name", row.Item("Disease_Short_Name"))
                        Command.Parameters.AddWithValue("@Disease_Hosp_Name", row.Item("Disease_Hosp_Name"))
                        Command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                        Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                        Command.Parameters.AddWithValue("@Infection_Type_Id", row.Item("Infection_Type_Id"))
                        Command.Parameters.AddWithValue("@Limit_Age", row.Item("Limit_Age"))
                        Command.Parameters.AddWithValue("@Age_Start_Year", row.Item("Age_Start_Year"))
                        Command.Parameters.AddWithValue("@Age_Start_Month", row.Item("Age_Start_Month"))
                        Command.Parameters.AddWithValue("@Age_Start_Day", row.Item("Age_Start_Day"))
                        Command.Parameters.AddWithValue("@Age_End_Year", row.Item("Age_End_Year"))
                        Command.Parameters.AddWithValue("@Age_End_Month", row.Item("Age_End_Month"))
                        Command.Parameters.AddWithValue("@Age_End_Day", row.Item("Age_End_Day"))
                        Command.Parameters.AddWithValue("@Is_Exclude_Labdiscount", row.Item("Is_Exclude_Labdiscount"))
                        Command.Parameters.AddWithValue("@Is_Chronic_Disease", row.Item("Is_Chronic_Disease"))
                        Command.Parameters.AddWithValue("@Is_Severe_Disease", row.Item("Is_Severe_Disease"))
                        Command.Parameters.AddWithValue("@Is_Psy_Severe_Disease", row.Item("Is_Psy_Severe_Disease"))
                        Command.Parameters.AddWithValue("@Is_Rare_Diseases", row.Item("Is_Rare_Diseases"))
                        Command.Parameters.AddWithValue("@Is_AIDS", row.Item("Is_AIDS"))
                        Command.Parameters.AddWithValue("@Is_Major_P", row.Item("Is_Major_P"))
                        Command.Parameters.AddWithValue("@Is_Minor_P", row.Item("Is_Minor_P"))
                        Command.Parameters.AddWithValue("@Is_Mcc", row.Item("Is_Mcc"))
                        Command.Parameters.AddWithValue("@Is_Cc", row.Item("Is_Cc"))
                        Command.Parameters.AddWithValue("@Main_Diagnosis_Id", row.Item("Main_Diagnosis_Id"))
                        Command.Parameters.AddWithValue("@Is_Opd", row.Item("Is_Opd"))
                        Command.Parameters.AddWithValue("@Is_Emg", row.Item("Is_Emg"))
                        Command.Parameters.AddWithValue("@Is_Ipd", row.Item("Is_Ipd"))
                        Command.Parameters.AddWithValue("@Pip_Type_Id", row.Item("Pip_Type_Id"))
                        Command.Parameters.AddWithValue("@Is_Occ_Injury", row.Item("Is_Occ_Injury"))
                        Command.Parameters.AddWithValue("@Is_Pre5_Diagnosis", row.Item("Is_Pre5_Diagnosis"))
                        Command.Parameters.AddWithValue("@Is_Hem_Original_Disease", row.Item("Is_Hem_Original_Disease"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_Or", row.Item("Is_Or"))
                        Command.Parameters.AddWithValue("@Is_Drg", row.Item("Is_Drg"))
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
            " Effect_Date , Icd_Code , Disease_Type_Id , Disease_En_Name , Disease_Name ,  " & _ 
             " Disease_En_Short_Name , Disease_Short_Name , Disease_Hosp_Name , Majorcare_Code , Limit_Sex_Id ,  " & _ 
             " Infection_Type_Id , Limit_Age , Age_Start_Year , Age_Start_Month , Age_Start_Day ,  " & _ 
             " Age_End_Year , Age_End_Month , Age_End_Day , Is_Exclude_Labdiscount , Is_Chronic_Disease ,  " & _ 
             " Is_Severe_Disease , Is_Psy_Severe_Disease , Is_Rare_Diseases , Is_AIDS , Is_Major_P ,  " & _ 
             " Is_Minor_P , Is_Mcc , Is_Cc , Main_Diagnosis_Id , Is_Opd ,  " & _ 
             " Is_Emg , Is_Ipd , Pip_Type_Id , Is_Occ_Injury , Is_Pre5_Diagnosis ,  " & _ 
             " Is_Hem_Original_Disease , Dc , End_Date , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time , Is_Or , Is_Drg ) " & _ 
             " values( @Effect_Date , @Icd_Code , @Disease_Type_Id , @Disease_En_Name , @Disease_Name ,  " & _ 
             " @Disease_En_Short_Name , @Disease_Short_Name , @Disease_Hosp_Name , @Majorcare_Code , @Limit_Sex_Id ,  " & _ 
             " @Infection_Type_Id , @Limit_Age , @Age_Start_Year , @Age_Start_Month , @Age_Start_Day ,  " & _ 
             " @Age_End_Year , @Age_End_Month , @Age_End_Day , @Is_Exclude_Labdiscount , @Is_Chronic_Disease ,  " & _ 
             " @Is_Severe_Disease , @Is_Psy_Severe_Disease , @Is_Rare_Diseases , @Is_AIDS , @Is_Major_P ,  " & _ 
             " @Is_Minor_P , @Is_Mcc , @Is_Cc , @Main_Diagnosis_Id , @Is_Opd ,  " & _ 
             " @Is_Emg , @Is_Ipd , @Pip_Type_Id , @Is_Occ_Injury , @Is_Pre5_Diagnosis ,  " & _ 
             " @Is_Hem_Original_Disease , @Dc , @End_Date , @Create_User , @Create_Time ,  " & _ 
             " @Modified_User , @Modified_Time , @Is_Or , @Is_Drg             )"
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
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Icd_Code", row.Item("Icd_Code"))
                        Command.Parameters.AddWithValue("@Disease_Type_Id", row.Item("Disease_Type_Id"))
                        Command.Parameters.AddWithValue("@Disease_En_Name", row.Item("Disease_En_Name"))
                        Command.Parameters.AddWithValue("@Disease_Name", row.Item("Disease_Name"))
                        Command.Parameters.AddWithValue("@Disease_En_Short_Name", row.Item("Disease_En_Short_Name"))
                        Command.Parameters.AddWithValue("@Disease_Short_Name", row.Item("Disease_Short_Name"))
                        Command.Parameters.AddWithValue("@Disease_Hosp_Name", row.Item("Disease_Hosp_Name"))
                        Command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                        Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                        Command.Parameters.AddWithValue("@Infection_Type_Id", row.Item("Infection_Type_Id"))
                        Command.Parameters.AddWithValue("@Limit_Age", row.Item("Limit_Age"))
                        Command.Parameters.AddWithValue("@Age_Start_Year", row.Item("Age_Start_Year"))
                        Command.Parameters.AddWithValue("@Age_Start_Month", row.Item("Age_Start_Month"))
                        Command.Parameters.AddWithValue("@Age_Start_Day", row.Item("Age_Start_Day"))
                        Command.Parameters.AddWithValue("@Age_End_Year", row.Item("Age_End_Year"))
                        Command.Parameters.AddWithValue("@Age_End_Month", row.Item("Age_End_Month"))
                        Command.Parameters.AddWithValue("@Age_End_Day", row.Item("Age_End_Day"))
                        Command.Parameters.AddWithValue("@Is_Exclude_Labdiscount", row.Item("Is_Exclude_Labdiscount"))
                        Command.Parameters.AddWithValue("@Is_Chronic_Disease", row.Item("Is_Chronic_Disease"))
                        Command.Parameters.AddWithValue("@Is_Severe_Disease", row.Item("Is_Severe_Disease"))
                        Command.Parameters.AddWithValue("@Is_Psy_Severe_Disease", row.Item("Is_Psy_Severe_Disease"))
                        Command.Parameters.AddWithValue("@Is_Rare_Diseases", row.Item("Is_Rare_Diseases"))
                        Command.Parameters.AddWithValue("@Is_AIDS", row.Item("Is_AIDS"))
                        Command.Parameters.AddWithValue("@Is_Major_P", row.Item("Is_Major_P"))
                        Command.Parameters.AddWithValue("@Is_Minor_P", row.Item("Is_Minor_P"))
                        Command.Parameters.AddWithValue("@Is_Mcc", row.Item("Is_Mcc"))
                        Command.Parameters.AddWithValue("@Is_Cc", row.Item("Is_Cc"))
                        Command.Parameters.AddWithValue("@Main_Diagnosis_Id", row.Item("Main_Diagnosis_Id"))
                        Command.Parameters.AddWithValue("@Is_Opd", row.Item("Is_Opd"))
                        Command.Parameters.AddWithValue("@Is_Emg", row.Item("Is_Emg"))
                        Command.Parameters.AddWithValue("@Is_Ipd", row.Item("Is_Ipd"))
                        Command.Parameters.AddWithValue("@Pip_Type_Id", row.Item("Pip_Type_Id"))
                        Command.Parameters.AddWithValue("@Is_Occ_Injury", row.Item("Is_Occ_Injury"))
                        Command.Parameters.AddWithValue("@Is_Pre5_Diagnosis", row.Item("Is_Pre5_Diagnosis"))
                        Command.Parameters.AddWithValue("@Is_Hem_Original_Disease", row.Item("Is_Hem_Original_Disease"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Is_Or", row.Item("Is_Or"))
                        Command.Parameters.AddWithValue("@Is_Drg", row.Item("Is_Drg"))
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
            " Disease_En_Name=@Disease_En_Name , Disease_Name=@Disease_Name " & _ 
            "  , Disease_En_Short_Name=@Disease_En_Short_Name , Disease_Short_Name=@Disease_Short_Name , Disease_Hosp_Name=@Disease_Hosp_Name , Majorcare_Code=@Majorcare_Code , Limit_Sex_Id=@Limit_Sex_Id " & _ 
            "  , Infection_Type_Id=@Infection_Type_Id , Limit_Age=@Limit_Age , Age_Start_Year=@Age_Start_Year , Age_Start_Month=@Age_Start_Month , Age_Start_Day=@Age_Start_Day " & _ 
            "  , Age_End_Year=@Age_End_Year , Age_End_Month=@Age_End_Month , Age_End_Day=@Age_End_Day , Is_Exclude_Labdiscount=@Is_Exclude_Labdiscount , Is_Chronic_Disease=@Is_Chronic_Disease " & _ 
            "  , Is_Severe_Disease=@Is_Severe_Disease , Is_Psy_Severe_Disease=@Is_Psy_Severe_Disease , Is_Rare_Diseases=@Is_Rare_Diseases , Is_AIDS=@Is_AIDS , Is_Major_P=@Is_Major_P " & _ 
            "  , Is_Minor_P=@Is_Minor_P , Is_Mcc=@Is_Mcc , Is_Cc=@Is_Cc , Main_Diagnosis_Id=@Main_Diagnosis_Id , Is_Opd=@Is_Opd " & _ 
            "  , Is_Emg=@Is_Emg , Is_Ipd=@Is_Ipd , Pip_Type_Id=@Pip_Type_Id , Is_Occ_Injury=@Is_Occ_Injury , Is_Pre5_Diagnosis=@Is_Pre5_Diagnosis " & _ 
            "  , Is_Hem_Original_Disease=@Is_Hem_Original_Disease , Dc=@Dc , End_Date=@End_Date , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_Or=@Is_Or , Is_Drg=@Is_Drg " & _ 
            " where  Effect_Date=@Effect_Date and Icd_Code=@Icd_Code and Disease_Type_Id=@Disease_Type_Id            "
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
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Icd_Code", row.Item("Icd_Code"))
                        Command.Parameters.AddWithValue("@Disease_Type_Id", row.Item("Disease_Type_Id"))
                        Command.Parameters.AddWithValue("@Disease_En_Name", row.Item("Disease_En_Name"))
                        Command.Parameters.AddWithValue("@Disease_Name", row.Item("Disease_Name"))
                        Command.Parameters.AddWithValue("@Disease_En_Short_Name", row.Item("Disease_En_Short_Name"))
                        Command.Parameters.AddWithValue("@Disease_Short_Name", row.Item("Disease_Short_Name"))
                        Command.Parameters.AddWithValue("@Disease_Hosp_Name", row.Item("Disease_Hosp_Name"))
                        Command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                        Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                        Command.Parameters.AddWithValue("@Infection_Type_Id", row.Item("Infection_Type_Id"))
                        Command.Parameters.AddWithValue("@Limit_Age", row.Item("Limit_Age"))
                        Command.Parameters.AddWithValue("@Age_Start_Year", row.Item("Age_Start_Year"))
                        Command.Parameters.AddWithValue("@Age_Start_Month", row.Item("Age_Start_Month"))
                        Command.Parameters.AddWithValue("@Age_Start_Day", row.Item("Age_Start_Day"))
                        Command.Parameters.AddWithValue("@Age_End_Year", row.Item("Age_End_Year"))
                        Command.Parameters.AddWithValue("@Age_End_Month", row.Item("Age_End_Month"))
                        Command.Parameters.AddWithValue("@Age_End_Day", row.Item("Age_End_Day"))
                        Command.Parameters.AddWithValue("@Is_Exclude_Labdiscount", row.Item("Is_Exclude_Labdiscount"))
                        Command.Parameters.AddWithValue("@Is_Chronic_Disease", row.Item("Is_Chronic_Disease"))
                        Command.Parameters.AddWithValue("@Is_Severe_Disease", row.Item("Is_Severe_Disease"))
                        Command.Parameters.AddWithValue("@Is_Psy_Severe_Disease", row.Item("Is_Psy_Severe_Disease"))
                        Command.Parameters.AddWithValue("@Is_Rare_Diseases", row.Item("Is_Rare_Diseases"))
                        Command.Parameters.AddWithValue("@Is_AIDS", row.Item("Is_AIDS"))
                        Command.Parameters.AddWithValue("@Is_Major_P", row.Item("Is_Major_P"))
                        Command.Parameters.AddWithValue("@Is_Minor_P", row.Item("Is_Minor_P"))
                        Command.Parameters.AddWithValue("@Is_Mcc", row.Item("Is_Mcc"))
                        Command.Parameters.AddWithValue("@Is_Cc", row.Item("Is_Cc"))
                        Command.Parameters.AddWithValue("@Main_Diagnosis_Id", row.Item("Main_Diagnosis_Id"))
                        Command.Parameters.AddWithValue("@Is_Opd", row.Item("Is_Opd"))
                        Command.Parameters.AddWithValue("@Is_Emg", row.Item("Is_Emg"))
                        Command.Parameters.AddWithValue("@Is_Ipd", row.Item("Is_Ipd"))
                        Command.Parameters.AddWithValue("@Pip_Type_Id", row.Item("Pip_Type_Id"))
                        Command.Parameters.AddWithValue("@Is_Occ_Injury", row.Item("Is_Occ_Injury"))
                        Command.Parameters.AddWithValue("@Is_Pre5_Diagnosis", row.Item("Is_Pre5_Diagnosis"))
                        Command.Parameters.AddWithValue("@Is_Hem_Original_Disease", row.Item("Is_Hem_Original_Disease"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_Or", row.Item("Is_Or"))
                        Command.Parameters.AddWithValue("@Is_Drg", row.Item("Is_Drg"))
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
            " Disease_En_Name=@Disease_En_Name , Disease_Name=@Disease_Name " & _ 
            "  , Disease_En_Short_Name=@Disease_En_Short_Name , Disease_Short_Name=@Disease_Short_Name , Disease_Hosp_Name=@Disease_Hosp_Name , Majorcare_Code=@Majorcare_Code , Limit_Sex_Id=@Limit_Sex_Id " & _ 
            "  , Infection_Type_Id=@Infection_Type_Id , Limit_Age=@Limit_Age , Age_Start_Year=@Age_Start_Year , Age_Start_Month=@Age_Start_Month , Age_Start_Day=@Age_Start_Day " & _ 
            "  , Age_End_Year=@Age_End_Year , Age_End_Month=@Age_End_Month , Age_End_Day=@Age_End_Day , Is_Exclude_Labdiscount=@Is_Exclude_Labdiscount , Is_Chronic_Disease=@Is_Chronic_Disease " & _ 
            "  , Is_Severe_Disease=@Is_Severe_Disease , Is_Psy_Severe_Disease=@Is_Psy_Severe_Disease , Is_Rare_Diseases=@Is_Rare_Diseases , Is_AIDS=@Is_AIDS , Is_Major_P=@Is_Major_P " & _ 
            "  , Is_Minor_P=@Is_Minor_P , Is_Mcc=@Is_Mcc , Is_Cc=@Is_Cc , Main_Diagnosis_Id=@Main_Diagnosis_Id , Is_Opd=@Is_Opd " & _ 
            "  , Is_Emg=@Is_Emg , Is_Ipd=@Is_Ipd , Pip_Type_Id=@Pip_Type_Id , Is_Occ_Injury=@Is_Occ_Injury , Is_Pre5_Diagnosis=@Is_Pre5_Diagnosis " & _ 
            "  , Is_Hem_Original_Disease=@Is_Hem_Original_Disease , Dc=@Dc , End_Date=@End_Date , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_Or=@Is_Or , Is_Drg=@Is_Drg " & _ 
            " where  Effect_Date=@Effect_Date and Icd_Code=@Icd_Code and Disease_Type_Id=@Disease_Type_Id            "
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
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Icd_Code", row.Item("Icd_Code"))
                        Command.Parameters.AddWithValue("@Disease_Type_Id", row.Item("Disease_Type_Id"))
                        Command.Parameters.AddWithValue("@Disease_En_Name", row.Item("Disease_En_Name"))
                        Command.Parameters.AddWithValue("@Disease_Name", row.Item("Disease_Name"))
                        Command.Parameters.AddWithValue("@Disease_En_Short_Name", row.Item("Disease_En_Short_Name"))
                        Command.Parameters.AddWithValue("@Disease_Short_Name", row.Item("Disease_Short_Name"))
                        Command.Parameters.AddWithValue("@Disease_Hosp_Name", row.Item("Disease_Hosp_Name"))
                        Command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                        Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                        Command.Parameters.AddWithValue("@Infection_Type_Id", row.Item("Infection_Type_Id"))
                        Command.Parameters.AddWithValue("@Limit_Age", row.Item("Limit_Age"))
                        Command.Parameters.AddWithValue("@Age_Start_Year", row.Item("Age_Start_Year"))
                        Command.Parameters.AddWithValue("@Age_Start_Month", row.Item("Age_Start_Month"))
                        Command.Parameters.AddWithValue("@Age_Start_Day", row.Item("Age_Start_Day"))
                        Command.Parameters.AddWithValue("@Age_End_Year", row.Item("Age_End_Year"))
                        Command.Parameters.AddWithValue("@Age_End_Month", row.Item("Age_End_Month"))
                        Command.Parameters.AddWithValue("@Age_End_Day", row.Item("Age_End_Day"))
                        Command.Parameters.AddWithValue("@Is_Exclude_Labdiscount", row.Item("Is_Exclude_Labdiscount"))
                        Command.Parameters.AddWithValue("@Is_Chronic_Disease", row.Item("Is_Chronic_Disease"))
                        Command.Parameters.AddWithValue("@Is_Severe_Disease", row.Item("Is_Severe_Disease"))
                        Command.Parameters.AddWithValue("@Is_Psy_Severe_Disease", row.Item("Is_Psy_Severe_Disease"))
                        Command.Parameters.AddWithValue("@Is_Rare_Diseases", row.Item("Is_Rare_Diseases"))
                        Command.Parameters.AddWithValue("@Is_AIDS", row.Item("Is_AIDS"))
                        Command.Parameters.AddWithValue("@Is_Major_P", row.Item("Is_Major_P"))
                        Command.Parameters.AddWithValue("@Is_Minor_P", row.Item("Is_Minor_P"))
                        Command.Parameters.AddWithValue("@Is_Mcc", row.Item("Is_Mcc"))
                        Command.Parameters.AddWithValue("@Is_Cc", row.Item("Is_Cc"))
                        Command.Parameters.AddWithValue("@Main_Diagnosis_Id", row.Item("Main_Diagnosis_Id"))
                        Command.Parameters.AddWithValue("@Is_Opd", row.Item("Is_Opd"))
                        Command.Parameters.AddWithValue("@Is_Emg", row.Item("Is_Emg"))
                        Command.Parameters.AddWithValue("@Is_Ipd", row.Item("Is_Ipd"))
                        Command.Parameters.AddWithValue("@Pip_Type_Id", row.Item("Pip_Type_Id"))
                        Command.Parameters.AddWithValue("@Is_Occ_Injury", row.Item("Is_Occ_Injury"))
                        Command.Parameters.AddWithValue("@Is_Pre5_Diagnosis", row.Item("Is_Pre5_Diagnosis"))
                        Command.Parameters.AddWithValue("@Is_Hem_Original_Disease", row.Item("Is_Hem_Original_Disease"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Is_Or", row.Item("Is_Or"))
                        Command.Parameters.AddWithValue("@Is_Drg", row.Item("Is_Drg"))
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
            " Disease_En_Name=@Disease_En_Name , Disease_Name=@Disease_Name " & _ 
            "  , Disease_En_Short_Name=@Disease_En_Short_Name , Disease_Short_Name=@Disease_Short_Name , Disease_Hosp_Name=@Disease_Hosp_Name , Majorcare_Code=@Majorcare_Code , Limit_Sex_Id=@Limit_Sex_Id " & _ 
            "  , Infection_Type_Id=@Infection_Type_Id , Limit_Age=@Limit_Age , Age_Start_Year=@Age_Start_Year , Age_Start_Month=@Age_Start_Month , Age_Start_Day=@Age_Start_Day " & _ 
            "  , Age_End_Year=@Age_End_Year , Age_End_Month=@Age_End_Month , Age_End_Day=@Age_End_Day , Is_Exclude_Labdiscount=@Is_Exclude_Labdiscount , Is_Chronic_Disease=@Is_Chronic_Disease " & _ 
            "  , Is_Severe_Disease=@Is_Severe_Disease , Is_Psy_Severe_Disease=@Is_Psy_Severe_Disease , Is_Rare_Diseases=@Is_Rare_Diseases , Is_AIDS=@Is_AIDS , Is_Major_P=@Is_Major_P " & _ 
            "  , Is_Minor_P=@Is_Minor_P , Is_Mcc=@Is_Mcc , Is_Cc=@Is_Cc , Main_Diagnosis_Id=@Main_Diagnosis_Id , Is_Opd=@Is_Opd " & _ 
            "  , Is_Emg=@Is_Emg , Is_Ipd=@Is_Ipd , Pip_Type_Id=@Pip_Type_Id , Is_Occ_Injury=@Is_Occ_Injury , Is_Pre5_Diagnosis=@Is_Pre5_Diagnosis " & _ 
            "  , Is_Hem_Original_Disease=@Is_Hem_Original_Disease , Dc=@Dc , End_Date=@End_Date , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_Or=@Is_Or , Is_Drg=@Is_Drg " & _ 
            " where  Effect_Date=@Effect_Date and Icd_Code=@Icd_Code and Disease_Type_Id=@Disease_Type_Id            "
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
                        Command.Parameters.AddWithValue("@Effect_Date", row.Item("Effect_Date"))
                        Command.Parameters.AddWithValue("@Icd_Code", row.Item("Icd_Code"))
                        Command.Parameters.AddWithValue("@Disease_Type_Id", row.Item("Disease_Type_Id"))
                        Command.Parameters.AddWithValue("@Disease_En_Name", row.Item("Disease_En_Name"))
                        Command.Parameters.AddWithValue("@Disease_Name", row.Item("Disease_Name"))
                        Command.Parameters.AddWithValue("@Disease_En_Short_Name", row.Item("Disease_En_Short_Name"))
                        Command.Parameters.AddWithValue("@Disease_Short_Name", row.Item("Disease_Short_Name"))
                        Command.Parameters.AddWithValue("@Disease_Hosp_Name", row.Item("Disease_Hosp_Name"))
                        Command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                        Command.Parameters.AddWithValue("@Limit_Sex_Id", row.Item("Limit_Sex_Id"))
                        Command.Parameters.AddWithValue("@Infection_Type_Id", row.Item("Infection_Type_Id"))
                        Command.Parameters.AddWithValue("@Limit_Age", row.Item("Limit_Age"))
                        Command.Parameters.AddWithValue("@Age_Start_Year", row.Item("Age_Start_Year"))
                        Command.Parameters.AddWithValue("@Age_Start_Month", row.Item("Age_Start_Month"))
                        Command.Parameters.AddWithValue("@Age_Start_Day", row.Item("Age_Start_Day"))
                        Command.Parameters.AddWithValue("@Age_End_Year", row.Item("Age_End_Year"))
                        Command.Parameters.AddWithValue("@Age_End_Month", row.Item("Age_End_Month"))
                        Command.Parameters.AddWithValue("@Age_End_Day", row.Item("Age_End_Day"))
                        Command.Parameters.AddWithValue("@Is_Exclude_Labdiscount", row.Item("Is_Exclude_Labdiscount"))
                        Command.Parameters.AddWithValue("@Is_Chronic_Disease", row.Item("Is_Chronic_Disease"))
                        Command.Parameters.AddWithValue("@Is_Severe_Disease", row.Item("Is_Severe_Disease"))
                        Command.Parameters.AddWithValue("@Is_Psy_Severe_Disease", row.Item("Is_Psy_Severe_Disease"))
                        Command.Parameters.AddWithValue("@Is_Rare_Diseases", row.Item("Is_Rare_Diseases"))
                        Command.Parameters.AddWithValue("@Is_AIDS", row.Item("Is_AIDS"))
                        Command.Parameters.AddWithValue("@Is_Major_P", row.Item("Is_Major_P"))
                        Command.Parameters.AddWithValue("@Is_Minor_P", row.Item("Is_Minor_P"))
                        Command.Parameters.AddWithValue("@Is_Mcc", row.Item("Is_Mcc"))
                        Command.Parameters.AddWithValue("@Is_Cc", row.Item("Is_Cc"))
                        Command.Parameters.AddWithValue("@Main_Diagnosis_Id", row.Item("Main_Diagnosis_Id"))
                        Command.Parameters.AddWithValue("@Is_Opd", row.Item("Is_Opd"))
                        Command.Parameters.AddWithValue("@Is_Emg", row.Item("Is_Emg"))
                        Command.Parameters.AddWithValue("@Is_Ipd", row.Item("Is_Ipd"))
                        Command.Parameters.AddWithValue("@Pip_Type_Id", row.Item("Pip_Type_Id"))
                        Command.Parameters.AddWithValue("@Is_Occ_Injury", row.Item("Is_Occ_Injury"))
                        Command.Parameters.AddWithValue("@Is_Pre5_Diagnosis", row.Item("Is_Pre5_Diagnosis"))
                        Command.Parameters.AddWithValue("@Is_Hem_Original_Disease", row.Item("Is_Hem_Original_Disease"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_Or", row.Item("Is_Or"))
                        Command.Parameters.AddWithValue("@Is_Drg", row.Item("Is_Drg"))
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
    Public Function delete(ByRef pk_Effect_Date As System.DateTime,ByRef pk_Icd_Code As System.String,ByRef pk_Disease_Type_Id As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Effect_Date=@Effect_Date and Icd_Code=@Icd_Code and Disease_Type_Id=@Disease_Type_Id "
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
                Command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
                Command.Parameters.AddWithValue("@Icd_Code", pk_Icd_Code)
                Command.Parameters.AddWithValue("@Disease_Type_Id", pk_Disease_Type_Id)
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
    Public Function queryByPK(ByRef pk_Effect_Date As System.DateTime,ByRef pk_Icd_Code As System.String,ByRef pk_Disease_Type_Id As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Effect_Date , Icd_Code , Disease_Type_Id , Disease_En_Name , Disease_Name ,  ") 
            content.AppendLine(" Disease_En_Short_Name , Disease_Short_Name , Disease_Hosp_Name , Majorcare_Code , Limit_Sex_Id ,  ") 
            content.AppendLine(" Infection_Type_Id , Limit_Age , Age_Start_Year , Age_Start_Month , Age_Start_Day ,  ") 
            content.AppendLine(" Age_End_Year , Age_End_Month , Age_End_Day , Is_Exclude_Labdiscount , Is_Chronic_Disease ,  ") 
            content.AppendLine(" Is_Severe_Disease , Is_Psy_Severe_Disease , Is_Rare_Diseases , Is_AIDS , Is_Major_P ,  ") 
            content.AppendLine(" Is_Minor_P , Is_Mcc , Is_Cc , Main_Diagnosis_Id , Is_Opd ,  ") 
            content.AppendLine(" Is_Emg , Is_Ipd , Pip_Type_Id , Is_Occ_Injury , Is_Pre5_Diagnosis ,  ") 
            content.AppendLine(" Is_Hem_Original_Disease , Dc , End_Date , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time , Is_Or , Is_Drg                from " & tableName)
            content.AppendLine("   where Effect_Date=@Effect_Date and Icd_Code=@Icd_Code and Disease_Type_Id=@Disease_Type_Id            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Effect_Date",pk_Effect_Date)
            Command.Parameters.AddWithValue("@Icd_Code",pk_Icd_Code)
            Command.Parameters.AddWithValue("@Disease_Type_Id",pk_Disease_Type_Id)
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
    Public Function queryByLikePK(ByRef pk_Effect_Date As System.DateTime,ByRef pk_Icd_Code As System.String,ByRef pk_Disease_Type_Id As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Effect_Date , Icd_Code , Disease_Type_Id , Disease_En_Name , Disease_Name ,  ") 
            content.AppendLine(" Disease_En_Short_Name , Disease_Short_Name , Disease_Hosp_Name , Majorcare_Code , Limit_Sex_Id ,  ") 
            content.AppendLine(" Infection_Type_Id , Limit_Age , Age_Start_Year , Age_Start_Month , Age_Start_Day ,  ") 
            content.AppendLine(" Age_End_Year , Age_End_Month , Age_End_Day , Is_Exclude_Labdiscount , Is_Chronic_Disease ,  ") 
            content.AppendLine(" Is_Severe_Disease , Is_Psy_Severe_Disease , Is_Rare_Diseases , Is_AIDS , Is_Major_P ,  ") 
            content.AppendLine(" Is_Minor_P , Is_Mcc , Is_Cc , Main_Diagnosis_Id , Is_Opd ,  ") 
            content.AppendLine(" Is_Emg , Is_Ipd , Pip_Type_Id , Is_Occ_Injury , Is_Pre5_Diagnosis ,  ") 
            content.AppendLine(" Is_Hem_Original_Disease , Dc , End_Date , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time , Is_Or , Is_Drg                from " & tableName)
            content.AppendLine("   where Effect_Date like @Effect_Date and Icd_Code like @Icd_Code and Disease_Type_Id like @Disease_Type_Id "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Effect_Date",pk_Effect_Date & "%")
            Command.Parameters.AddWithValue("@Icd_Code",pk_Icd_Code & "%")
            Command.Parameters.AddWithValue("@Disease_Type_Id",pk_Disease_Type_Id & "%")
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
            content.AppendLine(" Effect_Date , Icd_Code , Disease_Type_Id , Disease_En_Name , Disease_Name ,  ") 
            content.AppendLine(" Disease_En_Short_Name , Disease_Short_Name , Disease_Hosp_Name , Majorcare_Code , Limit_Sex_Id ,  ") 
            content.AppendLine(" Infection_Type_Id , Limit_Age , Age_Start_Year , Age_Start_Month , Age_Start_Day ,  ") 
            content.AppendLine(" Age_End_Year , Age_End_Month , Age_End_Day , Is_Exclude_Labdiscount , Is_Chronic_Disease ,  ") 
            content.AppendLine(" Is_Severe_Disease , Is_Psy_Severe_Disease , Is_Rare_Diseases , Is_AIDS , Is_Major_P ,  ") 
            content.AppendLine(" Is_Minor_P , Is_Mcc , Is_Cc , Main_Diagnosis_Id , Is_Opd ,  ") 
            content.AppendLine(" Is_Emg , Is_Ipd , Pip_Type_Id , Is_Occ_Injury , Is_Pre5_Diagnosis ,  ") 
            content.AppendLine(" Is_Hem_Original_Disease , Dc , End_Date , Create_User , Create_Time ,  ") 
            content.AppendLine(" Modified_User , Modified_Time , Is_Or , Is_Drg                from " & tableName )
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
            content.Append("select   Effect_Date , Icd_Code , Disease_Type_Id , Disease_En_Name , Disease_Name ,  " & _ 
             " Disease_En_Short_Name , Disease_Short_Name , Disease_Hosp_Name , Majorcare_Code , Limit_Sex_Id ,  " & _ 
             " Infection_Type_Id , Limit_Age , Age_Start_Year , Age_Start_Month , Age_Start_Day ,  " & _ 
             " Age_End_Year , Age_End_Month , Age_End_Day , Is_Exclude_Labdiscount , Is_Chronic_Disease ,  " & _ 
             " Is_Severe_Disease , Is_Psy_Severe_Disease , Is_Rare_Diseases , Is_AIDS , Is_Major_P ,  " & _ 
             " Is_Minor_P , Is_Mcc , Is_Cc , Main_Diagnosis_Id , Is_Opd ,  " & _ 
             " Is_Emg , Is_Ipd , Pip_Type_Id , Is_Occ_Injury , Is_Pre5_Diagnosis ,  " & _ 
             " Is_Hem_Original_Disease , Dc , End_Date , Create_User , Create_Time ,  " & _ 
             " Modified_User , Modified_Time , Is_Or , Is_Drg            from " & tableName & " where 1=1 ")
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
    '''取得表格 PUB_Disease 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Disease 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
