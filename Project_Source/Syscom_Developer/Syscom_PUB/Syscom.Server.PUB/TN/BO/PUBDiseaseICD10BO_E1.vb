Imports System.Data.SqlClient
'
'
'
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
Imports System.Text
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP

Public Class PUBDiseaseICD10BO_E1
    Inherits PubDiseaseIcd10BO

    'Private m_tableName = "PUB_Disease"

    'Public Shared ReadOnly Property Instance()
    '    Get
    '        Return New PUBDiseaseICD10BO_E1
    '    End Get
    'End Property

    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

#Region "########## getInstance ##########"

    Private Shared instance As PUBDiseaseICD10BO_E1

    Public Overloads Shared Function getInstance() As PUBDiseaseICD10BO_E1
        If instance Is Nothing Then
            instance = New PUBDiseaseICD10BO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    '''' <summary>
    '''' 取得SQL連線資訊
    '''' </summary>
    '''' <returns>sql connection</returns>
    '''' <author>Ken</author>
    '''' <date>2009-07-06</date>
    '''' <remarks></remarks>
    'Private Function GetSqlConnection() As SqlConnection

    '    Return SQLConnFactory.getInstance.getPubDBSqlConn
    'End Function

    ''' <summary>
    ''' Query by input conditions.
    ''' </summary>
    ''' <param name="_icdCode">ICD Code</param>
    ''' <param name="_diseaseEnName">疾病英文名稱</param>
    ''' <returns>查詢結果</returns>
    ''' <author>Ken</author>
    ''' <date>2009-07-06</date>
    ''' <remarks></remarks>
    Public Function queryPUBDisease10ByCond(ByVal _icdCode As String, ByVal _diseaseEnName As String, ByVal _diseaseTypeId As String) As DataSet
        Dim _date As Date = Date.Now

        Try
            Using conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Using Command As SqlCommand = conn.CreateCommand
                    Command.CommandText = "SELECT '' AS Favor_Category" & _
                                               ", Is_Chronic_Disease AS Is_Chronic_Disease" & _
                                               ", RTRIM(Icd_Code) AS Order_Code" & _
                                               ", Disease_En_Name AS Favor_Name" & _
                                               ", CASE" & _
                                                    " WHEN (ISNULL(Is_Psy_Severe_Disease, '') = 'Y' OR ISNULL(Is_Severe_Disease, '') = 'Y' )" & _
                                                        " THEN 'Y'" & _
                                                    " ELSE 'N'" & _
                                                " END AS Is_Severe_Disease" & _
                                               ", Disease_Name AS Disease_Name" & _
                                               ", Infection_Type_Id AS Infection_Type_Id" & _
                                           " FROM PUB_Disease_ICD10 WITH(NOLOCK)" & _
                                          " WHERE Icd_Code LIKE @Icd_Code+'%' " & _
                                            " AND (Disease_En_Name LIKE '%'+@DiseaseName+'%' OR Disease_Name LIKE '%'+@DiseaseName+'%')" & _
                                            " AND Is_Opd = 'Y' " & _
                                            " AND (Dc <> 'Y'" & _
                                              " OR Dc IS NULL)" & _
                                            " AND Effect_Date <= @NOW" & _
                                            " AND (End_Date >= @NOW" & _
                                              " OR End_Date IS NULL)" & _
                                            " AND PUB_Disease_ICD10.Disease_Type_Id = '1'" & _
                                          " ORDER BY Favor_Category, Favor_Name, Order_Code"

                    Command.Parameters.AddWithValue("@Icd_Code", _icdCode)
                    Command.Parameters.AddWithValue("@DiseaseName", _diseaseEnName.Trim)
                    Command.Parameters.AddWithValue("@NOW", Now.ToShortDateString)

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(Command)
                        Using ds As DataSet = New DataSet("PUB_Department")
                            adapter.Fill(ds, "PUB_Department")
                            Return ds
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    ''' <summary>
    ''' 程式說明：查詢疾病表
    ''' 開發人員：Jen
    ''' 開發日期：2009.09.16
    ''' </summary>
    ''' <param name="ConditionDT">查詢條件(多)</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Disease
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/09/16, XXX
    ''' </修改註記>
    Public Function querySingleDiseaseByCondition(ByVal ConditionDT As DataTable) As DataTable

        If DataSetUtil.IsContainsData(ConditionDT) AndAlso (Not IsDBNull(ConditionDT.Rows(0).Item("Icd_Code"))) AndAlso (Not IsDBNull(ConditionDT.Rows(0).Item("Disease_Type_Id"))) Then
            '至少有Icd_Code, Disease_Type_Id
            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("SELECT top 1 * ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where ")
            '主條件
            cmdStr.Append("Icd_Code = '").Append(CType(ConditionDT.Rows(0).Item("Icd_Code"), String).Trim).AppendLine("' ")
            cmdStr.Append("and Disease_Type_Id = '").Append(CType(ConditionDT.Rows(0).Item("Disease_Type_Id"), String).Trim).AppendLine("' ")
            cmdStr.Append("and Dc <> 'Y' ")
            '條件查詢
            If (Not IsDBNull(ConditionDT.Rows(0).Item("Disease_En_Name"))) AndAlso (CType(ConditionDT.Rows(0).Item("Disease_En_Name"), String).Trim.Length > 0) Then
                cmdStr.Append("and Disease_En_Name = '").Append(CType(ConditionDT.Rows(0).Item("Disease_En_Name"), String).Trim).AppendLine("' ")
            End If
            If (Not IsDBNull(ConditionDT.Rows(0).Item("Disease_Name"))) AndAlso (CType(ConditionDT.Rows(0).Item("Disease_Name"), String).Trim.Length > 0) Then
                cmdStr.Append("and Disease_Name = '").Append(CType(ConditionDT.Rows(0).Item("Disease_Name"), String).Trim).AppendLine("' ")
            End If
            If (Not IsDBNull(ConditionDT.Rows(0).Item("Disease_En_Short_Name"))) AndAlso (CType(ConditionDT.Rows(0).Item("Disease_En_Short_Name"), String).Trim.Length > 0) Then
                cmdStr.Append("and Disease_En_Short_Name = '").Append(CType(ConditionDT.Rows(0).Item("Disease_En_Short_Name"), String).Trim).AppendLine("' ")
            End If
            If (Not IsDBNull(ConditionDT.Rows(0).Item("Disease_Short_Name"))) AndAlso (CType(ConditionDT.Rows(0).Item("Disease_Short_Name"), String).Trim.Length > 0) Then
                cmdStr.Append("and Disease_Short_Name = '").Append(CType(ConditionDT.Rows(0).Item("Disease_Short_Name"), String).Trim).AppendLine("' ")
            End If
            If (Not IsDBNull(ConditionDT.Rows(0).Item("Disease_Hosp_Name"))) AndAlso (CType(ConditionDT.Rows(0).Item("Disease_Hosp_Name"), String).Trim.Length > 0) Then
                cmdStr.Append("and Disease_Hosp_Name = '").Append(CType(ConditionDT.Rows(0).Item("Disease_Hosp_Name"), String).Trim).AppendLine("' ")
            End If
            If Not IsDBNull(ConditionDT.Rows(0).Item("Majorcare_Code")) Then
                cmdStr.Append("and Majorcare_Code = '").Append(CType(ConditionDT.Rows(0).Item("Majorcare_Code"), String).Trim).AppendLine("' ")
            End If

            If Not IsDBNull(ConditionDT.Rows(0).Item("Infection_Type_Id")) Then
                cmdStr.Append("and Infection_Type_Id = '").Append(CType(ConditionDT.Rows(0).Item("Infection_Type_Id"), String).Trim).AppendLine("' ")
            End If

            If Not IsDBNull(ConditionDT.Rows(0).Item("Main_Diagnosis_Id")) Then
                cmdStr.Append("and Main_Diagnosis_Id = '").Append(CType(ConditionDT.Rows(0).Item("Main_Diagnosis_Id"), String).Trim).AppendLine("' ")
            End If

            If Not IsDBNull(ConditionDT.Rows(0).Item("Limit_Sex_Id")) Then
                cmdStr.Append("and Limit_Sex_Id = '").Append(CType(ConditionDT.Rows(0).Item("Limit_Sex_Id"), String).Trim).AppendLine("' ")
            End If

            If Not IsDBNull(ConditionDT.Rows(0).Item("Is_Opd")) Then
                If CType(ConditionDT.Rows(0).Item("Is_Opd"), String).Trim.Equals("Y") Then
                    cmdStr.Append("and Is_Opd = 'Y' ")
                Else
                    cmdStr.Append("and Is_Opd = 'N' ")
                End If
            End If

            If Not IsDBNull(ConditionDT.Rows(0).Item("Is_Emg")) Then
                If CType(ConditionDT.Rows(0).Item("Is_Emg"), String).Trim.Equals("Y") Then
                    cmdStr.Append("and Is_Emg = 'Y' ")
                Else
                    cmdStr.Append("and Is_Emg = 'N' ")
                End If
            End If

            If Not IsDBNull(ConditionDT.Rows(0).Item("Is_Ipd")) Then
                If CType(ConditionDT.Rows(0).Item("Is_Ipd"), String).Trim.Equals("Y") Then
                    cmdStr.Append("and Is_Ipd = 'Y' ")
                Else
                    cmdStr.Append("and Is_Ipd = 'N' ")
                End If
            End If



            If Not IsDBNull(ConditionDT.Rows(0).Item("Limit_Age")) Then
                cmdStr.Append("and Limit_Age = '").Append(CType(ConditionDT.Rows(0).Item("Limit_Age"), String).Trim).AppendLine("' ")
            End If

            If Not IsDBNull(ConditionDT.Rows(0).Item("Pip_Type_Id")) Then
                cmdStr.Append("and Pip_Type_Id = '").Append(CType(ConditionDT.Rows(0).Item("Pip_Type_Id"), String).Trim).AppendLine("' ")
            End If

            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("order by Effect_Date desc ")

            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            'sqlCmd.Parameters.AddWithValue("@ChartNo", ChartNo)

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
        Else
            Return Nothing
        End If


    End Function


    'cmdStr.AppendLine("left join PUB_Disease PD on PD.Icd_Code = ID.Diagnosis_Code and PD.Effect_Date <= @leftHospDate and (End_Date is null or End_Date >= @leftHospDate) ")
    '    cmdStr.AppendLine("and PD.Disease_Type_Id = ID.Diagnosis_Type_Id ")
    ''' <summary>
    ''' 更新疾病資料
    ''' </summary>
    ''' <param name="diseaseDateDT"></param>
    ''' <param name="outDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function updateDiseaseICD10Column(ByVal diseaseDateDT As DataTable, ByVal outDate As Date, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        If DataSetUtil.IsContainsData(diseaseDateDT) Then
            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'update SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("update ").Append(tableName).Append(" set Is_Rare_Diseases = @Is_Rare_Diseases, Is_Major_P = @Is_Major_P, Is_Minor_P = @Is_Minor_P, Is_Mcc = @Is_Mcc, Is_Cc = @Is_Cc, Is_Severe_Disease = @Is_Severe_Disease ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where ")
            '主條件
            cmdStr.AppendLine("Effect_Date <= @outDate and (End_Date is null or End_Date >= @outDate) ")
            cmdStr.AppendLine("and Icd_Code = @Icd_Code ")
            cmdStr.AppendLine("and Disease_Type_Id = @Disease_Type_Id ")
            cmdStr.AppendLine("and DC <> @DCY ")

            '----------------------------------------------------------------------------
            Dim count As Integer = 0

            Try
                Dim dt As DataTable = New DataTable(tableName)

                'Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                If connFlag Then
                    conn = getConnection()
                    conn.Open()
                End If

                For Each row As DataRow In diseaseDateDT.Rows
                    If IsDBNull(row.Item("Icd_Code")) Or IsDBNull(row.Item("Disease_Type_Id")) Or _
                    IsDBNull(row.Item("Is_Rare_Diseases")) Or IsDBNull(row.Item("Is_Major_P")) Or IsDBNull(row.Item("Is_Minor_P")) Or IsDBNull(row.Item("Is_Mcc")) Or _
                    IsDBNull(row.Item("Is_Cc")) Or IsDBNull(row.Item("Is_Severe_Disease")) Then
                        Return -1
                    Else
                        Using command As SqlCommand = New SqlCommand
                            With command
                                .CommandText = cmdStr.ToString
                                .CommandType = CommandType.Text
                                .Connection = CType(conn, SqlConnection)
                            End With

                            command.Parameters.AddWithValue("@Is_Rare_Diseases", CType(row.Item("Is_Rare_Diseases"), String).Trim)
                            command.Parameters.AddWithValue("@Is_Major_P", CType(row.Item("Is_Major_P"), String).Trim)
                            command.Parameters.AddWithValue("@Is_Minor_P", CType(row.Item("Is_Minor_P"), String).Trim)
                            command.Parameters.AddWithValue("@Is_Mcc", CType(row.Item("Is_Mcc"), String).Trim)
                            command.Parameters.AddWithValue("@Is_Cc", CType(row.Item("Is_Cc"), String).Trim)
                            command.Parameters.AddWithValue("@Is_Severe_Disease", CType(row.Item("Is_Severe_Disease"), String).Trim)

                            command.Parameters.AddWithValue("@DCY", "Y")
                            command.Parameters.AddWithValue("@outDate", outDate)
                            command.Parameters.AddWithValue("@Icd_Code", CType(row.Item("Icd_Code"), String).Trim)
                            command.Parameters.AddWithValue("@Disease_Type_Id", CType(row.Item("Disease_Type_Id"), String).Trim)

                            Dim cnt As Integer = command.ExecuteNonQuery
                            count = count + cnt
                        End Using
                    End If
                Next
                ' End Using

                Return count

            Catch ex As Exception
                Throw ex
            Finally
                If connFlag AndAlso conn IsNot Nothing Then
                    conn.Close()
                    conn.Dispose()
                    conn = Nothing
                End If
            End Try
        Else
            Return -1
        End If

    End Function

    ''' <summary>
    ''' 作廢疾病資料
    ''' </summary>
    ''' <param name="cancelDT"></param>
    ''' <param name="EndDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function cancelDiseaseICD10(ByVal cancelDT As DataTable, ByVal EndDate As Date) As Integer

        If DataSetUtil.IsContainsData(cancelDT) Then
            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'update SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("update ").Append(tableName).Append(" set DC = @DCY, ").AppendLine("End_Date = @EndDate ")
            '----------------------------------------------------------------------------
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where ")
            '主條件
            cmdStr.AppendLine("Icd_Code = @Icd_Code ")
            cmdStr.AppendLine("and Disease_Type_Id = @Disease_Type_Id ")
            cmdStr.AppendLine("and Effect_Date = @Effect_Date ")

            '----------------------------------------------------------------------------
            Dim count As Integer = 0

            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    conn.Open()
                    For Each row As DataRow In cancelDT.Rows
                        If IsDBNull(row.Item("Icd_Code")) Or IsDBNull(row.Item("Disease_Type_Id")) Or IsDBNull(row.Item("Effect_Date")) Then
                            Return -1
                        Else
                            Using command As SqlCommand = New SqlCommand
                                With command
                                    .CommandText = cmdStr.ToString
                                    .CommandType = CommandType.Text
                                    .Connection = CType(conn, SqlConnection)
                                End With
                                command.Parameters.AddWithValue("@DCY", "Y")
                                command.Parameters.AddWithValue("@EndDate", EndDate)
                                command.Parameters.AddWithValue("@Icd_Code", CType(row.Item("Icd_Code"), String).Trim)
                                command.Parameters.AddWithValue("@Disease_Type_Id", CType(row.Item("Disease_Type_Id"), String).Trim)
                                command.Parameters.AddWithValue("@Effect_Date", CType(row.Item("Effect_Date"), Date))

                                Dim cnt As Integer = command.ExecuteNonQuery
                                count = count + cnt
                            End Using
                        End If
                    Next
                End Using

                Return count

            Catch ex As Exception
                Throw ex
            End Try
        Else
            Return -1
        End If

    End Function



    '----------------------


    ''' <summary>
    ''' 程式說明：查詢疾病表筆數
    ''' 開發人員：Jen
    ''' 開發日期：2009.09.16
    ''' </summary>
    ''' <param name="ConditionDT">查詢條件</param>
    ''' <returns>Integer</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Disease
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/09/16, XXX
    ''' </修改註記>
    Public Function countDiseaseICD10(ByVal ConditionDT As DataTable) As Integer

        If DataSetUtil.IsContainsData(ConditionDT) AndAlso (Not IsDBNull(ConditionDT.Rows(0).Item("Icd_Code"))) AndAlso (Not IsDBNull(ConditionDT.Rows(0).Item("Disease_Type_Id"))) Then
            '至少有Icd_Code, Disease_Type_Id
            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("SELECT count(*) as CNT ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" ")

            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where ")
            '主條件
            cmdStr.Append("Icd_Code = '").Append(CType(ConditionDT.Rows(0).Item("Icd_Code"), String).Trim).AppendLine("' ")
            cmdStr.Append("and Effect_Date = '").Append(CType(ConditionDT.Rows(0).Item("Effect_Date"), Date).ToString("yyyy/MM/dd")).AppendLine("' ")
            cmdStr.Append("and Disease_Type_Id = '").Append(CType(ConditionDT.Rows(0).Item("Disease_Type_Id"), String).Trim).AppendLine("' ")

            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------

            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            'sqlCmd.Parameters.AddWithValue("@ChartNo", ChartNo)

                        End With

                        conn.Open()

                        Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                            da.Fill(dt)
                        End Using
                    End Using
                End Using

                Return Integer.Parse(dt.Rows(0).Item("CNT"))

            Catch ex As Exception
                Throw ex
            End Try
        Else
            Return 0
        End If


    End Function


    ''' <summary>
    ''' 程式說明：刪除資料
    ''' 開發人員：Jen
    ''' 開發日期：2009.09.16
    ''' </summary>
    ''' <remarks></remarks>
    Public Function deleteDiseaseICD10(ByVal EffectDate As Date, ByVal IcdCode As String) As Integer
        Try
            Dim count As Integer = 0


            '至少有Icd_Code, Disease_Type_Id
            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("delete ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" ")

            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where ")
            '主條件
            cmdStr.Append("Effect_Date = '").Append(EffectDate.ToString("yyyy/MM/dd")).Append("' and Icd_Code = @Icd_Code ")

            Using conn As System.Data.IDbConnection = getConnection()
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Icd_Code", IcdCode)

                    conn.Open()
                    count = command.ExecuteNonQuery
                End Using
            End Using
            Return count
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD004", ex)
        End Try
    End Function


    ''' <summary>
    ''' 程式說明：查詢範圍內存在疾病代碼
    ''' 開發人員：Jen
    ''' 開發日期：2009.12.22
    ''' </summary>
    ''' <param name="Condition">查詢條件</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Disease
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/12/22, XXX
    ''' </修改註記>
    Public Function queryExistIcdCodeByConditionICD10(ByVal Condition As String) As DataTable

        If Condition IsNot Nothing AndAlso Condition.Length > 0 Then
            '至少有Icd_Code, Disease_Type_Id
            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("SELECT Icd_Code ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where ")
            '主條件
            cmdStr.AppendLine("Dc <> @DcY ")
            cmdStr.AppendLine("and Effect_Date <= @Today_Date ")
            cmdStr.Append("and ").Append(Condition)
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("order by Icd_Code asc ")

            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@DcY", "Y")
                            sqlCmd.Parameters.AddWithValue("@Today_Date", Now)


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
        Else
            Return Nothing
        End If


    End Function


    ''' <summary>
    ''' 程式說明：查詢疾病表上一筆(下一筆)資料
    ''' 開發人員：Jen
    ''' 開發日期：2010.03.01
    ''' </summary>
    ''' <param name="partialIcdCode">部分疾病碼</param>
    ''' <param name="diseaseTypeId">疾病分類碼</param>
    ''' <param name="isPre">找上一筆?</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Disease
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2010/03/01, XXX
    ''' </修改註記>
    Public Function queryPreOrNextRecordSingleDiseaseICD10(ByVal partialIcdCode As String, ByVal diseaseTypeId As String, ByVal isPre As Boolean) As DataTable

        If (partialIcdCode IsNot Nothing AndAlso partialIcdCode.Length > 0) AndAlso (diseaseTypeId IsNot Nothing AndAlso diseaseTypeId.Length > 0) Then
            '至少有Icd_Code, Disease_Type_Id
            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("SELECT top 1 Icd_Code ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("where ")
            '主條件
            cmdStr.AppendLine("Dc <> @DcY ")
            cmdStr.AppendLine("and Effect_Date <= @Today_Date ")
            cmdStr.AppendLine("and Disease_Type_Id = @Disease_Type_Id ")
            If isPre Then
                cmdStr.AppendLine("and Icd_Code < @Icd_Code ")
            Else
                cmdStr.AppendLine("and Icd_Code > @Icd_Code ")
            End If

            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            If isPre Then
                cmdStr.AppendLine("order by Icd_Code desc ")
            Else
                cmdStr.AppendLine("order by Icd_Code asc ")
            End If


            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@DcY", "Y")
                            sqlCmd.Parameters.AddWithValue("@Today_Date", Now)
                            sqlCmd.Parameters.AddWithValue("@Disease_Type_Id", diseaseTypeId)
                            sqlCmd.Parameters.AddWithValue("@Icd_Code", partialIcdCode)

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
        Else
            Return Nothing
        End If


    End Function

    ''' <summary>
    ''' 程式說明：診斷 PUB_Disease查詢
    ''' 開發人員：Alan
    ''' 開發日期：2010.04.20
    ''' 備    註：為了要與前端UI一致，因此將相關欄位名稱變更如下:
    ''' Icd_Code=>Order_Code
    ''' Disease_En_Name=>Order_En_Name
    ''' Disease_Name=>Order_Nam
    ''' </summary>    
    Public Function queryPUBDiseaseICD10ByFavor(ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = " Select Icd_Code  As Order_Code, Disease_En_Name As Order_En_Name ,Disease_Type_Id, " & _
                                  "        Effect_Date ,Disease_Name As Order_Name,Disease_Hosp_Name,Majorcare_Code,Limit_Sex_Id," & _
                                  "        Infection_Type_Id,Limit_Age,Age_Start_Year,Age_Start_Month,Age_Start_Day," & _
                                  "        Age_End_Year,Age_End_Month,Age_End_Day,Is_Exclude_Labdiscount,Is_Chronic_Disease," & _
                                  "        Is_Severe_Disease,Is_Psy_Severe_Disease,Is_Rare_Diseases,Is_Major_P,Is_Minor_P," & _
                                  "        Is_Mcc,Is_Cc,End_Date " & _
                                  " From   PUB_Disease_ICD10 " & _
                                  " Where  '" & Now().ToString("yyyy/M/d") & "' >= Effect_Date And '" & _
                                               Now().ToString("yyyy/M/d") & "'<= End_Date "

            If code <> "" Then
                command.CommandText += " And Icd_Code like '" & code & "%' "
            End If

            If DiseaseTypeId.Trim <> "" Then
                command.CommandText += " And Disease_Type_Id in (" & DiseaseTypeId & ") "
            End If

            If codeName <> "" Then
                command.CommandText += " And Disease_Name like '" & codeName & "%' "
            End If

            If codeEnName <> "" Then
                command.CommandText += " And Disease_En_Name like '" & codeEnName & "%' "
            End If

            If IsSevereDisease.Trim = "Y" Then
                command.CommandText += " And Is_Severe_Disease='Y' "
            End If

            command.CommandText += " And DC<>'Y' And Is_Opd='Y' "

            If codeName <> "" Then
                command.CommandText += " Order By Disease_Name"
            Else
                command.CommandText += " Order By Disease_En_Name"
            End If


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function queryPUBDiseaseICD10ByFavor2(ByVal SourceType As String, ByVal code As String, ByVal codeEnName As String, ByVal codeName As String, ByVal DiseaseTypeId As String, Optional ByVal IsSevereDisease As String = "") As DataSet

        Try

            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim pvtMergeSQL As String = ""

            Select Case SourceType
                Case "O"
                    pvtMergeSQL = " Is_Opd='Y' "
                Case "E"
                    pvtMergeSQL = " Is_Emg='Y' "
                Case "I"
                    pvtMergeSQL = " Is_Ipd='Y' "
            End Select

            command.CommandText = " Select Icd_Code  As Order_Code, Disease_En_Name As Order_En_Name ,Disease_Type_Id, " & _
                                  "        Effect_Date ,Disease_Name As Order_Name,Disease_Hosp_Name,Majorcare_Code,Limit_Sex_Id," & _
                                  "        Infection_Type_Id,Limit_Age,Age_Start_Year,Age_Start_Month,Age_Start_Day," & _
                                  "        Age_End_Year,Age_End_Month,Age_End_Day,Is_Exclude_Labdiscount,Is_Chronic_Disease," & _
                                  "        Is_Severe_Disease,Is_Psy_Severe_Disease,Is_Rare_Diseases,Is_Major_P,Is_Minor_P," & _
                                  "        Is_Mcc,Is_Cc,End_Date " & _
                                  " From   PUB_Disease_ICD10 " & _
                                  " Where  '" & Now().ToString("yyyy/M/d") & "' >= Effect_Date And '" & _
                                               Now().ToString("yyyy/M/d") & "'<= End_Date "

            If code <> "" Then
                command.CommandText += " And Icd_Code like '%" & code & "%' "
            End If

            If DiseaseTypeId.Trim <> "" Then
                command.CommandText += " And Disease_Type_Id in (" & DiseaseTypeId & ") "
            End If

            If codeName <> "" Then
                If (SourceType = "E" OrElse SourceType = "I") Then
                    command.CommandText += " And (Disease_Name like '%" & codeName & "%' "
                    command.CommandText += " OR Icd_Code like '" & codeName & "%') "
                Else
                    command.CommandText += " And Disease_Name like '%" & codeName & "%' "
                End If

            End If

            If codeEnName <> "" Then
                If (SourceType = "E" OrElse SourceType = "I") Then
                    command.CommandText += " And ( Disease_En_Name like '%" & codeEnName & "%' "
                    command.CommandText += " OR Icd_Code like '" & codeEnName & "%') "
                Else
                    command.CommandText += " And Disease_En_Name like '%" & codeEnName & "%' "
                End If

            End If

            If IsSevereDisease.Trim = "Y" Then
                command.CommandText += " And Is_Severe_Disease='Y' "
            End If

            command.CommandText += " And DC<>'Y' And Is_Opd='Y' And " & pvtMergeSQL

            If codeName <> "" Then
                command.CommandText += " Order By Disease_Name"
            Else
                command.CommandText += " Order By Disease_En_Name"
            End If


            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            Return ds


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 取得精神科的Icd_Code
    ''' </summary>
    ''' <param name="opdVisitDate"></param>
    ''' <param name="icdCode"></param>
    ''' <returns>精神科的Icd_Code</returns>
    ''' <remarks></remarks>
    Public Function getPsyIcdCodeDataICD10(ByVal opdVisitDate As Date, ByVal icdCode As String) As String
        Dim cmdStr As New StringBuilder
        Dim conn As IDbConnection = SQLConnFactory.getInstance.getPubDBSqlConn
        If conn IsNot Nothing Then conn.Open()
        Try
            cmdStr.AppendLine("select distinct rtrim(Icd_Code) from PUB_Disease_ICD10")
            cmdStr.AppendLine("where 1=1")
            cmdStr.AppendLine("and Dc <> 'Y'")
            cmdStr.AppendLine("and Is_Psy_Severe_Disease = 'Y'")
            cmdStr.AppendLine("and Effect_Date <= '" & opdVisitDate.ToShortDateString & "' and End_Date >= '" & opdVisitDate.ToShortDateString & "'")
            cmdStr.AppendLine("and Icd_Code = '" & icdCode & "'")

            '執行SQL
            Dim rtnValue As Object = SQLDataUtil.getInstance.execSQL(cmdStr.ToString, Nothing, "value", Nothing, conn)

            If rtnValue Is Nothing Then
                Return ""
            Else
                Return rtnValue
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
            End If
         End Try
    End Function

End Class
