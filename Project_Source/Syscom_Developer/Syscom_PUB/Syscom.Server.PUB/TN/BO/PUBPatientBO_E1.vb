Imports System.Data.SqlClient
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text

Public Class PUBPatientBO_E1
    Inherits PubPatientBO

#Region "########## getInstance ##########"
    Private Shared instance As PUBPatientBO_E1
    Public Overloads Shared Function getInstance() As PUBPatientBO_E1
        If instance Is Nothing Then
            instance = New PUBPatientBO_E1
        End If
        Return instance
    End Function
    Private Sub New()
    End Sub
#End Region

    'Private Shared instance As PUBPatientBO_E1
    'Dim tableName1 As String = "PUB_Patient"

    'Public Shared Function getInstance() As PUBPatientBO_E1
    '    If instance Is Nothing Then
    '        instance = New PUBPatientBO_E1
    '    End If

    '    Return instance
    'End Function
    'Private Sub New()
    'End Sub


    '清空病歷主檔爽約欄位資料
    Public Function ClearPatientMisRegister(ByVal chartNo As String) As Integer  'Implements IPUBPatientBO.queryPubChartNoByKey

        Dim count As Integer = 0
        Try
            Dim updateSql As String = "UPDATE PUB_Patient SET Mis_Register_Date1=null, Mis_Register_Date2=null, Mis_Register_Date3=null, Mis_Register_Times=null, Mis_Register_End_Date=null WHERE Chart_No='" & chartNo & "' "


            Using conn As System.Data.IDbConnection = getConnection()
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = updateSql
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With

                    conn.Open()
                    count = command.ExecuteNonQuery
                End Using
            End Using

            Return count
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePat(ByVal ds As System.Data.DataSet) As Integer
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Patient_Name=@Patient_Name , Idno=@Idno , Birth_Date=@Birth_Date " & _
            "  , Sex_Id=@Sex_Id " & _
            "  , Nationality_Id=@Nationality_Id , Race_Id=@Race_Id , Area_Code=@Area_Code , Register_Postal_Code=@Register_Postal_Code , Register_Address=@Register_Address " & _
            "  , Postal_Code=@Postal_Code , Address=@Address , Tel_Home=@Tel_Home , Tel_Mobile=@Tel_Mobile " & _
            "   , Email=@Email" & _
            "  ,  Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            " where  Chart_No=@Chart_No            "
            Using conn As System.Data.IDbConnection = getConnection()
                conn.Open()
                For Each row As DataRow In ds.Tables(tableName).Rows
                    Using command As SqlCommand = New SqlCommand
                        With command
                            .CommandText = sqlString
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                        End With
                        command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        command.Parameters.AddWithValue("@Patient_Name", row.Item("Patient_Name"))
                        command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                        command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                        command.Parameters.AddWithValue("@Sex_Id", row.Item("Sex_Id"))
                        command.Parameters.AddWithValue("@Nationality_Id", row.Item("Nationality_Id"))
                        command.Parameters.AddWithValue("@Race_Id", row.Item("Race_Id"))
                        command.Parameters.AddWithValue("@Area_Code", row.Item("Area_Code"))
                        command.Parameters.AddWithValue("@Register_Postal_Code", row.Item("Register_Postal_Code"))
                        command.Parameters.AddWithValue("@Register_Address", row.Item("Register_Address"))
                        command.Parameters.AddWithValue("@Postal_Code", row.Item("Postal_Code"))
                        command.Parameters.AddWithValue("@Address", row.Item("Address"))
                        command.Parameters.AddWithValue("@Tel_Home", row.Item("Tel_Home"))
                        command.Parameters.AddWithValue("@Tel_Mobile", row.Item("Tel_Mobile"))
                        command.Parameters.AddWithValue("@Email", row.Item("Email"))
                        command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        command.Parameters.AddWithValue("@Modified_Time", Now)
                        Dim cnt As Integer = command.ExecuteNonQuery
                        count = count + cnt
                    End Using
                Next
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        End Try
    End Function

    ''' <summary>
    '''更新病人聯絡資料
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePatContactInfo(ByVal ds As System.Data.DataSet) As Integer
        Try
            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            "  Patient_Name=@Patient_Name,Register_Address=@Register_Address " & _
            "  , Address=@Address , Tel_Home=@Tel_Home , Tel_Mobile=@Tel_Mobile " & _
            "  ,  Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            " where  Chart_No=@Chart_No            "
            Using conn As System.Data.IDbConnection = getConnection()
                conn.Open()
                For Each row As DataRow In ds.Tables(tableName).Rows
                    Using command As SqlCommand = New SqlCommand
                        With command
                            .CommandText = sqlString
                            .CommandType = CommandType.Text
                            .Connection = CType(conn, SqlConnection)
                        End With
                        command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                        command.Parameters.AddWithValue("@Patient_Name", row.Item("Patient_Name"))
                        command.Parameters.AddWithValue("@Register_Address", row.Item("Register_Address"))
                        command.Parameters.AddWithValue("@Address", row.Item("Address"))
                        command.Parameters.AddWithValue("@Tel_Home", row.Item("Tel_Home"))
                        command.Parameters.AddWithValue("@Tel_Mobile", row.Item("Tel_Mobile"))
                        command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                        command.Parameters.AddWithValue("@Modified_Time", Now)
                        Dim cnt As Integer = command.ExecuteNonQuery
                        count = count + cnt
                    End Using
                Next
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        End Try
    End Function


    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePUBPatientByDS(ByVal ds As System.Data.DataSet) As Integer
        Try
            Dim count As Integer = 0

            If ds.Tables(0).Rows(0).Item("UpdateItem").ToString.Trim = "ICCBaby" Then



                Dim sqlString As String = "update " & tableName & " set " & _
                " Patient_Name=@Patient_Name , Idno=@Idno , Birth_Date=@Birth_Date " & _
                "  ,  Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
                " where  Chart_No=@Chart_No            "
                Using conn As System.Data.IDbConnection = getConnection()
                    conn.Open()
                    For Each row As DataRow In ds.Tables(tableName).Rows
                        Using command As SqlCommand = New SqlCommand
                            With command
                                .CommandText = sqlString
                                .CommandType = CommandType.Text
                                .Connection = CType(conn, SqlConnection)
                            End With
                            command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                            command.Parameters.AddWithValue("@Patient_Name", row.Item("Patient_Name"))
                            command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                            command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                            command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                            command.Parameters.AddWithValue("@Modified_Time", Now)
                            Dim cnt As Integer = command.ExecuteNonQuery
                            count = count + cnt
                        End Using
                    Next
                End Using

            End If


            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        End Try
    End Function

    ''' <summary>
    ''' 診間更新病患身高體重 
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <param name="Height">身高</param>
    ''' <param name="Weight">體重</param>
    ''' <param name="userId">更新者ID</param>
    ''' <remarks></remarks>
    Public Function updatePubPatientHeightWeightLMP(ByVal ChartNo As String, ByVal Height As String, ByVal Weight As String, ByVal Latest_LMP_Date As String, ByVal userId As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try

            Dim Latest_Height As Integer
            Dim Latest_Weight As Integer


            If Height = "" Then

            Else
                Latest_Height = CInt(Height)
            End If


            If Weight = "" Then

            Else
                Latest_Weight = CInt(Weight)
            End If

            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set " & _
            " Latest_Height=@Latest_Height , Latest_Weight=@Latest_Weight , Measure_Time=@Measure_Time, Latest_LMP_Date=@Latest_LMP_Date " & _
            "  ,  Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            " where  Chart_No=@Chart_No            "

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            'Using conn As System.Data.IDbConnection = getConnection()
            'conn.Open()

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Chart_No", ChartNo.Trim)

                If Height <> "" Then
                    command.Parameters.AddWithValue("@Latest_Height", CDec(Height.Trim))

                Else
                    command.Parameters.AddWithValue("@Latest_Height", DBNull.Value)

                End If


                If Weight <> "" Then
                    command.Parameters.AddWithValue("@Latest_Weight", CDec(Weight.Trim))
                Else
                    command.Parameters.AddWithValue("@Latest_Weight", DBNull.Value)
                End If


                If Latest_LMP_Date <> "" Then
                    command.Parameters.AddWithValue("@Latest_LMP_Date", Latest_LMP_Date)
                Else
                    command.Parameters.AddWithValue("@Latest_LMP_Date", DBNull.Value)
                End If


                command.Parameters.AddWithValue("@Measure_Time", Now)
                command.Parameters.AddWithValue("@Modified_User", userId)
                command.Parameters.AddWithValue("@Modified_Time", Now)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            'End Using
            Return count
        Catch sqlex As SqlException
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



    Public Function queryPubChartNoByKey(ByVal codeNo As String, ByVal codeType As String) As DataSet 'Implements IPUBPatientBO.queryPubChartNoByKey

        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn

        Dim cmdStr As String = ""
        Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
        Dim command As SqlCommand = sqlConn.CreateCommand()
        Dim myReader As SqlDataReader = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim ds1, ds2 As DataSet

        Try
            codeNo = codeNo.Replace("'", "")
            If codeType = "IdNo" Then
                command.CommandText = "select * from  " & tableName & " where Idno like '" & codeNo & "%' ORDER BY Reserve_Chart_No "

            ElseIf codeType = "ChartNo" Then
                command.CommandText = "select * from  " & tableName & " where Chart_No ='" & codeNo & "' "

            ElseIf codeType = "PatientName" Then
                command.CommandText = "select * from  " & tableName & " where Patient_Name like '" & codeNo & "%' order by Birth_Date "

            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds1 = New DataSet(tableName)
                adapter.Fill(ds1, tableName)
                adapter.FillSchema(ds1, SchemaType.Mapped, tableName)
            End Using

            command.CommandText = "select PP.Patient_Name,PP.Email , PP.Chart_No,PP.Idno,PP.Birth_Date ,PP.Sex_Id,PP.Nationality_Id,PP.Race_Id,PP.Register_Address,PP.Address,PP.Tel_Home,PP.Tel_Mobile,PP.Register_Postal_Code  ,PPC.Patient_Contact_No ,PPC.Contact_Name,PPC.Contact_Address ,PPC.Contact_Tel_Home from  " & tableName & " as PP left join PUB_Patient_Contact as PPC on PPC.Chart_No=PP.Chart_No  where PP.Chart_No ='" & codeNo & "' AND PPC.Patient_Contact_No =(SELECT MAX(PPC1.Patient_Contact_No) FROM PUB_Patient_Contact  AS ppc1  WHERE ppc1.Chart_No='" & codeNo & "')"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds2 = New DataSet("Patient_Contact")
                adapter.Fill(ds2, "Patient_Contact")
                adapter.FillSchema(ds2, SchemaType.Mapped, "Patient_Contact")
            End Using

            Dim mergeDs As DataSet = New DataSet
            mergeDs.Merge(ds1)
            mergeDs.Merge(ds2)

            Return mergeDs


        Catch ex As SqlClient.SqlException
            Throw ex
        Finally
            conn.Close()
        End Try

    End Function


    Public Function initUI(ByVal select1 As Integer) As DataSet
        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn

        Dim SqlCmd As SqlCommand
        Dim cmdStr As String = ""
        Dim myReader As SqlDataReader = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim ds As DataSet

        Try
            Select Case select1
                '性別
                Case 0
                    cmdStr = "select PS.Code_Id,PS.Code_Name From PUB_Syscode AS PS WHERE PS.Type_Id='21'"
                    '縣市
                Case 1
                    cmdStr = "select PS.Code_Id,PS.Code_Name From PUB_Syscode AS PS WHERE PS.Type_Id='37'"
                    '國別
                Case 2
                    cmdStr = "select PS.Code_Id,PS.Code_Name From PUB_Syscode AS PS WHERE PS.Type_Id='22'"




            End Select
            ds = New DataSet("resultDB")

            If cmdStr <> "" Then
                conn.Open()
                SqlCmd = New SqlCommand(cmdStr, conn)
                da = New SqlDataAdapter(New SqlCommand(cmdStr, conn))
                da.FillSchema(ds, SchemaType.Source, "resulttable")
                da.Fill(ds.Tables("resulttable"))
            End If


        Catch ex As SqlClient.SqlException
            Throw ex
        Finally
            conn.Close()
            conn.Dispose()
        End Try

        Return ds

    End Function


    ''' <summary>
    ''' 程式說明：取得病歷號讀取病患基本檔
    ''' 開發人員：Jen
    ''' 開發日期：2009.08.23
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Patirnt
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/08/23, XXX
    ''' </修改註記>
    Public Function queryPatientBasicInfo(ByVal ChartNo As String) As DataTable

        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select * ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("from PUB_Patient ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where Chart_No = @ChartNo ")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        Try
            Dim dt As DataTable = New DataTable(tableName)
            Using conn As System.Data.SqlClient.SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@ChartNo", ChartNo)

                    End With

                    conn.Open()

                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)


                        da.Fill(dt)


                    End Using

                End Using
            End Using

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "查詢檢驗檢查資料 "
    ''' <summary>
    ''' 功能說明：查詢檢驗檢查資料之病患資料
    ''' 
    ''' </summary>
    ''' <param name="chart_No"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function QueryPatientbyEMR(ByVal chart_No As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = " SELECT RTRIM(PP.Patient_Name) as Patient_Name,RTRIM(PP.Birth_Date) as Birth_date,RTRIM(PS1.Code_Name) as Sex,RTRIM(PP.Blood_type_Id) as Blood,RTRIM(PP.Chart_No) as chart_no" & _
            " from PUB_Patient as PP  inner join PUB_Syscode as PS1 on PS1.Code_Id=PP.Sex_Id and PS1.Type_Id='21'" & _
            " WHERE PP.Chart_NO='" + chart_No + "' or PP.idno='" + chart_No + "'"
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet()
                adapter.Fill(ds, "retExamineRecord")
                adapter.FillSchema(ds, SchemaType.Mapped, "retExamineRecord")
            End Using
            Return ds

        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "使用證號查詢病歷主檔"

    Public Function queryPubPatientByIdno(ByVal Idno As String) As DataSet

        Try

            Dim PUBPatientBO As PUBPatientBO_E1 = PUBPatientBO_E1.getInstance

            Dim queryStr As String = ""

            queryStr = " SELECT * " & _
                       " FROM PUB_Patient  " & _
                       " WHERE 1=1  And Idno='" & Idno & "' "

            Return PUBPatientBO.dynamicQuery(queryStr)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function


#End Region

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryPUBPatientByName(ByVal Chart_No As String, ByRef Patient_Name As System.String, ByVal Idno As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " Select * From  " & tableName & " Where 1 = 1 "
            If Chart_No <> "" Then
                command.CommandText &= " and Chart_No=@Chart_No "
                command.Parameters.AddWithValue("@Chart_No", Chart_No)
            End If
            If Patient_Name <> "" Then
                command.CommandText &= " and Patient_Name=@Patient_Name "
                command.Parameters.AddWithValue("@Patient_Name", Patient_Name)
            End If
            If Idno <> "" Then
                command.CommandText &= " and Idno=@Idno "
                command.Parameters.AddWithValue("@Idno", Idno)
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

    Public Function queryPUBPatientByNameBirthday(ByRef Patient_Name As String, ByVal Birth_Date As String) As System.Data.DataSet
        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
        Try
            Dim ds As DataSet

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " Select * From  " & tableName & " Where 1 = 1 "

            If Patient_Name <> "" Then
                command.CommandText &= " and Patient_Name like '%" & Patient_Name.Trim & "%'"
                'command.Parameters.AddWithValue("@Patient_Name", Patient_Name)
            End If
            If Birth_Date <> "" Then
                command.CommandText &= " and Birth_Date=@Birth_Date "
                command.Parameters.AddWithValue("@Birth_Date", Birth_Date)
            End If

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds
        Catch sqlex As SqlException
            conn.Close()
            Throw sqlex
        Catch ex As Exception
            conn.Close()
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            conn.Close()
        End Try
    End Function

 

#Region "2012/08/09, Add By Lits,更新病歷主檔及住院次數 PUB_Patient.Latest_Admission_Date, Ipd_Times"
    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="Chart_No">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePubLatestAdmissionDate(ByVal Chart_No As System.String, ByVal Modified_User As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing

        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            '2012.10.23 add by Bella, 增加更新住院次數(PUB_Patient.Ipd_Times)自動加1
            Dim inpTimes As Integer = 0
            Using patientDT As DataTable = PubPatientBO.GetInstance.queryByPK(Chart_No, conn).Tables(0)
                If DataSetUtil.IsContainsData(patientDT) Then
                    inpTimes = Val(StringUtil.nvl(patientDT.Rows(0).Item("Ipd_Times"))) + 1
                End If
            End Using

            Dim Latest_Admission_Date As String = Now.Date.ToString("yyyy/MM/dd")

            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set Latest_Admission_Date=@Latest_Admission_Date " & _
            " ,Ipd_Times =@Ipd_Times, Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
                " where  Chart_No=@Chart_No "

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Chart_No", Chart_No)
                command.Parameters.AddWithValue("@Latest_Admission_Date", Latest_Admission_Date)
                command.Parameters.AddWithValue("@Ipd_Times", inpTimes)
                command.Parameters.AddWithValue("@Modified_User", Modified_User)
                command.Parameters.AddWithValue("@Modified_Time", Now)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count
        Catch sqlex As SqlException
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
#End Region


#Region "20130613, Add By Patrick 更新DischargeDate"
    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="Chart_No">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePubLatest_Discharge_Date(ByVal Chart_No As System.String, ByVal Modified_User As String) As Integer

        Dim conn As System.Data.IDbConnection = getConnection()

        Try

            Dim Latest_Admission_Date As String = Now.Date.ToString("yyyy/MM/dd")

            Dim count As Integer = 0
            Dim sqlString As String = "update " & tableName & " set Latest_Discharge_Date=@Latest_Discharge_Date " & _
            " , Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
                " where  Chart_No=@Chart_No "
            conn.Open()

            Using command As SqlCommand = New SqlCommand
                With command
                    .CommandText = sqlString
                    .CommandType = CommandType.Text
                    .Connection = CType(conn, SqlConnection)
                End With
                command.Parameters.AddWithValue("@Chart_No", Chart_No)
                command.Parameters.AddWithValue("@Latest_Admission_Date", Latest_Admission_Date)
                command.Parameters.AddWithValue("@Modified_User", Modified_User)
                command.Parameters.AddWithValue("@Modified_Time", Now)
                Dim cnt As Integer = command.ExecuteNonQuery
                count = count + cnt
            End Using

            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD003", ex)
        Finally
            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function
#End Region

#Region "2014.01.15 PUB (Barcode條碼列印)  Add By 玟伶"
    Public Function BarCodeGetPatientInfo(ByVal strCharNo As String, ByVal strSourceID As String) As DataSet
        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
        Try
            Dim ds As DataSet

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            'command.CommandText = " Select patient_name,idno From pub_patient Where Chart_No='" & strCharNo & "'"
            command.CommandText = " Select Chart_No,patient_name,case when Sex_Id='1' then  '男' else '女' end as Sex_ID,Birth_Date,Idno From pub_patient Where Chart_No='" & strCharNo & "'"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, "pub_patient")
                'adapter.FillSchema(ds, SchemaType.Mapped, tableName)


                If strSourceID = "O" Then '門診

                    command.CommandText = " SELECT [Code_Id],[Code_En_Name],[Code_Name] FROM [PUB_Syscode] where Type_Id='5267' and Is_Opd='Y' "
                    adapter.Fill(ds, "PUB_Syscode")


                ElseIf strSourceID = "E" Then '急診

                    command.CommandText = " SELECT [Code_Id],[Code_En_Name],[Code_Name] FROM [PUB_Syscode] where Type_Id='5267' and Is_Emg='Y' "
                    adapter.Fill(ds, "PUB_Syscode")

                ElseIf strSourceID = "I" Then '住院

                    command.CommandText = " SELECT [Code_Id],[Code_En_Name],[Code_Name] FROM [PUB_Syscode] where Type_Id='5267' and Is_Ipd='Y' "
                    adapter.Fill(ds, "PUB_Syscode")

                End If



            End Using


            Return ds
        Catch sqlex As SqlException
            conn.Close()
            Throw sqlex
        Catch ex As Exception
            conn.Close()
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            conn.Close()
        End Try
    End Function


    Public Function BarCodeGetDeptnameInfo(ByVal strdeptcode As String) As DataSet
        'test
        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
        Try
            Dim ds As DataSet

            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = " Select Dept_Name From PUB_Department Where Dept_Code='" & strdeptcode & "'"

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, "PUB_Department")



            End Using


            Return ds
        Catch sqlex As SqlException
            conn.Close()
            Throw sqlex
        Catch ex As Exception
            conn.Close()
            Throw New CommonException("CMMCMMD001", ex)
        Finally
            conn.Close()
        End Try
    End Function





#End Region


    ''' <summary>
    '''以ＰＫ查詢資料 PUB_Patient
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryPUBPatientByPK(ByVal strL As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataTable
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim resultTable As DataTable
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select Latest_Visit_Date,Patient_Name,*  from PUB_Patient where  Chart_No = @Chart_No   "
            command.Parameters.AddWithValue("@Chart_No", strL)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                resultTable = New DataTable
                resultTable.TableName = tableName
                adapter.FillSchema(resultTable, SchemaType.Source)
                adapter.Fill(resultTable)
                Return resultTable
            End Using
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

    ''' <summary>
    '''以ＰＫ查詢資料 PUB_Patient
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryPUBPatientByPKForInactiveChart(ByVal strL As String, ByVal LatestVisitDate As String, ByVal BirthDate As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataTable
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If
            Dim resultTable As DataTable
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = _
            " Select A.Latest_Visit_Date, A.Patient_Name, A.Birth_Date, Case When B.Chart_No is NULL Then 'N' Else 'Y' End as IsDead " & _
            " From PUB_Patient A " & _
            "   Left Outer Join MMR_Death B on A.Chart_No = B.Chart_No and (B.Cancel <> 'Y' or B.Cancel is null ) " & _
            " Where A.Chart_No=@Chart_No and A.Chart_No Not In ( " & _
            "   Select Chart_No " & _
            "   From MMR_Inactive_Chart " & _
            "   Where Cancel <> 'Y' " & _
            "   Group by Chart_No " & _
            "   ) and A.Chart_No Not In ( " & _
            "   Select Chart_No " & _
            "   From MMR_Chart_VIP " & _
            "   Where Cancel <> 'Y' " & _
            "   Group by Chart_No " & _
            "   ) and A.Latest_Visit_Date <= '" & LatestVisitDate & "' "

            If BirthDate <> "" Then
                command.CommandText &= "   and (A.Birth_Date <= '" & BirthDate & "' Or A.Birth_Date is NULL) "
            End If

            command.Parameters.AddWithValue("@Chart_No", strL)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                resultTable = New DataTable
                resultTable.TableName = tableName
                adapter.FillSchema(resultTable, SchemaType.Source)
                adapter.Fill(resultTable)
                Return resultTable
            End Using
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

#Region "2009/08/22, Add By 谷官, 欠款繳回(OPCPayArrearUI)"

    ''' <summary>
    ''' 更新欠款記錄
    ''' </summary>
    ''' <param name="chartNo"></param>
    ''' <param name="opdArrearsAmt"></param>
    ''' <param name="modifiedUser"></param>
    ''' <param name="modifiedTime"></param>
    ''' <param name="conn"></param>
    ''' <param name="source" >來源</param>
    ''' <returns></returns>
    ''' <remarks>2011.08.24 Bella, 改為門急住(OPD/EPD/IPD)共用</remarks>
    Public Function updateOpdArrearsAmt(ByVal chartNo As String, ByVal opdArrearsAmt As Integer, ByVal modifiedUser As String, ByVal modifiedTime As Date, Optional ByRef conn As IDbConnection = Nothing, Optional ByVal source As String = "") As Integer
        Dim cmdStr As New StringBuilder


        Dim connFlag As Boolean = conn Is Nothing
        Try
            'SQL
            cmdStr.AppendLine("update PUB_Patient")
            If source.ToString.Length.Equals(0) Or source.ToString.Equals("OPD") Then
                cmdStr.AppendLine("set Opd_Arrears_Amt = ISNULL(Opd_Arrears_Amt,0) + (" & opdArrearsAmt & "),")
            ElseIf source.ToString.Equals("EPD") Then
                cmdStr.AppendLine("set Emg_Arrears_Amt = ISNULL(Emg_Arrears_Amt,0) + (" & opdArrearsAmt & "),")
            ElseIf source.ToString.Equals("IPD") Then
                cmdStr.AppendLine("set Ipd_Arrears_Amt = ISNULL(Ipd_Arrears_Amt,0) + (" & opdArrearsAmt & "),")
            End If

            'If opdArrearsAmt >= 0 Then
            '    cmdStr.AppendLine("set Opd_Arrears_Amt = Opd_Arrears_Amt + " & opdArrearsAmt & ",")
            'Else
            '    cmdStr.AppendLine("set Opd_Arrears_Amt = Opd_Arrears_Amt - " & opdArrearsAmt & ",")
            'End If
            cmdStr.AppendLine("Modified_User = '" & modifiedUser & "',")
            cmdStr.AppendLine("Modified_Time = '" & modifiedTime.ToString("yyyy/MM/dd HH:mm:ss") & "'")
            cmdStr.AppendLine("where 1=1")
            cmdStr.AppendLine("and Chart_No = '" & chartNo & "'")

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If


            '執行SQL
            Return SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "update", Nothing, conn)

        Catch ex As Exception
            LOGDelegate.getInstance.dbErrorMsg(cmdStr.ToString, ex)
            Throw ex
        Finally
            If connFlag AndAlso conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If

        End Try
    End Function
