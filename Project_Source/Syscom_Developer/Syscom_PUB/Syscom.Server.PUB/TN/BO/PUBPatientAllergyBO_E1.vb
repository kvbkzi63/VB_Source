Imports System.Data.SqlClient

'
Imports Syscom.Server.BO
Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility
'
Imports System.Text
Imports Syscom.Server.SQL
Imports Syscom.Comm.EXP
Imports System.Transactions

Public Class PUBPatientAllergyBO_E1
    Inherits PubPatientAllergyBO

    'Dim log As ILog = LOGDelegate.GetInstance.getFileLogger(Me)

#Region "########## getInstance ##########"
    Private Shared instance As PUBPatientAllergyBO_E1
    Public Overloads Shared Function getInstance() As PUBPatientAllergyBO_E1
        If instance Is Nothing Then
            instance = New PUBPatientAllergyBO_E1
        End If
        Return instance
    End Function

#End Region

    Public Function queryPUBPatientAllergyByCond(ByRef pk_Chart_No As System.String) As System.Data.DataSet
        Try
            Using sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
                Using command As SqlCommand = sqlConn.CreateCommand()
                    command.CommandText = "SELECT G.Order_Name, A.Patient_Allergy_No, A.Allergy_Code, A.Allergy_Item" & _
                                               ", A.Allergy_Reaction, A.Allergy_Severity, A.Allergy_Date" & _
                                           " FROM PUB_Patient_Allergy A WITH(NOLOCK)" & _
                                           " LEFT JOIN OPH_Pharmacy_Base G WITH(NOLOCK) ON A.Allergy_Code IS NOT NULL" & _
                                                                                     " AND A.Allergy_Code <> ''" & _
                                                                                     " AND A.Allergy_Code = G.Order_Code" & _
                                                                                     " AND G.Dc = 'N'" & _
                                          " WHERE A.Chart_No = @Chart_No" & _
                                            " AND A.Cancel = 'N' " & _
                                          " ORDER BY A.Patient_Allergy_No"

                    command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        Using ds As DataSet = New DataSet(tableName)
                            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            adapter.Fill(ds, tableName)
                            Return ds
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            '  LOGDelegate.GetInstance.getFileLogger(Me).Error(ex.Message)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 程式說明：讀取過敏記錄檔
    ''' 開發人員：Jen
    ''' 開發日期：2009.08.23
    ''' </summary>
    ''' <param name="ChartNo">病歷號</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Patient_Allergy
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/08/23, XXX
    ''' </修改註記>
    Public Function queryPatientAllergyInfo(ByVal ChartNo As String) As DataTable

        Dim cmdStr As New StringBuilder
        '----------------------------------------------------------------------------
        'Select SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("select * ")
        '----------------------------------------------------------------------------
        'From&Join SQL
        '----------------------------------------------------------------------------
        cmdStr.Append("from ").Append(tableName).AppendLine(" ")
        '----------------------------------------------------------------------------
        'Where SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("where Chart_No = @ChartNo And Cancel<>'Y' ")
        '----------------------------------------------------------------------------
        '----------------------------------------------------------------------------
        'Order By SQL
        '----------------------------------------------------------------------------
        cmdStr.AppendLine("order by Allergy_Kind_Id ")
        '----------------------------------------------------------------------------
        Try
            Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                Using sqlCmd As SqlCommand = New SqlCommand
                    With sqlCmd
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn

                        sqlCmd.Parameters.AddWithValue("@ChartNo", ChartNo)

                    End With

                    conn.Open()

                    Using da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
                        Using dt As DataTable = New DataTable(tableName)

                            da.Fill(dt)

                            Return dt
                        End Using
                    End Using

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' 程式說明：重新寫入IC卡過敏資料
    ''' 開發人員：Alan
    ''' 開發日期：2009.12.10    
    Public Function updatePUBPatientAllergyByChartNo(ByVal UserID As String, ByVal ChartNo As String, ByVal iData As DataSet) As Integer


        Dim SqlCmd As SqlCommand

        Dim pvtPtAllergyBO As New PubPatientAllergyBO

        Dim pvtDs As New DataSet
        pvtDs.Tables.Add("PUB_Patient_Allergy")
        pvtDs.Tables(0).Columns.Add("Chart_No")
        pvtDs.Tables(0).Columns.Add("Patient_Allergy_No")
        pvtDs.Tables(0).Columns.Add("Allergy_Kind_Id")
        pvtDs.Tables(0).Columns.Add("Allergy_Code")
        pvtDs.Tables(0).Columns.Add("Allergy_Item")
        pvtDs.Tables(0).Columns.Add("Allergy_Severity")
        pvtDs.Tables(0).Columns.Add("Allergy_Reaction")
        pvtDs.Tables(0).Columns.Add("Allergy_Date")
        pvtDs.Tables(0).Columns.Add("Is_From_Iccard")
        pvtDs.Tables(0).Columns.Add("Pharmacy_12_Code")
        pvtDs.Tables(0).Columns.Add("ADRNotification_No")
        pvtDs.Tables(0).Columns.Add("Cancel")
        pvtDs.Tables(0).Columns.Add("Create_User")
        pvtDs.Tables(0).Columns.Add("Create_Time")
        pvtDs.Tables(0).Columns.Add("Modified_User")
        pvtDs.Tables(0).Columns.Add("Modified_Time")
        pvtDs.Tables(0).Columns.Add("Drug_Allergy_Id")
        pvtDs.Tables(0).Columns.Add("Limit_Strength")
        pvtDs.Tables(0).Columns.Add("order_name")

        Try
            Using opdConn = SQLConnFactory.getInstance.getOpdDBSqlConn
                 
                Dim cmdStr1 As String = ""

                '刪除IC卡過敏資料
                cmdStr1 = "Delete From PUB_Patient_Allergy " & _
                          "Where Chart_No='" & ChartNo & "' And Is_From_Iccard='Y'  "
                opdConn.Open()
                SqlCmd = New SqlCommand(cmdStr1, opdConn)
                SqlCmd.ExecuteNonQuery()

                '重新寫入IC卡過敏資料
                Dim Allergy_Item As String
                Dim pvtMaxNo As New DataSet
                Dim pvtPatientAllergyNo As String

                '取得最大序號                    
                pvtMaxNo = getMaxPatientAllergyNo(ChartNo)

                If pvtMaxNo IsNot Nothing AndAlso pvtMaxNo.Tables(0) IsNot Nothing AndAlso _
                   pvtMaxNo.Tables(0).Rows.Count > 0 Then

                    pvtPatientAllergyNo = pvtMaxNo.Tables(0).Rows(0).Item(0).ToString.Trim

                    If pvtPatientAllergyNo = "" Then
                        pvtPatientAllergyNo = "1"
                    End If

                Else
                    pvtPatientAllergyNo = "1"
                End If

                For i = 0 To iData.Tables(0).Rows.Count - 1

                    Allergy_Item = iData.Tables(0).Rows(i).Item("ELEMENT").ToString.Trim

                    If Allergy_Item <> "" Then

                        If i <> 0 Then
                            pvtPatientAllergyNo += 1
                        End If

                        pvtDs.Tables(0).Rows.Add()
                        pvtDs.Tables(0).NewRow()
                        pvtDs.Tables(0).Rows(pvtDs.Tables(0).Rows.Count - 1).Item("Chart_No") = ChartNo
                        pvtDs.Tables(0).Rows(pvtDs.Tables(0).Rows.Count - 1).Item("Patient_Allergy_No") = pvtPatientAllergyNo
                        pvtDs.Tables(0).Rows(pvtDs.Tables(0).Rows.Count - 1).Item("Allergy_Kind_Id") = "DA"
                        pvtDs.Tables(0).Rows(pvtDs.Tables(0).Rows.Count - 1).Item("Allergy_Item") = Allergy_Item
                        pvtDs.Tables(0).Rows(pvtDs.Tables(0).Rows.Count - 1).Item("Is_From_Iccard") = "Y"
                        pvtDs.Tables(0).Rows(pvtDs.Tables(0).Rows.Count - 1).Item("Cancel") = "N"
                        pvtDs.Tables(0).Rows(pvtDs.Tables(0).Rows.Count - 1).Item("Create_User") = UserID
                        pvtDs.Tables(0).Rows(pvtDs.Tables(0).Rows.Count - 1).Item("Create_Time") = Now.ToString("yyyy/MM/dd H:m:s")

                        'cmdStr1 = "Insert into PUB_Patient_Allergy " & _
                        '          "(Chart_No,Patient_Allergy_No,Allergy_Kind_Id,Allergy_Item,Is_From_Iccard,Create_User,Create_Time) " & _
                        '          "Values " & _
                        '          "('" & ChartNo & "'," & pvtPatientAllergyNo & ",'DA','" & _
                        '          Allergy_Item & "','Y','" & UserID & "','" & Now.ToString("yyyy/MM/dd H:m:s") & "')"
                        'SqlCmd = New SqlCommand(cmdStr1, conn)
                        'SqlCmd.ExecuteNonQuery()
                    End If
                Next

                Dim insert As Integer = pvtPtAllergyBO.insert(pvtDs, opdConn)
                opdConn.Close()
            End Using

            Return 1
        Catch ex As SqlClient.SqlException
             
            Return 0
        Finally

        End Try
         
    End Function

    Public Function getMaxPatientAllergyNo(ByVal ChartNo As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select  MAX(Patient_Allergy_No)+1 " & _
                                  "From    PUB_Patient_Allergy " & _
                                  "Where   Chart_No='" & ChartNo & "' "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Patient_Allergy")
                adapter.Fill(ds, "PUB_Patient_Allergy")
                adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Patient_Allergy")
            End Using

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryPatientAllergyForIph(ByVal ChartNo As String) As System.Data.DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = "Select  * " & _
                                  "From    PUB_Patient_Allergy " & _
                                  "Where   Chart_No='" & ChartNo & "' and " & _
                                  "        Cancel<>'Y' and Allergy_Kind_Id='DA' "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Patient_Allergy")
                adapter.Fill(ds, "PUB_Patient_Allergy")
                adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Patient_Allergy")
            End Using

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "用在PUBPatientAllergyNew的介面上"

    Public Function InitUI() As DataSet
        Try
            Dim InitDS As New DataSet
            '--------------------------------載入藥品成份--------------------------------
            InitDS.Tables.Add("DrugIngredients")
            InitDS.Tables("DrugIngredients").Merge(Get_DrugIngredients)
            '--------------------------------載入限制強度--------------------------------
            InitDS.Tables.Add("LimitStrength")
            InitDS.Tables("LimitStrength").Merge(Get_LimitStrength)
            '--------------------------------載入藥品名稱--------------------------------
            'InitDS.Tables.Add("PharmacyBase")
            'InitDS.Tables("PharmacyBase").Merge(Get_PharmacyBase)
            '--------------------------------載入藥品分類--------------------------------
            'InitDS.Tables.Add("PharmacyClass")
            'InitDS.Tables("PharmacyClass").Merge(Get_PharmacyClass)
            Return InitDS
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function Get_DrugIngredients() As DataTable
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select DISTINCT Code_Id,Code_Name from oph_code where type_id = '302'"
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("DrugIngredients")
                adapter.Fill(ds, "DrugIngredients")
                adapter.FillSchema(ds, SchemaType.Mapped, "DrugIngredients")
            End Using
            Return ds.Tables("DrugIngredients")
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' 957195.20120731 過濾掉限制強度的「通知」選項
    ''' </remarks>
    Public Function Get_LimitStrength() As DataTable
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select RTRIM(Code_Id),RTRIM(Code_Name) From OPH_Code Where Type_Id='27' And DC='N' and code_name <>  '通知' Order By Sort_Value, Code_Id "
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("LimitStrength")
                adapter.Fill(ds, "LimitStrength")
                adapter.FillSchema(ds, SchemaType.Mapped, "LimitStrength")
            End Using
            Return ds.Tables("LimitStrength")
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 取得藥品名稱自動搜尋視窗的藥品資料
    ''' </summary>
    ''' <returns></returns>

    Public Function Get_PharmacyBase(ByRef orderName As String) As DataTable
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select RTRIM(Order_Code) as '藥品代碼' ,RTRIM(Order_Name) as '藥品名稱', rtrim(Trade_Name) as '商品名' ,'院內藥品' as '來源',RTRIM(Scientific_Name) as '學名' from OPH_Pharmacy_Base where Dc='N' and Is_Non_Display ='N' and (Order_Name like '%" + orderName + "%' or Trade_Name like '%" + orderName + "%' or  Scientific_Name like '%" + orderName + "%')"
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Pharmacy_Base")
                adapter.Fill(ds, "Pharmacy_Base")
                adapter.FillSchema(ds, SchemaType.Mapped, "Pharmacy_Base")
            End Using
            Return ds.Tables("Pharmacy_Base")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得藥品分類、藥品成份、ATC碼自動搜尋視窗的藥品資料(原Get_PharmacyClass)
    ''' </summary>
    ''' <returns></returns>
    Public Function Get_PharmacyClassAndCompositionAndATC(ByVal orderName As String, ByVal NameType As String) As DataTable
        Try

            If NameType = "Class" Then

                Dim ds As DataSet
                Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = " select  Class_Code,Class_En_Name from OPH_Pharmacy_Class  where Dc='N' and  (Class_En_Name like '%" + orderName + "%' ) --藥理分類 "
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds = New DataSet("Pharmacy_Class")
                    adapter.Fill(ds, "Pharmacy_Class")
                    adapter.FillSchema(ds, SchemaType.Mapped, "Pharmacy_Class")
                End Using
                Return ds.Tables("Pharmacy_Class")

            ElseIf NameType = "Composition" Then

                Dim ds As DataSet
                Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = " select  Pharmacy_12_Code,Composition_Name from OPH_Composition where (Composition_Name like '%" + orderName + "%' )  --藥品成分 "
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds = New DataSet("OPH_Composition")
                    adapter.Fill(ds, "OPH_Composition")
                End Using

                Return ds.Tables("OPH_Composition")

            ElseIf NameType = "ATC" Then

                Dim ds As DataSet
                Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = " select Atc_Code,Atc_En_Name from PHY_Atc  where Dc='N' and  (Atc_En_Name like '%" + orderName + "%' ) --ATC CODE "
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    ds = New DataSet("PHY_Atc")
                    adapter.Fill(ds, "PHY_Atc")
                End Using

                Return ds.Tables("PHY_Atc")

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Find_AllergyRecord(ByVal Chart_No As String) As DataTable
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "Select Chart_No,Allergy_Code,Allergy_Item,Cancel,Patient_Allergy_No from PUB_Patient_Allergy " & _
                                    " Where Chart_No=@Chart_No "
            command.Parameters.AddWithValue("@Chart_No", Chart_No)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("Allergy_Record")
                adapter.Fill(ds, "Allergy_Record")
                adapter.FillSchema(ds, SchemaType.Mapped, "Allergy_Record")
            End Using
            Return ds.Tables("Allergy_Record")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Find_PatientData(ByVal Chart_No As String) As DataTable
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select Chart_No,Patient_Name,Birth_Date,CASE Sex_Id WHEN 1 then '男' When 2 then '女' ELSE '' end as 性別 from  pub_patient " & _
                                    "where Chart_No= @Chart_No"
            command.Parameters.AddWithValue("@Chart_No", Chart_No)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PatientData")
                adapter.Fill(ds, "PatientData")
                adapter.FillSchema(ds, SchemaType.Mapped, "PatientData")
            End Using
            Return ds.Tables("PatientData")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Find_AllergyHistory(ByVal Chart_No As String) As DataTable
        ' 2013.7.19 (963391) 資料欄加建檔時間Create_Time及Patient_Allergy_no
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("SELECT 'ADD'       AS ADDICCard, " & vbCrLf)
            varname1.Append("       C.Code_Name AS Drug_Allergy_Id, " & vbCrLf)
            varname1.Append("       A.Allergy_Item, " & vbCrLf)
            varname1.Append("       A.Allergy_Reaction, " & vbCrLf)
            varname1.Append("       A.Order_Code, " & vbCrLf)
            varname1.Append("       CASE A.Is_From_Iccard " & vbCrLf)
            varname1.Append("         WHEN 'Y' THEN '是' " & vbCrLf)
            varname1.Append("         WHEN 'N' THEN '否' " & vbCrLf)
            varname1.Append("       END         AS Is_From_Iccard, " & vbCrLf)
            varname1.Append("       B.Code_Name AS Limit_Strength, " & vbCrLf)
            varname1.Append("       A.Create_User, " & vbCrLf)
            varname1.Append("       A.Create_Time, " & vbCrLf)
            varname1.Append("       A.Modified_User, " & vbCrLf)
            varname1.Append("       A.Modified_Time, " & vbCrLf)
            varname1.Append("       A.Patient_Allergy_No " & vbCrLf)
            varname1.Append("FROM   PUB_Patient_Allergy A " & vbCrLf)
            varname1.Append("       Left JOIN OPH_Code B " & vbCrLf)
            varname1.Append("               ON B.Code_Id = A.Limit_Strength " & vbCrLf)
            varname1.Append("                  AND B.type_id = '27' " & vbCrLf)
            varname1.Append("       Left JOIN PUB_Syscode C " & vbCrLf)
            varname1.Append("               ON C.Code_Id = A.Drug_Allergy_Id " & vbCrLf)
            varname1.Append("                  AND C.type_id = '219' " & vbCrLf)
            varname1.Append("WHERE  Cancel = 'N' " & vbCrLf)
            varname1.Append("       AND Chart_No = @Chart_No ")

            command.CommandText = varname1.ToString
            command.Parameters.AddWithValue("@Chart_No", Chart_No)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PatientData")
                adapter.Fill(ds, "PatientData")
                adapter.FillSchema(ds, SchemaType.Mapped, "PatientData")
            End Using

            Return ds.Tables("PatientData")

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 新增過敏記錄
    ''' </summary>
    ''' <param name="Chart_No"></param>
    ''' <param name="Patient_Allergy_No"></param>
    ''' <param name="Allergy_Kind_Id"></param>
    ''' <param name="Allergy_Code"></param>
    ''' <param name="Allergy_Item"></param>
    ''' <param name="Allergy_Reaction"></param>
    ''' <param name="Allergy_Date"></param>
    ''' <param name="Is_From_Iccard"></param>
    ''' <param name="Cancel"></param>
    ''' <param name="Create_User"></param>
    ''' <param name="Create_Time"></param>
    ''' <param name="Drug_Allergy_Id"></param>
    ''' <param name="Limit_Strength"></param>
    Public Sub AddNew_AllergyRecord(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Reaction As String, _
                             ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, ByVal Drug_Allergy_Id As String, _
                             ByVal Limit_Strength As String, ByVal Cancel As String, ByVal Order_Code As String, _
                             ByVal Create_Time As String, ByVal Create_User As String)

        Try
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As New SqlCommand
            command = New SqlCommand("insert into " & tableName & "(" & _
            " Chart_No , Patient_Allergy_No , Allergy_Kind_Id , Allergy_Code , Allergy_Item ,  " & _
             " Allergy_Reaction , Allergy_Date , Is_From_Iccard, Drug_Allergy_Id , Limit_Strength , Order_Code ,  " & _
             " Cancel , Create_User , Create_Time  ) " & _
             " values( @Chart_No , @Patient_Allergy_No , @Allergy_Kind_Id , @Allergy_Code , @Allergy_Item ,  " & _
             " @Allergy_Reaction , @Allergy_Date , @Is_From_Iccard , @Drug_Allergy_Id , @Limit_Strength , @Order_Code ,  " & _
             " @Cancel , @Create_User , @Create_Time   )", sqlConn)
            command.Parameters.AddWithValue("@Chart_No", Chart_No)
            command.Parameters.AddWithValue("@Patient_Allergy_No", Patient_Allergy_No)
            command.Parameters.AddWithValue("@Allergy_Kind_Id", Allergy_Kind_Id)
            command.Parameters.AddWithValue("@Allergy_Code", Allergy_Code)
            command.Parameters.AddWithValue("@Allergy_Item", Allergy_Item)
            command.Parameters.AddWithValue("@Allergy_Reaction", Allergy_Reaction)
            command.Parameters.AddWithValue("@Allergy_Date", Allergy_Date)
            command.Parameters.AddWithValue("@Is_From_Iccard", Is_From_Iccard)
            command.Parameters.AddWithValue("@Drug_Allergy_Id", Drug_Allergy_Id)
            command.Parameters.AddWithValue("@Limit_Strength", Limit_Strength)
            command.Parameters.AddWithValue("@Order_Code", Order_Code)
            command.Parameters.AddWithValue("@Cancel", Cancel)
            command.Parameters.AddWithValue("@Create_User", Create_User)
            command.Parameters.AddWithValue("@Create_Time", Create_Time)

            sqlConn.Open()
            command.ExecuteReader()
            sqlConn.Close()

            '若新增的不是無過敏則刪除原來無過敏的註記
            If Not Allergy_Item.Equals("NKDA") Then
                Delete_AllergyRecord(Chart_No, "", "NKDA", "Y", Create_User, Create_Time, "0")
            End If
            '若新增的不是未明則刪除原來未明的註記
            If Not Allergy_Item.Equals("未明") Then
                Delete_AllergyRecord(Chart_No, "", "未明", "Y", Create_User, Create_Time, "0")
            End If
            'Mark on 2016-08-12 By Lits 高聯醫無此Table
            'PHY_Nonbuild_Allergy_Pati_Reset(Chart_No)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 新增過敏記錄是NKDA
    ''' </summary>
    ''' <param name="Chart_No"></param>
    ''' <param name="Patient_Allergy_No"></param>
    ''' <param name="Allergy_Kind_Id"></param>
    ''' <param name="Allergy_Code"></param>
    ''' <param name="Allergy_Item"></param>
    ''' <param name="Allergy_Severity"></param>
    ''' <param name="Allergy_Reaction"></param>
    ''' <param name="Allergy_Date"></param>
    ''' <param name="Is_From_Iccard"></param>
    ''' <param name="Pharmacy_12_Code"></param>
    ''' <param name="ADRNotification_No"></param>
    ''' <param name="Cancel"></param>
    ''' <param name="Create_User"></param>
    ''' <param name="Create_Time"></param>
    ''' <param name="Modified_User"></param>
    ''' <param name="Modified_Time"></param>
    ''' <param name="Drug_Allergy_Id"></param>
    ''' <param name="Limit_Strength"></param>
    ''' <param name="order_name"></param>
    ''' <remarks></remarks>
    Public Function AddNew_AllergyRecord_NKDA(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Severity As String, _
                             ByVal Allergy_Reaction As String, ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, _
                             ByVal Pharmacy_12_Code As String, ByVal ADRNotification_No As String, ByVal Cancel As String, _
                             ByVal Create_User As String, ByVal Create_Time As String, ByVal Modified_User As String, _
                             ByVal Modified_Time As String, ByVal Drug_Allergy_Id As String, ByVal Limit_Strength As String, ByVal order_name As String) As String
        If Allergy_Item.Trim.Equals("NKDA") = False Then Return "作業失敗，應輸入NKDA!"

        Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
        Try
            Dim cmd1 As SqlCommand = sqlConn.CreateCommand()
            cmd1.CommandText = String.Format("SELECT * FROM  PUB_Patient_Allergy WHERE Is_From_Iccard='N' AND Cancel='N' AND Chart_No='{0}' ", Chart_No)
            sqlConn.Open()
            Dim reader = cmd1.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(reader)
            If dt.Rows.Count > 0 Then Return "作業失敗，過敏檔已有資料!"

            Dim cmd2 = New SqlCommand("INSERT INTO  PUB_Patient_Allergy " & _
               "(Chart_No ,Patient_Allergy_No ,Allergy_Kind_Id ,Allergy_Code ,Allergy_Item  " & _
               ",Allergy_Severity ,Allergy_Reaction ,Allergy_Date ,Is_From_Iccard ,Pharmacy_12_Code " & _
               ",ADRNotification_No ,Cancel ,Create_User ,Create_Time ,Modified_User " & _
               ",Modified_Time ,Drug_Allergy_Id ,Limit_Strength ,order_name) " & _
               "VALUES" & _
               " (@Chart_No ,@Patient_Allergy_No ,@Allergy_Kind_Id ,@Allergy_Code ,@Allergy_Item " & _
               ",@Allergy_Severity ,@Allergy_Reaction ,@Allergy_Date ,@Is_From_Iccard ,@Pharmacy_12_Code " & _
               ",@ADRNotification_No ,@Cancel ,@Create_User ,@Create_Time ,@Modified_User " & _
               ",@Modified_Time ,@Drug_Allergy_Id ,@Limit_Strength ,@order_name)", sqlConn)
            cmd2.Parameters.AddWithValue("@Chart_No", Chart_No)
            cmd2.Parameters.AddWithValue("@Patient_Allergy_No", Patient_Allergy_No)
            cmd2.Parameters.AddWithValue("@Allergy_Kind_Id", Allergy_Kind_Id)
            cmd2.Parameters.AddWithValue("@Allergy_Code", Allergy_Code)
            cmd2.Parameters.AddWithValue("@Allergy_Item", Allergy_Item)
            cmd2.Parameters.AddWithValue("@Allergy_Severity", Allergy_Severity)
            cmd2.Parameters.AddWithValue("@Allergy_Reaction", Allergy_Reaction)
            cmd2.Parameters.AddWithValue("@Allergy_Date", Allergy_Date)
            cmd2.Parameters.AddWithValue("@Is_From_Iccard", Is_From_Iccard)
            cmd2.Parameters.AddWithValue("@Pharmacy_12_Code", Pharmacy_12_Code)
            cmd2.Parameters.AddWithValue("@ADRNotification_No", ADRNotification_No)
            cmd2.Parameters.AddWithValue("@Cancel", Cancel)
            cmd2.Parameters.AddWithValue("@Create_User", Create_User)
            cmd2.Parameters.AddWithValue("@Create_Time", Create_Time)
            cmd2.Parameters.AddWithValue("@Modified_User", Modified_User)
            cmd2.Parameters.AddWithValue("@Modified_Time", Modified_Time)
            cmd2.Parameters.AddWithValue("@Drug_Allergy_Id", Drug_Allergy_Id)
            cmd2.Parameters.AddWithValue("@Limit_Strength", Limit_Strength)
            cmd2.Parameters.AddWithValue("@order_name", order_name)
            Dim i As Integer = cmd2.ExecuteNonQuery()
            Dim j As Integer = i
        Catch ex As Exception
        Finally
            sqlConn.Close()
            sqlConn.Dispose()
        End Try

        Return ""
    End Function
    ''' <summary>
    ''' 新增過敏記錄是未明或其他
    ''' </summary>
    ''' <param name="Chart_No"></param>
    ''' <param name="Patient_Allergy_No"></param>
    ''' <param name="Allergy_Kind_Id"></param>
    ''' <param name="Allergy_Code"></param>
    ''' <param name="Allergy_Item"></param>
    ''' <param name="Allergy_Severity"></param>
    ''' <param name="Allergy_Reaction"></param>
    ''' <param name="Allergy_Date"></param>
    ''' <param name="Is_From_Iccard"></param>
    ''' <param name="Pharmacy_12_Code"></param>
    ''' <param name="ADRNotification_No"></param>
    ''' <param name="Cancel"></param>
    ''' <param name="Create_User"></param>
    ''' <param name="Create_Time"></param>
    ''' <param name="Modified_User"></param>
    ''' <param name="Modified_Time"></param>
    ''' <param name="Drug_Allergy_Id"></param>
    ''' <param name="Limit_Strength"></param>
    ''' <param name="order_name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddNew_AllergyRecord_OTHER(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Severity As String, _
                             ByVal Allergy_Reaction As String, ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, _
                             ByVal Pharmacy_12_Code As String, ByVal ADRNotification_No As String, ByVal Cancel As String, _
                             ByVal Create_User As String, ByVal Create_Time As String, ByVal Modified_User As String, _
                             ByVal Modified_Time As String, ByVal Drug_Allergy_Id As String, ByVal Limit_Strength As String, ByVal order_name As String) As String
        If Allergy_Item.Trim.Equals("NKDA") = True Then Return "作業失敗，不可輸入NKDA!"

        Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
        Try
            Dim cmd1 As SqlCommand = sqlConn.CreateCommand()
            cmd1.CommandText = String.Format("UPDATE  PUB_Patient_Allergy SET Cancel='Y' WHERE Is_From_Iccard='N' AND Cancel='N' AND Allergy_Item='NKDA' AND Chart_No='{0}' ", Chart_No)
            sqlConn.Open()
            Dim k As Integer = cmd1.ExecuteNonQuery()

            Dim cmd2 = New SqlCommand("INSERT INTO PUB_Patient_Allergy " & _
               "(Chart_No ,Patient_Allergy_No ,Allergy_Kind_Id ,Allergy_Code ,Allergy_Item  " & _
               ",Allergy_Severity ,Allergy_Reaction ,Allergy_Date ,Is_From_Iccard ,Pharmacy_12_Code " & _
               ",ADRNotification_No ,Cancel ,Create_User ,Create_Time ,Modified_User " & _
               ",Modified_Time ,Drug_Allergy_Id ,Limit_Strength ,order_name) " & _
               "VALUES" & _
               " (@Chart_No ,@Patient_Allergy_No ,@Allergy_Kind_Id ,@Allergy_Code ,@Allergy_Item " & _
               ",@Allergy_Severity ,@Allergy_Reaction ,@Allergy_Date ,@Is_From_Iccard ,@Pharmacy_12_Code " & _
               ",@ADRNotification_No ,@Cancel ,@Create_User ,@Create_Time ,@Modified_User " & _
               ",@Modified_Time ,@Drug_Allergy_Id ,@Limit_Strength ,@order_name)", sqlConn)
            cmd2.Parameters.AddWithValue("@Chart_No", Chart_No)
            cmd2.Parameters.AddWithValue("@Patient_Allergy_No", Patient_Allergy_No)
            cmd2.Parameters.AddWithValue("@Allergy_Kind_Id", Allergy_Kind_Id)
            cmd2.Parameters.AddWithValue("@Allergy_Code", Allergy_Code)
            cmd2.Parameters.AddWithValue("@Allergy_Item", Allergy_Item)
            cmd2.Parameters.AddWithValue("@Allergy_Severity", Allergy_Severity)
            cmd2.Parameters.AddWithValue("@Allergy_Reaction", Allergy_Reaction)
            cmd2.Parameters.AddWithValue("@Allergy_Date", Allergy_Date)
            cmd2.Parameters.AddWithValue("@Is_From_Iccard", Is_From_Iccard)
            cmd2.Parameters.AddWithValue("@Pharmacy_12_Code", Pharmacy_12_Code)
            cmd2.Parameters.AddWithValue("@ADRNotification_No", ADRNotification_No)
            cmd2.Parameters.AddWithValue("@Cancel", Cancel)
            cmd2.Parameters.AddWithValue("@Create_User", Create_User)
            cmd2.Parameters.AddWithValue("@Create_Time", Create_Time)
            cmd2.Parameters.AddWithValue("@Modified_User", Modified_User)
            cmd2.Parameters.AddWithValue("@Modified_Time", Modified_Time)
            cmd2.Parameters.AddWithValue("@Drug_Allergy_Id", Drug_Allergy_Id)
            cmd2.Parameters.AddWithValue("@Limit_Strength", Limit_Strength)
            cmd2.Parameters.AddWithValue("@order_name", order_name)
            Dim i As Integer = cmd2.ExecuteNonQuery()
            Dim j As Integer = i
        Catch ex As Exception
        Finally
            sqlConn.Close()
            sqlConn.Dispose()
        End Try

        Return ""
    End Function
    ''' <summary>
    ''' 修改過敏記錄
    ''' 已存在過敏記錄當中, 卻被加入cancel=y的資料
    ''' </summary>
    ''' <param name="Chart_No"></param>
    ''' <param name="Allergy_Kind_Id"></param>
    ''' <param name="Allergy_Code"></param>
    ''' <param name="Allergy_Item"></param>
    ''' <param name="Allergy_Reaction"></param>
    ''' <param name="Allergy_Date"></param>
    ''' <param name="Is_From_Iccard"></param>
    ''' <param name="Cancel"></param>
    ''' <param name="Modified_User"></param>
    ''' <param name="Modified_Time"></param>
    ''' <param name="Drug_Allergy_Id"></param>
    ''' <param name="Limit_Strength"></param>
    ''' <param name="Order_Code"></param>
    ''' <remarks>
    ''' 957195.20121217 若新增的記錄不是NKDA，則刪除原來NKDA的記錄
    '''                 若新增的記錄不是未明, 則刪除原來的未明記錄
    ''' 2014.02.11 增加 Patient_Allergy_No 以期可修改過敏源字 (963391)
    ''' </remarks>
    Public Sub Modify_AllergyRecord(ByVal Chart_No As String, ByVal Patient_Allergy_No As String, ByVal Allergy_Kind_Id As String, _
                             ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Allergy_Reaction As String, _
                             ByVal Allergy_Date As String, ByVal Is_From_Iccard As String, ByVal Drug_Allergy_Id As String, _
                             ByVal Limit_Strength As String, ByVal Cancel As String, ByVal Order_Code As String, _
                             ByVal Modified_User As String, ByVal Modified_Time As String)
        Try
            Dim tmpsql As String = "update " & tableName & " set " & _
            " Allergy_Kind_Id=@Allergy_Kind_Id , Allergy_Code=@Allergy_Code , Allergy_Item=@Allergy_Item " & _
            "  , Allergy_Reaction=@Allergy_Reaction , Allergy_Date=@Allergy_Date , Is_From_Iccard=@Is_From_Iccard " & _
            "  , Drug_Allergy_Id=@Drug_Allergy_Id , Limit_Strength=@Limit_Strength , Order_Code=@Order_Code " & _
            "  , Cancel=@Cancel , Modified_User=@Modified_User , Modified_Time=@Modified_Time "
            If Patient_Allergy_No.Trim.Length > 0 Then
                If Patient_Allergy_No.Trim = "0" Then
                    tmpsql = tmpsql + " WHERE Chart_No = @Chart_No and Allergy_Item=@Allergy_Item "
                Else
                    tmpsql = tmpsql & _
                                " WHERE Chart_No = @Chart_No  and  Patient_Allergy_No=@Patient_Allergy_No "
                End If
            Else
                tmpsql = tmpsql + " WHERE Chart_No = @Chart_No and Allergy_Item=@Allergy_Item "
            End If
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As New SqlCommand
            command = New SqlCommand(tmpsql, sqlConn)
            command.Parameters.AddWithValue("@Chart_No", Chart_No)
            command.Parameters.AddWithValue("@Allergy_Kind_Id", Allergy_Kind_Id)
            command.Parameters.AddWithValue("@Allergy_Code", Allergy_Code)
            command.Parameters.AddWithValue("@Allergy_Item", Allergy_Item)
            command.Parameters.AddWithValue("@Allergy_Reaction", Allergy_Reaction)
            command.Parameters.AddWithValue("@Allergy_Date", Allergy_Date)
            command.Parameters.AddWithValue("@Is_From_Iccard", Is_From_Iccard)
            command.Parameters.AddWithValue("@Cancel", Cancel)
            command.Parameters.AddWithValue("@Modified_User", Modified_User)
            command.Parameters.AddWithValue("@Modified_Time", Modified_Time)
            command.Parameters.AddWithValue("@Drug_Allergy_Id", Drug_Allergy_Id)
            command.Parameters.AddWithValue("@Limit_Strength", Limit_Strength)
            command.Parameters.AddWithValue("@Order_Code", Order_Code)
            command.Parameters.AddWithValue("@Patient_Allergy_No", Patient_Allergy_No)

            sqlConn.Open()
            command.ExecuteReader()
            sqlConn.Close()

            '若新增的不是無過敏則刪除原來無過敏的註記
            If Not Allergy_Item.Equals("NKDA") Then
                Delete_AllergyRecord(Chart_No, "", "NKDA", "Y", Modified_User, Modified_Time, "0")
            End If
            '若新增的不是未明則刪除原來未明的註記
            If Not Allergy_Item.Equals("未明") Then
                Delete_AllergyRecord(Chart_No, "", "未明", "Y", Modified_User, Modified_Time, "0")
            End If
            'Mark on 2016-08-12 By Lits 高聯醫無此Table
            'PHY_Nonbuild_Allergy_Pati_Reset(Chart_No)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Delete_AllergyRecord(ByVal Chart_No As String, ByVal Allergy_Code As String, ByVal Allergy_Item As String, ByVal Cancel As String, ByVal Modified_User As String, ByVal Modified_Time As String, ByVal Allergy_no As String)
        Try
            ' 2013.7.19 (963391) 將刪除where 加key Patient_Allergy_No
            '                   如遇 未明 或 NKDA 且 Cancel = 'N' 則同Allergy_Item全刪
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As New SqlCommand
            Dim sqlstr As String
            sqlstr = "UPDATE  PUB_Patient_Allergy " & _
                                " SET Cancel = @Cancel, " & _
                                " Modified_User = @Modified_User,  " & _
                                " Modified_Time = @Modified_Time " & _
                                " WHERE Chart_No = @Chart_No and Cancel = 'N' "
            If Allergy_Item = "未明" Or Allergy_Item = "NKDA" Then
                sqlstr = sqlstr & " and Allergy_Item = @Allergy_Item "
            Else
                sqlstr = sqlstr & " and Patient_Allergy_No = @Allergy_no"
            End If

            command = New SqlCommand(sqlstr, sqlConn)
            command.Parameters.AddWithValue("@Chart_No", Chart_No)
            command.Parameters.AddWithValue("@Allergy_Code", Allergy_Code)
            command.Parameters.AddWithValue("@Allergy_Item", Allergy_Item)
            command.Parameters.AddWithValue("@Cancel", Cancel)
            command.Parameters.AddWithValue("@Modified_User", Modified_User)
            command.Parameters.AddWithValue("@Modified_Time", Modified_Time)
            command.Parameters.AddWithValue("@Allergy_no", Allergy_no)
            sqlConn.Open()
            command.ExecuteReader()
            sqlConn.Close()
            'Mark on 2016-08-12 By Lits 高聯醫無此Table
            'PHY_Nonbuild_Allergy_Pati_Reset(Chart_No)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Reset_IsFromICCard(ByVal Chart_No As String, ByVal Drug1 As String, ByVal Drug2 As String, ByVal Drug3 As String)
        Try
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim Set_ICCardToN As New SqlCommand
            Set_ICCardToN = New SqlCommand("Update PUB_Patient_Allergy Set Is_From_ICCard ='N' Where Chart_No=@Chart_No", sqlConn)
            Set_ICCardToN.Parameters.AddWithValue("@Chart_No", Chart_No)
            sqlConn.Open()
            Set_ICCardToN.ExecuteNonQuery()
            sqlConn.Close()

            Dim UpdateToY As SqlConnection = CType(getConnection(), SqlConnection)
            Dim Set_ICCardToY As New SqlCommand
            Set_ICCardToY = New SqlCommand("Update PUB_Patient_Allergy Set Is_From_ICCard ='Y' Where Chart_No=@Chart_No And Allergy_Item in (@Drug1,@Drug2,@Drug3)", UpdateToY)
            Set_ICCardToY.Parameters.AddWithValue("@Chart_No", Chart_No)
            Set_ICCardToY.Parameters.AddWithValue("@Drug1", Drug1)
            Set_ICCardToY.Parameters.AddWithValue("@Drug2", Drug2)
            Set_ICCardToY.Parameters.AddWithValue("@Drug3", Drug3)
            UpdateToY.Open()
            Set_ICCardToY.ExecuteNonQuery()
            UpdateToY.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub PHY_Nonbuild_Allergy_Pati_Reset(ByVal Chart_No As String)
        Try
            Dim sqlConn As SqlConnection = CType(getConnection(), SqlConnection)
            Dim PNAP_Reset_Cmd As New SqlCommand
            PNAP_Reset_Cmd = New SqlCommand("Update  PHY_Nonbuild_Allergy_Pati Set Is_DC ='Y' Where ChartNo=@ChartNo", sqlConn)
            PNAP_Reset_Cmd.Parameters.AddWithValue("@ChartNo", Chart_No)
            sqlConn.Open()
            PNAP_Reset_Cmd.ExecuteNonQuery()
            sqlConn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "用在PUBPatientAllergyNew的介面上"


    ''' <summary>
    ''' 通過Chart_No查詢PUB_Patient_Allergy的資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryByChartNo(ByRef pk_Chart_No As System.String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
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
            content.AppendLine(" Chart_No,ltrim(rtrim(isnull(Allergy_Item,''))) AS 過敏 ")
            content.AppendLine("                 from " & tableName)
            content.AppendLine("   where Chart_No=@Chart_No            ")
            command.CommandText = content.ToString
            command.Parameters.AddWithValue("@Chart_No", pk_Chart_No)
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

