'/*
'*****************************************************************************
'*
'*    Page/Class Name:	PUBPatientBO_E2.vb
'*              Title:	
'*        Description:	
'*          Copyright:	Copyright(c) Syscom Computer Co,.Ltd
'*            Company:	Syscom Computer Co,.Ltd.
'*            @author:	Jianhui 
'*        Create Date:	2009/09/02
'*      Last Modifier:	
'*   Last Modify Date:	
'*
'*****************************************************************************
'*/
Imports System.Data.SqlClient
Imports System.Text
Imports System.Transactions
Imports Syscom.Comm.TableFactory
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.SQL
Imports System.Reflection
Public Class PUBPatientBO_E2
    Inherits PubPatientBO
    Public Shared ReadOnly tableName1 As String = "PUB_Syscode"
    Private Shared myInstance As PUBPatientBO_E2
    Public Overloads Shared Function GetInstance() As PUBPatientBO_E2
        If myInstance Is Nothing Then
            myInstance = New PUBPatientBO_E2()
        End If
        Return myInstance
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
            "   ) and A.Latest_Visit_Date <= '" & LatestVisitDate & "' " & _
            "   and (A.Birth_Date <= '" & BirthDate & "' Or A.Birth_Date is NULL) "
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

#Region "20090908 查詢病歷資料 PUBPatientBO_E2 add by Yunfei"
    ''' <summary>
    '''查詢資料 PUB_Patient PUB_Syscode
    ''' </summary>
    ''' <param name="strChartNo">病歷號</param>
    ''' <remarks></remarks>
    Public Function queryPUBPatientByCond(ByVal strChartNo As String) As DataTable
        Try
            Dim resultTable As DataTable
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = " select " & _
                                    "  A.Chart_No" & _
                                    "  , A.Patient_Name" & _
                                    "  , A.Birth_Date " & _
                                    "  , A.Blood_Type_Id " & _
                                    "  , H.Area_Name" & _
                                    "  , isnull (rtrim(ltrim(A. Register_Postal_Code)), '') + '-' + isnull (rtrim(ltrim(A. Register_Address)), '') as Register_PCAndAddress" & _
                                    "  , isnull (rtrim(ltrim(A. Postal_Code)), '') + '-' + isnull (rtrim(ltrim(A. Address)), '') as PCAndAddress" & _
                                    "  , A.Tel_Home" & _
                                    "  , A.Tel_Office" & _
                                    "  , A.Tel_Mobile" & _
                                    "  , A.Fax" & _
                                    "  , A.Email" & _
                                    "  , A.Tel2" & _
                                    "  , A.Tel2_Mobile" & _
                                    "  , isnull (rtrim(ltrim(A. Postal_Code2)), '') + '-' + isnull (rtrim(ltrim(A. Address2)), '') as PCAndAddress2" & _
                                    "  , B.Code_Name as Sex" & _
                                    "  , C.Code_Name as Nationality_Name" & _
                                    "  , D.Code_Name as Race_Name" & _
                                    "  , E.Code_Name as Education_Name" & _
                                    "  , F.Code_Name as Marriage_Name" & _
                                    "  , G.Code_Name as Job_Name" & _
                                    "  , I.Code_Name as Flag_Name" & _
                                 "  from " & tableName & _
                                    "  A left outer join" & _
                                    "       (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '21') as B" & _
                                    "       on A.Sex_Id = B.Code_Id" & _
                                    "  left outer join" & _
                                    "       (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '22') as C" & _
                                    "       on A.Nationality_Id = C.Code_Id " & _
                                    "  left outer join" & _
                                    "       (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '37') as D" & _
                                    "       on A.Race_Id = D.Code_Id " & _
                                    "  left outer join " & _
                                    "       (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '24') as E" & _
                                    "       on A.Education_Id = E.Code_Id" & _
                                    "  left outer join " & _
                                    "       (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '23') as F" & _
                                    "       on A.Marriage_Id = F.Code_Id " & _
                                    "  left outer join" & _
                                    "       (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '28') as G" & _
                                    "       on A.Job_Id = G.Code_Id " & _
                                    "  left outer join " & _
                                    "       (select Area_Code , Area_Name from PUB_Area_Code ) as H" & _
                                    "       on A.Area_Code  = H.Area_Code " & _
                                    "  left outer join " & _
                                    "       (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '30' and Dc <> 'Y' ) as I" & _
                                    "       on A.Chart_No  = I.Chart_No " & _
                                "  where A.Chart_No =@Chart_No" & _
                                "  order by A.Chart_No"
            command.Parameters.AddWithValue("@Chart_No", strChartNo)
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
        End Try
    End Function
#End Region

#Region "20090909 病患病歷資料顯示區資料 PUB_Patient_Flag PUB_Syscode PUB_Patient_Allergy PUB_Patient_Severe_Disease PUB_Patient_Operation_History PUB_Patient_Past_Disease_History PUB_Patient_Personal_Habits PUB_Family_History PUB_Patient_Abroad_History add by Yunfei "
    ''' <summary>
    ''' 病患病歷資料顯示區資料
    ''' </summary>
    ''' <param name="strChartNo">病歷號</param>
    ''' <returns>病患病歷資料</returns>
    ''' <remarks></remarks>
    Public Function queryPUBPatientAll(ByVal strChartNo As String) As System.Data.DataSet
        Dim ds As Data.DataSet
        Dim dsReturn As Data.DataSet

        '特殊註記資料查詢
        Dim strSql As New StringBuilder
        strSql.Append("  Select ")
        strSql.Append("     parentNode = 1 ")
        strSql.Append("     , '特殊註記資料' as parentName ")
        strSql.Append("     , subNode = B.Code_Name ")
        strSql.Append("     , Content = A.Flag_Memo ")
        strSql.Append("  from PUB_Patient_Flag A ")
        strSql.Append("     left outer join ")
        strSql.Append("         (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '30') as B ")
        strSql.Append("         on A.Flag_Id = B.Code_Id ")
        strSql.Append("  where A.Chart_No = '").Append(strChartNo.Replace("'", "''")).Append("'")

        '過敏藥物記錄資料查詢
        Dim strSql2 As New StringBuilder
        strSql2.Append("  Select ")
        strSql2.Append("     parentNode = 2 ")
        strSql2.Append("     , '過敏藥物記錄資料' as parentName ")
        strSql2.Append("     , subNode = B.Code_Name ")
        strSql2.Append("     , Content = '[過敏項目]' + isnull (rtrim(ltrim(A.Allergy_Item)), '')  ")
        strSql2.Append("		         +'、[過敏程度]' + isnull (rtrim(ltrim(C.Code_Name)), '')     ")
        strSql2.Append("		         +'、[過敏反應]' + isnull (rtrim(ltrim(D.Code_Name)), '')     ")
        strSql2.Append("  from PUB_Patient_Allergy A ")
        strSql2.Append("     left outer join ")
        strSql2.Append("         (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '209') as B ")
        strSql2.Append("         on A.Allergy_Kind_Id = B.Code_Id ")
        strSql2.Append("     left outer join ")
        strSql2.Append("         (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '210') as C ")
        strSql2.Append("         on A.Allergy_Severity_Id = C.Code_Id ")
        strSql2.Append("     left outer join ")
        strSql2.Append("         (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '29') as D ")
        strSql2.Append("         on A.Allergy_Reaction_Id = D.Code_Id ")
        strSql2.Append("  where A.Chart_No = '").Append(strChartNo.Replace("'", "''")).Append("'")

        '重大傷病記錄查詢
        Dim strSql3 As New StringBuilder
        strSql3.Append("  Select ")
        strSql3.Append("     parentNode = 3 ")
        strSql3.Append("     , '重大傷病記錄' as parentName ")
        strSql3.Append("     , subNode = A.Icd_Code ")
        strSql3.Append("     , Content = '[重傷疾病]' + isnull (rtrim(ltrim(B.Disease_En_Name)), '')  ")
        strSql3.Append("		         +'、[有效期限]' + isnull (CONVERT(char(10),A.Effect_Date,111), '')  + '~' + isnull (CONVERT(char(10),A.End_Date,111), '')  ")
        strSql3.Append("		         +'、[證明文號]' + isnull (rtrim(ltrim(A.Certificate_Sn)), '') ")
        strSql3.Append("  from PUB_Patient_Severe_Disease A ")
        strSql3.Append("         left outer join PUB_Disease as B ")
        strSql3.Append("            on A.Icd_Code = B.Icd_Code ")
        strSql3.Append("  where A.Chart_No = '").Append(strChartNo.Replace("'", "''")).Append("'")
        strSql3.Append("  order by  A.Icd_Code, A.Effect_Date  ")

        '手術記錄資料
        Dim strSql4 As New StringBuilder
        strSql4.Append("  Select ")
        strSql4.Append("     parentNode = 4 ")
        strSql4.Append("     , '手術記錄資料' as parentName ")
        strSql4.Append("     , subNode = A.Operation_No ")
        strSql4.Append("     , Content = '[手術名稱]' + isnull (rtrim(ltrim(A. Operation_Name )), '')  ")
        strSql4.Append("		         +'、[手術時間]' + isnull (CONVERT(char(19),A.Operation_Time,120), '')  ")
        strSql4.Append("		         +'、[手術醫院]' + isnull (rtrim(ltrim(A.Operation_Hospital)), '') ")
        strSql4.Append("  from PUB_Patient_Operation_History A ")
        strSql4.Append("  where A.Chart_No = '").Append(strChartNo.Replace("'", "''")).Append("'")

        '過去病史資料
        Dim strSql5 As New StringBuilder
        strSql5.Append("  Select ")
        strSql5.Append("     parentNode = 5 ")
        strSql5.Append("     , '過去病史資料' as parentName ")
        strSql5.Append("     , subNode = A.Disease_No ")
        strSql5.Append("     , Content = isnull (rtrim(ltrim(A.Diease_Name )), '') ")
        strSql5.Append("		         +	case   ")
        strSql5.Append("		                when isnull (rtrim(ltrim(A.Body_Side)), '') <>'' then  '(' + isnull (rtrim(ltrim(A.Body_Side)), '') 	+')' ")
        strSql5.Append("                        else ''  ")
        strSql5.Append("		            end   ")
        strSql5.Append("		         +	case   ")
        strSql5.Append("		                when isnull (rtrim(ltrim(A.Remark)), '') <>'' then  '(' + isnull (rtrim(ltrim(A.Remark)), '') 	+')' ")
        strSql5.Append("                        else ''  ")
        strSql5.Append("		            end   ")
        strSql5.Append("  from PUB_Patient_Past_Disease_History A ")
        strSql5.Append("  where A.Chart_No = '").Append(strChartNo.Replace("'", "''")).Append("'")

        '個人習慣史
        '抽菸習慣
        Dim strSql6 As New StringBuilder
        strSql6.Append("  Select ")
        strSql6.Append("     parentNode = 6 ")
        strSql6.Append("     , '抽菸習慣' as parentName ")
        strSql6.Append("     , subNode = B.Code_Name ")
        strSql6.Append("     , Content = ''  ")
        strSql6.Append("		         +	case   ")
        strSql6.Append("		                when A.Smoke_Qty IS not null  then  '菸量約'+ cast (A.Smoke_Qty AS varchar(10) )+'支/天' ")
        strSql6.Append("                        else ''  ")
        strSql6.Append("		            end   ")
        strSql6.Append("		         + ' '  ")
        strSql6.Append("		         +	case   ")
        strSql6.Append("		                when A.Smoke_Year IS not null  then  '菸齡約'+ cast (A.Smoke_Year AS varchar(10) )+'年' ")
        strSql6.Append("                        else ''  ")
        strSql6.Append("		            end   ")
        strSql6.Append("  from PUB_Patient_Personal_Habits A ")
        strSql6.Append("     left outer join ")
        strSql6.Append("         (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '611') as B ")
        strSql6.Append("            on A.Smoke_Id = B.Code_Id  ")
        strSql6.Append("  where A.Chart_No = '").Append(strChartNo.Replace("'", "''")).Append("'")
        '喝酒習慣
        Dim strSql7 As New StringBuilder
        strSql7.Append("  Select ")
        strSql7.Append("     parentNode = 6 ")
        strSql7.Append("     , '喝酒習慣' as parentName ")
        strSql7.Append("     , subNode = C.Code_Name ")
        strSql7.Append("     , Content = ''  ")
        strSql7.Append("		         +	case   ")
        strSql7.Append("		                when isnull (rtrim(ltrim(A.Wine_Kind)), '') IS not null  then  '酒類'+ rtrim(ltrim(A.Wine_Kind)) ")
        strSql7.Append("                        else ''  ")
        strSql7.Append("		            end   ")
        strSql7.Append("		         + ' '  ")
        strSql7.Append("		         +	case   ")
        strSql7.Append("		                when A.Wine_Qty IS not null  then  '酒量約'+ cast (A.Wine_Qty AS varchar(10) )+'瓶/天' ")
        strSql7.Append("                        else ''  ")
        strSql7.Append("		            end   ")
        strSql7.Append("		         + ' '  ")
        strSql7.Append("		         +	case   ")
        strSql7.Append("		                when A.Wine_Year IS not null  then  '酒齡約'+ cast (A.Wine_Year AS varchar(10) )+'年' ")
        strSql7.Append("                        else ''  ")
        strSql7.Append("		            end   ")
        strSql7.Append("  from PUB_Patient_Personal_Habits A ")
        strSql7.Append("     left outer join ")
        strSql7.Append("         (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '612') as C ")
        strSql7.Append("            on A.Drink_Wine_Id = C.Code_Id  ")
        strSql7.Append("  where A.Chart_No = '").Append(strChartNo.Replace("'", "''")).Append("'")
        '咀嚼檳榔習慣
        Dim strSql8 As New StringBuilder
        strSql8.Append("  Select ")
        strSql8.Append("     parentNode = 6 ")
        strSql8.Append("     , '咀嚼檳榔習慣' as parentName ")
        strSql8.Append("     , subNode = D.Code_Name ")
        strSql8.Append("     , Content = ''  ")
        strSql8.Append("		         +	case   ")
        strSql8.Append("		                when A.Nut_Qty IS not null  then  '檳榔量約'+ cast (A.Nut_Qty AS varchar(10) )+'顆/天' ")
        strSql8.Append("                        else ''  ")
        strSql8.Append("		            end   ")
        strSql8.Append("		         + ' '  ")
        strSql8.Append("		         +	case   ")
        strSql8.Append("		                when A.Nut_Year IS not null  then  '檳榔齡約'+ cast (A.Nut_Year AS varchar(10) )+'年' ")
        strSql8.Append("                        else ''  ")
        strSql8.Append("		            end   ")
        strSql8.Append("  from PUB_Patient_Personal_Habits A ")
        strSql8.Append("     left outer join ")
        strSql8.Append("         (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '613') as D ")
        strSql8.Append("            on A.Eat_Nut_Id = D.Code_Id   ")
        strSql8.Append("  where A.Chart_No = '").Append(strChartNo.Replace("'", "''")).Append("'")
        '運動習慣
        Dim strSql9 As New StringBuilder
        strSql9.Append("  Select ")
        strSql9.Append("     parentNode = 6 ")
        strSql9.Append("     , '運動習慣' as parentName ")
        strSql9.Append("     , subNode = E.Code_Name ")
        strSql9.Append("     , Content = ''  ")
        strSql9.Append("		         +	case   ")
        strSql9.Append("		                when A.Exercise_Year IS not null  then  '已持續約'+ cast (A.Exercise_Year AS varchar(10) )+'年' ")
        strSql9.Append("                        else ''  ")
        strSql9.Append("		            end   ")
        strSql9.Append("  from PUB_Patient_Personal_Habits A ")
        strSql9.Append("     left outer join ")
        strSql9.Append("         (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '619') as E ")
        strSql9.Append("            on A.Exercise_Id = E.Code_Id   ")
        strSql9.Append("  where A.Chart_No = '").Append(strChartNo.Replace("'", "''")).Append("'")

        '家族病史資料
        Dim strSql10 As New StringBuilder
        strSql10.Append("  Select ")
        strSql10.Append("     parentNode = 7 ")
        strSql10.Append("     , '家族病史資料' as parentName ")
        strSql10.Append("     , subNode = B.Code_Name ")
        strSql10.Append("     , Content = isnull (rtrim(ltrim(A.Disease_Name)), '')  ")
        strSql10.Append("		         +	case   ")
        strSql10.Append("		                when isnull (rtrim(ltrim(A.Body_Side)), '') <>'' then  '(' + isnull (rtrim(ltrim(A.Body_Side)), '') 	+')' ")
        strSql10.Append("                        else ''  ")
        strSql10.Append("		            end   ")
        strSql10.Append("		         +	case   ")
        strSql10.Append("		                when isnull (rtrim(ltrim(A.Remark)), '') <>'' then  '(' + isnull (rtrim(ltrim(A.Remark)), '') 	+')' ")
        strSql10.Append("                        else ''  ")
        strSql10.Append("		            end   ")
        strSql10.Append("  from PUB_Family_History A ")
        strSql10.Append("     left outer join ")
        strSql10.Append("         (select Code_Id , Code_Name from PUB_Syscode where Type_Id = '34') as B ")
        strSql10.Append("            on A.Title_Id = B.Code_Id    ")
        strSql10.Append("  where A.Chart_No = '").Append(strChartNo.Replace("'", "''")).Append("'")
        strSql10.Append("  order by  A.Title_Id ,A.Disease_Id ")

        '出國旅遊史資料
        Dim strSql11 As New StringBuilder
        strSql11.Append("  Select ")
        strSql11.Append("     parentNode = 8 ")
        strSql11.Append("     , '出國旅遊史資料' as parentName ")
        strSql11.Append("     , subNode = A.Abroad_No  ")
        strSql11.Append("     , Content = '[國家名稱]' + isnull (rtrim(ltrim(A.Abroad_Country)), '')  ")
        strSql11.Append("		         +'、[出國期間]' + isnull (CONVERT(char(10),A.Abroad_Date,111), '')  + '~' + isnull (CONVERT(char(10),A.Comeback_Date,111), '') 	 ")
        strSql11.Append("  from PUB_Patient_Abroad_History A ")
        strSql11.Append("  where A.Chart_No = '").Append(strChartNo.Replace("'", "''")).Append("'")

        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                '特殊註記資料查詢
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet("PUB_Patient_Flag")
                adapter.Fill(ds, "PUB_Patient_Flag")

                '過敏藥物記錄資料查詢
                adapter = New SqlDataAdapter(strSql2.ToString, sqlConnection)
                adapter.Fill(ds, "PUB_Patient_Allergy")

                '重大傷病記錄查詢
                adapter = New SqlDataAdapter(strSql3.ToString, sqlConnection)
                adapter.Fill(ds, "PUB_Patient_Severe_Disease")

                '手術記錄資料
                adapter = New SqlDataAdapter(strSql4.ToString, sqlConnection)
                adapter.Fill(ds, "PUB_Patient_Operation_History")

                '過去病史資料
                adapter = New SqlDataAdapter(strSql5.ToString, sqlConnection)
                adapter.Fill(ds, "PUB_Patient_Past_Disease_History")

                '個人習慣史
                '抽菸習慣
                adapter = New SqlDataAdapter(strSql6.ToString, sqlConnection)
                adapter.Fill(ds, "PUB_Patient_Personal_Habits")
                '喝酒習慣
                adapter = New SqlDataAdapter(strSql7.ToString, sqlConnection)
                adapter.Fill(ds, "PUB_Patient_Personal_Habits")
                '咀嚼檳榔習慣
                adapter = New SqlDataAdapter(strSql8.ToString, sqlConnection)
                adapter.Fill(ds, "PUB_Patient_Personal_Habits")
                '運動習慣
                adapter = New SqlDataAdapter(strSql9.ToString, sqlConnection)
                adapter.Fill(ds, "PUB_Patient_Personal_Habits")

                '家族病史資料
                adapter = New SqlDataAdapter(strSql10.ToString, sqlConnection)
                adapter.Fill(ds, "PUB_Family_History")

                '出國旅遊史資料
                adapter = New SqlDataAdapter(strSql11.ToString, sqlConnection)
                adapter.Fill(ds, "PUB_Patient_Abroad_History")
            End Using

            dsReturn = New DataSet()
            Dim dt As New DataTable

            dt.Columns.Add("ID", GetType(System.Int32))
            dt.Columns.Add("ParentID", GetType(System.Int32))
            dt.Columns.Add("項目", GetType(System.String))
            dt.Columns.Add("內容", GetType(System.String))

            Dim iID As Integer = 1
            Dim drdt As DataRow
            Dim iParentID As Integer = 0

            '特殊註記
            drdt = dt.NewRow()
            drdt("ID") = iID
            iParentID = iID
            iID = iID + 1
            drdt("ParentID") = 0
            drdt("項目") = "特殊註記資料"
            dt.Rows.Add(drdt)
            For Each dr As DataRow In ds.Tables("PUB_Patient_Flag").Rows
                drdt = dt.NewRow()
                drdt("ID") = iID
                iID = iID + 1
                drdt("ParentID") = iParentID
                drdt("項目") = dr("subNode").ToString()
                drdt("內容") = dr("Content").ToString()
                dt.Rows.Add(drdt)
            Next

            '過敏藥物記錄
            drdt = dt.NewRow()
            drdt("ID") = iID
            iParentID = iID
            iID = iID + 1
            drdt("ParentID") = 0
            drdt("項目") = "過敏藥物記錄資料"
            dt.Rows.Add(drdt)
            For Each dr As DataRow In ds.Tables("PUB_Patient_Allergy").Rows
                drdt = dt.NewRow()
                drdt("ID") = iID
                iID = iID + 1
                drdt("ParentID") = iParentID
                drdt("項目") = dr("subNode").ToString()
                drdt("內容") = dr("Content").ToString()
                dt.Rows.Add(drdt)
            Next

            '重大傷病記錄查詢
            drdt = dt.NewRow()
            drdt("ID") = iID
            iParentID = iID
            iID = iID + 1
            drdt("ParentID") = 0
            drdt("項目") = "重大傷病記錄"
            dt.Rows.Add(drdt)
            For Each dr As DataRow In ds.Tables("PUB_Patient_Severe_Disease").Rows
                drdt = dt.NewRow()
                drdt("ID") = iID
                iID = iID + 1
                drdt("ParentID") = iParentID
                drdt("項目") = dr("subNode").ToString()
                drdt("內容") = dr("Content").ToString()
                dt.Rows.Add(drdt)
            Next

            '手術記錄資料
            drdt = dt.NewRow()
            drdt("ID") = iID
            iParentID = iID
            iID = iID + 1
            drdt("ParentID") = 0
            drdt("項目") = "手術記錄資料"
            dt.Rows.Add(drdt)
            For Each dr As DataRow In ds.Tables("PUB_Patient_Operation_History").Rows
                drdt = dt.NewRow()
                drdt("ID") = iID
                iID = iID + 1
                drdt("ParentID") = iParentID
                drdt("項目") = dr("subNode").ToString()
                drdt("內容") = dr("Content").ToString()
                dt.Rows.Add(drdt)
            Next

            '過去病史資料
            drdt = dt.NewRow()
            drdt("ID") = iID
            iParentID = iID
            iID = iID + 1
            drdt("ParentID") = 0
            drdt("項目") = "過去病史資料"
            dt.Rows.Add(drdt)
            For Each dr As DataRow In ds.Tables("PUB_Patient_Past_Disease_History").Rows
                drdt = dt.NewRow()
                drdt("ID") = iID
                iID = iID + 1
                drdt("ParentID") = iParentID
                drdt("項目") = dr("subNode").ToString()
                drdt("內容") = dr("Content").ToString()
                dt.Rows.Add(drdt)
            Next

            '個人習慣史
            drdt = dt.NewRow()
            drdt("ID") = iID
            iParentID = iID
            iID = iID + 1
            drdt("ParentID") = 0
            drdt("項目") = "個人習慣史"
            dt.Rows.Add(drdt)
            For Each dr As DataRow In ds.Tables("PUB_Patient_Personal_Habits").Rows
                drdt = dt.NewRow()
                drdt("ID") = iID
                iID = iID + 1
                drdt("ParentID") = iParentID
                drdt("項目") = dr("parentName").ToString()
                dt.Rows.Add(drdt)
                drdt = dt.NewRow()
                drdt("ID") = iID
                iID = iID + 1
                drdt("ParentID") = iID - 2
                drdt("項目") = dr("subNode").ToString()
                drdt("內容") = dr("Content").ToString()
                dt.Rows.Add(drdt)
            Next

            '家族病史資料
            drdt = dt.NewRow()
            drdt("ID") = iID
            iParentID = iID
            iID = iID + 1
            drdt("ParentID") = 0
            drdt("項目") = "家族病史資料"
            dt.Rows.Add(drdt)
            For Each dr As DataRow In ds.Tables("PUB_Family_History").Rows
                drdt = dt.NewRow()
                drdt("ID") = iID
                iID = iID + 1
                drdt("ParentID") = iParentID
                drdt("項目") = dr("subNode").ToString()
                dt.Rows.Add(drdt)
                drdt = dt.NewRow()
                drdt("ID") = iID
                iID = iID + 1
                drdt("ParentID") = iID - 2
                Dim i As Integer = 1
                drdt("項目") = i
                drdt("內容") = dr("Content").ToString()
                dt.Rows.Add(drdt)
                i = i + 1
            Next

            '出國旅遊史資料
            drdt = dt.NewRow()
            drdt("ID") = iID
            iParentID = iID
            iID = iID + 1
            drdt("ParentID") = 0
            drdt("項目") = "出國旅遊史資料"
            dt.Rows.Add(drdt)
            For Each dr As DataRow In ds.Tables("PUB_Patient_Abroad_History").Rows
                drdt = dt.NewRow()
                drdt("ID") = iID
                iID = iID + 1
                drdt("ParentID") = iParentID
                drdt("項目") = dr("subNode").ToString()
                drdt("內容") = dr("Content").ToString()
                dt.Rows.Add(drdt)
            Next
            dsReturn.Tables.Add(dt)
        Catch ex As Exception
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
            Throw ex
        End Try
        Return dsReturn
    End Function
#End Region

    ''' <summary>
    ''' 根據病歷號取得合并病歷資料
    ''' </summary>
    ''' <param name="chartNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryChartByCond(ByVal chartNo As String) As DataSet
        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
        Dim SqlCmd As SqlCommand
        Dim cmdStr As String = ""
        Dim myReader As SqlDataReader = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim ds As DataSet
        cmdStr = cmdStr & " select * ,code_name from PUB_Patient A left join PUB_Syscode B "
        cmdStr = cmdStr & "  on A.Sex_Id = B.Code_Id and B.Type_Id = '21'  "
        cmdStr = cmdStr & " where 1=1 "
        If Not chartNo.Equals("") Then
            cmdStr = cmdStr & " and A.Chart_No ='" & chartNo & "'"
        End If
        cmdStr = cmdStr & " order by A.Chart_No"
        ds = New DataSet("resultDB")
        Try
            If cmdStr <> "" Then
                conn.Open()
                SqlCmd = New SqlCommand(cmdStr, conn)
                da = New SqlDataAdapter(New SqlCommand(cmdStr, conn))
                da.FillSchema(ds, SchemaType.Source, "resulttable")
                da.Fill(ds.Tables("resulttable"))
            End If
        Catch ex As SqlClient.SqlException
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)

        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Return ds
    End Function

#Region "以ＰＫ查詢資料 PUB_Patient 中的部分信息 ，add by Tor"
    ''' <summary>
    '''以ＰＫ查詢資料 PUB_Patient
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryPUBPatientBychartNo_L(ByVal chartNo As String) As DataSet

        Dim conn As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn

        Dim SqlCmd As SqlCommand
        Dim cmdStr As String = ""
        Dim myReader As SqlDataReader = Nothing
        Dim da As SqlDataAdapter = Nothing
        Dim ds As DataSet
        cmdStr = cmdStr & " SELECT P.Idno, P.Patient_Name, P.Sex_Id, P.Birth_Date, P.Tel_Home, P.Address, P.Postal_Code,P.Latest_Visit_Date FROM PUB_Patient P where   "

        If Not chartNo.Equals("") Then
            cmdStr = cmdStr & " P.Chart_No ='" & chartNo & "'"
        End If
        cmdStr = cmdStr & " order by P.Chart_No"
        ds = New DataSet("resultDB")
        Try
            If cmdStr <> "" Then
                conn.Open()
                SqlCmd = New SqlCommand(cmdStr, conn)
                da = New SqlDataAdapter(New SqlCommand(cmdStr, conn))
                da.FillSchema(ds, SchemaType.Source, "resulttable")
                da.Fill(ds.Tables("resulttable"))
            End If
        Catch ex As SqlClient.SqlException
            Dim FunctName As String = String.Format("{0}-{1}:", Me.GetType.Name, MethodBase.GetCurrentMethod.Name)
            LOGDelegate.getInstance.dbDebugMsg(FunctName)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Return ds
    End Function
#End Region

#Region "20091014 查詢資料 PUB_Patient 中的部分信息 ，add by Yunfei"
    ''' <summary>
    '''以ＰＫ查詢資料 PUB_Patient
    ''' </summary>
    ''' <remarks></remarks>
    Public Function queryPUBPatientBaseInfoByChartNo_L(ByVal strChartNo As String) As DataSet
        Dim ds As Data.DataSet = New DataSet
        Dim strSql As New StringBuilder

        strSql.Append(" ").Append("select  A.Chart_No")
        strSql.Append(" ").Append("         ,A.Patient_Name ")
        strSql.Append(" ").Append("         ,D.Code_Name AS sex")
        strSql.Append(" ").Append("         ,A.Birth_Date  ")
        strSql.Append(" ").Append("from")
        strSql.Append(" ").Append(tableName).Append(" A ")
        strSql.Append(" ").Append("    left outer join ").Append(tableName1).Append(" D ")
        strSql.Append(" ").Append("        on (A.Sex_Id =D.Code_Id  and D.Type_Id =21) ")
        strSql.Append(" ").Append("Where 1=1 ")
        strSql.Append(" ").Append("AND A.Chart_No = '").Append(strChartNo.Trim).Append("' ")
        Try
            Using sqlConnection As SqlConnection = SQLConnFactory.getInstance.getPubDBSqlConn
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqlConnection)
                ds = New Data.DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, Data.SchemaType.Mapped, tableName)
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
        Return ds
    End Function
#End Region

#Region "20091021 取得病患資料 , Add by zxy"
    Public Function queryPUBPatientByChartNoOrId(ByVal strChartNo As String, ByVal strID As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sql As New StringBuilder
            sql.Append(" Select A.Chart_No ,A.Idno ,A.Patient_Name ,B.Code_Name ,A.Birth_Date ,A.Tel_Home ,A.Tel_Office ,A.Tel_Mobile ,A.Tel2 ,A.Tel2_Mobile ")
            sql.Append(" From ").Append(tableName).Append(" A ")
            sql.Append(" Left Join PUB_Syscode B On (A.Sex_Id =B.Code_Id And B.Type_Id ='21')  where 1=1 ")
            If strChartNo <> "" Then
                sql.Append(" And A.Chart_No = @Chart_No")
                command.Parameters.AddWithValue("@Chart_No", strChartNo)
            End If
            If strID <> "" Then
                sql.Append(" And A.Idno = @Idno")
                command.Parameters.AddWithValue("@Idno", strID)
            End If
            sql.Append(" Order by A.Chart_No ")
            command.CommandText = sql.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
                Return ds
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "20091126 取得病患資料 , Add by jianhui"
    Public Function queryPUBPatientByChartNoOrId_L(ByVal strCaseNo As String, ByVal strChartNo As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sql As New StringBuilder
            sql.Append(" select PUB_Patient.Chart_No,PUB_Syscode.Code_Name, ")
            sql.Append(" b.Code_Name,c.Code_Name,d.contact_name ")
            sql.Append(" from PUB_Patient ")
            sql.Append(" left join PUB_Syscode on (PUB_Patient.Education_Id = PUB_Syscode.Code_Id and PUB_Syscode.Type_Id = 24) ")
            sql.Append(" left join PUB_Syscode b on (PUB_Patient.Job_Id = b.Code_Id and b.Type_Id = 28) ")
            sql.Append(" left join PUB_Syscode c on (PUB_Patient.Marriage_Id = c.Code_Id and c.Type_Id = 23) ")
            sql.Append(" left join pub_patient_contact d on (d.Chart_No = PUB_Patient.Chart_No and d.Patient_Contact_No=1) ")
            sql.Append(" where PUB_Patient.Chart_No = @Chart_No ")
            sql.Append("  ")
            sql.Append("  ")
            sql.Append("  ")
            sql.Append("  ")

            command.Parameters.AddWithValue("@Chart_No", strChartNo)

            command.CommandText = sql.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
                Return ds
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "20100630 血液透析檢驗報告 , Add by pearl"
    Public Function queryPUBPatientForHDSPatientSchedule(ByVal SDate As String, ByVal EDate As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim sql As New StringBuilder
            sql.Append("Select Chart_No,Patient_Name,Idno  ")
            sql.Append("from PUB_Patient where Chart_No in (  ")
            sql.Append("Select Chart_No from HDS_Patient_Schedule   ")
            sql.Append("where Dialysis_Time>@SDate and Dialysis_Time<@EDate  ")
            sql.Append("group by Chart_No)    ")
            command.Parameters.AddWithValue("@SDate", SDate)
            command.Parameters.AddWithValue("@EDate", EDate)
            command.CommandText = sql.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                ' adapter.FillSchema(ds, SchemaType.Mapped, tableName)
                Return ds
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "20101014 成人健檢申報管理 , Add by Runxia"
    Public Function queryPUBPatientForOHMAphcApllyRecode(ByVal strChartNo As String, ByVal strIdno As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strsql As New StringBuilder
            strsql.Append(" ").Append("Select top 1 Chart_No,Patient_Name,Idno,Birth_Date, Sex_Id,Tel_Home ")
            strsql.Append(" ").Append("from PUB_Patient ")
            strsql.Append(" ").Append("where 1=1")
            If strChartNo <> "" Then
                strsql.Append(" ").Append(" and Chart_No = @ChartNo")
            End If
            If strIdno <> "" Then
                strsql.Append(" ").Append("and Idno = @Idno")
            End If
            command.Parameters.AddWithValue("@ChartNo", strChartNo)
            command.Parameters.AddWithValue("@Idno", strIdno)
            command.CommandText = strsql.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                Return ds
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "20111009 編輯死亡證明書 , Add by Mark Zhang"
    Public Function queryPUBPatientForOMODiagnosisCertificate(ByVal strChartNo As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strsql As New StringBuilder
            strsql.Append(" ").Append("Select top 1 B.Chart_No                          ")
            strsql.Append(" ").Append(" , B.Patient_Name                                 ")
            strsql.Append(" ").Append(" , B.Marriage_Id                                  ")
            strsql.Append(" ").Append(" , B.Birth_Date                                   ")
            strsql.Append(" ").Append(" , B.Idno                                        ")
            strsql.Append(" ").Append(" , B.Register_Postal_Code                        ")
            strsql.Append(" ").Append(" , B.Register_Address                            ")
            strsql.Append(" ").Append(" , C.CODE_Name AS Sex_Name                       ")
            strsql.Append(" ").Append(" , D.CODE_Name AS National_Name                  ")
            strsql.Append(" ").Append(" , B.Register_Dist_Code                   ")
            strsql.Append(" ").Append(" , B.Register_Vil_Code                  ")
            strsql.Append(" ").Append(" , B.Area_Code                  ")
            strsql.Append(" ").Append("from PUB_Patient B ")
            strsql.Append(" ").Append("LEFT JOIN PUB_SYSCODE C ON B.Sex_Id = C.code_id and C.type_id = '21'").Append(vbCrLf)
            strsql.Append(" ").Append("LEFT JOIN PUB_SYSCODE D ON B.Nationality_Id = D.code_id and D.type_id = '22'").Append(vbCrLf)
            strsql.Append(" ").Append("where 1=1")
            If strChartNo <> "" Then
                strsql.Append(" ").Append(" and Chart_No = @ChartNo")
            End If
            command.Parameters.AddWithValue("@ChartNo", strChartNo)
            command.CommandText = strsql.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                Return ds
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "20120313 身分資料變更 , Add by Mark Zhang"
    ''' <summary>
    '''更新資料庫內容
    ''' </summary>
    ''' <param name="ds">更新的資料內容</param>
    ''' <remarks></remarks>
    Public Function updatePUBPatientByDS(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer
        Dim connFlag As Boolean = conn Is Nothing
        Try
            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim count As Integer = 0

            Dim sqlString As String = "update " & tableName & " set " & _
            "  Idno=@Idno , Birth_Date=@Birth_Date " & _
            "  ,  Modified_User=@Modified_User , Modified_Time=@Modified_Time " & _
            " where  Chart_No=@Chart_No            "
            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = sqlString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))
                    command.Parameters.AddWithValue("@Idno", row.Item("Idno"))
                    command.Parameters.AddWithValue("@Birth_Date", row.Item("Birth_Date"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Modified_Time", Now)
                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next

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

#Region "20120316 回寫欠款金額  by liuye"

    ''' <summary>
    ''' 回寫欠款金額
    ''' </summary>
    ''' <param name="ds">修改資料</param>
    ''' <returns>Integer</returns>
    ''' <remarks>by liuye on 2012-3-16</remarks>
    Public Function UpdatePubPatientBOIpdArrearsAmt(ByVal ds As System.Data.DataSet, Optional ByRef conn As System.Data.IDbConnection = Nothing) As Integer

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim currentTime = Now
            Dim count As Integer = 0
            Dim varname1 As New System.Text.StringBuilder
            varname1.Append("UPDATE PUB_Patient " & vbCrLf)
            varname1.Append("SET    Ipd_Arrears_Amt = @Ipd_Arrears_Amt, " & vbCrLf)
            varname1.Append("       Modified_Time = @Modified_Time, " & vbCrLf)
            varname1.Append("       Modified_User = @Modified_User " & vbCrLf)
            varname1.Append("WHERE  Chart_No = @Chart_No ")


            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            For Each row As DataRow In ds.Tables(0).Rows
                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = varname1.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Ipd_Arrears_Amt", row.Item("Ipd_Arrears_Amt"))
                    command.Parameters.AddWithValue("@Modified_Time", row.Item("Modified_Time"))
                    command.Parameters.AddWithValue("@Modified_User", row.Item("Modified_User"))
                    command.Parameters.AddWithValue("@Chart_No", row.Item("Chart_No"))

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using
            Next

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

#Region "20120326 取得病患資料及戶籍地 , Add by Runxia"
    Public Function queryPUBPatientAndArea(ByVal strChartNo As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strsql As New StringBuilder
            strsql.Append(" ").Append("Select A.*,B.Area_Code as AreaCode ")
            strsql.Append(" ").Append("from PUB_Patient A")
            strsql.Append(" ").Append("left join pub_area_code_N B  ")
            strsql.Append(" ").Append("on B.Orig_Area_Code = A. Area_Code ")
            strsql.Append(" ").Append("where 1=1")
            If strChartNo <> "" Then
                strsql.Append(" ").Append(" and A.Chart_No = @ChartNo")
            End If
            command.Parameters.AddWithValue("@ChartNo", strChartNo)
            command.CommandText = strsql.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                Return ds
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "20120703 身高,最近體重,最近磅重日  by johsn,wu"

    ''' <summary>
    ''' 身高,最近體重,最近磅重日
    ''' </summary>
    ''' <param name="strChartNo">病歷號</param>
    ''' <returns>DataSet</returns>
    ''' <remarks>by johsn,wu on 2012-7-3</remarks>
    Public Function QueryPubPatientHeightBW_L(ByVal strChartNo As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim command As SqlCommand = conn.CreateCommand()
            Dim strsql As New StringBuilder
            strsql.Append("--身高,最近體重,最近磅重日 " & vbCrLf)
            strsql.Append("SELECT Latest_Height, " & vbCrLf)
            strsql.Append("       Latest_Weight, " & vbCrLf)
            strsql.Append("       Measure_Time " & vbCrLf)
            strsql.Append("FROM " & vbCrLf)
            strsql.Append("  pub_patient " & vbCrLf)
            strsql.Append("WHERE  chart_no = @ChartNo")

            command.Parameters.AddWithValue("@ChartNo", strChartNo)
            command.CommandText = strsql.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                Return ds
            End Using
        Catch sqlex As SqlException
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

#End Region

#Region "20150915 由病歷號 取得姓名、性別、出生年月日、國籍 、身份證號、電話號碼、通訊處 ,add by Remote"

    Public Function queryPUBPatientAndBasicData(ByVal strChart_No As String) As DataSet
        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strsql As New StringBuilder

            strsql.Append("SELECT A.patient_name                AS PatientName, " & vbCrLf)
            strsql.Append("       B.Code_Name                   AS Sex, " & vbCrLf)
            strsql.Append("       dbo.Adtorocdate(A.Birth_Date) AS Birthday, " & vbCrLf)
            strsql.Append("       C.Code_Name                   AS Nationality, " & vbCrLf)
            strsql.Append("       A.Idno, " & vbCrLf)
            strsql.Append("       A.Tel_Home                    AS Telno, " & vbCrLf)
            strsql.Append("       A.Address           AS Address " & vbCrLf)
            strsql.Append("FROM   Pub_patient A " & vbCrLf)
            strsql.Append("       LEFT JOIN PUB_Syscode B " & vbCrLf)
            strsql.Append("              ON B.Code_Id = A.Sex_Id " & vbCrLf)
            strsql.Append("                 AND B.Type_Id = 21 " & vbCrLf)
            strsql.Append("       LEFT JOIN PUB_Syscode C " & vbCrLf)
            strsql.Append("              ON C.Code_Id = A.Nationality_Id " & vbCrLf)
            strsql.Append("                 AND C.Type_Id = 22 " & vbCrLf)
            strsql.Append("WHERE  A.Chart_No = '" + strChart_No + "'")



            command.CommandText = strsql.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                Return ds
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function
#End Region

#Region "20160523 新增該病歷號「特殊註記」資料"

#End Region

#Region "20160620 由來源,病歷號,就診日期 取得就醫序號 by remote_liu "

    ''' <summary>
    ''' 由來源,病歷號,就診日期取得就醫序號   ，由病歷號，就診日期取得醫師
    ''' </summary>
    ''' <param name="inParam"></param>
    ''' <param name="conn">The connection.</param>
    ''' <returns> DataSet </returns>
    '''  <remarks>by Remote on 2016-06-20</remarks>

    Public Function queryMedicalSn(ByVal inParam() As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Try
            Dim ds As DataSet
            Dim sqlConn As SqlClient.SqlConnection = getConnection()
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim strsql As New StringBuilder

            If inParam(0).ToString.Trim = "1" Then

                strsql.Append("SELECT Outpatient_Sn " & vbCrLf)
                strsql.Append("FROM   OMO_Medical_Record " & vbCrLf)
                strsql.Append("WHERE  Chart_No = '" & inParam(1) & "  ' " & vbCrLf)
                strsql.Append("       AND Opd_Visit_Date = '" & inParam(2) & "' " & vbCrLf)
            ElseIf inParam(0).ToString.Trim = "2" Then

                strsql.Append("SELECT Outpatient_Sn " & vbCrLf)
                strsql.Append("FROM   EMO_Medical_Record " & vbCrLf)
                strsql.Append("WHERE  Chart_No = '" & inParam(1) & "  ' " & vbCrLf)
                strsql.Append("       AND Opd_Visit_Date = '" & inParam(2) & "' " & vbCrLf)
            ElseIf inParam(0).ToString.Trim = "3" Then

                strsql.Append("SELECT Case_No " & vbCrLf)
                strsql.Append("FROM   Inp_Check_In_Out " & vbCrLf)
                strsql.Append("WHERE  Chart_No = '" & inParam(1) & "  ' " & vbCrLf)
                strsql.Append("       AND In_Date = '" & inParam(2) & "' ")

            End If

            strsql.Append("SELECT vs_employee_code " & vbCrLf)
            strsql.Append("FROM   inp_check_in_out " & vbCrLf)
            strsql.Append("WHERE  Chart_No = '" & inParam(1) & "' " & vbCrLf)
            strsql.Append("       AND in_date = '" & inParam(2) & "' ")

            command.CommandText = strsql.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                Return ds
            End Using
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw New CommonException("CMMCMMD001", ex)
        End Try
    End Function


#End Region

#Region "20160620 由病歷號,就診日期 取得媽媽姓名 by remote_liu "

    ''' <summary>
    ''' 由來源,病歷號,就診日期取得就醫序號
    ''' </summary>
    ''' <param name="inParam"></param>
    ''' <param name="conn">The connection.</param>
    ''' <returns> DataSet </returns>
    '''  <remarks>by Remote on 2016-06-20</remarks>

    Public Function queryMotherName(ByVal inParam() As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet

        Dim connFlag As Boolean = conn Is Nothing

        Try
            Dim ds As DataSet

            If connFlag Then
                conn = getConnection()
                conn.Open()
            End If

            Dim command As SqlCommand = conn.CreateCommand()
            Dim strsql As New StringBuilder

            strsql.Append("SELECT B.Patient_Name AS Mother_Name " & vbCrLf)
            strsql.Append("FROM   INP_Mother_Baby_CheckIn A " & vbCrLf)
            strsql.Append("       INNER JOIN PUB_Patient B " & vbCrLf)
            strsql.Append("               ON A.Mother_Chart_No = B.Chart_No " & vbCrLf)
            strsql.Append("WHERE  A.Chart_No = '" & inParam(0) & "' " & vbCrLf)
            strsql.Append("       AND in_Date = '" & inParam(1) & "' ")

            strsql.Append("")

            command.CommandText = strsql.ToString
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                Return ds
            End Using
        Catch sqlex As SqlException
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

#End Region



End Class
