Imports System.Data.SqlClient
Imports System.Text
Imports System.ServiceModel
Imports System.Reflection
Imports System.Data
Imports System.Diagnostics
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.SQL

Public Class PubOrderBO
   Inherits Syscom.Comm.LOG.LOGDelegate
    'Syscom's CodeGen Produced This VB Code @ 2017/3/14 上午 10:59:48
    Public Shared ReadOnly tableName As String="PUB_Order"
    Private Shared myInstance As PubOrderBO
    Public Shared Function GetInstance() As PubOrderBO
        If myInstance Is Nothing Then
            myInstance = New PubOrderBO()
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
            " Effect_Date , Order_Code , Order_En_Name , Order_Name , Order_En_Short_Name ,  " & _ 
             " Order_Short_Name , Order_Type_Id , Account_Id , Is_Cure , Cure_Type_Id ,  " & _ 
             " Treatment_Type_Id , Charge_Unit , Nhi_Transrate , Nhi_Unit , Is_Order_Check ,  " & _ 
             " Fix_Order_Id , Is_Exclude_Drug , Order_Note , Order_Memo , Is_Agree_Sheet ,  " & _ 
             " Is_Nhi_Sheet , Is_Prior_Review , Is_IC_Card_Order , Is_Order_Price_Special , Dc_Reason ,  " & _ 
             " Dc , End_Date , Create_User , Create_Time , Modified_User ,  " & _ 
             " Modified_Time , Old_Order_Code , Material_Used_Cnt , Include_Order_Mark , Insu_Cover_Opd ,  " & _ 
             " Insu_Cover_Emg , Insu_Cover_Ipd , Is_Icd_Check , Is_Emg_Nursing_Charge , Majorcare_Code ,  " & _ 
             " Cost_Price , Is_Alternative ) " & _ 
             " values( @Effect_Date , @Order_Code , @Order_En_Name , @Order_Name , @Order_En_Short_Name ,  " & _ 
             " @Order_Short_Name , @Order_Type_Id , @Account_Id , @Is_Cure , @Cure_Type_Id ,  " & _ 
             " @Treatment_Type_Id , @Charge_Unit , @Nhi_Transrate , @Nhi_Unit , @Is_Order_Check ,  " & _ 
             " @Fix_Order_Id , @Is_Exclude_Drug , @Order_Note , @Order_Memo , @Is_Agree_Sheet ,  " & _ 
             " @Is_Nhi_Sheet , @Is_Prior_Review , @Is_IC_Card_Order , @Is_Order_Price_Special , @Dc_Reason ,  " & _ 
             " @Dc , @End_Date , @Create_User , @Create_Time , @Modified_User ,  " & _ 
             " @Modified_Time , @Old_Order_Code , @Material_Used_Cnt , @Include_Order_Mark , @Insu_Cover_Opd ,  " & _ 
             " @Insu_Cover_Emg , @Insu_Cover_Ipd , @Is_Icd_Check , @Is_Emg_Nursing_Charge , @Majorcare_Code ,  " & _ 
             " @Cost_Price , @Is_Alternative             )"
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
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Order_En_Name", row.Item("Order_En_Name"))
                        Command.Parameters.AddWithValue("@Order_Name", row.Item("Order_Name"))
                        Command.Parameters.AddWithValue("@Order_En_Short_Name", row.Item("Order_En_Short_Name"))
                        Command.Parameters.AddWithValue("@Order_Short_Name", row.Item("Order_Short_Name"))
                        Command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                        Command.Parameters.AddWithValue("@Account_Id", row.Item("Account_Id"))
                        Command.Parameters.AddWithValue("@Is_Cure", row.Item("Is_Cure"))
                        Command.Parameters.AddWithValue("@Cure_Type_Id", row.Item("Cure_Type_Id"))
                        Command.Parameters.AddWithValue("@Treatment_Type_Id", row.Item("Treatment_Type_Id"))
                        Command.Parameters.AddWithValue("@Charge_Unit", row.Item("Charge_Unit"))
                        Command.Parameters.AddWithValue("@Nhi_Transrate", row.Item("Nhi_Transrate"))
                        Command.Parameters.AddWithValue("@Nhi_Unit", row.Item("Nhi_Unit"))
                        Command.Parameters.AddWithValue("@Is_Order_Check", row.Item("Is_Order_Check"))
                        Command.Parameters.AddWithValue("@Fix_Order_Id", row.Item("Fix_Order_Id"))
                        Command.Parameters.AddWithValue("@Is_Exclude_Drug", row.Item("Is_Exclude_Drug"))
                        Command.Parameters.AddWithValue("@Order_Note", row.Item("Order_Note"))
                        Command.Parameters.AddWithValue("@Order_Memo", row.Item("Order_Memo"))
                        Command.Parameters.AddWithValue("@Is_Agree_Sheet", row.Item("Is_Agree_Sheet"))
                        Command.Parameters.AddWithValue("@Is_Nhi_Sheet", row.Item("Is_Nhi_Sheet"))
                        Command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                        Command.Parameters.AddWithValue("@Is_IC_Card_Order", row.Item("Is_IC_Card_Order"))
                        Command.Parameters.AddWithValue("@Is_Order_Price_Special", row.Item("Is_Order_Price_Special"))
                        Command.Parameters.AddWithValue("@Dc_Reason", row.Item("Dc_Reason"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Old_Order_Code", row.Item("Old_Order_Code"))
                        Command.Parameters.AddWithValue("@Material_Used_Cnt", row.Item("Material_Used_Cnt"))
                        Command.Parameters.AddWithValue("@Include_Order_Mark", row.Item("Include_Order_Mark"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Opd", row.Item("Insu_Cover_Opd"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Emg", row.Item("Insu_Cover_Emg"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Ipd", row.Item("Insu_Cover_Ipd"))
                        Command.Parameters.AddWithValue("@Is_Icd_Check", row.Item("Is_Icd_Check"))
                        Command.Parameters.AddWithValue("@Is_Emg_Nursing_Charge", row.Item("Is_Emg_Nursing_Charge"))
                        Command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                        Command.Parameters.AddWithValue("@Cost_Price", row.Item("Cost_Price"))
                        Command.Parameters.AddWithValue("@Is_Alternative", row.Item("Is_Alternative"))
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
            " Effect_Date , Order_Code , Order_En_Name , Order_Name , Order_En_Short_Name ,  " & _ 
             " Order_Short_Name , Order_Type_Id , Account_Id , Is_Cure , Cure_Type_Id ,  " & _ 
             " Treatment_Type_Id , Charge_Unit , Nhi_Transrate , Nhi_Unit , Is_Order_Check ,  " & _ 
             " Fix_Order_Id , Is_Exclude_Drug , Order_Note , Order_Memo , Is_Agree_Sheet ,  " & _ 
             " Is_Nhi_Sheet , Is_Prior_Review , Is_IC_Card_Order , Is_Order_Price_Special , Dc_Reason ,  " & _ 
             " Dc , End_Date , Create_User , Create_Time , Modified_User ,  " & _ 
             " Modified_Time , Old_Order_Code , Material_Used_Cnt , Include_Order_Mark , Insu_Cover_Opd ,  " & _ 
             " Insu_Cover_Emg , Insu_Cover_Ipd , Is_Icd_Check , Is_Emg_Nursing_Charge , Majorcare_Code ,  " & _ 
             " Cost_Price , Is_Alternative ) " & _ 
             " values( @Effect_Date , @Order_Code , @Order_En_Name , @Order_Name , @Order_En_Short_Name ,  " & _ 
             " @Order_Short_Name , @Order_Type_Id , @Account_Id , @Is_Cure , @Cure_Type_Id ,  " & _ 
             " @Treatment_Type_Id , @Charge_Unit , @Nhi_Transrate , @Nhi_Unit , @Is_Order_Check ,  " & _ 
             " @Fix_Order_Id , @Is_Exclude_Drug , @Order_Note , @Order_Memo , @Is_Agree_Sheet ,  " & _ 
             " @Is_Nhi_Sheet , @Is_Prior_Review , @Is_IC_Card_Order , @Is_Order_Price_Special , @Dc_Reason ,  " & _ 
             " @Dc , @End_Date , @Create_User , @Create_Time , @Modified_User ,  " & _ 
             " @Modified_Time , @Old_Order_Code , @Material_Used_Cnt , @Include_Order_Mark , @Insu_Cover_Opd ,  " & _ 
             " @Insu_Cover_Emg , @Insu_Cover_Ipd , @Is_Icd_Check , @Is_Emg_Nursing_Charge , @Majorcare_Code ,  " & _ 
             " @Cost_Price , @Is_Alternative             )"
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
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Order_En_Name", row.Item("Order_En_Name"))
                        Command.Parameters.AddWithValue("@Order_Name", row.Item("Order_Name"))
                        Command.Parameters.AddWithValue("@Order_En_Short_Name", row.Item("Order_En_Short_Name"))
                        Command.Parameters.AddWithValue("@Order_Short_Name", row.Item("Order_Short_Name"))
                        Command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                        Command.Parameters.AddWithValue("@Account_Id", row.Item("Account_Id"))
                        Command.Parameters.AddWithValue("@Is_Cure", row.Item("Is_Cure"))
                        Command.Parameters.AddWithValue("@Cure_Type_Id", row.Item("Cure_Type_Id"))
                        Command.Parameters.AddWithValue("@Treatment_Type_Id", row.Item("Treatment_Type_Id"))
                        Command.Parameters.AddWithValue("@Charge_Unit", row.Item("Charge_Unit"))
                        Command.Parameters.AddWithValue("@Nhi_Transrate", row.Item("Nhi_Transrate"))
                        Command.Parameters.AddWithValue("@Nhi_Unit", row.Item("Nhi_Unit"))
                        Command.Parameters.AddWithValue("@Is_Order_Check", row.Item("Is_Order_Check"))
                        Command.Parameters.AddWithValue("@Fix_Order_Id", row.Item("Fix_Order_Id"))
                        Command.Parameters.AddWithValue("@Is_Exclude_Drug", row.Item("Is_Exclude_Drug"))
                        Command.Parameters.AddWithValue("@Order_Note", row.Item("Order_Note"))
                        Command.Parameters.AddWithValue("@Order_Memo", row.Item("Order_Memo"))
                        Command.Parameters.AddWithValue("@Is_Agree_Sheet", row.Item("Is_Agree_Sheet"))
                        Command.Parameters.AddWithValue("@Is_Nhi_Sheet", row.Item("Is_Nhi_Sheet"))
                        Command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                        Command.Parameters.AddWithValue("@Is_IC_Card_Order", row.Item("Is_IC_Card_Order"))
                        Command.Parameters.AddWithValue("@Is_Order_Price_Special", row.Item("Is_Order_Price_Special"))
                        Command.Parameters.AddWithValue("@Dc_Reason", row.Item("Dc_Reason"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", currentTime)
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Old_Order_Code", row.Item("Old_Order_Code"))
                        Command.Parameters.AddWithValue("@Material_Used_Cnt", row.Item("Material_Used_Cnt"))
                        Command.Parameters.AddWithValue("@Include_Order_Mark", row.Item("Include_Order_Mark"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Opd", row.Item("Insu_Cover_Opd"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Emg", row.Item("Insu_Cover_Emg"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Ipd", row.Item("Insu_Cover_Ipd"))
                        Command.Parameters.AddWithValue("@Is_Icd_Check", row.Item("Is_Icd_Check"))
                        Command.Parameters.AddWithValue("@Is_Emg_Nursing_Charge", row.Item("Is_Emg_Nursing_Charge"))
                        Command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                        Command.Parameters.AddWithValue("@Cost_Price", row.Item("Cost_Price"))
                        Command.Parameters.AddWithValue("@Is_Alternative", row.Item("Is_Alternative"))
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
            " Effect_Date , Order_Code , Order_En_Name , Order_Name , Order_En_Short_Name ,  " & _ 
             " Order_Short_Name , Order_Type_Id , Account_Id , Is_Cure , Cure_Type_Id ,  " & _ 
             " Treatment_Type_Id , Charge_Unit , Nhi_Transrate , Nhi_Unit , Is_Order_Check ,  " & _ 
             " Fix_Order_Id , Is_Exclude_Drug , Order_Note , Order_Memo , Is_Agree_Sheet ,  " & _ 
             " Is_Nhi_Sheet , Is_Prior_Review , Is_IC_Card_Order , Is_Order_Price_Special , Dc_Reason ,  " & _ 
             " Dc , End_Date , Create_User , Create_Time , Modified_User ,  " & _ 
             " Modified_Time , Old_Order_Code , Material_Used_Cnt , Include_Order_Mark , Insu_Cover_Opd ,  " & _ 
             " Insu_Cover_Emg , Insu_Cover_Ipd , Is_Icd_Check , Is_Emg_Nursing_Charge , Majorcare_Code ,  " & _ 
             " Cost_Price , Is_Alternative ) " & _ 
             " values( @Effect_Date , @Order_Code , @Order_En_Name , @Order_Name , @Order_En_Short_Name ,  " & _ 
             " @Order_Short_Name , @Order_Type_Id , @Account_Id , @Is_Cure , @Cure_Type_Id ,  " & _ 
             " @Treatment_Type_Id , @Charge_Unit , @Nhi_Transrate , @Nhi_Unit , @Is_Order_Check ,  " & _ 
             " @Fix_Order_Id , @Is_Exclude_Drug , @Order_Note , @Order_Memo , @Is_Agree_Sheet ,  " & _ 
             " @Is_Nhi_Sheet , @Is_Prior_Review , @Is_IC_Card_Order , @Is_Order_Price_Special , @Dc_Reason ,  " & _ 
             " @Dc , @End_Date , @Create_User , @Create_Time , @Modified_User ,  " & _ 
             " @Modified_Time , @Old_Order_Code , @Material_Used_Cnt , @Include_Order_Mark , @Insu_Cover_Opd ,  " & _ 
             " @Insu_Cover_Emg , @Insu_Cover_Ipd , @Is_Icd_Check , @Is_Emg_Nursing_Charge , @Majorcare_Code ,  " & _ 
             " @Cost_Price , @Is_Alternative             )"
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
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Order_En_Name", row.Item("Order_En_Name"))
                        Command.Parameters.AddWithValue("@Order_Name", row.Item("Order_Name"))
                        Command.Parameters.AddWithValue("@Order_En_Short_Name", row.Item("Order_En_Short_Name"))
                        Command.Parameters.AddWithValue("@Order_Short_Name", row.Item("Order_Short_Name"))
                        Command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                        Command.Parameters.AddWithValue("@Account_Id", row.Item("Account_Id"))
                        Command.Parameters.AddWithValue("@Is_Cure", row.Item("Is_Cure"))
                        Command.Parameters.AddWithValue("@Cure_Type_Id", row.Item("Cure_Type_Id"))
                        Command.Parameters.AddWithValue("@Treatment_Type_Id", row.Item("Treatment_Type_Id"))
                        Command.Parameters.AddWithValue("@Charge_Unit", row.Item("Charge_Unit"))
                        Command.Parameters.AddWithValue("@Nhi_Transrate", row.Item("Nhi_Transrate"))
                        Command.Parameters.AddWithValue("@Nhi_Unit", row.Item("Nhi_Unit"))
                        Command.Parameters.AddWithValue("@Is_Order_Check", row.Item("Is_Order_Check"))
                        Command.Parameters.AddWithValue("@Fix_Order_Id", row.Item("Fix_Order_Id"))
                        Command.Parameters.AddWithValue("@Is_Exclude_Drug", row.Item("Is_Exclude_Drug"))
                        Command.Parameters.AddWithValue("@Order_Note", row.Item("Order_Note"))
                        Command.Parameters.AddWithValue("@Order_Memo", row.Item("Order_Memo"))
                        Command.Parameters.AddWithValue("@Is_Agree_Sheet", row.Item("Is_Agree_Sheet"))
                        Command.Parameters.AddWithValue("@Is_Nhi_Sheet", row.Item("Is_Nhi_Sheet"))
                        Command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                        Command.Parameters.AddWithValue("@Is_IC_Card_Order", row.Item("Is_IC_Card_Order"))
                        Command.Parameters.AddWithValue("@Is_Order_Price_Special", row.Item("Is_Order_Price_Special"))
                        Command.Parameters.AddWithValue("@Dc_Reason", row.Item("Dc_Reason"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Create_User", row.Item("Create_User"))
                        Command.Parameters.AddWithValue("@Create_Time", row.Item("Create_Time"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Old_Order_Code", row.Item("Old_Order_Code"))
                        Command.Parameters.AddWithValue("@Material_Used_Cnt", row.Item("Material_Used_Cnt"))
                        Command.Parameters.AddWithValue("@Include_Order_Mark", row.Item("Include_Order_Mark"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Opd", row.Item("Insu_Cover_Opd"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Emg", row.Item("Insu_Cover_Emg"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Ipd", row.Item("Insu_Cover_Ipd"))
                        Command.Parameters.AddWithValue("@Is_Icd_Check", row.Item("Is_Icd_Check"))
                        Command.Parameters.AddWithValue("@Is_Emg_Nursing_Charge", row.Item("Is_Emg_Nursing_Charge"))
                        Command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                        Command.Parameters.AddWithValue("@Cost_Price", row.Item("Cost_Price"))
                        Command.Parameters.AddWithValue("@Is_Alternative", row.Item("Is_Alternative"))
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
            " Order_En_Name=@Order_En_Name , Order_Name=@Order_Name , Order_En_Short_Name=@Order_En_Short_Name " & _ 
            "  , Order_Short_Name=@Order_Short_Name , Order_Type_Id=@Order_Type_Id , Account_Id=@Account_Id , Is_Cure=@Is_Cure , Cure_Type_Id=@Cure_Type_Id " & _ 
            "  , Treatment_Type_Id=@Treatment_Type_Id , Charge_Unit=@Charge_Unit , Nhi_Transrate=@Nhi_Transrate , Nhi_Unit=@Nhi_Unit , Is_Order_Check=@Is_Order_Check " & _ 
            "  , Fix_Order_Id=@Fix_Order_Id , Is_Exclude_Drug=@Is_Exclude_Drug , Order_Note=@Order_Note , Order_Memo=@Order_Memo , Is_Agree_Sheet=@Is_Agree_Sheet " & _ 
            "  , Is_Nhi_Sheet=@Is_Nhi_Sheet , Is_Prior_Review=@Is_Prior_Review , Is_IC_Card_Order=@Is_IC_Card_Order , Is_Order_Price_Special=@Is_Order_Price_Special , Dc_Reason=@Dc_Reason " & _ 
            "  , Dc=@Dc , End_Date=@End_Date , Modified_User=@Modified_User " & _ 
            "  , Modified_Time=@Modified_Time , Old_Order_Code=@Old_Order_Code , Material_Used_Cnt=@Material_Used_Cnt , Include_Order_Mark=@Include_Order_Mark , Insu_Cover_Opd=@Insu_Cover_Opd " & _ 
            "  , Insu_Cover_Emg=@Insu_Cover_Emg , Insu_Cover_Ipd=@Insu_Cover_Ipd , Is_Icd_Check=@Is_Icd_Check , Is_Emg_Nursing_Charge=@Is_Emg_Nursing_Charge , Majorcare_Code=@Majorcare_Code " & _ 
            "  , Cost_Price=@Cost_Price , Is_Alternative=@Is_Alternative " & _ 
            " where  Effect_Date=@Effect_Date and Order_Code=@Order_Code            "
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
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Order_En_Name", row.Item("Order_En_Name"))
                        Command.Parameters.AddWithValue("@Order_Name", row.Item("Order_Name"))
                        Command.Parameters.AddWithValue("@Order_En_Short_Name", row.Item("Order_En_Short_Name"))
                        Command.Parameters.AddWithValue("@Order_Short_Name", row.Item("Order_Short_Name"))
                        Command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                        Command.Parameters.AddWithValue("@Account_Id", row.Item("Account_Id"))
                        Command.Parameters.AddWithValue("@Is_Cure", row.Item("Is_Cure"))
                        Command.Parameters.AddWithValue("@Cure_Type_Id", row.Item("Cure_Type_Id"))
                        Command.Parameters.AddWithValue("@Treatment_Type_Id", row.Item("Treatment_Type_Id"))
                        Command.Parameters.AddWithValue("@Charge_Unit", row.Item("Charge_Unit"))
                        Command.Parameters.AddWithValue("@Nhi_Transrate", row.Item("Nhi_Transrate"))
                        Command.Parameters.AddWithValue("@Nhi_Unit", row.Item("Nhi_Unit"))
                        Command.Parameters.AddWithValue("@Is_Order_Check", row.Item("Is_Order_Check"))
                        Command.Parameters.AddWithValue("@Fix_Order_Id", row.Item("Fix_Order_Id"))
                        Command.Parameters.AddWithValue("@Is_Exclude_Drug", row.Item("Is_Exclude_Drug"))
                        Command.Parameters.AddWithValue("@Order_Note", row.Item("Order_Note"))
                        Command.Parameters.AddWithValue("@Order_Memo", row.Item("Order_Memo"))
                        Command.Parameters.AddWithValue("@Is_Agree_Sheet", row.Item("Is_Agree_Sheet"))
                        Command.Parameters.AddWithValue("@Is_Nhi_Sheet", row.Item("Is_Nhi_Sheet"))
                        Command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                        Command.Parameters.AddWithValue("@Is_IC_Card_Order", row.Item("Is_IC_Card_Order"))
                        Command.Parameters.AddWithValue("@Is_Order_Price_Special", row.Item("Is_Order_Price_Special"))
                        Command.Parameters.AddWithValue("@Dc_Reason", row.Item("Dc_Reason"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Old_Order_Code", row.Item("Old_Order_Code"))
                        Command.Parameters.AddWithValue("@Material_Used_Cnt", row.Item("Material_Used_Cnt"))
                        Command.Parameters.AddWithValue("@Include_Order_Mark", row.Item("Include_Order_Mark"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Opd", row.Item("Insu_Cover_Opd"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Emg", row.Item("Insu_Cover_Emg"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Ipd", row.Item("Insu_Cover_Ipd"))
                        Command.Parameters.AddWithValue("@Is_Icd_Check", row.Item("Is_Icd_Check"))
                        Command.Parameters.AddWithValue("@Is_Emg_Nursing_Charge", row.Item("Is_Emg_Nursing_Charge"))
                        Command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                        Command.Parameters.AddWithValue("@Cost_Price", row.Item("Cost_Price"))
                        Command.Parameters.AddWithValue("@Is_Alternative", row.Item("Is_Alternative"))
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
            " Order_En_Name=@Order_En_Name , Order_Name=@Order_Name , Order_En_Short_Name=@Order_En_Short_Name " & _ 
            "  , Order_Short_Name=@Order_Short_Name , Order_Type_Id=@Order_Type_Id , Account_Id=@Account_Id , Is_Cure=@Is_Cure , Cure_Type_Id=@Cure_Type_Id " & _ 
            "  , Treatment_Type_Id=@Treatment_Type_Id , Charge_Unit=@Charge_Unit , Nhi_Transrate=@Nhi_Transrate , Nhi_Unit=@Nhi_Unit , Is_Order_Check=@Is_Order_Check " & _ 
            "  , Fix_Order_Id=@Fix_Order_Id , Is_Exclude_Drug=@Is_Exclude_Drug , Order_Note=@Order_Note , Order_Memo=@Order_Memo , Is_Agree_Sheet=@Is_Agree_Sheet " & _ 
            "  , Is_Nhi_Sheet=@Is_Nhi_Sheet , Is_Prior_Review=@Is_Prior_Review , Is_IC_Card_Order=@Is_IC_Card_Order , Is_Order_Price_Special=@Is_Order_Price_Special , Dc_Reason=@Dc_Reason " & _ 
            "  , Dc=@Dc , End_Date=@End_Date , Modified_User=@Modified_User " & _ 
            "  , Modified_Time=@Modified_Time , Old_Order_Code=@Old_Order_Code , Material_Used_Cnt=@Material_Used_Cnt , Include_Order_Mark=@Include_Order_Mark , Insu_Cover_Opd=@Insu_Cover_Opd " & _ 
            "  , Insu_Cover_Emg=@Insu_Cover_Emg , Insu_Cover_Ipd=@Insu_Cover_Ipd , Is_Icd_Check=@Is_Icd_Check , Is_Emg_Nursing_Charge=@Is_Emg_Nursing_Charge , Majorcare_Code=@Majorcare_Code " & _ 
            "  , Cost_Price=@Cost_Price , Is_Alternative=@Is_Alternative " & _ 
            " where  Effect_Date=@Effect_Date and Order_Code=@Order_Code            "
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
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Order_En_Name", row.Item("Order_En_Name"))
                        Command.Parameters.AddWithValue("@Order_Name", row.Item("Order_Name"))
                        Command.Parameters.AddWithValue("@Order_En_Short_Name", row.Item("Order_En_Short_Name"))
                        Command.Parameters.AddWithValue("@Order_Short_Name", row.Item("Order_Short_Name"))
                        Command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                        Command.Parameters.AddWithValue("@Account_Id", row.Item("Account_Id"))
                        Command.Parameters.AddWithValue("@Is_Cure", row.Item("Is_Cure"))
                        Command.Parameters.AddWithValue("@Cure_Type_Id", row.Item("Cure_Type_Id"))
                        Command.Parameters.AddWithValue("@Treatment_Type_Id", row.Item("Treatment_Type_Id"))
                        Command.Parameters.AddWithValue("@Charge_Unit", row.Item("Charge_Unit"))
                        Command.Parameters.AddWithValue("@Nhi_Transrate", row.Item("Nhi_Transrate"))
                        Command.Parameters.AddWithValue("@Nhi_Unit", row.Item("Nhi_Unit"))
                        Command.Parameters.AddWithValue("@Is_Order_Check", row.Item("Is_Order_Check"))
                        Command.Parameters.AddWithValue("@Fix_Order_Id", row.Item("Fix_Order_Id"))
                        Command.Parameters.AddWithValue("@Is_Exclude_Drug", row.Item("Is_Exclude_Drug"))
                        Command.Parameters.AddWithValue("@Order_Note", row.Item("Order_Note"))
                        Command.Parameters.AddWithValue("@Order_Memo", row.Item("Order_Memo"))
                        Command.Parameters.AddWithValue("@Is_Agree_Sheet", row.Item("Is_Agree_Sheet"))
                        Command.Parameters.AddWithValue("@Is_Nhi_Sheet", row.Item("Is_Nhi_Sheet"))
                        Command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                        Command.Parameters.AddWithValue("@Is_IC_Card_Order", row.Item("Is_IC_Card_Order"))
                        Command.Parameters.AddWithValue("@Is_Order_Price_Special", row.Item("Is_Order_Price_Special"))
                        Command.Parameters.AddWithValue("@Dc_Reason", row.Item("Dc_Reason"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                        Command.Parameters.AddWithValue("@Old_Order_Code", row.Item("Old_Order_Code"))
                        Command.Parameters.AddWithValue("@Material_Used_Cnt", row.Item("Material_Used_Cnt"))
                        Command.Parameters.AddWithValue("@Include_Order_Mark", row.Item("Include_Order_Mark"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Opd", row.Item("Insu_Cover_Opd"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Emg", row.Item("Insu_Cover_Emg"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Ipd", row.Item("Insu_Cover_Ipd"))
                        Command.Parameters.AddWithValue("@Is_Icd_Check", row.Item("Is_Icd_Check"))
                        Command.Parameters.AddWithValue("@Is_Emg_Nursing_Charge", row.Item("Is_Emg_Nursing_Charge"))
                        Command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                        Command.Parameters.AddWithValue("@Cost_Price", row.Item("Cost_Price"))
                        Command.Parameters.AddWithValue("@Is_Alternative", row.Item("Is_Alternative"))
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
            " Order_En_Name=@Order_En_Name , Order_Name=@Order_Name , Order_En_Short_Name=@Order_En_Short_Name " & _ 
            "  , Order_Short_Name=@Order_Short_Name , Order_Type_Id=@Order_Type_Id , Account_Id=@Account_Id , Is_Cure=@Is_Cure , Cure_Type_Id=@Cure_Type_Id " & _ 
            "  , Treatment_Type_Id=@Treatment_Type_Id , Charge_Unit=@Charge_Unit , Nhi_Transrate=@Nhi_Transrate , Nhi_Unit=@Nhi_Unit , Is_Order_Check=@Is_Order_Check " & _ 
            "  , Fix_Order_Id=@Fix_Order_Id , Is_Exclude_Drug=@Is_Exclude_Drug , Order_Note=@Order_Note , Order_Memo=@Order_Memo , Is_Agree_Sheet=@Is_Agree_Sheet " & _ 
            "  , Is_Nhi_Sheet=@Is_Nhi_Sheet , Is_Prior_Review=@Is_Prior_Review , Is_IC_Card_Order=@Is_IC_Card_Order , Is_Order_Price_Special=@Is_Order_Price_Special , Dc_Reason=@Dc_Reason " & _ 
            "  , Dc=@Dc , End_Date=@End_Date , Modified_User=@Modified_User " & _ 
            "  , Modified_Time=@Modified_Time , Old_Order_Code=@Old_Order_Code , Material_Used_Cnt=@Material_Used_Cnt , Include_Order_Mark=@Include_Order_Mark , Insu_Cover_Opd=@Insu_Cover_Opd " & _ 
            "  , Insu_Cover_Emg=@Insu_Cover_Emg , Insu_Cover_Ipd=@Insu_Cover_Ipd , Is_Icd_Check=@Is_Icd_Check , Is_Emg_Nursing_Charge=@Is_Emg_Nursing_Charge , Majorcare_Code=@Majorcare_Code " & _ 
            "  , Cost_Price=@Cost_Price , Is_Alternative=@Is_Alternative " & _ 
            " where  Effect_Date=@Effect_Date and Order_Code=@Order_Code            "
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
                        Command.Parameters.AddWithValue("@Order_Code", row.Item("Order_Code"))
                        Command.Parameters.AddWithValue("@Order_En_Name", row.Item("Order_En_Name"))
                        Command.Parameters.AddWithValue("@Order_Name", row.Item("Order_Name"))
                        Command.Parameters.AddWithValue("@Order_En_Short_Name", row.Item("Order_En_Short_Name"))
                        Command.Parameters.AddWithValue("@Order_Short_Name", row.Item("Order_Short_Name"))
                        Command.Parameters.AddWithValue("@Order_Type_Id", row.Item("Order_Type_Id"))
                        Command.Parameters.AddWithValue("@Account_Id", row.Item("Account_Id"))
                        Command.Parameters.AddWithValue("@Is_Cure", row.Item("Is_Cure"))
                        Command.Parameters.AddWithValue("@Cure_Type_Id", row.Item("Cure_Type_Id"))
                        Command.Parameters.AddWithValue("@Treatment_Type_Id", row.Item("Treatment_Type_Id"))
                        Command.Parameters.AddWithValue("@Charge_Unit", row.Item("Charge_Unit"))
                        Command.Parameters.AddWithValue("@Nhi_Transrate", row.Item("Nhi_Transrate"))
                        Command.Parameters.AddWithValue("@Nhi_Unit", row.Item("Nhi_Unit"))
                        Command.Parameters.AddWithValue("@Is_Order_Check", row.Item("Is_Order_Check"))
                        Command.Parameters.AddWithValue("@Fix_Order_Id", row.Item("Fix_Order_Id"))
                        Command.Parameters.AddWithValue("@Is_Exclude_Drug", row.Item("Is_Exclude_Drug"))
                        Command.Parameters.AddWithValue("@Order_Note", row.Item("Order_Note"))
                        Command.Parameters.AddWithValue("@Order_Memo", row.Item("Order_Memo"))
                        Command.Parameters.AddWithValue("@Is_Agree_Sheet", row.Item("Is_Agree_Sheet"))
                        Command.Parameters.AddWithValue("@Is_Nhi_Sheet", row.Item("Is_Nhi_Sheet"))
                        Command.Parameters.AddWithValue("@Is_Prior_Review", row.Item("Is_Prior_Review"))
                        Command.Parameters.AddWithValue("@Is_IC_Card_Order", row.Item("Is_IC_Card_Order"))
                        Command.Parameters.AddWithValue("@Is_Order_Price_Special", row.Item("Is_Order_Price_Special"))
                        Command.Parameters.AddWithValue("@Dc_Reason", row.Item("Dc_Reason"))
                        Command.Parameters.AddWithValue("@Dc", row.Item("Dc"))
                        Command.Parameters.AddWithValue("@End_Date", row.Item("End_Date"))
                        Command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        Command.Parameters.AddWithValue("@Modified_Time", currentTime)
                        Command.Parameters.AddWithValue("@Old_Order_Code", row.Item("Old_Order_Code"))
                        Command.Parameters.AddWithValue("@Material_Used_Cnt", row.Item("Material_Used_Cnt"))
                        Command.Parameters.AddWithValue("@Include_Order_Mark", row.Item("Include_Order_Mark"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Opd", row.Item("Insu_Cover_Opd"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Emg", row.Item("Insu_Cover_Emg"))
                        Command.Parameters.AddWithValue("@Insu_Cover_Ipd", row.Item("Insu_Cover_Ipd"))
                        Command.Parameters.AddWithValue("@Is_Icd_Check", row.Item("Is_Icd_Check"))
                        Command.Parameters.AddWithValue("@Is_Emg_Nursing_Charge", row.Item("Is_Emg_Nursing_Charge"))
                        Command.Parameters.AddWithValue("@Majorcare_Code", row.Item("Majorcare_Code"))
                        Command.Parameters.AddWithValue("@Cost_Price", row.Item("Cost_Price"))
                        Command.Parameters.AddWithValue("@Is_Alternative", row.Item("Is_Alternative"))
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
    Public Function delete(ByRef pk_Effect_Date As System.DateTime,ByRef pk_Order_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim count As Integer = 0
            Dim sqlString As String="delete from " & tableName & " where " & _
            " Effect_Date=@Effect_Date and Order_Code=@Order_Code "
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
                  deleteBackup(pk_Effect_Date,pk_Order_Code,conn) '備份機制
                Using command As SqlCommand = New SqlCommand
                With Command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                Command.Parameters.AddWithValue("@Effect_Date", pk_Effect_Date)
                Command.Parameters.AddWithValue("@Order_Code", pk_Order_Code)
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
    Public Function queryByPK(ByRef pk_Effect_Date As System.DateTime,ByRef pk_Order_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Effect_Date , Order_Code , Order_En_Name , Order_Name , Order_En_Short_Name ,  ") 
            content.AppendLine(" Order_Short_Name , Order_Type_Id , Account_Id , Is_Cure , Cure_Type_Id ,  ") 
            content.AppendLine(" Treatment_Type_Id , Charge_Unit , Nhi_Transrate , Nhi_Unit , Is_Order_Check ,  ") 
            content.AppendLine(" Fix_Order_Id , Is_Exclude_Drug , Order_Note , Order_Memo , Is_Agree_Sheet ,  ") 
            content.AppendLine(" Is_Nhi_Sheet , Is_Prior_Review , Is_IC_Card_Order , Is_Order_Price_Special , Dc_Reason ,  ") 
            content.AppendLine(" Dc , End_Date , Create_User , Create_Time , Modified_User ,  ") 
            content.AppendLine(" Modified_Time , Old_Order_Code , Material_Used_Cnt , Include_Order_Mark , Insu_Cover_Opd ,  ") 
            content.AppendLine(" Insu_Cover_Emg , Insu_Cover_Ipd , Is_Icd_Check , Is_Emg_Nursing_Charge , Majorcare_Code ,  ") 
            content.AppendLine(" Cost_Price , Is_Alternative                from " & tableName)
            content.AppendLine("   where Effect_Date=@Effect_Date and Order_Code=@Order_Code            " )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Effect_Date",pk_Effect_Date)
            Command.Parameters.AddWithValue("@Order_Code",pk_Order_Code)
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
    Public Function queryByLikePK(ByRef pk_Effect_Date As System.DateTime,ByRef pk_Order_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Effect_Date , Order_Code , Order_En_Name , Order_Name , Order_En_Short_Name ,  ") 
            content.AppendLine(" Order_Short_Name , Order_Type_Id , Account_Id , Is_Cure , Cure_Type_Id ,  ") 
            content.AppendLine(" Treatment_Type_Id , Charge_Unit , Nhi_Transrate , Nhi_Unit , Is_Order_Check ,  ") 
            content.AppendLine(" Fix_Order_Id , Is_Exclude_Drug , Order_Note , Order_Memo , Is_Agree_Sheet ,  ") 
            content.AppendLine(" Is_Nhi_Sheet , Is_Prior_Review , Is_IC_Card_Order , Is_Order_Price_Special , Dc_Reason ,  ") 
            content.AppendLine(" Dc , End_Date , Create_User , Create_Time , Modified_User ,  ") 
            content.AppendLine(" Modified_Time , Old_Order_Code , Material_Used_Cnt , Include_Order_Mark , Insu_Cover_Opd ,  ") 
            content.AppendLine(" Insu_Cover_Emg , Insu_Cover_Ipd , Is_Icd_Check , Is_Emg_Nursing_Charge , Majorcare_Code ,  ") 
            content.AppendLine(" Cost_Price , Is_Alternative                from " & tableName)
            content.AppendLine("   where Effect_Date like @Effect_Date and Order_Code like @Order_Code "   )
            command.CommandText = content.tostring 
            Command.Parameters.AddWithValue("@Effect_Date",pk_Effect_Date & "%")
            Command.Parameters.AddWithValue("@Order_Code",pk_Order_Code & "%")
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
            content.AppendLine(" Effect_Date , Order_Code , Order_En_Name , Order_Name , Order_En_Short_Name ,  ") 
            content.AppendLine(" Order_Short_Name , Order_Type_Id , Account_Id , Is_Cure , Cure_Type_Id ,  ") 
            content.AppendLine(" Treatment_Type_Id , Charge_Unit , Nhi_Transrate , Nhi_Unit , Is_Order_Check ,  ") 
            content.AppendLine(" Fix_Order_Id , Is_Exclude_Drug , Order_Note , Order_Memo , Is_Agree_Sheet ,  ") 
            content.AppendLine(" Is_Nhi_Sheet , Is_Prior_Review , Is_IC_Card_Order , Is_Order_Price_Special , Dc_Reason ,  ") 
            content.AppendLine(" Dc , End_Date , Create_User , Create_Time , Modified_User ,  ") 
            content.AppendLine(" Modified_Time , Old_Order_Code , Material_Used_Cnt , Include_Order_Mark , Insu_Cover_Opd ,  ") 
            content.AppendLine(" Insu_Cover_Emg , Insu_Cover_Ipd , Is_Icd_Check , Is_Emg_Nursing_Charge , Majorcare_Code ,  ") 
            content.AppendLine(" Cost_Price , Is_Alternative                from " & tableName )
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
            content.Append("select   Effect_Date , Order_Code , Order_En_Name , Order_Name , Order_En_Short_Name ,  " & _ 
             " Order_Short_Name , Order_Type_Id , Account_Id , Is_Cure , Cure_Type_Id ,  " & _ 
             " Treatment_Type_Id , Charge_Unit , Nhi_Transrate , Nhi_Unit , Is_Order_Check ,  " & _ 
             " Fix_Order_Id , Is_Exclude_Drug , Order_Note , Order_Memo , Is_Agree_Sheet ,  " & _ 
             " Is_Nhi_Sheet , Is_Prior_Review , Is_IC_Card_Order , Is_Order_Price_Special , Dc_Reason ,  " & _ 
             " Dc , End_Date , Create_User , Create_Time , Modified_User ,  " & _ 
             " Modified_Time , Old_Order_Code , Material_Used_Cnt , Include_Order_Mark , Insu_Cover_Opd ,  " & _ 
             " Insu_Cover_Emg , Insu_Cover_Ipd , Is_Icd_Check , Is_Emg_Nursing_Charge , Majorcare_Code ,  " & _ 
             " Cost_Price , Is_Alternative            from " & tableName & " where 1=1 ")
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
            dt.Columns.Add("Effect_Date")
            dt.Columns("Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_En_Name")
            dt.Columns("Order_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Name")
            dt.Columns("Order_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_En_Short_Name")
            dt.Columns("Order_En_Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Short_Name")
            dt.Columns("Order_Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Type_Id")
            dt.Columns("Order_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Account_Id")
            dt.Columns("Account_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Cure")
            dt.Columns("Is_Cure").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cure_Type_Id")
            dt.Columns("Cure_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Treatment_Type_Id")
            dt.Columns("Treatment_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Charge_Unit")
            dt.Columns("Charge_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nhi_Transrate")
            dt.Columns("Nhi_Transrate").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Nhi_Unit")
            dt.Columns("Nhi_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Order_Check")
            dt.Columns("Is_Order_Check").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fix_Order_Id")
            dt.Columns("Fix_Order_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Exclude_Drug")
            dt.Columns("Is_Exclude_Drug").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Note")
            dt.Columns("Order_Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Memo")
            dt.Columns("Order_Memo").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Agree_Sheet")
            dt.Columns("Is_Agree_Sheet").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Nhi_Sheet")
            dt.Columns("Is_Nhi_Sheet").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Prior_Review")
            dt.Columns("Is_Prior_Review").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_IC_Card_Order")
            dt.Columns("Is_IC_Card_Order").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Order_Price_Special")
            dt.Columns("Is_Order_Price_Special").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc_Reason")
            dt.Columns("Dc_Reason").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("End_Date")
            dt.Columns("End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Old_Order_Code")
            dt.Columns("Old_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Material_Used_Cnt")
            dt.Columns("Material_Used_Cnt").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Include_Order_Mark")
            dt.Columns("Include_Order_Mark").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Cover_Opd")
            dt.Columns("Insu_Cover_Opd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Cover_Emg")
            dt.Columns("Insu_Cover_Emg").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Cover_Ipd")
            dt.Columns("Insu_Cover_Ipd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Icd_Check")
            dt.Columns("Is_Icd_Check").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Emg_Nursing_Charge")
            dt.Columns("Is_Emg_Nursing_Charge").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Majorcare_Code")
            dt.Columns("Majorcare_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cost_Price")
            dt.Columns("Cost_Price").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Is_Alternative")
            dt.Columns("Is_Alternative").DataType = System.Type.GetType("System.String")
            Dim pkColArray(3) As DataColumn 
            pkColArray(2) = dt.Columns("Effect_Date")
            pkColArray(3) = dt.Columns("Order_Code")
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
                bkRow("Effect_Date") = row.Item("Effect_Date")
                bkRow("Order_Code") = row.Item("Order_Code")
                bkRow("Order_En_Name") = row.Item("Order_En_Name")
                bkRow("Order_Name") = row.Item("Order_Name")
                bkRow("Order_En_Short_Name") = row.Item("Order_En_Short_Name")
                bkRow("Order_Short_Name") = row.Item("Order_Short_Name")
                bkRow("Order_Type_Id") = row.Item("Order_Type_Id")
                bkRow("Account_Id") = row.Item("Account_Id")
                bkRow("Is_Cure") = row.Item("Is_Cure")
                bkRow("Cure_Type_Id") = row.Item("Cure_Type_Id")
                bkRow("Treatment_Type_Id") = row.Item("Treatment_Type_Id")
                bkRow("Charge_Unit") = row.Item("Charge_Unit")
                bkRow("Nhi_Transrate") = row.Item("Nhi_Transrate")
                bkRow("Nhi_Unit") = row.Item("Nhi_Unit")
                bkRow("Is_Order_Check") = row.Item("Is_Order_Check")
                bkRow("Fix_Order_Id") = row.Item("Fix_Order_Id")
                bkRow("Is_Exclude_Drug") = row.Item("Is_Exclude_Drug")
                bkRow("Order_Note") = row.Item("Order_Note")
                bkRow("Order_Memo") = row.Item("Order_Memo")
                bkRow("Is_Agree_Sheet") = row.Item("Is_Agree_Sheet")
                bkRow("Is_Nhi_Sheet") = row.Item("Is_Nhi_Sheet")
                bkRow("Is_Prior_Review") = row.Item("Is_Prior_Review")
                bkRow("Is_IC_Card_Order") = row.Item("Is_IC_Card_Order")
                bkRow("Is_Order_Price_Special") = row.Item("Is_Order_Price_Special")
                bkRow("Dc_Reason") = row.Item("Dc_Reason")
                bkRow("Dc") = row.Item("Dc")
                bkRow("End_Date") = row.Item("End_Date")
                bkRow("Create_User") = row.Item("Create_User")
                bkRow("Create_Time") = row.Item("Create_Time")
                bkRow("Modified_User") = row.Item("Modified_User")
                bkRow("Modified_Time") = row.Item("Modified_Time")
                bkRow("Old_Order_Code") = row.Item("Old_Order_Code")
                bkRow("Material_Used_Cnt") = row.Item("Material_Used_Cnt")
                bkRow("Include_Order_Mark") = row.Item("Include_Order_Mark")
                bkRow("Insu_Cover_Opd") = row.Item("Insu_Cover_Opd")
                bkRow("Insu_Cover_Emg") = row.Item("Insu_Cover_Emg")
                bkRow("Insu_Cover_Ipd") = row.Item("Insu_Cover_Ipd")
                bkRow("Is_Icd_Check") = row.Item("Is_Icd_Check")
                bkRow("Is_Emg_Nursing_Charge") = row.Item("Is_Emg_Nursing_Charge")
                bkRow("Majorcare_Code") = row.Item("Majorcare_Code")
                bkRow("Cost_Price") = row.Item("Cost_Price")
                bkRow("Is_Alternative") = row.Item("Is_Alternative")
            bkTable.Rows.Add(bkRow)
            bkDS.Tables.Add(bkTable)
            If bkDS.Tables(0).Rows.Count > 0 Then
                Try
                   Dim Content As New StringBuilder
                   Content.AppendLine("	 Insert Into " & tableName & "_BK (Action,Backup_Time")
                          Content.AppendLine("      , Effect_Date")
                          Content.AppendLine("      , Order_Code")
                          Content.AppendLine("      , Order_En_Name")
                          Content.AppendLine("      , Order_Name")
                          Content.AppendLine("      , Order_En_Short_Name")
                          Content.AppendLine("      , Order_Short_Name")
                          Content.AppendLine("      , Order_Type_Id")
                          Content.AppendLine("      , Account_Id")
                          Content.AppendLine("      , Is_Cure")
                          Content.AppendLine("      , Cure_Type_Id")
                          Content.AppendLine("      , Treatment_Type_Id")
                          Content.AppendLine("      , Charge_Unit")
                          Content.AppendLine("      , Nhi_Transrate")
                          Content.AppendLine("      , Nhi_Unit")
                          Content.AppendLine("      , Is_Order_Check")
                          Content.AppendLine("      , Fix_Order_Id")
                          Content.AppendLine("      , Is_Exclude_Drug")
                          Content.AppendLine("      , Order_Note")
                          Content.AppendLine("      , Order_Memo")
                          Content.AppendLine("      , Is_Agree_Sheet")
                          Content.AppendLine("      , Is_Nhi_Sheet")
                          Content.AppendLine("      , Is_Prior_Review")
                          Content.AppendLine("      , Is_IC_Card_Order")
                          Content.AppendLine("      , Is_Order_Price_Special")
                          Content.AppendLine("      , Dc_Reason")
                          Content.AppendLine("      , Dc")
                          Content.AppendLine("      , End_Date")
                          Content.AppendLine("      , Create_User")
                          Content.AppendLine("      , Create_Time")
                          Content.AppendLine("      , Modified_User")
                          Content.AppendLine("      , Modified_Time")
                          Content.AppendLine("      , Old_Order_Code")
                          Content.AppendLine("      , Material_Used_Cnt")
                          Content.AppendLine("      , Include_Order_Mark")
                          Content.AppendLine("      , Insu_Cover_Opd")
                          Content.AppendLine("      , Insu_Cover_Emg")
                          Content.AppendLine("      , Insu_Cover_Ipd")
                          Content.AppendLine("      , Is_Icd_Check")
                          Content.AppendLine("      , Is_Emg_Nursing_Charge")
                          Content.AppendLine("      , Majorcare_Code")
                          Content.AppendLine("      , Cost_Price")
                          Content.AppendLine("      , Is_Alternative")
                 Content.AppendLine("      )")
                 Content.AppendLine("Select '" & action & "','" & Now.ToString("yyyy/MM/dd HH:mm:ss") & "' ,* From " & tableName & " Where 1=1 ")
                 Content.AppendLine("   And Effect_Date=@Effect_Date")
                 Content.AppendLine("   And Order_Code=@Order_Code")
                Using Command As SqlCommand = conn.CreateCommand
                    Command.CommandText = Content.ToString  
                Command.Parameters.AddWithValue("@Effect_Date", bkRow("Effect_Date"))
                Command.Parameters.AddWithValue("@Order_Code", bkRow("Order_Code"))
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
                command.Parameters("@LOG_Class").Value = "PUBOrderBO.vb"
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
        Protected Sub deleteBackup(ByVal pk_Effect_Date As System.DateTime,ByVal pk_Order_Code As System.String,Optional ByRef conn As System.Data.IDbConnection = Nothing)
    
            Dim bkDS As System.Data.DataSet = queryByPK(pk_Effect_Date,pk_Order_Code, conn)
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
    '''取得表格 PUB_Order 在所屬資料庫的連線
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
    '''取得表格 PUB_Order 在實體位置的資料庫連線，用在新增、修改、刪除、即時查詢的功能上 
    ''' </summary>
    ''' <returns>資料庫連線</returns>
    ''' <remarks></remarks>
    Public Function getAuthenticConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function 
#End Region


End Class
