Imports System.Transactions
Imports System.Data.SqlClient
Imports System.Text
Imports Syscom.Server.SQL

Public Class PUBIcdRuleCheckBS

    Private Shared _instance As PUBIcdRuleCheckBS = Nothing

    Public Shared Function GetInstance() As PUBIcdRuleCheckBS
        If _instance Is Nothing Then
            _instance = New PUBIcdRuleCheckBS
        End If

        Return _instance
    End Function

    ''' <summary>
    ''' 取得資料庫連線資訊
    ''' </summary>
    ''' <returns>資料庫連線資訊</returns>
    ''' <author>Ken</author>
    ''' <date>2010-01-15</date>
    ''' <remarks></remarks>
    Private Function getConnection() As SqlConnection

        Return SQLConnFactory.getInstance.getPubDBSqlConn
    End Function

    Private Function GetOpdConnection() As SqlConnection
        Return SQLConnFactory.getInstance.getOpdDBSqlConn
    End Function

    Public Function DoPubAction(ByVal ds As DataSet) As DataSet

        Dim QueryDS As DataSet
        Dim PriorReviewDS As DataSet
        'Dim BCDrugDS As DataSet
         
        If ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "QueryByOrderCode" Then

            '使用醫令
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim sqlOpdConn As SqlClient.SqlConnection = CType(GetOpdConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()
            Dim commandOpd As SqlCommand = sqlOpdConn.CreateCommand()


            Dim OrderCode As String = ds.Tables(0).Rows(0).Item("Order_Code").ToString.Trim
            Dim OpdVisitDate As String = ds.Tables(0).Rows(0).Item("OpdVisitDate").ToString.Trim
            Dim ChartNo As String = ds.Tables(0).Rows(0).Item("ChartNo").ToString.Trim
            Dim IsBCDrug As Boolean = False
            Dim IsPriorReviewHasData As Boolean = False

            If Not OrderCode.Trim.Contains("@") Then
                '藥品
                'commandOpd.CommandText = " Select   Drug_Order_Code , Pip_Type From PIP_Prj_Drug Where Pip_Type in ('BL' ,'CL' , 'BC') And Drug_Order_Code ='" & OrderCode & "' "
                'Using adapter As SqlDataAdapter = New SqlDataAdapter(commandOpd)
                '    BCDrugDS = New DataSet()
                '    adapter.Fill(BCDrugDS)

                'End Using


                '應BC肝試辦計畫藥品有2套適應症 ,1套適用事審, 另外一套用於不須事審狀況 , 區別在PUB_Rule.Is_Prior_Review='Y' (須事審) , PUB_Rule.Is_Prior_Review='N' (一般狀況) 2011/4/10
                'If BCDrugDS IsNot Nothing AndAlso BCDrugDS.Tables.Count > 0 AndAlso BCDrugDS.Tables(0).Rows.Count > 0 Then
                '    IsBCDrug = True
                'End If

                If IsBCDrug Then

                    commandOpd.CommandText = "  SELECT  A.Chart_No, B.Order_Code, A.Apply_Date ,B.Approval_Start_Date,B.Approval_End_Date,B.Approval_Amount  "
                    commandOpd.CommandText += " FROM PRI_Apply_Case A, PRI_Apply_Case_Order B  "
                    commandOpd.CommandText += " WHERE A.Chart_No = '" & ChartNo & "'   AND A.Cancel = 'N'  "
                    commandOpd.CommandText += " AND A.Case_Sn = B.Case_Sn   AND B.Cancel = 'N' "
                    commandOpd.CommandText += " and B.Is_Close='N' and B.Approval_Result_id='1' "
                    commandOpd.CommandText += " and '" & OpdVisitDate & "' between B.Approval_Start_Date and B.Approval_End_Date "
                    commandOpd.CommandText += " and B.Order_Code='" & OrderCode & "' "

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(commandOpd)
                        PriorReviewDS = New DataSet()
                        adapter.Fill(PriorReviewDS)

                    End Using

                    If PriorReviewDS IsNot Nothing AndAlso PriorReviewDS.Tables.Count > 0 AndAlso PriorReviewDS.Tables(0).Rows.Count > 0 Then
                        IsPriorReviewHasData = True
                    End If

                End If

                If IsBCDrug Then

                    If IsPriorReviewHasData Then

                        '拿掉B.Is_Prior_Review='N'  調整為一套適應症 , 不論是否已完成事審
                        command.CommandText = " declare @ordercode as nvarchar(40)= '" & OrderCode & "' " & _
                                              " declare @Is_Sorted as char(1) ='' " & _
                                              " select @ordercode = A.RUle_Code , @Is_Sorted=isnull(B.Is_Sorted_ByName,'N') from PUB_Rule_Detail A , PUB_Rule  B " & _
                                              " where A.Rule_Code like 'ICD%' and A.Item_Code = 'A00004' and A.Value_Data = '" & OrderCode & "' And A.Rule_Code=B.Rule_Code And  '" & OpdVisitDate & "' >=B.Valid_Date_S And '" & OpdVisitDate & "' <=B.Valid_Date_E " & _
                                              " select * from PUB_Rule where Rule_Code = @ordercode ; "

                        'command.CommandText = " declare @ordercode as nvarchar(40)= '" & OrderCode & "' " & _
                        '                     " declare @Is_Sorted as char(1) ='' " & _
                        '                     " select @ordercode = A.RUle_Code , @Is_Sorted=isnull(B.Is_Sorted_ByName,'N') from PUB_Rule_Detail A , PUB_Rule  B " & _
                        '                     " where A.Rule_Code like 'ICD%' and A.Item_Code = 'A00004' and A.Value_Data = '" & OrderCode & "' And A.Rule_Code=B.Rule_Code And B.Is_Prior_Review='N' And '" & OpdVisitDate & "' >=B.Valid_Date_S And '" & OpdVisitDate & "' <=B.Valid_Date_E " & _
                        '                     " select * from PUB_Rule where Rule_Code = @ordercode ; "



                    Else

                        '拿掉B.Is_Prior_Review='Y'  調整為一套適應症 , 不論是否已完成事審
                        command.CommandText = " declare @ordercode as nvarchar(40)= '" & OrderCode & "' " & _
                                              " declare @Is_Sorted as char(1) ='' " & _
                                              " select @ordercode = A.RUle_Code , @Is_Sorted=isnull(B.Is_Sorted_ByName,'N') from PUB_Rule_Detail A , PUB_Rule  B " & _
                                              " where A.Rule_Code like 'ICD%' and A.Item_Code = 'A00004' and A.Value_Data = '" & OrderCode & "' And A.Rule_Code=B.Rule_Code And   '" & OpdVisitDate & "' >=B.Valid_Date_S And '" & OpdVisitDate & "' <=B.Valid_Date_E " & _
                                              " select * from PUB_Rule where Rule_Code = @ordercode ; "

                        'command.CommandText = " declare @ordercode as nvarchar(40)= '" & OrderCode & "' " & _
                        '                    " declare @Is_Sorted as char(1) ='' " & _
                        '                    " select @ordercode = A.RUle_Code , @Is_Sorted=isnull(B.Is_Sorted_ByName,'N') from PUB_Rule_Detail A , PUB_Rule  B " & _
                        '                    " where A.Rule_Code like 'ICD%' and A.Item_Code = 'A00004' and A.Value_Data = '" & OrderCode & "' And A.Rule_Code=B.Rule_Code And B.Is_Prior_Review='Y' And '" & OpdVisitDate & "' >=B.Valid_Date_S And '" & OpdVisitDate & "' <=B.Valid_Date_E " & _
                        '                    " select * from PUB_Rule where Rule_Code = @ordercode ; "


                    End If


                Else
                    command.CommandText = " declare @ordercode as nvarchar(40)= '" & OrderCode & "' " & _
                                          " declare @Is_Sorted as char(1) ='' " & _
                                          " select @ordercode = A.RUle_Code , @Is_Sorted=isnull(B.Is_Sorted_ByName,'N')  from PUB_Rule_Detail A , PUB_Rule  B " & _
                                          " where A.Rule_Code like 'ICD%' and A.Item_Code = 'A00004' and A.Value_Data = '" & OrderCode & "' And A.Rule_Code=B.Rule_Code And '" & OpdVisitDate & "' >=B.Valid_Date_S And '" & OpdVisitDate & "' <=B.Valid_Date_E " & _
                                          " select * from PUB_Rule where Rule_Code = @ordercode ; "

                End If

                '2011.01.25 test kkkkkk  declare @aa as varchar(1) ='F'                
                '2011.01.25 test ''kkkkk'  select @aa=Is_Sorted_ByName from PUB_Rule where Rule_Code =  @ordercode

                'command.CommandText += " select @ordercode = RUle_Code from PUB_Rule_Detail " & _
                '                       " where Rule_Code like 'ICD%' and Item_Code = 'A00004' and Value_Data = '" & OrderCode & "' " & _
                command.CommandText += " select pr.Rule_Code,  pr.Rule_name, ' '  as ExpressionStr ,pd.Logical_Symbol,pr.Limit_Alert_Level , pr.Is_Bypass_Check ,pr.Is_Prior_Review ,pr.Check_Type " & _
                                       " from PUB_Rule pr " & _
                                       "     inner join PUB_Rule_Class pc " & _
                                       "        on (pr.Rule_Code = pc.Rule_Code) " & _
                                       "     inner join PUB_Rule_Detail pd " & _
                                       "        on (pr.Rule_Code = pd.Rule_Code) " & _
                                       " where pc.Condition_Rule_Code = @ordercode and  " & _
                                       "      pc.Condition_Type = 'A' and " & _
                                       "      pc.Rule_Code <> pc.Condition_Rule_Code  order by case when @Is_Sorted='Y' then pr.Rule_Name end "
                '2011.01.25 test kkkkkkk            '' order by case when @aa='Y' then Rule_Name else Rule_Code end

                ' dbo.GetExpressionStr_Desc(pr.Rule_Code) as ExpressionStr

                '= @ordercode

                command.CommandText += " declare @Trigger_Rule_Code as varchar(30)  " & _
                                        "  select top 1 @Trigger_Rule_Code= RR.Parent_Rule_Code " & _
                                        " from PUB_Rule RR where RR.Parent_Rule_Code in  " & _
                                        "     (select DD1.Rule_Code " & _
                                        "            from PUB_Rule_Detail DD1 inner join PUB_Rule_Detail DD2 " & _
                                        "                    on (DD1.Rule_Maintain_Sn=DD2.Rule_Maintain_Sn " & _
                                        "                        and DD2.Rule_Code =@ordercode " & _
                                        "                        and DD2.Rule_Code like 'ICD%' " & _
                                        "                       and DD2.Rule_Maintain_Sn>0) " & _
                                        "     ) " & _
                                        " if (@@rowcount = 0) begin select @Trigger_Rule_Code=@ordercode end "

                command.CommandText += " ;with CTE (myrcode, myp, myidx) as " & _
                                           " (select CC.Rule_code, CC.Condition_rule_Code, " & _
                                           " convert(varchar(100),'-'+right('00'+cast(row_number() over (order by RR.Rule_name) as varchar(2)),2)) " & _
                                           " from PUB_Rule_Class CC inner join PUB_Rule RR on CC.Condition_Rule_Code = RR.Rule_Code where CC.Condition_rule_Code = @Trigger_Rule_Code " & _
                                           " union all " & _
                                           " select rr.rule_code, rr.Parent_Rule_Code,  " & _
                                           " convert(varchar(100),myidx+'-'+right('00'+cast(row_number() over (partition by rr.Parent_rule_Code order by rr.Rule_name ) as varchar(2)),2) ) " & _
                                           " from PUB_Rule rr inner join cte aa " & _
                                           " on rr.Parent_Rule_Code <> rr.Rule_Code " & _
                                           " and rr.Parent_rule_Code = aa.myrcode " & _
                                           " ) select count(Rule_Code) from PUB_Rule " & _
                                           " where Rule_Code in (select myrcode from CTE) and Is_Prior_Review = 'Y' "



            Else

                '衛材
                Dim PUBRuleEngineAPI As New PUBRuleEngineAPI
                Dim InsuDS As DataSet
                Dim Insu_Group_Code As String = ""

                InsuDS = PUBRuleEngineAPI.Ext_OrderCode_To_InsuCodeDs(OrderCode.Replace("@", ""), Now, True)


                If InsuDS IsNot Nothing AndAlso InsuDS.Tables.Count > 0 AndAlso InsuDS.Tables(0).Rows.Count > 0 Then

                    For i As Integer = 0 To InsuDS.Tables(0).Rows.Count - 1

                        If InsuDS.Tables(0).Rows(i).Item("Insu_Group_Code") IsNot DBNull.Value AndAlso InsuDS.Tables(0).Rows(i).Item("Insu_Group_Code").ToString.Trim <> "" Then

                            Insu_Group_Code = InsuDS.Tables(0).Rows(i).Item("Insu_Group_Code").ToString.Trim
                            Exit For
                        End If


                    Next

                End If

                If Insu_Group_Code <> "" Then


                    command.CommandText = " declare @ordercode as nvarchar(40)= '" & OrderCode & "' " & _
                                         " declare @Is_Sorted as char(1) ='' " & _
                                        " select @ordercode = A.RUle_Code , @Is_Sorted=isnull(B.Is_Sorted_ByName,'N') from PUB_Rule_Detail A , PUB_Rule  B " & _
                                          " where A.Rule_Code like 'ICD%' and A.Item_Code = 'A00022' and A.Value_Data = '" & Insu_Group_Code & "' And A.Rule_Code=B.Rule_Code And '" & OpdVisitDate & "' >=B.Valid_Date_S And '" & OpdVisitDate & "' <=B.Valid_Date_E " & _
                                          " select * from PUB_Rule where Rule_Code = @ordercode ; "

                    'command.CommandText += " select @ordercode = RUle_Code from PUB_Rule_Detail " & _
                    '                       " where Rule_Code like 'ICD%' and Item_Code = 'A00022' and Value_Data = '" & Insu_Group_Code & "' " & _
                    command.CommandText += " select pr.Rule_Code,  pr.Rule_name, ' '  as ExpressionStr ,pd.Logical_Symbol,pr.Limit_Alert_Level , pr.Is_Bypass_Check ,pr.Is_Prior_Review ,pr.Check_Type " & _
                                           " from PUB_Rule pr " & _
                                           "     inner join PUB_Rule_Class pc " & _
                                           "        on (pr.Rule_Code = pc.Rule_Code) " & _
                                           "     inner join PUB_Rule_Detail pd " & _
                                           "        on (pr.Rule_Code = pd.Rule_Code) " & _
                                           " where pc.Condition_Rule_Code = @ordercode and  " & _
                                           "      pc.Condition_Type = 'A' and " & _
                                           "      pc.Rule_Code <> pc.Condition_Rule_Code order by case when @Is_Sorted='Y' then pr.Rule_Name end  "


                    command.CommandText += " declare @Trigger_Rule_Code as varchar(30)  " & _
                                          "  select top 1 @Trigger_Rule_Code= RR.Parent_Rule_Code " & _
                                          " from PUB_Rule RR where RR.Parent_Rule_Code in  " & _
                                          "     (select DD1.Rule_Code " & _
                                          "            from PUB_Rule_Detail DD1 inner join PUB_Rule_Detail DD2 " & _
                                          "                    on (DD1.Rule_Maintain_Sn=DD2.Rule_Maintain_Sn " & _
                                          "                        and DD2.Rule_Code =@ordercode " & _
                                          "                        and DD2.Rule_Code like 'ICD%' " & _
                                          "                       and DD2.Rule_Maintain_Sn>0) " & _
                                          "     ) " & _
                                          " if (@@rowcount = 0) begin select @Trigger_Rule_Code=@ordercode end "


                    command.CommandText += " ;with CTE (myrcode, myp, myidx) as " & _
                                            " (select CC.Rule_code, CC.Condition_rule_Code, " & _
                                            " convert(varchar(100),'-'+right('00'+cast(row_number() over (order by RR.Rule_name) as varchar(2)),2)) " & _
                                            " from PUB_Rule_Class CC inner join PUB_Rule RR on CC.Condition_Rule_Code = RR.Rule_Code where CC.Condition_rule_Code = @Trigger_Rule_Code " & _
                                            " union all " & _
                                            " select rr.rule_code, rr.Parent_Rule_Code,  " & _
                                            " convert(varchar(100),myidx+'-'+right('00'+cast(row_number() over (partition by rr.Parent_rule_Code order by rr.Rule_name ) as varchar(2)),2) ) " & _
                                            " from PUB_Rule rr inner join cte aa " & _
                                            " on rr.Parent_Rule_Code <> rr.Rule_Code " & _
                                            " and rr.Parent_rule_Code = aa.myrcode " & _
                                            " ) select count(Rule_Code) from PUB_Rule " & _
                                            " where Rule_Code in (select myrcode from CTE) and Is_Prior_Review = 'Y' "

                    '--and Rule_Code <> @Trigger_Rule_Code   --若納入root <觸發規則> 顯示, remark 此行
                Else
                    Return Nothing
                End If
            End If
             
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                QueryDS = New DataSet()
                 
                adapter.Fill(QueryDS)

            End Using
             
            Return QueryDS
             
        ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "QueryByRuleCode" Then


            '使用RuleCode
            Dim sqlConn As SqlClient.SqlConnection = CType(getConnection(), SqlConnection)
            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim RuleCode As String = ds.Tables(0).Rows(0).Item("Rule_Code").ToString.Trim

            command.CommandText = "Select A.*,B.Logical_Symbol  From PUB_Rule A , PUB_Rule_Detail B Where A.Parent_Rule_Code='" & RuleCode & "' And A.Rule_Code=B.Rule_Code "
             
            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                QueryDS = New DataSet()
                 
                adapter.Fill(QueryDS)

            End Using
             
            Return QueryDS

        ElseIf ds.Tables(0).Rows(0).Item("Action").ToString.Trim = "QueryIcdGridData" Then

            Dim QueryIcdDS1, QueryIcdDS2 As DataSet
             
            Dim sqlConn As SqlClient.SqlConnection = CType(GetOpdConnection(), SqlConnection)

            Dim command As SqlCommand = sqlConn.CreateCommand()

            Dim ChartNo As String = ds.Tables(0).Rows(0).Item("ChartNo").ToString.Trim
            Dim OutpatientSn As String = ds.Tables(0).Rows(0).Item("OutpatientSn").ToString.Trim
            Dim Order_Code As String = ds.Tables(0).Rows(0).Item("Order_Code").ToString.Trim

            command.CommandText = "Select * From  OMO_Order_Cause_Log Where  Outpatient_Sn='" & OutpatientSn & "' And Order_Code='" & Order_Code & "' "

            Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                QueryIcdDS1 = New DataSet()
                adapter.Fill(QueryIcdDS1)

            End Using

            If QueryIcdDS1 IsNot Nothing AndAlso QueryIcdDS1.Tables(0).Rows.Count > 0 Then

                Return QueryIcdDS1
            Else

                For i As Integer = 0 To ds.Tables(1).Rows.Count - 1

                    command.CommandText = "Select top 1 Cause_Content From  OMO_Order_Cause_Log A , OMO_Medical_Record B Where  B.Chart_No='" & ChartNo & "' And A.Outpatient_Sn=B.Outpatient_Sn And A.Order_Code='" & Order_Code & "' And A.Cause_Content like '%" & ds.Tables(1).Rows(i).Item(0).ToString.Trim & "%' Order By A.Modified_Time  DESC "

                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        QueryIcdDS2 = New DataSet()
                        adapter.Fill(QueryIcdDS2)

                    End Using

                    If QueryIcdDS2 IsNot Nothing AndAlso QueryIcdDS2.Tables(0).Rows.Count > 0 Then
                        Return QueryIcdDS2
                    End If

                Next
                 
            End If
             
            Return Nothing

        End If

        Return Nothing
    End Function
     
End Class
