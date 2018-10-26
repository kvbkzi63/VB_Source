Imports Syscom.Server.SQL
Imports System.Data.SqlClient
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.DataSetUtil
Imports System.Text

Public Class PUBRuleClassBO_E1
    Inherits PubRuleClassBO


#Region "########## getInstance ##########"

    Private Shared instance As PUBRuleClassBO_E1

    Public Overloads Shared Function getInstance() As PUBRuleClassBO_E1
        If instance Is Nothing Then
            instance = New PUBRuleClassBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 程式說明：依起始規則代碼查詢Rule_Code資料
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="initRuleCode">規則碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule_Class
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryRuleCodeByInitRuleCode(ByVal initRuleCode As String) As DataTable

        If initRuleCode IsNot Nothing AndAlso initRuleCode.Length > 0 Then

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
            cmdStr.Append("where Condition_Rule_Code = @Condition_Rule_Code ")
            cmdStr.Append("and Condition_Type = '1' and Seq_No = 1 ")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By Rule_Code, Seq_No ")
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@Condition_Rule_Code", initRuleCode)

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
            '無輸入資料
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' 程式說明：依起始規則代碼(多)查詢Rule_Code資料
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="initRuleCodes">規則碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule_Class
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryRuleCodeByInitRuleCodes(ByVal initRuleCodes() As String) As DataTable

        If initRuleCodes IsNot Nothing AndAlso initRuleCodes.Length > 0 Then

            Dim ruleStr As New StringBuilder

            For i As Integer = 0 To (initRuleCodes.Length - 1)
                ruleStr.Append("'").Append(initRuleCodes(i)).Append("'")
                If i < (initRuleCodes.Length - 1) Then
                    ruleStr.Append(",")
                End If
            Next


            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("select Rule_Code, Condition_Rule_Code ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("where Condition_Rule_Code in ( ")
            cmdStr.Append(ruleStr.ToString).Append(") ")
            cmdStr.Append("and Condition_Type = '1' and Seq_No = 1 ")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By Rule_Code, Seq_No ")
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            'sqlCmd.Parameters.AddWithValue("@Condition_Rule_Code", initRuleCode)

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
            '無輸入資料
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' 程式說明：依RuleCode查詢某rule的PUB_Rule_Class資料
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="RuleCode">規則碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule_Class
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryRuleClassByRuleCode(ByVal RuleCode As String) As DataTable


        'SELECT *
        'FROM PUB_Rule_Class
        'where (Rule_Code = 'PUB@A000040000011' and Condition_Type = '1') or (Condition_Rule_Code = 'PUB@A000040000011' and (Condition_Type = '2' or Condition_Type = '3') )

        If RuleCode IsNot Nothing AndAlso RuleCode.Length > 0 Then



            Dim cmdStr As New StringBuilder
            '『適應症檢核規則維護』，處理使用者按下【刪除】後無法將所有的規則內容從DB中刪除的問題 2013-12-31 黃富昌
            If RuleCode.Substring(0, 3).Equals("ICD") Then
                '----------------------------------------------------------------------------
                'Select SQL
                '----------------------------------------------------------------------------
                cmdStr.AppendLine("select distinct C.* ").AppendLine()
                '----------------------------------------------------------------------------
                'From&Join SQL
                '----------------------------------------------------------------------------
                cmdStr.Append("from ").Append(tableName).Append(" C ").AppendLine()
                '----------------------------------------------------------------------------
                'Where SQL
                '----------------------------------------------------------------------------
                cmdStr.Append("where C.Condition_Rule_Code in ").AppendLine()
                cmdStr.Append("( ").AppendLine()
                cmdStr.Append("select D2.Rule_Code ").AppendLine()
                cmdStr.Append("from PUB_Rule_Detail D1 inner join PUB_Rule_Detail D2 on D1.Rule_Code = @Rule_Code ").AppendLine()
                cmdStr.Append("and D1.Rule_Maintain_Sn = D2.Rule_Maintain_Sn ").AppendLine()
                cmdStr.Append(") ").AppendLine()
                '----------------------------------------------------------------------------
                'Order By SQL
                '----------------------------------------------------------------------------
                cmdStr.AppendLine("order by C.Rule_Code, C.Seq_No ")
            Else
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
                cmdStr.Append("where (Rule_Code = @Rule_Code and Condition_Type = '1') ")
                cmdStr.Append("or (Condition_Rule_Code = @Rule_Code and (Condition_Type = '2' or Condition_Type = '3') ) ")
                '----------------------------------------------------------------------------
                'Order By SQL
                '----------------------------------------------------------------------------
                cmdStr.AppendLine("Order By Rule_Code, Seq_No ")
            End If
            
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@Rule_Code", RuleCode)

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
            '無輸入資料
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' 查尋出起始條件資料
    ''' </summary>
    ''' <param name="RuleParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryInitRuleDataByParam(ByVal RuleParam As DataTable) As DataTable

        'select  rc.Condition_Rule_Code as Trigger_Rule_Code, 
        '        rc.Rule_Code as Check_Rule_Code,
        '        rc.Condition_Type as Condition_Type,
        '        rd.Item_Code, rd.Value_Data, rd.Rule_Maintain_Sn, 
        '        rr.Valid_Date_E, rr.Valid_Date_S, rr.Rule_Name, 
        '        rr.Limit_Alert_Level, rr.Check_Identity, rr.Check_Type,
        '        rm.Maintain_Value_Str()
        'from PUB_Rule_Class as rc 
        '     inner join PUB_Rule_Detail as rd 
        '            on (rc.Condition_Rule_Code = rd.Rule_Code and 
        '                rc.Condition_Type = '1' and 
        '                rd.Item_Code = 'A00004' 
        '                --and rd.Value_Data = 'E089229'
        '                ) 
        '     inner join PUB_Rule as rr
        '            on (rd.Rule_Code = rr.Rule_Code and
        '                rr.Valid_Date_S >= '2009-01-01' and
        '                rr.Valid_Date_E <= '2099-12-31' )
        '     left outer join PUB_Rule_Maintain as rm
        '            on (rm.Rule_Maintain_Sn = rd.Rule_Maintain_Sn)


        If DataSetUtil.IsContainsData(RuleParam) AndAlso (Not IsDBNull(RuleParam.Rows(0).Item("Item_Code"))) Then

            Dim ItemCode As String = ""
            Dim RuleName As String = ""
            Dim CheckType As String = ""
            Dim CheckIdentity As String = ""
            Dim LimitAlertLevel As String = ""
            Dim ValidDateS As Date = Now
            Dim ValidDateE As Date = Now


            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("select  rc.Condition_Rule_Code as Trigger_Rule_Code, ")
            cmdStr.AppendLine("        rc.Rule_Code as Check_Rule_Code, ")
            cmdStr.AppendLine("        rd.Item_Code, rd.Value_Data, rd.Rule_Maintain_Sn, ")
            cmdStr.AppendLine("        rr.Valid_Date_E, rr.Valid_Date_S, rr.Rule_Name, ")
            cmdStr.AppendLine("        rr.Limit_Alert_Level, rr.Check_Identity, rr.Check_Type, ")
            cmdStr.AppendLine("        rm.Maintain_Value_Str ")

            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" as rc ")
            cmdStr.AppendLine("     inner join PUB_Rule_Detail as rd on ")
            cmdStr.AppendLine("     (rc.Condition_Rule_Code = rd.Rule_Code ")
            cmdStr.AppendLine("     and rc.Condition_Type = '1' ")
            If Not IsDBNull(RuleParam.Rows(0).Item("Item_Code")) Then
                ItemCode = CType(RuleParam.Rows(0).Item("Item_Code"), String).Trim
                cmdStr.AppendLine("     and rd.Item_Code = @Item_Code ")
            End If

            'If Not IsDBNull(RuleParam.Rows(0).Item("Value_Data")) Then
            '    cmdStr.AppendLine("     and rd.Value_Data = @Value_Data ")
            'End If
            cmdStr.AppendLine(") ")

            cmdStr.AppendLine("     inner join PUB_Rule as rr ")
            cmdStr.AppendLine("          on (rd.Rule_Code = rr.Rule_Code ")

            ''"Rule_Name", 
            If Not IsDBNull(RuleParam.Rows(0).Item("Rule_Name")) Then
                RuleName = CType(RuleParam.Rows(0).Item("Rule_Name"), String).Trim
                cmdStr.AppendLine("          and rr.Rule_Name = @Rule_Name ")
            End If
            '"Check_Type", 
            If Not IsDBNull(RuleParam.Rows(0).Item("Check_Type")) Then
                CheckType = CType(RuleParam.Rows(0).Item("Check_Type"), String).Trim
                cmdStr.AppendLine("          and rr.Check_Type = @Check_Type ")
            End If
            '"Check_Identity", 
            If Not IsDBNull(RuleParam.Rows(0).Item("Check_Identity")) Then
                CheckIdentity = CType(RuleParam.Rows(0).Item("Check_Identity"), String).Trim
                cmdStr.AppendLine("          and rr.Check_Identity = @Check_Identity ")
            End If
            '"Limit_Alert_Level", 
            If Not IsDBNull(RuleParam.Rows(0).Item("Limit_Alert_Level")) Then
                LimitAlertLevel = CType(RuleParam.Rows(0).Item("Limit_Alert_Level"), String).Trim
                cmdStr.AppendLine("          and rr.Limit_Alert_Level = @Limit_Alert_Level ")
            End If
            If Not IsDBNull(RuleParam.Rows(0).Item("Valid_Date_S")) Then
                ValidDateS = CType(RuleParam.Rows(0).Item("Valid_Date_S"), Date)
                cmdStr.AppendLine("          and rr.Valid_Date_S >= @Valid_Date_S ")
            End If
            If Not IsDBNull(RuleParam.Rows(0).Item("Valid_Date_E")) Then
                ValidDateE = CType(RuleParam.Rows(0).Item("Valid_Date_E"), Date)
                cmdStr.AppendLine("          and rr.Valid_Date_E <= @Valid_Date_E ")
            End If
            cmdStr.AppendLine(") ")

            cmdStr.AppendLine("           left outer join PUB_Rule_Maintain as rm ")
            cmdStr.AppendLine(" on (rm.Rule_Maintain_Sn = rd.Rule_Maintain_Sn) ")

            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn
                            'Item_Code
                            If Not IsDBNull(RuleParam.Rows(0).Item("Item_Code")) Then
                                sqlCmd.Parameters.AddWithValue("@Item_Code", ItemCode)
                            End If
                            '"Rule_Name", 
                            If Not IsDBNull(RuleParam.Rows(0).Item("Rule_Name")) Then
                                sqlCmd.Parameters.AddWithValue("@Rule_Name", RuleName)
                            End If
                            '"Check_Type", 
                            If Not IsDBNull(RuleParam.Rows(0).Item("Check_Type")) Then
                                sqlCmd.Parameters.AddWithValue("@Check_Type", CheckType)
                            End If
                            '"Check_Identity", 
                            If Not IsDBNull(RuleParam.Rows(0).Item("Check_Identity")) Then
                                sqlCmd.Parameters.AddWithValue("@Check_Identity", CheckIdentity)
                            End If
                            '"Limit_Alert_Level", 
                            If Not IsDBNull(RuleParam.Rows(0).Item("Limit_Alert_Level")) Then
                                sqlCmd.Parameters.AddWithValue("@Limit_Alert_Level", LimitAlertLevel)
                            End If
                            '"Valid_Date_S", 
                            If Not IsDBNull(RuleParam.Rows(0).Item("Valid_Date_S")) Then
                                sqlCmd.Parameters.AddWithValue("@Valid_Date_S", ValidDateS)
                            End If
                            '"Valid_Date_E"}
                            If Not IsDBNull(RuleParam.Rows(0).Item("Valid_Date_E")) Then
                                sqlCmd.Parameters.AddWithValue("@Valid_Date_E", ValidDateE)
                            End If

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
    '''以Rule_Code刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function deleteByRuleCode(ByRef ruleCode As String) As Integer

        If ruleCode IsNot Nothing AndAlso ruleCode.Length > 0 Then
            
            Dim conn As SqlConnection = getConnection()

            Try
                Dim count As Integer = 0
                Dim cmdStr As StringBuilder = New StringBuilder
                '『適應症檢核規則維護』，處理使用者按下【刪除】後無法將所有的規則內容從DB中刪除的問題 2013-12-31 黃富昌
                If ruleCode.Substring(0, 3).Equals("ICD") Then
                    cmdStr.Append("delete from ").Append(tableName).AppendLine()
                    cmdStr.Append("where Condition_Rule_Code in ").AppendLine()
                    cmdStr.Append("( ").AppendLine()
                    cmdStr.Append("select D2.Rule_Code ").AppendLine()
                    cmdStr.Append("from PUB_Rule_Detail D1 inner join PUB_Rule_Detail D2 on D1.Rule_Code = @Rule_Code ").AppendLine()
                    cmdStr.Append("and D1.Rule_Maintain_Sn = D2.Rule_Maintain_Sn ").AppendLine()
                    cmdStr.Append(") ").AppendLine()
                Else
                    cmdStr.Append("delete from ").Append(tableName).AppendLine(" ")
                    cmdStr.Append("where (Rule_Code = @Rule_Code and Condition_Type = '1') ")
                    cmdStr.Append("or (Condition_Rule_Code = @Rule_Code and (Condition_Type = '2' or Condition_Type = '3') ) ")
                End If

                conn.Open()

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)

                        .Parameters.AddWithValue("@Rule_Code", ruleCode)

                    End With

                    count = command.ExecuteNonQuery
                End Using
                Return count
            Catch sqlex As SqlException
                Throw sqlex
            Catch ex As Exception
                Throw New CommonException("CMMCMMD004", ex)
            Finally
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End Try
        End If


    End Function

    '-----------------------------tree-------------------------------------------------------

    ''' <summary>
    ''' 程式說明：依RuleCode查詢某rule的PUB_Rule_Class資料
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="initRuleCode">起始規則碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule_Class
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryAllTreeRuleClassByInitRuleCode(ByVal initRuleCode As String) As DataTable

        If initRuleCode IsNot Nothing AndAlso initRuleCode.Length > 0 Then

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
            cmdStr.Append("where Condition_Rule_Code = @Init_Rule_Code and Condition_Type in ('A', '1', '2', '3') ")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By Rule_Code, Seq_No ")
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@Init_Rule_Code", initRuleCode)

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
            '無輸入資料
            Return Nothing
        End If

    End Function

    ''' <summary>
    '''以Init_Rule_Code刪除資料
    ''' </summary>
    ''' <remarks></remarks>
    Public Function deleteTreeByInitRuleCode(ByRef initRuleCode As String) As Integer

        If initRuleCode IsNot Nothing AndAlso initRuleCode.Length > 0 Then

            Dim conn As SqlConnection = getConnection()

            Try
                Dim count As Integer = 0
                Dim cmdStr As StringBuilder = New StringBuilder
                cmdStr.Append("delete from ").Append(tableName).AppendLine(" ")
                cmdStr.Append("where Condition_Rule_Code = @Init_Rule_Code and Condition_Type in ('A', '1', '2', '3') ")

                conn.Open()

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)

                        .Parameters.AddWithValue("@Init_Rule_Code", initRuleCode)

                    End With

                    count = command.ExecuteNonQuery
                End Using
                Return count
            Catch sqlex As SqlException
                Throw sqlex
            Catch ex As Exception
                Throw New CommonException("CMMCMMD004", ex)
            Finally
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End Try
        End If


    End Function


End Class
