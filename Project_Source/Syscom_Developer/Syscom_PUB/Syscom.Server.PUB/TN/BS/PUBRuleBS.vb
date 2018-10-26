Imports System.Text
Imports System.Data.SqlClient
Imports System.IO
Imports Syscom.Server.SQL
Imports Syscom.Server.CMM
Imports Syscom.Comm.EXP
Imports Syscom.Server.BO

Imports Syscom.Comm.TableFactory
Imports Syscom.Comm.Utility


Public Class PUBRuleBS

    Dim log As Syscom.Server.CMM.LOGDelegate = Syscom.Server.CMM.LOGDelegate.getInstance

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As PUBRuleBS
        Try
            Return New PUBRuleBS
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得 CallFrom 所需資料庫資料
    ''' </summary>
    ''' <param name="RuleCode"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCallFormDS(ByVal RuleCode As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = _
            " Select cast('(' + rtrim(tt.Item_Name) + ' ' + rtrim(s2.Code_Name) + ' ' + " & _
            " 	rtrim(d2.Value_Data) + " & _
            " 	case when uu.Unit_Name is null " & _
            " 		then rtrim(isnull(d2.Value_Unit,'')) " & _
            " 		else rtrim(uu.Unit_Name) " & _
            " 	end " & _
            " 	+ ')' + " & _
            " 	case rtrim(d2.Logical_Symbol) when 'AND' " & _
            " 		then ' 且' " & _
            " 		else ' 或' " & _
            " 	end as nvarchar(1000)) as RuleExpStrCht, " & _
            " 	cast('(' + rtrim(s1.Code_En_Name) + '@' + rtrim(tt.Field_Code) + " & _
            "     case tt.Data_Type when '1' " & _
            " 		then rtrim(s2.Code_En_Name)+ '''' + rtrim(d2.Value_Data) + '''' " & _
            " 		when '4' then " & _
            " 			case when tt.Return_Checking_Flag='N' " & _
            " 				then '=True' " & _
            " 				else rtrim(s2.Code_En_Name) + rtrim(d2.Value_Data) " & _
            " 			end " & _
            " 		else rtrim(s2.Code_En_Name) + rtrim(d2.Value_Data) " & _
            "     end " & _
            "     + ')' + " & _
            "     case rtrim(d2.Logical_Symbol) when 'AND' " & _
            " 		then '&' else '|' " & _
            " 	end as nvarchar(1000)) as RuleExpStr " & _
            " FROM PUB_Rule_Detail d2 " & _
            " 	inner join PUB_Item tt " & _
            " 		on (d2.Item_Code = tt.Item_Code) " & _
            " 	inner join PUB_Syscode s1 " & _
            " 		on (s1.Type_Id = 802 and tt.Class_Code = s1.Code_Id) " & _
            " 	inner join PUB_Syscode s2 " & _
            " 		on (s2.Type_Id = 804 and d2.Operator_Code = s2.Code_Id) " & _
            " 	left  join PUB_Unit uu " & _
            " 		on (rtrim(uu.Unit_Code) = rtrim(d2.Value_Unit)) " & _
            " where d2.Rule_Code = @Rule_Code " & _
            " order by d2.Rule_Code, d2.Seq_No " & _
            " ; " & _
            " Select A.Rule_Code as 'Rule_Code', B.Item_Code As 'Item_Code', B.Item_Name As 'Item_Name', B.Data_Type As 'Data_Type', B.Method_Code As 'Method_Code', " & _
            "     C.Code_En_Name As 'Class_Name', D.Field_Code As 'Field_Code', " & _
            "     B.Program_Code As 'Program_Code', A.Item_Param As 'Item_Param', " & _
            "     A.Value_Data As 'Value_Data', A.Operator_Code as 'Operator_Code'," & _
            "     A.Value_Unit As 'Value_Unit', A. Logical_Symbol As 'Logical_Symbol', A.Seq_No as 'Seq_No', B.Return_Checking_Flag as 'Return_Checking_Flag'," & _
            "     E.Check_Identity as 'Check_Identity', A.Is_Count_O as 'Is_Count_O', A.Is_Count_E as 'Is_Count_E', A.Is_Count_I as 'Is_Count_I',E.Ext_No as 'Ext_No' " & _
            " From PUB_Rule_Detail A, PUB_Item B, PUB_SYSCode C, PUB_Item_Field D, PUB_Rule E " & _
            " Where A.Rule_Code = @Rule_Code And " & _
            "     B.Item_Code = A.Item_Code And " & _
            "     C.Type_Id = '802' And C.Code_Id = B.Class_Code And " & _
            "     D.Class_Code = B.Class_Code And D.Field_Code = B.Field_Code And " & _
            "     A.Rule_Code = E.Rule_Code " & _
            " Order By A.Seq_No " & _
            "  " & _
            " Select * From PUB_Rule Where Rule_Code = @Rule_Code "
            command.Parameters.AddWithValue("@Rule_Code", RuleCode)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("CallForm")
                adapter.Fill(ds, "CallForm")
                adapter.FillSchema(ds, SchemaType.Mapped, "CallForm")
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 依照 RuleCode 取得 DB 資料，並取得該邏輯判斷式字串 ExpressionStr
    ''' </summary>
    ''' <param name="RuleCode">條件代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RuleExpressionStrQuery(ByVal RuleCode As String) As System.Data.DataSet
        Try
            Using sqlConn As SqlConnection = getConnection()
                Dim ds As New DataSet
                'Dim sqlConn As SqlConnection = getConnection()
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = " Select cast('(' + rtrim(tt.Item_Name) + ' ' + rtrim(s2.Code_Name) + ' ' + " & _
                                      " 	rtrim(d2.Value_Data) + " & _
                                      " 	case when uu.Unit_Name is null " & _
                                      " 		then rtrim(isnull(d2.Value_Unit,'')) " & _
                                      " 		else rtrim(uu.Unit_Name) " & _
                                      " 	end " & _
                                      " 	+ ')' + " & _
                                      " 	case rtrim(d2.Logical_Symbol) when 'AND' " & _
                                      " 		then ' 且' " & _
                                      " 		else ' 或' " & _
                                      " 	end as nvarchar(1000)) as RuleExpStrCht, " & _
                                      " 	cast('(' + rtrim(s1.Code_En_Name) + '@' + rtrim(tt.Field_Code) + " & _
                                      "     case tt.Data_Type when '1' " & _
                                      " 		then rtrim(s2.Code_En_Name)+ '''' + rtrim(d2.Value_Data) + '''' " & _
                                      " 		when '4' then " & _
                                      " 			case when tt.Return_Checking_Flag='N' " & _
                                      " 				then '=True' " & _
                                      " 				else rtrim(s2.Code_En_Name) + rtrim(d2.Value_Data) " & _
                                      " 			end " & _
                                      " 		else rtrim(s2.Code_En_Name) + rtrim(d2.Value_Data) " & _
                                      "     end " & _
                                      "     + ')' + " & _
                                      "     case rtrim(d2.Logical_Symbol) when 'AND' " & _
                                      " 		then '&' else '|' " & _
                                      " 	end as nvarchar(1000)) as RuleExpStr " & _
                                      " FROM PUB_Rule_Detail d2 " & _
                                      " 	inner join PUB_Item tt " & _
                                      " 		on (d2.Item_Code = tt.Item_Code) " & _
                                      " 	inner join PUB_Syscode s1 " & _
                                      " 		on (s1.Type_Id = 802 and tt.Class_Code = s1.Code_Id) " & _
                                      " 	inner join PUB_Syscode s2 " & _
                                      " 		on (s2.Type_Id = 804 and d2.Operator_Code = s2.Code_Id) " & _
                                      " 	left  join PUB_Unit uu " & _
                                      " 		on (rtrim(uu.Unit_Code) = rtrim(d2.Value_Unit)) " & _
                                      " where d2.Rule_Code = @Rule_Code " & _
                                      " order by d2.Rule_Code, d2.Seq_No "
                command.Parameters.AddWithValue("@Rule_Code", RuleCode)
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    adapter.Fill(ds, "PUB_Rule_Detail")
                    adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Rule_Detail")
                End Using
                Return ds
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    ''' <summary>
    ''' 依照 RuleCode 取得 DB 資料，並取得該邏輯判斷式字串 ExpressionStr
    ''' </summary>
    ''' <param name="RuleCode">條件代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RuleDetailQuery(ByVal RuleCode As String) As System.Data.DataSet
        Try
            Using sqlConn As SqlConnection = getConnection()
                Dim ds As New DataSet
                'Dim sqlConn As SqlConnection = getConnection()
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = " Select A.Rule_Code as 'Rule_Code', B.Item_Code As 'Item_Code', B.Item_Name As 'Item_Name', B.Data_Type As 'Data_Type', B.Method_Code As 'Method_Code', " & _
                                      "     C.Code_En_Name As 'Class_Name', D.Field_Code As 'Field_Code', " & _
                                      "     B.Program_Code As 'Program_Code', A.Item_Param As 'Item_Param', " & _
                                      "     A.Value_Data As 'Value_Data', A.Operator_Code as 'Operator_Code'," & _
                                      "     A.Value_Unit As 'Value_Unit', A. Logical_Symbol As 'Logical_Symbol', A.Seq_No as 'Seq_No', B.Return_Checking_Flag as 'Return_Checking_Flag'," & _
                                      "     E.Check_Identity as 'Check_Identity', A.Is_Count_O as 'Is_Count_O', A.Is_Count_E as 'Is_Count_E', A.Is_Count_I as 'Is_Count_I' " & _
                                      " From PUB_Rule_Detail A, PUB_Item B, PUB_SYSCode C, PUB_Item_Field D, PUB_Rule E " & _
                                      " Where A.Rule_Code = '" & RuleCode & "' And " & _
                                      "     B.Item_Code = A.Item_Code And " & _
                                      "     C.Type_Id = '802' And C.Code_Id = B.Class_Code And " & _
                                      "     D.Class_Code = B.Class_Code And D.Field_Code = B.Field_Code And " & _
                                      "     A.Rule_Code = E.Rule_Code " & _
                                      " Order By A.Seq_No "
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    adapter.Fill(ds, "PUB_Rule_Detail")
                    adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Rule_Detail")
                End Using
                Return ds
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得 CheckRule 所需資料庫資料
    ''' </summary>
    ''' <param name="RuleCode"></param>
    ''' <param name="ValueData"></param>
    ''' <param name="Source"></param>
    ''' <param name="Main_Identity_Id"></param>
    ''' <param name="Base_Date"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCheckRuleDS(ByVal RuleCode As String, ByVal ValueData As String, ByVal Source As String, ByVal Main_Identity_Id As String, ByVal Base_Date As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = _
            " Select TOP 1 rc.*,r.Ext_No " & _
            " From PUB_Rule_Class rc " & _
            "   inner join PUB_Rule_Detail rd " & _
            "       on (rc.Condition_Rule_Code = rd.Rule_Code and rd.Value_Data = @Value_Data) " & _
            " Left join PUB_Rule r on r.Rule_Code=rd.Rule_Code " & _
            " Where rc.Rule_Code = @Rule_Code " & _
            " ; " & _
            " Select * From PUB_Rule Where Rule_Code = @Rule_Code "

            Select Case Source
                Case "CO", "PO"
                    command.CommandText &= " and Is_Only_CO = @Source "
                    command.Parameters.AddWithValue("@Source", "Y")
                Case "CE", "PE"
                    command.CommandText &= " and Is_Only_CE = @Source "
                    command.Parameters.AddWithValue("@Source", "Y")
                Case "CI", "PI"
                    command.CommandText &= " and Is_Only_CI = @Source "
                    command.Parameters.AddWithValue("@Source", "Y")
                Case "SO"
                    command.CommandText &= " and Is_Only_SO = @Source "
                    command.Parameters.AddWithValue("@Source", "Y")
                Case "SE"
                    command.CommandText &= " and Is_Only_SE = @Source "
                    command.Parameters.AddWithValue("@Source", "Y")
                Case "SI"
                    command.CommandText &= " and Is_Only_SI = @Source "
                    command.Parameters.AddWithValue("@Source", "Y")
                Case Else
                    'Throw New Exception("錯誤的來源")
            End Select

            If Main_Identity_Id = "1" Or Main_Identity_Id = "3" Then
                command.CommandText &= " and (Check_Identity = '0' Or Check_Identity = '1') "
            ElseIf Main_Identity_Id = "2" Then
                command.CommandText &= " and (Check_Identity = '0' Or Check_Identity = '2') "
            End If

            command.CommandText &= " and Valid_Date_S <= @Base_Date and Valid_Date_E >= @Base_Date "
            command.Parameters.AddWithValue("@Value_Data", ValueData)
            command.Parameters.AddWithValue("@Rule_Code", RuleCode)
            command.Parameters.AddWithValue("@Base_Date", Base_Date)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("CheckRule")
                adapter.Fill(ds, "CheckRule")
                adapter.FillSchema(ds, SchemaType.Mapped, "CheckRule")
            End Using
            Return ds
        Catch sqlex As SqlException
            log.dbErrorMsg("getCheckRuleDS_sqlex：" & sqlex.Message, sqlex)
            Throw sqlex
        Catch ex As Exception
            log.dbErrorMsg("getCheckRuleDS_ex：" & ex.Message, ex)
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' 依照 RuleCode 取得 DB 資料，取得起始條件、成功失敗條件的 RuleCode
    ''' </summary>
    ''' <param name="RuleCode">條件代碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RuleClassQuery(ByVal RuleCode As String, ByVal ValueData As String) As System.Data.DataSet
        Try
            Using sqlConn As SqlConnection = getConnection()
                Dim ds As New DataSet
                'Dim sqlConn As SqlConnection = getConnection()
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = _
                " Select TOP 1 rc.* " & _
                " From PUB_Rule_Class rc " & _
                "   inner join PUB_Rule_Detail rd " & _
                "       on (rc.Condition_Rule_Code = rd.Rule_Code and rd.Value_Data = @Value_Data) " & _
                " Where rc.Rule_Code=@Rule_Code "
                command.Parameters.AddWithValue("@Rule_Code", RuleCode)
                command.Parameters.AddWithValue("@Value_Data", ValueData)
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    adapter.Fill(ds, "PUB_Rule_Class")
                    adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Rule_Class")
                End Using
                Return ds
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''以ＰＫ查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function RuleQueryByCond(ByRef pk_Rule_Code As System.String, ByVal Source As String, ByVal Main_Identity_Id As String, ByVal Base_Date As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As System.Data.DataSet
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            command.CommandText = "select * from PUB_Rule where Rule_Code=@Rule_Code "

            Select Case Source
                Case "CO", "PO"
                    command.CommandText &= " and Is_Only_CO=@Source "
                    command.Parameters.AddWithValue("@Source", "Y")
                Case "CE", "PE"
                    command.CommandText &= " and Is_Only_CE=@Source "
                    command.Parameters.AddWithValue("@Source", "Y")
                Case "CI", "PI"
                    command.CommandText &= " and Is_Only_CI=@Source "
                    command.Parameters.AddWithValue("@Source", "Y")
                Case "SO"
                    command.CommandText &= " and Is_Only_SO=@Source "
                    command.Parameters.AddWithValue("@Source", "Y")
                Case "SE"
                    command.CommandText &= " and Is_Only_SE=@Source "
                    command.Parameters.AddWithValue("@Source", "Y")
                Case "SI"
                    command.CommandText &= " and Is_Only_SI=@Source "
                    command.Parameters.AddWithValue("@Source", "Y")
                Case Else
                    'Throw New Exception("錯誤的來源")
            End Select

            If Main_Identity_Id = "1" Or Main_Identity_Id = "3" Then
                command.CommandText &= " and (Check_Identity='0' Or Check_Identity='1') "
            ElseIf Main_Identity_Id = "2" Then
                command.CommandText &= " and (Check_Identity='0' Or Check_Identity='2') "
            End If

            command.CommandText &= " and Valid_Date_S<=@Base_Date and Valid_Date_E>=@Base_Date "
            command.Parameters.AddWithValue("@Rule_Code", pk_Rule_Code)
            command.Parameters.AddWithValue("@Base_Date", Base_Date)
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet("PUB_Rule")
                adapter.Fill(ds, "PUB_Rule")
                adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Rule")
            End Using
            Return ds
        Catch sqlex As SqlException
            Throw sqlex
        Catch ex As Exception
            Throw ex
        Finally
            If connFlag Then
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End If
        End Try
    End Function

    ''' <summary>
    ''' Order_Code 轉 Insu_Code
    ''' </summary>
    ''' <param name="OrderCode">成大碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RuleCodeTransfer1(ByVal OrderCode As String) As System.Data.DataSet
        Try
            Using sqlConn As SqlConnection = getConnection()
                Dim ds As New DataSet
                'Dim sqlConn As SqlConnection = getConnection()
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = _
                " Select TOP 1 Insu_Code " & _
                " From PUB_Order_Price " & _
                " Where Order_Code = @Order_Code And Insu_Code is not NULL And Insu_Code <> '' "
                command.Parameters.AddWithValue("@Order_Code", OrderCode)
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    adapter.Fill(ds, "PUB_Rule")
                    adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Rule")
                End Using
                Return ds
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Insu_Code 轉 Order_Code
    ''' </summary>
    ''' <param name="Insu_Code">健保碼</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RuleCodeTransfer2(ByVal Insu_Code As String) As System.Data.DataSet
        Try
            Using sqlConn As SqlConnection = getConnection()
                Dim ds As New DataSet
                'Dim sqlConn As SqlConnection = getConnection()
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = _
                " Select TOP 1 Order_Code " & _
                " From PUB_Order_Price " & _
                " Where Insu_Code = @Insu_Code And Order_Code is not NULL And Order_Code <> '' "
                command.Parameters.AddWithValue("@Insu_Code", Insu_Code)
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    adapter.Fill(ds, "PUB_Rule")
                    adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Rule")
                End Using
                Return ds
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得ItemName
    ''' </summary>
    ''' <param name="Item_Code">Item_Code</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryItemName(ByVal Item_Code As String) As System.Data.DataSet
        Try
            Using sqlConn As SqlConnection = getConnection()
                Dim ds As New DataSet
                'Dim sqlConn As SqlConnection = getConnection()
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = _
                " Select Item_Code, Item_Name " & _
                " From PUB_Item " & _
                " Where Item_Code in (" & Item_Code & ") "
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    adapter.Fill(ds, "ItemName")
                    adapter.FillSchema(ds, SchemaType.Mapped, "ItemName")
                End Using
                Return ds
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 取得對應的RuleCode
    ''' </summary>
    ''' <param name="Item_Code">Item_Code</param>
    ''' <param name="Value_Data">Value_Data</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryRuleValueData(ByVal Item_Code As String, ByVal Value_Data As String) As System.Data.DataSet
        Try
            Using sqlConn As SqlConnection = getConnection()
                Dim ds As New DataSet
                'Dim sqlConn As SqlConnection = getConnection()
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = _
                " Select DISTINCT B.Rule_Code " & _
                " From PUB_RULE_Detail A, PUB_Rule_Class B " & _
                " Where A.Item_Code = @Item_Code And A.Value_Data = @Value_Data And " & _
                "     B.Condition_Type = '1' And B.Condition_Rule_Code = A.Rule_Code And B.Condition_Rule_Code <> B.Rule_Code "
                command.Parameters.AddWithValue("@Item_Code", Item_Code)
                command.Parameters.AddWithValue("@Value_Data", Value_Data)
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    adapter.Fill(ds, "PUB_Rule")
                    adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Rule")
                End Using
                Return ds
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryClassAndField(ByVal Item_Code As String, ByVal Value_Data As String) As System.Data.DataSet
        Try
            Using sqlConn As SqlConnection = getConnection()
                Dim ds As New DataSet
                'Dim sqlConn As SqlConnection = getConnection()
                Dim command As SqlCommand = sqlConn.CreateCommand()
                command.CommandText = _
                " Select B.Code_En_Name as TableName, A.Field_Code as ColumnName " & _
                " From PUB_Item A " & _
                " 	inner join PUB_Syscode B on A.Class_Code = B.Code_Id and B.Type_Id = '802' " & _
                " Where A.Item_Code = @Item_Code "
                command.Parameters.AddWithValue("@Item_Code", Item_Code)
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    adapter.Fill(ds, "PUB_Rule")
                    adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Rule")
                End Using
                Return ds
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function queryRuleCode(ByVal Item_Code As String, ByVal Value_Data As String, ByVal Base_Date As String) As System.Data.DataSet
        Try
            Dim Value_Data_X As String = ""
            If Item_Code.Equals("A00025") OrElse Item_Code.Equals("A00024") Then
                If Value_Data.Length > 3 Then
                    Value_Data_X = Value_Data.Substring(0, 3) + "X"
                End If
                '2013-09-06 025162 for bug 
            End If

            Using sqlConn As SqlConnection = getConnection()

                Using command As SqlCommand = sqlConn.CreateCommand()
                    '新增SELECT PUB_Rule.Rule_Name欄位 2014-2-25  黃富昌
                    'command.CommandText = "SELECT DISTINCT B.Rule_Code" & _
                    command.CommandText = "SELECT DISTINCT B.Rule_Code, D.Rule_Name " & _
                                           " FROM PUB_RULE_Detail A WITH(NOLOCK)" & _
                                          " INNER JOIN PUB_Rule_Class B WITH(NOLOCK) ON B.Condition_Rule_Code = A.Rule_Code" & _
                                                                                  " AND B.Condition_Type = '1'" & _
                                                                                  " AND B.Condition_Rule_Code <> B.Rule_Code" & _
                                          " INNER JOIN PUB_Item C WITH(NOLOCK) ON A.Item_Code = C.Item_Code" & _
                                          " INNER JOIN PUB_Rule D WITH(NOLOCK) ON A.Rule_Code = D.Rule_Code" & _
                                                                            " AND @Base_Date BETWEEN D.Valid_Date_S AND D.Valid_Date_E" & _
                                          " WHERE  A.Item_Code = @Item_Code"

                    If Value_Data_X.Length = 0 Then
                        command.CommandText &= " AND A.Value_Data = @Value_Data"
                    Else
                        command.CommandText &= " AND (A.Value_Data = @Value_Data " & _
                                                " OR  A.Value_Data = @Value_Data_X)"
                    End If

                    command.Parameters.AddWithValue("@Item_Code", Item_Code)

                    Dim sqlPar As SqlParameter = command.Parameters.Add("@Value_Data", SqlDbType.NVarChar, 1000)
                    If Value_Data.Length > 1000 Then
                        sqlPar.Value = Value_Data.Substring(0, 1000)
                    Else
                        sqlPar.Value = Value_Data
                    End If

                    Dim sqlPar2 As SqlParameter = command.Parameters.Add("@Value_Data_X", SqlDbType.NVarChar, 1000)
                    If Value_Data_X.Length > 1000 Then
                        sqlPar2.Value = Value_Data_X.Substring(0, 1000)
                    Else
                        sqlPar2.Value = Value_Data_X
                    End If

                    Dim sqlPar3 As SqlParameter = command.Parameters.Add("@Base_Date", SqlDbType.NVarChar, 20)
                    If Base_Date.Length > 20 Then
                        sqlPar3.Value = Base_Date.Substring(0, 20)
                    Else
                        sqlPar3.Value = Base_Date
                    End If

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        Using ds As New DataSet
                            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                            adapter.Fill(ds, "PUB_RuleCode")
                            Return ds
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            log.dbErrorMsg("queryRuleCode：" & ex.Message, ex)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 轉換 ItemCode 為 RuleCode，並進行檢核
    ''' </summary>
    ''' <param name="Location"></param>
    ''' <param name="SystemType"></param>
    ''' <param name="TriggerItemSet">檢查項目代碼</param>
    ''' <param name="OperationDS">檢查項目值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function initRuleTransfer(ByVal Location As String, ByVal SystemType As String, ByVal TriggerItemSet As DataSet, ByVal OperationDS As DataSet) As System.Data.DataSet
        Try
            Using sqlConn As SqlConnection = getConnection()
                Dim ds As New DataSet
                'Dim sqlConn As SqlConnection = getConnection()
                Dim command As SqlCommand = sqlConn.CreateCommand()

                For Each row As DataRow In TriggerItemSet.Tables(0).Rows

                Next

                command.CommandText = _
                " Select B.Rule_Code " & _
                " From PUB_RULE_Detail A,PUB_Rule_Class B " & _
                "     B.Condition_Type = '1' And B.Condition_Rule_Code = A.Rule_Code "
                Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                    adapter.Fill(ds, "PUB_Rule")
                    adapter.FillSchema(ds, SchemaType.Mapped, "PUB_Rule")
                End Using

                Return ds
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 搜尋歷史醫令
    ''' </summary>
    ''' <param name="Medical_Sn">就醫序號</param>
    ''' <param name="SystemType">系統歸屬 {O}門診 or {E}急診 or {I}住院</param>
    ''' <param name="Location">C , P  , S</param>
    ''' <returns>所有歷史醫令的資料集</returns>
    ''' <remarks>by Rich on 2012-05-30</remarks>
    Public Function GetCurrentOrderset(ByVal Medical_Sn As String, ByVal SystemType As String, ByVal Location As String) As DataSet
        Try
            Dim ds As New DataSet
            'Dim sqlConn As SqlConnection
            Select Case SystemType
                Case "O"
                    Using sqlConn As SqlConnection = getOPDConnection()
                        Dim command As SqlCommand = sqlConn.CreateCommand()
                        Dim sqlString As New System.Text.StringBuilder
                        sqlString.Append("SELECT X.* " & vbCrLf)
                        sqlString.Append("FROM   OMO_Order_Record X " & vbCrLf)
                        sqlString.Append("WHERE  X.Outpatient_Sn = '" & Medical_Sn & "' " & vbCrLf)
                        sqlString.Append("       AND ( X.Dc = 'N' " & vbCrLf)
                        sqlString.Append("              OR X.Dc IS NULL ) " & vbCrLf)
                        sqlString.Append("       AND ( X.Cancel = 'N' " & vbCrLf)
                        sqlString.Append("              OR X.Cancel IS NULL ) " & vbCrLf)
                        sqlString.Append("       AND X.Order_Code NOT IN (SELECT DISTINCT A.Order_Code " & vbCrLf)
                        sqlString.Append("                                FROM   OMO_Order_Record AS A " & vbCrLf)
                        sqlString.Append("                                       INNER JOIN PUB_Order AS B " & vbCrLf)
                        sqlString.Append("                                         ON A.Order_Code = B.Order_Code " & vbCrLf)
                        sqlString.Append("                                            AND B.Order_Type_Id = 'H' " & vbCrLf)
                        sqlString.Append("                                            AND ( B.Treatment_Type_Id = '3' " & vbCrLf)
                        sqlString.Append("                                                   OR B.Treatment_Type_Id = '4' ) " & vbCrLf)
                        sqlString.Append("                                WHERE  A.Outpatient_Sn = '" & Medical_Sn & "' " & vbCrLf)
                        sqlString.Append("                                       AND ( A.Dc = 'N' " & vbCrLf)
                        sqlString.Append("                                              OR A.Dc IS NULL ) " & vbCrLf)
                        sqlString.Append("                                       AND ( A.Cancel = 'N' " & vbCrLf)
                        sqlString.Append("                                              OR A.Cancel IS NULL )) " & vbCrLf)
                        sqlString.Append("ORDER  BY X.Order_Record_No ")

                        command.CommandText = sqlString.ToString
                        Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                            adapter.Fill(ds, "OMO_Order_Record")
                            'adapter.FillSchema(ds, SchemaType.Mapped, "OMO_Order_Record")
                        End Using
                    End Using
                Case "E"
                    Using sqlConn As SqlConnection = getEPDConnection()
                        Dim command As SqlCommand = sqlConn.CreateCommand()
                        Dim sqlString As New System.Text.StringBuilder
                        sqlString.Append("SELECT X.* " & vbCrLf)
                        sqlString.Append("FROM   EMO_Order_Record X " & vbCrLf)
                        sqlString.Append("WHERE  X.Outpatient_Sn = '" & Medical_Sn & "' " & vbCrLf)
                        sqlString.Append("       AND ( X.Dc = 'N' " & vbCrLf)
                        sqlString.Append("              OR X.Dc IS NULL ) " & vbCrLf)
                        sqlString.Append("       AND ( X.Cancel = 'N' " & vbCrLf)
                        sqlString.Append("              OR X.Cancel IS NULL ) " & vbCrLf)
                        sqlString.Append("       AND X.Order_Code NOT IN (SELECT DISTINCT A.Order_Code " & vbCrLf)
                        sqlString.Append("                                FROM   EMO_Order_Record AS A " & vbCrLf)
                        sqlString.Append("                                       INNER JOIN PUB_Order AS B " & vbCrLf)
                        sqlString.Append("                                         ON A.Order_Code = B.Order_Code " & vbCrLf)
                        sqlString.Append("                                            AND B.Order_Type_Id = 'H' " & vbCrLf)
                        sqlString.Append("                                            AND ( B.Treatment_Type_Id = '3' " & vbCrLf)
                        sqlString.Append("                                                   OR B.Treatment_Type_Id = '4' ) " & vbCrLf)
                        sqlString.Append("                                WHERE  A.Outpatient_Sn = '" & Medical_Sn & "' " & vbCrLf)
                        sqlString.Append("                                       AND ( A.Dc = 'N' " & vbCrLf)
                        sqlString.Append("                                              OR A.Dc IS NULL ) " & vbCrLf)
                        sqlString.Append("                                       AND ( A.Cancel = 'N' " & vbCrLf)
                        sqlString.Append("                                              OR A.Cancel IS NULL )) " & vbCrLf)
                        sqlString.Append("ORDER  BY X.Order_Record_No ")

                        command.CommandText = sqlString.ToString
                        Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                            adapter.Fill(ds, "EMO_Order_Record")
                            'adapter.FillSchema(ds, SchemaType.Mapped, "EMO_Order_Record")
                        End Using
                    End Using
                Case "I"
                    Using sqlConn As SqlConnection = getPCSConnection()
                        Dim command As SqlCommand = sqlConn.CreateCommand()
                        Dim sqlString As New System.Text.StringBuilder

                        Select Case Location
                            Case "C"
                                sqlString.Append("SELECT X.Order_Code, " & vbCrLf)
                                sqlString.Append("       P.Pharmacy_12_Code, " & vbCrLf)
                                sqlString.Append("       X.Order_Date, " & vbCrLf)
                                sqlString.Append("       X.Body_Site_Code, " & vbCrLf)
                                sqlString.Append("       X.Side_Id                             AS [Body_Side_Code], " & vbCrLf)
                                sqlString.Append("       X.Dosage, " & vbCrLf)
                                sqlString.Append("       X.Dosage_Unit, " & vbCrLf)
                                sqlString.Append("       X.Frequency_Code, " & vbCrLf)
                                sqlString.Append("       CASE " & vbCrLf)
                                sqlString.Append("         WHEN Isnull(X.Medication_Type_Sign, '') = 'H' THEN X.Duration " & vbCrLf)
                                sqlString.Append("         ELSE 1 " & vbCrLf)
                                sqlString.Append("       END                                   AS [Days], " & vbCrLf)
                                sqlString.Append("       X.Tqty, " & vbCrLf)
                                sqlString.Append("       X.Tqty_Unit, " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                AS [Is_Chronic_Card], " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                AS [Is_Cure], " & vbCrLf)
                                sqlString.Append("       1                                     AS [Medicine_Cnt], " & vbCrLf)
                                sqlString.Append("       X.Specimen_Id, " & vbCrLf)
                                sqlString.Append("       CASE " & vbCrLf)
                                sqlString.Append("         WHEN X.[Start_Date] IS NULL THEN LEFT(CONVERT(VARCHAR(30), X.Create_Time, 121), 16) " & vbCrLf)
                                sqlString.Append("         ELSE CONVERT(DATETIME, CONVERT(VARCHAR(30), X.[Start_Date], 121) + ' ' + LEFT(Replace(X.Start_HHMM, ':', '0'), 2) + ':' + RIGHT(Replace(X.Start_HHMM, ':', '0'), 2)) " & vbCrLf)
                                sqlString.Append("       END                                   AS [Order_Effect_Date], " & vbCrLf)
                                sqlString.Append("       CASE " & vbCrLf)
                                sqlString.Append("         WHEN X.End_Date IS NULL " & vbCrLf)
                                sqlString.Append("               OR X.End_Date = '' THEN " & vbCrLf)
                                sqlString.Append("           CASE " & vbCrLf)
                                sqlString.Append("             WHEN X.[Start_Date] IS NULL THEN LEFT(CONVERT(VARCHAR(30), Dateadd(day, Isnull(X.Duration, 1), X.Create_Time), 121), 16) " & vbCrLf)
                                sqlString.Append("             ELSE CONVERT(DATETIME, CONVERT(VARCHAR(30), Dateadd(day, Isnull(X.Duration, 1), X.[Start_Date]), 121) + ' ' + LEFT(Replace(X.Start_HHMM, ':', '0'), 2) + ':' + RIGHT(Replace(X.Start_HHMM, ':', '0'), 2)) " & vbCrLf)
                                sqlString.Append("           END " & vbCrLf)
                                sqlString.Append("         ELSE CONVERT(DATETIME, CONVERT(VARCHAR(30), X.End_Date, 121) + ' ' + LEFT(Replace(X.End_HHMM, ':', '0'), 2) + ':' + RIGHT(Replace(X.End_HHMM, ':', '0'), 2)) " & vbCrLf)
                                sqlString.Append("       END                                   AS [Order_End_Date], " & vbCrLf)
                                sqlString.Append("       X.Dr_Employee_Code                    AS [Order_Doctor_Code], " & vbCrLf)
                                sqlString.Append("       X.Usage_Code, " & vbCrLf)
                                sqlString.Append("       X.Consumption_Unit                   AS [Consumption_Dept], " & vbCrLf)
                                sqlString.Append("       CASE " & vbCrLf)
                                sqlString.Append("         WHEN Isnull(X.Order_Type_Id, '') = 'G' THEN Isnull(Is_Material_Force, 'N') " & vbCrLf)
                                sqlString.Append("         ELSE Isnull(Is_Force, 'N') " & vbCrLf)
                                sqlString.Append("       END                                   AS [Is_Force], " & vbCrLf)
                                sqlString.Append("       P.Class_Code, " & vbCrLf)
                                sqlString.Append("       Isnull(P.Order_Name, D.Order_En_Name) AS [Order_Name], " & vbCrLf)
                                sqlString.Append("       Isnull(X.Is_Self_Pay, 'N')            AS [Is_Self_Pay], " & vbCrLf)
                                sqlString.Append("       Isnull(X.Is_Preadmission, 'N')        AS [Is_Preadmission], " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                AS [Is_Pre_Or_Examination,], " & vbCrLf)
                                sqlString.Append("       X.Dr_Employee_Code                    AS [Order_VS_Code], " & vbCrLf)
                                sqlString.Append("       X.Order_Record_No, " & vbCrLf)
                                sqlString.Append("       X.Drip " & vbCrLf)
                                sqlString.Append("FROM   IMO_Order_Record X " & vbCrLf)
                                sqlString.Append("       LEFT OUTER JOIN OPH_Pharmacy_Base P " & vbCrLf)
                                sqlString.Append("         ON X.Order_Code = P.Order_Code " & vbCrLf)
                                sqlString.Append("       LEFT OUTER JOIN PUB_Order D " & vbCrLf)
                                sqlString.Append("         ON X.Order_Code = D.Order_Code " & vbCrLf)
                                sqlString.Append("            AND D.Dc = 'N' " & vbCrLf)
                                sqlString.Append("WHERE  X.Case_No = '" & Medical_Sn & "' " & vbCrLf)
                                sqlString.Append("       AND X.Dc <> 'Y'" & vbCrLf)

                                sqlString.Append("       AND X.Start_Date <=GETDATE() " & vbCrLf)
                                sqlString.Append("       AND X.End_Date >=GETDATE () " & vbCrLf)


                                sqlString.Append("       AND ( X.Cancel = 'N' " & vbCrLf)
                                sqlString.Append("              OR X.Cancel IS NULL ) " & vbCrLf)
                                sqlString.Append("       AND X.Order_Code NOT IN (SELECT DISTINCT A.Order_Code " & vbCrLf)
                                sqlString.Append("                                FROM   IMO_Order_Record AS A " & vbCrLf)
                                sqlString.Append("                                       INNER JOIN PUB_Order AS B " & vbCrLf)
                                sqlString.Append("                                         ON A.Order_Code = B.Order_Code " & vbCrLf)
                                sqlString.Append("                                            AND B.Order_Type_Id = 'H' " & vbCrLf)
                                sqlString.Append("                                            AND ( B.Treatment_Type_Id = '3' " & vbCrLf)
                                sqlString.Append("                                                   OR B.Treatment_Type_Id = '4' ) " & vbCrLf)
                                sqlString.Append("                                WHERE  A.Case_No = '" & Medical_Sn & "' " & vbCrLf)
                                sqlString.Append("                                       AND ( A.Dc = 'N' " & vbCrLf)
                                sqlString.Append("                                              OR A.Dc IS NULL ) " & vbCrLf)
                                sqlString.Append("                                       AND ( A.Cancel = 'N' " & vbCrLf)
                                sqlString.Append("                                              OR A.Cancel IS NULL )) " & vbCrLf)
                                sqlString.Append("ORDER  BY X.Order_Record_No ")
                            Case "P"
                                sqlString.Append("SELECT X.Order_Code                                      AS [Order_Code], " & vbCrLf)
                                sqlString.Append("       X.Insu_Code                                       AS [Insu_Code], " & vbCrLf)
                                sqlString.Append("       P.Pharmacy_12_Code, " & vbCrLf)
                                sqlString.Append("       X.Account_Date                                    AS [Order_Date], " & vbCrLf)
                                sqlString.Append("       X.Body_Site_Code, " & vbCrLf)
                                sqlString.Append("       X.Side_Id                                         AS [Body_Side_Code], " & vbCrLf)
                                sqlString.Append("       X.Dosage, " & vbCrLf)
                                sqlString.Append("       X.Dosage_Unit, " & vbCrLf)
                                sqlString.Append("       X.Frequency_Code, " & vbCrLf)
                                sqlString.Append("       CASE " & vbCrLf)
                                sqlString.Append("         WHEN Isnull(X.Medication_Type_Sign, '') = 'H' THEN R.Duration " & vbCrLf)
                                sqlString.Append("         ELSE 1 " & vbCrLf)
                                sqlString.Append("       END                                               AS [Days], " & vbCrLf)
                                sqlString.Append("       X.Remain_Qty                                      AS [Tqty], " & vbCrLf)
                                sqlString.Append("       X.Material_Unit                                   AS [Tqty_Unit], " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                            AS [Is_Chronic_Card], " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                            AS [Is_Cure], " & vbCrLf)
                                sqlString.Append("       1                                                 AS [Medicine_Cnt], " & vbCrLf)
                                sqlString.Append("       R.Specimen_Id, " & vbCrLf)
                                sqlString.Append("       X.Account_Date                                    AS [Order_Effect_Date], " & vbCrLf)
                                sqlString.Append("       X.Account_Date                                    AS [Order_End_Date], " & vbCrLf)
                                sqlString.Append("       X.Dr_Employee_Code                                AS [Order_Doctor_Code], " & vbCrLf)
                                sqlString.Append("       X.Usage_Code, " & vbCrLf)
                                sqlString.Append("       X.Consumption_Unit                                AS [Consumption_Dept], " & vbCrLf)
                                sqlString.Append("       X.Is_Force                                      AS [Is_Force], " & vbCrLf)
                                sqlString.Append("       P.Class_Code, " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                            AS [Is_Self_Pay], " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                            AS [Is_Preadmission], " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                            AS [Is_Pre_Or_Examination], " & vbCrLf)
                                sqlString.Append("       X.Dr_Employee_Code                                AS [Order_VS_Code], " & vbCrLf)
                                sqlString.Append("       Isnull(R.Order_Record_No, 990000 + X.Material_No) AS [Order_Record_No] " & vbCrLf)
                                sqlString.Append("FROM   STA_Material_Detail X " & vbCrLf)
                                sqlString.Append("       LEFT OUTER JOIN IMO_Order_Record R " & vbCrLf)
                                sqlString.Append("         ON X.Case_No = R.Case_No " & vbCrLf)
                                sqlString.Append("            AND X.Order_Record_No = R.Order_Record_No " & vbCrLf)
                                sqlString.Append("       LEFT OUTER JOIN OPH_Pharmacy_Base P " & vbCrLf)
                                sqlString.Append("         ON X.Order_Code = P.Order_Code " & vbCrLf)
                                sqlString.Append("WHERE  X.Case_No = '" & Medical_Sn & "' " & vbCrLf)
                                sqlString.Append("       AND ( X.Cancel = 'N' " & vbCrLf)
                                sqlString.Append("              OR X.Cancel IS NULL ) " & vbCrLf)
                                sqlString.Append("       AND X.Order_Code NOT IN (SELECT DISTINCT A.Order_Code " & vbCrLf)
                                sqlString.Append("                                FROM   IMO_Order_Record AS A " & vbCrLf)
                                sqlString.Append("                                       INNER JOIN PUB_Order AS B " & vbCrLf)
                                sqlString.Append("                                         ON A.Order_Code = B.Order_Code " & vbCrLf)
                                sqlString.Append("                                            AND B.Order_Type_Id = 'H' " & vbCrLf)
                                sqlString.Append("                                            AND ( B.Treatment_Type_Id = '3' " & vbCrLf)
                                sqlString.Append("                                                   OR B.Treatment_Type_Id = '4' ) " & vbCrLf)
                                sqlString.Append("                                WHERE  A.Case_No = '" & Medical_Sn & "' " & vbCrLf)
                                sqlString.Append("                                       AND ( A.Dc = 'N' " & vbCrLf)
                                sqlString.Append("                                              OR A.Dc IS NULL ) " & vbCrLf)
                                sqlString.Append("                                       AND ( A.Cancel = 'N' " & vbCrLf)
                                sqlString.Append("                                              OR A.Cancel IS NULL )) " & vbCrLf)
                                sqlString.Append("ORDER  BY X.Order_Record_No ")
                            Case "S"
                                sqlString.Append("SELECT X.Order_Code                                                                                                                  AS [Order_Code], " & vbCrLf)
                                sqlString.Append("       X.Insu_Code                                                                                                                   AS [Insu_Code], " & vbCrLf)
                                sqlString.Append("       X.Execute_Date_S                                                                                                              AS [Order_Date], " & vbCrLf)
                                sqlString.Append("       X.Body_Site_Code, " & vbCrLf)
                                sqlString.Append("       X.Side_Id                                                                                                                     AS [Body_Side_Code], " & vbCrLf)
                                sqlString.Append("       X.Dosage, " & vbCrLf)
                                sqlString.Append("       X.Dosage_Unit, " & vbCrLf)
                                sqlString.Append("       X.Frequency_Code, " & vbCrLf)
                                sqlString.Append("       Datediff(day, X.Execute_Date_S, X.Execute_Date_E) + 1                                                                         AS [Days], " & vbCrLf)
                                sqlString.Append("       X.Apply_Qty                                                                                                                   AS [Tqty], " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                                                                                                        AS [Is_Chronic_Card], " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                                                                                                        AS [Is_Cure], " & vbCrLf)
                                sqlString.Append("       1                                                                                                                             AS [Medicine_Cnt], " & vbCrLf)
                                sqlString.Append("       CONVERT(DATETIME, CONVERT(VARCHAR(30), Execute_Date_S, 121) + ' ' + LEFT(Execute_Time_S, 2) + ':' + RIGHT(Execute_Time_S, 2)) AS [Order_Effect_Date], " & vbCrLf)
                                sqlString.Append("       CONVERT(DATETIME, CONVERT(VARCHAR(30), Execute_Date_E, 121) + ' ' + LEFT(Execute_Time_E, 2) + ':' + RIGHT(Execute_Time_E, 2)) AS [Order_End_Date], " & vbCrLf)
                                sqlString.Append("       X.Dr_Employee_Code                                                                                                            AS [Order_Doctor_Code], " & vbCrLf)
                                sqlString.Append("       X.Usage_Code, " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                                                                                                        AS [Is_Force], " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                                                                                                        AS [Is_Self_Pay], " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                                                                                                        AS [Is_Preadmission], " & vbCrLf)
                                sqlString.Append("       CONVERT(NCHAR(1), 'N')                                                                                                        AS [Is_Pre_Or_Examination], " & vbCrLf)
                                sqlString.Append("       X.Dr_Employee_Code                                                                                                            AS [Order_VS_Code], " & vbCrLf)
                                sqlString.Append("       X.Order_No                                                                                                                    AS [Order_Record_No] " & vbCrLf)
                                sqlString.Append("FROM   IHD_Dclr_Detail X " & vbCrLf)
                                sqlString.Append("WHERE  X.Case_No = '" & Medical_Sn & "' " & vbCrLf)
                                sqlString.Append("       AND ( X.Cancel = 'N' " & vbCrLf)
                                sqlString.Append("              OR X.Cancel IS NULL ) " & vbCrLf)
                                sqlString.Append("       AND X.Order_Code NOT IN (SELECT DISTINCT A.Order_Code " & vbCrLf)
                                sqlString.Append("                                FROM   IMO_Order_Record AS A " & vbCrLf)
                                sqlString.Append("                                       INNER JOIN PUB_Order AS B " & vbCrLf)
                                sqlString.Append("                                         ON A.Order_Code = B.Order_Code " & vbCrLf)
                                sqlString.Append("                                            AND B.Order_Type_Id = 'H' " & vbCrLf)
                                sqlString.Append("                                            AND ( B.Treatment_Type_Id = '3' " & vbCrLf)
                                sqlString.Append("                                                   OR B.Treatment_Type_Id = '4' ) " & vbCrLf)
                                sqlString.Append("                                WHERE  A.Case_No = '" & Medical_Sn & "' " & vbCrLf)
                                sqlString.Append("                                       AND ( A.Dc = 'N' " & vbCrLf)
                                sqlString.Append("                                              OR A.Dc IS NULL ) " & vbCrLf)
                                sqlString.Append("                                       AND ( A.Cancel = 'N' " & vbCrLf)
                                sqlString.Append("                                              OR A.Cancel IS NULL )) " & vbCrLf)
                                sqlString.Append("ORDER  BY X.Order_No ")
                        End Select

                        command.CommandText = sqlString.ToString
                        Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                            adapter.Fill(ds, "IMO_Order_Record")
                            'adapter.FillSchema(ds, SchemaType.Mapped, "EMO_Order_Record")
                        End Using
                    End Using
            End Select

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

    Private Function getOPDConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function

    Private Function getEPDConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getEisDBSqlConn
    End Function

    Private Function getPCSConnection() As IDbConnection
        Return SQLConnFactory.getInstance.getPcsDBSqlConn
    End Function

End Class