#End Region

#Region "     以病歷號查詢關聯表的資料 (For KLH 用) "

    ''' <summary>
    '''以病歷號查詢關聯表的資料
    ''' </summary>
    ''' <remarks>by ChenYu.Guo on 2016-06-07</remarks>
    Public Function queryRelationInfoByPK(ByRef pk_Chart_No As System.String, ByRef pk_Pip_Type As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim content As New StringBuilder
            content.AppendLine(" select PA.Chart_No,PA.Patient_Name,PA.Idno,PA.Sex_Id,PA.Birth_Date,PA.Blood_Type_Id, ")
            content.AppendLine(" CM.Case_No,CM.Case_Apply_Date,CM.Case_Apply_Stage,CM.Case_DR_Code,E.Employee_Name, ")
            content.AppendLine(" CM.Case_Source_Id ")
            content.AppendLine("  from " & tableName & " as PA")
            content.AppendLine("  left join PIP_Case_Main as CM ON CM.Chart_No = PA.Chart_No and CM.Pip_Type = @Pip_Type ")
            content.AppendLine("  left join PUB_Employee as E ON E.Employee_Code = CM.Case_DR_Code ")
            content.AppendLine("  where PA.Chart_No=@Chart_No            ")

            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)
            command.Parameters.AddWithValue("@Pip_Type", pk_Pip_Type)
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

End Class
