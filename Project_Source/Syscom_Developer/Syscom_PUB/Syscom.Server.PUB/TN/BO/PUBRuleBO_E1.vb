Imports Syscom.Server.SQL
Imports System.Data.SqlClient
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.DataSetUtil
Imports System.Text

Public Class PUBRuleBO_E1
    Inherits PubRuleBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBRuleBO_E1

    Public Overloads Shared Function getInstance() As PUBRuleBO_E1
        If instance Is Nothing Then
            instance = New PUBRuleBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region

    ''' <summary>
    ''' 程式說明：依名稱查詢規則(for queryRuleDataByRuleParam use only)
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="RuleParam">規則參數</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryRuleDataByRuleParam(ByVal RuleParam As DataTable) As DataTable

        If DataSetUtil.IsContainsData(RuleParam) AndAlso (Not IsDBNull(RuleParam.Rows(0).Item("Item_Code"))) Then


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
            cmdStr.AppendLine("select R.* ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" R ")
            If Not IsDBNull(RuleParam.Rows(0).Item("Value_Data")) Then 'if valuedata left join pk
                cmdStr.Append("left join PUB_Rule_Detail D on R.Rule_Code = D.Rule_Code and D.Seq_No = 1 and D.Item_Code = '")
                cmdStr.Append(CType(RuleParam.Rows(0).Item("Item_Code"), String).Trim).Append("' and D.Value_Data = '")
                cmdStr.Append(CType(RuleParam.Rows(0).Item("Value_Data"), String).Trim).Append("' ")
            End If
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            '"Item_Code", 
            cmdStr.AppendLine("where R.Rule_Code like '%-S%' ")

            '"Rule_Name", 
            If Not IsDBNull(RuleParam.Rows(0).Item("Rule_Name")) Then
                RuleName = CType(RuleParam.Rows(0).Item("Rule_Name"), String).Trim
                cmdStr.AppendLine("and R.Rule_Name = @Rule_Name ")
            End If
            '"Check_Type", 
            If Not IsDBNull(RuleParam.Rows(0).Item("Check_Type")) Then
                CheckType = CType(RuleParam.Rows(0).Item("Check_Type"), String).Trim
                cmdStr.AppendLine("and R.Check_Type = @Check_Type ")
            End If
            '"Check_Identity", 
            If Not IsDBNull(RuleParam.Rows(0).Item("Check_Identity")) Then
                CheckIdentity = CType(RuleParam.Rows(0).Item("Check_Identity"), String).Trim
                cmdStr.AppendLine("and R.Check_Identity = @Check_Identity ")
            End If
            '"Limit_Alert_Level", 
            If Not IsDBNull(RuleParam.Rows(0).Item("Limit_Alert_Level")) Then
                LimitAlertLevel = CType(RuleParam.Rows(0).Item("Limit_Alert_Level"), String).Trim
                cmdStr.AppendLine("and R.Limit_Alert_Level = @Limit_Alert_Level ")
            End If
            '"Valid_Date_S", 
            If Not IsDBNull(RuleParam.Rows(0).Item("Valid_Date_S")) Then
                ValidDateS = CType(RuleParam.Rows(0).Item("Valid_Date_S"), Date)
                cmdStr.AppendLine("and R.Valid_Date_S >= @Valid_Date_S ")
            End If
            '"Valid_Date_E"}
            If Not IsDBNull(RuleParam.Rows(0).Item("Valid_Date_E")) Then
                ValidDateE = CType(RuleParam.Rows(0).Item("Valid_Date_E"), Date)
                cmdStr.AppendLine("and R.Valid_Date_E <= @Valid_Date_E ")
            End If

            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By R.Rule_Code ")
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            'sqlCmd.Parameters.AddWithValue("@Rule_Name", RuleName)
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
    ''' 程式說明：查詢規則代碼
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="itemParamDT">參數資料</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryRuleCodeByData(ByVal itemParamDT As DataTable) As DataTable

        'select PR.Rule_Code, PRC.Condition_Rule_Code, PRD.* 
        'from PUB_Rule PR 
        'join PUB_Rule_Class PRC on 
        'PRC.Condition_Rule_Code = PR.Rule_Code and PRC.Condition_Type = '1' and PRC.Seq_No = 1 
        'join PUB_Rule_Detail PRD on PR.Rule_Code = PRD.Rule_Code and PRD.Seq_No = 1 and PRD.Item_Code = 'A00004'

        If DataSetUtil.IsContainsData(itemParamDT) AndAlso (Not IsDBNull(itemParamDT.Rows(0).Item("Item_Code"))) Then

            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("select PR.Rule_Code ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" PR ")
            cmdStr.Append("join PUB_Rule_Class PRC on PRC.Condition_Rule_Code = PR.Rule_Code and PRC.Condition_Type = '1' and PRC.Seq_No = 1 ")
            cmdStr.Append("join PUB_Rule_Detail PRD on PR.Rule_Code = PRD.Rule_Code and PRD.Seq_No = 1 and PRD.Item_Code = @Item_Code ")
            '----------------------------------------------------------------------------
            'Where
            Dim whereStr As New StringBuilder

            If (Not IsDBNull(itemParamDT.Rows(0).Item("Value_Data"))) Then

                Dim valueData As String = CType(itemParamDT.Rows(0).Item("Value_Data"), String).Trim
                If valueData.Length > 0 Then
                    Dim valueDataStr As New StringBuilder
                    Dim splitValue() As String = valueData.Split(",")
                    If splitValue IsNot Nothing AndAlso splitValue.Length > 0 Then
                        For i As Integer = 0 To (splitValue.Length - 1)
                            valueDataStr.Append("'").Append(splitValue(i)).Append("',")
                        Next
                        If valueDataStr.Length > 0 Then
                            valueDataStr.Remove(valueDataStr.Length - 1, 1)
                        End If

                        whereStr.Append(" PRD.Value_Data in (").Append(valueDataStr.ToString).AppendLine(") ")
                    End If
                End If
            End If

            If whereStr.Length > 0 Then
                cmdStr.Append("where ").Append(whereStr.ToString).Append(" order by PRD.Value_Data")
            End If


            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@Item_Code", CType(itemParamDT.Rows(0).Item("Item_Code"), String).Trim)


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
    ''' 程式說明：查詢規則代碼(續接條件)
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="dataParamDT">參數資料</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryRuleCodeByDataForContinue(ByVal dataParamDT As DataTable) As DataTable

        'select PR.Rule_Code, PRC.Condition_Rule_Code, PRD.* 
        'from PUB_Rule PR 
        'join PUB_Rule_Class PRC on 
        'PRC.Condition_Rule_Code = PR.Rule_Code and PRC.Condition_Type = '1' and PRC.Seq_No = 1 
        'join PUB_Rule_Detail PRD on PR.Rule_Code = PRD.Rule_Code and PRD.Seq_No = 1 and PRD.Item_Code = 'A00004'

        If DataSetUtil.IsContainsData(dataParamDT) AndAlso (Not IsDBNull(dataParamDT.Rows(0).Item("Item_Code"))) Then

            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("select PR.Rule_Code ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" PR ")
            cmdStr.Append("join PUB_Rule_Class PRC on PRC.Condition_Rule_Code = PR.Rule_Code and PRC.Condition_Type = '1' and PRC.Seq_No = 1 ")
            cmdStr.Append("join PUB_Rule_Detail PRD on PR.Rule_Code = PRD.Rule_Code and PRD.Seq_No = 1 and PRD.Item_Code = @Item_Code ")
            '----------------------------------------------------------------------------
            'Where
            If DataSetUtil.IsContainsData(dataParamDT) Then
                Dim whereStr As New StringBuilder

                If (Not IsDBNull(dataParamDT.Rows(0).Item("Valid_Date_S"))) Then
                    whereStr.Append(" PR.Valid_Date_S <= '").Append(CType(dataParamDT.Rows(0).Item("Valid_Date_S"), Date).ToString("yyyy/MM/dd")).AppendLine("' ")
                End If

                If (Not IsDBNull(dataParamDT.Rows(0).Item("Valid_Date_E"))) Then
                    If whereStr.Length > 0 Then
                        whereStr.Append("and ")
                    End If
                    whereStr.Append(" PR.Valid_Date_E >= '").Append(CType(dataParamDT.Rows(0).Item("Valid_Date_E"), Date).ToString("yyyy/MM/dd")).AppendLine("' ")
                End If


                If whereStr.Length > 0 Then
                    cmdStr.AppendLine("where ").Append(whereStr.ToString)
                End If

            End If

            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@Item_Code", CType(dataParamDT.Rows(0).Item("Item_Code"), String).Trim)


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
    ''' 程式說明：依代碼查詢規則
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="RuleCode">規則代碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryRuleDataByRuleCode(ByVal RuleCode As String) As DataTable

        If RuleCode IsNot Nothing AndAlso RuleCode.Length > 0 Then

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
            cmdStr.Append("where Rule_Code = @Rule_Code  and substring(rule_code ,1,3)<>'ICD'")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By Rule_Code ")
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
            Return Nothing
        End If

    End Function


    ''' <summary>
    ''' 程式說明：依代碼查詢規則
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="RuleCode">規則代碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryRuleDataByRuleCode2(ByVal RuleCode As String) As DataTable

        If RuleCode IsNot Nothing AndAlso RuleCode.Length > 0 Then

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
            cmdStr.Append("where Rule_Code = @Rule_Code ")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By Rule_Code ")
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
            Return Nothing
        End If


    End Function

    ''' <summary>
    ''' 程式說明：依代碼查詢規則
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="RuleCodes">規則代碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryRuleDataByRuleCodes(ByVal RuleCodes() As String) As DataTable

        If RuleCodes IsNot Nothing AndAlso RuleCodes.Length > 0 Then
            Dim ruleStr As New StringBuilder
            For i As Integer = 0 To (RuleCodes.Length - 1)
                ruleStr.Append("'").Append(RuleCodes(i)).Append("',")
            Next
            If ruleStr.Length > 0 Then
                ruleStr.Remove(ruleStr.Length - 1, 1)
            End If

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
            cmdStr.Append("where Rule_Code in (").Append(ruleStr).Append(") and substring(rule_code ,1,3)<>'ICD'")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By Expression_Str  ")
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

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
    ''' 程式說明：依代碼查詢規則
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="RuleCodes">規則代碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryRuleDataByRuleCodes2(ByVal RuleCodes() As String) As DataTable

        If RuleCodes IsNot Nothing AndAlso RuleCodes.Length > 0 Then
            Dim ruleStr As New StringBuilder
            For i As Integer = 0 To (RuleCodes.Length - 1)
                ruleStr.Append("'").Append(RuleCodes(i)).Append("',")
            Next
            If ruleStr.Length > 0 Then
                ruleStr.Remove(ruleStr.Length - 1, 1)
            End If

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
            cmdStr.Append("where Rule_Code in (").Append(ruleStr).Append(") ")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By Expression_Str  ")
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

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
    Public Function deleteByRuleCodes(ByRef ruleCode() As String) As Integer

        If ruleCode IsNot Nothing AndAlso ruleCode.Length > 0 Then
            Dim ruleStr As New StringBuilder
            For i As Integer = 0 To (ruleCode.Length - 1)
                ruleStr.Append("'").Append(ruleCode(i)).Append("',")
            Next

            If ruleStr.Length > 0 Then
                ruleStr.Remove(ruleStr.Length - 1, 1)
            End If

            Dim conn As SqlConnection = getConnection()

            Try
                Dim count As Integer = 0
                Dim cmdStr As StringBuilder = New StringBuilder
                cmdStr.Append("delete from ").Append(tableName).AppendLine(" ")
                cmdStr.Append("where Rule_Code in (").Append(ruleStr.ToString).AppendLine(") ")

                conn.Open()

                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
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

    ''' <summary>
    '''更新終止生效日
    ''' </summary>
    ''' <param name="ruleCode">規則代碼</param>
    ''' <param name="validDateEnd">終止生效日</param>
    ''' <remarks></remarks>
    Public Function updateValidDateEByRuleCode(ByVal ruleCode() As String, ByVal validDateEnd As Date) As Integer
        If ruleCode IsNot Nothing AndAlso ruleCode.Length > 0 Then
            Dim ruleStr As New StringBuilder
            For i As Integer = 0 To (ruleCode.Length - 1)
                ruleStr.Append("'").Append(ruleCode(i)).Append("',")
            Next
            If ruleStr.Length > 0 Then
                ruleStr.Remove(ruleStr.Length - 1, 1)
            End If

            Dim conn As SqlConnection = getConnection()

            Try
                Dim count As Integer = 0
                Dim cmdStr As StringBuilder = New StringBuilder

                cmdStr.Append("update ").Append(tableName).AppendLine(" ")
                cmdStr.AppendLine(" set Valid_Date_E = @Valid_Date_E ")
                cmdStr.Append("where Rule_Code in (").Append(ruleStr).Append(")").AppendLine(" ")

                conn.Open()


                Using command As SqlCommand = New SqlCommand
                    With command
                        .CommandText = cmdStr.ToString
                        .CommandType = CommandType.Text
                        .Connection = CType(conn, SqlConnection)
                    End With
                    command.Parameters.AddWithValue("@Valid_Date_E", validDateEnd)

                    Dim cnt As Integer = command.ExecuteNonQuery
                    count = count + cnt
                End Using

                Return count
            Catch sqlex As SqlException
                Throw sqlex
            Catch ex As Exception
                Throw New CommonException("CMMCMMD003", ex)
            Finally
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End Try

        Else
            Return -1
        End If
    End Function

    '-------------------------------tree----------------
    ''' <summary>
    ''' 程式說明：查詢規則代碼
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="itemParamDT">參數資料</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryTreeRuleCodeByData(ByVal itemParamDT As DataTable) As DataTable

        'select distinct PR.Rule_Code, PRC.Condition_Type, PRC.Condition_Rule_Code, PRD.* 
        'from PUB_Rule PR 
        'join PUB_Rule_Class PRC on 
        'PRC.Condition_Rule_Code = PR.Rule_Code and PRC.Condition_Type = '1' and PRC.Seq_No = 1 
        'join PUB_Rule_Class PRCA on 
        'PRCA.Condition_Rule_Code = PR.Rule_Code and PRCA.Condition_Type = 'A' and PRCA.Seq_No = 1 
        'join PUB_Rule_Detail PRD on PR.Rule_Code = PRD.Rule_Code and PRD.Seq_No = 1 and PRD.Item_Code = 'A00004'

        If DataSetUtil.IsContainsData(itemParamDT) AndAlso (Not IsDBNull(itemParamDT.Rows(0).Item("Item_Code"))) Then

            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("select distinct PR.Rule_Code ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" PR ")
            cmdStr.Append("join PUB_Rule_Class PRC on PRC.Condition_Rule_Code = PR.Rule_Code and PRC.Condition_Type = 'A' and PRC.Seq_No = 1 ")
            cmdStr.Append("join PUB_Rule_Class PRCA on PRCA.Condition_Rule_Code = PR.Rule_Code and PRCA.Condition_Type = 'A' and PRCA.Seq_No = 1 ")
            cmdStr.Append("join PUB_Rule_Detail PRD on PR.Rule_Code = PRD.Rule_Code and PRD.Seq_No = 1 and PRD.Item_Code = @Item_Code ")
            '----------------------------------------------------------------------------
            'Where
            Dim whereStr As New StringBuilder

            If (Not IsDBNull(itemParamDT.Rows(0).Item("Value_Data"))) Then

                Dim valueData As String = CType(itemParamDT.Rows(0).Item("Value_Data"), String).Trim
                If valueData.Length > 0 Then
                    Dim valueDataStr As New StringBuilder
                    Dim splitValue() As String = valueData.Split(",")
                    If splitValue IsNot Nothing AndAlso splitValue.Length > 0 Then
                        For i As Integer = 0 To (splitValue.Length - 1)
                            valueDataStr.Append("'").Append(splitValue(i)).Append("',")
                        Next
                        If valueDataStr.Length > 0 Then
                            valueDataStr.Remove(valueDataStr.Length - 1, 1)
                        End If

                        whereStr.Append(" PRD.Value_Data in (").Append(valueDataStr.ToString).AppendLine(") ")
                    End If
                End If
            End If

            If whereStr.Length > 0 Then
                cmdStr.Append("where ").Append(whereStr.ToString)
            End If


            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            sqlCmd.Parameters.AddWithValue("@Item_Code", CType(itemParamDT.Rows(0).Item("Item_Code"), String).Trim)


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
    ''' 程式說明：依父代碼查詢規則代碼
    ''' 開發人員：Jen
    ''' 開發日期：2009.11.27
    ''' </summary>
    ''' <param name="parentRuleCodes">規則代碼</param>
    ''' <returns>DataTable</returns>
    ''' <使用表單>
    ''' 1.Jen-PUB_Rule
    ''' </使用表單>
    ''' <修改註記>
    ''' 1.2009/11/27, XXX
    ''' </修改註記>
    Public Function queryRuleDataByParentRuleCodes(ByVal parentRuleCodes() As String) As DataTable

        If parentRuleCodes IsNot Nothing AndAlso parentRuleCodes.Length > 0 Then
            Dim pruleStr As New StringBuilder
            For i As Integer = 0 To (parentRuleCodes.Length - 1)
                pruleStr.Append("'").Append(parentRuleCodes(i)).Append("',")
            Next
            If pruleStr.Length > 0 Then
                pruleStr.Remove(pruleStr.Length - 1, 1)
            End If

            Dim cmdStr As New StringBuilder
            '----------------------------------------------------------------------------
            'Select SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("select Rule_Code ")
            '----------------------------------------------------------------------------
            'From&Join SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("from ").Append(tableName).AppendLine(" ")
            '----------------------------------------------------------------------------
            'Where SQL
            '----------------------------------------------------------------------------
            cmdStr.Append("where Parent_Rule_Code in (").Append(pruleStr).Append(") ")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By Rule_Code ")
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

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

#Region "中文expressstr  "
    Public Function getExprre(ByVal ds As String) As String
        Dim queryString As String = "DECLARE @rtnStr nvarchar(4000) " & _
" declare @RuleCode nvarchar(40) = '" & ds & "'" & _
" ;WITH RuleCTE (rowsn, RuleCode,myseq, RuleContent) AS( select d3.rowsn, d3.RuleCode, d3.myseq,         cast('(' + rtrim(tt.Item_Name)+''+                   case when charindex('X',tt.Item_Name,0)>0                             then '<'+rtrim(d4.Item_Param)+'>'                        else ' '                   end +                                rtrim(ss.Code_Name)+' '+                   rtrim(d4.Value_Data)                + case when d4.Value_Unit is null then ''                       when rtrim(d4.Value_Unit)='' then ''                       else (select rtrim(isnull(uu.Unit_Name, d4.Value_Unit))                             from PUB_Unit uu                              where rtrim(uu.Unit_Code) = rtrim(d4.Value_Unit)                            )                  end                +')'+ case rtrim(d4.Logical_Symbol)                        when 'AND' then ' 且'                        else ' 或'                   end        AS nVARCHAR(max)) as RuleContent from ( select 1 as rowsn,rtrim(Rule_Code) as RuleCode ,MIN(Seq_No)as myseq         from PUB_Rule_Detail         where Rule_Code in (SELECT RULE_CODE FROM pub_RULE_CLASS WHERE CONDITION_RULE_cODE=@RuleCode)        group by Rule_Code      ) d3 inner join PUB_Rule_Detail d4 on (d3.RuleCode=d4.Rule_Code and d3.myseq=d4.Seq_No)           inner join PUB_Item tt ON (d4.Item_Code = tt.Item_Code)           inner join PUB_Syscode ss on (ss.Type_Id = 804 and d4.Operator_Code = ss.Code_Id)       " & _
" UNION ALL  SELECT CT.rowsn+1, CT.RuleCode, d2.Seq_No,        CT.RuleContent +          ' (' + rtrim(tt.Item_Name)+''+                   case when charindex('X',tt.Item_Name,0)>0                             then '<'+rtrim(d2.Item_Param)+'>'                        else ' '                   end +                                         rtrim(ss.Code_Name)+' '+                  rtrim(d2.Value_Data)                + case when d2.Value_Unit is null then ''                       when rtrim(d2.Value_Unit)='' then ''                       else (select rtrim(isnull(uu.Unit_Name, d2.Value_Unit))                             from PUB_Unit uu                              where rtrim(uu.Unit_Code) = rtrim(d2.Value_Unit)                            )                  end             +')'+ case rtrim(d2.Logical_Symbol)                        when 'AND' then ' 且'                        else ' 或'                   end   FROM PUB_Rule_Detail d2        inner join PUB_Item tt ON (d2.Item_Code = tt.Item_Code)       inner join PUB_Syscode ss on (ss.Type_Id = 804 and d2.Operator_Code = ss.Code_Id)       inner join RuleCTE CT ON (d2.Rule_Code = CT.RuleCode and d2.seq_No > CT.mySeq)        )select @rtnStr = left(kk.RuleContent, len(kk.RuleContent)-1) from (       select RuleContent ,RANK() over (partition by RuleCode order by rowsn desc) as myidx from RuleCTE )kk where kk.myidx =1 select @rtnStr go "



        Dim ds1 As DataSet = dynamicQuery(queryString)
        If ds1.Tables(0).Rows.Count > 0 Then
            Return ds1.Tables(0).Rows(0).Item(0).ToString
        Else
            Return ""

        End If




    End Function

#End Region

#Region "2016/06/01 SDSPEC-100-10-12(觸發規則顯示項目中文名稱)  By Li.Han"
    ''' <summary>
    ''' 取得中文名稱
    ''' </summary>
    ''' <param name="strSQL"></param>
    ''' <param name="conn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryRuleNameByCode(ByVal strSQL As String, Optional ByRef conn As System.Data.IDbConnection = Nothing) As String
        Dim connFlag As Boolean = conn Is Nothing
        Try
            Dim ds As DataSet
            Dim strName As String = ""
            If connFlag Then
                conn = getConnection()
            End If
            Dim sqlConn As SqlClient.SqlConnection = CType(conn, SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            command.CommandText = strSQL

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                ds = New DataSet(tableName)
                adapter.Fill(ds, tableName)
                adapter.FillSchema(ds, SchemaType.Mapped, tableName)
            End Using
            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    strName = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(0)), "", ds.Tables(0).Rows(0).Item(0).ToString.Trim)
                End If
            End If

            Return strName
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