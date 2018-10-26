Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Reflection
Imports System.Data
Imports System.Diagnostics
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubPatientBO
   Inherits Syscom.Comm.LOG.LOGDelegate
    'Syscom's CodeGen Produced This VB Code @ 2017/2/15 下午 05:35:11
    Public Shared ReadOnly tableName As String="PUB_Patient"
    Private Shared myInstance As PubPatientBO
    Public Shared Function GetInstance() As PubPatientBO
        If myInstance Is Nothing Then
            myInstance = New PubPatientBO()
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
            " Chart_No , Patient_Name , Patient_En_Name , Idno_Type_Id , Idno ,  " & _ 
             " Birth_Date , Sex_Id , Blood_Type_Id , Education_Id , Marriage_Id ,  " & _ 
             " Job_Id , Nationality_Id , Race_Id , Area_Code , Register_Postal_Code ,  " & _ 
             " Register_Address , Postal_Code , Address , Tel_Home , Tel_Office ,  " & _ 
             " Tel_Mobile , Fax , Email , Postal_Code2 , Address2 ,  " & _ 
             " Tel2 , Tel2_Mobile , Email2 , First_Visit_Date , Latest_Visit_Date ,  " & _ 
             " Latest_Admission_Date , Latest_Discharge_Date , Ipd_Times , Latest_Xray_Date , Latest_CT_Date ,  " & _ 
             " Arrears_Times , Opd_Arrears_Amt , Emg_Arrears_Amt , Ipd_Arrears_Amt , Measure_Time ,  " & _ 
             " Latest_Height , Latest_Weight , Mis_Register_Date1 , Mis_Register_Date2 , Mis_Register_Date3 ,  " & _ 
             " Mis_Register_Times , Mis_Register_End_Date , Is_Death , Death_Time , Is_Chart_Divide ,  " & _ 
             " Is_Chart_Image , Patient_Memo , Is_Employee , Reserve_Chart_No , Latest_LMP_Date ,  " & _ 
             " LIS_Blood_Report , LIS_Blood_Report_Time , LIS_BMT_Mark , Student_Id , Create_User ,  " & _ 
             " Create_Time , Modified_User , Modified_Time , Is_IPD , Is_EMG ,  " & _ 
             " Patient_Short_Name , Reg_Notify_Id , Register_Dist_Code , Register_Vil_Code , Dist_Code ,  " & _ 
             " Vil_Code , Dist_Code2 , Vil_Code2 , Not_Scrap , Chart_No_Int ,  " & _ 
             " Info_Confirm ) " & _ 
             " values( @Chart_No , @Patient_Name , @Patient_En_Name , @Idno_Type_Id , @Idno ,  " & _ 
             " @Birth_Date , @Sex_Id , @Blood_Type_Id , @Education_Id , @Marriage_Id ,  " & _ 
             " @Job_Id , @Nationality_Id , @Race_Id , @Area_Code , @Register_Postal_Code ,  " & _ 
             " @Register_Address , @Postal_Code , @Address , @Tel_Home , @Tel_Office ,  " & _ 
             " @Tel_Mobile , @Fax , @Email , @Postal_Code2 , @Address2 ,  " & _ 
             " @Tel2 , @Tel2_Mobile , @Email2 , @First_Visit_Date , @Latest_Visit_Date ,  " & _ 
             " @Latest_Admission_Date , @Latest_Discharge_Date , @Ipd_Times , @Latest_Xray_Date , @Latest_CT_Date ,  " & _ 
             " @Arrears_Times , @Opd_Arrears_Amt , @Emg_Arrears_Amt , @Ipd_Arrears_Amt , @Measure_Time ,  " & _ 
             " @Latest_Height , @Latest_Weight , @Mis_Register_Date1 , @Mis_Register_Date2 , @Mis_Register_Date3 ,  " & _ 
             " @Mis_Register_Times , @Mis_Register_End_Date , @Is_Death , @Death_Time , @Is_Chart_Divide ,  " & _ 
             " @Is_Chart_Image , @Patient_Memo , @Is_Employee , @Reserve_Chart_No , @Latest_LMP_Date ,  " & _ 
             " @LIS_Blood_Report , @LIS_Blood_Report_Time , @LIS_BMT_Mark , @Student_Id , @Create_User ,  " & _ 
             " @Create_Time , @Modified_User , @Modified_Time , @Is_IPD , @Is_EMG ,  " & _ 
             " @Patient_Short_Name , @Reg_Notify_Id , @Register_Dist_Code , @Register_Vil_Code , @Dist_Code ,  " & _ 
             " @Vil_Code , @Dist_Code2 , @Vil_Code2 , @Not_Scrap , @Chart_No_Int ,  " & _ 
             " @Info_Confirm             )"
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Patient_Name", row.Item("Patient_Name"))
                        Command.Parameters.AddWithValue("@Patient_En_Name", row.Item("Patient_En_Name"))
                        Command.Parameters.AddWithValue("@Idno_Type_Id", row.Item("Idno_Type_Id"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        Command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                        Command.Parameters.AddWithValue("@Blood_Type_Id", row.Item("Blood_Type_Id"))
                        Command.Parameters.AddWithValue("@Education_Id", row.Item("Education_Id"))
                        Command.Parameters.AddWithValue("@Marriage_Id", row.Item("Marriage_Id"))
                        Command.Parameters.AddWithValue("@Job_Id", row.Item("Job_Id"))
                        Command.Parameters.AddWithValue("@Nationality_Id", row.Item("Nationality_Id"))
                        Command.Parameters.AddWithValue("@Race_Id", row.Item("Race_Id"))
                        Command.Parameters.AddWithValue("@Area_Code", row.Item("Area_Code"))
                        Command.Parameters.AddWithValue("@Register_Postal_Code", row.Item("Register_Postal_Code"))
                        Command.Parameters.AddWithValue("@Register_Address", row.Item("Register_Address"))
                        Command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                        Command.Parameters.AddWithValue("@Address", row.Item("Address"))
                        Command.Parameters.AddWithValue("@Tel_Home", row.Item("Tel_Home"))
                        Command.Parameters.AddWithValue("@Tel_Office", row.Item("Tel_Office"))
                        Command.Parameters.AddWithValue("@Tel_Mobile", row.Item("Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Fax", row.Item("Fax"))
                        Command.Parameters.AddWithValue("@Email", row.Item("Email"))
                        Command.Parameters.AddWithValue("@Postal_Code2", row.Item("Postal_Code2"))
                        Command.Parameters.AddWithValue("@Address2", row.Item("Address2"))
                        Command.Parameters.AddWithValue("@Tel2", row.Item("Tel2"))
                        Command.Parameters.AddWithValue("@Tel2_Mobile", row.Item("Tel2_Mobile"))
                        Command.Parameters.AddWithValue("@Email2", row.Item("Email2"))
                        Command.Parameters.AddWithValue("@First_Visit_Date", row.Item("First_Visit_Date"))
                        Command.Parameters.AddWithValue("@Latest_Visit_Date", row.Item("Latest_Visit_Date"))
                        Command.Parameters.AddWithValue("@Latest_Admission_Date", row.Item("Latest_Admission_Date"))
                        Command.Parameters.AddWithValue("@Latest_Discharge_Date", row.Item("Latest_Discharge_Date"))
                        Command.Parameters.AddWithValue("@Ipd_Times", row.Item("Ipd_Times"))
                        Command.Parameters.AddWithValue("@Latest_Xray_Date", row.Item("Latest_Xray_Date"))
                        Command.Parameters.AddWithValue("@Latest_CT_Date", row.Item("Latest_CT_Date"))
                        Command.Parameters.AddWithValue("@Arrears_Times", row.Item("Arrears_Times"))
                        Command.Parameters.AddWithValue("@Opd_Arrears_Amt", row.Item("Opd_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Emg_Arrears_Amt", row.Item("Emg_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Ipd_Arrears_Amt", row.Item("Ipd_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Measure_Time", row.Item("Measure_Time"))
                        Command.Parameters.AddWithValue("@Latest_Height", row.Item("Latest_Height"))
                        Command.Parameters.AddWithValue("@Latest_Weight", row.Item("Latest_Weight"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date1", row.Item("Mis_Register_Date1"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date2", row.Item("Mis_Register_Date2"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date3", row.Item("Mis_Register_Date3"))
                        Command.Parameters.AddWithValue("@Mis_Register_Times", row.Item("Mis_Register_Times"))
                        Command.Parameters.AddWithValue("@Mis_Register_End_Date", row.Item("Mis_Register_End_Date"))
                        Command.Parameters.AddWithValue("@Is_Death", row.Item("Is_Death"))
                        Command.Parameters.AddWithValue("@Death_Time", row.Item("Death_Time"))
                        Command.Parameters.AddWithValue("@Is_Chart_Divide", row.Item("Is_Chart_Divide"))
                        Command.Parameters.AddWithValue("@Is_Chart_Image", row.Item("Is_Chart_Image"))
                        Command.Parameters.AddWithValue("@Patient_Memo", row.Item("Patient_Memo"))
                        Command.Parameters.AddWithValue("@Is_Employee", row.Item("Is_Employee"))
                        Command.Parameters.AddWithValue("@Reserve_Chart_No", row.Item("Reserve_Chart_No"))
                        Command.Parameters.AddWithValue("@Latest_LMP_Date", row.Item("Latest_LMP_Date"))
                        Command.Parameters.AddWithValue("@LIS_Blood_Report", row.Item("LIS_Blood_Report"))
                        Command.Parameters.AddWithValue("@LIS_Blood_Report_Time", row.Item("LIS_Blood_Report_Time"))
                        Command.Parameters.AddWithValue("@LIS_BMT_Mark", row.Item("LIS_BMT_Mark"))
                        Command.Parameters.AddWithValue("@Student_Id", row.Item("Student_Id"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_IPD", row.Item("Is_IPD"))
                        Command.Parameters.AddWithValue("@Is_EMG", row.Item("Is_EMG"))
                        Command.Parameters.AddWithValue("@Patient_Short_Name", row.Item("Patient_Short_Name"))
                        Command.Parameters.AddWithValue("@Reg_Notify_Id", row.Item("Reg_Notify_Id"))
                        Command.Parameters.AddWithValue("@Register_Dist_Code", row.Item("Register_Dist_Code"))
                        Command.Parameters.AddWithValue("@Register_Vil_Code", row.Item("Register_Vil_Code"))
                        Command.Parameters.AddWithValue("@Dist_Code", row.Item("Dist_Code"))
                        Command.Parameters.AddWithValue("@Vil_Code", row.Item("Vil_Code"))
                        Command.Parameters.AddWithValue("@Dist_Code2", row.Item("Dist_Code2"))
                        Command.Parameters.AddWithValue("@Vil_Code2", row.Item("Vil_Code2"))
                        Command.Parameters.AddWithValue("@Not_Scrap", row.Item("Not_Scrap"))
                        Command.Parameters.AddWithValue("@Chart_No_Int", row.Item("Chart_No_Int"))
                        Command.Parameters.AddWithValue("@Info_Confirm", row.Item("Info_Confirm"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                  insertBackup(row, conn) '備份機制
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
            " Chart_No , Patient_Name , Patient_En_Name , Idno_Type_Id , Idno ,  " & _ 
             " Birth_Date , Sex_Id , Blood_Type_Id , Education_Id , Marriage_Id ,  " & _ 
             " Job_Id , Nationality_Id , Race_Id , Area_Code , Register_Postal_Code ,  " & _ 
             " Register_Address , Postal_Code , Address , Tel_Home , Tel_Office ,  " & _ 
             " Tel_Mobile , Fax , Email , Postal_Code2 , Address2 ,  " & _ 
             " Tel2 , Tel2_Mobile , Email2 , First_Visit_Date , Latest_Visit_Date ,  " & _ 
             " Latest_Admission_Date , Latest_Discharge_Date , Ipd_Times , Latest_Xray_Date , Latest_CT_Date ,  " & _ 
             " Arrears_Times , Opd_Arrears_Amt , Emg_Arrears_Amt , Ipd_Arrears_Amt , Measure_Time ,  " & _ 
             " Latest_Height , Latest_Weight , Mis_Register_Date1 , Mis_Register_Date2 , Mis_Register_Date3 ,  " & _ 
             " Mis_Register_Times , Mis_Register_End_Date , Is_Death , Death_Time , Is_Chart_Divide ,  " & _ 
             " Is_Chart_Image , Patient_Memo , Is_Employee , Reserve_Chart_No , Latest_LMP_Date ,  " & _ 
             " LIS_Blood_Report , LIS_Blood_Report_Time , LIS_BMT_Mark , Student_Id , Create_User ,  " & _ 
             " Create_Time , Modified_User , Modified_Time , Is_IPD , Is_EMG ,  " & _ 
             " Patient_Short_Name , Reg_Notify_Id , Register_Dist_Code , Register_Vil_Code , Dist_Code ,  " & _ 
             " Vil_Code , Dist_Code2 , Vil_Code2 , Not_Scrap , Chart_No_Int ,  " & _ 
             " Info_Confirm ) " & _ 
             " values( @Chart_No , @Patient_Name , @Patient_En_Name , @Idno_Type_Id , @Idno ,  " & _ 
             " @Birth_Date , @Sex_Id , @Blood_Type_Id , @Education_Id , @Marriage_Id ,  " & _ 
             " @Job_Id , @Nationality_Id , @Race_Id , @Area_Code , @Register_Postal_Code ,  " & _ 
             " @Register_Address , @Postal_Code , @Address , @Tel_Home , @Tel_Office ,  " & _ 
             " @Tel_Mobile , @Fax , @Email , @Postal_Code2 , @Address2 ,  " & _ 
             " @Tel2 , @Tel2_Mobile , @Email2 , @First_Visit_Date , @Latest_Visit_Date ,  " & _ 
             " @Latest_Admission_Date , @Latest_Discharge_Date , @Ipd_Times , @Latest_Xray_Date , @Latest_CT_Date ,  " & _ 
             " @Arrears_Times , @Opd_Arrears_Amt , @Emg_Arrears_Amt , @Ipd_Arrears_Amt , @Measure_Time ,  " & _ 
             " @Latest_Height , @Latest_Weight , @Mis_Register_Date1 , @Mis_Register_Date2 , @Mis_Register_Date3 ,  " & _ 
             " @Mis_Register_Times , @Mis_Register_End_Date , @Is_Death , @Death_Time , @Is_Chart_Divide ,  " & _ 
             " @Is_Chart_Image , @Patient_Memo , @Is_Employee , @Reserve_Chart_No , @Latest_LMP_Date ,  " & _ 
             " @LIS_Blood_Report , @LIS_Blood_Report_Time , @LIS_BMT_Mark , @Student_Id , @Create_User ,  " & _ 
             " @Create_Time , @Modified_User , @Modified_Time , @Is_IPD , @Is_EMG ,  " & _ 
             " @Patient_Short_Name , @Reg_Notify_Id , @Register_Dist_Code , @Register_Vil_Code , @Dist_Code ,  " & _ 
             " @Vil_Code , @Dist_Code2 , @Vil_Code2 , @Not_Scrap , @Chart_No_Int ,  " & _ 
             " @Info_Confirm             )"
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Patient_Name", row.Item("Patient_Name"))
                        Command.Parameters.AddWithValue("@Patient_En_Name", row.Item("Patient_En_Name"))
                        Command.Parameters.AddWithValue("@Idno_Type_Id", row.Item("Idno_Type_Id"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        Command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                        Command.Parameters.AddWithValue("@Blood_Type_Id", row.Item("Blood_Type_Id"))
                        Command.Parameters.AddWithValue("@Education_Id", row.Item("Education_Id"))
                        Command.Parameters.AddWithValue("@Marriage_Id", row.Item("Marriage_Id"))
                        Command.Parameters.AddWithValue("@Job_Id", row.Item("Job_Id"))
                        Command.Parameters.AddWithValue("@Nationality_Id", row.Item("Nationality_Id"))
                        Command.Parameters.AddWithValue("@Race_Id", row.Item("Race_Id"))
                        Command.Parameters.AddWithValue("@Area_Code", row.Item("Area_Code"))
                        Command.Parameters.AddWithValue("@Register_Postal_Code", row.Item("Register_Postal_Code"))
                        Command.Parameters.AddWithValue("@Register_Address", row.Item("Register_Address"))
                        Command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                        Command.Parameters.AddWithValue("@Address", row.Item("Address"))
                        Command.Parameters.AddWithValue("@Tel_Home", row.Item("Tel_Home"))
                        Command.Parameters.AddWithValue("@Tel_Office", row.Item("Tel_Office"))
                        Command.Parameters.AddWithValue("@Tel_Mobile", row.Item("Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Fax", row.Item("Fax"))
                        Command.Parameters.AddWithValue("@Email", row.Item("Email"))
                        Command.Parameters.AddWithValue("@Postal_Code2", row.Item("Postal_Code2"))
                        Command.Parameters.AddWithValue("@Address2", row.Item("Address2"))
                        Command.Parameters.AddWithValue("@Tel2", row.Item("Tel2"))
                        Command.Parameters.AddWithValue("@Tel2_Mobile", row.Item("Tel2_Mobile"))
                        Command.Parameters.AddWithValue("@Email2", row.Item("Email2"))
                        Command.Parameters.AddWithValue("@First_Visit_Date", row.Item("First_Visit_Date"))
                        Command.Parameters.AddWithValue("@Latest_Visit_Date", row.Item("Latest_Visit_Date"))
                        Command.Parameters.AddWithValue("@Latest_Admission_Date", row.Item("Latest_Admission_Date"))
                        Command.Parameters.AddWithValue("@Latest_Discharge_Date", row.Item("Latest_Discharge_Date"))
                        Command.Parameters.AddWithValue("@Ipd_Times", row.Item("Ipd_Times"))
                        Command.Parameters.AddWithValue("@Latest_Xray_Date", row.Item("Latest_Xray_Date"))
                        Command.Parameters.AddWithValue("@Latest_CT_Date", row.Item("Latest_CT_Date"))
                        Command.Parameters.AddWithValue("@Arrears_Times", row.Item("Arrears_Times"))
                        Command.Parameters.AddWithValue("@Opd_Arrears_Amt", row.Item("Opd_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Emg_Arrears_Amt", row.Item("Emg_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Ipd_Arrears_Amt", row.Item("Ipd_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Measure_Time", row.Item("Measure_Time"))
                        Command.Parameters.AddWithValue("@Latest_Height", row.Item("Latest_Height"))
                        Command.Parameters.AddWithValue("@Latest_Weight", row.Item("Latest_Weight"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date1", row.Item("Mis_Register_Date1"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date2", row.Item("Mis_Register_Date2"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date3", row.Item("Mis_Register_Date3"))
                        Command.Parameters.AddWithValue("@Mis_Register_Times", row.Item("Mis_Register_Times"))
                        Command.Parameters.AddWithValue("@Mis_Register_End_Date", row.Item("Mis_Register_End_Date"))
                        Command.Parameters.AddWithValue("@Is_Death", row.Item("Is_Death"))
                        Command.Parameters.AddWithValue("@Death_Time", row.Item("Death_Time"))
                        Command.Parameters.AddWithValue("@Is_Chart_Divide", row.Item("Is_Chart_Divide"))
                        Command.Parameters.AddWithValue("@Is_Chart_Image", row.Item("Is_Chart_Image"))
                        Command.Parameters.AddWithValue("@Patient_Memo", row.Item("Patient_Memo"))
                        Command.Parameters.AddWithValue("@Is_Employee", row.Item("Is_Employee"))
                        Command.Parameters.AddWithValue("@Reserve_Chart_No", row.Item("Reserve_Chart_No"))
                        Command.Parameters.AddWithValue("@Latest_LMP_Date", row.Item("Latest_LMP_Date"))
                        Command.Parameters.AddWithValue("@LIS_Blood_Report", row.Item("LIS_Blood_Report"))
                        Command.Parameters.AddWithValue("@LIS_Blood_Report_Time", row.Item("LIS_Blood_Report_Time"))
                        Command.Parameters.AddWithValue("@LIS_BMT_Mark", row.Item("LIS_BMT_Mark"))
                        Command.Parameters.AddWithValue("@Student_Id", row.Item("Student_Id"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_IPD", row.Item("Is_IPD"))
                        Command.Parameters.AddWithValue("@Is_EMG", row.Item("Is_EMG"))
                        Command.Parameters.AddWithValue("@Patient_Short_Name", row.Item("Patient_Short_Name"))
                        Command.Parameters.AddWithValue("@Reg_Notify_Id", row.Item("Reg_Notify_Id"))
                        Command.Parameters.AddWithValue("@Register_Dist_Code", row.Item("Register_Dist_Code"))
                        Command.Parameters.AddWithValue("@Register_Vil_Code", row.Item("Register_Vil_Code"))
                        Command.Parameters.AddWithValue("@Dist_Code", row.Item("Dist_Code"))
                        Command.Parameters.AddWithValue("@Vil_Code", row.Item("Vil_Code"))
                        Command.Parameters.AddWithValue("@Dist_Code2", row.Item("Dist_Code2"))
                        Command.Parameters.AddWithValue("@Vil_Code2", row.Item("Vil_Code2"))
                        Command.Parameters.AddWithValue("@Not_Scrap", row.Item("Not_Scrap"))
                        Command.Parameters.AddWithValue("@Chart_No_Int", row.Item("Chart_No_Int"))
                        Command.Parameters.AddWithValue("@Info_Confirm", row.Item("Info_Confirm"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                  insertBackup(row, conn) '備份機制
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
            " Chart_No , Patient_Name , Patient_En_Name , Idno_Type_Id , Idno ,  " & _ 
             " Birth_Date , Sex_Id , Blood_Type_Id , Education_Id , Marriage_Id ,  " & _ 
             " Job_Id , Nationality_Id , Race_Id , Area_Code , Register_Postal_Code ,  " & _ 
             " Register_Address , Postal_Code , Address , Tel_Home , Tel_Office ,  " & _ 
             " Tel_Mobile , Fax , Email , Postal_Code2 , Address2 ,  " & _ 
             " Tel2 , Tel2_Mobile , Email2 , First_Visit_Date , Latest_Visit_Date ,  " & _ 
             " Latest_Admission_Date , Latest_Discharge_Date , Ipd_Times , Latest_Xray_Date , Latest_CT_Date ,  " & _ 
             " Arrears_Times , Opd_Arrears_Amt , Emg_Arrears_Amt , Ipd_Arrears_Amt , Measure_Time ,  " & _ 
             " Latest_Height , Latest_Weight , Mis_Register_Date1 , Mis_Register_Date2 , Mis_Register_Date3 ,  " & _ 
             " Mis_Register_Times , Mis_Register_End_Date , Is_Death , Death_Time , Is_Chart_Divide ,  " & _ 
             " Is_Chart_Image , Patient_Memo , Is_Employee , Reserve_Chart_No , Latest_LMP_Date ,  " & _ 
             " LIS_Blood_Report , LIS_Blood_Report_Time , LIS_BMT_Mark , Student_Id , Create_User ,  " & _ 
             " Create_Time , Modified_User , Modified_Time , Is_IPD , Is_EMG ,  " & _ 
             " Patient_Short_Name , Reg_Notify_Id , Register_Dist_Code , Register_Vil_Code , Dist_Code ,  " & _ 
             " Vil_Code , Dist_Code2 , Vil_Code2 , Not_Scrap , Chart_No_Int ,  " & _ 
             " Info_Confirm ) " & _ 
             " values( @Chart_No , @Patient_Name , @Patient_En_Name , @Idno_Type_Id , @Idno ,  " & _ 
             " @Birth_Date , @Sex_Id , @Blood_Type_Id , @Education_Id , @Marriage_Id ,  " & _ 
             " @Job_Id , @Nationality_Id , @Race_Id , @Area_Code , @Register_Postal_Code ,  " & _ 
             " @Register_Address , @Postal_Code , @Address , @Tel_Home , @Tel_Office ,  " & _ 
             " @Tel_Mobile , @Fax , @Email , @Postal_Code2 , @Address2 ,  " & _ 
             " @Tel2 , @Tel2_Mobile , @Email2 , @First_Visit_Date , @Latest_Visit_Date ,  " & _ 
             " @Latest_Admission_Date , @Latest_Discharge_Date , @Ipd_Times , @Latest_Xray_Date , @Latest_CT_Date ,  " & _ 
             " @Arrears_Times , @Opd_Arrears_Amt , @Emg_Arrears_Amt , @Ipd_Arrears_Amt , @Measure_Time ,  " & _ 
             " @Latest_Height , @Latest_Weight , @Mis_Register_Date1 , @Mis_Register_Date2 , @Mis_Register_Date3 ,  " & _ 
             " @Mis_Register_Times , @Mis_Register_End_Date , @Is_Death , @Death_Time , @Is_Chart_Divide ,  " & _ 
             " @Is_Chart_Image , @Patient_Memo , @Is_Employee , @Reserve_Chart_No , @Latest_LMP_Date ,  " & _ 
             " @LIS_Blood_Report , @LIS_Blood_Report_Time , @LIS_BMT_Mark , @Student_Id , @Create_User ,  " & _ 
             " @Create_Time , @Modified_User , @Modified_Time , @Is_IPD , @Is_EMG ,  " & _ 
             " @Patient_Short_Name , @Reg_Notify_Id , @Register_Dist_Code , @Register_Vil_Code , @Dist_Code ,  " & _ 
             " @Vil_Code , @Dist_Code2 , @Vil_Code2 , @Not_Scrap , @Chart_No_Int ,  " & _ 
             " @Info_Confirm             )"
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Patient_Name", row.Item("Patient_Name"))
                        Command.Parameters.AddWithValue("@Patient_En_Name", row.Item("Patient_En_Name"))
                        Command.Parameters.AddWithValue("@Idno_Type_Id", row.Item("Idno_Type_Id"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        Command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                        Command.Parameters.AddWithValue("@Blood_Type_Id", row.Item("Blood_Type_Id"))
                        Command.Parameters.AddWithValue("@Education_Id", row.Item("Education_Id"))
                        Command.Parameters.AddWithValue("@Marriage_Id", row.Item("Marriage_Id"))
                        Command.Parameters.AddWithValue("@Job_Id", row.Item("Job_Id"))
                        Command.Parameters.AddWithValue("@Nationality_Id", row.Item("Nationality_Id"))
                        Command.Parameters.AddWithValue("@Race_Id", row.Item("Race_Id"))
                        Command.Parameters.AddWithValue("@Area_Code", row.Item("Area_Code"))
                        Command.Parameters.AddWithValue("@Register_Postal_Code", row.Item("Register_Postal_Code"))
                        Command.Parameters.AddWithValue("@Register_Address", row.Item("Register_Address"))
                        Command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                        Command.Parameters.AddWithValue("@Address", row.Item("Address"))
                        Command.Parameters.AddWithValue("@Tel_Home", row.Item("Tel_Home"))
                        Command.Parameters.AddWithValue("@Tel_Office", row.Item("Tel_Office"))
                        Command.Parameters.AddWithValue("@Tel_Mobile", row.Item("Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Fax", row.Item("Fax"))
                        Command.Parameters.AddWithValue("@Email", row.Item("Email"))
                        Command.Parameters.AddWithValue("@Postal_Code2", row.Item("Postal_Code2"))
                        Command.Parameters.AddWithValue("@Address2", row.Item("Address2"))
                        Command.Parameters.AddWithValue("@Tel2", row.Item("Tel2"))
                        Command.Parameters.AddWithValue("@Tel2_Mobile", row.Item("Tel2_Mobile"))
                        Command.Parameters.AddWithValue("@Email2", row.Item("Email2"))
                        Command.Parameters.AddWithValue("@First_Visit_Date", row.Item("First_Visit_Date"))
                        Command.Parameters.AddWithValue("@Latest_Visit_Date", row.Item("Latest_Visit_Date"))
                        Command.Parameters.AddWithValue("@Latest_Admission_Date", row.Item("Latest_Admission_Date"))
                        Command.Parameters.AddWithValue("@Latest_Discharge_Date", row.Item("Latest_Discharge_Date"))
                        Command.Parameters.AddWithValue("@Ipd_Times", row.Item("Ipd_Times"))
                        Command.Parameters.AddWithValue("@Latest_Xray_Date", row.Item("Latest_Xray_Date"))
                        Command.Parameters.AddWithValue("@Latest_CT_Date", row.Item("Latest_CT_Date"))
                        Command.Parameters.AddWithValue("@Arrears_Times", row.Item("Arrears_Times"))
                        Command.Parameters.AddWithValue("@Opd_Arrears_Amt", row.Item("Opd_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Emg_Arrears_Amt", row.Item("Emg_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Ipd_Arrears_Amt", row.Item("Ipd_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Measure_Time", row.Item("Measure_Time"))
                        Command.Parameters.AddWithValue("@Latest_Height", row.Item("Latest_Height"))
                        Command.Parameters.AddWithValue("@Latest_Weight", row.Item("Latest_Weight"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date1", row.Item("Mis_Register_Date1"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date2", row.Item("Mis_Register_Date2"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date3", row.Item("Mis_Register_Date3"))
                        Command.Parameters.AddWithValue("@Mis_Register_Times", row.Item("Mis_Register_Times"))
                        Command.Parameters.AddWithValue("@Mis_Register_End_Date", row.Item("Mis_Register_End_Date"))
                        Command.Parameters.AddWithValue("@Is_Death", row.Item("Is_Death"))
                        Command.Parameters.AddWithValue("@Death_Time", row.Item("Death_Time"))
                        Command.Parameters.AddWithValue("@Is_Chart_Divide", row.Item("Is_Chart_Divide"))
                        Command.Parameters.AddWithValue("@Is_Chart_Image", row.Item("Is_Chart_Image"))
                        Command.Parameters.AddWithValue("@Patient_Memo", row.Item("Patient_Memo"))
                        Command.Parameters.AddWithValue("@Is_Employee", row.Item("Is_Employee"))
                        Command.Parameters.AddWithValue("@Reserve_Chart_No", row.Item("Reserve_Chart_No"))
                        Command.Parameters.AddWithValue("@Latest_LMP_Date", row.Item("Latest_LMP_Date"))
                        Command.Parameters.AddWithValue("@LIS_Blood_Report", row.Item("LIS_Blood_Report"))
                        Command.Parameters.AddWithValue("@LIS_Blood_Report_Time", row.Item("LIS_Blood_Report_Time"))
                        Command.Parameters.AddWithValue("@LIS_BMT_Mark", row.Item("LIS_BMT_Mark"))
                        Command.Parameters.AddWithValue("@Student_Id", row.Item("Student_Id"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Is_IPD", row.Item("Is_IPD"))
                        Command.Parameters.AddWithValue("@Is_EMG", row.Item("Is_EMG"))
                        Command.Parameters.AddWithValue("@Patient_Short_Name", row.Item("Patient_Short_Name"))
                        Command.Parameters.AddWithValue("@Reg_Notify_Id", row.Item("Reg_Notify_Id"))
                        Command.Parameters.AddWithValue("@Register_Dist_Code", row.Item("Register_Dist_Code"))
                        Command.Parameters.AddWithValue("@Register_Vil_Code", row.Item("Register_Vil_Code"))
                        Command.Parameters.AddWithValue("@Dist_Code", row.Item("Dist_Code"))
                        Command.Parameters.AddWithValue("@Vil_Code", row.Item("Vil_Code"))
                        Command.Parameters.AddWithValue("@Dist_Code2", row.Item("Dist_Code2"))
                        Command.Parameters.AddWithValue("@Vil_Code2", row.Item("Vil_Code2"))
                        Command.Parameters.AddWithValue("@Not_Scrap", row.Item("Not_Scrap"))
                        Command.Parameters.AddWithValue("@Chart_No_Int", row.Item("Chart_No_Int"))
                        Command.Parameters.AddWithValue("@Info_Confirm", row.Item("Info_Confirm"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                  insertBackup(row, conn) '備份機制
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
            " Patient_Name=@Patient_Name , Patient_En_Name=@Patient_En_Name , Idno_Type_Id=@Idno_Type_Id , Idno=@Idno " & _ 
            "  , Birth_Date=@Birth_Date , Sex_Id=@Sex_Id , Blood_Type_Id=@Blood_Type_Id , Education_Id=@Education_Id , Marriage_Id=@Marriage_Id " & _ 
            "  , Job_Id=@Job_Id , Nationality_Id=@Nationality_Id , Race_Id=@Race_Id , Area_Code=@Area_Code , Register_Postal_Code=@Register_Postal_Code " & _ 
            "  , Register_Address=@Register_Address , Postal_Code=@Postal_Code , Address=@Address , Tel_Home=@Tel_Home , Tel_Office=@Tel_Office " & _ 
            "  , Tel_Mobile=@Tel_Mobile , Fax=@Fax , Email=@Email , Postal_Code2=@Postal_Code2 , Address2=@Address2 " & _ 
            "  , Tel2=@Tel2 , Tel2_Mobile=@Tel2_Mobile , Email2=@Email2 , First_Visit_Date=@First_Visit_Date , Latest_Visit_Date=@Latest_Visit_Date " & _ 
            "  , Latest_Admission_Date=@Latest_Admission_Date , Latest_Discharge_Date=@Latest_Discharge_Date , Ipd_Times=@Ipd_Times , Latest_Xray_Date=@Latest_Xray_Date , Latest_CT_Date=@Latest_CT_Date " & _ 
            "  , Arrears_Times=@Arrears_Times , Opd_Arrears_Amt=@Opd_Arrears_Amt , Emg_Arrears_Amt=@Emg_Arrears_Amt , Ipd_Arrears_Amt=@Ipd_Arrears_Amt , Measure_Time=@Measure_Time " & _ 
            "  , Latest_Height=@Latest_Height , Latest_Weight=@Latest_Weight , Mis_Register_Date1=@Mis_Register_Date1 , Mis_Register_Date2=@Mis_Register_Date2 , Mis_Register_Date3=@Mis_Register_Date3 " & _ 
            "  , Mis_Register_Times=@Mis_Register_Times , Mis_Register_End_Date=@Mis_Register_End_Date , Is_Death=@Is_Death , Death_Time=@Death_Time , Is_Chart_Divide=@Is_Chart_Divide " & _ 
            "  , Is_Chart_Image=@Is_Chart_Image , Patient_Memo=@Patient_Memo , Is_Employee=@Is_Employee , Reserve_Chart_No=@Reserve_Chart_No , Latest_LMP_Date=@Latest_LMP_Date " & _ 
            "  , LIS_Blood_Report=@LIS_Blood_Report , LIS_Blood_Report_Time=@LIS_Blood_Report_Time , LIS_BMT_Mark=@LIS_BMT_Mark , Student_Id=@Student_Id , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_IPD=@Is_IPD , Is_EMG=@Is_EMG " & _ 
            "  , Patient_Short_Name=@Patient_Short_Name , Reg_Notify_Id=@Reg_Notify_Id , Register_Dist_Code=@Register_Dist_Code , Register_Vil_Code=@Register_Vil_Code , Dist_Code=@Dist_Code " & _ 
            "  , Vil_Code=@Vil_Code , Dist_Code2=@Dist_Code2 , Vil_Code2=@Vil_Code2 , Not_Scrap=@Not_Scrap , Chart_No_Int=@Chart_No_Int " & _ 
            "  , Info_Confirm=@Info_Confirm " & _ 
            " where  Chart_No=@Chart_No            "
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Patient_Name", row.Item("Patient_Name"))
                        Command.Parameters.AddWithValue("@Patient_En_Name", row.Item("Patient_En_Name"))
                        Command.Parameters.AddWithValue("@Idno_Type_Id", row.Item("Idno_Type_Id"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        Command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                        Command.Parameters.AddWithValue("@Blood_Type_Id", row.Item("Blood_Type_Id"))
                        Command.Parameters.AddWithValue("@Education_Id", row.Item("Education_Id"))
                        Command.Parameters.AddWithValue("@Marriage_Id", row.Item("Marriage_Id"))
                        Command.Parameters.AddWithValue("@Job_Id", row.Item("Job_Id"))
                        Command.Parameters.AddWithValue("@Nationality_Id", row.Item("Nationality_Id"))
                        Command.Parameters.AddWithValue("@Race_Id", row.Item("Race_Id"))
                        Command.Parameters.AddWithValue("@Area_Code", row.Item("Area_Code"))
                        Command.Parameters.AddWithValue("@Register_Postal_Code", row.Item("Register_Postal_Code"))
                        Command.Parameters.AddWithValue("@Register_Address", row.Item("Register_Address"))
                        Command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                        Command.Parameters.AddWithValue("@Address", row.Item("Address"))
                        Command.Parameters.AddWithValue("@Tel_Home", row.Item("Tel_Home"))
                        Command.Parameters.AddWithValue("@Tel_Office", row.Item("Tel_Office"))
                        Command.Parameters.AddWithValue("@Tel_Mobile", row.Item("Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Fax", row.Item("Fax"))
                        Command.Parameters.AddWithValue("@Email", row.Item("Email"))
                        Command.Parameters.AddWithValue("@Postal_Code2", row.Item("Postal_Code2"))
                        Command.Parameters.AddWithValue("@Address2", row.Item("Address2"))
                        Command.Parameters.AddWithValue("@Tel2", row.Item("Tel2"))
                        Command.Parameters.AddWithValue("@Tel2_Mobile", row.Item("Tel2_Mobile"))
                        Command.Parameters.AddWithValue("@Email2", row.Item("Email2"))
                        Command.Parameters.AddWithValue("@First_Visit_Date", row.Item("First_Visit_Date"))
                        Command.Parameters.AddWithValue("@Latest_Visit_Date", row.Item("Latest_Visit_Date"))
                        Command.Parameters.AddWithValue("@Latest_Admission_Date", row.Item("Latest_Admission_Date"))
                        Command.Parameters.AddWithValue("@Latest_Discharge_Date", row.Item("Latest_Discharge_Date"))
                        Command.Parameters.AddWithValue("@Ipd_Times", row.Item("Ipd_Times"))
                        Command.Parameters.AddWithValue("@Latest_Xray_Date", row.Item("Latest_Xray_Date"))
                        Command.Parameters.AddWithValue("@Latest_CT_Date", row.Item("Latest_CT_Date"))
                        Command.Parameters.AddWithValue("@Arrears_Times", row.Item("Arrears_Times"))
                        Command.Parameters.AddWithValue("@Opd_Arrears_Amt", row.Item("Opd_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Emg_Arrears_Amt", row.Item("Emg_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Ipd_Arrears_Amt", row.Item("Ipd_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Measure_Time", row.Item("Measure_Time"))
                        Command.Parameters.AddWithValue("@Latest_Height", row.Item("Latest_Height"))
                        Command.Parameters.AddWithValue("@Latest_Weight", row.Item("Latest_Weight"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date1", row.Item("Mis_Register_Date1"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date2", row.Item("Mis_Register_Date2"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date3", row.Item("Mis_Register_Date3"))
                        Command.Parameters.AddWithValue("@Mis_Register_Times", row.Item("Mis_Register_Times"))
                        Command.Parameters.AddWithValue("@Mis_Register_End_Date", row.Item("Mis_Register_End_Date"))
                        Command.Parameters.AddWithValue("@Is_Death", row.Item("Is_Death"))
                        Command.Parameters.AddWithValue("@Death_Time", row.Item("Death_Time"))
                        Command.Parameters.AddWithValue("@Is_Chart_Divide", row.Item("Is_Chart_Divide"))
                        Command.Parameters.AddWithValue("@Is_Chart_Image", row.Item("Is_Chart_Image"))
                        Command.Parameters.AddWithValue("@Patient_Memo", row.Item("Patient_Memo"))
                        Command.Parameters.AddWithValue("@Is_Employee", row.Item("Is_Employee"))
                        Command.Parameters.AddWithValue("@Reserve_Chart_No", row.Item("Reserve_Chart_No"))
                        Command.Parameters.AddWithValue("@Latest_LMP_Date", row.Item("Latest_LMP_Date"))
                        Command.Parameters.AddWithValue("@LIS_Blood_Report", row.Item("LIS_Blood_Report"))
                        Command.Parameters.AddWithValue("@LIS_Blood_Report_Time", row.Item("LIS_Blood_Report_Time"))
                        Command.Parameters.AddWithValue("@LIS_BMT_Mark", row.Item("LIS_BMT_Mark"))
                        Command.Parameters.AddWithValue("@Student_Id", row.Item("Student_Id"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_IPD", row.Item("Is_IPD"))
                        Command.Parameters.AddWithValue("@Is_EMG", row.Item("Is_EMG"))
                        Command.Parameters.AddWithValue("@Patient_Short_Name", row.Item("Patient_Short_Name"))
                        Command.Parameters.AddWithValue("@Reg_Notify_Id", row.Item("Reg_Notify_Id"))
                        Command.Parameters.AddWithValue("@Register_Dist_Code", row.Item("Register_Dist_Code"))
                        Command.Parameters.AddWithValue("@Register_Vil_Code", row.Item("Register_Vil_Code"))
                        Command.Parameters.AddWithValue("@Dist_Code", row.Item("Dist_Code"))
                        Command.Parameters.AddWithValue("@Vil_Code", row.Item("Vil_Code"))
                        Command.Parameters.AddWithValue("@Dist_Code2", row.Item("Dist_Code2"))
                        Command.Parameters.AddWithValue("@Vil_Code2", row.Item("Vil_Code2"))
                        Command.Parameters.AddWithValue("@Not_Scrap", row.Item("Not_Scrap"))
                        Command.Parameters.AddWithValue("@Chart_No_Int", row.Item("Chart_No_Int"))
                        Command.Parameters.AddWithValue("@Info_Confirm", row.Item("Info_Confirm"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                updateBackup(row, conn) '備份機制
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
            " Patient_Name=@Patient_Name , Patient_En_Name=@Patient_En_Name , Idno_Type_Id=@Idno_Type_Id , Idno=@Idno " & _ 
            "  , Birth_Date=@Birth_Date , Sex_Id=@Sex_Id , Blood_Type_Id=@Blood_Type_Id , Education_Id=@Education_Id , Marriage_Id=@Marriage_Id " & _ 
            "  , Job_Id=@Job_Id , Nationality_Id=@Nationality_Id , Race_Id=@Race_Id , Area_Code=@Area_Code , Register_Postal_Code=@Register_Postal_Code " & _ 
            "  , Register_Address=@Register_Address , Postal_Code=@Postal_Code , Address=@Address , Tel_Home=@Tel_Home , Tel_Office=@Tel_Office " & _ 
            "  , Tel_Mobile=@Tel_Mobile , Fax=@Fax , Email=@Email , Postal_Code2=@Postal_Code2 , Address2=@Address2 " & _ 
            "  , Tel2=@Tel2 , Tel2_Mobile=@Tel2_Mobile , Email2=@Email2 , First_Visit_Date=@First_Visit_Date , Latest_Visit_Date=@Latest_Visit_Date " & _ 
            "  , Latest_Admission_Date=@Latest_Admission_Date , Latest_Discharge_Date=@Latest_Discharge_Date , Ipd_Times=@Ipd_Times , Latest_Xray_Date=@Latest_Xray_Date , Latest_CT_Date=@Latest_CT_Date " & _ 
            "  , Arrears_Times=@Arrears_Times , Opd_Arrears_Amt=@Opd_Arrears_Amt , Emg_Arrears_Amt=@Emg_Arrears_Amt , Ipd_Arrears_Amt=@Ipd_Arrears_Amt , Measure_Time=@Measure_Time " & _ 
            "  , Latest_Height=@Latest_Height , Latest_Weight=@Latest_Weight , Mis_Register_Date1=@Mis_Register_Date1 , Mis_Register_Date2=@Mis_Register_Date2 , Mis_Register_Date3=@Mis_Register_Date3 " & _ 
            "  , Mis_Register_Times=@Mis_Register_Times , Mis_Register_End_Date=@Mis_Register_End_Date , Is_Death=@Is_Death , Death_Time=@Death_Time , Is_Chart_Divide=@Is_Chart_Divide " & _ 
            "  , Is_Chart_Image=@Is_Chart_Image , Patient_Memo=@Patient_Memo , Is_Employee=@Is_Employee , Reserve_Chart_No=@Reserve_Chart_No , Latest_LMP_Date=@Latest_LMP_Date " & _ 
            "  , LIS_Blood_Report=@LIS_Blood_Report , LIS_Blood_Report_Time=@LIS_Blood_Report_Time , LIS_BMT_Mark=@LIS_BMT_Mark , Student_Id=@Student_Id , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_IPD=@Is_IPD , Is_EMG=@Is_EMG " & _ 
            "  , Patient_Short_Name=@Patient_Short_Name , Reg_Notify_Id=@Reg_Notify_Id , Register_Dist_Code=@Register_Dist_Code , Register_Vil_Code=@Register_Vil_Code , Dist_Code=@Dist_Code " & _ 
            "  , Vil_Code=@Vil_Code , Dist_Code2=@Dist_Code2 , Vil_Code2=@Vil_Code2 , Not_Scrap=@Not_Scrap , Chart_No_Int=@Chart_No_Int " & _ 
            "  , Info_Confirm=@Info_Confirm " & _ 
            " where  Chart_No=@Chart_No            "
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Patient_Name", row.Item("Patient_Name"))
                        Command.Parameters.AddWithValue("@Patient_En_Name", row.Item("Patient_En_Name"))
                        Command.Parameters.AddWithValue("@Idno_Type_Id", row.Item("Idno_Type_Id"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        Command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                        Command.Parameters.AddWithValue("@Blood_Type_Id", row.Item("Blood_Type_Id"))
                        Command.Parameters.AddWithValue("@Education_Id", row.Item("Education_Id"))
                        Command.Parameters.AddWithValue("@Marriage_Id", row.Item("Marriage_Id"))
                        Command.Parameters.AddWithValue("@Job_Id", row.Item("Job_Id"))
                        Command.Parameters.AddWithValue("@Nationality_Id", row.Item("Nationality_Id"))
                        Command.Parameters.AddWithValue("@Race_Id", row.Item("Race_Id"))
                        Command.Parameters.AddWithValue("@Area_Code", row.Item("Area_Code"))
                        Command.Parameters.AddWithValue("@Register_Postal_Code", row.Item("Register_Postal_Code"))
                        Command.Parameters.AddWithValue("@Register_Address", row.Item("Register_Address"))
                        Command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                        Command.Parameters.AddWithValue("@Address", row.Item("Address"))
                        Command.Parameters.AddWithValue("@Tel_Home", row.Item("Tel_Home"))
                        Command.Parameters.AddWithValue("@Tel_Office", row.Item("Tel_Office"))
                        Command.Parameters.AddWithValue("@Tel_Mobile", row.Item("Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Fax", row.Item("Fax"))
                        Command.Parameters.AddWithValue("@Email", row.Item("Email"))
                        Command.Parameters.AddWithValue("@Postal_Code2", row.Item("Postal_Code2"))
                        Command.Parameters.AddWithValue("@Address2", row.Item("Address2"))
                        Command.Parameters.AddWithValue("@Tel2", row.Item("Tel2"))
                        Command.Parameters.AddWithValue("@Tel2_Mobile", row.Item("Tel2_Mobile"))
                        Command.Parameters.AddWithValue("@Email2", row.Item("Email2"))
                        Command.Parameters.AddWithValue("@First_Visit_Date", row.Item("First_Visit_Date"))
                        Command.Parameters.AddWithValue("@Latest_Visit_Date", row.Item("Latest_Visit_Date"))
                        Command.Parameters.AddWithValue("@Latest_Admission_Date", row.Item("Latest_Admission_Date"))
                        Command.Parameters.AddWithValue("@Latest_Discharge_Date", row.Item("Latest_Discharge_Date"))
                        Command.Parameters.AddWithValue("@Ipd_Times", row.Item("Ipd_Times"))
                        Command.Parameters.AddWithValue("@Latest_Xray_Date", row.Item("Latest_Xray_Date"))
                        Command.Parameters.AddWithValue("@Latest_CT_Date", row.Item("Latest_CT_Date"))
                        Command.Parameters.AddWithValue("@Arrears_Times", row.Item("Arrears_Times"))
                        Command.Parameters.AddWithValue("@Opd_Arrears_Amt", row.Item("Opd_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Emg_Arrears_Amt", row.Item("Emg_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Ipd_Arrears_Amt", row.Item("Ipd_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Measure_Time", row.Item("Measure_Time"))
                        Command.Parameters.AddWithValue("@Latest_Height", row.Item("Latest_Height"))
                        Command.Parameters.AddWithValue("@Latest_Weight", row.Item("Latest_Weight"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date1", row.Item("Mis_Register_Date1"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date2", row.Item("Mis_Register_Date2"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date3", row.Item("Mis_Register_Date3"))
                        Command.Parameters.AddWithValue("@Mis_Register_Times", row.Item("Mis_Register_Times"))
                        Command.Parameters.AddWithValue("@Mis_Register_End_Date", row.Item("Mis_Register_End_Date"))
                        Command.Parameters.AddWithValue("@Is_Death", row.Item("Is_Death"))
                        Command.Parameters.AddWithValue("@Death_Time", row.Item("Death_Time"))
                        Command.Parameters.AddWithValue("@Is_Chart_Divide", row.Item("Is_Chart_Divide"))
                        Command.Parameters.AddWithValue("@Is_Chart_Image", row.Item("Is_Chart_Image"))
                        Command.Parameters.AddWithValue("@Patient_Memo", row.Item("Patient_Memo"))
                        Command.Parameters.AddWithValue("@Is_Employee", row.Item("Is_Employee"))
                        Command.Parameters.AddWithValue("@Reserve_Chart_No", row.Item("Reserve_Chart_No"))
                        Command.Parameters.AddWithValue("@Latest_LMP_Date", row.Item("Latest_LMP_Date"))
                        Command.Parameters.AddWithValue("@LIS_Blood_Report", row.Item("LIS_Blood_Report"))
                        Command.Parameters.AddWithValue("@LIS_Blood_Report_Time", row.Item("LIS_Blood_Report_Time"))
                        Command.Parameters.AddWithValue("@LIS_BMT_Mark", row.Item("LIS_BMT_Mark"))
                        Command.Parameters.AddWithValue("@Student_Id", row.Item("Student_Id"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Is_IPD", row.Item("Is_IPD"))
                        Command.Parameters.AddWithValue("@Is_EMG", row.Item("Is_EMG"))
                        Command.Parameters.AddWithValue("@Patient_Short_Name", row.Item("Patient_Short_Name"))
                        Command.Parameters.AddWithValue("@Reg_Notify_Id", row.Item("Reg_Notify_Id"))
                        Command.Parameters.AddWithValue("@Register_Dist_Code", row.Item("Register_Dist_Code"))
                        Command.Parameters.AddWithValue("@Register_Vil_Code", row.Item("Register_Vil_Code"))
                        Command.Parameters.AddWithValue("@Dist_Code", row.Item("Dist_Code"))
                        Command.Parameters.AddWithValue("@Vil_Code", row.Item("Vil_Code"))
                        Command.Parameters.AddWithValue("@Dist_Code2", row.Item("Dist_Code2"))
                        Command.Parameters.AddWithValue("@Vil_Code2", row.Item("Vil_Code2"))
                        Command.Parameters.AddWithValue("@Not_Scrap", row.Item("Not_Scrap"))
                        Command.Parameters.AddWithValue("@Chart_No_Int", row.Item("Chart_No_Int"))
                        Command.Parameters.AddWithValue("@Info_Confirm", row.Item("Info_Confirm"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                updateBackup(row, conn) '備份機制
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
            " Patient_Name=@Patient_Name , Patient_En_Name=@Patient_En_Name , Idno_Type_Id=@Idno_Type_Id , Idno=@Idno " & _ 
            "  , Birth_Date=@Birth_Date , Sex_Id=@Sex_Id , Blood_Type_Id=@Blood_Type_Id , Education_Id=@Education_Id , Marriage_Id=@Marriage_Id " & _ 
            "  , Job_Id=@Job_Id , Nationality_Id=@Nationality_Id , Race_Id=@Race_Id , Area_Code=@Area_Code , Register_Postal_Code=@Register_Postal_Code " & _ 
            "  , Register_Address=@Register_Address , Postal_Code=@Postal_Code , Address=@Address , Tel_Home=@Tel_Home , Tel_Office=@Tel_Office " & _ 
            "  , Tel_Mobile=@Tel_Mobile , Fax=@Fax , Email=@Email , Postal_Code2=@Postal_Code2 , Address2=@Address2 " & _ 
            "  , Tel2=@Tel2 , Tel2_Mobile=@Tel2_Mobile , Email2=@Email2 , First_Visit_Date=@First_Visit_Date , Latest_Visit_Date=@Latest_Visit_Date " & _ 
            "  , Latest_Admission_Date=@Latest_Admission_Date , Latest_Discharge_Date=@Latest_Discharge_Date , Ipd_Times=@Ipd_Times , Latest_Xray_Date=@Latest_Xray_Date , Latest_CT_Date=@Latest_CT_Date " & _ 
            "  , Arrears_Times=@Arrears_Times , Opd_Arrears_Amt=@Opd_Arrears_Amt , Emg_Arrears_Amt=@Emg_Arrears_Amt , Ipd_Arrears_Amt=@Ipd_Arrears_Amt , Measure_Time=@Measure_Time " & _ 
            "  , Latest_Height=@Latest_Height , Latest_Weight=@Latest_Weight , Mis_Register_Date1=@Mis_Register_Date1 , Mis_Register_Date2=@Mis_Register_Date2 , Mis_Register_Date3=@Mis_Register_Date3 " & _ 
            "  , Mis_Register_Times=@Mis_Register_Times , Mis_Register_End_Date=@Mis_Register_End_Date , Is_Death=@Is_Death , Death_Time=@Death_Time , Is_Chart_Divide=@Is_Chart_Divide " & _ 
            "  , Is_Chart_Image=@Is_Chart_Image , Patient_Memo=@Patient_Memo , Is_Employee=@Is_Employee , Reserve_Chart_No=@Reserve_Chart_No , Latest_LMP_Date=@Latest_LMP_Date " & _ 
            "  , LIS_Blood_Report=@LIS_Blood_Report , LIS_Blood_Report_Time=@LIS_Blood_Report_Time , LIS_BMT_Mark=@LIS_BMT_Mark , Student_Id=@Student_Id , Modified_User=@Modified_User , Modified_Time=@Modified_Time , Is_IPD=@Is_IPD , Is_EMG=@Is_EMG " & _ 
            "  , Patient_Short_Name=@Patient_Short_Name , Reg_Notify_Id=@Reg_Notify_Id , Register_Dist_Code=@Register_Dist_Code , Register_Vil_Code=@Register_Vil_Code , Dist_Code=@Dist_Code " & _ 
            "  , Vil_Code=@Vil_Code , Dist_Code2=@Dist_Code2 , Vil_Code2=@Vil_Code2 , Not_Scrap=@Not_Scrap , Chart_No_Int=@Chart_No_Int " & _ 
            "  , Info_Confirm=@Info_Confirm " & _ 
            " where  Chart_No=@Chart_No            "
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
                        Command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        Command.Parameters.AddWithValue("@Patient_Name", row.Item("Patient_Name"))
                        Command.Parameters.AddWithValue("@Patient_En_Name", row.Item("Patient_En_Name"))
                        Command.Parameters.AddWithValue("@Idno_Type_Id", row.Item("Idno_Type_Id"))
                        Command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        Command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        Command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                        Command.Parameters.AddWithValue("@Blood_Type_Id", row.Item("Blood_Type_Id"))
                        Command.Parameters.AddWithValue("@Education_Id", row.Item("Education_Id"))
                        Command.Parameters.AddWithValue("@Marriage_Id", row.Item("Marriage_Id"))
                        Command.Parameters.AddWithValue("@Job_Id", row.Item("Job_Id"))
                        Command.Parameters.AddWithValue("@Nationality_Id", row.Item("Nationality_Id"))
                        Command.Parameters.AddWithValue("@Race_Id", row.Item("Race_Id"))
                        Command.Parameters.AddWithValue("@Area_Code", row.Item("Area_Code"))
                        Command.Parameters.AddWithValue("@Register_Postal_Code", row.Item("Register_Postal_Code"))
                        Command.Parameters.AddWithValue("@Register_Address", row.Item("Register_Address"))
                        Command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                        Command.Parameters.AddWithValue("@Address", row.Item("Address"))
                        Command.Parameters.AddWithValue("@Tel_Home", row.Item("Tel_Home"))
                        Command.Parameters.AddWithValue("@Tel_Office", row.Item("Tel_Office"))
                        Command.Parameters.AddWithValue("@Tel_Mobile", row.Item("Tel_Mobile"))
                        Command.Parameters.AddWithValue("@Fax", row.Item("Fax"))
                        Command.Parameters.AddWithValue("@Email", row.Item("Email"))
                        Command.Parameters.AddWithValue("@Postal_Code2", row.Item("Postal_Code2"))
                        Command.Parameters.AddWithValue("@Address2", row.Item("Address2"))
                        Command.Parameters.AddWithValue("@Tel2", row.Item("Tel2"))
                        Command.Parameters.AddWithValue("@Tel2_Mobile", row.Item("Tel2_Mobile"))
                        Command.Parameters.AddWithValue("@Email2", row.Item("Email2"))
                        Command.Parameters.AddWithValue("@First_Visit_Date", row.Item("First_Visit_Date"))
                        Command.Parameters.AddWithValue("@Latest_Visit_Date", row.Item("Latest_Visit_Date"))
                        Command.Parameters.AddWithValue("@Latest_Admission_Date", row.Item("Latest_Admission_Date"))
                        Command.Parameters.AddWithValue("@Latest_Discharge_Date", row.Item("Latest_Discharge_Date"))
                        Command.Parameters.AddWithValue("@Ipd_Times", row.Item("Ipd_Times"))
                        Command.Parameters.AddWithValue("@Latest_Xray_Date", row.Item("Latest_Xray_Date"))
                        Command.Parameters.AddWithValue("@Latest_CT_Date", row.Item("Latest_CT_Date"))
                        Command.Parameters.AddWithValue("@Arrears_Times", row.Item("Arrears_Times"))
                        Command.Parameters.AddWithValue("@Opd_Arrears_Amt", row.Item("Opd_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Emg_Arrears_Amt", row.Item("Emg_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Ipd_Arrears_Amt", row.Item("Ipd_Arrears_Amt"))
                        Command.Parameters.AddWithValue("@Measure_Time", row.Item("Measure_Time"))
                        Command.Parameters.AddWithValue("@Latest_Height", row.Item("Latest_Height"))
                        Command.Parameters.AddWithValue("@Latest_Weight", row.Item("Latest_Weight"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date1", row.Item("Mis_Register_Date1"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date2", row.Item("Mis_Register_Date2"))
                        Command.Parameters.AddWithValue("@Mis_Register_Date3", row.Item("Mis_Register_Date3"))
                        Command.Parameters.AddWithValue("@Mis_Register_Times", row.Item("Mis_Register_Times"))
                        Command.Parameters.AddWithValue("@Mis_Register_End_Date", row.Item("Mis_Register_End_Date"))
                        Command.Parameters.AddWithValue("@Is_Death", row.Item("Is_Death"))
                        Command.Parameters.AddWithValue("@Death_Time", row.Item("Death_Time"))
                        Command.Parameters.AddWithValue("@Is_Chart_Divide", row.Item("Is_Chart_Divide"))
                        Command.Parameters.AddWithValue("@Is_Chart_Image", row.Item("Is_Chart_Image"))
                        Command.Parameters.AddWithValue("@Patient_Memo", row.Item("Patient_Memo"))
                        Command.Parameters.AddWithValue("@Is_Employee", row.Item("Is_Employee"))
                        Command.Parameters.AddWithValue("@Reserve_Chart_No", row.Item("Reserve_Chart_No"))
                        Command.Parameters.AddWithValue("@Latest_LMP_Date", row.Item("Latest_LMP_Date"))
                        Command.Parameters.AddWithValue("@LIS_Blood_Report", row.Item("LIS_Blood_Report"))
                        Command.Parameters.AddWithValue("@LIS_Blood_Report_Time", row.Item("LIS_Blood_Report_Time"))
                        Command.Parameters.AddWithValue("@LIS_BMT_Mark", row.Item("LIS_BMT_Mark"))
                        Command.Parameters.AddWithValue("@Student_Id", row.Item("Student_Id"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Is_IPD", row.Item("Is_IPD"))
                        Command.Parameters.AddWithValue("@Is_EMG", row.Item("Is_EMG"))
                        Command.Parameters.AddWithValue("@Patient_Short_Name", row.Item("Patient_Short_Name"))
                        Command.Parameters.AddWithValue("@Reg_Notify_Id", row.Item("Reg_Notify_Id"))
                        Command.Parameters.AddWithValue("@Register_Dist_Code", row.Item("Register_Dist_Code"))
                        Command.Parameters.AddWithValue("@Register_Vil_Code", row.Item("Register_Vil_Code"))
                        Command.Parameters.AddWithValue("@Dist_Code", row.Item("Dist_Code"))
                        Command.Parameters.AddWithValue("@Vil_Code", row.Item("Vil_Code"))
                        Command.Parameters.AddWithValue("@Dist_Code2", row.Item("Dist_Code2"))
                        Command.Parameters.AddWithValue("@Vil_Code2", row.Item("Vil_Code2"))
                        Command.Parameters.AddWithValue("@Not_Scrap", row.Item("Not_Scrap"))
                        Command.Parameters.AddWithValue("@Chart_No_Int", row.Item("Chart_No_Int"))
                        Command.Parameters.AddWithValue("@Info_Confirm", row.Item("Info_Confirm"))
                        Dim cnt As Integer = Command.ExecuteNonQuery
                        count = count + cnt
                  End Using
                updateBackup(row, conn) '備份機制
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
    Public Function delete(ByRef pk_Chart_No As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Chart_No=@Chart_No "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
                  deleteBackup(pk_Chart_No,conn) '備份機制
                Using command As SqlCommand = New SqlCommand
                With Command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                Command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)
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
    Public Function queryByPK(ByRef pk_Chart_No As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Chart_No , Patient_Name , Patient_En_Name , Idno_Type_Id , Idno ,  ") 
            content.AppendLine(" Birth_Date , Sex_Id , Blood_Type_Id , Education_Id , Marriage_Id ,  ") 
            content.AppendLine(" Job_Id , Nationality_Id , Race_Id , Area_Code , Register_Postal_Code ,  ") 
            content.AppendLine(" Register_Address , Postal_Code , Address , Tel_Home , Tel_Office ,  ") 
            content.AppendLine(" Tel_Mobile , Fax , Email , Postal_Code2 , Address2 ,  ") 
            content.AppendLine(" Tel2 , Tel2_Mobile , Email2 , First_Visit_Date , Latest_Visit_Date ,  ") 
            content.AppendLine(" Latest_Admission_Date , Latest_Discharge_Date , Ipd_Times , Latest_Xray_Date , Latest_CT_Date ,  ") 
            content.AppendLine(" Arrears_Times , Opd_Arrears_Amt , Emg_Arrears_Amt , Ipd_Arrears_Amt , Measure_Time ,  ") 
            content.AppendLine(" Latest_Height , Latest_Weight , Mis_Register_Date1 , Mis_Register_Date2 , Mis_Register_Date3 ,  ") 
            content.AppendLine(" Mis_Register_Times , Mis_Register_End_Date , Is_Death , Death_Time , Is_Chart_Divide ,  ") 
            content.AppendLine(" Is_Chart_Image , Patient_Memo , Is_Employee , Reserve_Chart_No , Latest_LMP_Date ,  ") 
            content.AppendLine(" LIS_Blood_Report , LIS_Blood_Report_Time , LIS_BMT_Mark , Student_Id , Create_User ,  ") 
            content.AppendLine(" Create_Time , Modified_User , Modified_Time , Is_IPD , Is_EMG ,  ") 
            content.AppendLine(" Patient_Short_Name , Reg_Notify_Id , Register_Dist_Code , Register_Vil_Code , Dist_Code ,  ") 
            content.AppendLine(" Vil_Code , Dist_Code2 , Vil_Code2 , Not_Scrap , Chart_No_Int ,  ") 
            content.AppendLine(" Info_Confirm                from " & tableName)
            content.AppendLine("   where Chart_No=@Chart_No            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Chart_No",pk_Chart_No)
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
    Public Function queryByLikePK(ByRef pk_Chart_No As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Chart_No , Patient_Name , Patient_En_Name , Idno_Type_Id , Idno ,  ") 
            content.AppendLine(" Birth_Date , Sex_Id , Blood_Type_Id , Education_Id , Marriage_Id ,  ") 
            content.AppendLine(" Job_Id , Nationality_Id , Race_Id , Area_Code , Register_Postal_Code ,  ") 
            content.AppendLine(" Register_Address , Postal_Code , Address , Tel_Home , Tel_Office ,  ") 
            content.AppendLine(" Tel_Mobile , Fax , Email , Postal_Code2 , Address2 ,  ") 
            content.AppendLine(" Tel2 , Tel2_Mobile , Email2 , First_Visit_Date , Latest_Visit_Date ,  ") 
            content.AppendLine(" Latest_Admission_Date , Latest_Discharge_Date , Ipd_Times , Latest_Xray_Date , Latest_CT_Date ,  ") 
            content.AppendLine(" Arrears_Times , Opd_Arrears_Amt , Emg_Arrears_Amt , Ipd_Arrears_Amt , Measure_Time ,  ") 
            content.AppendLine(" Latest_Height , Latest_Weight , Mis_Register_Date1 , Mis_Register_Date2 , Mis_Register_Date3 ,  ") 
            content.AppendLine(" Mis_Register_Times , Mis_Register_End_Date , Is_Death , Death_Time , Is_Chart_Divide ,  ") 
            content.AppendLine(" Is_Chart_Image , Patient_Memo , Is_Employee , Reserve_Chart_No , Latest_LMP_Date ,  ") 
            content.AppendLine(" LIS_Blood_Report , LIS_Blood_Report_Time , LIS_BMT_Mark , Student_Id , Create_User ,  ") 
            content.AppendLine(" Create_Time , Modified_User , Modified_Time , Is_IPD , Is_EMG ,  ") 
            content.AppendLine(" Patient_Short_Name , Reg_Notify_Id , Register_Dist_Code , Register_Vil_Code , Dist_Code ,  ") 
            content.AppendLine(" Vil_Code , Dist_Code2 , Vil_Code2 , Not_Scrap , Chart_No_Int ,  ") 
            content.AppendLine(" Info_Confirm                from " & tableName)
            content.AppendLine("   where Chart_No like @Chart_No "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Chart_No",pk_Chart_No & "%")
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
            content.AppendLine(" Chart_No , Patient_Name , Patient_En_Name , Idno_Type_Id , Idno ,  ") 
            content.AppendLine(" Birth_Date , Sex_Id , Blood_Type_Id , Education_Id , Marriage_Id ,  ") 
            content.AppendLine(" Job_Id , Nationality_Id , Race_Id , Area_Code , Register_Postal_Code ,  ") 
            content.AppendLine(" Register_Address , Postal_Code , Address , Tel_Home , Tel_Office ,  ") 
            content.AppendLine(" Tel_Mobile , Fax , Email , Postal_Code2 , Address2 ,  ") 
            content.AppendLine(" Tel2 , Tel2_Mobile , Email2 , First_Visit_Date , Latest_Visit_Date ,  ") 
            content.AppendLine(" Latest_Admission_Date , Latest_Discharge_Date , Ipd_Times , Latest_Xray_Date , Latest_CT_Date ,  ") 
            content.AppendLine(" Arrears_Times , Opd_Arrears_Amt , Emg_Arrears_Amt , Ipd_Arrears_Amt , Measure_Time ,  ") 
            content.AppendLine(" Latest_Height , Latest_Weight , Mis_Register_Date1 , Mis_Register_Date2 , Mis_Register_Date3 ,  ") 
            content.AppendLine(" Mis_Register_Times , Mis_Register_End_Date , Is_Death , Death_Time , Is_Chart_Divide ,  ") 
            content.AppendLine(" Is_Chart_Image , Patient_Memo , Is_Employee , Reserve_Chart_No , Latest_LMP_Date ,  ") 
            content.AppendLine(" LIS_Blood_Report , LIS_Blood_Report_Time , LIS_BMT_Mark , Student_Id , Create_User ,  ") 
            content.AppendLine(" Create_Time , Modified_User , Modified_Time , Is_IPD , Is_EMG ,  ") 
            content.AppendLine(" Patient_Short_Name , Reg_Notify_Id , Register_Dist_Code , Register_Vil_Code , Dist_Code ,  ") 
            content.AppendLine(" Vil_Code , Dist_Code2 , Vil_Code2 , Not_Scrap , Chart_No_Int ,  ") 
            content.AppendLine(" Info_Confirm                from " & tableName )
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
            content.Append("select   Chart_No , Patient_Name , Patient_En_Name , Idno_Type_Id , Idno ,  " & _ 
             " Birth_Date , Sex_Id , Blood_Type_Id , Education_Id , Marriage_Id ,  " & _ 
             " Job_Id , Nationality_Id , Race_Id , Area_Code , Register_Postal_Code ,  " & _ 
             " Register_Address , Postal_Code , Address , Tel_Home , Tel_Office ,  " & _ 
             " Tel_Mobile , Fax , Email , Postal_Code2 , Address2 ,  " & _ 
             " Tel2 , Tel2_Mobile , Email2 , First_Visit_Date , Latest_Visit_Date ,  " & _ 
             " Latest_Admission_Date , Latest_Discharge_Date , Ipd_Times , Latest_Xray_Date , Latest_CT_Date ,  " & _ 
             " Arrears_Times , Opd_Arrears_Amt , Emg_Arrears_Amt , Ipd_Arrears_Amt , Measure_Time ,  " & _ 
             " Latest_Height , Latest_Weight , Mis_Register_Date1 , Mis_Register_Date2 , Mis_Register_Date3 ,  " & _ 
             " Mis_Register_Times , Mis_Register_End_Date , Is_Death , Death_Time , Is_Chart_Divide ,  " & _ 
             " Is_Chart_Image , Patient_Memo , Is_Employee , Reserve_Chart_No , Latest_LMP_Date ,  " & _ 
             " LIS_Blood_Report , LIS_Blood_Report_Time , LIS_BMT_Mark , Student_Id , Create_User ,  " & _ 
             " Create_Time , Modified_User , Modified_Time , Is_IPD , Is_EMG ,  " & _ 
             " Patient_Short_Name , Reg_Notify_Id , Register_Dist_Code , Register_Vil_Code , Dist_Code ,  " & _ 
             " Vil_Code , Dist_Code2 , Vil_Code2 , Not_Scrap , Chart_No_Int ,  " & _ 
             " Info_Confirm            from " & tableName & " where 1=1 ")
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

#Region " 備份"

    ''' <summary>
    '''取得資料庫備份表格的 DataTable 加上各欄位的資料型態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTableBKWithSchema() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName & "_BK")
            dt.Columns.Add("Action")
            dt.Columns("Action").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Backup_Time")
            dt.Columns("Backup_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Chart_No")
            dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Patient_Name")
            dt.Columns("Patient_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Patient_En_Name")
            dt.Columns("Patient_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Idno_Type_Id")
            dt.Columns("Idno_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Idno")
            dt.Columns("Idno").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Birth_Date")
            dt.Columns("Birth_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Sex_Id")
            dt.Columns("Sex_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Blood_Type_Id")
            dt.Columns("Blood_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Education_Id")
            dt.Columns("Education_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Marriage_Id")
            dt.Columns("Marriage_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Job_Id")
            dt.Columns("Job_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nationality_Id")
            dt.Columns("Nationality_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Race_Id")
            dt.Columns("Race_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Area_Code")
            dt.Columns("Area_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Register_Postal_Code")
            dt.Columns("Register_Postal_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Register_Address")
            dt.Columns("Register_Address").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Postal_Code")
            dt.Columns("Postal_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Address")
            dt.Columns("Address").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tel_Home")
            dt.Columns("Tel_Home").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tel_Office")
            dt.Columns("Tel_Office").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tel_Mobile")
            dt.Columns("Tel_Mobile").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fax")
            dt.Columns("Fax").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Email")
            dt.Columns("Email").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Postal_Code2")
            dt.Columns("Postal_Code2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Address2")
            dt.Columns("Address2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tel2")
            dt.Columns("Tel2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tel2_Mobile")
            dt.Columns("Tel2_Mobile").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Email2")
            dt.Columns("Email2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("First_Visit_Date")
            dt.Columns("First_Visit_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Latest_Visit_Date")
            dt.Columns("Latest_Visit_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Latest_Admission_Date")
            dt.Columns("Latest_Admission_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Latest_Discharge_Date")
            dt.Columns("Latest_Discharge_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Ipd_Times")
            dt.Columns("Ipd_Times").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Latest_Xray_Date")
            dt.Columns("Latest_Xray_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Latest_CT_Date")
            dt.Columns("Latest_CT_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Arrears_Times")
            dt.Columns("Arrears_Times").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Opd_Arrears_Amt")
            dt.Columns("Opd_Arrears_Amt").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Emg_Arrears_Amt")
            dt.Columns("Emg_Arrears_Amt").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Ipd_Arrears_Amt")
            dt.Columns("Ipd_Arrears_Amt").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Measure_Time")
            dt.Columns("Measure_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Latest_Height")
            dt.Columns("Latest_Height").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Latest_Weight")
            dt.Columns("Latest_Weight").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Mis_Register_Date1")
            dt.Columns("Mis_Register_Date1").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Mis_Register_Date2")
            dt.Columns("Mis_Register_Date2").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Mis_Register_Date3")
            dt.Columns("Mis_Register_Date3").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Mis_Register_Times")
            dt.Columns("Mis_Register_Times").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Mis_Register_End_Date")
            dt.Columns("Mis_Register_End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Is_Death")
            dt.Columns("Is_Death").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Death_Time")
            dt.Columns("Death_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Is_Chart_Divide")
            dt.Columns("Is_Chart_Divide").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Chart_Image")
            dt.Columns("Is_Chart_Image").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Patient_Memo")
            dt.Columns("Patient_Memo").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Employee")
            dt.Columns("Is_Employee").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Reserve_Chart_No")
            dt.Columns("Reserve_Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Latest_LMP_Date")
            dt.Columns("Latest_LMP_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("LIS_Blood_Report")
            dt.Columns("LIS_Blood_Report").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("LIS_Blood_Report_Time")
            dt.Columns("LIS_Blood_Report_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("LIS_BMT_Mark")
            dt.Columns("LIS_BMT_Mark").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Student_Id")
            dt.Columns("Student_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Is_IPD")
            dt.Columns("Is_IPD").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_EMG")
            dt.Columns("Is_EMG").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Patient_Short_Name")
            dt.Columns("Patient_Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Reg_Notify_Id")
            dt.Columns("Reg_Notify_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Register_Dist_Code")
            dt.Columns("Register_Dist_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Register_Vil_Code")
            dt.Columns("Register_Vil_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dist_Code")
            dt.Columns("Dist_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Vil_Code")
            dt.Columns("Vil_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dist_Code2")
            dt.Columns("Dist_Code2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Vil_Code2")
            dt.Columns("Vil_Code2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Not_Scrap")
            dt.Columns("Not_Scrap").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Chart_No_Int")
            dt.Columns("Chart_No_Int").DataType = System.Type.GetType("System.Int64")
            dt.Columns.Add("Info_Confirm")
            dt.Columns("Info_Confirm").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(2) = dt.Columns("Chart_No")
            pkColArray(0) = dt.Columns("Action")
            pkColArray(1) = dt.Columns("Backup_Time")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

    
        ''' <summary>
        ''' 備份新增資料
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Protected Sub insertBackup(ByVal row As DataRow, ByRef conn As System.Data.IDbConnection )
            dataBackup("Insert", row, conn)
        End Sub
    
    
        ''' <summary>
        ''' 備份新增資料
        ''' </summary>
        ''' <param name="table"></param>
        ''' <remarks></remarks>
        Protected Sub insertBackupTable(ByVal table As DataTable, ByRef conn As System.Data.IDbConnection )
            If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
                For Each row In table.Rows
                    insertBackup(row, conn)
                Next
            End If
        End Sub
    
    
        ''' <summary>
        ''' 備份更新資料
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Protected Sub updateBackup(ByVal row As DataRow, Optional ByRef conn As System.Data.IDbConnection = Nothing)
            dataBackup("Update", row, conn)
        End Sub
    
    
        ''' <summary>
        ''' 備份更新資料
        ''' </summary>
        ''' <param name="table"></param>
        ''' <remarks></remarks>
        Protected Sub updateBackupTable(ByVal table As DataTable, ByRef conn As System.Data.IDbConnection )
            If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
                For Each row In table.Rows
                    updateBackup(row, conn)
                Next
            End If
        End Sub
    
    
        ''' <summary>
        ''' 備份主程式
        ''' </summary>
        ''' <param name="action"></param>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Protected Sub dataBackup(ByRef action As String, ByRef row As DataRow, ByRef conn As System.Data.IDbConnection )
            Dim bkDS = New DataSet
            Dim bkTable = getDataTableBKWithSchema()
            Dim bkRow = bkTable.NewRow()
            bkRow("Action") = action
            bkRow("Backup_Time") = Now
                bkRow("Chart_No") = row.Item("Chart_No")
                bkRow("Patient_Name") = row.Item("Patient_Name")
                bkRow("Patient_En_Name") = row.Item("Patient_En_Name")
                bkRow("Idno_Type_Id") = row.Item("Idno_Type_Id")
                bkRow("Idno") = row.Item("Idno")
                bkRow("Birth_Date") = row.Item("Birth_Date")
                bkRow("Sex_Id") = row.Item("Sex_Id")
                bkRow("Blood_Type_Id") = row.Item("Blood_Type_Id")
                bkRow("Education_Id") = row.Item("Education_Id")
                bkRow("Marriage_Id") = row.Item("Marriage_Id")
                bkRow("Job_Id") = row.Item("Job_Id")
                bkRow("Nationality_Id") = row.Item("Nationality_Id")
                bkRow("Race_Id") = row.Item("Race_Id")
                bkRow("Area_Code") = row.Item("Area_Code")
                bkRow("Register_Postal_Code") = row.Item("Register_Postal_Code")
                bkRow("Register_Address") = row.Item("Register_Address")
                bkRow("Postal_Code") = row.Item("Postal_Code")
                bkRow("Address") = row.Item("Address")
                bkRow("Tel_Home") = row.Item("Tel_Home")
                bkRow("Tel_Office") = row.Item("Tel_Office")
                bkRow("Tel_Mobile") = row.Item("Tel_Mobile")
                bkRow("Fax") = row.Item("Fax")
                bkRow("Email") = row.Item("Email")
                bkRow("Postal_Code2") = row.Item("Postal_Code2")
                bkRow("Address2") = row.Item("Address2")
                bkRow("Tel2") = row.Item("Tel2")
                bkRow("Tel2_Mobile") = row.Item("Tel2_Mobile")
                bkRow("Email2") = row.Item("Email2")
                bkRow("First_Visit_Date") = row.Item("First_Visit_Date")
                bkRow("Latest_Visit_Date") = row.Item("Latest_Visit_Date")
                bkRow("Latest_Admission_Date") = row.Item("Latest_Admission_Date")
                bkRow("Latest_Discharge_Date") = row.Item("Latest_Discharge_Date")
                bkRow("Ipd_Times") = row.Item("Ipd_Times")
                bkRow("Latest_Xray_Date") = row.Item("Latest_Xray_Date")
                bkRow("Latest_CT_Date") = row.Item("Latest_CT_Date")
                bkRow("Arrears_Times") = row.Item("Arrears_Times")
                bkRow("Opd_Arrears_Amt") = row.Item("Opd_Arrears_Amt")
                bkRow("Emg_Arrears_Amt") = row.Item("Emg_Arrears_Amt")
                bkRow("Ipd_Arrears_Amt") = row.Item("Ipd_Arrears_Amt")
                bkRow("Measure_Time") = row.Item("Measure_Time")
                bkRow("Latest_Height") = row.Item("Latest_Height")
                bkRow("Latest_Weight") = row.Item("Latest_Weight")
                bkRow("Mis_Register_Date1") = row.Item("Mis_Register_Date1")
                bkRow("Mis_Register_Date2") = row.Item("Mis_Register_Date2")
                bkRow("Mis_Register_Date3") = row.Item("Mis_Register_Date3")
                bkRow("Mis_Register_Times") = row.Item("Mis_Register_Times")
                bkRow("Mis_Register_End_Date") = row.Item("Mis_Register_End_Date")
                bkRow("Is_Death") = row.Item("Is_Death")
                bkRow("Death_Time") = row.Item("Death_Time")
                bkRow("Is_Chart_Divide") = row.Item("Is_Chart_Divide")
                bkRow("Is_Chart_Image") = row.Item("Is_Chart_Image")
                bkRow("Patient_Memo") = row.Item("Patient_Memo")
                bkRow("Is_Employee") = row.Item("Is_Employee")
                bkRow("Reserve_Chart_No") = row.Item("Reserve_Chart_No")
                bkRow("Latest_LMP_Date") = row.Item("Latest_LMP_Date")
                bkRow("LIS_Blood_Report") = row.Item("LIS_Blood_Report")
                bkRow("LIS_Blood_Report_Time") = row.Item("LIS_Blood_Report_Time")
                bkRow("LIS_BMT_Mark") = row.Item("LIS_BMT_Mark")
                bkRow("Student_Id") = row.Item("Student_Id")
                bkRow("Create_User") = row.Item("Create_User")
                bkRow("Create_Time") = row.Item("Create_Time")
                bkRow("Modified_User") = row.Item("Modified_User")
                bkRow("Modified_Time") = row.Item("Modified_Time")
                bkRow("Is_IPD") = row.Item("Is_IPD")
                bkRow("Is_EMG") = row.Item("Is_EMG")
                bkRow("Patient_Short_Name") = row.Item("Patient_Short_Name")
                bkRow("Reg_Notify_Id") = row.Item("Reg_Notify_Id")
                bkRow("Register_Dist_Code") = row.Item("Register_Dist_Code")
                bkRow("Register_Vil_Code") = row.Item("Register_Vil_Code")
                bkRow("Dist_Code") = row.Item("Dist_Code")
                bkRow("Vil_Code") = row.Item("Vil_Code")
                bkRow("Dist_Code2") = row.Item("Dist_Code2")
                bkRow("Vil_Code2") = row.Item("Vil_Code2")
                bkRow("Not_Scrap") = row.Item("Not_Scrap")
                bkRow("Chart_No_Int") = row.Item("Chart_No_Int")
                bkRow("Info_Confirm") = row.Item("Info_Confirm")
            bkTable.Rows.Add(bkRow)
            bkDS.Tables.Add(bkTable)
            If bkDS.Tables(0).Rows.Count > 0 Then
                Try
                   Dim Content As New StringBuilder
                   Content.AppendLine("	 Insert Into " & tableName & "_BK (Action,Backup_Time")
                          Content.AppendLine("      , Chart_No")
                          Content.AppendLine("      , Patient_Name")
                          Content.AppendLine("      , Patient_En_Name")
                          Content.AppendLine("      , Idno_Type_Id")
                          Content.AppendLine("      , Idno")
                          Content.AppendLine("      , Birth_Date")
                          Content.AppendLine("      , Sex_Id")
                          Content.AppendLine("      , Blood_Type_Id")
                          Content.AppendLine("      , Education_Id")
                          Content.AppendLine("      , Marriage_Id")
                          Content.AppendLine("      , Job_Id")
                          Content.AppendLine("      , Nationality_Id")
                          Content.AppendLine("      , Race_Id")
                          Content.AppendLine("      , Area_Code")
                          Content.AppendLine("      , Register_Postal_Code")
                          Content.AppendLine("      , Register_Address")
                          Content.AppendLine("      , Postal_Code")
                          Content.AppendLine("      , Address")
                          Content.AppendLine("      , Tel_Home")
                          Content.AppendLine("      , Tel_Office")
                          Content.AppendLine("      , Tel_Mobile")
                          Content.AppendLine("      , Fax")
                          Content.AppendLine("      , Email")
                          Content.AppendLine("      , Postal_Code2")
                          Content.AppendLine("      , Address2")
                          Content.AppendLine("      , Tel2")
                          Content.AppendLine("      , Tel2_Mobile")
                          Content.AppendLine("      , Email2")
                          Content.AppendLine("      , First_Visit_Date")
                          Content.AppendLine("      , Latest_Visit_Date")
                          Content.AppendLine("      , Latest_Admission_Date")
                          Content.AppendLine("      , Latest_Discharge_Date")
                          Content.AppendLine("      , Ipd_Times")
                          Content.AppendLine("      , Latest_Xray_Date")
                          Content.AppendLine("      , Latest_CT_Date")
                          Content.AppendLine("      , Arrears_Times")
                          Content.AppendLine("      , Opd_Arrears_Amt")
                          Content.AppendLine("      , Emg_Arrears_Amt")
                          Content.AppendLine("      , Ipd_Arrears_Amt")
                          Content.AppendLine("      , Measure_Time")
                          Content.AppendLine("      , Latest_Height")
                          Content.AppendLine("      , Latest_Weight")
                          Content.AppendLine("      , Mis_Register_Date1")
                          Content.AppendLine("      , Mis_Register_Date2")
                          Content.AppendLine("      , Mis_Register_Date3")
                          Content.AppendLine("      , Mis_Register_Times")
                          Content.AppendLine("      , Mis_Register_End_Date")
                          Content.AppendLine("      , Is_Death")
                          Content.AppendLine("      , Death_Time")
                          Content.AppendLine("      , Is_Chart_Divide")
                          Content.AppendLine("      , Is_Chart_Image")
                          Content.AppendLine("      , Patient_Memo")
                          Content.AppendLine("      , Is_Employee")
                          Content.AppendLine("      , Reserve_Chart_No")
                          Content.AppendLine("      , Latest_LMP_Date")
                          Content.AppendLine("      , LIS_Blood_Report")
                          Content.AppendLine("      , LIS_Blood_Report_Time")
                          Content.AppendLine("      , LIS_BMT_Mark")
                          Content.AppendLine("      , Student_Id")
                          Content.AppendLine("      , Create_User")
                          Content.AppendLine("      , Create_Time")
                          Content.AppendLine("      , Modified_User")
                          Content.AppendLine("      , Modified_Time")
                          Content.AppendLine("      , Is_IPD")
                          Content.AppendLine("      , Is_EMG")
                          Content.AppendLine("      , Patient_Short_Name")
                          Content.AppendLine("      , Reg_Notify_Id")
                          Content.AppendLine("      , Register_Dist_Code")
                          Content.AppendLine("      , Register_Vil_Code")
                          Content.AppendLine("      , Dist_Code")
                          Content.AppendLine("      , Vil_Code")
                          Content.AppendLine("      , Dist_Code2")
                          Content.AppendLine("      , Vil_Code2")
                          Content.AppendLine("      , Not_Scrap")
                          Content.AppendLine("      , Chart_No_Int")
                          Content.AppendLine("      , Info_Confirm")
                 Content.AppendLine("      )")
                 Content.AppendLine("Select '" & action & "','" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "' ,* From " & tableName & " Where 1=1 ")
                 Content.AppendLine("   And Chart_No=@Chart_No")
                Using Command As SqlCommand = conn.CreateCommand
                    Command.CommandText = Content.ToString  
                Command.Parameters.AddWithValue("@Chart_No", bkRow("Chart_No"))
                    Dim cnt As Integer = Command.ExecuteNonQuery
                End Using
        Catch ex As Exception
                Dim caller As MethodBase = New StackTrace().GetFrames(1).GetMethod()

                '寫入DBLog
                Dim logConn As IDbConnection = SQLConnFactory.getInstance.getBKDBSqlConn
                logConn.Open()
                Dim command As SqlCommand = New SqlCommand("InsertLog", logConn )
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add("@LOG_Thread", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Level", SqlDbType.VarChar, 50)
                command.Parameters.Add("@LOG_Logger", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Class", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Method", SqlDbType.VarChar, 255)
                command.Parameters.Add("@LOG_Message", SqlDbType.NVarChar, 4000)
                command.Parameters.Add("@LOG_Exception", SqlDbType.NVarChar, 2000)

                command.Parameters("@LOG_Thread").Value = System.Threading.Thread.CurrentThread.ManagedThreadId
                command.Parameters("@LOG_Level").Value = "ERROR"
                command.Parameters("@LOG_Logger").Value = getLoggerName(caller.DeclaringType.FullName)
                command.Parameters("@LOG_Class").Value = "PUBPatientBO.vb"
                command.Parameters("@LOG_Method").Value = "dataBackup"
                command.Parameters("@LOG_Message").Value = "備份失敗:" & bkDS.GetXml
                command.Parameters("@LOG_Exception").Value = ex.StackTrace
                Try
                    command.ExecuteNonQuery()
                Catch logex As Exception
                Finally
                    logConn.Close()
                    logConn.Dispose()
                End Try
        End Try
            End If
        End Sub
    
    
        ''' <summary>
        ''' 備份刪除資料
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks>BO刪除動作要在這個方法之後，不然刪掉就沒資料了可以備份了；有 PKey 而不想太麻煩，用另一個方法，傳入PKey</remarks>
        Protected Sub deleteBackup(ByVal row As DataRow, Optional ByRef conn As System.Data.IDbConnection = Nothing)
                row("Modified_Time") = Now
            dataBackup("Delete", row, conn)
        End Sub
    
    
         ''' <summary>
        ''' 備份刪除資料
        ''' </summary>
        ''' <param name="table"></param>
        ''' <remarks></remarks>
        Protected Sub deleteBackupTable(ByVal table As DataTable, Optional ByRef conn As System.Data.IDbConnection = Nothing)
            If table IsNot Nothing AndAlso table.Rows.Count > 0 Then
                For Each row In table.Rows
                    deleteBackup(row, conn)
                Next
            End If
        End Sub

        ''' <summary>
        ''' 備份刪除資料
        ''' </summary>       
        Protected Sub deleteBackup(ByVal pk_Chart_No As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing)
    
            Dim bkDS As System.Data.DataSet = queryByPK(pk_Chart_No, conn)
            If bkDS IsNot Nothing _
            AndAlso bkDS.Tables.Count > 0 _
            AndAlso bkDS.Tables(0) IsNot Nothing _
            AndAlso bkDS.Tables(0).Rows.Count > 0 _
            AndAlso bkDS.Tables(0).Rows(0) IsNot Nothing _
            Then
                deleteBackup(bkDS.Tables(0).Rows(0), conn) 
            Else
                'Throw New Exception("No Data To Delete")
            End If
        End Sub

#End Region

#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Patient 在所屬資料庫的連線
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getConnection() As IDbConnection
        '請加入SQL Connection 於 SD CodeGen 中
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region
#Region " 取得所屬資料庫的連線"

    ''' <summary>
    '''取得表格 PUB_Patient 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
