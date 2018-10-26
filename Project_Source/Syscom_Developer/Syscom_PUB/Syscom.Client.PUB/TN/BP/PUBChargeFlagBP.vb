Imports Syscom.Client.Servicefactory

'=============================================================================
'========================== 凌群電腦 Syscom ==================================
'=============================================================================
'=======
'======= 程式名稱：SYNOX計價規則
'=======
'======= 程式說明：1.SYNOX計價規則
'=======
'======= 建立日期：2016-05-30
'=======
'======= 開發人員：James
'=============================================================================
'=============================================================================
'=============================================================================

Public Class PUBChargeFlagBP

    Public Shared PubOrderExamNocheckinDeptDS As DataSet
    Public Shared _Is_Need_Execute As Boolean = False

    '針對檢驗檢查醫令是否需科室執行 (True:需執行 ;False:不用執行)
    Public Shared Property Is_Need_Execute() As Boolean
        Get
            Return _Is_Need_Execute
        End Get
        Set(ByVal Value As Boolean)
            _Is_Need_Execute = Value
        End Set
    End Property


    ' 身份	計價別	計價說明	科室執行註記	醫囑開立/補批價	可異動	科室執行	費用結算
    '健保   	S	    需科室執行	Y	            預帶S	    S,O,X	S->N	       暫不計價
    '           S	    需科室執行	N	            預帶N    	N,O,X	　       	計價
    '           N   	健保可修改	　           	預帶N   	N,O,X	      　	健保
    '           X	    不計價	　                 	預帶X	　	　          	不計價不申報
    ' 自費    	Y	    自費可修改	           　	預帶Y   	Y,O,X	      　	自費
    '           O	    自費不可修改	　      	預帶O   	O,X	　	            自費
    '      	    X	    不計價	　              	預帶X	　	　              	不計價

    ''' <summary>
    ''' 取得ChargeFlag
    ''' </summary>
    ''' <param name="Source_Id">O,E,I</param>
    ''' <param name="Main_Identity_Id">主身份</param>
    ''' <param name="Dept_Code">科別</param>
    ''' <param name="Section_id">診別</param>
    ''' <param name="dt">資料</param>
    ''' <remarks>取得ChargeFlag</remarks>
    Public Shared Function getChargeFlag(ByVal Source_Id As String, ByVal Main_Identity_Id As String, ByVal Dept_Code As String, ByVal Section_id As String, ByVal dt As DataTable) As DataSet
        Try
            Dim uclService As IUclServiceManager = UclServiceManager.getInstance

            Dim IsNeedUclQuery As Boolean = False

            '每次都查
            'If PubOrderExamNocheckinDeptDS Is Nothing Then
            PubOrderExamNocheckinDeptDS = PubServiceManager.getInstance.RuleDynamicQuery("Select Order_Code , Kind_Id , Dept_Code ,Section_Id  From PUB_Order_Exam_Nocheckin_Dept")
            'End If

            '==========================================================
            If Not dt.Columns.Contains("Self_Charge_Flag") Then
                dt.Columns.Add("Self_Charge_Flag")
            End If

            If Not dt.Columns.Contains("Nhi_Charge_Flag") Then
                dt.Columns.Add("Nhi_Charge_Flag")
            End If

            If Not dt.Columns.Contains("Is_No_Check_In") Then
                dt.Columns.Add("Is_No_Check_In")
            End If

            If Not dt.Columns.Contains("Include_Order_Mark") Then
                dt.Columns.Add("Include_Order_Mark")
            End If

            If Not dt.Columns.Contains("Is_Cure") Then
                dt.Columns.Add("Is_Cure")
            End If

            For i As Integer = 0 To dt.Rows.Count - 1

                If dt.Rows(0).Item("Self_Charge_Flag").ToString.Trim = "" OrElse dt.Rows(0).Item("Nhi_Charge_Flag").ToString.Trim = "" Then
                    IsNeedUclQuery = True
                Else
                    Exit For
                End If

                Dim DataDS As New DataSet
                DataDS.Tables.Add()
                DataDS.Tables(0).Columns.Add("Action")
                DataDS.Tables(0).Columns.Add("Code")
                DataDS.Tables(0).Columns.Add("Name")
                DataDS.Tables(0).Columns.Add("Is_OPD")
                DataDS.Tables(0).Columns.Add("Is_IPD")
                DataDS.Tables(0).Columns.Add("Is_EPD")
                DataDS.Tables(0).Columns.Add("IsEqualMatch")
                DataDS.Tables(0).Columns.Add("OrderTypeId")
                DataDS.Tables(0).Columns.Add("Is_ShowPrice")
                DataDS.Tables(0).Columns.Add("Choice_Dc_Order")
                DataDS.Tables(0).Rows.Add()

                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Mixed"
                DataDS.Tables(0).Rows(0).Item("Code") = dt.Rows(i).Item("Order_Code").ToString.Trim
                DataDS.Tables(0).Rows(0).Item("IsEqualMatch") = "Y"
                DataDS.Tables(0).Rows(0).Item("Choice_Dc_Order") = "N"

                Dim OrderDS = uclService.DoUclAction(DataDS)

                If OrderDS IsNot Nothing AndAlso OrderDS.Tables(0).Rows.Count > 0 Then
                    dt.Rows(i).Item("Self_Charge_Flag") = OrderDS.Tables(0).Rows(0).Item("Self_Charge_Flag").ToString.Trim
                    dt.Rows(i).Item("Nhi_Charge_Flag") = OrderDS.Tables(0).Rows(0).Item("Nhi_Charge_Flag").ToString.Trim
                    dt.Rows(i).Item("Is_No_Check_In") = OrderDS.Tables(0).Rows(0).Item("Is_No_Check_In").ToString.Trim
                    dt.Rows(i).Item("Include_Order_Mark") = OrderDS.Tables(0).Rows(0).Item("Include_Order_Mark").ToString.Trim
                    dt.Rows(i).Item("Is_Cure") = OrderDS.Tables(0).Rows(0).Item("Is_Cure").ToString.Trim
                End If

            Next

            '==========================================================

            Dim RetrunDS As New DataSet
            RetrunDS.Tables.Add(dt.Copy)

            If Main_Identity_Id = "1" Then
                For Each row As DataRow In RetrunDS.Tables(0).Rows

                    If row.Item("Self_Charge_Flag").ToString.Trim = "O" Then
                        row.Item("Charge_Flag") = "O"

                    ElseIf row.Item("Self_Charge_Flag").ToString.Trim = "Y" Then
                        row.Item("Charge_Flag") = "Y"

                    ElseIf row.Item("Self_Charge_Flag").ToString.Trim = "X" Then
                        row.Item("Charge_Flag") = "X"

                    End If

                Next
            Else

                For Each row As DataRow In RetrunDS.Tables(0).Rows

                    If row.Item("Include_Order_Mark").ToString.Trim = "A" Then
                        row.Item("Charge_Flag") = "X"

                    Else

                        'A.	計價別欄位預設帶入PUB_Order_Price.Charge_Flag
                        'B.	但PUB_Order_Price.Charge_Flag = 'N'時, 
                        'B1.當PUB_Order_Examine.Is_No_Check_In = 'N' 時, 計價別欄位改為'S'; 
                        'B2.PUB_Order_Examine.Is_No_Check_In = 'Y' 時, 且開單科診存在[科室不需報到設定檔](PUB_Order_Exam_Nocheckin_Dept)時, 計價別欄位改為'N'; 
                        'B3. PUB_Order_Examine.Is_No_Check_In = 'Y' 時, 且開單科診不存在[科室不需報到設定檔](PUB_Order_Exam_Nocheckin_Dept)時, 計價別欄位改為'S'

                        If row.Item("Nhi_Charge_Flag").ToString.Trim <> "" Then
                            row.Item("Charge_Flag") = row.Item("Nhi_Charge_Flag").ToString.Trim
                        Else
                            row.Item("Charge_Flag") = row.Item("Self_Charge_Flag").ToString.Trim
                        End If


                        If Source_Id = "O" Then

                            '門診
                            If row.Item("Nhi_Charge_Flag").ToString.Trim = "N" Then


                                If row.Item("Is_Cure").ToString.Trim = "Y" Then
                                    '療程項目
                                    row.Item("Charge_Flag") = "S"

                                Else

                                    If row.Item("Is_No_Check_In").ToString.Trim = "N" Then '科室需報到
                                        row.Item("Charge_Flag") = "S"

                                    ElseIf row.Item("Is_No_Check_In").ToString.Trim = "Y" Then
                                        '先用Order_Code找PubOrderExamNocheckinDept , 如果找不到 ,就代表科室不需執行 , Charge_Flag =N
                                        If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & row.Item("Order_Code").ToString.Trim & "'").Count = 0 Then
                                            '沒找不到
                                            row.Item("Charge_Flag") = "N"
                                        Else
                                            '有找到 ,再依據門急住科診 找,如果找到 , 代表科室不需執行 , Charge_Flag =N
                                            If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & row.Item("Order_Code").ToString.Trim & "' And Kind_Id='" & Source_Id & "' And Dept_Code='" & Dept_Code & "' And Section_Id='" & Section_id & "'").Count > 0 Then
                                                row.Item("Charge_Flag") = "N"
                                            Else
                                                '沒找到,需要報到(執行)
                                                row.Item("Charge_Flag") = "S"
                                            End If
                                        End If

                                    End If

                                End If

                            End If

                        Else

                            '急,住
                            If row.Item("Nhi_Charge_Flag").ToString.Trim = "N" Then
                                If row.Item("Is_No_Check_In").ToString.Trim = "N" Then '科室需報到
                                    row.Item("Charge_Flag") = "S"

                                ElseIf row.Item("Is_No_Check_In").ToString.Trim = "Y" Then
                                    '先用Order_Code找PubOrderExamNocheckinDept , 如果找不到 ,就代表科室不需執行 , Charge_Flag =N
                                    If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & row.Item("Order_Code").ToString.Trim & "'").Count = 0 Then
                                        '沒找不到
                                        row.Item("Charge_Flag") = "N"
                                    Else
                                        '有找到 ,再依據門急住科診 找,如果找到 , 代表科室不需執行 , Charge_Flag =N
                                        If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & row.Item("Order_Code").ToString.Trim & "' And Kind_Id='" & Source_Id & "' And Dept_Code='" & Dept_Code & "'").Count > 0 Then
                                            row.Item("Charge_Flag") = "N"
                                        Else
                                            '沒找到,需要報到(執行)
                                            row.Item("Charge_Flag") = "S"
                                        End If
                                    End If

                                End If
                            End If
                        End If

                    End If

                Next

            End If

            Return RetrunDS
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    ''' <summary>
    ''' 取得ChargeFlag
    ''' </summary>
    ''' <param name="Source_Id">O,E,I</param>
    ''' <param name="Main_Identity_Id">主身份</param>
    ''' <param name="Dept_Code">科別</param>
    ''' <param name="Section_id">診別</param>
    ''' <param name="Order_Code">Order_Code</param>
    ''' <param name="Self_Charge_Flag">PUB_Order_Price.Charge_Flag(Main_Identity_Id = '1')</param>
    ''' <param name="Nhi_Charge_Flag">PUB_Order_Price.Charge_Flag(Main_Identity_Id = '2')</param>
    ''' <param name="Is_No_Check_In">PUB_Order_Examination.Is_No_Check_In</param>
    ''' <param name="Include_Order_Mark">PUB_Order.Include_Order_Mark</param>
    ''' <param name="Is_Cure">PUB_Order.Is_Cure</param>
    ''' <remarks>取得ChargeFlag</remarks>
    Public Shared Function getChargeFlag(ByVal Source_Id As String, ByVal Main_Identity_Id As String, ByVal Dept_Code As String, ByVal Section_id As String, ByVal Order_Code As String, Optional ByVal Self_Charge_Flag As String = "", Optional ByVal Nhi_Charge_Flag As String = "", Optional ByVal Is_No_Check_In As String = "", Optional ByVal Include_Order_Mark As String = "", Optional ByVal Is_Cure As String = "") As String
        Try
            Dim uclService As IUclServiceManager = UclServiceManager.getInstance
             
            '每次都查
            'If PubOrderExamNocheckinDeptDS Is Nothing Then
            PubOrderExamNocheckinDeptDS = PubServiceManager.getInstance.RuleDynamicQuery("Select Order_Code , Kind_Id , Dept_Code ,Section_Id  From PUB_Order_Exam_Nocheckin_Dept")
            'End If
             
            '==========================================================

            '不要靠這個處理 有可能會很慢喔...
            Dim DataDS As New DataSet
            DataDS.Tables.Add()
            DataDS.Tables(0).Columns.Add("Action")
            DataDS.Tables(0).Columns.Add("Code")
            DataDS.Tables(0).Columns.Add("Name")
            DataDS.Tables(0).Columns.Add("Is_OPD")
            DataDS.Tables(0).Columns.Add("Is_IPD")
            DataDS.Tables(0).Columns.Add("Is_EPD")
            DataDS.Tables(0).Columns.Add("IsEqualMatch")
            DataDS.Tables(0).Columns.Add("OrderTypeId")
            DataDS.Tables(0).Columns.Add("Is_ShowPrice")
            DataDS.Tables(0).Columns.Add("Choice_Dc_Order")
            DataDS.Tables(0).Rows.Add()

            DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Mixed"
            DataDS.Tables(0).Rows(0).Item("Code") = Order_Code.Trim
            DataDS.Tables(0).Rows(0).Item("IsEqualMatch") = "Y"
            DataDS.Tables(0).Rows(0).Item("Choice_Dc_Order") = "N"

            Dim OrderDS = uclService.DoUclAction(DataDS)

            If OrderDS IsNot Nothing AndAlso OrderDS.Tables(0).Rows.Count > 0 Then
                Self_Charge_Flag = OrderDS.Tables(0).Rows(0).Item("Self_Charge_Flag").ToString.Trim
                Nhi_Charge_Flag = OrderDS.Tables(0).Rows(0).Item("Nhi_Charge_Flag").ToString.Trim
                Is_No_Check_In = OrderDS.Tables(0).Rows(0).Item("Is_No_Check_In").ToString.Trim
                Include_Order_Mark = OrderDS.Tables(0).Rows(0).Item("Include_Order_Mark").ToString.Trim
                Is_Cure = OrderDS.Tables(0).Rows(0).Item("Is_Cure").ToString.Trim
            End If
             
            '==========================================================
            Dim RetrunDS As New DataSet
            RetrunDS.Tables.Add("Charge_Flag_Value")

            RetrunDS.Tables("Charge_Flag_Value").Columns.Add("Charge_Flag")

            RetrunDS.Tables("Charge_Flag_Value").Rows.Add()

            If Main_Identity_Id = "1" Then

                If Self_Charge_Flag.Trim = "O" Then
                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "O"

                ElseIf Self_Charge_Flag.Trim = "Y" Then
                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "Y"

                ElseIf Self_Charge_Flag.Trim = "X" Then
                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "X"

                End If

            Else

                If Include_Order_Mark = "A" Then
                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "X"
                Else

                    If Nhi_Charge_Flag <> "" Then
                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = Nhi_Charge_Flag
                    Else
                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = Self_Charge_Flag
                    End If

                    If Source_Id = "O" Then
                        '門診
                        If Nhi_Charge_Flag = "N" Then
                            If Is_Cure = "Y" Then
                                Is_Need_Execute = True
                                '療程項目
                                RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "S"
                            Else

                                If Is_No_Check_In = "N" Then '科室需報到
                                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "S"

                                ElseIf Is_No_Check_In = "Y" Then
                                    '先用Order_Code找PubOrderExamNocheckinDept , 如果找不到 ,就代表科室不需執行 , Charge_Flag =N
                                    If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "'").Count = 0 Then
                                        '沒找不到
                                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "N"
                                    Else
                                        '有找到 ,再依據門急住科診 找,如果找到 , 代表科室不需執行 , Charge_Flag =N
                                        If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "' And Kind_Id='" & Source_Id & "' And Dept_Code='" & Dept_Code & "' And Section_Id='" & Section_id & "'").Count > 0 Then
                                            RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "N"
                                        Else
                                            '沒找到,需要報到(執行)
                                            RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "S"
                                        End If
                                    End If

                                End If
                            End If
                        End If

                    Else

                        '急,住
                        If Nhi_Charge_Flag = "N" Then
                            If Is_No_Check_In = "N" Then '科室需報到
                                RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "S"

                            ElseIf Is_No_Check_In = "Y" Then
                                '先用Order_Code找PubOrderExamNocheckinDept , 如果找不到 ,就代表科室不需執行 , Charge_Flag =N
                                If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "'").Count = 0 Then
                                    '沒找不到
                                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "N"
                                Else
                                    '有找到 ,再依據門急住科診 找,如果找到 , 代表科室不需執行 , Charge_Flag =N
                                    If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "' And Kind_Id='" & Source_Id & "' And Dept_Code='" & Dept_Code & "'").Count > 0 Then
                                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "N"
                                    Else
                                        '沒找到,需要報到(執行)
                                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "S"
                                    End If
                                End If

                            End If
                        End If
                    End If
                     
                End If

            End If

            '設定Is_Need_Execute屬性
            DetermineIsNeedExecute(OrderDS, Source_Id, Dept_Code, Section_id, Order_Code)

            Return RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag").ToString.Trim
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 設定Is_Need_Execute屬性
    ''' </summary>
    ''' <param name="OrderDS">醫令資料</param>
    Private Shared Sub DetermineIsNeedExecute(ByVal OrderDS As DataSet, ByVal Source_Id As String, ByVal Dept_Code As String, ByVal Section_id As String, ByVal Order_Code As String)

        Try
            Dim Treatment_Type_Id As String = ""
            Dim Is_Cure As String = ""
            Dim Is_No_Check_In As String = ""

            Is_Need_Execute = False

            If OrderDS IsNot Nothing AndAlso OrderDS.Tables(0).Rows.Count > 0 Then

                Treatment_Type_Id = OrderDS.Tables(0).Rows(0).Item("Treatment_Type_Id").ToString.Trim
                Is_Cure = OrderDS.Tables(0).Rows(0).Item("Is_Cure").ToString.Trim
                Is_No_Check_In = OrderDS.Tables(0).Rows(0).Item("Is_No_Check_In").ToString.Trim
                '療程
                If Is_Cure = "Y" Then
                    Is_Need_Execute = True
                    Exit Sub
                End If

                '檢驗檢查
                If (Treatment_Type_Id = "3" OrElse Treatment_Type_Id = "4") Then
                    If Is_No_Check_In = "" OrElse Is_No_Check_In = "N" Then
                        Is_Need_Execute = True
                        Exit Sub
                    Else
                        'Is_No_Check_In="Y"
                        If Source_Id = "O" Then
                            '門診
                            '先用Order_Code找PubOrderExamNocheckinDept , 如果找不到 ,就代表科室不需執行 , Charge_Flag =N
                            If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "'").Count = 0 Then
                                '沒找不到
                                Is_Need_Execute = False
                                Exit Sub
                            Else
                                '有找到 ,再依據門急住科診 找,如果找到 , 代表科室不需執行 , Charge_Flag =N
                                If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "' And Kind_Id='" & Source_Id & "' And Dept_Code='" & Dept_Code & "' And Section_Id='" & Section_id & "'").Count > 0 Then
                                    Is_Need_Execute = False
                                    Exit Sub
                                Else
                                    '沒找到,需要報到(執行)
                                    Is_Need_Execute = True
                                    Exit Sub
                                End If
                            End If
                        Else
                            '急住
                            '先用Order_Code找PubOrderExamNocheckinDept , 如果找不到 ,就代表科室不需執行 , Charge_Flag =N
                            If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "'").Count = 0 Then
                                '沒找不到
                                Is_Need_Execute = False
                                Exit Sub
                            Else
                                '有找到 ,再依據門急住科診 找,如果找到 , 代表科室不需執行 , Charge_Flag =N
                                If PubOrderExamNocheckinDeptDS.Tables(0).Select("Order_Code='" & Order_Code & "' And Kind_Id='" & Source_Id & "' And Dept_Code='" & Dept_Code & "'").Count > 0 Then
                                    Is_Need_Execute = False
                                    Exit Sub
                                Else
                                    '沒找到,需要報到(執行)
                                    Is_Need_Execute = True
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If

                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' 取得ChargeFlag for 轉身分用
    ''' </summary>
    ''' <param name="Source_Id">O,E,I</param>
    ''' <param name="Main_Identity_Id">主身份</param>
    ''' <param name="Dept_Code">科別</param>
    ''' <param name="Section_id">診別</param>
    ''' <param name="Order_Code">Order_Code</param>
    ''' <param name="OldChargeFlag">PUB_Order_Price.Charge_Flag</param>
    ''' <param name="Order_Stat_Id">Order_Stat_Id</param>
    ''' <remarks>取得ChargeFlag</remarks>
    Public Shared Function getChargeFlagForIdentity(Source_id, Main_Identity_Id, Dept_Code, Section_id, Order_Code, OldChargeFlag, Order_Stat_Id) As String
        Try
            Dim uclService As IUclServiceManager = UclServiceManager.getInstance

            '==========================================================
            If OldChargeFlag = "" Then
                '不要靠這個處理 有可能會很慢喔...
                Dim DataDS As New DataSet
                DataDS.Tables.Add()
                DataDS.Tables(0).Columns.Add("Action")
                DataDS.Tables(0).Columns.Add("Code")
                DataDS.Tables(0).Columns.Add("Name")
                DataDS.Tables(0).Columns.Add("Is_OPD")
                DataDS.Tables(0).Columns.Add("Is_IPD")
                DataDS.Tables(0).Columns.Add("Is_EPD")
                DataDS.Tables(0).Columns.Add("IsEqualMatch")
                DataDS.Tables(0).Columns.Add("OrderTypeId")
                DataDS.Tables(0).Columns.Add("Is_ShowPrice")
                DataDS.Tables(0).Columns.Add("Choice_Dc_Order")
                DataDS.Tables(0).Rows.Add()

                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Mixed"
                DataDS.Tables(0).Rows(0).Item("Code") = Order_Code.Trim
                DataDS.Tables(0).Rows(0).Item("IsEqualMatch") = "Y"
                DataDS.Tables(0).Rows(0).Item("Choice_Dc_Order") = "N"

                Dim OrderDS = uclService.DoUclAction(DataDS)

                If OrderDS IsNot Nothing AndAlso OrderDS.Tables(0).Rows.Count > 0 Then
                    If Main_Identity_Id = "1" Then
                        OldChargeFlag = OrderDS.Tables(0).Rows(0).Item("Self_Charge_Flag").ToString.Trim
                    Else
                        OldChargeFlag = OrderDS.Tables(0).Rows(0).Item("Nhi_Charge_Flag").ToString.Trim
                    End If

                End If

            End If

            '==========================================================

            Dim RetrunDS As New DataSet
            RetrunDS.Tables.Add("Charge_Flag_Value")

            RetrunDS.Tables("Charge_Flag_Value").Columns.Add("Charge_Flag")

            RetrunDS.Tables("Charge_Flag_Value").Rows.Add()

            If OldChargeFlag.Trim = "O" Then
                RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "O"


            ElseIf OldChargeFlag.Trim = "X" Then
                RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "X"
            ElseIf OldChargeFlag.Trim = "N" OrElse OldChargeFlag.Trim = "S" Then
                RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "Y"

            ElseIf OldChargeFlag.Trim = "Y" Then
                Dim NewChargeFlag = getChargeFlag(Source_id, Main_Identity_Id, Dept_Code, Section_id, Order_Code)

                If NewChargeFlag = "S" Then
                    If IsNumeric(Order_Stat_Id) AndAlso CInt(Order_Stat_Id) >= 40 Then
                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "N"
                    Else
                        RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = "S"
                    End If
                Else
                    RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag") = NewChargeFlag
                End If

            End If

            Return RetrunDS.Tables("Charge_Flag_Value").Rows(0).Item("Charge_Flag").ToString
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
     
    ''' <summary>
    ''' 取得ChargeFlag範圍
    ''' </summary>
    ''' <param name="Source_Id">OEI</param>
    ''' <param name="Main_Identity_Id">主身份</param>
    ''' <param name="Dept_Code">科</param>
    ''' <param name="Section_id">診</param>
    ''' <param name="Order_Code">醫令代碼</param>
    ''' <param name="Self_Charge_Flag">PUB_Order_Price.Charge_Flag(Main_Identity_Id = '1')</param>
    ''' <param name="Nhi_Charge_Flag">PUB_Order_Price.Charge_Flag(Main_Identity_Id = '2')</param>
    ''' <param name="Is_No_Check_In">PUB_Order_Examination.Is_No_Check_In</param>
    ''' <param name="Include_Order_Mark">PUB_Order.Include_Order_Mark</param>
    ''' <param name="Is_Cure">PUB_Order.Is_Cure</param>
    ''' <remarks>取得ChargeFlag範圍</remarks>
    Public Shared Function getChargeFlagRange(ByVal Source_Id As String, ByVal Main_Identity_Id As String, ByVal Dept_Code As String, ByVal Section_id As String, ByVal Order_Code As String, Optional ByVal Self_Charge_Flag As String = "", Optional ByVal Nhi_Charge_Flag As String = "", Optional ByVal Is_No_Check_In As String = "", Optional ByVal Include_Order_Mark As String = "", Optional ByVal Is_Cure As String = "") As DataSet
        Try
            Dim uclService As IUclServiceManager = UclServiceManager.getInstance

            Dim RetrunDS As New DataSet

            RetrunDS.Tables.Add("Charge_Flag_Range")

            RetrunDS.Tables("Charge_Flag_Range").Columns.Add("Range")

            '==========================================================
            If Self_Charge_Flag = "" AndAlso Nhi_Charge_Flag = "" Then
                '不要靠這個處理 有可能會很慢喔...
                Dim DataDS As New DataSet
                DataDS.Tables.Add()
                DataDS.Tables(0).Columns.Add("Action")
                DataDS.Tables(0).Columns.Add("Code")
                DataDS.Tables(0).Columns.Add("Name")
                DataDS.Tables(0).Columns.Add("Is_OPD")
                DataDS.Tables(0).Columns.Add("Is_IPD")
                DataDS.Tables(0).Columns.Add("Is_EPD")
                DataDS.Tables(0).Columns.Add("IsEqualMatch")
                DataDS.Tables(0).Columns.Add("OrderTypeId")
                DataDS.Tables(0).Columns.Add("Is_ShowPrice")
                DataDS.Tables(0).Columns.Add("Choice_Dc_Order")
                DataDS.Tables(0).Rows.Add()

                DataDS.Tables(0).Rows(0).Item("Action") = "PUB_Order_Mixed"
                DataDS.Tables(0).Rows(0).Item("Code") = Order_Code.Trim
                DataDS.Tables(0).Rows(0).Item("IsEqualMatch") = "Y"
                DataDS.Tables(0).Rows(0).Item("Choice_Dc_Order") = "N"

                Dim OrderDS = uclService.DoUclAction(DataDS)

                If OrderDS IsNot Nothing AndAlso OrderDS.Tables(0).Rows.Count > 0 Then
                    Self_Charge_Flag = OrderDS.Tables(0).Rows(0).Item("Self_Charge_Flag").ToString.Trim
                    Nhi_Charge_Flag = OrderDS.Tables(0).Rows(0).Item("Nhi_Charge_Flag").ToString.Trim
                    Is_No_Check_In = OrderDS.Tables(0).Rows(0).Item("Is_No_Check_In").ToString.Trim
                    Include_Order_Mark = OrderDS.Tables(0).Rows(0).Item("Include_Order_Mark").ToString.Trim
                    Is_Cure = OrderDS.Tables(0).Rows(0).Item("Is_Cure").ToString.Trim
                End If

            End If

            '==========================================================

            If Main_Identity_Id = "1" Then
                'Order_Price的自費 單價的Charge_Flag
                If Self_Charge_Flag.Trim = "O" Then

                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()

                    RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "O"
                    RetrunDS.Tables("Charge_Flag_Range").Rows(1).Item("Range") = "X"

                ElseIf Self_Charge_Flag.Trim = "Y" Then

                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()

                    RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "Y"
                    RetrunDS.Tables("Charge_Flag_Range").Rows(1).Item("Range") = "O"
                    RetrunDS.Tables("Charge_Flag_Range").Rows(2).Item("Range") = "X"

                ElseIf Self_Charge_Flag.Trim = "X" Then

                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "X"
                End If

            Else
                'Order_Price的健保 單價的Charge_Flag

                Dim Default_Charge_Flag As String = getChargeFlag(Source_Id, Main_Identity_Id, Dept_Code, Section_id, Order_Code, Self_Charge_Flag, Nhi_Charge_Flag, Is_No_Check_In, Include_Order_Mark)


                If Nhi_Charge_Flag.Trim = "S" OrElse Nhi_Charge_Flag.Trim = "N" Then

                    If Default_Charge_Flag.Trim = "S" Then

                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()

                        RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "S"
                        RetrunDS.Tables("Charge_Flag_Range").Rows(1).Item("Range") = "O"
                        RetrunDS.Tables("Charge_Flag_Range").Rows(2).Item("Range") = "N"
                        RetrunDS.Tables("Charge_Flag_Range").Rows(3).Item("Range") = "X"
                    Else

                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                        RetrunDS.Tables("Charge_Flag_Range").Rows.Add()

                        RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "N"
                        RetrunDS.Tables("Charge_Flag_Range").Rows(1).Item("Range") = "O"
                        RetrunDS.Tables("Charge_Flag_Range").Rows(2).Item("Range") = "X"

                    End If

                ElseIf Nhi_Charge_Flag.Trim = "X" Then

                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "X"

                ElseIf Nhi_Charge_Flag.Trim = "O" Then

                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "O"
                    RetrunDS.Tables("Charge_Flag_Range").Rows(1).Item("Range") = "X"
                Else
                    '健保不給付
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()
                    RetrunDS.Tables("Charge_Flag_Range").Rows.Add()

                    RetrunDS.Tables("Charge_Flag_Range").Rows(0).Item("Range") = "Y"
                    RetrunDS.Tables("Charge_Flag_Range").Rows(1).Item("Range") = "O"
                    RetrunDS.Tables("Charge_Flag_Range").Rows(2).Item("Range") = "X"

                End If

            End If

            Return RetrunDS
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 取得Is_Force
    ''' </summary>
    ''' <param name="dt">資料</param>
    ''' <remarks>取得Is_Force</remarks>
    Public Shared Function getIsForce(ByVal dt As DataTable) As DataSet

        Try
            Dim RetrunDS As New DataSet
            RetrunDS.Tables.Add(dt.Copy)

            If Not RetrunDS.Tables(0).Columns.Contains("Is_Force") Then
                RetrunDS.Tables(0).Columns.Add("Is_Force")
            End If

            For Each row As DataRow In RetrunDS.Tables(0).Rows
                If row.Item("Charge_Flag").ToString.Trim = "Y" Then
                    row.Item("Is_Force") = "N"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "N" Then
                    row.Item("Is_Force") = "N"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "O" Then
                    row.Item("Is_Force") = "Y"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "S" Then
                    row.Item("Is_Force") = "N"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "X" Then
                    row.Item("Is_Force") = "N"

                End If

            Next

            Return RetrunDS

        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    ''' <summary>
    ''' 取得Is_Force
    ''' </summary>
    ''' <param name="Charge_Flag">Charge_Flag</param>
    ''' <remarks>取得Is_Force</remarks>
    Public Shared Function getIsForce(ByVal Charge_Flag As String) As String

        Try

            Dim Is_Force As String = "N"

            If Charge_Flag.Trim = "Y" Then
                Is_Force = "N"

            ElseIf Charge_Flag.Trim = "N" Then
                Is_Force = "N"

            ElseIf Charge_Flag.Trim = "O" Then
                Is_Force = "Y"

            ElseIf Charge_Flag.Trim = "S" Then
                Is_Force = "N"

            ElseIf Charge_Flag.Trim = "X" Then
                Is_Force = "N"

            End If

            Return Is_Force

        Catch ex As Exception
            Return "N"
        End Try

    End Function


    ''' <summary>
    ''' 取得Is_Charge
    ''' </summary>
    ''' <param name="dt">資料</param>
    ''' <remarks>取得Is_Charge</remarks>
    Public Shared Function getIsCharge(ByVal dt As DataTable) As DataSet

        Try
            Dim RetrunDS As New DataSet
            RetrunDS.Tables.Add(dt.Copy)

            If Not RetrunDS.Tables(0).Columns.Contains("Is_Charge") Then
                RetrunDS.Tables(0).Columns.Add("Is_Charge")
            End If

            For Each row As DataRow In RetrunDS.Tables(0).Rows
                If row.Item("Charge_Flag").ToString.Trim = "Y" Then
                    row.Item("Is_Charge") = "Y"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "N" Then
                    row.Item("Is_Charge") = "Y"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "O" Then
                    row.Item("Is_Charge") = "Y"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "S" Then
                    row.Item("Is_Charge") = "Y"

                ElseIf row.Item("Charge_Flag").ToString.Trim = "X" Then
                    row.Item("Is_Charge") = "N"

                End If

            Next

            Return RetrunDS
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    ''' <summary>
    ''' 取得Is_Charge
    ''' </summary>
    ''' <param name="Charge_Flag">Charge_Flag</param>
    ''' <remarks>取得Is_Charge</remarks>
    Public Shared Function getIsCharge(ByVal Charge_Flag As String) As String

        Try

            Dim Is_Charge As String = "Y"

            If Charge_Flag.Trim = "Y" Then
                Is_Charge = "Y"

            ElseIf Charge_Flag.Trim = "N" Then
                Is_Charge = "Y"

            ElseIf Charge_Flag.Trim = "O" Then
                Is_Charge = "Y"

            ElseIf Charge_Flag.Trim = "S" Then
                Is_Charge = "Y"

            ElseIf Charge_Flag.Trim = "X" Then
                Is_Charge = "N"

            End If

            Return Is_Charge

        Catch ex As Exception
            Return "Y"
        End Try

    End Function

End Class
