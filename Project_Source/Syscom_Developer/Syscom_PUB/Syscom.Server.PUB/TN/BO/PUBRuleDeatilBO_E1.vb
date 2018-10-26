Imports Syscom.Server.SQL
Imports System.Data.SqlClient
Imports Syscom.Comm.EXP
Imports Syscom.Server.CMM
Imports Syscom.Server.BO
Imports Syscom.Comm.Utility
Imports Syscom.Comm.Utility.DataSetUtil
Imports System.Text
Public Class PUBRuleDetailBO_E1
    Inherits PubRuleDetailBO

#Region "########## getInstance ##########"

    Private Shared instance As PUBRuleDetailBO_E1

    Public Overloads Shared Function getInstance() As PUBRuleDetailBO_E1
        If instance Is Nothing Then
            instance = New PUBRuleDetailBO_E1
        End If
        Return instance
    End Function

    Private Sub New()
    End Sub

#End Region


    ''' <summary>
    ''' 程式說明：依RuleCode()查詢PUB_Rule_Detail資料
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
    Public Function queryRuleDetailByRuleCodes(ByVal RuleCode() As String) As DataTable

        If RuleCode IsNot Nothing AndAlso RuleCode.Length > 0 Then
            Dim ruleStr As New StringBuilder
            For i As Integer = 0 To (RuleCode.Length - 1)
                ruleStr.Append("'").Append(RuleCode(i)).Append("',")
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
            cmdStr.Append("where Rule_Code in ( ").Append(ruleStr.ToString).AppendLine(" )  AND substring(rule_code ,1,3)<>'ICD'")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By Value_Data, Rule_Code, Seq_No,Item_code ")
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            'sqlCmd.Parameters.AddWithValue("@Rule_Name", RuleName)

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
    ''' 程式說明：依RuleCode()查詢PUB_Rule_Detail資料
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
    Public Function queryRuleDetailByRuleCodes2(ByVal RuleCode() As String) As DataTable

        If RuleCode IsNot Nothing AndAlso RuleCode.Length > 0 Then
            Dim ruleStr As New StringBuilder
            For i As Integer = 0 To (RuleCode.Length - 1)
                ruleStr.Append("'").Append(RuleCode(i)).Append("',")
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
            cmdStr.Append("where Rule_Code in ( ").Append(ruleStr.ToString).AppendLine(" )  ")
            '----------------------------------------------------------------------------
            'Order By SQL
            '----------------------------------------------------------------------------
            cmdStr.AppendLine("Order By Value_Data, Rule_Code, Seq_No,Item_code ")
            Try
                Dim dt As DataTable = New DataTable(tableName)

                Using conn As System.Data.SqlClient.SqlConnection = getConnection()
                    Using sqlCmd As SqlCommand = New SqlCommand
                        With sqlCmd
                            .CommandText = cmdStr.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn

                            'sqlCmd.Parameters.AddWithValue("@Rule_Name", RuleName)

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
    ''' 程式說明：依RuleCode()查詢PUB_Rule_Detail資料
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
    Public Function queryRuleDetailByRuleCode(ByVal RuleCode As String) As DataTable

        If RuleCode IsNot Nothing AndAlso RuleCode.Length > 0 Then
           
            Dim cmdStr As New StringBuilder
            '『適應症檢核規則維護』，處理使用者按下【刪除】後無法將所有的規則內容從DB中刪除的問題 2013-12-31 黃富昌
            If RuleCode.Substring(0, 3).Equals("ICD") Then
                '----------------------------------------------------------------------------
                'Select SQL
                '----------------------------------------------------------------------------
                cmdStr.AppendLine("select D2.* ").AppendLine()
                '----------------------------------------------------------------------------
                'From&Join SQL
                '----------------------------------------------------------------------------
                cmdStr.Append("from ").Append(tableName).Append(" D1 inner join ").Append(tableName).Append(" D2 on D1.Rule_Code = @Rule_Code ").AppendLine()
                cmdStr.Append("and D1.Rule_Maintain_Sn = D2.Rule_Maintain_Sn ").AppendLine()
                '----------------------------------------------------------------------------
                'Where SQL
                '----------------------------------------------------------------------------
                'Order By SQL
                '----------------------------------------------------------------------------
                cmdStr.AppendLine("order by D2.Rule_Code, D2.Seq_No ")
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
                cmdStr.Append("where Rule_Code = @Rule_Code AND substring(rule_code ,1,3)<>'ICD'")
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
    ''' 程式說明：依RuleCode()查詢PUB_Rule_Detail資料
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
    Public Function queryRuleDetailByRuleCode2(ByVal RuleCode As String) As DataTable

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
            cmdStr.Append("where Rule_Code = @Rule_Code   ")
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

End Class